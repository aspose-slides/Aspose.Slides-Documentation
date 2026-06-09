---
title: Tablo
type: docs
weight: 120
url: /tr/php-java/examples/elements/table/
keywords:
- tablo
- tablo ekle
- tabloya eriş
- tablo kaldır
- hücreleri birleştir
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides ile PHP'de tablolar oluşturun ve biçimlendirin: veri ekleyin, hücreleri birleştirin, kenarlıkları biçimlendirin, içeriği hizalayın ve PPT, PPTX ve ODP için içe/dışa aktarın."
---
Aspose.Slides for PHP via Java kullanarak tablo ekleme, tabloya erişme, tablo silme ve hücre birleştirme örnekleri.

## **Tablo Ekle**

İki satır ve iki sütundan oluşan basit bir tablo oluşturun.

```php
function addTable() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $widths = [80, 80];
        $heights = [30, 30];
        $table = $slide->getShapes()->addTable(50, 50, $widths, $heights);

        $presentation->save("table.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Tabloya Erişim**

Slayttaki ilk tablo şekli alın.

```php
function accessTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Slayttaki ilk tabloya eriş.
        $firstTable = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Table"))) {
                $firstTable = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Tabloyu Kaldır**

Bir slayttan tabloyu sil.

```php
function removeTable() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Tablonun slayttaki ilk şekil olduğu varsayılıyor.
        $table = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($table);

        $presentation->save("table_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Tablo Hücrelerini Birleştir**

Bir tablonun yan yana bulunan hücrelerini tek bir hücreye birleştirin.

```php
function mergeTableCells() {
    $presentation = new Presentation("table.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Tablonun slayttaki ilk şekil olduğu varsayılıyor.
        $table = $slide->getShapes()->get_Item(0);

        $table->mergeCells($table->get_Item(0, 0), $table->get_Item(1, 1), false);

        $presentation->save("cells_merged.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```