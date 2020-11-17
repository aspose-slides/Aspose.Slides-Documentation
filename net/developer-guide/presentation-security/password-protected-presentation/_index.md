---
title: Password Protected Presentation
type: docs
weight: 20
url: /net/password-protected-presentation/
keywords: "Lock PowerPoint presentation"
description: "Lock PowerPoint presentation. Password protected PowerPoint with Aspose.Slides."
---


## **About Password Protection**
### **What is Presentation Password Protection**
Password protection on presentation is when we set a password on a presentation to allow operating with it only for authorized users. This means, that only users, who know the password set on the presentation, can operate with it. Password protected presentation is also called locked presentation. Password protection can be set to prohibit:

- Modify.

  If presentation is password protected from modifying, you have two options: a) enter the password while opening to allow modifying presentation; b) open it in read-only mode, without entering the password.
  Read only mode means, that you can open presentation to view it, however you can not make any changes into it. Note, that all the content of presentation will be still available: hyperlinks, animations, effects, etc. In read only mode its not possible to copy paste the content of presentation. You can not save presentation in this mode too.

  Actually, you can edit the presentation, however you can not save these changes into this presentation. If you want to save changes made to presentation - you will need to enter the password. Otherwise, it is possible to save the changes by saving presentation as a new one, with a different file name.
  Protecting presentation from modifying is useful when you need to work on it in collaboration with others.
- Open.

  Presentation can be password protected from opening. In this case, its protected from modifying too. To open presentation, it is required to enter the password.
### **Presentation Password Protection in Aspose.Slides**
In [**Aspose.Slides**](https://products.aspose.com/slides/net) password protection from modifying can be divided on two types:

- **Encryption** 
  Presentation is encrypted with the password provided, it can not be modifies without setting a password.
- **Write Protection** 
  Presentation is not encrypted with password, but its just marked as *"do not modify"* presentation. This is done to notify users, that this presentation should not be changed. Actually, such presentation can be modified, but to save the changes you will have to create a new presentation with a different file name.



[**Aspose.Slides**](https://products.aspose.com/slides/net) supports password protection for both PowerPoint (PPTX, PPT) and OpenOffice (ODP) presentation formats. 
In [Aspose.Slides](https://products.aspose.com/slides/net), presentation password 
protection feature is represented by 
[**IProtectionManager**](https://apireference.aspose.com/net/slides/aspose.slides/iprotectionmanager). Each [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) object 
has [**ProtectionManager**](https://apireference.aspose.com/net/slides/aspose.slides/presentation/properties/protectionmanager) 
property to refer its methods:

- [**Encrypt**](https://apireference.aspose.com/net/slides/aspose.slides/iprotectionmanager/methods/encrypt) 
  Under the cover of password protection process, presentation is actually encrypted with the password. Encryption algorithm implemented by Aspose.Slides is used to do that, and you only need to pass the password into Encrypt method.
- [**RemoveEncryption**](https://apireference.aspose.com/net/slides/aspose.slides/iprotectionmanager/methods/removeencryption) 
  To decrypt presentation, you need to call RemoveEncryption method with no parameters. Note, that before that you will have to enter password to load this presentation. 
  See more: [Unlock Presentation](/slides/net/password-protected-presentation/#passwordprotectedpresentation-unlockpresentation).
- [**SetWriteProtection**](https://apireference.aspose.com/net/slides/aspose.slides/iprotectionmanager/methods/setwriteprotection) 
  This method is used to set write protection to presentation, and to do that you need to pass presentation password into the method.
- [**RemoveWriteProtection**](https://apireference.aspose.com/net/slides/aspose.slides/iprotectionmanager/methods/removewriteprotection) 
  To remove write protection, just call this method with no parameters.



[**IsEncrypted**](https://apireference.aspose.com/net/slides/aspose.slides/iprotectionmanager/properties/isencrypted) property is 
used to check if presentation is encrypted, 
[**IsWriteProtected**](https://apireference.aspose.com/net/slides/aspose.slides/iprotectionmanager/properties/iswriteprotected) - to check is its write protected.

Note that, when presentation is password protected - its document properties are 
password protected by default too. With Aspose.Slides, its possible to change 
this behavior and make document properties available even for locked presentation.
For that, [**EncryptDocumentProperties**](https://apireference.aspose.com/net/slides/aspose.slides/iprotectionmanager/properties/encryptdocumentproperties) property needs to be set true. 


## **Lock Presentation**
To lock PowerPoint (or OpenOffice) presentation means to create password protected presentation. To create password protected presentation you just need to set a password to presentation. Password protection is a feature used in both PowerPoint and OpenOffice presentation formats. While password is being set to presentation, this presentation is encrypted with the password. So, to encrypt (password protect) presentation do the following:



[**ProtectionManager** ](https://apireference.aspose.com/net/slides/aspose.slides/iprotectionmanager)contains [**Encrypt**](https://apireference.aspose.com/net/slides/aspose.slides/iprotectionmanager/methods/encrypt) method which sets a password for the presentation. Simply pass the password to the Encrypt method and then use Save method exposed by the Presentation to save the presentation.



You may take a look at demo app, demonstrating presentation lock feature in Aspose.Slides. For that, visit [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock) online app:

[](https://products.aspose.app/slides/lock)

[![todo:image_alt_text](slides-lock.png)](https://products.aspose.app/slides/lock)
## **Open Locked Presentation**
To open password protected presentation, use overloaded constructors of [Presentation ](https://apireference.aspose.com/net/slides/aspose.slides/presentation)class. Pass [**LoadOptions** ](https://apireference.aspose.com/net/slides/aspose.slides/loadoptions)class object to set the access password to open password protected presentation.


## **Get Document Properties in Locked Presentation**
When presentation is locked (password protected), the document properties become also prohibited. Aspose.Slides offers a mechanism for password protecting a presentation, but still being able to access the document properties in PowerPoint. The [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class exposes the [**EncryptDocumentProperties**](https://apireference.aspose.com/net/slides/aspose.slides/protectionmanager/properties/encryptdocumentproperties) property that takes a Boolean value to allow or disallow access to the document properties in password protected presentation. By default, its value is set to true.


## **Unlock Presentation**
To unlock PowerPoint (or OpenOffice) presentation, you need to open password protected presentation and then encrypt it. To open password protected presentation, use Presentation constructor with LoadOp[LoadOptions ](https://apireference.aspose.com/net/slides/aspose.slides/loadoptions)set with a presentation password. To unlock or encrypt presentation, call [**RemoveEncryption** ](https://apireference.aspose.com/net/slides/aspose.slides/iprotectionmanager/methods/removeencryption)method by [**ProtectionManager**](https://apireference.aspose.com/net/slides/aspose.slides/iprotectionmanager):



To try presentation unlock feature alive, you may try free online app [**Aspose.Slides Unlock**](https://products.aspose.app/slides/unlock):

[](https://products.aspose.app/slides/unlock)

[![todo:image_alt_text](slides-unlock.png)](https://products.aspose.app/slides/unlock)

## **Set Write Protection to Presentation**
To make a read only PowerPoint (or OpenOffice) presentation, you need to set write protection on it. For that use [**SetWriteProtection** ](https://apireference.aspose.com/net/slides/aspose.slides/iprotectionmanager/methods/setwriteprotection)method from [**ProtectionManager**](https://apireference.aspose.com/net/slides/aspose.slides/iprotectionmanager), with presentation password pass into it:


## **Remove Write Protection from Presentation**
Aspose.Slides for .NET provides a facility for accessing write protected presentation through the [Presentation](https://apireference.aspose.com/net/slides/aspose.slides/presentation) class. The [**IsWriteProtected**](https://apireference.aspose.com/net/slides/aspose.slides/iprotectionmanager/properties/iswriteprotected) property 
identifies whether a presentation is write protected or not. 
Then if it is write protected, the protection can be removed using the 
[**RemoveWriteProtection**](https://apireference.aspose.com/net/slides/aspose.slides/iprotectionmanager/methods/removewriteprotection) method.



{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/net/digital-signature-in-powerpoint/)
{{% /alert %}}