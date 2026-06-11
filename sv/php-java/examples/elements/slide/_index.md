---
title: Bild
type: docs
weight: 10
url: /sv/php-java/examples/elements/slide/
keywords:
- bild
- lägg till bild
- åtkomst till bild
- bildindex
- klona bild
- ordna om bilder
- ta bort bild
- kodexempel
- PowerPoint
- OpenDocument
- presentation
- PHP
- Aspose.Slides
description: "Hantera bilder i PHP med Aspose.Slides: skapa, klona, ordna om, dölja, ange bakgrunder och storlek, applicera övergångar och exportera för PowerPoint och OpenDocument."
---
Den här artikeln ger en rad exempel som visar hur du arbetar med bilder med **Aspose.Slides for PHP via Java**. Du kommer att lära dig hur du lägger till, får åtkomst till, klonar, ordnar om och tar bort bilder med hjälp av `Presentation`-klassen.

Varje exempel nedan innehåller en kort förklaring följt av ett kodexempel i PHP.

## **Lägg till en bild**

För att lägga till en ny bild måste du först välja en layout. I det här exemplet använder vi layouten `Blank` och lägger till en tom bild i presentationen.

```php
function addSlide() {
    $presentation = new Presentation();
    try {
        // Varje bild baseras på en layout, som i sin tur baseras på en masterbild.
        // Använd Blank-layouten för att skapa en ny bild.
        $blankLayout = $presentation->getLayoutSlides()->getByType(SlideLayoutType::Blank);

        // Lägg till en ny tom bild med den valda layouten.
        $presentation->getSlides()->addEmptySlide($blankLayout);

        $presentation->save("slide.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

> 💡 **Tips:** Varje bildlayout härstammar från en masterbild, som definierar den övergripande designen och platshållarstrukturen. Bilden nedan illustrerar hur masterbilder och deras associerade layouter är organiserade i PowerPoint.

![Förhållandet mellan master och layout](master-layout-slide.png)

## **Åtkomst till bilder efter index**

Du kan få åtkomst till bilder med deras index.

```php
function accessSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // Åtkomst till en bild efter index.
        $firstSlide = $presentation->getSlides()->get_Item(0);
    } finally {
        $presentation->dispose();
    }
}
```

## **Klona en bild**

Det här exemplet visar hur du klonar en befintlig bild. Den klonade bilden läggs automatiskt till i slutet av bildsamlingen.

```php
function cloneSlide() {
    // Som standard innehåller presentationen en tom bild.
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // Klona den första bilden; den kommer att läggas till i slutet av presentationen.
        $clonedSlide = $presentation->getSlides()->addClone($slide);

        // Det klonade bildindexet är 1 (andra bilden i presentationen).
        $clonedSlideIndex = $presentation->getSlides()->indexOf($clonedSlide);

        $presentation->save("slide_cloned.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Ordna om bilder**

Du kan ändra ordningen på bilder genom att flytta en till ett nytt index. I det här fallet flyttar vi en bild till första positionen.

```php
function reorderSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(1);

        // Flytta bilden till den första positionen (övriga förskjuts nedåt).
        $presentation->getSlides()->reorder(0, $slide);

        $presentation->save("slide_reordered.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **Ta bort en bild**

För att ta bort en bild, referera bara till den och anropa `remove`. Det här exemplet tar bort bilder efter index och efter referens.

```php
function removeSlide() {
    $presentation = new Presentation("slide.pptx");
    try {
        // Ta bort en bild efter index.
        $presentation->getSlides()->removeAt(0);

        // Ta bort en bild efter referens.
        $slide = $presentation->getSlides()->get_Item(0);
        $presentation->getSlides()->remove($slide);

        $presentation->save("slides_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```