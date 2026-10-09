---
title: Spravovat sešity diagramů v prezentacích pomocí C++
linktitle: Sešit diagramu
type: docs
weight: 70
url: /cs/cpp/chart-workbook/
keywords:
- sešit diagramu
- data diagramu
- buňka sešitu
- popisek dat
- pracovní list
- zdroj dat
- externí sešit
- externí data
- cache diagramu
- obnovení sešitu
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Objevte Aspose.Slides pro C++: snadno spravujte sešity diagramů v formátech PowerPoint a OpenDocument a zjednodušte data své prezentace."
---
## **Přehled**

Tento článek vysvětluje, jak pracovat s sešity diagramů v Aspose.Slides. Ukazuje, jak číst a zapisovat data diagramu pomocí proudů sešitu, používat buňky sešitu jako popisky dat diagramu, přistupovat k kolekcím pracovních listů a specifikovat typ zdroje dat pro hodnoty diagramu.

Také se zabývá používáním externích sešitů jako zdrojů dat diagramu. Příklady demonstrují, jak vytvořit a přiřadit externí sešit, získat cestu k externímu sešitu připojenému k diagramu a upravit data diagramu, když je sešit k dispozici.

Pro buňky sešitu, které představují chybějící data, viz [Ovládání zobrazení prázdných buněk](/slides/cs/cpp/chart-series/) pro rozdíl mezi prázdnou buňkou a nulou a porovnání liniového diagramu dostupných režimů zobrazení.

## **Zahrnout data ze skrytých řádků a sloupců**

Použijte [IChart::set_PlotVisibleCellsOnly](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_plotvisiblecellsonly/) k řízení, zda diagram vykresluje data ze skrytých řádků a sloupců pracovního listu. Nastavte jej na `true`, aby se vykreslovaly jen viditelné buňky, nebo na `false`, aby se zahrnovaly i viditelné i skryté buňky. Toto nastavení řídí vykreslování diagramu; neskryje ani neodkryje řádky či sloupce pracovního listu.

[Vzorková prezentace](hidden-source-data.pptx) obsahuje sloupcový diagram jako první tvar na první snímku. Vložený pracovní list `Sheet1` obsahuje následující zdrojový rozsah `A1:C4`. Řádek 3 a sloupec C jsou skryté, ale jejich buňky stále obsahují hodnoty.

| Řádek listu | A: Měsíc | B: Maloobchod | C: Velkoobchod (skrytý sloupec) |
| --- | --- | --- | --- |
| 2 | Leden | 10 | 30 |
| 3 (skrytý řádek) | Únor | 40 | 60 |
| 4 | Březen | 20 | 50 |

Přístup ke zdrojovým buňkám získáte přes [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/) a čtením [IChartDataCell::get_IsHidden](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/get_ishidden/) pro kontrolu jejich skrytého stavu. Tato vlastnost je pouze pro čtení. V tomto souboru je B2 viditelná, B3 patří ke skrytému řádku a C2 ke skrytému sloupci; příklad vytiskne `False`, `True` a `True`.

Pro tento příklad obnovte data diagramu po změně nastavení vykreslování: zachovejte vložený sešit pomocí [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) a načtěte jej pomocí [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/). Když zahrnujete všechny buňky, použijte také [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) k obnovení kompletního rozsahu, včetně skryté kategorie Únor. Pouze změna příznaku není dostačující k obnovení uložených dat diagramu a popisků kategorií v tomto příkladu.

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

        // Obnovit data diagramu z vloženého sešitu.
        workbookStream->set_Position(0);
        chart->get_ChartData()->WriteWorkbookStream(workbookStream);
        if (!visibleOnly)
        {
            // Obnovit kompletní zdrojový rozsah, včetně skrytých kategorií.
            chart->get_ChartData()->SetRange(u"Sheet1!$A$1:$C$4");
        }

        auto outputPath = visibleOnly ? u"hidden_cells_True.pptx" : u"hidden_cells_False.pptx";
        presentation->Save(outputPath, Export::SaveFormat::Pptx);
    }
}
else
{
    Console::WriteLine(u"První tvar není diagram.");
}
```

Příklad ukládá dvě verze prezentace: jednu pouze s viditelnými hodnotami maloobchodu (10 a 20) a druhou se všemi šesti hodnotami. Obrázky níže ilustrují oba režimy vykreslování. Řádek 3 a sloupec C zůstávají skryté v obou vložených sešitech.

| Pouze viditelné buňky (`true`) | Všechny buňky (`false`) |
| --- | --- |
| ![Pouze viditelné buňky: Hodnoty maloobchodu 10 a 20 pro leden a březen.](hidden_cells_True.png) | ![Všechny buňky: Hodnoty maloobchodu a velkoobchodu pro leden, únor a březen.](hidden_cells_False.png) |

Skrytá buňka obsahující hodnotu se liší od prázdné buňky. [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) řídí, jak se zobrazují chybějící hodnoty; nezahrnuje ani nevynechává skrytá zdrojová data. Viz [Ovládání zobrazení prázdných buněk](/slides/cs/cpp/chart-series/#control-the-display-of-empty-cells) pro příklad.

## **Získat rozsah dat diagramu**

Před aktualizací dat sešitu v existující prezentaci prozkoumejte zdrojové rozsahy, abyste identifikovali, které buňky pracovního listu každý diagram používá. Metoda [IChartData::GetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/getrange/) vrací aktuální rozsah dat jako vzorec kvalifikovaný pracovním listem, např. `Sheet1!$A$1:$D$5`. Zde `Sheet1` je název listu, `!` jej odděluje od rozsahu buněk a `$A$1:$D$5` určuje buňky A1 až D5 včetně. Znak `$` označuje absolutní odkazy na řádky a sloupce.

Metoda čte aktuální rozsah, aniž by měnila diagram nebo jeho sešit. Pokud diagram nepoužívá sešit jako zdroj dat, vyvolá [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/). Další informace najdete v [referenci API ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/).

Tento příklad otevře prezentaci a zkontroluje tvary přímo na každém snímku, zda jsou diagramy. Vytiskne název každého diagramu a jeho zdrojový rozsah. Pokud diagram nepoužívá sešit, vytiskne zprávu a pokračuje k dalšímu diagramu.

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

## **Číst a zapisovat data diagramu ze sešitu**

Aspose.Slides for C++ poskytuje metody [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) a [WriteWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/writeworkbookstream/), které umožňují číst a zapisovat sešity dat diagramu (obsahující data diagramu upravená pomocí Aspose.Cells). **Poznámka** – data diagramu musí být uspořádána stejným způsobem nebo mít strukturu podobnou zdroji.

Tento příklad používá prezentaci s diagramem jako první tvar na první snímku. Načte vložený sešit do proudu, vymaže existující řady a kategorie a zapíše stejný sešit zpět. Změny zůstávají v paměti; příklad neukládá prezentaci.

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

### **Ověřit rozložení diagramu po úpravě sešitu**

Když nahradíte vložený sešit upraveným, diagram si ponechá původní kolekce řad a kategorií. Tento nesoulad může způsobit selhání [IChart::ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/validatechartlayout/) s chybou indexu mimo rozsah. Před zápisem aktualizovaného sešitu do diagramu vymažte existující řady a kategorie. Tento příklad používá diagram, který je první tvar na první snímku. Komentář označuje místo, kde by úprava sešitu proběhla; spustitelný příklad zapíše původní sešit zpět a ověří rozložení v paměti.

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

    // Upravte zde proud sešitu, například pomocí Aspose.Cells.

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

Vymazání kolekcí odstraní zastaralé odkazy na data před zápisem sešitu zpět. Před použitím diagramu znovu vytvořte potřebné mapování řad a kategorií pro aktualizovaný sešit.

## **Nastavit buňku sešitu jako popisek dat diagramu**

Můžete použít text z buněk sešitu jako popisky dat diagramu.

Tento příklad přidá bublinový diagram s výchozími daty na první snímek existující prezentace. Použije buňky A10:A12 na listu 0 pro první tři popisky v první řadě, povolí popisky z buněk a uloží aktualizovanou prezentaci.

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

## **Správa pracovních listů**

Metoda [IChartDataWorkbook::get_Worksheets](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/get_worksheets/) poskytuje přístup k pracovním listům v sešitu diagramu. Tento příklad vytvoří koláčový diagram s výchozími daty a vytiskne název každého pracovního listu do konzole.

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

## **Specifikovat typ zdroje dat**

Tento příklad vytvoří 3D sloupcový diagram s výchozími daty a nastaví dva názvy řad pomocí různých zdrojů dat. První název používá řetězcový literál; druhý používá buňku C1 na listu 0. Výčtový typ [DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) vybírá zdroj pro každý název. Příklad uloží prezentaci s aktualizovanými názvy řad.

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

## **Detekce nepodporovaných formátů vložených sešitů**

Aspose.Slides nepodporuje formát Excel binárního sešitu (.xlsb), který může být vložen v některých diagramech. Můžete použít metodu [get_EmbeddedWorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_embeddedworkbooktype/) na [IChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/) spolu s výčtem [WorkbookType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/workbooktype/) k detekci nepodporovaných formátů a přeskočení těchto diagramů. Tento příklad prozkoumá tvary na první snímku existující prezentace, přeskočí tvary, které nejsou diagramy, a vytiskne diagnostickou zprávu pro každý diagram s vloženým sešitem .xlsb.

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

    // Přečtěte nebo upravte podporovaná data sešitu diagramu zde.
}
```

## **Externí sešit**

Aspose.Slides podporuje použití externích sešitů jako zdroje dat pro diagramy.

### **Vytvořit externí sešit**

Použijte [ReadWorkbookStream](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/readworkbookstream/) a [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) k exportu vloženého sešitu diagramu do souboru a propojení diagramu s tímto externím sešitem.

Tento příklad vytvoří koláčový diagram s výchozími daty a exportuje jeho sešit. Před přiřazením externího sešitu jako zdroje dat diagramu uzavře výstupní proud a poté uloží propojenou prezentaci.

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

### **Nastavit externí sešit**

Pomocí metody [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) můžete přiřadit externí sešit diagramu jako jeho zdroj dat. Tato metoda může být také použita k aktualizaci cesty k externímu sešitu (pokud byl přesunut).

I když nelze upravovat data v sešitech uložených na vzdálených místech nebo zdrojích, lze takové sešity stále použít jako externí zdroj dat. Pokud je zadána relativní cesta k externímu sešitu, automaticky se převede na plnou cestu.

Tento příklad používá externí sešit, jehož pracovní list pojmenovaný `Sheet1` obsahuje název řady v B1, názvy kategorií v A2:A4 a číselné hodnoty v B2:B4. Příklad vytvoří koláčový diagram, propojí sešit a použije [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setrange/) k namapování A1:B4 na jednu řadu a tři kategorie. Uloží prezentaci s propojeným diagramem.

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

Parametr `updateChartData` metody [SetExternalWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/setexternalworkbook/) určuje, zda se sešit načte.

* Když je `updateChartData` `false`, aktualizuje se pouze cesta k sešitu. Data diagramu nejsou načtena ani aktualizována ze cílového sešitu, takže sešit může být nedostupný.
* Když je `updateChartData` `true`, data diagramu jsou aktualizována ze cílového sešitu.

Následující příklad přiřadí zástupnou URL s `updateChartData` nastaveným na `false`. Zachová výchozí data koláčového diagramu a uloží prezentaci bez načtení nedostupného sešitu.

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

### **Získat cestu k externímu zdroji dat sešitu diagramu**

Pro identifikaci sešitu připojeného k diagramu zkontrolujte, zda diagram používá externí zdroj dat, a získejte jeho cestu.

Tento příklad prozkoumá první tvar na první snímku prezentace s propojeným externím sešitem. Pokud se jedná o diagram propojený s externím sešitem, vytiskne [get_ExternalWorkbookPath](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_externalworkbookpath/) do konzole. Poté uloží kopii prezentace.

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

### **Upravit data diagramu**

Můžete upravovat data v externích sešitech stejným způsobem, jako měníte obsah interních sešitů. Když externí sešit nelze načíst, je vyvolána výjimka.

Tento příklad používá diagram, který je první tvar na první snímku a je propojen s dostupným externím sešitem. Nastaví hodnotu založenou na buňce prvního datového bodu v první řadě na 100 a uloží aktualizovanou prezentaci. Úprava hodnot buněk může aktualizovat propojený externí soubor XLSX, proto použijte kopii, pokud potřebujete zachovat původní sešit.

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

### **Obnovit sešit z vyrovnávací paměti diagramu**

Pokud diagram používá externí sešit, který chybí nebo není dostupný, Aspose.Slides může rekonstruovat sešit diagramu z dat uložených v cache prezentace. Vytvořte [LoadOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/), nakonfigurujte jej pomocí [set_SpreadsheetOptions](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_spreadsheetoptions/), a zavolejte [ISpreadsheetOptions::set_RecoverWorkbookFromChartCache](https://reference.aspose.com/slides/cpp/aspose.slides/ispreadsheetoptions/set_recoverworkbookfromchartcache/) s `true` před otevřením prezentace.

Následující C++ příklad obnoví data sešitu pro diagram, který je první tvar na první snímku a odkazuje na nedostupný externí sešit. Přistupuje k obnoveným datům přes [IChart::get_ChartData](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_chartdata/) a [IChartData::get_ChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_chartdataworkbook/):

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

    // Přečtěte nebo upravte zde obnovená data sešitu.
}
else
{
    Console::WriteLine(u"The first shape is not a chart.");
}
```

Pokud je externí sešit nedostupný a obnovení je zakázáno, Aspose.Slides vyvolá [System::InvalidOperationException](https://reference.aspose.com/slides/cpp/system/details_invalidoperationexception/). Povolit obnovení použijte pouze tehdy, když je použití uložených dat diagramu přijatelnou alternativou, protože cache nemusí obsahovat změny provedené v externím sešitu po poslední aktualizaci prezentace.

## **Často kladené otázky**

**Mohu zjistit, zda je konkrétní diagram propojen s externím nebo vloženým sešitem?**

Ano. Diagram má [typ zdroje dat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_datasourcetype/) a [cestu k externímu sešitu](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/); pokud je zdroj externí sešit, můžete přečíst úplnou cestu a ověřit, že se používá externí soubor.

**Jsou podporovány relativní cesty k externím sešitum a jak jsou uloženy?**

Ano. Pokud zadáte relativní cestu, automaticky se převede na absolutní cestu. Prezentace ukládá absolutní cestu v souboru PPTX, takže přesunutí sešitu může vyžadovat aktualizaci odkazu.

**Mohou být sešity umístěny na síťových zdrojích/sdílených složkách?**

Ano, takové sešity lze použít jako externí zdroj dat. Úprava vzdálených sešitů přímo z Aspose.Slides však není podporována – mohou být použity jen jako zdroj.

**Přepisuje Aspose.Slides externí soubor XLSX při ukládání prezentace?**

Prezentace ukládá [odkaz na externí soubor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/get_externalworkbookpath/). Úpravy dat diagramu založených na buňkách mohou také aktualizovat propojený lokální soubor XLSX. Použijte kopii sešitu, pokud musí originál zůstat beze změny.

**Co mám dělat, pokud je externí soubor chráněn heslem?**

Aspose.Slides neakceptuje heslo při propojení. Běžný přístup je odstranit ochranu předem nebo připravit dešifrovanou kopii (např. pomocí [Aspose.Cells](https://reference.aspose.com/cells/cpp/)) a propojit se na tuto kopii.

**Může více diagramů odkazovat na stejný externí sešit?**

Ano. Každý diagram ukládá svůj vlastní odkaz. pokud všechny odkazují na stejný soubor, aktualizace tohoto souboru se projeví ve všech diagramech při dalším načtení dat.