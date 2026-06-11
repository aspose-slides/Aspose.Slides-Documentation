---
title: Bild
type: docs
weight: 10
url: /sv/java/examples/elements/slide/
keywords:
- kodexempel
- bild
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Kontrollera bilder i Aspose.Slides för Java: skapa, klona, omordna, ändra storlek, ange bakgrunder och tillämpa övergångar med Java för PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln innehåller en rad exempel som visar hur du arbetar med bilder med **Aspose.Slides for Java**. Du kommer att lära dig hur du lägger till, får åtkomst till, klonar, omordnar och tar bort bilder med hjälp av klassen `Presentation`.

Varje exempel nedanför innehåller en kort förklaring följd av ett kodexempel i Java.

## **Lägg till en bild**

För att lägga till en ny bild måste du först välja en layout. I det här exemplet använder vi layouten `Blank` och lägger till en tom bild i presentationen.

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

> 💡 **Obs:** Varje bildlayout härstammar från en masterbild, som definierar den totala designen och platshållarstrukturen. Bilden nedan visar hur masterbilder och deras associerade layouter är organiserade i PowerPoint.

![Relation mellan master och layout](master-layout-slide.png)

## **Få åtkomst till bilder efter index**

Du kan komma åt bilder med deras index, eller hitta en bilds index baserat på en referens. Detta är användbart för att iterera genom eller ändra specifika bilder.

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // Lägg till en annan tom bild.
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // Läs åt bilder efter index.
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // Hämta bildens index från en referens, och läs sedan åt den efter index.
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **Klona en bild**

Detta exempel visar hur du klonar en befintlig bild. Den klonade bilden läggs automatiskt till i slutet av bildsamlingen.

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

## **Omordna bilder**

Du kan ändra ordningen på bilder genom att flytta en till ett nytt index. I det här fallet flyttar vi en klonad bild till den första positionen.

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

## **Ta bort en bild**

För att ta bort en bild refererar du bara till den och anropar `remove`. Detta exempel lägger till en andra bild och tar sedan bort den ursprungliga, så att endast den nya finns kvar.

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