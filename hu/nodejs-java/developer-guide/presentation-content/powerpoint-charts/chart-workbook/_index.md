---
title: Diagram munkafüzetek kezelése prezentációkban JavaScript használatával
linktitle: Diagram munkafüzet
type: docs
weight: 70
url: /hu/nodejs-java/chart-workbook/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Node.js megoldást Java segítségével: egyszerűen kezelje a diagram munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy hatékonyabbá tegye prezentációja adatait."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan lehet a diagram munkafüzetekkel dolgozni az Aspose.Slides-ben. Bemutatja, hogyan lehet olvasni és írni diagram adatokat munkafüzet adatfolyamok segítségével, munkafüzet cellákat használni diagram adatcímkeként, hozzáférni a munkalap gyűjteményekhez, és megadni az adatforrás típusát a diagram értékekhez.

Továbbá kitér az externális munkafüzetek diagram adatforrásként való használatára. A példák bemutatják, hogyan lehet létrehozni és hozzárendelni egy külső munkafüzetet, lekérni egy diagramhoz kapcsolódó külső munkafüzet útvonalát, és szerkeszteni a diagram adatokat, ha a munkafüzet rendelkezésre áll.

## **Diagramadatok olvasása és írása munkafüzetből**

Az Aspose.Slides a [readWorkbookStream](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) és a [writeWorkbookStream](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) metódusokat biztosítja, amelyek lehetővé teszik diagramadat‑munkafüzetek (Aspose.Cells‑szel szerkesztett diagramadatokat tartalmazó) olvasását és írását. **Megjegyzés**: a diagram adatokat ugyanúgy kell szervezni, vagy struktúrában hasonlónak kell lenniük a forráshoz.

Ez a JavaScript‑kód egy példaműveletet mutat be:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **Diagram elrendezésének ellenőrzése munkafüzet módosítása után**

Ha egy beágyazott munkafüzetet egy módosítottra cserélünk, a diagram megtartja az eredeti sorozat‑ és kategória‑gyűjteményeit. Ez a nem egyezés a [Chart.validateChartLayout](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Chart#validateChartLayout--) hibához vezethet, index‑túl‑tartomány hiba esetén. Törölje a meglévő sorozatokat és kategóriákat, mielőtt visszaírná a frissített munkafüzetet a diagramra.

```javascript
// A munkafüzet adatfolyam módosítása után (pl. az Aspose.Cells használatával)
var updatedWorkbook = chartData.readWorkbookStream();

// Clear existing data references.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

A gyűjtemények törlése biztosítja, hogy a diagram adatstruktúrája összhangban legyen az új munkafüzettel, így a `validateChartLayout` hibamentesen befejeződik.

## **Munkafüzet cella beállítása diagram adatcímkeként**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból.  
1. Szerezze meg egy dia hivatkozását az indexe alapján.  
1. Adjon hozzá egy Buborék diagramot némi adattal.  
1. Hozzáférjen a diagram sorozatához.  
1. Állítsa be a munkafüzet cellát adatcímkeként.  
1. Mentse a prezentációt.

Ez a JavaScript‑kód megmutatja, hogyan lehet egy munkafüzet cellát diagram adatcímkének beállítani:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// Példányosít egy Presentation osztályt, amely egy prezentációs fájlt képvisel
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

Ez a JavaScript‑kód egy olyan műveletet demonstrál, ahol a [ChartDataWorkbook.getWorksheets](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartDataWorkbook#getWorksheets--) metódust használják a munkalap‑gyűjtemény eléréséhez:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Ez a JavaScript‑kód megmutatja, hogyan kell típusra állítani egy adatforrást:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Az Aspose.Slides nem támogatja a néhány diagramhoz beágyazható Excel bináris munkafüzet (.xlsb) formátumot. Használhatja a `getEmbeddedWorkbookType` metódust a [ChartData](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/) osztályon együtt a [WorkbookType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/workbooktype/) felsorolással a nem támogatott formátumok felderítéséhez, és kihagyhatja ezeket a diagramokat.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

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

        // Olvasd vagy módosítsd a diagram munkafüzet adatait itt.
    }
} finally {
    presentation.dispose();
}
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzeteket adatforrásként a diagramokhoz.

### **Külső munkafüzet létrehozása**

A **`readWorkbookStream`** és **`setExternalWorkbook`** metódusok használatával létrehozhat egy külső munkafüzetet a semmiből, vagy egy belső munkafüzetet külsővé alakíthat.

Ez a JavaScript‑kód demonstrálja a külső munkafüzet létrehozásának folyamatát:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fileSystem = require("fs");

var pres = new aspose.slides.Presentation();
try {
    var workbookPath = "externalWorkbook1.xlsx";
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.Pie, 50, 50, 400, 600);
    // readWorkbookStream visszaadja a munkafüzet bájtjait Node Bufferként.
    var workbookData = chart.getChartData().readWorkbookStream();
    fileSystem.writeFileSync(workbookPath, Buffer.from(workbookData));
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

A **`setExternalWorkbook`** metódussal egy külső munkafüzetet rendelhet egy diagramhoz adatforrásként. Ezt a metódust arra is használhatja, hogy frissítse a külső munkafüzet útvonalát (ha az áthelyezésre került).

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzetelek adatait nem szerkesztheti közvetlenül, továbbra is használhatja őket külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzethez, az automatikusan teljes útvonallá alakul.

Ez a JavaScript‑kód megmutatja, hogyan kell egy külső munkafüzetet beállítani:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

A `setExternalWorkbook` metódus második paramétere, az `updateChartData`, azt határozza meg, hogy az Excel‑munkafüzet be legyen‑töltve vagy sem.

* Ha az `updateChartData` **false** értékre van állítva, csak a munkafüzet útvonala frissül — a diagramadatok nem lesznek betöltve vagy frissítve a cél‑munkafüzetről. Ezt a beállítást akkor érdemes használni, ha a cél‑munkafüzet nem létezik vagy nem érhető el.  
* Ha az `updateChartData` **true** értékre van állítva, a diagramadatok frissülnek a cél‑munkafüzetről.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

### **Diagram külső adatforrás‑munkafüzet útvonalának lekérése**

1. Hozzon létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból.  
1. Szerezze meg egy dia hivatkozását az indexe alapján.  
1. Hozzon létre egy objektumot a diagram alakzathoz.  
1. Hozzon létre egy objektumot a forrás (`ChartDataSourceType`) típusához, amely a diagram adatforrását jelöli.  
1. Adja meg a megfelelő feltételt aszerint, hogy a forrás típusa megegyezik‑e a külső munkafüzet adatforrás típusával.

Ez a JavaScript‑kód demonstrálja a műveletet:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Az adatokat külső munkafüzetelekben ugyanúgy szerkesztheti, ahogy a belső munkafüzetelek tartalmát módosítaná. Ha egy külső munkafüzet nem tölthető be, kivétel keletkezik.

Ez a JavaScript‑kód a leírt folyamat megvalósítását mutatja be:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

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

Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzetet használ, az Aspose.Slides helyreállíthatja a diagram munkafüzetet a prezentációban tárolt gyorsítótár‑adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/)‑t, konfigurálja egy [SpreadsheetOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/spreadsheetoptions/)‑szel, és a prezentáció megnyitása előtt hívja meg a [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) metódust `true` értékkel.

Az alábbi JavaScript‑példa megnyit egy prezentációt, melynek diagramja egy nem elérhető külső munkafüzettel hivatkozik, és a helyreállított adatokat a [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) segítségével érheti el:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

const spreadsheetOptions = new aspose.slides.SpreadsheetOptions();
spreadsheetOptions.setRecoverWorkbookFromChartCache(true);

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setSpreadsheetOptions(spreadsheetOptions);

const presentation = new aspose.slides.Presentation("presentation.pptx", loadOptions);
try {
    const chart = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const recoveredWorkbook = chart.getChartData().getChartDataWorkbook();

    // Olvasd vagy módosítsd a helyreállított munkafüzet adatait itt.
} finally {
    presentation.dispose();
}
```

Ha a külső munkafüzet nem érhető el, és a helyreállítás le van tiltva, az Aspose.Slides kivételt dob. Csak akkor engedélyezze a helyreállítást, ha a gyorsítótár‑diagramadatok felhasználása elfogadható tartalék, mivel a gyorsítótár nem biztos, hogy tartalmazza a külső munkafüzetben a prezentáció legutóbbi frissítése óta végzett változtatásokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzethez kapcsolódik?**  
Igen. A diagramnek van egy [data source type](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) és egy [path to an external workbook](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); ha a forrás egy külső munkafüzet, akkor kiolvashatja a teljes útvonalat, hogy megbizonyosodjon a külső fájl használatáról.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**  
Igen. Ha relatív útvonalat ad meg, az automatikusan átalakul abszolút útvonallá. Ez kényelmes a projekt hordozhatósága szempontjából; azonban a prezentáció az ABSOLÚT útvonalat tárolja a PPTX fájlban.

**Használhatok munkafüzeteleket hálózati erőforrásokon/megosztásokon?**  
Igen, az ilyen munkafüzetelek használhatók külső adatforrásként. A távoli munkafüzetelek közvetlen szerkesztése az Aspose.Slides‑ből nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja a külső XLSX‑et a prezentáció mentésekor?**  
Nem. A prezentáció egy [link to the external file](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) tárol, és azt használja az adatok olvasásához. A külső fájl nem módosul a prezentáció mentésekor.

**Mit tegyek, ha a külső fájl jelszóval védett?**  
Az Aspose.Slides nem fogad el jelszót a hivatkozáskor. Egy általános megoldás, hogy előre eltávolítja a védelmet, vagy létrehoz egy dekódolt másolatot (például a [Aspose.Cells](/cells/nodejs-java/) segítségével), és arra hivatkozik.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**  
Igen. Minden diagram a saját hivatkozását tárolja. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagramot érint a következő adatbetöltéskor.