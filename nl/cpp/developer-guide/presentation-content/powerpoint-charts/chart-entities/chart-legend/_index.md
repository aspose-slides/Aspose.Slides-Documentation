---
title: "Diagramlegenda's aanpassen in presentaties met C++"
linktitle: "Diagramlegenda"
type: docs
url: /nl/cpp/chart-legend/
keywords:
- diagramlegenda
- positie van legenda
- lettergrootte
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Pas diagramlegenda's aan met Aspose.Slides voor C++ om PowerPoint‑presentaties te optimaliseren met op maat gemaakte legenda‑opmaak."
---
## **Overzicht**

Aspose.Slides for C++ biedt opties om legenda’s van diagrammen in PowerPoint‑presentaties aan te passen. In dit artikel wordt getoond hoe u een legenda positioneert en van grootte wijzigt, hoe u de lettergrootte voor de gehele legenda instelt, hoe u een individuele legende‑vermelding opmaakt en hoe u geselecteerde vermeldingen verbergt of herstelt.

De FAQ behandelt gerelateerde functionaliteit, waaronder het reserveren van ruimte voor de legenda, het weergeven van labels over meerdere regels en het overnemen van opmaak van het presentatiethema.

## **Positionering van de legenda**

Gebruik de methoden van de legenda [set_X](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_x/), [set_Y](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_y/), [set_Width](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_width/) en [set_Height](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_height/) om de positie en grootte als fracties van de afmetingen van het diagram op te geven.

Dit voorbeeld maakt een presentatie aan en voegt een gegroepeerd kolomdiagram met standaardgegevens toe aan de eerste dia. Door de gewenste offsets en afmetingen van de legenda te delen door de breedte en hoogte van het diagram, worden ze omgezet naar relatieve waarden: de legenda wordt 50 punten verplaatst vanaf de linkerbovenhoek van het diagram en krijgt een grootte van 100 × 100 punten.

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

// Geef de positie en grootte van de legenda weer ten opzichte van het diagram.
chart->get_Legend()->set_X(50 / chart->get_Width());
chart->get_Legend()->set_Y(50 / chart->get_Height());
chart->get_Legend()->set_Width(100 / chart->get_Width());
chart->get_Legend()->set_Height(100 / chart->get_Height());

presentation->Save(u"legend_position.pptx", SaveFormat::Pptx);
```

## **Lettergrootte van een legenda instellen**

Gebruik de [get_TextFormat](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_textformat/) van de legenda om toegang te krijgen tot de tekstopmaak en gebruik [set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/baseportionformat/set_fontheight/) om de lettergrootte in punten in te stellen.

Dit voorbeeld maakt een diagram met standaardgegevens en stelt de legende‑tekst in op 20 punten. Het schakelt ook automatische grenzen voor de verticale as uit en stelt het bereik in op -5 tot 10.

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

## **Lettergrootte van een individuele legende‑vermelding instellen**

Gebruik de collectie die wordt geretourneerd door de [get_Entries](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/get_entries/)‑methode van de legenda om de opmaak van een specifieke vermelding te benaderen. Vermeldingsindices beginnen bij nul, dus index `1` verwijst naar de tweede vermelding.

Dit voorbeeld maakt een gegroepeerd kolomdiagram waarvan de standaardgegevens ten minste twee series bevatten. Het formatteert de tweede legende‑vermelding met vet, cursief en 20‑punt blauwe tekst.

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

## **Individuele legende‑vermeldingen verbergen**

Om een hulpreeks uit de legenda te verwijderen terwijl de gegevens zichtbaar blijven, roept u [ILegendEntryProperties::set_Hide](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ilegendentryproperties/set_hide/) aan met `true` via [IChartSeries::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartseries/get_relatedlegendentry/). Hiermee wordt alleen de geselecteerde legende‑vermelding verborgen; de reeks en haar gegevenspunten blijven bestaan. Het aanroepen van [IChart::set_HasLegend](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichart/set_haslegend/) met `false` daarentegen verbergt de gehele legenda.

Het onderstaande voorbeeld maakt een gegroepeerd kolomdiagram met meerdere reeksen op basis van standaardgegevens. Het verbergt de legende‑vermelding van de tweede reeks (index `1`) en slaat de presentatie op. Vervolgens wordt de vermelding hersteld door `set_Hide` met `false` aan te roepen en wordt een tweede kopie opgeslagen. De kolommen blijven in beide bestanden zichtbaar.

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

// Herstel dezelfde vermelding zonder de diagramgegevens te wijzigen.
legendEntry->set_Hide(false);
presentation->Save(u"restored_legend_entry.pptx", SaveFormat::Pptx);
```

De vergelijking hieronder toont hetzelfde diagram met alle vermeldingen zichtbaar en met de tweede vermelding verborgen. De kolommen van de tweede reeks blijven ongewijzigd.

![Vergelijking van een diagram met alle legende‑vermeldingen zichtbaar en met Serie 2 verborgen in de legenda; alle kolommen blijven zichtbaar.](hide-legend-entry.png)

In kolom‑, staaf‑ en lijndiagrammen identificeren legende‑vermeldingen reeksen. In cirkeldiagrammen identificeren ze individuele gegevenspunten (segmenten), dus gebruik [IChartDataPoint::get_RelatedLegendEntry](https://reference.aspose.com/slides/cpp/aspose.slides.charts/ichartdatapoint/get_relatedlegendentry/) op het geselecteerde segment. De API-documentatie vermeldt deze methode voor de diagramtypen `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` en `BarOfPie`. Neem niet aan dat dit geldt voor donut‑diagrammen, die niet in die lijst staan.

## **FAQ**

**Kan ik het diagram laten ruimte reserveren voor de legenda in plaats van deze te overlappen?**

Ja. Roep [set_Overlay](https://reference.aspose.com/slides/cpp/aspose.slides.charts/legend/set_overlay/) aan met `false` om ruimte voor de legenda te reserveren in plaats van deze te laten overlappen met het plotgebied.

**Kan ik legendalabels over meerdere regels weergeven?**

Ja. Lange labels kunnen worden afgebroken wanneer de beschikbare breedte onvoldoende is. U kunt ook regeleindetekens in reeksnamen gebruiken om expliciet een regeleinde af te dwingen.

**Hoe laat ik de legenda het kleurenpalet van het presentatiethema volgen?**

Laat de kleuren, opvullingen en lettertypen van de legenda oningesteld zodat ze de themavormgeving kunnen overnemen. Expliciete opmaak overschrijft de overeenkomstige themainstellingen.