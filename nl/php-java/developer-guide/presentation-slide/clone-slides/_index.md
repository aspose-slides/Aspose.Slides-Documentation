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
description: "Dupliceer PowerPoint-dia's snel met Aspose.Slides voor PHP. Volg onze duidelijke code-voorbeelden om PPT-creatie in seconden te automatiseren en handmatig werk te elimineren."
---
## **Inleiding**

Klonen is het proces waarbij een exacte kopie of replica van iets wordt gemaakt. Aspose.Slides for PHP via Java maakt het ook mogelijk om een kopie of kloon van elke dia te maken en die gekloonde dia vervolgens in de huidige of een andere geopende presentatie in te voegen. Het klonen van dia's creëert een nieuwe dia die door ontwikkelaars kan worden aangepast zonder de oorspronkelijke dia te wijzigen. Er zijn verschillende mogelijke manieren om een dia te klonen:

- Kloon aan het einde binnen een presentatie.
- Kloon op een andere positie binnen een presentatie.
- Kloon aan het einde in een andere presentatie.
- Kloon op een andere positie in een andere presentatie.
- Kloon op een specifieke positie in een andere presentatie.

In Aspose.Slides for PHP via Java, (een collectie van [Slide](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Slide) objecten) die door het [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) object wordt blootgesteld, biedt de [addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#addClone) en [insertClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#insertClone) methoden om de bovenstaande soorten dia‑klonen uit te voeren

## **Kloon een dia aan het einde van een presentatie**
Als u een dia wilt klonen en deze vervolgens in hetzelfde presentatie‑bestand aan het einde van de bestaande dia's wilt gebruiken, gebruik dan de [addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#addClone) methode volgens de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse aan.
2. Haal het object [SlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation/#getSlides) op door te verwijzen naar de dia‑collectie die door het [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) object wordt blootgesteld.
3. Roep de [addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#addClone) methode aan die door het [SlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation/#getSlides) object wordt blootgesteld en geef de te klonen dia als parameter aan de [addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#addClone) methode.
4. Schrijf het gewijzigde presentatie‑bestand weg.

In het onderstaande voorbeeld hebben we een dia (die zich op de eerste positie – index nul – van de presentatie bevindt) naar het einde van de presentatie gekloond.

```php
  # Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt
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
Als u een dia wilt klonen en deze vervolgens in hetzelfde presentatie‑bestand, maar op een andere positie wilt gebruiken, gebruik dan de [insertClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#insertClone) methode:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse aan.
2. Haal het object [SlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection) op door te verwijzen naar de [**Slides**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation/#getSlides) collectie die door het [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) object wordt blootgesteld.
3. Roep de [insertClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#insertClone) methode aan die door het [SlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation/#getSlides) object wordt blootgesteld en geef de te klonen dia samen met de index voor de nieuwe positie als parameter aan de [insertClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#insertClone) methode.
4. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

In het onderstaande voorbeeld hebben we een dia (die zich op index nul – positie 1 – van de presentatie bevindt) naar index 1 – positie 2 – van de presentatie gekloond.

```php
  # Instantieer de Presentation-klasse die een presentatiebestand vertegenwoordigt
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
Als u een dia uit één presentatie wilt klonen en deze in een andere presentatie‑bestand aan het einde van de bestaande dia's wilt plaatsen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse aan die de bronpresentatie bevat waaruit de dia wordt gekloond.
2. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse aan die de doelpresentatie bevat waaraan de dia wordt toegevoegd.
3. Haal het object [SlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection) op door te verwijzen naar de [**Slides**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation/#getSlides) collectie die door het Presentation‑object van de doelpresentatie wordt blootgesteld.
4. Roep de [addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#addClone) methode aan die door het [SlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation/#getSlides) object wordt blootgesteld en geef de dia uit de bronpresentatie als parameter aan de [addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#addClone) methode.
5. Schrijf het gewijzigde doel‑presentatiebestand weg.

In het onderstaande voorbeeld hebben we een dia (van de eerste index van de bronpresentatie) naar het einde van de doelpresentatie gekloond.

```php
  # Instantieer de Presentation-klasse om het bronpresentatiebestand te laden
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Instantieer de Presentation-klasse voor de bestemmings-PPTX (waar de dia gekloond moet worden)
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
Als u een dia uit één presentatie wilt klonen en deze in een andere presentatie‑bestand op een specifieke positie wilt plaatsen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse aan die de bronpresentatie bevat waaruit de dia wordt gekloond.
2. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse aan die de doelpresentatie bevat waaraan de dia wordt toegevoegd.
3. Haal de [SlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation/#getSlides) klasse op door te verwijzen naar de Slides‑collectie die door het Presentation‑object van de doelpresentatie wordt blootgesteld.
4. Roep de [insertClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#insertClone) methode aan die door het [SlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation/#getSlides) object wordt blootgesteld en geef de dia uit de bronpresentatie samen met de gewenste positie als parameter aan de [insertClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#insertClone) methode.
5. Schrijf het gewijzigde doel‑presentatiebestand weg.

In het onderstaande voorbeeld hebben we een dia (van index nul van de bronpresentatie) naar index 1 (positie 2) van de doelpresentatie gekloond.

```php
  # Instantieer de Presentation-klasse om het bronpresentatiebestand te laden
  $srcPres = new Presentation("CloneAtEndOfAnother.pptx");
  try {
    # Instantieer de Presentation-klasse voor de bestemmings-PPTX (waar de dia gekloond moet worden)
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
Als u een dia met bijbehorende masterdia uit één presentatie wilt klonen en deze in een andere presentatie wilt gebruiken, moet u eerst de gewenste masterdia van de bronpresentatie naar de doelpresentatie klonen. Vervolgens gebruikt u die masterdia om de dia met master te klonen. De [**addClone(Slide, MasterSlide, boolean)**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slidecollection/addclone/) verwacht een masterdia uit de doelpresentatie in plaats van uit de bronpresentatie. Volg de onderstaande stappen om een dia met master te klonen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse aan die de bronpresentatie bevat waaruit de dia wordt gekloond.
2. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) klasse aan die de doelpresentatie bevat waarnaar de dia wordt gekloond.
3. Open de te klonen dia samen met de masterdia.
4. Instantieer de [MasterSlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/MasterSlideCollection) klasse door te verwijzen naar de Masters‑collectie die door het [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) object van de doelpresentatie wordt blootgesteld.
5. Roep de [addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#addClone) methode aan die door het [MasterSlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/MasterSlideCollection) object wordt blootgesteld en geef de master uit de bron‑PPTX door als parameter aan de [addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#addClone) methode.
6. Instantieer de [SlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation/#getSlides) klasse door een verwijzing naar de Slides‑collectie die door het [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation) object van de doelpresentatie wordt blootgesteld in te stellen.
7. Roep de [addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#addClone) methode aan die door het [SlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation/#getSlides) object wordt blootgesteld en geef de dia uit de bronpresentatie en de masterdia als parameters aan de [addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#addClone) methode.
8. Schrijf het gewijzigde doel‑presentatiebestand weg.

In het onderstaande voorbeeld hebben we een dia met master (die zich op index nul van de bronpresentatie bevindt) naar het einde van de doelpresentatie gekloond met een master van de bron‑dia.

```php
  # Instantieer de Presentation-klasse om het bronpresentatiebestand te laden
  $srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
  try {
    # Instantieer de Presentation-klasse voor de bestemmingspresentatie (waar de dia gekloond moet worden)
    $destPres = new Presentation();
    try {
      # Instantieer ISlide uit de collectie dia's in de bronpresentatie samen met
      # Master-dia
      $SourceSlide = $srcPres->getSlides()->get_Item(0);
      $SourceMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Kloon de gewenste masterdia van de bronpresentatie naar de collectie masters in de
      # Doelpresentatie
      $masters = $destPres->getMasters();
      $DestMaster = $SourceSlide->getLayoutSlide()->getMasterSlide();
      # Kloon de gewenste masterdia van de bronpresentatie naar de collectie masters in de
      # Doelpresentatie
      $iSlide = $masters->addClone($SourceMaster);
      # Kloon de gewenste dia van de bronpresentatie met de gewenste master naar het einde van de
      # Collectie dia's in de bestemmingspresentatie
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
Als u een dia wilt klonen en deze vervolgens in hetzelfde presentatie‑bestand, maar in een andere sectie wilt gebruiken, gebruik dan de [addClone](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection/#addClone) methode die door de [SlideCollection](https://reference.aspose.com/slides/nl/php-java/aspose.slides/SlideCollection) klasse wordt blootgesteld. Aspose.Slides for PHP via Java maakt het mogelijk om een dia uit de eerste sectie te klonen en vervolgens die gekloonde dia in de tweede sectie van dezelfde presentatie in te voegen.

De volgende code‑fragment toont hoe u een dia kloont en de gekloonde dia in een opgegeven sectie invoegt.

```php
  $presentation = new Presentation();
  try {
    $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 200, 50, 300, 100);
    $presentation->getSections()->addSection("Section 1", $presentation->getSlides()->get_Item(0));
    $section2 = $presentation->getSections()->appendEmptySection("Section 2");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0), $section2);
    # Sla de bestemmingspresentatie op naar schijf
    $presentation->save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Zorg voor overeenkomende dia‑grootte**

Wanneer u dia's in een andere presentatie kloont, moet u ervoor zorgen dat de doelpresentatie dezelfde dia‑grootte heeft als de bronpresentatie. Als de dia‑groottes verschillen, schaalt Aspose.Slides de gekloonde objecten niet automatisch opnieuw – hun originele coördinaten en afmetingen blijven behouden, waardoor de inhoud misaligned kan lijken of buiten de dia‑randen kan uitsteken.

U kunt de dia‑grootte van de doelpresentatie aanpassen zodat deze overeenkomt met die van de bron voordat u de master en de dia kloont:

```php
$sourceSize = $sourcePresentation->getSlideSize()->getSize();

$targetPresentation->getSlideSize()->setSize(
    $sourceSize->getWidth(), $sourceSize->getHeight(), SlideSizeScaleType::DoNotScale);
```

Doe dit vóór het klonen van de master en de dia.

## **FAQ**

**Worden aantekeningen van de spreker en beoordelingscommentaren gekloond?**

Ja. De notitie‑pagina en review‑commentaren worden meegenomen in de kloon. Als u ze niet wilt, [verwijder ze](/slides/nl/php-java/presentation-notes/) na het invoegen.

**Hoe worden grafieken en hun gegevensbronnen behandeld?**

Het grafiek‑object, de opmaak en de ingebedde gegevens worden gekopieerd. Als de grafiek gekoppeld was aan een externe bron (bijv. een OLE‑ingebed werkboek), blijft die koppeling behouden als een [OLE‑object](/slides/nl/php-java/manage-ole/). Controleer na het verplaatsen tussen bestanden de beschikbaarheid van de gegevens en het verversingsgedrag.

**Kan ik de invoegpositie en secties voor de kloon bepalen?**

Ja. U kunt de kloon invoegen op een specifieke dia‑index en plaatsen in een gekozen [sectie](/slides/nl/php-java/slide-section/). Als de doel‑sectie nog niet bestaat, maak deze dan eerst aan en verplaats de dia ernaartoe.