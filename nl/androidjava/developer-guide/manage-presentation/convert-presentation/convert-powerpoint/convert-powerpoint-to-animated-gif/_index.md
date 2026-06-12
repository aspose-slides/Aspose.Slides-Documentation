---
title: PowerPoint-presentaties converteren naar geanimeerde GIF's op Android
linktitle: PowerPoint naar GIF
type: docs
weight: 65
url: /nl/androidjava/convert-powerpoint-to-animated-gif/
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
- Android
- Java
- Aspose.Slides
description: "Converteer eenvoudig PowerPoint-presentaties (PPT, PPTX) naar geanimeerde GIF's met Aspose.Slides voor Android via Java. Snelle, hoogwaardige resultaten."
---
## **Overzicht**

Aspose.Slides maakt het mogelijk om PowerPoint‑presentaties om te zetten naar geanimeerde GIF‑bestanden met slechts een paar regels code. Dit is handig wanneer u de inhoud van dia’s wilt delen in een lichtgewicht, breed ondersteund animatie‑formaat dat ingebed kan worden in webpagina’s, messengers of documentatie. Dit artikel legt uit hoe u een presentatie naar GIF exporteert met de standaardinstellingen en hoe u de output kunt aanpassen door opties zoals frame‑grootte, dia‑vertraging en overgang‑frame‑rate te configureren via [GifOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/gifoptions/).

## **Presentaties converteren naar geanimeerde GIF met standaardinstellingen**

Deze voorbeeldcode in Java laat zien hoe u een presentatie naar een geanimeerde GIF converteert met de standaardinstellingen:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save("pres.gif", SaveFormat.Gif);
} finally {
	if (pres != null) pres.dispose();
}
```

De geanimeerde GIF wordt aangemaakt met standaardparameters. 

{{%  alert  title="TIP"  color="primary"  %}} 

Als u de parameters voor de GIF wilt aanpassen, kunt u de [GifOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/GifOptions)‑klasse gebruiken. Zie de voorbeeldcode hieronder.

{{% /alert %}} 

## **Presentaties converteren naar geanimeerde GIF met aangepaste instellingen**

Deze voorbeeldcode laat zien hoe u een presentatie naar een geanimeerde GIF converteert met aangepaste instellingen in Java:

```java
Presentation pres = new Presentation("pres.pptx");
try {
	GifOptions gifOptions = new GifOptions();
	gifOptions.setFrameSize(new Dimension(960, 720)); // de grootte van de resulterende GIF  
	gifOptions.setDefaultDelay(2000); // hoe lang elke dia wordt weergegeven voordat deze wordt vervangen door de volgende
	gifOptions.setTransitionFps(35); // verhoog de FPS voor betere kwaliteit van de overgangsanimatie

	pres.save("pres.gif", SaveFormat.Gif, gifOptions);
} finally {
	if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}

U kunt een GRATIS [Text to GIF](https://products.aspose.app/slides/nl/text-to-gif)‑converter, ontwikkeld door Aspose, bekijken. 

{{% /alert %}}

## **FAQ**

**Wat als de lettertypen die in de presentatie worden gebruikt niet op het systeem zijn geïnstalleerd?**

Installeer de ontbrekende lettertypen of [configure fallback fonts](/slides/nl/androidjava/powerpoint-fonts/). Aspose.Slides zal een vervanging gebruiken, maar het uiterlijk kan afwijken. Voor huisstijl moet u er altijd voor zorgen dat de vereiste lettertypen expliciet beschikbaar zijn.

**Kan ik een watermerk op de GIF‑frames plaatsen?**

Ja. [Add a semi-transparent object/logo](/slides/nl/androidjava/watermark/) toevoegen aan de master‑dia of aan individuele dia’s vóór export — het watermerk verschijnt op elk frame.