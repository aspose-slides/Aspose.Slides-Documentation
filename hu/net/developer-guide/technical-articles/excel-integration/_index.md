---
title: Excel adatok integrálása PowerPoint prezentációkba
linktitle: Excel integráció
type: docs
weight: 330
url: /hu/net/excel-integration/
aliases:
  - /net/developer-guide/technical-articles/excel-integration/
keywords:
- Excel
- munkafüzet
- Excel olvasása
- Excel integrálása
- adatforrás
- levelezési egyesítés
- táblázat importálása
- Excel PowerPointba
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Olvasd be az adatokat Excel munkafüzetekből az Aspose.Slides-ban az ExcelDataWorkbook API használatával. Tölts be munkalapokat és cellákat, és az értékeket felhasználva generálj adat-vezérelt PowerPoint prezentációkat."
---
## **Bevezetés**

A PowerPoint‑prezentációk hatékony módot nyújtanak az információk megjelenítésére és közvetítésére. Gyakran használják őket Excel‑munkafüzetekkel együtt, ahol az Excel kiváló forrása a strukturált adatoknak, a PowerPoint pedig remekül vizualizálja ezeket a közönség számára.

Számos gyakorlati eset van, ahol az Excel és a PowerPoint kombinálása elengedhetetlen: levélcsatolások, adat‑táblák feltöltése, egy diát generálása egy adat‑rekordhoz (csoportos dia‑generálás), képzési anyagok készítése, illetve több Excel‑jelentés egyetlen prezentációba történő összegzése, csak néhány példát említve.

Eddig az ilyen funkciók megvalósítása az Aspose.Slides API‑val harmadik fél megoldásaira, például az Aspose.Cells‑re támaszkodott. Bár ezek az eszközök robusztusak, túl komplexek és költségesek lehetnek azok számára, akiknek csak egyszerű adat‑integrációra van szükségük.

## **Működés módja**

Az Excel‑adatokkal való munka egyszerűbbé és gördülékenyebbé tétele érdekében az Aspose.Slides új osztályokat vezetett be az Excel‑munkafüzetek olvasására és a tartalom bemutatóba importálására. Ez a funkció új lehetőségeket nyit meg az API‑felhasználók számára, akik az Excel‑t adatforrásként szeretnék használni a prezentációs munkafolyamatokban.

Az új funkcionalitás általános célú adat‑hozzáférésre lett tervezve, és nincs beépítve a Presentation Document Object Model (DOM)-ba. Ez azt jelenti, hogy *nem teszi lehetővé az Excel‑fájlok szerkesztését vagy mentését* – kizárólag a munkafüzetek megnyitására és a tartalmuk böngészésére, valamint cella‑adatok lekérdezésére szolgál.

A funkció középpontjában az új [ExcelDataWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.excel/exceldataworkbook/) osztály áll. Ez az osztály lehetővé teszi egy Excel‑munkafüzet betöltését helyi fájlból vagy folyamatról. Betöltés után több overload‑ot kínál a [GetCell](https://reference.aspose.com/slides/hu/net/aspose.slides.excel/exceldataworkbook/getcell/) metódushoz, amely segítségével a cellákat a pozíciójuk (pl. sor‑ és oszlop‑index vagy név‑tartomány) alapján kérhetjük le.

Minden [GetCell](https://reference.aspose.com/slides/hu/net/aspose.slides.excel/exceldataworkbook/getcell/) hívás egy [ExcelDataCell](https://reference.aspose.com/slides/hu/net/aspose.slides.excel/exceldatacell/) osztálypéldányt ad vissza. Ez az objektum egyetlen cellát reprezentál az Excel‑munkafüzetben, és egyszerű, intuitív módon biztosítja a cella értékéhez való hozzáférést.

#### **Excel‑diagram importálása**

A következő lépés a funkcionalitás kibővítéséhez a [ExcelWorkbookImporter](https://reference.aspose.com/slides/hu/net/aspose.slides.import/excelworkbookimporter/) osztály. Ez az segédosztály lehetővé teszi a tartalom importálását egy Excel‑munkafüzetből egy prezentációba. Több overload‑ot tartalmaz a [AddChartFromWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) metódushoz, amelyek segítségével a megadott Excel‑munkafüzetből kiválasztott diagramot lekérhetjük, és a megadott koordinátákon a megadott alakzatgyűjtemény végére hozzáadhatjuk.

#### **Excel‑táblázat importálása**

Az [ExcelWorkbookImporter](https://reference.aspose.com/slides/hu/net/aspose.slides.import/excelworkbookimporter/) osztály szintén több overload‑ot tartalmaz a [AddTableFromWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/) metódushoz. Ezek a metódusok lehetővé teszik, hogy egy megadott cellatartományt egy megadott munkalapról importáljunk, és táblázatként a megadott koordinátákon a megadott alakzatgyűjtemény végére helyezzük el.

Röviden, ez egy könnyűsúlyú és egyszerű API az Excel‑adatok olvasására – pontosan azt, amire sok fejlesztőnek szüksége van anélkül, hogy teljes táblázat‑feldolgozó könyvtárra lenne szüksége.

## **Kódolás**

### **Levelezési összevonás (Mail Merge) példa**

Az alábbi példában egy egyszerű Mail Merge‑szcenáriót valósítunk meg úgy, hogy több prezentációt generálunk egy Excel‑munkafüzetben tárolt adatok alapján.

Kezdéshez két dologra van szükségünk:
1. Az adatokat tartalmazó Excel‑munkafüzet

![Excel adatok példája](example1_image0.png)

2. PowerPoint‑prezentációs sablon

![PowerPoint sablon példa](example1_image1.png)

```csharp
// Töltsd be az Excel munkafüzetet alkalmazotti adatokkal.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Töltsd be a prezentációs sablont.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Az Excel sorokon iterál (kivéve a 0. sor fejlécként).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // Készíts új prezentációt minden egyes alkalmazotti rekordhoz.
    using Presentation employeePresentation = new Presentation();

    // Távolítsd el az alapértelmezett üres diát.
    employeePresentation.Slides.RemoveAt(0);

    // Klónozd a sablon diát az új prezentációba.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // Szerezz be bekezdéseket a cél alakzatból (felteszi, hogy az 1-es indexű alakzatot használják).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // Cseréld le a helyőrzőket az Excel adatával.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // Mentsd el a személyre szabott prezentációt egy külön fájlba.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![Eredmény](example1_image2.png)

### **Excel‑táblázat példa**

A második példában egyszerűen egy Excel‑táblázat adatait másoljuk, és egy PowerPoint‑dián jelenítjük meg látványosabb formában.

Ebben a példában ugyanezt az Excel‑munkafüzetet használjuk, mint az első példában, amely egy egyszerű alkalmazotti táblázatot tartalmaz.

```csharp
// Töltsd be az alkalmazotti adatokat tartalmazó Excel munkafüzetet.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Hozz létre egy új PowerPoint prezentációt.
using Presentation presentation = new Presentation();

// Adj hozzá egy táblázat alakzatot az első diára.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// Töltsd fel a PowerPoint táblázatot az Excel munkafüzet adataival.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// Mentsd el a kapott prezentációt egy fájlba.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![Eredmény](example2_image0.png)

### **Excel‑diagram importálás példa**

Ebben a példában egy diagramot importálunk az előző példában használt Excel‑munkafüzet első munkalapjáról. A diagram a kimeneti prezentációban külső munkafüzetre hivatkozik majd.

Először egy kördiagramot adunk hozzá az Excel‑munkafüzethez az alkalmazottak táblázata alapján.

![Excel diagram példa](example3_image0.png)

```csharp
// Hozz létre egy új PowerPoint prezentációt.
using Presentation presentation = new Presentation();

// Szerezd meg az első dia alakzatgyűjteményét.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Importáld a "Chart 1" nevű diagramot a munkafüzet első lapjáról, és add hozzá az alakzatgyűjteményhez.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// Mentsd el a kapott prezentációt egy fájlba.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![Eredmény](example3_image1.png)

### **Minden Excel‑diagram importálása példa**

Képzeljük el, hogy egy diagramokkal teli Excel‑munkafüzetünk van, és mindet importálni kell egy prezentációba. Minden diagramnak új dián kell megjelennie.

Az alábbi kód végigiterál a forrás‑Excel‑fájl minden munkalapján, kinyeri a diagramokat, és minden diagramot egy külön diára helyez el egy üres dia‑elrendezés használatával. A kimeneti prezentációban csak a diagramadatok lesznek beágyazva, a teljes munkafüzet nem.

```csharp
// Töltsd be az alkalmazotti adatokat tartalmazó Excel munkafüzetet.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Hozz létre egy új PowerPoint prezentációt.
using Presentation presentation = new Presentation();

// Szerezd meg az üres dia elrendezését.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Szerezd meg az Excel munkafüzetben szereplő összes munkalap nevét.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // Szerezd meg a szótárat, amely a diagram indexeket a munkalap diagram neveire képezi le.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // Adj hozzá egy új diát az üres elrendezés használatával.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Importáld a megadott diagramot az Excel munkafüzetből a dia alakzatgyűjteményébe.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// Mentsd el a kapott prezentációt egy fájlba.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **Excel‑táblázat importálása példa**

Ebben a példában egy formázott táblázatot importálunk egy Excel‑munkalapról közvetlenül egy PowerPoint‑prezentációba.

A forrás‑Excel‑munkalap egy formázott táblázatot tartalmaz alkalmazotti adatokkal:

![Excel táblázat példa](example4_image0.png)

```csharp
// Hozz létre egy új PowerPoint prezentációt.
using Presentation presentation = new Presentation();

// Szerezd meg az első dia alakzatgyűjteményét.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Importáld a táblázatot a munkafüzet első lapjáról, és add hozzá az alakzatgyűjteményhez.
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// Mentsd el a kapott prezentációt egy fájlba.
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```

![Eredmény](example4_image1.png)


## **Összegzés**

Ez a mechanizmus, amely közvetlenül az Aspose.Slides‑ban érhető el, egy helyen ötvözi az Excel‑adatokkal és a prezentációkkal való munkát. Lehetővé teszi, hogy vizuális diagramokkal és Excel‑táblázatokként megjelenített adatokkal készüljön diák – további könyvtárak vagy összetett integrációk nélkül.