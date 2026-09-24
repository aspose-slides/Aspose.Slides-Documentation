---
title: Anpassa diagramdatatabeller i presentationer med C++
linktitle: Datatabell
type: docs
url: /sv/cpp/chart-data-table/
keywords:
- diagramdata
- datatabell
- teckensnittsegenskaper
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Anpassa diagramdatatabellens teckensnitt, kanter och förklaringsnycklar i PowerPoint-presentationer med Aspose.Slides för C++."
---
## **Översikt**

Aspose.Slides för C++ låter dig visa ett diagrammets datatabell och anpassa dess textformatering, kanter och förklaringsnycklar. Denna artikel förklarar hur du aktiverar tabellen, formaterar dess text, kontrollerar varje kanttyp och visar eller döljer förklaringsnycklar. Exemplen sparar de konfigurerade diagrammen i PPTX-filer.

## **Ange teckensnittsegenskaper**

För att visa ett diagrammets datatabell, skicka `true` till [IChart::set_HasDataTable](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichart/set_hasdatatable/). Använd [IChart::get_ChartDataTable](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichart/get_chartdatatable/) för att komma åt tabellen och konfigurera dess textformatering.

1. Ladda presentationen med klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
1. Lägg till ett grupperat stapeldiagram på den första bilden.
1. Aktivera diagrammets datatabell.
1. Aktivera fet text med [IBasePortionFormat::set_FontBold](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibaseportionformat/set_fontbold/) och skicka `20` till [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibaseportionformat/set_fontheight/) för 20‑punkts text.
1. Spara den ändrade presentationen.

Följande exempel kräver `test.pptx` i arbetskatalogen med minst en bild. Det lägger till ett diagram med standarddata på position (50, 50), med en bredd på 600 punkter och en höjd på 400 punkter. Den sparade `output.pptx` innehåller diagrammet med dess datatabell aktiverad och de angivna teckensnittinställningarna tillämpade.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"test.pptx");
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto portionFormat = chart->get_ChartDataTable()->get_TextFormat()->get_PortionFormat();
portionFormat->set_FontBold(NullableBool::True);
portionFormat->set_FontHeight(20.0f);

presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Anpassa datatabellkanter**

Aktivera tabellen med [IChart::set_HasDataTable](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichart/set_hasdatatable/) och nå den via [IChart::get_ChartDataTable](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichart/get_chartdatatable/). Du kan kontrollera tre typer av kanter oberoende av varandra:

- [IDataTable::set_HasBorderHorizontal](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/idatatable/set_hasborderhorizontal/) kontrollerar horisontella cellkanter.
- [IDataTable::set_HasBorderVertical](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/idatatable/set_hasbordervertical/) kontrollerar vertikala cellkanter.
- [IDataTable::set_HasBorderOutline](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/idatatable/set_hasborderoutline/) kontrollerar tabellens yttre kant.

Skicka `true` till varje setter för att visa dess kanter eller `false` för att dölja dem. Följande exempel skapar ett grupperat stapeldiagram med standarddata, visar horisontella kanter och den yttre kanten samt döljer vertikala kanter. Det kräver ingen indatafil. Diagrammets position och storlek anges i punkter.

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(false);
dataTable->set_HasBorderOutline(true);

presentation->Save(u"data-table-borders.pptx", SaveFormat::Pptx);
```

![Diagramdatatabeller med alla kanter aktiverade, inga horisontella kanter, inga vertikala kanter och ingen yttre kant](data-table-borders.png)

## **Visa eller dölj förklaringsnycklar**

Förklaringsnycklar är små färgade markörer bredvid serienamnen i datatabellen. De hjälper läsaren att matcha varje tabellrad med en diagramserie. Skicka `true` till [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) för att visa dessa markörer eller `false` för att dölja dem.

Diagrammets separata förklaring styrs av [IChart::set_HasLegend](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichart/set_haslegend/). Dessa inställningar är oberoende: att dölja den separata förklaringen döljer inte nycklarna i datatabellen, och att dölja tabellens nycklar döljer inte den separata förklaringen.

Följande exempel skapar ett diagram med standarddata, aktiverar dess datatabell och visar förklaringsnycklar i den medan den separata förklaringen döljs. Alla tabellkanter är explicit aktiverade. Ingen indata­presentation krävs. För att bara dölja tabellens nycklar, skicka `false` till [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/idatatable/set_showlegendkey/).

```cpp
#include <DOM/Chart/ChartType.h>
#include <DOM/Chart/IChartPortionFormat.h>
#include <DOM/Chart/IChartTextFormat.h>
#include <DOM/Chart/IDataTable.h>
#include <DOM/IChart.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Charts;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto chart = slide->get_Shapes()->AddChart(ChartType::ClusteredColumn, 50.0f, 50.0f, 600.0f, 400.0f);
chart->set_HasDataTable(true);
chart->set_HasLegend(false);

auto dataTable = chart->get_ChartDataTable();
dataTable->set_HasBorderHorizontal(true);
dataTable->set_HasBorderVertical(true);
dataTable->set_HasBorderOutline(true);
dataTable->set_ShowLegendKey(true);

presentation->Save(u"data-table-legend-keys.pptx", SaveFormat::Pptx);
```

![Diagramdatatabeller med förklaringsnycklar visade till vänster och dolda till höger](data-table-legend-keys.png)

## **Vanliga frågor**

**Kan jag visa förklaringsnycklar i ett diagrammets datatabell?**

Ja. Skicka `true` till [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) för att visa förklaringsnycklar eller `false` för att dölja dem.

**Kommer datatabellen att bevaras när presentationen exporteras till PDF, HTML eller bilder?**

Ja. Aspose.Slides renderar diagrammet och dess visade datatabell som en del av bilden när den exporteras till [PDF](/slides/sv/cpp/convert-powerpoint-to-pdf/), [HTML](/slides/sv/cpp/convert-powerpoint-to-html/), eller [images](/slides/sv/cpp/convert-powerpoint-to-png/).

**Kan jag arbeta med datatabeller i diagram som laddats från en mall?**

Ja. För ett diagram som laddats från en befintlig presentation eller mall, använd [IChart::get_HasDataTable](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichart/get_hasdatatable/) för att kontrollera om dess datatabell visas och [IChart::set_HasDataTable](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichart/set_hasdatatable/) för att ändra dess synlighet.

**Hur kan jag hitta diagram som har en datatabell aktiverad?**

Iterera genom formerna på varje bild, identifiera diagrammen och kontrollera deras [IChart::get_HasDataTable](https://reference.aspose.com/slides/sv/cpp/aspose.slides.charts/ichart/get_hasdatatable/)-resultat. Ett värde på `true` indikerar att datatabellen är aktiverad.