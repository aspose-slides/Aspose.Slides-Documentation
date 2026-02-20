---
title: ObjetoOLE
type: docs
weight: 210
url: /es/php-java/examples/elements/ole-object/
keywords:
- objeto OLE
- añadir objeto OLE
- acceder objeto OLE
- eliminar objeto OLE
- actualizar objeto OLE
- ejemplos de código
- PowerPoint
- OpenDocument
- presentación
- PHP
- Aspose.Slides
description: "Trabaja con objetos OLE en PHP usando Aspose.Slides: inserta o actualiza archivos incrustados, establece íconos o enlaces, extrae contenido, controla el comportamiento para PPT, PPTX y ODP."
---
Demuestra cómo incrustar un archivo como objeto OLE y actualizar sus datos usando **Aspose.Slides for PHP via Java**.

## **Agregar un objeto OLE**

Incrusta un archivo PDF en una presentación.

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

## **Acceder a un objeto OLE**

Recupera el primer marco de objeto OLE en una diapositiva.

```php
function accessOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Acceder al primer marco OLE en la diapositiva.
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

## **Eliminar un objeto OLE**

Elimina un objeto OLE incrustado de la diapositiva.

```php
function removeOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Suponiendo que la primera forma en la diapositiva es el marco OLE.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($oleFrame);

        $presentation->save("ole_object_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Actualizar datos del objeto OLE**

Reemplaza los datos incrustados en un objeto OLE existente.

```php
function updateOleObjectData() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Suponiendo que la primera forma en la diapositiva es el marco OLE.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $newData = new OleEmbeddedDataInfo(file_get_contents("picture.png"), "png");
        $oleFrame->setEmbeddedData($newData);

        $presentation->save("ole_object_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```