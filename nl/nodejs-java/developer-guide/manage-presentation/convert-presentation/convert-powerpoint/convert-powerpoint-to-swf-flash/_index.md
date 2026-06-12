---
title: PowerPoint-presentaties converteren naar SWF Flash in JavaScript
linktitle: PowerPoint naar SWF
type: docs
weight: 80
url: /nl/nodejs-java/convert-powerpoint-to-swf-flash/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Converteer PowerPoint (PPT/PPTX) naar SWF Flash met Aspose.Slides voor Node.js. Stapsgewijze codevoorbeelden, snelle kwaliteit output, zonder PowerPoint‑automatisering."
---
## **Overzicht**

Dit artikel legt uit hoe u PowerPoint-presentaties naar SWF kunt converteren met Aspose.Slides. Het laat zien hoe u een presentatie kunt opslaan als een SWF-bestand met de [Presentation.save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation/#save) methode en hoe u de export kunt configureren met [SwfOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/swfoptions/), inclusief viewer-instellingen en de lay-out van notities of commentaren.

## **PPT(X) converteren naar SWF**
De [save](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) methode die wordt blootgesteld door de [Presentation](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/presentation) klasse kan worden gebruikt om de volledige presentatie te converteren naar een **SWF**-document. Het volgende voorbeeld laat zien hoe u een presentatie kunt omzetten naar een **SWF**-document met behulp van de opties die worden geleverd door de **SWFOptions**-klasse. U kunt tevens commentaren opnemen in de gegenereerde SWF met behulp van de **SWFOptions**-klasse en de **NotesCommentsLayoutingOptions**-klasse.

```javascript
var pres = new aspose.slides.Presentation("Sample.pptx");
try {
    var swfOptions = new aspose.slides.SwfOptions();
    swfOptions.setViewerIncluded(false);
    swfOptions.getNotesCommentsLayouting().setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    // Presentatie opslaan
    pres.save("Sample.swf", aspose.slides.SaveFormat.Swf, swfOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Veelgestelde vragen**

**Kan ik verborgen dia's opnemen in de SWF?**

Ja. Gebruik de [setShowHiddenSlides](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/swfoptions/setshowhiddenslides/) methode in [SwfOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/swfoptions/). Standaard worden verborgen dia's niet geëxporteerd.

**Hoe kan ik compressie en de uiteindelijke SWF-grootte beheersen?**

Gebruik de [setCompressed](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/swfoptions/setcompressed/) methode en [setJpegQuality](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/swfoptions/setjpegquality/) om een balans te vinden tussen bestandsgrootte en beeldkwaliteit.

**Waar dient 'setViewerIncluded' voor en wanneer moet ik het gebruiken?**

[setViewerIncluded](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/swfoptions/setviewerincluded/) voegt een ingebedde speler-UI toe (navigatie-bedieningselementen, panelen, zoeken). Gebruik het als u uw eigen speler wilt gebruiken of een kaal SWF-frame zonder UI nodig heeft.

**Wat gebeurt er als een bronlettertype ontbreekt op de export-machine?**

Aspose.Slides zal het lettertype substitueren dat u opgeeft via [setDefaultRegularFont](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) in [SwfOptions](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/swfoptions/) om een onbedoelde fallback te voorkomen.