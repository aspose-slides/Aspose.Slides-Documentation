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
description: "Aspose.Slides for Java में मुख्य प्रस्तुति थीम को उपयोग करके, PowerPoint फ़ाइलों को सुसंगत ब्रांडिंग के साथ बनाएं, अनुकूलित करें और रूपांतरित करें।"
---
## **परिचय**

एक प्रस्तुति थीम रंगों, फ़ॉन्टों, पृष्ठभूमि शैलियों, भरावों, रेखाओं और प्रभावों का समन्वित सेट परिभाषित करती है। थीम‑सचेत वस्तुएँ इन साझा परिभाषाओं को संदर्भित करती हैं न कि प्रत्येक दृश्य गुण को स्थायी मान के रूप में संग्रहीत करती हैं, इसलिए थीम परिवर्तन कई वस्तुओं को एक साथ अपडेट कर सकता है।

Aspose.Slides में, प्रस्तुति‑स्तर की थीम [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) के माध्यम से उपलब्ध है। एक प्रस्तुति में निचले स्तरों पर थीम ओवरराइड भी हो सकते हैं। एक मास्टर [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/masterthememanager/) के द्वारा प्रस्तुति थीम को ओवरराइड कर सकता है, जबकि लेआउट या व्यक्तिगत स्लाइड अपने विरासत में मिली थीम को [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseoverridethememanager/) द्वारा ओवरराइड कर सकते हैं। व्यावहारिक रूप से, एक स्लाइड के लिए प्रभावी थीम इस विरासत शृंखला द्वारा निकाली जाती है: प्रस्तुति थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![थीम घटक: रंग, फ़ॉन्ट, पृष्ठभूमि शैलियाँ, और प्रभाव](theme-constituents.png)

नीचे के अनुभाग सबसे सामान्य थीम वर्कफ़्लो दिखाते हैं: थीम जांचना, रंग और फ़ॉन्ट बदलना, थीम कॉपी या लागू करना, पृष्ठभूमि और प्रभाव शैलियों को अपडेट करना, और विरासत एवं ओवरराइड के बाद प्रभावी मान पढ़ना।

## **थीम की जाँच करें**

[MasterTheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/mastertheme/) ऑब्जेक्ट थीम की रंग योजना, फ़ॉन्ट योजना, तथा फ़ॉर्मेट योजना को क्रमशः [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/mastertheme/), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/mastertheme/), और [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/mastertheme/) के माध्यम से उजागर करता है। इन्हें बदलने से पहले इन संग्रहों की जाँच करना विशेष रूप से उपयोगी है जब प्रस्तुति बाहरी स्रोत से आती है क्योंकि शैली प्रविष्टियों की संख्या और सामग्री अलग‑अलग हो सकती है।

निम्न उदाहरण मुख्य थीम गुण पढ़ता है और रिपोर्ट करता है कि थीम में कितनी पृष्ठभूमि, भराव, रेखा और प्रभाव शैलियाँ संग्रहीत हैं:

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

यदि कोई फ़ाइल कई मास्टर उपयोग करती है, तो यह न मानें कि हर स्लाइड का प्रभावी थीम समान है। स्लाइड से जुड़ा मास्टर जाँचें, और जब लेआउट या स्लाइड ओवरराइड मौजूद हों तो बाद में दिखाए गए प्रभावी‑थीम वर्कफ़्लो का उपयोग करें।

## **थीम के रंग बदलें**

थीम‑सचेत भराव, रेखा और टेक्स्ट [SchemeColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/schemecolor/) enumeration से एक तर्कसंगत रंग का संदर्भ ले सकते हैं। जब आप [IColorScheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icolorscheme/) में संबंधित प्रविष्टि बदलते हैं, तो सभी वस्तुएँ जो अभी भी उस थीम रंग को संदर्भित करती हैं, नए मान के विरुद्ध हल हो जाती हैं। सीधे RGB रंग का उपयोग करने वाली वस्तुओं को थीम‑रंग अपडेट से नहीं बदला जाता।

निम्न समाप्त‑से‑समाप्त उदाहरण एक आकृति बनाता है जो `Accent4` का उपयोग करती है, थीम के `Accent4` रंग को लाल में बदलता है, प्रस्तुति सहेजता है, फिर उसे पुनः खोलता है और प्रभावी भराव रंग प्रिंट करता है:

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

क्योंकि आयत `Accent4` से जुड़ी रहती है, थीम बदलने पर उसका दृश्य रंग लाल हो जाता है। यदि आप आकृति पर योजना रंग को सीधे रंग से बदल देते हैं, तो बाद में `Accent4` में बदलाव उस भराव को नहीं प्रभावित करेंगे।

### **अतिरिक्त पैलेट से रंग उपयोग करें**

PowerPoint एक थीम रंग से हल्के और गहरे रूपांतर उत्पन्न करता है। Aspose.Slides इन रूपांतरणों को [ColorTransformOperation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/colortransformoperation/) enumeration के माध्यम से उजागर करता है।

![मुख्य थीम रंग और अतिरिक्त पैलेट से उत्पन्न हल्के एवं गहरे रंग](additional-palette-colors.png)

**1** - मुख्य थीम रंग।

**2** - मुख्य थीम रंगों से उत्पन्न हल्के और गहरे रूपांतरण।

निम्न उदाहरण `Accent4` पर आधारित छह आयत बनाता है, उनमें से पाँच पर चमक परिवर्तन लागू करता है, और परिणाम सहेजता है:

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

ये रूपांतरण थीम रंग पर आधारित रहते हैं। यदि बाद में `Accent4` बदलता है, तो परिवर्तित रंग नए `Accent4` मान से पुनः गणना किए जाते हैं।

### **`SchemeColor` मानों को `IColorScheme` स्लॉट्स से मैप करें**

[SchemeColor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/schemecolor/) enumeration `Text1`, `Background1`, `Text2`, और `Background2` का उपयोग करता है, जबकि [IColorScheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/icolorscheme/) वही थीम स्लॉट्स `Dark1`, `Light1`, `Dark2`, तथा `Light2` के रूप में उजागर करता है। मैपिंग स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ये समान थीम स्लॉट्स के वैकल्पिक नाम हैं; इन्हें किसी रूप में से दूसरे रूप में गतिशील रूप से परिवर्तित नहीं किया जाता।

## **थीम के फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट योजना में शीर्षकों के लिए प्रमुख फ़ॉन्ट सेट और बॉडी टेक्स्ट के लिए गौण फ़ॉन्ट सेट होता है। [IFontScheme.getMajor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontscheme/) और [IFontScheme.getMinor](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ifontscheme/) विधियाँ उन सेटों को उजागर करती हैं।

PowerPoint‑अनुरूप थीम फ़ॉन्ट पहचानकर्ता टेक्स्ट स्वरूपण में उपयोग किए जा सकते हैं:

* `+mn‑lt` - बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* `+mj‑lt` - शीर्षक फ़ॉन्ट लैटिन (Major Latin Font)
* `+mn‑ea` - बॉडी फ़ॉन्ट ईस्ट एशियन (Minor East Asian Font)
* `+mj‑ea` - शीर्षक फ़ॉन्ट ईस्ट एशियन (Major East Asian Font)

निम्न उदाहरण एक शीर्षक बनाता है जो प्रमुख लैटिन थीम फ़ॉन्ट का उपयोग करता है और एक बॉडी पंक्ति बनाता है जो गौण लैटिन थीम फ़ॉन्ट का उपयोग करती है। फिर थीम फ़ॉन्ट बदलता है और परिणाम सहेजता है:

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

शीर्षक प्रमुख फ़ॉन्ट का अनुसरण करता है और बॉडी टेक्स्ट गौण फ़ॉन्ट का। स्पष्ट फ़ॉन्ट नाम वाला टेक्स्ट, थीम पहचानकर्ता के बजाय, थीम फ़ॉन्ट योजना बदलने पर स्वतः नहीं बदलता।

मुख्य और गौण फ़ॉन्ट संग्रहों में व्यक्तिगत लेखन प्रणालियों, जैसे सिरिलिक, अरबी, जापानी, जॉर्डियन, और थाना के लिए फ़ॉन्ट मैपिंग भी हो सकती है। इन्हें जाँचने, जोड़ने, बदलने या हटाने के लिए देखें [Script‑Specific Theme Fonts](/slides/hi/java/script-specific-font-mappings/)।

{{% alert color="info" title="सुझाव" %}}

प्रेज़ेंटेशन फ़ॉन्ट के बारे में अधिक जानकारी के लिए देखें [PowerPoint Fonts](/slides/hi/java/powerpoint-fonts/)।

{{% /alert %}}

## **थीम कॉपी या लागू करें**

नीचे के वर्कफ़्लो विभिन्न थीम‑संबंधी समस्याओं को हल करते हैं।

### **बाहरी थीम को मास्टर‑निर्भर स्लाइड्स पर लागू करें**

जब आपके पास PowerPoint थीम फ़ाइल (`.thmx`) हो और आप किसी विशेष मास्टर पर निर्भर सभी स्लाइड्स को पुनः शैलीबद्ध करना चाहते हों, तो [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterslide/) का उपयोग करें। चयनित मास्टर को [Presentation.getMasters](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) संग्रह (जो [IMasterSlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterslidecollection/) को लागू करता है) से चुनें, और विधि को थीम फ़ाइल पथ पास करें।

विधि निम्न कार्य करती है:

1. चयनित मास्टर के आधार पर एक नया मास्टर स्लाइड बनाती है।
1. बाहरी थीम को नए मास्टर पर लागू करती है।
1. नए मास्टर को सभी स्लाइड्स को असाइन करती है जो पहले चयनित मास्टर पर निर्भर थीं।
1. नवीनतम निर्मित [IMasterSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterslide/) लौटाती है।

निम्न उदाहरण पहली मास्टर पर निर्भर स्लाइड्स पर बाहरी थीम लागू करता है और प्रस्तुति सहेजता है:

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

एक अवैध, दूषित, या असमर्थित थीम [PptxReadException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pptxreadexception/) उत्पन्न कर सकती है। उपयोगकर्ता द्वारा प्रदान किए गए पथ को मान्य करें, फ़ाइल‑सिस्टम पहुँच विफलताओं को संभालें, और केवल तभी प्रस्तुति सहेजें जब थीम सफलतापूर्वक लागू हो गई हो।

केवल चयनित मास्टर पर निर्भर स्लाइड्स को पुनः असाइन किया जाता है। अन्य मास्टर से जुड़ी स्लाइड्स अपने मौजूदा मास्टर और थीम रखती हैं। थीम‑सचेत रंग, फ़ॉन्ट, भराव, रेखा, पृष्ठभूमि, और प्रभाव बाहरी थीम के विरुद्ध हल हो जाते हैं। सीधे असाइन किए गए रंग, फ़ॉन्ट, भराव और अन्य स्पष्ट स्वरूपण अपरिवर्तित रह सकते हैं। लेआउट‑स्तर और स्लाइड‑स्तर के ओवरराइड भी नई मास्टर से विरासत में मिले मानों पर प्राथमिकता ले सकते हैं।

थीम ऐसे फ़ॉन्ट संदर्भित कर सकती है जो रन‑टाइम पर्यावरण में उपलब्ध न हों। निरंतर रेंडरिंग और निर्यात के लिए आवश्यक फ़ॉन्ट स्थापित करें, उन्हें [कस्टम फ़ॉन्ट स्रोत](/slides/hi/java/custom-font/) के माध्यम से प्रदान करें, या [फ़ॉन्ट प्रतिस्थापन](/slides/hi/java/font-substitution/) कॉन्फ़िगर करें।

यह एक सीधा मास्टर‑स्तर वर्कफ़्लो है: विधि `.thmx` फ़ाइल पथ को स्वीकार करती है और स्लाइड‑स्तर या लेआउट‑स्तर के थीम ओवरराइड को मैन्युअल रूप से बनाने की आवश्यकता नहीं होती।

### **बहु‑मास्टर प्रस्तुति में विभिन्न बाहरी थीम लागू करें**

जब संबंधित मास्टर पहले से ज्ञात न हो, तो इसे प्रतिनिधि स्लाइड के माध्यम से [ISlide.getLayoutSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/) और [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutslide/) से प्राप्त करें। थीम लागू करने से पहले मूल मास्टर संदर्भों को संग्रहीत करें क्योंकि प्रत्येक कॉल प्रस्तुति में एक नया मास्टर बनाती है।

निम्न उदाहरण दो अनुभागों की स्लाइड्स से उनके मास्टर ढूँढ़ता है और प्रत्येक समूह पर अलग‑अलग बाहरी थीम लागू करता है:

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

पहली कॉल केवल उन स्लाइड्स को प्रभावित करती है जो `firstGroupMaster` पर निर्भर थीं, और दूसरी कॉल केवल `secondGroupMaster` पर निर्भर स्लाइड्स को। अन्य मास्टर से जुड़ी स्लाइड्स को पुनः शैलीबद्ध नहीं किया जाता।

### **स्लाइड्स ले जाते समय स्रोत थीम को बरकरार रखें**

यदि आप स्लाइड को किसी अन्य प्रस्तुति में ले जाना और उसका मूल डिज़ाइन बरकरार रखना चाहते हैं, तो [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterslidecollection/) द्वारा स्रोत मास्टर को लक्ष्य प्रस्तुति में क्लोन करें, फिर क्लोन किए गए मास्टर के साथ [ISlideCollection.addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecollection/) द्वारा स्लाइड को क्लोन करें। यह मास्टर, उसके लेआउट, और संबंधित थीम को साथ ले जाता है।

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

यह वही वर्कफ़्लो है जब स्रोत स्लाइड को गंतव्य में समान दिखना आवश्यक हो। अनिर्बंधित गंतव्य मास्टर पर केवल सामग्री क्लोन करने से थीम‑प्रेरित रंग, फ़ॉन्ट, पृष्ठभूमि, और प्रभाव बदल सकते हैं।

### **मौजूदा स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को उसके वर्तमान मास्टर और लेआउट पर रखकर रहना है, तो स्रोत थीम से स्लाइड‑स्तर ओवरराइड को प्रारंभ करें। [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hi/java/com.aspose.slides/overridetheme/), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hi/java/com.aspose.slides/overridetheme/), और [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hi/java/com.aspose.slides/overridetheme/) विधियाँ तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करती हैं।

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

यह अन्य स्लाइड्स द्वारा विरासत में मिली थीम को बदले बिना उस स्लाइड की थीम बदल देता है। स्थानीय ओवरराइड हटाकर विरासत मानों पर लौटने के लिए [OverrideTheme.clear](https://reference.aspose.com/slides/hi/java/com.aspose.slides/overridetheme/) को कॉल करें।

### **लेआउट पर थीम ओवरराइड लागू करें**

लेआउट‑स्तर ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट का उपयोग करती हैं, जब तक कि कोई विशेष स्लाइड अपना स्वयं का ओवरराइड न रखे। समान आरम्भीकरण विधियों को [LayoutSlideThemeManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/layoutslidethememanager/) के माध्यम से उपयोग किया जा सकता है:

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

जब कई लेआउट और स्लाइड्स को समान बेस डिज़ाइन साझा करना हो तो मास्टर या प्रस्तुति‑स्तर थीम उपयोग करें, जब केवल एक लेआउट परिवार को अलग शैली चाहिए तो लेआउट ओवरराइड, और केवल वास्तविक अपवादों के लिए स्लाइड ओवरराइड। अत्यधिक स्लाइड‑स्तर ओवरराइड बाद में वैश्विक थीम परिवर्तन को予測 करने में कठिन बनाते हैं।

## **थीम पृष्ठभूमि शैलियों को अपडेट करें**

थीम की पृष्ठभूमि भरावें [IFormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iformatscheme/) में संग्रहीत हैं। PowerPoint UI में अधिक पृष्ठभूमि विकल्प दिखा सकता है क्योंकि UI थीम भरावों को थीम रंगों और अन्य शैली संदर्भों के साथ संयोजित कर सकता है।

![प्रेज़ेंटेशन थीम के लिए PowerPoint पृष्ठभूमि शैली गैलरी](presentation-design_8.png)

पृष्ठभूमि शैली उपयोग करने से पहले, संग्रहीत संग्रह और वर्तमान [Background.getStyleIndex](https://reference.aspose.com/slides/hi/java/com.aspose.slides/background/) को जाँचें। `0` का शैली अंक मतलब कोई थीम भराव नहीं; सकारात्मक मान थीम पृष्ठभूमि‑शैली संदर्भ होते हैं। यह Java संग्रह को सीधे इंडेक्स करने से अलग है, जहाँ `get_Item(0)` पहला संग्रहीत आइटम दर्शाता है। यह न मानें कि हर प्रस्तुति में समान संख्या की पृष्ठभूमि भराव शैलियाँ हों।

निम्न उदाहरण उपलब्ध पृष्ठभूमि भराव गणना रिपोर्ट करती है, पहले मास्टर को थीम‑पृष्ठभूमि संदर्भ असाइन करती है, और प्रस्तुति सहेजती है:

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

दृश्य परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि और लेआउट या स्लाइड स्तर पर किसी भी पृष्ठभूमि ओवरराइड पर निर्भर करता है। यदि स्लाइड अपनी स्वयं की पृष्ठभूमि उपयोग करती है, तो केवल मास्टर पृष्ठभूमि बदलने से वह स्लाइड नहीं बदलेगी। विरासत लागू होने के बाद अंतिम पृष्ठभूमि जानने के लिए [Background.getEffective](https://reference.aspose.com/slides/hi/java/com.aspose.slides/background/) का उपयोग करें।

{{% alert color="warning" title="चेतावनी" %}}

शैली अंक को शून्य‑आधारित संग्रह अंक न मानें। साथ ही किसी एक फ़ाइल से शैली संख्या हार्ड‑कोड करके दूसरे फ़ाइल में समान रूप मानना टालें; थीम शैली परिभाषाएँ प्रस्तुति‑विशिष्ट होती हैं।

{{% /alert %}}

{{% alert color="info" title="सुझाव" %}}

सीधे पृष्ठभूमि स्वरूपण और पृष्ठभूमि विरासत के लिए देखें [Presentation Background](/slides/hi/java/presentation-background/)।

{{% /alert %}}

## **थीम प्रभाव अपडेट करें**

थीम फ़ॉर्मेट योजना अलग‑अलग भराव, रेखा, और प्रभाव शैली संग्रहों को [IFormatScheme.getFillStyles](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iformatscheme/), [IFormatScheme.getLineStyles](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iformatscheme/), और [IFormatScheme.getEffectStyles](https://reference.aspose.com/slides/hi/java/com.aspose.slides/iformatscheme/) के माध्यम से उजागर करती है। सामान्य Office थीम अक्सर तीन प्रमुख शैली प्रविष्टियों को शामिल करती हैं जो दृश्य रूप से सूक्ष्म, मध्यम, और तीव्र स्वरूपण से मेल खाते हैं, लेकिन कोड को प्रत्येक संग्रह को जाँचना चाहिए न कि स्थिर गिनती मानना चाहिए।

![समान आकृति पर लागू सूक्ष्म, मध्यम, और तीव्र थीम प्रभाव](presentation-design_10.png)

जब आप Java में इन संग्रहों तक पहुँचते हैं, तो संग्रह सूचकांक शून्य‑आधारित होता है: `get_Item(0)` पहला संग्रहीत शैली है और `get_Item(2)` तीसरा। आकृति के शैली‑संदर्भ संकेतक एक अलग अवधारणा है, जिसे [IShapeStyle](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishapestyle/) के द्वारा उजागर किया जाता है। थीम शैली में परिवर्तन उन आकृतियों को प्रभावित करता है जो उस थीम शैली को संदर्भित करती हैं; सीधे स्वरूपित आकृतियाँ अपरिवर्तित रह सकती हैं।

निम्न उदाहरण जाँचता है कि आवश्यक शैली प्रविष्टियाँ मौजूद हैं, पहली रेखा शैली बदलता है, तीसरी भराव शैली बदलता है, तीसरी प्रभाव शैली में बाहरी छाया सक्षम करता है, और परिणाम सहेजता है:

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

उन आकृतियों के लिए जो इन स्लॉट्स को संदर्भित करती हैं, पहली थीम रेखा शैली लाल हो जाती है, तीसरी थीम भराव शैली ठोस फ़ॉरेस्ट ग्रीन हो जाती है, और तीसरी प्रभाव शैली को 10 पॉइंट दूरी वाली बाहरी छाया मिलती है। सटीक दृश्य परिणाम अभी भी इस पर निर्भर करता है कि प्रत्येक आकृति कौन‑से शैली स्लॉट को संदर्भित करती है और क्या सीधे स्वरूपण थीम को ओवरराइड करता है।

![रेखा, भराव और छाया सेटिंग बदलने के बाद थीम प्रभाव शैलियाँ](presentation-design_11.png)

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम ऑब्जेक्ट बताते हैं कि किसी विशिष्ट स्तर पर क्या परिभाषित है। प्रभावी मान बताती हैं कि विरासत और स्थानीय ओवरराइड हल होने के बाद स्लाइड या आकृति वास्तव में क्या उपयोग करती है। स्लाइड के लिए [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseoverridethememanager/) को कॉल करें। पृष्ठभूमि के लिए [Background.getEffective](https://reference.aspose.com/slides/hi/java/com.aspose.slides/background/) और भराव के लिए [FillFormat.getEffective](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fillformat/) का उपयोग करें।

निम्न उदाहरण स्लाइड से प्रभावी थीम, पृष्ठभूमि, तथा पहली आकृति भराव पढ़ता है:

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

रेंडरिंग निदान, सत्यापन, और तुलना के लिए प्रभावी डेटा प्रयोग करें। यदि आप केवल [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) को देखेंगे, तो आप किसी मास्टर, लेआउट, स्लाइड, या आकृति ओवरराइड को चूक सकते हैं जो अंतिम रूप को बदलता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या बाहरी थीम लागू करने से प्रस्तुति की हर स्लाइड प्रभावित होती है?**

नहीं। [IMasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterslide/) केवल उन स्लाइड्स को पुनः असाइन करता है जो चयनित मास्टर पर निर्भर थीं। अन्य मास्टरों का उपयोग करने वाली स्लाइड्स अपने मौजूदा थीम बरकरार रखती हैं।

**क्या मैं मास्टर बदले बिना किसी एकल स्लाइड पर थीम लागू कर सकता हूँ?**

हां। स्लाइड की [SlideThemeManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slidethememanager/) का उपयोग कर उसकी ओवरराइड थीम को प्रारंभ करें। परिवर्तन केवल उस स्लाइड तक सीमित रहता है; अन्य स्लाइड्स अपने मौज़ूदा थीम को विरासत में लेती रहती हैं।

**एक प्रस्तुति से दूसरी प्रस्तुति में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

जब आप स्लाइड को ले जाकर उसकी स्रोत उपस्थिति बरकरार रखना चाहते हैं, तो स्रोत मास्टर को लक्ष्य में क्लोन करें और फिर उस मास्टर के साथ स्लाइड को [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterslidecollection/) और [ISlideCollection.addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecollection/) का उपयोग कर क्लोन करें। इससे मास्टर, लेआउट, और थीम एक साथ रहते हैं।

**विरासत और ओवरराइड के बाद प्रभावी मान कैसे देखें?**

स्लाइड या लेआउट थीम के लिए [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/java/com.aspose.slides/baseoverridethememanager/) तथा फ़ॉर्मेट ऑब्जेक्ट जैसे [Background.getEffective](https://reference.aspose.com/slides/hi/java/com.aspose.slides/background/) और [FillFormat.getEffective](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fillformat/) के संबंधित प्रभावी‑डेटा मेथड्स का प्रयोग करें। ये API विरासत और ओवरराइड लागू होने के बाद हल किए गए मान लौटाती हैं।