---
title: OLE objektum
type: docs
weight: 210
url: /hu/php-java/examples/elements/ole-object/
keywords:
- OLE objektum
- OLE objektum hozzáadása
- OLE objektum elérése
- OLE objektum eltávolítása
- OLE objektum frissítése
- kódpéldák
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Dolgozz OLE objektumokkal PHP-ben az Aspose.Slides használatával: ágyazott fájlok beszúrása vagy frissítése, ikonok vagy hivatkozások beállítása, tartalom kinyerése, viselkedés szabályozása PPT, PPTX és ODP esetén."
---
Bemutatja, hogyan ágyazhatsz be egy fájlt OLE objektumként, és frissítheted annak adatait a **Aspose.Slides for PHP via Java** használatával.

## **OLE objektum hozzáadása**

Ágyazz be egy PDF fájlt egy prezentációba.

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

## **OLE objektum elérése**

Szerezd meg az első OLE objektumkeretet egy dián.

```php
function accessOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Hozzáférés az első OLE kerethez a dián.
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

## **OLE objektum eltávolítása**

Töröld a beágyazott OLE objektumot a diáról.

```php
function removeOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Feltételezve, hogy a dián az első alakzat az OLE keret.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($oleFrame);

        $presentation->save("ole_object_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **OLE objektum adatainak frissítése**

Cseréld le a meglévő OLE objektumban beágyazott adatokat.

```php
function updateOleObjectData() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Feltételezve, hogy a dián az első alakzat az OLE keret.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $newData = new OleEmbeddedDataInfo(file_get_contents("picture.png"), "png");
        $oleFrame->setEmbeddedData($newData);

        $presentation->save("ole_object_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```