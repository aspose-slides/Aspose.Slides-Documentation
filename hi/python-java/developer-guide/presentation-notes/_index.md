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
- मास्टर नोट्स
- PowerPoint
- OpenDocument
- प्रस्तुति
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java के साथ प्रस्तुति नोट्स को अनुकूलित करें। PowerPoint और OpenDocument नोट्स के साथ सहजता से काम करें ताकि आपकी उत्पादकता बढ़े।"
---
## **परिचय**

Aspose.Slides प्रस्तुति से नोट्स स्लाइड हटाने का समर्थन करता है। यह विषय इस सुविधा का परिचय कराता है, जिसमें नोट्स को कैसे हटाएँ और प्रस्तुति में नोट्स स्लाइड पर शैली कैसे लागू करें, शामिल है। Aspose.Slides आपको किसी भी स्लाइड से नोट्स हटाने और मौजूदा नोट्स पर शैली लागू करने की अनुमति देता है। डेवलपर्स निम्नलिखित तरीकों से नोट्स हटा सकते हैं:

- प्रस्तुति में किसी विशिष्ट स्लाइड से नोट्स हटाएँ।
- प्रस्तुति में सभी स्लाइड्स से नोट्स हटाएँ।

## **एक स्लाइड से नोट्स हटाएँ**

एक विशिष्ट स्लाइड से नोट्स को नीचे दिए गए उदाहरण की तरह हटाया जा सकता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# एक Presentation ऑब्जेक्ट बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
presentation = Presentation("presWithNotes.pptx")
try:
    # पहले स्लाइड से नोट्स हटाएँ।
    notes_manager = presentation.getSlides().get_Item(0).getNotesSlideManager()
    notes_manager.removeNotesSlide()

    # प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **प्रस्तुति से नोट्स हटाएँ**

प्रस्तुति में सभी स्लाइड्स से नोट्स को नीचे दिए गए उदाहरण की तरह हटाया जा सकता है:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# एक Presentation ऑब्जेक्ट बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
presentation = Presentation("presWithNotes.pptx")
try:
    # सभी स्लाइड्स से नोट्स हटाएँ।
    for i in range(presentation.getSlides().size()):
        notes_manager = presentation.getSlides().get_Item(i).getNotesSlideManager()
        notes_manager.removeNotesSlide()

    # प्रस्तुति को डिस्क पर सहेजें।
    presentation.save("test.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **एक नोट्स शैली जोड़ें**

[MasterNotesSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masternotesslide/) वर्ग की [getNotesStyle](https://reference.aspose.com/slides/hi/python-java/aspose.slides/masternotesslide/#getNotesStyle) विधि नोट्स टेक्स्ट की शैली तक पहुँच प्रदान करती है। कार्यान्वयन नीचे दिए गए उदाहरण में प्रदर्शित किया गया है।

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BulletType, Presentation, SaveFormat

# एक Presentation ऑब्जेक्ट बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
presentation = Presentation("demo.pptx")
try:
    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()

    if notes_master is not None:
        # मास्टर नोट्स स्लाइड टेक्स्ट शैली प्राप्त करें।
        notes_style = notes_master.getNotesStyle()

        # पहले स्तर के पैराग्राफ़ के लिए प्रतीक बुलेट सेट करें।
        paragraph_format = notes_style.getLevel(0)
        paragraph_format.getBullet().setType(BulletType.Symbol)

    presentation.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**कौन सा API इकाई किसी विशिष्ट स्लाइड के नोट्स तक पहुँच प्रदान करती है?**

नोट्स स्लाइड के नोट्स मैनेजर के माध्यम से एक्सेस किए जाते हैं: स्लाइड के पास एक [NotesSlideManager](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notesslidemanager/) और एक [getNotesSlide](https://reference.aspose.com/slides/hi/python-java/aspose.slides/notesslidemanager/#getNotesSlide) विधि होती है जो नोट्स ऑब्जेक्ट लौटाती है, या यदि कोई नोट्स नहीं हैं तो `None` लौटाती है।

**क्या लाइब्रेरी के द्वारा समर्थित PowerPoint संस्करणों में नोट्स समर्थन में अंतर है?**

लाइब्रेरी Microsoft PowerPoint के व्यापक रेंज (97 और बाद के संस्करण) तथा ODP को लक्षित करती है; इन फ़ॉर्मैट्स में नोट्स समर्थित हैं और इसके लिए PowerPoint की स्थापित प्रति की आवश्यकता नहीं है।