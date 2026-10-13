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
- tengelyvonal
- dátumformátum
- tengelycím
- tengely pozíció
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Fedezze fel, hogyan használhatja az Aspose.Slides for C++-t a diagram tengelyek testreszabására PowerPoint prezentációkban jelentésekhez és vizualizációkhoz."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet testreszabni a diagram tengelyeit az Aspose.Slides for C++ használatával. Kitér a kiszámított tengelyértékekre, a diagram sorok és oszlopok cseréjére, a tengely láthatóságára, a kategória címke- és jelölőintervallumokra, a dátumkategóriákra és formázásukra, a cím forgatására, a tengely elhelyezésére, a megjelenítési egységekre és a logaritmikus skálázásra.

## **A függőleges tengely legnagyobb értékeinek lekérése a diagramokon**

Hozzon létre egy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) és adjon hozzá egy alapértelmezett adatú területdiagramot. Hívja meg a [ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/validatechartlayout/) metódust a kiszámított tengelyértékek olvasása előtt, hogy a diagram elrendezése naprakész legyen.

Olvassa el a [get_ActualMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmaxvalue/) és [get_ActualMinValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminvalue/) metódusokat a tengelyhatárokhoz, valamint a [get_ActualMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunit/) és [get_ActualMinorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunit/) metódusokat a jelölőintervallumokhoz. A [get_ActualMajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunitscale/) és a [get_ActualMinorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunitscale/) időegység skálákat ad vissza, amelyek a dátumtengelyekhez relevánsak. A példa ezeket az értékeket helyi változókba tárolja, majd elmenti a diagramot.

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

## **Az adatok cseréje a tengelyek között**

Használja a [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) metódust a sorozatok és kategóriák szerepének felcserélésére a diagram adataiban. Minden korábbi kategória sorozattá, minden korábbi sorozat pedig kategóriává válik. Ez megváltoztatja az adatok csoportosítási módját; nem cseréli fel a vízszintes és függőleges tengelyeket. A példa a [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setrange/) metódust használja, hogy az alapértelmezett adatot a `Sheet1!A1:D5` tartományra (fejlécsor és kategóriaoszlop beleértve) kötse, mielőtt a sorokat és oszlopokat felcserélné. Egy négy sorozatú és három kategóriás diagramot ment el.

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

## **Függőleges tengely letiltása vonaldiagramoknál**

Használja a [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) metódust `false` értékkel a függőleges tengelyen, hogy elrejtse azt. A példa egy vonaldiagramot hoz létre alapértelmezett adatokkal, és a függőleges tengely elrejtésével menti el.

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

Használja a [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) metódust `false` értékkel a vízszintes tengelyen, hogy elrejtse azt. A példa egy vonaldiagramot hoz létre alapértelmezett adatokkal, és a vízszintes tengely elrejtésével menti el.

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

## **Kategória tengely módosítása**

Használja a [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) metódust, hogy dátum vagy szöveges kategória tengelyt válasszon. Ez a példa az `ExistingChart.pptx` fájlt igényli, amelyben a diagram az első dián az első alakzat, a kategória cellák pedig numerikus Excel dátumértékeket tartalmaznak. A vízszintes tengelyt dátumtengellyé változtatja. A [set_IsAutomaticMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isautomaticmajorunit/) `false`, a [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunit/) `1`, valamint a [set_MajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunitscale/) hónapok beállítása azt eredményezi, hogy a fő jelölők egy‑hónapos intervallumra kerülnek.

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

## **Kategória tengely címkeintervallumok vezérlése**

Amikor egy diagram sok kategóriát tartalmaz, a látható tengelycímkék számát csökkenthetjük a kategóriák vagy adatpontok eltávolítása nélkül. Használja a [set_IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticticklabelspacing/) `false` beállítást, majd a [set_TickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_ticklabelspacing/) metódust a kívánt kategória intervallummal. Szöveges kategóriák esetén a normál sorrendben a számlálás az első kategóriától indul:

| Intervallum | Példában megjelenített címkék |
| --- | --- |
| `1` | Kategória 1, Kategória 2, Kategória 3, … Kategória 24 |
| `2` | Kategória 1, Kategória 3, Kategória 5, … Kategória 23 |
| `3` | Kategória 1, Kategória 4, Kategória 7, … Kategória 22 |

A `3` intervallum minden harmadik címkét jelenít meg, a megjelenített címkék között két címke marad rejtve. Nem távolítja el a megfelelő oszlopokat. Az automatikus távolság a rendelkezésre álló hely alapján választ intervallumot; nem feltétlenül jeleníti meg az összes címkét.

A jelölőpontoknak külön vezérlése is van. Használja a [set_IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomatictickmarksspacing/) `false` beállítást, majd a [set_TickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_tickmarksspacing/) metódust az intervallum beállításához. Például az `1` azt eredményezi, hogy minden kategória intervallumban van jelölőpont, míg a címkék csak minden harmadik kategóriánál jelennek meg. A [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majortickmark/) egy látható stílussal segít a végeredmény megtekintésében. Bármelyik automatikus távolság‑tulajdonság visszaállítása `true` értékre engedélyezi, hogy a diagram újra automatikusan válasszon intervallumot.

A következő önálló példában 24 kategóriát és egy sorozatot hozunk létre, majd három diát mentünk a `CategoryAxisIntervals.pptx` fájlba: automatikus távolság, kézi címke‑távolság független jelölőpontokkal, és az automatikus távolság visszaállítása. A két másolat az eredeti diagramadatokat őrzi. Bemutató prezentáció nem szükséges. A vízszintes címkeszöveg könnyen láthatóvá teszi a sűrűség különbségét.

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

// Slide 2: mutassa minden harmadik címkét, de tartson meg egy jelölőpontot minden kategóriához.
auto manualSlide = presentation->get_Slides()->AddClone(slide);
auto manualChart = System::ExplicitCast<IChart>(manualSlide->get_Shape(0));
auto manualAxis = manualChart->get_Axes()->get_HorizontalAxis();
manualAxis->set_IsAutomaticTickLabelSpacing(false);
manualAxis->set_TickLabelSpacing(3);
manualAxis->set_IsAutomaticTickMarksSpacing(false);
manualAxis->set_TickMarksSpacing(1);

// Slide 3: hagyja, hogy a diagram újra kiválassza mindkét intervallumot.
auto restoredSlide = presentation->get_Slides()->AddClone(manualSlide);
auto restoredChart = System::ExplicitCast<IChart>(restoredSlide->get_Shape(0));
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickLabelSpacing(true);
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickMarksSpacing(true);

presentation->Save(u"CategoryAxisIntervals.pptx", SaveFormat::Pptx);
```

**Automatikus távolság (dia 1):** Ebben a megjelenítésben minden második kategória címke látszik, és két sorba törik. Az automatikus eredmény a diagram méretétől, betűtípusától és a renderelőtől függ.

![Automatikus kategória címke távolság, minden 24 oszlop látható](category-axis-automatic.png)

**Kézi távolság (dia 2):** Minden harmadik címke jelenik meg egy sorban, miközben a jelölőpontok minden kategória intervallumban megmaradnak. Az összes 24 oszlop, beleértve a címke nélküli oszlopokat is, látható ugyanazokkal az értékekkel. A 3. dia visszaállítja a fent bemutatott automatikus megjelenést.

![Kézi kategória címke intervallum háromra, minden 24 oszlop látható](category-axis-manual.png)

### **A megfelelő tengely és intervallum kiválasztása**

Használja ezt a kategóriaszám‑intervallumot szöveges kategória tengely esetén, például oszlop, vonal, terület vagy sáv diagram kategória tengelyén. Oszlopdiagram esetén ez a vízszintes tengely. Vízszintes sáv diagram esetén a kategória tengely függőleges, ezért ezeket a beállításokat a [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/) metódusra kell alkalmazni. A jelölőpont‑távolság egy sorozat‑tengelyre is vonatkozik azokban a diagramokban, amelyeknek van ilyen.

Ne használja a kategória címke‑távolságot az értéktengely numerikus skálájának beállítására. Az értéktengelyen a [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majorunit/) a különbséget határozza meg: például a `10` fő egység 0, 10, 20 stb. értékekre ad jelölőpontot, ha a tengely nullánál kezdődik. A `3` kategória címke‑intervallum ezzel szemben a kategória pozíciókat számolja, függetlenül azok adatértékétől. Szórt és buborék diagramok értéktengelyt használnak, nem szöveges kategória tengelyt. Dátumtengely esetén használjon időalapú fő egységeket és skálákat, ahogy azt a [Kategória tengely módosítása](#change-a-category-axis) részben leírtuk.

## **A kategória tengely értékek dátumformátumának beállítása**

A példa négy éves értékkel helyettesíti az alapértelmezett diagramadatokat. A dátumok OLE Automation sorozatszámként vannak tárolva az első munkalapon (index `0`). Használja a [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) metódust, hogy dátumtengelyt válasszon, a forráshoz kapcsolódó formázást a [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isnumberformatlinkedtosource/) `false` értékével tiltsa le, és a [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_numberformat/) `yyyy` formátummal adja meg, hogy a kategória címkék négyjegyű évet mutassanak a cella formázásától függetlenül.

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

## **Forgatási szög beállítása a diagram tengelycíméhez**

A függőleges tengely címke engedélyezhető a [set_HasTitle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_hastitle/) metódussal, megadva a cím szövegét, majd a [set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextblockformat/set_rotationangle/) metódussal forgatható. A szög fokban van megadva; ez a példa egy oszlopdiagramot ment el, amelynek az értéktengely címkéje 90 fokkal van elforgatva.

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

Használja a [set_AxisBetweenCategories](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_axisbetweencategories/) metódust, hogy meghatározza, az értéktengely a kategória tengely közepén vagy a kategória jelölőpontoknál metszi-e. Ez a tulajdonság csak kategória tengelyekre vonatkozik. A példa a vízszintes kategória tengelyen `true` értékkel állítja be, majd elmenti a diagramot.

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

## **Megjelenítési egység beállítása diagram értéktengelyen**

Használja a [set_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_displayunit/) metódust, hogy a címkék méretét az értéktengelyen átméretezze anélkül, hogy a mögöttes adatot módosítaná. A [DisplayUnitType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/displayunittype/) `Millions` beállításával a 60 000 000 érték 60‑ként jelenik meg. A példa egy oszlopdiagramot hoz létre, és a függőleges tengelyen a millió megjelenítési egységet alkalmazza.

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

A logaritmikus értéktengely hasznos, ha a pozitív értékek több nagyságrendet fednek le. Például egy szolgáltatás öt időszakban 10, 100, 1 000, 10 000 és 100 000 kérést kap. Lineáris skálán a kisebb értékek közel fognak egymáshoz jelenni a nullához. A logaritmikus skála a relatív növekedést könnyebben összehasonlíthatóvá teszi: az egyenlő távolságok egyenlő arányt jelentenek, nem egyenlő különbséget.

Hívja meg a [set_IsLogarithmic](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_islogarithmic/) `true` értékkel az értéktengelyen, és a [set_LogBase](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_logbase/) metódussal válassza ki az alapot. Ez a meglévő értékek megjelenítését változtatja meg; nem módosítja az adatot, és nem ad hozzá logaritmikus trendvonalat. A trendvonal egy külön funkció, amely az adatokhoz illesztett kapcsolatot ábrázolja.

### **Az értéktengely és az alap kiválasztása**

Vonal vagy oszlop diagram esetén az értéktengely a [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). Vízszintes sáv diagram esetén a [get_HorizontalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_horizontalaxis/). Szórt és buborék diagramok két értéktengellyel rendelkeznek, így az X‑értékekhez a vízszintes, a Y‑értékekhez a függőleges tengelyt, vagy mindkettőt választhatja. Ne alkalmazzon logaritmikus skálát kategória tengelyen.

Az alapértelmezett logaritmikus alap `10`. PPTX diagramok esetén a `2`–`1000` közötti egész vagy tört értékek is megengedettek; például a `2,5` alap is támogatott. A `10` alap esetén a 10, 100, 1 000, 10 000 sorozat egyenlő távolságra kerül.

### **Lineáris és logaritmikus skálázás összehasonlítása**

A következő önálló példa egy vonaldiagramot hoz létre, amely az öt kérési számot tartalmazza az első dián, majd lemásolja azt, és a második dián 10‑es alapú logaritmikus értéktengelyt aktivál. Mindkét dia ugyanazt az adatot őrzi.

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

// Az első diát hagyja lineárisnak, és csak a másolat értéktengelyének skáláját változtassa meg.
auto logarithmicSlide = presentation->get_Slides()->AddClone(slide);
auto logarithmicChart = System::ExplicitCast<IChart>(logarithmicSlide->get_Shape(0));
auto valueAxis = logarithmicChart->get_Axes()->get_VerticalAxis();
valueAxis->set_IsLogarithmic(true);
valueAxis->set_LogBase(10);

presentation->Save(u"LogarithmicAxis.pptx", SaveFormat::Pptx);
```

**Lineáris skála (dia 1):** Az egyenlő függőleges távolságok egyenlő különbségeket jelentenek a kérési számokban. A legnagyobb érték uralja a diagramot, így a kisebb értékek nehezen különíthetők el.

![vonaldiagram PowerPointban, amely öt kérési számot mutat lineáris értéktengelyen](value-axis-linear.png)

**Logaritmikus skála (dia 2):** Az egyenlő függőleges távolságok egyenlő arányokat jelentenek. Minden időszak a előző tízszeres kérésszámot tartalmaz, ezért a pontok egy egyenes vonalat alkotnak a 10‑es alapú skálán. A tengelycímkék továbbra is az eredeti kérési számokat mutatják.

![Azonos öt kérési szám PowerPointban, 10‑es alapú logaritmikus értéktengelyen](value-axis-logarithmic.png)

### **Nulla és negatív értékek kezelése**

A logaritmikus skála csak szigorúan pozitív értékeket jeleníthet meg. Ellenőrizze az adatokat, mielőtt engedélyezi. Ha a nulla vagy negatív értékek jelentősek, használjon lineáris skálát, vagy jelenítse meg őket külön. Ha az értékek kizárása indokolt a felülvizsgálat szempontjából, magyarázza el az elhagyást. Ne cserélje le őket csendben kis pozitív számokra, mivel ez megváltoztatja az adatok jelentését. Bármely manuálisan konfigurált minimum vagy maximum a logaritmikus tengelyen is pozitív kell legyen.

## **GYIK**

**Hogyan állítható be, hogy egy tengely hol metsződik a másikkal (tengelymetszés)?**

Használja a [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) metódust a metszési magatartás kiválasztásához. Numerikus metszési érték megadásához használja a [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/) metódust. Ezek a beállítások lehetővé teszik, hogy a tengelymetszést egy megfelelő alapvonalra mozdítsa.

**Hogyan helyezhetők el a jelölőcímkék a tengelyhez viszonyítva?**

Használja a [set_TickLabelPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_ticklabelposition/) metódust a [TickLabelPositionType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ticklabelpositiontype/) egyik értékével: `Low`, `High`, `NextTo` vagy `None`. A jelölőpontok önálló vezérléséhez használja a [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) vagy a [set_MinorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_minortickmark/) metódusokat; ezek különállnak a címke‑pozicionálástól.