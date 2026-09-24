---
title: Personalizar tabelas de dados de gráficos em apresentações usando JavaScript
linktitle: Tabela de Dados
type: docs
url: /pt/nodejs-java/chart-data-table/
keywords:
- dados do gráfico
- tabela de dados
- propriedades da fonte
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Personalize fontes, bordas e chaves de legenda da tabela de dados de gráficos em apresentações PowerPoint usando Aspose.Slides para Node.js via Java."
---
## **Visão geral**

Aspose.Slides for Node.js via Java permite exibir a tabela de dados de um gráfico e personalizar sua formatação de texto, bordas e chaves da legenda. Este artigo explica como habilitar a tabela, formatar seu texto, controlar cada tipo de borda e mostrar ou ocultar as chaves da legenda. Os exemplos salvam os gráficos configurados em arquivos PPTX.

## **Definir propriedades da fonte**

Para exibir a tabela de dados de um gráfico, passe `true` para [setDataTable](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chart/setdatatable/). Use [getChartDataTable](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chart/getchartdatatable/) para acessar a tabela e configurar sua formatação de texto.

1. Carregue a apresentação usando a classe [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/).
1. Adicione um gráfico de colunas agrupadas ao primeiro slide.
1. Habilite a tabela de dados do gráfico.
1. Habilite texto em negrito com [setFontBold](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseportionformat/#setfontbold) e passe `20` para [setFontHeight](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseportionformat/#setfontheight) para texto de 20 pontos.
1. Salve a apresentação modificada.

O exemplo a seguir requer `input.pptx` no diretório de trabalho com ao menos um slide. Ele adiciona um gráfico com dados padrão na posição (50, 50), com largura de 600 pontos e altura de 400 pontos. O `output.pptx` salvo contém o gráfico com sua tabela de dados habilitada e as configurações de fonte especificadas aplicadas.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Personalizar bordas da tabela de dados**

Habilite a tabela com [Chart.setDataTable](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chart/setdatatable/) e acesse-a através de [Chart.getChartDataTable](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chart/getchartdatatable/). Você pode controlar três tipos de bordas independentemente:

- [setBorderHorizontal](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/datatable/setborderhorizontal/) controla as bordas horizontais das células.
- [setBorderVertical](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/datatable/setbordervertical/) controla as bordas verticais das células.
- [setBorderOutline](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/datatable/setborderoutline/) controla a borda externa da tabela.

Passe `true` para cada método para exibir suas bordas ou `false` para ocultá‑las. O exemplo a seguir cria um gráfico de colunas agrupadas com dados padrão, exibe as bordas horizontais e a borda externa, e oculta as bordas verticais. Não requer arquivo de entrada. A posição e o tamanho do gráfico são especificados em pontos.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A comparação abaixo usa os mesmos dados do gráfico e a mesma configuração de chave da legenda em todos os quatro casos. Começando com todas as bordas habilitadas, cada variante restante desabilita apenas uma configuração de borda. A variante inferior esquerda corresponde às configurações de borda do exemplo.

![Tabelas de dados do gráfico com todas as bordas habilitadas, sem bordas horizontais, sem bordas verticais e sem borda externa](data-table-borders.png)

## **Mostrar ou ocultar chaves da legenda**

As chaves da legenda são pequenos marcadores coloridos ao lado dos nomes das séries na tabela de dados. Eles ajudam os leitores a associar cada linha da tabela a uma série do gráfico. Passe `true` para [setShowLegendKey](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/datatable/setshowlegendkey/) para mostrar esses marcadores ou `false` para ocultá‑los.

A legenda separada do gráfico é controlada por [Chart.setLegend](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chart/setlegend/). Essas configurações são independentes: ocultar a legenda separada não oculta as chaves dentro da tabela de dados, e ocultar as chaves da tabela não oculta a legenda separada.

O exemplo a seguir cria um gráfico com dados padrão, habilita sua tabela de dados e exibe as chaves da legenda dentro dela enquanto oculta a legenda separada. Todas as bordas da tabela são explicitamente habilitadas. Nenhuma apresentação de entrada é necessária. Para ocultar apenas as chaves da tabela, passe `false` para [setShowLegendKey](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/datatable/setshowlegendkey/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A comparação abaixo mostra a mesma tabela com as chaves da legenda mostradas à esquerda e ocultas à direita. Todas as bordas permanecem habilitadas, e a legenda separada do gráfico está oculta em ambos os casos.

![Tabelas de dados do gráfico com chaves da legenda mostradas à esquerda e ocultas à direita](data-table-legend-keys.png)

## **FAQ**

**Posso mostrar chaves da legenda na tabela de dados de um gráfico?**

Sim. Passe `true` para [setShowLegendKey](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/datatable/setshowlegendkey/) para exibir as chaves da legenda ou `false` para ocultá‑las.

**A tabela de dados será preservada ao exportar a apresentação para PDF, HTML ou imagens?**

Sim. Aspose.Slides renderiza o gráfico e sua tabela de dados exibida como parte do slide ao exportar para [PDF](/slides/pt/nodejs-java/convert-powerpoint-to-pdf/), [HTML](/slides/pt/nodejs-java/convert-powerpoint-to-html/) ou [images](/slides/pt/nodejs-java/convert-powerpoint-to-png/).

**Posso trabalhar com tabelas de dados em gráficos carregados de um modelo?**

Sim. Para um gráfico carregado de uma apresentação ou modelo existente, use [hasDataTable](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chart/hasdatatable/) e [setDataTable](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chart/setdatatable/) para verificar ou alterar se sua tabela de dados está exibida.

**Como posso encontrar gráficos que têm a tabela de dados habilitada?**

Itere pelas shapes em cada slide, identifique os gráficos e chame o método [hasDataTable](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/chart/hasdatatable/). Um valor `true` indica que a tabela de dados está habilitada.