---
title: तालिका
type: docs
weight: 120
url: /hi/java/examples/elements/table/
keywords:
- कोड उदाहरण
- तालिका
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में तालिकाओं के साथ कार्य करें: बनाएं, स्वरूपित करें, कोशिकाओं को मिलाएँ, शैलियाँ लागू करें, डेटा आयात करें, और PPT, PPTX, तथा ODP के लिए Java उदाहरणों के साथ निर्यात करें।"
---
**Aspose.Slides for Java** का उपयोग करके तालिकाओं को जोड़ने, उनसे पहुंचने, उन्हें हटाने और कोशिकाओं को मर्ज करने के उदाहरण।

## **तालिका जोड़ें**

दो पंक्तियों और दो स्तंभों वाली एक सरल तालिका बनाएं।

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

## **तालिका तक पहुंचें**

स्लाइड पर पहली तालिका शैप प्राप्त करें।

```java
static void accessTable() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // स्लाइड पर पहली तालिका तक पहुंचें।
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

## **तालिका हटाएं**

स्लाइड से एक तालिका हटाएँ।

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

## **तालिका की कोशिकाएँ मर्ज करें**

एक तालिका की सटे हुए कोशिकाओं को एकल कोशिका में मर्ज करें।

```java
static void mergeTableCells() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        double[] widths = new double[] { 80, 80 };
        double[] heights = new double[] { 30, 30 };
        ITable table = slide.getShapes().addTable(50, 50, widths, heights);

        // कोशिकाओं को मिलाएँ.
        table.mergeCells(table.get_Item(0, 0), table.get_Item(1, 1), false);
    } finally {
        presentation.dispose();
    }
}
```