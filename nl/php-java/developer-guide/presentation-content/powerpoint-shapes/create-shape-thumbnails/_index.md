---
title: Miniaturen van presentatievormen maken in PHP
linktitle: Vormminiaturen
type: docs
weight: 70
url: /nl/php-java/create-shape-thumbnails/
keywords:
- vormminiatuur
- vormafbeelding
- vorm weergeven
- vormrendering
- visuele grenzen
- vormgrenzen
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Genereer hoogwaardige vormminiaturen van PowerPoint-dia’s met Aspose.Slides voor PHP via Java – maak en exporteer eenvoudig presentatie-miniaturen."
---
## **Introductie**

Aspose.Slides wordt gebruikt om presentatiebestanden te maken waarbij elke pagina een dia is. Deze dia’s kunnen worden bekeken door de presentatiebestanden te openen met Microsoft PowerPoint. Maar soms moeten ontwikkelaars de afbeeldingen van de vormen afzonderlijk bekijken in een afbeeldingsviewer. In dergelijke gevallen helpt Aspose.Slides u miniatuurafbeeldingen van de dia‑vormen te genereren. Hoe u deze functie gebruikt, wordt in dit artikel beschreven.

Dit artikel legt uit hoe u dia‑miniaturen op verschillende manieren kunt genereren:

- Een miniatuur van een vorm genereren binnen een dia.
- Een miniatuur van een vorm genereren voor een dia‑vorm met door de gebruiker gedefinieerde afmetingen.
- Een miniatuur van een vorm genereren binnen de grenzen van de weergave van een vorm.

## **Genereer een vorm‑miniatuur vanuit een dia**

Om een vorm‑miniatuur van een willekeurige dia te genereren met Aspose.Slides voor PHP via Java, doet u het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation)-klasse.
1. Verkrijg de referentie van een willekeurige dia met behulp van de ID of index.
1. [Haal de miniatuurafbeelding van de vorm op](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#getImage) van de referentie‑dia op standaardschaal.
1. Sla de miniatuurafbeelding op in het door u gewenste afbeeldingsformaat.

Dit voorbeeld toont hoe u een vorm‑miniatuur van een dia genereert:

```php
  # Instantieer een Presentation‑klasse die het presentatie‑bestand vertegenwoordigt
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Maak een afbeelding op volledige schaal
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage();
    # Sla de afbeelding op schijf op in PNG‑formaat
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

## **Genereer een miniatuur met door de gebruiker gedefinieerde schaalfactor**

Om de vorm‑miniatuur van een dia te genereren met Aspose.Slides voor PHP via Java, doet u het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation)-klasse.
1. Verkrijg de referentie van een willekeurige dia met behulp van de ID of index.
1. [Haal de miniatuurafbeelding van de vorm op](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#getImage) van de referentie‑dia met door de gebruiker gedefinieerde afmetingen.
1. Sla de miniatuurafbeelding op in het door u gewenste afbeeldingsformaat.

Dit voorbeeld toont hoe u een vorm‑miniatuur genereert op basis van een gedefinieerde schaalfactor:

```php
  # Instantieer een Presentation‑klasse die het presentatie‑bestand vertegenwoordigt
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Maak een afbeelding op volledige schaal
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Shape, 1, 1);
    # Sla de afbeelding op schijf op in PNG‑formaat
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

## **Maak een op grenzen gebaseerde weergave‑miniatuur van een vorm**

Deze methode om miniaturen van vormen te maken stelt ontwikkelaars in staat een miniatuur te genereren binnen de grenzen van de weergave van een vorm. Hierbij worden alle vormeffecten meegenomen. De gegenereerde vorm‑miniatuur wordt beperkt door de dia‑grenzen. Om een miniatuur van een dia‑vorm binnen de grens van zijn weergave te genereren, doet u het volgende:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation)-klasse.
1. Verkrijg de referentie van een willekeurige dia met behulp van de ID of index.
1. Haal de miniatuurafbeelding van de referentie‑dia op met vormgrenzen als weergave.
1. Sla de miniatuurafbeelding op in het door u gewenste afbeeldingsformaat.

Dit voorbeeld is gebaseerd op de bovenstaande stappen:

```php
  # Instantieer een Presentation-klasse die het presentatiedossier vertegenwoordigt
  $pres = new Presentation("Thumbnail.pptx");
  try {
    # Maak een afbeelding op volledige schaal
    $slideImage = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getImage(ShapeThumbnailBounds->Appearance, 1, 1);
    # Sla de afbeelding op schijf op in PNG-formaat
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

## **Haal de werkelijke zichtbare grenzen van een vorm op**

De frame‑eigenschappen van [Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/)—`Shape::getX()`, `Shape::getY()`, `Shape::getWidth()` en `Shape::getHeight()`—beschrijven het rechthoekige gebied dat in het presentatiemodel is opgeslagen. De inhoud die daadwerkelijk gerenderd wordt, kan buiten dat frame uitsteken of een ander rechthoekig gebied innemen. Rotatie, contouren, pijlpuntjes, tekstindeling en overflow, gegenereerde SmartArt‑geometrie en andere render‑effecten kunnen het bezette gebied allemaal wijzigen.

Gebruik [Shape::getVisualBounds](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#getVisualBounds) om dat bezette gebied te berekenen zonder een afbeelding te maken. De methode retourneert een [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) in dia‑coördinaten. Het geretourneerde rechthoekige gebied wordt niet bijgesneden tot de dia, zodat de coördinaten negatief kunnen zijn wanneer de inhoud buiten het dia‑origineel uitstrekt.

Het volgende voorbeeld haalt de frame‑ en visual‑bounds op en vergelijkt ze:

```php
  $presentation = new Presentation("example.pptx");
  try {
      $slide = $presentation->getSlides()->get_Item(0);
      $shape = $slide->getShapes()->get_Item(0);

      $visualBounds = $shape->getVisualBounds();

      $frameX = $shape->getX();
      $frameY = $shape->getY();
      $frameWidth = $shape->getWidth();
      $frameHeight = $shape->getHeight();

      $visualX = $visualBounds->getX();
      $visualY = $visualBounds->getY();
      $visualWidth = $visualBounds->getWidth();
      $visualHeight = $visualBounds->getHeight();

      echo "Frame bounds (x, y, width, height): $frameX, $frameY, $frameWidth, $frameHeight\n";
      echo "Visual bounds (x, y, width, height): $visualX, $visualY, $visualWidth, $visualHeight\n";
  } finally {
      $presentation->dispose();
  }
```

Dezelfde [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) kan worden gebruikt om nabije vormen uit te lijnen langs de linker-, rechter-, boven- of onderkant; om voldoende ruimte te reserveren in een gegenereerde lay-out; of om inhoud buiten een toegestane regio te detecteren. Visual‑bounds zijn vooral nuttig voor SmartArt, tekstvakken, pijlen, afbeeldingen, geroteerde vormen en groepsvormen, waar het opgeslagen frame niet het volledige gerenderde resultaat weergeeft.

Gebruik [Shape::getVisualBounds](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#getVisualBounds) wanneer u coördinaten voor lay-out of validatie nodig hebt en geen bitmap nodig heeft. Gebruik [Shape::getImage](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#getImage) wanneer u de vorm wilt renderen. Met [ShapeThumbnailBounds](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapethumbnailbounds/), `ShapeThumbnailBounds::Shape` past de afbeelding aan op basis van de vormgrenzen, inclusief contourinstellingen, terwijl `ShapeThumbnailBounds::Appearance` de afbeelding aanpast op basis van de weergave van de vorm en het resultaat beperkt tot de dia‑grenzen. Daarentegen retourneert `Shape::getVisualBounds` alleen het berekende rechthoekige gebied en snijdt het niet bij tot de dia.

## **FAQ**

**Welke afbeeldingsformaten kunnen worden gebruikt bij het opslaan van vorm‑miniaturen?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/nl/php-java/aspose.slides/imageformat/), en andere. Vormen kunnen ook worden [geëxporteerd als vector‑SVG](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/writeassvg/) door de inhoud van de vorm op te slaan als SVG.

**Wat is het verschil tussen Shape‑ en Appearance‑grenzen bij het renderen van een miniatuur?**

`Shape` gebruikt de geometrie van de vorm; `Appearance` houdt rekening met [visual effects](/slides/nl/php-java/shape-effect/) (schaduwen, gloed, enz.).

**Wat gebeurt er als een vorm als verborgen is gemarkeerd? Wordt er nog steeds een miniatuur gerenderd?**

Een verborgen vorm blijft deel van het model en kan worden gerenderd; de verborgen‑vlag beïnvloedt alleen de weergave van de diavoorstelling maar voorkomt niet dat de afbeelding van de vorm wordt gegenereerd.

**Worden groepsvormen, grafieken, SmartArt en andere complexe objecten ondersteund?**

Ja. Elk object dat wordt weergegeven als [Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/) (inclusief [GroupShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/nl/php-java/aspose.slides/chart/) en [SmartArt](https://reference.aspose.com/slides/nl/php-java/aspose.slides/smartart/)) kan worden opgeslagen als miniatuur of als SVG.

**Hebben systeem‑geïnstalleerde lettertypen invloed op de kwaliteit van miniaturen voor tekstvormen?**

Ja. U moet [de vereiste lettertypen beschikbaar stellen](/slides/nl/php-java/custom-font/) (of [lettertype‑substitutie configureren](/slides/nl/php-java/font-substitution/)) om ongewenste fallback‑ en tekst‑reflow‑problemen te voorkomen.