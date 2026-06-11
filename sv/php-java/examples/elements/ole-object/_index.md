---
title: OLE-objekt
type: docs
weight: 210
url: /sv/php-java/examples/elements/ole-object/
keywords:
- OLE-objekt
- lägga till OLE-objekt
- åtkomst till OLE-objekt
- ta bort OLE-objekt
- uppdatera OLE-objekt
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Arbeta med OLE-objekt i PHP med Aspose.Slides: infoga eller uppdatera inbäddade filer, ange ikoner eller länkar, extrahera innehåll, kontrollera beteende för PPT, PPTX och ODP."
---
Visar hur man bäddar in en fil som ett OLE-objekt och uppdaterar dess data med hjälp av **Aspose.Slides for PHP via Java**.

## **Lägg till ett OLE-objekt**

Bädda in en PDF-fil i en presentation.

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

## **Åtkomst till ett OLE-objekt**

Hämta den första OLE-objekt-ramen på en bild.

```php
function accessOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Åtkomst till den första OLE-ramen på bilden.
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

## **Ta bort ett OLE-objekt**

Ta bort ett inbäddat OLE-objekt från bilden.

```php
function removeOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Förutsatt att den första formen på bilden är OLE-ramen.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($oleFrame);

        $presentation->save("ole_object_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Uppdatera OLE-objektdata**

Ersätt data som är inbäddad i ett befintligt OLE-objekt.

```php
function updateOleObjectData() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Förutsatt att den första formen på bilden är OLE-ramen.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $newData = new OleEmbeddedDataInfo(file_get_contents("picture.png"), "png");
        $oleFrame->setEmbeddedData($newData);

        $presentation->save("ole_object_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```