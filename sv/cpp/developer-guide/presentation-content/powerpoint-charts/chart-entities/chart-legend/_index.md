---
title: Anpassa diagramförklaringar i presentationer med C++
linktitle: Diagramförklaring
type: docs
url: /sv/cpp/chart-legend/
keywords:
- diagramförklaring
- förklaringsposition
- teckenstorlek
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Anpassa diagramförklaringar med Aspose.Slides för C++ för att optimera PowerPoint-presentationer med skräddarsydd förklaringsformatering."
---
## **Översikt**

Aspose.Slides för C++ erbjuder alternativ för att anpassa diagramförklaringar i PowerPoint-presentationer. Denna artikel visar hur man placerar och storlekar en förklaring, anger teckenstorleken för hela förklaringen, formaterar ett enskilt förklaringsobjekt och döljer eller återställer valda objekt.

FAQ:n täcker relaterade beteenden, inklusive att reservera utrymme för förklaringen, visa flerradiga etiketter och ärva formatering från presentationstemat.

## **Placering av förklaring**

Använd förklaringens [set_X](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_x/), [set_Y](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_y/), [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_width/) och [set_Height](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_height/) metoder för att ange dess position och storlek som bråkdelar av diagrammets dimensioner.

Detta exempel skapar en presentation och lägger till ett staplat kolumndiagram med standarddata på den första bilden. Genom att dela de önskade förklaringsförskjutningarna och dimensionerna med diagrammets bredd och höjd konverteras de till relativa värden: förklaringen är förskjuten 50 punkter från diagrammets övre vänstra hörn och har storleken 100 gånger 100 punkter.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 500, 500);

// Express the legend's position and size relative to the chart.
chart->get_Legend()->set_X(50 / chart->get_Width());
chart->get_Legend()->set_Y(50 / chart->get_Height());
chart->get_Legend()->set_Width(100 / chart->get_Width());
chart->get_Legend()->set_Height(100 / chart->get_Height());

presentation->Save(u"legend_position.pptx", SaveFormat::Pptx);
```

## **Ange teckenstorlek för en förklaring**

Använd förklaringens [get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_textformat/) för att komma åt dess textformatering och använd [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) för att ange teckenstorleken i punkter.

Detta exempel skapar ett diagram med standarddata och sätter förklaringstexten till 20 punkter. Det inaktiverar också automatiska gränser för den vertikala axeln och sätter dess intervall till -5 till 10.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IAxesManager.h>
#include <DOM/Chart/IAxis.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);

chart->get_Legend()->get_TextFormat()->get_PortionFormat()->set_FontHeight(20);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMinValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MinValue(-5);
chart->get_Axes()->get_VerticalAxis()->set_IsAutomaticMaxValue(false);
chart->get_Axes()->get_VerticalAxis()->set_MaxValue(10);

presentation->Save(u"legend_font_size.pptx", SaveFormat::Pptx);
```

## **Ange teckenstorlek för ett enskilt förklaringsobjekt**

Använd samlingen som returneras av förklaringens [get_Entries](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_entries/) metod för att komma åt formatering för ett specifikt objekt. Objektindex är nollbaserade, så index `1` hänvisar till det andra objektet.

Detta exempel skapar ett staplat kolumndiagram vars standarddata innehåller minst två serier. Det formaterar det andra förklaringsobjektet med fet, kursiv och 20-punkters blå text.

```cpp
#include <system/shared_ptr.h>
#include <drawing/color.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/ILegendEntryCollection.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/NullableBool.h>
#include <DOM/IFillFormat.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
auto textFormat = chart->get_Legend()->get_Entries()->idx_get(1)->get_TextFormat();

textFormat->get_PortionFormat()->set_FontBold(NullableBool::True);
textFormat->get_PortionFormat()->set_FontHeight(20);
textFormat->get_PortionFormat()->set_FontItalic(NullableBool::True);
textFormat->get_PortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
textFormat->get_PortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Blue());

presentation->Save(u"legend_entry_format.pptx", SaveFormat::Pptx);
```

## **Dölj enskilda förklaringsobjekt**

För att utesluta en hjälpserie från förklaringen samtidigt som dess data är synliga, anropa [ILegendEntryProperties::set_Hide](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilegendentryproperties/set_hide/) med `true` via [IChartSeries::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_relatedlegendentry/). Detta döljer endast det valda förklaringsobjektet; det tar inte bort serien eller dess datapunkter. Att anropa [IChart::set_HasLegend](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_haslegend/) med `false` döljer däremot hela förklaringen.

Exemplet nedan skapar ett staplat kolumndiagram med flera serier med standarddata. Det döljer den andra seriens förklaringsobjekt (index `1`) och sparar presentationen. Det återställer sedan objektet genom att anropa `set_Hide` med `false` och sparar en andra kopia. Kolumnerna förblir synliga i båda filerna.

```cpp
#include <system/shared_ptr.h>
#include <DOM/Presentation.h>
#include <DOM/ISlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Chart/ChartType.h>
#include <DOM/IChart.h>
#include <DOM/Chart/ILegend.h>
#include <DOM/Chart/ILegendEntryProperties.h>
#include <DOM/Chart/IChartData.h>
#include <DOM/Chart/IChartSeriesCollection.h>
#include <DOM/Chart/IChartSeries.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50, 50, 600, 400);
chart->set_HasLegend(true);

auto legendEntry = chart->get_ChartData()->get_Series()->idx_get(1)->get_RelatedLegendEntry();

legendEntry->set_Hide(true);
presentation->Save(u"hidden_legend_entry.pptx", SaveFormat::Pptx);

// Återställ samma post utan att ändra diagramdata.
legendEntry->set_Hide(false);
presentation->Save(u"restored_legend_entry.pptx", SaveFormat::Pptx);
```

Jämförelsen nedan visar samma diagram med alla objekt synliga och med det andra objektet dolt. Den andra seriens kolumner förblir oförändrade.

![Jämförelse av ett diagram med alla förklaringsobjekt synliga och med Serie 2 dold från förklaringen; alla kolumner förblir synliga.](hide-legend-entry.png)

I kolumn-, stapel- och linjediagram identifierar förklaringsobjekt serier. För cirkeldiagram identifierar de enskilda datapunkter (skivor), så använd [IChartDataPoint::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_relatedlegendentry/) på den valda skivan istället. API:et dokumenterar denna datapunktmetod för diagramtyperna `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` och `BarOfPie`. Anta inte att den gäller för donutdiagram, som inte ingår i den listan.

## **FAQ**

**Kan jag få diagrammet att reservera utrymme för förklaringen istället för att överlappa den?**

Ja. Anropa [set_Overlay](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_overlay/) med `false` för att reservera utrymme för förklaringen istället för att låta den överlappa plotområdet.

**Kan jag skapa flerradiga förklaringsetiketter?**

Ja. Långa etiketter kan radbrytas när den tillgängliga bredden är otillräcklig. Du kan också använda nyradstecken i serienamn för att begära radbrytningar.

**Hur får jag förklaringen att följa presentationens färgschema?**

Lämna förklaringens färger, fyllningar och typsnitt oinställda så att den kan ärva temats formatering. Explicit formatering åsidosätter motsvarande temainställningar.