---
title: PowerPoint-tekst animeren in PHP
linktitle: Geanimeerde tekst
type: docs
weight: 60
url: /nl/php-java/animated-text/
keywords:
- geanimeerde tekst
- tekstananimatie
- geanimeerde alinea
- alinea-animatie
- animatie-effect
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Maak dynamische geanimeerde tekst in PowerPoint- en OpenDocument-presentaties met behulp van Aspose.Slides for PHP via Java, met gemakkelijk te volgen, geoptimaliseerde codevoorbeelden."
---
## **Overzicht**

Dit artikel legt uit hoe u met geanimeerde tekst in Aspose.Slides werkt door animatie-effecten toe te passen op individuele alinea's en de reeds aan alinea's in een tekstvak toegewezen effecten op te halen. Het richt zich op de API-methoden die worden gebruikt om animatie op alinea-niveau toe te voegen en bestaande alinea-animatie-effecten in een presentatie te inspecteren.

## **Animatie-effecten toevoegen aan alinea's**

We hebben de [**addEffect()**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Sequence#addEffect-com.aspose.slides.IParagraph-int-int-int-) methode toegevoegd aan de [**Sequence**](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Sequence) klasse. Deze methode stelt u in staat om animatie-effecten toe te voegen aan een enkele alinea. Deze voorbeeldcode laat zien hoe u een animatie-effect aan een enkele alinea kunt toevoegen:

```php
  $presentation = new Presentation("Presentation.pptx");
  try {
    # selecteer alinea om een effect toe te voegen
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    # voeg Fly-animatie-effect toe aan de geselecteerde alinea
    $effect = $presentation->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($paragraph, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    $presentation->save("AnimationEffectinParagraph.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **Animatie-effecten van alinea's ophalen**

U kunt besluiten de animatie-effecten die aan een alinea zijn toegevoegd te achterhalen - bijvoorbeeld in een scenario waarin u de animatie-effecten van een alinea wilt ophalen omdat u die effecten op een andere alinea of vorm wilt toepassen.

Aspose.Slides for PHP via Java maakt het mogelijk om alle animatie-effecten op te halen die zijn toegepast op alinea's in een tekstvak (vorm). Deze voorbeeldcode laat zien hoe u de animatie-effecten in een alinea kunt ophalen:

```php
  $pres = new Presentation("Presentation.pptx");
  $Array = new java_class("java.lang.reflect.Array");
  try {
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    foreach($autoShape->getTextFrame()->getParagraphs() as $paragraph) {
      $effects = $sequence->getEffectsByParagraph($paragraph);
      if (java_values($Array->getLength($effects)) > 0) {
        echo("Paragraph \"" . $paragraph->getText() . "\" has " . $effects[0]->getType() . " effect.");
      }
    }
  } finally {
    $pres->dispose();
  }
```

## **FAQ**

**Hoe verschillen tekstananimaties van dia-overgangen, en kunnen ze gecombineerd worden?**

Tekst-animaties regelen het gedrag van een object in de tijd op een dia, terwijl [overgangen](/slides/nl/php-java/slide-transition/) bepalen hoe dia's veranderen. Ze zijn onafhankelijk en kunnen samen worden gebruikt; de afspeelvolgorde wordt bepaald door de animatie-tijdlijn en de overgangsinstellingen.

**Worden tekstananimaties behouden bij exporteren naar PDF of afbeeldingen?**

Nee. PDF-bestanden en raster-afbeeldingen zijn statisch, dus u ziet één enkele weergave van de dia zonder beweging. Om beweging te behouden, gebruikt u export naar [video](/slides/nl/php-java/convert-powerpoint-to-video/) of [HTML](/slides/nl/php-java/export-to-html5/).

**Werken tekstananimaties in lay-outs en de dia-master?**

Effecten die op layout-/master-objecten worden toegepast, worden geërfd door dia's, maar hun timing en interactie met animaties op dia-niveau hangen af van de uiteindelijke volgorde op de dia.