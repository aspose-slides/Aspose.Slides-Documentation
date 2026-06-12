---
title: Verbeter uw presentaties met AutoFit in Java
linktitle: Autofit-instellingen
type: docs
weight: 30
url: /nl/java/manage-autofit-settings/
keywords:
- tekstvak
- autofit
- niet automatisch aanpassen
- tekst laten passen
- tekst krimpen
- tekst omwikkelen
- vormgrootte aanpassen
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u de AutoFit-instellingen in Aspose.Slides voor Java kunt beheren om de weergave van tekst in uw PowerPoint- en OpenDocument-presentaties te optimaliseren en de leesbaarheid van de inhoud te verbeteren."
---
## **Inleiding**

Standaard, wanneer je een tekstvak toevoegt, gebruikt Microsoft PowerPoint de **Resize shape to fix text** instelling voor het tekstvak – hij past automatisch de grootte van het tekstvak aan om te garanderen dat de tekst er altijd in past. 

![tekstvak-in-powerpoint](textbox-in-powerpoint.png)

* Wanneer de tekst in het tekstvak langer of groter wordt, vergroot PowerPoint automatisch het tekstvak – het verhoogt de hoogte – zodat er meer tekst in past. 
* Wanneer de tekst in het tekstvak korter of kleiner wordt, verkleint PowerPoint automatisch het tekstvak – het verlaagt de hoogte – om overtollige ruimte weg te nemen. 

In PowerPoint zijn dit de 4 belangrijke parameters of opties die het autofit‑gedrag voor een tekstvak regelen:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-opties-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for Java biedt vergelijkbare opties—enkele eigenschappen onder de [TextFrameFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/TextFrameFormat)‑klasse—die je in staat stellen het autofit‑gedrag voor tekstvakken in presentaties te beheersen. 

## **Grootte van vorm aanpassen aan tekst**

Als je wilt dat de tekst in een vak altijd in dat vak past nadat er wijzigingen in de tekst zijn aangebracht, moet je de **Resize shape to fix text**‑optie gebruiken. Om deze instelling te specificeren, stel je de [AutofitType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/TextFrameFormat#getAutofitType--) eigenschap (van de [TextFrameFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/TextFrameFormat) klasse) in op `Shape`.

![altijdpassen-instelling-powerpoint](alwaysfit-setting-powerpoint.png)

Deze Java‑code toont hoe je kunt aangeven dat tekst altijd in zijn vak moet passen in een PowerPoint‑presentatie:

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

Als de tekst langer of groter wordt, wordt het tekstvak automatisch aangepast (verhoogt in hoogte) zodat alle tekst erin past. Wordt de tekst korter, gebeurt het tegenovergestelde. 

## **Niet automatisch aanpassen**

Als je wilt dat een tekstvak of vorm zijn afmetingen behoudt, ongeacht de wijzigingen in de tekst die het bevat, moet je de **Do not Autofit**‑optie gebruiken. Om deze instelling te specificeren, stel je de [AutofitType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/TextFrameFormat#getAutofitType--) eigenschap (van de [TextFrameFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/TextFrameFormat) klasse) in op `None`. 

![niet-autofit-instelling-powerpoint](donotautofit-setting-powerpoint.png)

Deze Java‑code toont hoe je kunt aangeven dat een tekstvak altijd zijn afmetingen behoudt in een PowerPoint‑presentatie:

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

Wanneer de tekst te lang wordt voor het vak, loopt deze over. 

## **Tekst krimpen bij overflow**

Als een tekst te lang wordt voor het vak, kun je via de **Shrink text on overflow**‑optie aangeven dat de grootte en regelafstand van de tekst moeten worden verkleind zodat deze in het vak past. Om deze instelling te specificeren, stel je de [AutofitType](https://reference.aspose.com/slides/nl/java/com.aspose.slides/TextFrameFormat#getAutofitType--) eigenschap (van de [TextFrameFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/TextFrameFormat) klasse) in op `Normal`.

![tekstkrimpenbijoverflow-instelling-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Deze Java‑code toont hoe je kunt aangeven dat tekst moet worden gekrimpeld bij overflow in een PowerPoint‑presentatie:

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
Wanneer de **Shrink text on overflow**‑optie wordt gebruikt, wordt de instelling alleen toegepast wanneer de tekst te lang wordt voor het vak. 
{{% /alert %}}

## **Tekst omwikkelen in vorm**

Als je wilt dat de tekst in een vorm wordt afgebroken binnen die vorm wanneer de tekst de rand van de vorm (alleen breedte) overschrijdt, moet je de **Wrap text in shape**‑parameter gebruiken. Om deze instelling te specificeren, moet je de [WrapText](https://reference.aspose.com/slides/nl/java/com.aspose.slides/TextFrameFormat#getWrapText--) eigenschap (van de [TextFrameFormat](https://reference.aspose.com/slides/nl/java/com.aspose.slides/TextFrameFormat) klasse) op `true` instellen. 

Deze Java‑code toont hoe je de Wrap Text‑instelling gebruikt in een PowerPoint‑presentatie:

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
Als je de `WrapText`‑eigenschap op `False` zet voor een vorm, wordt de tekst bij een langere inhoud dan de breedte van de vorm buiten de randen van de vorm doorgetrokken op één regel. 
{{% /alert %}}

## **FAQ**

**Hebben de interne marges van het tekstframe invloed op AutoFit?**

Ja. Opvulling (interne marges) verkleint het bruikbare gebied voor tekst, waardoor AutoFit eerder ingrijpt – de lettergrootte wordt verkleind of de vorm eerder aangepast. Controleer en pas de marges aan voordat je AutoFit afstemt.

**Hoe werkt AutoFit samen met handmatige en zachte regeleinden?**

Geforceerde regeleinden blijven behouden, en AutoFit past de lettergrootte en regelafstand eromheen aan. Het verwijderen van onnodige regeleinden vermindert vaak de mate waarin AutoFit de tekst moet verkleinen.

**Heeft het wijzigen van het themalek of het activeren van font‑substitutie invloed op de AutoFit‑resultaten?**

Ja. Het vervangen door een lettertype met andere glyph‑metrieën verandert de breedte/hoogte van de tekst, wat de uiteindelijke lettergrootte en regeleindes kan beïnvloeden. Na elke wijziging of substitutie van een lettertype, controleer de dia’s opnieuw.