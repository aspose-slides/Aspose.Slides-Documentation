---
title: Diagrammunkafüzetek kezelése prezentációkban Java használatával
linktitle: Diagram munkafüzet
type: docs
weight: 70
url: /hu/java/chart-workbook/
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
- Java
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Java-t: könnyedén kezelje a diagram munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse a prezentációs adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a diagramkönyvtárakkal dolgozni az Aspose.Slides‑ben. Megmutatja, hogyan lehet a diagramadatokat könyvtár‑folyamokon keresztül beolvasni és írni, a könyvtárcellákat diagramadat‑címkékként használni, a munkalap‑gyűjteményekhez hozzáférni, valamint meghatározni az adatforrás típusát a diagramértékekhez.

Emellett tárgyalja a külső könyvtárak diagramadat‑forrásként való használatát. A példák bemutatják, hogyan hozhatunk létre és rendelhetünk hozzá külső könyvtárat, hogyan kérhetjük le egy diagramhoz kapcsolt külső könyvtár útvonalát, valamint hogyan szerkeszthetjük a diagramadatokat, ha a könyvtár elérhető.

A hiányzó adatot jelző könyvtárcellák esetén lásd a [Control the Display of Empty Cells](/slides/hu/java/chart-series/) szakaszt az üres cella és a nulla közti különbség, valamint az elérhető megjelenítési módok vonaldiagram‑összehasonlítása tekintetében.

## **Rejtett sorok és oszlopok adatainak belefoglalása**

Használja a [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) metódust annak vezérlésére, hogy a diagram a rejtett munkalap‑sorok és -oszlopok adatát is ábrázolja‑e. Állítsa `true`‑ra, ha csak a látható cellákat szeretné ábrázolni, vagy `false`‑ra, ha a látható és rejtett cellákat egyaránt bele akarja foglalni. Ez a beállítás csak a diagram ábrázolását befolyásolja; nem rejti el vagy jeleníti meg a munkalap‑sorokat vagy -oszlopokat.

A [sample presentation](hidden-source-data.pptx) egy oszlopdiagramot tartalmaz első alakzatként az első dián. A beágyazott munkalap, `Sheet1`, a következő forrás‑tartományt tartalmazza: `A1:C4`. A 3. sor és a C oszlop rejtett, de celláik továbbra is tartalmaznak értékeket.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (hidden row) | February | 40 | 60 |
| 4 | March | 20 | 50 |

A forrás‑cellákhoz a [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) segítségével férhet hozzá, és a [IChartDataCell.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#isHidden--) metódussal ellenőrizheti rejtett‑állapotukat. Ez a metódus a rejtett állapotot adja vissza anélkül, hogy megváltoztatná azt. Ebben a példában a B2 látható, a B3 a rejtett sorhoz tartozik, a C2 pedig a rejtett oszlophoz; a példa a `false`, `true` és `true` értékeket írja ki.

Ehhez a példához a diagramadatok frissítése a beállítás módosítása után szükséges: tartsa meg a beágyazott könyvtárat a [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) segítségével, és töltse be újra a [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---)‑val. Az összes cella belefoglalásakor használja a [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) metódust a teljes tartomány, köztük a rejtett februári kategória visszaállításához. A jelző egyszerű módosítása nem elegendő a példa gyorsítótárazott diagramadatainak és kategória‑címkéinek frissítéséhez.

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
                // Állítsa vissza a teljes forrás tartományt, beleértve a rejtett kategóriákat.
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

A példa két változatban menti a bemutatót: egyetlen a látható kiskereskedelmi értékekkel (10 és 20), a másik az összes hat értékkel. Az alábbi képek a két ábrázolási módot mutatják. A 3. sor és a C oszlop mindkét beágyazott könyvtárban rejtett marad.

| Csak látható cellák (`true`) | Minden cella (`false`) |
| --- | --- |
| ![Csak látható cellák: kiskereskedelmi értékek 10 és 20 januárra és márciusra.](hidden_cells_True.png) | ![Minden cella: kiskereskedelmi és nagykereskedelmi értékek januárra, februárra és márciusra.](hidden_cells_False.png) |

Egy rejtett cella, amely értéket tartalmaz, különbözik egy üres cellától. A [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) metódus szabályozza, hogyan jelenjenek meg a hiányzó értékek; nem vonja be vagy zárja ki a rejtett forrásadatokat. Lásd a [Control the Display of Empty Cells](/slides/hu/java/chart-series/#control-the-display-of-empty-cells) példát.

## **Diagram adat‑tartományának lekérdezése**

Mielőtt egy meglévő bemutatóban módosítaná a könyvtáradatokat, ellenőrizze a forrás‑tartományokat, hogy megtudja, mely munkalap‑cellákat használja az egyes diagramok. A [IChartData.getRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getRange--) metódus az aktuális adat‑tartományt adja vissza munkalap‑kvalifikált képletként, például `Sheet1!$A$1:$D$5`. Itt a `Sheet1` a munkalap neve, a `!` választja el a cellatartománytól, a `$A$1:$D$5` pedig az A1‑től D5‑ig terjedő cellákat jelöli. A dollárjelek abszolút sor‑ és oszlop‑hivatkozásokat jelölnek.

A metódus a tartományt anélkül olvassa, hogy a diagramot vagy a könyvtárát módosítaná. Ha a diagram nem használ könyvtárat adatforrásként, `InvalidOperationException`‑t dob. További információk a [ChartData API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/)‑ben találhatók.

Ez a példa megnyit egy bemutatót, és közvetlenül minden dián ellenőrzi az alakzatokat diagramokra. Kiírja minden diagram nevét és forrás‑tartományát. Ha egy diagram nem használ könyvtárat, üzenetet ír ki, majd a következő diagramra lép.

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

## **Diagramadatok beolvasása és írása könyvtárból**

Az Aspose.Slides for Java a [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) és a [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) metódusokat biztosítja, amelyek lehetővé teszik a diagramadat‑könyvtárak (az Aspose.Cells‑el szerkesztett diagramadatokat tartalmazó) be- és kiolvasását. **Megjegyzés:** a diagramadatoknak ugyanolyan módon kell felépülniük, vagy hasonló struktúrával kell rendelkezniük, mint a forrás.

Ez a példa egy bemutatót használ, amelynek az első alakzata az első dián egy diagram. Beolvassa a beágyazott könyvtárat egy byte tömbbe, törli a meglévő sorozatokat és kategóriákat, majd visszaírja ugyanazt a könyvtárat. A módosítások csak memóriában maradnak; a példa nem menti a bemutatót.

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

### **Diagram elrendezésének érvényesítése könyvtár módosítása után**

Ha egy beágyazott könyvtárat egy módosított példánnyal helyettesít, a diagram megtartja az eredeti sorozat‑ és kategória‑gyűjteményeit. Ez a nem egyezés a [IChart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#validateChartLayout--) hibához vezethet, amely index‑túl‑tartomány hibát dob. Írja ki a meglévő sorozatokat és kategóriákat, mielőtt visszaírná a frissített könyvtárat a diagramba. Ez a példa egy diagramot használ, amely az első dián az első alakzat. A megjegyzés jelöli, hol történne a könyvtár‑szerkesztés; a futtatható példa visszaírja az eredeti könyvtárat, és memóriában érvényesíti a elrendezést.

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

        // Itt módosítsa a munkafüzet bájtjait, például az Aspose.Cells használatával.

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

A gyűjtemények törlése megszünteti a régi adat‑referenciákat, mielőtt a könyvtár visszaíródna. Építse újra a szükséges sorozat‑ és kategória‑leképezéseket a frissített könyvtárhoz, mielőtt a diagramot használná.

## **Kategória‑címkék tárolási módjának kiválasztása**

Hívja meg az [IChartCategoryCollection.setUseCells](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategorycollection/#setUseCells-boolean-) metódust a üres kategória‑gyűjteményen, mielőtt címkéket adna hozzá. Használjon munkalap‑cellákat olyan címkékhez, amelyek a könyvtáradatokra hivatkoznak vagy hierarchiát alkotnak, például negyedéveket év szerint csoportosítva. Használjon karakterlánc‑literálokat egyetlen szintű címkékhez, amelyeknek nincs szükségük cellahivatkozásra. Ez a beállítás csak a kategóriákra vonatkozik. Mindkét diagram a példában a numerikus sorozat‑értékekhez munkalap‑cellákat használ.

A példa két oszlopdiagramot hoz létre, és kiírja a tárolási módot, majd a `Q1 Q2 Q3 Q4` sorozatot mindegyikhez. Munkalap‑háttérrel rendelkező címkéknél a [IChartCategory.getAsCell](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/#getAsCell--) visszaadja az alapul szolgáló cellát, a [IChartDataCell.getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#getValue--) pedig a címkét. Literális címkéknél közvetlenül a [IChartCategory.getValue](https://reference.aspose.com/slides/java/com.aspose.slides/ichartcategory/#getValue--) adja vissza a szöveget.

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

## **Egyéni számformátumok beállítása könyvtár‑cellákhoz**

Használja a [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) metódust, hogy szabályozza, hogyan jelenjenek meg a numerikus értékek egy diagram beágyazott könyvtárában. Például egy jelentésnek szüksége lehet egy konverziós arányra, amelyet négy tizedesjegyű százalékban, valamint egy koefficiensre, amelyet öt tizedesjegyben kell megjeleníteni. Mindkét értéket számként kell megtartani, hogy elérhetők legyenek a számításokhoz és a diagramábrázoláshoz.

A számformátum a megjelenítést, nem a tárolt értéket módosítja. A `0.0000%` formátum a `0.125`‑et `12.5000%`‑ként jeleníti meg; nem cseréli le a tárolt számot `12.5`‑re. Hasonlóan, a `0.00000` a `0.1234567`‑et `0.12346`‑ként mutatja, a tárolt értéket anélkül, hogy kerekítené. Ha az egyéni formátum üres karakterlánc (`""`), akkor a [getPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) által visszaadott formátumot használja.

Az alábbi példa egy oszlopdiagramot hoz létre, és a celláihoz a [getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--)‑on keresztül fér hozzá. Az 0‑s indexű munkalapon a B2 tartalmazza a konverziós arányt, a C2 pedig a koefficienst. Mindkét cella diagramértéket szolgáltat. A példa engedélyezi a forrásformátumokhoz kapcsolt értékcímkéket is.

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

A könyvtár‑cellák formátumai elkülönülnek a diagram tengelyeire vagy adatcímkéire közvetlenül beállított formátumoktól. Ebben a példában minden címke a forráscellájának értékét jeleníti meg, mert a [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) `true`‑ra van állítva, és a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) is `true`. A mentés és újranyitás után a címkék `12.5000%`‑t és `0.12346`‑t mutatnak, amint az alább látható. A függőleges tengely saját számformátumot használ, amelyet a [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) `0.00`‑ra állít, a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) pedig `false`‑ra.

Egy adatcímke önálló formázásához állítsa a forrás‑kapcsolati jelzőt `false`‑ra, és adja meg a formátumot a [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-)‑val. Ez nem változtatja meg a könyvtár‑cellája formátumát. Például egy önálló `0.00` formátumú címke az első értéket `0.13`‑ként jeleníti meg, míg a B2 továbbra is `12.5000%`‑t mutat. Lásd a [Chart Data Labels](/slides/hu/java/chart-data-label/#set-percentage-sign-with-chart-data-labels) szakaszt a címkék közvetlen formázásához.

Az alábbi kép a mentett bemutató újranyitása után lett renderelve:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **Könyvtár‑cellát használni diagramadat‑címkeként**

A könyvtár‑cellák szövegét használhatja diagramadat‑címkeként.

Ez a példa egy buborékdiagramot ad hozzá alapértelmezett adatokkal az első diában lévő meglévő bemutatóhoz. A 0‑s indexű munkalapon az A10:A12 tartományt használja az első sorozat első három címkéjéhez, engedélyezi a cellákból származó címkéket, majd elmenti a frissített bemutatót.

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

A [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) metódus hozzáférést biztosít a diagramkönyvtár munkalapjaihoz. Ez a példa egy alapértelmezett adatú kördiagramot hoz létre, és minden munkalap nevét kiírja a konzolra.

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

## **Adatforrás‑típus meghatározása**

A sorozatpont‑értékek tárolhatók közvetlenül numerikus literálokként is. Lásd a [Set Series Values Using Numeric Literals](/slides/hu/java/chart-series/#set-series-values-using-numeric-literals) példát a teljes mentés‑ és olvasási folyamat bemutatásához. A pontértékek forrás‑típusa elkülönül a diagram belső vagy külső könyvtár‑konfigurációjától; a numerikus literálok használata önmagában nem távolítja el a beágyazott könyvtárat.

Ez a példa egy 3D oszlopdiagramot hoz létre alapértelmezett adatokal, és két sorozatnevet állít be különböző adatforrások használatával. Az első név egy karakterlánc‑literál, a második a 0‑s indexű munkalap C1 celláját használja. A [DataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/) felsorolás választja ki a forrást minden névhez. A példa a frissített sorozatnevekkel menti a bemutatót.

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

## **Nem támogatott beágyazott könyvtárformátumok észlelése**

Az Aspose.Slides nem támogatja a Excel bináris könyvtár (.xlsb) formátumot, amely bizonyos diagramokban beágyazható. A [getEmbeddedWorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) metódust a [IChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/)‑val együtt, valamint a [WorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/workbooktype/) felsorolással használhatja a nem támogatott formátumok felismerésére és az ilyen diagramok kihagyására. Ez a példa az első dián lévő alakzatokat vizsgálja egy meglévő bemutatóban, kihagyja a nem‑diagram alakzatokat, és diagnosztikai üzenetet ír ki minden .xlsb könyvtárral rendelkező diagramra.

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

        // Olvassa vagy módosítsa a támogatott diagramkönyvtár adatokat itt.
    }
} finally {
    presentation.dispose();
}
```

## **Külső könyvtár**

Az Aspose.Slides támogatja külső könyvtárak diagramadat‑forrásként való használatát.

### **Külső könyvtár létrehozása**

Használja a [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) és a [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) metódusokat egy beágyazott diagramkönyvtár exportálásához fájlba, majd a diagram összekapcsolásához a külső könyvtárral.

Ez a példa egy alapértelmezett adatú kördiagramot hoz létre, és exportálja annak könyvtárát. A fájl írása befejeződik, mielőtt a külső könyvtárat a diagram adatforrásaként beállítaná, majd elmenti a kapcsolt bemutatót.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    Path workbookPath = Paths.get("externalWorkbook1.xlsx").toAbsolutePath();
    byte[] workbookData = chart.getChartData().readWorkbookStream();
    try {
        Files.write(workbookPath, workbookData);
        chart.getChartData().setExternalWorkbook(workbookPath.toString());
        presentation.save("externalWorkbook.pptx", SaveFormat.Pptx);
    } catch (IOException exception) {
        System.out.println("Could not write the external workbook: " + exception.getMessage());
    }
} finally {
    presentation.dispose();
}
```

### **Külső könyvtár beállítása**

A [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) metódussal egy külső könyvtárat rendelhet egy diagramhoz adatforrásként. Ezzel a metódussal frissíthető a külső könyvtár elérési útja is (ha a könyvtárat áthelyezték).

Bár távoli helyeken vagy erőforrásokban tárolt könyvtárak adatainak szerkesztése nem támogatott, ilyen könyvtárakat továbbra is használhat adatforrásként. Ha relatív útvonalat ad meg egy külső könyvtárhoz, az automatikusan teljes útvonallá konvertálódik.

Ez a példa egy külső könyvtárat használ, amelynek `Sheet1` munkalapja B1‑ben egy sorozatnevet, A2:A4‑ben kategórianéveket, B2:B4‑ben numerikus értékeket tartalmaz. A példa egy kördiagramot hoz létre, kapcsolja a könyvtárat, és a [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-)‑el az A1:B4 tartományt egy sorozatra és három kategóriára map‑olja. A diagrammal együtt menti a bemutatót.

```java
import com.aspose.slides.*;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();
    String workbookPath = Paths.get("externalWorkbook.xlsx").toAbsolutePath().toString();

    chartData.setExternalWorkbook(workbookPath);
    chartData.setRange("Sheet1!$A$1:$B$4");

    presentation.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

A [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) paramétere, az `updateChartData`, szabályozza, hogy a könyvtár betöltődik‑e.

* Ha az `updateChartData` **false**, csak a könyvtár útvonala frissül. A diagramadatai nem töltődnek be vagy frissülnek a célkönyvtárból, így a könyvtár akár nem is érhető el.
* Ha az `updateChartData` **true**, a diagramadatai frissülnek a célkönyvtárból.

A következő példa egy helyőrző URL‑t ad meg, az `updateChartData` értéke **false**. A kördiagram alapértelmezett adatait megtartja, és a bemutatót a könyvtár betöltése nélkül menti.

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

### **Diagram külső adatforrás‑könyvtárának útvonalának lekérdezése**

A diagramhoz kapcsolt könyvtár azonosításához ellenőrizze, hogy a diagram külső adatforrást használ‑e, és kérdezze le a könyvtár útvonalát.

Ez a példa az első dián az első alakzatot vizsgálja egy külső könyvtárral kapcsolt bemutatóban. Ha egy diagram külső könyvtárra hivatkozik, a példa a [getExternalWorkbookPath](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) értékét írja a konzolra, majd ment egy másolatot a bemutatóból.

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

### **Diagramadatok szerkesztése**

A külső könyvtárak adatait ugyanúgy szerkesztheti, ahogy a belső könyvtárakét. Ha egy külső könyvtár nem tölthető be, kivétel keletkezik.

Ez a példa egy diagramot használ, amely az első dián az első alakzat, és egy elérhető külső könyvtárra hivatkozik. A első sorozat első adatpontjának cella‑alapú értékét 100‑ra állítja, majd menti a frissített bemutatót. A cellaértékek szerkesztése frissítheti a kapcsolt külső XLSX‑fájlt, ezért használjon másolatot, ha az eredeti könyvtárat érintetlenül szeretné hagyni.

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

### **Könyvtár helyreállítása a diagram gyorsítótárából**

Ha egy diagram külső könyvtárra hivatkozik, amely hiányzik vagy nem érhető el, az Aspose.Slides helyreállíthatja a diagramkönyvtárat a prezentáció gyorsítótárában tárolt adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) objektumot, hívja meg a [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), és állítsa a [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) értékét **true**‑ra a prezentáció megnyitása előtt.

Az alábbi Java‑példa helyreállítja a könyvtáradatokat egy diagramhoz, amely az első dián az első alakzat, és egy nem elérhető külső könyvtárra hivatkozik. A helyreállított adatokat a [IChart.getChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getChartData--) és a [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) segítségével érheti el:

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

        // Olvassa vagy módosítsa a helyreállított könyvtár adatait itt.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Ha a külső könyvtár nem érhető el, és a helyreállítás ki van kapcsolva, az Aspose.Slides kivételt dob. A helyreállítást csak akkor engedélyezze, ha a gyorsítótár‑adatok használata elfogadható tartalék, mivel a gyorsítótár nem biztos, hogy tartalmazza a külső könyvtár legutóbbi módosításait a prezentáció legutóbbi frissítése óta.

## **GYIK**

**Meg tudom állapítani, hogy egy adott diagram külső vagy beágyazott könyvtárhoz van-e kapcsolva?**

Igen. A diagramnek van egy [data source type](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) és egy [path to an external workbook](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) tulajdonsága; ha a forrás egy külső könyvtár, a teljes útvonalat beolvashatja, hogy megbizonyosodjon a külső fájl használatáról.

**Támogatottak a relatív útvonalak a külső könyvtárakhoz, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, az automatikusan átalakul teljes útvonallá. A prezentáció a PPTX‑fájlban tárolja a teljes útvonalat, ezért a könyvtár áthelyezése esetén frissíteni kell a linket.

**Használhatók hálózati erőforrásokon/megosztott helyeken lévő könyvtárak?**

Igen, ilyen könyvtárak használhatók külső adatforrásként. Azonban a távoli könyvtárak közvetlen szerkesztése az Aspose.Slides‑ből nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja a külső XLSX‑et a prezentáció mentésekor?**

A prezentáció egy [link to the external file](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) tárol. A cella‑alapú diagramadatok szerkesztése szintén frissítheti a kapcsolt helyi XLSX‑fájlt. Használjon másolatot a könyvtárból, ha az eredetit változatlanul kell hagyni.

**Mit tegyek, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad jelszót a kapcsolódáshoz. Általános megoldás a védelem előzetes eltávolítása vagy egy dekódolt másolat (például az [Aspose.Cells](https://reference.aspose.com/cells/java/)) előkészítése, majd annak a másolatnak a használata.

**Több diagram hivatkozhat ugyanarra a külső könyvtárra?**

Igen. Minden diagram a saját linkjét tárolja. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagramon megjelenik a következő adatbetöltéskor.