---
title: जावा में प्रस्तुति थीम प्रबंधित करें
linktitle: प्रस्तुति थीम
type: docs
weight: 10
url: /hi/java/presentation-theme/
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
- थीम इफ़ेक्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में प्रस्तुति थीम्स को मास्टर करके PowerPoint फ़ाइलों को लगातार ब्रांडिंग के साथ बनाएं, अनुकूलित करें और परिवर्तित करें।"
---
## **परिचय**

एक प्रस्तुति थीम डिजाइन तत्वों के गुणों को परिभाषित करती है। जब आप प्रस्तुति थीम चुनते हैं, तो आप मूलतः दृश्य तत्वों और उनके गुणों का एक विशिष्ट सेट चुन रहे होते हैं।

PowerPoint में, एक थीम में रंग, [फ़ॉन्ट](/slides/hi/java/powerpoint-fonts/), [पृष्ठभूमि शैलियाँ](/slides/hi/java/presentation-background/), और प्रभाव शामिल होते हैं।

![theme-constituents](theme-constituents.png)

## **थीम रंग बदलें**

PowerPoint थीम स्लाइड पर विभिन्न तत्वों के लिए एक विशिष्ट रंग सेट का उपयोग करती है। यदि आपको रंग पसंद नहीं हैं, तो आप थीम के लिए नए रंग लागू करके उन्हें बदल सकते हैं। आपको नया थीम रंग चुनने की अनुमति देने के लिए, Aspose.Slides [SchemeColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SchemeColor) एन्यूमरेशन में मान प्रदान करता है।

यह Java कोड दिखाता है कि आप थीम के लिए एक्सेंट रंग को कैसे बदल सकते हैं:

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

आप इस तरह परिणामस्वरूप रंग के प्रभावी मान को निर्धारित कर सकते हैं:

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

रंग परिवर्तन ऑपरेशन को और स्पष्ट करने के लिए, हम एक अन्य तत्व बनाते हैं और उसे प्रारंभिक ऑपरेशन से प्राप्त एक्सेंट रंग सौंपते हैं। फिर हम थीम में रंग बदलते हैं:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

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

जब आप मुख्य थीम रंग (1) पर ल्यूमिनेंस परिवर्तन लागू करते हैं, तो अतिरिक्त पैलेट (2) से रंग बनते हैं। उसके बाद आप उन थीम रंगों को सेट और प्राप्त कर सकते हैं।

![additional-palette-colors](additional-palette-colors.png)

**1** - मुख्य थीम रंग  
**2** - अतिरिक्त पैलेट से रंग।

यह Java कोड एक ऑपरेशन प्रदर्शित करता है जहाँ अतिरिक्त पैलेट के रंग मुख्य थीम रंग से प्राप्त किए जाते हैं और फिर आकारों में उपयोग किए जाते हैं:

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

जब आप [SchemeColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/schemecolor/) के साथ काम करते हैं, तो आप देख सकते हैं कि इसमें निम्नलिखित थीम रंग मान शामिल हैं: `Background1`, `Background2`, `Text1`, और `Text2`।

हालांकि, `Presentation.getMasterTheme().getColorScheme()` [IColorScheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icolorscheme/) लौटाता है, जो संबंधित रंगों को इस प्रकार प्रदर्शित करता है: `Dark1`, `Dark2`, `Light1`, और `Light2`।

यह अंतर केवल नामकरण में है। ये मान समान थीम रंग स्लॉट्स को दर्शाते हैं और मैपिंग स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background` और `Dark`/`Light` के बीच कोई गतिशील रूपांतरण नहीं है। ये केवल समान थीम रंगों के वैकल्पिक नाम हैं।

यह नामकरण अंतर Microsoft Office की शब्दावली से आया है। पुराने Office संस्करणों में `Dark 1`, `Light 1`, `Dark 2`, और `Light 2` का उपयोग किया जाता था, जबकि नए UI संस्करण समान स्लॉट को `Text 1`, `Background 1`, `Text 2`, और `Background 2` के रूप में प्रदर्शित करते हैं।

## **थीम फ़ॉन्ट बदलें**

आपको थीम और अन्य उद्देश्यों के लिए फ़ॉन्ट चुनने की सुविधा देने के लिए, Aspose.Slides इन विशेष पहचानकर्ताओं का उपयोग करता है (PowerPoint में उपयोग किए जाने वाले के समान):

* **+mn-lt** - बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* **+mj-lt** - हेडिंग फ़ॉन्ट लैटिन (Major Latin Font)
* **+mn-ea** - बॉडी फ़ॉन्ट ईस्ट एशियन (Minor East Asian Font)
* **+mj-ea** - बॉडी फ़ॉन्ट ईस्ट एशियन (Major East Asian Font)

यह Java कोड दिखाता है कि आप कैसे थीम तत्व को लैटिन फ़ॉन्ट असाइन कर सकते हैं:

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

यह Java कोड दिखाता है कि आप प्रस्तुति थीम फ़ॉन्ट को कैसे बदल सकते हैं:

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
आप [PowerPoint फ़ॉन्ट](/slides/hi/java/powerpoint-fonts/) देखना चाह सकते हैं।
{{% /alert %}}

## **थीम पृष्ठभूमि शैली बदलें**

डिफ़ॉल्ट रूप से, PowerPoint ऐप 12 पूर्वनिर्धारित पृष्ठभूमियों को प्रदान करता है, लेकिन उन 12 पृष्ठभूमियों में से केवल 3 ही एक सामान्य प्रस्तुति में सहेजी जाती हैं। 

![todo:image_alt_text](presentation-design_8.png)

उदाहरण के लिए, PowerPoint ऐप में प्रस्तुति सहेजने के बाद, आप इस Java कोड को चलाकर प्रस्तुति में पूर्वनिर्धारित पृष्ठभूमियों की संख्या पता कर सकते हैं:

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
आप [FormatScheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FormatScheme) वर्ग की [BackgroundFillStyles](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) प्रॉपर्टी का उपयोग करके PowerPoint थीम में पृष्ठभूमि शैली जोड़ या एक्सेस कर सकते हैं। 
{{% /alert %}} 

यह Java कोड दिखाता है कि आप प्रस्तुति के लिए पृष्ठभूमि कैसे सेट कर सकते हैं:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
} finally {
    if (pres != null) pres.dispose();
}
```

**इंडेक्स गाइड**: 0 का उपयोग कोई फ़िल नहीं के लिए किया जाता है। इंडेक्स 1 से शुरू होता है।

{{% alert color="info" title="TIP" %}} 
आप [PowerPoint पृष्ठभूमि](/slides/hi/java/presentation-background/) देखना चाह सकते हैं।
{{% /alert %}}

## **थीम इफ़ेक्ट बदलें**

एक PowerPoint थीम सामान्यतः प्रत्येक शैली एरे के लिए 3 मान रखती है। उन एरे को मिलाकर ये 3 इफ़ेक्ट बनते हैं: सूक्ष्म, मध्यम, और तीव्र। उदाहरण के लिए, जब इन इफ़ेक्ट्स को किसी विशेष रूप पर लागू किया जाता है तो परिणाम इस प्रकार होता है:

![todo:image_alt_text](presentation-design_10.png)

आप [FormatScheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FormatScheme) वर्ग से 3 प्रॉपर्टीज़ ([FillStyles](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FormatScheme#getLineStyles--), [EffectStyles](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FormatScheme#getEffectStyles--)) का उपयोग करके थीम के तत्वों को बदल सकते हैं (PowerPoint के विकल्पों की तुलना में और अधिक लचीले ढंग से)।

यह Java कोड दिखाता है कि आप तत्वों के हिस्सों को बदलकर थीम इफ़ेक्ट को कैसे बदल सकते हैं:

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

परिणामस्वरूप भराव रंग, भराव प्रकार, शैडो इफ़ेक्ट आदि में परिवर्तन होते हैं:

![todo:image_alt_text](presentation-design_11.png)

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं मास्टर को बदले बिना एक ही स्लाइड पर थीम लागू कर सकता हूँ?
हां। Aspose.Slides स्लाइड-स्तर के थीम ओवरराइड को सपोर्ट करता है, इसलिए आप केवल उस स्लाइड पर स्थानीय थीम लागू कर सकते हैं जबकि मास्टर थीम को अपरिवर्तित रख सकते हैं ( [SlideThemeManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slidethememanager/) के माध्यम से)।

### एक प्रस्तुति से दूसरी प्रस्तुति में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?
[Clone slides](/slides/hi/java/clone-slides/) को उनके मास्टर के साथ लक्ष्य प्रस्तुति में कॉपी करें। यह मूल मास्टर, लेआउट, और संबंधित थीम को बनाए रखता है जिससे दिखावट समान रहती है।

### सभी विरासत और ओवरराइड के बाद "effective" मान कैसे देख सकते हैं?
थीम/रंग/फ़ॉन्ट/इफ़ेक्ट के लिए API के "effective" दृश्यों का उपयोग करें [/slides/hi/java/shape-effective-properties/]। ये मास्टर लागू करने के बाद तथा किसी भी स्थानीय ओवरराइड के बाद समाधानित अंतिम गुणों को लौटाते हैं।