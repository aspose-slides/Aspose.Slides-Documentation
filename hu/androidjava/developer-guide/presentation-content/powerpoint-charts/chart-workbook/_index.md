---
title: Diagrammunkafüzetek kezelése Androidos prezentációkban
linktitle: Diagram munkafüzet
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
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Androidot Java-val: egyszerűen kezelje a diagrammunkafüzeteket PowerPoint és OpenDocument formátumokban, hogy hatékonyabbá tegye prezentációs adatait."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan dolgozhat a diagram munkafüzetekkel az Aspose.Slides-ban. Bemutatja, hogyan lehet munkafüzet‑adatfolyamok segítségével olvasni és írni diagramadatokat, a munkafüzet‑cellákat diagramadatcímkeként használni, hozzáférni a munkalap‑gyűjteményekhez, és meghatározni az adatforrás típusát a diagramértékekhez.

Emellett tárgyalja a külső munkafüzetek diagramadat‑forrásként való használatát. A példák bemutatják, hogyan hozhat létre és rendelhet hozzá egy külső munkafüzetet, hogyan kérdezheti le egy diagramhoz csatolt külső munkafüzet elérési útját, és hogyan szerkesztheti a diagramadatokat, ha a munkafüzet elérhető.

## **Diagramadatok olvasása és írása munkafüzetből**

Az Aspose.Slides a [ReadWorkbookStream](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) és a [WriteWorkbookStream](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) metódusokat biztosítja, amelyek lehetővé teszik diagramadat‑munkafüzetek (az Aspose.Cells‑szal szerkesztett diagramadatokat tartalmazó) olvasását és írását. **Megjegyzés**: a diagramadatoknak ugyanúgy vagy a forráshoz hasonló szerkezetben kell legyenek rendezve.

Ez a Java kód egy példaműveletet mutat be:

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

## **Munkafüzet‑cellát használjon diagramadat‑címkeként**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Adjon hozzá egy buborékdiagramot némi adattal.  
4. Érje el a diagram sorozatát.  
5. Állítsa be a munkafüzet‑cellát adatcímkeként.  
6. Mentse a prezentációt.

Ez a Java kód megmutatja, hogyan állítsa be a munkafüzet‑cellát diagramadat‑címkeként:

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

Ez a Java kód egy olyan műveletet mutat be, ahol a [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) metódust használják a munkalap‑gyűjtemény eléréséhez:

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

## **Az adatforrás típusának meghatározása**

Ez a Java kód megmutatja, hogyan adjon meg egy típust egy adatforráshoz:

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

## **Nem támogatott beágyazott munkafüzetformátumok felismerése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumát, amelyet egyes diagramokba be lehet ágyazni. Használhatja a `getEmbeddedWorkbookType` metódust az [IChartData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartData) osztályon együtt a [WorkbookType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/WorkbookType) enumerációval, hogy felismerje a nem támogatott formátumokat, és kihagyja az érintett diagramokat.

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
            // A beágyazott munkafüzet .xlsb formátumban van, amely nem támogatott.
            continue;
        }

        // Olvassa vagy módosítsa itt a diagram munkafüzet adatait.
    }
} finally {
    presentation.dispose();
}
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzeteket diagramok adatforrásaként.

### **Külső munkafüzet létrehozása**

A **`readWorkbookStream`** és a **`setExternalWorkbook`** metódusok használatával készíthet egy külső munkafüzetet az alapoktól, vagy egy belső munkafüzetet külsővé tehet.

Ez a Java kód bemutatja a külső munkafüzet létrehozási folyamatát:

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

A **`setExternalWorkbook`** metódus használatával külső munkafüzetet rendelhet egy diagramhoz adatforrásként. Ez a metódus arra is használható, hogy frissítse a külső munkafüzet elérési útját (ha a fájlt áthelyezték).

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem szerkesztheti közvetlenül, ilyen munkafüzetek továbbra is használhatók külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzethez, az automatikusan teljes útvonallá alakul.

Ez a Java kód megmutatja, hogyan állítsa be egy külső munkafüzetet:

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

A `ChartData` paraméter (a `setExternalWorkbook` metódus alatt) azt határozza meg, hogy egy Excel‑munkafüzet be lesz‑töltve vagy sem.

* Ha a `ChartData` értéke **false**, csak a munkafüzet útvonala frissül – a diagramadatok nem lesznek betöltve vagy frissítve a célmunkafüzetről. Ezt a beállítást akkor érdemes használni, ha a célmunkafüzet nem létezik vagy nem érhető el.  
* Ha a `ChartData` értéke **true**, a diagramadatok a célmunkafüzetről frissülnek.

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

### **A diagram külső adatforrás‑munkafüzetének útvonalának lekérése**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.  
2. Szerezze meg egy dia hivatkozását az indexe alapján.  
3. Hozzon létre egy objektumot a diagram alakzat számára.  
4. Hozzon létre egy objektumot a forrás (`ChartDataSourceType`) típushoz, amely a diagram adatforrását képviseli.  
5. Adja meg a megfelelő feltételt a forrástípus és a külső munkafüzet adatforrástípus egyezőségén alapulva.

Ez a Java kód bemutatja a műveletet:

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

A külső munkafüzetek adatait ugyanúgy szerkesztheti, ahogyan a belső munkafüzetek tartalmát módosítja. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

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

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram egy külső vagy beágyazott munkafüzethez van‑e csatolva?**  
Igen. A diagramnak van egy [adatforrás típusa](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) és egy [útvonala a külső munkafüzethez](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); ha a forrás egy külső munkafüzet, a teljes útvonal kiolvasható, így ellenőrizhető, hogy külső fájlt használ-e.

**Támogatottak a relatív útvonalak külső munkafüzetekhez, és hogyan tárolódnak?**  
Igen. Ha relatív útvonalat ad meg, az automatikusan átalakul abszolút útvonallá. Ez a projekt hordozhatóságát segíti, de a PPTX fájlban az abszolút útvonal lesz tárolva.

**Használhatok munkafüzeteket hálózati erőforrásokon/megosztásokon?**  
Igen, az ilyen munkafüzetek használhatók külső adatforrásként. A távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ból nem támogatott – csak forrásként használhatók.

**Felülírja az Aspose.Slides a külső XLSX‑et a prezentáció mentésekor?**  
Nem. A prezentáció egy [hivatkozást tárol a külső fájlra](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--), és ezt használja az adatok olvasásához. A külső fájl magát nem módosítja a mentés során.

**Mit tegyek, ha a külső fájl jelszóval van védve?**  
Az Aspose.Slides nem fogad jelszót a csatoláskor. Általános megoldás a védelem előzetes eltávolítása vagy egy dekódolt másolat (például az [Aspose.Cells](/cells/androidjava/) segítségével) előkészítése, majd ahhoz való hivatkozás.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**  
Igen. Minden diagram a saját hivatkozását tárolja. Ha több diagram ugyanarra a fájlra mutat, a fájl frissítése a következő adatbetöltéskor minden diagramnál megjelenik.