---
title: "Presentatie‑weergave‑eigenschappen ophalen en bijwerken in C++"
linktitle: "Weergave‑eigenschappen"
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
description: "Ontdek de weergave‑eigenschappen van Aspose.Slides voor C++ om PPT-, PPTX- en ODP‑dia's aan te passen—layout, zoomniveaus en weergave‑instellingen wijzigen."
---
## **Inleiding**

De normale weergave bestaat uit drie inhoudsgebieden: de dia zelf, een zijinhoudsgebied en een onderinhoudsgebied. Eigenschappen die betrekking hebben op de positionering van de verschillende inhoudsgebieden. Deze informatie stelt de applicatie in staat om de weergavestatus op te slaan in het bestand, zodat bij het opnieuw openen de weergave zich in dezelfde staat bevindt als toen de presentatie voor het laatst werd opgeslagen.

Methode [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) is toegevoegd om toegang te bieden tot de normale weergave‑eigenschappen van een presentatie.  

[INormalViewProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/inormalviewrestoredproperties/) interfaces en hun afstammelingen, [SplitterBarStateType](https://reference.aspose.com/slides/nl/cpp/aspose.slides/splitterbarstatetype/)‑enum zijn toegevoegd.

## **Over INormalViewProperties**

Stelt de normale weergave‑eigenschappen voor.

Eigenschap **ShowOutlineIcons** geeft aan of de applicatie pictogrammen moet tonen bij het weergeven van de outline‑inhoud in een van de inhoudsgebieden van de normale weergavemodus.

Eigenschap **SnapVerticalSplitter** geeft aan of de verticale splitter naar een geminimaliseerde toestand moet springen wanneer het zijgebied voldoende klein is.

Eigenschap **PreferSingleView** geeft aan of de gebruiker de voorkeur geeft aan een enkel‑inhoudsgebied over de volledige vensterbreedte in plaats van de standaard normale weergave met drie inhoudsgebieden. Indien ingeschakeld, kan de applicatie ervoor kiezen om één van de inhoudsgebieden over het hele venster weer te geven.

Eigenschappen **VerticalBarState** en **HorizontalBarState** geven de toestand aan waarin de verticale of horizontale splitterbalk moet worden getoond. Een horizontale splitterbalk scheidt de dia van het inhoudsgebied onder de dia; een verticale splitterbalk scheidt de dia van het zij‑inhoudsgebied. Mogelijke waarden zijn: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** en **SplitterBarStateType.Restored**.

Eigenschappen **RestoredLeft** en **RestoredTop** geven de afmetingen van respectievelijk het boven‑ of zij‑dia‑gebied van de normale weergave wanneer de waarde **SplitterBarStateType.Restored** wordt toegepast op **VerticalBarState** en **HorizontalBarState**.

## **Over het herstellen van INormalViewProperties**

Geeft de afmetingen van het dia‑gebied (breedte wanneer een kind van RestoredTop, hoogte wanneer een kind van RestoredLeft) van de normale weergave weer, wanneer het gebied een variabele herstelde grootte heeft (noch geminimaliseerd, noch gemaximaliseerd).  

Eigenschap **DimensionSize** geeft de grootte van het dia‑gebied (breedte wanneer een kind van RestoredTop, hoogte wanneer een kind van RestoredLeft) aan.  

Eigenschap **AutoAdjust** geeft aan of de grootte van het zij‑inhoudsgebied moet worden aangepast aan de nieuwe grootte bij het wijzigen van de grootte van het venster dat de weergave bevat binnen de applicatie.

Een voorbeeld hieronder laat zien hoe u toegang krijgt tot de **ViewProperties.NormalViewProperties**‑eigenschappen voor een presentatie.

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

// Herstel de weergave-eigenschappen van de presentatie
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Standaardzoomwaarde instellen**

Aspose.Slides voor C++ ondersteunt nu het instellen van de standaard zoom‑waarde voor een presentatie, zodat de zoom al is ingesteld wanneer de presentatie wordt geopend. Dit kan worden gedaan door de [ViewProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/viewproperties/) van een presentatie in te stellen. Dia‑weergave‑eigenschappen evenals [get_NotesViewProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/viewproperties/get_notesviewproperties/) kunnen programmatisch worden ingesteld. In dit onderwerp laten we met een voorbeeld zien hoe de weergave‑eigenschappen van een presentatie in Aspose.Slides kunnen worden ingesteld.

Om de weergave‑eigenschappen in te stellen, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse
1. Stel de weergave‑[Properties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/viewproperties/) van de presentatie in
1. Schrijf de presentatie weg als een PPTX‑bestand

In het onderstaande voorbeeld hebben we de zoomwaarde voor zowel de dia‑weergave als de notitie‑weergave ingesteld.

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Instellen van de weergave-eigenschappen van de presentatie
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Zoomwaarde in procenten voor diavoorstelling
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Zoomwaarde in procenten voor notitie-weergave

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **Rasterafstand instellen**

Gebruik [Presentation::get_ViewProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_viewproperties/) om de weergave‑instellingen voor de hele presentatie te benaderen. De methoden [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iviewproperties/get_gridspacing/) en [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iviewproperties/set_gridspacing/) lezen of wijzigen het interval van het onderliggende bewerkingsraster. Deze instelling geldt voor de volledige presentatie, niet voor een enkele dia. Rasterafstand wordt opgegeven in punten, waarbij 72 punten gelijk zijn aan één inch. Gebruik een positieve waarde, zoals vereist in de API‑documentatie.

Het volgende voorbeeld opent een bestaande `demo.pptx`, toont de huidige rasterafstand, stelt een kwart‑inch‑interval in en slaat het resultaat op.

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

Het raster verschilt van [drawing guides](/slides/nl/cpp/drawing-guides/). Rasterafstand regelt een regelmatig interval, terwijl teken‑gidsen individuele horizontale of verticale uitlijningslijnen zijn. Het toevoegen, verplaatsen of wissen van teken‑gidsen verandert de rasterafstand niet.

Zowel het raster als de teken‑gidsen zijn hulpmiddelen voor bewerking. Ze worden niet gerenderd als dia‑inhoud in PDF, afbeeldingen, SVG of een diavoorstelling. Het opslaan van de rasterafstand garandeert niet dat een editor het raster weergeeft: de zichtbaarheid hangt ook af van de voorkeuren van de viewer of editor.

## **Commentaren tonen of verbergen bij het openen van een presentatie**

Gebruik [Presentation::get_ViewProperties](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_viewproperties/) om de weergave‑instellingen voor de hele presentatie te benaderen. Gebruik [IViewProperties::get_ShowComments](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iviewproperties/get_showcomments/) en [IViewProperties::set_ShowComments](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iviewproperties/set_showcomments/) om een voorkeur op te slaan voor het al dan niet tonen van commentaren wanneer de presentatie wordt geopend in PowerPoint of een andere compatibele editor.

Deze instelling regelt alleen de opgeslagen weergave‑voorkeur. Het voegt geen commentaren toe, verwijdert ze, wijzigt ze of lost ze op. Het verbergen van commentaren behoudt hun inhoud, auteurs, posities, antwoorden en statussen. Zie [Presentation Comments](/slides/nl/cpp/presentation-comments/) voor bewerkingen die de commentaren zelf wijzigen.

Het volgende voorbeeld vereist een bestaande `comments.pptx` met commentaren. Het toont de huidige zichtbaarheid, vraagt om commentaren te verbergen en slaat een nieuwe PPTX op zonder commentaren te verwijderen. Het gebruikt tevens [IViewProperties::set_LastView](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iviewproperties/set_lastview/) met [ViewType::SlideView](https://reference.aspose.com/slides/nl/cpp/aspose.slides/viewtype/) om de initiële bewerkingsweergave naast de commentaar‑zichtbaarheid te configureren.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <ViewType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"comments.pptx");
auto showComments = presentation->get_ViewProperties()->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

presentation->get_ViewProperties()->set_ShowComments(NullableBool::False);
presentation->get_ViewProperties()->set_LastView(ViewType::SlideView);
presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

Deze instelling bepaalt niet of commentaren worden meegenomen in PDF-, HTML-, afbeelding-, notities‑ of handout‑exporten. Configureer de export‑specifieke opties afzonderlijk.

## **FAQ**

**Waarom is het raster niet zichtbaar nadat ik de presentatie opnieuw heb geopend?**

Het bestand slaat de rasterafstand op, maar de editor bepaalt of het raster wordt weergegeven. Controleer de raster‑zichtbaarheidsinstellingen van de editor.

**Verandert het wissen van teken‑gidsen de rasterafstand?**

Nee. Teken‑gidsen en rasterafstand zijn onafhankelijke instellingen. Het wissen van gidsen laat het opgeslagen rasterinterval ongewijzigd.

**Kan ik verschillende weergave‑instellingen definiëren voor verschillende secties van een presentatie?**

[Weergave‑instellingen](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_viewproperties/) worden gedefinieerd op presentatieniveau ([Normal View](https://reference.aspose.com/slides/nl/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/nl/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), niet per sectie, dus een enkele set parameters geldt voor het hele document bij het openen.

**Kan ik vooraf verschillende weergave‑toestanden definiëren voor verschillende gebruikers?**

Nee. De instellingen worden in het bestand opgeslagen en gedeeld. Viewer‑applicaties kunnen gebruikersvoorkeuren respecteren, maar het bestand zelf bevat één set weergave‑eigenschappen.

**Kan ik een sjabloon voorbereiden met vooraf gedefinieerde weergave‑eigenschappen zodat nieuwe presentaties op dezelfde manier openen?**

Ja. Omdat [weergave‑eigenschappen](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/get_viewproperties/) op presentatieniveau worden opgeslagen, kunt u ze in een sjabloon opnemen en vervolgens nieuwe documenten vanuit die sjabloon maken met dezelfde initiële weergave‑configuratie.