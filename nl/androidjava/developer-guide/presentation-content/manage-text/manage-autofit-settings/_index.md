---
title: Verbeter je presentaties met AutoFit op Android
linktitle: Autofit-instellingen
type: docs
weight: 30
url: /nl/androidjava/manage-autofit-settings/
keywords:
- tekstvak
- autofit
- niet autofit
- tekst passend maken
- tekst verkleinen
- tekst afbreken
- vorm aanpassen
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheer Autofit-instellingen in Aspose.Slides voor Android via Java om de weergave van tekst in uw PowerPoint- en OpenDocument-presentaties te optimaliseren en de leesbaarheid van de inhoud te verbeteren."
---
## **Inleiding**

Standaard, wanneer je een tekstvak toevoegt, gebruikt Microsoft PowerPoint de instelling **Resize shape to fix text** voor het tekstvak — hij past automatisch de grootte van het tekstvak aan zodat de tekst er altijd in past.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Wanneer de tekst in het tekstvak langer of groter wordt, vergroot PowerPoint automatisch het tekstvak — het verhoogt de hoogte — zodat het meer tekst kan bevatten.  
* Wanneer de tekst in het tekstvak korter of kleiner wordt, verkleint PowerPoint automatisch het tekstvak — het verlaagt de hoogte — om overbodige ruimte weg te nemen.  

In PowerPoint zijn dit de 4 belangrijke parameters of opties die het autofit‑gedrag voor een tekstvak regelen:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Android via Java biedt vergelijkbare opties — enkele eigenschappen onder de [TextFrameFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/TextFrameFormat)‑klasse — die je in staat stellen het autofit‑gedrag voor tekstvakken in presentaties te regelen.

## **Formaat van een vorm aanpassen aan tekst**

Als je wilt dat de tekst in een vak altijd in dat vak past nadat er wijzigingen zijn aangebracht, moet je de optie **Resize shape to fix text** gebruiken. Om deze instelling te specificeren, stel je de eigenschap [AutofitType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (van de [TextFrameFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/TextFrameFormat)‑klasse) in op `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Deze Java‑code laat zien hoe je aangeeft dat een tekst altijd in zijn vak moet passen in een PowerPoint‑presentatie:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Shape);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Als de tekst langer of groter wordt, wordt het tekstvak automatisch vergroot (hoogte toename) zodat alle tekst erin past. Als de tekst korter wordt, gebeurt het omgekeerde.

## **Do Not Autofit**

Als je wilt dat een tekstvak of vorm zijn afmetingen behoudt, ongeacht de wijzigingen in de tekst die het bevat, moet je de optie **Do not Autofit** gebruiken. Om deze instelling te specificeren, stel je de eigenschap [AutofitType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (van de [TextFrameFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/TextFrameFormat)‑klasse) in op `None`.

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Deze Java‑code laat zien hoe je aangeeft dat een tekstvak altijd zijn afmetingen moet behouden in een PowerPoint‑presentatie:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.None);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

Wanneer de tekst te lang wordt voor zijn vak, loopt hij over.

## **Shrink Text on Overflow**

Als een tekst te lang wordt voor zijn vak, kun je via de optie **Shrink text on overflow** aangeven dat de grootte en afstand van de tekst moet worden verkleind zodat deze in het vak past. Om deze instelling te specificeren, stel je de eigenschap [AutofitType](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/TextFrameFormat#getAutofitType--) (van de [TextFrameFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/TextFrameFormat)‑klasse) in op `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Deze Java‑code laat zien hoe je aangeeft dat een tekst moet worden verkleind bij overflow in een PowerPoint‑presentatie:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);
	
    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);
	
    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setAutofitType(TextAutofitType.Normal);
	
    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Info" color="info" %}}
Wanneer de optie **Shrink text on overflow** wordt gebruikt, wordt de instelling alleen toegepast wanneer de tekst te lang wordt voor zijn vak.
{{% /alert %}}

## **Wrap Text**

Als je wilt dat de tekst in een vorm wordt afgebroken binnen die vorm wanneer de tekst breder wordt dan de vorm (alleen breedte), moet je de parameter **Wrap text in shape** gebruiken. Om deze instelling te specificeren, moet je de eigenschap [WrapText](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/TextFrameFormat#getWrapText--) (van de [TextFrameFormat](https://reference.aspose.com/slides/nl/androidjava/com.aspose.slides/TextFrameFormat)‑klasse) instellen op `true`.

Deze Java‑code laat zien hoe je de Wrap Text‑instelling gebruikt in een PowerPoint‑presentatie:

```java
Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 30, 350, 100);

    Portion portion = new Portion("lorem ipsum...");
    portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().add(portion);

    ITextFrameFormat textFrameFormat = autoShape.getTextFrame().getTextFrameFormat();
    textFrameFormat.setWrapText(NullableBool.True);

    pres.save("Output-presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
Als je de eigenschap `WrapText` op `False` zet voor een vorm, dan wordt, wanneer de tekst in de vorm langer wordt dan de breedte van de vorm, de tekst buiten de vormranden doorgetrokken op één regel.
{{% /alert %}}

## **FAQ**

**Hebben de interne marges van het tekstframe invloed op AutoFit?**

Ja. Opvulling (interne marges) verkleint het bruikbare gebied voor tekst, waardoor AutoFit eerder wordt geactiveerd — de lettergrootte wordt verkleind of de vorm eerder aangepast. Controleer en pas de marges aan voordat je AutoFit afstemt.

**Hoe gaat AutoFit om met handmatige en zachte regeleinden?**

Geforceerde regeleinden blijven behouden, en AutoFit past de lettergrootte en afstand eromheen aan. Het verwijderen van onnodige regeleinden vermindert vaak hoe agressief AutoFit de tekst moet verkleinen.

**Heeft het wijzigen van het thematype of het activeren van lettertype‑substitutie invloed op de AutoFit‑resultaten?**

Ja. Het substitueren naar een lettertype met andere glyph‑metrieken verandert de tekstbreedte/hoogte, wat de uiteindelijke lettergrootte en regelafbreking kan beïnvloeden. Na elke wijziging of substitutie van een lettertype, controleer de dia's opnieuw.