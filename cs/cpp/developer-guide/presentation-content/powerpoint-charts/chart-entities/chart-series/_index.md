---
title: Správa datových sérií diagramu v prezentacích v C++
linktitle: Datové série
type: docs
url: /cs/cpp/chart-series/
keywords:
- série diagramu
- překrytí série
- barva série
- barva kategorie
- název série
- datový bod
- mezera série
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Naučte se, jak spravovat série diagramů, datové body, buňky sešitu, formátování, překrytí, šířku mezery a záporné hodnoty v prezentacích pomocí C++."
---
## **Přehled**

Diagram ukládá svá vykreslená data do sešitu dat diagramu. [IChartSeries](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseries/) představuje jednu sadu souvisejících hodnot a každý [IChartDataPoint](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatapoint/) v sérii odkazuje na jednu nebo více buněk sešitu. Objekt [IChartCategory](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartcategory/) poskytuje popisky nebo hodnoty seskupení sdílené sériemi. Název série, kategorie a hodnoty bodů jsou tedy propojeny s objekty [IChartDataCell](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatacell/), místo aby byly uloženy jen jako zobrazovaný text.

Pro typický kategoriální diagram výchozí sešit používá řádek 0 pro názvy sérií, sloupec 0 pro názvy kategorií a zbývající buňky pro hodnoty sérií. Indexy listu, řádku a sloupce předávané metodě [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) jsou nulové (zero‑based). Toto rozvržení je užitečné, když vytváříte diagram s výchozími daty, ale nepředpokládejte, že každý existující diagram jej používá. U načtené prezentace si před změnou hodnot v sešitu prohlédněte buňky, na které odkazují série, kategorie a datové body.

Nastavení diagramu má tři různé úrovně:

- Nastavení na úrovni série, například [IChartSeries::get_Format](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseries/get_format/), poskytuje výchozí vzhled pro všechny body v jedné sérii.
- Nastavení datového bodu, například [IChartDataPoint::get_Format](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatapoint/get_format/), přepíše vzhled série pro jeden bod.
- Skupinová nastavení se vztahují na kompatibilní série, které patří do stejné [IChartSeriesGroup](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseriesgroup/). Přistupujte ke skupině přes [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/), pokud potřebujete nastavit možnosti jako překrytí nebo šířka mezery.

Pokud není nastaveno žádné explicitní vyplnění bodu nebo série, určuje automatický vzhled styl a motiv diagramu. Pokud jsou přítomny jak formátování série, tak bodu, má přednost formátování bodu.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Nastavit překrytí série diagramu**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseries/get_overlap/) udává, jak moc se pruhy nebo sloupce překrývají v 2‑D diagramu, v rozsahu od -100 do 100 procent. Jedná se o pouze pro čtení projekci nastavení na nadřazenou skupinu sérií. Zavolejte [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) pro aktualizaci všech kompatibilních sérií v této skupině. Tato možnost se vztahuje na typy diagramů, které zobrazují seskupené pruhy nebo sloupce; neovlivňuje nesouvisející skupiny sérií v kombinovaném diagramu.

Následující příklad nastavuje překrytí pro skupinu, která obsahuje první sérii:

```cpp
#include <cstdint>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int8_t overlapPercent = 30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

// Nový diagram obsahuje ukázkové série, kategorie a hodnoty.
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_Overlap(overlapPercent);

presentation->Save(u"series_overlap.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Překrytí série](series_overlap.png)

## **Změnit barvu výplně série**

Použijte [IChartSeries::get_Format](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseries/get_format/) k nastavení výchozí výplně pro celou sérii. Pokud má bod již explicitní výplň, jeho nastavení [IChartDataPoint::get_Format](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatapoint/get_format/) přepíše výplň série pro tento bod.

Následující příklad aplikuje jednolitou modrou výplň na první sérii:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto seriesColor = Color::get_Blue();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);

presentation->Save(u"series_color.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Barva série](series_color.png)

## **Změnit název série**

Název série je uložen v sešitu dat diagramu a obvykle se zobrazuje v legendě. Ve výchozím sešitu vytvořeném pro seskupený sloupcový diagram je buňka B1 v řádku 0, sloupci 1 a obsahuje název první série. Pojmenované konstanty v následujícím příkladu tuto strukturu explicitně uvádějí:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int seriesNameRowIndex = 0;
const int firstSeriesColumnIndex = 1;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
auto seriesNameCell = workbook->GetCell(worksheetIndex, seriesNameRowIndex, firstSeriesColumnIndex);
auto seriesName = ObjectExt::Box<String>(u"Revenue");
seriesNameCell->set_Value(seriesName);

presentation->Save(u"series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Můžete také aktualizovat buňku, na kterou již odkazuje [IChartSeries::get_Name](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseries/get_name/). Tento přístup se vyhýbá předpokládání konkrétního řádku a sloupce v existujícím diagramu:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCellCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IStringChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int firstNameCellIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto seriesNameCells = series->get_Name()->get_AsCells();
auto seriesNameCell = seriesNameCells->idx_get(firstNameCellIndex);
auto seriesName = ObjectExt::Box<String>(u"Revenue");
seriesNameCell->set_Value(seriesName);

presentation->Save(u"series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Název série](series_name.png)

## **Získat automatickou barvu výplně série**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) vrací barvu vypočtenou z indexu série a stylu diagramu. Toto je barva použita, když výplň série nebyla explicitně definována. Volání metody načte vypočtenou barvu; nepřiřadí novou výplň.

Následující příklad vypíše automatickou barvu každé výchozí série:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Presentation;
using System::Console;
using System::String;

const int firstSlideIndex = 0;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
const int seriesCount = seriesCollection->get_Count();
for (int seriesIndex = 0; seriesIndex < seriesCount; seriesIndex++)
{
    auto series = seriesCollection->idx_get(seriesIndex);
    auto automaticColor = series->GetAutomaticSeriesColor();
    auto colorName = automaticColor.get_Name();
    auto outputLine = String::Format(u"Series {0}: {1}", seriesIndex, colorName);
    Console::WriteLine(outputLine);
}

presentation->Dispose();
```

Příklad výstupu pro výchozí styl diagramu:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Přesné barvy závisí na stylu a motivu diagramu.

## **Nastavit invertovanou barvu výplně pro sérii diagramu**

Pro pruhové, sloupcové a bublinové série může [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) zobrazit záporné hodnoty s jinou výplní. Nastavte běžnou výplň série na plnou, povolte inverzi a přiřaďte barvu záporné hodnoty pomocí [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). Záporná čísla zůstávají v sešitu nezměněna; mění se jen jejich barva zobrazení.

Následující příklad nahrazuje výchozí data diagramu jednou sérií. Řádek 0 listu obsahuje název série, sloupec 0 obsahuje názvy kategorií a sloupec 1 obsahuje hodnoty:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;
using System::ObjectExt;
using System::String;

const int firstSlideIndex = 0;
const int worksheetIndex = 0;
const int headerRowIndex = 0;
const int categoryColumnIndex = 0;
const int firstSeriesColumnIndex = 1;
const int firstDataRowIndex = 1;
const int categoryCount = 3;

const String categoryNames[] = {u"Category 1", u"Category 2", u"Category 3"};
const int seriesValues[] = {-20, 50, -30};

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();

auto seriesCollection = chartData->get_Series();
seriesCollection->Clear();
chartData->get_Categories()->Clear();

auto seriesName = ObjectExt::Box<String>(u"Series 1");
auto seriesNameCell = workbook->GetCell(worksheetIndex, headerRowIndex, firstSeriesColumnIndex, seriesName);
auto chartType = chart->get_Type();
auto series = seriesCollection->Add(seriesNameCell, chartType);

for (int categoryIndex = 0; categoryIndex < categoryCount; categoryIndex++)
{
    const int dataRowIndex = firstDataRowIndex + categoryIndex;
    auto categoryName = categoryNames[categoryIndex];
    const int seriesValue = seriesValues[categoryIndex];

    auto boxedCategoryName = ObjectExt::Box<String>(categoryName);
    auto categoryCell = workbook->GetCell(worksheetIndex, dataRowIndex, categoryColumnIndex, boxedCategoryName);
    chartData->get_Categories()->Add(categoryCell);

    auto boxedSeriesValue = ObjectExt::Box<int>(seriesValue);
    auto valueCell = workbook->GetCell(worksheetIndex, dataRowIndex, firstSeriesColumnIndex, boxedSeriesValue);
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto automaticSeriesColor = series->GetAutomaticSeriesColor();
auto invertedSeriesColor = Color::get_Red();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(automaticSeriesColor);
series->set_InvertIfNegative(true);
series->get_InvertedSolidFillColor()->set_Color(invertedSeriesColor);

presentation->Save(u"inverted_solid_fill_color.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Invertovaná plná výplň](inverted_solid_fill_color.png)

Inverzi můžete povolit pro jeden bod pomocí [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/). V následujícím příkladu je inverze pro sérii vypnutá a povolena pouze pro vybraný bod. Bod také dostane zápornou hodnotu, aby byl efekt viditelný:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/Chart/IFormat.h>
#include <DOM/FillType.h>
#include <DOM/IChart.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::FillType;
using Aspose::Slides::Presentation;
using System::Drawing::Color;
using System::ObjectExt;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 2;
const int negativeValue = -30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto automaticSeriesColor = series->GetAutomaticSeriesColor();
auto invertedSeriesColor = Color::get_Red();
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(automaticSeriesColor);
series->get_InvertedSolidFillColor()->set_Color(invertedSeriesColor);
series->set_InvertIfNegative(false);

auto dataPoint = series->get_DataPoint(targetDataPointIndex);
auto boxedNegativeValue = ObjectExt::Box<int>(negativeValue);
dataPoint->get_YValue()->get_AsCell()->set_Value(boxedNegativeValue);
dataPoint->set_InvertIfNegative(true);

presentation->Save(u"data_point_invert_color_if_negative.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Vymazat konkrétní hodnotu datového bodu**

Aby byl jeden bod prázdný, aniž byste odstranili ostatní body, nastavte buňku sešitu, která ho podporuje, na `nullptr`. Pro sloupcový diagram je vykreslená hodnota dostupná přes [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/). Datový bod zůstane ve stejné pozici kategorie, ale diagram bude jeho hodnotu považovat za prázdnou podle nastavení prázdných hodnot diagramu.

Následující příklad vymaže jen druhý bod v první sérii:

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IDoubleChartValue.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const int targetDataPointIndex = 1;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
auto dataPoint = series->get_DataPoint(targetDataPointIndex);
dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);

presentation->Save(u"clear_data_point_value.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Scatter diagramy používají oddělené buňky X a Y a bublinové diagramy také používají buňku velikosti. Vymažte pouze buňku, která představuje hodnotu, kterou chcete odstranit. Nezavolejte [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatapointcollection/clear/), pokud chcete zachovat ostatní body, protože tato metoda odstraní všechny datové body ze sbírky.

## **Řídit zobrazování prázdných buněk**

Skryté buňky, které obsahují hodnoty, jsou odlišným případem než prázdné buňky. Pro zahrnutí nebo vyloučení dat ze skrytých řádků a sloupců listu viz [Include Data from Hidden Rows and Columns](/slides/cs/cpp/chart-workbook/#include-data-from-hidden-rows-and-columns).

Prázdná buňka sešitu představuje chybějící data; buňka obsahující `0` představuje známou číselnou hodnotu. Zavolejte [IChartDataCell::set_Value](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatacell/set_value/) s `nullptr`, aby byla buňka prázdná. Číselná nula zůstane nulou bez ohledu na nastavení prázdné buňky.

Použijte [IChart::set_DisplayBlanksAs](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichart/set_displayblanksas/) k výběru, jak má diagram zobrazovat prázdné buňky. Toto nastavení se vztahuje na celý diagram. Mění způsob, jakým jsou prázdná místa vykreslována, aniž by se prázdná buňka sešitu vyplňovala nulou nebo interpolovanou hodnotou.

Následující samostatný příklad vytvoří čárový diagram s jednou sérií, vymaže hodnotu pro den 3 a uloží stejný diagram ve všech režimech. Vstupní soubor není vyžadován. [IChartDataWorkbook](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdataworkbook/) používá list 0, sloupec 0 pro popisky kategorií a sloupec 1 pro hodnoty; řádek 0 obsahuje název série. Konečná data jsou `10, 20, empty, 30, 40`.

```cpp
#include <array>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DisplayBlanksAsType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using System::ObjectExt;
using System::String;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::LineWithMarkers, 40.0f, 40.0f, 640.0f, 400.0f);
auto chartData = chart->get_ChartData();
auto workbook = chartData->get_ChartDataWorkbook();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

auto seriesName = ObjectExt::Box<String>(u"Measurements");
auto seriesNameCell = workbook->GetCell(0, 0, 1, seriesName);
auto series = chartData->get_Series()->Add(seriesNameCell, chart->get_Type());
auto values = std::array<int, 5>{10, 20, 25, 30, 40};

for (auto i = 0; i < values.size(); i++)
{
    auto categoryName = String::Format(u"Day {0}", i + 1);
    auto boxedCategoryName = ObjectExt::Box<String>(categoryName);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, boxedCategoryName);
    chartData->get_Categories()->Add(categoryCell);
    auto boxedValue = ObjectExt::Box<int>(values[i]);
    auto valueCell = workbook->GetCell(0, i + 1, 1, boxedValue);
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

// Nechte den 3 skutečně prázdný, přičemž zachováte jeho kategorii a datový bod.
workbook->GetCell(0, 3, 1)->set_Value(nullptr);

auto modes = std::array<DisplayBlanksAsType, 3>{DisplayBlanksAsType::Gap, DisplayBlanksAsType::Zero, DisplayBlanksAsType::Span};
for (auto mode : modes)
{
    chart->set_DisplayBlanksAs(mode);
    auto outputPath = String::Format(u"empty_cells_{0}.pptx", mode);
    presentation->Save(outputPath, SaveFormat::Pptx);
}

presentation->Dispose();
```

Každý výstupní soubor ukládá režim přiřazený před uložením: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` a `empty_cells_Span.pptx`. Pro uložení pouze jedné verze přiřaďte požadovaný režim a prezentaci uložte jednou místo iterace přes režimy.

Srovnání níže ukazuje stejná data ve všech třech souborech. Den 3 je v sešitu v každém případě prázdný:

![Čárové diagramy se stejnými daty: Gap přeruší čáru v den 3, Zero spustí čáru na nulu a Span spojuje den 2 s dnem 4.](display_blanks_as.png)

Viditelný efekt závisí na typu diagramu. Čárový diagram usnadňuje porovnání všech tří režimů. Pruhové a sloupcové diagramy nemají čáru, která by spojovala chybějící kategorii, takže `Span` nemůže vytvořit spojující úsek zobrazený výše; chybějící sloupec a sloupec s nulovou výškou mohou také vypadat podobně. Podobně scatter diagram s jen značkami nemá spojující čáru. Neočekávejte tři odlišné výsledky pro každý typ diagramu; zkontrolujte výstup pro typ, který používáte.

## **Nastavit šířku mezery mezi sériemi**

Šířka mezery je prostor mezi sousedními pruhovými nebo sloupcovými shluky, vyjádřený jako procento šířky pruhu nebo sloupce. Podobně jako překrytí patří k nadřazené skupině sérií, nikoli k jedné sérii. Zavolejte [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) jednou pro skupinu. Větší hodnota vytvoří více místa mezi shluky; menší hodnota je učiní hustší.

Následující příklad mění šířku mezery a uloží jen finální prezentaci:

```cpp
#include <cstdint>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeriesGroup.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using Aspose::Slides::Charts::ChartType;
using Aspose::Slides::Export::SaveFormat;
using Aspose::Slides::Presentation;

const int firstSlideIndex = 0;
const int firstSeriesIndex = 0;
const uint16_t gapWidthPercent = 30;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(firstSlideIndex);

auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_GapWidth(gapWidthPercent);

presentation->Save(u"gap_width_30.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Šířka mezery](gap_width.png)

## **FAQ**

**Které typy diagramů podporují datové série?**

Všechny typy diagramů zastoupené výčtem [ChartType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/charttype/) používají data diagramu, ale jejich série nemají všechny stejnou strukturu hodnot ani nastavení. Například kategoriální diagramy používají kategorie a hodnoty, scatter diagramy používají hodnoty X a Y a bublinové diagramy přidávají velikosti bublin. Použijte metodu tvorby datových bodů, která odpovídá typu série. Možnosti jako překrytí a šířka mezery platí jen pro kompatibilní pruhové nebo sloupcové skupiny.

**Co je skupina sérií diagramu?**

[IChartSeriesGroup](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseriesgroup/) obsahuje kompatibilní série, které sdílejí nastavení vykreslování na úrovni skupiny. Kombinovaný diagram může obsahovat více než jednu skupinu, takže změna skupiny dosažené přes jednu sérii nutně neovlivní všechny série v diagramu.

**Obsahuje nově vytvořený diagram výchozí data?**

Ano. Ve výchozím nastavení [IShapeCollection::AddChart](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/addchart/) vytváří ukázkové série, kategorie a hodnoty. Můžete upravit tyto buňky nebo vymazat jak sérii, tak kolekci kategorií před přidáním zcela vlastního datového souboru. Přetížení může také vytvořit diagram bez výchozích dat.

**Jak jsou objekty diagramu propojeny s buňkami sešitu?**

Názvy sérií, popisky kategorií a hodnoty datových bodů odkazují na buňky v [IChartDataWorkbook](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdataworkbook/). Změna odkazované buňky aktualizuje odpovídající prvek diagramu. Při vytváření vlastních dat udržujte řádky kategorií a řádky hodnot sérií zarovnané, aby každý bod byl vykreslen pod zamýšlenou kategorií.

**Jak vymazat jeden bod místo celé série?**

Nastavte příslušnou buňku hodnoty na `nullptr`, aby bod zachoval svou pozici kategorie jako prázdný bod. Zavolejte [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) pouze tehdy, když máte v úmyslu odstranit všechny body z této série. Pokud také odstraňujete kategorie, aktualizujte všechny série, aby jejich hodnoty zůstaly zarovnané s kolekcí kategorií.

**Jak jsou prázdné body zobrazovány?**

Výsledek závisí na typu diagramu a [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichart/get_displayblanksas/). Podporované diagramy mohou prázdná místa zobrazovat jako mezery, jako nulové hodnoty nebo spojením sousedních bodů. Vyberte nastavení, které odpovídá významu chybějících dat ve vaší prezentaci. Viz [Control the Display of Empty Cells](#control-the-display-of-empty-cells) pro kompletní příklad a vizuální srovnání.

**Jak jsou záporné hodnoty formátovány?**

U podporovaných pruhových, sloupcových a bublinových sérií zavolejte [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) a nastavte barvu pomocí [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). Chování pro jednotlivý bod můžete přepsat pomocí [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/). Tyto metody ovlivňují formátování, nikoli uložené číselné hodnoty.

**Které formátování má přednost, když je formátována jak série, tak bod?**

Explicitní formátování datového bodu má přednost pro tento bod. Ostatní body nadále používají explicitní formát série nebo, pokud formát série není definován, automatický styl a motiv diagramu. Skupinová nastavení jako překrytí a šířka mezery řídí rozvržení a nejsou přepisovány na úrovni bodu.

**Existuje limit, kolik sérií může diagram obsahovat?**

Aspose.Slides nekladá samostatný pevný limit počtu sérií. V praxi určují užitečný limit omezení souboru prezentace, dostupná paměť, čas renderování a čitelnost diagramu.

**Co změnit, když jsou sloupce příliš blízko u sebe nebo příliš daleko?**

Zavolejte [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) na příslušné nadřazené skupině sérií. Zvyšte hodnotu pro zvětšení prostoru mezi shluky nebo ji snižte, aby se shluky přiblížily.