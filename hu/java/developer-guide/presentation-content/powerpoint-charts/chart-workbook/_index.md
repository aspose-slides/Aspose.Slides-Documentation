---
title: "Diagrammunkafüzetek kezelése prezentációkban Java használatával"
linktitle: "Diagrammunkafüzet"
type: docs
weight: 70
url: /hu/java/chart-workbook/
keywords:
- diagrammunkafüzet
- diagramadat
- munkafüzetcella
- adatcímke
- munkalap
- adatforrás
- külső munkafüzet
- külső adat
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Java-t: könnyedén kezelje a diagrammunkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse prezentációja adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet dolgozni diagram-munkafüzetekkel az Aspose.Slides-ban. Megmutatja, hogyan lehet be‑ és kinyerni a diagramadatokat munkafüzet‑adatfolyamokon keresztül, hogyan lehet a munkafüzet cellákat diagramadat‑címkeként használni, hogyan lehet a munkalap‑gyűjteményeket elérni, és hogyan lehet megadni az adatforrás típusát a diagramértékekhez.  
A cikk továbbá kitér a külső munkafüzetek diagramadat‑forrásként való használatára is. A példák bemutatják, hogyan hozhatunk létre és rendelhetünk hozzá egy külső munkafüzetet, hogyan kérhetjük le egy diagramhoz kapcsolt külső munkafüzet útvonalát, és hogyan szerkeszthetjük a diagramadatokat, ha a munkafüzet elérhető.

## **Diagramadatok be- és kiolvasása munkafüzetből**

Az Aspose.Slides a [ReadWorkbookStream](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartData#readWorkbookStream--) és a [WriteWorkbookStream](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) metódusokat biztosítja, amelyek lehetővé teszik a diagramadat‑munkafüzetek (Aspose.Cells‑szel szerkesztett diagramadatokat tartalmazó) be‑ és kiolvasását. **Megjegyzés**: a diagramadatoknak ugyanúgy kell felépülniük, vagy hasonló struktúrával kell rendelkezniük, mint a forrás.  

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

## **Munkafüzet‑cellát beállítása diagramadat‑címkeként**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból.  
2. Szerezze be a dia referenciáját az indexe alapján.  
3. Adjon hozzá egy Buborék‑diagramot némi adattal.  
4. Érje el a diagram sorozatait.  
5. Állítsa be a munkafüzet celláját adatcímkének.  
6. Mentse a bemutatót.  

Ez a Java kód bemutatja, hogyan állítható be a munkafüzet cellája diagramadat‑címkeként:

```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Létrehozza a prezentációs fájlt képviselő prezentáció osztályt
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

Ez a Java kód egy olyan műveletet mutat be, ahol a [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) metódust használják a munkalap‑gyűjtemény eléréséhez:

```java
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.Pie, 50, 50, 400, 500);
    IChartDataWorkbook wb =  chart.getChartData(). .getChartDataWorkbook();
    for (int i = 0; i < wb.getWorksheets().size(); i++)
        System.out.println(wb.getWorksheets().get_Item(i).getName());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Adatforrás típusának megadása**

Ez a Java kód megmutatja, hogyan lehet egy adatforrás típusát megadni:

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

## **Nem támogatott beágyazott munkafüzetformátumok észlelése**

Az Aspose.Slides nem támogatja az egyes diagramokba beágyazható Excel bináris munkafüzet (.xlsb) formátumot. A `getEmbeddedWorkbookType` metódust az [IChartData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartData)‑n és a [WorkbookType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/WorkbookType) felsorolással együtt használhatja a nem támogatott formátumok felismerésére, és a diagramok kihagyására.

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

        // Olvassa vagy módosítsa a diagram munkafüzet adatait itt.
    }
} finally {
    presentation.dispose();
}
```

## **Külső munkafüzet**

{{% alert color="primary" %}} 
A [Aspose.Slides 19.4](https://docs.aspose.com/slides/hu/java/aspose-slides-for-java-19-4-release-notes/) verzióban bevezettük a külső munkafüzetek diagramadat‑forrásként való támogatását. 
{{% /alert %}} 

### **Külső munkafüzet létrehozása**

A **`readWorkbookStream`** és **`setExternalWorkbook`** metódusok használatával vagy teljesen új külső munkafüzetet hozhat létre, vagy egy belső munkafüzetet tehet külsővé.  

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

Az **`setExternalWorkbook`** metódussal egy külső munkafüzetet rendelhet egy diagram adatforrásaként. Ez a metódus használható a külső munkafüzet útvonalának frissítésére is (ha az áthelyezésre került).  
Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem szerkesztheti, továbbra is felhasználhatja ezeket külső adatforrásként. Ha egy külső munkafüzet relatív útvonala van megadva, az automatikusan teljes útvonallá konvertálódik.  

Ez a Java kód megmutatja, hogyan állítható be egy külső munkafüzet:

```java
// Létrehozza a Presentation osztály egy példányát
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

A `ChartData` paraméter (a `setExternalWorkbook` metódus alatt) azt határozza meg, hogy Excel‑munkafüzetet betöltsünk‑e vagy sem.  

* Ha a `ChartData` értéke `false`, csak a munkafüzet útvonala frissül – a diagramadatok nem töltődnek be, és nem frissülnek a célmunkafüzetből. Ezt a beállítást akkor érdemes használni, ha a célmunkafüzet nem létezik vagy nem érhető el.  
* Ha a `ChartData` értéke `true`, a diagramadatok a célmunkafüzetből frissülnek.  

```java
// Létrehozza a Presentation osztály egy példányát
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

### **Diagram külső adatforrás‑munkafüzetének útvonalának lekérdezése**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból.  
2. Szerezze be a dia referenciáját az indexe alapján.  
3. Hozzon létre egy objektumot a diagram alakzatához.  
4. Hozzon létre egy objektumot a forrás (`ChartDataSourceType`) típushoz, amely a diagram adatforrását képviseli.  
5. Adja meg a megfelelő feltételt attól függően, hogy a forrástípus megegyezik-e a külső munkafüzet adatforrás típusával.  

Ez a Java kód bemutatja a műveletet:

```java
// Létrehozza a Presentation osztály egy példányát
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

A külső munkafüzetek adatait ugyanúgy szerkesztheti, ahogy a belső munkafüzetek tartalmát módosítja. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.  

Ez a Java kód a leírt folyamat megvalósítását mutatja:

```java
// Létrehozza a Presentation osztály egy példányát
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

**Meg tudom állapítani, hogy egy adott diagram külső vagy beágyazott munkafüzethez van‑e csatolva?**

Igen. A diagram rendelkezik egy [adatforrás típussal](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chartdata/#getDataSourceType--) és egy [külső munkafüzet útvonalával](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); ha a forrás egy külső munkafüzet, leolvashatja a teljes útvonalat, hogy megbizonyosodjon arról, hogy külső fájlt használ.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, az automatikusan abszolút útvonalra konvertálódik. Ez kényelmes a projekt hordozhatósága szempontjából; ugyanakkor vegye figyelembe, hogy a bemutató az abszolút útvonalat tárolja a PPTX fájlban.

**Használhatok hálózati erőforrásokon/megosztott helyeken lévő munkafüzeteket?**

Igen, ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ból nem támogatott – csak forrásként használhatók.

**Felülírja az Aspose.Slides a külső XLSX‑et a bemutató mentésekor?**

Nem. A bemutató egy [linket tárol a külső fájlra](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) és azt használja az adatok beolvasásához. A külső fájl maga nem módosul a bemutató mentésekor.

**Mit tegyek, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogadja el a jelszót a hivatkozáskor. Egy gyakori megoldás, hogy előre eltávolítja a védelmet, vagy egy dekódolt másolatot készít (például a [Aspose.Cells](/cells/java/) használatával), és ehhez a másolathoz hivatkozik.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram a saját linkjét tárolja. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése a következő adatbetöltéskor minden diagramon megjelenik.