---
title: ".NET 中的演示文稿密码保护"
linktitle: "密码保护"
type: docs
weight: 20
url: /zh/net/password-protected-presentation/
keywords:
- "受密码保护的演示文稿"
- "打开密码"
- "加密 PowerPoint"
- "解密 PowerPoint"
- "验证演示文稿密码"
- "检查演示文稿密码"
- "打开加密的演示文稿"
- "移除加密"
- "PowerPoint"
- "PPT"
- "PPTX"
- "演示文稿"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "使用 Aspose.Slides for .NET 在 C# 中加密、检测、验证、打开和解密受密码保护的 PowerPoint PPT 和 PPTX 演示文稿。"
---
## **概述**

打开密码会加密演示文稿。必须提供正确的密码才能加载和查看演示文稿内容，因此此保护提供机密性。

打开密码不同于写保护密码。写保护限制修改，但不加密内容或阻止加载演示文稿。若要管理用于修改演示文稿的密码，请参阅[Write-Protect Presentations](/slides/zh/net/write-protected-presentation/)。

下面的工作流适用于 PPT 和 PPTX 演示文稿。当文件‑基和流‑基行为重要时，示例会使用两种格式。

## **使用打开密码加密演示文稿**

使用[IProtectionManager.Encrypt](https://reference.aspose.com/slides/zh/net/aspose.slides/iprotectionmanager/encrypt/)分配打开密码。然后使用[IPresentation.Save](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentation/save/)持久化加密后的演示文稿。

以下示例对 PPTX 演示文稿进行加密：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **保持文档属性公开**

默认情况下，Aspose.Slides 会在演示文稿加密时包含文档属性。[IProtectionManager.EncryptDocumentProperties](https://reference.aspose.com/slides/zh/net/aspose.slides/iprotectionmanager/encryptdocumentproperties/)属性可独立于幻灯片内容加密来控制此行为。当索引、分类、搜索或文档管理系统必须在没有打开密码的情况下读取元数据时，请在调用[IProtectionManager.Encrypt](https://reference.aspose.com/slides/zh/net/aspose.slides/iprotectionmanager/encrypt/)之前将其设置为 `false`。

以下示例在创建加密的 PPTX 演示文稿的同时保持其内置文档属性公开：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var properties = presentation.DocumentProperties;
properties.Author = "Contoso Knowledge Management";
properties.Title = "Quarterly Product Roadmap";
properties.Keywords = "roadmap, planning, internal";

presentation.Slides[0].Name = "Encrypted presentation content";
presentation.ProtectionManager.EncryptDocumentProperties = false;
presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("public-properties-encrypted.pptx", SaveFormat.Pptx);
```

`EncryptDocumentProperties` 设置为 `false` 并不会使幻灯片、母版、版式、形状、媒体或其他演示文稿内容公开。它仅影响文档属性。若需在不加载加密内容的情况下读取这些属性，请参阅[Manage Presentation Properties](/slides/zh/net/presentation-properties/)。

## **加载加密的演示文稿**

在加载文件时，将[LoadOptions.Password](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/password/)设为打开密码，并将该选项传递给[Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/)。当需要打开密码但提供的密码缺失或不正确时，加载将失败。

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// 使用已解密的演示文稿进行操作。
```

## **移除演示文稿的加密**

使用打开密码加载演示文稿，调用[IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/zh/net/aspose.slides/iprotectionmanager/removeencryption/)，并保存结果。随后即可在无需密码的情况下加载已保存的演示文稿。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **在加载前验证打开密码**

使用[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationfactory/getpresentationinfo/)获取[IPresentationInfo](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationinfo/)而无需创建完整的演示文稿实例。检查[IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationinfo/ispasswordprotected/)后再请求或验证密码。当存在保护时，使用[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationinfo/checkpassword/)验证提供的值。

### **文件路径工作流**

以下示例对 PPTX 文件验证打开密码，将验证后的值传递给[LoadOptions.Password](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/password/)，然后加载完整演示文稿：

```csharp
using System;
using Aspose.Slides;

var filePath = "protected-presentation.pptx";
var password = "open_password";
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(filePath);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(filePath, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **流工作流**

[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationfactory/getpresentationinfo/)的流重载提供相同的工作流。在从该流加载完整演示文稿之前，请重置可定位流的位置。

以下示例使用 PPT 文件：

```csharp
using System;
using System.IO;
using Aspose.Slides;

var password = "open_password";
using var presentationStream = File.OpenRead("protected-presentation.ppt");
var presentationInfo = PresentationFactory.Instance.GetPresentationInfo(presentationStream);

if (!presentationInfo.IsPasswordProtected)
{
    Console.WriteLine("The presentation does not have an opening password.");
}
else if (!presentationInfo.CheckPassword(password))
{
    Console.WriteLine("The opening password is incorrect.");
}
else
{
    presentationStream.Position = 0;

    var loadOptions = new LoadOptions { Password = password };
    using var presentation = new Presentation(presentationStream, loadOptions);

    Console.WriteLine("The presentation was validated and loaded successfully.");
}
```

### **CheckPassword 返回值**

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationinfo/checkpassword/)仅在演示文稿具有打开密码且提供的密码正确时返回 `true`。在以下情况下返回 `false`：

- 密码不正确。
- 演示文稿没有打开密码。
- 提供的密码为 `null` 或为空。

PPT 和 PPTX 演示文稿的行为相同。

## **检查已加载的演示文稿是否已加密**

使用正确的密码加载演示文稿后，检查[IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/zh/net/aspose.slides/iprotectionmanager/isencrypted/)以确认源演示文稿已加密。若要在加载前检测打开密码保护，请使用上文示例中的 `IPresentationInfo.IsPasswordProtected`。

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **安全建议**

{{% alert color="warning" title="安全" %}}
不要记录打开密码或在诊断信息中包含密码。避免不必要的重复验证尝试，仅在需要时在内存中保留密码，并在立即加载演示文稿时复用成功的验证结果。

即使演示文稿内容已加密，公开的文档属性仍可能泄露作者姓名、标题、主题、关键字、公司信息、备注和自定义值。请将敏感的元数据与演示文稿一起加密。仅在系统必须在没有打开密码的情况下对文件进行索引、分类、搜索或管理时，才应明确决定将属性设为公开。
{{% /alert %}}

## **在线对演示文稿进行密码保护**

1. 打开[Aspose.Slides Lock](https://products.aspose.app/slides/zh/lock)应用程序。
2. 选择或上传演示文稿。
3. 输入用于查看保护的密码。
4. 可选地输入用于编辑保护的单独密码。
5. 应用保护并下载生成的文件。

{{% alert color="info" title="另见" %}}
- [Write-Protect Presentations](/slides/zh/net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/zh/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常见问题**

**What is the difference between an opening password and a write-protection password?**

打开密码会加密演示文稿并在加载其内容时需要提供密码。写保护密码仅限制修改，不会加密内容。

**Can I validate an opening password without loading all slides?**

可以。获取演示文稿信息，检查是否存在打开密码保护，然后在创建完整演示文稿实例之前验证密码。

**Can an application read metadata without the opening password?**

可以，但仅当演示文稿在加密时将 `EncryptDocumentProperties` 设置为 `false`。此时应用程序必须使用[Manage Presentation Properties](/slides/zh/net/presentation-properties/)中描述的仅加载文档属性的模式。

**Do the password-checking workflows support both PPT and PPTX?**

支持。文件路径和基于流的密码检测与验证在 PPT 和 PPTX 演示文稿中行为一致。