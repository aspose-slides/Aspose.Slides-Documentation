---
title: 在 .NET 中打开演示文稿
linktitle: 打开演示文稿
type: docs
weight: 20
url: /zh/net/open-presentation/
keywords:
- 打开 PowerPoint
- 打开演示文稿
- 打开 PPTX
- 打开 PPT
- 打开 ODP
- 加载演示文稿
- 加载 PPTX
- 加载 PPT
- 加载 ODP
- 受保护的演示文稿
- 大型演示文稿
- 外部资源
- 二进制对象
- .NET
- C#
- Aspose.Slides
description: "了解如何在 C# 中打开 PowerPoint 和 OpenDocument 演示文稿，提供打开密码，控制资源加载，并使用 Aspose.Slides for .NET 减少内存使用。"
---
## **简介**

[Aspose.Slides for .NET](https://products.aspose.com/slides/zh/net/) 可以从文件和流加载 PowerPoint 和 OpenDocument 演示文稿。加载演示文稿后，您可以检查其结构、编辑幻灯片、管理资源，并以原始格式或其他受支持的格式保存。

加载行为可以通过 [LoadOptions](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/) 类进行自定义。例如，您可以提供打开密码、将大型二进制对象保留在受管内存之外、控制外部资源或省略嵌入的二进制数据。

## **打开演示文稿**

加载文件或流后，您可以[determine its original presentation format](/slides/zh/net/detect-presentation-source-format/) 以选择应用程序的处理方式。

要打开现有演示文稿，请将其文件路径传递给 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 构造函数。使用完毕后请释放演示文稿，以便及时释放文件句柄、临时数据和其他资源。

下面的 C# 示例展示了如何打开演示文稿并获取其幻灯片计数：

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **打开受密码保护的演示文稿**

打开密码会加密演示文稿内容。要加载完整演示文稿，请将正确的密码分配给 [LoadOptions.Password](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/password/) 并将该选项传递给 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 构造函数。缺少或不正确的密码会导致加载失败。

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

有关密码检测、验证和加密工作流，请参阅[Password-Protect Presentations](/slides/zh/net/password-protected-presentation/)。如果加密的演示文稿有意使用公共文档属性保存，则可以在不提供密码的情况下读取这些属性；请参阅[Manage Presentation Properties](/slides/zh/net/presentation-properties/)。

## **打开大型演示文稿**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/blobmanagementoptions/) 控制 Aspose.Slides 如何处理图像、音频和视频等大型二进制对象。您可以保持源文件锁定、允许使用临时文件，并限制保留在内存中的 BLOB 数据量。

下面的 C# 代码演示了加载大型演示文稿（例如 2 GB）：

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

const string filePath = "large-presentation.pptx";

var loadOptions = new LoadOptions
{
    BlobManagementOptions =
    {
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024
    }
};

using var presentation = new Presentation(filePath, loadOptions);

presentation.Slides[0].Name = "Large presentation";
presentation.Save("large-presentation-copy.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
使用 `PresentationLockingBehavior.KeepLocked` 时，源文件将保持锁定状态，直至 `Presentation` 对象被释放。在对象存活期间请勿移动、覆盖或删除源文件。
Aspose.Slides 可能在加载时复制输入流的内容。对于大型演示文稿，文件路径通常比流更高效。有关其他存储和内存管理选项，请参阅[Manage BLOBs](/slides/zh/net/manage-blob/)。
{{% /alert %}}

## **控制外部资源**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/resourceloadingcallback/) 接受一个 [IResourceLoadingCallback](https://reference.aspose.com/slides/zh/net/aspose.slides/iresourceloadingcallback/) 实现。回调可以提供替代数据、重定向资源、使用默认加载器或跳过资源。当演示文稿包含必须根据应用特定安全或存储规则解析的外部图像时，此功能非常有用。

```csharp
using System;
using System.IO;
using Aspose.Slides;

internal static class OpenPresentationExample
{
    private static void Main()
    {
        var loadOptions = new LoadOptions
        {
            ResourceLoadingCallback = new ImageLoadingHandler()
        };

        using var presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
        Console.WriteLine("Slide count: " + presentation.Slides.Count);
    }

    private sealed class ImageLoadingHandler : IResourceLoadingCallback
    {
        public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
        {
            var isJpeg = args.OriginalUri.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase);
            if (!isJpeg || !File.Exists("approved-image.jpg"))
            {
                return ResourceLoadingAction.Skip;
            }

            var imageData = File.ReadAllBytes("approved-image.jpg");
            args.SetData(imageData);
            return ResourceLoadingAction.UserProvided;
        }
    }
}
```

## **加载不含嵌入式二进制对象的演示文稿**

演示文稿可能包含应用程序不需要或不想保留的嵌入式二进制数据。例如：

- VBA 项目，可通过[IPresentation.VbaProject](https://reference.aspose.com/slides/zh/net/aspose.slides/ipresentation/vbaproject/)获取；
- 嵌入的 OLE 数据，可通过[IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/zh/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/)获取；
- ActiveX 控件数据，可通过[IControl.ActiveXControlBinary](https://reference.aspose.com/slides/zh/net/aspose.slides/icontrol/activexcontrolbinary/)获取。

将 [LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) 设置为 `true`，即可在加载时删除这些二进制数据。将加载后的演示文稿保存，以持久化清理后的结果。

此选项可降低不需要的嵌入负载风险，但它并非完整的恶意软件检测或内容消毒系统。

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DeleteEmbeddedBinaryObjects = true
};

using var presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);

presentation.Save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
```

## **常见问题**

**如何判断文件已损坏且无法打开？**

Aspose.Slides 在加载期间会抛出解析或格式异常。请将此类失败单独处理，而不是与密码错误混淆，以便应用程序能够准确报告原因。

**如果缺少必需的字体会怎样？**

演示文稿仍可加载，但渲染和导出时可能会使用替代字体。您可以[configure font substitution](/slides/zh/net/font-substitution/) 或[provide custom fonts](/slides/zh/net/custom-font/) 来使输出更可预测。

**加载演示文稿是否会同时加载其嵌入的媒体？**

嵌入的音频和视频会通过演示文稿对象模型可用。外部资源会根据配置的资源加载行为进行解析；如果无法访问其位置，则可能不可用。