---
title: मास्टर स्लाइड
type: docs
weight: 30
url: /hi/python-java/examples/elements/master-slide/
keywords:
- कोड उदाहरण
- मास्टर स्लाइड
- मास्टर स्लाइड जोड़ें
- मास्टर स्लाइड तक पहुँचें
- मास्टर स्लाइड हटाएँ
- अप्रयुक्त मास्टर स्लाइड
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ मास्टर स्लाइड्स प्रबंधित करें: PowerPoint और OpenDocument प्रस्तुतियों में मास्टर बनाएं, पहुँचें, हटाएँ और साफ‑सफ़ाई करें।"
---
Master slides PowerPoint में स्लाइड इनहेरिटेंस हाइरार्की के शीर्ष स्तर बनाते हैं। एक **master slide** पृष्ठभूमि, लोगो, और टेक्स्ट फॉर्मेटिंग जैसे सामान्य डिजाइन तत्वों को परिभाषित करता है। **Layout slides** master slides से वंशागत होते हैं, और **normal slides** layout slides से वंशागत होते हैं।

यह लेख **Aspose.Slides for Python via Java** का उपयोग करके master slides को बनाने, संशोधित करने और प्रबंधित करने का प्रदर्शन करता है।

पैकेज को [Installation](/slides/hi/python-java/installation/) में वर्णित अनुसार स्थापित करें। प्रत्येक उदाहरण JVM शुरू करने से पहले `asposeslides` को इम्पोर्ट करता है, और JVM चलने के बाद API को इम्पोर्ट करता है।

## **Add a Master Slide**

यह उदाहरण डिफ़ॉल्ट master slide को क्लोन करके एक नया master slide बनाने का तरीका दिखाता है। फिर यह लेआउट इनहेरिटेंस के माध्यम से सभी स्लाइड्स में कंपनी नाम बैनर जोड़ता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, ShapeType
from java.awt import Color

presentation = Presentation()
try:
    # डिफ़ॉल्ट मास्टर स्लाइड को क्लोन करें।
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    # मास्टर स्लाइड के शीर्ष पर कंपनी नाम के साथ एक बैनर जोड़ें।
    text_box = new_master_slide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 720, 25)
    text_box.getTextFrame().setText("Company Name")
    paragraph = text_box.getTextFrame().getParagraphs().get_Item(0)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid)
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)
    text_box.getFillFormat().setFillType(FillType.NoFill)

    # नए मास्टर स्लाइड को लेआउट स्लाइड को असाइन करें।
    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)

    # लेआउट स्लाइड को प्रस्तुति की पहली स्लाइड को असाइन करें।
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Master slides सभी स्लाइड्स में लगातार ब्रांडिंग या साझा डिज़ाइन तत्व लागू करने का तरीका प्रदान करती हैं। master में किए गए बदलाव स्वचालित रूप से निर्भर लेआउट और normal स्लाइड्स में प्रतिबिंबित होते हैं।
{{% /alert %}}

{{% alert color="info" title="Note" %}}
master slide में जोड़े गए Shapes और फॉर्मेटिंग layout slides को विरासत में मिलते हैं और बदले में उन लेआउट्स का उपयोग करने वाली सभी normal स्लाइड्स को मिलते हैं। नीचे की छवि दिखाती है कि कैसे master slide में जोड़ा गया टेक्स्ट बॉक्स अंतिम स्लाइड पर स्वचालित रूप से रेंडर होता है।
{{% /alert %}}

![Master Inheritance Example](master-slide-banner.png)

## **Access a Master Slide**

आप प्रस्तुति के master collection के माध्यम से master slides तक पहुँच सकते हैं। यह उदाहरण पहला master slide प्राप्त करता है और उसकी background प्रकार को बदलता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, Presentation

presentation = Presentation()
try:
    first_master_slide = presentation.getMasters().get_Item(0)
    first_master_slide.getBackground().setType(BackgroundType.OwnBackground)
finally:
    presentation.dispose()
```

## **Remove a Master Slide**

एक master slide को इंडेक्स या रेफ़रेंस द्वारा हटाया जा सकता है जब वह अब उपयोग में नहीं हो। यह उदाहरण एक क्लोन किए गए master slide को प्रस्तुति में असाइन करता है और फिर मूल master को इंडेक्स द्वारा हटाता है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    new_master_slide = presentation.getMasters().addClone(default_master_slide)

    layout_slide = presentation.getLayoutSlides().get_Item(0)
    layout_slide.setMasterSlide(new_master_slide)
    presentation.getSlides().get_Item(0).setLayoutSlide(layout_slide)

    # इंडेक्स द्वारा अप्रयुक्त मूल मास्टर स्लाइड हटाएँ।
    presentation.getMasters().removeAt(0)

    # वैकल्पिक रूप से, संदर्भ द्वारा एक अप्रयुक्त मास्टर स्लाइड हटाएँ:
    # presentation.getMasters().remove(unused_master_slide)
finally:
    presentation.dispose()
```

## **Remove Unused Master Slides**

कुछ प्रस्तुतियों में ऐसे master slides होते हैं जो उपयोग में नहीं हैं। इन स्लाइड्स को हटाने से फ़ाइल आकार कम करने में मदद मिल सकती है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation()
try:
    default_master_slide = presentation.getMasters().get_Item(0)
    presentation.getMasters().addClone(default_master_slide)

    # सभी अप्रयुक्त मास्टर स्लाइड्स हटाएँ, जिसमें Preserve के रूप में चिह्नित स्लाइड्स भी शामिल हैं।
    presentation.getMasters().removeUnused(True)
finally:
    presentation.dispose()
```