---
title: Beheer grafiekdatereeksen in presentaties met C++
linktitle: Gegevensreeks
type: docs
url: /nl/cpp/chart-series/
keywords:
- grafiekreeks
- reeks overlap
- reeks kleur
- categorie kleur
- reeks naam
- datapunt
- reeks tussenruimte
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe je grafiekreeksen kunt beheren in C++ voor PowerPoint (PPT/PPTX) met praktische codevoorbeelden en best practices om je gegevenspresentaties te verbeteren."
---
## **Overzicht**

Dit artikel beschrijft de rol van [ChartSeries](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/chartseries/) in Aspose.Slides, met de focus op hoe gegevens worden gestructureerd en gevisualiseerd binnen presentaties. Deze objecten vormen de fundamentele elementen die individuele sets van datapunten, categorieën en weergave‑parameters in een grafiek definiëren. Door met [ChartSeries](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/chartseries/) te werken, kunnen ontwikkelaars onderliggende gegevensbronnen naadloos integreren en volledige controle behouden over hoe informatie wordt weergegeven, wat resulteert in dynamische, gegevens‑gedreven presentaties die duidelijk inzichten en analyses overbrengen.

Een serie is een rij of kolom van getallen die in een grafiek worden uitgezet.

![chart-series-powerpoint](chart-series-powerpoint.png)

## **Stel de overlap van de gegevensreeks in**

Met de IChartSeries::get_Overlap()‑methode kun je opgeven hoeveel balken en kolommen moeten overlappen in een 2D‑grafiek (bereik: -100 tot 100). Deze eigenschap is van toepassing op alle series van de bovenliggende series‑groep: dit is een projectie van de overeenkomstige groeps‑eigenschap.

Gebruik de `get_ParentSeriesGroup()::set_Overlap()`‑methode om de gewenste waarde voor `Overlap` in te stellen. 

1. Maak een instantie van de Presentation‑klasse aan.
1. Voeg een gegroepeerde kolomgrafiek toe aan een dia.
1. Toegang tot de eerste grafiekserie.
1. Toegang tot de `ParentSeriesGroup` van de grafiekserie en stel de gewenste overlapwaarde in.
1. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

Deze C++‑code laat zien hoe je de overlap voor een grafiekserie instelt:

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

// Schrijft het presentatiebestand naar de schijf
presentation->Save(u"SetChartSeriesOverlap_out.pptx", SaveFormat::Pptx);
```

## **Verander de kleur van de gegevensreeks**

Aspose.Slides voor C++ maakt het mogelijk om de kleur van een serie op deze manier te wijzigen:

1. Maak een instantie van de Presentation‑klasse aan.
1. Voeg een grafiek toe aan de dia.
1. Toegang tot de serie waarvan je de kleur wilt wijzigen. 
1. Stel het gewenste opvultype en de opvulkleur in.
1. Sla de gewijzigde presentatie op.

Deze C++‑code laat zien hoe je de kleur van een serie wijzigt:

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

## **Verander de kleur van een categorie van een gegevensreeks**

Aspose.Slides voor C++ maakt het mogelijk om de kleur van een seriecategorie op deze manier te wijzigen:

1. Maak een instantie van de Presentation‑klasse aan.
1. Voeg een grafiek toe aan de dia.
1. Toegang tot de seriecategorie waarvan je de kleur wilt wijzigen.
1. Stel het gewenste opvultype en de opvulkleur in.
1. Sla de gewijzigde presentatie op.

Deze C++‑code laat zien hoe je de kleur van een seriecategorie wijzigt:

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

Standaard zijn de legendanaam­men van een grafiek de inhoud van de cellen boven elke kolom of rij met gegevens. 

In ons voorbeeld (voorbeeldafbeelding),

* de kolommen zijn *Series 1, Series 2,* en *Series 3*;
* de rijen zijn *Category 1, Category 2, Category 3,* en *Category 4.* 

Aspose.Slides voor C++ maakt het mogelijk om een serienaam bij te werken of te wijzigen in de grafiekdata en de legenda. 

Deze C++‑code laat zien hoe je de naam van een serie wijzigt in de grafiekdata `ChartDataWorkbook`:

```cpp
auto pres = System::MakeObject<Presentation>();

auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);

auto seriesCell = chart->get_ChartData()->get_ChartDataWorkbook()->GetCell(0, 0, 1);
seriesCell->set_Value(ObjectExt::Box<String>(u"New name"));

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

Deze C++‑code laat zien hoe je een serienaam wijzigt in de legenda via `Series`:

```cpp
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();

auto chart = shapes->AddChart(ChartType::Column3D, 50.0f, 50.0f, 600.0f, 400.0f, true);
auto series = chart->get_ChartData()->get_Series()->idx_get(0);

auto name = series->get_Name();
name->get_AsCells()->idx_get(0)->set_Value(ObjectExt::Box<String>(u"New name"));
```

## **Stel de vulkleur van de gegevensreeks in**

Aspose.Slides voor C++ maakt het mogelijk om de automatische vulkleur voor grafiekseries binnen een plotgebied op deze manier in te stellen:

1. Maak een instantie van de Presentation‑klasse aan.
1. Verkrijg een referentie naar een dia via het indexnummer.
1. Voeg een grafiek toe met standaardgegevens op basis van het door jou gewenste type (in het onderstaande voorbeeld gebruikten we `ChartType::ClusteredColumn`).
1. Toegang tot de grafiekserie en stel de vulkleur in op Automatic.
1. Sla de presentatie op als een PPTX‑bestand.

Deze C++‑code laat zien hoe je de automatische vulkleur voor een grafiekserie instelt:

```cpp
auto presentation = System::MakeObject<Presentation>();
auto shapes = presentation->get_Slides()->idx_get(0)->get_Shapes();

// Maakt een gegroepeerde kolomgrafiek
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 50.0f, 600.0f, 400.0f);

// Stelt het vulformaat van de reeks in op automatisch
for (const auto& series : chart->get_ChartData()->get_Series())
{
    series->GetAutomaticSeriesColor();
}

// Schrijft het presentatiebestand naar de schijf
presentation->Save(u"AutoFillSeries_out.pptx", SaveFormat::Pptx);
```

## **Stel omgekeerde vulkleuren voor de gegevensreeks in**

Aspose.Slides maakt het mogelijk om de omgekeerde vulkleur voor grafiekseries binnen een plotgebied op deze manier in te stellen:

1. Maak een instantie van de Presentation‑klasse aan.
1. Verkrijg een referentie naar een dia via het indexnummer.
1. Voeg een grafiek toe met standaardgegevens op basis van het door jou gewenste type (in het onderstaande voorbeeld gebruikten we `ChartType::ClusteredColumn`).
1. Toegang tot de grafiekserie en stel de vulkleur in op invert.
1. Sla de presentatie op als een PPTX‑bestand.

Deze C++‑code demonstreert de handeling:

```cpp
Color inverColor = Color::get_Red();
    
auto pres = System::MakeObject<Presentation>();
auto shapes = pres->get_Slides()->idx_get(0)->get_Shapes();
auto chart = shapes->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 400.0f, 300.0f);

auto workBook = chart->get_ChartData()->get_ChartDataWorkbook();
auto chartData = chart->get_ChartData();

chartData->get_Series()->Clear();
chartData->get_Categories()->Clear();

// Voeg nieuwe reeksen en categorieën toe
chartData->get_Series()->Add(workBook->GetCell(0, 0, 1, ObjectExt::Box<String>(u"Series 1")), chart->get_Type());
chartData->get_Categories()->Add(workBook->GetCell(0, 1, 0, ObjectExt::Box<String>(u"Category 1")));
chartData->get_Categories()->Add(workBook->GetCell(0, 2, 0, ObjectExt::Box<String>(u"Category 2")));
chartData->get_Categories()->Add(workBook->GetCell(0, 3, 0, ObjectExt::Box<String>(u"Category 3")));

// Neem de eerste grafiekreeks en vul de reeksgegevens.
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

## **Stel omgekeerde vulkleur in voor een grafiekserie**

Aspose.Slides maakt het mogelijk om omkeringen in te stellen via de `IChartDataPoint::set_InvertIfNegative()`‑ en `ChartDataPoint.set_InvertIfNegative()`‑methoden. Wanneer een omkering wordt ingesteld via deze methoden, keert het datapunt zijn kleuren om zodra het een negatieve waarde krijgt. 

Deze C++‑code demonstreert de handeling:

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

## **Wis specifieke waarden van datapunten**

Aspose.Slides voor C++ maakt het mogelijk om de `DataPoints`‑gegevens voor een specifieke grafiekserie op deze manier te wissen:

1. Maak een instantie van de Presentation‑klasse aan.
2. Verkrijg de referentie van een dia via het indexnummer.
3. Verkrijg de referentie van een grafiek via het indexnummer.
4. Doorloop alle `DataPoints` van de grafiek en stel `XValue` en `YValue` in op null.
5. Wis alle `DataPoints` voor de specifieke grafiekserie.
6. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

Deze C++‑code demonstreert de handeling:

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

Aspose.Slides voor C++ maakt het mogelijk om de tussenruimte (gap width) van een serie in te stellen via de **`set_GapWidth()`**‑methode op deze manier:

1. Maak een instantie van de Presentation‑klasse aan.
1. Toegang tot de eerste dia.
1. Voeg een grafiek toe met standaardgegevens.
1. Toegang tot een willekeurige grafiekserie.
1. Stel de eigenschap `GapWidth` in.
1. Schrijf de gewijzigde presentatie naar een PPTX‑bestand.

Deze C++‑code laat zien hoe je de tussenruimte van een serie instelt:

```cpp
// Maakt een lege presentatie 
auto presentation = System::MakeObject<Presentation>();

// Benadert de eerste dia van de presentatie
auto slide = presentation->get_Slides()->idx_get(0);

// Voegt een grafiek toe met standaardgegevens
auto chart = slide->get_Shapes()->AddChart(ChartType::StackedColumn, 0.0f, 0.0f, 500.0f, 500.0f);

// Stelt de index van het chart-data-blad in
int32_t worksheetIndex = 0;

// Haalt het werkblad met chart-data op
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

// Vult de reeksen‑data
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 1, ObjectExt::Box<int32_t>(20)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 1, ObjectExt::Box<int32_t>(50)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 1, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 1, 2, ObjectExt::Box<int32_t>(30)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 2, 2, ObjectExt::Box<int32_t>(10)));
dataPoints->AddDataPointForBarSeries(workbook->GetCell(worksheetIndex, 3, 2, ObjectExt::Box<int32_t>(60)));

// Stelt de GapWidth‑waarde in
series->get_ParentSeriesGroup()->set_GapWidth(50);

// Slaat de presentatie op naar schijf
presentation->Save(u"GapWidth_out.pptx", SaveFormat::Pptx);
```

## **Veelgestelde vragen**

**Is er een limiet aan hoeveel series een enkele grafiek kan bevatten?**

Aspose.Slides legt geen vaste limiet op aan het aantal series dat je toevoegt. Het praktische maximum wordt bepaald door de leesbaarheid van de grafiek en door het beschikbare geheugen van je toepassing.

**Wat als de kolommen binnen een cluster te dicht op elkaar of te ver van elkaar staan?**

Pas de instelling voor de tussenruimte (gap width) aan voor die serie (of de bovenliggende series‑groep). Een hogere waarde vergroot de ruimte tussen de kolommen, een lagere waarde brengt ze dichter bij elkaar.