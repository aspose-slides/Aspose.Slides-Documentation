---
title: 视频帧
type: docs
weight: 10
url: /zh/nodejs-java/video-frame/
keywords: "添加视频, 创建视频帧, 提取视频, PowerPoint 演示文稿, Java, Aspose.Slides for Node.js via Java"
description: "在 JavaScript 中向 PowerPoint 演示文稿添加视频帧"
---

在演示文稿中恰当地放置视频可以使您的信息更具说服力，并提升观众的参与度。

PowerPoint 允许您以两种方式向演示文稿的幻灯片中添加视频：

* 添加或嵌入本地视频（存储在您的计算机上）
* 添加在线视频（来自 YouTube 等网络来源）

为了让您能够向演示文稿中添加视频（视频对象），Aspose.Slides 提供了[Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/)类、[VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/)类以及其他相关类型。

## **创建嵌入式视频帧**

如果您要添加到幻灯片的视频文件存储在本地，可以创建视频帧将视频嵌入到演示文稿中。

1. 创建一个[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加一个[Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/)对象，并传入视频文件路径以将视频嵌入演示文稿。  
4. 添加一个[VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/)对象来创建视频的框架。  
5. 保存修改后的演示文稿。  

下面的 JavaScript 代码示例展示了如何将本地存储的视频添加到演示文稿中：
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


或者，您也可以直接将文件路径传递给[addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addVideoFrame-float-float-float-float-aspose.slides.IVideo-)方法来添加视频：
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


## **创建来自网页源的视频帧**

Microsoft [PowerPoint 2013 及更高版本](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us)支持在演示文稿中插入 YouTube 视频。如果您要使用的视频可以在网上获取（例如 YouTube），可以通过其网页链接将其添加到演示文稿中。

1. 创建一个[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)类的实例。  
2. 通过索引获取幻灯片的引用。  
3. 添加一个[Video](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/)对象，并传入视频链接。  
4. 为视频帧设置缩略图。  
5. 保存演示文稿。  

下面的 JavaScript 代码示例展示了如何将网络视频添加到 PowerPoint 幻灯片中：
```javascript
// 实例化表示演示文稿文件的 Presentation 对象
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


## **从幻灯片中提取视频**

除了向幻灯片添加视频之外，Aspose.Slides 还允许您提取嵌入在演示文稿中的视频。

1. 创建一个[Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation)类的实例以加载包含视频的演示文稿。  
2. 遍历所有[Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide/)对象。  
3. 遍历所有[Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/)对象以查找[VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/)。  
4. 将视频保存到磁盘。  

下面的 JavaScript 代码示例展示了如何从演示文稿幻灯片中提取视频：
```javascript
// 实例化表示演示文稿文件的 Presentation 对象
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


## **FAQ**

**可以更改 VideoFrame 的哪些视频播放参数？**

您可以控制[播放模式](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplaymode/)（自动或点击）以及[循环](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setplayloopmode/)。这些选项可以通过[VideoFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/)对象的属性进行设置。

**添加视频会影响 PPTX 文件大小吗？**

会。当您嵌入本地视频时，二进制数据会被包含在文档中，演示文稿的大小会随文件大小等比例增长。当您添加在线视频时，仅嵌入链接和缩略图，大小增加相对较小。

**能否在不改变位置和大小的情况下替换现有 VideoFrame 中的视频？**

可以。您可以在保持形状几何属性不变的情况下，替换框架内的[视频内容](https://reference.aspose.com/slides/nodejs-java/aspose.slides/videoframe/setembeddedvideo/)，这在更新已有布局中的媒体时非常常见。

**可以确定嵌入视频的内容类型（MIME）吗？**

可以。嵌入的视频拥有可读取的[内容类型](https://reference.aspose.com/slides/nodejs-java/aspose.slides/video/getcontenttype/)，您可以使用该信息，例如在保存到磁盘时。