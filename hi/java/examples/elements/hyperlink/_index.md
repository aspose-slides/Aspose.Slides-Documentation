---
title: हाइपरलिंक
type: docs
weight: 130
url: /hi/java/examples/elements/hyperlink/
keywords:
- कोड उदाहरण
- हाइपरलिंक
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में हाइपरलिंक्स जोड़ें और प्रबंधित करें: लिंक टेक्स्ट, आकार, और चित्र, PPT, PPTX, और ODP के लिए लक्ष्य और कार्य सेट करें, Java उदाहरणों के साथ।"
---
यह लेख आकारों पर हाइपरलिंक्स को जोड़ने, एक्सेस करने, हटाने और अपडेट करने को **Aspose.Slides for Java** का उपयोग करके दर्शाता है।

## **हाइपरलिंक जोड़ें**

बाहरी वेबसाइट की ओर इशारा करने वाले हाइपरलिंक के साथ एक आयताकार आकार बनाएं।

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

आकार के पाठ भाग से हाइपरलिंक की जानकारी पढ़ें।

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

आकार के पाठ से हाइपरलिंक को साफ़ करें।

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

मौजूदा हाइपरलिंक के लक्ष्य को बदलें। `HyperlinkManager` का उपयोग करके ऐसे पाठ को संशोधित करें जिसमें पहले से हाइपरलिंक हो, जो पावरपॉइंट के सुरक्षित हाइपरलिंक अपडेट करने के तरीके की नकल करता है।

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

        // मौजूदा पाठ में हाइपरलिंक बदलने के लिए इसे प्रयोग किया जाना चाहिए
        // HyperlinkManager का उपयोग करना चाहिए न कि प्रॉपर्टी को सीधे सेट करना।
        // यह पावरपॉइंट के सुरक्षित हाइपरलिंक अपडेट करने के तरीके की नकल करता है।
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");
    } finally {
        presentation.dispose();
    }
}
```