---
title: Personalizar Legendas de Gráficos em Apresentações Usando JavaScript
linktitle: Legenda do Gráfico
type: docs
url: /pt/nodejs-java/chart-legend/
keywords:
- legenda de gráfico
- posição da legenda
- tamanho da fonte
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Personalize legendas de gráficos com Aspose.Slides para Node.js via Java para otimizar apresentações do PowerPoint com formatação de legenda personalizada."
---
## **Visão geral**

Aspose.Slides for Node.js via Java oferece opções para personalizar legendas de gráficos em apresentações do PowerPoint. Este artigo mostra como posicionar e dimensionar uma legenda, definir o tamanho da fonte para a legenda inteira, formatar uma entrada individual da legenda e ocultar ou restaurar entradas selecionadas.

A FAQ aborda comportamentos relacionados, incluindo reservar espaço para a legenda, exibir rótulos multilinha e herdar a formatação do tema da apresentação.

## **Posicionamento da Legenda**

Use os métodos [setX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setx/), [setY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/sety/), [setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setwidth/) e [setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setheight/) da legenda para especificar sua posição e tamanho como frações das dimensões do gráfico.

Este exemplo cria uma apresentação e adiciona um gráfico de colunas agrupadas com dados padrão ao primeiro slide. Dividir os deslocamentos e dimensões desejados da legenda pela largura e altura do gráfico os converte em valores relativos: a legenda é deslocada em 50 pontos do canto superior esquerdo do gráfico e dimensionada em 100 por 100 pontos.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Expresse a posição e o tamanho da legenda em relação ao gráfico.
    chart.getLegend().setX(java.newFloat(50 / chart.getWidth()));
    chart.getLegend().setY(java.newFloat(50 / chart.getHeight()));
    chart.getLegend().setWidth(java.newFloat(100 / chart.getWidth()));
    chart.getLegend().setHeight(java.newFloat(100 / chart.getHeight()));

    presentation.save("legend_position.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir o Tamanho da Fonte de uma Legenda**

Use o [getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/gettextformat/) da legenda para acessar sua formatação de texto e use [setFontHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setFontHeight) para definir o tamanho da fonte em pontos.

Este exemplo cria um gráfico com dados padrão e define o texto da legenda para 20 pontos. Também desabilita os limites automáticos para o eixo vertical e define seu intervalo de -5 a 10.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir o Tamanho da Fonte de uma Entrada Individual da Legenda**

Use a coleção retornada pelo método [getEntries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/getentries/) da legenda para acessar a formatação de uma entrada específica. Os índices das entradas são baseados em zero, portanto o índice `1` refere‑se à segunda entrada.

Este exemplo cria um gráfico de colunas agrupadas cujo dados padrão incluem pelo menos duas séries. Ele formata a segunda entrada da legenda com texto em negrito, itálico e azul de 20 pontos.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    var textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    textFormat.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    var blue = java.getStaticFieldValue("java.awt.Color", "BLUE");
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(blue);

    presentation.save("legend_entry_format.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ocultar Entradas Individuais da Legenda**

Para excluir uma série auxiliar da legenda mantendo seus dados visíveis, chame [LegendEntryProperties.setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) com `true` por meio de [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getrelatedlegendentry/). Isso oculta apenas a entrada de legenda selecionada; não remove a série ou seus pontos de dados. Chamar [Chart.setLegend](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/setlegend/) com `false`, por outro lado, oculta a legenda inteira.

O exemplo abaixo cria um gráfico de colunas agrupadas com várias séries usando dados padrão. Ele oculta a entrada de legenda da segunda série (índice `1`) e salva a apresentação. Em seguida, restaura a entrada chamando [setHide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legendentryproperties/sethide/) com `false` e salva uma segunda cópia. As colunas permanecem visíveis em ambos os arquivos.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation();
try {
    var slide = presentation.getSlides().get_Item(0);

    var chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    var legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);

    // Restaurar a mesma entrada sem alterar os dados do gráfico.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A comparação abaixo mostra o mesmo gráfico com todas as entradas visíveis e com a segunda entrada oculta. As colunas da segunda série permanecem inalteradas.

![Comparação de um gráfico com todas as entradas de legenda visíveis e com a Série 2 oculta da legenda; todas as colunas permanecem visíveis.](hide-legend-entry.png)

Em gráficos de colunas, barras e linhas, as entradas de legenda identificam séries. Em gráficos de pizza, elas identificam pontos de dados individuais (fatias), portanto use [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatapoint/getrelatedlegendentry/) na fatia selecionada. A API documenta esse método de ponto de dados para os tipos de gráfico `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` e `BarOfPie`. Não presuma que ele se aplique a gráficos de rosquinha, que não estão incluídos nessa lista.

## **FAQ**

**Posso fazer o gráfico reservar espaço para a legenda em vez de sobrepô-lo?**

Sim. Chame [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/setoverlay/) com `false` para reservar espaço para a legenda em vez de permitir que ela sobreponha a área do gráfico.

**Posso criar rótulos de legenda multilinha?**

Sim. Rótulos longos podem quebrar quando a largura disponível é insuficiente. Você também pode usar caracteres de nova linha nos nomes das séries para solicitar quebras de linha.

**Como faço a legenda seguir o esquema de cores do tema da apresentação?**

Deixe as cores, preenchimentos e fontes da legenda não definidos para que ela possa herdá‑los do tema. Formatação explícita substitui as configurações correspondentes do tema.