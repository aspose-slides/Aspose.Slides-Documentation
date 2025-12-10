---
title: Secure Presentations with Passwords in C++
linktitle: Password Protection
type: docs
weight: 20
url: /cpp/password-protected-presentation/
keywords:
- lock PowerPoint
- lock presentation
- unlock PowerPoint
- unlock presentation
- protect PowerPoint
- protect presentation
- set password
- add password
- encrypt PowerPoint
- encrypt presentation
- decrypt PowerPoint
- decrypt presentation
- write protection
- PowerPoint security
- presentation security
- remove password
- remove protection
- remove encryption
- disable password
- disable protection
- remove write protection
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Learn how to effortlessly lock and unlock password-protected PowerPoint and OpenDocument presentations with Aspose.Slides for C++. Secure your presentations."
---


## **About Password Protection**
### **How Does Password Protection for Presentations Work?**
When you password protect a presentation, it means you are setting a password that enforces certain restrictions on the presentation. To remove the restrictions, the password has to be entered. A password-protected presentation is considered a locked presentation.

Typically, you can set a password to enforce these restrictions on a presentation:

- **Modification**

  If you want only certain users to modify your presentation, you can set a modification restriction. The restriction here prevents people from modifying, changing, or copying things in your presentation (unless they provide the password). 

  However, in this case, even without the password, a user will be able to access your document and open it. In this read-only mode, the user can view the contents or things—hyperlinks, animations, effects, and others—inside your presentation, but they cannot copy items or save the presentation. 

- **Opening**

  If you want only certain users to open your presentation, you can set an opening restriction. The restriction here prevents people from even viewing the contents of your presentation (unless they provide the password).

  Technically, the opening restriction also prevents users from modifying your presentations: When people cannot open a presentation, they cannot make modify or make changes to it. 
  
  **Note** that when you password protect a presentation to prevent opening, the presentation file becomes encrypted.

## **How to Password Protect a Presentation Online**

1. Go to our [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock) page. 

   ![todo:image_alt_text](slides-lock.png)

2. Click **Drop or upload your files**.

3. Select the file you want to password protect on your computer. 

4. Input your preferred password for edit protection; Input your preferred password for view protection. 

5. If you want users to see your presentation as the final copy, tick the **Mark as final** checkbox.

6. Click **PROTECT NOW.** 

7. Click **DOWNLOAD NOW.**

## **Password Protection for Presentations in Aspose.Slides**
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

## **Encrypt a Presentation**

You can encrypt a presentation by setting a password. Then, to modify the locked presentation, a user has to provide the password. 

To encrypt or password protect a presentation, you have to use the encrypt method (from [ProtectionManager](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager)) to set a password for the presentation. You pass the password to the encrypt method and use the save method to save the now encrypted presentation. 

This sample code shows you how to encrypt a presentation:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **Set Write Protection to a Presentation** 

You can add a mark stating “Do not modify” to a presentation. This way, you get to tell users that you do not want them to make changes to the presentation.  

**Note** that the write protection process does not encrypt the presentation. Therefore, users—if they actually want to—can modify the presentation, but to save the changes, they will have to create a presentation with a different name. 

To set a write protection, you have to use the setWriteProtection method. This sample code shows you how to set a write protection to a presentation:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **Load an Encrypted Presentation**

Aspose.Slides allow you to load an encrypted file by passing its password. To decrypt a presentation, you have to call the [RemoveEncryption](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) method with no parameters. You will then have to enter the correct password to load the presentation. 

This sample code shows you how to decrypt a presentation: 

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// work with decrypted presentation
```

## **Remove Encryption from a Presentation**

You can remove the encryption or password protection on a presentation. This way, users become able to access or modify the presentation without restrictions. 

To remove encryption or password protection, you have to call the [RemoveEncryption](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) method. This sample code shows you to remove encryption from a presentation:

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **Remove Write Protection from a Presentation**

You can use Aspose.Slides to remove the write protection used on a presentation file. This way, users get to modify as they like—and they get no warnings when they perform such tasks.

You can remove the write protection from a presentation by using the [RemoveWriteProtection](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50) method. This sample code shows you to remove the write protection from a presentation:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **Get the Properties of an Encrypted Presentation**

Typically, users struggle to get the document properties of an encrypted or password-protected presentation. Aspose.Slides, however, offers a mechanism that allows you to password protect a presentation while retaining the means for users to access the properties of that presentation.

**Note** that when Aspose.Slides encrypts a presentation, the presentation’s document properties get password protected too by default. But if you need to make the presentation’s properties accessible (even after the presentation gets encrypted), Aspose.Slides allows you to do precisely that. 

If you want users to retain the ability to access the properties of a presentation you encrypted, you can pass `true` to the [set_EncryptDocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a67e041b432552969d106f72fa7fe5a1d) method. This sample code shows you how to encrypt a presentation while providing the means for users to access its document properties:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(true);
presentation->get_ProtectionManager()->Encrypt(u"123123");
```

## **Check Whether a Presentation Is Password Protected**

Before you load a presentation, you might want to check and confirm that the presentation has not been protected with a password. This way, you get to avoid errors and similar issues, which come up when a password protected presentation is loaded without its password.

This C++ code shows you how to examine a presentation to see if it is password protected (without loading the presentation itself):

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **Check Whether a Presentation Is Encrypted**

Aspose.Slides allows you to check whether a presentation is encrypted. To perform this task, you can use the [get_IsEncrypted()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68) method, which returns `true` if the presentation is encrypted or `false` if the presentation isn't encrypted. 

This sample code shows you how to check whether a presentation is encrypted:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **Check Whether a Presentation Is Write Protected**

Aspose.Slides allows you to check whether a presentation is write-protected. To perform this task, you can use the [get_IsWriteProtected()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2) method, which returns `true` if the presentation is encrypted or `false` if the presentation isn't encrypted. 

This sample code shows you how to check whether a presentation is write-protected:

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **Verify Presentation Password Usage**

You may want to check and confirm that a specific password has been used to protect a presentation document. Aspose.Slides provides the means for you to validate a password. 

This sample code shows you how to validate a password:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// check if "pass" is matched with
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

It returns `true` if the presentation has been encrypted with the specified password. Otherwise, it returns `false`. 

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **FAQ**

**What encryption methods are supported by Aspose.Slides?**

Aspose.Slides supports modern encryption methods, including AES-based algorithms, ensuring a high level of data security for your presentations.

**What happens if an incorrect password is entered when attempting to open a presentation?**

An exception is thrown if an incorrect password is used, alerting you that access to the presentation is denied. This helps prevent unauthorized access and protects the presentation content.

**Are there any performance implications when working with password-protected presentations?**

The encryption and decryption process may introduce a slight overhead during opening and saving operations. In most cases, this performance impact is minimal and does not significantly affect the overall processing time of your presentation tasks.
