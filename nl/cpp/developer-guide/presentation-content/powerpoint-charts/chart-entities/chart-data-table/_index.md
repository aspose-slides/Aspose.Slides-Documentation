---
title: Grafiekgegevens-tabellen aanpassen in presentaties met C++
linktitle: Gegevenstabel
type: docs
url: /nl/cpp/chart-data-table/
keywords:
- grafiekgegevens
- tabel
- lettertype-eigenschappen
- PowerPoint
- presentatie
- C++
- Aspose.Slides
description: "Pas lettertypen, randen en legendasleutels van grafiekgegevens-tabellen aan in PowerPoint-presentaties met Aspose.Slides voor C++."
---
## **Overzicht**

Aspose.Slides for C++ stelt u in staat een gegevens-tabel van een diagram weer te geven en de tekstopmaak, randen en legenda-sleutels aan te passen. Dit artikel legt uit hoe u de tabel inschakelt, de tekst formatteert, elk type rand regelt en legenda-sleutels toont of verbergt. De voorbeelden slaan de geconfigureerde diagrammen op in PPTX-bestanden.

## **Lettertype-eigenschappen instellen**

Om een gegevens-tabel van een diagram weer te geven, geeft u `true` door aan [IChart::set_HasDataTable](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichart/set_hasdatatable/). Gebruik [IChart::get_ChartDataTable](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichart/get_chartdatatable/) om toegang te krijgen tot de tabel en de tekstopmaak te configureren.

1. Laad de presentatie met de klasse [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/).
1. Voeg een gegroepeerde kolomdiagram toe aan de eerste dia.
1. Schakel de gegevens-tabel van het diagram in.
1. Schakel vetgedrukte tekst in met [IBasePortionFormat::set_FontBold](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseportionformat/set_fontbold/) en geef `20` door aan [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibaseportionformat/set_fontheight/) voor tekst van 20 punten.
1. Sla de gewijzigde presentatie op.

Het volgende voorbeeld vereist `test.pptx` in de werkmap met minstens één dia. Het voegt een diagram met standaardgegevens toe op positie (50, 50), met een breedte van 600 punten en een hoogte van 400 punten. Het opgeslagen `output.pptx` bevat het diagram met de gegevens-tabel ingeschakeld en de opgegeven lettertype-instellingen toegepast.

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

## **Randen van de gegevens-tabel aanpassen**

Schakel de tabel in met [IChart::set_HasDataTable](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichart/set_hasdatatable/) en krijg er toegang tot via [IChart::get_ChartDataTable](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichart/get_chartdatatable/). U kunt drie soorten randen onafhankelijk regelen:

- [IDataTable::set_HasBorderHorizontal](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/idatatable/set_hasborderhorizontal/) regelt de horizontale celranden.
- [IDataTable::set_HasBorderVertical](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/idatatable/set_hasbordervertical/) regelt de verticale celranden.
- [IDataTable::set_HasBorderOutline](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/idatatable/set_hasborderoutline/) regelt de buitenrand van de tabel.

Geef `true` door aan elke setter om de randen weer te geven of `false` om ze te verbergen. Het volgende voorbeeld maakt een gegroepeerde kolomdiagram met standaardgegevens, toont horizontale randen en de buitenrand, en verbergt verticale randen. Het vereist geen invoerbestand. De positie en grootte van het diagram worden opgegeven in punten.

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

De onderstaande vergelijking gebruikt dezelfde diagramgegevens en legendasleutelinstelling in alle vier de gevallen. Beginnend met alle randen ingeschakeld, schakelt elke resterende variant precies één randinstelling uit. De variant links-onder komt overeen met de randinstellingen in het voorbeeld.

![Diagram-gegevens-tabellen met alle randen ingeschakeld, geen horizontale randen, geen verticale randen en geen buitenrand](data-table-borders.png)

## **Legenda-sleutels weergeven of verbergen**

Legenda-sleutels zijn kleine gekleurde markeringen naast de serienaam in de gegevens-tabel. Ze helpen lezers elke tabelrij te koppelen aan een diagramserie. Geef `true` door aan [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/idatatable/set_showlegendkey/) om deze markeringen weer te geven of `false` om ze te verbergen.

De afzonderlijke legenda van het diagram wordt geregeld via [IChart::set_HasLegend](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichart/set_haslegend/). Deze instellingen zijn onafhankelijk: het verbergen van de afzonderlijke legenda verbergt de sleutels in de gegevens-tabel niet, en het verbergen van de sleutels in de tabel verbergt de afzonderlijke legenda niet.

Het volgende voorbeeld maakt een diagram met standaardgegevens, schakelt de gegevens-tabel in en toont legendasleutels erin terwijl de afzonderlijke legenda verborgen blijft. Alle tabelranden worden expliciet ingeschakeld. Er is geen invoerpresentatie vereist. Om alleen de sleutels van de tabel te verbergen, geeft u `false` door aan [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/idatatable/set_showlegendkey/).

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

De onderstaande vergelijking toont dezelfde tabel met legendasleutels ingeschakeld en uitgeschakeld. Alle randen blijven ingeschakeld, en de afzonderlijke diagramlegenda is in beide gevallen verborgen.

![Diagram-gegevens-tabellen met legendasleutels links weergegeven en rechts verborgen](data-table-legend-keys.png)

## **Veelgestelde vragen**

**Kan ik legendasleutels in de gegevens-tabel van een diagram weergeven?**

Ja. Geef `true` door aan [IDataTable::set_ShowLegendKey](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/idatatable/set_showlegendkey/), om legendasleutels weer te geven, of `false` om ze te verbergen.

**Wordt de gegevens-tabel bewaard bij het exporteren van de presentatie naar PDF, HTML of afbeeldingen?**

Ja. Aspose.Slides rendert het diagram en de weergegeven gegevens-tabel als onderdeel van de dia bij het exporteren naar [PDF](/slides/nl/cpp/convert-powerpoint-to-pdf/), [HTML](/slides/nl/cpp/convert-powerpoint-to-html/) of [afbeeldingen](/slides/nl/cpp/convert-powerpoint-to-png/).

**Kan ik werken met gegevens-tabellen in diagrammen die uit een sjabloon zijn geladen?**

Ja. Voor een diagram dat uit een bestaande presentatie of sjabloon is geladen, gebruikt u [IChart::get_HasDataTable](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichart/get_hasdatatable/) om te controleren of de gegevens-tabel wordt weergegeven, en [IChart::set_HasDataTable](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichart/set_hasdatatable/) om de zichtbaarheid te wijzigen.

**Hoe kan ik diagrammen vinden die een ingeschakelde gegevens-tabel hebben?**

Itereer door de vormen op elke dia, identificeer de diagrammen en controleer hun resultaat van [IChart::get_HasDataTable](https://reference.aspose.com/slides/nl/cpp/aspose.slides.charts/ichart/get_hasdatatable/). Een waarde van `true` geeft aan dat de gegevens-tabel is ingeschakeld.