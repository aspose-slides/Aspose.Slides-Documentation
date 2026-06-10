---
title: Excel adatok integrálása PowerPoint prezentációkba
linktitle: Excel integráció
type: docs
weight: 330
url: /hu/php-java/excel-integration/
keywords:
- Excel
- munkafüzet
- Excel beolvasása
- Excel integrálása
- adatforrás
- levélösszevonás
- tábla importálása
- Excel PowerPointba
- PowerPoint
- prezentáció
- PHP
- Aspose.Slides
description: "Olvassa be az adatokat Excel munkafüzetekből az Aspose.Slides for PHP via Java segítségével. Töltse be a munkalapokat és cellákat, majd használja az értékeket adatvezérelt PowerPoint prezentációk létrehozásához."
---
## **Bevezetés**

A PowerPoint előadás egy hatékony módja az információk megjelenítésének és közvetítésének. Gyakran használják őket Excel-munkafüzetekkel együtt, ahol az Excel kiváló forrást biztosít a struktúrált adatokhoz, a PowerPoint pedig kiválóan megjeleníti ezeket az adatokat a közönség számára.

Számos gyakorlati szituáció létezik, ahol az Excel és a PowerPoint kombinálása elengedhetetlen: levél-összevonások, adattáblák feltöltése, egy diát generálni adatrekordonként (csoportos diakészítés), képzési anyagok létrehozása, valamint több Excel-jelentés egyetlen előadásba történő konszolidálása, csak néhány példát említve.

Eddig az Aspose.Slides API-val ezen funkciók megvalósítása harmadik fél megoldásaira, például az Aspose.Cells-re támaszkodott. Bár ezek az eszközök robusztusak, túl komplexek és költségesek lehetnek azok számára, akik csak alap adatintegrációs funkciókra van szükségük.

## **Hogyan működik**

Az Excel-adatokkal való munka egyszerűbbé és gördülékenyebbé tételéhez az Aspose.Slides új osztályokat vezetett be az Excel-munkafüzetek adatainak beolvasására és a tartalom prezentációba importálására. Ez a funkció erőteljes új lehetőségeket nyit meg az API felhasználók számára, akik az Excelt adatforrásként szeretnék használni a prezentációs munkafolyamatokban.

Az új funkcionalitás általános adat-hozzáférésre van tervezve, és nincs integrálva a Presentation Document Object Model (DOM) struktúrába. Ez azt jelenti, hogy *nem teszi lehetővé az Excel-fájlok szerkesztését vagy mentését* — egyetlen célja a munkafüzetek megnyitása és a tartalmukon való navigálás a cellaadatok lekérdezéséhez.

A funkció középpontjában az új [ExcelDataWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/exceldataworkbook/) osztály áll. Ez az osztály lehetővé teszi, hogy egy Excel-munkafüzetet helyi fájlból vagy adatfolyamból töltsön be. Miután betöltöttük, több overloadot biztosít a [getCell](https://reference.aspose.com/slides/hu/php-java/aspose.slides/exceldataworkbook/#getCell) metódushoz, amelyet a cellák pozíciója (pl. sor- és oszlopindexek vagy névvel ellátott tartományok) alapján való lekérdezésére használhat.

Minden [getCell](https://reference.aspose.com/slides/hu/php-java/aspose.slides/exceldataworkbook/#getCell) hívás egy [ExcelDataCell](https://reference.aspose.com/slides/hu/php-java/aspose.slides/exceldatacell/) osztálypéldányt ad vissza. Ez az objektum egyetlen cellát képvisel az Excel-munkafüzetben, és egyszerű, intuitív módon biztosítja az értékéhez való hozzáférést.

#### **Excel diagram importálása**

A funkcionalitás bővítésének következő lépése a [ExcelWorkbookImporter](https://reference.aspose.com/slides/hu/php-java/aspose.slides/excelworkbookimporter/) osztály. Ez a segédosztály funkciót kínál az Excel-munkafüzet tartalmának prezentációba történő importálásához. Tartalmazza a [addChartFromWorkbook](https://reference.aspose.com/slides/hu/php-java/aspose.slides/excelworkbookimporter/#addChartFromWorkbook) metódus több overloadját, amelyek segítenek a kiválasztott diagram lekérdezésében a megadott Excel-munkafüzetből, és a megadott koordinátákon a megadott alakzatgyűjtemény végéhez hozzáadni.

Röviden, ez egy könnyű és egyszerű API az Excel-adatok olvasásához — pontosan azt, amire sok fejlesztőnek szüksége van anélkül, hogy egy teljes táblázat-feldolgozó könyvtár súlya ránk nehezedne.

## **Kódoljunk**

### **Levelezés összevonás szcenárió példa**

A következő példában egy egyszerű levelezés-összevonás szcenáriót valósítunk meg, több prezentációt generálva egy Excel-munkafüzetben tárolt adatok alapján.

A kezdéshez kettőre van szükségünk:
1. Az adatokat tartalmazó Excel-munkafüzet

![Excel adat példa](example1_image0.png)

2. PowerPoint prezentáció sablon

![PowerPoint sablon példa](example1_image1.png)

```php
// Töltsd be az Excel munkafüzetet alkalmazotti adatokkal.
$workbook = new ExcelDataWorkbook("TemplateData.xlsx");
$worksheetIndex = 0;

// Töltsd be a prezentáció sablont.
$templatePresentation = new Presentation("PresentationTemplate.pptx");

try {
    // Iterálj az Excel sorokon (az 0. sor fejlécének kihagyásával).
    for ($rowIndex = 1; $rowIndex <= 4; $rowIndex++) {

        // Hozz létre egy új prezentációt minden alkalmazotti rekordhoz.
        $employeePresentation = new Presentation();

        try {
            // Távolítsd el az alapértelmezett üres diát.
            $employeePresentation->getSlides()->removeAt(0);

            // Klónozd a sablon diát az új prezentációba.
            $slide = $employeePresentation->getSlides()->addClone($templatePresentation->getSlides()->get_Item(0));

            // Szerezz be bekezdéseket a cél alakzatról (feltételezve, hogy az 1-es indexű alakzatot használják).
            $paragraphs = $slide->getShapes()->get_Item(1)->getTextFrame()->getParagraphs();

            // Cseréld le a helyőrzőket az Excel adataival.
            $employeeName = $workbook->getCell($worksheetIndex, $rowIndex, 0)->getValue()->toString();
            $namePortion = $paragraphs->get_Item(0)->getPortions()->get_Item(0);
            $namePortion->setText($namePortion->getText()->replace("{{EmployeeName}}", $employeeName));

            $department = $workbook->getCell($worksheetIndex, $rowIndex, 1)->getValue()->toString();
            $departmentPortion = $paragraphs->get_Item(1)->getPortions()->get_Item(0);
            $departmentPortion->setText($departmentPortion->getText()->replace("{{Department}}", $department));

            $yearsOfService = $workbook->getCell($worksheetIndex, $rowIndex, 2)->getValue()->toString();
            $yearsPortion = $paragraphs->get_Item(2)->getPortions()->get_Item(0);
            $yearsPortion->setText($yearsPortion->getText()->replace("{{YearsOfService}}", $yearsOfService));

            // Mentsd el a személyre szabott prezentációt egy külön fájlba.
            $employeePresentation->save(sprintf("%s Report.pptx", $employeeName), SaveFormat::Pptx);
        } finally {
            $employeePresentation->dispose();
        }
    }
} finally {
    $templatePresentation->dispose();
}
```

![Eredmény](example1_image2.png)

### **Excel tábla példa**

A második példában egyszerűen átmásoljuk az adatokat egy Excel-táblából, és egy vizuálisan vonzóbb formátumban jelenítjük meg a PowerPoint dián.

Ebben a példában újra felhasználjuk az első példában szereplő ugyanazt az Excel-munkafüzetet, amely egy egyszerű alkalmazotti táblát tartalmaz.

```php
// Töltsd be az alkalmazotti adatokat tartalmazó Excel munkafüzetet.
$workbook = new ExcelDataWorkbook("TemplateData.xlsx");
$worksheetIndex = 0;

// Hozz létre egy új PowerPoint prezentációt.
$presentation = new Presentation();

try {
    // Adj hozzá egy táblázat alakzatot az első diára.
    $table = $presentation->getSlides()->get_Item(0)->getShapes()->addTable(
            50, 200,
            array(200, 200, 200),
            array(30, 30, 30, 30, 30)
    );

    // Töltsd fel a PowerPoint táblázatot az Excel munkafüzet adataival.
    for ($rowIndex = 0; $rowIndex < 5; $rowIndex++) {
        for ($columnIndex = 0; $columnIndex < 3; $columnIndex++) {
            $cellValue = $workbook->getCell($worksheetIndex, $rowIndex, $columnIndex)->getValue()->toString();
            $table->getColumns()->get_Item($columnIndex)->get_Item($rowIndex)->getTextFrame()->setText($cellValue);
        }
    }

    // Mentsd el a létrehozott prezentációt egy fájlba.
    $presentation->save("Table.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Eredmény](example2_image0.png)

### **Excel diagram importálása példa**

Ebben a példában egy diagramot importálunk az előző példában használt Excel-munkafüzet első munkalapjáról. A diagram a kész prezentációban a külső munkafüzethez fog linkelni.

Először egy kördiagramot adunk hozzá az Excel-munkafüzethez az alkalmazottak táblája alapján.

![Excel diagram példa](example3_image0.png)

```php
// Hozz létre egy új PowerPoint prezentációt.
$presentation = new Presentation();
try {
    // Szerezd meg az első dia alakzatgyűjteményét.
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    // Importáld a "Chart 1" nevű diagramot a munkafüzet első lapjáról, és add hozzá az alakzatgyűjteményhez.
    ExcelWorkbookImporter::addChartFromWorkbook($shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

    // Mentsd el a létrehozott prezentációt egy fájlba.
    $presentation->save("Chart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Eredmény](example3_image1.png)

### **Minden Excel diagram importálása példa**

Tegyük fel, hogy egy diagramokkal teli Excel-munkafüzettel rendelkezik, és mindet importálni kell egy prezentációba. Minden diagramot egy új diára kell helyezni.

Az alábbi kód végig iterál a forrás Excel-fájl összes munkalapján, kinyeri a diagramokat minden munkalapról, és egy üres diaelrendezés segítségével minden diagramot egy külön diára helyez. A kész prezentációban csak a diagram adatai lesznek beágyazva, nem az egész munkafüzet.

```php
// Töltsd be az alkalmazotti adatokat tartalmazó Excel munkafüzetet.
$workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Hozz létre egy új PowerPoint prezentációt.
$presentation = new Presentation();
try {
    // Szerezd meg az üres diaelrendezést.
    $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

    // Szerezd meg az Excel munkafüzetben szereplő összes munkalap nevét.
    $worksheetNames = $workbook->getWorksheetNames()->iterator();

    while (java_values($worksheetNames->hasNext())) {
        $name = $worksheetNames->next();
        // Szerezd meg a térképet, amely a diagram indexeket a munkalap diagram neveire rendeli.
        $worksheetCharts = $workbook->getChartsFromWorksheet($name)->iterator();

        while (java_values($worksheetCharts->hasNext())) {
            $chart = $worksheetCharts->next();
            // Adj hozzá egy új diát az üres elrendezés használatával.
            $slide = $presentation->getSlides()->addEmptySlide($blankLayout);

            // Importáld a megadott diagramot az Excel munkafüzettől a dia alakzatgyűjteményébe.
            ExcelWorkbookImporter::addChartFromWorkbook(
                    $slide->getShapes(), 10, 10, $workbook, $name, $chart->getKey(), false);
        }
    }

    // Mentsd el a létrehozott prezentációt egy fájlba.
    $presentation->save("Charts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Összegzés**

Ez a mechanizmus, amely közvetlenül az Aspose.Slides-ben érhető el, egy helyen egyesíti az Excel-adatokkal és a prezentációkkal való munkát. Lehetővé teszi, hogy vizuális diagramokkal és Excel táblákban megjelenített adatokkal készítsen diákat – további könyvtárak vagy összetett integrációk nélkül.