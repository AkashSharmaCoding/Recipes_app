package md5f92db10386ed08bec461c0fed5d8d554;


public class Activity4ClientWelcome
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Recipes.Activity4ClientWelcome, Recipes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Activity4ClientWelcome.class, __md_methods);
	}


	public Activity4ClientWelcome ()
	{
		super ();
		if (getClass () == Activity4ClientWelcome.class)
			mono.android.TypeManager.Activate ("Recipes.Activity4ClientWelcome, Recipes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
