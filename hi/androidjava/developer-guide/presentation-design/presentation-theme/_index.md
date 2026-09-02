---
title: "एंड्रॉइड पर प्रेज़ेंटेशन थीम्स को प्रबंधित करें"
linktitle: "प्रेज़ेंटेशन थीम"
type: docs
weight: 10
url: /hi/androidjava/presentation-theme/
keywords:
- "PowerPoint थीम"
- "प्रस्तुति थीम"
- "स्लाइड थीम"
- "थीम सेट करें"
- "थीम बदलें"
- "थीम प्रबंधित करें"
- "बाहरी थीम"
- "THMX"
- "थीम रंग"
- "अतिरिक्त पैलेट"
- "थीम फ़ॉन्ट"
- "थीम शैली"
- "थीम प्रभाव"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "एंड्रॉइड"
- "Java"
- "Aspose.Slides"
description: "एंड्रॉइड के लिए Aspose.Slides में जावा के माध्यम से मास्टर प्रेज़ेंटेशन थीम्स को बनाना, कस्टमाइज़ करना और PowerPoint फाइलों को सुसंगत ब्रांडिंग के साथ परिवर्तित करना।"
---
## **परिचय**

एक प्रस्तुति थीम रंगों, फ़ॉन्ट्स, बैकग्राउंड शैलियों, फ़िल्स, लाइनों और इफ़ेक्ट्स का समन्वित सेट निर्धारित करती है। थीम‑सचेत ऑब्जेक्ट्स इन साझा परिभाषाओं को संदर्भित करते हैं न कि प्रत्येक दृश्य गुण को स्थिर मान के रूप में संग्रहीत करते हैं, इसलिए थीम बदलने से कई ऑब्जेक्ट्स एक साथ अपडेट हो सकते हैं।

Aspose.Slides में, प्रस्तुति‑स्तर की थीम उपलब्ध है [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) के माध्यम से। एक प्रस्तुति में निचले स्तरों पर भी थीम ओवरराइड हो सकते हैं। एक मास्टर [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/masterthememanager/) के माध्यम से प्रस्तुति थीम को ओवरराइड कर सकता है, जबकि एक लेआउट या व्यक्तिगत स्लाइड [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseoverridethememanager/) के माध्यम से अपनी विरासत में मिली थीम को ओवरराइड कर सकती है। व्यावहारिक रूप से, एक स्लाइड के लिए प्रभावी थीम इस विरासत श्रृंखला के माध्यम से निर्धारित होती है: प्रस्तुति थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![थीम घटक: रंग, फ़ॉन्ट, बैकग्राउंड शैलियाँ और इफ़ेक्ट्स](theme-constituents.png)

नीचे के अनुभाग सबसे सामान्य थीम कार्यप्रवाह दिखाते हैं: थीम का निरीक्षण, रंग और फ़ॉन्ट बदलना, थीम को कॉपी या लागू करना, बैकग्राउंड और इफ़ेक्ट शैलियों को अपडेट करना, और विरासत और ओवरराइड के बाद प्रभावी मानों को पढ़ना।

## **थीम का निरीक्षण करें**

[MasterTheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mastertheme/) ऑब्जेक्ट थीम की रंग योजना, फ़ॉन्ट योजना, और फ़ॉर्मेट योजना को [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mastertheme/), और [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mastertheme/) के माध्यम से उजागर करता है। इन संग्रहों को बदलने से पहले निरीक्षण करना विशेष रूप से उपयोगी होता है जब प्रस्तुति बाहरी स्रोत से आयी हो, क्योंकि शैली प्रविष्टियों की संख्या और सामग्री भिन्न हो सकती है।

निम्न उदाहरण मुख्य थीम गुण पढ़ता है और बताता है कि थीम में कितनी बैकग्राउंड, फ़िल, लाइन और इफ़ेक्ट शैलियां संग्रहीत हैं:

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

यदि किसी फ़ाइल में कई मास्टर उपयोग किए गए हैं, तो यह मानें नहीं कि प्रत्येक स्लाइड की प्रभावी थीम समान है। स्लाइड से संबंधित मास्टर का निरीक्षण करें, और लेआउट या स्लाइड ओवरराइड मौजूद होने पर इस लेख में बाद में दिखाए गए प्रभावी‑थीम कार्यप्रवाह का उपयोग करें।

## **थीम के रंग बदलें**

थीम‑सचेत फ़िल, लाइन और टेक्स्ट [SchemeColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/schemecolor/) enumeration से एक तर्कसंगत रंग को संदर्भित कर सकता है। जब आप [IColorScheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icolorscheme/) में संबंधित प्रविष्टि बदलते हैं, तो सभी ऑब्जेक्ट्स जो अभी भी उस थीम रंग को संदर्भित करते हैं, नए मान के विरुद्ध हल हो जाएंगे। सीधे RGB रंग का उपयोग करने वाले ऑब्जेक्ट्स थीम‑रंग अपडेट से नहीं बदलते।

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

चूँकि आयत `Accent4` से जुड़ी रहती है, थीम बदलने के बाद उसका दिखने वाला रंग लाल हो जाता है। यदि आप रूपरेखा में स्कीम रंग को सीधे रंग से बदल देते हैं, तो बाद में `Accent4` में बदलाव उस फ़िल को और नहीं प्रभावित करेंगे।

### **अतिरिक्त पैलेट से रंगों का उपयोग करें**

PowerPoint थीम रंग से हल्के और गहरे वैरिएंट्स उत्पन्न करता है रंग रूपांतरणों को लागू करके। Aspose.Slides इन रूपांतरणों को [ColorTransformOperation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/colortransformoperation/) enumeration के माध्यम से उजागर करता है।

![मुख्य थीम रंग और अतिरिक्त पैलेट से उत्पन्न हल्के तथा गहरे रंग](additional-palette-colors.png)

**1** - मुख्य थीम रंग।

**2** - मुख्य थीम रंगों से उत्पन्न हल्के और गहरे वैरिएंट्स।

निम्न उदाहरण `Accent4` पर आधारित छह आयत बनाता है, उनमें से पाँच पर ल्यूमिनेंस रूपांतरण लागू करता है, और परिणाम को सहेजता है:

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

ये वैरिएंट्स थीम रंग पर आधारित रहते हैं। यदि बाद में `Accent4` बदलता है, तो रूपांतरित रंग नए `Accent4` मान से पुनः गणना किए जाएंगे।

### **`SchemeColor` मानों को `IColorScheme` स्लॉट्स में मानचित्रित करें**

[SchemeColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/schemecolor/) enumeration `Text1`, `Background1`, `Text2`, और `Background2` का उपयोग करती है, जबकि [IColorScheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icolorscheme/) वही थीम स्लॉट्स `Dark1`, `Light1`, `Dark2`, और `Light2` के रूप में उजागर करता है। मानचित्रण स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ये समान थीम स्लॉट्स के वैकल्पिक नाम हैं; ये ऐसे मान नहीं हैं जो गतिशील रूप से एक रूप से दूसरे में बदलते हैं।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट योजना में हेडिंग के लिए प्रमुख फ़ॉन्ट सेट और बॉडी टेक्स्ट के लिए लघु फ़ॉन्ट सेट होता है। `[IFontScheme.getMajor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontscheme/)` और `[IFontScheme.getMinor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontscheme/)` मेथड इन सेटों को उजागर करते हैं।

PowerPoint‑संगत थीम फ़ॉन्ट पहचानकर्ता टेक्स्ट फ़ॉर्मेटिंग में उपयोग किए जा सकते हैं:

* `+mn-lt` - बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* `+mj-lt` - हेडिंग फ़ॉन्ट लैटिन (Major Latin Font)
* `+mn-ea` - बॉडी फ़ॉन्ट ईस्ट एशियन (Minor East Asian Font)
* `+mj-ea` - हेडिंग फ़ॉन्ट ईस्ट एशियन (Major East Asian Font)

निम्न उदाहरण एक हेडिंग बनाता है जो प्रमुख लैटिन थीम फ़ॉन्ट का उपयोग करता है और एक बॉडी लाइन जो लघु लैटिन थीम फ़ॉन्ट का उपयोग करती है। फिर यह थीम फ़ॉन्ट को बदलता है और परिणाम सहेजता है:

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

हेडिंग प्रमुख फ़ॉन्ट का अनुसरण करती है और बॉडी टेक्स्ट लघु फ़ॉन्ट का। स्पष्ट फ़ॉन्ट नाम वाले टेक्स्ट, जो थीम पहचानकर्ता नहीं है, थीम फ़ॉन्ट योजना बदलने पर स्वतः नहीं बदलेंगे।

मुख्य और लघु फ़ॉन्ट संग्रह में व्यक्तिगत लेखन प्रणालियों, जैसे Cyrillic, Arabic, Japanese, Georgian, और Thaana के लिए फ़ॉन्ट मैपिंग भी हो सकती है। इन्हें निरीक्षण, जोड़ने, बदलने या हटाने के लिए देखें [Script‑Specific Theme Fonts](/slides/hi/androidjava/script-specific-font-mappings/)।

{{% alert color="info" title="Tip" %}}
प्रस्तुति फ़ॉन्ट के बारे में अधिक जानकारी के लिए देखें [PowerPoint Fonts](/slides/hi/androidjava/powerpoint-fonts/)।
{{% /alert %}}

## **थीम कॉपी या लागू करें**

नीचे के कार्यप्रवाह विभिन्न थीम‑संबंधी समस्याओं को हल करते हैं।

### **बाहरी थीम को मास्टर की निर्भर स्लाइड्स पर लागू करें**

जब आपके पास PowerPoint थीम फ़ाइल (`.thmx`) हो और आप किसी विशिष्ट मास्टर पर निर्भर सभी स्लाइड्स को पुनः शैलीबद्ध करना चाहते हों, तो उपयोग करें [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslide/)। चयनित मास्टर को [Presentation.getMasters](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) संग्रह से चुनें, जो [IMasterSlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslidecollection/) लागू करता है, और मेथड को थीम फ़ाइल पाथ पास करें।

मेथड निम्नलिखित कार्य करता है:

1. चयनित मास्टर के आधार पर एक नया मास्टर स्लाइड बनाता है।
1. बाहरी थीम को नए मास्टर पर लागू करता है।
1. पहले चयनित मास्टर पर निर्भर सभी स्लाइड्स को नए मास्टर को असाइन करता है।
1. नए बनाए गए [IMasterSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslide/) को लौटाता है।

निम्न उदाहरण पहले मास्टर पर निर्भर स्लाइड्स पर बाहरी थीम लागू करता है और प्रस्तुति को सहेजता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide selectedMaster = presentation.getMasters().get_Item(0);
    IMasterSlide themedMaster = selectedMaster.applyExternalThemeToDependingSlides("corporate-theme.thmx");

    System.out.println("Created master: " + themedMaster.getName());
    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

एक अमान्य, भ्रष्ट, या असमर्थित थीम से [PptxReadException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pptxreadexception/) उत्पन्न हो सकता है। उपयोगकर्ता द्वारा प्रदान किए गए पाथ को मान्य करें, फ़ाइल‑सिस्टम पहुँच विफलताओं को संभालें, और थीम सफलतापूर्वक लागू होने के बाद ही प्रस्तुति सहेजें।

केवल उन स्लाइड्स को पुनः असाइन किया जाता है जो चयनित मास्टर पर निर्भर थीं। अन्य मास्टर से जुड़ी स्लाइड्स अपने मौजूदा मास्टर और थीम को बनाए रखती हैं। थीम‑सचेत रंग, फ़ॉन्ट, फ़िल, लाइन, बैकग्राउंड और इफ़ेक्ट्स बाहरी थीम के विरुद्ध हल हो जाते हैं। सीधे असाइन किए गए रंग, फ़ॉन्ट, फ़िल और अन्य स्पष्ट फ़ॉर्मेटिंग अपरिवर्तित रह सकते हैं। लेआउट‑स्तर और स्लाइड‑स्तर ओवरराइड भी नए मास्टर से विरासत में मिले मूल्यों पर प्राधान्य ले सकते हैं।

थीम ऐसे फ़ॉन्ट का संदर्भ दे सकती है जो रन‑टाइम पर्यावरण में उपलब्ध न हों। निरंतर रेंडरिंग और एक्सपोर्ट के लिए आवश्यक फ़ॉन्ट इंस्टॉल करें, उन्हें [कस्टम फ़ॉन्ट स्रोत](/slides/hi/androidjava/custom-font/) के माध्यम से प्रदान करें, या [फ़ॉन्ट प्रतिस्थापन](/slides/hi/androidjava/font-substitution/) कॉन्फ़िगर करें।

यह एक प्रत्यक्ष मास्टर‑स्तर कार्यप्रवाह है: मेथड एक `.thmx` फ़ाइल पाथ स्वीकार करता है और स्लाइड‑स्तर या लेआउट‑स्तर थीम ओवरराइड को मैन्युअल रूप से बनाने की आवश्यकता नहीं होती।

### **बहु‑मास्टर प्रस्तुति में विभिन्न बाहरी थीम लागू करें**

जब प्रासंगिक मास्टर पहले से ज्ञात न हो, तो इसे प्रतिनिधि स्लाइड से प्राप्त करें [ISlide.getLayoutSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/) और [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutslide/) के माध्यम से। थीम लागू करने से पहले मूल मास्टर संदर्भों को संग्रहीत करें क्योंकि प्रत्येक कॉल प्रस्तुति में एक नया मास्टर बनाता है।

निम्न उदाहरण दो अनुभागों की स्लाइड्स का उपयोग करके उनके मास्टर ढूंढता है और प्रत्येक समूह पर अलग‑अलग बाहरी थीम लागू करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("multi-master-presentation.pptx");
try {
    if (presentation.getSlides().size() < 5) {
        System.out.println("The presentation does not contain the expected representative slides.");
    } else {
        IMasterSlide firstGroupMaster = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide();
        IMasterSlide secondGroupMaster = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide();

        if (firstGroupMaster.getSlideId() == secondGroupMaster.getSlideId()) {
            System.out.println("The representative slides use the same master.");
        } else {
            IMasterSlide firstThemedMaster = firstGroupMaster.applyExternalThemeToDependingSlides("blue-theme.thmx");
            IMasterSlide secondThemedMaster = secondGroupMaster.applyExternalThemeToDependingSlides("green-theme.thmx");

            System.out.println("First themed master: " + firstThemedMaster.getName());
            System.out.println("Second themed master: " + secondThemedMaster.getName());
            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx);
        }
    }
} finally {
    presentation.dispose();
}
```

पहला कॉल केवल `firstGroupMaster` पर निर्भर स्लाइड्स को प्रभावित करता है, और दूसरा कॉल केवल `secondGroupMaster` पर निर्भर स्लाइड्स को प्रभावित करता है। अन्य मास्टर से जुड़ी स्लाइड्स पुनः शैलीबद्ध नहीं होतीं।

### **स्लाइड्स को स्थानांतरित करते समय स्रोत थीम को संरक्षित रखें**

यदि आप किसी स्लाइड को अन्य प्रस्तुति में स्थानांतरित करना चाहते हैं और उसकी मूल डिज़ाइन को बनाए रखना चाहते हैं, तो स्रोत मास्टर को लक्ष्य प्रस्तुति में [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslidecollection/) के द्वारा क्लोन करें, फिर स्लाइड को क्लोन करें [ISlideCollection.addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidecollection/) और क्लोन किए गए मास्टर के साथ। यह मास्टर, उसके लेआउट और संबंधित थीम को साथ ले जाता है।

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

यह वह वर्कफ़्लो है जब स्रोत स्लाइड को लक्ष्य में समान रूप से दिखना आवश्यक हो। केवल सामग्री को असंबद्ध लक्ष्य मास्टर पर क्लोन करने से थीम‑चालित रंग, फ़ॉन्ट, बैकग्राउंड और इफ़ेक्ट बदल सकते हैं।

### **मौजूदा स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को अपने मौजूदा मास्टर और लेआउट पर बनाए रखना है, तो स्रोत थीम से स्लाइड‑स्तर ओवरराइड प्रारंभ करें। [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/overridetheme/), और [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/overridetheme/) मेथड तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करते हैं।

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

यह अन्य स्लाइड्स द्वारा विरासत में मिलने वाली थीम को बदले बिना उस स्लाइड की थीम बदलता है। स्थानीय ओवरराइड हटाने और विरासत मानों पर लौटने के लिए कॉल करें [OverrideTheme.clear](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/overridetheme/)।

### **लेआउट पर थीम ओवरराइड लागू करें**

लेआउट‑स्तर ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट का उपयोग करती हैं, जब तक कि किसी विशेष स्लाइड की अपनी ओवरराइड न हो। वही प्रारंभिक मेथड [LayoutSlideThemeManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/layoutslidethememanager/) के माध्यम से उपयोग किए जा सकते हैं:

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

जब कई लेआउट और स्लाइड एक ही बेस डिज़ाइन साझा करते हैं, तो मास्टर या प्रस्तुति‑स्तर थीम का उपयोग करें; जब केवल एक लेआउट समूह को अलग शैली चाहिए, तो लेआउट ओवरराइड उपयोग करें; और वास्तविक अपवादों के लिए केवल स्लाइड ओवरराइड उपयोग करें। अत्यधिक स्लाइड‑स्तर ओवरराइड बाद में ग्लोबल थीम बदलावों को पूर्वानुमानित करना कठिन बना देते हैं।

## **थीम बैकग्राउंड शैलियों को अपडेट करें**

थीम की बैकग्राउंड फ़िल्स को [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iformatscheme/) में संग्रहीत किया जाता है। PowerPoint UI में उपलब्ध बैकग्राउंड विकल्प इस संग्रह में भौतिक रूप से संग्रहीत फ़िल परिभाषाओं से अधिक हो सकते हैं, क्योंकि UI थीम फ़िल को थीम रंग और अन्य शैली संदर्भों के साथ मिलाकर दिखा सकता है।

![प्रेज़ेंटेशन थीम के लिए PowerPoint बैकग्राउंड शैली गैलरी](presentation-design_8.png)

बैकग्राउंड शैली का उपयोग करने से पहले, संग्रहीत संग्रह और वर्तमान [Background.getStyleIndex](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/background/) को निरीक्षण करें। `0` का शैली सूचकांक मतलब कोई थीम फ़िल नहीं; सकारात्मक मान थीम बैकग्राउंड‑शैली संदर्भ होते हैं। यह Java संग्रह को सीधे इंडेक्स करने से अलग है, जहाँ `get_Item(0)` पहला संग्रहीत आइटम होता है। यह मानें नहीं कि प्रत्येक प्रस्तुति में समान संख्या में बैकग्राउंड फ़िल शैलियां हों।

निम्न उदाहरण उपलब्ध बैकग्राउंड फ़िल गिनती रिपोर्ट करता है, पहले मास्टर को थीम‑बैकग्राउंड संदर्भ असाइन करता है, और प्रस्तुति को सहेजता है:

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

दिखायी देने वाला परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि और लेआउट या स्लाइड स्तर पर किसी भी बैकग्राउंड ओवरराइड पर निर्भर करता है। यदि कोई स्लाइड अपनी स्वयं की बैकग्राउंड उपयोग करती है, तो केवल मास्टर बैकग्राउंड बदलने से वह स्लाइड नहीं बदलेगी। विरासत लागू होने के बाद अंतिम बैकग्राउंड जानने के लिए उपयोग करें [Background.getEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/background/)।

{{% alert color="warning" title="Warning" %}}
शैली सूचकांक को शून्य‑आधारित संग्रह सूचकांक न समझें। किसी एक फ़ाइल से शैली संख्या को हार्ड‑कोड न करें और यह मान कर न चलें कि वह दूसरी फ़ाइल में समान दिखेगी; थीम शैली परिभाषाएँ प्रस्तुति‑विशिष्ट होती हैं।
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
सीधे बैकग्राउंड फ़ॉर्मैटिंग और बैकग्राउंड विरासत के लिए देखें [Presentation Background](/slides/hi/androidjava/presentation-background/)।
{{% /alert %}}

## **थीम इफ़ेक्ट्स को अपडेट करें**

थीम फ़ॉर्मेट योजना में अलग‑अलग फ़िल, लाइन और इफ़ेक्ट शैली संग्रह होते हैं, जिन्हें [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iformatscheme/), और [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iformatscheme/) द्वारा उजागर किया जाता है। सामान्य Office थीम में अक्सर तीन प्रमुख शैली प्रविष्टियां होती हैं जो दृश्य रूप से सूक्ष्म, मध्यम और तीव्र फ़ॉर्मेटिंग से मेल खाती हैं, लेकिन कोड को प्रत्येक संग्रह की जांच करनी चाहिए न कि स्थिर संख्या मान लेनी चाहिए।

![समान आकार पर सूक्ष्म, मध्यम और तीव्र थीम इफ़ेक्ट्स लागू किए गए](presentation-design_10.png)

जब आप इन संग्रहों को Java में एक्सेस करते हैं, तो संग्रह सूचकांक शून्य‑आधारित होता है: `get_Item(0)` पहला संग्रहीत शैली है और `get_Item(2)` तीसरा। आकार की शैली‑संदर्भ सूचकांक एक अलग अवधारणा है, जिसे [IShapeStyle](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapestyle/) द्वारा उजागर किया जाता है। थीम शैली में संशोधन उन आकारों को प्रभावित करता है जो उस थीम शैली को संदर्भित करते हैं; सीधे फ़ॉर्मैटिंग वाले आकार अपरिवर्तित रह सकते हैं।

निम्न उदाहरण जांचता है कि आवश्यक शैली प्रविष्टियां मौजूद हैं, पहली लाइन शैली बदलता है, तीसरी फ़िल शैली बदलता है, तीसरी इफ़ेक्ट शैली में बाहरी शैडो सक्षम करता है, और परिणाम सहेजता है:

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

इन स्लॉट्स को संदर्भित करने वाले आकारों के लिए, पहली थीम लाइन शैली लाल हो जाती है, तीसरी थीम फ़िल शैली ठोस फ़ॉरेस्ट ग्रीन हो जाती है, और तीसरी इफ़ेक्ट शैली को बाहर की छाया 10 पॉइंट की दूरी के साथ मिलती है। सटीक दृश्य परिणाम अभी भी इस बात पर निर्भर करता है कि प्रत्येक आकार कौन से शैली स्लॉट को संदर्भित करता है और क्या प्रत्यक्ष फ़ॉर्मैटिंग थीम को ओवरराइड करती है।

![लाइन, फ़िल और शैडो सेटिंग्स बदलने के बाद थीम इफ़ेक्ट शैलियां](presentation-design_11.png)

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम ऑब्जेक्ट केवल यह बताते हैं कि किसी विशिष्ट स्तर पर क्या परिभाषित है। प्रभावी मान बताते हैं कि कोई स्लाइड या आकार विरासत और स्थानीय ओवरराइड के बाद वास्तव में क्या उपयोग करता है। स्लाइड के लिए कॉल करें [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseoverridethememanager/)。 बैकग्राउंड के लिए उपयोग करें [Background.getEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/background/), और फ़िल के लिए उपयोग करें [FillFormat.getEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fillformat/)।

निम्न उदाहरण स्लाइड से प्रभावी थीम, बैकग्राउंड और पहले आकार की फ़िल पढ़ता है:

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

रेंडरिंग निदान, मान्यकरण और तुलना के लिए प्रभावी डेटा का उपयोग करें। यदि आप केवल [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) का निरीक्षण करते हैं, तो आप किसी मास्टर, लेआउट, स्लाइड या आकार ओवरराइड को चूक सकते हैं जो अंतिम उपस्थिति को बदलता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या बाहरी थीम लागू करने से प्रस्तुति की प्रत्येक स्लाइड प्रभावित होती है?**

नहीं। [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslide/) केवल उन स्लाइड्स को पुनः असाइन करता है जो चयनित मास्टर पर निर्भर थीं। अन्य मास्टर का उपयोग करने वाली स्लाइड्स अपने मौजूदा थीम को बरकरार रखती हैं।

**क्या मैं मास्टर बदले बिना एकल स्लाइड पर थीम लागू कर सकता हूँ?**

हाँ। स्लाइड के [SlideThemeManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slidethememanager/) का उपयोग करें और उसका ओवरराइड थीम प्रारंभ करें। परिवर्तन केवल उस स्लाइड तक सीमित रहता है; अन्य स्लाइड्स अपने मौजूदा थीम को विरासत में लेती रहती हैं।

**एक प्रस्तुति से दूसरी में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

जब स्लाइड को स्थानांतरित करते समय उसकी मूल उपस्थिति को संरक्षित करना हो, तो स्रोत मास्टर को लक्ष्य में क्लोन करें [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslidecollection/) के द्वारा और फिर स्लाइड को उसी मास्टर के साथ क्लोन करें [ISlideCollection.addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidecollection/) के द्वारा। यह मास्टर, उसके लेआउट और थीम को एक साथ रखता है।

**मैं विरासत और ओवरराइड के बाद प्रभावी मान कैसे देख सकता हूँ?**

स्लाइड या लेआउट थीम के लिए उपयोग करें [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseoverridethememanager/) और फ़ॉर्मेट ऑब्जेक्ट जैसे [Background.getEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/background/) और [FillFormat.getEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fillformat/) के संबंधित प्रभावी‑डेटा मेथड। ये API विरासत और ओवरराइड लागू होने के बाद हल किए गए मान लौटाते हैं।