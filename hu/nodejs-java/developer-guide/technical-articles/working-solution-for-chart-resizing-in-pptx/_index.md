---
title: Működő megoldás a diagram átméretezéséhez PPTX-ben
type: docs
weight: 40
url: /hu/nodejs-java/working-solution-for-chart-resizing-in-pptx/
keywords:
- diagram átméretezés
- Excel diagram
- OLE objektum
- diagram beágyazása
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Javítsa a PPTX-ben előforduló váratlan diagram átméretezést beágyazott Excel OLE objektumok használatakor az Aspose.Slides for Node.js via Java segítségével. Állítson be rögzített diagramméreteket, hogy a diagram és az OLE keret méretei következetesek maradjanak."
---
## **Áttekintés**

Az Aspose komponenseket használó PowerPoint‑prezentációkban OLE‑objektumként beágyazott Excel‑diagramok első aktiválásuk után megváltoztathatják a méretüket. Ez észrevehető különbséget eredményezhet a diagram megjelenése között aktiválás előtt és után. Ez a cikk elmagyarázza, miért fordul elő az átméretezés, és bemutatja, hogyan lehet megelőzni azt úgy, hogy a rögzített diagramméreteket az OLE‑kerethez illesztjük.

Az [Excel‑diagramok létrehozása és OLE‑objektumként történő beágyazása a prezentációkba](/slides/hu/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/) című cikkben bemutattuk, hogyan lehet Aspose.Cells for Node.js via Java segítségével Excel‑diagramot készíteni, majd azt Aspose.Slides for Node.js via Java‑val PowerPoint‑prezentációba beágyazni. Az [objektum előnézeti probléma](/slides/hu/nodejs-java/object-preview-issue-when-adding-oleobjectframe/) megoldásaként a diagram képét rendeltük a diagram OLE‑objektumkeretéhez. A kimeneti prezentációban, ha duplán a diagramképet megjelenítő OLE‑objektumkeretre kattintunk, az Excel‑diagram aktiválódik. A felhasználók szerkeszthetik a beágyazott Excel‑munkafüzetet, majd a aktivált munkafüzeten kívülre kattintva visszatérhetnek a diára. Az OLE‑objektumkeret mérete megváltozik, amikor a felhasználó visszatér a diára, és az átméretezési arány a OLE‑objektumkeret és a beágyazott Excel‑munkafüzet eredeti méreteitől függ.

## **Az átméretezés oka**

A beágyazott Excel‑munkafüzet saját ablakméretekkel rendelkezik, amelyeket az Excel megpróbál megtartani, amikor az objektum először aktiválódik. A dián lévő OLE‑keret önállóan definiált méretekkel bír. Amikor az Excel‑munkafüzet aktiválódik, az Excel és a PowerPoint egyeztetik az objektum méretét, hogy a beágyazási folyamat részeként arányait megtartsa. A munkafüzetablak és az OLE‑keret közötti eltérések ezért az objektum átméreteződését okozhatják.

## **Működő megoldás**

Illessze a diagram méretét a dián lévő OLE‑kerethez, és tartsa a diagramméreteket a munkafüzetablaktól függetlenül. Ez a megoldás új prezentációval vagy meglévő sablonnal egyaránt működik.

A példa az Aspose.Cells for Node.js via Java és az Aspose.Slides for Node.js via Java csomagokat igényli. Telepítse a `aspose.cells`, `aspose.slides.via.java` és `java` Node.js csomagokat. Futtassa az alábbi két CommonJS‑scriptet külön Node.js‑processzben, ugyanabban a munkakönyvtárban, mivel mindkét Aspose‑csomag a betöltés során inicializálja a Java‑hidat. A script egy egyszerű oszlopdiagramot hoz létre az aktív diagramlapon, és beágyazza a munkafüzetet XLS formátumban. Nem kerül diagram‑előnézeti kép hozzárendelésre; a diagram a OLE‑objektum PowerPoint‑ban való aktiválásakor válik láthatóvá.

A példa egy új prezentációt hoz létre, amely 9.5 × 4‑hüvelykes OLE‑kerettel rendelkezik, balról 0.5 hüvelyk, felül pedig 1 hüvelyk távolságra elhelyezve. A dia koordinátái és méretei pontokban (72 pont hüvelykenként) vannak megadva. Meglévő prezentáció esetén lásd a [Sablon használata](#use-a-template) szekciót.

## **Állítsa be a rögzített diagramméretet**

Állítsa a [setSizeWithWindow](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setsizewithwindow) értékét false-ra, hogy a diagramméretek függetlenek legyenek a munkafüzetablaktól. Állítsa a [getChartObject](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#getchartobject) méreteit a [setWidth](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setwidth) és a [setHeight](https://reference.aspose.com/cells/nodejs/aspose.cells/shape/#setheight) segítségével, a pontokat 96 pixel/hüvelyk átváltással pixelekké konvertálva: egy 684 × 288 pont méretű keret 912 × 384 pixel méretű diagramnak felel meg. Állítsa a [setPrintSize](https://reference.aspose.com/cells/nodejs/aspose.cells/chart/#setprintsize) értékét a `PrintSizeType` CUSTOM értékére. A példa a [addOleObjectFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/#addOleObjectFrame) segítségével ágyazza be a munkafüzetet, és egy 9.5 × 4 hüvelykes OLE‑kerettel rendelkező prezentációt ment.

Mentse az első scriptet `create-fixed-chart.js` néven. Ez egy `chart-fixed-size.xls` fájlt hoz létre, amely 912 × 384 pixel méretű diagramot tartalmaz, ami megfelel a második script által használt 684 × 288 pont méretű keretnek. Bemeneti munkafüzet nem szükséges.

```javascript
const cells = require("aspose.cells");

const workbook = new cells.Workbook();
try {
    const dataSheet = workbook.getWorksheets().get(0);
    dataSheet.setName("Data");
    dataSheet.getCells().get("A1").putValue(10);
    dataSheet.getCells().get("A2").putValue(20);

    const chartSheetIndex = workbook.getWorksheets().add(cells.SheetType.CHART);
    const chartSheet = workbook.getWorksheets().get(chartSheetIndex);
    const chartIndex = chartSheet.getCharts().add(cells.ChartType.COLUMN, 0, 0, 20, 10);
    const chart = chartSheet.getCharts().get(chartIndex);
    chart.getNSeries().add("Data!A1:A2", true);
    workbook.getWorksheets().setActiveSheetIndex(chartSheetIndex);

    // Illessze az OLE keret méreteit pontban (72 pont hüvelykenként).
    const width = 684; // 9,5 hüvelyk.
    const height = 288; // 4 hüvelyk.

    chart.setSizeWithWindow(false);
    // Konvertálja a pontokat diagram pixelé 96 pixel/hüvelyk használatával.
    chart.getChartObject().setWidth(Math.trunc(width / 72 * 96));
    chart.getChartObject().setHeight(Math.trunc(height / 72 * 96));
    chart.setPrintSize(cells.PrintSizeType.CUSTOM);

    workbook.save("chart-fixed-size.xls", cells.SaveFormat.EXCEL_97_TO_2003);
} finally {
    workbook.dispose();
}

// Minden szinkronizált munka befejeződött; leállítja a Java hidat.
process.exit(0);
```

Mentse a második scriptet `embed-fixed-chart.js` néven, és futtassa a `create-fixed-chart.js` után. A script beolvassa a generált XLS munkafüzetet, és elmenti a `chart-fixed-size.pptx` fájlt. A Java‑híd explicit Java‑byte‑tömböt igényel a munkafüzet adatainak, valamint Java‑float értékeket a keret koordinátáihoz és méreteihez. Az `xls` kiterjesztés megfelel a munkafüzet mentett formátumának.

```javascript
const fs = require("fs");
const java = require("java");
const slides = require("aspose.slides.via.java");

const workbookBuffer = fs.readFileSync("chart-fixed-size.xls");
const workbookBytes = java.newArray("byte", Array.from(workbookBuffer));
const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    // Diának a koordinátái és méretei pontban vannak (72 pont hüvelykenként).
    const width = 684; // 9,5 hüvelyk.
    const height = 288; // 4 hüvelyk.
    const dataInfo = new slides.OleEmbeddedDataInfo(workbookBytes, "xls");
    slide.getShapes().addOleObjectFrame(java.newFloat(36), java.newFloat(72), java.newFloat(width), java.newFloat(height), dataInfo);

    presentation.save("chart-fixed-size.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

// Minden szinkron munka befejeződött; leállítja a Java hidat.
process.exit(0);
```

## **Sablon használata**

Az átméretezési logika ugyanaz meglévő prezentációk esetén is. A példa adaptálásához:

1. Töltsön be egy sablonprezentációt az üres prezentáció létrehozása helyett.
1. Ellenőrizze, hogy az első dia legalább három alakzatot tartalmaz, majd a 2. indexű alakzatot használja helykitöltőként.
1. Vegye a keret szélességét és magasságát abból az alakzatból a 684 és 288 rögzített értékek helyett. Használja ugyanazokat a méreteket a munkafüzet‑létrehozó scriptben, a méretezési számítások változatlanul tartásával, és generálja újra az XLS munkafüzetet, mielőtt beágyazná.
1. Adja hozzá az OLE keretet a helykitöltő pozíciójához a 36 és 72 rögzített koordináták helyett.
1. Távolítsa el a helykitöltőt a prezentáció mentése előtt.

## **FAQ**

**Miért változik meg a beágyazott Excel‑diagram mérete a PowerPoint‑ban történő aktiválás után?**

Ez azért történik, mert az Excel megpróbálja visszaállítani az eredeti ablakméretet az első aktiváláskor, míg a PowerPoint‑ban lévő OLE‑objektumkeret saját méretekkel rendelkezik. A PowerPoint és az Excel a méretet egyeztetik, hogy megtartsák az arányt, ami az átméretezést okozhatja.

**Hogyan tarthatom konzisztensnek a diagram és az OLE‑keret méretét?**

Állítson be rögzített diagramméreteket, amelyek megegyeznek az OLE‑kerettel, és használjon egyedi diagramnyomtatási méretet a munkafüzet beágyazása előtt. A fenti példa bemutatja a szükséges beállításokat és egységkonverziókat.

**Elégséges a munkafüzetablak méretének egyeztetése?**

A munkafüzetablak méretének egyeztetése önmagában nem biztosítja megbízhatóan, hogy az OLE‑keret mérete ne változzon az aktiválás után. Használjon rögzített diagramméreteket, ahogy a példában látható.

**Ez a megoldás működik sablon‑alapú és új prezentációkkal egyaránt?**

Igen. Sablonnal dolgozva használja a helykitöltő méreteit és pozícióját. Új prezentáció esetén adja meg közvetlenül a keret méreteit és pozícióját.

**Használhatom ezt a példát más táblázatkezelő programokban létrehozott diagramokkal?**

A példa egy Aspose.Cells‑el létrehozott Excel‑munkafüzetet használ. Nem mutatja be az aktiválási viselkedést más táblázatkezelő programok esetén.

## **Kapcsolódó szakaszok**

- [Excel‑diagramok létrehozása és OLE‑objektumként beágyazása a prezentációkba](/slides/hu/nodejs-java/creating-excel-chart-and-embedding-it-in-presentation-as-ole-object/)