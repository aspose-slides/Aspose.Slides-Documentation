---
title: "Diagrammunkafüzetek kezelése prezentációkban Java használatával"
linktitle: "Diagrammunkafüzet"
type: docs
weight: 70
url: /hu/java/chart-workbook/
keywords:
  - "diagrammunkafüzet"
  - "diagramadat"
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
description: "Fedezze fel az Aspose.Slides for Java-t: könnyedén kezelje a diagrammunkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse prezentációja adatait."
---
## **Áttekintés**

Ez a cikk ismerteti, hogyan dolgozhatunk diagrammunkafüzetekkel az Aspose.Slides-ben. Bemutatja, hogyan olvashatunk és írhatunk diagramadatokat munkafüzet adatfolyamokon keresztül, hogyan használhatjuk a munkafüzet cellákat diagramadatcímkeként, hogyan érhetjük el a munkalap‑gyűjteményeket, és hogyan adhatjuk meg az adatforrás típusát a diagramértékekhez.

Továbbá kitér a külső munkafüzetek diagramadatforrásként való használatára. A példák bemutatják, hogyan hozhatunk létre és rendelhetünk egy külső munkafüzetet, hogyan kérhetjük le egy diagramhoz kapcsolt külső munkafüzet útvonalát, és hogyan szerkeszthetjük a diagramadatokat, ha a munkafüzet elérhető.

## **Diagramadatok olvasása és írása munkafüzetből**

Az Aspose.Slides biztosítja a [ReadWorkbookStream](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartData#readWorkbookStream--) és a [WriteWorkbookStream](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) metódusokat, amelyek lehetővé teszik diagramadatmunkafüzetek (az Aspose.Cells segítségével szerkesztett diagramadatokat tartalmazó) olvasását és írását. **Megjegyzés**: a diagramadatokat ugyanúgy kell elrendezni, vagy hasonló szerkezetűnek kell lenniük, mint a forrás.

Ez a Java kód egy mintaműveletet mutat be:

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

## **Munkafüzet cella beállítása diagramadatcímkeként**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból.  
2. Szerezze be a dia hivatkozását az indexén keresztül.  
3. Adjon hozzá egy Bubbla diagramot némi adattal.  
4. Érje el a diagram sorozatát.  
5. Állítsa be a munkafüzet cellát adatcímkeként.  
6. Mentse a prezentációt.

Ez a Java kód megmutatja, hogyan állítható be egy munkafüzetcellát diagramadatcímkeként:

```java
String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Létrehozza a prezentációfájlt képviselő Presentation osztályt
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
    IChartDataWorkbook wb =  chart.getChartData().getChartDataWorkbook();
    for (int i = 0; i < wb.getWorksheets().size(); i++)
        System.out.println(wb.getWorksheets().get_Item(i).getName());
} finally {
    if (pres != null) pres.dispose();
}
```

## **Az adatforrás típusának meghatározása**

Ez a Java kód megmutatja, hogyan adhatunk meg egy típust egy adatforráshoz:

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

## **Nem támogatott beágyazott munkafüzet formátumok észlelése**

Az Aspose.Slides nem támogatja az egyes diagramokba beágyazható Excel bináris munkafüzet (.xlsb) formátumot. Használhatja a `getEmbeddedWorkbookType` metódust a [IChartData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartData) együtt a [WorkbookType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/WorkbookType) felsorolással, hogy észlelje a nem támogatott formátumokat, és kihagyja az ilyen diagramokat.

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

        // Itt olvashatja vagy módosíthatja a diagram munkafüzet adatait.
    }
} finally {
    presentation.dispose();
}
```

## **Külső munkafüzet**

{{% alert color="primary" %}} 
Az [Aspose.Slides 19.4](https://docs.aspose.com/slides/hu/java/aspose-slides-for-java-19-4-release-notes/) verzióban bevezettük a külső munkafüzetek diagramok adatforrásaként való támogatását. 
{{% /alert %}} 

### **Külső munkafüzet létrehozása**

A **`readWorkbookStream`** és **`setExternalWorkbook`** metódusok használatával létrehozhat egy külső munkafüzetet a semmiből, vagy egy belső munkafüzetet külsővé tehet.

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

A **`setExternalWorkbook`** metódus használatával egy külső munkafüzetet adhatunk egy diagram adatforrásaként. Ez a metódus a külső munkafüzet útvonalának frissítésére is használható (ha az át lett helyezve).

Bár nem szerkesztheti a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait, továbbra is használhat ilyen munkafüzeteket külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzethez, az automatikusan teljes útvonallá alakul.

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

A `ChartData` paraméter (a `setExternalWorkbook` metódus alatt) azt határozza meg, hogy egy Excel munkafüzet betöltődjön‑e vagy sem.

* Ha a `ChartData` értéke `false`, csak a munkafüzet útvonala frissül – a diagramadatok nem töltődnek be, és nem frissülnek a célmunkafüzetről. Ezt a beállítást akkor használja, ha a célmunkafüzet nem létezik vagy nem érhető el.  
* Ha a `ChartData` értéke `true`, a diagramadatok a célmunkafüzetről frissülnek.

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

### **Külső adatforrás munkafüzet útvonalának lekérése egy diagramhoz**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból.  
2. Szerezze be a dia hivatkozását az indexén keresztül.  
3. Hozzon létre egy objektumot a diagram alakzatához.  
4. Hozzon létre egy objektumot a forrás (`ChartDataSourceType`) típusához, amely a diagram adatforrását reprezentálja.  
5. Adja meg a megfelelő feltételt a forrástípus és a külső munkafüzet adatforrás típusa közötti egyezés alapján.

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
	
	// Mentse a prezentációt
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Diagramadatok szerkesztése**

A külső munkafüzetek adatait ugyanúgy szerkesztheti, ahogy a belső munkafüzetek tartalmát módosítaná. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

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

### **Munkafüzet helyreállítása a diagram gyorsítótárából**

Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzetet használ, az Aspose.Slides képes a diagram munkafüzetét a prezentációban gyorsítótárazott adatokból rekonstruálni. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/) objektumot, konfigurálja a [SpreadsheetOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/spreadsheetoptions/)‑al, és a prezentáció megnyitása előtt hívja meg az [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) metódust `true` értékkel.

A következő Java példa megnyit egy prezentációt, amelynek diagramja egy nem elérhető külső munkafüzetre hivatkozik, és a helyreállított adatokat a [IChart.getChartData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichart/#getChartData--) és a [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) segítségével éri el:

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Itt olvashatja vagy módosíthatja a helyreállított munkafüzet adatait.
} finally {
    presentation.dispose();
}
```

Ha a külső munkafüzet nem elérhető, és a helyreállítás le van tiltva, az Aspose.Slides kivételt dob. A helyreállítást csak akkor engedélyezze, ha a gyorsítótárazott diagramadatok használata elfogadható tartalék, mivel a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzetben a prezentáció legutóbbi frissítése után történt változtatásokat.

## **GYIK**

**Megállapíthatom, hogy egy adott diagram külső vagy beágyazott munkafüzethez kapcsolódik‑e?**  
Igen. A diagram rendelkezik egy [adatforrás típussal](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chartdata/#getDataSourceType--) és egy [úttal egy külső munkafüzethez](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--); ha a forrás egy külső munkafüzet, elolvashatja a teljes útvonalat, hogy megállapítsa, külső fájlt használ-e.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**  
Igen. Relatív útvonal megadása esetén az automatikusan abszolút útvonalra konvertálódik. Ez előnyös a projekt hordozhatósága szempontjából; azonban a prezentáció az abszolút útvonalat tárolja a PPTX fájlban.

**Használhatok olyan munkafüzeteket, amelyek hálózati erőforrásokon/megosztott meghajtókon vannak?**  
Igen, az ilyen munkafüzetek használhatók külső adatforrásként. A távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ből nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja a külső XLSX‑t a prezentáció mentésekor?**  
Nem. A prezentáció egy [hivatkozást tárol a külső fájlra](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) és ezt használja az adatok olvasásához. A külső fájl maga nem módosul a prezentáció mentésekor.

**Mit tegyek, ha a külső fájl jelszóval védett?**  
Az Aspose.Slides nem fogad jelszót a hivatkozáskor. Általános megoldás, hogy előre eltávolítja a védelmet, vagy egy visszafejtett másolatot készít (például az [Aspose.Cells](/cells/java/) használatával), majd arra hivatkozik.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**  
Igen. Minden diagram a saját hivatkozását tárolja. Ha több diagram ugyanarra a fájlra mutat, a fájl frissítése minden diagram esetében megjelenik a következő adatbetöltéskor.