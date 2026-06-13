---
title: चार्ट
type: docs
weight: 60
url: /hi/nodejs-java/examples/elements/chart/
keywords:
- कोड उदाहरण
- चार्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ चार्ट में महारत हासिल करें: चार्ट बनाएं, स्वरूपित करें, डेटा बाइंड करें, और PPT, PPTX, और ODP में चार्ट निर्यात करें, JavaScript उदाहरणों के साथ."
---
विभिन्न चार्ट प्रकारों को जोड़ने, पहुँचने, हटाने और अपडेट करने के उदाहरण **Aspose.Slides for Node.js via Java** के साथ। नीचे दिए गए स्निपेट्स बुनियादी चार्ट संचालन को दर्शाते हैं।

## **चार्ट जोड़ें**

यह विधि पहली स्लाइड पर एक सरल एरिया चार्ट जोड़ती है।

```js
function addChart() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // पहली स्लाइड पर एक सरल एरिया चार्ट जोड़ें।
        let chart = slide.getShapes().addChart(aspose.slides.ChartType.Area, 50, 50, 400, 300);

        presentation.save("chart.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **चार्ट तक पहुँचें**

चार्ट बनाने के बाद, आप इसे शेप कलेक्शन के माध्यम से प्राप्त कर सकते हैं।

```js
function accessChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // स्लाइड पर पहला चार्ट एक्सेस करें।
        let firstChart = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
                firstChart = shape;
                break;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **चार्ट हटाएँ**

निम्नलिखित कोड स्लाइड से चार्ट को हटाता है।

```js
function removeChart() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // चार्ट हटाएँ।
        slide.getShapes().removeAt(0);

        presentation.save("chart_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **चार्ट डेटा अपडेट करें**

आप चार्ट की विशेषताओं को, जैसे शीर्षक, बदल सकते हैं।

```js
function updateChartData() {
    let presentation = new aspose.slides.Presentation("chart.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);
        let chart = slide.getShapes().get_Item(0);

        // चार्ट शीर्षक बदलें।
        chart.getChartTitle().addTextFrameForOverriding("Sales Report");

        presentation.save("chart_title.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```