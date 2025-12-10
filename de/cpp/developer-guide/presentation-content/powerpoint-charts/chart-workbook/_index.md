---
title: Diagramm-Arbeitsmappen in Präsentationen mit C++ verwalten
linktitle: Diagramm-Arbeitsmappe
type: docs
weight: 70
url: /de/cpp/chart-workbook/
keywords:
- Diagramm-Arbeitsmappe
- Diagrammdaten
- Arbeitsblattzelle
- Datenbeschriftung
- Arbeitsblatt
- Datenquelle
- Externe Arbeitsmappe
- Externe Daten
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für C++: Verwalten Sie Diagramm-Arbeitsmappen in PowerPoint- und OpenDocument-Formaten mühelos, um Ihre Präsentationsdaten zu optimieren."
---

## **Diagrammdaten aus einer Arbeitsmappe lesen und schreiben**

Aspose.Slides bietet die Methoden [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data#a1bc3d9eaafc86814336b6c23bffd8e2e) und [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data#a3f42c5e16bf1fd1d4e69579bffc6ce8e) an, mit denen Sie Arbeitsmappen für Diagrammdaten (die mit Aspose.Cells bearbeitet wurden) lesen und schreiben können. **Hinweis**: Die Diagrammdaten müssen in derselben Weise organisiert sein oder eine ähnliche Struktur wie die Quelldaten aufweisen.
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


Dieser C++‑Code demonstriert das Setzen einer Diagrammdaten‑Arbeitsmappe:
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


## **Eine Arbeitsblattzelle als Diagrammdaten‑Beschriftung festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/)‑Klasse.  
1. Holen Sie sich über den Index einen Verweis auf die Folie.  
1. Fügen Sie ein Blasendiagramm mit einigen Daten hinzu.  
1. Greifen Sie auf die Diagramm‑Serie zu.  
1. Legen Sie die Arbeitsblattzelle als Datenbeschriftung fest.  
1. Speichern Sie die Präsentation.

Dieser C++‑Code zeigt, wie Sie eine Arbeitsblattzelle als Diagrammdaten‑Beschriftung festlegen:
``` cpp
System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// Instanziiert eine Presentation-Klasse, die eine Präsentationsdatei darstellt
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


## **Arbeitsblätter verwalten**

Dieser C++‑Code demonstriert eine Operation, bei der die Eigenschaft [IChartDataWorkbook.Worksheets](https://reference.aspose.com/slides/cpp/class/aspose.slides.charts.i_chart_data_workbook#a8a5bfd5f6d389c497fe0d9ff4037d928) verwendet wird, um auf eine Arbeitsblatt‑Sammlung zuzugreifen:
```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```


## **Datentyp der Quelle festlegen**

Dieser C++‑Code zeigt, wie Sie einen Typ für eine Datenquelle festlegen:
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


## **Externe Arbeitsmappe**

{{% alert color="primary" %}} 
In [Aspose.Slides](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-19-4-release-notes/) 19.4 haben wir die Unterstützung für externe Arbeitsmappen als Datenquelle für Diagramme implementiert.
{{% /alert %}} 

### **Eine externe Arbeitsmappe erstellen**

Mit den Methoden **`ReadWorkbookStream`** und **`SetExternalWorkbook`** können Sie entweder eine externe Arbeitsmappe von Grund auf neu erstellen oder eine interne Arbeitsmappe extern machen.

Dieser C++‑Code demonstriert den Erstellungsprozess einer externen Arbeitsmappe:
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


### **Eine externe Arbeitsmappe festlegen**

Mit der Methode **`IChartData.SetExternalWorkbook`** können Sie einer Grafik eine externe Arbeitsmappe als Datenquelle zuweisen. Diese Methode kann auch verwendet werden, um den Pfad zur externen Arbeitsmappe zu aktualisieren (falls diese verschoben wurde).

Während Sie die Daten in Arbeitsmappen, die an entfernten Orten oder Ressourcen gespeichert sind, nicht bearbeiten können, können Sie solche Arbeitsmappen dennoch als externe Datenquelle nutzen. Wird ein relativer Pfad für eine externe Arbeitsmappe angegeben, wird er automatisch in einen absoluten Pfad umgewandelt.

Dieser C++‑Code zeigt, wie Sie eine externe Arbeitsmappe festlegen:
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


Der Parameter `updateChartData` (unter der Methode `SetExternalWorkbook`) gibt an, ob eine Excel‑Arbeitsmappe geladen wird oder nicht.

* Wenn `updateChartData` auf `false` gesetzt ist, wird nur der Pfad zur Arbeitsmappe aktualisiert – die Diagrammdaten werden nicht aus der Zielarbeitsmappe geladen oder aktualisiert. Diese Einstellung ist sinnvoll, wenn die Zielarbeitsmappe nicht existiert oder nicht verfügbar ist.  
* Wenn `updateChartData` auf `true` gesetzt ist, werden die Diagrammdaten aus der Zielarbeitsmappe aktualisiert.
```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```


### **Pfad zur externen Datenquellen‑Arbeitsmappe eines Diagramms abrufen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)‑Klasse.  
1. Holen Sie sich über den Index einen Verweis auf die Folie.  
1. Erzeugen Sie ein Objekt für das Diagramm‑Shape.  
1. Erzeugen Sie ein Objekt für den Quelltyp (`ChartDataSourceType`), das die Datenquelle des Diagramms repräsentiert.  
1. Geben Sie die relevante Bedingung an, wobei der Quelltyp dem Typ der externen Arbeitsmappe entsprechen muss.

Dieser C++‑Code demonstriert die Operation:
```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto slide = pres->get_Slides()->idx_get(1);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
ChartDataSourceType sourceType = chart->get_ChartData()->get_DataSourceType();
if (sourceType == ChartDataSourceType::ExternalWorkbook)
{
    System::String path = chart->get_ChartData()->get_ExternalWorkbookPath();
}

// Saves the presentation
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```


### **Diagrammdaten bearbeiten**

Sie können die Daten in externen Arbeitsmappen genauso bearbeiten, wie Sie Änderungen an internen Arbeitsmappen vornehmen. Wenn eine externe Arbeitsmappe nicht geladen werden kann, wird eine Ausnahme ausgelöst.

Dieser C++‑Code implementiert den beschriebenen Vorgang:
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

**Kann ich feststellen, ob ein bestimmtes Diagramm mit einer externen oder einer eingebetteten Arbeitsmappe verknüpft ist?**

Ja. Ein Diagramm verfügt über einen [Datenquellentyp](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) und einen [Pfad zu einer externen Arbeitsmappe](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); ist die Quelle eine externe Arbeitsmappe, können Sie den vollständigen Pfad auslesen, um sicherzustellen, dass eine externe Datei verwendet wird.

**Werden relative Pfade zu externen Arbeitsmappen unterstützt und wie werden sie gespeichert?**

Ja. Wenn Sie einen relativen Pfad angeben, wird er automatisch in einen absoluten Pfad umgewandelt. Das erleichtert die Projektportabilität; jedoch wird der absolute Pfad in der PPTX‑Datei gespeichert.

**Kann ich Arbeitsmappen verwenden, die sich auf Netzwerkressourcen/Freigaben befinden?**

Ja, solche Arbeitsmappen können als externe Datenquelle genutzt werden. Das direkte Bearbeiten von Remote‑Arbeitsmappen über Aspose.Slides wird jedoch nicht unterstützt – sie können nur als Quelle dienen.

**Überschreibt Aspose.Slides die externe XLSX beim Speichern der Präsentation?**

Nein. Die Präsentation speichert einen [Verweis auf die externe Datei](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) und verwendet diesen zum Lesen der Daten. Die externe Datei selbst wird beim Speichern der Präsentation nicht verändert.

**Was ist zu tun, wenn die externe Datei durch ein Passwort geschützt ist?**

Aspose.Slides akzeptiert beim Verknüpfen kein Passwort. Ein gängiger Ansatz besteht darin, den Schutz im Vorfeld zu entfernen oder eine entschlüsselte Kopie (z. B. mit [Aspose.Cells](/cells/cpp/)) vorzubereiten und auf diese Kopie zu verlinken.

**Können mehrere Diagramme dieselbe externe Arbeitsmappe referenzieren?**

Ja. Jedes Diagramm speichert seinen eigenen Verweis. Wenn sie alle auf dieselbe Datei zeigen, werden Änderungen an dieser Datei in allen Diagrammen beim nächsten Laden der Daten wirksam.