---
title: Folienübergang
type: docs
weight: 110
url: /de/java/examples/elements/slide-transition/
keywords:
- Codebeispiel
- Folienübergang
- PowerPoint
- OpenDocument
- Präsentation
- Java
- Aspose.Slides
description: "Meistern Sie Folienübergänge in Aspose.Slides for Java: Hinzufügen, Anpassen und Sequenzieren von Effekten und Dauern mit Java-Beispielen für PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel demonstriert, wie man Folienübergangseffekte und Zeitsteuerungen mit **Aspose.Slides for Java** anwendet.

## **Einen Folienübergang hinzufügen**

Wenden Sie einen Fade-Übergangseffekt auf die erste Folie an.

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

## **Einen Folienübergang entfernen**

Entfernen Sie jeden Übergangseffekt, indem Sie den Typ auf `None` setzen.

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // Übergang entfernen durch Setzen auf None.
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