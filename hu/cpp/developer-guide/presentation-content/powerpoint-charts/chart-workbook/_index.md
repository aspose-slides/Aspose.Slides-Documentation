---
title: Diagrammunkafüzetek kezelése prezentációkban C++ használatával
linktitle: Diagram munkafüzet
type: docs
weight: 70
url: /hu/cpp/chart-workbook/
keywords:
- diagram munkafüzet
- diagram adat
- munkafüzet cella
- adatcímke
- munkalap
- adatforrás
- külső munkafüzet
- külső adat
- diagram gyorsítótár
- munkafüzet helyreállítás
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for C++-ot: egyszerűen kezelje a diagram munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy hatékonyabbá tegye a prezentáció adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan kell dolgozni diagramm-munkafüzetekkel az Aspose.Slides‑ben. Megmutatja, hogyan lehet a diagram adatokat munkafüzet‑adatfolyamokon keresztül beolvasni és írni, a munkafüzet‑cellákat diagram adatcímkeként használni, a munkalap‑gyűjteményekhez hozzáférni, valamint a diagramértékek adatforrás‑típusát megadni.

Továbbá tárgyalja a külső munkafüzetek diagram adatforrásként való használatát. A példák bemutatják, hogyan kell létrehozni és hozzárendelni egy külső munkafüzetet, lekérdezni egy diagramhoz kapcsolt külső munkafüzet útvonalát, valamint szerkeszteni a diagram adatokat, ha a munkafüzet elérhető.

A hiányzó adatokat képviselő munkafüzet‑cellák esetén lásd a(z) [Control the Display of Empty Cells](/slides/hu/cpp/chart-series/) cikket, amely a üres cella és a nulla közti különbséget, valamint a rendelkezésre álló megjelenítési módok vonaldiagram‑összehasonlítását mutatja be.

## **Rejtett sorok és oszlopok adatainak belefoglalása**

Használd a(z) [IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) metódust annak szabályozására, hogy a diagram a rejtett munkalap‑sorokból és -oszlopokból származó adatokat ábrázolja-e. Állítsd `true`‑ra, ha csak a látható cellákat szeretnéd ábrázolni, vagy `false`‑ra, ha a látható és rejtett cellákat egyaránt bele akarod foglalni. Ez a beállítás a diagram ábrázolását szabályozza; nem rejti el vagy jeleníti meg a munkalap‑sorokat vagy -oszlopokat.

A(z) [sample presentation](hidden-source-data.pptx) egy oszlopdiagramot tartalmaz, amely az első diájának első alakja. A beágyazott munkalap, a `Sheet1`, a következő forrás‑tartományt tartalmazza: `A1:C4`. A 3. sor és a C oszlop rejtett, de a celláik továbbra is tartalmaznak értékeket.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (rejtett sor) | February | 40 | 60 |
| 4 | March | 20 | 50 |

A forrás‑cellákhoz a(z) [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) segítségével férhetsz hozzá, és a(z) [IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/) olvasásával ellenőrizheted a rejtettségi állapotukat. Ez a tulajdonság csak olvasható. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz tartozik, a C2 pedig a rejtett oszlophoz; a példa sorban `False`, `True`, illetve `True` értékeket ír ki.

Ehhez a példához frissítsd a diagram adatokat a rajzolási beállítás módosítása után: tartsd meg a beágyazott munkafüzetet a(z) [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) használatával, és töltsd be újra a(z) [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/)‑nel. Az összes cella belefoglalásakor a(z) [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/)‑et is használd a teljes tartomány visszaállításához, beleértve a rejtett februári kategóriát. Csak a jelző megváltoztatása nem elegendő a minta gyorsítótárazott diagramadatai és kategóriacímkéinek frissítéséhez.

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <initializer_list>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"hidden-source-data.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
    Console::WriteLine(u"B2 hidden: {0}", workbook->GetCell(0, u"B2")->get_IsHidden());
    Console::WriteLine(u"B3 hidden: {0}", workbook->GetCell(0, u"B3")->get_IsHidden());
    Console::WriteLine(u"C2 hidden: {0}", workbook->GetCell(0, u"C2")->get_IsHidden());

    auto workbookStream = chart->get_ChartData()->ReadWorkbookStream();
    for (auto visibleOnly : {true, false})
    {
        chart->set_PlotVisibleCellsOnly(visibleOnly);

        // Frissítse a diagram adatokat a beágyazott munkafüzetből.
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Állítsa vissza a teljes forrás-tartományt, a rejtett kategóriákat is beleértve.
            chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$C$4");
        }

        auto outputPath = visibleOnly ? u"hidden_cells_True.pptx" : u"hidden_cells_False.pptx";
        presentation->Save(outputPath, Export::SaveFormat::Pptx);
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

A példa két változatban menti a prezentációt: az egyik csak a látható kiskereskedelmi értékeket (10 és 20) tartalmazza, a másik az összes hat értéket. Az alábbi képek a két ábrázolási módot szemléltetik. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| Csak látható cellák (`true`) | Összes cella (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

A rejtett cellában lévő érték különbözik egy üres cellától. A(z) [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) szabályozza, hogy a hiányzó értékek hogyan jelenjenek meg; nem vonja be vagy zárja ki a rejtett forrásadatokat. Lásd a(z) [Control the Display of Empty Cells](/slides/hu/cpp/chart-series/#control-the-display-of-empty-cells) cikket egy példáért.

## **Diagram adat-tartományának lekérdezése**

Mielőtt frissítenéd a munkafüzet adatokat egy meglévő prezentációban, ellenőrizd a forrás‑tartományokat, hogy mely munkalap‑cellákat használja az egyes diagramok. A(z) [IChartData::GetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/getrange/) metódus a jelenlegi adat‑tartományt adja vissza munkalap‑kvalifikált képletként, például `Sheet1!$A$1:$D$5`. Itt a `Sheet1` a munkalap neve, a `!` elválasztja a cellatartománytól, a `$A$1:$D$5` pedig az A1‑től D5‑ig terjedő cellákat jelöli, a dollárjelek abszolút sor‑ és oszlopreferenciákat jelentenek.

A metódus a jelenlegi tartományt olvassa anélkül, hogy módosítaná a diagramot vagy annak munkafüzetét. Ha a diagram nem használ munkafüzetet adatforrásként, akkor [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/) kivételt dob. További információkért lásd a(z) [ChartData API Reference](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/) oldalt.

Ez a példa megnyit egy prezentációt, és minden dián közvetlenül ellenőrzi az alakzatokat diagramokra. Kiírja minden diagram nevét és forrás‑tartományát. Ha egy diagram nem használ munkafüzetet, egy üzenetet ír ki, majd a következő diagramra lép.

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/exceptions.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");

for (auto slide : IterateOver(presentation->get_Slides()))
{
    for (auto shape : IterateOver(slide->get_Shapes()))
    {
        auto chart = AsCast<IChart>(shape);
        if (chart != nullptr)
        {
            try
            {
                auto range = chart->get_ChartData()->GetRange();
                Console::WriteLine(u"{0}: {1}", chart->get_Name(), range);
            }
            catch (const InvalidOperationException&)
            {
                Console::WriteLine(u"{0}: The chart does not use a workbook as its data source.", chart->get_Name());
            }
        }
    }
}
```

## **Diagramadatok beolvasása és írása munkafüzetből**

Az Aspose.Slides for C++ biztosítja a(z) [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) és a(z) [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) metódusokat, amelyek lehetővé teszik a diagramadat‑munkafüzetek (az Aspose.Cells‑el szerkesztett diagramadatokat tartalmazó) be- és kiolvasását. **Megjegyzés:** a diagram adatainak ugyanúgy kell felépülniük, vagy hasonló struktúrával kell rendelkezniük, mint a forrásnak.

Ez a példa egy prezentációt használ, amelynek első diáján első alakzata egy diagram. Beolvassa a beágyazott munkafüzetet egy adatfolyamba, törli a meglévő sorozatokat és kategóriákat, majd ugyanazt a munkafüzetet visszaírja. A változtatások memóriában maradnak; a példa nem menti a prezentációt.

```cpp
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    auto workbookStream = chartData->ReadWorkbookStream();

    chartData->get_Series()->Clear();
    chartData->get_Categories()->Clear();

    workbookStream->set_Position(0);
    chartData->WriteWorkbookStream(workbookStream);
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

### **Diagram elrendezésének ellenőrzése munkafüzet módosítása után**

Ha egy beágyazott munkafüzetet módosított munkafüzettel helyettesítesz, a diagram megtartja az eredeti sorozat‑ és kategória‑gyűjteményeit. Ez a nincs egyezés okozhatja, hogy a(z) [IChart::ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/validatechartlayout/) hibát adjon „index‑out‑of‑range” kivétellel. Töröld a meglévő sorozatokat és kategóriákat, mielőtt a frissített munkafüzetet visszaírnád a diagramra. Ez a példa egy diagramot használ, amely az első diájának első alakzata. A megjegyzés jelzi, hol történne a munkafüzet‑szerkesztés; a futtatható példa a régi munkafüzetet írja vissza, és memóriában ellenőrzi az elrendezést.

```cpp
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    auto workbookStream = chartData->ReadWorkbookStream();

    // Módosítsa itt a munkafüzet adatfolyamot, például az Aspose.Cells használatával.

    chartData->get_Series()->Clear();
    chartData->get_Categories()->Clear();

    workbookStream->set_Position(0);
    chartData->WriteWorkbookStream(workbookStream);
    chart->ValidateChartLayout();
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

A gyűjtemények törlése eltávolítja a régóta élő adat‑hivatkozásokat, mielőtt a munkafüzet visszaírásra kerül. Újraépíteni kell a szükséges sorozat‑ és kategória‑leképezéseket a frissített munkafüzethez, mielőtt a diagramot használnád.

## **Egyedi számformátum beállítása munkafüzet‑cellákhoz**

Használd a(z) [IChartDataCell::set_CustomNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_customnumberformat/) metódust annak szabályozására, hogyan jelenjenek meg a numerikus értékek egy diagram beágyazott munkafüzetében. Például egy jelentésnek százalékos konverziós rátát kell megjelenítenie négy tizedes jeggyel, illetve egy együtthatót öt tizedes jeggyel. Mindkét értéket tartsd számmá, hogy továbbra is felhasználható legyen számításokhoz és diagramrajzoláshoz.

A számformátum csak a megjelenést változtatja, a tárolt értéket nem. A `0.0000%` formátum a `0.125` értéket `12.5000%`‑ként jeleníti meg; nem helyettesíti a tárolt számot `12.5`‑tel. Hasonlóképpen a `0.00000` a `0.1234567` értéket `0.12346`‑ként jeleníti meg, a tárolt értéket kerekítés nélkül. Ha az egyedi formátum egy üres karakterlánc (`""`), akkor a [set_PresetNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_presetnumberformat/)‑en keresztül megadott formátum kerül felhasználásra.

Az alábbi példa egy oszlopdiagramot hoz létre, és a celláihoz a(z) [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) segítségével fér hozzá. Az 0‑s munkalapon a B2 a konverziós ráta, a C2 pedig az együttható. Mindkét cella a diagramértékeket szolgáltatja. A példa továbbá engedélyezi az értékcímkéket, amelyek a forrás‑formátumokhoz kapcsolódnak.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(720, 270, SlideSizeScaleType::DoNotScale);
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 20, 620, 210);
chart->set_HasTitle(false);

chart->get_Axes()->get_VerticalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_VerticalAxis()->set_NumberFormat(u"0.00");
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MinValue(0);

chart->get_ChartData()->get_Series()->Clear();
chart->get_ChartData()->get_Categories()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto categoryCell = workbook->GetCell(0, u"A2", ObjectExt::Box<String>(u"Sample"));
chart->get_ChartData()->get_Categories()->Add(categoryCell);

auto percentageCell = workbook->GetCell(0, u"B2", ObjectExt::Box<double>(0.125));
percentageCell->set_CustomNumberFormat(u"0.0000%");
auto percentageName = workbook->GetCell(0, u"B1", ObjectExt::Box<String>(u"Conversion rate"));
auto percentageSeries = chart->get_ChartData()->get_Series()->Add(percentageName, chart->get_Type());
percentageSeries->get_DataPoints()->AddDataPointForBarSeries(percentageCell);

auto precisionCell = workbook->GetCell(0, u"C2", ObjectExt::Box<double>(0.1234567));
precisionCell->set_CustomNumberFormat(u"0.00000");
auto precisionName = workbook->GetCell(0, u"C1", ObjectExt::Box<String>(u"Coefficient"));
auto precisionSeries = chart->get_ChartData()->get_Series()->Add(precisionName, chart->get_Type());
precisionSeries->get_DataPoints()->AddDataPointForBarSeries(precisionCell);

for (auto series : IterateOver(chart->get_ChartData()->get_Series()))
{
    auto labelFormat = series->get_DataPoint(0)->get_Label()->get_DataLabelFormat();
    labelFormat->set_ShowValue(true);
    labelFormat->set_IsNumberFormatLinkedToSource(true);
}

presentation->Save(u"CustomCellFormats.pptx", Export::SaveFormat::Pptx);
```

A munkafüzet‑cellák formátumai különböznek a diagram tengelyein vagy adatcímkéin közvetlenül beállított formátumoktól. Ebben a példában minden címke a forrás‑cellájának értékét jeleníti meg, mert a [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) `true`‑ra van állítva, és a forrás‑számformátumhoz kapcsolódik, mivel a [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_isnumberformatlinkedtosource/) `true`‑ra van állítva. A mentés és újbóli megnyitás után a címkék `12.5000%` és `0.12346` értékeket mutatják, ahogy az alább látható. A függőleges tengely saját `0.00` formátumát használja, amit a [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_numberformat/) állít be, a [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isnumberformatlinkedtosource/) pedig `false`‑ra van állítva.

Egy adatcímke független formázásához állítsd a forrás‑kapcsolat jelzőjét `false`‑ra, és add meg a formátumot a [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_numberformat/)‑el. Ez nem változtatja meg a munkafüzet‑celláé. Például egy független `0.00` formátumú címke az első értéket `0.13`‑ként jeleníti meg, míg a B2 továbbra is `12.5000%`‑t mutat. Lásd a(z) [Chart Data Labels](/slides/hu/cpp/chart-data-label/#set-percentage-sign-with-chart-data-labels) cikket a közvetlen címke‑formázáshoz.

Az alábbi kép a mentett, majd újra megnyitott prezentációból került előállításra:

![Column chart with source-linked labels showing 12.5000% and 0.12346 and an independently formatted numeric axis.](custom-cell-formats.png)

## **Munkafüzet‑cellát diagramadat‑címkének beállítása**

A munkafüzet‑cellák szövegét diagramadat‑címkeként használhatod.

Ez a példa egy buborékdiagramot ad hozzá alapértelmezett adatokkal egy meglévő prezentáció első diájához. Az 0‑s munkalap A10:A12 tartományát használja az első sorozat három első címkéjének, engedélyezi a cellákból származó címkéket, és menti a frissített prezentációt.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDataLabel.h>
#include <DOM/Chart/IDataLabelCollection.h>
#include <DOM/Chart/IDataLabelFormat.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"chart2.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Bubble, 50, 50, 600, 400, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

series->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLabelValueFromCell(true);
auto firstLabelCell = workbook->GetCell(0, u"A10", ObjectExt::Box<String>(u"Label 0 cell value"));
auto secondLabelCell = workbook->GetCell(0, u"A11", ObjectExt::Box<String>(u"Label 1 cell value"));
auto thirdLabelCell = workbook->GetCell(0, u"A12", ObjectExt::Box<String>(u"Label 2 cell value"));
series->get_Labels()->idx_get(0)->set_ValueFromCell(firstLabelCell);
series->get_Labels()->idx_get(1)->set_ValueFromCell(secondLabelCell);
series->get_Labels()->idx_get(2)->set_ValueFromCell(thirdLabelCell);

presentation->Save(u"resultchart.pptx", Export::SaveFormat::Pptx);
```

## **Munkalapok kezelése**

A(z) [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) metódus hozzáférést biztosít a diagram‑munkafüzetben lévő munkalapokhoz. Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és minden munkalap nevét kiírja a konzolra.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataWorksheet.h>
#include <DOM/Chart/IChartDataWorksheetCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 500);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

for (auto i = 0; i < workbook->get_Worksheets()->get_Count(); i++)
{
    Console::WriteLine(workbook->get_Worksheets()->idx_get(i)->get_Name());
}
```

## **Az adatforrás típusának meghatározása**

Sorozat‑pont értékek tárolhatók közvetlenül numerikus literálokként is. Lásd a(z) [Set Series Values Using Numeric Literals](/slides/hu/cpp/chart-series/#set-series-values-using-numeric-literals) cikket egy teljes példaért, amely menti és beolvassa őket. A pontértékek forrás‑típusa különálló a diagram belső vagy külső munkafüzet‑konfigurációjától; a numerikus literálok használata önmagában nem távolítja el a beágyazott munkafüzetet.

Ez a példa egy 3D‑oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozat‑nevet állít be különböző adatforrásokkal. Az első név egy karakter‑literál, a második a 0‑s munkalap C1 cellájából származik. A(z) [DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) felsorolás választja ki az egyes nevek forrását. A példa a frissített sorozat‑nevekkel menti a prezentációt.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Column3D, 50, 50, 600, 400, true);
auto literalName = chart->get_ChartData()->get_Series()->idx_get(0)->get_Name();

literalName->set_DataSourceType(DataSourceType::StringLiterals);
literalName->set_Data(ObjectExt::Box<String>(u"LiteralString"));

auto cellName = chart->get_ChartData()->get_Series()->idx_get(1)->get_Name();
auto nameCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, u"C1", ObjectExt::Box<String>(u"NewCell"));
cellName->set_DataSourceType(DataSourceType::Worksheet);
cellName->set_Data(nameCell);

presentation->Save(u"pres.pptx", Export::SaveFormat::Pptx);
```

## **Nem támogatott beágyazott munkafüzet‑formátumok észlelése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumát, amely egyes diagramokban beágyazható. A(z) [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) metódust a(z) [IChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/)‑val együtt használhatod a [WorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/workbooktype/) felsorolással a nem támogatott formátumok észlelésére, illetve a diagramok kihagyására. Ez a példa az első dián lévő alakzatokat ellenőrzi egy meglévő prezentációban, kihagyja a nem‑diagram alakzatokat, és minden .xlsb‑t beágyazott munkafüzettel rendelkező diagramhoz diagnosztikai üzenetet ír ki.

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/WorkbookType.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto shape : IterateOver(slide->get_Shapes()))
{
    auto chart = AsCast<IChart>(shape);
    if (chart == nullptr)
    {
        continue;
    }

    auto chartData = chart->get_ChartData();
    auto isInternalWorkbook = chartData->get_DataSourceType() == ChartDataSourceType::InternalWorkbook;
    auto isBinaryMacro = chartData->get_EmbeddedWorkbookType() == WorkbookType::WorkbookBinaryMacro;

    if (isInternalWorkbook && isBinaryMacro)
    {
        Console::WriteLine(u"Skipping a chart with an unsupported .xlsb workbook.");
        continue;
    }

    // Olvassa vagy módosítsa a támogatott diagram munkafüzet adatait itt.
}
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetek diagram adatforrásként való használatát.

### **Külső munkafüzet létrehozása**

Használd a(z) [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) és a(z) [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) metódusokat a beágyazott diagram‑munkafüzet exportálásához fájlba, majd a diagram összekapcsolásához azzal a külső munkafüzettel.

Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és exportálja a munkafüzetét. Az összekapcsolás előtt lezárja a kimeneti adatfolyamot, majd menti a hivatkozott prezentációt.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
#include <system/io/file_stream.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600);
auto workbookPath = IO::Path::GetFullPath(u"externalWorkbook1.xlsx");
auto workbookStream = chart->get_ChartData()->ReadWorkbookStream();
auto fileStream = IO::File::Create(workbookPath);
workbookStream->CopyTo(fileStream);
fileStream->Close();

chart->get_ChartData()->SetExternalWorkbook(workbookPath);

presentation->Save(u"externalWorkbook.pptx", Export::SaveFormat::Pptx);
```

### **Külső munkafüzet beállítása**

A(z) [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) metódus segítségével egy külső munkafüzetet rendelhetsz egy diagramhoz adatforrásként. Ez a metódus használható a külső munkafüzet elérési útjának frissítésére is (ha az áthelyezésre került).

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzet adatainak szerkesztése nem lehetséges, továbbra is használhatók külső adatforrásként. Ha relatív útvonalat adsz meg egy külső munkafüzethez, az automatikusan teljes útvonallá lesz konvertálva.

Ez a példa egy külső munkafüzetet használ, amelynek `Sheet1` nevű munkalapja B1‑ben egy sorozat‑nevet, A2:A4‑ben kategória‑neveket, B2:B4‑ben pedig numerikus értékeket tartalmaz. A példa egy kördiagramot hoz létre, összekapcsolja a munkafüzetet, és a(z) [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) segítségével A1:B4‑et leképezi egy sorozatra és három kategóriára. A prezentációt a kapcsolt diagrammal menti.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600, true);
auto chartData = chart->get_ChartData();
auto workbookPath = IO::Path::GetFullPath(u"externalWorkbook.xlsx");

chartData->SetExternalWorkbook(workbookPath);
chartData->SetRange(u"Sheet1!$A$1:$B$4");

presentation->Save(u"Presentation_with_externalWorkbook.pptx", Export::SaveFormat::Pptx);
```

A(z) [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) `updateChartData` paramétere határozza meg, hogy a munkafüzet legyen-e betöltve.

* Ha az `updateChartData` **false**, csak a munkafüzet útvonala frissül. A diagram adatokat nem tölti be vagy frissíti a cél‑munkafüzetről, ezért a munkafüzet lehet, hogy nem érhető el.
* Ha az `updateChartData` **true**, a diagram adatokat frissíti a cél‑munkafüzetről.

Az alábbi példa egy helyettesítő URL‑t ad meg, az `updateChartData` **false**‑ra állítva. Így a kördiagram alapértelmezett adatai megmaradnak, és a prezentációt a nem‑betöltött munkafüzet nélkül menti.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50, 50, 400, 600, true);

chart->get_ChartData()->SetExternalWorkbook(u"https://example.com/unavailable-workbook.xlsx", false);
presentation->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", Export::SaveFormat::Pptx);
```

### **Egy diagram külső adatforrás‑munkafüzete útvonalának lekérdezése**

A diagramhoz kapcsolt munkafüzet azonosításához ellenőrizd, hogy a diagram külső adatforrást használ‑e, és kérdezd le annak munkafüzet‑útvonalát.

Ez a példa az első dián lévő első alakzatot ellenőrzi egy, külső munkafüzettel kapcsolt prezentációban. Ha az egy diagram, amely külső munkafüzettel van összekapcsolva, a példa a [get_ExternalWorkbookPath](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/)‑t írja ki a konzolra, majd a prezentáció egy másolatát menti.

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"externalWorkbook.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto chartData = chart->get_ChartData();
    if (chartData->get_DataSourceType() == ChartDataSourceType::ExternalWorkbook)
    {
        Console::WriteLine(chartData->get_ExternalWorkbookPath());
    }
    else
    {
        Console::WriteLine(u"The chart does not use an external workbook.");
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}

presentation->Save(u"Result.pptx", Export::SaveFormat::Pptx);
```

### **Diagram adatainak szerkesztése**

A külső munkafüzetben lévő adatokat ugyanúgy szerkesztheted, mint a belső munkafüzet tartalmát. Ha egy külső munkafüzet nem tölthető be, kivétel keletkezik.

Ez a példa egy diagramot használ, amely az első diájának első alakzata, és egy elérhető külső munkafüzettel van összekapcsolva. Beállítja az első sorozat első adatpontjának cella‑alapú értékét 100‑ra, és menti a frissített prezentációt. A cellaértékek szerkesztése frissítheti a kapcsolt külső XLSX‑fájlt, ezért használj másolatot, ha az eredeti munkafüzetet meg kell őrizni.

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto series = chart->get_ChartData()->get_Series();
    if (series->get_Count() > 0 && series->idx_get(0)->get_DataPoints()->get_Count() > 0)
    {
        auto valueCell = series->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell();
        if (valueCell != nullptr)
        {
            valueCell->set_Value(ObjectExt::Box<int32_t>(100));
            presentation->Save(u"presentation_out.pptx", Export::SaveFormat::Pptx);
        }
        else
        {
            Console::WriteLine(u"The first data point is not linked to a workbook cell.");
        }
    }
    else
    {
        Console::WriteLine(u"The chart has no data points to edit.");
    }
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

### **Munkafüzet helyreállítása a diagram gyorsítótárából**

Ha egy diagram egy hiányzó vagy nem‑elérhető külső munkafüzettel dolgozik, az Aspose.Slides a prezentációban gyorsítótárazott adatokból rekonstruálhatja a diagram‑munkafüzetet. Hozz létre egy [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) objektumot, konfiguráld a [set_SpreadsheetOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/)‑el, és a nyitás előtt hívd meg az [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/)‑t **true**‑ra.

Az alábbi C++ példa helyreállítja a munkafüzet‑adatokat egy diagramhoz, amely az első diájának első alakzata, és egy nem‑elérhető külső munkafüzetre hivatkozik. A helyreállított adatokat a(z) [IChart::get_ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_chartdata/) és a(z) [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) segítségével éri el:

```cpp
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/SpreadsheetOptions.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->get_Count() > 0 ? AsCast<IChart>(slide->get_Shape(0)) : nullptr;
if (chart != nullptr)
{
    auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

    // Olvassa vagy módosítsa a helyreállított munkafüzet adatait itt.
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

Ha a külső munkafüzet nem elérhető, és a helyreállítás ki van kapcsolva, az Aspose.Slides egy [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/) kivételt dob. Csak akkor engedélyezd a helyreállítást, ha a gyorsítótárazott diagramadatok használata elfogadható tartalék, mivel a gyorsítótár nem feltétlenül tartalmazza a külső munkafüzetben a prezentáció utolsó frissítése óta történt változtatásokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzettel van-e összekapcsolva?**

Igen. Egy diagram rendelkezik egy [data source type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) és egy [path to an external workbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) attribútummal; ha a forrás egy külső munkafüzet, a teljes útvonalat kiolvashatod, hogy megbizonyosodj róla, hogy egy külső fájl van használatban.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat adsz meg, az automatikusan átalakul abszolút úttá. A prezentáció az abszolút útvonalat tárolja a PPTX fájlban, így a munkafüzet áthelyezése esetén frissíteni kell a hivatkozást.

**Használhatók hálózati erőforrásokon/megosztásokon lévő munkafüzetek?**

Igen, ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ből nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja a külső XLSX‑et a prezentáció mentésekor?**

A prezentáció egy [link to the external file](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) tárol. A cella‑alapú diagramadatok szerkesztése frissítheti a kapcsolt helyi XLSX‑fájlt is. Ha az eredetit változatlanul kell hagyni, használj egy másolatot a munkafüzetről.

**Mi a teendő, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad jelszót a hivatkozáshoz. Egy gyakori megoldás, hogy előre eltávolítod a védelmet, vagy egy dekódolt másolatot (például az [Aspose.Cells](https://reference.aspose.com/cells/cpp/)‑al) készítesz, és ahhoz kapcsolod a diagramot.

**Több diagram hivatkozhat ugyanarra a külső munkafüzettel?**

Igen. Minden diagram a saját hivatkozását tárolja. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagramon megjelenik a következő adatbetöltéskor.