---
title: Szakasz
type: docs
weight: 90
url: /hu/androidjava/examples/elements/section/
keywords:
- kódrészlet
- szakasz
- PowerPoint
- OpenDocument
- bemutató
- Android
- Java
- Aspose.Slides
description: "Kezelje a diák szakaszait az Aspose.Slides for Androidban: hozza létre, nevezze át, rendezze újra és csoportosítsa a diákat Java példákkal PPT, PPTX és ODP formátumokhoz."
---
Példák a bemutató szakaszok kezelésére — hozzáadás, elérés, eltávolítás és átnevezés programozott módon a **Aspose.Slides for Android via Java** használatával.

## **Szakasz hozzáadása**

Hozzon létre egy szakaszt, amely egy adott dián kezdődik.

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Adja meg azt a diát, amely a szakasz kezdetét jelöli.
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **Szakasz elérése**

Olvassa be a szakasz információit egy bemutatóból.

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        // Egy szakasz elérése index alapján.
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Szakasz eltávolítása**

Törölje a korábban hozzáadott szakaszt.

```java
static void removeSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISection section = presentation.getSections().addSection("Temporary Section", slide);

        // Távolítsa el az első szakaszt.
        presentation.getSections().removeSection(section);
    } finally {
        presentation.dispose();
    }
}
```

## **Szakasz átnevezése**

Módosítsa egy meglévő szakasz nevét.

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