---
title: चार्ट
type: docs
weight: 60
url: /hi/java/examples/elements/chart/
keywords:
- कोड उदाहरण
- चार्ट
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ चार्ट में माहिर बनें: चार्ट बनाएं, स्वरूपित करें, डेटा बाइंड करें, और Java उदाहरणों के साथ PPT, PPTX, और ODP में चार्ट निर्यात करें।"
---
Aspose.Slides for Java के साथ विभिन्न चार्ट प्रकार को जोड़ने, एक्सेस करने, हटाने और अपडेट करने के उदाहरण। नीचे दिए गए स्निपेट्स बुनियादी चार्ट संचालन दर्शाते हैं।

## **चार्ट जोड़ें**

यह मेथड पहले स्लाइड में एक सरल एरिया चार्ट जोड़ता है।

```java
static void addChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        // पहली स्लाइड में एक सरल एरिया चार्ट जोड़ें।
        IChart chart = slide.getShapes().addChart(ChartType.Area, 50, 50, 400, 300);
    } finally {
        presentation.dispose();
    }
}
```

## **चार्ट तक पहुँचें**

एक चार्ट बनाने के बाद, आप इसे shape collection के माध्यम से प्राप्त कर सकते हैं।

```java
static void accessChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Line, 50, 50, 400, 300);

        // स्लाइड पर पहला चार्ट एक्सेस करें।
        IChart firstChart = null;
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof IChart) {
                firstChart = (IChart) shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **चार्ट हटाएँ**

निम्नलिखित कोड स्लाइड से एक चार्ट को हटाता है।

```java
static void removeChart() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Pie, 50, 50, 400, 300);

        // चार्ट को हटाएँ।
        slide.getShapes().remove(chart);
    } finally {
        presentation.dispose();
    }
}
```

## **चार्ट डेटा अपडेट करें**

आप चार्ट के गुणों को, जैसे शीर्षक, बदल सकते हैं।

```java
static void updateChartData() {
    Presentation presentation = new Presentation();
    try {
        ISlide slide = presentation.getSlides().get_Item(0);

        IChart chart = slide.getShapes().addChart(ChartType.Column3D, 50, 50, 400, 300);

        // चार्ट शीर्षक बदलें।
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");
    } finally {
        presentation.dispose();
    }
}
```