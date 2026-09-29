---
title: Java használatával prezentációk diagrammunkafüzeteinek kezelése
linktitle: Diagrammunkafüzet
type: docs
weight: 70
url: /hu/java/chart-workbook/
keywords:
- diagrammunkafüzet
- diagramadat
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
description: "Fedezze fel az Aspose.Slides for Java-t: egyszerűen kezelje a diagrammunkafüzeteket PowerPoint és OpenDocument formátumokban, hogy könnyebbé tegye prezentációs adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk diagramműköütteskönyvekkel az Aspose.Slides-ban. Megmutatja, hogyan olvashatunk és írhatunk diagrammadatokat munkafüzet adatfolyamokon keresztül, hogyan használhatunk munkafüzet cellákat diagrammadatok címkéjeként, hogyan érhetjük el a munkalap-gyűjteményeket, és hogyan adhatjuk meg az adatforrás típust a diagram értékeihez.

A cikk azt is lefedi, hogyan dolgozhatunk külső munkafüzetekkel diagram adatforrásként. A példák bemutatják, hogyan hozhatunk létre és rendelhetünk egy külső munkafüzetet, hogyan kérhetjük le egy diagramhoz csatolt külső munkafüzet elérési útját, és hogyan szerkeszthetjük a diagram adatokat, ha a munkafüzet elérhető.

A hiányzó adatot képviselő munkafüzet cellák esetén lásd a [Control the Display of Empty Cells](/slides/hu/java/chart-series/) oldalt, ahol megtalálható a különbség az üres cella és a nulla között, valamint egy vonaldiagram-összehasonlítás a rendelkezésre álló megjelenítési módokról.

## **Rejtett sorok és oszlopok adatainak belefoglalása**

Használja a [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) metódust annak szabályozására, hogy a diagram rejtett munkalap sorokból és oszlopokból is ábrázoljon-e adatot. Állítsa `true`‑ra, ha csak a látható cellákat szeretné ábrázolni, vagy `false`‑ra, ha a látható és a rejtett cellákat egyaránt bele kívánja foglalni. Ez a beállítás a diagram ábrázolását szabályozza; nem rejti el vagy jeleníti meg újra a munkalap sorait vagy oszlopait.

Töltse le a [hidden-source-data.pptx](hidden-source-data.pptx) fájlt, és helyezze el a munkakönyvtárban. Első diaja egy oszlopdiagramot tartalmaz első alakzatként. A beágyazott munkalap, `Sheet1`, a következő forrás tartományt tartalmazza: `A1:C4`. A 3. sor és a C oszlop rejtett, de a celláik továbbra is tartalmaznak értékeket.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | Január | 10 | 30 |
| 3 (hidden row) | Február | 40 | 60 |
| 4 | Március | 20 | 50 |

A forráscellákhoz a [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) segítségével férhet hozzá, és a [IChartDataCell.isHidden](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdatacell/#isHidden--) segítségével vizsgálhatja meg a rejtett állapotukat. Ez a módszer a rejtett állapotot jelenti anélkül, hogy módosítaná azt. Ebben a fájlban a B2 látható, a B3 a rejtett sorba tartozik, a C2 pedig a rejtett oszlopba; a példa sorban `false`, `true` és `true` értékeket ír ki.

Ehhez a példához frissítse a diagram adatokat a megjelenítési beállítás módosítása után: tartsa meg a beágyazott munkafüzetet a [readWorkbookStream](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdata/#readWorkbookStream--) segítségével, és töltse be újra a [writeWorkbookStream](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-) segítségével. Az összes cella belefoglalásakor használja a [setRange](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) metódust az egész tartomány visszaállításához, beleértve a rejtett februári kategóriát is. Csak a jelző megváltoztatása nem elegendő a minta gyorsítótárazott diagramadatai és kategóriacímkéinek frissítéséhez.

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

A példa a `hidden_cells_true.pptx` fájlt csak a látható kiskereskedelmi értékekkel (10 és 20) menti, a `hidden_cells_false.pptx` fájlt pedig mind a hat értékkel. Az alábbi képek a két ábrázolási módot illusztrálják. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtve marad.

| Csak látható cellák (`true`) | Minden cella (`false`) |
| --- | --- |
| ![Csak látható cellák: kiskereskedelmi értékek 10 és 20 január és március esetén.](hidden_cells_True.png) | ![Minden cella: kiskereskedelmi és nagykereskedelmi értékek január, február és március esetén.](hidden_cells_False.png) |

Egy értéket tartalmazó rejtett cella különbözik egy üres cellától. A [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) szabályozza, hogy a hiányzó értékek hogyan jelenjenek meg; nem vonja be vagy zárja ki a rejtett forrásadatokat. Lásd a [Control the Display of Empty Cells](/slides/hu/java/chart-series/#control-the-display-of-empty-cells) példát.

## **Diagramadatok olvasása és írása munkafüzetből**

Az Aspose.Slides for Java biztosítja a [readWorkbookStream](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdata/#readWorkbookStream--) és a [writeWorkbookStream](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-) metódusokat, amelyek lehetővé teszik a diagramadatok munkafüzeteinek (az Aspose.Cells segítségével szerkesztett diagramadatokat tartalmazó) olvasását és írását. **Megjegyzés**: a diagramadatoknak ugyanúgy kell felépülniük, vagy hasonló struktúrával kell rendelkezniük, mint a forrás.

Ez a példa megnyitja a `chart.pptx` fájlt, amelynek az első diájának első alakzata diagramnak kell lennie. Beolvassa a beágyazott munkafüzetet egy byte tömbbe, törli a meglévő sorozatokat és kategóriákat, majd ugyanazt a munkafüzetet visszaírja. A módosítások a memóriában maradnak; a példa nem menti a prezentációt.

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

### **Diagram elrendezésének érvényesítése munkafüzet módosítása után**

Amikor egy beágyazott munkafüzetet egy módosítottal helyettesít, a diagram megtartja az eredeti sorozat- és kategóriagyűjteményeit. Ez a különbség az [IChart.validateChartLayout](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichart/#validateChartLayout--) metódus hibához vezethet indexkívül-állomány hiba miatt. Törölje a meglévő sorozatokat és kategóriákat, mielőtt az új munkafüzetet visszaírná a diagramra. Ez a példa a `chart.pptx` fájlt igényli, amelynek az első diáján első alakzata diagram legyen. A megjegyzés jelzi, hol történik a munkafüzet szerkesztése; a futtatható példa visszaírja az eredeti munkafüzetet és memóriában érvényesíti az elrendezést.

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

A gyűjtemények törlése megszünteti a régi adat hivatkozásokat, mielőtt a munkafüzetet visszaírná. Építse újra a szükséges sorozat- és kategória leképezéseket a frissített munkafüzettől a diagram használata előtt.

## **Munkafüzet cella beállítása diagram adatcímkeként**

A munkafüzet celláiból származó szöveget használhatja diagram adatcímkékként. A következő lépések mutatják be, hogyan kapcsolja össze a buborékdiagram címkéit a diagram adatmunkafüzetének celláival.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
2. Érje el az első diát a nulla-alapú indexével.
3. Adjon hozzá egy buborékdiagramot alapértelmezett adatokkal.
4. Érje el a diagram sorozatát.
5. Állítsa be a munkafüzet cellát adatcímkeként.
6. Mentse a prezentációt.

Ez a példa megnyitja a `chart2.pptx` fájlt, amelynek legalább egy diát kell tartalmaznia, és hozzáad egy alapértelmezett adatú buborékdiagramot. Az 0. munkalapon lévő A10:A12 cellákat használja az első sorozat első három címkéjéhez, engedélyezi a cellákból származó címkéket, és a `resultchart.pptx` fájlba menti az eredményt.

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

Az [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) metódus hozzáférést biztosít a diagram munkafüzetben lévő munkalapokhoz. Ez a példa egy alapértelmezett adatú kördiagramot hoz létre, és minden munkalap nevét kiírja a konzolra.

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

Ez a példa egy 3D oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozatnevet állít be különböző adatforrásokkal. Az első név egy szó szerinti karakterláncot használ; a második a 0. munkalap C1 celláját. A [DataSourceType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/datasourcetype/) felsorolás választja ki a forrást minden névhez. Az eredményt a `pres.pptx` fájlba menti.

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

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely néhány diagramba beágyazható. A [getEmbeddedWorkbookType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) metódust a [IChartData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdata/) osztályon együtt a [WorkbookType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/workbooktype/) felsorolással használhatja a nem támogatott formátumok felismeréséhez és a diagramok kihagyásához. Ez a példa megvizsgálja a `sample.pptx` első diájának alakzatait, kihagyja a diagramon kívüli alakzatokat, és diagnosztikai üzenetet ír ki minden olyan diagramhoz, amely beágyazott .xlsb munkafüzettel rendelkezik.

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

        // Olvassa vagy módosítsa itt a támogatott diagrammunkafüzet adatokat.
    }
} finally {
    presentation.dispose();
}
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetek diagramok adatforrásként való használatát.

### **Külső munkafüzet létrehozása**

Használja a [readWorkbookStream](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdata/#readWorkbookStream--) és a [setExternalWorkbook](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) metódusokat a beágyazott diagram munkafüzete fájlba exportálásához és a diagram külső munkafüzethez való kapcsolásához.

Ez a példa egy alapértelmezett adatú kördiagramot hoz létre, a munkafüzettét a `externalWorkbook1.xlsx` fájlba írja, és a fájl írását befejezi a diagram adatforrásaként történő hozzárendelés előtt. A kapcsolt prezentációt a `externalWorkbook.pptx` fájlba menti.

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

A [setExternalWorkbook](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) metódus használatával egy külső munkafüzetet rendelhet egy diagram adatforrásához. Ez a metódus a külső munkafüzet elérési útjának frissítésére is használható (ha az utóbbit áthelyezték).

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem szerkesztheti, továbbra is használhatja ezeket külső adatforrásként. Ha egy külső munkafüzet relatív útvonalát adja meg, az automatikusan teljes útvonalra konvertálódik.

Ez a példa a `externalWorkbook.xlsx` fájlt igényli a munkakönyvtárban. A `Sheet1` nevű munkalapnak B1‑ben kell tartalmaznia egy sorozat nevét, A2:A4‑ben a kategória neveket, és B2:B4‑ben a számértékeket. A példa egy kördiagramot hoz létre, a munkafüzetet összekapcsolja, és a [setRange](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) segítségével az A1:B4 tartományt egy sorozat és három kategória között leképezi. Az eredményt a `Presentation_with_externalWorkbook.pptx` fájlba menti.

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

A [setExternalWorkbook](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) `updateChartData` paramétere szabályozza, hogy a munkafüzet be legyen-e töltve.

* Ha `updateChartData` `false`, akkor csak a munkafüzet útvonalát frissíti. A diagram adatokat nem tölti be vagy frissíti a cél munkafüzetről, így a munkafüzet hiányozhat.
* Ha `updateChartData` `true`, a diagram adatokat a cél munkafüzetről frissíti.

A következő példa egy helyettesítő URL-t rendeli `updateChartData` `false` értékével. Megőrzi a kördiagram alapértelmezett adatait, és a prezentációt úgy menti, hogy a nem elérhető munkafüzetet nem tölti be.

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

### **Diagram külső adatforrás munkafüzete elérési útjának lekérdezése**

A diagramhoz csatolt munkafüzet azonosításához először ellenőrizze, hogy a diagram külső adatforrást használ-e. Ha igen, a következő lépésekkel kérhető le a munkafüzet útvonala.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/java/com.aspose.slides/presentation/) osztályból.
2. Érje el az első diát a nulla-alapú indexével.
3. Ellenőrizze, hogy az első alakzat diagram-e.
4. Olvassa ki a diagram adatforrás típusát.
5. Ha a forrás egy külső munkafüzet, olvassa be az útvonalát.

Ez a példa megnyitja a korábban létrehozott `externalWorkbook.pptx` fájlt, és megvizsgálja az első dián az első alakzatot. Ha ez egy külső munkafüzettel összekapcsolt diagram, a példa a [getExternalWorkbookPath](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) értékét írja ki a konzolra. Ezután a prezentáció egy másolatát a `Result.pptx` fájlba menti.

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

A külső munkafüzetek adatait ugyanúgy szerkesztheti, mint a belső munkafüzetek tartalmát. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

Ez a példa a `presentation.pptx` fájlt igényli, amelynek az első diáján első alakzatként diagramnak kell lennie, valamint egy elérhető külső munkafüzettel. A első sorozat első adatpontjának cella‑alapú értékét 100‑ra állítja, és a prezentációt a `presentation_out.pptx` fájlba menti. A cellaértékek szerkesztése frissítheti a kapcsolt külső XLSX fájlt, ezért használjon másolatot, ha az eredeti munkafüzetet érintetlenül kell hagyni.

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

Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzetet használ, az Aspose.Slides képes rekonstruálni a diagram munkafüzettét a prezentációban gyorsítótárazott adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/) objektumot, hívja meg a [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-) metódust, és állítsa az [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) értékét `true`‑ra, mielőtt megnyitná a prezentációt.

A következő Java példa megnyitja a `presentation.pptx` fájlt, amelynek első diájának első alakzata egy olyan diagram, amely egy nem elérhető külső munkafüzettel hivatkozik, és a helyreállított adatokat a [IChart.getChartData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichart/#getChartData--) és a [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) segítségével érheti el:

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

Ha a külső munkafüzet nem érhető el és a helyreállítás le van tiltva, az Aspose.Slides kivételt dob. A helyreállítást csak akkor engedélyezze, ha a gyorsítótárazott diagramadatok használata elfogadható tartalékmegoldás, mivel a gyorsítótár nem feltétlenül tartalmazza a prezentáció legutóbbi frissítése után a külső munkafüzetben végzett változtatásokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram egy külső vagy beágyazott munkafüzettel van-e összekapcsolva?**

Igen. A diagram rendelkezik egy [data source type](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chartdata/#getDataSourceType--) és egy [path to an external workbook](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) attribútummal; ha a forrás egy külső munkafüzet, akkor kiolvashatja a teljes útvonalat, hogy megbizonyosodjon arról, hogy külső fájlt használnak.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, azt a rendszer automatikusan abszolútra konvertálja. A prezentáció az abszolút útvonalat tárolja a PPTX fájlban, így a munkafüzet áthelyezése esetén előfordulhat, hogy frissíteni kell a hivatkozást.

**Használhatok hálózati erőforrásokon/megosztott helyeken lévő munkafüzeteket?**

Igen, ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides-ból nem támogatott – csak forrásként használhatók.

**Felülírja az Aspose.Slides a külső XLSX-et a prezentáció mentésekor?**

A prezentáció egy [link to the external file](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) hivatkozást tárolja. A cella‑alapú diagramadatok szerkesztése frissítheti a kapcsolt helyi XLSX fájlt is. Használjon a munkafüzet másolatát, ha az eredetit változatlanul kell hagyni.

**Mit tegyek, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad jelszót a kapcsoláskor. Egy gyakori megoldás, hogy előzetesen eltávolítja a védelmet, vagy elkészít egy dekódolt másolatot (például a [Aspose.Cells](https://reference.aspose.com/cells/java/) segítségével), és arra a másolatra hivatkozik.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram a saját hivatkozását tárolja. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagramnál megjelenik a következő adatbetöltéskor.