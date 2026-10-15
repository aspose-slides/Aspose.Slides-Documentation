---
title: "Anpassa diagramaxlar i presentationer med C++"
linktitle: "Diagramaxel"
type: docs
url: /sv/cpp/chart-axis/
keywords:
- diagramaxel
- vertikal axel
- horisontell axel
- anpassa axel
- manipulera axel
- hantera axel
- axelegenskaper
- maxvärde
- minvärde
- axellinje
- datumformat
- axeltitel
- axelposition
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Upptäck hur du använder Aspose.Slides för C++ för att anpassa diagramaxlar i PowerPoint‑presentationer för rapporter och visualiseringar."
---
## **Översikt**

Den här artikeln förklarar hur du anpassar diagramaxlar med Aspose.Slides för C++. Den täcker beräknade axelvärden, byte av diagramrader och -kolumner, axelns synlighet, intervall för kategorimärkning och tick‑markeringar, datumkategorier och formatering, rotations av titel, axelpositionering, visningsenheter och logaritmisk skalning.

## **Hämta maxvärdena på den vertikala axeln i diagram**

Skapa en [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) och lägg till ett ytdiagram med standarddata. Anropa [ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/validatechartlayout/) innan du läser beräknade axelvärden så att diagramlayouten är uppdaterad.

Läs [get_ActualMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmaxvalue/) och [get_ActualMinValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminvalue/) för axelgränserna, och [get_ActualMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunit/) och [get_ActualMinorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunit/) för tick‑intervallerna. [get_ActualMajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunitscale/) och [get_ActualMinorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunitscale/) ger tidsenhetsskalor, som är relevanta för datumaxlar. Exemplet lagrar dessa värden i lokala variabler och sparar diagrammet.

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

## **Byt data mellan axlarna**

Använd [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) för att byta rollerna mellan serier och kategorier i diagramdata. Varje tidigare kategori blir en serie, och varje tidigare serie blir en kategori. Detta ändrar hur data grupperas; det byter inte horisontella och vertikala axlar. Exemplet använder [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setrange/) för att binda standarddata till `Sheet1!A1:D5`, inklusive rubrikraden och kategori‑kolumnen, innan rader och kolumner byts. Det sparar ett diagram med fyra serier och tre kategorier.

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

## **Omvänd plotningsordning för en axel**

Använd [set_IsPlotOrderReversed](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isplotorderreversed/) för att vända en kategori‑ eller värdeaxel. Till exempel kan ett horisontellt stapeldiagram visa projektstadier från topp till botten i samma ordning som kalkylbladet: Planering, Utveckling, Testning. Att vända en axel ändrar plottningsriktningen; den sorterar inte eller omarrangerar arbetsbokens data. Till jämförelse byter [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) rollerna mellan serier och kategorier.

Följande exempel skapar ett horisontellt stapeldiagram med tre steg och en serie. Det sparar en presentation med tre bilder: normal ordning, omvända kategorier och omvända värden. Varje kopia använder samma dataset, och endast en axel är omvänd i varje kopia.

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

// Bild 2: visa den första kategorin högst upp.
auto categorySlide = presentation->get_Slides()->AddClone(slide);
auto categoryChart = System::ExplicitCast<IChart>(categorySlide->get_Shape(0));
categoryChart->get_Axes()->get_VerticalAxis()->set_IsPlotOrderReversed(true);
// Behåll den horisontella värdeaxeln längst ner.
categoryChart->get_Axes()->get_VerticalAxis()->set_CrossType(CrossesType::Maximum);

// Bild 3: vänd endast den horisontella numeriska skalan.
auto valueSlide = presentation->get_Slides()->AddClone(slide);
auto valueChart = System::ExplicitCast<IChart>(valueSlide->get_Shape(0));
valueChart->get_Axes()->get_HorizontalAxis()->set_IsPlotOrderReversed(true);

presentation->Save(u"ReversedAxes.pptx", SaveFormat::Pptx);
```

Att vända en axel kan också flytta den vinkelräta axeln till motsatt sida av diagrammet. [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) styr var den andra axeln korsar den axel som konfigureras. I bild 2, när den sätts till `Maximum` på den omvända kategori‑axeln behålls den horisontella värdeaxeln längst ner. För en specifik korsningspunkt, använd [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/). Kontrollera korsningsinställningarna när du ändrar riktning, särskilt om diagrammet redan har en anpassad korsningspunkt. Anropa `set_IsPlotOrderReversed` med `false` för att återställa normal plottningsriktning; korsningsinställningarna är separata.

| Normal ordning (slide 1) | Omvända kategorier (slide 2) | Omvända värden (slide 3) |
| --- | --- | --- |
| ![Horizontal stapeldiagram med normal kategori- och värdeaxelordning](axis-order-normal.png) | ![Horizontal stapeldiagram med kategorier visade från topp till botten](axis-order-categories-reversed.png) | ![Horizontal stapeldiagram med en omvänd värdeaxel och noll på högra sidan](axis-order-values-reversed.png) |
| Kategorier går från botten till toppen; värden ökar från vänster till höger. | Planering, Utveckling och Testning går från topp till botten. Värden och arbetsbokens radordning förblir oförändrade. | Kategorier behåller sin normala ordning; värden ökar från höger till vänster. Kategoriaxeln korsar vid noll på höger sida. |

## **Inaktivera den vertikala axeln för linjediagram**

Använd [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) med `false` på den vertikala axeln för att dölja den. Exemplet skapar ett linjediagram med standarddata och sparar det med den vertikala axeln dold.

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

## **Inaktivera den horisontella axeln för linjediagram**

Använd [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) med `false` på den horisontella axeln för att dölja den. Exemplet skapar ett linjediagram med standarddata och sparar det med den horisontella axeln dold.

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

## **Ändra en kategori‑axel**

Använd [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) för att välja en datum‑ eller textkategorie‑axel. Detta exempel kräver `ExistingChart.pptx`, med ett diagram som den första formen på den första bilden och kategori‑celler som innehåller numeriska Excel‑datumvärden. Det ändrar den horisontella axeln till en datumaxel. Anropet av [set_IsAutomaticMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isautomaticmajorunit/) med `false`, [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunit/) med `1` och [set_MajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunitscale/) med månader placerar huvudtickar med ett‑månaders intervall.

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

## **Styr intervaller för kategori‑axelmärkning**

När ett diagram har många kategorier, minska antalet synliga axel‑etiketter utan att ta bort kategorier eller datapunkter. Använd [set_IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticticklabelspacing/) med `false`, och sedan [set_TickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_ticklabelspacing/) med önskat kategoriintervall. För textkategorier i deras normala ordning börjar räknandet på den första kategorin:

| Intervall | Etiketter som visas i exemplet |
| --- | --- |
| `1` | Kategori 1, Kategori 2, Kategori 3, … Kategori 24 |
| `2` | Kategori 1, Kategori 3, Kategori 5, … Kategori 23 |
| `3` | Kategori 1, Kategori 4, Kategori 7, … Kategori 22 |

Ett intervall på `3` visar var tredje etikett och lämnar två etiketter dolda mellan de visade. Det tar inte bort motsvarande kolumner. Automatisk spacing väljer ett intervall baserat på tillgängligt utrymme; den visar inte nödvändigtvis varje etikett.

Tick‑markeringar har separata kontroller. Använd [set_IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomatictickmarksspacing/) med `false` och [set_TickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_tickmarksspacing/) för att sätta deras intervall. Till exempel behåller `1` en tick‑markering vid varje kategoriintervall medan etiketter bara visas var tredje kategori. Använd [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majortickmark/) med en synlig stil så att du kan se resultatet. Att sätta tillbaka någon av de automatiska spacing‑egenskaperna till `true` låter diagrammet välja intervallet igen.

Följande självständiga exempel skapar 24 kategorier och en serie, och sparar tre bilder i `CategoryAxisIntervals.pptx`: automatisk spacing, manuell etikett‑spacing med oberoende tick‑markeringar, och återställd automatisk spacing. De två kopiorna behåller originaldiagramdata. Ingen inmatningspresentation krävs. Horisontell etikett‑text gör skillnaden i densitet lätt att se.

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

// Bild 2: visa var tredje etikett, men behåll en tick mark för varje kategori.
auto manualSlide = presentation->get_Slides()->AddClone(slide);
auto manualChart = System::ExplicitCast<IChart>(manualSlide->get_Shape(0));
auto manualAxis = manualChart->get_Axes()->get_HorizontalAxis();
manualAxis->set_IsAutomaticTickLabelSpacing(false);
manualAxis->set_TickLabelSpacing(3);
manualAxis->set_IsAutomaticTickMarksSpacing(false);
manualAxis->set_TickMarksSpacing(1);

// Bild 3: låt diagrammet välja båda intervallerna igen.
auto restoredSlide = presentation->get_Slides()->AddClone(manualSlide);
auto restoredChart = System::ExplicitCast<IChart>(restoredSlide->get_Shape(0));
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickLabelSpacing(true);
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickMarksSpacing(true);

presentation->Save(u"CategoryAxisIntervals.pptx", SaveFormat::Pptx);
```

**Automatiskt avstånd (bild 1):** I denna rendering visas varannan kategori‑etikett och de bryts på två rader. Det automatiska resultatet kan variera med diagramstorlek, typsnitt och renderare.

![Automatiskt kategori‑etikett‑spacing med alla 24 kolumner synliga](category-axis-automatic.png)

**Manuell avstånd (bild 2):** Var tredje etikett visas på en rad, medan tick‑markeringar förblir vid varje kategoriintervall. Alla 24 kolumner, inklusive de utan etiketter, förblir synliga med samma värden. Bild 3 återställer det automatiska utseendet som visas ovan.

![Manuell kategori‑etikett‑intervall på tre med alla 24 kolumner synliga](category-axis-manual.png)

### **Välj korrekt axel och intervall**

Använd detta kategori‑räkningsintervall för en textkategorie‑axel, såsom kategori‑axeln i ett stapel-, linje‑, område‑ eller stapeldiagram. I ett stapeldiagram är det den horisontella axeln. I ett horisontellt stapeldiagram är kategori‑axeln vertikal, så applicera dessa inställningar på [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). Tick‑markering spacing gäller också för en serie‑axel i diagram som har en sådan.

Använd inte kategori‑etikett‑spacing för att ställa in den numeriska skalan på en värdeaxel. På en värdeaxel specificerar [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majorunit/) ett värdeskillnad: t.ex. ger en huvud‑enhet på `10` tick‑markeringar vid 0, 10, 20 osv. när axeln startar vid noll. Ett kategori‑etikett‑intervall på `3` räknar istället kategori‑positioner, oavsett deras datavärden. Spridnings‑ och bubbeldiagram använder värdeaxlar snarare än en textkategorie‑axel. För en datumaxel, använd tidsbaserade huvud‑enheter och skalor som beskrivs i [Ändra en kategori‑axel](#ändra-en‑kategori‑axel).

## **Ange datumformat för kategori‑axelvärden**

Exemplet ersätter standarddiagramdata med fyra årsvisa värden. Datum lagras som OLE‑Automation‑serienummer i det första kalkylbladet (index `0`). Använd [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) för att välja en datumaxel, inaktivera källa‑länkad formatering med [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isnumberformatlinkedtosource/), och tilldela `yyyy` med [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_numberformat/) så att kategori‑etiketterna visar fyrsiffriga år oberoende av cellformateringen.

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

## **Ange en rotationsvinkel för en diagramaxeltitel**

Aktivera vertikal‑axelns titel med [set_HasTitle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_hastitle/), ange titeltext och använd [set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextblockformat/set_rotationangle/) för att rotera titeln. Vinkeln mäts i grader; detta exempel sparar ett stapeldiagram med sin värde‑axeltitel roterad 90 grader.

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

## **Ange axelns position på en kategori‑ eller värdeaxel**

Använd [set_AxisBetweenCategories](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_axisbetweencategories/) för att styra om värdeaxeln korsar kategori‑axeln mellan kategorier eller vid kategori‑tick‑markeringar. Denna egenskap gäller kategori‑axlar. Exemplet sätter den till `true` på den horisontella kategori‑axeln i ett stapeldiagram och sparar resultatet.

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

## **Ange visningsenhet på en diagramvärdeaxel**

Använd [set_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_displayunit/) för att skala etiketter på en värdeaxel utan att ändra underliggande data. Med [DisplayUnitType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/displayunittype/) satt till `Millions` visas ett värde på 60 000 000 som 60. Exemplet skapar ett stapeldiagram och applicerar miljon‑visningsenheten på dess vertikala axel.

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

## **Konfigurera en logaritmisk värdeaxel**

En logaritmisk värdeaxel är användbar när positiva värden sträcker sig över flera storleksordningar. Till exempel kan en tjänst ta emot 10, 100, 1 000, 10 000 och 100 000 förfrågningar över fem perioder. På en linjär skala ligger de mindre värdena nära varandra nära noll. En logaritmisk skala gör deras relativa tillväxt lättare att jämföra: lika avstånd representerar lika förhållanden snarare än lika skillnader.

Anropa [set_IsLogarithmic](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_islogarithmic/) med `true` på värdeaxeln och använd [set_LogBase](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_logbase/) för att välja bas. Detta ändrar hur befintliga värden visas; det ändrar inte data eller lägger till en logaritmisk trendlinje. En trendlinje representerar ett anpassat förhållande i data och är en separat funktion.

### **Välj värdeaxeln och basen**

För ett linje‑ eller stapeldiagram är värdeaxeln [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). För ett horisontellt stapeldiagram är den [get_HorizontalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_horizontalaxis/). Spridnings‑ och bubbeldiagram har två värdeaxlar, så välj den horisontella axeln för X‑värden, den vertikala för Y‑värden, eller båda. Tillämpa inte logaritmisk skalning på en kategori‑axel.

Standard‑logaritmbasen är `10`. För PPTX‑diagram kan du använda en bas mellan `2` och `1000`, inklusive; bråktalsbaser såsom `2.5` stöds också. Med bas `10` är på varandra följande potenser som 10, 100, 1 000 och 10 000 lika avståndsliga.

### **Jämför linjär och logaritmisk skalning**

Följande självständiga exempel skapar ett linjediagram med de fem förfrågningsantalena på första bilden, klonar sedan den bilden och aktiverar en bas‑10 logaritmisk värdeaxel på den andra. Båda bilderna behåller samma data.

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

// Behåll den första bilden linjär och ändra endast kopians värdeaxelskala.
auto logarithmicSlide = presentation->get_Slides()->AddClone(slide);
auto logarithmicChart = System::ExplicitCast<IChart>(logarithmicSlide->get_Shape(0));
auto valueAxis = logarithmicChart->get_Axes()->get_VerticalAxis();
valueAxis->set_IsLogarithmic(true);
valueAxis->set_LogBase(10);

presentation->Save(u"LogarithmicAxis.pptx", SaveFormat::Pptx);
```

**Linjär skala (bild 1):** Lika vertikala avstånd representerar lika skillnader i förfrågningsantal. Det största värdet dominerar diagrammet, vilket gör de mindre värdena svåra att urskilja.

![Linje‑diagram i PowerPoint som visar fem förfrågningsantal på en linjär värdeaxel](value-axis-linear.png)

**Logaritmisk skala (bild 2):** Lika vertikala avstånd representerar lika förhållanden. Varje period har tio gånger så många förfrågningar som föregående, så punkterna bildar en rak stigande linje på bas‑10‑skalan. Axel‑etiketterna visar fortfarande de ursprungliga förfrågningsantalena.

![Samma fem förfrågningsantal i PowerPoint på en bas‑10 logaritmisk värdeaxel](value-axis-logarithmic.png)

### **Hantera noll‑ och negativa värden**

En logaritmisk skala kan bara visa strikt positiva värden. Kontrollera data innan du aktiverar den. Om noll‑ eller negativa värden är meningsfulla, håll en linjär skala eller visa dem separat. Om det är lämpligt att exkludera dessa värden för analysen, förklara uteslutningen. Ersätt dem inte tyst med små positiva tal, eftersom detta förändrar data­meningen. Eventuella manuellt konfigurerade minimum‑ eller maximum‑värden för en logaritmisk axel måste också vara positiva.

## **FAQ**

**Hur anger jag värdet där en axel korsar den andra (axelkorsning)?**

Använd [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) för att välja korsningsbeteende. För att specificera ett numeriskt korsningsvärde, använd [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/). Dessa inställningar låter dig flytta axelkorsningen till en lämplig referenslinje.

**Hur kan jag placera tick‑etiketter i förhållande till axeln?**

Använd [set_TickLabelPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_ticklabelposition/) med ett värde från [TickLabelPositionType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo` eller `None`. För att styra själva tick‑markeringarna, använd [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) eller [set_MinorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_minortickmark/); dessa är separata från etikettplaceringen.