---
title: Prezentációs diagramok formázása Pythonban
linktitle: Diagramformázás
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
description: "Ismerje meg a diagramok formázását az Aspose.Slides for Python via Java segítségével, és emelje fel PowerPoint prezentációját egyedi tengelyekkel, betűtípusokkal, számformátumokkal és lekerekített diagram szegélyekkel."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázhatók diagramok PowerPoint-prezentációkban az Aspose.Slides használatával. Megmutatja, hogyan testreszabhatók a diagram kulcselemei, például tengelyek, rasztervonalak, címek, jelmagyarázatok, a rajzoló terület és a fal kitöltései, a diagram adatainak megjelenésének és olvashatóságának javítása érdekében.

A cikk bemutatja továbbá, hogyan állíthatók be a diagram szövegének betűtípus‑tulajdonságai, hogyan alkalmazhatók előre definiált számformátumok a diagram adataira, valamint hogyan lehet lekerekített sarkokat engedélyezni a diagram területen. Ezek a példák együttesen azt mutatják, hogyan lehet a diagramok vizuális stílusát és adatmegjelenítését egy prezentációban szabályozni.

A fel- és lemenő időszakokra külön kitöltések és körvonalak esetén lásd a [stock chart példa](/slides/hu/python-java/create-chart/#create-stock-charts).

## **Diagramelemek formázása**

Használja a [Diagram](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) elemet diagramcímek, tengelyek, rasztervonalak, jelmagyarázatok és a rajzoló terület formázásához. Ez a példa egy vonaldiagramot hoz létre jelölőkkel és alapértelmezett adatokkal, majd külön szöveg‑ és vonalstílusokat alkalmaz az érték‑ és kategóriatengelyeire. A betűméretek és vonalszélességek pontban vannak megadva; a kategóriacímkék 45 fokban vannak elforgatva.

Az értéktengely a [setNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setNumberFormat) függvényt használja a forráscelláktól függetlenül. A skála -2‑től 15‑ig terjed, nagyobb intervallumok 2‑esek, kisebbek 0,5‑osak. A példa a százalékos formázást kombinálja a [setDisplayUnit](https://reference.aspose.com/slides/python-java/aspose.slides/axis/#setDisplayUnit) ezrekre beállításával, ezért ezeket a beállításokat az adatok jelentésének és nagyságának megfelelően kell módosítani. A jelmagyarázat a rajzoló terület kívül marad, mert a [setOverlay](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#setOverlay) `False` értékkel van meghívva. A hátfal és a talaj kitöltései a [getBackWall](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getBackWall) és a [getFloor](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getFloor) segítségével vannak beállítva, de ezek a felületek csak 3D diagramokban láthatóak.

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

## **Betűtípus‑tulajdonságok beállítása diagramhoz**

Állítsa be a diagram szövegének alapértelmezett betűméretét a [Diagram.getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getTextFormat) segítségével. A példa egy klaszter oszlopdiagramot hoz létre 20 pont betűmérettel, és az első sorozat értékcímkéit a [setShowValue](https://reference.aspose.com/slides/python-java/aspose.slides/datalabelformat/#setShowValue) függvénnyel engedélyezi. Azok a szövegelemek, amelyek saját explicit betűtípusbeállításokkal rendelkeznek, felülírhatják a diagram alapértelmezését.

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

## **Szövegkeret formázás újrahasználata diagram jelmagyarázatnál**

A jelmagyarázatot a diacímhez igazítva állítsa be a címsor betűtípusát a [getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) függvénnyel az első bekezdésen. Hívja meg a [copyFrom](https://reference.aspose.com/slides/python-java/aspose.slides/charttextformat/#copyFrom) függvényt a jelmagyarázat [getTextFormat](https://reference.aspose.com/slides/python-java/aspose.slides/legend/#getTextFormat) által visszaadott formátumon. Ez átmásolja a szövegkeret beállításait, az első bekezdés formázását, valamint annak alapértelmezett betűtípus‑tulajdonságait. Az egyes részekre vagy későbbi bekezdésekre közvetlenül alkalmazott formázás a forráson marad helyi.

A példa egy félkövér, 26 pont Calibri címet kék színben használ sablonként. A jelmagyarázat stílusozása után a [copyTo](https://reference.aspose.com/slides/python-java/aspose.slides/charttextformat/#copyTo) függvényt hívja meg, hogy ugyanazt a formázást egy külön feliratra alkalmazza.

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

A mentett prezentációban a jelmagyarázat és a felirat méret, súly és szín tekintetében megegyezik a címmel. A jelmagyarázat továbbra is a sorozatneveket jeleníti meg, a felirat pedig a saját szövegét tartja meg. Ha a felirat egy részében már explicit betűméret van megadva, az a méret felülírja a másolt bekezdés alapértelmezését.

| Másolás előtt | Másolás után |
| --- | --- |
| ![Negyedéves eladási diagram rendszeres fekete jelmagyarázati címkékkel és fekete felirattal](legend-formatting-before.png) | ![Ugyanez a diagram nagyobb, vastag tengerkék jelmagyarázati címkékkel és egyező felirattal](legend-formatting.png) |

## **Számformátum beállítása**

Használja a [DiagramAdatCella.setPresetNumberFormat](https://reference.aspose.com/slides/python-java/aspose.slides/chartdatacell/#setPresetNumberFormat) függvényt beépített számformátum alkalmazásához a diagram munkafüzetcelláira. Ez a példa egy klaszter oszlopdiagramot hoz létre alapértelmezett, cella‑alapú adatokkal, és a 10‑es formátumindexet (`0.00%`) minden sorozat értékcellájára alkalmazza. Ez megváltoztatja, hogyan jelennek meg az értékek a munkafüzetben anélkül, hogy a tényleges számok módosulnának; például a 0,25 25,00%-ként jelenik meg. Az tengely‑ és adatcímke‑formátumok külön is beállíthatók.

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

Az alábbi táblázat felsorolja a beépített számformátum‑indexeket az angol (USA) helyi beállításokhoz tartozó tipikus Excel‑formátumokkal. A pontos formátumkarakterláncok és megjelenítésük alkalmazásonként és helyi beállításonként változhat, különösen pénznem és dátum esetén. Néhány Excel‑formátum eltér az OOXML szabvány alapértelmezettjeitől, amint azt a [Microsoft számformátum‑implementációs megjegyzéseiben](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) leírják.

| Index | Formátum |
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

## **Diagramterület lekerekített szegélyeinek beállítása**

Hívja meg a [Diagram.setRoundedCorners](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#setRoundedCorners) függvényt `True` értékkel a diagram terület sarkainak lekerekítéséhez. A példa egy klaszter oszlopdiagramot hoz létre, és a [getLineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getLineFormat) segítségével szilárd szürke színt és egyszeres vonalstílust ad a körvonalnak, mielőtt mentené a prezentációt.

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

## **Meglévő diagramjegyzetek szerkesztése**

Egy diagram tartalmazhat egyedi alakzatokat, például egy szöveges megjegyzést, amely a jelentés állapotát magyarázza. Ezeket az alakzatokat a [Diagram.getUserShapes](https://reference.aspose.com/slides/python-java/aspose.slides/chart/#getUserShapes) segítségével érheti el. A [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) által visszaadott gyűjtemény a diagramhoz tartozó alakzatokat tartalmazza.

Egy diagram fölé helyezett egyszerű szövegdoboz a diára tartozik, még ha úgy is tűnik, mintha a diagram része lenne. Az [Dia.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes) végigiterálása megtalálja a diagramot és a szokásos diaelemeket, de nem sorolja fel a diagramon belüli egyedi alakzatokat. A diagramcímek és adatcímkék külön diagramelemek, nem egyéni megjegyzések ebben a gyűjteményben.

Töltse le a [chart-annotations.pptx](chart-annotations.pptx) fájlt, és helyezze az alkalmazás munkakönyvtárába. Az első dia egy diagramot tartalmaz egy csoportosítatlan megjegyzéssel, amely a „Preliminary results” szöveget tartalmazza, egy diagramhoz tartozó vonallal és egy egyszerű diaszövegdobozzal, amely a „Slide overlay” feliratot mutatja. A példa megtalálja az első diagramot ezen a dián, és a megjegyzést „Final results” szövegre módosítja, amikor a jelentés közzétételre készül. Ellenőrzi, hogy a gyűjtemény nem üres, és csak egy [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) elemet szerkeszt, amelynek a [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame) metódusa nem `None`, és a várt szöveget tartalmazza.

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

A vonal és a diaszövegdoboz változatlan marad. Az alábbi képek a bemeneti és a mentett, újra megnyitott eredményt mutatják:

| Szerkesztés előtt | Szerkesztés után |
| --- | --- |
| ![Diagramjegyzet, amely a Preliminary results szöveget tartalmazza](chart-annotations-before.png) | ![Diagramjegyzet, amely a Final results szöveget tartalmazza](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
A példa csak a legfelső szintű, diagramhoz tartozó alakzatokat vizsgálja. Ha egy megjegyzés egy [GroupShape](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/) belsejében van, akkor vizsgálja meg az adott csoport [getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/groupshape/#getShapes) gyűjteményét is. Ismételje ezt rekurzívan a belső csoportoknál, ugyanazokat a szövegellenőrzéseket alkalmazva a gyermekalakzatokra. A csoport önmagában egy tároló; ne kezelje szövegdobozként.

{{% /alert %}}

## **GYIK**

**Beállíthatok félig átlátszó kitöltéseket oszlopokhoz/területekhez, miközben a szegély átlátszatlan marad?**

Igen. A kitöltés átlátszósága és a körvonal külön-külön konfigurálható. Ez hasznos a rács és az adatok olvashatóságának javításához sűrű vizualizációk esetén.

**Hogyan kezeljem az adatcímkéket, ha átfedik egymást?**

Csökkentse a betűméretet, tiltsa le a nem létfontosságú címke‑komponenseket (például a kategóriákat), módosítsa a címke pozícióját, szükség esetén csak a kiválasztott pontok címkéit jelenítse meg, vagy váltsa a formátumot „érték + jelmagyarázat” formára.

**Alkalmazhatok‑e gradient‑ vagy mintakövet kitöltéseket sorozatokra?**

Igen. A sorozatok támogatják a szilárd, gradient és mintakövet kitöltéseket. Gyakorlatban használjon gradienseket takarékosan, és kerülje az olyan kombinációkat, amelyek csökkentik a kontrasztot a rács és a szöveg között.