---
title: Diaátmenet
type: docs
weight: 110
url: /hu/php-java/examples/elements/slide-transition/
keywords:
- diaátmenet
- diaátmenet hozzáadása
- diaátmenet elérése
- diaátmenet eltávolítása
- átmenet időtartama
- kódpéldák
- PowerPoint
- OpenDocument
- prezentáció
- PHP
- Aspose.Slides
description: "Kezelje a diaátmeneteket PHP-ben az Aspose.Slides segítségével: válasszon típusokat, sebességet, hangot és időzítést a PPT, PPTX és ODP prezentációk tökéletesítéséhez."
---
Bemutatja a diavetítés-átmeneti hatások és időzítések alkalmazását a **Aspose.Slides for PHP via Java** használatával.

## **Átmenet hozzáadása a diára**

Alkalmazzon egy elhalványuló átmeneti hatást az első diára.

```php
function addSlideTransition() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Alkalmazzon egy elhalványuló átmenetet.
        $slide->getSlideShowTransition()->setType(TransitionType::Fade);

        $presentation->save("slide_transition.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Átmenet elérése a dián**

Olvassa el a diához rendelt átmenet típusát.

```php
function accessSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Az átmenet típusának lekérése.
        $type = $slide->getSlideShowTransition()->getType();
    } finally {
        $presentation->dispose();
    }
}
```

## **Átmenet eltávolítása a diáról**

Törölje az összes átmeneti hatást a típus `None` beállításával.

```php
function removeSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Az átmenet eltávolítása az None beállításával.
        $slide->getSlideShowTransition()->setType(TransitionType::None);

        $presentation->save("slide_transition_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Átmenet időtartamának beállítása**

Adja meg, mennyi ideig jelenik meg a dia, mielőtt automatikusan tovább lép.

```php
function setTransitionDuration() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getSlideShowTransition()->setAdvanceOnClick(true);
        $slide->getSlideShowTransition()->setAdvanceAfterTime(2000); // ezredmásodpercben.

        $presentation->save("slide_transition_duration.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```