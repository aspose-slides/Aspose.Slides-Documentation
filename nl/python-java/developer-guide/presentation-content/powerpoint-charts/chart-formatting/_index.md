---
title: Opmaak van presentatiediagrammen in Python
linktitle: Diagramopmaak
type: docs
weight: 60
url: /nl/python-java/chart-formatting/
keywords:
- diagram opmaken
- diagramopmaak
- diagramonderdeel
- diagrameigenschappen
- diagraminstellingen
- diagramopties
- lettertype‑eigenschappen
- afgeronde rand
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer diagramopmaak in Aspose.Slides voor Python via Java en til uw PowerPoint‑presentatie naar een hoger niveau met aangepaste assen, lettertypen, numerieke opmaken en afgeronde diagramranden."
---
## **Overzicht**

Dit artikel legt uit hoe je diagrammen in PowerPoint‑presentaties kunt opmaken met Aspose.Slides. Het toont hoe je belangrijke diagramonderdelen zoals assen, rasterlijnen, titels, legenda’s, het tekengebied en wandvullingen kunt aanpassen om de uitstraling en leesbaarheid van diagramgegevens te verbeteren.

Het laat ook zien hoe je lettertype‑eigenschappen voor diagramtekst kunt instellen, vooraf ingestelde numerieke opmaak kunt toepassen op diagramgegevens, en afgeronde hoeken voor het diagramgebied kunt inschakelen. Gezamenlijk laten deze voorbeelden zien hoe je zowel de visuele stijl als de gegevenspresentatie van diagrammen in een presentatie kunt beheersen.

Voor afzonderlijke vullingen en contouren bij stijgende en dalende intervallen, zie het [stock chart example](/slides/nl/python-java/create-chart/#create-stock-charts).

## **Diagramonderdelen opmaken**

Gebruik [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) om diagramtitels, assen, rasterlijnen, legenda’s en het tekengebied op te maken. Dit voorbeeld maakt een lijndiagram met markeringen en standaardgegevens, en past vervolgens afzonderlijke tekst‑ en lijnstijlen toe op de waarde‑ en categorie‑assen. Lettergrootte en lijndikte worden gespecificeerd in punten; categorielabels worden 45 graden geroteerd.

De waarde‑as gebruikt [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) onafhankelijk van de broncellen. De schaal loopt van –2 tot 15, met grote intervallen van 2 en kleine intervallen van 0,5. Het voorbeeld combineert procentopmaak met [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) ingesteld op duizendtallen, dus pas deze instellingen aan op basis van de betekenis en omvang van je gegevens. De legenda blijft buiten het tekengebied omdat [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) wordt aangeroepen met `False`. Achter‑wand‑ en vloer‑vullingen worden geconfigureerd via [getBackWall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getBackWall) en [getFloor](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getFloor), maar deze oppervlakken zijn alleen zichtbaar in 3D‑diagrammen.

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

## **Lettertype‑eigenschappen voor een diagram instellen**

Stel de standaard lettergrootte voor diagramtekst in via [Chart.getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getTextFormat). Het voorbeeld maakt een gegroepeerd kolomdiagram met een lettergrootte van 20 punt en schakelt waardelabels in voor de eerste serie via [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue). Tekstelementen met hun eigen expliciete lettertype‑instellingen kunnen de standaard van het diagram overschrijven.

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

## **Tekstkader‑opmaak hergebruiken voor een diagramlegenda**

Om een legenda af te stemmen op een dia‑kop, stel je het lettertype van de kop in via [getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) op de eerste alinea. Roep [copyFrom](https://reference.aspose.com/slides/python-java/aspose.slides/charttextformat/#copyFrom) aan op het format dat wordt geretourneerd door de legenda‑[getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat). Dit kopieert de tekstkader‑instellingen, de opmaak van de eerste alinea en de standaard lettertype‑eigenschappen van die alinea. Opmaak die direct op individuele delen of op latere alinea’s wordt toegepast, blijft lokaal voor de bron.

Het voorbeeld gebruikt een vette, 26‑punt Calibri‑kop in marineblauw als sjabloon. Na het stylen van de legenda wordt [copyTo](https://reference.aspose.com/slides/python-java/aspose.slides/charttextformat/#copyTo) aangeroepen om dezelfde opmaak toe te passen op een afzonderlijke bijschrift.

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

In de opgeslagen presentatie komen legenda en bijschrift overeen met de kop in grootte, gewicht en kleur. De legenda toont nog steeds de serienaam, en het bijschrift behoudt eigen tekst. Als een deel in het bijschrift al een expliciete lettergrootte heeft, heeft die grootte voorrang op het gekopieerde alinea‑default.

| Before copying | After copying |
| --- | --- |
| ![Quarterly sales chart with regular black legend labels and a black caption](legend-formatting-before.png) | ![The same chart with larger, bold navy legend labels and a matching caption](legend-formatting.png) |

## **Numeriek formaat instellen**

Gebruik [ChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setPresetNumberFormat) om een ingebouwd numeriek formaat toe te passen op diagramwerkboekcellen. Dit voorbeeld maakt een gegroepeerd kolomdiagram met standaard‑, cel‑gebaseerde gegevens en past formaat‑index 10 (`0.00%`) toe op elke serie‑waarde‑cel. Hierdoor wordt de weergave van de waarden in het werkboek aangepast zonder de onderliggende getallen te wijzigen; bijvoorbeeld, 0,25 wordt weergegeven als 25,00 %. As‑ en data‑label‑formaten kunnen afzonderlijk worden geconfigureerd.

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

De volgende tabel geeft ingebouwde numerieke formaat‑indices weer met representatieve Excel‑formaten voor de Engelse (Verenigde Staten) locale. De exacte formaat‑strings en hun weergave kunnen per toepassing en locale variëren, vooral voor valuta en datums. Sommige Excel‑formaten wijken ook af van de standaarden in OOXML, zoals beschreven in de [Microsoft's number format implementation notes](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528).

| Index | Format |
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

## **Afgeronde hoeken voor het diagramgebied instellen**

Roep [Chart.setRoundedCorners](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setRoundedCorners) aan met `True` om de hoeken van het diagramgebied af te ronden. Het voorbeeld maakt een gegroepeerd kolomdiagram en gebruikt [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) om de omtrek een effen grijze kleur en een enkele lijnstijl te geven vóór het opslaan van de presentatie.

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

## **Bestaande diagram‑annotaties bewerken**

Een diagram kan aangepaste vormen bevatten, zoals een tekst‑annotatie die de status van een rapport verklaart. Open deze vormen via [Chart.getUserShapes](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getUserShapes). De collectie die wordt geretourneerd door [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) bevat de door het diagram beheerde vormen.

Een gewone tekstvak geplaatst boven een diagram behoort tot de dia, zelfs als het eruitziet als onderdeel van het diagram. Door te itereren over [Slide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) wordt het diagram én de gewone dia‑vormen gevonden, maar niet de individuele vormen binnen het diagram. Diagram­titels en gegevenslabels zijn afzonderlijke diagramonderdelen, geen aangepaste annotaties in deze collectie.

Download [chart-annotations.pptx](chart-annotations.pptx) en plaats het in de werkomgeving van de applicatie. De eerste dia bevat een diagram met een niet‑gegroepeerde annotatie met de tekst “Preliminary results”, een diagram‑eigene lijn, en een gewoon tekstvak op de dia met de tekst “Slide overlay”. Het voorbeeld vindt het eerste diagram op die dia en wijzigt de annotatie naar “Final results” zodra het rapport klaar is om te publiceren. Het controleert of de collectie leeg is en bewerkt alleen een [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) met een tekstkader dat niet `None` is, geretourneerd door [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame) en de verwachte tekst.

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

De lijn en het tekstvak op de dia blijven ongewijzigd. De volgende afbeeldingen tonen de invoer en het opgeslagen, opnieuw geopende resultaat:

| Before editing | After editing |
| --- | --- |
| ![Chart annotation reading Preliminary results](chart-annotations-before.png) | ![Chart annotation reading Final results](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
Het voorbeeld inspecteert alleen de bovenliggende diagram‑eigende vormen. Als een annotatie zich binnen een [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/) bevindt, inspecteer dan ook de [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes)‑collectie van die groep. Herhaal dit recursief voor geneste groepen, waarbij dezelfde tekstcontroles op hun onderliggende vormen worden toegepast. Een groep zelf is een container; behandel deze niet als een tekstvak.
{{% /alert %}}

## **FAQ**

**Kan ik semi‑transparante vullingen voor kolommen/gebieden instellen terwijl de rand ondoorzichtig blijft?**

Ja. Vullings‑transparantie en de omtrek worden afzonderlijk geconfigureerd. Dit is nuttig om de leesbaarheid van het raster en de gegevens in drukke visualisaties te verbeteren.

**Hoe ga ik om met gegevenslabels die overlappen?**

Verklein de lettergrootte, schakel niet‑essentiële labelcomponenten uit (bijvoorbeeld categorieën), pas de label‑positie aan, toon alleen labels voor geselecteerde punten indien nodig, of schakel over naar het formaat “waarde + legenda”.

**Kan ik een verloop‑ of patroonvulling op een serie toepassen?**

Ja. Serien ondersteunen effen, verloop‑ en patroonvullingen. Gebruik in de praktijk verlopen spaarzaam en vermijd combinaties die het contrast met het raster en de tekst verminderen.