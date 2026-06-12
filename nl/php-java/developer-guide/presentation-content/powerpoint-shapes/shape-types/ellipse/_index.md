---
title: Voeg ellipsen toe aan presentaties in PHP
linktitle: Ellips
type: docs
weight: 30
url: /nl/php-java/ellipse/
keywords:
- ellips
- vorm
- ellips toevoegen
- ellips maken
- ellips tekenen
- opgemaakte ellips
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u ellipsvormen kunt maken, opmaken en bewerken in Aspose.Slides voor PHP via Java in PPT- en PPTX-presentaties — met code-voorbeelden."
---
## **Overzicht**

Dit artikel laat zien hoe u ellipsvormen aan PowerPoint‑dia’s kunt toevoegen met behulp van Aspose.Slides. Het behandelt het maken van een eenvoudige ellips, het maken van een opgemaakte ellips, en het opslaan van de bijgewerkte presentatie als een PPTX‑bestand. Het raakt ook gerelateerde vragen, zoals het werken met de positie en grootte van een ellips, het regelen van de stapelvolgorde en het toepassen van animatie‑effecten.

## **Maak een ellips**
Om een eenvoudige ellips toe te voegen aan een geselecteerde dia van de presentatie, volgt u de onderstaande stappen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation)‑klasse aan.
- Verkrijg de referentie van een dia door zijn Index te gebruiken.
- Voeg een AutoShape van het type Ellipse toe met behulp van de [addAutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/#addAutoShape)‑methode die wordt aangeboden door het [ShapeCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/)‑object.
- Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een ellips toegevoegd aan de eerste dia

```php
  # Instancieer de Presentation-klasse die de PPTX vertegenwoordigt
  $pres = new Presentation();
  try {
    # Haal de eerste dia op
    $sld = $pres->getSlides()->get_Item(0);
    # Voeg een AutoShape van het type ellips toe
    $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Schrijf het PPTX-bestand naar schijf
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Maak een opgemaakte ellips**
Om een beter opgemaakte ellips aan een dia toe te voegen, volgt u de onderstaande stappen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation)‑klasse aan.
- Verkrijg de referentie van een dia door zijn Index te gebruiken.
- Voeg een AutoShape van het type Ellipse toe met behulp van de [addAutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/#addAutoShape)‑methode die wordt aangeboden door het [ShapeCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/)‑object.
- Stel het vultype van de ellips in op Solid.
- Stel de kleur van de ellips in met behulp van de `SolidFillColor::setColor`‑methode die beschikbaar is via het [FillFormat](https://reference.aspose.com/slides/nl/php-java/aspose.slides/fillformat/)‑object dat is gekoppeld aan het [Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/)‑object.
- Stel de kleur van de lijnen van de ellips in.
- Stel de breedte van de lijnen van de ellips in.
- Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een opgemaakte ellips toegevoegd aan de eerste dia van de presentatie.

```php
  # Instancieer de Presentation-klasse die de PPTX vertegenwoordigt
  $pres = new Presentation();
  try {
    # Haal de eerste dia op
    $sld = $pres->getSlides()->get_Item(0);
    # Voeg een AutoShape van het type ellips toe
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Ellipse, 50, 150, 150, 50);
    # Pas enige opmaak toe op de ellipsvorm
    $shp->getFillFormat()->setFillType(FillType::Solid);
    $shp->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Chocolate));
    # Pas enige opmaak toe op de lijn van de ellips
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);
    $shp->getLineFormat()->setWidth(5);
    # Schrijf het PPTX-bestand naar schijf
    $pres->save("EllipseShp1.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Hoe stel ik de exacte positie en grootte van een ellips in ten opzichte van de eenheden van de dia?**

Coördinaten en afmetingen worden doorgaans **in points** gespecificeerd. Voor voorspelbare resultaten baseert u uw berekeningen op de dia-grootte en converteert u de benodigde millimeters of inches naar points voordat u de waarden toewijst.

**Hoe kan ik een ellips boven of onder andere objecten plaatsen (stapelvolgorde regelen)?**

Pas de tekenvolgorde van het object aan door het naar voren te brengen of naar achteren te sturen. Hierdoor kan de ellips andere objecten overlappen of die eronder liggen onthullen.

**Hoe animeer ik het verschijnen of de nadruk van een ellips?**

[Apply](/slides/nl/php-java/shape-animation/) binnenkomst-, nadruk- of uitgangseffecten op de vorm, en configureer triggers en timing om te bepalen wanneer en hoe de animatie wordt afgespeeld.