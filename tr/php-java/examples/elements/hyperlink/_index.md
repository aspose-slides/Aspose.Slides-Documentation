---
title: Hiperlink
type: docs
weight: 130
url: /tr/php-java/examples/elements/hyperlink/
keywords:
- hiperlink
- hiperlink ekle
- hiperlink eriş
- hiperlink kaldır
- hiperlink güncelle
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides ile PHP'de hiperlink ekleyin, düzenleyin ve kaldırın: metin, şekiller, slaytlar, URL'ler ve e-posta; PPT, PPTX ve ODP için hedef ve eylemler ayarlayın."
---
Şekillerdeki hiperlinkleri ekleme, erişme, kaldırma ve güncelleme işlemlerini **Aspose.Slides for PHP via Java** kullanarak gösterir.

## **Hiperlink Ekle**

Harici bir web sitesine yönelik bir hiperlink içeren bir dikdörtgen şekil oluşturun.

```php
function addHyperlink() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
        $shape->getTextFrame()->setText("Aspose");

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        $presentation->save("hyperlink.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Hiperlink'e Eriş**

Bir şeklin metin bölümünden hiperlink bilgilerini okuyun.

```php
function accessHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        //        İlk şeklin hiperlinki içerdiği varsayılıyor.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $hyperlink = $portion->getPortionFormat()->getHyperlinkClick();
    } finally {
        $presentation->dispose();
    }
}
```

## **Hiperlink'i Kaldır**

Bir şeklin metninden hiperlinki temizleyin.

```php
function removeHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // İlk şeklin hiperlinki içerdiği varsayılıyor.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setHyperlinkClick(null);

        $presentation->save("hyperlink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Hiperlink'i Güncelle**

Mevcut bir hiperlinkin hedefini değiştirin. `HyperlinkManager` kullanarak zaten bir hiperlink içeren metni değiştirin; bu, PowerPoint'in hiperlinkleri güvenli bir şekilde güncelleme biçimini taklit eder.

```php
function updateHyperlink() {
    $presentation = new Presentation("hyperlink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        //        İlk şeklin hiperlinki içerdiği varsayılıyor.
        $shape = $slide->getShapes()->get_Item(0);

        $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
        $portion = $paragraph->getPortions()->get_Item(0);

        //        Mevcut metin içinde bir hiperlinki değiştirmek
        //        HyperlinkManager kullanılarak, özelliği doğrudan ayarlamaktan kaçınılmalıdır.
        //        Bu, PowerPoint'in hiperlinkleri güvenli bir şekilde güncelleme şeklini taklit eder.
        $portion->getPortionFormat()->getHyperlinkManager()->setExternalHyperlinkClick("https://new.example.com");

        $presentation->save("hyperlink_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```