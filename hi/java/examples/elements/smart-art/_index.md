---
title: SmartArt
type: docs
weight: 140
url: /hi/java/examples/elements/smart-art/
keywords:
- कोड उदाहरण
- SmartArt
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में SmartArt के साथ कार्य करें: Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों के लिए आरेख बनाएं, संपादित करें, परिवर्तित करें और शैली दें।"
---
यह लेख **Aspose.Slides for Java** का उपयोग करके SmartArt ग्राफिक्स को जोड़ने, उन तक पहुँचने, उन्हें हटाने और लेआउट बदलने का प्रदर्शन करता है।

## **SmartArt जोड़ें**

एक निर्मित लेआउट में से एक का उपयोग करके SmartArt ग्राफिक सम्मिलित करें।

```java
static void addSmartArt() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);
    } finally {
        presentation.dispose();
    }
}
```

## **SmartArt तक पहुँचें**

स्लाइड पर पहले SmartArt ऑब्जेक्ट को प्राप्त करें।

```java
static void accessSmartArt() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

        ISmartArt firstSmartArt = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ISmartArt) {
                firstSmartArt = (ISmartArt) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **SmartArt हटाएँ**

स्लाइड से SmartArt आकार को हटाएँ।

```java
static void removeSmartArt() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicProcess);

        slide.getShapes().remove(smartArt);
    } finally {
        presentation.dispose();
    }
}
```

## **SmartArt लेआउट बदलें**

मौजूदा SmartArt ग्राफिक का लेआउट प्रकार अपडेट करें।

```java
static void changeSmartArtLayout() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        ISmartArt smartArt = slide.getShapes().addSmartArt(50, 50, 400, 300, SmartArtLayoutType.BasicBlockList);
        smartArt.setLayout(SmartArtLayoutType.VerticalPictureList);
    } finally {
        presentation.dispose();
    }
}
```