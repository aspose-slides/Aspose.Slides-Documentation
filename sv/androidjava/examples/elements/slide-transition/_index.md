---
title: Bildövergång
type: docs
weight: 110
url: /sv/androidjava/examples/elements/slide-transition/
keywords:
- kodexempel
- bildövergång
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Behärska bildövergångar i Aspose.Slides för Android: lägg till, anpassa och sekvensera effekter och varaktigheter med Java-exempel för PPT, PPTX, och ODP‑presentationer."
---
Den här artikeln visar hur du använder bildövergångseffekter och tidsinställningar med **Aspose.Slides for Android via Java**.

## **Lägg till en bildövergång**

Applicera en toningsövergång på den första bilden.

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Applicera en toningsövergång.
        slide.getSlideShowTransition().setType(TransitionType.Fade);
    } finally {
        presentation.dispose();
    }
}
```

## **Kom åt en bildövergång**

Läs av den övergångstyp som för närvarande är tilldelad en bild.

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // Åtkomst till övergångstypen.
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Ta bort en bildövergång**

Rensa alla övergångseffekter genom att sätta typen till `None`.

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // Ta bort övergång genom att sätta none.
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **Ställ in övergångens varaktighet**

Ange hur länge bilden visas innan den automatiskt går vidare.

```java
static void setTransitionDuration() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // i millisekunder.
    } finally {
        presentation.dispose();
    }
}
```