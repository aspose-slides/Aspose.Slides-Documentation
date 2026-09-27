---
title: "Konvertera presentationsbilder till bildfiler i Node.js via .NET"
linktitle: "Slide till bild"
type: docs
weight: 40
url: /sv/nodejs-net/convert-slide/
keywords:
- "konvertera slide"
- "slide till bild"
- "slide till PNG"
- "spara slide som bild"
- "rendera slide"
- "slide miniatyr"
- "PowerPoint"
- "OpenDocument"
- "presentation"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Rendera bilder från PPTX-, PPT- och ODP-presentationer som PNG‑bilder i JavaScript med Aspose.Slides för Node.js via .NET, med en skalningsfaktor eller med exakt storlek i pixlar."
---
## **Översikt**

Aspose.Slides for Node.js via .NET renderar bilder från PowerPoint- och OpenDocument-presentationer, till exempel för att visa förhandsgranskningar av bilder på en webbsida. Denna artikel visar två sätt att välja bildstorlek: en skalningsfaktor relativt bildens storlek och en exakt storlek i pixlar. Båda exemplen sparar PNG-filer.

Exemplen förväntar sig en presentation med namnet `sample.pptx` i projektmappen som du konfigurerade i [Installation](/slides/sv/nodejs-net/installation/). Vilken PowerPoint-presentation som helst fungerar. Spara varje exempel som en `.js`-fil i projektmappen och kör den från den mappen med `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET har ingen egen API-referens. Den speglar Aspose.Slides for .NET API med camelCase-namn, så API-länkarna i den här artikeln leder till de matchande klasserna och medlemmarna i [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/).
{{% /alert %}}

För att konvertera en slide till en bild, följ dessa steg:

1. Öppna presentationen med konstruktorn [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/).
2. Hämta en slide från samlingen [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) med `get(index)`. Index börjar på 0.
3. Rendera sliden med `getImageWithScale` eller `getImageWithImageSize`. I .NET API-referensen är båda överlagringar av [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/). De returnerar ett bildobjekt som motsvarar [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/).
4. Spara bilden med dess [save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/)‑metod och ett [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/)‑värde, och anropa sedan dess `dispose`‑metod.

## **Konvertera varje slide till en PNG-bild**

`getImageWithScale` tar en horisontell och en vertikal skalningsfaktor. Vid en skala på 1 blir en punkt i sliden en bildpunkt i bilden. Följande exempel renderar varje slide med en skala på 2:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

// En skala på 1 renderar en pixel per punkt; 2 fördubblar bredden och höjden.
const scaleX = 2;
const scaleY = scaleX;

const presentation = new Presentation("sample.pptx");
try {
    const slideCount = presentation.slides.count;
    for (let index = 0; index < slideCount; index++) {
        const slide = presentation.slides.get(index);
        const image = slide.getImageWithScale(scaleX, scaleY);
        try {
            image.save(`slide_${index + 1}.png`, ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
    console.log(`Saved ${slideCount} images`);
} finally {
    presentation.dispose();
}
```

Skriptet skriver en fil per slide, `slide_1.png`, `slide_2.png` och så vidare, numrerade från 1. För en 16:9‑presentation med slides på 960 × 540 punkter blir varje bild 1920 × 1080 pixlar. Dolda slides renderas också; för att hoppa över dem, kontrollera slidens egendom [hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/). Varje bild frigörs i sin egen `finally`‑block, vilket släpper den innan nästa slide renderas. Utan licens visar bilderna även ett utvärderingsvattenmärke; se [Licensing](/slides/sv/nodejs-net/licensing/).

## **Konvertera en slide till en bild med given storlek**

`getImageWithImageSize` tar ett objekt med `width` och `height` i pixlar. Följande exempel renderar den första sliden 1280 pixlar bred och beräknar höjden från slidens storlek, så att bilden behåller slidens bildförhållande:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

const imageWidth = 1280;

const presentation = new Presentation("sample.pptx");
try {
    const slideSize = presentation.slideSize.size;
    const imageHeight = Math.round(imageWidth * slideSize.height / slideSize.width);

    const slide = presentation.slides.get(0);
    const image = slide.getImageWithImageSize({ width: imageWidth, height: imageHeight });
    try {
        image.save("slide_1_1280px.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
    console.log(`Saved a ${imageWidth} x ${imageHeight} image`);
} finally {
    presentation.dispose();
}
```

Egenskapen [slideSize.size](https://reference.aspose.com/slides/net/aspose.slides/slidesize/size/) returnerar slidens bredd och höjd i punkter. För en 16:9‑presentation skriver skriptet ut `Saved a 1280 x 720 image` och skapar `slide_1_1280px.png`; för en 4:3‑presentation blir bilden 1280 × 960 pixlar.

## **FAQ**

**Varför är bilden från `getImage` utan argument så liten?**

Utan argument renderar `getImage` sliden med 20 % av dess storlek i punkter, så en slide på 960 × 540 punkter blir en bild på 192 × 108 pixlar. Använd `getImageWithScale` eller `getImageWithImageSize` för att välja storlek.

**Hur sparar jag JPEG eller andra bildformat?**

Skicka ett annat `ImageFormat`‑värde till bildens `save`‑metod, till exempel `image.save("slide_1.jpg", ImageFormat.Jpeg)`. Formatet hämtas från `ImageFormat`‑värdet, inte från filändelsen, så håll de två konsekventa.

**Varför ser texten i bilderna annorlunda ut på Linux?**

Aspose.Slides kan endast använda typsnitt som är installerade på den maskin som renderar slidsen. När en presentation använder ett typsnitt som saknas, till exempel Calibri på en vanlig Linux‑server, använder Aspose.Slides ett installerat typsnitt i dess ställe, vilket kan ändra hur texten ser ut och var radbrytningar sker. Installera de typsnitt som dina presentationer använder för att få samma bilder som på Windows.

**Varför misslyckas `getThumbnailWithImageSize` med ett TypeError?**

Pakets README använder `getThumbnailWithImageSize`, men paketet har inga `getThumbnail`‑metoder. Använd `getImageWithImageSize` istället; den tar samma `{ width, height }`‑argument.