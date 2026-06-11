---
title: Hämta och uppdatera presentationsvyegenskaper i C++
linktitle: Vyegenskaper
type: docs
weight: 80
url: /sv/cpp/presentation-view-properties/
keywords:
- vyegenskaper
- normalläge
- dispositionsinnehåll
- dispositionsikoner
- fäst vertikal delare
- enkel vy
- fältstatus
- dimensionstorlek
- automatisk justering
- standardzoom
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Upptäck Aspose.Slides för C++ vyegenskaper för att anpassa PPT-, PPTX- och ODP-bilder—justera layouter, zoomnivåer och visningsinställningar."
---
## **Introduktion**

Normalläget består av tre innehållsområden: själva bilden, ett sidoinnehållsområde och ett nederst innehållsområde. Egenskaper som gäller placeringen av de olika innehållsområdena. Denna information gör att applikationen kan spara vyns tillstånd till filen, så att när den öppnas igen är vyn i samma tillstånd som när presentationen senast sparades.

Metoden [IViewProperties::get_NormalViewProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iviewproperties/get_normalviewproperties/) har lagts till för att ge åtkomst till normallägets egenskaper för en presentation. 

Gränssnitten [INormalViewProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/inormalviewproperties/), [INormalViewRestoredProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/inormalviewrestoredproperties/) samt deras efterföljare, enumen [SplitterBarStateType](https://reference.aspose.com/slides/sv/cpp/aspose.slides/splitterbarstatetype/) har lagts till.

## **Om INormalViewProperties**

Representerar egenskaper för normalläget.

Egendomen **ShowOutlineIcons** anger om applikationen ska visa ikoner när dispositionen visas i något av innehållsområdena i normallägesläget.

Egendomen **SnapVerticalSplitter** anger om den vertikala delaren ska fästa i ett minimerat tillstånd när sidområdet är tillräckligt litet.

Egendomen **PreferSingleView** anger om användaren föredrar att se ett enda innehållsområde som fyller hela fönstret istället för standardnormalläget med tre innehållsområden. Om den är aktiverad kan applikationen välja att visa ett av innehållsområdena i hela fönstret.

Egendomarna **VerticalBarState** och **HorizontalBarState** anger i vilket tillstånd den horisontella respektive vertikala delningslisten ska visas. En horisontell delningslist separerar bilden från innehållsområdet under bilden, en vertikal delningslist separerar bilden från sidoinnehållsområdet. Möjliga värden är: **SplitterBarStateType.Minimized**, **SplitterBarStateType.Maximized** och **SplitterBarStateType.Restored**.

Egendomarna **RestoredLeft** och **RestoredTop** anger storleken på det övre eller sidogränssnittet i normalläget när värdet **SplitterBarStateType.Restored** har tillämpats på **VerticalBarState** respektive **HorizontalBarState**.

## **Om återställning av INormalViewProperties**

Anger storleken på bildområdet (bredd när det är ett barn till RestoredTop, höjd när det är ett barn till RestoredLeft) i normalläget när området har en variabel återställd storlek (varken minimerat eller maximalt).

Egendomen **DimensionSize** anger storleken på bildområdet (bredd när det är ett barn till RestoredTop, höjd när det är ett barn till RestoredLeft).

Egendomen **AutoAdjust** anger om sidoinnehållsområdet ska kompensera för den nya storleken när fönstret som innehåller vyn i applikationen ändras storlek.

Ett exempel visas nedan som visar hur du kan komma åt egenskaperna **ViewProperties.NormalViewProperties** för en presentation.

``` cpp
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

Aspose.Slides för C++ stödjer nu att ange standardzoomvärdet för en presentation så att när presentationen öppnas är zoomen redan inställd. Detta kan göras genom att ställa in [ViewProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/viewproperties/) för en presentation. Bildvyegenskaper samt [get_NotesViewProperties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/viewproperties/get_notesviewproperties/) kan också sättas programatiskt. I detta avsnitt ser vi med ett exempel hur man ställer in View Properties för en presentation i Aspose.Slides.

För att ställa in vyegenskaperna, följ stegen nedan:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑klassen
1. Ställ in View[Properties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/viewproperties/) för presentationen
1. Skriv presentationen som en PPTX‑fil

I exemplet nedan har vi ställt in zoomvärdet för både bildvyn och notervyn.

``` cpp
auto presentation = System::MakeObject<Presentation>(u"demo.pptx");

// Ställa in vyegenskaperna för presentationen
presentation->get_ViewProperties()->get_SlideViewProperties()->set_Scale(100); // Zoomvärde i procent för bildvyn
presentation->get_ViewProperties()->get_NotesViewProperties()->set_Scale(100); // Zoomvärde i procent för notervyn 

presentation->Save(u"Zoom_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Kan jag ange olika vyinställningar för olika avsnitt i en presentation?**

[Vyinställningar](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_viewproperties/) definieras på presentationsnivå ([Normal View](https://reference.aspose.com/slides/sv/cpp/aspose.slides/viewproperties/get_normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/sv/cpp/aspose.slides/viewproperties/get_slideviewproperties/)), inte per avsnitt, så ett enda parametrarset gäller för hela dokumentet när det öppnas.

**Kan jag fördefiniera olika vylägen för olika användare?**

Nej. Inställningarna lagras i filen och delas. Visningsprogram kan ta hänsyn till användarpreferenser, men filen själv innehåller ett enda set av vyegenskaper.

**Kan jag skapa en mall med fördefinierade View Properties så att nya presentationer öppnas på samma sätt?**

Ja. Eftersom [view properties](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/get_viewproperties/) lagras på presentationsnivå kan du bädda in dem i en mall och skapa nya dokument från den med samma initiala vykonfiguration.