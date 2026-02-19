---
title: Section
type: docs
weight: 90
url: /androidjava/examples/elements/section/
keywords:
- code example
- section
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Manage slide sections in Aspose.Slides for Android: create, rename, reorder, and group slides with Java examples for PPT, PPTX, and ODP."
---

Examples for managing presentation sections—add, access, remove, and rename them programmatically using **Aspose.Slides for Android via Java**.

## **Add a Section**

Create a section that starts at a specific slide.

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Specify the slide that marks the beginning of the section.
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **Access a Section**

Read section information from a presentation.

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        // Access a section by index.
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Remove a Section**

Delete a previously added section.

```java
static void removeSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISection section = presentation.getSections().addSection("Temporary Section", slide);

        // Remove the first section.
        presentation.getSections().removeSection(section);
    } finally {
        presentation.dispose();
    }
}
```

## **Rename a Section**

Change the name of an existing section.

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
