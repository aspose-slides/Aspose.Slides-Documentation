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
- as eigenschappen
- maximale waarde
- minimale waarde
- aslijn
- datumformaat
- as titel
- aspositie
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Ontdek hoe u Aspose.Slides voor C++ kunt gebruiken om grafiekassen in PowerPoint‑presentaties aan te passen voor rapporten en visualisaties."
---
## **Overzicht**

Dit artikel legt uit hoe je grafiekassen kunt aanpassen in Aspose.Slides. Het laat zien hoe je de werkelijke aswaarden kunt ophalen, gegevens tussen assen kunt verwisselen, de verticale of horizontale as voor lijndiagrammen kunt verbergen, het type categorie‑as kunt wijzigen, het datumformaat voor categorie‑aswaarden kunt instellen, een as‑titel kunt roteren, de aspositie kunt instellen en een eenheidsetiket op de waardenas kunt weergeven.

## **De maximale waarden op de verticale as ophalen**
Aspose.Slides for C++ maakt het mogelijk om de minimale en maximale waarden op een verticale as te verkrijgen. Ga deze stappen door:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.presentation) klasse.
1. Open de eerste dia.
1. Voeg een grafiek toe met standaardgegevens.
1. Haal de werkelijke maximale waarde op de as op.
1. Haal de werkelijke minimale waarde op de as op.
1. Haal de werkelijke hoofd‑eenheid van de as op.
1. Haal de werkelijke onderliggende eenheid van de as op.
1. Haal de werkelijke schaal van de hoofd‑eenheid van de as op.
1. Haal de werkelijke schaal van de onderliggende eenheid van de as op.

Deze voorbeeldcode—een implementatie van de bovenstaande stappen—laat zien hoe je de vereiste waarden in C++ kunt ophalen:

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
Aspose.Slides maakt het mogelijk om snel de gegevens tussen assen te verwisselen—de gegevens op de verticale as (y‑as) worden naar de horizontale as (x‑as) verplaatst en omgekeerd.

Deze C++‑code laat zien hoe je de gegevensverwisseling tussen assen op een grafiek kunt uitvoeren:

``` cpp
// Maakt een lege presentatie
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

// Wisselt rijen en kolommen
chart->get_ChartData()->SwitchRowColumn();

// Slaat de presentatie op
pres->Save(u"SwitchChartRowColumns_out.pptx", SaveFormat::Pptx);
```

## **De verticale as uitschakelen voor lijndiagrammen**

Deze C++‑code laat zien hoe je de verticale as voor een lijndiagram kunt verbergen:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **De horizontale as uitschakelen voor lijndiagrammen**

Deze code laat zien hoe je de horizontale as voor een lijndiagram kunt verbergen:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Line, 100.0f, 100.0f, 400.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_IsVisible(false);

pres->Save(u"chart.pptx", SaveFormat::Pptx);
```

## **Een categorie‑as wijzigen**

Met de methode **set_CategoryAxisType()** kun je het gewenste type categorie‑as opgeven (**date** of **text**). Deze C++‑code demonstreert de bewerking:

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

## **Het datumformaat instellen voor categorie‑aswaarden**
Aspose.Slides for C++ maakt het mogelijk om het datumformaat voor een categorie‑aswaarde in te stellen. De bewerking wordt gedemonstreerd in deze C++‑code:

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

## **De rotatiehoek voor een as‑titel instellen**
Aspose.Slides for C++ maakt het mogelijk om de rotatiehoek voor een grafiekas‑titel in te stellen. Deze C++‑code demonstreert de bewerking:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
auto verticalAxis = chart->get_Axes()->get_VerticalAxis();
verticalAxis->set_HasTitle(true);
verticalAxis->get_Title()->get_TextFormat()->get_TextBlockFormat()->set_RotationAngle(90.0f);

pres->Save(u"test.pptx", SaveFormat::Pptx);
```

## **De aspositie instellen op een categorie‑ of waardenas**
Aspose.Slides for C++ maakt het mogelijk om de positie‑as in te stellen op een categorie‑ of waardenas. Deze C++‑code laat zien hoe je de taak kunt uitvoeren:

``` cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_HorizontalAxis()->set_AxisBetweenCategories(true);

pres->Save(u"AsposeScatterChart.pptx", SaveFormat::Pptx);
```

## **De weergave van een eenheidsetiket op een waardenas van een grafiek inschakelen**
Aspose.Slides for C++ maakt het mogelijk om een grafiek zo te configureren dat er een eenheidsetiket op de waardenas wordt getoond. Deze C++‑code demonstreert de bewerking:

``` cpp
auto pres = System::MakeObject<Presentation>(u"Test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 450.0f, 300.0f);
chart->get_Axes()->get_VerticalAxis()->set_DisplayUnit(DisplayUnitType::Millions);

pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Hoe stel ik de waarde in waarop één as de andere (as‑kruising) kruist?**

Assen bieden een [crossing setting](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/axis/set_crosstype/): je kunt kiezen om te kruisen bij nul, bij de maximale categorie/waarde, of bij een specifieke numerieke waarde. Dit is handig om de X‑as omhoog of omlaag te verschuiven of om een referentielijn te benadrukken.

**Hoe kan ik de markeringlabels ten opzichte van de as positioneren (langs, buiten, binnen)?**

Stel de [label position](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/axis/set_majortickmark/) in op "cross", "outside" of "inside". Dit beïnvloedt de leesbaarheid en helpt ruimte te besparen, vooral bij kleine grafieken.