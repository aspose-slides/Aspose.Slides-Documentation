---
title: Personalizar tabelas de dados de gráficos em apresentações em Python
linktitle: Tabela de Dados
type: docs
url: /pt/python-net/chart-data-table/
keywords:
- dados do gráfico
- tabela de dados
- propriedades de fonte
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Personalize as fontes, bordas e chaves de legenda da tabela de dados de gráficos em apresentações PowerPoint usando Aspose.Slides para Python via .NET."
---
## **Visão geral**

Aspose.Slides for Python via .NET permite exibir a tabela de dados de um gráfico e personalizar a formatação de texto, bordas e chaves de legenda. Este artigo explica como habilitar a tabela, formatar seu texto, controlar cada tipo de borda e mostrar ou ocultar as chaves de legenda. Os exemplos salvam os gráficos configurados em arquivos PPTX.

## **Definir propriedades de fonte**

Para exibir a tabela de dados de um gráfico, defina [has_data_table](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chart/has_data_table/) como `True`. Use [chart_data_table](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chart/chart_data_table/) para acessar a tabela e configurar sua formatação de texto.

1. Carregue a apresentação usando a classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
1. Adicione um gráfico de colunas agrupadas ao primeiro slide.
1. Habilite a tabela de dados do gráfico.
1. Ative o texto em negrito com [font_bold](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseportionformat/font_bold/) e defina [font_height](https://reference.aspose.com/slides/pt/python-net/aspose.slides/baseportionformat/font_height/) como `20` para texto de 20 pontos.
1. Salve a apresentação modificada.

O exemplo a seguir requer `test.pptx` no diretório de trabalho com ao menos um slide. Ele adiciona um gráfico com dados padrão na posição (50, 50), com largura de 600 pontos e altura de 400 pontos. O `output.pptx` salvo contém o gráfico com sua tabela de dados habilitada e as configurações de fonte especificadas aplicadas.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("test.pptx") as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    portion_format = chart.chart_data_table.text_format.portion_format
    portion_format.font_bold = slides.NullableBool.TRUE
    portion_format.font_height = 20

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Personalizar bordas da tabela de dados**

Habilite a tabela com [Chart.has_data_table](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chart/has_data_table/) e acesse-a por meio de [Chart.chart_data_table](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chart/chart_data_table/). Você pode controlar três tipos de bordas de forma independente:

- [has_border_horizontal](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/datatable/has_border_horizontal/) controla as bordas horizontais das células.
- [has_border_vertical](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/datatable/has_border_vertical/) controla as bordas verticais das células.
- [has_border_outline](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/datatable/has_border_outline/) controla a borda externa da tabela.

Defina cada propriedade como `True` para exibir suas bordas ou `False` para ocultá-las. O exemplo a seguir cria um gráfico de colunas agrupadas com dados padrão, exibe as bordas horizontais e a borda externa, e oculta as bordas verticais. Não requer arquivo de entrada. A posição e o tamanho do gráfico são especificados em pontos.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = False
    data_table.has_border_outline = True

    presentation.save("data-table-borders.pptx", slides.export.SaveFormat.PPTX)
```

A comparação abaixo usa os mesmos dados do gráfico e a configuração de chave de legenda em todos os quatro casos. Começando com todas as bordas habilitadas, cada variante restante desabilita apenas uma propriedade de borda. A variante inferior esquerda corresponde às configurações de borda do exemplo.

![Tabelas de dados de gráficos com todas as bordas habilitadas, sem bordas horizontais, sem bordas verticais e sem borda externa](data-table-borders.png)

## **Mostrar ou ocultar chaves de legenda**

As chaves de legenda são pequenos marcadores coloridos ao lado dos nomes das séries na tabela de dados. Elas ajudam os leitores a associar cada linha da tabela a uma série do gráfico. Defina [show_legend_key](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/datatable/show_legend_key/) como `True` para exibir esses marcadores ou `False` para ocultá-los.

A legenda separada do gráfico é controlada por [Chart.has_legend](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chart/has_legend/). Essas configurações são independentes: ocultar a legenda separada não oculta as chaves dentro da tabela de dados, e ocultar as chaves da tabela não oculta a legenda separada.

O exemplo a seguir cria um gráfico com dados padrão, habilita sua tabela de dados e mostra as chaves de legenda dentro dela enquanto oculta a legenda separada. Todas as bordas da tabela são explicitamente habilitadas. Não é necessária nenhuma apresentação de entrada. Para ocultar apenas as chaves da tabela, altere `data_table.show_legend_key` para `False`.

```py
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 50, 50, 600, 400)
    chart.has_data_table = True
    chart.has_legend = False

    data_table = chart.chart_data_table
    data_table.has_border_horizontal = True
    data_table.has_border_vertical = True
    data_table.has_border_outline = True
    data_table.show_legend_key = True

    presentation.save("data-table-legend-keys.pptx", slides.export.SaveFormat.PPTX)
```

A comparação abaixo mostra a mesma tabela com as chaves de legenda habilitadas e desabilitadas. Todas as bordas permanecem habilitadas, e a legenda separada do gráfico está oculta em ambos os casos.

![Tabelas de dados de gráficos com chaves de legenda mostradas à esquerda e ocultas à direita](data-table-legend-keys.png)

## **Perguntas frequentes**

**Posso exibir chaves de legenda na tabela de dados de um gráfico?**

Sim. Defina [show_legend_key](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/datatable/show_legend_key/) como `True` para exibir as chaves de legenda ou como `False` para ocultá-las.

**A tabela de dados será preservada ao exportar a apresentação para PDF, HTML ou imagens?**

Sim. Aspose.Slides renderiza o gráfico e sua tabela de dados exibida como parte do slide ao exportar para [PDF](/slides/pt/python-net/convert-powerpoint-to-pdf/), [HTML](/slides/pt/python-net/convert-powerpoint-to-html/), ou [imagens](/slides/pt/python-net/convert-powerpoint-to-png/).

**Posso trabalhar com tabelas de dados em gráficos carregados de um modelo?**

Sim. Para um gráfico carregado de uma apresentação ou modelo existente, use [has_data_table](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chart/has_data_table/) para verificar ou alterar se sua tabela de dados está exibida.

**Como posso encontrar gráficos que têm a tabela de dados habilitada?**

Itere pelas formas em cada slide, identifique os gráficos e verifique a propriedade [has_data_table](https://reference.aspose.com/slides/pt/python-net/aspose.slides.charts/chart/has_data_table/). Um valor `True` indica que a tabela de dados está habilitada.