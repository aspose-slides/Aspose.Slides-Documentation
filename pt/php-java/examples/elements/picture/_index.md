---
title: Imagem
type: docs
weight: 50
url: /pt/php-java/examples/elements/picture/
keywords:
- imagem
- quadro de imagem
- adicionar imagem
- acessar imagem
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Trabalhe com imagens em PHP usando Aspose.Slides: insira, substitua, recorte, comprima, ajuste transparência e efeitos, preencha formas e exporte para PPT, PPTX e ODP."
---
Mostra como inserir e acessar imagens usando **Aspose.Slides for PHP via Java**. Os exemplos abaixo colocam uma imagem em um slide e, em seguida, a recuperam.

## **Adicionar uma Imagem**

Este código insere uma imagem como um quadro de imagem no primeiro slide.

```php
function addPicture() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $image = $presentation->getImages()->addImage(
            new Java("java.io.FileInputStream", new Java("java.io.File", "image.jpg")));

        // Adicione a imagem aos recursos da apresentação.
        // Insira um quadro de imagem exibindo a imagem no primeiro slide.
        $slide->getShapes()->addPictureFrame(
            ShapeType::Rectangle, 50, 50, $ppImage->getWidth(), $ppImage->getHeight(), $ppImage);

        $presentation->save("picture.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Acessar uma Imagem**

Este exemplo garante que um slide contenha um quadro de imagem e, em seguida, acessa o primeiro que encontrar.

```php
function accessPicture() {
    $presentation = new Presentation("picture.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Acesse o primeiro PictureFrame no slide.
        $firstPictureFrame = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $firstPictureFrame = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```