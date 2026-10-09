---
title: Kezelje a diagram munkafüzeteit prezentációkban Java használatával
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
description: "Fedezze fel az Aspose.Slides for Java-t: egyszerűen kezelje a diagram munkafüzeteit PowerPoint és OpenDocument formátumokban, hogy optimalizálja prezentációja adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhat a diagram munkafüzetekkel az Aspose.Slides-ban. Megmutatja, hogyan lehet diagramadatokat olvasni és írni munkafüzet‑adatfolyamokon keresztül, hogyan használhatja a munkafüzet celláit diagramcímkeként, hogyan érheti el a munkalap‑gyűjteményeket, és hogyan adhatja meg az adatforrás‑típust a diagram értékeihez.

Továbbá lefedi a külső munkafüzetek diagramadat‑forrásként való használatát. A példák bemutatják, hogyan hozhat létre és rendelhet hozzá egy külső munkafüzetet, hogyan szerezheti meg egy diagramhoz kapcsolt külső munkafüzet elérési útját, és hogyan szerkesztheti a diagramadatokat, ha a munkafüzet elérhető.

A hiányzó adatokat képviselő munkafüzet‑cellákhoz lásd az [Az üres cellák megjelenítésének szabályozása](/slides/hu/java/chart-series/) oldalt, ahol megtalálja a különbséget az üres cella és a nulla között, valamint egy vonaldiagram‑összehasonlítást a rendelkezésre álló megjelenítési módokról.

## **Rejtett sorok és oszlopok adatainak bevonása**

Használja az [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) metódust annak szabályozására, hogy a diagram a rejtett munkalap‑sorokból és -oszlopokból származó adatokat ábrázolja‑e. Állítsa `true`‑ra, ha csak a látható cellákat akarja ábrázolni, vagy `false`‑ra, ha mind a látható, mind a rejtett cellákat bele szeretné foglalni. Ez a beállítás a diagram ábrázolását szabályozza; nem rejt el vagy jelenít meg munkalap‑sorokat vagy -oszlopokat.

A [minta prezentáció](hidden-source-data.pptx) egy oszlopdiagramot tartalmaz, amely az első dián az első alakzat. A beágyazott munkalap, `Sheet1`, a következő forrás‑tartományt tartalmazza, `A1:C4`. A 3. sor és a C oszlop rejtett, de celláik még mindig értéket tartalmaznak.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | január | 10 | 30 |
| 3 (rejtett sor) | február | 40 | 60 |
| 4 | március | 20 | 50 |

A forrás‑cellák eléréséhez használja az [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) metódust, és olvassa az [IChartDataCell.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#isHidden--) értékét a rejtettség ellenőrzéséhez. Ez a metódus a rejtettséget jelentik anélkül, hogy megváltoztatná azt. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz tartozik, a C2 a rejtett oszlophoz; a példa ennek megfelelően `false`, `true`, és `true` értékeket ír ki.

Ehhez a példához a diagramadatok frissítése a rajzolási beállítás módosítása után szükséges: tartsa meg a beágyazott munkafüzetet a [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) metódussal, és töltse be újra a [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) segítségével. Az összes cella bevonásakor használja a [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) metódust a teljes tartomány helyreállításához, beleértve a rejtett februári kategóriát is. Csak a jelző megváltoztatása nem elegendő a minta gyorsítótárazott diagramadatai és kategória‑címkéi frissítéséhez.

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

A példa két verziót ment a prezentációból: egyet, amely csak a látható Kiskereskedelem értékeket (10 és 20) tartalmazza, és egy másikat, amely az összes hat értéket tartalmazza. Az alábbi képek szemléltetik a két ábrázolási módot. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| Csak látható cellák (`true`) | Minden cella (`false`) |
| --- | --- |
| ![Csak látható cellák: Kiskereskedelmi értékek 10 és 20 januárra és márciusra.](hidden_cells_True.png) | ![Minden cella: Kiskereskedelem és Nagykereskedelem értékek januárra, februárra és márciusra.](hidden_cells_False.png) |

Egy rejtett, értéket tartalmazó cella különbözik az üres cellától. Az [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) metódus szabályozza, hogy a hiányzó értékek hogyan jelenjenek meg; nem vonja be vagy zárja ki a rejtett forrásadatokat. Lásd az [Az üres cellák megjelenítésének szabályozása](/slides/hu/java/chart-series/#control-the-display-of-empty-cells) példát.

## **A diagram adat‑tartományának lekérése**

Mielőtt meglévő prezentációban módosítaná a munkafüzet adatokat, ellenőrizze a forrás‑tartományokat, hogy meghatározza, mely munkalap‑cellákat használja az egyes diagramok. Az [IChartData.getRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getRange--) metódus a jelenlegi adat‑tartományt adja vissza munkalap‑kvalifikált képletként, például `Sheet1!$A$1:$D$5`. Itt a `Sheet1` a munkalap neve, a `!` elválasztja a cellatartományt, a `$A$1:$D$5` pedig az A1‑től D5‑ig terjedő cellákat jelöli. A dollárjelek abszolút sor‑ és oszlop‑hivatkozásokat jeleznek.

A metódus a jelenlegi tartományt olvassa anélkül, hogy módosítaná a diagramot vagy annak munkafüzetét. Ha a diagram nem használ munkafüzetet adatforrásként, `InvalidOperationException`‑t dob. További információért lásd a [ChartData API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/) oldalt.

Ez a példa megnyit egy prezentációt, és közvetlenül minden dián ellenőrzi az alakzatokat diagramok után. Kiírja minden diagram nevét és forrás‑tartományát. Ha egy diagram nem használ munkafüzetet, üzenetet jelenít meg, majd a következő diagramra lép.

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

Az Aspose.Slides for Java a [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) és a [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) metódusokat biztosítja, amelyekkel diagramadat‑munkafüzeteket (az Aspose.Cells‑szel szerkesztett diagramadatokat tartalmazó) olvashat és írhat. **Megjegyzés:** a diagramadatoknak ugyanúgy kell felépülniük, vagy hasonló szerkezettel kell rendelkezniük, mint a forrásnak.

Ez a példa egy prezentációt használ, amelynek első diájának első alakzata egy diagram. Beolvassa a beágyazott munkafüzetet bájt‑tömbbe, törli a meglévő sorozatokat és kategóriákat, majd visszaírja ugyanazt a munkafüzetet. A változások memóriában maradnak; a példa nem menti a prezentációt.

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

### **Diagramelrendezés ellenőrzése munkafüzet‑módosítás után**

Ha egy beágyazott munkafüzetet módosított verzióval cserél, a diagram megőrzi az eredeti sorozat‑ és kategória‑gyűjteményeket. Ez a nem‑egyezés az [IChart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#validateChartLayout--) hibáját okozhat „index‑out‑of‑range” kivétellel. Törölje a meglévő sorozatokat és kategóriákat, mielőtt visszaírná a frissített munkafüzetet a diagramra. Ez a példa egy diagramot használ, amely az első diájának első alakzata. A komment jelzi, hol történik a munkafüzet‑szerkesztés; a futtatható példa visszaírja az eredeti munkafüzetet, és memóriában ellenőrzi az elrendezést.

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

A gyűjtemények tisztítása elavult adat‑referenciákat távolít el, mielőtt a munkafüzet visszaírásra kerül. Építse újra a szükséges sorozat‑ és kategória‑leképezéseket a frissített munkafüzethez, mielőtt a diagramot használja.

## **Munkafüzet‑cellát beállítani diagramcímkeként**

A munkafüzet‑cellák szövegét használhatja diagramcímkeként.

Ez a példa egy buborékk diagramot ad hozzá alapértelmezett adatokkal egy meglévő prezentáció első diájához. Az első sorozat első három címkéjéhez a 0‑s indexű munkalap A10:A12 tartományát használja, engedélyezi a cellákból származó címkéket, majd elmenti a frissített prezentációt.

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

Az [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) metódus hozzáférést biztosít a diagram munkafüzetének munkalapjaihoz. Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és kiírja minden munkalap nevét a konzolra.

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

## **Adatforrás‑típus megadása**

Ez a példa egy 3D oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozat‑nevet állít be különböző adatforrásokkal. Az első név egy karakterlánc‑literál; a második a 0‑s indexű munkalap C1 celláját használja. A [DataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/) felsorolás választja ki a forrást minden névhez. A példa elmenti a prezentációt a frissített sorozat‑nevekkel.

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

## **Nem támogatott beágyazott munkafüzet‑formátumok észlelése**

Az Aspose.Slides nem támogatja a néhány diagramhoz beágyazott Excel bináris munkafüzet (.xlsb) formátumot. A [getEmbeddedWorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) metódust a [IChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/)‑on együtt a [WorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/workbooktype/) felsorolással használhatja, hogy észlelje a nem támogatott formátumokat, és kihagyja az érintett diagramokat. Ez a példa ellenőrzi az első dián lévő alakzatokat egy meglévő prezentációban, kihagyja a nem‑diagram alakzatokat, és diagnosztikai üzenetet ír ki minden .xlsb munkafüzetet beágyazott diagramhoz.

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

        // Olvassa vagy módosítsa a támogatott diagram munkafüzeti adatokat itt.
    }
} finally {
    presentation.dispose();
}
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetek diagramok adatforrásként való használatát.

### **Külső munkafüzet létrehozása**

Használja a [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) és a [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) metódusokat egy beágyazott diagram munkafüzete fájlba exportálásához, majd a diagram külső munkafüzettel való összekapcsolásához.

Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és exportálja a munkafüzetet. A fájlírás befejezése után rendeli hozzá a külső munkafüzetet diagram adatforrásként, majd elmenti a kapcsolt prezentációt.

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

A [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) metódus segítségével egy külső munkafüzetet rendelhet diagramhoz adatforrásként. Ezzel a módszerrel frissítheti a külső munkafüzet elérési útját is (ha az áthelyezésre került).

Bár a távoli helyen vagy erőforrásban tárolt munkafüzetek adatainak közvetlen szerkesztése nem támogatott, ezek a munkafüzetek továbbra is felhasználhatók külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzethez, az automatikusan teljes útvonalra konvertálódik.

Ez a példa egy külső munkafüzetet használ, amelynek `Sheet1` nevű munkalapja B1‑ben egy sorozat‑nevet, A2:A4‑ben kategória‑neveket, és B2:B4‑ben numerikus értékeket tartalmaz. A példa egy kördiagramot hoz létre, összekapcsolja a munkafüzetet, és a [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) segítségével az A1:B4 tartományt egy sorozatra és három kategóriára térképezi. Elmenti a prezentációt a kapcsolt diagrammal.

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

* Ha `updateChartData` **false**, csak a munkafüzet útvonala frissül. A diagramadatok nem töltődnek be vagy frissülnek a cél‑munkafüzetről, így a munkafüzet hiányzó is lehet.
* Ha `updateChartData` **true**, a diagramadatok frissülnek a cél‑munkafüzetről.

A következő példa egy helyettesítő URL‑t ad meg `updateChartData` **false** értékkel. A kördiagram alapértelmezett adatait megtartja, és a prezentációt a munkafüzet betöltése nélkül menti.

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

### **Diagram külső adatforrás‑munkafüzete útvonalának lekérése**

A diagramhoz kapcsolt munkafüzet azonosításához ellenőrizze, hogy a diagram külső adatforrást használ‑e, és szerezze be a munkafüzet útvonalát.

Ez a példa az első dián lévő első alakzatot vizsgálja egy külső munkafüzettel összekapcsolt prezentációban. Ha ez egy diagram, amely külső munkafüzettel van összekapcsolva, a példa a [getExternalWorkbookPath](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) értékét írja a konzolra, majd elment egy másolatot a prezentációból.

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

A külső munkafüzettek adatait ugyanúgy szerkesztheti, mint a belső munkafüzetekét. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

Ez a példa egy diagramot használ, amely az első dián lévő első alakzat, és egy elérhető külső munkafüzettel van összekapcsolva. A példában az első sorozat első adatpontjának cella‑alapú értékét 100‑ra állítja, majd elmenti a frissített prezentációt. A cella‑értékek szerkesztése frissítheti a kapcsolt külső XLSX fájlt, ezért másolatot használjon, ha az eredeti munkafüzettet meg akarja őrizni.

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

Ha egy diagram egy hiányzó vagy elérhetetlen külső munkafüzettel dolgozik, az Aspose.Slides képes a diagram munkafüzetét rekonstruálni a prezentációban gyorsítótárazott adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) objektumot, hívja meg a [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-)‑t, és állítsa az [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) értékét **true**‑ra a prezentáció megnyitása előtt.

Az alábbi Java‑példa helyreállítja a munkafüzet‑adatokat egy olyan diagramhoz, amely az első dián lévő első alakzat, és egy elérhetetlen külső munkafüzetre hivatkozik. A helyreállított adatokat a [IChart.getChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getChartData--) és az [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) segítségével éri el:

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

Ha a külső munkafüzet nem érhető el, és a helyreállítás le van tiltva, az Aspose.Slides kivételt dob. Engedélyezze a helyreállítást csak akkor, ha a gyorsítótár‑adatok használata elfogadható visszalépés, mivel a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzet utolsó módosításait a prezentáció legutóbbi frissítése óta.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzettel van‑e összekapcsolva?**

Igen. A diagram rendelkezik egy [data source type](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) és egy [path to an external workbook](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) tulajdonsággal; ha a forrás külső munkafüzet, a teljes útvonal elolvasásával ellenőrizhető, hogy valóban külső fájlt használ‑e.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Relatív útvonal megadása esetén az automatikusan abszolút útvonallá alakul. A prezentáció az abszolút útvonalat tárolja a PPTX‑fájlban, ezért a munkafüzet áthelyezésekor frissíteni kell a hivatkozást.

**Használhatok munkafüzeteket hálózati erőforrásokból/megosztott meghajtókról?**

Igen, az ilyen munkafüzettek használhatók külső adatforrásként. Azonban a távoli munkafüzettek közvetlen szerkesztése az Aspose.Slides‑ból nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja a külső XLSX‑et a prezentáció mentésekor?**

A prezentáció egy [linket tárol a külső fájlra](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--). A cella‑alapú diagramadatok szerkesztése frissítheti a kapcsolt helyi XLSX‑fájlt is. Ha az eredeti munkafüzetet változatlanul kell hagyni, használjon másolatot.

**Mit tegyek, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad jelszót a hivatkozáskor. Általános megoldás, hogy előzetesen eltávolítja a védelmet, vagy egy feloldott másolatot (például az [Aspose.Cells](https://reference.aspose.com/cells/java/)‑kel) készít, majd azt kapcsolja.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram a saját hivatkozását tárolja. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagramra hatással lesz a következő adatbetöltéskor.