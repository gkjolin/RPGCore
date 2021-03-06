﻿using RPGCore.Audio;

namespace RPGCore
{
	[NodeInformation ("Item/Activatable Input", "Input")]
	public class ActivatableNode : BehaviourNode
	{
		public IntInput ManaCost;
		public IntInput QuantityCost;
		public EventOutput OnActivate;
		public SfxGroup ActivateSound;

		protected override void OnSetup (IBehaviourContext context)
		{
			// ConnectionEntry<int> manaCostInput = ManaCost.GetEntry (context);
			// ConnectionEntry<int> quantityCostInput = QuantityCost.GetEntry (context);
			// EventEntry onActivateOutput = OnActivate.GetEntry (context);

			/*equippedOutput.Value = character.Equipped.Value; 

			character.Equipped.onChanged += () => 
			{
				equippedOutput.Value = character.Equipped.Value;
			};*/
		}

		protected override void OnRemove (IBehaviourContext context)
		{

		}

		public void TryUse (ItemSurrogate context, RPGCharacter character)
		{
			ConnectionEntry<int> manaCostInput = ManaCost.GetEntry (context);
			ConnectionEntry<int> quantityCostInput = QuantityCost.GetEntry (context);
			EventEntry onActivateOutput = OnActivate.GetEntry (context);

			if (CanCharacterUse (context, character))
			{
				context.owner.Value.States.CurrentMana.Value -= manaCostInput.Value;
				context.Quantity -= quantityCostInput.Value;

				onActivateOutput.OnEventFired ();
				AudioManager.Play (ActivateSound);
			}
		}

		public bool CanCharacterUse (ItemSurrogate context, RPGCharacter character)
		{
			ConnectionEntry<int> manaCostInput = ManaCost.GetEntry (context);
			ConnectionEntry<int> quantityCostInput = QuantityCost.GetEntry (context);

			if (context.Quantity < quantityCostInput.Value)
				return false;

			if (context.owner.Value.States.CurrentMana.Value < manaCostInput.Value)
				return false;

			return true;
		}
	}
}