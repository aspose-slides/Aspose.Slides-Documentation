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
description: "学习如何使用 Aspose.Slides for Android（Java）以编程方式在 PowerPoint 和 OpenDocument 幻灯片中添加和提取视频帧。快速使用指南。"
---
## **介绍**

在演示文稿中恰当地放置视频可以使您的信息更具说服力并提升观众的参与度。

PowerPoint 允许您以两种方式向演示文稿的幻灯片添加视频：

* 添加或嵌入本地视频（存储在您的计算机上）
* 添加在线视频（来自如 YouTube 等网络来源）。

为了让您能够向演示文稿添加视频（视频对象），Aspose.Slides 提供了 [IVideo](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideo/) 接口、[IVideoFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideoframe/) 接口以及其他相关类型。

## **创建嵌入式视频帧**

如果您要添加到幻灯片的视频文件存储在本地，您可以创建视频帧以在演示文稿中嵌入该视频。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加一个 [IVideo](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideo/) 对象，并传入视频文件路径以将视频嵌入演示文稿。
4. 添加一个 [IVideoFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideoframe/) 对象，以为视频创建帧。
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

或者，您可以将文件路径直接传递给 [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-) 方法来添加视频：

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

Microsoft 较新版本的 [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 支持在演示文稿中使用在线视频。如果您想使用的视频可以在线获取（例如 YouTube），您可以通过其网络链接将其添加到演示文稿中。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation) 类的实例。
2. 通过索引获取幻灯片的引用。
3. 添加一个 [IVideo](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideo/) 对象，并传入视频链接。
4. 为视频帧设置缩略图。
5. 保存演示文稿。

下面的 Java 代码演示了如何将来自网络的视频添加到 PowerPoint 演示文稿的幻灯片中：

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
    // 添加一个视频帧
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

## **裁剪视频帧**

Aspose.Slides 允许您通过 [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) 和 [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) 设置 trim-from-start 和 trim-from-end 值，以控制播放视频的哪一部分。这两个值以毫秒为单位，分别定义从视频开始和结束跳过的时间。这些设置更改演示文稿中视频的播放设置；它们不会剪切或以其他方式修改嵌入视频的二进制数据。

**设置裁剪参数**

创建视频帧并设置其裁剪参数的步骤如下：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 类的实例。
2. 向演示文稿添加一个 [IVideo](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideo/) 对象。
3. 向幻灯片添加一个 [IVideoFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideoframe/) 对象。
4. 通过 [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) 和 [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) 设置 trim-from-start 和 trim-from-end 值。
5. 保存修改后的演示文稿。

下面的代码示例在播放时跳过嵌入视频的前 2.5 秒和最后 1 秒：

```java
Presentation presentation = new Presentation();
try {
    FileInputStream videoStream = new FileInputStream("video.mp4");
    try {
        IVideo video = presentation.getVideos().addVideo(
                videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
        ISlide slide = presentation.getSlides().get_Item(0);
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);

        videoFrame.setTrimFromStart(2500f);
        videoFrame.setTrimFromEnd(1000f);

        presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

**读取裁剪参数**

要检查现有的裁剪参数，加载演示文稿，在第一张幻灯片的形状中找到 [IVideoFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideoframe/) 对象，并通过 [IVideoFrame.getTrimFromStart](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideoframe/#getTrimFromStart--) 和 [IVideoFrame.getTrimFromEnd](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideoframe/#getTrimFromEnd--) 读取相应的值。

下面的代码示例查找第一张幻灯片上的第一个视频帧，并以毫秒为单位报告其裁剪参数：

```java
Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            float trimFromStart = videoFrame.getTrimFromStart();
            float trimFromEnd = videoFrame.getTrimFromEnd();

            System.out.println("Trim from start: " + trimFromStart + " ms");
            System.out.println("Trim from end: " + trimFromEnd + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **管理视频字幕**

Aspose.Slides 允许您管理 PowerPoint 演示文稿中视频帧的闭合字幕。字幕以 WebVTT 格式存储，并通过 [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) 方法提供。

**向视频帧添加字幕**

向视频帧添加字幕的步骤如下：

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/presentation/) 类的实例。
2. 向演示文稿添加视频。
3. 向幻灯片添加一个 [IVideoFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideoframe/) 对象。
4. 使用由 [getCaptionTracks](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) 返回的 [ICaptionsCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icaptionscollection/) 添加 WebVTT 字幕轨道。
5. 保存修改后的演示文稿。

下面的代码演示了如何向视频帧添加字幕：

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

[ICaptionsCollection](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icaptionscollection/) 接口还提供了一个重载，可让您从流中添加字幕。

**从视频帧提取字幕**

从视频帧提取字幕的步骤如下：

1. 加载包含该视频的演示文稿。
2. 找到目标 [IVideoFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideoframe/) 对象。
3. 遍历 [getCaptionTracks](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) 返回的字幕轨道。
4. 将每个字幕轨道保存为 `.vtt` 文件。

下面的代码演示了如何从视频帧提取字幕：

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                // 将字幕轨道保存为 WebVTT 文件。
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

每个 [ICaptions](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icaptions/) 对象都会公开字幕标识符、标签、二进制数据以及作为 UTF-8 字符串的字幕内容。

**删除视频帧字幕**

删除视频帧字幕的步骤如下：

1. 加载包含该视频的演示文稿。
2. 获取目标 [IVideoFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideoframe/) 对象。
3. 从 [getCaptionTracks](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) 返回的集合中移除字幕轨道。
4. 保存修改后的演示文稿。

下面的代码演示了如何删除视频帧中的所有字幕：

```java
Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);

    // 删除视频帧中的所有字幕。
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

如果只需要删除单个字幕轨道，请使用 [remove](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icaptionscollection/#remove-com.aspose.slides.ICaptions-) 或 [removeAt](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icaptionscollection/#removeAt-int-) 方法，而不是 [clear](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/icaptionscollection/#clear--)。

## **从幻灯片提取视频**

除了向幻灯片添加视频，Aspose.Slides 还允许您提取嵌入在演示文稿中的视频。

1. 创建一个 [Presentation](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/Presentation) 类的实例，以加载包含视频的演示文稿。
2. 遍历所有 [ISlide](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/islide/) 对象。
3. 遍历所有 [IShape](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/ishape/) 对象，查找 [VideoFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/videoframe/)。
4. 将视频保存到磁盘。

下面的 Java 代码演示了如何提取演示文稿幻灯片上的视频：

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

**可以更改 VideoFrame 的哪些视频播放参数？**

您可以通过 [VideoFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/videoframe/) 对象的属性控制 [playback mode](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-)（自动或单击）和 [looping](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-)（循环）。这些选项可通过 [VideoFrame](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/videoframe/) 对象的属性进行设置。

**添加视频会影响 PPTX 文件大小吗？**

是的。嵌入本地视频时，二进制数据会写入文档，导致演示文稿大小按视频文件大小成比例增长。添加在线视频时，仅嵌入链接和缩略图，文件大小的增长相对较小。

**我可以在不更改位置和大小的情况下替换现有 VideoFrame 中的视频吗？**

可以。您可以在保持形状几何属性不变的情况下，替换框架内的 [video content](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-)，这在更新现有布局中的媒体时非常常见。

**可以确定嵌入视频的内容类型（MIME）吗？**

可以。嵌入的视频具有可读取的 [content type](https://reference.aspose.com/slides/zh/androidjava/com.aspose.slides/video/#getContentType--)，您可以在保存到磁盘等场景中使用该信息。