---
title: Hämta och uppdatera presentationsvyegenskaper i C++
linktitle: Vyegenskaper
type: docs
weight: 80
url: /sv/cpp/presentation-view-properties/
keywords:
- vyegenskaper
- normalvy
- dispositionsinnehåll
- dispositionsikoner
- fäst vertikal delare
- enkelvy
- stapeltillstånd
- dimensionstorlek
- automatisk justering
- standardzoom
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Använd Aspose.Slides för C++ för att konfigurera normalvylayout, zoom för bild och anteckningar, rutnätsavstånd samt kommentarers synlighet i PowerPoint-presentationer."
---
## **Introduktion**

I PowerPoints normala vy visas bilden mellan en sidopanel för miniatyrbilder eller en disposition och en anteckningspanel under. Aspose.Slides för C++ exponerar presentationens sparade redigeringsinställningar via [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/). Dessa inkluderar panelens layout, zoomnivåer, rutnätavstånd och kommentarers synlighet.

## **Om INormalViewProperties**

Använd [get_NormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) för att komma åt [INormalViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/)‑gränssnittet. [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) styr om ikoner visas bredvid bildtitlar i dispositionen. [set_SnapVerticalSplitter](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_snapverticalsplitter/) låter sidopanelen fästa sig i sitt minimerade tillstånd när användaren minskar den. [set_PreferSingleView](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_prefersingleview/) indikerar en preferens för att visa en panel i hela fönstret.

[set_VerticalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_verticalbarstate/) styr delaren mellan sidopanelen och bilden. [set_HorizontalBarState](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_horizontalbarstate/) styr delaren ovanför anteckningspanelen. Båda accepterar ett [SplitterBarStateType](https://reference.aspose.com/slides/cpp/aspose.slides/splitterbarstatetype/)‑värde av `Minimized`, `Maximized` eller `Restored`.

## **Om återställning av INormalViewProperties**

När en delare återställs levererar [get_RestoredLeft](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredleft/) den sparade storleken på sidopanelen och [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) den sparade storleken på det övre bildområdet. Båda exponerar [INormalViewRestoredProperties](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/). Dess [set_DimensionSize](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_dimensionsize/)‑metod accepterar en procentandel från 0 till 100, och [set_AutoAdjust](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewrestoredproperties/set_autoadjust/) styr om redigeraren justerar storleken när fönstret ändras i storlek.

Detta exempel uppdaterar en befintlig presentation. Det återställer den horisontella delaren, sätter storleken på det övre bildområdet som exponeras av [get_RestoredTop](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/get_restoredtop/) till 80% med automatisk justering aktiverad, och maximerar den vertikala delaren. Det aktiverar också dispositionsikoner med [set_ShowOutlineIcons](https://reference.aspose.com/slides/cpp/aspose.slides/inormalviewproperties/set_showoutlineicons/) för dispositionsvyn.

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
## **Ställ in standardzoomvärdet**

[get_SlideViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_slideviewproperties/) och [get_NotesViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/get_notesviewproperties/) lagrar oberoende zoominställningar för redigeraren. Dessa inställningar påverkar inte bildstorlekar, bildspelsuppspelning eller bildexportupplösning.

Detta exempel öppnar en befintlig presentation och möjliggör automatisk skalning med [set_VariableScale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_variablescale/) för att anpassa bilden till redigeringsfönstret. För anteckningssidan inaktiveras automatisk skalning och [set_Scale](https://reference.aspose.com/slides/cpp/aspose.slides/icommonslideviewproperties/set_scale/) används för att sätta en fast zoom på 80%.

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
## **Ställ in rutnätsavståndet**

[set_GridSpacing](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_gridspacing/) anger avståndet mellan redigeringsrutnätslinjer i hela presentationen. Den tar ett positivt värde i punkter, med 72 punkter per tum. Detta exempel skriver ut det aktuella avståndet i en befintlig presentation och sparar ett fjärdedels tum stort rutnät genom att sätta intervallet till 18 punkter.

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
Rutnätet upprepas med ett fast intervall. [Ritningsguider](/slides/sv/cpp/drawing-guides/) markerar individuella horisontella eller vertikala positioner. Båda är hjälpmedel för redigering och visas endast i redigerare som visar dem. Bildspel och export till PDF, bilder eller SVG utelämnar dem.

## **Visa eller dölj kommentarer vid öppning av en presentation**

[set_ShowComments](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_showcomments/) lagrar en preferens som kompatibla redigerare använder när presentationen öppnas. För en befintlig presentation med kommentarer skriver detta exempel ut den aktuella inställningen och sparar en kopia med kommentarer dolda. Det anropar också [set_LastView](https://reference.aspose.com/slides/cpp/aspose.slides/iviewproperties/set_lastview/) med [ViewType::SlideView](https://reference.aspose.com/slides/cpp/aspose.slides/viewtype/) så att kopian öppnas i bildvyn.

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
Att dölja kommentarer bevarar deras text, författare, positioner, svar och status. För att ändra själva kommentarerna, se [Presentation kommentarer](/slides/sv/cpp/presentation-comments/). Exportinställningarna styr om kommentarer visas i PDF, HTML, bilder, anteckningar eller handouts.

## **Vanliga frågor**

**Varför är rutnätet dolt när jag öppnar presentationen igen?**  
Presentationen lagrar rutnätintervallet. För att se rutnätet, aktivera rutnätsvisning i redigeraren.

**Påverkar rensning av ritningsguider rutnätsavståndet?**  
Nej. Att lägga till, flytta eller rensa en guide lämnar rutnätintervallet oförändrat.

**Kan olika sektioner i en presentation ha olika vyinställningar?**  
Nej. [Presentation::get_ViewProperties](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/get_viewproperties/) gäller för hela presentationen.

**Kan jag spara olika vyinställningar för olika användare?**  
Filen lagrar en uppsättning vyegenskaper för alla. En redigerare kan också tillämpa en användares lokala preferenser.

**Kan jag spara vyinställningar i en mall?**  
Ja. Presentationer som skapas från mallen ärver dess sparade vyinställningar.