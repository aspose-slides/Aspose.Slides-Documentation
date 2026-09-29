---
title: Diagram munkafüzetek kezelése prezentációkban Androidon
linktitle: Diagram munkafüzet
type: docs
weight: 70
url: /hu/androidjava/chart-workbook/
keywords:
- diagram munkafüzet
- diagram adat
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
description: "Fedezze fel az Aspose.Slides for Android via Java-t: egyszerűen kezelje a diagram munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy áramvonalasítsa prezentációi adatait."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan dolgozhat a diagram munkafüzetekkel az Aspose.Slides-ban. Bemutatja, hogyan olvashat és írhat diagramadatokat munkafüzet adatfolyamokon keresztül, hogyan használhatja a munkafüzet cellákat diagramadatcímkeként, hogyan érheti el a munkalap gyűjteményeket, és hogyan adhatja meg az adatforrás típusát a diagramértékekhez.

A cikk tárgyalja azt is, hogyan használhatók külső munkafüzetek diagramadatforrásként. A példák bemutatják, hogyan hozhat létre és rendelhet hozzá egy külső munkafüzetet, hogyan kérdezheti le egy diagramhoz csatolt külső munkafüzet elérési útját, és hogyan szerkesztheti a diagramadatokat, ha a munkafüzet elérhető.

A hiányzó adatot képviselő munkafüzet cellákkal kapcsolatban lásd a [Üres cellák megjelenítésének vezérlése](/slides/hu/androidjava/chart-series/) cikket, amely bemutatja az üres cella és a nulla közötti különbséget, valamint egy vonaldiagram összehasonlítást az elérhető megjelenítési módokról.

## **Rejtett sorok és oszlopok adatainak belefoglalása**

Használja a [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) metódust annak szabályozására, hogy a diagram megjelenítse-e a rejtett munkalap sorok és oszlopok adatait. Állítsa `true`-ra, ha csak a látható cellákat szeretné megjeleníteni, vagy `false`-ra, ha mind a látható, mind a rejtett cellákat bele akarja foglalni. Ez a beállítás a diagram rajzolását szabályozza; nem rejt el vagy jelenít meg sorokat vagy oszlopokat a munkalapon.

Töltse le a [hidden-source-data.pptx](hidden-source-data.pptx) fájlt, és helyezze el a munkakönyvtárban. Az első diája egy oszlopdiagramot tartalmaz első alakzatként. A beágyazott munkalap, `Sheet1`, a következő forrás tartományt tartalmazza: `A1:C4`. A 3. sor és a C oszlop rejtett, de a celláik továbbra is tartalmaznak értékeket.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | Január | 10 | 30 |
| 3 (rejtett sor) | Február | 40 | 60 |
| 4 | Március | 20 | 50 |

A forráscellákhoz hozzáférhet a [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) metódussal, és a [IChartDataCell.isHidden](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) segítségével vizsgálhatja meg a rejtettségi állapotukat. Ez a metódus jelzi a rejtett állapotot anélkül, hogy megváltoztatná azt. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz tartozik, és a C2 a rejtett oszlophoz; a példa a `false`, `true` és `true` értékeket írja ki.

Ehhez a példához a diagramadatokat a rajzolási beállítás módosítása után frissíteni kell: a beágyazott munkafüzetet a [readWorkbookStream](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) metódussal tartsa meg, és töltse be újra a [writeWorkbookStream](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-) segítségével. Az összes cella belefoglalásakor használja a [setRange](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) metódust a teljes tartomány visszaállításához, beleértve a rejtett februári kategóriát is. A zászló egyszerű módosítása nem elegendő a mintában tárolt gyorsítótárazott diagramadatok és kategóriacímkék frissítéséhez.

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

A példa a `hidden_cells_true.pptx` fájlt csak a látható Kiskereskedelem értékekkel (10 és 20) menti, és a `hidden_cells_false.pptx` fájlt mind a hat értékkel. Az alábbi képek illusztrálják a két rajzolási módot. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| Csak látható cellák (`true`) | Minden cella (`false`) |
| --- | --- |
| ![Csak látható cellák: Kiskereskedelem értékek 10 és 20 januárra és márciusra.](hidden_cells_True.png) | ![Minden cella: Kiskereskedelem és Nagykereskedelem értékek januárra, februárra és márciusra.](hidden_cells_False.png) |

Egy értéket tartalmazó rejtett cella különbözik egy üres cellától. A [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) metódus szabályozza, hogyan jelennek meg a hiányzó értékek; nem vonja be vagy zárja ki a rejtett forrásadatokat. Lásd a [Üres cellák megjelenítésének vezérlése](/slides/hu/androidjava/chart-series/#control-the-display-of-empty-cells) példát.

## **Diagramadatok olvasása és írása munkafüzettel**

Az Aspose.Slides for Android via Java a [readWorkbookStream](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) és a [writeWorkbookStream](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-) metódusokat kínálja, amelyek lehetővé teszik diagramadat munkafüzeteinek (az Aspose.Cells‑szel szerkesztett diagramadatokat tartalmazó) olvasását és írását. **Megjegyzés**: a diagramadatokat ugyanúgy kell rendszerezni, vagy hasonló struktúrával kell rendelkezniük, mint a forrás.

Ez a példa megnyitja a `chart.pptx` fájlt, amelynek az első diáján az első alakzatként diagramot kell tartalmaznia. Beolvassa a beágyazott munkafüzetet egy bájt tömbbe, törli a meglévő sorozatokat és kategóriákat, majd visszaírja ugyanazt a munkafüzetet. A módosítások memóriában maradnak; a példa nem menti a bemutatót.

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

Ha egy beágyazott munkafüzetet egy módosítottval helyettesít, a diagram megtartja az eredeti sorozat- és kategóriagyűjteményeit. Ez az eltérés az [IChart.validateChartLayout](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichart/#validateChartLayout--) metódus hibáját okozhat, index‑túl‑hatókörű hibával. A módosított munkafüzet visszaírása a diagramra előtt törölje a meglévő sorozatokat és kategóriákat. Ez a példa a `chart.pptx` fájlt igényli, amelynek az első diáján az első alakzatként diagramot kell tartalmaznia. A megjegyzés jelöli, hol történne a munkafüzet szerkesztése; a futtatható példa visszaírja az eredeti munkafüzetet, és a memóriában ellenőrzi az elrendezést.

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

        // Módosítsa a munkafüzet bájtjait itt, például az Aspose.Cells használatával.

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

A gyűjtemények törlése eltávolítja a elavult adatreferenciákat, mielőtt a munkafüzetet visszaírná. Az diagram használata előtt építse újra a szükséges sorozat- és kategória leképezéseket a módosított munkafüzethez.

## **Munkafüzet cella beállítása diagramadatcímkének**

A munkafüzet cellákból származó szöveget használhatja diagramadatcímkeként. A következő lépések bemutatják, hogyan kapcsolja össze a buborékdiagram címkéit a diagram adatmunkafüzetének celláival.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.  
2. Érje el az első diát a nullától induló indexével.  
3. Adjon hozzá egy buborékdiagramot alapértelmezett adatokkal.  
4. Érje el a diagram sorozatát.  
5. Állítsa be a munkafüzet cellát adatcímkének.  
6. Mentse a bemutatót.

Ez a példa megnyitja a `chart2.pptx` fájlt, amelynek legalább egy diát kell tartalmaznia, és hozzáad egy alapértelmezett adatú buborékdiagramot. Az 0. munkalapon az A10:A12 cellákat használja az első sorozat első három címkéjéhez, engedélyezi a cellákból származó címkéket, és a eredményt a `resultchart.pptx` fájlba menti.

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

Az [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) metódus hozzáférést biztosít a diagram munkafüzetének munkalapjaihoz. Ez a példa egy alapértelmezett adatú kördiagramot hoz létre, és minden munkalap nevét kiírja a konzolra.

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

## **Adatforrás típusának megadása**

Ez a példa egy alapértelmezett adatú 3D oszlopdiagramot hoz létre, és két sorozatnevet állít be különböző adatforrásokkal. Az első név egy karakterlánc literált használ; a második a 0. munkalap C1 celláját használja. A [DataSourceType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/datasourcetype/) felsorolás kiválasztja a forrást minden névhez. Az eredményt a `pres.pptx` fájlba menti.

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

## **Nem támogatott beágyazott munkafüzet formátumok felismerése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely néhány diagramba beágyazható. A [getEmbeddedWorkbookType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) metódust az [IChartData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdata/) osztállyal együtt, valamint a [WorkbookType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/workbooktype/) felsorolással használhatja a nem támogatott formátumok felismerésére és az ilyen diagramok kihagyására. Ez a példa a `sample.pptx` első diáján lévő alakzatokat vizsgálja, átugorja a nem diagram alakzatokat, és diagnosztikai üzenetet ír ki minden .xlsb munkafüzetet tartalmazó diagramhoz.

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

        // Olvassa vagy módosítsa a támogatott diagram munkafüzet adatokat itt.
    }
} finally {
    presentation.dispose();
}
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetek diagramadatforrásként való használatát.

### **Külső munkafüzet létrehozása**

Használja a [readWorkbookStream](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) és a [setExternalWorkbook](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) metódusokat a beágyazott diagram munkafüzet fájlba exportálásához, és a diagram külső munkafüzethez való csatolásához.

Ez a példa egy alapértelmezett adatú kördiagramot hoz létre, a munkafüzettét a `externalWorkbook1.xlsx` fájlba írja, és a fájlírás befejezése után rendeli hozzá a fájlt diagramadatforrásként. A csatolt bemutatót a `externalWorkbook.pptx` fájlba menti.

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

A [setExternalWorkbook](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) metódus segítségével egy külső munkafüzetet rendelhet egy diagram adatforrásaként. Ez a metódus a külső munkafüzet útvonalának frissítésére is használható (ha az át lett helyezve).

Miközben a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem lehet szerkeszteni, ilyen munkafüzetteket továbbra is használhat külső adatforrásként. Ha egy külső munkafüzet relatív útvonala van megadva, az automatikusan teljes útra konvertálódik.

Ez a példa a munkakönyvtárban lévő `externalWorkbook.xlsx` fájlt igényli. A `Sheet1` nevű munkalapnak B1‑ben egy sorozatnevet, A2:A4‑ben kategórianéveket és B2:B4‑ben számértékeket kell tartalmaznia. A példa egy kördiagramot hoz létre, csatolja a munkafüzetet, és a [setRange](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) segítségével az A1:B4 tartományt egy sorozatra és három kategóriára képezi le. Az eredményt a `Presentation_with_externalWorkbook.pptx` fájlba menti.

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

A [setExternalWorkbook](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) `updateChartData` paramétere szabályozza, hogy a munkafüzet be legyen‑töltve.

* Ha `updateChartData` `false`, csak a munkafüzet útvonala frissül. A diagramadatok nem töltődnek be, illetve nem frissülnek a célnyelv munkafüzetből, így a munkafüzet elérhetetlen lehet.  
* Ha `updateChartData` `true`, a diagramadatok a célnyelv munkafüzettől frissülnek.

A következő példa egy helyettesítő URL‑t rendel, a `updateChartData`‑t `false`‑ra állítva. Megőrzi a kördiagram alapértelmezett adatait, és a bemutatót a nem elérhető munkafüzet betöltése nélkül menti.

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

### **Diagram külső adatforrás munkafüzet útvonalának lekérése**

A diagramhoz csatolt munkafüzet azonosításához először ellenőrizze, hogy a diagram külső adatforrást használ-e. Ha igen, a következő lépésekkel kérdezheti le a munkafüzet útvonalát.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation/) osztályból.  
2. Érje el az első diát a nullától induló indexével.  
3. Ellenőrizze, hogy az első alakzat diagram-e.  
4. Olvassa ki a diagram adatforrás típusát.  
5. Ha a forrás egy külső munkafüzet, olvassa ki annak útvonalát.

Ez a példa megnyitja a korábban létrehozott `externalWorkbook.pptx` fájlt, és az első dián az első alakzatot vizsgálja. Ha ez egy külső munkafüzettel összekapcsolt diagram, a példa a [getExternalWorkbookPath](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) értékét a konzolra írja. Ezután a bemutató egy másolatát a `Result.pptx` fájlba menti.

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

A külső munkafüzetek adatait ugyanúgy szerkesztheti, mint a belső munkafüzetek tartalmát. Ha egy külső munkafüzetet nem lehet betölteni, kivétel kerül dobásra.

Ez a példa a `presentation.pptx` fájlt igényli, amelyben az első dián egy diagram van, valamint egy elérhető külső munkafüzettet. A első sorozat első adatpontjának cellabeágyazott értékét 100-ra állítja, és a bemutatót a `presentation_out.pptx` fájlba menti. A cellák értékének szerkesztése frissítheti a kapcsolt külső XLSX fájlt, ezért használjon másolatot, ha az eredeti munkafüzetet meg kell tartani.

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

Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzetet használ, az Aspose.Slides képes a diagram munkafüzetet rekonstruálni a bemutatóban gyorsítótárazott adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/), hívja meg a [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), és állítsa a [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) értékét `true`‑ra a bemutató megnyitása előtt.

A következő Java példa megnyitja a `presentation.pptx` fájlt, amelynek az első diáján az első alakzatnak egy nem elérhető külső munkafüzetet hivatkozó diagramnak kell lennie, és a helyreállított adatokat eléri a [IChart.getChartData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichart/#getChartData--) és a [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) segítségével:

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

        // Olvassa vagy módosítsa a helyreállított munkafüzet adatokat itt.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Ha a külső munkafüzet nem elérhető és a helyreállítás ki van kapcsolva, az Aspose.Slides kivételt dob. Engedélyezze a helyreállítást csak akkor, ha a gyorsítótárazott diagramadatok használata elfogadható tartalék, mivel a gyorsítótár nem feltétlenül tartalmazhatja a prezentáció legutóbbi frissítése után a külső munkafüzetben történt változásokat.

## **FAQ**

**Meg tudom állapítani, hogy egy adott diagram egy külső vagy beágyazott munkafüzettel van‑e összekapcsolva?**

Igen. A diagram rendelkezik egy [adatforrás típusa](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) és egy [az external workbook útvonala](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) attribútummal; ha a forrás egy külső munkafüzet, akkor elolvashatja a teljes útvonalat, hogy megbizonyosodjon róla, hogy egy külső fájl van használatban.

**Támogatottak a relatív útvonalak külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, az automatikusan abszolút útvonalra konvertálódik. A bemutató az abszolút útvonalat tárolja a PPTX fájlban, ezért a munkafüzet áthelyezésekor frissíteni kell a hivatkozást.

**Használhatok hálózati erőforrásokon/megosztott helyeken lévő munkafüzetteket?**

Igen, ilyen munkafüzettek használhatók külső adatforrásként. Azonban a távoli munkafüzettek közvetlen szerkesztése az Aspose.Slides‑ból nem támogatott – csak forrásként használhatók.

**Felülírja az Aspose.Slides a külső XLSX‑et a bemutató mentésekor?**

A bemutató egy [linket a külső fájlra](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) tárol. A cellához kötött diagramadatok szerkesztése frissítheti a kapcsolt helyi XLSX fájlt is. Ha az eredetit meg kell tartani, használjon másolatot a munkafüzetről.

**Mit tegyek, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad el jelszót a hivatkozáskor. Egy gyakori megoldás, hogy előre eltávolítja a védelmet, vagy egy visszafejtett másolatot készít (például az [Aspose.Cells](https://reference.aspose.com/cells/java/) segítségével), majd ehhez a másolathoz csatolja.

**Több diagram is hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram saját hivatkozást tárol. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése a következő adatbetöltéskor minden diagramon megjelenik.