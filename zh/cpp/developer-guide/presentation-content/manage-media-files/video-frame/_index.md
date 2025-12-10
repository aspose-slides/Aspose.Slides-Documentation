---
title: 使用 C++ 在演示文稿中管理视频帧
linktitle: 视频帧
type: docs
weight: 10
url: /zh/cpp/video-frame/
keywords:
- 添加视频
- 创建视频
- 嵌入视频
- 提取视频
- 检索视频
- 视频帧
- 网络来源
- PowerPoint
- OpenDocument
- 演示文稿
- C++
- Aspose.Slides
description: "学习使用 Aspose.Slides for C++ 在 PowerPoint 和 OpenDocument 幻灯片中以编程方式添加和提取视频帧。快速使用指南。"
---

在演示文稿中恰当地放置视频可以让您的信息更具说服力，并提高观众的参与度。  

PowerPoint 允许您以两种方式向幻灯片添加视频：

* 添加或嵌入本地视频（存储在您的计算机上）  
* 添加在线视频（来自 YouTube 等网络来源）。  

为了让您能够向演示文稿添加视频（视频对象），Aspose.Slides 提供了 [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) 接口、[IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) 接口以及其他相关类型。  

## **创建嵌入式视频帧**

如果要添加到幻灯片的视频文件存储在本地，您可以创建视频帧将视频嵌入到演示文稿中。  

1. 创建一个 [Presentation ](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 添加一个 [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) 对象，并传入视频文件路径以将视频嵌入演示文稿。  
1. 添加一个 [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) 对象以创建视频帧。  
1. 保存已修改的演示文稿。  

以下 C++ 代码演示了如何将本地存储的视频添加到演示文稿中：
```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// Loads the video
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// Gets the first slide and adds a videoframe
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// Saves the presentation to disk
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```


或者，您也可以直接将文件路径传递给 [AddVideoFrame()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/) 方法来添加视频：
``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```


## **创建来自网页源的视频帧**

Microsoft [PowerPoint 2013 及更高版本](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) 支持在演示文稿中嵌入 YouTube 视频。如果您要使用的视频已在线提供（例如在 YouTube 上），可以通过其网页链接将其添加到演示文稿中。  

1. 创建一个 [Presentation ](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 添加一个 [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) 对象，并传入视频链接。  
1. 为视频帧设置缩略图。  
1. 保存演示文稿。  

以下 C++ 代码演示了如何将网络视频添加到 PowerPoint 幻灯片中：
```c++
// 文档目录的路径。
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// 实例化一个表示演示文稿文件的 Presentation 对象
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 访问第一张幻灯片
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// 添加视频帧 
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// 设置视频的播放模式和音量
vf->set_PlayMode(VideoPlayModePreset::Auto);

//将演示文稿保存到磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **从幻灯片中提取视频**

除了向幻灯片添加视频之外，Aspose.Slides 还支持从演示文稿中提取嵌入的视频。  

1. 创建一个 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例以加载包含视频的演示文稿。  
2. 遍历所有 [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) 对象。  
3. 遍历所有 [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) 对象，以查找 [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/)。  
4. 将视频保存到磁盘。  

以下 C++ 代码演示了如何从演示文稿幻灯片中提取视频：
```c++
// 文档目录的路径。
const System::String templatePath = u"../templates/Video.pptx";
const System::String outPath = u"../out/Video_out";

auto presentation = System::MakeObject<Presentation>(templatePath);
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        if (System::ObjectExt::Is<VideoFrame>(shape))
        {
            System::SharedPtr<VideoFrame> vf = System::AsCast<VideoFrame>(shape);
            System::String type = vf->get_EmbeddedVideo()->get_ContentType();
            type = type.Remove(0, type.LastIndexOf('/') + 1);
            auto buffer = vf->get_EmbeddedVideo()->get_BinaryData();

            auto stream = System::MakeObject<System::IO::FileStream>(
                outPath + type, System::IO::FileMode::Create, System::IO::FileAccess::Write,
                System::IO::FileShare::Read);
            stream->Write(buffer, 0, buffer->get_Length());
        }
    }
}
```


## **FAQ**

**可以更改 VideoFrame 的哪些视频播放参数？**  

您可以控制 [播放模式](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playmode/)（自动或点击）和 [循环播放](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_playloopmode/)。这些选项通过 [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/) 对象的属性提供。  

**添加视频会影响 PPTX 文件大小吗？**  

会的。当您嵌入本地视频时，二进制数据会被写入文档，演示文稿大小会随文件大小等比例增长。当您添加在线视频时，仅会嵌入链接和缩略图，大小增长相对较小。  

**是否可以在不更改位置和大小的情况下替换现有 VideoFrame 中的视频？**  

可以。您可以在保持形状几何属性不变的情况下，替换帧内的 [视频内容](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/set_embeddedvideo/)，这在更新已有布局的媒体时非常常见。  

**是否可以确定嵌入视频的内容类型（MIME）？**  

可以。嵌入视频具有可读取的 [内容类型](https://reference.aspose.com/slides/cpp/aspose.slides/video/get_contenttype/)，您可以在保存到磁盘等场景中使用它。