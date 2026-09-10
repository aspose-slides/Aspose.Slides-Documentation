---
title: Personalizar Áreas de Plotagem de Gráficos de Apresentação em Python
linktitle: Área de Plotagem
type: docs
url: /pt/python-java/chart-plot-area/
keywords:
- gráfico
- área de plotagem
- largura da área de plotagem
- altura da área de plotagem
- tamanho da área de plotagem
- modo de layout
- PowerPoint
- apresentação
- Python
- Java
- Aspose.Slides
description: "Descubra como personalizar áreas de plotagem de gráficos em apresentações PowerPoint com Aspose.Slides para Python via Java. Melhore os visuais dos seus slides com facilidade."
---
## **Visão geral**

Este artigo mostra como trabalhar com a área de plotagem de um gráfico no Aspose.Slides. Ele explica como obter a posição e o tamanho reais da área de plotagem validando o layout do gráfico e, em seguida, lendo seus valores X, Y, largura e altura.

Também demonstra como configurar o modo de layout da área de plotagem quando o layout é definido manualmente, usando [LayoutTargetType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/layouttargettype/) para definir se a área de plotagem é calculada por sua região interna ou por sua região externa juntamente com os eixos e rótulos dos eixos.

## **Obter largura e altura de uma área de plotagem de gráfico**

Aspose.Slides para Python via Java fornece uma API simples para ler a posição e o tamanho reais da área de plotagem de um gráfico.

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
2. Acesse o primeiro slide.
3. Adicione um gráfico com dados padrão.
4. Chame o método [Chart.validateChartLayout](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chart/#validateChartLayout) antes de obter os valores reais.
5. Obtenha a posição X real (esquerda) do elemento do gráfico em relação ao canto superior esquerdo do gráfico.
6. Obtenha a posição Y real (superior) do elemento do gráfico em relação ao canto superior esquerdo do gráfico.
7. Obtenha a largura real do elemento do gráfico.
8. Obtenha a altura real do elemento do gráfico.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation

# Crie uma instância da classe Presentation.
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 350)
    chart.validateChartLayout()

    plot_area = chart.getPlotArea()
    x = plot_area.getActualX()
    y = plot_area.getActualY()
    width = plot_area.getActualWidth()
    height = plot_area.getActualHeight()
finally:
    presentation.dispose()
```

## **Definir o modo de layout de uma área de plotagem de gráfico**

Aspose.Slides para Python via Java fornece uma API simples para definir o modo de layout da área de plotagem do gráfico. Os métodos [setLayoutTargetType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartplotarea/#setLayoutTargetType) e [getLayoutTargetType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartplotarea/#getLayoutTargetType) estão disponíveis na classe [ChartPlotArea](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chartplotarea/). Se o layout da área de plotagem for definido manualmente, esta configuração especifica se a área de plotagem deve ser posicionada por dentro (excluindo eixos e rótulos dos eixos) ou por fora (incluindo eixos e rótulos dos eixos). Existem dois valores possíveis definidos na enumeração [LayoutTargetType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/layouttargettype/).

- [Inner](https://reference.aspose.com/slides/pt/python-java/aspose.slides/layouttargettype/#Inner) especifica que o tamanho da área de plotagem exclui marcas de graduação e rótulos dos eixos.
- [Outer](https://reference.aspose.com/slides/pt/python-java/aspose.slides/layouttargettype/#Outer) especifica que o tamanho da área de plotagem inclui marcas de graduação e rótulos dos eixos.

O código de exemplo é apresentado abaixo.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, LayoutTargetType, Presentation, SaveFormat

# Crie uma instância da classe Presentation.
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    plot_area = chart.getPlotArea()
    plot_area.setX(0.2)
    plot_area.setY(0.2)
    plot_area.setWidth(0.7)
    plot_area.setHeight(0.7)
    plot_area.setLayoutTargetType(LayoutTargetType.Inner)

    presentation.save("SetLayoutMode_inner.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Em que unidades são retornados X real, Y real, largura real e altura real?**

Em pontos; 1 polegada = 72 pontos. Estas são unidades de coordenadas do Aspose.Slides.

**Como a área de plotagem difere da área do gráfico em termos de conteúdo?**

A área de plotagem é a região de desenho dos dados (séries, linhas de grade, linhas de tendência etc.); a área do gráfico inclui os elementos circundantes (título, legenda etc.). Em gráficos 3D, a área de plotagem também inclui as paredes/chão e os eixos.

**Como são interpretados X, Y, largura e altura da área de plotagem quando o layout é manual?**

Eles são frações (0–1) do tamanho total do gráfico; nesse modo, o posicionamento automático está desativado e as frações definidas são usadas.

**Por que a posição da área de plotagem mudou após adicionar ou mover a legenda?**

A legenda fica na área do gráfico fora da área de plotagem, mas afeta o layout e o espaço disponível, de modo que a área de plotagem pode ser deslocada quando o posicionamento automático está em vigor. (Esse é o comportamento padrão dos gráficos do PowerPoint.)