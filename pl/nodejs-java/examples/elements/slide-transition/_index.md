---
title: Przejście slajdu
type: docs
weight: 110
url: /pl/nodejs-java/examples/elements/slide-transition/
keywords:
- przykład kodu
- przejście slajdu
- PowerPoint
- OpenDocument
- prezentacja
- Node.js
- JavaScript
- Aspose.Slides
description: "Opanuj przejścia slajdów w Aspose.Slides dla Node.js: dodawaj, dostosowuj i kolejkuj efekty oraz czasy trwania w przykładach dla prezentacji PPT, PPTX i ODP."
---
Ten artykuł demonstruje stosowanie efektów przejścia slajdów i ich czasowania przy użyciu **Aspose.Slides for Node.js via Java**.

## **Dodaj przejście slajdu**

Zastosuj efekt przejścia zanikania do pierwszego slajdu.

```js
function addSlideTransition() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Zastosuj przejście zanikania.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.Fade);

        presentation.save("slide_transition.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Uzyskaj dostęp do przejścia slajdu**

Odczytaj typ przejścia aktualnie przypisany do slajdu.

```js
function accessSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Uzyskaj dostęp do typu przejścia.
        let type = slide.getSlideShowTransition().getType();
    } finally {
        presentation.dispose();
    }
}
```

## **Usuń przejście slajdu**

Wyczyść wszelkie efekty przejścia, ustawiając typ na `None`.

```js
function removeSlideTransition() {
    let presentation = new aspose.slides.Presentation("slide_transition.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // Usuń przejście, ustawiając None.
        slide.getSlideShowTransition().setType(aspose.slides.TransitionType.None);

        presentation.save("slide_transition_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Ustaw czas trwania przejścia**

Określ, jak długo slajd jest wyświetlany przed automatycznym przejściem.

```js
function setTransitionDuration() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getSlideShowTransition().setAdvanceOnClick(true);
        slide.getSlideShowTransition().setAdvanceAfterTime(2000); // w milisekundach.

        presentation.save("slide_transition_duration.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```