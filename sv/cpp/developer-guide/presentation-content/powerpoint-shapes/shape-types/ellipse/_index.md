---
title: Lägg till ellipser i presentationer i C++
linktitle: Ellips
type: docs
weight: 30
url: /sv/cpp/ellipse/
keywords:
- ellips
- form
- lägg till ellips
- skapa ellips
- rita ellips
- formaterad ellips
- PowerPoint
- presentation
- C++
- Aspose.Slides
description: "Lär dig hur du skapar, formaterar och manipulerar ellipsformer i Aspose.Slides för C++ i PPT- och PPTX-presentationer — exempel på C++-kod ingår."
---
## **Översikt**

Den här artikeln visar hur man lägger till ellipsformer i PowerPoint‑bilder med Aspose.Slides. Den täcker hur man skapar en enkel ellips, hur man skapar en formaterad ellips och hur man sparar den uppdaterade presentationen som en PPTX‑fil. Den berör också relaterade frågor som att arbeta med ellipsens position och storlek, kontroll av staplingsordning och tillämpning av animationseffekter.

## **Skapa en ellips**
I det här avsnittet introducerar vi utvecklare för hur man lägger till ellipsformer i sina bilder med Aspose.Slides för C++. Aspose.Slides för C++ erbjuder ett enklare API‑set för att rita olika typer av former med bara några rader kod. För att lägga till en enkel ellips på en vald bild i presentationen, följ stegen nedan:

1. Skapa en instans av [Presentation-klass](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)
1. Hämta referensen till en bild genom att använda dess Index
1. Lägg till en AutoShape av typ Ellipse med metoden AddAutoShape som exponeras av IShapes-objektet
1. Spara den ändrade presentationen som en PPTX‑fil

I exempelprogrammet nedan har vi lagt till en ellips på den första bilden.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SimpleEllipse-SimpleEllipse.cpp" >}}

## **Skapa en formaterad ellips**
För att lägga till en bättre formaterad ellips på en bild, följ stegen nedan:

1. Skapa en instans av [Presentation-klass](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
1. Hämta referensen till en bild genom att använda dess Index.
1. Lägg till en AutoShape av typ Ellipse med metoden AddAutoShape som exponeras av IShapes-objektet.
1. Ställ in fyllningstypen för ellipsen till Solid.
1. Ställ in färgen på ellipsen med egenskapen SolidFillColor.Color som exponeras av FillFormat-objektet som är associerat med IShape-objektet.
1. Ställ in färgen på ellipsens linjer.
1. Ställ in bredden på ellipsens linjer.
1. Spara den ändrade presentationen som en PPTX‑fil.

I exempelprogrammet nedan har vi lagt till en formaterad ellips på den första bilden i presentationen.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FormattedEllipse-FormattedEllipse.cpp" >}}

## **FAQ**

**Hur anger jag den exakta positionen och storleken på en ellips i förhållande till bildens enheter?**

Koordinater och storlekar anges vanligtvis **i punkter**. För förutsägbara resultat, basera dina beräkningar på bildens storlek och konvertera erforderliga millimeter eller tum till punkter innan du tilldelar värdena.

**Hur placeras en ellips ovanför eller under andra objekt (kontroll av staplingsordning)?**

Justera ritordningen för objektet genom att föra det framåt eller skicka det bakåt. Detta gör att ellipsen kan överlappa andra objekt eller avslöja de som ligger under den.

**Hur animera jag en ellips visnings‑ eller betoningseffekt?**

[Apply](/slides/sv/cpp/shape-animation/) ingångs‑, betoning‑ eller utgångseffekter på formen, och konfigurera triggrar och tidsinställningar för att bestämma när och hur animationen spelas upp.