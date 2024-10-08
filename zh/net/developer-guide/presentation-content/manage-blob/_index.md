---
title: 管理 Blob
type: docs
weight: 10
url: /zh/net/manage-blob/
keywords: "添加 blob, 导出 blob, 作为 blob 添加图片, PowerPoint 演示文稿, C#, Csharp, Aspose.Slides for .NET"
description: "在 C# 或 .NET 中将 blob 添加到 PowerPoint 演示文稿。导出 blob。作为 blob 添加图像"
---

## **关于 BLOB**

**BLOB** (**二进制大对象**) 通常是以二进制格式保存的大型项目（照片、演示文稿、文档或媒体）。

Aspose.Slides for .NET 允许您以减少大型文件时内存消耗的方式使用 BLOB。

## **使用 BLOB 减少内存消耗**

### **通过 BLOB 向演示文稿添加大型文件**

[Aspose.Slides](/slides/zh/net/) for .NET 允许您通过涉及 BLOB 的过程向演示文稿添加大型文件（在这种情况下是一个大型视频文件），以减少内存消耗。

以下 C# 示例展示了如何通过 BLOB 过程向演示文稿添加一个大型视频文件：

```c#
const string pathToVeryLargeVideo = "veryLargeVideo.avi";

// 创建一个新的演示文稿，将添加视频
using (Presentation pres = new Presentation())
{
    using (FileStream fileStream = new FileStream(pathToVeryLargeVideo, FileMode.Open))
    {
        // 将视频添加到演示文稿 - 我们选择 KeepLocked 行为，因为我们不打算访问 "veryLargeVideo.avi" 文件。
        IVideo video = pres.Videos.AddVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.Slides[0].Shapes.AddVideoFrame(0, 0, 480, 270, video);

        // 保存演示文稿。当大型演示文稿输出时，内存消耗在 pres 对象的生命周期内保持低。
        pres.Save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    }
}
```


### **通过 BLOB 从演示文稿导出大型文件**
Aspose.Slides for .NET 允许您通过涉及 BLOB 的过程从演示文稿导出大型文件（在这种情况下是音频或视频文件）。例如，您可能需要从演示文稿中提取一个大型媒体文件，但又不希望该文件加载到计算机的内存中。通过 BLOB 过程导出文件，您可以保持低内存消耗。

以下 C# 代码演示了上述操作：

```c#
const string hugePresentationWithAudiosAndVideosFile = @"Large  Video File Test1.pptx";

LoadOptions loadOptions = new LoadOptions
{
	BlobManagementOptions = {
		// 锁定源文件并不将其加载到内存中
		PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
	}
};

// 创建一个演示文稿实例，锁定 "hugePresentationWithAudiosAndVideos.pptx" 文件。
using (Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions))
{
	// 将每个视频保存到文件。为了防止高内存使用，我们需要一个缓冲区，用于将数据从演示文稿的视频流传输到新创建视频文件的流。
	byte[] buffer = new byte[8 * 1024];

	// 遍历视频
	for (var index = 0; index < pres.Videos.Count; index++)
	{
		IVideo video = pres.Videos[index];

		// 打开演示文稿视频流。请注意，我们故意避免访问类似 video.BinaryData 的属性，因为这个属性返回一个包含完整视频的字节数组，这会导致字节加载到内存中。我们使用 video.GetStream，它将返回 Stream，并不需要我们将整个视频加载到内存中。
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

		// 无论视频或演示文稿的大小如何，内存消耗将保持低。
	}

	// 如有必要，您可以对音频文件应用相同的步骤。 
}
```

### **在演示文稿中作为 BLOB 添加图像**
通过 [**IImageCollection**](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection) 接口和 [**ImageCollection** ](https://reference.aspose.com/slides/net/aspose.slides/imagecollection) 类的方法，您可以将大型图像作为流添加，使其被视为 BLOB。

以下 C# 代码展示了如何通过 BLOB 过程添加一个大型图像：

```c#
string pathToLargeImage = "large_image.jpg";

// 创建一个新的演示文稿，将添加图像。
using (Presentation pres = new Presentation())
{
	using (FileStream fileStream = new FileStream(pathToLargeImage, FileMode.Open))
	{
		// 将图像添加到演示文稿 - 我们选择 KeepLocked 行为，因为我们不打算访问 "largeImage.png" 文件。
		IPPImage img = pres.Images.AddImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// 保存演示文稿。当大型演示文稿输出时，内存消耗保持在 pres 对象的生命周期内
		pres.Save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	}
}
```

## **内存和大型演示文稿**

通常，加载大型演示文稿时，计算机需要大量的临时内存。演示文稿的所有内容都加载到内存中，而文件（从中加载演示文稿）将不再使用。

考虑一个包含 1.5 GB 视频文件的大型 PowerPoint 演示文稿（large.pptx）。加载演示文稿的标准方法在以下 C# 代码中描述：

```c#
using (Presentation pres = new Presentation("large.pptx"))
{
   pres.Save("large.pdf", SaveFormat.Pdf);
}
```

但这种方法大约消耗 1.6 GB 的临时内存。

### **将大型演示文稿作为 BLOB 加载**

通过涉及 BLOB 的过程，您可以在使用较少内存的情况下加载大型演示文稿。以下 C# 代码描述了利用 BLOB 过程加载大型演示文稿文件（large.pptx）的实现：

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

### **更改临时文件的文件夹**

当使用 BLOB 过程时，您的计算机会在默认的临时文件文件夹中创建临时文件。如果您希望临时文件保存在不同的文件夹中，可以使用 `TempFilesRootPath` 更改存储设置：

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

{{% alert title="信息" color="info" %}}

使用 `TempFilesRootPath` 时，Aspose.Slides 不会自动创建用于存储临时文件的文件夹。您必须手动创建该文件夹。

{{% /alert %}}