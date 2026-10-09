---
title: Diagrammunkafüzetek kezelése bemutatókban C++ használatával
linktitle: Diagrammunkafüzet
type: docs
weight: 70
url: /hu/cpp/chart-workbook/
keywords:
- diagrammunkafüzet
- diagramadat
- munkafüzet cella
- adatcímke
- munkalap
- adatforrás
- külső munkafüzet
- külső adat
- diagramgyorsítótár
- munkafüzet helyreállítás
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for C++-t: könnyedén kezelje a diagrammunkafüzeteket PowerPoint és OpenDocument formátumokban, hogy egyszerűsítse a prezentáció adatait."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan dolgozhatunk diagrammunkafüzetekkel az Aspose.Slides‑ben. Megmutatja, hogyan olvassunk és írjunk diagramadatokat munkafüzet‑adatfolyamok segítségével, hogyan használjunk munkafüzet‑cellákat diagramadat‑címkeként, hogyan érjünk el munkalap‑gyűjteményeket, és hogyan adhatjuk meg az adatforrás‑típust a diagramértékekhez.

Továbbá bemutatja a külső munkafüzetek diagramadat‑forrásként való használatát. A példák azt mutatják, hogyan hozzunk létre és rendeljünk hozzá egy külső munkafüzetet, hogyan szerezzük meg egy diagramhoz kapcsolt külső munkafüzet útvonalát, és hogyan szerkesszük a diagramadatokat, ha a munkafüzet elérhető.

A hiányzó adatot képviselő munkafüzet‑cellákhoz lásd a [Control the Display of Empty Cells](/slides/hu/cpp/chart-series/) témát, ahol az üres cella és a nulla közti különbséget, valamint egy vonaldiagram‑összehasonlítást láthat a rendelkezésre álló megjelenítési módok között.

## **Rejtett sorok és oszlopok adatainak belefoglalása**

Használja az [IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) metódust annak vezérlésére, hogy a diagram megjelenítse-e a rejtett munkalap‑sorok és -oszlopok adatait. Állítsa `true`‑ra, ha csak a látható cellákat szeretné megjeleníteni, vagy `false`‑ra, ha a látható és rejtett cellákat egyaránt bele akarja foglalni. Ez a beállítás a diagram ábrázolását szabályozza; nem rejt el vagy jelenít meg munkalap‑sorokat vagy -oszlopokat.

A [sample presentation](hidden-source-data.pptx) egy oszlopdiagramot tartalmaz első alakzatként az első dia első diáján. A beágyazott munkalap, `Sheet1`, a következő forrás‑tartományt tartalmazza, `A1:C4`. A 3‑as sor és a C oszlop rejtett, de celláik még mindig tartalmaznak értékeket.

| Munkalap sor | A: Hónap | B: Kiskereskedelem | C: Nagykereskedelem (rejtett oszlop) |
| --- | --- | --- | --- |
| 2 | január | 10 | 30 |
| 3 (rejtett sor) | február | 40 | 60 |
| 4 | március | 20 | 50 |

A forrás‑cellák eléréséhez használja az [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) metódust, és ellenőrizze a [IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/) tulajdonságot. Ez a tulajdonság csak olvasható. Ebben a fájlban a B2 látható, a B3 a rejtett sorhoz tartozik, a C2 pedig a rejtett oszlophoz; a példa `False`, `True`, és `True` értékeket ír ki.

Ehhez a példához frissítse a diagramadatot a rajzolási beállítás módosítása után: tartsa meg a beágyazott munkafüzetet a [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) segítségével, és töltse be újra a [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) használatával. Ha minden cellát bele akar foglalni, használja a [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) metódust a teljes tartomány, köztük a rejtett februári kategória visszaállításához. Csak a jelző megváltoztatása nem elegendő a példa gyorsítótárazott diagramadatainak és kategória‑címkéinek frissítéséhez.

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

        // Frissítse a diagram adatokat a beágyazott munkafüzetről.
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Állítsa vissza a teljes forrás‑tartományt, beleértve a rejtett kategóriákat.
            chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$C$4");
        }

        auto outputPath = visibleOnly ? u"hidden_cells_True.pptx" : u"hidden_cells_False.pptx";
        presentation->Save(outputPath, Export::SaveFormat::Pptx);
    }
}
else
{
    // Az első alakzat nem diagram.
    Console::WriteLine(u"The first shape is not a chart.");
}
```

A példa két változatban menti a prezentációt: egyben csak a látható Kiskereskedelem értékek (10 és 20) szerepelnek, a másikban mind a hat érték. Az alábbi képek a két rajzolási módot szemléltetik. A 3‑as sor és a C oszlop mindkét beágyazott munkafüzetben rejtett marad.

| Csak látható cellák (`true`) | Minden cella (`false`) |
| --- | --- |
| ![Only visible cells: Retail values 10 and 20 for January and March.](hidden_cells_True.png) | ![All cells: Retail and Wholesale values for January, February, and March.](hidden_cells_False.png) |

Egy rejtett, értéket tartalmazó cella különbözik egy üres cellától. Az [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) szabályozza, hogy a hiányzó értékek hogyan jelenjenek meg; nem vonja be vagy zárja ki a rejtett forrásadatot. Lásd a [Control the Display of Empty Cells](/slides/hu/cpp/chart-series/#control-the-display-of-empty-cells) példát.

## **Diagram adat-tartományának lekérése**

Mielőtt módosítaná a munkafüzet adatokat egy meglévő prezentációban, ellenőrizze a forrás‑tartományokat, hogy meghatározza, mely munkalap‑cellákat használja az egyes diagramok. Az [IChartData::GetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/getrange/) metódus visszaadja a jelenlegi adat‑tartományt egy munkalap‑specifikus képletként, például `Sheet1!$A$1:$D$5`. Itt a `Sheet1` a munkalap neve, a `!` elválasztja a cellatartományt, a `$A$1:$D$5` pedig az A1‑től D5‑ig terjedő cellákat jelöli, mindkettő tartalmazva. A dollárjelek abszolút sor‑ és oszlop‑hivatkozásokat jelentenek.

A metódus a jelenlegi tartományt olvassa anélkül, hogy módosítaná a diagramot vagy annak munkafüzetét. Ha a diagram nem használ munkafüzetet adatforrásként, [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/) kivételt dob. További információk a [ChartData API Reference](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/) oldalon.

Ez a példa megnyit egy prezentációt, és a diákon közvetlenül ellenőrzi az alakzatokat, hogy diagramok-e. Kiírja minden diagram nevét és forrás‑tartományát. Ha egy diagram nem használ munkafüzetet, egy üzenetet jelenít meg, majd a következő diagramra lép tovább.

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

## **Diagramadatok olvasása és írása munkafüzetből**

Az Aspose.Slides for C++ biztosítja a [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) és a [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) metódusokat, amelyek lehetővé teszik a diagramadat‑munkafüzetek (Aspose.Cells‑szel szerkesztett diagramadatok) olvasását és írását. **Megjegyzés:** a diagramadatnak ugyanolyan módon szerveződnie kell, vagy hasonló szerkezettel kell rendelkeznie, mint a forrás.

Ez a példa egy prezentációt használ, amelynek első alakzata egy diagram az első dián. Beolvassa a beágyazott munkafüzetet egy adatfolyamba, törli a meglévő sorozatokat és kategóriákat, majd ugyanazt a munkafüzetet visszaírja. A változások a memóriában maradnak; a példa nem menti a prezentációt.

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

Amikor egy beágyazott munkafüzetet felülír egy módosított példánnyal, a diagram megtartja az eredeti sorozat‑ és kategória‑gyűjteményeit. Ez a nem egyezés az [IChart::ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/validatechartlayout/) hibához vezethet, „index‑out‑of‑range” kivételt dobva. Törölje a meglévő sorozatokat és kategóriákat, mielőtt visszaírná a frissített munkafüzetet a diagramhoz. Ez a példa egy diagramot használ, amely az első dia első alakzata. A megjegyzés helye jelzi, hol történne a munkafüzet‑szerkesztés; a futtatható példa az eredeti munkafüzetet írja vissza, és a memóriában ellenőrzi az elrendezést.

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

    // Módosítsa itt a munkafüzet adatfolyamát, például az Aspose.Cells használatával.

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

A gyűjtemények törlése eltávolítja a régi adat‑referenciákat, mielőtt a munkafüzet visszaíródna. Építse újra a szükséges sorozat‑ és kategória‑leképezéseket a frissített munkafüzethez, mielőtt a diagramot használja.

## **Munkafüzet‑cellát diagramadat‑címkeként beállítása**

A munkafüzet‑cellák szövegét felhasználhatja diagramadat‑címkeként.

Ez a példa egy buborékdiagramot ad hozzá alapértelmezett adatokkal egy meglévő prezentáció első diájához. Az 0‑ás munkalap A10:A12 tartományát használja az első sorozat három első címkéjéhez, engedélyezi a címkék cellákból való felvételét, és menti a frissített prezentációt.

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

Az [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) metódus lehetővé teszi a diagram munkafüzetének munkalapjaihoz való hozzáférést. Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és kiírja minden munkalap nevét a konzolra.

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

Ez a példa egy 3D oszlopdiagramot hoz létre alapértelmezett adatokkal, és két sorozat‑nevet állít be különböző adatforrások használatával. Az első nevet karakterlánc‑literálként adja meg; a másodikat a 0‑ás munkalap C1 cellájából veszi. A [DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) enumerációval választható a forrás minden névhez. A példa a frissített sorozat‑nevekkel menti a prezentációt.

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

## **Nem támogatott beágyazott munkafüzetformátumok felismerése**

Az Aspose.Slides nem támogatja a néhány diagramban beágyazható Excel bináris munkafüzet (.xlsb) formátumot. A [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) metódust az [IChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/) esetén a [WorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/workbooktype/) enumerációval együtt használhatja a nem támogatott formátumok felismerésére és a megfelelő diagramok kihagyására. Ez a példa az első dia alakzatait vizsgálja egy meglévő prezentációban, a nem diagram alakzatokat átugorja, és diagnosztikai üzenetet ír ki minden olyan diagramhoz, amely beágyazott .xlsb munkafüzetet használ.

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

    // Olvassa vagy módosítsa a támogatott diagrammunkafüzet adatokat itt.
}
```

## **Külső munkafüzet**

Az Aspose.Slides támogatja a külső munkafüzetek diagramok adatforrásként való használatát.

### **Külső munkafüzet létrehozása**

Használja a [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) és a [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) metódusokat a beágyazott diagrammunkafüzet exportálásához egy fájlba, majd a diagram összekapcsolásához a külső munkafüzettel.

Ez a példa egy kördiagramot hoz létre alapértelmezett adatokkal, és exportálja annak munkafüzetét. A kimeneti adatfolyamot a külső munkafüzet diagramadat‑forrásként történő hozzárendelése előtt zárja be, majd menti a kapcsolt prezentációt.

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

A [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) metódus használatával egy külső munkafüzetet rendelhet egy diagramhoz adatforrásként. Ezzel a metódussal frissítheti a külső munkafüzet elérési útját is (ha az át lett helyezve).

Bár a távoli helyeken vagy erőforrásokban tárolt munkafüzetek adatait nem szerkesztheti közvetlenül, ezek a munkafüzetek továbbra is használhatók külső adatforrásként. Ha relatív útvonalat ad meg egy külső munkafüzettel, az automatikusan teljes elérési úttá konvertálódik.

Ez a példa egy külső munkafüzetet használ, amelynek `Sheet1` munkalapján B1‑ben egy sorozat‑név, A2:A4‑ben kategória‑nevek, B2:B4‑ben numerikus értékek találhatók. A példa egy kördiagramot hoz létre, összekapcsolja a munkafüzetet, és a [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) segítségével az A1:B4‑et egy sorozatra és három kategóriára képezi le. A prezentációt a kapcsolt diagrammal menti.

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

A [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) `updateChartData` paramétere szabályozza, hogy a munkafüzet betöltődjön‑e.

* Ha `updateChartData` **false**, csak a munkafüzet útvonala frissül. A diagramadat nem töltődik be vagy frissül a célmunkafüzetről, így a munkafüzet hiányzik is lehet.
* Ha `updateChartData` **true**, a diagramadat frissül a célmunkafüzetről.

Az alábbi példa egy helyettesítő URL‑t ad meg `updateChartData` **false** értékkel. A kördiagram alapértelmezett adatai megmaradnak, és a prezentációt a munkafüzet betöltése nélkül menti.

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

### **Diagram külső adatforrás‑munkafüzet útvonalának lekérdezése**

A diagramhoz kapcsolt munkafüzet azonosításához ellenőrizze, hogy a diagram külső adatforrást használ‑e, majd szerezze meg annak munkafüzet‑útvonalát.

Ez a példa az első dia első alakzatát vizsgálja egy kapcsolt külső munkafüzettel rendelkező prezentációban. Ha egy diagram külső munkafüzethez van kapcsolva, a példa kiírja a [get_ExternalWorkbookPath](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) értékét a konzolra, majd ment egy másolatot a prezentációról.

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

### **Diagramadat szerkesztése**

Külső munkafüzetek adatait ugyanúgy szerkesztheti, mint a belső munkafüzetekét. Ha egy külső munkafüzetet nem lehet betölteni, kivétel keletkezik.

Ez a példa egy diagramot használ, amely az első dia első alakzata, és egy elérhető külső munkafüzethez kapcsolódik. A első sorozat első adatpontjának cella‑alapú értékét 100‑ra állítja, majd menti a frissített prezentációt. A cellaértékek szerkesztése frissítheti a kapcsolt külső XLSX fájlt, ezért használjon másolatot, ha az eredeti munkafüzetet meg kell őrizni.

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

Ha egy diagram külső, hiányzó vagy elérhetetlen munkafüzettel dolgozik, az Aspose.Slides a diagram gyorsítótárában tárolt adatokból rekonstruálhatja a diagrammunkafüzetet. Hozzon létre egy [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/) objektumot, állítsa be a [set_SpreadsheetOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/) metódussal, és hívja meg a [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) metódust `true` értékkel a prezentáció megnyitása előtt.

Az alábbi C++ példa helyreállítja a munkafüzet adatokat egy diagramhoz, amely az első dia első alakzata, és egy nem elérhető külső munkafüzetre hivatkozik. A helyreállított adatokat az [IChart::get_ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_chartdata/) és az [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) segítségével éri el:

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

Ha a külső munkafüzet nem érhető el, és a helyreállítás ki van kapcsolva, az Aspose.Slides [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/) kivételt dob. Engedélyezze a helyreállítást csak akkor, ha a gyorsítótár‑adatok használata elfogadható visszaesés, mivel a gyorsítótár nem tartalmazhatja az externális munkafüzetben a prezentáció legutóbbi frissítése óta történt változásokat.

## **GYIK**

**Meg tudom határozni, hogy egy adott diagram külső vagy beágyazott munkafüzethez van-e kapcsolva?**

Igen. A diagramnek van egy [data source type](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) és egy [path to an external workbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); ha a forrás külső munkafüzet, a teljes útvonal elolvasásával ellenőrizheti, hogy külső fájlt használ‑e.

**Támogatottak-e a relatív útvonalak a külső munkafüzetekhez, és hogyan tárolódnak?**

Igen. Ha relatív útvonalat ad meg, az automatikusan abszolút útvonalra konvertálódik. A prezentáció az abszolút útvonalat tárolja a PPTX fájlban, így a munkafüzet áthelyezése esetén a hivatkozást frissíteni kell.

**Használhatok munkafüzeteket hálózati erőforrásokon/megosztott meghajtókon?**

Igen, ilyen munkafüzetek használhatók külső adatforrásként. Azonban a távoli munkafüzetek közvetlen szerkesztése az Aspose.Slides‑ból nem támogatott – csak forrásként használhatók.

**Az Aspose.Slides felülírja‑e a külső XLSX‑et a prezentáció mentésekor?**

A prezentáció egy [link to the external file](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) tárol. A cella‑alapú diagramadatok szerkesztése frissítheti a kapcsolt helyi XLSX fájlt is. Ha az eredetit változatlanul kell hagyni, használjon másolatot a munkafüzetről.

**Mi a teendő, ha a külső fájl jelszóval védett?**

Az Aspose.Slides nem fogad jelszót a kapcsolódáskor. Általános megoldás a védelem előzetes eltávolítása vagy egy dekódolt másolat előkészítése (például az [Aspose.Cells](https://reference.aspose.com/cells/cpp/) használatával), majd ennek a másolatnak a kapcsolása.

**Több diagram hivatkozhat ugyanarra a külső munkafüzetre?**

Igen. Minden diagram saját hivatkozást tárol. Ha mindegyik ugyanarra a fájlra mutat, a fájl frissítése minden diagramon megjelenik a következő adatbetöltéskor.