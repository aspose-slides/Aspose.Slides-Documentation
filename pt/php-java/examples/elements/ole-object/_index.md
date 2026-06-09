---
title: Objeto OLE
type: docs
weight: 210
url: /pt/php-java/examples/elements/ole-object/
keywords:
- objeto OLE
- adicionar objeto OLE
- acessar objeto OLE
- remover objeto OLE
- atualizar objeto OLE
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Trabalhe com objetos OLE em PHP usando Aspose.Slides: insira ou atualize arquivos incorporados, defina ícones ou links, extraia conteúdo, controle o comportamento para PPT, PPTX e ODP."
---
Demonstrar a incorporação de um arquivo como objeto OLE e a atualização de seus dados usando **Aspose.Slides for PHP via Java**.

## **Add an OLE Object**
Incorporar um arquivo PDF em uma apresentação.

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

## **Access an OLE Object**
Recuperar o primeiro quadro de objeto OLE em um slide.

```php
function accessOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Acessar o primeiro frame OLE no slide.
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

## **Remove an OLE Object**
Excluir um objeto OLE incorporado do slide.

```php
function removeOleObject() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Pressupondo que a primeira forma no slide é o frame OLE.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($oleFrame);

        $presentation->save("ole_object_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Update OLE Object Data**
Substituir os dados incorporados em um objeto OLE existente.

```php
function updateOleObjectData() {
    $presentation = new Presentation("ole_object.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Assumindo que a primeira forma no slide é o frame OLE.
        $oleFrame = $slide->getShapes()->get_Item(0);

        $newData = new OleEmbeddedDataInfo(file_get_contents("picture.png"), "png");
        $oleFrame->setEmbeddedData($newData);

        $presentation->save("ole_object_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```