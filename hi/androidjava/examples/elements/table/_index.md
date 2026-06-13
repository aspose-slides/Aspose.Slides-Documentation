---
title: टेबल
type: docs
weight: 120
url: /hi/androidjava/examples/elements/table/
keywords:
- कोड उदाहरण
- टेबल
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android में टेबल्स के साथ काम करें: बनाना, स्वरूपित करना, सेल्स को मर्ज करना, स्टाइल लागू करना, डेटा आयात करना, और PPT, PPTX, और ODP के लिए जावा उदाहरणों के साथ निर्यात करना।"
---
**Aspose.Slides for Android via Java** का उपयोग करके टेबल जोड़ने, उनका उपयोग करने, हटाने और सेल्स को मर्ज करने के उदाहरण।

## **टेबल जोड़ें**

दो पंक्तियों और दो स्तम्भों वाला एक सरल टेबल बनाएं।

```java
static void addTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);
    } finally {
        presentation.dispose();
    }
}
```

## **टेबल तक पहुंचें**

स्लाइड पर पहला टेबल शेप प्राप्त करें।

```java
static void accessTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // स्लाइड पर पहला टेबल प्राप्त करें।
        ITable firstTable = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ITable) {
                firstTable = (ITable) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **टेबल हटाएँ**

स्लाइड से टेबल हटाएं।

```java
static void removeTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        slide.getShapes().remove(table);
    } finally {
        presentation.dispose();
    }
}
```

## **टेबल सेल्स को मर्ज करें**

टेबल की आसन्न कोशिकाओं को एकल कोशिका में मर्ज करें।

```java
static void mergeTableCells() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // सेल्स को मर्ज करें।
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);
    } finally {
        presentation.dispose();
    }
}
```