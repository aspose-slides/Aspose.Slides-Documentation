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
description: "了解如何使用 Aspose.Slides for Java 在 PowerPoint 和 OpenDocument 幻灯片中以编程方式添加和提取视频帧。快速操作指南。"
---

在演示文稿中恰当地放置视频可以使您的信息更具说服力，并提升观众的参与度。

PowerPoint 允许您以两种方式向演示文稿的幻灯片中添加视频：

* 添加或嵌入本地视频（存储在您的机器上）
* 添加在线视频（来自 YouTube 等网络来源）。

为了让您能够向演示文稿中添加视频（视频对象），Aspose.Slides 提供了[IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/)接口、[IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/)接口以及其他相关类型。

## **创建嵌入式视频帧**

如果要添加到幻灯片的视频文件存储在本地，您可以创建视频帧将视频嵌入到演示文稿中。

1. 创建一个[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个[IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/)对象，并传入视频文件路径以将视频嵌入演示文稿。
1. 添加一个[IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/)对象以为视频创建帧。
1. 保存修改后的演示文稿。

以下 Java 代码展示了如何将本地存储的视频添加到演示文稿中：
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


或者，您可以直接将文件路径传递给[addVideoFrame(float x,float y,float width,float height,IVideo video)](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-)方法来添加视频：
``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```


## **创建来自网络来源的视频帧**

Microsoft[PowerPoint 2013 及更高版本](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us)支持在演示文稿中嵌入 YouTube 视频。如果您要使用的视频可在网上获取（例如 YouTube），可以通过其网络链接将其添加到演示文稿中。

1. 创建一个[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个[IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/)对象，并传入视频链接。
1. 为视频帧设置缩略图。
1. 保存演示文稿。

以下 Java 代码展示了如何将网络视频添加到 PowerPoint 幻灯片中：
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
    // 添加 videoFrame
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


## **从幻灯片中提取视频**

除了向幻灯片添加视频，Aspose.Slides 还允许您提取嵌入演示文稿中的视频。

1. 创建一个[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)类的实例以加载包含视频的演示文稿。
2. 遍历所有的[ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/)对象。
3. 遍历所有的[IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)对象以查找[VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/)。
4. 将视频保存到磁盘。

以下 Java 代码展示了如何提取演示文稿幻灯片中的视频：
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


## **FAQ**

**可以更改 VideoFrame 的哪些视频播放参数？**

您可以控制[播放模式](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayMode-int-)(自动或点击)和[循环](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setPlayLoopMode-boolean-)。这些选项通过[VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/)对象的属性提供。

**添加视频会影响 PPTX 文件大小吗？**

会。嵌入本地视频时，二进制数据会包含在文档中，演示文稿大小会随文件大小成比例增长。添加在线视频时，仅嵌入链接和缩略图，大小增长会更小。

**是否可以在不更改位置和大小的情况下替换现有 VideoFrame 中的视频？**

可以。您可以在保持形状几何属性不变的情况下，替换帧内的[video content](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/#setEmbeddedVideo-com.aspose.slides.IVideo-)，这在更新已有布局中的媒体时非常常见。

**是否可以确定嵌入视频的内容类型 (MIME)？**

可以。嵌入的视频具有[content type](https://reference.aspose.com/slides/java/com.aspose.slides/video/#getContentType--)，您可以读取并使用，例如在保存到磁盘时。