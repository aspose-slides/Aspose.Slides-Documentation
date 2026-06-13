---
title: कनेक्टर
type: docs
weight: 190
url: /hi/java/examples/elements/connector/
keywords:
- कोड उदाहरण
- कनेक्टर
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके आकारों के बीच कनेक्टर जोड़ने, मार्ग निर्धारित करने और शैलीबद्ध करने के तरीके सीखें, PPT, PPTX और ODP प्रस्तुतियों के लिए जावा उदाहरणों के साथ।"
---
यह लेख दर्शाता है कि **Aspose.Slides for Java** का उपयोग करके आकारों को कनेक्टर से कैसे जोड़ें और उनके लक्ष्य को कैसे बदलें।

## **कनेक्टर जोड़ें**

स्लाइड में दो बिंदुओं के बीच एक कनेक्टर आकार डालें।

```java
static void addConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);
    } finally {
        presentation.dispose();
    }
}
```

## **कनेक्टर तक पहुँचें**

स्लाइड में जोड़ा गया पहला कनेक्टर आकार प्राप्त करें।

```java
static void accessConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        // स्लाइड पर पहला कनेक्टर प्राप्त करें।
        IConnector connector = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IConnector) {
                connector = (IConnector) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **कनेक्टर हटाएँ**

स्लाइड से एक कनेक्टर हटाएँ।

```java
static void removeConnector() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        slide.getShapes().remove(connector);
    } finally {
        presentation.dispose();
    }
}
```

## **आकारों को पुनः कनेक्ट करें**

प्रारंभ और अंत लक्ष्य निर्धारित करके दो आकारों को एक कनेक्टर से जोड़ें।

```java
static void reconnectShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
        IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 50, 50);
        IConnector connector = slide.getShapes().addConnector(ShapeType.BentConnector2, 0, 0, 100, 100);

        connector.setStartShapeConnectedTo(shape1);
        connector.setEndShapeConnectedTo(shape2);
    } finally {
        presentation.dispose();
    }
}
```