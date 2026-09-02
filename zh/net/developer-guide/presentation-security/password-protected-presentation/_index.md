---
title: 使用 .NET 对演示文稿进行密码保护
linktitle: 密码保护
type: docs
weight: 20
url: /zh/net/password-protected-presentation/
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
- 写保护
- PowerPoint 安全
- 演示文稿 安全
- 移除 密码
- 移除 保护
- 移除 加密
- 禁用 密码
- 禁用 保护
- 移除 写保护
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 轻松锁定和解锁受密码保护的 PowerPoint 和 OpenDocument 演示文稿。保护您的演示文稿。"
---
## **介绍**

当您对演示文稿设置密码保护时，意味着您设置了一个密码来强制对演示文稿施加特定限制。要解除这些限制，必须输入密码。受密码保护的演示文稿被视为已锁定的演示文稿。

通常，您可以设置密码来对演示文稿强制这些限制：

- **修改**

如果您只希望特定用户修改您的演示文稿，可以设置修改限制。此限制会阻止他人在未提供密码的情况下修改、更改或复制演示文稿中的元素。  

然而，即使没有密码，用户仍然可以访问并打开您的文档。在此只读模式下，用户可以查看演示文稿中的内容——包括超链接、动画、效果及其他元素，但不能复制项目或保存演示文稿。

- **打开**

如果您只希望特定用户打开您的演示文稿，可以设置打开限制。此限制会阻止他人在未提供密码的情况下甚至查看演示文稿的内容。  

从技术上讲，打开限制同样会阻止用户修改演示文稿——如果无法打开演示文稿，就无法对其进行修改或更改。

**注意：** 当您通过密码保护演示文稿以阻止其打开时，演示文稿文件会被加密。

## **Aspose.Slides 中的密码保护**

**支持的格式**

Aspose.Slides 支持密码保护、加密以及类似操作，支持以下格式的演示文稿：

- PPTX 和 PPT – Microsoft PowerPoint 演示文稿
- ODP – OpenDocument 演示文稿
- OTP – OpenDocument 演示文稿模板

**支持的操作**

Aspose.Slides 允许您通过密码保护演示文稿，以以下方式防止修改：

- 加密演示文稿
- 对演示文稿设置写保护

**其他操作**

Aspose.Slides 允许您以以下方式执行涉及密码保护和加密的其他任务：

- 解密演示文稿；打开已加密的演示文稿
- 移除加密；禁用密码保护
- 移除演示文稿的写保护
- 检索已加密演示文稿的属性
- 在加载之前检查演示文稿是否受密码保护
- 检查演示文稿是否已加密
- 检查演示文稿是否受密码保护

## **使用密码保护演示文稿**

您可以通过设置密码来加密演示文稿。之后，要修改已锁定的演示文稿，用户必须提供密码。

要加密（或设置密码保护）演示文稿，请使用来自[ProtectionManager](https://reference.aspose.com/slides/zh/net/aspose.slides/protectionmanager)的 `Encrypt` 方法来设置密码。将密码传递给 `Encrypt` 方法，然后使用 `Save` 方法保存已加密的演示文稿。

以下示例代码展示了如何加密演示文稿：

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## **对演示文稿设置写保护**

您可以在演示文稿上添加 “Do not modify” 标记，以告知用户您不希望他们对演示文稿进行更改。

**注意：** 写保护过程并不会加密演示文稿。因此，用户——如果他们愿意——仍然可以修改演示文稿，但要保存更改，则必须另存为不同的文件名。

要设置写保护，请使用 `SetWriteProtection` 方法。以下示例代码展示了如何对演示文稿设置写保护：

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## **加载已加密的演示文稿**

Aspose.Slides 允许您通过传入正确的密码来加载已加密的演示文稿。以下示例代码展示了如何加载已加密的演示文稿：

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // 对已解密的演示文稿进行操作。
}
```

## **从演示文稿中移除加密**

您可以从演示文稿中移除加密或密码保护，从而允许用户在没有限制的情况下访问或修改它。

要移除加密或密码保护，请调用 [RemoveEncryption](https://reference.aspose.com/slides/zh/net/aspose.slides/protectionmanager/methods/removeencryption) 方法。以下示例代码展示了如何从演示文稿中移除加密：

```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## **从演示文稿中移除写保护**

您可以使用 Aspose.Slides 移除演示文稿文件的写保护。这样，用户可以随意修改它——在执行此类操作时也不会收到任何警告。

您可以通过使用 [RemoveWriteProtection](https://reference.aspose.com/slides/zh/net/aspose.slides/protectionmanager/methods/removewriteprotection) 方法来移除写保护。以下示例代码展示了如何从演示文稿中移除写保护：

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## **获取已加密演示文稿的属性**

通常，用户在检索已加密或受密码保护的演示文稿的文档属性时会遇到困难。然而，Aspose.Slides 提供了一种机制，使您能够在对演示文稿进行密码保护的同时，仍然允许用户访问其属性。

**注意：** 默认情况下，当 Aspose.Slides 加密演示文稿时，演示文稿的文档属性也会受到密码保护。如果您需要在加密后仍能访问文档属性，Aspose.Slides 允许您实现此功能。

如果您希望用户仍然能够访问已加密演示文稿的属性，请将 [IProtectionManager](https://reference.aspose.com/slides/zh/net/aspose.slides/iprotectionmanager/) 的 `EncryptDocumentProperties` 属性设置为 `false`。以下示例代码展示了如何在加密演示文稿的同时仍然向用户提供访问其文档属性的权限：

```c#
using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("123123");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **仅加载已加密演示文稿的文档属性**

要在不加载幻灯片或其他内容的情况下检查已加密演示文稿的元数据，请创建一个 [LoadOptions](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/) 对象并将 [OnlyLoadDocumentProperties](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/onlyloaddocumentproperties/) 设置为 `true`。在此模式下，Aspose.Slides 会忽略密码，仅加载公开可访问的文档属性。

以下代码示例通过 [IPresentation.DocumentProperties](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentation/documentproperties/) 读取内置和自定义文档属性：

```c#
var loadOptions = new LoadOptions
{
    OnlyLoadDocumentProperties = true
};

using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);
var documentProperties = presentation.DocumentProperties;

// Read built-in document properties.
Console.WriteLine("Title: " + documentProperties.Title);
Console.WriteLine("Author: " + documentProperties.Author);

// Read custom document properties.
var customPropertyCount = documentProperties.CountOfCustomProperties;

for (var propertyIndex = 0; propertyIndex < customPropertyCount; propertyIndex++)
{
    var propertyName = documentProperties.GetCustomPropertyName(propertyIndex);
    var propertyValue = documentProperties[propertyName];

    Console.WriteLine(propertyName + ": " + propertyValue);
}
```

仅当演示文稿加密时文档属性保持未加密（公开）时，此工作流才有效。如果文档属性已加密，将 `OnlyLoadDocumentProperties` 设置为 `true` 会导致异常，因为此模式下密码被忽略。要访问加密的文档属性或加载完整的演示文稿（包括幻灯片和其他内容），请在 [LoadOptions](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/) 中提供正确的 `Password` 值。

## **检查演示文稿是否受密码保护**

在加载演示文稿之前，您可能想先检查它是否已设置密码保护。这可以帮助您避免在未提供正确密码的情况下加载受密码保护的演示文稿时出现错误等问题。

以下 C# 代码展示了如何检查演示文稿是否受密码保护，而无需实际加载它：

```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```

## **检查演示文稿是否已加密**

Aspose.Slides 允许您检查演示文稿是否已加密。要执行此操作，您可以使用 [IsEncrypted](https://reference.aspose.com/slides/zh/net/aspose.slides/protectionmanager/properties/isencrypted) 属性，该属性在演示文稿已加密时返回 `true`，未加密时返回 `false`。

以下示例代码展示了如何检查演示文稿是否已加密：

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## **检查演示文稿是否受写保护**

Aspose.Slides 允许您检查演示文稿是否受写保护。要执行此操作，您可以使用 [IsWriteProtected](https://reference.aspose.com/slides/zh/net/aspose.slides/protectionmanager/properties/iswriteprotected) 属性，该属性在演示文稿受写保护时返回 `true`，未受保护时返回 `false`。

以下示例代码展示了如何检查演示文稿是否受写保护：

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **验证演示文稿密码使用情况**

您可能想检查并确认已使用特定密码来保护演示文稿文档。Aspose.Slides 提供了验证密码的手段。

以下示例代码展示了如何验证密码：

```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // 检查密码是否匹配。
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```

如果演示文稿已使用指定密码加密，则返回 `true`；否则返回 `false`。

{{% alert color="primary" title="See also" %}} 
- [PowerPoint 中的数字签名](/slides/zh/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **在线密码保护演示文稿**

1. 访问我们的[**Aspose.Slides Lock**](https://products.aspose.app/slides/zh/lock)页面。 
2. 点击 **拖放或上传文件**。 
3. 在电脑上选择您想要进行密码保护的文件。 
4. 输入您用于编辑保护的首选密码以及用于查看保护的首选密码。 
5. 如果您希望用户将演示文稿视为最终稿，请勾选 **Mark as final** 复选框。 
6. 点击 **PROTECT NOW.** 
7. 点击 **DOWNLOAD NOW.** 

![密码保护 PowerPoint 演示文稿](slides-lock.png)

## **常见问题**

**Aspose.Slides 支持哪些加密方法？**

Aspose.Slides 支持现代加密方法，包括基于 AES 的算法，确保您的演示文稿拥有高水平的数据安全性。

**尝试打开演示文稿时如果输入了错误的密码会怎样？**

如果使用了错误的密码，会抛出异常，提示您访问演示文稿被拒绝。这有助于防止未授权访问并保护演示文稿内容。

**在处理受密码保护的演示文稿时会有性能影响吗？**

加密和解密过程可能在打开和保存操作时带来轻微的开销。大多数情况下，这种性能影响极小，不会显著影响演示文稿任务的整体处理时间。