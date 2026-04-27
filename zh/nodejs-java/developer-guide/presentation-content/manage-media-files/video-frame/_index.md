---
title: 在演示文稿中使用 JavaScript 管理视频帧
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
description: "学习如何使用 Aspose.Slides for Node.js（Java 版）在 PowerPoint 和 OpenDocument 幻灯片中以编程方式添加和提取视频帧。快速操作指南。"
---
在演示文稿中恰当放置视频可以让您的信息更具说服力，并提升与观众的互动程度。

PowerPoint 允许您以两种方式向演示文稿的幻灯片添加视频：

* 添加或嵌入本地视频（存储在您的计算机上）
* 添加在线视频（来自如 YouTube 等网络来源）。

为了让您能够向演示文稿中添加视频（视频对象），Aspose.Slides 提供了 [Video](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/video/) 类、[VideoFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/videoframe/) 类以及其他相关类型。

## **创建嵌入式视频帧**

如果您要添加到幻灯片的视频文件存储在本地，您可以创建视频帧将视频嵌入演示文稿中。

1. 创建 [Presentation ](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation) 类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个 [Video](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/video/) 对象，并传入视频文件路径以将视频嵌入演示文稿。
1. 添加一个 [VideoFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/videoframe/) 对象，以创建视频帧。
1. 保存修改后的演示文稿。

下面的 JavaScript 代码展示了如何将本地存储的视频添加到演示文稿中：

```javascript
// 实例化 Presentation 类
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // 加载视频
    var fileStream = java.newInstanceSync("java.io.FileInputStream", "Wildlife.mp4");
    var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
    // 获取第一张幻灯片并添加视频帧
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);
    // 将演示文稿保存到磁盘
    pres.save("pres-with-video.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

或者，您可以通过将文件路径直接传递给 [addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-) 方法来添加视频：

```javascript
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    var vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **从网络来源创建带视频的帧**

Microsoft [PowerPoint 2013 及更高版本](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us) 支持在演示文稿中使用 YouTube 视频。如果您要使用的视频可以在线获取（例如在 YouTube 上），可以通过其网络链接将其添加到演示文稿中。

1. 创建 [Presentation ](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation) 类的实例
1. 通过索引获取幻灯片的引用。
1. 添加一个 [Video](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/video/) 对象，并传入视频的链接。
1. 为视频帧设置缩略图。
1. 保存演示文稿。

下面的 JavaScript 代码展示了如何将网络视频添加到 PowerPoint 幻灯片中：

```javascript
// 实例化一个表示演示文稿文件的 Presentation 对象
var pres = new aspose.slides.Presentation();
try {
    addVideoFromYouTube(pres, "Tj75Arhq5ho");
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
async function addVideoFromYouTube(pres, videoID) {
    let slide = pres.getSlides().get_Item(0);
    let videoUrl = "https://www.youtube.com/embed/" + videoID;
    let videoFrame = slide.getShapes().addVideoFrame(10, 10, 427, 240, videoUrl);
    
    videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

    let thumbnailUri = "http://img.youtube.com/vi/" + videoID + "/hqdefault.jpg";

    try {
        const imageStream = await getImageStream(thumbnailUri);
        let image = pres.getImages().addImage(imageStream);
        videoFrame.getPictureFormat().getPicture().setImage(image);
    } catch (error) {
        console.error("Error loading thumbnail:", error);
    }
}

async function getImageStream(url) {
    return new Promise((resolve, reject) => {
        http.get(url, (response) => {
            if (response.statusCode === 200) {
                resolve(response);
            } else {
                reject(new Error(`Failed to load image: ${response.statusCode}`));
            }
        }).on('error', (e) => {
            reject(e);
        });
    });
}
```

## **管理视频字幕**

Aspose.Slides 允许您管理 PowerPoint 演示文稿中视频帧的闭合字幕。字幕以 WebVTT 格式存储，并可通过 [VideoFrame.getCaptionTracks](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/videoframe/#getCaptionTracks) 方法获取。

**向视频帧添加字幕**

向视频帧添加字幕的步骤：

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/presentation/) 类的实例。
1. 向演示文稿添加视频。
1. 向幻灯片添加一个 [VideoFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/videoframe/) 对象。
1. 使用 [CaptionsCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/captionscollection/) 集合添加 WebVTT 字幕轨道。
1. 保存修改后的演示文稿。

下面的代码展示了如何向视频帧添加字幕：

```js
let presentation = new aspose.slides.Presentation();
try {
    let videoStream = java.newInstanceSync("java.io.FileInputStream", "video.mp4");
    let video = presentation.getVideos().addVideo(videoStream, aspose.slides.LoadingStreamBehavior.KeepLocked);

    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().addVideoFrame(0, 0, 100, 100, video);

    // 添加一个来自 WebVTT 文件的新字幕轨道。
    videoFrame.getCaptionTracks().add("English", "track.vtt");

    presentation.save("video_with_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

[CaptionsCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/captionscollection/) 类还提供了 [addFromStream](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/captionscollection/#addFromStream) 方法，允许您从流中添加字幕。

**从视频帧中提取字幕**

从视频帧中提取字幕的步骤：

1. 加载包含该视频的演示文稿。
1. 找到目标 [VideoFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/videoframe/) 对象。
1. 遍历 [CaptionsCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/captionscollection/) 集合。
1. 将每个字幕轨道保存为 `.vtt` 文件。

下面的代码展示了如何从视频帧中提取字幕：

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapeCount = slide.getShapes().size();
    for (let shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
        let shape = slide.getShapes().get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
            let videoFrame = shape;
            let trackCount = videoFrame.getCaptionTracks().getCount();
            for (let trackIndex = 0; trackIndex < trackCount; trackIndex++) {
                let captionTrack = videoFrame.getCaptionTracks().get_Item(trackIndex);
                // 将字幕轨道保存为 WebVTT 文件。
                let filePath = captionTrack.getCaptionId() + ".vtt";
                let captionData = Buffer.from(captionTrack.getBinaryData());
                fs.writeFileSync(filePath, captionData);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

每个 [Captions](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/captions/) 对象会公开字幕标识符、标签、二进制数据以及作为 UTF-8 字符串的字幕文本。

**从视频帧中移除字幕**

从视频帧中移除字幕的步骤：

1. 加载包含该视频的演示文稿。
1. 获取目标 [VideoFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/videoframe/) 对象。
1. 从 [CaptionsCollection](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/captionscollection/) 集合中移除字幕轨道。
1. 保存修改后的演示文稿。

下面的代码展示了如何从视频帧中移除所有字幕：

```js
let presentation = new aspose.slides.Presentation("video_with_captions.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let videoFrame = slide.getShapes().get_Item(0); // 类型: com.aspose.slides.VideoFrame

    // 删除视频帧中的所有字幕。
    videoFrame.getCaptionTracks().clear();

    presentation.save("video_without_captions.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

如果只需移除单个字幕轨道，请使用 [remove](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/captionscollection/#remove) 或 [removeAt](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/captionscollection/#removeAt) 方法，而不是 [clear](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/captionscollection/#clear)。

## **从幻灯片提取视频**

除了向幻灯片添加视频，Aspose.Slides 还允许您提取嵌入演示文稿中的视频。

1. 创建 [Presentation](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/Presentation) 类的实例以加载包含视频的演示文稿。
2. 遍历所有 [Slide](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/slide/) 对象。
3. 遍历所有 [Shape](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/shape/) 对象，以查找 [VideoFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/videoframe/)。
4. 将视频保存到磁盘。

下面的 JavaScript 代码展示了如何提取演示文稿幻灯片中的视频：

```javascript
// 实例化一个表示演示文稿文件的 Presentation 对象
var pres = new aspose.slides.Presentation("VideoSample.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let slide = pres.getSlides().get_Item(i);
        for (let j = 0; j < slide.getShapes().size(); j++) {
            let shape = slide.getShapes().get_Item(j);
            if (java.instanceOf(shape, "com.aspose.slides.VideoFrame")) {
                var vf = shape;
                console.log(shape);
                var type = vf.getEmbeddedVideo().getContentType();
                var ss = type.lastIndexOf('-');
                const buffer = Buffer.from(vf.getEmbeddedVideo().getBinaryData());
                console.log(buffer);
                // 获取文件扩展名
                var charIndex = type.indexOf("/");
                type = type.substring(charIndex + 1);
                fs.writeFileSync("testing2." + type, buffer);
            }
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **常见问题**

**可以更改 VideoFrame 的哪些视频播放参数？**  
您可以通过 [VideoFrame](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/videoframe/) 对象的属性控制 [playback mode](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/videoframe/setplaymode/)（自动或点击播放）和 [looping](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/videoframe/setplayloopmode/)。这些选项可通过该对象的属性进行设置。

**添加视频会影响 PPTX 文件大小吗？**  
是的。嵌入本地视频时，二进制数据会被写入文档，导致演示文稿大小按文件大小比例增加。添加在线视频时，只会嵌入链接和缩略图，大小增长较小。

**我能在不改变位置和大小的情况下替换已有 VideoFrame 中的视频吗？**  
可以。您可以在保持形状几何属性不变的情况下，替换帧内的 [video content](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/videoframe/setembeddedvideo/)，这在更新已有布局中的媒体时很常见。

**可以确定嵌入视频的内容类型（MIME）吗？**  
可以。嵌入视频具有可读取的 [content type](https://reference.aspose.com/slides/zh/nodejs-java/aspose.slides/video/getcontenttype/)，例如在保存到磁盘时可以使用该信息。