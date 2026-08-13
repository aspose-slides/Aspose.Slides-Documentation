---
title: जावा में प्रस्तुतियों से आकार के प्रभावी गुण प्राप्त करें
linktitle: प्रभावी गुण
type: docs
weight: 50
url: /hi/java/shape-effective-properties/
keywords:
- आकार गुण
- कैमरा गुण
- लाइट रिग
- बेवेल आकार
- टेक्स्ट फ्रेम
- टेक्स्ट शैली
- फ़ॉन्ट ऊँचाई
- भरण स्वरूप
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: "जानिए कि Aspose.Slides for Java कैसे सटीक PowerPoint रेंडरिंग के लिए आकार के प्रभावी गुणों की गणना और लागू करता है।"
---
## **अवलोकन**

यह विषय **स्थानीय** और **प्रभावी** गुणों के बीच अंतर को समझाता है। स्थानीय मान वे मान होते हैं जो सीधे किसी विशिष्ट स्वरूपण स्तर पर सेट किए जाते हैं, जैसे:

1. स्लाइड पर भाग (portion) गुण।
1. लेआउट या मास्टर स्लाइड पर प्रोटोटाइप आकार के टेक्स्ट शैलियों, जब भाग के टेक्स्ट फ्रेम आकार में एक हो।
1. प्रस्तुति में वैश्विक टेक्स्ट सेटिंग्स।

स्थानीय मान किसी भी स्तर पर परिभाषित या छोड़े जा सकते हैं। जब Aspose.Slides को अंतिम "जैसे प्रस्तुत" स्वरूपण चाहिए होता है, तो वह विरासत श्रृंखला को हल करता है और **प्रभावी** मान लौटाता है। आप इन्हें स्थानीय स्वरूपण वस्तु पर `getEffective` विधि को कॉल करके प्राप्त कर सकते हैं।

निम्नलिखित उदाहरण दिखाता है कि प्रभावी मान कैसे प्राप्त करें। यह मानता है कि प्रथम स्लाइड पर पहला आकार एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IAutoShape) है जिसमें टेक्स्ट फ्रेम और कम से कम एक भाग है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat localTextFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = localTextFrameFormat.getEffective();

    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    IPortion portion = paragraph.getPortions().get_Item(0);
    IPortionFormat localPortionFormat = portion.getPortionFormat();
    IPortionFormatEffectiveData effectivePortionFormat = localPortionFormat.getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="info" %}}
प्रभावी स्वरूपण डेटा वह वर्तमान गणना किया गया स्वरूपण दर्शाता है जो विरासत लागू होने के बाद प्राप्त होता है। वर्तमान कार्यान्वयन में, कुछ प्रभावी डेटा वस्तुएँ, जैसे कि [IPortionFormatEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPortionFormatEffectiveData), आंतरिक रूप से कैश हो सकती हैं। पैरेंट या विरासतित स्वरूपण बदलने के बाद `getEffective` को फिर से कॉल करने से कैश्ड डेटा रीफ़्रेश हो सकता है, और पहले प्राप्त वस्तु अब पूर्व स्थिति का प्रतिनिधित्व नहीं कर सकती। यदि आपको प्रभावी मानों को बाद में पुनः उपयोग के लिए संरक्षित करना है, तो आवश्यक गुणों जैसे फ़ॉन्ट ऊँचाई, भरने का रंग, फ़ॉन्ट शैली, या संरेखण को अपनी डेटा वस्तु में कॉपी करें।
{{% /alert %}}

## **कैमरा के प्रभावी गुण प्राप्त करें**

Aspose.Slides आपको कैमरे के प्रभावी गुण प्राप्त करने की अनुमति देता है। [ICameraEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICameraEffectiveData) इंटरफ़ेस एक अपरिवर्तनीय वस्तु का प्रतिनिधित्व करता है जिसमें प्रभावी कैमरा गुण शामिल होते हैं। एक [ICameraEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICameraEffectiveData) उदाहरण [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IThreeDFormatEffectiveData) के माध्यम से उजागर किया जाता है, जो [IThreeDFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IThreeDFormat) के लिए प्रभावी मान प्रदान करता है।

निम्नलिखित कोड नमूना दिखाता है कि कैमरे के लिए प्रभावी गुण कैसे प्राप्त करें। यह मानता है कि प्रथम स्लाइड पर पहला आकार 3D स्वरूपण रखता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();
    int cameraType = cameraEffectiveData.getCameraType();
    double fieldOfViewAngle = cameraEffectiveData.getFieldOfViewAngle();
    double zoom = cameraEffectiveData.getZoom();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraType);
    System.out.println("Field of view: " + fieldOfViewAngle);
    System.out.println("Zoom: " + zoom);
} finally {
    presentation.dispose();
}
```

## **लाइट रिग के प्रभावी गुण получ करें**

Aspose.Slides आपको लाइट रिग के प्रभावी गुण प्राप्त करने की अनुमति देता है। [ILightRigEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ILightRigEffectiveData) इंटरफ़ेस एक अपरिवर्तनीय वस्तु का प्रतिनिधित्व करता है जिसमें प्रभावी लाइट रिग गुण शामिल होते हैं। एक [ILightRigEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ILightRigEffectiveData) उदाहरण [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IThreeDFormatEffectiveData) के माध्यम से उजागर किया जाता है, जो [IThreeDFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IThreeDFormat) के लिए प्रभावी मान प्रदान करता है।

निम्नलिखित कोड नमूना दिखाता है कि लाइट रिग के लिए प्रभावी गुण कैसे प्राप्त करें। यह मानता है कि प्रथम स्लाइड पर पहला आकार 3D स्वरूपण रखता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();
    int lightType = lightRigEffectiveData.getLightType();
    int direction = lightRigEffectiveData.getDirection();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightType);
    System.out.println("Direction: " + direction);
} finally {
    presentation.dispose();
}
```

## **बेवेल आकार के प्रभावी गुण प्राप्त करें**

Aspose.Slides आपको आकार के बेवेल के प्रभावी गुण प्राप्त करने की अनुमति देता है। [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeBevelEffectiveData) इंटरफ़ेस एक अपरिवर्तनीय वस्तु का प्रतिनिधित्व करता है जिसमें आकार के लिए प्रभावी फेस‑रिलिफ़ गुण होते हैं। एक [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeBevelEffectiveData) उदाहरण [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IThreeDFormatEffectiveData) के माध्यम से उजागर किया जाता है, जो [IThreeDFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IThreeDFormat) के लिए प्रभावी मान प्रदान करता है।

निम्नलिखित कोड नमूना दिखाता है कि आकार के शीर्ष बेवेल के लिए प्रभावी गुण कैसे प्राप्त करें। यह मानता है कि प्रथम स्लाइड पर पहला आकार 3D स्वरूपण रखता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);
    
    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTop = threeDEffectiveData.getBevelTop();
    int bevelType = bevelTop.getBevelType();
    double bevelWidth = bevelTop.getWidth();
    double bevelHeight = bevelTop.getHeight();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelType);
    System.out.println("Width: " + bevelWidth);
    System.out.println("Height: " + bevelHeight);
} finally {
    presentation.dispose();
}
```

## **टेक्स्ट फ्रेम के प्रभावी गुण प्राप्त करें**

Aspose.Slides का उपयोग करके, आप टेक्स्ट फ्रेम के प्रभावी गुण प्राप्त कर सकते हैं। [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITextFrameFormatEffectiveData) इंटरफ़ेस में प्रभावी टेक्स्ट फ्रेम स्वरूपण गुण होते हैं।

निम्नलिखित कोड नमूना दिखाता है कि प्रभावी टेक्स्ट फ्रेम स्वरूपण गुण कैसे प्राप्त करें। यह मानता है कि प्रथम स्लाइड पर पहला आकार एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IAutoShape) है जिसमें टेक्स्ट फ्रेम है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormat textFrameFormat = shape.getTextFrame().getTextFrameFormat();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrameFormat.getEffective();
    int anchoringType = effectiveTextFrameFormat.getAnchoringType();
    int autofitType = effectiveTextFrameFormat.getAutofitType();
    int textVerticalType = effectiveTextFrameFormat.getTextVerticalType();
    double marginLeft = effectiveTextFrameFormat.getMarginLeft();
    double marginTop = effectiveTextFrameFormat.getMarginTop();
    double marginRight = effectiveTextFrameFormat.getMarginRight();
    double marginBottom = effectiveTextFrameFormat.getMarginBottom();

    System.out.println("Anchoring type: " + anchoringType);
    System.out.println("Autofit type: " + autofitType);
    System.out.println("Text vertical type: " + textVerticalType);
    System.out.println("Margins");
    System.out.println("   Left: " + marginLeft);
    System.out.println("   Top: " + marginTop);
    System.out.println("   Right: " + marginRight);
    System.out.println("   Bottom: " + marginBottom);
} finally {
    presentation.dispose();
}
```

## **टेक्स्ट शैली के प्रभावी गुण प्राप्त करें**

Aspose.Slides का उपयोग करके, आप टेक्स्ट शैली के प्रभावी गुण प्राप्त कर सकते हैं। [ITextStyleEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITextStyleEffectiveData) इंटरफ़ेस में प्रभावी टेक्स्ट शैली गुण होते हैं।

निम्नलिखित कोड नमूना दिखाता है कि प्रभावी टेक्स्ट शैली गुण कैसे प्राप्त करें। यह मानता है कि प्रथम स्लाइड पर पहला आकार एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IAutoShape) है जिसमें टेक्स्ट फ्रेम है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);
    
    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
    {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);
        int depth = effectiveStyleLevel.getDepth();
        double indent = effectiveStyleLevel.getIndent();
        int alignment = effectiveStyleLevel.getAlignment();
        int fontAlignment = effectiveStyleLevel.getFontAlignment();
        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + depth);
        System.out.println("Indent: " + indent);
        System.out.println("Alignment: " + alignment);
        System.out.println("Font alignment: " + fontAlignment);
    }
} finally {
    presentation.dispose();
}
```

## **प्रभावी फ़ॉन्ट ऊँचाई मान प्राप्त करें**

Aspose.Slides का उपयोग करके, आप प्रभावी फ़ॉन्ट ऊँचाई प्राप्त कर सकते हैं। निम्नलिखित कोड दर्शाता है कि विभिन्न प्रस्तुति संरचना स्तरों पर स्थानीय फ़ॉन्ट ऊँचाई मान सेट करने के बाद भाग की प्रभावी फ़ॉन्ट ऊँचाई कैसे बदलती है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 75, false);
    autoShape.addTextFrame("");

    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    IPortion firstPortion = new Portion("Sample text with first portion");
    IPortion secondPortion = new Portion(" and second portion.");

    paragraph.getPortions().add(firstPortion);
    paragraph.getPortions().add(secondPortion);

    IPortionFormatEffectiveData firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    IPortionFormatEffectiveData secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height just after creation:");
    double firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    double secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.getDefaultTextStyle().getLevel(0).getDefaultPortionFormat().setFontHeight(24);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting the presentation default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(40);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting paragraph default font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    firstPortion.getPortionFormat().setFontHeight(55);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();

    System.out.println("Effective font height after setting portion #0 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    secondPortion.getPortionFormat().setFontHeight(18);
    firstPortionFormatEffectiveData = firstPortion.getPortionFormat().getEffective();
    secondPortionFormatEffectiveData = secondPortion.getPortionFormat().getEffective();
    
    System.out.println("Effective font height after setting portion #1 font height:");
    firstPortionFontHeight = firstPortionFormatEffectiveData.getFontHeight();
    secondPortionFontHeight = secondPortionFormatEffectiveData.getFontHeight();
    System.out.println("Portion #0: " + firstPortionFontHeight);
    System.out.println("Portion #1: " + secondPortionFontHeight);

    presentation.save("SetLocalFontHeightValues.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **टेबल के लिए प्रभावी भराव स्वरूप प्राप्त करें**

Aspose.Slides का उपयोग करके, आप विभिन्न टेबल भागों के लिए प्रभावी भराव स्वरूपण प्राप्त कर सकते हैं। [IFillFormatEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IFillFormatEffectiveData) इंटरफ़ेस में प्रभावी भराव स्वरूपण गुण होते हैं। सेल स्वरूपण का प्राथमिकता पंक्ति स्वरूपण से अधिक है, पंक्ति स्वरूपण का प्राथमिकता कॉलम स्वरूपण से अधिक है, और कॉलम स्वरूपण का प्राथमिकता सम्पूर्ण टेबल स्वरूपण से अधिक है।

परिणामस्वरूप, टेबल सेल को चित्रित करने के लिए [ICellFormatEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICellFormatEffectiveData) गुणों का उपयोग किया जाता है। निम्नलिखित कोड नमूना दिखाता है कि विभिन्न टेबल भागों के लिए प्रभावी भराव स्वरूपण कैसे प्राप्त करें। यह मानता है कि प्रथम स्लाइड पर पहला आकार एक [ITable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITable) है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);
    
    ITableFormatEffectiveData tableFormatEffective = table.getTableFormat().getEffective();
    IRowFormatEffectiveData rowFormatEffective = table.getRows().get_Item(0).getRowFormat().getEffective();
    IColumnFormatEffectiveData columnFormatEffective = table.getColumns().get_Item(0).getColumnFormat().getEffective();
    ICellFormatEffectiveData cellFormatEffective = table.get_Item(0, 0).getCellFormat().getEffective();

    IFillFormatEffectiveData tableFillFormatEffective = tableFormatEffective.getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = rowFormatEffective.getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = columnFormatEffective.getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cellFormatEffective.getFillFormat();
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या `getEffective` एक स्नैपशॉट लौटाता है?

हमेशा नहीं। प्रभावी डेटा विरासत लागू होने के बाद गणना किया गया स्वरूपण दर्शाता है, लेकिन कुछ प्रभावी डेटा वस्तुएँ आंतरिक रूप से कैश हो सकती हैं। एक बाद वाला `getEffective` कॉल स्वरूपण को पुनः गणना कर सकता है और कैश्ड डेटा को रीफ़्रेश कर सकता है, इसलिए पहले प्राप्त वस्तु को स्थायी स्नैपशॉट के रूप में नहीं माना जाना चाहिए।

### मुझे प्रभावी गुणों को पुनः कब पढ़ना चाहिए?

स्थानीय स्वरूपण, पैरेंट शैली, लेआउट स्वरूपण, मास्टर स्वरूपण, या प्रस्तुति‑स्तर के डिफ़ॉल्ट बदलने के बाद `getEffective` को पुनः कॉल करें। अगली कॉल स्वरूपण पदानुक्रम को पुनर्मूल्यांकन करती है और वर्तमान प्रभावी परिणाम लौटाती है।

### क्या लेआउट/मास्टर स्लाइड को बदलना या हटाना पहले प्राप्त प्रभावी गुणों को प्रभावित करता है?

हाँ, लेकिन परिवर्तन अगली `getEffective` कॉल पर प्रतिबिंबित होगा। यदि पैरेंट स्वरूपण स्रोत बदलता या हटाया जाता है, तो पहले प्राप्त प्रभावी डेटा पुराना हो सकता है। एक बार `getEffective` फिर से कॉल करने पर, Aspose.Slides स्वरूपण वृक्ष को पुनः मूल्यांकन करता है और परिणामस्वरूप फ़ॉन्ट, रंग, आकार या अन्य मान बदल सकते हैं।

### क्या मैं प्रभावी डेटा वस्तुओं के माध्यम से मान संशोधित कर सकता हूँ?

नहीं। प्रभावी डेटा वस्तुएँ गणना किए गए मान प्रदान करती हैं। स्थानीय स्वरूपण वस्तुओं में परिवर्तन करें, और फिर प्रभावी मान पुनः प्राप्त करें।

### यदि कोई गुण आकार स्तर पर, न लेआउट/मास्टर में, न ही वैश्विक सेटिंग्स में सेट नहीं है तो क्या होता है?

प्रभावी मान डिफ़ॉल्ट तंत्र द्वारा निर्धारित किया जाता है, जिसमें PowerPoint और Aspose.Slides के डिफ़ॉल्ट शामिल होते हैं। वह निर्धारित मान वर्तमान प्रभावी डेटा का हिस्सा बन जाता है।

### क्या प्रभावी फ़ॉन्ट मान से मैं बता सकता हूँ कि किस स्तर ने आकार या फ़ॉन्ट प्रदान किया?

सीधे नहीं। प्रभावी डेटा अंतिम मान लौटाता है। स्रोत पता करने के लिए, भाग, पैराग्राफ, टेक्स्ट फ्रेम, और लेआउट, मास्टर, तथा प्रस्तुति स्तर पर टेक्स्ट शैलियों में स्थानीय मान देखें कि पहली स्पष्ट परिभाषा कहाँ है।

### क्यों कभी‑कभी प्रभावी मान स्थानीय मानों के समान दिखते हैं?

क्योंकि स्थानीय मान अंततः अंतिम हो गया (उच्च स्तर की विरासत की आवश्यकता नहीं थी)। ऐसे मामलों में, प्रभावी मान स्थानीय मान से मेल खाता है।

### मुझे प्रभावी गुण कब उपयोग करने चाहिए, और केवल स्थानीय गुणों के साथ कब काम करना चाहिए?

जब आपको सभी विरासत लागू होने के बाद "जैसे प्रस्तुत" परिणाम चाहिए, जैसे रंग, इंडेंट या आकार का संरेखण, तो प्रभावी डेटा का उपयोग करें। यदि आप इन मानों को बाद में स्वरूपण परिवर्तन के बावजूद संरक्षित रखना चाहते हैं, तो आवश्यक गुणों को अपनी वस्तु में कॉपी करें। यदि आप किसी विशिष्ट स्तर पर स्वरूपण बदलना चाहते हैं, तो स्थानीय गुणों को संशोधित करें और आवश्यक होने पर प्रभावी डेटा को पुनः पढ़ें ताकि परिणाम की पुष्टि हो सके।