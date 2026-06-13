---
title: SmartArt
type: docs
weight: 140
url: /hi/androidjava/examples/elements/smart-art/
keywords:
  - कोड उदाहरण
  - SmartArt
  - PowerPoint
  - OpenDocument
  - प्रस्तुति
  - Android
  - Java
  - Aspose.Slides
description: "Aspose.Slides for Android में SmartArt के साथ काम करें: Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों के लिए आरेख बनाएँ, संपादित करें, रूपांतरित करें और शैली लागू करें।"
---
यह लेख दर्शाता है कि कैसे SmartArt ग्राफ़िक्स जोड़ें, उन्हें एक्सेस करें, हटाएँ, और लेआउट बदलें **Aspose.Slides for Android via Java** का उपयोग करके.

## **Add SmartArt**
निर्मित लेआउट में से एक का उपयोग करके SmartArt ग्राफ़िक सम्मिलित करें.

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

## **Access SmartArt**
स्लाइड पर पहला SmartArt ऑब्जेक्ट प्राप्त करें.

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

## **Remove SmartArt**
स्लाइड से SmartArt आकार हटाएँ.

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

## **Change SmartArt Layout**
मौजूदा SmartArt ग्राफ़िक के लेआउट प्रकार को अपडेट करें.

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