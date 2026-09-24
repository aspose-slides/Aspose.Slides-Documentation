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
- sorozat neve
- adatpont
- sorozat hézag
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Tanulja meg, hogyan kezelje a diagram sorozatokat, adatpontokat, munkafüzetcellákat, formázást, átfedést, hézag szélességet és negatív értékeket a prezentációkban C++-val."
---
## **Áttekintés**

A diagram az ábrázolt adatokat egy diagramadat‑könyvtárban tárolja. Egy [IChartSeries](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/) egy kapcsolódó értékkészletet képvisel, és a sorozat minden [IChartDataPoint](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapoint/) egy vagy több munkafüzetcellára hivatkozik. Az [IChartCategory](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartcategory/) objektumok a sorozatok által megosztott címkéket vagy csoportosítási értékeket biztosítják. A sorozat neve, a kategóriák és a pontértékek ezért [IChartDataCell](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatacell/) objektumokhoz vannak kapcsolva, nem csak megjelenített szövegként tárolják őket.

Egy tipikus kategória diagram esetén az alapértelmezett munkafüzet a 0. sort használja a sorozatnevekhez, a 0. oszlopot a kategória nevekhez, és a maradék cellákat a sorozatértékekhez. A munkalap, sor és oszlop indexek, amelyeket a [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) kap, nulláról indulnak. Ez a felépítés akkor hasznos, ha alapértelmezett adatokkal hoz létre diagramot, de ne feltételezze, hogy minden meglévő diagram ezt használja. Betöltött prezentáció esetén vizsgálja meg a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt módosítaná a munkafüzet értékeit.

A diagrambeállítások három különböző hatókörrel rendelkeznek:

- Sorozat‑szintű beállítások, például a [IChartSeries::get_Format](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/get_format/) biztosítják az alapértelmezett megjelenést egy sorozat összes pontjához.
- Adatpont‑szintű beállítások, például a [IChartDataPoint::get_Format](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapoint/get_format/) felülírják a sorozat megjelenését egy pont esetén.
- Csoportbeállítások azokra a kompatibilis sorozatokra vonatkoznak, amelyek ugyanahhoz az [IChartSeriesGroup](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseriesgroup/) tartoznak. A csoportot a [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) segítségével érheti el, ha például átfedés vagy hézag szélesség opciókat szeretne beállítani.

Ha nincs kifejezett pont‑ vagy sorozatkitöltés beállítva, a diagram stílusa és témája határozza meg az automatikus megjelenést. Ha a sorozat és a pont formázása egyaránt jelen van, a pont formázása élvez elsőbbséget az adott pontnál.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **A diagram sorozat‑átfedésének beállítása**

[IChartSeries::get_Overlap](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/get_overlap/) megadja, hogy egy 2D diagram oszlopai vagy sávjai milyen mértékben fednek át egymást, -100 és 100 százalék között. Ez egy csak olvasható leképezése a szülő sorozatcsoport beállításának. Hívja meg a [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) metódust, hogy frissítse a csoport minden kompatibilis sorozatát. Ez az opció a csoportos oszlopot vagy sávot megjelenítő diagramtípusokra vonatkozik; egy kombinált diagramban nem érint nem kapcsolódó sorozatcsoportokat.

A következő példa beállítja az átfedést arra a csoportra, amely az első sorozatot tartalmazza:

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

![The series overlap](series_overlap.png)

## **A sorozat kitöltőszínének módosítása**

Használja a [IChartSeries::get_Format](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/get_format/) metódust egy teljes sorozat alapértelmezett kitöltésének beállításához. Ha egy pont már rendelkezik kifejezett kitöltéssel, akkor annak [IChartDataPoint::get_Format](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapoint/get_format/) beállítása felülírja a sorozat kitöltését az adott pontnál.

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

![The color of the series](series_color.png)

## **A sorozat nevének módosítása**

Egy sorozat neve a diagram adatkönyvtárban van tárolva, és általában a jelmagyarázatban jelenik meg. Az alapértelmezett munkafüzetben, amely a klaszteres oszlopdiagramhoz jön létre, a B1 cella a 0. sorban, az 1. oszlopban található, és az első sorozat nevét tartalmazza. A következő példában a névkonstansok explicit módon megadják ezt a struktúrát:

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

A [IChartSeries::get_Name](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/get_name/) által már hivatkozott cellát is frissítheti. Ez a megközelítés elkerüli, hogy egy meglévő diagramnál egy konkrét sort és oszlopot feltételezzen:

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

![The series name](series_name.png)

## **Az automatikus sorozatkitöltőszín lekérdezése**

[IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) a sorozatindexből és a diagram stílusából kiszámított színt adja vissza. Ez a szín akkor kerül felhasználásra, ha a sorozat kitöltése nincs kifejezetten definiálva. A metódus meghívása csak a kiszámított színt olvassa, nem állít be új kitöltést.

A következő példa kiírja minden alapértelmezett sorozat automatikus színét:

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

## **Negatív értékek inverz kitöltőszínének beállítása egy diagram sorozathoz**

Sáv-, oszlop- és buborék sorozatoknál a [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) lehetővé teszi, hogy a negatív értékek más kitöltéssel jelenjenek meg. Állítsa be a normál sorozat kitöltését szilárdra, engedélyezze az inverziót, és adja meg a negatív értékek színét a [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) segítségével. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenített színük változik.

A következő példa az alapértelmezett diagramadatot egy sorozatra cseréli. A munkalap 0. sora a sorozat nevét, a 0. oszlop a kategória neveket, az 1. oszlop pedig az értékeket tartalmazza:

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

![The inverted solid fill color](inverted_solid_fill_color.png)

Az inverziót egy pont számára a [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) segítségével engedélyezheti. A következő példában az inverzió a sorozatra le van tiltva, és csak a kiválasztott pontra van beállítva. A pontnak negatív értéket is adunk, hogy a hatás látható legyen:

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

Egy pont üresé tételéhez a többi pont eltávolítása nélkül állítsa be a háttércelláját `nullptr`-ra. Oszlopdiagram esetén a megjelenített érték a [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/) segítségével érhető el. Az adatpont ugyanazon kategória pozícióban marad, de a diagram a beállított üres‑érték beállítások szerint üresként kezeli az értékét.

A következő példa csak a második pontot törli az első sorozatban:

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

A szórási diagramok külön X és Y cellákat használnak, a buborék diagramok pedig egy méretcellát is. Csak azt a cellát törölje, amely az eltávolítandó értéket tartalmazza. Ne hívja meg a [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) metódust, ha a többi pontot meg szeretné tartani, mivel ez a függvény az összes adatpontot eltávolítja a gyűjteményből.

## **Az üres cellák megjelenítésének szabályozása**

Egy üres munkafüzetcell a hiányzó adatot jelenti; a `0` értéket tartalmazó cella egy ismert numerikus értéket jelent. Hívja meg a [IChartDataCell::set_Value](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatacell/set_value/) metódust `nullptr`-val, hogy a cellát üresre állítsa. A numerikus nulla továbbra is nulla marad, függetlenül az üres‑cellás beállítástól.

Használja a [IChart::set_DisplayBlanksAs](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichart/set_displayblanksas/) metódust, hogy kiválassza, a diagram hogyan jeleníti meg az üres cellákat. Ez a beállítás a teljes diagramra vonatkozik. Megváltoztatja, hogyan kerülnek ábrázolásra a hiányzó értékek, anélkül hogy az üres munkafüzetcellát nullával vagy interpolált értékkel töltené fel.

A következő önálló példa egy vonaldiagramot hoz létre egy sorozattal, törli a 3. nap értékét, és ugyanazt a diagramot minden módon elmenti. Nem szükséges bemeneti fájl. A [IChartDataWorkbook](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdataworkbook/) a 0. munkalapot, az 0. oszlopot használja a kategória címkékhez, az 1. oszlopot az értékekhez; a 0. sor tartalmazza a sorozat nevét. A végső adatok: `10, 20, empty, 30, 40`.

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

// Hagyja a 3. napot valóban üresen, miközben megőrzi a kategóriáját és adatpontját.
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

Minden kimeneti fájl a mentés előtt beállított módot tárolja: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx` és `empty_cells_Span.pptx`. Ha csak egy verziót szeretne menteni, állítsa be a kívánt módot, és a prezentációt egyszer mentse el a módok iterálása helyett.

Az alábbi összehasonlítás ugyanazt az adatot mutatja mindhárom fájlban. A 3. nap minden esetben üres a munkafüzetben:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

A látható hatás a diagram típusától függ. A vonaldiagram esetén minden három mód könnyen összehasonlítható. A sáv- és oszlopdiagramoknak nincs vonala, amely összekötné a hiányzó kategóriát, ezért a `Span` nem tudja létrehozni a fenti összekötő szegmenst; egy hiányzó oszlop és egy nulla magasságú oszlop is hasonlóan nézhet ki. Hasonlóképpen, egy csak jelöletekkel rendelkező szórási diagramnak sincs vonala. Ne számítson három különböző eredményre minden diagramtípusnál; ellenőrizze a kimenetet a saját típusára vonatkozóan.

## **A sorozat hézag szélességének beállítása**

A hézag szélessége a szomszédos sáv‑ vagy oszloptömegek közötti távolság, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez a szülő sorozatcsoporthoz tartozik, nem egyetlen sorozathoz. Hívja meg egyszer a [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) metódust a csoportra. A nagyobb érték több helyet teremt a csoportok között; a kisebb érték sűrűbbé teszi őket.

A következő példa módosítja a hézag szélességét, és csak a végső prezentációt menti:

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

![The gap width](gap_width.png)

## **GYIK**

**Mely diagramtípusok támogatják az adat sorozatokat?**

Az összes, a [ChartType](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/charttype/) felsorolásban szereplő diagramtípus használ diagramadatot, de a sorozataik nem mindegyike rendelkezik ugyanazzal az értékstruktúrával vagy beállításokkal. Például a kategória diagramok kategóriákat és értékeket használnak, a szórási diagramok X és Y értékeket, a buborék diagramok pedig buborékméreteket adnak hozzá. Használja azt az adatpont‑létrehozó módszert, amely a sorozattípusnak megfelelő. Az olyan opciók, mint az átfedés és a hézag szélessége, csak kompatibilis sáv‑ vagy oszlopcsoportokra vonatkoznak.

**Mi a diagram sorozatcsoport?**

Egy [IChartSeriesGroup](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseriesgroup/) kompatibilis sorozatokat tartalmaz, amelyek közös csoport‑szintű ábrázolási beállításokat osztanak meg. Egy kombinált diagram több csoportot is tartalmazhat, így egy sorozaton keresztül elért csoport megváltoztatása nem feltétlenül változtatja meg a diagram minden sorozatát.

**A frissen létrehozott diagram tartalmaz-e alapértelmezett adatot?**

Igen. Alapértelmezés szerint a [IShapeCollection::AddChart](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/addchart/) mintasorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy törölheti a sorozat- és kategóriagyűjteményeket, mielőtt teljesen egyedi adatkészletet adna hozzá. Egy túlterhelés lehetővé teszi diagram létrehozását alapértelmezett adatok nélkül is.

**Hogyan kapcsolódnak a diagramobjektumok a munkafüzetcellákhoz?**

A sorozatnevek, kategória címkék és adatpont‑értékek egy [IChartDataWorkbook](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella megváltoztatása frissíti a megfelelő diagramelemet. Egyedi adat építésekor tartsa a kategória sorokat és a sorozat‑érték sorokat igazítva, hogy minden pont a kívánt kategória alatt kerüljenek ábrázolásra.

**Hogyan töröljek egy pontot a teljes sorozat helyett?**

Állítsa be a megfelelő értékcellát `nullptr`-ra, hogy a pont kategóriahelye üres pontként megmaradjon. A [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) metódust csak akkor hívja meg, ha a sorozat összes pontját el kívánja távolítani. Ha a kategóriákat is eltávolítja, frissítse az összes sorozatot, hogy értékeik azonosuljanak a kategóriagyűjteménnyel.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagram típusától és a [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichart/get_displayblanksas/) beállítástól függ. A támogatott diagramok megjeleníthetik a hiányzókat hézagként, nulla értékként, vagy a szomszédos pontok összekapcsolásával. Válassza azt a beállítást, amely megfelel a hiányzó adatok jelentésének a prezentációjában. Tekintse meg a [Control the Display of Empty Cells](#control-the-display-of-empty-cells) részt a teljes példáért és a vizuális összehasonlításért.

**Hogyan formázódnak a negatív értékek?**

A támogatott sáv-, oszlop- és buborék sorozatoknál hívja meg a [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) metódust, és állítsa be a színt a [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) segítségével. Egy adott pont viselkedését felülírhatja a [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) metódussal. Ezek a metódusok a formázást befolyásolják, nem a tárolt numerikus értékeket.

**Melyik formázás nyer, ha egy sorozat és egy pont is formázva van?**

A kifejezett adatpont‑formázás elsőbbséget élvez az adott pontnál. A többi pont továbbra is a kifejezett sorozat‑formátumot használja, vagy ha a sorozat formátuma nincs definiálva, akkor az automatikus diagramstílust és témát. A csoportbeállítások, mint az átfedés és a hézag szélessége, az elrendezést szabályozzák, és nem pont‑szintű formázási felülírások.

**Van korláta, hogy hány sorozatot tartalmazhat egy diagram?**

Az Aspose.Slides nem határoz meg különálló, rögzített sorozatszám‑korlátot. Gyakorlatban a prezentációs fájl korlátai, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg az értelmes határt.

**Mit kell változtatni, ha az oszlopok túl közel vagy túl távol vannak egymástól?**

Hívja meg a megfelelő szülő sorozatcsoporton a [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/hu/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) metódust. Növelje az értéket a klaszterek közti távolság bővítéséhez, vagy csökkentse, hogy a klaszterek közelebb kerüljenek egymáshoz.