---
title: Sekce
type: docs
weight: 90
url: /cs/androidjava/examples/elements/section/
keywords:
- ukázka kódu
- sekce
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Spravujte sekce snímků v Aspose.Slides pro Android: vytvářejte, přejmenovávejte, měňte pořadí a seskupujte snímky pomocí ukázek v jazyce Java pro PPT, PPTX a ODP."
---
Příklady správy sekcí prezentace — přidání, přístup, odebrání a přejmenování pomocí programování s **Aspose.Slides for Android via Java**.

## **Přidat sekci**

Vytvořte sekci, která začíná na konkrétním snímku.

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // Určete snímek, který označuje začátek sekce.
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **Přístup k sekci**

Přečtěte si informace o sekci z prezentace.

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        // Přístup k sekci podle indexu.
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **Odstranit sekci**

Odstraňte dříve přidanou sekci.

```java
static void removeSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISection section = presentation.getSections().addSection("Temporary Section", slide);

        // Odeberte první sekci.
        presentation.getSections().removeSection(section);
    } finally {
        presentation.dispose();
    }
}
```

## **Přejmenovat sekci**

Změňte název existující sekce.

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