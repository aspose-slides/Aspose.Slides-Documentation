---
title: Adicionar Elipses a Apresentações em PHP
linktitle: Elipse
type: docs
weight: 30
url: /pt/php-java/ellipse/
keywords:
- elipse
- forma
- adicionar elipse
- criar elipse
- desenhar elipse
- elipse formatada
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda a criar, formatar e manipular formas de elipse no Aspose.Slides para PHP via Java em apresentações PPT e PPTX — exemplos de código incluídos."
---
## **Visão geral**

Este artigo mostra como adicionar formas de elipse aos slides do PowerPoint usando Aspose.Slides. Ele aborda a criação de uma elipse simples, a criação de uma elipse formatada e a gravação da apresentação atualizada como um arquivo PPTX. Também aborda questões relacionadas, como trabalhar com a posição e o tamanho da elipse, controlar a ordem de empilhamento e aplicar efeitos de animação.

## **Criar uma elipse**
Para adicionar uma elipse simples a um slide selecionado da apresentação, siga as etapas abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation).
- Obtenha a referência de um slide usando seu Índice.
- Adicione um AutoShape do tipo Ellipse usando o método [addAutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/#addAutoShape) exposto pelo objeto [ShapeCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/).
- Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, adicionamos uma elipse ao primeiro slide

```php
  # Instanciar a classe Presentation que representa o PPTX
  $pres = new Presentation();
  try {
    # Obter o primeiro slide
    $sld = $pres->getSlides()->get_Item(0);
    # Adicionar AutoShape do tipo elipse
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Gravar o arquivo PPTX no disco
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Criar uma elipse formatada**
Para adicionar uma elipse melhor formatada a um slide, siga as etapas abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation).
- Obtenha a referência de um slide usando seu Índice.
- Adicione um AutoShape do tipo Ellipse usando o método [addAutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/#addAutoShape) exposto pelo objeto [ShapeCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/).
- Defina o Fill Type da Elipse como Solid.
- Defina a Cor da Elipse usando o método `SolidFillColor::setColor` exposto pelo objeto [FillFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/fillformat/) associado ao objeto [Shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/).
- Defina a Cor das linhas da Elipse.
- Defina a Largura das linhas da Elipse.
- Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, adicionamos uma elipse formatada ao primeiro slide da apresentação.

```php
  # Instanciar a classe Presentation que representa o PPTX
  $pres = new Presentation();
  try {
    # Obter o primeiro slide
    $sld = $pres->getSlides()->get_Item(0);
    # Adicionar AutoShape do tipo elipse
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Aplicar alguma formatação à forma de elipse
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # Aplicar alguma formatação à linha da elipse
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Gravar o arquivo PPTX no disco
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Perguntas frequentes**

**Como defino a posição exata e o tamanho de uma elipse em relação às unidades do slide?**

As coordenadas e os tamanhos geralmente são especificados **em pontos**. Para resultados previsíveis, baseie seus cálculos no tamanho do slide e converta milímetros ou polegadas necessários para pontos antes de atribuir os valores.

**Como posicionar uma elipse acima ou abaixo de outros objetos (controlar ordem de empilhamento)?**

Ajuste a ordem de desenho do objeto trazendo-o para a frente ou enviando-o para trás. Isso permite que a elipse sobreponha outros objetos ou revele os que estão abaixo dela.

**Como animar a aparição ou ênfase de uma elipse?**

[Apply](/slides/pt/php-java/shape-animation/) efeitos de entrada, ênfase ou saída à forma e configure gatilhos e temporização para orquestrar quando e como a animação será reproduzida.