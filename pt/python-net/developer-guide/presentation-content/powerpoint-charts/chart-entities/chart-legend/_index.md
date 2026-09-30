---
title: Personalizar legendas de gráficos em apresentações com Python
linktitle: Legenda do Gráfico
type: docs
url: /pt/python-net/chart-legend/
keywords:
- legenda de gráfico
- posição da legenda
- tamanho da fonte
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Personalize legendas de gráficos com Aspose.Slides for Python via .NET para otimizar apresentações do PowerPoint com formatação de legenda sob medida."
---
## **Visão geral**

Aspose.Slides for Python via .NET oferece opções para personalizar legendas de gráficos em apresentações do PowerPoint. Este artigo mostra como posicionar e dimensionar uma legenda, definir o tamanho da fonte para toda a legenda, formatar uma entrada de legenda individual e ocultar ou restaurar entradas selecionadas.

A seção de Perguntas Frequentes aborda comportamentos relacionados, incluindo reserva de espaço para a legenda, exibição de rótulos multilinha e herança de formatação do tema da apresentação.

## **Posicionamento da legenda**

Use as propriedades da legenda [x](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/x/), [y](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/y/), [width](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/width/) e [height](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/height/) para especificar sua posição e tamanho como frações das dimensões do gráfico.

Este exemplo cria uma apresentação e adiciona um gráfico de colunas agrupadas com dados padrão ao primeiro slide. Dividir os deslocamentos e dimensões desejados da legenda pela largura e altura do gráfico converte-os em valores relativos: a legenda é deslocada em 50 pontos a partir do canto superior esquerdo do gráfico e dimensionada em 100 por 100 pontos.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 500, 500)

    # Expresse a posição e o tamanho da legenda em relação ao gráfico.
    chart.legend.x = 50 / chart.width
    chart.legend.y = 50 / chart.height
    chart.legend.width = 100 / chart.width
    chart.legend.height = 100 / chart.height

    presentation.save("legend_position.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir o tamanho da fonte da legenda**

Use a propriedade [text_format](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/text_format/) da legenda para acessar sua formatação de texto e definir [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) em pontos.

Este exemplo cria um gráfico com dados padrão e define o texto da legenda para 20 pontos. Também desativa os limites automáticos para o eixo vertical e define seu intervalo de -5 a 10.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    chart.legend.text_format.portion_format.font_height = 20
    chart.axes.vertical_axis.is_automatic_min_value = False
    chart.axes.vertical_axis.min_value = -5
    chart.axes.vertical_axis.is_automatic_max_value = False
    chart.axes.vertical_axis.max_value = 10

    presentation.save("legend_font_size.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir o tamanho da fonte de uma entrada individual da legenda**

Use a coleção [entries](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/entries/) da legenda para acessar a formatação de uma entrada específica. Os índices das entradas começam em zero, portanto o índice `1` refere‑se à segunda entrada.

Este exemplo cria um gráfico de colunas agrupadas cujo conjunto de dados padrão inclui pelo menos duas séries. Ele formata a segunda entrada da legenda com negrito, itálico e texto azul de 20 pontos.

```python
import aspose.slides as slides
import aspose.slides.charts as charts
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)

    text_format = chart.legend.entries[1].text_format
    text_format.portion_format.font_bold = slides.NullableBool.TRUE
    text_format.portion_format.font_height = 20
    text_format.portion_format.font_italic = slides.NullableBool.TRUE
    text_format.portion_format.fill_format.fill_type = slides.FillType.SOLID
    text_format.portion_format.fill_format.solid_fill_color.color = draw.Color.blue

    presentation.save("legend_entry_format.pptx", slides.export.SaveFormat.PPTX)
```

## **Ocultar entradas individuais da legenda**

Para excluir uma série auxiliar da legenda mantendo seus dados visíveis, defina [ILegendEntryProperties.hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) como `True` através de [IChartSeries.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartseries/related_legend_entry/). Isso oculta apenas a entrada de legenda selecionada; não remove a série nem seus pontos de dados. Definir [IChart.has_legend](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichart/has_legend/) como `False`, por outro lado, oculta a legenda inteira.

O exemplo abaixo cria um gráfico de colunas agrupadas com várias séries usando dados padrão. Ele oculta a entrada de legenda da segunda série (índice `1`) e salva a apresentação. Em seguida, restaura a entrada definindo [hide](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ilegendentryproperties/hide/) como `False` e salva uma segunda cópia. As colunas permanecem visíveis em ambos os arquivos.

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_legend = True

    legend_entry = chart.chart_data.series[1].related_legend_entry
    legend_entry.hide = True

    presentation.save("hidden_legend_entry.pptx", slides.export.SaveFormat.PPTX)

    # Restaure a mesma entrada sem mudar os dados do gráfico.
    legend_entry.hide = False

    presentation.save("restored_legend_entry.pptx", slides.export.SaveFormat.PPTX)
```

A comparação abaixo mostra o mesmo gráfico com todas as entradas visíveis e com a segunda entrada oculta. As colunas da segunda série permanecem inalteradas.

![Comparison of a chart with all legend entries visible and with Series 2 hidden from the legend; all columns remain visible.](hide-legend-entry.png)

Em gráficos de colunas, barras e linhas, as entradas da legenda identificam séries. Em gráficos de pizza, elas identificam pontos de dados individuais (fatias), portanto use [IChartDataPoint.related_legend_entry](https://reference.aspose.com/slides/python-net/aspose.slides.charts/ichartdatapoint/related_legend_entry/) na fatia selecionada. A documentação da API registra essa propriedade de ponto de dados para os tipos de gráfico `PIE`, `PIE3D`, `EXPLODED_PIE`, `EXPLODED_PIE3D`, `PIE_OF_PIE` e `BAR_OF_PIE`. Não presuma que ela se aplique a gráficos de rosca, que não estão incluídos nessa lista.

## **Perguntas frequentes**

**Posso fazer o gráfico reservar espaço para a legenda em vez de sobrepô‑la?**

Sim. Defina [overlay](https://reference.aspose.com/slides/python-net/aspose.slides.charts/legend/overlay/) como `False` para reservar espaço para a legenda em vez de permitir que ela sobreponha a área de plotagem.

**Posso criar rótulos de legenda multilinha?**

Sim. Rótulos longos podem ser quebrados quando a largura disponível não for suficiente. Você também pode usar caracteres de nova linha nos nomes das séries para solicitar quebras de linha.

**Como faço a legenda seguir o esquema de cores do tema da apresentação?**

Deixe as cores, preenchimentos e fontes da legenda sem definição para que ela possa herdar a formatação do tema. Formatação explícita sobrescreve as configurações correspondentes do tema.