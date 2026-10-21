---
title: Diagramm munkafüzetek kezelése prezentációkban Java-val
linktitle: Diagramm munkafüzet
type: docs
weight: 70
url: /hu/java/chart-workbook/
keywords:
- diagramm munkafüzet
- diagrammadatok
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
description: "Fedezze fel az Aspose.Slides for Java-t: könnyedén kezelje a diagramm munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse a prezentáció adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk diagramm‑munkafüzetekkel az Aspose.Slides-ban. Megmutatja, hogyan olvassunk és írjunk diagrammadatokat munkafüzet‑folyamokon keresztül, hogyan használjunk munkafüzet‑cellákat diagrammadat‑címkékként, hogyan érjünk hozzá munkalap‑gyűjteményekhez, és hogyan határozzuk meg az adatforrás típusát a diagram értékekhez.

Továbbá tárgyalja a külső munkafüzetek diagrammadat‑forrásként való használatát. A példák bemutatják, hogyan hozhatunk létre és rendelhetünk hozzá egy külső munkafüzetet, hogyan kérhetjük le egy diagramhoz kapcsolt külső munkafüzet útvonalát, és hogyan szerkeszthetjük a diagramadatokat, amikor a munkafüzet elérhető.

A hiányzó adatot jelző munkafüzet‑cellákhoz lásd a [Üres cellák megjelenítésének szabályozása](/slides/hu/java/chart-series/) szakaszt, ahol megtudhatja a különbséget egy üres cella és a nulla között, valamint egy vonaldiagram‑összehasonlítást a rendelkezésre álló megjelenítési módokról.

## **Rejtett sorok és oszlopok adatainak belefoglalása**

Használja az [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) metódust a vezérléshez, hogy a diagram a rejtett munkalap‑sorokból és -oszlopokból származó adatokat ábrázolja‑e. Állítsa `true`‑ra, ha csak a látható cellákat szeretné ábrázolni, vagy `false`‑ra, ha a látható és a rejtett cellákat egyaránt bele kívánja foglalni. Ez a beállítás a diagram ábrázolását szabályozza; nem rejt vagy jelenít meg sorokat vagy oszlopokat a munkalapon.

A [minta bemutató](hidden-source-data.pptx) tartalmaz egy oszlopdiagramot, amely az első diájának első alakja. A beágyazott munkalap, `Sheet1`, a következő forrás‑tartományt tartalmazza, `A1:C4`. A 3. sor és a C oszlop rejtett, de a celláik továbbra is értéket tartalmaznak.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | Január | 10 | 30 |
| 3 (rejtett sor) | Február | 40 | 60 |
| 4 | Március | 20 | 50 |

A forrás‑cellákat a [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) segítségével érheti el, és a [IChartDataCell.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#isHidden--) metódussal ellenőrizheti a rejtett állapotukat. Ez a metódus a rejtett állapotot jelenti anélkül, hogy megváltoztatná azt. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz tartozik, a C2 a rejtett oszlophoz; a példa ennek megfelelően `false`, `true` és `true` értékeket ír ki.

Ehhez a példához frissítse a diagramadatokat a beállítás megváltoztatása után: tartsa meg a beágyazott munkafüzetet a [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) használatával, majd töltse be újra a [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) segítségével. Az összes cella belefoglalásához használja a [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) metódust a teljes tartomány helyreállításához, beleértve a rejtett februári kategóriát is. A jelző egyszerű módosítása nem elegendő a példa gyorsítótárazott diagramadatai és kategóriacímkéinek frissítéséhez.

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

            // Frissítse a diagram adatokat a beágyazott munkafüzetről.
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

A példa két változatban menti a bemutatót: az egyik csak a látható kiskereskedelmi értékekkel (10 és 20), a másik az összes hat értékkel. Az alábbi képek a két ábrázolási módot mutatják. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| Csak a látható cellák (`true`) | Minden cella (`false`) |
| --- | --- |
| ![Csak a látható cellák: Kiskereskedelmi értékek 10 és 20 januárra és márciusra.](hidden_cells_True.png) | ![Minden cella: Kiskereskedelem és nagykereskedelem értékek januárra, februárra és márciusra.](hidden_cells_False.png) |

Egy rejtett cella, amely értéket tartalmaz, különbözik egy üres cellától. Az [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) szabályozza, hogyan jelenjenek meg a hiányzó értékek; nem vonja be vagy zárja ki a rejtett forrásadatokat. Lásd a [Üres cellák megjelenítésének szabályozása](/slides/hu/java/chart-series/#control-the-display-of-empty-cells) példát.

## **Diagram adatcímének lekérése**

Mielőtt frissítené a munkafüzet‑adatokat egy meglévő bemutatóban, ellenőrizze a forrás‑tartományokat, hogy azonosítsa, mely munkalap‑cellákat használja az egyes diagramok. Az [IChartData.getRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getRange--) metódus visszaadja a jelenlegi adat­tartományt munkalap‑kvalifikált képletként, például `Sheet1!$A$1:$D$5`. Itt a `Sheet1` a munkalap neve, a `!` választja el a cellatartománytól, a `$A$1:$D$5` pedig az A1‑től D5‑ig terjedő cellákat jelöli, a dollárjelek pedig abszolút sor‑ és oszlop‑hivatkozásokat jelölnek.

A metódus a jelenlegi tartományt olvassa anélkül, hogy módosítaná a diagramot vagy annak munkafüzetét. Ha a diagram nem használ munkafüzetet adatforrásként, `InvalidOperationException`‑t dob. További információk a [ChartData API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/) oldalon.

Ez a példa megnyit egy bemutatót, és közvetlenül a diákon ellenőrzi az alakzatokat diagramok után. Kiírja minden diagram nevét és forrás‑tartományát. Ha egy diagram nem használ munkafüzetet, üzenetet ír ki, majd a következő diagramra lép.

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

## **Diagramadatok olvasása és írása munkafüzetből**

Az Aspose.Slides for Java biztosítja a [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) és a [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) metódusokat, amelyek lehetővé teszik a diagramadat‑munkafüzetek (amelyek az Aspose.Cells‑szel szerkesztett diagramadatokat tartalmazzák) olvasását és írását. **Megjegyzés**: a diagramadatoknak ugyanúgy kell felépülniük, vagy hasonló szerkezetűnek kell lenniük a forráshoz képest.

Ez a példa egy olyan bemutatót használ, amelynek első diáján az első alakzat egy diagram. Beolvassa a beágyazott munkafüzetet egy bájt‑tömbbe, törli a meglévő sorozatokat és kategóriákat, majd ugyanazt a munkafüzetet visszaírja. A változások memóriában maradnak; a példa nem menti a bemutatót.

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

### **Diagram elrendezésének ellenőrzése munkafüzet módosítása után**

Ha egy beágyazott munkafüzetet egy módosítottra cserél, a diagram megtartja az eredeti sorozat‑ és kategória‑gyűjteményeket. Ez a nem egyezés a [IChart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#validateChartLayout--) hibához vezethet, amely index‑out‑of‑range hibát dob. Törölje a meglévő sorozatokat és kategóriákat a módosított munkafüzet visszaírása előtt. Ez a példa egy olyan diagramot használ, amely az első diájának első alakzata. A megjegyzés azt jelzi, hol történne a munkafüzet‑szerkesztés; a futtatható példa az eredeti munkafüzetet írja vissza, és a memóriában ellenőrzi az elrendezést.

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

A gyűjtemények törlése elpusztítja a régi adat‑hivatkozásokat, mielőtt a munkafüzet vissza lenne írva. Építse újra a szükséges sorozat‑ és kategória‑leképezéseket a frissített munkafüzethez, mielőtt a diagramot használja.

## **Egyéni számformátumok beállítása munkafüzetcellákhoz**

Használja az [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) metódust a numerikus értékek megjelenésének szabályozására a diagram beágyazott munkafüzetében. Például egy jelentéshez szükség lehet arra, hogy egy konverziós arányt százalékosan, négy tizedesjeggyel, egy koefficienst pedig öt tizedesjeggyel jelenítsünk meg. Mindkét értéket tartsuk numerikus formában, hogy továbbra is elérhetőek legyenek a számításokhoz és a diagram ábrázolásához.

A számformátum a megjelenítést változtatja, nem a tárolt értéket. A `0.0000%` formátum a `0.125`‑öt `12.5000%`‑ként jeleníti meg; a tárolt szám nem lesz `12.5`. Hasonlóan, a `0.00000` a `0.1234567`‑et `0.12346`‑ként jeleníti meg anélkül, hogy a tárolt értéket kerekítené. Ha az egyéni formátum üres karakterlánc (`""`), akkor a [getPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) által visszaadott formátumot használja.

Az alábbi példa létrehoz egy oszlopdiagramot, és a cellákat a [getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) segítségével éri el. Az 0‑s munkalapon a B2 tartalmazza a konverziós arányt, a C2 a koefficienst. Mindkét cella diagramértékeket szolgáltat. A példa továbbá engedélyezi a forrásformátumhoz kapcsolt értékcímkéket.

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

A munkafüzet‑cellák formátuma különbözik a diagram tengelyeire vagy adatcímkéire közvetlenül beállított formátumoktól. Ebben a példában minden címke a forráscellájának értékét jeleníti meg, mivel a [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) `true`‑ra van állítva, és a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) `true`‑ra, így a forrás‑számformátumot követi. A mentés és újbóli megnyitás után a címkék `12.5000%` és `0.12346` értékeket mutatják, ahogy az alább látható. A függőleges tengely saját számformátumot használ, amelyet a [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) `0.00`‑ra állít, a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) pedig `false`‑ra van állítva.

Ha egy adatcímkét függetlenül szeretne formázni, állítsa a forrás‑hivatkozási jelzőt `false`‑ra, és adjon meg egy formátumot a [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-)‑nel. Ez nem változtatja meg a munkafüzet‑cellához tartozó formátumot. Például egy független címkeformátum `0.00` az első értéket `0.13`‑ként jeleníti meg, míg a B2 továbbra is `12.5000%`‑t mutat. Lásd a [Diagram adatcímkék](/slides/hu/java/chart-data-label/#set-percentage-sign-with-chart-data-labels) szakaszt a címkék közvetlen formázásához.

Az alábbi kép a mentett bemutató újbóli megnyitása után lett előállítva:

![Oszlopdiagram forrás‑kapcsolt címkékkel, amelyek 12.5000% és 0.12346 értékeket mutatnak, valamint egy önállóan formázott numerikus tengellyel.](custom-cell-formats.png)

## **Munkafüzet‑cellát diagram adatcímkeként használni**

A munkafüzet‑cellák szövegét is felhasználhatja diagram adatcímkékként.

Ez a példa egy buborékdiagramot ad hozzá alapértelmezett adatokkal egy meglévő bemutató első diájához. A 0‑s munkalap A10‑A12 tartományát használja az első sorozat első három címkéjéhez, engedélyezi a cellákból származó címkéket, és menti a frissített bemutatót.

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

Az [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) metódus hozzáférést biztosít a diagram munkafüzetének munkalapjaihoz. Ez a példa egy alapértelmezett adatú kördiagramot hoz létre, és a konzolra írja minden munkalap nevét.

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

## **Az adatforrás típusának meghatározása**

Ez a példa egy 3D oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozatnévet állít be különböző adatforrásokkal. Az első név egy karakterlánc‑literál, a második a 0‑s munkalap C1 cellájából származik. A [DataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/) felsorlat határozza meg a forrást minden névhez. A példa menti a bemutatót a frissített sorozatnevekkel.

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

## **Nem támogatott beágyazott munkafüzetformátumok felismerése**

Az Aspose.Slides nem támogatja a néhány diagramhoz beágyazható Excel bináris munkafüzet (.xlsb) formátumot. A [getEmbeddedWorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) metódust használhatja az [IChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/) esetén a [WorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/workbooktype/) felsorolattal együtt, hogy felismerje a nem támogatott formátumokat, és kihagyja azokat a diagramokat. Ez a példa ellenőrzi az első dián lévő alakzatokat egy meglévő bemutatóban, kihagyja a nem‑diagram alakzatokat, és diagnosztikai üzenetet ír ki minden .xlsb munkafüzettel rendelkező diagramról.

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

        // Olvassa vagy módosítsa itt a támogatott diagram munkafüzet adatait.
    }
} finally {
    presentation.dispose();
}
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetek diagramok adatforrásként való használatát.

### **Külső munkafüzet létrehozása**

Használja a [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) és a [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) metódusokat egy beágyazott diagram munkafüzetének exportálásához egy fájlba, majd a diagram kapcsolatának létrehozásához a külső munkafüzethez.

Ez a példa egy alapértelmezett adatú kördiagramot hoz létre, és exportálja a munkafüzetét. A fájlírás befejezése után rendeli hozzá a külső munkafüzetet adatforrásként, majd menti a kapcsolt bemutatót.

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

### **Külső munkafüzet beállítása**

A [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) metódussal egy külső munkafüzetet rendelhet egy diagramhoz adatforrásként. Ezzel a metódussal frissítheti a külső munkafüzet elérési útját is (ha az át lett helyezve).

Miközben a távoli helyen vagy erőforrásban tárolt munkafüzetek adatait nem szerkesztheti, továbbra is használhatja őket külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzethez, az automatikusan teljes útvonalra konvertálódik.

Ez a példa egy külső munkafüzetet használ, amelyen a `Sheet1` munkalapon a B1‑ben egy sorozatnév, az A2‑A4‑ben kategórianév, a B2‑B4‑ben numerikus értékek találhatók. A példa egy kördiagramot hoz létre, kapcsolja a munkafüzetet, és a [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-)‑nel az A1:B4‑et egy sorozatra és három kategóriára térképezi. Mentse a bemutatót a kapcsolt diagrammal.

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

A [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) `updateChartData` paramétere szabályozza, hogy a munkafüzet be legyen‑töltve.

* Ha az `updateChartData` `false`, csak a munkafüzet útvonalát frissíti. A diagramadatok nem lesznek betöltve vagy frissítve a cél‑munkafüzetről, így a munkafüzet hiányozhat.
* Ha az `updateChartData` `true`, a diagramadatok a cél‑munkafüzetről frissülnek.

Az alábbi példa egy helyőrző URL‑t rendeli hozzá, az `updateChartData` értéke `false`. A kördiagram alapértelmezett adatait megtartja, és a bemutatót anélkül menti, hogy a nem elérhető munkafüzetet betöltené.

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

### **Diagram külső adatforrás‑munkafüzetének útvonalának lekérése**

A diagramhoz kapcsolt munkafüzet azonosításához ellenőrizze, hogy a diagram külső adatforrást használ‑e, majd kérje le a munkafüzet útvonalát.

Ez a példa az első diájának első alakzatát vizsgálja egy olyan bemutatóban, amelynek diagramja külső munkafüzethez van kapcsolva. Ha egy diagram kapcsolt külső munkafüzettel rendelkezik, a példa a [getExternalWorkbookPath](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--)‑t írja a konzolra, majd ment egy másolatot a bemutatóról.

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

Külső munkafüzetek adatait ugyanúgy szerkesztheti, mint a belső munkafüzetek tartalmát. Ha egy külső munkafüzet nem tölthető be, kivétel keletkezik.

Ez a példa egy olyan diagramot használ, amely az első diájának első alakzata, és egy hozzáférhető külső munkafüzethez van kapcsolva. Beállítja az első sorozat első adatpontjának cella‑alapú értékét 100‑ra, és menti a frissített bemutatót. A cellaértékek szerkesztése frissítheti a kapcsolt külső XLSX fájlt, ezért másolatot használjon, ha az eredeti munkafüzetet meg kell őrizni.

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

Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzetet használ, az Aspose.Slides helyreállíthatja a diagram munkafüzettét a bemutatóban gyorsítótárazott adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) objektumot, hívja meg a [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-)‑t, és állítsa a [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) értékét `true`‑ra a bemutató megnyitása előtt.

Az alábbi Java‑példa helyreállítja a diagram adatokat, amely az első diájának első alakzata, és egy nem elérhető külső munkafüzetre hivatkozik. A helyreállított adatokat a [IChart.getChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getChartData--) és a [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) segítségével érheti el:

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

Ha a külső munkafüzet nem érhető el, és a helyreállítás le van tiltva, az Aspose.Slides kivételt dob. Engedélyezze a helyreállítást csak akkor, amikor a gyorsítótárazott diagramadatok használata elfogadható tartalék, mivel a gyorsító esetleg nem tartalmazza a külső munkafüzetben a bemutató legutóbbi frissítése után végzett módosításokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzethez kapcsolódik?**

Igen. A diagramnek van [data source type](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) és [path to an external workbook](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) attribútuma; ha a forrás egy külső munkafüzet, leolvashatja a teljes útvonalat, hogy megbizonyosodjon arról, külső fájlt használnak‑e.

**Támogatottak a relatív útvonalak külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, azt a rendszer automatikusan abszolút útvonallá alakítja. A bemutató az abszolút útvonalat tárolja a PPTX fájlban, ezért a munkafüzet áthelyezése esetén a hivatkozást frissíteni kell.

**Használhatók hálózati erőforrásokon/megosztásokon lévő munkafüzetek?**

Igen, ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑szal nem támogatott – csak forrásként alkalmazhatók.

**Az Aspose.Slides felülírja a külső XLSX‑et a bemutató mentésekor?**

A bemutató egy [link to the external file](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--)‑et tárol. A cella‑alapú diagramadatok szerkesztése frissítheti a kapcsolt helyi XLSX fájlt is. Használjon másolatot a munkafüzetről, ha az eredetit változatlanul kell hagyni.

**Mit kell tenni, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad jelszót a csatoláskor. Általános megoldás, hogy előre eltávolítja a védelmet, vagy egy dekódolt másolatot (például az [Aspose.Cells](https://reference.aspose.com/cells/java/)‑vel) készít, és arra hivatkozik.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram a saját hivatkozását tárolja. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagramon megjelenik a következő adatbetöltéskor.