---
title: Hämta och uppdatera presentationsvyegenskaper i C++
linktitle: Vyegenskaper
type: docs
weight: 80
url: /sv/cpp/presentation-view-properties/
keywords:
  - vyegenskaper
  - normal vy
  - dispositionsinnehåll
  - dispositionsikoner
  - snäppa vertikal delare
  - enkel vy
  - listtillstånd
  - dimensionstorlek
  - automatisk justering
  - standardzoom
  - PowerPoint
  - OpenDocument
  - presentation
  - C++
  - Aspose.Slides
description: "Upptäck Aspose.Slides för C++ vyegenskaper för att anpassa format PPT, PPTX och ODP‑bilder — justera layouter, zoomnivåer och visningsinställningar."
---
## **Introduktion**

Normalvyn består av tre innehållsområden: själva bilden, ett sidoinnehållsområde och ett botteninnehållsområde. Egenskaper som rör positioneringen av de olika innehållsområdena. Denna information gör att applikationen kan spara sitt visningsläge till filen, så att när den öppnas igen är vyn i samma tillstånd som när presentationen senast sparades.

Metoden [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) har lagts till för att ge åtkomst till normalvyns egenskaper för presentationen.

[INormalViewProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/inormalviewrestoredproperties/) gränssnitt och deras underklasser, [SplitterBarStateType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/splitterbarstatetype/) enum har lagts till.

## **Om INormalViewProperties**

Representerar egenskaper för normalvy.

Egenskap **ShowOutlineIcons** specificerar om applikationen ska visa ikoner när dispositionens innehåll visas i något av innehållsområdena i normalvyläget.

Egenskap **SnapVerticalSplitter** specificerar om den vertikala delaren ska fastna i ett minimerat läge när sidområdet är tillräckligt litet.

Egenskap **PreferSingleView** anger om användaren föredrar att se ett helfönster med ett enda innehållsområde istället för den standardmässiga normalvyn med tre innehållsområden. Om detta är aktiverat kan applikationen välja att visa ett av innehållsområdena i hela fönstret.

Egenskaperna **VerticalBarState** och **HorizontalBarState** specificerar i vilket tillstånd den horisontella eller vertikala delningslisten ska visas. En horisontell delningslist separerar bilden från innehållsområdet under bilden, en vertikal delningslist separerar bilden från sidoinnehållsområdet. Möjliga värden är: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** och **SplitterBarStateType.Restored.**

Egenskaperna **RestoredLeft** och **RestoredTop** specificerar storleken på det övre eller sidogolvet i normalvyn, när värdet **SplitterBarStateType.Restored** tillämpas på **VerticalBarState** respektive **HorizontalBarState**.

## **Om återställning av INormalViewProperties**

Anger storleken på bildområdet (bredd när det är ett barn till RestoredTop, höjd när det är ett barn till RestoredLeft) i normalvyn, när området har en variabel återställd storlek (varken minimerad eller maximerad).

Egenskap **DimensionSize** specificerar storleken på bildområdet (bredd när det är ett barn till restoredTop, höjd när det är ett barn till restoredLeft).

Egenskap **AutoAdjust** specificerar om storleken på sidoinnehållsområdet ska kompensera för den nya storleken när fönstret som innehåller vyn i applikationen ändras i storlek.

Ett exempel ges nedan som visar hur du kan komma åt **ViewProperties.NormalViewProperties**-egenskaperna för en presentation.

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

// Återställ visningsegenskaperna för presentationen
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_AutoAdjust(true);
pres->get_ViewProperties()->get_NormalViewProperties()->get_RestoredTop()->set_DimensionSize(80.0f);
pres->get_ViewProperties()->get_NormalViewProperties()->set_ShowOutlineIcons(true);

pres->Save(u"presentation_normal_view_state.pptx", SaveFormat::Pptx);
```

## **Ställ in standard-zoomvärde**

Aspose.Slides för C++ stöder nu att ange standardzoomvärdet för en presentation så att när presentationen öppnas är zoomen redan inställd. Detta kan göras genom att sätta [ViewProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/viewproperties/) för en presentation. Bildvyns egenskaper samt [get_NotesViewProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/viewproperties/get_notesviewproperties/) kan sättas programatiskt. I detta avsnitt ser vi med ett exempel hur man sätter View‑egenskaperna för en presentation i Aspose.Slides.

För att ställa in vy‑egenskaperna, följ stegen nedan:
1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
1. Ställ in View [Properties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/viewproperties/) för presentationen.
1. Spara presentationen som en PPTX‑fil.

I exemplaret nedan har vi satt zoomvärdet för bildvyn samt anteckningsvyn.

``` cpp
#include <DOM/ICommonSlideViewProperties.h>
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Ställer in visningsegenskaperna för presentationen
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Zoomvärde i procent för bildvyn
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Zoomvärde i procent för anteckningsvyn

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **Ställ in rasteravstånd**

Använd [Presentation::get_ViewProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_viewproperties/) för att komma åt visningsinställningarna för hela presentationen. Metoderna [IViewProperties::get_GridSpacing](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iviewproperties/get_gridspacing/) och [IViewProperties::set_GridSpacing](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iviewproperties/set_gridspacing/) läser eller ändrar intervallet för det underliggande redigeringsrasteret. Denna inställning gäller hela presentationen, inte en enskild bild. Rasteravståndet anges i punkter, där 72 punkter motsvarar en tum. Använd ett positivt värde enligt API‑dokumentationen.

Följande exempel öppnar en befintlig `demo.pptx`, skriver ut det aktuella rasteravståndet, sätter ett kvart‑tum‑intervall och sparar resultatet.

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

Rastern är annorlunda än [drawing guides](/slides/sv/cpp/drawing-guides/). Rasteravståndet styr ett regelbundet intervall, medan ritguider är individuellt placerade horisontella eller vertikala justeringslinjer. Att lägga till, flytta eller rensa ritguider förändrar inte rasteravståndet.

Både raster och ritguider är hjälpmedel för redigering. De renderas inte som bildinnehåll i PDF, bilder, SVG eller bildspel. Att lagra rasteravståndet garanterar inte att en redigerare visar rastert: dess synlighet beror också på visarens eller redigerarens inställningar.

## **FAQ**

**Varför är rastert inte synligt efter att jag har öppnat presentationen igen?**  
Filen lagrar rasteravståndet, men redigeraren bestämmer om rastert visas. Kontrollera redigerarens inställningar för rasterns synlighet.

**Ändrar rensning av ritguider rasteravståndet?**  
Nej. Ritguider och rasteravstånd är oberoende inställningar. Att rensa guider lämnar det lagrade rasterintervallet oförändrat.

**Kan jag ange olika visningsinställningar för olika sektioner i en presentation?**  
[View settings](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_viewproperties/) definieras på presentationsnivå ([Normal View](https://reference.aspose.com/slides/sv/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/sv/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), inte per sektion, så ett enda parametervärde gäller för hela dokumentet när det öppnas.

**Kan jag fördefiniera olika visningstillstånd för olika användare?**  
Nej. Inställningarna sparas i filen och delas. Visningsprogram kan respektera användarens preferenser, men filen i sig innehåller endast ett set av vy‑egenskaper.

**Kan jag skapa en mall med fördefinierade View‑egenskaper så nya presentationer öppnas på samma sätt?**  
Ja. Eftersom [view properties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_viewproperties/) lagras på presentationsnivå kan du bädda in dem i en mall och skapa nya dokument från den med samma initiala visningskonfiguration.