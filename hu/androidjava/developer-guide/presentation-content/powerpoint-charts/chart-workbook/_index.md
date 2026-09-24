---
title: Diagrammunkafüzetek kezelése prezentációkban Androidon
linktitle: Diagrammunkafüzet
type: docs
weight: 70
url: /hu/androidjava/chart-workbook/
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
- Android
- Java
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Android Java segítségével: könnyedén kezelje a diagrammunkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse prezentációi adatait."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan dolgozhatunk diagrammunkafüzetekkel az Aspose.Slides-ben. Bemutatja, hogyan olvashatunk és írhatunk diagram adatokhoz munkafüzet‑adatfolyamok segítségével, hogyan használhatjuk a munkafüzet cellákat diagram adatelőjelként, hogyan érhetjük el a munkalap‑gyűjteményeket, és hogyan adhatjuk meg az adatforrás típusát a diagramértékekhez.

Továbbá lefedi a külső munkafüzetek diagram adatforrásként történő használatát. A példák bemutatják, hogyan hozhatunk létre és rendelhetünk hozzá egy külső munkafüzetet, hogyan kérhetjük le egy diagramhoz kapcsolt külső munkafüzet útvonalát, és hogyan szerkeszthetjük a diagram adatokat, ha a munkafüzet elérhető.

A hiányzó adatot képviselő munkafüzet cellákhoz lásd a [Control the Display of Empty Cells](/slides/hu/androidjava/chart-series/) oldalt, ahol megtalálható a különbség az üres cella és a nulla között, valamint egy vonaldiagram‑összehasonlítás a rendelkezésre álló megjelenítési módokról.

## **Munkafüzettel történő diagram adatok olvasása és írása**

Aspose.Slides a [ReadWorkbookStream](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartData#readWorkbookStream--) és a [WriteWorkbookStream](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) metódusokat biztosítja, amelyek lehetővé teszik a diagram adat munkafüzeteinek (amelyek Aspose.Cells‑szel szerkesztett diagram adatokat tartalmaznak) olvasását és írását. **Megjegyzés** , hogy a diagram adatait ugyanúgy kell szervezni, vagy a forráshoz hasonló szerkezetűnek kell lennie.

Ez a Java kód bemutat egy példaműveletet:

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

### **Diagram elrendezés ellenőrzése a munkafüzet módosítása után**

Amikor egy beágyazott munkafüzetet egy módosítottal helyettesít, a diagram megtartja eredeti sorozat- és kategória‑gyűjteményeit. Ez a nem egyezés miatt a [IChart.validateChartLayout](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChart#validateChartLayout--) hívás indexkívül határ hibával sikertelen lehet. Törölje a meglévő sorozatokat és kategóriákat, mielőtt az frissített munkafüzetet visszaírná a diagramba.

```java
// A munkafüzet adatfolyam módosítása után (például az Aspose.Cells használatával)
byte[] updatedWorkbook = chartData.readWorkbookStream();

// Törölje a meglévő adat hivatkozásokat.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

A gyűjtemények törlése biztosítja, hogy a diagram adatstruktúrája egyezik az új munkafüzettel, lehetővé téve a `validateChartLayout` hibamentes befejezését.

## **Munkafüzet cella beállítása diagram adatcímkeként**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.  
1. Szerezze meg a dia hivatkozását az indexe alapján.  
1. Adjon hozzá egy Buborék diagramot némi adattal.  
1. Hozzáférés a diagram sorozataihoz.  
1. Állítsa be a munkafüzet cellát adatcímkeként.  
1. Mentse a prezentációt.

Ez a Java kód bemutatja, hogyan állítható be a munkafüzet cella diagram adatcímkeként:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Példányosít egy prezentáció osztályt, amely egy prezentáció fájlt képvisel
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

Ez a Java kód bemutat egy műveletet, ahol a [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartDataWorkbook#getWorksheets--) metódust használják a munkalap‑gyűjtemény eléréséhez:

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

Ez a Java kód bemutatja, hogyan adható meg egy típus egy adatforráshoz:

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

## **Nem támogatott beágyazott munkafüzet formátumok felismerése**

Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely egyes diagramokba beágyazható. A `getEmbeddedWorkbookType` metódust a [IChartData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/IChartData) és a [WorkbookType](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/WorkbookType) felsorolással együtt használhatja a nem támogatott formátumok felismerésére és az ilyen diagramok kihagyására.

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
            // A beágyazott munkafüzet .xlsb formátumban van, amelyet nem támogatunk.
            continue;
        }

        // Olvassa vagy módosítsa itt a diagram munkafüzet adatait.
    }
} finally {
    presentation.dispose();
}
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetek diagram adatforrásként való használatát.

### **Külső munkafüzet létrehozása**

A **`readWorkbookStream`** és **`setExternalWorkbook`** metódusok használatával létrehozhat egy külső munkafüzetet a semmiből, vagy egy belső munkafüzetet külsővé tehet.

Ez a Java kód bemutatja a külső munkafüzet létrehozási folyamatát:

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

A **`setExternalWorkbook`** metódus használatával külső munkafüzetet rendelhet egy diagram adatforrásaként. Ez a metódus arra is használható, hogy frissítse a külső munkafüzet útvonalát (ha az áthelyezésre került).

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem szerkesztheti, továbbra is használhatja ezeket külső adatforrásként. Ha a külső munkafüzet relatív útvonala van megadva, az automatikusan teljes útvonallá konvertálódik.

Ez a Java kód bemutatja, hogyan állítható be egy külső munkafüzet:

```java
import com.aspose.slides.*;

// Létrehozza a Presentation osztály példányát
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

Az `updateChartData` paraméter (a `setExternalWorkbook` metódusban) arra szolgál, hogy meghatározza, betöltődik‑e egy Excel munkafüzet vagy sem.

* Ha az `updateChartData` értéke `false`, csak a munkafüzet útvonala frissül – a diagram adatai nem lesznek betöltve vagy frissítve a célmunkafüzetről. Ezt a beállítást akkor érdemes használni, ha a célmunkafüzet nem létezik vagy nem érhető el.  
* Ha az `updateChartData` értéke `true`, a diagram adatai frissülnek a célmunkafüzetről.

```java
import com.aspose.slides.*;

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

### **A diagram külső adatforrás munkafüzetének útvonalának lekérése**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/androidjava/com.aspose.slides/presentation) osztályból.  
1. Szerezze meg a dia hivatkozását az indexe alapján.  
1. Hozzon létre egy objektumot a diagram alakzatra.  
1. Hozzon létre egy objektumot a forrás (`ChartDataSourceType`) típushoz, amely a diagram adatforrását képviseli.  
1. Határozza meg a megfelelő feltételt a forrás típusa alapján, amely megegyezik a külső munkafüzet adatforrás típussal.

Ez a Java kód bemutatja a műveletet:

```java
import com.aspose.slides.*;

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

### **Diagram adatainak szerkesztése**

A külső munkafüzetek adatait ugyanúgy szerkesztheti, mint a belső munkafüzetek tartalmát. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

Ez a Java kód a leírt folyamat megvalósítása:

```java
import com.aspose.slides.*;

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

### **Munkafüzet visszaállítása a diagram gyorsítótárából**

Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzetet használ, az Aspose.Slides képes a diagram munkafüzetet helyreállítani a prezentációban tárolt gyorsítótárazott adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/loadoptions/)‑t, konfigurálja [SpreadsheetOptions](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/spreadsheetoptions/)‑val, és hívja meg a [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) metódust `true` értékkel a prezentáció megnyitása előtt.

A következő Java példa megnyit egy prezentációt, amelynek diagramja egy nem elérhető külső munkafüzetre hivatkozik, és a visszaállított adatokat eléri a [IChart.getChartData](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichart/#getChartData--) és a [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/ichartdata/#getChartDataWorkbook--) segítségével:

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

Ha a külső munkafüzet nem érhető el, és a helyreállítás le van tiltva, az Aspose.Slides kivételt dob. A helyreállítást csak akkor engedélyezze, ha a gyorsítótárban tárolt diagram adatok használata elfogadható tartalék, mivel a gyorsítótár esetleg nem tartalmazza a külső munkafüzetben a prezentáció legutóbbi frissítése után történt módosításokat.

## **GYIK**

**Megállapíthatom, hogy egy adott diagram külső vagy beágyazott munkafüzethez van‑e kapcsolva?**

Igen. A diagram rendelkezik egy [data source type](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chartdata/#getDataSourceType--) és egy [path to an external workbook](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--) tulajdonsággal; ha a forrás egy külső munkafüzet, kiolvashatja a teljes útvonalat, hogy megbizonyosodjon, egy külső fájlt használ.

**Támogatottak-e a külső munkafüzetek relatív útvonalai, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, az automatikusan átalakul abszolút útvonallá. Ez a projekt hordozhatóságát segíti, de vegye figyelembe, hogy a prezentáció az abszolút útvonalat tárolja a PPTX fájlban.

**Használhatok‑e hálózati erőforrásokon/megosztásokon lévő munkafüzeteket?**

Igen, ilyen munkafüzetek használhatók külső adatforrásként. A távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ből azonban nem támogatott – csak forrásként használhatók.

**Felülírja‑e az Aspose.Slides a külső XLSX‑et a prezentáció mentésekor?**

Nem. A prezentáció egy [link to the external file](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/chartdata/#getExternalWorkbookPath--)‑et tárol, és ezt használja az adatok olvasásához. A külső fájl maga nem módosul a prezentáció mentésekor.

**Mit tegyek, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad el jelszót a hivatkozáskor. Általános megoldás a védelem előzetes eltávolítása vagy egy visszafejtett példány előkészítése (például a [Aspose.Cells](/cells/androidjava/) segítségével), majd arra a példányra hivatkozni.

**Több diagram is hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram a saját hivatkozását tárolja. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése a következő adatbetöltéskor minden diagramon megjelenik.