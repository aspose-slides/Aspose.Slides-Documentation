---
title: Pythonban a bemutató diagramok formázása
linktitle: Diagram formázás
type: docs
weight: 60
url: /hu/python-java/chart-formatting/
keywords:
- diagram formázása
- diagram formázás
- diagram elem
- diagram tulajdonságok
- diagram beállítások
- diagram opciók
- betűtípus tulajdonságok
- lekerekített szegély
- PowerPoint
- prezentáció
- Python
- Aspose.Slides
description: "Ismerje meg a diagramok formázását az Aspose.Slides Python számára Java útján, és emelje fel PowerPoint prezentációját egyéni tengelyekkel, betűtípusokkal, számformátumokkal és lekerekített diagram szegélyekkel."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázhatók diagramok PowerPoint‑prezentációkban az Aspose.Slides használatával. Megmutatja, hogyan testreszabhatók a diagram kulcsfontosságú elemei, például a tengelyek, rácsvonalak, címek, jelmagyarázatok, ábraterület és falkitöltések, a diagram adatok megjelenésének és olvashatóságának javítása érdekében.

A cikk továbbá bemutatja, hogyan állítható be a betűtípus tulajdonsága a diagram szövegéhez, hogyan alkalmazhatók előre definiált számformátumok a diagram adataihoz, és hogyan engedélyezhetők lekerekített sarkok a diagram területén. Ezek a példák együtt megmutatják, hogyan szabályozható a diagram megjelenési stílusa és az adatmegjelenítés egy prezentációban.

## **Diagramelemek formázása**

Használja a [Diagram](https://reference.aspose.com/slides/python-java/aspose.slides/chart/)‑t a diagram címek, tengelyek, rácsvonalak, jelmagyarázatok és az ábraterület formázásához. Ez a példa egy vonaldiagramot hoz létre jelölőkkel és alapértelmezett adatokkal, majd külön szöveg‑ és vonalstílusokat alkalmaz az érték‑ és kategória‑tengelyekre. A betűméretek és vonalszélességek pontban vannak megadva; a kategória‑címkék 45 fokra vannak elfordítva.

Az értéktengely a [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat)‑t használja a forráscelláktól függetlenül. Skálája –2‑től 15‑ig terjed, főosztók léptéke 2, kisebb osztók 0.5. A példa százalékos formátumot kombinál a [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) ezrekre állított beállításával, ezért ezeket a beállításokat a saját adatai jelentéséhez és nagyságához igazítsa. A jelmagyarázat a ábraterületen kívül marad, mert a [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) `False`‑ra van állítva. A hátfal és a padló kitöltései a [getBackWall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getBackWall) és a [getFloor](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getFloor) segítségével konfigurálható, de ezek a felületek csak 3D diagramokban láthatók.

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

## **Diagram betűtípus tulajdonságainak beállítása**

Állítsa be a diagram szövegének alapértelmezett betűméretét a [Diagram.getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getTextFormat) segítségével. A példa egy csoportosított oszlopdiagramot hoz létre 20‑pontos betűtípussal, és az első sorra a [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue)‑t hívva engedélyezi az értékcímkéket. A saját explicit betűtípust beállító szövegelemek felülbírálhatják a diagram alapértelmezését.

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

## **Számformátum beállítása**

Használja a [ChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setPresetNumberFormat)‑t beépített számformátum alkalmazásához a diagram munkafüzet‑celláira. Ez a példa egy csoportosított oszlopdiagramot hoz létre alapértelmezett, cella‑alapú adatokkal, és az index 10‑es (`0.00%`) formátumot alkalmazza minden sor értékcellájára. Ez megváltoztatja, hogyan jelennek meg az értékek a munkafüzetben anélkül, hogy az alapszámok módosulnának; például a 0.25 25.00 %-ként jelenik meg. A tengely‑ és adatcímke‑formátumok külön‑külön is beállíthatók.

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
            data_point.getValue().getAsCell().setPresetNumberFormat(jpype.JByte(10))  # 0.00%

    presentation.save("PresetNumberFormat_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Az alábbi táblázat felsorolja a beépített számformátum‑indexeket a megfelelő Excel‑formátumokkal az angol (Egyesült Államok) nyelvterületen. A pontos formátumkarakterláncok és megjelenítésük alkalmazásonként és nyelvterületenként változhat, különösen a pénznemek és dátumok esetén. Néhány Excel‑formátum eltér az OOXML szabvány alapértelmezett formátumaitól, ahogyan azt a [Microsoft számformátum‑implementációs jegyzetek](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) leírja.

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

## **Diagramterület lekerekített szegélyek beállítása**

Hívja a [Diagram.setRoundedCorners](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setRoundedCorners)‑t `True`‑val a diagram területének sarkainak lekerekítéséhez. A példa egy csoportosított oszlopdiagramot hoz létre, majd a [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat)‑et használja a kontúr szilárd szürke színre és egyetlen vonalstílusra állításához, mielőtt mentené a prezentációt.

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

## **Meglévő diagram megjegyzések szerkesztése**

Egy diagram tartalmazhat saját alakzatokat, például egy szöveges megjegyzést, amely a jelentés állapotát magyarázza. Ezekhez az alakzatokhoz a [Diagram.getUserShapes](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getUserShapes)‑on keresztül férhet hozzá. A [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) által visszaadott gyűjtemény a diagram által birtokolt alakzatokat tartalmazza.

Egy egyszerű szövegdoboz, amely a diagram fölött helyezkedik el, a diára tartozik, még ha úgy is néz ki, mintha a diagram része lenne. Az [Slide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) bejárása megtalálja a diagramot és a szokásos diák alakzatait, de nem sorolja fel a diagramon belüli egyedi alakzatokat. A diagramcímek és adatcímkék külön diagramelemek, nem egyéni megjegyzések ebben a gyűjteményben.

Töltse le a [chart-annotations.pptx](chart-annotations.pptx)‑t, és helyezze az alkalmazás munkakönyvtárába. Az első dia egy diagramot tartalmaz egy csoportosított megjegyzéssel, amely a „Preliminary results” feliratot mutatja, egy diagram‑tulajdonú vonallal és egy egyszerű diára helyezett szövegdobozzal, amely a „Slide overlay” feliratot tartalmazza. A példa megkeresi az első diagramot ezen a dián, és a jelentés közzétételére készülve a megjegyzést „Final results”‑ra módosítja. Ellenőrzi, hogy a gyűjtemény nem üres, és csak olyan [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) elemet szerkeszt, amelynek a [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame) által visszaadott szövegtárolója nem `None`, és a várt szöveget tartalmazza.

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

A vonal és a diára helyezett szövegdoboz változatlan marad. Az alábbi képek az eredeti és a mentett, újra megnyitott állapotot mutatják:

| Szerkesztés előtt | Szerkesztés után |
| --- | --- |
| ![Diagram megjegyzés, amely az “Preliminary results” feliratot tartalmazza](chart-annotations-before.png) | ![Diagram megjegyzés, amely a “Final results” feliratot tartalmazza](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}

A példa csak a legfelső szintű, diagram‑tulajdonú alakzatokat vizsgálja. Ha egy megjegyzés egy [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/)‑ben van, akkor vizsgálja meg annak a csoportnak a [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) gyűjteményét is. Ezt rekurzívan ismételje a beágyazott csoportoknál, ugyanazt a szöveg‑ellenőrzést alkalmazva a gyermek alakzatokra. Maga a csoport egy tároló; ne kezelje szövegdobozként.

{{% /alert %}}

## **GYIK**

**Beállíthatok félig átlátszó kitöltéseket oszlopokhoz/területekhez, miközben a keret átlátszatlan marad?**

Igen. A kitöltés átlátszósága és a körvonal külön‑külön állítható be. Ez hasznos a rács és az adatok olvashatóságának javításához sűrű ábrázolásokban.

**Hogyan kezelhetem az adatcímkéket, amikor azok átfedik egymást?**

Csökkentse a betűméretet, tiltsa le a nem létfontosságú címkeelemeket (például a kategóriákat), állítsa be a címke pozícióját, szükség esetén csak a kiválasztott pontokhoz mutasson címkét, vagy válassza az „érték + jelmagyarázat” formátumot.

**Alkalmazhatok színátmenetes vagy mintás kitöltéseket sorozatokra?**

Igen. A sorozatok támogatják a szilárd, színátmenetes és mintás kitöltéseket. Gyakorlati tanács: használja a színátmeneteket mértékkel, és kerülje az olyan kombinációkat, amelyek csökkentik a kontrasztot a rács és a szöveg között.