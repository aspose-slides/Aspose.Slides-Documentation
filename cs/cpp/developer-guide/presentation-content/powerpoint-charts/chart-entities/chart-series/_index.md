---
title: Správa datových sérií grafu v prezentacích v C++
linktitle: Datové série
type: docs
url: /cs/cpp/chart-series/
keywords:
- série grafu
- překrytí sérií
- barva série
- barva kategorie
- název série
- datový bod
- mezera mezi sériemi
- PowerPoint
- prezentace
- C++
- Aspose.Slides
description: "Zjistěte, jak spravovat série grafu, datové body, buňky sešitu, formátování, překrytí, šířku mezery a záporné hodnoty v prezentacích pomocí C++."
---
## **Přehled**

Graf ukládá svá vykreslená data do sešitu s daty grafu. [IChartSeries](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseries/) představuje jeden soubor souvisejících hodnot a každá [IChartDataPoint](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatapoint/) v sérii odkazuje na jednu nebo více buněk sešitu. Objekt [IChartCategory](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartcategory/) poskytuje štítky nebo skupinové hodnoty sdílené sérií. Název série, kategorie a hodnoty bodů jsou proto propojeny s objekty [IChartDataCell](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatacell/) spíše než aby byly uloženy jen jako zobrazovaný text.

Pro typický kategoriový graf výchozí sešit používá řádek 0 pro názvy sérií, sloupec 0 pro názvy kategorií a zbývající buňky pro hodnoty sérií. Indexy listu, řádku a sloupce předávané do [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) jsou nulové (zero-based). Toto rozložení je užitečné, když vytvoříte graf s výchozími daty, ale nepředpokládejte, že každý existující graf jej používá. Pro načtenou prezentaci zkontrolujte buňky, na které odkazují série, kategorie a datové body, před změnou hodnot v sešitu.

Nastavení grafu má tři různé úrovně:

- Nastavení na úrovni série, například [IChartSeries::get_Format](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseries/get_format/), poskytuje výchozí vzhled pro všechny body v jedné sérii.
- Nastavení datového bodu, například [IChartDataPoint::get_Format](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatapoint/get_format/), přepíše vzhled série pro jeden bod.
- Nastavení skupiny se vztahuje na kompatibilní série, které patří do stejné [IChartSeriesGroup](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseriesgroup/). Přístup ke skupině přes [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/), pokud potřebujete nastavit možnosti jako překrytí nebo šířka mezery.

Pokud není nastaveno žádné explicitní vyplnění bodu nebo série, určuje automatický vzhled styl a motiv grafu. Pokud jsou přítomna jak formátování série, tak formátování bodu, formátování bodu má přednost pro tento bod.

![graf-serií-powerpoint](chart-series-powerpoint.png)

## **Nastavení překrytí sérií grafu**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseries/get_overlap/) uvádí, jak moc se překrývají sloupce nebo pruhy v 2D grafu, v rozmezí od -100 do 100 procent. Jedná se o projekci nastavení ve skupině nadřazené série, která je pouze ke čtení. Zavolejte [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) pro aktualizaci všech kompatibilních sérií v této skupině. Tato možnost se vztahuje na typy grafů, které zobrazují seskupené sloupce nebo pruhy; neovlivňuje nesouvisející skupiny sérií v kombinovaném grafu.

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

// Nový graf obsahuje ukázkové série, kategorie a hodnoty.
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_Overlap(overlapPercent);

presentation->Save(u"series_overlap.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Výsledek:

![Překrytí série](series_overlap.png)

## **Změna barvy výplně série**

Použijte [IChartSeries::get_Format](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseries/get_format/) k nastavení výchozí výplně pro celou sérii. Pokud má bod již explicitní výplň, její nastavení [IChartDataPoint::get_Format](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatapoint/get_format/) přepíše výplň série pro tento bod.

Následující příklad aplikuje plnou modrou výplň na první sérii:

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

## **Změna názvu série**

Název série je uložen v sešitu s daty grafu a obvykle se zobrazuje v legendě. Ve výchozím sešitu vytvořeném pro seskupený sloupcový graf je buňka B1 v řádku 0, sloupci 1 a obsahuje název první série. Pojmenované konstanty v následujícím příkladu tuto strukturu explicitně vymezují:

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

Můžete také aktualizovat buňku, na kterou již odkazuje [IChartSeries::get_Name](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseries/get_name/). Tento přístup se vyhýbá předpokladu konkrétního řádku a sloupce v existujícím grafu:

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

## **Získání automatické barvy výplně série**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) vrací barvu vypočítanou z indexu série a stylu grafu. Toto je barva používaná, když výplň série není explicitně definována. Volání metody pouze načte vypočítanou barvu; nepřiřazuje novou výplň.

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

Příklad výstupu pro výchozí styl grafu:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

Přesné barvy závisí na stylu grafu a motivu.

## **Nastavení inverzní barvy výplně pro sérii grafu**

Pro série sloupců, pruhů a bublin může [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) zobrazit záporné hodnoty s odlišnou výplní. Nastavte běžnou výplň série na plnou, povolte inverzi a přiřaďte barvu záporných hodnot pomocí [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). Záporná čísla zůstávají v sešitu nezměněna; mění se jen jejich barva při zobrazení.

Následující příklad nahrazuje výchozí data grafu jednou sérií. Řádek 0 listu obsahuje název série, sloupec 0 obsahuje názvy kategorií a sloupec 1 obsahuje hodnoty:

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

![Inverzní plná barva výplně](inverted_solid_fill_color.png)

Můžete povolit inverzi pro jeden bod pomocí [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/). V následujícím příkladu je inverze pro sérii zakázána a povolena pouze pro vybraný bod. Bod má také přiřazenu zápornou hodnotu, aby byl efekt viditelný:

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

## **Vymazání konkrétní hodnoty datového bodu**

Aby byl jeden bod prázdný, aniž byste odstraňovali ostatní body, nastavte jeho podkladovou buňku v sešitu na `nullptr`. Pro sloupcový graf je vykreslená hodnota dostupná pomocí [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/). Datový bod zůstává na stejném místě kategorie, ale graf s ohledem na nastavení prázdných hodnot považuje jeho hodnotu za prázdnou.

Následující příklad vymaže pouze druhý bod v první sérii:

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

Rozptylové grafy používají samostatné buňky X a Y a bublinové grafy také používají buňku velikosti. Vymažte jen buňku, která představuje hodnotu, kterou chcete odstranit. Nevolajte [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) pokud chcete zachovat ostatní body, protože tato metoda odstraní každý datový bod ze sbírky.

## **Nastavení šířky mezery sérií**

Šířka mezery je prostor mezi sousedními shluky sloupců nebo pruhů, vyjádřený jako procento šířky sloupce nebo pruhu. Stejně jako překrytí patří k nadřazené skupině sérií, nikoli k jedné sérii. Zavolejte [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) jednou pro skupinu. Větší hodnota vytvoří více prostoru mezi shluky; menší hodnota je učiní hustšími.

Následující příklad mění šířku mezery a ukládá pouze finální prezentaci:

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

## **Často kladené otázky**

**Které typy grafů podporují datové série?**

Všechny typy grafů reprezentované výčtem [ChartType](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/charttype/) používají data grafu, ale jejich série nemají všude stejnou strukturu hodnot nebo nastavení. Například kategoriové grafy používají kategorie a hodnoty, rozptylové grafy používají hodnoty X a Y a bublinové grafy přidávají velikosti bublin. Použijte metodu tvorby datového bodu, která odpovídá typu série. Možnosti jako překrytí a šířka mezery platí jen pro kompatibilní skupiny sloupců nebo pruhů.

**Co je skupina sérií grafu?**

[IChartSeriesGroup](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseriesgroup/) obsahuje kompatibilní série, které sdílejí nastavení vykreslování na úrovni skupiny. Kombinační graf může obsahovat více než jednu skupinu, takže změna skupiny získané skrze jednu sérii nemusí nutně změnit všechny série v grafu.

**Obsahuje nově vytvořený graf výchozí data?**

Ano. Ve výchozím nastavení [IShapeCollection::AddChart](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishapecollection/addchart/) vytváří ukázkové série, kategorie a hodnoty. Můžete upravit tyto buňky nebo vymazat jak kolekce sérií, tak kolekce kategorií před přidáním zcela vlastního datového souboru. Přetížená metoda může také vytvořit graf bez výchozích dat.

**Jak jsou objekty grafu propojeny s buňkami sešitu?**

Názvy sérií, štítky kategorií a hodnoty datových bodů odkazují na buňky v [IChartDataWorkbook](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdataworkbook/). Změna odkazované buňky aktualizuje odpovídající prvek grafu. Při tvorbě vlastních dat udržujte řádky kategorií a řádky hodnot sérií zarovnané tak, aby byl každý bod vykreslen pod zamýšlenou kategorií.

**Jak vymazat jeden bod místo celé série?**

Nastavte příslušnou buňku s hodnotou na `nullptr`, aby se zachovala pozice kategorie bodu jako prázdný bod. Volajte [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) pouze tehdy, když chcete odstranit všechny body z dané série. Pokud také odstraňujete kategorie, aktualizujte všechny série tak, aby jejich hodnoty zůstaly zarovnané s kolekcí kategorií.

**Jak jsou prázdné body zobrazovány?**

Výsledek závisí na typu grafu a [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichart/get_displayblanksas/). Podporované grafy mohou zobrazovat prázdná místa jako mezery, jako nulové hodnoty nebo spojením sousedních bodů. Vyberte nastavení, které odpovídá významu chybějících dat ve vaší prezentaci.

**Jak jsou záporné hodnoty formátovány?**

Pro podporované série sloupců, pruhů a bublin zavolejte [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) a nastavte barvu pomocí [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/). Chování můžete přepsat pro jednotlivý bod pomocí [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/). Tyto metody ovlivňují formátování, ne uložené číselné hodnoty.

**Které formátování má přednost, když jsou formátovány jak série, tak bod?**

Explicitní formátování datového bodu má přednost pro tento bod. Ostatní body nadále používají explicitní formát série nebo, pokud není formát série definován, automatický styl a motiv grafu. Nastavení skupiny, jako jsou překrytí a šířka mezery, řídí rozložení a nejsou přepsáním formátování na úrovni bodu.

**Existuje limit, kolik sérií může graf obsahovat?**

Aspose.Slides nepřikládá zvláštní pevný limit počtu sérií. V praxi určují užitečný limit omezení souboru prezentace, dostupná paměť, čas vykreslování a čitelnost grafu.

**Co změnit, když jsou sloupce příliš blízko u sebe nebo příliš daleko?**

Zavolejte [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cs/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) na příslušné nadřazené skupině sérií. Zvýšte hodnotu pro zvětšení prostoru mezi shluky nebo ji snížíte, aby byly shluky blíže k sobě.