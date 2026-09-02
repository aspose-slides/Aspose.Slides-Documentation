---
title: Diagramm-munkafüzetek kezelése prezentációkban Androidon
linktitle: Diagramm munkafüzet
type: docs
weight: 70
url: /hu/androidjava/chart-workbook/
keywords:
- diagramm munkafüzet
- diagramm adatok
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
description: "Fedezze fel az Aspose.Slides for Android-t Java segítségével: egyszerűen kezelje a diagramm-munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy optimalizálja a prezentáció adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozzunk diagramm-munkafüzetekkel az Aspose.Slides‑ben. Megmutatja, hogyan lehet olvasni és írni diagrammadatokat munkafüzet‑áramokon keresztül, munkafüzet‑cellákat használni diagrammadatok címkéjeként, elérni a munkalap‑gyűjteményeket, és megadni az adatforrás típusát a diagram értékeihez.

Továbbá tárgyalja a külső munkafüzetek diagrammadat‑forrásként való használatát. A példák bemutatják, hogyan hozhatunk létre és rendelhetünk hozzá egy külső munkafüzetet, hogyan kérhetjük le egy diagramhoz csatolt külső munkafüzet útvonalát, és hogyan szerkeszthetjük a diagramadatokat, ha a munkafüzet elérhető.

## **Diagramadatok olvasása és írása munkafüzetből**
Az Aspose.Slides a [ReadWorkbookStream](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) és a [WriteWorkbookStream](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) metódusokat biztosítja, amelyek lehetővé teszik a diagramadat‑munkafüzetek (az Aspose.Cells‑szel szerkesztett diagramadatokat tartalmazó) olvasását és írását. **Megjegyzés:** a diagramadatoknak ugyanolyan módon kell felépülniük, vagy hasonló struktúrával kell rendelkezniük, mint a forrás.

Ez a Java‑kód egy példaműveletet mutat be:

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

## **Munkafüzet‑cellát beállítani diagrammadat‑címkének**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.
1. Szerezze meg egy diát indexe alapján.
1. Adjon hozzá egy Buborék‑diagramot némi adattal.
1. Érje el a diagram sorozatát.
1. Állítsa be a munkafüzet‑cellát adatcímkének.
1. Mentse a prezentációt.

Ez a Java‑kód megmutatja, hogyan állíthat be egy munkafüzet‑cellát diagrammadat‑címkének:

```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Példányosít egy prezentáció osztályt, amely egy prezentációfájlt képvisel
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

## **Munkalapok kezelése**

Ez a Java‑kód egy műveletet demonstrál, ahol a [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) metódust használják a munkalap‑gyűjtemény eléréséhez:

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

## **Az adatforrás típusának megadása**

Ez a Java‑kód megmutatja, hogyan adhat meg egy típust az adatforráshoz:

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

## **Nem támogatott beágyazott munkafüzet‑formátumok észlelése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumát, amely néhány diagramba beágyazható. A `getEmbeddedWorkbookType` metódust az [IChartData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartData)‑n és a [WorkbookType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/WorkbookType) enumerációval együtt használva felismerhetők a nem támogatott formátumok, és kihagyhatók a diagramok.

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
            // A beágyazott munkafüzet .xlsb formátumban van, ami nem támogatott.
            continue;
        }

        // Olvassa vagy módosítsa itt a diagram munkafüzet adatait.
    }
} finally {
    presentation.dispose();
}
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzeteket adatforrásként a diagramokhoz.

### **Külső munkafüzet létrehozása**

A **`readWorkbookStream`** és a **`setExternalWorkbook`** metódusok segítségével létrehozhat egy külső munkafüzetet a semmiből, vagy egy belső munkafüzetet tehet külsővé.

Ez a Java‑kód bemutatja a külső munkafüzet létrehozásának folyamatát:

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

### **Külső munkafüzet beállítása**

A **`setExternalWorkbook`** metódussal egy külső munkafüzetet rendelhet egy diagramhoz adatforrásként. Ezzel a metódussal a külső munkafüzet útvonalát is frissítheti (ha az később át lett helyezve).

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem szerkesztheti, továbbra is használhatja ezeket külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzethez, azt automatikusan teljes úttá konvertálja a rendszer.

Ez a Java‑kód megmutatja, hogyan állíthat be egy külső munkafüzetet:

```java
// Létrehoz egy példányt a Presentation osztályból
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

A `ChartData` paraméter (a `setExternalWorkbook` metódus alatt) azt jelzi, hogy egy Excel‑munkafüzet be lesz‑töltve vagy sem.

* Ha a `ChartData` értéke **false**, csak a munkafüzet‑útvonal frissül – a diagramadatok nem lesznek betöltve vagy frissítve a cél‑munkafüzetből. Ezt a beállítást akkor érdemes használni, ha a cél‑munkafüzet nem létezik vagy nem érhető el.
* Ha a `ChartData` értéke **true**, a diagramadatok frissülnek a cél‑munkafüzetből.

```java
// Létrehoz egy példányt a Presentation osztályból
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

### **A diagram külső adatforrás‑munkafüzetének útvonalának lekérdezése**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.
1. Szerezze meg egy diát indexe alapján.
1. Hozzon létre egy objektumot a diagram alakzathoz.
1. Hozzon létre egy objektumot a forrás (`ChartDataSourceType`) típusához, amely a diagram adatforrását képviseli.
1. Adja meg a megfelelő feltételt a forrástípus alapján, amely megegyezik a külső munkafüzet adatforrás‑típusával.

Ez a Java‑kód demonstrálja a műveletet:

```java
// Létrehoz egy példányt a Presentation osztályból
Presentation pres = new Presentation("chart.pptx");
try {
    ISlide slide = pres.getSlides().get_Item(1);
    IChart chart = (IChart)slide.getShapes().get_Item(0);
    int sourceType = chart.getChartData().getDataSourceType();
    
    if (sourceType == ChartDataSourceType.ExternalWorkbook)
    {
        String path = chart.getChartData().getExternalWorkbookPath();
    }
	
	// Elmenti a prezentációt
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Diagramadatok szerkesztése**

A külső munkafüzetek adatainak szerkesztése ugyanúgy történik, mint a belső munkafüzetek tartalmának módosítása. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

Ez a Java‑kód a leírt folyamat megvalósítása:

```java
// Létrehoz egy példányt a Presentation osztályból
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

### **Munkafüzet helyreállítása a diagram‑gyorsítótárból**

Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzetet használ, az Aspose.Slides helyreállíthatja a diagram munkafüzetét a prezentációban tárolt gyorsítótárazott adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/)‑t, konfigurálja a [SpreadsheetOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/spreadsheetoptions/)‑szel, és hívja meg az [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-)‑t **true**‑ra a prezentáció megnyitása előtt.

Az alábbi Java‑példa megnyit egy prezentációt, amelynek diagramja egy nem elérhető külső munkafüzetre hivatkozik, és a helyreállított adatokat az [IChart.getChartData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichart/#getChartData--) és az [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) segítségével éri el:

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Olvassa vagy módosítsa itt a helyreállított munkafüzet adatait.
} finally {
    presentation.dispose();
}
```

Ha a külső munkafüzet nem elérhető, és a helyreállítás le van tiltva, az Aspose.Slides kivételt dob. Engedélyezze a helyreállítást csak akkor, ha a gyorsítótárazott diagramadatok használata elfogadható tartalék, mivel a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzetben a prezentáció utolsó frissítése óta végzett módosításokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzethez van‑e csatolva?**

Igen. A diagram rendelkezik egy [data source type](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) és egy [path to an external workbook](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) attribútummal; ha a forrás külső munkafüzet, kiolvashatja a teljes útvonalat, hogy megbizonyosodjon arról, hogy egy külső fájlt használ.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, azt a rendszer automatikusan abszolút útvonalra konvertálja. Ez a projekt hordozhatóságát segíti, de vegye figyelembe, hogy a prezentáció a PPTX‑fájlban tárolja az abszolút útvonalat.

**Használhatók a hálózati erőforrásokon/megosztásokon lévő munkafüzetek?**

Igen, ilyen munkafüzetek használhatók külső adatforrásként. A távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ből nem támogatott – csak forrásként alkalmazhatók.

**Az Aspose.Slides felülírja a külső XLSX‑et a prezentáció mentésekor?**

Nem. A prezentáció tárol egy [link to the external file](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) és ezt használja az adatok beolvasásához. A külső fájl maga nem módosul a prezentáció mentésekor.

**Mit tegyek, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad jelszót a csatoláskor. Általános megoldás, hogy előre eltávolítja a védelmet, vagy egy dekódolt másolatot készít (például a [Aspose.Cells](/cells/androidjava/) használatával), és arra a másolatra hivatkozik.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram saját hivatkozást tárol. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagram esetében megjelenik a következő adatbetöltéskor.