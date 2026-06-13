---
title: जावास्क्रिप्ट में प्रस्तुतियों से पैराग्राफ सीमाएँ प्राप्त करें
linktitle: पैराग्राफ
type: docs
weight: 60
url: /hi/nodejs-java/paragraph/
keywords:
- पैराग्राफ सीमाएं
- टेक्स्ट भाग सीमाएं
- पैराग्राफ निर्देशांक
- भाग निर्देशांक
- पैराग्राफ आकार
- टेक्स्ट भाग आकार
- टेक्स्ट फ्रेम
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के साथ जावास्क्रिप्ट में पैराग्राफ और टेक्स्ट-भाग सीमाओं को पुनः प्राप्त करना सीखें ताकि PowerPoint प्रस्तुतियों में टेक्स्ट पोजिशनिंग को अनुकूलित किया जा सके।"
---
## **परिचय**

यह लेख Aspose.Slides में पैराग्राफ और टेक्स्ट भागों की सीमाएँ, आकार और निर्देशांक कैसे प्राप्त करें, इस पर समझाता है। यह `getRect()` का उपयोग करके `TextFrame` में पैराग्राफ का आयत प्राप्त करने, तालिका सेल टेक्स्ट फ्रेम के भीतर पैराग्राफ और भाग के निर्देशांक प्राप्त करने, तथा मापन इकाइयाँ, टेक्स्ट रैपिंग का सीमाओं पर प्रभाव, पिक्सेल रूपांतरण और प्रभावी पैराग्राफ फ़ॉर्मेटिंग मानों जैसे महत्वपूर्ण विवरणों को उजागर करता है।

## **TextFrame में पैराग्राफ और भाग के निर्देशांक प्राप्त करें**
Aspose.Slides for Node.js via Java का उपयोग करके डेवलपर अब TextFrame के पैराग्राफ संग्रह में पैराग्राफ के आयताकार निर्देशांक प्राप्त कर सकते हैं। यह आपको पैराग्राफ के भाग संग्रह के भीतर [the coordinates of portion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Portion#getCoordinates--) प्राप्त करने की अनुमति भी देता है। इस विषय में हम एक उदाहरण की मदद से दिखाएंगे कि पैराग्राफ के आयताकार निर्देशांक और उसके भीतर भाग की स्थिति कैसे प्राप्त की जा सकती है।

```javascript
var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
var textFrame = shape.getTextFrame();
for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
    const paragraph = textFrame.getParagraphs().get_Item(i);
    for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
        const portion = paragraph.getPortions().get_Item(j);
        var point = portion.getCoordinates();
    }
}
```

## **पैराग्राफ के आयताकार निर्देशांक प्राप्त करें**
[**getRect()**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Paragraph#getRect--) मेथड का उपयोग करके डेवलपर पैराग्राफ की सीमा आयत प्राप्त कर सकते हैं।

```javascript
var pres = new aspose.slides.Presentation("HelloWorld.pptx");
try {
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    var rect = textFrame.getParagraphs().get_Item(0).getRect();
    console.log("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **टेबल सेल टेक्स्ट फ्रेम के भीतर पैराग्राफ और भाग का आकार प्राप्त करें**
एक तालिका सेल टेक्स्ट फ्रेम में [Portion](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Portion) या [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Paragraph) का आकार और निर्देशांक प्राप्त करने के लिए आप [Portion.getRect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Portion#getRect--) और [Paragraph.getRect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Paragraph#getRect--) मेथड का उपयोग कर सकते हैं।

यह नमूना कोड वर्णित संचालन को प्रदर्शित करता है:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var tbl = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var cell = tbl.getRows().get_Item(1).get_Item(1);
    var x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    var y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();
    
    for (let i = 0; i < cell.getTextFrame().getParagraphs().getCount(); i++) {
        const para = cell.getTextFrame().getParagraphs().get_Item(i);
        if (para.getText() === "") {
            continue;
        }
        var rect = para.getRect();
        var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
        shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        shape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        for (let j = 0; j < para.getPortions().getCount(); j++) {
            const portion = para.getPortions().get_Item(j);
            if (portion.getText().includes("0")) {
                rect = portion.getRect();
                shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, java.newFloat(rect.getX() + x), java.newFloat(rect.getY() + y), java.newFloat(rect.getWidth()), java.newFloat(rect.getHeight()));
                shape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
            }
        }
    }
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**पैराग्राफ और टेक्स्ट भागों के लिए लौटाए गए निर्देशांक किस इकाइयों में मापे जाते हैं?**  
पॉइंट्स में, जहाँ 1 इंच = 72 पॉइंट्स। यह स्लाइड पर सभी निर्देशांक और परिमाणों पर लागू होता है।

**क्या शब्द रैपिंग पैराग्राफ की सीमाओं को प्रभावित करती है?**  
हां। यदि [wrapping](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/setwraptext/) [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) में सक्रिय है, तो टेक्स्ट क्षेत्र की चौड़ाई के अनुसार टूटता है, जिससे पैराग्राफ की वास्तविक सीमाएँ बदल जाती हैं।

**क्या पैराग्राफ के निर्देशांक को निर्यात की गई छवि में पिक्सेल में भरोसेमंद रूप से मैप किया जा सकता है?**  
हां। पॉइंट्स को पिक्सेल में बदलने के लिए उपयोग करें: pixels = points × (DPI / 72)। परिणाम रेंडरिंग/निर्यात के लिए चुनी गई DPI पर निर्भर करता है।

**स्टाइल विरासत को ध्यान में रखते हुए "प्रभावी" पैराग्राफ फ़ॉर्मेटिंग पैरामीटर कैसे प्राप्त करें?**  
[effective paragraph formatting data structure](/slides/hi/nodejs-java/shape-effective-properties/) का उपयोग करें; यह इंडेंट, स्पेसिंग, रैपिंग, RTL एवं अन्य के लिए अंतिम सम्मिलित मान लौटाता है।