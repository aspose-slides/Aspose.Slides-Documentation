---
title: Beheer presentatie‑placeholders in PHP
linktitle: Beheer placeholders
type: docs
weight: 10
url: /nl/php-java/manage-placeholder/
keywords:
- placeholder
- tekst‑placeholder
- afbeelding‑placeholder
- grafiek‑placeholder
- prompt‑tekst
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Gemakkelijk placeholders beheren in Aspose.Slides voor PHP via Java: tekst vervangen, prompts aanpassen & afbeeldings‑transparantie instellen in PowerPoint en OpenDocument."
---
## **Overzicht**

Aspose.Slides stelt u in staat om presentatiesleuf‑placeholders programmatisch te beheren. Dit artikel legt uit hoe u placeholders op dia's kunt vinden en hun tekst kunt wijzigen, aangepaste prompttekst kunt instellen voor placeholder‑lay-outs, en de transparantie van een afbeelding die als achtergrond voor een placeholder wordt gebruikt kunt aanpassen. Het bevat ook een korte FAQ die het verschil tussen basis‑placeholders en lokale vormen verduidelijkt, uitlegt hoe placeholder‑wijzigingen kunnen worden toegepast via lay-outs of masters, en verwijst naar het beheer van header‑ en footer‑placeholders.

## **Tekst wijzigen in een placeholder**

Met [Aspose.Slides for PHP via Java](/slides/nl/php-java/) kunt u placeholders op dia's in presentaties vinden en aanpassen. Aspose.Slides stelt u in staat om wijzigingen aan te brengen in de tekst van een placeholder.

**Voorvereiste**: U heeft een presentatie nodig die een placeholder bevat. Zo’n presentatie kunt u maken met de standaard Microsoft PowerPoint‑applicatie.

Zo gebruikt u Aspose.Slides om de tekst in de placeholder van die presentatie te vervangen:

1. Maak een instantie van de [`Presentation`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation)‑klasse en geef de presentatie als argument door.
2. Haal een referentie naar een dia op via de index.
3. Itereer over de vormen om de placeholder te vinden.
4. Cast de placeholder‑vorm naar een [`AutoShape`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/AutoShape) en wijzig de tekst met behulp van het [`TextFrame`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/TextFrame) dat bij de [`AutoShape`](https://reference.aspose.com/slides/nl/php-java/aspose.slides/AutoShape) hoort.
5. Sla de aangepaste presentatie op.

Deze PHP‑code toont hoe u de tekst in een placeholder wijzigt:

```php
  # Instancieert een Presentation-klasse
  $pres = new Presentation("ReplacingText.pptx");
  try {
    # Toegang tot de eerste dia
    $sld = $pres->getSlides()->get_Item(0);
    # Loopt door de vormen om de placeholder te vinden
    foreach($sld->getShapes() as $shp) {
      if (!java_is_null($shp->getPlaceholder())) {
        # Verandert de tekst in elke placeholder
        $shp->getTextFrame()->setText("This is Placeholder");
      }
    }
    # Slaat de presentatie op naar schijf
    $pres->save("output.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Prompttekst instellen in een placeholder**

Standaard‑ en vooraf gebouwde lay-outs bevatten placeholder‑promptteksten zoals ***Klik om een titel toe te voegen*** of ***Klik om een ondertitel toe te voegen***. Met Aspose.Slides kunt u uw eigen gewenste promptteksten in placeholder‑lay-outs invoegen.

Deze PHP‑code toont hoe u de prompttekst in een placeholder instelt:

```php
  $pres = new Presentation("Presentation.pptx");
  try {
    $slide = $pres->getSlides()->get_Item(0);
    # Itereert door de dia
    foreach($slide->getSlide()->getShapes() as $shape) {
      if (java_instanceof($shape->getPlaceholder()) != null && $shape, new JavaClass("com.aspose.slides.AutoShape")) {
        $text = "";
        # PowerPoint toont "Klik om een titel toe te voegen"
        if ($shape->getPlaceholder()->getType() == PlaceholderType::CenteredTitle) {
          $text = "Add Title";
        } else // Voeg ondertitel toe
        if ($shape->getPlaceholder()->getType() == PlaceholderType::Subtitle) {
          $text = "Add Subtitle";
        }
        $shape->getTextFrame()->setText($text);
        echo("Placeholder with text: " . $text);
      }
    }
    $pres->save("Placeholders_PromptText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Transparantie van placeholder‑afbeelding instellen**

Aspose.Slides maakt het mogelijk om de transparantie van de achtergrondafbeelding in een tekst‑placeholder in te stellen. Door de transparantie van de afbeelding in zo’n frame aan te passen, kunt u de tekst of de afbeelding laten opvallen (afhankelijk van de kleuren van de tekst en de afbeelding).

Deze PHP‑code toont hoe u de transparantie van een afbeelding als achtergrond (binnen een vorm) instelt:

```php
  $presentation = new Presentation("example.pptx");
  $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
  $operationCollection = $shape->getFillFormat()->getPictureFillFormat()->getPicture()->getImageTransform();
  for($i = 0; $i < java_values($operationCollection->size()) ; $i++) {
    if (java_instanceof($operationCollection->get_Item($i)), new JavaClass("com.aspose.slides.AlphaModulateFixed")) {
      $alphaModulate = $operationCollection->get_Item($i);
      $currentValue = 100 - $alphaModulate->getAmount();
      echo("Current transparency value: " . $currentValue);
      $alphaValue = 40;
      $alphaModulate->setAmount(100 - $alphaValue);
    }
  }
  $presentation->save("example_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Wat is een basis‑placeholder en hoe verschilt deze van een lokale vorm op een dia?**

Een basis‑placeholder is de oorspronkelijke vorm op een lay-out of master waarvan de vorm op de dia erft — type, positie en een deel van de opmaak komen van deze basis‑placeholder. Een lokale vorm is onafhankelijk; als er geen basis‑placeholder bestaat, is er geen overerving.

**Hoe kan ik alle titels of bijschriften in een presentatie bijwerken zonder door elke dia te itereren?**

Bewerk de bijbehorende placeholder op de lay-out of de master. Dia’s die op die lay-outs of master zijn gebaseerd, zullen de wijziging automatisch overnemen.

**Hoe beheer ik de standaard header/footer‑placeholders — datum & tijd, dia‑nummer en footer‑tekst?**

Gebruik de HeaderFooter‑managers op de juiste scope (normale dia’s, lay-outs, master, notities/hand-outs) om die placeholders in of uit te schakelen en om hun inhoud in te stellen.