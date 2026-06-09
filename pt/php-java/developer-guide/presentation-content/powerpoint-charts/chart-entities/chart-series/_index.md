---
title: Gerenciar Séries de Dados de Gráficos em Apresentações Usando PHP
linktitle: Séries de Dados
type: docs
url: /pt/php-java/chart-series/
keywords:
- séries de gráfico
- sobreposição de séries
- cor da série
- cor da categoria
- nome da série
- ponto de dados
- intervalo da série
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Aprenda a gerenciar séries de dados de gráficos em PHP para PowerPoint (PPT/PPTX) com exemplos de código práticos e melhores práticas para aprimorar suas apresentações de dados."
---
## **Visão geral**

Este artigo descreve o papel de [ChartSeries](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartseries/) no Aspose.Slides, focando em como os dados são estruturados e visualizados dentro de apresentações. Esses objetos fornecem os elementos fundamentais que definem conjuntos individuais de pontos de dados, categorias e parâmetros de aparência em um gráfico. Ao trabalhar com [ChartSeries](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartseries/), os desenvolvedores podem integrar perfeitamente fontes de dados subjacentes e manter controle total sobre como as informações são exibidas, resultando em apresentações dinâmicas e orientadas por dados que transmitem claramente percepções e análises.

Uma série é uma linha ou coluna de números plotada em um gráfico.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Definir a sobreposição da série de gráfico**

Com o método [getParentSeriesGroup](https://reference.aspose.com/slides/pt/php-java/aspose.slides/chartseries/#getParentSeriesGroup), você pode especificar quanto as barras e colunas devem se sobrepor em um gráfico 2D (intervalo: -100 a 100). Essa propriedade se aplica a todas as séries do grupo de séries pai: é uma projeção da propriedade de grupo apropriada. Portanto, essa propriedade é somente leitura.

Use o método `ChartSeriesGroup::setOverlap` para definir o valor desejado para `Overlap`.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
1. Adicione um gráfico de colunas agrupadas em um slide.
1. Acesse a primeira série do gráfico.
1. Acesse o `ParentSeriesGroup` da série de gráfico e defina o valor de sobreposição desejado para a série. 
1. Grave a apresentação modificada em um arquivo PPTX.

Este código PHP mostra como definir a sobreposição para uma série de gráfico:

```php
  $pres = new Presentation();
  try {
    # Adiciona gráfico
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    if (java_values($series->get_Item(0)->getOverlap()) == 0) {
      # Define a sobreposição da série
      $series->get_Item(0)->getParentSeriesGroup()->setOverlap(-30);
    }
    # Grava o arquivo de apresentação no disco
    $pres->save("SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Alterar a cor da série**

Aspose.Slides for PHP via Java permite que você altere a cor de uma série da seguinte maneira:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
1. Adicione um gráfico no slide.
1. Acesse a série cuja cor você deseja alterar. 
1. Defina o tipo de preenchimento e a cor de preenchimento desejados.
1. Salve a apresentação modificada.

Este código PHP mostra como alterar a cor de uma série:

```php
  $pres = new Presentation("test.pptx");
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Pie, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(1);
    $point->setExplosion(30);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Alterar a cor da categoria da série**

Aspose.Slides for PHP via Java permite que você altere a cor de uma categoria de série da seguinte maneira:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
1. Adicione um gráfico no slide.
1. Acesse a categoria da série cuja cor você deseja alterar.
1. Defina o tipo de preenchimento e a cor de preenchimento desejados.
1. Salve a apresentação modificada.

Este código mostra como alterar a cor de uma categoria de série:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
    $point = $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->get_Item(0);
    $point->getFormat()->getFill()->setFillType(FillType::Solid);
    $point->getFormat()->getFill()->getSolidFillColor()->setColor(java("java.awt.Color")->BLUE);
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Alterar o nome da série** 

Por padrão, os nomes da legenda de um gráfico são o conteúdo das células acima de cada coluna ou linha de dados. 

Em nosso exemplo (imagem de amostra):

* as colunas são *Series 1, Series 2,* e *Series 3*;
* as linhas são *Category 1, Category 2, Category 3,* e *Category 4.* 

Aspose.Slides for PHP via Java permite que você atualize ou altere o nome de uma série em seus dados de gráfico e na legenda.

Este código PHP mostra como alterar o nome de uma série nos dados do gráfico `ChartDataWorkbook`:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $seriesCell = $chart->getChartData()->getChartDataWorkbook()->getCell(0, 0, 1);
    $seriesCell->setValue("New name");
    $pres->save("pres.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Este código PHP mostra como alterar o nome de uma série na legenda através de `Series`:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::Column3D, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $name = $series->getName();
    $name->getAsCells()->get_Item(0)->setValue("New name");
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Definir a cor de preenchimento da série de gráfico**

Aspose.Slides for PHP via Java permite que você defina a cor de preenchimento automática para séries de gráfico dentro de uma área de plotagem da seguinte maneira:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
1. Obtenha a referência de um slide pelo seu índice.
1. Adicione um gráfico com dados padrão com base no tipo preferido (no exemplo abaixo, usamos `ChartType::ClusteredColumn`).
1. Acesse a série do gráfico e defina a cor de preenchimento como Automática.
1. Salve a apresentação em um arquivo PPTX.

Este código PHP mostra como definir a cor de preenchimento automática para uma série de gráfico:

```php
  $pres = new Presentation();
  try {
    # Cria um gráfico de colunas agrupadas
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 50, 600, 400);
    # Define o formato de preenchimento da série como automático
    for($i = 0; $i < java_values($chart->getChartData()->getSeries()->size()) ; $i++) {
      $chart->getChartData()->getSeries()->get_Item($i)->getAutomaticSeriesColor();
    }
    # Grava o arquivo de apresentação no disco
    $pres->save("AutoFillSeries_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Definir preenchimento invertido para uma série de gráfico**

Aspose.Slides permite que você defina o preenchimento invertido para séries de gráfico dentro de uma área de plotagem da seguinte maneira:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
1. Obtenha a referência de um slide pelo seu índice.
1. Adicione um gráfico com dados padrão com base no tipo preferido (no exemplo abaixo, usamos `ChartType::ClusteredColumn`).
1. Acesse a série do gráfico e defina o preenchimento como invertido.
1. Salve a apresentação em um arquivo PPTX.

Este código PHP demonstra a operação:

```php
  $inverColor = java("java.awt.Color")->RED;
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 100, 100, 400, 300);
    $workBook = $chart->getChartData()->getChartDataWorkbook();
    $chart->getChartData()->getSeries()->clear();
    $chart->getChartData()->getCategories()->clear();
    # Adiciona novas séries e categorias
    $chart->getChartData()->getSeries()->add($workBook->getCell(0, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 1, 0, "Category 1"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 2, 0, "Category 2"));
    $chart->getChartData()->getCategories()->add($workBook->getCell(0, 3, 0, "Category 3"));
    # Obtém a primeira série do gráfico e preenche os dados da série.
    $series = $chart->getChartData()->getSeries()->get_Item(0);
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 1, 1, -20));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($workBook->getCell(0, 3, 1, -30));
    $seriesColor = $series->getAutomaticSeriesColor();
    $series->setInvertIfNegative(true);
    $series->getFormat()->getFill()->setFillType(FillType::Solid);
    $series->getFormat()->getFill()->getSolidFillColor()->setColor($seriesColor);
    $series->getInvertedSolidFillColor()->setColor($inverColor);
    $pres->save("SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Definir uma série para inverter quando o valor for negativo**

Aspose.Slides permite que você defina inversões através das propriedades `IChartDataPoint.InvertIfNegative` e `ChartDataPoint.InvertIfNegative`. Quando uma inversão é definida usando essas propriedades, o ponto de dados inverte suas cores ao receber um valor negativo. 

Este código PHP demonstra a operação:

```php
  $pres = new Presentation();
  try {
    $chart = $pres->getSlides()->get_Item(0)->getShapes()->addChart(ChartType::ClusteredColumn, 50, 50, 600, 400, true);
    $series = $chart->getChartData()->getSeries();
    $chart->getChartData()->getSeries()->clear();
    $chartSeries = $series->add($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B1"), $chart->getType());
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B2", -5));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B3", 3));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B4", -2));
    $chartSeries->getDataPoints()->addDataPointForBarSeries($chart->getChartData()->getChartDataWorkbook()->getCell(0, "B5", 1));
    $chartSeries->setInvertIfNegative(false);
    $chartSeries->getDataPoints()->get_Item(2)->setInvertIfNegative(true);
    $pres->save("out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Limpar dados de ponto específico**

Aspose.Slides for PHP via Java permite que você limpe os dados `DataPoints` de uma série de gráfico específica da seguinte maneira:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide pelo seu índice.
3. Obtenha a referência de um gráfico pelo seu índice.
4. Percorra todos os `DataPoints` do gráfico e defina `XValue` e `YValue` como nulos.
5. Limpe todos os `DataPoints` de uma série de gráfico específica.
6. Grave a apresentação modificada em um arquivo PPTX.

Este código PHP demonstra a operação:

```php
  $pres = new Presentation("TestChart.pptx");
  try {
    $sl = $pres->getSlides()->get_Item(0);
    $chart = $sl->getShapes()->get_Item(0);
    foreach($chart->getChartData()->getSeries()->get_Item(0)->getDataPoints() as $dataPoint) {
      $dataPoint->getXValue()->getAsCell()->setValue(null);
      $dataPoint->getYValue()->getAsCell()->setValue(null);
    }
    $chart->getChartData()->getSeries()->get_Item(0)->getDataPoints()->clear();
    $pres->save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Definir a largura do intervalo da série**

Aspose.Slides for PHP via Java permite que você defina a largura do intervalo de uma série através da propriedade **`GapWidth`** da seguinte maneira:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/Presentation).
1. Acesse o primeiro slide.
1. Adicione um gráfico com dados padrão.
1. Acesse qualquer série do gráfico.
1. Defina a propriedade `GapWidth`.
1. Grave a apresentação modificada em um arquivo PPTX.

Este código mostra como definir a largura do intervalo de uma série:

```php
  # Cria apresentação vazia
  $pres = new Presentation();
  try {
    # Acessa o primeiro slide da apresentação
    $slide = $pres->getSlides()->get_Item(0);
    # Adiciona um gráfico com dados padrão
    $chart = $slide->getShapes()->addChart(ChartType::StackedColumn, 0, 0, 500, 500);
    # Define o índice da planilha de dados do gráfico
    $defaultWorksheetIndex = 0;
    # Obtém a planilha de dados do gráfico
    $fact = $chart->getChartData()->getChartDataWorkbook();
    # Adiciona séries
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 1, "Series 1"), $chart->getType());
    $chart->getChartData()->getSeries()->add($fact->getCell($defaultWorksheetIndex, 0, 2, "Series 2"), $chart->getType());
    # Adiciona categorias
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    $chart->getChartData()->getCategories()->add($fact->getCell($defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    # Obtém a segunda série do gráfico
    $series = $chart->getChartData()->getSeries()->get_Item(1);
    # Preenche os dados da série
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 1, 20));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 1, 50));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 1, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 1, 2, 30));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 2, 2, 10));
    $series->getDataPoints()->addDataPointForBarSeries($fact->getCell($defaultWorksheetIndex, 3, 2, 60));
    # Define o valor de GapWidth
    $series->getParentSeriesGroup()->setGapWidth(50);
    # Salva a apresentação no disco
    $pres->save("GapWidth_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Existe um limite para a quantidade de séries que um único gráfico pode conter?**

Aspose.Slides não impõe um limite fixo ao número de séries que você adiciona. O teto prático é definido pela legibilidade do gráfico e pela memória disponível para sua aplicação.

**E se as colunas dentro de um agrupamento estiverem muito próximas ou muito afastadas?**

Ajuste a configuração `GapWidth` para essa série (ou seu grupo de séries pai). Aumentar o valor amplia o espaço entre as colunas, enquanto diminuí‑lo as aproxima.