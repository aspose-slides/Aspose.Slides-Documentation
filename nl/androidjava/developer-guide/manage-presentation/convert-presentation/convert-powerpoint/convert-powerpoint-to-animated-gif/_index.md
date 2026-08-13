---
title: PowerPoint‑presentaties converteren naar geanimeerde GIF's op Android
linktitle: PowerPoint naar GIF
type: docs
weight: 65
url: /nl/androidjava/convert-powerpoint-to-animated-gif/
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
- Android
- Java
- Aspose.Slides
description: "Converteer eenvoudig PowerPoint‑presentaties (PPT, PPTX) naar geanimeerde GIF's met Aspose.Slides voor Android via Java. Snelle, hoogwaardige resultaten."
---
## **Overzicht**

Aspose.Slides stelt u in staat om PowerPoint‑presentaties met slechts een paar regels code om te zetten naar geanimeerde GIF‑bestanden. Dit is handig wanneer u slide‑inhoud wilt delen in een lichtgewicht, breed ondersteund animatieformaat dat in webpagina’s, chat‑apps of documentatie kan worden ingevoegd. Dit artikel legt uit hoe u een presentatie naar GIF exporteert met de standaardinstellingen en hoe u de uitvoer kunt aanpassen door opties zoals framegrootte, slide‑vertraging en overgang‑frame‑rate te configureren via [GifOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/gifoptions/).

## **Presentaties converteren naar geanimeerde GIF met standaardinstellingen**

Deze voorbeeldcode in Java laat zien hoe u een presentatie naar een geanimeerde GIF converteert met de standaardinstellingen:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

De geanimeerde GIF wordt aangemaakt met de standaardparameters. 

{{%  alert  title="TIP"  color="info"  %}} 
Als u de parameters voor de GIF wilt aanpassen, kunt u de [GifOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/GifOptions) klasse gebruiken. Zie de voorbeeldcode hieronder.
{{% /alert %}} 

## **Presentaties converteren naar geanimeerde GIF met aangepaste instellingen**

Deze voorbeeldcode laat zien hoe u een presentatie naar een geanimeerde GIF converteert met aangepaste instellingen in Java:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // de grootte van de resulterende GIF
	gifOptions.setDefaultDelay(2000); // hoe lang elke slide wordt getoond voordat deze wordt vervangen door de volgende
	gifOptions.setTransitionFps(35); // verhoog FPS voor betere animatiekwaliteit van de overgang

	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
U kunt ook de GRATIS [Text to GIF](https://products.aspose.app/slides/nl/text-to-gif) converter van Aspose bekijken. 
{{% /alert %}}

## **FAQ**

### Wat gebeurt er als de lettertypen die in de presentatie worden gebruikt niet op het systeem zijn geïnstalleerd?

Installeer de ontbrekende lettertypen of [configure fallback fonts](/slides/nl/androidjava/powerpoint-fonts/). Aspose.Slides zal een vervanging toepassen, maar de weergave kan afwijken. Voor branding moet u er altijd voor zorgen dat de benodigde lettertypen expliciet beschikbaar zijn.

### Kan ik een watermerk over de GIF‑frames plaatsen?

Ja. Voeg een semitransparant object/logo toe aan de master‑slide of aan individuele slides vóór export — het watermerk verschijnt op elk frame.