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
- obnova sešitu
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Objevte Aspose.Slides pro Javu: snadno spravujte sešity grafů v formátech PowerPoint a OpenDocument a optimalizujte data své prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s sešity grafů v Aspose.Slides. Ukazuje, jak číst a zapisovat data grafu prostřednictvím streamů sešitu, používat buňky sešitu jako popisky dat grafu, přistupovat k kolekcím listů a určovat typ zdroje dat pro hodnoty grafu.

Také se zabývá prací s externími sešity jako zdrojmi dat pro grafy. Příklady ukazují, jak vytvořit a přiřadit externí sešit, získat cestu k externímu sešitu propojenému s grafem a upravit data grafu, když je sešit k dispozici.

Pro buňky sešitu, které představují chybějící data, viz [Ovládání zobrazení prázdných buněk](/slides/cs/java/chart-series/) pro rozdíl mezi prázdnou buňkou a nulou a srovnání čárového grafu dostupných režimů zobrazení.

## **Zahrnout data ze skrytých řádků a sloupců**

Použijte [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) k ovládání, zda graf vykresluje data ze skrytých řádků a sloupců listu. Nastavte jej na `true`, aby se vykreslovaly pouze viditelné buňky, nebo na `false`, aby se zahrnovaly jak viditelné, tak skryté buňky. Toto nastavení řídí vykreslování grafu; nezkryje ani neodkryje řádky nebo sloupce listu.

Ukázková prezentace ([ukázková prezentace](hidden-source-data.pptx)) obsahuje sloupcový graf jako první objekt na první snímku. Vložený list, `Sheet1`, obsahuje následující zdrojový rozsah, `A1:C4`. Řádek 3 a sloupec C jsou skryté, ale jejich buňky stále obsahují hodnoty.

| Řádek listu | A: Měsíc | B: Maloobchod | C: Velkoobchod (skrytý sloupec) |
| --- | --- | --- | --- |
| 2 | Leden | 10 | 30 |
| 3 (skrytý řádek) | Únor | 40 | 60 |
| 4 | Březen | 20 | 50 |

Přístup ke zdrojovým buňkám získáte pomocí [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) a přečtěte [IChartDataCell.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatacell/#isHidden--) pro kontrolu jejich skrytého stavu. Tato metoda vrací skrytý stav bez jeho změny. V tomto souboru je B2 viditelný, B3 patří ke skrytému řádku a C2 ke skrytému sloupci; příklad vytiskne `false`, `true` a `true`.

Pro tento příklad obnovte data grafu po změně nastavení vykreslování: zachovejte vložený sešit pomocí [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) a načtěte jej znovu pomocí [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---). Při zahrnutí všech buněk také použijte [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) k obnovení kompletního rozsahu, včetně skryté kategorie únor. Pouhé změnění příznaku není dostačující k obnovení kešovaných dat grafu a popisků kategorií v tomto příkladu.

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

Příklad uloží dvě verze prezentace: jednu pouze s viditelnými hodnotami Maloobchodu (10 a 20) a druhou se všemi šesti hodnotami. Obrázky níže ilustrují dva režimy vykreslování. Řádek 3 a sloupec C zůstávají skryté v obou vložených sešitech.

| Pouze viditelné buňky (`true`) | Všechny buňky (`false`) |
| --- | --- |
| ![Pouze viditelné buňky: Hodnoty Maloobchodu 10 a 20 pro Leden a Březen.](hidden_cells_True.png) | ![Všechny buňky: Hodnoty Maloobchodu a Velkoobchodu pro Leden, Únor a Březen.](hidden_cells_False.png) |

Skrytá buňka obsahující hodnotu se liší od prázdné buňky. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) určuje, jak se zobrazují chybějící hodnoty; neumožňuje zahrnout nebo vyloučit skryté zdrojové data. Viz [Ovládání zobrazení prázdných buněk](/slides/cs/java/chart-series/#control-the-display-of-empty-cells) pro příklad.

## **Získat datový rozsah grafu**

Před aktualizací dat sešitu v existující prezentaci prověřte zdrojové rozsahy, abyste určili, které buňky listu používá každý graf. Metoda [IChartData.getRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getRange--) vrací aktuální datový rozsah jako vzorec kvalifikovaný listem, např. `Sheet1!$A$1:$D$5`. Zde `Sheet1` je název listu, `!` jej odděluje od rozsahu buněk a `$A$1:$D$5` určuje buňky A1 až D5 včetně. Symboly `$` označují absolutní odkazy na řádky a sloupce.

Metoda přečte aktuální rozsah, aniž by měnila graf nebo jeho sešit. Pokud graf nepoužívá sešit jako zdroj dat, vyvolá `InvalidOperationException`. Další informace naleznete v [ChartData API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/).

Tento příklad otevře prezentaci a kontroluje objekty přímo na každém slidu, aby našel grafy. Vytiskne název každého grafu a jeho zdrojový rozsah. Pokud graf nepoužívá sešit, vytiskne zprávu a pokračuje k dalšímu grafu.

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

## **Číst a zapisovat data grafu ze sešitu**

Aspose.Slides pro Java poskytuje metody [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) a [writeWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---), které umožňují číst a zapisovat sešity dat grafu (obsahující data grafu upravená pomocí Aspose.Cells). **Poznámka**: data grafu musí být uspořádána stejným způsobem nebo mít podobnou strukturu jako zdroj.

Tento příklad používá prezentaci s grafem jako první objekt na první snímek. Přečte vložený sešit do pole bajtů, vymaže existující řady a kategorie a zapíše stejný sešit zpět. Změny zůstávají v paměti; příklad neukládá prezentaci.

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

### **Ověřit rozložení grafu po úpravě sešitu**

Když nahradíte vložený sešit upraveným, graf si zachová své původní kolekce řad a kategorií. Tento nesoulad může způsobit selhání [IChart.validateChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#validateChartLayout--) s chybou indexu mimo rozsah. Vymažte existující řady a kategorie před zápisem aktualizovaného sešitu zpět do grafu. Tento příklad používá graf jako první objekt na první snímek. Komentář označuje místo, kde by se úprava sešitu měla provést; spustitelný příklad zapíše původní sešit zpět a ověří rozložení v paměti.

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

Vymazání kolekcí odstraní zastaralé odkazy na data před zápisem sešitu zpět. Před použitím grafu obnovte potřebné mapování řad a kategorií pro aktualizovaný sešit.

## **Nastavit buňku sešitu jako popisek dat grafu**

Můžete použít text z buněk sešitu jako popisky dat grafu.

Tento příklad přidá bublinkový graf s výchozími daty na první snímek existující prezentace. Použije buňky A10:A12 na listu 0 pro první tři popisky v první řadě, povolí popisky z buněk a uloží aktualizovanou prezentaci.

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

Metoda [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdataworkbook/#getWorksheets--) poskytuje přístup k listům v sešitu grafu. Tento příklad vytvoří koláčový graf s výchozími daty a vytiskne název každého listu do konzoly.

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

## **Zvolit typ zdroje dat**

Tento příklad vytvoří 3D sloupcový graf s výchozími daty a nastaví dva názvy řad pomocí různých zdrojů dat. První název používá řetězcový literál; druhý používá buňku C1 na listu 0. Výčtová hodnota [DataSourceType](https://reference.aspose.com/slides/java/com.aspose.slides/datasourcetype/) vybírá zdroj pro každý název. Příklad uloží prezentaci s aktualizovanými názvy řad.

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

Aspose.Slides nepodporuje formát binárního sešitu Excel (.xlsb), který může být vložen v některých grafech. Můžete použít metodu [getEmbeddedWorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) na [IChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/) společně s výčtem [WorkbookType](https://reference.aspose.com/slides/java/com.aspose.slides/workbooktype/) k detekci nepodporovaných formátů a přeskočení těchto grafů. Tento příklad prozkoumá objekty na první snímek existující prezentace, přeskočí objekty, které nejsou grafy, a vytiskne diagnostickou zprávu pro každý graf s vloženým sešitem .xlsb.

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

        // Číst nebo upravit podporovaná data sešitu grafu zde.
    }
} finally {
    presentation.dispose();
}
```

## **Externí sešit**

Aspose.Slides podporuje použití externích sešitů jako zdroj dat pro grafy.

### **Vytvořit externí sešit**

Použijte [readWorkbookStream](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#readWorkbookStream--) a [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) k exportu vloženého sešitu grafu do souboru a propojení grafu s tímto externím sešitem.

Tento příklad vytvoří koláčový graf s výchozími daty a exportuje jeho sešit. Dokončí zápis souboru před přiřazením externího sešitu jako zdroje dat grafu, poté uloží propojenou prezentaci.

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

Pomocí metody [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) můžete přiřadit externí sešit grafu jako jeho zdroj dat. Tato metoda může být také použita k aktualizaci cesty k externímu sešitu (pokud byl přesunut).

I když nemůžete upravovat data v sešitech uložených na vzdálených místech nebo zdrojích, můžete je stále používat jako externí zdroj dat. Pokud je zadána relativní cesta k externímu sešitu, automaticky se převede na plnou cestu.

Tento příklad používá externí sešit, jehož list s názvem `Sheet1` obsahuje název řady v B1, názvy kategorií v A2:A4 a číselné hodnoty v B2:B4. Příklad vytvoří koláčový graf, propojí sešit a použije [setRange](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setRange-java.lang.String-) k mapování A1:B4 na jednu řadu a tři kategorie. Uloží prezentaci s propojeným grafem.

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

Parametr `updateChartData` metody [setExternalWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) určuje, zda se sešit načte.

* Když je `updateChartData` nastaven na `false`, aktualizuje se pouze cesta k sešitu. Data grafu nejsou načtena ani aktualizována z cílového sešitu, takže sešit může být nedostupný.  
* Když je `updateChartData` nastaven na `true`, data grafu jsou aktualizována z cílového sešitu.

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

Pro určení sešitu propojeného s grafem zkontrolujte, zda graf používá externí zdroj dat, a získejte jeho cestu.

Tento příklad prozkoumá první objekt na první snímek prezentace s propojeným externím sešitem. Pokud se jedná o graf propojený s externím sešitem, příklad vytiskne [getExternalWorkbookPath](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) do konzole. Poté uloží kopii prezentace.

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

Data v externích sešitech můžete upravovat stejným způsobem, jako měníte obsah interních sešitů. Když externí sešit nelze načíst, vyvolá se výjimka.

Tento příklad používá graf, který je první objekt na první snímek a je propojen s přístupným externím sešitem. Nastaví hodnotu první datové bodu v první řadě na 100 a uloží aktualizovanou prezentaci. Úprava hodnot v buňkách může aktualizovat propojený externí soubor XLSX, proto použijte kopii, pokud potřebujete zachovat původní sešit.

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

### **Obnovit sešit z grafické keše**

Pokud graf používá externí sešit, který chybí nebo není k dispozici, Aspose.Slides může rekonstruovat sešit grafu z dat uložených v keši prezentace. Vytvořte [LoadOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/), zavolejte [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/java/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), a nastavte [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) na `true` před otevřením prezentace.

Následující Java příklad obnovuje data sešitu pro graf, který je první objekt na první snímek a odkazuje na nedostupný externí sešit. Přistupuje k obnoveným datům pomocí [IChart.getChartData](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getChartData--) a [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

        // Přečtěte nebo upravte data obnoveného sešitu zde.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Pokud externí sešit není k dispozici a obnovování je zakázáno, Aspose.Slides vyvolá výjimku. Povolení obnovy použijte jen tehdy, když je použití kešovaných dat grafu přijatelné jako záloha, protože keš nemusí obsahovat změny provedené v externím sešitu po poslední aktualizaci prezentace.

## **Časté dotazy**

**Mohu zjistit, zda je konkrétní graf propojen s externím nebo vloženým sešitem?**

Ano. Graf má [typ zdroje dat](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getDataSourceType--) a [cestu k externímu sešitu](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); pokud je zdroj externí sešit, můžete přečíst celou cestu a ujistit se, že je používán externí soubor.

**Jsou relativní cesty k externím sešitům podporovány a jak jsou uloženy?**

Ano. Pokud zadáte relativní cestu, automaticky se převede na absolutní cestu. Prezentace ukládá absolutní cestu v souboru PPTX, takže při přesunu sešitu může být nutné aktualizovat odkaz.

**Mohu použít sešity umístěné na síťových prostředcích/sdílených složkách?**

Ano, takové sešity mohou být použity jako externí zdroj dat. Úprava vzdálených sešitů přímo z Aspose.Slides však není podporována – mohou být použity pouze jako zdroj.

**Přepíše Aspose.Slides externí XLSX při ukládání prezentace?**

Prezentace ukládá [odkaz na externí soubor](https://reference.aspose.com/slides/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Úprava buňkou řízených dat grafu může také aktualizovat propojený lokální soubor XLSX. Použijte kopii sešitu, pokud originál musí zůstat nezměněn.

**Co mám dělat, pokud je externí soubor chráněn heslem?**

Aspose.Slides nepřijímá heslo při propojení. Běžný postup je odstranit ochranu předem nebo připravit dešifrovanou kopii (např. pomocí [Aspose.Cells](https://reference.aspose.com/cells/java/)) a odkazovat na tuto kopii.

**Může více grafů odkazovat na stejný externí sešit?**

Ano. Každý graf ukládá svůj vlastní odkaz. Pokud všechny ukazují na stejný soubor, aktualizace tohoto souboru se projeví v každém grafu při dalším načtení dat.