---
title: Obter limites de parágrafos de apresentações em PHP
linktitle: Limites de Parágrafo
type: docs
weight: 43
url: /pt/php-java/paragraph-bounds/
keywords:
- limites de parágrafo
- coordenada de parágrafo
- tamanho de parágrafo
- quadro de texto
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda como recuperar os limites de parágrafo no Aspose.Slides para PHP via Java para otimizar o posicionamento de texto em apresentações do PowerPoint."
---
## **Visão geral**

Este artigo explica como obter os limites, o tamanho e as coordenadas de parágrafos no Aspose.Slides. Ele mostra como recuperar um retângulo de parágrafo a partir de um [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/) usando [Paragraph::getRect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraph/getrect/), como obter as coordenadas do parágrafo dentro de um TextFrame de célula de tabela e destaca detalhes importantes como unidades de medida, o efeito da quebra de linha nos limites, conversão para pixels e valores de formatação de parágrafo efetivos.

## **Obter coordenadas retangulares de um parágrafo**

Use [Paragraph::getRect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraph/getrect/) para obter o retângulo delimitador de um parágrafo.

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $rectangle = $paragraph->getRect();
} finally {
    $presentation->dispose();
}
```

## **Obter o tamanho de um parágrafo dentro de um TextFrame de célula de tabela**

Para obter o tamanho e as coordenadas de um [Paragraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraph/) em um TextFrame de célula de tabela, use [Paragraph::getRect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraph/getrect/). O retângulo retornado é relativo ao TextFrame da célula da tabela, portanto adicione a posição da tabela e o deslocamento da célula quando precisar de coordenadas ao nível do slide.

O exemplo a seguir obtém os limites do parágrafo dentro de uma célula de tabela e desenha retângulos no slide para visualizar esses limites:

```php
$presentation = new Presentation("source.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $table = $slide->getShapes()->get_Item(0);
    $cell = $table->getRows()->get_Item(1)->get_Item(1);

    $cellX = java_values($table->getX()) + java_values($cell->getOffsetX());
    $cellY = java_values($table->getY()) + java_values($cell->getOffsetY());

    foreach ($cell->getTextFrame()->getParagraphs() as $paragraph) {
        if ($paragraph->getText() == "") {
            continue;
        }

        $paragraphRectangle = $paragraph->getRect();
        $paragraphRectangleX = java_values($paragraphRectangle->getX()) + $cellX;
        $paragraphRectangleY = java_values($paragraphRectangle->getY()) + $cellY;
        $paragraphRectangleWidth = java_values($paragraphRectangle->getWidth());
        $paragraphRectangleHeight = java_values($paragraphRectangle->getHeight());

        $paragraphBoundsShape = $slide->getShapes()->addAutoShape(
            ShapeType::Rectangle,
            $paragraphRectangleX,
            $paragraphRectangleY,
            $paragraphRectangleWidth,
            $paragraphRectangleHeight
        );

        $paragraphBoundsShape->getFillFormat()->setFillType(FillType::NoFill);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
        $paragraphBoundsShape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **FAQ**

**Em que unidades as coordenadas do parágrafo são medidas?**

São medidas em pontos, onde 1 polegada equivale a 72 pontos. Isso se aplica a todas as coordenadas e dimensões no slide.

**A quebra de linha afeta os limites de um parágrafo?**

Sim. Se [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframeformat/setwraptext/) estiver habilitado para o [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/), o texto será dividido para caber na largura da área, alterando os limites reais do parágrafo.

**As coordenadas do parágrafo podem ser mapeadas de forma confiável para pixels na imagem exportada?**

Sim. Converta pontos para pixels usando a fórmula: pixels = points x (DPI / 72). O resultado depende do DPI escolhido para renderização ou exportação.

**Como obter os parâmetros de formatação de parágrafo “efetivos”, levando em conta a herança de estilo?**

Use a [effective paragraph formatting data structure](/slides/pt/php-java/shape-effective-properties/); ela devolve os valores finais consolidados para recuos, espaçamento, quebra de linha, RTL e outros.