---
title: Abschnitt
type: docs
weight: 90
url: /de/androidjava/examples/elements/section/
keywords:
- Codebeispiel
- Abschnitt
- PowerPoint
- OpenDocument
- Präsentation
- Android
- Java
- Aspose.Slides
description: "Verwalten Sie Folienabschnitte in Aspose.Slides für Android: Erstellen, Umbenennen, Neuordnen und Gruppieren von Folien mit Java‑Beispielen für PPT, PPTX und ODP."
---
Beispiele für die Verwaltung von Präsentationsabschnitten—Hinzufügen, Zugreifen, Entfernen und Umbenennen programmgesteuert mit **Aspose.Slides for Android via Java**.

## **Abschnitt hinzufügen**

Erstellen Sie einen Abschnitt, der bei einer bestimmten Folie beginnt.

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Gibt die Folie an, die den Beginn des Abschnitts markiert.
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **Abschnitt zugreifen**

Lesen Sie Abschnittsinformationen aus einer Präsentation.

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        // Greift auf einen Abschnitt nach Index zu.
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Abschnitt entfernen**

Löschen Sie einen zuvor hinzugefügten Abschnitt.

```java
static void removeSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISection section = presentation.getSections().addSection("Temporary Section", slide);

        // Entfernt den ersten Abschnitt.
        presentation.getSections().removeSection(section);
    } finally {
        presentation.dispose();
    }
}
```

## **Abschnitt umbenennen**

Ändern Sie den Namen eines vorhandenen Abschnitts.

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