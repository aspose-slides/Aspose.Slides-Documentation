---
title: Diagram sorozatok kezelése prezentációkban C++-ban
linktitle: Adatsorok
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
description: "Tanulja meg, hogyan kezelje a diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, hézag szélességet és negatív értékeket prezentációkban C++-al."
---
## **Áttekintés**

A diagram a megjelenített adatokat egy diagram adat-munkafüzetben tárolja. Egy [IChartSeries](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/) egy kapcsolódó értékkészletet képvisel, és a sorozat minden [IChartDataPoint](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapoint/) egy vagy több munkafüzet‑cellára hivatkozik. Az [IChartCategory](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartcategory/) objektumok a sorozatok által megosztott címkéket vagy csoportosító értékeket biztosítják. Így a sorozat neve, kategóriái és pontértékei az [IChartDataCell](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatacell/) objektumokhoz kapcsolódnak, nem csak megjelenített szövegként tárolódnak.

Egy tipikus kategória diagram esetén az alapértelmezett munkafüzet a 0‑s sort használja a sorozatnevekhez, a 0‑s oszlopot a kategória-nevekhez, a maradék cellákat pedig a sorozatértékekhez. A [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) számára megadott munkalap‑, sor‑ és oszlopindexek nulláról indulnak. Ez a felépítés hasznos, ha alapértelmezett adatokkal hozunk létre diagramot, de ne feltételezzük, hogy minden meglévő diagram ezt használja. Betöltött prezentáció esetén ellenőrizze a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt a munkafüzet értékeit módosítaná.

A diagram beállításai három különböző hatókörrel rendelkeznek:

- Sorozat‑szintű beállítások, például az [IChartSeries::get_Format](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/get_format/) alapértelmezett megjelenését biztosítják az egész sorozat pontjaira.
- Adatpont‑szintű beállítások, például az [IChartDataPoint::get_Format](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapoint/get_format/) felülírják a sorozat megjelenését egy adott pont esetén.
- Csoportbeállítások a kompatibilis sorozatokra vonatkoznak, amelyek ugyanahhoz az [IChartSeriesGroup](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseriesgroup/) tartoznak. A csoporthoz az [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) segítségével férhet hozzá, ha például átfedés vagy hézag‑szélesség beállítására van szükség.

Ha nincs kifejezetten megadva pont‑ vagy sorozat‑kitöltés, a diagram stílusa és témája határozza meg az automatikus megjelenést. Ha mind a sorozat, mind a pont formázása meg van adva, a pont formázása felülbírálja a sorozatét.

![diagram sorozat PowerPoint](chart-series-powerpoint.png)

## **A diagram sorozat átfedésének beállítása**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/get_overlap/) azt jelzi, mennyire fednek át a sávok vagy oszlopok egy 2D diagramon, -100‑tól 100 százalékig. Ez egy csak‑olvasásra szánt leképezése a szülő sorozatcsoport beállításának. Hívja meg az [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) metódust, hogy frissítse az adott csoport minden kompatibilis sorozatát. Ez az opció az olyan diagramtípusokra vonatkozik, amelyek csoportos sávokat vagy oszlopokat jelenítenek meg; kombinált diagram esetén a nem kapcsolódó sorozatcsoportokat nem érinti.

A következő példa beállítja az átfedést az első sorozatot tartalmazó csoportban:

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

// Az új diagram mintasorozatokat, kategóriákat és értékeket tartalmaz.
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

Az [IChartSeries::get_Format](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/get_format/) segítségével állítható be az egész sorozat alapértelmezett kitöltése. Ha egy pont már rendelkezik kifejezett kitöltéssel, annak [IChartDataPoint::get_Format](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapoint/get_format/) beállítása felülírja a sorozat kitöltését az adott pontnál.

A következő példa egy szilárd kék kitöltést alkalmaz az első sorozatra:

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

A sorozat neve a diagram adat‑munkafüzetben van tárolva, és általában a jelmagyarázatban jelenik meg. Az klaszteres oszlopdiagramhoz létrehozott alapértelmezett munkafüzetben a B1 cella (0‑s sor, 1‑s oszlop) tartalmazza az első sorozat nevét. Az alábbi példában a névkonstansok egyértelművé teszik ezt a struktúrát:

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

Frissítheti azt a cellát is, amelyre már hivatkozik az [IChartSeries::get_Name](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/get_name/). Ez a megközelítés elkerüli a sor és oszlop konkrét feltételezését egy meglévő diagram esetén:

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

## **Az automatikus sorozat kitöltőszín lekérése**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) visszaadja a sorozatindex és a diagramstílus alapján kiszámított színt. Ez a szín akkor kerül felhasználásra, ha a sorozat kitöltése nincs kifejezetten definiálva. A metódus meghívása csak a kiszámított színt olvassa; nem állít be új kitöltést.

A következő példa kiírja az alapértelmezett sorozatok automatikus színét:

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

Példa‑kimenet az alapértelmezett diagramstílushoz:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

A pontos színek a diagramstílustól és témától függenek.

## **Invert (negatív) kitöltőszín beállítása egy diagram sorozathoz**

Sáv‑, oszlop‑ és buboréksorozatoknál az [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) lehetővé teszi, hogy a negatív értékek másik kitöltéssel jelenjenek meg. Állítsa be a normál sorozatkitöltést szilárdra, engedélyezze az invertálást, és adja meg a negatív‑érték színét az [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) segítségével. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenítési színük változik.

A következő példa az alapértelmezett diagramadatait lecseréli egy sorozatra. A munkalap 0‑s sora a sorozat nevét, a 0‑s oszlop a kategória‑neveket, az 1‑s oszlop pedig az értékeket tartalmazza:

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

![Invertált szilárd kitöltőszín](inverted_solid_fill_color.png)

Invertálást egy pontnál az [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) segítségével engedélyezheti. Az alábbi példában a sorozatra ki van kapcsolva az invertálás, csak a kiválasztott pontra van bekapcsolva. Ennek a pontnak negatív értéket is adunk, hogy a hatás látható legyen:

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

Egy pont üresen hagyásához, anélkül, hogy a többi pontot eltávolítaná, állítsa a mögöttes munkafüzet‑cellát `nullptr`‑ra. Oszlopdiagram esetén a megjelenített érték a [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/) segítségével érhető el. Az adatpont ugyanazon kategória‑pozícióban marad, de a diagram a beállított üres‑érték szabályok szerint üresként kezeli.

A következő példa csak a második pontot törli az első sorozatból:

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

A scatter diagramok külön X és Y cellákat használnak, a bubble diagramok pedig egy méret‑cellát is. Csak azt a cellát törölje, amely az eltávolítani kívánt értéket tartalmazza. Ne hívja a [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) metódust, ha a többi pontot megtartja, mert ez a metódus az összes adatpontot eltávolítja a gyűjteményből.

## **Üres cellák megjelenítésének szabályozása**

A rejtett, de értéket tartalmazó cellák külön esetet jelentenek az üres celláktól. A rejtett munkalap‑sorok és -oszlopok adatait be‑ vagy kizárni a [Rejtett sorok és oszlopok adatainak bevonása](/slides/hu/cpp/chart-workbook/#include-data-from-hidden-rows-and-columns) szakaszban található útmutató szerint teheti meg.

Egy üres munkafüzet‑cellát hiányzó adatként tekintünk; a `0` értéket tartalmazó cella ismert numerikus értéket jelent. Hívja a [IChartDataCell::set_Value](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatacell/set_value/) metódust `nullptr`‑val, hogy a cella üres legyen. A numerikus nulla minden esetben null marad, függetlenül az üres‑cellá beállítástól.

Használja az [IChart::set_DisplayBlanksAs](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichart/set_displayblanksas/) metódust annak meghatározására, hogyan jelenjenek meg az üres cellák a diagramon. Ez a beállítás a teljes diagramra vonatkozik. Megváltoztatja, hogyan ábrázolják a hiányzó értékeket, anélkül, hogy a munkafüzet‑cellát nullával vagy interpolált értékkel töltené fel.

Az alábbi önálló példa egy vonaldiagramot hoz létre egy sorozattal, törli a 3. nap értékét, és minden módot külön fájlba ment. Bemeneti fájl nem szükséges. Az [IChartDataWorkbook](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdataworkbook/) a 0‑s munkalapot, az 0‑s oszlopot a kategória‑címkéknek, az 1‑s oszlopot az értékeknek használja; a 0‑s sor a sorozatnevét tárolja. A végső adatsor: `10, 20, empty, 30, 40`.

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

// Hagyja a 3. napot ténylegesen üresen, miközben megtartja a kategóriát és az adatpontot.
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

Minden kimeneti fájl a mentés előtt beállított módot tartalmazza: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` és `empty_cells_Span.pptx`. Ha csak egy változatot szeretne menteni, állítsa be a kívánt módot, és egyszer mentse a prezentációt a módok iterálása helyett.

Az alábbi összehasonlítás ugyanazt az adatot mutatja mindhárom fájlban. A 3. nap a munkafüzetben minden esetben üres:

![Vonaldiagramok azonos adatokkal: Gap szaggatja a vonalat a 3. napnál, Zero 0‑ra viszi a vonalat, Span összeköti a 2. és 4. napot.](display_blanks_as.png)

A látható hatás a diagram típusától függ. A vonaldiagram mindhárom mód esetén könnyen összehasonlítható. Sáv‑ és oszlopdiagramok esetén nincs vonal, amely átfogó kapcsolatot képezne egy hiányzó kategória felett, ezért a `Span` nem hoz létre összekötő szegmenst, ahogy fent látható; egy hiányzó és egy nulla magasságú oszlop is hasonlíthat egymáshoz. Hasonlóképpen egy scatter diagram csak jelölőkkel nem rendelkezik összekötő vonallal. Ne várjon három különböző eredményt minden diagramtípusnál; ellenőrizze a kimenetet a használt típusra vonatkozóan.

## **A sorozat hézag‑szélességének beállítása**

A hézag‑szélesség a szomszédos sáv‑ vagy oszlopcsoportok közötti távolságot jelöli, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez a szülő sorozatcsoporthoz tartozik, nem egy adott sorozathoz. Hívja meg egyszer az [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) metódust a csoportra. Nagyobb érték nagyobb távolságot hoz létre a csoportok között; kisebb érték sűrűbb elrendezést eredményez.

A következő példa módosítja a hézag‑szélességet, és csak a végső prezentációt menti:

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

Az [ChartType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/charttype/) felsorolásban szereplő összes diagramtípus használ diagramadatokat, de sorozataik nem mindegyik rendelkezik ugyanazzal az érték‑struktúrával vagy beállításokkal. Például a kategória‑diagramok kategóriákat és értékeket használnak, a scatter diagramok X és Y értékeket, a bubble diagramok pedig buborékméreteket adnak hozzá. Használja a sorozattípushoz illeszkedő adat‑pont létrehozási módszert. Az átfedés‑ és hézag‑szélesség beállításai csak a kompatibilis sáv‑ vagy oszlopsorozatokra vonatkoznak.

**Mi az a diagram sorozatcsoport?**

Az [IChartSeriesGroup](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek csoportszintű ábrázolási beállításokat osztanak meg. Egy kombinált diagram több csoportot is tartalmazhat, így egy sorozaton keresztül elért csoport módosítása nem feltétlenül változtatja meg a diagram minden sorozatát.

**Tartalmaz egy újonnan létrehozott diagram alapértelmezett adatot?**

Igen. Alapértelmezés szerint az [IShapeCollection::AddChart](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/addchart/) minta‑sorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy a sorozat‑ és kategória‑gyűjteményeket törölheti, mielőtt teljesen egyedi adatkészletet adna hozzá. Egy overload segítségével diagramot is létrehozhat alapértelmezett adatok nélkül.

**Hogyan kapcsolódnak a diagramobjektumok a munkafüzet‑cellákhoz?**

A sorozatnevek, kategória‑címkék és adat‑pont értékek egy [IChartDataWorkbook](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagram‑elemet. Egyedi adat építésekor tartsa a kategória‑sorokat és a sorozat‑érték‑sorokat összehangoltan, hogy minden pont a kívánt kategória alá kerüljön.

**Hogyan töröljek egy pontot a teljes sorozat helyett?**

Állítsa a megfelelő értékkell cellát `nullptr`‑ra, hogy a pont kategória‑pozíciója üres pontként maradjon. A [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) metódust csak akkor hívja, ha az adott sorozat összes pontját el kívánja távolítani. Ha kategóriákat is eltávolít, frissítse minden sorozatot, hogy az értékek továbbra is a kategória‑gyűjteménnyel legyenek összehangolva.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagram típusától és az [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichart/get_displayblanksas/) beállítástól függ. A támogatott diagramok üres helyeket jeleníthetnek meg szünetként, nullaként vagy a szomszédos pontok összekapcsolásával. Válassza ki a hiányzó adat jelentésének megfelelő beállítást. Lásd a [Üres cellák megjelenítésének szabályozása](#control-the-display-of-empty-cells) szakaszt a teljes példáért és vizuális összehasonlításért.

**Hogyan formázzák a negatív értékeket?**

A támogatott sáv, oszlop és bubble sorozatoknál hívja meg a [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) metódust, és állítsa be a színt a [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) segítségével. Egy egyedi pontra vonatkozóan felülbírálhatja a viselkedést az [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) metódussal. Ezek a metódusok a formázást érintik, a tárolt numerikus értékeket nem.

**Melyik formázás nyer, ha egy sorozat és egy pont is formázott?**

A kifejezett adat‑pont formázás felülbírálja a sorozat formázását az adott pontnál. A többi pont a sorozat explicit formátumát vagy, ha az nincs definiálva, az automatikus diagram‑stílust és témát használja. A csoport‑beállítások, mint az átfedés és hézag‑szélesség, a layoutot szabályozzák, és nem pont‑szintű formázási felülírások.

**Van korlát arra, hogy hány sorozatot tartalmazhat egy diagram?**

Az Aspose.Slides nem állít fel különálló, fix sorozatszám‑korlátot. Gyakorlatilag a prezentációfájl korlátai, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a hasznos felső határt.

**Mit módosítsak, ha az oszlopok túl közel vagy túl távol vannak egymástól?**

Hívja meg a [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) metódust a megfelelő szülő sorozatcsoporton. Növelje az értéket a csoportok közötti távolság növeléséhez, vagy csökkentse, ha a csoportok közelebb szeretnék kerülni egymáshoz.