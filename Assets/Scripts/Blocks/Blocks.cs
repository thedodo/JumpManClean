using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public abstract class Blocks
{
	protected string name;
	protected bool deadly;
	protected int effect;
		
	protected Sprite icon;
		
		public Blocks()
		{
		}
		
		public Blocks(string name)
		{
			this.name = name;
		}
		
		
		public String getBlockName()
		{
			return name;
		}
		
		
		public Sprite Icon
		{
			get { return icon; }
		}
		
}

