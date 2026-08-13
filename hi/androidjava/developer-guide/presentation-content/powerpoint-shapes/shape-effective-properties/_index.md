---
title: Android पर प्रस्तुतियों से आकार के प्रभावी गुण प्राप्त करें
linktitle: प्रभावी गुण
type: docs
weight: 50
url: /hi/androidjava/shape-effective-properties/
keywords:
- आकार गुण
- कैमरा गुण
- लाइट रिग
- बीवेल आकार
- टेक्स्ट फ्रेम
- टेक्स्ट शैली
- फ़ॉन्ट ऊँचाई
- भराव स्वरूप
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "जाने कैसे Aspose.Slides for Android Java के माध्यम से सटीक PowerPoint रेंडरिंग के लिये प्रभावी आकार गुणों की गणना और लागू करता है।"
---
## **अवलोकन**

यह विषय **स्थानीय** और **प्रभावी** गुणों के बीच अंतर को समझाता है। स्थानीय मान वे होते हैं जो किसी विशिष्ट स्वरूपण स्तर पर सीधे सेट किए जाते हैं, जैसे:

1. स्लाइड पर भाग (portion) गुण।
1. लेआउट या मास्टर स्लाइड पर प्रोटोटाइप आकार के टेक्स्ट शैलियाँ, जब भाग के टेक्स्ट फ्रेम आकार में यह मौजूद हो।
1. प्रस्तुति में वैश्विक टेक्स्ट सेटिंग्स।

स्थानीय मान किसी भी स्तर पर परिभाषित या छोड़ दिए जा सकते हैं। जब Aspose.Slides को अंतिम “जैसे प्रस्तुत किया गया” स्वरूपण चाहिए होता है, तो यह विरासत श्रृंखला को हल करता है और **प्रभावी** मान लौटाता है। आप इन्हें स्थानीय स्वरूपण वस्तु पर `getEffective()` मेथड कॉल करके प्राप्त कर सकते हैं।

निम्न उदाहरण दिखाता है कि प्रभावी मान कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड के पहले आकार में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) है जिसमें टेक्स्ट फ्रेम और कम से कम एक भाग है।

```java
import com.aspose.slides.*;

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

{{% alert color="info" %}}
प्रभावी स्वरूपण डेटा विरासत लागू करने के बाद गणना किए गए मौजूदा स्वरूपण को दर्शाता है। वर्तमान कार्यान्वयन में, कुछ प्रभावी डेटा ऑब्जेक्ट, जैसे कि [IPortionFormatEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iportionformateffectivedata/), को आंतरिक रूप से कैश किया जा सकता है। पैरेंट या विरासतित स्वरूपण बदलने के बाद फिर से `getEffective()` कॉल करने से कैश्ड डेटा रिफ्रेश हो सकता है, और पहले प्राप्त ऑब्जेक्ट अब पहले की स्थिति को प्रतिबिंबित नहीं करेगा। यदि आपको बाद में पुन: उपयोग के लिए प्रभावी मान सुरक्षित रखने हैं, तो फ़ॉन्ट ऊँचाई, भराव रंग, फ़ॉन्ट शैली या संरेखण जैसी आवश्यक गुणों को अपने स्वयं के डेटा वस्तु में कॉपी करें।
{{% /alert %}}

## **कैमरा के प्रभावी गुण प्राप्त करें**

Aspose.Slides आपको कैमरा के प्रभावी गुण प्राप्त करने की सुविधा देता है। [ICameraEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icameraeffectivedata/) इंटरफ़ेस एक अपरिवर्तनीय ऑब्जेक्ट का प्रतिनिधित्व करता है जिसमें प्रभावी कैमरा गुण होते हैं। एक [ICameraEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icameraeffectivedata/) उदाहरण [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformateffectivedata/) के माध्यम से उजागर किया जाता है, जो [IThreeDFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/) के लिए प्रभावी मान प्रदान करता है।

निम्न कोड सैंपल दिखाता है कि कैमरा के प्रभावी गुण कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड के पहले आकार में 3D स्वरूपण है।

```java
import com.aspose.slides.*;

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

Aspose.Slides आपको लाइट रिग के प्रभावी गुण प्राप्त करने की सुविधा देता है। [ILightRigEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilightrigeffectivedata/) इंटरफ़ेस एक अपरिवर्तनीय ऑब्जेक्ट का प्रतिनिधित्व करता है जिसमें प्रभावी लाइट रिग गुण होते हैं। एक [ILightRigEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilightrigeffectivedata/) उदाहरण [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformateffectivedata/) के माध्यम से उजागर किया जाता है, जो [IThreeDFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/) के लिए प्रभावी मान प्रदान करता है।

निम्न कोड सैंपल दिखाता है कि लाइट रिग के प्रभावी गुण कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड के पहले आकार में 3D स्वरूपण है।

```java
import com.aspose.slides.*;

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

Aspose.Slides आपको आकार के बीवेल के प्रभावी गुण प्राप्त करने की सुविधा देता है। [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapebeveleffectivedata/) इंटरफ़ेस एक अपरिवर्तनीय ऑब्जेक्ट का प्रतिनिधित्व करता है जिसमें आकार के चेहरे‑रिलीज़ गुण होते हैं। एक [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapebeveleffectivedata/) उदाहरण [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformateffectivedata/) के माध्यम से उजागर किया जाता है, जो [IThreeDFormat](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ithreedformat/) के लिए प्रभावी मान प्रदान करता है।

निम्न कोड सैंपल दिखाता है कि आकार के शीर्ष बीवेल के प्रभावी गुण कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड के पहले आकार में 3D स्वरूपण है।

```java
import com.aspose.slides.*;

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

Aspose.Slides का उपयोग करके आप टेक्स्ट फ्रेम के प्रभावी गुण प्राप्त कर सकते हैं। [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextframeformateffectivedata/) इंटरफ़ेस प्रभावी टेक्स्ट फ्रेम स्वरूपण गुणों को समाहित करता है।

निम्न कोड सैंपल दिखाता है कि प्रभावी टेक्स्ट फ्रेम स्वरूपण गुण कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड के पहले आकार में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) है जिसमें टेक्स्ट फ्रेम है।

```java
import com.aspose.slides.*;

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

## **टेक्स्ट शैली के प्रभावी गुण प्राप्त करें**

Aspose.Slides का उपयोग करके आप टेक्स्ट शैली के प्रभावी गुण प्राप्त कर सकते हैं। [ITextStyleEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itextstyleeffectivedata/) इंटरफ़ेस प्रभावी टेक्स्ट शैली गुणों को समाहित करता है।

निम्न कोड सैंपल दिखाता है कि प्रभावी टेक्स्ट शैली गुण कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड के पहले आकार में एक [IAutoShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iautoshape/) है जिसमें टेक्स्ट फ्रेम है।

```java
import com.aspose.slides.*;

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

Aspose.Slides का उपयोग करके आप प्रभावी फ़ॉन्ट ऊँचाई प्राप्त कर सकते हैं। निम्न कोड दर्शाता है कि विभिन्न प्रस्तुति संरचना स्तरों पर स्थानीय फ़ॉन्ट ऊँचाई मान सेट करने के बाद भाग की प्रभावी फ़ॉन्ट ऊँचाई कैसे बदलती है।

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

## **टेबल के लिए प्रभावी भराव स्वरूपण प्राप्त करें**

Aspose.Slides का उपयोग करके आप विभिन्न टेबल भागों के लिए प्रभावी भराव स्वरूपण प्राप्त कर सकते हैं। [IFillFormatEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifillformateffectivedata/) इंटरफ़ेस प्रभावी भराव स्वरूपण गुणों को समाहित करता है। सेल स्वरूपण का प्राथमिकता पंक्ति स्वरूपण से अधिक होती है, पंक्ति स्वरूपण का प्राथमिकता कॉलम स्वरूपण से अधिक होती है, और कॉलम स्वरूपण का प्राथमिकता पूरी‑टेबल स्वरूपण से अधिक होती है।

परिणामस्वरूप, [ICellFormatEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icellformateffectivedata/) गुणों का उपयोग टेबल सेल को रेंडर करने के लिए किया जाता है। निम्न कोड सैंपल दिखाता है कि विभिन्न टेबल भागों के लिए प्रभावी भराव स्वरूपण कैसे प्राप्त करें। यह मानता है कि पहली स्लाइड के पहले आकार में एक [ITable](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/itable/) है।

```java
import com.aspose.slides.*;

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

### क्या `getEffective()` एक स्नैपशॉट लौटाता है?

हमेशा नहीं। प्रभावी डेटा विरासत लागू करने के बाद गणना किए गए स्वरूपण को दर्शाता है, लेकिन कुछ प्रभावी डेटा ऑब्जेक्ट आंतरिक रूप से कैश किए जा सकते हैं। बाद का `getEffective()` कॉल स्वरूपण को पुनः गणना कर सकता है और कैश्ड डेटा को रिफ्रेश कर सकता है, इसलिए पहले प्राप्त ऑब्जेक्ट को स्थायी स्नैपशॉट के रूप में नहीं माना जाना चाहिए।

### मुझे प्रभावी गुणों को फिर से कब पढ़ना चाहिए?

स्थानीय स्वरूपण, पैरेंट शैलियों, लेआउट स्वरूपण, मास्टर स्वरूपण या प्रस्तुति‑स्तर की डिफ़ॉल्ट सेटिंग्स बदलने के बाद `getEffective()` फिर से कॉल करें। अगला कॉल स्वरूपण पदानुक्रम को पुनः मूल्यांकन करता है और वर्तमान प्रभावी परिणाम लौटाता है।

### क्या लेआउट/मास्टर स्लाइड को बदलना या हटाना उस समय प्राप्त प्रभावी गुणों को प्रभावित करता है?

हाँ, लेकिन परिवर्तन अगले `getEffective()` कॉल पर प्रतिबिंबित होगा। यदि पैरेंट स्वरूपण स्रोत बदल या हटाया जाता है, तो पहले प्राप्त प्रभावी डेटा पुराना हो सकता है। एक बार फिर `getEffective()` कॉल करने पर Aspose.Slides स्वरूपण वृक्ष को पुनः मूल्यांकन करता है और फ़ॉन्ट, रंग, आकार या अन्य मान बदल सकते हैं।

### क्या मैं प्रभावी डेटा ऑब्जेक्ट के माध्यम से मान बदल सकता हूँ?

नहीं। प्रभावी डेटा ऑब्जेक्ट गणना किए गए मान प्रदान करते हैं। स्थानीय स्वरूपण वस्तुओं में परिवर्तन करें, फिर प्रभावी मान फिर से प्राप्त करें।

### यदि कोई गुण आकार स्तर, लेआउट/मास्टर या वैश्विक सेटिंग्स में नहीं सेट है तो क्या होता है?

प्रभावी मान डिफ़ॉल्ट तंत्र द्वारा निर्धारित होता है, जिसमें PowerPoint और Aspose.Slides के डिफ़ॉल्ट शामिल होते हैं। यह निर्धारित मान वर्तमान प्रभावी डेटा का हिस्सा बन जाता है।

### क्या मैं प्रभावी फ़ॉन्ट मान से पता लगा सकता हूँ कि कौन से स्तर ने आकार या फ़ॉन्ट प्रकार प्रदान किया?

सीधे नहीं। प्रभावी डेटा अंतिम मान लौटाता है। स्रोत पता लगाने के लिए भाग, पैराग्राफ, टेक्स्ट फ्रेम और लेआउट, मास्टर तथा प्रस्तुति स्तर पर स्थानीय मानों की जाँच करें कि पहली स्पष्ट परिभाषा कहाँ मिली।

### कभी‑कभी प्रभावी मान स्थानीय मान के समान क्यों दिखते हैं?

क्योंकि स्थानीय मान अंततः अंतिम हो गया (ऊंचे‑स्तर की विरासत की आवश्यकता नहीं रही)। ऐसे मामलों में प्रभावी मान स्थानीय मान के बराबर होता है।

### मैं प्रभावी गुणों का उपयोग कब करूँ, और केवल स्थानीय गुणों के साथ कब काम करूँ?

जब आपको सभी विरासत लागू करने के बाद “जैसे प्रस्तुत किया गया” परिणाम चाहिए, जैसे रंग, इंडेंट या आकार को संरेखित करना, तभी प्रभावी डेटा उपयोग करें। यदि आपको बाद में स्वरूपण परिवर्तन के बावजूद उन मानों को सुरक्षित रखना है, तो आवश्यक गुणों को अपने स्वयं के ऑब्जेक्ट में कॉपी करें। यदि आपको किसी विशिष्ट स्तर पर स्वरूपण बदलना है, तो स्थानीय गुणों को संशोधित करें और आवश्यकता होने पर प्रभावी डेटा फिर से पढ़ें ताकि परिणाम सत्यापित हो सके।