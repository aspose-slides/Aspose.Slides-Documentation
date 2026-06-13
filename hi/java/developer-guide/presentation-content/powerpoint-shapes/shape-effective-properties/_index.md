---
title: जावा में प्रस्तुतियों से Shape प्रभावी गुण प्राप्त करें
linktitle: प्रभावी प्रॉपर्टीज़
type: docs
weight: 50
url: /hi/java/shape-effective-properties/
keywords:
- shape प्रॉपर्टीज़
- कैमरा प्रॉपर्टीज़
- लाइट रिग
- बीवेल Shape
- टेक्स्ट फ्रेम
- टेक्स्ट स्टाइल
- फ़ॉन्ट ऊँचाई
- फ़िल फ़ॉर्मेट
- PowerPoint
- प्रेजेंटेशन
- Java
- Aspose.Slides
description: "जावा के लिए Aspose.Slides कैसे सटीक PowerPoint रेंडरिंग के लिए प्रभावी Shape प्रॉपर्टीज़ की गणना और लागू करता है, इस बारे में जानें।"
---
## **अवलोकन**

यह विषय **स्थानीय** और **प्रभावी** प्रॉपर्टियों के बीच अंतर को समझाता है। स्थानीय मान वे मान हैं जो किसी विशिष्ट फॉर्मेटिंग स्तर पर सीधे सेट किए जाते हैं, जैसे:

1. स्लाइड पर भाग की प्रॉपर्टी।
2. लेआउट या मास्टर स्लाइड पर प्रोटोटाइप शAPE टेक्स्ट स्टाइल्स, जब भाग के टेक्स्ट फ़्रेम शAPE में एक हो।
3. प्रस्तुति में वैश्विक टेक्स्ट सेटिंग्स।

स्थानीय मान को किसी भी स्तर पर परिभाषित या छोड़ दिया जा सकता है। जब Aspose.Slides को अंतिम "जैसे दिखाया गया" फॉर्मेटिंग चाहिए होती है, तो यह विरासत श्रृंखला को हल करती है और **प्रभावी** मान लौटाती है। आप इन्हें स्थानीय फ़ॉर्मेट ऑब्जेक्ट पर `getEffective` मेथड को कॉल करके प्राप्त कर सकते हैं।

निम्नलिखित उदाहरण दिखाता है कि प्रभावी मान कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड पर पहला शAPE एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IAutoShape) है जिसमें एक टेक्स्ट फ़्रेम और कम से कम एक भाग है।

```java
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

{{% alert color="primary" %}}
प्रभावी फ़ॉर्मेटिंग डेटा वह वर्तमान गणना किया गया फ़ॉर्मेटिंग दर्शाता है जो विरासत लागू होने के बाद होता है। वर्तमान कार्यान्वयन में, कुछ प्रभावी डेटा ऑब्जेक्ट्स, जैसे कि [IPortionFormatEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPortionFormatEffectiveData), को आंतरिक रूप से कैश किया जा सकता है। पैरेंट या विरासत फ़ॉर्मेटिंग को बदलने के बाद फिर से `getEffective` कॉल करने से कैश्ड डेटा रीफ़्रेश हो सकता है, और पहले प्राप्त ऑब्जेक्ट अब पहले की स्थिति को दर्शा नहीं सकता। यदि आपको बाद में पुनः उपयोग के लिए प्रभावी मान सुरक्षित रखने की आवश्यकता है, तो आवश्यक प्रॉपर्टीज़ जैसे फ़ॉन्ट ऊँचाई, भरने का रंग, फ़ॉन्ट शैली, या संरेखण को अपने डेटा ऑब्जेक्ट में कॉपी करें।
{{% /alert %}}

## **कैमरा के प्रभावी प्रॉपर्टीज़ प्राप्त करें**

Aspose.Slides आपको कैमरा की प्रभावी प्रॉपर्टीज़ प्राप्त करने की अनुमति देता है। इंटरफ़ेस [ICameraEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICameraEffectiveData) एक अपरिवर्तनीय ऑब्जेक्ट दर्शाता है जिसमें प्रभावी कैमरा प्रॉपर्टीज़ होती हैं। एक [ICameraEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICameraEffectiveData) इंस्टेंस को [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IThreeDFormatEffectiveData) के माध्यम से उजागर किया जाता है, जो [IThreeDFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IThreeDFormat) के लिए प्रभावी मान प्रदान करता है।

```java
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

## **लाइट रिग की प्रभावी प्रॉपर्टीज़ प्राप्त करें**

Aspose.Slides आपको लाइट रिग की प्रभावी प्रॉपर्टीज़ प्राप्त करने की अनुमति देता है। इंटरफ़ेस [ILightRigEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ILightRigEffectiveData) एक अपरिवर्तनीय ऑब्जेक्ट दर्शाता है जिसमें प्रभावी लाइट रिग प्रॉपर्टीज़ होती हैं। एक [ILightRigEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ILightRigEffectiveData) इंस्टेंस को [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IThreeDFormatEffectiveData) के माध्यम से उजागर किया जाता है, जो [IThreeDFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IThreeDFormat) के लिए प्रभावी मान प्रदान करता है।

```java
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

## **बीवेल आकार की प्रभावी प्रॉपर्टीज़ प्राप्त करें**

Aspose.Slides आपको शAPE बीवेल की प्रभावी प्रॉपर्टीज़ प्राप्त करने की अनुमति देता है। इंटरफ़ेस [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeBevelEffectiveData) एक अपरिवर्तनीय ऑब्जेक्ट दर्शाता है जिसमें शAPE के लिए प्रभावी फेस-रिलिफ़ प्रॉपर्टीज़ होती हैं। एक [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShapeBevelEffectiveData) इंस्टेंस को [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IThreeDFormatEffectiveData) के माध्यम से उजागर किया जाता है, जो [IThreeDFormat](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IThreeDFormat) के लिए प्रभावी मान प्रदान करता है।

```java
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

## **टेक्स्ट फ्रेम की प्रभावी प्रॉपर्टीज़ प्राप्त करें**

Aspose.Slides का उपयोग करके, आप टेक्स्ट फ्रेम की प्रभावी प्रॉपर्टीज़ प्राप्त कर सकते हैं। इंटरफ़ेस [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITextFrameFormatEffectiveData) में प्रभावी टेक्स्ट फ्रेम फ़ॉर्मेटिंग प्रॉपर्टीज़ शामिल हैं।

निम्नलिखित कोड नमूना दिखाता है कि प्रभावी टेक्स्ट फ्रेम फ़ॉर्मेटिंग प्रॉपर्टीज़ कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड पर पहला शAPE एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IAutoShape) है जिसमें एक टेक्स्ट फ़्रेम है।

```java
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

## **टेक्स्ट स्टाइल की प्रभावी प्रॉपर्टीज़ प्राप्त करें**

Aspose.Slides का उपयोग करके, आप टेक्स्ट स्टाइल की प्रभावी प्रॉपर्टीज़ प्राप्त कर सकते हैं। इंटरफ़ेस [ITextStyleEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITextStyleEffectiveData) में प्रभावी टेक्स्ट स्टाइल प्रॉपर्टीज़ शामिल हैं।

निम्नलिखित कोड नमूना दिखाता है कि प्रभावी टेक्स्ट स्टाइल प्रॉपर्टीज़ कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड पर पहला शAPE एक [IAutoShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IAutoShape) है जिसमें एक टेक्स्ट फ़्रेम है।

```java
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

## **टेबल के लिए प्रभावी फ़िल फॉर्मेट प्राप्त करें**

Aspose.Slides में, आप विभिन्न टेबल भागों के लिए प्रभावी फ़िल फ़ॉर्मेटिंग प्राप्त कर सकते हैं। इंटरफ़ेस [IFillFormatEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IFillFormatEffectiveData) में प्रभावी फ़िल फ़ॉर्मेटिंग प्रॉपर्टीज़ शामिल हैं। सेल फ़ॉर्मेटिंग का प्राथमिकता रो फ़ॉर्मेटिंग से अधिक है, रो फ़ॉर्मेटिंग का कॉलम फ़ॉर्मेटिंग से अधिक, और कॉलम फ़ॉर्मेटिंग का पूरे टेबल फ़ॉर्मेटिंग से अधिक है।

परिणामस्वरूप, टेबल सेल को ड्रॉ करने के लिए [ICellFormatEffectiveData](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ICellFormatEffectiveData) प्रॉपर्टीज़ का उपयोग किया जाता है। निम्नलिखित कोड नमूना दिखाता है कि विभिन्न टेबल भागों के लिए प्रभावी फ़िल फ़ॉर्मेटिंग कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड पर पहला शAPE एक [ITable](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ITable) है।

```java
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

**`getEffective` एक स्नैपशॉट वापस करता है?**

हमेशा नहीं। प्रभावी डेटा वह गणना किया गया फ़ॉर्मेटिंग दर्शाता है जो विरासत लागू होने के बाद प्राप्त होता है, लेकिन कुछ प्रभावी डेटा ऑब्जेक्ट्स को आंतरिक रूप से कैश किया जा सकता है। आगे का `getEffective` कॉल फ़ॉर्मेटिंग को पुनः गणना कर सकता है और कैश्ड डेटा को रीफ़्रेश कर सकता है, इसलिए पहले प्राप्त किए गए ऑब्जेक्ट को स्थायी स्नैपशॉट के रूप में नहीं माना जाना चाहिए।

**मुझे प्रभावी प्रॉपर्टीज़ फिर से कब पढ़नी चाहिए?**

स्थानीय फ़ॉर्मेटिंग, पैरेंट स्टाइल्स, लेआउट फ़ॉर्मेटिंग, मास्टर फ़ॉर्मेटिंग या प्रेज़ेंटेशन-स्तर के डिफॉल्ट बदलने के बाद फिर से `getEffective` कॉल करें। अगला कॉल फ़ॉर्मेटिंग पदानुक्रम का पुनर्मूल्यांकन करता है और वर्तमान प्रभावी परिणाम लौटाता है।

**क्या लेआउट/मास्टर स्लाइड को बदलना या हटाना उन प्रभावी प्रॉपर्टीज़ को प्रभावित करता है जो पहले ही प्राप्त की गई हैं?**

हाँ, लेकिन परिवर्तन अगली `getEffective` कॉल पर दिखाया जाता है। यदि पैरेंट फ़ॉर्मेटिंग स्रोत बदलता या हटता है, तो पहले प्राप्त किया गया प्रभावी डेटा पुराना हो सकता है। जब `getEffective` फिर से कॉल किया जाता है, तो Aspose.Slides फ़ॉर्मेटिंग ट्री का पुनर्मूल्यांकन करता है और परिणामस्वरूप फ़ॉन्ट, रंग, आकार या अन्य मान बदल सकते हैं।

**क्या मैं प्रभावी डेटा ऑब्जेक्ट्स के माध्यम से मानों को संशोधित कर सकता हूँ?**

नहीं। प्रभावी डेटा ऑब्जेक्ट्स गणना किए गए मान प्रदान करते हैं। स्थानीय फ़ॉर्मेटिंग ऑब्जेक्ट्स में परिवर्तन करें, और फिर प्रभावी मानों को फिर से प्राप्त करें।

**यदि कोई प्रॉपर्टी शAPE स्तर पर, न लेआउट/मास्टर में, न ही वैश्विक सेटिंग्स में सेट नहीं है तो क्या होता है?**

प्रभावी मान डिफ़ॉल्ट मेकेनिज़्म द्वारा निर्धारित किया जाता है, जिसमें PowerPoint और Aspose.Slides के डिफ़ॉल्ट शामिल होते हैं। वह समाधान किया गया मान वर्तमान प्रभावी डेटा का हिस्सा बन जाता है।

**क्या प्रभावी फ़ॉन्ट मान से मैं बता सकता हूँ कि आकार या फ़ॉन्ट किस स्तर से आया है?**

सीधे नहीं। प्रभावी डेटा अंतिम मान लौटाता है। स्रोत पता करने के लिए, भाग, पैराग्राफ, टेक्स्ट फ्रेम, और लेआउट, मास्टर तथा प्रेज़ेंटेशन स्तर पर टेक्स्ट स्टाइल्स में स्थानीय मानों की जाँच करें कि पहला स्पष्ट परिभाषा कहाँ है।

**कभी-कभी प्रभावी मान स्थानीय मानों से समान क्यों दिखते हैं?**

क्योंकि स्थानीय मान अंत में अंतिम हो जाता है (उच्च स्तर की विरासत की आवश्यकता नहीं थी)। ऐसे मामलों में, प्रभावी मान स्थानीय मान के समान होता है।

**मुझे प्रभावी प्रॉपर्टीज़ कब उपयोग करनी चाहिए, और कब केवल स्थानीय प्रॉपर्टीज़ के साथ काम करना चाहिए?**

सभी विरासत लागू होने के बाद "जैसे प्रदर्शित हुआ" परिणाम चाहिए हो तो प्रभावी डेटा का उपयोग करें, जैसे रंग, इन्डेंट या आकार को संरेखित करने के लिए। यदि आपको बाद में फ़ॉर्मेटिंग बदलने के बावजूद उन मानों को सुरक्षित रखना है, तो आवश्यक प्रॉपर्टीज़ को अपने ऑब्जेक्ट में कॉपी करें। यदि आपको किसी विशिष्ट स्तर पर फ़ॉर्मेटिंग बदलनी है, तो स्थानीय प्रॉपर्टीज़ को संशोधित करें और फिर, यदि आवश्यक हो, परिणाम सत्यापित करने के लिए प्रभावी डेटा को फिर से पढ़ें।