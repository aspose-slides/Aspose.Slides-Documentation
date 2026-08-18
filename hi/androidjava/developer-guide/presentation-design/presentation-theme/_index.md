---
title: Android पर प्रस्तुति थीम्स प्रबंधित करें
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
description: "Aspose.Slides for Android में Java के माध्यम से मुख्य प्रस्तुति थीम्स को बनाना, अनुकूलित करना और PowerPoint फ़ाइलों को निरंतर ब्रांडिंग के साथ परिवर्तित करना।"
---
## **परिचय**

एक प्रस्तुति थीम रंगों, फ़ॉन्टों, पृष्ठभूमि शैलियों, भरावों, रेखाओं और प्रभावों का समन्वित सेट परिभाषित करती है। थीम‑सचेत वस्तुएँ इन साझा परिभाषाओं को संदर्भित करती हैं न कि प्रत्येक दृश्य गुण को स्थिर मान के रूप में संग्रहीत करती हैं, इसलिए थीम परिवर्तन कई वस्तुओं को एक साथ अपडेट कर सकता है।

Aspose.Slides में, प्रस्तुति‑स्तर की थीम को [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) के माध्यम से एक्सेस किया जा सकता है। एक प्रस्तुति में नीचे‑स्तर पर भी थीम ओवरराइड हो सकते हैं। एक मास्टर प्रस्तुति थीम को [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/masterthememanager/) के माध्यम से ओवरराइड कर सकता है, जबकि लेआउट या व्यक्तिगत स्लाइड अपनी विरासत थीम को [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseoverridethememanager/) के माध्यम से ओवरराइड कर सकती है। व्यावहारिक रूप से, एक स्लाइड के लिए प्रभावी थीम इस विरासत श्रृंखला के माध्यम से हल होती है: प्रस्तुति थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![थीम घटक: रंग, फ़ॉन्ट, पृष्ठभूमि शैलियां, और प्रभाव](theme-constituents.png)

नीचे के अनुभाग सबसे सामान्य थीम कार्यप्रवाह दिखाते हैं: एक थीम का निरीक्षण करना, रंग और फ़ॉन्ट बदलना, थीम को कॉपी या लागू करना, पृष्ठभूमि और प्रभाव शैलियों को अपडेट करना, और विरासत तथा ओवरराइड के बाद प्रभावी मान पढ़ना।

## **एक थीम का निरीक्षण करें**

[MasterTheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mastertheme/) ऑब्जेक्ट थीम की रंग योजना, फ़ॉन्ट योजना, और फ़ॉर्मेट योजना को क्रमशः [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mastertheme/), और [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mastertheme/) के माध्यम से उजागर करता है। इन संग्रहों का निरीक्षण करना, विशेषकर जब प्रस्तुति बाहरी स्रोत से आती है, उपयोगी होता है क्योंकि शैली प्रविष्टियों की संख्या और सामग्री बदल सकती है।

निम्न उदाहरण मुख्य थीम गुणों को पढ़ता है और रिपोर्ट करता है कि थीम में कितने पृष्ठभूमि, भराव, रेखा, और प्रभाव शैलियाँ संग्रहीत हैं:

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

यदि कोई फ़ाइल कई मास्टर का उपयोग करती है, तो यह मानकर न चलें कि हर स्लाइड का प्रभावी थीम समान है। स्लाइड से जुड़े मास्टर का निरीक्षण करें, और तब प्रभावी‑थीम कार्यप्रवाह का उपयोग करें जो इस लेख में बाद में दिखाया गया है, जब लेआउट या स्लाइड ओवरराइड मौजूद हो सकते हैं।

## **थीम रंग बदलें**

थीम‑सचेत भराव, रेखाएँ, और पाठ [SchemeColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/schemecolor/) enumeration से एक तर्कसंगत रंग का संदर्भ दे सकते हैं। जब आप [IColorScheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icolorscheme/) में संबंधित प्रविष्टि बदलते हैं, तो सभी वस्तुएँ जो अभी भी उस थीम रंग को संदर्भित करती हैं, नए मान के विरुद्ध हल हो जाती हैं। वे वस्तुएँ जो प्रत्यक्ष RGB रंग का उपयोग करती हैं, थीम‑रंग अपडेट से नहीं बदलतीं।

निम्न अंत‑से‑अंत उदाहरण एक आकार बनाता है जो `Accent4` का उपयोग करता है, थीम के `Accent4` रंग को लाल में बदलता है, प्रस्तुति को सहेजता है, उसे पुनः खोलता है, और प्रभावी भराव रंग को प्रिंट करता है:

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

क्योंकि आयत `Accent4` से जुड़ी रहती है, इसलिए थीम बदलने के बाद उसका दिखाई देने वाला रंग लाल हो जाता है। यदि आप आकार पर सीधे रंग के साथ योजना रंग को बदल देते हैं, तो बाद में `Accent4` में परिवर्तन उस भराव को नहीं प्रभावित करेंगे।

### **अतिरिक्त पैलेट से रंग उपयोग करें**

PowerPoint थीम रंग से हल्के और गहरे रूपांतर बनाता है, जिसमें रंग रूपांतरण लागू होते हैं। Aspose.Slides इन रूपांतरणों को [ColorTransformOperation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/colortransformoperation/) enumeration के माध्यम से उजागर करता है।

![मुख्य थीम रंग और अतिरिक्त पैलेट से उत्पन्न हल्के व गहरे रंग](additional-palette-colors.png)

**1** - मुख्य थीम रंग।

**2** - मुख्य थीम रंगों से उत्पन्न हल्के और गहरे रूपांतर।

निम्न उदाहरण `Accent4` पर आधारित छह आयतें बनाता है, पाँच पर ल्यूमिनेंस रूपांतरण लागू करता है, और परिणाम सहेजता है:

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

ये रूपांतर थीम रंग पर आधारित रहते हैं। यदि बाद में `Accent4` बदलता है, तो परिवर्तित रंग नई `Accent4` मान से पुनः गणना किए जाएंगे।

### **`SchemeColor` मानों को `IColorScheme` स्लॉट्स से मैप करें**

[SchemeColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/schemecolor/) enumeration `Text1`, `Background1`, `Text2`, और `Background2` का उपयोग करता है, जबकि [IColorScheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icolorscheme/) वही थीम स्लॉट्स को `Dark1`, `Light1`, `Dark2`, और `Light2` के रूप में उजागर करता है। मैपिंग स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ये समान थीम स्लॉट्स के वैकल्पिक नाम हैं; ये ऐसे मान नहीं हैं जो एक रूप से दूसरे में गतिशील रूप से परिवर्तित होते हैं।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट योजना हेडिंग्स के लिए मुख्य फ़ॉन्ट सेट और बॉडी टेक्स्ट के लिए गौण फ़ॉन्ट सेट रखती है। [IFontScheme.getMajor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontscheme/) और [IFontScheme.getMinor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontscheme/) मेथड इन सेटों को उजागर करते हैं।

PowerPoint‑संगत थीम फ़ॉन्ट पहचानकर्ता पाठ फ़ॉर्मेटिंग में उपयोग किए जा सकते हैं:

* `+mn-lt` - बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* `+mj-lt` - हेडिंग फ़ॉन्ट लैटिन (Major Latin Font)
* `+mn-ea` - बॉडी फ़ॉन्ट ईस्ट एशियन (Minor East Asian Font)
* `+mj-ea` - हेडिंग फ़ॉन्ट ईस्ट एशियन (Major East Asian Font)

निम्न उदाहरण एक हेडिंग बनाता है जो मुख्य लैटिन थीम फ़ॉन्ट का उपयोग करता है और एक बॉडी लाइन जो गौण लैटिन थीम फ़ॉन्ट का उपयोग करती है। फिर यह थीम फ़ॉन्ट बदलता है और परिणाम सहेजता है:

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

हेडिंग मुख्य फ़ॉन्ट का अनुसरण करती है और बॉडी टेक्स्ट गौण फ़ॉन्ट का। वह पाठ जिसके पास स्पष्ट फ़ॉन्ट नाम है, थीम पहचानकर्ता के बजाय, थीम फ़ॉन्ट योजना बदलने पर स्वचालित रूप से नहीं बदलेगा।

{{% alert color="info" title="टिप" %}}
प्रस्तुति फ़ॉन्ट के बारे में अधिक जानकारी के लिए देखें [PowerPoint फ़ॉन्ट](/slides/hi/androidjava/powerpoint-fonts/)।
{{% /alert %}}

## **थीम कॉपी या लागू करें**

दो सामान्य कार्यप्रवाह होते हैं, और वे अलग‑अलग समस्याओं को हल करते हैं।

### **स्लाइड्स को स्थानांतरित करते समय स्रोत थीम को संरक्षित रखें**

यदि आप स्लाइड को किसी अन्य प्रस्तुति में ले जाना चाहते हैं और उसकी मूल डिजाइन को बरकरार रखना चाहते हैं, तो स्रोत मास्टर को लक्ष्य प्रस्तुति में [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslidecollection/) के साथ क्लोन करें, फिर क्लोन किए गए मास्टर के साथ स्लाइड को [ISlideCollection.addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidecollection/) के साथ क्लोन करें। इससे मास्टर, उसके लेआउट, और संबंधित थीम एक साथ ले जाई जाती हैं।

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

यह वह पसंदीदा कार्यप्रवाह है जब स्रोत स्लाइड को गंतव्य में समान दिखना चाहिए। केवल सामग्री को किसी असंबंधित गंतव्य मास्टर पर क्लोन करने से थीम‑चालित रंग, फ़ॉन्ट, पृष्ठभूमि, और प्रभाव बदल सकते हैं।

### **मौजूदा स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को अपना वर्तमान मास्टर और लेआउट बनाए रखना है, तो स्रोत थीम से स्लाइड‑स्तर का ओवरराइड प्रारंभ करें। [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/overridetheme/), और [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/overridetheme/) मेथड तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करते हैं।

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

यह अन्य स्लाइडों द्वारा विरासत में मिली थीम को बदले बिना उस स्लाइड द्वारा उपयोग की गई थीम को बदलता है। स्थानीय ओवरराइड को हटाकर विरासत मानों पर वापस जाने के लिए, [OverrideTheme.clear](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/overridetheme/) को कॉल करें।

### **लेआउट पर थीम ओवरराइड लागू करें**

लेआउट‑स्तर का ओवरराइड उन स्लाइडों पर लागू होता है जो उस लेआउट का उपयोग करती हैं, जब तक कि कोई विशेष स्लाइड अपनी स्वयं की ओवरराइड न रखे। समान प्रारंभिक मेथड [LayoutSlideThemeManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/layoutslidethememanager/) के माध्यम से उपयोग किए जा सकते हैं:

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

जब कई लेआउट और स्लाइड एक ही मूल डिज़ाइन साझा करने चाहिए, तो मास्टर या प्रस्तुति‑स्तर की थीम का उपयोग करें, जब एक लेआउट परिवार को अलग शैली चाहिए तो लेआउट ओवरराइड, और केवल वास्तविक अपवादों के लिए स्लाइड ओवरराइड। अत्यधिक स्लाइड‑स्तर ओवरराइड बाद में वैश्विक थीम बदलाव को भविष्यवाणी करने में कठिन बनाते हैं।

## **थीम पृष्ठभूमि शैलियों को अपडेट करें**

थीम की पृष्ठभूमि भराव [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iformatscheme/) में संग्रहीत होते हैं। PowerPoint अपने UI में अधिक पृष्ठभूमि विकल्प प्रस्तुत कर सकता है जितनी भराव परिभाषाएँ इस संग्रह में शारीरिक रूप से संग्रहीत हैं, क्योंकि UI थीम भराव को थीम रंग और अन्य शैली संदर्भों के साथ संयोजित कर सकता है।

![PowerPoint प्रस्तुति थीम के लिए पृष्ठभूमि शैली गैलरी](presentation-design_8.png)

पृष्ठभूमि शैली का उपयोग करने से पहले, संग्रहीत संग्रह और वर्तमान [Background.getStyleIndex](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/background/) को निरीक्षण करें। `0` शैली सूचकांक का अर्थ है कोई थीम भराव नहीं; सकारात्मक मान थीम पृष्ठभूमि‑शैली संदर्भ हैं। यह जावा संग्रह के सीधे इंडेक्सिंग से अलग है, जहाँ `get_Item(0)` पहला संग्रहीत आइटम दर्शाता है। यह मानकर न चलें कि हर प्रस्तुति में समान संख्या में पृष्ठभूमि भराव शैलियां होती हैं।

निम्न उदाहरण उपलब्ध पृष्ठभूमि भराव गिनती की रिपोर्ट करता है, पहले मास्टर को एक थीम बैकग्राउंड रेफ़रेंस असाइन करता है, और प्रस्तुति को सहेजता है:

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

दृश्य परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि और लेआउट या स्लाइड स्तर पर किसी भी पृष्ठभूमि ओवरराइड पर निर्भर करता है। यदि कोई स्लाइड अपनी स्वयं की पृष्ठभूमि उपयोग करती है, तो केवल मास्टर पृष्ठभूमि बदलने से वह स्लाइड नहीं बदलेगी। जब आपको विरासत लागू होने के बाद अंतिम पृष्ठभूमि जानना हो, तो [Background.getEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/background/) का उपयोग करें।

{{% alert color="warning" title="चेतावनी" %}}
शैली सूचकांक को शून्य‑आधारित संग्रह सूचकांक न समझें। साथ ही एक फ़ाइल से शैली संख्या को हार्ड‑कोड करके दूसरे फ़ाइल में समान उपस्थिति मानने से बचें; थीम शैली परिभाषाएँ प्रस्तुति‑विशिष्ट होती हैं।
{{% /alert %}}

{{% alert color="info" title="टिप" %}}
सीधे पृष्ठभूमि फ़ॉर्मेटिंग और पृष्ठभूमि विरासत के लिए देखें [Presentation Background](/slides/hi/androidjava/presentation-background/)।
{{% /alert %}}

## **थीम प्रभाव अपडेट करें**

एक थीम फ़ॉर्मेट योजना अलग‑अलग भराव, रेखा, और प्रभाव शैली संग्रहों को उजागर करती है, जिन्हें क्रमशः [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iformatscheme/), और [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iformatscheme/) के माध्यम से एक्सेस किया जाता है। सामान्य Office थीम अक्सर तीन प्रमुख शैली प्रविष्टियों को शामिल करती हैं, जो दृश्य रूप से सूक्ष्म, मध्यम, और तीव्र फ़ॉर्मेटिंग से मेल खाती हैं, लेकिन कोड को प्रत्येक संग्रह का निरीक्षण करना चाहिए न कि स्थिर संख्या मान लेना।

![एक ही आकार पर लागू सूक्ष्म, मध्यम, और तीव्र थीम प्रभाव](presentation-design_10.png)

जब आप इन संग्रहों को जावा में एक्सेस करते हैं, तो संग्रह सूचकांक शून्य‑आधारित होता है: `get_Item(0)` पहला संग्रहीत शैली है और `get_Item(2)` तीसरा। कोई आकार का शैली‑संदर्भ सूचकांक एक अलग अवधारणा है, जिसे [IShapeStyle](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapestyle/) के माध्यम से उजागर किया जाता है। थीम शैली को संशोधित करने से उन आकारों पर असर पड़ता है जो उस थीम शैली को संदर्भित करते हैं; सीधे फ़ॉर्मेटिंग वाले आकार अपरिवर्तित रह सकते हैं।

निम्न उदाहरण जाँचता है कि आवश्यक शैली प्रविष्टियाँ मौजूद हैं, पहला रेखा शैली बदलता है, तीसरा भराव शैली बदलता है, तीसरे प्रभाव शैली में बाहरी शैडो सक्षम करता है, और परिणाम सहेजता है:

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

इन स्लॉट्स को संदर्भित करने वाले आकारों के लिए, पहला थीम रेखा शैली लाल हो जाता है, तीसरा थीम भराव शैली ठोस फ़ॉरेस्ट ग्रीन, और तीसरे प्रभाव शैली में 10 पॉइंट की दूरी वाला बाहरी शैडो जोड़ दिया जाता है। सटीक दृश्य परिणाम अभी भी इस बात पर निर्भर करता है कि प्रत्येक आकार कौन‑से शैली स्लॉट को संदर्भित करता है और क्या सीधे फ़ॉर्मेटिंग ने थीम को ओवरराइड किया है।

![लाइन, भराव, और शैडो सेटिंग्स बदलने के बाद थीम प्रभाव शैलियाँ](presentation-design_11.png)

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम ऑब्जेक्ट बताते हैं कि किसी विशेष स्तर पर क्या परिभाषित है। प्रभावी मान बताते हैं कि विरासत और स्थानीय ओवरराइड के बाद स्लाइड या आकार वास्तव में क्या उपयोग करता है। स्लाइड के लिए, [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseoverridethememanager/) को कॉल करें। पृष्ठभूमि के लिए, [Background.getEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/background/) का उपयोग करें, और भराव के लिए, [FillFormat.getEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fillformat/) का उपयोग करें।

निम्न उदाहरण एक स्लाइड से प्रभावी थीम, पृष्ठभूमि, और पहली आकार भराव को पढ़ता है:

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

रेंडरिंग डायग्नॉस्टिक्स, वैलिडेशन, और तुलना के लिए प्रभावी डेटा का उपयोग करें। यदि आप केवल [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) को निरीक्षण करते हैं, तो आप किसी मास्टर, लेआउट, स्लाइड, या आकार ओवरराइड को मिस कर सकते हैं जो अंतिम रूप को बदलता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं थीम को केवल एक स्लाइड पर लागू कर सकता हूँ बिना मास्टर बदले?**

हाँ। स्लाइड के [SlideThemeManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slidethememanager/) का उपयोग करें और उसकी ओवरराइड थीम को प्रारंभ करें। परिवर्तन केवल उस स्लाइड तक सीमित रहेगा; अन्य स्लाइडें अपनी मौजूदा थीम विरासत में लेती रहेंगी।

**एक प्रस्तुति से दूसरी प्रस्तुति तक थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

जब स्लाइड को ले जा रहे हों और उसके स्रोत स्वरूप को बनाए रखना हो, तो स्रोत मास्टर को गंतव्य में क्लोन करें और उस क्लोन किए गए मास्टर के साथ स्लाइड को [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslidecollection/) और [ISlideCollection.addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidecollection/) से क्लोन करें। यह मास्टर, लेआउट, और थीम को साथ रखता है।

**विरासत और ओवरराइड के बाद प्रभावी मान कैसे देखें?**

स्लाइड या लेआउट थीम के लिए [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseoverridethememanager/) और फॉर्मेट ऑब्जेक्ट जैसे [Background.getEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/background/) और [FillFormat.getEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fillformat/) के संबंधित प्रभावी‑डेटा मेथड का उपयोग करें। ये API विरासत और ओवरराइड लागू होने के बाद हल किए गए मान लौटाते हैं।