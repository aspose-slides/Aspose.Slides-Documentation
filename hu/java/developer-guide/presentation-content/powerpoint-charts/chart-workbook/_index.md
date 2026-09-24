---
title: "Diagram munkafüzetek kezelése prezentációkban Java használatával"
linktitle: "Diagram munkafüzet"
type: docs
weight: 70
url: /hu/java/chart-workbook/
keywords:
- diagram munkafüzet
- diagram adatok
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
description: "Fedezze fel az Aspose.Slides for Java-t: könnyedén kezelje a diagram munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse prezentációja adatait."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan lehet a diagram munkafüzetekkel dolgozni az Aspose.Slides-ben. Bemutatja, hogyan lehet a diagram adatokat munkafüzet áramokon keresztül be- és kiolvasni, a munkafüzet cellákat diagram adatcímkeként használni, a munkalap gyűjteményekhez hozzáférni, és a diagram értékek adatforrás típusát megadni.  

Továbbá lefedi a külső munkafüzetek diagram adatforrásként való használatát. A példák bemutatják, hogyan hozhatunk létre és rendelhetünk hozzá egy külső munkafüzetet, hogyan kérhetjük le egy diagramhoz csatolt külső munkafüzet útvonalát, és hogyan szerkeszthető a diagram adat, amikor a munkafüzet elérhető.  

A hiányzó adatot jelző munkafüzet cellák esetén lásd a [Control the Display of Empty Cells](/slides/hu/java/chart-series/) cikket a üres cella és a nulla közötti különbségért, valamint a rendelkezésre álló megjelenítési módok vonaldiagram összehasonlításáért.

## **Diagramadatok olvasása és írása munkafüzetből**

Az Aspose.Slides a [ReadWorkbookStream](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartData#readWorkbookStream--) és a [WriteWorkbookStream](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartData#writeWorkbookStream-byte:A-) metódusokat biztosítja, amelyek lehetővé teszik a diagramadat munkafüzetek (Az Aspose.Cells segítségével szerkesztett diagramadatokat tartalmazó) be- és kiolvasását. **Megjegyzés**: a diagramadatoknak ugyanúgy kell szerveződnie, vagy hasonló struktúrával kell rendelkezniük, mint a forrás.  

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

### **Diagram elrendezésének ellenőrzése munkafüzet módosítása után**

Amikor egy beágyazott munkafüzetet egy módosítottal helyettesít, a diagram megtartja az eredeti sorozatok és kategóriagyűjtemények összességét. Ez az inkonzisztencia azt eredményezheti, hogy az [IChart.validateChartLayout](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichart/#validateChartLayout--) `ArgumentOutOfRangeException` kivételt dob (paraméter: index). A kivétel elkerülése érdekében törölje a meglévő sorozatokat és kategóriákat **mielőtt** a frissített munkafüzetet visszaírná a diagramba.  

```java
// A munkafüzet áramlata módosítása után (pl. az Aspose.Cells használatával)
byte[] updatedWorkbook = baos.toByteArray();

// A meglévő adat hivatkozások törlése.
chart.getChartData().getSeries().clear();
chart.getChartData().getCategories().clear();

chart.getChartData().writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

A gyűjtemények törlése biztosítja, hogy a diagram adatstruktúrája illeszkedjen az új munkafüzethez, lehetővé téve a `validateChartLayout` hibamentes befejezését.

## **Munkafüzet cella beállítása diagram adatcímkeként**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból.  
2. Szerezze meg egy dia referenciáját az indexén keresztül.  
3. Adjon hozzá egy Bubbla diagramot némi adattal.  
4. Hozzon hozzáférést a diagram sorozataihoz.  
5. Állítsa be a munkafüzet cellát adatcímkeként.  
6. Mentse a prezentációt.  

Ez a Java kód megmutatja, hogyan állíthat be egy munkafüzet cellát diagram adatcímkeként:

```java
import com.aspose.slides.*;

String lbl0 = "Label 0 cell value";
String lbl1 = "Label 1 cell value";
String lbl2 = "Label 2 cell value";

// Példányosít egy Presentation osztályt, amely egy prezentációfájlt képvisel
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

Ez a Java kód bemutat egy műveletet, ahol az [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartDataWorkbook#getWorksheets--) metódust használják munkalap gyűjtemény elérésére:

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

Ez a Java kód megmutatja, hogyan adható meg egy típus egy adatforráshoz:

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

Az Aspose.Slides nem támogatja a néhány diagramba beágyazható Excel bináris munkafüzet (.xlsb) formátumot. A `getEmbeddedWorkbookType` metódust az [IChartData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/IChartData) és a [WorkbookType](https://reference.aspose.com/slides/hu/java/com.aspose.slides/WorkbookType) felsorolással együtt használva felismerheti a nem támogatott formátumokat, és kihagyhatja az érintett diagramokat.

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
            // A beágyazott munkafüzet .xlsb formátumú, amely nem támogatott.
            continue;
        }

        // Itt olvassa vagy módosítsa a diagram munkafüzet adatait.
    }
} finally {
    presentation.dispose();
}
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetek diagramok adatforrásaként való használatát.

### **Külső munkafüzet létrehozása**

A **`readWorkbookStream`** és **`setExternalWorkbook`** metódusok használatával akár egy külső munkafüzetet hozhatunk létre a semmiből, akár egy belső munkafüzetet tehetünk külsővé.  

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

A **`setExternalWorkbook`** metódus használatával külső munkafüzetet rendelhetünk egy diagramhoz adatforrásként. Ez a metódus használható a külső munkafüzet útvonalának frissítésére is (ha az áthelyezésre került).  

Bár a távoli helyen vagy erőforrásban tárolt munkafüzetek adatait nem szerkesztheti, ilyen munkafüzeteket továbbra is használhat külső adatforrásként. Ha egy külső munkafüzet relatív útvonala van megadva, az automatikusan teljes úttá konvertálódik.  

```java
import com.aspose.slides.*;

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

A `setExternalWorkbook` metódus második (`boolean`) paramétere azt határozza meg, hogy az Excel munkafüzet be lesz-e töltve vagy sem.  

* Ha az értéke `false`, csak a munkafüzet útvonala frissül – a diagram adat nem lesz betöltve vagy frissítve a célmunkafüzettől. Ezt a beállítást olyan esetben érdemes használni, amikor a célmunkafüzet nem létezik vagy nem érhető el.  
* Ha az értéke `true`, a diagram adatok a célmunkafüzettől frissülnek.  

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

### **Diagram külső adatforrás munkafüzet útvonalának lekérése**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/java/com.aspose.slides/presentation) osztályból.  
2. Szerezze meg egy dia referenciáját az indexén keresztül.  
3. Hozzon létre egy objektumot a diagram alakzat számára.  
4. Hozzon létre egy objektumot a forrás (`ChartDataSourceType`) típusához, amely a diagram adatforrását jelenti.  
5. Adja meg a megfelelő feltételt a forrástípusnak a külső munkafüzet adatforrás típusával megegyező legyen.  

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

### **Diagram adat szerkesztése**

A külső munkafüzetek adatait ugyanúgy szerkesztheti, ahogy a belső munkafüzetek tartalmát módosítja. Ha egy külső munkafüzet nem tölthető be, kivétel keletkezik.

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

### **Munkafüzet helyreállítása a diagram gyorsítótárból**

Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzetet használ, az Aspose.Slides képes rekonstruálni a diagram munkafüzetét a prezentációban tárolt gyorsítótárazott adatokból. Hozzon létre [LoadOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/loadoptions/), konfigurálja [SpreadsheetOptions](https://reference.aspose.com/slides/hu/java/com.aspose.slides/spreadsheetoptions/) segítségével, és hívja meg az [ISpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ispreadsheetoptions/#setRecoverWorkbookFromChartCache-boolean-) metódust `true` értékkel a prezentáció megnyitása előtt.  

A következő Java példa megnyit egy prezentációt, amelynek diagramja egy nem elérhető külső munkafüzetre hivatkozik, és a helyreállított adatokat az [IChart.getChartData](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichart/#getChartData--) és az [IChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hu/java/com.aspose.slides/ichartdata/#getChartDataWorkbook--) segítségével érheti el:

```java
SpreadsheetOptions spreadsheetOptions = new SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

LoadOptions loadOptions = new LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

Presentation presentation = new Presentation("presentation.pptx", loadOptions);
try {
    IChart chart = (IChart)presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IChartDataWorkbook recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Itt olvassa vagy módosítsa a helyreállított munkafüzet adatait.
} finally {
    presentation.dispose();
}
```

Ha a külső munkafüzet nem érhető el és a helyreállítás le van tiltva, az Aspose.Slides kivételt dob. Engedélyezze a helyreállítást csak akkor, ha a gyorsítótárazott diagramadatok használata elfogadható alternatíva, mivel a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzetben a prezentáció legutóbbi frissítése után végzett változtatásokat.

## **Gyakran ismételt kérdések**

**Meg tudom határozni, hogy egy adott diagram egy külső vagy beágyazott munkafüzethez van-e csatolva?**  

Igen. A diagram rendelkezik egy [data source type](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chartdata/#getDataSourceType--) és egy [path to an external workbook](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) tulajdonsággal; ha a forrás egy külső munkafüzet, akkor kiolvashatja a teljes útvonalat annak biztosítására, hogy egy külső fájlt használ.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**  

Igen. Ha relatív útvonalat ad meg, az automatikusan abszolút útvonallá alakul. Ez kényelmes a projekt hordozhatósága szempontjából; azonban vegye figyelembe, hogy a prezentáció az abszolút útvonalat tárolja a PPTX fájlban.

**Használhatok munkafüzeteket hálózati erőforrásokon/megosztásokon?**  

Igen, az ilyen munkafüzetek külső adatforrásként használhatók. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides-ből nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja a külső XLSX fájlt a prezentáció mentésekor?**  

Nem. A prezentáció egy [link to the external file](https://reference.aspose.com/slides/hu/java/com.aspose.slides/chartdata/#getExternalWorkbookPath--) tárolja, és ezt használja az adatok beolvasásához. A külső fájl maga nem módosul a prezentáció mentésekor.

**Mit tegyek, ha a külső fájl jelszóval védett?**  

Az Aspose.Slides nem fogad el jelszót a csatoláskor. Egy gyakori megoldás, hogy előre eltávolítja a védelmet, vagy egy dekódolt másolatot készít (például [Aspose.Cells](/cells/java/) használatával), és arra a másolatra hivatkozik.

**Több diagram is hivatkozhat ugyanarra a külső munkafüzetre?**  

Igen. Minden diagram a saját hivatkozását tárolja. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagram esetén megjelenik a következő adatbetöltéskor.