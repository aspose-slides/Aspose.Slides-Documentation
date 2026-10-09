---
title: 使用 Java 在演示文稿中管理视频帧
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
description: "学习使用 Aspose.Slides for Java 在 PowerPoint 和 OpenDocument 幻灯片中以编程方式添加和提取视频帧。快速实用指南。"
---
## **介绍**

视频可以帮助解释概念并吸引受众。Aspose.Slides for Java 允许您向幻灯片添加视频帧、调整播放设置、管理字幕并提取嵌入的视频数据。

PowerPoint 支持本地视频和指向在线视频（如 YouTube 视频）的链接。

为了表示视频数据和视频帧，Aspose.Slides 提供了 [IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/) 接口、[IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/) 接口以及其他相关类型。

## **创建嵌入式视频帧**

如果要添加到幻灯片的视频文件存储在本地，您可以创建视频帧将视频嵌入到演示文稿中。

此示例将在现有演示文稿的第一张幻灯片上嵌入本地视频并保存结果。帧的坐标和尺寸单位为点。流会保持打开状态直到保存完成，因为 [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/java/com.aspose.slides/loadingstreambehavior/) 在演示文稿使用时会保持锁定。

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

您也可以直接将本地视频路径传递给 [addVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-java.lang.String-)。此示例将在新演示文稿的第一张幻灯片上嵌入视频。视频必须在演示文稿保存之前保持可访问。

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

## **使用来自网络源的视频创建视频帧**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 在演示文稿中支持在线视频。您可以创建一个链接到在线视频（例如 YouTube 视频）的视频帧。

此示例向第一张幻灯片添加 YouTube 视频链接和缩略图。更换视频标识符即可使用其他视频。[setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setPlayMode-int-) 方法请求自动播放。下载缩略图和播放视频需要互联网连接。演示文稿查看器还必须支持在线视频播放。

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

## **在全屏模式下播放视频**

在培训演示中，您可以以全屏模式播放软件演示，以便观众看到细节。调用 [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-) 并传入 `true` 可在播放期间启用此行为。

此示例打开一个演示文稿，查找第一张幻灯片上的第一个 [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/)，并启用全屏播放。输入的演示文稿必须至少在第一张幻灯片上包含一个已有的视频帧。

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

全屏播放控制视频的显示方式。除此之外，[setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) 决定视频是自动开始还是点击启动，[setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) 决定是否循环播放。要选择启动行为，请将播放模式设置为 [VideoPlayModePreset.Auto 或 VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/)。示例保留了已有的启动和循环设置。

## **播放后倒回视频**

在培训演示中，将演示视频倒回到开头可使演示者再次播放。调用 [setRewindVideo](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setRewindVideo-boolean-) 并传入 `true`，可在播放结束后将视频返回到开头。

此示例打开一个演示文稿，查找第一张幻灯片上的第一个 [IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/)，并启用倒回。它关闭循环以便播放能结束，并将播放设置为点击启动。输入的演示文稿必须至少在第一张幻灯片上包含一个已有的视频帧。

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

倒回会将视频返回到开头而不重新启动。相反，调用 [setPlayLoopMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) 并传入 `true` 会自动循环播放。当您希望视频播放完毕并保持可重新播放时，请保持循环关闭。[setPlayMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-) 独立控制自动或点击启动；本示例使用 [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/java/com.aspose.slides/videoplaymodepreset/) 让演示者决定何时开始播放。如示例所示，先设置循环后再设置播放模式。倒回功能独立于 [setFullScreenMode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setFullScreenMode-boolean-)。

## **剪辑视频帧**

使用 [IVideoFrame.setTrimFromStart](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromStart-float-) 和 [IVideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#setTrimFromEnd-float-) 可以在播放期间跳过视频的开头或结尾部分。两个值的单位都是毫秒。剪辑会更改播放设置，但不修改嵌入的视频数据。

**设置剪辑参数**

此示例嵌入本地视频，并在播放时跳过前 2.5 秒和最后 1 秒。请使用时长超过 3.5 秒的视频，以确保仍有可播放的片段。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500f);
    videoFrame.setTrimFromEnd(1000f);

    presentation.save("video_with_trim.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**读取剪辑参数**

此示例以毫秒为单位打印第一张幻灯片上第一个视频帧的剪辑值。演示文稿必须至少包含一张幻灯片。如果该幻灯片没有视频帧，则不会输出。前面的示例产生的值为 2500 和 1000。

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

Aspose.Slides 允许您管理 PowerPoint 演示文稿中视频帧的闭合字幕。字幕以 WebVTT 格式存储，并可通过 [IVideoFrame.getCaptionTracks](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/#getCaptionTracks--) 方法获取。

**向视频帧添加字幕**

此示例嵌入本地视频并添加一个标记为 English 的 WebVTT 字幕轨道。字幕时间戳应与视频匹配。保存的演示文稿同时包含视频及其字幕。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    Path videoPath = Paths.get("video.mp4");
    byte[] videoData = Files.readAllBytes(videoPath);
    IVideo video = presentation.getVideos().addVideo(videoData);

    IVideoFrame videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[ICaptionsCollection](https://reference.aspose.com/slides/java/com.aspose.slides/icaptionscollection/) 接口还提供了一个重载，可让您从流中添加字幕。

**从视频帧提取字幕**

此示例将第一张幻灯片上所有视频帧的字幕轨道保存为单独的 WebVTT 文件。使用顺序编号保持输出文件的唯一性。控制台会报告提取的轨道数量。演示文稿必须至少包含一张幻灯片。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("video_with_captions.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int trackCount = 0;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IVideoFrame) {
            IVideoFrame videoFrame = (IVideoFrame) shape;
            for (ICaptions captionTrack : videoFrame.getCaptionTracks()) {
                trackCount++;
                Path outputPath = Paths.get("captions_" + trackCount + ".vtt");
                Files.write(outputPath, captionTrack.getBinaryData());
            }
        }
    }

    System.out.println("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

每个 [ICaptions](https://reference.aspose.com/slides/java/com.aspose.slides/icaptions/) 对象公开字幕标识符、标签、二进制数据以及以 UTF-8 字符串形式的字幕文本。

**从视频帧移除字幕**

此示例移除第一张幻灯片上第一形状位置的视频帧中的所有字幕并保存结果。它假设幻灯片和形状均存在且该形状为视频帧。

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

如果只需移除单个字幕轨道，请使用 [remove](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#remove-com.aspose.slides.ICaptions-) 或 [removeAt](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#removeAt-int-) 方法，而不是 [clear](https://reference.aspose.com/slides/java/com.aspose.slides/captionscollection/#clear--)。

## **从幻灯片提取视频**

除了向幻灯片添加视频，Aspose.Slides 还允许您提取演示文稿中嵌入的视频。

此示例将每张幻灯片中的嵌入视频提取为单独的、编号的二进制文件。链接视频会被跳过，因为它们没有嵌入数据。控制台会打印每个视频的 MIME 类型以及总计数。输出使用通用的 `.bin` 扩展名；如有需要请更改为对应的媒体类型。

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

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
                Path outputPath = Paths.get("extracted_video_" + videoCount + ".bin");
                Files.write(outputPath, video.getBinaryData());
                System.out.println("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    System.out.println("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **常见问题**

**可以更改视频帧的哪些播放参数？**

您可以通过 [playback mode](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-)（自动或点击）和 [looping](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-) 来控制。可通过 [VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/) 对象的方法访问这些选项。

**添加视频会影响 PPTX 文件大小吗？**

会。嵌入本地视频时，二进制数据会包含在文档中，导致演示文稿大小按视频文件大小成比例增长。链接到在线视频并添加缩略图时，演示文稿只存储链接和预览图像，而不是视频数据，大小增幅通常较小。

**我可以在不更改位置和尺寸的情况下替换现有视频帧中的视频吗？**

可以。您可以在保持形状几何属性不变的情况下交换帧内的 [video content](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-) ，这在更新已有布局中的媒体时很常见。

**可以确定嵌入视频的内容类型（MIME）吗？**

可以。嵌入的视频拥有一个可读取的 [content type](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--) ，例如在保存到磁盘时可以使用。