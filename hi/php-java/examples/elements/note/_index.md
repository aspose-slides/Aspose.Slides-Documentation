---
title: नोट
type: docs
weight: 240
url: /hi/php-java/examples/elements/note/
keywords:
- नोट
- नोट्स स्लाइड जोड़ें
- नोट्स स्लाइड तक पहुँचें
- नोट्स स्लाइड हटाएँ
- नोट्स टेक्स्ट अपडेट करें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "PHP में Aspose.Slides के साथ स्पीकर नोट्स जोड़ें, पढ़ें, संपादित करें और निर्यात करें: टेक्स्ट को फ़ॉर्मेट करें, स्लाइड के अनुसार नोट्स प्रबंधित करें, और PowerPoint और OpenDocument में दृश्यता नियंत्रित करें।"
---
कैसे **Aspose.Slides for PHP via Java** का उपयोग करके नोट्स स्लाइड जोड़ना, पढ़ना, हटाना और अपडेट करना है, दिखाता है।

## **नोट्स स्लाइड जोड़ें**

एक नोट्स स्लाइड बनाएं और उसमें टेक्स्ट असाइन करें।

```php
function addNote() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $notesSlide = $slide->getNotesSlideManager()->addNotesSlide();
        $notesSlide->getNotesTextFrame()->setText("My note");

        $presentation->save("note.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **नोट्स स्लाइड तक पहुँचें**

मौजूदा नोट्स स्लाइड से टेक्स्ट पढ़ें।

```php
function accessNote() {
    $presentation = new Presentation("note.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $notesSlide = $slide->getNotesSlideManager()->getNotesSlide();
        $notes = $notesSlide->getNotesTextFrame()->getText();
    } finally {
        $presentation->dispose();
    }
}
```

## **नोट्स स्लाइड हटाएँ**

स्लाइड से जुड़ी नोट्स स्लाइड को हटाएँ।

```php
function removeNote() {
    $presentation = new Presentation("note.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $slide->getNotesSlideManager()->removeNotesSlide();

        $presentation->save("note_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **नोट्स टेक्स्ट अपडेट करें**

नोट्स स्लाइड का टेक्स्ट बदलें।

```php
function updateNoteText() {
    $presentation = new Presentation("note.pptx");
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        $notesSlide = $slide->getNotesSlideManager()->getNotesSlide();
        $notesSlide->getNotesTextFrame()->setText("Updated");

        $presentation->save("note_updated.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```