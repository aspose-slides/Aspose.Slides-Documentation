---
title: 使用 Node.js 管理演示文稿中的视频帧
linktitle: 视频帧
type: docs
weight: 10
url: /zh/nodejs-java/video-frame/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "学习如何使用 Aspose.Slides for Node.js via Java，以编程方式在 PowerPoint 和 OpenDocument 幻灯片中添加和提取视频帧。快速指南。"
---
## **介绍**

视频可以帮助解释概念并吸引观众。Aspose.Slides for Node.js via Java 让您可以向幻灯片添加视频帧、调整播放设置、管理字幕以及提取嵌入式视频数据。

PowerPoint 支持本地视频以及指向在线视频（例如 YouTube 视频）的链接。

为了表示视频数据和视频帧，Aspose.Slides 提供了 [Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/) 类、[VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) 类以及其他相关类型。

## **创建嵌入式视频帧**

如果要添加到幻灯片的视频文件存储在本地，您可以创建视频帧将视频嵌入到演示文稿中。

此示例在现有演示文稿的第一张幻灯片中嵌入本地视频并保存结果。帧的坐标和尺寸以点为单位。流会保持打开状态直至保存完成，因为 [LoadingStreamBehavior.KeepLocked](https://reference.aspose.com/slides/nodejs-java/aspose.slides/loadingstreambehavior/) 在演示文稿使用时会保持锁定。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    const videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    try {
        const slide = presentation.getSlides().get_Item(0);

        const video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        slide.getShapes().addVideoFrame(10, 10, 150, 250, video);

        presentation.save("embedded_video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        videoStream.close();
    }
} finally {
    presentation.dispose();
}
```

您也可以直接将本地视频路径传递给 [addVideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addvideoframe/)。此示例在新演示文稿的第一张幻灯片中嵌入视频。视频必须在演示文稿保存之前保持可访问。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    slide.getShapes().addVideoFrame(50, 150, 300, 150, "video.avi");

    presentation.save("video_from_path.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **创建来自网络来源的视频帧**

Microsoft [PowerPoint](https://support.microsoft.com/en-us/powerpoint/training/insert-a-video-from-youtube-or-another-site) 支持在演示文稿中使用在线视频。您可以创建一个链接到在线视频（例如 YouTube 视频）的视频帧。

此示例向第一张幻灯片添加 YouTube 视频链接和缩略图。替换视频标识符即可使用其他视频。[setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) 方法请求自动播放。下载缩略图和播放视频需要互联网访问。演示文稿查看器也必须支持在线视频播放。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoId = "aqz-KE-bpKQ";
    const videoUrl = "https://www.youtube.com/embed/" + videoId;
    const videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    const thumbnailUrl = "https://img.youtube.com/vi/" + videoId + "/hqdefault.jpg";
    const thumbnailLocation = java.newInstanceSync("java.net.URL", thumbnailUrl);
    const thumbnailStream = thumbnailLocation.openStream();
    try {
        const thumbnail = presentation.getImages().addImage(thumbnailStream);
        videoFrame.getPictureFormat().getPicture().setImage(thumbnail);
    } finally {
        thumbnailStream.close();
    }

    presentation.save("online_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **全屏播放视频**

在培训演示中，您可以全屏播放软件演示，让观众看到细节。将 `true` 传递给 [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) 即可在播放期间启用此行为。

此示例打开一个演示文稿，查找第一张幻灯片上的第一个 [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/)，并启用全屏播放。输入演示文稿必须至少包含一张幻灯片，其中第一张幻灯片上已有视频帧。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setFullScreenMode(true);
            break;
        }
    }

    presentation.save("full_screen_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

全屏播放控制视频的显示方式。独立于此，[setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) 控制是自动开始还是点击开始，而 [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) 控制是否循环。要选择启动行为，请将播放模式设置为 [VideoPlayModePreset.Auto or VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/)。示例保留了现有的启动和循环设置。

## **播放后倒退视频**

在培训演示中，将演示视频倒回到开头可以让演讲者再次播放它。将 `true` 传递给 [setRewindVideo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setrewindvideo/) 即可在播放结束后将视频返回到开头。

此示例打开一个演示文稿，查找第一张幻灯片上的第一个 [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/)，并启用倒退。它禁用循环以便播放能够结束，并将播放设置为点击开始。输入演示文稿必须至少包含一张幻灯片，其中第一张幻灯片上已有视频帧。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("training.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            videoFrame.setRewindVideo(true);
            videoFrame.setPlayLoopMode(false);
            videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.OnClick);
            break;
        }
    }

    presentation.save("rewind_video.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

倒退会将视频返回到开头而不重新启动。相反，将 [setPlayLoopMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/) 设置为 `true` 会自动循环播放。当您希望视频播放结束后保持就绪状态时，请保持循环关闭。[setPlayMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/) 独立控制自动或点击启动；本示例使用 [VideoPlayModePreset.OnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoplaymodepreset/) 让演讲者自行决定何时开始播放。请先设置循环选项，再设置播放模式，如示例所示。倒退独立于 [setFullScreenMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setfullscreenmode/) 工作。

## **裁剪视频帧**

使用 [VideoFrame.setTrimFromStart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromstart/) 和 [VideoFrame.setTrimFromEnd](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/settrimfromend/) 可以在播放时跳过视频开头或结尾的部分。两者的值以毫秒为单位。裁剪会更改播放设置，而不会修改嵌入式视频数据。

**设置裁剪参数**

此示例嵌入本地视频，并在播放时跳过前 2.5 秒和最后 1 秒。请使用时长超过 3.5 秒的视频，以确保仍有可播放的片段。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(50, 50, 640, 360, video);
    videoFrame.setTrimFromStart(2500);
    videoFrame.setTrimFromEnd(1000);

    presentation.save("video_with_trim.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**读取裁剪参数**

此示例以毫秒为单位打印第一张幻灯片上第一个视频帧的裁剪值。演示文稿必须至少包含一张幻灯片。如果该幻灯片没有视频帧，则不会输出任何内容。前面的示例会产生 2500 和 1000 两个值。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("video_with_trim.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            console.log("Trim from start: " + videoFrame.getTrimFromStart() + " ms");
            console.log("Trim from end: " + videoFrame.getTrimFromEnd() + " ms");
            break;
        }
    }
} finally {
    presentation.dispose();
}
```

## **管理视频字幕**

Aspose.Slides 允许您管理 PowerPoint 演示文稿中视频帧的隐藏字幕。字幕以 WebVTT 格式存储，并通过 [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) 方法公开。

**向视频帧添加字幕**

此示例嵌入本地视频并添加一个标记为 English 的 WebVTT 字幕轨道。字幕时间戳应与视频匹配。保存的演示文稿将同时包含视频及其字幕。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoBuffer = fs.readFileSync("video.mp4");
    const videoData = java.newArray("byte", Array.from(videoBuffer));
    const video = presentation.getVideos().addVideo(videoData);

    const videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[CaptionsCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/) 类还提供了 [addFromStream](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#addFromStream) 方法，以便从流中添加字幕。

**从视频帧中提取字幕**

此示例将第一张幻灯片上所有视频帧的字幕轨道保存为单独的 WebVTT 文件。使用顺序编号保持输出文件的区别。控制台会报告提取的轨道数量。演示文稿必须至少包含一张幻灯片。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    let trackCount = 0;
    for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
        const shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            const videoFrame = shape;
            for (let trackIndex = 0; trackIndex < videoFrame.getCaptionTracks().getCount(); trackIndex++) {
                const captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                trackCount++;
                const outputPath = "captions_" + trackCount + ".vtt";
                const outputData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
            }
        }
    }

    console.log("Caption tracks extracted: " + trackCount);
} finally {
    presentation.dispose();
}
```

每个 [Captions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captions/) 对象都公开字幕标识符、标签、二进制数据以及以 UTF-8 字符串形式的字幕文本。

**从视频帧中移除字幕**

此示例移除第一张幻灯片上第一个形状位置处视频帧的所有字幕并保存结果。它假设该幻灯片和形状存在且该形状是视频帧。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const videoFrame = slide.getShapes().get_Item(0);
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

如果只需移除单个字幕轨道，请使用 [remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#remove) 或 [removeAt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#removeAt) 方法，而不是 [clear](https://reference.aspose.com/slides/nodejs-java/aspose.slides/captionscollection/#clear)。

## **从幻灯片中提取视频**

除了向幻灯片添加视频，Aspose.Slides 还允许您提取嵌入在演示文稿中的视频。

此示例将每张幻灯片中嵌入的视频提取为单独的、编号的二进制文件。链接视频会被跳过，因为它们没有嵌入数据。控制台会打印每个视频的 MIME 类型以及总数。输出使用通用的 `.bin` 扩展名，如有需要可根据报告的媒体类型进行更改。

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

const presentation = new aspose.slides.Presentation("presentation_with_videos.pptx");
try {
    let videoCount = 0;
    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                const videoFrame = shape;
                const video = videoFrame.getEmbeddedVideo();
                if (video == null) {
                    console.log("Skipped a linked video: no embedded data is available.");
                    continue;
                }

                videoCount++;
                const outputPath = "extracted_video_" + videoCount + ".bin";
                const outputData = Buffer.from(video.getBinaryData());
                fs.writeFileSync(outputPath, outputData);
                console.log("Video " + videoCount + ": " + video.getContentType());
            }
        }
    }

    console.log("Embedded videos extracted: " + videoCount);
} finally {
    presentation.dispose();
}
```

## **常见问题**

**可以更改视频帧的哪些播放参数？**

您可以通过 [VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/) 对象的方法控制 [playback mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/)（自动或点击）以及 [looping](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/)。这些选项均通过相应的方法提供。

**添加视频会影响 PPTX 文件大小吗？**

会的。当您嵌入本地视频时，二进制数据会包含在文档中，演示文稿的大小会随视频文件大小成比例增长。当您链接到在线视频并添加缩略图时，演示文稿仅存储链接和预览图像，而不是视频数据，因而大小增幅通常较小。

**我能在不改变位置和尺寸的前提下替换已有视频帧中的视频吗？**

可以。您可以在保持形状几何属性不变的情况下，使用 [video content](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/) 替换帧内的视频，这是更新已有布局中媒体的常见场景。

**能否确定嵌入视频的内容类型（MIME）？**

可以。嵌入的视频具有可读取的 [content type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/)，您可以在需要时（例如保存到磁盘时）使用它。