---
title: Personalizar legendas de gráficos em apresentações usando PHP
linktitle: Legenda do Gráfico
type: docs
url: /pt/php-java/chart-legend/
keywords:
- legenda de gráfico
- posição da legenda
- tamanho da fonte
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Personalize legendas de gráficos com Aspose.Slides for PHP via Java para otimizar apresentações PowerPoint com formatação de legenda sob medida."
---
## **Visão geral**

O Aspose.Slides fornece opções para personalizar legendas de gráficos em apresentações do PowerPoint. Este artigo mostra como posicionar e dimensionar uma legenda, definir o tamanho da fonte para toda a legenda e aplicar formatação a uma entrada de legenda individual.

Ele também cobre vários comportamentos relacionados nas Perguntas Frequentes, incluindo o uso do modo sem sobreposição para que a área de plotagem reserve espaço para a legenda, permitir que rótulos longos de legenda quebrem em linhas ou usem quebras de linha, e permitir que a formatação da legenda herde do tema da apresentação quando configurações explícitas de texto e preenchimento não são aplicadas.

## **Posicionamento da legenda**
Para definir as propriedades da legenda, siga as etapas abaixo:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
- Obtenha a referência do slide.
- Adicione um gráfico ao slide.
- Defina as propriedades da legenda.
- Grave a apresentação como um arquivo PPTX.

No exemplo abaixo, definimos a posição e o tamanho da legenda do gráfico.

```php
  # Criar uma instância da classe Presentation
  $pres = new Presentation();
  try {
    # Obter referência do slide
    $slide = $pres->getSlides()->get_Item(0);
    # Adicionar um gráfico de colunas agrupadas no slide
    $chart = $slide->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 500, 500);
    # Definir propriedades da legenda
    $chart->getLegend()->setX(50 / $chart->getWidth());
    $chart->getLegend()->setY(50 / $chart->getHeight());
    $chart->getLegend()->setWidth(100 / $chart->getWidth());
    $chart->getLegend()->setHeight(100 / $chart->getHeight());
    # Gravar a apresentação no disco
    $pres->save("Legend_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Definir o tamanho da fonte de uma legenda**
O Aspose.Slides for PHP via Java permite que os desenvolvedores definam o tamanho da fonte da legenda. Siga os passos abaixo:

- Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
- Crie o gráfico padrão.
- Defina o tamanho da fonte.
- Defina o valor mínimo do eixo.
- Defina o valor máximo do eixo.
- Grave a apresentação em disco.

```php
  # Criar uma instância da classe Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $chart->getLegend()->getTextFormat()->getPortionFormat()->setFontHeight(20);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMinValue(false);
    $chart->getAxes()->getVerticalAxis()->setMinValue(-5);
    $chart->getAxes()->getVerticalAxis()->setAutomaticMaxValue(false);
    $chart->getAxes()->getVerticalAxis()->setMaxValue(10);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Definir o tamanho da fonte de uma legenda individual**
O Aspose.Slides for PHP via Java permite que os desenvolvedores definam o tamanho da fonte das entradas individuais da legenda. Siga os passos abaixo:

- Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
- Crie o gráfico padrão.
- Acesse a entrada da legenda.
- Defina o tamanho da fonte.
- Defina o valor mínimo do eixo.
- Defina o valor máximo do eixo.
- Grave a apresentação em disco.

```php
  # Criar uma instância da classe Presentation
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $tf = $chart->getLegend()->getEntries()->get_Item(1)->getTextFormat();
    $tf->getPortionFormat()->setFontBold(NullableBool::True);
    $tf->getPortionFormat()->setFontHeight(20);
    $tf->getPortionFormat()->setFontItalic(NullableBool::True);
    $tf->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $tf->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Perguntas frequentes**

**Posso ativar a legenda de modo que o gráfico reserve automaticamente espaço para ela em vez de sobrepô‑la?**

Sim. Use o modo sem sobreposição ([setOverlay(false)](https://reference.aspose.com/slides/pt/php-java/aspose.slides/legend/setoverlay/)); neste caso, a área de plotagem será reduzida para acomodar a legenda.

**Posso criar rótulos de legenda em várias linhas?**

Sim. Rótulos longos são quebrados automaticamente quando o espaço é insuficiente; quebras de linha forçadas são suportadas por meio de caracteres de nova linha no nome da série.

**Como faço para que a legenda siga o esquema de cores do tema da apresentação?**

Não defina cores, preenchimentos ou fontes explícitas para a legenda ou seu texto. Eles herdarão do tema e serão atualizados corretamente quando o design mudar.