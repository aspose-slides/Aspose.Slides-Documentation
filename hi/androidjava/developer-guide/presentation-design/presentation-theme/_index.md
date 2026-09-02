---
title: Android पर प्रस्तुति थीम प्रबंधित करें
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
description: "Aspose.Slides for Android में Java के माध्यम से मास्टर प्रस्तुति थीम को प्रबंधित करें जिससे आप PowerPoint फ़ाइलें बनाएं, अनुकूलित करें और निरंतर ब्रांडिंग के साथ परिवर्तित कर सकें।"
---
## **परिचय**

एक प्रस्तुति थीम रंगों, फ़ॉन्ट्स, बैकग्राउंड शैलियों, फ़िल्स, लाइनों और प्रभावों का समन्वित सेट परिभाषित करती है। थीम‑सजग ऑब्जेक्ट्स इन साझा परिभाषाओं को संदर्भित करते हैं न कि प्रत्येक दृश्य गुण को स्थिर मान के रूप में संग्रहित करते हैं, इसलिए थीम बदलने पर कई ऑब्जेक्ट्स एक साथ अपडेट हो सकते हैं।

Aspose.Slides में, प्रस्तुति‑स्तर की थीम [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) के माध्यम से उपलब्ध है। एक प्रस्तुति में निचले स्तरों पर थीम ओवरराइड भी हो सकते हैं। एक मास्टर प्रस्तुति थीम को [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/masterthememanager/) के द्वारा ओवरराइड कर सकता है, जबकि लेआउट या व्यक्तिगत स्लाइड अपने विरासत में मिली थीम को [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseoverridethememanager/) के द्वारा ओवरराइड कर सकती है। व्यावहारिक रूप से, स्लाइड के लिए प्रभावी थीम इस विरासत श्रृंखला के माध्यम से हल होती है: प्रस्तुति थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

नीचे के अनुभाग सबसे सामान्य थीम कार्य‑प्रवाह दिखाते हैं: थीम का निरीक्षण, रंग और फ़ॉन्ट बदलना, थीम कॉपी या लागू करना, बैकग्राउंड और प्रभाव शैलियों को अपडेट करना, और विरासत व ओवरराइड हल होने के बाद प्रभावी मान पढ़ना।

## **थीम का निरीक्षण**

[MasterTheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mastertheme/) ऑब्जेक्ट थीम की कलर स्कीम, फ़ॉन्ट स्कीम और फ़ॉर्मेट स्कीम को क्रमशः [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mastertheme/), और [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mastertheme/) के द्वारा उजागर करता है। इन संग्रहों का निरीक्षण करना विशेष रूप से उपयोगी है जब प्रस्तुति बाहरी स्रोत से आती है क्योंकि शैली प्रविष्टियों की संख्या और सामग्री बदल सकती है।

निम्न उदाहरण मुख्य थीम गुण पढ़ता है और रिपोर्ट करता है कि थीम में कितनी बैकग्राउंड, फ़िल, लाइन और इफ़ेक्ट स्टाइल संग्रहीत हैं:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterTheme theme = presentation.getMasterTheme();
    int accent1 = theme.getColorScheme().getAccent1().getColor();
    System.out.println("Theme name: " + theme.getName());
    System.out.println(String.format("Accent 1: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(accent1), Color.red(accent1), Color.green(accent1), Color.blue(accent1)));
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

यदि फ़ाइल कई मास्टर उपयोग करती है, तो यह न मानें कि प्रत्येक स्लाइड की प्रभावी थीम समान होगी। स्लाइड से जुड़े मास्टर का निरीक्षण करें, और लेआउट या स्लाइड ओवरराइड मौजूद होने पर इस लेख में दिखाए गए प्रभावी‑थीम कार्य‑प्रवाह का उपयोग करें।

## **थीम रंग बदलें**

थीम‑सजग फ़िल्स, लाइनें और टेक्स्ट [SchemeColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/schemecolor/) enumeration से एक लॉजिकल रंग को संदर्भित कर सकते हैं। जब आप [IColorScheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icolorscheme/) में संबंधित प्रविष्टि बदलते हैं, तो सभी ऑब्जेक्ट्स जो अभी भी उस थीम रंग को संदर्भित करते हैं, नई कीमत के विरुद्ध हल होते हैं। डायरेक्ट RGB रंग का उपयोग करने वाले ऑब्जेक्ट्स थीम‑रंग अपडेट से नहीं बदलते।

निम्न अंत‑से‑अंत उदाहरण एक आकार बनाता है जो `Accent4` का उपयोग करता है, थीम के `Accent4` रंग को लाल में बदलता है, प्रस्तुति को सहेजता है, पुनः खोलता है, और प्रभावी फ़िल रंग प्रिंट करता है:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
    int effectiveColor = effectiveFill.getSolidFillColor();
    System.out.println(String.format("Effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
} finally {
    savedPresentation.dispose();
}
```

चूँकि आयत `Accent4` से जुड़ी रहती है, थीम बदलने के बाद उसका दिखाई देने वाला रंग लाल हो जाता है। यदि आप आकार पर सीधे रंग बदलते हैं, तो बाद में `Accent4` में परिवर्तन उस फ़िल को प्रभावित नहीं करेगा।

### **अतिरिक्त पैलेट से रंग उपयोग करें**

PowerPoint थीम रंग से हल्के और गहरे वैरिएंट उत्पन्न करने हेतु रंग रूपांतरण लागू करता है। Aspose.Slides इन रूपांतरणों को [ColorTransformOperation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/colortransformoperation/) enumeration के माध्यम से उजागर करता है।

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - मुख्य थीम रंग।

**2** - मुख्य थीम रंगों से उत्पन्न हल्के और गहरे वैरिएंट।

निम्न उदाहरण `Accent4` पर आधारित छह आयतें बनाता है, उनमें से पाँच पर ल्यूमिनेंस रूपांतरण लागू करता है, और परिणाम सहेजता है:

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

ये वैरिएंट अभी भी थीम रंग पर आधारित रहते हैं। यदि बाद में `Accent4` बदलता है, तो रूपांतरित रंग नई `Accent4` कीमत से पुनः गणना किए जाते हैं।

### **`SchemeColor` मानों को `IColorScheme` स्लॉट्स में मानचित्रित करें**

[SchemeColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/schemecolor/) enumeration `Text1`, `Background1`, `Text2` और `Background2` का उपयोग करती है, जबकि [IColorScheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icolorscheme/) समान थीम स्लॉट्स को `Dark1`, `Light1`, `Dark2`, और `Light2` के रूप में उजागर करता है। मैपिंग स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ये उसी थीम स्लॉट्स के वैकल्पिक नाम हैं; इन्हें एक रूप से दूसरे रूप में गतिशील रूप से परिवर्तित नहीं किया जाता।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट स्कीम में हेडिंग्स के लिए प्रमुख फ़ॉन्ट सेट और बॉडी टेक्स्ट के लिए लघु फ़ॉन्ट सेट होता है। [IFontScheme.getMajor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontscheme/) और [IFontScheme.getMinor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontscheme/) मेथड्स इन सेटों को उजागर करते हैं।

PowerPoint‑अनुकूल थीम फ़ॉन्ट पहचानकर्ता टेक्स्ट फ़ॉर्मेटिंग में उपयोग किए जा सकते हैं:

* `+mn-lt` - बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* `+mj-lt` - हेडिंग फ़ॉन्ट लैटिन (Major Latin Font)
* `+mn-ea` - बॉडी फ़ॉन्ट ईस्ट एशियन (Minor East Asian Font)
* `+mj-ea` - हेडिंग फ़ॉन्ट ईस्ट एशियन (Major East Asian Font)

निम्न उदाहरण एक हेडिंग बनाता है जो प्रमुख लैटिन थीम फ़ॉन्ट का उपयोग करता है और एक बॉडी लाइन जो लघु लैटिन थीम फ़ॉन्ट का उपयोग करती है। इसके बाद थीम फ़ॉन्ट बदलता है और परिणाम सहेजता है:

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

हेडिंग प्रमुख फ़ॉन्ट का अनुसरण करती है और बॉडी टेक्स्ट लघु फ़ॉन्ट का। स्पष्ट फ़ॉन्ट नाम वाले टेक्स्ट थीम पहचानकर्ता बदलने पर स्वतः स्विच नहीं करेंगे।

मुख्य और लघु फ़ॉन्ट संग्रह व्यक्तिगत लेखन प्रणालियों (जैसे Cyrillic, Arabic, Japanese, Georgian, और Thaana) के लिए फ़ॉन्ट मैपिंग भी रख सकते हैं। इन मैपिंग को निरीक्षण, जोड़, बदल या हटाने के लिए देखें [Script-Specific Theme Fonts](/slides/hi/androidjava/script-specific-font-mappings/)।

{{% alert color="info" title="Tip" %}}
अधिक जानकारी के लिए प्रस्तुति फ़ॉन्ट देखें [PowerPoint Fonts](/slides/hi/androidjava/powerpoint-fonts/)।
{{% /alert %}}

## **थीम कॉपी या लागू करें**

दो सामान्य कार्य‑प्रवाह हैं, जो विभिन्न समस्याएँ सुलझाते हैं।

### **स्लाइड्स स्थानांतरित करते समय स्रोत थीम बनाए रखें**

यदि आप एक स्लाइड को दूसरी प्रस्तुति में ले जाकर उसकी मूल डिज़ाइन बनाए रखना चाहते हैं, तो स्रोत मास्टर को लक्ष्य प्रस्तुति में [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslidecollection/) से क्लोन करें, फिर स्लाइड को [ISlideCollection.addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidecollection/) और क्लोन किए हुए मास्टर से क्लोन करें। यह मास्टर, इसके लेआउट, और सम्बद्ध थीम को साथ ले जाता है।

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

यह कार्य‑प्रवाह तब पसंदीदा है जब स्रोत स्लाइड को गंतव्य में समान दिखना चाहिए। सिर्फ असंबंधित लक्ष्य मास्टर पर सामग्री क्लोन करने से थीम‑ड्रिवन रंग, फ़ॉन्ट, बैकग्राउंड और प्रभाव बदल सकते हैं।

### **एक मौजूदा स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को उसके मौजूदा मास्टर और लेआउट पर रहना है, तो स्रोत थीम से स्लाइड‑स्तर ओवरराइड प्रारंभ करें। [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/overridetheme/), और [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/overridetheme/) मेथड्स तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करते हैं।

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
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

यह अन्य स्लाइड्स द्वारा विरासत में ली गई थीम को बदले बिना उस स्लाइड की थीम बदल देता है। स्थानीय ओवरराइड हटाने और विरासत मानों पर लौटने के लिए [OverrideTheme.clear](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/overridetheme/) को कॉल करें।

### **लेआउट पर थीम ओवरराइड लागू करें**

लेआउट‑स्तर ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट को उपयोग करती हैं, जब तक कि कोई विशेष स्लाइड अपना स्वयं का ओवरराइड न रखे। इसी प्रारंभिक मेथड को [LayoutSlideThemeManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/layoutslidethememanager/) के माध्यम से उपयोग किया जा सकता है:

```java
import com.aspose.slides.*;

Presentation source = new Presentation("source-theme.pptx");
try {
    Presentation target = new Presentation("target.pptx");
    try {
        ISlide targetSlide = target.getSlides().get_Item(0);
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

जब कई लेआउट और स्लाइड्स को समान आधार डिज़ाइन साझा करना हो तो प्रस्तुति‑स्तर या मास्टर‑स्तर थीम उपयोग करें, जब एक लेआउट परिवार को अलग शैली चाहिए तो लेआउट ओवरराइड, और केवल वास्तविक अपवादों के लिए स्लाइड ओवरराइड उपयोग करें। अधिक स्लाइड‑स्तर ओवरराइड बाद में वैश्विक थीम बदलों को भविष्यवाणी करना कठिन बनाते हैं।

## **थीम बैकग्राउंड शैलियों को अपडेट करें**

थीम की बैकग्राउंड फ़िल्स [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iformatscheme/) में संग्रहीत हैं। PowerPoint अपने UI में अधिक बैकग्राउंड विकल्प प्रस्तुत कर सकता है क्योंकि UI थीम फ़िल्स को थीम रंगों और अन्य शैली संदर्भों के साथ संयोजित कर सकता है।

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

बैकग्राउंड शैली उपयोग करने से पहले संग्रहीत संग्रह और वर्तमान [Background.getStyleIndex](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/background/) का निरीक्षण करें। `0` का शैली‑सूचकांक कोई थीम्ड फ़िल नहीं दर्शाता; सकारात्मक मान थीम बैकग्राउंड‑स्टाइल संदर्भ होते हैं। यह Java संग्रह के इंडेक्सिंग से अलग है, जहाँ `get_Item(0)` पहला संग्रहीत आइटम होता है। प्रत्येक प्रस्तुति में बैकग्राउंड फ़िल शैली की समान संख्या नहीं होती, यह न मानें।

निम्न उदाहरण उपलब्ध बैकग्राउंड फ़िल गणना रिपोर्ट करता है, पहले मास्टर को थीम्ड बैकग्राउंड संदर्भ असाइन करता है, और प्रस्तुति सहेजता है:

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

दिखाई देने वाला परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि और लेआउट या स्लाइड‑स्तर पर किसी भी बैकग्राउंड ओवरराइड पर निर्भर करता है। यदि स्लाइड अपनी स्वयं की बैकग्राउंड उपयोग करती है, तो केवल मास्टर बैकग्राउंड बदलने से वह स्लाइड नहीं बदलेगी। विरासत लागू होने के बाद अंतिम बैकग्राउंड जानने के लिए [Background.getEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/background/) उपयोग करें।

{{% alert color="warning" title="Warning" %}}
शैली‑सूचकांक को शून्य‑आधारित संग्रह सूचकांक न समझें। एक फ़ाइल से शैली संख्या हार्ड‑कोड कर अन्य फ़ाइल में समान रूप मानना नहीं चाहिए; थीम शैली परिभाषाएँ प्रस्तुति‑विशिष्ट होती हैं।
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
सीधे बैकग्राउंड फ़ॉर्मेटिंग और बैकग्राउंड विरासत के लिए देखें [Presentation Background](/slides/hi/androidjava/presentation-background/)।
{{% /alert %}}

## **थीम प्रभाव अपडेट करें**

एक थीम फ़ॉर्मेट स्कीम में अलग‑अलग फ़िल, लाइन, और इफ़ेक्ट शैली संग्रह होते हैं जो क्रमशः [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iformatscheme/), और [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iformatscheme/) के द्वारा उजागर होते हैं। समान्य Office थीम में अक्सर तीन प्रमुख शैली प्रविष्टियाँ होती हैं जो दृश्य रूप से Subtle, Moderate, और Intense फ़ॉर्मेटिंग के अनुरूप होती हैं, लेकिन कोड को प्रत्येक संग्रह का निरीक्षण करना चाहिए न कि निश्चित गिनती मान लेना।

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

जब आप इन संग्रहों को Java में एक्सेस करते हैं, तो संग्रह सूचकांक शून्य‑आधारित होता है: `get_Item(0)` पहला संग्रहीत शैली और `get_Item(2)` तीसरा। आकार की शैली‑संदर्भ सूचकांक एक अलग अवधारणा है, जो [IShapeStyle](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapestyle/) द्वारा उजागर होती है। किसी थीम शैली को बदलने से उन आकारों पर प्रभाव पड़ता है जो उस थीम शैली को संदर्भित करते हैं; सीधे फ़ॉर्मेटिंग वाले आकार अपरिवर्तित रह सकते हैं।

निम्न उदाहरण जांचता है कि आवश्यक शैली प्रविष्टियाँ मौजूद हैं, पहला लाइन शैली बदलता है, तीसरा फ़िल शैली बदलता है, तीसरे इफ़ेक्ट शैली में बाहरी छाया सक्षम करता है, और परिणाम सहेजता है:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation("Subtle_Moderate_Intense.pptx");
try {
    IFormatScheme formatScheme = presentation.getMasterTheme().getFormatScheme();
    if (formatScheme.getLineStyles().size() < 1 || formatScheme.getFillStyles().size() < 3 || formatScheme.getEffectStyles().size() < 3) {
        throw new IllegalStateException("The theme does not contain the style entries required by this example.");
    }
    formatScheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid);
    formatScheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED);
    formatScheme.getFillStyles().get_Item(2).setFillType(FillType.Solid);
    formatScheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(Color.rgb(34, 139, 34));
    IEffectFormat effectFormat = formatScheme.getEffectStyles().get_Item(2).getEffectFormat();
    effectFormat.enableOuterShadowEffect();
    effectFormat.getOuterShadowEffect().setDistance(10f);
    presentation.save("theme-effects.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

इन स्लॉट्स को संदर्भित करने वाले आकारों के लिए पहला थीम लाइन शैली लाल हो जाती है, तीसरा थीम फ़िल शैली ठोस फ़ॉरेस्ट ग्रीन, और तीसरा इफ़ेक्ट शैली 10 पॉइंट दूरी के साथ बाहरी छाया प्राप्त करता है। अंतिम दृश्य परिणाम तब भी इस पर निर्भर करता है कि प्रत्येक आकार कौन‑से शैली स्लॉट संदर्भित करता है तथा क्या सीधे फ़ॉर्मेटिंग थीम को ओवरराइड करता है।

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम ऑब्जेक्ट बताते हैं कि किसी विशेष स्तर पर क्या परिभाषित है। प्रभावी मान दिखाते हैं कि विरासत और स्थानीय ओवरराइड हल होने के बाद स्लाइड या आकार वास्तव में क्या उपयोग करता है। स्लाइड के लिए [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseoverridethememanager/) को कॉल करें। बैकग्राउंड के लिए [Background.getEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/background/), और फ़िल के लिए [FillFormat.getEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fillformat/) उपयोग करें।

निम्न उदाहरण एक स्लाइड से प्रभावी थीम, बैकग्राउंड, और पहले आकार फ़िल पढ़ता है:

```java
import com.aspose.slides.*;
import android.graphics.Color;

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
            int effectiveColor = effectiveFill.getSolidFillColor();
            System.out.println(String.format("First shape effective fill color: Color [A=%d, R=%d, G=%d, B=%d]", Color.alpha(effectiveColor), Color.red(effectiveColor), Color.green(effectiveColor), Color.blue(effectiveColor)));
        }
    }
} finally {
    presentation.dispose();
}
```

रेंडरिंग डाइग्नॉस्टिक्स, वैधता, और तुलना के लिए प्रभावी डेटा उपयोग करें। यदि आप केवल [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) का निरीक्षण करते हैं, तो आप किसी मास्टर, लेआउट, स्लाइड, या आकार ओवरराइड को चूक सकते हैं जो अंतिम उपस्थिति बदलता है।

## **बार‑बार पूछे जाने वाले प्रश्न**

**क्या मैं मास्टर बदलें बिना एकल स्लाइड पर थीम लागू कर सकता हूँ?**

हाँ। स्लाइड के [SlideThemeManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slidethememanager/) को उपयोग करें और उसका ओवरराइड थीम प्रारंभ करें। परिवर्तन केवल उसी स्लाइड तक सीमित रहता है; अन्य स्लाइड्स अपने मौजूदा थीम को विरासत में लेती रहेंगी।

**एक प्रस्तुति से दूसरी प्रस्तुति में थीम सुरक्षित रूप से कैसे ले जाएँ?**

जब आप स्लाइड को ले जा रहे हों और उसकी मूल उपस्थिति बनाए रखना चाहते हों, तो स्रोत मास्टर को लक्ष्य में [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslidecollection/) से क्लोन करें और फिर स्लाइड को उस मास्टर के साथ [ISlideCollection.addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidecollection/) से क्लोन करें। यह मास्टर, लेआउट, और थीम को साथ रखता है।

**विरासत और ओवरराइड के बाद प्रभावी मान कैसे देखें?**

स्लाइड या लेआउट थीम के लिए [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseoverridethememanager/) उपयोग करें और फ़ॉर्मेट ऑब्जेक्ट्स जैसे [Background.getEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/background/) और [FillFormat.getEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fillformat/) के लिए संबंधित प्रभावी‑डेटा मेथड्स उपयोग करें। ये API विरासत और ओवरराइड लागू होने के बाद हल हुए मान लौटाते हैं।