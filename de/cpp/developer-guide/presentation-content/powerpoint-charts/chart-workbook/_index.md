---
title: Diagramm-Arbeitsmappen in Präsentationen mit C++ verwalten
linktitle: Diagramm-Arbeitsmappe
type: docs
weight: 70
url: /de/cpp/chart-workbook/
keywords:
- Diagramm-Arbeitsmappe
- Diagrammdaten
- Arbeitsmappen-Zelle
- Datenbeschriftung
- Arbeitsblatt
- Datenquelle
- externe Arbeitsmappe
- externe Daten
- Diagramm-Cache
- Wiederherstellung der Arbeitsmappe
- PowerPoint
- Präsentation
- C++
- Aspose.Slides
description: "Entdecken Sie Aspose.Slides für C++: Verwalten Sie Diagramm-Arbeitsmappen in PowerPoint- und OpenDocument-Formaten mühelos, um Ihre Präsentationsdaten zu optimieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man mit Diagramm‑Arbeitsmappen in Aspose.Slides arbeitet. Er zeigt, wie Diagrammdaten über Arbeitsmappen‑Streams gelesen und geschrieben werden, wie Arbeitsmappen‑Zellen als Diagrammdaten‑Beschriftungen verwendet werden, wie auf Arbeitsblatt‑Sammlungen zugegriffen wird und wie der Datentyp für Diagrammwerte angegeben wird.

Er behandelt außerdem die Arbeit mit externen Arbeitsmappen als Diagrammdatenquellen. Die Beispiele demonstrieren, wie eine externe Arbeitsmappe erstellt und zugewiesen wird, wie der Pfad einer mit einem Diagramm verknüpften externen Arbeitsmappe abgerufen wird und wie Diagrammdaten bearbeitet werden, wenn die Arbeitsmappe verfügbar ist.

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
## **Lesen und Schreiben von Diagrammdaten aus einer Arbeitsmappe**

Aspose.Slides stellt die Methoden [ReadWorkbookStream](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) und [WriteWorkbookStream](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/) zur Verfügung, mit denen Sie Diagramm‑Daten‑Arbeitsmappen lesen und schreiben können (die Diagrammdaten enthalten, die mit Aspose.Cells bearbeitet wurden). **Hinweis**: Die Diagrammdaten müssen in derselben Weise organisiert sein oder eine Struktur haben, die der Quelle ähnlich ist.

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

## **Eine Arbeitsmappen‑Zelle als Diagrammdatenbeschriftung festlegen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
1. Holen Sie sich die Referenz einer Folie über ihren Index.
1. Fügen Sie ein Bubble‑Diagramm mit einigen Daten hinzu.
1. Greifen Sie auf die Diagramm‑Serie zu.
1. Setzen Sie die Arbeitsmappen‑Zelle als Datenbeschriftung.
1. Speichern Sie die Präsentation.

Dieser C++‑Code zeigt, wie Sie eine Arbeitsmappen‑Zelle als Diagrammdatenbeschriftung festlegen:

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

Dieser C++‑Code demonstriert einen Vorgang, bei dem die Methode [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) verwendet wird, um auf eine Arbeitsblatt‑Sammlung zuzugreifen:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **Datentyp für die Datenquelle angeben**

Dieser C++‑Code zeigt, wie Sie einen Typ für eine Datenquelle angeben:

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

## **Erkennen nicht unterstützter eingebetteter Arbeitsmappen‑Formate**

Aspose.Slides unterstützt das Excel‑Binärarbeitsmappen‑Format (.xlsb), das in einigen Diagrammen eingebettet werden kann, nicht. Sie können die Methode `get_EmbeddedWorkbookType` auf [IChartData](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdata/) zusammen mit der Aufzählung [WorkbookType](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/workbooktype/) verwenden, um nicht unterstützte Formate zu erkennen und diese Diagramme zu überspringen.

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
        // Eingebettete Arbeitsmappe ist im .xlsb-Format, das nicht unterstützt wird.
        continue;
    }

    // Lesen oder ändern Sie hier die Diagramm-Arbeitsmappendaten.
}
```

## **Externe Arbeitsmappe**

{{% alert color="primary" %}} 
In [Aspose.Slides](https://releases.aspose.com/slides/de/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4 haben wir die Unterstützung für externe Arbeitsmappen als Datenquelle für Diagramme implementiert.
{{% /alert %}} 

### **Externe Arbeitsmappe erstellen**

Mit den Methoden **`ReadWorkbookStream`** und **`SetExternalWorkbook`** können Sie entweder eine externe Arbeitsmappe von Grund auf erstellen oder eine interne Arbeitsmappe extern machen.

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

### **Externe Arbeitsmappe festlegen**

Mit der Methode **`IChartData::SetExternalWorkbook`** können Sie einer Diagramm‑Datenquelle eine externe Arbeitsmappe zuweisen. Diese Methode kann auch verwendet werden, um den Pfad zur externen Arbeitsmappe zu aktualisieren (falls diese verschoben wurde).

Obwohl Sie die Daten in Arbeitsmappen, die an entfernten Orten oder Ressourcen gespeichert sind, nicht bearbeiten können, können Sie solche Arbeitsmappen weiterhin als externe Datenquelle verwenden. Wird ein relativer Pfad für eine externe Arbeitsmappe angegeben, wird er automatisch in einen vollständigen Pfad umgewandelt.

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

Der Parameter `updateChartData` (bei der Methode `SetExternalWorkbook`) wird verwendet, um anzugeben, ob eine Excel‑Arbeitsmappe geladen werden soll oder nicht. 

* Wenn der Wert von `updateChartData` auf `false` gesetzt ist, wird nur der Pfad der Arbeitsmappe aktualisiert – die Diagrammdaten werden nicht aus der Zielarbeitsmappe geladen oder aktualisiert. Diese Einstellung kann sinnvoll sein, wenn die Zielarbeitsmappe nicht existiert oder nicht verfügbar ist. 
* Wenn der Wert von `updateChartData` auf `true` gesetzt ist, werden die Diagrammdaten aus der Zielarbeitsmappe aktualisiert.

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **Pfad der externen Datenquellen‑Arbeitsmappe eines Diagramms abrufen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/cpp/aspose.slides/presentation/).
1. Holen Sie sich die Referenz einer Folie über ihren Index.
1. Erstellen Sie ein Objekt für die Diagramm‑Form.
1. Erstellen Sie ein Objekt für den Quelltyp (`ChartDataSourceType`), der die Datenquelle des Diagramms darstellt.
1. Geben Sie die entsprechende Bedingung an, basierend darauf, dass der Quelltyp dem Typ der externen Arbeitsmappen‑Datenquelle entspricht.

Dieser C++‑Code demonstriert den Vorgang:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto slide = pres->get_Slides()->idx_get(1);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
ChartDataSourceType sourceType = chart->get_ChartData()->get_DataSourceType();
if (sourceType == ChartDataSourceType::ExternalWorkbook)
{
    System::String path = chart->get_ChartData()->get_ExternalWorkbookPath();
}

// Speichert die Präsentation
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **Diagrammdaten bearbeiten**

Sie können die Daten in externen Arbeitsmappen auf dieselbe Weise bearbeiten, wie Sie Änderungen an internen Arbeitsmappen vornehmen. Wenn eine externe Arbeitsmappe nicht geladen werden kann, wird eine Ausnahme ausgelöst.

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

### **Wiederherstellung einer Arbeitsmappe aus dem Diagramm‑Cache**

Wenn ein Diagramm eine externe Arbeitsmappe verwendet, die fehlt oder nicht verfügbar ist, kann Aspose.Slides die Diagramm‑Arbeitsmappe aus den im Dokument zwischengespeicherten Daten rekonstruieren. Erstellen Sie [LoadOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/), konfigurieren Sie es mit [set_SpreadsheetOptions](https://reference.aspose.com/slides/de/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), und rufen Sie [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/de/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) mit `true` auf, bevor Sie die Präsentation öffnen.

Das folgende C++‑Beispiel öffnet eine Präsentation, deren Diagramm auf eine nicht verfügbare externe Arbeitsmappe verweist, und greift über [IChart::get_ChartData](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichart/get_chartdata/) und [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) auf die wiederhergestellten Daten zu:

```cpp
auto spreadsheetOptions = MakeObject<SpreadsheetOptions>();
spreadsheetOptions->set_RecoverWorkbookFromChartCache(true);

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_SpreadsheetOptions(spreadsheetOptions);

auto presentation = MakeObject<Presentation>(u"presentation.pptx", loadOptions);

auto shape = presentation->get_Slide(0)->get_Shape(0);
auto chart = System::ExplicitCast<IChart>(shape);

auto recoveredWorkbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Lesen oder bearbeiten Sie hier die wiederhergestellten Arbeitsmappendaten.

presentation->Dispose();
```

Ist die externe Arbeitsmappe nicht verfügbar und ist die Wiederherstellung deaktiviert, wirft Aspose.Slides eine `System::InvalidOperationException`. Aktivieren Sie die Wiederherstellung nur, wenn die Verwendung der zwischengespeicherten Diagrammdaten ein akzeptabler Rückgriff ist, da der Cache Änderungen, die nach dem letzten Aktualisieren der Präsentation an der externen Arbeitsmappe vorgenommen wurden, möglicherweise nicht enthält.

## **FAQ**

**Kann ich feststellen, ob ein bestimmtes Diagramm mit einer externen oder einer eingebetteten Arbeitsmappe verknüpft ist?**

Ja. Ein Diagramm besitzt einen [Datentyp der Datenquelle](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) und einen [Pfad zu einer externen Arbeitsmappe](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). Wenn die Quelle eine externe Arbeitsmappe ist, können Sie den vollständigen Pfad auslesen, um sicherzustellen, dass eine externe Datei verwendet wird.

**Werden relative Pfade zu externen Arbeitsmappen unterstützt und wie werden sie gespeichert?**

Ja. Wenn Sie einen relativen Pfad angeben, wird dieser automatisch in einen absoluten Pfad umgewandelt. Das ist praktisch für die Portierbarkeit von Projekten; beachten Sie jedoch, dass die Präsentation den absoluten Pfad in der PPTX‑Datei speichert.

**Kann ich Arbeitsmappen verwenden, die sich auf Netzwerkressourcen/Freigaben befinden?**

Ja, solche Arbeitsmappen können als externe Datenquelle verwendet werden. Das direkte Bearbeiten von entfernten Arbeitsmappen über Aspose.Slides wird jedoch nicht unterstützt – sie können nur als Quelle genutzt werden.

**Überschreibt Aspose.Slides die externe XLSX beim Speichern der Präsentation?**

Nein. Die Präsentation speichert einen [Link zur externen Datei](https://reference.aspose.com/slides/de/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/), der zum Lesen der Daten verwendet wird. Die externe Datei selbst wird beim Speichern der Präsentation nicht verändert.

**Was soll ich tun, wenn die externe Datei durch ein Passwort geschützt ist?**

Aspose.Slides akzeptiert beim Verknüpfen kein Passwort. Ein gängiger Ansatz ist, den Schutz im Vorfeld zu entfernen oder eine entschlüsselte Kopie vorzubereiten (z. B. mit [Aspose.Cells](/cells/cpp/)) und diese Kopie zu verknüpfen.

**Können mehrere Diagramme dieselbe externe Arbeitsmappe referenzieren?**

Ja. Jedes Diagramm speichert seinen eigenen Link. Wenn sie alle auf dieselbe Datei zeigen, wird eine Aktualisierung dieser Datei beim nächsten Laden der Daten in jedem Diagramm berücksichtigt.