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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में मास्टर प्रस्तुति थीम को बनाने, अनुकूलित करने और PowerPoint फ़ाइलों को सुसंगत ब्रांडिंग के साथ परिवर्तित करने के लिए।"
---
## **परिचय**

एक प्रस्तुति थीम रंगों, फ़ॉन्टों, पृष्ठभूमि शैलियों, भरावों, रेखाओं और प्रभावों का समन्वित सेट परिभाषित करती है। थीम‑जानकार वस्तुएँ इन साझा परिभाषाओं को संदर्भित करती हैं बजाय प्रत्येक दृश्य गुण को स्थिर मान के रूप में संग्रहीत करने के, ताकि थीम परिवर्तन कई वस्तुओं को एक साथ अद्यतन कर सके।

Aspose.Slides में, प्रस्तुति स्तर की थीम उपलब्ध है [Presentation.getMasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/)। एक प्रस्तुति में निचले स्तरों पर थीम ओवरराइड भी हो सकते हैं। एक मास्टर प्रस्तुति थीम को [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/java/com.aspose.slides/masterthememanager/) के माध्यम से ओवरराइड कर सकता है, जबकि लेआउट या व्यक्तिगत स्लाइड अपनी विरासत में मिली थीम को [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/) के माध्यम से ओवरराइड कर सकती है। व्यावहारिक रूप से, एक स्लाइड के लिए प्रभावी थीम इस विरासत श्रृंखला के माध्यम से निर्धारित होती है: प्रस्तुति थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![थीम घटक: रंग, फ़ॉन्ट, पृष्ठभूमि शैलियाँ, और प्रभाव](theme-constituents.png)

नीचे दिए गए अनुभाग सबसे सामान्य थीम कार्यप्रवाह दिखाते हैं: थीम का निरीक्षण, रंग और फ़ॉन्ट बदलना, थीम की प्रतिलिपि बनाना या लागू करना, पृष्ठभूमि और प्रभाव शैलियों को अपडेट करना, और विरासत और ओवरराइड के समाधान के बाद प्रभावी मान पढ़ना।

## **थीम का निरीक्षण**

The [MasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/) ऑब्जेक्ट थीम की रंग योजना, फ़ॉन्ट योजना और फ़ॉर्मेट योजना को [MasterTheme.getColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/), और [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/java/com.aspose.slides/mastertheme/) के माध्यम से उपलब्ध कराता है। उन्हें बदलने से पहले इन संग्रहों का निरीक्षण करना विशेष रूप से उपयोगी है जब प्रस्तुति बाहरी स्रोत से आती है क्योंकि शैली प्रविष्टियों की संख्या और सामग्री भिन्न हो सकती है।

निम्न उदाहरण मुख्य थीम गुण पढ़ता है और रिपोर्ट करता है कि थीम में कितनी पृष्ठभूमि, भराव, रेखा, और प्रभाव शैलियाँ संग्रहीत हैं:

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

यदि किसी फ़ाइल में कई मास्टर उपयोग हुए हैं, तो यह मान न रखें कि प्रत्येक स्लाइड की समान प्रभावी थीम है। स्लाइड से जुड़े मास्टर का निरीक्षण करें, और जब लेआउट या स्लाइड ओवरराइड मौजूद हों तो इस लेख में बाद में दिखाए गए प्रभावी-थीम कार्यप्रवाह का उपयोग करें।

## **थीम के रंग बदलें**

थीम‑जानकार भराव, रेखाएँ और पाठ [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/) enumeration से एक तर्कसंगत रंग का संदर्भ ले सकते हैं। जब आप [IColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/icolorscheme/) में संबंधित प्रविष्टि बदलते हैं, तो सभी वस्तुएँ जो अभी भी उस थीम रंग को संदर्भित करती हैं, नए मान के अनुसार हल हो जाती हैं। सीधे RGB रंग का उपयोग करने वाली वस्तुओं को थीम‑रंग अपडेट से नहीं बदला जाता।

निम्न अंत‑से‑अंत उदाहरण एक आकार बनाता है जो `Accent4` का उपयोग करता है, थीम के `Accent4` रंग को लाल में बदलता है, प्रस्तुति को सहेजता है, इसे पुनः खोलता है, और प्रभावी भराव रंग को प्रिंट करता है:

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

क्योंकि आयत `Accent4` से जुड़ी रहती है, थीम बदले जाने के बाद उसका दिखने वाला रंग लाल हो जाता है। यदि आप आकार पर स्कीम रंग को सीधे रंग से बदलते हैं, तो बाद में `Accent4` में परिवर्तन उस भराव को अब प्रभावित नहीं करेंगे।

### **अतिरिक्त पैलेट से रंगों का उपयोग**

PowerPoint एक थीम रंग से हल्के और गहरे विविधता को रंग रूपांतरण लागू करके प्राप्त करता है। Aspose.Slides इन रूपांतरणों को [ColorTransformOperation](https://reference.aspose.com/slides/java/com.aspose.slides/colortransformoperation/) enumeration के माध्यम से उजागर करता है।

![मुख्य थीम रंग और अतिरिक्त पैलेट से उत्पन्न हल्के एवं गहरे रंग](additional-palette-colors.png)

**1** - मुख्य थीम रंग।  
**2** - मुख्य थीम रंगों से उत्पन्न हल्के और गहरे विविधताएँ।

निम्न उदाहरण `Accent4` पर आधारित छह आयत बनाता है, उन में से पाँच पर ल्यूमिनेंस रूपांतरण लागू करता है, और परिणाम को सहेजता है:

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

ये विविधताएँ थीम रंग पर आधारित रहती हैं। यदि बाद में `Accent4` बदलता है, तो रूपांतरित रंग नए `Accent4` मान से पुनः गणना किए जाते हैं।

### **`SchemeColor` मानों को `IColorScheme` स्लॉट्स से मैप करें**

[SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/) enumeration `Text1`, `Background1`, `Text2`, और `Background2` का उपयोग करती है, जबकि [IColorScheme](https://reference.aspose.com/slides/java/com.aspose.slides/icolorscheme/) समान थीम स्लॉट्स को `Dark1`, `Light1`, `Dark2`, और `Light2` के रूप में उजागर करता है। मैपिंग स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ये वैकल्पिक नाम समान थीम स्लॉट्स के हैं; वे किसी रूपांतरण के माध्यम से गतिशील रूप से परिवर्तित नहीं होते।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट योजना में शीर्षकों के लिए प्रमुख फ़ॉन्ट सेट और मुख्य पाठ के लिए गौण फ़ॉन्ट सेट होता है। [IFontScheme.getMajor](https://reference.aspose.com/slides/java/com.aspose.slides/ifontscheme/) और [IFontScheme.getMinor](https://reference.aspose.com/slides/java/com.aspose.slides/ifontscheme/) विधियाँ उन सेटों को उजागर करती हैं।

PowerPoint‑compatible थीम फ़ॉन्ट पहचानकर्ता को पाठ स्वरूपण में उपयोग किया जा सकता है:

* `+mn-lt` - बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* `+mj-lt` - हेडिंग फ़ॉन्ट लैटिन (Major Latin Font)
* `+mn-ea` - बॉडी फ़ॉन्ट ईस्ट एशियन (Minor East Asian Font)
* `+mj-ea` - हेडिंग फ़ॉन्ट ईस्ट एशियन (Major East Asian Font)
* `+mn-cs` - बॉडी फ़ॉन्ट कॉम्प्लेक्स स्क्रिप्ट (Minor Complex Script Font)
* `+mj-cs` - हेडिंग फ़ॉन्ट कॉम्प्लेक्स स्क्रिप्ट (Major Complex Script Font)

निम्न उदाहरण एक शीर्षक बनाता है जो प्रमुख लैटिन थीम फ़ॉन्ट का उपयोग करता है और एक बॉडी पंक्ति बनाता है जो गौण लैटिन थीम फ़ॉन्ट का उपयोग करती है। फिर यह थीम फ़ॉन्ट बदलता है और परिणाम सहेजता है:

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

शीर्षक प्रमुख फ़ॉन्ट का अनुसरण करता है और बॉडी पाठ गौण फ़ॉन्ट का। जिस पाठ में स्पष्ट फ़ॉन्ट नाम है न कि थीम पहचानकर्ता, वह थीम फ़ॉन्ट योजना बदलने पर स्वतः नहीं बदलेगा।

मुख्य और गौण फ़ॉन्ट संग्रह में व्यक्तिगत लेखन प्रणाली जैसे सायरिलिक, अरबी, जापानी, जॉर्जियन और थाना के लिए फ़ॉन्ट मैपिंग भी हो सकते हैं। इन्हें निरीक्षण, जोड़ने, बदलने या हटाने के लिए देखें [Script-Specific Theme Fonts](/slides/hi/java/script-specific-font-mappings/)।

{{% alert color="info" title="Tip" %}}
प्रस्तुति फ़ॉन्ट के बारे में अधिक जानकारी के लिए देखें [PowerPoint Fonts](/slides/hi/java/powerpoint-fonts/)।
{{% /alert %}}

### **थीम फ़ॉन्ट संदर्भों को हल करें**

पाठ का निरीक्षण करते समय, [IFontData.getFontName](https://reference.aspose.com/slides/java/com.aspose.slides/ifontdata/#getFontName--) थीम संदर्भ जैसे `+mn-lt` लौट सकता है न कि फ़ॉन्ट परिवार नाम। उस संदर्भ को हल करने के लिए उपयुक्त [IThemeEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ithemeeffectivedata/) के साथ [IFontData.getFontName](https://reference.aspose.com/slides/java/com.aspose.slides/ifontdata/#getFontName-com.aspose.slides.IThemeEffectiveData-) को कॉल करें। `+mj` और `+mn` उपसर्ग प्रमुख और गौण फ़ॉन्ट सेट चुनते हैं; `-lt`, `-ea`, और `-cs` प्रत्यय क्रमशः उनके लैटिन, ईस्ट एशियन, और कॉम्प्लेक्स स्क्रिप्ट फ़ॉन्ट चुनते हैं।

इंद्रधनुश की प्रभावी थीम प्राप्त करने के लिए [IThemeable.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ithemeable/#createThemeEffective--) को उस वस्तु पर कॉल करें, जिस पर निरीक्षण किए गए पाठ की थीम लागू होती है। स्लाइड पर सामान्य पाठ के लिए, इस विधि को स्लाइड पर कॉल करें ताकि संदर्भ में उस स्लाइड की विरासत में मिली थीम और स्थानीय ओवरराइड शामिल हों। लेआउट या मास्टर को स्वयं निरीक्षण करते समय, उसकी अपनी प्रभावी थीम उपयोग करें। यह न मानें कि पहले मास्टर की थीम सभी स्लाइड में लागू है।

निम्न उदाहरण एक पाठ भाग बनाता है जो स्पष्ट रूप से गौण लैटिन फ़ॉन्ट को संदर्भित करता है। यह [IOverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/java/com.aspose.slides/ioverridetheme/#initFontSchemeFromInherited--) के माध्यम से स्लाइड फ़ॉन्ट योजना को प्रारम्भ करता है और प्रमुख एवं गौण लैटिन परिवारों को क्रमशः `Arial` और `Calibri` सेट करता है, जिससे बिना इनपुट फ़ाइल के परिणाम पुनरुत्पादन योग्य बनता है।

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

आउटपुट `+mn-lt -> Calibri` के बाद `Verdana -> Verdana` है। संग्रहीत संदर्भ अपरिवर्तित रहता है, जबकि स्पष्ट परिवार नाम जैसा है वैसा ही लौटाया जाता है। यदि भाग `+mj-lt` का उपयोग करता, तो यह थीम में `Arial` को हल करता।

थीम संदर्भ को हल करना थीम द्वारा निर्दिष्ट फ़ॉन्ट परिवार की पहचान करता है। यह फ़ॉन्ट उपलब्धता की जाँच नहीं करता या रेंडरिंग के दौरान प्रतिस्थापन या ग्लिफ़ फ़ॉलबैक के बाद उपयोग किए गए फ़ॉन्ट फ़ाइल का निर्धारण नहीं करता। इन अलग चरणों के लिए देखें [Font Selection Sequence](/slides/hi/java/font-selection-sequence/) और [Font Substitution](/slides/hi/java/font-substitution/)।

## **थीम की प्रतिलिपि बनाना या लागू करना**

नीचे के कार्यप्रवाह विभिन्न थीम‑संबंधी समस्याओं को हल करते हैं।

### **बाहरी थीम को मास्टर‑निर्भर स्लाइड्स पर लागू करें**

[IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) का उपयोग करें जब आपके पास PowerPoint थीम फ़ाइल (`.thmx`) है और आप उस मास्टर पर निर्भर सभी स्लाइड्स को पुनः शैली देना चाहते हैं। चयनित मास्टर को [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) संग्रह से चुनें, जो [IMasterSlideCollection](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) को कार्यान्वित करता है, और थीम फ़ाइल पथ को विधि को पास करें।

विधि निम्नलिखित कार्य करती है:

1. चयनित मास्टर के आधार पर एक नया मास्टर स्लाइड बनाता है।  
1. नए मास्टर पर बाहरी थीम लागू करता है।  
1. पहले चयनित मास्टर पर निर्भर सभी स्लाइड को नए मास्टर को असाइन करता है।  
1. नवीन निर्मित [IMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) को लौटाता है।

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

अमान्य, भ्रष्ट या असमर्थित थीम से [PptxReadException](https://reference.aspose.com/slides/java/com.aspose.slides/pptxreadexception/) उत्पन्न हो सकता है। उपयोगकर्ताओं द्वारा प्रदान किए गए पथ को मान्य करें, फ़ाइल‑सिस्टम पहुँच विफलताओं को संभालें, और केवल तब प्रस्तुति सहेजें जब थीम सफलतापूर्वक लागू हो गई हो।

केवल उन स्लाइड्स को पुनः असाइन किया जाता है जो चयनित मास्टर पर निर्भर थीं। अन्य मास्टरों से जुड़े स्लाइड्स अपने मौजूदा मास्टर और थीम को बरकरार रखते हैं। थीम‑जानकार रंग, फ़ॉन्ट, भराव, रेखा, पृष्ठभूमि और प्रभाव बाहरी थीम के आधार पर हल होते हैं। सीधे असाइन किए गए रंग, फ़ॉन्ट, भराव और अन्य स्पष्ट स्वरूपण अपरिवर्तित रह सकते हैं। लेआउट‑स्तर और स्लाइड‑स्तर ओवरराइड भी नई मास्टर से विरासत में मिली मानों पर प्राथमिकता ले सकते हैं।

थीम ऐसे फ़ॉन्ट को संदर्भित कर सकती है जो रन‑टाइम वातावरण में उपलब्ध नहीं हैं। सुसंगत रेंडरिंग और निर्यात के लिए आवश्यक फ़ॉन्ट स्थापित करें, उन्हें [custom font sources](/slides/hi/java/custom-font/) के माध्यम से प्रदान करें, या [font substitution](/slides/hi/java/font-substitution/) को कॉन्फ़िगर करें।

यह एक सीधा मास्टर‑स्तर कार्यप्रवाह है: विधि `.thmx` फ़ाइल के पथ को स्वीकार करती है और स्लाइड‑स्तर या लेआउट‑स्तर थीम ओवरराइड को मैन्युअल रूप से बनाने की आवश्यकता नहीं होती।

### **बहु‑मास्टर प्रस्तुति में विभिन्न बाहरी थीम लागू करें**

जब सम्बंधित मास्टर अग्रिम में ज्ञात न हो, तो उसे प्रतिनिधि स्लाइड से [ISlide.getLayoutSlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide/) और [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/java/com.aspose.slides/ilayoutslide/) के माध्यम से प्राप्त करें। थीम लागू करने से पहले मूल मास्टर संदर्भों को संग्रहीत करें क्योंकि प्रत्येक कॉल प्रस्तुति में एक नया मास्टर बनाता है।

निम्न उदाहरण दो भागों की स्लाइड्स का उपयोग करके उनके मास्टर ढूँढ़ता है और प्रत्येक समूह पर अलग-अलग बाहरी थीम लागू करता है:

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

पहली कॉल केवल उन स्लाइड्स को प्रभावित करती है जो `firstGroupMaster` पर निर्भर थीं, और दूसरी कॉल केवल उन स्लाइड्स को प्रभावित करती है जो `secondGroupMaster` पर निर्भर थीं। अन्य मास्टरों से संबंधित स्लाइड्स की शैली नहीं बदली जाती।

### **स्लाइड्स को स्थानांतरित करते समय स्रोत थीम संरक्षित रखें**

यदि आप स्लाइड को किसी अन्य प्रस्तुति में ले जाना चाहते हैं और उसकी मूल डिज़ाइन को संरक्षित रखना चाहते हैं, तो स्रोत मास्टर को लक्ष्य प्रस्तुति में [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) के साथ क्लोन करें, फिर स्लाइड को [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/) और क्लोन किए गए मास्टर के साथ क्लोन करें। यह मास्टर, उसके लेआउट और सम्बंधित थीम को साथ ले जाता है।

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

जब स्रोत स्लाइड को लक्ष्य में समान दिखना चाहिए, तब यह वांछित कार्यप्रवाह है। केवल सामग्री को किसी असंबंधित लक्ष्य मास्टर पर क्लोन करने से थीम‑चालित रंग, फ़ॉन्ट, पृष्ठभूमि और प्रभाव बदल सकते हैं।

### **मौजूदा स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को वर्तमान मास्टर और लेआउट पर ही रहना है, तो स्रोत थीम से स्लाइड‑स्तर ओवरराइड को आरंभ करें। [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/) , [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/) और [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/) विधियाँ तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करती हैं।

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

यह उस स्लाइड द्वारा उपयोग की गई थीम को बदलता है बिना अन्य स्लाइड्स द्वारा विरासत में मिली थीम को बदले। स्थानीय ओवरराइट हटाने और विरासत मानों पर लौटने के लिए, [OverrideTheme.clear](https://reference.aspose.com/slides/java/com.aspose.slides/overridetheme/) को कॉल करें।

### **लेआउट पर थीम ओवरराइड लागू करें**

लेआउट‑स्तर ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट का उपयोग करती हैं, जब तक कि किसी विशेष स्लाइड का अपना ओवरराइड न हो। समान आरम्भ विधियों को [LayoutSlideThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/layoutslidethememanager/) के माध्यम से उपयोग किया जा सकता है:

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

जब कई लेआउट और स्लाइड समान बेस डिज़ाइन साझा करना चाहते हों, तो मास्टर या प्रस्तुति‑स्तर थीम उपयोग करें, जब एक लेआउट परिवार को अलग शैली चाहिए तो लेआउट ओवरराइड, और केवल वास्तविक अपवादों के लिए स्लाइड ओवरराइड। अत्यधिक स्लाइड‑स्तर ओवरराइड बाद में वैश्विक थीम परिवर्तन को भविष्यवाणी करना कठिन बना देते हैं।

<!-- visual-explanation:presentation-theme:start -->
[![एक मास्टर थीम दो लेआउट को फीड करती है; एक लेआउट ओवरराइड उसके स्लाइड्स को प्रभावित करता है सिवाय एक स्लाइड के जिसके पास अधिक स्थानीय ओवरराइड है।](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*एक लेआउट ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट का उपयोग करती हैं, जब तक कि स्लाइड अपना स्वयं का ओवरराइड न प्रदान करे। थीम‑आधारित मान उनके हल किए गए स्कीम का पालन करते हैं; स्पष्ट रूप से स्वरूपित वस्तुएँ अपनी स्थानीय उपस्थिति बनाए रख सकती हैं। ओवरराइड को इच्छित डिज़ाइन अपवाद जितना संभव हो संकीर्ण रखें।*
<!-- visual-explanation:presentation-theme:end -->

## **थीम पृष्ठभूमि शैलियों को अपडेट करें**

थीम की पृष्ठभूमि भराव [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/) में संग्रहीत होते हैं। PowerPoint अपने UI में इस संग्रह में शारीरिक रूप से संग्रहीत भराव परिभाषाओं की संख्या से अधिक पृष्ठभूमि विकल्प दिखा सकता है क्योंकि UI थीम भराव को थीम रंगों और अन्य शैली संदर्भों के साथ संयोजित कर सकता है।

![PowerPoint प्रस्तुति थीम के लिए पृष्ठभूमि शैली गैलरी](presentation-design_8.png)

पृष्ठभूमि शैली का उपयोग करने से पहले, संग्रहित संग्रह और वर्तमान [Background.getStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/background/) का निरीक्षण करें। शैली सूचकांक `0` का मतलब कोई थीम भराव नहीं; सकारात्मक मान थीम पृष्ठभूमि‑शैली संदर्भ होते हैं। यह सीधे Java संग्रह को इंडेक्स करने से अलग है, जहाँ `get_Item(0)` पहला संग्रहीत आइटम दर्शाता है। यह न मानें कि प्रत्येक प्रस्तुति में समान संख्या में पृष्ठभूमि भराव शैलियाँ होती हैं।

निम्न उदाहरण उपलब्ध पृष्ठभूमि भराव गणना रिपोर्ट करता है, पहले मास्टर को थीम पृष्ठभूमि संदर्भ असाइन करता है, और प्रस्तुति को सहेजता है:

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

दृश्यमान परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि और लेआउट या स्लाइड स्तर पर किसी भी पृष्ठभूमि ओवरराइड पर निर्भर करता है। यदि स्लाइड अपनी स्वयं की पृष्ठभूमि उपयोग करता है, तो केवल मास्टर पृष्ठभूमि बदलने से वह स्लाइड नहीं बदलेगी। विरासत लागू होने के बाद अंतिम पृष्ठभूमि जानने के लिए [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/) का उपयोग करें।

{{% alert color="warning" title="Warning" %}}
शैली सूचकांक को शून्य‑आधारित संग्रह सूचकांक न समझें। साथ ही एक फ़ाइल से शैली संख्या को हार्ड‑कोड करने और मानने से बचें कि उसका स्वरूप दूसरे फ़ाइल में भी समान है; थीम शैली परिभाषाएँ प्रस्तुति‑विशिष्ट होती हैं।
{{% /alert %}}

{{% alert color="info" title="Tip" %}}
सीधे पृष्ठभूमि स्वरूपण और पृष्ठभूमि विरासत के लिए देखें [Presentation Background](/slides/hi/java/presentation-background/)।
{{% /alert %}}

## **थीम प्रभावों को अपडेट करें**

एक थीम फ़ॉर्मेट स्कीम में अलग‑अलग भराव, रेखा, और प्रभाव शैली संग्रह होते हैं, जो क्रमशः [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/), और [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/java/com.aspose.slides/iformatscheme/) के द्वारा उजागर होते हैं। सामान्य Office थीम अक्सर तीन प्रमुख शैली प्रविष्टियों को शामिल करती हैं जो दृश्य रूप से सूक्ष्म, मध्यम, और तीव्र स्वरूपण से मेल खाती हैं, लेकिन कोड को प्रत्येक संग्रह का निरीक्षण करना चाहिए न कि निश्चित संख्या मान लेना चाहिए।

![समान आकार पर लागू सूक्ष्म, मध्यम, और तीव्र थीम प्रभाव](presentation-design_10.png)

जब आप Java में इन संग्रहों तक पहुँचते हैं, तो संग्रह सूचकांक शून्य‑आधारित होता है: `get_Item(0)` पहला संग्रहीत शैली है और `get_Item(2)` तीसरा। आकार की शैली‑संदर्भ सूचकांक एक अलग अवधारणा है, जो [IShapeStyle](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/) द्वारा उजागर होती है। थीम शैली को संशोधित करने से उन आकारों पर प्रभाव पड़ता है जो उस थीम शैली को संदर्भित करते हैं; सीधे स्वरूपित आकार अपरिवर्तित रह सकते हैं।

निम्न उदाहरण जांचता है कि आवश्यक शैली प्रविष्टियां मौजूद हैं, पहली रेखा शैली बदलता है, तीसरी भराव शैली बदलता है, तीसरी प्रभाव शैली में बाहरी छाया सक्षम करता है, और परिणाम सहेजता है:

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

इन स्लॉटों को संदर्भित करने वाले आकारों के लिए, पहली थीम रेखा शैली लाल हो जाती है, तीसरी थीम भराव शैली ठोस फॉरेस्ट ग्रीन हो जाती है, और तीसरी प्रभाव शैली में 10 पॉइंट दूरी वाली बाहरी छाया मिलती है। सटीक दृश्य परिणाम अभी भी इस पर निर्भर करता है कि प्रत्येक आकार किन शैली स्लॉटों को संदर्भित करता है और क्या सीधे स्वरूपण थीम को ओवरराइड करता है।

![रेखा, भराव, और छाया सेटिंग बदलने के बाद थीम प्रभाव शैलियां](presentation-design_11.png)

## **एक आकार के लिए थीम भराव और रेखा शैलियों का चयन करें**

एक आकार अपने भराव और रूपरेखा को स्वतंत्र रूप से [IShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/#setFillStyleIndex-short-) और [IShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/java/com.aspose.slides/ishapestyle/#setLineStyleIndex-int-) के द्वारा चुन सकता है। प्रत्येक विधि के लिए, सूचकांक `1` संबंधित थीम संग्रह में पहली प्रविष्टि (`get_Item(0)`) चुनता है, और सूचकांक `2` दूसरी (`get_Item(1)`) चुनता है।

निम्न उदाहरण नए प्रस्तुति की डिफ़ॉल्ट थीम में दो भराव शैलियां (स्वर्ण और आकाश नीला) और दो रेखा शैलियां (6 pt पर गहरा नीला और 12 pt पर गहरा लाल) सेट करता है। यह स्लाइड को तीन चरणों में सहेजता है ताकि आप PowerPoint में परिणामों की तुलना कर सकें।

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IFormatScheme styles = presentation.getMasterTheme().getFormatScheme();

    IFillFormat goldFill = styles.getFillStyles().get_Item(0);
    goldFill.setFillType(FillType.Solid);
    goldFill.getSolidFillColor().setColor(new Color(255, 215, 0));
    IFillFormat blueFill = styles.getFillStyles().get_Item(1);
    blueFill.setFillType(FillType.Solid);
    blueFill.getSolidFillColor().setColor(new Color(135, 206, 235));

    ILineFormat thinLine = styles.getLineStyles().get_Item(0);
    thinLine.getFillFormat().setFillType(FillType.Solid);
    thinLine.getFillFormat().getSolidFillColor().setColor(new Color(0, 0, 139));
    thinLine.setWidth(6);
    ILineFormat thickLine = styles.getLineStyles().get_Item(1);
    thickLine.getFillFormat().setFillType(FillType.Solid);
    thickLine.getFillFormat().getSolidFillColor().setColor(new Color(139, 0, 0));
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

    goldFill.getSolidFillColor().setColor(new Color(46, 139, 87));
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| प्रारंभिक शैलियां | दायाँ रूपरेखा बदलें | पहली थीम भराव संपादित करें |
|:---:|:---:|:---:|
| ![स्वर्ण और आकाश‑नीले आयतें मिलते-जुलते पतले गहरे नीले रूपरेखा के साथ](theme-style-initial.png) | ![आकाश‑नीला आयत अब मोटी गहरी लाल रूपरेखा रखता है](theme-style-line-changed.png) | ![बायाँ आयत अब हरा है और दोनों रूपरेखा अपरिवर्तित हैं](theme-style-fill-changed.png) |

भिन्न रेखा शैली का चयन केवल दाएँ आयत की रूपरेखा बदलता है। पहली थीम भराव को संपादित करने से इसका उपयोग करने वाले सभी आकार अपडेट होते हैं। यहाँ केवल बायाँ आयत हरा हो जाता है।

मौजूदा आकार पर, स्थानीय भराव रंग, रेखा रंग, या रेखा चौड़ाई थीम शैली के उस भाग को ओवरराइड कर सकती है। यदि शैली सूचकांक बदलने से कोई दृश्य प्रभाव नहीं दिखता, तो आकार की [direct formatting](/slides/hi/java/shape-formatting/) जांचें।

## **निर्धारित करें कि प्रभावी ठोस भराव थीम रंग उपयोग करता है या नहीं**

एक भराव वस्तु पर सीधे संग्रहीत हो सकता है या पैराग्राफ, लेआउट, मास्टर, थीम शैली, या किसी अन्य स्वरूपण स्तर से विरासत में मिल सकता है। उस पदानुक्रम को अनिर्दिष्ट [IFillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/) द्वारा अस्थिर [IFillFormatEffectiveData](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) में हल करें। पहले [IFillFormatEffectiveData.getFillType](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) जांचें। केवल जब यह `FillType.Solid` हो, तब ठोस‑भराव गुण पढ़ें।

ठोस‑भराव के लिए, [IFillFormatEffectiveData.getSolidFillColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) विरासत, थीम लुक‑अप, और रंग रूपांतरण लागू करने के बाद अंतिम रेंडर किया गया RGB मान लौटाता है। [IFillFormatEffectiveData.getSolidFillSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformateffectivedata/) संबंधित तर्कसंगत [SchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/schemecolor/) स्लॉट लौटाता है, जैसे `Text1` या `Accent6`। `SchemeColor.NotDefined` का मान दर्शाता है कि प्रभावी ठोस भराव किसी स्कीम रंग पर आधारित नहीं है। थीम‑रंग या सीधे RGB रंग वाले कार्यप्रवाह में, यह मान सीधे RGB भराव की पहचान करता है।

स्थानीय [IColorFormat.getSchemeColor](https://reference.aspose.com/slides/java/com.aspose.slides/icolorformat/) मान को अकेले प्रयोग करके भराव वर्गीकृत न करें। उदाहरण के लिए, कोई पाठ भाग स्थानीय रूप से स्कीम रंग परिभाषित नहीं रखता, इसलिए उसका स्थानीय मान `NotDefined` हो सकता है, जबकि उसका प्रभावी भराव थीम रंग विरासत में लेकर `Text1` या `Accent6` में हल हो सकता है। इसके विपरीत, `getSolidFillSchemeColor` बताता है कि कौन सा तर्कसंगत थीम स्लॉट प्रभावी रंग उत्पन्न करता है, लेकिन यह नहीं बताता कि वह स्लॉट वस्तु, पैराग्राफ, लेआउट, मास्टर या किसी अन्य स्तर से आया है।

निम्न उदाहरण एक प्रस्तुति लोड करता है, दोनों आकार भराव और पाठ‑भाग भराव का ऑडिट करता है, प्रत्येक अंतिम RGB मान और संबंधित स्कीम रंग को प्रिंट करता है, और उन ठोस भरावों को चिन्हित करता है जो थीम रंग परिवर्तनों का अनुसरण नहीं करेंगे:

```java
import com.aspose.slides.*;
import java.awt.Color;
import java.util.function.BiConsumer;

BiConsumer<String, IFillFormat> auditFill = (objectName, localFill) -> {
    IFillFormatEffectiveData effectiveFill = localFill.getEffective();

    if (effectiveFill.getFillType() != FillType.Solid) {
        System.out.println(objectName + ": fill type = " + effectiveFill.getFillType() + "; not a solid fill.");
        return;
    }

    Color rgb = effectiveFill.getSolidFillColor();
    int effectiveSchemeColor = effectiveFill.getSolidFillSchemeColor();
    int localSchemeColor = localFill.getSolidFillColor().getSchemeColor();

    System.out.printf("%s: RGB = #%02X%02X%02X%n", objectName, rgb.getRed(), rgb.getGreen(), rgb.getBlue());
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

`NotDefined` शाखा उन ठोस भरावों की ऑडिट सूची प्रदान करती है जो थीम रंग स्लॉट बदलने पर प्रतिक्रिया नहीं देंगे। जब प्रस्तुति को नई ब्रांड पैलेट अपनाना हो, तब उन वस्तुओं की समीक्षा करें। रिपोर्ट किया गया RGB मान अभी भी वर्तमान उपस्थिति दिखाता है, जबकि स्कीम मान समझाता है कि वह उपस्थिति थीम से जुड़ी है या नहीं।

Effective‑format वस्तुएँ स्नैपशॉट होती हैं। प्रस्तुति थीम, थीम ओवरराइड, या कोई विरासत स्वरूपण बदलने के बाद, फिर से `getEffective` कॉल करें और नई `IFillFormatEffectiveData` वस्तु पढ़ें, फिर रंगों की तुलना या रिपोर्ट करें।

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम ऑब्जेक्ट बताते हैं कि किसी विशेष स्तर पर क्या परिभाषित है। प्रभावी मान बताते हैं कि विरासत और स्थानीय ओवरराइड के समाधान के बाद स्लाइड या आकार वास्तव में क्या उपयोग करता है। स्लाइड के लिए, [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/) कॉल करें। पृष्ठभूमि के लिए, [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/) उपयोग करें, और भराव के लिए, [FillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/) उपयोग करें।

निम्न उदाहरण स्लाइड से प्रभावी थीम, पृष्ठभूमि, और पहले आकार भराव को पढ़ता है:

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

रेंडरिंग निदान, मान्यकरण, और तुलना के लिए प्रभावी डेटा उपयोग करें। यदि आप केवल [Presentation.getMasterTheme](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) का निरीक्षण करते हैं, तो आप किसी मास्टर, लेआउट, स्लाइड, या आकार ओवरराइड को मिस कर सकते हैं जो अंतिम रूप बदलता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**बाहरी थीम लागू करने से क्या प्रस्तुति की सभी स्लाइड प्रभावित होती हैं?**

नहीं। [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/) केवल उन स्लाइड्स को पुनः असाइन करता है जो चयनित मास्टर पर निर्भर थीं। अन्य मास्टरों का उपयोग करने वाली स्लाइड्स अपनी मौजूदा थीम रखती हैं।

**क्या मैं मास्टर बदले बिना किसी एकल स्लाइड पर थीम लागू कर सकता हूँ?**

हां। स्लाइड के [SlideThemeManager](https://reference.aspose.com/slides/java/com.aspose.slides/slidethememanager/) का उपयोग करके उसकी ओवरराइड थीम को प्रारम्भ करें। यह परिवर्तन केवल उस स्लाइड तक सीमित रहता है; अन्य स्लाइड्स अपनी मौजूदा थीम विरासत में लेती रहती हैं।

**एक प्रस्तुति से दूसरी में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

जब स्लाइड को ले जाकर उसके स्रोत रूप को संरक्षित रखना हो, तो स्रोत मास्टर को लक्ष्य में क्लोन करें और फिर उस मास्टर के साथ स्लाइड को [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslidecollection/) और [ISlideCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/islidecollection/) का उपयोग करके क्लोन करें। यह मास्टर, लेआउट और थीम को साथ रखता है।

**मैं विरासत और ओवरराइड के बाद प्रभावी मान कैसे देख सकता हूँ?**

[BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/java/com.aspose.slides/baseoverridethememanager/) का उपयोग करके स्लाइड या लेआउट थीम के प्रभावी डेटा प्राप्त करें और फ़ॉर्मेट ऑब्जेक्ट्स जैसे [Background.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/background/) और [FillFormat.getEffective](https://reference.aspose.com/slides/java/com.aspose.slides/fillformat/) की संबंधित प्रभावी‑डेटा विधियों को कॉल करें। ये API विरासत और ओवरराइड लागू होने के बाद हल किए गए मान लौटाते हैं।