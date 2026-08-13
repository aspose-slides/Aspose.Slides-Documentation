---
title: PowerPoint‑presentaties converteren naar geanimeerde GIF’s in .NET
linktitle: PowerPoint naar GIF
type: docs
weight: 65
url: /nl/net/convert-powerpoint-to-animated-gif/
keywords:
- geanimeerde GIF
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar GIF
- presentatie naar GIF
- dia naar GIF
- PPT naar GIF
- PPTX naar GIF
- PPT opslaan als GIF
- PPTX opslaan als GIF
- PPT exporteren als GIF
- PPTX exporteren als GIF
- standaardinstellingen
- aangepaste instellingen
- .NET
- C#
- Aspose.Slides
description: "Converteer eenvoudig PowerPoint‑presentaties (PPT, PPTX) naar geanimeerde GIF’s met Aspose.Slides voor .NET. Snelle, hoge‑kwaliteit resultaten."
---
## **Overzicht**

Aspose.Slides stelt u in staat om PowerPoint‑presentaties te converteren naar geanimeerde GIF‑bestanden met slechts enkele regels code. Dit is handig wanneer u de inhoud van dia’s wilt delen in een lichtgewicht, breed ondersteund animatieformaat dat ingebed kan worden in webpagina’s, messengers of documentatie. Dit artikel legt uit hoe u een presentatie exporteert naar GIF met de standaardinstellingen en hoe u de uitvoer kunt aanpassen door opties zoals frame‑grootte, dia‑vertraging en overgang‑frame‑snelheid te configureren via [GifOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/gifoptions/).

## **Presentaties converteren naar geanimeerde GIF met standaardinstellingen**

Deze voorbeeldcode in C# laat zien hoe u een presentatie converteert naar een geanimeerde GIF met de standaardinstellingen:

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

De geanimeerde GIF wordt aangemaakt met de standaardparameters. 

{{%  alert  title="TIP"  color="info"  %}} 

Als u de parameters voor de GIF liever aanpast, kunt u de [GifOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/gifoptions) klasse gebruiken. Zie de voorbeeldcode hieronder. 

{{% /alert %}} 

## **Presentaties converteren naar geanimeerde GIF met aangepaste instellingen**

Deze voorbeeldcode laat zien hoe u een presentatie converteert naar een geanimeerde GIF met aangepaste instellingen in C#:

``` csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // de grootte van de resulterende GIF
        DefaultDelay = 2000, // hoe lang elke dia wordt getoond tot hij wordt vervangen door de volgende
        TransitionFps = 35 // verhoog het FPS voor een betere kwaliteit van de overgangsanimatie
    });
}
```

{{% alert title="Info" color="info" %}}

U kunt ook de GRATIS [Text to GIF](https://products.aspose.app/slides/nl/text-to-gif) converter van Aspose bekijken. 

{{% /alert %}}

## **FAQ**

### Wat gebeurt er als de lettertypen die in de presentatie worden gebruikt niet op het systeem geïnstalleerd zijn?

Installeer de ontbrekende lettertypen of [configure fallback fonts](/slides/nl/net/powerpoint-fonts/). Aspose.Slides zal vervangen, maar het uiterlijk kan afwijken. Voor merkconsistentie moet u er altijd voor zorgen dat de benodigde lettertypen expliciet beschikbaar zijn.

### Kan ik een watermerk over de GIF‑frames leggen?

Ja. [Add a semi-transparent object/logo](/slides/nl/net/watermark/) toevoegen aan de master‑dia of aan individuele dia’s vóór het exporteren — het watermerk verschijnt op elk frame.