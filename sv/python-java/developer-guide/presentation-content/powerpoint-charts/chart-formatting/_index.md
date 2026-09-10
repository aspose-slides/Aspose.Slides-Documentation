---
title: Formatera presentationsdiagram i Python
linktitle: Diagramformatering
type: docs
weight: 60
url: /sv/python-java/chart-formatting/
keywords:
- formatera diagram
- diagramformatering
- diagramobjekt
- diagramegenskaper
- diagraminställningar
- diagramalternativ
- teckensegenskaper
- rundade kanter
- PowerPoint
- presentation
- Python
- Aspose.Slides
description: "Lär dig diagramformatering i Aspose.Slides för Python via Java och lyft din PowerPoint-presentation med professionell, iögonfallande stil."
---
## **Översikt**

Den här artikeln förklarar hur du formaterar diagram i PowerPoint‑presentationer med Aspose.Slides. Den visar hur du anpassar viktiga diagramkomponenter som axlar, rutnätlinjer, titlar, förklaringar, diagramytan och väggfyllningar för att förbättra diagrammets utseende och läsbarhet.

Den demonstrerar också hur du anger teckensegenskaper för diagramtext, använder förinställda och anpassade numeriska format för diagramdata samt aktiverar rundade hörn för diagramområdet. Tillsammans visar dessa exempel hur du styr både den visuella stilen och datavisningen i diagram i en presentation.

## **Formatera diagramobjekt**
Aspose.Slides for Python via Java låter utvecklare lägga till anpassade diagram i sina bilder från grunden. Den här artikeln förklarar hur du formaterar olika diagramobjekt inklusive kategori‑ och värdeaxlar.

Aspose.Slides for Python via Java tillhandahåller ett enkelt API för att hantera olika diagramobjekt och formatera dem med anpassade värden:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Kom åt en bild efter dess index.
1. Lägg till ett diagram av önskad typ med standarddata (det här exemplet använder [ChartType.LineWithMarkers](https://reference.aspose.com/slides/sv/python-java/aspose.slides/charttype/#LineWithMarkers)).
1. Kom åt diagrammets värdeaxel och ange följande egenskaper:
   1. Ställ in **Linjeformat** för värdeaxelns huvudrutnätslinjer.
   1. Ställ in **Linjeformat** för värdeaxelns underrutnätslinjer.
   1. Ställ in **Talformat** för värdeaxeln.
   1. Ställ in **minimum, maximum, huvud‑ och underenheter** för värdeaxeln.
   1. Ställ in **Textegenskaper** för värdeaxelns data.
   1. Ställ in **Titel** för värdeaxeln.
1. Kom åt diagrammets kategori‑axel och ange följande egenskaper:
   1. Ställ in **Linjeformat** för kategori‑axelns huvudrutnätslinjer.
   1. Ställ in **Linjeformat** för kategori‑axelns underrutnätslinjer.
   1. Ställ in **Textegenskaper** för kategori‑axelns data.
   1. Ställ in **Titel** för kategori‑axeln.
   1. Ställ in **Etikettpositionering** för kategori‑axeln.
   1. Ställ in **Rotationsvinkel** för kategori‑axelns etiketter.
1. Kom åt diagrammets förklaring och ange dess **textegenskaper**.
1. Visa diagramförklaringen utan att den överlappar diagrammet.
1. Kom åt diagrammets **sekundära värdeaxel** och ange följande egenskaper:
   1. Aktivera den sekundära **värdeaxeln**.
   1. Ställ in **Linjeformat** för den sekundära värdeaxeln.
   1. Ställ in **Talformat** för den sekundära värdeaxeln.
   1. Ställ in **minimum, maximum, huvud‑ och underenheter** för den sekundära värdeaxeln.
1. Plotta den första diagramserien på den sekundära värdeaxeln.
1. Ställ in bakväggens fyllningsfärg för diagrammet.
1. Ställ in diagrammets plottyta fyllningsfärg.
1. Skriv den modifierade presentationen till en PPTX‑fil.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")
nullable_true = NullableBool.True_

# Skapa en instans av Presentation-klassen
presentation = Presentation()
try:
    # Åtkomst till den första bilden
    slide = presentation.getSlides().get_Item(0)

    # Lägg till exempeldiagrammet
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    # Ställ in diagramtitel
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(nullable_true)
    chart_title.getPortionFormat().setFontItalic(nullable_true)

    # Ställ in huvudrutnätslinjers format för värdeaxeln
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    # Ställ in underrutnätslinjers format för värdeaxeln
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # Ställ in talformat för värdeaxeln
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    # Ställ in diagrammets maximala och minimala värden
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    # Ställ in textegenskaper för värdeaxeln
    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(nullable_true)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(nullable_true)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    # Ställ in värdeaxelns titel
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(nullable_true)
    value_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # Ställ in huvudrutnätslinjers format för kategori‑axeln
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    # Ställ in underrutnätslinjers format för kategori‑axeln
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # Ställ in textegenskaper för kategori‑axeln
    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(nullable_true)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(nullable_true)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    # Ställ in kategori‑titel
    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(nullable_true)
    category_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # Ställ in etikettposition för kategori‑axeln
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)

    # Ställ in rotationsvinkel för kategori‑axlens etiketter
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    # Ställ in textegenskaper för förklaringen
    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(nullable_true)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(nullable_true)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    # Visa diagramförklaringen utan att den överlappar diagrammet

    chart.getLegend().setOverlay(False)

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(True)
    # Ställ in sekundär värdeaxel
    chart.getAxes().getSecondaryVerticalAxis().setVisible(True)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20)

    # Ställ in talformat för sekundär värdeaxel
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds)
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%")

    # Ställ in diagrammets maximala och minimala värden
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20)
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5)
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0)

    # Ställ in bakväggens färg för diagrammet
    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)
    # Ställ in färg för plotområdet
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    # Spara presentationen
    presentation.save("FormattedChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ställ in teckensegenskaper för ett diagram**
Aspose.Slides for Python via Java stöder att ange teckensegenskaper för diagram. Följ dessa steg för att ange teckensegenskaperna:

- Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
- Lägg till ett diagram på bilden.
- Ange teckenhöjd.
- Spara den modifierade presentationen.

Följande exempel demonstrerar dessa steg.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Skapa en instans av Presentation-klassen
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ställ in numeriskt format**
Aspose.Slides for Python via Java tillhandahåller ett enkelt API för att hantera diagramdatans format:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Kom åt en bild efter dess index.
1. Lägg till ett diagram av önskad typ med standarddata (det här exemplet använder [ChartType.ClusteredColumn](https://reference.aspose.com/slides/sv/python-java/aspose.slides/charttype/#ClusteredColumn)).
1. Ställ in det förinställda talformatet från de möjliga förinställda värdena.
1. Iterera genom datacellerna i varje diagramserie och ange deras talformat.
1. Spara presentationen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Skapa en instans av Presentation-klassen
presentation = Presentation()
try:
    # Åtkomst till den första presentationsbilden
    slide = presentation.getSlides().get_Item(0)

    # Lägg till ett standardklustrat stapeldiagram
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)

    # Åtkomst till diagramseriens samling
    chart_series_collection = chart.getChartData().getSeries()

    # Iterera genom varje diagramserie
    for chart_series in chart_series_collection:
        # Iterera genom varje datapunkt i serien
        for data_point in chart_series.getDataPoints():
            # Ställ in talformatet
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0,00%

    # Spara presentationen
    presentation.save("PresetNumberFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

De tillgängliga förinställda talformaten och deras index listas nedan:

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

## **Ställ in rundade kanter för diagramområdet**
Aspose.Slides for Python via Java stöder rundade hörn för diagramområdet via metoderna [hasRoundedCorners](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chart/#hasRoundedCorners) och [setRoundedCorners](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chart/#setRoundedCorners) i klassen [Chart](https://reference.aspose.com/slides/sv/python-java/aspose.slides/chart/).

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/python-java/aspose.slides/presentation/).
1. Lägg till ett diagram på bilden.
1. Ställ in fyllningstyp och stil för diagrammets kantlinje.
1. Aktivera rundade hörn.
1. Spara den modifierade presentationen.

Följande exempel demonstrerar dessa steg.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

# Skapa en instans av Presentation-klassen
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

**Kan jag ange halvgenomskinliga fyllningar för staplar/områden samtidigt som kanten förblir ogenomskinlig?**

Ja. Fyllningens transparens och konturen konfigureras separat. Detta är användbart för att förbättra läsbarheten av rutnätet och data i täta visualiseringar.

**Hur hanterar jag datamärkningarna när de överlappar varandra?**

Minska teckenstorleken, inaktivera icke‑nödvändiga märkningselement (t.ex. kategorier), justera märkningens förskjutning/position, visa märken endast för valda punkter om så behövs, eller byt format till ”värde + förklaring”.

**Kan jag använda gradient‑ eller mönsterfyllningar för serier?**

Ja. Både solida och gradient‑/mönsterfyllningar är i allmänhet tillgängliga. I praktiken bör gradienter användas sparsamt och kombinationer som minskar kontrasten mot rutnät och text undvikas.