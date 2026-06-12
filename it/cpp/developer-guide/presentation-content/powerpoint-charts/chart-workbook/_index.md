---
title: Gestire le cartelle di lavoro dei grafici nelle presentazioni con С++
linktitle: Cartella di lavoro del grafico
type: docs
weight: 70
url: /it/cpp/chart-workbook/
keywords:
- cartella di lavoro del grafico
- dati del grafico
- cella del workbook
- etichetta dati
- foglio di lavoro
- origine dati
- cartella di lavoro esterna
- dati esterni
- PowerPoint
- presentazione
- С++
- Aspose.Slides
description: "Scopri Aspose.Slides per С++: gestisci facilmente le cartelle di lavoro dei grafici in formato PowerPoint e OpenDocument per semplificare i dati della tua presentazione."
---
## **Panoramica**

Questo articolo spiega come lavorare con le cartelle di lavoro dei grafici in Aspose.Slides. Mostra come leggere e scrivere i dati del grafico tramite i flussi delle cartelle di lavoro, utilizzare le celle della cartella di lavoro come etichette dei dati del grafico, accedere alle raccolte di fogli di lavoro e specificare il tipo di origine dati per i valori del grafico.

Copre anche l'uso di cartelle di lavoro esterne come origini dati per i grafici. Gli esempi dimostrano come creare e assegnare una cartella di lavoro esterna, recuperare il percorso di una cartella di lavoro esterna collegata a un grafico e modificare i dati del grafico quando la cartella di lavoro è disponibile.

## **Leggere e Scrivere i Dati del Grafico da una Cartella di Lavoro**

Aspose.Slides fornisce i metodi [ReadWorkbookStream](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) e [WriteWorkbookStream](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) che consentono di leggere e scrivere le cartelle di lavoro dei dati del grafico (contenenti dati del grafico modificati con Aspose.Cells). **Nota** che i dati del grafico devono essere organizzati allo stesso modo o devono avere una struttura simile a quella della sorgente.

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

Questo codice C++ dimostra l'operazione per impostare una cartella di lavoro dei dati del grafico:

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

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Ottieni il riferimento a una diapositiva tramite il suo indice.
3. Aggiungi un grafico a bolle con alcuni dati.
4. Accedi alla serie del grafico.
5. Imposta la cella del workbook come etichetta dati.
6. Salva la presentazione.

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

Questo codice C++ dimostra un'operazione in cui il metodo [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) viene utilizzato per accedere a una raccolta di fogli di lavoro:

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

Questo codice C++ mostra come specificare un tipo per un'origine dati:

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

## **Rilevare Formati di Cartelle di Lavoro Incorporate Non Supportati**

Aspose.Slides non supporta il formato di cartella di lavoro binario di Excel (.xlsb) che può essere incorporato in alcuni grafici. È possibile utilizzare il metodo `get_EmbeddedWorkbookType` su [IChartData](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/ichartdata/) insieme all'enumerazione [WorkbookType](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/workbooktype/) per rilevare formati non supportati e ignorare quei grafici.

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
        // Il workbook incorporato è nel formato .xlsb, non supportato.
        continue;
    }

    // Leggi o modifica i dati del workbook del grafico qui.
}
```

## **Cartella di Lavoro Esterna**

{{% alert color="primary" %}} 
In [Aspose.Slides](https://releases.aspose.com/slides/it/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4, è stato implementato il supporto per le cartelle di lavoro esterne come origine dati per i grafici.
{{% /alert %}} 

### **Creare una Cartella di Lavoro Esterna**

Utilizzando i metodi **`ReadWorkbookStream`** e **`SetExternalWorkbook`**, è possibile creare una cartella di lavoro esterna da zero oppure rendere una cartella di lavoro interna esterna.

Questo codice C++ dimostra il processo di creazione della cartella di lavoro esterna:

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

### **Impostare una Cartella di Lavoro Esterna**

Utilizzando il metodo **`IChartData::SetExternalWorkbook`**, è possibile assegnare una cartella di lavoro esterna a un grafico come sua origine dati. Questo metodo può anche essere usato per aggiornare il percorso della cartella di lavoro esterna (se quest'ultima è stata spostata).

Sebbene non sia possibile modificare i dati nelle cartelle di lavoro archiviate in posizioni remote o risorse, è comunque possibile utilizzare tali cartelle di lavoro come origine dati esterna. Se viene fornito un percorso relativo per una cartella di lavoro esterna, questo viene convertito automaticamente in un percorso completo.

Questo codice C++ mostra come impostare una cartella di lavoro esterna:

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

Il parametro `updateChartData` (nel metodo `SetExternalWorkbook`) viene usato per specificare se una cartella di lavoro Excel verrà caricata o meno. 

* Quando il valore di `updateChartData` è impostato su `false`, viene aggiornato solo il percorso della cartella di lavoro - i dati del grafico non verranno caricati o aggiornati dalla cartella di lavoro di destinazione. È consigliabile usare questa impostazione quando la cartella di lavoro di destinazione è inesistente o non disponibile. 
* Quando il valore di `updateChartData` è impostato su `true`, i dati del grafico vengono aggiornati dalla cartella di lavoro di destinazione.

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

## **Ottenere il Percorso della Cartella di Lavoro Esterna di Origine Dati di un Grafico**

1. Crea un'istanza della classe [Presentation](https://reference.aspose.com/slides/it/cpp/aspose.slides/presentation/).
2. Ottieni il riferimento a una diapositiva tramite il suo indice.
3. Crea un oggetto per la forma del grafico.
4. Crea un oggetto per il tipo di origine (`ChartDataSourceType`) che rappresenta l'origine dati del grafico.
5. Specifica la condizione rilevante basata sul fatto che il tipo di origine sia lo stesso del tipo di origine dati della cartella di lavoro esterna.

Questo codice C++ dimostra l'operazione:

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

## **Modificare i Dati del Grafico**

È possibile modificare i dati nelle cartelle di lavoro esterne allo stesso modo in cui si apportano modifiche al contenuto delle cartelle di lavoro interne. Quando una cartella di lavoro esterna non può essere caricata, viene sollevata un'eccezione.

Questo codice C++ è un'implementazione del processo descritto:

```c++
const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **FAQ**

**Posso determinare se un determinato grafico è collegato a una cartella di lavoro esterna o incorporata?**

Sì. Un grafico ha un [tipo di origine dati](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) e un [percorso a una cartella di lavoro esterna](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); se l'origine è una cartella di lavoro esterna, è possibile leggere il percorso completo per verificare che venga utilizzato un file esterno.

**Sono supportati i percorsi relativi alle cartelle di lavoro esterne e come vengono memorizzati?**

Sì. Se si specifica un percorso relativo, questo viene automaticamente convertito in un percorso assoluto. È comodo per la portabilità del progetto; tuttavia, è necessario tenere presente che la presentazione memorizzerà il percorso assoluto nel file PPTX.

**Posso utilizzare cartelle di lavoro situate su risorse/condivisioni di rete?**

Sì, tali cartelle di lavoro possono essere usate come origine dati esterna. Tuttavia, la modifica delle cartelle di lavoro remote direttamente da Aspose.Slides non è supportata - possono essere utilizzate solo come origine.

**Aspose.Slides sovrascrive il file XLSX esterno durante il salvataggio della presentazione?**

No. La presentazione memorizza un [collegamento al file esterno](https://reference.aspose.com/slides/it/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) e lo utilizza per leggere i dati. Il file esterno stesso non viene modificato quando la presentazione viene salvata.

**Cosa devo fare se il file esterno è protetto da password?**

Aspose.Slides non accetta una password durante il collegamento. Un approccio comune è rimuovere la protezione in anticipo o preparare una copia decrittata (ad esempio, usando [Aspose.Cells](/cells/cpp/)) e collegarsi a quella copia.

**Più grafici possono fare riferimento alla stessa cartella di lavoro esterna?**

Sì. Ogni grafico memorizza il proprio collegamento. Se tutti puntano allo stesso file, l'aggiornamento di quel file verrà riflesso in ciascun grafico al successivo caricamento dei dati.