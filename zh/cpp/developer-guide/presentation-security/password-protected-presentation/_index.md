---
title: 使用 C++ 锁定演示文稿的密码保护
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
- 设置 密码
- 添加 密码
- 加密 PowerPoint
- 加密 演示文稿
- 解密 PowerPoint
- 解密 演示文稿
- 写入保护
- PowerPoint 安全
- 演示文稿 安全
- 移除 密码
- 移除 保护
- 移除 加密
- 禁用 密码
- 禁用 保护
- 移除 写入保护
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for C++ 轻松锁定和解锁受密码保护的 PowerPoint 和 OpenDocument 演示文稿。保护您的演示文稿。"
---
## **简介**

当您为演示文稿设置密码保护时，即为演示文稿设定一个密码，以强制实施特定限制。要取消这些限制，必须输入密码。受密码保护的演示文稿被视为已锁定的演示文稿。

通常，您可以为演示文稿设置密码，以强制实施以下限制：

- **修改**

  如果您希望只有特定用户能够修改您的演示文稿，可以设置修改限制。此限制阻止他人在未提供密码的情况下修改、改变或复制演示文稿中的内容。

  但是，在这种情况下，即使没有密码，用户仍然可以访问并打开文档。以只读模式，用户可以查看演示文稿中的内容或对象——超链接、动画、效果等——但无法复制项目或保存演示文稿。

- **打开**

  如果您希望只有特定用户能够打开您的演示文稿，可以设置打开限制。此限制阻止他人在未提供密码的情况下查看演示文稿的内容。

  从技术上讲，打开限制同样阻止用户修改演示文稿：当用户无法打开演示文稿时，他们就无法对其进行修改或更改。

  **注意** 当您为演示文稿设置密码以防止打开时，演示文稿文件会被加密。

## **在线为演示文稿设置密码保护**

1. 访问我们的[**Aspose.Slides Lock**](https://products.aspose.app/slides/zh/lock)页面。

   ![todo:image_alt_text](slides-lock.png)

2. 单击**Drop or upload your files**。

3. 在计算机上选择您要设置密码保护的文件。

4. 输入您用于编辑保护的首选密码；输入您用于查看保护的首选密码。

5. 如果希望用户将您的演示文稿视为最终版本，请勾选**Mark as final**复选框。

6. 单击**PROTECT NOW.** 

7. 单击**DOWNLOAD NOW.**

## **Aspose.Slides 中的演示文稿密码保护**
**支持的格式**

Aspose.Slides 支持对以下格式的演示文稿进行密码保护、加密及类似操作：

- PPTX 和 PPT - Microsoft PowerPoint 演示文稿
- ODP - OpenDocument 演示文稿
- OTP - OpenDocument 演示文稿模板

**支持的操作**

Aspose.Slides 允许您通过以下方式使用密码保护演示文稿，以防止修改：

- 加密演示文稿
- 为演示文稿设置写保护

**其他操作**

Aspose.Slides 还允许您以以下方式执行其他与密码保护和加密相关的任务：

- 解密演示文稿；打开加密的演示文稿
- 移除加密；禁用密码保护
- 移除演示文稿的写保护
- 获取加密演示文稿的属性
- 检查演示文稿是否已加密
- 检查演示文稿是否已设置密码保护

## **加密演示文稿**

您可以通过设置密码来加密演示文稿。随后，要修改已锁定的演示文稿，用户必须提供密码。

要加密或设置密码保护演示文稿，需使用 [ProtectionManager](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.protection_manager) 中的 encrypt 方法为演示文稿设置密码。将密码传递给 encrypt 方法后，再使用 save 方法保存已加密的演示文稿。

以下示例代码演示如何加密演示文稿：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
```

## **为演示文稿设置写保护**

您可以在演示文稿中添加“请勿修改”标记。这样即可告知用户您不希望他们对演示文稿进行更改。

**注意** 写保护过程并不会加密演示文稿。因此，用户如果真的想修改演示文稿，仍然可以进行修改，只是在保存更改时必须另存为不同的文件名。

要设置写保护，需要使用 setWriteProtection 方法。以下示例代码演示如何为演示文稿设置写保护：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->SetWriteProtection(u"123123");
presentation->Save(u"write-protected-pres.pptx", SaveFormat::Pptx);
```

## **加载加密的演示文稿**

Aspose.Slides 允许您通过传递密码来加载加密文件。要解密演示文稿，需要调用 [RemoveEncryption](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) 方法（无参数），随后输入正确的密码以加载演示文稿。

以下示例代码演示如何解密演示文稿：

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

// 对解密后的演示文稿进行操作
```

## **移除演示文稿的加密**

您可以移除演示文稿的加密或密码保护。这样，用户即可在没有任何限制的情况下访问或修改演示文稿。

要移除加密或密码保护，需要调用 [RemoveEncryption](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.protection_manager#a422059278b430a0493680252aa975d4d) 方法。以下示例代码演示如何从演示文稿中移除加密：

``` cpp
auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"123123");
    
auto presentation = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);

presentation->get_ProtectionManager()->RemoveEncryption();
presentation->Save(u"encryption-removed.pptx", SaveFormat::Pptx);
```

## **移除演示文稿的写保护**

您可以使用 Aspose.Slides 移除演示文稿文件上的写保护。这样，用户可以随意修改，且在执行此类操作时不会出现任何警告。

可以通过调用 [RemoveWriteProtection](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.protection_manager#a9f9e6de5983965157dac0f270a0a9e50) 方法来移除写保护。以下示例代码演示如何从演示文稿中移除写保护：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->RemoveWriteProtection();
presentation->Save(u"write-protection-removed.pptx", SaveFormat::Pptx);
```

## **获取加密演示文稿的属性**

通常，用户在检索加密或受密码保护的演示文稿的文档属性时会遇到困难。但是，Aspose.Slides 提供了一种机制，允许您在对演示文稿进行密码保护的同时仍能访问其文档属性。

**注意：** 默认情况下，当 Aspose.Slides 加密演示文稿时，演示文稿的文档属性也会被密码保护。如果您需要在加密后仍然能够访问文档属性，Aspose.Slides 允许您这样做。

如果希望用户在加密后仍能访问演示文稿的属性，请向 [IProtectionManager](https://reference.aspose.com/slides/zh/cpp/aspose.slides/iprotectionmanager/) 的 `set_EncryptDocumentProperties` 方法传递 `false`。以下示例代码演示如何在加密演示文稿的同时仍向用户提供其文档属性的访问：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

presentation->get_ProtectionManager()->set_EncryptDocumentProperties(false);
presentation->get_ProtectionManager()->Encrypt(u"123123");
presentation->Save(u"encrypted-pres.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **仅从加密演示文稿加载文档属性**

若要在不加载幻灯片或其他内容的情况下检查加密演示文稿的元数据，请创建一个 [LoadOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides/loadoptions/) 对象，并将 `set_OnlyLoadDocumentProperties` 设置为 `true`。在此模式下，Aspose.Slides 会忽略密码，仅加载公开可访问的文档属性。

以下代码示例通过 [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/zh/cpp/aspose.slides/ipresentation/get_documentproperties/) 读取内置和自定义文档属性：

``` cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"encrypted-pres.pptx", loadOptions);
auto documentProperties = presentation->get_DocumentProperties();

// Read built-in document properties.
auto title = documentProperties->get_Title();
auto author = documentProperties->get_Author();
Console::WriteLine(String(u"Title: ") + title);
Console::WriteLine(String(u"Author: ") + author);

// Read custom document properties.
int customPropertyCount = documentProperties->get_CountOfCustomProperties();

for (int propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(propertyIndex);
    auto propertyValue = documentProperties->idx_get(propertyName);
    auto propertyValueText = ObjectExt::ToString(propertyValue);

    Console::WriteLine(propertyName + u": " + propertyValueText);
}

presentation->Dispose();
```

此工作流仅在演示文稿加密时文档属性保持未加密（公开）时有效。如果文档属性被加密，将 `LoadOptions::set_OnlyLoadDocumentProperties` 设置为 `true` 会导致异常，因为在此模式下密码会被忽略。若要访问加密的文档属性或加载包括幻灯片在内的完整演示文稿，请在 [LoadOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides/loadoptions/) 中使用 `LoadOptions::set_Password` 提供正确的密码。

## **检查演示文稿是否受密码保护**

在加载演示文稿之前，您可能希望检查并确认该演示文稿未被密码保护。这样可以避免在未提供密码的情况下加载受密码保护的演示文稿时出现错误和类似问题。

以下 C++ 代码展示如何在不加载演示文稿本身的情况下检查其是否受密码保护：

```c++
auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(u"example.pptx");
System::Console::WriteLine(System::String(u"The presentation is password protected: ") +
                           presentationInfo->get_IsPasswordProtected());
```

## **检查演示文稿是否已加密**

Aspose.Slides 允许您检查演示文稿是否已加密。为执行此操作，可使用 [get_IsEncrypted()](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.protection_manager#ad88b984e44b378f335317ded49b34e68) 方法，该方法在演示文稿已加密时返回 `true`，未加密时返回 `false`。

以下示例代码演示如何检查演示文稿是否已加密：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsEncrypted();
```

## **检查演示文稿是否受写保护**

Aspose.Slides 允许您检查演示文稿是否受写保护。为执行此操作，可使用 [get_IsWriteProtected()](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.protection_manager#a0b4a82c0f7b3a32ca5762c5fcc8844a2) 方法，该方法在演示文稿受写保护时返回 `true`，否则返回 `false`。

以下示例代码演示如何检查演示文稿是否受写保护：

``` cpp
auto presentation = System::MakeObject<Presentation>(u"pres.pptx");

bool isEncrypted = presentation->get_ProtectionManager()->get_IsWriteProtected();
```

## **验证演示文稿密码的使用情况**

您可能希望检查并确认特定密码已用于保护演示文稿文档。Aspose.Slides 提供了验证密码的功能。

以下示例代码演示如何验证密码：

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

// 检查 "pass" 是否匹配
bool isWriteProtected = pres->get_ProtectionManager()->CheckWriteProtection(u"my_password");
```

如果演示文稿使用指定密码加密，则返回 `true`；否则返回 `false`。

{{% alert color="primary" title="另见" %}} 
- [Digital Signature in PowerPoint](/slides/zh/cpp/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常见问题**

**Aspose.Slides 支持哪些加密方法？**

Aspose.Slides 支持现代加密方法，包括基于 AES 的算法，确保您的演示文稿数据安全性达到高级别。

**如果在尝试打开演示文稿时输入了错误的密码，会发生什么？**

如果使用错误的密码，将抛出异常，提示访问演示文稿被拒绝。这有助于防止未经授权的访问并保护演示文稿内容。

**在处理受密码保护的演示文稿时是否会有性能影响？**

加密和解密过程可能在打开和保存操作期间引入轻微的开销。大多数情况下，这种性能影响很小，并不会显著影响演示文稿任务的整体处理时间。