---
title: PřechodSnímku
type: docs
weight: 110
url: /cs/php-java/examples/elements/slide-transition/
keywords:
- přechod snímku
- přidat přechod snímku
- načíst přechod snímku
- odstranit přechod snímku
- doba trvání přechodu
- příklady kódu
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Ovládejte přechody snímků v PHP s Aspose.Slides: vyberte typy, rychlost, zvuk a časování a vylepšete prezentace ve formátech PPT, PPTX a ODP."
---
Ukazuje použití efektů přechodů snímků a časování s **Aspose.Slides for PHP via Java**.

## **Přidat přechod snímku**

Použijte efekt fade přechodu na první snímek.

```php
function addSlideTransition() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Použít přechod fade.
        $slide->getSlideShowTransition()->setType(TransitionType::Fade);

        $presentation->save("slide_transition.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Načíst přechod snímku**

Přečtěte typ přechodu přiřazený snímku.

```php
function accessSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Načíst typ přechodu.
        $type = $slide->getSlideShowTransition()->getType();
    } finally {
        $presentation->dispose();
    }
}
```

## **Odstranit přechod snímku**

Odstraňte jakýkoli efekt přechodu nastavením typu na `None`.

```php
function removeSlideTransition() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Odebrat přechod nastavením none.
        $slide->getSlideShowTransition()->setType(TransitionType::None);

        $presentation->save("slide_transition_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Nastavit dobu trvání přechodu**

Určete, jak dlouho bude snímek zobrazován před automatickým přechodem.

```php
function setTransitionDuration() {
    $presentation = new Presentation("slide_transition.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getSlideShowTransition()->setAdvanceOnClick(true);
        $slide->getSlideShowTransition()->setAdvanceAfterTime(2000); // v milisekundách.

        $presentation->save("slide_transition_duration.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```