---
title: Excel adatok integrálása PowerPoint prezentációkba
linktitle: Excel integráció
type: docs
weight: 330
url: /hu/net/excel-integration/
keywords:
- Excel
- munkafüzet
- Excel olvasása
- Excel integrálása
- adatforrás
- levelezési összevonás
- táblázat importálása
- Excel PowerPointba
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Olvassa be az adatokat Excel munkafüzetekből az Aspose.Slides-ben az ExcelDataWorkbook API segítségével. Töltsön be munkalapokat és cellákat, és használja az értékeket adatvezérelt PowerPoint prezentációk generálásához."
---
## **Bevezetés**

A PowerPoint‑prezentációk hatékony módot nyújtanak az információ megjelenítésére és kommunikálására. Gyakran használják őket Excel‑munkafüzetekkel együtt, ahol az Excel kiváló forrása a strukturált adatoknak, a PowerPoint pedig kiemelkedő a közönség számára történő adatvizualizálásban.

Számos gyakorlati esetben elengedhetetlen az Excel és a PowerPoint kombinálása: levelezési összevonás, adat‑táblák feltöltése, egy diát generálás minden adatbejegyzéshez (csoportos dia generálás), képzési anyagok készítése, valamint több Excel‑jelentés egyetlen prezentációba való egyesítése, és még sok más.

Eddig az ilyen funkciók megvalósítása az Aspose.Slides API‑val harmadik‑féltől származó megoldások, például az Aspose.Cells használatát igényelte. Bár ezek az eszközök megbízhatóak, túl bonyolultak és költségesek lehetnek azok számára, akik csak alapvető adat‑integrációs funkciókat igényelnek.

## **Hogyan működik**

Az Excel‑adatokkal való munka egyszerűbbé és hatékonyabbá tétele érdekében az Aspose.Slides új osztályokat vezetett be az Excel‑munkafüzetek adatainak olvasásához és a tartalom prezentációba történő importálásához. Ez a funkció erőteljes új lehetőségeket nyit meg az API‑felhasználók számára, akik az Excelt adatforrásként szeretnék felhasználni a prezentációs munkafolyamatokban.

Az új funkció általános célú adat-hozzáférésre lett tervezve, és nem integrálódik a Presentation Document Object Model (DOM)-ba. Ez azt jelenti, hogy *nem teszi lehetővé az Excel‑fájlok szerkesztését vagy mentését* – egyetlen célja, hogy megnyissa a munkafüzeteket, navigáljon azok tartalmán, és lekérje a cellaadatokat.

A funkció központjában az új [ExcelDataWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.excel/exceldataworkbook/) osztály áll. Ez az osztály lehetővé teszi egy Excel‑munkafüzet betöltését helyi fájlból vagy adatfolyamból. Betöltés után több overloadot kínál a [GetCell](https://reference.aspose.com/slides/hu/net/aspose.slides.excel/exceldataworkbook/getcell/) metódusra, amelyet a cellák pozíciója (pl. sor‑ és oszlop‑index vagy névvel ellátott tartomány) alapján történő lekérdezésére használhat.

Minden [GetCell](https://reference.aspose.com/slides/hu/net/aspose.slides.excel/exceldataworkbook/getcell/) hívás egy [ExcelDataCell](https://reference.aspose.com/slides/hu/net/aspose.slides.excel/exceldatacell/) osztálypéldányt ad vissza. Ez az objektum egyetlen cellát képvisel az Excel‑munkafüzetben, és egyszerű, intuitív módon biztosít hozzáférést annak értékéhez.

#### **Excel diagram importálása**

A funkció bővítésének következő lépése a [ExcelWorkbookImporter](https://reference.aspose.com/slides/hu/net/aspose.slides.import/excelworkbookimporter/) osztály. Ez a segédosztály lehetővé teszi tartalom importálását egy Excel‑munkafüzettől egy prezentációba. Több overloadot tartalmaz a [AddChartFromWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) metódusra, amely segít a megadott Excel‑munkafüzetből a kiválasztott diagram lekérdezésében és a megadott koordinátákon a megadott alakzatgyűjtemény végéhez való hozzáadásában.

#### **Excel táblázat importálása**

Az [ExcelWorkbookImporter](https://reference.aspose.com/slides/hu/net/aspose.slides.import/excelworkbookimporter/) osztály továbbá több overloadot kínál a [AddTableFromWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.import/excelworkbookimporter/addtablefromworkbook/) metódusra. Ezek a metódusok lehetővé teszik egy megadott cellatartomány importálását egy meghatározott munkalapról, és táblázatként a megadott koordinátákon a megadott alakzatgyűjtemény végéhez való hozzáadását.

Röviden, ez egy könnyű és egyszerű API az Excel‑adatok olvasásához – pontosan azt, amire sok fejlesztőnek szüksége van egy teljes táblázatkezelő könyvtár terhe nélkül.

## **Kódoljunk**

### **Levelezési összevonás példája**

A következő példában egy egyszerű levelezési összevonási forgatókönyvet valósítunk meg, több prezentáció generálásával az Excel‑munkafüzetben tárolt adatok alapján.

A kezdéshez két dologra van szükségünk:
1. Az adatokat tartalmazó Excel‑munkafüzet

![Excel adat példa](example1_image0.png)

2. PowerPoint prezentációs sablon

![PowerPoint sablon példa](example1_image1.png)

```csharp
// Az alkalmazotti adatokkal rendelkező Excel munkafüzet betöltése.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// A prezentációs sablon betöltése.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Az Excel sorokon iterálás (0. sor fejlécre kizárva).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // Új prezentáció létrehozása minden alkalmazotti rekordhoz.
    using Presentation employeePresentation = new Presentation();

    // Az alapértelmezett üres dia eltávolítása.
    employeePresentation.Slides.RemoveAt(0);

    // A sablon dia klónozása az új prezentációba.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // Bekérjük a bekezdéseket a cél alakzatból (feltételezve, hogy az 1. indexű alakzatot használják).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // A helyőrzők cseréje az Excel adataival.
    string employeeName = workbook.GetCell(worksheetIndex, rowIndex, 0).Value.ToString();
    IPortion namePortion = paragraphs[0].Portions[0];
    namePortion.Text = namePortion.Text.Replace("{{EmployeeName}}", employeeName);

    string department = workbook.GetCell(worksheetIndex, rowIndex, 1).Value.ToString();
    IPortion departmentPortion = paragraphs[1].Portions[0];
    departmentPortion.Text = departmentPortion.Text.Replace("{{Department}}", department);

    string yearsOfService = workbook.GetCell(worksheetIndex, rowIndex, 2).Value.ToString();
    IPortion yearsPortion = paragraphs[2].Portions[0];
    yearsPortion.Text = yearsPortion.Text.Replace("{{YearsOfService}}", yearsOfService);

    // A személyre szabott prezentáció mentése külön fájlba.
    employeePresentation.Save($"{employeeName} Report.pptx", SaveFormat.Pptx);
}
```

![Eredmény](example1_image2.png)

### **Excel táblázat példája**

A második példában egyszerűen másoljuk az adatokat egy Excel‑táblázatból, és egy PowerPoint‑dián jelenítjük meg vizuálisan vonzóbb formában.

Ebben a példában ugyanazt az Excel‑munkafüzetet használjuk újra, amely az első példában szerepelt, és egy egyszerű alkalmazotti táblázatot tartalmaz.

```csharp
// Az alkalmazotti adatokat tartalmazó Excel munkafüzet betöltése.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Új PowerPoint prezentáció létrehozása.
using Presentation presentation = new Presentation();

// Táblázat alakzat hozzáadása az első diára.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// A PowerPoint táblázat feltöltése az Excel munkafüzettel.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// A létrehozott prezentáció mentése fájlba.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![Eredmény](example2_image0.png)

### **Excel diagram importálásának példája**

Ebben a példában importálunk egy diagramot az előző példában használt Excel‑munkafüzet első munkalapjáról. A diagram a végső prezentációban egy külső munkafüzethez lesz kapcsolva.

Először egy kördiagramot adunk hozzá az Excel‑munkafüzethez az alkalmazotti táblázat alapján.

![Excel diagram példa](example3_image0.png)

```csharp
// Új PowerPoint prezentáció létrehozása.
using Presentation presentation = new Presentation();

// Az első dia alakzatgyűjteményének lekérése.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Importálja a "Chart 1" nevű diagramot a munkafüzet első lapjáról, és hozzáadja az alakzatgyűjteményhez.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// A létrehozott prezentáció mentése fájlba.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![Eredmény](example3_image1.png)

### **Minden Excel diagram importálásának példája**

Képzeljünk el egy olyan Excel‑munkafüzetet, amely tele van diagramokkal, és mindet importálni kell egy prezentációba. Minden diagramot egy új diára kell helyezni.

Az alábbi kód végigiterál a forrás‑Excel‑fájl összes munkalapján, kinyeri a diagramokat minden munkalapról, és egy üres diaterv használatával külön diára helyezi őket. A végeredményben csak a diagram adatai lesznek beágyazva, nem az egész munkafüzet.

```csharp
// Az alkalmazotti adatokat tartalmazó Excel munkafüzet betöltése.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Új PowerPoint prezentáció létrehozása.
using Presentation presentation = new Presentation();

// Az üres dia elrendezés lekérése.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Az Excel munkafüzetben található összes munkalap nevét lekéri.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // Lekér egy szótárat, amely a diagramindexeket a diagramnevekre térképezi a munkalaphoz.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // Új dia hozzáadása az üres elrendezés használatával.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // A megadott diagram importálása az Excel munkafüzetről a dia alakzatgyűjteményébe.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// A létrehozott prezentáció mentése fájlba.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

### **Excel táblázat importálásának példája**

Ebben a példában egy formázott táblázatot importálunk egy Excel‑munkalapról közvetlenül egy PowerPoint‑prezentációba.

A forrás Excel‑munkalap egy formázott táblázatot tartalmaz alkalmazotti adatokkal:

![Excel táblázat példa](example4_image0.png)

```csharp
// Új PowerPoint prezentáció létrehozása.
using Presentation presentation = new Presentation();

// Az első dia alakzatgyűjteményének lekérése.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Táblázat importálása a munkafüzet első lapjáról és hozzáadása az alakzatgyűjteményhez.
ExcelWorkbookImporter.AddTableFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "A1:C5");

// A létrehozott prezentáció mentése fájlba.
presentation.Save("FormattedTable.pptx", SaveFormat.Pptx);
```
![Eredmény](example4_image1.png)

## **Összefoglalás**

Ez a mechanizmus, amely közvetlenül az Aspose.Slides‑ban érhető el, egy helyen egyesíti az Excel‑adatok és a prezentációk kezelését. Lehetővé teszi vizuális diagramokkal és Excel‑táblázatokként megjelenített adatokkal ellátott diák létrehozását – további könyvtárak vagy összetett integrációk nélkül.