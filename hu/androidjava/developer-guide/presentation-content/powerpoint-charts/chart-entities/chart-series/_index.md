---
title: Diagram adatsorozatok kezelése Android prezentációkban
linktitle: Adatsorozatok
type: docs
url: /hu/androidjava/chart-series/
keywords:
- diagram sorozat
- sorozat átfedés
- sorozat szín
- sorozat név
- adatpont
- munkafüzet cella
- sorozat hézag
- negatív érték
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan kezelhet diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, hézag szélességet és negatív értékeket Android prezentációkban."
---
## **Áttekintés**

Egy diagram a megjelenített adatokat egy diagram adatkönyvtárban tárolja. Egy [IChartSeries](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/) egy kapcsolódó értékcsoportot képvisel, és a sorozat minden [IChartDataPoint](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatapoint/) egy vagy több munkafüzetcellára hivatkozik. Az [IChartCategory](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartcategory/) objektumok a sorozatok által megosztott címkéket vagy csoportosítási értékeket biztosítják. Így a sorozat neve, a kategóriák és a pontértékek az [IChartDataCell](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/) objektumokhoz kapcsolódnak, nem csupán megjelenő szövegként tárolódnak.

Egy tipikus kategória diagram esetén az alapértelmezett munkafüzet a 0‑s sorban tárolja a sorozatneveket, a 0‑s oszlopban a kategória neveket, a maradék cellákban pedig a sorozatértékeket. A [IChartDataWorkbook.getCell](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/#getCell-int-int-int-)‑nek átadott munkalap-, sor- és oszlopszámok nullárral kezdődnek. Ez a felépítés hasznos, ha alapértelmezett adatokkal hoz létre diagramot, de ne feltételezze, hogy minden meglévő diagram így működik. Betöltött bemutató esetén vizsgálja meg a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt módosítaná a munkafüzet értékeit.

Diagram beállítások három különböző hatókörrel rendelkeznek:

- Sorozatszintű beállítások, például a [IChartSeries.getFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#getFormat--), amely egy sorozat összes pontjának alapértelmezett megjelenését biztosítja.
- Adatpont beállítások, például a [IChartDataPoint.getFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--), amely felülírja a sorozat megjelenését egy adott pont számára.
- Csoportbeállítások érvényesek a kompatibilis sorozatokra, amelyek egy [IChartSeriesGroup](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseriesgroup/) csoportba tartoznak. A csoportot a [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--) segítségével érheti el, ha például átfedés vagy hézag szélesség beállítására van szükség.

Ha nincs kifejezetten beállítva pont- vagy sorozatkitöltés, a diagram stílusa és témája határozza meg a automatikus megjelenést. Ha mind a sorozat, mind a pont formázása meg van adva, a pont formázása élvez elsőbbséget az adott pontnál.

![diagram-sorozat-powerpoint](chart-series-powerpoint.png)

## **A diagram sorozat átfedésének beállítása**

[AChartSeries.getOverlap](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#getOverlap--) megadja, hogy a sávok vagy oszlopok mennyire fednek át egy 2D diagramon, -100 és 100 százalék között. Ez a beállítás csak olvasható leképezése a szülő sorozatcsoportnak. A [IChartSeriesGroup.setOverlap](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseriesgroup/#setOverlap-byte-) használatával frissítheti a csoportban lévő minden kompatibilis sorozatot. Ez a lehetőség azoknál a diagramtípusoknál érvényes, amelyek csoportos sávokat vagy oszlopokat jelenítenek meg; egy kombinált diagramnél a nem kapcsolódó sorozatcsoportokat nem befolyásolja.

A következő példa beállítja az átfedést azon csoportban, amely az első sorozatot tartalmazza:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final byte overlapPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    // Az új diagram minta sorozatokat, kategóriákat és értékeket tartalmaz.
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setOverlap(overlapPercent);

    presentation.save("series_overlap.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A sorozat átfedése](series_overlap.png)

## **A sorozat kitöltőszínének módosítása**

A [IChartSeries.getFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#getFormat--) használatával állíthatja be az egész sorozat alapértelmezett kitöltését. Ha egy pont már rendelkezik kifejezett kitöltéssel, akkor annak a [IChartDataPoint.getFormat](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatapoint/#getFormat--) beállítása felülírja a sorozat kitöltését az adott pontnál.

A következő példa egy egységes kék kitöltést alkalmaz az első sorozatra:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("series_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A sorozat színe](series_color.png)

## **A sorozat nevének módosítása**

Egy sorozat neve a diagram adatkönyvtárban van tárolva, és általában a jelmagyarázatban jelenik meg. A klaszteres oszlopdiagram alapértelmezett munkafüzetében a B1 cella a 0‑s sorban, 1‑es oszlopban található, és az első sorozat nevét tartalmazza. A következő példa elnevezett konstansai egyértelművé teszik ezt a struktúrát:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int seriesNameRowIndex = 0;
final int firstSeriesColumnIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A [IChartSeries.getName](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#getName--) által már hivatkozott cellát is frissítheti. Ez a megközelítés elkerüli, hogy egy meglévő diagramnál egy adott sort és oszlopot feltételezzünk:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int firstNameCellIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataCell seriesNameCell = series.getName().getAsCells().get_Item(firstNameCellIndex);
    seriesNameCell.setValue("Revenue");

    presentation.save("series_name.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A sorozat neve](series_name.png)

## **Az automatikus sorozatkitöltőszín lekérdezése**

[AChartSeries.getAutomaticSeriesColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#getAutomaticSeriesColor--) visszaadja a sorozat indexéből és a diagram stílusából számított színt Android ARGB szín egészként. Ez a szín akkor kerül felhasználásra, amikor a sorozat kitöltése nincs kifejezetten meghatározva. A metódus meghívása csak leolvassa a kiszámított színt; nem rendel hozzá új kitöltést.

A következő példa kiírja minden alapértelmezett sorozat automatikus színértékét:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    int seriesCount = chart.getChartData().getSeries().size();
    for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++) {
        IChartSeries series = chart.getChartData().getSeries().get_Item(seriesIndex);
        int automaticColor = series.getAutomaticSeriesColor();
        System.out.println("Series " + seriesIndex + ": " + automaticColor);
    }
} finally {
    presentation.dispose();
}
```

A pontos egész értékek a diagram stílusától és témájától függenek.

## **Inverz kitöltőszín beállítása diagram sorozathoz**

Sáv-, oszlop- és buboréksorozatok esetén a [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) képes a negatív értékeket eltérő kitöltéssel megjeleníteni. Állítsa be a normál sorozatkitöltést szilárdra, engedélyezze az invertálást, és rendelje hozzá a negatív érték színét a [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) segítségével. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenő színük változik.

A következő példa lecseréli az alapértelmezett diagram adatokat egy sorozatra. A munkalap 0‑s sorában a sorozat neve, a 0‑s oszlopban a kategória nevek, az 1‑es oszlopban pedig az értékek találhatók:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int worksheetIndex = 0;
final int headerRowIndex = 0;
final int categoryColumnIndex = 0;
final int firstSeriesColumnIndex = 1;
final int firstDataRowIndex = 1;

String[] categoryNames = { "Category 1", "Category 2", "Category 3" };
int[] seriesValues = { -20, 50, -30 };

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);
    IChartData chartData = chart.getChartData();
    IChartDataWorkbook workbook = chartData.getChartDataWorkbook();

    chartData.getSeries().clear();
    chartData.getCategories().clear();

    IChartDataCell seriesNameCell = workbook.getCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, "Series 1");
    int chartType = chart.getType();
    IChartSeries series = chartData.getSeries().add(seriesNameCell, chartType);

    for (int categoryIndex = 0; categoryIndex < categoryNames.length; categoryIndex++) {
        int dataRowIndex = firstDataRowIndex + categoryIndex;
        String categoryName = categoryNames[categoryIndex];
        int seriesValue = seriesValues[categoryIndex];

        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, dataRowIndex, categoryColumnIndex, categoryName);
        chartData.getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, seriesValue);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    int automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.setInvertIfNegative(true);
    series.getInvertedSolidFillColor().setColor(Color.RED);

    presentation.save("inverted_solid_fill_color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![Az invertált szilárd kitöltőszín](inverted_solid_fill_color.png)

Az invertálást egy pontnál a [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) segítségével engedélyezheti. A következő példában az invertálás le van tiltva a sorozatra, és csak a kiválasztott pontnál van engedélyezve. A pontnak negatív értéket is adunk, hogy a hatás látható legyen:

```java
import com.aspose.slides.*;
import android.graphics.Color;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 2;
final int negativeValue = -30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    int automaticSeriesColor = series.getAutomaticSeriesColor();
    series.getFormat().getFill().setFillType(FillType.Solid);
    series.getFormat().getFill().getSolidFillColor().setColor(automaticSeriesColor);
    series.getInvertedSolidFillColor().setColor(Color.RED);
    series.setInvertIfNegative(false);

    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(negativeValue);
    dataPoint.setInvertIfNegative(true);

    presentation.save("data_point_invert_color_if_negative.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Egy adott adatpont értékének törlése**

Egy pont üresé tételéhez a többi pont eltávolítása nélkül állítsa be a mögöttes munkafüzetcellát `null`-ra. Oszlopdiagram esetén a megjelenített érték a [IChartDataPoint.getValue](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatapoint/#getValue--) által érhető el. Az adatpont ugyanazon a kategóriapozíción marad, de a diagram a beállított üresérték-kezelés szerint üresként kezeli az értékét.

A következő példa csak az első sorozat második pontját törli:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int targetDataPointIndex = 1;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    IChartDataPoint dataPoint = series.getDataPoints().get_Item(targetDataPointIndex);
    dataPoint.getValue().getAsCell().setValue(null);

    presentation.save("clear_data_point_value.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A szórt diagramok külön X és Y cellákat használnak, a buborékdiagramok pedig méretcellát is. Törölje csak azt a cellát, amely az eltávolítani kívánt értéket tartalmazza. Ne hívja meg a [IChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) metódust, ha a többi pontot meg szeretné tartani, mivel ez a metódus az összes adatpontot eltávolítja a gyűjteményből.

## **A sorozat hézag szélességének beállítása**

A hézag szélessége a szomszédos sáv- vagy oszlopcsoportok közti távolság, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez is a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. Hívja meg egyszer a [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) metódust a csoport számára. Nagyobb érték nagyobb távolságot eredményez a csoportok között; kisebb érték szorosabb elrendezést eredményez.

A következő példa módosítja a hézag szélességét, és csak a végső bemutatót menti:

```java
import com.aspose.slides.*;

final int firstSlideIndex = 0;
final int firstSeriesIndex = 0;
final int gapWidthPercent = 30;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(firstSlideIndex);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn, 20, 20, 500, 200);

    IChartSeries series = chart.getChartData().getSeries().get_Item(firstSeriesIndex);
    series.getParentSeriesGroup().setGapWidth(gapWidthPercent);

    presentation.save("gap_width_30.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Az eredmény:

![A hézag szélessége](gap_width.png)

## **GYIK**

**Mely diagramtípusok támogatják az adat sorozatokat?**

Minden, a [ChartType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/charttype/) felsorolás által képviselt diagramtípus használ diagram adatokat, de sorozataik nem mindegyiknek ugyanaz a értékstruktúrája vagy beállításai. Például a kategória diagramok kategóriákat és értékeket használnak, a szórt diagramok X és Y értékeket, a buborékdiagramok pedig buborékméreteket adnak hozzá. Használja a sorozattípussal megegyező adatpont létrehozási módszert. Az átfedés és hézag szélesség beállítások csak a kompatibilis sáv- vagy oszlopcsoportokra vonatkoznak.

**Mi az a diagram sorozatcsoport?**

Egy [IChartSeriesGroup](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek közös csoportszintű ábrázolási beállításokat osztanak meg. Egy kombinált diagram több csoportot is tartalmazhat, így egy sorozaton keresztül elérhető csoport módosítása nem feltétlenül változtatja meg a diagram minden sorozatát.

**Tartalmaz-e egy újonnan létrehozott diagram alapértelmezett adatokat?**

Igen. Alapértelmezés szerint a [IShapeCollection.addChart](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) mintasorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy törölheti a sorozat- és kategóriagyűjteményeket, mielőtt teljesen egyedi adatkészletet adna hozzá. Egy túlterhelés segítségével diagramot is létrehozhat alapértelmezett adatok nélkül.

**Hogyan kapcsolódnak a diagram objektumok a munkafüzet celláihoz?**

A sorozatnevek, kategória címkék és adatpont értékek egy [IChartDataWorkbook](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagram elemet. Egyéni adatokat építve tartsa a kategória sorokat és a sorozat-érték sorokat igazítva, hogy minden pont a kívánt kategória alatt legyen ábrázolva.

**Hogyan törölhetek egy pontot a teljes sorozat helyett?**

Állítsa a megfelelő értékcellát `null`-ra, hogy a pont kategória pozíciója üres pontként megmaradjon. Használja a [IChartDataPointCollection.clear](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatapointcollection/#clear--) metódust csak akkor, ha az adott sorozat összes pontját el kívánja távolítani. Ha a kategóriákat is eltávolítja, frissítse minden sorozatot, hogy az értékek illeszkedjenek a kategóriagyűjteményhez.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagram típusától és a [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) által beállított értéktől függ. A támogatott diagramok az üresek megjeleníthetők hézagokként, nulla értékekként, vagy a szomszédos pontok összekapcsolásával. Válassza ki azt a beállítást, amely megfelel a hiányzó adatok jelentésének az Ön bemutatójában.

**Hogyan formázódnak a negatív értékek?**

Támogatott sáv-, oszlop- és buboréksorozatok esetén hívja meg a [IChartSeries.setInvertIfNegative](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#setInvertIfNegative-boolean-) metódust, és állítsa be a [IChartSeries.getInvertedSolidFillColor](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseries/#getInvertedSolidFillColor--) által visszaadott színt. Egy adott pont viselkedését felülírhatja a [IChartDataPoint.setInvertIfNegative](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatapoint/#setInvertIfNegative-boolean-) metódussal. Ezek a metódusok a formázásra hatnak, nem a tárolt numerikus értékekre.

**Melyik formázás nyer, ha egy sorozat és egy pont is formázott?**

A kifejezett adatpont formázás elsőbbséget élvez az adott pontnál. A többi pont továbbra is a kifejezett sorozatformátumot vagy, ha a sorozatformátum nincs definiálva, az automatikus diagram stílust és témát használja. A csoportbeállítások, mint az átfedés és a hézag szélesség, az elrendezést szabályozzák, és nem pontszintű formázási felülbírálásokat jelentenek.

**Van korlát arra, hogy egy diagram hány sorozatot tartalmazhat?**

Az Aspose.Slides nem szab ki különálló, rögzített sorozatszám‑korlátot. Gyakorlatban a bemutató fájl korlátai, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a hasznos korlátot.

**Mit kell változtatni, ha az oszlopok túl közel vagy túl távol vannak egymástól?**

Hívja meg a [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) metódust a megfelelő szülő sorozatcsoporton. Növelje az értéket a csoportok közti térköz szélesítéséhez, vagy csökkentse, ha a csoportokat közelebb szeretné hozni.