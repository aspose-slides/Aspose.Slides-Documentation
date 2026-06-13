---
title: हाइपरलिंक
type: docs
weight: 130
url: /hi/androidjava/examples/elements/hyperlink/
keywords:
- कोड उदाहरण
- हाइपरलिंक
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android में हाइपरलिंक जोड़ें और प्रबंधित करें: लिंक टेक्स्ट, आकार और छवियों के साथ, PPT, PPTX और ODP के लिए लक्ष्य और क्रियाएँ सेट करें, Java उदाहरणों के साथ।"
---
यह लेख आकारों पर हाइपरलिंक जोड़ना, एक्सेस करना, हटाना और अपडेट करना दर्शाता है, **Aspose.Slides for Android via Java** का उपयोग करके।

## **हाइपरलिंक जोड़ें**

एक बाहरी वेबसाइट की ओर इंगित हाइपरलिंक के साथ एक आयताकार आकार बनाएं।

```java
static void addHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));
    } finally {
        presentation.dispose();
    }
}
```

## **हाइपरलिंक एक्सेस करें**

एक आकार के टेक्स्ट भाग से हाइपरलिंक जानकारी पढ़ें।

```java
static void accessHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        IHyperlink hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **हाइपरलिंक हटाएँ**

एक आकार के टेक्स्ट से हाइपरलिंक हटाएं।

```java
static void removeHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com"));

        textPortion.getPortionFormat().setHyperlinkClick(null);
    } finally {
        presentation.dispose();
    }
}
```

## **हाइपरलिंक अपडेट करें**

मौजूदा हाइपरलिंक का लक्ष्य बदलें। `HyperlinkManager` का उपयोग करके ऐसे टेक्स्ट को संशोधित करें जिसमें पहले से हाइपरलिंक हो, जो PowerPoint के सुरक्षित हाइपरलिंक अपडेट करने के तरीके की नकल करता है।

```java
static void updateHyperlink() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        IPortion textPortion = paragraph.getPortions().get_Item(0);
        textPortion.getPortionFormat().setHyperlinkClick(new Hyperlink("https://old.example.com"));

        // मौजूदा टेक्स्ट में हाइपरलिंक को बदलना इस माध्यम से किया जाना चाहिए
        // HyperlinkManager का उपयोग करें, सीधे प्रॉपर्टी सेट करने के बजाय।
        // यह PowerPoint के सुरक्षित हाइपरलिंक अपडेट करने के तरीके की नकल करता है।
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");
    } finally {
        presentation.dispose();
    }
}
```