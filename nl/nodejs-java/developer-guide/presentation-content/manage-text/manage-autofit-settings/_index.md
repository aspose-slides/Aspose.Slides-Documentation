---
title: Verbeter uw presentaties met AutoFit in JavaScript
linktitle: Autofit-instellingen
type: docs
weight: 30
url: /nl/nodejs-java/manage-autofit-settings/
keywords:
- tekstvak
- autofit
- niet autofit
- tekst passen
- tekst verkleinen
- tekst afbreken
- vorm aanpassen
- PowerPoint
- OpenDocument
- presentatie
- Node.js
- JavaScript
- Aspose.Slides
description: "Beheer AutoFit-instellingen in Aspose.Slides voor Node.js om de weergave van tekst in uw PowerPoint- en OpenDocument-presentaties te optimaliseren en de leesbaarheid van de inhoud te verbeteren."
---
## **Inleiding**

Standaard, wanneer je een tekstvak toevoegt, gebruikt Microsoft PowerPoint de instelling **Resize shape to fix text** voor het tekstvak – het formaat van het tekstvak wordt automatisch aangepast zodat de tekst er altijd in past.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Wanneer de tekst in het tekstvak langer of groter wordt, vergroot PowerPoint automatisch het tekstvak – de hoogte wordt vergroot – zodat er meer tekst in past. 
* Wanneer de tekst in het tekstvak korter of kleiner wordt, verkleint PowerPoint automatisch het tekstvak – de hoogte wordt verkleind – om overtollige ruimte te verwijderen. 

In PowerPoint zijn dit de 4 belangrijke parameters of opties die het autofit‑gedrag voor een tekstvak bepalen:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Node.js via Java biedt vergelijkbare opties – enkele eigenschappen onder de [TextFrameFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TextFrameFormat)‑klasse – die je in staat stellen het autofit‑gedrag voor tekstvakken in presentaties te regelen.

## **Resize Shape to Fit Text**

Als je wilt dat de tekst in een kader altijd in dat kader past nadat de tekst is aangepast, moet je de optie **Resize shape to fix text** gebruiken. Om deze instelling te specificeren, roep je de [setAutofitType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType)‑methode van de [TextFrameFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TextFrameFormat)‑klasse aan met de waarde `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Deze JavaScript‑code laat zien hoe je opgeeft dat een tekst altijd in zijn kader moet passen in een PowerPoint‑presentatie:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Shape);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Wordt de tekst langer of groter, dan wordt het tekstvak automatisch vergroot (hoogte toename) zodat alle tekst past. Wordt de tekst korter, gebeurt het omgekeerde.

## **Do Not Autofit**

Als je wilt dat een tekstvak of vorm zijn afmetingen behoudt, ongeacht de wijzigingen in de tekst, moet je de optie **Do not Autofit** gebruiken. Om deze instelling te specificeren, roep je de [setAutofitType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType)‑methode van de [TextFrameFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TextFrameFormat)‑klasse aan met de waarde `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Deze JavaScript‑code laat zien hoe je opgeeft dat een tekstvak altijd zijn afmetingen behoudt in een PowerPoint‑presentatie:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.None);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Wanneer de tekst te lang wordt voor het kader, stroomt deze over.

## **Shrink Text on Overflow**

Als een tekst te lang wordt voor zijn kader, kun je met de optie **Shrink text on overflow** aangeven dat de grootte en de spatiëring van de tekst moeten worden verkleind zodat hij in het kader past. Om deze instelling te specificeren, roep je de [setAutofitType](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TextFrameFormat#setAutofitType)‑methode van de [TextFrameFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TextFrameFormat)‑klasse aan met de waarde `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Deze JavaScript‑code laat zien hoe je opgeeft dat een tekst moet worden verkleind bij overflow in een PowerPoint‑presentatie:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(aspose.slides.TextAutofitType.Normal);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Info" color="info" %}}

Wanneer de optie **Shrink text on overflow** wordt gebruikt, wordt de instelling alleen toegepast als de tekst te lang wordt voor het kader.

{{% /alert %}}

## **Wrap Text**

Als je wilt dat de tekst in een vorm wordt afgebroken binnen die vorm wanneer de tekst breder wordt dan de vorm (alleen breedte), moet je de parameter **Wrap text in shape** gebruiken. Om deze instelling te specificeren, moet je de [setWrapText](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TextFrameFormat#setWrapText)‑methode van de [TextFrameFormat](https://reference.aspose.com/slides/nl/nodejs-java/aspose.slides/TextFrameFormat)‑klasse aanroepen met de waarde `true`.

Deze JavaScript‑code laat zien hoe je de Wrap Text‑instelling gebruikt in een PowerPoint‑presentatie:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var slide = pres.getSlides().get_Item(0);
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 30, 30, 350, 100);
    var portion = new aspose.slides.Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
    var textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(aspose.slides.NullableBool.True);
    pres.save("Output-presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 

Als je de `setWrapText`‑methode aanroept met de waarde `False` voor een vorm, wordt de tekst, zodra deze langer wordt dan de breedte van de vorm, over de randen van de vorm heen uitgerekt op één regel.

{{% /alert %}}

## **FAQ**

**Beïnvloeden de interne marges van het tekstframe AutoFit?**

Ja. Padding (interne marges) verkleint de bruikbare ruimte voor tekst, waardoor AutoFit eerder wordt geactiveerd – de lettergrootte wordt verkleind of de vorm wordt eerder aangepast. Controleer en pas de marges aan voordat je AutoFit afstemt.

**Hoe werkt AutoFit samen met handmatige en zachte regeleinden?**

Geforceerde regeleinden blijven behouden en AutoFit past de lettergrootte en spatiëring eromheen aan. Het verwijderen van onnodige regeleinden vermindert vaak hoe agressief AutoFit de tekst moet verkleinen.

**Heeft het wijzigen van het thema‑lettertype of het activeren van lettertype‑substitutie invloed op de AutoFit‑resultaten?**

Ja. Het vervangen door een lettertype met andere glyph‑metriek verandert de breedte/hoogte van de tekst, wat de uiteindelijke lettergrootte en regelafbreking kan wijzigen. Na elke wijziging of substitutie van een lettertype moet je de dia's opnieuw controleren.