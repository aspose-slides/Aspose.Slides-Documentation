---
title: Beheer diagramwerkboeken in presentaties met C++
linktitle: Diagramwerkboek
type: docs
weight: 70
url: /nl/cpp/chart-workbook/
keywords:
- diagramwerkboek
- diagramgegevens
- werkboekcel
- gegevenslabel
- werkblad
- gegevensbron
- extern werkboek
- externe gegevens
- diagramcache
- werkboekherstel
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Ontdek Aspose.Slides voor C++: beheer eenvoudig diagramwerkboeken in PowerPoint- en OpenDocument-formaten om uw presentatiedata te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u met diagramwerkboeken in Aspose.Slides werkt. Het laat zien hoe u diagramgegevens kunt lezen en schrijven via werkboek‑streams, werkboekcellen kunt gebruiken als diagramgegevens‑labels, toegang krijgt tot werkbladcollecties, en het gegevenstype voor diagramwaarden kunt opgeven.

Het behandelt ook het werken met externe werkboeken als diagramgegevensbronnen. De voorbeelden tonen hoe u een extern werkboek maakt en toewijst, het pad van een extern werkboek dat aan een diagram is gekoppeld opvraagt, en diagramgegevens bewerkt wanneer het werkboek beschikbaar is.

Voor werkboekcellen die ontbrekende gegevens vertegenwoordigen, zie [Control the Display of Empty Cells](/slides/nl/cpp/chart-series/) voor het verschil tussen een lege cel en nul, en een lijndiagram‑vergelijking van de beschikbare weergavemodi.

## **Gegevens van verborgen rijen en kolommen opnemen**

Gebruik [IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) om te bepalen of een diagram gegevens plot uit verborgen werkbladrijen en -kolommen. Stel in op `true` om alleen zichtbare cellen te plotten, of op `false` om zowel zichtbare als verborgen cellen op te nemen. Deze instelling beïnvloedt alleen het plotten van het diagram; hij verbergt of maakt werkbladrijen of -kolommen niet zichtbaar of onzichtbaar.

Download [hidden-source-data.pptx](hidden-source-data.pptx) en plaats het in de werkmap. De eerste dia bevat een kolomdiagram als eerste vorm. Het ingebedde werkblad, `Sheet1`, bevat het volgende bronbereik, `A1:C4`. Rij 3 en kolom C zijn verborgen, maar hun cellen bevatten nog steeds waarden.

| Werkbladrij | A: Maand | B: Detailhandel | C: Groothandel (verborgen kolom) |
| --- | --- | --- | --- |
| 2 | januari | 10 | 30 |
| 3 (verborgen rij) | februari | 40 | 60 |
| 4 | maart | 20 | 50 |

Toegang tot broncellen via [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) en lees [IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/) om hun verborgen status te inspecteren. Deze eigenschap is alleen-lezen. In dit bestand is B2 zichtbaar, B3 behoort tot de verborgen rij, en C2 tot de verborgen kolom; het voorbeeld drukt respectievelijk `False`, `True` en `True` af.

Voor dit voorbeeld ververst u de diagramgegevens na het wijzigen van de plotinstelling: behoud het ingebedde werkboek met [ReadWorkbookStream](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) en laad het opnieuw met [WriteWorkbookStream](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/). Wanneer u alle cellen opneemt, gebruik dan ook [SetRange](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdata/setrange/) om het volledige bereik te herstellen, inclusief de verborgen februari‑categorie. Alleen de vlag wijzigen is onvoldoende om de in het voorbeeld gecachede diagramgegevens en categorielabels te verversen.

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

        // Ververs de diagramgegevens van het ingevoegde werkboek.
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Herstel het volledige bronbereik, inclusief verborgen categorieën.
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

Het voorbeeld slaat `hidden_cells_True.pptx` op met alleen de zichtbare detailhandelswaarden (10 en 20), en `hidden_cells_False.pptx` met alle zes waarden. De afbeeldingen hieronder illustreren de twee plotmodi. Rij 3 en kolom C blijven verborgen in beide ingebedde werkboeken.

| Alleen zichtbare cellen (`true`) | Alle cellen (`false`) |
| --- | --- |
| ![Alleen zichtbare cellen: detailhandelswaarden 10 en 20 voor januari en maart.](hidden_cells_True.png) | ![Alle cellen: detailhandels- en groothandelswaarden voor januari, februari en maart.](hidden_cells_False.png) |

Een verborgen cel met een waarde verschilt van een lege cel. [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichart/get_displayblanksas/) bepaalt hoe ontbrekende waarden worden weergegeven; hij omvat of sluit geen verborgen brongegevens uit. Zie [Control the Display of Empty Cells](/slides/nl/cpp/chart-series/#control-the-display-of-empty-cells) voor een voorbeeld.

## **Diagramgegevens lezen en schrijven vanuit een werkboek**

Aspose.Slides for C++ biedt de methoden [ReadWorkbookStream](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) en [WriteWorkbookStream](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) waarmee u diagramwerkboeken (bevatten diagramgegevens bewerkt met Aspose.Cells) kunt lezen en schrijven. **Opmerking**: de diagramgegevens moeten op dezelfde manier zijn georganiseerd of een structuur hebben die vergelijkbaar is met de bron.

Dit voorbeeld opent `chart.pptx`, dat een diagram moet bevatten als eerste vorm op de eerste dia. Het leest het ingebedde werkboek in een stream, wist de bestaande reeksen en categorieën, en schrijft hetzelfde werkboek terug. De wijzigingen blijven in het geheugen; het voorbeeld slaat de presentatie niet op.

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

### **Diagramindeling valideren na wijziging van werkboek**

Wanneer u een ingebed werkboek vervangt door een aangepast werkboek, behoudt het diagram zijn oorspronkelijke reeks‑ en categoricollecties. Deze mismatch kan ervoor zorgen dat [IChart::ValidateChartLayout](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichart/validatechartlayout/) faalt met een index‑out‑of‑range‑fout. Wis de bestaande reeksen en categorieën voordat u het bijgewerkte werkboek terugschrijft naar het diagram. Dit voorbeeld vereist `chart.pptx` met een diagram als eerste vorm op de eerste dia. Het commentaar markeert waar bewerking van het werkboek zou plaatsvinden; het uitvoerbare voorbeeld schrijft het originele werkboek terug en valideert de indeling in het geheugen.

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

    // Wijzig de werkboekstream hier, bijvoorbeeld met Aspose.Cells.

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

Het wissen van de collecties verwijdert verouderde gegevensverwijzingen voordat het werkboek wordt weggeschreven. Bouw eventuele benodigde reeks‑ en categorietoewijzingen opnieuw op voor het bijgewerkte werkboek voordat u het diagram gebruikt.

## **Een werkboekcel instellen als diagramgegevens‑label**

U kunt tekst uit werkboekcellen gebruiken als diagramgegevens‑labels. De volgende stappen tonen hoe u de labels in een bubbel‑diagram koppelt aan cellen in het bijbehorende werkboek.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
2. Toegang tot de eerste dia via de nul‑gebaseerde index.
3. Voeg een bubbel‑diagram toe met standaardgegevens.
4. Toegang tot de diagramreeksen.
5. Stel de werkboekcel in als gegevenslabel.
6. Sla de presentatie op.

Dit voorbeeld opent `chart2.pptx`, dat minstens één dia moet bevatten, en voegt een bubbel‑diagram met standaardgegevens toe. Het gebruikt cellen A10:A12 op werkblad 0 voor de eerste drie labels in de eerste reeks, schakelt labels uit cellen in, en slaat het resultaat op in `resultchart.pptx`.

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

## **Werkbladen beheren**

De methode [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) biedt toegang tot de werkbladen in een diagramwerkboek. Dit voorbeeld maakt een taart‑diagram met standaardgegevens en drukt elke werkbladnaam af naar de console.

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

## **Gegevenstype van bron opgeven**

Dit voorbeeld maakt een 3D‑kolomdiagram met standaardgegevens en stelt twee reeksnamen in met verschillende gegevensbronnen. De eerste naam gebruikt een tekenreeks‑literal; de tweede gebruikt cel C1 op werkblad 0. De enumeratie [DataSourceType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/datasourcetype/) selecteert de bron voor elke naam. Het resultaat wordt opgeslagen in `pres.pptx`.

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

## **Detectie van niet‑ondersteunde ingebedde werkboekformaten**

Aspose.Slides ondersteunt het Excel‑binaire werkboekformaat (.xlsb) niet wanneer dit in sommige diagrammen is ingebed. U kunt de methode [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) op [IChartData](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdata/) gebruiken in combinatie met de enumeratie [WorkbookType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/workbooktype/) om niet‑ondersteunde formaten te detecteren en die diagrammen over te slaan. Dit voorbeeld inspecteert de vormen op de eerste dia van `sample.pptx`, slaat niet‑diagram‑vormen over, en drukt een diagnostisch bericht af voor elk diagram met een ingebed .xlsb‑werkboek.

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

    // Lees of wijzig ondersteunde diagramwerkboekgegevens hier.
}
```

## **Extern werkboek**

Aspose.Slides ondersteunt het gebruik van externe werkboeken als gegevensbron voor diagrammen.

### **Een extern werkboek maken**

Gebruik [ReadWorkbookStream](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) en [SetExternalWorkbook](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) om een ingebed diagramwerkboek naar een bestand te exporteren en het diagram aan dat externe werkboek te koppelen.

Dit voorbeeld maakt een taart‑diagram met standaardgegevens, schrijft het werkboek naar `externalWorkbook1.xlsx`, en sluit de uitvoer‑stream voordat het bestand wordt toegewezen als gegevensbron van het diagram. Het slaat de gekoppelde presentatie op in `externalWorkbook.pptx`.

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

### **Een extern werkboek instellen**

Met de methode [SetExternalWorkbook](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) kunt u een extern werkboek toewijzen aan een diagram als gegevensbron. Deze methode kan ook worden gebruikt om het pad naar het externe werkboek bij te werken (als het bestand is verplaatst).

Hoewel u de gegevens in werkboeken die zich op externe locaties of bronnen bevinden niet kunt bewerken, kunt u die werkboeken wel als externe gegevensbron gebruiken. Als een relatief pad voor een extern werkboek wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

Dit voorbeeld vereist `externalWorkbook.xlsx` in de werkmap. Het werkblad met de naam `Sheet1` moet een reeksnaam bevatten in B1, categorienamen in A2:A4, en numerieke waarden in B2:B4. Het voorbeeld maakt een taart‑diagram, koppelt het werkboek, en gebruikt [SetRange](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdata/setrange/) om A1:B4 toe te wijzen aan één reeks en drie categorieën. Het slaat het resultaat op in `Presentation_with_externalWorkbook.pptx`.

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

De parameter `updateChartData` van [SetExternalWorkbook](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) bepaalt of het werkboek wordt geladen.

* Wanneer `updateChartData` `false` is, wordt alleen het werkboekpad bijgewerkt. De diagramgegevens worden niet geladen of bijgewerkt vanuit het doel‑werkboek, zodat het werkboek niet beschikbaar hoeft te zijn.
* Wanneer `updateChartData` `true` is, worden de diagramgegevens bijgewerkt vanuit het doel‑werkboek.

Het volgende voorbeeld wijst een tijdelijke URL toe met `updateChartData` ingesteld op `false`. Het behoudt de standaardgegevens van het taart‑diagram en slaat de presentatie op zonder het niet‑beschikbare werkboek te laden.

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

### **Het pad van de externe gegevensbron‑werkboek van een diagram ophalen**

Om het werkboek dat aan een diagram is gekoppeld te identificeren, controleert u eerst of het diagram een externe gegevensbron gebruikt. Als dat het geval is, kunt u het pad van het werkboek ophalen via de volgende stappen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
2. Toegang tot de eerste dia via de nul‑gebaseerde index.
3. Controleer of de eerste vorm een diagram is.
4. Lees het diagram‑gegevens‑brontype.
5. Als de bron een extern werkboek is, lees dan het pad.

Dit voorbeeld opent `externalWorkbook.pptx`, gemaakt in het eerdere voorbeeld, en inspecteert de eerste vorm op de eerste dia. Als het een diagram is dat gekoppeld is aan een extern werkboek, drukt het voorbeeld [get_ExternalWorkbookPath](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) af naar de console. Vervolgens slaat het een kopie van de presentatie op in `Result.pptx`.

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

### **Diagramgegevens bewerken**

U kunt de gegevens in externe werkboeken bewerken op dezelfde manier als u wijzigingen aanbrengt in interne werkboeken. Wanneer een extern werkboek niet kan worden geladen, wordt een uitzondering gegooid.

Dit voorbeeld vereist `presentation.pptx` met een diagram als eerste vorm op de eerste dia en een toegankelijk extern werkboek. Het stelt de cel‑gebackde waarde van het eerste gegevenspunt in de eerste reeks in op 100 en slaat de presentatie op in `presentation_out.pptx`. Het bewerken van celwaarden kan het gekoppelde externe XLSX‑bestand bijwerken, dus gebruik een kopie als u het originele werkboek moet behouden.

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

### **Een werkboek herstellen uit de diagram‑cache**

Als een diagram een extern werkboek gebruikt dat ontbreekt of niet beschikbaar is, kan Aspose.Slides het diagram‑werkboek reconstrueren uit de in de presentatie gecachte gegevens. Maak [LoadOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/) aan, configureer deze met [set_SpreadsheetOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), en roep [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) aan met `true` voordat u de presentatie opent.

Het volgende C++‑voorbeeld opent `presentation.pptx`, waarvan de eerste vorm op de eerste dia een diagram moet zijn dat verwijst naar een niet‑beschikbaar extern werkboek, en krijgt toegang tot de herstelde gegevens via [IChart::get_ChartData](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichart/get_chartdata/) en [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

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

    // Lees of wijzig de herstelde werkboekgegevens hier.
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

Als het externe werkboek niet beschikbaar is en herstel is uitgeschakeld, gooit Aspose.Slides een [System::InvalidOperationException](https://reference.aspose.com/slides/nl/cpp/system/details_invalidoperationexception/). Schakel herstel alleen in wanneer het gebruik van de gecachede diagramgegevens een aanvaardbare fallback is, omdat de cache mogelijk niet de wijzigingen bevat die in het externe werkboek zijn aangebracht na de laatste update van de presentatie.

## **FAQ**

**Kan ik bepalen of een specifiek diagram is gekoppeld aan een extern of een ingebed werkboek?**

Ja. Een diagram heeft een [data source type](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) en een [path to an external workbook](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); als de bron een extern werkboek is, kunt u het volledige pad lezen om te bevestigen dat een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkboeken ondersteund, en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. De presentatie slaat het absolute pad op in het PPTX‑bestand, dus het verplaatsen van het werkboek kan vereisen dat de koppeling wordt bijgewerkt.

**Kan ik werkboeken gebruiken die op netwerklocaties/gedeelde schijven staan?**

Ja, dergelijke werkboeken kunnen worden gebruikt als externe gegevensbron. Het rechtstreeks bewerken van externe werkboeken vanuit Aspose.Slides wordt echter niet ondersteund – ze kunnen alleen als bron worden gebruikt.

**Overschrijft Aspose.Slides het externe XLSX‑bestand bij het opslaan van de presentatie?**

De presentatie slaat een [link to the external file](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) op. Het bewerken van cel‑gebackte diagramgegevens kan ook het gekoppelde lokale XLSX‑bestand bijwerken. Gebruik een kopie van het werkboek als het origineel ongewijzigd moet blijven.

**Wat moet ik doen als het externe bestand met een wachtwoord beschermd is?**

Aspose.Slides accepteert geen wachtwoord bij het koppelen. Een gangbare aanpak is om de bescherming vooraf te verwijderen of een gedecodeerde kopie (bijvoorbeeld met [Aspose.Cells](https://reference.aspose.com/cells/cpp/)) te maken en die kopie te koppelen.

**Kunnen meerdere diagrammen naar hetzelfde externe werkboek verwijzen?**

Ja. Elk diagram slaat zijn eigen koppeling op. Als ze allemaal naar hetzelfde bestand wijzen, wordt een wijziging in dat bestand in elk diagram weerspiegeld de volgende keer dat de gegevens worden geladen.