---
title: समूह आकार
type: docs
weight: 170
url: /hi/java/examples/elements/group-shape/
keywords:
- कोड उदाहरण
- समूह आकार
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में समूहित आकारों को प्रबंधित करें: PPT, PPTX और ODP प्रस्तुतियों में Java उदाहरणों के साथ समूह आकार बनाना, नेस्ट करना, संरेखित करना, पुन: क्रमित करना और स्टाइल करना।"
---
**Aspose.Slides for Java** का उपयोग करके आकारों के समूह बनाने, उन्हें एक्सेस करने, अनग्रुप करने और हटाने के उदाहरण।

## **समूह आकार जोड़ें**

दो बुनियादी आकारों को सम्मिलित करते हुए एक समूह बनाएं।

```java
static void addGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);
        group.getShapes().addAutoShape(ShapeType.Ellipse, 60, 0, 50, 50);
    } finally {
        presentation.dispose();
    }
}
```

## **समूह आकार एक्सेस करें**

स्लाइड से पहला समूह आकार प्राप्त करें।

```java
static void accessGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        IGroupShape firstGroup = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IGroupShape) {
                firstGroup = (IGroupShape) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **समूह आकार हटाएँ**

स्लाइड से एक समूह आकार हटाएं।

```java
static void removeGroupShape() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();

        slide.getShapes().remove(group);
    } finally {
        presentation.dispose();
    }
}
```

## **आकारों को अनग्रुप करें**

आकारों को समूह कंटेनर से बाहर ले जाएँ।

```java
static void ungroupShapes() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IGroupShape group = slide.getShapes().addGroupShape();
        IAutoShape rect = group.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 50, 50);

        // आकार को समूह से बाहर ले जाएँ।
        slide.getShapes().addClone(rect);
        group.getShapes().remove(rect);
    } finally {
        presentation.dispose();
    }
}
```