---
title: OleObject
type: docs
weight: 210
url: /de/php-java/examples/elements/ole-object/
keywords:
- OLE-Objekt
- OLE-Objekt hinzufügen
- OLE-Objekt abrufen
- OLE-Objekt entfernen
- OLE-Objekt aktualisieren
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Arbeiten Sie mit OLE-Objekten in PHP mithilfe von Aspose.Slides: Einbetten oder Aktualisieren von Dateien, Festlegen von Symbolen oder Links, Extrahieren von Inhalten, Steuerung des Verhaltens für PPT, PPTX und ODP."
---
Zeigt, wie man eine Datei als OLE-Objekt einbettet und deren Daten mit **Aspose.Slides for PHP via Java** aktualisiert.

## **OLE-Objekt hinzufügen**

Betten Sie eine PDF-Datei in eine Präsentation ein.

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

## **Zugriff auf ein OLE-Objekt**

Rufen Sie den ersten OLE-Objektrahmen auf einer Folie ab.

```php
function accessOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zugriff auf das erste OLE-Frame auf der Folie.
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

## **OLE-Objekt entfernen**

Löschen Sie ein eingebettetes OLE-Objekt von der Folie.

```php
function removeOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Angenommen, das erste Shape auf der Folie ist das OLE-Frame.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($oleFrame);

        $presentation->save("ole_object_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **OLE-Objektdaten aktualisieren**

Ersetzen Sie die in einem vorhandenen OLE-Objekt eingebetteten Daten.

```php
function updateOleObjectData() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Angenommen, das erste Shape auf der Folie ist das OLE-Frame.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $newData = new OleEmbeddedDataInfo(file_get_contents("picture.png"), "png");
        $oleFrame->setEmbeddedData($newData);

        $presentation->save("ole_object_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```