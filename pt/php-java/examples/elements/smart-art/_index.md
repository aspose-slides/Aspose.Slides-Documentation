---
title: SmartArt
type: docs
weight: 140
url: /pt/php-java/examples/elements/smartart/
keywords:
- SmartArt
- adicionar SmartArt
- acessar SmartArt
- remover SmartArt
- layout SmartArt
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Crie e edite SmartArt em PHP com Aspose.Slides: adicione nós, altere layouts e estilos, converta em formas com precisão e exporte para PPT, PPTX e ODP."
---
Mostra como adicionar gráficos SmartArt, acessá‑los, removê‑los e alterar layouts usando **Aspose.Slides for PHP via Java**.

## **Add SmartArt**
Inserir um gráfico SmartArt usando um dos layouts incorporados.

```php
function addSmartArt() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $smart = $slide->getShapes()->addSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

        $presentation->save("smart_art.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Access SmartArt**
Recuperar o primeiro objeto SmartArt em um slide.

```php
function accessSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Acesse o primeiro SmartArt no slide.
        $firstSmartArt = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.SmartArt"))) {
                $firstSmartArt = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Remove SmartArt**
Excluir uma forma SmartArt do slide.

```php
function removeSmartArt() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Assumindo que a primeira forma no slide é um SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($smartArt);

        $presentation->save("smart_art_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Change SmartArt Layout**
Atualizar o tipo de layout de um gráfico SmartArt existente.

```php
function changeSmartArtLayout() {
    $presentation = new Presentation("smart_art.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Assumindo que a primeira forma no slide é um SmartArt.
        $smartArt = $slide->getShapes()->get_Item(0);

        // Alterar o layout do SmartArt.
        $smartArt->setLayout(SmartArtLayoutType::VerticalPictureList);

        $presentation->save("smart_art_layout_changed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```