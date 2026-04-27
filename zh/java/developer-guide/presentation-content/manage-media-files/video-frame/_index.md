---
title: 使用 Java 管理演示文稿中的视频帧
linktitle: 视频帧
type: docs
weight: 10
url: /zh/java/video-frame/
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
- Java
- Aspose.Slides
description: "学习如何使用 Aspose.Slides for Java 在 PowerPoint 和 OpenDocument 幻灯片中以编程方式添加和提取视频帧。快速入门指南。"
---
在演示文稿中恰当地插入视频可以使您的信息更具说服力，并提升观众的参与度。

PowerPoint 允许您通过两种方式向幻灯片添加视频：

* 添加或嵌入本地视频（存储在您的机器上）
* 添加在线视频（来自 YouTube 等网络来源）。

为了让您能够向演示文稿添加视频（视频对象），Aspose.Slides 提供了 [IVideo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ivideo/) 接口、[IVideoFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ivideoframe/) 接口以及其他相关类型。

## **创建嵌入式视频帧**

如果要添加到幻灯片的视频文件存储在本地，您可以创建视频帧将视频嵌入到演示文稿中。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation) 类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 添加一个 [IVideo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ivideo/) 对象并传入视频文件路径，以将视频嵌入演示文稿。  
1. 添加一个 [IVideoFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ivideoframe/) 对象以创建视频帧。  
1. 保存修改后的演示文稿。

下面的 Java 代码演示了如何将本地存储的视频添加到演示文稿中：

```java
// 实例化 Presentation 类
Presentation pres = new Presentation("pres.pptx");
try {
    // 加载视频
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // 获取第一张幻灯片并添加视频帧
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // 将演示文稿保存到磁盘
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

或者，您可以直接将文件路径传递给 [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) 方法：

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **使用网络来源视频创建视频帧**

Microsoft [PowerPoint 2013 及更高版本](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) 支持在演示文稿中使用 YouTube 视频。如果您要使用的视频可以在线获取（例如 YouTube），可以通过其网络链接将其添加到演示文稿中。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation) 类的实例。  
1. 通过索引获取幻灯片的引用。  
1. 添加一个 [IVideo](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ivideo/) 对象并传入视频链接。  
1. 为视频帧设置缩略图。  
1. 保存演示文稿。

下面的 Java 代码演示了如何将网络视频添加到 PowerPoint 幻灯片中：

```java
// 实例化一个代表演示文稿文件的 Presentation 对象
Presentation pres = new Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

```java
private static void addVideoFromYouTube(Presentation pres, String videoID)
{
    // 添加视频帧
    IVideoFrame videoFrame = pres.getSlides().get_Item(0).getShapes().addVideoFrame(
            10, 10, 427, 240, "https://www.youtube.com/embed/" + videoID);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    // 加载缩略图
    String thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";
    URL url;

    try {
        url = new URL(thumbnailUri);
        videoFrame.getPictureFormat().getPicture().setImage(pres.getImages().addImage(url.openStream()));
    } catch (MalformedURLException e) {
        e.printStackTrace();
    } catch (IOException e) {
        e.printStackTrace();
    }
}
```

## **管理视频字幕**

Aspose.Slides 允许您管理 PowerPoint 演示文稿中视频帧的闭合字幕。字幕以 WebVTT 格式存储，并可通过 [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) 方法访问。

**向视频帧添加字幕**

向视频帧添加字幕的步骤：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/presentation/) 类的实例。  
1. 向演示文稿添加视频。  
1. 向幻灯片添加一个 [IVideoFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ivideoframe/) 对象。  
1. 使用 [getCaptionTracks](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) 返回的 [ICaptionsCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/icaptionscollection/) 添加 WebVTT 字幕轨道。  
1. 保存修改后的演示文稿。

以下代码展示了如何向视频帧添加字幕：

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = Files.readAllBytes(Paths.get("video.mp4"));
    IVideo video = presentation.getVideos().addVideo(videoData);

    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // 添加一个来自 WebVTT 文件的新字幕轨道。
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ICaptionsCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/icaptionscollection/) 接口还提供了一个重载，允许您从流中添加字幕。

**从视频帧提取字幕**

从视频帧提取字幕的步骤：

1. 加载包含视频的演示文稿。  
1. 找到目标 [IVideoFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ivideoframe/) 对象。  
1. 遍历 [ICaptionsCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/icaptionscollection/) 中的字幕轨道。  
1. 将每个字幕轨道保存为 `.vtt` 文件。

以下代码展示了如何从视频帧提取字幕：

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame)shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // 将字幕轨道保存为 WebVTT 文件。
                String filePath = captionTrack.getCaptionId().toString() + ".vtt";
                Files.write(Paths.get(filePath), captionTrack.getBinaryData());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

每个 [ICaptions](https://reference.aspose.com/slides/zh/java/com.aspose.slides/icaptions/) 对象都公开了字幕标识符、标签、二进制数据以及以 UTF-8 字符串形式的字幕文本。

**从视频帧移除字幕**

从视频帧移除字幕的步骤：

1. 加载包含视频的演示文稿。  
1. 获取目标 [IVideoFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ivideoframe/) 对象。  
1. 从 [ICaptionsCollection](https://reference.aspose.com/slides/zh/java/com.aspose.slides/icaptionscollection/) 中移除字幕轨道。  
1. 保存修改后的演示文稿。

以下代码展示了如何移除视频帧中的所有字幕：

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame)slide.getShapes().get_Item(0);

    // 删除视频帧中的所有字幕。
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

如果只需要移除单个字幕轨道，请使用 [remove](https://reference.aspose.com/slides/zh/java/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) 或 [removeAt](https://reference.aspose.com/slides/zh/java/com.aspose.slides/icaptionscollection/#removeAt-int-) 方法，而不是 [clear](https://reference.aspose.com/slides/zh/java/com.aspose.slides/icaptionscollection/#clear--)。

## **从幻灯片中提取视频**

除了向幻灯片添加视频，Aspose.Slides 还允许您提取嵌入在演示文稿中的视频。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/java/com.aspose.slides/Presentation) 类的实例以加载包含视频的演示文稿。  
2. 遍历所有 [ISlide](https://reference.aspose.com/slides/zh/java/com.aspose.slides/islide/) 对象。  
3. 遍历所有 [IShape](https://reference.aspose.com/slides/zh/java/com.aspose.slides/ishape/) 对象以查找 [VideoFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/videoframe/)。  
4. 将视频保存到磁盘。

下面的 Java 代码展示了如何从演示文稿幻灯片中提取视频：

```java
// 实例化一个代表演示文稿文件的 Presentation 对象
Presentation pres = new Presentation("VideoSample.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        for (IShape shape : slide.getShapes()) 
        {
            if (shape instanceof VideoFrame) 
            {
                IVideoFrame vf = (IVideoFrame) shape;
                String type = vf.getEmbeddedVideo().getContentType();
                int ss = type.lastIndexOf('-');
                byte[] buffer = vf.getEmbeddedVideo().getBinaryData();

                // 获取文件扩展名
                int charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);

                FileOutputStream fop = new FileOutputStream("testing2." + type);
                fop.write(buffer);
                fop.flush();
                fop.close();
            }
        }
    }
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **常见问题**

**可以更改 VideoFrame 的哪些播放参数？**

您可以控制[播放模式](https://reference.aspose.com/slides/zh/java/com.aspose.slides/videoframe/#setPlayMode-int-)(自动或单击)和[循环](https://reference.aspose.com/slides/zh/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-)。这些选项通过 [VideoFrame](https://reference.aspose.com/slides/zh/java/com.aspose.slides/videoframe/) 对象的属性提供。

**添加视频会影响 PPTX 文件大小吗？**

会的。嵌入本地视频时，二进制数据会被包含在文档中，因而演示文稿大小会按文件大小比例增长。添加在线视频时，只会嵌入链接和缩略图，大小增长相对较小。

**是否可以在不更改位置和大小的情况下替换现有 VideoFrame 中的视频？**

可以。您可以在保持形状几何的前提下替换帧内的[视频内容](https://reference.aspose.com/slides/zh/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-)，这在更新已有布局的媒体时很常见。

**能否确定嵌入视频的内容类型（MIME）？**

可以。嵌入视频拥有可读取的[内容类型](https://reference.aspose.com/slides/zh/java/com.aspose.slides/video/#getContentType--)，您可以在保存到磁盘等场景中使用它。