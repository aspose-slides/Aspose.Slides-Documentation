---
title: Gestire i workbook dei grafici nelle presentazioni con C++
linktitle: Workbook del grafico
type: docs
weight: 70
url: /it/cpp/chart-workbook/
keywords:
- workbook del grafico
- dati del grafico
- cella del workbook
- etichetta dati
- foglio di lavoro
- origine dati
- workbook esterno
- dati esterni
- cache del grafico
- recupero del workbook
- PowerPoint
- presentazione
- C++
- Aspose.Slides
description: "Scopri Aspose.Slides per C++: gestisci facilmente i workbook dei grafici nei formati PowerPoint e OpenDocument per semplificare i dati della tua presentazione."
---
## **Panoramica**

Questo articolo spiega come lavorare con i workbook dei grafici in Aspose.Slides. Mostra come leggere e scrivere i dati dei grafici tramite flussi di workbook, utilizzare le celle del workbook come etichette dei dati dei grafici, accedere alle collezioni di fogli di lavoro e specificare il tipo di origine dati per i valori del grafico.

Copre inoltre l’utilizzo di workbook esterni come origini dati per i grafici. Gli esempi dimostrano come creare e assegnare un workbook esterno, recuperare il percorso di un workbook esterno collegato a un grafico e modificare i dati del grafico quando il workbook è disponibile.

## **Leggere e Scrivere Dati del Grafico da un Workbook**

Aspose.Slides fornisce i metodi [ReadWorkbookStream](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) e [WriteWorkbookStream](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) che consentono di leggere e scrivere i workbook dei dati dei grafici (contenenti dati dei grafici modificati con Aspose.Cells). **Nota** che i dati del grafico devono essere organizzati nello stesso modo o avere una struttura simile a quella della sorgente.

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

Questo codice C++ dimostra l’operazione per impostare un workbook dei dati del grafico:

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

## **Impostare una Cella del Workbook come Etichetta Dati del Grafico**

1. Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Ottenere il riferimento a una diapositiva tramite il suo indice.
1. Aggiungere un grafico a bolle con alcuni dati.
1. Accedere alle serie del grafico.
1. Impostare la cella del workbook come etichetta dati.
1. Salvare la presentazione.

Questo codice C++ mostra come impostare una cella del workbook come etichetta dati del grafico:

``` cpp
System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// Istanzia una classe Presentation che rappresenta un file di presentazione 
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

## **Gestire i Fogli di Lavoro**

Questo codice C++ dimostra un’operazione in cui il metodo [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) viene utilizzato per accedere a una collezione di fogli di lavoro:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **Specificare il Tipo di Origine Dati**

Questo codice C++ mostra come specificare un tipo per un’origine dati:

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

## **Rilevare Formati di Workbook Incorporati Non Supportati**

Aspose.Slides non supporta il formato di workbook binario Excel (.xlsb) che può essere incorporato in alcuni grafici. È possibile utilizzare il metodo `get_EmbeddedWorkbookType` su [IChartData](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdata/) insieme all’enumerazione [WorkbookType](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/workbooktype/) per rilevare i formati non supportati e saltare quei grafici.

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
        // Il workbook incorporato è in formato .xlsb, che non è supportato.
        continue;
    }

    // Leggi o modifica i dati del workbook del grafico qui.
}
```

## **Workbook Esterno**

{{% alert color="primary" %}} 
In [Aspose.Slides](https://releases.aspose.com/slides/it/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4, abbiamo implementato il supporto per workbook esterni come origine dati per i grafici.
{{% /alert %}} 

### **Creare un Workbook Esterno**

Utilizzando i metodi **`ReadWorkbookStream`** e **`SetExternalWorkbook`**, è possibile creare un workbook esterno da zero o rendere esterno un workbook interno.

Questo codice C++ dimostra il processo di creazione del workbook esterno:

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

### **Impostare un Workbook Esterno**

Utilizzando il metodo **`IChartData::SetExternalWorkbook`**, è possibile assegnare un workbook esterno a un grafico come sua origine dati. Questo metodo può anche essere usato per aggiornare il percorso al workbook esterno (se quest’ultimo è stato spostato).

Pur non potendo modificare i dati in workbook memorizzati in posizioni remote o risorse, è comunque possibile usarli come origine dati esterna. Se viene fornito un percorso relativo per un workbook esterno, questo viene convertito automaticamente in un percorso assoluto.

Questo codice C++ mostra come impostare un workbook esterno:

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

Il parametro `updateChartData` (nel metodo `SetExternalWorkbook`) serve a specificare se il workbook Excel deve essere caricato o meno.

* Quando il valore di `updateChartData` è impostato su `false`, viene aggiornato solo il percorso del workbook — i dati del grafico non vengono caricati né aggiornati dal workbook di destinazione. Si può usare questa impostazione quando il workbook di destinazione è inesistente o non disponibile. 
* Quando il valore di `updateChartData` è impostato su `true`, i dati del grafico vengono aggiornati dal workbook di destinazione.

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **Ottenere il Percorso del Workbook di Origine Dati Esterno di un Grafico**

1. Creare un’istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
1. Ottenere il riferimento a una diapositiva tramite il suo indice.
1. Creare un oggetto per la forma del grafico.
1. Creare un oggetto per il tipo di origine (`ChartDataSourceType`) che rappresenta l’origine dati del grafico.
1. Specificare la condizione pertinente basata sul tipo di origine che corrisponde al tipo di origine dati del workbook esterno.

Questo codice C++ dimostra l’operazione:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto slide = pres->get_Slides()->idx_get(1);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
ChartDataSourceType sourceType = chart->get_ChartData()->get_DataSourceType();
if (sourceType == ChartDataSourceType::ExternalWorkbook)
{
    System::String path = chart->get_ChartData()->get_ExternalWorkbookPath();
}

// Salva la presentazione
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **Modificare i Dati del Grafico**

È possibile modificare i dati nei workbook esterni nello stesso modo in cui si modificano i contenuti dei workbook interni. Quando un workbook esterno non può essere caricato, viene generata un’eccezione.

Questo codice C++ è un’implementazione del processo descritto:

```c++
const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Recuperare un Workbook dalla Cache del Grafico**

Se un grafico utilizza un workbook esterno mancante o non disponibile, Aspose.Slides può ricostruire il workbook del grafico dai dati memorizzati nella presentazione. Creare un oggetto [LoadOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/), configurarlo con [set_SpreadsheetOptions](https://reference.aspose.com/slides/it/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), e chiamare [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/it/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) impostandolo su `true` prima di aprire la presentazione.

Il seguente esempio C++ apre una presentazione il cui grafico fa riferimento a un workbook esterno non disponibile e accede ai dati recuperati tramite [IChart::get_ChartData](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichart/get_chartdata/) e [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

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

Se il workbook esterno è non disponibile e il recupero è disabilitato, Aspose.Slides genera un’`System::InvalidOperationException`. Abilitare il recupero solo quando l’utilizzo dei dati del grafico in cache è una soluzione accettabile, poiché la cache potrebbe non contenere le modifiche apportate al workbook esterno dopo l’ultimo aggiornamento della presentazione.

## **FAQ**

**Posso determinare se un grafico specifico è collegato a un workbook esterno o incorporato?**

Sì. Un grafico ha un [tipo di origine dati](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) e un [percorso a un workbook esterno](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); se l’origine è un workbook esterno, è possibile leggere il percorso completo per verificare che venga utilizzato un file esterno.

**Sono supportati i percorsi relativi ai workbook esterni e come vengono memorizzati?**

Sì. Se si specifica un percorso relativo, questo viene automaticamente convertito in un percorso assoluto. È comodo per la portabilità del progetto; tuttavia, la presentazione memorizzerà il percorso assoluto nel file PPTX.

**Posso utilizzare workbook situati su risorse di rete/condivisioni?**

Sì, tali workbook possono essere usati come origine dati esterna. Tuttavia, la modifica diretta di workbook remoti da Aspose.Slides non è supportata — possono essere usati solo come sorgente.

**Aspose.Slides sovrascrive l’XLSX esterno quando salva la presentazione?**

No. La presentazione memorizza un [collegamento al file esterno](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) e lo utilizza per leggere i dati. Il file esterno stesso non viene modificato al salvataggio della presentazione.

** Cosa devo fare se il file esterno è protetto da password?**

Aspose.Slides non accetta una password al collegamento. Un approccio comune è rimuovere la protezione in anticipo o preparare una copia decrittata (ad esempio, usando [Aspose.Cells](/cells/cpp/)) e collegarsi a quella copia.

**Possono più grafici fare riferimento allo stesso workbook esterno?**

Sì. Ogni grafico memorizza il proprio collegamento. Se tutti puntano allo stesso file, la modifica di quel file verrà riflessa in ogni grafico al successivo caricamento dei dati.