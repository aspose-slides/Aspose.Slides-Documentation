---
title: Personalizar tabelas de dados de gráficos em apresentações no .NET
linktitle: Tabela de Dados
type: docs
url: /pt/net/chart-data-table/
keywords:
- dados de gráfico
- tabela de dados
- propriedades de fonte
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Personalize as fontes, bordas e chaves de legenda da tabela de dados de gráficos em apresentações do PowerPoint usando Aspose.Slides para .NET e C#."
---
## **Visão geral**

Aspose.Slides for .NET permite exibir a tabela de dados de um gráfico e personalizar sua formatação de texto, bordas e chaves de legenda. Este artigo explica como habilitar a tabela, formatar seu texto, controlar cada tipo de borda e mostrar ou ocultar as chaves de legenda. Os exemplos salvam os gráficos configurados em arquivos PPTX.

## **Definir propriedades da fonte**

Para exibir a tabela de dados de um gráfico, defina [HasDataTable](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/chart/hasdatatable/) como `true`. Use [ChartDataTable](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/chart/chartdatatable/) para acessar a tabela e configurar sua formatação de texto.

1. Carregue a apresentação usando a classe [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).
1. Adicione um gráfico de colunas agrupadas ao primeiro slide.
1. Habilite a tabela de dados do gráfico.
1. Ative o texto em negrito com [FontBold](https://reference.aspose.com/slides/pt/net/aspose.slides/baseportionformat/fontbold/) e defina [FontHeight](https://reference.aspose.com/slides/pt/net/aspose.slides/baseportionformat/fontheight/) como `20` para texto de 20 pontos.
1. Salve a apresentação modificada.

O exemplo a seguir requer `test.pptx` no diretório de trabalho com pelo menos um slide. Ele adiciona um gráfico com dados padrão na posição (50, 50), com largura de 600 pontos e altura de 400 pontos. O `output.pptx` salvo contém o gráfico com a tabela de dados habilitada e as configurações de fonte especificadas aplicadas.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation("test.pptx");
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var portionFormat = chart.ChartDataTable.TextFormat.PortionFormat;
portionFormat.FontBold = NullableBool.True;
portionFormat.FontHeight = 20;

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **Personalizar bordas da tabela de dados**

Habilite a tabela com [IChart.HasDataTable](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichart/hasdatatable/) e acesse-a através de [IChart.ChartDataTable](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichart/chartdatatable/). Você pode controlar três tipos de bordas independentemente:

- [HasBorderHorizontal](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/idatatable/hasborderhorizontal/) controla as bordas horizontais das células.
- [HasBorderVertical](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/idatatable/hasbordervertical/) controla as bordas verticais das células.
- [HasBorderOutline](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/idatatable/hasborderoutline/) controla a borda externa da tabela.

Defina cada propriedade como `true` para exibir suas bordas ou como `false` para ocultá‑las. O exemplo a seguir cria um gráfico de colunas agrupadas com dados padrão, exibe as bordas horizontais e a borda externa, e oculta as bordas verticais. Não requer nenhum arquivo de entrada. A posição e o tamanho do gráfico são especificados em pontos.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = false;
dataTable.HasBorderOutline = true;

presentation.Save("data-table-borders.pptx", SaveFormat.Pptx);
```

A comparação abaixo usa os mesmos dados do gráfico e a mesma configuração de chave de legenda em todos os quatro casos. Começando com todas as bordas habilitadas, cada variante restante desabilita apenas uma propriedade de borda. A variante inferior esquerda corresponde às configurações de borda do exemplo.

![Tabelas de dados do gráfico com todas as bordas habilitadas, sem bordas horizontais, sem bordas verticais e sem borda externa](data-table-borders.png)

## **Mostrar ou ocultar chaves de legenda**

As chaves de legenda são pequenos marcadores coloridos ao lado dos nomes das séries na tabela de dados. Elas ajudam os leitores a associar cada linha da tabela a uma série do gráfico. Defina [ShowLegendKey](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/idatatable/showlegendkey/) como `true` para mostrar esses marcadores ou como `false` para ocultá‑los.

A legenda separada do gráfico é controlada por [IChart.HasLegend](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/ichart/haslegend/). Essas configurações são independentes: ocultar a legenda separada não oculta as chaves dentro da tabela de dados, e ocultar as chaves da tabela não oculta a legenda separada.

O exemplo a seguir cria um gráfico com dados padrão, habilita sua tabela de dados e mostra as chaves de legenda dentro dela enquanto oculta a legenda separada. Todas as bordas da tabela são explicitamente habilitadas. Nenhuma apresentação de entrada é necessária. Para ocultar apenas as chaves da tabela, altere `dataTable.ShowLegendKey` para `false`.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
chart.HasDataTable = true;
chart.HasLegend = false;

var dataTable = chart.ChartDataTable;
dataTable.HasBorderHorizontal = true;
dataTable.HasBorderVertical = true;
dataTable.HasBorderOutline = true;
dataTable.ShowLegendKey = true;

presentation.Save("data-table-legend-keys.pptx", SaveFormat.Pptx);
```

A comparação abaixo mostra a mesma tabela com as chaves de legenda habilitadas e desabilitadas. Todas as bordas permanecem habilitadas, e a legenda separada do gráfico está oculta em ambos os casos.

![Tabelas de dados do gráfico com chaves de legenda mostradas à esquerda e ocultas à direita](data-table-legend-keys.png)

## **FAQ**

**Posso mostrar chaves de legenda na tabela de dados de um gráfico?**  
Sim. Defina [ShowLegendKey](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/datatable/showlegendkey/) como `true` para exibir as chaves de legenda ou como `false` para ocultá‑las.

**A tabela de dados será preservada ao exportar a apresentação para PDF, HTML ou imagens?**  
Sim. Aspose.Slides renderiza o gráfico e sua tabela de dados exibida como parte do slide ao exportar para [PDF](/slides/pt/net/convert-powerpoint-to-pdf/), [HTML](/slides/pt/net/convert-powerpoint-to-html/), ou [images](/slides/pt/net/convert-powerpoint-to-png/).

**Posso trabalhar com tabelas de dados em gráficos carregados de um modelo?**  
Sim. Para um gráfico carregado de uma apresentação ou modelo existente, use [HasDataTable](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/chart/hasdatatable/) para verificar ou alterar se sua tabela de dados está exibida.

**Como posso encontrar gráficos que têm a tabela de dados habilitada?**  
Itere pelas formas em cada slide, identifique os gráficos e verifique a propriedade [HasDataTable](https://reference.aspose.com/slides/pt/net/aspose.slides.charts/chart/hasdatatable/). Um valor `true` indica que a tabela de dados está habilitada.