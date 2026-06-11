---
title: Sektion
type: docs
weight: 90
url: /sv/androidjava/examples/elements/section/
keywords:
- kodexempel
- sektion
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Hantera bildsektioner i Aspose.Slides för Android: skapa, byta namn, omordna och gruppera bilder med Java-exempel för PPT, PPTX och ODP."
---
Exempel på hantering av presentationssektioner—lägga till, komma åt, ta bort och byta namn på dem programatiskt med **Aspose.Slides for Android via Java**.

## **Lägg till en sektion**

Skapa en sektion som börjar på en specifik bild.

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Ange bilden som markerar början av sektionen.
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **Kom åt en sektion**

Läs sektionens information från en presentation.

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        // Kom åt en sektion med index.
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Ta bort en sektion**

Ta bort en tidigare tillagd sektion.

```java
static void removeSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISection section = presentation.getSections().addSection("Temporary Section", slide);

        // Ta bort den första sektionen.
        presentation.getSections().removeSection(section);
    } finally {
        presentation.dispose();
    }
}
```

## **Byt namn på en sektion**

Ändra namnet på en befintlig sektion.

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