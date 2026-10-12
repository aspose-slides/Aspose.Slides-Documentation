---
title: Gerenciar Rótulos de Dados em Gráficos em Apresentações Usando Java
linktitle: Rótulo de Dados
type: docs
url: /pt/java/chart-data-label/
keywords:
- gráfico
- rótulo de dados
- precisão de dados
- porcentagem
- distância do rótulo
- localização do rótulo
- PowerPoint
- apresentação
- Java
- Aspose.Slides
description: "Aprenda a adicionar e formatar rótulos de dados em gráficos em apresentações do PowerPoint usando Aspose.Slides para Java para slides mais envolventes."
---
## **Introdução**

Os rótulos de dados exibem informações sobre as séries do gráfico e pontos de dados individuais, ajudando os leitores a identificar valores e compreender o gráfico. Este artigo explica como formatar valores, exibir porcentagens, ler o texto do rótulo, controlar rótulos além do máximo do eixo, ajustar o espaçamento dos rótulos do eixo de categorias e posicionar rótulos em gráficos de pizza.

## **Definir Precisão dos Dados em Rótulos de Dados do Gráfico**

Use [setNumberFormatOfValues](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) para formatar os valores das séries. Este exemplo cria um gráfico de linhas com dados padrão, exibe sua tabela de dados e habilita rótulos de valores para a primeira série. O formato `#,##0.00` exibe um separador de milhares e duas casas decimais sem alterar os valores subjacentes.

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

## **Exibir Porcentagem como Rótulos**

Para um gráfico de colunas empilhadas, calcule cada valor como porcentagem do total da sua categoria e atribua o texto ao quadro de texto retornado por [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--). Este exemplo usa os dados padrão do gráfico e exibe porcentagens com duas casas decimais em fonte de 8 pt. Categorias com total zero são ignoradas para evitar divisão por zero. Recalcule o texto personalizado do rótulo se os dados do gráfico mudarem.

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

## **Definir Sinal de Porcentagem nos Rótulos de Dados do Gráfico**

Quando os valores são armazenados como frações, use [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) para exibir porcentagens. Passe `false` para [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) para aplicar o formato do rótulo independentemente das células de origem.

Este exemplo cria um gráfico de colunas empilhadas 100 % com séries vermelha e azul em quatro categorias. Cada par de valores soma 1. O formato de rótulo `0.0%` exibe 0.30 como 30.0 %, enquanto o eixo vertical usa duas casas decimais. Ambas as séries usam texto de rótulo branco, tamanho 10 pt.

```java
import com.aspose.slides.*;
import java.awt.Color;

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
    Color[] seriesColors = { Color.RED, Color.BLUE };
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

Use [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) para obter o texto gerado pelas configurações de um rótulo de dados. Isso é útil ao extrair rótulos para relatórios, pesquisar conteúdo da apresentação ou validar gráficos gerados. No exemplo abaixo, o [formato padrão de rótulo de dados](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/) combina o nome da categoria, o nome da série e o valor. Um ponto formata seu valor como porcentagem, e outro usa texto personalizado de [getTextFrameForOverriding](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--).

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

O número armazenado em um ponto de dados permanece `0.75`, mesmo quando seu rótulo mostra `75 %` junto com os nomes da categoria e da série. Texto personalizado substitui o texto gerado do rótulo. [getActualLabelText](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#getActualLabelText--) retorna a string resultante do rótulo em ambos os casos. Verifique [isVisible](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabel/#isVisible--) separadamente, como mostrado acima, quando desejar extrair apenas rótulos visíveis.

## **Controlar Rótulos de Dados Além do Máximo do Eixo**

Quando você limita manualmente o intervalo de um eixo, alguns pontos de dados podem exceder seu máximo. Use [setShowDataLabelsOverMaximum](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setShowDataLabelsOverMaximum-boolean-) para controlar se seus rótulos de dados são exibidos. Essa configuração altera a visibilidade dos rótulos; não altera o intervalo do eixo nem os valores de dados subjacentes.

O exemplo abaixo cria um gráfico de colunas agrupadas 2D com valores 60 e 120. Ele passa `false` para [setAutomaticMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticMaxValue-boolean-) e define o máximo como 100 com [setMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMaxValue-double-) no eixo vertical. O primeiro slide permite rótulos além do máximo; uma cópia desse slide os desabilita. Ambos os slides são salvos em `DataLabelsOverMaximum.pptx`.

Habilite rótulos de valor com [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-). A configuração a nível de gráfico não habilita a exibição de valores por si só nem sobrescreve a exibição desabilitada de um rótulo individual. Este exemplo habilita valores para toda a série e usa [setPosition](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setPosition-int-) para posicionar os rótulos na extremidade externa de cada coluna.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(false);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    IChartDataCell firstCategory = workbook.getCell(0, 1, 0, "Within range");
    IChartDataCell secondCategory = workbook.getCell(0, 2, 0, "Above maximum");

    chart.getChartData().getCategories().add(firstCategory);
    chart.getChartData().getCategories().add(secondCategory);

    IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Values");
    IChartSeries series = chart.getChartData().getSeries().add(seriesName, chart.getType());

    IChartDataCell firstValue = workbook.getCell(0, 1, 1, 60);
    IChartDataCell secondValue = workbook.getCell(0, 2, 1, 120);

    series.getDataPoints().addDataPointForBarSeries(firstValue);
    series.getDataPoints().addDataPointForBarSeries(secondValue);

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getLabels().getDefaultDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);

    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(100);
    chart.setShowDataLabelsOverMaximum(true);

    ISlide secondSlide = presentation.getSlides().addClone(slide);
    IChart secondChart = (IChart) secondSlide.getShapes().get_Item(0);
    secondChart.setShowDataLabelsOverMaximum(false);

    presentation.save("DataLabelsOverMaximum.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

As imagens a seguir mostram os slides salvos renderizados pelo Microsoft PowerPoint. Com `true`, o rótulo **120** fica visível no limite superior; com `false`, ele fica oculto. O rótulo **60** permanece visível, o máximo do eixo permanece em **100** e o segundo ponto de dados continua **120** em ambos os casos.

| setShowDataLabelsOverMaximum(true) | setShowDataLabelsOverMaximum(false) |
| --- | --- |
| ![PowerPoint chart showing the value label 120 with an axis maximum of 100](data-labels-over-maximum-true.png) | ![PowerPoint chart hiding the value label 120 with an axis maximum of 100](data-labels-over-maximum-false.png) |

{{% alert color="info" title="Chart Type" %}}
Este exemplo usa um gráfico de colunas 2D com um eixo de valores. Gráficos sem eixo de valores, como gráficos de pizza e rosca, não possuem um máximo de eixo para limitar dessa forma.
{{% /alert %}}

## **Definir Distância do Rótulo a um Eixo**

Use [setLabelOffset](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setLabelOffset-int-) para controlar a distância entre os rótulos do eixo de categorias e o eixo. O valor é uma porcentagem do tamanho máximo da fonte dos rótulos do eixo. Este exemplo cria um gráfico de colunas agrupadas e define o deslocamento do rótulo do eixo horizontal para 500. Essa configuração afeta os rótulos do eixo de categorias, não os rótulos anexados a pontos de dados individuais.

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

## **Ajustar Localização do Rótulo**

Em um gráfico de pizza, ajuste as posições dos rótulos de dados para melhorar o espaçamento e abrir espaço para linhas de ligação.

Este exemplo exibe o valor do primeiro ponto de dados, coloca seu rótulo fora da fatia e ajusta seus deslocamentos horizontal e vertical usando [setX](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setX-float-) e [setY](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutable/#setY-float-). Esses deslocamentos são relativos à largura e altura do gráfico, respectivamente.

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

![Pie chart with an adjusted data label position](pie-chart-adjusted-label.png)

## **Adicionar Várias Linhas de Rótulos de Dados Acima de um Gráfico de Colunas**

Este exemplo cria um gráfico de colunas com duas linhas de rótulos de dados acima da área de plotagem. A Série A exibe as colunas visíveis, enquanto as Séries B e C fornecem os rótulos adicionais. Suas colunas são ocultas removendo o preenchimento e o contorno. O método [ChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/java/com.aspose.slides/chartseriesgroup/) alinha as três séries ao mesmo centro de categoria.

As configurações do [ChartPlotArea](https://reference.aspose.com/slides/java/com.aspose.slides/chartplotarea/) reservam espaço para as linhas de rótulo. Após [Chart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/) calcular as posições padrão, [DataLabel.setX and DataLabel.setY](https://reference.aspose.com/slides/java/com.aspose.slides/datalabel/) preservam o alinhamento horizontal e aplicam deslocamentos verticais para organizar os rótulos em duas linhas. Os números permanecem rótulos de dados vinculados aos valores das séries; somente os títulos das linhas são formas de texto separadas.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 40, 40, 640, 200);
    chart.setTitle(false);
    chart.setLegend(false);
    chart.getTextFormat().getPortionFormat().setFontHeight(12);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    String[] categories = {"North", "South", "East", "West"};
    String[] seriesNames = {"Series A", "Series B", "Series C"};
    double[][] seriesValues = {
            {35, 42, 28, 47},
            {22, 31, 19, 26},
            {12, 16, 14, 18}
    };

    for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
        chart.getChartData().getCategories().add(
                workbook.getCell(0, categoryIndex + 1, 0, categories[categoryIndex]));
    }

    for (int seriesIndex = 0; seriesIndex < seriesNames.length; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().add(
                workbook.getCell(0, 0, seriesIndex + 1, seriesNames[seriesIndex]),
                ChartType.ClusteredColumn);

        for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            series.getDataPoints().addDataPointForBarSeries(workbook.getCell(
                    0, categoryIndex + 1, seriesIndex + 1,
                    seriesValues[seriesIndex][categoryIndex]));
        }

        if (seriesIndex > 0) {
            // Ocultar as colunas de B e C, mas manter seus rótulos de dados.
            series.getFormat().getFill().setFillType(FillType.NoFill);
            series.getFormat().getLine().getFillFormat().setFillType(FillType.NoFill);
            series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
            series.getLabels().getDefaultDataLabelFormat()
                    .getTextFormat().getPortionFormat().setFontHeight(12);
            IFillFormat labelFill = series.getLabels().getDefaultDataLabelFormat()
                    .getTextFormat().getPortionFormat().getFillFormat();
            labelFill.setFillType(FillType.Solid);
            labelFill.getSolidFillColor().setColor(java.awt.Color.BLACK);
            series.getLabels().getDefaultDataLabelFormat().setPosition(
                    LegendDataLabelPosition.InsideBase);
        }
    }

    // Alinhar as três séries aos mesmos centros de categoria.
    chart.getChartData().getSeries().get_Item(0)
            .getParentSeriesGroup().setOverlap((byte) 100);

    // Usar menos linhas de grade neste exemplo compacto.
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setMajorUnit(10);

    // Reservar espaço acima da área de plotagem para duas linhas de rótulos de dados.
    chart.getPlotArea().setLayoutTargetType(LayoutTargetType.Inner);
    chart.getPlotArea().setX(0.15f);
    chart.getPlotArea().setY(0.32f);
    chart.getPlotArea().setWidth(0.80f);
    chart.getPlotArea().setHeight(0.48f);
    chart.validateChartLayout();

    for (int seriesIndex = 1; seriesIndex < seriesNames.length; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        float rowTop = seriesIndex == 1 ? 0.15f : 0.03f;

        for (int categoryIndex = 0; categoryIndex < categories.length; categoryIndex++) {
            IDataLabel dataLabel = series.getDataPoints().get_Item(categoryIndex).getLabel();
            // Manter a posição horizontal padrão. Y é um deslocamento a partir de
            // a posição padrão do rótulo, expressa como fração da altura do gráfico.
            dataLabel.setX(0);
            dataLabel.setY(rowTop - dataLabel.getActualY() / chart.getHeight());
        }

        // Somente o cabeçalho da linha é uma forma de texto separada.
        IAutoShape rowHeading = slide.getShapes().addAutoShape(
                ShapeType.Rectangle, chart.getX(),
                chart.getY() + rowTop * chart.getHeight(), 85, 18);
        rowHeading.getFillFormat().setFillType(FillType.NoFill);
        rowHeading.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
        rowHeading.addTextFrame(seriesNames[seriesIndex]);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginTop(0);
        rowHeading.getTextFrame().getTextFrameFormat().setMarginBottom(0);
        IPortionFormat headingFormat = rowHeading.getTextFrame().getParagraphs()
                .get_Item(0).getPortions().get_Item(0).getPortionFormat();
        headingFormat.setFontHeight(12);
        headingFormat.getFillFormat().setFillType(FillType.Solid);
        headingFormat.getFillFormat().getSolidFillColor().setColor(java.awt.Color.BLACK);
    }

    presentation.save("multiple-rows-of-labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Column chart with two rows of data labels above the plot area](multiple-rows-of-labels.png)

## **Perguntas Frequentes**

**Como posso impedir que os rótulos de dados se sobreponham em gráficos densos?**

Combine posicionamento automático de rótulos, linhas de ligação e redução do tamanho da fonte; se necessário, oculte alguns campos (por exemplo, a categoria) ou exiba rótulos apenas para valores extremos ou pontos chave.

**Como posso desativar rótulos apenas para valores zero, negativos ou vazios?**

Filtre os pontos de dados antes de habilitar rótulos e desative a exibição para valores 0, negativos ou ausentes conforme uma regra definida.

**Como garantir um estilo de rótulo consistente ao exportar para PDF/imagens?**

Defina explicitamente a família e o tamanho da fonte e verifique se a fonte está disponível no ambiente de renderização para evitar substituições.