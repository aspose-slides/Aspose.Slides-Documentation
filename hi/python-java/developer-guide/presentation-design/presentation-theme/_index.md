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
description: "Aspose.Slides के लिए Python के माध्यम से Java में मुख्य प्रस्तुति थीम को नियंत्रित करके, PowerPoint फ़ाइलों को निरंतर ब्रांडिंग के साथ बनाएं, अनुकूलित करें और रूपांतरित करें।"
---
## **परिचय**

एक प्रस्तुति थीम रंगों, फ़ॉन्ट्स, पृष्ठभूमि शैलियों, भराव, रेखाएँ और प्रभावों का समन्वित सेट परिभाषित करती है। थीम‑ज्ञात ऑब्जेक्ट्स इन साझा परिभाषाओं को संदर्भित करते हैं न कि प्रत्येक दृश्य गुण को स्थिर मान के रूप में संग्रहीत करते हैं, इसलिए थीम परिवर्तन कई ऑब्जेक्ट्स को एक साथ अपडेट कर सकता है।

Aspose.Slides में, प्रस्तुति‑स्तर की थीम को [Presentation.getMasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasterTheme) के माध्यम से उपलब्ध कराया जाता है। एक प्रस्तुति में निचले स्तरों पर भी थीम ओवरराइड हो सकते हैं। एक मास्टर प्रस्तुति थीम को [MasterThemeManager.getOverrideTheme](https://reference.aspose.com/slides/python-java/aspose.slides/masterthememanager/#getOverrideTheme) के माध्यम से ओवरराइड कर सकता है, जबकि एक लेआउट या व्यक्तिगत स्लाइड अपने वारिस थीम को [BaseOverrideThemeManager.getOverrideTheme](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#getOverrideTheme) के माध्यम से ओवरराइड कर सकती है। व्यवहार में, स्लाइड के लिए प्रभावी थीम इस विरासत श्रृंखला के माध्यम से निर्धारित होती है: प्रस्तुति थीम, मास्टर ओवरराइड, लेआउट ओवरराइड, और स्लाइड ओवरराइड।

![थीम घटक: रंग, फ़ॉन्ट, पृष्ठभूमि शैलियाँ, और प्रभाव](theme-constituents.png)

नीचे के अनुभाग सबसे सामान्य थीम कार्यप्रवाह दिखाते हैं: थीम का निरीक्षण, रंग और फ़ॉन्ट बदलना, थीम को कॉपी या लागू करना, पृष्ठभूमि और प्रभाव शैलियों को अपडेट करना, और विरासत व ओवरराइड के लागू होने के बाद प्रभावी मानों को पढ़ना।

## **थीम का निरीक्षण**

[MasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/) ऑब्जेक्ट थीम की कलर स्कीम, फ़ॉन्ट स्कीम और फ़ॉर्मेट स्कीम को क्रमशः [MasterTheme.getColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getColorScheme), [MasterTheme.getFontScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getFontScheme) और [MasterTheme.getFormatScheme](https://reference.aspose.com/slides/python-java/aspose.slides/mastertheme/#getFormatScheme) के माध्यम से उजागर करता है। इन्हें बदलने से पहले इन संग्रहों का निरीक्षण करना विशेष रूप से उपयोगी होता है जब प्रस्तुति बाहरी स्रोत से आती है, क्योंकि शैली प्रविष्टियों की संख्या और सामग्री भिन्न हो सकती है।

निम्नलिखित उदाहरण मुख्य थीम गुणों को पढ़ता है और रिपोर्ट करता है कि थीम में कितनी पृष्ठभूमि, भराव, रेखा और प्रभाव शैलियाँ संग्रहीत हैं:

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

यदि कोई फ़ाइल कई मास्टर उपयोग करती है, तो यह मानना उचित नहीं है कि प्रत्येक स्लाइड का प्रभावी थीम समान है। स्लाइड से जुड़े मास्टर का निरीक्षण करें, और जब लेआउट या स्लाइड ओवरराइड मौजूद हो सकते हैं तो इस लेख में बाद में दिखाए गए प्रभावी‑थीम कार्यप्रवाह का उपयोग करें।

## **थीम रंग बदलें**

थीम‑ज्ञात भराव, रेखाएँ और टेक्स्ट [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/) enumeration से एक तार्किक रंग का संदर्भ ले सकते हैं। जब आप [ColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/colorscheme/) में संबंधित प्रविष्टि बदलते हैं, तो सभी ऑब्जेक्ट्स जो अभी भी उस थीम रंग को संदर्भित करते हैं, नए मान के अनुसार हल हो जाते हैं। सीधे RGB रंग का उपयोग करने वाले ऑब्जेक्ट्स थीम‑रंग अपडेट से प्रभावित नहीं होते।

निम्न अंत‑से‑अंत उदाहरण एक ऐसा शैप बनाता है जो `Accent4` का उपयोग करता है, थीम के `Accent4` रंग को लाल में बदलता है, प्रस्तुति को सहेजता है, पुनः खोलता है, और प्रभावी भराव रंग को प्रिंट करता है:

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

क्योंकि आयत `Accent4` से जुड़ी रहती है, थीम बदलने के बाद उसका दिखाई देने वाला रंग लाल हो जाता है। यदि आप शैप पर स्कीम रंग को सीधे रंग से बदलते हैं, तो बाद में `Accent4` में परिवर्तन उस भराव को प्रभावित नहीं करेंगे।

### **अतिरिक्त पैलेट से रंगों का उपयोग करें**

PowerPoint एक थीम रंग से हल्के और गहरे विविधताएँ उत्पन्न करता है जो रंग रूपांतरण लागू करके बनाई जाती हैं। Aspose.Slides इन रूपांतरणों को [ColorTransformOperation](https://reference.aspose.com/slides/python-java/aspose.slides/colortransformoperation/) enumeration के माध्यम से उजागर करता है।

![मुख्य थीम रंग और अतिरिक्त पैलेट से उत्पन्न हल्के और गहरे रंग](additional-palette-colors.png)

**1** - मुख्य थीम रंग।

**2** - मुख्य थीम रंगों से उत्पन्न हल्के और गहरे विविधताएँ।

निम्न उदाहरण `Accent4` पर आधारित छह आयतें बनाता है, पाँच पर ल्यूमिनेंस रूपांतरण लागू करता है, और परिणाम को सहेजता है:

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

ये विविधताएँ थीम रंग पर आधारित रहती हैं। यदि बाद में `Accent4` बदलता है, तो रूपांतरित रंग नए `Accent4` मान से पुनः गणना किए जाते हैं।

### **`SchemeColor` मानों को `ColorScheme` स्लॉट्स से मैप करें**

[SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/) enumeration `Text1`, `Background1`, `Text2` और `Background2` का उपयोग करता है, जबकि [ColorScheme](https://reference.aspose.com/slides/python-java/aspose.slides/colorscheme/) समान थीम स्लॉट्स को `Dark1`, `Light1`, `Dark2` और `Light2` के रूप में उजागर करता है। मैपिंग स्थिर है:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

ये समान थीम स्लॉट्स के वैकल्पिक नाम हैं; ये ऐसे मान नहीं हैं जो एक रूप से दूसरे रूप में गतिशील रूप से परिवर्तित होते हैं।

## **थीम फ़ॉन्ट बदलें**

एक थीम फ़ॉन्ट स्कीम में हैडिंग्स के लिए एक प्रमुख फ़ॉन्ट सेट और बॉडी टेक्स्ट के लिए एक गौण फ़ॉन्ट सेट होता है। [FontScheme.getMajor](https://reference.aspose.com/slides/python-java/aspose.slides/fontscheme/#getMajor) और [FontScheme.getMinor](https://reference.aspose.com/slides/python-java/aspose.slides/fontscheme/#getMinor) मेथड्स इन सेटों को उजागर करते हैं।

PowerPoint‑अनुरूप थीम फ़ॉन्ट पहचानकर्ता टेक्स्ट फ़ॉर्मेटिंग में उपयोग किए जा सकते हैं:

* `+mn-lt` - बॉडी फ़ॉन्ट लैटिन (माइनर लैटिन फ़ॉन्ट)
* `+mj-lt` - हेड़िंग फ़ॉन्ट लैटिन (मेजर लैटिन फ़ॉन्ट)
* `+mn-ea` - बॉडी फ़ॉन्ट ईस्ट एशियन (माइनर ईस्ट एशियन फ़ॉन्ट)
* `+mj-ea` - हेड़िंग फ़ॉन्ट ईस्ट एशियन (मेजर ईस्ट एशियन फ़ॉन्ट)
* `+mn-cs` - बॉडी फ़ॉन्ट कॉम्प्लेक्स स्क्रिप्ट (माइनर कॉम्प्लेक्स स्क्रिप्ट फ़ॉन्ट)
* `+mj-cs` - हेड़िंग फ़ॉन्ट कॉम्प्लेक्स स्क्रिप्ट (मेजर कॉम्प्लेक्स स्क्रिप्ट फ़ॉन्ट)

निम्न उदाहरण एक हेड़िंग बनाता है जो प्रमुख लैटिन थीम फ़ॉन्ट का उपयोग करता है और एक बॉडी लाइन बनाता है जो गौण लैटिन थीम फ़ॉन्ट का उपयोग करती है। फिर यह थीम फ़ॉन्ट को बदलता है और परिणाम सहेजता है:

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

हेड़िंग प्रमुख फ़ॉन्ट का अनुसरण करती है और बॉडी टेक्स्ट गौण फ़ॉन्ट का। यदि टेक्स्ट में स्पष्ट फ़ॉन्ट नाम थीम पहचानकर्ता के बजाय हो, तो थीम फ़ॉन्ट स्कीम बदलने पर वह स्वतः नहीं बदलेगा।

प्रमुख और गौण फ़ॉन्ट संग्रह में व्यक्तिगत लेखन प्रणालियों जैसे सिरिलिक, अरबी, जापानी, जॉर्जियन और थाना के लिए फ़ॉन्ट मैपिंग भी हो सकती है। इन मैपिंग को निरीक्षण, जोड़, बदल या हटाने के लिए देखें: [Script-Specific Theme Fonts](/slides/hi/python-java/script-specific-font-mappings/).

{{% alert color="success" title="Tip" %}}
For more information about presentation fonts, see [PowerPoint Fonts](/slides/hi/python-java/powerpoint-fonts/).
{{% /alert %}}

### **थीम फ़ॉन्ट संदर्भों को हल करें**

टेक्स्ट का निरीक्षण करते समय, [FontData.getFontName](https://reference.aspose.com/slides/python-java/aspose.slides/fontdata/#getFontName) थीम संदर्भ जैसे `+mn-lt` लौटा सकता है बजाय फ़ॉन्ट परिवार नाम के। उपयुक्त प्रभावी थीम डेटा के साथ [FontData.getFontName](https://reference.aspose.com/slides/python-java/aspose.slides/fontdata/#getFontName) को कॉल करें ताकि वह संदर्भ हल हो सके। `+mj` और `+mn` उपसर्ग क्रमशः प्रमुख और गौण फ़ॉन्ट सेट को चुनते हैं; `-lt`, `-ea` और `-cs` प्रत्यय उनके लैटिन, ईस्ट एशियन और कॉम्प्लेक्स स्क्रिप्ट फ़ॉन्ट को निर्धारित करते हैं।

ऑब्जेक्ट की थीम जिस पर लागू होती है, उसके थीम मैनेजर पर [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) का प्रयोग करके प्रभावी थीम प्राप्त करें। स्लाइड पर सामान्य टेक्स्ट के लिए, स्लाइड के थीम मैनेजर का उपयोग करें ताकि संदर्भ में उस स्लाइड की वारिस थीम और स्थानीय ओवरराइड शामिल हों। लेआउट या मास्टर का निरीक्षण करते समय, उसका अपना प्रभावी थीम उपयोग करें। यह मान लेना कि पहले मास्टर की थीम सभी स्लाइड्स पर लागू होती है, उचित नहीं है।

निम्न उदाहरण एक टेक्स्ट भाग बनाता है जो स्पष्ट रूप से गौण लैटिन फ़ॉन्ट को संदर्भित करता है। यह [OverrideTheme.initFontSchemeFromInherited](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFontSchemeFromInherited) के द्वारा एक स्लाइड फ़ॉन्ट स्कीम को प्रारंभ करता है और प्रमुख एवं गौण लैटिन परिवारों को क्रमशः `Arial` और `Calibri` सेट करता है, जिससे इनपुट फ़ाइल के बिना परिणाम पुनरुत्पादनीय बनता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Presentation, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    theme = slide.getThemeManager().getOverrideTheme()
    theme.initFontSchemeFromInherited()
    major_font = FontData("Arial")
    theme.getFontScheme().getMajor().setLatinFont(major_font)
    minor_font = FontData("Calibri")
    theme.getFontScheme().getMinor().setLatinFont(minor_font)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60)
    shape.getTextFrame().setText("Text using the minor theme font")

    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    theme_font = FontData("+mn-lt")
    portion.getPortionFormat().setLatinFont(theme_font)

    font = portion.getPortionFormat().getLatinFont()
    effective_theme = slide.getThemeManager().createThemeEffective()
    print(f"{font.getFontName()} -> {font.getFontName(effective_theme)}")

    explicit_font = FontData("Verdana")
    print(f"{explicit_font.getFontName()} -> {explicit_font.getFontName(effective_theme)}")
finally:
    presentation.dispose()
```

आउटपुट `+mn-lt -> Calibri` इसके बाद `Verdana -> Verdana` दिखाता है। संग्रहीत संदर्भ अपरिवर्तित रहता है, जबकि स्पष्ट फ़ॉन्ट नाम जैसा है वैसा ही लौटाया जाता है। यदि भाग `+mj-lt` उपयोग करता, तो यह थीम में `Arial` में हल हो जाता।

थीम संदर्भ को हल करने से वह फ़ॉन्ट परिवार पता चलता है जो थीम द्वारा निर्दिष्ट है। यह फ़ॉन्ट उपलब्धता या रेंडरिंग के दौरान प्रतिस्थापन/ग्लिफ़ फॉलबैक को नहीं देखता। उन अलग चरणों के लिए देखें: [Font Selection Sequence](/slides/hi/python-java/font-selection-sequence/) और [Font Substitution](/slides/hi/python-java/font-substitution/)।

## **थीम को कॉपी या लागू करें**

नीचे के कार्यप्रवाह विभिन्न थीम‑सम्बंधित समस्याओं को हल करते हैं।

### **बाहरी थीम को मास्टर की निर्भर स्लाइड्स पर लागू करें**

जब आपके पास PowerPoint थीम फ़ाइल (`.thmx`) हो और आप किसी विशिष्ट मास्टर पर निर्भर सभी स्लाइड्स की शैली बदलना चाहें, तो [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) का उपयोग करें। [Presentation.getMasters](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasters) संग्रह से इच्छित मास्टर चुनें (यह [MasterSlideCollection](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/) द्वारा प्रतिनिधित्व किया जाता है), और मेथड को थीम फ़ाइल पथ प्रदान करें।

यह मेथड निम्नलिखित कार्य करता है:

1. चयनित मास्टर के आधार पर एक नया मास्टर स्लाइड बनाता है।
1. नए मास्टर पर बाहरी थीम लागू करता है।
1. पहले चयनित मास्टर पर निर्भर सभी स्लाइड्स को नया मास्टर असाइन करता है।
1. नया निर्मित [MasterSlide](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/) लौटाता है।

निम्न उदाहरण पहली मास्टर पर निर्भर स्लाइड्स में बाहरी थीम लागू करता है और प्रस्तुति को सहेजता है:

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

अमान्य, भ्रष्ट या असमर्थित थीम से [PptxReadException](https://reference.aspose.com/slides/python-java/aspose.slides/pptxreadexception/) उत्पन्न हो सकता है। उपयोगकर्ताओं द्वारा प्रदान किए गए पथ को मान्य करें, फ़ाइल‑सिस्टम त्रुटियों को संभालें, और तभी प्रस्तुति को सहेजें जब थीम सफलतापूर्वक लागू हो गई हो।

केवल उन स्लाइड्स को पुनः असाइन किया जाता है जो चयनित मास्टर पर निर्भर थीं। अन्य मास्टरों से जुड़ी स्लाइड्स अपनी मौजूदा मास्टर और थीम को बरकरार रखती हैं। थीम‑ज्ञात रंग, फ़ॉन्ट, भराव, रेखा, पृष्ठभूमि और प्रभाव बाहरी थीम के आधार पर पुनः गणना किए जाते हैं। सीधे असाइन किए गए रंग, फ़ॉन्ट, भराव और अन्य स्पष्ट फॉर्मेटिंग अपरिवर्तित रह सकते हैं। लेआउट‑स्तर और स्लाइड‑स्तर ओवरराइड नई मास्टर से विरासत में मिली किंमत पर प्राथमिकता ले सकते हैं।

थीम ऐसे फ़ॉन्ट का संदर्भ दे सकती है जो रन‑टाइम वातावरण में उपलब्ध न हों। संगत रेंडरिंग व निर्यात के लिए आवश्यक फ़ॉन्ट स्थापित करें, उन्हें [custom font sources](/slides/hi/python-java/custom-font/) के माध्यम से प्रदान करें, या [font substitution](/slides/hi/python-java/font-substitution/) कॉन्फ़िगर करें।

यह एक प्रत्यक्ष मास्टर‑स्तर कार्यप्रवाह है: मेथड `.thmx` फ़ाइल पथ स्वीकार करता है और स्लाइड‑स्तर या लेआउट‑स्तर थीम ओवरराइड को मैन्युअल रूप से बनाने की आवश्यकता नहीं है।

### **मल्टी‑मास्टर प्रस्तुति में विभिन्न बाहरी थीम लागू करें**

जब संबंधित मास्टर पहले से ज्ञात न हो, तो इसे किसी प्रतिनिधि स्लाइड से [Slide.getLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getLayoutSlide) और [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslide/#getMasterSlide) के द्वारा प्राप्त किया जा सकता है। थीम लागू करने से पहले मूल मास्टर रेफ़रेंसेज़ को सहेजें क्योंकि प्रत्येक कॉल प्रस्तुति में एक नया मास्टर बनाता है।

निम्न उदाहरण दो अनुभागों की स्लाइड्स का उपयोग करके उनके मास्टर ढूंढ़ता है और प्रत्येक समूह पर अलग‑अलग बाहरी थीम लागू करता है:

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

पहली कॉल केवल `first_group_master` पर निर्भर स्लाइड्स को प्रभावित करती है, और दूसरी कॉल केवल `second_group_master` पर निर्भर स्लाइड्स को प्रभावित करती है। किसी अन्य मास्टर से जुड़ी स्लाइड्स नहीं बदली जातीं।

### **स्लाइड्स को स्थानांतरित करते समय स्रोत थीम को संरक्षित रखें**

यदि आप किसी स्लाइड को दूसरे प्रस्तुति में ले जाना चाहते हैं और उसकी मूल डिज़ाइन को बरकरार रखना चाहते हैं, तो [MasterSlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/#addClone) से स्रोत मास्टर को लक्ष्य प्रस्तुति में क्लोन करें, फिर [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) से स्लाइड को क्लोन करें तथा क्लोन किए गए मास्टर को उपयोग में लें। इस प्रक्रिया से मास्टर, उसके लेआउट और संबंधित थीम एक साथ स्थानांतरित होते हैं।

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

यह तब पसंदीदा कार्यप्रवाह है जब स्रोत स्लाइड को गंतव्य में समान रूप दिखना चाहिए। केवल सामग्री को किसी अनिर्दिष्ट लक्ष्य मास्टर पर क्लोन करने से थीम‑आधारित रंग, फ़ॉन्ट, पृष्ठभूमि और प्रभाव बदल सकते हैं।

### **मौजूदा स्लाइड पर थीम मान लागू करें**

यदि लक्ष्य स्लाइड को वर्तमान मास्टर और लेआउट पर रहना है, तो स्रोत थीम से स्लाइड‑स्तर ओवरराइड को प्रारंभ करें। [OverrideTheme.initColorSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initColorSchemeFrom), [OverrideTheme.initFontSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFontSchemeFrom) और [OverrideTheme.initFormatSchemeFrom](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#initFormatSchemeFrom) मेथड्स तीन मुख्य थीम घटकों को ओवरराइड में कॉपी करते हैं।

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

यह स्लाइड द्वारा उपयोग की गई थीम को बदलेगा बिना अन्य स्लाइड्स की विरासत वाली थीम को बदले। स्थानीय ओवरराइड को हटाने और विरासत मानों पर वापस आने के लिए [OverrideTheme.clear](https://reference.aspose.com/slides/python-java/aspose.slides/overridetheme/#clear) को कॉल करें।

### **लेआउट पर थीम ओवरराइड लागू करें**

लेआउट‑स्तर ओवरराइड उन स्लाइड्स पर लागू होता है जो उस लेआउट को उपयोग करती हैं, जब तक कि किसी विशेष स्लाइड का अपना ओवरराइड न हो। समान प्रारंभिक मेथड्स को [LayoutSlideThemeManager](https://reference.aspose.com/slides/python-java/aspose.slides/layoutslidethememanager/) के माध्यम से उपयोग किया जा सकता है:

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

जब कई लेआउट और स्लाइड को समान बेस डिज़ाइन साझा करना हो तो मास्टर या प्रस्तुति‑स्तर थीम का उपयोग करें, एक लेआउट परिवार को अलग शैली चाहिए तो लेआउट ओवरराइड, और केवल वास्तविक अपवादों के लिए स्लाइड ओवरराइड। अत्यधिक स्लाइड‑स्तर ओवरराइड बाद में वैश्विक थीम परिवर्तन को भविष्यवाणी करना कठिन बना देते हैं।

<!-- visual-explanation:presentation-theme:start -->
[![A master theme feeds two layouts; a layout override affects its slides except a slide with a more local override.](visual-presentation-theme-20ad12f2193b.svg)](visual-presentation-theme-20ad12f2193b.svg)

*A layout override applies to slides using that layout unless a slide supplies its own override. Theme-based values follow their resolved scheme; explicitly formatted objects can retain their local appearance. Keep overrides as narrow as the intended design exception.*
<!-- visual-explanation:presentation-theme:end -->

## **थीम पृष्ठभूमि शैलियों को अपडेट करें**

थीम की पृष्ठभूमि भरावें [FormatScheme.getBackgroundFillStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getBackgroundFillStyles) में संग्रहीत होती हैं। PowerPoint UI में पृष्ठभूमि विकल्पों की संख्या इस संग्रह में भौतिक रूप से संग्रहीत भराव परिभाषाओं से अधिक हो सकती है, क्योंकि UI थीम भराव को थीम रंगों और अन्य शैली संदर्भों के साथ संयोजित कर सकती है।

![प्रेज़ेंटेशन थीम के लिए PowerPoint पृष्ठभूमि शैली गैलरी](presentation-design_8.png)

पृष्ठभूमि शैली का उपयोग करने से पहले, संग्रहीत संग्रह और वर्तमान [Background.getStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getStyleIndex) को निरीक्षण करें। स्टाइल इंडेक्स `0` का अर्थ है कोई थीम्ड भराव नहीं; सकारात्मक मान थीम पृष्ठभूमि‑शैली संदर्भ होते हैं। यह सीधे संग्रह को इंडेक्स करने से अलग है, जहाँ `get_Item(0)` पहला संग्रहीत आइटम दर्शाता है। यह मान लेना उचित नहीं है कि प्रत्येक प्रस्तुति में समान पृष्ठभूमि भराव शैलियों की संख्या होती है।

निम्न उदाहरण उपलब्ध पृष्ठभूमि भराव गिनती को रिपोर्ट करता है, पहले मास्टर को एक थीम्ड पृष्ठभूमि संदर्भ असाइन करता है, और प्रस्तुति को सहेजता है:

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

दृश्यमान परिणाम मास्टर द्वारा संदर्भित थीम प्रविष्टि तथा लेआउट या स्लाइड‑स्तर पर किसी भी पृष्ठभूमि ओवरराइड पर निर्भर करता है। यदि स्लाइड अपनी स्वयं की पृष्ठभूमि उपयोग करती है, तो केवल मास्टर पृष्ठभूमि बदलने से वह स्लाइड नहीं बदलेगी। विरासत लागू होने के बाद अंतिम पृष्ठभूमि जानने के लिए [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective) का उपयोग करें।

{{% alert color="warning" title="Warning" %}}
Do not treat the style index as a zero-based collection index. Also avoid hard-coding a style number from one file and assuming it has the same appearance in another file; theme style definitions are presentation-specific.
{{% /alert %}}

{{% alert color="success" title="Tip" %}}
For direct background formatting and background inheritance, see [Presentation Background](/slides/hi/python-java/presentation-background/).
{{% /alert %}}

## **थीम प्रभावों को अपडेट करें**

एक थीम फ़ॉर्मेट स्कीम अलग‑अलग भराव, रेखा और प्रभाव शैली संग्रहों को उजागर करती है, जिन्हें क्रमशः [FormatScheme.getFillStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getFillStyles), [FormatScheme.getLineStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getLineStyles) और [FormatScheme.getEffectStyles](https://reference.aspose.com/slides/python-java/aspose.slides/formatscheme/#getEffectStyles) द्वारा एक्सेस किया जाता है। सामान्य Office थीम में अक्सर तीन प्रमुख शैली प्रविष्टियाँ होती हैं जो दृश्य रूप से सूक्ष्म, मध्यम और तीव्र फ़ॉर्मेटिंग के अनुरूप होती हैं, परन्तु कोड को प्रत्येक संग्रह का निरीक्षण करना चाहिए न कि स्थिर संख्या मान लेना।

![एक ही आकार पर लागू सूक्ष्म, मध्यम, और तीव्र थीम प्रभाव](presentation-design_10.png)

जब आप इन संग्रहों को Python के माध्यम से Java में एक्सेस करते हैं, तो संग्रह इंडेक्स शून्य‑आधारित होता है: `get_Item(0)` पहला संग्रहीत शैली है और `get_Item(2)` तीसरी। एक शैप की शैली‑संदर्भ इंडेक्स अलग अवधारणा है, जिसे [ShapeStyle](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/) द्वारा उजागर किया जाता है। थीम शैली को संशोधित करने से उन शैप्स पर असर पड़ता है जो उस थीम शैली को संदर्भित करते हैं; सीधे फ़ॉर्मेटिंग वाले शैप्स अपरिवर्तित रह सकते हैं।

निम्न उदाहरण जाँचता है कि आवश्यक शैली प्रविष्टियाँ मौजूद हैं, पहली रेखा शैली बदलता है, तीसरी भराव शैली बदलता है, तीसरी प्रभाव शैली में बाहरी छाया सक्षम करता है, और परिणाम सहेजता है:

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

ऐसी शैलियों को संदर्भित करने वाले शैप्स के लिए पहली थीम रेखा शैली लाल हो जाएगी, तीसरी थीम भराव शैली ठोस फ़ॉरेस्ट ग्रीन हो जाएगी, और तीसरी प्रभाव शैली 10 पॉइंट दूरी के साथ बाहरी छाया प्राप्त करेगी। सटीक दृश्य परिणाम अभी भी इस पर निर्भर करता है कि प्रत्येक शैप कौन‑सी स्लॉट को संदर्भित करता है और क्या सीधे फ़ॉर्मेटिंग थीम को ओवरराइड करती है।

![रेखा, भराव और छाया सेटिंग्स बदलने के बाद थीम प्रभाव शैलियाँ](presentation-design_11.png)

## **एक आकार के लिए थीम भराव और रेखा शैलियों का चयन करें**

एक शैप अपने भराव और रूपरेखा को स्वतंत्र रूप से [ShapeStyle.setFillStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/#setFillStyleIndex) और [ShapeStyle.setLineStyleIndex](https://reference.aspose.com/slides/python-java/aspose.slides/shapestyle/#setLineStyleIndex) द्वारा चुन सकता है। प्रत्येक मेथड के लिए, इंडेक्स `1` संबंधित थीम संग्रह में पहला प्रविष्टि चुनता है (`get_Item(0)`), और इंडेक्स `2` दूसरा (`get_Item(1)`)।

निम्न उदाहरण नई प्रस्तुति के डिफ़ॉल्ट थीम में दो भराव शैलियाँ (सोना और आसमान‑नीला) और दो रेखा शैलियाँ (6 pt का गहरा नीला और 12 pt का गहरा लाल) स्थापित करता है। यह स्लाइड को तीन चरणों पर सहेजता है ताकि आप PowerPoint में परिणामों की तुलना कर सकें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    styles = presentation.getMasterTheme().getFormatScheme()

    gold_fill = styles.getFillStyles().get_Item(0)
    gold_fill.setFillType(FillType.Solid)
    gold_fill.getSolidFillColor().setColor(Color(255, 215, 0))
    blue_fill = styles.getFillStyles().get_Item(1)
    blue_fill.setFillType(FillType.Solid)
    blue_fill.getSolidFillColor().setColor(Color(135, 206, 235))

    thin_line = styles.getLineStyles().get_Item(0)
    thin_line.getFillFormat().setFillType(FillType.Solid)
    thin_line.getFillFormat().getSolidFillColor().setColor(Color(0, 0, 139))
    thin_line.setWidth(6)
    thick_line = styles.getLineStyles().get_Item(1)
    thick_line.getFillFormat().setFillType(FillType.Solid)
    thick_line.getFillFormat().getSolidFillColor().setColor(Color(139, 0, 0))
    thick_line.setWidth(12)

    shapes = presentation.getSlides().get_Item(0).getShapes()
    left = shapes.addAutoShape(ShapeType.Rectangle, 100, 205, 200, 130)
    right = shapes.addAutoShape(ShapeType.Rectangle, 420, 205, 200, 130)
    left.getShapeStyle().setFillStyleIndex(1)
    right.getShapeStyle().setFillStyleIndex(2)
    left.getShapeStyle().setLineStyleIndex(1)
    right.getShapeStyle().setLineStyleIndex(1)
    presentation.save("01-initial.pptx", SaveFormat.Pptx)

    right.getShapeStyle().setLineStyleIndex(2)
    presentation.save("02-line-changed.pptx", SaveFormat.Pptx)

    gold_fill.getSolidFillColor().setColor(Color(46, 139, 87))
    presentation.save("03-theme-changed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

| प्रारंभिक शैलियाँ | दाएँ आउटलाइन बदलें | पहले थीम भराव को संपादित करें |
|:---:|:---:|:---:|
| ![सोने और आकाश‑नीले आयतों के साथ मिलते जुलते पतले गहरे नीले आउटलाइन](theme-style-initial.png) | ![आकाश‑नीली आयत अब एक मोटी गहरी लाल आउटलाइन रही](theme-style-line-changed.png) | ![बायीं आयत अब हरी है और दोनों आउटलाइन समान हैं](theme-style-fill-changed.png) |

विभिन्न रेखा शैली का चयन केवल दाएँ आयत की रूपरेखा को बदलता है। पहले थीम भराव को संपादित करने से हर शैप बदल जाता है जो उसे उपयोग करता है। यहाँ केवल बायीं आयत हरी हो गई।

मौजूदा शैप पर, स्थानीय भराव रंग, रेखा रंग या रेखा चौड़ाई उस थीम शैली के भाग को ओवरराइड कर सकती है। यदि शैली इंडेक्स बदलने से कोई दृश्य प्रभाव नहीं दिखता, तो शैप की [direct formatting](/slides/hi/python-java/shape-formatting/) देखें।

## **जाँचें कि प्रभावी ठोस भराव थीम रंग का उपयोग करता है या नहीं**

एक भराव सीधे ऑब्जेक्ट पर संग्रहीत हो सकता है या पैराग्राफ, लेआउट, मास्टर, थीम शैली या किसी अन्य फ़ॉर्मेटिंग स्तर से विरासत में मिल सकता है। उस पदानुक्रम को अपरिवर्तनीय प्रभावी भराव डेटा में बदलने के लिए [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective) को कॉल करें। पहले प्रभावी डेटा ऑब्जेक्ट पर `getFillType` जाँचें। केवल जब वह `FillType.Solid` हो, तब ही ठोस‑भराव गुणों को पढ़ें।

ठोस‑भराव के लिए, `getSolidFillColor` विरासत, थीम लुक‑अप और रंग रूपांतरण के लागू होने के बाद अंतिम RGB मान देता है। `getSolidFillSchemeColor` संबंधित तार्किक [SchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/schemecolor/) स्लॉट लौटाता है, जैसे `Text1` या `Accent6`। `SchemeColor.NotDefined` का अर्थ है कि प्रभावी ठोस भराव स्कीम रंग पर आधारित नहीं है। ऐसी प्रविधि में जहाँ भराव या तो थीम रंग होते हैं या सीधे RGB, यह मान सीधे RGB भराव को पहचानता है।

स्थानीय [ColorFormat.getSchemeColor](https://reference.aspose.com/slides/python-java/aspose.slides/colorformat/#getSchemeColor) मान को अकेले वर्गीकृत करने के लिए उपयोग न करें। उदाहरण के लिए, कोई टेक्स्ट भाग स्थानीय तौर पर स्कीम रंग परिभाषित नहीं रखता, इसलिए उसका स्थानीय मान `NotDefined` होगा, जबकि उसका प्रभावी भराव थीम रंग से विरासत में लेकर `Text1` या `Accent6` में हल हो सकता है। इसके विपरीत, `getSolidFillSchemeColor` बताता है कि प्रभावी रंग किस तार्किक थीम स्लॉट से आया है, पर यह नहीं बताता कि वह स्लॉट ऑब्जेक्ट, पैराग्राफ, लेआउट, मास्टर या किसी अन्य स्तर से आया है।

निम्न उदाहरण एक प्रस्तुति को लोड करता है, शैप भराव और टेक्स्ट‑भाग भराव दोनों का ऑडिट करता है, प्रत्येक अंतिम RGB मान और सम्बंधित स्कीम रंग प्रिंट करता है, और ठोस भरावों को चिह्नित करता है जो थीम रंग परिवर्तन को ट्रैक नहीं करेंगे:

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

`NotDefined` शाखा ठोस भरावों की ऑडिट सूची प्रदान करती है जो थीम रंग स्लॉट में परिवर्तन पर प्रतिक्रिया नहीं देंगे। ऐसे ऑब्जेक्ट्स की समीक्षा करें जब प्रस्तुति को नई ब्रांड पैलेट का पालन करना हो। रिपोर्ट किया गया RGB मान अभी भी वर्तमान दृश्य को दिखाता है, जबकि स्कीम मान यह स्पष्ट करता है कि वह उपस्थिति थीम से जुड़ी है या नहीं।

प्रभावी‑फ़ॉर्मेट ऑब्जेक्ट स्नैपशॉट होते हैं। प्रस्तुति थीम, थीम ओवरराइड या कोई विरासत फ़ॉर्मेटिंग बदलने के बाद, फिर से `getEffective` कॉल करें और नई प्रभावी भराव डेटा ऑब्जेक्ट पढ़ें इससे पहले कि आप रंगों की तुलना या रिपोर्ट करें।

## **प्रभावी थीम मान पढ़ें**

कच्चे थीम ऑब्जेक्ट बताते हैं कि किसी विशेष स्तर पर क्या परिभाषित है। प्रभावी मान बताते हैं कि विरासत और स्थानीय ओवरराइड लागू होने के बाद स्लाइड या शैप वास्तव में क्या उपयोग करता है। स्लाइड के लिए, [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) को कॉल करें। पृष्ठभूमि के लिए, [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective) का उपयोग करें, और भराव के लिए, [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective) का।

निम्न उदाहरण एक स्लाइड से प्रभावी थीम, पृष्ठभूमि और पहले शैप भराव को पढ़ता है:

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

रेंडरिंग निदान, वैधता जांच और तुलना के लिए प्रभावी डेटा का उपयोग करें। यदि आप केवल [Presentation.getMasterTheme](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getMasterTheme) का निरीक्षण करते हैं, तो आप मास्टर, लेआउट, स्लाइड या शैप ओवरराइड को चूक सकते हैं जो अंतिम उपस्थिति को बदलते हैं।

## **FAQ**

**क्या बाहरी थीम लागू करने से प्रस्तुति की सभी स्लाइड्स प्रभावित होती हैं?**

नहीं। [MasterSlide.applyExternalThemeToDependingSlides](https://reference.aspose.com/slides/python-java/aspose.slides/masterslide/#applyExternalThemeToDependingSlides) केवल उन स्लाइड्स को पुनः असाइन करता है जो चयनित मास्टर पर निर्भर हैं। अन्य मास्टर उपयोग करने वाली स्लाइड्स अपनी मौजूदा थीम रखती हैं।

**क्या मैं मास्टर बदले बिना एकल स्लाइड पर थीम लागू कर सकता हूँ?**

हां। स्लाइड के [SlideThemeManager](https://reference.aspose.com/slides/python-java/aspose.slides/slidethememanager/) का उपयोग करके उसकी ओवरराइड थीम को प्रारंभ करें। परिवर्तन केवल उस स्लाइड तक सीमित रहता है; अन्य स्लाइड्स अपनी मौजूदा थीम को विरासत में प्राप्त करती रहती हैं।

**एक प्रस्तुति से दूसरे में थीम ले जाने का सबसे सुरक्षित तरीका क्या है?**

जब आप स्लाइड को स्थानांतरित करते हैं और उसके स्रोत स्वरूप को बरकरार रखना चाहते हैं, तो स्रोत मास्टर को गंतव्य में क्लोन करें और फिर [MasterSlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/masterslidecollection/#addClone) तथा [SlideCollection.addClone](https://reference.aspose.com/slides/python-java/aspose.slides/slidecollection/#addClone) का उपयोग करके स्लाइड को क्लोन करें। इससे मास्टर, लेआउट और थीम एक साथ रखे जाते हैं।

**मैं विरासत और ओवरराइड के बाद प्रभावी मान कैसे देख सकता हूँ?**

स्लाइड या लेआउट थीम के लिए [BaseOverrideThemeManager.createThemeEffective](https://reference.aspose.com/slides/python-java/aspose.slides/baseoverridethememanager/#createThemeEffective) का उपयोग करें और फ़ॉर्मेट ऑब्जेक्ट्स जैसे [Background.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/background/#getEffective) और [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective) के संबंधित प्रभावी‑डेटा मेथड्स का उपयोग करें। ये API विरासत और ओवरराइड लागू होने के बाद हल किए गए मान लौटाते हैं।