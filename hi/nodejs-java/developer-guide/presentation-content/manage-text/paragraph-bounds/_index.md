---
title: जावास्क्रिप्ट में प्रेजेंटेशन्स से पैराग्राफ़ बाउंड्स प्राप्त करें
linktitle: पैराग्राफ़ बाउंड्स
type: docs
weight: 43
url: /hi/nodejs-java/paragraph-bounds/
keywords:
- पैराग्राफ़ बाउंड्स
- पैराग्राफ़ निर्देशांक
- पैराग्राफ़ आकार
- टेक्स्ट फ्रेम
- PowerPoint
- प्रेजेंटेशन
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "जावास्क्रिप्ट के लिए Aspose.Slides में Node.js के माध्यम से पैराग्राफ़ बाउंड्स कैसे प्राप्त करें, यह सीखें ताकि PowerPoint प्रेजेंटेशन में टेक्स्ट पोजिशनिंग को अनुकूलित किया जा सके।"
---
## **परिचय**

यह लेख Aspose.Slides में पैराग्राफ़ की सीमाएँ, आकार, और निर्देशांक प्राप्त करने का तरीका समझाता है। यह दिखाता है कि कैसे [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) से [Paragraph.getRect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/getrect/) का उपयोग करके पैराग्राफ़ आयत प्राप्त की जा सकती है, तालिका सेल टेक्स्ट फ़्रेम के भीतर पैराग्राफ़ निर्देशांक कैसे प्राप्त किए जाएँ, और मापन इकाइयों, टेक्स्ट रैपिंग का सीमाओं पर प्रभाव, पिक्सेल रूपांतरण, और प्रभावी पैराग्राफ़ फ़ॉर्मेटिंग मानों जैसे महत्वपूर्ण विवरणों को उजागर करता है।

## **पैराग्राफ़ के आयताकार निर्देशांक प्राप्त करें**

पैराग्राफ़ की बाउंडिंग आयत प्राप्त करने के लिए [Paragraph.getRect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/getrect/) का उपयोग करें।

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    const rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **टेबल सेल TextFrame के भीतर पैराग्राफ़ का आकार प्राप्त करें**

टेबल सेल टेक्स्ट फ़्रेम में किसी [Paragraph](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/) का आकार और निर्देशांक प्राप्त करने के लिए, [Paragraph.getRect](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/paragraph/getrect/) का उपयोग करें। लौटाई गई आयत तालिका सेल टेक्स्ट फ़्रेम के सापेक्ष होती है, इसलिए स्लाइड-स्तर के निर्देशांक चाहिए होने पर तालिका की स्थिति और सेल ऑफ़सेट जोड़ें।

निम्न उदाहरण तालिका सेल के भीतर पैराग्राफ़ की सीमाएँ प्राप्त करता है और स्लाइड पर आयतें बनाकर उन सीमाओं को दृश्य रूप में प्रस्तुत करता है:

```javascript
const presentation = new aspose.slides.Presentation("source.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const table = slide.getShapes().get_Item(0);
    const cell = table.getRows().get_Item(1).get_Item(1);

    const cellX = table.getX() + cell.getOffsetX();
    const cellY = table.getY() + cell.getOffsetY();
    const paragraphs = cell.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        if (paragraph.getText() === "") {
            continue;
        }

        const paragraphRectangle = paragraph.getRect();
        const paragraphRectangleX = paragraphRectangle.x + cellX;
        const paragraphRectangleY = paragraphRectangle.y + cellY;
        const paragraphRectangleWidth = paragraphRectangle.width;
        const paragraphRectangleHeight = paragraphRectangle.height;

        const paragraphBoundsShape = slide.getShapes().addAutoShape(
            aspose.slides.ShapeType.Rectangle,
            java.newFloat(paragraphRectangleX),
            java.newFloat(paragraphRectangleY),
            java.newFloat(paragraphRectangleWidth),
            java.newFloat(paragraphRectangleHeight));

        paragraphBoundsShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "YELLOW"));
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    }

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**पैराग्राफ़ निर्देशांक किस इकाइयों में मापे जाते हैं?**  
वे पॉइंट्स में मापे जाते हैं, जहाँ 1 इंच बराबर 72 पॉइंट्स होता है। यह स्लाइड के सभी निर्देशांक और आयामों पर लागू होता है।

**क्या शब्द रैपिंग का पैराग्राफ़ की सीमाओं पर प्रभाव पड़ता है?**  
हां। यदि [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframeformat/setwraptext/) को [TextFrame](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/textframe/) के लिए सक्षम किया गया है, तो टेक्स्ट क्षेत्र की चौड़ाई में फिट होने के लिए टूटता है, जिससे पैराग्राफ़ की वास्तविक सीमाएँ बदल जाती हैं।

**क्या पैराग्राफ़ निर्देशांक को निर्यातित छवि में पिक्सेल में विश्वसनीय रूप से मैप किया जा सकता है?**  
हां। इस सूत्र का उपयोग करके पॉइंट्स को पिक्सेल में बदलें: pixels = points × (DPI / 72). परिणाम रेंडरिंग या निर्यात के लिए चुनी गई DPI पर निर्भर करता है।

**मैं शैली विरासत को ध्यान में रखते हुए "प्रभावी" पैराग्राफ़ फ़ॉर्मेटिंग पैरामीटर कैसे प्राप्त करूँ?**  
Use the [effective paragraph formatting data structure](/slides/hi/nodejs-java/shape-effective-properties/); it returns the final consolidated values for indents, spacing, wrapping, RTL, and more.