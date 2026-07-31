---
title: Lijnen toevoegen aan presentaties in PHP
linktitle: Lijn
type: docs
weight: 50
url: /nl/php-java/line/
keywords:
- lijn
- lijn maken
- lijn toevoegen
- eenvoudige lijn
- lijn configureren
- lijn aanpassen
- stippellijnstijl
- pijlkop
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u de opmaak van lijnen in PowerPoint presentaties kunt manipuleren met Aspose.Slides for PHP via Java. Ontdek eigenschappen, methoden en voorbeelden."
---
## **Overzicht**

Aspose.Slides stelt u in staat om lijnvormen toe te voegen aan PowerPoint‑dia’s via code. Dit artikel laat zien hoe u een eenvoudige lijn maakt en hoe u een lijn kunt aanpassen zodat deze als een pijl wordt weergegeven.

U leert hoe u een lijnvorm aan een dia toevoegt, het uiterlijk aanpast en de bijgewerkte presentatie opslaat. De voorbeelden richten zich op praktische lijnopmaakinstellingen zoals stijl, breedte, stippellijnpatroon, pijlpuntenopties en vulkleur.

## **Maak een eenvoudige lijn**

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation)‑klasse.  
- Krijg de referentie van een dia door zijn Index te gebruiken.  
- Voeg een AutoShape van het type Line toe met de [addAutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/#addAutoShape)‑methode die wordt blootgesteld door het [ShapeCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/)‑object.  
- Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een lijn toegevoegd aan de eerste dia van de presentatie.

```php
  # Instantie van PresentationEx-klasse die het PPTX-bestand voorstelt
  $pres = new Presentation();
  try {
    # Haal de eerste dia op
    $sld = $pres->getSlides()->get_Item(0);
    # Voeg een AutoShape van type lijn toe
    $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Schrijf de PPTX naar schijf
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Maak een pijlvormige lijn**

Aspose.Slides for PHP via Java stelt ontwikkelaars bovendien in staat enkele eigenschappen van de lijn te configureren zodat deze er aantrekkelijker uitziet. Laten we een paar eigenschappen van een lijn configureren om deze eruit te laten zien als een pijl. Volg de onderstaande stappen om dit te doen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation)‑klasse.  
- Krijg de referentie van een dia door zijn Index te gebruiken.  
- Voeg een AutoShape van het type Line toe met de [addAutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/#addAutoShape)‑methode die wordt blootgesteld door het [ShapeCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapecollection/)‑object.  
- Stel de [Line Style](https://reference.aspose.com/slides/nl/php-java/aspose.slides/LineStyle) in op een van de stijlen die Aspose.Slides for PHP via Java biedt.  
- Stel de Breedte van de lijn in.  
- Stel de [Dash Style](https://reference.aspose.com/slides/nl/php-java/aspose.slides/LineDashStyle) van de lijn in op een van de door Aspose.Slides for PHP via Java aangeboden stijlen.  
- Stel de [Arrow Head Style](https://reference.aspose.com/slides/nl/php-java/aspose.slides/LineArrowheadStyle) en [Length](https://reference.aspose.com/slides/nl/php-java/aspose.slides/LineArrowheadLength) van het startpunt van de lijn in.  
- Stel de [Arrow Head Style](https://reference.aspose.com/slides/nl/php-java/aspose.slides/LineArrowheadStyle) en [Length](https://reference.aspose.com/slides/nl/php-java/aspose.slides/LineArrowheadLength) van het eindpunt van de lijn in.  
- Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

```php
  # Instantie van PresentationEx-klasse die het PPTX-bestand voorstelt
  $pres = new Presentation();
  try {
    # Haal de eerste dia op
    $sld = $pres->getSlides()->get_Item(0);
    # Voeg een AutoShape van type lijn toe
    $shp = $sld->getShapes()->addAutoShape(ShapeType::Line, 50, 150, 300, 0);
    # Pas enkele opmaak toe op de lijn
    $shp->getLineFormat()->setStyle(LineStyle->ThickBetweenThin);
    $shp->getLineFormat()->setWidth(10);
    $shp->getLineFormat()->setDashStyle(LineDashStyle->DashDot);
    $shp->getLineFormat()->setBeginArrowheadLength(LineArrowheadLength->Short);
    $shp->getLineFormat()->setBeginArrowheadStyle(LineArrowheadStyle->Oval);
    $shp->getLineFormat()->setEndArrowheadLength(LineArrowheadLength->Long);
    $shp->getLineFormat()->setEndArrowheadStyle(LineArrowheadStyle->Triangle);
    $shp->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $shp->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(new java("java.awt.Color", PresetColor->Maroon));
    # Schrijf de PPTX naar schijf
    $pres->save("LineShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Kan ik een gewone lijn omzetten naar een connector zodat deze "klikt" op vormen?**

Nee. Een gewone lijn (een [AutoShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/) van het type [Line](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shapetype/)) wordt niet automatisch een connector. Om deze op vormen te laten klikken, gebruikt u het specifieke [Connector](https://reference.aspose.com/slides/nl/php-java/aspose.slides/connector/)‑type en de [corresponding APIs](/slides/nl/php-java/connector/) voor verbindingen.

**Wat moet ik doen als de eigenschappen van een lijn geërfd zijn van het thema en het moeilijk is de uiteindelijke waarden te bepalen?**

[Read the effective properties](/slides/nl/php-java/shape-effective-properties/) via de `LineFormatEffectiveData`/`LineFillFormatEffectiveData`—deze houden al rekening met overerving en themastijlen.

**Kan ik een lijn vergrendelen tegen bewerken (verplaatsen, grootte wijzigen)?**

Ja. Vormen bieden [lock objects](https://reference.aspose.com/slides/nl/php-java/aspose.slides/autoshape/getautoshapelock/) die het mogelijk maken bewerkingsbewerkingen te verbieden.