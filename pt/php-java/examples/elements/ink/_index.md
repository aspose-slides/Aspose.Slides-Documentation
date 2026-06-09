---
title: Tinta
type: docs
weight: 180
url: /pt/php-java/examples/elements/ink/
keywords:
- tinta
- acessar tinta
- remover tinta
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Manipule tinta digital em slides em PHP com Aspose.Slides: adicione traços de caneta, edite caminhos, defina cor e largura, e exporte os resultados para PowerPoint e OpenDocument."
---
Fornece exemplos de acesso a formas de tinta existentes e sua remoção usando **Aspose.Slides for PHP via Java**.

> ❗ **Nota:** As formas de tinta representam a entrada do usuário a partir de dispositivos especializados. Aspose.Slides não pode criar novos traços de tinta programaticamente, mas você pode ler e modificar tinta existente.

## **Acessar Tinta**

Obtenha a primeira forma de tinta em um slide.

```php
function accessInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Acesse a primeira forma de tinta no slide.
        $firstInk = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.Ink"))) {
                $firstInk = $shape;
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Remover Tinta**

Exclua uma forma de tinta do slide.

```php
function removeInk() {
    $presentation = new Presentation("ink.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Assumindo que a primeira forma no slide é uma forma de tinta.
        $ink = $slide->getShapes()->get_Item(0);

        $slide->getShapes()->remove($ink);

        $presentation->save("ink_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```