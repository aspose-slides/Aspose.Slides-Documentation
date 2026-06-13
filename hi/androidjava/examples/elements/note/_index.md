---
title: नोट
type: docs
weight: 240
url: /hi/androidjava/examples/elements/note/
keywords:
- कोड उदाहरण
- नोट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android में स्लाइड नोट्स के साथ काम करें: स्पष्ट Java उदाहरणों का उपयोग करके PPT, PPTX, और ODP में स्पीकर नोट्स को जोड़ें, पढ़ें, संपादित करें और निर्यात करें।"
---
यह लेख **Aspose.Slides for Android via Java** का उपयोग करके नोट्स स्लाइड को जोड़ने, पढ़ने, हटाने और अद्यतन करने का प्रदर्शन करता है।

## **नोट्स स्लाइड जोड़ें**

एक नोट्स स्लाइड बनाएं और उसमें टेक्स्ट असाइन करें।

```java
static void addNote() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
        slide.getNotesSlideManager().getNotesSlide().getNotesTextFrame().setText("My note");
    } finally {
        presentation.dispose();
    }
}
```

## **नोट्स स्लाइड तक पहुंचें**

मौजूदा नोट्स स्लाइड से टेक्स्ट पढ़ें।

```java
static void accessNote() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();

        String notes = notesSlide.getNotesTextFrame().getText();
    } finally {
        presentation.dispose();
    }
}
```

## **नोट्स स्लाइड हटाएं**

स्लाइड से जुड़ी नोट्स स्लाइड को हटाएं।

```java
static void removeNote() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();

        slide.getNotesSlideManager().removeNotesSlide();
    } finally {
        presentation.dispose();
    }
}
```

## **नोट्स टेक्स्ट अपडेट करें**

नोट्स स्लाइड के टेक्स्ट को बदलें।

```java
static void updateNoteText() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();

        slide.getNotesSlideManager().getNotesSlide().getNotesTextFrame().setText("Old");
        slide.getNotesSlideManager().getNotesSlide().getNotesTextFrame().setText("Updated");
    } finally {
        presentation.dispose();
    }
}
```