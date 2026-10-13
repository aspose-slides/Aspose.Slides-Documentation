---
title: Diagramtengelyek testreszabása Java‑val készített prezentációkban
linktitle: Diagramtengely
type: docs
url: /hu/java/chart-axis/
keywords:
- diagramtengely
- függőleges tengely
- vízszintes tengely
- tengely testreszabása
- tengely manipulálása
- tengely kezelése
- tengely tulajdonságok
- maximális érték
- minimális érték
- tengelyvonal
- dátumformátum
- tengelycím
- tengely pozíció
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Ismerje meg, hogyan használhatja az Aspose.Slides for Java‑t a diagramtengelyek testreszabásához PowerPoint‑prezentációkban jelentések és vizualizációk számára."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni a diagram tengelyeit az Aspose.Slides for Java segítségével. Tárgyalja a számított tengelyértékeket, a diagram sorok és oszlopok felcserélését, a tengely láthatóságát, a kategória címke és a jelölőskálák intervallumait, a dátumkategóriákat és formázásukat, a cím forgatását, a tengely pozicionálását, a megjelenítési egységeket és a logaritmikus skálázást.

## **Maximum értékek lekérése a függőleges tengelyen a diagramokban**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) és adjon hozzá egy terület diagramot az alapértelmezett adatokkal. Hívja meg a [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) a számított tengelyértékek olvasása előtt, hogy a diagram elrendezése naprakész legyen.

Olvassa a [getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) és a [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) a tengelyhatárokhoz, valamint a [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) és a [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) a jelölőintervallumokhoz. A [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) és a [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) időegység-skálákat adnak vissza, amelyek a dátum tengelyekre vonatkoznak. A példa ezeket az értékeket helyi változókba tárolja, majd menti a diagramot.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Area, 100, 100, 500, 350);
    chart.validateChartLayout();

    double maxValue = chart.getAxes().getVerticalAxis().getActualMaxValue();
    double minValue = chart.getAxes().getVerticalAxis().getActualMinValue();

    double majorUnit = chart.getAxes().getVerticalAxis().getActualMajorUnit();
    double minorUnit = chart.getAxes().getVerticalAxis().getActualMinorUnit();

    int majorUnitScale = chart.getAxes().getVerticalAxis().getActualMajorUnitScale();
    int minorUnitScale = chart.getAxes().getVerticalAxis().getActualMinorUnitScale();

    presentation.save("AxisValues_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Az adatok cseréje a tengelyek között**

Használja a [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) metódust a diagram adataiban a sorozatok és a kategóriák szerepének felcserélésére. Minden korábbi kategória sorozattá válik, és minden korábbi sorozat kategóriává. Ez megváltoztatja az adatok csoportosítását; nem cseréli fel a vízszintes és függőleges tengelyeket. A példa a [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) metódust használja az alapértelmezett adatok kötésére a `Sheet1!A1:D5` tartományra, beleértve a fejlécsort és a kategóriaoszlopot, a sorok és oszlopok felcserélése előtt. Egy négy sorozatot és három kategóriát tartalmazó diagramot ment.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 100, 100, 400, 300);
    chart.getChartData().setRange("Sheet1!A1:D5");
    chart.getChartData().switchRowColumn();

    presentation.save("SwitchChartRowColumns_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A függőleges tengely letiltása vonaldiagramokhoz**

Hívja meg a [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) metódust a függőleges tengellyel `false` értékkel a rejtéshez. A példa egy vonaldiagramot hoz létre alapértelmezett adatokkal, és elmenti a függőleges tengely rejtett állapotával.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getVerticalAxis().setVisible(false);

    presentation.save("HiddenVerticalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A vízszintes tengely letiltása vonaldiagramokhoz**

Hívja meg a [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) metódust a vízszintes tengellyel `false` értékkel a rejtéshez. A példa egy vonaldiagramot hoz létre alapértelmezett adatokkal, és elmenti a vízszintes tengely rejtett állapotával.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 100, 100, 400, 300);
    chart.getAxes().getHorizontalAxis().setVisible(false);

    presentation.save("HiddenHorizontalAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kategória tengely módosítása**

Használja a [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) metódust, hogy dátum vagy szöveg kategória tengelyt válasszon. Ez a példa a `ExistingChart.pptx` fájlt igényli, amelynek a diagramja az első dián az első forma, és a kategória cellák numerikus Excel dátumértékeket tartalmaznak. A vízszintes tengelyt dátum tengellyé változtatja. A [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) `false`, a [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) `1`, valamint a [setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) `TimeUnitType.Months` beállítása egy‑hónapos intervallumokra helyezi a fő jelölőket.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("ExistingChart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = (IChart) slide.getShapes().get_Item(0);
    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setAutomaticMajorUnit(false);
    chart.getAxes().getHorizontalAxis().setMajorUnit(1);
    chart.getAxes().getHorizontalAxis().setMajorUnitScale(TimeUnitType.Months);

    presentation.save("ChangeChartCategoryAxis_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kategória tengely címkeintervallumok szabályozása**

Amikor egy diagram sok kategóriát tartalmaz, csökkentheti a látható tengelycímkék számát anélkül, hogy a kategóriákat vagy adatpontokat eltávolítaná. Hívja meg a [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) `false` értékkel, majd adja meg a kívánt kategóriaintervallumot a [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-long-) metódusnak. Szöveges kategóriák esetén a számozás az első kategóriától indul:

| Intervallum | A példában megjelenített címkék |
| --- | --- |
| `1` | Kategória 1, Kategória 2, Kategória 3, … Kategória 24 |
| `2` | Kategória 1, Kategória 3, Kategória 5, … Kategória 23 |
| `3` | Kategória 1, Kategória 4, Kategória 7, … Kategória 22 |

A `3` intervallum minden harmadik címkét jelenít meg, a megjelenített címkék között két rejtett marad. Nem távolítja el a megfelelő oszlopokat. Az automatikus távolság a rendelkezésre álló hely alapján választ intervallumot; nem feltétlenül jelenik meg minden címke.

A jelölővonalaknak külön vezérlői vannak. Hívja meg a [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) `false` értékkel, és használja a [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-long-) metódust az intervallum beállításához. Például az `1` minden kategóriaintervallumban hagy egy jelölőt, míg a címkék csak minden harmadik kategórián jelennek meg. Használja a [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) látható stílusát, hogy lássa az eredményt. Bármely automatikus beállítót `true`‑ra állítva a diagram újra kiválasztja a megfelelő intervallumot.

A következő önálló példa 24 kategóriát és egy sorozatot hoz létre, majd három diát ment a `CategoryAxisIntervals.pptx` fájlba: automatikus távolság, manuális címkeintervallum független jelölőkkel, és visszaállított automatikus távolság. A két másolat az eredeti diagram adatokat megtartja. Bemeneti prezentációra nincs szükség. A vízszintes címke szöveg könnyen láthatóvá teszi a sűrűség különbségét.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 30, 40, 660, 320);

    chart.setLegend(false);
    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.ClusteredColumn);
    for (int i = 0; i < 24; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Category " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);
        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, 10 + i % 6 * 5);
        series.getDataPoints().addDataPointForBarSeries(valueCell);
    }

    IAxis axis = chart.getAxes().getHorizontalAxis();
    axis.setCategoryAxisType(CategoryAxisType.Text);
    axis.getTextFormat().getTextBlockFormat().setRotationAngle(0);
    axis.getTextFormat().getPortionFormat().setFontHeight(12);
    axis.setMajorTickMark(TickMarkType.Outside);
    axis.setAutomaticTickLabelSpacing(true);
    axis.setAutomaticTickMarksSpacing(true);

    // Dia 2: mutassa minden harmadik címkét, de legyen jelölő minden kategóriához.
    ISlide manualSlide = presentation.getSlides().addClone(slide);
    IChart manualChart = (IChart)manualSlide.getShapes().get_Item(0);
    IAxis manualAxis = manualChart.getAxes().getHorizontalAxis();
    manualAxis.setAutomaticTickLabelSpacing(false);
    manualAxis.setTickLabelSpacing(3);
    manualAxis.setAutomaticTickMarksSpacing(false);
    manualAxis.setTickMarksSpacing(1);

    // Dia 3: hagyja, hogy a diagram újra kiválassza mindkét intervallumot.
    ISlide restoredSlide = presentation.getSlides().addClone(manualSlide);
    IChart restoredChart = (IChart)restoredSlide.getShapes().get_Item(0);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickLabelSpacing(true);
    restoredChart.getAxes().getHorizontalAxis().setAutomaticTickMarksSpacing(true);

    presentation.save("CategoryAxisIntervals.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Automatikus távolság (1. dia):** Ebben a megjelenítésben minden második kategóriacímke látható, és két sorra törik. Az automatikus eredmény a diagram méretétől, betűtípusától és a renderelőtől függően változhat.

![Automatikus kategória címke távolság, minden 24 oszlop látható](category-axis-automatic.png)

**Manuális távolság (2. dia):** Minden harmadik címke jelenik meg egy sorban, míg a jelölővonalak minden kategóriaintervallumban megmaradnak. Az összes 24 oszlop, beleértve a címke nélküli oszlopokat is, látható ugyanazzal az értékkel. A 3. dia visszaállítja a fenti automatikus megjelenést.

![Manuális kategória címke intervallum hárommal, minden 24 oszlop látható](category-axis-manual.png)

### **A megfelelő tengely és intervallum kiválasztása**

Ezt a kategória‑szám intervallumot szöveges kategória tengelyhez használja, például oszlop-, vonal-, terület- vagy sávdiagram kategória tengelyéhez. Oszlopdiagram esetén ez a vízszintes tengely. Vízszintes sávdiagram esetén a kategória tengely függőleges, ezért alkalmazza ezeket a beállításokat a [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) által visszaadott tengelyre. A jelölővonalak távolsága egy sorozattengelyre is vonatkozik azon diagramokban, amelyeknél van ilyen.

Ne használja a kategóriacímke‑távolságot a numerikus skála beállítására értéktengelyen. Egy értéktengelyen a [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) a különbséget adja meg az értékek között: például a `10` főegység 0, 10, 20 stb. jelölőket eredményez, ha a tengely nullánál indul. A `3` kategóriacímke‑intervallum ezzel ellentétben a kategóriahelyeket számolja, függetlenül az adatértékektől. Szórt és buborék diagramok értéktengelyt használnak, nem szöveges kategória tengelyt. Dátum tengelyhez használjon időalapú főegységeket és skálákat, ahogy a [Kategória tengely módosítása](#change-a-category-axis) részben le van írva.

## **Dátumformátum beállítása a kategória tengely értékeihez**

A példa lecseréli az alapértelmezett diagram adatokat négy éves értékre. A dátumok OLE Automation sorozatszámokként tárolódnak az első munkalapon (index `0`), a 1899. december 30. óta eltelt napok számaként. Használja a [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) metódust `CategoryAxisType.Date`‑el, hívja a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) metódust `false`‑val, és adja át a `yyyy` értéket a [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) metódusnak, hogy a kategóriacímkék a cellaformázástól függetlenül négy számjegyű évként jelenjenek meg.

```java
import com.aspose.slides.*;
import java.time.LocalDate;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 450, 300);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    LocalDate baseDate = LocalDate.of(1899, 12, 30);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    for (int i = 0; i < 4; i++) {
        LocalDate date = LocalDate.of(2015 + i, 1, 1);
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, date.toEpochDay() - baseDate.toEpochDay());
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, i + 1);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    chart.getAxes().getHorizontalAxis().setCategoryAxisType(CategoryAxisType.Date);
    chart.getAxes().getHorizontalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getHorizontalAxis().setNumberFormat("yyyy");

    presentation.save("DateAxisFormat.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Forgatási szög beállítása a diagram tengely címéhez**

Hívja meg a [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) metódust `true`‑val a függőleges tengelyen, adja meg a címszöveget, és használja a [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) metódust a cím elforgatásához. A szög fokban van megadva; ez a példa egy oszlopdiagramot ment, amelynek az értéktengelycíme 90 fokkal el van forgatva.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setTitle(true);
    chart.getAxes().getVerticalAxis().getTitle().addTextFrameForOverriding("Value");
    chart.getAxes().getVerticalAxis().getTitle().getTextFormat().getTextBlockFormat().setRotationAngle(90);

    presentation.save("RotatedAxisTitle.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **A tengely helyzetének beállítása egy kategória vagy értéktengelyen**

Használja a [setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) metódust annak szabályozására, hogy az értéktengely a kategória tengelyet a kategóriák között vagy a kategóriajelölőknél metssze. Ez a beállítás kategória tengelyekre vonatkozik. A példa `true`‑ra állítja ezt a beállítást egy oszlopdiagram vízszintes kategória tengelyén, majd menti az eredményt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getHorizontalAxis().setAxisBetweenCategories(true);

    presentation.save("AxisBetweenCategories.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Megjelenítési egység beállítása egy diagram értéktengelyén**

Használja a [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) metódust az értéktengely feliratainak skálázásához az adatok megváltoztatása nélkül. A [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) `Millions` értékre állítva a 60 000 000 érték 60‑ként jelenik meg. A példa egy oszlopdiagramot hoz létre, és a függőleges tengelyére alkalmazza a milliós megjelenítési egységet.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 450, 300);
    chart.getAxes().getVerticalAxis().setDisplayUnit(DisplayUnitType.Millions);

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Logaritmikus értéktengely konfigurálása**

A logaritmikus értéktengely hasznos, ha a pozitív értékek több nagyságrendi lépcsőben terjednek. Például egy szolgáltatás 10, 100, 1 000, 10 000 és 100 000 kérésre is számíthat öt időszak alatt. Lineáris skálán a kisebb értékek közel legyenek a nullához. A logaritmikus skála a relatív növekedést könnyebben hasonlíthatóvá teszi: az azonos távolságok azonos arányt, nem azonos különbséget jelentenek.

Hívja meg a [setLogarithmic](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogarithmic-boolean-) metódust `true`‑val az értéktengelyen, és használja a [setLogBase](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setLogBase-double-) metódust az alap kiválasztásához. Ez megváltoztatja a meglévő értékek megjelenítését; nem módosítja az adatokat, és nem ad hozzá logaritmikus trendvonalat. A trendvonal a data‑khoz illesztett kapcsolatot jelenti, és önálló funkció.

### **Az értéktengely és az alap kiválasztása**

Vonal- vagy oszlopdiagram esetén az értéktengelyt a [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) adja vissza. Vízszintes sávdiagram esetén a [getHorizontalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getHorizontalAxis--) adja vissza. Szórt és buborék diagramok két értéktengellyel rendelkeznek, ezért válassza a vízszintes tengelyt az X‑értékekhez, a függőleges tengelyt az Y‑értékekhez, vagy mindkettőt. Ne alkalmazzon logaritmikus skálázást kategória tengelyen.

Az alapértelmezett logaritmikus alap a `10`. PPTX diagramok esetén a `2`‑től `1000`‑ig terjedő (beleértve) bármely egész szám használható; a tört alapok, például a `2.5` is támogatottak. A `10` alappal a 10, 100, 1 000, 10 000 stb. egyenlő távolságra esnek.

### **Lineáris és logaritmikus skálázás összehasonlítása**

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Line, 30, 40, 660, 200);

    chart.setLegend(false);

    chart.getChartData().getCategories().clear();
    chart.getChartData().getSeries().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartSeries series = chart.getChartData().getSeries().add(ChartType.Line);
    double[] values = { 10, 100, 1000, 10000, 100000 };

    for (int i = 0; i < values.length; i++) {
        IChartDataCell categoryCell = workbook.getCell(0, i + 1, 0, "Period " + (i + 1));
        chart.getChartData().getCategories().add(categoryCell);

        IChartDataCell valueCell = workbook.getCell(0, i + 1, 1, values[i]);
        series.getDataPoints().addDataPointForLineSeries(valueCell);
    }

    // Tartsa az első diát lineárisan, és csak a másolat értéktengely skáláját változtassa meg.
    ISlide logarithmicSlide = presentation.getSlides().addClone(slide);
    IChart logarithmicChart = (IChart)logarithmicSlide.getShapes().get_Item(0);
    IAxis valueAxis = logarithmicChart.getAxes().getVerticalAxis();
    valueAxis.setLogarithmic(true);
    valueAxis.setLogBase(10);

    presentation.save("LogarithmicAxis.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

**Lineáris skála (1. dia):** Az egyenlő függőleges távolságok egyenlő különbségeket jelentnek a kérés-számokban. A legnagyobb érték uralja a diagramot, így a kisebb értékek nehezen különböztethetők meg.

![Lineáris értéktengelyen megjelenített öt kérés‑szám PowerPoint diagramja](value-axis-linear.png)

**Logaritmikus skála (2. dia):** Az egyenlő függőleges távolságok egyenlő arányokat jelentnek. Minden időszak tízszer több kérést tartalmaz, mint az előző, így a pontok egy egyenesen emelkedő vonalat alkotnak a 10‑es alapú skálán. A tengelycímkék továbbra is az eredeti kérés‑számokat mutatják.

![Ugyanazon öt kérés‑szám logaritmikus értéktengelyen, 10‑es alapú PowerPoint diagram](value-axis-logarithmic.png)

### **Nulla és negatív értékek kezelése**

A logaritmikus skála csak szigorúan pozitív értékeket tud megjeleníteni. Ellenőrizze az adatokat a bekapcsolás előtt. Ha a nulla vagy negatív értékek jelentősek, használjon lineáris skálát vagy jelenítse meg őket külön. Ha az értékek kizárása indokolt az elemzéshez, magyarázza el az elhagyást. Ne helyettesítse őket csendben kis pozitív számokkal, mivel ez megváltoztatja az adatok jelentését. Bármely kézzel beállított minimum vagy maximum a logaritmikus tengelyen is pozitívnak kell maradnia.

## **FAQ**

**Hogyan állíthatom be azt az értéket, ahol egy tengely metszi a másikat (tengelykereszt)?**

Használja a [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) metódust a metszési viselkedés kiválasztásához. Számérték alapú metszéshez használja a [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-) metódust. Ezek a beállítások lehetővé teszik, hogy a tengelykeresztet egy megfelelő alapvonalra helyezze.

**Hogyan helyezhetem el a jelölőcímkéket a tengelyhez viszonyítva?**

Hívja meg a [setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) metódust a [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/) értékeivel: `Low`, `High`, `NextTo` vagy `None`. A jelölővonalak szabályozásához használja a [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) vagy a [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-) metódusokat; ezek különállóak a címke‑pozicionálástól.