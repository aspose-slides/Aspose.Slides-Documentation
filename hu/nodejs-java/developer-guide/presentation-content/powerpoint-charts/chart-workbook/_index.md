---
title: Diagramm munkafüzetek kezelése prezentációkban JavaScript használatával
linktitle: Diagramm munkafüzet
type: docs
weight: 70
url: /hu/nodejs-java/chart-workbook/
keywords:
- diagramm munkafüzet
- diagramm adatok
- munkafüzet cella
- adatcímke
- munkalap
- adatforrás
- külső munkafüzet
- külső adat
- diagramm gyorsítótár
- munkafüzet helyreállítás
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for Node.js-t Java-on keresztül: könnyedén kezelje a diagramm munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse prezentációja adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozzunk diagramm munkafüzetekkel az Aspose.Slides‑ban. Megmutatja, hogyan olvassunk és írjunk diagrammadatokat munkafüzet‑folyamokon keresztül, hogyan használjuk a munkafüzetcellákat diagrammadat‑címkeként, hogyan érjük el a munkalap‑gyűjteményeket, és hogyan adhatjuk meg az adatforrás típusát a diagrammértékekhez.

Továbbá lefedi a külső munkafüzetek diagrammadat‑forrásként való használatát. A példák bemutatják, hogyan hozzunk létre és rendeljünk hozzá egy külső munkafüzetet, hogyan szerezzük meg egy diagrammhez kapcsolt külső munkafüzet útvonalát, és hogyan szerkesszük a diagrammadatokat, ha a munkafüzet elérhető.

A hiányzó adatokat jelző munkafüzetcellákhoz lásd a [Control the Display of Empty Cells](/slides/hu/nodejs-java/chart-series/) oldalt, ahol megtudhatod az üres cella és a null érték közötti különbséget, valamint egy vonaldiagram‑összehasonlítást a rendelkezésre álló megjelenítési módokról.

## **Diagrammadatok olvasása és írása munkafüzetből**

Az Aspose.Slides a [readWorkbookStream](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartData#readWorkbookStream--) és a [writeWorkbookStream](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/ChartData#writeWorkbookStream-byte:A-) metódusokat biztosítja, amelyek lehetővé teszik a diagrammadat‑munkafüzetek (az Aspose.Cells‑szel szerkesztett diagrammadatokkal) olvasását és írását. **Megjegyzés:** a diagrammadatnak ugyanúgy kell felépítve lennie, vagy hasonló szerkezettel kell rendelkeznie, mint a forrás.

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

### **Diagramm elrendezésének érvényesítése munkafüzet módosítása után**

Ha egy beágyazott munkafüzetet egy módosítottra cserélsz, a diagramm megőrzi az eredeti sorozat‑ és kategória‑gyűjteményeit. Ez a nincs egyezés a [Chart.validateChartLayout](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Chart#validateChartLayout--) hibához vezethet, amely index‑túl‑határt hibát dob. A meglévő sorozatokat és kategóriákat töröld, mielőtt az új munkafüzetet visszaírnád a diagrammba.

```javascript
// A munkafüzetfolyam módosítása után (pl. az Aspose.Cells használatával)
var updatedWorkbook = chartData.readWorkbookStream();

// Törölje a meglévő adatreferenciákat.
chartData.getSeries().clear();
chartData.getCategories().clear();

chartData.writeWorkbookStream(updatedWorkbook);

chart.validateChartLayout();
```

A gyűjtemények törlése biztosítja, hogy a diagrammadatszerkezet összhangban legyen az új munkafüzettel, így a `validateChartLayout` hibamentesen befejeződik.

## **Munkafüzet‑cellát beállítása diagrammadat‑címkének**

1. Hozz létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból.  
1. Szerezd meg egy dia referencia‑indexét.  
1. Adj hozzá egy Bubbler‑diagrammot némi adattal.  
1. Érd el a diagramm sorozatát.  
1. Állítsd be a munkafüzetcellát adatcímkének.  
1. Mentsd a prezentációt.

Ez a JavaScript‑kód megmutatja, hogyan állíts be egy munkafüzetcellát diagrammadat‑címkének:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var lbl0 = "Label 0 cell value";
var lbl1 = "Label 1 cell value";
var lbl2 = "Label 2 cell value";
// Példányosít egy prezentáció osztályt, amely egy prezentáció fájlt képvisel
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

Ez a JavaScript‑kód megmutatja, hogyan adhatunk meg egy típust az adatforráshoz:

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

## **Nem támogatott beágyazott munkafüzetformátumok észlelése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely néhány diagrammban beágyazható. A `getEmbeddedWorkbookType` metódust a [ChartData](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/) osztályon együtt a [WorkbookType](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/workbooktype/) felsorolással használhatod, hogy észleld a nem támogatott formátumokat, és kihagyd az érintett diagrammokat.

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
            // A beágyazott munkafüzet .xlsb formátumban van, ami nem támogatott.
            continue;
        }

        // Olvassa vagy módosítsa itt a diagramm munkafüzet adatait.
    }
} finally {
    presentation.dispose();
}
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzeteket diagrammadat‑forrásként.

### **Külső munkafüzet létrehozása**

A **`readWorkbookStream`** és a **`setExternalWorkbook`** metódusok segítségével akár egy külső munkafüzetet hozhatsz létre a semmiből, akár egy belső munkafüzetet tehetsz külsővé.

Ez a JavaScript‑kód demonstrálja a külső munkafüzet létrehozási folyamatát:

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

A **`setExternalWorkbook`** metódus segítségével egy külső munkafüzetet rendelhetsz egy diagrammhoz adatforrásként. Ezzel a metódussal frissítheted a külső munkafüzet elérési útját is (ha az áthelyezésre került).

Bár a távoli helyeken vagy erőforrásokon tárolt munkafüzetek adatait nem szerkesztheted, továbbra is használhatod ezeket külső adatforrásként. Ha relatív útvonalat adsz meg egy külső munkafüzethez, azt automatikusan teljes útvonallá alakítja a rendszer.

Ez a JavaScript‑kód megmutatja, hogyan állíts be egy külső munkafüzetet:

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

A `setExternalWorkbook` metódus második paramétere, `updateChartData`, meghatározza, hogy az Excel‑munkafüzet betöltődjön‑e vagy sem.

* Ha `updateChartData` **false**, csak a munkafüzet útvonala frissül – a diagrammadat nem töltődik be vagy frissül a célmunkafüzetről. Ezt a beállítást olyan helyzetben érdemes használni, amikor a célmunkafüzet nem létezik vagy nem érhető el.  
* Ha `updateChartData` **true**, a diagrammadat frissül a célmunkafüzetről.

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

### **Diagramm külső adatforrás munkafüzet útvonalának lekérése**

1. Hozz létre egy példányt a [Presentation](https://apireference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation) osztályból.  
1. Szerezd meg egy dia referencia‑indexét.  
1. Hozz létre egy objektumot a diagramm alakzatához.  
1. Hozz létre egy objektumot a forrás (`ChartDataSourceType`) típusához, amely a diagramm adatforrását képviseli.  
1. Add meg a megfelelő feltételt a forrástípus és a külső munkafüzet adatforrás típusa közötti egyezés alapján.

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

### **Diagrammadatok szerkesztése**

A külső munkafüzetek adatait ugyanúgy szerkesztheted, mint a belső munkafüzetek tartalmát. Ha egy külső munkafüzet nem tölthető be, kivétel keletkezik.

Ez a JavaScript‑kód a leírt folyamat megvalósítását mutatja:

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

### **Munkafüzet helyreállítása a diagramm gyorsítótárából**

Ha egy diagramm egy hiányzó vagy nem elérhető külső munkafüzetet használ, az Aspose.Slides a prezentációban gyorsítótárazott adatokból helyreállíthatja a diagramm munkafüzetét. Hozz létre egy [LoadOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/) objektumot, konfiguráld egy [SpreadsheetOptions](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/spreadsheetoptions/) segítségével, és hívd meg a [SpreadsheetOptions.setRecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/spreadsheetoptions/#setRecoverWorkbookFromChartCache) metódust **true**‑ra, mielőtt megnyitod a prezentációt.

Az alábbi JavaScript‑példa megnyit egy prezentációt, amelynek diagrammjának hivatkozása egy nem elérhető külső munkafüzetre mutat, és a helyreállított adatot a [ChartData.getChartDataWorkbook](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/#getChartDataWorkbook) segítségével érheti el:

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

    // Olvassa vagy módosítsa itt a helyreállított munkafüzet adatait.
} finally {
    presentation.dispose();
}
```

Ha a külső munkafüzet nem érhető el, és a helyreállítás ki van kapcsolva, az Aspose.Slides kivételt dob. Engedélyezd a helyreállítást csak akkor, ha a gyorsítótárazott diagrammadatok használata elfogadható tartalék megoldás, mivel a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzetben a prezentáció legutóbbi frissítése óta végzett módosításokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagramm külső vagy beágyazott munkafüzethez kapcsolódik‑e?**  
Igen. A diagrammnek van egy [data source type](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/getdatasourcetype/) és egy [path to an external workbook](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/); ha a forrás egy külső munkafüzet, kiolvashatod a teljes útvonalat, hogy megbizonyosodj arról, hogy külső fájlt használsz.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**  
Igen. Ha relatív útvonalat adsz meg, azt automatikusan abszolút útvonallá alakítja a rendszer. Ez a projekt hordozhatóságát segíti; azonban a prezentáció az abszolút útvonalat tárolja a PPTX‑fájlban.

**Használhatok munkafüzeteket hálózati erőforrásokon/megosztásokon?**  
Igen, az ilyen munkafüzetek használhatók külső adatforrásként. A távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ból nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja a külső XLSX‑et a prezentáció mentésekor?**  
Nem. A prezentáció egy [link to the external file](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/chartdata/getexternalworkbookpath/) tárol, és ezt használja az adatolvasáshoz. A külső fájl magát nem módosítja a mentés.

**Mit tegyek, ha a külső fájl jelszóval védett?**  
Az Aspose.Slides nem fogad el jelszót a hivatkozáskor. Általános megoldás, hogy előzetesen eltávolítod a védelmet, vagy egy dekódolt másolatot készítesz (például a [Aspose.Cells](/cells/nodejs-java/) használatával), és ehhez a másolathoz hivatkozol.

**Több diagramm is hivatkozhat ugyanarra a külső munkafüzetre?**  
Igen. Minden diagramm a saját hivatkozását tárolja. Ha ugyanarra a fájlra mutatnak, a fájl frissítése minden diagrammra hatással lesz a következő adatbetöltéskor.