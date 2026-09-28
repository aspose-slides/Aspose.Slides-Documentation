---
title: Python via Java में प्रस्तुति टेक्स्ट का फ़ॉर्मेट
linktitle: टेक्स्ट फ़ॉर्मेटिंग
type: docs
weight: 50
url: /hi/python-java/text-formatting/
keywords:
- पैराग्राफ संरेखित
- टेक्स्ट शैली
- टेक्स्ट पृष्ठभूमि
- टेक्स्ट पारदर्शिता
- कैरेक्टर अंतराल
- फ़ॉन्ट गुण
- फ़ॉन्ट परिवार
- टेक्स्ट घुमाव
- घुमाव कोण
- टेक्स्ट फ्रेम
- लाइन स्पेसिंग
- ऑटॉफिट गुण
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
## **सारांश**

यह लेख दिखाता है कि Aspose.Slides for Python via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में पाठ को कैसे स्वरूपित करें। यह पृष्ठभूमि रंग, पारदर्शिता, अक्षर अंतराल, फ़ॉन्ट गुण, घुमाव, पैराग्राफ अंतराल, ऑटॉफिट व्यवहार, पाठ एंकरिंग, टैब स्टॉप, और भाषा सेटिंग्स को कवर करता है।

जब तक अन्यथा उल्लेख न किया गया हो, उदाहरण [ sample.pptx ](sample.pptx) का उपयोग करते हैं। उसकी पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है, और उसका पहला पैराग्राफ नीचे दिखाए गए पाठ को सम्मिलित करता है। स्लाइड और आकार दोनों का सूचक शून्य‑आधारित है। बोल्ड भागों का चयन करने वाले उदाहरण प्रभावी स्वरूपण का उपयोग करते हैं, जिसमें विरासत में मिला हुआ बोल्ड स्वरूपण भी शामिल है:

![उदाहरण पाठ](sample_text.png)

शाब्दिक पाठ या नियमित अभिव्यक्ति मिलानों को खोजने और हाइलाइट करने के लिए, देखें [Search and Replace Text](/slides/hi/python-java/search-and-replace-text/)।

## **पाठ पृष्ठभूमि रंग सेट करें**

डिफ़ॉल्ट हाइलाइट रंग निर्धारित करने के लिए [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) का उपयोग करें, या व्यक्तिगत पाठ भागों के लिए [BasePortionFormat.getHighlightColor](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#getHighlightColor) का उपयोग करें।

निम्न उदाहरण पहले पैराग्राफ के लिए हल्का ग्रे हाइलाइट डिफ़ॉल्ट रूप से सेट करता है। व्यक्तिगत भागों पर स्पष्ट हाइलाइट रंग इस डिफ़ॉल्ट पर प्राथमिकता लेता है:

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

    # पूरे पैराग्राफ के लिए हाइलाइट रंग सेट करें।

    presentation.save("gray_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![ग्रे पैराग्राफ](gray_paragraph.png)

नीचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** के लिए पृष्ठभूमि रंग कैसे सेट करें, दिखाता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpile.startJVM()

from asposeslides.api import Presentation, SaveFormat
from java.awt import Color

presentation = Presentation("sample.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    auto_shape = slide.getShapes().get_Item(0)
    paragraph = auto_shape.getTextFrame().getParagraphs().get_Item(0)

    for portion in paragraph.getPortions():
        if portion.getPortionFormat().getEffective().getFontBold():
            # टेक्स्ट भाग के लिए हाइलाइट रंग सेट करें।
            portion.getPortionFormat().getHighlightColor().setColor(Color.LIGHT_GRAY)

    presentation.save("gray_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![ग्रे टेक्स्ट भाग](gray_text_portions.png)

## **पाठ पैराग्राफ संरेखित करें**

पाठ फ़्रेम के भीतर पैराग्राफ संरेखण निर्धारित करने के लिए [ParagraphFormat.setAlignment](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setAlignment) का प्रयोग करें। मान में centered, left‑aligned, right‑aligned, justified आदि शामिल हो सकते हैं।

निम्न कोड उदाहरण पैराग्राफ को **केंद्र** में संरेखित करने का तरीका दिखाता है:

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

    # पैराग्राफ का संरेखण केंद्र में सेट करें।
    paragraph.getParagraphFormat().setAlignment(TextAlignment.Center)

    presentation.save("aligned_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![संरेखित पैराग्राफ](aligned_paragraph.png)

## **पाठ के लिए पारदर्शिता सेट करें**

पाठ पारदर्शिता [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#getFillFormat) को असाइन किए गए रंग के अल्फा घटक के माध्यम से नियंत्रित की जाती है। नीचे के उदाहरणों में `alpha = 50` 0‑255 स्केल पर एक ARGB अल्फा‑चैनल मान है, न कि पारदर्शिता प्रतिशत।

निम्न कोड उदाहरण **पूरे पैराग्राफ** पर पारदर्शिता लागू करना दिखाता है:

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

    # पाठ के भराव रंग को पारदर्शी रंग पर सेट करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![पारदर्शी पैराग्राफ](transparent_paragraph.png)

निम्न कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** पर पारदर्शिता लागू करना दिखाता है:

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
            # टेक्स्ट भाग की पारदर्शिता सेट करें।
            portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
            portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(text_color)

    presentation.save("transparent_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![पारदर्शी टेक्स्ट भाग](transparent_text_portions.png)

## **पाठ के लिए अक्षर अंतराल सेट करें**

पाठ बॉक्स में अक्षरों के बीच अंतराल को विस्तारित या संकुचित करने के लिए [BasePortionFormat.setSpacing](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setSpacing) का उपयोग करें। नीचे के उदाहरण 3 पॉइंट अंतराल जोड़ते हैं; नकारात्मक मान पाठ को संकुचित करेंगे।

निम्न पायथन कोड **पूरे पैराग्राफ** में अक्षर अंतराल विस्तारित करने का तरीका दिखाता है:

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

    # ध्यात रखें: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मान उपयोग करें।
    paragraph.getParagraphFormat().getDefaultPortionFormat().setSpacing(3) # अक्षर अंतराल बढ़ाएँ।

    presentation.save("character_spacing_in_paragraph.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![पैराग्राफ में अक्षर अंतराल](character_spacing_in_paragraph.png)

नीचे दिया गया कोड उदाहरण **बोल्ड फ़ॉन्ट वाले टेक्स्ट भागों** में अक्षर अंतराल विस्तारित करने का तरीका दिखाता है:

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
            # ध्यान दें: अक्षर अंतराल को संकुचित करने के लिए नकारात्मक मान उपयोग करें।
            portion.getPortionFormat().setSpacing(3) # अक्षर अंतराल बढ़ाएँ।

    presentation.save("character_spacing_in_text_portions.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

परिणाम:

![टेक्स्ट भागों में अक्षर अंतराल](character_spacing_in_text_portions.png)

### **विशिष्ट फ़ॉन्ट्स के लिए केरनिंग अक्षम करें**

कुछ मामलों में, Aspose.Slides द्वारा रेंडर किया गया पाठ PowerPoint में दिखने वाले पाठ से थोड़ा अधिक घना लग सकता है। यह इसलिए हो सकता है क्योंकि PowerPoint विशिष्ट फ़ॉन्ट्स के लिए केरनिंग डेटा को अनदेखा कर सकता है, भले ही फ़ॉन्ट में वैध केरनिंग जानकारी हो और PowerPoint सेटिंग्स में केरनिंग सक्रिय हो।

ऐसे मामलों में रेंडर आउटपुट को PowerPoint के करीब लाने के लिए, आप उन फ़ॉन्ट्स का उपयोग करने वाले टेक्स्ट भागों के लिए केरनिंग को अक्षम कर सकते हैं। [BasePortionFormat.setKerningMinimalSize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setKerningMinimalSize) को वास्तविक फ़ॉन्ट आकार से बड़ा मान सेट करें। यह उदाहरण "presentation.pptx" को आवश्यक मानता है, जिसमें पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है। यह प्रभावी फ़ॉन्ट नामों, जिसमें विरासत में मिले फ़ॉन्ट भी शामिल हैं, को जाँचता है और Roboto फ़ॉन्ट का उपयोग करने वाले भागों के लिए 100‑पॉइंट सीमा सेट करता है। यह 100 पॉइंट से छोटे फ़ॉन्ट आकार वाले मेल खाने वाले भागों के लिए केरनिंग अक्षम करता है:

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

सीमा से नीचे के मेल खाने वाले पाठ के लिए यह सेटिंग केरनिंग को रोकती है और उन फ़ॉन्ट्स के लिए Aspose.Slides रेंडरिंग को PowerPoint के दृश्य आउटपुट के साथ बेहतर मिलान करने में मदद कर सकती है।

## **पाठ फ़ॉन्ट गुण प्रबंधित करें**

फ़ॉन्ट गुण को पैराग्राफ स्तर पर [ParagraphFormat.getDefaultPortionFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) या व्यक्तिगत भागों पर [PortionFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/portionformat/) के द्वारा सेट किया जा सकता है।

निम्न उदाहरण पहले पैराग्राफ की डिफ़ॉल्ट फ़ॉन्ट को 12‑पॉइंट Times New Roman, बोल्ड, इटैलिक और डॉटेड अंडरलाइन के साथ सेट करता है। व्यक्तिगत भागों पर स्पष्ट स्वरूपण इन डिफ़ॉल्ट्स पर प्राथमिकता लेता है:

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

    # पैराग्राफ के लिए फ़ॉन्ट गुण सेट करें।
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

![पैराग्राफ के लिए फ़ॉन्ट गुण](font_properties_for_paragraph.png)

निम्न उदाहरण उन भागों पर 13‑पॉइंट Times New Roman, इटैलिक और डॉटेड अंडरलाइन लागू करता है जिनके प्रभावी स्वरूपण में बोल्ड शामिल है:

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
            # टेक्स्ट भाग के लिए फ़ॉन्ट गुण सेट करें।
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

![टेक्स्ट भागों के लिए फ़ॉन्ट गुण](font_properties_for_text_portions.png)

## **पाठ रोटेशन सेट करें**

शेप के भीतर पूर्वनिर्धारित पाठ दिशा निर्धारित करने के लिए [TextFrameFormat.setTextVerticalType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#setTextVerticalType) का उपयोग करें।

निम्न कोड उदाहरण शेप में पाठ दिशा को [TextVerticalType.Vertical270](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textverticaltype/) पर सेट करता है, जिससे पाठ **90 डिग्री घड़ी की विपरीत दिशा में** घुम जाता है:

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

![पाठ रोटेशन](text_rotation.png)

## **टेक्स्ट फ्रेम के लिए कस्टम रोटेशन सेट करें**

एक [TextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframe/) के लिए कस्टम रोटेशन एंगल सेट करने के लिए [TextFrameFormat.setRotationAngle](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#setRotationAngle) का उपयोग करें।

निम्न कोड उदाहरण शेप के भीतर टेक्स्ट फ्रेम को 3 डिग्री clockwise घुमाता है:

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

![कस्टम टेक्स्ट रोटेशन](custom_text_rotation.png)

## **पैराग्राफ की लाइन स्पेसिंग सेट करें**

Aspose.Slides [ParagraphFormat.setSpaceAfter](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat.setSpaceBefore](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setSpaceBefore), और [ParagraphFormat.setSpaceWithin](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setSpaceWithin) के माध्यम से पैराग्राफ स्पेसिंग को नियंत्रित करता है। इन गुणों का प्रयोग इस प्रकार किया जाता है:

* लाइन स्पेसिंग को लाइन ऊँचाई के प्रतिशत के रूप में निर्दिष्ट करने के लिए सकारात्मक मान उपयोग करें।
* लाइन स्पेसिंग को पॉइंट में निर्दिष्ट करने के लिए नकारात्मक मान उपयोग करें।

निम्न उदाहरण पहला पैराग्राफ के भीतर स्पेसिंग को लाइन ऊँचाई के 200 % (डबल स्पेसिंग) पर सेट करता है:

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

![पैराग्राफ के भीतर लाइन स्पेसिंग](line_spacing.png)

## **लाइन ब्रेकिंग नियंत्रित करें**

पैराग्राफ लाइन‑ब्रेकिंग नियम संकुचित टेक्स्ट ब्लॉक और लैटिन एवं ईस्ट एशियन टेक्स्ट मिश्रित प्रस्तुतियों में उपयोगी होते हैं। नीचे के मेथड [ParagraphFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/) से संबंधित हैं, इसलिए वे पूरे पैराग्राफ पर लागू होते हैं:

- [setLatinLineBreak](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setLatinLineBreak) लैटिन लाइन‑ब्रेकिंग नियमों को नियंत्रित करता है। मिश्रित टेक्स्ट में इसे बदलने से पड़ोसी ईस्ट एशियन टेक्स्ट और विराम चिह्नों की रैपिंग भी बदल सकती है।
- [setEastAsianLineBreak](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) ईस्ट एशियन लाइन‑ब्रेकिंग नियमों को नियंत्रित करता है, जिसमें लाइन की शुरुआत और अंत में वर्ण प्रतिबन्ध शामिल हैं।

ये नियम [TextFrameFormat.setWrapText](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#setWrapText) को प्रतिस्थापित नहीं करते, जो टेक्स्ट फ्रेम के भीतर स्वतः रैपिंग सक्षम करता है। ये रैपिंग होने पर लेआउट को प्रभावित करते हैं; वे लाइन‑ब्रेक कैरेक्टर डालते नहीं हैं। एक स्पष्ट लाइन‑ब्रेक पैराग्राफ के भीतर नया लाइन बनाता है, उपलब्ध चौड़ाई से स्वतंत्र।

नीचे का स्वतंत्र उदाहरण एक संकीर्ण टेक्स्ट ब्लॉक बनाता है जिसमें चीनी और लैटिन टेक्स्ट दोनों हैं। यह दोनों लाइन‑ब्रेक विकल्पों को स्पष्ट रूप से सेट करता है और “line_breaking.pptx” सहेजता है। किसी भी नियम को आज़माने के लिए, दूसरी सेटिंग को स्थिर रखते हुए संबंधित मान बदलें। उदाहरण 24‑पॉइंट Arial और SimSun, 160‑पॉइंट फ्रेम चौड़ाई और शून्य क्षैतिज मार्जिन के साथ उपयोग करता है। [TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#setAutofitType) को [TextAutofitType.None_](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textautofittype/) से कॉल किया गया है ताकि टेक्स्ट आकार और फ्रेम आयाम स्थिर रहें।

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

[ParagraphFormat.setHangingPunctuation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setHangingPunctuation) पात्रों को टेक्स्ट लाइन के दाएँ किनारे से आगे तक विस्तारित होने की अनुमति देता है, बजाय अगले लाइन में जाने के। यह पूरे पैराग्राफ पर लागू होता है और हेंगिंग इंडेंट से अलग है।

नीचे का स्वतंत्र उदाहरण 100‑पॉइंट‑चौड़े टेक्स्ट फ्रेम में हैंगिंग विराम चिह्न सक्षम करता है और “hanging_punctuation.pptx” सहेजता है। 24‑पॉइंट Arial और शून्य क्षैतिज मार्जिन के साथ, अंतिम पीरियड “sentence” के बाद रहता है और दाएँ टेक्स्ट किनारे से बाहर तक विस्तारित होता है। तुलना के लिए संपत्ति को [NullableBool.False_](https://reference.aspose.com/slides/hi/python-java/aspose.slides/nullablebool/) पर सेट करें: इन सेटिंग्स के साथ, पीरियड अलग लाइन पर रहता है। रैपिंग सक्षम है और ऑटॉफिट अक्षम है ताकि उपलब्ध चौड़ाई स्थिर रहे।

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

हर विराम chinh सभी हैंग नहीं कर सकता। दिखाया गया परिणाम फ़ॉन्ट उपलब्धता और लेआउट पर निर्भर करता है: फ़ॉन्ट, उपलब्ध चौड़ाई, मार्जिन या ऑटॉफिट सेटिंग बदलने से दृश्यमान अंतर हट सकता है।

## **टेक्स्ट फ्रेम के लिए ऑटॉफिट प्रकार सेट करें**

[TextFrameFormat.setAutofitType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#setAutofitType) निर्धारित करता है कि जब टेक्स्ट अपने कंटेनर की सीमा से बाहर हो तो वह कैसे व्यवहार करे। इसका उपयोग करके आप टेक्स्ट को सिकुड़ने, अतिरक्त होने, या शैप को स्वचालित रूप से आकार बदलने को नियंत्रित कर सकते हैं। नीचे का उदाहरण शैप को उसके टेक्स्ट के अनुसार आकार बदलने के लिए कॉन्फ़िगर करता है और परिणाम “autofit_type.pptx” में सहेजता है।

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

स्वचालित रैपिंग के बाद लाइनों की गणना करने और यह देखने के लिए कि टेक्स्ट या शैप की चौड़ाई परिणाम को कैसे बदलती है, देखें [Count Rendered Lines](/slides/hi/python-java/manage-paragraph/)। केवल लाइन गणना यह नहीं दर्शाती कि टेक्स्ट कंटेनर से बाहर है या नहीं।

## **टेक्स्ट फ्रेम एंकर सेट करें**

[TextFrameFormat.setAnchoringType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textframeformat/#setAnchoringType) शेप के भीतर टेक्स्ट को ऊर्ध्वाधर रूप से कैसे स्थित किया जाए, जैसे शीर्ष, मध्य या निचले भाग पर, को परिभाषित करता है। नीचे का उदाहरण टेक्स्ट को पहली शेप के निचले भाग में एंकर करता है और “text_anchor.pptx” में सहेजता है।

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

पैराग्राफ में टैब स्टॉप कॉन्फ़िगर करने के लिए [ParagraphFormat.setDefaultTabSize](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#setDefaultTabSize) और [ParagraphFormat.getTabs](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraphformat/#getTabs) का उपयोग करें। नीचे का उदाहरण डिफ़ॉल्ट टैब अंतराल को 100 पॉइंट पर सेट करता है और 30 पॉइंट पर बाएँ‑साइडेड टैब स्टॉप जोड़ता है। ये सेटिंग्स टैब कैरेक्टर वाले टेक्स्ट को प्रभावित करती हैं।

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

![पैराग्राफ टैब्स](paragraph_tabs.png)

## **प्रूफ़िंग भाषा सेट करें**

Aspose.Slides [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#setLanguageId) के माध्यम से टेक्स्ट भाग के लिए प्रूफ़िंग भाषा सेट करने की सुविधा देता है। प्रूफ़िंग भाषा निर्धारित करती है कि PowerPoint में वर्तनी और व्याकरण जाँच के लिए कौन सी भाषा उपयोग की जाएगी।

नीचे का उदाहरण “presentation.pptx” को आवश्यक मानता है, जिसमें पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है और कम से कम एक पैराग्राफ है। यह पहले पैराग्राफ की सामग्री को “1。” से बदलता है, फ़ॉन्ट को SimSun सेट करता है, और प्रूफ़िंग भाषा को Simplified Chinese (`zh-CN`) असाइन करता है। परिणाम “proofing_language.pptx” में सहेजा जाता है:

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

    # प्रूफ़िंग भाषा का Id सेट करें।
    text_portion.getPortionFormat().setLanguageId("zh-CN")

    text_portion.setText("1。")
    paragraph.getPortions().add(text_portion)

    presentation.save("proofing_language.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **डिफ़ॉल्ट भाषा सेट करें**

पावरपॉइंट लोड या निर्माण के दौरान बनाए जा रहे टेक्स्ट के लिए डिफ़ॉल्ट भाषा निर्धारित करने हेतु [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/hi/python-java/aspose.slides/loadoptions/#setDefaultTextLanguage) का उपयोग करें। नीचे का उदाहरण US English को डिफ़ॉल्ट टेक्स्ट भाषा के रूप में सेट करता है, एक टेक्स्ट बॉक्स जोड़ता है, और उसके पहले टेक्स्ट भाग के लिए `en-US` प्रिंट करता है।

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

    # आयत आकार को टेक्स्ट के साथ जोड़ें।
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 50)
    shape.getTextFrame().setText("Sample text")

    # पहले भाग की भाषा जाँचें।
    portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    print(portion.getPortionFormat().getLanguageId())
finally:
    presentation.dispose()
```

## **डिफ़ॉल्ट टेक्स्ट स्टाइल सेट करें**

प्रेजेंटेशन स्तर पर डिफ़ॉल्ट टेक्स्ट फ़ॉर्मेटिंग लागू करने के लिए [Presentation.getDefaultTextStyle](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/#getDefaultTextStyle) का उपयोग करें।

नीचे का उदाहरण नई प्रेजेंटेशन में शीर्ष‑स्तर पैराग्राफ के लिए 14‑पॉइंट बोल्ड फ़ॉन्ट को डिफ़ॉल्ट के रूप में सेट करता है और “default_text_style.pptx” में सहेजता है। टेक्स्ट इन डिफ़ॉल्ट्स को विरासत में ले सकता है, जब तक कि अधिक विशिष्ट फ़ॉर्मेटिंग उन्हें ओवरराइड न करे।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat

presentation = Presentation()
try:
    # शीर्ष स्तर पैराग्राफ फ़ॉर्मेट प्राप्त करें।
    paragraph_format = presentation.getDefaultTextStyle().getLevel(0)

    if paragraph_format is not None:
        paragraph_format.getDefaultPortionFormat().setFontHeight(14)
        paragraph_format.getDefaultPortionFormat().setFontBold(NullableBool.True_)

    presentation.save("default_text_style.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **ऑल‑कैप्स इफ़ेक्ट के साथ टेक्स्ट निकालें**

PowerPoint में **All Caps** फ़ॉन्ट इफ़ेक्ट लागू करने से स्लाइड पर पाठ सभी बड़े अक्षरों में दिखता है, भले ही वह मूल रूप से छोटे अक्षरों में टाइप किया गया हो। जब आप Aspose.Slides के साथ ऐसा टेक्स्ट भाग प्राप्त करते हैं, तो लाइब्रेरी टेक्स्ट को ठीक उसी रूप में लौटाती है जैसा वह दर्ज किया गया था। प्रदर्शित टेक्स्ट से मेल खाने के लिए, [TextCapType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/textcaptype/) को देखें और जब मान `All` हो तो लौटाए गए स्ट्रिंग को अपरकेस में बदलें।

यह उदाहरण “sample2.pptx” को आवश्यक मानता है, जिसमें पहली स्लाइड पर पहला आकार एक टेक्स्ट बॉक्स है। इसके पहले पैराग्राफ का पहला भाग “Hello, Aspose!” को ऑल‑कैप्स इफ़ेक्ट के साथ रखता है, जैसा कि नीचे दिखाया गया है।

![ऑल कैप्स इफ़ेक्ट](all_caps_effect.png)

नीचे का कोड उदाहरण **ऑल‑कैप्स** इफ़ेक्ट लागू होने पर टेक्स्ट को निकालने का तरीका दिखाता है:

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

**मैं स्लाइड पर तालिका में पाठ को कैसे संशोधित करूँ?**

स्लाइड पर तालिका में पाठ को संशोधित करने के लिए [Table](https://reference.aspose.com/slides/hi/python-java/aspose.slides/table/) का प्रयोग करें। कोशिकाओं के माध्यम से इटरिएट करें और प्रत्येक कोशिका को [Cell.getTextFrame](https://reference.aspose.com/slides/hi/python-java/aspose.slides/cell/#getTextFrame) और पैराग्राफ फ़ॉर्मेटिंग को [Paragraph.getParagraphFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/paragraph/#getParagraphFormat) से अपडेट करें।

**मैं PowerPoint स्लाइड पर पाठ पर ग्रेडिएंट रंग कैसे लागू करूँ?**

पाठ पर ग्रेडिएंट रंग लागू करने के लिए [BasePortionFormat.getFillFormat](https://reference.aspose.com/slides/hi/python-java/aspose.slides/baseportionformat/#getFillFormat) का उपयोग करें। [FillFormat.setFillType](https://reference.aspose.com/slides/hi/python-java/aspose.slides/fillformat/#setFillType) को [FillType.Gradient](https://reference.aspose.com/slides/hi/python-java/aspose.slides/filltype/) पर सेट करें और ग्रेडिएंट स्टॉप, दिशा, तथा पारदर्शिता को कॉन्फ़िगर करें।