---
title: एंड्रॉयड पर प्रस्तुति थीम प्रबंधित करें
linktitle: प्रस्तुति थीम
type: docs
weight: 10
url: /hi/androidjava/presentation-theme/
keywords:
- PowerPoint थीम
- प्रस्तुति थीम
- स्लाइड थीम
- थीम सेट करें
- थीम बदलें
- थीम प्रबंधित करें
- थीम रंग
- अतिरिक्त पैलेट
- थीम फ़ॉन्ट
- थीम शैली
- थीम प्रभाव
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "एंड्रॉयड के लिए Aspose.Slides में मास्टर प्रस्तुति थीम, Java के माध्यम से, पावरपॉइंट फ़ाइलों को निरंतर ब्रांडिंग के साथ बनाने, अनुकूलित करने और परिवर्तित करने के लिए।"
---
## **परिचय**

एक प्रस्तुति थीम डिजाइन तत्वों की विशेषताओं को परिभाषित करती है। जब आप एक प्रस्तुति थीम चुनते हैं, तो आप मूल रूप से दृश्य तत्वों और उनकी विशेषताओं का एक विशिष्ट सेट चुन रहे होते हैं।

PowerPoint में, एक थीम में रंग, [फ़ॉन्ट](/slides/hi/androidjava/powerpoint-fonts/), [पृष्ठभूमि शैलियाँ](/slides/hi/androidjava/presentation-background/), और प्रभाव शामिल होते हैं।

![theme-constituents](theme-constituents.png)

## **थीम रंग बदलें**

PowerPoint थीम स्लाइड के विभिन्न तत्वों के लिए एक विशिष्ट रंगों के सेट का उपयोग करती है। यदि आपको रंग पसंद नहीं हैं, तो आप थीम के लिए नए रंग लागू करके उन्हें बदल सकते हैं। नया थीम रंग चुनने के लिए, Aspose.Slides [SchemeColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/SchemeColor) एन्‍युमेरेशन के तहत मान प्रदान करता है।

यह Java कोड दिखाता है कि कैसे एक थीम के लिए एक्सेंट रंग बदलें:
```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

आप इस प्रकार परिणामी रंग के प्रभावी मान को निर्धारित कर सकते हैं:
```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

    Color effectiveColor = fillEffective.getSolidFillColor();

    System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]",
            effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
} finally {
    if (pres != null) pres.dispose();
}
```

रंग परिवर्तन ऑपरेशन को और दर्शाने के लिए, हम एक और तत्व बनाते हैं और उसे एक्सेंट रंग (प्रारंभिक ऑपरेशन से) सौंपते हैं। फिर हम थीम में रंग बदलते हैं:
```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

    otherShape.getFillFormat().setFillType(FillType.Solid);

    otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
} finally {
    if (pres != null) pres.dispose();
}
```

नया रंग दोनों तत्वों पर स्वचालित रूप से लागू हो जाता है।

### **अतिरिक्त पैलेट से थीम रंग सेट करें**

जब आप मुख्य थीम रंग(1) पर ल्यूमिनेंस परिवर्तनों को लागू करते हैं, तो अतिरिक्त पैलेट(2) से रंग बनते हैं। फिर आप उन थीम रंगों को सेट और प्राप्त कर सकते हैं।

![additional-palette-colors](additional-palette-colors.png)

**1** - मुख्य थीम रंग

**2** - अतिरिक्त पैलेट से रंग।

यह Java कोड एक ऑपरेशन दर्शाता है जहाँ अतिरिक्त पैलेट रंग मुख्य थीम रंग से प्राप्त होते हैं और फिर आकारों में उपयोग किए जाते हैं:
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // एक्सेंट 4
    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);

    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    // एक्सेंट 4, हल्का 80%
    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);

    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    // एक्सेंट 4, हल्का 60%
    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);

    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    // एक्सेंट 4, हल्का 40%
    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);

    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    // एक्सेंट 4, गहरा 25%
    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);

    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    // एक्सेंट 4, गहरा 50%
    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);

    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **`SchemeColor` को `IColorScheme` रंगों से मैप करें**

जब आप [SchemeColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/schemecolor/) के साथ काम करते हैं, तो आपको दिख सकता है कि इसमें निम्नलिखित थीम रंग मान शामिल हैं:
`Background1`, `Background2`, `Text1`, and `Text2`.

हालांकि, `Presentation.getMasterTheme().getColorScheme()` [IColorScheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icolorscheme/) लौटाता है, जो संबंधित रंगों को इस प्रकार प्रकट करता है:
`Dark1`, `Dark2`, `Light1`, and `Light2`.

यह अंतर केवल नामकरण में है। ये मान समान थीम रंग स्लॉटों को संदर्भित करते हैं और मैपिंग स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background` और `Dark`/`Light` के बीच कोई गतिशील रूपांतरण नहीं है। वे केवल समान थीम रंगों के वैकल्पिक नाम हैं।

यह नामकरण अंतर Microsoft Office शब्दावली से आया है। पुराने Office संस्करणों में `Dark 1`, `Light 1`, `Dark 2`, और `Light 2` का उपयोग होता था, जबकि नई UI संस्करण समान स्लॉटों को `Text 1`, `Background 1`, `Text 2`, और `Background 2` के रूप में दिखाते हैं।

## **थीम फ़ॉन्ट बदलें**

थीम और अन्य उद्देश्यों के लिए फ़ॉन्ट चुनने हेतु, Aspose.Slides इन विशेष पहचानकर्ताओं का उपयोग करता है (PowerPoint में प्रयुक्त समान):

* **+mn-lt** - बॉडी फ़ॉन्ट लैटिन (माइनर लैटिन फ़ॉन्ट)
* **+mj-lt** - हेडिंग फ़ॉन्ट लैटिन (मैजर लैटिन फ़ॉन्ट)
* **+mn-ea** - बॉडी फ़ॉन्ट ईस्ट एशियन (माइनर ईस्ट एशियन फ़ॉन्ट)
* **+mj-ea** - बॉडी फ़ॉन्ट ईस्ट एशियन (मैजर ईस्ट एशियन फ़ॉन्ट)

यह Java कोड दिखाता है कि कैसे लैटिन फ़ॉन्ट को थीम तत्व को असाइन करें:
```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    Paragraph paragraph = new Paragraph();

    Portion portion = new Portion("Theme text format");

    paragraph.getPortions().add(portion);

    shape.getTextFrame().getParagraphs().add(paragraph);

    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
} finally {
    if (pres != null) pres.dispose();
}
```

यह Java कोड दिखाता है कि कैसे प्रस्तुति थीम फ़ॉन्ट बदलें:
```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
} finally {
    if (pres != null) pres.dispose();
}
```

सभी टेक्स्ट बॉक्सों में फ़ॉन्ट अपडेट हो जाएगा।

{{% alert color="info" title="TIP" %}} 
आप देखना चाहेंगे [PowerPoint फ़ॉन्ट](/slides/hi/androidjava/powerpoint-fonts/).
{{% /alert %}}

## **थीम पृष्ठभूमि शैली बदलें**

डिफॉल्ट रूप से, PowerPoint एप्लिकेशन 12 पूर्वनिर्धारित पृष्ठभूमियाँ प्रदान करता है, लेकिन उन 12 में से केवल 3 पृष्ठभूमियाँ एक सामान्य प्रस्तुति में सहेजी जाती हैं।

![todo:image_alt_text](presentation-design_8.png)

उदाहरण के लिए, PowerPoint एप में प्रस्तुति सहेजने के बाद, आप इस Java कोड को चलाकर प्रस्तुति में पूर्वनिर्धारित पृष्ठभूमियों की संख्या पता कर सकते हैं:
```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
आप [BackgroundFillStyles](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) प्रॉपर्टी को [FormatScheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FormatScheme) क्लास से उपयोग करके PowerPoint थीम में पृष्ठभूमि शैली को जोड़ या एक्सेस कर सकते हैं।
{{% /alert %}} 

यह Java कोड दिखाता है कि कैसे प्रस्तुति के लिए पृष्ठभूमि सेट करें:
```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

**इंडेक्स गाइड**: 0 का उपयोग कोई भराव नहीं होने के लिये किया जाता है। इंडेक्स 1 से शुरू होता है।

{{% alert color="info" title="TIP" %}} 
आप देखना चाहेंगे [PowerPoint पृष्ठभूमि](/slides/hi/androidjava/presentation-background/).
{{% /alert %}}

## **थीम प्रभाव बदलें**

एक PowerPoint थीम आम तौर पर प्रत्येक स्टाइल एरे के लिए 3 मान रखती है। उन एरे को मिलाकर ये 3 प्रभाव बनते हैं: सूक्ष्म, मध्यम, और तीव्र। उदाहरण के लिए, यह परिणाम है जब प्रभावों को किसी विशिष्ट आकार पर लागू किया जाता है:
![todo:image_alt_text](presentation-design_10.png)

आप [FormatScheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FormatScheme) क्लास की 3 प्रॉपर्टी ([FillStyles](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/FormatScheme#getEffectStyles--)) का उपयोग करके थीम में तत्वों को बदल सकते हैं (PowerPoint के विकल्पों से भी अधिक लचीलापन के साथ)।

यह Java कोड दिखाता है कि कैसे तत्वों के हिस्सों को बदलकर थीम प्रभाव बदलें:
```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    pres.getMasterTheme().getFormatScheme().getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).setFillType(FillType.Solid);

    pres.getMasterTheme().getFormatScheme().getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.GREEN);

    pres.getMasterTheme().getFormatScheme().getEffectStyles().get_Item(2).getEffectFormat().getOuterShadowEffect().setDistance(10f);

    pres.save("Design_04_Subtle_Moderate_Intense-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

परिणामस्वरूप भराव रंग, भराव प्रकार, छाया प्रभाव आदि में परिवर्तन होते हैं:
![todo:image_alt_text](presentation-design_11.png)

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं मास्टर को बदले बिना एकल स्लाइड पर थीम लागू कर सकता हूँ?

हाँ। Aspose.Slides स्लाइड-स्तर थीम ओवरराइड का समर्थन करता है, इसलिए आप केवल उस स्लाइड पर स्थानीय थीम लागू कर सकते हैं जबकि मास्टर थीम को अपरिवर्तित रख सकते हैं ([SlideThemeManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slidethememanager/) के माध्यम से)।

### एक प्रस्तुति से दूसरी में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?

[Clone slides](/slides/hi/androidjava/clone-slides/) को उनके मास्टर के साथ लक्ष्य प्रस्तुति में ले जाएँ। इससे मूल मास्टर, लेआउट और संबंधित थीम संरक्षित रहती है, इसलिए स्वरूप स्थिर रहता है।

### सभी विरासत और ओवरराइड के बाद "प्रभावी" मान कैसे देखूँ?

थीम/रंग/फ़ॉन्ट/प्रभाव के लिए API के ["effective" view](/slides/hi/androidjava/shape-effective-properties/) का उपयोग करें। ये मास्टर लागू करने और किसी भी स्थानीय ओवरराइड के बाद समाधान किए गए अंतिम गुण लौटाते हैं।