---
title: सेक्शन
type: docs
weight: 90
url: /hi/androidjava/examples/elements/section/
keywords:
- कोड उदाहरण
- सेक्शन
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android में स्लाइड सेक्शन प्रबंधित करें: PPT, PPTX, और ODP के लिए जावा उदाहरणों के साथ स्लाइड बनाएं, उनका नाम बदलें, क्रम बदलें और समूहित करें।"
---
प्रेजेंटेशन सेक्शन को प्रोग्रामेटिक रूप से प्रबंधित करने के उदाहरण—जोड़ना, एक्सेस करना, हटाना और नाम बदलना, **Aspose.Slides for Android via Java** का उपयोग करके।

## **सेक्शन जोड़ें**

एक विशिष्ट स्लाइड से शुरू होने वाला सेक्शन बनाएं।

```java
static void addSection() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // सेक्शन की शुरुआत को दर्शाने वाली स्लाइड निर्दिष्ट करें।
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

        // इंडेक्स द्वारा सेक्शन तक पहुंचें।
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

        // पहला सेक्शन हटाएँ।
        presentation.getSections().removeSection(section);
    } finally {
        presentation.dispose();
    }
}
```

## **सेक्शन का नाम बदलें**

मौजूद सेक्शन का नाम बदलें।

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