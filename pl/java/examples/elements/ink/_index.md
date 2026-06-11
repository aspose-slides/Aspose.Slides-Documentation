---
title: Atrament
type: docs
weight: 180
url: /pl/java/examples/elements/ink/
keywords:
- przykład kodu
- atrament
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Praca z atramentem w Aspose.Slides dla Javy: rysowanie, importowanie i edytowanie pociągnięć, dostosowywanie koloru i szerokości oraz eksport do PPT, PPTX i ODP przy użyciu przykładów w Javie."
---
Ten artykuł zawiera przykłady dostępu do istniejących kształtów atramentu i ich usuwania przy użyciu **Aspose.Slides for Java**.

> ❗ **Uwaga:** Kształty atramentu reprezentują dane wejściowe użytkownika z wyspecjalizowanych urządzeń. Aspose.Slides nie może tworzyć nowych pociągnięć atramentu programowo, ale możesz odczytać i modyfikować istniejący atrament.

## **Dostęp do atramentu**

Odczytaj tagi z pierwszego kształtu atramentu na slajdzie.

```java
static void accessInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IShape shape = slide.getShapes().get_Item(0);
        if (shape instanceof IInk) {
            IInk inkShape = (IInk) shape;
            ITagCollection tags = inkShape.getCustomData().getTags();
            if (tags.size() > 0) {
                String tagName = tags.getNameByIndex(0);
                // Użyj tagName w razie potrzeby.
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **Usuwanie atramentu**

Usuń kształt atramentu ze slajdu, jeśli istnieje.

```java
static void removeInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IInk ink = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IInk) {
                ink = (IInk) shape;
                break;
            }
        }
        if (ink != null) {
            slide.getShapes().remove(ink);
        }
    } finally {
        presentation.dispose();
    }
}
```