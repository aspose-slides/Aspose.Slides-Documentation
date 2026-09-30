---
title: Personalizar legendas de gráficos em apresentações no .NET
linktitle: Legenda do Gráfico
type: docs
url: /pt/net/chart-legend/
keywords:
- legenda de gráfico
- posição da legenda
- tamanho da fonte
- PowerPoint
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Personalize legendas de gráficos com Aspose.Slides para .NET para otimizar apresentações do PowerPoint com formatação de legenda sob medida."
---
## **Visão geral**

Aspose.Slides for .NET oferece opções para personalizar legendas de gráficos em apresentações do PowerPoint. Este artigo mostra como posicionar e dimensionar uma legenda, definir o tamanho da fonte para a legenda inteira, formatar uma entrada individual da legenda e ocultar ou restaurar entradas selecionadas.

A FAQ cobre comportamentos relacionados, incluindo reservar espaço para a legenda, exibir rótulos em várias linhas e herdar a formatação do tema da apresentação.

## **Posicionamento da Legenda**

Use as propriedades [X](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/x/), [Y](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/y/), [Width](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/width/) e [Height](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/height/) da legenda para especificar sua posição e tamanho como frações das dimensões do gráfico.

Este exemplo cria uma apresentação e adiciona um gráfico de colunas agrupadas com dados padrão ao primeiro slide. Dividir os deslocamentos e dimensões desejados da legenda pela largura e altura do gráfico os converte em valores relativos: a legenda é deslocada em 50 pontos do canto superior esquerdo do gráfico e tem tamanho de 100 por 100 pontos.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

// Expresse a posição e o tamanho da legenda em relação ao gráfico.
chart.Legend.X = 50 / chart.Width;
chart.Legend.Y = 50 / chart.Height;
chart.Legend.Width = 100 / chart.Width;
chart.Legend.Height = 100 / chart.Height;

presentation.Save("legend_position.pptx", SaveFormat.Pptx);
```

## **Definir o Tamanho da Fonte de uma Legenda**

Use o [TextFormat](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/textformat/) da legenda para acessar sua formatação de texto e definir [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) em pontos.

Este exemplo cria um gráfico com dados padrão e define o texto da legenda para 20 pontos. Também desabilita os limites automáticos para o eixo vertical e define seu intervalo de -5 a 10.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

chart.Legend.TextFormat.PortionFormat.FontHeight = 20;
chart.Axes.VerticalAxis.IsAutomaticMinValue = false;
chart.Axes.VerticalAxis.MinValue = -5;
chart.Axes.VerticalAxis.IsAutomaticMaxValue = false;
chart.Axes.VerticalAxis.MaxValue = 10;

presentation.Save("legend_font_size.pptx", SaveFormat.Pptx);
```

## **Definir o Tamanho da Fonte de uma Entrada Individual da Legenda**

Use a coleção [Entries](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/entries/) da legenda para acessar a formatação de uma entrada específica. Os índices de entrada são baseados em zero, portanto o índice `1` refere‑se à segunda entrada.

Este exemplo cria um gráfico de colunas agrupadas cujo dados padrão incluem pelo menos duas séries. Ele formata a segunda entrada da legenda com texto em negrito, itálico e azul de 20 pontos.

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
var textFormat = chart.Legend.Entries[1].TextFormat;

textFormat.PortionFormat.FontBold = NullableBool.True;
textFormat.PortionFormat.FontHeight = 20;
textFormat.PortionFormat.FontItalic = NullableBool.True;
textFormat.PortionFormat.FillFormat.FillType = FillType.Solid;
textFormat.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;

presentation.Save("legend_entry_format.pptx", SaveFormat.Pptx);
```

## **Ocultar Entradas Individuais da Legenda**

Para excluir uma série auxiliar da legenda mantendo seus dados visíveis, defina [ILegendEntryProperties.Hide](https://reference.aspose.com/slides/net/aspose.slides.charts/ilegendentryproperties/hide/) como `true` através de [IChartSeries.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartseries/relatedlegendentry/). Isso oculta somente a entrada de legenda selecionada; não remove a série ou seus pontos de dados. Definir [IChart.HasLegend](https://reference.aspose.com/slides/net/aspose.slides.charts/ichart/haslegend/) como `false`, por outro lado, oculta toda a legenda.

O exemplo abaixo cria um gráfico de colunas agrupadas com várias séries usando dados padrão. Ele oculta a entrada de legenda da segunda série (índice `1`) e salva a apresentação. Em seguida, restaura a entrada definindo `Hide` como `false` e salva uma segunda cópia. As colunas permanecem visíveis em ambos os arquivos.

```cs
using Aspose.Slides;
using Aspose.Slides.Charts;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var chart = slide.Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 200);
chart.HasLegend = true;

var legendEntry = chart.ChartData.Series[1].RelatedLegendEntry;

legendEntry.Hide = true;
presentation.Save("hidden_legend_entry.pptx", SaveFormat.Pptx);

// Restaurar a mesma entrada sem alterar os dados do gráfico.
legendEntry.Hide = false;
presentation.Save("restored_legend_entry.pptx", SaveFormat.Pptx);
```

A comparação abaixo mostra o mesmo gráfico com todas as entradas visíveis e com a segunda entrada oculta. As colunas da segunda série permanecem inalteradas.

![Comparação de um gráfico com todas as entradas da legenda visíveis e com a Série 2 oculta da legenda; todas as colunas permanecem visíveis.](hide-legend-entry.png)

Em gráficos de colunas, barras e linhas, as entradas da legenda identificam séries. Para gráficos de pizza, elas identificam pontos de dados individuais (fatias), portanto use [IChartDataPoint.RelatedLegendEntry](https://reference.aspose.com/slides/net/aspose.slides.charts/ichartdatapoint/relatedlegendentry/) na fatia selecionada. A API documenta essa propriedade de ponto de dados para os tipos de gráfico `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` e `BarOfPie`. Não assume que ela se aplique a gráficos de rosca, que não estão incluídos nessa lista.

## **FAQ**

**Posso fazer o gráfico reservar espaço para a legenda em vez de sobrepô-lo?**

Sim. Defina [Overlay](https://reference.aspose.com/slides/net/aspose.slides.charts/legend/overlay/) como `false` para reservar espaço para a legenda em vez de permitir que ela sobreponha a área de plotagem.

**Posso criar rótulos de legenda em várias linhas?**

Sim. Rótulos longos podem ser quebrados quando a largura disponível é insuficiente. Você também pode usar caracteres de nova linha nos nomes das séries para solicitar quebras de linha.

**Como faço a legenda seguir o esquema de cores do tema da apresentação?**

Deixe as cores, preenchimentos e fontes da legenda sem definição para que ela possa herdar a formatação do tema. Formatação explícita sobrescreve as configurações correspondentes do tema.