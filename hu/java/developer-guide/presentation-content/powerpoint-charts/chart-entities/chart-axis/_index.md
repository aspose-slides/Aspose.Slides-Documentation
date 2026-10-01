---
title: Diagram tengelyek testreszabása prezentációkban Java használatával
linktitle: Diagramtengely
type: docs
url: /hu/java/chart-axis/
keywords:
- diagram tengely
- függőleges tengely
- vízszintes tengely
- tengely testreszabása
- tengely manipulálása
- tengely kezelése
- tengely tulajdonságai
- maximális érték
- minimális érték
- tengelyvonal
- dátumformátum
- tengely cím
- tengely pozíció
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Fedezze fel, hogyan használhatja az Aspose.Slides for Java-t a diagram tengelyek testreszabásához PowerPoint prezentációkban jelentések és vizualizációk számára."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni a diagram tengelyeit az Aspose.Slides for Java-val. Tárgyalja a kiszámított tengelyértékeket, a diagram sorok és oszlopok átváltását, a tengely láthatóságát, a kategória‑címke és a jelölőjel intervallumokat, a dátumkategóriákat és formázást, a cím forgatását, a tengely elhelyezését, valamint a megjelenítési egységeket.

## **A maximális értékek lekérése a függőleges tengelyen a diagramokon**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) és adjon hozzá egy alapértelmezett adatú területdiagramot. Hívja meg a [validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/chart/#validateChartLayout--) metódust, mielőtt a kiszámított tengelyértékeket olvasná, hogy a diagram elrendezése naprakész legyen.

Olvassa a [getActualMaxValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMaxValue--) és a [getActualMinValue](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinValue--) a tengelyhatárokhoz, valamint a [getActualMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnit--) és a [getActualMinorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnit--) a jelölőjel intervallumokhoz. A [getActualMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMajorUnitScale--) és a [getActualMinorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#getActualMinorUnitScale--) időegység skálákat biztosítanak, amelyek a dátumtengelyeknél relevánsak. A példa ezeket az értékeket helyi változókba tárolja, és elmenti a diagramot.

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

## **Adatok cseréje a tengelyek között**

Használja a [switchRowColumn](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#switchRowColumn--) metódust a sorozatok és kategóriák szerepének felcserélésére a diagram adataiban. Minden korábbi kategória sorozattá válik, és minden korábbi sorozat kategóriává. Ez megváltoztatja az adatok csoportosítását; nem cseréli fel a vízszintes és függőleges tengelyeket. A példa a [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#setRange-java.lang.String-) segítségével kötja az alapértelmezett adatokat a `Sheet1!A1:D5`-höz, beleértve a fejlécsort és a kategóriaoszlopot, mielőtt sorokat és oszlopokat cserélne. Négy sorozattal és három kategóriával ment egy diagramot.

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

## **Függőleges tengely letiltása vonaldiagramoknál**

Hívja a [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) metódust `false` értékkel a függőleges tengelyen a rejtéséhez. A példa alapértelmezett adatokkal hoz létre egy vonaldiagramot, és a függőleges tengely letiltásával menti el.

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

## **Vízszintes tengely letiltása vonaldiagramoknál**

Hívja a [setVisible](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setVisible-boolean-) metódust `false` értékkel a vízszintes tengelyen a rejtéséhez. A példa alapértelmezett adatokkal hoz létre egy vonaldiagramot, és a vízszintes tengely letiltásával menti el.

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

Használja a [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) metódust, hogy dátum vagy szöveges kategória tengelyt válasszon. Ez a példa a `ExistingChart.pptx` fájlt igényli, amelyben a diagram az első slide első alakzata, és a kategória cellák numerikus Excel dátumértékeket tartalmaznak. A vízszintes tengelyt dátum tengelyre változtatja. A [setAutomaticMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAutomaticMajorUnit-boolean-) `false`, a [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnit-double-) `1`, és a [setMajorUnitScale](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorUnitScale-int-) `TimeUnitType.Months` beállítása egyhónapos intervallumot eredményez a fő jelölőjeleknek.

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

Ha egy diagram sok kategóriát tartalmaz, csökkentse a látható tengelycímkék számát a kategóriák vagy adatelemek eltávolítása nélkül. Hívja a [setAutomaticTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickLabelSpacing-boolean-) `false` értékkel, majd adja meg a kívánt kategóriaintervallumot a [setTickLabelSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickLabelSpacing-int-) metódussal. Szöveges kategóriák esetén a normál sorrendben a számozás az első kategóriától kezdődik:

| Intervallum | A példában megjelenített címkék |
| --- | --- |
| `1` | Kategória 1, Kategória 2, Kategória 3, ... Kategória 24 |
| `2` | Kategória 1, Kategória 3, Kategória 5, ... Kategória 23 |
| `3` | Kategória 1, Kategória 4, Kategória 7, ... Kategória 22 |

Egy `3` intervallum minden harmadik címkét jelenít meg, a megjelenített címkék között két címke marad rejtve. Nem távolítja el a megfelelő oszlopokat. Az automatikus távolság a rendelkezésre álló hely alapján választ intervallumot; nem feltétlenül jeleníti meg az összes címkét.

A jelölőjeleknek külön vezérlőik vannak. Hívja a [setAutomaticTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setAutomaticTickMarksSpacing-boolean-) `false` értékkel, és használja a [setTickMarksSpacing](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setTickMarksSpacing-int-) metódust az intervallum beállításához. Például az `1` minden kategóriaintervallumra helyez egy jelölőjelet, míg a címkék csak minden harmadik kategóriánál jelennek meg. Használja a [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorTickMark-int-) metódust látható stílussal, hogy lássa az eredményt. Bármelyik automatikus beállítót `true`‑ra állítva a diagram újra kiválasztja az intervallumot.

A következő önálló példa 24 kategóriát és egy sorozatot hoz létre, majd három diát ment a `CategoryAxisIntervals.pptx` fájlba: automatikus távolság, manuális címkeintervallum független jelölőjelekkel, és a visszaállított automatikus távolság. A két másolat megtartja az eredeti diagram adatait. Bemeneti prezentáció nem szükséges. A vízszintes címke szöveg megkönnyíti a sűrűség észlelését.

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

    // Dia 2: mutassa minden harmadik címkét, de minden kategóriához tartson meg egy jelölőjelet.
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

**Automatikus távolság (1. dia):** Ebben a megjelenítésben minden második kategória címke látható, és két sorba törik. Az automatikus eredmény a diagram méretétől, betűtípustól és a renderertől függően változhat.

![Automatikus kategória címke távolság, az összes 24 oszlop látható](category-axis-automatic.png)

**Kézi távolság (2. dia):** Minden harmadik címke jelenik meg egy sorban, míg a jelölőjelek minden kategóriaintervallumnál maradnak. Az összes 24 oszlop, beleértve a címkével nem rendelkezőket is, látható ugyanazokkal az értékekkel. A 3. dia visszaállítja a fent látható automatikus megjelenést.

![Kézi kategória címke intervallum hárommal, az összes 24 oszlop látható](category-axis-manual.png)

### **A megfelelő tengely és intervallum kiválasztása**

Használja ezt a kategória‑szám intervallumot szöveges kategória tengelyhez, például oszlop-, vonal-, terület- vagy sávdiagram kategória tengelyéhez. Oszlopdiagram esetén ez a vízszintes tengely. Vízszintes sávdiagram esetén a kategória tengely függőleges, ezért alkalmazza ezeket a beállításokat a [getVerticalAxis](https://reference.aspose.com/slides/java/com.aspose.slides/iaxesmanager/#getVerticalAxis--) metódus által visszaadott tengelyre. A jelölőjel távolság egy sorozat tengelyre is vonatkozik olyan diagramoknál, amelyek rendelkeznek ilyen tengellyel.

Ne használja a kategória címke távolságot az értéktengely numerikus skálájának beállítására. Egy értéktengelyen a [setMajorUnit](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setMajorUnit-double-) a értékek közti különbséget adja meg: például a `10` fő egység 0, 10, 20 stb. jelölőket hoz létre, ha a tengely nulláról indul. A `3` kategória címke intervallum ezzel szemben a kategóriahelyeket számolja, függetlenül azok adatértékétől. Szórt és buborék diagramok értéktengelyt használnak, nem szöveges kategória tengelyt. Dátumtengely esetén használjon időalapú fő egységeket és skálákat a [Change a Category Axis](#change-a-category-axis) szakaszban leírtak szerint.

## **Dátumformátum beállítása a kategória tengely értékeihez**

A példa az alapértelmezett diagram adatokat négy éves értékkel helyettesíti. A dátumok OLE Automation sorozatszámokként vannak tárolva az első munkalapon (index `0`), a 1899. december 30. óta eltelt napok számaként. Használja a [setCategoryAxisType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCategoryAxisType-int-) metódust `CategoryAxisType.Date` értékkel, hívja a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormatLinkedToSource-boolean-) metódust `false`‑ra, és adja meg a `yyyy` formátumot a [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setNumberFormat-java.lang.String-) metódussal, hogy a kategória címkék a négy számjegyű évet jelenítsék meg a cellaformázástól függetlenül.

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

Hívja a [setTitle](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTitle-boolean-) metódust `true`‑ra a függőleges tengelyen, adja meg a cím szövegét, és használja a [setRotationAngle](https://reference.aspose.com/slides/java/com.aspose.slides/icharttextblockformat/#setRotationAngle-float-) metódust a cím forgatásához. A szög fokokban van megadva; ez a példa egy oszlopdiagramot ment el, amelynek értéktengely‑címe 90 fokkal van elfordítva.

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

## **Tengelypozíció beállítása kategória vagy érték tengelyen**

Használja a [setAxisBetweenCategories](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setAxisBetweenCategories-boolean-) metódust, hogy szabályozza, az értéktengely a kategória tengely között vagy a kategória jelölőpontoknál metssze át. Ez a beállítás a kategória tengelyekre vonatkozik. A példa a vízszintes kategória tengelyen `true`‑ra állítja, és elmenti az eredményt.

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

## **Megjelenítési egység beállítása a diagram érték tengelyen**

Használja a [setDisplayUnit](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setDisplayUnit-int-) metódust, hogy a címkék méretét az értéktengelyen anélkül módosítsa, hogy az adatokat megváltoztatná. A [DisplayUnitType](https://reference.aspose.com/slides/java/com.aspose.slides/displayunittype/) `Millions` értékre állítása esetén a 60 000 000 érték 60‑ként jelenik meg. A példa egy oszlopdiagramot hoz létre, és a függőleges tengelyen alkalmazza a milliók megjelenítési egységet.

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

## **GYIK**

**Hogyan állíthatom be azt az értéket, ahol egy tengely áthalad a másikon (tengelykeresztelő)?**

Használja a [setCrossType](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossType-int-) metódust a keresztelési viselkedés kiválasztásához. Numerikus keresztelési érték megadásához használja a [setCrossAt](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setCrossAt-float-) metódust. Ezek a beállítások lehetővé teszik, hogy a tengely metszéspontját egy megfelelő alapvonalra helyezze.

**Hogyan helyezhetem el a jelölőcímkéket a tengelyhez képest?**

Hívja a [setTickLabelPosition](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setTickLabelPosition-int-) metódust a [TickLabelPositionType](https://reference.aspose.com/slides/java/com.aspose.slides/ticklabelpositiontype/) valamelyik értékével: `Low`, `High`, `NextTo` vagy `None`. A jelölőjelek saját beállításához használja a [setMajorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMajorTickMark-int-) vagy a [setMinorTickMark](https://reference.aspose.com/slides/java/com.aspose.slides/axis/#setMinorTickMark-int-) metódust; ezek különállóak a címkék pozicionálásától.