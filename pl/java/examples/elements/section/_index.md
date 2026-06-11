---
title: Sekcja
type: docs
weight: 90
url: /pl/java/examples/elements/section/
keywords:
- przykład kodu
- sekcja
- PowerPoint
- OpenDocument
- prezentacja
- Java
- Aspose.Slides
description: "Zarządzaj sekcjami slajdów w Aspose.Slides for Java: twórz, zmieniaj nazwę, przestawiaj kolejność i grupuj slajdy za pomocą przykładów Java dla PPT, PPTX i ODP."
---
Przykłady zarządzania sekcjami prezentacji—dodawanie, dostęp, usuwanie i zmiana nazwy programowo przy użyciu **Aspose.Slides for Java**.

## **Dodaj sekcję**

Utwórz sekcję zaczynającą się od określonego slajdu.

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Określ slajd, który oznacza początek sekcji.
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **Dostęp do sekcji**

Odczytaj informacje o sekcji z prezentacji.

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        // Uzyskaj dostęp do sekcji po indeksie.
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Usuń sekcję**

Usuń wcześniej dodaną sekcję.

```java
static void removeSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISection section = presentation.getSections().addSection("Temporary Section", slide);

        // Usuń pierwszą sekcję.
        presentation.getSections().removeSection(section);
    } finally {
        presentation.dispose();
    }
}
```

## **Zmień nazwę sekcji**

Zmień nazwę istniejącej sekcji.

```java
static void renameSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("Old Name", slide);

        ISection section = presentation.getSections().get_Item(0);
        section.setName("New Name");
    } finally {
        presentation.dispose();
    }
}
```