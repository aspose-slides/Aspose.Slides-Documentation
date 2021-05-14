---
title: Password Protected Presentation
type: docs
weight: 20
url: /cpp/password-protected-presentation/
keywords: "Lock PowerPoint presentation in C++"
description: "Lock PowerPoint presentation. Password protected PowerPoint in C++"
---

## **Save Password Protected Presentation**
It's possible to save presentations with password protection. The presentation class exposes the [Encrypt](http://www.aspose.com/api/net/slides/aspose.slides/protectionmanager/methods/encrypt) method which sets the password for the presentation. To do this, simply pass the password to the [Encrypt](http://www.aspose.com/api/net/slides/aspose.slides/protectionmanager/methods/encrypt) method and then use the [Save](http://www.aspose.com/api/net/slides/aspose.slides/presentation/methods/save/index) method exposed by the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class as a string to save the presentation.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SaveWithPassword-SaveWithPassword.cpp" >}}

## **Save Password Protected Presentation with Read Access**
It's possible to save presentations with password protection. But in that case access to the presentation's document properties is also prohibited. Aspose.Slides offers a mechanism for password protecting a presentation but still being able to access the document properties in PowerPoint. The [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class exposes the [EncryptDocumentProperties](http://www.aspose.com/api/net/slides/aspose.slides/protectionmanager/properties/index) property that takes a Boolean value to allow or disallow access to the document properties in password protected mode. By default, its value is set to true. The [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class also exposes the [Encrypt](http://www.aspose.com/api/net/slides/aspose.slides/protectionmanager/methods/encrypt) method which sets the password for the presentation.

To do this, simply pass the password to the [Encrypt](http://www.aspose.com/api/net/slides/aspose.slides/protectionmanager/methods/encrypt) method and then use the [Save](http://www.aspose.com/api/net/slides/aspose.slides/presentation/methods/save/index) method exposed by the Presentation class as a string to save the presentation.method.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SaveProperties-SaveProperties.cpp" >}}


## **Save Presentation in Read Only Mode**
Developers can now save presentations with write protection to allow the presentation to be read in read only mode. The [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class exposes the [SetWriteProtection(string Password)](http://www.aspose.com/api/net/slides/aspose.slides/presentation/methods/setwriteprotection) method with which it is possible to save the presentation in read only mode by applying write protection on it. To do so, call the method and set the write protection password. The following code snippet shows you how to apply write protection to a presentation with Aspose.Slides for C++.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SaveAsReadOnly-SaveAsReadOnly.cpp" >}}

## **Remove Write Protection from Presentation**
Aspose.Slides for C++ provides a facility for accessing write protected presentation through the [Presentation](http://www.aspose.com/api/net/slides/aspose.slides/presentation) class. The [IsWriteProtected](http://www.aspose.com/api/net/slides/aspose.slides/presentation/properties/iswriteprotected) property identifies whether a presentation is write protected or not. Then if it is write protected, the protection can be removed using the [RemoveWriteProtection](http://www.aspose.com/api/net/slides/aspose.slides/presentation/methods/removewriteprotection) method.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveWriteProtection-RemoveWriteProtection.cpp" >}}
