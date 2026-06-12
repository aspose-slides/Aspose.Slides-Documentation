---
title: "Grafiekassen aanpassen in presentaties met С++"
linktitle: "Grafiekas"
type: docs
url: /nl/cpp/chart-axis/
keywords:
- grafiekas
- verticale as
- horizontale as
- as aanpassen
- as manipuleren
- as beheren
- as eigenschappen
- maximale waarde
- minimale waarde
- aslijn
- datumnotatie
- as titel
- aspositie
- PowerPoint
- presentatie
- С++
- Aspose.Slides
description: "Ontdek hoe u Aspose.Slides voor С++ kunt gebruiken om grafiekassen aan te passen in PowerPoint‑presentaties voor rapporten en visualisaties."
---
## **Overzicht**

Dit artikel legt uit hoe u de assen van een diagram in Aspose.Slides kunt aanpassen. Het laat zien hoe u de werkelijke aswaarden kunt ophalen, gegevens tussen assen kunt verwisselen, de verticale of horizontale as voor lijndiagrammen kunt verbergen, het type categoriasse kunt wijzigen, het datumformaat voor categoriasse‑waarden kunt instellen, een as‑titel kunt roteren, de aspositie kunt instellen en een eenheidsetiket op de waardenas kunt weergeven.

## **Haal de maximale waarden op de verticale as**

Aspose.Slides voor C++ stelt u in staat om de minimum- en maximumwaarden op een verticale as te verkrijgen. Doorloop de volgende stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation) klasse.
2. Open de eerste dia.
3. Voeg een diagram toe met standaardgegevens.
4. Haal de werkelijke maximumwaarde op de as op.
5. Haal de werkelijke minimumwaarde op de as op.
6. Haal de werkelijke hoofdeenheid van de as op.
7. Haal de werkelijke subeenheid van de as op.
8. Haal de werkelijke schaal van de hoofdeenheid van de as op.
9. Haal de werkelijke schaal van de subeenheid van de as op.

Deze voorbeeldcode—een implementatie van de bovenstaande stappen—laat zien hoe u de benodigde waarden in C++ kunt verkrijgen:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = System::ExplicitCast<Chart>(shapes->AddChart(ChartType::Area, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

auto axes = chart->get_Axes();

double maxValue = axes->get_VerticalAxis()->get_ActualMaxValue();
double minValue = axes->get_VerticalAxis()->get_ActualMinValue();

double majorUnit = axes->get_HorizontalAxis()->get_ActualMajorUnit();
double minorUnit = axes->get_HorizontalAxis()->get_ActualMinorUnit();

// Slaat de presentatie op
pres->Save(u"ErrorBars_out.pptx", SaveFormat::Pptx);
```

## **Gegevens tussen assen verwisselen**

Aspose.Slides stelt u in staat om snel de gegevens tussen assen te verwisselen—de gegevens die op de verticale as (y-as) staan, worden verplaatst naar de horizontale as (x-as) en omgekeerd.

Deze C++-code laat zien hoe u de gegevensverwisseling tussen assen op een diagram kunt uitvoeren:

``` cpp
// Maakt lege presentatie
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// Wisselt rijen en kolommen
chart->get_ChartData()->SwitchRowColumn();

// Slaat presentatie op
pres->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **Verticale as uitschakelen voor lijndiagrammen**

Deze C++-code laat zien hoe u de verticale as voor een lijndiagram kunt verbergen:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Horizontale as uitschakelen voor lijndiagrammen**

Deze code laat zien hoe u de horizontale as voor een lijndiagram kunt verbergen:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Een categoriasse wijzigen**

Met de **set_CategoryAxisType()**‑methode kunt u uw gewenste categoriasstype (**date** of **text**) opgeven. Deze C++‑code toont de bewerking: 

``` cpp
auto presentation = System::MakeObject<Presentation>(u"ExistingChart.pptx");
auto chart = System::AsCast<IChart>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();

horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsAutomaticMajorUnit(false);
horizontalAxis->set_MajorUnit(1);
horizontalAxis->set_MajorUnitScale(TimeUnitType::Months);

presentation->Save(u"ChangeChartCategoryAxis_out.pptx", SaveFormat::Pptx);
```

## **Datumformaat instellen voor categoriasse‑waarden**

Aspose.Slides voor C++ stelt u in staat om het datumformaat voor een categoriasse‑waarde in te stellen. De bewerking wordt gedemonstreerd in deze C++‑code:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto chart = pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::Area, 50.0f, 50.0f, 450.0f, 300.0f);

auto wb = chart->get_ChartData()->get_ChartDataWorkbook();

wb->Clear(0);

chart->get_ChartData()->get_Series()->Clear();
auto areaCategories = chart->get_ChartData()->get_Categories();
areaCategories->Clear();
areaCategories->Add(wb->GetCell(0, u"A2", ObjectExt::Box<double>(DateTime(2015, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A3", ObjectExt::Box<double>(DateTime(2016, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A4", ObjectExt::Box<double>(DateTime(2017, 1, 1).ToOADate())));
areaCategories->Add(wb->GetCell(0, u"A5", ObjectExt::Box<double>(DateTime(2018, 1, 1).ToOADate())));

auto series = chart->get_ChartData()->get_Series()->Add(ChartType::Line);
auto dataPoints = series->get_DataPoints();
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B2", ObjectExt::Box<int32_t>(1)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B3", ObjectExt::Box<int32_t>(2)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B4", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForLineSeries(wb->GetCell(0, u"B5", ObjectExt::Box<int32_t>(4)));

auto horizontalAxis = chart->get_Axes()->get_HorizontalAxis();
horizontalAxis->set_CategoryAxisType(CategoryAxisType::Date);
horizontalAxis->set_IsNumberFormatLinkedToSource(false);
horizontalAxis->set_NumberFormat(u"yyyy");

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **Draaihoek instellen voor een as‑titel**

Aspose.Slides voor C++ stelt u in staat om de draaihoek voor een diagramas‑titel in te stellen. Deze C++‑code demonstreert de bewerking:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **Aspositie instellen op een categoriasse of waardenas**

Aspose.Slides voor C++ stelt u in staat om de aspositie in een categoriasse of waardenas in te stellen. Deze C++‑code laat zien hoe u de taak kunt uitvoeren:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```

## **Eenheidsetiket weergeven op een diagram‑waardenas inschakelen**

Aspose.Slides voor C++ stelt u in staat om een diagram zo te configureren dat er een eenheidsetiket op de waardenas wordt weergegeven. Deze C++‑code demonstreert de bewerking:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Hoe stel ik de waarde in waarop de ene as de andere kruist (as‑kruising)?**

Assen bieden een [crossing setting](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/axis/set_crosstype/): u kunt kiezen om te kruisen op nul, op de maximale categorie/waarde, of op een specifieke numerieke waarde. Dit is handig om de X-as omhoog of omlaag te verplaatsen of om een basislijn te accentueren.

**Hoe kan ik tick‑labels ten opzichte van de as positioneren (naast, buiten, binnen)?**

Stel de [label position](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/axis/set_majortickmark/) in op "cross", "outside" of "inside". Dit beïnvloedt de leesbaarheid en helpt ruimte te besparen, vooral bij kleine diagrammen.