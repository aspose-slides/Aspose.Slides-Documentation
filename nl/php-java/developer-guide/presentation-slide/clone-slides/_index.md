---
title: Dia's van presentaties klonen in PHP
linktitle: Dia's klonen
type: docs
weight: 35
url: /nl/php-java/clone-slides/
keywords:
- dia klonen
- dia kopiëren
- dia opslaan
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Dupliceer PowerPoint-dia's snel met Aspose.Slides voor PHP. Volg onze duidelijke code-voorbeelden om PPT-creatie in enkele seconden te automatiseren en handmatig werk te elimineren."
---
## **Introductie**

Klonen is het proces waarbij een exacte kopie of replica van iets wordt gemaakt. Aspose.Slides for PHP via Java maakt het ook mogelijk om een kopie of kloon van een willekeurige dia te maken en die gekloonde dia vervolgens in de huidige of een andere geopende presentatie in te voegen. Het proces van dia‑klonen creëert een nieuwe dia die door ontwikkelaars kan worden aangepast zonder de oorspronkelijke dia te wijzigen. Er zijn verschillende mogelijke manieren om een dia te klonen:

- Kloon aan het einde binnen een presentatie.
- Kloon op een andere positie binnen een presentatie.
- Kloon aan het einde in een andere presentatie.
- Kloon op een andere positie in een andere presentatie.
- Kloon op een specifieke positie in een andere presentatie.

In Aspose.Slides for PHP via Java biedt (een verzameling [Slide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Slide) objecten) die door het [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) object wordt blootgesteld, de methoden [addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#addClone) en [insertClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#insertClone) om de bovenstaande soorten dia‑klonen uit te voeren

## **Kloon een dia aan het einde van een presentatie**
Als u een dia wilt klonen en deze vervolgens in hetzelfde presentatie‑bestand aan het einde van de bestaande dia’s wilt gebruiken, gebruik dan de [addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#addClone)‑methode volgens de onderstaande stappen:

1. Maak een exemplaar van de klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) aan.  
1. Haal het object [SlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation/#getSlides) op door te verwijzen naar de dia‑collectie die door het [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) object wordt blootgesteld.  
1. Roep de [addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#addClone)‑methode aan die door het [SlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation/#getSlides) object wordt blootgesteld en geef de te klonen dia door als parameter aan de [addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#addClone)‑methode.  
1. Schrijf het gewijzigde presentatie‑bestand weg.

In het onderstaande voorbeeld hebben we een dia gekloond (die zich op de eerste positie – nulindex – van de presentatie bevond) naar het einde van de presentatie.

```php
  # Maak een instantie van de Presentation‑klasse die een presentatiedossier representeert
  $pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
  try {
    # Kloon de gewenste dia naar het einde van de collectie dia's in dezelfde presentatie
    $slds = $pres->getSlides();
    $slds->addClone($pres->getSlides()->get_Item(0));
    # Schrijf de gewijzigde presentatie naar schijf
    $pres->save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Kloon een dia naar een andere positie binnen een presentatie**
Als u een dia wilt klonen en deze vervolgens in hetzelfde presentatie‑bestand maar op een andere positie wilt gebruiken, gebruik dan de [insertClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#insertClone)‑methode:

1. Maak een exemplaar van de klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) aan.  
1. Haal het object [SlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection) op door te verwijzen naar de [**Slides**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation/#getSlides) collectie die door het [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) object wordt blootgesteld.  
1. Roep de [insertClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#insertClone)‑methode aan die door het [SlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation/#getSlides) object wordt blootgesteld en geef de te klonen dia samen met de index voor de nieuwe positie door als parameter aan de [insertClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#insertClone)‑methode.  
1. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een dia gekloond (die zich op nulindex – positie 1 – van de presentatie bevond) naar index 1 – positie 2 – van de presentatie.

```php
  # Instantieer de Presentation‑klasse die een presentatiedossier representeert
  $pres = new Presentation("CloneWithInSamePresentation.pptx");
  try {
    # Kloon de gewenste dia naar het einde van de collectie dia's in dezelfde presentatie
    $slds = $pres->getSlides();
    # Kloon de gewenste dia naar de opgegeven index in dezelfde presentatie
    $slds->insertClone(2, $pres->getSlides()->get_Item(1));
    # Schrijf de gewijzigde presentatie naar schijf
    $pres->save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Kloon een dia aan het einde van een andere presentatie**
Als u een dia uit een presentatie moet klonen en deze in een andere presentatie‑bestand aan het einde van de bestaande dia’s wilt gebruiken:

1. Maak een exemplaar van de klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) aan die de presentatie bevat waarvan de dia wordt gekloond.  
1. Maak een exemplaar van de klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) aan die de bestemmingspresentatie bevat waaraan de dia zal worden toegevoegd.  
1. Haal het object [SlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection) op door te verwijzen naar de [**Slides**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation/#getSlides) collectie die door het Presentation‑object van de bestemmingspresentatie wordt blootgesteld.  
1. Roep de [addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#addClone)‑methode aan die door het [SlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation/#getSlides) object wordt blootgesteld en geef de dia uit de bronpresentatie door als parameter aan de [addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#addClone)‑methode.  
1. Schrijf het gewijzigde bestemmingspresentatie‑bestand weg.

In het onderstaande voorbeeld hebben we een dia gekloond (van de eerste index van de bronpresentatie) naar het einde van de bestemmingspresentatie.

```php
  # Instantieer de Presentation‑klasse om het bron‑presentatiedossier te laden
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Instantieer de Presentation‑klasse voor de bestemmings‑PPTX (waar de dia gekloond wordt)
    $destPres = new Presentation();
    try {
      # Kloon de gewenste dia van de bronpresentatie naar het einde van de collectie dia's in de bestemmingspresentatie
      $slds = $destPres->getSlides();
      $slds->addClone($srcPres->getSlides()->get_Item(0));
      # Schrijf de bestemmingspresentatie naar schijf
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Kloon een dia naar een andere positie in een andere presentatie**
Als u een dia uit een presentatie moet klonen en deze in een andere presentatiedocument op een specifieke positie wilt gebruiken:

1. Maak een exemplaar van de klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) aan die de bronpresentatie bevat waarvan de dia wordt gekloond.  
1. Maak een exemplaar van de klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) aan die de presentatie bevat waaraan de dia wordt toegevoegd.  
1. Haal de klasse [SlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation/#getSlides) op door te verwijzen naar de Slides‑collectie die door het Presentation‑object van de bestemmingspresentatie wordt blootgesteld.  
1. Roep de [insertClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#insertClone)‑methode aan die door het [SlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation/#getSlides) object wordt blootgesteld en geef de dia uit de bronpresentatie samen met de gewenste positie door als parameter aan de [insertClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#insertClone)‑methode.  
1. Schrijf het gewijzigde bestemmingspresentatie‑bestand weg.

In het onderstaande voorbeeld hebben we een dia gekloond (van nulindex van de bronpresentatie) naar index 1 (positie 2) van de bestemmingspresentatie.

```php
  # Instantieer de Presentation‑klasse om het bron‑presentatiedossier te laden
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Instantieer de Presentation‑klasse voor de bestemmings‑PPTX (waar de dia gekloond wordt)
    $destPres = new Presentation();
    try {
      # Kloon de gewenste dia van de bronpresentatie naar het einde van de collectie dia's in de bestemmingspresentatie
      $slds = $destPres->getSlides();
      $slds->insertClone(2, $srcPres->getSlides()->get_Item(0));
      # Schrijf de bestemmingspresentatie naar schijf
      $destPres->save("Aspose2_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Kloon een dia op een specifieke positie in een andere presentatie**
Als u een dia met een masterslide uit één presentatie moet klonen en in een andere presentatie wilt gebruiken, moet u eerst de gewenste masterslide van de bronpresentatie naar de bestemmingspresentatie klonen. Daarna moet u die masterslide gebruiken om de dia met masterslide te klonen. De [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/addclone/) verwacht een masterslide uit de bestemmingspresentatie in plaats van uit de bronpresentatie. Volg de onderstaande stappen om een dia met een master te klonen:

1. Maak een exemplaar van de klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) aan die de bronpresentatie bevat waarvan de dia wordt gekloond.  
1. Maak een exemplaar van de klasse [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) aan die de bestemmingspresentatie bevat waaraan de dia wordt gekloond.  
1. Toegang tot de te klonen dia samen met de masterslide.  
1. Instantiateer de klasse [MasterSlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/MasterSlideCollection) door te verwijzen naar de Masters‑collectie die door het [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) object van de bestemmingspresentatie wordt blootgesteld.  
1. Roep de [addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#addClone)‑methode aan die door het [MasterSlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/MasterSlideCollection) object wordt blootgesteld en geef de master uit de bron‑PPTX door als parameter aan de [addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#addClone)‑methode.  
1. Instantiateer de klasse [SlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation/#getSlides) door een verwijzing naar de Slides‑collectie in te stellen die door het [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) object van de bestemmingspresentatie wordt blootgesteld.  
1. Roep de [addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#addClone)‑methode aan die door het [SlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation/#getSlides) object wordt blootgesteld en geef de te klonen dia uit de bronpresentatie en de masterslide door als parameter aan de [addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#addClone)‑methode.  
1. Schrijf het gewijzigde bestemmingspresentatie‑bestand weg.

In het onderstaande voorbeeld hebben we een dia met een master gekloond (die zich op nulindex van de bronpresentatie bevond) naar het einde van de bestemmingspresentatie met gebruik van een master van de brondia.

```php
  # Instantieer de Presentation‑klasse om het bron‑presentatiedossier te laden
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # Instantieer de Presentation‑klasse voor de bestemmingspresentatie (waar de dia gekloond wordt)
    $destPres = new Presentation();
    try {
      # Instantieer ISlide uit de collectie dia's in de bronpresentatie samen met
      # de masterslide
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Kloon de gewenste masterslide van de bronpresentatie naar de collectie masters in de
      # bestemmingspresentatie
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Kloon de gewenste masterslide van de bronpresentatie naar de collectie masters in de
      # bestemmingspresentatie
      $iSlide = $masters->addClone($SourceMaster);
      # Kloon de gewenste dia van de bronpresentatie met de gewenste master naar het einde van de
      # collectie dia's in de bestemmingspresentatie
      $slds = $destPres->getSlides();
      $slds->addClone($SourceSlide, $iSlide, true);
      # Sla de bestemmingspresentatie op naar schijf
      $destPres->save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat::Pptx);
    } finally {
      $destPres->dispose();
    }
  } finally {
    $srcPres->dispose();
  }
```

## **Kloon een dia aan het einde van een opgegeven sectie**
Als u een dia wilt klonen en deze vervolgens in hetzelfde presentatie‑bestand maar in een andere sectie wilt gebruiken, gebruik dan de [addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#addClone)‑methode die door de klasse [SlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection) wordt blootgesteld. Aspose.Slides for PHP via Java maakt het mogelijk om een dia uit de eerste sectie te klonen en die gekloonde dia in de tweede sectie van dezelfde presentatie in te voegen.

De volgende code‑fragment laat zien hoe u een dia kunt klonen en de gekloonde dia in een opgegeven sectie kunt invoegen.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # Sla de bestemmingspresentatie op naar schijf
    $presentation->save($dataDir . "CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **FAQ**

**Worden notities voor de spreker en beoordelingscommentaren gekloond?**

Ja. De notitiepagina en beoordelingscommentaren worden opgenomen in de kloon. Als u ze niet wilt, [verwijder ze](/slides/nl/php-java/presentation-notes/) na het invoegen.

**Hoe worden grafieken en hun gegevensbronnen behandeld?**

Het grafiekobject, de opmaak en de ingesloten gegevens worden gekopieerd. Als de grafiek was gekoppeld aan een externe bron (bijv. een OLE‑ingesloten werkmap), blijft die koppeling behouden als een [OLE‑object](/slides/nl/php-java/manage-ole/). Na het verplaatsen tussen bestanden, controleer de beschikbaarheid van de gegevens en het verversingsgedrag.

**Kan ik de invoegpositie en secties voor de kloon bepalen?**

Ja. U kunt de kloon invoegen op een specifieke dia‑index en deze plaatsen in een gekozen [sectie](/slides/nl/php-java/slide-section/). Als de doelsectie niet bestaat, maak deze dan eerst aan en verplaats de dia ernaartoe.