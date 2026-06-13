---
title: Android पर प्रस्तुतियों से पैराग्राफ की सीमाएँ प्राप्त करें
linktitle: पैराग्राफ
type: docs
weight: 60
url: /hi/androidjava/paragraph/
keywords:
- पैराग्राफ सीमाएँ
- टेक्स्ट भाग सीमाएँ
- पैराग्राफ समन्वय
- भाग समन्वय
- पैराग्राफ आकार
- टेक्स्ट भाग आकार
- टेक्स्ट फ्रेम
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android में Java के माध्यम से पैराग्राफ और टेक्स्ट भाग सीमाएँ प्राप्त करने का तरीका सीखें ताकि PowerPoint प्रस्तुतियों में टेक्स्ट की स्थिति को अनुकूलित किया जा सके।"
---
## **अवलोकन**

यह लेख Aspose.Slides में पैराग्राफ और टेक्स्ट भागों की सीमा, आकार और समन्वय कैसे प्राप्त किए जाएँ, इसकी व्याख्या करता है। यह दिखाता है कि `getRect()` का उपयोग करके `TextFrame` में पैराग्राफ का आयत कैसे प्राप्त किया जाए, तालिका सेल टेक्स्ट फ्रेम के भीतर पैराग्राफ और भाग के समन्वय कैसे प्राप्त किए जाएँ, और माप इकाइयाँ, टेक्स्ट रैपिंग का सीमा पर प्रभाव, पिक्सेल रूपान्तरण, तथा प्रभावी पैराग्राफ फ़ॉर्मेटिंग मूल्यों जैसी महत्वपूर्ण विवरणों को उजागर करता है।

## **TextFrame में पैराग्राफ और भाग के समन्वय प्राप्त करना**
Aspose.Slides for Android को Java के माध्यम से उपयोग करते हुए, डेवलपर्स अब TextFrame के पैराग्राफ संग्रह के भीतर पैराग्राफ के आयताकार समन्वय प्राप्त कर सकते हैं। यह आपको पैराग्राफ के भाग संग्रह के भीतर [भाग के समन्वय](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPortion#getCoordinates--) प्राप्त करने की भी अनुमति देता है। इस विषय में, हम एक उदाहरण की मदद से दर्शाएँगे कि कैसे पैराग्राफ के आयताकार समन्वय को उसके भीतर भाग की स्थिति के साथ प्राप्त किया जाए।

``` java
AutoShape shape = (AutoShape)pres.getSlides().get_Item(0).getShapes().get_Item(0);
TextFrame textFrame = (TextFrame)shape.getTextFrame();
for (IParagraph paragraph : textFrame.getParagraphs()){
  for (IPortion portion : paragraph.getPortions()){
    Point2D.Float point = portion.getCoordinates();
  }
}
```


## **पैराग्राफ के आयताकार समन्वय प्राप्त करना**
डिवेलपर्स [**getRect()**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IParagraph#getRect--) मेथड का उपयोग करके पैराग्राफ की सीमा आयत प्राप्त कर सकते हैं।

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

## **टेबल सेल TextFrame के भीतर पैराग्राफ और भाग का आकार प्राप्त करना**

टेबल सेल टेक्स्ट फ्रेम में [Portion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Portion) या [Paragraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Paragraph) का आकार और समन्वय प्राप्त करने के लिए, आप [IPortion.getRect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IPortion#getRect--) और [IParagraph.getRect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IParagraph#getRect--) मेथड्स का उपयोग कर सकते हैं।

यह नमूना कोड वर्णित ऑपरेशन को प्रदर्शित करता है:

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

## **FAQ**

**पैराग्राफ और टेक्स्ट भागों के समन्वय किस इकाइयों में लौटाए जाते हैं?**

पॉइंट्स में, जहाँ 1 इंच = 72 पॉइंट्स होता है। यह स्लाइड पर सभी समन्वय और आयामों पर लागू होता है।

**क्या शब्द रैपिंग पैराग्राफ की सीमा को प्रभावित करती है?**

हाँ। यदि [wrapping](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-) को [TextFrame](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/textframe/) में सक्षम किया गया है, तो टेक्स्ट क्षेत्र की चौड़ाई के अनुसार टूटता है, जिससे पैराग्राफ की वास्तविक सीमा बदल जाती है।

**क्या पैराग्राफ के समन्वय को एक्सपोर्ट किए गए इमेज में पिक्सेल में भरोसेमंद तरीके से मैप किया जा सकता है?**

हाँ। पॉइंट्स को पिक्सेल में परिवर्तित करने के लिए उपयोग करें: pixels = points × (DPI / 72). परिणाम रेंडरिंग/एक्सपोर्ट के लिए चुने गए DPI पर निर्भर करता है।

**मैं "effective" पैराग्राफ फ़ॉर्मेटिंग पैरामीटर कैसे प्राप्त करूँ, शैली विरासत को ध्यान में रखते हुए?**

यह [effective paragraph formatting data structure](/slides/hi/androidjava/shape-effective-properties/) का उपयोग करें; यह इंडेंट, स्पेसिंग, रैपिंग, RTL, आदि के लिए अंतिम एकीकृत मान लौटाता है।