---
title: Správa sešitů diagramů v prezentacích na Androidu
linktitle: Sešit diagramu
type: docs
weight: 70
url: /cs/androidjava/chart-workbook/
keywords:
- sešit diagramu
- data diagramu
- buňka sešitu
- popisek dat
- list
- datový zdroj
- externí sešit
- externí data
- mezipaměť diagramu
- obnova sešitu
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Objevte Aspose.Slides pro Android pomocí Java: snadno spravujte sešity diagramů ve formátech PowerPoint a OpenDocument a zefektivněte data své prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s sešity diagramů v Aspose.Slides. Ukazuje, jak číst a zapisovat data diagramu prostřednictvím streamů sešitu, používat buňky sešitu jako popisky dat diagramu, přistupovat ke kolekcím listů a specifikovat typ datového zdroje pro hodnoty diagramu.

Také se zabývá prací s externími sešity jako datovým zdrojem diagramů. Příklady ukazují, jak vytvořit a přiřadit externí sešit, získat cestu k externímu sešitu propojenému s diagramem a upravit data diagramu, když je sešit k dispozici.

Pro buňky sešitu, které představují chybějící data, viz [Control the Display of Empty Cells](/slides/cs/androidjava/chart-series/) pro rozdíl mezi prázdnou buňkou a nulou a srovnání liniového diagramu dostupných režimů zobrazení.

## **Zahrnout data ze skrytých řádků a sloupců**

Použijte [IChart.setPlotVisibleCellsOnly](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setPlotVisibleCellsOnly-boolean-) k řízení, zda diagram vykresluje data ze skrytých řádků a sloupců listu. Nastavte na `true`, aby diagram vykresloval jen viditelné buňky, nebo na `false`, aby zahrnoval jak viditelné, tak skryté buňky. Toto nastavení řídí vykreslování diagramu; neukrývá ani neodkrývá řádky nebo sloupce listu.

Ukázková prezentace([sample presentation](hidden-source-data.pptx)) obsahuje sloupcový diagram jako první objekt na první snímku. Vložený list `Sheet1` obsahuje následující zdrojový rozsah `A1:C4`. Řádek 3 a sloupec C jsou skryté, ale jejich buňky stále obsahují hodnoty.

| Řádek listu | A: Měsíc | B: Maloobchod | C: Velkoobchod (skrytý sloupec) |
| --- | --- | --- | --- |
| 2 | leden | 10 | 30 |
| 3 (skrytý řádek) | únor | 40 | 60 |
| 4 | březen | 20 | 50 |

Přístup ke zdrojovým buňkám získáte pomocí [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) a přečtete [IChartDataCell.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#isHidden--) k inspekci jejich skrytého stavu. Tato metoda hlásí skrytý stav, aniž by ho měnila. V tomto souboru je B2 viditelná, B3 patří ke skrytému řádku a C2 patří ke skrytému sloupci; příklad vytiskne `false`, `true` a `true`.

Pro tento příklad obnovte data diagramu po změně nastavení vykreslování: zachovejte vložený sešit pomocí [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) a znovu jej načtěte pomocí [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---). Při zahrnutí všech buněk také použijte [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) k obnovení úplného rozsahu, včetně skryté kategorie únor. Pouhý změna příznaku není dostačující k obnovení mezipaměti dat a popisků kategorií v tomto vzorku.

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

            // Obnovte data diagramu z vloženého sešitu.
            chart.getChartData().writeWorkbookStream(workbookData);
            if (!visibleOnly) {
                // Obnovte úplný zdrojový rozsah, včetně skrytých kategorií.
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

Příklad uloží dvě verze prezentace: jednu jen s viditelnými hodnotami Maloobchodu (10 a 20) a druhou se všemi šesti hodnotami. Níže uvedené obrázky ilustrují dva režimy vykreslování. Řádek 3 a sloupec C zůstávají skryté v obou vložených sešitech.

| Pouze viditelné buňky (`true`) | Všechny buňky (`false`) |
| --- | --- |
| ![Pouze viditelné buňky: hodnoty maloobchodu 10 a 20 pro leden a březen.](hidden_cells_True.png) | ![Všechny buňky: hodnoty maloobchodu a velkoobchodu pro leden, únor a březen.](hidden_cells_False.png) |

Skrytá buňka obsahující hodnotu se liší od prázdné buňky. [IChart.setDisplayBlanksAs](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#setDisplayBlanksAs-int-) řídí, jak jsou chybějící hodnoty zobrazeny; neinkluduje ani nevynechává skrytá zdrojová data. Viz [Control the Display of Empty Cells](/slides/cs/androidjava/chart-series/#control-the-display-of-empty-cells) pro příklad.

## **Získat datový rozsah diagramu**

Před aktualizací dat sešitu v existující prezentaci prověřte zdrojové rozsahy, abyste identifikovali, které buňky listu každý diagram používá. Metoda [IChartData.getRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getRange--) vrací aktuální datový rozsah jako vzorec kvalifikovaný listem, například `Sheet1!$A$1:$D$5`. Zde je `Sheet1` název listu, `!` jej odděluje od rozsahu buněk a `$A$1:$D$5` označuje buňky A1 až D5 včetně. Znak `$` značí absolutní odkazy na řádek a sloupec.

Metoda čte aktuální rozsah, aniž by měnila diagram nebo jeho sešit. Pokud diagram nevyužívá sešit jako datový zdroj, vyvolá `InvalidOperationException`. Další informace naleznete v [ChartData API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/).

Tento příklad otevře prezentaci a přímo na každém snímku kontroluje objekty, zda jsou diagramy. Vytiskne název každého diagramu a jeho zdrojový rozsah. Pokud diagram nevyužívá sešit, vytiskne zprávu a pokračuje k dalšímu diagramu.

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

## **Číst a zapisovat data diagramu ze sešitu**

Aspose.Slides for Android via Java poskytuje metody [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) a [writeWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#writeWorkbookStream-byte---), které umožňují číst a zapisovat sešity dat diagramu (obsahující data editovaná pomocí Aspose.Cells). **Note** že data diagramu musí být uspořádána stejným způsobem nebo mít strukturu podobnou zdroji.

Příklad používá prezentaci s diagramem jako první objekt na první snímku. Načte vložený sešit do pole bajtů, vymaže existující řady a kategorie a zapíše stejný sešit zpět. Změny zůstávají v paměti; příklad prezentaci neukládá.

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

### **Ověřit rozvržení diagramu po úpravě sešitu**

Když nahradíte vložený sešit upraveným, diagram si zachová původní kolekce řad a kategorií. Tento nesoulad může způsobit selhání [IChart.validateChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#validateChartLayout--) s chybou index‑out‑of‑range. Před zápisem aktualizovaného sešitu do diagramu vymažte existující řady a kategorie. Tento příklad používá diagram, který je první objekt na prvním snímku. Komentář označuje místo, kde by se upravoval sešit; spustitelný příklad zapíše původní sešit zpět a v paměti ověří rozvržení.

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

        // Upravit bajty sešitu zde, například pomocí Aspose.Cells.

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

Vymazání kolekcí odstraní zastaralé odkazy na data před zápisem sešitu zpět. Před použitím diagramu znovu vytvořte potřebné mapování řad a kategorií pro aktualizovaný sešit.

## **Nastavit vlastní číselné formáty pro buňky sešitu**

Použijte [IChartDataCell.setCustomNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#setCustomNumberFormat-java.lang.String-) k řízení, jak se číselné hodnoty zobrazují ve vloženém sešitu diagramu. Například zpráva může vyžadovat konverzní poměr zobrazený jako procento se čtyřmi desetinnými místy a koeficient se pěti desetinnými místy. Obě hodnoty nechte jako číselné, aby byly dostupné pro výpočty a vykreslování diagramu.

Číselný formát mění pouze zobrazení, ne uloženou hodnotu. Formát `0.0000%` zobrazí `0.125` jako `12.5000%`; nenahradí uložené číslo `12.5`. Podobně `0.00000` zobrazí `0.1234567` jako `0.12346` bez zaokrouhlení uložené hodnoty. Pokud je vlastní formát prázdný řetězec (`""`), použije se formát vrácený metodou [getPresetNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdatacell/#getPresetNumberFormat--).

Následující příklad vytvoří sloupcový diagram a přistoupí k jeho buňkám přes [getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--). Na listu 0 obsahuje B2 konverzní poměr a C2 koeficient. Obě buňky poskytují hodnoty pro diagram. Příklad také povolí popisky hodnot propojené se zdrojovými formáty.

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

Formáty buněk sešitu jsou oddělené od formátů nastavených přímo na osách diagramu nebo popiscích dat. V tomto příkladu každý popisek zobrazuje hodnotu své zdrojové buňky, protože [setShowValue](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setShowValue-boolean-) je nastaven na `true` a dodržuje zdrojový číselný formát, protože [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormatLinkedToSource-boolean-) je nastaven na `true`. Po uložení a opětovném otevření prezentace popisky zobrazí `12.5000%` a `0.12346`, jak je ukázáno níže. Vertikální osa používá vlastní číselný formát nastavený pomocí [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormat-java.lang.String-) na `0.00`, přičemž [setNumberFormatLinkedToSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaxis/#setNumberFormatLinkedToSource-boolean-) je nastaven na `false`.

Pro nezávislé formátování popisku dat nastavte příznak propojení na zdroj na `false` a přiřaďte formát pomocí [setNumberFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/idatalabelformat/#setNumberFormat-java.lang.String-). Tím se nezmění formát buňky sešitu. Například nezávislý formát popisku `0.00` zobrazí první hodnotu jako `0.13`, zatímco B2 stále zobrazuje `12.5000%`. Viz [Chart Data Labels](/slides/cs/androidjava/chart-data-label/#set-the-percentage-sign-with-chart-data-labels) pro přímé formátování popisků.

Obrázek níže byl vygenerován z uložené prezentace po jejím opětovném otevření:

![Sloupcový diagram se štítky propojenými na zdroj, zobrazující 12,5000 % a 0,12346, a samostatně formátovanou číselnou osu.](custom-cell-formats.png)

## **Nastavit buňku sešitu jako popisek dat diagramu**

Můžete použít text z buněk sešitu jako popisky dat diagramu.

Tento příklad přidá bublinový diagram s výchozími daty na první snímek existující prezentace. Použije buňky A10:A12 na listu 0 pro první tři popisky v první řadě, povolí popisky z buněk a uloží aktualizovanou prezentaci.

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

Metoda [IChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdataworkbook/#getWorksheets--) poskytuje přístup k listům v sešitu diagramu. Tento příklad vytvoří koláčový diagram s výchozími daty a vytiskne každý název listu do konzole.

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

## **Zadat typ datového zdroje**

Tento příklad vytvoří 3D sloupcový diagram s výchozími daty a nastaví dva názvy řad pomocí různých datových zdrojů. První název používá řetězcový literál; druhý používá buňku C1 na listu 0. Výčtový typ [DataSourceType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/datasourcetype/) vybírá zdroj pro každý název. Příklad uloží prezentaci s aktualizovanými názvy řad.

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

Aspose.Slides nepodporuje binární formát Excelu (.xlsb), který může být vložen v některých diagramech. K detekci nepodporovaných formátů a přeskočení takových diagramů můžete použít metodu [getEmbeddedWorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getEmbeddedWorkbookType--) na [IChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/) spolu s výčtem [WorkbookType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/workbooktype/). Tento příklad prověří objekty na první snímku existující prezentace, přeskočí objekty, které nejsou diagramy, a vytiskne diagnostickou zprávu pro každý diagram s vloženým .xlsb sešitem.

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

        // Přečtěte nebo upravte podporovaná data sešitu diagramu zde.
    }
} finally {
    presentation.dispose();
}
```

## **Externí sešit**

Aspose.Slides podporuje používání externích sešitů jako datového zdroje pro diagramy.

### **Vytvořit externí sešit**

Použijte [readWorkbookStream](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#readWorkbookStream--) a [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) k exportu vloženého sešitu diagramu do souboru a propojení diagramu s tímto externím sešitem.

Tento příklad vytvoří koláčový diagram s výchozími daty a exportuje jeho sešit. Po dokončení zápisu souboru přiřadí externí sešit jako datový zdroj diagramu a uloží propojenou prezentaci.

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

### **Nastavit externí sešit**

Pomocí metody [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-) můžete přiřadit externí sešit diagramu jako jeho datový zdroj. Tato metoda lze také použít k aktualizaci cesty k externímu sešitu (pokud byl přesunut).

I když nelze upravovat data v sešitech uložených ve vzdálených umístěních nebo zdrojích, můžete takové sešity stále použít jako externí datový zdroj. Pokud je zadána relativní cesta k externímu sešitu, automaticky se převede na úplnou cestu.

Tento příklad používá externí sešit, jehož list pojmenovaný `Sheet1` obsahuje název řady v B1, názvy kategorií v A2:A4 a číselné hodnoty v B2:B4. Příklad vytvoří koláčový diagram, propojí sešit a použije [setRange](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setRange-java.lang.String-) k mapování A1:B4 na jednu řadu a tři kategorie. Uloží prezentaci s propojeným diagramem.

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

Parametr `updateChartData` metody [setExternalWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#setExternalWorkbook-java.lang.String-boolean-) řídí, zda se sešit načte.

* Když je `updateChartData` `false`, aktualizuje se jen cesta k sešitui. Data diagramu nejsou načtena ani aktualizována ze cílového sešitu, takže sešit může být nedostupný.  
* Když je `updateChartData` `true`, data diagramu jsou aktualizována ze cílového sešitu.

Následující příklad přiřadí zástupnou URL s `updateChartData` nastaveným na `false`. Zachová výchozí data koláčového diagramu a uloží prezentaci bez načítání nedostupného sešitu.

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

### **Získat cestu k externímu sešitu datového zdroje diagramu**

Pro identifikaci sešitu propojeného s diagramem zkontrolujte, zda diagram používá externí datový zdroj, a získejte cestu k jeho sešitu.

Tento příklad prověří první objekt na prvním snímku prezentace s propojeným externím sešitem. Pokud jde o diagram propojený s externím sešitem, vytiskne [getExternalWorkbookPath](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getExternalWorkbookPath--) do konzole. Pak uloží kopii prezentace.

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

### **Upravit data diagramu**

Můžete upravovat data v externích sešitech stejným způsobem, jako měníte obsah vnitřních sešitů. Když nelze externí sešit načíst, je vyvolána výjimka.

Tento příklad používá diagram, který je první objekt na prvním snímku a je propojen s dostupným externím sešitem. Nastaví hodnotu buňky první datové bodu v první řadě na 100 a uloží aktualizovanou prezentaci. Úprava hodnot buněk může aktualizovat propojený externí soubor XLSX, proto použijte kopii, pokud potřebujete zachovat originální sešit.

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

### **Obnovit sešit z mezipaměti diagramu**

Pokud diagram používá externí sešit, který chybí nebo není dostupný, Aspose.Slides může reconstruct sešit diagramu z dat uložených v mezipaměti prezentace. Vytvořte [LoadOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/), zavolejte [LoadOptions.setSpreadsheetOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/loadoptions/#setSpreadsheetOptions-com.aspose.slides.ISpreadsheetOptions-), a nastavte [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) na `true` před otevřením prezentace.

Následující Java příklad obnoví data sešitu pro diagram, který je první objekt na prvním snímku a odkazuje na nedostupný externí sešit. Přístup k obnoveným datům získá přes [IChart.getChartData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getChartData--) a [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

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

        // Přečtěte nebo upravte obnovená data sešitu zde.
    } else {
        System.out.println("The first shape is not a chart.");
    }
} finally {
    presentation.dispose();
}
```

Pokud je externí sešit nedostupný a obnova je zakázána, Aspose.Slides vyvolá výjimku. Povolit obnovu jen tehdy, když je použití mezipaměti diagramu přijatelné, protože mezipaměť nemusí obsahovat změny provedené v externím sešitu po poslední aktualizaci prezentace.

## **Často kladené otázky**

**Mohu zjistit, zda je konkrétní diagram propojen na externí nebo vložený sešit?**

Ano. Diagram má [data source type](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) a [path to an external workbook](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); pokud je zdrojem externí sešit, můžete přečíst úplnou cestu a ověřit, že je použita externí soubor.

**Jsou relativní cesty k externím sešitům podporovány a jak jsou uloženy?**

Ano. Pokud zadáte relativní cestu, automaticky se převede na absolutní. Prezentace ukládá absolutní cestu v souboru PPTX, takže při přesunu sešitu může být nutné aktualizovat odkaz.

**Mohu používat sešity umístěné na síťových zdrojích/sdíleních?**

Ano, takové sešity lze použít jako externí datový zdroj. Úpravy vzdálených sešitů přímo z Aspose.Slides však nejsou podporovány – mohou být použity jen jako zdroj.

**Přepisuje Aspose.Slides externí soubor XLSX při ukládání prezentace?**

Prezentace ukládá [link to the external file](https://reference.aspose.com/slides/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--). Úpravy buněk‑propojených dat diagramu mohou také aktualizovat propojený lokální soubor XLSX. Použijte kopii sešitu, pokud musí originál zůstat nezměněn.

**Co mám dělat, pokud je externí soubor chráněn heslem?**

Aspose.Slides nepřijímá heslo při propojení. Běžný postup je odstranit ochranu předem nebo připravit dešifrovanou kopii (například pomocí [Aspose.Cells](https://reference.aspose.com/cells/java/)) a odkazovat na tuto kopii.

**Může více diagramů odkazovat na stejný externí sešit?**

Ano. Každý diagram ukládá svůj vlastní odkaz. Pokud všechny odkazují na stejný soubor, aktualizace tohoto souboru bude odrážena v každém diagramu při dalším načtení dat.