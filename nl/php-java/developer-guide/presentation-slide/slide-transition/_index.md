---
title: Beheer dia-overgangen in presentaties met PHP
linktitle: Dia-overgang
type: docs
weight: 80
url: /nl/php-java/slide-transition/
keywords:
- dia-overgang
- dia-overgang toevoegen
- dia-overgang toepassen
- geavanceerde dia-overgang
- morph-overgang
- overgangstype
- overgangseffect
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Ontdek hoe u dia-overgangen kunt aanpassen in Aspose.Slides for PHP via Java, met stapsgewijze begeleiding voor PowerPoint- en OpenDocument-presentaties."
---
## **Overzicht**

Dit artikel legt uit hoe u slide‑overgangen in presentaties beheert met Aspose.Slides. Het laat zien hoe u overgangstypen toepast op dia's, het gedrag van overgangen configureert, zoals vooruitgaan bij klikken of na een opgegeven tijd, automatische voortgang controleert en uitschakelt, de Morph‑overgang en de verschillende types ervan gebruikt, en opties voor overgangseffecten instelt. De voorbeelden tonen hoe u een presentatie laadt of maakt, de overgangsinstellingen voor geselecteerde dia's wijzigt, en het resultaat opslaat als een PPTX‑bestand. Het artikel beantwoordt ook veelgestelde vragen over de snelheid van overgangen, overgangsgeluiden, dezelfde overgang op meerdere dia's toepassen, en hoe u de momenteel ingestelde overgang op een dia controleert.

## **Slide‑overgang toevoegen**
Om een eenvoudig slide‑overgangseffect te maken, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation)‑klasse.  
1. Pas een Slide Transition Type toe op de dia via een van de overgangseffecten die Aspose.Slides for PHP via Java biedt, met de TransitionType‑enum.  
1. Schrijf het gewijzigde presentatie‑bestand weg.

```php
  # Instantieer de Presentation-klasse om het bronpresentatiebestand te laden
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Pas een cirkeltype overgang toe op dia 1
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Pas een kamtype overgang toe op dia 2
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Schrijf de presentatie naar de schijf
    $presentation->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Geavanceerde slide‑overgang toevoegen**
In de bovenstaande sectie hebben we alleen een eenvoudige overgang op de dia toegepast. Om die eenvoudige overgang nog beter en beter te beheersen, volgt u de onderstaande stappen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/presentation)‑klasse.  
1. Pas een Slide Transition Type toe op de dia via een van de overgangseffecten die Aspose.Slides for PHP via Java biedt.  
1. U kunt de overgang ook instellen op Advance On Click, na een specifieke tijdsperiode of beide.  
1. Als de slide‑overgang is ingesteld op Advance On Click, gaat de overgang alleen verder wanneer iemand klikt. Bovendien, als de eigenschap Advance After Time is ingesteld, gaat de overgang automatisch verder zodra de opgegeven tijd is verstreken.  
1. Schrijf de gewijzigde presentatie weg als een presentatie‑bestand.

```php
  # Instantieer Presentation-klasse die een presentatiebestand vertegenwoordigt
  $pres = new Presentation("BetterSlideTransitions.pptx");
  try {
    # Pas een cirkeltype overgang toe op dia 1
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Circle);
    # Stel de overgangstijd in op 3 seconden
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(0)->getSlideShowTransition()->setAdvanceAfterTime(3000);
    # Pas een kamtype overgang toe op dia 2
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Comb);
    # Stel de overgangstijd in op 5 seconden
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(1)->getSlideShowTransition()->setAdvanceAfterTime(5000);
    # Pas een zoomtype overgang toe op dia 3
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setType(TransitionType::Zoom);
    # Stel de overgangstijd in op 7 seconden
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceOnClick(true);
    $pres->getSlides()->get_Item(2)->getSlideShowTransition()->setAdvanceAfterTime(7000);
    # Schrijf de presentatie naar de schijf
    $pres->save("SampleTransition_out.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Morph‑overgang**
{{% alert color="primary" %}} 

Aspose.Slides for PHP via Java ondersteunt nu de [Morph Transition](https://reference.aspose.com/slides/nl/php-java/aspose.slides/morphtransition/). Deze vertegenwoordigt de nieuwe morph‑overgang die geïntroduceerd is in PowerPoint 2019.

{{% /alert %}} 

De Morph‑overgang maakt het mogelijk om een vloeiende beweging van de ene dia naar de volgende te animeren. Dit artikel beschrijft het concept en hoe u de Morph‑overgang gebruikt. Om de Morph‑overgang effectief te gebruiken, moet u twee dia's hebben met ten minste één gemeenschappelijk object. De eenvoudigste manier is om de dia te dupliceren en het object op de tweede dia naar een andere positie te verplaatsen.

De volgende code‑fragment toont hoe u een kloon van de dia met wat tekst toevoegt aan de presentatie en een overgang van het [morph‑type](https://reference.aspose.com/slides/nl/php-java/aspose.slides/TransitionType) instelt op de tweede dia.

```php
  $presentation = new Presentation();
  try {
    $autoshape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 100);
    $autoshape->getTextFrame()->setText("Morph Transition in PowerPoint Presentations");
    $presentation->getSlides()->addClone($presentation->getSlides()->get_Item(0));
    $shape = $presentation->getSlides()->get_Item(1)->getShapes()->get_Item(0);
    $shape->setX($shape->getX() + 100);
    $shape->setY($shape->getY() + 50);
    $shape->setWidth($shape->getWidth() - 200);
    $shape->setHeight($shape->getHeight() - 10);
    $presentation->getSlides()->get_Item(1)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Morph‑overgangstypen**
Er is een nieuwe enum [TransitionMorphType](https://reference.aspose.com/slides/nl/php-java/aspose.slides/TransitionMorphType) toegevoegd. Deze vertegenwoordigt verschillende typen Morph‑slide‑overgangen.

TransitionMorphType‑enum heeft drie leden:

- ByObject: Morph‑overgang wordt uitgevoerd waarbij vormen worden beschouwd als ondeelbare objecten.  
- ByWord: Morph‑overgang wordt uitgevoerd met het overbrengen van tekst per woord waar mogelijk.  
- ByChar: Morph‑overgang wordt uitgevoerd met het overbrengen van tekst per teken waar mogelijk.

De volgende code‑fragment toont hoe u een morph‑overgang op een dia instelt en het morph‑type wijzigt:

```php
  $presentation = new Presentation("presentation.pptx");
  try {
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Morph);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setMorphType(TransitionMorphType::ByWord);
    $presentation->save("presentation-out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Overgangseffecten instellen**
Aspose.Slides for PHP via Java ondersteunt het instellen van overgangseffecten zoals vanaf zwart, van links, van rechts enzovoort. Om een overgangseffect in te stellen, volgt u de onderstaande stappen:

- Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/php-java/aspose.slides/Presentation)‑klasse.  
- Haal de referentie van de dia op.  
- Stel het overgangseffect in.  
- Schrijf de presentatie weg als een [PPTX](https://docs.fileformat.com/presentation/pptx/)‑bestand.

In het onderstaande voorbeeld hebben we de overgangseffecten ingesteld.

```php
  # Maak een instantie van de Presentation-klasse
  $presentation = new Presentation("AccessSlides.pptx");
  try {
    # Stel effect in
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->setType(TransitionType::Cut);
    $presentation->getSlides()->get_Item(0)->getSlideShowTransition()->getValue()->setFromBlack(true);
    # Schrijf de presentatie naar de schijf
    $presentation->save("SetTransitionEffects_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **FAQ**

**Kan ik de afspeelsnelheid van een slide‑overgang regelen?**

Ja. Stel de [speed](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/setspeed/) van de overgang in via de [TransitionSpeed](https://reference.aspose.com/slides/nl/php-java/aspose.slides/transitionspeed/)‑instelling (bijv. slow/medium/fast).

**Kan ik audio aan een overgang koppelen en laten herhalen?**

Ja. U kunt een geluid voor de overgang insluiten en het gedrag regelen via instellingen zoals sound mode en looping (bijv. [setSound](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/setsoundloop/), plus metadata zoals [setSoundIsBuiltIn](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) en [setSoundName](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/setsoundname/)).

**Wat is de snelste manier om dezelfde overgang op elke dia toe te passen?**

Configureer het gewenste overgangstype in de overgangsinstellingen van elke dia; overgangen worden per dia opgeslagen, dus dezelfde type op alle dia's toepassen levert een consistent resultaat op.

**Hoe kan ik controleren welke overgang momenteel op een dia is ingesteld?**

Inspecteer de [transition settings](https://reference.aspose.com/slides/nl/php-java/aspose.slides/baseslide/#getSlideShowTransition) van de dia en lees het [transition type](https://reference.aspose.com/slides/nl/php-java/aspose.slides/slideshowtransition/settype/); die waarde geeft precies aan welk effect is toegepast.