---
title: Android पर प्रस्तुतियों से पैराग्राफ बाउंड्स प्राप्त करें
linktitle: पैराग्राफ बाउंड्स
type: docs
weight: 43
url: /hi/androidjava/paragraph-bounds/
keywords:
- पैराग्राफ बाउंड्स
- पैराग्राफ निर्देशांक
- पैराग्राफ आकार
- टेक्स्ट फ्रेम
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android में जावा के माध्यम से पैराग्राफ बाउंड्स प्राप्त करना सीखें ताकि PowerPoint प्रस्तुतियों में टेक्स्ट की स्थिति को अनुकूलित किया जा सके।"
---
## **अवलोकन**

यह लेख Aspose.Slides में पैराग्राफ की सीमाएँ, आकार और निर्देशांक कैसे प्राप्त करें, इसे समझाता है। यह दर्शाता है कि कैसे [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) से [IParagraph.getRect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IParagraph#getRect--) का उपयोग करके पैराग्राफ आयत प्राप्त की जाए, तालिका सेल टेक्स्ट फ्रेम के भीतर पैराग्राफ के निर्देशांक कैसे प्राप्त हों, और माप इकाइयाँ, टेक्स्ट रैपिंग का सीमाओं पर प्रभाव, पिक्सल परिवर्तन, और प्रभावी पैराग्राफ फ़ॉर्मेटिंग मान जैसे महत्वपूर्ण विवरणों को उजागर करता है।

## **पैराग्राफ के आयताकार निर्देशांक प्राप्त करें**

[IParagraph.getRect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IParagraph#getRect--) का उपयोग करके पैराग्राफ का बाउंडिंग आयत प्राप्त करें।

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    android.graphics.RectF rectangle = paragraph.getRect();
} finally {
    presentation.dispose();
}
```

## **टेबल सेल टेक्स्ट फ्रेम के भीतर पैराग्राफ का आकार प्राप्त करें**

एक टेबल सेल टेक्स्ट फ्रेम में [IParagraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iparagraph/) का आकार और निर्देशांक प्राप्त करने के लिए, [IParagraph.getRect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IParagraph#getRect--) का उपयोग करें। वापस किया गया आयत टेबल सेल टेक्स्ट फ्रेम के सापेक्ष होता है, इसलिए स्लाइड-स्तर के निर्देशांक चाहिए हों तो टेबल की स्थिति और सेल ऑफसेट जोड़ें।

निम्न उदाहरण टेबल सेल के भीतर पैराग्राफ की सीमाएँ प्राप्त करता है और स्लाइड पर आयतें खींचता है जिससे उन सीमाओं को देखा जा सके:

```java
Presentation presentation = new Presentation("source.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable) slide.getShapes().get_Item(0);
    ICell cell = table.getRows().get_Item(1).get_Item(1);

    double cellX = table.getX() + cell.getOffsetX();
    double cellY = table.getY() + cell.getOffsetY();

    for (IParagraph paragraph : cell.getTextFrame().getParagraphs())
    {
        if (paragraph.getText().isEmpty())
            continue;

        android.graphics.RectF paragraphRectangle = paragraph.getRect();
        float paragraphRectangleX = paragraphRectangle.left + (float) cellX;
        float paragraphRectangleY = paragraphRectangle.top + (float) cellY;

        IAutoShape paragraphBoundsShape = slide.getShapes().addAutoShape(
                ShapeType.Rectangle,
                paragraphRectangleX,
                paragraphRectangleY,
                paragraphRectangle.width(),
                paragraphRectangle.height());

        paragraphBoundsShape.getFillFormat().setFillType(FillType.NoFill);
        paragraphBoundsShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        paragraphBoundsShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**पैराग्राफ निर्देशांक किस इकाई में मापे जाते हैं?**

इन्हें पॉइंट्स में मापा जाता है, जहाँ 1 इंच बराबर 72 पॉइंट्स होता है। यह स्लाइड पर सभी निर्देशांक और आयामों पर लागू होता है।

**क्या शब्द रैपिंग पैराग्राफ की सीमाओं को प्रभावित करती है?**

हां। यदि [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-) को [ITextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframe/) के लिए सक्षम किया गया है, तो टेक्स्ट क्षेत्र की चौड़ाई में फिट होने के लिए टूट जाता है, जिससे पैराग्राफ की वास्तविक सीमाएँ बदल जाती हैं।

**क्या पैराग्राफ निर्देशांक को निर्यातित छवि में पिक्सल में भरोसेमंद रूप से मैप किया जा सकता है?**

हां। पॉइंट्स को पिक्सल में बदलने के लिए इस सूत्र का उपयोग करें: pixels = points × (DPI / 72). परिणाम रेंडरिंग या निर्यात के लिए चयनित DPI पर निर्भर करता है।

**मैं शैली विरासत को ध्यान में रखते हुए "प्रभावी" पैराग्राफ फॉर्मेटिंग पैरामीटर कैसे प्राप्त करूँ?**

[प्रभावी पैराग्राफ फॉर्मेटिंग डेटा संरचना](/slides/hi/androidjava/shape-effective-properties/) का उपयोग करें; यह इंडेंट, स्पेसिंग, रैपिंग, RTL और अन्य के लिए अंतिम समेकित मान लौटाता है।