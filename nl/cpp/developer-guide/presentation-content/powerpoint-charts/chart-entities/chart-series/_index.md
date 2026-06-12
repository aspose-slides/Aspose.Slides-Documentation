---
title: Beheer grafiekgegevensreeksen in presentaties met C++
linktitle: Gegevensreeks
type: docs
url: /nl/cpp/chart-series/
keywords:
- grafiekreeks
- reeks overlapping
- reeks kleur
- categorie kleur
- reeksnaam
- datapunt
- reeks tussenruimte
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u grafiekreeksen in C++ voor PowerPoint (PPT/PPTX) kunt beheren met praktische codevoorbeelden en best practices om uw datapresentaties te verbeteren."
---
## **Overzicht**

Dit artikel beschrijft de rol van [ChartSeries](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/chartseries/) in Aspose.Slides, met nadruk op hoe gegevens worden gestructureerd en visualiseerd binnen presentaties. Deze objecten vormen de fundamentele elementen die individuele sets van gegevenspunten, categorieën en weergave‑parameters in een diagram definiëren. Door met [ChartSeries](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/chartseries/) te werken, kunnen ontwikkelaars onderliggende gegevensbronnen naadloos integreren en volledige controle behouden over hoe informatie wordt weergegeven, wat leidt tot dynamische, data‑gedreven presentaties die duidelijk inzichten en analyses overbrengen.

Een serie is een rij of kolom met getallen die in een diagram wordt uitgezet.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Stel de overlappende gegevensreeks in**

Met de [IChartSeries::get_Overlap()](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.charts.i_chart_series#a5ae56346bd11dc0a2264ff049a3e72bb) methode kun je opgeven hoeveel balken en kolommen moeten overlappen in een 2D-diagram (bereik: -100 tot 100). Deze eigenschap is van toepassing op alle reeksen van de bovenliggende seriesgroep: dit is een projectie van de betreffende groeps­eigenschap.

Gebruik de `get_ParentSeriesGroup()::set_Overlap()` methode om je gewenste waarde voor `Overlap` in te stellen. 

1. Maak een instantie van de [Presentation] klasse aan.
1. Voeg een gegroepeerde kolomgrafiek toe aan een dia.
1. Open de eerste diagramreeks.
1. Open de `ParentSeriesGroup` van de diagramreeks en stel de gewenste overlappingswaarde voor de reeks in.
1. Schrijf de aangepaste presentatie naar een PPTX‑bestand.

Deze C++‑code toont hoe je de overlap voor een diagramreeks instelt:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Voegt grafiek toe
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
if (series->idx_get(0)->get_Overlap() == 0)
{
    // Stelt de overlap van de reeks in
    series->idx_get(0)->get_ParentSeriesGroup()->set_Overlap(-30);
}

// Schrijft het presentatiedocument naar schijf
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **Verander de kleur van de gegevensreeks**

Aspose.Slides voor C++ maakt het mogelijk om de kleur van een reeks op deze manier te wijzigen:

1. Maak een instantie van de [Presentation] klasse aan.
1. Voeg een diagram toe op de dia.
1. Open de reeks waarvan je de kleur wilt wijzigen. 
1. Stel het gewenste opvultype en de opvulkleur in.
1. Sla de aangepaste presentatie op.

Deze C++‑code toont hoe je de kleur van een reeks wijzigt:

```cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Pie, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(1);

point->set_Explosion(30);
point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Verander de kleur van een categorie van de gegevensreeks**

Aspose.Slides voor C++ maakt het mogelijk om de kleur van een reekscategorie op deze manier te wijzigen:

1. Maak een instantie van de [Presentation] klasse aan.
1. Voeg een diagram toe op de dia.
1. Open de reekscategorie waarvan je de kleur wilt wijzigen.
1. Stel het gewenste opvultype en de opvulkleur in.
1. Sla de aangepaste presentatie op.

Deze C++‑code toont hoe je de kleur van een reekscategorie wijzigt:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
auto point = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints()->idx_get(0);

point->get_Format()->get_Fill()->set_FillType(FillType::Solid);
point->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(Color::get_Blue());

pres->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Verander de naam van de gegevensreeks** 

Standaard zijn de legendarienamen voor een diagram de inhoud van de cellen boven elke kolom of rij met gegevens. 

In ons voorbeeld (voorbeeldafbeelding), 

* de kolommen zijn *Series 1, Series 2,* en *Series 3*;
* de rijen zijn *Category 1, Category 2, Category 3,* en *Category 4.* 

Aspose.Slides voor C++ maakt het mogelijk om een reeksnamen in de diagramgegevens en de legende bij te werken of te wijzigen. 

Deze C++‑code toont hoe je de naam van een reeks wijzigt in de diagramgegevens `ChartDataWorkbook`:

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"New name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

Deze C++‑code toont hoe je een reeksnaam wijzigt in de legende via`Series`:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"New name"));
```

## **Stel de vulkleur van de gegevensreeks in**

Aspose.Slides voor C++ maakt het mogelijk om de automatische vulkleur voor diagramreeksen binnen een plotgebied op deze manier in te stellen:

1. Maak een instantie van de [Presentation] klasse aan.
1. Verkrijg een referentie naar een dia via de index.
1. Voeg een diagram toe met standaardgegevens op basis van het gewenste type (in het onderstaande voorbeeld gebruikten we `ChartType::ClusteredColumn`).
1. Open de diagramreeks en stel de vulkleur in op Automatisch.
1. Sla de presentatie op naar een PPTX‑bestand.

Deze C++‑code toont hoe je de automatische vulkleur voor een diagramreeks instelt:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Maakt een gegroepeerde kolomgrafiek aan
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// Stelt het vulformaat van de reeks in op automatisch
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// Schrijft het presentatiedocument naar schijf
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **Stel omgekeerde vulkleuren voor de gegevensreeks in**

Aspose.Slides maakt het mogelijk om de omgekeerde vulkleur voor diagramreeksen binnen een plotgebied op deze manier in te stellen:

1. Maak een instantie van de [Presentation] klasse aan.
1. Verkrijg een referentie naar een dia via de index.
1. Voeg een diagram toe met standaardgegevens op basis van het gewenste type (in het onderstaande voorbeeld gebruikten we `ChartType::ClusteredColumn`).
1. Open de diagramreeks en stel de vulkleur in op omkeren.
1. Sla de presentatie op naar een PPTX‑bestand.

Deze C++‑code demonstreert de bewerking:

```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// Voegt nieuwe series en categorieën toe
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Neemt de eerste diagramreeks en vult de reeksdaten.
auto series = chartData->get_Series()->idx_get(0);
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 1, 1, ObjectExt::Box<int32_t>(-20)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 2, 1, ObjectExt::Box<int32_t>(50)));
series->get_DataPoints()->AddDataPointForBarSeries(workBook->GetCell(0, 3, 1, ObjectExt::Box<int32_t>(-30)));
Color seriesColor = series->GetAutomaticSeriesColor();
series->set_InvertIfNegative(true);
series->get_Format()->get_Fill()->set_FillType(FillType::Solid);
series->get_Format()->get_Fill()->get_SolidFillColor()->set_Color(seriesColor);
series->get_InvertedSolidFillColor()->set_Color(inverColor);
pres->Save(u"SetInvertFillColorChart_out.pptx", SaveFormat::Pptx);
```

## **Stel omgekeerde vulkleur in voor een diagramreeks**

Aspose.Slides maakt het mogelijk om omkeringen in te stellen via de`IChartDataPoint::set_InvertIfNegative()` en `ChartDataPoint.set_InvertIfNegative()` methoden. Wanneer een omkering is ingesteld met deze methoden, keert het gegevenspunt zijn kleuren om zodra het een negatieve waarde krijgt. 

Deze C++‑code demonstreert de bewerking:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series();
chart->get_ChartData()->get_Series()->Clear();

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
series->Add(workBook->GetCell(0, u"B1"), chart->get_Type());
auto dataPoints = series->idx_get(0)->get_DataPoints();
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B2", ObjectExt::Box<int32_t>(-5)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B3", ObjectExt::Box<int32_t>(3)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B4", ObjectExt::Box<int32_t>(-2)));
dataPoints->AddDataPointForBarSeries(workBook->GetCell(0, u"B5", ObjectExt::Box<int32_t>(1)));

series->idx_get(0)->set_InvertIfNegative(false);

series->idx_get(0)->get_DataPoints()->idx_get(2)->set_InvertIfNegative(true);

pres->Save(u"out.pptx", SaveFormat::Pptx);
```

## **Specifieke gegevenspuntwaarden wissen**

Aspose.Slides voor C++ maakt het mogelijk om de `DataPoints`‑gegevens voor een specifieke diagramreeks op deze manier te wissen:

1. Maak een instantie van de [Presentation] klasse aan.
2. Verkrijg de referentie van een dia via de index.
3. Verkrijg de referentie van een diagram via de index.
4. Iterate over alle diagram‑`DataPoints` en stel `XValue` en `YValue` in op null.
5. Wis alle `DataPoints` voor een specifieke diagramreeks.
6. Schrijf de aangepaste presentatie naar een PPTX‑bestand.

Deze C++‑code demonstreert de bewerking:

```cpp
auto pres = System::MakeObject<Presentation>(u"TestChart.pptx");
auto sl = pres->get_Slides()->idx_get(0);

auto chart = System::ExplicitCast<IChart>(sl->get_Shapes()->idx_get(0));
auto dataPoints = chart->get_ChartData()->get_Series()->idx_get(0)->get_DataPoints();

for (const auto& dataPoint : dataPoints)
{
    dataPoint->get_XValue()->get_AsCell()->set_Value(nullptr);
    dataPoint->get_YValue()->get_AsCell()->set_Value(nullptr);
}

dataPoints->Clear();

pres->Save(u"ClearSpecificChartSeriesDataPointsData.pptx", SaveFormat::Pptx);
```

## **Stel de tussenruimte van de gegevensreeks in**

Aspose.Slides voor C++ maakt het mogelijk om een reeksgapbreedte in te stellen via de **`set_GapWidth()`** methode op deze manier:

1. Maak een instantie van de [Presentation] klasse aan.
1. Open de eerste dia.
1. Voeg een diagram toe met standaardgegevens.
1. Open een willekeurige diagramreeks.
1. Stel de eigenschap `GapWidth` in.
1. Schrijf de aangepaste presentatie naar een PPTX‑bestand.

Deze C++‑code toont hoe je een reeksgapbreedte instelt:

```cpp
// Maakt een lege presentatie
auto presentation = System::MakeObject<Presentation>();

// Toegang tot de eerste dia van de presentatie
auto slide = presentation->get_Slides()->idx_get(0);

// Voegt een grafiek toe met standaardgegevens
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// Stelt de index van het grafiekdatablad in
int32_t worksheetIndex = 0;

// Haalt het werkblad met grafiekgegevens op
auto workbook = chart->get_ChartData()->get_ChartDataWorkbook();

// Voegt reeksen toe
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chart->get_ChartData()->get_Series()->Add(workbook->GetCell(worksheetIndex, 0, 2, ObjectExt::Box<String>(u"Series 2")), chart->get_Type());

// Voegt categorieën toe
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chart->get_ChartData()->get_Categories()->Add(workbook->GetCell(worksheetIndex, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Neemt de tweede grafiekreeks
auto series = chart->get_ChartData()->get_Series()->idx_get(1);
auto dataPoints = series->get_DataPoints();

// Vult de reeksgegevens
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(20)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(50)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<int32_t>(10)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<int32_t>(60)));

// Stelt de GapWidth-waarde in
series->get_ParentSeriesGroup()->set_GapWidth(50);

// Slaat de presentatie op naar schijf
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Is er een limiet aan hoeveel reeksen een enkel diagram kan bevatten?**

Aspose.Slides legt geen vaste bovengrens op aan het aantal reeksen dat je toevoegt. De praktische limiet wordt bepaald door de leesbaarheid van het diagram en door het beschikbare geheugen van je applicatie.

**Wat als de kolommen binnen een cluster te dicht bij elkaar of te ver van elkaar staan?**

Pas de instelling voor de gap‑breedte van die reeks (of de bovenliggende seriesgroep) aan. Een hogere waarde vergroot de ruimte tussen de kolommen, een lagere waarde brengt ze dichter bij elkaar.