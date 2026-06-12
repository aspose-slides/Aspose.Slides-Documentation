---
title: Sectie
type: docs
weight: 90
url: /nl/java/examples/elements/section/
keywords:
- codevoorbeeld
- sectie
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Beheer dia-secties in Aspose.Slides for Java: maak, hernoem, hersorteer en groepeer dia's met Java-voorbeelden voor PPT, PPTX en ODP."
---
Voorbeelden voor het beheren van presentatiesecties—toevoegen, openen, verwijderen en hernoemen via code met **Aspose.Slides for Java**.

## **Sectie toevoegen**

Maak een sectie die start bij een specifieke dia.

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Geef de dia op die het begin van de sectie aangeeft.
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **Sectie benaderen**

Lees sectie‑informatie uit een presentatie.

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        // Benader een sectie via index.
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Sectie verwijderen**

Verwijder een eerder toegevoegde sectie.

```java
static void removeSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISection section = presentation.getSections().addSection("Temporary Section", slide);

        // Verwijder de eerste sectie.
        presentation.getSections().removeSection(section);
    } finally {
        presentation.dispose();
    }
}
```

## **Sectie hernoemen**

Wijzig de naam van een bestaande sectie.

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