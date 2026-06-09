---
title: Obter limites de parágrafo de apresentações em PHP
linktitle: Parágrafo
type: docs
weight: 60
url: /pt/php-java/paragraph/
keywords:
- limites de parágrafo
- limites de porção de texto
- coordenada de parágrafo
- coordenada de porção
- tamanho de parágrafo
- tamanho de porção de texto
- quadro de texto
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda como recuperar os limites de parágrafo e de porção de texto no Aspose.Slides para PHP via Java para otimizar o posicionamento de texto em apresentações PowerPoint."
---
## **Visão geral**

Este artigo explica como obter os limites, tamanho e coordenadas de parágrafos e trechos de texto no Aspose.Slides. Ele mostra como recuperar o retângulo de um parágrafo em um `TextFrame` usando `getRect()`, como obter as coordenadas do parágrafo e da porção dentro de um quadro de texto de célula de tabela, e destaca detalhes importantes como unidades de medida, o efeito da quebra de linha nos limites, conversão para pixels e valores de formatação efetiva de parágrafo.

## **Obter coordenadas de parágrafo e porção em um TextFrame**
Usando Aspose.Slides for PHP via Java, os desenvolvedores agora podem obter as coordenadas retangulares de um Parágrafo dentro da coleção de parágrafos de um TextFrame. Também permite obter [as coordenadas da porção](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/#getCoordinates) dentro da coleção de porções de um parágrafo. Neste tópico, vamos demonstrar com a ajuda de um exemplo como obter as coordenadas retangulares do parágrafo junto com a posição da porção dentro do parágrafo.

```php
  $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $textFrame = $shape->getTextFrame();
  foreach($textFrame->getParagraphs() as $paragraph) {
    foreach($paragraph->getPortions() as $portion) {
      $point = $portion->getCoordinates();
    }
  }
```

## **Obter coordenadas retangulares de um parágrafo**
Usando o método [**getRect()**](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraph/#getRect) os desenvolvedores podem obter o retângulo dos limites do parágrafo.

```php
  $pres = new Presentation("HelloWorld.pptx");
  try {
    $shape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textFrame = $shape->getTextFrame();
    $rect = $textFrame->getParagraphs()->get_Item(0)->getRect();
    echo("X: " . $rect->$x . " Y: " . $rect->$y . " Width: " . $rect->$width . " Height: " . $rect->$height);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Obter o tamanho de um parágrafo e de uma porção dentro de um TextFrame de célula de tabela**

Para obter o tamanho e as coordenadas da [Portion](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Portion) ou [Paragraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Paragraph) em um quadro de texto de célula de tabela, você pode usar os métodos [Portion::getRect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/#getRect) e [Paragraph::getRect](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraph/#getRect).

Este código de exemplo demonstra a operação descrita:

```php
  $pres = new Presentation("source.pptx");
  try {
    $tbl = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $cell = $tbl->getRows()->get_Item(1)->get_Item(1);
    $x = $tbl->getX() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetX();
    $y = $tbl->getY() + $tbl->getRows()->get_Item(1)->get_Item(1)->getOffsetY();
    foreach($cell->getTextFrame()->getParagraphs() as $para) {
      if ($para->getText()->equals("")) {
        continue;
      }
      $rect = $para->getRect();
      $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
      $shape->getFillFormat()->setFillType(FillType::NoFill);
      $shape->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->YELLOW);
      $shape->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
      foreach($para->getPortions() as $portion) {
        if ($portion->getText()->contains("0")) {
          $rect = $portion->getRect();
          $shape = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, $rect->getX() + $x, $rect->getY() + $y, $rect->getWidth(), $rect->getHeight());
          $shape->getFillFormat()->setFillType(FillType::NoFill);
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Perguntas frequentes**

**Em quais unidades as coordenadas retornadas para um parágrafo e trechos de texto são medidas?**

Em pontos, onde 1 polegada = 72 pontos. Isso se aplica a todas as coordenadas e dimensões no slide.

**A quebra de linha afeta os limites de um parágrafo?**

Sim. Se [wrapping](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframeformat/setwraptext/) estiver habilitado no [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/), o texto é quebrado para se ajustar à largura da área, o que altera os limites reais do parágrafo.

**As coordenadas do parágrafo podem ser mapeadas de forma confiável para pixels na imagem exportada?**

Sim. Converta pontos para pixels usando: pixels = points × (DPI / 72). O resultado depende do DPI escolhido para renderização/exportação.

**Como obtenho os parâmetros de formatação "efetiva" do parágrafo, levando em conta a herança de estilos?**

Use a [effective paragraph formatting data structure](/slides/pt/php-java/shape-effective-properties/); ele retorna os valores finais consolidados para recuos, espaçamento, quebra, RTL e mais.