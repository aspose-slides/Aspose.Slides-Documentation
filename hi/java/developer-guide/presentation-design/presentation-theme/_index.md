---
title: Java में प्रेजेंटेशन थीम प्रबंधन
linktitle: प्रेजेंटेशन थीम
type: docs
weight: 10
url: /hi/java/presentation-theme/
keywords:
- PowerPoint थीम
- प्रेजेंटेशन थीम
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
- प्रेजेंटेशन
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में मुख्य प्रेजेंटेशन थीम का उपयोग करके PowerPoint फ़ाइलों को लगातार ब्रांडिंग के साथ बनाने, अनुकूलित करने और परिवर्तित करने के लिए।"
---
## **परिचय**

एक प्रेजेंटेशन थीम रंगों, फ़ॉन्ट्स, बैकग्राउंड शैलियों, फ़िल्स, लाइनों और इफ़ेक्ट्स का समन्वित सेट परिभाषित करती है। थीम-आधारित ऑब्जेक्ट्स इन साझा परिभाषाओं को संदर्भित करते हैं बजाय प्रत्येक दृश्य गुण को स्थिर मान के रूप में संग्रहीत करने के, जिससे थीम परिवर्तन कई ऑब्जेक्ट्स को एक साथ अपडेट कर सकता है।

Aspose.Slides में, प्रेजेंटेशन‑स्तरीय थीम [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) के माध्यम से उपलब्ध है। एक प्रेजेंटेशन में निचले स्तरों पर भी थीम ओवरराइड हो सकते हैं। एक मास्टर अपने प्रेजेंटेशन थीम को [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/masterthememanager/) के जरिए ओवरराइड कर सकता है, जबकि लेआउट या व्यक्तिगत स्लाइड अपने विरासत में मिले थीम को [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseoverridethememanager/) के माध्यम से ओवरराइड कर सकते हैं। व्यवहार में, स्लाइड के लिए प्रभावी थीम इस विरासत श्रृंखला के माध्यम से निर्धारित होती है: प्रेजेंटेशन थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

नीचे दिया गया भाग सबसे सामान्य थीम कार्यप्रवाह दिखाता है: थीम का निरीक्षण, रंग और फ़ॉन्ट बदलना, थीम कॉपी या लागू करना, बैकग्राउंड और इफ़ेक्ट शैलियों को अपडेट करना, और विरासत एवं ओवरराइड्स के बाद प्रभावी मूल्यों को पढ़ना।

## **थीम का निरीक्षण**

[MasterTheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/mastertheme/) ऑब्जेक्ट थीम की रंग योजना, फ़ॉन्ट योजना, और फ़ॉर्मेट योजना को क्रमशः [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/mastertheme/), और [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/mastertheme/) के जरिए उजागर करता है। इन संग्रहों का निरीक्षण करके परिवर्तन करना उपयोगी होता है, विशेषकर जब प्रेजेंटेशन बाहरी स्रोत से आया हो, क्योंकि शैली प्रविष्टियों की संख्या और सामग्री भिन्न हो सकती है।

निम्न उदाहरण मुख्य थीम गुण पढ़ता है और बताता है कि थीम में कितनी बैकग्राउंड, फ़िल, लाइन और इफ़ेक्ट शैलियाँ संग्रहीत हैं:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    System.out.println("Theme name: " + theme.getName());
    System.out.println("Accent 1: " + theme.getColorScheme().getAccent1().getColor());
    System.out.println("Major Latin font: " + theme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Minor Latin font: " + theme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Background fill styles: " + theme.getFormatScheme().getBackgroundFillStyles().size());
    System.out.println("Fill styles: " + theme.getFormatScheme().getFillStyles().size());
    System.out.println("Line styles: " + theme.getFormatScheme().getLineStyles().size());
    System.out.println("Effect styles: " + theme.getFormatScheme().getEffectStyles().size());
} finally {
    presentation.dispose();
}
```

यदि कोई फ़ाइल कई मास्टर इस्तेमाल करती है, तो यह मान कर न चलें कि प्रत्येक स्लाइड की वही प्रभावी थीम होगी। स्लाइड से जुड़ा मास्टर निरीक्षण करें, और जब लेआउट या स्लाइड ओवरराइड मौजूद हो तो इस लेख में बाद में दिखाए गए प्रभावी‑थीम कार्यप्रवाह का उपयोग करें।

## **थीम के रंग बदलें**

थीम‑आधारित फ़िल्स, लाइनों और टेक्स्ट में [SchemeColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/schemecolor/) enumeration से एक तार्किक रंग संदर्भित किया जा सकता है। जब आप [IColorScheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icolorscheme/) में संबंधित प्रविष्टि बदलते हैं, तो सभी ऑब्जेक्ट्स जो अभी भी उस थीम रंग को संदर्भित करते हैं, नया मान ले लेते हैं। जो ऑब्जेक्ट्स सीधे RGB रंग प्रयोग करते हैं, वे थीम‑रंग अपडेट से प्रभावित नहीं होते।

निम्न अंत‑से‑अंत उदाहरण एक आकार बनाता है जो `Accent4` का उपयोग करता है, थीम के `Accent4` रंग को लाल में बदलता है, प्रेजेंटेशन सहेजता है, फिर उसे पुनः खोलकर प्रभावी फ़िल रंग प्रिंट करता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED);
    presentation.save("theme-color.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation savedPresentation = new Presentation("theme-color.pptx");
try {
    ISlide savedSlide = savedPresentation.getSlides().get_Item(0);
    IShape savedShape = savedSlide.getShapes().get_Item(0);
    IFillFormatEffectiveData effectiveFill = savedShape.getFillFormat().getEffective();
    System.out.println("Effective fill color: " + effectiveFill.getSolidFillColor());
} finally {
    savedPresentation.dispose();
}
```

क्योंकि आयत `Accent4` से जुड़ी रहती है, इसलिए थीम बदलने के बाद उसका दिखाई देने वाला रंग लाल हो जाता है। यदि आप आकार पर सीधे रंग डालते हैं, तो बाद में `Accent4` में बदलाव उस फ़िल को प्रभावित नहीं करेंगे।

### **Additional Palette से रंग उपयोग करें**

PowerPoint थीम रंग से हल्के और गहरे वैरिएंट उत्पन्न करता है, इसके लिए रंग रूपांतरण लागू करता है। Aspose.Slides इन रूपांतरणों को [ColorTransformOperation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/colortransformoperation/) enumeration के माध्यम से उजागर करता है।

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - मुख्य थीम रंग।

**2** - मुख्य थीम रंगों से उत्पन्न हल्के और गहरे वैरिएंट।

निम्न उदाहरण `Accent4` के आधार पर छह आयतें बनाता है, उनमें से पाँच पर ल्यूमिनेंस रूपांतरण लागू करता है, और परिणाम सहेजता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50);
    shape1.getFillFormat().setFillType(FillType.Solid);
    shape1.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);

    IShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50);
    shape2.getFillFormat().setFillType(FillType.Solid);
    shape2.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2f);
    shape2.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8f);

    IShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50);
    shape3.getFillFormat().setFillType(FillType.Solid);
    shape3.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4f);
    shape3.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6f);

    IShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50);
    shape4.getFillFormat().setFillType(FillType.Solid);
    shape4.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6f);
    shape4.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4f);

    IShape shape5 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50);
    shape5.getFillFormat().setFillType(FillType.Solid);
    shape5.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape5.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75f);

    IShape shape6 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50);
    shape6.getFillFormat().setFillType(FillType.Solid);
    shape6.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4);
    shape6.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5f);

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ये वैरिएंट अभी भी थीम रंग पर आधारित रहते हैं। यदि बाद में `Accent4` बदलता है, तो रूपांतरित रंग नए `Accent4` मान से पुनः गणना किए जाएंगे।

### **`SchemeColor` मानों को `IColorScheme` स्लॉट्स से मैप करें**

[SchemeColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/schemecolor/) enumeration `Text1`, `Background1`, `Text2`, और `Background2` का उपयोग करता है, जबकि [IColorScheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icolorscheme/) वही थीम स्लॉट `Dark1`, `Light1`, `Dark2`, और `Light2` के रूप में उजागर करता है। मैपिंग स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ये समान थीम स्लॉट के वैकल्पिक नाम हैं; ये किसी रूपांतरणीय मान नहीं हैं जो एक रूप से दूसरे रूप में गतिशील रूप से बदलते हैं।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट योजना में हेडिंग के लिए मुख्य (major) फ़ॉन्ट सेट और बॉडी टेक्स्ट के लिए द्वितीयक (minor) फ़ॉन्ट सेट होता है। [IFontScheme.getMajor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontscheme/) और [IFontScheme.getMinor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontscheme/) विधियाँ इन सेटों को उजागर करती हैं।

PowerPoint‑संगत थीम फ़ॉन्ट पहचानकर्ता टेक्स्ट फ़ॉर्मेटिंग में उपयोग किए जा सकते हैं:

* `+mn-lt` - बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* `+mj-lt` - हेडिंग फ़ॉन्ट लैटिन (Major Latin Font)
* `+mn-ea` - बॉडी फ़ॉन्ट ईस्ट एशियन (Minor East Asian Font)
* `+mj-ea` - हेडिंग फ़ॉन्ट ईस्ट एशियन (Major East Asian Font)

निम्न उदाहरण एक हेडिंग बनाता है जो मुख्य लैटिन थीम फ़ॉन्ट उपयोग करता है और एक बॉडी लाइन जो द्वितीयक लैटिन थीम फ़ॉन्ट उपयोग करती है। फिर थीम फ़ॉन्ट बदलता है और परिणाम सहेजता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60);
    heading.getTextFrame().setText("Theme heading");
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mj-lt"));

    IAutoShape body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60);
    body.getTextFrame().setText("Theme body text");
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(new FontData("Aptos Display"));
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(new FontData("Arial"));
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

हेडिंग मुख्य फ़ॉन्ट का अनुसरण करती है और बॉडी टेक्स्ट द्वितीयक फ़ॉन्ट का। यदि टेक्स्ट में स्पष्ट फ़ॉन्ट नाम है न कि थीम पहचानकर्ता, तो थीम फ़ॉन्ट योजना बदलने पर वह स्वतः नहीं बदलेगा।

{{% alert color="info" title="संकेत" %}}
अधिक जानकारी के लिए प्रेजेंटेशन फ़ॉन्ट्स देखें: [PowerPoint Fonts](/slides/hi/java/powerpoint-fonts/)।
{{% /alert %}}

## **थीम कॉपी या लागू करें**

दो सामान्य कार्यप्रवाह हैं, और वे अलग‑अलग समस्याओं को हल करते हैं।

### **स्लाइड स्थानांतरित करते समय स्रोत थीम बनाए रखें**

यदि आप किसी स्लाइड को दूसरे प्रेजेंटेशन में ले जाकर उसका मूल डिज़ाइन बनाए रखना चाहते हैं, तो स्रोत मास्टर को लक्ष्य प्रेजेंटेशन में [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterslidecollection/) से क्लोन करें, फिर स्लाइड को [ISlideCollection.addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecollection/) और क्लोन किए गए मास्टर के साथ क्लोन करें। इससे मास्टर, उसके लेआउट और संबंधित थीम साथ‑साथ चली जाती है।

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide sourceSlide = source.getSlides().get_Item(0);
        IMasterSlide sourceMaster = sourceSlide.getLayoutSlide().getMasterSlide();
        IMasterSlide clonedMaster = target.getMasters().addClone(sourceMaster);
        target.getSlides().addClone(sourceSlide, clonedMaster, true);
        target.save("theme-preserved.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

यह वह प्राथमिक कार्यप्रवाह है जब स्रोत स्लाइड को गन्तव्य में समान दिखना आवश्यक हो। असंबंधित गन्तव्य मास्टर पर केवल सामग्री क्लोन करने से थीम‑आधारित रंग, फ़ॉन्ट, बैकग्राउंड और इफ़ेक्ट बदल सकते हैं।

### **मौजूदा स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को अपने वर्तमान मास्टर और लेआउट पर ही रहना है, तो स्रोत थीम से स्लाइड‑स्तरीय ओवरराइड प्रारंभ करें। [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hi/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hi/java/com.aspose.slides/overridetheme/), और [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hi/java/com.aspose.slides/overridetheme/) विधियाँ तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करती हैं।

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
        IOverrideTheme overrideTheme = targetSlide.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

यह उस स्लाइड द्वारा उपयोग की गई थीम को बदलता है, जबकि अन्य स्लाइडों की विरासत वाली थीम अपरिवर्तित रहती है। स्थानीय ओवरराइड हटाने और विरासत मानों पर लौटने के लिए [OverrideTheme.clear](https://reference.aspose.com/slides/hi/java/com.aspose.slides/overridetheme/) को कॉल करें।

### **लेआउट पर थीम ओवरराइड लागू करें**

लेआउट‑स्तरीय ओवरराइड उन सभी स्लाइडों पर लागू होता है जो उस लेआउट को उपयोग करती हैं, जब तक कि एक विशिष्ट स्लाइड की अपनी ओवरराइड न हो। समान प्रारंभिक विधियों का प्रयोग [LayoutSlideThemeManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/layoutslidethememanager/) के माध्यम से किया जा सकता है:

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = presentation.getSlides().get_Item(0);
        ILayoutSlide targetLayout = targetSlide.getLayoutSlide();
        IOverrideTheme overrideTheme = targetLayout.getThemeManager().getOverrideTheme();
        overrideTheme.initColorSchemeFrom(source.getMasterTheme().getColorScheme());
        overrideTheme.initFontSchemeFrom(source.getMasterTheme().getFontScheme());
        overrideTheme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme());
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx);
    } finally {
        target.dispose();
    }
} finally {
    source.dispose();
}
```

जब कई लेआउट और स्लाइड को समान बेस डिज़ाइन साझा करना हो तो मास्टर या प्रेजेंटेशन‑स्तरीय थीम उपयोग करें, जब एक लेआउट परिवार को अलग शैली चाहिए तो लेआउट ओवरराइड, और केवल वास्तविक अपवादों के लिए स्लाइड ओवरराइड। अत्यधिक स्लाइड‑स्तरीय ओवरराइड्स बाद में वैश्विक थीम परिवर्तन को भविष्यवाणी करना कठिन बना देती हैं।

## **थीम बैकग्राउंड शैलियों को अपडेट करें**

थीम की बैकग्राउंड फ़िल्स [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iformatscheme/) में संग्रहीत होती हैं। PowerPoint अपने UI में उन फ़िल्स को थीम रंग और अन्य शैली संदर्भों के साथ संयोजित करके अधिक बैकग्राउंड विकल्प प्रस्तुत कर सकता है, जबकि इस संग्रह में शारीरिक रूप से संग्रहीत फ़िल परिभाषाओं की संख्या कम हो सकती है।

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

बैकग्राउंड शैली का उपयोग करने से पहले, संग्रहीत संग्रह और वर्तमान [Background.getStyleIndex](https://reference.aspose.com/slides/hi/java/com.aspose.slides/background/) को जाँचें। `0` का स्टाइल इंडेक्स मतलब कोई थीमेड फ़िल नहीं; सकारात्मक मान थीम बैकग्राउंड‑स्टाइल संदर्भ होते हैं। यह Java संग्रह को सीधे इंडेक्स करने से अलग है, जहाँ `get_Item(0)` पहला संग्रहीत आइटम दर्शाता है। यह मान न लें कि प्रत्येक प्रेजेंटेशन में समान संख्या में बैकग्राउंड फ़िल शैलियाँ होंगी।

निम्न उदाहरण उपलब्ध बैकग्राउंड फ़िल गिनती रिपोर्ट करता है, पहले मास्टर को थीम्ड बैकग्राउंड संदर्भ असाइन करता है, और प्रेजेंटेशन सहेजता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IFillFormatCollection backgroundStyles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles();
    System.out.println("Background fill styles: " + backgroundStyles.size());
    if (backgroundStyles.size() == 0) {
        throw new IllegalStateException("The presentation theme does not contain background fill styles.");
    }

    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    masterSlide.getBackground().setType(BackgroundType.Themed);
    masterSlide.getBackground().setStyleIndex(1);
    presentation.save("theme-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

दर्शनीय परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि और लेआउट या स्लाइड स्तर पर किसी भी बैकग्राउंड ओवरराइड पर निर्भर करता है। यदि स्लाइड अपनी स्वयं की बैकग्राउंड उपयोग करती है, तो केवल मास्टर बैकग्राउंड बदलने से वह स्लाइड नहीं बदल पाएगी। अंतिम बैकग्राउंड (विरासत लागू होने के बाद) जानने के लिए [Background.getEffective](https://reference.aspose.com/slides/hi/java/com.aspose.slides/background/) का उपयोग करें।

{{% alert color="warning" title="चेतावनी" %}}
स्टाइल इंडेक्स को शून्य-आधारित संग्रह इंडेक्स न समझें। साथ ही एक फ़ाइल से स्टाइल नंबर हार्ड‑कोड करके दूसरे फ़ाइल में समान उपस्थिति मानना से बचें; थीम शैली परिभाषाएँ प्रेजेंटेशन‑विशिष्ट होती हैं।
{{% /alert %}}

{{% alert color="info" title="संकेत" %}}
सीधे बैकग्राउंड फ़ॉर्मेटिंग और बैकग्राउंड विरासत के लिए देखें: [Presentation Background](/slides/hi/java/presentation-background/)।
{{% /alert %}}

## **थीम इफ़ेक्ट्स को अपडेट करें**

एक थीम फ़ॉर्मेट योजना अलग‑अलग फ़िल, लाइन और इफ़ेक्ट शैली संग्रहों को उजागर करती है, जिन्हें क्रमशः [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iformatscheme/), और [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iformatscheme/) के द्वारा एक्सेस किया जाता है। सामान्य Office थीम अक्सर तीन प्रमुख शैली प्रविष्टियों को शामिल करती हैं जो दृश्य रूप से Subtle, Moderate, और Intense फ़ॉर्मेटिंग से मेल खाती हैं, लेकिन कोड को प्रत्येक संग्रह को जाँचना चाहिए न कि निश्चित संख्या मान लेना चाहिए।

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

जब आप इन संग्रहों को Java में एक्सेस करते हैं, तो संग्रह इंडेक्स शून्य‑आधारित होता है: `get_Item(0)` पहला संग्रहीत शैली है और `get_Item(2)` तीसरा। आकार की शैली‑संदर्भ इंडेक्स अलग अवधारणा है, जिसे [IShapeStyle](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapestyle/) द्वारा उजागर किया जाता है। थीम शैली को संशोधित करने से उन आकारों पर प्रभाव पड़ता है जो उस थीम शैली को संदर्भित करते हैं; सीधे फ़ॉर्मेटिंग वाले आकार अपरिवर्तित रह सकते हैं।

निम्न उदाहरण जाँचता है कि आवश्यक शैली प्रविष्टियाँ मौजूद हैं, पहली लाइन शैली बदलता है, तीसरी फ़िल शैली बदलता है, तीसरी इफ़ेक्ट शैली में बाहरी छाया (distance 10 points) सक्रिय करता है, और परिणाम सहेजता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(new Color(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

इन स्लॉटों को संदर्भित करने वाले आकारों के लिए, प्रथम थीम लाइन शैली लाल हो जाएगी, तृतीय थीम फ़िल शैली ठोस फ़ॉरेस्ट ग्रीन, और तृतीय इफ़ेक्ट शैली बाहरी छाया के साथ 10 पॉइंट दूरी प्राप्त करेगी। सटीक दृश्य परिणाम अभी भी इस बात पर निर्भर करता है कि प्रत्येक आकार कौन‑से शैली स्लॉट को संदर्भित करता है और क्या सीधे फ़ॉर्मेटिंग थीम को ओवरराइड करती है।

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम ऑब्जेक्ट आपको किसी विशिष्ट स्तर पर क्या परिभाषित है बताते हैं। प्रभावी मान आपको बताते हैं कि कोई स्लाइड या आकार वास्तव में विरासत और स्थानीय ओवरराइड्स के बाद क्या उपयोग करता है। स्लाइड के लिए, [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseoverridethememanager/) को कॉल करें। बैकग्राउंड के लिए, [Background.getEffective](https://reference.aspose.com/slides/hi/java/com.aspose.slides/background/) और फ़िल के लिए, [FillFormat.getEffective](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fillformat/) उपयोग करें।

निम्न उदाहरण एक स्लाइड से प्रभावी थीम, बैकग्राउंड, और प्रथम आकार फ़िल पढ़ता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IThemeEffectiveData effectiveTheme = slide.getThemeManager().createThemeEffective();
    IBackgroundEffectiveData effectiveBackground = slide.getBackground().getEffective();
    System.out.println("Effective major Latin font: " + effectiveTheme.getFontScheme().getMajor().getLatinFont().getFontName());
    System.out.println("Effective minor Latin font: " + effectiveTheme.getFontScheme().getMinor().getLatinFont().getFontName());
    System.out.println("Effective background fill type: " + effectiveBackground.getFillFormat().getFillType());
    if (slide.getShapes().size() > 0) {
        IFillFormatEffectiveData effectiveFill = slide.getShapes().get_Item(0).getFillFormat().getEffective();
        System.out.println("First shape effective fill type: " + effectiveFill.getFillType());
        if (effectiveFill.getFillType() == FillType.Solid) {
            System.out.println("First shape effective fill color: " + effectiveFill.getSolidFillColor());
        }
    }
} finally {
    presentation.dispose();
}
```

रेंडरिंग डायग्नॉस्टिक, वैलिडेशन, और तुलना के लिए प्रभावी डेटा का उपयोग करें। यदि आप केवल [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) को निरीक्षण करते हैं, तो आप किसी मास्टर, लेआउट, स्लाइड, या आकार ओवरराइड को खो सकते हैं जो अंतिम उपस्थिति को बदलता है।

## **सामान्य प्रश्न**

**क्या मैं एकल स्लाइड पर थीम लागू कर सकता हूँ बिना मास्टर बदले?**

हाँ। स्लाइड के [SlideThemeManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slidethememanager/) का उपयोग करके उसका ओवरराइड थीम प्रारंभ करें। परिवर्तन केवल उस स्लाइड तक सीमित रहेगा; अन्य स्लाइडें अपने मौजूदा थीम से विरासत जारी रखेगी।

**एक प्रेजेंटेशन से दूसरे में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

जब स्लाइड को स्थानांतरित कर उसके मूल डिज़ाइन को बनाए रखना हो, तो स्रोत मास्टर को गन्तव्य में क्लोन करें और फिर उस मास्टर के साथ स्लाइड को [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterslidecollection/) और [ISlideCollection.addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecollection/) से क्लोन करें। इससे मास्टर, लेआउट और थीम साथ‑साथ चलती है।

**विरासत और ओवरराइड्स के बाद प्रभावी मान कैसे देखें?**

स्लाइड या लेआउट थीम के लिए [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseoverridethememanager/) तथा फ़ॉर्मेट ऑब्जेक्ट्स जैसे [Background.getEffective](https://reference.aspose.com/slides/hi/java/com.aspose.slides/background/) और [FillFormat.getEffective](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fillformat/) के संबंधित प्रभावी‑डेटा मेथड्स का उपयोग करें। ये API विरासत और ओवरराइड लागू होने के बाद हल किए गए मान लौटाते हैं।