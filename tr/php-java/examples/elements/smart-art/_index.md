---
title: SmartArt
type: docs
weight: 140
url: /tr/php-java/examples/elements/smartart/
keywords:
- SmartArt
- SmartArt ekle
- SmartArt erişimi
- SmartArt kaldırma
- SmartArt düzeni
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides ile PHP'de SmartArt oluşturun ve düzenleyin: düğüm ekleyin, düzen ve stilleri değiştirin, şekillere hassas bir şekilde dönüştürün ve PPT, PPTX ve ODP için dışa aktarın."
---
**Aspose.Slides for PHP via Java** kullanarak SmartArt grafiklerini eklemeyi, bunlara erişmeyi, kaldırmayı ve düzenleri değiştirmeyi gösterir.

## **SmartArt Ekle**

Yerleşik düzenlerden birini kullanarak bir SmartArt grafiği ekleyin.

```php
function addSmartArt() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $smart = $slide->getShapes()->addSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

        $presentation->save("smart_art.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **SmartArt Erişimi**

Bir slayttaki ilk SmartArt nesnesini alın.

```php
function accessSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Slayttaki ilk SmartArt'a erişim.
        $firstSmartArt = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
                $firstSmartArt = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **SmartArt'ı Kaldır**

Slayttan bir SmartArt şekli silin.

```php
function removeSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Slayttaki ilk şeklin bir SmartArt olduğunu varsayarak.
        $smartArt = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($smartArt);

        $presentation->save("smart_art_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **SmartArt Düzenini Değiştir**

Mevcut bir SmartArt grafiğinin düzen türünü güncelleyin.

```php
function changeSmartArtLayout() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Slayttaki ilk şeklin bir SmartArt olduğunu varsayarak.
        $smartArt = $slide->getShapes()->get_Item(0);

        // SmartArt'ın düzenini değiştir.
        $smartArt->setLayout(SmartArtLayoutType::VerticalPictureList);

        $presentation->save("smart_art_layout_changed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```