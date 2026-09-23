---
title: Diagram adatcímkék kezelése Android prezentációkban
linktitle: Adatcímke
type: docs
url: /hu/androidjava/chart-data-label/
keywords:
- diagram
- adatcímke
- adat pontosság
- százalék
- címke távolság
- címke helye
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Tanulja meg, hogyan adjon hozzá és formázzon diagram adatcímkéket a PowerPoint prezentációkban az Aspose.Slides for Android Java használatával, hogy vonzóbb diák jöjjenek létre."
---
## **Bevezetés**

Az adatcímkék információt jelenítenek meg a diagram sorozatairól és az egyes adatpontokról, segítve az olvasókat az értékek azonosításában és a diagram megértésében. Ez a cikk bemutatja, hogyan formázhatja az értékeket, jeleníthet meg százalékokat, olvashatja a címke szövegét, állíthatja a kategória tengely címke távolságát, valamint a kördiagram címkéinek elhelyezését.

## **Adatpontok pontosságának beállítása a diagram adatcímkéknél**

Használja a [setNumberFormatOfValues](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#setNumberFormatOfValues-java.lang.String-) metódust a sorozatértékek formázásához. Ez a példa egy vonaldiagramot hoz létre alapértelmezett adatokkal, megjeleníti az adat táblázatát, és engedélyezi az értékcímkéket az első sorozatnál. A `#,##0.00` formátum ezres elválasztót és két tizedesjegyet jelenít meg anélkül, hogy megváltoztatná a mögöttes értékeket.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);
    chart.setDataTable(true);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    series.setNumberFormatOfValues("#,##0.00");
    series.getLabels().getDefaultDataLabelFormat().setShowValue(true);

    presentation.save("PrecisionOfDatalabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Százalékok megjelenítése címkeként**

Egy halmozott oszlopdiagram esetén számítsa ki minden értéket a kategória összegének százalékában, és rendelje a szöveget a [getTextFrameForOverriding](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) által visszaadott szövegkerethez. Ez a példa az alapértelmezett diagram adatokat használja, és a százalékokat két tizedesjegyel, 8 pontos betűmérettel jeleníti meg. A nulla összegű kategóriákat kihagyja, hogy elkerülje a nullával való osztást. Ha a diagram adatai megváltoznak, számolja újra az egyéni címke szöveget.

```java
import com.aspose.slides.*;
import java.util.Locale;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 400, 400);

    double[] categoryTotals = new double[chart.getChartData().getCategories().size()];
    for (int k = 0; k < chart.getChartData().getCategories().size(); k++) {
        for (int i = 0; i < chart.getChartData().getSeries().size(); i++) {
            IChartSeries series = chart.getChartData().getSeries().get_Item(i);
            Number pointValue = (Number) series.getDataPoints().get_Item(k).getValue().getData();
            categoryTotals[k] += pointValue.doubleValue();
        }
    }

    for (int x = 0; x < chart.getChartData().getSeries().size(); x++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(x);
        series.getLabels().getDefaultDataLabelFormat().setShowLegendKey(false);

        for (int j = 0; j < series.getDataPoints().size(); j++) {
            IDataLabel label = series.getDataPoints().get_Item(j).getLabel();
            if (categoryTotals[j] == 0) {
                continue;
            }

            Number pointValue = (Number) series.getDataPoints().get_Item(j).getValue().getData();
            double dataPointPercent = (pointValue.doubleValue() / categoryTotals[j]) * 100;

            IPortion portion = new Portion();
            portion.setText(String.format(Locale.US, "%.2f %%", dataPointPercent));
            portion.getPortionFormat().setFontHeight(8f);

            label.getTextFrameForOverriding().setText("");
            IParagraph paragraph = label.getTextFrameForOverriding().getParagraphs().get_Item(0);
            paragraph.getPortions().add(portion);

            label.getDataLabelFormat().setShowValue(true);
            label.getDataLabelFormat().setShowSeriesName(false);
            label.getDataLabelFormat().setShowPercentage(false);
            label.getDataLabelFormat().setShowLegendKey(false);
            label.getDataLabelFormat().setShowCategoryName(false);
            label.getDataLabelFormat().setShowBubbleSize(false);
        }
    }

    presentation.save("DisplayPercentageAsLabels_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Százalékjel beállítása a diagram adatcímkéknél**

Amikor az értékek törtként vannak tárolva, használja a [setNumberFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) metódust a százalékok megjelenítéséhez. Adja meg a `false` értéket a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) hívásában, hogy a címkeformátum független legyen a forráscelláktól.

Ez a példa egy 100 %‑os halmozott oszlopdiagramot hoz létre piros és kék sorozatokkal négy kategóriában. Minden értéppár összege 1. A `0.0%` címkeformátum a 0.30‑at 30.0 %-ként jeleníti meg, míg a függőleges tengely két tizedesjegyet használ. Mindkét sorozat fehér, 10 pontos címkeszöveget kap.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.PercentsStackedColumn, 20, 20, 500, 400);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00%");

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;
    for (int i = 0; i < 4; i++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    String[] seriesNames = { "Reds", "Blues" };
    int[] seriesColors = { Color.RED, Color.BLUE };
    double[][] values = { { 0.30, 0.50, 0.80, 0.65 }, { 0.70, 0.50, 0.20, 0.35 } };

    for (int i = 0; i < seriesNames.length; i++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, i + 1, seriesNames[i]);
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());
        for (int j = 0; j < 4; j++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, j + 1, i + 1, values[i][j]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        series.getFormat().getFill().setFillType(FillType.Solid);
        series.getFormat().getFill().getSolidFillColor().setColor(seriesColors[i]);

        IDataLabelFormat labelFormat = series.getLabels().getDefaultDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(false);
        labelFormat.setNumberFormat("0.0%");
        labelFormat.getTextFormat().getPortionFormat().setFontHeight(10);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().setFillType(FillType.Solid);
        labelFormat.getTextFormat().getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.WHITE);
    }

    presentation.save("SetDataLabelsPercentageSign_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Az adatcímkék tényleges szövegének kiolvasása**

Használja a [getActualLabelText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--) metódust a címke beállításai által előállított szöveg lekéréséhez. Ez akkor hasznos, ha címkéket kell kinyerni jelentésekhez, keresni a bemutató tartalmában, vagy ellenőrizni a generált diagramokat. Az alábbi példában az alapértelmezett [adatcímke formátum](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idatalabelformat/) minden kategórianév, sorozatnév és érték kombinációját tartalmazza. Egy pont értékét százalékként formázza, egy másik pedig egyedi szöveget használ a [getTextFrameForOverriding](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ioverridabletext/#getTextFrameForOverriding--) segítségével.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell firstCategoryCell = workbook.getCell(0, 1, 0, "Q1");
    chart.getChartData().getCategories().add(firstCategoryCell);
    IChartDataCell secondCategoryCell = workbook.getCell(0, 2, 0, "Q2");
    chart.getChartData().getCategories().add(secondCategoryCell);

    IChartDataCell northSeriesCell = workbook.getCell(0, 0, 1, "North");
    IChartSeries north = chart.getChartData().getSeries().add(northSeriesCell, chart.getType());
    IChartDataCell northFirstValueCell = workbook.getCell(0, 1, 1, 0.25);
    north.getDataPoints().addDataPointForBarSeries(northFirstValueCell);
    IChartDataCell northSecondValueCell = workbook.getCell(0, 2, 1, 0.75);
    north.getDataPoints().addDataPointForBarSeries(northSecondValueCell);

    IChartDataCell southSeriesCell = workbook.getCell(0, 0, 2, "South");
    IChartSeries south = chart.getChartData().getSeries().add(southSeriesCell, chart.getType());
    IChartDataCell southFirstValueCell = workbook.getCell(0, 1, 2, 0.40);
    south.getDataPoints().addDataPointForBarSeries(southFirstValueCell);
    IChartDataCell southSecondValueCell = workbook.getCell(0, 2, 2, 0.60);
    south.getDataPoints().addDataPointForBarSeries(southSecondValueCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat format = series.getLabels().getDefaultDataLabelFormat();
        format.setShowCategoryName(true);
        format.setShowSeriesName(true);
        format.setShowValue(true);
    }

    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormatLinkedToSource(false);
    north.getLabels().get_Item(1).getDataLabelFormat().setNumberFormat("0%");
    south.getLabels().get_Item(0).getTextFrameForOverriding().setText("Reviewed");

    for (IChartSeries series : chart.getChartData().getSeries()) {
        for (IChartDataPoint point : series.getDataPoints()) {
            IDataLabel label = point.getLabel();
            if (!label.isVisible()) {
                continue;
            }

            System.out.println("Value: " + point.getValue().getData() + "; label: " + label.getActualLabelText());
        }
    }
} finally {
    presentation.dispose();
}
```

A pontban tárolt szám továbbra is `0.75`, még akkor is, ha a címke `75%`-ként jelenik meg a kategória és sorozat nevekkel együtt. Az egyedi szöveg felülírja a generált címke szövegét. A [getActualLabelText](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idatalabel/#getActualLabelText--) mindkét esetben a kapott címke karakterláncot adja vissza. A [isVisible](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/idatalabel/#isVisible--) állapotot külön ellenőrizze, ahogy fent is látható, ha csak a látható címkéket szeretné kinyerni.

## **Címke távolságának beállítása a tengelytől**

Használja a [setLabelOffset](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/iaxis/#setLabelOffset-int-) metódust a kategória tengely címkéi és a tengely közötti távolság szabályozásához. Az érték a tengelycímkék legnagyobb betűméretének százaléka. Ez a példa egy csoportosított oszlopdiagramot hoz létre, és a vízszintes tengely címkeeltolását 500-ra állítja. Ez a beállítás a kategória tengely címkéire vonatkozik, nem pedig az egyedi adatpontokhoz csatolt címkékre.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 300);
    chart.getAxes().getHorizontalAxis().setLabelOffset(500);

    presentation.save("SetCategoryAxisLabelDistance_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Címke helyének módosítása**

Körtáblán módosítsa az adatcímkék pozícióját a távolság javítása és a vezetővonalak elhelyezése érdekében.

Ez a példa az első adatpont értékét jeleníti meg, a címkét a szelet kívülre helyezi, és a vízszintes illetve függőleges eltolásokat a [setX](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutable/#setX-float-) és a [setY](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ilayoutable/#setY-float-) függvényekkel állítja be. Ezek az eltolások a diagram szélességéhez és magasságához viszonyítva értendők.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 200, 200);
    IChartSeriesCollection series = chart.getChartData().getSeries();

    IDataLabel label = series.get_Item(0).getLabels().get_Item(0);
    label.getDataLabelFormat().setShowValue(true);
    label.getDataLabelFormat().setPosition(LegendDataLabelPosition.OutsideEnd);
    label.setX(0.71f);
    label.setY(0.04f);

    presentation.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Torta diagramm a módosított adatcímke pozícióval](pie-chart-adjusted-label.png)

## **GYIK**

**Hogyan előzhetem meg, hogy az adatcímkék átfedjék egymást sűrű diagramok esetén?**

Alkalmazzon automatikus címkeelhelyezést, vezetővonalakat és kisebb betűméretet; szükség esetén rejtse el bizonyos mezőket (például a kategóriát), vagy csak a szélső vagy kulcsfontosságú értékekhez jelenítsen meg címkéket.

**Hogyan tilthatom le a címkéket kizárólag a nulla, negatív vagy üres értékeknél?**

Szűrje le az adatpontokat a címkék engedélyezése előtt, és kapcsolja ki a megjelenítést a 0, negatív vagy hiányzó értékeknél egy meghatározott szabály szerint.

**Hogyan biztosíthatom a konzisztens címkestílust PDF/képek exportálása során?**

Állítsa be kifeexplicit módon a betűcsaládot és méretet, és ellenőrizze, hogy a betűtípus elérhető legyen a renderelési környezetben, hogy elkerülje a betűkicserélést.