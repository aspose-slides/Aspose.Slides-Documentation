---
title: Groepsvormen in presentaties in PHP
linktitle: Vormgroep
type: docs
weight: 40
url: /nl/php-java/group/
keywords:
- groepsvorm
- vormgroep
- groep toevoegen
- alternatieve tekst
- PowerPoint
- presentatie
- PHP
- Aspose.Slides
description: "Leer hoe u vormen in PowerPoint-presentaties groepeert en degroepeert met Aspose.Slides voor PHP via Java — snelle, stapsgewijze gids met gratis code."
---
## **Overzicht**

Dit artikel legt uit hoe u met groepsvormen in Aspose.Slides kunt werken. Het laat zien hoe u een groepsvorm aan een dia toevoegt, vormen erin plaatst en de bijgewerkte presentatie opslaat. Het toont ook hoe u vormen die in een groep zijn opgeslagen kunt benaderen en hun `AlternativeText`‑waarden kunt uitlezen. Daarnaast behandelt het kort gerelateerde mogelijkheden van groepsvormen, zoals geneste groepen, z‑order en vergrendelingsopties.

## **Groepsvorm Toevoegen**
Aspose.Slides ondersteunt het werken met groepsvormen op dia's. Deze functie helpt ontwikkelaars rijkere presentaties te maken. Aspose.Slides for PHP via Java ondersteunt het toevoegen of benaderen van groepsvormen. Het is mogelijk om vormen toe te voegen aan een toegevoegde groepsvorm om deze te vullen of om een willekeurige eigenschap van de groepsvorm te benaderen. Om een groepsvorm aan een dia toe te voegen met Aspose.Slides for PHP via Java:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation)‑klasse.
1. Verkrijg de referentie van een dia door zijn Index te gebruiken.
1. Voeg een groepsvorm toe aan de dia.
1. Voeg de vormen toe aan de toegevoegde groepsvorm.
1. Sla de gewijzigde presentatie op als een PPTX‑bestand.

Het voorbeeld hieronder voegt een groepsvorm toe aan een dia.

```php
  # Instantie van de Presentation-klasse
  $pres = new Presentation();
  try {
    # Haal de eerste dia op
    $sld = $pres->getSlides()->get_Item(0);
    # Toegang tot de vormcollectie van dia's
    $slideShapes = $sld->getShapes();
    # Groepsvorm toevoegen aan de dia
    $groupShape = $slideShapes->addGroupShape();
    # Vormen toevoegen binnen toegevoegde groepsvorm
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 100, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 300, 300, 100, 100);
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 500, 300, 100, 100);
    # Frame van groepsvorm toevoegen
    $groupShape->setFrame(new ShapeFrame(100, 300, 500, 40, NullableBool::False, NullableBool::False, 0));
    # PPTX-bestand naar schijf schrijven
    $pres->save("GroupShape.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Toegang tot de AltText‑eigenschap**
Dit onderwerp toont eenvoudige stappen, compleet met code‑voorbeelden, voor het toevoegen van een groepsvorm en het benaderen van de AltText‑eigenschap van groepsvormen op dia's. Om AltText van een groepsvorm op een dia te benaderen met Aspose.Slides for PHP via Java:

1. Instantieer de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation)‑klasse die een PPTX‑bestand vertegenwoordigt.
1. Verkrijg de referentie van een dia door zijn Index te gebruiken.
1. Benader de vormcollectie van de dia's.
1. Benader de groepsvorm.
1. Benader de [Alternative Text](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/#getAlternativeText)‑eigenschap.

Het voorbeeld hieronder benadert de alternatieve tekst van een groepsvorm.

```php
  # Instantie van de Presentation-klasse die een PPTX-bestand vertegenwoordigt
  $pres = new Presentation("AltText.pptx");
  try {
    # Haal de eerste dia op
    $sld = $pres->getSlides()->get_Item(0);
    for($i = 0; $i < java_values($sld->getShapes()->size()) ; $i++) {
      # Toegang tot de vormcollectie van dia's
      $shape = $sld->getShapes()->get_Item($i);
      if (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
        # Toegang tot de groepsvorm.
        $grphShape = $shape;
        for($j = 0; $j < java_values($grphShape->getShapes()->size()) ; $j++) {
          $shape2 = $grphShape->getShapes()->get_Item($j);
          # Toegang tot de AltText‑eigenschap
          echo($shape2->getAlternativeText());
        }
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **FAQ**

**Wordt geneste groepering (een groep binnen een groep) ondersteund?**

Ja. [GroupShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/groupshape/) heeft een [getParentGroup](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/getparentgroup/)‑methode, die direct hiërarchische ondersteuning aangeeft (een groep kan een kind van een andere groep zijn).

**Hoe kan ik de z‑order van de groep ten opzichte van andere objecten op de dia regelen?**

Gebruik de [GroupShape](https://reference.aspose.com/slides/nl/php-java/aspose.slides/groupshape/)‑[getZOrderPosition](https://reference.aspose.com/slides/nl/php-java/aspose.slides/shape/getzorderposition/)‑methode om de positie in de weergave‑stack te inspecteren.

**Kan ik verplaatsen/bewerken/degroeperen voorkomen?**

Ja. Het vergrendelingsgedeelte van de groep wordt blootgesteld via [GroupShapeLock](https://reference.aspose.com/slides/nl/php-java/aspose.slides/groupshape/getgroupshapelock/), waarmee u bewerkingen op het object kunt beperken.