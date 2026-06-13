---
title: इंक
type: docs
weight: 180
url: /hi/androidjava/examples/elements/ink/
keywords:
- कोड उदाहरण
- इंक
- PowerPoint
- OpenDocument
- प्रस्तुतीकरण
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android में इंक के साथ काम करें: स्ट्रोक बनाएँ, आयात करें, और संपादित करें, रंग और चौड़ाई समायोजित करें, और Java उदाहरणों का उपयोग करके PPT, PPTX, और ODP में निर्यात करें।"
---
यह लेख मौजूदा इंक आकृतियों तक पहुँचने और उन्हें **Aspose.Slides for Android via Java** का उपयोग करके हटाने के उदाहरण प्रदान करता है।

> ❗ **नोट:** इंक आकृतियाँ विशेष उपकरणों से उपयोगकर्ता इनपुट का प्रतिनिधित्व करती हैं। Aspose.Slides प्रोग्रामेटिक रूप से नई इंक स्ट्रोक नहीं बना सकता, लेकिन आप मौजूदा इंक को पढ़ सकते हैं और संशोधित कर सकते हैं।

## **इंक तक पहुँचें**

स्लाइड पर पहली इंक आकृति से टैग पढ़ें।

```java
static void accessInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IShape shape = slide.getShapes().get_Item(0);
        if (shape instanceof IInk) {
            IInk inkShape = (IInk) shape;
            ITagCollection tags = inkShape.getCustomData().getTags();
            if (tags.size() > 0) {
                String tagName = tags.getNameByIndex(0);
                // आवश्यकतानुसार tagName का उपयोग करें।
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **इंक हटाएँ**

यदि कोई इंक आकृति मौजूद हो, तो स्लाइड से उसे हटाएँ।

```java
static void removeInk() {
    Presentation presentation = new Presentation("ink.pptx");
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IInk ink = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IInk) {
                ink = (IInk) shape;
                break;
            }
        }
        if (ink != null) {
            slide.getShapes().remove(ink);
        }
    } finally {
        presentation.dispose();
    }
}
```