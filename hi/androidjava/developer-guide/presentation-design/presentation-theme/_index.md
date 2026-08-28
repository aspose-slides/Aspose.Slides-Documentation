---
title: Android पर प्रस्तुति थीम प्रबंधित करें
linktitle: प्रेजेंटेशन थीम
type: docs
weight: 10
url: /hi/androidjava/presentation-theme/
keywords:
- PowerPoint थीम
- प्रेजेंटेशन थीम
- स्लाइड थीम
- थीम सेट करें
- थीम बदलें
- थीम प्रबंधित करें
- बाहरी थीम
- THMX
- थीम रंग
- अतिरिक्त पैलेट
- थीम फ़ॉन्ट
- थीम शैली
- थीम प्रभाव
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android में Java के माध्यम से प्रमुख प्रेजेंटेशन थीम को नियंत्रित करके PowerPoint फ़ाइलों को सुसंगत ब्रांडिंग के साथ बनाना, अनुकूलित करना और परिवर्तित करना।"
---
## **परिचय**

एक प्रस्तुति थीम रंगों, फ़ॉन्टों, पृष्ठभूमि शैलियों, भरावों, रेखाओं और प्रभावों का समन्वित सेट परिभाषित करती है। थीम‑सचेत ऑब्जेक्ट इन साझी परिभाषाओं को संदर्भित करते हैं न कि प्रत्येक दृश्य गुण को स्थायी मान के रूप में संग्रहीत करते हैं, इसलिए थीम बदलने पर कई ऑब्जेक्ट एक साथ अपडेट हो सकते हैं।

Aspose.Slides में प्रस्तुति‑स्तर की थीम को [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) के माध्यम से प्राप्त किया जा सकता है। एक प्रस्तुति में निम्न स्तरों पर भी थीम ओवरराइड हो सकते हैं। एक मास्टर अपने प्रस्तुति थीम को [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/masterthememanager/) के माध्यम से ओवरराइड कर सकता है, जबकि लेआउट या व्यक्तिगत स्लाइड अपनी विरासत में मिली थीम को [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseoverridethememanager/) से ओवरराइड कर सकते हैं। व्यावहारिक रूप से, किसी स्लाइड के लिए प्रभावी थीम इस विरासत श्रृंखला से तय होती है: प्रस्तुति थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![थीम घटक: रंग, फ़ॉन्ट, पृष्ठभूमि शैलियाँ और प्रभाव](theme-constituents.png)

नीचे के अनुभाग में सबसे आम थीम कार्य‑प्रवाह दिखाए गए हैं: थीम का निरीक्षण, रंग और फ़ॉन्ट बदलना, थीम को कॉपी या लागू करना, पृष्ठभूमि और प्रभाव शैलियों को अपडेट करना, और विरासत व ओवरराइड के बाद प्रभावी मान पढ़ना।

## **एक थीम देखें**

[MasterTheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mastertheme/) ऑब्जेक्ट अपनी रंग योजना, फ़ॉन्ट योजना और फॉर्मेट योजना को क्रमशः [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mastertheme/) तथा [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/mastertheme/) के माध्यम से उजागर करता है। इन्हें बदलने से पहले इन संग्रहों की जाँच करना विशेष रूप से उपयोगी होता है जब प्रस्तुति बाहरी स्रोत से आती है क्योंकि शैली प्रविष्टियों की संख्या और सामग्री में विविधता हो सकती है।

निम्न उदाहरण मुख्य थीम गुण पढ़ता है और रिपोर्ट करता है कि थीम में कितने पृष्ठभूमि, भराव, रेखा और प्रभाव शैलियाँ संग्रहीत हैं:

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

यदि फ़ाइल में कई मास्टर उपयोग होते हैं, तो यह न मानें कि प्रत्येक स्लाइड की प्रभावी थीम समान है। स्लाइड से संबंधित मास्टर को देखें, और लेआउट या स्लाइड ओवरराइड मौजूद होने पर बाद में दिखाए गए प्रभावी‑थीम कार्य‑प्रवाह को अपनाएँ।

## **थीम रंग बदलें**

थीम‑सचेत भराव, रेखाएँ और पाठ [SchemeColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/schemecolor/) enumeration में मौजूद एक तर्कसंगत रंग को संदर्भित कर सकते हैं। जब आप [IColorScheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icolorscheme/) में संबंधित प्रविष्टि बदलते हैं, तो सभी ऑब्जेक्ट जो अभी भी उस थीम रंग को संदर्भित कर रहे हैं, नया मान प्राप्त करेंगे। सीधे RGB रंग उपयोग करने वाले ऑब्जेक्ट थीम‑रंग अपडेट से नहीं बदलेंगे।

निम्न संपूर्ण उदाहरण एक आकृति बनाता है जो `Accent4` का उपयोग करती है, थीम के `Accent4` रंग को लाल में बदलता है, प्रस्तुति को सहेजता है, पुनः खोलता है, और प्रभावी भराव रंग को प्रिंट करता है:

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

क्योंकि आयत `Accent4` से जुड़ी रहती है, थीम बदलने के बाद उसका दृश्य रंग लाल हो जाता है। यदि आप स्कीम रंग को आकृति पर सीधे रंग से बदलते हैं, तो बाद में `Accent4` में किए गए परिवर्तन उस भराव को प्रभावित नहीं करेंगे।

### **अतिरिक्त पैलेट से रंग उपयोग करना**

PowerPoint थीम रंग से हल्के और गहरे वैरिएंट उत्पन्न करने के लिए रंग रूपांतरण लागू करती है। Aspose.Slides इन रूपांतरणों को [ColorTransformOperation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/colortransformoperation/) enumeration के माध्यम से उजागर करता है।

![मुख्य थीम रंग तथा अतिरिक्त पैलेट से उत्पन्न हल्के व गहरे रंग](additional-palette-colors.png)

**1** – मुख्य थीम रंग।

**2** – मुख्य थीम रंग से उत्पन्न हल्के और गहरे वैरिएंट।

निम्न उदाहरण `Accent4` पर आधारित छह आयतें बनाता है, उनमें से पाँच पर चमक रूपांतरण लागू करता है, और परिणाम सहेजता है:

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

ये वैरिएंट थीम रंग पर आधारित रहते हैं। यदि बाद में `Accent4` बदला जाता है, तो रूपांतरणित रंग नया `Accent4` मान से पुनः गणना होते हैं।

### **`SchemeColor` मानों को `IColorScheme` स्लॉट्स से मैप करना**

[SchemeColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/schemecolor/) enumeration `Text1`, `Background1`, `Text2` और `Background2` का उपयोग करता है, जबकि [IColorScheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icolorscheme/) समान थीम स्लॉट को `Dark1`, `Light1`, `Dark2` और `Light2` के रूप में उजागर करता है। मैपिंग स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ये वही थीम स्लॉट के वैकल्पिक नाम हैं; इन्हें किसी रूप में गतिशील रूप से परिवर्तित नहीं किया जाता।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट योजना में शीर्षक (major) फ़ॉन्ट सेट और शरीर (minor) फ़ॉन्ट सेट होता है। [IFontScheme.getMajor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontscheme/) और [IFontScheme.getMinor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifontscheme/) विधियां इन सेटों को उजागर करती हैं।

PowerPoint‑अनुकूल थीम फ़ॉन्ट पहचानकर्ताओं का उपयोग पाठ स्वरूपण में किया जा सकता है:

* `+mn-lt` – बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* `+mj-lt` – हेडिंग फ़ॉन्ट लैटिन (Major Latin Font)
* `+mn-ea` – बॉडी फ़ॉन्ट ईस्ट एशियन (Minor East Asian Font)
* `+mj-ea` – हेडिंग फ़ॉन्ट ईस्ट एशियन (Major East Asian Font)

निम्न उदाहरण एक शीर्षक बनाता है जो प्रमुख लैटिन थीम फ़ॉन्ट का उपयोग करता है और एक बॉडी पंक्ति जो किरासमान लैटिन थीम फ़ॉन्ट का उपयोग करती है। फिर थीम फ़ॉन्ट बदलता है और परिणाम सहेजता है:

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

शीर्षक प्रमुख फ़ॉन्ट का अनुसरण करता है और बॉडी टेक्स्ट किरासमान फ़ॉन्ट का। जिन पाठों में स्पष्ट फ़ॉन्ट नाम है, वह थीम पहचानकर्ता बदलने पर स्वचालित रूप से नहीं बदलता।

प्रमुख और किरासमान फ़ॉन्ट संग्रह में व्यक्तिगत लेखन प्रणालियों के लिये फ़ॉन्ट मैपिंग भी हो सकती है, जैसे कि सिरिलिक, अरबी, जापानी, जॉर्जियन और थाना। इन्हें देखना, जोड़ना, बदलना या हटाना हेतु देखें [Script‑Specific Theme Fonts](/slides/hi/androidjava/script-specific-font-mappings/)।

{{% alert color="info" title="Tip" %}}

प्रेजेंटेशन फ़ॉन्ट के बारे में अधिक जानकारी के लिये देखें [PowerPoint Fonts](/slides/hi/androidjava/powerpoint-fonts/)।

{{% /alert %}}

## **एक थीम कॉपी या लागू करें**

नीचे दिए गए कार्य‑प्रवाह विभिन्न थीम‑संबंधी समस्याओं को हल करते हैं।

### **एक मास्टर‑निर्भर स्लाइड्स पर बाहरी थीम लागू करें**

जब आपके पास PowerPoint थीम फ़ाइल (`.thmx`) हो और आप किसी विशेष मास्टर पर निर्भर सभी स्लाइड्स को पुनःशैली देना चाहते हों, तो [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslide/) का उपयोग करें। पहले [Presentation.getMasters](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) संग्रह से इच्छित मास्टर चुनें, जो [IMasterSlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslidecollection/) को लागू करता है, और विधि को थीम फ़ाइल पथ पास करें।

विधि निम्न कार्य करती है:

1. चयनित मास्टर के आधार पर एक नया मास्टर स्लाइड बनाती है।
2. बाहरी थीम को नए मास्टर पर लागू करती है।
3. पहले चयनित मास्टर पर निर्भर सभी स्लाइड्स को नए मास्टर से जोड़ती है।
4. नए बनाए गये [IMasterSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslide/) को लौटाती है।

निम्न उदाहरण पहला मास्टर पर निर्भर स्लाइड्स पर बाहरी थीम लागू करता है और प्रस्तुति सहेजता है:

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

एक अमान्य, भ्रष्ट या असमर्थित थीम से [PptxReadException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pptxreadexception/) उत्पन्न हो सकता है। उपयोगकर्ता द्वारा प्रदान किए गए पथ को सत्यापित करें, फ़ाइल‑सिस्टम एक्सेस त्रुटियों को संभालें, और केवल तभी प्रस्तुति सहेजें जब थीम सफलतापूर्वक लागू हो गई हो।

केवल उन स्लाइड्स को पुनः‑सौंपा जाता है जो चयनित मास्टर पर निर्भर थीं। अन्य मास्टर‑संबंधित स्लाइड्स अपने मौजूदा मास्टर और थीम को बनाए रखती हैं। थीम‑सचेत रंग, फ़ॉन्ट, भराव, रेखाएँ, पृष्ठभूमि और प्रभाव बाहरी थीम के विरुद्ध हल किए जाते हैं। सीधे असाइन किए गए रंग, फ़ॉन्ट, भराव आदि अपरिवर्तित रह सकते हैं। लेआउट‑स्तर और स्लाइड‑स्तर के ओवरराइड नए मास्टर से विरासत में मिलें मानों पर प्राथमिकता ले सकते हैं।

थीम ऐसे फ़ॉन्ट भी संदर्भित कर सकती है जो रन‑टाइम परिवेश में उपलब्ध नहीं हैं। निरंतर रेंडरिंग और निर्यात के लिये आवश्यक फ़ॉन्ट स्थापित करें, उन्हें [कस्टम फ़ॉन्ट स्रोत](/slides/hi/androidjava/custom-font/) के माध्यम से उपलब्ध कराएँ, या [फ़ॉन्ट प्रतिस्थापन](/slides/hi/androidjava/font-substitution/) कॉन्फ़िगर करें।

यह एक प्रत्यक्ष मास्टर‑स्तर कार्य‑प्रवाह है: विधि `.thmx` फ़ाइल पथ को स्वीकार करती है और स्लाइड‑स्तर या लेआउट‑स्तर के थीम ओवरराइड को मैन्युअली बनाने की आवश्यकता नहीं होती।

### **बहु‑मास्टर प्रस्तुति में विभिन्न बाहरी थीम लागू करें**

जब प्रासंगिक मास्टर पहले से ज्ञात न हो, तो उसे प्रतिनिधि स्लाइड से [ISlide.getLayoutSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/) और [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutslide/) के माध्यम से प्राप्त करें। थीम लागू करने से पहले मूल मास्टर संदर्भों को संग्रहीत करें क्योंकि प्रत्येक कॉल प्रस्तुति में एक नया मास्टर बनाती है।

निम्न उदाहरण दो अनुभागों की स्लाइड्स के मास्टर लोकेट करता है और प्रत्येक समूह पर अलग‑अलग बाहरी थीम लागू करता है:

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

पहली कॉल केवल उन स्लाइड्स को प्रभावित करती है जो `firstGroupMaster` पर निर्भर थीं, और दूसरी कॉल केवल उन स्लाइड्स को जो `secondGroupMaster` पर निर्भर थीं। अन्य किसी भी मास्टर की स्लाइड्स को पुनः‑शैली नहीं दी जाती।

### **स्लाइड्स स्थानांतरित करते समय स्रोत थीम को संरक्षित रखें**

यदि आप किसी स्लाइड को अन्य प्रस्तुति में ले जाना चाहते हैं और उसकी मूल डिज़ाइन बरकरार रखना चाहते हैं, तो [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslidecollection/) से स्रोत मास्टर को लक्ष्य प्रस्तुति में क्लोन करें, फिर [ISlideCollection.addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidecollection/) और क्लोन किए गये मास्टर से स्लाइड को क्लोन करें। इस प्रकार मास्टर, उसके लेआउट और संबद्ध थीम एक साथ ले जाया जाता है।

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

जब स्रोत स्लाइड को गंतव्य में वैसा ही दिखाना हो, यह सबसे अनुकूल कार्य‑प्रवाह है। केवल असंबंधित गंतव्य मास्टर पर कंटेंट क्लोन करने से थीम‑आधारित रंग, फ़ॉन्ट, पृष्ठभूमि और प्रभाव बदल सकते हैं।

### **मौजूदा स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को अपना वर्तमान मास्टर और लेआउट बनाए रखना है, तो स्रोत थीम से स्लाइड‑स्तर ओवरराइड को प्रारंभ करें। [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/overridetheme/) तथा [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/overridetheme/) विधियां तीन प्रमुख थीम घटकों को ओवरराइड में कॉपी करती हैं।

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

यह अन्य स्लाइड्स द्वारा विरासत में ली गई थीम को बदले बिना उस स्लाइड की थीम बदल देता है। स्थानीय ओवरराइड हटाकर विरासत मानों पर वापस आने के लिये [OverrideTheme.clear](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/overridetheme/) को कॉल करें।

### **लेआउट पर थीम ओवरराइड लागू करें**

लेआउट‑स्तर ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट का उपयोग करती हैं, जब तक कि विशेष स्लाइड का अपना ओवरराइड न हो। वही प्रारंभिक विधियां [LayoutSlideThemeManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/layoutslidethememanager/) के माध्यम से उपयोग की जा सकती हैं:

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

जब कई लेआउट और स्लाइड्स को समान बेस डिज़ाइन साझा करना हो तो मास्टर या प्रस्तुति‑स्तर की थीम प्रयोग करें, एक लेआउट परिवार को अलग शैली की आवश्यकता हो तो लेआउट ओवरराइड, और केवल वास्तविक अपवादों के लिये स्लाइड ओवरराइड। अत्यधिक स्लाइड‑स्तर ओवरराइड भविष्य में वैश्विक थीम बदलावों की भविष्यवाणी को कठिन बना देते हैं।

## **थीम पृष्ठभूमि शैलियों को अपडेट करें**

थीम की पृष्ठभूमि भराव [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iformatscheme/) में संग्रहीत होते हैं। PowerPoint UI में उपलब्ध पृष्ठभूमि विकल्पों की संख्या इस संग्रह में भौतिक रूप से मौजूद भराव परिभाषाओं से अधिक हो सकती है क्योंकि UI थीम भराव को थीम रंगों और अन्य शैली संदर्भों के साथ संयोजित कर सकती है।

![प्रेजेंटेशन थीम के लिये PowerPoint पृष्ठभूमि शैली गैलरी](presentation-design_8.png)

पृष्ठभूमि शैली उपयोग करने से पहले संग्रह और वर्तमान [Background.getStyleIndex](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/background/) जाँचें। शैली सूचकांक `0` का अर्थ है कोई थीम भराव नहीं; सकारात्मक मान थीम पृष्ठभूमि‑शैली संदर्भ होते हैं। यह Java संग्रह के सीधे इंडेक्सिंग से अलग है, जहाँ `get_Item(0)` पहला संग्रहीत आइटम दर्शाता है। यह न मानें कि प्रत्येक प्रस्तुति में समान संख्या में पृष्ठभूमि भराव शैलियाँ होंगी।

निम्न उदाहरण उपलब्ध पृष्ठभूमि भराव गिनती रिपोर्ट करता है, पहले मास्टर को थीम‑पृष्ठभूमि संदर्भ असाइन करता है और प्रस्तुति सहेजता है:

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

दिखाया गया परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि और लेआउट या स्लाइड स्तर पर मौजूद किसी भी पृष्ठभूमि ओवरराइड पर निर्भर करता है। यदि स्लाइड की अपनी पृष्ठभूमि है, तो केवल मास्टर पृष्ठभूमि बदलने से वह स्लाइड नहीं बदलेगी। विरासत लागू होने के बाद अंतिम पृष्ठभूमि जानने के लिये [Background.getEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/background/) का उपयोग करें।

{{% alert color="warning" title="Warning" %}}

शैली सूचकांक को शून्य‑आधारित संग्रह सूचकांक न समझें। किसी एक फ़ाइल से शैली संख्या को हार्ड‑कोड करके दूसरे फ़ाइल में मानने से बचें; थीम शैली परिभाषाएँ प्रस्तुति‑विशिष्ट होती हैं।

{{% /alert %}}

{{% alert color="info" title="Tip" %}}

सीधे पृष्ठभूमि स्वरूपण और पृष्ठभूमि विरासत के लिये देखें [Presentation Background](/slides/hi/androidjava/presentation-background/)।

{{% /alert %}}

## **थीम प्रभावों को अपडेट करें**

एक थीम फॉर्मेट योजना में अलग‑अलग भराव, रेखा और प्रभाव शैली संग्रह होते हैं, जिन्हें क्रमशः [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iformatscheme/), और [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iformatscheme/) द्वारा उजागर किया जाता है। सामान्य Office थीम में अक्सर तीन प्रमुख शैली प्रविष्टियाँ होती हैं जो दृश्य रूप से सूक्ष्म, मध्यम और तीव्र स्वरूपण से मेल खाती हैं, पर कोड को प्रत्येक संग्रह की जाँच करनी चाहिए न कि निश्चित संख्या माननी चाहिए।

![एक ही आकृति पर लागू सूक्ष्म, मध्यम और तीव्र थीम प्रभाव](presentation-design_10.png)

Java में इन संग्रहों को एक्सेस करते समय संग्रह सूचकांक शून्य‑आधारित होता है: `get_Item(0)` पहला संग्रहीत शैली और `get_Item(2)` तीसरा। आकृति के शैली‑संदर्भ सूचकांक एक अलग अवधारणा है, जिसे [IShapeStyle](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishapestyle/) द्वारा उजागर किया जाता है। थीम शैली में परिवर्तन उन आकृतियों को प्रभावित करता है जो उस थीम शैली को संदर्भित करती हैं; सीधे स्वरूपित आकृतियों पर कोई असर नहीं होता।

निम्न उदाहरण जाँचता है कि आवश्यक शैली प्रविष्टियाँ मौजूद हैं, पहले रेखा शैली, तीसरे भराव शैली को बदलता है, तीसरी प्रभाव शैली में बाहरी छाया सक्षम करता है और परिणाम सहेजता है:

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

इन स्लॉटों को संदर्भित करने वाली आकृतियों के लिये, पहली थीम रेखा शैली लाल हो जाएगी, तीसरी थीम भराव शैली ठोस फ़ॉरेस्ट ग्रीन, और तीसरी प्रभाव शैली में 10 पॉइंट की दूरी वाला बाहरी शैडो जुड़ जाएगा। सटीक दृश्य परिणाम इस बात पर निर्भर करता है कि प्रत्येक आकृति कौन से शैली स्लॉट को संदर्भित करती है और क्या सीधे स्वरूपण ने थीम को ओवरराइड किया है।

![लाइन, भराव और शैडो सेटिंग बदलने के बाद थीम प्रभाव शैलियाँ](presentation-design_11.png)

## **निर्धारित करें कि प्रभावी सॉलिड भराव थीम रंग उपयोग करता है या नहीं**

एक भराव ऑब्जेक्ट पर सीधे संग्रहीत या पैराग्राफ, लेआउट, मास्टर, थीम शैली या अन्य स्वरूपण स्तर से विरासत में मिली हो सकती है। उस पदानुक्रम को अपरिवर्तनीय [IFillFormatEffectiveData](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifillformateffectivedata/) में बदलने के लिये [IFillFormat.getEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifillformat/) को कॉल करें। पहले [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifillformateffectivedata/) देखें। केवल जब यह `FillType.Solid` हो, तभी सॉलिड‑भराव गुण पढ़ें।

सॉलिड भराव के लिये, [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifillformateffectivedata/) विरासत, थीम लुक‑अप और रंग रूपांतरण लागू करने के बाद अंतिम RGB मान लौटाता है। [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ifillformateffectivedata/) संबंधित तर्कसंगत [SchemeColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/schemecolor/) स्लॉट (जैसे `Text1` या `Accent6`) लौटाता है। `SchemeColor.NotDefined` का अर्थ है कि प्रभावी सॉलिड भराव स्कीम रंग पर आधारित नहीं है। ऐसी कार्य‑धारा में जहाँ भराव या तो थीम रंग होते हैं या सीधे RGB, यह मान सीधे RGB भराव का संकेत देता है।

स्थानीय [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/icolorformat/) मान केवल भराव को वर्गीकृत करने के लिये प्रयोग न करें। उदाहरण के लिये, किसी पाठ भाग के पास स्थानीय रूप से कोई स्कीम रंग नहीं हो सकता, इसलिए उसका स्थानीय मान `NotDefined` है, जबकि उसका प्रभावी भराव थीम रंग विरासत में लेता है और `Text1` या `Accent6` में बदल जाता है। इसके विपरीत, `getSolidFillSchemeColor` बताता है कि कौन सा तर्कसंगत थीम स्लॉट प्रभावी रंग उत्पन्न किया, लेकिन यह नहीं बताता कि वह स्लॉट ऑब्जेक्ट, पैराग्राफ, लेआउट, मास्टर या अन्य स्तर से आया है।

निम्न उदाहरण प्रस्तुति लोड करता है, दोनों आकृति भराव और पाठ‑भाग भराव का ऑडिट करता है, प्रत्येक अंतिम RGB मान और संबंधित स्कीम रंग प्रिंट करता है, और उन सॉलिड भराव को फ्लैग करता है जो थीम रंग बदलावों को ट्रैक नहीं करेंगे:

```java
import com.aspose.slides.*;
import android.graphics.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    int rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, Color.red(rgb), Color.green(rgb), Color.blue(rgb));
    System.out.println(objectName + ": local scheme = " + localSchemeColor + ", effective scheme = " + effectiveSchemeColor);

    if (effectiveSchemeColor == SchemeColor.NotDefined) {
        System.out.println(objectName + ": direct RGB or another non-scheme fill; audit as theme-independent.");
    } else {
        System.out.println(objectName + ": theme-dependent through " + effectiveSchemeColor + ".");
    }
};

Presentation presentation = new Presentation("input.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);

        int shapeCount = slide.getShapes().size();
        for (int shapeIndex = 0; shapeIndex < shapeCount; shapeIndex++) {
            IShape shape = slide.getShapes().get_Item(shapeIndex);
            String shapeName = "Slide " + (slideIndex + 1) + ", shape " + (shapeIndex + 1);
            auditFill.accept(shapeName, shape.getFillFormat());

            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                int paragraphCount = autoShape.getTextFrame().getParagraphs().getCount();
                for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                    IParagraph paragraph = autoShape.getTextFrame().getParagraphs().get_Item(paragraphIndex);

                    int portionCount = paragraph.getPortions().getCount();
                    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                        IPortion portion = paragraph.getPortions().get_Item(portionIndex);
                        String portionName = shapeName + ", paragraph " + (paragraphIndex + 1) + ", portion " + (portionIndex + 1);
                        auditFill.accept(portionName, portion.getPortionFormat().getFillFormat());
                    }
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

`NotDefined` शाखा उन सॉलिड भरावों की ऑडिट सूची प्रदान करती है जो थीम रंग स्लॉट परिवर्तनों पर प्रतिक्रिया नहीं देंगे। जब प्रस्तुति को नई ब्रांड पैलेट का पालन करना हो, तो इन ऑब्जेक्ट्स की समीक्षा करें। रिपोर्ट किया गया RGB मान अभी भी वर्तमान दिखावट दर्शाता है, जबकि स्कीम मान बताता है कि वह दिखावट थीम से जुड़ी है या नहीं।

प्रभावी‑फॉर्मेट ऑब्जेक्ट स्नैपशॉट होते हैं। प्रस्तुति थीम, थीम‑ओवरराइड या किसी विरासत स्वरूपण को बदलने के बाद, नई `IFillFormatEffectiveData` वस्तु पढ़ने से पहले `getEffective` को फिर से कॉल करें।

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम ऑब्जेक्ट बताते हैं कि किसी विशेष स्तर पर क्या परिभाषित है। प्रभावी मान बताते हैं कि विरासत और स्थानीय ओवरराइड के बाद स्लाइड या आकृति वास्तव में क्या उपयोग करती है। स्लाइड के लिये, [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseoverridethememanager/) को कॉल करें। पृष्ठभूमि के लिये, [Background.getEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/background/) का उपयोग करें, और भराव के लिये, [FillFormat.getEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fillformat/) का।

निम्न उदाहरण स्लाइड से प्रभावी थीम, पृष्ठभूमि और पहली आकृति भराव पढ़ता है:

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

रेंडरिंग डायग्नॉस्टिक्स, वैधता और तुलना के लिये प्रभावी डेटा का उपयोग करें। यदि आप केवल [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) को देखेंगे, तो आप ऐसे मास्टर, लेआउट, स्लाइड या आकृति ओवरराइड को चूक सकते हैं जो अंतिम दिखावट को बदलते हैं।

## **FAQ**

**क्या बाहरी थीम लागू करने से प्रस्तुति की हर स्लाइड प्रभावित होती है?**

नहीं। [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslide/) केवल उन स्लाइड्स को पुनः‑सौंपता है जो चयनित मास्टर पर निर्भर थीं। अन्य मास्टर उपयोग करने वाली स्लाइड्स अपनी मौजूदा थीम बरकरार रखती हैं।

**क्या मैं मास्टर बदले बिना किसी एकल स्लाइड पर थीम लागू कर सकता हूँ?**

हां। स्लाइड के [SlideThemeManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slidethememanager/) का उपयोग करें और उसका ओवरराइड थीम प्रारंभ करें। परिवर्तन केवल उस स्लाइड तक सीमित रहता है; अन्य स्लाइड्स अपने मौजूदा थीम को विरासत में लेती रहेंगी।

**एक थीम को एक प्रस्तुति से दूसरी में सुरक्षित रूप से ले जाने का सबसे अच्छा तरीका क्या है?**

जब स्लाइड को ले जाकर उसकी स्रोत दिखावट को बनाए रखना हो, तो स्रोत मास्टर को गंतव्य में क्लोन करें और उस मास्टर के साथ स्लाइड को [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslidecollection/) तथा [ISlideCollection.addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidecollection/) से क्लोन करें। यह मास्टर, लेआउट और थीम को साथ रखता है।

**विरासत और ओवरराइड के बाद प्रभावी मान कैसे देखूँ?**

स्लाइड या लेआउट थीम के लिये [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/baseoverridethememanager/) का उपयोग करें और फॉर्मेट ऑब्जेक्ट जैसे [Background.getEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/background/) तथा [FillFormat.getEffective](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fillformat/) के संबंधित प्रभावी‑डेटा विधियों को कॉल करें। ये API विरासत और ओवरराइड लागू होने के बाद हल किए गये मान लौटाते हैं।