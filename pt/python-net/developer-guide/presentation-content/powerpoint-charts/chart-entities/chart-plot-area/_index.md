---
title: Personalizar Áreas de Plotagem de Gráficos de Apresentação em Python
linktitle: Área de Plotagem
type: docs
url: /pt/python-net/chart-plot-area/
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
- Aspose.Slides
description: "Descubra como personalizar áreas de plotagem de gráficos em apresentações PowerPoint e OpenDocument com Aspose.Slides para Python via .NET. Aprimore visualmente seus slides com facilidade."
---
## **Visão Geral**

Este artigo mostra como trabalhar com a área de plotagem de um gráfico no Aspose.Slides. Ele explica como obter a posição e o tamanho reais da área de plotagem validando o layout do gráfico e, em seguida, lendo seus valores X, Y, largura e altura.

Também demonstra como configurar o modo de layout da área de plotagem quando o layout é definido manualmente, usando `LayoutTargetType` para definir se a área de plotagem é calculada por sua região interna ou por sua região externa juntamente com os eixos e rótulos de eixo.

## **Obter Largura, Altura da Área de Plotagem do Gráfico**
Aspose.Slides for Python via .NET fornece uma API simples para .

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-net/aspose.slides/presentation/).
2. Acesse o primeiro slide.
3. Adicione um gráfico com dados padrão.
4. Chame o método IChart.ValidateChartLayout() antes para obter os valores reais.
5. Obtém a posição X real (esquerda) do elemento do gráfico relativa ao canto superior esquerdo do gráfico.
6. Obtém o topo real do elemento do gráfico relativo ao canto superior esquerdo do gráfico.
7. Obtém a largura real do elemento do gráfico.
8. Obtém a altura real do elemento do gráfico.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as pres:
    chart = pres.slides[0].shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 100, 100, 500, 350)
    chart.validate_chart_layout()

    x = chart.plot_area.actual_x
    y = chart.plot_area.actual_y
    w = chart.plot_area.actual_width
    h = chart.plot_area.actual_height
	
	# Salvar a apresentação com o gráfico
    pres.save("Chart_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Definir Modo de Layout da Área de Plotagem do Gráfico**
Aspose.Slides for Python via .NET fornece uma API simples para definir o modo de layout da área de plotagem do gráfico. A propriedade **LayoutTargetType** foi adicionada às classes **ChartPlotArea** e **IChartPlotArea**. Se o layout da área de plotagem for definido manualmente, esta propriedade especifica se o layout da área de plotagem será interno (não incluindo eixo e rótulos de eixo) ou externo (incluindo eixo e rótulos de eixo). Existem dois valores possíveis que são definidos no enum **LayoutTargetType**.

- **LayoutTargetType.Inner** - especifica que o tamanho da área de plotagem determinará o tamanho da área de plotagem, não incluindo as marcas de escala e os rótulos de eixo.
- **LayoutTargetType.Outer** - especifica que o tamanho da área de plotagem determinará o tamanho da área de plotagem, as marcas de escala e os rótulos de eixo.

O código de exemplo é fornecido abaixo.

```py
import aspose.slides.charts as charts
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, 20, 100, 600, 400)
    chart.plot_area.as_i_layoutable.x = 0.2
    chart.plot_area.as_i_layoutable.y = 0.2
    chart.plot_area.as_i_layoutable.width = 0.7
    chart.plot_area.as_i_layoutable.height = 0.7
    chart.plot_area.layout_target_type = charts.LayoutTargetType.INNER

    presentation.save("SetLayoutMode_outer.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Em quais unidades são retornados actual_x, actual_y, actual_width e actual_height?**

Em pontos; 1 polegada = 72 pontos. Estas são unidades de coordenadas do Aspose.Slides.

**Como a Área de Plotagem difere da Área do Gráfico em termos de conteúdo?**

A Área de Plotagem é a região de desenho dos dados (séries, linhas de grade, linhas de tendência etc.); a Área do Gráfico inclui os elementos circundantes (título, legenda etc.). Em gráficos 3D, a Área de Plotagem também inclui as paredes/chão e os eixos.

**Como são interpretados X, Y, Largura e Altura da Área de Plotagem quando o layout é manual?**

Eles são frações (0–1) do tamanho total do gráfico; neste modo, o posicionamento automático está desativado e as frações que você definir são usadas.

**Por que a posição da Área de Plotagem mudou após adicionar/mover a legenda?**

A legenda fica na área do gráfico fora da Área de Plotagem, mas afeta o layout e o espaço disponível, portanto a Área de Plotagem pode mudar de posição quando o posicionamento automático está em vigor. (Esse é o comportamento padrão para gráficos do PowerPoint.)