---
title: Integrálja az Excel adatokat PowerPoint prezentációkba
linktitle: Excel integráció
type: docs
weight: 330
url: /hu/androidjava/excel-integration/
keywords:
- Excel
- munkafüzet
- Excel olvasás
- Excel integráció
- adatforrás
- levélösszevonás
- tábla importálása
- Excel PowerPointba
- PowerPoint
- prezentáció
- Android
- Java
- Aspose.Slides
description: "Olvassa be az adatokat Excel munkafüzetekből az Aspose.Slides-ben az ExcelDataWorkbook API használatával. Töltse be a munkalapokat és cellákat, és használja fel az értékeket adatközpontú PowerPoint prezentációk generálásához."
---
## **Bevezetés**

A PowerPoint‑prezentációk erőteljes módot nyújtanak az információk megjelenítésére és közvetítésére. Gyakran használják őket Excel‑munkafüzetekkel együtt, ahol az Excel kiváló struktúrált adatforrás, a PowerPoint pedig kiválóan megjeleníti ezeket az adatokat a közönség számára.

Számos gyakorlati helyzetben elengedhetetlen az Excel és a PowerPoint kombinálása: levél‑összevonások, adattáblák feltöltése, egy diát minden adatrekordhoz generálása (csoportos diagenerálás), képzési anyagok létrehozása, valamint több Excel‑jelentés egyetlen prezentációba történő összevonása, csak néhány példa.

Addig eddig az ilyen funkciók megvalósítása az Aspose.Slides API‑val harmadik féltől származó megoldásokra, például az Aspose.Cells‑re támaszkodott. Bár ezek az eszközök robusztusak, túl komplexek és költségesek lehetnek azok számára, akiknek csak az alapvető adatintegrációs funkciók kellenek.

## **Hogyan működik**

Az Excel‑adatokkal való munka egyszerűbbé és hatékonyabbá tételéért az Aspose.Slides új osztályokat vezetett be az Excel‑munkafüzetek beolvasásához és a tartalom prezentációba való importálásához. Ez a funkció új lehetőségeket nyit meg az API‑felhasználók számára, akik az Excel‑t adatforrásként kívánják használni a prezentációs munkafolyamatokban.

Az új funkcionalitás általános célú adatlekérésre készült, és nincs beépítve a Presentation Document Object Model (DOM)‑ba. Ez azt jelenti, *nem teszi lehetővé az Excel‑fájlok szerkesztését vagy mentését* – kizárólag munkafüzetek megnyitására és azok tartalmának bejárására szolgál a cellaadatok lekérdezéséhez.

A funkció középpontjában az új [ExcelDataWorkbook](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/exceldataworkbook/) osztály áll. Ez az osztály lehetővé teszi egy Excel‑munkafüzet betöltését helyi fájlból vagy adatfolyamból. Betöltés után több overloadot kínál a [getCell](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) metódushoz, amellyel a cellákat pozíció (sor‑ és oszlopt index) vagy név alapján kérhetjük le.

Minden [getCell](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/exceldataworkbook/#getCell-int-int-int-) hívás egy [ExcelDataCell](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/exceldatacell/) példányt ad vissza. Ez az objektum egyetlen cellát reprezentál az Excel‑munkafüzetben, és egyszerű, intuitív módon ad hozzáférést az értékéhez.

#### **Excel diagram importálása**

A funkcionalitás továbbfejlesztéséhez a [ExcelWorkbookImporter](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/excelworkbookimporter/) osztály kerül bemutatásra. Ez az segédosztály az Excel‑munkafüzetből történő tartalomimportálásra szolgál prezentációba. Több overloadot tartalmaz a [addChartFromWorkbook](https://reference.aspose.com/slides/hu/androidjava/com.aspose.slides/excelworkbookimporter/#addChartFromWorkbook-com.aspose.slides.IShapeCollection-float-float-com.aspose.slides.IExcelDataWorkbook-java.lang.String-int-boolean-) metódushoz, amelyekkel a megadott Excel‑munkafüzetből a kiválasztott diagramot kinyerve a megadott koordinátákon a cél alakgyűjtemény végére illeszthető.

Röviden, egy könnyű és egyszerű API az Excel‑adatok beolvasásához – pontosan azt, amire sok fejlesztőnek szüksége van anélkül, hogy egy teljes táblázatfeldolgozó könyvtárra támaszkodna.

## **Kódoljunk**

### **Levélösszevonás szcenárió példa**

Az alábbi példában egy egyszerű Levélösszevonás szcenáriót valósítunk meg, több prezentáció generálásával egy Excel‑munkafüzetben tárolt adatok alapján.

A kezdéshez két dologra van szükségünk:
1. Egy Excel‑munkafüzet, amely tartalmazza az adatokat

![Excel adat példa](example1_image0.png)

2. PowerPoint sablon

![PowerPoint sablon példa](example1_image1.png)

```java
// Töltsd be az Excel munkafüzetet a munkavállalói adatokkal.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Töltsd be a prezentáció sablont.
Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // Iterálj végig az Excel sorokon (kivéve a 0. sor fejléccel).
    for (int rowIndex = 1; rowIndex <= 4; rowIndex++) {

        // Hozz létre egy új prezentációt minden munkavállalói rekordhoz.
        Presentation employeePresentation = new Presentation();

        try {
            // Távolítsd el az alapértelmezett üres diát.
            employeePresentation.getSlides().removeAt(0);

            // Klónozd a sablon diát az új prezentációba.
            ISlide slide = employeePresentation.getSlides().addClone(templatePresentation.getSlides().get_Item(0));

            // Szerezz be bekezdéseket a cél alakzatból (feltételezve, hogy az 1. indexű alakzatot használják).
            IParagraphCollection paragraphs = ((IAutoShape)slide.getShapes().get_Item(1)).getTextFrame().getParagraphs();

            // Cseréld le a helyőrzőket az Excel adatával.
            String employeeName = workbook.getCell(worksheetIndex, rowIndex, 0).getValue().toString();
            IPortion namePortion = paragraphs.get_Item(0).getPortions().get_Item(0);
            namePortion.setText(namePortion.getText().replace("{{EmployeeName}}", employeeName));

            String department = workbook.getCell(worksheetIndex, rowIndex, 1).getValue().toString();
            IPortion departmentPortion = paragraphs.get_Item(1).getPortions().get_Item(0);
            departmentPortion.setText(departmentPortion.getText().replace("{{Department}}", department));

            String yearsOfService = workbook.getCell(worksheetIndex, rowIndex, 2).getValue().toString();
            IPortion yearsPortion = paragraphs.get_Item(2).getPortions().get_Item(0);
            yearsPortion.setText(yearsPortion.getText().replace("{{YearsOfService}}", yearsOfService));

            // Mentsd el a személyre szabott prezentációt egy külön fájlba.
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

### **Excel táblázat példa**

A második példában egyszerűen átmásoljuk az adatokat egy Excel‑táblázatból, és egy vonzóbb formában jelenítjük meg őket egy PowerPoint‑dián.

Ebben a példában újra felhasználjuk az első példában már szereplő Excel‑munkafüzetet, amely egy egyszerű alkalmazotti táblázatot tartalmaz.

```java
// Töltsd be a munkavállalói adatokat tartalmazó Excel munkafüzetet.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Hozz létre egy új PowerPoint prezentációt.
Presentation presentation = new Presentation();

try {
    // Adj egy táblázat alakzatot az első diához.
    ITable table = presentation.getSlides().get_Item(0).getShapes().addTable(
            50, 200,
            new double[]{200, 200, 200},
            new double[]{30, 30, 30, 30, 30}
    );

    // Töltsd fel a PowerPoint táblázatot az Excel munkafüzet adataival.
    for (int rowIndex = 0; rowIndex < 5; rowIndex++) {
        for (int columnIndex = 0; columnIndex < 3; columnIndex++) {
            String cellValue = workbook.getCell(worksheetIndex, rowIndex, columnIndex).getValue().toString();
            table.getColumns().get_Item(columnIndex).get_Item(rowIndex).getTextFrame().setText(cellValue);
        }
    }

    // Mentsd el a kapott prezentációt egy fájlba.
    presentation.save("Table.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Eredmény](example2_image0.png)

### **Excel diagram importálása példa**

Ebben a példában egy diagramot importálunk az előző példában használt Excel‑munkafüzet első munkalapjáról. A diagram a végső prezentációban külső munkafüzetre hivatkozik majd.

Először egy kördiagramot adunk hozzá az Excel‑munkafüzethez az alkalmazotti táblázat alapján.

![Excel diagram példa](example3_image0.png)

```java
// Hozz létre egy új PowerPoint prezentációt.
Presentation presentation = new Presentation();
try {
    // Szerezd meg az első dia alakzatgyűjteményét.
    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();

    // Importáld a "Chart 1" nevű diagramot a munkafüzet első lapjáról, és add hozzá az alakzatgyűjteményhez.
    ExcelWorkbookImporter.addChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Mentsd el a kapott prezentációt egy fájlba.
    presentation.save("Chart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Eredmény](example3_image1.png)

### **Minden Excel diagram importálása példa**

Képzeljünk el egy olyan Excel‑munkafüzetet, amely diagramokkal van tele, és ezek mindegyikét egy prezentációba szeretnénk importálni. Minden diagramot új diára kell helyezni.

Az alábbi kód végigiterál a forrás‑Excel‑fájl összes munkalapján, kinyeri a diagramokat, majd mindegyik diagramot egy külön diára helyezi egy üres diaképre építve. A végső prezentációban csak a diagram adatai lesznek beágyazva, nem maga a teljes munkafüzet.

```java
// Töltsd be a munkavállalói adatokat tartalmazó Excel munkafüzetet.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Hozz létre egy új PowerPoint prezentációt.
Presentation presentation = new Presentation();
try {
    // Szerezd meg az üres dia elrendezést.
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // Szerezd meg az Excel munkafüzetben szereplő összes munkalap nevét.
    List<String> worksheetNames = workbook.getWorksheetNames();

    for (String name : worksheetNames) {
        // Szerezd meg a térképet, amely a diagram indexeket a munkalap diagramneveire rendeli.
        Dictionary<Integer, String> worksheetCharts = workbook.getChartsFromWorksheet(name);

        for (KeyValuePair<Integer, String> chart : worksheetCharts) {
            // Adj hozzá egy új diát az üres elrendezés használatával.
            ISlide slide = presentation.getSlides().addEmptySlide(blankLayout);

            // Importáld a megadott diagramot az Excel munkafüzetből a dia alakzatgyűjteményébe.
            ExcelWorkbookImporter.addChartFromWorkbook(
                    slide.getShapes(), 10, 10, workbook, name, chart.getKey(), false);
        }
    }

    // Mentsd el a kapott prezentációt egy fájlba.
    presentation.save("Charts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Összefoglalás**

Ez a mechanizmus, amely közvetlenül az Aspose.Slides‑ben érhető el, egy helyen egyesíti az Excel‑adatokkal és a prezentációkkal való munkát. Lehetővé teszi, hogy diákon vizuális diagramokkal és Excel‑táblázatokként megjelenített adatcsomagokkal dolgozzunk – további könyvtárak vagy bonyolult integrációk nélkül.