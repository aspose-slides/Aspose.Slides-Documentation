---
title: Video
type: docs
weight: 80
url: /tr/java/examples/elements/video/
keywords:
- kod örneği
- video
- PowerPoint
- OpenDocument
- sunum
- Java
- Aspose.Slides
description: "Aspose.Slides for Java ile video ekleyin ve yönetin: ekleyin, oynatın, kırpın, poster çerçevelerini ayarlayın ve PPT, PPTX ve ODP sunumları için Java örnekleriyle dışa aktarın."
---
Bu makale, **Aspose.Slides for Java** kullanarak video çerçevelerini nasıl gömeceğinizi ve oynatma seçeneklerini nasıl ayarlayacağınızı gösterir.

## **Video Çerçevesi Ekle**
Bir slayta boş bir video çerçevesi ekleyin.

```java
static void addVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Bir video ekleyin.
        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");
    } finally {
        presentation.dispose();
    }
}
```

## **Video Çerçevesine Erişim**
Bir slayta eklenen ilk video çerçevesini alın.

```java
static void accessVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Slayttaki ilk video çerçevesine erişin.
        IVideoFrame firstVideo = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IVideoFrame) {
                firstVideo = (IVideoFrame) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Video Çerçevesini Kaldır**
Video çerçevesini slayttan silin.

```java
static void removeVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Video çerçevesini kaldırın.
        slide.getShapes().remove(videoFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Video Oynatmayı Ayarla**
Slayt gösterildiğinde videonun otomatik olarak oynatılacak şekilde yapılandırın.

```java
static void setVideoPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Videoyu otomatik olarak oynatılacak şekilde yapılandırın.
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```