﻿// (c) Copyright HutongGames, LLC 2010-2018. All rights reserved.

using System;
using UnityEngine;
using System.IO;
namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("GPU Instancer")]
	public class GPURemovePrefabInstance : ComponentAction<GPUInstancer.GPUPrefabInstancerProxy>
	{
		[RequiredField]
		[CheckForComponent(typeof(GPUInstancer.GPUPrefabInstancerProxy))]
        public FsmOwnerDefault gameObject;
		//public FsmEvent Spawn;

		[System.NonSerialized]
		 GPUInstancer.GPUPrefabInstancerProxy GPUPrefabInstancer;

		[RequiredField]
		public FsmGameObject destroy;
		

		public override void OnEnter()
		{
           
			 if (UpdateCache (Fsm.GetOwnerDefaultTarget (gameObject))) {
				GPUPrefabInstancer = (GPUInstancer.GPUPrefabInstancerProxy)this.cachedComponent;
				Execute ();
			}

			Finish();
		} 

		void Execute(){
			
			GPUPrefabInstancer.objectname = destroy.Value;
			GPUPrefabInstancer.Destroy();
			Transform.Destroy (destroy.Value);
			
		}

	}
}