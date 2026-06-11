---
title: Sekcja
type: docs
weight: 90
url: /pl/androidjava/examples/elements/section/
keywords:
- przykład kodu
- sekcja
- PowerPoint
- OpenDocument
- prezentacja
- Android
- Java
- Aspose.Slides
description: "Zarządzaj sekcjami slajdów w Aspose.Slides for Android: twórz, zmieniaj nazwy, zmieniaj kolejność i grupuj slajdy przy użyciu przykładów w Javie dla formatów PPT, PPTX i ODP."
---
Przykłady zarządzania sekcjami prezentacji — dodawanie, dostęp, usuwanie i zmienianie ich nazw programowo przy użyciu **Aspose.Slides for Android via Java**.

## **Dodaj sekcję**

Utwórz sekcję, która zaczyna się od określonego slajdu.

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

## **Uzyskaj dostęp do sekcji**

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