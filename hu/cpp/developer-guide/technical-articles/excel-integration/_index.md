---
title: Excel adatok integrálása PowerPoint prezentációkba
linktitle: Excel integráció
type: docs
weight: 330
url: /hu/cpp/excel-integration/
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
- C++
- Aspose.Slides
description: "Olvassa be az adatokat Excel munkafüzetekből az Aspose.Slides ExcelDataWorkbook API-jával. Töltsön be munkalapokat és cellákat, és használja fel az értékeket adatvezérelt PowerPoint prezentációk létrehozásához."
---
## **Bevezetés**

A PowerPoint‑prezentációk hatékony módot nyújtanak az információk megjelenítésére és közlésére. Gyakran használják őket együtt az Excel‑munkafüzetekkel, ahol az Excel kiváló forrása a strukturált adatoknak, a PowerPoint pedig kiválóan alkalmas ezeknek az adatoknak a közönség számára történő vizualizálására.

Számos gyakorlati helyzetben elengedhetetlen az Excel és a PowerPoint kombinációja: levélösszevonások, adatbázis‑táblák feltöltése, egy diát generálása adatrekordonként (batch slide generation), képzési anyagok létrehozása, illetve több Excel‑jelentés egyetlen prezentációba történő összevonása, csak néhány példát említve.

Eddig az ilyen funkciók megvalósítása az Aspose.Slides API‑val harmadik fél megoldásaira, például az Aspose.Cells‑re támaszkodott. Bár ezek az eszközök robosztusak, túl bonyolultak és költségesek lehetnek azok számára, akik csak alapvető adat‑integrációs funkcióra van szükségük.

## **Hogyan működik**

Az Excel‑adatokkal való munka megkönnyítése és egyszerűsítése érdekében az Aspose.Slides új osztályokat vezetett be Excel‑munkafüzetek olvasására és a tartalom prezentációba való importálására. Ez a funkció erőteljes új lehetőségeket nyit meg az API‑felhasználók számára, akik az Excel‑t adatforrásként szeretnék használni a prezentációs munkafolyamatokban.

Az új funkcionalitás általános célú adat‑hozzáférésre készült, és nem része a Presentation Document Object Model‑nek (DOM). Ez azt jelenti, hogy *nem teszi lehetővé az Excel‑fájlok szerkesztését vagy mentését* – egyetlen célja a munkafüzetek megnyitása és azok tartalmának bejárása a cellaadatok lekéréséhez.

A funkció középpontjában az új [ExcelDataWorkbook](https://reference.aspose.com/slides/hu/cpp/aspose.slides.excel/exceldataworkbook/) osztály áll. Ez az osztály lehetővé teszi egy Excel‑munkafüzet betöltését helyi fájlból vagy adatfolyamból. Betöltés után több overload‑ot kínál a [GetCell](https://reference.aspose.com/slides/hu/cpp/aspose.slides.excel/exceldataworkbook/getcell/) metódushoz, amellyel a cellákat pozíciójuk (pl. sor‑ és oszlop‑indexek vagy név‑tartományok) alapján kérhetjük le.

Minden [GetCell](https://reference.aspose.com/slides/hu/cpp/aspose.slides.excel/exceldataworkbook/getcell/) hívás egy [ExcelDataCell](https://reference.aspose.com/slides/hu/cpp/aspose.slides.excel/exceldatacell/) példányt ad vissza. Ez az objektum egyetlen cellát képvisel az Excel‑munkafüzetben, és egyszerű, intuitív módon biztosítja a cella értékéhez való hozzáférést.

#### **Excel diagram importálása**

A következő lépés a funkcionalitás kibővítéséhez a [ExcelWorkbookImporter](https://reference.aspose.com/slides/hu/cpp/aspose.slides.import/excelworkbookimporter/) osztály. Ez az segédosztály lehetővé teszi az Excel‑munkafüzet tartalmának importálását egy prezentációba. Több overload‑ot tartalmaz a [AddChartFromWorkbook](https://reference.aspose.com/slides/hu/cpp/aspose.slides.import/excelworkbookimporter/addchartfromworkbook/) metódushoz, amelyekkel a megadott Excel‑munkafüzetből kiválasztható diagramot lekérhetjük, és a megadott koordinátákon a cél alakzat‑gyűjtemény végére illeszthetjük.

Röviden, ez egy könnyű és egyértelmű API az Excel‑adatok olvasására – pontosan azt, amire sok fejlesztőnek szüksége van anélkül, hogy teljes táblázatkezelő könyvtár súlya nehezedne rá.

## **Kódoljunk**

### **Mail Merge szcenárió példa**

Az alábbi példában egy egyszerű Mail Merge szcenáriót valósítunk meg, több prezentáció generálásával, amely adatokat egy Excel‑munkafüzetben tárol.

A kezdéshez két dologra van szükség:
1. Excel‑munkafüzet az adatokkal

![Excel adatok példa](example1_image0.png)

2. PowerPoint‑prezentáció sablon

![PowerPoint sablon példa](example1_image1.png)

```cpp
// Töltsük be az Excel munkafüzetet a munkavállalói adatokkal.
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// Töltsük be a prezentáció sablont.
auto templatePresentation = MakeObject<Presentation>(u"PresentationTemplate.pptx");

    // Iteráljunk végig az Excel sorokon (az 0. sor fejlécének kihagyásával).
for (auto rowIndex = 1; rowIndex <= 4; rowIndex++) {

    // Készítsünk új prezentációt minden munkavállalói rekordhoz.
    auto employeePresentation = MakeObject<Presentation>();

    // Távolítsuk el az alapértelmezett üres diát.
    employeePresentation->get_Slides()->RemoveAt(0);

    // Klónozzuk a sablon diát az új prezentációba.
    auto slide = employeePresentation->get_Slides()->AddClone(templatePresentation->get_Slide(0));

    // Szerezzük be a bekezdéseket a cél alakzatról (feltételezve, hogy az 1-es indexű alakzatot használjuk).
    auto paragraphs = ExplicitCast<IAutoShape>(slide->get_Shape(1))->get_TextFrame()->get_Paragraphs();

    // Cseréljük le a helyőrzőket az Excel adatára.
    auto employeeName = workbook->GetCell(worksheetIndex, rowIndex, 0)->get_Value()->ToString();
    auto namePortion = paragraphs->idx_get(0)->get_Portion(0);
    namePortion->set_Text(namePortion->get_Text().Replace(u"{{EmployeeName}}", employeeName));

    auto department = workbook->GetCell(worksheetIndex, rowIndex, 1)->get_Value()->ToString();
    auto departmentPortion = paragraphs->idx_get(1)->get_Portion(0);
    departmentPortion->set_Text(departmentPortion->get_Text().Replace(u"{{Department}}", department));

    auto yearsOfService = workbook->GetCell(worksheetIndex, rowIndex, 2)->get_Value()->ToString();
    auto yearsPortion = paragraphs->idx_get(2)->get_Portion(0);
    yearsPortion->set_Text(yearsPortion->get_Text().Replace(u"{{YearsOfService}}", yearsOfService));

    // Mentsük a személyre szabott prezentációt egy külön fájlba.
    employeePresentation->Save(String::Format(u"{0} Report.pptx", employeeName), SaveFormat::Pptx);
    employeePresentation->Dispose();
}

templatePresentation->Dispose();
```

![Eredmény](example1_image2.png)

### **Excel táblázat példa**

A második példában egyszerűen egy Excel‑táblázat adatait másoljuk, és egy PowerPoint‑dián jelenítjük meg vizuálisan vonzóbb formában.

Ebben a példában az első példában használt ugyanazt az Excel‑munkafüzetet használjuk, amely egy egyszerű alkalmazotti táblázatot tartalmaz.

```cpp
// Töltsük be az Excel munkafüzetet, amely a munkavállalói adatokat tartalmaz.
auto workbook = MakeObject<ExcelDataWorkbook>(u"TemplateData.xlsx");
auto worksheetIndex = 0;

// Hozzunk létre egy új PowerPoint prezentációt.
auto presentation = MakeObject<Presentation>();

// Adjunk hozzá egy táblázat alakzatot az első diára.
auto table = presentation->get_Slide(0)->get_Shapes()->AddTable(
    50, 200,
    MakeArray<double>({200, 200, 200}),
    MakeArray<double>({30, 30, 30, 30, 30})
);

// Töltsük fel a PowerPoint táblázatot az Excel munkafüzet adataival.
for (auto rowIndex = 0; rowIndex < 5; rowIndex++) {
    for (auto columnIndex = 0; columnIndex < 3; columnIndex++) {
        auto cellValue = workbook->GetCell(worksheetIndex, rowIndex, columnIndex)->get_Value()->ToString();
        table->get_Column(columnIndex)->idx_get(rowIndex)->get_TextFrame()->set_Text(cellValue);
    }
}

// Mentsük a létrejött prezentációt egy fájlba.
presentation->Save(u"Table.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Eredmény](example2_image0.png)

### **Excel diagram importálása példa**

Ebben a példában egy diagramot importálunk az előző példában használt Excel‑munkafüzet első munkalapjáról. A diagram a kész prezentációban a külső munkafüzetre hivatkozik majd.

Először egy kördiagramot adunk hozzá az Excel‑munkafüzethez az alkalmazottak táblázata alapján.

![Excel diagram példa](example3_image0.png)

```cpp
// Hozzunk létre egy új PowerPoint prezentációt.
auto presentation = MakeObject<Presentation>();

// Szerezzük be az első dia alakzat gyűjteményét.
auto shapes = presentation->get_Slide(0)->get_Shapes();

// Importáljuk a "Chart 1" nevű diagramot a munkafüzet első munkalapjáról, és adjuk hozzá az alakzat gyűjteményhez.
ExcelWorkbookImporter::AddChartFromWorkbook(shapes, 10.0, 10.0, u"TemplateData.xlsx", u"Sheet1", u"Chart 1", false);

// Mentsük a létrejött prezentációt egy fájlba.
presentation->Save(u"Chart.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Eredmény](example3_image1.png)

### **Minden Excel diagram importálása példa**

Képzeljünk el egy Excel‑munkafüzetet, amely tele van diagramokkal, és mindegyiket importálni kell egy prezentációba. Minden diagramot új diára kell helyezni.

Az alábbi kód végigjárja a forrás‑Excel‑fájl minden munkalapját, kinyeri a diagramokat az egyes munkalapokról, és minden diagramot egy külön diára helyez el egy üres diákiosztás használatával. A kész prezentációban csak a diagram adatai lesznek beágyazva, a teljes munkafüzet nem.

```cpp
// Töltsük be az Excel munkafüzetet, amely a munkavállalói adatokat tartalmaz.
auto workbook = MakeObject<ExcelDataWorkbook>(u"ExcelWithCharts.xlsx");

// Hozzunk létre egy új PowerPoint prezentációt.
auto presentation = MakeObject<Presentation>();

// Szerezzük be az üres dia elrendezését.
auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// Szerezzük meg az Excel munkafüzetben szereplő összes munkalap nevét.
auto worksheetNames = workbook->GetWorksheetNames();

for (auto&& name : worksheetNames)
{
    // Szerezzük be a szótárat, amely a diagram indexeket a diagram nevekhez rendeli a munkalapon.
    auto worksheetCharts = workbook->GetChartsFromWorksheet(name);

    for (auto&& chart : worksheetCharts)
    {
        // Adjunk hozzá egy új diát az üres elrendezés használatával.
        auto slide = presentation->get_Slides()->AddEmptySlide(blankLayout);

        // Importáljuk a megadott diagramot az Excel munkafüzetből a dia alakzatgyűjteményébe.
        ExcelWorkbookImporter::AddChartFromWorkbook(slide->get_Shapes(), 10.0, 10.0, workbook, name, chart.get_Key(), false);
    }
}

// Mentsük a létrejött prezentációt egy fájlba.
presentation->Save(u"Charts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Összegzés**

Ez a mechanizmus, amely közvetlenül az Aspose.Slides‑ban érhető el, egy helyen kombinálja az Excel‑adatokkal és a prezentációkkal való munkát. Lehetővé teszi olyan diák létrehozását, amelyek vizuális diagramokkal és Excel‑táblázatokként megjelenített adatokkal rendelkeznek – minden további könyvtár vagy bonyolult integráció nélkül.