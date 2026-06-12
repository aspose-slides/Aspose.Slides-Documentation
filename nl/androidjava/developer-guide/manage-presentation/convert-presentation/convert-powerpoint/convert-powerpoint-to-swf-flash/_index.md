---
title: PowerPoint Presentaties converteren naar SWF Flash op Android
linktitle: PowerPoint naar SWF
type: docs
weight: 80
url: /nl/androidjava/convert-powerpoint-to-swf-flash/
keywords:
- PowerPoint converteren
- presentatie converteren
- dia converteren
- PPT converteren
- PPTX converteren
- PowerPoint naar SWF
- presentatie naar SWF
- dia naar SWF
- PPT naar SWF
- PPTX naar SWF
- PowerPoint naar Flash
- presentatie naar Flash
- dia naar Flash
- PPT naar Flash
- PPTX naar Flash
- PPT opslaan als SWF
- PPTX opslaan als SWF
- PPT exporteren naar SWF
- PPTX exporteren naar SWF
- PowerPoint
- presentatie
- Android
- Java
- Aspose.Slides
description: "Converteer PowerPoint (PPT/PPTX) naar SWF Flash in Java met Aspose.Slides voor Android. Stapsgewijze codevoorbeelden, snelle kwaliteit output, geen PowerPoint-automatisering."
---
## **Overzicht**

Dit artikel legt uit hoe je PowerPoint‑presentaties kunt converteren naar SWF met behulp van Aspose.Slides. Het laat zien hoe je een presentatie opslaat als een SWF‑bestand met de [Presentation.save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) methode en hoe je de export configureert met [SwfOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/swfoptions/), inclusief weergave‑instellingen en notities‑ of commentaar‑lay‑out.

## **Converteer PPT(X) naar SWF**
De [Save](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) methode die beschikbaar is via de [Presentation](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/presentation) klasse kan worden gebruikt om de volledige presentatie te converteren naar een **SWF**‑document. Het volgende voorbeeld laat zien hoe je een presentatie converteert naar een **SWF**‑document met behulp van de opties die worden geleverd door de [**SWFOptions**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/SwfOptions) klasse. Je kunt ook opmerkingen opnemen in de gegenereerde SWF met behulp van de [**ISWFOptions**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/ISwfOptions) klasse en de [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/INotesCommentsLayoutingOptions) interface.

```java
Presentation pres = new Presentation("Sample.pptx");
try {
    SwfOptions swfOptions = new SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(NotesPositions.BottomFull);
    
    // Presentatie opslaan
    pres.save("Sample.swf", SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Kan ik verborgen dia's opnemen in de SWF?**

Ja. Schakel de verborgen dia's in met de [setShowHiddenSlides](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-) methode in [SwfOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/swfoptions/). Standaard worden verborgen dia's niet geëxporteerd.

**Hoe kan ik compressie en de uiteindelijke SWF-grootte regelen?**

Gebruik de [setCompressed](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/swfoptions/#setCompressed-boolean-) methode en [pas de JPEG‑kwaliteit aan](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/swfoptions/#setJpegQuality-int-) om een balans te vinden tussen bestandsgrootte en beeldkwaliteit.

**Waar dient 'setViewerIncluded' voor, en wanneer moet ik het uitschakelen?**

[setViewerIncluded](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) voegt een ingebedde speler‑UI toe (navigatie‑controles, panelen, zoeken). Schakel het uit als je een eigen speler wilt gebruiken of een minimale SWF‑frame zonder UI nodig hebt.

**Wat gebeurt er als een bronlettertype ontbreekt op de exportmachine?**

Aspose.Slides zal het lettertype dat je opgeeft via [setDefaultRegularFont](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) in [SwfOptions](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/swfoptions/) vervangen om een ongewenste fallback te voorkomen.