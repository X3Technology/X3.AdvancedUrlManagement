# X3.AdvancedUrlManagement

This DNN extension provides some UXs for managing the settings of DNN's Advanced Url Management functionality. It includes some Persona Bar UX and some normal DNN module UX.

This is a major update from https://github.com/mathisjay/X3.DnnUrlManagement, so I created it as a new repo.

This was developed on DNN 9.2, specifically with the new persona bar in mind.  It should work fine with any DNN9x version.  

This module does not actually do much other than give access to all of the AUM_ settings that are used by DNN to control how DNN rewrites and redirects URLs.

There are two parts to AUM_.  
1) HOST settings, which basically set the default values for all Portals within within the DNN installation
2) Portal settings, which can override the HOST settings at the portaL level.

The install package will create a couple of things for you:
1) A Host Settings UX will be created in the Persona Bar's 'Settings' section.
2) A Portal Settings UX will be created in the Persona Bar's 'Manage' section.
3) Also, create a new 'normal' module with the same UX that can be placed on any usual DNN page, if you wish.
	Note: dropping this module on a page will actually put both the HOST and PORTAL settings UX on the page.  You can move one of them to another page if you wish for security reasons.

The extension is written with Angular 1x as a kind of proof on concept on how to build a Persona Bar extension with Angular as opposed to React.

I'm sure there are lots of opportunities for improvement, so feel free to leave me some feedback.

NOTE: This iteration drops the functionality for managing the Portal's Page URLs.  This was intentional as DNN 9x now includes this functionality directly in the Page Settings, so it was no longer needed here.

