---
title: 使用密码在 .NET 中保护演示文稿
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
- .NET
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 轻松锁定和解锁受密码保护的 PowerPoint 和 OpenDocument 演示文稿。保护您的演示文稿。"
---

## **概述**

当您对演示文稿进行密码保护时，意味着您正在设置一个密码以对演示文稿实施某些限制。要移除这些限制，必须输入密码。受密码保护的演示文稿被视为锁定的演示文稿。

通常，您可以设置密码以对演示文稿强制这些限制：

- **修改**

如果您希望仅特定用户修改您的演示文稿，您可以设置修改限制。此限制会阻止他人在未提供密码的情况下修改、更改或复制演示文稿中的元素。

但是，即使没有密码，用户仍然能够访问并打开您的文档。在只读模式下，用户可以查看演示文稿中的内容——包括超链接、动画、效果及其他元素，但无法复制项目或保存演示文稿。

- **打开**

如果您希望仅特定用户打开您的演示文稿，您可以设置打开限制。此限制会阻止他人在未提供密码的情况下甚至查看演示文稿的内容。

从技术上讲，打开限制也会阻止用户修改您的演示文稿——如果无法打开演示文稿，就无法对其进行修改或更改。

**注意：** 当您对演示文稿进行密码保护以阻止打开时，演示文稿文件会被加密。

## **Aspose.Slides 中的密码保护**

**支持的格式**

Aspose.Slides 支持对以下格式的演示文稿进行密码保护、加密及类似操作：

- PPTX 和 PPT – Microsoft PowerPoint 演示文稿
- ODP – OpenDocument 演示文稿
- OTP – OpenDocument 演示文稿模板

**支持的操作**

Aspose.Slides 允许您通过以下方式使用密码保护来防止演示文稿被修改：

- 加密演示文稿
- 对演示文稿设置写保护

**其他操作**

Aspose.Slides 允许您通过以下方式执行涉及密码保护和加密的其他任务：

- 解密演示文稿；打开加密的演示文稿
- 移除加密；禁用密码保护
- 从演示文稿中移除写保护
- 获取加密演示文稿的属性
- 在加载之前检查演示文稿是否受密码保护
- 检查演示文稿是否已加密
- 检查演示文稿是否受密码保护

## **使用密码保护演示文稿**

您可以通过设置密码来加密演示文稿。随后，要修改已锁定的演示文稿，用户必须提供密码。

要加密（或密码保护）演示文稿，请使用 [ProtectionManager](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager) 的 `Encrypt` 方法设置密码。将密码传递给 `Encrypt` 方法，然后使用 `Save` 方法保存已加密的演示文稿。

此示例代码演示如何加密演示文稿：
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```


## **在演示文稿上设置写保护** 

您可以在演示文稿上添加 “Do not modify” 标记。这向用户表明您不希望他们对演示文稿进行更改。

**注意：** 写保护过程不会加密演示文稿。因此，用户——如果他们愿意——仍可以修改演示文稿，但若要保存更改，则必须另存为不同的名称。

要设置写保护，请使用 `SetWriteProtection` 方法。此示例代码演示如何在演示文稿上设置写保护：
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```


## **加载加密的演示文稿**

Aspose.Slides 允许您通过传递正确的密码来加载加密的演示文稿。此示例代码演示如何加载加密的演示文稿：
```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // 在已解密的演示文稿上工作。
}
```


## **从演示文稿中移除加密**

您可以移除演示文稿的加密或密码保护，允许用户在无需限制的情况下访问或修改它。

要移除加密或密码保护，请调用 [RemoveEncryption](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removeencryption) 方法。此示例代码演示如何从演示文稿中移除加密：
```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```


## **从演示文稿中移除写保护**

您可以使用 Aspose.Slides 移除演示文稿文件的写保护。这样，用户可以随意修改它——并且在执行此类操作时不会收到任何警告。

您可以通过使用 [RemoveWriteProtection](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removewriteprotection) 方法来移除写保护。此示例代码演示如何从演示文稿中移除写保护：
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```


## **获取加密演示文稿的属性**

通常，用户难以检索加密或受密码保护的演示文稿的文档属性。然而，Aspose.Slides 提供了一种机制，使您能够在对演示文稿进行密码保护的同时，仍保留用户访问其属性的能力。

**注意：** 默认情况下，当 Aspose.Slides 加密演示文稿时，演示文稿的文档属性也会受到密码保护。如果您需要在加密后仍能访问文档属性，Aspose.Slides 允许您实现此目的。

如果您希望用户在演示文稿加密后仍能访问其属性，可以将 [EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/encryptdocumentproperties) 属性设为 `true`。此示例代码演示如何在加密演示文稿的同时仍提供对文档属性的访问：
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.EncryptDocumentProperties = true;
    presentation.ProtectionManager.Encrypt("123123");
}
```


## **检查演示文稿是否受密码保护**

在加载演示文稿之前，您可能想检查它是否已被密码保护。这有助于避免在未提供正确密码的情况下加载受密码保护的演示文稿时出现错误等问题。

此 C# 代码示例演示如何在不实际加载演示文稿的情况下检查其是否受密码保护：
```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```


## **检查演示文稿是否已加密**

Aspose.Slides 允许您检查演示文稿是否已加密。为执行此操作，您可以使用 [IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/isencrypted) 属性，如果演示文稿已加密则返回 `true`，否则返回 `false`。

此示例代码演示如何检查演示文稿是否已加密：
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```


## **检查演示文稿是否受写保护**

Aspose.Slides 允许您检查演示文稿是否受写保护。为执行此操作，您可以使用 [IsWriteProtected](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/iswriteprotected) 属性，如果演示文稿受写保护则返回 `true`，否则返回 `false`。

此示例代码演示如何检查演示文稿是否受写保护：
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```


## **验证演示文稿密码的使用**

您可能想检查并确认已使用特定密码来保护演示文稿。Aspose.Slides 提供了验证密码的方式。

此示例代码演示如何验证密码：
```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // 检查密码是否匹配。
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```


如果演示文稿已使用指定密码加密，则返回 `true`；否则返回 `false`.

{{% alert color="primary" title="See also" %}} 
- [Digital Signature in PowerPoint](/slides/zh/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **在线密码保护演示文稿**

1. 访问我们的 [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock) 页面。 
2. 点击 **Drop or upload your files**。 
3. 在电脑上选择您想要进行密码保护的文件。 
4. 输入用于编辑保护的首选密码和用于查看保护的首选密码。 
5. 如果您希望用户将演示文稿视为最终版，请勾选 **Mark as final** 复选框。 
6. 点击 **PROTECT NOW.** 
7. 点击 **DOWNLOAD NOW.**

![密码保护 PowerPoint 演示文稿](slides-lock.png)

## **常见问题**

**Aspose.Slides 支持哪些加密方法？**

Aspose.Slides 支持现代加密方法，包括基于 AES 的算法，确保您的演示文稿数据安全性达到较高水平。

**尝试打开演示文稿时输入错误密码会怎样？**

如果使用错误密码，系统会抛出异常，提示演示文稿访问被拒绝。这有助于防止未经授权的访问并保护演示文稿内容。

**在处理受密码保护的演示文稿时是否会影响性能？**

加密和解密过程可能在打开和保存操作期间引入轻微的开销。在大多数情况下，这种性能影响很小，不会显著影响演示文稿任务的整体处理时间。