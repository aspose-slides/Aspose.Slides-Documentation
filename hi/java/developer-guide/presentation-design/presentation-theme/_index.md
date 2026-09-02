---
title: जावा में प्रेजेंटेशन थीम प्रबंधित करें
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
- थीम स्टाइल
- थीम इफ़ेक्ट
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- जावा
- Aspose.Slides
description: "Aspose.Slides for Java में मास्टर प्रेजेंटेशन थीम्स का उपयोग करके PowerPoint फाइलें सृजन, अनुकूलन और रूपांतरण करें, निरंतर ब्रांडिंग के साथ।"
---
## **परिचय**

एक प्रेजेंटेशन थीम रंगों, फ़ॉन्ट्स, बैकग्राउंड स्टाइल्स, फ़िल्स, लाइन्स और इफ़ेक्ट्स का समन्वित सेट परिभाषित करती है। थीम‑सचेत ऑब्जेक्ट्स इन साझा परिभाषाओं को संदर्भित करते हैं बजाय प्रत्येक दृश्य गुण को स्थिर मान के रूप में संग्रहित करने के, इसलिए थीम में परिवर्तन कई ऑब्जेक्ट्स को एक साथ अपडेट कर सकता है।

Aspose.Slides में, प्रेजेंटेशन‑स्तर की थीम को [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) के माध्यम से उपलब्ध कराया जाता है। एक प्रेजेंटेशन में निचले स्तरों पर भी थीम ओवरराइड हो सकते हैं। एक मास्टर प्रेजेंटेशन थीम को [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/masterthememanager/) के माध्यम से ओवरराइड कर सकता है, जबकि लेआउट या व्यक्तिगत स्लाइड अपनी विरासत में मिली थीम को [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseoverridethememanager/) के माध्यम से ओवरराइड कर सकते हैं। व्यवहार में, स्लाइड के लिए प्रभावी थीम इस विरासत श्रृंखला के माध्यम से हल की जाती है: प्रेजेंटेशन थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![थीम के घटक: रंग, फ़ॉन्ट, बैकग्राउंड स्टाइल, और इफ़ेक्ट्स](theme-constituents.png)

नीचे के सेक्शन सबसे सामान्य थीम वर्कफ़्लो दिखाते हैं: थीम का निरीक्षण, रंग और फ़ॉन्ट बदलना, थीम कॉपी या लागू करना, बैकग्राउंड और इफ़ेक्ट स्टाइल अपडेट करना, और विरासत एवं ओवरराइड के बाद प्रभावी मान पढ़ना।

## **थीम का निरीक्षण करें**

[MasterTheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/mastertheme/) ऑब्जेक्ट थीम की कलर स्कीम, फ़ॉन्ट स्कीम और फ़ॉर्मेट स्कीम को क्रमशः [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/mastertheme/) और [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/mastertheme/) के माध्यम से उजागर करता है। इन संग्रहों का निरीक्षण करना विशेष रूप से उपयोगी है जब प्रेजेंटेशन बाहरी स्रोत से आया हो, क्योंकि स्टाइल एंट्रीज़ की संख्या और सामग्री भिन्न हो सकती है।

निम्न उदाहरण मुख्य थीम प्रॉपर्टीज़ को पढ़ता है और यह रिपोर्ट करता है कि थीम में कितनी बैकग्राउंड, फ़िल, लाइन और इफ़ेक्ट स्टाइल्स संग्रहीत हैं:

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

यदि किसी फ़ाइल में कई मास्टर उपयोग किए गए हैं, तो यह न मानें कि हर स्लाइड की प्रभावी थीम समान है। स्लाइड से जुड़ा मास्टर निरीक्षण करें, और लेआउट या स्लाइड ओवरराइड मौजूद होने पर इस लेख के बाद दिखाए गए प्रभावी‑थीम वर्कफ़्लो का उपयोग करें।

## **थीम के रंग बदलें**

थीम‑सचेत फ़िल्स, लाइन्स और टेक्स्ट [SchemeColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/schemecolor/) एन्न्यूमरेशन से एक लॉजिकल रंग का संदर्भ ले सकते हैं। जब आप [IColorScheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icolorscheme/) में संबंधित एंट्री बदलते हैं, तो सभी ऑब्जेक्ट्स जो अभी भी उस थीम रंग को संदर्भित कर रहे हैं, नई मान के विरुद्ध हल हो जाते हैं। सीधे RGB रंग का उपयोग करने वाले ऑब्जेक्ट्स थीम‑रंग अपडेट से प्रभावित नहीं होते।

निम्न संपूर्ण उदाहरण एक शेप बनाता है जो `Accent4` का उपयोग करता है, थीम के `Accent4` रंग को लाल में बदलता है, प्रेजेंटेशन को सहेजता है, पुनः खोलता है, और प्रभावी फ़िल रंग को प्रिंट करता है:

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

चूँकि आयत `Accent4` से जुड़ी रहती है, इस थीम के बदलाव के बाद उसका दिखने वाला रंग लाल हो जाता है। यदि आप शेप पर सीधे रंग सेट कर देते हैं, तो बाद में `Accent4` में बदलाव उस फ़िल को प्रभावित नहीं करेंगे।

### **अतिरिक्त पैलेट से रंगों का उपयोग करें**

PowerPoint एक थीम रंग से हल्के और गहरे वैरिएंट्स उत्पन्न करता है रंग रूपांतरण लागू करके। Aspose.Slides इन रूपांतरणों को [ColorTransformOperation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/colortransformoperation/) एन्न्यूमरेशन के माध्यम से उजागर करता है।

![मुख्य थीम रंग और अतिरिक्त पैलेट से उत्पन्न हल्के एवं गहरे रंग](additional-palette-colors.png)

**1** - मुख्य थीम रंग।

**2** - मुख्य थीम रंगों से उत्पन्न हल्के और गहरे वैरिएंट्स।

निम्न उदाहरण `Accent4` पर आधारित छह आयतें बनाता है, उनमें से पाँच पर ल्यूमिनेंस रूपांतरण लागू करता है, और परिणाम को सहेजता है:

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

ये वैरिएंट्स थीम रंग पर आधारित रहते हैं। यदि बाद में `Accent4` बदलता है, तो रूपांतरित रंग नई `Accent4` मान से पुनः गणना किए जाते हैं।

### **`SchemeColor` मानों को `IColorScheme` स्लॉट्स से मैप करें**

[SchemeColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/schemecolor/) एन्न्यूमरेशन `Text1`, `Background1`, `Text2` और `Background2` का उपयोग करता है, जबकि [IColorScheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icolorscheme/) समान थीम स्लॉट्स को `Dark1`, `Light1`, `Dark2` और `Light2` के रूप में उजागर करता है। मैपिंग नियत है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ये वही थीम स्लॉट्स के वैकल्पिक नाम हैं; इन्हें किसी रूप में गतिशील रूप से परिवर्तित नहीं किया जाता।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट स्कीम हेडिंग के लिए प्रमुख फ़ॉन्ट सेट और बॉडी टेक्स्ट के लिए गौण फ़ॉन्ट सेट रखती है। [IFontScheme.getMajor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontscheme/) और [IFontScheme.getMinor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontscheme/) मेथड्स इन सेट्स को उजागर करते हैं।

PowerPoint‑संगत थीम फ़ॉन्ट पहचानकर्ताओं का उपयोग टेक्स्ट फ़ॉर्मेटिंग में किया जा सकता है:

* `+mn-lt` - बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* `+mj-lt` - हेडिंग फ़ॉन्ट लैटिन (Major Latin Font)
* `+mn-ea` - बॉडी फ़ॉन्ट ईस्ट एशियन (Minor East Asian Font)
* `+mj-ea` - हेडिंग फ़ॉन्ट ईस्ट एशियन (Major East Asian Font)

निम्न उदाहरण एक हेडिंग बनाता है जो प्रमुख लैटिन थीम फ़ॉन्ट उपयोग करता है और एक बॉडी लाइन जो गौण लैटिन थीम फ़ॉन्ट उपयोग करती है। फिर थीम फ़ॉन्ट बदलते हैं और परिणाम सहेजते हैं:

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

हेडिंग प्रमुख फ़ॉन्ट को अनुसरण करती है और बॉडी टेक्स्ट गौण फ़ॉन्ट को। यदि फ़ॉन्ट नाम स्पष्ट रूप से दिया गया है न कि थीम पहचानकर्ता, तो थीम फ़ॉन्ट स्कीम बदलने पर वह स्वचालित रूप से नहीं बदलेगा।

मुख्य और गौण फ़ॉन्ट संग्रह में व्यक्तिगत लेखन प्रणालियों, जैसे सिरिलिक, अरबी, जापानी, जॉर्जियन और थाना के लिए फ़ॉन्ट मैपिंग भी हो सकती है। इन मैपिंग्स को निरीक्षण, जोड़ने, बदलने या हटाने के लिए देखें [Script‑Specific Theme Fonts](/slides/hi/java/script-specific-font-mappings/)।

{{% alert color="info" title="Tip" %}}
प्रेजेंटेशन फ़ॉन्ट्स के बारे में अधिक जानकारी के लिए देखें [PowerPoint Fonts](/slides/hi/java/powerpoint-fonts/)।
{{% /alert %}}

## **थीम कॉपी या लागू करें**

दो सामान्य वर्कफ़्लो होते हैं, और वे अलग‑अलग समस्याएँ हल करते हैं।

### **स्लाइड्स को स्थानांतरित करते समय स्रोत थीम बनाए रखें**

यदि आप किसी स्लाइड को अन्य प्रेजेंटेशन में ले जाना चाहते हैं और उसकी मूल डिज़ाइन बरकरार रखना चाहते हैं, तो स्रोत मास्टर को लक्षित प्रेजेंटेशन में [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterslidecollection/) से क्लोन करें, फिर उस क्लोन किए गए मास्टर के साथ स्लाइड को [ISlideCollection.addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecollection/) से क्लोन करें। इससे मास्टर, उसके लेआउट्स और सम्बद्ध थीम साथ में आएँगी।

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

यह वर्कफ़्लो तब वांछित होता है जब स्रोत स्लाइड को गंतव्य में वही रूप चाहिए। असंबद्ध गंतव्य मास्टर पर केवल कंटेंट क्लोन करने से थीम‑आधारित रंग, फ़ॉन्ट, बैकग्राउंड और इफ़ेक्ट बदल सकते हैं।

### **मौजूदा स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को अपने वर्तमान मास्टर और लेआउट पर ही रहना है, तो स्रोत थीम से स्लाइड‑स्तर का ओवरराइड प्रारंभ करें। [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hi/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hi/java/com.aspose.slides/overridetheme/) और [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hi/java/com.aspose.slides/overridetheme/) मेथड्स तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करते हैं।

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

यह अन्य स्लाइड्स द्वारा विरासत में मिली थीम को बदले बिना उस स्लाइड की थीम बदल देता है। स्थानीय ओवरराइड हटाकर विरासत मान पर लौटने के लिए [OverrideTheme.clear](https://reference.aspose.com/slides/hi/java/com.aspose.slides/overridetheme/) को कॉल करें।

### **लेआउट पर थीम ओवरराइड लागू करें**

लेआउट‑स्तर का ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट को उपयोग करती हैं, जब तक कि विशेष स्लाइड का अपना ओवरराइड न हो। समान प्रारंभिक मेथड्स को [LayoutSlideThemeManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/layoutslidethememanager/) के माध्यम से उपयोग किया जा सकता है:

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

जब कई लेआउट्स और स्लाइड्स को समान बेस डिज़ाइन साझा करना हो तो मास्टर या प्रेजेंटेशन‑स्तर की थीम उपयोग करें, जब केवल एक लेआउट परिवार को अलग शैली चाहिए तो लेआउट ओवरराइड, और केवल असाधारण मामलों के लिए स्लाइड ओवरराइड। अत्यधिक स्लाइड‑स्तर ओवरराइड्स बाद में वैश्विक थीम बदलावों को भविष्यवाणी करना कठिन बना देते हैं।

## **थीम बैकग्राउंड स्टाइल अपडेट करें**

थीम की बैकग्राउंड फ़िल्स [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iformatscheme/) में संग्रहीत होती हैं। PowerPoint UI में उपलब्ध बैकग्राउंड विकल्प इन संग्रह में भौतिक रूप से संग्रहीत फ़िल परिभाषाओं से अधिक हो सकते हैं, क्योंकि UI थीम फ़िल को थीम रंग और अन्य स्टाइल रेफ़रेंसेज़ के साथ संयोजित कर सकता है।

![PowerPoint बैकग्राउंड स्टाइल गैलरी एक प्रेजेंटेशन थीम के लिए](presentation-design_8.png)

बैकग्राउंड स्टाइल उपयोग करने से पहले संग्रहीत संग्रह और मौजूदा [Background.getStyleIndex](https://reference.aspose.com/slides/hi/java/com.aspose.slides/background/) को निरीक्षण करें। `0` का स्टाइल इंडेक्स मतलब कोई थीम फ़िल नहीं; सकारात्मक मान थीम बैकग्राउंड‑स्टाइल रेफ़रेंसेज़ हैं। यह Java संग्रह में सीधे इंडेक्सिंग (`get_Item(0)`) से अलग है, जहाँ `get_Item(0)` पहला संग्रहीत आइटम दर्शाता है। यह न मानें कि हर प्रेजेंटेशन में समान संख्या में बैकग्राउंड फ़िल स्टाइल्स हों।

निम्न उदाहरण उपलब्ध बैकग्राउंड फ़िल गिनती रिपोर्ट करता है, पहले मास्टर को थीम‑बैकग्राउंड रेफ़रेंस असाइन करता है, और प्रेजेंटेशन को सहेजता है:

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

दिखाई देने वाला परिणाम मास्टर द्वारा संदर्भित थीम एंट्री और लेआउट या स्लाइड स्तर पर किसी भी बैकग्राउंड ओवरराइड पर निर्भर करता है। यदि स्लाइड अपनी खुद की बैकग्राउंड उपयोग करती है, तो केवल मास्टर बैकग्राउंड बदलने से वह स्लाइड नहीं बदलेगी। विरासत लागू होने के बाद अंतिम बैकग्राउंड जानने के लिए [Background.getEffective](https://reference.aspose.com/slides/hi/java/com.aspose.slides/background/) का उपयोग करें।

{{% alert color="warning" title="Warning" %}}
स्टाइल इंडेक्स को शून्य‑आधारित संग्रह इंडेक्स न समझें। साथ ही एक फ़ाइल से स्टाइल नंबर हार्ड‑कोड करके दूसरा फ़ाइल में मानने से बचें; थीम स्टाइल परिभाषाएँ प्रेजेंटेशन‑विशिष्ट होती हैं।
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
सीधे बैकग्राउंड फ़ॉर्मेटिंग और बैकग्राउंड विरासत के लिए देखें [Presentation Background](/slides/hi/java/presentation-background/)।
{{% /alert %}}

## **थीम इफ़ेक्ट्स अपडेट करें**

एक थीम फ़ॉर्मेट स्कीम अलग‑अलग फ़िल, लाइन और इफ़ेक्ट स्टाइल संग्रह रखती है, जिन्हें क्रमशः [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iformatscheme/) और [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iformatscheme/) के माध्यम से उजागर किया जाता है। सामान्य Office थीम्स में अक्सर तीन मुख्य स्टाइल एंट्रीज़ होती हैं जो दृश्य रूप में सूक्ष्म, मध्यम और तीव्र फ़ॉर्मेटिंग से मेल खाती हैं, पर कोड को प्रत्येक संग्रह का निरीक्षण करना चाहिए बजाय निश्चित गणना मानने के।

![समान शेप पर लागू सूक्ष्म, मध्यम और तीव्र थीम इफ़ेक्ट्स](presentation-design_10.png)

जब आप ये संग्रह Java में एक्सेस करते हैं, तो संग्रह इंडेक्स शून्य‑आधारित होता है: `get_Item(0)` पहला संग्रहीत स्टाइल और `get_Item(2)` तीसरा। शेप का स्टाइल‑रेफ़रेंस इंडेक्स एक अलग अवधारणा है, जिसे [IShapeStyle](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapestyle/) के माध्यम से उजागर किया जाता है। थीम स्टाइल को संशोधित करने से उन शेप्स पर प्रभाव पड़ता है जो उस थीम स्टाइल को संदर्भित करती हैं; सीधे फ़ॉर्मेटिंग वाले शेप्स अपरिवर्तित रह सकते हैं।

निम्न उदाहरण जाँचता है कि आवश्यक स्टाइल एंट्रीज़ मौजूद हैं, पहला लाइन स्टाइल बदलता है, तीसरा फ़िल स्टाइल बदलता है, तीसरे इफ़ेक्ट स्टाइल में बाहरी शैडो सक्षम करता है, और परिणाम सहेजता है:

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

इन स्लॉट्स को संदर्भित शेप्स के लिए पहला थीम लाइन स्टाइल लाल हो जाता है, तीसरा थीम फ़िल स्टाइल ठोस फ़ॉरेस्ट ग्रीन, और तीसरा इफ़ेक्ट स्टाइल बाहरी शैडो 10 पॉइंट दूरी के साथ प्राप्त करता है। अंतिम दृश्य परिणाम अभी भी इस पर निर्भर करता है कि प्रत्येक शेप कौन‑से स्लॉट को संदर्भित करता है और क्या सीधे फ़ॉर्मेटिंग थीम को ओवरराइड करती है।

![लाइन, फ़िल और शैडो सेटिंग्स बदलने के बाद थीम इफ़ेक्ट स्टाइल्स](presentation-design_11.png)

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम ऑब्जेक्ट बताते हैं कि किसी विशेष स्तर पर क्या परिभाषित है। प्रभावी मान बताते हैं कि विरासत और स्थानीय ओवरराइड्स हल होने के बाद स्लाइड या शेप वास्तव में क्या उपयोग करती है। स्लाइड के लिए, [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseoverridethememanager/) को कॉल करें। बैकग्राउंड के लिए, [Background.getEffective](https://reference.aspose.com/slides/hi/java/com.aspose.slides/background/) उपयोग करें, और फ़िल के लिए, [FillFormat.getEffective](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fillformat/) उपयोग करें।

निम्न उदाहरण एक स्लाइड से प्रभावी थीम, बैकग्राउंड और पहली शेप फ़िल पढ़ता है:

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

रेंडरिंग डायग्नोस्टिक्स, वैलिडेशन और तुलना के लिए प्रभावी डेटा का उपयोग करें। यदि आप केवल [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) का निरीक्षण करते हैं, तो आप ऐसा मास्टर, लेआउट, स्लाइड या शेप ओवरराइड मिस कर सकते हैं जो अंतिम उपस्थिति को बदलता है।

## **FAQ**

**क्या मैं मास्टर को बदले बिना एकल स्लाइड पर थीम लागू कर सकता हूँ?**

हाँ। स्लाइड की [SlideThemeManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slidethememanager/) का उपयोग करके उसकी ओवरराइड थीम को प्रारंभ करें। परिवर्तन केवल उस स्लाइड तक सीमित रहेगा; अन्य स्लाइड्स अपने मौजूदा थीम को विरासत में जारी रखेंगी।

**एक प्रेजेंटेशन से दूसरे में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

जब स्लाइड को ले जा रहे हों और उसकी स्रोत उपस्थिति को बनाए रखना चाहते हों, तो स्रोत मास्टर को गंतव्य में [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterslidecollection/) से क्लोन करें और फिर उस मास्टर के साथ स्लाइड को [ISlideCollection.addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecollection/) से क्लोन करें। इससे मास्टर, लेआउट्स और थीम साथ में रहती हैं।

**विरासत और ओवरराइड्स के बाद प्रभावी मान कैसे देखूँ?**

स्लाइड या लेआउट थीम के लिए [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseoverridethememanager/) का उपयोग करें और फ़ॉर्मेट ऑब्जेक्ट जैसे [Background.getEffective](https://reference.aspose.com/slides/hi/java/com.aspose.slides/background/) और [FillFormat.getEffective](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fillformat/) के लिए संबंधित प्रभावी‑डेटा मेथड्स का उपयोग करें। ये API विरासत और ओवरराइड लागू होने के बाद हल किए गए मान लौटाते हैं।