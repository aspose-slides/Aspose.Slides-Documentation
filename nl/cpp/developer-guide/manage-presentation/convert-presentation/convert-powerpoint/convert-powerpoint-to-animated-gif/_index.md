---
title: PowerPoint-presentaties converteren naar geanimeerde GIF's in C++
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
description: "Converteer eenvoudig PowerPoint-presentaties (PPT, PPTX) naar geanimeerde GIF's met Aspose.Slides voor C++. Snelle, hoogwaardige resultaten."
---
## **Overzicht**

Aspose.Slides stelt u in staat om PowerPoint‑presentaties te converteren naar geanimeerde GIF‑bestanden met slechts enkele regels code. Dit is handig wanneer u dia‑inhoud wilt delen in een lichtgewicht, breed ondersteund geanimeerd formaat dat kan worden ingebed in webpagina’s, messenger‑apps of documentatie. Dit artikel legt uit hoe u een presentatie exporteert naar GIF met standaardinstellingen en hoe u de output kunt aanpassen door opties te configureren zoals frame‑grootte, dia‑vertraging en overgangs‑frame‑rate via [GifOptions](https://reference.aspose.com/slides/nl/cpp/aspose.slides.export/gifoptions/).

## **Presentaties converteren naar geanimeerde GIF met standaardinstellingen**

Deze voorbeeldcode in C++ laat zien hoe u een presentatie converteert naar een geanimeerde GIF met standaardinstellingen:

``` cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif);
```

De geanimeerde GIF wordt aangemaakt met standaardparameters. 

{{%  alert  title="TIP"  color="info"  %}} 
Als u de parameters voor de GIF wilt aanpassen, kunt u de [GifOptions](https://reference.aspose.com/slides/nl/cpp/class/aspose.slides.export.gif_options)‑klasse gebruiken. Zie de voorbeeldcode hieronder. 
{{% /alert %}} 

## **Presentaties converteren naar geanimeerde GIF met aangepaste instellingen**

Deze voorbeeldcode laat zien hoe u een presentatie converteert naar een geanimeerde GIF met aangepaste instellingen in C++:

``` cpp
#include <DOM/Presentation.h>
#include <Export/GifOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto gifOptions = System::MakeObject<GifOptions>();
// de grootte van de resulterende GIF
gifOptions->set_FrameSize(System::Drawing::Size(960, 720));
// hoe lang elke dia wordt weergegeven voordat hij wordt vervangen door de volgende
gifOptions->set_DefaultDelay(2000);
// verhoog FPS voor betere overgangsanimatiekwaliteit
gifOptions->set_TransitionFps(35);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(u"pres.gif", SaveFormat::Gif, gifOptions);
```

{{% alert title="Info" color="info" %}}
U kunt een GRATIS [Text to GIF](https://products.aspose.app/slides/nl/text-to-gif) converter, ontwikkeld door Aspose, bekijken. 
{{% /alert %}}

## **FAQ**

### Wat gebeurt er als de in de presentatie gebruikte lettertypen niet op het systeem geïnstalleerd zijn?

Installeer de ontbrekende lettertypen of [configure fallback fonts](/slides/nl/cpp/powerpoint-fonts/). Aspose.Slides zal een vervanging gebruiken, maar het uiterlijk kan afwijken. Zorg voor branding altijd dat de benodigde lettertypen expliciet beschikbaar zijn.

### Kan ik een watermerk over de GIF‑frames plaatsen?

Ja. Voeg een semi‑transparant object/logo toe aan de master‑dia of aan individuele dia’s vóór het exporteren — het watermerk verschijnt op elk frame. [Een semi‑transparant object/logo toevoegen](/slides/nl/cpp/watermark/)