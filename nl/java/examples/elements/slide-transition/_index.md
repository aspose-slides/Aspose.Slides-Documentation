---
title: Diaovergang
type: docs
weight: 110
url: /nl/java/examples/elements/slide-transition/
keywords:
- codevoorbeeld
- diaovergang
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Beheer diaovergangen in Aspose.Slides voor Java: voeg toe, pas aan en rangschik effecten en duur met Java-voorbeelden voor PPT-, PPTX- en ODP-presentaties."
---
Dit artikel demonstreert het toepassen van diaovergangseffecten en tijdinstellingen met **Aspose.Slides for Java**.

## **Diaovergang toevoegen**

Pas een fade‑overgangseffect toe op de eerste dia.

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Pas een fade-overgang toe.
        slide.getSlideShowTransition().setType(TransitionType.Fade);
    } finally {
        presentation.dispose();
    }
}
```

## **Toegang tot een diaovergang**

Lees het overgangstype dat momenteel aan een dia is toegewezen.

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // Toegang tot het overgangstype.
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Een diaovergang verwijderen**

Verwijder elk overgangseffect door het type in te stellen op `None`.

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // Verwijder de overgang door deze op None te zetten.
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **De duur van de overgang instellen**

Specificeer hoe lang de dia wordt weergegeven voordat deze automatisch wordt voortgezet.

```java
static void setTransitionDuration() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // in milliseconden.
    } finally {
        presentation.dispose();
    }
}
```