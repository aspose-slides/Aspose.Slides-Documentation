---
title: Diaovergang
type: docs
weight: 110
url: /nl/androidjava/examples/elements/slide-transition/
keywords:
- codevoorbeeld
- diaovergang
- PowerPoint
- OpenDocument
- presentatie
- Android
- Java
- Aspose.Slides
description: "Beheers diaovergangen in Aspose.Slides voor Android: voeg toe, pas aan en rangschik effecten en duur met Java-voorbeelden voor PPT-, PPTX- en ODP-presentaties."
---
Dit artikel laat zien hoe u diaovergangseffecten en -tijden toepast met **Aspose.Slides for Android via Java**.

## **Een diaovergang toevoegen**

Pas een vervagingsovergang toe op de eerste dia.

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Pas een vervagingsovergang toe.
        slide.getSlideShowTransition().setType(TransitionType.Fade);
    } finally {
        presentation.dispose();
    }
}
```

## **Een diaovergang benaderen**

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

        // Verwijder de overgang door None in te stellen.
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **Duur van overgang instellen**

Geef op hoe lang de dia wordt weergegeven voordat deze automatisch wordt voortgezet.

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