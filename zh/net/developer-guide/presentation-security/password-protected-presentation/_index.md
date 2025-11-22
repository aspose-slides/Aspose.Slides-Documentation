---
title: 使用 C# 为 PowerPoint 演示文稿设置密码保护
linktitle: 受密码保护的演示文稿
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
- PowerPoint 演示文稿
- C#
- Aspose.Slides
description: "了解如何使用 Aspose.Slides for .NET 轻松锁定和解锁受密码保护的 PowerPoint 与 OpenDocument 演示文稿。提升工作效率并通过我们的分步指南保护您的演示文稿。"
---

## **概述**

当您对演示文稿设置密码保护时，意味着您正在设置一个密码，以对演示文稿执行特定限制。要移除这些限制，必须输入密码。受密码保护的演示文稿被视为锁定的演示文稿。

通常，您可以设置密码来对演示文稿强制这些限制：

- **修改**

如果您只希望特定用户修改您的演示文稿，可以设置修改限制。此限制会阻止在未提供密码的情况下对演示文稿进行修改、变更或复制元素。

但是，即使没有密码，用户仍然能够访问并打开文档。在此只读模式下，用户可以查看演示文稿中的内容，包括超链接、动画、效果和其他元素，但他们无法复制项目或保存演示文稿。

- **打开**

如果您只希望特定用户打开您的演示文稿，可以设置打开限制。此限制会阻止在未提供密码的情况下查看演示文稿的内容。

从技术上讲，打开限制同样会阻止用户修改演示文稿——如果无法打开演示文稿，就无法对其进行修改或更改。

**注意：** 当您对演示文稿进行密码保护以阻止打开时，演示文稿文件会被加密。

## **Aspose.Slides 中的密码保护**

**支持的格式**

Aspose.Slides 支持对以下格式的演示文稿进行密码保护、加密及类似操作：

- PPTX 和 PPT – Microsoft PowerPoint 演示文稿
- ODP – OpenDocument 演示文稿
- OTP – OpenDocument 演示文稿模板

**支持的操作**

Aspose.Slides 允许您通过以下方式对演示文稿使用密码保护以防止修改：

- 加密演示文稿
- 对演示文稿设置写保护

**其他操作**

Aspose.Slides 还可以让您以以下方式执行涉及密码保护和加密的其他任务：

- 解密演示文稿；打开加密的演示文稿
- 移除加密；禁用密码保护
- 从演示文稿中移除写保护
- 检索加密演示文稿的属性
- 在加载演示文稿之前检查其是否受密码保护
- 检查演示文稿是否已加密
- 检查演示文稿是否受密码保护

## **使用密码保护演示文稿**

您可以通过设置密码来加密演示文稿。随后，要修改已锁定的演示文稿，用户必须提供密码。

要加密（或密码保护）演示文稿，请使用 [ProtectionManager](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager) 的 `Encrypt` 方法设置密码。将密码传递给 `Encrypt` 方法，然后使用 `Save` 方法保存已加密的演示文稿。

以下示例代码演示如何加密演示文稿：
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```


## **在演示文稿上设置写保护** 

您可以在演示文稿上添加“请勿修改”的标记。这会告知用户您不希望他们对演示文稿进行更改。

**注意：** 写保护过程并不加密演示文稿。因此，用户——如果他们愿意——仍然可以修改演示文稿，但要保存更改，则必须另存为不同的文件名。

要设置写保护，请使用 `SetWriteProtection` 方法。以下示例代码演示如何在演示文稿上设置写保护：
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```


## **加载加密的演示文稿**

Aspose.Slides 允许您通过传递正确的密码来加载加密的演示文稿。以下示例代码演示如何加载加密的演示文稿：
```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    // 在解密后的演示文稿上工作。
}
```


## **从演示文稿中移除加密**

您可以移除演示文稿的加密或密码保护，从而允许用户在没有限制的情况下访问或修改它。

要移除加密或密码保护，请调用 [RemoveEncryption](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removeencryption) 方法。以下示例代码演示如何从演示文稿中移除加密：
```c#
LoadOptions loadOptions = new LoadOptions { Password = "123123" };
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```


## **从演示文稿中移除写保护**

您可以使用 Aspose.Slides 移除演示文稿文件的写保护。这样，用户可以随意修改，并且在执行此类操作时不会收到任何警告。

您可以使用 [RemoveWriteProtection](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removewriteprotection) 方法来移除写保护。以下示例代码演示如何从演示文稿中移除写保护：
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```


## **获取加密演示文稿的属性**

通常，用户难以检索加密或受密码保护的演示文稿的文档属性。不过，Aspose.Slides 提供了一种机制，允许您在对演示文稿进行密码保护的同时，仍保留用户访问其属性的能力。

**注意：** 默认情况下，当 Aspose.Slides 加密演示文稿时，演示文稿的文档属性也会受到密码保护。如果您需要在加密后仍能访问文档属性，Aspose.Slides 可以实现此需求。

如果您希望用户在演示文稿加密后仍能访问其属性，可以将 [EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/encryptdocumentproperties) 属性设置为 `true`。以下示例代码演示如何在加密演示文稿的同时仍为用户提供文档属性访问：
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.EncryptDocumentProperties = true;
    presentation.ProtectionManager.Encrypt("123123");
}
```


## **检查演示文稿是否受密码保护**

在加载演示文稿之前，您可能希望检查它是否已被密码保护。这可以帮助您避免在未提供正确密码的情况下加载受密码保护的演示文稿时出现错误等问题。

以下 C# 代码演示如何在不实际加载演示文稿的情况下检查其是否受密码保护：
```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("The presentation is password protected: " + presentationInfo.IsPasswordProtected);
```


## **检查演示文稿是否已加密**

Aspose.Slides 允许您检查演示文稿是否已加密。要执行此操作，您可以使用 [IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/isencrypted) 属性，如果演示文稿已加密则返回 `true`，否则返回 `false`。

以下示例代码演示如何检查演示文稿是否已加密：
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```


## **检查演示文稿是否受写保护**

Aspose.Slides 允许您检查演示文稿是否受写保护。要执行此操作，您可以使用 [IsWriteProtected](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/iswriteprotected) 属性，如果演示文稿受写保护则返回 `true`，否则返回 `false`。

以下示例代码演示如何检查演示文稿是否受写保护：
```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```


## **验证演示文稿密码使用情况**

您可能想检查并确认特定密码已用于保护演示文稿。Aspose.Slides 提供了验证密码的功能。

以下示例代码演示如何验证密码：
```c#
using (IPresentation presentation = new Presentation("pres.pptx"))
{
    // 检查密码是否匹配。
    bool isWriteProtected = presentation.ProtectionManager.CheckWriteProtection("my_password");
}
```


如果演示文稿已使用指定密码加密，则返回 `true`；否则返回 `false`.

{{% alert color="primary" title="See also" %}} 
- [PowerPoint 中的数字签名](/slides/zh/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **在线密码保护演示文稿**

1. 访问我们的 [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock) 页面。 
2. 点击 **Drop or upload your files**。 
3. 在电脑上选择要进行密码保护的文件。 
4. 输入用于编辑保护的首选密码和用于查看保护的首选密码。 
5. 如果您希望用户将演示文稿视为最终稿件，请勾选 **Mark as final** 复选框。 
6. 点击 **PROTECT NOW.** 
7. 点击 **DOWNLOAD NOW.**

![密码保护 PowerPoint 演示文稿](slides-lock.png)

## **常见问题**

**Aspose.Slides 支持哪些加密方法？**

Aspose.Slides 支持现代加密方法，包括基于 AES 的算法，确保演示文稿具备高水平的数据安全性。

**如果在尝试打开演示文稿时输入了错误的密码会怎样？**

当使用错误密码时会抛出异常，提示您访问演示文稿被拒绝。这有助于防止未经授权的访问并保护演示文稿内容。

**在处理受密码保护的演示文稿时是否会产生性能影响？**

加密和解密过程可能在打开和保存操作期间引入少量开销。在大多数情况下，这种性能影响非常小，不会显著影响演示文稿任务的整体处理时间。