---
title: 视频帧
type: docs
weight: 10
url: /cpp/video-frame/
keywords: "添加视频，创建视频帧，提取视频，PowerPoint 演示文稿，C++，CPP，Aspose.Slides for C++"
description: "在 C++ 中将视频帧添加到 PowerPoint 演示文稿"

---

在演示文稿中精心放置的视频可以使您的信息更加引人注目并提高与观众的参与度。

PowerPoint 允许您通过两种方式将视频添加到演示文稿的幻灯片中：

* 添加或嵌入本地视频（存储在您的计算机上）
* 添加在线视频（来自于 YouTube 等网络来源）。

为了让您能够将视频（视频对象）添加到演示文稿中，Aspose.Slides 提供了 [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) 接口、[IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) 接口以及其他相关类型。

## **创建嵌入视频帧**

如果您要添加到幻灯片的视频文件存储在本地，您可以创建一个视频帧将视频嵌入到演示文稿中。

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个 [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) 对象并传递视频文件路径以将视频嵌入到演示文稿中。
1. 添加一个 [IVideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/ivideoframe/) 对象以为视频创建一个帧。
1. 保存修改后的演示文稿。

这段 C++ 代码演示了如何将存储在本地的视频添加到演示文稿中：

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx");

// 加载视频
System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(u"Wildlife.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);
System::SharedPtr<IVideo> video = pres->get_Videos()->AddVideo(fileStream, LoadingStreamBehavior::KeepLocked);

// 获取第一张幻灯片并添加视频帧
pres->get_Slide(0)->get_Shapes()->AddVideoFrame(10.0f, 10.0f, 150.0f, 250.0f, video);

// 将演示文稿保存到磁盘
pres->Save(u"pres-with-video.pptx", SaveFormat::Pptx);
```

另外，您可以直接将视频文件路径传递给 [AddVideoFrame()](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addvideoframe/) 方法来添加视频：

``` c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slide(0);
System::SharedPtr<IVideoFrame> vf = sld->get_Shapes()->AddVideoFrame(50.0f, 150.0f, 300.0f, 150.0f, u"video1.avi");
```

## **使用网络来源的视频创建视频帧**

Microsoft [PowerPoint 2013 及更高版本](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) 支持在演示文稿中使用 YouTube 视频。如果您要使用的视频可以在线获取（例如在 YouTube 上），您可以通过其网络链接将其添加到演示文稿中。

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个 [IVideo](https://reference.aspose.com/slides/cpp/aspose.slides/ivideo/) 对象并传递视频链接。
1. 为视频帧设置缩略图。
1. 保存演示文稿。

这段 C++ 代码演示了如何将网络上的视频添加到 PowerPoint 演示文稿中的幻灯片：

```c++
// 文档目录的路径。
const String outPath = u"../out/AddVideoFrameFromWebSource_out.pptx";
const String filePath = u"../templates/video1.avi";

// 实例化代表演示文稿文件的 Presentation 对象
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// 访问第一张幻灯片
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// 添加视频帧
System::SharedPtr<IVideoFrame> vf = slide->get_Shapes()->AddVideoFrame(10, 10, 427, 240,u"https://www.youtube.com/embed/Tj75Arhq5ho");

// 设置视频的播放模式和音量
vf->set_PlayMode(VideoPlayModePreset::Auto);

// 将演示文稿保存到磁盘
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **从幻灯片中提取视频**

除了将视频添加到幻灯片中，Aspose.Slides 还允许您提取嵌入在演示文稿中的视频。

1. 创建 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 类的实例以加载包含视频的演示文稿。
2. 遍历所有 [ISlide](https://reference.aspose.com/slides/cpp/aspose.slides/islide/) 对象。
3. 遍历所有 [IShape](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/) 对象以查找 [VideoFrame](https://reference.aspose.com/slides/cpp/aspose.slides/videoframe/)。
4. 将视频保存到磁盘。

这段 C++ 代码演示了如何提取演示文稿幻灯片上的视频：

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