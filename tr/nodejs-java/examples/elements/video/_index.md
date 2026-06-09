---
title: Video
type: docs
weight: 80
url: /tr/nodejs-java/examples/elements/video/
keywords:
- kod örneği
- video
- PowerPoint
- OpenDocument
- sunum
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js ile videoları ekleyin ve yönetin: ekleme, oynatma, kırpma, poster çerçeveleri ayarlama ve PPT, PPTX ve ODP sunumları için örneklerle dışa aktarma."
---
Bu makale, **Aspose.Slides for Node.js via Java** kullanarak video çerçevelerini gömmeyi ve oynatma seçeneklerini ayarlamayı göstermektedir.

## **Video Çerçevesi Ekle**

Bir slayta video çerçevesi ekleyin.

```js
function addVideo() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Bir video ekle.
        let videoFrame = slide.getShapes().addVideoFrame(50, 50, 320, 240, "video.mp4");

        presentation.save("video.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Video Çerçevesine Eriş**

Bir slayta eklenen ilk video çerçevesini alın.

```js
function accessVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx"); 
    try { 
        let slide = presentation.getSlides().get_Item(0);

        // Slayd üzerindeki ilk video çerçevesine eriş.
        let firstVideo = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IVideoFrame")) {
                firstVideo = shape;
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

```js
function removeVideo() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // İlk şeklin video çerçevesi olduğunu varsay.
        let videoFrame = slide.getShapes().get_Item(0);

        // Video çerçevesini kaldır.
        slide.getShapes().remove(videoFrame);

        presentation.save("video_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Video Oynatmayı Ayarla**

Slayt gösterildiğinde videonun otomatik olarak oynatılmasını yapılandırın.

```js
function setVideoPlayback() {
    let presentation = new aspose.slides.Presentation("video.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // İlk şeklin video çerçevesi olduğunu varsay.
        let videoFrame = slide.getShapes().get_Item(0);

        // Videonun otomatik olarak oynatılmasını yapılandır.
        videoFrame.setPlayMode(aspose.slides.VideoPlayModePreset.Auto);

        presentation.save("video_autoplay.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```