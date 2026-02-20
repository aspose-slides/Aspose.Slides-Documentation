---
title: ObjetOLE
type: docs
weight: 210
url: /fr/php-java/examples/elements/ole-object/
keywords:
- objet OLE
- ajouter objet OLE
- accéder à l'objet OLE
- supprimer l'objet OLE
- mettre à jour l'objet OLE
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- PHP
- Aspose.Slides
description: "Travaillez avec les objets OLE en PHP à l'aide d'Aspose.Slides: insérez ou mettez à jour des fichiers incorporés, définissez des icônes ou des liens, extrayez le contenu, contrôlez le comportement pour PPT, PPTX et ODP."
---
Démontre l'intégration d'un fichier en tant qu'objet OLE et la mise à jour de ses données à l'aide de **Aspose.Slides for PHP via Java**.

## **Ajouter un objet OLE**
Intégrez un fichier PDF dans une présentation.

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

## **Accéder à un objet OLE**
Récupérez la première trame d'objet OLE sur une diapositive.

```php
function accessOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Accéder au premier cadre OLE de la diapositive.
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

## **Supprimer un objet OLE**
Supprimez un objet OLE intégré de la diapositive.

```php
function removeOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // En supposant que la première forme de la diapositive est le cadre OLE.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($oleFrame);

        $presentation->save("ole_object_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Mettre à jour les données d'un objet OLE**
Remplacez les données intégrées dans un objet OLE existant.

```php
function updateOleObjectData() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // En supposant que la première forme de la diapositive est le cadre OLE.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $newData = new OleEmbeddedDataInfo(file_get_contents("picture.png"), "png");
        $oleFrame->setEmbeddedData($newData);

        $presentation->save("ole_object_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```