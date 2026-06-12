---
title: Beheer presentatievormen in PHP
linktitle: Vormmanipulatie
type: docs
weight: 40
url: /nl/php-java/shape-manipulations/
keywords:
- PowerPoint-vorm
- presentatievorm
- vorm op dia
- vorm vinden
- vorm klonen
- vorm verwijderen
- vorm verbergen
- vormvolgorde wijzigen
- Interop-vorm-ID ophalen
- alternatieve tekst van vorm
- vormlayoutformaten
- vorm als SVG
- vorm naar SVG
- vorm uitlijnen
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u vormen kunt maken, bewerken en optimaliseren in Aspose.Slides for PHP via Java en hoogwaardige PowerPoint-presentaties kunt leveren."
---
## **Overzicht**

Dit artikel legt uit hoe u met vormen in presentaties kunt werken met Aspose.Slides. Het laat zien hoe u een vorm op een dia kunt vinden, dupliceren, verwijderen, verbergen, de volgorde kunt wijzigen, de Interop‑vorm‑ID kunt ophalen en alternatieve tekst kunt instellen voor identificatie en verdere verwerking.

Het behandelt ook hoe u layoutformaten voor vormen kunt benaderen, een vorm kunt renderen als SVG, vormen op een dia kunt uitlijnen en spiegelings‑eigenschappen kunt gebruiken voor horizontale en verticale spiegeling. Bovendien bevat het artikel een korte FAQ over het combineren van vormen, stapelvolgorde en het vergrendelen van vormen.

## **Een vorm op een dia vinden**
Dit onderwerp beschrijft een eenvoudige techniek om het voor ontwikkelaars makkelijker te maken een specifieke vorm op een dia te vinden zonder de interne Id te gebruiken. Het is belangrijk te weten dat PowerPoint‑presentatiebestanden geen manier hebben om vormen op een dia te identificeren, behalve via een interne unieke Id. Het blijkt moeilijk voor ontwikkelaars om een vorm te vinden met behulp van die interne unieke Id. Alle vormen die aan de dia's worden toegevoegd hebben enige alternatieve tekst. We raden ontwikkelaars aan de alternatieve tekst te gebruiken om een specifieke vorm te vinden. U kunt MS PowerPoint gebruiken om de alternatieve tekst voor objecten te definiëren die u later wilt wijzigen.

Na het instellen van de alternatieve tekst van een gewenste vorm, kunt u die presentatie openen met Aspose.Slides for PHP via Java en door alle aan een dia toegevoegde vormen itereren. Tijdens elke iteratie kunt u de alternatieve tekst van de vorm controleren; de vorm met overeenkomende alternatieve tekst is dan de gewenste vorm. Om deze techniek beter te demonstreren, hebben we een methode gemaakt, [findShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideUtil#findShape-com.aspose.slides.IBaseSlide-java.lang.String-) die de truc uitvoert om een specifieke vorm op een dia te vinden en vervolgens simpelweg die vorm teruggeeft.

```php
  # Instantieer een Presentation-klasse die het presentatiebestand vertegenwoordigt
  $pres = new Presentation("FindingShapeInSlide.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Alternatieve tekst van de te vinden vorm
    $shape = findShape($slide, "Shape1");
    if (!java_is_null($shape)) {
      echo("Shape Name: " . $shape->getName());
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```
```php

```

## **Een vorm dupliceren**
Om een vorm te dupliceren naar een dia met Aspose.Slides for PHP via Java:

1. Maak een instantie van de klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) aan.
1. Verkrijg de referentie van een dia door de index te gebruiken.
1. Open de vormverzameling van de bron‑dia.
1. Voeg een nieuwe dia toe aan de presentatie.
1. Dupliceer vormen van de vormverzameling van de bron‑dia naar de nieuwe dia.
1. Sla de aangepaste presentatie op als een PPTX‑bestand.

Het onderstaande voorbeeld voegt een groepvorm toe aan een dia.

```php
  # Instantieer Presentation-klasse
  $pres = new Presentation("Source Frame.pptx");
  try {
    $sourceShapes = $pres->getSlides()->get_Item(0)->getShapes();
    $blankLayout = $pres->getMasters()->get_Item(0)->getLayoutSlides()->getByType(SlideLayoutType::Blank);
    $destSlide = $pres->getSlides()->addEmptySlide($blankLayout);
    $destShapes = $destSlide->getShapes();
    $destShapes->addClone($sourceShapes->get_Item(1), 50, 150 + $sourceShapes->get_Item(0)->getHeight());
    $destShapes->addClone($sourceShapes->get_Item(2));
    $destShapes->insertClone(0, $sourceShapes->get_Item(0), 50, 150);
    # Schrijf het PPTX-bestand naar schijf
    $pres->save("CloneShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Een vorm verwijderen**
Aspose.Slides for PHP via Java stelt ontwikkelaars in staat elke vorm te verwijderen. Om een vorm van een dia te verwijderen, volg de onderstaande stappen:

1. Maak een instantie van [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) aan.
1. Open de eerste dia.
1. Zoek de vorm met specifieke AlternativeText.
1. Verwijder de vorm.
1. Sla het bestand op naar schijf.

```php
  # Maak Presentation-object
  $pres = new Presentation();
  try {
    # Haal de eerste dia op
    $sld = $pres->getSlides()->get_Item(0);
    # Voeg een autovorm van rechthoektype toe
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $altText = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item(0);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $sld->getShapes()->remove($ashp);
      }
    }
    # Sla de presentatie op naar schijf
    $pres->save("RemoveShape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Een vorm verbergen**
Aspose.Slides for PHP via Java stelt ontwikkelaars in staat elke vorm te verbergen. Om een vorm van een dia te verbergen, volg de onderstaande stappen:

1. Maak een instantie van [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) aan.
1. Open de eerste dia.
1. Zoek de vorm met specifieke AlternativeText.
1. Verberg de vorm.
1. Sla het bestand op naar schijf.

```php
  # Instantieer Presentation-klasse die de PPTX vertegenwoordigt
  $pres = new Presentation();
  try {
    # Haal de eerste dia op
    $sld = $pres->getSlides()->get_Item(0);
    # Voeg een autovorm van rechthoektype toe
    $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $alttext = "User Defined";
    $iCount = $sld->getShapes()->size();
    for($i = 0; $i < java_values($iCount) ; $i++) {
      $ashp = $sld->getShapes()->get_Item($i);
      if ($alttext->equals($ashp->getAlternativeText())) {
        $ashp->setHidden(true);
      }
    }
    # Sla de presentatie op naar schijf
    $pres->save("Hiding_Shapes_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Vormvolgorde wijzigen**
Aspose.Slides for PHP via Java stelt ontwikkelaars in staat de volgorde van vormen te wijzigen. Het herschikken van vormen bepaalt welke vorm voorop staat en welke achterop. Om de volgorde van vormen op een dia te wijzigen, volg de onderstaande stappen:

1. Maak een instantie van [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) aan.
1. Open de eerste dia.
1. Voeg een vorm toe.
1. Voeg wat tekst toe in het tekstkader van de vorm.
1. Voeg nog een vorm toe met dezelfde coördinaten.
1. Herschik de vormen.
1. Sla het bestand op naar schijf.

```php
  $pres = new Presentation("ChangeShapeOrder.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 365, 400, 150);
    $shp3->getFillFormat()->setFillType(FillType::NoFill);
    $shp3->addTextFrame(" ");
    $para = $shp3->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $para->getPortions()->get_Item(0);
    $portion->setText("Watermark Text Watermark Text Watermark Text");
    $shp3 = $slide->getShapes()->addAutoShape(ShapeType::Triangle, 200, 365, 400, 150);
    $slide->getShapes()->reorder(2, $shp3);
    $pres->save("Reshape_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Interop‑vorm‑ID ophalen**
Aspose.Slides for PHP via Java stelt ontwikkelaars in staat een unieke vorm‑identificatie binnen de dia‑scope te verkrijgen, in tegenstelling tot de [getUniqueId](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/getuniqueid/)‑methode, die een unieke identificatie binnen de presentatie‑scope oplevert. De methode [getOfficeInteropShapeId](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/getofficeinteropshapeid/) is respectievelijk toegevoegd aan de klasse [Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/). De waarde die wordt geretourneerd door de [getOfficeInteropShapeId](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/getofficeinteropshapeid/)‑methode komt overeen met de Id‑waarde van het Microsoft.Office.Interop.PowerPoint.Shape‑object. Hieronder staat een voorbeeldcode.

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    # Unieke vormidentificatie verkrijgen binnen de diascope
    $officeInteropShapeId = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->getOfficeInteropShapeId();
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Alternatieve tekst voor een vorm instellen**
Aspose.Slides for PHP via Java stelt ontwikkelaars in staat de AlternateText van elke vorm in te stellen.  
Vormen in een presentatie kunnen worden onderscheiden aan de hand van de `Alternative Text` of de [Shape Name](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/setname/)‑methode.  
De methoden [setAlternativeText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/setalternativetext/) en [getAlternativeText](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/getalternativetext/) kunnen worden gelezen of ingesteld met zowel Aspose.Slides als Microsoft PowerPoint.  
Met deze methode kunt u een vorm taggen en verschillende bewerkingen uitvoeren, zoals het verwijderen, verbergen of herschikken van vormen op een dia.  
Om de AlternateText van een vorm in te stellen, volg de onderstaande stappen:

1. Maak een instantie van [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) aan.
1. Open de eerste dia.
1. Voeg een willekeurige vorm toe aan de dia.
1. Werk met de nieuw toegevoegde vorm.
1. Doorloop de vormen om een specifieke vorm te vinden.
1. Stel de AlternativeText in.
1. Sla het bestand op naar schijf.

```php
  # Instantieer Presentation-klasse die de PPTX vertegenwoordigt
  $pres = new Presentation();
  try {
    # Haal de eerste dia op
    $sld = $pres->getSlides()->get_Item(0);
    # Voeg een autovorm van rechthoektype toe
    $shp1 = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 40, 150, 50);
    $shp2 = $sld->getShapes()->addAutoShape(ShapeType::Moon, 160, 40, 150, 50);
    $shp2->getFillFormat()->setFillType(FillType::Solid);
    $shp2->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->GRAY);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      $shape = $sld->getShapes()->get_Item($i);
      if (!java_is_null($shape)) {
        $shape->setAlternativeText("User Defined");
      }
    }
    # Sla de presentatie op naar schijf
    $pres->save("Set_AlternativeText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Layout‑formaten voor een vorm benaderen**
Aspose.Slides for PHP via Java biedt een eenvoudige API om layout‑formaten voor een vorm te benaderen. Dit artikel toont hoe u layout‑formaten kunt benaderen.

Hieronder staat een voorbeeldcode.

```php
  $pres = new Presentation("pres.pptx");
  try {
    foreach($pres->getLayoutSlides() as $layoutSlide) {
      foreach($layoutSlide->getShapes() as $shape) {
        $fillFormats = $shape->getFillFormat();
        $lineFormats = $shape->getLineFormat();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Een vorm renderen als SVG**
Nu ondersteunt Aspose.Slides for PHP via Java het renderen van een vorm als SVG. De methode [writeAsSvg](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/writeassvg/) (en de overload) is toegevoegd aan de klasse [Shape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/). Deze methode maakt het mogelijk de inhoud van de vorm op te slaan als een SVG‑bestand. De code‑fragment hieronder laat zien hoe u de vorm van een dia naar een SVG‑bestand exporteert.

```php
  $pres = new Presentation("TestExportShapeToSvg.pptx");
  try {
    $stream = new Java("java.io.FileOutputStream", "SingleShape.svg");
    try {
      $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0)->writeAsSvg($stream);
    } finally {
      if (!java_is_null($stream)) {
        $stream->close();
      }
    }
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Een vorm uitlijnen**
Aspose.Slides maakt het mogelijk vormen uit te lijnen ten opzichte van de dia‑marges of ten opzichte van elkaar. Hiervoor is de overloaded methode [SlidesUtil::alignShapes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideutil/alignshapes/) toegevoegd. De enumeratie [ShapesAlignmentType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapesalignmenttype/) definieert de mogelijke uitlijningsopties.

**Voorbeeld 1**

De broncode hieronder lijn de vormen met indices 1, 2 en 4 uit langs de bovenrand van de dia uit.

```php
  $pres = new Presentation("example.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    $shape1 = $slide->getShapes()->get_Item(1);
    $shape2 = $slide->getShapes()->get_Item(2);
    $shape3 = $slide->getShapes()->get_Item(4);
    SlideUtil->alignShapes(ShapesAlignmentType::AlignTop, true, $pres->getSlides()->get_Item(0), array($slide->getShapes()->indexOf($shape1), $slide->getShapes()->indexOf($shape2), $slide->getShapes()->indexOf($shape3) ));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

**Voorbeeld 2**

Het voorbeeld hieronder toont hoe u de volledige verzameling vormen kunt uitlijnen ten opzichte van de onderste vorm in de verzameling.

```php
  $pres = new Presentation("example.pptx");
  try {
    SlideUtil->alignShapes(ShapesAlignmentType::AlignBottom, false, $pres->getSlides()->get_Item(0));
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Flip‑eigenschappen**
In Aspose.Slides biedt de klasse [ShapeFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapeframe/) controle over horizontale en verticale spiegeling van vormen via de eigenschappen `flipH` en `flipV`. Beide eigenschappen zijn van het type [NullableBool](https://reference.aspose.com/slides/nl/php-java/aspose.slides/nullablebool/) en kunnen de waarden `True` (spiegeling), `False` (geen spiegeling) of `NotDefined` (standaardgedrag) bevatten. Deze waarden zijn toegankelijk via het [Frame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#getFrame) van een vorm.

Om de flip‑instellingen aan te passen, wordt een nieuw [ShapeFrame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapeframe/)‑object gecreëerd met de huidige positie en grootte van de vorm, de gewenste waarden voor `flipH` en `flipV` en de rotatiehoek. Door dit object toe te wijzen aan het [Frame](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#getFrame) van de vorm en de presentatie op te slaan, worden de spiegeltransformaties toegepast en in het uitvoerbestand vastgelegd.

Stel, we hebben een bestand sample.pptx waarin de eerste dia een enkele vorm bevat met standaard flip‑instellingen, zoals hieronder weergegeven.

![The shape to be flipped](shape_to_be_flipped.png)

De volgende code‑voorbeeld haalt de huidige flip‑eigenschappen van de vorm op en spiegelt deze zowel horizontaal als verticaal.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    // Haal de horizontale flip‑eigenschap van de vorm op.
    $horizontalFlip = $shape->getFrame()->getFlipH();
    echo "Horizontal flip: ", $horizontalFlip, "\n";

    // Haal de verticale flip‑eigenschap van de vorm op.
    $verticalFlip = $shape->getFrame()->getFlipV();
    echo "Vertical flip: ", $verticalFlip, "\n";

    $x = $shape->getFrame()->getX();
    $y = $shape->getFrame()->getY();
    $width = $shape->getFrame()->getWidth();
    $height = $shape->getFrame()->getHeight();
    $flipH = NullableBool::True; // Flip horizontaal.
    $flipV = NullableBool::True; // Flip horizontaal.
    $rotation = $shape->getFrame()->getRotation();

    $shape->setFrame(new ShapeFrame($x, $y, $width, $height, $flipH, $flipV, $rotation));

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Het resultaat:

![The flipped shape](flipped_shape.png)

## **FAQ**

**Kan ik vormen (union/intersect/subtract) op een dia combineren zoals in een desktop‑editor?**

Er is geen ingebouwde Boolean‑operatie‑API. U kunt dit benaderen door zelf de gewenste omtrek te construeren — bijvoorbeeld de resulterende geometrie berekenen via [GeometryPath](https://reference.aspose.com/slides/nl/php-java/aspose.slides/geometrypath/) en een nieuwe vorm met dat contour aanmaken, eventueel de originele vormen verwijderen.

**Hoe kan ik de stapelvolgorde (z‑order) regelen zodat een vorm altijd "bovenop" blijft?**

Wijzig de invoeg‑/verplaatsvolgorde binnen de [shapes](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseslide/#getShapes)‑collectie van de dia. Voor voorspelbare resultaten, stel de z‑order definitief in nadat alle andere bewerkingen op de dia zijn uitgevoerd.

**Kan ik een vorm "vergrendelen" om te voorkomen dat gebruikers deze in PowerPoint kunnen bewerken?**

Ja. Stel vorm‑specifieke beschermingsvlaggen in (bijv. selectie, verplaatsing, grootte wijzigen, tekst bewerken). Indien nodig, kunt u ook beperkingen op het master‑ of layout‑niveau toepassen. Let op: dit is een UI‑bescherming, geen beveiligingsfunctie; voor sterkere bescherming combineert u dit met bestands‑niveau restricties zoals lees‑alleen‑aanbevelingen of wachtwoorden.