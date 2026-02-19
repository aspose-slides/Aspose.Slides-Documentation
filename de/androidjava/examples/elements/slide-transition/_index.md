---
title: Folienübergang
type: docs
weight: 110
url: /de/androidjava/examples/elements/slide-transition/
keywords:
- Codebeispiel
- Folienübergang
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Master-Folienübergänge in Aspose.Slides für Android: Hinzufügen, Anpassen und Sequenzieren von Effekten und Dauern mit Java-Beispielen für PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel demonstriert das Anwenden von Folienübergangseffekten und Zeitpunkten mit **Aspose.Slides for Android via Java**.

## **Folienübergang hinzufügen**

Wenden Sie einen Fade‑Übergangseffekt auf die erste Folie an.

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Fade-Übergang anwenden.
        slide.getSlideShowTransition().setType(TransitionType.Fade);
    } finally {
        presentation.dispose();
    }
}
```

## **Zugriff auf einen Folienübergang**

Lesen Sie den aktuell einer Folie zugewiesenen Übergangstyp.

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // Zugriff auf den Übergangstyp.
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Folienübergang entfernen**

Entfernen Sie jeden Übergangseffekt, indem Sie den Typ auf `None` setzen.

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // Übergang entfernen, indem er auf None gesetzt wird.
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **Übergangsdauer festlegen**

Geben Sie an, wie lange die Folie angezeigt wird, bevor sie automatisch weitergeht.

```java
static void setTransitionDuration() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // in Millisekunden.
    } finally {
        presentation.dispose();
    }
}
```