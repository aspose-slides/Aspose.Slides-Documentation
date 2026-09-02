---
title: .NET 中的写保护演示文稿
linktitle: 写保护
type: docs
weight: 25
url: /zh/net/write-protected-presentation/
keywords:
- 写保护
- PowerPoint写保护
- 修改密码
- 限制演示文稿编辑
- 移除写保护
- 验证修改密码
- PowerPoint
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "使用 Aspose.Slides for .NET 在 PowerPoint PPT 和 PPTX 演示文稿中设置、检测、验证和移除写保护密码。"
---
## **介绍**

写保护密码限制对演示文稿的修改，但不加密其内容。用户可以在没有密码的情况下加载并查看受写保护的演示文稿。根据应用程序的不同，用户也可能能够编辑内容并另存为其他名称，因此写保护不应被视为保密机制。

打开密码的作用不同：它对演示文稿进行加密，并且加载内容时需要该密码。要加密演示文稿或验证打开密码，请参阅[Password-Protect Presentations](/slides/zh/net/password-protected-presentation/)。

本文中的工作流适用于 PPT 和 PPTX 演示文稿。示例使用 PPTX 文件；保存为 PPT 时，请使用 `.ppt` 扩展名和相应的 PPT 保存格式。

## **为演示文稿设置写保护**

使用[IProtectionManager.SetWriteProtection](https://reference.aspose.com/slides/zh/net/aspose.slides/iprotectionmanager/setwriteprotection/)为修改演示文稿分配密码。保存演示文稿会保留该保护设置。

以下示例在 PPTX 演示文稿上设置写保护：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

presentation.ProtectionManager.SetWriteProtection("modify_password");
presentation.Save("write-protected-pres.pptx", SaveFormat.Pptx);
```

## **加载受写保护的演示文稿**

由于写保护不加密演示文稿内容，加载演示文稿不需要密码。该密码仅在验证修改受保护演示文稿的授权时才相关。

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("write-protected-pres.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

不要将写保护密码传递给[LoadOptions.Password](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/password/)。该属性接受用于加密内容的打开密码。如果演示文稿同时具有两种保护类型，请提供打开密码以加载它，并单独处理写保护密码。

## **从演示文稿中移除写保护**

使用[IProtectionManager.RemoveWriteProtection](https://reference.aspose.com/slides/zh/net/aspose.slides/iprotectionmanager/removewriteprotection/)移除修改限制，然后保存演示文稿。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("write-protected-pres.pptx");

presentation.ProtectionManager.RemoveWriteProtection();
presentation.Save("write-protection-removed.pptx", SaveFormat.Pptx);
```

## **检查演示文稿是否受写保护**

若要在不创建完整[Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/)实例的情况下检查文件，请调用[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationfactory/getpresentationinfo/)并检查[IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationinfo/iswriteprotected/)。该属性使用[NullableBool](https://reference.aspose.com/slides/zh/net/aspose.slides/nullablebool/)，在检测到写保护时返回`NullableBool.True`。

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected == NullableBool.True)
{
    Console.WriteLine("The presentation is write protected.");
}
else
{
    Console.WriteLine("Write protection was not detected.");
}
```

[IPresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationfactory/getpresentationinfo/)的流重载为以流形式提供的演示文稿提供相同的信息。

## **验证写保护密码**

使用[IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationinfo/checkwriteprotection/)在不加载完整演示文稿的情况下验证修改密码。首先检查[IPresentationInfo.IsWriteProtected](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationinfo/iswriteprotected/)，以便仅在存在写保护时请求或验证密码。

```csharp
using System;
using Aspose.Slides;

var presentationInfo = PresentationFactory.Instance.GetPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.IsWriteProtected != NullableBool.True)
{
    Console.WriteLine("The presentation is not write protected.");
}
else if (presentationInfo.CheckWriteProtection("modify_password"))
{
    Console.WriteLine("The write-protection password is correct.");
}
else
{
    Console.WriteLine("The write-protection password is incorrect.");
}
```

[IPresentationInfo.CheckWriteProtection](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationinfo/checkwriteprotection/)仅验证写保护密码。它不验证打开密码，也不确定是否可以加载加密内容。相反，[IPresentationInfo.CheckPassword](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentationinfo/checkpassword/)仅验证打开密码。如果已加载完整演示文稿，[IProtectionManager.CheckWriteProtection](https://reference.aspose.com/slides/zh/net/aspose.slides/iprotectionmanager/checkwriteprotection/)通过其保护管理器提供等效的写保护检查。

在生产环境的应用程序中，不要记录密码或将其包含在诊断信息中。避免不必要的重复验证，并且只在需要时在内存中保留密码。

{{% alert color="info" title="另见" %}}
- [Password-Protect Presentations](/slides/zh/net/password-protected-presentation/)
- [Read-Only Presentations](/slides/zh/net/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/zh/net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **常见问题**

**写保护会加密演示文稿吗？**

否。它限制修改，但仍然可以加载和查看演示文稿内容。

**打开演示文稿是否需要写保护密码？**

否。仅需要打开密码来加载加密的演示文稿内容。

**演示文稿可以同时拥有打开密码和写保护密码吗？**

是的。通过加载选项提供打开密码以打开加密的演示文稿，并在需要修改授权时单独验证写保护密码。