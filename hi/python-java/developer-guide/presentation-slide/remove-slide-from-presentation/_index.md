---
title: Python में प्रस्तुतियों से स्लाइड्स हटाएँ
linktitle: स्लाइड हटाएँ
type: docs
weight: 30
url: /hi/python-java/remove-slide-from-presentation/
keywords:
- स्लाइड हटाएँ
- स्लाइड हटाना
- अप्रयुक्त स्लाइड हटाएँ
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via Java का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों से स्लाइड्स को आसानी से हटाएँ। स्पष्ट कोड उदाहरण प्राप्त करें और अपने कार्यप्रवाह को बढ़ाएँ।"
---
## **Introduction**

यदि कोई स्लाइड (या उसकी सामग्री) अनावश्यक हो जाए, तो आप इसे हटा सकते हैं। Aspose.Slides [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास प्रदान करता है जो [SlideCollection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/) को समाहित करता है, जो प्रस्तुति में सभी स्लाइड्स का भंडारण है। एक ज्ञात [Slide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slide/) ऑब्जेक्ट का संदर्भ या अनुक्रमणिका उपयोग करके, आप उस स्लाइड को निर्दिष्ट कर सकते हैं जिसे आप हटाना चाहते हैं। 

## **Remove a Slide by Reference**

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।  
1. वह स्लाइड जिसे आप हटाना चाहते हैं, उसके ID या अनुक्रमणिका के माध्यम से उसका संदर्भ प्राप्त करें।  
1. संदर्भित स्लाइड को प्रस्तुति से हटाएं।  
1. परिवर्तित प्रस्तुति को सहेजें।  

यह Python कोड दिखाता है कि कैसे संदर्भ के माध्यम से स्लाइड को हटाया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# एक Presentation ऑब्जेक्ट बनाएँ जो प्रस्तुतिकरण फ़ाइल का प्रतिनिधित्व करता है।
presentation = Presentation("demo.pptx")
try:
    # स्लाइड संग्रह में उसकी अनुक्रमणिका के माध्यम से एक स्लाइड एक्सेस करें।
    slide = presentation.getSlides().get_Item(0)

    # संदर्भ के माध्यम से स्लाइड हटाएँ।
    presentation.getSlides().remove(slide)

    # परिवर्तित प्रस्तुतिकरण को सहेजें।
    presentation.save("modified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Remove a Slide by Index**

1. [Presentation](https://reference.aspose.com/slides/hi/python-java/aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।  
1. स्लाइड को उसके अनुक्रमणिका स्थिति के माध्यम से प्रस्तुति से हटाएं।  
1. परिवर्तित प्रस्तुति को सहेजें।  

यह Python कोड दिखाता है कि कैसे स्लाइड को उसकी अनुक्रमणिका के माध्यम से हटाया जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# एक Presentation ऑब्जेक्ट बनाएँ जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
presentation = Presentation("demo.pptx")
try:
    # उसकी अनुक्रमणिका के माध्यम से एक स्लाइड हटाएँ।
    presentation.getSlides().removeAt(0)

    # परिवर्तित प्रस्तुति को सहेजें।
    presentation.save("modified.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Remove Unused Layout Slides**

Aspose.Slides [Compress](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compress/) क्लास की [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) मेथड प्रदान करता है जिससे आप अवांछित और अनउपयोगी लेआउट स्लाइड्स को हटा सकते हैं। यह Python कोड दिखाता है कि कैसे PowerPoint प्रस्तुति से लेआउट स्लाइड हटाई जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Remove Unused Master Slides**

Aspose.Slides [Compress](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compress/) क्लास की [removeUnusedMasterSlides](https://reference.aspose.com/slides/hi/python-java/aspose.slides/compress/#removeUnusedMasterSlides) मेथड प्रदान करता है जिससे आप अवांछित और अनउपयोगी मास्टर स्लाइड्स को हटा सकते हैं। यह Python कोड दिखाता है कि कैसे PowerPoint प्रस्तुति से मास्टर स्लाइड हटाई जाए:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    Compress.removeUnusedMasterSlides(presentation)

    presentation.save("pres-out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**What happens to slide indexes after I delete a slide?**

हटाने के बाद, [collection](https://reference.aspose.com/slides/hi/python-java/aspose.slides/slidecollection/) फिर से अनुक्रमणिका बनाता है: हर बाद की स्लाइड एक स्थान बाएँ सरकती है, इसलिए पहले के इंडेक्स नंबर अप्रचलित हो जाते हैं। यदि आपको स्थिर संदर्भ चाहिए, तो प्रत्येक स्लाइड की स्थायी ID का उपयोग करें, न कि उसका इंडेक्स।

**Is a slide’s ID different from its index, and does it change when neighboring slides are deleted?**

हाँ। इंडेक्स स्लाइड की स्थिति है और स्लाइड जोड़ने या हटाने पर बदलता है। स्लाइड की ID एक स्थायी पहचानकर्ता है और जब अन्य स्लाइड्स हटाई जाती हैं तो यह नहीं बदलती।

**How does deleting a slide affect slide sections?**

यदि स्लाइड किसी सेक्शन का भाग थी, तो वह सेक्शन केवल एक कम स्लाइड रखेगा। सेक्शन की संरचना बनी रहती है; यदि कोई सेक्शन खाली हो जाता है, तो आप आवश्यकता अनुसार [remove or reorganize sections](/slides/hi/python-java/slide-section/)।  

**What happens to notes and comments attached to a slide when it’s deleted?**

[Notes](/slides/hi/python-java/presentation-notes/) और [comments](/slides/hi/python-java/presentation-comments/) उस विशिष्ट स्लाइड से जुड़े होते हैं और वह स्लाइड हटते ही हट जाते हैं। अन्य स्लाइड्स की सामग्री अप्रभावित रहती है।

**How is deleting slides different from cleaning up unused layouts/masters?**

डिलीट करने से डेक से विशिष्ट सामान्य स्लाइड्स हटती हैं। अनउपयोगी लेआउट/मास्टर को साफ़ करने से उन लेआउट या मास्टर स्लाइड्स को हटाया जाता है जिनका कोई संदर्भ नहीं रहता, जिससे फ़ाइल आकार घटता है जबकि शेष स्लाइड सामग्री नहीं बदलती। ये कार्य एक-दूसरे के पूरक हैं: आमतौर पर पहले स्लाइड्स हटाएँ, फिर साफ़‑सफ़ाई करें।