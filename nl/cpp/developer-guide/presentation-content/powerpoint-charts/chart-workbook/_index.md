---
title: Beheer grafiek-werkboeken in presentaties met C++
linktitle: Grafiek werkboek
type: docs
weight: 70
url: /nl/cpp/chart-workbook/
keywords:
- grafiek werkboek
- grafiekgegevens
- werkboekcel
- gegevenslabel
- werkblad
- gegevensbron
- extern werkboek
- externe gegevens
- grafiekcache
- werkboekherstel
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Ontdek Aspose.Slides voor C++: beheer moeiteloos grafiek-werkboeken in PowerPoint- en OpenDocument-formaten om de gegevens in uw presentaties te stroomlijnen."
---
## **Overzicht**

Dit artikel legt uit hoe u kunt werken met grafiek‑werkboeken in Aspose.Slides. Het laat zien hoe u grafiekgegevens kunt lezen en schrijven via werkboek‑streams, werkboekcellen kunt gebruiken als gegevenslabels, toegang krijgt tot werkbladcollecties en het type gegevensbron kunt opgeven voor grafiekwaarden.

Ook wordt behandeld hoe u externe werkboeken als gegevensbron voor grafieken kunt gebruiken. De voorbeelden laten zien hoe u een extern werkboek maakt en toewijst, het pad van een extern werkboek dat aan een grafiek is gekoppeld opvraagt en grafiekgegevens bewerkt wanneer het werkboek beschikbaar is.

## **Grafiekgegevens lezen en schrijven vanuit een werkboek**

Aspose.Slides biedt de [ReadWorkbookStream](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) en [WriteWorkbookStream](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) methoden waarmee u grafiekgegevens‑werkboeken (die grafiekgegevens bevatten die met Aspose.Cells zijn bewerkt) kunt lezen en schrijven. **Opmerking** dat de grafiekgegevens op dezelfde manier moeten zijn gestructureerd of een structuur moeten hebben die vergelijkbaar is met de bron.

``` cpp
auto pres = System::MakeObject<Presentation>(u"chart.pptx");

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto data = chart->get_ChartData();

System::SharedPtr<System::IO::MemoryStream> stream = data->ReadWorkbookStream();
data->get_Series()->Clear();
data->get_Categories()->Clear();

stream->set_Position(0);
data->WriteWorkbookStream(stream);
```

Deze C++‑code toont de bewerking om een grafiekgegevens‑werkboek in te stellen:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(Charts::ChartType::Pie, 50.0f, 50.0f, 500.0f, 400.0f);
chart->get_ChartData()->get_ChartDataWorkbook()->Clear(0);

intrusive_ptr<Aspose::Cells::IWorkbook> workbook;
try
{
    workbook = Aspose::Cells::Factory::CreateIWorkbook(new String("a1.xlsx"));
}
catch (Aspose::Cells::Systems::Exception& ex)
{
    System::Console::Write(System::String::FromWCS(ex.GetMessageExp()->value()));
}

intrusive_ptr<MemoryStream> cellsOutputStream = new Aspose::Cells::Systems::IO::MemoryStream();
workbook->Save(cellsOutputStream, Aspose::Cells::SaveFormat_Xlsx);

cellsOutputStream->SetPosition(0);
System::SharedPtr<System::IO::MemoryStream> msout = ToSlidesMemoryStream(cellsOutputStream);

chart->get_ChartData()->WriteWorkbookStream(msout);

chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$B$9");
auto series = chart->get_ChartData()->get_Series()->idx_get(0);
series->get_ParentSeriesGroup()->set_IsColorVaried(true);
pres->Save(u"response2.pptx", Export::SaveFormat::Pptx);
```

## **Een werkboekcel instellen als een grafiek‑gegevenslabel**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie naar een dia via de index.
3. Voeg een bubble‑grafiek toe met wat gegevens.
4. Toegang tot de grafiekseries.
5. Stel de werkboekcel in als gegevenslabel.
6. Sla de presentatie op.

Deze C++‑code laat zien hoe u een werkboekcel als grafiek‑gegevenslabel instelt:

``` cpp
System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// Instantieert een Presentation-klasse die een presentatie-bestand vertegenwoordigt 
auto pres = System::MakeObject<Presentation>(u"chart2.pptx");

auto slide = pres->get_Slides()->idx_get(0);

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Bubble, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto series = chart->get_ChartData()->get_Series();

series->idx_get(0)->get_Labels()->get_DefaultDataLabelFormat()->set_ShowLabelValueFromCell(true);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

series->idx_get(0)->get_Labels()->idx_get(0)->set_ValueFromCell(wb->GetCell(0, u"A10", System::ObjectExt::Box<System::String>(lbl0)));
series->idx_get(0)->get_Labels()->idx_get(1)->set_ValueFromCell(wb->GetCell(0, u"A11", System::ObjectExt::Box<System::String>(lbl1)));
series->idx_get(0)->get_Labels()->idx_get(2)->set_ValueFromCell(wb->GetCell(0, u"A12", System::ObjectExt::Box<System::String>(lbl2)));

pres->Save(u"resultchart.pptx", SaveFormat::Pptx);
```

## **Werkbladen beheren**

Deze C++‑code toont een bewerking waarbij de [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) methode wordt gebruikt om toegang te krijgen tot een werkbladcollectie:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **Het type gegevensbron opgeven**

Deze C++‑code laat zien hoe u een type voor een gegevensbron specificeert:

```c++
auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto chartData = chart->get_ChartData();
auto val = chart->get_ChartData()->get_Series()->idx_get(0)->get_Name();

val->set_DataSourceType(DataSourceType::StringLiterals);
val->set_Data(System::ObjectExt::Box<System::String>(u"LiteralString"));
val = chartData->get_Series()->idx_get(1)->get_Name();
val->set_Data(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1", System::ObjectExt::Box<System::String>(u"NewCell")));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **Detecteren van niet‑ondersteunde ingesloten werkboekformaten**

Aspose.Slides ondersteunt het Excel‑binaire werkboekformaat (.xlsb) dat in sommige grafieken kan worden ingesloten niet. U kunt de `get_EmbeddedWorkbookType`‑methode op [IChartData](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdata/) samen met de [WorkbookType](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/workbooktype/)‑enumeratie gebruiken om niet‑ondersteunde formaten te detecteren en die grafieken over te slaan.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : slide->get_Shapes())
{
    if (!System::ObjectExt::Is<IChart>(shape))
    {
        continue;
    }

    auto chart = System::ExplicitCast<IChart>(shape);
    auto chartData = chart->get_ChartData();

    if (chartData->get_DataSourceType() == ChartDataSourceType::InternalWorkbook &&
        chartData->get_EmbeddedWorkbookType() == WorkbookType::WorkbookBinaryMacro)
    {
        // Ingesloten werkboek is in .xlsb-formaat, wat niet wordt ondersteund.
        continue;
    }

    // Lees of wijzig hier de grafiek-werkboekgegevens.
}
```

## **Extern werkboek**

{{% alert color="primary" %}} 
In [Aspose.Slides](https://releases.aspose.com/slides/nl/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4 hebben we ondersteuning voor externe werkboeken als gegevensbron voor grafieken geïmplementeerd.
{{% /alert %}} 

### **Een extern werkboek maken**

Met behulp van de **`ReadWorkbookStream`**‑ en **`SetExternalWorkbook`**‑methoden kunt u ofwel een extern werkboek vanaf nul maken of een intern werkboek extern maken.

Deze C++‑code toont het proces voor het maken van een extern werkboek:

```c++
auto pres = System::MakeObject<Presentation>();

const System::String workbookPath = u"externalWorkbook1.xlsx";

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f);
auto chartData = chart->get_ChartData();

{
    System::SharedPtr<System::IO::FileStream> fileStream = System::MakeObject<System::IO::FileStream>(workbookPath, System::IO::FileMode::Create);

    System::ArrayPtr<uint8_t> workbookData = chartData->ReadWorkbookStream()->ToArray();
    fileStream->Write(workbookData, 0, workbookData->get_Length());
}

chartData->SetExternalWorkbook(System::IO::Path::GetFullPath(workbookPath));

pres->Save(u"externalWorkbook.pptx", SaveFormat::Pptx);
```

### **Een extern werkboek instellen**

Met de **`IChartData::SetExternalWorkbook`**‑methode kunt u een extern werkboek aan een grafiek toewijzen als gegevensbron. Deze methode kan ook worden gebruikt om een pad naar het externe werkboek bij te werken (als het werkboek is verplaatst).

Hoewel u de gegevens in werkboeken die op externe locaties of bronnen zijn opgeslagen niet kunt bewerken, kunt u dergelijke werkboeken nog steeds als externe gegevensbron gebruiken. Als een relatief pad voor een extern werkboek wordt opgegeven, wordt dit automatisch omgezet naar een volledig pad.

Deze C++‑code laat zien hoe u een extern werkboek instelt:

```c++
auto pres = System::MakeObject<Presentation>();

auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, false);
auto chartData = chart->get_ChartData();

chartData->SetExternalWorkbook(System::IO::Path::GetFullPath(u"externalWorkbook.xlsx"));

chartData->get_Series()->Add(chartData->get_ChartDataWorkbook()->GetCell(0, u"B1"), ChartType::Pie);
auto dataPoints = chartData->get_Series()->idx_get(0)->get_DataPoints();
auto workbook = chartData->get_ChartDataWorkbook();
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B2"));
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B3"));
dataPoints->AddDataPointForPieSeries(workbook->GetCell(0, u"B4"));

auto categories = chartData->get_Categories();
categories->Add(workbook->GetCell(0, u"A2"));
categories->Add(workbook->GetCell(0, u"A3"));
categories->Add(workbook->GetCell(0, u"A4"));
pres->Save(u"Presentation_with_externalWorkbook.pptx", SaveFormat::Pptx);
```

De `updateChartData`‑parameter (onder de `SetExternalWorkbook`‑methode) wordt gebruikt om op te geven of een Excel‑werkboek wel of niet wordt geladen.

* Wanneer `updateChartData` de waarde `false` krijgt, wordt alleen het werkboekpad bijgewerkt — de grafiekgegevens worden niet geladen of bijgewerkt vanuit het doel‑werkboek. Deze instelling is handig wanneer het doel‑werkboek niet bestaat of niet beschikbaar is.  
* Wanneer `updateChartData` de waarde `true` krijgt, worden de grafiekgegevens bijgewerkt vanuit het doel‑werkboek.

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **Het pad van de externe gegevensbron‑werkboek van een grafiek ophalen**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie naar een dia via de index.
3. Maak een object voor de grafiekvorm.
4. Maak een object voor het bron‑type (`ChartDataSourceType`) dat de gegevensbron van de grafiek representeert.
5. Specificeer de relevante voorwaarde op basis van het bron‑type dat gelijk is aan het externe werkboek‑gegevensbrontype.

Deze C++‑code toont de bewerking:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto slide = pres->get_Slides()->idx_get(1);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
ChartDataSourceType sourceType = chart->get_ChartData()->get_DataSourceType();
if (sourceType == ChartDataSourceType::ExternalWorkbook)
{
    System::String path = chart->get_ChartData()->get_ExternalWorkbookPath();
}

// Slaat de presentatie op
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **Grafiekgegevens bewerken**

U kunt de gegevens in externe werkboeken op dezelfde manier bewerken als u wijzigingen aanbrengt in interne werkboeken. Wanneer een extern werkboek niet kan worden geladen, wordt er een uitzondering gegooid.

Deze C++‑code implementeert het beschreven proces:

```c++
const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Een werkboek herstellen uit de grafiek‑cache**

Als een grafiek een extern werkboek gebruikt dat ontbreekt of niet beschikbaar is, kan Aspose.Slides het grafiek‑werkboek reconstrueren vanuit de in de presentatie gecachete gegevens. Maak [LoadOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/) aan, configureer deze met [set_SpreadsheetOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), en roep [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) aan met `true` voordat u de presentatie opent.

Het volgende C++‑voorbeeld opent een presentatie waarvan de grafiek een niet‑beschikbaar extern werkboek referereert en krijgt de herstelde gegevens via [IChart::get_ChartData](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichart/get_chartdata/) en [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

```cpp
auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto chart = System::ExplicitCast<IChart>(shape);

auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Read or modify the recovered workbook data here.

presentation->Dispose();
```

Als het externe werkboek niet beschikbaar is en herstel is uitgeschakeld, gooit Aspose.Slides een `System::InvalidOperationException`. Schakel herstel alleen in wanneer het gebruik van de gecachete grafiekgegevens een acceptabele fallback is, omdat de cache mogelijk geen wijzigingen bevat die na de laatste update van de presentatie in het externe werkboek zijn aangebracht.

## **FAQ**

**Kan ik bepalen of een specifieke grafiek gekoppeld is aan een extern of ingesloten werkboek?**

Ja. Een grafiek heeft een [data source type](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) en een [pad naar een extern werkboek](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); als de bron een extern werkboek is, kunt u het volledige pad lezen om zeker te weten dat een extern bestand wordt gebruikt.

**Worden relatieve paden naar externe werkboeken ondersteund en hoe worden ze opgeslagen?**

Ja. Als u een relatief pad opgeeft, wordt dit automatisch omgezet naar een absoluut pad. Dit is handig voor project‑portabiliteit; houd er echter rekening mee dat de presentatie het absolute pad opslaat in het PPTX‑bestand.

**Kan ik werkboeken gebruiken die zich op netwerkresources/‑shares bevinden?**

Ja, dergelijke werkboeken kunnen als externe gegevensbron worden gebruikt. Direct bewerken van externe werkboeken vanuit Aspose.Slides wordt echter niet ondersteund — ze kunnen alleen als bron dienen.

**Overschrijft Aspose.Slides het externe XLSX‑bestand bij het opslaan van de presentatie?**

Nee. De presentatie slaat een [link naar het externe bestand](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) op en gebruikt deze voor het lezen van gegevens. Het externe bestand zelf wordt niet gewijzigd bij het opslaan van de presentatie.

**Wat moet ik doen als het externe bestand met een wachtwoord beschermd is?**

Aspose.Slides accepteert geen wachtwoord bij het maken van een koppeling. Een gebruikelijke aanpak is om de bescherming vooraf te verwijderen of een ontcijferde kopie (bijvoorbeeld via [Aspose.Cells](/cells/cpp/)) voor te bereiden en naar die kopie te linken.

**Kunnen meerdere grafieken naar hetzelfde externe werkboek verwijzen?**

Ja. Elke grafiek slaat zijn eigen koppeling op. Als ze allemaal naar hetzelfde bestand wijzen, wordt een update van dat bestand in elke grafiek weerspiegeld de volgende keer dat de gegevens worden geladen.