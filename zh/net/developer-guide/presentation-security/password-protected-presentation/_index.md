---
title: 密码保护的演示文稿
type: docs
weight: 20
url: /zh/net/password-protected-presentation/
keywords: "锁定 PowerPoint，解锁 PowerPoint，保护 PowerPoint，设置密码，添加密码，加密 PowerPoint，解密 PowerPoint，写保护，PowerPoint 安全性，PowerPoint 演示文稿，C#，Csharp，Aspose.Slides for .NET"
description: "C# 或 .NET 中的 PowerPoint 密码保护、加密和安全性"

---

## **关于密码保护**
### **演示文稿的密码保护是如何工作的？**
当您对演示文稿进行密码保护时，这意味着您设置了一个密码，强制对演示文稿施加某些限制。要取消这些限制，必须输入密码。受密码保护的演示文稿被视为锁定的演示文稿。

通常，您可以设置一个密码来施加这些限制：

- **修改**

  如果您只希望某些用户修改您的演示文稿，可以设置修改限制。此限制防止人们修改、改变或复制您演示文稿中的内容（除非他们提供密码）。

  但是，在这种情况下，即使没有密码，用户仍然可以访问您的文档并打开它。在只读模式下，用户可以查看演示文稿中的内容或事物——超链接、动画、效果等——但他们无法复制项目或保存演示文稿。

- **打开**

  如果您希望只有特定用户能打开您的演示文稿，可以设置打开限制。此限制防止人们甚至查看您演示文稿的内容（除非他们提供密码）。

  从技术上讲，打开限制也防止用户修改您的演示文稿：当人们无法打开演示文稿时，他们无法对其进行修改或更改。

  **注意**，当您为阻止打开而进行密码保护时，演示文稿文件将被加密。

## 如何在线保护演示文稿的密码

1. 转到我们的 [**Aspose.Slides Lock**](https://products.aspose.app/slides/lock) 页面。

   ![todo:image_alt_text](slides-lock.png)

2. 点击 **拖放或上传您的文件**。

3. 选择您希望在计算机上进行密码保护的文件。

4. 输入您首选的编辑保护密码；输入您首选的查看保护密码。

5. 如果您希望用户将您的演示文稿视为最终副本，请勾选 **标记为最终版本** 复选框。

6. 点击 **立即保护**。

7. 点击 **立即下载**。

### **Aspose.Slides 中的演示文稿密码保护**
**支持的格式**

Aspose.Slides 支持对以下格式的演示文稿进行密码保护、加密及类似操作：

- PPTX 和 PPT - Microsoft PowerPoint 演示文稿
- ODP - OpenDocument 演示文稿
- OTP - OpenDocument 演示文稿模板

**支持的操作**

Aspose.Slides 允许您在演示文稿上使用密码保护，以防止通过以下方式进行修改：

- 为演示文稿加密
- 为演示文稿设置写保护

**其他操作**

Aspose.Slides 允许您以以下方式执行其他涉及密码保护和加密的任务：

- 解密演示文稿；打开加密演示文稿
- 移除加密；禁用密码保护
- 从演示文稿中移除写保护
- 获取加密演示文稿的属性
- 在加载演示文稿之前检查演示文稿是否被密码保护
- 检查演示文稿是否被加密
- 检查演示文稿是否被密码保护。

## 加密演示文稿

您可以通过设置密码来加密演示文稿。然后，为了修改锁定的演示文稿，用户必须提供密码。

要加密或为演示文稿设置密码保护，您必须使用 encrypt 方法（来自 [ProtectionManager](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager)）为演示文稿设置密码。您将密码传递给 encrypt 方法，并使用 save 方法保存现在加密的演示文稿。

这段示例代码向您展示了如何加密演示文稿：

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.Encrypt("123123");
    presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
}
```

## 为演示文稿设置写保护

您可以在演示文稿中添加一个标记，说明“请勿修改”。这样，您可以告知用户不希望他们对演示文稿进行更改。

**注意**，写保护过程并不加密演示文稿。因此，用户——如果他们真的想——可以修改演示文稿，但要保存更改，他们必须创建一个不同名称的演示文稿。

要设置写保护，您必须使用 setWriteProtection 方法。这段示例代码向您展示了如何为演示文稿设置写保护：

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.SetWriteProtection("123123");
    presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
}
```

## 解密演示文稿；打开加密演示文稿

Aspose.Slides 允许您通过传递其密码来加载加密文件。要解密演示文稿，您必须调用 [RemoveEncryption](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removeencryption) 方法而不带参数。然后，您将必须输入正确的密码以加载演示文稿。

这段示例代码向您展示了如何解密演示文稿：

```c#
LoadOptions loadOptions = new LoadOptions {Password = "123123"};
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
  // 使用解密的演示文稿
}
```

## 移除加密；禁用密码保护

您可以移除演示文稿上的加密或密码保护。这样，用户可以在没有限制的情况下访问或修改演示文稿。

要移除加密或密码保护，您必须调用 [RemoveEncryption](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removeencryption) 方法。这段示例代码向您展示了如何从演示文稿中移除加密：

```c#
LoadOptions loadOptions = new LoadOptions {Password = "123123"};
using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
{
    presentation.ProtectionManager.RemoveEncryption();
    presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
}
```

## 从演示文稿中移除写保护

您可以使用 Aspose.Slides 移除演示文稿文件上使用的写保护。这样，用户可以随心所欲地进行修改——并且在执行此类操作时不会收到警告。

您可以通过使用 [RemoveWriteProtection](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/methods/removewriteprotection) 方法来从演示文稿中移除写保护。这段示例代码向您展示了如何从演示文稿中移除写保护：

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.RemoveWriteProtection();
    presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
}
```

## 获取加密演示文稿的属性

通常，用户在获取加密或密码保护演示文稿的文档属性时会遇到困难。然而，Aspose.Slides 提供了一种机制，允许您在保护演示文稿的同时让用户可以访问该演示文稿的属性。

**注意**，当 Aspose.Slides 加密演示文稿时，演示文稿的文档属性也默认被密码保护。但如果您希望使演示文稿的属性可访问（即使在演示文稿加密后），Aspose.Slides 允许您做到这一点。

如果您希望用户保留访问加密演示文稿的属性的能力，您可以将 [EncryptDocumentProperties](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/encryptdocumentproperties) 属性设置为 `true`。这段示例代码向您展示了如何在提供用户访问文档属性的方法的同时加密演示文稿：

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    presentation.ProtectionManager.EncryptDocumentProperties = true;
    presentation.ProtectionManager.Encrypt("123123");
}
```

## **在加载之前检查演示文稿是否被密码保护**

在加载演示文稿之前，您可能希望检查并确认演示文稿是否未受到密码保护。这样，您可以避免在没有输入密码的情况下加载受密码保护的演示文稿时出现错误和类似问题。

这段 C# 代码向您展示了如何检查演示文稿是否被密码保护（而不加载演示文稿本身）：

```c#
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("example.pptx");
Console.WriteLine("演示文稿受到密码保护: " + presentationInfo.IsPasswordProtected);
```

## 检查演示文稿是否被加密

Aspose.Slides 允许您检查演示文稿是否被加密。要执行此任务，您可以使用 [IsEncrypted](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/isencrypted) 属性，该属性返回 `true` 如果演示文稿被加密，或者返回 `false` 如果演示文稿没有被加密。

这段示例代码向您展示了如何检查演示文稿是否被加密：

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsEncrypted;
}
```

## 检查演示文稿是否被写保护

Aspose.Slides 允许您检查演示文稿是否被写保护。要执行此任务，您可以使用 [IsWriteProtected](https://reference.aspose.com/slides/net/aspose.slides/protectionmanager/properties/iswriteprotected) 属性，该属性返回 `true` 如果演示文稿被写保护，或者返回 `false` 如果演示文稿没有被写保护。

这段示例代码向您展示了如何检查演示文稿是否被写保护：

```c#
using (Presentation presentation = new Presentation("pres.pptx"))
{
    bool isEncrypted = presentation.ProtectionManager.IsWriteProtected;
}
```

## **验证或确认特定密码是否已用于保护演示文稿**

您可能希望检查并确认是否使用特定密码保护了演示文稿文档。Aspose.Slides 提供了验证密码的手段。

这段示例代码向您展示了如何验证密码：

```c#
using (IPresentation pres = new Presentation("pres.pptx"))
{
    // 检查 "pass" 是否匹配
    bool isWriteProtected = pres.ProtectionManager.CheckWriteProtection("my_password");
}
```

如果演示文稿已使用指定的密码加密，则返回 `true`。否则，返回 `false`。

{{% alert color="primary" title="另见" %}} 
- [PowerPoint 中的数字签名](/slides/zh/net/digital-signature-in-powerpoint/)
{{% /alert %}}