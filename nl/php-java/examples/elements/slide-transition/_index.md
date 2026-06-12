---
title: DiaOvergang
type: docs
weight: 110
url: /nl/php-java/examples/elements/slide-transition/
keywords:
- diaovergang
- diaovergang toevoegen
- diaovergang raadplegen
- diaovergang verwijderen
- overgangsduur
- codevoorbeelden
- PowerPoint
- OpenDocument
- presentatie
- PHP
- Aspose.Slides
description: "Beheer diaovergangen in PHP met Aspose.Slides: kies typen, snelheid, geluid en timing om presentaties in PPT, PPTX en ODP te verfijnen."
---
Toont het toepassen van dia‑overgangseffecten en tijdsinstellingen met **Aspose.Slides for PHP via Java**.

## **Een dia‑overgang toevoegen**

Pas een vervagings‑overgangseffect toe op de eerste dia.

```php
function addSlideTransition() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Pas een vervagingsovergang toe.
        $slide->getSlideShowTransition()->setType(TransitionType::Fade);

        $presentation->save("slide_transition.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Een dia‑overgang raadplegen**

Lees het overgangstype dat aan een dia is toegewezen.

```php
function accessSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Toegang tot het overgangstype.
        $type = $slide->getSlideShowTransition()->getType();
    } finally {
        $presentation->dispose();
    }
}
```

## **Een dia‑overgang verwijderen**

Verwijder elk overgangseffect door het type in te stellen op `None`.

```php
function removeSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Verwijder overgang door none in te stellen.
        $slide->getSlideShowTransition()->setType(TransitionType::None);

        $presentation->save("slide_transition_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Overgangsduur instellen**

Geef op hoe lang de dia wordt weergegeven voordat hij automatisch wordt voortgeschoven.

```php
function setTransitionDuration() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getSlideShowTransition()->setAdvanceOnClick(true);
        $slide->getSlideShowTransition()->setAdvanceAfterTime(2000); // in milliseconden.

        $presentation->save("slide_transition_duration.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```