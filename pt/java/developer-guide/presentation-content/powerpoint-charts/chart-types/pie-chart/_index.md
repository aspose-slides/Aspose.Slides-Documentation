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
description: "Aprenda a criar e personalizar gráficos de pizza em Java com Aspose.Slides, exportáveis para PowerPoint, impulsionando a narrativa dos seus dados em segundos."
---
## **Visão geral**

Este artigo explica como trabalhar com gráficos de pizza no Aspose.Slides. Ele mostra como configurar opções de segundo gráfico para gráficos Pie of Pie e Bar of Pie, e como habilitar a coloração automática das fatias para um gráfico de pizza padrão.

Os exemplos concentram‑se em etapas práticas de personalização de gráficos, como adicionar um gráfico a um slide, ajustar as configurações de séries e rótulos, substituir os dados padrão do gráfico por categorias e valores personalizados e salvar a apresentação atualizada.

## **Opções de Segundo Gráfico para Gráficos Pie of Pie e Bar of Pie**

O Aspose.Slides for Java agora oferece suporte a opções de segundo gráfico para os tipos Pie of Pie ou Bar of Pie. Neste tópico, mostraremos como especificar essas opções usando o Aspose.Slides. Para definir as propriedades, siga estas etapas:

1. Instancie o objeto da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
2. Adicione um gráfico ao slide.
3. Especifique as opções de segundo gráfico do gráfico.
4. Grave a apresentação no disco.

No exemplo abaixo, definimos diferentes propriedades do gráfico Pie of Pie.

```java
// Crie uma instância da classe Presentation
Presentation pres = new Presentation();
try {
    // Adicione o gráfico ao slide
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.PieOfPie, 50, 50, 500, 400);
    
    // Defina diferentes propriedades
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    
    // Grave a apresentação no disco
    pres.save("SecondPlotOptionsforCharts_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Definir Cores Automáticas das Fatias do Gráfico de Pizza**

O Aspose.Slides for Java fornece uma API simples para definir cores automáticas das fatias de um gráfico de pizza. O código de exemplo aplica a definição das propriedades mencionadas acima.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/java/com.aspose.slides/Presentation).
2. Acesse o primeiro slide.
3. Adicione um gráfico com dados padrão.
4. Defina o título do gráfico.
5. Configure a primeira série para Mostrar valores.
6. Defina o índice da planilha de dados do gráfico.
7. Obtenha a planilha de dados do gráfico.
8. Exclua as séries e categorias geradas por padrão.
9. Adicione novas categorias.
10. Adicione novas séries.

Grave a apresentação modificada em um arquivo PPTX.

```java
// Crie uma instância da classe Presentation
Presentation pres = new Presentation();
try {
    // Adicione o gráfico com dados padrão
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 100, 100, 400, 400);

    // Definindo o título do gráfico
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);

    // Defina a primeira série para Mostrar Valores
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    // Definindo o índice da planilha de dados do gráfico
    int defaultWorksheetIndex = 0;

    // Obtendo a planilha de dados do gráfico
    IChartDataWorkbook fact = chart.getChartData().getChartDataWorkbook();

    // Excluir séries e categorias geradas por padrão
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    // Adicionando novas categorias
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));

    // Adicionando novas séries
    IChartSeries series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());

    // Agora preenchendo os dados da série
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));

    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**As variações 'Pie of Pie' e 'Bar of Pie' são suportadas?**

Sim, a biblioteca [suporta](https://reference.aspose.com/slides/pt/java/com.aspose.slides/charttype/) um segundo gráfico para gráficos de pizza, incluindo os tipos 'Pie of Pie' e 'Bar of Pie'.

**Posso exportar apenas o gráfico como imagem (por exemplo, PNG)?**

Sim, você pode [exportar o próprio gráfico como imagem](https://reference.aspose.com/slides/pt/java/com.aspose.slides/shape/#getImage-int-float-float-) (como PNG) sem precisar da apresentação completa.