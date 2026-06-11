---
title: Bild
type: docs
weight: 10
url: /sv/androidjava/examples/elements/slide/
keywords:
- kodexempel
- bild
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Styr bilder i Aspose.Slides för Android: skapa, klona, omordna, ändra storlek, sätta bakgrunder och tillämpa övergångar med Java för PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln innehåller en serie exempel som visar hur man arbetar med bilder med **Aspose.Slides for Android via Java**. Du kommer att lära dig hur man lägger till, får åtkomst till, klonar, omordnar och tar bort bilder med hjälp av `Presentation`‑klassen.

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

> 💡 **Obs:** Varje bildlayout härstammar från en huvudbild, som definierar den övergripande designen och platshållarstrukturen. Bilden nedanför illustrerar hur huvudbilder och deras associerade layouter är organiserade i PowerPoint.

![Relation mellan huvudbild och layout](master-layout-slide.png)

## **Få åtkomst till bilder efter index**

Du kan komma åt bilder med hjälp av deras index, eller hitta en bilds index baserat på en referens. Detta är användbart för att iterera genom eller modifiera specifika bilder.

```java
static void accessSlide() {
    Presentation presentation = new Presentation();
    try {
        // Lägg till en annan tom bild.
        ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
        presentation.getSlides().addEmptySlide(blankLayout);

        // Kom åt bilder efter index.
        ISlide firstSlide = presentation.getSlides().get_Item(0);
        ISlide secondSlide = presentation.getSlides().get_Item(1);

        // Hämta bildens index från en referens och sedan komma åt den efter index.
        int secondSlideIndex = presentation.getSlides().indexOf(secondSlide);
        ISlide secondSlideByIndex = presentation.getSlides().get_Item(secondSlideIndex);
    } finally {
        presentation.dispose();
    }
}
```

## **Klona en bild**

Detta exempel visar hur man klonar en befintlig bild. Den klonade bilden läggs automatiskt till i slutet av bildsamlingen.

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

För att ta bort en bild, referera bara till den och anropa `remove`. Detta exempel lägger till en andra bild och tar sedan bort den ursprungliga, så att endast den nya återstår.

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