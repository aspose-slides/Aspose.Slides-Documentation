---
title: Folienübergang
type: docs
weight: 110
url: /de/php-java/examples/elements/slide-transition/
keywords:
- Folienübergang
- Folienübergang hinzufügen
- Zugriff auf Folienübergang
- Folienübergang entfernen
- Übergangsdauer
- Codebeispiele
- PowerPoint
- OpenDocument
- Präsentation
- PHP
- Aspose.Slides
description: "Steuern Sie Folienübergänge in PHP mit Aspose.Slides: wählen Sie Typen, Geschwindigkeit, Sound und Timing, um Präsentationen in PPT, PPTX und ODP zu verfeinern."
---
Demonstriert die Anwendung von Folienübergangseffekten und -zeiten mit **Aspose.Slides for PHP via Java**.

## **Folieübergang hinzufügen**

Wenden Sie einen Fade-Übergangseffekt auf die erste Folie an.

```php
function addSlideTransition() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Fade-Übergang anwenden.
        $slide->getSlideShowTransition()->setType(TransitionType::Fade);

        $presentation->save("slide_transition.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Zugriff auf einen Folienübergang**

Lesen Sie den der Folie zugewiesenen Übergangstyp.

```php
function accessSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zugriff auf den Übergangstyp.
        $type = $slide->getSlideShowTransition()->getType();
    } finally {
        $presentation->dispose();
    }
}
```

## **Folienübergang entfernen**

Entfernen Sie alle Übergangseffekte, indem Sie den Typ auf `None` setzen.

```php
function removeSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Übergang entfernen, indem auf None gesetzt wird.
        $slide->getSlideShowTransition()->setType(TransitionType::None);

        $presentation->save("slide_transition_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Übergangsdauer festlegen**

Geben Sie an, wie lange die Folie angezeigt wird, bevor sie automatisch weiterblättert.

```php
function setTransitionDuration() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getSlideShowTransition()->setAdvanceOnClick(true);
        $slide->getSlideShowTransition()->setAdvanceAfterTime(2000); // in Millisekunden.

        $presentation->save("slide_transition_duration.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```