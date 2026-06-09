---
title: Adicionar formas de linha às apresentações em PHP
linktitle: Linha
type: docs
weight: 50
url: /pt/php-java/Line/
keywords:
- linha
- criar linha
- adicionar linha
- linha simples
- configurar linha
- personalizar linha
- estilo de traço
- ponta de seta
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda a manipular a formatação de linhas em apresentações PowerPoint com Aspose.Slides para PHP via Java. Descubra propriedades, métodos e exemplos."
---
## **Visão geral**

Aspose.Slides permite que você adicione formas de linha aos slides do PowerPoint programaticamente. Este artigo mostra como criar uma linha simples e como personalizar uma linha para que ela apareça como uma seta.

Você aprenderá como adicionar uma forma de linha a um slide, ajustar sua aparência visual e salvar a apresentação atualizada. Os exemplos se concentram em configurações práticas de formatação de linha, como estilo, largura, padrão de traços, opções de ponta de seta e cor de preenchimento.

## **Criar uma linha simples**

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
- Obtenha a referência de um slide usando seu Índice.
- Adicione um AutoShape do tipo Line usando o método [addAutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/#addAutoShape) exposto pelo objeto [ShapeCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/).
- Grave a apresentação modificada como um arquivo PPTX.

No exemplo abaixo, adicionamos uma linha ao primeiro slide da apresentação.

```php
  # Instanciar a classe PresentationEx que representa o arquivo PPTX
  $pres = new Presentation();
  try {
    # Obter o primeiro slide
    $sld = $pres->getSlides()->get_Item(0);
    # Adicionar um AutoShape do tipo linha
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Gravar o PPTX no disco
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Criar uma linha em forma de seta**

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
- Obtenha a referência de um slide usando seu Índice.
- Adicione um AutoShape do tipo Line usando o método [addAutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/#addAutoShape) exposto pelo objeto [ShapeCollection](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapecollection/).
- Defina o [Estilo de linha](https://reference.aspose.com/slides/pt/php-java/aspose.slides/LineStyle) para um dos estilos oferecidos pelo Aspose.Slides for PHP via Java.
- Defina a Largura da linha.
- Defina o [Dash Style](https://reference.aspose.com/slides/pt/php-java/aspose.slides/LineDashStyle) da linha para um dos estilos oferecidos pelo Aspose.Slides for PHP via Java.
- Defina o [Arrow Head Style](https://reference.aspose.com/slides/pt/php-java/aspose.slides/LineArrowheadStyle) e o [Length](https://reference.aspose.com/slides/pt/php-java/aspose.slides/LineArrowheadLength) do ponto inicial da linha.
- Defina o [Arrow Head Style](https://reference.aspose.com/slides/pt/php-java/aspose.slides/LineArrowheadStyle) e o [Length](https://reference.aspose.com/slides/pt/php-java/aspose.slides/LineArrowheadLength) do ponto final da linha.
- Grave a apresentação modificada como um arquivo PPTX.

```php
  # Instanciar a classe PresentationEx que representa o arquivo PPTX
  $pres = new Presentation();
  try {
    # Obter o primeiro slide
    $sld = $pres->getSlides()->get_Item(0);
    # Adicionar um AutoShape do tipo linha
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Aplicar alguma formatação na linha
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # Gravar o PPTX no disco
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Perguntas frequentes**

**Posso converter uma linha regular em um conector para que ela “encaixe” nas formas?**

Não. Uma linha regular (um [AutoShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/) do tipo [Line](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shapetype/)) não se transforma automaticamente em um conector. Para que ela se encaixe nas formas, use o tipo [Connector](https://reference.aspose.com/slides/pt/php-java/aspose.slides/connector/) dedicado e as [corresponding APIs](/slides/pt/php-java/connector/) para conexões.

**O que devo fazer se as propriedades de uma linha forem herdadas do tema e for difícil determinar os valores finais?**

[Leia as propriedades efetivas](/slides/pt/php-java/shape-effective-properties/) através de `LineFormatEffectiveData`/`LineFillFormatEffectiveData` — elas já consideram a herança e os estilos do tema.

**Posso bloquear uma linha contra edição (movimento, redimensionamento)?**

Sim. As formas fornecem [lock objects](https://reference.aspose.com/slides/pt/php-java/aspose.slides/autoshape/getautoshapelock/) que permitem impedir operações de edição.