---
title: हाइपरलिंक
type: docs
weight: 130
url: /hi/nodejs-java/examples/elements/hyperlink/
keywords:
- कोड उदाहरण
- हाइपरलिंक
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js में हाइपरलिंक जोड़ें और प्रबंधित करें: टेक्स्ट, आकार और छवियों को लिंक करें, PPT, PPTX और ODP के लिए टार्गेट और क्रियाएँ निर्धारित करें, उदाहरणों के साथ।"
---
यह लेख **Aspose.Slides for Node.js via Java** का उपयोग करके आकारों पर हाइपरलिंक जोड़ने, पहुँचने, हटाने और अपडेट करने का प्रदर्शन करता है।

## **हाइपरलिंक जोड़ें**

एक आयताकार आकार बनाएं जिसमें बाहरी वेबसाइट की ओर इशारा करने वाला हाइपरलिंक हो।

```js
function addHyperlink() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 150, 50);
        shape.getTextFrame().setText("Aspose");

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = new aspose.slides.Hyperlink("https://www.aspose.com");
        textPortion.getPortionFormat().setHyperlinkClick(hyperlink);

        presentation.save("hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **हाइपरलिंक तक पहुंचें**

एक आकार के टेक्स्ट हिस्से से हाइपरलिंक पढ़ें।

```js
function accessHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // यह मानते हुए कि पहला आकार हाइपरलिंक वाले टेक्स्ट को शामिल करता है।
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        let hyperlink = textPortion.getPortionFormat().getHyperlinkClick();
    } finally {
        presentation.dispose();
    }
}
```

## **हाइपरलिंक हटाएँ**

एक आकार के टेक्स्ट से हाइपरलिंक साफ़ करें।

```js
function removeHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // मान लेते हैं कि पहला आकार हाइपरलिंक वाले टेक्स्ट को शामिल करता है।
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        textPortion.getPortionFormat().setHyperlinkClick(null);

        presentation.save("hyperlink_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **हाइपरलिंक अपडेट करें**

मौजूदा हाइपरलिंक का लक्ष्य बदलें। `HyperlinkManager` का उपयोग करके उस टेक्स्ट को संशोधित करें जिसमें पहले से हाइपरलिंक मौजूद है, जिससे PowerPoint हाइपरलिंक को सुरक्षित रूप से अपडेट करता है, वही प्रक्रिया दोहराई जाती है।

```js
function updateHyperlink() {
    let presentation = new aspose.slides.Presentation("hyperlink.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        // मान लेते हैं कि पहला आकार हाइपरलिंक वाले टेक्स्ट को शामिल करता है।
        let shape = slide.getShapes().get_Item(0);

        let paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
        let textPortion = paragraph.getPortions().get_Item(0);

        // मौजूदा टेक्स्ट में हाइपरलिंक बदलने के लिए HyperlinkManager का उपयोग किया जाना चाहिए
        // HyperlinkManager के द्वारा, सीधे प्रॉपर्टी सेट करने के बजाय।
        // यह PowerPoint के सुरक्षित रूप से हाइपरलिंक अपडेट करने के तरीके की नकल करता है।
        textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://new.example.com");

        presentation.save("hyperlink_updated.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```