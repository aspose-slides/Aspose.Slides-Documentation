---
title: 在 .NET 中管理演示文稿 BLOB 以实现高效内存使用
linktitle: 管理 BLOB
type: docs
weight: 10
url: /zh/net/manage-blob/
keywords:
- 大对象
- 大项目
- 大文件
- 添加 BLOB
- 导出 BLOB
- 将图像添加为 BLOB
- 减少内存
- 内存消耗
- 大型演示文稿
- 临时文件
- PowerPoint
- OpenDocument
- 演示文稿
- .NET
- C#
- Aspose.Slides
description: "在 Aspose.Slides for .NET 中管理 BLOB 数据，以简化 PowerPoint 和 OpenDocument 文件操作，实现高效的演示文稿处理。"
---
## **概述**

Aspose.Slides 为演示文稿中的大二进制数据提供基于 BLOB 的处理，以帮助在处理大图像、音频、视频和演示文件时减少内存消耗。

本文展示了如何使用基于 BLOB 的处理将大型媒体添加到演示文稿、从演示文稿导出大型媒体，以及更高效地加载大型演示文稿。还说明了在处理过程中如何使用临时文件以及如何更改用于存储临时文件的文件夹。

## **关于 BLOB**

**BLOB**（**Binary Large Object**）通常是以二进制格式保存的大型项（照片、演示文稿、文档或媒体）。

Aspose.Slides for .NET 允许您以降低内存消耗的方式为对象使用 BLOB，尤其是在涉及大型文件时。

## **使用 BLOB 降低内存消耗**

### **通过 BLOB 将大文件添加到演示文稿**

[Aspose.Slides](/slides/zh/net/) for .NET 允许您通过涉及 BLOB 的过程添加大文件（此处为大型视频文件），以降低内存消耗。

以下 C# 示例展示了如何通过 BLOB 过程将大型视频文件添加到演示文稿：

```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// 创建一个新演示文稿，将在其中添加视频
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // 让我们将视频添加到演示文稿中 - 我们选择 KeepLocked 行为，因为我们
        // 不打算访问 "veryLargeVideo.avi" 文件。
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // 保存演示文稿。虽然输出了大型演示文稿，
        // 在 pres 对象的整个生命周期中，内存消耗保持低水平 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```

### **通过 BLOB 从演示文稿导出大文件**
Aspose.Slides for .NET 允许您通过涉及 BLOB 的过程从演示文稿中导出大文件（例如音频或视频文件）。例如，您可能需要从演示文稿中提取大型媒体文件，但不想将文件加载到计算机内存中。通过 BLOB 过程导出文件，可保持低内存消耗。

以下 C# 代码演示了上述操作：

```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// 锁定源文件且不将其加载到内存中
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// 创建 Presentation 实例，并锁定 "hugePresentationWithAudiosAndVideos.pptx" 文件。
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// 我们将每个视频保存为文件。为了防止高内存使用，需要一个缓冲区来使用
	// 将演示文稿的视频流中的数据传输到新创建的视频文件的流中。
	byte[] buffer = new byte[8 * 1024];

	// Iterates through the videos
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// 打开演示文稿的视频流。请注意，我们刻意避免访问属性
		// 如 video.BinaryData ——因为该属性返回包含完整视频的字节数组，这会
		// 导致字节被加载到内存中。我们使用 video.GetStream，它返回 Stream ——且不
		//  需要我们将整个视频加载到内存中。
		using (Stream presVideoStream = video.GetStream())
		{
			using (FileStream outputFileStream = File.OpenWrite($"video{index}.avi"))
			{
				int bytesRead;
				while ((bytesRead = presVideoStream.Read(buffer, 0, buffer.Length)) > 0)
				{
					outputFileStream.Write(buffer, 0, bytesRead);
				}
			}
		}

		// 无论视频或演示文稿的大小如何，内存消耗都将保持低水平，
	}

	// 如有必要，您可以对音频文件执行相同的步骤。 
}
```

### **将图像作为 BLOB 添加到演示文稿**
使用来自 [**IImageCollection**](https://reference.aspose.com/slides/zh/net/aspose.slides/iimagecollection) 接口和 [**ImageCollection**](https://reference.aspose.com/slides/zh/net/aspose.slides/imagecollection) 类的方法，您可以将大图像以流的形式添加，使其被视为 BLOB。

以下 C# 代码展示了如何通过 BLOB 过程添加大型图像：

```c#
string pathToLargeImage = "large_image.jpg";

// 创建一个新演示文稿，将在其中添加图像。
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// 让我们将图像添加到演示文稿中 - 我们选择 KeepLocked 行为，因为我们
		// 不打算访问 "largeImage.png" 文件。
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// 保存演示文稿。虽然输出了大型演示文稿，内存消耗 
		// 在 pres 对象的整个生命周期中保持低水平
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```

## **内存与大型演示文稿**

通常，加载大型演示文稿时，计算机需要大量临时内存。演示文稿的所有内容都会加载到内存中，而加载该演示文稿的文件则不再被使用。

考虑一个包含 1.5 GB 视频文件的大型 PowerPoint 演示文稿（large.pptx）。以下 C# 代码描述了标准的加载方法：

```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

但此方法会消耗约 1.6 GB 的临时内存。

### **将大型演示文稿作为 BLOB 加载**

通过涉及 BLOB 的过程，您可以在使用很少内存的情况下加载大型演示文稿。以下 C# 代码说明了使用 BLOB 过程加载大型演示文稿文件（large.pptx）的实现：

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true
   }
};
 
using (Presentation pres = new Presentation("large.pptx", loadOptions))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

### **更改临时文件夹**

使用 BLOB 过程时，计算机会在默认的临时文件夹中创建临时文件。如果希望将临时文件保存在其他文件夹，可使用 `TempFilesRootPath` 更改存储设置：

```c#
LoadOptions loadOptions = new LoadOptions
{
   BlobManagementOptions = new BlobManagementOptions
   {
       PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
       IsTemporaryFilesAllowed = true,
       TempFilesRootPath = "temp"
   }
};
```

{{% alert title="Info" color="info" %}}
使用 `TempFilesRootPath` 时，Aspose.Slides 不会自动创建用于存储临时文件的文件夹。您必须手动创建该文件夹。
{{% /alert %}}

### **释放演示文稿对象以释放内存**

处理大型演示文稿时，请确保正确释放 [Presentation](https://reference.aspose.com/slides/zh/net/aspose.slides/presentation/) 实例，以释放其占用的内存。推荐的做法是使用 `using` 语句或声明，如上例所示；当代码块结束时，它会自动释放演示文稿并释放非托管资源。

如果在没有 `using` 块的情况下创建演示文稿，请在使用完毕后显式调用 `Dispose()`。

```cs
Presentation presentation = new Presentation("large.pptx");

// ...处理演示文稿...
presentation.Save("large.pdf", SaveFormat.Pdf);

// 明确释放资源。
presentation.Dispose();
```

## **常见问题**

**在 Aspose.Slides 演示文稿中，哪些数据被视为 BLOB 并受 BLOB 选项控制？**

图像、音频和视频等大型二进制对象被视为 BLOB。当加载或保存整个演示文稿文件时，也涉及 BLOB 处理。这些对象受 BLOB 策略管理，您可以在需要时控制内存使用并将数据转储到临时文件。

**在哪里配置演示文稿加载期间的 BLOB 处理规则？**

使用 [LoadOptions](https://reference.aspose.com/slides/zh/net/aspose.slides/loadoptions/) 配合 [BlobManagementOptions](https://reference.aspose.com/slides/zh/net/aspose.slides/blobmanagementoptions/)。在此可以设置 BLOB 的内存上限、是否允许临时文件、临时文件根路径以及源锁定行为。

**BLOB 设置会影响性能吗，如何在速度和内存之间取得平衡？**

会。将 BLOB 保存在内存中可获得最高速度，但会增加 RAM 消耗；降低内存上限会将更多工作转移到临时文件，降低 RAM 使用但增加 I/O。调节 [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/zh/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) 阈值，以在工作负载和环境之间找到合适的平衡。

**在打开极大型演示文稿（例如数 GB）时，BLOB 选项有帮助吗？**

有。[BlobManagementOptions](https://reference.aspose.com/slides/zh/net/aspose.slides/blobmanagementoptions/) 专为此类场景设计：启用临时文件并使用源锁定可显著降低峰值 RAM 使用，提升对超大演示文稿的处理稳定性。

**在从流而非磁盘文件加载时，能使用 BLOB 策略吗？**

可以。相同的规则同样适用于流：演示文稿实例可以拥有并锁定输入流（取决于所选的锁定模式），并在允许的情况下使用临时文件，从而在处理期间保持可预测的内存使用。