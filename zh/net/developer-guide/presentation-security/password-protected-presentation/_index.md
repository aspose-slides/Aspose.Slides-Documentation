---
title: .NET 中使用密码保护演示文稿
linktitle: 密码保护
type: docs
weight: 20
url: /zh/net/password-protected-presentation/
keywords:
- 锁定 PowerPoint
- 锁定演示文稿
- 解锁 PowerPoint
- 解锁演示文稿
- 保护 PowerPoint
- 保护演示文稿
- 设置密码
- 添加密码
- 加密 PowerPoint
- 加密演示文稿
- 解密 PowerPoint
- 解密演示文稿
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
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 轻松锁定和解锁受密码保护的 PowerPoint 与 OpenDocument 演示文稿，确保演示文稿安全。"
---
## **介绍**

当您为演示文稿设置密码保护时，意味着您正在设置一个密码，以对演示文稿强加某些限制。要解除这些限制，必须输入密码。受密码保护的演示文稿被视为已锁定的演示文稿。

通常，您可以设置密码以在演示文稿上强制这些限制：

- **修改**

  如果您只希望特定用户修改您的演示文稿，可以设置修改限制。此限制阻止其他人在未提供密码的情况下修改、变更或复制演示文稿中的元素。

  然而，即使没有密码，用户仍然可以访问并打开您的文档。在只读模式下，用户可以查看内容——包括超链接、动画、效果及其他元素——但不能复制项目或保存演示文稿。

- **打开**

  如果您只希望特定用户打开您的演示文稿，可以设置打开限制。此限制阻止他人在未提供密码的情况下甚至查看演示文稿的内容。

  从技术上讲，打开限制也会阻止用户修改演示文稿——如果无法打开演示文稿，就无法对其进行修改或更改。

**注意：** 当您为防止打开而对演示文稿进行密码保护时，演示文稿文件会被加密。

## **Aspose.Slides 中的密码保护**

**支持的格式**

Aspose.Slides 支持对以下格式的演示文稿进行密码保护、加密和类似操作：

- PPTX 和 PPT – Microsoft PowerPoint 演示文稿
- ODP – OpenDocument 演示文稿
- OTP – OpenDocument 演示文稿模板

**支持的操作**

Aspose.Slides 允许您通过以下方式对演示文稿使用密码保护以防止修改：

- 加密演示文稿
- 对演示文稿设置写保护

**其他操作**

Aspose.Slides 还允许您以以下方式执行涉及密码保护和加密的附加任务：

- 解密演示文稿；打开加密的演示文稿
- 移除加密；禁用密码保护
- 从演示文稿中移除写保护
- 检索加密演示文稿的属性
- 在加载演示文稿之前检查其是否受密码保护
- 检查演示文稿是否已加密
- 检查演示文稿是否受密码保护

## **使用密码保护演示文稿**

您可以通过设置密码来加密演示文稿。随后，修改已锁定的演示文稿时，用户必须提供密码。

要加密（或设置密码保护）演示文稿，请使用来自[ProtectionManager](https://reference.aspose.com/slides/zh/net/aspose.slides/protectionmanager)的`Encrypt`方法设置密码。将密码传递给`Encrypt`方法，然后使用`Save`方法保存已加密的演示文稿。

以下示例代码演示如何加密演示文稿：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **对演示文稿设置写保护**

您可以在演示文稿中添加“请勿修改”的标记，以告知用户您不希望他们对演示文稿进行更改。

**注意：** 写保护过程并不会加密演示文稿。因此，用户如果愿意，仍可以修改演示文稿，但要保存更改，必须另存为不同的文件名。

要设置写保护，请使用`SetWriteProtection`方法。以下示例代码演示如何对演示文稿设置写保护：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **加载加密的演示文稿**

Aspose.Slides 允许您通过传入正确的密码来加载加密的演示文稿。以下示例代码演示如何加载加密的演示文稿：

```c#
using Aspose.Slides;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // 使用已解密的演示文稿进行操作。
}
```

## **从演示文稿中移除加密**

您可以从演示文稿中移除加密或密码保护，从而让用户可以在没有限制的情况下访问或修改它。

要移除加密或密码保护，请调用[RemoveEncryption](https://reference.aspose.com/slides/zh/net/aspose.slides/protectionmanager/methods/removeencryption)方法。以下示例代码演示如何从演示文稿中移除加密：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **从演示文稿中移除写保护**

您可以使用 Aspose.Slides 移除演示文稿文件的写保护。这样，用户可以随意修改演示文稿，并且在执行此类操作时不会收到任何警告。

您可以通过使用[RemoveWriteProtection](https://reference.aspose.com/slides/zh/net/aspose.slides/protectionmanager/methods/removewriteprotection)方法来移除写保护。以下示例代码演示如何从演示文稿中移除写保护：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **获取加密演示文稿的属性**

通常，用户在检索加密或受密码保护的演示文稿的文档属性时会遇到困难。然而，Aspose.Slides 提供了一种机制，使您在对演示文稿进行密码保护的同时，仍然允许用户访问其属性。

**注意：** 默认情况下，当 Aspose.Slides 加密演示文稿时，演示文稿的文档属性也会受到密码保护。如果您需要在加密后仍然能够访问文档属性，Aspose.Slides 允许您实现此目的。

如果您希望用户在加密后仍能访问演示文稿的属性，请将[IProtectionManager](https://reference.aspose.com/slides/zh/net/aspose.slides/iprotectionmanager/)的`EncryptDocumentProperties`属性设为`false`。以下示例代码演示如何在加密演示文稿的同时仍向用户提供文档属性访问：

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **仅从加密演示文稿加载文档属性**

若要在不加载幻灯片或其他内容的情况下检查加密演示文稿的元数据，请创建一个[LoadOptions](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/)对象并将[OnlyLoadDocumentProperties](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/onlyloaddocumentproperties/)设为`true`。在此模式下，Aspose.Slides 会忽略密码，仅加载公开可访问的文档属性。

以下代码示例通过[IPresentation.DocumentProperties](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentation/documentproperties/)读取内建和自定义文档属性：

```c#
using Aspose.Slides;

var loadOptions = new LoadOptions
{
    OnlyLoadDocumentProperties = true
};

using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);
var documentProperties = presentation.DocumentProperties;

// 读取内置文档属性。
Console.WriteLine("Title: " + documentProperties.Title);
Console.WriteLine("Author: " + documentProperties.Author);

// 读取自定义文档属性。
var customPropertyCount = documentProperties.CountOfCustomProperties;

for (var propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    var propertyName = documentProperties.GetCustomPropertyName(propertyIndex);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine(propertyName + ": " + propertyValue);
}
```

此工作流仅在演示文稿加密时文档属性未被加密（保持公开）时有效。如果文档属性已加密，将`OnlyLoadDocumentProperties`设为`true`会导致异常，因为密码在此模式下被忽略。若要访问加密的文档属性或加载包含幻灯片及其他内容的完整演示文稿，请在[LoadOptions](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/)中提供正确的`Password`值。

## **检查演示文稿是否受密码保护**

在加载演示文稿之前，您可能想检查它是否已被密码保护。这可以帮助您避免在未提供正确密码时加载受密码保护的演示文稿时产生的错误和类似问题。

以下 C# 代码展示了如何在不实际加载演示文稿的情况下检查其是否受密码保护：

```c#
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **检查演示文稿是否已加密**

Aspose.Slides 允许您检查演示文稿是否已加密。为执行此操作，您可以使用[IsEncrypted](https://reference.aspose.com/slides/zh/net/aspose.slides/protectionmanager/properties/isencrypted)属性，如果演示文稿已加密则返回 `true`，否则返回 `false`。

以下示例代码演示如何检查演示文稿是否已加密：

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **检查演示文稿是否受写保护**

Aspose.Slides 允许您检查演示文稿是否受写保护。为执行此操作，您可以使用[IsWriteProtected](https://reference.aspose.com/slides/zh/net/aspose.slides/protectionmanager/properties/iswriteprotected)属性，如果演示文稿受写保护则返回 `true`，否则返回 `false`。

以下示例代码演示如何检查演示文稿是否受写保护：

```c#
using Aspose.Slides;

using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **验证演示文稿密码的使用情况**

您可能希望检查并确认特定密码已用于保护演示文稿文档。Aspose.Slides 提供了验证密码的手段。

以下示例代码演示如何验证密码：

```c#
using Aspose.Slides;

using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // 检查密码是否匹配。
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

如果演示文稿已使用指定密码加密，则返回 `true`；否则返回 `false`。

{{% alert color="info" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/zh/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **在线对演示文稿进行密码保护**

1. 访问我们的[**Aspose.Slides Lock**](https://products.aspose.app/slides/zh/lock)页面。 
2. 点击**Drop or upload your files**。 
3. 在计算机上选择要进行密码保护的文件。 
4. 输入用于编辑保护的首选密码以及用于查看保护的首选密码。 
5. 如果您希望用户将演示文稿视为最终稿，请勾选**Mark as final**复选框。 
6. 点击**PROTECT NOW.** 
7. 点击**DOWNLOAD NOW.**

![Password protect PowerPoint presentations](slides-lock.png)

## **常见问题**

**Aspose.Slides 支持哪些加密方法？**

Aspose.Slides 支持包括基于 AES 的现代加密算法，确保演示文稿数据的高安全性。

**在尝试打开演示文稿时输入错误密码会怎样？**

如果使用错误密码，系统会抛出异常，提示访问演示文稿被拒绝。这有助于防止未经授权的访问并保护演示文稿内容。

**处理受密码保护的演示文稿会有性能影响吗？**

加密和解密过程可能在打开和保存操作期间引入轻微开销。大多数情况下，这种性能影响很小，不会显著影响演示文稿任务的整体处理时间。