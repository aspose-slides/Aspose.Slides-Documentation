---
title: Video
type: docs
weight: 80
url: /tr/androidjava/examples/elements/video/
keywords:
- kod örneği
- video
- PowerPoint
- OpenDocument
- sunum
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android ile video ekleyin ve kontrol edin: ekleme, oynatma, kırpma, poster çerçeveleri ayarlama ve PPT, PPTX ve ODP sunumları için Java örnekleriyle dışa aktarma."
---
Bu makale, **Aspose.Slides for Android via Java** kullanarak video çerçevelerini nasıl gömebileceğinizi ve oynatma seçeneklerini nasıl ayarlayabileceğinizi gösterir.

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

## **Video Çerçevesine Erişin**
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
Slayttan bir video çerçevesini silin.

```java
static void removeVideo() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Video çerçevesini kaldır.
        slide.getShapes().remove(videoFrame);
    } finally {
        presentation.dispose();
    }
}
```

## **Video Oynatmayı Ayarla**
Slayt gösterildiğinde videonun otomatik olarak oynatılacak şekilde ayarlayın.

```java
static void setVideoPlayback() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IVideoFrame videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        // Videoyu otomatik oynatmak için yapılandır.
        videoFrame.setPlayMode(VideoPlayModePreset.Auto);
    } finally {
        presentation.dispose();
    }
}
```