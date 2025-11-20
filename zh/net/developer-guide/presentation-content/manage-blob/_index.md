---
title: 管理 Blob
type: docs
weight: 10
url: /zh/net/manage-blob/
keywords: "添加 Blob, 导出 Blob, 将图像添加为 Blob, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中将 Blob 添加到 PowerPoint 演示文稿。导出 Blob。将图像添加为 Blob"
---

## **关于 BLOB**

**BLOB** (**Binary Large Object**) 通常是以二进制格式保存的大型项目（照片、演示文稿、文档或媒体）。

Aspose.Slides for .NET 允许您在对象上使用 BLOB，以在处理大型文件时降低内存消耗。

## **使用 BLOB 减少内存消耗**

### **通过 BLOB 将大型文件添加到演示文稿**

[Aspose.Slides](/slides/zh/net/) for .NET 允许您通过 BLOB 过程添加大型文件（在本例中是大型视频文件），以降低内存消耗。

下面的 C# 示例演示了如何通过 BLOB 过程将大型视频文件添加到演示文稿：
```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// 创建一个新的演示文稿，将向其添加视频
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // 让我们将视频添加到演示文稿中 - 我们选择 KeepLocked 行为，因为我们
        // 不打算访问 "veryLargeVideo.avi" 文件。
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // 保存演示文稿。即使输出大型演示文稿，内存消耗
        // 通过整个 pres 对象的生命周期保持低位 
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```



### **通过 BLOB 从演示文稿导出大型文件**
Aspose.Slides for .NET 允许您通过 BLOB 过程从演示文稿中导出大型文件（例如音频或视频文件）。例如，您可能需要从演示文稿中提取大型媒体文件，但不希望将文件加载到计算机内存中。通过 BLOB 导出文件，您可以保持低内存消耗。

下面的 C# 代码演示了上述操作：
```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// 锁定源文件且不加载到内存中
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// 创建 Presentation 实例，并锁定 "hugePresentationWithAudiosAndVideos.pptx" 文件。
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// 让我们将每个视频保存到文件。为防止高内存使用，我们需要一个缓冲区来
	// 将演示文稿视频流的数据传输到新创建的视频文件的流。
	byte[] buffer = new byte[8 * 1024];

	// Iterates through the videos
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// 打开演示文稿的视频流。请注意，我们有意避免访问属性
		// 如 video.BinaryData —— 因为此属性返回包含完整视频的字节数组，这将
		// 导致字节被加载到内存中。我们使用 video.GetStream，它将返回 Stream —— 且不会
		// 需要我们将整个视频加载到内存中。
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

		// 无论视频或演示文稿的大小如何，内存消耗都将保持低。
	}

	// 如有必要，您可以对音频文件执行相同的步骤。 
}
```


### **在演示文稿中将图像添加为 BLOB**
使用 [**IImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) 接口和 [**ImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/imagecollection) 类的方法，您可以将大型图像作为流添加，以将其视为 BLOB。

下面的 C# 代码演示了如何通过 BLOB 过程添加大型图像：
```c#
string pathToLargeImage = "large_image.jpg";

// 创建一个新的演示文稿，将向其添加图像。
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// 让我们将图像添加到演示文稿中 - 我们选择 KeepLocked 行为，因为我们
		// 不打算访问 "largeImage.png" 文件。
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// 保存演示文稿。即使输出大型演示文稿，内存消耗
		// 在整个 pres 对象的生命周期内保持低水平。
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```


## **内存与大型演示文稿**

通常，要加载大型演示文稿，计算机需要大量临时内存。演示文稿的所有内容都会加载到内存中，加载该演示文稿的文件则不再被使用。

假设有一个包含 1.5 GB 视频文件的大型 PowerPoint 演示文稿（large.pptx）。加载该演示文稿的标准方法如下 C# 代码所示：
```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```


但此方法会消耗约 1.6 GB 的临时内存。

### **将大型演示文稿作为 BLOB 加载**

通过 BLOB 过程，您可以在使用很少内存的情况下加载大型演示文稿。以下 C# 代码描述了使用 BLOB 过程加载大型演示文稿文件（large.pptx）的实现：
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
使用 BLOB 过程时，计算机会在默认的临时文件夹中创建临时文件。如果您希望将临时文件保存在其他文件夹中，可以使用 `TempFilesRootPath` 更改存储设置：
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

## **常见问题**

**在 Aspose.Slides 演示文稿中，哪些数据被视为 BLOB 并受 BLOB 选项控制？**

图像、音频和视频等大型二进制对象被视为 BLOB。当加载或保存演示文稿文件时，整个演示文稿文件也涉及 BLOB 处理。这些对象受 BLOB 策略的管控，您可以在需要时管理内存使用并将数据转存至临时文件。

**在演示文稿加载期间，我在哪里配置 BLOB 处理规则？**

使用 [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) 与 [BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/)。在此处设置 BLOB 的内存限制，是否允许临时文件，临时文件的根路径，以及源锁定行为。

**BLOB 设置会影响性能吗？我该如何在速度和内存之间取得平衡？**

会的。将 BLOB 保留在内存中可最大化速度，但会增加 RAM 消耗；降低内存限制会将更多工作转移到临时文件，从而降低 RAM 使用，但会增加额外的 I/O。调节 [MaxBlobsBytesInMemory](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/maxblobsbytesinmemory/) 阈值，以在您的工作负载和环境中实现合适的平衡。

**在打开极大型演示文稿（例如 GB 级）时，BLOB 选项是否有帮助？**

会的。[BlobManagementOptions](https://reference.aspose.com/slides/net/aspose.slides/blobmanagementoptions/) 正是为此类场景设计的：启用临时文件并使用源锁定可以显著降低峰值 RAM 使用并使处理非常大型文稿更为稳定。

**在从流而非磁盘文件加载时，我可以使用 BLOB 策略吗？**

可以。相同的规则适用于流：演示文稿实例可以拥有并锁定输入流（取决于所选的锁定模式），并在允许的情况下使用临时文件，从而在处理期间保持可预测的内存使用。