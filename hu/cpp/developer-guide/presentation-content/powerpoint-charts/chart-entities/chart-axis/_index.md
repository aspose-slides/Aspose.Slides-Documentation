---
title: Diagramtengelyek testreszabása prezentációkban C++ használatával
linktitle: Diagramtengely
type: docs
url: /hu/cpp/chart-axis/
keywords:
- diagramtengely
- függőleges tengely
- vízszintes tengely
- tengely testreszabása
- tengely manipulálása
- tengely kezelése
- tengely tulajdonságok
- maximális érték
- minimális érték
- tengelyvonal
- dátumformátum
- tengelycím
- tengelypozíció
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Fedezze fel, hogyan használhatja az Aspose.Slides for C++-t a diagramtengelyek testreszabásához PowerPoint prezentációkban jelentések és vizualizációk készítéséhez."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testre szabni a diagram tengelyeket az Aspose.Slides for C++ segítségével. Bemutatja a számított tengelyértékeket, a diagram sorok és oszlopok cseréjét, a tengely láthatóságát, a kategória címke- és jelölőskálákat, a dátumkategóriákat és formázást, a cím forgatását, a tengely elhelyezését, a megjelenítési egységeket és a logaritmikus skálázást.

## **A maximális értékek lekérése a függőleges tengelyen diagramokon**

Hozzon létre egy [Prezentáció](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) és adjon hozzá egy területdiagramot alapértelmezett adatokkal. Hívja meg a [ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/validatechartlayout/) függvényt a számított tengelyértékek olvasása előtt, hogy a diagram elrendezése naprakész legyen.

Olvassa a [get_ActualMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmaxvalue/) és a [get_ActualMinValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminvalue/) értékeket a tengely határokhoz, valamint a [get_ActualMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunit/) és a [get_ActualMinorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunit/) értékeket a jelölőskálákhoz. A [get_ActualMajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunitscale/) és a [get_ActualMinorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunitscale/) időegység-méreteket adnak, amelyek dátumtengelyeknél relevánsak. A példa ezeket az értékeket helyi változókba tárolja, és elmenti a diagramot.

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

## **Adatok cseréje a tengelyek között**

Használja a [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) metódust a sorozatok és kategóriák szerepének felcseréléséhez a diagram adataiban. Minden korábbi kategória sorozattá, minden korábbi sorozat pedig kategóriává válik. Ez megváltoztatja az adatok csoportosítását; nem cseréli fel a vízszintes és függőleges tengelyeket. A példa a [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setrange/) metódust használja az alapértelmezett adatok `Sheet1!A1:D5` tartományra kötéséhez, beleértve a fejlécsort és a kategóriaoszlopot, a sorok és oszlopok cseréje előtt. Egy négy sorozatú és három kategóriás diagramot ment.

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

## **Tengely rajzolási sorrendjének megfordítása**

Használja a [set_IsPlotOrderReversed](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isplotorderreversed/) metódust egy kategória‑ vagy értéktengely megfordításához. Például egy vízszintes sávdiagram megjelenítheti a projekt fázisait felülről lefelé ugyanabban a sorrendben, mint a munkalapon: Tervezés, Fejlesztés, Tesztelés. Egy tengely megfordítása a rajzolás irányát változtatja; nem rendezi vagy átrendezi a munkafüzet adatait. Ezzel szemben a [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) felcseréli a sorozatok és kategóriák szerepét.

Az alábbi példa egy három fázisú és egy sorozatos vízszintes sávdiagramot hoz létre. Három diát ment: normál sorrend, megfordított kategóriák, megfordított értékek. Minden másolat ugyanazt az adathalmazt használja, és minden másolaton csak egy tengely van megfordítva.

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

// 2. dia: az első kategória megjelenítése felül.
auto categorySlide = presentation->get_Slides()->AddClone(slide);
auto categoryChart = System::ExplicitCast<IChart>(categorySlide->get_Shape(0));
categoryChart->get_Axes()->get_VerticalAxis()->set_IsPlotOrderReversed(true);
// A vízszintes értéktengely megtartása alul.
categoryChart->get_Axes()->get_VerticalAxis()->set_CrossType(CrossesType::Maximum);

// 3. dia: csak a vízszintes numerikus skála megfordítása.
auto valueSlide = presentation->get_Slides()->AddClone(slide);
auto valueChart = System::ExplicitCast<IChart>(valueSlide->get_Shape(0));
valueChart->get_Axes()->get_HorizontalAxis()->set_IsPlotOrderReversed(true);

presentation->Save(u"ReversedAxes.pptx", SaveFormat::Pptx);
```

A tengely megfordítása azt is lehetővé teszi, hogy a merőleges tengely a diagram másik oldalára kerüljön. A [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) szabályozza, hogy a másik tengely hol metszze a konfigurált tengelyt. A 2. dián a `Maximum` érték beállítása a megfordított kategóriatengelyen a vízszintes értéktengelyt alul tartja. Egy konkrét metszéspontnál használja a [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/) metódust. Ellenőrizze a metszéspont beállításait az irányváltáskor, különösen ha a diagram már rendelkezik egy egyéni metszésponttal. Hívja a `set_IsPlotOrderReversed`‑t `false` értékkel a normál rajzolási irány visszaállításához; a metszéspont beállítások külön állnak.

| Normál sorrend (1. dia) | Megfordított kategóriák (2. dia) | Megfordított értékek (3. dia) |
| --- | --- | --- |
| ![Vízszintes sávdiagram normál kategória‑ és értéktengely sorrenddel](axis-order-normal.png) | ![Vízszintes sávdiagram, ahol a kategóriák felülről lefelé jelennek meg](axis-order-categories-reversed.png) | ![Vízszintes sávdiagram megfordított értéktengellyel, nullával jobbra](axis-order-values-reversed.png) |
| A kategóriák alulról felfelé haladnak; az értékek balról jobbra nőnek. | A Tervezés, Fejlesztés és Tesztelés felülről lefelé halad. Az értékek és a munkafüzet sorok sorrendje változatlan. | A kategóriák megtartják normál sorrendjüket; az értékek jobbról balra nőnek. A kategóriatengely a jobb oldalon, nullán keresztül metsződik. |

## **Függőleges tengely letiltása vonaldiagramoknál**

Használja a [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) metódust `false` értékkel a függőleges tengelyen a rejtéshez. A példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, és elmenti a függőleges tengely elrejtve.

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

## **Vízszintes tengely letiltása vonaldiagramoknál**

Használja a [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) metódust `false` értékkel a vízszintes tengelyen a rejtéshez. A példa egy alapértelmezett adatokkal rendelkező vonaldiagramot hoz létre, és elmenti a vízszintes tengely elrejtve.

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

## **Kategóriatengely módosítása**

Használja a [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) metódust dátum vagy szöveges kategóriatengely kiválasztásához. Ez a példához a `ExistingChart.pptx` fájlra van szükség, amelynek első diáján az első alakzat egy diagram, és a kategória cellák numerikus Excel dátumértékeket tartalmaznak. A vízszintes tengelyt dátumtengelyre állítja. A [set_IsAutomaticMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isautomaticmajorunit/) `false`, a [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunit/) `1`, valamint a [set_MajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunitscale/) `Months` beállítása egyhónapos fő jelölőket eredményez.

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

## **Kategóriatengely címkeintervallumok vezérlése**

Amikor egy diagram sok kategóriát tartalmaz, csökkentheti a látható tengelycímkék számát a kategóriák vagy adatpontok eltávolítása nélkül. Állítsa a [set_IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticticklabelspacing/) `false` értéket, majd a [set_TickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_ticklabelspacing/) segítségével adja meg a kívánt kategória‑intervallumot. Szöveges kategóriák esetén a normál sorrendben a számozás az első kategóriától indul:

| Intervallum | A példában megjelenített címkék |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

A `3` intervallum minden harmadik címkét jelenít meg, a két közötte lévő címkét elrejtve. Nem távolítja el a megfelelő oszlopokat. Az automatikus távolság a rendelkezésre álló hely alapján választ intervallumot; nem feltétlenül jeleníti meg az összes címkét.

A jelölőskálák külön vezérelhetők. Állítsa a [set_IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomatictickmarksspacing/) `false` értéket, és a [set_TickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_tickmarksspacing/) segítségével adja meg azok intervallumát. Például a `1` minden kategória‑intervallumnál jelölőt helyez el, míg a címkék csak minden harmadik kategórián jelennek meg. A [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majortickmark/) látható stílus beállítása megmutatja az eredményt. Bármelyik automatikus‑távolság‑tulajdonság visszaállítása `true`-ra hagyja, hogy a diagram újra kiválassza az intervallumot.

Az alábbi önálló példa 24 kategóriát és egy sorozatot hoz létre, majd három diát ment `CategoryAxisIntervals.pptx` néven: automatikus távolság, manuális címke‑távolság független jelölőkkel, és visszaállított automatikus távolság. A két másolat az eredeti diagramadatokat tartja. Bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató bemutató.

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

// 2. dia: minden harmadik címke megjelenítése, de jelölő minden kategóriához marad.
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

**Automatikus távolság (1. dia):** Ebben a megjelenítésben minden második kategória címke látható, és két sorba törik. Az automatikus eredmény a diagram méretétől, betűtípusaitól és a renderertől függően változhat.

![Automatikus kategóriacímke távolság, minden 24 oszlop látható](category-axis-automatic.png)

**Manuális távolság (2. dia):** Minden harmadik címke jelenik meg egy sorban, míg a jelölők minden kategória‑intervallumnál megmaradnak. Az összes 24 oszlop, beleértve a címke nélküli oszlopokat is, látható ugyanazzal az értékkel. A 3. dia visszaállítja a fenti automatikus megjelenést.

![Manuális kategóriacímke intervallum három, minden 24 oszlop látható](category-axis-manual.png)

### **Válassza ki a megfelelő tengelyt és intervallumot**

Használja ezt a kategóriaszám‑intervallumot szöveges kategóriatengely esetén, például oszlop-, vonal-, terület- vagy sávdiagram kategóriatengelyén. Oszlopdiagram esetén ez a vízszintes tengely. Vízszintes sávdiagram esetén a kategóriatengely függőleges, ezért alkalmazza ezeket a beállításokat a [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/)-ra. A jelölőskálák a sorozattengelyre is vonatkoznak azoknál a diagramoknál, amelyeknek van ilyen.

Ne használja a kategória‑címke‑távolságot az értéktengely numerikus skálájának beállítására. Egy értéktengelyen a [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majorunit/) érték a tényleges értékkülönbséget adja meg: például a `10` főegység 0, 10, 20 stb. értékeken jelöl. A `3` kategória‑címke‑intervallum csak a kategória‑pozíciókat számolja, függetlenül az adatértékektől. Szórt és buborék diagramok értéktengelyeket használnak, nem szöveges kategóriatengelyt. Dátumtengely esetén használjon időalapú főegységeket és skálákat a [Kategóriatengely módosítása](#kategóriatengely-módosítása) szakaszban leírtak szerint.

## **Dátumformátum beállítása a kategóriatengely értékekhez**

A példa a alapértelmezett diagramadatokat négy éves értékre cseréli. A dátumok OLE Automation sorozatszámként vannak tárolva az első munkalapon (index `0`). Használja a [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) metódust dátumtengely kiválasztásához, tiltsa le a forrás‑kötött formázást a [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isnumberformatlinkedtosource/) segítségével, és a [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_numberformat/) segítségével adja meg a `yyyy` formátumot, hogy a kategóriacímkék a négyjegyű éveket jelenítsék meg a cella formázástól függetlenül.

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

## **Forgatási szög beállítása egy diagramtengely címéhez**

Kapcsolja be a függőleges tengely címét a [set_HasTitle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_hastitle/) metódussal, adja meg a címszöveget, és használja a [set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextblockformat/set_rotationangle/) metódust a cím forgatásához. A szög fokban van megadva; ez a példa egy oszlopdiagramot ment el, amelynek az értéktengely címe 90 fokkal van elforgatva.

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

## **Tengelypozíció beállítása kategória‑ vagy értéktengelyen**

Használja a [set_AxisBetweenCategories](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_axisbetweencategories/) metódust annak szabályozására, hogy az értéktengely a kategóriatengelyt a kategóriák között vagy a kategória‑jelölőkön keresztül metszze. Ez a tulajdonság a kategóriatengelyekre vonatkozik. A példa a vízszintes kategóriatengelyen `true` értékkel állítja be egy oszlopdiagramon, és elmenti az eredményt.

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

Használja a [set_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_displayunit/) metódust az értéktengely feliratainak méretezésére az adat tényleges módosítása nélkül. A [DisplayUnitType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/displayunittype/) `Millions` beállításával a 60 000 000 érték 60‑ként jelenik meg. A példa egy oszlopdiagramot hoz létre, és a függőleges tengelyen alkalmazza a milliók megjelenítési egységét.

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

## **Logaritmikus értéktengely konfigurálása**

A logaritmikus értéktengely hasznos, ha pozitív értékek több nagyságrendi lépcsőben terjednek. Például egy szolgáltatás 10, 100, 1 000, 10 000 és 100 000 kérést kaphat öt időszakban. Lineáris skálán a kisebb értékek közel nulla helyen csoportosulnak. A logaritmikus skála a relatív növekedést könnyebben összehasonlíthatóvá teszi: az egyenlő távolságok egyenlő arányokat jelentenek, nem egyenlő különbségeket.

Hívja a [set_IsLogarithmic](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_islogarithmic/) metódust `true` értékkel az értéktengelyen, és használja a [set_LogBase](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_logbase/) metódust az alap kiválasztásához. Ez megváltoztatja a meglévő értékek megjelenését; nem módosítja az adatot, és nem ad hozzá logaritmikus trendvonalat. A trendvonal egy külön funkció, amely a adatokhoz illeszkedő kapcsolatot ábrázolja.

### **Az értéktengely és az alap kiválasztása**

Vonal- vagy oszlopdiagram esetén az értéktengely a [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). Vízszintes sávdiagram esetén a [get_HorizontalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_horizontalaxis/). Szórt és buborék diagramoknak két értéktengelyük van, ezért válassza a vízszintes tengelyt az X‑értékekhez, a függőleges tengelyt a Y‑értékekhez, vagy mindkettőt. Ne alkalmazzon logaritmikus skálázást egy kategóriatengelyen.

Az alapértelmezett logaritmikus alap a `10`. PPTX diagramok esetén az alap lehet `2` és `1000` között, inkluzíve; a tört alapok, például `2.5`, szintén támogatottak. A `10` alappal a sorozatos hatványok (10, 100, 1 000, 10 000) egyenlő távolságra helyezkednek el.

### **Lineáris és logaritmikus skálázás összehasonlítása**

Az alábbi önálló példa egy vonaldiagramot hoz létre az öt kérelem számával az első dián, majd klónozza azt, és a második dián engedélyezi a 10‑es alapú logaritmikus értéktengelyt. Mindkét dia ugyanazt az adatot tartalmazza.

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

// Tartsa az első diát lineárisnak, és csak a másolat értéktengelyének skáláját változtassa meg.
auto logarithmicSlide = presentation->get_Slides()->AddClone(slide);
auto logarithmicChart = System::ExplicitCast<IChart>(logarithmicSlide->get_Shape(0));
auto valueAxis = logarithmicChart->get_Axes()->get_VerticalAxis();
valueAxis->set_IsLogarithmic(true);
valueAxis->set_LogBase(10);

presentation->Save(u"LogarithmicAxis.pptx", SaveFormat::Pptx);
```

**Lineáris skála (1. dia):** Az egyenlő függőleges távolságok egyenlő különbségeket jelentenek a kérelem számában. A legnagyobb érték uralja a diagramot, a kisebb értékek nehezen megkülönböztethetők.

![Vonaldiagram PowerPointban, amely öt kérelem számot mutat lineáris értéktengelyen](value-axis-linear.png)

**Logaritmikus skála (2. dia):** Az egyenlő függőleges távolságok egyenlő arányokat jelentenek. Minden periódus tízszer annyi kérelmet tartalmaz, mint az előző, így a pontok egy egyenes, felfelé ívelő vonalat alkotnak a 10‑es alapú skálán. Az tengelycímkék továbbra is az eredeti kérelem számokat mutatják.

![Ugyanaz az öt kérelem szám PowerPointban, 10‑es logaritmikus értéktengelyen](value-axis-logarithmic.png)

### **Nulla és negatív értékek kezelése**

Logaritmikus skála csak szigorúan pozitív értékeket képes megjeleníteni. Ellenőrizze az adatokat a bekapcsolás előtt. Ha a nulla vagy a negatív értékek jelentősek, használjon lineáris skálát vagy jelenítse meg őket külön. Ha az ilyen értékek kizárása megfelelő az elemzéshez, magyarázza el a kihagyást. Ne cserélje ki őket csendben kis pozitív számokra, mivel ez megváltoztatja az adatok jelentését. Bármely, logaritmikus tengelyhez manuálisan beállított minimum vagy maximum értéknek szintén pozitívnak kell lennie.

## **GYIK**

**Hogyan állíthatom be azt az értéket, ahol az egyik tengely a másikat metszik (tengelykereszt)?**

Használja a [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) metódust a keresztezési viselkedés kiválasztásához. Számszerű keresztezési érték megadásához használja a [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/) metódust. Ezek a beállítások lehetővé teszik a tengelykeresztezés megfelelő alapvonalra történő áthelyezését.

**Hogyan helyezhetem el a jelölőcímkéket a tengelyhez viszonyítva?**

Használja a [set_TickLabelPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_ticklabelposition/) metódust, a [TickLabelPositionType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ticklabelpositiontype/) egyik értékével: `Low`, `High`, `NextTo` vagy `None`. A jelölőket magukat a [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) vagy a [set_MinorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_minortickmark/) segítségével szabályozhatja; ezek különállóak a címke‑pozicionálástól.