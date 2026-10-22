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
description: "Ismerje meg, hogyan kezelheti a diagram sorozatokat, adatpontokat, munkafüzet cellákat, formázást, átfedést, hézag szélességet és negatív értékeket prezentációkban C++-ban."
---
## **Áttekintés**

A diagram a leképezett értékeket munkafüzetcellákban vagy közvetlenül numerikus literálokként tárolhatja. Egy [IChartSeries](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/) egy kapcsolódó értékcsoportot képvisel, és minden [IChartDataPoint](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/) egy pontot jelent abban a sorozatban. Az [IChartCategory](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartcategory/) objektumok a címkéket vagy a sorozatok által megosztott csoportosítási értékeket biztosítják. Az alapértelmezett adatokkal létrehozott diagramok esetén a sorozatneveket, kategóriákat és pontértékeket a diagram munkafüzetének [IChartDataCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/) objektumai tárolják.

Egy tipikus kategóriadiagram alapértelmezett munkafüzete a 0. sort használja a sorozatnevekhez, a 0. oszlopot a kategórianévhez, a többi cellát pedig a sorozatértékekhez. A [IChartDataWorkbook::GetCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/getcell/) számára átadott munkalap-, sor‑ és oszlopszámok nulla‑alapúak. Ez a felépítés hasznos, ha alapértelmezett adatokkal hoz létre diagramot, de ne feltételezze, hogy minden meglévő diagram ezt használja. Betöltött prezentáció esetén ellenőrizze a sorozatok, kategóriák és adatpontok által hivatkozott cellákat, mielőtt a munkafüzetértékeket megváltoztatná.

A diagrambeállítások három különböző hatókörrel rendelkeznek:

- Sorozatszintű beállítások, például az [IChartSeries::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_format/) adja meg egy sorozat összes pontjának alapértelmezett megjelenését.
- Adatpont‑szintű beállítások, például az [IChartDataPoint::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_format/) felülírja a sorozat megjelenését egy adott pontnál.
- Csoportbeállítások alkalmazhatók azokra a kompatibilis sorozatokra, amelyek ugyanahhoz az [IChartSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/) tartoznak. A csoportot az [IChartSeries::get_ParentSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_parentseriesgroup/) segítségével érheti el, ha olyan opciókat kell beállítania, mint az átfedés vagy a részsávszélesség.

Ha nincs kifejezetten beállítva pont‑ vagy sorozattöltés, a diagram stílusa és témája határozza meg az automatikus megjelenést. Ha mind a sorozat, mind a pont formázása jelen van, a pont formázása felülírja a sorozatét az adott pontnál.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Sorozatértékek beállítása numerikus literálokkal**

Numerikus literálokat akkor használjon, ha a sorozatértékek alkalmazásadatokból vagy számításokból származnak, és nem szükséges munkalap‑cellahivatkozás. Hívja meg a [set_DataSourceTypeForValues](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforvalues/) metódust a [DataSourceType::DoubleLiterals](https://reference.aspose.com/slides/cpp/aspose.slides.charts/datasourcetype/) értékével, mielőtt a pontok [get_Value](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_value/) által visszaadott értéket a [set_AsLiteralDouble](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idoublechartvalue/set_asliteraldouble/) segítségével rendeli.

A gyűjteménybeállítás vezérli a sorozat összes pontjának forrástípusát. Egy pont [IBaseChartValue::get_DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ibasechartvalue/get_datasourcetype/) jelzi a kiválasztott típust; módosítsa a gyűjteménybeállítással. `Worksheet` esetén a [get_AsCell](https://reference.aspose.com/slides/cpp/aspose.slides.charts/isinglecellchartvalue/get_ascell/) segítségével érheti el a hivatkozott cellát. `DoubleLiterals` esetén a [get_AsLiteralDouble](https://reference.aspose.com/slides/cpp/aspose.slides.charts/idoublechartvalue/get_asliteraldouble/) vagy a `set_AsLiteralDouble` segítségével olvashatja vagy írhatja a számot közvetlenül.

A következő példa egy oszlopdiagramot hoz létre alapértelmezett sorozattal és kategóriákkal, majd a sorozat első sorozatának meglévő pontjaira a számított 10, 20, stb. értékeket rendeli. Elmenti a prezentációt, újra megnyitja, és kiírja a tárolt értékeket.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/DataSourceType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataPoint.h>
#include <DOM/Chart/IChartDataPointCollection.h>
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
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 20, 20, 500, 300);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

series->get_DataPoints()->set_DataSourceTypeForValues(DataSourceType::DoubleLiterals);
for (auto i = 0; i < series->get_DataPoints()->get_Count(); i++)
{
    series->get_DataPoints()->idx_get(i)->get_Value()->set_AsLiteralDouble((i + 1) * 10);
}

presentation->Save(u"numeric_literals.pptx", SaveFormat::Pptx);
presentation->Dispose();

auto reopenedPresentation = MakeObject<Presentation>(u"numeric_literals.pptx");
auto reopenedSlide = reopenedPresentation->get_Slide(0);
auto reopenedChart = ExplicitCast<IChart>(reopenedSlide->get_Shape(0));
auto reopenedSeries = reopenedChart->get_ChartData()->get_Series()->idx_get(0);
for (auto i = 0; i < reopenedSeries->get_DataPoints()->get_Count(); i++)
{
    auto point = reopenedSeries->get_DataPoints()->idx_get(i);
    Console::WriteLine(point->get_Value()->get_AsLiteralDouble());
}
reopenedPresentation->Dispose();
```

A pontérték forrástípusa különálló a [IChartData::get_DataSourceType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdata/get_datasourcetype/) beállítástól, amely a diagram belső vagy külső munkafüzet‑konfigurációját jelöli. Numerikus literálok használata önmagában nem távolítja el a beágyazott munkafüzetet. Ebben a példában a munkafüzet továbbra is elérhető a kategóriacímkék, sorozatnevek és a többi sorozat számára. Lásd a [Chart Workbook](/slides/hu/cpp/chart-workbook/) oldalát a munkafüzet‑kezeléshez.

Szórt- és buborékdiagramok esetén hívja meg a [set_DataSourceTypeForXValues](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforxvalues/) és a [set_DataSourceTypeForYValues](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforyvalues/) metódusokat a [get_XValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_xvalue/) és a [get_YValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/) forrásának kiválasztásához. A buborékdiagramok továbbá a [set_DataSourceTypeForBubbleSizes](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/set_datasourcetypeforbubblesizes/) metódust használják a [get_BubbleSize](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_bubblesize/) számára. Minden alkalmazandó forrást állítson `DoubleLiterals`‑re, mielőtt a `set_AsLiteralDouble` metódussal számokat rendelne.

## **Diagramsorozat‑átfedés beállítása**

Az [IChartSeries::get_Overlap](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_overlap/) azt jelzi, hogy a sávok vagy oszlopok milyen mértékben fedik egymást egy 2D diagramon, -100‑tól 100‑ig százalékban. Ez egy csak‑olvasásra szánt leképezése a szülő sorozatcsoport beállításának. Hívja meg az [IChartSeriesGroup::set_Overlap](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_overlap/) metódust a csoport minden kompatibilis sorozatának frissítéséhez. Ez az opció azoknál a diagramtípusoknál alkalmazandó, amelyek csoportos sávokat vagy oszlopokat jelenítenek meg; egy kombinációs diagram nem‑kapcsolódó sorozatcsoportokat nem érint.

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

## **Sorozatkitöltés színének módosítása**

Használja az [IChartSeries::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_format/) metódust az egész sorozat alapértelmezett kitöltésének beállításához. Ha egy pont már rendelkezik kifejezett kitöltéssel, annak [IChartDataPoint::get_Format](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_format/) beállítása felülírja a sorozat kitöltését az adott pontnál.

A következő példa szilárd kék kitöltést alkalmaz az első sorozatra:

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

## **Sorozatnév módosítása**

A sorozat neve a diagram adatmunkafüzetében tárolódik, és általában a jelmagyarázatban jelenik meg. Egy csoportosított oszlopdiagram alapértelmezett munkafüzete esetén a B1 cella (0. sor, 1. oszlop) tartalmazza az első sorozat nevét. Az alábbi példában a névkonstansok egyértelművé teszik ezt a szerkezetet:

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

Ezt a cellát közvetlenül is frissítheti az [IChartSeries::get_Name](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_name/) által már hivatkozott cellán. Ez a megközelítés elkerüli egy adott sor vagy oszlop feltételezését egy meglévő diagramon:

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

### **Sorozat létrehozása több cella nevéből**

Összetett sorozatnév hasznos, ha egy termék neve és egy jelentési időszak külön munkafüzetcellákban van tárolva. Például a `Product A` B1‑ben és a `2026` C1‑ben kombinálható egyetlen sorozatnévvé, miközben mindkét rész hivatkozva marad a forráscellákra.

Használja az [IChartDataWorkbook::GetCellCollection](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/getcellcollection/) metódust a névtartomány lekéréséhez, majd adja át a gyűjteményt az [IChartSeriesCollection::Add](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriescollection/add/) metódusnak. A `skipHiddenCells` argumentum határozza meg, hogy rejtett cellákat belefoglaljon-e: `true` kizárja őket, `false` pedig belefoglalja. Ez a példa `false`‑t használ a névtartomány minden cellájának belefoglalásához.

A következő példa egy prezentációt hoz létre egy sorozattal és két adatponttal. A B1:C1 cellák csak a sorozat nevét adják; az A2:A3 cellák a kategóriacímkéket, a B2:B3 cellák pedig a numerikus értékeket.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartCellCollection.h>
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

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 620.0f, 180.0f);
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();
chart->set_HasLegend(true);

auto workbook = chartData->get_ChartDataWorkbook();
workbook->Clear(0);

// Ez a két cella adja a sorozat nevét.
auto productName = ObjectExt::Box<String>(u"Product A");
auto reportingPeriod = ObjectExt::Box<String>(u"2026");
workbook->GetCell(0, 0, 1, productName);
workbook->GetCell(0, 0, 2, reportingPeriod);
auto nameCells = workbook->GetCellCollection(u"Sheet1!$B$1:$C$1", false);
auto series = chartData->get_Series()->Add(nameCells, ChartType::ClusteredColumn);

// Külön cellák szolgáltatják a kategóriákat és a numerikus adatpontokat.
auto northLabel = ObjectExt::Box<String>(u"North");
auto southLabel = ObjectExt::Box<String>(u"South");
auto northCategory = workbook->GetCell(0, 1, 0, northLabel);
auto southCategory = workbook->GetCell(0, 2, 0, southLabel);
chartData->get_Categories()->Add(northCategory);
chartData->get_Categories()->Add(southCategory);
auto northAmount = ObjectExt::Box<int>(120);
auto southAmount = ObjectExt::Box<int>(150);
auto northValue = workbook->GetCell(0, 1, 1, northAmount);
auto southValue = workbook->GetCell(0, 2, 1, southAmount);
series->get_DataPoints()->AddDataPointForBarSeries(northValue);
series->get_DataPoints()->AddDataPointForBarSeries(southValue);

presentation->Save(u"composite_series_name.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredményül kapott sorozatnév `Product A 2026`, a két cellaérték közötti szóközzel. A jelmagyarázat egy bejegyzésként jeleníti meg mindkét oszlopot. Az alábbi kép mutatja az eredményt:

![Column chart with North and South values and the composite series name Product A 2026 in the legend](composite_series_name.png)

## **Automatikus sorozatkitöltés színének lekérése**

Az [IChartSeries::GetAutomaticSeriesColor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/getautomaticseriescolor/) visszaadja a sorozatindex és a diagramstílus alapján kiszámított színt. Ez a szín akkor kerül felhasználásra, ha a sorozatkitöltés nincs kifejezetten definiálva. A metódus csak a kiszámított színt olvassa; nem állít be új kitöltést.

A következő példa kiírja az egyes alapértelmezett sorozatok automatikus színét:

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

Példakimenet az alapértelmezett diagramstílushoz:

```text
Series 0: ff4f81bd
Series 1: ffc0504d
Series 2: ff9bbb59
```

A pontos színek a diagramstílustól és a témától függenek.

## **Inverz kitöltés szín beállítása diagramsorozathoz**

Sáv-, oszlop‑ és buborék‑sorozatok esetén az [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) segítségével negatív értékek megjeleníthetők eltérő kitöltéssel. Állítsa be a szabályos sorozatkitöltést szilárdra, engedélyezze az inverziót, és adja meg a negatív érték színét az [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) metódussal. A negatív számok a munkafüzetben változatlanok maradnak; csak a megjelenítési színük változik.

A következő példa az alapértelmezett diagramadatokat egy sorozattal helyettesíti. A munkalap 0‑s sorában a sorozat neve, az 0‑s oszlopban a kategórianevek, az 1‑s oszlopban pedig az értékek találhatók:

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

Inverziót egyetlen pontra is engedélyezhet az [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) segítségével. Az alábbi példában a sorozatnál az inverzió le van tiltva, csak a kiválasztott pontnál van engedélyezve, amelyhez negatív értéket is rendelünk, hogy a hatás látható legyen:

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

Egy pont üresen hagyásához, anélkül hogy a többi pontot eltávolítaná, állítsa a mögöttes munkafüzetcellát `nullptr`‑ra. Oszlopdiagram esetén a megjelenített érték a [IChartDataPoint::get_YValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_yvalue/) segítségével érhető el. Az adatpont a kategóriapozícióban marad, a diagram pedig a cellaértéket üresként kezeli a diagram üres‑érték beállításai szerint.

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

A szórt diagramok külön X és Y cellákat használnak, a buborékdiagramok pedig méretcellát is. Törölje csak azt a cellát, amely a törlendő értéket tartalmazza. Ne hívja a [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) metódust, ha a többi pontot meg szeretné tartani, mivel ez a metódus az összes adatpontot eltávolítja a gyűjteményből.

## **Üres cellák megjelenítésének szabályozása**

A rejtett, értékkel rendelkező cellák egy külön esetet képeznek az üres cellákkal szemben. A rejtett munkalapsorok és -oszlopok adatainak felvételéhez vagy kizárásához tekintse meg a [Include Data from Hidden Rows and Columns](/slides/hu/cpp/chart-workbook/#include-data-from-hidden-rows-and-columns) oldalt.

Egy üres munkafüzetcellát hiányzó adatként értelmeznek; egy `0` értéket tartalmazó cella ismert numerikus értéket jelent. Hívja a [IChartDataCell::set_Value](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_value/) metódust `nullptr`‑val, hogy cellát üressé tegyen. Egy numerikus nulla továbbra is nulla marad, függetlenül az üres‑cellák beállításától.

Használja az [IChart::set_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_displayblanksas/) metódust annak kiválasztásához, hogyan jelenítse meg a diagram az üres cellákat. Ez a beállítás a teljes diagramra vonatkozik. Megváltoztatja, hogy a hiányzó értékek hogyan legyenek leképezve, anélkül, hogy az üres munkafüzetcellát nullával vagy interpolált értékkel töltené fel.

A következő önálló példa egy vonaldiagramot hoz létre egy sorozattal, a 3‑as nap értékét törli, majd minden mód esetén elmenti a diagramot. Bemeneti fájlra nincs szükség. A [IChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/) a 0‑s munkalapot, az 0‑s oszlopot használja a kategóriacímkékhez, az 1‑s oszlopot az értékekhez; a 0‑s sor a sorozat nevét tartalmazza. A végső adatsor `10, 20, empty, 30, 40`.

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

// Leave Day 3 genuinely empty, while retaining its category and data point.
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

Minden kimeneti fájl a mentés előtt beállított módot tárolja: `empty_cells_Gap.pptx`, `empty_cells_Zero.pptx`, és `empty_cells_Span.pptx`. Ha csak egy változatot szeretne menteni, állítsa be a kívánt módot, és egyszer mentse a prezentációt a módok iterálása helyett.

Az alábbi összehasonlítás ugyanazt az adatot mutatja mindhárom fájlban. A 3‑as nap minden esetben üres a munkafüzetben:

![Line charts with identical data: Gap breaks the line at Day 3, Zero drops the line to zero, and Span connects Day 2 to Day 4.](display_blanks_as.png)

A látható hatás a diagramtípustól függ. Egy vonaldiagram könnyen összehasonlítható mindhárom móddal. Sáv‑ és oszlopdiagramok esetén nincs vonal, amely összekötné a hiányzó kategóriát, így a `Span` nem hozhat létre összekötő szegmenst; egy hiányzó oszlop és egy nulla‑magasságú oszlop is hasonlóan nézhet ki. Hasonlóképpen egy szórt diagram csak jelölőkkel nincs összekötő vonala. Ne várjon három különböző eredményt minden diagramtípus esetén; ellenőrizze a kimenetet az adott típusra.

## **Sorozat‑részsávszélesség beállítása**

A részsávszélesség a szomszédos sáv‑ vagy oszlopcsoportok közti távolság, a sáv vagy oszlop szélességének százalékában kifejezve. Az átfedéshez hasonlóan ez a szülő sorozatcsoport szintjén áll, nem egyetlen sorozatnál. Hívja meg egyszer a [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) metódust a csoport számára. A nagyobb érték több helyet hoz létre a csoportok között; a kisebb érték sűrűbbé teszi őket.

A következő példa módosítja a részsávszélességet, és csak a végleges prezentációt menti el:

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

Az összes, a [ChartType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/charttype/) felsorolásban szereplő diagramtípus használ diagramadatot, de sorozataik nem minden esetben rendelkeznek azonos értékstruktúrával vagy beállításokkal. Például a kategóriadiagramok kategóriákat és értékeket használnak, a szórt diagramok X és Y értékeket, a buborékdiagramok pedig buborékméreteket. A sorozattípusnak megfelelő adatpont‑létrehozási metódust kell alkalmazni. Az átfedés‑ és részsávszélesség‑opciók csak kompatibilis sáv‑ vagy oszlopcsoportokra vonatkoznak.

**Mi az a diagram‑sorozatcsoport?**

Az [IChartSeriesGroup](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/) kompatibilis sorozatokat foglal össze, amelyek közös csoportszintű megjelenítési beállításokat osztanak meg. Egy kombinációs diagram több csoportot is tartalmazhat, így egy sorozaton keresztül elért csoport módosítása nem feltétlenül változtatja meg a diagram minden sorozatát.

**Tartalmaz-e egy újonnan létrehozott diagram alapértelmezett adatot?**

Igen. Alapértelmezés szerint az [IShapeCollection::AddChart](https://reference.aspose.com/slides/cpp/aspose.slides/ishapecollection/addchart/) mintasorozatokat, kategóriákat és értékeket hoz létre. Ezeket a cellákat szerkesztheti, vagy a sorozat‑ és kategóriagyűjteményeket törölheti, mielőtt teljesen egyedi adatkészletet adna hozzá. Egy túlterhelés segítségével diagramot is létrehozhat alapértelmezett adatok nélkül.

**Hogyan kapcsolódnak a diagramobjektumok a munkafüzetcellákhoz?**

A sorozatnevek, kategóriacímkék és adatpont‑értékek egy [IChartDataWorkbook](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdataworkbook/) celláira hivatkoznak. Egy hivatkozott cella módosítása frissíti a megfelelő diagramelemet. Egyedi adat építésekor tartsa összehangoltan a kategóriasorokat és a sorozat‑érték sorokat, hogy minden pont a kívánt kategória alá kerüljön.

**Hogyan töröljek egy pontot anélkül, hogy az egész sorozatot eltávolítanám?**

Állítsa a megfelelő értékcellát `nullptr`‑ra, így a pont kategóriapozíciója megmarad üres pontként. Csak akkor hívja a [IChartDataPointCollection::Clear](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapointcollection/clear/) metódust, ha az összes pontot el kívánja távolítani az adott sorozatból. Ha a kategóriákat is eltávolítja, frissítse minden sorozatot, hogy értékeik a kategória‑gyűjteménnyel összhangban maradjanak.

**Hogyan jelennek meg az üres pontok?**

Az eredmény a diagramtípustól és az [IChart::get_DisplayBlanksAs](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/get_displayblanksas/) beállítástól függ. A támogatott diagramok megjeleníthetik a hiányzókat hézagként, nullaként, vagy a szomszédos pontok összekapcsolásával. Válassza ki a beállítást úgy, hogy az illeszkedjen a hiányzó adatok jelentéséhez a prezentációjában. Lásd a [Control the Display of Empty Cells](#control-the-display-of-empty-cells) részt a teljes példáért és a vizuális összehasonlításért.

**Hogyan formázódnak a negatív értékek?**

A támogatott sáv‑, oszlop‑ és buborék‑sorozatok esetén hívja meg az [IChartSeries::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/set_invertifnegative/) metódust, és állítsa be a színt az [IChartSeries::get_InvertedSolidFillColor](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_invertedsolidfillcolor/) segítségével. Egy egyedi pont viselkedését felülírhatja az [IChartDataPoint::set_InvertIfNegative](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/set_invertifnegative/) metódussal. Ezek a módszerek a formázást érintik, nem a tárolt numerikus értékeket.

**Melyik formázás nyer, ha mind a sorozat, mind a pont formázva van?**

A kifejezett adatpont‑formázás felülírja a sorozati formázást az adott pontnál. A többi pont továbbra is a kifejezett sorozatformázást vagy, ha az nincs definiálva, az automatikus diagramstílust és témát használja. A csoportbeállítások, mint az átfedés és a részsávszélesség, az elrendezést szabályozzák, és nem pont‑szintű formázási felülírások.

**Van korlátozva, hány sorozatot tartalmazhat egy diagram?**

Az Aspose.Slides nem állít be különálló, rögzített sorozatszám‑korlátot. Gyakorlatban a prezentációs fájl korlátai, a rendelkezésre álló memória, a renderelési idő és a diagram olvashatósága határozza meg a használható felső határt.

**Mit módosítsak, ha az oszlopok túl közel vagy túl távol vannak egymástól?**

Hívja meg az [IChartSeriesGroup::set_GapWidth](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseriesgroup/set_gapwidth/) metódust a megfelelő szülő sorozatcsoporton. Növelje az értéket a csoportok közti távolság növeléséhez, vagy csökkentse, ha közelebb szeretné őket hozni.