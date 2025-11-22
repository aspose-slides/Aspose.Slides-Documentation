---
title: 在 C# 中打开演示文稿
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
description: "使用 Aspose.Slides for .NET 轻松打开 PowerPoint（.pptx、.ppt）和 OpenDocument（.odp）演示文稿——快速、可靠、功能齐全。"
---

## **概述**

除了从头创建 PowerPoint 演示文稿，Aspose.Slides 还可以打开现有的演示文稿。加载演示文稿后，您可以检索其信息、编辑幻灯片内容、添加新幻灯片、删除已有幻灯片等。

## **打开演示文稿**

要打开现有演示文稿，实例化 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类并将文件路径传递给其构造函数。

以下 C# 示例展示了如何打开演示文稿并获取其幻灯片计数：
```cs
// 实例化 Presentation 类并将文件路径传递给其构造函数。
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // 打印演示文稿中的幻灯片总数。
    System.Console.WriteLine(presentation.Slides.Count);
}
```


## **打开受密码保护的演示文稿**

当需要打开受密码保护的演示文稿时，通过 [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) 类的 [Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) 属性传入密码即可解密并加载。以下 C# 代码演示了此操作：
```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // 对解密后的演示文稿执行操作。
}
```


## **打开大型演示文稿**

Aspose.Slides 提供了选项——特别是 [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) 类中的 [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/blobmanagementoptions/) 属性——帮助您加载大型演示文稿。

以下 C# 代码演示了加载大型演示文稿（例如 2 GB）的过程：
```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // 选择 KeepLocked 行为——演示文稿文件将在整个生命周期内保持锁定
        // 演示实例期间，但它不需要加载到内存或复制到临时文件。
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 MB
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // 大型演示文稿已加载并可使用，同时内存消耗保持低水平。

    // 对演示文稿进行更改。
    presentation.Slides[0].Name = "Large presentation";

    // 将演示文稿保存到另一个文件。此操作期间内存消耗保持低水平。
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // 不要这样做！会抛出 I/O 异常，因为文件在演示稿对象释放之前会被锁定。
    File.Delete(filePath);
}

// 在这里执行是可以的。源文件已不再被演示文稿对象锁定。
File.Delete(filePath);
```


{{% alert color="info" title="Info" %}}
为了解决在使用流时的某些限制，Aspose.Slides 可能会复制流的内容。从流加载大型演示文稿会导致演示文稿被复制，从而降低加载速度。因此，在需要加载大型演示文稿时，我们强烈建议使用演示文稿文件路径而非流。

在创建包含大对象（视频、音频、高分辨率图像等）的演示文稿时，您可以使用 [BLOB management](/slides/zh/net/manage-blob/) 来降低内存消耗。
{{%/alert %}}

## **控制外部资源**

Aspose.Slides 提供了 [IResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/iresourceloadingcallback/) 接口，以便您管理外部资源。以下 C# 代码展示了如何使用 `IResourceLoadingCallback` 接口：
```cs
LoadOptions loadOptions = new LoadOptions();
loadOptions.ResourceLoadingCallback = new ImageLoadingHandler();

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```cs
public class ImageLoadingHandler : IResourceLoadingCallback
{
    public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
    {
        if (args.OriginalUri.EndsWith(".jpg"))
        {
            try
            {
                // 加载替代图像。
                byte[] imageData = File.ReadAllBytes("aspose-logo.jpg");
                args.SetData(imageData);
                return ResourceLoadingAction.UserProvided;
            }
            catch (Exception)
            {
                return ResourceLoadingAction.Skip;
            }
        }
        else if (args.OriginalUri.EndsWith(".png"))
        {
            // 设置替代 URL。
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // 跳过所有其他图像。
        return ResourceLoadingAction.Skip;
    }
}
```


## **在不加载嵌入二进制对象的情况下加载演示文稿**

PowerPoint 演示文稿可能包含以下类型的嵌入二进制对象：

- VBA 项目（可通过 [IPresentation.VbaProject](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/vbaproject/) 访问）；
- OLE 对象嵌入数据（可通过 [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/) 访问）；
- ActiveX 控件二进制数据（可通过 [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/net/aspose.slides/icontrol/activexcontrolbinary/) 访问）。

使用 [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/) 属性，您可以在加载演示文稿时移除所有嵌入的二进制对象。

此属性对于删除可能的恶意二进制内容非常有用。以下 C# 代码演示了如何在不加载任何嵌入二进制内容的情况下加载演示文稿：
```cs
LoadOptions loadOptions = new LoadOptions()
{
	DeleteEmbeddedBinaryObjects = true
}

using (Presentation presentation = new Presentation("malware.ppt", loadOptions))
{
    // 对演示文稿执行操作。
}
```


## **常见问题**

**如何判断文件已损坏且无法打开？**

加载时会抛出解析/格式验证异常。此类错误通常提示 ZIP 结构无效或 PowerPoint 记录损坏。

**打开时缺少必需的字体会怎样？**

文件仍会打开，但随后在[渲染/导出](/slides/zh/net/convert-presentation/)时可能会替换字体。请在运行时环境中[配置字体替换](/slides/zh/net/font-substitution/)或[添加所需字体](/slides/zh/net/custom-font/)。

**打开时嵌入的媒体（视频/音频）会怎样？**

它们会作为演示文稿资源可用。如果媒体通过外部路径引用，请确保这些路径在您的环境中可访问；否则在[渲染/导出](/slides/zh/net/convert-presentation/)时可能会省略这些媒体。