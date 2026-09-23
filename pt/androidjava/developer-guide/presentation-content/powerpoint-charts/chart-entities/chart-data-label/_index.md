---
title: Gerenciar Rótulos de Dados de Gráficos em Apresentações no Android
linktitle: Rótulo de Dados
type: docs
url: /pt/androidjava/chart-data-label/
keywords:
- gráfico
- rótulo de dados
- precisão dos dados
- percentual
- distância do rótulo
- localização do rótulo
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Aprenda a adicionar e formatar rótulos de dados de gráficos em apresentações PowerPoint usando Aspose.Slides para Android via Java para slides mais envolventes."
---
## **Introdução**

Os rótulos de dados exibem informações sobre as séries do gráfico e pontos de dados individuais, ajudando os leitores a identificar valores e compreender o gráfico. Este artigo explica como formatar valores, exibir percentuais, ler o texto do rótulo, ajustar o espaçamento dos rótulos do eixo de categorias e posicionar os rótulos em gráficos de pizza.

## **Definir Precisão dos Dados nos Rótulos de Dados do Gráfico**

Use [setNumberFormatOfValues](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) para formatar os valores da série. Este exemplo cria um gráfico de linhas com dados padrão, exibe sua tabela de dados e habilita os rótulos de valor para a primeira série. O formato `#,##0.00` exibe um separador de milhares e duas casas decimais sem alterar os valores subjacentes.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Exibir Percentuais como Rótulos**

Para um gráfico de colunas empilhadas, calcule cada valor como percentual de seu total de categoria e atribua o texto ao quadro de texto retornado por [getTextFrameForOverriding](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--). Este exemplo usa os dados padrão do gráfico e exibe percentuais com duas casas decimais em uma fonte de 8 pontos. Categorias com total zero são ignoradas para evitar divisão por zero. Recalcule o texto do rótulo personalizado se os dados do gráfico mudarem.

```java
import com.aspose.slides.*;
import java.util.Locale;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400);

    double[] categoryTotals = new double[chart.getChartData().getCategories().size()];
    for (int k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (int i = 0; i < chart.getChartData().getSeries().size(); i++) {
            IChartSeries series = chart.getChartData().getSeries().get_Item(i);
            Number pointValue = (Number) series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += pointValue.doubleValue();
        }
    }

    for (int x = 0; x < chart.getChartData().getSeries().size(); x++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (int j = 0; j < series.getDataPoints().size(); j++) {
            IDataLabel label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            Number pointValue = (Number) series.getDataPoints().get_Item(j).getValue().getData();
            double dataPointPercent = (pointValue.doubleValue() / categoryTotals[j]) * 100;

            IPortion portion = new Portion();
            portion.setText(String.format(Locale.US, "%.2f %%", dataPointPercent));
            portion.getPortionFormat().setFontHeight(8f);

            label.getTextFrameForOverriding().setText("");
            IParagraph paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir o Símbolo de Percentual nos Rótulos de Dados do Gráfico**

Quando os valores são armazenados como frações, use [setNumberFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) para exibir percentuais. Passe `false` para [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) para aplicar o formato do rótulo independentemente das células de origem.

Este exemplo cria um gráfico de colunas empilhadas 100% com séries vermelha e azul em quatro categorias. Cada par de valores soma 1. O formato de rótulo `0.0%` exibe 0,30 como 30,0%, enquanto o eixo vertical usa duas casas decimais. Ambas as séries usam texto de rótulo branco, tamanho 10.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    for (int i = 0; i < 4; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    String[] seriesNames = { "Reds", "Blues" };
    int[] seriesColors = { Color.RED, Color.BLUE };
    double[][] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

    for (int i = 0; i < seriesNames.length; i++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (int j = 0; j < 4; j++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(FillType.Solid);
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        IDataLabelFormat labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ler o Texto Real dos Rótulos de Dados**

Use [getActualLabelText](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--) para obter o texto gerado pelas configurações de um rótulo de dados. Isso é útil ao extrair rótulos para relatórios, pesquisar conteúdo da apresentação ou validar gráficos gerados. No exemplo abaixo, o [formato de rótulo de dados](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/idatalabelformat/) padrão combina o nome de cada categoria, o nome da série e o valor. Um ponto formata seu valor como percentual, e outro usa texto personalizado de [getTextFrameForOverriding](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    IChartDataCell secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    IChartDataCell northSeriesCell = workbook.getCell(0, 0, 1, "North");
    IChartSeries north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    IChartDataCell northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    IChartDataCell northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    IChartDataCell southSeriesCell = workbook.getCell(0, 0, 2, "South");
    IChartSeries south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    IChartDataCell southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    IChartDataCell southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (IChartSeries series : chart.getChartData().getSeries()) {
        for (IChartDataPoint point : series.getDataPoints()) {
            IDataLabel label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            System.out.println("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

O número armazenado em um ponto de dados permanece `0.75`, mesmo quando seu rótulo mostra `75%` junto com os nomes da categoria e da série. Texto personalizado substitui o texto gerado do rótulo. [getActualLabelText](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--) retorna a string de rótulo resultante em ambos os casos. Verifique [isVisible](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/idatalabel/#isVisible--) separadamente, como mostrado acima, quando desejar extrair apenas os rótulos visíveis.

## **Definir a Distância do Rótulo em Relação a um Eixo**

Use [setLabelOffset](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iaxis/#setLabelOffset-int-) para controlar a distância entre os rótulos do eixo de categorias e o eixo. O valor é uma porcentagem do tamanho máximo da fonte dos rótulos do eixo. Este exemplo cria um gráfico de colunas agrupadas e define o deslocamento do rótulo do eixo horizontal para 500. Essa configuração afeta os rótulos do eixo de categorias, e não os rótulos associados a pontos de dados individuais.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ajustar a Posicionamento dos Rótulos**

Em um gráfico de pizza, ajuste as posições dos rótulos de dados para melhorar o espaçamento e criar espaço para as linhas de chamada.

Este exemplo exibe o valor do primeiro ponto de dados, posiciona seu rótulo fora da fatia e ajusta seus deslocamentos horizontal e vertical usando [setX](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilayoutable/#setX-float-) e [setY](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ilayoutable/#setY-float-). Esses deslocamentos são relativos à largura e à altura do gráfico, respectivamente.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    IDataLabel label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71f);
    label.setY(0.04f);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Gráfico de pizza com posição de rótulo de dados ajustada](pie-chart-adjusted-label.png)

## **Perguntas frequentes**

**Como posso impedir que os rótulos de dados se sobreponham em gráficos densos?**

Combine posicionamento automático de rótulos, linhas de chamada e tamanho de fonte reduzido; se necessário, oculte alguns campos (por exemplo, a categoria) ou mostre rótulos somente para valores extremos ou pontos‑chave.

**Como posso desativar rótulos apenas para valores zero, negativos ou vazios?**

Filtre os pontos de dados antes de habilitar os rótulos e desative a exibição para valores 0, valores negativos ou valores ausentes conforme uma regra definida.

**Como garantir um estilo de rótulo consistente ao exportar para PDF/imagens?**

Defina explicitamente a família e o tamanho da fonte e verifique se a fonte está disponível no ambiente de renderização para evitar o fallback.