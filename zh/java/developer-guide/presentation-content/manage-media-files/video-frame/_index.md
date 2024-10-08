---
title: 视频框
type: docs
weight: 10
url: /zh/java/video-frame/
keywords: " 添加视频，创建视频框，提取视频，PowerPoint演示文稿，Java，Aspose.Slides for Java"
description: "在Java中向PowerPoint演示文稿添加视频框"
---

在演示文稿中恰当地放置视频可以使您的信息更加引人注目，并提高与观众的互动水平。

PowerPoint允许您以两种方式在演示文稿的幻灯片中添加视频：

* 添加或嵌入本地视频（存储在您的计算机上）
* 添加在线视频（来自网络源，例如YouTube）。

为了让您能够向演示文稿添加视频（视频对象），Aspose.Slides提供了[IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/)接口、[IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/)接口和其他相关类型。

## **创建嵌入视频框**

如果您要添加到幻灯片的视频文件存储在本地，则可以创建一个视频框以在演示文稿中嵌入视频。

1. 创建一个[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个[IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/)对象，并传递视频文件路径以在演示文稿中嵌入视频。
1. 添加一个[IVideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ivideoframe/)对象以为视频创建一个框架。
1. 保存修改后的演示文稿。

以下Java代码展示了如何将存储在本地的视频添加到演示文稿中：

```java
// 实例化Presentation类
Presentation pres = new Presentation("pres.pptx");
try {
    // 加载视频
    FileInputStream fileStream = new FileInputStream("Wildlife.mp4");
    
    IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);

    // 获取第一张幻灯片并添加视频框
    pres.getSlides().get_Item(0).getShapes().addVideoFrame(10, 10, 150, 250, video);

    // 将演示文稿保存到磁盘
    pres.save("pres-with-video.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

或者，您可以通过直接将视频文件路径传递给[addVideoFrame(float x, float y, float width, float height, IVideo video)](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addVideoFrame-float-float-float-float-com.aspose.slides.IVideo-)方法来添加视频：

``` java
Presentation pres = new Presentation();
try {
	ISlide sld = pres.getSlides().get_Item(0);
	IVideoFrame vf = sld.getShapes().addVideoFrame(50, 150, 300, 150, "video1.avi");
} finally {
	if (pres != null) pres.dispose();
}
```

## **使用网络来源的视频创建视频框**

Microsoft [PowerPoint 2013及更高版本](https://support.microsoft.com/en-us/office/versions-of-powerpoint-that-support-online-videos-2a0e184d-af50-4da9-b530-e4355ac436a9?ui=en-us&rs=en-us&ad=us)支持在演示文稿中使用YouTube视频。如果您要使用的视频可以在线获得（例如在YouTube上），则可以通过其网页链接将其添加到演示文稿中。

1. 创建一个[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)类的实例。
1. 通过索引获取幻灯片的引用。
1. 添加一个[IVideo](https://reference.aspose.com/slides/java/com.aspose.slides/ivideo/)对象，并传递视频的链接。
1. 为视频框设置缩略图。
1. 保存演示文稿。

以下Java代码展示了如何将网络上的视频添加到PowerPoint演示文稿的幻灯片中：

```java
// 实例化一个表示演示文稿文件的Presentation对象
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
    // 添加视频框
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

除了向幻灯片添加视频，Aspose.Slides还允许您提取嵌入在演示文稿中的视频。

1. 创建一个[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation)类的实例，以加载包含视频的演示文稿。
2. 遍历所有[ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/)对象。
3. 遍历所有[IShape](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/)对象，以查找[VideoFrame](https://reference.aspose.com/slides/java/com.aspose.slides/videoframe/)。
4. 将视频保存到磁盘。

以下Java代码展示了如何提取演示文稿幻灯片上的视频：

```java
// 实例化一个表示演示文稿文件的Presentation对象 
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