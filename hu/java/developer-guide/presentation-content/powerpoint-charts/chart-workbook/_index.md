---
title: "Diagrammunkafüzetek kezelése prezentációkban Java használatával"
linktitle: "Diagrammunkafüzet"
type: docs
weight: 70
url: /hu/java/chart-workbook/
keywords:
- diagrammunkafüzet
- diagramadat
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
- Java
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Java-t: egyszerűen kezelje a diagrammunkafüzeteket PowerPoint és OpenDocument formátumokban, hogy optimalizálja a prezentáció adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet diagramműködőkönyvekkel dolgozni az Aspose.Slides-ban. Megmutatja, hogyan lehet munkafüzet‑áramokon keresztül olvasni és írni diagramadatokat, munkafüzet‑cellákat használni diagramcímkeként, elérni a munkalap‑gyűjteményeket, és megadni az adatforrás típusát a diagramértékekhez.

Továbbá tárgyalja a külső munkafüzetek diagramadat‑forrásként való használatát. A példák bemutatják, hogyan hozhatunk létre és rendeljünk hozzá egy külső munkafüzetet, hogyan kérhetjük le egy diagramhoz kapcsolt külső munkafüzet útvonalát, valamint hogyan szerkeszthetjük a diagramadatokat, ha a munkafüzet elérhető.

## **Diagramadatok olvasása és írása munkafüzettel**
Az Aspose.Slides a [ReadWorkbookStream](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartData#readWorkbookStream--) és a [WriteWorkbookStream](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) metódusokat biztosítja, amelyek lehetővé teszik diagramadat‑munkafüzetek (Aspose.Cells‑szel szerkesztett diagramadatokat tartalmazó) olvasását és írását. **Megjegyzés**: a diagramadatoknak ugyanúgy kell felépülniük, vagy hasonló struktúrával kell rendelkezniük, mint a forrásnak.

Ez a Java‑kód bemutat egy mintaműveletet:

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

### **Diagramelrendezés ellenőrzése a munkafüzet módosítása után**

Ha egy beágyazott munkafüzetet egy módosítottal helyettesítünk, a diagram megtartja az eredeti sorozat‑ és kategória‑gyűjteményeit. Ez az inkonzisztencia azt okozhatja, hogy a `chart.validateChartLayout()` `ArgumentOutOfRangeException`‑t (paraméter: index) dob. Az kivétel elkerülése érdekében töröljük a meglévő sorozatokat és kategóriákat **azelőtt**, hogy a frissített munkafüzetet visszaírnánk a diagramba.

```java
// A munkafüzetáram módosítása után (például Aspose.Cells használatával)
byte[] updatedWorkbook = baos.toByteArray();

// Törölje a meglévő adatreferenciákat.
chart.getChartData().getSeries().clear();
chart.getChartData().getCategories().clear();

// Írja vissza a frissített munkafüzetet a diagramhoz.
chart.getChartData().writeWorkbookStream(updatedWorkbook);

// Most a validálás sikeres.
chart.validateChartLayout();
```

A gyűjtemények törlése biztosítja, hogy a diagramadat‑szerkezet illeszkedjen az új munkafüzethez, így a `validateChartLayout()` hiba nélkül lefuthat.

## **Munkafüzet‑cellát beállítani diagramadat‑címkeként**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból.  
2. Kapjon referenciát egy diára az indexén keresztül.  
3. Adjon hozzá egy Buborék‑diagramot némi adattal.  
4. Hozzáférés a diagram sorozatához.  
5. Állítsa be a munkafüzet‑cellát adatcímkeként.  
6. Mentse a prezentációt.

Ez a Java‑kód megmutatja, hogyan állítható be egy munkafüzet‑cellát diagramadat‑címkeként:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Példányosít egy prezentációs osztályt, amely egy prezentációs fájlt képvisel
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

Ez a Java‑kód bemutat egy műveletet, ahol a [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) metódust használják a munkalap‑gyűjtemény eléréséhez:

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

## **Az adatforrás típusának megadása**

Ez a Java‑kód mutatja, hogyan adható meg egy típus egy adatforráshoz:

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

## **Nem támogatott beágyazott munkafüzet‑formátumok felderítése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely néhány diagramhoz beágyazható. A `getEmbeddedWorkbookType` metódust az [IChartData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartData) interfészen, a [WorkbookType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/WorkbookType) felsorolással együtt használva felderíthetőek a nem támogatott formátumok, és kihagyhatók a diagramok.

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
            // Beágyazott munkafüzet .xlsb formátumban van, amely nem támogatott.
            continue;
        }

        // Itt olvassa vagy módosítsa a diagram munkafüzet adatait.
    }
} finally {
    presentation.dispose();
}
```

## **Külső munkafüzet**

{{% alert color="info" %}} 
Az [Aspose.Slides 19.4](https://docs.aspose.com/slides/hu/java/aspose-slides-for-java-19-4-release-notes/)‑ben bevezettük a külső munkafüzetek diagramok adatforrásaként való támogatását.
{{% /alert %}} 

### **Külső munkafüzet létrehozása**

A **`readWorkbookStream`** és a **`setExternalWorkbook`** metódusokkal létrehozhatunk egy külső munkafüzetet a semmiből, vagy egy belső munkafüzetet külsővé tehetünk.

Ez a Java‑kód demonstrálja a külső munkafüzet létrehozási folyamatát:

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

### **Külső munkafüzet beállítása**

A **`setExternalWorkbook`** metódussal egy külső munkafüzetet rendelhetünk egy diagramhoz adatforrásként. Ezzel a metódussal frissíthető a külső munkafüzet útvonala is (ha az áthelyezésre került).

Bár a távoli helyen vagy erőforrásban tárolt munkafüzetek adatainak közvetlen szerkesztése nem lehetséges, továbbra is használhatók külső adatforrásként. Ha relatív útvonalat adunk meg egy külső munkafüzethez, az automatikusan teljes útvonallá alakul.

Ez a Java‑kód megmutatja, hogyan állítható be egy külső munkafüzet:

```java
import com.aspose.slides.*;

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

A `setExternalWorkbook` metódus második (`boolean`) paramétere azt határozza meg, hogy egy Excel‑munkafüzet be legyen‑töltve vagy sem.

* Ha értéke `false`, csak a munkafüzet útvonala frissül – a diagramadatok nem töltődnek be vagy frissülnek a cél‑munkafüzettől. Ez a beállítás akkor hasznos, ha a cél‑munkafüzet nem létezik vagy nem érhető el.  
* Ha értéke `true`, a diagramadatok frissülnek a cél‑munkafüzettel.

```java
import com.aspose.slides.*;

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

### **Diagram külső adatforrás‑munkafüzet útvonalának lekérdezése**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból.  
2. Kapjon referenciát egy diára az indexén keresztül.  
3. Hozzon létre egy objektumot a diagram alakzathoz.  
4. Hozzon létre egy objektumot a forrástípus (`ChartDataSourceType`) számára, amely a diagram adatforrását képviseli.  
5. Adja meg a megfelelő feltételt, annak alapján, hogy a forrástípus megegyezik‑e a külső munkafüzet adatforrástípussal.

Ez a Java‑kód demonstrálja a műveletet:

```java
import com.aspose.slides.*;

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
	
	// Mentés a prezentáció
    pres.save("result.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Diagramadatok szerkesztése**

A külső munkafüzetek adatait ugyanúgy szerkeszthetjük, mint a belső munkafüzetekét. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

Ez a Java‑kód az ismertetett folyamat megvalósítását mutatja:

```java
import com.aspose.slides.*;

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

### **Munkafüzet helyreállítása a diagram gyorsítótárából**

Ha egy diagram egy hiányzó vagy elérhetetlen külső munkafüzetet használ, az Aspose.Slides a prezentációban tárolt gyorsítótárazott adatból rekonstruálhatja a diagram‑munkafüzetet. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/) objektumot, állítsa be a [SpreadsheetOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/spreadsheetoptions/)‑t, és hívja meg az [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) metódust `true`‑ra a prezentáció megnyitása előtt.

Az alábbi Java‑példa megnyit egy prezentációt, amelynek diagramja egy nem elérhető külső munkafüzetre hivatkozik, és a helyreállított adatokat a [IChart.getChartData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichart/#getChartData--) és a [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) segítségével érheti el:

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Olvassa vagy módosítsa a helyreállított munkafüzet adatait itt.
} finally {
    presentation.dispose();
}
```

Ha a külső munkafüzet nem érhető el, és a helyreállítás ki van kapcsolva, az Aspose.Slides kivételt dob. Engedélyezze a helyreállítást csak akkor, ha a gyorsítótárban tárolt diagramadatok használata elfogadható tartalék, mivel a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzetben a prezentáció utolsó frissítése óta végzett módosításokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzethez kapcsolódik?**

Igen. A diagram rendelkezik egy [data source type](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chartdata/#getDataSourceType--) és egy [path to an external workbook](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) tulajdonsággal; ha a forrás egy külső munkafüzet, kiolvashatja a teljes útvonalat, hogy megbizonyosodjon arról, hogy egy külső fájlt használ.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, az automatikusan átalakul abszolút útvonallá. Ez projekt‑portabilitást tesz lehetővé; azonban a prezentáció az abszolút útvonalat tárolja a PPTX‑fájlban.

**Használhatók hálózati erőforrásokon/megosztásokon lévő munkafüzetek?**

Igen, az ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ból nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja a külső XLSX‑et a prezentáció mentésekor?**

Nem. A prezentáció egy [link to the external file](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) tárol, és azt használja az adatok olvasásához. A külső fájl maga nem módosul a prezentáció mentésekor.

**Mit tegyek, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad el jelszót a hivatkozáskor. Általános megoldás a védelem előzetes eltávolítása vagy egy titkosítás nélküli másolat előkészítése (például az [Aspose.Cells](/cells/java/) használatával), majd arra a másolatra hivatkozni.

**Több diagram is hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram saját hivatkozást tárol. Ha mind ugyanarra a fájlra mutat, a fájl frissítése minden diagramon megjelenik a következő adatbetöltéskor.