---
title: Przejście slajdu
type: docs
weight: 110
url: /pl/androidjava/examples/elements/slide-transition/
keywords:
- przykład kodu
- przejście slajdu
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Opanuj przejścia slajdów w Aspose.Slides dla Androida: dodawaj, dostosowuj i kolejkuj efekty oraz czasy trwania przy użyciu przykładów w Java dla prezentacji PPT, PPTX i ODP."
---
Ten artykuł demonstruje stosowanie efektów przejść slajdów oraz ich czasów przy użyciu **Aspose.Slides for Android via Java**.

## **Dodaj przejście slajdu**

Zastosuj efekt płynnego przejścia do pierwszego slajdu.

```java
static void addSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Zastosuj przejście zanikania.
        slide.getSlideShowTransition().setType(TransitionType.Fade);
    } finally {
        presentation.dispose();
    }
}
```

## **Uzyskaj dostęp do przejścia slajdu**

Odczytaj typ przejścia obecnie przypisany do slajdu.

```java
static void accessSlideTransition() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setType(TransitionType.Push);

        // Uzyskaj dostęp do typu przejścia.
        int type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Usuń przejście slajdu**

Usuń dowolny efekt przejścia, ustawiając typ na `None`.

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

Określ, jak długo slajd jest wyświetlany przed automatycznym przejściem.

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