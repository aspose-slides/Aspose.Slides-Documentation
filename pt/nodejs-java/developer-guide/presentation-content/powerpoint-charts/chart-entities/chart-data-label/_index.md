---
title: Gerenciar Rótulos de Dados de Gráficos em Apresentações Usando JavaScript
linktitle: Rótulo de Dados
type: docs
url: /pt/nodejs-java/chart-data-label/
keywords:
- gráfico
- rótulo de dados
- precisão dos dados
- porcentagem
- distância do rótulo
- localização do rótulo
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a adicionar e formatar rótulos de dados de gráficos em apresentações PowerPoint usando JavaScript e Aspose.Slides para Node.js via Java para slides mais envolventes."
---
## **Introdução**

Os rótulos de dados em um gráfico exibem detalhes sobre as séries de dados do gráfico ou pontos de dados individuais. Eles permitem que os leitores identifiquem rapidamente as séries de dados e também tornam os gráficos mais fáceis de entender.

## **Definir Precisão dos Dados nos Rótulos de Dados do Gráfico**

Este código JavaScript mostra como definir a precisão dos dados em um rótulo de dados do gráfico:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);
    chart.getChartData().getSeries().get_Item(0).setNumberFormatOfValues("#,##0.00");
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Exibir Porcentagem como Rótulos**

Aspose.Slides para Node.js via Java permite definir rótulos de porcentagem em gráficos exibidos. Este código JavaScript demonstra a operação:

```javascript
// Cria uma instância da classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Obtém o primeiro slide
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.StackedColumn, 20, 20, 400, 400);
    var series;
    var total_for_Cat = new double[chart.getChartData().getCategories().size()];
    for (var k = 0; k < chart.getChartData().getCategories().size(); k++) {
        var cat = chart.getChartData().getCategories().get_Item(k);
        for (var i = 0; i < chart.getChartData().getSeries().size(); i++) {
            total_for_Cat[k] = total_for_Cat[k] + chart.getChartData().getSeries().get_Item(i).getDataPoints().get_Item(k).getValue().getData();
        }
    }
    var dataPontPercent = 0.0;
    for (var x = 0; x < chart.getChartData().getSeries().size(); x++) {
        series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);
        for (var j = 0; j < series.getDataPoints().size(); j++) {
            var lbl = series.getDataPoints().get_Item(j).getLabel();
            dataPontPercent = (series.getDataPoints().get_Item(j).getValue().getData() / total_for_Cat[j]) * 100;
            var port = new aspose.slides.Portion();
            port.setText(java.callStaticMethodSync("java.lang.String", "format", "{0:F2} %.2f", dataPontPercent));
            port.getPortionFormat().setFontHeight(8.0);
            lbl.getTextFrameForOverriding().setText("");
            var para = lbl.getTextFrameForOverriding().getParagraphs().get_Item(0);
            para.getPortions().add(port);
            lbl.getDataLabelFormat().setShowSeriesName(false);
            lbl.getDataLabelFormat().setShowPercentage(false);
            lbl.getDataLabelFormat().setShowLegendKey(false);
            lbl.getDataLabelFormat().setShowCategoryName(false);
            lbl.getDataLabelFormat().setShowBubbleSize(false);
        }
    }
    // Salva a apresentação que contém o gráfico
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Definir Sinal de Porcentagem nos Rótulos de Dados do Gráfico**

Este código JavaScript mostra como definir o sinal de porcentagem para um rótulo de dados do gráfico:

```javascript
// Cria uma instância da classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Obtém a referência de um slide através do seu índice
    var slide = pres.getSlides().get_Item(0);
    // Cria o gráfico PercentsStackedColumn em um slide
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.PercentsStackedColumn, 20, 20, 500, 400);
    // Define NumberFormatLinkedToSource como false
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");
    chart.getChartData().getSeries().clear();
    var defaultWorksheetIndex = 0;
    // Obtém a planilha de dados do gráfico
    var workbook = chart.getChartData().getChartDataWorkbook();
    // Adiciona nova série
    var series = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 1, "Reds"), chart.getType());
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 1, 0.3));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 1, 0.5));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 1, 0.8));
    series.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 1, 0.65));
    // Define a cor de preenchimento da série
    series.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    // Define as propriedades do LabelFormat
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Adiciona nova série
    var series2 = chart.getChartData().getSeries().add(workbook.getCell(defaultWorksheetIndex, 0, 2, "Blues"), chart.getType());
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 1, 2, 0.7));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 2, 2, 0.5));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 3, 2, 0.2));
    series2.getDataPoints().addDataPointForBarSeries(workbook.getCell(defaultWorksheetIndex, 4, 2, 0.35));
    // Define o tipo de preenchimento e a cor
    series2.getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series2.getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    series2.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormatLinkedToSource(false);
    series2.getLabels().getDefaultDataLabelFormat().setNumberFormat("0.0%");
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().setFontHeight(10);
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    series2.getLabels().getDefaultDataLabelFormat().getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "WHITE"));
    // Grava a apresentação no disco
    pres.save("SetDataLabelsPercentageSign_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Definir Distância dos Rótulos ao Eixo**

Este código JavaScript mostra como definir a distância do rótulo a partir de um eixo de categoria ao trabalhar com um gráfico plotado a partir de eixos:

```javascript
// Cria uma instância da classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Obtém a referência de um slide
    var sld = pres.getSlides().get_Item(0);
    // Cria um gráfico no slide
    var ch = sld.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 20, 500, 300);
    // Define a distância do rótulo a partir de um eixo
    ch.getAxes().getHorizontalAxis().setLabelOffset(500);
    // Grava a apresentação no disco
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Ajustar Localização do Rótulo**

Ao criar um gráfico que não depende de nenhum eixo, como um gráfico de pizza, os rótulos de dados do gráfico podem acabar muito próximos de sua borda. Nesse caso, é necessário ajustar a localização do rótulo de dados para que as linhas de ligação sejam exibidas claramente.

Este código JavaScript mostra como ajustar a localização do rótulo em um gráfico de pizza:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 200, 200);
    var series = chart.getChartData().getSeries();
    var label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(aspose.slides.LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71);
    label.setY(0.04);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

![pie-chart-adjusted-label](pie-chart-adjusted-label.png)

## **Perguntas Frequentes**

**Como posso impedir que os rótulos de dados se sobreponham em gráficos densos?**

Combine o posicionamento automático de rótulos, linhas de ligação e tamanho de fonte reduzido; se necessário, oculte alguns campos (por exemplo, a categoria) ou exiba rótulos apenas para pontos extremos/chave.

**Como posso desativar rótulos apenas para valores zero, negativos ou vazios?**

Filtre os pontos de dados antes de habilitar os rótulos e desative a exibição para valores 0, valores negativos ou valores ausentes de acordo com uma regra definida.

**Como posso garantir um estilo de rótulo consistente ao exportar para PDF/imagens?**

Defina explicitamente as fontes (família, tamanho) e verifique se a fonte está disponível no lado de renderização para evitar fallback.