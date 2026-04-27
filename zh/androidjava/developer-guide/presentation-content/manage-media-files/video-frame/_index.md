---
title: 在 Android 上管理演示文稿中的视频帧
linktitle: 视频帧
type: docs
weight: 10
url: /zh/androidjava/video-frame/
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
- Android
- Java
- Aspose.Slides
description: "学习如何使用 Aspose.Slides for Android（通过 Java）以编程方式在 PowerPoint 和 OpenDocument 幻灯片中添加和提取视频帧。快速使用指南。"
---
在演示文稿中恰当地放置视频可以使您的信息更具说服力，并提升观众的参与度。

PowerPoint 提供了两种方式将视频添加到幻灯片中：

* 添加或嵌入本地视频（存储在您的计算机上）
* 添加在线视频（例如来自 YouTube 的视频）

为帮助您向演示文稿添加视频（视频对象），Aspose.Slides 提供了 [IVideo](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideo/) 接口、[IVideoFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideoframe/) 接口以及其他相关类型。

## **创建嵌入式视频帧**

如果要添加到幻灯片的视频文件存储在本地，您可以创建视频帧将视频嵌入到演示文稿中。

1. 创建 [Presentation ](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加一个 [IVideo](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideo/) 对象，并传入视频文件路径以将视频嵌入演示文稿。
4. 添加一个 [IVideoFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideoframe/) 对象，以创建视频的帧。
5. 保存修改后的演示文稿。

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

或者，您也可以直接将文件路径传递给 [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) 方法来添加视频：

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **使用网页源视频创建视频帧**

Microsoft [PowerPoint 2013 and newer](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) 支持在演示文稿中嵌入 YouTube 视频。如果您要使用的视频可在网上获取（例如 YouTube），可以通过其网页链接将其添加到演示文稿中。

1. 创建 [Presentation ](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加一个 [IVideo](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideo/) 对象，并传入视频链接。
4. 为视频帧设置缩略图。
5. 保存演示文稿。

下面的 Java 代码演示了如何将网络视频添加到 PowerPoint 幻灯片中：

```java
// 实例化一个表示演示文稿文件的 Presentation 对象
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

Aspose.Slides 允许您管理 PowerPoint 演示文稿中视频帧的闭合字幕。字幕以 WebVTT 格式存储，并通过 [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) 方法公开。

**向视频帧添加字幕**

要向视频帧添加字幕：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 类的实例。
2. 将视频添加到演示文稿中。
3. 向幻灯片添加一个 [IVideoFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideoframe/) 对象。
4. 使用由 [getCaptionTracks](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) 返回的 [ICaptionsCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icaptionscollection/) 添加 WebVTT 字幕轨道。
5. 保存修改后的演示文稿。

以下代码演示了如何向视频帧添加字幕：

```java
Presentation presentation = new Presentation();
try {
    byte[] videoData = // "video.mp4";
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

[ICaptionsCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icaptionscollection/) 接口还提供了一个重载，允许您从流中添加字幕。

**从视频帧提取字幕**

要从视频帧提取字幕：

1. 加载包含视频的演示文稿。
2. 找到目标的 [IVideoFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideoframe/) 对象。
3. 遍历 [getCaptionTracks](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) 返回的字幕轨道。
4. 将每个字幕轨道保存为 `.vtt` 文件。

以下代码演示了如何从视频帧提取字幕：

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // 保存字幕轨道为 WebVTT 文件。
                FileOutputStream outputStream = new FileOutputStream(captionTrack.getCaptionId() + ".vtt");
                outputStream.write(captionTrack.getBinaryData());
                outputStream.close();
            }
        }
    }
} finally {
    presentation.dispose();
}
```

每个 [ICaptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icaptions/) 对象都公开字幕标识符、标签、二进制数据以及作为 UTF-8 字符串的字幕内容。

**从视频帧移除字幕**

要从视频帧移除字幕：

1. 加载包含视频的演示文稿。
2. 获取目标的 [IVideoFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideoframe/) 对象。
3. 从由 [getCaptionTracks](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) 返回的集合中移除字幕轨道。
4. 保存修改后的演示文稿。

以下代码演示了如何移除视频帧中的所有字幕：

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // 移除视频帧中的所有字幕。
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

如果仅需移除单个字幕轨道，请使用 [remove](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) 或 [removeAt](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) 方法，而不是 [clear](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icaptionscollection/#clear--)。

## **从幻灯片中提取视频**

除了向幻灯片添加视频，Aspose.Slides 还允许您提取嵌入在演示文稿中的视频。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation) 类的实例以加载包含视频的演示文稿。
2. 遍历所有 [ISlide](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islide/) 对象。
3. 遍历所有 [IShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/) 对象以查找 [VideoFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/videoframe/)。
4. 将视频保存到磁盘。

下面的 Java 代码演示了如何提取演示文稿幻灯片中的视频：

```java
// 实例化一个表示演示文稿文件的 Presentation 对象 
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

                //获取文件扩展名
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

**可以更改 VideoFrame 的哪些视频播放参数？**

您可以控制 [playback mode](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-)（自动或点击）和 [looping](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-)。这些选项通过 [VideoFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/videoframe/) 对象的属性提供。

**添加视频会影响 PPTX 文件大小吗？**

会的。嵌入本地视频时，二进制数据会被包含在文档中，文件大小会随视频文件大小等比例增长。添加在线视频时，仅嵌入链接和缩略图，大小增幅相对较小。

**能否在不更改位置和尺寸的情况下替换已有 VideoFrame 中的视频？**

可以。您可以在保持形状几何属性不变的情况下，使用 [setEmbeddedVideo](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) 方法替换帧内的视频内容，这在更新已有布局的媒体时很常见。

**能否确定嵌入视频的内容类型（MIME）？**

可以。嵌入的视频具有可读取的 [content type](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/video/#getContentType--)，您可以根据需要使用它，例如在保存到磁盘时。