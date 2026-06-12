---
title: PowerPoint-presentaties converteren naar geanimeerde GIF's in .NET
linktitle: PowerPoint naar GIF
type: docs
weight: 65
url: /nl/net/convert-powerpoint-to-animated-gif/
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
- .NET
- C#
- Aspose.Slides
description: "Converteer eenvoudig PowerPoint-presentaties (PPT, PPTX) naar geanimeerde GIF's met Aspose.Slides voor .NET. Snel, resultaten van hoge kwaliteit."
---
## **Overzicht**

Aspose.Slides stelt u in staat om PowerPoint‑presentaties om te zetten naar geanimeerde GIF‑bestanden met slechts een paar regels code. Dit is handig wanneer u slide‑inhoud wilt delen in een lichtgewicht, breed ondersteund geanimeerd formaat dat kan worden ingebed in webpagina's, messengers of documentatie. Dit artikel legt uit hoe u een presentatie exporteert naar GIF met de standaardinstellingen en hoe u de uitvoer kunt aanpassen door opties zoals frame‑grootte, slide‑vertraging en overgang‑frame‑rate te configureren via [GifOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/gifoptions/).

## **Presentaties omzetten naar geanimeerde GIF met standaardinstellingen**

Deze voorbeeldcode in C# laat zien hoe u een presentatie omzet naar een geanimeerde GIF met de standaardinstellingen:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif);
}
```

De geanimeerde GIF wordt aangemaakt met de standaardparameters. 

{{%  alert  title="TIP"  color="primary"  %}} 
Als u de parameters voor de GIF wilt aanpassen, kunt u de [GifOptions](https://reference.aspose.com/slides/nl/net/aspose.slides.export/gifoptions) klasse gebruiken. Zie de voorbeeldcode hieronder. 
{{% /alert %}} 

## **Presentaties omzetten naar geanimeerde GIF met aangepaste instellingen**

Deze voorbeeldcode laat zien hoe u een presentatie omzet naar een geanimeerde GIF met aangepaste instellingen in C#:

``` csharp
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres.gif", SaveFormat.Gif, new GifOptions
    {
        FrameSize = new Size(960, 720), // de grootte van de resulterende GIF  
        DefaultDelay = 2000, // hoe lang elke dia wordt weergegeven totdat deze wordt vervangen door de volgende
        TransitionFps = 35 // verhoog FPS voor betere kwaliteit van de overgangsanimatie
    });
}
```

{{% alert title="Info" color="info" %}}
U kunt ook een GRATIS [Text to GIF](https://products.aspose.app/slides/nl/text-to-gif) converter van Aspose bekijken. 
{{% /alert %}}

## **FAQ**

**Wat gebeurt er als de in de presentatie gebruikte lettertypen niet op het systeem zijn geïnstalleerd?**

Installeer de ontbrekende lettertypen of [configure fallback fonts](/slides/nl/net/powerpoint-fonts/). Aspose.Slides zal een vervanging gebruiken, maar het uiterlijk kan afwijken. Zorg er voor branding altijd voor dat de vereiste lettertypes expliciet beschikbaar zijn.

**Kan ik een watermerk over de GIF‑frames leggen?**

Ja. [Voeg een semi-transparant object/logo](/slides/nl/net/watermark/) toe aan de master‑slide of aan afzonderlijke slides vóór het exporteren — het watermerk verschijnt op elk frame.