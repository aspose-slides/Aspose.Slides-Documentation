---
title: Prezentáció Diagramok Formázása JavaScriptben
linktitle: Diagram Formázás
type: docs
weight: 60
url: /hu/nodejs-java/chart-formatting/
keywords:
- diagram formázása
- diagram formázás
- diagram entitás
- diagram tulajdonságok
- diagram beállítások
- diagram opciók
- betűtípus tulajdonságok
- lekerekített szegély
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Ismerje meg a diagramok formázását az Aspose.Slides for Node.js használatával JavaScriptben, és emelje fel PowerPoint prezentációját egyedi tengelyekkel, betűtípusokkal, számformátumokkal és lekerekített diagram szegélyekkel."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázhatók a diagramok PowerPoint‑prezentációkban az Aspose.Slides használatával. Megmutatja, hogyan testreszabhatók a diagram fő elemei, például a tengelyek, rácsvonalak, címek, jelmagyarázatok, a plot terület és a fal kitöltések, a diagram adatainak megjelenésének és olvashatóságának javítása érdekében.

A cikk bemutatja továbbá, hogyan állíthatók be a diagram szövegének betűtípus‑tulajdonságai, hogyan alkalmazhatók előre definiált számformátumok a diagram adataira, és hogyan engedélyezhetők a lekerekített sarkok a diagram területén. Ezek a példák együtt azt mutatják, hogyan szabályozható a diagramok vizuális stílusa és adatmegjelenítése egy prezentációban.

A növekvő és csökkenő intervallumok külön kitöltései és körvonala miatt lásd a [részvénydiagram példa](/slides/hu/nodejs-java/create-chart/#create-stock-charts).

## **Diagramelemek formázása**

Használja a [Chart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/) osztályt a diagram címek, tengelyek, rácsvonalak, jelmagyarázatok és a plot terület formázásához. Ez a példa egy jelölőkkel ellátott vonaldiagramot hoz létre alapértelmezett adatokkal, majd külön szöveg‑ és vonalstílusokat alkalmaz az érték‑ és kategória‑tengelyeken. A betűméreteket és vonalszélességeket pontosban adják meg; a kategória‑címkék 45 fokban vannak elforgatva.

Az értéktengely a [setNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/#setNumberFormat) metódust használja a forráscelláktól függetlenül. Skálája -2-től 15-ig terjed, fő intervallumai 2, kisebb intervallumai 0,5. A példa százalékos formázást kombinál a [setDisplayUnit](https://reference.aspose.com/slides/nodejs-java/aspose.slides/axis/#setDisplayUnit) ezrésekre beállításával, ezért ezeket a beállításokat a saját adatai jelentéséhez és nagyságához igazítsa. A jelmagyarázat a plot területén kívül marad, mert a [setOverlay](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/#setOverlay) `false` értékkel van meghívva. A háttérfal és a padló kitöltései a [getBackWall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getBackWall) és a [getFloor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getFloor) metódusokon keresztül vannak konfigurálva, de ezek a felületek csak 3D diagramoknál láthatóak.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.LineWithMarkers, 50, 50, 500, 400);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("");
    let chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    chartTitle.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(java.newByte(aspose.slides.LineDashStyle.DashDot));

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setDisplayUnit(aspose.slides.DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);

    chart.getAxes().getVerticalAxis().setMaxValue(15);
    chart.getAxes().getVerticalAxis().setMinValue(-2);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0);

    let valueAxisText = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    valueAxisText.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    valueAxisText.setFontHeight(16);
    valueAxisText.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    valueAxisText.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valueAxisText.getFillFormat().getSolidFillColor().setPresetColor(java.newByte(aspose.slides.PresetColor.DarkGreen));
    valueAxisText.setLatinFont(new aspose.slides.FontData("Times New Roman"));

    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    let valueAxisTitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valueAxisTitle.setText("Primary Axis");
    valueAxisTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    valueAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    valueAxisTitle.getPortionFormat().setFontHeight(20);
    valueAxisTitle.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    valueAxisTitle.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 0, 128, 0));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    let categoryAxisText = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    categoryAxisText.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    categoryAxisText.setFontHeight(16);
    categoryAxisText.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    categoryAxisText.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    categoryAxisText.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    categoryAxisText.setLatinFont(new aspose.slides.FontData("Arial"));

    chart.getAxes().getHorizontalAxis().setTitle(true);
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    let categoryAxisTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    categoryAxisTitle.setText("Sample Category");
    categoryAxisTitle.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    categoryAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    categoryAxisTitle.getPortionFormat().setFontHeight(20);
    categoryAxisTitle.getPortionFormat().setFontBold(java.newByte(aspose.slides.NullableBool.True));
    categoryAxisTitle.getPortionFormat().setFontItalic(java.newByte(aspose.slides.NullableBool.True));

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(aspose.slides.TickLabelPositionType.Low);
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    let legendText = chart.getLegend().getTextFormat().getPortionFormat();
    legendText.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    legendText.setFontHeight(16);
    legendText.setFontItalic(java.newByte(aspose.slides.NullableBool.True));
    legendText.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    legendText.getFillFormat().getSolidFillColor().setPresetColor(java.newByte(aspose.slides.PresetColor.DarkRed));

    chart.getLegend().setOverlay(false);

    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 255, 165, 0));

    chart.getFloor().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    chart.getPlotArea().getFormat().getFill().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(java.newByte(aspose.slides.PresetColor.LightCyan));

    presentation.save("FormattedChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Diagram betűtípus‑tulajdonságainak beállítása**

Állítsa be a diagram szövegének alapértelmezett betűméretét a [Chart.getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getTextFormat) segítségével. A példa egy csoportosított oszlopdiagramot hoz létre 20 pont betűmérettel, és az első sorozat értékcímkéit a [setShowValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/datalabelformat/#setShowValue) metódussal engedélyezi. A saját explicit betűtípus‑beállításokkal rendelkező szövegelemek felülbírálhatják a diagram alapértelmezését.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("FontPropertiesForChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Diagram jelmagyarázat szövegkeret formázásának újrahasználata**

A jelmagyarázat a dia címsorához való illesztéséhez állítsa be a címsor betűtípusát az első bekezdésen a [getDefaultPortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) segítségével. Hívja meg a [copyFrom](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttextformat/#copyFrom) metódust a jelmagyarázat által visszaadott [getTextFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legend/#getTextFormat) formátumon. Ez átmásolja a szövegkeret beállításait, az első bekezdés formázását, valamint az adott bekezdés alapértelmezett betűtípus‑tulajdonságait. Az egyes részekre vagy későbbi bekezdésekre közvetlenül alkalmazott formázás a forrásra korlátozódik.

A példa félkövér, 26 pont Calibri címsort használ sötétkékről, mint sablont. A jelmagyarázat stílusozása után meghívja a [copyTo](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttextformat/#copyTo) metódust, hogy ugyanazt a formázást egy külön feliratra alkalmazza.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const shapes = presentation.getSlides().get_Item(0).getShapes();

    const heading = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 20, 640, 40, false);
    const sourceTextFrame = heading.addTextFrame("Quarterly sales");
    const font = sourceTextFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    font.setLatinFont(new aspose.slides.FontData("Calibri"));
    font.setFontHeight(26);
    font.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    font.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    font.getFillFormat().getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", 32, 64, 96));

    const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, 40, 75, 640, 360);
    chart.setStyle(java.newByte(aspose.slides.StyleType.Style3));
    const workbook = chart.getChartData().getChartDataWorkbook();
    workbook.getCell(0, 0, 1).setValue("Retail");
    workbook.getCell(0, 0, 2).setValue("Online");
    workbook.getCell(0, 0, 3).setValue("Wholesale");
    for (let quarter = 1; quarter <= 4; quarter++) {
        workbook.getCell(0, quarter, 0).setValue("Q" + quarter);
    }

    chart.setLegend(true);
    chart.getLegend().setPosition(java.newByte(aspose.slides.LegendPositionType.Bottom));
    const legendFormat = chart.getLegend().getTextFormat();
    legendFormat.copyFrom(sourceTextFrame);

    const caption = shapes.addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 460, 640, 40, false);
    const captionTextFrame = caption.addTextFrame("Sales in millions of dollars");
    legendFormat.copyTo(captionTextFrame);

    presentation.save("legend-formatting.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A mentett prezentációban a jelmagyarázat és a felirat méretben, vastagságban és színben megegyezik a címsorral. A jelmagyarázat továbbra is a sorozat nevek jelenik meg, a felirat saját szövegét megtartja. Ha a felirat egy részének már van explicit betűmérete, az a másolt bekezdés alapértelmezése fölött lesz előnyben részesítve.

| Másolás előtt | Másolás után |
| --- | --- |
| ![Negyedéves értékesítési diagram szabályos fekete jelmagyarázat-címkékkel és fekete felirattal](legend-formatting-before.png) | ![Ugyanaz a diagram nagyobb, félkövér sötétkék jelmagyarázat-címkékkel és egyező felirattal](legend-formatting.png) |

## **Számformátum beállítása**

Használja a [ChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartdatacell/#setPresetNumberFormat) metódust beépített számformátum alkalmazásához a diagram munkafüzet celláira. Ez a példa egy csoportosított oszlopdiagramot hoz létre alapértelmezett, cella‑alapú adatokkal, és az 10‑es formátum indexet (`0.00%`) minden sorozat értékcella számára alkalmazza. Ez megváltoztatja, hogyan jelennek meg az értékek a munkafüzetben a tényleges számok módosítása nélkül; például a 0,25 25,00%-ként jelenik meg. A tengely- és adatcímke‑formátumok külön-külön konfigurálhatók.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 500, 400);
    let series = chart.getChartData().getSeries();

    for (let i = 0; i < series.size(); i++) {
        let chartSeries = series.get_Item(i);
        for (let j = 0; j < chartSeries.getDataPoints().size(); j++) {
            let dataPoint = chartSeries.getDataPoints().get_Item(j);
            dataPoint.getValue().getAsCell().setPresetNumberFormat(java.newByte(10)); // 0.00%
        }
    }

    presentation.save("PresetNumberFormat_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az alábbi táblázat sorolja a beépített számformátum indexeket a megfelelő Excel formátumokkal az angol (Egyesült Államok) nyelvi beállításhoz. A pontos formátumkarakterláncok és megjelenítésük alkalmazásonként és nyelvi beállításonként változhat, különösen a pénznem és a dátumok esetében. Néhány Excel formátum eltér az OOXML szabvány alapértelmezett beállításaitól, ahogy azt a [Microsoft számformátum-implementációs megjegyzéseiben](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) leírják.

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

## **Lekerekített szegélyek beállítása a diagram területén**

Hívja meg a [Chart.setRoundedCorners](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#setRoundedCorners) metódust `true` értékkel a diagram területének sarkainak lekerekítéséhez. A példa egy csoportosított oszlopdiagramot hoz létre, és a [getLineFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/#getLineFormat) metódussal szilárd szürke színt és egyszerű vonalstílust ad az outline‑nak, mielőtt elmenti a prezentációt.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));
    chart.getLineFormat().setStyle(java.newByte(aspose.slides.LineStyle.Single));
    chart.setRoundedCorners(true);

    presentation.save("out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Meglévő diagram annotációk szerkesztése**

Egy diagram tartalmazhat egyedi alakzatokat, például egy szöveges annotációt, amely a jelentés állapotát magyarázza. Ezekhez az alakzatokhoz a [Chart.getUserShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/#getUserShapes) segítségével férhet hozzá. A [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) által visszaadott gyűjtemény a diagramhoz tartozó alakzatokat tartalmazza.

Egy egyszerű szövegdoboz, amely egy diagram felett helyezkedik el, a diára tartozik, még ha úgy néz ki is, mintha a diagram része lenne. A [Slide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes) bejárásával megtalálja a diagramot és a szokásos diaelemeket, de nem sorolja fel a diagramon belüli egyedi alakzatokat. A diagramcímek és adatcímkék külön diagramelemek, nem egyedi annotációk ebben a gyűjteményben.

Töltse le a [chart-annotations.pptx](chart-annotations.pptx) fájlt, és helyezze az alkalmazás munkakönyvtárába. Az első dián egy diagram található egy csoportosítatlan annotációval, amely a „Preliminary results” szöveget tartalmazza, egy diagramhoz tartozó vonallal és egy egyszerű diaszövegdobozzal, amely a „Slide overlay” feliratot mutatja. A példa megtalálja az első diagramot azon a dián, és a jelentés közzétételére kész állapotában a annotációt „Final results” szövegre változtatja. Ellenőrzi, hogy a gyűjtemény üres‑e, és csak akkor szerkeszt egy [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) elemet, ha a [getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/#getTextFrame) nem null értékű szövegkeretet ad vissza, és a szöveg a várt.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

let presentation = new aspose.slides.Presentation("chart-annotations.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);

    let chart = null;
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
            chart = shape;
            break;
        }
    }

    if (chart == null || chart.getUserShapes().getShapes().size() == 0) {
        console.log("No chart or chart-owned shapes found.");
    } else {
        let updated = false;
        for (let i = 0; i < chart.getUserShapes().getShapes().size(); i++) {
            let shape = chart.getUserShapes().getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                let annotation = shape;
                if (annotation.getTextFrame() != null && annotation.getTextFrame().getText() === "Preliminary results") {
                    annotation.getTextFrame().setText("Final results");
                    updated = true;
                    break;
                }
            }
        }

        if (updated) {
            presentation.save("chart-annotations-updated.pptx", aspose.slides.SaveFormat.Pptx);
        } else {
            console.log("No matching text annotation found.");
        }
    }
} finally {
    presentation.dispose();
}
```

A vonal és a diaszövegdoboz változatlan marad. A következő képek mutatják a bemenetet és a mentett, újra megnyitott eredményt:

| Szerkesztés előtt | Szerkesztés után |
| --- | --- |
| ![Diagram annotáció, amely a Preliminary results feliratot tartalmazza](chart-annotations-before.png) | ![Diagram annotáció, amely a Final results feliratot tartalmazza](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
A példa csak a felső‑szintű, diagramhoz tartozó alakzatokat vizsgálja. Ha egy annotáció egy [GroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/) belsejében van, akkor ellenőrizze ennek a csoportnak a [getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/groupshape/#getShapes) gyűjteményét is. Ismételje meg ezt rekurzívan a beágyazott csoportok esetén, ugyanazokat a szövegelem‑ellenőrzéseket alkalmazva a gyermek alakzatokra. Maga a csoport egy tároló; ne kezelje szövegdobozként.
{{% /alert %}}

## **GYIK**

**Beállíthatok félig átlátszó kitöltéseket oszlopoknak/területeknek, miközben a keret átlátszatlan marad?**

Igen. A kitöltés átlátszósága és a körvonal külön-külön konfigurálható. Ez hasznos a rács és az adatok olvashatóságának javításához sűrű vizualizációkban.

**Hogyan kezelhetem az adatcímkéket, ha átfednek?**

Csökkentse a betűméretet, tiltsa le a nem lényeges címke‑komponenseket (például a kategóriákat), állítsa be a címke pozícióját, szükség esetén csak a kiválasztott pontokhoz mutassa a címkéket, vagy változtassa a formátumot "érték + jelmagyarázat".

**Alkalmazhatok színátmenetes vagy mintás kitöltéseket sorozatokra?**

Igen. A sorozatok támogatják a szilárd, színátmenetes és mintás kitöltéseket. Gyakorlatban takarékosan használjon színátmeneteket, és kerülje az olyan kombinációkat, amelyek a rács és a szöveg kontrasztját csökkentik.