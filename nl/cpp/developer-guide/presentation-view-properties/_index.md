---
title: Presentatieweergave‑eigenschappen ophalen en bijwerken in C++
linktitle: Weergave‑eigenschappen
type: docs
weight: 80
url: /nl/cpp/presentation-view-properties/
keywords:
- weergave‑eigenschappen
- normale weergave
- outline‑inhoud
- outline‑pictogrammen
- verticale splitter vastzetten
- enkele weergave
- balkstatus
- dimensiegrootte
- automatisch aanpassen
- standaardzoom
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: Ontdek de weergave‑eigenschappen van Aspose.Slides voor C++ om PPT-, PPTX- en ODP‑dia's aan te passen - lay-outs, zoomniveaus en weergave‑instellingen te finetunen.
---
## **Inleiding**

De normale weergave bestaat uit drie inhoudsgebieden: de dia zelf, een zijinhoudsgebied en een onderste inhoudsgebied. Eigenschappen die betrekking hebben op de positionering van de verschillende inhoudsgebieden. Deze informatie stelt de applicatie in staat om de weergavestatus op te slaan in het bestand, zodat bij het heropenen de weergave in dezelfde staat is als toen de presentatie voor het laatst werd opgeslagen.

Methode [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) is toegevoegd om toegang te bieden tot de normale weergave‑eigenschappen van een presentatie. 

Interfaces [INormalViewProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/inormalviewrestoredproperties/) en hun afstammelingen, enum [SplitterBarStateType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/splitterbarstatetype/) zijn toegevoegd.

## **Over INormalViewProperties**

Stelt de normale weergave‑eigenschappen voor.

Eigenschap **ShowOutlineIcons** bepaalt of de applicatie pictogrammen moet tonen bij het weergeven van outline‑inhoud in een van de inhoudsgebieden van de normale weergavemodus.

Eigenschap **SnapVerticalSplitter** bepaalt of de verticale splitter naar een geminimaliseerde staat moet klikken wanneer het zijgebied voldoende klein is.

Eigenschap **PreferSingleView** bepaalt of de gebruiker de voorkeur geeft aan één inhoudsgebied over het volledige venster in plaats van de standaard normale weergave met drie inhoudsgebieden. Indien ingeschakeld, kan de applicatie ervoor kiezen om één van de inhoudsgebieden over het volledige venster weer te geven.

Eigenschappen **VerticalBarState** en **HorizontalBarState** bepalen in welke toestand de horizontale of verticale splitterbalk moet worden getoond. Een horizontale splitterbalk scheidt de dia van het inhoudsgebied onder de dia, een verticale splitterbalk scheidt de dia van het zij‑inhoudsgebied. Mogelijke waarden zijn: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** en **SplitterBarStateType.Restored**.

Eigenschappen **RestoredLeft** en **RestoredTop** bepalen de grootte van respectievelijk het boven‑ of zij‑dia‑gebied van de normale weergave, wanneer de waarde **SplitterBarStateType.Restored** wordt toegepast voor **VerticalBarState** en **HorizontalBarState**.

## **Over het herstellen van INormalViewProperties**

Bepaalt de grootte van het dia‑gebied (breedte wanneer een kind van RestoredTop, hoogte wanneer een kind van RestoredLeft) van de normale weergave, wanneer het gebied een variabele herstelde grootte heeft (niet geminimaliseerd of gemaximaliseerd). 

Eigenschap **DimensionSize** specificeert de grootte van het dia‑gebied (breedte wanneer een kind van RestoredTop, hoogte wanneer een kind van RestoredLeft).

Eigenschap **AutoAdjust** bepaalt of de grootte van het zij‑inhoudsgebied moet worden gecompenseerd voor de nieuwe grootte bij het aanpassen van het venster dat de weergave bevat binnen de applicatie.

Een voorbeeld hieronder laat zien hoe u **ViewProperties.NormalViewProperties**‑eigenschappen voor een presentatie kunt benaderen.

``` cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"demo.pptx");
pres->get_ViewProperties()->get_NormalViewProperties()->set_HorizontalBarState(SplitterBarStateType::Restored);
pres->get_ViewProperties()->get_NormalViewProperties()->set_VerticalBarState(SplitterBarStateType::Maximized);

// Herstel de weergave‑eigenschappen van de presentatie
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Standaardzoomwaarde instellen**

Aspose.Slides for C++ ondersteunt nu het instellen van de standaardzoomwaarde voor een presentatie, zodat bij het openen van de presentatie de zoom al is ingesteld. Dit kan worden gedaan door de [ViewProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/viewproperties/) van een presentatie in te stellen. Dia‑weergave‑eigenschappen evenals [get_NotesViewProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/viewproperties/get_notesviewproperties/) kunnen programmatisch worden ingesteld. In dit artikel laten we met een voorbeeld zien hoe de weergave‑eigenschappen van een presentatie in Aspose.Slides worden ingesteld.

Om de weergave‑eigenschappen in te stellen, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse
1. Stel de weergave‑[Properties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/viewproperties/) van de presentatie in
1. Schrijf de presentatie weg als een PPTX‑bestand

In het onderstaande voorbeeld hebben we de zoomwaarde ingesteld voor zowel de dia‑weergave als de notitie‑weergave.

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Instellen van de weergave‑eigenschappen van de presentatie
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Zoomwaarde in procenten voor de dia‑weergave
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Zoomwaarde in procenten voor notitie‑weergave 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **Rasterafstand instellen**

Gebruik [Presentation::get_ViewProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_viewproperties/) om toegang te krijgen tot de weergave‑instellingen die voor de hele presentatie gelden. De methoden [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iviewproperties/get_gridspacing/) en [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iviewproperties/set_gridspacing/) lezen of wijzigen het interval van het onderliggende bewerkingsraster. Deze instelling geldt voor de volledige presentatie, niet voor een individuele dia. Rasterafstand wordt gespecificeerd in points, waarbij 72 points overeenkomen met één inch. Gebruik een positieve waarde, zoals vereist door de API‑documentatie.

Het volgende voorbeeld opent een bestaande `demo.pptx`, toont de huidige rasterafstand, stelt een kwart‑inch‑interval in, en slaat het resultaat op.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");
auto gridSpacing = presentation->get_ViewProperties()->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

presentation->get_ViewProperties()->set_GridSpacing(18.0f);
presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

Het raster verschilt van [drawing guides](/slides/nl/cpp/drawing-guides/). Rasterafstand regelt een regelmatig interval, terwijl teken‑gidsen individuele horizontale of verticale uitlijningslijnen zijn. Het toevoegen, verplaatsen of verwijderen van teken‑gidsen verandert de rasterafstand niet.

Zowel het raster als de teken‑gidsen zijn hulpmiddelen voor bewerken. Ze worden niet gerenderd als dia‑inhoud in PDF, afbeeldingen, SVG of een diavoorstelling. Het opslaan van de rasterafstand garandeert niet dat een editor het raster weergeeft: de zichtbaarheid hangt ook af van de voorkeuren van de viewer of editor.

## **FAQ**

**Waarom is het raster niet zichtbaar nadat ik de presentatie opnieuw heb geopend?**

Het bestand slaat de rasterafstand op, maar de editor bepaalt of het raster wordt weergegeven. Controleer de raster‑zichtbaarheidsinstellingen van de editor.

**Verandert het verwijderen van teken‑gidsen de rasterafstand?**

Nee. Teken‑gidsen en rasterafstand zijn onafhankelijke instellingen. Het verwijderen van gidsen laat het opgeslagen rasterinterval onveranderd.

**Kan ik verschillende weergave‑instellingen definiëren voor verschillende secties van een presentatie?**

[View settings](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_viewproperties/) worden gedefinieerd op presentatieniveau ([Normal View](https://reference.aspose.com/slides/nl/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/nl/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), niet per sectie, waardoor één set parameters geldt voor het hele document bij het openen.

**Kan ik vooraf verschillende weergave‑staten definiëren voor verschillende gebruikers?**

Nee. De instellingen worden in het bestand opgeslagen en gedeeld. Viewer‑applicaties kunnen gebruikersvoorkeuren respecteren, maar het bestand zelf bevat één set weergave‑eigenschappen.

**Kan ik een sjabloon voorbereiden met vooraf gedefinieerde weergave‑eigenschappen zodat nieuwe presentaties op dezelfde manier openen?**

Ja. Omdat [view properties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_viewproperties/) worden opgeslagen op presentatieniveau, kunt u ze in een sjabloon opnemen en nieuwe documenten ervan maken met dezelfde initiële weergave‑configuratie.