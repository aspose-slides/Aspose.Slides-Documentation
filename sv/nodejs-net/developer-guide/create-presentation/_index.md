---
title: Skapa presentationer i Node.js via .NET
linktitle: Skapa presentation
type: docs
weight: 10
url: /sv/nodejs-net/create-presentation/
keywords:
- skapa presentation
- ny presentation
- skapa PowerPoint
- skapa PPTX
- lägg till textruta
- lägg till bild
- bildstorlek
- bredbild
- PowerPoint
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Skapa PowerPoint‑presentationer i JavaScript med Aspose.Slides för Node.js via .NET: lägg till en textruta och bilder, ställ in en 16:9‑bildstorlek och spara resultatet som PPTX."
---
## **Översikt**

Denna artikel visar hur man skapar en presentation med Aspose.Slides för Node.js via .NET, lägger till en textruta på dess första bild och sparar resultatet som en PPTX‑fil. Den visar också hur man lägger till fler bilder och hur man byter presentationen till widescreen‑bilder (16:9).

Exemplen kräver ett projekt som är konfigurerat enligt [Installation](/slides/sv/nodejs-net/installation/). Spara varje exempel som en `.js`‑fil i projektmappen och kör den från den mappen med `node`, till exempel `node create-presentation.js`.

{{% alert color="info" title="Note" %}}
Aspose.Slides för Node.js via .NET har ingen egen API‑referens. Den speglar Aspose.Slides för .NET API med camelCase‑namn, så API‑länkarna i den här artikeln leder till de matchande klasserna och medlemmarna i [Aspose.Slides för .NET API‑referensen](https://reference.aspose.com/slides/sv/net/).
{{% /alert %}}

## **Skapa en presentation med en textruta**

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/). En ny presentation innehåller redan en tom bild.  
2. Hämta den bilden från samlingen [slides](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/slides/sv/). Samlingar i detta paket läses med `get(index)`, och index börjar på 0.  
3. Lägg till en rektangel med metoden [addAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/shapecollection/addautoshape/) och sätt [text](https://reference.aspose.com/slides/sv/net/aspose.slides/textframe/text/) för dess [textFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/autoshape/textframe/).  
4. Spara presentationen med metoden [save](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/save/) och värdet `SaveFormat.Pptx`.  
5. Anropa `dispose` i ett `finally`‑block för att frigöra .NET‑resurserna som ligger bakom presentationen.

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // Positionen (x, y) och storleken (bredd, höjd) är i punkter.
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    textBox.textFrame.text = "Hello, Aspose.Slides!";

    presentation.save("new-presentation.pptx", SaveFormat.Pptx);
    console.log("Saved new-presentation.pptx");
} finally {
    presentation.dispose();
}
```

Skriptet skriver `new-presentation.pptx` till projektmappen. Filen har en bild med en fylld rektangel vars övre vänstra hörn ligger 50 punkter från bildens vänstra och övre kant. Rektangeln är 400 punkter bred och 100 punkter hög, och dess text är centrerad. En punkt motsvarar 1/72 tum. Utan licens lägger Aspose.Slides även till en utvärderingsvattenstämpel på bilden; se [Licensiering](/slides/sv/nodejs-net/licensing/).

## **Lägg till bilder**

En ny presentation har en bild. För att lägga till fler, skicka en layout‑bild till metoden [addEmptySlide](https://reference.aspose.com/slides/sv/net/aspose.slides/slidecollection/addemptyslide/) för `slides`‑samlingen. Metoden [getByType](https://reference.aspose.com/slides/sv/net/aspose.slides/layoutslidecollection/getbytype/) för samlingen [layoutSlides](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/layoutslides/) returnerar den första layouten av en given [SlideLayoutType](https://reference.aspose.com/slides/sv/net/aspose.slides/slidelayouttype/).

Följande exempel lägger till två bilder med tom layout:

```javascript
const { Presentation, SlideLayoutType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const blankLayout = presentation.layoutSlides.getByType(SlideLayoutType.Blank);
    presentation.slides.addEmptySlide(blankLayout);
    presentation.slides.addEmptySlide(blankLayout);

    console.log("Slide count: " + presentation.slides.count);
    presentation.save("three-slides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Skriptet skriver ut `Slide count: 3` och skapar `three-slides.pptx`. De nya bilderna läggs till efter den första och innehåller inga former. En ny presentation har alltid en tom layout, men en presentation som du öppnar från en fil kanske inte har en layout av den begärda typen; i så fall returnerar `getByType` `null`, så kontrollera resultatet innan du använder det.

## **Ställ in bildstorlek**

En ny presentation använder 4:3‑bilder som är 720 × 540 punkter (10 × 7,5 tum). För att skapa widescreen‑bilder istället, anropa metoden [setSize](https://reference.aspose.com/slides/sv/net/aspose.slides/slidesize/setsize/) för presentationens [slideSize](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/slidesize/) med ett värde av [SlideSizeType](https://reference.aspose.com/slides/sv/net/aspose.slides/slidesizetype/) och ett värde av [SlideSizeScaleType](https://reference.aspose.com/slides/sv/net/aspose.slides/slidesizescaletype/). Skalningstypen talar om för Aspose.Slides vad som ska göras med former som redan finns på bilderna; `DoNotScale` lämnar dem som de är, vilket är rätt val för en presentation som ännu inte har något innehåll.

```javascript
const { Presentation, SlideSizeType, SlideSizeScaleType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    presentation.slideSize.setSize(SlideSizeType.Widescreen, SlideSizeScaleType.DoNotScale);

    const slideSize = presentation.slideSize.size;
    console.log(`Slide size: ${slideSize.width} x ${slideSize.height} points`);

    presentation.save("widescreen.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Skriptet skriver ut `Slide size: 960 x 540 points`, vilket är 13,33 × 7,5 tum, och skapar `widescreen.pptx`. `SlideSizeType.OnScreen16x9` har samma bildförhållande 16:9 men är mindre: 720 × 405 punkter.

## **Vanliga frågor**

**I vilka enheter mäts positioner och storlekar?**  
I punkter. En tum är 72 punkter, så standard‑4:3‑bilden är 720 × 540 punkter, och en widescreen‑bild 16:9 är 960 × 540 punkter.

**Vilka format kan jag spara en ny presentation i?**  
Valfritt värde i enum‑typen [SaveFormat](https://reference.aspose.com/slides/sv/net/aspose.slides.export/saveformat/), till exempel `SaveFormat.Ppt` för PowerPoint 97–2003, `SaveFormat.Odp` för OpenDocument, eller `SaveFormat.Pdf`. För PDF‑utmatning, se [Konvertera PowerPoint till PDF](/slides/sv/nodejs-net/convert-powerpoint-to-pdf/).

**Varför innehåller den sparade presentationen texten "Evaluation only"?**  
Utan licens lägger Aspose.Slides till en utvärderingsvattenstämpel på de bilder som sparas. Applicera en licens enligt [Licensiering](/slides/sv/nodejs-net/licensing/) för att ta bort den.

**Varför bör jag anropa `dispose`?**  
Ett `Presentation`‑objekt stödjs av ett .NET‑objekt som hanterar minne och andra resurser. Genom att anropa `dispose` frigörs dessa så snart du inte längre behöver presentationen, och genom att anropa det i ett `finally`‑block frigörs de även vid ett fel.