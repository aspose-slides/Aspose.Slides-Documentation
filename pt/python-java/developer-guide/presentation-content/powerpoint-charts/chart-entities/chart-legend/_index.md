---
title: Personalizar Legendas de Gráficos em Apresentações Usando Python
linktitle: Legenda de Gráfico
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
description: "Personalize legendas de gráficos com Aspose.Slides para Python via Java para otimizar apresentações de PowerPoint com formatação de legenda sob medida."
---
## **Visão geral**

O Aspose.Slides fornece opções para personalizar legendas de gráficos em apresentações do PowerPoint. Este artigo mostra como posicionar e dimensionar uma legenda, definir o tamanho da fonte para toda a legenda e aplicar formatação a uma entrada de legenda individual.

Ele também aborda vários comportamentos relacionados nas Perguntas Frequentes, incluindo o uso do modo sem sobreposição para que a área do gráfico faça espaço para a legenda, permitindo que rótulos longos de legenda sejam quebrados em linhas ou usem quebras de linha, e permitindo que a formatação da legenda herde do tema da apresentação quando configurações explícitas de texto e preenchimento não são aplicadas.

## **Posicionamento da Legenda**

Para definir as propriedades da legenda, siga estas etapas:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Obtenha uma referência ao slide.
1. Adicione um gráfico ao slide.
1. Defina as propriedades da legenda.
1. Salve a apresentação como um arquivo PPTX.

O exemplo a seguir define a posição e o tamanho de uma legenda de gráfico.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Criar uma apresentação vazia.
presentation = Presentation()
try:
    # Obter uma referência ao slide.
    slide = presentation.getSlides().get_Item(0)

    # Adicionar um gráfico de colunas agrupadas ao slide.
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500)

    # Definir as propriedades da legenda.
    legend = chart.getLegend()
    legend.setX(50 / chart.getWidth())
    legend.setY(50 / chart.getHeight())
    legend.setWidth(100 / chart.getWidth())
    legend.setHeight(100 / chart.getHeight())

    # Salvar a apresentação no disco.
    presentation.save("Legend_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Definir o Tamanho da Fonte de uma Legenda**

Aspose.Slides for Python via Java permite definir o tamanho da fonte de uma legenda. Siga estas etapas:

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Crie o gráfico padrão.
1. Defina o tamanho da fonte.
1. Defina o valor mínimo do eixo.
1. Defina o valor máximo do eixo.
1. Salve a apresentação no disco.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Criar uma apresentação vazia.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20)

    vertical_axis = chart.getAxes().getVerticalAxis()
    vertical_axis.setAutomaticMinValue(False)
    vertical_axis.setMinValue(-5)
    vertical_axis.setAutomaticMaxValue(False)
    vertical_axis.setMaxValue(10)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Definir o Tamanho da Fonte de uma Entrada de Legenda Individual**

Aspose.Slides for Python via Java permite definir o tamanho da fonte de entradas de legenda individuais. Siga estas etapas:

1. Instancie a classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Crie o gráfico padrão.
1. Acesse uma entrada de legenda.
1. Defina o tamanho da fonte.
1. Salve a apresentação no disco.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, NullableBool, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

# Criar uma apresentação vazia.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400)

    text_format = chart.getLegend().getEntries().get_Item(1).getTextFormat()
    portion_format = text_format.getPortionFormat()

    portion_format.setFontBold(NullableBool.True_)
    portion_format.setFontHeight(20)
    portion_format.setFontItalic(NullableBool.True_)
    portion_format.getFillFormat().setFillType(FillType.Solid)
    portion_format.getFillFormat().getSolidFillColor().setColor(Color.BLUE)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Perguntas Frequentes**

**Posso habilitar a legenda para que o gráfico reserve espaço automaticamente para ela em vez de sobrepô-la?**

Sim. Use [setOverlay](https://reference.aspose.com/slides/pt/python-java/aspose.slides/legend/#setOverlay) com `False` para habilitar o modo sem sobreposição; nesse caso, a área do gráfico será reduzida para acomodar a legenda.

**Posso criar rótulos de legenda em várias linhas?**

Sim. Rótulos longos são automaticamente quebrados quando o espaço é insuficiente; quebras de linha forçadas são suportadas por meio de caracteres de nova linha no nome da série.

**Como faço a legenda seguir o esquema de cores do tema da apresentação?**

Não defina cores, preenchimentos ou fontes explícitas para a legenda ou seu texto. Eles então herdarão do tema e serão atualizados corretamente quando o design mudar.