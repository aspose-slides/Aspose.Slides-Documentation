---
title: PrzejścieSlajdu
type: docs
weight: 110
url: /pl/php-java/examples/elements/slide-transition/
keywords:
- przejście slajdu
- dodaj przejście slajdu
- uzyskaj dostęp do przejścia slajdu
- usuń przejście slajdu
- czas trwania przejścia
- przykłady kodu
- PowerPoint
- OpenDocument
- prezentacja
- PHP
- Aspose.Slides
description: "Steruj przejściami slajdów w PHP za pomocą Aspose.Slides: wybieraj typy, prędkość, dźwięk i timing, aby dopracować prezentacje w formatach PPT, PPTX i ODP."
---
Prezentuje zastosowanie efektów przejścia slajdów i ich czasów trwania przy użyciu **Aspose.Slides for PHP via Java**.

## **Dodaj przejście slajdu**

Zastosuj efekt przejścia zanikania do pierwszego slajdu.

```php
function addSlideTransition() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Zastosuj przejście zanikania.
        $slide->getSlideShowTransition()->setType(TransitionType::Fade);

        $presentation->save("slide_transition.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Uzyskaj dostęp do przejścia slajdu**

Odczytaj typ przejścia przypisany do slajdu.

```php
function accessSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Uzyskaj dostęp do typu przejścia.
        $type = $slide->getSlideShowTransition()->getType();
    } finally {
        $presentation->dispose();
    }
}
```

## **Usuń przejście slajdu**

Usuń dowolny efekt przejścia, ustawiając typ na `None`.

```php
function removeSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Usuń przejście, ustawiając brak.
        $slide->getSlideShowTransition()->setType(TransitionType::None);

        $presentation->save("slide_transition_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Ustaw czas trwania przejścia**

Określ, jak długo slajd jest wyświetlany przed automatycznym przejściem dalej.

```php
function setTransitionDuration() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getSlideShowTransition()->setAdvanceOnClick(true);
        $slide->getSlideShowTransition()->setAdvanceAfterTime(2000); // w milisekundach.

        $presentation->save("slide_transition_duration.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```