---
title: Personalizar tabelas de dados de gráfico em apresentações usando Python
linktitle: Tabela de Dados
type: docs
url: /pt/python-java/chart-data-table/
keywords:
- dados de gráfico
- tabela de dados
- propriedades de fonte
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Personalize fontes, bordas e chaves de legenda da tabela de dados de gráficos em apresentações PowerPoint usando Aspose.Slides para Python via Java."
---
## **Visão geral**

Aspose.Slides for Python via Java permite exibir a tabela de dados de um gráfico e personalizar sua formatação de texto, bordas e chaves da legenda. Este artigo explica como habilitar a tabela, formatar seu texto, controlar cada tipo de borda e mostrar ou ocultar as chaves da legenda. Os exemplos salvam os gráficos configurados em arquivos PPTX.

## **Definir propriedades da fonte**

Para exibir a tabela de dados de um gráfico, passe `True` para [setDataTable](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chart/#setDataTable). Use [getChartDataTable](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chart/#getChartDataTable) para acessar a tabela e configurar sua formatação de texto.

1. Carregue a apresentação usando a classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Adicione um gráfico de colunas agrupadas ao primeiro slide.
3. Habilite a tabela de dados do gráfico.
4. Habilite texto em negrito com [setFontBold](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseportionformat/#setFontBold) e passe `20` para [setFontHeight](https://reference.aspose.com/slides/pt/python-java/aspose.slides/baseportionformat/#setFontHeight) para texto de 20 pontos.
5. Salve a apresentação modificada.

O exemplo a seguir requer `test.pptx` no diretório de trabalho com ao menos um slide. Ele adiciona um gráfico com dados padrão na posição (50, 50), com largura de 600 pontos e altura de 400 pontos. O `output.pptx` salvo contém o gráfico com sua tabela de dados habilitada e as configurações de fonte especificadas aplicadas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, NullableBool, Presentation, SaveFormat

presentation = Presentation("test.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    portion_format = chart.getChartDataTable().getTextFormat().getPortionFormat()
    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Personalizar bordas da tabela de dados**

Habilite a tabela com [Chart.setDataTable](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chart/#setDataTable) e acesse-a através de [Chart.getChartDataTable](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chart/#getChartDataTable). Você pode controlar três tipos de bordas independentemente:

- [setBorderHorizontal](https://reference.aspose.com/slides/pt/python-java/aspose.slides/datatable/#setBorderHorizontal) controla as bordas horizontais das células.
- [setBorderVertical](https://reference.aspose.com/slides/pt/python-java/aspose.slides/datatable/#setBorderVertical) controla as bordas verticais das células.
- [setBorderOutline](https://reference.aspose.com/slides/pt/python-java/aspose.slides/datatable/#setBorderOutline) controla a borda externa da tabela.

Passe `True` para cada método para exibir suas bordas ou `False` para ocultá‑las. O exemplo a seguir cria um gráfico de colunas agrupadas com dados padrão, exibe as bordas horizontais e a borda externa, e oculta as bordas verticais. Não requer nenhum arquivo de entrada. A posição e o tamanho do gráfico são especificados em pontos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(False)
    data_table.setBorderOutline(True)

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A comparação abaixo usa os mesmos dados do gráfico e a configuração de chave de legenda em todos os quatro casos. Começando com todas as bordas habilitadas, cada variante restante desabilita apenas uma configuração de borda. A variante inferior esquerda corresponde às configurações de borda do exemplo.

![Tabelas de dados do gráfico com todas as bordas habilitadas, sem bordas horizontais, sem bordas verticais e sem borda externa](data-table-borders.png)

## **Mostrar ou ocultar chaves de legenda**

As chaves de legenda são pequenos marcadores coloridos ao lado dos nomes das séries na tabela de dados. Elas ajudam os leitores a associar cada linha da tabela a uma série do gráfico. Passe `True` para [setShowLegendKey](https://reference.aspose.com/slides/pt/python-java/aspose.slides/datatable/#setShowLegendKey) para mostrar esses marcadores ou `False` para ocultá‑los.

A legenda separada do gráfico é controlada por [Chart.setLegend](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chart/#setLegend). Essas configurações são independentes: ocultar a legenda separada não oculta as chaves dentro da tabela de dados, e ocultar as chaves da tabela não oculta a legenda separada.

O exemplo a seguir cria um gráfico com dados padrão, habilita sua tabela de dados e mostra as chaves de legenda dentro dela enquanto oculta a legenda separada. Todas as bordas da tabela são explicitamente habilitadas. Nenhuma apresentação de entrada é necessária. Para ocultar apenas as chaves da tabela, passe `False` para [setShowLegendKey](https://reference.aspose.com/slides/pt/python-java/aspose.slides/datatable/#setShowLegendKey).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    chart.setDataTable(True)
    chart.setLegend(False)

    data_table = chart.getChartDataTable()
    data_table.setBorderHorizontal(True)
    data_table.setBorderVertical(True)
    data_table.setBorderOutline(True)
    data_table.setShowLegendKey(True)

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A comparação abaixo mostra a mesma tabela com as chaves de legenda habilitadas e desabilitadas. Todas as bordas permanecem habilitadas, e a legenda separada do gráfico está oculta em ambos os casos.

![Tabelas de dados do gráfico com chaves de legenda mostradas à esquerda e ocultas à direita](data-table-legend-keys.png)

## **Perguntas frequentes**

**Posso exibir chaves de legenda na tabela de dados de um gráfico?**

Sim. Passe `True` para [setShowLegendKey](https://reference.aspose.com/slides/pt/python-java/aspose.slides/datatable/#setShowLegendKey) para exibir as chaves de legenda ou `False` para ocultá‑las.

**A tabela de dados será preservada ao exportar a apresentação para PDF, HTML ou imagens?**

Sim. Aspose.Slides renderiza o gráfico e sua tabela de dados exibida como parte do slide ao exportar para [PDF](/slides/pt/python-java/convert-powerpoint-to-pdf/), [HTML](/slides/pt/python-java/convert-powerpoint-to-html/), ou [imagens](/slides/pt/python-java/convert-powerpoint-to-png/).

**Posso trabalhar com tabelas de dados em gráficos carregados a partir de um modelo?**

Sim. Para um gráfico carregado a partir de uma apresentação ou modelo existente, use [hasDataTable](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chart/#hasDataTable) e [setDataTable](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chart/#setDataTable) para verificar ou alterar se sua tabela de dados está exibida.

**Como posso encontrar gráficos que têm a tabela de dados habilitada?**

Itere pelas formas em cada slide, identifique os gráficos e chame o método [hasDataTable](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chart/#hasDataTable) deles. Um valor `True` indica que a tabela de dados está habilitada.