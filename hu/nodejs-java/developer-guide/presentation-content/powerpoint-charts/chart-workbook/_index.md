---
title: Diagram munkafüzetek kezelése prezentációkban JavaScript használatával
linktitle: Diagram munkafüzet
type: docs
weight: 70
url: /hu/nodejs-java/chart-workbook/
keywords:
- diagram munkafüzet
- diagram adat
- munkafüzet cella
- adatcímke
- munkalap
- adatforrás
- külső munkafüzet
- külső adat
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Node.js-et Java segítségével: egyszerűen kezelje a diagram munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy hatékonyabbá tegye a prezentáció adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhat a diagram munkafüzetekkel az Aspose.Slides segítségével. Megmutatja, hogyan olvashat és írhat diagram adatokat munkafüzet adatfolyamok segítségével, hogyan használhat munkafüzet cellákat diagram adatcímkeként, hogyan érheti el a munkalapgyűjteményeket, és hogyan adhatja meg az adatforrás típusát a diagram értékekhez.

Továbbá tárgyalja a külső munkafüzetek használatát diagram adatforrásként. A példák bemutatják, hogyan hozhat létre és rendelhet hozzá egy külső munkafüzetet, hogyan kérheti le egy diagramhoz csatolt külső munkafüzet útvonalát, és hogyan szerkesztheti a diagram adatokat, ha a munkafüzet elérhető.

## **Diagram adatainak olvasása és írása munkafüzetből**

Az Aspose.Slides a [readWorkbookStream](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) és a [writeWorkbookStream](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) metódusokat biztosítja, amelyek lehetővé teszik a diagram adatokat tartalmazó munkafüzetek (az Aspose.Cells‑szel szerkesztett diagram adatokkal) olvasását és írását. **Megjegyzés:** a diagram adatokat ugyanúgy kell szervezni, vagy a forráshoz hasonló szerkezettel kell rendelkezniük.

Ez a JavaScript‑kód egy mintaműveletet mutat be:

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

## **Munkafüzet cella beállítása diagram adatcímkének**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból.
1. Szerezze meg egy dia referenciáját az indexe alapján.
1. Adjon hozzá egy buborékdiagramot némi adatokkal.
1. Hozzáférjen a diagram sorozatához.
1. Állítsa be a munkafüzet cellát adatcímkeként.
1. Mentse a bemutatót.

Ez a JavaScript‑kód bemutatja, hogyan állítsa be a munkafüzet cellát diagram adatcímkeként:

```javascript
var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// Példányosít egy prezentáció osztályt, amely egy prezentációs fájlt képvisel
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

Ez a JavaScript‑kód egy műveletet mutat be, amelyben a [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) metódust használják a munkalapgyűjtemény eléréséhez:

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

Ez a JavaScript‑kód megmutatja, hogyan adhat meg egy típust egy adatforráshoz:

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

## **Nem támogatott beágyazott munkafüzetformátumok felderítése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely néhány diagramba beágyazható. A [ChartData](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/) `getEmbeddedWorkbookType` metódusát a [WorkbookType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/workbooktype/) felsorolással együtt használhatja a nem támogatott formátumok felderítéséhez és az ilyen diagramok kihagyásához.

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
            // A beágyazott munkafüzet .xlsb formátumú, amely nem támogatott.
            continue;
        }

        // Olvassa vagy módosítsa a diagram munkafüzet adatait itt.
    }
} finally {
    presentation.dispose();
}
```

## **Külső munkafüzet**

Az Aspose.Slides külső munkafüzeteket támogat adatforrásként a diagramokhoz.

### **Külső munkafüzet létrehozása**

A **`readWorkbookStream`** és a **`setExternalWorkbook`** metódusok segítségével vagy egy új külső munkafüzetet hozhat létre, vagy egy belső munkafüzetet tehet külsővé.

Ez a JavaScript‑kód demonstrálja a külső munkafüzet létrehozási folyamatát:

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

A **`setExternalWorkbook`** metódus segítségével egy külső munkafüzetet rendelhet egy diagram adatforrásához. Ezzel a metódussal frissítheti a külső munkafüzet elérési útját is (ha az áthelyezésre került).

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem szerkesztheti, továbbra is használhatja ezeket külső adatforrásként. Ha a külső munkafüzet relatív útvonalát adja meg, az automatikusan teljes úttá alakul.

Ez a JavaScript‑kód megmutatja, hogyan állítsa be egy külső munkafüzetet:

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

A `ChartData` paraméter (a `setExternalWorkbook` metódus alatt) azt határozza meg, hogy egy Excel munkafüzet be lesz‑töltve vagy sem.

* Ha a `ChartData` értéke `false`, csak a munkafüzet útvonala frissül – a diagram adatai nem lesznek betöltve vagy frissítve a cél munkafüzetből. Ezt a beállítást akkor használja, ha a cél munkafüzet nem létezik vagy nem érhető el.
* Ha a `ChartData` értéke `true`, a diagram adatai frissülnek a cél munkafüzetből.

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

### **Diagram külső adatforrás munkafüzet útvonalának lekérdezése**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból.
1. Szerezze meg egy dia referenciáját az indexe alapján.
1. Hozzon létre egy objektumot a diagram alakzatra.
1. Hozzon létre egy objektumot a forrástípus (`ChartDataSourceType`) képviseletére, amely a diagram adatforrását jelöli.
1. Adja meg a megfelelő feltételt a forrástípus alapján, amely megegyezik a külső munkafüzet adatforrástípusával.

Ez a JavaScript‑kód demonstrálja a műveletet:

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
    // Elmenti a prezentációt
    pres.save("result.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Diagram adatainak szerkesztése**

A külső munkafüzetek adatait ugyanúgy szerkesztheti, ahogy a belső munkafüzetek tartalmát módosítja. Ha egy külső munkafüzet nem tölthető be, kivétel keletkezik.

Ez a JavaScript‑kód a leírt folyamat megvalósítását mutatja be:

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

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzethez kapcsolódik‑e?**

Igen. A diagram rendelkezik egy [data source type](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) és egy [path to an external workbook](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) attribútummal; ha a forrás külső munkafüzet, kiolvashatja a teljes útvonalat, hogy megbizonyosodjon a külső fájl használatáról.

**Támogatottak-e a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, az automatikusan abszolút úttá konvertálódik. Ez a projekt hordozhatóságát segíti, de vegye figyelembe, hogy a bemutató az abszolút útvonalat tárolja a PPTX‑ben.

**Használhatok‑e hálózati erőforrásokban/megosztásokon található munkafüzeteket?**

Igen, az ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ből nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja‑e a külső XLSX‑et a bemutató mentésekor?**

Nem. A bemutató egy [linket a külső fájlra](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) tárol, és ezt használja az adatok beolvasásához. A külső fájl maga nem módosul a mentés során.

**Mi a teendő, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad el jelszót a hivatkozáskor. Általános megoldás a védelem előzetes eltávolítása vagy egy dekódolt másolat (például a [Aspose.Cells](/cells/nodejs-java/) segítségével) készítése, majd arra való hivatkozás.

**Több diagram is hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram saját linket tárol. Ha mind ugyanarra a fájlra mutat, a fájl frissítése minden diagram esetén megjelenik a következő adatbetöltéskor.