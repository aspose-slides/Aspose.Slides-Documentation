---
title: "Excel adatok integrálása PowerPoint prezentációkba"
linktitle: "Excel integráció"
type: docs
weight: 330
url: /hu/net/excel-integration/
keywords:
- Excel
- munkafüzet
- Excel olvasása
- Excel integrálása
- adatforrás
- körlevél
- tábla importálása
- Excel PowerPointba
- PowerPoint
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Olvassa be az adatokat Excel munkafüzetekből az Aspose.Slides-ben az ExcelDataWorkbook API használatával. Töltsön be munkalapokat és cellákat, és használja az értékeket adatvezérelt PowerPoint prezentációk létrehozásához."
---
## **Bevezetés**

A PowerPoint‑prezentációk hatékony módot nyújtanak az információk megjelenítésére és kommunikálására. Gyakran használják őket Excel‑munkafüzetekkel együtt, ahol az Excel kiváló forrása a strukturált adatoknak, a PowerPoint pedig nagyszerűen visualizálja ezeket a közönség számára.

Számos gyakorlati esetben elengedhetetlen az Excel és a PowerPoint összekapcsolása: levelezésküldés, adat táblák feltöltése, egy diát generálni adatrekordonként (csoportos dia‑generálás), képzési anyagok létrehozása, és több Excel‑riport egyetlen prezentációba való összevonása, csak néhány példát említve.

Eddig az ilyen funkciók megvalósítása az Aspose.Slides API‑val harmadik‑fél megoldásokra, például az Aspose.Cells‑re volt támaszkodva. Bár ezek az eszközök robusztusak, túl bonyolultak és költségesek lehetnek azok számára, akiknek csak alapvető adat‑integrációs funkcióra van szükségük.

## **Hogyan működik**

Az Excel‑adatokkal való munka megkönnyítése és áramvonalasabbá tétele érdekében az Aspose.Slides új osztályokat vezetett be az Excel‑munkafüzetek olvasásához és a tartalom prezentációba való importálásához. Ez a funkció erőteljes új lehetőségeket nyit meg az API‑felhasználók számára, akik az Excelt adatforrásként kívánják használni a prezentációs munkafolyamatokban.

Az új funkcionalitás általános célú adat‑hozzáférésre lett tervezve, és nincs beépítve a Presentation Document Object Model‑ba (DOM). Ez azt jelenti, hogy *nem teszi lehetővé az Excel‑fájlok szerkesztését vagy mentését* – kizárólag munkafüzetek megnyitására és tartalmukban való navigálásra, valamint cellaadatok lekérésére szolgál.

Ennek a funkciónak a középpontjában az új [ExcelDataWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.excel/exceldataworkbook/) osztály áll. Ez az osztály lehetővé teszi egy Excel‑munkafüzet betöltését helyi fájlból vagy adatfolyamból. Betöltés után több overload‑ot kínál a [GetCell](https://reference.aspose.com/slides/hu/net/aspose.slides.excel/exceldataworkbook/getcell/) metódushoz, amelyet a cellák pozíció (például sor‑ és oszlop‑index vagy név‑tartomány) alapján történő lekérésére használhat.

Minden [GetCell](https://reference.aspose.com/slides/hu/net/aspose.slides.excel/exceldataworkbook/getcell/) hívás egy [ExcelDataCell](https://reference.aspose.com/slides/hu/net/aspose.slides.excel/exceldatacell/) példányt ad vissza. Ez az objektum egyetlen cellát képvisel az Excel‑munkafüzetben, és egyszerű, intuitív módon biztosítja a cella értékének elérését.

#### **Excel‑diagram importálása**

A következő lépés a funkcionalitás kiterjesztéséhez a [ExcelWorkbookImporter](https://reference.aspose.com/slides/hu/net/aspose.slides.import/excelworkbookimporter/) osztály. Ez a segédosztály az Excel‑munkafüzet tartalmának prezentációba való importálásához nyújt funkciókat. Több overload‑ot tartalmaz a [AddChartFromWorkbook](https://reference.aspose.com/slides/hu/net/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) metódushoz, amelyek segítenek a megadott Excel‑munkafüzetből a kiválasztott diagram lekérésében és a megadott koordinátákon a megadott alakzat‑gyűjtemény végére történő hozzáadásában.

Röviden, ez egy könnyű és egyszerű API az Excel‑adatok olvasásához – pontosan azt, amire sok fejlesztőnek szüksége van anélkül, hogy egy teljes táblázatkezelő könyvtár terhelésével kellene számolni.

## **Kódoljunk**

### **Mail Merge forgatókönyv példája**

Az alábbi példában egy egyszerű Mail Merge forgatókönyvet valósítunk meg, több prezentáció generálásával egy Excel‑munkafüzetben tárolt adatok alapján.

Az induláshoz két dologra van szükség:
1. Egy Excel‑munkafüzet az adatokkal

![Excel adatok példája](example1_image0.png)

2. PowerPoint‑prezentáció sablon

![PowerPoint sablon példája](example1_image1.png)

```csharp
// Töltsd be az alkalmazott adatokat tartalmazó Excel munkafüzetet.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Töltsd be a prezentáció sablont.
using Presentation templatePresentation = new Presentation("PresentationTemplate.pptx");

// Iteráld végig az Excel sorokat (az 0. sor fejléc kizárásával).
for (int rowIndex = 1; rowIndex <= 4; rowIndex++)
{
    // Hozz létre egy új prezentációt minden egyes alkalmazotti rekordhoz.
    using Presentation employeePresentation = new Presentation();

    // Távolítsd el az alapértelmezett üres diát.
    employeePresentation.Slides.RemoveAt(0);

    // Klónozd a sablon diát az új prezentációba.
    ISlide slide = employeePresentation.Slides.AddClone(templatePresentation.Slides[0]);

    // Szerezd meg a bekezdéseket a cél alakzatról (feltételezve, hogy az 1-es indexű alakzat van használatban).
    IParagraphCollection paragraphs = (slide.Shapes[1] as IAutoShape).TextFrame.Paragraphs;

    // Cseréld le a helyőrzőket az Excel adatainak megfelelően.
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

### **Excel‑tábla példája**

A második példában egyszerűen egy Excel‑táblából másolunk adatot, és egy PowerPoint‑dián jelenítjük meg vizuálisan vonzóbb formátumban.

Ebben a példában az első példában használt ugyanazt az Excel‑munkafüzetet használjuk, amely egy egyszerű alkalmazott‑táblát tartalmaz.

```csharp
// Töltsd be az alkalmazott adatokat tartalmazó Excel munkafüzetet.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("TemplateData.xlsx");
int worksheetIndex = 0;

// Hozz létre egy új PowerPoint prezentációt.
using Presentation presentation = new Presentation();

// Adj hozzá egy táblázat alakzatot az első diához.
ITable table = presentation.Slides[0].Shapes.AddTable(
    50, 200,
    new double[] { 200, 200, 200 },
    new double[] { 30, 30, 30, 30, 30 }
);

// Töltsd fel a PowerPoint táblázatot az Excel munkafüzet adatával.
for (int rowIndex = 0; rowIndex < 5; rowIndex++)
{
    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
    {
        string cellValue = workbook.GetCell(worksheetIndex, rowIndex, columnIndex).Value.ToString();
        table[columnIndex, rowIndex].TextFrame.Text = cellValue;
    }
}

// Mentsd el a keletkezett prezentációt egy fájlba.
presentation.Save("Table.pptx", SaveFormat.Pptx);
```

![Eredmény](example2_image0.png)

### **Excel‑diagram importálása példa**

Ebben a példában egy diagramot importálunk az előző példában használt Excel‑munkafüzet első munkalapjáról. A diagram a kész prezentációban a külső munkafüzetre fog hivatkozni.

Először egy kördiagramot adunk hozzá az Excel‑munkafüzethez az alkalmazottak táblája alapján.

![Excel diagram példa](example3_image0.png)

```csharp
// Hozz létre egy új PowerPoint prezentációt.
using Presentation presentation = new Presentation();

// Szerezd meg az első dia alakzatgyűjteményét.
IShapeCollection shapes = presentation.Slides[0].Shapes;

// Importáld a "Chart 1" nevű diagramot a munkafüzet első lapjáról, és add hozzá az alakzatgyűjteményhez.
ExcelWorkbookImporter.AddChartFromWorkbook(shapes, 10, 10, "TemplateData.xlsx", "Sheet1", "Chart 1", false);

// Mentsd el a keletkezett prezentációt egy fájlba.
presentation.Save("Chart.pptx", SaveFormat.Pptx);
```
![Eredmény](example3_image1.png)

### **Minden Excel‑diagram importálása példa**

Képzeljük el, hogy van egy Excel‑munkafüzet tele diagramokkal, és mindet be kell importálni egy prezentációba. Minden diagramot egy új diára kell helyezni.

Az alábbi kód végigiterál a forrás‑Excel‑fájl összes munkalapján, kibontja a diagramokat minden munkalapról, és minden diagramot egy külön diára helyez egy üres dia‑elrendezéssel. A kész prezentációban csak a diagramadatok lesznek beágyazva, nem a teljes munkafüzet.

```csharp
// Töltsd be az alkalmazott adatokat tartalmazó Excel munkafüzetet.
ExcelDataWorkbook workbook = new ExcelDataWorkbook("ExcelWithCharts.xlsx");

// Hozz létre egy új PowerPoint prezentációt.
using Presentation presentation = new Presentation();

// Szerezd meg az üres diaelrendezést.
ILayoutSlide blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

// Szerezd meg az Excel munkafüzetben található összes munkalap nevét.
IList<string> worksheetNames = workbook.GetWorksheetNames();

foreach (var name in worksheetNames)
{
    // Szerezd meg a szótárat, amely a diagram indexeket a munkalap diagramneveire térképezi.
    IDictionary<int, string> worksheetCharts = workbook.GetChartsFromWorksheet(name);
    foreach (var chart in worksheetCharts)
    {
        // Adj hozzá egy új diát az üres elrendezés használatával.
        ISlide slide = presentation.Slides.AddEmptySlide(blankLayout);

        // Importáld a megadott diagramot az Excel munkafüzetből a dia alakzatgyűjteményébe.
        ExcelWorkbookImporter.AddChartFromWorkbook(slide.Shapes, 10, 10, workbook, name, chart.Key, false);
    }
}

// Mentsd el a keletkezett prezentációt egy fájlba.
presentation.Save("Charts.pptx", SaveFormat.Pptx);
```

## **Összegzés**

Ez a mechanizmus, amely közvetlenül az Aspose.Slides‑ban érhető el, egy helyen ötvözi az Excel‑adatok és a prezentációk kezelését. Lehetővé teszi, hogy diákon vizuális diagramokkal és Excel‑táblákkal jelenítsük meg az adatokat – további könyvtárak vagy összetett integrációk nélkül.