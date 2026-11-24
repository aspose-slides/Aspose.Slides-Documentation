---
title: Diagram munkafüzetek kezelése prezentációkban C++ használatával
linktitle: Diagram munkafüzet
type: docs
weight: 70
url: /hu/cpp/chart-workbook/
keywords:
- diagram munkafüzet
- diagram adatok
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
description: "Fedezze fel az Aspose.Slides for C++-t: könnyedén kezelje a diagram munkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse prezentációja adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet dolgozni diagramm munkafüzetekkel az Aspose.Slides-ban. Bemutatja, hogyan olvassuk és írjuk a diagram adatait munkafüzet‑adatfolyamokkal, hogyan használjuk a munkafüzet celláit diagramadat‑címkékhez, hogyan érjük el a munkalap‑gyűjteményeket, és hogyan határozzuk meg az adatforrás típusát a diagramértékekhez.

Az is bemutatja, hogyan lehet külső munkafüzeteket használni diagramok adatforrásaként. A példák azt mutatják be, hogyan hozhatunk létre és rendelhetünk egy külső munkafüzetet, hogyan kérhetjük le egy diagramhoz kapcsolt külső munkafüzet útvonalát, és hogyan szerkeszthetünk diagramadatokat, ha a munkafüzet elérhető.

A hiányzó adatot képviselő munkafüzet‑cellák esetén lásd a [Az üres cellák megjelenítésének szabályozása](/slides/hu/cpp/chart-series/) cikket, amely a különbséget mutatja az üres cella és a nulla között, valamint egy vonaldiagramot a rendelkezésre álló megjelenítési módok összehasonlításával.

## **Rejtett sorok és oszlopok adatainak belefoglalása**

Használja az [IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) metódust annak vezérlésére, hogy a diagram ábrázoljon‑e adatokat rejtett munkalap‑sorokból és -oszlopokból. Állítsa `true`‑ra, ha csak a látható cellákat szeretné ábrázolni, vagy `false`‑ra, ha mind a látható, mind a rejtett cellákat bele akarja foglalni. Ez a beállítás a diagram ábrázolását szabályozza; nem rejt vagy jelenít meg munkalap‑sorokat vagy -oszlopokat.

A [minta bemutató](hidden-source-data.pptx) egy oszlopdiagramot tartalmaz, amely az első dián az első alakzatként jelenik meg. A beágyazott munkalap, `Sheet1`, a következő forrás‑tartományt tartalmazza: `A1:C4`. A 3. sor és a C oszlop rejtett, de celláik még mindig értékeket tartalmaznak.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | January | 10 | 30 |
| 3 (rejtett sor) | February | 40 | 60 |
| 4 | March | 20 | 50 |

A forrás‑cellák eléréséhez használja az [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) metódust, és olvassa az [IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/) tulajdonságát a rejtett állapotuk ellenőrzéséhez. Ez a tulajdonság csak olvasható. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz tartozik, a C2 pedig a rejtett oszlophoz; a példa sorban `False`, `True`, és `True` értékeket ír ki.

Ehhez a példához frissítse a diagramadatokat a megjelenítési beállítás módosítása után: tartsa meg a beágyazott munkafüzetet a [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) segítségével, és töltsözze be újra a [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) metódussal. Az összes cella belefoglalásakor használja a [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) metódust a teljes tartomány visszaállításához, beleértve a rejtett februári kategóriát is. Csak a jelző megváltoztatása nem elegendő a minta gyorsítótárazott diagramadatai és kategória‑címkéi frissítéséhez.

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

        // Frissíti a diagram adatokat a beágyazott munkafüzetből.
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Visszaállítja a teljes forrás tartományt, a rejtett kategóriákat beleértve.
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

A példa két verziót ment a bemutatóból: egyet, amely csak a látható kiskereskedelmi értékeket (10 és 20) tartalmazza, és egy másikat, amely minden hat értéket tartalmaz. Az alábbi képek illusztrálják a két ábrázolási módot. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| Csak látható cellák (`true`) | Minden cella (`false`) |
| --- | --- |
| ![Csak látható cellák: a kiskereskedelmi értékek 10 és 20 januárra és márcra.](hidden_cells_True.png) | ![Minden cella: kiskereskedelmi és nagykereskedelmi értékek januárra, februárra és márcra.](hidden_cells_False.png) |

Egy rejtett cella, amely értéket tartalmaz, különbözik egy üres cellától. Az [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) szabályozza, hogyan jelenjenek meg a hiányzó értékek; nem tartja be vagy veti el a rejtett forrásadatokat. Lásd a [Az üres cellák megjelenítésének szabályozása](/slides/hu/cpp/chart-series/#control-the-display-of-empty-cells) példát.

## **Diagram adat‑tartományának lekérése**

Mielőtt frissítené a munkafüzet adatait egy meglévő bemutatóban, ellenőrizze a forrás‑tartományokat, hogy azonosítsa, mely munkalap‑cellákat használja az egyes diagramok. Az [IChartData::GetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/getrange/) metódus visszaadja a jelenlegi adat‑tartományt egy munkalap‑qualified képlet formájában, például `Sheet1!$A$1:$D$5`. Itt a `Sheet1` a munkalap neve, a `!` elválasztja a cellatartományt, a `$A$1:$D$5` pedig az A1‑től D5‑ig tartó cellákat jelöli, a dollárjelek abszolút sor‑ és oszlop‑hivatkozásokat jelölnek.

A metódus a jelenlegi tartományt olvassa anélkül, hogy változtatna a diagramon vagy annak munkafüzetén. Ha a diagram nem használ munkafüzetet adatforrásként, akkor [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/) kivételt dob. További információkért lásd a [ChartData API Reference](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/) oldalt.

Ez a példa megnyit egy bemutatót, és minden dián közvetlenül ellenőrzi az alakzatokat diagramokra. Kiírja minden diagram nevét és forrás‑tartományát. Ha egy diagram nem használ munkafüzetet, egy üzenetet ír ki, és a következő diagramra lép.

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

## **Diagram adatok olvasása és írása munkafüzetből**

Az Aspose.Slides for C++ biztosítja a [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) és a [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) metódusokat, amelyek lehetővé teszik a diagramadat‑munkafüzetek (az Aspose.Cells‑sel szerkesztett diagramadatokat tartalmazó) olvasását és írását. **Note** hogy a diagramadatoknak ugyanúgy kell felépítve lenniük, vagy hasonló struktúrával kell rendelkezniük, mint a forrás.

Ez a példa egy olyan bemutatót használ, amelynek első diáján az első alakzat egy diagram. Beolvassa a beágyazott munkafüzetet egy adatfolyamba, törli a meglévő sorozatokat és kategóriákat, majd visszaírja ugyanazt a munkafüzetet. A módosítások csak memóriában maradnak; a példa nem menti a bemutatót.

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

### **Diagram elrendezésének ellenőrzése a munkafüzet módosítása után**

Ha egy beágyazott munkafüzetet egy módosítottval helyettesít, a diagram megtartja az eredeti sorozat‑ és kategória‑gyűjteményeit. Ez az eltérés hibához vezethet, amikor az [IChart::ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/validatechartlayout/) index‑out‑of‑range hibát dob. Törölje a meglévő sorozatokat és kategóriákat, mielőtt visszaírná a frissített munkafüzetet a diagramra. Ez a példa egy olyan diagramot használ, amely az első dián az első alakzat. A megjegyzés jelzi, hol történne a munkafüzet szerkesztése; a futtatható példa visszaírja az eredeti munkafüzetet, és memóriában ellenőrzi az elrendezést.

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

    // Módosítsa a munkafüzet adatfolyamot itt, például az Aspose.Cells használatával.

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

A gyűjtemények törlése eltávolítja a már nem érvényes adat‑hivatkozásokat, mielőtt a munkafüzet vissza lenne írva. Építse újra a szükséges sorozat‑ és kategória‑leképezéseket a frissített munkafüzethez, mielőtt a diagramot használja.

## **A kategória címkék tárolási módjának kiválasztása**

Hívja meg az [IChartCategoryCollection::set_UseCells](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartcategorycollection/set_usecells/) metódust az üres kategória‑gyűjteményen, mielőtt címkéket adna hozzá. Használjon munkalap‑cellákat olyan címkékhez, amelyek munkafüzetadatokra hivatkoznak vagy hierarchiát alkotnak, például éves csoportosítású negyedéveket. Használjon karakter‑literálokat egyetlen szintű címkéhez, amelynek nincs cellahivatkozása. Ez a beállítás csak a kategóriákra vonatkozik. Mindkét diagram a példában a numerikus sorozat‑értékekhez munkalap‑cellákat használ.

A példa két oszlopdiagramot hoz létre, és kiírja a tárolási módot valamint a `Q1 Q2 Q3 Q4` címkéket mindkét diagramra. A munkalap‑alapú címkékhez az [IChartCategory::get_AsCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartcategory/get_ascell/) biztosít hozzáférést az underlying cellához, az [IChartDataCell::get_Value](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_value/) pedig visszaadja a címkét. Literális címkék esetén a sztringet közvetlenül az [IChartCategory::get_Value](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartcategory/get_value/) metódusból olvassa.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategory.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <initializer_list>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

for (auto useCells : {true, false})
{
    auto x = useCells ? 20 : 360;
    auto chart = shapes->AddChart(ChartType::ClusteredColumn, x, 20, 320, 250);
    auto data = chart->get_ChartData();
    auto categories = data->get_Categories();
    data->get_Series()->Clear();
    categories->Clear();
    categories->set_UseCells(useCells);

    auto workbook = data->get_ChartDataWorkbook();
    auto seriesName = workbook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Sales"));
    auto series = data->get_Series()->Add(seriesName, chart->get_Type());
    for (auto row = 1; row <= 4; ++row)
    {
        auto label = String::Format(u"Q{0}", row);
        auto labelValue = ObjectExt::Box<String>(label);
        if (useCells)
        {
            auto labelCell = workbook->GetCell(0, row, 0, labelValue);
            categories->Add(labelCell);
        }
        else
        {
            categories->Add(labelValue);
        }

        auto valueCell = workbook->GetCell(0, row, 1, ObjectExt::Box<int32_t>(row * 10));
        series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
    }

    Console::Write(u"UseCells = {0}:", categories->get_UseCells());
    for (auto category : IterateOver(categories))
    {
        auto label = categories->get_UseCells() ? category->get_AsCell()->get_Value() : category->get_Value();
        Console::Write(u" {0}", label->ToString());
    }
    Console::WriteLine();
}

presentation->Save(u"category-labels.pptx", Export::SaveFormat::Pptx);
```

## **Egyéni számformátumok beállítása munkafüzet cellákhoz**

Használja az [IChartDataCell::set_CustomNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_customnumberformat/) metódust annak meghatározására, hogy a numerikus értékek hogyan jelenjenek meg egy diagram beágyazott munkafüzetében. Például egy jelentésnek lehet szüksége egy konverziós arányra, amelyet százalékosan, négy tizedesjeggyel, valamint egy együtthatóra, amelyet öt tizedesjeggyel kell megjeleníteni. Tartsa mindkét értéket numerikus formában, hogy a számítások és a diagram ábrázolása számára is elérhető legyen.

A számformátum csak a megjelenítést módosítja, nem a tárolt értéket. A `0.0000%` formátum a `0.125`‑öt `12.5000%`‑ként jeleníti meg; nem cseréli le a tárolt számot `12.5`‑re. Hasonlóan, a `0.00000` a `0.1234567`‑et `0.12346`‑ként jeleníti meg anélkül, hogy a tárolt értéket kerekítené. Ha az egyéni formátum egy üres karakterlánc (`""`), akkor a [set_PresetNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_presetnumberformat/) által hozzárendelt formátum kerül felhasználásra.

Az alábbi példa létrehoz egy oszlopdiagramot, és a celláihoz a [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) segítségével fér hozzá. Az 0‑számú munkalapon a B2 tartalmazza a konverziós rátát, a C2 pedig a koefficienst. Mindkét cella diagramértékeket szolgáltat. A példa engedélyezi az érték‑címkéket, amelyek a forrás formátumokra hivatkoznak.

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

A munkafüzet‑cellák formátumai különböznek a diagram tengelyeire vagy adatcímkéire közvetlenül beállított formátumoktól. Ebben a példában minden címke a forrás‑cellája értékét jeleníti meg, mivel a [set_ShowValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_showvalue/) `true`‑val van meghívva, és a forrás számformátumot követi, mivel a [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_isnumberformatlinkedtosource/) `true`‑val van meghívva. A bemutató mentése és újbóli megnyitása után a címkék `12.5000%` és `0.12346` értékeket mutatnak, ahogy az alább látható. A függőleges tengely saját `0.00` formátumot használ, amelyet a [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_numberformat/) ad meg, a [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isnumberformatlinkedtosource/) pedig `false`‑ra van állítva.

Ahhoz, hogy egy adatcímkét önállóan formázzunk, állítsa a forrás‑hivatkozás jelzőjét `false`‑ra, és rendelje hozzá a formátumot a [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idatalabelformat/set_numberformat/) segítségével. Ez nem változtatja meg a munkafüzet‑cellák formátumát. Például egy `0.00` formátumú önálló címke az első értéket `0.13`‑ként jeleníti meg, míg a B2 továbbra is `12.5000%`‑t mutat. Lásd a [Diagram adatcímkék](/slides/hu/cpp/chart-data-label/#set-percentage-sign-with-chart-data-labels) cikket a közvetlen címkeformázáshoz.

Az alábbi kép a mentett bemutató újbóli megnyitása után lett renderelve:

![Diagram oszlop diagram forrásra hivatkozó címkékkel, amelyek 12.5000% és 0.12346 értékeket mutatnak, valamint önállóan formázott numerikus tengely.](custom-cell-formats.png)

## **Munkafüzet cella beállítása diagram adatcímkeként**

A munkafüzet celláiból származó szöveget használhatja diagram adatcímkékként.

Ez a példa egy buborékdiagramot ad hozzá az első diára egy meglévő bemutatóban, alapértelmezett adatokkal. A 0‑számú munkalapon az A10:A12 cellákat használja az első sorozat első három címkéjéhez, engedélyezi a cellákból származó címkéket, és menti a frissített bemutatót.

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

Az [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) metódus hozzáférést biztosít a diagram‑munkafüzetben lévő munkalapokhoz. Ez a példa egy alapértelmezett adatú kördiagramot hoz létre, és minden munkalap nevét kiírja a konzolra.

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

A sorozat‑pont értékek közvetlenül numerikus literálokként is tárolhatók. Lásd a [Sorozatértékek beállítása numerikus literálokkal](/slides/hu/cpp/chart-series/#set-series-values-using-numeric-literals) példát a teljes példa megtekintéséhez, amely menti és beolvassa őket. A pontértékek forrás‑típusa különbözik a diagram belső vagy külső munkafüzet‑konfigurációjától; a numerikus literálok használata önmagában nem távolítja el a beágyazott munkafüzetet.

Ez a példa egy 3D oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozat nevét különböző adatforrásokkal állítja be. Az első név karakter‑literál, a második a 0‑számú munkalap C1 cellájából. A [DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) felsorolás választja ki az egyes nevek forrását. A példa menti a bemutatót a frissített sorozatnevekkel.

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

## **Nem támogatott beágyazott munkafüzetformátumok észlelése**

Az Aspose.Slides nem támogatja az Excel bináris munkafüzet (.xlsb) formátumot, amely bizonyos diagramokba beágyazható. A [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) metódust használhatja az [IChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/) és a [WorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/workbooktype/) felsorolás kombinációjával, hogy észlelje a nem támogatott formátumokat, és kihagyja az érintett diagramokat. Ez a példa egy meglévő bemutató első diáján lévő alakzatokat ellenőrzi, kihagyja a nem diagram alakzatokat, és diagnosztikai üzenetet ír ki minden .xlsb beágyazott munkafüzetet tartalmazó diagramra.

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

    // Olvasd vagy módosítsd itt a támogatott diagram munkafüzet adatokat.
}
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetek diagramok adatforrásként való használatát.

### **Külső munkafüzet létrehozása**

Használja a [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) és a [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) metódusokat a beágyazott diagram‑munkafüzet exportálásához egy fájlba, és a diagram összekapcsolásához a külső munkafüzettel.

Ez a példa egy alapértelmezett adatú kördiagramot hoz létre, és exportálja a munkafüzetét. A kimeneti adatfolyamot bezárja, mielőtt a külső munkafüzetet a diagram adatforrásaként beállítaná, majd menti a kapcsolt bemutatót.

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

A [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) metódus használatával egy külső munkafüzetet rendelhet egy diagramhoz adatforrásként. Ez a metódus használható a külső munkafüzet elérési útjának frissítésére is (ha a fájl helye megváltozott).

Bár nem szerkesztheti a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait, továbbra is használhat ilyen munkafüzeteket külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzethez, az automatikusan teljes útvonallá konvertálódik.

Ez a példa egy olyan külső munkafüzetet használ, amelynek `Sheet1` nevű munkalapja B1‑ben sorozatnevet, A2:A4‑ben kategória neveket és B2:B4‑ben numerikus értékeket tartalmaz. A példa kördiagramot hoz létre, összekapcsolja a munkafüzetet, és a [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) segítségével az A1:B4‑et egy sorozatra és három kategóriára térképezi. A bemutatót a kapcsolt diagrammal menti.

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

A [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) `updateChartData` paramétere szabályozza, hogy a munkafüzet be legyen‑töltve.

* Amikor az `updateChartData` `false`, csak a munkafüzet útvonala frissül. A diagramadatok nem töltődnek be és nem frissülnek a cél‑munkafüzetből, így a munkafüzet lehet elérhetetlen.
* Amikor az `updateChartData` `true`, a diagramadatok frissülnek a cél‑munkafüzetből.

Az alábbi példa egy helyőrző URL‑t ad meg, az `updateChartData` `false` értékkel. A kördiagram alapértelmezett adatait megtartja, és a bemutatót a nem betöltött munkafüzet nélkül menti.

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

### **A diagram külső adatforrás munkafüzetének útvonalának lekérése**

A diagramhoz kapcsolt munkafüzet azonosításához ellenőrizze, hogy a diagram külső adatforrást használ‑e, és kérje le a munkafüzet útvonalát.

Ez a példa az első dián az első alakzatot ellenőrzi egy olyan bemutatóban, amelynek külső munkafüzethez van kapcsolva. Ha ez egy külső munkafüzethez kapcsolt diagram, a példa a [get_ExternalWorkbookPath](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) értékét írja ki a konzolra. Ezután a bemutató egy másolatát menti.

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

### **Diagram adatok szerkesztése**

A külső munkafüzetek adatait ugyanúgy szerkesztheti, ahogy a belső munkafüzetek tartalmát módosítaná. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

Ez a példa egy olyan diagramot használ, amely az első dián az első alakzat, és elérhető külső munkafüzethez van kapcsolva. Beállítja az első sorozat első adatpontjának cella‑háttér‑értékét 100-ra, majd menti a frissített bemutatót. A cella‑értékek szerkesztése frissítheti a kapcsolt külső XLSX fájlt, ezért használjon másolatot, ha az eredeti munkafüzetet meg kell őrizni.

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

Ha egy diagram olyan külső munkafüzetet használ, amely hiányzik vagy nem érhető el, az Aspose.Slides rekonstruálhatja a diagram‑munkafüzetet a bemutató gyorsítótárában tárolt adatokból. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) objektumot, konfigurálja a [set_SpreadsheetOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) segítségével, és hívja a [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) metódust `true`‑val, mielőtt megnyitná a bemutatót.

Az alábbi C++ példa visszaállítja a munkafüzet‑adatokat egy olyan diagramhoz, amely az első dián az első alakzat, és egy elérhetetlen külső munkafüzetre hivatkozik. A visszaállított adatokat eléri az [IChart::get_ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_chartdata/) és az [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) segítségével:

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

    // Olvasd vagy módosítsd itt a helyreállított munkafüzet adatait.
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

Ha a külső munkafüzet elérhetetlen, és a helyreállítás le van tiltva, az Aspose.Slides [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/) kivételt dob. Engedélyezze a helyreállítást csak akkor, ha a gyorsítótárazott diagramadatok használata elfogadható tartalék megoldás, mivel a gyorsítótár nem tartalmazhatja a külső munkafüzeten történt változásokat, miután a bemutatót legutóbb frissítették.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzethez kapcsolódik?**

Igen. A diagramnek van egy [data source type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) és egy [path to an external workbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) attribútuma; ha a forrás egy külső munkafüzet, kiolvashatja a teljes útvonalat, hogy megbizonyosodjon arról, egy külső fájlt használ.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, az automatikusan átalakul abszolút útvonallá. A bemutató az abszolút útvonalat tárolja a PPTX fájlban, így a munkafüzet áthelyezése esetén frissíteni kell a hivatkozást.

**Használhatok munkafüzeteket hálózati erőforrásokon/megosztott meghajtókon?**

Igen, az ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ból nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja a külső XLSX‑et a bemutató mentésekor?**

A bemutató egy [link to the external file](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) tárol. A cella‑háttér‑diagramadatok szerkesztése szintén frissítheti a kapcsolt helyi XLSX fájlt. Használjon munkafüzet‑másolatot, ha az eredetit érintetlenül kell hagyni.

**Mit tegyek, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad jelszót a kapcsolódáskor. Egy gyakori megoldás, hogy előre eltávolítja a védelmet, vagy egy visszafejtett másolatot készít (például az [Aspose.Cells](https://reference.aspose.com/cells/cpp/) segítségével), és arra hivatkozik.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram a saját hivatkozását tárolja. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése a következő adatbetöltéskor minden diagramon megjelenik.