---
title: Presentatieweergave‑eigenschappen ophalen en bijwerken in C++
linktitle: Weergave‑eigenschappen
type: docs
weight: 80
url: /nl/cpp/presentation-view-properties/
keywords:
- weergave‑eigenschappen
- normale weergave
- inhoud van overzicht
- overzichtspictogrammen
- verticale splitter vastklikken
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
description: Gebruik Aspose.Slides voor C++ om de lay-out van de normale weergave, de zoom van dia's en notities, de rasterafstand en de zichtbaarheid van opmerkingen in PowerPoint‑presentaties te configureren.
---
## **Inleiding**

In de normale weergave van PowerPoint wordt de dia weergegeven tussen een zijpaneel voor miniaturen of een overzicht en een notitiepaneel beneden. Aspose.Slides voor C++ maakt de opgeslagen bewerkingsvoorkeuren van de presentatie beschikbaar via [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/). Deze omvatten de paneelindeling, zoomniveaus, rasterafstand en zichtbaarheid van opmerkingen.

## **Over INormalViewProperties**

Gebruik [get_NormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) om de [INormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/) interface te benaderen. [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) bepaalt of pictogrammen verschijnen naast diatitel in het overzicht. [set_SnapVerticalSplitter](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_snapverticalsplitter/) zorgt ervoor dat het zijpaneel naar zijn geminimaliseerde toestand knipt wanneer de gebruiker het vernauwt. [set_PreferSingleView](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_prefersingleview/) geeft een voorkeur aan om één paneel in het volledige venster weer te geven.

[set_VerticalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_verticalbarstate/) regelt de scheidingslijn tussen het zijpaneel en de dia. [set_HorizontalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_horizontalbarstate/) regelt de scheidingslijn boven het notitiepaneel. Beide accepteren een [SplitterBarStateType](https://reference.aspose.com/slides/cpp/aspose.slides/splitterbarstatetype/) waarde van `Minimized`, `Maximized` of `Restored`.

## **Over het herstellen van INormalViewProperties**

Wanneer een scheidingslijn wordt hersteld, levert [get_RestoredLeft](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredleft/) de opgeslagen grootte van het zijpaneel en levert [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) de opgeslagen grootte van het bovenste dia‑gebied. Beide geven toegang tot [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/). De [set_DimensionSize](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_dimensionsize/) methode accepteert een percentage van 0 tot 100, en [set_AutoAdjust](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_autoadjust/) bepaalt of de editor de grootte aanpast wanneer het venster wordt gewijzigd.

Dit voorbeeld werkt een bestaande presentatie bij. Het herstelt de horizontale scheidingslijn, stelt de grootte van het bovenste dia‑gebied die wordt blootgesteld door [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) in op 80% met automatische aanpassing ingeschakeld, en maximaliseert de verticale scheidingslijn. Het schakelt ook overzichtspictogrammen in met [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) voor de overzichtsweergave.

```cpp
#include <DOM/INormalViewProperties.h>
#include <DOM/INormalViewRestoredProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <DOM/SplitterBarStateType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto normalView = presentation->get_ViewProperties()->get_NormalViewProperties();
normalView->set_HorizontalBarState(SplitterBarStateType::Restored);
normalView->set_VerticalBarState(SplitterBarStateType::Maximized);
auto restoredTop = normalView->get_RestoredTop();
restoredTop->set_AutoAdjust(true);
restoredTop->set_DimensionSize(80.0f);
normalView->set_ShowOutlineIcons(true);

presentation->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Stel de standaard zoomwaarde in**

[get_SlideViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_slideviewproperties/) en [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_notesviewproperties/) bewaren onafhankelijke zoominstellingen voor de editor. Deze instellingen hebben geen invloed op de afmetingen van de dia, de weergave van de diavoorstelling, of de resolutie bij export naar afbeeldingen.

Dit voorbeeld opent een bestaande presentatie en schakelt automatische schaalvergroting in met [set_VariableScale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_variablescale/) om de dia aan te passen aan het bewerkingsvenster. Voor de notitiepagina schakelt het automatische schaalvergroting uit en gebruikt [set_Scale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_scale/) om een vaste zoom van 80% in te stellen.

```cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
viewProperties->get_SlideViewProperties()->set_VariableScale(true);
auto notesView = viewProperties->get_NotesViewProperties();
notesView->set_VariableScale(false);
notesView->set_Scale(80);

presentation->Save(u"zoom.pptx", SaveFormat::Pptx);
```

## **Stel de rasterafstand in**

[set_GridSpacing](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_gridspacing/) stelt de afstand tussen bewerkingsrasterlijnen in de gehele presentatie in. Het neemt een positieve waarde in punten, met 72 punten per inch. Dit voorbeeld geeft de huidige afstand weer in een bestaande presentatie en slaat een kwart‑inch raster op door het interval op 18 punten te zetten.

```cpp
#include <system/console.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

auto viewProperties = presentation->get_ViewProperties();
auto gridSpacing = viewProperties->get_GridSpacing();
System::Console::WriteLine(u"Current grid spacing: {0} points", gridSpacing);

viewProperties->set_GridSpacing(18.0f);

presentation->Save(u"grid-spacing.pptx", SaveFormat::Pptx);
```

Het raster herhaalt zich met een vaste interval. [Tekengidsen](/slides/nl/cpp/drawing-guides/) markeren individuele horizontale of verticale posities. Beide zijn hulpmiddelen bij het bewerken en verschijnen alleen in editors die ze tonen. Diavoorstellingen en export naar PDF, afbeeldingen of SVG laten ze weg.

## **Toon of verberg opmerkingen bij het openen van een presentatie**

[set_ShowComments](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_showcomments/) slaat een voorkeur op die compatibele editors gebruiken bij het openen van de presentatie. Voor een bestaande presentatie met opmerkingen geeft dit voorbeeld de huidige instelling weer en slaat een kopie op met verborgen opmerkingen. Het roept ook [set_LastView](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_lastview/) aan met [ViewType::SlideView](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/) zodat de kopie wordt geopend in diaweergave.

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

auto viewProperties = presentation->get_ViewProperties();
auto showComments = viewProperties->get_ShowComments();
System::Console::WriteLine(u"Current comment visibility: {0}", showComments);

viewProperties->set_ShowComments(NullableBool::False);
viewProperties->set_LastView(ViewType::SlideView);

presentation->Save(u"comments-hidden.pptx", SaveFormat::Pptx);
```

Het verbergen van opmerkingen behoudt hun tekst, auteurs, posities, antwoorden en statussen. Om de opmerkingen zelf te wijzigen, zie [Presentatie-opmerkingen](/slides/nl/cpp/presentation-comments/). Exportinstellingen bepalen of opmerkingen verschijnen in PDF, HTML, afbeeldingen, notities of hand‑outs.

## **FAQ**

**Waarom is het raster verborgen wanneer ik de presentatie opnieuw open?**  
De presentatie slaat het rasterinterval op. Om het raster te zien, schakel de rasterzichtbaarheid in de editor in.

**Verandert het verwijderen van tekengidsen de rasterafstand?**  
Nee. Het toevoegen, verplaatsen of verwijderen van een gids laat het rasterinterval ongewijzigd.

**Kunnen verschillende secties van een presentatie verschillende weergave‑instellingen hebben?**  
Nee. [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) geldt voor de gehele presentatie.

**Kan ik verschillende weergave‑instellingen opslaan voor verschillende gebruikers?**  
Het bestand slaat één set weergave‑eigenschappen op voor iedereen. Een editor kan tevens de lokale voorkeuren van een gebruiker toepassen.

**Kan ik weergave‑instellingen opslaan in een sjabloon?**  
Ja. Presentaties die vanuit het sjabloon worden gemaakt, erven de daarin opgeslagen weergave‑instellingen.