---
title: हेडर फुटर
type: docs
weight: 220
url: /hi/java/examples/elements/header-footer/
keywords:
- कोड उदाहरण
- हेडर
- फुटर
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ स्लाइड हेडर और फुटर को नियंत्रित करें: PPT, PPTX, और ODP में तिथि, स्लाइड नंबर, और कस्टम टेक्स्ट जोड़ें, Java उदाहरणों के साथ।"
---
यह लेख **Aspose.Slides for Java** का उपयोग करके फ़ूटर जोड़ने और तिथि व समय प्लेसहोल्डर को अपडेट करने का प्रदर्शन करता है।

## **फ़ूटर जोड़ें**

स्लाइड के फ़ूटर क्षेत्र में टेक्स्ट जोड़ें और इसे दृश्यमान बनाएं।

```java
static void addHeaderFooter() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```

## **तिथि और समय अपडेट करें**

स्लाइड पर तिथि और समय प्लेसहोल्डर को संशोधित करें।

```java
static void updateDateTime() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);
    } finally {
        presentation.dispose();
    }
}
```