---
title: सेक्शन
type: docs
weight: 90
url: /hi/php-java/examples/elements/section/
keywords:
- सेक्शन
- स्लाइड सेक्शन
- सेक्शन जोड़ें
- सेक्शन तक पहुँचें
- सेक्शन हटाएँ
- सेक्शन का नाम बदलें
- कोड उदाहरण
- PowerPoint
- OpenDocument
- प्रस्तुति
- PHP
- Aspose.Slides
description: "Aspose.Slides के साथ PHP में स्लाइड सेक्शन को प्रबंधित करें: आसानी से बनाएं, नाम बदलें, पुनः क्रमित करें, सेक्शन के बीच स्लाइड ले जाएँ, और PPT, PPTX तथा ODP के लिए दृश्यता को नियंत्रित करें।"
---
प्रस्तुति सेक्शन को प्रबंधित करने के उदाहरण — उन्हें प्रोग्रामेटिक रूप से जोड़ना, पहुँच प्राप्त करना, हटाना और पुनः नाम देना **Aspose.Slides for PHP via Java** का उपयोग करके।

## **सेक्शन जोड़ें**

एक सेक्शन बनाएं जो एक विशिष्ट स्लाइड से शुरू हो।

```php
function addSection() {
    $presentation = new Presentation();
    try {
        $slide = $presentation->getSlides()->get_Item(0);

        // सेक्शन की शुरुआत को चिह्नित करने वाली स्लाइड निर्दिष्ट करें।
        $presentation->getSections()->addSection("New Section", $slide);

        $presentation->save("section.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **सेक्शन तक पहुँचें**

प्रस्तुति से सेक्शन जानकारी पढ़ें।

```php
function accessSection() {
    $presentation = new Presentation("section.pptx");
    try {
        // इंडेक्स द्वारा सेक्शन तक पहुँचें।
        $section = $presentation->getSections()->get_Item(0);
        $sectionName = $section->getName();
    } finally {
        $presentation->dispose();
    }
}
```

## **सेक्शन हटाएँ**

पहले जोड़ा गया सेक्शन हटाएँ।

```php
function removeSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);

        // सेक्शन हटाएँ।
        $presentation->getSections()->removeSection($section);

        $presentation->save("section_removed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

## **सेक्शन का नाम बदलें**

मौजूदा सेक्शन का नाम बदलें।

```php
function renameSection() {
    $presentation = new Presentation("section.pptx");
    try {
        $section = $presentation->getSections()->get_Item(0);
        $section->setName("New Name");

        $presentation->save("section_renamed.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```