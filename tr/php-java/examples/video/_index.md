---
title: Video
type: docs
weight: 80
url: /tr/php-java/examples/elements/video/
keywords:
- video
- video çerçevesi
- video ekle
- videoya eriş
- video kaldır
- video oynatma
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides kullanarak PHP'de video ile çalışın: ekleme, değiştirme, kırpma, afiş çerçevelerini ve oynatma seçeneklerini ayarlama ve PPT, PPTX ve ODP için sunumları dışa aktarma."
---
Aspose.Slides for PHP via Java kullanarak video çerçevelerinin nasıl gömüleceğini ve oynatma seçeneklerinin nasıl ayarlanacağını gösterir.

## **Video Çerçevesi Ekle**

Bir slayta video çerçevesi ekleyin.

```php
function addVideo() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Video çerçevesi ekle.
        $videoFrame = $slide->getShapes()->addVideoFrame(50, 50, 320, 240, "video.mp4");

        $presentation->save("video.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Video Çerçevesine Erişim**

Bir slayta eklenen ilk video çerçevesini alın.

```php
function accessVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Slayttaki ilk video çerçevesine eriş.
        $firstVideoFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.VideoFrame"))) {
                $firstVideoFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Video Çerçevesini Kaldır**

Video çerçevesini slayttan silin.

```php
function removeVideo() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Slayttaki ilk şeklin video çerçevesi olduğunu varsayalım.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // Video çerçevesini kaldır.
        $slide->getShapes()->remove($videoFrame);

        $presentation->save("video_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Video Oynatmayı Ayarla**

Slayt gösterildiğinde videonun otomatik olarak oynatılacak şekilde yapılandırın.

```php
function setVideoPlayback() {
    $presentation = new Presentation("video.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Slayttaki ilk şeklin video çerçevesi olduğunu varsayalım.
        $videoFrame = $slide->getShapes()->get_Item(0);

        // Videoyu otomatik olarak oynatacak şekilde yapılandır.
        $videoFrame->setPlayMode(VideoPlayModePreset::Auto);

        $presentation->save("video_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```