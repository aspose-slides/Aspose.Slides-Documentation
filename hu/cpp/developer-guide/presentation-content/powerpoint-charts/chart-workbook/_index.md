---
title: Diagrammunkafüzetek kezelése a prezentációkban C++ használatával
linktitle: Diagrammunkafüzet
type: docs
weight: 70
url: /hu/cpp/chart-workbook/
keywords:
- diagrammunkafüzet
- diagramadat
- munkafüzetcella
- adatcímke
- munkalap
- adatforrás
- külső munkafüzet
- külső adat
- diagramgyorsítótár
- munkafüzet-helyreállítás
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for C++-t: könnyedén kezelje a diagrammunkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse a prezentáció adatait."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan dolgozhat a diagram munkafüzetekkel az Aspose.Slides-ben. Bemutatja, hogyan olvashat és írhat diagramadatokat munkafüzet‑folyamokon keresztül, hogyan használhat munkafüzet‑cellákat diagramadat‑címkeként, hogyan érheti el a munkalap‑gyűjteményeket, és hogyan adhatja meg az adatforrás típusát a diagramértékekhez.

Az is tárgyalja, hogyan használhatók külső munkafüzetek diagramadat‑forrásként. A példák bemutatják, hogyan hozhat létre és rendelhet hozzá egy külső munkafüzetet, hogyan kérheti le egy diagramhoz kapcsolt külső munkafüzet útvonalát, és hogyan szerkesztheti a diagramadatokat, ha a munkafüzet elérhető.

A hiányzó adatot képviselő munkafüzet‑cellák esetén lásd az [Az üres cellák megjelenítésének vezérlése](/slides/hu/cpp/chart-series/) oldalt, ahol megtalálható a különbség az üres cella és a nulla között, valamint egy vonaldiagram‑összehasonlítás a rendelkezésre álló megjelenítési módokról.

## **Rejtett sorok és oszlopok adatainak belefoglalása**

Használja az [IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) metódust annak vezérlésére, hogy a diagram rejtett munkalap‑sorokból és -oszlopokból származó adatokat rajzoljon‑e. Állítsa `true`‑ra, ha csak a látható cellákat akarja ábrázolni, vagy `false`‑ra, ha mind a látható, mind a rejtett cellákat bele kívánja foglalni. Ez a beállítás a diagram rajzolását szabályozza; nem rejti el vagy jeleníti meg a munkalap sorait vagy oszlopait.

Töltse le a [hidden-source-data.pptx](hidden-source-data.pptx) fájlt, és helyezze el a munkakönyvtárban. Az első dián egy oszlopdiagram található első alakzatként. A beágyazott munkalap, a `Sheet1`, a következő forrás‑tartományt tartalmazza: `A1:C4`. A 3. sor és a C oszlop rejtett, de celláik továbbra is értéket tartalmaznak.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | Január | 10 | 30 |
| 3 (rejtett sor) | Február | 40 | 60 |
| 4 | Március | 20 | 50 |

Az adatcellákhoz a [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) segítségével férhet hozzá, és a [IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/) metódussal olvashatja a rejtett státuszukat. Ez a tulajdonság csak olvasható. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz tartozik, és a C2 a rejtett oszlophoz; a példa sorban `False`, `True`, és `True` értékeket nyomtat.

E példában a diagramadatok frissítéséhez a rajzolási beállítás módosítása után: a beágyazott munkafüzetet a [ReadWorkbookStream](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) segítségével tartsa meg, és a [WriteWorkbookStream](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/)‑el töltse be újra. Ha az összes cellát bele szeretné foglalni, használja a [SetRange](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdata/setrange/)‑t is a teljes tartomány, beleértve a rejtett februári kategóriát, helyreállításához. Csak a jelző megváltoztatása nem elegendő a minta gyorsítótárazott diagramadatai és kategória‑címkéi frissítéséhez.

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

        // A diagramadatai frissítése a beágyazott munkafüzetből.
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Állítsa vissza a teljes forrástartományt, beleértve a rejtett kategóriákat.
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

A példa a `hidden_cells_True.pptx` fájlt csak a látható kiskereskedelmi értékekkel (10 és 20) menti, a `hidden_cells_False.pptx` fájlt pedig az összes hat értékkel. Az alábbi képek a két rajzolási módot illusztrálják. A 3. sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| Csak látható cellák (`true`) | Minden cella (`false`) |
| --- | --- |
| ![Csak látható cellák: kiskereskedelmi értékek 10 és 20 januárra és márciusra.](hidden_cells_True.png) | ![Minden cella: kiskereskedelmi és nagykereskedelmi értékek januárra, februárra és márciusra.](hidden_cells_False.png) |

A rejtett, értékkel rendelkező cella különbözik az üres cellától. Az [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichart/get_displayblanksas/) szabályozza, hogyan jelennek meg a hiányzó értékek; nem vonja be vagy zárja ki a rejtett forrásadatokat. Lásd az [Az üres cellák megjelenítésének vezérlése](/slides/hu/cpp/chart-series/#control-the-display-of-empty-cells) példát.

## **Diagramadatok olvasása és írása munkafüzetről**

Az Aspose.Slides for C++ biztosítja a [ReadWorkbookStream](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) és a [WriteWorkbookStream](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) metódusokat, amelyek lehetővé teszik diagramadat‑munkafüzerek (az Aspose.Cells‑el szerkesztett diagramadatokat tartalmazó) olvasását és írását. **Megjegyzés**: a diagramadatokat ugyanúgy kell szervezni, vagy hasonló struktúrával kell rendelkezniük, mint a forrás.

Ez a példa megnyitja a `chart.pptx` fájlt, amelynek az első diájának első alakzataként egy diagramot kell tartalmaznia. A beágyazott munkafüzdet egy folyamba olvassa, törli a meglévő sorozatokat és kategóriákat, majd visszaírja ugyanazt a munkafüzettet. A módosítások memóriában maradnak; a példa nem menti a prezentációt.

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

### **Diagramelrendezés ellenőrzése a munkafüzet módosítása után**

Ha egy beágyazott munkafüzetet egy módosítottval helyettesít, a diagram megtartja az eredeti sorozat‑ és kategória‑gyűjteményeit. Ez az eltérés azt eredményezheti, hogy a [IChart::ValidateChartLayout](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichart/validatechartlayout/) hibát dob index‑túlhatár kivétellel. A frissített munkafüzet diagramhoz való visszaírása előtt törölje a meglévő sorozatokat és kategóriákat. Ez a példa `chart.pptx`‑t igényel, amelynek az első diáján az első alakzat egy diagram. A megjegyzés jelzi, hol történne a munkafüzet szerkesztése; a futtatható példa visszaírja az eredeti munkafüzettet és ellenőrzi a memóriában lévő elrendezést.

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

    // Módosítsa itt a munkafüzetfolyamot, például az Aspose.Cells használatával.

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

A gyűjtemények törlése megszünteti a régi adat hivatkozásokat, mielőtt a munkafüzet visszaírásra kerül. A diagram használata előtt építse újra a szükséges sorozat‑ és kategória‑leképezéseket a frissített munkafüzettel.

## **Munkafüzet‑cella beállítása diagramcímkeként**

A munkafüzet‑cellák szövegét használhatja diagramadat‑címkeként. A következő lépések mutatják, hogyan kapcsolhatók a címkék egy buborékdiagram celláihoz a diagramadat‑munkafüzett.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Hozza el az első diát a nullától indexelés alapján.
1. Adjon hozzá egy buborékdiagramot alapértelmezett adatokkal.
1. Hozza el a diagram sorozatát.
1. Állítsa be a munkafüzet‑cellát adatcímkeként.
1. Mentse a prezentációt.

Ez a példa megnyitja a `chart2.pptx` fájlt, amelynek legalább egy diát kell tartalmaznia, és hozzáad egy alapértelmezett adatokkal rendelkező buborékdiagramot. Az 0‑s munkalapon az A10:A12 cellákat használja az első sorozat első három címkéjének, engedélyezi a cellákból származó címkéket, és a `resultchart.pptx` fájlba menti az eredményt.

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

Az [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) metódus hozzáférést biztosít a diagram‑munkafüzet munkalapjaihoz. Ez a példa egy alapértelmezett adatú kördiagramot hoz létre, és minden munkalap nevét kiírja a konzolra.

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

## **Az adatforrás típusának megadása**

Ez a példa egy alapértelmezett adatú 3D oszlopdiagramot hoz létre, és két sorozat‑nevet állít be különböző adatforrások használatával. Az első név egy karakterlánc‑literált használ; a második a 0‑s munkalap C1 celláját. A [DataSourceType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/datasourcetype/) felsorolás választja ki az egyes nevek forrását. Az eredmény a `pres.pptx` fájlba kerül mentésre.

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

## **Nem támogatott beágyazott munkafüzet formátumok felismerése**

Az Aspose.Slides nem támogatja a néhány diagramba beágyazható Excel bináris munkafüzet (.xlsb) formátumot. A [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) metódust a [IChartData](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdata/)‑on, a [WorkbookType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/workbooktype/) felsorolással kombinálva használhatja a nem támogatott formátumok felismerésére és az ilyen diagramok kihagyására. Ez a példa a `sample.pptx` első diáján lévő alakzatokat vizsgálja, kihagyja a nem diagram alakzatokat, és diagnosztikai üzenetet ír ki minden .xlsb beágyazott munkafüzettel rendelkező diagramhoz.

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

    // Itt olvassa vagy módosítsa a támogatott diagram munkafüzet adatokat.
}
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetek diagramok adatforrásként való használatát.

### **Külső munkafüzet létrehozása**

Használja a [ReadWorkbookStream](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) és a [SetExternalWorkbook](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) metódusokat a beágyazott diagram‑munkafüzet fájlba exportálásához és a diagram külső munkafüzethez való csatolásához.

Ez a példa egy alapértelmezett adatú kördiagramot hoz létre, a munkafüzettét a `externalWorkbook1.xlsx` fájlba írja, majd a kimeneti folyamot bezárja, mielőtt a fájlt a diagram adatforrásaként megadná. A csatolt prezentációt a `externalWorkbook.pptx` fájlba menti.

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

A [SetExternalWorkbook](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) metódus használatával külső munkafüzetet rendelhet egy diagramhoz adatforrásként. Ez a metódus használható a külső munkafüzet útvonalának frissítésére is (ha az át lett helyezve).

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem szerkesztheti, ezeket a munkafüzeteket továbbra is használhatja külső adatforrásként. Ha egy külső munkafüzet relatív útvonalát adja meg, az automatikusan teljes (abszolút) útvonallá alakul.

Ez a példa a `externalWorkbook.xlsx` fájlt igényli a munkakönyvtárban. Az `Sheet1` munkalapnak B1‑ben kell tartalmaznia egy sorozatnevet, A2:A4‑ben kategórianév‑sorozatot, és B2:B4‑ben numerikus értékeket. A példa egy kördiagramot hoz létre, csatolja a munkafüzettet, és a [SetRange](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdata/setrange/) segítségével A1:B4‑et leképezi egy sorozatra és három kategóriára. Az eredményt a `Presentation_with_externalWorkbook.pptx` fájlba menti.

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

A [SetExternalWorkbook](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) `updateChartData` paramétere szabályozza, hogy a munkafüzet betöltődik‑e.

* Ha `updateChartData` értéke `false`, csak a munkafüzet útvonala frissül. A diagramadatok nem töltődnek be vagy frissülnek a célmunkafüzetről, így a munkafüzet lehet elérhetetlen.
* Ha `updateChartData` értéke `true`, a diagramadatok a célmunkafüzetről frissülnek.

A következő példa egy helyőrző URL‑t rendeli a `updateChartData` értéke `false` esetén. A kördiagram alapértelmezett adatait megtartja, és a prezentációt a nem elérhető munkafüzet betöltése nélkül menti.

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

### **Diagram külső adatforrás munkafüzete útvonalának lekérése**

Ahhoz, hogy azonosítsa egy diagramhoz kapcsolt munkafüzetet, először ellenőrizze, hogy a diagram külső adatforrást használ‑e. Ha igen, a következő lépések szerint kérheti le a munkafüzet útvonalát.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Hozza el az első diát a nullától indexelés alapján.
1. Ellenőrizze, hogy az első alakzat egy diagram‑e.
1. Olvassa el a diagram adatforrás típusát.
1. Ha a forrás egy külső munkafüzet, olvassa le annak útvonalát.

Ez a példa megnyitja az előző példában létrehozott `externalWorkbook.pptx` fájlt, és az első dián az első alakzatot vizsgálja. Ha ez egy külső munkafüzettel csatolt diagram, a példa a [get_ExternalWorkbookPath](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/)‑t írja ki a konzolra. Ezután a prezentáció egy másolatát a `Result.pptx` fájlba menti.

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

Külső munkafüzetek adatait ugyanúgy szerkesztheti, ahogyan a belső munkafüzetek tartalmát módosítja. Ha egy külső munkafüzet nem tölthető be, kivétel keletkezik.

Ez a példa a `presentation.pptx` fájlt igényli, amelynek első diáján az első alakzat egy diagram, valamint egy elérhető külső munkafüzet. Az első sorozat első adatpontjának cella‑alapú értékét 100‑ra állítja, és a prezentációt a `presentation_out.pptx` fájlba menti. A cellaértékek szerkesztése frissítheti a csatolt külső XLSX fájlt, ezért használjon másolatot, ha az eredeti munkafüzetet meg kell őrizni.

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

### **Munkafüzete helyreállítása a diagram gyorsítótárából**

Ha egy diagram egy hiányzó vagy nem elérhető külső munkafüzettel dolgozik, az Aspose.Slides a prezentációban gyorsítótárazott adatokból helyreállíthatja a diagram munkafüzetét. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/) objektumot, állítsa be a [set_SpreadsheetOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) segítségével, és a prezentáció megnyitása előtt hívja meg a [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) metódust `true`‑val.

A következő C++ példa megnyitja a `presentation.pptx` fájlt, amelynek első diáján az első alakzatnak egy nem elérhető külső munkafüzetet hivatkozó diagramnak kell lennie, és a helyreállított adatokat a [IChart::get_ChartData](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichart/get_chartdata/) és a [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) segítségével érheti el:

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

Ha a külső munkafüzet nem érhető el és a helyreállítás le van tiltva, az Aspose.Slides egy [System::InvalidOperationException](https://reference.aspose.com/slides/hu/cpp/system/details_invalidoperationexception/) kivételt dob. Engedélyezze a helyreállítást csak akkor, ha a gyorsítótárazott diagramadatok használata elfogadható tartalékmegoldás, mivel a gyorsítótár nem feltétlenül tartalmazza a prezentáció legutóbbi frissítése után a külső munkafüzetben történt módosításokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzettel van‑e összekapcsolva?**

Igen. Egy diagram rendelkezik egy [data source type](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) és egy [path to an external workbook](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) tulajdonsággal; ha a forrás egy külső munkafüzet, akkor kiolvashatja a teljes útvonalat, hogy megbizonyosodjon arról, hogy külső fájlt használ.

**Támogatottak a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, az automatikusan teljes (abszolút) útvonallá alakul. A prezentáció a PPTX fájlban az abszolút útvonalat tárolja, ezért a munkafüzet áthelyezésekor frissíteni kell a hivatkozást.

**Használhatok hálózati erőforrásokon/megosztókon található munkafüzeteket?**

Igen, ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzeteinek közvetlen szerkesztése az Aspose.Slides‑ből nem támogatott – csak forrásként használhatók.

**Felülírja az Aspose.Slides a külső XLSX‑et a prezentáció mentésekor?**

A prezentáció egy [link to the external file](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) (külső fájlra mutató linket) tárol. A cella‑alapú diagramadatok szerkesztése frissítheti a csatolt helyi XLSX fájlt is. Használjon másolatot a munkafüzetről, ha az eredetit változatlanul kell hagyni.

**Mit tegyek, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad jelszót a csatoláskor. Egy általános megközelítés, hogy előre eltávolítja a védelmet, vagy elkészít egy dekódolt másolatot (például az [Aspose.Cells](https://reference.aspose.com/cells/cpp/) segítségével), majd arra hivatkozik.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram saját hivatkozást tárol. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése a következő adatbetöltéskor minden diagramon érvényesül.