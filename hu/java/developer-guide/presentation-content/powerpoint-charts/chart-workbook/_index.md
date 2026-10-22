---
title: "Diagram munkafüzetek kezelése prezentációkban Java-val"
linktitle: "Diagram munkafüzet"
type: docs
weight: 70
url: /hu/java/chart-workbook/
keywords:
- "diagram munkafüzet"
- "diagram adat"
- "munkafüzet cella"
- "adatcímke"
- "munkalap"
- "adatforrás"
- "külső munkafüzet"
- "külső adat"
- "diagram gyorsítótár"
- "munkafüzet helyreállítás"
- "PowerPoint"
- "prezentáció"
- "Java"
- "Aspose.Slides"
description: "Fedezze fel az Aspose.Slides for Java programot: könnyedén kezelje a diagram munkafüzeteket a PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse prezentációs adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet a diagrammunkafüzetekkel dolgozni az Aspose.Slides-ben. Megmutatja, hogyan olvashat és írhat diagramadatokat munkafüzet‑áramokon keresztül, hogyan használhatja a munkafüzetcellákat diagramadat‑címkéként, hogyan érheti el a munkalap‑gyűjteményeket, és hogyan adhatja meg az adatforrás típusát a diagramértékekhez.

A cikk továbbá tárgyalja a külső munkafüzetek diagramadat‑forrásként való használatát. A példák bemutatják, hogyan hozhat létre és rendelhet hozzá egy külső munkafüzetet, hogyan szerezheti meg egy diagramhoz kapcsolt külső munkafüzet útvonalát, és hogyan szerkesztheti a diagramadatokat, ha a munkafüzet elérhető.

A hiányzó adatot képviselő munkafüzetcellák esetén lásd az [Az Üres Cellák Megjelenítésének Szabályozása](/slides/hu/java/chart-series/) cikket az üres cella és a nulla közti különbségért, valamint egy vonaldiagram-összehasonlítást a rendelkezésre álló megjelenítési módokról.

## **Adatok belefoglalása rejtett sorokból és oszlopokból**

Használja a [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) metódust annak szabályozására, hogy a diagram rejtett munkalap‑sorokból és -oszlopokból is ábrázolja-e az adatokat. Állítsa `true`‑ra, ha csak a látható cellákat szeretné ábrázolni, vagy `false`‑ra, ha a látható és a rejtett cellákat egyaránt bele akarja foglalni. Ez a beállítás a diagram ábrázolását szabályozza; nem rejti el vagy jeleníti meg a munkalap sorait vagy oszlopait.

A [példa prezentáció](hidden-source-data.pptx) egy oszlopdiagramot tartalmaz első alakzatként az első diáján. A beágyazott munkalap, `Sheet1`, a következő forrás‑tartományt tartalmazza, `A1:C4`. A 3. sor és a C oszlop rejtett, de celláik még mindig értékeket tartalmaznak.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (rejtett sor) | February | 40 | 60 |
| 4 | March | 20 | 50 |

A forráscellák eléréséhez használja az [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) metódust, és olvassa az [IChartDataCell.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#isHidden--) értékét a rejtettség ellenőrzéséhez. Ez a metódus a rejtett állapotot adja vissza módosítás nélkül. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz tartozik, a C2 pedig a rejtett oszlophoz; a példa `false`, `true`, és `true` értékeket ír ki.

Ehhez a példához frissítse a diagram adatát a ábrázolási beállítás módosítása után: tartsa meg a beágyazott munkafüzetet a [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) használatával, és töltse be újra a [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) segítségével. Az összes cella belefoglalásához használja a [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) metódust a teljes tartomány visszaállításához, beleértve a rejtett februári kategóriát is. Csak a jelző megváltoztatása nem elegendő a gyorsítótárban lévő diagramadat és kategória‑címkék frissítéséhez.

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

                // Frissítse a diagram adatát a beágyazott munkafüzetről.
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

A példa két változatban menti a prezentációt: az egyik csak a látható Kiskereskedelem‑értékeket (10 és 20) tartalmazza, a másik az összes hat értéket. Az alábbi képek a két ábrázolási módot szemléltetik. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| Csak látható cellák (`true`) | Minden cella (`false`) |
| --- | --- |
| ![Csak látható cellák: Kiskereskedelmi értékek 10 és 20 januárra és márciusra.](hidden_cells_True.png) | ![Minden cella: Kiskereskedelmi és nagykereskedelmi értékek januárra, februárra és márciusra.](hidden_cells_False.png) |

Egy rejtett, értéket tartalmazó cella különbözik egy üres cellától. Az [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) szabályozza, hogyan jelenjenek meg a hiányzó értékek; nem vonja be vagy zárja ki a rejtett forrásadatokat. Lásd az [Az Üres Cellák Megjelenítésének Szabályozása](/slides/hu/java/chart-series/#control-the-display-of-empty-cells) példát.

## **Diagram adat-tartományának lekérése**

Mielőtt egy meglévő prezentációban módosítaná a munkafüzet adatokat, ellenőrizze a forrás‑tartományokat, hogy megtudja, mely munkalap‑cellákat használja az egyes diagramok. Az [IChartData.getRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getRange--) metódus visszaadja az aktuális adat‑tartományt egy munkalap‑specifikus képlet formájában, például `Sheet1!$A$1:$D$5`. Itt a `Sheet1` a munkalap neve, a `!` elválasztja a cellatartományt, a `$A$1:$D$5` pedig az A1‑től D5‑ig terjedő cellákat jelöli. A dollárjelek abszolút sor‑ és oszlop‑hivatkozásokat jelölnek.

A metódus a jelenlegi tartományt olvassa anélkül, hogy a diagramot vagy a munkafüzetet módosítaná. Ha a diagram nem használ munkafüzetet adatforrásként, `InvalidOperationException`‑t dob. További információkért lásd a [ChartData API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/) oldalt.

Ez a példa megnyit egy prezentációt, és minden dián közvetlenül a diagramokra ellenőrzi a alakzatokat. Kiírja minden diagram nevét és forrás‑tartományát. Ha egy diagram nem használ munkafüzetet, üzenetet jelenít meg, majd a következő diagramra lép.

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

Az Aspose.Slides for Java a [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) és a [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---) metódusokkal lehetővé teszi diagramadat‑munkafüzetek (az Aspose.Cells‑szel szerkesztett diagramadatok) olvasását és írását. **Megjegyzés**: a diagramadatoknak ugyanúgy vagy hasonló struktúrában kell felépülniük, mint a forrás.

Ez a példa egy prezentációt használ, amelynek első diáján az első alakzat egy diagram. Beolvassa a beágyazott munkafüzetet egy bájt‑tömbbe, törli a meglévő sorozatokat és kategóriákat, majd visszairja ugyanazt a munkafüzetet. A módosítások csak memóriában maradnak; a példa nem menti a prezentációt.

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

Amikor egy beágyazott munkafüzetet módosított változattal helyettesít, a diagram megtartja az eredeti sorozat‑ és kategória‑gyűjteményeit. Ez a nem egyezés miatt az [IChart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#validateChartLayout--) hibát dobhat „index‑out‑of‑range”. Törölje a meglévő sorozatokat és kategóriákat, mielőtt visszaírná a frissített munkafüzetet a diagramba. Ez a példa egy diagramot használ, amely az első dián az első alakzat. A megjegyzés jelzi, hol történne a munkafüzet szerkesztése; a futtatható példa visszaírja az eredeti munkafüzetet, és a memóriában ellenőrzi az elrendezést.

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

A gyűjtemények törlése eltávolítja a régi adathivatkozásokat, mielőtt a munkafüzet visszaíródna. Építse újra a szükséges sorozat‑ és kategória‑leképezéseket a frissített munkafüzethez, mielőtt a diagramot használja.

## **Egyéni számformátumok beállítása munkafüzetcellákhoz**

Használja az [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) metódust annak szabályozására, hogyan jelenjenek meg a numerikus értékek egy diagram beágyazott munkafüzetében. Például egy jelentésnek egy konverziós arányt szerethet százalékban, négy tizedesjeggyel, míg egy együtthatót öt tizedesjeggyel megjeleníteni. Tartsa mindkét értéket numerikus formában, hogy továbbra is felhasználható legyen számításokhoz és ábrázoláshoz.

A számformátum csak a megjelenítést változtatja, a tárolt értéket nem. A `0.0000%` formátum a `0.125` értéket `12.5000%`‑ként jeleníti meg; a tárolt szám nem változik `12.5`‑re. Hasonlóan a `0.00000` a `0.1234567`‑et `0.12346`‑ként mutatja, anélkül, hogy a tárolt értéket kerekítené. Ha az egyéni formátum egy üres karakterlánc (`""`), akkor a [getPresetNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--) által visszaadott formátum lesz használva.

Az alábbi példa egy oszlopdiagramot hoz létre, és a cellákat a [getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) segítségével éri el. A 0‑s munkalapon a B2 a konverziós arányt, a C2 az együtthatót tartalmazza. Mindkét cella diagramértékeket szolgáltat. A példa engedélyezi az értékcímkéket, amelyek a forrás formátumára hivatkoznak.

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

A munkafüzetcellák formátumai elkülönülnek a diagram tengelyeire vagy adatcímkéire közvetlenül beállított formátumoktól. Ebben a példában minden címke a forráscellájának értékét jeleníti meg, mert a [setShowValue](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) `true`‑ra van állítva, és a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) is `true`. A prezentáció mentése és újranyitása után a címkék `12.5000%` és `0.12346` értékeket mutatják, ahogyan alább látható. A függőleges tengely saját számformátumot használ, amelyet a [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) `0.00` értékkel állítottunk be, a [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/java/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) pedig `false`.

Egy adatcímkét önállóan formázni úgy lehet, hogy a forrás‑link jelzőjét `false`‑ra állítja, és a [setNumberFormat](https://reference.aspose.com/slides/java/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-)‑vel saját formátumot ad meg. Ez nem változtatja meg a munkafüzetcellák formátumát. Például egy `0.00` formátumú önálló címke az első értéket `0.13`‑ként jeleníti meg, míg a B2 továbbra is `12.5000%`‑t mutat. Lásd a [Chart Data Labels](/slides/hu/java/chart-data-label/#set-percentage-sign-with-chart-data-labels) oldalt a közvetlen címkeformázásról.

Az alábbi kép a mentett prezentáció újranyitása után lett renderelve:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **Munkafüzetcellák használata diagram adatcímkeként**

A munkafüzetcellák szövegét felhasználhatja diagram adatcímkeként.

Ez a példa egy buborékdiagramot ad hozzá alapértelmezett adatokkal egy meglévő prezentáció első diájához. Az első munkalap 0‑ás indexű munkalapján az A10:A12 cellákat használja az első sorozat három első címkéjéhez, engedélyezi a cellákból származó címkéket, és menti a módosított prezentációt.

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

Az [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) metódus a diagrammunkafüzet munkalapjaihoz biztosít hozzáférést. Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és minden munkalap nevét kiírja a konzolra.

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

Sor‑pont értékek tárolhatók közvetlenül numerikus literálokként is. Lásd a [Set Series Values Using Numeric Literals](/slides/hu/java/chart-series/#set-series-values-using-numeric-literals) oldalt egy komplett példa miatt, amely elmenti és beolvassa ezeket. A pontértékek forrás‑típusa különbözik a diagram belső vagy külső munkafüzet‑konfigurációjától; a numerikus literálok használata önmagában nem távolítja el a beágyazott munkafüzetet.

Ez a példa egy 3D oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozatnévhez különböző adatforrásokat állít be. Az első név egy karakterlánc‑literált használ; a második a 0‑ás munkalap C1 celláját. A [DataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/) felsorlat választja ki a forrást minden névhez. A példa a módosított sorozatnevekkel menti a prezentációt.

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

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely egyes diagramokban beágyazható. Használhatja a [getEmbeddedWorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) metódust az [IChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/)‑on együtt a [WorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/workbooktype/) felsorolattal a nem támogatott formátumok felismeréséhez és a diagramok kihagyásához. Ez a példa az első dián lévő alakzatokat ellenőrzi egy meglévő prezentációban, kihagyja a nem‑diagram alakzatokat, és diagnosztikai üzenetet ír ki minden .xlsb beágyazott munkafüzetet tartalmazó diagramhoz.

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

Az Aspose.Slides támogatja a külső munkafüzetek diagramok adatforrásként való használatát.

### **Külső munkafüzet létrehozása**

Használja a [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) és a [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) metódusokat a beágyazott diagrammunkafüzet fájlba exportálásához, majd a diagram külső munkafüzethez való kapcsolásához.

Ez a példa egy alapértelmezett adatokkal rendelkező kördiagramot hoz létre, és exportálja a munkafüzetét. A fájl írása befejeződik, mielőtt a külső munkafüzetet a diagram adatforrásaként beállítaná, majd a kapcsolt prezentációt menti.

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

A [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) metódussal egy külső munkafüzetet rendelhet egy diagram adatforrásaként. Ezzel a metódussal frissítheti a külső munkafüzet elérési útját is (ha az áthelyezésre került).

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem szerkesztheti, továbbra is használhatja őket külső adatforrásként. Ha relatív útvonalat ad meg a külső munkafüzethez, automatikusan teljes útvonallá konvertálja.

Ez a példa egy olyan külső munkafüzetet használ, amelynek a `Sheet1` nevű munkalapja B1‑ben egy sorozatnevet, A2:A4‑ben kategórianéveket és B2:B4‑ben numerikus értékeket tartalmaz. A példa egy kördiagramot hoz létre, kapcsolja a munkafüzetet, és a [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-)‑el az A1:B4 tartományt egy sorozatra és három kategóriára képezi le. A diagrammal menti a prezentációt.

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

A `setExternalWorkbook` [updateChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) paramétere szabályozza, hogy a munkafüzet be legyen‑töltve.

* Ha az `updateChartData` `false`, csak a munkafüzet útvonala frissül. A diagramadatok nem töltődnek be vagy frissülnek a célmunkafüzetről, ezért a munkafüzet hiányozhat.
* Ha az `updateChartData` `true`, a diagramadatok frissülnek a célmunkafüzetről.

Az alábbi példa egy helyettesítő URL‑t ad meg, az `updateChartData` értéke `false`. A kördiagram alapértelmezett adatait megtartja, és a prezentációt úgy menti, hogy a nem elérhető munkafüzetet nem tölti be.

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

### **A diagram külső adatforrás munkafüzetének útvonalának lekérése**

A diagramhoz kapcsolt munkafüzet azonosításához ellenőrizze, hogy a diagram külső adatforrást használ‑e, majd kérje le a munkafüzet útvonalát.

Ez a példa az első dián az első alakzatra vonatkozik egy kapcsolt külső munkafüzetet tartalmazó prezentációban. Ha a diagram külső munkafüzethez kapcsolódik, a példa kiírja a [getExternalWorkbookPath](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) értékét a konzolra, majd ment egy másolatot a prezentációról.

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

A külső munkafüzetek adatait ugyanolyan módon szerkesztheti, ahogy a belső munkafüzetekét. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

Ez a példa egy olyan diagramot használ, amely az első dián az első alakzat, és egy elérhető külső munkafüzethez kapcsolódik. Az első sorozat első adatpontjának cella‑alapú értékét 100‑ra állítja, majd menti a módosított prezentációt. A cellaértékek szerkesztése frissítheti a kapcsolt külső XLSX fájlt, ezért használjon másolatot, ha az eredeti munkafüzetet meg akarja őrizni.

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

Ha egy diagram külső, hiányzó vagy nem elérhető munkafüzetet használ, az Aspose.Slides helyreállíthatja a diagrammunkafüzetet a prezentációban gyorsítótárazott adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/) objektumot, hívja meg a [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-)‑t, és állítsa az [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-)‑t `true`‑ra, mielőtt megnyitná a prezentációt.

Az alábbi Java‑példa helyreállítja egy diagram, az első dián az első alakzat, munkafüzet‑adatait, amely egy nem elérhető külső munkafüzetre hivatkozik. A helyreállított adatokat a [IChart.getChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getChartData--) és a [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) segítségével éri el:

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

Ha a külső munkafüzet nem érhető el, és a helyreállítás le van tiltva, az Aspose.Slides kivételt dob. Engedélyezze a helyreállítást csak akkor, ha a gyorsítótár‑adatok használata elfogadható visszalépés, mivel a gyorsítótár esetleg nem tartalmazza a külső munkafüzetben a prezentáció utolsó mentése után történt változásokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzethez kapcsolódik?**  
Igen. A diagram rendelkezik egy [data source type](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) típusával és egy [path to an external workbook](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) útvonallal; ha a forrás egy külső munkafüzet, a teljes útvonal kiolvasásával ellenőrizhető, hogy külső fájlt használ‑e.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**  
Igen. Ha relatív útvonalat ad meg, azt a rendszer automatikusan abszolút útvonallá alakítja. A prezentáció az abszolút útvonalat tárolja a PPTX fájlban, ezért a munkafüzet áthelyezése esetén frissíteni kell a hivatkozást.

**Használhatók hálózati erőforrásokon vagy megosztásokon lévő munkafüzetek?**  
Igen, ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑el nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja a külső XLSX‑et a prezentáció mentésekor?**  
A prezentáció egy [link to the external file](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) tárol. A cella‑alapú diagramadatok szerkesztése frissítheti a kapcsolt helyi XLSX‑fájlt is. Ha az eredetit változatlanul akarja hagyni, használjon másolatot a munkafüzetről.

**Mi a teendő, ha a külső fájl jelszóval védett?**  
Az Aspose.Slides nem fogad jelszót a kapcsoláskor. Általános megoldás a védelem előzetes eltávolítása vagy egy dekódolt másolat (például az [Aspose.Cells](https://reference.aspose.com/cells/java/)‑szel) elkészítése, majd ennek a másolatnak a linkelése.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**  
Igen. Minden diagram a saját linkjét tárolja. Ha több diagram ugyanarra a fájlra mutat, a fájl frissítése mindegyik diagramnál megjelenik a következő adatbetöltéskor.