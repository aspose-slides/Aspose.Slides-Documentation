---
title: Verbeter uw presentaties met AutoFit in PHP
linktitle: Autofit-instellingen
type: docs
weight: 30
url: /nl/php-java/manage-autofit-settings/
keywords:
- tekstvak
- autofit
- niet autofit
- tekst passend
- tekst verkleinen
- tekst afbreken
- vorm aanpassen
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Beheer AutoFit-instellingen in Aspose.Slides voor PHP om de weergave van tekst in uw PowerPoint- en OpenDocument-presentaties te optimaliseren en de leesbaarheid van de inhoud te verbeteren."
---
## **Inleiding**

Standaard, wanneer je een tekstvak toevoegt, gebruikt Microsoft PowerPoint de instelling **Resize shape to fix text** voor het tekstvak – hij past de grootte van het tekstvak automatisch aan zodat de tekst er altijd in past. 

![tekstvak-in-powerpoint](textbox-in-powerpoint.png)

* Wanneer de tekst in het tekstvak langer of groter wordt, vergroot PowerPoint het tekstvak – het verhoogt de hoogte – zodat er meer tekst in past.  
* Wanneer de tekst in het tekstvak korter of kleiner wordt, verkleint PowerPoint het tekstvak – het verlaagt de hoogte – om overtollige ruimte weg te nemen.  

In PowerPoint zijn dit de 4 belangrijke parameters of opties die het autofit‑gedrag van een tekstvak bepalen:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-opties-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for PHP via Java biedt soortgelijke opties – een aantal eigenschappen onder de [TextFrameFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/TextFrameFormat)‑klasse – waarmee je het autofit‑gedrag van tekstvakken in presentaties kunt regelen.

## **Resize a Shape to Fit Text**

Als je wilt dat de tekst in een vak altijd in dat vak past nadat de tekst gewijzigd is, moet je de optie **Resize shape to fix text** gebruiken. Om deze instelling te specificeren, stel je de [AutofitType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/TextFrameFormat#getAutofitType--)‑eigenschap (van de [TextFrameFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/TextFrameFormat)‑klasse) in op `Shape`.

![alwaysfit-instelling-powerpoint](alwaysfit-setting-powerpoint.png)

Deze PHP‑code toont hoe je aangeeft dat een tekst altijd in zijn vak moet passen in een PowerPoint‑presentatie:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Shape);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Wordt de tekst langer of groter, dan wordt het tekstvak automatisch vergroot (hoogte verhoogd) zodat alle tekst erin past. Wordt de tekst korter, gebeurt het tegenovergestelde. 

## **Do Not Autofit**

Als je wilt dat een tekstvak of vorm zijn afmetingen behoudt, ongeacht de wijzigingen in de tekst, moet je de optie **Do not Autofit** gebruiken. Om deze instelling te specificeren, stel je de [AutofitType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/TextFrameFormat#getAutofitType--)‑eigenschap (van de [TextFrameFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/TextFrameFormat)‑klasse) in op `None`.

![donotautofit-instelling-powerpoint](donotautofit-setting-powerpoint.png)

Deze PHP‑code toont hoe je aangeeft dat een tekstvak altijd zijn afmetingen moet behouden in een PowerPoint‑presentatie:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::None);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

Wordt de tekst te lang voor zijn vak, dan loopt deze buiten het vak.

## **Shrink Text on Overflow**

Als een tekst te lang wordt voor zijn vak, kun je via de optie **Shrink text on overflow** aangeven dat de tekstgrootte en -spatiëring moeten worden verkleind zodat de tekst in het vak past. Om deze instelling te specificeren, stel je de [AutofitType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/TextFrameFormat#getAutofitType--)‑eigenschap (van de [TextFrameFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/TextFrameFormat)‑klasse) in op `Normal`.

![shrinktextonoverflow-instelling-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Deze PHP‑code toont hoe je aangeeft dat een tekst moet worden verkleind bij overflow in een PowerPoint‑presentatie:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setAutofitType(TextAutofitType::Normal);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Info" color="info" %}}
Wanneer de optie **Shrink text on overflow** wordt gebruikt, wordt de instelling alleen toegepast wanneer de tekst te lang wordt voor zijn vak. 
{{% /alert %}}

## **Wrap Text**

Als je wilt dat de tekst in een vorm wordt afgebroken binnen die vorm wanneer de tekst de breedte van de vorm overschrijdt, moet je de parameter **Wrap text in shape** gebruiken. Om deze instelling te specificeren, moet je de [WrapText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/TextFrameFormat#getWrapText--)‑eigenschap (van de [TextFrameFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/TextFrameFormat)‑klasse) instellen op `true`.

Deze PHP‑code toont hoe je de Wrap Text‑instelling gebruikt in een PowerPoint‑presentatie:

```php
  $pres = new Presentation();
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 30, 30, 350, 100);
    $portion = new Portion("lorem ipsum...");
    $portion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $portion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->add($portion);
    $textFrameFormat = $autoShape->getTextFrame()->getTextFrameFormat();
    $textFrameFormat::setWrapText(NullableBool::True);
    $pres->save("Output-presentation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 
Als je de `WrapText`‑eigenschap voor een vorm op `False` zet, wordt de tekst bij een grotere breedte dan de vorm voortgezet buiten de grenzen van de vorm op één enkele regel. 
{{% /alert %}}

## **FAQ**

**Beïnvloeden de interne marges van het tekstkader AutoFit?**

Ja. Padding (interne marges) verkleint de bruikbare ruimte voor tekst, waardoor AutoFit eerder wordt geactiveerd – de lettergrootte wordt verkleind of de vorm eerder aangepast. Controleer en pas de marges aan voordat je AutoFit afstemt.

**Hoe werkt AutoFit met handmatige en zachte regeleinden?**

Geforceerde regeleinden blijven behouden, en AutoFit past de lettergrootte en spatiëring hieromheen aan. Het verwijderen van onnodige regeleinden verkleint vaak de mate waarin AutoFit de tekst moet verkleinen.

**Heeft het wijzigen van het thema‑lettertype of het toepassen van lettertype‑substitutie invloed op de AutoFit‑resultaten?**

Ja. Substitutie naar een lettertype met andere glyph‑metingen verandert de breedte/hoogte van de tekst, wat de uiteindelijke lettergrootte en regelafbreking kan wijzigen. Na elke wijziging of substitutie van het lettertype moet je de dia’s opnieuw controleren.