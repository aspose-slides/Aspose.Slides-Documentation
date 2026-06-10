---
title: Excel-adatok integrálása PowerPoint-prezentációkba
linktitle: Excel integráció
type: docs
weight: 330
url: /hu/java/excel-integration/
keywords:
- Excel
- munkafüzet
- Excel olvasása
- Excel integrálása
- adatforrás
- levélösszevonás
- táblázat importálása
- Excel PowerPointba
- PowerPoint
- prezentáció
- Java
- Aspose.Slides
description: "Olvassa be az Excel-munkafüzetek adatait az Aspose.Slides-ban az ExcelDataWorkbook API használatával. Töltse be a munkalapokat és cellákat, és használja az értékeket adat‑vezérelt PowerPoint-prezentációk létrehozásához."
---
## **Bevezetés**

A PowerPoint-prezentációk hatékony módot jelentenek az információk megjelenítésére és közvetítésére. Gyakran használják őket az Excel-munkafüzetekkel együtt, ahol az Excel kiváló forrása a strukturált adatoknak, a PowerPoint pedig kiválóan megjeleníti ezeket az adatokat a közönség számára.

Számos gyakorlati esetben elengedhetetlen az Excel és a PowerPoint kombinálása: levélösszevonások, adat-táblák feltöltése, egy diát generálás egy adatrekordhoz (készlet diakészítés), oktatási anyagok létrehozása, valamint több Excel-jelentés egyetlen prezentációba való összevonása, csak néhány példa.

Eddig az ilyen funkciók megvalósítása az Aspose.Slides API-val harmadik fél megoldásaira, például az Aspose.Cells-re támaszkodott. Bár ezek az eszközök robusztusak, a felhasználók számára – akiknek csak alapvető adatintegrációs funkcióra van szükségük – túl összetettek és költségesek lehetnek.

## **Hogyan működik**

Az Excel-adatokkal való munka egyszerűbbé és hatékonyabbá tételéhez az Aspose.Slides új osztályokat vezetett be az Excel-munkafüzetek adatainak beolvasásához és a tartalom prezentációba történő importálásához. Ez a funkció új, erőteljes lehetőségeket nyit meg az API felhasználói számára, akik az Excelt adatforrásként szeretnék használni a prezentációs munkafolyamatokban.

Az új funkció általános célú adatlekérdezésre készült, és nem integrálódik a Presentation Document Object Model (DOM)-ba. Ez azt jelenti, hogy *nem teszi lehetővé az Excel-fájlok szerkesztését vagy mentését* – egyetlen célja a munkafüzetek megnyitása és a tartalmukban való navigálás a cellaadatok lekérdezéséhez.

Ennek a funkciónak a középpontjában az új [ExcelDataWorkbook](https://reference.aspose.com/slides/hu/java/com.aspose.slides/exceldataworkbook/) osztály áll. Ez az osztály lehetővé teszi egy Excel-munkafüzet betöltését helyi fájlból vagy folyamatról. Betöltés után több overloadja is van a [getCell](https://reference.aspose.com/slides/hu/java/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) metódusnak, amelyet a cellák pozíciójuk (pl. sor- és oszlopindexek vagy névvel ellátott tartományok) alapján történő lekérdezésére használhat.

Minden [getCell](https://reference.aspose.com/slides/hu/java/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) hívás egy [ExcelDataCell](https://reference.aspose.com/slides/hu/java/com.aspose.slides/exceldatacell/) osztálypéldányt ad vissza. Ez az objektum egyetlen cellát képvisel az Excel-munkafüzetben, és egyszerű, intuitív módon biztosít hozzáférést az értékéhez.

#### **Excel-diagram importálása**

A funkcionalitás kibővítésének következő lépése a [ExcelWorkbookImporter](https://reference.aspose.com/slides/hu/java/com.aspose.slides/excelworkbookimporter/) osztály. Ez a segédosztály funkciót biztosít az Excel-munkafüzetből a prezentációba történő tartalom importálásához. Több overloadja is van a [addChartFromWorkbook](https://reference.aspose.com/slides/hu/java/com.aspose.slides/excelworkbookimporter/#addChartFromWorkbook-com.aspose.slides.IShapeCollection-float-float-com.aspose.slides.IExcelDataWorkbook-java.lang.String-int-boolean-) metódusnak, amely segít a megadott Excel-munkafüzetből a kiválasztott diagram lekérdezésében és a megadott koordinátákon a megadott alakzatgyűjtemény végéhez hozzáadásában.

Röviden, ez egy könnyű és egyszerű API az Excel-adatok beolvasásához – pontosan azt, amire sok fejlesztőnek szüksége van, anélkül, hogy teljes táblázatkezelő könyvtár terhe lenne.

## **Kódoljunk**

### **Levélösszevonási szituáció példa**

A következő példában egy egyszerű levélösszevonási szituációt valósítunk meg, több prezentáció generálásával egy Excel-munkafüzetben tárolt adatok alapján.

A kezdéshez két dologra van szükségünk:
1. Egy Excel-munkafüzet, amely tartalmazza az adatokat

![Excel adat példa](example1_image0.png)

2. PowerPoint prezentációs sablon

![PowerPoint sablon példa](example1_image1.png)

```java
// Töltsük be az Excel-munkafüzetet a munkavállalói adatokkal.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Töltsük be a prezentáció sablont.
Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // Iteráljunk végig az Excel-sorokon (kivéve a 0. sor fejléce).
    for (int rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // Hozzunk létre egy új prezentációt minden munkavállalói rekordhoz.
        Presentation employeePresentation = new Presentation();

        try {
            // Távolítsuk el az alapértelmezett üres diát.
            employeePresentation.getSlides().removeAt(0);

            // Klónozzuk a sablon diát az új prezentációba.
            ISlide slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // Szerezzük meg a bekezdéseket a cél alakzatról (feltételezve, hogy az 1-es indexű alakzatot használjuk).
            IParagraphCollection paragraphs = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame().getParagraphs();

            // Cseréljük le a helyőrzőket az Excel adatával.
            String employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            IPortion namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            String department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            IPortion departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            String yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            IPortion yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // Mentsük a személyre szabott prezentációt egy külön fájlba.
            employeePresentation.save(String.format("%s Report.pptx", employeeName), SaveFormat.Pptx);
        } finally {
            employeePresentation.dispose();
        }
    }
} finally {
    templatePresentation.dispose();
}
```

![Eredmény](example1_image2.png)

### **Excel-tábla példa**

A második példában egyszerűen átmásoljuk az adatokat egy Excel-táblából, és egy PowerPoint-dián jelenítjük meg egy vonzóbb vizuális formátumban.

Ebben a példában újra felhasználjuk az első példából származó ugyanazt az Excel-munkafüzetet, amely egy egyszerű alkalmazotti táblát tartalmaz.

```java
// Töltsük be az alkalmazotti adatokat tartalmazó Excel-munkafüzetet.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Hozzunk létre egy új PowerPoint-prezentációt.
Presentation presentation = new Presentation();

try {
    // Adjunk egy táblázat alakzatot az első diára.
    ITable table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            new double[]{200, 200, 200},
            new double[]{30, 30, 30, 30, 30}
    );

    // Töltsük fel a PowerPoint-táblát az Excel-munkafüzet adataival.
    for (int rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (int columnIndex = 0; columnIndex < 3; columnIndex++) {
            String cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // Mentsük a keletkezett prezentációt egy fájlba.
    presentation.save("Table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Eredmény](example2_image0.png)

### **Excel-diagram importálása példa**

Ebben a példában egy diagramot importálunk az előző példában használt Excel-munkafüzet első munkalapjáról. A diagram a külső munkafüzethez lesz csatolva a kapott prezentációban.

Először egy kördiagramot adunk az Excel-munkafüzethez az alkalmazotti tábla alapján.

![Excel diagram példa](example3_image0.png)

```java
// Hozzunk létre egy új PowerPoint-prezentációt.
Presentation presentation = new Presentation();
try {
    // Szerezzük meg az első dia alakzatgyűjteményét.
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    // Importáljuk a "Chart 1" nevű diagramot a munkafüzet első lapjáról, és adjuk hozzá az alakzatgyűjteményhez.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Mentsük a keletkezett prezentációt egy fájlba.
    presentation.save("Chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Eredmény](example3_image1.png)

### **Minden Excel-diagram importálása példa**

Képzeljünk el egy olyan Excel-munkafüzetet, amely tele van diagramokkal, és ezeket mind importálni kell egy prezentációba. Minden diagramot egy új diára kell elhelyezni.

A következő kód végigiterál az összes munkalapon a forrás Excel-fájlban, kinyeri a diagramokat minden munkalapról, és egy üres diaterv segítségével minden diagramot külön diára helyez. A kapott prezentációban csak a diagram adatai lesznek beágyazva, nem a teljes munkafüzet.

```java
// Töltsük be az alkalmazotti adatokat tartalmazó Excel-munkafüzetet.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Hozzunk létre egy új PowerPoint-prezentációt.
Presentation presentation = new Presentation();
try {
    // Szerezzük meg az üres dia elrendezését.
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Szerezzük meg az Excel-munkafüzetben lévő összes munkalap nevét.
    List<String> worksheetNames = workbook.getWorksheetNames();

    for (String name : worksheetNames) {
        // Szerezzünk egy leképezést, amely a diagram indexeket a munkalap diagramneveire térképezi.
        Dictionary<Integer, String> worksheetCharts = workbook.getChartsFromWorksheet(name);

        for (KeyValuePair<Integer, String> chart : worksheetCharts) {
            // Adjunk hozzá egy új diát az üres elrendezés használatával.
            ISlide slide = presentation.getSlides().addEmptySlide(blankLayout);

            // Importáljuk a megadott diagramot az Excel-munkafüzetből a dia alakzatgyűjteményébe.
            ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // Mentsük a keletkezett prezentációt egy fájlba.
    presentation.save("Charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Összefoglalás**

Ez a mechanizmus, amely közvetlenül az Aspose.Slides-ben érhető el, egy helyen ötvözi az Excel-adatokkal és a prezentációkkal való munkát. Lehetővé teszi, hogy vizuális diagramokkal és Excel táblaként bemutatott adatokkal ellátott diákat hozzon létre – további könyvtárak vagy összetett integrációk nélkül.