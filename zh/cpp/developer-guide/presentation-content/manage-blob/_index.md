---
title: 管理 Blob
type: docs
weight: 10
url: /zh/cpp/manage-blob/
keywords: "添加 blob, 导出 blob, 将图像作为 blob 添加, PowerPoint 演示文稿, C++, Aspose.Slides for C++"
description: "在 C++ 中向 PowerPoint 演示文稿添加 blob。导出 blob。将图像作为 blob 添加。"
---

## **关于 BLOB**

**BLOB** (**二进制大对象**) 通常是以二进制格式保存的大项目（照片、演示文稿、文档或媒体）。 

Aspose.Slides for C++ 允许您在涉及大型文件时以一种减少内存消耗的方式使用 BLOB。

## **使用 BLOB 减少内存消耗**

### **通过 BLOB 向演示文稿添加大型文件**

[Aspose.Slides](/slides/zh/cpp/) for C++ 允许您通过涉及 BLOB 的过程向演示文稿添加大型文件（在此案例中为大型视频文件），以减少内存消耗。

以下 C++ 代码演示了如何通过 BLOB 过程向演示文稿添加大型视频文件：

```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// 创建一个新的演示文稿，将添加视频
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// 让我们将视频添加到演示文稿中 - 我们选择 KeepLocked 行为，因为
//我们并不打算访问 "veryLargeVideo.avi" 文件。
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// 保存演示文稿。当输出大型演示文稿时，内存消耗
// 在 pres 对象的生命周期内保持较低
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```


### **通过 BLOB 从演示文稿导出大型文件**
Aspose.Slides for C++ 允许您通过涉及 BLOB 的过程从演示文稿导出大型文件（在此案例中为音频或视频文件）。例如，您可能需要从演示文稿中提取大型媒体文件，但不希望将文件加载到计算机的内存中。通过 BLOB 过程导出文件，您可以保持低内存消耗。 

以下 C++ 代码演示了所述操作：

```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// 创建演示文稿实例，锁定 "hugePresentationWithAudiosAndVideos.pptx" 文件。

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// 让我们将每个视频保存到一个文件。为了防止高内存使用，我们需要一个缓冲区，用于从演示文稿的视频流传输数据到新创建的视频文件的流中。
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// 遍历视频
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// 打开演示文稿视频流。请注意，我们故意避免访问方法
	// 例如 video->get_BinaryData - 因为此方法返回一个包含完整视频的字节数组，然后
	// 导致字节被加载到内存中。我们使用 video->GetStream，这将返回 Stream - 并且不需要
	// 我们将整个视频加载到内存中。
	
	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
	// 无论视频或演示文稿的大小，内存消耗将保持较低，
}

// 如果需要，您可以对音频文件应用相同的步骤。
```

### **将图像作为 BLOB 添加到演示文稿**
使用 [**IImageCollection**](https://reference.aspose.com/slides/cpp/class/aspose.slides.i_image_collection) 接口和 [**ImageCollection** ](https://reference.aspose.com/slides/cpp/class/aspose.slides.image_collection) 类中的方法，您可以将大型图像作为流添加，以将其视为 BLOB。 

以下 C++ 代码展示了如何通过 BLOB 过程添加大型图像：

```cpp
const String pathToLargeImage = u"large_image.jpg";

// 创建一个新的演示文稿，将添加图像。
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// 让我们将图像添加到演示文稿中 - 我们选择 KeepLocked 行为，因为我们
// 不打算访问 "largeImage.png" 文件。
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// 保存演示文稿。当输出大型演示文稿时，内存消耗 
// 在 pres 对象的生命周期内保持较低
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```

## **内存和大型演示文稿**

通常，加载大型演示文稿，计算机需要大量临时内存。所有演示文稿的内容都被加载到内存中，加载演示文稿的文件不再被使用。

考虑一个包含 1.5 GB 视频文件的大型 PowerPoint 演示文稿 (large.pptx)。加载演示文稿的标准方法在以下 C++ 代码中描述：

```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

但此方法消耗约 1.6 GB 的临时内存。

### **将大型演示文稿加载为 BLOB**

通过涉及 BLOB 的过程，您可以在使用较少内存的同时加载大型演示文稿。以下 C++ 代码描述了使用 BLOB 过程加载大型演示文稿文件 (large.pptx) 的实现：

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);

auto pres = System::MakeObject<Presentation>(u"large.pptx", loadOptions);
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

#### **更改临时文件的文件夹**

当使用 BLOB 过程时，您的计算机会在默认的临时文件夹中创建临时文件。如果您希望临时文件保存在不同的文件夹中，可以使用 `TempFilesRootPath` 更改存储设置：

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```

{{% alert title="信息" color="info" %}}

使用 `TempFilesRootPath` 时，Aspose.Slides 不会自动创建用于存储临时文件的文件夹。您必须手动创建文件夹。 

{{% /alert %}}