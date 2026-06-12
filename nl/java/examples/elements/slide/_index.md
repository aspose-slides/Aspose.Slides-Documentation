---
title: Dia
type: docs
weight: 10
url: /nl/java/examples/elements/slide/
keywords:
- codevoorbeeld
- dia
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Dia's beheren in Aspose.Slides for Java: maken, klonen, herschikken, van grootte wijzigen, achtergronden instellen en overgangen toepassen met Java voor PPT-, PPTX- en ODP-presentaties."
---
Dit artikel bevat een reeks voorbeelden die laten zien hoe u met dia’s kunt werken met **Aspose.Slides for Java**. U leert hoe u dia’s kunt toevoegen, benaderen, klonen, herschikken en verwijderen met behulp van de `Presentation`‑klasse.

Elke hieronder weergegeven voorbeeld bevat een korte uitleg, gevolgd door een codefragment in Java.

## **Dia toevoegen**

Om een nieuwe dia toe te voegen, moet u eerst een lay-out selecteren. In dit voorbeeld gebruiken we de `Blank` lay-out en voegen we een lege dia toe aan de presentatie.

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

> 💡 **Opmerking:** Elke dia‑lay-out is afgeleid van een masterdia, die het algemene ontwerp en de placeholder‑structuur bepaalt. De afbeelding hieronder toont hoe masterdia’s en hun bijbehorende lay-outs zijn georganiseerd in PowerPoint.

![Relatie tussen master en lay-out](master-layout-slide.png)

## **Dia’s benaderen op index**

U kunt dia’s benaderen via hun index, of de index van een dia vinden op basis van een referentie. Dit is handig om door dia’s te itereren of specifieke dia’s te wijzigen.

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // Voeg nog een lege dia toe.
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // Dia's benaderen op index.
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // Haal de dia-index op uit een referentie, en benader deze vervolgens op index.
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **Dia klonen**

Dit voorbeeld laat zien hoe u een bestaande dia kunt klonen. De gekloonde dia wordt automatisch toegevoegd aan het einde van de verzameling dia’s.

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

## **Dia’s herschikken**

U kunt de volgorde van dia’s wijzigen door er één naar een nieuwe index te verplaatsen. In dit geval verplaatsen we een gekloonde dia naar de eerste positie.

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

Om een dia te verwijderen, verwijst u er simpelweg naar en roept u `remove` aan. Dit voorbeeld voegt een tweede dia toe en verwijdert vervolgens de oorspronkelijke, zodat alleen de nieuwe overblijft.

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