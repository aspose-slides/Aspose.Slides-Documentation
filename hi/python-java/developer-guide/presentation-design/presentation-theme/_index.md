---
title: Python के माध्यम से Java में प्रस्तुति थीम प्रबंधित करें
linktitle: प्रस्तुति थीम
type: docs
weight: 10
url: /hi/python-java/presentation-theme/
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
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides में Python के माध्यम से Java के लिए मुख्य प्रस्तुति थीम, जो स्थिर ब्रांडिंग के साथ PowerPoint फाइलें बनाने, अनुकूलित करने और रूपांतरित करने में मदद करती हैं।"
---
## **परिचय**

एक प्रस्तुति थीम रंगों, फ़ॉन्ट्स, पृष्ठभूमि शैलियों, भराव, रेखाओं और प्रभावों का समन्वित सेट परिभाषित करती है। थीम-जानकार ऑब्जेक्ट्स इन साझा परिभाषाओं को संदर्भित करते हैं बजाय प्रत्येक दृश्य गुण को स्थिर मान के रूप में संग्रहीत करने के, इसलिए थीम बदलने पर कई ऑब्जेक्ट्स एक साथ अपडेट हो सकते हैं।

Aspose.Slides में, प्रस्तुति‑स्तर की थीम को [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getMasterTheme) के माध्यम से एक्सेस किया जा सकता है। एक प्रस्तुति निम्न स्तरों पर भी थीम ओवरराइड रख सकती है। एक मास्टर थीम को [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterthememanager/#getOverrideTheme) के माध्यम से ओवरराइड कर सकता है, जबकि एक लेआउट या व्यक्तिगत स्लाइड अपने उत्तराधिकारित थीम को [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseoverridethememanager/#getOverrideTheme) के माध्यम से ओवरराइड कर सकता है। व्यवहार में, स्लाइड के लिए प्रभावी थीम इस वंशानुगत श्रृंखला के माध्यम से निर्धारित होती है: प्रस्तुति थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![थीम घटक: रंग, फ़ॉन्ट, पृष्ठभूमि शैलियाँ, और प्रभाव](theme-constituents.png)

निम्न अनुभाग सबसे सामान्य थीम वर्कफ़्लो दिखाते हैं: थीम निरीक्षण, रंग और फ़ॉन्ट बदलना, थीम कॉपी या लागू करना, पृष्ठभूमि और प्रभाव शैलियों को अपडेट करना, और वंशानुक्रम एवं ओवरराइड के बाद प्रभावी मान पढ़ना।

## **थीम निरीक्षण करें**

[MasterTheme](https://reference.aspose.com/slides/hi/python-java/aspose.slides/mastertheme/) वस्तु थीम की कलर स्कीम, फ़ॉन्ट स्कीम, और फ़ॉर्मेट स्कीम को क्रमशः [MasterTheme.getColorScheme](https://reference.aspose.com/slides/hi/python-java/aspose.slides/mastertheme/#getColorScheme), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/hi/python-java/aspose.slides/mastertheme/#getFontScheme), और [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/hi/python-java/aspose.slides/mastertheme/#getFormatScheme) के माध्यम से उजागर करती है। इन्हें बदलने से पहले इन संग्रहों का निरीक्षण करना विशेष रूप से उपयोगी होता है जब प्रस्तुति बाहरी स्रोत से आई हो क्योंकि शैली प्रविष्टियों की संख्या और सामग्री भिन्न हो सकती है।

निम्न उदाहरण मुख्य थीम गुणों को पढ़ता है और रिपोर्ट करता है कि थीम में कितनी पृष्ठभूमि, भराव, रेखा, और प्रभाव शैलियां संग्रहीत हैं:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("input.pptx")
try:
    theme = presentation.getMasterTheme()
    print("Theme name:", theme.getName())
    print("Accent 1:", theme.getColorScheme().getAccent1().getColor())
    print("Major Latin font:", theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Minor Latin font:", theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Background fill styles:", theme.getFormatScheme().getBackgroundFillStyles().size())
    print("Fill styles:", theme.getFormatScheme().getFillStyles().size())
    print("Line styles:", theme.getFormatScheme().getLineStyles().size())
    print("Effect styles:", theme.getFormatScheme().getEffectStyles().size())
finally:
    presentation.dispose()
```

यदि फ़ाइल कई मास्टर उपयोग करती है, तो यह न मानें कि प्रत्येक स्लाइड का वही प्रभावी थीम है। स्लाइड से जुड़े मास्टर का निरीक्षण करें, और लेआउट या स्लाइड ओवरराइड मौजूद होने पर बाद में दर्शाए गए प्रभावी‑थीम वर्कफ़्लो का उपयोग करें।

## **थीम रंग बदलें**

थीम‑जानकार भराव, रेखा, और टेक्स्ट [SchemeColor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/schemecolor/) enumeration से एक तर्कसंगत रंग का संदर्भ ले सकते हैं। जब आप [ColorScheme](https://reference.aspose.com/slides/hi/python-java/aspose.slides/colorscheme/) में संबंधित प्रविष्टि बदलते हैं, तो सभी ऑब्जेक्ट्स जो अभी भी उस थीम रंग को संदर्भित कर रहे हैं, नया मान ले लेते हैं। सीधे RGB रंग उपयोग करने वाले ऑब्जेक्ट्स थीम‑रंग अपडेट से नहीं बदलते।

निम्न संपूर्ण उदाहरण एक आकृति बनाता है जो `Accent4` का उपयोग करती है, थीम का `Accent4` रंग लाल में बदलता है, प्रस्तुति को सहेजता है, पुनः खोलता है, तथा प्रभावी भराव रंग प्रिंट करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, SchemeColor, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 100)
    shape.getFillFormat().setFillType(FillType.Solid)
    shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    presentation.getMasterTheme().getColorScheme().getAccent4().setColor(Color.RED)
    presentation.save("theme-color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()

saved_presentation = Presentation("theme-color.pptx")
try:
    saved_slide = saved_presentation.getSlides().get_Item(0)
    saved_shape = saved_slide.getShapes().get_Item(0)
    effective_fill = saved_shape.getFillFormat().getEffective()
    print("Effective fill color:", effective_fill.getSolidFillColor())
finally:
    saved_presentation.dispose()
```

क्योंकि आयत `Accent4` से लिंक रही है, थीम बदलने के बाद उसका दिखाई देने वाला रंग लाल हो जाता है। यदि आप आकार पर स्कीम रंग को सीधे रंग से बदलते हैं, तो बाद में `Accent4` में परिवर्तन उस भराव को प्रभावित नहीं करेगा।

### **अतिरिक्त पैलेट से रंग उपयोग करें**

PowerPoint थीम रंग से हल्के और गहरे संस्करण उत्पन्न करता है रंग परिवर्तन लागू करके। Aspose.Slides इन परिवर्तनों को [ColorTransformOperation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/colortransformoperation/) enumeration के माध्यम से उजागर करता है।

![मुख्य थीम रंग और अतिरिक्त पैलेट से उत्पन्न हल्के और गहरे रंग](additional-palette-colors.png)

**1** - मुख्य थीम रंग।

**2** - मुख्य थीम रंगों से उत्पन्न हल्के और गहरे संस्करण।

निम्न उदाहरण `Accent4` पर आधारित छह आयत बनाता है, उनमें से पाँच पर ल्यूमिनेंस परिवर्तन लागू करता है, और परिणाम सहेजता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ColorTransformOperation, FillType, Presentation, SaveFormat, SchemeColor, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    base_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 50, 50)
    base_shape.getFillFormat().setFillType(FillType.Solid)
    base_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)

    lightest_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 50, 50)
    lightest_shape.getFillFormat().setFillType(FillType.Solid)
    lightest_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.2)
    lightest_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.8)

    lighter_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 50, 50)
    lighter_shape.getFillFormat().setFillType(FillType.Solid)
    lighter_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.4)
    lighter_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.6)

    light_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 50, 50)
    light_shape.getFillFormat().setFillType(FillType.Solid)
    light_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.6)
    light_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.AddLuminance, 0.4)

    dark_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 250, 50, 50)
    dark_shape.getFillFormat().setFillType(FillType.Solid)
    dark_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    dark_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.75)

    darker_shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 50, 50)
    darker_shape.getFillFormat().setFillType(FillType.Solid)
    darker_shape.getFillFormat().getSolidFillColor().setSchemeColor(SchemeColor.Accent4)
    darker_shape.getFillFormat().getSolidFillColor().getColorTransform().add(ColorTransformOperation.MultiplyLuminance, 0.5)

    presentation.save("theme-color-palette.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

ये संस्करण अभी भी थीम रंग पर आधारित रहते हैं। यदि बाद में `Accent4` बदलता है, तो परिवर्तित रंग नए `Accent4` मान से पुनः गणना किए जाएंगे।

### **`SchemeColor` मानों को `ColorScheme` स्लॉट्स में मानचित्रित करें**

[SchemeColor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/schemecolor/) enumeration `Text1`, `Background1`, `Text2`, और `Background2` का उपयोग करता है, जबकि [ColorScheme](https://reference.aspose.com/slides/hi/python-java/aspose.slides/colorscheme/) समान थीम स्लॉट्स को `Dark1`, `Light1`, `Dark2`, और `Light2` के रूप में उजागर करता है। मानचित्रण स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ये समान थीम स्लॉट्स के वैकल्पिक नाम हैं; ये किसी रूपांतरण के द्वारा गतिशील रूप से नहीं बदले जाते।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट स्कीम में हेडिंग के लिए प्रमुख फ़ॉन्ट सेट और बॉडी टेक्स्ट के लिए गौण फ़ॉन्ट सेट होता है। [FontScheme.getMajor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontscheme/#getMajor) और [FontScheme.getMinor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontscheme/#getMinor) मेथड इन सेट को उजागर करते हैं।

PowerPoint‑अनुकूल थीम फ़ॉन्ट पहचानकर्ता टेक्स्ट फॉर्मेटिंग में उपयोग किए जा सकते हैं:

* `+mn-lt` - बॉडी फ़ॉन्ट लैटिन (Minor Latin Font)
* `+mj-lt` - हेडिंग फ़ॉन्ट लैटिन (Major Latin Font)
* `+mn-ea` - बॉडी फ़ॉन्ट ईस्ट एशियन (Minor East Asian Font)
* `+mj-ea` - हेडिंग फ़ॉन्ट ईस्ट एशियन (Major East Asian Font)

निम्न उदाहरण एक हेडिंग बनाता है जो प्रमुख लैटिन थीम फ़ॉन्ट का उपयोग करती है और एक बॉडी लाइन जो गौण लैटिन थीम फ़ॉन्ट का उपयोग करती है। फिर यह थीम फ़ॉन्ट बदलता है और परिणाम सहेजता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    heading = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 500, 60)
    heading.getTextFrame().setText("Theme heading")
    font_data = FontData("+mj-lt")
    heading.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    body = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 120, 500, 60)
    body.getTextFrame().setText("Theme body text")
    font_data = FontData("+mn-lt")
    body.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(font_data)

    font_data = FontData("Aptos Display")
    presentation.getMasterTheme().getFontScheme().getMajor().setLatinFont(font_data)
    font_data = FontData("Arial")
    presentation.getMasterTheme().getFontScheme().getMinor().setLatinFont(font_data)
    presentation.save("theme-fonts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

हेडिंग प्रमुख फ़ॉन्ट का पालन करती है और बॉडी टेक्स्ट गौण फ़ॉन्ट का। स्पष्ट फ़ॉन्ट नाम वाले टेक्स्ट में थीम पहचानकर्ता नहीं है, इसलिए थीम फ़ॉन्ट स्कीम बदलने पर वह स्वचालित रूप से नहीं बदलेगा।

मुख्य और गौण फ़ॉन्ट संग्रह में व्यक्तिगत लेखन प्रणालियों (जैसे Cyrillic, Arabic, Japanese, Georgian, Thaana) के लिए फ़ॉन्ट मैपिंग भी हो सकती है। इन मैपिंग को निरीक्षण, जोड़ने, बदलने या हटाने के लिए देखें [Script‑Specific Theme Fonts](/slides/hi/python-java/script-specific-font-mappings/)।

{{% alert color="success" title="टिप" %}}

प्रेज़ेंटेशन फ़ॉन्ट के बारे में अधिक जानकारी के लिए देखें [PowerPoint Fonts](/slides/hi/python-java/powerpoint-fonts/)।

{{% /alert %}}

## **थीम कॉपी या लागू करें**

नीचे के वर्कफ़्लो विभिन्न थीम‑संबंधी समस्याओं को हल करते हैं।

### **बाहरी थीम को मास्टर‑निर्भर स्लाइड्स पर लागू करें**

जब आपके पास PowerPoint थीम फ़ाइल (`.thmx`) हो और आप किसी विशेष मास्टर पर निर्भर सभी स्लाइड्स को पुनः शैली देना चाहते हों तो [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) का उपयोग करें। मास्टर को [Presentation.getMasters](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getMasters) संग्रह से चुनें, जो [MasterSlideCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslidecollection/) द्वारा प्रस्तुत है, और थीम फ़ाइल पथ को मेथड में पास करें।

मेथड निम्न कार्य करता है:

1. चयनित मास्टर पर आधारित नया मास्टर स्लाइड बनाता है।
1. बाहरी थीम को नए मास्टर पर लागू करता है।
1. नए मास्टर को सभी स्लाइड्स को असाइन करता है जो पहले चयनित मास्टर पर निर्भर थीं।
1. नया बनाया गया [MasterSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslide/) लौटाता है।

निम्न उदाहरण पहले मास्टर पर निर्भर स्लाइड्स पर बाहरी थीम लागू करता है और प्रस्तुति को सहेजता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    selected_master = presentation.getMasters().get_Item(0)
    themed_master = selected_master.applyExternalThemeToDependingSlides("corporate-theme.thmx")

    print("Created master:", themed_master.getName())
    presentation.save("presentation-with-external-theme.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

अमान्य, क्षतिग्रस्त, या असमर्थित थीम से [PptxReadException](https://reference.aspose.com/slides/hi/python-java/aspose.slides/pptxreadexception/) उत्पन्न हो सकता है। उपयोगकर्ता द्वारा प्रदान किए गए पथ को सत्यापित करें, फ़ाइल‑सिस्टम एक्सेस विफलताओं को संभालें, और केवल तब प्रस्तुति सहेजें जब थीम सफलतापूर्वक लागू हो गई हो।

केवल चयनित मास्टर पर निर्भर स्लाइड्स पुनः असाइन की जाती हैं। अन्य मास्टर से जुड़े स्लाइड्स अपने मौजूदा मास्टर और थीम को रखती हैं। थीम‑जानकार रंग, फ़ॉन्ट, भराव, रेखा, पृष्ठभूमि, और प्रभाव बाहरी थीम के विरुद्ध हल किए जाते हैं। सीधे असाइन किए गए रंग, फ़ॉन्ट, भराव और अन्य स्पष्ट फॉर्मेटिंग अपरिवर्तित रह सकती है। लेआउट‑स्तर और स्लाइड‑स्तर ओवरराइड भी नए मास्टर से विरासत में मिली मानों पर वर्चस्व रख सकते हैं।

थीम उन फ़ॉन्ट को संदर्भित कर सकती है जो रन‑टाइम वातावरण में उपलब्ध नहीं हैं। सुसंगत रेंडरिंग और निर्यात के लिए आवश्यक फ़ॉन्ट इंस्टॉल करें, उन्हें [custom font sources](/slides/hi/python-java/custom-font/) के माध्यम से उपलब्ध कराएँ, या [font substitution](/slides/hi/python-java/font-substitution/) कॉन्फ़िगर करें।

यह सीधे मास्टर‑स्तर का वर्कफ़्लो है: मेथड `.thmx` फ़ाइल पथ को स्वीकार करता है और स्लाइड‑स्तर या लेआउट‑स्तर थीम ओवरराइड को मैन्युअल रूप से बनाने की आवश्यकता नहीं होती।

### **बहु‑मास्टर प्रस्तुति में विभिन्न बाहरी थीम लागू करें**

जब उपयुक्त मास्टर पहले से ज्ञात न हो, तो इसे प्रतिनिधि स्लाइड से [Slide.getLayoutSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/#getLayoutSlide) और [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutslide/#getMasterSlide) के माध्यम से प्राप्त करें। थीम लागू करने से पहले मूल मास्टर संदर्भों को सहेजें क्योंकि प्रत्येक कॉल प्रस्तुति में एक नया मास्टर बनाता है।

निम्न उदाहरण दो अनुभागों की स्लाइड्स से उनके मास्टर खोजता है और प्रत्येक समूह पर अलग बाहरी थीम लागू करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("multi-master-presentation.pptx")
try:
    if presentation.getSlides().size() < 5:
        print("The presentation does not contain the expected representative slides.")
    else:
        first_group_master = presentation.getSlides().get_Item(0).getLayoutSlide().getMasterSlide()
        second_group_master = presentation.getSlides().get_Item(4).getLayoutSlide().getMasterSlide()

        if first_group_master.getSlideId() == second_group_master.getSlideId():
            print("The representative slides use the same master.")
        else:
            first_themed_master = first_group_master.applyExternalThemeToDependingSlides("blue-theme.thmx")
            second_themed_master = second_group_master.applyExternalThemeToDependingSlides("green-theme.thmx")

            print("First themed master:", first_themed_master.getName())
            print("Second themed master:", second_themed_master.getName())
            presentation.save("multi-master-with-external-themes.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

पहला कॉल केवल `first_group_master` पर निर्भर स्लाइड्स को प्रभावित करता है, और दूसरा कॉल केवल `second_group_master` पर निर्भर स्लाइड्स को। अन्य किसी भी मास्टर से जुड़ी स्लाइड्स का स्वरूप नहीं बदलेगा।

### **स्लाइड्स को स्थानांतरित करते समय स्रोत थीम को बनाए रखें**

यदि आप स्लाइड को किसी अन्य प्रस्तुति में स्थानांतरित करना चाहते हैं और उसके मूल डिज़ाइन को बनाए रखना चाहते हैं, तो स्रोत मास्टर को लक्ष्य प्रस्तुति में [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslidecollection/#addClone) के साथ क्लोन करें, फिर क्लोन किया गया मास्टर के साथ [SlideCollection.addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#addClone) का उपयोग करके स्लाइड को क्लोन करें। इससे मास्टर, उसके लेआउट, और संबंधित थीम साथ लेकर चलते हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        source_slide = source.getSlides().get_Item(0)
        source_master = source_slide.getLayoutSlide().getMasterSlide()
        cloned_master = target.getMasters().addClone(source_master)
        target.getSlides().addClone(source_slide, cloned_master, True)
        target.save("theme-preserved.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

जब स्रोत स्लाइड को गंतव्य में समान दिखना आवश्यक हो, तो यह वर्कफ़्लो पसंदीदा है। बिना संबंधित गंतव्य मास्टर पर केवल कंटेंट को क्लोन करने से थीम‑चलित रंग, फ़ॉन्ट, पृष्ठभूमि और प्रभाव बदल सकते हैं।

### **मौजूदा स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को अपने वर्तमान मास्टर और लेआउट पर रखना है, तो स्रोत थीम से स्लाइड‑स्तर ओवरराइड को इनिशियलाइज़ करें। [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/hi/python-java/aspose.slides/overridetheme/#initColorSchemeFrom), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/hi/python-java/aspose.slides/overridetheme/#initFontSchemeFrom), और [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/hi/python-java/aspose.slides/overridetheme/#initFormatSchemeFrom) मेथड तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करते हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)
        override_theme = target_slide.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())
        target.save("theme-applied-to-slide.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

यह अन्य स्लाइड्स द्वारा विरासत में प्राप्त थीम को बदले बिना उस स्लाइड द्वारा उपयोग की गई थीम को बदलता है। स्थानीय ओवरराइड हटाने और विरासतित मानों पर लौटने के लिए [OverrideTheme.clear](https://reference.aspose.com/slides/hi/python-java/aspose.slides/overridetheme/#clear) को कॉल करें।

### **लेआउट पर थीम ओवरराइड लागू करें**

एक लेआउट‑स्तर ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट का उपयोग करती हैं, जब तक कि कोई विशेष स्लाइड अपना स्वयं का ओवरराइड न रखती हो। वही इनिशियलाइज़ेशन मेथड [LayoutSlideThemeManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/layoutslidethememanager/) के माध्यम से उपयोग किए जा सकते हैं:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

source = Presentation("source-theme.pptx")
try:
    target = Presentation("target.pptx")
    try:
        target_slide = target.getSlides().get_Item(0)
        target_layout = target_slide.getLayoutSlide()
        override_theme = target_layout.getThemeManager().getOverrideTheme()
        override_theme.initColorSchemeFrom(source.getMasterTheme().getColorScheme())
        override_theme.initFontSchemeFrom(source.getMasterTheme().getFontScheme())
        override_theme.initFormatSchemeFrom(source.getMasterTheme().getFormatScheme())
        target.save("theme-applied-to-layout.pptx", SaveFormat.Pptx)
    finally:
        target.dispose()
finally:
    source.dispose()
```

जब कई लेआउट और स्लाइड्स को समान बेस डिज़ाइन साझा करना हो तो मास्टर या प्रस्तुति‑स्तर थीम उपयोग करें, जब एक लेआउट परिवार को अलग शैलियों की आवश्यकता हो तो लेआउट ओवरराइड, और केवल वास्तविक अपवादों के लिए स्लाइड ओवरराइड। अत्यधिक स्लाइड‑स्तर ओवरराइड बाद में वैश्विक थीम बदलावों को पूर्वानुमानित करना मुश्किल बना देते हैं।

## **थीम पृष्ठभूमि शैलियों को अपडेट करें**

थीम की पृष्ठभूमि भरावें [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/hi/python-java/aspose.slides/formatscheme/#getBackgroundFillStyles) में संग्रहीत होती हैं। PowerPoint UI में पृष्ठभूमि विकल्पों की संख्या इस संग्रह में भौतिक रूप से संग्रहीत भराव परिभाषाओं से अधिक हो सकती है क्योंकि UI थीम भराव को थीम रंग और अन्य शैली संदर्भों के साथ जोड़ सकता है।

![प्रेज़ेंटेशन थीम के लिए PowerPoint पृष्ठभूमि शैली गैलरी](presentation-design_8.png)

पृष्ठभूमि शैली उपयोग करने से पहले संग्रह और वर्तमान [Background.getStyleIndex](https://reference.aspose.com/slides/hi/python-java/aspose.slides/background/#getStyleIndex) का निरीक्षण करें। `0` का शैली इंडेक्स मतलब कोई थीम्ड भराव नहीं; सकारात्मक मान थीम पृष्ठभूमि‑शैली संदर्भ होते हैं। यह सीधे संग्रह को इंडेक्स करने से अलग है, जहाँ `get_Item(0)` पहला संग्रहीत आइटम दर्शाता है। यह न मानें कि प्रत्येक प्रस्तुति में समान संख्या में पृष्ठभूमि भराव शैलियां होंगी।

निम्न उदाहरण उपलब्ध पृष्ठभूमि भराव गिनती रिपोर्ट करता है, पहले मास्टर को थीम्ड पृष्ठभूमि संदर्भ असाइन करता है, और प्रस्तुति को सहेजता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    background_styles = presentation.getMasterTheme().getFormatScheme().getBackgroundFillStyles()
    print("Background fill styles:", background_styles.size())
    if background_styles.size() == 0:
        print("The presentation theme does not contain background fill styles.")
    else:
        master_slide = presentation.getMasters().get_Item(0)
        master_slide.getBackground().setType(BackgroundType.Themed)
        master_slide.getBackground().setStyleIndex(1)
        presentation.save("theme-background.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

दृश्यमान परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि और लेआउट या स्लाइड स्तर पर किसी भी पृष्ठभूमि ओवरराइड पर निर्भर करता है। यदि स्लाइड अपनी स्वयं की पृष्ठभूमि उपयोग करती है, तो केवल मास्टर पृष्ठभूमि बदलने से वह स्लाइड नहीं बदलेगी। अंतिम पृष्ठभूमि जानने के लिए विरासत लागू होने के बाद [Background.getEffective](https://reference.aspose.com/slides/hi/python-java/aspose.slides/background/#getEffective) का उपयोग करें।

{{% alert color="warning" title="चेतावनी" %}}

शैली इंडेक्स को शून्य‑आधारित संग्रह इंडेक्स के रूप में न देखें। किसी फ़ाइल से शैली संख्या को हार्ड‑कोड करने और इसे दूसरी फ़ाइल में समान उपस्थिति मानने से बचें; थीम शैली परिभाषाएं प्रस्तुति‑विशिष्ट होती हैं।

{{% /alert %}}

{{% alert color="success" title="टिप" %}}

सीधे पृष्ठभूमि फॉर्मेटिंग और पृष्ठभूमि विरासत के लिए देखें [Presentation Background](/slides/hi/python-java/presentation-background/)।

{{% /alert %}}

## **थीम प्रभाव अपडेट करें**

एक थीम फ़ॉर्मेट स्कीम में अलग‑अलग भराव, रेखा, और प्रभाव शैली संग्रह होते हैं जो क्रमशः [FormatScheme.getFillStyles](https://reference.aspose.com/slides/hi/python-java/aspose.slides/formatscheme/#getFillStyles), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/hi/python-java/aspose.slides/formatscheme/#getLineStyles), और [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/hi/python-java/aspose.slides/formatscheme/#getEffectStyles) द्वारा उजागर होते हैं। सामान्य Office थीम में अक्सर तीन मुख्य शैली प्रविष्टियां होती हैं जो क्रमशः Subtle, Moderate, और Intense फ़ॉर्मेटिंग से मेल खाती हैं, लेकिन कोड को प्रत्येक संग्रह का निरीक्षण करना चाहिए न कि स्थिर गिनती मानना चाहिए।

![एक ही आकृति पर Subtle, Moderate, और Intense थीम प्रभाव लागू करना](presentation-design_10.png)

जब आप इन संग्रहों को Python via Java में एक्सेस करते हैं, तो संग्रह इंडेक्स शून्य‑आधारित होता है: `get_Item(0)` पहला संग्रहीत शैली है और `get_Item(2)` तीसरा। आकृति का शैली‑संदर्भ इंडेक्स एक अलग अवधारणा है, जो [ShapeStyle](https://reference.aspose.com/slides/hi/python-java/aspose.slides/shapestyle/) द्वारा उजागर होती है। थीम शैली को बदलने से उन आकृतियों पर प्रभाव पड़ता है जो उस थीम शैली का संदर्भ लेती हैं; सीधे फॉर्मेट की गई आकृतियां अपरिवर्तित रह सकती हैं।

निम्न उदाहरण जांचता है कि आवश्यक शैली प्रविष्टियां मौजूद हैं, पहली रेखा शैली बदलता है, तीसरी भराव शैली बदलता है, तीसरी प्रभाव शैली में बाहरी छाया सक्षम करता है, और परिणाम सहेजता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("Subtle_Moderate_Intense.pptx")
try:
    format_scheme = presentation.getMasterTheme().getFormatScheme()
    if format_scheme.getLineStyles().size() < 1 or format_scheme.getFillStyles().size() < 3 or format_scheme.getEffectStyles().size() < 3:
        print("The theme does not contain the style entries required by this example.")
    else:
        format_scheme.getLineStyles().get_Item(0).getFillFormat().setFillType(FillType.Solid)
        format_scheme.getLineStyles().get_Item(0).getFillFormat().getSolidFillColor().setColor(Color.RED)
        format_scheme.getFillStyles().get_Item(2).setFillType(FillType.Solid)
        forest_green = Color(34, 139, 34)
        format_scheme.getFillStyles().get_Item(2).getSolidFillColor().setColor(forest_green)
        effect_format = format_scheme.getEffectStyles().get_Item(2).getEffectFormat()
        effect_format.enableOuterShadowEffect()
        effect_format.getOuterShadowEffect().setDistance(10)
        presentation.save("theme-effects.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

इन स्लॉट्स को संदर्भित करने वाली आकृतियों के लिए, पहली थीम रेखा शैली लाल हो जाती है, तीसरी थीम भराव शैली सॉलिड फ़ॉरेस्ट ग्रीन हो जाती है, और तीसरी प्रभाव शैली में 10 पॉइंट दूरी के साथ बाहरी छाया जुड़ जाती है। सटीक दृश्य परिणाम अभी भी इस पर निर्भर करता है कि प्रत्येक आकृति कौन से शैली स्लॉट को संदर्भित करती है और क्या सीधे फॉर्मेटिंग थीम को ओवरराइड करती है।

![लाइन, भराव, और छाया सेटिंग बदलने के बाद थीम प्रभाव शैलियां](presentation-design_11.png)

## **निर्धारित करें कि क्या प्रभावी सॉलिड भराव थीम रंग उपयोग करता है**

एक भराव ऑब्जेक्ट पर सीधे संग्रहीत या पैराग्राफ, लेआउट, मास्टर, थीम शैली, या अन्य फॉर्मेट स्तर से विरासत में मिल सकता है। उस पदानुक्रम को अपरिवर्तनीय प्रभावी भराव डेटा में हल करने के लिए [FillFormat.getEffective](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fillformat/#getEffective) कॉल करें। पहले प्रभावी डेटा ऑब्जेक्ट पर `getFillType` देखें। केवल जब यह `FillType.Solid` हो, तब ही सॉलिड‑भराव गुण पढ़ें।

सॉलिड भराव के लिए, `getSolidFillColor` विरासत, थीम लुकअप, और रंग परिवर्तन लागू होने के बाद अंतिम रेंडर किया गया RGB मान लौटाता है। `getSolidFillSchemeColor` संबंधित तर्कसंगत [SchemeColor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/schemecolor/) स्लॉट लौटाता है, जैसे `Text1` या `Accent6`। `SchemeColor.NotDefined` का मान दर्शाता है कि प्रभावी सॉलिड भराव कोई स्कीम रंग नहीं है। थीम रंग या सीधे RGB रंग वाले वर्कफ़्लो में यह मान सीधे RGB भराव की पहचान करता है।

स्थानीय [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/colorformat/#getSchemeColor) मान से भराव वर्गीकृत न करें। उदाहरण के लिए, टेक्स्ट हिस्से का स्थानीय स्कीम रंग परिभाषित नहीं हो सकता, इसलिए उसका स्थानीय मान `NotDefined` हो सकता है, जबकि उसका प्रभावी भराव थीम रंग विरासत में लेकर `Text1` या `Accent6` में हल हो सकता है। दूसरी ओर, `getSolidFillSchemeColor` बताता है कि कौन सा तर्कसंगत थीम स्लॉट प्रभावी रंग उत्पन्न करता है, पर यह नहीं बताता कि वह स्लॉट ऑब्जेक्ट, पैराग्राफ, लेआउट, मास्टर या किसी अन्य स्तर से आया है।

निम्न उदाहरण एक प्रस्तुति लोड करता है, दोनों आकृति भराव और टेक्स्ट‑हिस्सा भराव का ऑडिट करता है, प्रत्येक अंतिम RGB मान और संबद्ध स्कीम रंग प्रिंट करता है, और उन सॉलिड भरावों को चिन्हित करता है जो थीम रंग परिवर्तन को ट्रैक नहीं करेंगे:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, FillType, Presentation, SchemeColor

def audit_fill(object_name, local_fill):
    effective_fill = local_fill.getEffective()
    if effective_fill.getFillType() != FillType.Solid:
        print(f"{object_name}: fill type = {effective_fill.getFillType()}; not a solid fill.")
        return

    rgb = effective_fill.getSolidFillColor()
    effective_scheme_color = effective_fill.getSolidFillSchemeColor()
    local_scheme_color = local_fill.getSolidFillColor().getSchemeColor()
    print(f"{object_name}: RGB = #{rgb.getRed():02X}{rgb.getGreen():02X}{rgb.getBlue():02X}")
    print(f"{object_name}: local scheme = {local_scheme_color}, effective scheme = {effective_scheme_color}")
    if effective_scheme_color == SchemeColor.NotDefined:
        print(f"{object_name}: direct RGB or another non-scheme fill; audit as theme-independent.")
    else:
        print(f"{object_name}: theme-dependent through {effective_scheme_color}.")


presentation = Presentation("input.pptx")
try:
    for slide_index, slide in enumerate(presentation.getSlides()):
        for shape_index, shape in enumerate(slide.getShapes()):
            shape_name = f"Slide {slide_index + 1}, shape {shape_index + 1}"
            audit_fill(shape_name, shape.getFillFormat())
            if isinstance(shape, AutoShape):
                for paragraph_index, paragraph in enumerate(shape.getTextFrame().getParagraphs()):
                    for portion_index, portion in enumerate(paragraph.getPortions()):
                        portion_name = f"{shape_name}, paragraph {paragraph_index + 1}, portion {portion_index + 1}"
                        audit_fill(portion_name, portion.getPortionFormat().getFillFormat())
finally:
    presentation.dispose()
```

`NotDefined` शाखा उन सॉलिड भरावों की ऑडिट सूची देती है जो थीम रंग स्लॉट में परिवर्तन के प्रति प्रतिक्रिया नहीं देंगे। जब प्रस्तुति को नए ब्रांड पैलेट का पालन करना हो, तो उन ऑब्जेक्ट्स की समीक्षा करें। रिपोर्ट किया गया RGB मान अभी भी वर्तमान रूप दिखाता है, जबकि स्कीम मान बताता है कि वह रूप थीम से जुड़ा है या नहीं।

प्रभावी‑फ़ॉर्मेट ऑब्जेक्ट स्नैपशॉट होते हैं। प्रस्तुति थीम, थीम ओवरराइड, या कोई भी विरासतित फॉर्मेट बदलने के बाद, `getEffective` फिर से कॉल करें और नई प्रभावी भराव डेटा ऑब्जेक्ट पढ़ें, फिर तुलना या रिपोर्ट करें।

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम ऑब्जेक्ट आपको बताते हैं कि किसी विशेष स्तर पर क्या परिभाषित है। प्रभावी मान बताते हैं कि स्लाइड या आकृति वास्तव में विरासत और स्थानीय ओवरराइड के बाद क्या उपयोग करती है। स्लाइड के लिए, [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) कॉल करें। पृष्ठभूमि के लिए, [Background.getEffective](https://reference.aspose.com/slides/hi/python-java/aspose.slides/background/#getEffective) उपयोग करें, और भराव के लिए, [FillFormat.getEffective](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fillformat/#getEffective)।

निम्न उदाहरण एक स्लाइड से प्रभावी थीम, पृष्ठभूमि, और पहली आकृति भराव पढ़ता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation

presentation = Presentation("input.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    effective_theme = slide.getThemeManager().createThemeEffective()
    effective_background = slide.getBackground().getEffective()
    print("Effective major Latin font:", effective_theme.getFontScheme().getMajor().getLatinFont().getFontName())
    print("Effective minor Latin font:", effective_theme.getFontScheme().getMinor().getLatinFont().getFontName())
    print("Effective background fill type:", effective_background.getFillFormat().getFillType())
    if slide.getShapes().size() > 0:
        effective_fill = slide.getShapes().get_Item(0).getFillFormat().getEffective()
        print("First shape effective fill type:", effective_fill.getFillType())
        if effective_fill.getFillType() == FillType.Solid:
            print("First shape effective fill color:", effective_fill.getSolidFillColor())
finally:
    presentation.dispose()
```

रेंडरिंग डायग्नॉस्टिक्स, वैधता, और तुलना के लिए प्रभावी डेटा का उपयोग करें। यदि आप केवल [Presentation.getMasterTheme](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getMasterTheme) का निरीक्षण करते हैं, तो आप किसी मास्टर, लेआउट, स्लाइड, या आकार ओवरराइड को चूक सकते हैं जो अंतिम रूप को बदलता है।

## **FAQ**

**क्या बाहरी थीम लागू करने से प्रस्तुति की हर स्लाइड प्रभावित होती है?**

नहीं। [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) केवल उन स्लाइड्स को पुनः असाइन करता है जो चयनित मास्टर पर निर्भर थीं। अन्य मास्टर उपयोग करने वाली स्लाइड्स अपने मौजूदा थीम को बनाए रखती हैं।

**क्या मैं मास्टर बदले बिना एकल स्लाइड पर थीम लागू कर सकता हूँ?**

हाँ। स्लाइड के [SlideThemeManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidethememanager/) का उपयोग करें और उसके ओवरराइड थीम को इनिशियलाइज़ करें। परिवर्तन केवल उस स्लाइड तक सीमित रहता है; अन्य स्लाइड्स अपने मौजूदा थीम को विरासत में लेती रहेंगी।

**एक प्रस्तुति से दूसरी में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

जब स्लाइड को स्थानांतरित करते हैं और उसके स्रोत रूप को बनाए रखना चाहते हैं, तो स्रोत मास्टर को गंतव्य में क्लोन करें और फिर उस मास्टर के साथ स्लाइड को [MasterSlideCollection.addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masterslidecollection/#addClone) और [SlideCollection.addClone](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/#addClone) के जरिए क्लोन करें। यह मास्टर, लेआउट, और थीम को साथ रखता है।

**मैं विरासत और ओवरराइड के बाद प्रभावी मान कैसे देख सकता हूँ?**

स्लाइड या लेआउट थीम के लिए [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) और फ़ॉर्मेट ऑब्जेक्ट्स के लिए संबंधित प्रभावी‑डेटा मेथड जैसे [Background.getEffective](https://reference.aspose.com/slides/hi/python-java/aspose.slides/background/#getEffective) और [FillFormat.getEffective](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fillformat/#getEffective) का प्रयोग करें। ये API वंशानुक्रम और ओवरराइड लागू होने के बाद हल किए गए मान लौटाते हैं।