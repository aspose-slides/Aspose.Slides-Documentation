---
title: Grafiekassen aanpassen in presentaties met C++
linktitle: Grafiekas
type: docs
url: /nl/cpp/chart-axis/
keywords:
- grafiekas
- verticale as
- horizontale as
- as aanpassen
- as manipuleren
- as beheren
- as-eigenschappen
- maximale waarde
- minimale waarde
- aslijn
- datumnotatie
- as-titel
- aspositie
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Ontdek hoe u Aspose.Slides voor C++ kunt gebruiken om grafiekassen aan te passen in PowerPoint-presentaties voor rapporten en visualisaties."
---
## **Overzicht**

Dit artikel legt uit hoe u diagramassen kunt aanpassen met Aspose.Slides voor C++. Het behandelt berekende aswaarden, het verwisselen van rijen en kolommen in diagrammen, de zichtbaarheid van assen, intervallen voor categorie‑labels en tick‑markeringen, datumcategorieën en -opmaak, titelrotatie, aspositionering, weergave‑eenheden en logaritmische schaal.

## **De maximale waarden op de verticale as op diagrammen ophalen**

Maak een [Presentatie](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) aan en voeg een gebiedsdiagram toe met standaardgegevens. Roep [ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/validatechartlayout/) aan voordat u berekende aswaarden uitleest, zodat de diagramlay-out up‑to‑date is.

Lees [get_ActualMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmaxvalue/) en [get_ActualMinValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminvalue/) voor de aslimieten, en [get_ActualMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunit/) en [get_ActualMinorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunit/) voor de tick‑intervallen. [get_ActualMajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunitscale/) en [get_ActualMinorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunitscale/) geven tijdseenheid‑schaalwaarden, die relevant zijn voor datumassen. Het voorbeeld slaat deze waarden op in lokale variabelen en slaat het diagram op.

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

## **Gegevens tussen assen verwisselen**

Gebruik [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) om de rollen van series en categorieën in diagramgegevens om te wisselen. Elke vorige categorie wordt een serie, en elke vorige serie wordt een categorie. Dit verandert de groepering van de gegevens; het verwisselt niet de horizontale en verticale assen. Het voorbeeld gebruikt [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setrange/) om de standaardgegevens te koppelen aan `Sheet1!A1:D5`, inclusief de koprij en de categoriekolom, vóór het verwisselen van rijen en kolommen. Het slaat een diagram op met vier series en drie categorieën.

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

## **Volgorde van weergave van een as omkeren**

Gebruik [set_IsPlotOrderReversed](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isplotorderreversed/) om een categorie‑ of waardenas om te keren. Een horizontale staafdiagram kan bijvoorbeeld projectfasen van boven naar beneden weergeven in dezelfde volgorde als het werkblad: Planning, Development, Testing. Het omkeren van een as verandert de weergaverichting; het sorteert of herschikt de werkboekgegevens niet. Ter vergelijking verwisselt [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) de rollen van series en categorieën.

Het volgende voorbeeld maakt een horizontale staafdiagram met drie fasen en één serie. Het slaat een presentatie op met drie dia’s: normale volgorde, omgekeerde categorieën en omgekeerde waarden. Elke kopie gebruikt dezelfde gegevensset, en per kopie wordt slechts één as omgekeerd.

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

// Dia 2: toon de eerste categorie bovenaan.
auto categorySlide = presentation->get_Slides()->AddClone(slide);
auto categoryChart = System::ExplicitCast<IChart>(categorySlide->get_Shape(0));
categoryChart->get_Axes()->get_VerticalAxis()->set_IsPlotOrderReversed(true);
// Houd de horizontale waardenas onderaan.
categoryChart->get_Axes()->get_VerticalAxis()->set_CrossType(CrossesType::Maximum);

// Dia 3: keer alleen de horizontale numerieke schaal om.
auto valueSlide = presentation->get_Slides()->AddClone(slide);
auto valueChart = System::ExplicitCast<IChart>(valueSlide->get_Shape(0));
valueChart->get_Axes()->get_HorizontalAxis()->set_IsPlotOrderReversed(true);

presentation->Save(u"ReversedAxes.pptx", SaveFormat::Pptx);
```

Het omkeren van een as kan tevens de loodrechte as naar de tegenoverliggende kant van het diagram verplaatsen. [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) bepaalt waar de andere as de geconfigureerde as kruist. In dia 2 wordt `Maximum` ingesteld op de omgekeerde categorias om de horizontale waardenas onderaan te houden. Voor een specifiek kruispunt gebruikt u [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/). Controleer de kruisinginstellingen bij het wijzigen van de richting, vooral als het diagram al een aangepast kruispunt heeft. Roep `set_IsPlotOrderReversed` met `false` aan om de normale weergaverichting te herstellen; kruisinginstellingen zijn onafhankelijk.

| Normale volgorde (dia 1) | Omgekeerde categorieën (dia 2) | Omgekeerde waarden (dia 3) |
| --- | --- | --- |
| ![Horizontale staafdiagram met normale volgorde van categorie- en waardenas](axis-order-normal.png) | ![Horizontale staafdiagram met categorieën weergegeven van boven naar beneden](axis-order-categories-reversed.png) | ![Horizontale staafdiagram met een omgekeerde waardenas en nul rechts](axis-order-values-reversed.png) |
| Categorieën lopen van onder naar boven; waarden nemen toe van links naar rechts. | Planning, Development en Testing lopen van boven naar beneden. Waarden en de rijvolgorde in het werkboek blijven ongewijzigd. | Categorieën behouden hun normale volgorde; waarden nemen toe van rechts naar links. De categorias kruist op nul rechts. |

## **Verticale as uitschakelen voor lijndiagrammen**

Gebruik [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) met `false` op de verticale as om deze te verbergen. Het voorbeeld maakt een lijndiagram met standaardgegevens en slaat het op met de verticale as verborgen.

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

## **Horizontale as uitschakelen voor lijndiagrammen**

Gebruik [set_IsVisible](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isvisible/) met `false` op de horizontale as om deze te verbergen. Het voorbeeld maakt een lijndiagram met standaardgegevens en slaat het op met de horizontale as verborgen.

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

## **Diagramrasterlijnen tonen of verbergen**

Gebruik [get_ShowMajorGridLines](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_showmajorgridlines/) en [get_ShowMinorGridLines](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_showminorgridlines/) om te controleren welke rasterlijnen een as weergeeft. Beide eigenschappen zijn alleen‑lees. Om kleine rasterlijnen te tonen, gebruikt u [get_MinorGridLinesFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_minorgridlinesformat/) en stelt u de lijnvulling in op een effen, zichtbare kleur. Om ze te verbergen, stelt u de vulling in op [FillType::NoFill](https://reference.aspose.com/slides/cpp/aspose.slides/filltype/). Gebruik [get_MajorGridLinesFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_majorgridlinesformat/) om de grote rasterlijnen op dezelfde manier aan te passen. Het wijzigen van de rasterlijnvulling behoudt de zichtbaar­heid van de as en de tick‑marks.

De verticale as van dit gegroepeerde kolomdiagram toont aanvankelijk alleen grote rasterlijnen. Het voorbeeld toont kleine rasterlijnen in oranje, verbergt ze daarna weer en slaat de presentatie op.

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

| Kleine rasterlijnen ingeschakeld | Kleine rasterlijnen verborgen |
| --- | --- |
| ![Oranje kleine rasterlijnen tussen de grote rasterlijnen op de verticale as](minor-gridlines-enabled.png) | ![Hetzelfde kolomdiagram met alleen grote rasterlijnen zichtbaar](minor-gridlines-hidden.png) |

## **Categorieas wijzigen**

Gebruik [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) om een datum‑ of tekst‑categorieas te kiezen. Dit voorbeeld vereist `ExistingChart.pptx`, met een diagram als het eerste object op de eerste dia en categoriecellen die numerieke Excel‑datumnummers bevatten. Het verandert de horizontale as in een datumas. Het aanroepen van [set_IsAutomaticMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isautomaticmajorunit/) met `false`, [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunit/) met `1` en [set_MajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunitscale/) met maanden plaatst de grote tick‑marks op één‑maandintervallen.

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

### **Bepalen van het type categorieas op basis van gegevens**

Roep [SetCategoryAxisTypeAutomatically](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/setcategoryaxistypeautomatically/) aan nadat de categorieën zijn gevuld, en roep daarna [get_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/get_categoryaxistype/) aan om de selectie te inspecteren. Dit is nuttig wanneer hetzelfde diagram ofwel tekst‑labels ofwel numerieke datumwaarden ontvangt. De methode bepaalt het type op het moment van aanroep; hij activeert geen persistente modus die latere gegevenswijzigingen opnieuw evalueert. Roep hem opnieuw aan nadat de categorieën zijn vervangen.

Het volgende voorbeeld maakt een diagram met tekstcategorieën en drukt `Text` af. Vervolgens vervangt het de categoriecellen door datums en roept de methode opnieuw aan, die `Date` afdrukt. Datums worden opgeslagen als numerieke OLE‑Automation‑waarden die worden geretourneerd door [System::DateTime::ToOADate](https://reference.aspose.com/slides/cpp/system/datetime/tooadate/), in plaats van datums als tekenreeks. [set_CustomNumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatacell/set_customnumberformat/) bepaalt hoe die waarden worden weergegeven; hij converteert geen tekst naar numerieke datums. Voor meer informatie over categoriecellen, zie [Chart Workbook](/slides/nl/cpp/chart-workbook/).

Gebruik automatische bepaling wanneer de invoer bekend is als tekstcategorieën of numerieke datums, zoals in dit voorbeeld. Voor gewone numerieke labels, gemengde categorieën of lege gegevens, roep expliciet [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_categoryaxistype/) aan om overeen te komen met de beoogde betekenis. Numerieke waarden alleen stellen niet vast dat de categorieën datumsoorten vertegenwoordigen.

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
System::Console::WriteLine(System::Enum<CategoryAxisType>::GetName(axis->get_CategoryAxisType())); // Tekst

auto dates = std::array<System::DateTime, 3>{System::DateTime(2026, 1, 1), System::DateTime(2026, 1, 2), System::DateTime(2026, 2, 1)};

for (auto i = 0; i < dates.size(); i++)
{
    auto categoryCell = workbook->GetCell(0, i + 1, 0);
    categoryCell->set_Value(System::ObjectExt::Box(dates[i].ToOADate()));
    categoryCell->set_CustomNumberFormat(u"yyyy-mm-dd");
}

axis->SetCategoryAxisTypeAutomatically();
System::Console::WriteLine(System::Enum<CategoryAxisType>::GetName(axis->get_CategoryAxisType())); // Datum

presentation->Save(u"AutomaticCategoryAxis.pptx", SaveFormat::Pptx);
```

## **Interval voor categorieas‑labels beheren**

Wanneer een diagram veel categorieën heeft, kunt u het aantal zichtbare as‑labels verminderen zonder categorieën of gegevenspunten te verwijderen. Gebruik [set_IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticticklabelspacing/) met `false`, en vervolgens [set_TickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_ticklabelspacing/) met het gewenste categorie‑interval. Voor tekstcategorieën in hun normale volgorde begint de telling bij de eerste categorie:

| Interval | Labels die in het voorbeeld worden weergegeven |
| --- | --- |
| `1` | Category 1, Category 2, Category 3, … Category 24 |
| `2` | Category 1, Category 3, Category 5, … Category 23 |
| `3` | Category 1, Category 4, Category 7, … Category 22 |

Een interval van `3` toont elk derde label, waarbij twee labels verborgen blijven tussen de weergegeven labels. Het verwijdert de overeenkomstige kolommen niet. Automatische tussenruimte kiest een interval op basis van de beschikbare ruimte; het toont niet noodzakelijk elk label.

Tick‑marks hebben afzonderlijke instellingen. Gebruik [set_IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomatictickmarksspacing/) met `false` en gebruik [set_TickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_tickmarksspacing/) om hun interval in te stellen. Bijvoorbeeld, `1` houdt een tick‑mark op elk categorie‑interval terwijl labels alleen elk derde categorie verschijnen. Gebruik [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majortickmark/) met een zichtbaar stijltje zodat u het resultaat kunt zien. Het terugzetten van een van de automatische‑spacing‑eigenschappen naar `true` laat het diagram dat interval opnieuw kiezen.

Het volgende zelfstandige voorbeeld maakt 24 categorieën en één serie, en slaat drie dia’s op in `CategoryAxisIntervals.pptx`: automatische tussenruimte, handmatige label‑tussenruimte met onafhankelijke tick‑marks, en herstel van automatische tussenruimte. De twee kopieën behouden de oorspronkelijke diagramgegevens. Er is geen invoer‑presentatie vereist. Horizontale label‑tekst maakt het verschil in dichtheid gemakkelijk zichtbaar.

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

// Dia 2: toon elk derde label, maar behoud een tikmark voor elke categorie.
auto manualSlide = presentation->get_Slides()->AddClone(slide);
auto manualChart = System::ExplicitCast<IChart>(manualSlide->get_Shape(0));
auto manualAxis = manualChart->get_Axes()->get_HorizontalAxis();
manualAxis->set_IsAutomaticTickLabelSpacing(false);
manualAxis->set_TickLabelSpacing(3);
manualAxis->set_IsAutomaticTickMarksSpacing(false);
manualAxis->set_TickMarksSpacing(1);

// Dia 3: laat het diagram opnieuw beide intervallen kiezen.
auto restoredSlide = presentation->get_Slides()->AddClone(manualSlide);
auto restoredChart = System::ExplicitCast<IChart>(restoredSlide->get_Shape(0));
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickLabelSpacing(true);
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickMarksSpacing(true);

presentation->Save(u"CategoryAxisIntervals.pptx", SaveFormat::Pptx);
```

**Automatische tussenruimte (dia 1):** In deze weergave wordt elke tweede categorielabel getoond en wordt ze op twee regels afgebroken. Het automatische resultaat kan variëren afhankelijk van diagramgrootte, lettertypen en de renderer.

![Automatic category label spacing with all 24 columns visible](category-axis-automatic.png)

**Handmatige tussenruimte (dia 2):** Elke derde label wordt op één regel getoond, terwijl tick‑marks blijven staan op elk categorie‑interval. Alle 24 kolommen, inclusief die zonder label, blijven zichtbaar met dezelfde waarden. Dia 3 herstelt de automatische weergave die hierboven is getoond.

![Manual category label interval of three with all 24 columns visible](category-axis-manual.png)

### **Kies de juiste as en interval**

Gebruik dit categorie‑aantal‑interval voor een tekst‑categorieas, zoals de categorieas van een kolom‑, lijn‑, gebieds‑ of staafdiagram. In een kolomdiagram is dit de horizontale as. In een horizontaal staafdiagram is de categorieas verticaal, dus pas deze instellingen toe op [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). De afstand tussen tick‑marks geldt ook voor een serie‑as in diagrammen die er één hebben.

Gebruik geen categorie‑label‑tussenruimte om de numerieke schaal van een waardenas in te stellen. Op een waardenas specificeert [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majorunit/) een verschil in waarden: bijvoorbeeld, een grote eenheid van `10` levert ticks op 0, 10, 20, … wanneer de as bij nul start. Een categorie‑label‑interval van `3` telt daarentegen categorie‑posities, ongeacht hun datawaarden. Spreidings‑ en bubbeldiagrammen gebruiken waardassen in plaats van een tekst‑categorieas. Voor een datumas gebruikt u tijd‑gebaseerde grote eenheden en schalen zoals beschreven in [Categorieas wijzigen](#categorieas-wijzigen).

## **Datumopmaak instellen voor categorieas‑waarden**

Het voorbeeld vervangt de standaard diagramgegevens door vier jaarlijkse waarden. Datums worden opgeslagen als OLE‑Automation‑serienummers in het eerste werkblad (index `0`). Gebruik [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) om een datumas te selecteren, schakel bron‑gekoppelde opmaak uit met [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isnumberformatlinkedtosource/), en wijs `yyyy` toe met [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_numberformat/) zodat de categorielabels viercijferige jaartallen tonen, onafhankelijk van de celopmaak.

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

## **Rotatiehoek instellen voor de titel van een diagramas**

Schakel de titel van de verticale as in met [set_HasTitle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_hastitle/), geef de titeltekst op, en gebruik [set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextblockformat/set_rotationangle/) om de titel te roteren. De hoek wordt gemeten in graden; dit voorbeeld slaat een kolomdiagram op met de titel van de waardenas geroteerd met 90 graden.

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

## **Aspositie instellen op een categorie‑ of waardenas**

Gebruik [set_AxisBetweenCategories](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_axisbetweencategories/) om te bepalen of de waardenas de categorieas tussen categorieën of op categorietick‑marks kruist. Deze eigenschap is van toepassing op categorieassen. Het voorbeeld stelt dit in op `true` op de horizontale categorieas van een kolomdiagram en slaat het resultaat op.

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

## **Weergave‑eenheid instellen op een waardenas van een diagram**

Gebruik [set_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_displayunit/) om de labels op een waardenas te schalen zonder de onderliggende gegevens te wijzigen. Met [DisplayUnitType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/displayunittype/) ingesteld op `Millions` wordt een waarde van 60 000 000 weergegeven als 60. Het voorbeeld maakt een kolomdiagram en past de miljoenen‑weergave‑eenheid toe op de verticale as.

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

## **Logaritmische waardenas configureren**

Een logaritmische waardenas is nuttig wanneer positieve waarden zich over meerdere grootheidsordes uitstrekken. Bijvoorbeeld, een service kan 10, 100, 1 000, 10 000 en 100 000 verzoeken ontvangen over vijf perioden. Op een lineaire schaal liggen de kleinere waarden dicht bij nul bijeen. Een logaritmische schaal maakt hun relatieve groei gemakkelijker te vergelijken: gelijke afstanden vertegenwoordigen gelijke verhoudingen in plaats van gelijke verschillen.

Roep [set_IsLogarithmic](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_islogarithmic/) met `true` aan op de waardenas en gebruik [set_LogBase](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_logbase/) om de basis te kiezen. Dit verandert hoe de bestaande waarden worden weergegeven; het wijzigt de gegevens niet en voegt geen logaritmische trendlijn toe. Een trendlijn vertegenwoordigt een aangepaste relatie in de gegevens en is een aparte functie.

### **Kies de waardenas en basis**

Voor een lijn‑ of kolomdiagram is de waardenas [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). Voor een horizontaal staafdiagram is het [get_HorizontalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_horizontalaxis/). Spreidings‑ en bubbeldiagrammen hebben twee waardassen, dus kies de horizontale as voor X‑waarden, de verticale as voor Y‑waarden, of beide. Pas geen logaritmische schaal toe op een categorieas.

De standaard logaritmische basis is `10`. Voor PPTX‑diagrammen kunt u een basis kiezen van `2` tot en met `1000`, inclusief; breukdelen zoals `2.5` worden ook ondersteund. Met basis `10` zijn opeenvolgende machten zoals 10, 100, 1 000 en 10 000 gelijkmatig verdeeld.

### **Lineaire en logaritmische schaal vergelijken**

Het volgende zelfstandige voorbeeld maakt een lijndiagram met de vijf verzoektelling‑waarden op de eerste dia, klont vervolgens die dia en schakelt een logaritmische waardenas met basis 10 in op de tweede. Beide dia’s behouden dezelfde gegevens.

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

// Behoud de eerste dia lineair en wijzig alleen de schaal van de waardenas van de kopie.
auto logarithmicSlide = presentation->get_Slides()->AddClone(slide);
auto logarithmicChart = System::ExplicitCast<IChart>(logarithmicSlide->get_Shape(0));
auto valueAxis = logarithmicChart->get_Axes()->get_VerticalAxis();
valueAxis->set_IsLogarithmic(true);
valueAxis->set_LogBase(10);

presentation->Save(u"LogarithmicAxis.pptx", SaveFormat::Pptx);
```

**Lineaire schaal (dia 1):** Gelijke verticale afstanden vertegenwoordigen gelijke verschillen in verzoektelling. De grootste waarde domineert het diagram, waardoor de kleinere waarden moeilijk te onderscheiden zijn.

![Line chart in PowerPoint showing five request counts on a linear value axis](value-axis-linear.png)

**Logaritmische schaal (dia 2):** Gelijke verticale afstanden vertegenwoordigen gelijke verhoudingen. Elke periode heeft tien keer zoveel verzoeken als de vorige, waardoor de punten een rechte stijgende lijn vormen op de basis‑10‑schaal. De as‑labels tonen nog steeds de oorspronkelijke verzoektelling.

![The same five request counts in PowerPoint on a base-10 logarithmic value axis](value-axis-logarithmic.png)

### **Omgaan met nul‑ en negatieve waarden**

Een logaritmische schaal kan alleen strikt positieve waarden weergeven. Controleer de gegevens voordat u de schaal inschakelt. Als nul of negatieve waarden betekenisvol zijn, behoud dan een lineaire schaal of toon ze afzonderlijk. Als het weglaten van die waarden passend is voor de analyse, leg dan de reden uit. Vervang ze niet stilletjes door kleine positieve getallen, want dat verandert de betekenis van de gegevens. Elke handmatig geconfigureerde minimum‑ of maximum‑waarde voor een logaritmische as moet eveneens positief zijn.

## **Veelgestelde vragen**

**Hoe stel ik de waarde in waarop één as de andere kruist (as‑kruising)?**

Gebruik [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) om het kruispuntgedrag te selecteren. Om een numerieke kruispuntwaarde op te geven, gebruikt u [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/). Deze instellingen laten u de as‑kruising verplaatsen naar een geschikte basislijn.

**Hoe kan ik tick‑labels positioneren ten opzichte van de as?**

Gebruik [set_TickLabelPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_ticklabelposition/) met een waarde uit [TickLabelPositionType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo` of `None`. Om de tick‑marks zelf te regelen, gebruikt u [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) of [set_MinorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_minortickmark/); deze staan los van de label‑positionering.