---
title: समूह आकृति
type: docs
weight: 170
url: /hi/androidjava/examples/elements/group-shape/
keywords:
- कोड उदाहरण
- समूह आकृति
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android में समूहित आकृतियों को प्रबंधित करें: Java उदाहरणों के साथ PPT, PPTX, और ODP प्रस्तुतियों में समूह आकृतियों को बनाना, नेस्ट करना, संरेखित करना, क्रम बदलना और शैली लागू करना।"
---
**Aspose.Slides for Android via Java** का उपयोग करके आकारों के समूह बनाने, उन्हें एक्सेस करने, अनग्रुप करने और हटाने के उदाहरण।

## **समूह आकृति जोड़ें**

दो बुनियादी आकारों वाले एक समूह बनाएं।

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

## **समूह आकृति तक पहुँचें**

स्लाइड से पहली समूह आकृति प्राप्त करें।

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

## **समूह आकृति हटाएँ**

स्लाइड से समूह आकृति हटाएं।

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

आकारों को समूह कंटेनर से बाहर निकालें।

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