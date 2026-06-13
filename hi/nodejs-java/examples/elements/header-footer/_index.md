---
title: हेडर फुटर
type: docs
weight: 220
url: /hi/nodejs-java/examples/elements/header-footer/
keywords:
- कोड उदाहरण
- हेडर
- फुटर
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के साथ स्लाइड हेडर और फुटर नियंत्रित करें: PPT, PPTX, और ODP में तिथियां, स्लाइड नंबर, और कस्टम टेक्स्ट जोड़ें जावास्क्रिप्ट उदाहरणों के साथ।"
---
यह लेख दिखाता है कि **Aspose.Slides for Node.js via Java** का उपयोग करके फुटर जोड़ें और तिथि व समय के प्लेसहॉल्डर को अपडेट करें।

## **फुटर जोड़ें**

स्लाइड के फुटर क्षेत्र में पाठ जोड़ें और उसे दृश्यमान बनाएं।

```js
function addHeaderFooter() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setFooterText("My footer");
        slide.getHeaderFooterManager().setFooterVisibility(true);

        presentation.save("header_footer.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **तारीख और समय अपडेट करें**

स्लाइड पर तिथि और समय के प्लेसहॉल्डर को संशोधित करें।

```js
function updateDateTime() {
    let presentation = new aspose.slides.Presentation("header_footer.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        slide.getHeaderFooterManager().setDateTimeText("01/01/2024");
        slide.getHeaderFooterManager().setDateTimeVisibility(true);

        presentation.save("header_footer_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```