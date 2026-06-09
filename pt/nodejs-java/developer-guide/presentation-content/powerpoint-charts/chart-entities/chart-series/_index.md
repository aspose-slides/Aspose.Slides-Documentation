---
title: Gerenciar Séries de Dados de Gráficos em Apresentações Usando JavaScript
linktitle: Séries de Dados
type: docs
url: /pt/nodejs-java/chart-series/
keywords:
- séries de gráfico
- sobreposição de séries
- cor da série
- cor da categoria
- nome da série
- ponto de dados
- espaçamento da série
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda como gerenciar séries de gráficos em JavaScript para PowerPoint (PPT/PPTX) com exemplos práticos de código e boas práticas para melhorar suas apresentações de dados."
---
## **Visão geral**

Este artigo descreve o papel do [ChartSeries](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartseries/) no Aspose.Slides, concentrando‑se em como os dados são estruturados e visualizados em apresentações. Esses objetos fornecem os elementos fundamentais que definem conjuntos individuais de pontos de dados, categorias e parâmetros de aparência em um gráfico. Ao trabalhar com [ChartSeries](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartseries/), os desenvolvedores podem integrar perfeitamente fontes de dados subjacentes e manter controle total sobre como as informações são exibidas, resultando em apresentações dinâmicas e baseadas em dados que transmitem claramente insights e análises.

Uma série é uma linha ou coluna de números plotados em um gráfico.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Definir sobreposição da série de gráfico**

Com o método [ChartSeries.getOverlap](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chartseries/#getOverlap), você pode especificar o quanto as barras e colunas devem se sobrepor em um gráfico 2D (intervalo: -100 a 100). Essa propriedade se aplica a todas as séries do grupo de séries pai: é uma projeção da propriedade de grupo apropriada. Portanto, essa propriedade é somente leitura.

Use a propriedade de leitura/gravação `ParentSeriesGroup.getOverlap` para definir o valor desejado para `Overlap`.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
1. Adicione um gráfico de colunas agrupadas em um slide.
1. Acesse a primeira série do gráfico.
1. Acesse o `ParentSeriesGroup` da série do gráfico e defina o valor de sobreposição desejado para a série.
1. Grave a apresentação modificada em um arquivo PPTX.

Este código JavaScript mostra como definir a sobreposição para uma série de gráfico:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Adiciona gráfico
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    if (series.get_Item(0).getOverlap() == 0) {
        // Define sobreposição da série
        series.get_Item(0).getParentSeriesGroup().setOverlap(-30);
    }
    // Grava o arquivo de apresentação no disco
    pres.save("SetChartSeriesOverlap_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Alterar cor da série**

Aspose.Slides para Node.js via Java permite alterar a cor de uma série desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
1. Adicione um gráfico no slide.
1. Acesse a série cuja cor você deseja alterar.
1. Defina o tipo de preenchimento e a cor de preenchimento desejados.
1. Salve a apresentação modificada.

Este código JavaScript mostra como alterar a cor de uma série:

```javascript
var pres = new aspose.slides.Presentation("test.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(1);
    point.setExplosion(30);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Alterar cor da categoria da série**

Aspose.Slides para Node.js via Java permite alterar a cor da categoria de uma série desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
1. Adicione um gráfico no slide.
1. Acesse a categoria da série cuja cor você deseja alterar.
1. Defina o tipo de preenchimento e a cor de preenchimento desejados.
1. Salve a apresentação modificada.

Este código JavaScript mostra como alterar a cor da categoria de uma série:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var point = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(0);
    point.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    point.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Alterar nome da série**

Por padrão, os nomes da legenda de um gráfico são o conteúdo das células acima de cada coluna ou linha de dados.

Em nosso exemplo (imagem de exemplo),

* as colunas são *Series 1, Series 2,* e *Series 3*;
* as linhas são *Category 1, Category 2, Category 3,* e *Category 4.* 

Aspose.Slides para Node.js via Java permite atualizar ou alterar o nome de uma série em seus dados de gráfico e na legenda.

Este código JavaScript mostra como alterar o nome de uma série nos dados do gráfico `ChartDataWorkbook`:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var seriesCell = chart.getChartData().getChartDataWorkbook().getCell(0, 0, 1);
    seriesCell.setValue("New name");
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Este código JavaScript mostra como alterar o nome de uma série na sua legenda através de `Series`:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries().get_Item(0);
    var name = series.getName();
    name.getAsCells().get_Item(0).setValue("New name");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Definir cor de preenchimento da série de gráfico**

Aspose.Slides para Node.js via Java permite definir a cor de preenchimento automática para séries de gráfico dentro da área de plotagem desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
1. Obtenha a referência de um slide pelo seu índice.
1. Adicione um gráfico com dados padrão com base no seu tipo preferido (no exemplo abaixo, usamos `ChartType.ClusteredColumn`).
1. Acesse as séries do gráfico e defina a cor de preenchimento como Automatic.
1. Salve a apresentação em um arquivo PPTX.

Este código JavaScript mostra como definir a cor de preenchimento automática para uma série de gráfico:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Cria um gráfico de colunas agrupadas
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 50, 600, 400);
    // Define o formato de preenchimento da série como automático
    for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
        chart.getChartData().getSeries().get_Item(i).getAutomaticSeriesColor();
    }
    // Grava o arquivo de apresentação no disco
    pres.save("AutoFillSeries_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Definir cores de preenchimento invertidas da série de gráfico**

Aspose.Slides permite definir a cor de preenchimento invertida para séries de gráfico dentro da área de plotagem desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
1. Obtenha a referência de um slide pelo seu índice.
1. Adicione um gráfico com dados padrão com base no seu tipo preferido (no exemplo abaixo, usamos `ChartType.ClusteredColumn`).
1. Acesse as séries do gráfico e defina a cor de preenchimento como invert.
1. Salve a apresentação em um arquivo PPTX.

Este código JavaScript demonstra a operação:

```javascript
var inverColor = java.getStaticFieldValue("java.awt.Color", "RED");
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 400, 300);
    var workBook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Adiciona novas séries e categorias
    chart.getChartData().getSeries().add(workBook.getCell(0, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getCategories().add(workBook.getCell(0, 1, 0, "Category 1"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 2, 0, "Category 2"));
    chart.getChartData().getCategories().add(workBook.getCell(0, 3, 0, "Category 3"));
    // Obtém a primeira série do gráfico e preenche seus dados de série.
    var series = chart.getChartData().getSeries().get_Item(0);
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 1, 1, -20));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(workBook.getCell(0, 3, 1, -30));
    var seriesColor = series.getAutomaticSeriesColor();
    series.setInvertIfNegative(true);
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(seriesColor);
    series.getInvertedSolidFillColor().setColor(inverColor);
    pres.save("SetInvertFillColorChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Definir série para inverter quando o valor for negativo**

Aspose.Slides permite definir inversões através do método `ChartDataPoint.setInvertIfNegative`. Quando uma inversão é definida usando as propriedades, o ponto de dados inverte suas cores quando recebe um valor negativo.

Este código JavaScript demonstra a operação:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    chart.getChartData().getSeries().clear();
    var chartSeries = series.add(chart.getChartData().getChartDataWorkbook().getCell(0, "B1"), chart.getType());
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B2", -5));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B3", 3));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B4", -2));
    chartSeries.getDataPoints().addDataPointForBarSeries(chart.getChartData().getChartDataWorkbook().getCell(0, "B5", 1));
    chartSeries.setInvertIfNegative(false);
    chartSeries.getDataPoints().get_Item(2).setInvertIfNegative(true);
    pres.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Limpar dados de pontos de dados específicos**

Aspose.Slides para Node.js via Java permite limpar os dados de `DataPoints` para uma série de gráfico específica desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
2. Obtenha a referência de um slide por seu índice.
3. Obtenha a referência de um gráfico por seu índice.
4. Percorra todos os `DataPoints` do gráfico e defina `XValue` e `YValue` como nulo.
5. Limpe todos os `DataPoints` para séries de gráfico específicas.
6. Grave a apresentação modificada em um arquivo PPTX.

Este código JavaScript demonstra a operação:

```javascript
var pres = new aspose.slides.Presentation("TestChart.pptx");
try {
    var sl = pres.getSlides().get_Item(0);
    var chart = sl.getShapes().get_Item(0);
    for (let i = 0; i < chart.getChartData().getSeries().get_Item(0).getDataPoints().size(); i++) {
        let dataPoint = chart.getChartData().getSeries().get_Item(0).getDataPoints().get_Item(i);
        dataPoint.getXValue().getAsCell().setValue(null);
        dataPoint.getYValue().getAsCell().setValue(null);
    }
    chart.getChartData().getSeries().get_Item(0).getDataPoints().clear();
    pres.save("ClearSpecificChartSeriesDataPointsData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Definir largura do intervalo da série**

Aspose.Slides para Node.js via Java permite definir a Largura do Espaçamento de uma série através da propriedade **`GapWidth`** desta forma:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
1. Acesse o primeiro slide.
1. Adicione um gráfico com dados padrão.
1. Acesse qualquer série do gráfico.
1. Defina a propriedade `GapWidth`.
1. Grave a apresentação modificada em um arquivo PPTX.

Este código JavaScript mostra como definir a Largura do Espaçamento de uma série:

```javascript
// Cria apresentação vazia
var pres = new aspose.slides.Presentation();
try {
    // Acessa o primeiro slide da apresentação
    var slide = pres.getSlides().get_Item(0);
    // Adiciona um gráfico com dados padrão
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 0, 0, 500, 500);
    // Define o índice da planilha de dados do gráfico
    var defaultWorksheetIndex = 0;
    // Obtém a planilha de dados do gráfico
    var fact = chart.getChartData().getChartDataWorkbook();
    // Adiciona séries
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 1, "Series 1"), chart.getType());
    chart.getChartData().getSeries().add(fact.getCell(defaultWorksheetIndex, 0, 2, "Series 2"), chart.getType());
    // Adiciona categorias
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 1, 0, "Caetegoty 1"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 2, 0, "Caetegoty 2"));
    chart.getChartData().getCategories().add(fact.getCell(defaultWorksheetIndex, 3, 0, "Caetegoty 3"));
    // Obtém a segunda série do gráfico
    var series = chart.getChartData().getSeries().get_Item(1);
    // Popula os dados da série
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 1, 2, 30));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 2, 2, 10));
    series.getDataPoints().addDataPointForBarSeries(fact.getCell(defaultWorksheetIndex, 3, 2, 60));
    // Define o valor de GapWidth
    series.getParentSeriesGroup().setGapWidth(50);
    // Salva a apresentação no disco
    pres.save("GapWidth_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Existe um limite para a quantidade de séries que um único gráfico pode conter?**

O Aspose.Slides não impõe um limite fixo na quantidade de séries que você adiciona. O teto prático é determinado pela legibilidade do gráfico e pela memória disponível para sua aplicação.

**E se as colunas dentro de um cluster estiverem muito próximas ou muito afastadas?**

Ajuste a configuração de Largura do Espaçamento (Gap Width) para essa série (ou seu grupo de séries pai). Aumentar o valor amplia o espaço entre as colunas, enquanto diminuí‑lo as aproxima.