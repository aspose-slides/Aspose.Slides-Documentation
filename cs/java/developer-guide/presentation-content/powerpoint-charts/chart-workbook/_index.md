---
title: Správa sešitů grafů v prezentacích pomocí Javy
linktitle: Sešit grafu
type: docs
weight: 70
url: /cs/java/chart-workbook/
keywords:
- sešit grafu
- data grafu
- buňka sešitu
- popisek dat
- list
- zdroj dat
- externí sešit
- externí data
- keš grafu
- obnovení sešitu
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Objevte Aspose.Slides pro Javu: snadno spravujte sešity grafů v PowerPoint a OpenDocument formátech a zefektivněte data své prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s sešity grafů v Aspose.Slides. Ukazuje, jak číst a zapisovat data grafu pomocí streamů sešitu, používat buňky sešitu jako popisky dat grafu, přistupovat ke kolekcím listů a specifikovat typ zdroje dat pro hodnoty grafu.

Také se zabývá prací s externími sešity jako zdroji dat grafu. Příklady ukazují, jak vytvořit a přiřadit externí sešit, získat cestu k externímu sešitu propojenému s grafem a upravit data grafu, když je sešit k dispozici.

Pro buňky sešitu, které představují chybějící data, viz [Control the Display of Empty Cells](/slides/cs/java/chart-series/) pro rozdíl mezi prázdnou buňkou a nulou a porovnání čárových grafů dostupných režimů zobrazení.

## **Zahrnout data ze skrytých řádků a sloupců**

Použijte [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) k ovládání, zda graf vykresluje data ze skrytých řádků a sloupců listu. Nastavte jej na `true`, aby se vykreslovaly pouze viditelné buňky, nebo na `false`, aby se zahrnovaly jak viditelné, tak skryté buňky. Toto nastavení řídí vykreslování grafu; nezkryje ani neodkryje řádky ani sloupce listu.

Stáhněte [hidden-source-data.pptx](hidden-source-data.pptx) a umístěte jej do pracovního adresáře. Jeho první snímek obsahuje sloupcový graf jako první tvar. Vložený list, `Sheet1`, obsahuje následující zdrojový rozsah `A1:C4`. Řádek 3 a sloupec C jsou skryté, ale jejich buňky stále obsahují hodnoty.

| Řádek listu | A: Měsíc | B: Maloobchod | C: Velkoobchod (skrytý sloupec) |
| --- | --- | --- | --- |
| 2 | Leden | 10 | 30 |
| 3 (skrytý řádek) | Únor | 40 | 60 |
| 4 | Březen | 20 | 50 |

Přístup ke zdrojovým buňkám získáte pomocí [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) a přečtěte [IChartDataCell.isHidden](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdatacell/#isHidden--) pro kontrolu jejich skrytého stavu. Tato metoda hlásí skrytý stav, aniž by jej měnila. V tomto souboru je B2 viditelný, B3 patří ke skrytému řádku a C2 patří ke skrytému sloupci; příklad vytiskne `false`, `true` a `true`.

Pro tento příklad obnovte data grafu po změně nastavení vykreslování: zachovejte vložený sešit pomocí [readWorkbookStream](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdata/#readWorkbookStream--) a načtěte jej znovu pomocí [writeWorkbookStream](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-). Při zahrnutí všech buněk také použijte [setRange](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) k obnovení kompletního rozsahu, včetně skryté kategorie únor. Pouhé změnění příznaku není dostačující k obnově keší dat grafu a popisků kategorií v tomto vzorku.

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

            // Obnovit data grafu z vloženého sešitu.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Obnovit kompletní zdrojový rozsah, včetně skrytých kategorií.
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

Příklad uloží `hidden_cells_true.pptx` pouze s viditelnými hodnotami maloobchodu (10 a 20) a `hidden_cells_false.pptx` se všemi šesti hodnotami. Obrázky níže ilustrují dva režimy vykreslování. Řádek 3 a sloupec C zůstávají ve obou vložených sešitech skryté.

| Pouze viditelné buňky (`true`) | Všechny buňky (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

Skrytá buňka obsahující hodnotu se liší od prázdné buňky. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) řídí, jak jsou zobrazovány chybějící hodnoty; neinkluzuje ani nevyřazuje skryté zdrojové data. Viz [Control the Display of Empty Cells](/slides/cs/java/chart-series/#control-the-display-of-empty-cells) pro příklad.

## **Čtení a zápis dat grafu ze sešitu**

Aspose.Slides pro Java poskytuje metody [readWorkbookStream](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdata/#readWorkbookStream--) a [writeWorkbookStream](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte:A-) , které umožňují číst a zapisovat sešity dat grafu (obsahující data grafu upravená pomocí Aspose.Cells). **Poznámka**: data grafu musí být uspořádána stejným způsobem nebo mít strukturu podobnou zdroji.

Tento příklad otevírá `chart.pptx`, který musí obsahovat graf jako první tvar na svém prvním snímku. Přečte vložený sešit do pole bajtů, vymaže existující řady a kategorie a zapíše stejný sešit zpět. Změny zůstávají v paměti; příklad neukládá prezentaci.

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

### **Ověřit rozvržení grafu po úpravě sešitu**

Když nahradíte vložený sešit modifikovaným, graf si ponechá své původní kolekce řad a kategorií. Tento nesoulad může způsobit selhání [IChart.validateChartLayout](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichart/#validateChartLayout--) s chybou indexu mimo rozsah. Vymažte existující řady a kategorie před zápisem aktualizovaného sešitu zpět do grafu. Tento příklad vyžaduje `chart.pptx` s grafem jako první tvar na prvním snímku. Komentář označuje místo, kde by se úprava sešitu měla provést; spustitelný příklad zapíše zpět původní sešit a ověří rozvržení v paměti.

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

        // Upravte bajty sešitu zde, například pomocí Aspose.Cells.

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

Vymazání kolekcí odstraní zastaralé odkazy na data před zápisem sešitu zpět. Před použitím grafu znovu vytvořte potřebné mapování řad a kategorií pro aktualizovaný sešit.

## **Nastavit buňku sešitu jako popisek dat grafu**

Můžete použít text z buněk sešitu jako popisky dat grafu. Následující kroky ukazují, jak propojit popisky v bublinovém grafu s buňkami v jeho datovém sešitu.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Přistupte k prvnímu snímku pomocí nulového indexu.
3. Přidejte bublinový graf s výchozími daty.
4. Přistupte k řadám grafu.
5. Nastavte buňku sešitu jako popisek dat.
6. Uložte prezentaci.

Tento příklad otevírá `chart2.pptx`, který musí obsahovat alespoň jeden snímek, a přidá bublinový graf s výchozími daty. Používá buňky A10:A12 na listu 0 pro první tři popisky v první řadě, povolí popisky z buněk a uloží výsledek do `resultchart.pptx`.

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

## **Spravovat listy**

Metoda [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) poskytuje přístup k listům v sešitu grafu. Tento příklad vytvoří koláčový graf s výchozími daty a vypíše každé jméno listu na konzoli.

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

## **Specifikovat typ zdroje dat**

Tento příklad vytvoří 3D sloupcový graf s výchozími daty a nastaví dva názvy řad pomocí různých zdrojů dat. První název používá řetězcový literál; druhý používá buňku C1 na listu 0. Výčtový typ [DataSourceType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/datasourcetype/) vybírá zdroj pro každý název. Výsledek je uložen do `pres.pptx`.

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

## **Detekovat nepodporované formáty vložených sešitů**

Aspose.Slides nepodporuje binární formát Excelu (.xlsb), který může být vložen v některých grafech. Můžete použít metodu [getEmbeddedWorkbookType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) na [IChartData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdata/) spolu s výčtem [WorkbookType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/workbooktype/) k detekci nepodporovaných formátů a přeskakování těchto grafů. Tento příklad prozkoumá tvary na prvním snímku `sample.pptx`, přeskočí tvary, které nejsou grafy, a vypíše diagnostickou zprávu pro každý graf s vloženým sešitem .xlsb.

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

        // Prečtěte nebo upravte podporovaná data sešitu grafu zde.
    }
} finally {
    presentation.dispose();
}
```

## **Externí sešit**

Aspose.Slides podporuje používání externích sešitů jako zdroj dat pro grafy.

### **Vytvořit externí sešit**

Použijte [readWorkbookStream](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdata/#readWorkbookStream--) a [setExternalWorkbook](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) k exportu vloženého sešitu grafu do souboru a propojení grafu s tímto externím sešitem.

Tento příklad vytvoří koláčový graf s výchozími daty, zapíše jeho sešit do `externalWorkbook1.xlsx` a dokončí zápis souboru před přiřazením souboru jako zdroj dat grafu. Uloží spojenou prezentaci do `externalWorkbook.pptx`.

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

### **Nastavit externí sešit**

Pomocí metody [setExternalWorkbook](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) můžete přiřadit externí sešit grafu jako jeho zdroj dat. Tato metoda může být také použita k aktualizaci cesty k externímu sešitu (pokud byl přesunut).

I když nemůžete upravovat data v sešitech uložených na vzdálených místech nebo zdrojích, můžete takové sešity stále použít jako externí zdroj dat. Pokud je zadána relativní cesta k externímu sešitu, automaticky se převádí na úplnou cestu.

Tento příklad vyžaduje `externalWorkbook.xlsx` v pracovním adresáři. Jeho list s názvem `Sheet1` musí obsahovat název řady v B1, názvy kategorií v A2:A4 a číselné hodnoty v B2:B4. Příklad vytvoří koláčový graf, propojí sešit a použije [setRange](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) k mapování A1:B4 na jednu řadu a tři kategorie. Uloží výsledek do `Presentation_with_externalWorkbook.pptx`.

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

Parametr `updateChartData` metody [setExternalWorkbook](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) určuje, zda je sešit načten.

* Když je `updateChartData` nastaveno na `false`, aktualizuje se pouze cesta k sešitu. Data grafu nejsou načtena ani aktualizována ze cílového sešitu, takže sešit může být nedostupný.
* Když je `updateChartData` nastaveno na `true`, data grafu jsou aktualizována ze cílového sešitu.

Následující příklad přiřadí zástupnou URL s `updateChartData` nastaveným na `false`. Zachová výchozí data koláčového grafu a uloží prezentaci, aniž by načetl nedostupný sešit.

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

### **Získat cestu k externímu sešitu zdroje dat grafu**

Pro určení sešitu propojeného s grafem nejprve zkontrolujte, zda graf používá externí zdroj dat. Pokud ano, můžete získat cestu k sešitu podle následujících kroků.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/).
2. Přistupte k prvnímu snímku pomocí nulového indexu.
3. Zkontrolujte, že první tvar je graf.
4. Přečtěte typ zdroje dat grafu.
5. Pokud je zdroj externí sešit, načtěte jeho cestu.

Tento příklad otevírá `externalWorkbook.pptx`, vytvořený v předchozím příkladu, a prozkoumá první tvar na prvním snímku. Pokud je to graf propojený s externím sešitem, příklad vypíše [getExternalWorkbookPath](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) na konzoli. Poté uloží kopii prezentace do `Result.pptx`.

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

### **Upravit data grafu**

Můžete upravovat data v externích sešitech stejným způsobem, jako provádíte změny v obsahu interních sešitů. Když není externí sešit načten, je vyvolána výjimka.

Tento příklad vyžaduje `presentation.pptx` s grafem jako první tvar na prvním snímku a přístupný externí sešit. Nastaví hodnotu první datové bodu v první řadě na 100 a uloží prezentaci do `presentation_out.pptx`. Úprava hodnot buněk může aktualizovat propojený externí soubor XLSX, proto použijte kopii, pokud potřebujete zachovat původní sešit.

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

### **Obnovit sešit z keše grafu**

Pokud graf používá externí sešit, který chybí nebo není dostupný, Aspose.Slides může rekonstruovat sešit grafu z dat uložených v keši prezentace. Vytvořte [LoadOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/), zavolejte [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), a nastavte [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) na `true` před otevřením prezentace.

Následující Java příklad otevírá `presentation.pptx`, jehož první tvar na prvním snímku musí být graf odkazující na nedostupný externí sešit, a přistupuje k obnoveným datům pomocí [IChart.getChartData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichart/#getChartData--) a [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

        // Přečtěte nebo upravte zde data obnoveného sešitu.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Pokud je externí sešit nedostupný a obnovení je vypnuto, Aspose.Slides vyhodí výjimku. Povolit obnovu jen tehdy, když je použití kešovaných dat grafu přijatelnou zálohou, protože keš nemusí obsahovat změny provedené v externím sešitu po poslední aktualizaci prezentace.

## **Často kladené otázky**

**Mohu zjistit, zda je konkrétní graf propojen s externím nebo vloženým sešitem?**

Ano. Graf má [typ zdroje dat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/chartdata/#getDataSourceType--) a [cestu k externímu sešitu](https://reference.aspose.com/slides/cs/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); pokud je zdroj externí sešit, můžete přečíst úplnou cestu a ověřit, že je použit externí soubor.

**Jsou relativní cesty k externím sešitům podporovány a jak jsou uloženy?**

Ano. Pokud zadáte relativní cestu, automaticky se převede na absolutní cestu. Prezentace ukládá absolutní cestu v souboru PPTX, takže přesunutí sešitu může vyžadovat aktualizaci odkazu.

**Mohu používat sešity umístěné na síťových zdrojích/úložištích?**

Ano, takové sešity mohou být použity jako externí zdroj dat. Úpravy vzdálených sešitů přímo z Aspose.Slides však nejsou podporovány – mohou být použity jen jako zdroj.

**Přepisuje Aspose.Slides externí XLSX při ukládání prezentace?**

Prezentace ukládá [odkaz na externí soubor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Úprava dat grafu založených na buňkách může také aktualizovat propojený lokální soubor XLSX. Použijte kopii sešitu, pokud originál musí zůstat beze změny.

**Co mám dělat, pokud je externí soubor chráněn heslem?**

Aspose.Slides nepřijímá heslo při propojování. Běžný postup je odstranit ochranu předem nebo připravit dešifrovanou kopii (např. pomocí [Aspose.Cells](https://reference.aspose.com/cells/java/)) a odkazovat na tuto kopii.

**Může více grafů odkazovat na stejný externí sešit?**

Ano. Každý graf ukládá vlastní odkaz. Pokud všechny ukazují na stejný soubor, aktualizace tohoto souboru se projeví v každém grafu při dalším načtení dat.