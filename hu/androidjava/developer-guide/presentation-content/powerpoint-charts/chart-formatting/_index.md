---
title: Formázza a prezentációs diagramokat Androidon
linktitle: Diagram formázása
type: docs
weight: 60
url: /hu/androidjava/chart-formatting/
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
- Android
- Java
- Aspose.Slides
description: "Ismerje meg a diagram formázását az Aspose.Slides Android verziójában Java nyelven, és emelje fel PowerPoint prezentációját egyedi tengelyekkel, betűtípusokkal, számformátumokkal és lekerekített diagram szegélyekkel."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan formázhatók a diagramok PowerPoint‑prezentációkban az Aspose.Slides használatával. Megmutatja, hogyan testreszabhatók a diagram fő elemei, például a tengelyek, rácsvonalak, címek, jelmagyarázatok, a diagramterület és a fal kitöltései, a diagram adatainak megjelenésének és olvashatóságának javítása érdekében.

Emellett bemutatja, hogyan állíthatók be a betűtípus‑tulajdonságok a diagram szövegeihez, hogyan alkalmazhatók előre definiált numerikus formátumok a diagram adataihoz, valamint hogyan engedélyezhetők a lekerekített sarkok a diagram területén. Ezek a példák egyaránt a diagram vizuális stílusát és az adatok megjelenítését szabályozzák egy prezentációban.

## **Diagramelemek formázása**

Használja a [IChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/) felületet diagramcímek, tengelyek, rácsvonalak, jelmagyarázatok és diagramterület formázásához. Ez a példa egy jelölőkkel ellátott vonaldiagramot hoz létre alapértelmezett adatokkal, majd külön szöveg‑ és vonalstílusokat alkalmaz az érték‑ és kategóriatengelyeken. A betűméretek és vonalszélességek pontban vannak megadva; a kategória‑címkék 45 fokra vannak elforgatva.

Az értéktengely a [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) metódust használja a forráscelláktól függetlenül. Skálája -2‑től 15‑ig terjed, fő intervalluma 2, másodlagos intervalluma 0,5. A példa a százalékos formázást a [setDisplayUnit](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setDisplayUnit-int-) „ezer” beállításával kombinálja, ezért a beállításokat a saját adatainak jelentéséhez és nagyságrendjéhez igazítsa. A jelmagyarázat a diagramterület kívül marad, mivel a [setOverlay](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegend/#setOverlay-boolean-) `false` értékkel van meghívva. A hátfal és az alap kitöltései a [getBackWall](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getBackWall--) és a [getFloor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getFloor--) segítségével állíthatók be, ezek a felületek azonban csak 3D diagramokban láthatók.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    chart.getAxes().getHorizontalAxis().getMajorGridLinesFormat().getLine().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 128, 0));
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
    chart.getBackWall().getFormat().getFill().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    chart.getFloor().getFormat().getFill().setFillType(FillType.Solid);
    chart.getFloor().getFormat().getFill().getSolidFillColor().setColor(Color.RED);

    chart.getPlotArea().getFormat().getFill().setFillType(FillType.Solid);
    chart.getPlotArea().getFormat().getFill().getSolidFillColor().setPresetColor(PresetColor.LightCyan);

    presentation.save("FormattedChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Betűtípus‑tulajdonságok beállítása diagramhoz**

Állítsa be a diagram szövegeinek alapértelmezett betűméretét a [Chart.getTextFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#getTextFormat--) metódus segítségével. A példa egy csoportosított oszlopdiagramot hoz létre 20 pontos betűmérettel, és az első sorozat értékcímkéit a [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) `true` értékkel engedélyezi. A saját, kifejezetten megadott betűtípus beállításokkal rendelkező szövegelemek felülírhatják a diagram alapértelmezését.

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

## **Numerikus formátum beállítása**

Használja az [IChartDataCell.setPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setPresetNumberFormat-byte-) metódust beépített számformátum alkalmazásához a diagram munkafüzetcelláira. Ez a példa egy csoportosított oszlopdiagramot hoz létre alapértelmezett, cella‑alapú adatokkal, és a 10‑es formátumindexet (`0.00%`) alkalmazza minden sorozat értékcellájára. Ez a megjelenést módosítja a munkafüzetben anélkül, hogy a tényleges számok változnának; például a 0,25 érték 25,00 %-ként jelenik meg. A tengely‑ és adatcímke‑formátumok külön konfigurálhatók.

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

Az alábbi táblázat a beépített számformátum‑indexeket sorolja fel a angol (Egyesült Államok) területi beállításokhoz tartozó jellemző Excel‑formátumokkal. A pontos formátumkarakterláncok és megjelenítésük alkalmazásonként és területenként eltérhet, különösen a pénznemek és dátumok esetében. Néhány Excel‑formátum eltér az OOXML szabvány alapértelmezéseitől, ahogy azt a [Microsoft számformátum‑implementációs megjegyzéseiben](https://learn.microsoft.com/en-us/openspecs/office_standards/ms-oi29500/17d11129-219b-4e2c-88db-45844d21e528) leírják.

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

## **Lekerekített szegélyek beállítása a diagramterületen**

Hívja meg az [IChart.setRoundedCorners](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setRoundedCorners-boolean-) metódust `true` értékkel a diagramterület sarkainak lekerekítéséhez. A példa egy csoportosított oszlopdiagramot hoz létre, és a [getLineFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#getLineFormat--) segítségével szilárd szürke színt és egyvonalas stílust ad a körvonalnak, mielőtt elmentené a prezentációt.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **Meglévő diagramjegyzetek szerkesztése**

Egy diagram tartalmazhat egyedi alakzatokat, például olyan szöveges megjegyzést, amely a jelentés állapotát magyarázza. Ezeket az alakzatokat a [IChart.getUserShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getUserShapes--) vagy a [Chart.getUserShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chart/#getUserShapes--) API‑kön keresztül érheti el. A [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) által visszaadott gyűjtemény a diagramhoz tartozó alakzatokat tartalmazza.

Egy diagram fölé helyezett egyszerű szövegdoboz a diára tartozik, még ha úgy néz is ki, mintha a diagram része lenne. A [Slide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) iterálásával megtalálja a diagramot és a diagramon kívüli diaképeket, de a diagramon belüli egyedi alakzatokat nem sorolja fel. A diagramcímek és adatcímkék külön diagramelemek, nem egyedi megjegyzések ebben a gyűjteményben.

Töltse le a [chart-annotations.pptx](chart-annotations.pptx) fájlt, és helyezze el az alkalmazás munkakönyvtárában. Az első dián egy diagram látható, amely egy csoportosítatlan megjegyzést („Preliminary results”), egy diagramhoz tartozó vonalat és egy egyszerű diaszövegdobozt („Slide overlay”) tartalmaz. A példa megtalálja az első diagramot azon a dián, és módosítja a megjegyzést „Final results” szövegre, amikor a jelentés közzétételre készül. Ellenőrzi, hogy a gyűjtemény nem üres, és csak akkor szerkeszt egy [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) elemet, ha annak nem üres a [getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/#getTextFrame--) által visszaadott szövegkerete, és a várt szöveget tartalmazza.

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

A vonal és a diaszövegdoboz változatlan marad. Az alábbi képek a bemeneti és a mentett, újra megnyitott eredményt mutatják:

| Szerkesztés előtt | Szerkesztés után |
| --- | --- |
| ![Diagramjegyzet – Preliminary results](chart-annotations-before.png) | ![Diagramjegyzet – Final results](chart-annotations-after.png) |

{{% alert color="info" title="Megjegyzés" %}}

A példa csak a legfelső szintű, diagramhoz tartozó alakzatokat vizsgálja. Ha egy megjegyzés egy [IGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/) belsejében van, vizsgálja meg annak [getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/igroupshape/#getShapes--) gyűjteményét is. Ezt rekurzívan ismételje a beágyazott csoportokra, ugyanazokat a szövegellenőrzéseket alkalmazva a gyermekalakzatokra. A csoport önmagában egy tároló; ne kezelje szövegdobozként.

{{% /alert %}}

## **GYIK**

**Beállíthatok-e félig átlátszó kitöltést az oszlopok/területek számára, miközben a szegély opak marad?**

Igen. A kitöltés átlátszósága és a körvonal külön-külön konfigurálható. Ez különösen hasznos a rács és az adatok olvashatóságának javításához sűrű vizualizációkban.

**Hogyan kezeljem a címkéket, ha átfedik egymást?**

Csökkentse a betűméretet, tiltsa le a nem lényeges címkeösszetevőket (például a kategóriákat), állítsa át a címkehelyzetet, szükség esetén csak a kiválasztott pontok címkéit jelenítse meg, vagy váltsa “érték + jelmagyarázat” formátumra.

**Alkalmazhatok‑e fokozat vagy minta kitöltést sorozatokra?**

Igen. A sorozatok támogatják a szilárd, fokozatos és minta kitöltéseket. Gyakorlatban használjon fokozatot mértékkel, és kerülje az olyan kombinációkat, amelyek csökkentik a kontrasztot a rács és a szöveg között.