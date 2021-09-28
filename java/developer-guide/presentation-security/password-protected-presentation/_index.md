---
title: Password Protected Presentation
type: docs
weight: 20
url: /java/password-protected-presentation/
keywords: "Lock PowerPoint presentation in Java"
description: "Lock PowerPoint presentation. Password protected PowerPoint in Java"
---

## **About Password Protection**
### **How does password protection for presentation work?**
When you password protect a presentation, it means you are setting a password that enforces certain restrictions on the presentation. To remove the restrictions, the password has to be entered. A password-protected presentation is considered a locked presentation.

Typically, you can set a password to enforce these restrictions on a presentation:

- **Modification**

  If you want only certain users to modify your presentation, you can set a modification restriction. The restriction here prevents people from modifying, changing, or copying things in your presentation (unless they provide the password). 

  However, in this case, even without the password, a user will be able to access your document and open it. In this read-only mode, the user can view the contents or things—hyperlinks, animations, effects, and others—inside your presentation, but they cannot copy items or save the presentation. 

- **Opening**

  If you want only certain users to open your presentation, you can set an opening restriction. The restriction here prevents people from even viewing the contents of your presentation (unless they provide the password).

  Technically, the opening restriction also prevents users from modifying your presentations: When people cannot open a presentation, they cannot make modify or make changes to it. 
  
  **Note** that when you password protect a presentation to prevent opening, the presentation file becomes encrypted.

## **How to Password Protect a Presentation**

1. Go to our [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock) page. 

   ![todo:image_alt_text](slides-lock.png)

2. Click **Drop or upload your files**.

3. Select the file you want to password protect on your computer. 

4. Input your preferred password for edit protection; Input your preferred password for view protection. 

5. If you want users to see your presentation as the final copy, tick the **Mark as final** checkbox.

6. Click **PROTECT NOW.** 

7. Click **DOWNLOAD NOW.**

### **Password Protection for Presentations in Aspose.Slides**
**Supported formats**

Aspose.Slides supports password protection, encryption, and similar operations for presentations in these formats: 

- PPTX and PPT - Microsoft PowerPoint Presentation 
- ODP - OpenDocument Presentation 
- OTP -  OpenDocument Presentation Template 

**Supported operations**

Aspose.Slides allows you to use password protection on presentations to prevent modifications in these ways:

- Encrypting a presentation
- Setting a write protection to a presentation

**Other operations**

Aspose.Slides allows you to perform other tasks involving password protection and encryption in these ways:

- Decrypting a presentation; opening an encrypted presentation
- Removing encryption; disabling password protection
- Removing write protection from a presentation
- Getting the properties of an encrypted presentation
- Checking whether a presentation is encrypted
- Checking whether a presentation is password protected.

## **Encrypting a Presentation**

You can encrypt a presentation by setting a password. Then, to modify the locked presentation, a user has to provide the password. 

To encrypt or password protect a presentation, you have to use the encrypt method (from [IProtectionManager](https://apireference.aspose.com/slides/java/com.aspose.slides/IProtectionManager)) to set a password for the presentation. You pass the password to the encrypt method and use the save method to save the now encrypted presentation. 

This sample code shows you how to encrypt a presentation:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().encrypt("123123");
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Setting Write Protection to a Presentation**

You can add a mark stating “Do not modify” to a presentation. This way, you get to tell users that you do not want them to make changes to the presentation.  

**Note** that the write protection process does not encrypt the presentation. Therefore, users—if they actually want to—can modify the presentation, but to save the changes, they will have to create a presentation with a different name. 

To set a write protection, you have to use the [setWriteProtection](https://apireference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#setWriteProtection-java.lang.String-) method. This sample code shows you how to set a write protection to a presentation:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("123123");
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Decrypting a Presentation; Opening an Encrypted Presentation**

Aspose.Slides allow you to load an encrypted file by passing its password. To decrypt a presentation, you have to call the [removeEncryption](https://apireference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#removeEncryption--) method with no parameters. You will then have to enter the correct password to load the presentation. 

This sample code shows you how to decrypt a presentation: 

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    // work with decrypted presentation
} finally {
    if (presentation != null) presentation.dispose();
}
}
```

## **Removing Encryption; Disabling Password Protection**

You can remove the encryption or password protection on a presentation. This way, users become able to access or modify the presentation without restrictions. 

To remove encryption or password protection, you have to call the [removeEncryption](https://apireference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#removeEncryption--) method. This sample code shows you to remove encryption from a presentation:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("123123");
Presentation presentation = new Presentation("pres.pptx", loadOptions);
try {
    presentation.getProtectionManager().removeEncryption();
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Removing Write Protection from a Presentation**

You can use Aspose.Slides to remove the write protection used on a presentation file. This way, users get to modify as they like—and they get no warnings when they perform such tasks.

You can remove the write protection from a presentation by using the [removeWriteProtection](https://apireference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#removeWriteProtection--) method. This sample code shows you to remove the write protection from a presentation:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Getting the Properties of an Encrypted Presentation**

Typically, users struggle to get the document properties of an encrypted or password-protected presentation. Aspose.Slides, however, offers a mechanism that allows you to password protect a presentation while retaining the means for users to access the properties of that presentation.

**Note** that when Aspose.Slides encrypts a presentation, the presentation’s document properties get password protected too by default. But if you need to make the presentation’s properties accessible (even after the presentation gets encrypted), Aspose.Slides allows you to do precisely that. 

If you want users to retain the ability to access the properties of a presentation you encrypted, you can set the [encryptDocumentProperties](https://apireference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#getEncryptDocumentProperties--) property to `true`. This sample code shows you how to encrypt a presentation while providing the means for users to access its document properties:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setEncryptDocumentProperties(true);
    presentation.getProtectionManager().encrypt("123123");
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Checking whether a Presentation is Encrypted**

Aspose.Slides allows you to check whether a presentation is encrypted. To perform this task, you can use the [isEncrypted](https://apireference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#isEncrypted--) property, which returns `true` if the presentation is encrypted or `false` if the presentation isn't encrypted. 

This sample code shows you how to check whether a presentation is encrypted:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isEncrypted();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Checking whether a Presentation is Write Protected**

Aspose.Slides allows you to check whether a presentation is write-protected. To perform this task, you can use the [isWriteProtected](https://apireference.aspose.com/slides/java/com.aspose.slides/IProtectionManager#isWriteProtected--) property, which returns `true` if the presentation is encrypted or `false` if the presentation isn't encrypted. 

This sample code shows you how to check whether a presentation is write-protected:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    boolean isEncrypted = presentation.getProtectionManager().isWriteProtected();
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Validating or Confirming that a Specific Password has been used to Protect a Presentation**

You may want to check and confirm that a specific password has been used to protect a presentation document. Aspose.Slides provides the means for you to validate a password. 

This sample code shows you how to validate a password:

```java
Presentation presentation = new Presentation("pres.pptx");
try {
    // check if "pass" is matched with
    boolean isWriteProtected = presentation.getProtectionManager().checkWriteProtection("my_password");
} finally {
    if (presentation != null) presentation.dispose();
}
```

It returns `true` if the presentation has been encrypted with the specified password. Otherwise, it returns `false`. 

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/net/digital-signature-in-powerpoint/)
{{% /alert %}}