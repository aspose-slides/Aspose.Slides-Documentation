---
title: OleObject
type: docs
weight: 210
url: /pl/php-java/examples/elements/ole-object/
keywords:
- obiekt OLE
- dodaj obiekt OLE
- uzyskaj dostęp do obiektu OLE
- usuń obiekt OLE
- zaktualizuj obiekt OLE
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Pracuj z obiektami OLE w PHP przy użyciu Aspose.Slides: wstawiaj lub aktualizuj osadzone pliki, ustawiaj ikony lub linki, wyodrębniaj zawartość, kontroluj zachowanie dla PPT, PPTX i ODP."
---
Demonstruje osadzanie pliku jako obiektu OLE i aktualizowanie jego danych przy użyciu **Aspose.Slides for PHP via Java**.

## **Dodaj obiekt OLE**

Osadź plik PDF w prezentacji.

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

## **Uzyskaj dostęp do obiektu OLE**

Pobierz pierwszą ramkę obiektu OLE na slajdzie.

```php
function accessOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Dostęp do pierwszej ramki OLE na slajdzie.
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

## **Usuń obiekt OLE**

Usuń osadzony obiekt OLE ze slajdu.

```php
function removeOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zakładając, że pierwszym kształtem na slajdzie jest ramka OLE.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($oleFrame);

        $presentation->save("ole_object_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Aktualizuj dane obiektu OLE**

Zastąp dane osadzone w istniejącym obiekcie OLE.

```php
function updateOleObjectData() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zakładając, że pierwszym kształtem na slajdzie jest ramka OLE.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $newData = new OleEmbeddedDataInfo(file_get_contents("picture.png"), "png");
        $oleFrame->setEmbeddedData($newData);

        $presentation->save("ole_object_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```