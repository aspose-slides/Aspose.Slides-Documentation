---
title: Password Protected Presentation
type: docs
weight: 20
url: /java/password-protected-presentation/
keywords: "Lock PowerPoint presentation in Java"
description: "Lock PowerPoint presentation. Password protected PowerPoint in Java"
---

## **Save Password Protected Presentation**
It's possible to save presentations with password protection. The [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class exposes the **Encrypt** method which sets a password for the presentation. To do this, simply pass the password to the **Encrypt** method and then use the **Save** method exposed by the Presentation class as a string to save the presentation.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SavingAPasswordProtectedPresentation-SavingAPasswordProtectedPresentation.java" >}}
## **Save Password Protected Presentation with Read Access**
It is possible to save presentations with password protection. 
But in that case access to the presentation's document properties is also prohibited. 
Aspose.Slides offers a mechanism for password protecting a presentation but still 
being able to access the document properties in PowerPoint.

The [**Presentation**](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) exposes the [**setEncryptDocumentProperties**](https://apireference.aspose.com/java/slides/com.aspose.slides/IProtectionManager#setEncryptDocumentProperties-boolean-) property that takes a Boolean value to allow or disallow access to the document properties in password-protected mode. By default, its value is set to **true**. The Presentation class also exposes the [**Encrypt** ](https://apireference.aspose.com/java/slides/com.aspose.slides/IProtectionManager#encrypt-java.lang.String-)method which sets the presentation's password. To do this, simply pass the password to the **Encrypt** method and then use the **Save** method exposed by the Presentation class as a string to save the presentation method.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SavingAPassProtectPresWithReadAccessToDocProps-SavingAPassProtectPresWithReadAccessToDocProps.java" >}}

## **Save Presentation in Read Only Mode**
Developers can save presentations with write protection to allow the presentation to be read in read-only mode. The [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class exposes the [**SetWriteProtection(string Password)**](https://apireference.aspose.com/java/slides/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) method with which it is possible to save the presentation in read-only mode by applying write protection on it. To do so, call the method and set the write protection password.

The code example that shows how to apply write protection to a presentation with Aspose.Slides for Java.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-SavingPresentationInReadOnlyMode-SavingPresentationInReadOnlyMode.java" >}}

## **Remove Write Protection from Presentation**
Aspose.Slides for Java provides a facility for accessing write-protected presentation through the [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class. The [**IsWriteProtected**](https://apireference.aspose.com/java/slides/com.aspose.slides/IProtectionManager#isWriteProtected--) property identifies whether a presentation is write-protected or not. If it is write-protected, the protection can be removed using the [**removeWriteProtection()**](https://apireference.aspose.com/java/slides/com.aspose.slides/IProtectionManager#removeWriteProtection--) method.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Saving-RemovingWriteProtectionFromAPresentation-RemovingWriteProtectionFromAPresentation.java" >}}

## **Access Document Properties of Password Protected Presentation without Password**
Aspose.Slides for Java provides a facility to access the **Document Properties** of the presentation in password-protected presentation without supplying password using [Presentation](https://apireference.aspose.com/java/slides/com.aspose.slides/Presentation) class. It offers few overloaded constructors and we can make use of one of the suitable constructors of Presentation class to create its object based on an existing presentation. In the example given below, we are accessing the Document Properties of a password protected presentation. We will use [LoadOptions](https://apireference.aspose.com/java/slides/com.aspose.slides/LoadOptions) class object to set the presentation access properties.

{{< gist "aspose-slides" "a1b0b7f99c2b44d84c6d" "Examples-src-main-java-com-aspose-slides-examples-Presentation-Opening-AccessDocPropOfProtectedPresentationWithoutPassword-AccessDocPropOfProtectedPresentationWithoutPassword.java" >}}

