---
title: Diagram tengelyek testreszabása prezentációkban C++ használatával
linktitle: Diagram tengely
type: docs
url: /hu/cpp/chart-axis/
keywords:
- diagram tengely
- függőleges tengely
- vízszintes tengely
- tengely testreszabása
- tengely manipulálása
- tengely kezelése
- tengely tulajdonságok
- maximális érték
- minimális érték
- tengely vonal
- dátumformátum
- tengely cím
- tengely pozíció
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan használhatja az Aspose.Slides for C++-t a diagram tengelyek testreszabásához PowerPoint prezentációkban jelentések és vizualizációk készítéséhez."
---
## **Áttekintés**

Ez a cikk azt ismerteti, hogyan lehet testreszabni a diagram tengelyeit az Aspose.Slides for C++ segítségével. Tárgyalja a számított tengelyértékeket, a diagram sorok és oszlopok felcserélését, a tengely láthatóságát, a kategória címkék és a jelölő-márka intervallumokat, a dátum kategóriákat és formázást, a cím forgatását, a tengely elhelyezését, a megjelenítési egységeket és a logaritmikus skálázást.

## **Maximum értékek lekérése a függőleges tengelyen a diagramokban**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) elemet, és adjon hozzá egy alapértelmezett adatokkal rendelkező területdiagramot. Hívja meg a [ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/validatechartlayout/) metódust a számított tengelyértékek olvasása előtt, hogy a diagram elrendezése naprakész legyen.

Olvassa ki a [get_ActualMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmaxvalue/) és [get_ActualMinValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminvalue/) metódusokkal a tengely határait, valamint a [get_ActualMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunit/) és [get_ActualMinorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunit/) segítségével a jelölő-intervallumokat. A [get_ActualMajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunitscale/) és a [get_ActualMinorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunitscale/) időegység skálákat biztosítanak, amelyek a dátumtengelyek esetén relevánsak. A példában ezek az értékek helyi változókba kerülnek, és a diagramot menti.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Area, 100, 100, 500, 350);
chart->ValidateChartLayout();

auto maxValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMaxValue();
auto minValue = chart->get_Axes()->get_VerticalAxis()->get_ActualMinValue();

auto majorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnit();
auto minorUnit = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnit();

auto majorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMajorUnitScale();
auto minorUnitScale = chart->get_Axes()->get_VerticalAxis()->get_ActualMinorUnitScale();

presentation->Save(u"AxisValues_out.pptx", SaveFormat::Pptx);
```

## **Adatok felcserélése a tengelyek között**

Használja a [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) metódust a sorozatok és kategóriák szerepének felcseréléséhez a diagram adatainál. Minden korábbi kategória sorozattá, minden korábbi sorozat pedig kategóriává válik. Ez megváltoztatja az adatcsoportosítás módját; nem cseréli fel a vízszintes és függőleges tengelyeket. A példa a [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setrange/) metódust használja, hogy az alapértelmezett adatot a `Sheet1!A1:D5` tartományra kötse, beleértve a fejléc sort és a kategória oszlopot, mielőtt a sorok és oszlopok felcserélődnek. Ez négy sorozattal és három kategóriával rendelkező diagramot ment.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100, 100, 400, 300);

chart->get_ChartData()->SetRange(u"Sheet1!A1:D5");
chart->get_ChartData()->SwitchRowColumn();

presentation->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **A tengely rajzolási sorrendjének megfordítása**

Használja a [set_IsPlotOrderReversed](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isplotorderreversed/) metódust egy kategória- vagy értéktengely megfordításához. Például egy vízszintes sávdiagram a projekt szakaszait a munkalapon lévő sorrendben mutathatja felülről lefelé: Tervezés, Fejlesztés, Tesztelés. A tengely megfordítása megváltoztatja a rajzolási irányt; nem rendezi vagy átalakítja a munkafüzet adatokat. Ezzel szemben a [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) felcseréli a sorozatok és kategóriák szerepét.

A következő példa egy három szakaszból álló és egy sorozatot tartalmazó vízszintes sávdiagramot hoz létre. Egy három diából álló prezentációt ment, ahol az első normál sorrendet, a második a megfordított kategóriákat, a harmadik a megfordított értékeket mutatja. Minden másolat ugyanazt az adatkészletet használja, és minden másolaton csak egy tengely van megfordítva.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/CrossesType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredBar, 50, 40, 620, 320);
chart->set_HasLegend(false);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::ClusteredBar);
auto stages = std::array<System::String, 3>{u"Planning", u"Development", u"Testing"};
auto values = std::array<int, 3>{10, 30, 20};
for (auto i = 0; i < stages.size(); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(stages[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

// 2. dia: az első kategória felül jelenik.
auto categorySlide = presentation->get_Slides()->AddClone(slide);
auto categoryChart = System::ExplicitCast<IChart>(categorySlide->get_Shape(0));
categoryChart->get_Axes()->get_VerticalAxis()->set_IsPlotOrderReversed(true);
// A vízszintes értéktengelyt alul tartsa.
categoryChart->get_Axes()->get_VerticalAxis()->set_CrossType(CrossesType::Maximum);

// 3. dia: csak a vízszintes numerikus skálát fordítsa meg.
auto valueSlide = presentation->get_Slides()->AddClone(slide);
auto valueChart = System::ExplicitCast<IChart>(valueSlide->get_Shape(0));
valueChart->get_Axes()->get_HorizontalAxis()->set_IsPlotOrderReversed(true);

presentation->Save(u"ReversedAxes.pptx", SaveFormat::Pptx);
```

Az tengely megfordítása a merőleges tengelyt is áthelyezheti a diagram ellentétes oldalára. A [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) szabályozza, hogy a többi tengely hol keresztezze az éppen beállított tengelyt. A 2. dián a `Maximum` érték beállítása a megfordított kategória tengelyen megtartja a vízszintes értéktengelyt alul. Egy adott keresztezési ponthoz használja a [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/). Ellenőrizze a keresztezési beállításokat irányváltáskor, különösen ha a diagram már egy egyedi keresztezési pontot tartalmaz. Hívja a `set_IsPlotOrderReversed`-t `false`-ra a normál rajzolási irány visszaállításához; a keresztezési beállítások különállóak.

| Normál sorrend (1. dia) | Megfordított kategóriák (2. dia) | Megfordított értékek (3. dia) |
| --- | --- | --- |
| ![Vízszintes sávdiagram normál kategória- és értéktengely sorrenddel](axis-order-normal.png) | ![Vízszintes sávdiagram, ahol a kategóriák felülről lefelé jelennek meg](axis-order-categories-reversed.png) | ![Vízszintes sávdiagram megfordított értéktengellyel és nullával a jobb oldalon](axis-order-values-reversed.png) |
| A kategóriák alulról felfelé haladnak; az értékek balról jobbra nőnek. | A Tervezés, Fejlesztés és Tesztelés felülről lefelé halad. Az értékek és a munkafüzet sorok sorrendje változatlan. | A kategóriák megtartják a normál sorrendjüket; az értékek jobbról balra nőnek. A kategóriatengely a jobb oldalon nullánál metszi egymást. |

## **A függőleges tengely letiltása vonaldiagramokhoz**

Használja a [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) metódust `false` értékkel a függőleges tengelyen, hogy elrejtse azt. A példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, és menti a függőleges tengely elrejtett állapotában.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenVerticalAxis.pptx", SaveFormat::Pptx);
```

## **A vízszintes tengely letiltása vonaldiagramokhoz**

Használja a [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) metódust `false` értékkel a vízszintes tengelyen, hogy elrejtse azt. A példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, és menti a vízszintes tengely elrejtett állapotában.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 100, 100, 400, 300);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

presentation->Save(u"HiddenHorizontalAxis.pptx", SaveFormat::Pptx);
```

## **Diagram rácsvonalak megjelenítése vagy elrejtése**

Használja a [get_ShowMajorGridLines](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_showmajorgridlines/) és a [get_ShowMinorGridLines](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_showminorgridlines/) metódusokat annak ellenőrzésére, hogy egy tengely mely rácsvonalakat jeleníti meg. Mindkét tulajdonság csak olvasható. A kisebb rácsvonalak megjelenítéséhez használja a [get_MinorGridLinesFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_minorgridlinesformat/) metódust, és állítsa a vonal kitöltését szilárd, látható színre. Az elrejtéshez állítsa a kitöltést a [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/) értékre. A fő rácsvonalak módosításához használja a [get_MajorGridLinesFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_majorgridlinesformat/) ugyanígy. A rácsvonal kitöltésének módosítása megőrzi a tengely láthatóságát és a jelölőket.

Ennek a csoportosított oszlopdiagramnak a függőleges tengelye kezdetben csak a fő rácsvonalakat jeleníti meg. A példa narancssárga kisebb rácsvonalakat mutat, majd a mentés előtt újra elrejti őket.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartLinesFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/ILineFillFormat.h>
#include <DOM/IColorFormat.h>
#include <DOM/FillType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 30, 30, 660, 230);
auto axis = chart->get_Axes()->get_VerticalAxis();
std::cout << std::boolalpha << "Initial: major=" << axis->get_ShowMajorGridLines() << ", minor=" << axis->get_ShowMinorGridLines() << '\n';

auto minorFill = axis->get_MinorGridLinesFormat()->get_Line()->get_FillFormat();
minorFill->set_FillType(FillType::Solid);
minorFill->get_SolidFillColor()->set_Color(Color::get_DarkOrange());
std::cout << "Enabled: minor=" << axis->get_ShowMinorGridLines() << '\n';

minorFill->set_FillType(FillType::NoFill);
std::cout << "Hidden: major=" << axis->get_ShowMajorGridLines() << ", minor=" << axis->get_ShowMinorGridLines() << '\n';

presentation->Save(u"ChartGridlines.pptx", SaveFormat::Pptx);
```

| Kisebb rácsvonalak engedélyezve | Kisebb rácsvonalak rejtve |
| --- | --- |
| ![Narancssárga kisebb rácsvonalak a fő rácsvonalak között a függőleges tengelyen](minor-gridlines-enabled.png) | ![Ugyanaz a oszlopdiagram, csak a fő rácsvonalak láthatók](minor-gridlines-hidden.png) |

## **Kategóriatengely módosítása**

Használja a [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) metódust egy dátum vagy szöveges kategóriatengely kiválasztásához. Ez a példa a `ExistingChart.pptx` fájlt igényli, amelyben a diagram az első dia első alakzataként található, és a kategória cellák numerikus Excel dátumértékeket tartalmaznak. A vízszintes tengelyt dátumtengellyé változtatja. A [set_IsAutomaticMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isautomaticmajorunit/) `false`, a [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunit/) `1`, és a [set_MajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunitscale/) havival beállítása fő jelölőket helyez el egyhónapos intervallummal.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TimeUnitType.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto slide = presentation->get_Slide(0);

auto chart = System::ExplicitCast<IChart>(slide->get_Shape(0));
chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticMajorUnit(false);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnit(1);
chart->get_Axes()->get_HorizontalAxis()->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

### **A kategóriatengely típusának meghatározása az adatok alapján**

Az [SetCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/setcategoryaxistypeautomatically/) metódust a kategóriák feltöltése után hívja meg, majd a [get_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_categoryaxistype/) segítségével ellenőrizze a választ. Ez hasznos, ha ugyanaz a diagram szöveges címkéket vagy numerikus dátumértékeket kap. A metódus a híváskor meghatározza a típust; nem aktivál állandó módot, amely későbbi adatváltozásokat újraértékeli. Hívja újra a kategóriák cseréje után.

A következő példa egy szöveges kategóriákat tartalmazó diagramot hoz létre és a `Text` szót jeleníti meg. Ezután a kategória cellaértékeket dátumokra cseréli, és újra meghívja a metódust, ami a `Date` szót jeleníti meg. A dátumok numerikus OLE Automation értékként tárolódnak, amelyet a [System::DateTime::ToOADate](https://reference.aspose.com/slides/cpp/system/datetime/tooadate/) ad vissza, nem dátum karakterláncként. A [set_CustomNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_customnumberformat/) szabályozza, hogyan jelennek meg ezek az értékek; nem konvertálja a szöveget numerikus dátumokká. A kategória cellákról bővebben a [Chart Workbook](/slides/hu/cpp/chart-workbook/) lapon olvashat.

Használja az automatikus meghatározást, ha a bemenet szöveges kategóriákat vagy numerikus dátumokat tartalmaz, ahogy ebben a példában is. Általános numerikus címkék, kevert kategóriák vagy üres adatok esetén hívja kifejezetten a [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_categoryaxistype/) metódust a kívánt jelentéshez. Csak a numerikus értékek nem bizonyítják, hogy a kategóriák dátumok.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/date_time.h>
#include <system/console.h>
#include <system/enum.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto seriesName = workbook->GetCell(0, 0, 1, System::ObjectExt::Box(System::String(u"Sales")));
auto series = chart->get_ChartData()->get_Series()->Add(seriesName, chart->get_Type());
auto labels = std::array<System::String, 3>{u"First", u"Second", u"Third"};

for (auto i = 0; i < labels.size(); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(labels[i]));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box((i + 1) * 10));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto axis = chart->get_Axes()->get_HorizontalAxis();
axis->SetCategoryAxisTypeAutomatically();
System::Console::WriteLine(System::Enum<CategoryAxisType>::GetName(axis->get_CategoryAxisType())); // Szöveg

auto dates = std::array<System::DateTime, 3>{System::DateTime(2026, 1, 1), System::DateTime(2026, 1, 2), System::DateTime(2026, 2, 1)};

for (auto i = 0; i < dates.size(); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0);
    categoryCell->set_Value(System::ObjectExt::Box(dates[i].ToOADate()));
    categoryCell->set_CustomNumberFormat(u"yyyy-mm-dd");
}

axis->SetCategoryAxisTypeAutomatically();
System::Console::WriteLine(System::Enum<CategoryAxisType>::GetName(axis->get_CategoryAxisType())); // Dátum

presentation->Save(u"AutomaticCategoryAxis.pptx", SaveFormat::Pptx);
```

## **Kategóriatengely címke intervallumok szabályozása**

Amikor egy diagram sok kategóriát tartalmaz, csökkentheti a látható tengelycímkék számát anélkül, hogy a kategóriákat vagy adatpontokat eltávolítaná. Használja a [set_IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticticklabelspacing/) `false` értéket, majd a [set_TickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_ticklabelspacing/) segítségével adja meg a kívánt kategória intervallumot. Szöveges kategóriák normál sorrendjében a számlálás az első kategóriától indul:

| Intervallum | A példában megjelenített címkék |
| --- | --- |
| `1` | Kategória 1, Kategória 2, Kategória 3, … Kategória 24 |
| `2` | Kategória 1, Kategória 3, Kategória 5, … Kategória 23 |
| `3` | Kategória 1, Kategória 4, Kategória 7, … Kategória 22 |

Az `3` intervallum minden harmadik címkét jelenít meg, két címkét rejtve hagyva a megjelenített címkék között. Nem távolítja el a megfelelő oszlopokat. Az automatikus távolság a rendelkezésre álló hely alapján választ intervallumot; nem feltétlenül jelenít meg minden címkét.

A jelölőpontoknak külön szabályozása van. Használja a [set_IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomatictickmarksspacing/) `false` értéket, és a [set_TickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_tickmarksspacing/) segítségével állítsa be az intervallumukat. Például az `1` minden kategória intervallumnál elhelyezi a jelölőpontot, miközben a címkék csak minden harmadik kategóriánál jelennek meg. Használja a [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majortickmark/) látható stílusú beállítását, hogy látható legyen az eredmény. Bármely automatikus távolság tulajdonság visszaállítása `true`-ra lehetővé teszi a diagram számára, hogy újra válasszon intervallumot.

A következő önálló példa 24 kategóriát és egy sorozatot hoz létre, majd három diát ment a `CategoryAxisIntervals.pptx` fájlba: automatikus távolság, kézi címke távolság független jelölőpontokkal, és visszaállított automatikus távolság. A két másolat megtartja az eredeti diagram adatokat. Nem szükséges bemeneti prezentáció. A vízszintes címke szövege könnyen láthatóvá teszi a sűrűségkülönbséget.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/TickMarkType.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <DOM/ISlideCollection.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 30, 40, 660, 320);

chart->set_HasLegend(false);
chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::ClusteredColumn);
for (auto i = 0; i < 24; i++)
{
    auto categoryName = System::String::Format(u"Category {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);
    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(10 + i % 6 * 5));
    series->get_DataPoints()->AddDataPointForBarSeries(valueCell);
}

auto axis = chart->get_Axes()->get_HorizontalAxis();
axis->set_CategoryAxisType(CategoryAxisType::Text);
axis->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(0);
axis->get_TextFormat()->get_PortionFormat()->set_FontHeight(12);
axis->set_MajorTickMark(TickMarkType::Outside);
axis->set_IsAutomaticTickLabelSpacing(true);
axis->set_IsAutomaticTickMarksSpacing(true);

// 2. dia: minden harmadik címkét jelenítse meg, de minden kategóriához tartson egy jelölőpontot.
auto manualSlide = presentation->get_Slides()->AddClone(slide);
auto manualChart = System::ExplicitCast<IChart>(manualSlide->get_Shape(0));
auto manualAxis = manualChart->get_Axes()->get_HorizontalAxis();
manualAxis->set_IsAutomaticTickLabelSpacing(false);
manualAxis->set_TickLabelSpacing(3);
manualAxis->set_IsAutomaticTickMarksSpacing(false);
manualAxis->set_TickMarksSpacing(1);

// 3. dia: a diagram válassza újra mindkét intervallumot.
auto restoredSlide = presentation->get_Slides()->AddClone(manualSlide);
auto restoredChart = System::ExplicitCast<IChart>(restoredSlide->get_Shape(0));
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickLabelSpacing(true);
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickMarksSpacing(true);

presentation->Save(u"CategoryAxisIntervals.pptx", SaveFormat::Pptx);
```

**Automatikus távolság (1. dia):** Ebben a megjelenítésben minden második kategória címke jelenik meg és két sorba törik. Az automatikus eredmény a diagram méretétől, betűtípustól és a renderertől függően változhat.

![Automatikus kategória címke távolság a 24 oszlop mind látható állapotában](category-axis-automatic.png)

**Kézi távolság (2. dia):** Minden harmadik címke jelenik meg egy sorban, míg a jelölőpontok minden kategória intervallumnál maradnak. Az összes 24 oszlop, beleértve a címkével nem rendelkezőket is, látható marad ugyanazzal az értékkel. A 3. dia visszaállítja a fenti automatikus megjelenést.

![Kézi kategória címke intervallum hárommal, a 24 oszlop mind látható](category-axis-manual.png)

### **A megfelelő tengely és intervallum kiválasztása**

Használja ezt a kategóriaszám intervallumot szöveges kategóriatengely esetén, például egy oszlop-, vonal-, terület- vagy sávdiagram kategóriatengelyén. Oszlopdiagram esetén ez a vízszintes tengely. Vízzel sávdiagramnál a kategóriatengely függőleges, ezért alkalmazza ezeket a beállításokat a [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/) metódusra. A jelölőpont távolság a sorozat tengelyen is alkalmazható olyan diagramoknál, amelyek rendelkeznek ilyen tengellyel.

Ne használja a kategória címke távolságot egy értéktengely numerikus skálájának beállítására. Egy értéktengelyen a [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majorunit/) egy értékbeli különbséget határoz meg: például a `10` fő egység 0, 10, 20, stb. jelölőket hoz létre, ha a tengely nullánál kezdődik. A `3` kategória címke intervallum csak a kategóriahelyeket számlálja, az értékek függetlenek. Szórt és buborék diagramok értéktengelyeket használnak, nem szöveges kategóriatengelyt. Dátumtengely esetén használjon időalapú fő egységeket és skálákat, ahogy a [Change a Category Axis](#change-a-category-axis) résznél leírták.

## **Dátumformátum beállítása a kategóriatengely értékeihez**

A példa az alapértelmezett diagram adatokat négy éves értékkel helyettesíti. A dátumok OLE Automation sorozatszámként tárolódnak az első munkalapon (index `0`). Használja a [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) metódust egy dátumtengely kiválasztásához, tiltsa le a forrásra hivatkozó formázást a [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isnumberformatlinkedtosource/) segítségével, és állítsa a `yyyy` formátumot a [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_numberformat/) metódussal, hogy a kategória címkék négyjegyű évszámot mutassanak a cella formázástól függetlenül.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/CategoryAxisType.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <system/object_ext.h>
#include <system/date_time.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 50, 50, 450, 300);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
for (auto i = 0; i < 4; i++)
{
    auto date = System::DateTime(2015 + i, 1, 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(date.ToOADate()));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(i + 1));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

chart->get_Axes()->get_HorizontalAxis()->set_CategoryAxisType(CategoryAxisType::Date);
chart->get_Axes()->get_HorizontalAxis()->set_IsNumberFormatLinkedToSource(false);
chart->get_Axes()->get_HorizontalAxis()->set_NumberFormat(u"yyyy");

presentation->Save(u"DateAxisFormat.pptx", SaveFormat::Pptx);
```

## **A diagramtengely címének forgatási szöge beállítása**

Engedélyezze a függőleges tengely címét a [set_HasTitle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_hastitle/) metódussal, adja meg a cím szövegét, és a [set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextblockformat/set_rotationangle/) segítségével forgassa a címet. A szög fokokban van megadva; ez a példa egy oszlopdiagramot ment, amelynek az értéktengely címe 90 fokkal van elforgatva.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IChartTextBlockFormat.h>
#include <DOM/Chart/IChartTitle.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_HasTitle(true);
chart->get_Axes()->get_VerticalAxis()->get_Title()->AddTextFrameForOverriding(u"Value");
chart->get_Axes()->get_VerticalAxis()->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90);

presentation->Save(u"RotatedAxisTitle.pptx", SaveFormat::Pptx);
```

## **A tengely pozíciójának beállítása kategória vagy értéktengelyen**

Használja a [set_AxisBetweenCategories](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_axisbetweencategories/) metódust annak szabályozására, hogy az értéktengely a kategóriatengelyt a kategóriák között vagy a kategória jelölőpontoknál keresse keresztül. Ez a tulajdonság csak kategóriatengelyekre vonatkozik. A példa a `true` értéket állítja be egy oszlopdiagram vízszintes kategóriatengelyén, és menti az eredményt.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

presentation->Save(u"AxisBetweenCategories.pptx", SaveFormat::Pptx);
```

## **Megjelenítési egység beállítása egy diagram értéktengelyén**

Használja a [set_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_displayunit/) metódust, hogy a feliratokat egy értéktengelyen átméretezze anélkül, hogy a mögöttes adatokat megváltoztatná. A [DisplayUnitType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/displayunittype/) `Millions` értékre állításával a 60 000 000 érték 60-ként jelenik meg. A példa egy oszlopdiagramot hoz létre, és a függőleges tengelyen a milliós megjelenítési egységet alkalmazza.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <Export/SaveFormat.h>
#include <DOM/Chart/DisplayUnitType.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 450, 300);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

presentation->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **Logaritmikus értéktengely beállítása**

Egy logaritmikus értéktengely akkor hasznos, ha a pozitív értékek több nagyságrendi szinten terülnek el. Például egy szolgáltatás 10, 100, 1 000, 10 000 és 100 000 kérést kaphat öt időszakban. Lineáris skálán a kisebb értékek közel a nullához vannak összeszorozva. A logaritmikus skála a relatív növekedést könnyebben teszi összehasonlíthatóvá: az egyenlő távolságok egyenlő arányt jelentenek, nem egyenlő különbséget.

Hívja a [set_IsLogarithmic](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_islogarithmic/) metódust `true` értékkel az értéktengelyen, és a [set_LogBase](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_logbase/) segítségével válassza ki az alapot. Ez megváltoztatja, hogyan jelennek meg a meglévő értékek; nem módosítja az adatokat, és nem ad hozzá logaritmikus trendvonalat. A trendvonal egy illesztett kapcsolatot képvisel az adatokban, és egy külön funkció.

### **Az értéktengely és az alap kiválasztása**

Egy vonal- vagy oszlopdiagram esetén az értéktengely a [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/) metódus. Vízzel sávdiagram esetén a [get_HorizontalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_horizontalaxis/) metódus. Szórt és buborék diagramok két értéktengellyel rendelkeznek, így az X értékekhez választható a vízszintes tengely, a Y értékekhez a függőleges, vagy mindkettő. Ne alkalmazza a logaritmikus skálázást kategóriatengelyen.

Az alapértelmezett logaritmikus alap `10`. PPTX diagramok esetén az alap `2` és `1000` közötti (beleértve) érték lehet; a törtes értékek, például `2.5`, is támogatottak. A `10` alap esetén a sorozatos hatványok, mint 10, 100, 1 000, 10 000 egyenlő távolságra helyezkednek el.

### **Lineáris és logaritmikus skálázás összehasonlítása**

A következő önálló példa egy vonaldiagramot hoz létre az öt kérés számával az első dián, majd klónozza azt, és a második dián engedélyezi a 10-es alapú logaritmikus értéktengelyt. Mindkét dia ugyanazt az adatot tartalmazza.

```cpp
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartDataWorkbook.h>
#include <DOM/Chart/IChartDataCell.h>
#include <DOM/Chart/IChartCategoryCollection.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <DOM/Chart/IChartDataPointCollection.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <array>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::Line, 30, 40, 660, 200);

chart->set_HasLegend(false);

chart->get_ChartData()->get_Categories()->Clear();
chart->get_ChartData()->get_Series()->Clear();

auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();
workbook->Clear(0);

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto values = std::array<double, 5>{10, 100, 1000, 10000, 100000};

for (auto i = 0; i < values.size(); i++)
{
    auto categoryName = System::String::Format(u"Period {0}", i + 1);
    auto categoryCell = workbook->GetCell(0, i + 1, 0, System::ObjectExt::Box(categoryName));
    chart->get_ChartData()->get_Categories()->Add(categoryCell);

    auto valueCell = workbook->GetCell(0, i + 1, 1, System::ObjectExt::Box(values[i]));
    series->get_DataPoints()->AddDataPointForLineSeries(valueCell);
}

// Az első diát lineáris maradjon, és csak a másolat értéktengelyének skáláját módosítsa.
auto logarithmicSlide = presentation->get_Slides()->AddClone(slide);
auto logarithmicChart = System::ExplicitCast<IChart>(logarithmicSlide->get_Shape(0));
auto valueAxis = logarithmicChart->get_Axes()->get_VerticalAxis();
valueAxis->set_IsLogarithmic(true);
valueAxis->set_LogBase(10);

presentation->Save(u"LogarithmicAxis.pptx", SaveFormat::Pptx);
```

**Lineáris skála (1. dia):** Az egyenlő függőleges távolságok egyenlő különbségeket jelentenek a kérési számokban. A legnagyobb érték uralja a diagramot, így a kisebb értékek megkülönböztetése nehéz.

![Vonaldiagram PowerPointban, amely öt kérés számát mutatja egy lineáris értéktengelyen](value-axis-linear.png)

**Logaritmikus skála (2. dia):** Az egyenlő függőleges távolságok egyenlő arányokat jelentenek. Minden időszak tízszer annyi kérést tartalmaz, mint az előző, így a pontok egy egyenesen emelkedő vonalat alkotnak a 10-es alapú skálán. A tengelycímkék továbbra is az eredeti kérés számokat mutatják.

![Ugyanaz az öt kérés száma PowerPointban egy 10-es alapú logaritmikus értéktengelyen](value-axis-logarithmic.png)

### **Nulla és negatív értékek kezelése**

Egy logaritmikus skála csak szigorúan pozitív értékeket jeleníthet meg. Ellenőrizze az adatokat, mielőtt engedélyezné. Ha a nulla vagy negatív értékek jelentősek, használjon lineáris skálát vagy jelenítse meg azokat külön. Ha azok kizárása megfelelő az elemzéshez, magyarázza el az eltávolítást. Ne cserélje le őket hallgatólagosan kis pozitív számokra, mert ezzel megváltozik az adatok jelentése. Bármely manuálisan beállított minimum vagy maximum logaritmikus tengelyen is pozitív kell legyen.

## **GYIK**

**Hogyan állíthatom be azt az értéket, ahol egy tengely a másikat metszik (tengelykereszteződés)?**  
Használja a [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) metódust a keresztezési viselkedés kiválasztásához. Numerikus keresztezési érték megadásához használja a [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/) metódust. Ezek a beállítások lehetővé teszik a tengelykeresztezés mozgatását egy megfelelő alapvonalra.

**Hogyan helyezhetem el a jelölőcímkéket a tengelyhez viszonyítva?**  
Használja a [set_TickLabelPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_ticklabelposition/) metódust egy [TickLabelPositionType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ticklabelpositiontype/) értékkel: `Low`, `High`, `NextTo` vagy `None`. A jelölőpontok szabályozásához használja a [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) vagy a [set_MinorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_minortickmark/) metódusokat; ezek különállók a címkepozícionálástól.