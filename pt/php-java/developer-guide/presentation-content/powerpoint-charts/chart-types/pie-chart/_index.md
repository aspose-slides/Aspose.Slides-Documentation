---
title: Personalizar gráficos de pizza em apresentações usando PHP
linktitle: Gráfico de Pizza
type: docs
url: /pt/php-java/pie-chart/
keywords:
- gráfico de pizza
- gerenciar gráfico
- personalizar gráfico
- opções de gráfico
- configurações de gráfico
- opções de plotagem
- cor da fatia
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda como criar e personalizar gráficos de pizza com Aspose.Slides para PHP via Java, exportáveis para PowerPoint, impulsionando sua narrativa de dados em segundos."
---
## **Visão geral**

Este artigo explica como trabalhar com gráficos de pizza no Aspose.Slides. Ele mostra como configurar opções de plotagem secundária para gráficos Pie of Pie e Bar of Pie, e como habilitar a coloração automática das fatias em um gráfico de pizza padrão.

Os exemplos concentram‑se em etapas práticas de personalização de gráficos, como adicionar um gráfico a um slide, ajustar as configurações de séries e rótulos, substituir os dados padrão do gráfico por categorias e valores personalizados e salvar a apresentação atualizada.

## **Opções de Plotagem Secundária para Gráficos Pie of Pie e Bar of Pie**
Aspose.Slides for PHP via Java agora oferece suporte a opções de plotagem secundária para gráficos Pie of Pie ou Bar of Pie. Neste tópico, mostraremos como especificar essas opções usando Aspose.Slides. Para definir as propriedades, faça o seguinte:

1. Instanciar o objeto da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
1. Adicionar um gráfico ao slide.
1. Especificar as opções de plotagem secundária do gráfico.
1. Gravar a apresentação no disco.

No exemplo abaixo, definimos propriedades diferentes para um gráfico Pie of Pie.

```php
  # Criar uma instância da classe Presentation
  $pres = new Presentation();
  try {
    # Adicionar gráfico ao slide
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::PieOfPie, 50, 50, 500, 400);
    # Definir propriedades diferentes
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setSecondPieSize(149);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitBy(PieSplitType::ByPercentage);
    $chart->getChartData()->getSeries()->get_Item(0)->getParentSeriesGroup()->setPieSplitPosition(53);
    # Gravar apresentação no disco
    $pres->save("SecondPlotOptionsforCharts_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Definir Cores Automáticas das Fatias do Gráfico de Pizza**
Aspose.Slides for PHP via Java fornece uma API simples para definir cores automáticas das fatias de um gráfico de pizza. O código de exemplo aplica a configuração das propriedades mencionadas.

1. Criar uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
1. Acessar o primeiro slide.
1. Adicionar um gráfico com dados padrão.
1. Definir o Título do gráfico.
1. Definir a primeira série para Mostrar Valores.
1. Definir o índice da planilha de dados do gráfico.
1. Obter a planilha de dados do gráfico.
1. Excluir as séries e categorias geradas por padrão.
1. Adicionar novas categorias.
1. Adicionar novas séries.

Gravar a apresentação modificada em um arquivo PPTX.

```php
  # Criar uma instância da classe Presentation
  $pres = new Presentation();
  try {
    # Adicionar gráfico com dados padrão
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 100, 100, 400, 400);
    # Definir o título do gráfico
    $chart->getChartTitle()->addTextFrameForOverriding("Sample Title");
    $chart->getChartTitle()->getTextFrameForOverriding()->getTextFrameFormat()->setCenterText(NullableBool::True);
    $chart->getChartTitle()->setHeight(20);
    $chart->setTitle(true);
    # Definir a primeira série para Mostrar Valores
    $chart->getChartData()->getSeries()->get_Item(0)->getLabels()->getDefaultDataLabelFormat()->setShowValue(true);
    # Definir o índice da planilha de dados do gráfico
    $defaultWorksheetIndex = 0;
    # Obter a planilha de dados do gráfico
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Excluir as séries e categorias geradas por padrão
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Adicionar novas categorias
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 1, 0, "First Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 2, 0, "2nd Qtr"));
    $chart->getChartData()->getCategories()->add($fact->getCell(0, 3, 0, "3rd Qtr"));
    # Adicionar nova série
    $series = $chart->getChartData()->getSeries()->add($fact->getCell(0, 0, 1, "Series 1"), $chart->getType());
    # Agora preenchendo os dados da série
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForPieSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getParentSeriesGroup()->setColorVaried(true);
    $pres->save("Pie.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**As variações 'Pie of Pie' e 'Bar of Pie' são suportadas?**

Sim, a biblioteca [suporta](https://reference.aspose.com/slides/pt/php-java/aspose.slides/charttype/) um gráfico secundário para gráficos de pizza, incluindo os tipos 'Pie of Pie' e 'Bar of Pie'.

**Posso exportar apenas o gráfico como imagem (por exemplo, PNG)?**

Sim, você pode [exportar o próprio gráfico como imagem](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/#getImage) (como PNG) sem precisar exportar toda a apresentação.