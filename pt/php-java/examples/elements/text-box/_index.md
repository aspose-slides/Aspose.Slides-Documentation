---
title: Caixa de texto
type: docs
weight: 40
url: /pt/php-java/examples/elements/text-box/
keywords:
- caixa de texto
- adicionar caixa de texto
- acessar caixa de texto
- remover caixa de texto
- exemplos de código
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Crie e formate caixas de texto em PHP com Aspose.Slides: defina fontes, alinhamento, quebra de linha, ajuste automático e links para aprimorar slides para PowerPoint e OpenDocument."
---
Em Aspose.Slides, uma **caixa de texto** é representada por um `AutoShape`. Quase qualquer forma pode conter texto, mas uma caixa de texto típica não tem preenchimento nem borda e exibe apenas texto.

Este guia explica como adicionar, acessar e remover caixas de texto programaticamente.

## **Adicionar uma caixa de texto**

Uma caixa de texto é simplesmente um `AutoShape` sem preenchimento nem borda e com algum texto formatado. Veja como criar uma:

```php
function addTextBox() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Crie uma forma retangular (padrão preenchida com borda e sem texto).
        $textBox = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

        // Remova o preenchimento e a borda para que pareça uma caixa de texto típica.
        $textBox->getFillFormat()->setFillType(FillType::NoFill);
        $textBox->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);

        // Defina a formatação do texto.
        $paragraph = $textBox->getTextFrame()->getParagraphs()->get_Item(0);
        $portionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
        $portionFormat->getFillFormat()->setFillType(FillType::Solid);
        $portionFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        // Atribua o conteúdo real do texto.
        $textBox->getTextFrame()->setText("Some text...");

        $presentation->save("text_box.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Observação:** Qualquer `AutoShape` que contém um `TextFrame` não vazio pode funcionar como uma caixa de texto.

## **Acessar caixas de texto por conteúdo**

Para encontrar todas as caixas de texto que contêm uma palavra‑chave específica (por ex. "Slide"), itere pelas formas e verifique seu texto:

```php
function accessTextBox() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Acesse a primeira caixa de texto do slide.
        $firstTextBox = null;
        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $firstTextBox = $shape;
                if (strpos($firstTextBox->getTextFrame()->getText(), "Slide") !== false) {
                    // Faça algo com a caixa de texto correspondente.
                }
                break;
            }
        }
    } finally {
        $presentation->dispose();
    }
}
```

## **Remover caixas de texto por conteúdo**

Este exemplo encontra e exclui todas as caixas de texto no primeiro slide que contêm uma palavra‑chave específica:

```php
function removeTextBoxes() {
    $presentation = new Presentation("text_box.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $shapesToRemove = [];

        $shapeCount = java_values($slide->getShapes()->size());
        for ($index = 0; $index < $shapeCount; $index++) {
            $shape = $slide->getShapes()->get_Item($index);
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $autoShape = $shape;
                if (strpos($autoShape->getTextFrame()->getText(), "Slide") !== false) {
                    $shapesToRemove[] = $shape;
                }
            }
        }

        foreach ($shapesToRemove as $shape) {
            $slide->getShapes()->remove($shape);
        }

        $presentation->save("text_boxes_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Dica:** Sempre crie uma cópia da coleção de formas antes de modificá‑la durante a iteração para evitar erros de modificação da coleção.