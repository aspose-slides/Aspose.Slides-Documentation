---
title: Diagrammunkafüzetek kezelése prezentációkban Androidon
linktitle: Diagram munkafüzet
type: docs
weight: 70
url: /hu/androidjava/chart-workbook/
keywords:
- diagram munkafüzet
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
- Android
- Java
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Android-et Java segítségével: könnyedén kezelje a diagrammunkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse a prezentáció adatait."
---
## **Áttekintés**

Ez a cikk ismerteti, hogyan dolgozhat a diagram munkafüzetekkel az Aspose.Slides-ben. Bemutatja, hogyan olvashat és írhat diagramadatokat munkafüzet áramlatokon keresztül, hogyan használhat munkafüzet cellákat diagramadatcímkeként, hogyan érheti el a munkalapgyűjteményeket, és hogyan adhatja meg az adatforrás típusát a diagramértékekhez.

Továbbá bemutatja a külső munkafüzetek diagramadat-forrásként való használatát. A példák azt mutatják, hogyan hozhat létre és rendelhet hozzá egy külső munkafüzetet, hogyan kérdezheti le egy diagramhoz kapcsolt külső munkafüzet útvonalát, és hogyan szerkesztheti a diagramadatokat, ha a munkafüzet elérhető.

## **Olvasás és írás diagramadatok munkafüzetből**
Aspose.Slides biztosítja a [ReadWorkbookStream](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) és a [WriteWorkbookStream](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) metódusokat, amelyek lehetővé teszik a diagramadat-munkafüzetek (az Aspose.Cells‑szel szerkesztett diagramadatokat tartalmazó) olvasását és írását. **Megjegyzés**: a diagramadatoknak ugyanúgy kell felépülniük, vagy hasonló struktúrával kell rendelkezniük, mint a forrás.

Ez a Java‑kód egy példaműveletet mutat be:

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

### **Diagram elrendezésének ellenőrzése a munkafüzet módosítása után**
Amikor egy beágyazott munkafüzetet egy módosítottval helyettesít, a diagram megtartja az eredeti sorozat‑ és kategória‑gyűjteményeit. Ez az eltérés az [IChart.validateChartLayout](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChart#validateChartLayout--) hibához vezethet, amely indexkiesés hibát dob. Törölje a meglévő sorozatokat és kategóriákat, mielőtt a frissített munkafüzetet visszaírná a diagramba.

```java
// A munkafüzet áramlat módosítása után (pl. az Aspose.Cells használatával)
byte[] updatedWorkbook = chartData.readWorkbookStream();

// A meglévő adat hivatkozások törlése.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

A gyűjtemények törlése biztosítja, hogy a diagramadat‑struktúra egyezzen az új munkafüzettel, ezáltal a `validateChartLayout` hiba nélkül lefuthat.

## **Munkafüzet cella beállítása diagramadatcímkeként**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.  
1. Szerezze meg egy dia referenciáját indexe alapján.  
1. Adjon hozzá egy buborékdiagramot némi adattal.  
1. Érje el a diagram sorozatát.  
1. Állítsa be a munkafüzet cellát adatcímkének.  
1. Mentse a prezentációt.

Ez a Java‑kód bemutatja, hogyan állíthat be egy munkafüzet cellát diagramadatcímkeként:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Példányosít egy prezentáció osztályt, amely egy prezentációfájlt reprezentál
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

Ez a Java‑kód egy műveletet demonstrál, ahol a [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) metódust használják egy munkalapgyűjtemény elérésére:

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

## **Adatforrás típusának meghatározása**

Ez a Java‑kód megmutatja, hogyan adhat meg egy típust egy adatforráshoz:

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

## **Nem támogatott beágyazott munkafüzet formátumok észlelése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely bizonyos diagramokba beágyazható. A `getEmbeddedWorkbookType` metódust az [IChartData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartData) osztályon együtt a [WorkbookType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/WorkbookType) felsorolással használhatja a nem támogatott formátumok észlelésére és az ilyen diagramok kihagyására.

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

Az Aspose.Slides külső munkafüzeteket támogat adatforrásként diagramokhoz.

### **Külső munkafüzet létrehozása**

A **`readWorkbookStream`** és a **`setExternalWorkbook`** metódusok használatával vagy teljesen új külső munkafüzetet hozhat létre, vagy egy belső munkafüzetet tehet külsővé.

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

A **`setExternalWorkbook`** metódussal egy külső munkafüzetet rendelhet egy diagramhoz adatforrásként. Ez a metódus használható az útvonal frissítésére is, ha a külső munkafüzetet áthelyezték.

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem szerkesztheti, továbbra is használhatja ezeket külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzethez, az automatikusan teljes úttá konvertálódik.

Ez a Java‑kód megmutatja, hogyan állíthat be egy külső munkafüzetet:

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

Az `updateChartData` paraméter (a `setExternalWorkbook` metódus alatt) határozza meg, hogy egy Excel‑munkafüzet betöltődjön‑e vagy sem.

* Ha az `updateChartData` értéke **false**, csak a munkafüzet útvonalát frissíti – a diagramadatok nem lesznek betöltve vagy frissítve a célmunkafüzetről. Ezt a beállítást akkor érdemes használni, ha a célmunkafüzet nem létezik vagy nem érhető el.  
* Ha az `updateChartData` értéke **true**, a diagramadatok a célmunkafüzetről frissülnek.

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

### **A diagram külső adatforrás munkafüzetének elérési útjának lekérése**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.  
1. Szerezze meg egy dia referenciáját indexe alapján.  
1. Hozzon létre egy objektumot a diagram alakzatához.  
1. Hozzon létre egy objektumot a forrást (`ChartDataSourceType`) reprezentáló típushoz, amely a diagram adatforrását jelöli.  
1. Adja meg a megfelelő feltételt a forrástípusnak megfelelően, ami megegyezik a külső munkafüzet adatforrás‑típusával.

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

A külső munkafüzetek adatait ugyanúgy szerkesztheti, ahogy a belső munkafüzetek tartalmát módosítaná. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

Ez a Java‑kód a leírt folyamat megvalósítását mutatja:

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

Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzetet használ, az Aspose.Slides a prezentációban gyorsítótárazott adatokból rekonstruálhatja a diagram munkafüzetét. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/) objektumot, konfigurálja egy [SpreadsheetOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/spreadsheetoptions/) példánnyal, és a [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) metódust hívja meg **true** értékkel, mielőtt megnyitná a prezentációt.

Az alábbi Java‑példa megnyit egy olyan prezentációt, amelynek diagramja egy nem elérhető külső munkafüzetet hivatkozik, és a helyreállított adatokat az [IChart.getChartData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichart/#getChartData--) és az [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) segítségével érheti el:

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

    // Olvassa vagy módosítsa itt a helyreállított munkafüzet adatait.
} finally {
    presentation.dispose();
}
```

Ha a külső munkafüzet nem érhető el, és a helyreállítás le van tiltva, az Aspose.Slides kivételt dob. Engedélyezze a helyreállítást csak akkor, ha a gyorsítótárazott diagramadatok használata elfogadható tartalék, mivel a gyorsítótár nem biztos, hogy tartalmazza a külső munkafüzeten történt változtatásokat a prezentáció legutóbbi mentése óta.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzethez van-e kapcsolva?**  
Igen. A diagramnek van egy [data source type](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) és egy [path to an external workbook](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--); ha a forrás egy külső munkafüzet, a teljes útvonalat leolvashatja, hogy megbizonyosodjon a külső fájl használatáról.

**Támogatottak-e a relatív utak a külső munkafüzetekhez, és hogyan tárolódnak?**  
Igen. Ha relatív utat ad meg, az automatikusan átalakul abszolút úttá. Ez kényelmes a projekt hordozhatósága szempontjából; azonban a prezentáció elmenti az abszolút utat a PPTX fájlban.

**Használhatok-e munkafüzeteket hálózati erőforrásokon/megosztott meghajtókon?**  
Igen, ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ből nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja-e a külső XLSX‑et a prezentáció mentésekor?**  
Nem. A prezentáció egy [link to the external file](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) tárol, és ezt használja az adatok olvasásához. A külső fájl maga nem módosul a prezentáció mentésekor.

**Mit tegyek, ha a külső fájl jelszóval védett?**  
Az Aspose.Slides nem fogad el jelszót a hivatkozás során. Általános megoldás, hogy előzetesen eltávolítja a védelmet, vagy készít egy visszafejtett másolatot (például az [Aspose.Cells](/cells/androidjava/) segítségével), majd ahhoz hivatkozik.

**Több diagram is hivatkozhat ugyanarra a külső munkafüzetre?**  
Igen. Minden diagram saját linket tárol. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagramon megjelenik a következő adatbetöltéskor.