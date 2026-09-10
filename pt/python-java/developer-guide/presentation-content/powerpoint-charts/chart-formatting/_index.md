---
title: Formatar gráficos de apresentação em Python
linktitle: Formatação de Gráficos
type: docs
weight: 60
url: /pt/python-java/chart-formatting/
keywords:
- formatar gráfico
- formatação de gráfico
- entidade de gráfico
- propriedades do gráfico
- configurações do gráfico
- opções de gráfico
- propriedades de fonte
- borda arredondada
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Aprenda a formatação de gráficos no Aspose.Slides para Python via Java e eleve sua apresentação PowerPoint com um estilo profissional e visualmente atraente."
---
## **Visão geral**

Este artigo explica como formatar gráficos em apresentações do PowerPoint usando Aspose.Slides. Ele mostra como personalizar elementos principais do gráfico, como eixos, linhas de grade, títulos, legendas, a área de plotagem e preenchimentos de parede, para melhorar a aparência e a legibilidade dos dados do gráfico.

Também demonstra como definir propriedades de fonte para o texto do gráfico, aplicar formatos numéricos predefinidos e personalizados aos dados do gráfico e habilitar cantos arredondados para a área do gráfico. Juntos, esses exemplos mostram como controlar tanto o estilo visual quanto a apresentação dos dados dos gráficos em uma apresentação.

## **Formatar entidades do gráfico**
Aspose.Slides for Python via Java permite que os desenvolvedores adicionem gráficos personalizados aos seus slides do zero. Este artigo explica como formatar diferentes entidades de gráfico, incluindo os eixos de categoria e de valor.

Aspose.Slides for Python via Java fornece uma API simples para gerenciar diferentes entidades de gráfico e formatá-las usando valores personalizados:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Acesse um slide pelo seu índice.
1. Adicione um gráfico do tipo desejado com dados padrão (este exemplo usa [ChartType.LineWithMarkers](https://reference.aspose.com/slides/pt/python-java/aspose.slides/charttype/#LineWithMarkers)).
1. Acesse o eixo de valores do gráfico e configure as seguintes propriedades:
   1. Defina **Line format** para as linhas de grade principais do eixo de valores.
   1. Defina **Line format** para as linhas de grade secundárias do eixo de valores.
   1. Defina **Number Format** para o eixo de valores.
   1. Defina **minimum, maximum, major, and minor units** para o eixo de valores.
   1. Defina **Text Properties** para os dados do eixo de valores.
   1. Defina **Title** para o eixo de valores.
1. Acesse o eixo de categorias do gráfico e configure as seguintes propriedades:
   1. Defina **Line format** para as linhas de grade principais do eixo de categorias.
   1. Defina **Line format** para as linhas de grade secundárias do eixo de categorias.
   1. Defina **Text Properties** para os dados do eixo de categorias.
   1. Defina **Title** para o eixo de categorias.
   1. Defina **Label Positioning** para o eixo de categorias.
   1. Defina **Rotation Angle** para os rótulos do eixo de categorias.
1. Acesse a legenda do gráfico e defina suas **text properties**.
1. Exiba a legenda do gráfico sem sobrepor o gráfico.
1. Acesse o **secondary value axis** do gráfico e configure as seguintes propriedades:
   1. Habilite o **value axis** secundário.
   1. Defina **Line Format** para o eixo de valores secundário.
   1. Defina **Number Format** para o eixo de valores secundário.
   1. Defina **minimum, maximum, major, and minor units** para o eixo de valores secundário.
1. Plote a primeira série do gráfico no eixo de valores secundário.
1. Defina a cor de preenchimento da parede traseira do gráfico.
1. Defina a cor de preenchimento da área de plotagem do gráfico.
1. Grave a apresentação modificada em um arquivo PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")
nullable_true = NullableBool.True_

    # Crie uma instância da classe Presentation
presentation = Presentation()
try:
    # Acesse o primeiro slide
    slide = presentation.getSlides().get_Item(0)

    # Adicione o gráfico de exemplo
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    # Defina o título do gráfico
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(nullable_true)
    chart_title.getPortionFormat().setFontItalic(nullable_true)

    # Defina o formato das linhas de grade principais para o eixo de valores
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    # Defina o formato das linhas de grade secundárias para o eixo de valores
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # Defina o formato numérico do eixo de valores
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    # Defina os valores máximo e mínimo do gráfico
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    # Defina as propriedades de texto do eixo de valores
    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(nullable_true)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(nullable_true)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    # Defina o título do eixo de valores
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(nullable_true)
    value_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # Defina o formato das linhas de grade principais para o eixo de categorias
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    # Defina o formato das linhas de grade secundárias para o eixo de categorias
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # Defina as propriedades de texto do eixo de categorias
    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(nullable_true)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(nullable_true)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    # Defina o título da categoria
    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(nullable_true)
    category_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # Defina a posição do rótulo do eixo de categorias
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)

    # Defina o ângulo de rotação do rótulo do eixo de categorias
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    # Defina as propriedades de texto das legendas
    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(nullable_true)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(nullable_true)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    # Exiba a legenda do gráfico sem sobrepor o gráfico

    chart.getLegend().setOverlay(False)

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(True)
    # Defina o eixo de valores secundário
    chart.getAxes().getSecondaryVerticalAxis().setVisible(True)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20)

    # Defina o formato numérico do eixo de valores secundário
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds)
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%")

    # Defina os valores máximo e mínimo do gráfico
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20)
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5)
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0)

    # Defina a cor da parede traseira do gráfico
    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)
    # Defina a cor da área de plotagem
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    # Salve a apresentação
    presentation.save("FormattedChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Definir propriedades de fonte para um gráfico**
Aspose.Slides for Python via Java oferece suporte à definição de propriedades de fonte para gráficos. Siga estas etapas para definir as propriedades de fonte:

- Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
- Adicione um gráfico ao slide.
- Defina a altura da fonte.
- Salve a apresentação modificada.

O exemplo a seguir demonstra estas etapas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Crie uma instância da classe Presentation
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Definir o formato numérico**
Aspose.Slides for Python via Java fornece uma API simples para gerenciar formatos de dados de gráficos:

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Acesse um slide pelo seu índice.
1. Adicione um gráfico do tipo desejado com dados padrão (este exemplo usa [ChartType.ClusteredColumn](https://reference.aspose.com/slides/pt/python-java/aspose.slides/charttype/#ClusteredColumn)).
1. Defina o formato numérico predefinido a partir dos valores predefinidos disponíveis.
1. Percorra as células de dados em cada série do gráfico e defina seu formato numérico.
1. Salve a apresentação.

```python
import jpype
import asposeslides

if not jpool.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Crie uma instância da classe Presentation
presentation = Presentation()
try:
    # Acesse o primeiro slide da apresentação
    slide = presentation.getSlides().get_Item(0)

    # Adicione um gráfico de colunas agrupadas padrão
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)

    # Acesse a coleção de séries do gráfico
    chart_series_collection = chart.getChartData().getSeries()

    # Itere por cada série do gráfico
    for chart_series in chart_series_collection:
        # Itere por cada ponto de dados na série
        for data_point in chart_series.getDataPoints():
            # Defina o formato numérico
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0.00%

    # Salve a apresentação
    presentation.save("PresetNumberFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Os formatos numéricos predefinidos disponíveis e seus índices são listados abaixo:

|**0**|Geral|
| :- | :- |
|**1**|0|
|**2**|0.00|
|**3**|#,##0|
|**4**|#,##0.00|
|**5**|$#,##0;$-#,##0|
|**6**|$#,##0;Red$-#,##0|
|**7**|$#,##0.00;$-#,##0.00|
|**8**|$#,##0.00;Red$-#,##0.00|
|**9**|0%|
|**10**|0.00%|
|**11**|0.00E+00|
|**12**|# ?/?|
|**13**|# /|
|**14**|m/d/yy|
|**15**|d-mmm-yy|
|**16**|d-mmm|
|**17**|mmm-yy|
|**18**|h:mm AM/PM|
|**19**|h:mm:ss AM/PM|
|**20**|h:mm|
|**21**|h:mm:ss|
|**22**|m/d/yy h:mm|
|**37**|#,##0;-#,##0|
|**38**|#,##0;Red-#,##0|
|**39**|#,##0.00;-#,##0.00|
|**40**|#,##0.00;Red-#,##0.00|
|**41**|_ * #,##0_ ;_ * "_ ;_ @_|
|**42**|_ $* #,##0_ ;_ $* "_ ;_ @_|
|**43**|_ * #,##0.00_ ;_ * "??_ ;_ @_|
|**44**|_ $* #,##0.00_ ;_ $* "??_ ;_ @_|
|**45**|mm:ss|
|**46**|h:mm:ss|
|**47**|mm:ss.0|
|**48**|##0.0E+00|
|**49**|@|

## **Definir bordas arredondadas da área do gráfico**
Aspose.Slides for Python via Java oferece suporte a cantos arredondados para a área do gráfico através dos métodos [hasRoundedCorners](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chart/#hasRoundedCorners) e [setRoundedCorners](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chart/#setRoundedCorners) da classe [Chart](https://reference.aspose.com/slides/pt/python-java/aspose.slides/chart/).

1. Crie uma instância da classe [Presentation](https://reference.aspose.com/slides/pt/python-java/aspose.slides/presentation/).
1. Adicione um gráfico ao slide.
1. Defina o tipo e o estilo de preenchimento da linha de borda do gráfico.
1. Habilite cantos arredondados.
1. Salve a apresentação modificada.

O exemplo a seguir demonstra estas etapas.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

# Crie uma instância da classe Presentation
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    chart.getLineFormat().setStyle(LineStyle.Single)
    chart.setRoundedCorners(True)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Posso definir preenchimentos semitransparentes para colunas/áreas mantendo a borda opaca?**

Sim. A transparência do preenchimento e o contorno são configurados separadamente. Isso é útil para melhorar a legibilidade da grade e dos dados em visualizações densas.

**Como lidar com rótulos de dados quando eles se sobrepõem?**

Reduza o tamanho da fonte, desative componentes de rótulo não essenciais (por exemplo, categorias), ajuste o deslocamento/posição do rótulo, exiba rótulos apenas para pontos selecionados, se necessário, ou altere o formato para "valor + legenda".

**Posso aplicar preenchimentos gradiente ou padrão às séries?**

Sim. Tanto preenchimentos sólidos quanto gradientes/padrões geralmente estão disponíveis. Na prática, use gradientes com moderação e evite combinações que reduzam o contraste com a grade e o texto.