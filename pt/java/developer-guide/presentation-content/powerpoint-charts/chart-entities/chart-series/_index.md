---
title: Gerenciar Dados de Série de Gráficos em Apresentações Usando Java
linktitle: Séries de Dados
type: docs
url: /pt/java/chart-series/
keywords:
- séries de gráfico
- sobreposição de séries
- cor da série
- cor da categoria
- nome da série
- ponto de dados
- espaço da série
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Aprenda como gerenciar séries de gráficos em Java para PowerPoint (PPT/PPTX) com exemplos de código práticos e boas práticas para aprimorar suas apresentações de dados."
---
## **Visão geral**

Este artigo descreve o papel do [ChartSeries](https://reference.aspose.com/slides/pt/java/com.aspose.slides/chartseries/) no Aspose.Slides, enfocando como os dados são estruturados e visualizados dentro das apresentações. Esses objetos fornecem os elementos fundamentais que definem conjuntos individuais de pontos de dados, categorias e parâmetros de aparência em um gráfico. Ao trabalhar com [ChartSeries](https://reference.aspose.com/slides/pt/java/com.aspose.slides/chartseries/), os desenvolvedores podem integrar perfeitamente fontes de dados subjacentes e manter total controle sobre como as informações são exibidas, resultando em apresentações dinâmicas e baseadas em dados que transmitem claramente insights e análises.

Uma série é uma linha ou coluna de números plotados em um gráfico.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Definir a Sobreposição da Série de Gráfico**

Com a propriedade [IChartSeriesOverlap](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichartseries/properties/overlap), você pode especificar o quanto barras e colunas devem se sobrepor em um gráfico 2D (intervalo: -100 a 100). Essa propriedade se aplica a todas as séries do grupo de séries pai: é uma projeção da propriedade de grupo correspondente. Portanto, essa propriedade é somente leitura. 

Use a propriedade de leitura/gravação `ParentSeriesGroup.Overlap` para definir o valor desejado para `Overlap`. 

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
1. Adicione um gráfico de colunas agrupadas em um slide.
1. Acesse a primeira série do gráfico.
1. Acesse `ParentSeriesGroup` da série do gráfico e defina o valor de sobreposição desejado para a série. 
1. Grave a apresentação modificada em um arquivo PPTX. 

Este código Java mostra como definir a sobreposição para uma série de gráfico:

```java
Presentation pres = new Presentation();
try {
    // Adiciona gráfico
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0)
    {
        // Define a sobreposição da série
        series.get_Item(0).getParentSeriesGroup().setOverlap((byte)-30);
    }

    // Grava o arquivo de apresentação no disco
    pres.save("SetChartSeriesOverlap_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alterar a Cor da Série**

Aspose.Slides for Java permite alterar a cor de uma série da seguinte forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
1. Adicione um gráfico no slide.
1. Acesse a série cuja cor você deseja alterar. 
1. Defina o tipo de preenchimento e a cor de preenchimento desejados.
1. Salve a apresentação modificada. 

Este código Java mostra como alterar a cor de uma série:

```java
Presentation pres = new Presentation("test.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);

    point.setExplosion(30);
    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alterar a Cor da Categoria da Série**

Aspose.Slides for Java permite alterar a cor da categoria de uma série da seguinte forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
1. Adicione um gráfico no slide.
1. Acesse a categoria da série cuja cor você deseja alterar.
1. Defina o tipo de preenchimento e a cor de preenchimento desejados.
1. Salve a apresentação modificada. 

Este código em Java mostra como alterar a cor da categoria de uma série:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartDataPoint point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);

    point.getFormat().getFill().setFillType(FillType.Solid);
    point.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Alterar o Nome da Série** 

Por padrão, os nomes da legenda de um gráfico são o conteúdo das células acima de cada coluna ou linha de dados. 

Em nosso exemplo (imagem de exemplo), 

* as colunas são *Series 1, Series 2,* e *Series 3*;
* as linhas são *Category 1, Category 2, Category 3,* e *Category 4.* 

Aspose.Slides for Java permite atualizar ou alterar o nome de uma série em seus dados de gráfico e na legenda. 

Este código Java mostra como alterar o nome de uma série em seus dados de gráfico `ChartDataWorkbook`:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);

    IChartDataCell seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Este código Java mostra como alterar o nome de uma série em sua legenda através de `Series`:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    IStringChartValue name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) pres.dispose();
}
```

## **Definir a Cor de Preenchimento da Série de Gráfico**

Aspose.Slides for Java permite definir a cor de preenchimento automática para séries de gráfico dentro da área de plotagem da seguinte forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
1. Obtenha a referência de um slide pelo seu índice.
1. Adicione um gráfico com dados padrão com base no tipo desejado (no exemplo abaixo, usamos `ChartType.ClusteredColumn`).
1. Acesse a série do gráfico e defina a cor de preenchimento como Automatic.
1. Salve a apresentação em um arquivo PPTX. 

Este código Java mostra como definir a cor de preenchimento automática para uma série de gráfico:

```java
Presentation pres = new Presentation();
try {
    // Cria um gráfico de colunas agrupadas
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 50, 600, 400);

    // Define o formato de preenchimento da série como automático
    for (int i = 0; i < chart.getChartData().getSeries().size(); i++)
    {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }

    // Grava o arquivo de apresentação no disco
    pres.save("AutoFillSeries_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Definir Cor de Preenchimento Invertida para uma Série de Gráfico**

Aspose.Slides permite definir a cor de preenchimento invertida para séries de gráfico dentro da área de plotagem da seguinte forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
1. Obtenha a referência de um slide pelo seu índice.
1. Adicione um gráfico com dados padrão com base no tipo desejado (no exemplo abaixo, usamos `ChartType.ClusteredColumn`).
1. Acesse a série do gráfico e defina a cor de preenchimento como invert.
1. Salve a apresentação em um arquivo PPTX. 

Este código Java demonstra a operação:

```java
Color inverColor = Color.RED;
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    IChartDataWorkbook workBook = chart.getChartData().getChartDataWorkbook();

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Adiciona novas séries e categorias
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));

    // Obtém a primeira série do gráfico e preenche seus dados de série.
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    Color seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    
    pres.save("SetInvertFillColorChart_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Definir uma Série para Inverter Quando o Valor for Negativo**

Aspose.Slides permite definir inversões através das propriedades `IChartDataPoint.InvertIfNegative` e `ChartDataPoint.InvertIfNegative`. Quando uma inversão é definida usando essas propriedades, o ponto de dados inverte suas cores ao receber um valor negativo. 

Este código Java demonstra a operação:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();

    IChartSeries chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));

    chartSeries.setInvertIfNegative(false);

    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);

    pres.save("out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Limpar Dados de Pontos Específicos**

Aspose.Slides for Java permite limpar os dados de `DataPoints` de uma série de gráfico específica da seguinte forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
2. Obtenha a referência de um slide por seu índice.
3. Obtenha a referência de um gráfico por seu índice.
4. Itere por todos os `DataPoints` do gráfico e defina `XValue` e `YValue` como null.
5. Limpe todos os `DataPoints` para a série de gráfico específica.
6. Grave a apresentação modificada em um arquivo PPTX. 

Este código Java demonstra a operação:

```java
Presentation pres = new Presentation("TestChart.pptx");
try {
    ISlide sl = pres.getSlides().get_Item(0);

    IChart chart = (IChart)sl.getShapes().get_Item(0);

    for (IChartDataPoint dataPoint : chart.getChartData().getSeries().get_Item(0).getDataPoints())
    {
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }

    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();

    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Definir a Largura do Espaço da Série**

Aspose.Slides for Java permite definir a Largura do Espaço de uma série através da propriedade **`GapWidth`** da seguinte forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
1. Acesse o primeiro slide.
1. Adicione um gráfico com dados padrão.
1. Acesse qualquer série de gráfico.
1. Defina a propriedade `GapWidth`.
1. Grave a apresentação modificada em um arquivo PPTX. 

Este código em Java mostra como definir a Largura do Espaço de uma série:

```java
// Cria apresentação vazia 
Presentation pres = new Presentation();
try {
    // Acessa o primeiro slide da apresentação
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Adiciona um gráfico com dados padrão
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 0, 0, 500, 500);
    
    // Define o índice da planilha de dados do gráfico
    int defaultWorksheetIndex = 0;
    
    // Obtém a planilha de dados do gráfico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();
    
    // Adiciona séries
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    
    // Adiciona categorias
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    
    // Obtém a segunda série do gráfico
    IChartSeries series = chart.getChartData().getSeries().get_Item(1);
    
    // Preenche os dados da série
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    
    // Define o valor de GapWidth
    series.getParentSeriesGroup().setGapWidth(50);
    
    // Salva a apresentação no disco
    pres.save("GapWidth_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Existe um limite para quantas séries um único gráfico pode conter?**

O Aspose.Slides não impõe um limite fixo para o número de séries que você adiciona. O teto prático é definido pela legibilidade do gráfico e pela memória disponível para sua aplicação.

**E se as colunas dentro de um agrupamento estiverem muito próximas ou muito distantes?**

Ajuste a configuração `GapWidth` para essa série (ou seu grupo de séries pai). Aumentar o valor amplia o espaço entre as colunas, enquanto diminuir o valor as aproxima.