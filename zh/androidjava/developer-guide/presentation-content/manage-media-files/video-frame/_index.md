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
description: "学习使用 Aspose.Slides for Android via Java 在 PowerPoint 和 OpenDocument 幻灯片中以编程方式添加和提取视频帧。快速实用指南。"
---
## **介绍**

视频可以帮助解释概念并吸引受众。Aspose.Slides for Android via Java 允许您向幻灯片添加视频帧、调整播放设置、管理字幕并提取嵌入的视频数据。

PowerPoint 支持本地视频和指向在线视频的链接，例如 YouTube 视频。

为了表示视频数据和视频帧，Aspose.Slides 提供了 [IVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideo/) 接口、[IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/) 接口以及其他相关类型。

## **创建嵌入式视频帧**

如果您要添加到幻灯片的视频文件存储在本地，您可以创建视频帧将视频嵌入到演示文稿中。

此示例在现有演示文稿的第一张幻灯片上嵌入本地视频并保存结果。帧坐标和尺寸使用点 (points) 为单位。由于 [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadingstreambehavior/) 在演示文稿使用期间保持流锁定，流会保持打开，直到保存完成。

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation("presentation.pptx");
try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.KeepLocked);
    slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

    presentation.save("embedded_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

您也可以直接将本地视频路径传递给 [addVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-)。此示例在新演示文稿的第一张幻灯片上嵌入视频。视频必须保持可访问，直到演示文稿保存完成。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **使用来自网络来源的视频创建视频帧**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 在演示文稿中支持在线视频。您可以创建指向在线视频（例如 YouTube 视频）的视频帧。

此示例向第一张幻灯片添加 YouTube 视频链接和缩略图。替换视频标识符即可使用其他视频。[setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setPlayMode-int-) 方法请求自动播放。下载缩略图和播放视频需要互联网访问。演示文稿查看器还必须支持在线视频播放。

```java
import com.aspose.slides.*;
import java.io.InputStream;
import java.net.URL;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    String videoId = "aqz-KE-bpKQ";
    String videoUrl = "https://www.youtube.com/embed/" + videoId;
    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(VideoPlayModePreset.Auto);

    String thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    URL thumbnailLocation = new URL(thumbnailUrl);
    try (InputStream thumbnailStream = thumbnailLocation.openStream()) {
        IPPImage thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    }

    presentation.save("online_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **全屏播放视频**

在培训演示文稿中，您可以以全屏模式播放软件演示，以便观众看到细节。使用 `true` 调用 [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) 可在播放期间启用此行为。

此示例打开演示文稿，查找第一张幻灯片上的第一个 [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/)，并启用全屏播放。输入演示文稿必须至少包含一张幻灯片，在其第一张幻灯片上已有视频帧。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

全屏播放控制视频的显示方式。除此之外，[setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) 控制是自动播放还是点击播放，而 [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) 控制是否循环播放。要选择启动行为，请将播放模式设为 [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/)。示例保留了现有的启动和循环设置。

## **回放后倒带视频**

在培训演示中，将演示视频返回到起始位置可使演讲者再次播放。使用 `true` 调用 [setRewindVideo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setRewindVideo-boolean-) 可在播放结束后将视频倒回起始位置。

此示例打开演示文稿，查找第一张幻灯片上的第一个 [IVideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/)，并启用倒带。它禁用循环以便播放可以结束，并将播放设置为点击启动。输入演示文稿必须至少包含一张幻灯片，在其第一张幻灯片上已有视频帧。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("training.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

倒带会将视频返回到起始位置，但不会再次启动。相反，使用 `true` 调用 [setPlayLoopMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) 会自动循环播放。希望视频播放完毕后保持可重复播放时，请保持循环关闭。[setPlayMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-) 独立控制自动或点击启动；本示例使用 [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoplaymodepreset/) 使演讲者自行决定何时开始播放。正如示例所示，应在设置循环后再设置播放模式。倒带功能独立于 [setFullScreenMode](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setFullScreenMode-boolean-)。

## **剪辑视频帧**

使用 [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) 和 [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) 可在播放期间跳过视频的开头或结尾部分。两个值的单位均为毫秒。剪辑会更改播放设置，但不会修改嵌入的视频数据。

**设置剪辑参数**

此示例嵌入本地视频，并在播放时跳过前 2.5 秒和最后 1 秒。请使用时长超过 3.5 秒的视频，以确保仍有可播放片段。

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**读取剪辑参数**

此示例以毫秒为单位打印第一张幻灯片上第一个视频帧的剪辑值。演示文稿必须至少包含一张幻灯片。如果该幻灯片没有视频帧，则不会打印任何内容。前面的示例会产生 2500 和 1000 的值。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_trim.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            System.out.println("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            System.out.println("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **管理视频字幕**

Aspose.Slides 允许您管理 PowerPoint 演示文稿中视频帧的隐藏字幕。字幕以 WebVTT 格式存储，并通过 [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ivideoframe/#getCaptionTracks--) 方法公开。

**向视频帧添加字幕**

此示例嵌入本地视频，并添加标记为 English 的 WebVTT 字幕轨。字幕时间戳应与视频匹配。保存的演示文稿同时包含视频及其字幕。

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideo video;
    try (FileInputStream videoStream = new FileInputStream("video.mp4")) {
        video = presentation.getVideos().addVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
    }

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ICaptionsCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptionscollection/) 接口还提供了一个重载，允许您从流中添加字幕。

**从视频帧提取字幕**

此示例将第一张幻灯片上视频帧的所有字幕轨保存为单独的 WebVTT 文件。使用顺序编号可保持输出文件的唯一性。控制台会报告提取的轨道数量。演示文稿必须至少包含一张幻灯片。

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                try (FileOutputStream outputStream = new FileOutputStream("captions_" + trackCount + ".vtt")) {
                    outputStream.write(captionTrack.getBinaryData());
                }
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

每个 [ICaptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icaptions/) 对象都公开字幕标识符、标签、二进制数据以及作为 UTF-8 字符串的字幕文本。

**从视频帧移除字幕**

此示例删除第一张幻灯片上第一个形状位置的视频帧中的所有字幕并保存结果。它假设幻灯片和形状均存在且该形状为视频帧。

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IVideoFrame videoFrame = (IVideoFrame) slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

如果只需移除单个字幕轨道，请使用 [remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) 或 [removeAt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#removeAt-int-) 方法，而不是 [clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/captionscollection/#clear--)。

## **从幻灯片提取视频**

除了向幻灯片添加视频外，Aspose.Slides 还允许您提取演示文稿中嵌入的视频。

此示例将每张幻灯片中的嵌入视频提取为单独的、编号的二进制文件。链接视频会被跳过，因为它们没有嵌入的数据。控制台会打印每个视频的 MIME 类型以及总数量。输出使用通用的 `.bin` 扩展名；如有需要，可将其更改为匹配报告的媒体类型。

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("presentation_with_videos.pptx");
try {
    int videoCount = 0;
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                IVideoFrame videoFrame = (IVideoFrame) shape;
                IVideo video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    System.out.println("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                try (FileOutputStream outputStream = new FileOutputStream("extracted_video_" + videoCount + ".bin")) {
                    outputStream.write(video.getBinaryData());
                }
                System.out.println("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    System.out.println("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**可以更改视频帧的哪些播放参数？**

您可以通过 [VideoFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/) 对象的方法控制[播放模式](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayMode-int-)（自动或点击）和[循环](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-)。

**添加视频会影响 PPTX 文件大小吗？**

是的。当您嵌入本地视频时，二进制数据会包含在文档中，演示文稿的大小会随文件大小成比例增长。当您链接到在线视频并添加缩略图时，演示文稿仅存储链接和预览图像，而不是视频数据，因此大小增加通常较小。

**我能在不更改位置和大小的情况下替换现有视频帧中的视频吗？**

可以。您可以在保持形状几何尺寸不变的情况下替换帧内的[视频内容](https://reference.aspose.com/slides/androidjava/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-)，这在更新现有布局中的媒体时很常见。

**可以确定嵌入视频的内容类型（MIME）吗？**

可以。嵌入的视频具有[内容类型](https://reference.aspose.com/slides/androidjava/com.aspose.slides/video/#getContentType--)，您可以读取并使用，例如在保存到磁盘时。