---
title: Android पर प्रस्तुतीकरणों से आकार के प्रभावी गुण प्राप्त करें
linktitle: प्रभावी गुण
type: docs
weight: 50
url: /hi/androidjava/shape-effective-properties/
keywords:
- आकार गुण
- कैमरा गुण
- प्रकाश रिग
- बीवेल आकार
- टेक्स्ट फ्रेम
- टेक्स्ट शैली
- फ़ॉन्ट ऊँचाई
- भरन स्वरूप
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "जानिए कैसे Aspose.Slides for Android जावा के माध्यम से सटीक PowerPoint रेंडरिंग के लिए प्रभावी आकार गुणों की गणना और अनुप्रयोग करता है।"
---
## **अवलोकन**

यह विषय **स्थानीय** और **प्रभावी** गुणों के बीच अंतर समझाता है। स्थानीय मान वे मान हैं जो सीधे किसी विशिष्ट स्वरूप स्तर पर सेट किए जाते हैं, जैसे:

1. स्लाइड पर भाग गुण।
1. लेआउट या मास्टर स्लाइड पर प्रोटोटाइप आकार के टेक्स्ट शैलियों, जब भाग के टेक्स्ट फ्रेम आकार में एक हो।
1. प्रस्तुति में वैश्विक टेक्स्ट सेटिंग्स।

स्थानीय मान किसी भी स्तर पर परिभाषित या छोड़े जा सकते हैं। जब Aspose.Slides को अंतिम "जैसे रेंडर किया गया" स्वरूपण चाहिए, तो यह विरासत शृंखला को हल करता है और **प्रभावी** मान लौटाता है। आप उन्हें स्थानीय स्वरूप वस्तु पर `getEffective()` विधि को कॉल करके प्राप्त कर सकते हैं।

निम्न उदाहरण दिखाता है कि प्रभावी मान कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड पर पहला आकार एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) है जिसमें एक टेक्स्ट फ्रेम और कम से कम एक भाग है।

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrame textFrame = shape.getTextFrame();
    ITextFrameFormatEffectiveData effectiveTextFrameFormat = textFrame.getTextFrameFormat().getEffective();

    IPortion portion = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0);
    IPortionFormatEffectiveData effectivePortionFormat = portion.getPortionFormat().getEffective();
} finally {
    presentation.dispose();
}
```

{{% alert color="primary" %}}
प्रभावी स्वरूप डेटा विरासत लागू होने के बाद वर्तमान गणना किए गए स्वरूप को दर्शाता है। वर्तमान कार्यान्वयन में, कुछ प्रभावी डेटा ऑब्जेक्ट, जैसे कि [IPortionFormatEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportionformateffectivedata/), आंतरिक रूप से कैश किए जा सकते हैं। फ़ॉर्मेटिंग में पैरेंट या विरासतित बदलाव करने के बाद `getEffective()` को फिर से कॉल करने से कैश्ड डेटा रीफ़्रेश हो जाता है, और पहले प्राप्त ऑब्जेक्ट अब पूर्व स्थिति का प्रतिनिधित्व नहीं कर सकता। यदि आपको प्रभावी मानों को बाद में पुनः उपयोग के लिए सुरक्षित रखना है, तो आवश्यक गुण, जैसे फ़ॉन्ट ऊँचाई, भरने का रंग, फ़ॉन्ट शैली, या संरेखण, को अपने स्वयं के डेटा ऑब्जेक्ट में कॉपी करें।
{{% /alert %}}

## **कैमरे के प्रभावी गुण प्राप्त करें**

Aspose.Slides आपको कैमरे के प्रभावी गुण प्राप्त करने की अनुमति देता है। इंटरफ़ेस [ICameraEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icameraeffectivedata/) एक अपरिवर्तनीय ऑब्जेक्ट का प्रतिनिधित्व करता है जिसमें प्रभावी कैमरा गुण होते हैं। एक [ICameraEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icameraeffectivedata/) का उदाहरण [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformateffectivedata/) के माध्यम से एक्सपोज़ किया जाता है, जो [IThreeDFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/) के लिए प्रभावी मान प्रदान करता है।

निम्न कोड नमूना दिखाता है कि कैमरे के लिए प्रभावी गुण कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड पर पहला आकार 3D स्वरूपण रखता है।

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ICameraEffectiveData cameraEffectiveData = threeDEffectiveData.getCamera();

    System.out.println("= Effective camera properties =");
    System.out.println("Type: " + cameraEffectiveData.getCameraType());
    System.out.println("Field of view: " + cameraEffectiveData.getFieldOfViewAngle());
    System.out.println("Zoom: " + cameraEffectiveData.getZoom());
} finally {
    presentation.dispose();
}
```

## **लाइट रिग के प्रभावी गुण प्राप्त करें**

Aspose.Slides आपको लाइट रिग के प्रभावी गुण प्राप्त करने की अनुमति देता है। इंटरफ़ेस [ILightRigEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilightrigeffectivedata/) एक अपरिवर्तनीय ऑब्जेक्ट का प्रतिनिधित्व करता है जिसमें प्रभावी लाइट रिग गुण होते हैं। एक [ILightRigEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilightrigeffectivedata/) का उदाहरण [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformateffectivedata/) के माध्यम से एक्सपोज़ किया जाता है, जो [IThreeDFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/) के लिए प्रभावी मान प्रदान करता है।

निम्न कोड नमूना दिखाता है कि लाइट रिग के लिए प्रभावी गुण कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड पर पहला आकार 3D स्वरूपण रखता है।

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    ILightRigEffectiveData lightRigEffectiveData = threeDEffectiveData.getLightRig();

    System.out.println("= Effective light rig properties =");
    System.out.println("Type: " + lightRigEffectiveData.getLightType());
    System.out.println("Direction: " + lightRigEffectiveData.getDirection());
} finally {
    presentation.dispose();
}
```

## **बीवेल आकार के प्रभावी गुण प्राप्त करें**

Aspose.Slides आपको आकार बीवेल के प्रभावी गुण प्राप्त करने की अनुमति देता है। इंटरफ़ेस [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapebeveleffectivedata/) एक अपरिवर्तनीय ऑब्जेक्ट का प्रतिनिधित्व करता है जिसमें आकार के लिए प्रभावी फेस-रिलीफ़ गुण होते हैं। एक [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapebeveleffectivedata/) का उदाहरण [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformateffectivedata/) के माध्यम से एक्सपोज़ किया जाता है, जो [IThreeDFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/) के लिए प्रभावी मान प्रदान करता है।

निम्न कोड नमूना दिखाता है कि आकार के टॉप बीवेल के लिए प्रभावी गुण कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड पर पहला आकार 3D स्वरूपण रखता है।

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    IThreeDFormatEffectiveData threeDEffectiveData = shape.getThreeDFormat().getEffective();
    IShapeBevelEffectiveData bevelTopEffectiveData = threeDEffectiveData.getBevelTop();

    System.out.println("= Effective shape's top face relief properties =");
    System.out.println("Type: " + bevelTopEffectiveData.getBevelType());
    System.out.println("Width: " + bevelTopEffectiveData.getWidth());
    System.out.println("Height: " + bevelTopEffectiveData.getHeight());
} finally {
    presentation.dispose();
}
```

## **टेक्स्ट फ्रेम के प्रभावी गुण प्राप्त करें**

Aspose.Slides का उपयोग करके, आप टेक्स्ट फ्रेम के प्रभावी गुण प्राप्त कर सकते हैं। इंटरफ़ेस [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframeformateffectivedata/) प्रभावी टेक्स्ट फ्रेम स्वरूपण गुणों को शामिल करता है।

निम्न कोड नमूना दिखाता है कि प्रभावी टेक्स्ट फ्रेम स्वरूपण गुण कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड पर पहला आकार एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) है जिसमें टेक्स्ट फ्रेम है।

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextFrameFormatEffectiveData effectiveTextFrameFormat = shape.getTextFrame().getTextFrameFormat().getEffective();

    System.out.println("Anchoring type: " + effectiveTextFrameFormat.getAnchoringType());
    System.out.println("Autofit type: " + effectiveTextFrameFormat.getAutofitType());
    System.out.println("Text vertical type: " + effectiveTextFrameFormat.getTextVerticalType());
    System.out.println("Margins");
    System.out.println("   Left: " + effectiveTextFrameFormat.getMarginLeft());
    System.out.println("   Top: " + effectiveTextFrameFormat.getMarginTop());
    System.out.println("   Right: " + effectiveTextFrameFormat.getMarginRight());
    System.out.println("   Bottom: " + effectiveTextFrameFormat.getMarginBottom());
} finally {
    presentation.dispose();
}
```

## **टेक्स्ट स्टाइल के प्रभावी गुण प्राप्त करें**

Aspose.Slides का उपयोग करके, आप टेक्स्ट स्टाइल के प्रभावी गुण प्राप्त कर सकते हैं। इंटरफ़ेस [ITextStyleEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextstyleeffectivedata/) प्रभावी टेक्स्ट स्टाइल गुणों को शामिल करता है।

निम्न कोड नमूना दिखाता है कि प्रभावी टेक्स्ट स्टाइल गुण कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड पर पहला आकार एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) है जिसमें टेक्स्ट फ्रेम है।

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape)slide.getShapes().get_Item(0);

    ITextStyleEffectiveData effectiveTextStyle = shape.getTextFrame().getTextFrameFormat().getTextStyle().getEffective();
    int levelCount = 9;

    for (int levelIndex = 0; levelIndex < levelCount; levelIndex++) {
        IParagraphFormatEffectiveData effectiveStyleLevel = effectiveTextStyle.getLevel(levelIndex);

        System.out.println("= Effective paragraph formatting for style level #" + levelIndex + " =");

        System.out.println("Depth: " + effectiveStyleLevel.getDepth());
        System.out.println("Indent: " + effectiveStyleLevel.getIndent());
        System.out.println("Alignment: " + effectiveStyleLevel.getAlignment());
        System.out.println("Font alignment: " + effectiveStyleLevel.getFontAlignment());
    }
} finally {
    presentation.dispose();
}
```

## **प्रभावी फ़ॉन्ट ऊँचाई मान प्राप्त करें**

Aspose.Slides का उपयोग करके, आप प्रभावी फ़ॉन्ट ऊँचाई प्राप्त कर सकते हैं। निम्न कोड दिखाता है कि विभिन्न प्रस्तुति संरचना स्तरों पर स्थानीय फ़ॉन्ट ऊँचाई मान सेट करने के बाद एक भाग की प्रभावी फ़ॉन्ट ऊँचाई कैसे बदलती है।

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

## **टेबल के लिए प्रभावी भराव स्वरूप प्राप्त करें**

Aspose.Slides का उपयोग करके, आप विभिन्न टेबल भागों के लिए प्रभावी भराव स्वरूप प्राप्त कर सकते हैं। इंटरफ़ेस [IFillFormatEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifillformateffectivedata/) प्रभावी भराव स्वरूप गुणों को शामिल करता है। सेल स्वरूपण की प्राथमिकता पंक्ति स्वरूपण से अधिक होती है, पंक्ति स्वरूपण की प्राथमिकता कॉलम स्वरूपण से अधिक होती है, और कॉलम स्वरूपण की प्राथमिकता पूरे टेबल स्वरूपण से अधिक होती है।

परिणामस्वरूप, टेबल सेल को ड्रॉ करने के लिए [ICellFormatEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icellformateffectivedata/) गुणों का उपयोग किया जाता है। निम्न कोड नमूना दिखाता है कि विभिन्न टेबल भागों के लिए प्रभावी भराव स्वरूप कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड पर पहला आकार एक [ITable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itable/) है।

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ITable table = (ITable)slide.getShapes().get_Item(0);

    IRow row = table.getRows().get_Item(0);
    IColumn column = table.getColumns().get_Item(0);
    ICell cell = table.get_Item(0, 0);

    IFillFormatEffectiveData tableFillFormatEffective = table.getTableFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData rowFillFormatEffective = row.getRowFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData columnFillFormatEffective = column.getColumnFormat().getEffective().getFillFormat();
    IFillFormatEffectiveData cellFillFormatEffective = cell.getCellFormat().getEffective().getFillFormat();
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या `getEffective()` एक स्नैपशॉट लौटाता है?**

हमेशा नहीं। प्रभावी डेटा विरासत लागू होने के बाद गणना किए गए स्वरूप को दर्शाता है, लेकिन कुछ प्रभावी डेटा ऑब्जेक्ट आंतरिक रूप से कैश किए जा सकते हैं। बाद में `getEffective()` कॉल स्वरूप को पुनः गणना कर सकती है और कैश्ड डेटा को रीफ़्रेश कर सकती है, इसलिए पहले प्राप्त ऑब्जेक्ट को स्थायी स्नैपशॉट के रूप में नहीं माना जाना चाहिए।

**मुझे प्रभावी गुण फिर से कब पढ़ने चाहिए?**

`getEffective()` को स्थानीय स्वरूपण, पैरेंट शैलियों, लेआउट स्वरूपण, मास्टर स्वरूपण, या प्रस्तुति-स्तर के डिफ़ॉल्ट्स को बदलने के बाद फिर से कॉल करें। अगली कॉल स्वरूपण पदानुक्रम को पुनः मूल्यांकित करती है और वर्तमान प्रभावी परिणाम लौटाती है।

**क्या लेआउट/मास्टर स्लाइड को बदलने या हटाने से पहले प्राप्त प्रभावी गुण प्रभावित होते हैं?**

हाँ, लेकिन परिवर्तन अगली `getEffective()` कॉल पर परिलक्षित होता है। यदि कोई पैरेंट स्वरूपण स्रोत बदला या हटाया जाता है, तो पहले प्राप्त प्रभावी डेटा पुराना हो सकता है। जब `getEffective()` फिर से कॉल किया जाता है, तो Aspose.Slides स्वरूपण वृक्ष को पुनः मूल्यांकित करता है और resulting फ़ॉन्ट, रंग, आकार, या अन्य मान बदल सकते हैं।

**क्या मैं प्रभावी डेटा ऑब्जेक्ट्स के माध्यम से मान संशोधित कर सकता हूँ?**

नहीं। प्रभावी डेटा ऑब्जेक्ट्स गणना किए गए मानों को दर्शाते हैं। स्थानीय स्वरूपण वस्तुओं में परिवर्तन करें, और फिर प्रभावी मानों को दोबारा प्राप्त करें।

**यदि कोई गुण आकार स्तर पर, लेआउट/मास्टर में, या वैश्विक सेटिंग्स में सेट नहीं है तो क्या होता है?**

प्रभावी मान डिफ़ॉल्ट तंत्र द्वारा निर्धारित किया जाता है, जिसमें PowerPoint और Aspose.Slides के डिफ़ॉल्ट शामिल हैं। यह प्राप्त मान वर्तमान प्रभावी डेटा का हिस्सा बन जाता है।

**क्या प्रभावी फ़ॉन्ट मान से मैं तय कर सकता हूँ कि कौन से स्तर ने आकार या टाइपफ़ेस प्रदान किया?**

सीधे नहीं। प्रभावी डेटा अंतिम मान लौटाता है। स्रोत जानने के लिए, भाग, पैराग्राफ, टेक्स्ट फ्रेम, और लेआउट, मास्टर और प्रस्तुति स्तर पर टेक्स्ट शैलियों में स्थानीय मानों की जाँच करें कि पहली स्पष्ट परिभाषा कहाँ हुई।

**कभी-कभी प्रभावी मान स्थानीय मानों जैसे ही क्यों दिखते हैं?**

क्योंकि स्थानीय मान अंत में अंतिम हो गया (उच्च स्तर की विरासत की आवश्यकता नहीं थी)। ऐसे मामलों में प्रभावी मान स्थानीय मान के समान होता है।

**मुझे प्रभावी गुण कब उपयोग करने चाहिए, और कब केवल स्थानीय गुणों के साथ काम करना चाहिए?**

सभी विरासत लागू होने के बाद आपको "जैसे रेंडर किया गया" परिणाम चाहिए, जैसे रंग, इंडेंट या आकार को संरेखित करने के हेतु, तब प्रभावी डेटा का उपयोग करें। यदि आप इन मानों को बाद के स्वरूपण परिवर्तनों से स्वतंत्र रूप से सुरक्षित रखना चाहते हैं, तो आवश्यक गुणों को अपने स्वयं के ऑब्जेक्ट में कॉपी करें। यदि आपको किसी विशिष्ट स्तर पर स्वरूपण बदलना है, तो स्थानीय गुणों को संशोधित करें और फिर आवश्यकता अनुसार परिणाम की पुष्टि के लिए प्रभावी डेटा दोबारा पढ़ें।