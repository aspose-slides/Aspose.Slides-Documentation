---
title: जावास्क्रिप्ट का उपयोग करके प्रस्तुतियों में टेक्स्ट पोर्शन प्रबंधित करें
linktitle: टेक्स्ट पोर्शन
type: docs
weight: 70
url: /hi/nodejs-java/portion/
keywords:
- टेक्स्ट पोर्शन
- टेक्स्ट भाग
- टेक्स्ट निर्देशांक
- टेक्स्ट स्थिति
- पावरपॉइंट
- प्रेज़ेंटेशन
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "जावास्क्रिप्ट और Aspose.Slides for Node.js के माध्यम से जावा के उपयोग से पावरपॉइंट प्रस्तुतियों में टेक्स्ट पोर्शन को प्रबंधित करना सीखें, जिससे प्रदर्शन और अनुकूलन बढ़े।"
---
## **परिचय**

एक टेक्स्ट पोर्शन पैराग्राफ के भीतर एक विशिष्ट टेक्स्ट अंश को दर्शाता है और आपको उस अंश को आसपास की सामग्री से स्वतंत्र रूप से काम करने की अनुमति देता है। Aspose.Slides में, पोर्शन का उपयोग तब किया जा सकता है जब आपको टेक्स्ट अंश की स्थिति प्राप्त करनी हो, केवल पैराग्राफ के किसी हिस्से पर फॉर्मेटिंग लागू करनी हो, या अधिक विस्तृत स्तर पर टेक्स्ट व्यवहार को नियंत्रित करना हो।

यह लेख `getCoordinates()` मेथड का उपयोग करके पोर्शन की शुरुआत के निर्देशांक प्राप्त करने का तरीका दर्शाता है। यह सामान्य पोर्शन-संबंधी परिदृश्यों को भी उजागर करता है, जैसे एकल टेक्स्ट अंश पर हाइपरलिंक लागू करना, यह समझना कि फॉर्मेटिंग पोर्शन, पैराग्राफ, टेक्स्ट फ्रेम और थीम विरासत के माध्यम से कैसे समाधान होती है, और जब निर्दिष्ट फ़ॉन्ट उपलब्ध न हो तो उसके केस को संभालना। इसके अतिरिक्त, यह उल्लेख करता है कि समान पैराग्राफ के भीतर व्यक्तिगत पोर्शन के लिए टेक्स्ट फिल, रंग और ट्रांसपैरेंसी को अलग-अलग सेट किया जा सकता है।

## **पोर्शन के स्थिति निर्देशांक प्राप्त करें**
[**getCoordinates()**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Portion#getCoordinates--) मेथड को [Portion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/) क्लास में जोड़ा गया है जो पोर्शन की शुरुआत के निर्देशांक प्राप्त करने की अनुमति देता है।

```javascript
// PPTX का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंटिएट करें
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // प्रस्तुति के संदर्भ को पुनः आकार देना
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const paragraph = textFrame.getParagraphs().get_Item(i);
        for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
            const portion = paragraph.getPortions().get_Item(j);
            var point = portion.getCoordinates();
            console.log("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं एक ही पैराग्राफ के भीतर केवल टेक्स्ट के भाग पर हाइपरलिंक लागू कर सकता हूँ?**

हां, आप [हाइपरलिंक असाइन कर सकते हैं](/slides/hi/nodejs-java/manage-hyperlinks/) एक व्यक्तिगत पोर्शन को; केवल वही अंश क्लिक करने योग्य होगा, न कि पूरा पैराग्राफ।

**स्टाइल इनहेरिटेंस कैसे काम करता है: पोर्शन क्या ओवरराइड करता है, और पैराग्राफ/टेक्स्टफ़्रेम से क्या लेता है?**

पोर्शन-स्तर के प्रॉपर्टी को सबसे अधिक प्राथमिकता मिलती है। यदि कोई प्रॉपर्टी [Portion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/) पर सेट नहीं है, तो इंजन इसे [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) से लेता है; यदि वह भी सेट नहीं है, तो इसे [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) या [theme](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/theme/) स्टाइल से लिया जाता है।

**यदि पोर्शन के लिए निर्दिष्ट फ़ॉन्ट लक्ष्य मशीन/सर्वर पर उपलब्ध नहीं है तो क्या होता है?**

[फ़ॉन्ट प्रतिस्थापन नियम](/slides/hi/nodejs-java/font-selection-sequence/) लागू होते हैं। टेक्स्ट पुनः प्रवाहित हो सकता है: मीट्रिक्स, हाइफ़नेशन और चौड़ाई बदल सकती है, जो सटीक पोजिशनिंग के लिए महत्वपूर्ण है।

**क्या मैं पोर्शन-विशिष्ट टेक्स्ट फ़िल ट्रांसपैरेंसी या ग्रेडिएंट को पैराग्राफ के बाकी हिस्सों से स्वतंत्र रूप से सेट कर सकता हूं?**

हां, टेक्स्ट का रंग, फ़िल और ट्रांसपैरेंसी [Portion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/) स्तर पर पड़ोसी अंशों से अलग हो सकते हैं।