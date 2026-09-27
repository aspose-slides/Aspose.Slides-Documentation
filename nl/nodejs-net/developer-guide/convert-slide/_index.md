---
title: Dia's van presentaties omzetten naar afbeeldingen in Node.js via .NET
linktitle: Dia naar afbeelding
type: docs
weight: 40
url: /nl/nodejs-net/convert-slide/
keywords:
- dia converteren
- dia naar afbeelding
- dia naar PNG
- dia opslaan als afbeelding
- dia renderen
- dia-thumbnail
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Render dia's uit PPTX-, PPT- en ODP-presentaties als PNG-afbeeldingen in JavaScript met Aspose.Slides voor Node.js via .NET, met een schaalfactor of met een exacte grootte in pixels."
---
## **Overzicht**

Aspose.Slides for Node.js via .NET renderen dia's uit PowerPoint‑ en OpenDocument‑presentaties als afbeeldingen, bijvoorbeeld om voorvertoningen van dia's op een webpagina te tonen. Dit artikel toont twee manieren om de afbeeldingsgrootte te kiezen: een schaalfactor ten opzichte van de dia‑grootte, en een exacte grootte in pixels. Beide voorbeelden slaan PNG‑bestanden op.

De voorbeelden verwachten een presentatie met de naam `sample.pptx` in de projectmap die je hebt opgezet in [Installation](/slides/nl/nodejs-net/installation/). Elke PowerPoint‑presentatie voldoet. Sla elk voorbeeld op als een `.js`‑bestand in de projectmap en voer het uit vanuit die map met `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET heeft geen eigen API‑referentie. Het spiegelt de Aspose.Slides for .NET API met camelCase‑namen, dus de API‑links in dit artikel verwijzen naar de overeenkomstige klassen en leden in de [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/).
{{% /alert %}}

Om een dia naar een afbeelding te converteren, volg deze stappen:

1. Open de presentatie met de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) constructor.  
1. Haalt een dia op uit de [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) collectie met `get(index)`. Indexen beginnen bij 0.  
1. Render de dia met `getImageWithScale` of `getImageWithImageSize`. In de .NET API‑referentie zijn dit overloads van [Slide.GetImage](https://reference.aspose.com/slides/net/aspose.slides/slide/getimage/). Ze retourneren een afbeelding‑object dat overeenkomt met [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/).  
1. Sla de afbeelding op met zijn [save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) methode en een [ImageFormat](https://reference.aspose.com/slides/net/aspose.slides/imageformat/) waarde, en roep daarna zijn `dispose` methode aan.

## **Converteer elke dia naar een PNG‑afbeelding**

`getImageWithScale` neemt een horizontale en een verticale schaalfactor. Bij een schaal van 1 wordt één punt van de dia één pixel van de afbeelding. Het volgende voorbeeld renderen alle dia's met een schaal van 2:

```javascript
const { Presentation, ImageFormat } = require("aspose.slides.via.net");

// Een schaal van 1 rendeert één pixel per punt; 2 verdubbelt zowel de breedte als de hoogte.
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

Het script schrijft één bestand per dia, `slide_1.png`, `slide_2.png`, enzovoort, genummerd vanaf 1. Voor een 16:9‑presentatie met dia’s van 960 × 540 punten, is elke afbeelding 1920 × 1080 pixels. Verborgen dia's worden ook gerenderd; om ze over te slaan, controleer je de [hidden](https://reference.aspose.com/slides/net/aspose.slides/slide/hidden/) eigenschap van de dia. Elke afbeelding wordt in zijn eigen `finally`‑block disposed, waardoor deze wordt vrijgegeven vóórdat de volgende dia wordt gerenderd. Zonder licentie bevatten de afbeeldingen ook een evaluatiewatermerk; zie [Licensing](/slides/nl/nodejs-net/licensing/).

## **Converteer een dia naar een afbeelding met een opgegeven grootte**

`getImageWithImageSize` neemt een object met `width` en `height` in pixels. Het volgende voorbeeld rendert de eerste dia 1280 pixels breed en berekent de hoogte op basis van de dia‑grootte, zodat de afbeelding de aspectverhouding van de dia behoudt:

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

De eigenschap [slideSize.size](https://reference.aspose.com/slides/net/aspose.slides/slidesize/size/) geeft de breedte en hoogte van de dia in punten terug. Voor een 16:9‑presentatie toont het script `Saved a 1280 x 720 image` en schrijft `slide_1_1280px.png`; voor een 4:3‑presentatie is de afbeelding 1280 × 960 pixels.

## **FAQ**

**Waarom is de afbeelding van `getImage` zonder argumenten zo klein?**

Zonder argumenten rendert `getImage` de dia op 20 % van zijn grootte in punten, dus een dia van 960 × 540 punten wordt een afbeelding van 192 × 108 pixels. Gebruik `getImageWithScale` of `getImageWithImageSize` om de grootte te kiezen.

**Hoe sla ik JPEG‑ of andere afbeeldingsformaten op?**

Geef een andere `ImageFormat`‑waarde door aan de `save`‑methode van de afbeelding, bijvoorbeeld `image.save("slide_1.jpg", ImageFormat.Jpeg)`. Het formaat wordt bepaald door de `ImageFormat`‑waarde, niet door de bestandsextensie, dus houd de twee consistent.

**Waarom ziet de tekst in de afbeeldingen er anders uit op Linux?**

Aspose.Slides kan alleen lettertypen gebruiken die geïnstalleerd zijn op de machine die de dia's rendert. Wanneer een presentatie een lettertype gebruikt dat ontbreekt, bijvoorbeeld Calibri op een typische Linux‑server, gebruikt Aspose.Slides een geïnstalleerd lettertype als vervanging, waardoor de weergave van de tekst en de regeleinden kunnen veranderen. Installeer de lettertypen die je presentaties gebruiken om dezelfde afbeeldingen als op Windows te krijgen.

**Waarom faalt `getThumbnailWithImageSize` met een TypeError?**

De README van het pakket gebruikt `getThumbnailWithImageSize`, maar het pakket bevat geen `getThumbnail`‑methoden. Gebruik in plaats daarvan `getImageWithImageSize`; deze neemt hetzelfde `{ width, height }`‑argument.