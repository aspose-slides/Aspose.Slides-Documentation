---
title: Diagrammunkafüzetek kezelése prezentációkban JavaScript használatával
linktitle: Diagrammunkafüzet
type: docs
weight: 70
url: /hu/nodejs-java/chart-workbook/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Node.js-et Java segítségével: könnyedén kezelje a diagrammunkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse a prezentáció adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk diagramműkönyvekkel az Aspose.Slides-ban. Megmutatja, hogyan olvassunk és írjunk diagramadatokat munkafüzet-áramok segítségével, hogyan használjuk a munkafüzet cellákat diagramadat‑címkeként, hogyan érjük el a munkalap gyűjteményeket, valamint hogyan adhatjuk meg az adatforrás típusát a diagramértékekhez.

Emellett tárgyalja a külső munkafüzetek diagramadat‑forrásként való használatát is. A példák bemutatják, hogyan hozhatunk létre és rendeljünk hozzá egy külső munkafüzetet, hogyan kérhetjük le egy diagramhoz csatolt külső munkafüzet útvonalát, valamint hogyan szerkeszthetjük a diagramadatokat a munkafüzet elérhető állapotában.

## **Diagramadatok olvasása és írása munkafüzettel**

Az Aspose.Slides a [readWorkbookStream](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) és a [writeWorkbookStream](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) metódusokat biztosítja, amelyek lehetővé teszik diagramadat‑munkafüzetek (az Aspose.Cells‑szel szerkesztett diagramadatokat tartalmazó) olvasását és írását. **Megjegyzés**: a diagramadatokat ugyanúgy kell szervezni, vagy a forráshoz hasonló struktúrával kell rendelkezniük.

Ez a JavaScript kód egy példaműveletet mutat be:
```javascript
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var data = chart.getChartData();
    var stream = data.readWorkbookStream();
    data.getSeries().clear();
    data.getCategories().clear();
    data.writeWorkbookStream(stream);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Munkafüzet cella beállítása diagramcímkének**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból.  
2. Szerezze meg a dia referenciaját az indexe alapján.  
3. Adjon hozzá egy buborékdiagramot némi adattal.  
4. Hozzáférés a diagram sorozataihoz.  
5. Állítsa be a munkafüzet cellát adatcímkének.  
6. Mentse a prezentációt.

Ez a JavaScript kód bemutatja, hogyan állítható be a munkafüzet cella diagramadat‑címkének:
```javascript
var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// Létrehozza a prezentációs osztályt, amely egy prezentációs fájlt képvisel
var pres = new aspose.slides.Presentation("chart2.pptx");
try {
    var slide = pres.getSlides().get_Item(0);
    var chart = slide.getShapes().addChart(aspose.slides.ChartType.Bubble, 50, 50, 600, 400, true);
    var series = chart.getChartData().getSeries();
    var dataLabelCollection = series.get_Item(0).getLabels();
    dataLabelCollection.getDefaultDataLabelFormat().setShowLabelValueFromCell(true);
    var wb = chart.getChartData().getChartDataWorkbook();
    dataLabelCollection.get_Item(0).setValueFromCell(wb.getCell(0, "A10", lbl0));
    dataLabelCollection.get_Item(1).setValueFromCell(wb.getCell(0, "A11", lbl1));
    dataLabelCollection.get_Item(2).setValueFromCell(wb.getCell(0, "A12", lbl2));
    pres.save("resultchart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Munkalapok kezelése**

Ez a JavaScript kód egy műveletet mutat be, ahol a [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) metódust használják a munkalapgyűjtemény eléréséhez:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 500);
    var wb = chart.getChartData().getChartDataWorkbook();
    for (var i = 0; i < wb.getWorksheets().size(); i++) {
        console.log(wb.getWorksheets().get_Item(i).getName());
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Adatforrás típusának megadása**

Ez a JavaScript kód bemutatja, hogyan adhatunk meg egy típust az adatforráshoz:
```javascript
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Column3D, 50, 50, 600, 400, true);
    var val = chart.getChartData().getSeries().get_Item(0).getName();
    val.setDataSourceType(aspose.slides.DataSourceType.StringLiterals);
    val.setData("LiteralString");
    val = chart.getChartData().getSeries().get_Item(1).getName();
    val.setData(chart.getChartData().getChartDataWorkbook().getCell(0, "B1", "NewCell"));
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Nem támogatott beágyazott munkafüzet formátumok észlelése**

Az Aspose.Slides nem támogatja az egyes diagramokba beágyazható Excel bináris munkafüzet (.xlsb) formátumot. A `getEmbeddedWorkbookType` metódust a [ChartData](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/) osztályon, valamint a [WorkbookType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/workbooktype/) felsorolással használva észlelhetjük a nem támogatott formátumokat, és kihagyhatjuk azokat a diagramokat.
```js
let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shapes = slide.getShapes();

    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        let shape = shapes.get_Item(shapeIndex);

        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) continue;

        let chart = shape;
        let chartData = chart.getChartData();

        if (chartData.getDataSourceType() == aspose.slides.ChartDataSourceType.InternalWorkbook &&
                chartData.getEmbeddedWorkbookType() == aspose.slides.WorkbookType.WorkbookBinaryMacro) {
            // A beágyazott munkafüzet .xlsb formátumban van, ami nem támogatott.
            continue;
        }

        // Olvassa vagy módosítsa a diagram munkafüzete adatait itt.
    }
} finally {
    presentation.dispose();
}
```

## **Külső munkafüzet**

Az Aspose.Slides külső munkafüzeteket támogat adatforrásként a diagramokhoz.

### **Külső munkafüzet létrehozása**

Az **`readWorkbookStream`** és **`setExternalWorkbook`** metódusok használatával akár egy külső munkafüzetet is létrehozhat nulláról, vagy egy belső munkafüzetet is külsővé tehet.

Ez a JavaScript kód bemutatja a külső munkafüzet létrehozási folyamatát:
```javascript
var pres = new aspose.slides.Presentation();
try {
    final var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    var fileStream = java.newInstanceSync("java.io.FileOutputStream", workbookPath);
    try {
        var workbookData = chart.getChartData().readWorkbookStream();
        fileStream.write(workbookData, 0, workbookData.length);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
    chart.getChartData().setExternalWorkbook(workbookPath);
    pres.save("externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Külső munkafüzet beállítása**

Az **`setExternalWorkbook`** metódus használatával egy külső munkafüzetet rendelhetünk egy diagram adatforrásaként. Ez a metódus arra is használható, hogy frissítse a külső munkafüzet útvonalát (ha az át lett helyezve).

Habár a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem szerkesztheti, továbbra is használhatja ezeket külső adatforrásként. Ha meg van adva egy relatív útvonal a külső munkafüzethez, az automatikusan teljes útvonallá alakítódik.

Ez a JavaScript kód bemutatja, hogyan állítható be egy külső munkafüzet:
```javascript
// Létrehozza a Presentation osztály egy példányát
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, false);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("externalWorkbook.xlsx");
    chartData.getSeries().add(chartData.getChartDataWorkbook().getCell(0, "B1"), aspose.slides.ChartType.Pie);
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B2"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B3"));
    chartData.getSeries().get_Item(0).getDataPoints().addDataPointForPieSeries(chartData.getChartDataWorkbook().getCell(0, "B4"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A2"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A3"));
    chartData.getCategories().add(chartData.getChartDataWorkbook().getCell(0, "A4"));
    pres.save("Presentation_with_externalWorkbook.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

A `ChartData` paraméter (a `setExternalWorkbook` metódus alatt) azt határozza meg, hogy egy Excel munkafüzet be legyen‑e töltve vagy sem.

* Ha a `ChartData` érték `false`, csak a munkafüzet útvonala frissül – a diagramadatok nem töltődnek be, és nem frissülnek a cél munkafüzetről. Ezt a beállítást akkor érdemes használni, ha a cél munkafüzet nem létezik vagy nem érhető el.  
* Ha a `ChartData` érték `true`, a diagramadatok a cél munkafüzetről frissülnek.

```javascript
// Létrehozza a Presentation osztály egy példányát
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600, true);
    var chartData = chart.getChartData();
    chartData.setExternalWorkbook("http://path/doesnt/exists", false);
    pres.save("Presentation_with_externalWorkbookWithUpdateChartData.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Diagram külső adatforrás munkafüzet útvonalának lekérése**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból.  
2. Szerezze meg a dia referenciaját az indexe alapján.  
3. Hozzon létre egy objektumot a diagram alakzat számára.  
4. Hozzon létre egy objektumot a forrás (`ChartDataSourceType`) típushoz, amely a diagram adatforrását jelöli.  
5. Adja meg a megfelelő feltételt a forrástípus és a külső munkafüzet adatforrástípusának egyezése alapján.

Ez a JavaScript kód bemutatja a műveletet:
```javascript
// Létrehozza a Presentation osztály egy példányát
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var slide = pres.getSlides().get_Item(1);
    var chart = slide.getShapes().get_Item(0);
    var sourceType = chart.getChartData().getDataSourceType();
    if (sourceType == aspose.slides.ChartDataSourceType.ExternalWorkbook) {
        var path = chart.getChartData().getExternalWorkbookPath();
    }
    // Mentse a prezentációt
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Diagramadatok szerkesztése**

Az adatokat külső munkafüzetekben ugyanúgy szerkesztheti, ahogy a belső munkafüzetek tartalmát módosítja. Ha egy külső munkafüzet nem tölthető be, kivétel keletkezik.

Ez a JavaScript kód a leírt folyamat megvalósítása:
```javascript
// Létrehozza a Presentation osztály egy példányát
var pres = new aspose.slides.Presentation("chart.pptx");
try {
    var chart = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var chartData = chart.getChartData();
    chartData.getSeries().get_Item(0).getDataPoints().get_Item(0).getValue().getAsCell().setValue(100);
    pres.save("presentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Munkafüzet helyreállítása a diagram gyorsítótárából**

Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzetet használ, az Aspose.Slides képes rekonstruálni a diagram munkafüzetét a prezentációban tárolt gyorsítótárazott adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/), állítsa be [SpreadsheetOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/spreadsheetoptions/) segítségével, és a prezentáció megnyitása előtt hívja meg a [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) metódust `true` értékkel.

Az alábbi JavaScript példa megnyit egy prezentációt, amelynek diagramja egy elérhetetlen külső munkafüzetre hivatkozik, és a helyreállított adatokat a [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) segítségével éri el:
```javascript
const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Olvassa vagy módosítsa a helyreállított munkafüzet adatait itt.
} finally {
    presentation.dispose();
}
```

Ha a külső munkafüzet nem érhető el és a helyreállítás le van tiltva, az Aspose.Slides kivételt dob. Csak akkor engedélyezze a helyreállítást, ha a gyorsítótárazott diagramadatok használata elfogadható visszalépés, mivel a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzet prezentáció utolsó frissítése után történt változásokat.

## **GYIK**

**Megállapíthatom, hogy egy adott diagram külső vagy beágyazott munkafüzethez kapcsolódik‑e?**  
Igen. A diagram rendelkezik egy [data source type](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) és egy [path to an external workbook](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) értékkel; ha a forrás egy külső munkafüzet, akkor kiolvashatja a teljes útvonalat, hogy megbizonyosodjon arról, hogy külső fájlt használ.

**Támogatottak a külső munkafüzetek relatív útvonalai, és hogyan tárolódnak?**  
Igen. Ha relatív útvonalat ad meg, az automatikusan abszolút útvonalra konvertálódik. Ez kényelmes a projekt hordozhatóságához; azonban vegye figyelembe, hogy a prezentáció az abszolút útvonalat tárolja a PPTX fájlban.

**Használhatok munkafüzeteket hálózati erőforrásokon/megosztott meghajtókon?**  
Igen, ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ból nem támogatott – csak forrásként használhatók.

**Felülírja az Aspose.Slides a külső XLSX fájlt a prezentáció mentésekor?**  
Nem. A prezentáció egy [link to the external file](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) (külső fájlra mutató hivatkozást) tárol, és ezt használja az adatok olvasásához. A külső fájl maga nem módosul a prezentáció mentésekor.

**Mit tegyek, ha a külső fájl jelszóval védett?**  
Az Aspose.Slides nem fogad el jelszót a hivatkozáskor. Egy gyakori megoldás, hogy előzetesen eltávolítja a védelmet, vagy egy dekódolt másolatot készít (például a [Aspose.Cells](/cells/nodejs-java/) használatával), és arra a másolatra hivatkozik.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**  
Igen. Minden diagram a saját hivatkozását tárolja. Ha mind ugyanarra a fájlra mutatnak, a fájl frissítése a következő adatbetöltéskor minden diagram esetében megjelenik.