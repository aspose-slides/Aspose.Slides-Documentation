---
title: Java में प्रस्तुति थीमों का प्रबंधन
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
- थीम प्रभाव
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में प्रस्तुति थीमों को नियंत्रित करें ताकि आप PowerPoint फ़ाइलों को स्थिर ब्रांडिंग के साथ बना, अनुकूलित और परिवर्तित कर सकें।"
---
## **परिचय**

एक प्रस्तुति थीम डिज़ाइन तत्वों की गुणधर्मों को परिभाषित करती है। जब आप प्रस्तुति थीम चुनते हैं, तो आप मूलतः दृश्य तत्वों और उनके गुणधर्मों का एक विशिष्ट सेट चुन रहे होते हैं।

PowerPoint में, एक थीम रंगों, [फ़ॉन्ट्स](/slides/hi/java/powerpoint-fonts/), [पृष्ठभूमि शैलियों](/slides/hi/java/presentation-background/), और प्रभावों को सम्मिलित करती है।

![theme-constituents](theme-constituents.png)

## **थीम रंग बदलें**

PowerPoint थीम स्लाइड के विभिन्न तत्वों के लिए विशिष्ट रंगों का सेट उपयोग करती है। यदि आपको रंग पसंद नहीं हैं, तो आप थीम के लिए नए रंग लागू करके उन्हें बदल सकते हैं। नया थीम रंग चुनने के लिए, Aspose.Slides [SchemeColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/SchemeColor) enumeration के तहत मान प्रदान करता है।

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
} finally {
    if (pres != null) pres.dispose();
}
```

आप इस तरह परिणामस्वरूप रंग का प्रभावी मान निर्धारित कर सकते हैं:

```java
IFillFormatEffectiveData fillEffective = shape.getFillFormat().getEffective();

Color effectiveColor = fillEffective.getSolidFillColor();

System.out.println(String.format("Color [A=%d, R=%d, G=%d, B=%d]", 
        effectiveColor.getAlpha(), effectiveColor.getRed(), effectiveColor.getGreen(), effectiveColor.getBlue()));
```

रंग परिवर्तन ऑपरेशन को आगे दिखाने के लिए, हम एक अन्य तत्व बनाते हैं और प्रारंभिक ऑपरेशन से प्राप्त एक्सेंट रंग उसे असाइन करते हैं। फिर हम थीम में रंग बदलते हैं:

```java
IAutoShape otherShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 120, 100, 100);

otherShape.getFillFormat().setFillType(FillType.Solid);

otherShape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

pres.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
```

नया रंग दोनों तत्वों पर स्वतः लागू हो जाता है।

### **अतिरिक्त पैलेट से थीम रंग सेट करें**

जब आप मुख्य थीम रंग(1) पर ल्यूमिनेंस परिवर्तन लागू करते हैं, तो अतिरिक्त पैलेट(2) से रंग बनते हैं। आप फिर उन थीम रंगों को सेट और प्राप्त कर सकते हैं।

![additional-palette-colors](additional-palette-colors.png)

**1** - मुख्य थीम रंग

**2** - अतिरिक्त पैलेट के रंग

```java
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

    presentation.save(path + "example_accent4.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

### **`SchemeColor` को `IColorScheme` रंगों से मैप करें**

जब आप [SchemeColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/schemecolor/) के साथ काम करते हैं, तो आप देख सकते हैं कि इसमें निम्नलिखित थीम रंग मान हैं:

`Background1`, `Background2`, `Text1`, और `Text2`.

हालांकि, `Presentation.getMasterTheme().getColorScheme()` [IColorScheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icolorscheme/) लौटाता है, जो संबंधित रंगों को इस प्रकार प्रदर्शित करता है:

`Dark1`, `Dark2`, `Light1`, और `Light2`.

यह अंतर केवल नामकरण में है। ये मान वही थीम रंग स्लॉट्स को दर्शाते हैं और मैपिंग स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

`Text`/`Background` और `Dark`/`Light` के बीच कोई गतिशील रूपांतरण नहीं है। वे केवल समान थीम रंगों के वैकल्पिक नाम हैं।

यह नामकरण अंतर Microsoft Office शब्दावली से आता है। पुराने Office संस्करणों में `Dark 1`, `Light 1`, `Dark 2`, और `Light 2` उपयोग किए जाते थे, जबकि नवीनतम UI संस्करण वही स्लॉट्स को `Text 1`, `Background 1`, `Text 2`, और `Background 2` के रूप में प्रदर्शित करते हैं।

## **थीम फ़ॉन्ट बदलें**

थीम और अन्य उद्देश्यों के लिए फ़ॉन्ट चुनने हेतु, Aspose.Slides इन विशेष पहचानकर्ताओं का उपयोग करता है (जो PowerPoint में उपयोग किए जाने वाले हैं):

* **+mn-lt** - बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* **+mj-lt** - हेडिंग फ़ॉन्ट लैटिन (Major Latin Font)
* **+mn-ea** - बॉडी फ़ॉन्ट ईस्ट एशियन (Minor East Asian Font)
* **+mj-ea** - बॉडी फ़ॉन्ट ईस्ट एशियन (Major East Asian Font)

```java
IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);

Paragraph paragraph = new Paragraph();

Portion portion = new Portion("Theme text format");

paragraph.getPortions().add(portion);

shape.getTextFrame().getParagraphs().add(paragraph);

portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));
```

यह Java कोड दिखाता है कि कैसे लैटिन फ़ॉन्ट को थीम तत्व को असाइन किया जाए:

```java
pres.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
```

यह Java कोड दिखाता है कि कैसे प्रस्तुति थीम फ़ॉन्ट बदलें:

सभी पाठ बॉक्सों में फ़ॉन्ट अपडेट हो जाएगा।

{{% alert color="primary" title="TIP" %}} 
आप [PowerPoint फ़ॉन्ट्स](/slides/hi/java/powerpoint-fonts/) देखना चाह सकते हैं।
{{% /alert %}}

## **थीम पृष्ठभूमि शैली बदलें**

डिफ़ॉल्ट रूप से, PowerPoint ऐप 12 पूर्वनिर्धारित पृष्ठभूमियां प्रदान करता है लेकिन उन 12 में से केवल 3 पृष्ठभूमियां एक सामान्य प्रस्तुति में सहेजी जाती हैं। 

![todo:image_alt_text](presentation-design_8.png)

उदाहरण के लिए, PowerPoint ऐप में प्रस्तुति सहेजने के बाद, आप इस Java कोड को चलाकर प्रस्तुति में पूर्वनिर्धारित पृष्ठभूमियों की संख्या पता कर सकते हैं:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    int numberOfBackgroundFills = pres.getMasterTheme().getFormatScheme().getBackgroundFillStyles().size();

    System.out.println("Number of background fill styles for theme is " + numberOfBackgroundFills);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert color="warning" %}} 
आप [BackgroundFillStyles](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FormatScheme#getBackgroundFillStyles--) प्रॉपर्टी को [FormatScheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FormatScheme) क्लास से उपयोग करके PowerPoint थीम में पृष्ठभूमि शैली को जोड़ या एक्सेस कर सकते हैं। 
{{% /alert %}} 

यह Java कोड दिखाता है कि कैसे प्रस्तुति के लिए पृष्ठभूमि सेट की जाए:

```java
pres.getMasters().get_Item(0).getBackground().setStyleIndex(2);
```

**इंडेक्स गाइड**: 0 का उपयोग कोई भराव न देने के लिए किया जाता है। इंडेक्स 1 से शुरू होता है।

{{% alert color="primary" title="TIP" %}} 
आप [PowerPoint पृष्ठभूमि](/slides/hi/java/presentation-background/) देखना चाह सकते हैं। 
{{% /alert %}}

## **थीम प्रभाव बदलें**

एक PowerPoint थीम आमतौर पर प्रत्येक शैली array के लिए 3 मान रखती है। इन arrays को मिलाकर ये 3 प्रभाव बनते हैं: सूक्ष्म, मध्यम, और तीव्र। उदाहरण के लिए, जब इन प्रभावों को किसी विशिष्ट आकार पर लागू किया जाता है तो यह परिणाम मिलता है:

![todo:image_alt_text](presentation-design_10.png)

आप [FillStyles](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FormatScheme#getFillStyles--), [LineStyles](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FormatScheme#getLineStyles--), और [EffectStyles](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FormatScheme#getEffectStyles--) जैसे 3 प्रॉपर्टियों का उपयोग करके [FormatScheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/FormatScheme) क्लास से थीम के तत्वों को बदल सकते हैं (PowerPoint विकल्पों से भी अधिक लचीले ढंग से)।

```java
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

परिणामस्वरूप भराव रंग, भराव प्रकार, शैडो प्रभाव आदि में परिवर्तन होते हैं:

![todo:image_alt_text](presentation-design_11.png)

## **FAQ**

**क्या मैं मास्टर को बदले बिना एकल स्लाइड पर थीम लागू कर सकता हूँ?**

हां। Aspose.Slides स्लाइड-स्तरीय थीम ओवरराइड का समर्थन करता है, इसलिए आप केवल उस स्लाइड पर एक स्थानीय थीम लागू कर सकते हैं जबकि मास्टर थीम को अछूता रख सकते हैं ( [SlideThemeManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slidethememanager/) के माध्यम से)।

**एक प्रस्तुति से दूसरी में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

[Clone slides](/slides/hi/java/clone-slides/) को उनके मास्टर के साथ लक्ष्य प्रस्तुति में कॉपी करें। यह मूल मास्टर, लेआउट और संबंधित थीम को संरक्षित रखता है जिससे रूपरेखा समान बनी रहती है।

**सभी विरासत और ओवरराइड के बाद मैं "effective" मान कैसे देख सकता हूँ?**

थीम/रंग/फ़ॉन्ट/प्रभाव के लिए API के "effective" व्यूज](/slides/hi/java/shape-effective-properties/) का उपयोग करें। ये मास्टर और किसी भी स्थानीय ओवरराइड के लागू होने के बाद हल किए गए, अंतिम गुणों को लौटाते हैं।