---
title: Ses
type: docs
weight: 70
url: /tr/php-java/examples/elements/audio/
keywords:
- ses
- ses çerçevesi
- ses ekle
- sese erişim
- ses kaldır
- ses oynatma
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides kullanarak PHP'de sesle çalışın: ses ekleyin, değiştirin, çıkarın ve kesin, PowerPoint ve OpenDocument'te slaytlar ve şekiller için ses seviyesini ve oynatmayı ayarlayın."
---
Ses çerçevelerinin nasıl yerleştirileceğini ve **Aspose.Slides for PHP via Java** ile oynatmanın nasıl kontrol edileceğini gösterir. Aşağıdaki örnekler temel ses işlemlerini gösterir.

## **Ses Çerçevesi Ekle**

Bir ses çerçevesi ekleyin.

```php
function addAudio() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Ses çerçevesi oluştur.
        $audioStream = new Java("java.io.FileInputStream", new Java("java.io.File", "audio.wav"));
        $audioFrame = $slide->getShapes()->addAudioFrameEmbedded(50, 50, 100, 100, $audioStream);

        $presentation->save("audio.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Ses Çerçevesine Erişim**

Bu kod, slayttaki ilk ses çerçevesini alır.

```php
function accessAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Slayt üzerindeki ilk ses çerçevesine eriş.
        $firstAudioFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AudioFrame"))) {
                $firstAudioFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Ses Çerçevesini Kaldır**

Daha önce eklenmiş bir ses çerçevesini silin.

```php
function removeAudio() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Slayttaki ilk şeklin bir ses çerçevesi olduğunu varsayarak.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Ses çerçevesini kaldır.
        $slide->getShapes()->remove($audioFrame);

        $presentation->save("audio_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Ses Oynatmayı Ayarla**

Ses çerçevesinin slayt göründüğünde otomatik olarak çalmasını yapılandırın.

```php
function setAudioPlayback() {
    $presentation = new Presentation("audio.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Slayttaki ilk şeklin bir ses çerçevesi olduğunu varsayarak.
        $audioFrame = $slide->getShapes()->get_Item(0);

        // Slayt göründüğünde otomatik olarak çal.
        $audioFrame->setPlayMode(AudioPlayModePreset::Auto);

        $presentation->save("audio_playback.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```