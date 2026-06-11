---
title: Bildövergång
type: docs
weight: 110
url: /sv/php-java/examples/elements/slide-transition/
keywords:
- bildövergång
- lägg till bildövergång
- åtkomst till bildövergång
- ta bort bildövergång
- övergångens varaktighet
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Kontrollera bildövergångar i PHP med Aspose.Slides: välj typer, hastighet, ljud och tidpunkter för att finjustera presentationer i PPT, PPTX och ODP."
---
Demonstrerar hur man tillämpar bildövergångseffekter och tidsinställningar med **Aspose.Slides for PHP via Java**.

## **Lägg till en bildövergång**

Applicera en blekningsövergångseffekt på den första bilden.

```php
function addSlideTransition() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Applicera en blekningsövergång.
        $slide->getSlideShowTransition()->setType(TransitionType::Fade);

        $presentation->save("slide_transition.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Få åtkomst till en bildövergång**

Läs av övergångstypen som tilldelats en bild.

```php
function accessSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Få åtkomst till övergångstypen.
        $type = $slide->getSlideShowTransition()->getType();
    } finally {
        $presentation->dispose();
    }
}
```

## **Ta bort en bildövergång**

Rensa alla övergångseffekter genom att sätta typen till `None`.

```php
function removeSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Ta bort övergång genom att sätta ingen.
        $slide->getSlideShowTransition()->setType(TransitionType::None);

        $presentation->save("slide_transition_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Ange övergångens varaktighet**

Ange hur länge bilden visas innan den går vidare automatiskt.

```php
function setTransitionDuration() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getSlideShowTransition()->setAdvanceOnClick(true);
        $slide->getSlideShowTransition()->setAdvanceAfterTime(2000); // i millisekunder.

        $presentation->save("slide_transition_duration.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```