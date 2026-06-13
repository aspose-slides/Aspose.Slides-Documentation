---
title: टेक्स्ट बॉक्स
type: docs
weight: 40
url: /hi/nodejs-java/examples/elements/text-box/
keywords:
- कोड उदाहरण
- टेक्स्टबॉक्स
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js में टेक्स्ट बॉक्स के साथ काम करें: PPT, PPTX और ODP प्रस्तुतियों के लिए JavaScript का उपयोग करके टेक्स्ट को जोड़ें, फ़ॉर्मेट करें, संरेखित करें, रैप करें, ऑटोफ़िट और स्टाइल करें।"
---
Aspose.Slides में, एक **टेक्स्ट बॉक्स** को `AutoShape` द्वारा दर्शाया जाता है। लगभग कोई भी आकार टेक्स्ट रख सकता है, लेकिन एक सामान्य टेक्स्ट बॉक्स में कोई भराव या बॉर्डर नहीं होता और यह केवल टेक्स्ट प्रदर्शित करता है।

यह गाइड बताएगा कि प्रोग्रामेटिक रूप से टेक्स्ट बॉक्स को कैसे जोड़ें, एक्सेस करें और हटाएँ।

## **टेक्स्ट बॉक्स जोड़ें**

एक टेक्स्ट बॉक्स, बस एक `AutoShape` है जिसमें कोई भराव या बॉर्डर नहीं है और कुछ स्वरूपित टेक्स्ट होता है। इसे बनाने का तरीका इस प्रकार है:

```js
function addTextBox() {
    let presentation = new aspose.slides.Presentation();
    try {
        let slide = presentation.getSlides().get_Item(0);

        // आयत आकार बनाएं (डिफ़ॉल्ट रूप से भराव के साथ बॉर्डर और कोई टेक्स्ट नहीं)।
        let textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 75, 150, 100);

        // भराव और बॉर्डर हटाएँ ताकि यह एक सामान्य टेक्स्ट बॉक्स जैसा दिखे।
        let boxFillType = java.newByte(aspose.slides.FillType.NoFill);
        textBox.getFillFormat().setFillType(boxFillType);
        textBox.getLineFormat().getFillFormat().setFillType(boxFillType);

        // टेक्स्ट फ़ॉर्मेटिंग सेट करें।
        let paragraph = textBox.getTextFrame().getParagraphs().get_Item(0);
        let textFormat = paragraph.getParagraphFormat().getDefaultPortionFormat();
        let textFillType = java.newByte(aspose.slides.FillType.Solid);
        let textFillColor = java.getStaticFieldValue("java.awt.Color", "BLACK");
        textFormat.getFillFormat().setFillType(textFillType);
        textFormat.getFillFormat().getSolidFillColor().setColor(textFillColor);

        // वास्तविक टेक्स्ट सामग्री असाइन करें।
        textBox.getTextFrame().setText("Some text...");

        presentation.save("text_box.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **ध्यान दें:** कोई भी `AutoShape` जो non-empty `TextFrame` रखता है, वह टेक्स्ट बॉक्स के रूप में काम कर सकता है।

## **टेक्स्ट बॉक्स तक पहुँचें**

स्लाइड से पहला टेक्स्ट बॉक्स प्राप्त करें।

```js
function accessTextBox() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let firstTextBox = null;
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            // केवल AutoShapes ही संपादन योग्य टेक्स्ट रख सकते हैं।
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                firstTextBox = shape;
            }
        }
    } finally {
        presentation.dispose();
    }
}
```

## **सामग्री के आधार पर टेक्स्ट बॉक्स हटाएँ**

यह उदाहरण पहली स्लाइड पर सभी टेक्स्ट बॉक्स को खोजता और हटाता है जो किसी विशेष कुंजी शब्द को शामिल करते हैं:

```js
function removeTextBoxes() {
    let presentation = new aspose.slides.Presentation("text_box.pptx");
    try {
        let slide = presentation.getSlides().get_Item(0);

        let shapesToRemove = [];
        for (let i = 0; i < slide.getShapes().size(); i++) {
            let shape = slide.getShapes().get_Item(i);
            if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
                let autoShape = shape;
                if (autoShape.getTextFrame().getText().includes("Slide")) {
                    shapesToRemove.push(shape);
                }
            }
        }

        for (let i = 0; i < shapesToRemove.length; i++) {
            slide.getShapes().remove(shapesToRemove[i]);
        }

        presentation.save("text_boxes_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **सलाह:** इटरेशन के दौरान संशोधित करने से पहले हमेशा shape collection की एक कॉपी बनाएँ ताकि collection modification errors से बचा जा सके।