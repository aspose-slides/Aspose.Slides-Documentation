---
title: Personalizar Gráficos de Pizza em Apresentações Usando JavaScript
linktitle: Gráfico de Pizza
type: docs
url: /pt/nodejs-java/pie-chart/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aprenda a criar e personalizar gráficos de pizza em JavaScript com Aspose.Slides para Node.js, exportáveis para PowerPoint, impulsionando sua narrativa de dados em segundos."
---
## **Visão geral**

Este artigo explica como trabalhar com gráficos de pizza no Aspose.Slides. Ele mostra como configurar opções de plot secundário para gráficos Pie of Pie e Bar of Pie, e como habilitar a coloração automática das fatias para um gráfico de pizza padrão.

Os exemplos focam em etapas práticas de personalização de gráficos, como adicionar um gráfico a um slide, ajustar as configurações de séries e rótulos, substituir os dados padrão do gráfico por categorias e valores personalizados, e salvar a apresentação atualizada.

## **Opções de Plot Secundário para Gráficos Pie of Pie e Bar of Pie**

O Aspose.Slides para Node.js via Java agora suporta opções de plot secundário para gráficos Pie of Pie ou Bar of Pie. Neste tópico, mostraremos como especificar essas opções usando Aspose.Slides. Para especificar as propriedades, siga estas etapas:

1. Instancie o objeto da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
1. Adicione o gráfico ao slide.
1. Especifique as opções de plot secundário do gráfico.
1. Grave a apresentação no disco.

No exemplo abaixo, definimos diferentes propriedades do gráfico Pie of Pie.

```javascript
// Criar uma instância da classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Adicionar gráfico ao slide
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.PieOfPie, 50, 50, 500, 400);
    // Definir diferentes propriedades
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setSecondPieSize(149);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitBy(aspose.slides.PieSplitType.ByPercentage);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setPieSplitPosition(53);
    // Gravar apresentação no disco
    pres.save("SecondPlotOptionsforCharts_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Definir Cores Automáticas das Fatias do Gráfico de Pizza**

O Aspose.Slides para Node.js via Java fornece uma API simples para definir cores automáticas das fatias do gráfico de pizza. O código de exemplo aplica a configuração das propriedades mencionadas acima.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/Presentation).
1. Acesse o primeiro slide.
1. Adicione um gráfico com dados padrão.
1. Defina o título do gráfico.
1. Configure a primeira série para Exibir Valores.
1. Defina o índice da planilha de dados do gráfico.
1. Obtenha a planilha de dados do gráfico.
1. Exclua as séries e categorias geradas por padrão.
1. Adicione novas categorias.
1. Adicione novas séries.

Grave a apresentação modificada em um arquivo PPTX.

```javascript
// Criar uma instância da classe Presentation
var pres = new aspose.slides.Presentation();
try {
    // Adicionar gráfico com dados padrão
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 100, 100, 400, 400);
    // Definir título do gráfico
    chart.getChartTitle().addTextFrameForOverriding("Sample Title");
    chart.getChartTitle().getTextFrameForOverriding().getTextFrameFormat().setCenterText(aspose.slides.NullableBool.True);
    chart.getChartTitle().setHeight(20);
    chart.setTitle(true);
    // Definir a primeira série para mostrar valores
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);
    // Definir o índice da planilha de dados do gráfico
    var defaultWorksheetIndex = 0;
    // Obter a planilha de dados do gráfico
    var fact = chart.getChartData().getChartDataWorkbook();
    // Excluir séries e categorias geradas por padrão
    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();
    // Adicionar novas categorias
    chart.getChartData().getCategories().add(fact.getCell(0, 1, 0, "First Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 2, 0, "2nd Qtr"));
    chart.getChartData().getCategories().add(fact.getCell(0, 3, 0, "3rd Qtr"));
    // Adicionar nova série
    var series = chart.getChartData().getSeries().add(fact.getCell(0, 0, 1, "Series 1"), chart.getType());
    // Agora preenchendo os dados da série
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 1, 1, 20));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 2, 1, 50));
    series.getDataPoints().addDataPointForPieSeries(fact.getCell(defaultWorksheetIndex, 3, 1, 30));
    series.getParentSeriesGroup().setColorVaried(true);
    pres.save("Pie.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Perguntas Frequentes**

**As variações 'Pie of Pie' e 'Bar of Pie' são suportadas?**

Sim, a biblioteca [suporta](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/charttype/) um plot secundário para gráficos de pizza, incluindo os tipos 'Pie of Pie' e 'Bar of Pie'.

**Posso exportar apenas o gráfico como uma imagem (por exemplo, PNG)?**

Sim, você pode [exportar o próprio gráfico como uma imagem](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/shape/#getImage) (como PNG) sem a apresentação inteira.