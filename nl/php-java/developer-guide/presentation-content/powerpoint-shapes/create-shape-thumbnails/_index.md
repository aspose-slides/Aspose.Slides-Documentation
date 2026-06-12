---
title: Miniaturen van presentatievormen maken in PHP
linktitle: Vormminiaturen
type: docs
weight: 70
url: /nl/php-java/create-shape-thumbnails/
keywords:
- vormminiatuur
- vormafbeelding
- vorm renderen
- vormrendering
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Genereer hoogwaardige vormminiaturen van PowerPoint-dia's met Aspose.Slides for PHP via Java - maak eenvoudig presentatieminiaturen aan en exporteer ze."
---
## **Inleiding**

Aspose.Slides wordt gebruikt om presentatiedocumenten te maken waarbij elke pagina een dia is. Deze dia's kunnen bekeken worden door de presentatiedocumenten te openen met Microsoft PowerPoint. Maar soms moeten ontwikkelaars de afbeeldingen van de vormen afzonderlijk bekijken in een afbeeldingsviewer. In zulke gevallen helpt Aspose.Slides u miniatuurafbeeldingen van de dia‑vormen te genereren. Hoe u deze functie gebruikt, wordt in dit artikel beschreven.  
Dit artikel legt uit hoe u dia‑miniaturen op verschillende manieren kunt genereren:

- Een vorm‑miniatuur genereren binnen een dia.  
- Een vorm‑miniatuur genereren voor een dia‑vorm met door de gebruiker opgegeven afmetingen.  
- Een vorm‑miniatuur genereren binnen de grenzen van de weergave van een vorm.

## **Een vorm‑miniatuur genereren vanuit een dia**
Om een vorm‑miniatuur van een willekeurige dia te genereren met Aspose.Slides for PHP via Java, doet u het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation)‑klasse.  
1. Verkrijg de referentie van een willekeurige dia met behulp van de ID of de index.  
1. [Haal de vorm‑miniatuur op](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#getImage) van de referentie‑dia op met de standaardschaal.  
1. Sla de miniatuurafbeelding op in het door u gewenste afbeeldingformaat.

Deze voorbeeldcode laat zien hoe u een vorm‑miniatuur van een dia genereert:

```php
  # Instantieer een Presentation-klasse die het presentatiebestand vertegenwoordigt
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Maak een afbeelding op volledige schaal
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # Sla de afbeelding op schijf in PNG-formaat
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Een miniatuur met door de gebruiker gedefinieerde schaalfactor genereren**
Om de vorm‑miniatuur van een dia te genereren met Aspose.Slides for PHP via Java, doet u het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation)‑klasse.  
1. Verkrijg de referentie van een willekeurige dia met behulp van de ID of de index.  
1. [Haal de vorm‑miniatuur op](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#getImage) van de referentie‑dia met door de gebruiker opgegeven afmetingen.  
1. Sla de miniatuurafbeelding op in het door u gewenste afbeeldingformaat.

Deze voorbeeldcode laat zien hoe u een vorm‑miniatuur op basis van een gedefinieerde schaalfactor genereert:

```php
  # Instantieer een Presentation-klasse die het presentatiebestand vertegenwoordigt
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Maak een afbeelding op volledige schaal
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # Sla de afbeelding op schijf in PNG-formaat
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Een vorm‑miniatuur op basis van de weergave‑grenzen maken**
Deze methode om miniaturen van vormen te maken stelt ontwikkelaars in staat om een miniatuur te genereren binnen de grenzen van de weergave van de vorm. Hierbij worden alle vorm‑effecten meegenomen. De gegenereerde vorm‑miniatuur wordt beperkt door de dia‑grenzen. Om een miniatuur van een dia‑vorm binnen de grenzen van de weergave te genereren, doet u het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation)‑klasse.  
1. Verkrijg de referentie van een willekeurige dia met behulp van de ID of de index.  
1. Haal de miniatuur van de referentie‑dia op met vorm‑grenzen als weergave.  
1. Sla de miniatuurafbeelding op in het door u gewenste afbeeldingformaat.

Deze voorbeeldcode is gebaseerd op de bovenstaande stappen:

```php
  # Instantieer een Presentation-klasse die het presentatiebestand vertegenwoordigt
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Maak een afbeelding op volledige schaal
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # Sla de afbeelding op schijf in PNG-formaat
    try {
      $slideImage->save("output.png", ImageFormat::Png);
    } finally {
      if (!java_is_null($slideImage)) {
        $slideImage->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Welke afbeeldingsformaten kunnen worden gebruikt bij het opslaan van vorm‑miniaturen?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imageformat/), en andere. Vormen kunnen ook worden [geëxporteerd als vector‑SVG](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/writeassvg/) door de inhoud van de vorm op te slaan als SVG.

**Wat is het verschil tussen Shape‑ en Appearance‑grenzen bij het renderen van een miniatuur?**

`Shape` gebruikt de geometrie van de vorm; `Appearance` houdt rekening met [visual effects](/slides/nl/php-java/shape-effect/) (schaduwen, gloed, enz.).

**Wat gebeurt er als een vorm als verborgen gemarkeerd is? Wordt deze nog steeds gerenderd als miniatuur?**

Een verborgen vorm blijft deel uitmaken van het model en kan worden gerenderd; de verborgen‑vlag beïnvloedt de weergave van de diavoorstelling maar voorkomt niet dat de afbeelding van de vorm wordt gegenereerd.

**Worden groepsvormen, diagrammen, SmartArt en andere complexe objecten ondersteund?**

Ja. Elk object dat wordt weergegeven als [Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/) (inclusief [GroupShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/) en [SmartArt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartart/)) kan worden opgeslagen als een miniatuur of als SVG.

**Beïnvloeden systeem‑geïnstalleerde lettertypen de kwaliteit van miniaturen voor tekstvormen?**

Ja. U moet [de vereiste lettertypen leveren](/slides/nl/php-java/custom-font/) (of [lettertype‑substituties configureren](/slides/nl/php-java/font-substitution/)) om ongewenste terugvallen en tekst‑herindelingen te voorkomen.