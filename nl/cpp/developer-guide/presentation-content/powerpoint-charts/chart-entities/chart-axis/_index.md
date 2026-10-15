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
- as-positie
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Ontdek hoe u Aspose.Slides voor C++ kunt gebruiken om grafiekassen aan te passen in PowerPoint-presentaties voor rapporten en visualisaties."
---
## **Overzicht**

Dit artikel legt uit hoe u de assen van grafieken kunt aanpassen met Aspose.Slides voor C++. Het behandelt berekende aswaarden, het wisselen van rijen en kolommen in grafieken, aszichtbaarheid, intervallen voor categorie‑labels en tik‑markeringen, datumcategorieën en -opmaak, titelrotatie, aspositionering, weergave‑eenheden en logaritmische schaling.

## **De maximale waarden op de verticale as van grafieken ophalen**

Maak een [Presentatie](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) en voeg een gebiedsgrafiek toe met standaardgegevens. Roep [ValidateChartLayout](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chart/validatechartlayout/) aan voordat u berekende aswaarden leest, zodat de grafieklay-out up‑to‑date is.

Lees [get_ActualMaxValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmaxvalue/) en [get_ActualMinValue](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminvalue/) voor de aslimieten, en [get_ActualMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunit/) en [get_ActualMinorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunit/) voor de tic‑intervallen. [get_ActualMajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualmajorunitscale/) en [get_ActualMinorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/get_actualminorunitscale/) leveren tijdseenheid‑schalen, die relevant zijn voor datumassen. Het voorbeeld slaat deze waarden op in lokale variabelen en slaat de grafiek op.

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

Gebruik [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) om de rollen van reeksen en categorieën in de grafiekgegevens uit te wisselen. Elke voormalige categorie wordt een reeks, en elke voormalige reeks wordt een categorie. Dit verandert hoe de gegevens worden gegroepeerd; het wisselt niet de horizontale en verticale assen uit. Het voorbeeld gebruikt [SetRange](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/setrange/) om de standaardgegevens te binden aan `Sheet1!A1:D5`, inclusief de koprij en categoriekolom, voordat rijen en kolommen worden verwisseld. Het slaat een grafiek op met vier reeksen en drie categorieën.

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

## **Volgorde van plotten van een as omkeren**

Gebruik [set_IsPlotOrderReversed](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isplotorderreversed/) om een categorie‑ of waardenas om te keren. Bijvoorbeeld, een horizontale staafgrafiek kan projectfasen van boven naar beneden weergeven in dezelfde volgorde als het werkblad: Planning, Ontwikkeling, Testen. Het omkeren van een as verandert de plot‑richting; het sorteert of herschikt de werkboekgegevens niet. Ter vergelijking wisselt [SwitchRowColumn](https://reference.aspose.com/slides/cpp/aspose.slides.charts/chartdata/switchrowcolumn/) de rollen van reeksen en categorieën.

Het volgende voorbeeld maakt een horizontale staafgrafiek met drie fasen en één reeks. Het slaat een presentatie op met drie dia's: normale volgorde, omgekeerde categorieën en omgekeerde waarden. Elke kopie gebruikt dezelfde dataset, en er wordt slechts één as omgekeerd in elke kopie.

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
// Behoud de horizontale waardenas onderaan.
categoryChart->get_Axes()->get_VerticalAxis()->set_CrossType(CrossesType::Maximum);

// Dia 3: keer alleen de horizontale numerieke schaal om.
auto valueSlide = presentation->get_Slides()->AddClone(slide);
auto valueChart = System::ExplicitCast<IChart>(valueSlide->get_Shape(0));
valueChart->get_Axes()->get_HorizontalAxis()->set_IsPlotOrderReversed(true);

presentation->Save(u"ReversedAxes.pptx", SaveFormat::Pptx);
```

Het omkeren van een as kan ook de loodrechte as naar de tegenovergestelde kant van de tekening verplaatsen. [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) bepaalt waar de andere as de geconfigureerde as kruist. In dia 2 houdt het instellen op `Maximum` op de omgekeerde categorieas de horizontale waardenas onderaan. Voor een specifiek kruispunt gebruikt u [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/). Controleer de kruisinginstellingen bij het wijzigen van de richting, vooral als de grafiek al een aangepast kruispunt heeft. Roep `set_IsPlotOrderReversed` aan met `false` om de normale plot‑richting te herstellen; kruisinginstellingen zijn onafhankelijk.

| Normale volgorde (dia 1) | Omgekeerde categorieën (dia 2) | Omgekeerde waarden (dia 3) |
| --- | --- | --- |
| ![Horizontale staafgrafiek met normale categorie‑ en waardenas‑volgorde](axis-order-normal.png) | ![Horizontale staafgrafiek met van boven naar beneden weergegeven categorieën](axis-order-categories-reversed.png) | ![Horizontale staafgrafiek met een omgekeerde waardenas en nul aan de rechterkant](axis-order-values-reversed.png) |
| Categorieën lopen van onder naar boven; waarden nemen toe van links naar rechts. | Planning, Ontwikkeling en Testen lopen van boven naar beneden. Waarden en de volgorde van werkboekrijen blijven ongewijzigd. | Categorieën behouden hun normale volgorde; waarden nemen toe van rechts naar links. De categorieas kruist op nul aan de rechterkant. |

## **De verticale as uitschakelen voor lijndiagrammen**

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

## **De horizontale as uitschakelen voor lijndiagrammen**

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

## **Een categorieas wijzigen**

Gebruik [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) om een datum‑ of tekstcategorieas te kiezen. Dit voorbeeld vereist `ExistingChart.pptx`, met een grafiek als eerste vorm op de eerste dia en categoriecellen die numerieke Excel‑datumnummers bevatten. Het wijzigt de horizontale as naar een datumas. Het aanroepen van [set_IsAutomaticMajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isautomaticmajorunit/) met `false`, [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunit/) met `1` en [set_MajorUnitScale](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majorunitscale/) met maanden plaatst de hoofd‑tikmarkeringen op een‑maand‑intervallen.

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

## **Intervallen voor labels van een categorieas beheren**

Wanneer een grafiek veel categorieën bevat, vermindert u het aantal zichtbare aslabels zonder categorieën of gegevenspunten te verwijderen. Gebruik [set_IsAutomaticTickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomaticticklabelspacing/) met `false`, en gebruik vervolgens [set_TickLabelSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_ticklabelspacing/) met het gewenste categorie‑interval. Voor tekstcategorieën in hun normale volgorde begint de telling bij de eerste categorie:

| Interval | Labels die in het voorbeeld worden weergegeven |
| --- | --- |
| `1` | Categorie 1, Categorie 2, Categorie 3, ... Categorie 24 |
| `2` | Categorie 1, Categorie 3, Categorie 5, ... Categorie 23 |
| `3` | Categorie 1, Categorie 4, Categorie 7, ... Categorie 22 |

Een interval van `3` toont elk derde label, waarbij twee labels tussen de weergegeven labels verborgen blijven. Het verwijdert de bijbehorende kolommen niet. Automatische spacing kiest een interval op basis van de beschikbare ruimte; het toont niet per se elk label.

Tic‑markeringen hebben afzonderlijke instellingen. Gebruik [set_IsAutomaticTickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_isautomatictickmarksspacing/) met `false` en gebruik [set_TickMarksSpacing](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_tickmarksspacing/) om hun interval in te stellen. Bijvoorbeeld, `1` behoudt een tic‑markering bij elk categorie‑interval terwijl labels slechts elke derde categorie verschijnen. Gebruik [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majortickmark/) met een zichtbaar stijl zodat u het resultaat kunt zien. Het terugzetten van een van de automatische‑spacing‑eigenschappen naar `true` laat de grafiek dat interval opnieuw kiezen.

Het volgende zelfstandige voorbeeld maakt 24 categorieën en één reeks, en slaat vervolgens drie dia's op in `CategoryAxisIntervals.pptx`: automatische spacing, handmatige label‑spacing met onafhankelijke tic‑markeringen, en herstelde automatische spacing. De twee kopieën behouden de originele grafiekgegevens. Er is geen invoerpresentatie vereist. Horizontale labeltekst maakt het verschil in dichtheid gemakkelijk zichtbaar.

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

// Dia 2: toon elk derde label, maar behoud een tic-markering voor elke categorie.
auto manualSlide = presentation->get_Slides()->AddClone(slide);
auto manualChart = System::ExplicitCast<IChart>(manualSlide->get_Shape(0));
auto manualAxis = manualChart->get_Axes()->get_HorizontalAxis();
manualAxis->set_IsAutomaticTickLabelSpacing(false);
manualAxis->set_TickLabelSpacing(3);
manualAxis->set_IsAutomaticTickMarksSpacing(false);
manualAxis->set_TickMarksSpacing(1);

// Dia 3: laat de grafiek beide intervallen opnieuw kiezen.
auto restoredSlide = presentation->get_Slides()->AddClone(manualSlide);
auto restoredChart = System::ExplicitCast<IChart>(restoredSlide->get_Shape(0));
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickLabelSpacing(true);
restoredChart->get_Axes()->get_HorizontalAxis()->set_IsAutomaticTickMarksSpacing(true);

presentation->Save(u"CategoryAxisIntervals.pptx", SaveFormat::Pptx);
```

**Automatische spacing (dia 1):** In deze weergave wordt elk tweede categorielabel weergegeven en wordt op twee regels afgebroken. Het automatische resultaat kan variëren met grafiekgrootte, lettertypen en de renderer.

![Automatische categorie‑labelspacing met alle 24 kolommen zichtbaar](category-axis-automatic.png)

**Handmatige spacing (dia 2):** Elk derde label wordt op één regel weergegeven, terwijl tic‑markeringen bij elk categorie‑interval blijven. Alle 24 kolommen, inclusief die zonder labels, blijven zichtbaar met dezelfde waarden. Dia 3 herstelt de bovenstaande automatische weergave.

![Handmatig categorie‑labelinterval van drie met alle 24 kolommen zichtbaar](category-axis-manual.png)

### **De juiste as en interval kiezen**

Gebruik dit categorie‑telinterval voor een tekst‑categorieas, zoals de categorieas van een kolom‑, lijn‑, gebieds‑ of staafgrafiek. In een kolomgrafiek is dit de horizontale as. In een horizontale staafgrafiek is de categorieas verticaal, dus pas deze instellingen toe op [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). Tic‑mark‑spacing is ook van toepassing op een reeksenas in grafieken die die hebben.

Gebruik geen categorie‑labelspacing om de numerieke schaal van een waardenas in te stellen. Op een waardenas bepaalt [set_MajorUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxis/set_majorunit/) een verschil in waarden: bijvoorbeeld, een hoofd‑eenheid van `10` produceert tikken op 0, 10, 20, enzovoort wanneer de as bij nul begint. Een categorie‑labelinterval van `3` telt daarentegen categorieposities, ongeacht hun gegevenswaarden. Spreidings‑ en bolgrafieken gebruiken waardenassen in plaats van een tekst‑categorieas. Voor een datumas gebruikt u tijdgebaseerde hoofd‑eenheden en schalen zoals beschreven in [Change a Category Axis](#change-a-category-axis).

## **Het datumnotatieformaat voor categorieaswaarden instellen**

Het voorbeeld vervangt de standaardgrafiekgegevens door vier jaarlijkse waarden. Datums worden opgeslagen als OLE‑Automation‑serienummers in het eerste werkblad (index `0`). Gebruik [set_CategoryAxisType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_categoryaxistype/) om een datumas te selecteren, schakel bron‑gekoppelde opmaak uit met [set_IsNumberFormatLinkedToSource](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_isnumberformatlinkedtosource/), en ken `yyyy` toe met [set_NumberFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_numberformat/) zodat de categorie‑labels viercijferige jaartallen weergeven, onafhankelijk van de celopmaak.

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

## **Een rotatie‑hoek voor een grafiekas‑titel instellen**

Schakel de titel van de verticale as in met [set_HasTitle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_hastitle/), geef titeltekst op, en gebruik [set_RotationAngle](https://reference.aspose.com/slides/cpp/aspose.slides.charts/icharttextblockformat/set_rotationangle/) om de titel te roteren. De hoek wordt gemeten in graden; dit voorbeeld slaat een kolomgrafiek op met de titels van de waardenas gedraaid met 90 graden.

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

## **De positie van de as op een categorie‑ of waardenas instellen**

Gebruik [set_AxisBetweenCategories](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_axisbetweencategories/) om te bepalen of de waardenas de categorieas tussen categorieën of op categorie‑tikmarkeringen kruist. Deze eigenschap geldt voor categorieassen. Het voorbeeld stelt dit in op `true` op de horizontale categorieas van een kolomgrafiek en slaat het resultaat op.

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

## **De weergave‑eenheid op een grafiekwaardenas instellen**

Gebruik [set_DisplayUnit](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_displayunit/) om de labels op een waardenas te schalen zonder de onderliggende gegevens te wijzigen. Met [DisplayUnitType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/displayunittype/) ingesteld op `Millions` wordt een waarde van 60.000.000 weergegeven als 60. Het voorbeeld maakt een kolomgrafiek en past de miljoenen‑weergave‑eenheid toe op de verticale as.

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

## **Een logaritmische waardenas configureren**

Een logaritmische waardenas is nuttig wanneer positieve waarden zich over meerdere groottenordes uitstrekken. Bijvoorbeeld, een dienst kan 10, 100, 1.000, 10.000 en 100.000 aanvragen ontvangen over vijf periodes. Op een lineaire schaal verschijnen de kleinere waarden dicht bij nul bij elkaar. Een logaritmische schaal maakt hun relatieve groei makkelijker te vergelijken: gelijke afstanden staan voor gelijke verhoudingen in plaats van gelijke verschillen.

Roep [set_IsLogarithmic](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_islogarithmic/) aan met `true` op de waardenas en gebruik [set_LogBase](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_logbase/) om de basis te kiezen. Dit verandert hoe de bestaande waarden worden weergegeven; het wijzigt de gegevens niet of voegt een logaritmische trendlijn toe. Een trendlijn geeft een aangepaste relatie in de gegevens weer en is een aparte functie.

### **De waardenas en basis kiezen**

Voor een lijn‑ of kolomgrafiek is de waardenas [get_VerticalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_verticalaxis/). Voor een horizontale staafgrafiek is dit [get_HorizontalAxis](https://reference.aspose.com/slides/cpp/aspose.slides.charts/iaxesmanager/get_horizontalaxis/). Spreidings‑ en bolgrafieken hebben twee waardenassen, dus kies de horizontale as voor X‑waarden, de verticale as voor Y‑waarden, of beide. Pas geen logaritmische schaal toe op een categorieas.

De standaard logaritmische basis is `10`. Voor PPTX‑grafieken gebruikt u een basis van `2` tot en met `1000`, inclusief; fractionele bases zoals `2.5` worden ook ondersteund. Met basis `10` zijn opeenvolgende machten zoals 10, 100, 1.000 en 10.000 gelijkmatig gespreid.

### **Lineaire en logaritmische schaal vergelijken**

Het volgende zelfstandige voorbeeld maakt een lijndiagram met de vijf aanvraag‑telwaarden op de eerste dia, klont vervolgens die dia en schakelt op de tweede een logaritmische waardenas met basis‑10 in. Beide dia's behouden dezelfde gegevens.

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

// Houd de eerste dia lineair en wijzig alleen de schaal van de waardenas van de kopie.
auto logarithmicSlide = presentation->get_Slides()->AddClone(slide);
auto logarithmicChart = System::ExplicitCast<IChart>(logarithmicSlide->get_Shape(0));
auto valueAxis = logarithmicChart->get_Axes()->get_VerticalAxis();
valueAxis->set_IsLogarithmic(true);
valueAxis->set_LogBase(10);

presentation->Save(u"LogarithmicAxis.pptx", SaveFormat::Pptx);
```

**Lineaire schaal (dia 1):** Gelijke verticale afstanden staan voor gelijke verschillen in het aantal aanvragen. De grootste waarde domineert de grafiek, waardoor de kleinere waarden moeilijk te onderscheiden zijn.

![Lijndiagram in PowerPoint met vijf aanvraag‑telwaarden op een lineaire waardenas](value-axis-linear.png)

**Logaritmische schaal (dia 2):** Gelijke verticale afstanden staan voor gelijke verhoudingen. Elke periode heeft tien keer zoveel aanvragen als de vorige, waardoor de punten een rechte stijgende lijn vormen op de basis‑10 schaal. De aslabels tonen nog steeds de oorspronkelijke aanvraag‑telwaarden.

![Dezelfde vijf aanvraag‑telwaarden in PowerPoint op een logaritmische waardenas met basis‑10](value-axis-logarithmic.png)

### **Nul‑ en negatieve waarden behandelen**

Een logaritmische schaal kan alleen strikt positieve waarden weergeven. Controleer de gegevens voordat u deze inschakelt. Als nul‑ of negatieve waarden betekenisvol zijn, behoud dan een lineaire schaal of toon ze afzonderlijk. Als het weglaten van die waarden geschikt is voor de analyse, licht dan de omissie toe. Vervang ze niet stilletjes door kleine positieve getallen, want dat verandert de betekenis van de gegevens. Elke handmatig geconfigureerde minimum‑ of maximumwaarde voor een logaritmische as moet ook positief zijn.

## **FAQ**

**Hoe stel ik de waarde in waarop één as de andere kruist (as‑kruising)?**

Gebruik [set_CrossType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crosstype/) om het kruisk gedrag te selecteren. Om een numerieke kruiswaarde op te geven, gebruik [set_CrossAt](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_crossat/). Deze instellingen laten u de askruising verplaatsen naar een geschikte basislijn.

**Hoe kan ik tic‑labels positioneren ten opzichte van de as?**

Gebruik [set_TickLabelPosition](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_ticklabelposition/) met een waarde uit [TickLabelPositionType](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ticklabelpositiontype/): `Low`, `High`, `NextTo` of `None`. Om de tic‑markeringen zelf te regelen, gebruik [set_MajorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_majortickmark/) of [set_MinorTickMark](https://reference.aspose.com/slides/cpp/aspose.slides.charts/axis/set_minortickmark/); deze zijn los van de labelpositionering.