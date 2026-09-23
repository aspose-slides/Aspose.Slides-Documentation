---
title: "Hämta och uppdatera vyegenskaper för presentation i C++"
linktitle: "Vyegenskaper"
type: docs
weight: 80
url: /sv/cpp/presentation-view-properties/
keywords:
- vyegenskaper
- normal vy
- dispositionsinnehåll
- dispositionsikoner
- fästa vertikal splitter
- ensam vy
- stapeltillstånd
- dimensionens storlek
- automatisk justering
- standardzoom
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Upptäck vyegenskaperna i Aspose.Slides för C++ för att anpassa PPT-, PPTX- och ODP‑presentationer – justera layouter, zoomnivåer och visningsinställningar."
---
## **Introduktion**

Normalvyn består av tre innehållsområden: själva bilden, ett sidoinnehållsområde och ett botteninnehållsområde. Egenskaper som rör positioneringen av de olika innehållsområdena. Denna information gör att applikationen kan spara vynet till filen, så att när den öppnas igen är vyn i samma tillstånd som när presentationen senast sparades.

Metoden [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) har lagts till för att ge åtkomst till normalvyns egenskaper för presentationen.

[INormalViewProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/inormalviewrestoredproperties/) gränssnitten och deras underklasser, [SplitterBarStateType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/splitterbarstatetype/)‑enum har lagts till.

## **Om INormalViewProperties**

Representerar normalvyns egenskaper.

Egendomen **ShowOutlineIcons** anger om applikationen ska visa ikoner när man visar dispositionens innehåll i något av innehållsområdena i normalvy.

Egendomen **SnapVerticalSplitter** anger om den vertikala splitterbaren ska fästas i ett minimerat tillstånd när sidoregionen är tillräckligt liten.

Egendomen **PreferSingleView** anger om användaren föredrar att se ett helfönster med ett enda innehållsområde istället för den vanliga normalvyn med tre innehållsområden. Om den är aktiverad kan applikationen välja att visa ett av innehållsområdena i hela fönstret.

Egendomarna **VerticalBarState** och **HorizontalBarState** anger i vilket tillstånd den horisontella respektive vertikala splitterbaren ska visas. En horisontell splitterbar separerar bilden från innehållsområdet under bilden, en vertikal splitterbar separerar bilden från sidoinnehållsområdet. Möjliga värden är: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** och **SplitterBarStateType.Restored**.

Egendomarna **RestoredLeft** och **RestoredTop** anger storleken på respektive top- eller sidoregion i normalvyn när värdet **SplitterBarStateType.Restored** har tillämpats på **VerticalBarState** respektive **HorizontalBarState**.

## **Om att återställa INormalViewProperties**

Anger storleken på bildregionen (bredd när den är ett underobjekt till RestoredTop, höjd när den är ett underobjekt till RestoredLeft) i normalvyn, när regionen har en variabel återställd storlek (varken minimerad eller maximerad).

Egendomen **DimensionSize** anger storleken på bildregionen (bredd när den är ett underobjekt till restoredTop, höjd när den är ett underobjekt till restoredLeft).

Egendomen **AutoAdjust** anger om storleken på sidoinnehållsområdet ska kompensera för den nya storleken när fönstret som innehåller vyn förstoras eller förminskas i applikationen.

Ett exempel nedan visar hur du kan komma åt egenskaperna för **ViewProperties.NormalViewProperties** för en presentation.

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

// Återställ vyegenskaperna för presentationen
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Ange standardzoomvärde**

Aspose.Slides för C++ stöder nu att ställa in standardzoomvärdet för en presentation så att när presentationen öppnas är zoomen redan inställd. Detta kan göras genom att sätta [ViewProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/viewproperties/) för en presentation. Bildvyeegenskaper samt [get_NotesViewProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/viewproperties/get_notesviewproperties/) kan ställas in programmässigt. I detta avsnitt ser vi med ett exempel hur man sätter View Properties för en presentation i Aspose.Slides.

För att ställa in vyeegenskaperna, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)
1. Ställ in View [Properties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/viewproperties/) för Presentation
1. Skriv presentationen som en PPTX‑fil

I exemplet nedan har vi ställt in zoomvärdet för bildvyn samt notvyn.

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Inställer vyegenskaperna för presentationen
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Zoomvärde i procent för bildvyn
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Zoomvärde i procent för notvyn 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **Ställ in rutnätets avstånd**

Använd [Presentation::get_ViewProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_viewproperties/) för att komma åt vyinställningar på presentationsnivå. Metoderna [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iviewproperties/get_gridspacing/) och [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iviewproperties/set_gridspacing/) läser eller ändrar intervallet för det underliggande redigeringsrutnätet. Denna inställning gäller för hela presentationen, inte för en enskild bild. Rutnätsavstånd anges i punkter, där 72 punkter motsvarar en tum. Använd ett positivt värde, enligt API-dokumentationen.

Följande exempel öppnar en befintlig `demo.pptx`, skriver ut dess aktuella rutnätsavstånd, sätter ett kvart-tumsintervall och sparar resultatet.

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

Rutnätet skiljer sig från [drawing guides](/slides/sv/cpp/drawing-guides/). Rutnätsavstånd styr ett regelbundet intervall, medan ritguider är individuellt placerade horisontella eller vertikala justeringslinjer. Att lägga till, flytta eller rensa ritguider ändrar inte rutnätsavståndet.

Både rutnätet och ritguiderna är hjälpmedel för redigering. De renderas inte som bildinnehåll i PDF, bilder, SVG eller en bildspelsvisning. Att lagra rutnätsavståndet garanterar inte att en redigerare visar rutnätet: dess synlighet beror också på visnings- eller redigerarens inställningar.

## **Visa eller dölja kommentarer vid öppning av en presentation**

Använd [Presentation::get_ViewProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_viewproperties/) för att komma åt vyinställningar på presentationsnivå. Använd [IViewProperties::get_ShowComments](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iviewproperties/get_showcomments/) och [IViewProperties::set_ShowComments](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iviewproperties/set_showcomments/) för att lagra en preferens om huruvida kommentarer ska visas när presentationen öppnas i PowerPoint eller en annan kompatibel redigerare.

Denna inställning styr endast den lagrade vypreferensen. Den lägger inte till, tar bort, redigerar eller löser kommentarer. Att dölja kommentarer bevarar deras innehåll, författare, positioner, svar och status. Se [Presentation Comments](/slides/sv/cpp/presentation-comments/) för operationer som ändrar kommentarerna själva.

Följande exempel kräver en befintlig `comments.pptx` som innehåller kommentarer. Det skriver ut den aktuella synlighetsinställningen, begär att kommentarer ska döljas och sparar en ny PPTX utan att ta bort några kommentarer. Det använder också [IViewProperties::set_LastView](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iviewproperties/set_lastview/) tillsammans med [ViewType::SlideView](https://reference.aspose.com/slides/sv/cpp/aspose.slides/viewtype/) för att konfigurera den initiala redigeringsvyn samt kommentarssynlighet.

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

Denna inställning avgör inte om kommentarer inkluderas i PDF-, HTML-, bild-, antecknings- eller utdelningsexport. Konfigurera de specifika exportalternativen separat.

## **FAQ**

**Varför är rutnätet inte synligt när jag öppnar presentationen igen?**

Filen lagrar rutnätsavståndet, men redigeraren styr om rutnätet visas. Kontrollera redigerarens inställningar för rutnätsynlighet.

**Ändrar rensning av ritguider rutnätsavståndet?**

Nej. Ritguider och rutnätsavstånd är oberoende inställningar. Att rensa guider lämnar det lagrade rutnätsintervallet oförändrat.

**Kan jag ange olika vyinställningar för olika sektioner i en presentation?**

[View settings](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_viewproperties/) definieras på presentationsnivå ([Normal View](https://reference.aspose.com/slides/sv/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/sv/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), inte per sektion, så en enda uppsättning parametrar gäller för hela dokumentet när det öppnas.

**Kan jag fördefiniera olika vylägen för olika användare?**

Nej. Inställningarna lagras i filen och delas. Visningsprogram kan ta hänsyn till användarpreferenser, men filen i sig innehåller endast en uppsättning vyeegenskaper.

**Kan jag förbereda en mall med fördefinierade View Properties så att nya presentationer öppnas på samma sätt?**

Ja. Eftersom [view properties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_viewproperties/) lagras på presentationsnivå kan du bädda in dem i en mall och skapa nya dokument från den med samma initiala vykonfiguration.