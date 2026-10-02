---
title: पाइथन के माध्यम से जावा में प्रस्तुति टेक्स्ट फ़ॉर्मेट करें
linktitle: टेक्स्ट फ़ॉर्मेटिंग
type: docs
weight: 50
url: /hi/python-java/text-formatting/
keywords:
- पैराग्राफ़ संरेखित करें
- टेक्स्ट शैली
- टेक्स्ट पृष्ठभूमि
- टेक्स्ट पारदर्शिता
- अक्षर अंतराल
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- टेक्स्ट घूर्णन
- घूर्णन कोण
- टेक्स्ट फ्रेम
- लाइन स्पेसिंग
- ऑटॉफिट प्रॉपर्टी
- टेक्स्ट फ्रेम एंकर
- टेक्स्ट टैबुलेशन
- डिफ़ॉल्ट भाषा
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को फ़ॉर्मेट और शैलीबद्ध करें। फ़ॉन्ट, रंग, संरेखण और अधिक को अनुकूलित करें।"
---
## **अवलोकन**

यह लेख दिखाता है कि Aspose.Slides for Python via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में टेक्स्ट को कैसे फॉर्मेट किया जाए। यह पृष्ठभूमि रंग, पारदर्शिता, अक्षर अंतराल, फ़ॉन्ट गुण, घूर्णन, पैराग्राफ अंतराल, ऑटॉफिट व्यवहार, टेक्स्ट एंकरिंग, टैब स्टॉप, और भाषा सेटिंग्स को कवर करता है।

जब तक अन्यथा उल्लेख न किया गया हो, उदाहरणों में [sample.pptx](sample.pptx) का उपयोग किया गया है। इसकी पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है, और उसका पहला पैराग्राफ नीचे दिखाए गए टेक्स्ट को शामिल करता है। स्लाइड और आकार दोनों के इंडेक्स शून्य-आधारित होते हैं। जो उदाहरण बोल्ड भागों का चयन करते हैं, वे प्रभावी फॉर्मेटिंग का उपयोग करते हैं, जिसमें विरासत में मिली बोल्ड फॉर्मेटिंग भी शामिल है:

![नमूना टेक्स्ट](sample_text.png)

शाब्दिक टेक्स्ट या रेगुलर‑एक्सप्रेशन मिलानों को खोजने और हाईलाईट करने के लिए, देखें [टेक्स्ट खोजें और बदलें](/slides/hi/python-java/search-and-replace-text/)।

## **टेक्स्ट पृष्ठभूमि रंग सेट करें**

एक पैराग्राफ़ के लिए डिफ़ॉल्ट हाईलाईट रंग सेट करने हेतु [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) का उपयोग करें, या व्यक्तिगत टेक्स्ट हिस्सों के लिए [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getHighlightColor) का उपयोग करें।

निम्न उदाहरण पहले पैराग्राफ़ के लिए हल्के ग्रे हाईलाईट को डिफ़ॉल्ट के रूप में सेट करता है। व्यक्तिगत हिस्सों पर स्पष्ट हाईलाईट रंग इस डिफ़ॉल्ट से ऊपरस्थ होते हैं:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # पूरे पैराग्राफ़ के लिए हाईलाईट रंग सेट करें.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![ग्रे पैराग्राफ़](gray_paragraph.png)

नीचे दिया गया कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट** वाले **टेक्स्ट हिस्सों** के लिए पृष्ठभूमि रंग कैसे सेट किया जाए:

```python
import jpide
import asposeslides

if not jpide.isJVMStarted():
    jpide.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # टेक्स्ट हिस्से के लिए हाईलाईट रंग सेट करें.
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![ग्रे टेक्स्ट हिस्से](gray_text_portions.png)

## **टेक्स्ट पैराग्राफ़ संरेखित करें**

टेक्स्ट फ्रेम के भीतर पैराग्राफ़ संरेखण सेट करने के लिए [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) का उपयोग करें। मान केंद्रित, बाएं‑संरेखित, दाएं‑संरेखित, समानांतर आदि हो सकते हैं।

निम्न कोड उदाहरण पैराग्राफ़ को **केंद्र** में कैसे संरेखित किया जाए दिखाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # पैराग्राफ़ का संरेखण केंद्र में सेट करें.
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![संरेखित पैराग्राफ़](aligned_paragraph.png)

## **पंक्ति के भीतर फ़ॉन्ट संरेखित करें**

विभिन्न फ़ॉन्ट आकार वाले टेक्स्ट हिस्सों को एक पंक्ति के भीतर लंबवत संरेखित करने हेतु [ParagraphFormat.setFontAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setFontAlignment) का उपयोग करें। यह सेटिंग पूरे पैराग्राफ़ पर लागू होती है और प्रत्येक लाइन में संरेखण को नियंत्रित करती है।

निम्न स्वनिर्भर उदाहरण एक स्लाइड पर चार लेबल वाले टेक्स्ट बॉक्स बनाता है। प्रत्येक पैराग्राफ़ में 18, 36 और 54 पॉइंट का समान टेक्स्ट होता है, जिसमें अलग‑अलग फ़ॉन्ट संरेखण होता है। यह Arial का उपयोग करता है, ऑटॉफिट और रैपिंग को निष्क्रिय करता है, और टेक्स्ट फ्रेम को एक पंक्ति के लिए पर्याप्त बड़ा रखता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontAlignment, FontData, NullableBool, Paragraph, Portion, Presentation, SaveFormat, ShapeType, TextAlignment, TextAnchorType, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    alignments = [FontAlignment.Baseline, FontAlignment.Top, FontAlignment.Center, FontAlignment.Bottom]
    alignment_names = ["Baseline", "Top", "Center", "Bottom"]
    font_sizes = [18.0, 36.0, 54.0]
    font = FontData("Arial")

    for i, alignment in enumerate(alignments):
        shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 30, 20 + i * 130, 660, 120)
        shape.getFillFormat().setFillType(FillType.NoFill)
        shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill)

        text_frame = shape.getTextFrame()
        text_frame.getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
        text_frame.getTextFrameFormat().setWrapText(NullableBool.False_)

        label = text_frame.getParagraphs().get_Item(0)
        label.setText(alignment_names[i])
        label.getParagraphFormat().setAlignment(TextAlignment.Left)
        label.getParagraphFormat().getDefaultPortionFormat().setFontHeight(14)
        label.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        label.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY)

        paragraph = Paragraph()
        paragraph.getParagraphFormat().setFontAlignment(alignment)
        paragraph.getParagraphFormat().setAlignment(TextAlignment.Left)
        paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
        paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        for font_size in font_sizes:
            portion = Portion("Ag ")
            portion.getPortionFormat().setFontHeight(font_size)
            paragraph.getPortions().add(portion)

        text_frame.getParagraphs().add(paragraph)

    presentation.save("font_alignment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![Baseline, Top, Center, Bottom फ़ॉन्ट संरेखण का तुलना (मिश्रित फ़ॉन्ट आकारों के साथ)](font_alignment.png)

फ़ॉन्ट संरेखण फ़ॉन्ट मीट्रिक पर आधारित होती है, इसलिए व्यक्तिगत अक्षरों के दृश्य किनारे आवश्यक रूप से बिल्कुल मेल नहीं खा सकते। उदाहरण में एक बड़े अक्षर और एक डीस्केंडर शामिल है ताकि बेसलाइन और बॉटम संरेखण के अंतर को स्पष्ट किया जा सके। फ़ॉन्ट उपलब्धता, सब्स्टीट्यूशन, उपयोग किए गए अक्षर, और फ़ॉन्ट आकारों का अंतर परिणाम को प्रभावित करता है। फ्रेम का आकार, मार्जिन, लाइन स्पेसिंग, रैपिंग और ऑटॉफिट भी लेआउट को प्रभावित करती हैं; मोड की तुलना करते समय समान फ़ॉन्ट और लेआउट सेटिंग्स का उपयोग करें।

यह सेटिंग [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setAlignment) से भिन्न है, जो क्षैतिज पैराग्राफ संरेखण को नियंत्रित करती है, और [TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) से, जो आकार के भीतर टेक्स्ट ब्लॉक को लंबवत स्थित करता है। [BasePortionFormat.setEscapement](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setEscapement) द्वारा सुपरसक्रिप्ट और सबस्क्रिप्ट फॉर्मेटिंग व्यक्तिगत हिस्सों को बेसलाइन के सापेक्ष शिफ्ट करती है, न कि पैराग्राफ़ की लाइनों के फ़ॉन्ट संरेखण को सेट करती है।

## **टेक्स्ट के लिए पारदर्शिता सेट करें**

पारदर्शिता को [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat) को असाइन किए गए रंग के अल्फा घटक के माध्यम से नियंत्रित किया जाता है। नीचे दिए गए उदाहरणों में `alpha = 50` 0–255 स्केल पर एक ARGB अल्फा‑चैनल मान है, न कि पारदर्शिता प्रतिशत।

निम्न कोड उदाहरण दिखाता है कि **पूरे पैराग्राफ़** पर पारदर्शिता कैसे लागू की जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # टेक्स्ट का फ़िल रंग पारदर्शी रंग में सेट करें.
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![पारदर्शी पैराग्राफ़](transparent_paragraph.png)

निम्न कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट** वाले **टेक्स्ट हिस्सों** पर पारदर्शिता कैसे लागू की जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

alpha = 50
text_color = Color(0, 0, 0, alpha)

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # टेक्स्ट हिस्से की पारदर्शिता सेट करें.
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![पारदर्शी टेक्स्ट हिस्से](transparent_text_portions.png)

## **टेक्स्ट के लिए अक्षर अंतराल सेट करें**

एक टेक्स्ट बॉक्स में अक्षरों के बीच अंतराल को विस्तारित या घटाने के लिए [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setSpacing) का उपयोग करें। नीचे के उदाहरण 3 पॉइंट अंतराल जोड़ते हैं; नकारात्मक मान टेक्स्ट को संकुचित करते हैं।

निम्न Python कोड दिखाता है कि **पूरे पैराग्राफ़** में अक्षर अंतराल कैसे बढ़ाया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # नोट: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मान उपयोग करें.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # अक्षर अंतराल बढ़ाएँ.

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![पैराग्राफ़ में अक्षर अंतराल](character_spacing_in_paragraph.png)

निम्न कोड उदाहरण दिखाता है कि **बोल्ड फ़ॉन्ट** वाले **टेक्स्ट हिस्सों** में अक्षर अंतराल कैसे बढ़ाया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # नोट: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मान उपयोग करें.
            portion.getPortionFormat().setSpacing(3) # अक्षर अंतराल बढ़ाएँ.

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![टेक्स्ट हिस्सों में अक्षर अंतराल](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट के लिए केरनिंग निष्क्रिय करें**

कुछ मामलों में, Aspose.Slides द्वारा रेंडर किया गया टेक्स्ट PowerPoint में प्रदर्शित टेक्स्ट की तुलना में थोड़ा तंग लग सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint कुछ फ़ॉन्ट के लिए केरनिंग डेटा को अनदेखा कर देता है, भले ही फ़ॉन्ट में वैध केरनिंग जानकारी मौजूद हो और PowerPoint सेटिंग्स में केरनिंग सक्षम हो।

ऐसे मामलों में रेंडरिंग को PowerPoint के करीब लाने के लिए, आप उन टेक्स्ट हिस्सों के लिए केरनिंग निष्क्रिय कर सकते हैं जो प्रभावित फ़ॉन्ट का उपयोग करते हैं। [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) को वास्तविक फ़ॉन्ट आकार से बड़ा मान सेट करें। यह उदाहरण पहले स्लाइड के पहले आकार में टेक्स्ट बॉक्स वाले "presentation.pptx" की आवश्यकता करता है। यह प्रभावी फ़ॉन्ट नामों (विरासत में मिले फ़ॉन्ट सहित) की जांच करता है और Roboto उपयोग करने वाले हिस्सों के लिए 100‑पॉइंट थ्रेशहोल्ड सेट करता है। इससे 100 पॉइंट से नीचे के फ़ॉन्ट आकार वाले मिलते‑जुलते हिस्सों के लिए केरनिंग निष्क्रिय हो जाती है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    target_font = "Roboto"

    for paragraph in auto_shape.getTextFrame().getParagraphs():
        for portion in paragraph.getPortions():
            portion_format = portion.getPortionFormat().getEffective()
            fonts = (portion_format.getLatinFont(), portion_format.getEastAsianFont(), portion_format.getComplexScriptFont())
            if any(font is not None and font.getFontName() == target_font for font in fonts):
                portion.getPortionFormat().setKerningMinimalSize(100)

    presentation.save("output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

थ्रेशहोल्ड से नीचे के मिलते टेक्स्ट के लिए, यह सेटिंग केरनिंग को रोकती है और उन फ़ॉन्टों के लिए Aspose.Slides रेंडरिंग को PowerPoint के दृश्य आउटपुट के करीब लाने में मदद कर सकती है जो इस PowerPoint‑विशिष्ट व्यवहार से प्रभावित होते हैं।

## **टेक्स्ट फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण को पैराग्राफ़ स्तर पर [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) के माध्यम से या व्यक्तिगत हिस्सों पर [PortionFormat](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/) द्वारा सेट किया जा सकता है।

निम्न उदाहरण पहले पैराग्राफ़ के डिफ़ॉल्ट फ़ॉन्ट को 12‑पॉइंट Times New Roman, बोल्ड, इटैलिक और डॉटेड अंडरलाइन के साथ सेट करता है। व्यक्तिगत हिस्सों पर स्पष्ट फॉर्मेटिंग इन डिफ़ॉल्ट्स से ऊपरस्थ होती है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    # पैराग्राफ़ के लिए फ़ॉन्ट गुण सेट करें.
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontHeight(12)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontBold(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontItalic(NullableBool.True_)
    paragraph.getParagraphFormat().getDefaultPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
    font = FontData("Times New Roman")
    paragraph.getParagraphFormat().getDefaultPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![पैराग्राफ़ के फ़ॉन्ट गुण](font_properties_for_paragraph.png)

निम्न उदाहरण उन हिस्सों पर 13‑पॉइंट Times New Roman, इटैलिक फॉर्मेटिंग और डॉटेड अंडरलाइन लागू करता है जिनकी प्रभावी फॉर्मेटिंग बोल्ड है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, NullableBool, Presentation, SaveFormat, TextUnderlineType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # टेक्स्ट हिस्से के लिए फ़ॉन्ट गुण सेट करें.
            portion.getPortionFormat().setFontHeight(13)
            portion.getPortionFormat().setFontItalic(NullableBool.True_)
            portion.getPortionFormat().setFontUnderline(TextUnderlineType.Dotted)
            font = FontData("Times New Roman")
            portion.getPortionFormat().setLatinFont(font)

    presentation.save("font_properties_for_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![टेक्स्ट हिस्सों के फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **टेक्स्ट घूर्णन सेट करें**

एक आकार के भीतर पूर्वनिर्धारित टेक्स्ट अभिविन्यास सेट करने के लिए [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setTextVerticalType) का उपयोग करें।

निम्न कोड उदाहरण टेक्स्ट अभिविन्यास को [TextVerticalType.Vertical270](https://reference.aspose.com/slides/python-java/aspose.slides/textverticaltype/) पर सेट करता है, जो टेक्स्ट को **90 डिग्री प्रतिक्लोकwise घुमाता** है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextVerticalType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setTextVerticalType(TextVerticalType.Vertical270)

    presentation.save("text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![टेक्स्ट घूर्णन](text_rotation.png)

## **टेक्स्ट फ्रेम के लिए कस्टम घूर्णन सेट करें**

एक [TextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/textframe/) के लिए कस्टम घूर्णन कोण सेट करने हेतु [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setRotationAngle) का उपयोग करें।

निम्न कोड उदाहरण आकार के भीतर टेक्स्ट फ्रेम को 3 डिग्री घड़ीwise घुमाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setRotationAngle(3)

    presentation.save("custom_text_rotation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![कस्टम टेक्स्ट घूर्णन](custom_text_rotation.png)

## **पैराग्राफ़ की लाइन स्पेसिंग सेट करें**

Aspose.Slides निम्नलिखित प्रॉपर्टीज़ प्रदान करता है: [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore), और [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceWithin) ताकि पैराग्राफ़ स्पेसिंग को नियंत्रित किया जा सके। इनका उपयोग इस प्रकार है:

* लाइन स्पेसिंग को लाइन की ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिए सकारात्मक मान उपयोग करें।
* लाइन स्पेसिंग को पॉइंट में निर्दिष्ट करने के लिए नकारात्मक मान उपयोग करें।

निम्न उदाहरण पहले पैराग्राफ़ के भीतर स्पेसिंग को लाइन की ऊँचाई के 200 % (डबल स्पेसिंग) पर सेट करता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setSpaceWithin(200)

    presentation.save("line_spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![पैराग्राफ़ में लाइन स्पेसिंग](line_spacing.png)

## **लाइन ब्रेेकिंग नियंत्रित करें**

पैराग्राफ़ की लाइन‑ब्रेक नियम संकीर्ण टेक्स्ट ब्लॉकों और लैटिन तथा ईस्ट एशियन टेक्स्ट मिश्रित प्रस्तुतियों में उपयोगी होते हैं। निम्न मेथड्स [ParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/) से संबंधित हैं, इसलिए वे पूरे पैराग्राफ़ पर लागू होते हैं:

- [setLatinLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) लैटिन लाइन‑ब्रेक नियम नियंत्रित करता है। मिश्रित टेक्स्ट में इसे बदलने से पड़ोसी ईस्ट एशियन टेक्स्ट और विराम चिह्नों की रैप भी बदल सकती है।
- [setEastAsianLineBreak](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) ईस्ट एशियन लाइन‑ब्रेक नियम नियंत्रित करता है, जिसमें लाइन की शुरुआत और अंत में वर्णों पर प्रतिबंध शामिल हैं।

ये नियम [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setWrapText) को प्रतिस्थापित नहीं करते, जो टेक्स्ट फ्रेम के भीतर स्वतः रैपिंग सक्षम करता है। वे रैप होने पर लेआउट को प्रभावित करते हैं; वे लाइन‑ब्रेक कैरेक्टर नहीं डालते। स्पष्ट लाइन‑ब्रेक पैराग्राफ़ के भीतर उपलब्ध चौड़ाई से स्वतंत्र नई लाइन बनाता है।

निम्न स्वनिर्भर उदाहरण एक संकीर्ण टेक्स्ट ब्लॉक बनाता है जिसमें चीनी और लैटिन टेक्स्ट दोनों होते हैं। यह दोनों लाइन‑ब्रेक विकल्पों को स्पष्ट रूप से सेट करता है और "line_breaking.pptx" सहेजता है। प्रत्येक नियम का प्रयोग करने के लिए, दूसरे सेटिंग को समान रखते हुए संबंधित मान बदलें। उदाहरण 24‑पॉइंट Arial और SimSun, 160‑पॉइंट फ्रेम चौड़ाई और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन का उपयोग करता है। [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) को [TextAutofitType.None_](https://reference.aspose.com/slides/python-java/aspose.slides/textautofittype/) के साथ कॉल किया जाता है ताकि टेक्स्ट आकार और फ्रेम आयाम स्थिर रहें।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 160, 300)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("中文排版测试，PowerPoint 中文演示。")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    east_asian_font = FontData("SimSun")
    paragraph_format.getDefaultPortionFormat().setEastAsianFont(east_asian_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setLatinLineBreak(NullableBool.False_)
    paragraph_format.setEastAsianLineBreak(NullableBool.True_)

    presentation.save("line_breaking.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **हैंगिंग विराम चिह्न नियंत्रित करें**

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) पात्रता वाले विराम चिह्नों को टेक्स्ट लाइन के दाईं सीमा से बाहर तक विस्तार करने की अनुमति देता है, बजाय अगले लाइन में स्थान लेने के। यह पूरे पैराग्राफ़ पर लागू होता है और हेंगिंग इन्डेंट से अलग है।

निम्न स्वनिर्भर उदाहरण 100‑पॉइंट‑चौड़े टेक्स्ट फ्रेम में हैंगिंग विराम चिह्न सक्षम करता है और "hanging_punctuation.pptx" सहेजता है। 24‑पॉइंट Arial और शून्य क्षैतिज टेक्स्ट‑फ़्रेम मार्जिन के साथ, अंतिम बिंदु "sentence" के बाद रहता है और दाएँ टेक्स्ट किनारे से बाहर तक विस्तारित होता है। तुलना के लिए प्रॉपर्टी को [NullableBool.False_](https://reference.aspose.com/slides/python-java/aspose.slides/nullablebool/) पर सेट करें: इन सेटिंग्स के साथ बिंदु अलग लाइन में स्थित होता है। रैपिंग सक्षम है और ऑटॉफिट निष्क्रिय है ताकि उपलब्ध चौड़ाई स्थिर रहे।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, NullableBool, Presentation, SaveFormat, ShapeType, TextAlignment, TextAutofitType
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 100, 200)
    shape.getFillFormat().setFillType(FillType.NoFill)

    text_frame = shape.getTextFrame()
    text_frame.getTextFrameFormat().setWrapText(NullableBool.True_)
    text_frame.getTextFrameFormat().setAutofitType(TextAutofitType.None_)
    text_frame.getTextFrameFormat().setMarginLeft(0)
    text_frame.getTextFrameFormat().setMarginRight(0)

    paragraph = text_frame.getParagraphs().get_Item(0)
    paragraph.setText("Simple text, next sentence.")

    paragraph_format = paragraph.getParagraphFormat()
    paragraph_format.setAlignment(TextAlignment.Left)
    paragraph_format.getDefaultPortionFormat().setFontHeight(24)
    latin_font = FontData("Arial")
    paragraph_format.getDefaultPortionFormat().setLatinFont(latin_font)
    paragraph_format.getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph_format.getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    paragraph_format.setHangingPunctuation(NullableBool.True_)

    presentation.save("hanging_punctuation.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

हर विराम चिह्न हैंग नहीं कर सकता। ऊपर वर्णित [फ़ॉन्ट और लेआउट शर्तें](#control-line-breaking) भी इस तुलना पर लागू होती हैं: फ़ॉन्ट, उपलब्ध चौड़ाई, मार्जिन या ऑटॉफिट सेटिंग्स बदलने से दृश्य अंतर हट सकता है।

## **टेक्स्ट फ्रेम के लिए ऑटॉफिट प्रकार सेट करें**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAutofitType) निर्धारित करता है कि टेक्स्ट कंटेनर की सीमा से अधिक होने पर कैसे व्यवहार करता है। इसे उपयोग करके आप निर्धारित कर सकते हैं कि टेक्स्ट छोटा हो, ओवरफ़्लो करे, या आकार को स्वतः री‑साइज़ करे। निम्न उदाहरण आकार को उसके टेक्स्ट के अनुसार री‑साइज़ करता है और परिणाम "autofit_type.pptx" में सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAutofitType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAutofitType(TextAutofitType.Shape)

    presentation.save("autofit_type.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

स्वतः रैपिंग के बाद लाइनों की संख्या गिनने और टेक्स्ट या आकार की चौड़ाई में बदलाव से परिणाम कैसे बदलता है, देखिए [Count Rendered Lines](/slides/hi/python-java/manage-paragraph/)। केवल लाइनों की गिनती यह संकेत नहीं देती कि टेक्स्ट कंटेनर से बाहर निकल रहा है या नहीं।

## **टेक्स्ट फ्रेम का एंकर सेट करें**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#setAnchoringType) आकार के भीतर टेक्स्ट को लंबवत रूप से कैसे स्थित किया जाए, यह निर्धारित करता है, उदाहरण के लिए शीर्ष, मध्य या नीचे। निम्न उदाहरण टेक्स्ट को पहले आकार के नीचे एंकर करता है और परिणाम "text_anchor.pptx" में सहेजता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TextAnchorType

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    auto_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Bottom)

    presentation.save("text_anchor.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **टेक्स्ट टैबुलेशन सेट करें**

पैराग्राफ़ में टैब स्टॉप कॉन्फ़िगर करने हेतु [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) और [ParagraphFormat.getTabs](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getTabs) का उपयोग करें। निम्न उदाहरण डिफ़ॉल्ट टैब अंतराल को 100 पॉइंट पर सेट करता है और 30 पॉइंट पर बाएँ‑संरेखित टैब स्टॉप जोड़ता है। ये सेटिंग्स टैब कैरेक्टर वाले टेक्स्ट को प्रभावित करती हैं।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TabAlignment

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().setDefaultTabSize(100)
    paragraph.getParagraphFormat().getTabs().add(30, TabAlignment.Left)

    presentation.save("paragraph_tabs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![पैराग्राफ़ टैब्स](paragraph_tabs.png)

## **प्रूफ़िंग भाषा सेट करें**

Aspose.Slides [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setLanguageId) प्रदान करता है, जिससे आप टेक्स्ट हिस्से के लिए प्रूफ़िंग भाषा सेट कर सकते हैं। प्रूफ़िंग भाषा PowerPoint में वर्तनी और व्याकरण जाँच के लिए उपयोग की जाने वाली भाषा निर्धारित करती है।

निम्न उदाहरण के लिए "presentation.pptx" चाहिए, जिसमें पहली स्लाइड पर टेक्स्ट बॉक्स पहला आकार है और कम से कम एक पैराग्राफ़ है। यह पहले पैराग्राफ़ की सामग्री को "1。" से बदलता है, फ़ॉन्ट को SimSun सेट करता है, और प्रमाणीकृत चीनी प्रूफ़िंग भाषा (`zh-CN`) असाइन करता है। परिणाम "proofing_language.pptx" में सहेजा जाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, Portion, Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)

    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getPortions().clear()

    font = FontData("SimSun")

    text_portion = Portion()
    text_portion.getPortionFormat().setComplexScriptFont(font)
    text_portion.getPortionFormat().setEastAsianFont(font)
    text_portion.getPortionFormat().setLatinFont(font)

    # प्रूफ़िंग भाषा की Id सेट करें.
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **डिफ़ॉल्ट भाषा सेट करें**

[LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) का उपयोग करके प्रस्तुति लोड या बनाते समय बनाए गए टेक्स्ट की डिफ़ॉल्ट भाषा निर्धारित की जा सकती है। निम्न उदाहरण US English को डिफ़ॉल्ट टेक्स्ट भाषा के रूप में सेट करता है, एक टेक्स्ट बॉक्स जोड़ता है, और उसके पहले टेक्स्ट हिस्से के लिए `en-US` प्रिंट करता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, ShapeType

load_options = LoadOptions()
load_options.setDefaultTextLanguage("en-US")

presentation = Presentation(load_options)
try:
    slide = presentation.getSlides().get_Item(0)

    # टेक्स्ट के साथ एक आयत आकार जोड़ें.
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # पहले हिस्से की भाषा जांचें.
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **डिफ़ॉल्ट टेक्स्ट स्टाइल सेट करें**

प्रस्तुति स्तर पर डिफ़ॉल्ट टेक्स्ट फ़ॉर्मेटिंग लागू करने के लिए [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getDefaultTextStyle) का उपयोग करें।

निम्न उदाहरण नई प्रस्तुति में टॉप‑लेवल पैराग्राफ़ के लिए 14‑पॉइंट बोल्ड फ़ॉन्ट को डिफ़ॉल्ट सेट करता है और इसे "default_text_style.pptx" में सहेजता है। टेक्स्ट इन डिफ़ॉल्ट्स को विरासत में ले सकता है जब तक कि अधिक विशिष्ट फ़ॉर्मेटिंग उन्हें ओवरराइड न करे।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # शीर्ष स्तर पैराग्राफ़ फॉर्मेट प्राप्त करें.
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ऑल‑कैप्स इफ़ेक्ट के साथ टेक्स्ट निकालें**

PowerPoint में **All Caps** फ़ॉन्ट इफ़ेक्ट लागू करने से टेक्स्ट स्लाइड पर बड़े अक्षरों में दिखता है, भले ही वह शुरू में छोटे अक्षरों में टाइप किया गया हो। Aspose.Slides के साथ ऐसे टेक्स्ट हिस्से को प्राप्त करने पर लाइब्रेरी वही टेक्स्ट लौटाती है जो दर्ज किया गया था। प्रदर्शित टेक्स्ट से मेल खाने के लिए, [TextCapType](https://reference.aspose.com/slides/python-java/aspose.slides/textcaptype/) की जाँच करें और जब मूल्य `All` हो तो लौटाए गए स्ट्रिंग को अपरकेस में परिवर्तित करें।

इस उदाहरण के लिए "sample2.pptx" चाहिए, जिसमें पहली स्लाइड पर टेक्स्ट बॉक्स पहला आकार है। इसके पहले पैराग्राफ़ के पहले हिस्से में "Hello, Aspose!" All Caps इफ़ेक्ट के साथ है, जैसा कि नीचे दिखाया गया है।

![All Caps इफ़ेक्ट](all_caps_effect.png)

निम्न कोड उदाहरण दिखाता है कि **All Caps** इफ़ेक्ट लागू होने के साथ टेक्स्ट को कैसे निकालें:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, TextCapType

presentation = Presentation("sample2.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    
    auto_shape = slide.getShapes().get_Item(0)
    text_portion = auto_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)

    print("Original text: " + str(text_portion.getText()))

    text_format = text_portion.getPortionFormat().getEffective()
    if text_format.getTextCapType() == TextCapType.All:
        text = str(text_portion.getText()).upper()
        print("All-Caps effect: " + text)
finally:
    presentation.dispose()
```

आउटपुट:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं स्लाइड पर तालिका में टेक्स्ट को कैसे बदलूँ?**

स्लाइड पर तालिका में टेक्स्ट बदलने के लिए [Table](https://reference.aspose.com/slides/python-java/aspose.slides/table/) का उपयोग करें। कोशिकाओं के माध्यम से iterate करें और प्रत्येक कोशिका को [Cell.getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) और पैराग्राफ फ़ॉर्मेट को [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/python-java/aspose.slides/paragraph/#getParagraphFormat) के माध्यम से अपडेट करें।

**मैं PowerPoint स्लाइड पर टेक्स्ट को ग्रेडिएंट रंग कैसे लागू करूँ?**

टेक्स्ट पर ग्रेडिएंट रंग लागू करने के लिए [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#getFillFormat) का उपयोग करें। [FillFormat.setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType) को [FillType.Gradient](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा, तथा पारदर्शिता को कॉन्फ़िगर करें।