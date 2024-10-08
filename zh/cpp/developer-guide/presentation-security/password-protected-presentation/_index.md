---
title: 密码保护演示文稿
type: docs
weight: 20
url: /zh/cpp/password-protected-presentation/
keywords: "锁定 PowerPoint 演示文稿"
description: "锁定 PowerPoint 演示文稿。使用 Aspose.Slides 进行密码保护的 PowerPoint 演示文稿。"
---


## **关于密码保护**
### **演示文稿的密码保护是如何工作的？**
当您对演示文稿进行密码保护时，这意味着您正在设置一个密码，以强制对演示文稿施加某些限制。要移除这些限制，必须输入密码。被密码保护的演示文稿被视为锁定的演示文稿。

通常，您可以设置一个密码来强制这些限制：

- **修改**

  如果您希望只有某些用户可以修改您的演示文稿，您可以设置修改限制。此限制会阻止人们修改、更改或复制您演示文稿中的内容（除非他们提供密码）。

  然而，在这种情况下，即使没有密码，用户仍然可以访问您的文档并打开它。在此只读模式下，用户可以查看演示文稿中的内容或元素——超链接、动画、效果等——但他们无法复制项目或保存演示文稿。

- **打开**

  如果您希望只有某些用户可以打开您的演示文稿，您可以设置打开限制。此限制会阻止人们甚至查看演示文稿的内容（除非他们提供密码）。

  从技术上讲，打开限制也阻止用户修改您的演示文稿：当人们无法打开演示文稿时，他们就无法修改或更改它。

  **注意** 当您对演示文稿进行密码保护以防止打开时，演示文稿文件将被加密。

## **如何在线对演示文稿进行密码保护**

1. 请访问我们的 [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock) 页面。

   ![todo:image_alt_text](slides-lock.png)

2. 点击 **拖放或上传文件**。

3. 在您的计算机上选择要进行密码保护的文件。

4. 输入您希望用于编辑保护的密码；输入您希望用于查看保护的密码。

5. 如果您希望用户将演示文稿视为最终副本，请勾选 **标记为最终** 复选框。

6. 点击 **立即保护**。

7. 点击 **立即下载**。

## **Aspose.Slides 中的演示文稿密码保护**
**支持的格式**

Aspose.Slides 支持对以下格式的演示文稿进行密码保护、加密和类似操作：

- PPTX 和 PPT - Microsoft PowerPoint 演示文稿
- ODP - OpenDocument 演示文稿
- OTP - OpenDocument 演示文稿模板

**支持的操作**

Aspose.Slides 允许您使用密码保护演示文稿以防止以以下方式进行修改：

- 对演示文稿进行加密
- 为演示文稿设置写保护

**其他操作**

Aspose.Slides 允许您以以下方式执行涉及密码保护和加密的其他任务：

- 解密演示文稿；打开加密的演示文稿
- 移除加密；禁用密码保护
- 从演示文稿中移除写保护
- 获取加密演示文稿的属性
- 检查演示文稿是否被加密
- 检查演示文稿是否被密码保护。

## **加密演示文稿**

您可以通过设置一个密码来加密演示文稿。然后，要修改锁定的演示文稿，用户必须提供密码。

要加密或对演示文稿进行密码保护，您必须使用 encrypt 方法（来自 [ProtectionManager](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager)）为演示文稿设置密码。您将密码传递给 encrypt 方法，并使用 save 方法保存现在加密的演示文稿。

此示例代码向您展示了如何加密演示文稿：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **为演示文稿设置写保护**

您可以在演示文稿中添加 “请勿修改” 的标记。这样，您可以告诉用户您不希望他们对演示文稿进行更改。

**注意** 写保护过程并不会加密演示文稿。因此，用户——如果他们确实想要——可以修改演示文稿，但要保存更改，他们必须创建一个不同名称的演示文稿。

要设置写保护，您必须使用 setWriteProtection 方法。此示例代码向您展示了如何为演示文稿设置写保护：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **解密演示文稿；打开加密的演示文稿**

Aspose.Slides 允许您通过传递其密码来加载加密文件。要解密演示文稿，您必须调用 [RemoveEncryption](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) 方法，而不带参数。然后，您必须输入正确的密码以加载演示文稿。

此示例代码向您展示了如何解密演示文稿：

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// 工作与解密的演示文稿
```

## **移除加密；禁用密码保护**

您可以移除演示文稿上的加密或密码保护。这样，用户就可以毫有限制地访问或修改演示文稿。

要移除加密或密码保护，您必须调用 [RemoveEncryption](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) 方法。此示例代码向您展示了如何从演示文稿中移除加密：

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **从演示文稿中移除写保护**

您可以使用 Aspose.Slides 从演示文稿文件中移除写保护。这样，用户就可以随意修改——当他们执行此类操作时没有警告。

您可以通过使用 [RemoveWriteProtection](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50) 方法从演示文稿中移除写保护。此示例代码向您展示了如何从演示文稿中移除写保护：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **获取加密演示文稿的属性**

通常，用户在获取加密或密码保护的演示文稿的文档属性时会遇到困难。然而，Aspose.Slides 提供了一种机制，允许您在对演示文稿进行密码保护的同时，保留用户访问该演示文稿属性的手段。

**注意** 当 Aspose.Slides 加密演示文稿时，演示文稿的文档属性默认也会被密码保护。但如果您希望使演示文稿的属性在演示文稿被加密后仍可访问，Aspose.Slides 允许您做到这一点。

如果您希望用户能够访问您加密的演示文稿的属性，可以将 `true` 传递给 [set_EncryptDocumentProperties()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a67e041b432552969d106f72fa7fe5a1d) 方法。此示例代码向您展示了如何加密演示文稿，同时提供用户访问其文档属性的途径：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(true);
presentation->get_ProtectionManager()->Encrypt(u"123123");
```

## **在加载演示文稿之前检查它是否被密码保护**

在加载演示文稿之前，您可能希望检查并确认演示文稿未被密码保护。这样，您可以避免错误和类似问题，这些问题在加载一个被密码保护的演示文稿但没有其密码时会出现。

此 C++ 代码向您展示了如何检查演示文稿是否被密码保护（而不加载演示文稿本身）：

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"该演示文稿是否被密码保护: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **检查演示文稿是否已加密**

Aspose.Slides 允许您检查演示文稿是否已加密。要执行此任务，您可以使用 [get_IsEncrypted()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68) 方法，该方法返回 `true` 如果演示文稿已加密，或者如果演示文稿未加密则返回 `false`。

此示例代码向您展示了如何检查演示文稿是否已加密：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **检查演示文稿是否受到写保护**

Aspose.Slides 允许您检查演示文稿是否受到写保护。要执行此任务，您可以使用 [get_IsWriteProtected()](https://reference.aspose.com/slides/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2) 方法，该方法返回 `true` 如果演示文稿受到写保护，或者如果演示文稿未加密则返回 `false`。

此示例代码向您展示了如何检查演示文稿是否受到写保护：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **验证或确认某个特定密码是否用于保护演示文稿**

您可能想要检查并确认某个特定密码是否用于保护演示文稿文档。Aspose.Slides 提供了验证密码的手段。

此示例代码向您展示了如何验证密码：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// 检查 "pass" 是否与之匹配
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

如果演示文稿被指定的密码加密，则返回 `true`。否则，返回 `false`。 

{{% alert color="primary" title="另见" %}} 
- [PowerPoint 中的数字签名](/slides/zh/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}