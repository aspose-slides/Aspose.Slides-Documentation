---
title: Grafieken in presentatie opmaken in Python
linktitle: Grafiekopmaak
type: docs
weight: 60
url: /nl/python-java/chart-formatting/
keywords:
- grafiek opmaken
- grafiekopmaak
- grafiek entiteit
- grafiek eigenschappen
- grafiek instellingen
- grafiek opties
- lettertype eigenschappen
- afgeronde rand
- PowerPoint
- presentatie
- Python
- Aspose.Slides
description: "Leer grafiekopmaak in Aspose.Slides voor Python via Java en til uw PowerPoint-presentatie naar een professioneel, opvallend uiterlijk."
---
## **Overzicht**

Dit artikel legt uit hoe u grafieken in PowerPoint‑presentaties kunt opmaken met Aspose.Slides. Het toont hoe u belangrijke grafiekelementen zoals assen, rasterlijnen, titels, legenda’s, het plotgebied en wandvullingen kunt aanpassen om het uiterlijk en de leesbaarheid van grafiekgegevens te verbeteren.

Het laat ook zien hoe u font‑eigenschappen voor grafiekttekst instelt, vooraf gedefinieerde en aangepaste numerieke opmaak op grafiekgegevens toepast en afgeronde hoeken voor het grafiekgebied inschakelt. Samen laten deze voorbeelden zien hoe u zowel de visuele stijl als de gegevenspresentatie van grafieken in een presentatie kunt beheersen.

## **Grafiek‑entiteiten opmaken**
Aspose.Slides for Python via Java stelt ontwikkelaars in staat om aangepaste grafieken vanaf nul aan hun dia’s toe te voegen. Dit artikel legt uit hoe u verschillende grafiek‑entiteiten, waaronder de categorie‑ en waarde‑assen, kunt opmaken.

Aspose.Slides for Python via Java biedt een eenvoudige API voor het beheren van verschillende grafiek‑entiteiten en het opmaken ervan met aangepaste waarden:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.
1. Toegang tot een dia via de index.
1. Voeg een grafiek van het gewenste type toe met standaardgegevens (dit voorbeeld gebruikt [ChartType.LineWithMarkers](https://reference.aspose.com/slides/nl/python-java/aspose.slides/charttype/#LineWithMarkers)).
1. Open de waardeas van de grafiek en stel de volgende eigenschappen in:
   1. Stel **Line format** in voor de hoofd‑rasterlijnen van de waardeas.
   1. Stel **Line format** in voor de onder‑rasterlijnen van de waardeas.
   1. Stel **Number Format** in voor de waardeas.
   1. Stel **minimum, maximum, major, and minor units** in voor de waardeas.
   1. Stel **Text Properties** in voor de gegevens van de waardeas.
   1. Stel **Title** in voor de waardeas.
1. Open de categorie‑as van de grafiek en stel de volgende eigenschappen in:
   1. Stel **Line format** in voor de hoofd‑rasterlijnen van de categorie‑as.
   1. Stel **Line format** in voor de onder‑rasterlijnen van de categorie‑as.
   1. Stel **Text Properties** in voor de gegevens van de categorie‑as.
   1. Stel **Title** in voor de categorie‑as.
   1. Stel **Label Positioning** in voor de categorie‑as.
   1. Stel **Rotation Angle** in voor de labels van de categorie‑as.
1. Open de legende van de grafiek en stel de **text properties** in.
1. Toon de legende van de grafiek zonder dat deze overlapt met de grafiek.
1. Open de **secondary value axis** van de grafiek en stel de volgende eigenschappen in:
   1. Schakel de secundaire **value axis** in.
   1. Stel **Line Format** in voor de secundaire value axis.
   1. Stel **Number Format** in voor de secundaire value axis.
   1. Stel **minimum, maximum, major, and minor units** in voor de secundaire value axis.
1. Plot de eerste grafiekreeks op de secundaire value axis.
1. Stel de vulkleur van de achterwand van de grafiek in.
1. Stel de vulkleur van het plotgebied van de grafiek in.
1. Schrijf de aangepaste presentatie naar een PPTX‑bestand.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")
nullable_true = NullableBool.True_

    # Maak een instantie van de Presentation-klasse
    presentation = Presentation()
    try:
        # Toegang tot de eerste dia
        slide = presentation.getSlides().get_Item(0)

        # Voeg de voorbeeldgrafiek toe
        chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

        # Stel de grafiektitel in
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("")
        chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
        chart_title.setText("Sample Chart")
        chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
        chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
        chart_title.getPortionFormat().setFontHeight(20)
        chart_title.getPortionFormat().setFontBold(nullable_true)
        chart_title.getPortionFormat().setFontItalic(nullable_true)

        # Stel opmaak van hoofd‑rasterlijnen voor de waarde‑as in
        chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
        chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
        chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
        chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

        # Stel opmaak van onder‑rasterlijnen voor de waarde‑as in
        chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
        chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
        chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

        # Stel numeriek formaat van de waarde‑as in
        chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
        chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
        chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

        # Stel maximale en minimale waarden van de grafiek in
        chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
        chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
        chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
        chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

        chart.getAxes().getVerticalAxis().setMaxValue(15)
        chart.getAxes().getVerticalAxis().setMinValue(-2)
        chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
        chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

        # Stel tekst‑eigenschappen van de waarde‑as in
        value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
        value_axis_text.setFontBold(nullable_true)
        value_axis_text.setFontHeight(16)
        value_axis_text.setFontItalic(nullable_true)
        value_axis_text.getFillFormat().setFillType(FillType.Solid)
        value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
        value_axis_font = FontData("Times New Roman")
        value_axis_text.setLatinFont(value_axis_font)

        # Stel titel van de waarde‑as in
        chart.getAxes().getVerticalAxis().setTitle(True)
        chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
        value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
        value_axis_title.setText("Primary Axis")
        value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
        value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
        value_axis_title.getPortionFormat().setFontHeight(20)
        value_axis_title.getPortionFormat().setFontBold(nullable_true)
        value_axis_title.getPortionFormat().setFontItalic(nullable_true)

        # Stel opmaak van hoofd‑rasterlijnen voor de categorie‑as in
        chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
        chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN)
        chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

        # Stel opmaak van onder‑rasterlijnen voor de categorie‑as in
        chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
        chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
        chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

        # Stel tekst‑eigenschappen van de categorie‑as in
        category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
        category_axis_text.setFontBold(nullable_true)
        category_axis_text.setFontHeight(16)
        category_axis_text.setFontItalic(nullable_true)
        category_axis_text.getFillFormat().setFillType(FillType.Solid)
        category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
        category_axis_font = FontData("Arial")
        category_axis_text.setLatinFont(category_axis_font)

        # Stel categorie‑titel in
        chart.getAxes().getHorizontalAxis().setTitle(True)
        chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

        category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
        category_axis_title.setText("Sample Category")
        category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
        category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
        category_axis_title.getPortionFormat().setFontHeight(20)
        category_axis_title.getPortionFormat().setFontBold(nullable_true)
        category_axis_title.getPortionFormat().setFontItalic(nullable_true)

        # Stel positie van labels op de categorie‑as in
        chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)

        # Stel rotatie‑hoek van labels op de categorie‑as in
        chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

        # Stel tekst‑eigenschappen van de legenda in
        legend_text = chart.getLegend().getTextFormat().getPortionFormat()
        legend_text.setFontBold(nullable_true)
        legend_text.setFontHeight(16)
        legend_text.setFontItalic(nullable_true)
        legend_text.getFillFormat().setFillType(FillType.Solid)
        legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

        # Toon de grafieklegenda zonder overlappen met de grafiek

        chart.getLegend().setOverlay(False)

        chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(True)
        # Stel secundaire waarde‑as in
        chart.getAxes().getSecondaryVerticalAxis().setVisible(True)
        chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin)
        chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20)

        # Stel numeriek formaat van de secundaire waarde‑as in
        chart.getAxes().getSecondaryVerticalAxis().setNumberFormatLinkedToSource(False)
        chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds)
        chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%")

        # Stel maximale en minimale waarden van de grafiek in
        chart.getAxes().getSecondaryVerticalAxis().setAutomaticMajorUnit(False)
        chart.getAxes().getSecondaryVerticalAxis().setAutomaticMaxValue(False)
        chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinorUnit(False)
        chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinValue(False)

        chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20)
        chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5)
        chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5)
        chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0)

        # Stel kleur van de achterwand van de grafiek in
        chart.getBackWall().setThickness(1)
        chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
        chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

        chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
        chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)
        # Stel kleur van het plotgebied in
        chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
        chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

        # Sla de presentatie op
        presentation.save("FormattedChart.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

## **Font‑eigenschappen instellen voor een grafiek**
Aspose.Slides for Python via Java ondersteunt het instellen van font‑eigenschappen voor grafieken. Volg deze stappen om de font‑eigenschappen in te stellen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.
- Voeg een grafiek toe aan de dia.
- Stel de font‑hoogte in.
- Sla de aangepaste presentatie op.

Het volgende voorbeeld toont deze stappen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Maak een instantie van de Presentation-klasse
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Het numerieke formaat instellen**
Aspose.Slides for Python via Java biedt een eenvoudige API voor het beheren van grafiekgegevens‑formaten:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.
1. Toegang tot een dia via de index.
1. Voeg een grafiek van het gewenste type toe met standaardgegevens (dit voorbeeld gebruikt [ChartType.ClusteredColumn](https://reference.aspose.com/slides/nl/python-java/aspose.slides/charttype/#ClusteredColumn)).
1. Stel het vooraf gedefinieerde nummerformaat in op basis van de mogelijke vooraf ingestelde waarden.
1. Itereer door de gegevenscellen in elke grafiekreeks en stel hun nummerformaat in.
1. Sla de presentatie op.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Maak een instantie van de Presentation-klasse
presentation = Presentation()
try:
    # Toegang tot de eerste presentatiedia
    slide = presentation.getSlides().get_Item(0)

    # Voeg een standaard gegroepeerde kolomgrafiek toe
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)

    # Toegang tot de verzameling grafiekreeksen
    chart_series_collection = chart.getChartData().getSeries()

    # Doorloop elke grafiekreeks
    for chart_series in chart_series_collection:
        # Doorloop elk gegevenspunt in de reeks
        for data_point in chart_series.getDataPoints():
            # Stel het getalformaat in
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0.00%

    # Sla de presentatie op
    presentation.save("PresetNumberFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De beschikbare vooraf ingestelde nummerformaten en hun indexen staan hieronder vermeld:

|**0**|General|
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

## **Afgeronde randen voor het grafiekgebied instellen**
Aspose.Slides for Python via Java ondersteunt afgeronde hoeken voor het grafiekgebied via de [hasRoundedCorners](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chart/#hasRoundedCorners) en [setRoundedCorners](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chart/#setRoundedCorners) methoden van de [Chart](https://reference.aspose.com/slides/nl/python-java/aspose.slides/chart/) klasse.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/python-java/aspose.slides/presentation/) klasse.
1. Voeg een grafiek toe aan de dia.
1. Stel het vultype en de stijl van de randlijn van de grafiek in.
1. Schakel afgeronde hoeken in.
1. Sla de aangepaste presentatie op.

Het volgende voorbeeld toont deze stappen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

# Maak een instantie van de Presentation-klasse
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

**Kan ik halftransparante vullingen voor kolommen/gebieden instellen terwijl de rand ondoorzichtig blijft?**

Ja. De transparantie van de vulling en de omtrek worden afzonderlijk geconfigureerd. Dit is nuttig om de leesbaarheid van het raster en de gegevens in dichte visualisaties te verbeteren.

**Hoe kan ik omgaan met gegevenslabels wanneer ze overlappen?**

Verminder de lettergrootte, schakel niet‑essentiële labelonderdelen uit (bijvoorbeeld categorieën), stel de offset/positie van het label in, toon alleen labels voor geselecteerde punten indien nodig, of wijzig het formaat naar "value + legend".

**Kan ik verloop‑ of patroonvullingen op reeksen toepassen?**

Ja. Zowel effen als verloop‑/patroonvullingen zijn doorgaans beschikbaar. Gebruik in de praktijk verlopen met mate en vermijd combinaties die het contrast met het raster en de tekst verminderen.