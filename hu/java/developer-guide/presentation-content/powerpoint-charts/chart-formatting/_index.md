---
title: Prezentációs diagramok formázása Java-ban
linktitle: Diagram formázás
type: docs
weight: 60
url: /hu/java/chart-formatting/
keywords:
- diagram formázás
- diagram formázás
- diagram elem
- diagram tulajdonságok
- diagram beállítások
- diagram opciók
- betűtulajdonságok
- lekerekített szegély
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg a diagramok formázását az Aspose.Slides for Java segítségével, és emelje a PowerPoint prezentációját egyedi tengelyekkel, betűtípusokkal, számformátumokkal és lekerekített diagram szegélyekkel."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázhatók diagramok PowerPoint-prezentációkban az Aspose.Slides használatával. Megmutatja, hogyan lehet testre szabni a diagramok kulcsfontosságú elemeit, például a tengelyeket, rácsvonalakat, címeket, jelmagyarázatokat, ábrázolási területet és fal kitöltéseket, a diagram adatok megjelenésének és olvashatóságának javítása érdekében.  
Az is bemutatja, hogyan állítható be a diagram szövegének betűtulajdonsága, hogyan alkalmazhatók előre definiált számformátumok a diagram adataira, és hogyan engedélyezhetők lekerekített sarkok a diagram területén. Ezek a példák együtt azt mutatják, hogyan lehet irányítani a diagramok vizuális stílusát és adatmegjelenítését egy prezentációban.  
Az emelkedő és csökkenő intervallumokhoz külön kitöltések és körvonalak esetén lásd a [részvénydiagram-példa](/slides/hu/java/create-chart/#create-stock-charts).

## **Diagramelemek formázása**

Használja az [IChart](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/) felületet a diagramcímek, tengelyek, rácsvonalak, jelmagyarázatok és ábrázolási terület formázásához. Ez a példa egy jelölőkkel ellátott vonaldiagramot hoz létre alapértelmezett adatokkal, majd külön szöveg- és vonalstílusokat alkalmaz az érték- és kategóriatengelyekre. A betűméretek és vonalszélességek pontban vannak megadva; a kategória címkék 45 fokban vannak elforgatva.  

Az értéktengely a [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) metódust használja a forráscelláktól függetlenül. Skálája -2 és 15 között terjed, fő intervallumok 2, kisebb intervallumok 0,5. A példa a százalékos formázást az [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setDisplayUnit-int-) ezerre állítással kombinálja, ezért igazítsa ezeket a beállításokat az adatok jelentéséhez és nagyságához. A jelmagyarázat a ábrázolási terület kívül marad, mert a [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/ilegend/#setOverlay-boolean-) `false` értékkel van meghívva. A háttérfal és a padló kitöltései a [getBackWall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--) és a [getFloor](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--) segítségével vannak beállítva, de ezek a felületek csak 3D diagramokban láthatók.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.LineWithMarkers, 50, 50, 500, 400);

    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("");
    IPortion chartTitle = chart.getChartTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    chartTitle.setText("Sample Chart");
    chartTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    chartTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chartTitle.getPortionFormat().setFontHeight(20);
    chartTitle.getPortionFormat().setFontBold(NullableBool.True);
    chartTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setWidth(5);
    chart.getAxes().getVerticalAxis().getMajorGridLinesFormat().getLine().setDashStyle(LineDashStyle.DashDot);

    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.RED);
    chart.getAxes().getVerticalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Thousands);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.0%");

    chart.getAxes().getVerticalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinorUnit(false);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);

    chart.getAxes().getVerticalAxis().setMaxValue(15f);
    chart.getAxes().getVerticalAxis().setMinValue(-2f);
    chart.getAxes().getVerticalAxis().setMinorUnit(0.5f);
    chart.getAxes().getVerticalAxis().setMajorUnit(2.0f);

    IChartPortionFormat valueAxisText = chart.getAxes().getVerticalAxis().getTextFormat().getPortionFormat();
    valueAxisText.setFontBold(NullableBool.True);
    valueAxisText.setFontHeight(16);
    valueAxisText.setFontItalic(NullableBool.True);
    valueAxisText.getFillFormat().setFillType(FillType.Solid);
    valueAxisText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkGreen);
    valueAxisText.setLatinFont(new FontData("Times New Roman"));

    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("");
    IPortion valueAxisTitle = chart.getAxes().getVerticalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    valueAxisTitle.setText("Primary Axis");
    valueAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    valueAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    valueAxisTitle.getPortionFormat().setFontHeight(20);
    valueAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    valueAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(new Color(0, 128, 0));
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().setWidth(5);

    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().setFillType(FillType.Solid);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
    chart.getAxes().getHorizontalAxis().getMinorGridLinesFormat().getLine().setWidth(3);

    IChartPortionFormat categoryAxisText = chart.getAxes().getHorizontalAxis().getTextFormat().getPortionFormat();
    categoryAxisText.setFontBold(NullableBool.True);
    categoryAxisText.setFontHeight(16);
    categoryAxisText.setFontItalic(NullableBool.True);
    categoryAxisText.getFillFormat().setFillType(FillType.Solid);
    categoryAxisText.getFillFormat().getSolidFillColor().setColor(Color.BLUE);
    categoryAxisText.setLatinFont(new FontData("Arial"));

    chart.getAxes().getHorizontalAxis().setTitle(true);
    chart.getAxes().getHorizontalAxis().getTitle().addTextFrameForOverriding("");

    IPortion categoryAxisTitle = chart.getAxes().getHorizontalAxis().getTitle().getTextFrameForOverriding().getParagraphs().get_Item(0).getPortions().get_Item(0);
    categoryAxisTitle.setText("Sample Category");
    categoryAxisTitle.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    categoryAxisTitle.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    categoryAxisTitle.getPortionFormat().setFontHeight(20);
    categoryAxisTitle.getPortionFormat().setFontBold(NullableBool.True);
    categoryAxisTitle.getPortionFormat().setFontItalic(NullableBool.True);

    chart.getAxes().getHorizontalAxis().setTickLabelPosition(TickLabelPositionType.Low);
    chart.getAxes().getHorizontalAxis().setTickLabelRotationAngle(45);

    IChartPortionFormat legendText = chart.getLegend().getTextFormat().getPortionFormat();
    legendText.setFontBold(NullableBool.True);
    legendText.setFontHeight(16);
    legendText.setFontItalic(NullableBool.True);
    legendText.getFillFormat().setFillType(FillType.Solid);
    legendText.getFillFormat().getSolidFillColor().setPresetColor(PresetColor.DarkRed);

    chart.getLegend().setOverlay(false);

    chart.getBackWall().setThickness(1);
    chart.getBackWall().getFormat().getFill().setFillType(FillType.Solid);
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(new Color(255, 165, 0));

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan);

    presentation.save("FormattedChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Diagram betűtulajdonságainak beállítása**

Hozza létre az alapértelmezett betűméretet a diagram szövegéhez a [Chart.getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getTextFormat--) segítségével. A példa egy csoportosított oszlopdiagramot hoz létre 20 pontos betűvel, és az első sorozathoz a [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) segítségével engedélyezi az értékcímkéket. A saját explicit betűbeállításokkal rendelkező szövegelemek felülírhatják a diagram alapértelmezését.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 500, 400);
    chart.getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getChartData().getSeries().get_Item(0).getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("FontPropertiesForChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Szövegkeret formázásának újrahasználata a diagram jelmagyarázatához**

A jelmagyarázatot a dia címsorához igazítani a címsor betűtípusát a [getDefaultPortionFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraphformat/#getDefaultPortionFormat--) metódusával állíthatja be az első bekezdésen. Hívja meg a [copyFrom](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextformat/#copyFrom-com.aspose.slides.ITextFrame-) metódust a jelmagyarázat által visszaadott [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iformattedtextcontainer/#getTextFormat--) formátumon. Ez átmásolja a szövegkeret beállításait, az első bekezdés formázását és annak alapértelmezett betűtulajdonságait. Az egyedi részekre vagy későbbi bekezdésekre közvetlenül alkalmazott formázás a forrásra korlátozódik.  

A példa vastag, 26 pontos Calibri címsort használ navy színben sablonként. A jelmagyarázat stílusozása után meghívja a [copyTo](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextformat/#copyTo-com.aspose.slides.ITextFrame-) metódust, hogy ugyanazt a formázást alkalmazza egy külön feliratra.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    
    IAutoShape heading = shapes.addAutoShape(ShapeType.Rectangle, 40, 20, 640, 40, false);
    ITextFrame sourceTextFrame = heading.addTextFrame("Quarterly sales");
    IPortionFormat font = sourceTextFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    font.setLatinFont(new FontData("Calibri"));
    font.setFontHeight(26);
    font.setFontBold(NullableBool.True);
    font.getFillFormat().setFillType(FillType.Solid);
    font.getFillFormat().getSolidFillColor().setColor(new Color(32, 64, 96));

    IChart chart = shapes.addChart(ChartType.ClusteredColumn, 40, 75, 640, 360);
    chart.setStyle(StyleType.Style3);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.getCell(0, 0, 1).setValue("Retail");
    workbook.getCell(0, 0, 2).setValue("Online");
    workbook.getCell(0, 0, 3).setValue("Wholesale");
    for (int quarter = 1; quarter <= 4; quarter++) {
        workbook.getCell(0, quarter, 0).setValue("Q" + quarter);
    }

    chart.setLegend(true);
    chart.getLegend().setPosition(LegendPositionType.Bottom);
    IChartTextFormat legendFormat = chart.getLegend().getTextFormat();
    legendFormat.copyFrom(sourceTextFrame);

    IAutoShape caption = shapes.addAutoShape(ShapeType.Rectangle, 40, 460, 640, 40, false);
    ITextFrame captionTextFrame = caption.addTextFrame("Sales in millions of dollars");
    legendFormat.copyTo(captionTextFrame);

    presentation.save("legend-formatting.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A mentett prezentációban a jelmagyarázat és a felirat méretben, súlyban és színben megegyezik a címsorral. A jelmagyarázat továbbra is a sorozatneveket jeleníti meg, a felirat pedig megtartja saját szövegét. Ha a felirat egy részének már explicit betűmérete van, az a méret felülírja a másolt bekezdés alapértelmezését.

| Másolás előtt | Másolás után |
| --- | --- |
| ![Negyedéves eladási diagram szabályos fekete jelmagyarázat címkékkel és fekete felirattal](legend-formatting-before.png) | ![Ugyanez a diagram nagyobb, félkövér navy színű jelmagyarázat címkékkel és megfelelő felirattal](legend-formatting.png) |

## **Számformátum beállítása**

Használja az [IChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setPresetNumberFormat-byte-) metódust, hogy beépített számformátumot alkalmazzon a diagram munkafüzet celláira. Ez a példa egy csoportosított oszlopdiagramot hoz létre alapértelmezett, cella-alapú adatokkal, és minden sorozat értékcellájára a 10-es formátumindexet (`0.00%`) alkalmazza. Ez megváltoztatja, hogyan jelennek meg az értékek a munkafüzetben anélkül, hogy a mögöttes számok változnának; például a 0,25 25,00%-ként jelenik meg. A tengely és az adatcímke formátumok külön konfigurálhatók.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 400);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    for (IChartSeries chartSeries : series)
    {
        for (IChartDataPoint dataPoint : chartSeries.getDataPoints())
        {
            dataPoint.getValue().getAsCell().setPresetNumberFormat((byte) 10); // 0.00%
        }
    }

    presentation.save("PresetNumberFormat_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az alábbi táblázat felsorolja a beépített számformátum-indexeket, az Egyesült Államok angol nyelvű helyes beállításait bemutató Excel formátumokkal. A pontos formátumkarakterláncok és megjelenítésük alkalmazásonként és helyi beállításonként eltérhet, különösen pénznemek és dátumok esetén. Néhány Excel formátum eltér az OOXML szabvány alapértelmezettjeitől, ahogy az [Microsoft számformátum-implementációs megjegyzések](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) le van írva.

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

## **A diagram terület lekerekített szegélyeinek beállítása**

Hívja meg az [IChart.setRoundedCorners](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setRoundedCorners-boolean-) metódust `true` értékkel a diagram terület sarkainak lekerekítéséhez. A példa egy csoportosított oszlopdiagramot hoz létre, és a [getLineFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#getLineFormat--) segítségével szilárd szürke színt és egyvonalas stílust ad a körvonalnak, mielőtt a prezentációt mentené.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 100, 600, 400);
    chart.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    chart.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);
    chart.getLineFormat().setStyle(LineStyle.Single);
    chart.setRoundedCorners(true);

    presentation.save("out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Meglévő diagram annotációk szerkesztése**

A diagram tartalmazhat egyedi alakzatokat, például egy szöveges annotációt, amely a jelentés állapotát magyarázza. Ezekhez az alakzatokhoz a [IChart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getUserShapes--) segítségével férhet hozzá, amely a [Chart.getUserShapes](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#getUserShapes--) alatt is szerepel a Diagram API Referenciában. A [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) által visszaadott gyűjtemény a diagram által birtokolt alakzatokat tartalmazza.

Egy egyszerű szövegdoboz, amely egy diagram fölött helyezkedik el, a diára tartozik, még ha úgy is néz ki, mintha a diagram része lenne. A [Slide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) bejárása megtalálja a diagramot és a szokásos dián lévő alakzatokat, de nem sorolja fel a diagramon belüli egyedi alakzatokat. A diagramcímek és adatcímkék külön diagramelemek, nem egyedi annotációk ebben a gyűjteményben.

Töltse le a [chart-annotations.pptx](chart-annotations.pptx) fájlt, és helyezze el az alkalmazás munkakönyvtárában. Az első dián egy diagram van egy csoportosítatlan annotációval, amely a "Preliminary results" (Előzetes eredmények) szöveget tartalmazza, egy diagramtulajdonú vonallal és egy egyszerű diára helyezett szövegdobozzal, amely a "Slide overlay" (Dia átfedés) feliratot mutatja. A példa megtalálja az első diagramot azon a dián, és a jelentés közzétételére készüléskor a annotációt "Final results" (Végső eredmények) szövegre módosítja. Ellenőrzi, hogy a gyűjtemény üres-e, és csak egy [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) elemet szerkeszt, amelynek nem null értékű szövegkerete van, a [getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/#getTextFrame--) által visszaadva, valamint a várt szöveggel.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart-annotations.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = null;
    for (IShape shape : slide.getShapes()) {
        if (shape instanceof IChart) {
            chart = (IChart) shape;
            break;
        }
    }

    if (chart == null || chart.getUserShapes().getShapes().size() == 0) {
        System.out.println("No chart or chart-owned shapes found.");
        return;
    }

    boolean updated = false;
    for (IShape shape : chart.getUserShapes().getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape annotation = (IAutoShape) shape;
            if (annotation.getTextFrame() != null && "Preliminary results".equals(annotation.getTextFrame().getText())) {
                annotation.getTextFrame().setText("Final results");
                updated = true;
                break;
            }
        }
    }

    if (updated) {
        presentation.save("chart-annotations-updated.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("No matching text annotation found.");
    }
} finally {
    presentation.dispose();
}
```

A vonal és a diára helyezett szövegdoboz változatlan marad. A következő képek mutatják a bemenetet és a mentett, újra megnyitott eredményt:

| Szerkesztés előtt | Szerkesztés után |
| --- | --- |
| ![Diagram annotáció, amely az Előzetes eredmények szöveget mutat](chart-annotations-before.png) | ![Diagram annotáció, amely a Végső eredmények szöveget mutat](chart-annotations-after.png) |

{{% alert color="info" title="Note" %}}
A példa csak a felső szintű, diagramtulajdonú alakzatokat vizsgálja. Ha egy annotáció egy [IGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/) belsejében van, akkor a csoport [getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/igroupshape/#getShapes--) gyűjteményét is ellenőrizze. Ismételje meg ezt rekurzívan a beágyazott csoportoknál, alkalmazva ugyanazokat a szöveges ellenőrzéseket a gyermek alakzatokra. A csoport maga egy konténer; ne kezelje szövegdobozként.
{{% /alert %}}

## **GYIK**

**Beállíthatok félig átlátszó kitöltéseket az oszlopoknak/területeknek, miközben a szegély átlátszatlan marad?**

Igen. A kitöltés átlátszósága és a körvonal külön kerül beállításra. Ez hasznos a rács és az adatok olvashatóságának javításához sűrű ábrázolások esetén.

**Hogyan kezeljem az adatcímkéket, ha átfedik egymást?**

Csökkentse a betűméretet, tiltsa le a nem lényeges címkeelemeket (például a kategóriákat), állítsa be a címke pozícióját, szükség esetén csak a kiválasztott pontokhoz jelenítse meg a címkéket, vagy váltson a "érték + jelmagyarázat" formátumra.

**Alkalmazhatok színátmenet vagy minta kitöltéseket a sorozatokra?**

Igen. A sorozatok támogatják a szilárd, színátmenetes és mintás kitöltéseket. Gyakorlatban használjon színátmeneteket csak mérsékelten, és kerülje az olyan kombinációkat, amelyek csökkentik a kontrasztot a rács és a szöveg között.