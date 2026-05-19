---
title: 在 C++ 中管理演示文稿 BLOB 以实现高效内存使用
linktitle: 管理 BLOB
type: docs
weight: 10
url: /zh/cpp/manage-blob/
keywords:
- 大对象
- 大项
- 大文件
- 添加 BLOB
- 导出 BLOB
- 将图像添加为 BLOB
- 降低内存
- 内存消耗
- 大型演示文稿
- 临时文件
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: 在 Aspose.Slides for C++ 中管理 BLOB 数据，以简化 PowerPoint 和 OpenDocument 文件操作，实现高效的演示文稿处理。
---
## **概述**

Aspose.Slides 提供基于 BLOB 的处理，用于演示文稿中的大型二进制数据，以帮助在处理大图片、音频、视频和演示文稿文件时降低内存消耗。

本文展示了如何使用基于 BLOB 的处理向演示文稿添加大型媒体、从演示文稿导出大型媒体以及更高效地加载大型演示文稿。它还说明了在处理过程中如何使用临时文件以及如何更改用于存储临时文件的文件夹。

## **关于 BLOB**

**BLOB**（**Binary Large Object**）通常是以二进制格式保存的大型项（照片、演示文稿、文档或媒体）。

Aspose.Slides for C++ 允许在涉及大文件时以降低内存消耗的方式使用 BLOB。

## **使用 BLOB 减少内存消耗**

### **通过 BLOB 将大文件添加到演示文稿**

[Aspose.Slides](/slides/zh/cpp/) for C++ 允许通过涉及 BLOB 的过程添加大文件（此处为大视频文件），以降低内存消耗。

下面的 C++ 代码展示了如何通过 BLOB 过程将大视频文件添加到演示文稿：

```cpp
const String pathToVeryLargeVideo = u"veryLargeVideo.avi";

// 创建一个将添加视频的新演示文稿
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToVeryLargeVideo, FileMode::Open);
// 让我们将视频添加到演示文稿中 - 我们选择 KeepLocked 行为，因为我们
// 不打算访问 "veryLargeVideo.avi" 文件。
auto video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddVideoFrame(0.0f, 0.0f, 480.0f, 270.0f, video);

// 保存演示文稿。即使输出大型演示文稿，内存消耗
// 在 pres 对象的整个生命周期中保持低水平 
pres->Save(u"presentationWithLargeVideo.pptx", SaveFormat::Pptx);
```

### **通过 BLOB 从演示文稿导出大文件**

Aspose.Slides for C++ 允许通过涉及 BLOB 的过程从演示文稿中导出大文件（此处为音频或视频文件）。例如，您可能需要从演示文稿中提取大型媒体文件，但不希望将文件加载到计算机内存中。通过 BLOB 过程导出文件，可保持内存消耗低。

下面的 C++ 代码演示了上述操作：

```cpp
const String hugePresentationWithAudiosAndVideosFile = u"Large  Video File Test1.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);

// 创建一个 Presentation 实例，锁定 "hugePresentationWithAudiosAndVideos.pptx" 文件。

auto pres = System::MakeObject<Presentation>(hugePresentationWithAudiosAndVideosFile, loadOptions);
// 让我们将每个视频保存为文件。为了防止高内存使用，我们需要一个缓冲区来使用
// 将演示文稿的视频流数据传输到新创建的视频文件的流中。
auto buffer = System::MakeArray<uint8_t>(8 * 1024, 0);

// 遍历视频
for (int32_t index = 0; index < pres->get_Videos()->get_Count(); ++index)
{
	auto video = pres->get_Videos()->idx_get(index);

	// 打开演示文稿的视频流。请注意，我们有意避免访问方法
	// 如 video->get_BinaryData —— 因为此方法返回包含完整视频的字节数组，这将
	// 导致字节被加载到内存中。我们使用 video->GetStream，它将返回 Stream —— 并且不
	// 需要我们将整个视频加载到内存中。
	
	auto presVideoStream = video->GetStream();

	auto outputFileStream = File::OpenWrite(String::Format(u"video{0}.avi", index));
	int32_t bytesRead;
	while ((bytesRead = presVideoStream->Read(buffer, 0, buffer->get_Length())) > 0)
	{
		outputFileStream->Write(buffer, 0, bytesRead);
	}
		
	// 无论视频或演示文稿的大小如何，内存消耗都将保持低位，
}

// 如有必要，您可以对音频文件应用相同的步骤。
```

### **将图像作为 BLOB 添加到演示文稿**

使用 [**IImageCollection**](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.i_image_collection) 接口和 [**ImageCollection** ](https://reference.aspose.com/slides/zh/cpp/class/aspose.slides.image_collection)class 的方法，您可以将大图像作为流添加，以便将其视为 BLOB。

下面的 C++ 代码展示了如何通过 BLOB 过程添加大图像：

```cpp
const String pathToLargeImage = u"large_image.jpg";

// 创建一个将添加图像的新演示文稿。
auto pres = System::MakeObject<Presentation>();

auto fileStream = System::MakeObject<FileStream>(pathToLargeImage, FileMode::Open);
// 让我们将图像添加到演示文稿中 - 我们选择 KeepLocked 行为，因为我们
// 不打算访问 "largeImage.png" 文件。
auto img = pres->get_Images()->AddImage(fileStream, LoadingStreamBehavior::KeepLocked);
pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, 300.0f, 200.0f, img);

// 保存演示文稿。即使输出大型演示文稿，内存消耗
// 在 pres 对象的整个生命周期中保持低水平
pres->Save(u"presentationWithLargeImage.pptx", SaveFormat::Pptx);
```

## **内存和大型演示文稿**

通常，加载大型演示文稿需要大量临时内存。演示文稿的所有内容都会被加载到内存中，而用于加载演示文稿的文件则不再使用。

考虑一个包含 1.5 GB 视频文件的大 PowerPoint 演示文稿（large.pptx）。以下 C++ 代码描述了加载该演示文稿的标准方法：

```cpp
auto pres = System::MakeObject<Presentation>(u"large.pptx");
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

但此方法会消耗约 1.6 GB 的临时内存。

### **将大型演示文稿作为 BLOB 加载**

通过涉及 BLOB 的过程，您可以在使用极少内存的情况下加载大型演示文稿。下面的 C++ 代码描述了使用 BLOB 过程加载大型演示文稿文件（large.pptx）的实现：

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);

auto pres = System::MakeObject<Presentation>(u"large.pptx", loadOptions);
pres->Save(u"large.pdf", SaveFormat::Pdf);
```

#### **更改临时文件夹**

使用 BLOB 过程时，计算机会在默认的临时文件夹中创建临时文件。如果希望将临时文件保存在其他文件夹中，可以使用 `TempFilesRootPath` 更改存储设置：

```cpp
auto blobManagementOptions = System::MakeObject<BlobManagementOptions>();
blobManagementOptions->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
blobManagementOptions->set_IsTemporaryFilesAllowed(true);
blobManagementOptions->set_TempFilesRootPath(u"temp");

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_BlobManagementOptions(blobManagementOptions);
```

{{% alert title="Info" color="info" %}}
使用 `TempFilesRootPath` 时，Aspose.Slides 不会自动创建用于存放临时文件的文件夹。您需要手动创建该文件夹。
{{% /alert %}}

### **释放演示文稿对象以释放内存**

在处理大型演示文稿时，确保正确释放 [Presentation](https://reference.aspose.com/slides/zh/cpp/aspose.slides/presentation/) 实例，以便释放其占用的内存。使用完演示文稿后调用 `Dispose()` 以释放非托管资源。

```cpp
auto presentation = System::MakeObject<Presentation>(u"large.pptx");

// ...process the presentation...
presentation->Save(u"large.pdf", SaveFormat::Pdf);

// Explicitly release resources.
presentation->Dispose();
```

## **常见问题**

**在 Aspose.Slides 演示文稿中，哪些数据被视为 BLOB 并受 BLOB 选项控制？**

图像、音频、视频等大型二进制对象被视为 BLOB。整个演示文稿文件在加载或保存时也涉及 BLOB 处理。这些对象受 BLOB 策略约束，您可以通过策略管理内存使用并在需要时转存到临时文件。

**在演示文稿加载期间，我在哪里配置 BLOB 处理规则？**

使用 [LoadOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides/loadoptions/) 搭配 [BlobManagementOptions](https://reference.aspose.com/slides/zh/cpp/aspose.slides/blobmanagementoptions/)。在此处设置 BLOB 的内存限制、是否允许临时文件、临时文件根路径以及源锁定行为。

**BLOB 设置会影响性能吗，如何在速度和内存之间取得平衡？**

会。将 BLOB 保持在内存中可最大化速度，但会增加 RAM 消耗；降低内存限制会将更多工作转移到临时文件，从而降低 RAM 使用，但会增加 I/O。使用 [set_MaxBlobsBytesInMemory](https://reference.aspose.com/slides/zh/cpp/aspose.slides/blobmanagementoptions/set_maxblobsbytesinmemory/) 方法可为您的工作负载和环境找到合适的平衡点。

**在打开极其大型的演示文稿（例如 GB 级别）时，BLOB 选项有帮助吗？**

有。[BlobManagementOptions] 旨在应对此类场景：启用临时文件并使用源锁定可显著降低峰值 RAM 使用，并使处理非常大的演示文稿更加稳定。

**我可以在从流而不是磁盘文件加载时使用 BLOB 策略吗？**

可以。相同的规则适用于流：演示文稿实例可以拥有并锁定输入流（取决于所选的锁定模式），并在允许的情况下使用临时文件，从而在处理期间保持可预测的内存使用。