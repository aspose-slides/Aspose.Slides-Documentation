---
title: Správa sešitů grafů v prezentacích na Androidu
linktitle: Sešit grafu
type: docs
weight: 70
url: /cs/androidjava/chart-workbook/
keywords:
- sešit grafu
- data grafu
- buňka sešitu
- popisek dat
- list
- zdroj dat
- externí sešit
- externí data
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Objevte Aspose.Slides pro Android pomocí Javy: snadno spravujte sešity grafů ve formátech PowerPoint a OpenDocument a zefektivněte data své prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s sešity grafů v Aspose.Slides. Ukazuje, jak číst a zapisovat data grafu pomocí proudů sešitu, používat buňky sešitu jako popisky dat grafu, přistupovat ke kolekcím listů a určovat typ zdroje dat pro hodnoty grafu.

Také se zabývá prací s externími sešity jako zdroji dat grafu. Příklady ukazují, jak vytvořit a přiřadit externí sešit, získat cestu k externímu sešitu propojenému s grafem a upravit data grafu, když je sešit k dispozici.

## **Čtení a zápis dat grafu ze sešitu**

Aspose.Slides poskytuje metody [ReadWorkbookStream](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) a [WriteWorkbookStream](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) , které umožňují číst a zapisovat sešity dat grafu (obsahující data grafu upravená pomocí Aspose.Cells). **Poznámka**: data grafu musí být uspořádána stejným způsobem nebo musí mít strukturu podobnou zdroji.

```java
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

## **Nastavení buňky WorkBook jako popisku dat grafu**

1. Vytvořte instanci třídy [Presentation](https://apireference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) .
2. Získejte referenci snímku pomocí jeho indexu.
3. Přidejte bublinový graf s nějakými daty.
4. Přistupte k řadám grafu.
5. Nastavte buňku sešitu jako popisek dat.
6. Uložte prezentaci.

```java
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

Tento Java kód ukazuje operaci, kde je metoda [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) použita k přístupu ke kolekci listů:

```java
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

## **Určení typu zdroje dat**

Tento Java kód ukazuje, jak určit typ pro zdroj dat:

```java
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

## **Detekce nepodporovaných vložených formátů sešitu**

Aspose.Slides nepodporuje binární formát Excel sešitu (.xlsb), který může být vložen v některých grafech. Můžete použít metodu `getEmbeddedWorkbookType` na [IChartData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IChartData) spolu s výčtem [WorkbookType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/WorkbookType), abyste detekovali nepodporované formáty a tyto grafy přeskočili.

```java
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

        // Zde přečtěte nebo upravte data sešitu grafu.
    }
} finally {
    presentation.dispose();
}
```

## **Externí sešit**

Aspose.Slides podporuje externí sešity jako zdroj dat pro grafy.

### **Vytvoření externího sešitu**

Pomocí metod **`readWorkbookStream`** a **`setExternalWorkbook`** můžete buď vytvořit externí sešit od nuly, nebo učinit interní sešit externím.

```java
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

Pomocí metody **`setExternalWorkbook`** můžete přiřadit externí sešit k grafu jako jeho zdroj dat. Tato metoda může být také použita k aktualizaci cesty k externímu sešitu (pokud byl přesunut).  

I když nemůžete upravovat data v sešitech uložených na vzdálených místech nebo zdrojích, můžete takové sešity stále použít jako externí zdroj dat. Pokud je zadána relativní cesta k externímu sešitu, automaticky se převede na úplnou cestu.

```java
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

Parametr `ChartData` (u metody `setExternalWorkbook`) se používá k určení, zda bude excelový sešit načten, nebo ne.

* Když je hodnota `ChartData` nastavena na `false`, aktualizuje se pouze cesta k sešitu — data grafu nebudou načtena ani aktualizována z cílového sešitu. Toto nastavení můžete použít v situaci, kdy cílový sešit neexistuje nebo není k dispozici.  
* Když je hodnota `ChartData` nastavena na `true`, data grafu se aktualizují z cílového sešitu.

```java
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

### **Získání cesty k externímu sešitu zdroje dat grafu**

1. Vytvořte instanci třídy [Presentation](https://apireference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation) .
2. Získejte referenci snímku pomocí jeho indexu.
3. Vytvořte objekt pro tvar grafu.
4. Vytvořte objekt pro typ zdroje (`ChartDataSourceType`), který představuje zdroj dat grafu.
5. Určete relevantní podmínku na základě toho, že typ zdroje je stejný jako typ externího sešitu.

```java
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

Data v externích sešitech můžete upravovat stejným způsobem, jako měníte obsah interních sešitů. Pokud externí sešit nelze načíst, je vyvolána výjimka.

```java
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

## **FAQ**

**Mohu určit, zda je konkrétní graf propojen s externím nebo vloženým sešitem?**

Ano. Graf má [typ zdroje dat](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) a [cestu k externímu sešitu](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); pokud je zdroj externí sešit, můžete přečíst úplnou cestu a ujistit se, že je používán externí soubor.

**Podporují se relativní cesty k externím sešitům a jak jsou ukládány?**

Ano. Pokud zadáte relativní cestu, automaticky se převede na absolutní cestu. To je výhodné pro přenositelnost projektu; však buďte si vědomi, že prezentace uloží absolutní cestu v souboru PPTX.

**Mohu použít sešity umístěné na síťových zdrojích/sdílených složkách?**

Ano, takové sešity mohou být použity jako externí zdroj dat. Úprava vzdálených sešitů přímo z Aspose.Slides však není podporována — mohou být použity pouze jako zdroj.

**Přepisuje Aspose.Slides externí soubor XLSX při ukládání prezentace?**

Ne. Prezentace ukládá [odkaz na externí soubor](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) a používá jej při čtení dat. Externí soubor samotný není při ukládání prezentace upravován.

**Co mám dělat, pokud je externí soubor chráněn heslem?**

Aspose.Slides nepřijímá heslo při propojení. Běžný postup je odstranit ochranu předem nebo připravit dešifrovanou kopii (například pomocí [Aspose.Cells](/cells/androidjava/)) a odkazovat na tuto kopii.

**Může více grafů odkazovat na stejný externí sešit?**

Ano. Každý graf uchovává svůj vlastní odkaz. Pokud všechny odkazují na stejný soubor, aktualizace tohoto souboru se projeví v každém grafu při dalším načtení dat.