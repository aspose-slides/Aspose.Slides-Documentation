---
title: Spravujte sešity diagramů v prezentacích na Androidu
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
- obnovení sešitu
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Objevte Aspose.Slides pro Android pomocí Javy: snadno spravujte sešity diagramů ve formátech PowerPoint a OpenDocument a zefektivněte data své prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s diagramovými sešity v Aspose.Slides. Ukazuje, jak číst a zapisovat data diagramu pomocí proudu sešitu, používat buňky sešitu jako popisky dat diagramu, přistupovat ke kolekcím listů a určit typ datového zdroje pro hodnoty diagramu.

Také se zabývá používáním externích sešitů jako datových zdrojů diagramu. Příklady demonstrují, jak vytvořit a přiřadit externí sešit, získat cestu k externímu sešitu propojenému s diagramem a upravit data diagramu, když je sešit k dispozici.

## **Čtení a zápis dat diagramu ze sešitu**
Aspose.Slides poskytuje metody [ReadWorkbookStream](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) a [WriteWorkbookStream](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) , které umožňují číst a zapisovat sešity dat diagramu (obsahující data diagramu upravená pomocí Aspose.Cells). **Poznámka** že data diagramu musí být organizována stejným způsobem nebo musí mít strukturu podobnou zdroji.

Tento Java kód ukazuje ukázkovou operaci:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("chart.pptx");
try {
    Chart chart = (Chart) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartData data = chart.getChartData();

    byte[] stream = data.readWorkbookStream();

    data.getSeries().clear();
    data.getCategories().clear();

    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Ověření rozvržení diagramu po úpravě sešitu**

Když nahradíte vložený sešit upraveným, diagram si zachová původní kolekce sérií a kategorií. Tento nesoulad může způsobit, že [IChart.validateChartLayout](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChart#validateChartLayout--) selže s chybou indexu mimo rozsah. Vyčistěte existující série a kategorie před zápisem aktualizovaného sešitu zpět do diagramu.

```java
// Po úpravě proudu sešitu (např. pomocí Aspose.Cells)
byte[] updatedWorkbook = chartData.readWorkbookStream();

// Vymazat existující odkazy na data.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Vyprázdnění kolekcí zajišťuje, že struktura dat diagramu je konzistentní s novým sešitem, což umožní `validateChartLayout` dokončit bez chyb.

## **Nastavení buňky sešitu jako popisku dat diagramu**

1. Vytvořte instanci třídy [Presentation](https://apireference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) .
1. Získejte odkaz na snímek podle jeho indexu.
1. Přidejte bublinový diagram s některými daty.
1. Přistupte k sérii diagramu.
1. Nastavte buňku sešitu jako popisek dat.
1. Uložte prezentaci.

Tento Java kód vám ukáže, jak nastavit buňku sešitu jako popisek dat diagramu:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Vytvoří instanci třídy prezentace, která představuje soubor prezentace
Presentation pres = new Presentation("chart2.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IChart chart = slide.getShapes().addChart(ChartType.Bubble, 50, 50, 600, 400, true);
    IChartSeriesCollection series = chart.getChartData().getSeries();
    
    IDataLabelCollection dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);

    IChartDataWorkbook wb = chart.getChartData().getChartDataWorkbook();

    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));

    pres.save("resultchart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Správa listů**

Tento Java kód demonstruje operaci, kde je metoda [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) použita k přístupu ke kolekci listů:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook wb =  chart.getChartData().getChartDataWorkbook();
    for (int i = 0; i < wb.getWorksheets().size(); i++)
        System.out.println(wb.getWorksheets().get_Item(i).getName());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Určení typu datového zdroje**

Tento Java kód vám ukáže, jak určit typ pro datový zdroj:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Column3D, 50, 50, 600, 400, true);
    IStringChartValue val = chart.getChartData().getSeries().get_Item(0).getName();

    val.setDataSourceType(DataSourceType.StringLiterals);
    val.setData("LiteralString");

    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Detekce nepodporovaných formátů vložených sešitů**

Aspose.Slides nepodporuje binární formát Excelu (.xlsb), který může být vložen v některých diagramech. Můžete použít metodu `getEmbeddedWorkbookType` na [IChartData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartData) spolu s výčtem [WorkbookType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/WorkbookType) k detekci nepodporovaných formátů a přeskakování těchto diagramů.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    for (IShape shape : slide.getShapes()) {
        if (!(shape instanceof IChart)) continue;

        IChart chart = (IChart)shape;
        IChartData chartData = chart.getChartData();

        if (chartData.getDataSourceType() == ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == WorkbookType.WorkbookBinaryMacro) {
            // Vložený sešit je ve formátu .xlsb, který není podporován.
            continue;
        }

        // Zde načtěte nebo upravte data sešitu diagramu.
    }
} finally {
    presentation.dispose();
}
```

## **Externí sešit**

Aspose.Slides podporuje externí sešity jako datový zdroj pro diagramy.

### **Vytvoření externího sešitu**

Pomocí metod **`readWorkbookStream`** a **`setExternalWorkbook`** můžete buď vytvořit externí sešit od nuly, nebo učinit interní sešit externím.

Tento Java kód demonstruje proces vytváření externího sešitu:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation pres = new Presentation();
try {
    final String workbookPath = "externalWorkbook1.xlsx";

    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600);
    FileOutputStream fileStream = new FileOutputStream(workbookPath);
    try {
        byte[] workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) fileStream.close();
    }

    chart.getChartData().setExternalWorkbook(workbookPath);

    pres.save("externalWorkbook.pptx", SaveFormat.Pptx);
} catch (IOException e) {    
} finally {
    if (pres != null) pres.dispose();
}
```

### **Nastavení externího sešitu**

Pomocí metody **`setExternalWorkbook`** můžete přiřadit externí sešit k diagramu jako jeho datový zdroj. Tato metoda může být také použita k aktualizaci cesty k externímu sešitu (pokud byl přesunut).

Zatímco nemůžete upravovat data v sešitech uložených na vzdálených místech nebo zdrojích, můžete takové sešity stále používat jako externí datový zdroj. Pokud je zadána relativní cesta k externímu sešitu, automaticky se převede na úplnou cestu.

Tento Java kód vám ukáže, jak nastavit externí sešit:

```java
import com.aspose.slides.*;

// Vytvoří instanci třídy Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, false);
    IChartData chartData = chart.getChartData();

    chartData.setExternalWorkbook("externalWorkbook.xlsx");

    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));

    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    
    pres.save("Presentation_with_externalWorkbook.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Parametr `updateChartData` (pod metodou `setExternalWorkbook`) slouží k určení, zda bude Excel sešit načten nebo ne.

* Když je hodnota `updateChartData` nastavena na `false`, aktualizuje se pouze cesta k sešitu — data diagramu nebudou načtena ani aktualizována z cílového sešitu. Toto nastavení je vhodné, pokud cílový sešit neexistuje nebo není k dispozici.
* Když je hodnota `updateChartData` nastavena na `true`, data diagramu se aktualizují z cílového sešitu.

```java
import com.aspose.slides.*;

// Vytvoří instanci třídy Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 600, true);
    IChartData chartData = chart.getChartData();

    ((ChartData)chartData).setExternalWorkbook("http://path/doesnt/exists", false);

    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Získání cesty k externímu sešitu datového zdroje diagramu**

1. Vytvořte instanci třídy [Presentation](https://apireference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) .
1. Získejte odkaz na snímek podle jeho indexu.
1. Vytvořte objekt pro tvar diagramu.
1. Vytvořte objekt pro typ zdroje (`ChartDataSourceType`), který představuje datový zdroj diagramu.
1. Určete příslušnou podmínku na základě toho, že typ zdroje je stejný jako typ externího sešitu datového zdroje.

Tento Java kód demonstruje operaci:

```java
import com.aspose.slides.*;

// Vytvoří instanci třídy Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(1);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    int sourceType = chart.getChartData().getDataSourceType();
    
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        String path = chart.getChartData().getExternalWorkbookPath();
    }
	
	// Uloží prezentaci
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Úprava dat diagramu**

Můžete upravovat data v externích sešitech stejným způsobem, jako měníte obsah interních sešitů. Když externí sešit nelze načíst, je vyvolána výjimka.

Tento Java kód představuje popsaný proces:

```java
import com.aspose.slides.*;

// Vytvoří instanci třídy Presentation
Presentation pres = new Presentation("chart.pptx");
try {
    IChart chart = (IChart)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ChartData chartData = (ChartData)chart.getChartData();
    
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    
    pres.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Obnovení sešitu z mezipaměti diagramu**

Pokud diagram používá externí sešit, který chybí nebo není dostupný, Aspose.Slides může obnovit sešit diagramu z dat uložených v mezipaměti prezentace. Vytvořte [LoadOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/loadoptions/), nakonfigurujte jej pomocí [SpreadsheetOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/spreadsheetoptions/), a před otevřením prezentace zavolejte [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) s hodnotou `true`.

Následující Java příklad otevře prezentaci, jejíž diagram odkazuje na nedostupný externí sešit, a přistoupí k obnoveným datům prostřednictvím [IChart.getChartData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichart/#getChartData--) a [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
import com.aspose.slides.*;

SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Zde načtěte nebo upravte data obnoveného sešitu.
} finally {
    presentation.dispose();
}
```

Pokud je externí sešit nedostupný a obnovení je zakázáno, Aspose.Slides vyvolá výjimku. Povolit obnovení pouze tehdy, když je použití dat z mezipaměti přijatelnou náhradou, protože mezipaměť nemusí obsahovat změny provedené v externím sešitu po poslední aktualizaci prezentace.

## **Často kladené otázky**

**Mohu zjistit, zda je konkrétní diagram propojen s externím nebo vloženým sešitem?**

Ano. Diagram má [typ datového zdroje](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) a [cestu k externímu sešitu](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); pokud je zdroj externí sešit, můžete přečíst úplnou cestu a ujistit se, že je používán externí soubor.

**Jsou podporovány relativní cesty k externím sešitům a jak jsou uloženy?**

Ano. Pokud zadáte relativní cestu, automaticky se převede na absolutní cestu. To je výhodné pro přenositelnost projektu; mějte však na vědomí, že prezentace uloží absolutní cestu v souboru PPTX.

**Mohu používat sešity umístěné na síťových zdrojích/share?**

Ano, takové sešity mohou být použity jako externí datový zdroj. Úpravy vzdálených sešitů přímo z Aspose.Slides však nejsou podporovány — lze je jen použít jako zdroj.

**Přepisuje Aspose.Slides externí XLSX při ukládání prezentace?**

Ne. Prezentace ukládá [odkaz na externí soubor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) a používá jej pro čtení dat. Externí soubor není při ukládání prezentace modifikován.

**Co mám dělat, pokud je externí soubor chráněn heslem?**

Aspose.Slides neakceptuje heslo při propojení. Běžný postup je odstranit ochranu předem nebo připravit dešifrovanou kopii (například pomocí [Aspose.Cells](/cells/androidjava/)) a odkazovat na tuto kopii.

**Může více diagramů odkazovat na stejný externí sešit?**

Ano. Každý diagram ukládá svůj vlastní odkaz. Pokud všechny odkazují na stejný soubor, aktualizace tohoto souboru se projeví v každém diagramu při dalším načtení dat.