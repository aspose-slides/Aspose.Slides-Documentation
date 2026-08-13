---
title: Diagram adat sorozatok kezelése prezentációkban C++-ban
linktitle: Adatsorozatok
type: docs
url: /hu/cpp/chart-series/
keywords:
- diagram sorozat
- sorozat átfedés
- sorozat szín
- kategória szín
- sorozat név
- adatpont
- sorozat hézag
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: Ismerje meg, hogyan kezelheti a diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, hézag szélességet és negatív értékeket prezentációkban C++-ban.
---
## **Áttekintés**

A diagram az ábrázolt adatokat egy diagramadat‑könyvtárban tárolja. Egy [IChartSeries](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/) egy kapcsolódó értékkészletet képvisel, és a sorozat minden [IChartDataPoint](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapoint/) egy vagy több munkafüzet‑cellára hivatkozik. A [IChartCategory](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartcategory/) objektumok a sorozatok által közösen használt címkéket vagy csoportosítási értékeket biztosítják. A sorozat neve, a kategóriák és a pontértékek ezért [IChartDataCell](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatacell/) objektumokhoz kapcsolódnak, nem csak megjelenítési szövegként tárolódnak.

Egy tipikus kategória‑diagram esetén az alapértelmezett munkafüzet a 0‑s sort a sorozatneveknek, a 0‑s oszlopot a kategórianeveknek, a többi cellát pedig a sorozatértékeknek használja. A [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) számára megadott munkalap‑, sor‑ és oszlopindexek nullától indulnak. Ez a felépítés akkor hasznos, ha az alapértelmezett adatokkal hoz létre egy diagramot, de nem szabad feltételezni, hogy minden meglévő diagram ezt a felépítést használja. Betöltött prezentáció esetén vizsgálja meg a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt a munkafüzet‑értékeket módosítaná.

A diagram beállításai három különböző hatókörben érvényesülnek:

- Sorozatszintű beállítások, például az [IChartSeries::get_Format](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/get_format/) adja meg az alapértelmezett megjelenést egy sorozat összes pontjának.
- Adatpontos beállítások, például az [IChartDataPoint::get_Format](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapoint/get_format/) felülírja a sorozat megjelenését egyetlen pont esetén.
- Csoportbeállítások a kompatibilis sorozatokra vonatkoznak, amelyek ugyanahhoz az [IChartSeriesGroup](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseriesgroup/) tartoznak. A csoportot a [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) segítségével érheti el, ha például átfedés vagy hézag‑szélesség beállítására van szükség.

Ha nincs kifejezett pont‑ vagy sorozat‑kitöltés megadva, a diagram stílusa és témája határozza meg a automatikus megjelenést. Ha a sorozat és a pont formázása egyaránt jelen van, a pont formázása élvez elsőbbséget az adott pontnál.

![diagram-sorozat-powerpoint](chart-series-powerpoint.png)

## **A diagram sorozat átfedésének beállítása**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/get_overlap/) megadja, hogy a sávok vagy oszlopok milyen mértékben fednek át egymást egy 2D diagramon, -100 % és 100 % között. Ez a beállítás csak olvasható, mivel a szülő sorozatcsoport beállításának egy projekciója. A [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) hívásával frissítheti az adott csoportba tartozó összes kompatibilis sorozatot. Ez az opció olyan diagramtípusokra vonatkozik, amelyek csoportos sávokat vagy oszlopokat jelenítenek meg; egy kombinációs diagram nem kapcsolódó sorozatcsoportokat nem érint.

Az alábbi példa beállítja az átfedést az első sorozatot tartalmazó csoportnál:

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

// Az új diagram minta sorozatokat, kategóriákat és értékeket tartalmaz.
auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20.0f, 20.0f, 500.0f, 200.0f);

auto seriesCollection = chart->get_ChartData()->get_Series();
auto series = seriesCollection->idx_get(firstSeriesIndex);
series->get_ParentSeriesGroup()->set_Overlap(overlapPercent);

presentation->Save(u"series_overlap.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A sorozat átfedése](series_overlap.png)

## **A sorozat kitöltőszínének módosítása**

Az [IChartSeries::get_Format](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/get_format/) segítségével állíthatja be egy teljes sorozat alapértelmezett kitöltését. Ha egy pont már rendelkezik kifejezett kitöltéssel, annak [IChartDataPoint::get_Format](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapoint/get_format/) beállítása felülírja a sorozat kitöltését az adott pontnál.

Az alábbi példa egy egységes kék kitöltést alkalmaz az első sorozatra:

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

Az eredmény:

![A sorozat színe](series_color.png)

## **A sorozat nevének módosítása**

A sorozat neve a diagramadat‑könyvtárban tárolódik, és általában a jelmagyarázatban jelenik meg. Az alapértelmezett munkafüzet, amely a csoportosított oszlopdiagramhoz készül, a B1 cella (0‑s sor, 1‑s oszlop) tartalmazza az első sorozat nevét. A következő példa állandó változókkal teszi egyértelművé ezt a struktúrát:

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

A cellát, amelyre a [IChartSeries::get_Name](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/get_name/) már hivatkozik, szintén frissítheti. Ez a megközelítés elkerüli, hogy egy meglévő diagram konkrét sorát és oszlopát feltételezze:

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

Az eredmény:

![A sorozat neve](series_name.png)

## **Az automatikus sorozatkitöltő szín lekérdezése**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) visszaadja a sorozat indexéből és a diagram stílusából számolt színt. Ez a szín akkor kerül felhasználásra, amikor a sorozat kitöltése nincs kifejezetten definiálva. A metódus csak kiolvassa a számított színt; nem állít be új kitöltést.

Az alábbi példa kiírja minden alapértelmezett sorozat automatikus színét:

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

Példa kimenet az alapértelmezett diagramstílushoz:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

A pontos színek a diagram stílusától és témájától függenek.

## **Inverz kitöltőszín beállítása egy diagram sorozathoz**

Sáv-, oszlop- és buborék‑sorozatok esetén az [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) segítségével a negatív értékek más kitöltéssel jeleníthetők meg. Állítsa be a normál sorozatkitöltést egységesre, engedélyezze az inverziót, és adja meg a negatív érték színét a [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) segítségével. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenített színük változik.

Az alábbi példa egy sorozattal helyettesíti az alapértelmezett diagramadatot. A 0‑s sor tartalmazza a sorozat nevét, az 0‑s oszlop a kategórianeveket, az 1‑s oszlop pedig az értékeket:

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

Az eredmény:

![Az inverz egységes kitöltőszín](inverted_solid_fill_color.png)

Az inverzió engedélyezhető egyetlen pont számára a [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) hívásával. Az alábbi példában a sorozatnál le van tiltva az inverzió, csak a kiválasztott pontnál van engedélyezve. A pont negatív értéket is kap, hogy a hatás látható legyen:

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

## **Egy adott adatpont értékének törlése**

Egy pont üresre állításához, anélkül hogy a többi pontot eltávolítaná, állítsa a mögöttes munkafüzet‑celláját `nullptr`‑ra. Oszlopdiagram esetén a megjelenített érték a [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/) segítségével érhető el. Az adatpont ugyanabban a kategóriapozícióban marad, de a diagram a beállításaitól függően a pont értékét üresként kezeli.

Az alábbi példa csak a második pontot törli az első sorozatban:

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

A szórásdiagramok külön X és Y cellákat használnak, a buborékdiagramok pedig méretcellát is. Csak azt a cellát törölje, amely a törölni kívánt értéket képviseli. Ne hívja a [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) metódust, ha a többi pontot meg akarja tartani, mivel ez a metódus az összes adatpontot eltávolítja a gyűjteményből.

## **A sorozat hézag‑szélességének beállítása**

A hézag‑szélesség a szomszédos sáv‑ vagy oszlopcsoportok közötti távolságot jelöli, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez a tulajdonság a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. A [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) egyszeri meghívásával a teljes csoportnál módosítható. A nagyobb érték több helyet hoz létre a csoportok között; a kisebb érték sűrűbb elrendezést eredményez.

Az alábbi példa megváltoztatja a hézag‑szélességet, és csak a végleges prezentációt menti:

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

Az eredmény:

![A hézag‑szélesség](gap_width.png)

## **GYIK**

**Mely diagramtípusok támogatják az adat‑sorozatokat?**

Az összes, a [ChartType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/charttype/) felsorolásban szereplő diagramtípus használ diagramadatot, de sorozataik nem minden esetben rendelkeznek ugyanazzal az érték‑struktúrával vagy beállításokkal. Például a kategória‑diagramok kategóriákat és értékeket használnak, a szórásdiagramok X és Y értékeket, a buborékdiagramok pedig buborékméreteket adnak hozzá. Használja azt az adatpontos létrehozási módszert, amely a sorozattípussal egyezik. Az olyan opciók, mint az átfedés vagy a hézag‑szélesség, csak kompatibilis sáv‑ vagy oszlopcsoportokra vonatkoznak.

**Mi az a diagram sorozatcsoport?**

Egy [IChartSeriesGroup](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek közös csoport‑szintű ábrázolási beállításokat osztanak meg. Egy kombinációs diagram több csoportot is tartalmazhat, ezért egy sorozaton keresztül elért csoport megváltoztatása nem feltétlenül változtatja meg a diagram minden sorozatát.

**Tartalmaz-e egy újonnan létrehozott diagram alapértelmezett adatokat?**

Igen. Alapértelmezés szerint az [IShapeCollection::AddChart](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/addchart/) minta‑sorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy törölheti mind a sorozat‑, mind a kategória‑gyűjteményeket, mielőtt teljesen egyedi adatkészletet adna hozzá. Egy túlterhelés segítségével diagramot is létrehozhat alapértelmezett adatok nélkül.

**Hogyan kapcsolódnak a diagramobjektumok a munkafüzet‑cellákhoz?**

A sorozatnevek, kategória­címkék és adatpontos értékek egy [IChartDataWorkbook](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdataworkbook/) cellájára hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagram‑elemet. Egyedi adat építésekor ügyeljen arra, hogy a kategória‑sorok és a sorozat‑érték sorok igazodjanak egymáshoz, hogy minden pont a megfelelő kategória alá kerüljön.

**Hogyan törölhetek egy pontot anélkül, hogy az egész sorozatot törölném?**

Állítsa a megfelelő értékcellát `nullptr`‑ra, így a pont kategória‑pozíciója üres pontként marad. A [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) metódust csak akkor hívja, ha az adott sorozat összes pontját el szeretné távolítani. Ha a kategóriákat is eltávolítja, frissítse minden sorozatot, hogy az értékek továbbra is a kategória‑gyűjteménnyel legyenek összehangolva.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagramtípustól és az [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichart/get_displayblanksas/) beállítástól függ. A támogatott diagramok üres pontokat megjeleníthetnek hézagként, nullaként vagy a szomszédos pontok összekapcsolásával. Válassza ki azt a beállítást, amely a hiányzó adatok jelentését a legjobban tükrözi a prezentációban.

**Hogyan formázzák a negatív értékeket?**

A támogatott sáv-, oszlop- és buborék‑sorozatok esetén hívja meg az [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) metódust, és állítsa be a színt a [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) segítségével. Egy egyedi pont viselkedését felülbírálhatja az [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) használatával. Ezek a módszerek a formázást érintik, nem a tárolt numerikus értékeket.

**Melyik formázás nyer, ha a sorozat és egy pont is formázva van?**

Az explicit adatpont‑formázás élvez elsőbbséget az adott pontnál. A többi pont a sorozat explicit formázását használja, vagy ha az nincs definiálva, az automatikus diagramstílus és -téma alapján jelenik meg. A csoportbeállítások, mint az átfedés és a hézag‑szélesség, a elrendezést szabályozzák, és nem felülírják a pont‑szintű formázást.

**Van korláta a diagramban lévő sorozatok számának?**

Az Aspose.Slides nem alkalmaz különálló fix sorozatszám‑korlátot. Gyakorlatban a prezentációfájl‑korlátok, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a hasznos felső határt.

**Mit kell módosítanom, ha az oszlopok túl közel vagy túl távol vannak egymástól?**

Hívja meg a [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) metódust a megfelelő szülő sorozatcsoporton. Növelje az értéket a csoportok közti távolság bővítéséhez, vagy csökkentse, hogy a csoportok közelebb kerüljenek egymáshoz.