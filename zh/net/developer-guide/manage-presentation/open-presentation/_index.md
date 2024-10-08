---
title: 在 C# 中打开演示文稿
linktitle: 打开演示文稿
type: docs
weight: 20
url: /net/open-presentation/
keywords: "打开 PowerPoint, PPTX, PPT, 打开演示文稿, 加载演示文稿, C#, Csharp, .NET"
description: "在 C# 或 .NET 中打开或加载演示文稿 PPT，PPTX，ODP"
---

除了从头创建 PowerPoint 演示文稿，Aspose.Slides 还允许您打开现有演示文稿。在您加载演示文稿后，可以获取有关演示文稿的信息，编辑演示文稿（幻灯片上的内容），添加新幻灯片或删除现有幻灯片等。

## 打开演示文稿

要打开现有演示文稿，您只需实例化 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类，并将文件路径（要打开的演示文稿的路径）传递给它的构造函数。

以下 C# 代码演示如何打开演示文稿，并找出其包含的幻灯片数量：

```c#
// 实例化 Presentation 类，并将文件路径传递给其构造函数
Presentation pres = new Presentation("OpenPresentation.pptx");

// 打印演示文稿中存在的幻灯片总数
System.Console.WriteLine(pres.Slides.Count.ToString());
```

## **打开受密码保护的演示文稿**

当您需要打开受密码保护的演示文稿时，可以通过 [Password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) 属性（来自 [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) 类）传递密码，以解密并加载演示文稿。以下 C# 代码演示该操作：

```c#
	LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
	using (Presentation presentation = new Presentation("pres.pptx", loadOptions))
	{
	  // 对解密后的演示文稿进行一些操作
	}
```

## 打开大型演示文稿

Aspose.Slides 提供选项（尤其是 [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/blobmanagementoptions/) 属性）来允许您加载大型演示文稿。

以下 C# 演示了一项操作，其中加载一个大型演示文稿（例如 2GB 大小）：

```c#
const string pathToVeryLargePresentationFile = "veryLargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = {
        // 选择 KeepLocked 行为 - "veryLargePresentation.pptx" 将在
        // 演示文稿的实例生命周期内保持锁定，但我们不需要将其加载到内存中或复制到
        // 临时文件
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
    }
};

using (Presentation pres = new Presentation(pathToVeryLargePresentationFile, loadOptions))
{
    // 大型演示文稿已被加载并可以使用，但内存消耗仍然较低。

    // 对演示文稿进行更改。
    pres.Slides[0].Name = "非常大的演示文稿";

    // 演示文稿将保存到另一个文件。操作期间内存消耗保持较低
    pres.Save("veryLargePresentation-copy.pptx", SaveFormat.Pptx);

    // 不能这样做！将抛出 IO 异常，因为文件在 pres 对象未被
    // 释放时被锁定
    File.Delete(pathToVeryLargePresentationFile);
}

// 此时可以这样做，源文件未被 pres 对象锁定
File.Delete(pathToVeryLargePresentationFile);
```

{{% alert color="info" title="信息" %}}

为避免在与流交互时遇到某些限制，Aspose.Slides 可能会复制流的内容。通过其流加载大型演示文稿将导致演示文稿内容的复制并导致加载缓慢。因此，当您打算加载大型演示文稿时，我们强烈建议您使用演示文稿文件路径，而不是其流。

当您想创建一个包含大型对象（视频、音频、大图像等）的演示文稿时，可以使用 [Blob facility](https://docs.aspose.com/slides/net/manage-blob/) 以减少内存消耗。

{{%/alert %}} 


## 加载演示文稿
Aspose.Slides 提供 [IResourceLoadingCallback](https://reference.aspose.com/slides/net/aspose.slides/iresourceloadingcallback/) 及其单个方法，以允许您管理外部资源。以下 C# 代码演示如何使用 `IResourceLoadingCallback` 接口：

```c#
LoadOptions opts = new LoadOptions();
opts.ResourceLoadingCallback = new ImageLoadingHandler();
Presentation presentation = new Presentation("presentation.pptx", opts);
```

```c#
public class ImageLoadingHandler : IResourceLoadingCallback
{
    public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
    {
        if (args.OriginalUri.EndsWith(".jpg"))
        {
            try // 加载替代图像
            {
                byte[] imageBytes = File.ReadAllBytes("c:\\aspose-logo.jpg");
                args.SetData(imageBytes);
                return ResourceLoadingAction.UserProvided;
            }
            catch (Exception)
            {
                return ResourceLoadingAction.Skip;
            }
        }
        else if (args.OriginalUri.EndsWith(".png"))
        {
            // 设置替代网址
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // 跳过所有其他图像
        return ResourceLoadingAction.Skip;
    }
}
```

## 加载不包含嵌入二进制对象的演示文稿

PowerPoint 演示文稿可以包含以下类型的嵌入二进制对象：

- VBA 项目 ([IPresentation.VbaProject](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/vbaproject/));
- 嵌入的 OLE 对象数据 ([IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- ActiveX 控件二进制数据 ([IControl.ActiveXControlBinary](https://reference.aspose.com/slides/net/aspose.slides/icontrol/activexcontrolbinary/));

通过 [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/) 属性，您可以加载不包含任何嵌入二进制对象的演示文稿。

该属性对于删除潜在的恶意二进制内容非常有用。

以下 C# 代码演示如何加载和保存没有恶意内容的演示文稿：

```c#
LoadOptions loadOptions = new LoadOptions()
{
	DeleteEmbeddedBinaryObjects = true
}

using (var pres = new Presentation("malware.ppt", loadOptions))
{
    pres.Save("clean.ppt", SaveFormat.Ppt);
}
```

<h2>打开和保存演示文稿</h2>

<a name="csharp-open-save-presentation"><strong>步骤：在 C# 中打开和保存演示文稿</strong></a>

1. 创建 [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) 类的实例，并传递您想要打开的文件。 
2. 保存演示文稿。

```c#
// 加载任何支持的演示文稿，例如 ppt、pptx、odp
Presentation presentation = new Presentation("Sample.odp");

presentation.Save("OutputPresenation.pptx", SaveFormat.Pptx);
```