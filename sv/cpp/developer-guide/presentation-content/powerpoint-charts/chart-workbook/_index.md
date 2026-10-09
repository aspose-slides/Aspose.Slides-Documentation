---
title: Hantera diagramarbetsböcker i presentationer med C++
linktitle: Diagramarbok
type: docs
weight: 70
url: /sv/cpp/chart-workbook/
keywords:
- diagramarbok
- diagramdata
- arbetsboks­cell
- datamärkning
- arbetsblad
- datakälla
- extern arbetsbok
- extern data
- diagramcache
- återställning av arbetsbok
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Upptäck Aspose.Slides för C++: hantera enkelt diagramarbok i PowerPoint- och OpenDocument-format för att förenkla dina presentationsdata."
---
## **Översikt**

Den här artikeln förklarar hur man arbetar med diagramarbetsböcker i Aspose.Slides. Den visar hur man läser och skriver diagramdata via arbetsbokströmmar, använder arbetsboks­celler som diagramdatamärken, får åtkomst till arbetsbladssamlingar och anger datakälltyp för diagramvärden.

Den täcker också arbete med externa arbetsböcker som diagramdatakällor. Exemplen demonstrerar hur man skapar och tilldelar en extern arbetsbok, hämtar sökvägen till en extern arbetsbok som är länkad till ett diagram och redigerar diagramdata när arbetsboken är tillgänglig. Se [Styr hur tomma celler visas](/slides/sv/cpp/chart-series/) för skillnaden mellan en tom cell och noll, samt en linjediagramsjämförelse av de tillgängliga visningslägena.

## **Inkludera data från dolda rader och kolumner**

Använd [IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) för att styra om ett diagram ritar data från dolda arbetsbladsrader och -kolumner. Ställ in det på `true` för att endast rita synliga celler, eller `false` för att inkludera både synliga och dolda celler. Denna inställning påverkar diagramritning; den döljer eller visar inte arbetsbladsrader eller -kolumner.

Den [exempelpresentation](hidden-source-data.pptx) innehåller ett stapeldiagram som den första formen på den första bilden. Det inbäddade arbetsbladet, `Sheet1`, innehåller följande källintervall, `A1:C4`. Rad 3 och kolumn C är dolda, men deras celler innehåller fortfarande värden.

| Arbetsbladsrad | A: Månad | B: Detaljhandel | C: Partihandel (dold kolumn) |
| --- | --- | --- | --- |
| 2 | januari | 10 | 30 |
| 3 (dold rad) | februari | 40 | 60 |
| 4 | mars | 20 | 50 |

Få åtkomst till källceller genom [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) och läs [IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/) för att undersöka deras dolda status. Denna egenskap är skrivskyddad. I detta exempel är B2 synlig, B3 tillhör den dolda raden och C2 tillhör den dolda kolumnen; exemplet skriver ut `False`, `True` och `True`.

För detta exempel, uppdatera diagramdata efter att plottningsinställningen har ändrats: behåll den inbäddade arbetsboken med [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) och läs in den igen med [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/). När alla celler inkluderas, använd även [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) för att återställa hela intervallet, inklusive den dolda februari‑kategorin. Att bara ändra flaggan är otillräckligt för att uppdatera detta exempels cachade diagramdata och kategorimärkningar.

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

        // Uppdatera diagramdata från den inbäddade arbetsboken.
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Återställ hela källintervallet, inklusive dolda kategorier.
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

Exemplet sparar två versioner av presentationen: en med endast de synliga detaljhandelsvärdena (10 och 20) och en annan med alla sex värden. Bilderna nedanför illustrerar de två plottningslägena. Rad 3 och kolumn C förblir dolda i båda inbäddade arbetsböckerna.

| Endast synliga celler (`true`) | Alla celler (`false`) |
| --- | --- |
| ![Endast synliga celler: Detaljhandelsvärden 10 och 20 för januari och mars.](hidden_cells_True.png) | ![Alla celler: Detaljhandels- och partihandelsvärden för januari, februari och mars.](hidden_cells_False.png) |

En dold cell som innehåller ett värde skiljer sig från en tom cell. [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) styr hur saknade värden visas; den inkluderar eller exkluderar inte dold källdata. Se [Styr hur tomma celler visas](/slides/sv/cpp/chart-series/#control-the-display-of-empty-cells) för ett exempel.

## **Hämta diagrammets dataintervall**

Innan du uppdaterar arbetsboksdata i en befintlig presentation, inspektera källintervallen för att identifiera vilka arbetsbladceller varje diagram använder. Metoden [IChartData::GetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/getrange/) returnerar det aktuella dataintervallet som en arbetsblads‑kvalificerad formel, t.ex. `Sheet1!$A$1:$D$5`. Här är `Sheet1` arbetsbladets namn, `!` separerar det från cellintervallet, och `$A$1:$D$5` identifierar cellerna A1 till D5, inklusive. Dollartecknen indikerar absoluta rad‑ och kolumnreferenser.

Metoden läser det aktuella intervallet utan att ändra diagrammet eller dess arbetsbok. Om diagrammet inte använder en arbetsbok som datakälla, kastar det [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/). För mer information, se [ChartData API‑referensen](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/).

Detta exempel öppnar en presentation och kontrollerar formerna direkt på varje bild för diagram. Det skriver ut varje diagramnamn och källintervall. Om ett diagram inte använder en arbetsbok, skriver det ett meddelande och fortsätter till nästa diagram.

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

## **Läsa och skriva diagramdata från en arbetsbok**

Aspose.Slides för C++ tillhandahåller metoderna [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) och [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) som låter dig läsa och skriva diagramarbetsböcker (innehåller diagramdata redigerad med Aspose.Cells). **Obs** att diagramdata måste vara organiserad på samma sätt eller ha en struktur som liknar källan.

Detta exempel använder en presentation med ett diagram som den första formen på den första bilden. Det läser den inbäddade arbetsboken till en ström, rensar befintliga serier och kategorier, och skriver tillbaka samma arbetsbok. Ändringarna finns kvar i minnet; exemplet sparar inte presentationen.

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

### **Validera diagramlayout efter arbetsboksändring**

När du ersätter en inbäddad arbetsbok med en modifierad, behåller diagrammet sina ursprungliga serie‑ och kategori‑samlingar. Denna mismatch kan orsaka att [IChart::ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/validatechartlayout/) misslyckas med ett index‑out‑of‑range‑fel. Rensa de befintliga serierna och kategorierna innan du skriver den uppdaterade arbetsboken tillbaka till diagrammet. Detta exempel använder ett diagram som är den första formen på den första bilden. Kommentaren markerar var arbetsboksredigering skulle ske; det körbara exemplet skriver tillbaka den ursprungliga arbetsboken och validerar layouten i minnet.

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

    // Ändra arbetsboksströmmen här, till exempel med Aspose.Cells.

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

Att tömma samlingarna tar bort föråldrade datreferenser innan arbetsboken skrivs tillbaka. Återskapa eventuella nödvändiga serie‑ och kategorikopplingar för den uppdaterade arbetsboken innan du använder diagrammet.

## **Ange en arbetsbokscell som diagramdatamärkning**

Du kan använda text från arbetsboksceller som diagramdatamärkningar.

Detta exempel lägger till ett bubbeldiagram med standarddata på den första bilden i en befintlig presentation. Det använder cellerna A10:A12 på arbetsblad 0 för de tre första etiketterna i den första serien, aktiverar etiketter från celler och sparar den uppdaterade presentationen.

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

## **Hantera arbetsblad**

Metoden [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) ger åtkomst till arbetsbladen i en diagramarbetsbok. Detta exempel skapar ett cirkeldiagram med standarddata och skriver ut varje arbetsblads namn till konsolen.

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

## **Ange datakälltyp**

Detta exempel skapar ett 3D-stapeldiagram med standarddata och anger två serienamn med olika datakällor. Det första namnet använder en strängliteral; det andra använder cell C1 på arbetsblad 0. Enumerationen [DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) väljer källan för varje namn. Exemplet sparar presentationen med de uppdaterade serienamnen.

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

## **Upptäck ej stödjade inbäddade arbetsboksformat**

Aspose.Slides stödjer inte Excel‑binärarbetsboken (.xlsb) som kan vara inbäddad i vissa diagram. Du kan använda metoden [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) på [IChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/) tillsammans med enumerationen [WorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/workbooktype/) för att upptäcka ej stödjade format och hoppa över dessa diagram. Detta exempel undersöker formerna på den första bilden i en befintlig presentation, hoppar över icke‑diagramformer och skriver ut ett diagnostiskt meddelande för varje diagram med en inbäddad .xlsb‑arbetsbok.

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

    // Läs eller ändra stödd diagramarboksdata här.
}
```

## **Extern arbetsbok**

Aspose.Slides stödjer att använda externa arbetsböcker som datakälla för diagram.

### **Skapa en extern arbetsbok**

Använd [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) och [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) för att exportera en inbäddad diagramarbetsbok till en fil och länka diagrammet till den externa arbetsboken.

Detta exempel skapar ett cirkeldiagram med standarddata och exporterar dess arbetsbok. Det stänger utmatningsströmmen innan den externa arbetsboken tilldelas som diagrammets datakälla, och sparar sedan den länkade presentationen.

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

### **Tilldela en extern arbetsbok**

Genom att använda metoden [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) kan du tilldela en extern arbetsbok till ett diagram som dess datakälla. Metoden kan också användas för att uppdatera sökvägen till den externa arbetsboken (om den senare har flyttats).

Även om du inte kan redigera data i arbetsböcker som lagras på fjärrplatser eller resurser, kan du ändå använda sådana arbetsböcker som extern datakälla. Om en relativ sökväg för en extern arbetsbok anges, konverteras den automatiskt till en fullständig sökväg.

Detta exempel använder en extern arbetsbok vars arbetsblad `Sheet1` innehåller ett serienamn i B1, kategorinamn i A2:A4 och numeriska värden i B2:B4. Exemplet skapar ett cirkeldiagram, länkar arbetsboken och använder [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) för att mappa A1:B4 till en serie och tre kategorier. Det sparar presentationen med det länkade diagrammet.

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

`updateChartData`‑parameteren för [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) styr om arbetsboken laddas.

* När `updateChartData` är `false` uppdateras bara arbetsbokens sökväg. Diagramdata laddas inte eller uppdateras från målarbetsboken, så arbetsboken kan vara otillgänglig.
* När `updateChartData` är `true` uppdateras diagramdata från målarbetsboken.

Följande exempel tilldelar en platshållar‑URL med `updateChartData` satt till `false`. Det behåller cirkeldiagrammets standarddata och sparar presentationen utan att ladda den otillgängliga arbetsboken.

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

### **Hämta den externa datakällans arbetsboksökväg för ett diagram**

För att identifiera arbetsboken som är länkad till ett diagram, kontrollera om diagrammet använder en extern datakälla och hämta dess arbetsboksökväg.

Detta exempel undersöker den första formen på den första bilden i en presentation med en länkad extern arbetsbok. Om den är ett diagram länkat till en extern arbetsbok, skriver exemplet ut [get_ExternalWorkbookPath](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) till konsolen. Det sparar sedan en kopia av presentationen.

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

### **Redigera diagramdata**

Du kan redigera data i externa arbetsböcker på samma sätt som du gör ändringar i innehållet i interna arbetsböcker. När en extern arbetsbok inte kan laddas kastas ett undantag.

Detta exempel använder ett diagram som är den första formen på den första bilden och är länkat till en åtkomlig extern arbetsbok. Det sätter det cellbaserade värdet för den första datapunkten i den första serien till 100 och sparar den uppdaterade presentationen. Att redigera cellvärden kan uppdatera den länkade externa XLSX‑filen, så använd en kopia om du behöver bevara originalarbetsboken.

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

### **Återskapa en arbetsbok från diagramcachen**

Om ett diagram använder en extern arbetsbok som saknas eller är otillgänglig, kan Aspose.Slides rekonstruera diagramarbetsboken från de data som cachas i presentationen. Skapa [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/), konfigurera den med [set_SpreadsheetOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), och anropa [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) med `true` innan presentationen öppnas.

Följande C++‑exempel återställer arbetsboksdata för ett diagram som är den första formen på den första bilden och refererar en otillgänglig extern arbetsbok. Det får åtkomst till den återställda datan via [IChart::get_ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_chartdata/) och [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

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

    // Läs eller ändra den återställda arbetsboksdatan här.
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

Om den externa arbetsboken är otillgänglig och återställning är inaktiverad, kastar Aspose.Slides ett [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/). Aktivera återställning endast när användning av den cachade diagramdatan är ett acceptabelt alternativ, eftersom cachen kanske inte innehåller ändringar som gjorts i den externa arbetsboken efter att presentationen senast uppdaterades.

## **FAQ**

**Kan jag avgöra om ett specifikt diagram är länkat till en extern eller en inbäddad arbetsbok?**

Ja. Ett diagram har en [datakälltyp](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) och en [sökväg till en extern arbetsbok](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); om källan är en extern arbetsbok kan du läsa den fullständiga sökvägen för att säkerställa att en extern fil används.

**Stöds relativa sökvägar till externa arbetsböcker, och hur lagras de?**

Ja. Om du anger en relativ sökväg konverteras den automatiskt till en absolut sökväg. Presentationen lagrar den absoluta sökvägen i PPTX‑filen, så om arbetsboken flyttas kan länken behöva uppdateras.

**Kan jag använda arbetsböcker som finns på nätverksresurser/Delade enheter?**

Ja, sådana arbetsböcker kan användas som en extern datakälla. Att redigera fjärrarbetsböcker direkt från Aspose.Slides stöds dock inte – de kan endast användas som källa.

**Skriver Aspose.Slides över den externa XLSX‑filen när presentationen sparas?**

Presentationen lagrar en [länk till den externa filen](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). Att redigera cellbaserad diagramdata kan också uppdatera den länkade lokala XLSX‑filen. Använd en kopia av arbetsboken om originalet måste förbli oförändrat.

**Vad ska jag göra om den externa filen är lösenordsskyddad?**

Aspose.Slides accepterar inte ett lösenord vid länkning. Ett vanligt tillvägagångssätt är att ta bort skyddet i förväg eller skapa en dekrypterad kopia (t.ex. med [Aspose.Cells](https://reference.aspose.com/cells/cpp/)) och länka till den kopian.

**Kan flera diagram referera till samma externa arbetsbok?**

Ja. Varje diagram lagrar sin egen länk. Om de alla pekar på samma fil kommer en uppdatering av filen att återspeglas i varje diagram nästa gång data laddas.