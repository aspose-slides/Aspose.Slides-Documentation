---
title: जावा में प्रस्तुतियों से अनुच्छेद सीमाएँ प्राप्त करें
linktitle: अनुच्छेद
type: docs
weight: 60
url: /hi/java/paragraph/
keywords:
- अनुच्छेद सीमाएँ
- पाठ भाग सीमाएँ
- अनुच्छेद निर्देशांक
- भाग निर्देशांक
- अनुच्छेद आकार
- पाठ भाग आकार
- टेक्स्ट फ्रेम
- PowerPoint
- प्रस्तुति
- जावा
- Aspose.Slides
description: "जावा के लिए Aspose.Slides में अनुच्छेद और टेक्स्ट-भाग सीमाएँ प्राप्त करने के तरीके सीखें ताकि PowerPoint प्रस्तुतियों में टेक्स्ट स्थिति को अनुकूलित किया जा सके।"
---
## **अवलोकन**

यह लेख Aspose.Slides में अनुच्छेदों और टेक्स्ट भागों की सीमाएँ, आकार और निर्देशांक प्राप्त करने के तरीकों को समझाता है। यह `getRect()` का उपयोग करके `TextFrame` में किसी अनुच्छेद का आयत प्राप्त करने, तालिका कोशिका टेक्स्ट फ्रेम के भीतर अनुच्छेद और भाग के निर्देशांक कैसे प्राप्त करें, और माप इकाइयाँ, टेक्स्ट रैपिंग का सीमाओं पर प्रभाव, पिक्सेल रूपांतरण, तथा प्रभावी अनुच्छेद स्वरूपण मानों जैसे महत्वपूर्ण विवरणों को दर्शाता है।

## **TextFrame में अनुच्छेद और भाग के निर्देशांक प्राप्त करना**
Aspose.Slides for Java का उपयोग करके, डेवलपर अब TextFrame के पैराग्राफ संग्रह में पैराग्राफ के आयताकार निर्देशांक प्राप्त कर सकते हैं। यह आपको पैराग्राफ के भाग संग्रह के भीतर [भाग के निर्देशांक](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPortion#getCoordinates--) को प्राप्त करने की भी अनुमति देता है। इस विषय में, हम एक उदाहरण की सहायता से प्रदर्शन करेंगे कि पैराग्राफ के आयताकार निर्देशांक के साथ भाग की स्थिति कैसे प्राप्त की जाती है।

``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```

## **अनुच्छेद के आयताकार निर्देशांक प्राप्त करना**
डेलवरी [**getRect()**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IParagraph#getRect--) विधि का उपयोग करके डेवलपर अनुच्छेद सीमाओं का आयत प्राप्त कर सकते हैं।

```java
Presentation pres = new Presentation("HelloWorld.pptx");
try {
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ITextFrame textFrame = shape.getTextFrame();
    Rectangle2D.Float rect = textFrame.getParagraphs().get_Item(0).getRect();
    System.out.println("X: " + rect.x + " Y: " + rect.y + " Width: " + rect.width + " Height: " + rect.height);
} finally {
    if (pres != null) pres.dispose();
}
```

## **तालिका सेल TextFrame के भीतर अनुच्छेद और भाग का आकार प्राप्त करना**
तालिका सेल टेक्स्ट फ्रेम में [Portion](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Portion) या [Paragraph](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Paragraph) का आकार और निर्देशांक प्राप्त करने के लिए, आप [IPortion.getRect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPortion#getRect--) और [IParagraph.getRect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IParagraph#getRect--) विधियों का उपयोग कर सकते हैं।

यह नमूना कोड वर्णित कार्य को प्रदर्शित करता है:

```java
Presentation pres = new Presentation("source.pptx");
try {
    Table tbl = (Table)pres.getSlides().get_Item(0).getShapes().get_Item(0);
    ICell cell = tbl.getRows().get_Item(1).get_Item(1);

    double x = tbl.getX() + tbl.getRows().get_Item(1).get_Item(1).getOffsetX();
    double y = tbl.getY() + tbl.getRows().get_Item(1).get_Item(1).getOffsetY();

    for (IParagraph para : cell.getTextFrame().getParagraphs())
    {
        if (para.getText().equals(""))
            continue;

        Rectangle2D.Float rect = para.getRect();
        IAutoShape shape =
                pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                        (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

        shape.getFillFormat().setFillType(FillType.NoFill);
        shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.YELLOW);
        shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);

        for (IPortion portion : para.getPortions())
        {
            if (portion.getText().contains("0"))
            {
                rect = portion.getRect();
                shape =
                        pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle,
                                (float)rect.getX() + (float)x, (float)rect.getY() + (float)y, (float)rect.getWidth(), (float)rect.getHeight());

                shape.getFillFormat().setFillType(FillType.NoFill);
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**अनुच्छेद और टेक्स्ट भागों के निर्देशांक किस इकाइयों में लौटाए जाते हैं?**

पॉइंट्स में, जहाँ 1 इंच = 72 पॉइंट्स है। यह स्लाइड पर सभी निर्देशांक और आयामों पर लागू होता है।

**क्या शब्द रैपिंग से अनुच्छेद की सीमाओं पर प्रभाव पड़ता है?**

हां। यदि [wrapping](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textframeformat/#setWrapText-byte-) को [TextFrame](https://reference.aspose.com/slides/hi/java/com.aspose.slides/textframe/) में सक्षम किया गया है, तो टेक्स्ट क्षेत्र की चौड़ाई के अनुसार टूटता है, जिससे अनुच्छेद की वास्तविक सीमाएँ बदल जाती हैं।

**क्या अनुच्छेद के निर्देशांक को निर्यातित छवि में पिक्सेल में विश्वसनीय रूप से मैप किया जा सकता है?**

हां। पॉइंट्स को पिक्सेल में बदलने के लिए उपयोग करें: pixels = points × (DPI / 72)। परिणाम रेंडरिंग/निर्यात के लिए चुने गए DPI पर निर्भर करता है।

**मैं शैली विरासत को ध्यान में रखते हुए "प्रभावी" अनुच्छेद स्वरूपण पैरामीटर कैसे प्राप्त करूं?**

इनहेरिटेड शैली को ध्यान में रखते हुए [effective paragraph formatting data structure](/slides/hi/java/shape-effective-properties/) का उपयोग करें; यह इंडेंट, स्पेसिंग, रैपिंग, RTL और अन्य के लिए अंतिम समेकित मान लौटाता है।