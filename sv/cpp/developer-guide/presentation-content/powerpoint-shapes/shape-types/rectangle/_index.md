---
title: Lägg till rektanglar i presentationer i C++
linktitle: Rektangel
type: docs
weight: 80
url: /sv/cpp/rectangle/
keywords:
- lägg till rektangel
- skapa rektangel
- rektangel form
- enkel rektangel
- formaterad rektangel
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Förbättra dina PowerPoint-presentationer genom att lägga till rektanglar med Aspose.Slides för C++ — designa och modifiera former programatiskt med lätthet."
---
## **Översikt**

Den här artikeln visar hur man lägger till rektangelformer i PowerPoint-bilder med Aspose.Slides. Den täcker att skapa en enkel rektangel, att skapa en formaterad rektangel och att spara den uppdaterade presentationen som en PPTX‑fil.

## **Skapa en enkel rektangel**
Precis som i tidigare ämnen handlar detta också om att lägga till en form och den här gången är formen vi kommer att diskutera en rektangel. I det här avsnittet har vi beskrivit hur utvecklare kan lägga till enkla eller formaterade rektanglar i sina bilder med Aspose.Slides för C++. För att lägga till en enkel rektangel på en vald bild i presentationen, följ stegen nedan:

1. Skapa en instans av [Presentation class](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
1. Hämta referensen till en bild genom att använda dess index.
1. Lägg till en IAutoShape av typen Rectangle med metoden AddAutoShape som exponeras av IShapes‑objektet.
1. Skriv den modifierade presentationen som en PPTX‑fil.

I exemplaret nedan har vi lagt till en enkel rektangel på den första bilden i presentationen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleRectangle-SimpleRectangle.cpp" >}}

## **Skapa en formaterad rektangel**
För att lägga till en formaterad rektangel på en bild, följ stegen nedan:

1. Skapa en instans av [Presentation class](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
1. Hämta referensen till en bild genom att använda dess index.
1. Lägg till en IAutoShape av typen Rectangle med metoden AddAutoShape som exponeras av IShapes‑objektet.
1. Ställ in fyllningstypen för rektangeln till Solid.
1. Ställ in färgen på rektangeln med egenskapen SolidFillColor.Color som exponeras av FillFormat‑objektet som är kopplat till IShape‑objektet.
1. Ställ in färgen på rektangelns linjer.
1. Ställ in bredden på rektangelns linjer.
1. Skriv den modifierade presentationen som en PPTX‑fil.
   Stegen ovan är implementerade i exemplaret nedan.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedRectangle-FormattedRectangle.cpp" >}}

## **FAQ**

**Hur lägger jag till en rektangel med rundade hörn?**

Använd den rundade hörn‑[shape type](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shapetype/) och justera hörnradien i formens egenskaper; avrundning kan också tillämpas per hörn via geometrijusteringar.

**Hur fyller jag en rektangel med en bild (textur)?**

Välj bild‑[fill type](https://reference.aspose.com/slides/sv/cpp/aspose.slides/filltype/), ange bildkällan och konfigurera [stretching/tiling modes](https://reference.aspose.com/slides/sv/cpp/aspose.slides/picturefillmode/).

**Kan en rektangel ha skugga och glöd?**

Ja. [Outer/inner shadow, glow, and soft edges](/slides/sv/cpp/shape-effect/) finns tillgängliga med justerbara parametrar.

**Kan jag göra en rektangel till en knapp med en hyperlänk?**

Ja. [Assign a hyperlink](/slides/sv/cpp/manage-hyperlinks/) till formen vid klick (hoppa till en bild, fil, webbadress eller e‑post).

**Hur kan jag skydda en rektangel från att flyttas och ändras?**

[Use shape locks](/slides/sv/cpp/applying-protection-to-presentation/): du kan förbjuda flyttning, storleksändring, markering eller textredigering för att bevara layouten.

**Kan jag konvertera en rektangel till en rasterbild eller SVG?**

Ja. Du kan [render the shape](http://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/getimage/) till en bild med angiven storlek/skala eller [export it as SVG](https://reference.aspose.com/slides/sv/cpp/aspose.slides/shape/writeassvg/) för vektoranvändning.

**Hur får jag snabbt de faktiska (effektiva) egenskaperna för en rektangel med hänsyn till tema och arv?**

[Use the shape’s effective properties](/slides/sv/cpp/shape-effective-properties/): API‑et returnerar beräknade värden som tar hänsyn till temastilar, layout och lokala inställningar, vilket förenklar analysen av formatering.