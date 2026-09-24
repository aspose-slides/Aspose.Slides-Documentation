---
title: Správa pracovních sešitů grafů v prezentacích pomocí Javy
linktitle: Pracovní sešit grafu
type: docs
weight: 70
url: /cs/java/chart-workbook/
keywords:
- pracovní sešit grafu
- data grafu
- buňka pracovního sešitu
- popisek dat
- list
- zdroj dat
- externí pracovní sešit
- externí data
- mezipaměť grafu
- obnovení pracovního sešitu
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Objevte Aspose.Slides pro Javu: snadno spravujte pracovní sešity grafů ve formátech PowerPoint a OpenDocument a zjednodušte data své prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s pracovními sešity grafů v Aspose.Slides. Ukazuje, jak číst a zapisovat data grafu prostřednictvím streamů pracovních sešitů, používat buňky pracovního sešitu jako popisky dat grafu, přistupovat ke kolekcím listů a specifikovat typ zdroje dat pro hodnoty grafu.

Také se zabývá prací s externími pracovními sešity jako zdroji dat grafu. Příklady ukazují, jak vytvořit a přiřadit externí pracovní sešit, získat cestu k externímu pracovnímu sešitu propojenému s grafem a upravit data grafu, když je pracovní sešit k dispozici.

Pro buňky pracovního sešitu, které představují chybějící data, viz [Ovládání zobrazení prázdných buněk](/slides/cs/java/chart-series/) pro rozdíl mezi prázdnou buňkou a nulou a srovnání režimů zobrazení v čárovém grafu.

## **Čtení a zápis dat grafu z pracovního sešitu**
Aspose.Slides poskytuje metody [ReadWorkbookStream](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IChartData#readWorkbookStream--) a [WriteWorkbookStream](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) , které umožňují číst a zapisovat pracovní sešity s daty grafu (obsahující data grafu upravená pomocí Aspose.Cells). **Poznámka** že data grafu musí být uspořádána stejným způsobem nebo mít strukturu podobnou zdroji.

Tento Java kód demonstruje ukázkovou operaci:

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

### **Ověření rozvržení grafu po úpravě pracovního sešitu**

Když nahradíte vložený pracovní sešit upraveným, graf si zachová původní kolekce řad a kategorií. Tato nekonzistence může způsobit, že [IChart.validateChartLayout](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichart/#validateChartLayout--) vyhodí výjimku `ArgumentOutOfRangeException` (parametr: index). Aby se výjimce předešlo, vymažte existující řady a kategorie **před** zápisem aktualizovaného pracovního sešitu zpět do grafu.

```java
// Po úpravě streamu pracovního sešitu (např. pomocí Aspose.Cells)
byte[] updatedWorkbook = baos.toByteArray();

// Vymažte existující odkazy na data.
chart.getChartData().getSeries().clear();
chart.getChartData().getCategories().clear();

chart.getChartData().writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

Vymazání kolekcí zajistí, že struktura dat grafu bude odpovídat novému pracovnímu sešitu, což umožní metodě `validateChartLayout` dokončit sebez chyb.

## **Nastavení buňky pracovního sešitu jako popisek dat grafu**

1. Vytvořte instanci třídy [Presentation](https://apireference.aspose.com/slides/cs/java/com.aspose.slides/presentation) .
1. Získejte referenci na snímek podle jeho indexu.
1. Přidejte bublinový graf s některými daty.
1. Přistupte k řadám grafu.
1. Nastavte buňku pracovního sešitu jako popisek dat.
1. Uložte prezentaci.

Tento Java kód vám ukazuje, jak nastavit buňku pracovního sešitu jako popisek dat grafu:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Vytváří instanci třídy prezentace, která představuje soubor prezentace
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

Tento Java kód demonstruje operaci, kde se metoda [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) používá k přístupu ke kolekci listů:

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

## **Specifikace typu zdroje dat**

Tento Java kód vám ukazuje, jak specifikovat typ pro zdroj dat:

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

## **Detekce nepodporovaných formátů vložených pracovních sešitů**

Aspose.Slides nepodporuje binární formát Excel (.xlsb), který lze vložit do některých grafů. Můžete použít metodu `getEmbeddedWorkbookType` na [IChartData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IChartData) společně s výčtem [WorkbookType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/WorkbookType) k detekci nepodporovaných formátů a vynechání těchto grafů.

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
            // Vložený pracovní sešit je ve formátu .xlsb, který není podporován.
            continue;
        }

        // Zde načtěte nebo upravte data pracovního sešitu grafu.
    }
} finally {
    presentation.dispose();
}
```

## **Externí pracovní sešit**

Aspose.Slides podporuje použití externích pracovních sešitů jako zdroje dat pro grafy.

### **Vytvoření externího pracovního sešitu**

Pomocí metod **`readWorkbookStream`** a **`setExternalWorkbook`** můžete buď vytvořit externí pracovní sešit od nuly, nebo převést interní pracovní sešit na externí.

Tento Java kód demonstruje proces vytvoření externího pracovního sešitu:

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

### **Nastavení externího pracovního sešitu**

Pomocí metody **`setExternalWorkbook`** můžete přiřadit externí pracovní sešit k grafu jako jeho zdroj dat. Tato metoda může být také použita k aktualizaci cesty k externímu pracovnímu sešitu (pokud byl přesunut).

I když nemůžete upravovat data v pracovních sešitech uložených na vzdálených místech nebo zdrojích, můžete takové sešity stále použít jako externí zdroj dat. Pokud je zadána relativní cesta k externímu pracovnímu sešitu, automaticky se převede na úplnou cestu.

Tento Java kód vám ukazuje, jak nastavit externí pracovní sešit:

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

Druhý (`boolean`) parametr metody `setExternalWorkbook` slouží k určení, zda bude excelový pracovní sešit načten nebo ne.

* Když je hodnota nastavena na `false`, aktualizuje se pouze cesta k pracovnímu sešitu – data grafu nebudou načtena ani aktualizována z cílového sešitu. Toto nastavení můžete použít v situaci, kdy cílový pracovní sešit neexistuje nebo není dostupný. 
* Když je hodnota nastavena na `true`, data grafu se aktualizují z cílového pracovního sešitu.

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

### **Získání cesty k externímu pracovnímu sešitu zdroje dat grafu**

1. Vytvořte instanci třídy [Presentation](https://apireference.aspose.com/slides/cs/java/com.aspose.slides/presentation) .
1. Získejte referenci na snímek podle jeho indexu.
1. Vytvořte objekt pro tvar grafu.
1. Vytvořte objekt pro zdroj (`ChartDataSourceType`) typu, který představuje zdroj dat grafu.
1. Specifikujte příslušnou podmínku na základě toho, že typ zdroje je stejný jako typ externího pracovního sešitu.

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

### **Úprava dat grafu**

Můžete upravovat data v externích pracovních sešitech stejným způsobem, jako provádíte změny v obsahu interních sešitů. Když externí pracovní sešit nelze načíst, je vyhozena výjimka.

Tento Java kód je implementací popsaného procesu:

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

### **Obnovení pracovního sešitu z mezipaměti grafu**

Pokud graf používá externí pracovní sešit, který chybí nebo není dostupný, Aspose.Slides může rekonstruovat pracovní sešit grafu z dat uložených v mezipaměti prezentace. Vytvořte [LoadOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/), nakonfigurujte jej pomocí [SpreadsheetOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/spreadsheetoptions/), a před otevřením prezentace zavolejte [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) s hodnotou `true`.

Následující Java příklad otevře prezentaci, jejíž graf odkazuje na nedostupný externí pracovní sešit, a přistoupí k obnoveným datům prostřednictvím [IChart.getChartData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichart/#getChartData--) a [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--):

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Načtěte nebo upravte zde obnovená data pracovního sešitu.
} finally {
    presentation.dispose();
}
```

Pokud je externí pracovní sešit nedostupný a obnovení je vypnuté, Aspose.Slides vyhodí výjimku. Povolit obnovení použijte pouze tehdy, když je použití dat z mezipaměti grafu přijatelné jako náhradní řešení, protože mezipaměť nemusí obsahovat změny provedené v externím pracovním sešitu po poslední aktualizaci prezentace.

## **Často kladené otázky**

**Mohu určit, zda je konkrétní graf propojen s externím nebo vloženým pracovním sešitem?**

Ano. Graf má [typ zdroje dat](https://reference.aspose.com/slides/cs/java/com.aspose.slides/chartdata/#getDataSourceType--) a [cestu k externímu pracovnímu sešitu](https://reference.aspose.com/slides/cs/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); pokud je zdrojem externí pracovní sešit, můžete přečíst úplnou cestu a ujistit se, že je používán externí soubor.

**Podporují se relativní cesty k externím pracovním sešitům a jak jsou uloženy?**

Ano. Pokud zadáte relativní cestu, automaticky se převádí na absolutní cestu. To je výhodné pro přenositelnost projektu; však mějte na vědomí, že prezentace uloží absolutní cestu v souboru PPTX.

**Mohu používat pracovní sešity umístěné na síťových zdrojích/spolích?**

Ano, takové sešity lze použít jako externí zdroj dat. Úpravy vzdálených sešitů přímo z Aspose.Slides však nejsou podporovány – mohou být použity pouze jako zdroj.

**Přepisuje Aspose.Slides externí XLSX při ukládání prezentace?**

Nevy. Prezentace ukládá [odkaz na externí soubor](https://reference.aspose.com/slides/cs/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) a používá jej k načítání dat. Samotný externí soubor není při ukládání prezentace upravován.

**Co mám dělat, pokud je externí soubor chráněn heslem?**

Aspose.Slides nepřijímá heslo při vytváření odkazu. Běžný postup je odstranit ochranu předem nebo připravit dešifrovanou kopii (například pomocí [Aspose.Cells](/cells/java/)) a odkázat se na tuto kopii.

**Může více grafů odkazovat na stejný externí pracovní sešit?**

Ano. Každý graf ukládá svůj vlastní odkaz. Pokud všechny odkazují na stejný soubor, jeho aktualizace se projeví v každém grafu při dalším načtení dat.