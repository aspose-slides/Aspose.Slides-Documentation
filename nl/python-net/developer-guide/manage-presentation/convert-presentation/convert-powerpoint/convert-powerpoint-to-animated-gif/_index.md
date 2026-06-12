---
title: "Presentaties converteren naar geanimeerde GIF's in Python"
linktitle: Presentatie naar GIF
type: docs
weight: 65
url: /nl/python-net/convert-powerpoint-to-animated-gif/
keywords:
- geanimeerde GIF
- PowerPoint converteren
- OpenDocument converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- ODP converteren
- PowerPoint naar GIF
- OpenDocument naar GIF
- presentatie naar GIF
- dia naar GIF
- PPT naar GIF
- PPTX naar GIF
- ODP naar GIF
- standaardinstellingen
- aangepaste instellingen
- Python
- Aspose.Slides
description: "Converteer eenvoudig PowerPoint-presentaties (PPT, PPTX) en OpenDocument-bestanden (ODP) naar geanimeerde GIF's met Aspose.Slides voor Python. Snelle, hoogwaardige resultaten."
---
## **Overzicht**

Met Aspose.Slides kunt u PowerPoint‑presentaties converteren naar geanimeerde GIF‑bestanden met slechts een paar regels code. Dit is handig wanneer u de inhoud van dia’s wilt delen in een lichtgewicht, breed ondersteund animatieformaat dat in webpagina’s, chat‑apps of documentatie kan worden ingebed. In dit artikel wordt uitgelegd hoe u een presentatie exporteert naar GIF met de standaardinstellingen en hoe u de uitvoer kunt aanpassen door opties zoals framegrootte, dia‑vertraging en overgangssnelheid te configureren via [GifOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/gifoptions/).

## **Presentaties converteren naar geanimeerde GIF met de standaardinstellingen**

Deze voorbeeldcode in Python laat zien hoe u een presentatie converteert naar een geanimeerde GIF met de standaardinstellingen:

```py
import aspose.slides as slides

pres = slides.Presentation(path + "pres.pptx")
pres.save("pres.gif", slides.export.SaveFormat.GIF)
```

De geanimeerde GIF wordt aangemaakt met de standaardparameters. 

{{%  alert  title="TIP"  color="primary"  %}} 

Als u de parameters voor de GIF wilt aanpassen, kunt u de [GifOptions](https://reference.aspose.com/slides/nl/python-net/aspose.slides.export/gifoptions/)‑klasse gebruiken. Bekijk de voorbeeldcode hieronder. 

{{% /alert %}} 

## **Presentaties converteren naar geanimeerde GIF met aangepaste instellingen**

Deze voorbeeldcode laat zien hoe u een presentatie converteert naar een geanimeerde GIF met aangepaste instellingen in Python:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

options = slides.export.GifOptions()
options.frame_size = drawing.Size(960, 720) # de grootte van de resulterende GIF  
options.default_delay = 2000 # hoe lang elke dia wordt weergegeven totdat deze wordt vervangen door de volgende
options.transition_fps = 35  # verhoog FPS voor betere animatiekwaliteit van de overgang

pres.save("pres.gif", slides.export.SaveFormat.GIF, options)
```

{{% alert title="Info" color="info" %}}

U kunt wellicht een GRATIS [Text to GIF](https://products.aspose.app/slides/nl/text-to-gif)‑converter bekijken die door Aspose is ontwikkeld. 

{{% /alert %}}

## **FAQ**

**Wat gebeurt er als de lettertypen die in de presentatie gebruikt worden niet op het systeem geïnstalleerd zijn?**

Installeer de ontbrekende lettertypen of [configure fallback fonts](/slides/nl/python-net/powerpoint-fonts/). Aspose.Slides zal een vervanging gebruiken, maar het uiterlijk kan afwijken. Zorg voor branding altijd dat de benodigde lettertypen expliciet beschikbaar zijn.

**Kan ik een watermerk op de GIF‑frames plaatsen?**

Ja. [Voeg een semi-transparant object/logo](/slides/nl/python-net/watermark/) toe aan de master‑dia of aan individuele dia’s vóór het exporteren — het watermerk verschijnt op elk frame.