---
title: Rechthoeken toevoegen aan presentaties in PHP
linktitle: Rechthoek
type: docs
weight: 80
url: /nl/php-java/rectangle/
keywords:
- rechthoek toevoegen
- rechthoek maken
- rechthoekvorm
- eenvoudige rechthoek
- opgemaakte rechthoek
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Verbeter uw PowerPoint-presentaties door rechthoeken toe te voegen met Aspose.Slides voor PHP via Java — ontwerp en wijzig vormen eenvoudig programmatisch."
---
## **Overzicht**

Dit artikel laat zien hoe je rechthoekvormen aan PowerPoint-dia's kunt toevoegen met Aspose.Slides. Het behandelt het maken van een eenvoudige rechthoek, het maken van een opgemaakte rechthoek, en het opslaan van de bijgewerkte presentatie als een PPTX‑bestand.

Je ziet ook hoe je basisopmaak voor rechthoeken toepast, zoals een effen vulkleur, lijnkleur en lijndikte. Bovendien verwijst de FAQ van het artikel naar gerelateerde rechthoek‑taken, waaronder afgeronde hoeken, afbeeldingsvullingen, visuele effecten, hyperlinks, vormvergrendelingen, exportopties en effectieve eigenschappen.

## **Voeg een rechthoek toe aan een dia**
Om een eenvoudige rechthoek toe te voegen aan een geselecteerde dia van de presentatie, volg je de onderstaande stappen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation)-klasse aan.
- Verkrijg de referentie van een dia door zijn Index te gebruiken.
- Voeg een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) van het type Rectangle toe met behulp van de [addAutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/#addAutoShape)-methode van het [ShapeCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/) object.
- Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een eenvoudige rechthoek toegevoegd aan de eerste dia van de presentatie.

```php
  # Instantieer de Presentation-klasse die de PPTX vertegenwoordigt
  $pres = new Presentation();
  try {
    # Verkrijg de eerste dia
    $sld = $pres->getSlides()->get_Item(0);
    # Voeg een AutoShape van type ellips toe
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Schrijf het PPTX-bestand naar de schijf
    $pres->save("RecShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Voeg een opgemaakte rechthoek toe aan een dia**
Om een opgemaakte rechthoek toe te voegen aan een dia, volg je de onderstaande stappen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation)-klasse aan.
- Verkrijg de referentie van een dia door zijn Index te gebruiken.
- Voeg een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) van het type Rectangle toe met behulp van de [addAutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/#addAutoShape)-methode van het [ShapeCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/) object.
- Stel het [Fill Type](https://reference.aspose.com/slides/nl/php-java/aspose.slides/FillType)-type van de rechthoek in op Solid.
- Stel de kleur van de rechthoek in met behulp van de [ColorFormat::setColor](https://reference.aspose.com/slides/nl/php-java/aspose.slides/colorformat/#setColor)-methode die wordt blootgesteld door het [FillFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fillformat/) object dat gekoppeld is aan het [Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/) object.
- Stel de kleur van de lijnen van de rechthoek in.
- Stel de breedte van de lijnen van de rechthoek in.
- Schrijf de gewijzigde presentatie weg als PPTX‑bestand.

De bovenstaande stappen zijn geïmplementeerd in het onderstaande voorbeeld.

```php
  # Instantieer de Presentation-klasse die de PPTX vertegenwoordigt
  $pres = new Presentation();
  try {
    # Verkrijg de eerste dia
    $sld = $pres->getSlides()->get_Item(0);
    # Voeg een AutoShape van ellips type toe
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 150, 150, 50);
    # Pas enige opmaak toe op ellipsvorm
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    # Pas enige opmaak toe op de lijn van de ellips
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Schrijf het PPTX-bestand naar de schijf
    $pres->save("RecShp2.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Hoe voeg ik een rechthoek met afgeronde hoeken toe?**

Gebruik het [shape type](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapetype/) met afgeronde hoeken en pas de hoekradius aan in de eigenschappen van de vorm; afronding kan ook per hoek worden toegepast via geometrie‑aanpassingen.

**Hoe vul ik een rechthoek met een afbeelding (textuur)?**

Selecteer het afbeeldings‑[fill type](https://reference.aspose.com/slides/nl/php-java/aspose.slides/filltype/), lever de afbeeldingsbron en configureer de [stretching/tiling modes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/picturefillmode/).

**Kan een rechthoek schaduw en gloed hebben?**

Ja. [Outer/inner shadow, glow, and soft edges](/slides/nl/php-java/shape-effect/) zijn beschikbaar met instelbare parameters.

**Kan ik een rechthoek omzetten in een knop met een hyperlink?**

Ja. [Assign a hyperlink](/slides/nl/php-java/manage-hyperlinks/) aan de klik van de vorm (ga naar een dia, bestand, webadres of e‑mail).

**Hoe kan ik een rechthoek beschermen tegen verplaatsen en wijzigingen?**

Gebruik vormvergrendelingen: je kunt verplaatsen, formaat wijzigen, selectie of tekstbewerking verbieden om de lay‑out te behouden.

**Kan ik een rechthoek omzetten naar een rasterafbeelding of SVG?**

Ja. Je kunt de vorm [renderen](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#getImage) naar een afbeelding met een opgegeven grootte/schaal of deze [exporteren als SVG](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/writeassvg/) voor vectorgebruik.

**Hoe krijg ik snel de daadwerkelijke (effectieve) eigenschappen van een rechthoek terug, rekening houdend met thema en overerving?**

[Use the shape’s effective properties](/slides/nl/php-java/shape-effective-properties/): de API geeft berekende waarden terug die rekening houden met themastijlen, layout en lokale instellingen, waardoor de formatteeranalyse vereenvoudigd wordt.