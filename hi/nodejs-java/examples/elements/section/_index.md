---
title: सेक्शन
type: docs
weight: 90
url: /hi/nodejs-java/examples/elements/section/
keywords:
- कोड उदाहरण
- सेक्शन
- पॉवरपॉइंट
- ओपनडॉक्युमेंट
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java में स्लाइड सेक्शनों का प्रबंधन: JavaScript उदाहरणों के साथ PPT, PPTX और ODP के लिए स्लाइड बनाना, नाम बदलना, पुनर्व्यवस्थित करना और समूह बनाना।"
---
प्रेजेंटेशन सेक्शनों का प्रबंधन करने के उदाहरण—प्रोग्रामेटिक रूप से जोड़ना, एक्सेस करना, हटाना और उनका नाम बदलना **Aspose.Slides for Node.js via Java** का उपयोग करके।

## **सेक्शन जोड़ें**

```js
function addSection() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // सेक्शन की शुरुआत को चिह्नित करने वाली स्लाइड निर्दिष्ट करें।
        presentation.getSections().addSection("New Section", slide);

        presentation.save("section.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **सेक्शन तक पहुँचें**

```js
function accessSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // इंडेक्स द्वारा सेक्शन तक पहुँचें।
        let section = presentation.getSections().get_Item(0);
        let sectionName = section.getName();
    } finally {
        presentation.dispose();
    }
}
```

## **सेक्शन हटाएँ**

```js
function removeSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // पहला सेक्शन हटाएँ।
        let section = presentation.getSections().get_Item(0);
        presentation.getSections().removeSection(section);

        presentation.save("section_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **सेक्शन का नाम बदलें**

```js
function renameSection() {
    let presentation = new aspose.slides.Presentation("section.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let section = presentation.getSections().get_Item(0);
        section.setName("New Name");

        presentation.save("section_renamed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```