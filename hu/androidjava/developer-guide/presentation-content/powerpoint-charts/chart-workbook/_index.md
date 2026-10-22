---
title: Diagram munkafüzeteinek kezelése bemutatókban Androidon
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
- bemutató
- Android
- Java
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Android for Java alkalmazást: könnyedén kezelje a diagram munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse bemutatói adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhat a diagram munkafüzetekkel az Aspose.Slides-ben. Megmutatja, hogyan olvashat és írhat diagram adatokat a munkafüzet adatfolyamokon keresztül, hogyan használhat munkafüzet cellákat diagram adatcímkeként, hogyan érheti el a munkalapgyűjteményeket, és hogyan adhatja meg az adatforrás típusát a diagram értékekhez.

Emellett tárgyalja a külső munkafüzetek diagram adatforrásként való használatát is. A példák bemutatják, hogyan hozhat létre és rendelhet hozzá egy külső munkafüzetet, hogyan kérheti le a diagramhoz csatolt külső munkafüzet elérési útját, és hogyan szerkesztheti a diagram adatokat, amikor a munkafüzet elérhető.

A hiányzó adatot képviselő munkafüzet cellák esetén lásd a [Az üres cellák megjelenítésének szabályozása](/slides/hu/androidjava/chart-series/), ahol az üres cella és a nulla közti különbségről, valamint a megjeleníthető módok vonaldiagram összehasonlításáról olvashat.

## **Rejtett sorok és oszlopok adatainak felvétele**

Használja a [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) metódust annak szabályozására, hogy a diagram a rejtett munkalap sorok és oszlopok adatait plotolja-e. Állítsa `true`-ra, ha csak a látható cellákat szeretné plotolni, vagy `false`-ra, ha mind a látható, mind a rejtett cellákat fel szeretné venni. Ez a beállítás csak a diagram plotolását érinti; nem rejti el vagy jeleníti meg a munkalap sorait vagy oszlopait.

A [példa bemutató](hidden-source-data.pptx) első diájának első alakzataként egy oszlopdiagramot tartalmaz. A beágyazott munkalap, `Sheet1`, a következő forrás tartományt tartalmazza: `A1:C4`. A 3. sor és a C oszlop rejtett, de a celláikban továbbra is értékek vannak.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | Január | 10 | 30 |
| 3 (rejtett sor) | Február | 40 | 60 |
| 4 | Március | 20 | 50 |

A forrás cellák eléréséhez használja a [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) metódust, és olvassa a [IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) értékét a rejtett állapot ellenőrzéséhez. Ez a módszer a rejtett állapotot jelzi anélkül, hogy megváltoztatná azt. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz tartozik, a C2 a rejtett oszlophoz; a példa sorban `false`, `true`, és `true` értékeket írja ki.

Ehhez a példához frissítse a diagram adatokat a plotolási beállítás módosítása után: tartsa meg a beágyazott munkafüzetet a [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) használatával, és töltse be újból a [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) segítségével. Az összes cella felvételekor használja a [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) metódust a teljes tartomány visszaállításához, beleértve a rejtett februári kategóriát is. Csak a jelző megváltoztatása nem elegendő a minta gyorsítótárazott diagram adatainak és kategóriacímkéinek frissítéséhez.

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

            // Frissítse a diagram adatokat a beágyazott munkafüzettől.
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

A példa két verziót ment a bemutatóból: egyet, amely csak a látható kiskereskedelmi értékeket (10 és 20) tartalmazza, és egyet, amely mind a hat értéket tartalmazza. Az alábbi képek a két plotolási módot illusztrálják. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| Csak látható cellák (`true`) | Minden cella (`false`) |
| --- | --- |
| ![Csak látható cellák: kiskereskedelmi értékek 10 és 20 januárra és márciusra.](hidden_cells_True.png) | ![Minden cella: kiskereskedelmi és nagykereskedelmi értékek januárra, februárra és márciusra.](hidden_cells_False.png) |

Egy értékkel rendelkező rejtett cella eltér az üres cellától. A [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) metódus szabályozza, hogyan jelenjenek meg a hiányzó értékek; nem vonja be vagy zárja ki a rejtett forrás adatokat. Lásd a [Az üres cellák megjelenítésének szabályozása](/slides/hu/androidjava/chart-series/#control-the-display-of-empty-cells) példát.

## **Diagram adat tartományának lekérdezése**

Mielőtt módosítaná a munkafüzet adatokat egy meglévő bemutatóban, ellenőrizze a forrás tartományokat, hogy mely munkalap cellákat használja az egyes diagramok. A [IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--) metódus visszaadja az aktuális adat tartományt egy munkalapra hivatkozó képletként, például `Sheet1!$A$1:$D$5`. Itt a `Sheet1` a munkalap neve, a `!` elválasztja a cellatartományt, és a `$A$1:$D$5` a A1‑től D5‑ig terjedő cellákat jelöli. A dollárjelek abszolút sor- és oszlophivatkozásokat jeleznek.

Ez a metódus a jelenlegi tartományt olvassa anélkül, hogy módosítaná a diagramot vagy a munkafüzettét. Ha a diagram nem használ munkafüzetet adatforrásként, `InvalidOperationException` kivételt dob. További információk a [ChartData API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/) oldalon.

Ez a példa egy bemutatót nyit meg, és minden dián közvetlenül ellenőrzi az alakzatokat diagramok után. Kiírja minden diagram nevét és forrás tartományát. Ha egy diagram nem használ munkafüzetet, üzenetet jelenít meg, és a következő diagramra lép.

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

Az Aspose.Slides for Android via Java biztosítja a [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) és a [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) metódusokat, amelyek lehetővé teszik a diagram adat munkafüzetek (az Aspose.Cells‑el szerkesztett diagramadatok) olvasását és írását. **Megjegyzés**: a diagram adatainak ugyanúgy vagy hasonló szerkezetben kell felépülniük, mint a forrás.

Ez a példa egy bemutatót használ, amelynek első diáján az első alakzat egy diagram. Beolvassa a beágyazott munkafüzetet egy bájt tömbbe, törli a meglévő sorozatokat és kategóriákat, majd ugyanazt a munkafüzetet írja vissza. A változtatások a memóriában maradnak; a példa nem menti el a bemutatót.

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

### **Érvényesítse a diagram elrendezését a munkafüzet módosítása után**

Ha egy beágyazott munkafüzetet egy módosított változatra cserél, a diagram megtartja az eredeti sorozat- és kategóriagyűjteményeket. Ez a nem egyezés a [IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) hibához vezethet, amely index‑túl‑határ hibát dob. Írja ki a meglévő sorozatokat és kategóriákat, mielőtt a frissített munkafüzetet visszaírná a diagramba. A példa egy olyan diagramot használ, amely az első diájának első alakzata. A megjegyzés jelzi, hol történne a munkafüzet szerkesztése; a futtatható példa visszaírja az eredeti munkafüzetet, és a memóriában ellenőrzi a layoutot.

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

A gyűjtemények törlése elavult adat hivatkozásokat távolít el, mielőtt a munkafüzet vissza lenne írásra. Építse újra a szükséges sorozat‑ és kategóriamappingeket a frissített munkafüzethez, mielőtt a diagramot használná.

## **Egyéni számformátumok beállítása munkafüzet celláira**

Használja a [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) metódust, hogy szabályozza, hogyan jelennek meg a numerikus értékek egy diagram beágyazott munkafüzetében. Például egy jelentésnek négy tizedesjegyű százalékos átváltási arányt, valamint öt tizedesjegyű koefficienset kell megjelenítenie. Tartsa mindkét értéket numerikus formában, hogy továbbra is elérhetőek legyenek a számítások és a diagram plotolása számára.

A számformátum csak a megjelenítést változtatja, nem a tárolt értéket. A `0.0000%` formátum a `0.125`‑et `12.5000%`‑ként jeleníti meg; nem helyettesíti a tárolt számot `12.5`‑től. Hasonlóan, a `0.00000` a `0.1234567`‑et `0.12346`‑ként jeleníti meg, anélkül, hogy a tárolt értéket kerekítené. Ha az egyéni formátum egy üres karakterlánc (`""`), akkor a [getPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) által visszaadott formátum lesz használva.

Az alábbi példa egy oszlopdiagramot hoz létre, és a cellákat a [getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) segítségével éri el. Az első munkalapon a B2 tartalmazza az átváltási arányt, a C2 a koefficienst. Mindkét cella diagram értékeket szolgáltat. A példa továbbá engedélyezi az adatcímkéket, amelyek a forrás formátumához vannak kapcsolva.

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

A munkafüzet cellaformátumok elkülönülnek a diagram tengelyeken vagy adatcímkéken közvetlenül beállított formátumoktól. Ebben a példában minden címke a forrás cella értékét jeleníti meg, mivel a [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) `true`‑ra van állítva, és a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) `true`‑ra. A mentés és újranyitás után a címkék a `12.5000%` és `0.12346` értékeket jelenítik meg, ahogy az alább látható. A függőleges tengely saját számformátumot használ, amelyet a [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) `0.00`‑ra állít, a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) pedig `false`.

Ahhoz, hogy egy adatcímkét függetlenül formázzon, állítsa a forrásra hivatkozó jelzőt `false`‑ra, és adjon meg egy formátumot a [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-) segítségével. Ez nem változtatja meg a munkafüzet cella formátumát. Például egy `0.00` formátumú független címke az első értéket `0.13`‑ként jeleníti meg, míg a B2 továbbra is `12.5000%`‑et mutat. Lásd a [Diagram adatcímkék](/slides/hu/androidjava/chart-data-label/#set-the-percentage-sign-with-chart-data-labels) oldalt a címkék közvetlen formázásához.

Az alábbi kép a mentett, újra megnyitott prezentációból lett renderelve:

![Oszlopdiagram forrás‑kapcsolt címkékkel, amelyek a 12.5000% és 0.12346 értékeket mutatják, valamint egy önállóan formázott numerikus tengellyel.](custom-cell-formats.png)

## **Munkafüzet cella beállítása diagram adatcímkeként**

Használhat szöveget a munkafüzet celláiból diagram adatcímkeként.

Ez a példa egy buborékdiagramot ad hozzá alapértelmezett adatokkal a meglévő bemutató első diájához. A 0‑s munkalapon az A10‑A12 cellákat használja az első sorozat első három címkéjéhez, engedélyezi a cellákból származó címkéket, és menti a frissített bemutatót.

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

Az [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) metódus hozzáférést biztosít a diagram munkafüzetének munkalapjaihoz. Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és kiírja minden munkalap nevét a konzolra.

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

## **Adatforrás típusának meghatározása**

A sorozat pontértékei közvetlenül numerikus literálokként is tárolhatók. Lásd a [Sorozatértékek beállítása numerikus literálok használatával](/slides/hu/androidjava/chart-series/#set-series-values-using-numeric-literals) komplett példát, amely menti és beolvassa őket. A pontértékek forrás típusa különálló a diagram belső vagy külső munkafüzet konfigurációjától; a numerikus literálok használata önmagában nem távolítja el a beágyazott munkafüzetet.

Ez a példa egy 3D oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozat nevet állít be különböző adatforrások használatával. Az első név egy karakterliterált használ; a második a 0‑s munkalap C1 celláját. A [DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) felsorolás választja ki a forrást minden névhez. A példa a frissített sorozatnevekkel menti a bemutatót.

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

## **Nem támogatott beágyazott munkafüzet formátumok észlelése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely néhány diagramba beágyazható. A [getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) metódust a [IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/) segítségével, a [WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/) felsorolással együtt használhatja a nem támogatott formátumok felismerésére és a diagramok kihagyására. Ez a példa az első dián lévő alakzatokat vizsgálja egy meglévő bemutatóban, kihagyja a nem-diagram alakzatokat, és diagnosztikai üzenetet ír ki minden olyan diagramhoz, amely beágyazott .xlsb munkafüzetet tartalmaz.

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

Használja a [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) és a [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) metódusokat egy beágyazott diagram munkafüzete fájlba exportálásához, és a diagramot ehhez a külső munkafüzethez kapcsolja.

Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és exportálja a munkafüzetét. A fájlírás befejezése után állítja be a külső munkafüzetet diagram adatforrásként, majd menti a kapcsolt bemutatót.

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

A [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) metódus segítségével egy külső munkafüzetet rendelhet egy diagramhoz adatforrásként. Ezzel a metódussal frissíthető a külső munkafüzet elérési útja is (ha az áthelyezésre került).

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem szerkesztheti, ilyen munkafüzetek még mindig használhatók külső adatforrásként. Ha a külső munkafüzet relatív útvonala van megadva, az automatikusan teljes útvonalra konvertálódik.

Ez a példa egy olyan külső munkafüzetet használ, amelynek a `Sheet1` munkalapján a B1 cella tartalmaz egy sorozat nevet, az A2‑A4 cellák kategória neveket, a B2‑B4 cellák numerikus értékeket. A példa egy kördiagramot hoz létre, összekapcsolja a munkafüzetet, és a [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) segítségével az A1:B4 tartományt egy sorozatra és három kategóriára térképezi. Mentse a bemutatót a kapcsolt diagrammal.

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

* Ha az `updateChartData` **false**, csak a munkafüzet útvonala frissül. A diagram adat nem lesz betöltve vagy frissítve a célmunkafüzetről, így a munkafüzet hiányzó is lehet.
* Ha az `updateChartData` **true**, a diagram adat frissül a célmunkafüzetről.

Az alábbi példa egy helyőrző URL‑t ad meg, az `updateChartData` értéke **false**. A kördiagram alapértelmezett adatait megtartja, és a bemutatót olyan módon menti, hogy a nem elérhető munkafüzetet ne töltse be.

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

### **A diagram külső adatforrásának munkafüzet útvonalának lekérdezése**

Ahhoz, hogy meghatározza, melyik munkafüzet van csatolva egy diagramhoz, ellenőrizze, hogy a diagram külső adatforrást használ‑e, és kérdezze le a munkafüzet útvonalát.

Ez a példa az első diájának első alakzatát vizsgálja egy külső munkafüzettel kapcsolt bemutatóban. Ha egy diagram külső munkafüzettel van összekapcsolva, a példa kiírja a [getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) értékét a konzolra, majd elment egy másolatot a bemutatóból.

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

Külső munkafüzetek adatait ugyanúgy szerkesztheti, ahogyan a belső munkafüzetek tartalmát módosítaná. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

Ez a példa egy olyan diagramot használ, amely az első diájának első alakzata, és elérhető külső munkafüzettel van összekapcsolva. Beállítja az első sorozat első adatpontjának cella‑háttér értékét 100‑ra, és menti a frissített bemutatót. A cellaértékek szerkesztése frissítheti a kapcsolt külső XLSX fájlt, ezért másolatot használjon, ha az eredeti munkafüzetet meg kell őrizni.

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

### **Munkafüzet helyreállítása a diagram gyorsítótárból**

Ha egy diagram olyan külső munkafüzetet használ, amely hiányzik vagy nem érhető el, az Aspose.Slides helyreállíthatja a diagram munkafüzettét a bemutatóban gyorsítótárazott adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) objektumot, hívja meg a [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) metódust, és állítsa a [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) értékét **true**‑ra a prezentáció megnyitása előtt.

Az alábbi Java példa helyreállítja a munkafüzet adatokat egy olyan diagramhoz, amely az első diájának első alakzata, és egy nem elérhető külső munkafüzetet hivatkozik. A helyreállított adatokat a [IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) és a [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) segítségével éri el:

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

        // Olvassa vagy módosítsa itt a helyreállított munkafüzet adatokat.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Ha a külső munkafüzet nem elérhető, és a helyreállítás le van tiltva, az Aspose.Slides kivételt dob. Engedélyezze a helyreállítást csak akkor, ha a gyorsítótárban tárolt diagram adatok elfogadható visszaesésként szolgálnak, mivel a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzetben a prezentáció utolsó frissítése óta végzett módosításokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzethez van‑e csatolva?**

Igen. A diagram rendelkezik egy [adatforrás típusa](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) és egy [külső munkafüzet elérési útja](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); ha a forrás egy külső munkafüzet, akkor kiolvashatja a teljes elérési utat, hogy megbizonyosodjon, egy külső fájl kerül használatra.

**Támogatottak a relatív utak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, az automatikusan átalakul abszolút útvonallá. A prezentáció az abszolút útvonalat tárolja a PPTX fájlban, ezért a munkafüzet áthelyezésekor a hivatkozást frissíteni kell.

**Használhatok munkafüzeteket hálózati erőforrásokon/megosztott meghajtókon?**

Igen, az ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ből nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja a külső XLSX‑et a prezentáció mentésekor?**

A prezentáció egy [linket a külső fájlra](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) tárol. A cellára hivatkozó diagramadatok szerkesztése frissítheti a kapcsolt helyi XLSX fájlt is. Használjon másolatot a munkafüzetről, ha az eredetit változtatás nélkül kell megőrizni.

**Mit tegyek, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad el jelszót a csatoláskor. Általános megoldás, hogy a védelmet előre eltávolítja, vagy egy dekódolt másolatot (például az [Aspose.Cells](https://reference.aspose.com/cells/java/)) készít, majd ahhoz csatol.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram a saját hivatkozását tárolja. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagramon megjelenik, amikor az adat betöltődik.