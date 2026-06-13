---
title: Python में प्रस्तुति नोट्स प्रबंधित करें
linktitle: प्रस्तुति नोट्स
type: docs
weight: 110
url: /hi/python-net/presentation-notes/
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
- Aspose.Slides
description: "Aspose.Slides for Python के माध्यम से .NET के साथ प्रस्तुति नोट्स को अनुकूलित करें। PowerPoint और OpenDocument नोट्स के साथ सहजता से कार्य करें ताकि आपकी उत्पादकता बढ़े।"
---
## **अवलोकन**

Aspose.Slides प्रस्तुति से नोट्स स्लाइड्स को हटाने का समर्थन करता है। इस लेख में, हम इस सुविधा को प्रस्तुत करेंगे, जिसमें नोट्स को हटाने और प्रस्तुति में नोट्स स्लाइड्स पर स्टाइल लागू करने के बारे में बताया गया है। Aspose.Slides आपको किसी भी स्लाइड से नोट्स हटाने और मौजूदा नोट्स पर स्टाइल लागू करने की अनुमति देता है। डेवलपर्स निम्नलिखित तरीकों से नोट्स हटा सकते हैं:

- किसी विशिष्ट स्लाइड से नोट्स हटाएं।
- प्रस्तुति में सभी स्लाइड्स से नोट्स हटाएं।

## **स्लाइड से नोट्स हटाएं**
नीचे दिए गए उदाहरण में दिखाए अनुसार कुछ विशिष्ट स्लाइड के नोट्स हटाए जा सकते हैं:

```py
import aspose.slides as slides

# एक Presentation ऑब्जेक्ट बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # पहली स्लाइड के नोट्स हटाएं
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # प्रस्तुति को डिस्क पर सहेजें
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **सभी स्लाइड्स से नोट्स हटाएं**
नीचे दिए गए उदाहरण में दिखाए अनुसार प्रस्तुति की सभी स्लाइड्स के नोट्स हटाए जा सकते हैं:

```py
import aspose.slides as slides

# एक Presentation ऑब्जेक्ट बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # सभी स्लाइडों के नोट्स हटाएं
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # प्रस्तुति को डिस्क पर सहेजें
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **NotesStyle जोड़ें**
[notes_style](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masternotesslide/notes_style/) प्रॉपर्टी को [MasterNotesSlide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masternotesslide/) क्लास में जोड़ा गया है। यह प्रॉपर्टी नोट्स टेक्स्ट की शैली निर्धारित करती है। कार्यान्वयन नीचे दिए गए उदाहरण में प्रदर्शित किया गया है।

```py
import aspose.slides as slides

# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाला Presentation क्लास बनाएं
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # MasterNotesSlide टेक्स्ट शैली प्राप्त करें
        notesStyle = notesMaster.notes_style

        #पहले स्तर के पैराग्राफ़ के लिए प्रतीक बुलेट सेट करें
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # PPTX फ़ाइल को डिस्क पर सहेजें
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन-सा API एंटिटी विशिष्ट स्लाइड के नोट्स तक पहुंच प्रदान करता है?**

नोट्स स्लाइड के नोट्स मैनेजर के माध्यम से एक्सेस किए जाते हैं: स्लाइड में एक [NotesSlideManager](https://reference.aspose.com/slides/hi/python-net/aspose.slides/notesslidemanager/) और एक [property](https://reference.aspose.com/slides/hi/python-net/aspose.slides/notesslidemanager/notes_slide/) होता है जो नोट्स ऑब्जेक्ट वापस करता है, या यदि नोट्स नहीं हैं तो `None`।

**क्या लाइब्रेरी द्वारा समर्थित PowerPoint संस्करणों में नोट्स समर्थन में अंतर है?**

लाइब्रेरी Microsoft PowerPoint के विभिन्न प्रारूपों (97-नया) और ODP को लक्षित करती है; इन प्रारूपों में नोट्स समर्थित होते हैं और इसके लिए स्थापित PowerPoint की आवश्यकता नहीं होती।