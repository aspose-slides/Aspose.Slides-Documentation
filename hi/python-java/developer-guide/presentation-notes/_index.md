---
title: Python के माध्यम से Java में प्रस्तुति नोट्स प्रबंधित करें
linktitle: प्रस्तुति नोट्स
type: docs
weight: 110
url: /hi/python-java/presentation-notes/
keywords:
- नोट्स
- नोट्स स्लाइड
- नोट्स जोड़ें
- नोट्स हटाएँ
- नोट्स शैली
- मुख्य नोट्स
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ प्रस्तुति नोट्स को अनुकूलित करें। PowerPoint और OpenDocument नोट्स के साथ सहजता से काम करके अपनी उत्पादकता बढ़ाएँ।"
---
## **अवलोकन**

Aspose.Slides प्रस्तुति से नोट्स स्लाइड को हटाने का समर्थन करता है। यह विषय इस सुविधा का परिचय देता है, जिसमें नोट्स को हटाने तथा प्रस्तुति में नोट्स स्लाइड पर शैली लागू करने के तरीकों को शामिल किया गया है। Aspose.Slides आपको किसी भी स्लाइड से नोट्स हटाने और मौजूदा नोट्स पर शैली लागू करने की अनुमति देता है। डेवलपर्स निम्नलिखित तरीकों से नोट्स हटा सकते हैं:

- प्रस्तुति में किसी विशिष्ट स्लाइड से नोट्स हटाएँ।
- प्रस्तुति की सभी स्लाइडों से नोट्स हटाएँ।

नोट्स पेज के आयाम पढ़ने या बदलने, अभिविन्यास बदलने और निर्यात व्यवहार जाँचने के लिए, देखें [नोट्स पेज आकार](/slides/hi/python-java/notes-size/)।

## **स्लाइड से नोट्स हटाएँ**

किसी विशिष्ट स्लाइड के नोट्स को नीचे दिखाए गए उदाहरण के अनुसार हटाया जा सकता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# एक Presentation ऑब्जेक्ट बनाएँ जो प्रस्तुति फ़ाइल को दर्शाता है।
presentation = Presentation("presWithNotes.pptx")
try:
    # पहली स्लाइड से नोट्स हटाएँ।
    notes_manager = presentation.getSlides().get_Item(0).getNotesSlideManager()
    notes_manager.removeNotesSlide()

    # प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **प्रस्तुति से नोट्स हटाएँ**

प्रस्तुति की सभी स्लाइडों के नोट्स को नीचे दिखाए गए उदाहरण के अनुसार हटाया जा सकता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# एक Presentation ऑब्जेक्ट बनाएँ जो प्रस्तुति फ़ाइल को दर्शाता है।
presentation = Presentation("presWithNotes.pptx")
try:
    # सभी स्लाइडों से नोट्स हटाएँ।
    for i in range(presentation.getSlides().size()):
        notes_manager = presentation.getSlides().get_Item(i).getNotesSlideManager()
        notes_manager.removeNotesSlide()

    # प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **नोट्स शैली जोड़ें**

क्लास [MasterNotesSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masternotesslide/) की [getNotesStyle](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masternotesslide/#getNotesStyle) विधि नोट्स टेक्स्ट की शैली तक पहुँच प्रदान करती है। कार्यान्वयन नीचे दिए गए उदाहरण में दर्शाया गया है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Presentation, SaveFormat

# एक Presentation ऑब्जेक्ट बनाएँ जो प्रस्तुति फ़ाइल को दर्शाता है।
presentation = Presentation("demo.pptx")
try:
    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if notes_master is not None:
        # मुख्य नोट्स स्लाइड टेक्स्ट शैली प्राप्त करें।
        notes_style = notes_master.getNotesStyle()

        # प्रथम स्तर के पैराग्राफ़ के लिए सिम्बोल बुलेट सेट करें।
        paragraph_format = notes_style.getLevel(0)
        paragraph_format.getBullet().setType(BulletType.Symbol)

    presentation.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन सा API इकाई विशिष्ट स्लाइड के नोट्स तक पहुँच प्रदान करती है?**

नोट्स स्लाइड के नोट्स मैनेजर के माध्यम से पहुँचा जाता है: प्रत्येक स्लाइड के पास एक [NotesSlideManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notesslidemanager/) और एक [getNotesSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notesslidemanager/#getNotesSlide) विधि होती है जो नोट्स ऑब्जेक्ट लौटाती है, या `None` यदि کوئی नोट्स नहीं है।

**क्या लाइब्रेरी के काम करने वाले PowerPoint संस्करणों में नोट्स समर्थन में अंतर है?**

लाइब्रेरी Microsoft PowerPoint के विभिन्न प्रारूपों (97 और बाद के) तथा ODP को लक्षित करती है; इन प्रारूपों में नोट्स को स्थापित PowerPoint की कॉपी पर निर्भर किए बिना समर्थित किया जाता है।