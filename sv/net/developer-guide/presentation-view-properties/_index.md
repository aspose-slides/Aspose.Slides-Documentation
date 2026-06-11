---
title: Hämta och uppdatera presentationsvyegenskaper i .NET
linktitle: Vyegenskaper
type: docs
weight: 80
url: /sv/net/presentation-view-properties/
keywords:
- vyegenskaper
- normal vy
- dispositionsinnehåll
- dispositionsikoner
- fäst vertikal delare
- enkelsvy
- listtillstånd
- dimensionstorlek
- automatisk justering
- standardzoom
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Upptäck Aspose.Slides för .NET vyegenskaper för att anpassa PPT-, PPTX- och ODP-format; justera layouter, zoomnivåer och visningsinställningar."
---
## **Introduktion**

Normalvy består av tre innehållsområden: själva bilden, ett sidoinnehållsområde och ett botteninnehållsområde. Egenskaper som rör placeringen av de olika innehållsområdena. Denna information gör att applikationen kan spara sitt visningsläge i filen, så att när den öppnas igen är vyn i samma tillstånd som när presentationen senast sparades.

Egenskapen [IViewProperties.NormalViewProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/iviewproperties/properties/normalviewproperties) har lagts till för att ge åtkomst till normalvyns egenskaper för presentationen.

[INormalViewProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/inormalviewproperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/inormalviewrestoredproperties) gränssnitt och deras underklasser, [SplitterBarStateType](https://reference.aspose.com/slides/sv/net/aspose.slides/splitterbarstatetype) enum har lagts till.

## **Om INormalViewProperties**

Representerar normalvyns egenskaper.

Egendomen **ShowOutlineIcons** anger om applikationen ska visa ikoner när dispositionsinnehåll visas i något av innehållsområdena i normalvyläge.

Egendomen **SnapVerticalSplitter** anger om den vertikala delaren ska fästas i ett minimerat tillstånd när sidområdet är tillräckligt litet.

Egendomen **PreferSingleView** anger om användaren föredrar att se ett fullskärms enkel‑innehållsområde istället för den standardiserade normalvyn med tre innehållsområden. Om den är aktiverad kan applikationen välja att visa ett av innehållsområdena i hela fönstret.

Egendömerna **VerticalBarState** och **HorizontalBarState** specificerar i vilket tillstånd den horisontella respektive vertikala delningslisten ska visas. En horisontell delningslist separerar bilden från innehållsområdet under bilden, en vertikal delningslist separerar bilden från sidoinnehållsområdet. Möjliga värden är: **SplitterBarStateType.Minimized, SplitterBarStateType.Maximized** och **SplitterBarStateType.Restored**.

Egendömerna **RestoredLeft** och **RestoredTop** anger storleken på det övre eller sidogående bildområdet i normalvyn, när värdet **SplitterBarStateType.Restored** används för **VerticalBarState** respektive **HorizontalBarState**.

## **Om återställning av INormalViewProperties**

Anger storleken på bildområdet (bredd när det är ett underobjekt till RestoredTop, höjd när det är ett underobjekt till RestoredLeft) i normalvyn, när området har en variabel återställd storlek (varken minimerad eller maximiserad).

Egendomen **DimensionSize** anger storleken på bildområdet (bredd när det är ett underobjekt till restoredTop, höjd när det är ett underobjekt till restoredLeft).

Egendomen **AutoAdjust** anger om storleken på sidoinnehållsområdet ska justeras för den nya storleken när fönstret som innehåller vyn ändras i applikationen.

Ett exempel ges nedan som visar hur du kan komma åt egenskaperna **ViewProperties.NormalViewProperties** för en presentation.

```c#
using (Presentation pres = new Presentation("demo.pptx"))
{
    pres.ViewProperties.NormalViewProperties.HorizontalBarState = SplitterBarStateType.Restored;
    pres.ViewProperties.NormalViewProperties.VerticalBarState = SplitterBarStateType.Maximized;

    // Återställ presentationens vyegenskaper
    pres.ViewProperties.NormalViewProperties.RestoredTop.AutoAdjust = true;
    pres.ViewProperties.NormalViewProperties.RestoredTop.DimensionSize = 80;
    pres.ViewProperties.NormalViewProperties.ShowOutlineIcons = true;

    pres.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
}
```

## **Ställ in standardzoomvärdet**

Aspose.Slides för .NET stödjer nu att ställa in standardzoomvärdet för en presentation så att när presentationen öppnas är zoomen redan satt. Detta kan göras genom att sätta [ViewProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/viewproperties) för en presentation. Bildvyeegenskaper samt [NotesViewProperties](https://reference.aspose.com/slides/sv/net/aspose.slides/viewproperties/properties/notesviewproperties) kan sättas programatiskt. I detta avsnitt ser vi med ett exempel hur man ställer in Vy[Properties](https://reference.aspose.com/slides/sv/net/aspose.slides/viewproperties) för Presentation i Aspose.Slides.

För att ställa in vy‑egenskaperna, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)
2. Ställ in Vy [Properties](https://reference.aspose.com/slides/sv/net/aspose.slides/viewproperties) för Presentation
3. Skriv presentationen som en PPTX‑fil

```c#
using (Presentation presentation = new Presentation("demo.pptx"))
{
    // Ställer in vyegenskaperna för presentationen
    presentation.ViewProperties.SlideViewProperties.Scale = 100; // Zoomvärde i procent för bildvyn
    presentation.ViewProperties.NotesViewProperties.Scale = 100; // Zoomvärde i procent för anteckningsvyn 

    presentation.Save("Zoom_out.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Kan jag ställa in olika vyinställningar för olika sektioner i en presentation?**

[View settings](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/viewproperties/) definieras på presentationsnivå ([Normal View](https://reference.aspose.com/slides/sv/net/aspose.slides/viewproperties/normalviewproperties/)/[Slide View](https://reference.aspose.com/slides/sv/net/aspose.slides/viewproperties/slideviewproperties/)), inte per sektion, så ett enda uppsättning parametrar gäller för hela dokumentet när det öppnas.

**Kan jag fördefiniera olika vylägen för olika användare?**

Nej. Inställningarna lagras i filen och delas. Visningsprogram kan ta hänsyn till användarpreferenser, men filen själv innehåller endast ett set av vy‑egenskaper.

**Kan jag förbereda en mall med fördefinierade Vy‑egenskaper så att nya presentationer öppnas på samma sätt?**

Ja. Eftersom [view properties](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/viewproperties/) lagras på presentationsnivå kan du bädda in dem i en mall och skapa nya dokument från den med samma initiala vy‑konfiguration.