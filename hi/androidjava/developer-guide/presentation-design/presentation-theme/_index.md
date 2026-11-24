---
title: एंड्रॉइड पर प्रस्तुति थीम प्रबंधित करें
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
- बाहरी थीम
- THMX
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
description: "एंड्रॉइड के लिये Aspose.Slides में जावा के माध्यम से मास्टर प्रस्तुति थीम, ताकि स्थिर ब्रांडिंग के साथ PowerPoint फाइलें बनायीं, कस्टमाइज़ और परिवर्तित की जा सकें।"
---
## **परिचय**

एक प्रस्तुति थीम रंगों, फ़ॉन्ट्स, पृष्ठभूमि शैलियों, फ़िल्स, लाइनों और प्रभावों का समन्वित सेट परिभाषित करती है। थीम-ज्ञानयुक्त ऑब्जेक्ट्स इन साझा परिभाषाओं को संदर्भित करते हैं न कि प्रत्येक दृश्य गुण को स्थिर मान के रूप में संग्रहीत करते हैं, इसलिए थीम परिवर्तन कई ऑब्जेक्ट्स को एक साथ अपडेट कर सकता है।

Aspose.Slides में, प्रस्तुति‑स्तर की थीम उपलब्ध है [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) के माध्यम से। एक प्रस्तुति में निचले स्तरों पर भी थीम ओवरराइड हो सकते हैं। एक मास्टर [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/masterthememanager/) के माध्यम से प्रस्तुति थीम को ओवरराइड कर सकता है, जबकि लेआउट या व्यक्तिगत स्लाइड अपने विरासत में मिले थीम को [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/) के माध्यम से ओवरराइड कर सकते हैं। व्यवहार में, एक स्लाइड के लिए प्रभावी थीम इस उत्तराधिकार श्रृंखला के माध्यम से निर्धारित की जाती है: प्रस्तुति थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![थीम घटक: रंग, फ़ॉन्ट, पृष्ठभूमि शैलियाँ और प्रभाव](theme-constituents.png)

नीचे के अनुभाग सबसे सामान्य थीम वर्कफ़्लो दिखाते हैं: थीम जांचना, रंग और फ़ॉन्ट बदलना, थीम कॉपी या लागू करना, पृष्ठभूमि और प्रभाव शैलियों को अपडेट करना, तथा उत्तराधिकार और ओवरराइड्स के हल होने के बाद प्रभावी मान पढ़ना।

## **थीम की जाँच**

[MasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) ऑब्जेक्ट थीम की कलर स्कीम, फ़ॉन्ट स्कीम और फॉर्मेट स्कीम को क्रमशः [MasterTheme.getColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) और [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mastertheme/) के माध्यम से उजागर करता है। इन्हें बदलने से पहले इन संग्रहों की जाँच करना विशेष रूप से उपयोगी है जब प्रस्तुति बाहरी स्रोत से आती है क्योंकि शैली प्रविष्टियों की संख्या और सामग्री भिन्न हो सकती है।

निम्न उदाहरण मुख्य थीम गुण पढ़ता है और रिपोर्ट करता है कि थीम में कितने पृष्ठभूमि, फ़िल, लाइन और प्रभाव शैलियाँ संग्रहीत हैं:

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

यदि किसी फ़ाइल में कई मास्टर उपयोग किए गए हैं, तो यह न मानें कि हर स्लाइड की समान प्रभावी थीम होगी। स्लाइड से संबंधित मास्टर को जांचें, और लेआउट या स्लाइड ओवरराइड मौजूद होने पर इस लेख में बाद में दिखाए गए प्रभावी‑थीम वर्कफ़्लो का उपयोग करें।

## **थीम रंग बदलें**

थीम‑ज्ञानयुक्त फ़िल्स, लाइनों और टेक्स्ट में [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) तालिका से तार्किक रंग का संदर्भ हो सकता है। जब आप [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/) में संबंधित प्रविष्टि बदलते हैं, तो सभी ऑब्जेक्ट्स जो अभी भी उस थीम रंग को संदर्भित कर रहे हैं, नए मान के विरुद्ध हल हो जाते हैं। सीधे RGB रंग का उपयोग करने वाले ऑब्जेक्ट्स थीम‑रंग अपडेट से नहीं बदलेंगे।

निम्न पूर्ण‑परिचालन उदाहरण एक आकार बनाता है जो `Accent4` का उपयोग करता है, थीम का `Accent4` रंग लाल में बदलता है, प्रस्तुति सहेजता है, पुनः खोलता है, और प्रभावी फ़िल रंग प्रिंट करता है:

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

क्योंकि आयत `Accent4` से जुड़ी रहती है, थीम बदलने के बाद उसका दिखाई देने वाला रंग लाल हो जाता है। यदि आप आकार पर सीधे रंग के साथ स्कीम रंग को बदलते हैं, तो बाद में `Accent4` में किए गए परिवर्तन उस फ़िल को प्रभावित नहीं करेंगे।

### **अतिरिक्त पैलेट से रंग उपयोग करें**

PowerPoint थीम रंग से हल्के और गहरे वेरिएंट उत्पन्न करने के लिए रंग रूपांतरण लागू करता है। Aspose.Slides इन रूपांतरणों को [ColorTransformOperation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/colortransformoperation/) तालिका के माध्यम से उजागर करता है।

![मुख्य थीम रंग और अतिरिक्त पैलेट से उत्पन्न हल्के व गहरे रंग](additional-palette-colors.png)

**1** – मुख्य थीम रंग।

**2** – मुख्य थीम रंगों से उत्पन्न हल्के व गहरे वेरिएंट।

निम्न उदाहरण `Accent4` पर आधारित छह आयतें बनाता है, उनमें से पाँच पर लुमिनेंस रूपांतरण लागू करता है, और परिणाम सहेजता है:

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

ये वेरिएंट थीम रंग पर आधारित रहते हैं। यदि बाद में `Accent4` बदलता है, तो रूपांतरित रंग नए `Accent4` मान से पुनः गणना किए जाते हैं।

### **`SchemeColor` मानों को `IColorScheme` स्लॉट्स में मैप करें**

[Sche​meColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) तालिका `Text1`, `Background1`, `Text2` और `Background2` का उपयोग करती है, जबकि [IColorScheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorscheme/) समान थीम स्लॉट को `Dark1`, `Light1`, `Dark2` और `Light2` के रूप में उजागर करता है। मैपिंग स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ये समान थीम स्लॉट के वैकल्पिक नाम हैं; ये कोई गतिशील रूप से रूपांतरित मान नहीं हैं।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट स्कीम में हेडिंग के लिए प्रमुख फ़ॉन्ट सेट और बॉडी टेक्स्ट के लिए गौण फ़ॉन्ट सेट होते हैं। [IFontScheme.getMajor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) और [IFontScheme.getMinor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontscheme/) मेथड्स इन सेटों को उजागर करते हैं।

PowerPoint‑अनुकूल थीम फ़ॉन्ट पहचानकर्ता टेक्स्ट फ़ॉर्मेटिंग में उपयोग किए जा सकते हैं:

* `+mn‑lt` – बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* `+mj‑lt` – हेडिंग फ़ॉन्ट लैटिन (Major Latin Font)
* `+mn‑ea` – बॉडी फ़ॉन्ट ईस्ट एशियन (Minor East Asian Font)
* `+mj‑ea` – हेडिंग फ़ॉन्ट ईस्ट एशियन (Major East Asian Font)
* `+mn‑cs` – बॉडी फ़ॉन्ट कॉम्प्लेक्स स्क्रिप्ट (Minor Complex Script Font)
* `+mj‑cs` – हेडिंग फ़ॉन्ट कॉम्प्लेक्स स्क्रिप्ट (Major Complex Script Font)

निम्न उदाहरण एक हेडिंग बनाता है जो प्रमुख लैटिन थीम फ़ॉन्ट का उपयोग करता है और एक बॉडी लाइन बनाता है जो गौण लैटिन थीम फ़ॉन्ट का उपयोग करती है। फिर थीम फ़ॉन्ट बदलता है और परिणाम सहेजता है:

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

हेडिंग प्रमुख फ़ॉन्ट को फॉलो करती है और बॉडी टेक्स्ट गौण फ़ॉन्ट को। यदि फ़ॉन्ट का नाम स्पष्ट रूप से दिया गया है न कि थीम पहचानकर्ता, तो थीम फ़ॉन्ट स्कीम बदलने पर वह स्वचालित रूप से नहीं बदलेगा।

मुख्य और गौण फ़ॉन्ट संग्रह में व्यक्तिगत लेखन प्रणालियों, जैसे सिरिलिक, अरबी, जापानी, जॉर्जियन, और थाना के लिए फ़ॉन्ट मैपिंग भी हो सकती है। इन्हें जांचने, जोड़ने, बदलने या हटाने के लिए देखें [Script‑Specific Theme Fonts](/slides/hi/androidjava/script-specific-font-mappings/)।

{{% alert color="info" title="Tip" %}}
थीम फ़ॉन्ट के बारे में अधिक जानकारी के लिए देखें [PowerPoint Fonts](/slides/hi/androidjava/powerpoint-fonts/)।
{{% /alert %}}

### **थीम फ़ॉन्ट संदर्भ हल करें**

टेक्स्ट जांचते समय, [IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName--) `+mn‑lt` जैसे थीम संदर्भ वापस कर सकता है बजाय फ़ॉन्ट फैमिली नाम के। उपयुक्त [IThemeEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeeffectivedata/) के साथ [IFontData.getFontName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifontdata/#getFontName-com.aspose.slides.IThemeEffectiveData-) को कॉल करके उस संदर्भ को हल करें। `+mj` और `+mn` उपसर्ग क्रमशः प्रमुख और गौण फ़ॉन्ट सेट चुनते हैं; `-lt`, `-ea` और `-cs` प्रत्यय क्रमशः लैटिन, ईस्ट एशियन और कॉम्प्लेक्स स्क्रिप्ट फ़ॉन्ट चुनते हैं।

वह ऑब्जेक्ट जिससे थीम लागू होती है, पर [IThemeable.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ithemeable/#createThemeEffective--) को कॉल करके प्रभावी थीम प्राप्त करें। स्लाइड पर सामान्य टेक्स्ट के लिए इस मेथड को स्लाइड पर कॉल करें ताकि संदर्भ में उस स्लाइड की विरासत वाली थीम और स्थानीय ओवरराइड शामिल हों। लेआउट या मास्टर को जांचते समय उसके अपने प्रभावी थीम का उपयोग करें। यह न मानें कि पहले मास्टर की थीम सभी स्लाइड्स पर लागू होती है।

निम्न उदाहरण एक टेक्स्ट भाग बनाता है जो स्पष्ट रूप से गौण लैटिन फ़ॉन्ट को संदर्भित करता है। यह [IOverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioverridetheme/#initFontSchemeFromInherited--) के माध्यम से स्लाइड फ़ॉन्ट स्कीम को प्रारंभ करता है और प्रमुख एवं गौण लैटिन फ़ैमिलियों को क्रमशः `Arial` और `Calibri` सेट करता है, जिससे कोई इनपुट फ़ाइल न होने पर भी परिणाम पुनरुत्पादित हो सके।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IOverrideTheme theme = slide.getThemeManager().getOverrideTheme();
    theme.initFontSchemeFromInherited();
    theme.getFontScheme().getMajor().setLatinFont(new FontData("Arial"));
    theme.getFontScheme().getMinor().setLatinFont(new FontData("Calibri"));

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Text using the minor theme font");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLatinFont(new FontData("+mn-lt"));

    IFontData font = portion.getPortionFormat().getLatinFont();
    IThemeEffectiveData effectiveTheme = slide.createThemeEffective();
    System.out.println(font.getFontName() + " -> " + font.getFontName(effectiveTheme));

    FontData explicitFont = new FontData("Verdana");
    System.out.println(explicitFont.getFontName() + " -> " + explicitFont.getFontName(effectiveTheme));
} finally {
    presentation.dispose();
}
```

आउटपुट `+mn‑lt -> Calibri` के बाद `Verdana -> Verdana` दिखाता है। संग्रहीत संदर्भ अपरिवर्तित रहता है, जबकि स्पष्ट फ़ैमिली नाम जैसा है वैसा ही लौटाया जाता है। यदि भाग `+mj‑lt` उपयोग करता, तो यह इस थीम में `Arial` को हल करता।

थीम संदर्भ हल करना केवल यह बताता है कि थीम ने कौन सा फ़ॉन्ट फैमिली निर्दिष्ट किया है। यह फ़ॉन्ट उपलब्धता या रेंडरिंग के दौरान ग्लीफ़ फ़ॉलबैक के बाद उपयोग किए जाने वाले फ़ॉन्ट फ़ाइल को नहीं जांचता। उन अलग चरणों के लिए देखें [Font Selection Sequence](/slides/hi/androidjava/font-selection-sequence/) और [Font Substitution](/slides/hi/androidjava/font-substitution/)।

## **थीम कॉपी या लागू करें**

नीचे के वर्कफ़्लो विभिन्न थीम‑संबंधित समस्याओं को हल करते हैं।

### **बाहरी थीम को मास्टर‑निर्भर स्लाइड्स पर लागू करें**

जब आपके पास PowerPoint थीम फ़ाइल (`.thmx`) हो और आप किसी विशिष्ट मास्टर पर निर्भर सभी स्लाइड्स की शैली बदलना चाहते हों, तब उपयोग करें [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/)। पहले [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) संग्रह से मास्टर चुनें, जो [IMasterSlideCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) को लागू करता है, और थीम फ़ाइल पाथ को मेथड में पास करें।

मेथड निम्न कार्य करता है:

1. चयनित मास्टर के आधार पर एक नया मास्टर स्लाइड बनाता है।
1. बाहरी थीम को नए मास्टर पर लागू करता है।
1. पहले चयनित मास्टर पर निर्भर सभी स्लाइड्स को नए मास्टर से जोड़ता है।
1. नया बना हुआ [IMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) लौटाता है।

निम्न उदाहरण पहले मास्टर पर निर्भर स्लाइड्स पर बाहरी थीम लागू करता है और प्रस्तुति सहेजता है:

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

अमान्य, भ्रष्ट या असमर्थित थीम से [PptxReadException](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pptxreadexception/) उत्पन्न हो सकता है। उपयोगकर्ता द्वारा प्रदान किये गए पाथ को वैध करें, फ़ाइल‑सिस्टम एक्सेस विफलताओं को संभालें, और थीम सफलतापूर्वक लागू होने के बाद ही प्रस्तुति सहेजें।

केवल वही स्लाइड्स पुनः‑नियुक्त होती हैं जो चयनित मास्टर पर निर्भर थीं। अन्य मास्टर से जुड़ी स्लाइड्स अपनी मौजूदा मास्टर और थीम बरकरार रखती हैं। थीम‑ज्ञानयुक्त रंग, फ़ॉन्ट, फ़िल, लाइन, पृष्ठभूमि और प्रभाव बाहरी थीम के विरुद्ध हल होते हैं। सीधे असाइन किए गए रंग, फ़ॉन्ट, फ़िल और अन्य स्पष्ट फ़ॉर्मेटिंग अपरिवर्तित रह सकते हैं। लेआउट‑स्तर और स्लाइड‑स्तर ओवरराइड्स भी नए मास्टर से विरासत में मिले मानों पर प्राथमिकता ले सकते हैं।

थीम ऐसे फ़ॉन्ट्स को संदर्भित कर सकती है जो रन‑टाइम पर्यावरण में उपलब्ध नहीं हैं। सुसंगत रेंडरिंग और निर्यात के लिये आवश्यक फ़ॉन्ट्स स्थापित करें, उन्हें [custom font sources](/slides/hi/androidjava/custom-font/) के माध्यम से प्रदान करें, या [font substitution](/slides/hi/androidjava/font-substitution/) को कॉन्फ़िगर करें।

यह सीधा मास्टर‑स्तर वर्कफ़्लो है: मेथड `.thmx` फ़ाइल पाथ स्वीकार करता है और स्लाइड‑स्तर या लेआउट‑स्तर थीम ओवरराइड बनाने की आवश्यकता नहीं होती।

### **बहु‑मास्टर प्रस्तुति में विभिन्न बाहरी थीम लागू करें**

जब प्रासंगिक मास्टर पहले से ज्ञात न हो, तो [ISlide.getLayoutSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/) और [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilayoutslide/) के माध्यम से प्रतिनिधि स्लाइड से इसे प्राप्त करें। थीम लागू करने से पहले मूल मास्टर रेफ़रेंसेज़ को संग्रहीत करें क्योंकि प्रत्येक कॉल प्रस्तुति में एक नया मास्टर बनाता है।

निम्न उदाहरण दो अनुभागों की स्लाइड्स के मास्टर को खोजता है और प्रत्येक समूह पर अलग‑अलग बाहरी थीम लागू करता है:

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

पहला कॉल केवल उन स्लाइड्स को प्रभावित करता है जो `firstGroupMaster` पर निर्भर थीं, और दूसरा कॉल केवल `secondGroupMaster` पर निर्भर स्लाइड्स को। किसी अन्य मास्टर से जुड़ी स्लाइड्स को पुनः‑स्टाइल नहीं किया जाता।

### **स्लाइड्स को स्थानांतरित करते समय स्रोत थीम को संरक्षित रखें**

यदि आप किसी स्लाइड को दूसरे प्रस्तुति में ले जाना चाहते हैं और उसके मूल डिज़ाइन को बरकरार रखना चाहते हैं, तो स्रोत मास्टर को लक्ष्य प्रस्तुति में [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) से क्लोन करें, फिर क्लोन किए हुए मास्टर के साथ [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) से स्लाइड को क्लोन करें। यह मास्टर, उसके लेआउट और सम्बंधित थीम को साथ ले जाता है।

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

यह वर्कफ़्लो तभी पसंदीदा है जब स्रोत स्लाइड को गंतव्य में समान रूप से दिखना आवश्यक हो। केवल सामग्री को असंबंधित गंतव्य मास्टर पर क्लोन करने से थीम‑से प्रेरित रंग, फ़ॉन्ट, पृष्ठभूमि और प्रभाव बदल सकते हैं।

### **एक मौजूदा स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को वर्तमान मास्टर और लेआउट पर रखा जाना है, तो स्रोत थीम से स्लाइड‑स्तर ओवरराइड प्रारंभ करें। [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/) और [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/) मेथड्स तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करते हैं।

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

यह उस स्लाइड द्वारा उपयोग की गई थीम को बदलता है बिना अन्य स्लाइड्स की विरासत वाली थीम को बदले। स्थानीय ओवरराइड हटाने और विरासत वाले मानों पर लौटने के लिये कॉल करें [OverrideTheme.clear](https://reference.aspose.com/slides/androidjava/com.aspose.slides/overridetheme/)।

### **लेआउट पर थीम ओवरराइड लागू करें**

लेआउट‑स्तर ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट का उपयोग करती हैं, जब तक कोई विशिष्ट स्लाइड अपना स्वयं का ओवरराइड न रखे। समान प्रारम्भिक मेथड्स को [LayoutSlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/layoutslidethememanager/) के माध्यम से उपयोग किया जा सकता है:

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

जब कई लेआउट और स्लाइड्स को समान आधार डिज़ाइन साझा करना हो तो मास्टर या प्रस्तुति‑स्तर थीम का उपयोग करें, जब एक लेआउट परिवार को अलग शैली की आवश्यकता हो तो लेआउट ओवरराइड, और केवल असामान्य मामलों के लिये स्लाइड ओवरराइड। अत्यधिक स्लाइड‑स्तर ओवरराइड बाद में वैश्विक थीम परिवर्तन को पूर्वानुमान करना कठिन बना देते हैं।

<!-- visual-explanation:presentation-theme:start -->
[![एक मास्टर थीम दो लेआउट को फ़ीड करती है; एक लेआउट ओवरराइड उसके स्लाइड्स को प्रभावित करता है सिवाय एक स्लाइड के जिसके पास अधिक स्थानीय ओवरराइड है।](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*एक लेआउट ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट को उपयोग करती हैं जब तक कोई स्लाइड अपना स्वयं का ओवरराइड न प्रदान करे। थीम‑आधारित मान उनके हल किए गए स्कीम का अनुसरण करते हैं; स्पष्ट रूप से फ़ॉर्मेट किए गए ऑब्जेक्ट स्थानीय उपस्थिति बना सकते हैं। ओवरराइड को अपेक्षित डिज़ाइन अपवाद के समान संकीर्ण रखें।*
<!-- visual-explanation:presentation-theme:end -->

## **थीम पृष्ठभूमि शैली अपडेट करें**

थीम की पृष्ठभूमि फ़िल्स [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/) में संग्रहीत हैं। PowerPoint UI में थीम फ़िल्स को थीम रंगों और अन्य शैली संदर्भों के साथ मिलाकर अधिक पृष्ठभूमि विकल्प दिखा सकता है, जबकि संग्रह में वास्तविक फ़िल परिभाषाएँ कम हो सकती हैं।

![PowerPoint पृष्ठभूमि शैली गैलरी प्रस्तुति थीम के लिये](presentation-design_8.png)

पृष्ठभूमि शैली उपयोग करने से पहले, संग्रहीत संग्रह और वर्तमान [Background.getStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) की जाँच करें। `0` इंडेक्स का अर्थ है कोई थीम्ड फ़िल नहीं; सकारात्मक मान थीम पृष्ठभूमि‑शैली संदर्भ दर्शाते हैं। यह Java संग्रह की शून्य‑आधारित इंडेक्सिंग (`get_Item(0)` पहला आइटम) से भिन्न है। यह न मानें कि हर प्रस्तुति में समान संख्या में पृष्ठभूमि फ़िल शैलियाँ होंगी।

निम्न उदाहरण उपलब्ध पृष्ठभूमि फ़िल गिनती रिपोर्ट करता है, पहले मास्टर को थीम्ड पृष्ठभूमि संदर्भ असाइन करता है, और प्रस्तुति सहेजता है:

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

दिखाई देने वाला परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि और लेआउट या स्लाइड‑स्तर पर किसी भी पृष्ठभूमि ओवरराइड पर निर्भर करता है। यदि स्लाइड अपनी स्वयं की पृष्ठभूमि उपयोग करती है, तो केवल मास्टर पृष्ठभूमि बदलने से वह स्लाइड नहीं बदलेगी। विरासत लागू होने के बाद अंतिम पृष्ठभूमि जानने के लिये उपयोग करें [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/)।

{{% alert color="warning" title="Warning" %}}
स्टाइल इंडेक्स को शून्य‑आधारित संग्रह इंडेक्स न मानें। किसी फ़ाइल से स्टाइल नंबर को हार्ड‑कोड करके दूसरे फ़ाइल में समान उपस्थिति मानना सुरक्षित नहीं है; थीम शैली परिभाषाएँ प्रस्तुति‑विशिष्ट होती हैं।
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
सीधे पृष्ठभूमि फ़ॉर्मेटिंग और पृष्ठभूमि उत्तराधिकार के लिये देखें [Presentation Background](/slides/hi/androidjava/presentation-background/)।
{{% /alert %}}

## **थीम प्रभाव अपडेट करें**

थीम फ़ॉर्मेट स्कीम में अलग‑अलग फ़िल, लाइन और इफ़ेक्ट शैली संग्रह होते हैं जो क्रमशः [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/), और [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iformatscheme/) द्वारा उजागर होते हैं। सामान्य Office थीम अक्सर तीन प्रमुख शैली प्रविष्टियाँ रखती हैं जो दृश्य रूप में सूक्ष्म, मध्यम और तीव्र फ़ॉर्मेटिंग से मेल खाती हैं, लेकिन कोड को प्रत्येक संग्रह को जांचना चाहिए न कि निश्चित संख्या मान लेना चाहिए।

![एक ही आकार पर लागू सूक्ष्म, मध्यम और तीव्र थीम प्रभाव](presentation-design_10.png)

जब आप इन संग्रहों को Java में एक्सेस करते हैं, तो संग्रह इंडेक्स शून्य‑आधारित होता है: `get_Item(0)` पहला संग्रहीत शैली और `get_Item(2)` तीसरा। आकार की शैली‑संदर्भ इंडेक्स अलग अवधारणा है, जिसे [IShapeStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/) के माध्यम से उजागर किया जाता है। थीम शैली को संशोधित करने से उन सभी आकारों पर प्रभाव पड़ता है जो उस थीम शैली को संदर्भित करते हैं; सीधे फ़ॉर्मेट किए गए आकार अपरिवर्तित रह सकते हैं।

निम्न उदाहरण जांचता है कि आवश्यक शैली प्रविष्टियाँ मौजूद हैं, पहली लाइन शैली बदलता है, तीसरी फ़िल शैली बदलता है, तीसरी इफ़ेक्ट शैली में बाहरी छाया सक्षम करता है, और परिणाम सहेजता है:

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

उन आकारों के लिये जिनके पास ये स्लॉट्स संदर्भित हैं, पहली थीम लाइन शैली लाल हो जाएगी, तीसरी थीम फ़िल शैली सॉलिड फ़ॉरेस्ट ग्रीन हो जाएगी, और तीसरी इफ़ेक्ट शैली में दूरी 10 पॉइंट की बाहरी छाया जुड़ जाएगी। अंतिम दृश्य परिणाम अभी भी इस पर निर्भर करता है कि प्रत्येक आकार कौन से स्लॉट संदर्भित करता है और क्या सीधे फ़ॉर्मेटिंग थीम को ओवरराइड करती है।

![लाइन, फ़िल और शैडो सेटिंग्स बदलने के बाद थीम इफ़ेक्ट शैली](presentation-design_11.png)

## **आकार के लिये थीम फ़िल और लाइन शैली चुनें**

एक आकार अपने फ़िल और आउटलाइन को स्वतंत्र रूप से [IShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setFillStyleIndex-short-) और [IShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapestyle/#setLineStyleIndex-int-) के माध्यम से चुन सकता है। दोनों मेथड्स में इंडेक्स `1` संबंधित थीम संग्रह की पहली प्रविष्टि (`get_Item(0)`) चुनता है, और इंडेक्स `2` दूसरी (`get_Item(1)`) चुनता है।

निम्न उदाहरण दो फ़िल शैली (स्वर्ण और आकाश नीला) और दो लाइन शैली (6 pt पर गहरी नीली और 12 pt पर गहरा लाल) मूल थीम के तहत नई प्रस्तुति में सेट करता है। यह स्लाइड को तीन चरणों पर सहेजता है ताकि आप PowerPoint में परिणाम तुलना कर सकें।

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IFormatScheme styles = presentation.getMasterTheme().getFormatScheme();

    IFillFormat goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(FillType.Solid);
    goldFill.getSolidFillColor().setColor(Color.rgb(255, 215, 0));
    IFillFormat blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(FillType.Solid);
    blueFill.getSolidFillColor().setColor(Color.rgb(135, 206, 235));

    ILineFormat thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(FillType.Solid);
    thinLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    thinLine.setWidth(6);
    ILineFormat thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(FillType.Solid);
    thickLine.getFillFormat().getSolidFillColor().setColor(Color.rgb(139, 0, 0));
    thickLine.setWidth(12);

    IShapeCollection shapes = presentation.getSlides().get_Item(0).getShapes();
    IAutoShape left = shapes.addAutoShape(ShapeType.Rectangle, 100, 205, 200, 130);
    IAutoShape right = shapes.addAutoShape(ShapeType.Rectangle, 420, 205, 200, 130);
    left.getShapeStyle().setFillStyleIndex((short) 1);
    right.getShapeStyle().setFillStyleIndex((short) 2);
    left.getShapeStyle().setLineStyleIndex(1);
    right.getShapeStyle().setLineStyleIndex(1);
    presentation.save("01-initial.pptx", SaveFormat.Pptx);

    right.getShapeStyle().setLineStyleIndex(2);
    presentation.save("02-line-changed.pptx", SaveFormat.Pptx);

    goldFill.getSolidFillColor().setColor(Color.rgb(46, 139, 87));
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| प्रारम्भिक शैलियाँ | दाहिनी आउटलाइन बदलें | पहली थीम फ़िल संपादित करें |
|:---:|:---:|:---:|
| ![स्वर्ण और आकाश‑नीली आयतें समान पतली गहरी नीली आउटलाइन के साथ](theme-style-initial.png) | ![आकाश‑नीली आयत अब मोटी गहरी लाल आउटलाइन रखती है](theme-style-line-changed.png) | ![बाएँ आयत अब हरी है और दोनों आउटलाइन अपरिवर्तित हैं](theme-style-fill-changed.png) |

विभिन्न लाइन शैली चुनने से केवल दाहिनी आयत की आउटलाइन बदलती है। पहली थीम फ़िल संपादित करने से सभी आकार जो उसे उपयोग करते हैं अपडेट हो जाते हैं। यहाँ केवल बायाँ आयत हरा हो जाता है।

किसी मौजूदा आकार पर, स्थानीय फ़िल रंग, लाइन रंग या लाइन चौड़ाई थीम शैली के उस भाग को ओवरराइड कर सकते हैं। यदि शैली इंडेक्स बदलने से कोई दृश्य प्रभाव नहीं दिखता, तो आकार की [direct formatting](/slides/hi/androidjava/shape-formatting/) देखें।

## **जांचें कि प्रभावी सॉलिड फ़िल थीम रंग उपयोग करती है या नहीं**

फ़िल ऑब्जेक्ट पर सीधे सहेजा जा सकता है या पैराग्राफ, लेआउट, मास्टर, थीम शैली या किसी अन्य फ़ॉर्मेटिंग स्तर से विरासत में मिल सकता है। इस पदानुक्रम को अपरिवर्तनीय [IFillFormatEffectiveData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) में हल करने के लिये कॉल करें [IFillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/)। पहले [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) जांचें। केवल जब यह `FillType.Solid` हो तो सॉलिड‑फ़िल गुण पढ़ें।

सॉलिड फ़िल के लिये, [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) उत्तराधिकार, थीम लुक‑अप और रंग रूपांतरण लागू होने के बाद अंतिम रेंडर किए गए RGB मान लौटाता है। [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformateffectivedata/) संबंधित तार्किक [SchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/schemecolor/) स्लॉट लौटाता है, जैसे `Text1` या `Accent6`। `SchemeColor.NotDefined` का अर्थ है प्रभावी सॉलिड फ़िल स्कीम रंग पर आधारित नहीं है। ऐसी वर्कफ़्लो में जहाँ फ़िल केवल थीम रंग या सीधे RGB रंग होते हैं, यह मान सीधे RGB फ़िल को दर्शाता है।

केवल स्थानीय [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolorformat/) मूल्य का उपयोग करके फ़िल वर्गीकृत न करें। उदाहरण के लिये, एक टेक्स्ट भाग में स्थानीय रूप से कोई स्कीम रंग नहीं हो सकता, इसलिए उसका स्थानीय मान `NotDefined` होगा, जबकि उसका प्रभावी फ़िल थीम रंग विरासत में लेकर `Text1` या `Accent6` बन सकता है। इसके विपरीत, `getSolidFillSchemeColor` बताता है कि कौन सा तार्किक थीम स्लॉट प्रभावी रंग उत्पन्न करता है, लेकिन यह नहीं बताता कि वह स्लॉट ऑब्जेक्ट, पैराग्राफ, लेआउट, मास्टर या किसी अन्य स्तर से आया है।

निम्न उदाहरण एक प्रस्तुति लोड करता है, दोनों आकार फ़िल और टेक्स्ट‑पोर्टियन फ़िल को ऑडिट करता है, प्रत्येक अंतिम RGB मान और संबद्ध स्कीम रंग प्रिंट करता है, और उन सॉलिड फ़िल्स को चिन्हित करता है जो थीम रंग परिवर्तनों को ट्रैक नहीं करेंगे:

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

`NotDefined` शाखा उन सॉलिड फ़िल्स की ऑडिट सूची प्रदान करती है जो थीम रंग स्लॉट में परिवर्तन पर प्रतिक्रिया नहीं देंगे। नई ब्रांड पैलेट लागू करने पर इन ऑब्जेक्ट्स की समीक्षा करें। रिपोर्ट किया गया RGB मान अभी भी वर्तमान उपस्थिति दिखाता है, जबकि स्कीम मान बताता है कि वह उपस्थिति थीम से जुड़ी है या नहीं।

प्रभावी‑फ़ॉर्मेट ऑब्जेक्ट स्नैपशॉट होते हैं। प्रस्तुति थीम, थीम ओवरराइड या कोई भी उत्तराधिकारित फ़ॉर्मेट बदलने के बाद, फिर से `getEffective` कॉल करें और नई `IFillFormatEffectiveData` ऑब्जेक्ट पढ़ें, फिर रंग तुलना या रिपोर्ट करें।

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम ऑब्जेक्ट केवल किसी निश्चित स्तर पर परिभाषित चीज़ें बताते हैं। प्रभावी मान बताते हैं कि स्लाइड या आकार वास्तव में क्या उपयोग करता है जब उत्तराधिकार और स्थानीय ओवरराइड्स हल हो चुके हों। स्लाइड के लिये, कॉल करें [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/). पृष्ठभूमि के लिये, उपयोग करें [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/), और फ़िल के लिये, उपयोग करें [FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/)।

निम्न उदाहरण एक स्लाइड से प्रभावी थीम, पृष्ठभूमि, और पहले आकार फ़िल पढ़ता है:

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

रेंडरिंग डायग्नॉस्टिक्स, वैधता जाँच और तुलना के लिये प्रभावी डेटा उपयोग करें। यदि आप केवल [Presentation.getMasterTheme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) जांचते हैं, तो आप मास्टर, लेआउट, स्लाइड या आकार ओवरराइड को चूक सकते हैं जो अंतिम उपस्थिति बदलते हैं।

## **FAQ**

**क्या बाहरी थीम लागू करने से प्रस्तुति की हर स्लाइड प्रभावित होती है?**  
नहीं। [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/) केवल चयनित मास्टर पर निर्भर स्लाइड्स को पुनः‑नियुक्त करता है। अन्य मास्टर प्रयोग करने वाली स्लाइड्स अपनी मौजूदा थीम बरकरार रखती हैं।

**क्या मैं मास्टर बदले बिना किसी एकल स्लाइड पर थीम लागू कर सकता हूँ?**  
हां। स्लाइड के [SlideThemeManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidethememanager/) का उपयोग करें और उसका ओवरराइड थीम प्रारम्भ करें। परिवर्तन केवल उस स्लाइड तक सीमित रहता है; अन्य स्लाइड्स अपनी मौजूदा थीम विरासत में लेती रहती हैं।

**एक प्रस्तुति से दूसरी में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**  
स्लाइड को ले जाकर उसके स्रोत रूप को संरक्षित करने हेतु स्रोत मास्टर को लक्ष्य में क्लोन करें और फिर उस क्लोन किए हुए मास्टर के साथ स्लाइड को [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslidecollection/) एवं [ISlideCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecollection/) से क्लोन करें। यह मास्टर, लेआउट और थीम को साथ रखता है।

**मैं उत्तराधिकार और ओवरराइड्स के बाद प्रभावी मान कैसे देख सकता हूँ?**  
स्लाइड या लेआउट थीम के लिये उपयोग करें [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseoverridethememanager/) और फॉर्मेट ऑब्जेक्ट्स जैसे [Background.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/background/) तथा [FillFormat.getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/fillformat/) के संबंधित प्रभावी‑डेटा मेथड्स। ये API उत्तराधिकार और ओवरराइड लागू होने के बाद हल किए गये मान लौटाते हैं।