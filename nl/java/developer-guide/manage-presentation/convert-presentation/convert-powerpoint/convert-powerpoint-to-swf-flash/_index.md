---
title: PowerPoint-presentaties converteren naar SWF Flash in Java
linktitle: PowerPoint naar SWF
type: docs
weight: 80
url: /nl/java/convert-powerpoint-to-swf-flash/
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
- Java
- Aspose.Slides
description: "Converteer PowerPoint (PPT/PPTX) naar SWF Flash in Java met Aspose.Slides. Stapsgewijze codevoorbeelden, snelle kwaliteitoutput, geen PowerPoint-automatisering."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint‑presentaties naar SWF kunt converteren met Aspose.Slides. Het laat zien hoe u een presentatie kunt opslaan als een SWF‑bestand met de [Presentation.save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)‑methode en hoe u de export kunt configureren met [SwfOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/swfoptions/), inclusief viewer‑instellingen en de opmaak van notities of opmerkingen.

## **Presentaties converteren naar Flash**

De [save](https://reference.aspose.com/slides/nl/java/com.aspose.slides/Presentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-)‑methode die wordt aangeboden door de klasse [Presentation](https://reference.aspose.com/slides/nl/java/com.aspose.slides/presentation) kan worden gebruikt om de volledige presentatie te converteren naar een **SWF**‑document. Het volgende voorbeeld laat zien hoe u een presentatie naar een **SWF**‑document converteert met behulp van de opties die worden geleverd door de klasse [**SWFOptions**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/SwfOptions) class.You can also include comments in generated SWF using [**ISWFOptions**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/ISwfOptions) class and [**INotesCommentsLayoutingOptions**](https://reference.aspose.com/slides/nl/java/com.aspose.slides/INotesCommentsLayoutingOptions) interface.

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

Ja. Schakel de verborgen dia's in met de [setShowHiddenSlides](https://reference.aspose.com/slides/nl/java/com.aspose.slides/swfoptions/#setShowHiddenSlides-boolean-)‑methode in [SwfOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/swfoptions/). Standaard worden verborgen dia's niet geëxporteerd.

**Hoe kan ik compressie en de uiteindelijke SWF‑grootte beheersen?**

Gebruik de [setCompressed](https://reference.aspose.com/slides/nl/java/com.aspose.slides/swfoptions/#setCompressed-boolean-)‑methode en [pas de JPEG‑kwaliteit aan](https://reference.aspose.com/slides/nl/java/com.aspose.slides/swfoptions/#setJpegQuality-int-) om een balans te vinden tussen bestandsgrootte en beeldkwaliteit.

**Waar dient 'setViewerIncluded' voor en wanneer moet ik het uitschakelen?**

[setViewerIncluded](https://reference.aspose.com/slides/nl/java/com.aspose.slides/swfoptions/#setViewerIncluded-boolean-) voegt een ingebedde afspeel‑UI toe (navigatie‑besturingselementen, panelen, zoeken). Schakel het uit als u uw eigen afspeler wilt gebruiken of een kale SWF‑frame zonder UI nodig hebt.

**Wat gebeurt er als een bronlettertype ontbreekt op de exportmachine?**

Aspose.Slides zal het lettertype dat u opgeeft via [setDefaultRegularFont](https://reference.aspose.com/slides/nl/java/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) in [SwfOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/swfoptions/) vervangen om een onbedoelde fallback te voorkomen.