---
title: "Prezentációk diagramjainak formázása Pythonban"
linktitle: "Diagram formázása"
type: docs
weight: 60
url: /hu/python-java/chart-formatting/
keywords:
- "diagram formázása"
- "diagram formázás"
- "diagram elem"
- "diagram tulajdonságok"
- "diagram beállítások"
- "diagram opciók"
- "betűtípus tulajdonságok"
- "lekerekített szegély"
- "PowerPoint"
- "prezentáció"
- "Python"
- "Aspose.Slides"
description: "Ismerje meg a diagramok formázását az Aspose.Slides for Python via Java-ban, és emelje fel PowerPoint prezentációját professzionális, figyelemfelkeltő stílussal."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázhatók diagramok PowerPoint‑prezentációkban az Aspose.Slides használatával. Megmutatja, hogyan testreszabhatók a diagram kulcsfontosságú elemei, például tengelyek, rácsvonalak, címek, jelmagyarázatok, a diagramterület és a falak kitöltései a diagramadatok megjelenésének és olvashatóságának javítása érdekében.  

Emellett bemutatja, hogyan állítható be a diagram szövegének betűtípus‑tulajdonsága, hogyan alkalmazhatók előre definiált és egyéni numerikus formátumok a diagram adataira, valamint hogyan engedélyezhetők a lekerekített sarkok a diagramterületen. Ezek a példák együtt megmutatják, hogyan irányítható a diagramok vizuális stílusa és adatmegjelenítése egy prezentációban.

## **Diagramelemek formázása**
Aspose.Slides for Python via Java lehetővé teszi a fejlesztők számára, hogy egyedileg testre szabott diagramokat hozzanak létre a diákon a semmiből. Ez a cikk bemutatja, hogyan formázhatók a különböző diagramelemek, beleértve a kategória‑ és értéktengelyeket is.

Aspose.Slides for Python via Java egy egyszerű API‑t biztosít a különböző diagramelemek kezeléséhez és egyedi értékekkel való formázásukhoz:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.  
1. Érjen el egy diát az indexe alapján.  
1. Adjon hozzá egy kívánt típusú diagramot alapértelmezett adatokkal (ez a példa a [ChartType.LineWithMarkers](https://reference.aspose.com/slides/hu/python-java/aspose.slides/charttype/#LineWithMarkers) típust használja).  
1. Hozzáférés a diagram értéktengelyéhez, és a következő tulajdonságok beállítása:  
   1. Állítsa be a **Line format**‑ot az értéktengely fő rácsvonalaihoz.  
   1. Állítsa be a **Line format**‑ot az értéktengely alacsonyabb rácsvonalaihoz.  
   1. Állítsa be a **Number Format**‑t az értéktengelyhez.  
   1. Állítsa be az **minimum, maximum, major, and minor units**‑t az értéktengelyhez.  
   1. Állítsa be a **Text Properties**‑t az értéktengely adatainak.  
   1. Állítsa be a **Title**‑t az értéktengelyhez.  
1. Hozzáférés a diagram kategória‑tengelyéhez, és a következő tulajdonságok beállítása:  
   1. Állítsa be a **Line format**‑ot a kategória tengely fő rácsvonalaihoz.  
   1. Állítsa be a **Line format**‑ot a kategória tengely alacsonyabb rácsvonalaihoz.  
   1. Állítsa be a **Text Properties**‑t a kategória tengely adatainak.  
   1. Állítsa be a **Title**‑t a kategória tengelyhez.  
   1. Állítsa be a **Label Positioning**‑t a kategória tengelyhez.  
   1. Állítsa be a **Rotation Angle**‑t a kategória tengely címkéihez.  
1. Hozzáférés a diagram jelmagyarázatához, és állítsa be a **text properties**‑t.  
1. Jelenítse meg a diagram jelmagyarázatát úgy, hogy ne fedje át a diagramot.  
1. Hozzáférés a diagram **secondary value axis**‑hez, és a következő tulajdonságok beállítása:  
   1. Engedélyezze a másodlagos **value axis**‑t.  
   1. Állítsa be a **Line Format**‑t a másodlagos értéktengelyhez.  
   1. Állítsa be a **Number Format**‑t a másodlagos értéktengelyhez.  
   1. Állítsa be az **minimum, maximum, major, and minor units**‑t a másodlagos értéktengelyhez.  
1. Jelenítse meg az első diagram sorozatot a másodlagos értéktengelyen.  
1. Állítsa be a diagram hátfal kitöltő színét.  
1. Állítsa be a diagram ábrázolási területének kitöltő színét.  
1. Írja a módosított prezentációt egy PPTX fájlba.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, DisplayUnitType, FillType, FontData, LineDashStyle, LineStyle, NullableBool, Presentation, PresetColor, SaveFormat, TickLabelPositionType

Color = jpype.JClass("java.awt.Color")
nullable_true = NullableBool.True_

# Hozzon létre egy példányt a Presentation osztályból
presentation = Presentation()
try:
    # Érje el az első diát
    slide = presentation.getSlides().get_Item(0)

    # Adja hozzá a minta diagramot
    chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400)

    # Állítsa be a diagram címet
    chart.setTitle(True)
    chart.getChartTitle().addTextFrameForOverriding("")
    chart_title = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    chart_title.setText("Sample Chart")
    chart_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    chart_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    chart_title.getPortionFormat().setFontHeight(20)
    chart_title.getPortionFormat().setFontBold(nullable_true)
    chart_title.getPortionFormat().setFontItalic(nullable_true)

    # Állítsa be az értéktengely fő rácsvonalainak formátumát
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5)
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot)

    # Állítsa be az értéktengely alacsonyabb rácsvonalainak formátumát
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED)
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # Állítsa be az értéktengely számformátumát
    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands)
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%")

    # Állítsa be a diagram maximális és minimális értékeit
    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getVerticalAxis().setMaxValue(15)
    chart.getAxes().getVerticalAxis().setMinValue(-2)
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0)

    # Állítsa be az értéktengely szövegtulajdonságait
    value_axis_text = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat()
    value_axis_text.setFontBold(nullable_true)
    value_axis_text.setFontHeight(16)
    value_axis_text.setFontItalic(nullable_true)
    value_axis_text.getFillFormat().setFillType(FillType.Solid)
    value_axis_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen)
    value_axis_font = FontData("Times New Roman")
    value_axis_text.setLatinFont(value_axis_font)

    # Állítsa be az értéktengely címét
    chart.getAxes().getVerticalAxis().setTitle(True)
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("")
    value_axis_title = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    value_axis_title.setText("Primary Axis")
    value_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    value_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    value_axis_title.getPortionFormat().setFontHeight(20)
    value_axis_title.getPortionFormat().setFontBold(nullable_true)
    value_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # Állítsa be a kategória tengely fő rácsvonalainak formátumát
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.GREEN)
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5)

    # Állítsa be a kategória tengely alacsonyabb rácsvonalainak formátumát
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW)
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3)

    # Állítsa be a kategória tengely szövegtulajdonságait
    category_axis_text = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat()
    category_axis_text.setFontBold(nullable_true)
    category_axis_text.setFontHeight(16)
    category_axis_text.setFontItalic(nullable_true)
    category_axis_text.getFillFormat().setFillType(FillType.Solid)
    category_axis_text.getFillFormat().getSolidFillColor().setColor(Color.BLUE)
    category_axis_font = FontData("Arial")
    category_axis_text.setLatinFont(category_axis_font)

    # Állítsa be a kategória címet
    chart.getAxes().getHorizontalAxis().setTitle(True)
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("")

    category_axis_title = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0)
    category_axis_title.setText("Sample Category")
    category_axis_title.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
    category_axis_title.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)
    category_axis_title.getPortionFormat().setFontHeight(20)
    category_axis_title.getPortionFormat().setFontBold(nullable_true)
    category_axis_title.getPortionFormat().setFontItalic(nullable_true)

    # Állítsa be a kategória tengely feliratának pozícióját
    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low)

    # Állítsa be a kategória tengely feliratának forgatásának szögét
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45)

    # Állítsa be a jelmagyarázat szövegtulajdonságait
    legend_text = chart.getLegend().getTextFormat().getPortionFormat()
    legend_text.setFontBold(nullable_true)
    legend_text.setFontHeight(16)
    legend_text.setFontItalic(nullable_true)
    legend_text.getFillFormat().setFillType(FillType.Solid)
    legend_text.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed)

    # Jelenítse meg a diagram jelmagyarázatát anélkül, hogy átfedné a diagramot

    chart.getLegend().setOverlay(False)

    chart.getChartData().getSeries().get_Item(0).setPlotOnSecondAxis(True)
    # Állítsa be a másodlagos értéktengelyt
    chart.getAxes().getSecondaryVerticalAxis().setVisible(True)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setStyle(LineStyle.ThickBetweenThin)
    chart.getAxes().getSecondaryVerticalAxis().getFormat().getLine().setWidth(20)

    # Állítsa be a másodlagos értéktengely számformátumát
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormatLinkedToSource(False)
    chart.getAxes().getSecondaryVerticalAxis().setDisplayUnit(DisplayUnitType.Hundreds)
    chart.getAxes().getSecondaryVerticalAxis().setNumberFormat("0.0%")

    # Állítsa be a diagram maximális és minimális értékeit
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMajorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMaxValue(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinorUnit(False)
    chart.getAxes().getSecondaryVerticalAxis().setAutomaticMinValue(False)

    chart.getAxes().getSecondaryVerticalAxis().setMaxValue(20)
    chart.getAxes().getSecondaryVerticalAxis().setMinValue(-5)
    chart.getAxes().getSecondaryVerticalAxis().setMinorUnit(0.5)
    chart.getAxes().getSecondaryVerticalAxis().setMajorUnit(2.0)

    # Állítsa be a diagram hátfal színét
    chart.getBackWall().setThickness(1)
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid)
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.ORANGE)

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid)
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED)
    # Állítsa be a diagram ábrázolási terület színét
    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid)
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan)

    # Mentse el a prezentációt
    presentation.save("FormattedChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Betűtípus tulajdonságok beállítása diagramhoz**
Az Aspose.Slides for Python via Java támogatja a diagramok betűtípus‑tulajdonságainak beállítását. Kövesse az alábbi lépéseket a betűtípus‑tulajdonságok beállításához:

- Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.  
- Adjon hozzá egy diagramot a diához.  
- Állítsa be a betűmagasságot.  
- Mentse el a módosított prezentációt.

A következő példa bemutatja ezeket a lépéseket.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Hozzon létre egy példányt a Presentation osztályból
presentation = Presentation()
try:
    chart = presentation.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400)

    chart.getTextFormat().getPortionFormat().setFontHeight(20)
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(True)

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Numerikus formátum beállítása**
Aspose.Slides for Python via Java egy egyszerű API‑t biztosít a diagramadat-formátumok kezeléséhez:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.  
1. Érjen el egy diát az indexe alapján.  
1. Adjon hozzá egy kívánt típusú diagramot alapértelmezett adatokkal (ez a példa a [ChartType.ClusteredColumn](https://reference.aspose.com/slides/hu/python-java/aspose.slides/charttype/#ClusteredColumn) típust használja).  
1. Állítsa be az előre definiált számformátumot a lehetséges előre definiált értékek közül.  
1. Járja végig az adatcellákat minden diagram sorozatban, és állítsa be azok számformátumát.  
1. Mentse el a prezentációt.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, Presentation, SaveFormat

# Hozzon létre egy példányt a Presentation osztályból
presentation = Presentation()
try:
    # Érje el az első prezentációs diát
    slide = presentation.getSlides().get_Item(0)

    # Adjon hozzá egy alapértelmezett csoportosított oszlop diagramot
    chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400)

    # Érje el a diagram sorozatok gyűjteményét
    chart_series_collection = chart.getChartData().getSeries()

    # Iteráljon végig minden diagram sorozaton
    for chart_series in chart_series_collection:
        # Iteráljon végig a sorozat minden adatpontján
        for data_point in chart_series.getDataPoints():
            # Állítsa be a számformátumot
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0.00%

    # Mentse el a prezentációt
    presentation.save("PresetNumberFormat.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az elérhető előre definiált számformátumok és azok indexei az alábbiak:

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

## **Diagramterület lekerekített szegélyek beállítása**
Aspose.Slides for Python via Java a [hasRoundedCorners](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/#hasRoundedCorners) és a [setRoundedCorners](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/#setRoundedCorners) metódusokkal támogatja a diagramterület lekerekített sarkait a [Chart](https://reference.aspose.com/slides/hu/python-java/aspose.slides/chart/) osztályban.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/python-java/aspose.slides/presentation/) osztályból.  
1. Adjon hozzá egy diagramot a diához.  
1. Állítsa be a diagram szegélyvonal típusát és stílusát.  
1. Engedélyezze a lekerekített sarkokat.  
1. Mentse el a módosított prezentációt.

A következő példa bemutatja ezeket a lépéseket.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ChartType, FillType, LineStyle, Presentation, SaveFormat

    # Hozzon létre egy példányt a Presentation osztályból
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

## **GYIK**

**Beállíthatok félig átlátszó kitöltéseket oszlopokhoz/területekhez, miközben a szegély opak marad?**  
Igen. A kitöltés átlátszósága és a körvonal külön‑külön konfigurálható. Ez hasznos a rács és az adatok olvashatóságának javításához sűrű vizualizációk esetén.

**Hogyan kezeljem az adatcímkéket, ha átfedik egymást?**  
Csökkentse a betűméretet, tiltsa le a nem lényeges címkeösszetevőket (például a kategóriákat), állítsa be a címke eltolását vagy helyzetét, szükség esetén csak a kiválasztott pontok címkéit jelenítse meg, vagy válassza a „value + legend” formátumot.

**Alkalmazhatok színátmenetes vagy mintás kitöltéseket a sorozatokra?**  
Igen. Mind a szilárd, mind a színátmenetes/mintás kitöltések általában elérhetők. Gyakorlatban használjon színátmeneteket mértékkel, és kerülje az olyan kombinációkat, amelyek csökkentik a kontrasztot a rácshoz és a szöveghez.