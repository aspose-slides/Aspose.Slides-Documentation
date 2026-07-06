---
title: जावास्क्रिप्ट में प्रस्तुतियों से टेक्स्ट भाग की सीमाएँ प्राप्त करें
linktitle: भाग सीमाएँ
type: docs
weight: 47
url: /hi/nodejs-java/portion-bounds/
keywords:
- टेक्स्ट भाग सीमाएँ
- टेक्स्ट भाग
- टेक्स्ट हिस्सा
- टेक्स्ट निर्देशांक
- टेक्स्ट स्थिति
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "जावा के माध्यम से Node.js के लिए Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतियों में टेक्स्ट भाग की सीमाएँ प्राप्त करना सीखें।"
---
## **अवलोकन**

एक टेक्स्ट भाग पैराग्राफ के भीतर टेक्स्ट के विशिष्ट अंश को दर्शाता है और आपको उस अंश को आसपास की सामग्री से स्वतंत्र रूप से काम करने की अनुमति देता है। Aspose.Slides में, भागों का उपयोग तब किया जाता है जब आपको टेक्स्ट अंश की सीमाएँ प्राप्त करनी हों, केवल पैराग्राफ के किसी हिस्से पर फ़ॉर्मेटिंग लागू करनी हो, या अधिक विस्तृत स्तर पर टेक्स्ट व्यवहार को नियंत्रित करना हो।

यह लेख दिखाता है कि [Portion.getRect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/getrect/) का उपयोग करके भाग का बाउंडिंग आयत कैसे प्राप्त किया जाए। यह यह भी दर्शाता है कि [Portion.getCoordinates](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/getcoordinates/) का उपयोग करके भाग की शुरुआत के निर्देशांक कैसे प्राप्त किए जाएँ। अतिरिक्त रूप से, यह सामान्य भाग‑संबंधी परिदृश्यों को उजागर करता है, जैसे एकल टेक्स्ट अंश पर हाइपरलिंक लागू करना, फ़ॉर्मेटिंग कैसे भाग, पैराग्राफ, टेक्स्ट फ्रेम और थीम वारिस स्थिति के माध्यम से हल होती है, तथा जब निर्दिष्ट फ़ॉन्ट उपलब्ध न हो तो कैसे संभालें।

## **टेक्स्ट भाग की सीमाओं को प्राप्त करें**

[Portion.getRect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/getrect/) का उपयोग करके टेक्स्ट भाग का बाउंडिंग आयत प्राप्त करें:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const rectangle = portion.getRect();
            console.log("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **टेक्स्ट भाग के निर्देशांक प्राप्त करें**

[Portion.getCoordinates](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/getcoordinates/) का उपयोग करके टेक्स्ट भाग की शुरुआत के निर्देशांक प्राप्त करें:

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const point = portion.getCoordinates();
            console.log("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही पैराग्राफ में केवल टेक्स्ट के एक भाग पर हाइपरलिंक लागू कर सकता हूँ?**

हाँ, आप [हाइपरलिंक असाइन करें](/slides/hi/nodejs-java/manage-hyperlinks/) को एक व्यक्तिगत भाग पर लागू कर सकते हैं; केवल वही अंश क्लिक करने योग्य होगा, पूरी पैराग्राफ नहीं।

**स्टाइल इनहेरिटेंस कैसे काम करता है: एक भाग क्या ओवरराइड करता है, और क्या पैराग्राफ या टेक्स्ट फ्रेम से लिया जाता है?**

भाग‑स्तर की प्रॉपर्टीज़ का सर्वोच्च प्राथमिकता है। यदि कोई प्रॉपर्टी [Portion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/) पर सेट नहीं है, तो Aspose.Slides इसे [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) से लेता है। यदि वहाँ भी सेट नहीं है, तो Aspose.Slides [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) या [theme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/theme/) स्टाइल से उपयोग करता है।

**यदि भाग के लिए निर्दिष्ट फ़ॉन्ट लक्ष्य मशीन या सर्वर पर उपलब्ध नहीं है तो क्या होता है?**

[फ़ॉन्ट प्रतिस्थापन नियम](/slides/hi/nodejs-java/font-selection-sequence/) लागू होते हैं। टेक्स्ट रीफ़्लो हो सकता है: मेट्रिक्स, हाइफ़नेशन और चौड़ाई बदल सकती है, जो सटीक पोजिशनिंग के लिए महत्वपूर्ण है।

**क्या मैं भाग‑विशिष्ट टेक्स्ट फ़िल ट्रांसपेरेंसी या ग्रेडिएंट को पैराग्राफ की बाकी सामग्री से स्वतंत्र रूप से सेट कर सकता हूँ?**

हाँ, टेक्स्ट का रंग, फ़िल और ट्रांसपेरेंसी [Portion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/) स्तर पर पड़ोसी भागों से अलग हो सकते हैं।