---
title: PowerPoint-presentaties converteren naar geanimeerde GIF-bestanden in C++
linktitle: PowerPoint naar GIF
type: docs
weight: 65
url: /nl/cpp/convert-powerpoint-to-animated-gif/
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
- C++
- Aspose.Slides
description: "Converteer eenvoudig PowerPoint-presentaties (PPT, PPTX) naar geanimeerde GIF-bestanden met Aspose.Slides voor C++. Snelle, hoogwaardige resultaten."
---
## **Overzicht**

Aspose.Slides stelt u in staat om PowerPoint‑presentaties te converteren naar geanimeerde GIF‑bestanden met slechts een paar regels code. Dit is handig wanneer u de inhoud van dia’s wilt delen in een lichtgewicht, breed ondersteund animatieformaat dat kan worden ingebed in webpagina’s, messengers of documentatie. Dit artikel legt uit hoe u een presentatie exporteert naar GIF met de standaardinstellingen en hoe u de uitvoer kunt aanpassen door opties zoals beeldgrootte, dia‑vertraging en overgangsframerate te configureren via [GifOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/gifoptions/).

## **Presentaties converteren naar geanimeerde GIF met standaardinstellingen**

Deze voorbeeldcode in C++ laat zien hoe u een presentatie naar een geanimeerde GIF converteert met standaardinstellingen:

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

De geanimeerde GIF wordt aangemaakt met de standaardparameters. 

{{%  alert  title="TIP"  color="primary"  %}} 

Als u de parameters voor de GIF wilt aanpassen, kunt u de [GifOptions](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.export.gif_options)‑klasse gebruiken. Zie de voorbeeldcode hieronder. 

{{% /alert %}} 

## **Presentaties converteren naar geanimeerde GIF met aangepaste instellingen**

Deze voorbeeldcode laat zien hoe u een presentatie naar een geanimeerde GIF converteert met aangepaste instellingen in C++:

``` cpp
auto gifOptions = System::MakeObject<GifOptions>();
// de grootte van de resulterende GIF 
gifOptions->set_FrameSize(Size(960, 720));
// hoe lang elke dia wordt getoond totdat deze wordt vervangen door de volgende
gifOptions->set_DefaultDelay(2000);
// FPS verhogen voor betere overgangsanimatiekwaliteit
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}

U kunt ook een GRATIS [Text to GIF](https://products.aspose.app/slides/nl/text-to-gif)‑converter van Aspose bekijken. 

{{% /alert %}}

## **FAQ**

**Wat gebeurt er als de lettertypen die in de presentatie worden gebruikt niet op het systeem zijn geïnstalleerd?**

Installeer de ontbrekende lettertypen of [fallback-lettertypen configureren](/slides/nl/cpp/powerpoint-fonts/). Aspose.Slides zal een vervanging toepassen, maar het uiterlijk kan afwijken. Zorg voor branding altijd dat de benodigde lettertypes expliciet beschikbaar zijn.

**Kan ik een watermerk over de GIF‑frames leggen?**

Ja. [Voeg een semi-transparant object/logo toe](/slides/nl/cpp/watermark/) aan de master‑dia of aan individuele dia’s vóór het exporteren — het watermerk verschijnt op elk frame.