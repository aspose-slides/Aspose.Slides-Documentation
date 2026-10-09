---
title: "Kezelje a diagram munkafüzeteket prezentációkban Androidon"
linktitle: "Diagram Munkafüzet"
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
description: "Fedezze fel az Aspose.Slides for Android via Java-t: könnyedén kezelje a diagram munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse prezentációja adatait."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan dolgozhat a diagram munkafüzeteivel az Aspose.Slides segítségével. Bemutatja, hogyan lehet olvasni és írni diagram adatokat munkafüzet‑stream‑eken keresztül, hogyan használhat munkafüzet‑cellákat diagram adatcímkékként, hogyan érheti el a munkalap‑gyűjteményeket, és hogyan adhatja meg az adatforrás típusát a diagram értékeihez.

Emellett tárgyalja a külső munkafüzetekkel való munkát diagram adatforrásként. A példák bemutatják, hogyan hozhat létre és rendelhet hozzá egy külső munkafüzetet, hogyan kérheti le egy diagramhoz kapcsolt külső munkafüzet útvonalát, és hogyan szerkesztheti a diagram adatokat, amikor a munkafüzet elérhető.

A hiányzó adatot képviselő munkafüzet‑cellák esetén lásd a [Az üres cellák megjelenítésének vezérlése](/slides/hu/androidjava/chart-series/) oldalon az üres cella és a nulla közti különbséget, valamint a rendelkezésre álló megjelenítési módok vonaldiagram‑összehasonlítását.

## **Rejtett sorok és oszlopok adatainak felvétele**

Használja az [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) metódust annak szabályozására, hogy egy diagram rejtett munkalap‑sorokból és -oszlopokból is ábrázoljon‑e adatokat. Állítsa `true`‑ra, ha csak a látható cellákat szeretné ábrázolni, vagy `false`‑ra, ha a látható és a rejtett cellákat egyaránt fel szeretné venni. Ez a beállítás a diagram ábrázolását szabályozza; nem rejti el és nem jeleníti meg a munkalap‑sorokat vagy -oszlopokat.

A [minta prezentáció](hidden-source-data.pptx) első diáján az első alakzat egy oszlopdiagram. A beágyazott munkalap, `Sheet1`, a következő forrás‑tartományt tartalmazza: `A1:C4`. A 3. sor és a C oszlop rejtett, de celláik továbbra is tartalmaznak értékeket.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | Január | 10 | 30 |
| 3 (rejtett sor) | Február | 40 | 60 |
| 4 | Március | 20 | 50 |

A forrás‑cellákhoz a [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) segítségével férhet hozzá, és a [IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) metódussal ellenőrizheti a rejtett állapotukat. Ez a módszer a rejtett állapotot jelzi anélkül, hogy módosítaná azt. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz tartozik, a C2 pedig a rejtett oszlophoz; a példa ennek megfelelően `false`, `true`, és `true` értékeket ír ki.

Ehhez a példához frissítse a diagram adatokat a ábrázolási beállítás módosítása után: tartsa meg a beágyazott munkafüzetet a [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) segítségével, és töltse be újra a [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) segítségével. Az összes cella felvételéhez használja a [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) metódust a rejtett februári kategória is beleértve a teljes tartomány visszaállításához. A zászló egyszerű módosítása nem elegendő a mintában gyorsítótárazott diagram adat és kategória címkék frissítéséhez.

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
                // Állítsa vissza a teljes forrás‑tartományt, beleértve a rejtett kategóriákat.
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

A példa két változatban menti a prezentációt: az egyik csak a látható Kiskereskedelem értékekkel (10 és 20), a másik mind a hat értékkel. Az alábbi képek a két ábrázolási módot szemléltetik. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| Csak látható cellák (`true`) | Minden cella (`false`) |
| --- | --- |
| ![Csak látható cellák: Kiskereskedelem értékek 10 és 20 januárra és márciusra.](hidden_cells_True.png) | ![Minden cella: Kiskereskedelem és Nagykereskedelem értékek januárra, februárra és márciusra.](hidden_cells_False.png) |

A rejtett, értéket tartalmazó cella különbözik egy üres cellától. Az [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) szabályozza, hogy a hiányzó értékek hogyan jelenjenek meg; nem vonja be vagy zárja ki a rejtett forrásadatokat. Lásd a [Az üres cellák megjelenítésének vezérlése](/slides/hu/androidjava/chart-series/#control-the-display-of-empty-cells) példát.

## **Diagram adat‑tartományának lekérése**

Mielőtt frissítené a munkafüzet adatokat egy meglévő prezentációban, vizsgálja meg a forrás‑tartományokat, hogy azonosítsa, mely munkalap‑cellákat használja az egyes diagramok. Az [IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--) metódus visszaadja az aktuális adat‑tartományt munkalap‑kvalifikált képletként, például `Sheet1!$A$1:$D$5`. Itt a `Sheet1` a munkalap neve, az `!` választja el a cellatartománytól, a `$A$1:$D$5` pedig az A1‑től D5‑ig terjedő cellákat jelöli. A dollárjelek abszolút sor‑ és oszlophivatkozásokat jelentenek.

A metódus a jelenlegi tartományt olvassa anélkül, hogy módosítaná a diagramot vagy annak munkafüzetét. Ha a diagram nem használ munkafüzetet adatforrásként, `InvalidOperationException`‑t dob. További információkért lásd a [ChartData API Referencia](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/) oldalt.

Ez a példa megnyit egy prezentációt, és minden dián közvetlenül ellenőrzi az alakzatokat diagramok után. Kiírja minden diagram nevét és forrás‑tartományát. Ha egy diagram nem használ munkafüzetet, üzenetet ír ki, és a következő diagramra lép.

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

## **Diagram adatainak olvasása és írása munkafüzetből**

Az Aspose.Slides for Android via Java biztosítja a [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) és a [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) metódusokat, amelyekkel diagram adat‑munkafüzeteket (az Aspose.Cells‑el szerkesztett diagram adatokat) olvashat és írhat. **Megjegyzés**: a diagram adatokat ugyanúgy kell szervezni, vagy hasonló szerkezetűnek kell lenniük, mint a forrás.

Ez a példa egy prezentációt használ, amelynek első diáján első alakzatként egy diagram található. A beágyazott munkafüzetet bájttömbbe olvassa, törli a meglévő sorozatokat és kategóriákat, majd visszaírja ugyanazt a munkafüzetet. A módosítások memóriában maradnak; a példa nem menti a prezentációt.

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

Ha egy beágyazott munkafüzetet egy módosított példánnyal helyettesít, a diagram a saját eredeti sorozat‑ és kategória‑gyűjteményeit megtartja. Ez a nem egyezés a [IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) metódus hibájához vezethet, amikor index‑out‑of‑range hiba lép fel. Törölje a meglévő sorozatokat és kategóriákat, mielőtt visszaírná a frissített munkafüzetet a diagramba. Ez a példa egy diagramot használ, amely az első diáján az első alakzat. A megjegyzés jelöli, hol történne a munkafüzet‑szerkesztés; a futtatható példa visszaírja az eredeti munkafüzetet, és a memóriában ellenőrzi az elrendezést.

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

        // Módosítsa a munkafüzet bájtokat itt, például az Aspose.Cells használatával.

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

A gyűjtemények törlése megszünteti a rég elavult adat‑hivatkozásokat, mielőtt a munkafüzet vissza lenne írva. Építse újra a szükséges sorozat‑ és kategória‑leképezéseket a frissített munkafüzethez, mielőtt a diagramot használná.

## **Munkafüzet cellájának beállítása diagram adatcímkeként**

A munkafüzet celláiból származó szöveget használhatja diagram adatcímkeként.

Ez a példa egy buborékdiagramot ad hozzá alapértelmezett adatokkal egy meglévő prezentáció első diájához. Az első sorozat első három címkéjéhez a 0‑s indexű munkalap A10:A12 tartományát használja, engedélyezi a cellákból származó címkéket, és menti a frissített prezentációt.

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

Az [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) metódus hozzáférést biztosít a diagram munkafüzetének munkalapjaihoz. Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és minden munkalap nevét a konzolra írja.

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

Ez a példa egy 3D oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozat‑nevet állít be különböző adatforrásokból. Az első nevet karakterlánc‑literálként adja meg; a második a 0‑s indexű munkalap C1 celláját használja. A [DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) felsorolás választja ki a forrást minden egyes névhez. A példa a módosított sorozat‑nevekkel menti a prezentációt.

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

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely bizonyos diagramokban beágyazható. A [getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) metódust az [IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/)‑nél a [WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/) felsorolással együtt használhatja a nem támogatott formátumok felismerésére és az adott diagramok kihagyására. Ez a példa az első dián lévő alakzatokat ellenőrzi, kihagyja a diagram‑től eltérő alakzatokat, és diagnosztikai üzenetet ír ki minden .xlsb beágyazott munkafüzettel rendelkező diagramhoz.

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

Az Aspose.Slides támogatja külső munkafüzeteinek diagram adatforrásként való használatát.

### **Külső munkafüzet létrehozása**

Használja a [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) és a [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) metódusokat egy beágyazott diagram munkafüzete fájlba exportálásához, majd a diagramot ehhez a külső munkafüzethez linkeli.

Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és exportálja a munkafüzetét. A fájlírást befejezi, mielőtt a külső munkafüzetet diagram adatforrásként hozzárendelné, majd menti a linkelt prezentációt.

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

A [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) metódussal egy külső munkafüzettel rendelhet hozzá egy diagramot adatforrásként. Ezzel a metódussal a külső munkafüzet útvonalát is frissítheti (ha az áthelyezésre került).

Miközben a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem szerkesztheti, továbbra is használhatja ezeket a munkafüzeteket külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzethez, azt automatikusan átalakítja teljes útvonallá.

Ez a példa egy olyan külső munkafüzettet használ, amelynek `Sheet1` nevű munkalapja B1‑ben egy sorozat‑nevet, A2:A4‑ben kategória‑neveket, és B2:B4‑ben numerikus értékeket tartalmaz. A példa egy kördiagramot hoz létre, linkeli a munkafüzetet, és a [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) segítségével A1:B4‑et leképezi egy sorozatra és három kategóriára. A linkelt diagrammal menti a prezentációt.

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

* Ha az `updateChartData` `false`, csak a munkafüzet útvonalát frissíti. A diagram adata nem töltődik be vagy frissül a cél‑munkafüzetről, így a munkafüzet hiányozhat.
* Ha az `updateChartData` `true`, a diagram adatai frissülnek a cél‑munkafüzetről.

A következő példa egy helyettesítő URL‑t rendeli hozzá `updateChartData` értékét `false`‑ra állítva. A kördiagram alapértelmezett adatait megtartja, és a prezentációt úgy menti, hogy a nem elérhető munkafüzetet nem tölti be.

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

### **A diagram külső adatforrás munkafüzet útvonalának lekérése**

A diagramhoz kapcsolt munkafüzet azonosításához ellenőrizze, hogy a diagram külső adatforrást használ‑e, és kérje le a munkafüzet útvonalát.

Ez a példa az első dián az első alakzatot vizsgálja egy linkelt külső munkafüzettel rendelkező prezentációban. Ha ez egy külső munkafüzettel linkelt diagram, a példa a [getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) értékét a konzolra írja. Ezután a prezentáció egy másolatát menti.

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

A külső munkafüzettek adatait ugyanúgy szerkesztheti, ahogy a belső munkafüzettek tartalmát módosítaná. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

Ez a példa egy olyan diagramot használ, amely az első dián az első alakzat, és egy elérhető külső munkafüzettel van linkelve. A első sorozat első adatpontjának cella‑alapú értékét 100‑ra állítja, és menti a frissített prezentációt. A cellaértékek szerkesztése frissítheti a linkelt külső XLSX‑fájlt, ezért használjon másolatot, ha az eredeti munkafüzetet meg akarja őrizni.

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

### **Munkafüzet visszaállítása a diagram gyorsítótárából**

Ha egy diagram külső, hiányzó vagy elérhetetlen munkafüzettel dolgozik, az Aspose.Slides képes a prezentációban gyorsítótárazott adatokból rekonstruálni a diagram munkafüzettét. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/) objektumot, hívja meg a [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-)‑t, és állítsa az [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) értékét `true`‑ra a prezentáció megnyitása előtt.

Az alábbi Java‑példa helyreállítja a munkafüzet‑adatokat egy olyan diagramhoz, amely az első dián az első alakzat, és egy nem elérhető külső munkafüzetre hivatkozik. A helyreállított adatokat a [IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) és a [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) segítségével érheti el:

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

Ha a külső munkafüzet nem érhető el, és a helyreállítás ki van kapcsolva, az Aspose.Slides kivételt dob. A helyreállítást csak akkor engedélyezze, ha a gyorsítótárazott diagramadatok használata elfogadható alternatíva, mivel a gyorsítótár nem feltétlenül tartalmazza az azon a munkafüzetről készült változtatásokat, amelyek a prezentáció legutóbbi frissítése után történtek.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzettel van‑e összekapcsolva?**

Igen. A diagram rendelkezik egy [data source type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) és egy [path to an external workbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) attribútummal; ha a forrás egy külső munkafüzet, leolvasható a teljes útvonal a biztosításhoz, hogy külső fájlt használ.

**Támogatottak-e a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, azt a rendszer automatikusan abszolút útvonalra konvertálja. A prezentáció az abszolút útvonalat a PPTX‑fájlban tárolja, ezért a munkafüzet áthelyezése esetén a link frissítése szükséges lehet.

**Használhatók‑e hálózati erőforrásokon/megosztásokon lévő munkafüzetek?**

Igen, az ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzeteink közvetlen szerkesztése az Aspose.Slides‑ből nem támogatott – csak forrásként használhatók.

**Felülírja‑e az Aspose.Slides a külső XLSX‑et a prezentáció mentésekor?**

A prezentáció egy [link to the external file](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) tárol. A cella‑alapú diagramadatok szerkesztése frissítheti a kapcsolt helyi XLSX‑fájlt is. Használjon másolatot a munkafüzetről, ha az eredetit változatlanul kívánja tartani.

**Mit tegyek, ha a külső fájl jelszóval van védve?**

Az Aspose.Slides nem fogad el jelszót a linkeléskor. Általános megoldás a védelem előzetes eltávolítása vagy egy dekódolt másolat előkészítése (például az [Aspose.Cells](https://reference.aspose.com/cells/java/) segítségével), majd a másolatra való hivatkozás.

**Több diagram is hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram saját linket tárol. Ha mind ugyanarra a fájlra mutatnak, a fájl frissítése minden diagramon megjelenik a következő adatbetöltéskor.