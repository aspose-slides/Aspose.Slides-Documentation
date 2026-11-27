---
title: Formatar Gráficos de Apresentação em Python
linktitle: Formatação de Gráficos
type: docs
weight: 60
url: /pt/python-java/chart-formatting/
keywords:
- formatar gráfico
- formatação de gráfico
- entidade de gráfico
- propriedades de gráfico
- configurações de gráfico
- opções de gráfico
- propriedades de fonte
- borda arredondada
- PowerPoint
- apresentação
- Python
- Aspose.Slides
description: "Aprenda a formatar gráficos no Aspose.Slides para Python via Java e eleve sua apresentação do PowerPoint com eixos personalizados, fontes, formatos numéricos e bordas arredondadas nos gráficos."
---
## **Visão geral**

Este artigo explica como formatar gráficos em apresentações do PowerPoint usando Aspose.Slides. Ele mostra como personalizar os principais elementos do gráfico, como eixos, linhas de grade, títulos, legendas, a área de plotagem e preenchimentos de paredes, para melhorar a aparência e a legibilidade dos dados do gráfico.

Ele também demonstra como definir propriedades de fonte para o texto do gráfico, aplicar formatos numéricos predefinidos aos dados do gráfico e habilitar cantos arredondados para a área do gráfico. Juntos, esses exemplos mostram como controlar tanto o estilo visual quanto a apresentação dos dados dos gráficos em uma apresentação.

Para preenchimentos e contornos separados em intervalos de alta e baixa, veja o [exemplo de gráfico de ações](/slides/pt/python-java/create-chart/#create-stock-charts).

## **Formatar entidades de gráfico**

Use [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) para formatar títulos de gráfico, eixos, linhas de grade, legendas e a área de plotagem. Este exemplo cria um gráfico de linha com marcadores e dados padrão, depois aplica estilos de texto e de linha separados aos seus eixos de valor e de categoria. Os tamanhos de fonte e a espessura das linhas são especificados em pontos; os rótulos de categoria são girados em 45 graus.

O eixo de valor usa [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) independentemente das células de origem. Sua escala vai de -2 a 15, com intervalos principais de 2 e intervalos menores de 0,5. O exemplo também combina formatação percentual com [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) definido para milhares, portanto ajuste essas configurações ao significado e à magnitude dos seus dados. A legenda permanece fora da área de plotagem porque [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) é chamado com `False`. Os preenchimentos da parede traseira e do piso são configurados através de [getBackWall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getBackWall) e [getFloor](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getFloor), mas essas superfícies são visíveis apenas em gráficos 3D.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(NullableBool.True_)
    chart_title.getPortionFormat().setFontItalic(NullableBool.True_)

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(NullableBool.True_)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(NullableBool.True_)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(NullableBool.True_)
    value_axis_title.getPortionFormat().setFontItalic(NullableBool.True_)

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    category_grid_color = Color(0, 128, 0)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(category_grid_color)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(NullableBool.True_)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(NullableBool.True_)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(NullableBool.True_)
    category_axis_title.getPortionFormat().setFontItalic(NullableBool.True_)

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(NullableBool.True_)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(NullableBool.True_)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    chart.getLegend().setOverlay(False)

    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    back_wall_color = Color(255, 165, 0)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(back_wall_color)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)

    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    presentation.save("FormattedChart_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Definir propriedades de fonte para um gráfico**

Defina o tamanho de fonte padrão para o texto do gráfico por meio de [Chart.getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getTextFormat). O exemplo cria um gráfico de colunas agrupadas com fonte de 20 pontos e habilita rótulos de valor para a primeira série através de [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue). Elementos de texto com suas próprias definições explícitas de fonte podem sobrescrever o padrão do gráfico.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)
    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Reutilizar formatação de quadro de texto para a legenda do gráfico**

Para combinar a legenda com o título de um slide, defina a fonte do título por meio de [getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) no primeiro parágrafo. Chame [copyFrom](https://reference.aspose.com/slides/python-java/aspose.slides/charttextformat/#copyFrom) no formato retornado por [getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat) da legenda. Isso copia as configurações do quadro de texto, a formatação do primeiro parágrafo e as propriedades de fonte padrão desse parágrafo. Formatação aplicada diretamente a porções individuais ou a parágrafos posteriores permanece local à origem.

O exemplo usa um título em Calibri negrito de 26 pontos em azul-marinho como modelo. Após estilizar a legenda, ele chama [copyTo](https://reference.aspose.com/slides/python-java/aspose.slides/charttextformat/#copyTo) para aplicar a mesma formatação a uma legenda separada.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, FontData, LegendPositionType, NullableBool, Presentation, SaveFormat, ShapeType, StyleType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    shapes = presentation.getSlides().get_Item(0).getShapes()
    
    heading = shapes.addAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, False)
    source_text_frame = heading.addTextFrame("Quarterly sales")
    paragraph = source_text_frame.getParagraphs().get_Item(0)
    font = paragraph.getParagraphFormat().getDefaultPortionFormat()
    font.setLatinFont(FontData("Calibri"))
    font.setFontHeight(26)
    font.setFontBold(NullableBool.True_)
    font.getFillFormat().setFillType(FillType.Solid)
    font.getFillFormat().getSolidFillColor().setColor(Color(32, 64, 96))

    chart = shapes.addChart(ChartType.ClusteredColumn, 40, 75, 640, 360)
    chart.setStyle(StyleType.Style3)
    workbook = chart.getChartData().getChartDataWorkbook()
    for column, series_name in enumerate(("Retail", "Online", "Wholesale"), start=1):
        workbook.getCell(0, 0, column).setValue(series_name)
    for quarter in range(1, 5):
        workbook.getCell(0, quarter, 0).setValue(f"Q{quarter}")

    chart.setLegend(True)
    legend = chart.getLegend()
    legend.setPosition(LegendPositionType.Bottom)
    legend_format = legend.getTextFormat()
    legend_format.copyFrom(source_text_frame)

    caption = shapes.addAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, False)
    caption_text_frame = caption.addTextFrame("Sales in millions of dollars")
    legend_format.copyTo(caption_text_frame)

    presentation.save("legend-formatting.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Na apresentação salva, a legenda e a legenda secundária coincidem com o título em tamanho, peso e cor. A legenda ainda exibe os nomes das séries, e a legenda secundária mantém seu próprio texto. Se uma porção da legenda secundária já possuir um tamanho de fonte explícito, esse tamanho tem precedência sobre o padrão do parágrafo copiado.

| Antes da cópia | Depois da cópia |
| --- | --- |
| ![Gráfico de vendas trimestrais com legendas pretas regulares e legenda secundária preta](legend-formatting-before.png) | ![O mesmo gráfico com legendas maiores, negrito, azul-marinho e legenda secundária correspondente](legend-formatting.png) |

## **Definir o formato numérico**

Use [ChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setPresetNumberFormat) para aplicar um formato numérico interno às células da planilha do gráfico. Este exemplo cria um gráfico de colunas agrupadas com dados padrão baseados em células e aplica o índice de formato 10 (`0.00%`) a cada célula de valor da série. Isso altera a forma como os valores são exibidos na planilha sem mudar os números subjacentes; por exemplo, 0,25 é exibido como 25,00 %. Formatos de eixo e de rótulo de dados podem ser configurados separadamente.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)
    chart_series_collection = chart.getChartData().getSeries()

    for chart_series in chart_series_collection:
        for data_point in chart_series.getDataPoints():
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0,00%

    presentation.save("PresetNumberFormat_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

A tabela a seguir lista os índices de formatos numéricos internos com formatos representativos do Excel para a localidade English (United States). As cadeias de formato exatas e sua exibição podem variar por aplicativo e localidade, particularmente para moeda e datas. Alguns formatos do Excel também diferem dos padrões padrão do OOXML, conforme descrito nas [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Índice | Formato |
| --- | --- |
| 0 | `General` |
| 1 | `0` |
| 2 | `0.00` |
| 3 | `#,##0` |
| 4 | `#,##0.00` |
| 5 | `"$"#,##0_);("$"#,##0)` |
| 6 | `"$"#,##0_);[Red]("$"#,##0)` |
| 7 | `"$"#,##0.00_);("$"#,##0.00)` |
| 8 | `"$"#,##0.00_);[Red]("$"#,##0.00)` |
| 9 | `0%` |
| 10 | `0.00%` |
| 11 | `0.00E+00` |
| 12 | `# ?/?` |
| 13 | `# ??/??` |
| 14 | `m/d/yyyy` |
| 15 | `d-mmm-yy` |
| 16 | `d-mmm` |
| 17 | `mmm-yy` |
| 18 | `h:mm AM/PM` |
| 19 | `h:mm:ss AM/PM` |
| 20 | `h:mm` |
| 21 | `h:mm:ss` |
| 22 | `m/d/yyyy h:mm` |
| 37 | `#,##0_);(#,##0)` |
| 38 | `#,##0_);[Red](#,##0)` |
| 39 | `#,##0.00_);(#,##0.00)` |
| 40 | `#,##0.00_);[Red](#,##0.00)` |
| 41 | `_(* #,##0_);_(* (#,##0);_(* "-"_);_(@_)` |
| 42 | `_("$"* #,##0_);_("$"* (#,##0);_("$"* "-"_);_(@_)` |
| 43 | `_(* #,##0.00_);_(* (#,##0.00);_(* "-"??_);_(@_)` |
| 44 | `_("$"* #,##0.00_);_("$"* (#,##0.00);_("$"* "-"??_);_(@_)` |
| 45 | `mm:ss` |
| 46 | `[h]:mm:ss` |
| 47 | `mm:ss.0` |
| 48 | `##0.0E+0` |
| 49 | `@` |

## **Definir cantos arredondados da área do gráfico**

Chame [Chart.setRoundedCorners](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setRoundedCorners) com `True` para arredondar os cantos da área do gráfico. O exemplo cria um gráfico de colunas agrupadas e usa [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) para dar ao seu contorno uma cor cinza sólida e um estilo de linha única antes de salvar a apresentação.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400)
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid)
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart.getLineFormat().setStyle(LineStyle.Single)
    chart.setRoundedCorners(True)

    presentation.save("out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Editar anotações de gráfico existentes**

Um gráfico pode conter formas personalizadas, como uma anotação de texto explicando o status de um relatório. Acesse essas formas por meio de [Chart.getUserShapes](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getUserShapes). A coleção retornada por [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) contém as formas de propriedade do gráfico.

Uma caixa de texto comum posicionada sobre um gráfico pertence ao slide, mesmo que pareça parte do gráfico. Percorrer [Slide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) encontra o gráfico e as formas comuns do slide, mas não enumera as formas individuais dentro do gráfico. Títulos de gráfico e rótulos de dados são elementos de gráfico separados, não anotações personalizadas nesta coleção.

Baixe [chart-annotations.pptx](chart-annotations.pptx) e coloque-o no diretório de trabalho da aplicação. Seu primeiro slide contém um gráfico com uma anotação desagrupada lendo "Preliminary results", uma linha de propriedade do gráfico e uma caixa de texto comum do slide lendo "Slide overlay". O exemplo encontra o primeiro gráfico naquele slide e altera a anotação para "Final results" quando o relatório estiver pronto para publicação. Ele verifica se a coleção está vazia e edita somente um [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) com quadro de texto diferente de `None` retornado por [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame) e com o texto esperado.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, Chart, Presentation, SaveFormat

presentation = Presentation("chart-annotations.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    chart = None
    for shape in slide.getShapes():
        if isinstance(shape, Chart):
            chart = shape
            break

    if chart is None or chart.getUserShapes().getShapes().size() == 0:
        print("No chart or chart-owned shapes found.")
    else:
        updated = False
        for shape in chart.getUserShapes().getShapes():
            if isinstance(shape, AutoShape):
                text_frame = shape.getTextFrame()
                if text_frame is not None and text_frame.getText() == "Preliminary results":
                    text_frame.setText("Final results")
                    updated = True
                    break

        if updated:
            presentation.save("chart-annotations-updated.pptx", SaveFormat.Pptx)
        else:
            print("No matching text annotation found.")
finally:
    presentation.dispose()
```

A linha e a caixa de texto do slide permanecem inalteradas. As imagens a seguir mostram a entrada e o resultado salvo e reaberto:

| Antes da edição | Depois da edição |
| --- | --- |
| ![Anotação do gráfico lendo Preliminary results](chart-annotations-before.png) | ![Anotação do gráfico lendo Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
O exemplo inspeciona apenas as formas de propriedade do gráfico de nível superior. Se uma anotação estiver dentro de um [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/), inspecione também a coleção [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) desse grupo. Repita isso recursivamente para grupos aninhados, aplicando as mesmas verificações de texto às suas formas filhas. Um grupo em si é um contêiner; não o trate como uma caixa de texto.
{{% /alert %}}

## **Perguntas frequentes**

**Posso definir preenchimentos semitransparentes para colunas/áreas mantendo a borda opaca?**

Sim. A transparência do preenchimento e o contorno são configurados separadamente. Isso é útil para melhorar a legibilidade da grade e dos dados em visualizações densas.

**Como posso lidar com rótulos de dados quando eles se sobrepõem?**

Reduza o tamanho da fonte, desative componentes de rótulo não essenciais (por exemplo, categorias), ajuste a posição do rótulo, exiba rótulos somente para pontos selecionados se necessário ou troque o formato para "valor + legenda".

**Posso aplicar preenchimentos degradê ou padrão às séries?**

Sim. As séries suportam preenchimentos sólidos, degradê e padrão. Na prática, use degradês com moderação e evite combinações que reduzam o contraste com a grade e o texto.