---
title: सेक्शन
type: docs
weight: 90
url: /hi/java/examples/elements/section/
keywords:
- कोड उदाहरण
- सेक्शन
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रेजेंटेशन
- जावा
- Aspose.Slides
description: "Aspose.Slides for Java में स्लाइड सेक्शनों को प्रबंधित करें: Java उदाहरणों के साथ PPT, PPTX और ODP के लिए स्लाइड बनाएं, उनका नाम बदलें, पुनः क्रमित करें, और समूहित करें।"
---
प्रेजेंटेशन सेक्शन को प्रोग्रामेटिकली प्रबंधित करने के उदाहरण — जोड़ें, एक्सेस करें, हटाएँ और उनका नाम बदलें **Aspose.Slides for Java** का उपयोग करके।

## **सेक्शन जोड़ें**

विशिष्ट स्लाइड से शुरू होने वाला एक सेक्शन बनाएं।

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // सेक्शन की शुरुआत को चिह्नित करने वाली स्लाइड निर्दिष्ट करें।
        presentation.getSections().addSection("New Section", slide);
    } finally {
        presentation.dispose();
    }
}
```

## **सेक्शन एक्सेस करें**

प्रेजेंटेशन से सेक्शन की जानकारी पढ़ें।

```java
static void accessSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        presentation.getSections().addSection("My Section", slide);

        // सूचकांक से सेक्शन तक पहुंचें।
        ISection section = presentation.getSections().get_Item(0);
        String sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **सेक्शन हटाएँ**

पहले जोड़े गए सेक्शन को हटाएँ।

```java
static void removeSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISection section = presentation.getSections().addSection("Temporary Section", slide);

        // पहले सेक्शन को हटाएँ।
        presentation.getSections().removeSection(section);
    } finally {
        presentation.dispose();
    }
}
```

## **सेक्शन का नाम बदलें**

मौजूदा सेक्शन का नाम बदलें।

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