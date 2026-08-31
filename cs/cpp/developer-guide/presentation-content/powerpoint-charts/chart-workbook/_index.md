---
title: Správa sešitů diagramů v prezentacích pomocí C++
linktitle: Sešit diagramu
type: docs
weight: 70
url: /cs/cpp/chart-workbook/
keywords:
- sešit diagramu
- data diagramu
- buňka sešitu
- popisek dat
- list
- zdroj dat
- externí sešit
- externí data
- mezipaměť diagramu
- obnovení sešitu
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Objevte Aspose.Slides pro C++: snadno spravujte sešity diagramů v PowerPoint a OpenDocument formátech a zjednodušte data své prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat se sešity diagramů v Aspose.Slides. Ukazuje, jak číst a zapisovat data diagramu pomocí proudů sešitu, používat buňky sešitu jako popisky dat diagramu, přistupovat ke kolekcím listů a určovat typ zdroje dat pro hodnoty diagramu.

Také se věnuje práci s externími sešity jako zdroji dat pro diagramy. Příklady ukazují, jak vytvořit a přiřadit externí sešit, získat cestu k externímu sešitu propojenému s diagramem a upravit data diagramu, když je sešit dostupný.

## **Čtení a zápis dat diagramu ze sešitu**

Aspose.Slides poskytuje metody [ReadWorkbookStream](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) a [WriteWorkbookStream](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/), které umožňují číst a zapisovat sešity s daty diagramu (obsahující data diagramu editovaná pomocí Aspose.Cells). **Note** že data diagramu musí být uspořádána stejným způsobem nebo mít strukturu podobnou zdroji.

``` cpp
#include <DOM/Chart/Chart.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/io/memory_stream.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>(u"chart.pptx");

auto chart = System::ExplicitCast<Chart>(pres->get_Slide(0)->get_Shape(0));
auto data = chart->get_ChartData();

auto = data->ReadWorkbookStream();
data->get_Series()->Clear();
data->get_Categories()->Clear();

stream->set_Position(0);
data->WriteWorkbookStream(stream);
```

### **Ověření rozvržení diagramu po úpravě sešitu**

Když nahradíte vložený sešit upraveným, diagram si zachová původní kolekce řad a kategorií. Tento nesoulad může způsobit selhání [IChart::ValidateChartLayout](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichart/validatechartlayout/) s chybou index‑out‑of‑range. Vymažte existující řady a kategorie před zápisem aktualizovaného sešitu zpět do diagramu.

```cpp
// Po úpravě proudu sešitu (např. pomocí Aspose.Cells)
auto updatedWorkbook = chartData->ReadWorkbookStream();

// Vymazat existující odkazy na data.
chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

updatedWorkbook->set_Position(0);
chartData->WriteWorkbookStream(updatedWorkbook);

chart->ValidateChartLayout();
```

Vymazání kolekcí zajistí, že struktura dat diagramu bude konzistentní s novým sešitem, což umožní `ValidateChartLayout` dokončit bez chyb.

## **Nastavte buňku sešitu jako popisek dat diagramu**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Přidejte bublinový diagram s několika daty.
4. Přistupte k řadě diagramu.
5. Nastavte buňku sešitu jako popisek dat.
6. Uložte prezentaci.

Tento C++ kód ukazuje, jak nastavit buňku sešitu jako popisek dat diagramu:

``` cpp
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
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

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

Tento C++ kód demonstruje operaci, kde je metoda [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) použita k přístupu ke kolekci listů:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataWorksheet.h>
#include <DOM/Chart/IChartDataWorksheetCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 500.0f);
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto worksheets = workbook->get_Worksheets();

for (auto ws : System::IterateOver(worksheets))
    System::Console::WriteLine(ws->get_Name());
```

## **Určení typu zdroje dat**

Tento C++ kód ukazuje, jak specifikovat typ pro zdroj dat:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

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

## **Detekce nepodporovaných formátů vložených sešitů**

Aspose.Slides nepodporuje binární formát Excelu (.xlsb), který může být vložen v některých diagramech. Můžete použít metodu `get_EmbeddedWorkbookType` na [IChartData](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdata/) spolu s výčtem [WorkbookType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/workbooktype/), abyste detekovali nepodporované formáty a tyto diagramy přeskočili.

```cpp
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/WorkbookType.h>
#include <DOM/IChart.h>
#include <DOM/ISlide.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);

for (auto&& shape : System::IterateOver(slide->get_Shapes()))
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

    // Zde načtěte nebo upravte data sešitu diagramu.
}
```

## **Externí sešit**

{{% alert color="info" %}} 
V [Aspose.Slides](https://releases.aspose.com/slides/cs/cpp/release-notes/2019/aspose-slides-for-cpp-19-4-release-notes/) 19.4 jsme implementovali podporu externích sešitů jako zdroje dat pro diagramy.
{{% /alert %}} 

### **Vytvořte externí sešit**

Pomocí metod **`ReadWorkbookStream`** a **`SetExternalWorkbook`** můžete buď vytvořit externí sešit od nuly, nebo učinit interní sešit externím.

Tento C++ kód demonstruje proces vytvoření externího sešitu:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System::IO;

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

### **Nastavte externí sešit**

Pomocí metody **`IChartData::SetExternalWorkbook`** můžete přiřadit externí sešit k diagramu jako jeho zdroj dat. Tato metoda může být také použita k aktualizaci cesty k externímu sešitu (pokud byl přesunut).

I když nemůžete upravovat data v sešitech uložených na vzdálených místech nebo v prostředcích, můžete takové sešity nadále používat jako externí zdroj dat. Pokud je zadána relativní cesta k externímu sešitu, automaticky se převede na úplnou cestu.

Tento C++ kód ukazuje, jak nastavit externí sešit:

```c++
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/path.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System::IO;

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

Parametr `updateChartData` (u metody `SetExternalWorkbook`) slouží k určení, zda bude excelový sešit načten.

* Když je hodnota `updateChartData` nastavena na `false`, aktualizuje se jen cesta k sešitu — data diagramu nebudou načtena ani aktualizována ze zvoleného sešitu. Toto nastavení se hodí, když cílový sešit neexistuje nebo není dostupný.  
* Když je hodnota `updateChartData` nastavena na `true`, data diagramu se aktualizují ze zvoleného sešitu.

```c++
#include <DOM/Chart/ChartData.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto chart = slide->get_Shapes()->AddChart(ChartType::Pie, 50.0f, 50.0f, 400.0f, 600.0f, true);
System::SharedPtr<IChartData> chartData = chart->get_ChartData();

System::SharedPtr<ChartData> concreteChartData = System::AsCast<ChartData>(chartData);
concreteChartData->SetExternalWorkbook(u"http://path/doesnt/exists", false);

pres->Save(u"SetExternalWorkbookWithUpdateChartData.pptx", SaveFormat::Pptx);
```

### **Získejte cestu k externímu zdroji dat sešitu diagramu**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) .
2. Získejte odkaz na snímek pomocí jeho indexu.
3. Vytvořte objekt pro tvar diagramu.
4. Vytvořte objekt pro typ zdroje (`ChartDataSourceType`), který představuje zdroj dat diagramu.
5. Specifikujte příslušnou podmínku na základě toho, že typ zdroje je stejný jako typ externího sešitu.

Tento C++ kód demonstruje operaci:

```c++
#include <DOM/Chart/ChartDataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

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

### **Upravte data diagramu**

Data v externích sešitech můžete upravovat stejným způsobem jako v interních sešitech. Když nelze externí sešit načíst, vyvolá se výjimka.

Tento C++ kód je implementací popsaného postupu:

```c++
#include <DOM/Chart/Chart.h>
#include <DOM/Chart/ChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

const String templatePath = u"../templates/presentation.pptx";
	const String outPath = u"../out/presentation-out.pptx";
	

	System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(templatePath);
	System::SharedPtr<Aspose::Slides::Charts::IChart> chart = System::AsCast<Aspose::Slides::Charts::IChart>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
	System::SharedPtr<Aspose::Slides::Charts::ChartData> chartData = System::ExplicitCast<Aspose::Slides::Charts::ChartData>(chart->get_ChartData());
	

	chartData->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0)->get_Value()->get_AsCell()->set_Value(System::ObjectExt::Box<int32_t>(100));
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

### **Obnovte sešit z mezipaměti diagramu**

Pokud diagram používá externí sešit, který chybí nebo není dostupný, Aspose.Slides může rekonstruovat sešit diagramu z dat uložených v mezipaměti prezentace. Vytvořte [LoadOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/), nakonfigurujte jej pomocí [set_SpreadsheetOptions](https://reference.aspose.com/slides/cs/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), a zavolejte [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) s hodnotou `true` před otevřením prezentace.

Následující C++ příklad otevírá prezentaci, jejíž diagram odkazuje na nedostupný externí sešit, a přistupuje k obnoveným datům prostřednictvím [IChart::get_ChartData](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichart/get_chartdata/) a [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

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

Pokud je externí sešit nedostupný a obnova je vypnuta, Aspose.Slides vyhodí `System::InvalidOperationException`. Povolit obnovu použijte jen tehdy, když je použití dat z mezipaměti přijatelnou náhradou, protože mezipaměť nemusí obsahovat změny provedené v externím sešitu po poslední aktualizaci prezentace.

## **Často kladené otázky**

**Mohu zjistit, zda je konkrétní diagram propojen s externím nebo vloženým sešitem?**

Ano. Diagram má [typ zdroje dat](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) a [cestu k externímu sešitu](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); pokud je zdroj externí sešit, můžete přečíst úplnou cestu a ověřit, že je používán externí soubor.

**Jsou podporovány relativní cesty k externím sešitům a jak jsou uloženy?**

Ano. Pokud zadáte relativní cestu, automaticky se převede na absolutní. To je výhodné pro přenositelnost projektu; však si uvědomte, že prezentace uloží absolutní cestu v souboru PPTX.

**Mohu použít sešity umístěné na síťových zdrojích/sdíleních?**

Ano, takové sešity mohou být použity jako externí zdroj dat. Přímé úpravy vzdálených sešitů z Aspose.Slides však nejsou podporovány – mohou být použity jen jako zdroj.

**Přepisuje Aspose.Slides externí XLSX při ukládání prezentace?**

Ne. Prezentace ukládá [odkaz na externí soubor](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/) a používá jej pro čtení dat. Externí soubor samotný není při uložení prezentace upravován.

**Co mám dělat, když je externí soubor chráněn heslem?**

Aspose.Slides nepřijímá heslo při vytváření odkazu. Běžný přístup je odstranit ochranu předem nebo připravit dešifrovanou kopii (např. pomocí [Aspose.Cells](/cells/cpp/)) a odkazovat na tuto kopii.

**Může více diagramů odkazovat na stejný externí sešit?**

Ano. Každý diagram ukládá svůj vlastní odkaz. Pokud všechny odkazují na stejný soubor, aktualizace tohoto souboru se projeví ve všech diagramech při dalším načtení dat.