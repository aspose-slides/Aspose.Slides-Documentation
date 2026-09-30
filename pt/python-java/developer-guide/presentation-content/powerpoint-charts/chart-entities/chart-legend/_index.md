---
title: Personalizar Legendas de Gráficos em Apresentações Usando Python
linktitle: Legenda do Gráfico
type: docs
url: /pt/python-java/chart-legend/
keywords:
- legenda de gráfico
- posição da legenda
- tamanho da fonte
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Personalize legendas de gráficos com Aspose.Slides para Python via Java para otimizar apresentações do PowerPoint com formatação de legenda sob medida."
---
## **Visão geral**

Aspose.Slides for Python via Java oferece opções para personalizar legendas de gráficos em apresentações do PowerPoint. Este artigo mostra como posicionar e dimensionar uma legenda, definir o tamanho da fonte para toda a legenda, formatar uma entrada individual da legenda e ocultar ou restaurar entradas selecionadas.

O FAQ cobre comportamentos relacionados, incluindo reservar espaço para a legenda, exibir rótulos em várias linhas e herdar a formatação do tema da apresentação.

## **Posicionamento da legenda**

Use os métodos [setX](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setX), [setY](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setY), [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setWidth) e [setHeight](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setHeight) da legenda para especificar sua posição e tamanho como frações das dimensões do gráfico.

Este exemplo cria uma apresentação e adiciona um gráfico de colunas agrupadas com dados padrão ao primeiro slide. Dividindo os deslocamentos e dimensões desejados da legenda pela largura e altura do gráfico converte‑os em valores relativos: a legenda é deslocada em 50 pontos do canto superior esquerdo do gráfico e dimensionada em 100 por 100 pontos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # Expresse a posição e o tamanho da legenda em relação ao gráfico.
    chart.getLegend().setX(50 / chart.getWidth())
    chart.getLegend().setY(50 / chart.getHeight())
    chart.getLegend().setWidth(100 / chart.getWidth())
    chart.getLegend().setHeight(100 / chart.getHeight())

    presentation.save("legend_position.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Definir o tamanho da fonte de uma legenda**

Use o [getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat) da legenda para acessar sua formatação de texto e use [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) para definir o tamanho da fonte em pontos.

Este exemplo cria um gráfico com dados padrão e define o texto da legenda para 20 pontos. Ele também desabilita os limites automáticos para o eixo vertical e define seu intervalo de -5 a 10.

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

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)
    chart.getAxes().getVerticalAxis().setMinValue(-5)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setMaxValue(10)

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Definir o tamanho da fonte de uma entrada individual da legenda**

Use a coleção retornada pelo método [getEntries](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getEntries) da legenda para acessar a formatação de uma entrada específica. Os índices das entradas são baseados em zero, portanto o índice `1` refere‑se à segunda entrada.

Este exemplo cria um gráfico de colunas agrupadas cujo dados padrão incluem pelo menos duas séries. Ele formata a segunda entrada da legenda com texto negrito, itálico e azul de 20 pontos.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)
    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()

    text_format.getPortionFormat().setFontBold(NullableBool.True_)
    text_format.getPortionFormat().setFontHeight(20)
    text_format.getPortionFormat().setFontItalic(NullableBool.True_)
    text_format.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    text_format.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ocultar entradas individuais da legenda**

Para excluir uma série auxiliar da legenda mantendo seus dados visíveis, chame [LegendEntryProperties.setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) com `True` através de [ChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartseries/#getRelatedLegendEntry). Isso oculta apenas a entrada de legenda selecionada; não remove a série nem seus pontos de dados. Chamar [Chart.setLegend](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setLegend) com `False`, por outro lado, oculta a legenda inteira.

O exemplo abaixo cria um gráfico de colunas agrupadas com várias séries usando dados padrão. Ele oculta a entrada de legenda da segunda série (índice `1`) e salva a apresentação. Em seguida, restaura a entrada chamando [setHide](https://reference.aspose.com/slides/python-java/aspose.slides/legendentryproperties/#setHide) com `False` e salva uma segunda cópia. As colunas permanecem visíveis em ambos os arquivos.

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
    chart.setLegend(True)

    legend_entry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry()

    legend_entry.setHide(True)
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx)

    # Restaurar a mesma entrada sem alterar os dados do gráfico.
    legend_entry.setHide(False)
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A comparação abaixo mostra o mesmo gráfico com todas as entradas visíveis e com a segunda entrada oculta. As colunas da segunda série permanecem inalteradas.

![Comparação de um gráfico com todas as entradas de legenda visíveis e com a Série 2 oculta na legenda; todas as colunas permanecem visíveis.](hide-legend-entry.png)

Em gráficos de colunas, barras e linhas, as entradas de legenda identificam séries. Em gráficos de pizza, elas identificam pontos de dados individuais (fatias), portanto use [ChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatapoint/#getRelatedLegendEntry) na fatia selecionada. A documentação da API descreve esse método de ponto de dados para os tipos de gráfico `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` e `BarOfPie`. Não presuma que ele se aplique a gráficos de anel, que não estão incluídos nessa lista.

## **FAQ**

**Posso fazer o gráfico reservar espaço para a legenda em vez de sobrepô‑la?**

Sim. Chame [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) com `False` para reservar espaço para a legenda em vez de permitir que ela se sobreponha à área do gráfico.

**Posso criar rótulos de legenda em múltiplas linhas?**

Sim. Rótulos longos podem ser quebrados quando a largura disponível é insuficiente. Você também pode usar caracteres de nova linha nos nomes das séries para solicitar quebras de linha.

**Como faço a legenda seguir o esquema de cores do tema da apresentação?**

Deixe as cores, preenchimentos e fontes da legenda não definidos para que ela possa herdar a formatação do tema. Formatação explícita sobrescreve as configurações correspondentes do tema.