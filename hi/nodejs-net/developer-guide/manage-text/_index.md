---
title: Node.js के माध्यम से .NET में प्रस्तुति पाठ प्रबंधित करें
linktitle: पाठ प्रबंधित करें
type: docs
weight: 50
url: /hi/nodejs-net/manage-text/
keywords:
- पाठ
- टेक्स्ट बॉक्स
- पाठ जोड़ें
- पाठ बदलें
- पाठ को स्वरूपित करें
- फ़ॉन्ट आकार
- बोल्ड पाठ
- टेक्स्ट फ्रेम
- पैराग्राफ
- भाग
- PowerPoint
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via .NET के साथ जावास्क्रिप्ट में एक स्लाइड पर टेक्स्ट बॉक्स जोड़ें, फिर उसके पाठ, फ़ॉन्ट आकार और बोल्ड शैली को बदलें।"
---
## **समीक्षा**

Aspose.Slides में, स्लाइड पर पाठ एक shape से संबंधित होता है। एक ऑटो शैप, जैसे कि आयत, में एक टेक्स्ट फ्रेम होता है; टेक्स्ट फ्रेम में पैराग्राफ होते हैं, और प्रत्येक पैराग्राफ में portions होते हैं, जो समान स्वरूपण वाले पाठ के भाग होते हैं। आप टेक्स्ट को टेक्स्ट फ्रेम के माध्यम से और फ़ॉन्ट को भाग के format के माध्यम से बदलते हैं।

यह लेख स्लाइड में एक टेक्स्ट बॉक्स जोड़ता है और प्रस्तुति को सहेजता है। फिर यह सहेजे गए फ़ाइल को खोलता है और टेक्स्ट बॉक्स के पाठ, फ़ॉन्ट आकार और बोल्ड शैली को बदलता है।

उदाहरणों को एक प्रोजेक्ट की आवश्यकता होती है जिसे [स्थापना](/slides/hi/nodejs-net/installation/) में वर्णित के अनुसार सेट किया गया हो। प्रत्येक उदाहरण को प्रोजेक्ट फ़ोल्डर में एक `.js` फ़ाइल के रूप में सहेजें और उसे उस फ़ोल्डर से `node` के साथ चलाएँ।

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET का अपना कोई API रेफ़रेंस नहीं है। यह Aspose.Slides for .NET API को camelCase नामों के साथ प्रतिबिंबित करता है, इसलिए इस लेख में API लिंक [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/hi/net/) में मिलते‑जुलते क्लास और सदस्य की ओर ले जाते हैं।
{{% /alert %}}

## **टेक्स्ट बॉक्स जोड़ें**

टेक्स्ट बॉक्स जोड़ने के लिए, स्लाइड में एक ऑटो शैप को [addAutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/shapecollection/addautoshape/) मेथड से जोड़ें और उसे [addTextFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/autoshape/addtextframe/) मेथड से टेक्स्ट दें। निम्नलिखित उदाहरण नए प्रस्तुति की पहली स्लाइड में एक आयत जोड़ता है और प्रस्तुति को `text-box.pptx` के रूप में सहेजता है:

```javascript
const { Presentation, ShapeType, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation();
try {
    const slide = presentation.slides.get(0);

    // स्थिति (x, y) और आकार (चौड़ाई, ऊँचाई) पॉइंट में हैं।
    const textBox = slide.shapes.addAutoShape(ShapeType.Rectangle, 100, 100, 500, 80);
    textBox.addTextFrame("Quarterly report");

    presentation.save("text-box.pptx", SaveFormat.Pptx);
    console.log("Saved text-box.pptx");
} finally {
    presentation.dispose();
}
```

`text-box.pptx` में स्लाइड में एक आयत है, जिसकी चौड़ाई 500 पॉइंट और ऊँचाई 80 पॉइंट है, जिसमें डिफ़ॉल्ट फ़ॉन्ट और आकार में "Quarterly report" टेक्स्ट है। अगला उदाहरण इस टेक्स्ट बॉक्स को बदलता है।

## **टेक्स्ट और उसके स्वरूपण को बदलें**

निम्नलिखित उदाहरण `text-box.pptx` खोलता है, जिसे पिछले उदाहरण ने बनाया था, और पहली स्लाइड पर पहला shape प्राप्त करता है। चित्र और तालिका जैसे shape में कोई टेक्स्ट फ्रेम नहीं होता, इसलिए उदाहरण यह जांचता है कि shape एक [AutoShape](https://reference.aspose.com/slides/hi/net/aspose.slides/autoshape/) है या नहीं, इससे पहले कि वह shape के [textFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/autoshape/textframe/) का उपयोग करे। फिर यह निम्नलिखित करता है:

1. यह टेक्स्ट फ्रेम की [text](https://reference.aspose.com/slides/hi/net/aspose.slides/textframe/text/) प्रॉपर्टी के माध्यम से टेक्स्ट को बदलता है। इसके बाद, टेक्स्ट फ्रेम में एक पैराग्राफ और उसमें एक पोर्शन होता है।
2. यह उस पोर्शन को [paragraphs](https://reference.aspose.com/slides/hi/net/aspose.slides/textframe/paragraphs/) और [portions](https://reference.aspose.com/slides/hi/net/aspose.slides/paragraph/portions/) कलेक्शन से प्राप्त करता है और उसका [portionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/portion/portionformat/) पढ़ता है।
3. यह [fontHeight](https://reference.aspose.com/slides/hi/net/aspose.slides/baseportionformat/fontheight/), फ़ॉन्ट आकार को पॉइंट में सेट करता है, और [fontBold](https://reference.aspose.com/slides/hi/net/aspose.slides/baseportionformat/fontbold/), जो कि एक [NullableBool](https://reference.aspose.com/slides/hi/net/aspose.slides/nullablebool/) मान लेता है, को सेट करता है।

```javascript
const { Presentation, AutoShape, NullableBool, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("text-box.pptx");
try {
    const shape = presentation.slides.get(0).shapes.get(0);
    if (shape instanceof AutoShape) {
        const textFrame = shape.textFrame;
        textFrame.text = "Quarterly report: third quarter";

        const portionFormat = textFrame.paragraphs.get(0).portions.get(0).portionFormat;
        portionFormat.fontHeight = 32;
        portionFormat.fontBold = NullableBool.True;

        presentation.save("text-box-updated.pptx", SaveFormat.Pptx);
        console.log("Saved text-box-updated.pptx");
    } else {
        console.log("The first shape on the first slide is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

`text-box-updated.pptx` में टेक्स्ट बॉक्स "Quarterly report: third quarter" को बोल्ड 32‑पॉइंट टाइप में दिखाता है। क्योंकि नया टेक्स्ट एक ही पोर्शन है, दोनों स्वरूपण गुण पूरे टेक्स्ट पर लागू होते हैं। लाइसेंस के बिना, हर सहेजने पर एक मूल्यांकन वाटरमार्क जोड़ता है। क्योंकि `text-box.pptx` स्वयं मूल्यांकन मोड में सहेजा गया था, `text-box-updated.pptx` में दो वाटरमार्क होते हैं; देखें [Aspose.Slides का मूल्यांकन करें](/slides/hi/nodejs-net/evaluate-aspose-slides/)।

## **अक्सर पूछे जाने वाले प्रश्न**

**`fontBold` `NullableBool` मान क्यों लेता है न कि `true` या `false`?**

एक पोर्शन किसी प्रॉपर्टी को अपरिभाषित छोड़ सकता है और उसे पैराग्राफ, shape, या स्लाइड के लेआउट और मास्टर से विरासत में ले सकता है। `NullableBool.NotDefined` का अर्थ "inherit" है, जबकि `NullableBool.True` और `NullableBool.False` विरासत में मिले मान को ओवरराइड करते हैं। `true` या `false` असाइन करने पर त्रुटि आती है। इसी कारण `fontHeight` `NaN` लौटाता है जब पोर्शन अपना फ़ॉन्ट आकार विरासत में लेता है।

**मैं टेक्स्ट का रंग कैसे बदलूँ?**

पोर्टियन फ़ॉर्मेट के फ़िल को सेट करें: `portionFormat.fillFormat.fillType` को `FillType.Solid` असाइन करें, और फिर `portionFormat.fillFormat.solidFillColor.color` को `"#FF0000"` जैसे रंग असाइन करें। पैकेज से इम्पोर्ट किए जाने वाले नामों में `FillType` जोड़ें।

**मैं केवल टेक्स्ट का एक भाग कैसे फ़ॉर्मेट करूँ?**

फ़ॉर्मेटिंग पोर्शन से संबंधित होती है, इसलिए टेक्स्ट के उस भाग को अपने स्वयं के पोर्शन में रखें। पोर्शन को `Portion.CreatePortionFromText` से बनाएं, उसे पैराग्राफ के `portions` कलेक्शन के `add` मेथड से पैराग्राफ में जोड़ें, और फिर नए पोर्शन के `portionFormat` को सेट करें। पैकेज से इम्पोर्ट किए जाने वाले नामों में `Portion` जोड़ें।

**टेक्स्ट पढ़ते समय "... text has been truncated due to evaluation version limitation" क्यों मिलता है?**

लाइसेंस के बिना, Aspose.Slides पढ़ी गई किसी भी लंबी टेक्स्ट की केवल पहले पाँच अक्षर लौटाता है, जैसे `textFrame.text`, जिसके बाद यह नोटिस आता है। आप जो टेक्स्ट लिखते हैं वह पूर्ण रूप से सहेजा जाता है। पूर्ण टेक्स्ट पढ़ने के लिए [लाइसेंसिंग](/slides/hi/nodejs-net/licensing/) में वर्णित अनुसार लाइसेंस लागू करें।