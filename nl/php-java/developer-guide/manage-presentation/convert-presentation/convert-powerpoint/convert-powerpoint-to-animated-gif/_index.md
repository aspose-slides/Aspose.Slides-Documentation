---
title: PowerPoint-presentaties converteren naar geanimeerde GIF's in PHP
linktitle: PowerPoint naar GIF
type: docs
weight: 65
url: /nl/php-java/convert-powerpoint-to-animated-gif/
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
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Converteer eenvoudig PowerPoint-presentaties (PPT, PPTX) naar geanimeerde GIF's met Aspose.Slides voor PHP via Java. Snelle, hoogwaardige resultaten."
---
## **Overzicht**

Aspose.Slides stelt u in staat om PowerPoint‑presentaties om te zetten naar geanimeerde GIF‑bestanden met slechts een paar regels code. Dit is handig wanneer u dia‑inhoud wilt delen in een lichtgewicht, breed ondersteund animatieformaat dat kan worden ingebed in webpagina's, messengers of documentatie. Dit artikel legt uit hoe u een presentatie exporteert naar GIF met de standaardinstellingen en hoe u de uitvoer kunt aanpassen door opties zoals frame‑grootte, dia‑vertraging en transitie‑frame‑snelheid te configureren via [GifOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/gifoptions/).

## **Presentaties converteren naar geanimeerde GIF met standaardinstellingen**

Deze voorbeeldcode toont u hoe u een presentatie naar een geanimeerde GIF converteert met de standaardinstellingen:

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save("pres.gif", SaveFormat::Gif);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

De geanimeerde GIF wordt gemaakt met de standaardparameters. 

{{%  alert  title="TIP"  color="primary"  %}} 
Als u de parameters voor de GIF liever wilt aanpassen, kunt u de [GifOptions](https://reference.aspose.com/slides/nl/php-java/aspose.slides/GifOptions)‑klasse gebruiken. Zie de voorbeeldcode hieronder.
{{% /alert %}} 

## **Presentaties converteren naar geanimeerde GIF met aangepaste instellingen**
Deze voorbeeldcode toont u hoe u een presentatie naar een geanimeerde GIF converteert met aangepaste instellingen :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $gifOptions = new GifOptions();
    $gifOptions->setFrameSize(new Java("java.awt.Dimension", 960, 720));// de grootte van de gegenereerde GIF

    $gifOptions->setDefaultDelay(2000);// hoe lang elke dia wordt getoond totdat deze wordt vervangen door de volgende

    $gifOptions->setTransitionFps(35);// verhoog het aantal FPS voor een betere kwaliteit van de overgangsanimatie

    $pres->save("pres.gif", SaveFormat::Gif, $gifOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Info" color="info" %}}
U wilt wellicht een GRATIS [Text to GIF](https://products.aspose.app/slides/nl/text-to-gif)‑converter van Aspose bekijken. 
{{% /alert %}}

## **FAQ**

**Wat als de lettertypen die in de presentatie worden gebruikt niet op het systeem geïnstalleerd zijn?**

Installeer de ontbrekende lettertypen of [fallback-lettertypen configureren](/slides/nl/php-java/powerpoint-fonts/). Aspose.Slides zal een vervanging gebruiken, maar het uiterlijk kan afwijken. Zorg er voor branding altijd voor dat de benodigde lettertypen expliciet beschikbaar zijn.

**Kan ik een watermerk over de GIF‑frames leggen?**

Ja. [Voeg een semitransparant object/logo](/slides/nl/php-java/watermark/) toe aan de master‑dia of aan individuele dia's vóór het exporteren — het watermerk wordt op elk frame weergegeven.