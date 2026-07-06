---
title: Obter limites da porção de texto em apresentações PHP
linktitle: Limites da Porção
type: docs
weight: 47
url: /pt/php-java/portion-bounds/
keywords:
- limites da porção de texto
- porção de texto
- parte de texto
- coordenadas de texto
- posição de texto
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda como recuperar os limites da porção de texto em apresentações PowerPoint usando Aspose.Slides para PHP via Java."
---
## **Visão geral**

Uma porção de texto representa um fragmento específico de texto dentro de um parágrafo e permite que você trabalhe com esse fragmento de forma independente do conteúdo ao redor. No Aspose.Slides, as porções podem ser usadas quando você precisa recuperar os limites de um fragmento de texto, aplicar formatação apenas a parte de um parágrafo ou controlar o comportamento do texto em um nível mais detalhado.

Este artigo mostra como obter o retângulo delimitador de uma porção usando [Portion::getRect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/getrect/). Também mostra como obter as coordenadas do início de uma porção usando [Portion::getCoordinates](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/getcoordinates/). Além disso, destaca cenários comuns relacionados a porções, como aplicar um hyperlink a um único fragmento de texto, entender como a formatação é resolvida através da herança de porção, parágrafo, caixa de texto e tema, e lidar com casos em que uma fonte especificada não está disponível.

## **Obter limites de uma porção de texto**

Use [Portion::getRect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/getrect/) para recuperar o retângulo delimitador de uma porção de texto:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $rectangle = $portion->getRect();
            $rectangleX = java_values($rectangle->getX());
            $rectangleY = java_values($rectangle->getY());
            $rectangleWidth = java_values($rectangle->getWidth());
            $rectangleHeight = java_values($rectangle->getHeight());

            echo("X = " . $rectangleX . "; Y = " . $rectangleY . "; Width = " . $rectangleWidth . "; Height = " . $rectangleHeight);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Obter coordenadas de uma porção de texto**

Use [Portion::getCoordinates](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/getcoordinates/) para recuperar as coordenadas do início de uma porção de texto:

```php
$presentation = new Presentation("Shapes.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    foreach ($shape->getTextFrame()->getParagraphs() as $paragraph) {
        foreach ($paragraph->getPortions() as $portion) {
            $point = $portion->getCoordinates();
            $pointX = java_values($point->getX());
            $pointY = java_values($point->getY());

            echo("X = " . $pointX . "; Y = " . $pointY);
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Perguntas frequentes**

**Posso aplicar um hyperlink apenas a parte do texto dentro de um único parágrafo?**

Sim, você pode [atribuir um hyperlink](/slides/pt/php-java/manage-hyperlinks/) a uma porção individual; apenas esse fragmento será clicável, não todo o parágrafo.

**Como funciona a herança de estilo: o que uma porção sobrescreve e o que é herdado de um parágrafo ou caixa de texto?**

As propriedades ao nível da Porção têm a maior precedência. Se uma propriedade não estiver definida na [Portion](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/), o Aspose.Slides a obtém do [Paragraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraph/). Se também não estiver definida lá, o Aspose.Slides usa o estilo da [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/) ou do [theme](https://reference.aspose.com/slides/pt/php-java/aspose.slides/theme/).

**O que acontece se a fonte especificada para uma porção estiver ausente na máquina ou servidor de destino?**

As [regras de substituição de fontes](/slides/pt/php-java/font-selection-sequence/) são aplicadas. O texto pode ser reformatado: métricas, hifenação e largura podem mudar, o que é importante para posicionamento preciso.

**Posso definir transparência de preenchimento de texto ou um gradiente específico da porção independentemente do restante do parágrafo?**

Sim, a cor do texto, o preenchimento e a transparência ao nível da [Portion](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/) podem ser diferentes dos fragmentos vizinhos.