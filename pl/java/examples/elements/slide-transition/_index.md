---
title: Przejście slajdu
type: docs
weight: 110
url: /pl/java/examples/elements/slide-transition/
keywords:
- przykład kodu
- przejście slajdu
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Opanuj przejścia slajdów w Aspose.Slides for Java: dodawaj, dostosowuj i kolejkuj efekty oraz czasy trwania, korzystając z przykładów Java dla prezentacji PPT, PPTX i ODP."
---
Ten artykuł demonstruje stosowanie efektów przejść slajdów oraz ich czasu z **Aspose.Slides for Java**.

## **Dodaj przejście slajdu**

Zastosuj efekt zanikania jako przejście pierwszego slajdu.

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Zastosuj efekt zanikania.
        slide.getSlideShowTransition().setType(TransitionType.Fade);
    } finally {
        presentation.dispose();
    }
}
```

## **Odczytaj przejście slajdu**

Odczytaj typ przejścia aktualnie przypisany do slajdu.

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // Odczytaj typ przejścia.
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Usuń przejście slajdu**

Usuń wszelkie efekty przejścia, ustawiając typ na `None`.

```java
static void removeSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Fade);

        // Usuń przejście, ustawiając brak.
        slide.getSlideShowTransition().setType(TransitionType.None);
    } finally {
        presentation.dispose();
    }
}
```

## **Ustaw czas trwania przejścia**

Określ, jak długo slajd jest wyświetlany przed automatycznym przejściem dalej.

```java
static void setTransitionDuration() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // w milisekundach.
    } finally {
        presentation.dispose();
    }
}
```