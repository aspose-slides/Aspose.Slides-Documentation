---
title: PowerPoint-presentaties converteren naar geanimeerde GIF's in JavaScript
linktitle: PowerPoint naar GIF
type: docs
weight: 65
url: /nl/nodejs-java/convert-powerpoint-to-animated-gif/
keywords:
- geanimeerde GIF
- PowerPoint converteren
- presentatie converteren
- slide converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar GIF
- presentatie naar GIF
- slide naar GIF
- PPT naar GIF
- PPTX naar GIF
- PPT opslaan als GIF
- PPTX opslaan als GIF
- PPT exporteren als GIF
- PPTX exporteren als GIF
- standaardinstellingen
- aangepaste instellingen
- PowerPoint
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Converteer eenvoudig PowerPoint-presentaties (PPT, PPTX) naar geanimeerde GIF's in JavaScript met Aspose.Slides voor Node.js via Java. Snelle, hoogwaardige resultaten."
---
## **Overzicht**

Aspose.Slides stelt u in staat om PowerPoint‑presentaties te converteren naar geanimeerde GIF‑bestanden met slechts enkele regels code. Dit is handig wanneer u slide‑inhoud wilt delen in een lichtgewicht, breed ondersteund animatieformaat dat kan worden ingebed in webpagina’s, messengers of documentatie. Dit artikel legt uit hoe u een presentatie exporteert naar GIF met standaardinstellingen en hoe u de output kunt aanpassen door opties zoals framegrootte, slide‑vertraaging en overgangs‑frame‑rate te configureren via [GifOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/gifoptions/).

## **Presentaties converteren naar geanimeerde GIF met standaardinstellingen**

Deze voorbeeldcode in JavaScript laat zien hoe u een presentatie converteert naar een geanimeerde GIF met standaardinstellingen:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

De geanimeerde GIF wordt aangemaakt met de standaardparameters.

{{%  alert  title="TIP"  color="primary"  %}} 
Als u de parameters voor de GIF wilt aanpassen, kunt u de [GifOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/GifOptions) klasse gebruiken. Zie de voorbeeldcode hieronder.
{{% /alert %}} 

## **Presentaties converteren naar geanimeerde GIF met aangepaste instellingen**

Deze voorbeeldcode laat zien hoe u een presentatie converteert naar een geanimeerde GIF met aangepaste instellingen in JavaScript:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var gifOptions = new aspose.slides.GifOptions();
    gifOptions.setFrameSize(java.newInstanceSync("java.awt.Dimension", 960, 720));// de grootte van de resulterende GIF
    gifOptions.setDefaultDelay(2000);// hoe lang elke slide wordt getoond voordat deze naar de volgende wordt gewijzigd
    gifOptions.setTransitionFps(35);// verhoog FPS voor betere overgangsanimatiekwaliteit
    pres.save("pres.gif", aspose.slides.SaveFormat.Gif, gifOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Info" color="info" %}}
U kunt een GRATIS [Tekst naar GIF](https://products.aspose.app/slides/nl/text-to-gif) converter, ontwikkeld door Aspose, bekijken.
{{% /alert %}}

## **FAQ**

**Wat als de lettertypen die in de presentatie worden gebruikt niet op het systeem geïnstalleerd zijn?**

Installeer de ontbrekende lettertypen of [configure fallback fonts](/slides/nl/nodejs-java/powerpoint-fonts/). Aspose.Slides zal een vervanging gebruiken, maar het uiterlijk kan verschillen. Voor branding moet u er altijd voor zorgen dat de benodigde lettertypen expliciet beschikbaar zijn.

**Kan ik een watermerk over de GIF‑frames plaatsen?**

Ja. [Add a semi-transparent object/logo](/slides/nl/nodejs-java/watermark/) toevoegen aan de master‑slide of aan afzonderlijke slides vóór export — het watermerk verschijnt op elk frame.