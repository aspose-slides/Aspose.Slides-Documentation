---
title: 在 .NET 中对演示文稿进行密码保护
linktitle: 密码保护
type: docs
weight: 20
url: /zh/net/password-protected-presentation/
keywords:
- 受密码保护的演示文稿
- 打开密码
- 加密 PowerPoint
- 解密 PowerPoint
- 验证演示文稿密码
- 检查演示文稿密码
- 打开加密的演示文稿
- 移除加密
- PowerPoint
- PPT
- PPTX
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 C# 中加密、检测、验证、打开和解密受密码保护的 PowerPoint PPT 和 PPTX 演示文稿。"
---
## **概述**

打开密码用于加密演示文稿。必须提供正确的密码才能加载并查看演示文稿内容，因此此保护提供了机密性。

打开密码不同于写保护密码。写保护限制修改，但不加密内容，也不阻止演示文稿被加载。要管理用于修改演示文稿的密码，请参阅[Write-Protect Presentations](/slides/zh/net/write-protected-presentation/)。

下面的工作流适用于 PPT 和 PPTX 演示文稿。示例在两种格式下都展示了文件和流的行为差异。

## **使用打开密码加密演示文稿**

使用[IProtectionManager.Encrypt](https://reference.aspose.com/slides/zh/net/aspose.slides/iprotectionmanager/encrypt/)分配打开密码。随后使用[IPresentation.Save](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentation/save/)保存加密后的演示文稿。

下面的示例对 PPTX 演示文稿进行加密：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.Encrypt("open_password");
presentation.Save("encrypted-pres.pptx", SaveFormat.Pptx);
```

## **加载加密的演示文稿**

将[LoadOptions.Password](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/password/)设置为打开密码，并在加载文件时将该选项传递给[Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/)。如果需要打开密码但未提供密码或密码错误，加载将失败。

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

// 在解密的演示文稿上工作。
```

## **移除演示文稿的加密**

使用打开密码加载演示文稿，调用[IProtectionManager.RemoveEncryption](https://reference.aspose.com/slides/zh/net/aspose.slides/iprotectionmanager/removeencryption/)，然后保存结果。保存后的演示文稿即可在不输入密码的情况下加载。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

presentation.ProtectionManager.RemoveEncryption();
presentation.Save("encryption-removed.pptx", SaveFormat.Pptx);
```

## **在加载之前验证打开密码**

使用[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationfactory/getpresentationinfo/)获取[IPresentationInfo](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationinfo/)，无需创建完整的演示文稿实例。在请求或验证密码之前检查[IPresentationInfo.IsPasswordProtected](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationinfo/ispasswordprotected/)。如果存在保护，请使用[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationinfo/checkpassword/)验证提供的密码。

### **文件路径工作流**

下面的示例验证 PPTX 文件的打开密码，将验证后的值传递给[LoadOptions.Password](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/password/)，随后加载完整的演示文稿：

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

[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationfactory/getpresentationinfo/)的流重载提供相同的工作流。在从该流加载完整演示文稿之前，重置可查找流的位置。

下面的示例使用 PPT 文件：

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

[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationinfo/checkpassword/)仅在演示文稿具有打开密码且提供的密码正确时返回`true`。在以下情况下返回`false`：

- 密码不正确。
- 演示文稿没有打开密码。
- 提供的密码为`null`或为空。

PPT 和 PPTX 演示文稿的行为相同。

## **检查已加载的演示文稿是否已加密**

使用正确的密码加载演示文稿后，检查[IProtectionManager.IsEncrypted](https://reference.aspose.com/slides/zh/net/aspose.slides/iprotectionmanager/isencrypted/)以确认源演示文稿已被加密。要在加载之前检测打开密码保护，请使用上文所示的`IPresentationInfo.IsPasswordProtected`。

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-pres.pptx", loadOptions);

var isEncrypted = presentation.ProtectionManager.IsEncrypted;
Console.WriteLine("The presentation is encrypted: " + isEncrypted);
```

## **安全建议**

{{% alert color="warning" title="Security" %}}
不要记录打开密码或将其包含在诊断消息中。避免不必要的重复验证尝试，仅在需要时在内存中保留密码，并在立即加载演示文稿时复用成功的验证结果。
{{% /alert %}}

## **在线为演示文稿设置密码保护**

1. 打开[Aspose.Slides Lock](https://products.aspose.app/slides/zh/lock)应用程序。
1. 选择或上传演示文稿。
1. 输入用于查看保护的密码。
1. 可选地为编辑保护输入另一个密码。
1. 应用保护并下载生成的文件。

{{% alert color="info" title="See also" %}}
- [Write-Protect Presentations](/slides/zh/net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/zh/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常见问题**

**打开密码和写保护密码有什么区别？**

打开密码会加密演示文稿，并且在加载其内容时必须提供。写保护密码限制修改，但不加密内容。

**我可以在不加载所有幻灯片的情况下验证打开密码吗？**

可以。获取演示文稿信息，检查是否存在打开密码保护，然后在创建完整演示文稿实例之前验证密码。

**密码检查工作流是否同时支持 PPT 和 PPTX？**

是的。文件路径和基于流的密码检测与验证在 PPT 和 PPTX 演示文稿中表现相同。