---
title: Diagram munkafüzeteinek kezelése prezentációkban Androidon
linktitle: Diagram munkafüzet
type: docs
weight: 70
url: /hu/androidjava/chart-workbook/
keywords:
- diagram munkafüzet
- diagram adatok
- munkafüzet cella
- adatcímke
- munkalap
- adatforrás
- külső munkafüzet
- külső adat
- diagram gyorsítótár
- munkafüzet helyreállítás
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Android via Java megoldást: könnyedén kezelje a diagram munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse prezentációja adatait."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan dolgozhat a diagram munkafüzetekkel az Aspose.Slides-ban. Bemutatja, hogyan lehet a diagram adatokat olvasni és írni munkafüzet adatfolyamok segítségével, hogyan használhatja a munkafüzet cellákat diagram adatcímkeként, hogyan férhet hozzá a munkalap gyűjteményekhez, és hogyan adhatja meg az adatforrás típusát a diagram értékekhez.

Emellett bemutatja a külső munkafüzetek diagram adatforrásként való használatát. A példák azt mutatják be, hogyan hozhat létre és rendelhet hozzá egy külső munkafüzetet, hogyan kérheti le egy diagramhoz kapcsolódó külső munkafüzet útvonalát, és hogyan szerkesztheti a diagram adatokat, ha a munkafüzet elérhető.

A hiányzó adatokat képviselő munkafüzet cellákhoz lásd a [Üres cellák megjelenítésének vezérlése](/slides/hu/androidjava/chart-series/) című cikket, ahol megtudhatja a különbséget egy üres cella és a nulla között, valamint egy vonaldiagram összehasonlítást a rendelkezésre álló megjelenítési módokról.

## **Rejtett sorok és oszlopok adatainak belefoglalása**

Használja a [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) metódust annak szabályozására, hogy a diagram rejtett munkalap sorokból és oszlopokból is ábrázoljon-e adatot. Állítsa `true`‑ra, ha csak a látható cellákat szeretné ábrázolni, vagy `false`‑ra, ha a látható és a rejtett cellákat egyaránt szeretné belefoglalni. Ez a beállítás a diagram ábrázolását szabályozza; nem rejt el vagy jelenít meg munkalap sorokat vagy oszlopokat.

A [sample presentation](hidden-source-data.pptx) egy oszlopdiagramot tartalmaz, mint az első alakzat az első dián. A beágyazott munkalap, `Sheet1`, a `A1:C4` tartományt tartalmazza. A 3. sor és a C oszlop rejtett, de celláik továbbra is tartalmaznak értékeket.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | január | 10 | 30 |
| 3 (rejtett sor) | február | 40 | 60 |
| 4 | március | 20 | 50 |

A forráscellák eléréséhez használja a [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) metódust, és olvassa a [IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) értékét a rejtett állapotuk ellenőrzéséhez. Ez a metódus a rejtett állapotot jelzi anélkül, hogy módosítaná azt. Ebben a példában a B2 látható, a B3 a rejtett sorhoz tartozik, a C2 a rejtett oszlophoz; a példa ennek megfelelően `false`, `true`, és `true` értékeket ír ki.

Ehhez a példához frissítse a diagram adatokat a rajzolási beállítás módosítása után: tartsa meg a beágyazott munkafüzetet a [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) metódussal, majd töltse be újra a [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) segítségével. Ha az összes cellát belefoglalja, használja továbbá a [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) metódust a teljes tartomány visszaállításához, beleértve a rejtett februári kategóriát is. Csak a jelző módosítása nem elegendő a gyorsítótárban lévő diagram adat és kategória címkék frissítéséhez.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hidden-source-data.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
        System.out.println("B2 hidden: " + workbook.getCell(0, "B2").isHidden());
        System.out.println("B3 hidden: " + workbook.getCell(0, "B3").isHidden());
        System.out.println("C2 hidden: " + workbook.getCell(0, "C2").isHidden());

        byte[] workbookData = chart.getChartData().readWorkbookStream();
        for (boolean visibleOnly : new boolean[] { true, false }) {
            chart.setPlotVisibleCellsOnly(visibleOnly);

            // Frissítse a diagram adatokat a beágyazott munkafüzetből.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Állítsa vissza a teljes forrástartományt, beleértve a rejtett kategóriákat.
                chart.getChartData().setRange("Sheet1!$A$1:$C$4");
            }

            presentation.save("hidden_cells_" + visibleOnly + ".pptx", SaveFormat.Pptx);
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

A példa két változatban menti a prezentációt: egyben csak a látható kiskereskedelmi értékek (10 és 20) szerepelnek, a másikban mind a hat érték. Az alábbi képek a két ábrázolási módot mutatják. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| Csak látható cellák (`true`) | Minden cella (`false`) |
| --- | --- |
| ![Csak látható cellák: kiskereskedelmi értékek 10 és 20 januárra és márciusra.](hidden_cells_True.png) | ![Minden cella: kiskereskedelmi és nagykereskedelmi értékek januárra, februárra és márciusra.](hidden_cells_False.png) |

Egy rejtett cella, amely értéket tartalmaz, különbözik egy üres cellától. A [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) metódus szabályozza, hogyan jelennek meg a hiányzó értékek; nem befolyásolja a rejtett forrásadatok belefoglalását vagy kihagyását. Lásd a [Üres cellák megjelenítésének vezérlése](/slides/hu/androidjava/chart-series/#control-the-display-of-empty-cells) példát.

## **Diagram adat tartományának lekérdezése**

Mielőtt meglévő prezentációban módosítaná a munkafüzet adatait, ellenőrizze a forrás tartományokat, hogy azonosítsa, mely munkalapcellákat használja az egyes diagramok. A [IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--) metódus visszaadja a jelenlegi adat tartományt munkalap‑kvalifikált képletként, például `Sheet1!$A$1:$D$5`. Itt a `Sheet1` a munkalap neve, a `!` elválasztja a cellatartományt, a `$A$1:$D$5` pedig az A1‑től D5‑ig terjedő cellákat jelöli. A dollárjelek abszolút sor‑ és oszlopreferenciákat jelentenek.

A metódus a tartományt a diagram vagy a munkafüzet megváltoztatása nélkül olvassa. Ha a diagram nem használ munkafüzetet adatforrásként, `InvalidOperationException`‑t dob. További információért tekintse meg a [ChartData API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/) oldalát.

Ez a példa megnyit egy prezentációt, és minden dián közvetlenül ellenőrzi az alakzatokat, hogy diagramokat találjon. Kiírja minden diagram nevét és forrás tartományát. Ha egy diagram nem használ munkafüzetet, üzenetet ír ki, majd a következő diagramra lép.

```java
import com.aspose.slides.*;
import com.aspose.slides.exceptions.InvalidOperationException;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                IChart chart = (IChart) shape;
                try {
                    String range = chart.getChartData().getRange();
                    System.out.println(chart.getName() + ": " + range);
                } catch (InvalidOperationException exception) {
                    System.out.println(chart.getName() + ": The chart does not use a workbook as its data source.");
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Diagram adatok olvasása és írása munkafüzetből**

Az Aspose.Slides for Android via Java biztosítja a [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) és [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) metódusokat, amelyek lehetővé teszik a diagram adat munkafüzetek (Az Aspose.Cells‑el szerkesztett diagramadatok) olvasását és írását. **Megjegyzés:** a diagram adatot ugyanúgy vagy hasonló szerkezetben kell elrendezni, mint a forrás.

Ez a példa egy olyan prezentációt használ, amelynek első alakzata az első dián egy diagram. Beolvassa a beágyazott munkafüzetet egy bájt­tömbbe, törli a meglévő sorozatokat és kategóriákat, majd visszaírja ugyanazt a munkafüzetet. A módosítások memóriában maradnak; a példa nem menti a prezentációt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Diagram elrendezésének ellenőrzése a munkafüzet módosítása után**

Ha egy beágyazott munkafüzetet egy módosítottval helyettesít, a diagram megtartja az eredeti sorozat‑ és kategória‑gyűjteményeit. Ez a nem egyezés a [IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) metódus hibához, index‑kívül‑tartomány („index‑out‑of‑range”) hibához vezethet. Írja ki a meglévő sorozatokat és kategóriákat, mielőtt a frissített munkafüzetet visszaírná a diagramba. Ez a példa egy diagramot használ, amely az első dián az első alakzat. A megjegyzés jelzi, hol történne a munkafüzet szerkesztése; a futtatható példa az eredeti munkafüzetet írja vissza, és a memóriában ellenőrzi a layoutot.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        byte[] workbookData = chartData.readWorkbookStream();

        // Módosítsa itt a munkafüzet bájtjait, például az Aspose.Cells használatával.

        chartData.getSeries().clear();
        chartData.getCategories().clear();

        chartData.writeWorkbookStream(workbookData);
        chart.validateChartLayout();
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

A gyűjtemények törlése eltávolítja a régi adathivatkozásokat, mielőtt a munkafüzet vissza lenne írva. Építse újra a szükséges sorozat‑ és kategória‑leképezéseket a frissített munkafüzethez, mielőtt a diagramot használja.

## **Kategóriacímkék tárolási módjának kiválasztása**

Hívja meg a [IChartCategoryCollection.setUseCells](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategorycollection/#setUseCells-boolean-) metódust az üres kategória‑gyűjteményen, mielőtt címkéket adna hozzá. Használjon munkalap‑cellákat olyan címkékhez, amelyek a munkafüzet adataira hivatkoznak, vagy hierarchiát alkotnak, például negyedévekre csoportosítva évenként. Használjon karakterlánc‑literálokat egyszerű szintű címkékhez, amelyeknek nincs szükségük cellahivatkozásokra. Ez a beállítás csak a kategóriákra vonatkozik. A példában mindkét diagram a számértékekhez munkalap‑cellákat használ.

A példa két oszlopdiagramot hoz létre, és kiírja a tárolási módot, majd a `Q1 Q2 Q3 Q4` sorozatot minden diagramhoz. Munkalap‑háttérrel rendelkező címkék esetén a [IChartCategory.getAsCell](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/#getAsCell--) visszaadja az alatta lévő cellát, a [IChartDataCell.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#getValue--) pedig a címkét. Literális címkék esetén a [IChartCategory.getValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartcategory/#getValue--) metódussal olvasható a karakterlánc közvetlenül.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    for (boolean useCells : new boolean[] {true, false}) {
        int x = useCells ? 20 : 360;
        IChart chart = shapes.addChart(ChartType.ClusteredColumn, x, 20, 320, 250);
        IChartData data = chart.getChartData();
        data.getSeries().clear();
        IChartCategoryCollection categories = data.getCategories();
        categories.clear();
        categories.setUseCells(useCells);

        IChartDataWorkbook workbook = data.getChartDataWorkbook();
        IChartDataCell seriesName = workbook.getCell(0, 0, 1, "Sales");
        IChartSeries series = data.getSeries().add(seriesName, chart.getType());
        for (int row = 1; row <= 4; row++) {
            String label = "Q" + row;
            if (useCells) {
                IChartDataCell labelCell = workbook.getCell(0, row, 0, label);
                categories.add(labelCell);
            } else {
                categories.add(label);
            }

            IChartDataCell valueCell = workbook.getCell(0, row, 1, row * 10);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }

        System.out.print("UseCells = " + categories.getUseCells() + ":");
        for (IChartCategory category : categories) {
            Object label = categories.getUseCells() ? category.getAsCell().getValue() : category.getValue();
            System.out.print(" " + label);
        }
        System.out.println();
    }

    presentation.save("category-labels.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Egyedi számformátumok beállítása munkafüzet cellákhoz**

Használja a [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) metódust a numerikus értékek megjelenésének szabályozásához a diagram beágyazott munkafüzetében. Például egy jelentésnek szüksége lehet egy átváltási arány százalékos megjelenítésére négy tizedes helyzettel, illetve egy koefficiens megjelenítésére öt tizedes helyzettel. Tartsa mindkét értéket numerikus formában, hogy továbbra is felhasználhatóak legyenek számításokhoz és diagramábrázoláshoz.

A számformátum a megjelenítést változtatja, nem a tárolt értéket. A `0.0000%` formátum a `0.125` értéket `12.5000%`‑ként jeleníti meg; nem cseréli le a tárolt számot `12.5`‑re. Hasonlóan, a `0.00000` a `0.1234567`‑et `0.12346`‑ként jeleníti meg, anélkül, hogy a tárolt értéket kerekítené. Ha az egyedi formátum egy üres karakterlánc (`""`), akkor a [getPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) által visszaadott formátumot használja.

Az alábbi példa egy oszlopdiagramot hoz létre, és a cellákat a [getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) segítségével éri el. Az első munkalapon a B2 tartalmazza az átváltási arányt, a C2 a koefficienset. Mindkét cella a diagram értékét adja. A példa fel is kapcsolja a forrásformátumhoz kapcsolt értékcímkéket.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getSlideSize().setSize(720, 270, SlideSizeScaleType.DoNotScale);
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 20, 620, 210);
    chart.setTitle(false);

    chart.getAxes().getVerticalAxis().setNumberFormatLinkedToSource(false);
    chart.getAxes().getVerticalAxis().setNumberFormat("0.00");
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(0);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    workbook.clear(0);

    IChartDataCell categoryCell = workbook.getCell(0, "A2", "Sample");
    chart.getChartData().getCategories().add(categoryCell);

    IChartDataCell percentageCell = workbook.getCell(0, "B2", 0.125);
    percentageCell.setCustomNumberFormat("0.0000%");
    IChartDataCell percentageName = workbook.getCell(0, "B1", "Conversion rate");
    IChartSeries percentageSeries = chart.getChartData().getSeries().add(percentageName, chart.getType());
    percentageSeries.getDataPoints().addDataPointForBarSeries(percentageCell);

    IChartDataCell precisionCell = workbook.getCell(0, "C2", 0.1234567);
    precisionCell.setCustomNumberFormat("0.00000");
    IChartDataCell precisionName = workbook.getCell(0, "C1", "Coefficient");
    IChartSeries precisionSeries = chart.getChartData().getSeries().add(precisionName, chart.getType());
    precisionSeries.getDataPoints().addDataPointForBarSeries(precisionCell);

    for (IChartSeries series : chart.getChartData().getSeries()) {
        IDataLabelFormat labelFormat = series.getDataPoints().get_Item(0).getLabel().getDataLabelFormat();
        labelFormat.setShowValue(true);
        labelFormat.setNumberFormatLinkedToSource(true);
    }

    presentation.save("CustomCellFormats.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A munkafüzet cellaformátumok különböznek a diagram tengelyeken vagy adatcímkéken közvetlenül beállított formátumoktól. Ebben a példában minden címke a forráscellája értékét jeleníti meg, mert a [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) `true`‑ra van állítva, és a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) is `true`. A prezentáció mentése és újranyitása után a címkék `12.5000%` és `0.12346` értékeket mutatják, ahogy lent látható. A függőleges tengely saját számformátumot használ, amely a [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) `0.00` értékével van beállítva, a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) pedig `false`.

Egy adatcímke önálló formázásához állítsa a forrás‑kapcsolati jelzőt `false`‑ra, és adjon meg egy formátumot a [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) metódussal. Ez nem változtatja meg a munkafüzet cella formátumát. Például egy `0.00` formátumú önálló címke az első értéket `0.13`‑ként jeleníti meg, míg a B2 továbbra is `12.5000%`‑t mutat. Lásd a [Diagram adatcímkék](/slides/hu/androidjava/chart-data-label/#set-the-percentage-sign-with-chart-data-labels) oldalt a közvetlen címkeformázáshoz.

Az alábbi kép a prezentáció mentése után, újranyitásakor készült:

![Oszlopdiagram forráskapcsolt címkékkel, amelyek 12.5000% és 0.12346 értékeket mutatnak, valamint egy önállóan formázott numerikus tengellyel.](custom-cell-formats.png)

## **Munkafüzet cella beállítása diagram adatcímkeként**

A munkafüzet cellák szövegét felhasználhatja diagram adatcímkékként.

Ez a példa egy buborékdiagramot ad hozzá, alapértelmezett adatokkal, az első diára egy meglévő prezentációban. A 0‑s munkalapon az A10:A12 tartományt használja az első sorozat első három címkéjéhez, bekapcsolja a cellákból származó címkéket, majd menti a frissített prezentációt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("chart2.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    series.getLabels().getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    series.getLabels().get_Item(0).setValueFromCell(workbook.getCell(0, "A10", "Label 0 cell value"));
    series.getLabels().get_Item(1).setValueFromCell(workbook.getCell(0, "A11", "Label 1 cell value"));
    series.getLabels().get_Item(2).setValueFromCell(workbook.getCell(0, "A12", "Label 2 cell value"));

    presentation.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Munkalapok kezelése**

Az [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) metódus hozzáférést biztosít a diagram munkafüzetben lévő munkalapokhoz. Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és minden munkalap nevét a konzolra írja.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();

    for (int i = 0; i < workbook.getWorksheets().size(); i++) {
        System.out.println(workbook.getWorksheets().get_Item(i).getName());
    }
} finally {
    presentation.dispose();
}
```

## **Az adatforrás típusának megadása**

A sorozat pont értékeit közvetlenül numerikus literálokként is tárolhatja. Tekintse meg a [Sorozatértékek beállítása numerikus literálokkal](/slides/hu/androidjava/chart-series/#set-series-values-using-numeric-literals) oldalt a teljes példához, amely menti és olvassa ezeket. A pontértékek adatforrása elkülönül a diagram belső vagy külső munkafüzet konfigurációjától; a numerikus literálok használata önmagában nem távolítja el a beágyazott munkafüzetet.

Ez a példa egy 3D oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozatnevet állít be különböző adatforrásokkal. Az első név egy karakterlánc‑literál, a második a 0‑s munkalap C1 cellája. A [DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) felsorolás választja ki a forrást minden névhez. A példa a frissített sorozatnevekkel menti a prezentációt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue literalName = chart.getChartData().getSeries().get_Item(0).getName();

    literalName.setDataSourceType(DataSourceType.StringLiterals);
    literalName.setData("LiteralString");

    IStringChartValue cellName = chart.getChartData().getSeries().get_Item(1).getName();
    IChartDataCell nameCell = chart.getChartData().getChartDataWorkbook().getCell(0, "C1", "NewCell");
    cellName.setDataSourceType(DataSourceType.Worksheet);
    cellName.setData(nameCell);

    presentation.save("pres.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Nem támogatott beágyazott munkafüzet formátumok felderítése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely egyes diagramokba beágyazható. A [getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) metódust az [IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/)‑on együtt a [WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/) felsorolással használhatja a nem támogatott formátumok felismerésére és a diagramok kihagyására. Ez a példa ellenőrzi az első dián lévő alakzatokat egy meglévő prezentációban, kihagyja a nem‑diagram alakzatokat, és diagnosztikai üzenetet ír ki minden .xlsb beágyazott munkafüzetet tartalmazó diagramra.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) {
            continue;
        }

        IChart chart = (IChart) shape;
        IChartData chartData = chart.getChartData();
        boolean isInternalWorkbook = chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook;
        boolean isBinaryMacro = chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro;

        if (isInternalWorkbook && isBinaryMacro) {
            System.out.println("Skipping a chart with an unsupported .xlsb workbook.");
            continue;
        }

        // Olvassa vagy módosítsa itt a támogatott diagram munkafüzet adatokat.
    }
} finally {
    presentation.dispose();
}
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetek diagram adatforrásként való használatát.

### **Külső munkafüzet létrehozása**

Használja a [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) és a [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) metódusokat a beágyazott diagram munkafüzet exportálásához egy fájlba, és a diagram külső munkafüzethez való kapcsolásához.

Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és exportálja a munkafüzetét. A fájlírás befejezése után állítja be a külső munkafüzetet adatforrásként a diagramhoz, majd menti a kapcsolt prezentációt.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    File workbookFile = new File("externalWorkbook1.xlsx").getAbsoluteFile();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        try (FileOutputStream workbookStream = new FileOutputStream(workbookFile)) {
            workbookStream.write(workbookData);
        }
        chart.getChartData().setExternalWorkbook(workbookFile.getAbsolutePath());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Külső munkafüzet beállítása**

A [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) metódussal egy külső munkafüzetet rendelhet hozzá egy diagramhoz adatforrásként. Ezzel a metódussal frissítheti a külső munkafüzet elérési útját is (ha az áthelyezésre került).

Bár nem szerkesztheti a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait, továbbra is használhatja ezeket külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzethez, az automatikusan teljes útra lesz konvertálva.

Ez a példa egy külső munkafüzetet használ, amelynek `Sheet1` munkalapján a B1 cellában egy sorozat neve, az A2:A4 tartományban a kategória nevek, a B2:B4 tartományban pedig a numerikus értékek vannak. A példa egy kördiagramot hoz létre, összekapcsolja a munkafüzetet, és a [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) segítségével az A1:B4 tartományt egy sorozathoz és három kategóriához rendeli. A prezentációt a kapcsolt diagrammal menti.

```java
import com.aspose.slides.*;
import java.io.File;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    File workbookFile = new File("externalWorkbook.xlsx");
    String workbookPath = workbookFile.getAbsolutePath();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) `updateChartData` paramétere szabályozza, hogy a munkafüzet be legyen‑töltve.

* Ha `updateChartData` **false**, csak a munkafüzet útvonala frissül. A diagram adatai nem töltődnek be vagy frissülnek a célmunkafüzetből, így a munkafüzet elérhetetlen is lehet.
* Ha `updateChartData` **true**, a diagram adatai frissülnek a célmunkafüzetből.

Az alábbi példa egy helyettesítő URL‑t ad meg, a `updateChartData` **false** értékkel. A kördiagram alapértelmezett adatait megtartja, és a prezentációt anélkül menti, hogy a nem elérhető munkafüzetet betöltené.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    chart.getChartData().setExternalWorkbook("https://example.com/unavailable-workbook.xlsx", false);

    presentation.save("SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Külső adatforrás munkafüzet útvonalának lekérdezése diagramhoz**

Az egy diagramhoz kapcsolt munkafüzet azonosításához ellenőrizze, hogy a diagram külső adatforrást használ‑e, és kérje le a munkafüzet útvonalát.

Ez a példa az első dián az első alakzatot vizsgálja egy, külső munkafüzettel kapcsolt prezentációban. Ha a diagram külső munkafüzettel van összekapcsolva, a példa a [getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) értékét írja a konzolra, majd egy másolatot ment a prezentációról.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("externalWorkbook.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartData chartData = chart.getChartData();
        if (chartData.getDataSourceType() == ChartDataSourceType.ExternalWorkbook) {
            System.out.println(chartData.getExternalWorkbookPath());
        } else {
            System.out.println("The chart does not use an external workbook.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }

    presentation.save("Result.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Diagram adatainak szerkesztése**

Külső munkafüzetek adatait ugyanúgy szerkesztheti, mint a belső munkafüzetekét. Ha egy külső munkafüzet nem tölthető be, kivétel keletkezik.

Ez a példa egy diagramot használ, amely az első dián az első alakzat, és egy elérhető külső munkafüzethez van kapcsolva. A első sorozat első adatpontjának cella‑alapú értékét 100‑ra állítja, majd menti a frissített prezentációt. A cella‑értékek szerkesztése frissítheti a kapcsolt külső XLSX fájlt, ezért használjon másolatot, ha az eredeti munkafüzetet meg szeretné őrizni.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartSeriesCollection series = chart.getChartData().getSeries();
        if (series.size() > 0 && series.get_Item(0).getDataPoints().size() > 0) {
            IChartDataCell valueCell = series.get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell();
            if (valueCell != null) {
                valueCell.setValue(100);
                presentation.save("presentation_out.pptx", SaveFormat.Pptx);
            } else {
                System.out.println("The first data point is not linked to a workbook cell.");
            }
        } else {
            System.out.println("The chart has no data points to edit.");
        }
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

### **Munkafüzet helyreállítása a diagram gyorsítótárából**

Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzetet használ, az Aspose.Slides a diagram gyorsítótárában lévő adatból rekonstruálhatja a munkafüzetet. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) objektumot, hívja a [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) metódust, és állítsa a [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) értékét **true**‑ra a prezentáció megnyitása előtt.

Az alábbi Java példa helyreállítja a munkafüzet adatokat egy olyan diagramhoz, amely az első dián az első alakzat, és egy nem elérhető külső munkafüzetre hivatkozik. A helyreállított adatot a [IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) és a [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) segítségével éri el:

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int shapeCount = slide.getShapes().size();
    if (shapeCount > 0 && slide.getShapes().get_Item(0) instanceof IChart) {
        IChart chart = (IChart) slide.getShapes().get_Item(0);
        IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

        // Olvassa vagy módosítsa itt a helyreállított munkafüzet adatait.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Ha a külső munkafüzet nem érhető el, és a helyreállítás ki van kapcsolva, az Aspose.Slides kivételt dob. Csak akkor kapcsolja be a helyreállítást, ha a gyorsítótárban tárolt diagramadatok használata elfogadható tartalékmegoldás, mivel a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzetben a legutóbbi módosításokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzethez van‑e kapcsolva?**

Igen. A diagramnak van egy [data source type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) és egy [path to an external workbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); ha a forrás egy külső munkafüzet, akkor kiolvashatja a teljes útvonalat, hogy megbizonyosodjon, hogy egy külső fájlt használ.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, az automatikusan átalakul abszolút úttá. A prezentáció az abszolút útvonalat tárolja a PPTX fájlban, így a munkafüzet áthelyezése frissítést igényelhet a hivatkozáson.

**Használhatok munkafüzeteket hálózati erőforrásokon/megosztásokon?**

Igen, ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ból nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja a külső XLSX fájlt a prezentáció mentésekor?**

A prezentáció egy [linket a külső fájlhoz](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) tárol. A cellák‑alapú diagramadatok szerkesztése frissítheti a kapcsolt helyi XLSX fájlt is. Ha az eredeti munkafüzetet érintetlenül kell hagyni, használjon egy másolatot.

**Mit tegyek, ha a külső fájl jelszó‑védett?**

Az Aspose.Slides nem fogad jelszót a csatoláskor. Egy gyakori megoldás, hogy előzetesen eltávolítja a védelmet, vagy egy dekódolt másolatot készít (például az [Aspose.Cells](https://reference.aspose.com/cells/java/) segítségével), majd arra hivatkozik.

**Több diagram is hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram a saját hivatkozását tárolja. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagramot érint a következő adatbetöltéskor.