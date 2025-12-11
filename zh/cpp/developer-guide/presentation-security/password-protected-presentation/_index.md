---
title: 在 C++ 中使用密码保护演示文稿
linktitle: 密码保护
type: docs
weight: 20
url: /zh/cpp/password-protected-presentation/
keywords:
- 锁定 PowerPoint
- 锁定 演示文稿
- 解锁 PowerPoint
- 解锁 演示文稿
- 保护 PowerPoint
- 保护 演示文稿
- 设置密码
- 添加密码
- 加密 PowerPoint
- 加密 演示文稿
- 解密 PowerPoint
- 解密 演示文稿
- 写保护
- PowerPoint 安全
- 演示文稿安全
- 移除密码
- 移除保护
- 移除加密
- 禁用密码
- 禁用保护
- 移除写保护
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 轻松锁定和解锁受密码保护的 PowerPoint 与 OpenDocument 演示文稿。确保您的演示文稿安全。"
---

## **关于密码保护**
### **演示文稿的密码保护是如何工作的？**
当您对演示文稿设置密码时，意味着您正在设置一个密码，以对演示文稿强制执行某些限制。要取消这些限制，必须输入密码。受密码保护的演示文稿被视为锁定的演示文稿。

通常，您可以设置密码来对演示文稿强制执行以下限制：

- **修改**

  如果您希望只有特定用户可以修改您的演示文稿，您可以设置修改限制。此限制阻止人们在未提供密码的情况下修改、更改或复制演示文稿中的内容。

  但是，在这种情况下，即使没有密码，用户仍然可以访问您的文档并打开它。处于只读模式时，用户可以查看演示文稿中的内容或元素——超链接、动画、效果等——但无法复制项目或保存演示文稿。

- **打开**

  如果您希望只有特定用户可以打开您的演示文稿，您可以设置打开限制。此限制阻止人们查看演示文稿的内容（除非提供密码）。

  从技术上讲，打开限制也会阻止用户修改您的演示文稿：当人们无法打开演示文稿时，就不能对其进行修改或更改。

  **注意** 当您对演示文稿进行密码保护以阻止打开时，演示文稿文件将被加密。

## **如何在线对演示文稿进行密码保护**

1. 访问我们的[**Aspose.Slides Lock**](https://products.aspose.app/slides/lock)页面。

   ![todo:image_alt_text](slides-lock.png)

2. 单击**将文件拖放或上传**。

3. 在计算机上选择您想要进行密码保护的文件。

4. 输入用于编辑保护的首选密码；输入用于查看保护的首选密码。

5. 如果您希望用户将演示文稿视为最终副本，请勾选**标记为最终**复选框。

6. 单击**立即保护**。

7. 单击**立即下载**。

## **Aspose.Slides 中的演示文稿密码保护**
**支持的格式**

Aspose.Slides 支持对以下格式的演示文稿进行密码保护、加密和类似操作：

- PPTX 和 PPT - Microsoft PowerPoint 演示文稿
- ODP - OpenDocument 演示文稿
- OTP - OpenDocument 演示文稿模板

**支持的操作**

Aspose.Slides 允许您通过以下方式使用密码保护来防止演示文稿被修改：

- 对演示文稿进行加密
- 为演示文稿设置写保护

**其他操作**

Aspose.Slides 还允许您以以下方式执行涉及密码保护和加密的其他任务：

- 解密演示文稿；打开加密的演示文稿
- 移除加密；禁用密码保护
- 移除演示文稿的写保护
- 获取加密演示文稿的属性
- 检查演示文稿是否已加密
- 检查演示文稿是否受密码保护

## **加密演示文稿**

您可以通过设置密码来加密演示文稿。随后，要修改已锁定的演示文稿，用户必须提供密码。

要加密或对演示文稿进行密码保护，您需要使用 encrypt 方法（来自[ProtectionManager](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager)）为演示文稿设置密码。将密码传递给 encrypt 方法，然后使用 save 方法保存已加密的演示文稿。

以下示例代码展示了如何加密演示文稿：
``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```


## **为演示文稿设置写保护**

您可以在演示文稿中添加“禁止修改”的标记。这样，您就可以告诉用户您不希望他们更改演示文稿。

**注意** 写保护过程并不会加密演示文稿。因此，用户——如果他们真的想——可以修改演示文稿，但要保存更改，则必须另存为不同的文件名。

要设置写保护，您需要使用 setWriteProtection 方法。以下示例代码展示了如何为演示文稿设置写保护：
``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```


## **加载加密的演示文稿**

Aspose.Slides 允许您通过传入密码来加载加密文件。要解密演示文稿，您需要调用[RemoveEncryption](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d)方法（无参数）。随后，您必须输入正确的密码才能加载演示文稿。

以下示例代码展示了如何解密演示文稿：
``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// 使用已解密的演示文稿
```


## **从演示文稿中移除加密**

您可以移除演示文稿上的加密或密码保护。这样，用户就能够在没有限制的情况下访问或修改演示文稿。

要移除加密或密码保护，您需要调用[RemoveEncryption](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d)方法。以下示例代码展示了如何从演示文稿中移除加密：
``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```


## **从演示文稿中移除写保护**

您可以使用 Aspose.Slides 移除演示文稿文件上的写保护。这样，用户可以随意修改，而且在执行此类操作时不会收到警告。

您可以通过调用[RemoveWriteProtection](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50)方法来移除写保护。以下示例代码展示了如何从演示文稿中移除写保护：
``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```


## **获取加密演示文稿的属性**

通常，用户难以获取加密或受密码保护的演示文稿的文档属性。Aspose.Slides 提供了一种机制，允许您在对演示文稿进行密码保护的同时，仍保留用户访问该演示文稿属性的方式。

**注意** 当 Aspose.Slides 加密演示文稿时，演示文稿的文档属性默认也会受到密码保护。但如果您需要在演示文稿加密后仍让属性可访问，Aspose.Slides 允许您实现此目的。

如果您希望用户在您加密的演示文稿中仍然能够访问属性，可以向[set_EncryptDocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a67e041b432552969d106f72fa7fe5a1d)方法传入 `true`。以下示例代码展示了如何在加密演示文稿的同时提供访问其文档属性的方式：
``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(true);
presentation->get_ProtectionManager()->Encrypt(u"123123");
```


## **检查演示文稿是否受密码保护**

在加载演示文稿之前，您可能想检查并确认该演示文稿未被密码保护。这样，您可以避免在未提供密码的情况下加载受密码保护的演示文稿时出现错误等问题。

以下 C++ 代码展示了如何在不加载演示文稿本身的情况下检查其是否受密码保护：
```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```


## **检查演示文稿是否已加密**

Aspose.Slides 允许您检查演示文稿是否已加密。要执行此操作，您可以使用[get_IsEncrypted()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68)方法，如果演示文稿已加密则返回 `true`，否则返回 `false`。

以下示例代码展示了如何检查演示文稿是否已加密：
``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```


## **检查演示文稿是否受写保护**

Aspose.Slides 允许您检查演示文稿是否受写保护。要执行此操作，您可以使用[get_IsWriteProtected()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2)方法，如果演示文稿受写保护则返回 `true`，否则返回 `false`。

以下示例代码展示了如何检查演示文稿是否受写保护：
``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```


## **验证演示文稿密码的使用情况**

您可能希望检查并确认已使用特定密码来保护演示文稿文档。Aspose.Slides 提供了验证密码的手段。

以下示例代码展示了如何验证密码：
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// 检查 "pass" 是否匹配
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```


如果演示文稿已使用指定密码加密，则返回 `true`；否则返回 `false`。

{{% alert color="primary" title="See also" %}} 
- [数字签名在 PowerPoint 中](/slides/zh/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常见问题**

**Aspose.Slides 支持哪些加密方法？**

Aspose.Slides 支持包括基于 AES 的现代加密算法，确保演示文稿数据具有高水平的安全性。

**如果在尝试打开演示文稿时输入了错误的密码会怎样？**

使用错误密码时会抛出异常，提示访问演示文稿被拒绝。这有助于防止未授权访问并保护演示文稿内容。

**在处理受密码保护的演示文稿时是否会对性能产生影响？**

加密和解密过程可能在打开和保存操作时带来轻微的开销。在大多数情况下，这种性能影响极小，不会显著影响演示文稿任务的整体处理时间。