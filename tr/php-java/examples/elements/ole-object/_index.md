---
title: OleNesnesi
type: docs
weight: 210
url: /tr/php-java/examples/elements/ole-object/
keywords:
- OLE nesnesi
- OLE nesnesi ekle
- OLE nesnesine eriş
- OLE nesnesini kaldır
- OLE nesnesini güncelle
- kod örnekleri
- PowerPoint
- OpenDocument
- sunum
- PHP
- Aspose.Slides
description: "Aspose.Slides kullanarak PHP'de OLE nesneleriyle çalışın: gömülü dosyaları ekleyin veya güncelleyin, simge veya bağlantı ayarlayın, içeriği çıkarın, PPT, PPTX ve ODP için davranışı kontrol edin."
---
Bir dosyayı OLE nesnesi olarak eklemeyi ve verilerini **Aspose.Slides for PHP via Java** kullanarak güncellemeyi gösterir.

## **OLE Nesnesi Ekle**

Bir PDF dosyasını sunuma ekleyin.

```php
function addOleObject() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $pdfData = new OleEmbeddedDataInfo(file_get_contents("doc.pdf"), "pdf");
        $oleFrame = $slide->getShapes()->addOleObjectFrame(20, 20, 50, 50, $pdfData);

        $presentation->save("ole_object.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **OLE Nesnesine Eriş**

Bir slayttaki ilk OLE nesne çerçevesini alın.

```php
function accessOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Slayttaki ilk OLE çerçevesine eriş.
        $firstOleFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
                $firstOleFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **OLE Nesnesini Kaldır**

Slayttan yerleştirilmiş bir OLE nesnesini silin.

```php
function removeOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Slayttaki ilk şeklin OLE çerçevesi olduğunu varsayarak.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($oleFrame);

        $presentation->save("ole_object_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **OLE Nesne Verilerini Güncelle**

Mevcut bir OLE nesnesine yerleştirilmiş verileri değiştirin.

```php
function updateOleObjectData() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Slayttaki ilk şeklin OLE çerçevesi olduğunu varsayarak.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $newData = new OleEmbeddedDataInfo(file_get_contents("picture.png"), "png");
        $oleFrame->setEmbeddedData($newData);

        $presentation->save("ole_object_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```