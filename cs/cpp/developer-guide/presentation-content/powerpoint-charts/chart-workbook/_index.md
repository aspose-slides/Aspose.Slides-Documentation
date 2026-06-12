---
title: Spravovat sešity grafů v prezentacích pomocí C++
linktitle: Sešit grafu
type: docs
weight: 70
url: /cs/cpp/chart-workbook/
keywords:
- sešit grafu
- data grafu
- buňka sešitu
- popisek dat
- list
- zdroj dat
- externí sešit
- externí data
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Objevte Aspose.Slides pro C++: snadno spravujte sešity grafů ve formátech PowerPoint a OpenDocument a zefektivněte data ve své prezentaci."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s sešity grafů v Aspose.Slides. Ukazuje, jak číst a zapisovat data grafu pomocí streamů sešitu, používat buňky sešitu jako popisky dat grafu, přistupovat k kolekcím listů a určit typ zdroje dat pro hodnoty grafu. Také se zabývá prací s externími sešity jako zdroji dat grafů. Příklady ukazují, jak vytvořit a přiřadit externí sešit, získat cestu k externímu sešitu připojenému k grafu a upravit data grafu, když je sešit k dispozici.

## **Čtení a zápis dat grafu ze sešitu**

Aspose.Slides poskytuje metody [ReadWorkbookStream](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) a [WriteWorkbookStream](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/), které umožňují číst a zapisovat sešity dat grafu (obsahující data grafu upravená pomocí Aspose.Cells). **Poznámka**: data grafu musí být uspořádána stejným způsobem nebo musí mít strukturu podobnou zdroji.

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

Tento C++ kód demonstruje operaci nastavení sešitu dat grafu:

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

## **Nastavení buňky sešitu jako popisku dat grafu**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte referenci na snímek pomocí jeho indexu.
1. Přidejte bublinový graf s některými daty.
1. Přistupte k řadám grafu.
1. Nastavte buňku sešitu jako popisek dat.
1. Uložte prezentaci.

Tento C++ kód ukazuje, jak nastavit buňku sešitu jako popisek dat grafu:

``` cpp
System::String lbl0 = u"Label 0 cell value";
System::String lbl1 = u"Label 1 cell value";
System::String lbl2 = u"Label 2 cell value";

// Vytvoří instanci třídy Presentation, která představuje soubor prezentace 
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

## **Správa listů**

Tento C++ kód demonstruje operaci, kde je metoda [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) použita k přístupu k kolekci listů:

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **Určení typu zdroje dat**

Tento C++ kód ukazuje, jak určit typ pro zdroj dat:

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

## **Detekce nepodporovaných vložených formátů sešitu**

Aspose.Slides nepodporuje binární formát Excel sešitu (.xlsb), který může být vložen v některých grafech. Můžete použít metodu `get_EmbeddedWorkbookType` na rozhraní [IChartData](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdata/) spolu s výčtem [WorkbookType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/workbooktype/), abyste detekovali nepodporované formáty a tyto grafy přeskočili.

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
        // Vložený sešit je ve formátu .xlsb, který není podporován.
        continue;
    }

    // Zde přečtěte nebo upravte data sešitu grafu.
}
```

## **Externí sešit**

{{% alert color="primary" %}} 
Ve verzi 19.4 [Aspose.Slides](https://releases.aspose.com/slides/cs/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) jsme implementovali podporu externích sešitů jako zdroje dat pro grafy.
{{% /alert %}} 

### **Vytvoření externího sešitu**

Pomocí metod **`ReadWorkbookStream`** a **`SetExternalWorkbook`** můžete buď vytvořit externí sešit od nuly, nebo převést interní sešit na externí.

Tento C++ kód demonstruje proces vytvoření externího sešitu:

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

### **Nastavení externího sešitu**

Pomocí metody **`IChartData::SetExternalWorkbook`** můžete přiřadit externí sešit grafu jako jeho zdroj dat. Tuto metodu lze také použít k aktualizaci cesty k externímu sešitu (pokud byl přesunut).

I když nemůžete upravovat data v sešitech uložených na vzdálených místech nebo zdrojích, můžete takové sešity stále použít jako externí zdroj dat. Pokud je zadána relativní cesta k externímu sešitu, automaticky se převede na úplnou cestu.

Tento C++ kód ukazuje, jak nastavit externí sešit:

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

Parametr `updateChartData` (v rámci metody `SetExternalWorkbook`) slouží k určení, zda bude excelový sešit načten, nebo ne. 

* Když je hodnota `updateChartData` nastavena na `false`, aktualizuje se pouze cesta k sešitu – data grafu nebudou načtena ani aktualizována z cílového sešitu. Toto nastavení můžete použít v případech, kdy cílový sešit neexistuje nebo není k dispozici. 
* Když je hodnota `updateChartData` nastavena na `true`, data grafu se aktualizují z cílového sešitu.

```c++
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **Získání cesty k externímu zdroji dat sešitu grafu**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte referenci na snímek pomocí jeho indexu.
1. Vytvořte objekt pro tvar grafu.
1. Vytvořte objekt pro typ zdroje (`ChartDataSourceType`), který představuje zdroj dat grafu.
1. Určete příslušnou podmínku na základě toho, že typ zdroje je stejný jako typ externího sešitu.

Tento C++ kód demonstruje operaci:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto slide = pres->get_Slides()->idx_get(1);
auto chart = System::ExplicitCast<IChart>(slide->get_Shapes()->idx_get(0));
ChartDataSourceType sourceType = chart->get_ChartData()->get_DataSourceType();
if (sourceType == ChartDataSourceType::ExternalWorkbook)
{
    System::String path = chart->get_ChartData()->get_ExternalWorkbookPath();
}

// Uloží prezentaci
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

### **Úprava dat grafu**

Data v externích sešitech můžete upravovat stejným způsobem jako obsah interních sešitů. Pokud nelze externí sešit načíst, je vyvolána výjimka.

Tento C++ kód je implementací popsaného postupu:

```c++
const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Často kladené otázky**

**Mohu zjistit, zda je konkrétní graf propojen s externím nebo vloženým sešitem?**

Ano. Graf má [data source type](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) a [path to an external workbook](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); pokud je zdroj externí sešit, můžete přečíst úplnou cestu a ověřit, že je použit externí soubor.

**Jsou relativní cesty k externím sešitům podporovány a jak jsou uloženy?**

Ano. Pokud zadáte relativní cestu, automaticky se převede na absolutní cestu. To je výhodné pro přenositelnost projektu; však buďte si vědomi, že prezentace uloží absolutní cestu v souboru PPTX.

**Mohu použít sešity umístěné na síťových zdrojích/sdílených složkách?**

Ano, takové sešity lze použít jako externí zdroj dat. Úprava vzdálených sešitů přímo z Aspose.Slides však není podporována – mohou být použity pouze jako zdroj.

**Přepisuje Aspose.Slides externí XLSX při ukládání prezentace?**

Ne. Prezentace uloží [link to the external file](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) a použije jej při čtení dat. Externí soubor samotný není při uložení prezentace změněn.

**Co mám dělat, pokud je externí soubor chráněn heslem?**

Aspose.Slides nepřijímá heslo při prolinkování. Běžný postup je předem odstranit ochranu nebo připravit dešifrovanou kopii (například pomocí [Aspose.Cells](/cells/cpp/)) a odkazovat na tuto kopii.

**Mohou více grafů odkazovat na stejný externí sešit?**

Ano. Každý graf si uloží vlastní odkaz. Pokud všechny ukazují na stejný soubor, aktualizace tohoto souboru se projeví v každém grafu při dalším načtení dat.