---
title: Personalizar gráficos de pizza em apresentações usando Java
linktitle: Gráfico de Pizza
type: docs
url: /pt/java/pie-chart/
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
- Java
- Aspose.Slides
description: "Crie e personalize gráficos de pizza em Java com Aspose.Slides. Configure plotagens secundárias, exiba rótulos de dados e aplique cores automáticas às fatias no PowerPoint."
---
## **Visão geral**

Este artigo explica como trabalhar com gráficos de pizza no Aspose.Slides. Ele mostra como configurar opções de plotagem secundária para gráficos Pie of Pie e Bar of Pie, e como habilitar a coloração automática de fatias para um gráfico de pizza padrão.

Os exemplos se concentram em tarefas de personalização de gráficos, como adicionar um gráfico a um slide, ajustar as configurações de séries e rótulos, substituir os dados padrão do gráfico por categorias e valores personalizados e salvar a apresentação atualizada.

## **Opções de Plotagem Secundária para Gráficos Pie of Pie e Bar of Pie**

O Aspose.Slides for Java oferece suporte a opções de plotagem secundária para gráficos Pie of Pie e Bar of Pie. Essas opções controlam o tamanho da plotagem secundária e como os pontos de dados são divididos entre as duas plotagens.

O exemplo a seguir cria um gráfico Pie of Pie em uma nova apresentação e exibe os valores dos pontos de dados como rótulos. O método [setSecondPieSize](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setSecondPieSize-int-) define o tamanho da plotagem secundária para 149% da plotagem principal. [setPieSplitBy](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) seleciona a divisão baseada em percentual, e [setPieSplitPosition](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitPosition-double-) define o limite para 53%.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    // Exibir valores e configurar a plotagem secundária.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setSecondPieSize(149);
    seriesGroup.setPieSplitBy(PieSplitType.ByPercentage);
    seriesGroup.setPieSplitPosition(53);

    presentation.save("pie_of_pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Selecionar Categorias para a Plotagem Secundária**

Use a divisão personalizada quando desejar agrupar categorias específicas na plotagem secundária independentemente de seus valores percentuais. Por exemplo, um relatório de vendas pode mostrar Online e Eventos juntos para que os leitores comparem esses dois canais, embora representem 35% e 10% das vendas totais.

Chame [setPieSplitBy](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setPieSplitBy-int-) com [PieSplitType.Custom](https://reference.aspose.com/slides/java/com.aspose.slides/piesplittype/#Custom) e selecione os pontos através de [getPieSplitCustomPoints](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#getPieSplitCustomPoints--). O método [add](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#add-int-) da coleção aceita um índice baseado em zero na série; use [addItem](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#addItem-com.aspose.slides.IChartDataPoint-) para adicionar um objeto de ponto de dados. Neste exemplo, o índice 1 seleciona Online e o ponto no índice 3 seleciona Eventos. Partners também é adicionado temporariamente, e depois excluído usando [removeItem](https://reference.aspose.com/slides/java/com.aspose.slides/piesplitcustompointcollection/#removeItem-com.aspose.slides.IChartDataPoint-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.PieOfPie, 50, 50, 600, 200);

    // Substitua os dados padrão por vendas por canal.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "Retail", "Online", "Partners", "Events" };
    int[] values = { 40, 35, 15, 10 };
    IChartDataCell seriesNameCell = workbook.getCell(0, 0, 1, "Sales");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    IChartSeriesGroup seriesGroup = series.getParentSeriesGroup();
    seriesGroup.setPieSplitBy(PieSplitType.Custom);
    seriesGroup.setColorVaried(true);

    // Selecione Online pelo seu índice baseado em zero e Eventos pelo seu objeto de ponto de dados.
    seriesGroup.getPieSplitCustomPoints().add(1);
    seriesGroup.getPieSplitCustomPoints().addItem(series.getDataPoints().get_Item(3));

    // Exclua Partners da seleção sem remover seus dados de origem.
    seriesGroup.getPieSplitCustomPoints().add(2);
    seriesGroup.getPieSplitCustomPoints().removeItem(series.getDataPoints().get_Item(2));

    presentation.save("pie_of_pie_custom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Online (35) e Eventos (10) aparecem como fatias separadas na plotagem secundária. Na plotagem principal, eles são representados por uma única fatia combinada com valor 45, juntamente com Varejo (40) e Partners (15). Remover Partners da seleção personalizada mantém‑o na plotagem principal; não remove a categoria ou seu valor dos dados de origem do gráfico.

A imagem a seguir mostra a apresentação salva no PowerPoint:

![Gráfico Pie of Pie com Online e Eventos na plotagem secundária e seu valor combinado de 45 na plotagem principal](pie_of_pie_custom.png)

## **Definir Cores Automáticas para Fatias de Gráfico de Pizza**

O Aspose.Slides for Java pode atribuir automaticamente cores diferentes às fatias de um gráfico de pizza. O exemplo a seguir cria um gráfico de pizza com um título centralizado e substitui os dados padrão por três categorias trimestrais e seus valores. O método [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) exibe os valores 20, 50 e 30 como rótulos, enquanto [setColorVaried](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setColorVaried-boolean-) habilita uma cor distinta para cada fatia.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Adicionar um título de gráfico centralizado.
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Substituir os dados padrão usando a primeira planilha.
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    String[] categoryNames = { "First Qtr", "2nd Qtr", "3rd Qtr" };
    int[] values = { 20, 50, 30 };
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, 0, 1, "Series 1");
    IChartSeries series = chart.getChartData().getSeries().add(seriesNameCell, chart.getType());

    for (int i = 0; i < categoryNames.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, categoryNames[i]);
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForPieSeries(valueCell);
    }

    // Mostrar valores e atribuir cores diferentes às fatias.
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);
    series.getParentSeriesGroup().setColorVaried(true);

    presentation.save("pie.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Perguntas frequentes**

**As variações Pie of Pie e Bar of Pie são suportadas?**

Sim, a biblioteca [suporta](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) uma plotagem secundária para gráficos de pizza, incluindo os tipos Pie of Pie e Bar of Pie.

**Posso exportar apenas o gráfico como imagem (por exemplo, PNG)?**

Sim, você pode [exportar o próprio gráfico como imagem](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) (por exemplo PNG) sem exportar a apresentação completa.