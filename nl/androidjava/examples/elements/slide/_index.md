---
title: Dia
type: docs
weight: 10
url: /nl/androidjava/examples/elements/slide/
keywords:
- codevoorbeeld
- dia
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheer dia's in Aspose.Slides voor Android: maak, kloon, herschik, wijzig de grootte, stel achtergronden in en pas overgangen toe met Java voor PPT-, PPTX- en ODP-presentaties."
---
Dit artikel bevat een reeks voorbeelden die laten zien hoe je met dia's kunt werken met **Aspose.Slides for Android via Java**. Je leert hoe je dia's kunt toevoegen, benaderen, klonen, herschikken en verwijderen met de `Presentation`‑klasse.

Elk voorbeeld hieronder bevat een korte uitleg gevolgd door een codefragment in Java.

## **Dia toevoegen**

Om een nieuwe dia toe te voegen, moet je eerst een lay-out selecteren. In dit voorbeeld gebruiken we de `Blank`‑lay-out en voegen we een lege dia toe aan de presentatie.

```java
static void addSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

        presentation.getSlides().addEmptySlide(blankLayout);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Opmerking:** Elke dia‑lay-out is afgeleid van een masterdia, die het algemene ontwerp en de structuur van de tijdelijke aanduidingen definieert. De afbeelding hieronder toont hoe masterdia's en hun bijbehorende lay-outs in PowerPoint zijn georganiseerd.

![Relatie tussen master en lay-out](master-layout-slide.png)

## **Dia's benaderen op index**

Je kunt dia's benaderen met hun index, of de index van een dia vinden op basis van een referentie. Dit is nuttig om door dia's te itereren of specifieke dia's te wijzigen.

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // Voeg nog een lege dia toe.
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // Toegang tot dia's via index.
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // Haal dia-index op uit een referentie, en krijg daarna toegang via index.
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **Dia klonen**

Dit voorbeeld laat zien hoe je een bestaande dia kunt klonen. De gekloonde dia wordt automatisch aan het einde van de dia‑collectie toegevoegd.

```java
static void cloneSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        int clonedSlideIndex = presentation.getSlides().indexOf(clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Dia's herschikken**

Je kunt de volgorde van dia's wijzigen door er één naar een nieuwe index te verplaatsen. In dit voorbeeld verplaatsen we een gekloonde dia naar de eerste positie.

```java
static void reorderSlide() {
    Presentation presentation = new Presentation();
    try {
        ISlide firstSlide = presentation.getSlides().get_Item(0);

        ISlide clonedSlide = presentation.getSlides().addClone(firstSlide);

        presentation.getSlides().reorder(0, clonedSlide);
    } finally {
        presentation.dispose();
    }
}
```

## **Dia verwijderen**

Om een dia te verwijderen, verwijs je er simpelweg naar en roep je `remove` aan. Dit voorbeeld voegt een tweede dia toe en verwijdert vervolgens de oorspronkelijke, zodat alleen de nieuwe overblijft.

```java
static void removeSlide() {
    Presentation presentation = new Presentation();
    try {
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        ISlide secondSlide = presentation.getSlides().addEmptySlide(blankLayout);

        ISlide firstSlide = presentation.getSlides().get_Item(0);
        presentation.getSlides().remove(firstSlide);
    } finally {
        presentation.dispose();
    }
}
```