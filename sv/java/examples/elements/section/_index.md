---
title: Sektion
type: docs
weight: 90
url: /sv/java/examples/elements/section/
keywords:
- kodexempel
- sektion
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Hantera bildsektioner i Aspose.Slides for Java: skapa, byta namn, omordna och gruppera bilder med Java-exempel för PPT, PPTX och ODP."
---
Exempel på hantering av presentationssektioner—lägg till, öppna, ta bort och byt namn på dem programatiskt med **Aspose.Slides for Java**.

## **Lägg till en sektion**

Skapa en sektion som börjar på en specifik bild.

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Ange den bild som markerar början av sektionen.
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **Åtkomst till en sektion**

Läs sektionens information från en presentation.

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        // Åtkomst till en sektion via index.
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