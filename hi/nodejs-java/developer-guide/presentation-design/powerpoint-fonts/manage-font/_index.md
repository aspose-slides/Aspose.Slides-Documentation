---
title: JavaScript का उपयोग करके प्रस्तुतियों में फ़ॉन्ट प्रबंधित करें
linktitle: फ़ॉन्ट प्रबंधित करें
type: docs
weight: 10
url: /hi/nodejs-java/manage-fonts/
keywords:
- फ़ॉन्ट प्रबंधित करें
- फ़ॉन्ट गुण
- पैराग्राफ
- टेक्स्ट फॉर्मेटिंग
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ फ़ॉन्ट नियंत्रित करें: कस्टम फ़ॉन्ट एम्बेड करें, बदलें, और लोड करें ताकि PPT, PPTX और ODP प्रस्तुतियाँ स्पष्ट और सुसंगत रहें."
---
## **परिचय**

प्रस्तुतियों में आमतौर पर टेक्स्ट और छवियों दोनों का समावेश होता है। टेक्स्ट को विभिन्न तरीकों से फॉर्मेट किया जा सकता है, चाहे वह विशेष अनुभागों और शब्दों को उजागर करने के लिए हो या कॉरपोरेट स्टाइल के अनुरूप बनाने के लिए। टेक्स्ट फ़ॉर्मेटिंग उपयोगकर्ताओं को प्रस्तुतियों की सामग्री के लुक और फील को बदलने में मदद करती है। यह लेख दर्शाता है कि Aspose.Slides for Node.js via Java का उपयोग करके स्लाइड्स पर टेक्स्ट पैराग्राफ की फ़ॉन्ट प्रॉपर्टीज़ कैसे कॉन्फ़िगर करें।

## **फ़ॉन्ट से संबंधित प्रॉपर्टीज़ प्रबंधित करें**

1. [प्रस्तुति](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) वर्ग का एक उदाहरण बनाएं।
1. स्लाइड का संदर्भ उसके अनुक्रमांक का उपयोग करके प्राप्त करें।
1. स्लाइड में [Placeholder](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/placeholder/) आकारों तक पहुंचें और उन्हें [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) में टाइपकास्ट करें।
1. [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) द्वारा प्रदर्शित [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) से [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) प्राप्त करें।
1. पैराग्राफ को जस्टिफाई करें।
1. [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) के टेक्स्ट [Portion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/) तक पहुंचें।
1. [FontData](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontdata/) का उपयोग करके फ़ॉन्ट निर्धारित करें और टेक्स्ट [Portion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/) का **फ़ॉन्ट** उसी अनुसार सेट करें।
   1. फ़ॉन्ट को बोल्ड सेट करें।
   2. फ़ॉन्ट को इटैलिक सेट करें।
1. [Portion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/) ऑब्जेक्ट द्वारा प्रदर्शित [FillFormat](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fillformat/) का उपयोग करके फ़ॉन्ट रंग सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में सहेजें।

उपरोक्त चरणों का कार्यान्वयन नीचे दिया गया है। यह एक साधारण प्रस्तुति लेता है और एक स्लाइड पर फ़ॉन्ट को फ़ॉर्मेट करता है। नीचे दिए गए स्क्रीनशॉट इनपुट फ़ाइल और कोड स्निपेट्स द्वारा किए गए परिवर्तन को दर्शाते हैं। कोड फ़ॉन्ट, रंग और फ़ॉन्ट शैली को बदलता है।

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figure: इनपुट फ़ाइल में टेक्स्ट**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figure: एक ही टेक्स्ट के अपडेटेड फ़ॉर्मेटिंग के साथ**|

```javascript
// एक Presentation ऑब्जेक्ट बनाएं जो PPTX फ़ाइल का प्रतिनिधित्व करता है
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // स्लाइड को उसकी स्थिति का उपयोग करके एक्सेस करना
    var slide = pres.getSlides().get_Item(0);
    // स्लाइड में पहला और दूसरा प्लेसहोल्डर एक्सेस करना और इसे AutoShape में टाइपकास्ट करना
    var tf1 = slide.getShapes().get_Item(0).getTextFrame();
    var tf2 = slide.getShapes().get_Item(1).getTextFrame();
    // पहला पैराग्राफ एक्सेस करना
    var para1 = tf1.getParagraphs().get_Item(0);
    var para2 = tf2.getParagraphs().get_Item(0);
    // पैराग्राफ को जस्टिफाई करें
    para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.JustifyLow);
    // पहला पोर्शन एक्सेस करना
    var port1 = para1.getPortions().get_Item(0);
    var port2 = para2.getPortions().get_Item(0);
    // नए फ़ॉन्ट परिभाषित करें
    var fd1 = new aspose.slides.FontData("Elephant");
    var fd2 = new aspose.slides.FontData("Castellar");
    // नए फ़ॉन्ट को पोर्शन को असाइन करें
    port1.getPortionFormat().setLatinFont(fd1);
    port2.getPortionFormat().setLatinFont(fd2);
    // फ़ॉन्ट को बोल्ड सेट करें
    port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // फ़ॉन्ट को इटैलिक सेट करें
    port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // फ़ॉन्ट का रंग सेट करें
    port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
    // PPTX को डिस्क पर सहेजें
    pres.save("WelcomeFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **टेक्स्ट फ़ॉन्ट प्रॉपर्टीज़ सेट करें**
{{% alert color="primary" %}} 

जैसा कि **फ़ॉन्ट से संबंधित प्रॉपर्टीज़ प्रबंधित करें** में उल्लेख किया गया है, एक [Portion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/) पैराग्राफ में समान फ़ॉर्मेटिंग शैली वाले टेक्स्ट को रखने के लिए उपयोग किया जाता है। यह लेख दिखाता है कि Aspose.Slides for Node.js via Java का उपयोग करके कुछ टेक्स्ट के साथ एक टेक्स्टबॉक्स कैसे बनायें और फिर किसी विशिष्ट फ़ॉन्ट तथा फ़ॉन्ट फ़ैमिली कैटेगरी की विभिन्न अन्य प्रॉपर्टीज़ को कैसे परिभाषित करें। 
{{% /alert %}} 

एक टेक्स्टबॉक्स बनाने और उसमें टेक्स्ट की फ़ॉन्ट प्रॉपर्टीज़ सेट करने के लिए:

1. [प्रस्तुति](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) वर्ग का एक उदाहरण बनाएं।
1. स्लाइड का संदर्भ उसके अनुक्रमांक का उपयोग करके प्राप्त करें।
1. स्लाइड में प्रकार **Rectangle** का एक [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) जोड़ें।
1. [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) से जुड़ी फ़िल स्टाइल को हटाएं।
1. [AutoShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/autoshape/) के [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) तक पहुंचें।
1. [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) में कुछ टेक्स्ट जोड़ें।
1. [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) से जुड़ी [Portion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/) ऑब्जेक्ट तक पहुंचें।
1. [Portion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/) के लिए उपयोग किया जाने वाला फ़ॉन्ट निर्धारित करें।
1. [Portion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/portion/) ऑब्जेक्ट द्वारा प्रदान किए गए संबंधित प्रॉपर्टीज़ का उपयोग करके बोल्ड, इटैलिक, अंडरलाइन, रंग और ऊँचाई जैसी अन्य फ़ॉन्ट प्रॉपर्टीज़ सेट करें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

उपरोक्त चरणों का कार्यान्वयन नीचे दिया गया है।

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figure: Aspose.Slides for Node.js via Java द्वारा सेट किए गए कुछ फ़ॉन्ट प्रॉपर्टीज़ के साथ टेक्स्ट**|

```javascript
// एक Presentation ऑब्जेक्ट बनाएं जो PPTX फ़ाइल का प्रतिनिधित्व करता है
var pres = new aspose.slides.Presentation();
try {
    // पहली स्लाइड प्राप्त करें
    var sld = pres.getSlides().get_Item(0);
    // Rectangle प्रकार का AutoShape जोड़ें
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // AutoShape से जुड़ी किसी भी फ़िल स्टाइल को हटाएँ
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // AutoShape से जुड़े TextFrame को एक्सेस करें
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // TextFrame से जुड़े Portion को एक्सेस करें
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // Portion के लिए फ़ॉन्ट सेट करें
    port.getPortionFormat().setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // फ़ॉन्ट की बोल्ड प्रॉपर्टी सेट करें
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // फ़ॉन्ट की इटैलिक प्रॉपर्टी सेट करें
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // फ़ॉन्ट की अंडरलाइन प्रॉपर्टी सेट करें
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // फ़ॉन्ट की ऊँचाई सेट करें
    port.getPortionFormat().setFontHeight(25);
    // फ़ॉन्ट का रंग सेट करें
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // प्रस्तुति को डिस्क पर सहेजें
    pres.save("pptxFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```