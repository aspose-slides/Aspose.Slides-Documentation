---
title: Python के माध्यम से Java का उपयोग करके PowerPoint फ़ॉन्ट को अनुकूलित करें
linktitle: कस्टम फ़ॉन्ट
type: docs
weight: 20
url: /hi/python-java/custom-font/
keywords:
- फ़ॉन्ट
- कस्टम फ़ॉन्ट
- बाहरी फ़ॉन्ट
- फ़ॉन्ट लोड करें
- फ़ॉन्ट प्रबंधित करें
- फ़ॉन्ट फ़ोल्डर
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Python के लिए Java के माध्यम से Aspose.Slides के साथ PowerPoint स्लाइड्स में फ़ॉन्ट को अनुकूलित करें ताकि आपकी प्रस्तुतियाँ किसी भी डिवाइस पर तीक्ष्ण और सुसंगत रहें।"
---
## **अवलोकन**

Aspose.Slides आपको ऑपरेटिंग सिस्टम पर फ़ॉन्ट स्थापित किए बिना प्रस्तुतियों में कस्टम फ़ॉन्ट उपयोग करने की अनुमति देता है। आप फ़ॉन्ट को कस्टम फ़ोल्डरों से लोड कर सकते हैं, दस्तावेज़-स्तर फ़ॉन्ट स्रोतों के माध्यम से किसी विशिष्ट प्रस्तुति के लिए फ़ॉन्ट प्रदान कर सकते हैं, या बाइनरी डेटा से सीधे बाहरी फ़ॉन्ट लोड कर सकते हैं।

लोड किए गए फ़ॉन्ट उस समय उपयोग होते हैं जब प्रस्तुति को रेंडर या एक्सपोर्ट किया जाता है, उदाहरण के लिए PDF, इमेज और अन्य समर्थित फ़ॉर्मेट में। यह विभिन्न पर्यावरणों में प्रस्तुति आउटपुट को सुसंगत रखने में मदद करता है। लेख यह भी बताता है कि Aspose.Slides द्वारा उपयोग किए गए फ़ॉन्ट फ़ोल्डर कैसे जांचें और बाहरी फ़ॉन्ट के साथ काम करने के बाद फ़ॉन्ट कैश को कैसे साफ़ करें।

रेंडरिंग के लिए कस्टम फ़ॉन्ट पंजीकृत करना PPTX फ़ाइल में फ़ॉन्ट एम्बेड करने से अलग है। यदि फ़ॉन्ट को प्रस्तुति के भीतर संग्रहीत करना आवश्यक है, तो फ़ॉन्ट एम्बेडिंग फीचर का स्पष्ट रूप से उपयोग करें।

एक प्रस्तुति थीम व्यक्तिगत लेखन प्रणालियों के लिए विभिन्न फ़ॉन्ट परिवारों का संदर्भ दे सकती है। ये मैपिंग्स फ़ॉन्ट नाम सहेजती हैं लेकिन फ़ॉन्ट फ़ाइलों को स्थापित या लोड नहीं करतीं। मैपिंग्स को प्रबंधित करने के लिए देखें [Script-Specific Theme Fonts](/slides/hi/python-java/script-specific-font-mappings/), और नीचे दिए गए लोडिंग विकल्पों का उपयोग करें ताकि संदर्भित फ़ॉन्ट निरंतर रेंडरिंग के लिए उपलब्ध हों।

{{% alert color="info" title="Note" %}}
Aspose.Slides आपको इन फ़ॉन्ट को [loadExternalFonts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsloader/#loadExternalFonts) मेथड का उपयोग करके लोड करने की अनुमति देता है:

* TrueType (.ttf) और TrueType Collection (.ttc) फ़ॉन्ट। देखें [TrueType](https://en.wikipedia.org/wiki/TrueType)।
* OpenType (.otf) फ़ॉन्ट। देखें [OpenType](https://en.wikipedia.org/wiki/OpenType)।
{{% /alert %}}

## **कस्टम फ़ॉन्ट लोड करना**

Aspose.Slides आपको प्रस्तुति में प्रयुक्त फ़ॉन्ट को सिस्टम पर स्थापित किए बिना लोड करने की अनुमति देता है। यह निर्यात आउटपुट—जैसे PDF, इमेज और अन्य समर्थित फ़ॉर्मेट—को प्रभावित करता है, जिससे प्राप्त दस्तावेज़ विभिन्न पर्यावरणों में सुसंगत दिखते हैं। फ़ॉन्ट कस्टम डायरेक्टरीज़ से लोड होते हैं।

1. उन फ़ोल्डरों को निर्दिष्ट करें जिनमें फ़ॉन्ट फ़ाइलें हैं।
2. उन फ़ोल्डरों से फ़ॉन्ट लोड करने के लिए स्थैतिक [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsloader/#loadExternalFonts) मेथड को कॉल करें।
3. प्रस्तुति को लोड और रेंडर/एक्सपोर्ट करें।
4. फ़ॉन्ट कैश को साफ़ करने के लिए [FontsLoader.clearCache](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsloader/#clearCache) को कॉल करें।

निम्नलिखित कोड उदाहरण फ़ॉन्ट लोडिंग प्रक्रिया को दर्शाता है:

```python
from jpype import JArray, JString
from asposeslides.api import FontsLoader, Presentation, SaveFormat

# कस्टम फ़ॉन्ट फ़ाइलों वाले फ़ोल्डर निर्धारित करें।
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])

# निर्दिष्ट फ़ोल्डरों से कस्टम फ़ॉन्ट लोड करें।
FontsLoader.loadExternalFonts(font_folders)

presentation = None
try:
    presentation = Presentation("sample.pptx")

    # लोड किए गए फ़ॉन्ट्स का उपयोग करके प्रस्तुति को रेंडर/एक्सपोर्ट करें।
    presentation.save("output.pdf", SaveFormat.Pdf)
finally:
    if presentation is not None:
        presentation.dispose()

    # काम समाप्त होने के बाद फ़ॉन्ट कैश को साफ़ करें।
    FontsLoader.clearCache()
```

{{% alert color="info" title="Note" %}}
[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsloader/#loadExternalFonts) फ़ॉन्ट खोज पथ में अतिरिक्त फ़ोल्डर जोड़ता है, लेकिन फ़ॉन्ट प्रारंभ क्रम नहीं बदलता। फ़ॉन्ट इस क्रम में प्रारंभ होते हैं:

1. डिफ़ॉल्ट ऑपरेटिंग सिस्टम फ़ॉन्ट पथ।
1. [FontsLoader](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsloader/) के माध्यम से लोड किए गए पथ।
{{%/alert %}}

## **कस्टम फ़ॉन्ट फ़ोल्डर प्राप्त करना**

Aspose.Slides [getFontFolders](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsloader/#getFontFolders) मेथड प्रदान करता है जिससे आप फ़ॉन्ट फ़ोल्डर खोज सकें। यह मेथड [loadExternalFonts](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsloader/#loadExternalFonts) मेथड के द्वारा जोड़े गए फ़ोल्डर और सिस्टम फ़ॉन्ट फ़ोल्डर दोनों को लौटाता है।

यह Python कोड दर्शाता है कि आप [getFontFolders](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsloader/#getFontFolders) को कैसे उपयोग कर सकते हैं:

```python
from asposeslides.api import FontsLoader

# loadExternalFonts के द्वारा जोड़े गए फ़ोल्डर और सिस्टम फ़ॉन्ट फ़ोल्डर प्राप्त करें।
font_folders = FontsLoader.getFontFolders()
```

## **प्रस्तुति के साथ उपयोग किए जाने वाले कस्टम फ़ॉन्ट निर्दिष्ट करना**

Aspose.Slides [getDocumentLevelFontSources](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) मेथड प्रदान करता है जिससे आप बाहरी फ़ॉन्ट निर्दिष्ट कर सकें जो प्रस्तुति के साथ उपयोग होंगे।

यह Python कोड दर्शाता है कि आप [getDocumentLevelFontSources](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) मेथड को कैसे उपयोग कर सकते हैं:

```python
from pathlib import Path
from jpype import JArray, JByte, JString
from asposeslides.api import LoadOptions, Presentation

memory_font_primary = Path("customfonts/CustomFont1.ttf").read_bytes()
memory_font_secondary = Path("customfonts/CustomFont2.ttf").read_bytes()

load_options = LoadOptions()
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])
memory_fonts = JArray(JByte, 2)([memory_font_primary, memory_font_secondary])
load_options.getDocumentLevelFontSources().setFontFolders(font_folders)
load_options.getDocumentLevelFontSources().setMemoryFonts(memory_fonts)

presentation = Presentation("MyPresentation.pptx", load_options)
try:
    # प्रस्तुति के साथ काम करें।
    # CustomFont1, CustomFont2, और assets/fonts और global/fonts से फ़ॉन्ट्स
    # और उनके सबफ़ोल्डर प्रस्तुति के लिए उपलब्ध हैं।
    pass
finally:
    presentation.dispose()
```

## **फ़ॉन्ट को बाहरी रूप से प्रबंधित करना**

Aspose.Slides [loadExternalFont](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fontsloader/#loadExternalFont) मेथड प्रदान करता है जिससे आप बाइनरी डेटा से बाहरी फ़ॉन्ट लोड कर सकते हैं।

यह Python कोड बाइट ऐरे फ़ॉन्ट लोडिंग प्रक्रिया को दर्शाता है:

```python
from pathlib import Path
from jpype import JArray, JByte
from asposeslides.api import FontsLoader, Presentation

font_data = Path("ARIALN.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNBI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))

try:
    presentation = Presentation()
    try:
            # बाहरी फ़ॉन्ट्स प्रस्तुति के जीवनकाल के दौरान लोड होते हैं।
            pass
    finally:
        presentation.dispose()
finally:
    FontsLoader.clearCache()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या कस्टम फ़ॉन्ट सभी फ़ॉर्मेट (PDF, PNG, SVG, HTML) के एक्सपोर्ट को प्रभावित करते हैं?**  
हाँ। कनेक्टेड फ़ॉन्ट रेंडरर द्वारा सभी एक्सपोर्ट फ़ॉर्मेट में प्रयोग किए जाते हैं।

**क्या कस्टम फ़ॉन्ट स्वचालित रूप से उत्पन्न PPTX में एम्बेड हो जाते हैं?**  
नहीं। रेंडरिंग के लिए फ़ॉन्ट पंजीकृत करना उसे PPTX में एम्बेड करने के समान नहीं है। यदि आपको फ़ॉन्ट को प्रस्तुति फ़ाइल के भीतर रखना है, तो आपको स्पष्ट रूप से [embedding features](/slides/hi/python-java/embedded-font/) का उपयोग करना होगा।

**क्या मैं कस्टम फ़ॉन्ट में कुछ ग्लिफ़ न होने पर फॉलबैक व्यवहार को नियंत्रित कर सकता हूँ?**  
हाँ। आप [font substitution](/slides/hi/python-java/font-substitution/), [replacement rules](/slides/hi/python-java/font-replacement/) और [fallback sets](/slides/hi/python-java/fallback-font/) को कॉन्फ़िगर कर सकते हैं ताकि जब अनुरोधित ग्लिफ़ अनुपलब्ध हो तो किस फ़ॉन्ट का उपयोग होगा, यह ठीक-ठीक निर्धारित किया जा सके।

**क्या मैं Linux/Docker कंटेनर में सिस्टम‑वाइड स्थापित किए बिना फ़ॉन्ट उपयोग कर सकता हूँ?**  
हाँ। अपने स्वयं के फ़ॉन्ट फ़ोल्डर की ओर इंगित करें या बाइट ऐरे से फ़ॉन्ट लोड करें। इससे कंटेनर इमेज में सिस्टम फ़ॉन्ट डायरेक्टरी पर किसी भी निर्भरता को हटाया जाता है।

**लाइसेंसिंग के बारे में क्या—क्या मैं किसी भी कस्टम फ़ॉन्ट को बिना प्रतिबंध के एम्बेड कर सकता हूँ?**  
आप फ़ॉन्ट लाइसेंस अनुपालन के लिए स्वयं जिम्मेदार हैं। शर्तें अलग-अलग होती हैं; कुछ लाइसेंस एम्बेडिंग या व्यावसायिक उपयोग पर प्रतिबंध लगाते हैं। आउटपुट वितरित करने से पहले हमेशा फ़ॉन्ट के EULA को समीक्षा करें।