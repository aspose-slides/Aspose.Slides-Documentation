---
title: Optimera diagramberäkningar för presentationer i C++
linktitle: Diagramberäkningar
type: docs
weight: 50
url: /sv/cpp/chart-calculations/
keywords:
- diagramberäkningar
- diagramelement
- elementposition
- faktisk position
- underordnat element
- föräldraelement
- diagramvärden
- faktiskt värde
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Förstå diagramberäkningar, datauppdateringar och precisionstyrning i Aspose.Slides för C++ för PPT och PPTX, med praktiska C++-kodexempel."
---
## **Översikt**

Aspose.Slides tillhandahåller API:er för att arbeta med diagramberäkningar och layoutdata i presentationer. Den här artikeln visar hur du hämtar de faktiska värdena för diagramelement, inklusive den verkliga positionen och storleken för element som implementerar `IActualLayout` samt de faktiska värdena för diagramaxlar. Den förklarar också att dessa värden fylls i efter validering av diagramlayout.

Dessutom visar artikeln hur du får den faktiska positionen för föräldra-diagramelement och hur du döljer diagramkomponenter såsom titel, axlar, legend och rutnät. Tillsammans hjälper dessa exempel dig att inspektera diagramlayoutinformation och kontrollera synligheten för diagramelement i PowerPoint-presentationer programatiskt.

## **Beräkna faktiska värden för diagramelement**
Aspose.Slides for C++ tillhandahåller ett enkelt API för att hämta dessa egenskaper. Detta hjälper dig att beräkna faktiska värden för diagramelement. De faktiska värdena inkluderar positionen för element som implementerar IActualLayout-gränssnittet (IActualLayout::get_ActualX(), IActualLayout::get_ActualY(), IActualLayout::get_ActualWidth(), IActualLayout::get_ActualHeight()) och faktiska axelvärden (IAxis::get_ActualMaxValue(), IAxis::get_ActualMinValue(), IAxis::get_ActualMajorUnit(), IAxis::get_ActualMinorUnit(), IAxis::get_ActualMajorUnitScale(), IAxis::get_ActualMinorUnitScale()).

``` cpp
auto pres = System::MakeObject<Presentation>(u"test.pptx");
    
auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();

// Spara presentationen
pres->Save(u"Result.pptx", SaveFormat::Pptx);
```

## **Beräkna den faktiska positionen för föräldra-diagramelement**
Aspose.Slides for C++ tillhandahåller ett enkelt API för att hämta dessa egenskaper. Metoder i IActualLayout ger information om den faktiska positionen för föräldra-diagramelementet. Det är nödvändigt att tidigare anropa metoden IChart::ValidateChartLayout() för att fylla egenskaperna med faktiska värden.

``` cpp
// Skapar tom presentation
auto pres = System::MakeObject<Presentation>();

auto chart = System::ExplicitCast<Chart>(pres->get_Slides()->idx_get(0)->get_Shapes()->AddChart(ChartType::ClusteredColumn, 100.0f, 100.0f, 500.0f, 350.0f));
chart->ValidateChartLayout();

double x = chart->get_PlotArea()->get_ActualX();
double y = chart->get_PlotArea()->get_ActualY();
double w = chart->get_PlotArea()->get_ActualWidth();
double h = chart->get_PlotArea()->get_ActualHeight();
```

## **Dölj diagramelement**
Detta ämne hjälper dig att förstå hur du döljer information från ett diagram. Med Aspose.Slides for C++ kan du dölja **Titel, Vertikal axel, Horisontell axel** och **Rutlinjer** i diagrammet. Nedanstående kodexempel visar hur du använder dessa egenskaper.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-HideInformationFromChart-HideInformationFromChart.cpp" >}}

## **Ange ett dataintervall för ett diagram**
Aspose.Slides for C++ har tillhandahållit det enklaste API:et för att ange dataintervall för ett diagram på det lättaste sättet. För att ange dataintervall för ett diagram:

- Öppna en instans av Presentation-klassen som innehåller diagrammet.
- Hämta referensen till en bild genom att använda dess Index.
- Iterera genom alla former för att hitta önskat diagram.
- Kom åt diagramdata och ange intervallet.
- Spara den ändrade presentationen som en PPTX-fil.

Kodexemplen nedan visar hur du uppdaterar ett diagram.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetDataRange-SetDataRange.cpp" >}}

## **Vanliga frågor**

**Fungerar externa Excel-arbetsböcker som datakälla, och hur påverkar det omräkning?**

Ja. Ett diagram kan referera till en extern arbetsbok: när du ansluter eller uppdaterar den externa källan tas formler och värden från den arbetsboken, och diagrammet återspeglar uppdateringarna under öppnings-/redigeringsoperationer. API:n låter dig [specificera den externa arbetsboken](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/chartdata/setexternalworkbook/) sökväg och hantera de länkade data.

**Kan jag beräkna och visa trendlinjer utan att implementera regression själv?**

Ja. [Trendlinjer](/slides/sv/cpp/trend-line/) (linjära, exponentiella och andra) läggs till och uppdateras av Aspose.Slides; deras parametrar omberäknas automatiskt från seriesdata, så du behöver inte implementera egna beräkningar.

**Om en presentation har flera diagram med externa länkar, kan jag styra vilken arbetsbok varje diagram använder för beräknade värden?**

Ja. Varje diagram kan peka på sin egen [externa arbetsbok](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/chartdata/setexternalworkbook/), eller så kan du skapa/ersätta en extern arbetsbok per diagram oberoende av de andra.