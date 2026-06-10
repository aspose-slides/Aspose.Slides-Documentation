---
title: Integrálja az Excel-adatokat a PowerPoint-prezentációkba
linktitle: Excel integráció
type: docs
weight: 330
url: /hu/nodejs-java/excel-integration/
keywords:
- Excel
- munkafüzet
- Excel olvasása
- Excel integrálása
- adatforrás
- körlevél
- tábla importálása
- Excel a PowerPointba
- PowerPoint
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Olvassa be az adatokat Excel-munkafüzetekből JavaScript-ben az Aspose.Slides segítségével. Töltse be a lapokat és cellákat, és használja az értékeket adatvezérelt PowerPoint-prezentációk generálásához."
---
## **Bevezetés**

A PowerPoint‑prezentációk hatékony módja az információ megjelenítésének és közvetítésének. Gyakran használják őket az Excel‑munkafüzetekkel együtt, ahol az Excel kitűnő forrása a strukturált adatoknak, a PowerPoint pedig kiválóan megjeleníti ezeket az adatokat a közönség számára.

Számos gyakorlati esetben elengedhetetlen az Excel és a PowerPoint kombinálása: körlevélkészítés, adat táblák feltöltése, egy diát generálni adat rekordonként (csoportos dia generálás), képzési anyagok készítése, valamint több Excel‑jelentés egyetlen prezentációba való összevonása, csak néhány példa.

Eddig az ilyen funkciók megvalósítása az Aspose.Slides API‑val harmadik féltől származó megoldásokra, például az Aspose.Cells‑re támaszkodott. Bár ezek az eszközök robusztusak, túl komplexek és költségesek lehetnek azok számára, akiknek csak alapvető adatintegrációs funkciókra van szükségük.

## **Hogyan működik**

Az Excel‑adatokkal való munka egyszerűbbé és hatékonyabbá tétele érdekében az Aspose.Slides új osztályokat vezetett be az Excel‑munkafüzetek olvasására és a tartalom prezentációba importálására. Ez a funkció új lehetőségeket nyit meg az API‑felhasználók számára, akik az Excel‑t adatforrásként kívánják használni a prezentációs munkafolyamatokban.

Az új funkció általános célú adatlekérdezésre készült, és nincs integrálva a Presentation Document Object Model (DOM)-ba. Ez azt jelenti, *hogy nem engedélyezi az Excel‑fájlok szerkesztését vagy mentését* – kizárólag a munkafüzetek megnyitására és a tartalmukban való navigálásra szolgál a cella‑adatok lekérdezéséhez.

A funkció középpontjában az új [ExcelDataWorkbook](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/exceldataworkbook/) osztály áll. Ezzel az osztállyal helyi fájlból vagy adatfolyamból tölthet be egy Excel‑munkafüzetet. Betöltés után több overload‑ot kínál a [getCell](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/exceldataworkbook/#getCell) metódushoz, amely segítségével a cellákat pozíciójuk (például sor‑ és oszlop‑indexek vagy név‑tartományok) alapján kérdezheti le.

Minden [getCell](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/exceldataworkbook/#getCell) hívás egy [ExcelDataCell](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/exceldatacell/) példányt ad vissza. Ez az objektum egyetlen cellát képvisel az Excel‑munkafüzetben, és egyszerű, intuitív módon ad hozzáférést annak értékéhez.

#### **Excel‑diagram importálása**

A funkciók bővítésének következő lépése a [ExcelWorkbookImporter](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/excelworkbookimporter/) osztály. Ez az segédosztály az Excel‑munkafüzet tartalmának prezentációba importálását teszi lehetővé. Több overload‑ot tartalmaz a [addChartFromWorkbook](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook) metódushoz, amelyekkel a megadott Excel‑munkafüzetből kiválaszthatja a kívánt diagramot, és a megadott koordinátákon a cél alakzatgyűjtemény végéhez adhatja hozzá.

Röviden, ez egy könnyű és egyszerű API az Excel‑adatok olvasásához – pontosan azt, amire sok fejlesztőnek szüksége van anélkül, hogy egy teljes táblázat‑feldolgozó könyvtárra támaszkodna.

## **Kódoljunk**

### **Mail Merge szcenárió példa**

Az alábbi példában egy egyszerű Mail Merge szcenáriót valósítunk meg, amely több prezentációt generál az Excel‑munkafüzetben tárolt adatok alapján.

A kezdéshez két dologra van szükségünk:
1. Az adatokat tartalmazó Excel‑munkafüzet

![Excel adatok példája](example1_image0.png)

2. PowerPoint‑prezentáció sablon

![PowerPoint sablon példája](example1_image1.png)

```js
// Töltsük be az Excel-munkafüzetet a munkavállalói adatokkal.
let workbook = new aspose.slides.ExcelDataWorkbook("TemplateData.xlsx");
const worksheetIndex = 0;

// Töltsük be a prezentáció sablont.
let templatePresentation = new aspose.slides.Presentation("PresentationTemplate.pptx");

try {
    // Iteráljunk végig az Excel sorokon (a 0. sor fejléce nélkül).
    for (let rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // Hozzunk létre egy új prezentációt minden egyes munkavállalói rekordhoz.
        let employeePresentation = new aspose.slides.Presentation();

        try {
            // Távolítsuk el az alapértelmezett üres diát.
            employeePresentation.getSlides().removeAt(0);

            // Klónozzuk a sablon diát az új prezentációba.
            let slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // Szerezzük meg a bekezdéseket a cél alakzatról (feltevés: az 1-es indexű alakzatot használjuk).
            let paragraphs = slide.getShapes().get_Item(1).getTextFrame().getParagraphs();

            // Cseréljük le a helyőrzőket az Excel adataival.
            let employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            let namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            let department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            let departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            let yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            let yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // Mentsük el a személyre szabott prezentációt egy külön fájlba.
            employeePresentation.save(`${employeeName} Report.pptx`, aspose.slides.SaveFormat.Pptx);
        } finally {
            employeePresentation.dispose();
        }
    }
} finally {
    templatePresentation.dispose();
}
```

![Eredmény](example1_image2.png)

### **Excel‑tábla példa**

A második példában egyszerűen egy Excel‑táblából másoljuk az adatokat, és egy PowerPoint‑dián jelenítjük meg őket vizuálisan vonzóbb formában.

Ebben a példában ugyanazt az Excel‑munkafüzetet használjuk, amelyet az első példában már bemutattunk, és amely egy egyszerű alkalmazotti táblát tartalmaz.

```js
// Töltsük be az Excel-munkafüzetet, amely a munkavállalói adatokat tartalmaz.
let workbook = new aspose.slides.ExcelDataWorkbook("TemplateData.xlsx");
const worksheetIndex = 0;

// Hozzunk létre egy új PowerPoint-prezentációt.
let presentation = new aspose.slides.Presentation();

try {
    // Adjunk egy táblázat alakzatot az első diára.
    let table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            java.newArray("double", [200, 200, 200]),
            java.newArray("double", [30, 30, 30, 30, 30])
    );

    // Töltsük meg a PowerPoint-táblázatot az Excel-munkafüzet adataival.
    for (let rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (let columnIndex = 0; columnIndex < 3; columnIndex++) {
            let cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // Mentsük el a kapott prezentációt egy fájlba.
    presentation.save("Table.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Eredmény](example2_image0.png)

### **Excel‑diagram importálása példa**

Ebben a példában egy diagramot importálunk az előző példában használt Excel‑munkafüzet első munkalapjáról. A diagram a végső prezentációban a külső munkafüzethez fog kapcsolódni.

Először egy kördiagramot adunk az Excel‑munkafüzethez az alkalmazottak táblája alapján.

![Excel diagram példa](example3_image0.png)

```js
// Hozzunk létre egy új PowerPoint-prezentációt.
let presentation = new aspose.slides.Presentation();
try {
    // Szerezzük meg az első dia alakzatgyűjteményét.
    let shapes = presentation.getSlides().get_Item(0).getShapes();

    // Importáljuk a "Chart 1" nevű diagramot a munkafüzet első lapjáról, és adjuk hozzá az alakzatgyűjteményhez.
    aspose.slides.ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Mentsük el a kapott prezentációt egy fájlba.
    presentation.save("Chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Eredmény](example3_image1.png)

### **Minden Excel‑diagram importálása példa**

Képzeljük el, hogy egy Excel‑munkafüzet tele van diagramokkal, és mindet importálni kell egy prezentációba. Minden diagramot egy új diára kell helyezni.

Az alábbi kód végigiterál a forrás‑Excel‑fájl minden munkalapján, kivonja a diagramokat, és minden diagramot egy külön diára helyez egy üres dia‑elrendezés használatával. A létrejövő prezentációban csak a diagramadatok lesznek beágyazva, a teljes munkafüzet nem.

```js
// Töltsük be az Excel-munkafüzetet, amely a munkavállalói adatokat tartalmaz.
let workbook = new aspose.slides.ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Hozzunk létre egy új PowerPoint-prezentációt.
let presentation = new aspose.slides.Presentation();
try {
    // Szerezzük meg az üres diaelrendezést.
    let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

    // Szerezzük meg az Excel-munkafüzetben található összes munkalap nevét.
    let worksheetNames = workbook.getWorksheetNames().iterator();

    while (worksheetNames.hasNext()) {
        let name = worksheetNames.next();
        // Szerezzük meg a térképet, amely a diagramindexeket a munkalap diagramneveire képezi.
        let worksheetCharts = workbook.getChartsFromWorksheet(name).iterator();

        while (worksheetCharts.hasNext()) {
            let chart = worksheetCharts.next();
            // Adjunk hozzá egy új diát az üres elrendezés használatával.
            let slide = presentation.getSlides().addEmptySlide(layoutSlide);

            // Importáljuk a megadott diagramot az Excel-munkafüzetről a dia alakzatgyűjteményébe.
            aspose.slides.ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // Mentsük el a kapott prezentációt egy fájlba.
    presentation.save("Charts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Összefoglalás**

Ez a mechanizmus, amely közvetlenül az Aspose.Slides‑ben érhető el, egy helyen egyesíti az Excel‑adatok és a prezentációk kezelését. Lehetővé teszi, hogy diákat hozzunk létre vizuális diagramokkal és Excel‑táblákban megjelenített adatokkal – további könyvtárak vagy bonyolult integrációk nélkül.