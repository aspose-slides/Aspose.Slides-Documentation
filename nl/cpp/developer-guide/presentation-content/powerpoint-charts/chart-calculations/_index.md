---
title: Optimaliseer chartberekeningen voor presentaties in C++
linktitle: Chartberekeningen
type: docs
weight: 50
url: /nl/cpp/chart-calculations/
keywords:
- chartberekeningen
- chart-elementen
- elementpositie
- feitelijke positie
- kind-element
- bovenliggend element
- chartwaarden
- feitelijke waarde
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Begrijp chartberekeningen, gegevensupdates en precisiebeheer in Aspose.Slides voor C++ voor PPT en PPTX, met praktische C++ code-voorbeelden."
---
## **Overzicht**

Aspose.Slides biedt API's voor het werken met chartberekeningen en lay-outgegevens in presentaties. Dit artikel laat zien hoe u de werkelijke waarden van chart‑elementen kunt ophalen, inclusief de feitelijke positie en grootte van elementen die `IActualLayout` implementeren en de werkelijke waarden van de chart‑assen. Het legt ook uit dat deze waarden worden gevuld na validatie van de chart‑lay‑out.

Bovendien toont het artikel hoe u de feitelijke positie van bovenliggende chart‑elementen kunt verkrijgen en hoe u chart‑componenten zoals de titel, assen, legenda en rasterlijnen kunt verbergen. Samen helpen deze voorbeelden u om chart‑lay‑outinformatie te inspecteren en de zichtbaarheid van chart‑elementen in PowerPoint‑presentaties programmatically te controleren.

## **Werkelijke waarden van chart‑elementen berekenen**
Aspose.Slides for C++ biedt een eenvoudige API om deze eigenschappen op te halen. Dit helpt u bij het berekenen van de werkelijke waarden van chart‑elementen. De werkelijke waarden omvatten de positie van elementen die de IActualLayout‑interface implementeren (IActualLayout::get_ActualX(), IActualLayout::get_ActualY(), IActualLayout::get_ActualWidth(), IActualLayout::get_ActualHeight()) en de werkelijke waarden van assen (IAxis::get_ActualMaxValue(), IAxis::get_ActualMinValue(), IAxis::get_ActualMajorUnit(), IAxis::get_ActualMinorUnit(), IAxis::get_ActualMajorUnitScale(), IAxis::get_ActualMinorUnitScale()).

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Presentatie opslaan
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **De feitelijke positie van bovenliggende chart‑elementen berekenen**
Aspose.Slides for C++ biedt een eenvoudige API om deze eigenschappen op te halen. Methoden van IActualLayout geven informatie over de feitelijke positie van het bovenliggende chart‑element. Het is noodzakelijk om eerst de methode IChart::ValidateChartLayout() aan te roepen om de eigenschappen met werkelijke waarden te vullen.

``` cpp
// Lege presentatie maken
auto pres = System::MakeObject<Presentation>();

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();
```

## **Chart‑elementen verbergen**
Dit onderwerp helpt u te begrijpen hoe u informatie in een chart kunt verbergen. Met Aspose.Slides for C++ kunt u **Titel, verticale as, horizontale as** en **rasterlijnen** in een chart verbergen. Het onderstaande code‑voorbeeld laat zien hoe u deze eigenschappen gebruikt.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **Gegevensbereik voor een chart instellen**
Aspose.Slides for C++ heeft de eenvoudigste API geleverd om het gegevensbereik voor een chart op de gemakkelijkste manier in te stellen. Om het gegevensbereik voor een chart in te stellen:

- Open een instantie van de klasse **Presentation** die een chart bevat.
- Verkrijg de referentie van een dia via diens **Index**.
- Doorloop alle vormen om de gewenste chart te vinden.
- Toegang tot de chart‑gegevens en stel het bereik in.
- Sla de aangepaste presentatie op als een PPTX‑bestand.

De onderstaande code‑voorbeelden laten zien hoe u een chart bijwerkt.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}

## **FAQ**

**Werken externe Excel‑werkboeken als gegevensbron, en hoe beïnvloedt dat herberekening?**

Ja. Een chart kan naar een extern werkboek verwijzen: wanneer u de externe bron verbindt of ververst, worden formules en waarden uit dat werkboek gehaald, en de chart toont de updates tijdens open-/bewerkingsbewerkingen. De API stelt u in staat om het pad van het [externe werkboek](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/chartdata/setexternalworkbook/) op te geven en de gekoppelde gegevens te beheren.

**Kan ik trendlijnen berekenen en weergeven zonder zelf regressie te implementeren?**

Ja. [Trendlijnen](/slides/nl/cpp/trend-line/) (lineair, exponentieel en andere) worden door Aspose.Slides toegevoegd en bijgewerkt; hun parameters worden automatisch herberekend op basis van de seriedata, zodat u geen eigen berekeningen hoeft te implementeren.

**Als een presentatie meerdere charts met externe koppelingen bevat, kan ik bepalen welk werkboek elke chart gebruikt voor berekende waarden?**

Ja. Elke chart kan naar zijn eigen [externe werkboek](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/chartdata/setexternalworkbook/) verwijzen, of u kunt per chart een extern werkboek creëren/vervangen, onafhankelijk van de anderen.