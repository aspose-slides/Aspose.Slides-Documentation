---
title: Python में प्रस्तुति नोट्स को नियंत्रित करें
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
description: "Aspose.Slides for Python via .NET के साथ प्रस्तुति नोट्स को अनुकूलित करें। PowerPoint और OpenDocument नोट्स के साथ सहजता से काम करें और अपनी उत्पादकता बढ़ाएँ।"
---
## **अवलोकन**

Aspose.Slides प्रस्तुति से नोट स्लाइड को हटाने का समर्थन करता है। इस विषय में हम इस सुविधा का परिचय देंगे, जिसमें नोट्स को कैसे हटाएँ और प्रस्तुति में नोट स्लाइड पर शैली कैसे लागू करें शामिल है। Aspose.Slides आपको किसी भी स्लाइड से नोट्स हटाने और मौजूदा नोट्स पर स्टाइल लागू करने की अनुमति देता है। डेवलपर्स निम्नलिखित तरीकों से नोट्स हटा सकते हैं:

- प्रस्तुति में किसी विशिष्ट स्लाइड से नोट्स हटाएँ।
- प्रस्तुति की सभी स्लाइड्स से नोट्स हटाएँ।

नोट्स पृष्ठ के आयाम पढ़ने या बदलने, अभिविन्यास बदलने, और निर्यात व्यवहार जांचने के लिए, देखें [Notes Page Size](/slides/hi/python-net/notes-size/)।

## **स्लाइड से नोट्स हटाएँ**
नीचे दिखाए गए उदाहरण के अनुसार किसी विशिष्ट स्लाइड से नोट्स हटाए जा सकते हैं:

```py
import aspose.slides as slides

# प्रस्तुति फ़ाइल को दर्शाने वाला प्रस्तुति ऑब्जेक्ट बनाएं 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # पहली स्लाइड के नोट्स हटाना
    mgr = presentation.slides[0].notes_slide_manager
    mgr.remove_notes_slide()

    # प्रस्तुति को डिस्क पर सहेजें
    presentation.save("RemoveNotesAtSpecificSlide_out.pptx", slides.export.SaveFormat.PPTX)
```

## **सभी स्लाइड्स से नोट्स हटाएँ**
प्रस्तुति की सभी स्लाइड्स से नोट्स नीचे दिखाए गए उदाहरण के अनुसार हटाए जा सकते हैं:

```py
import aspose.slides as slides

# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाला Presentation ऑब्जेक्ट बनाएं 
with slides.Presentation("AccessSlides.pptx") as presentation:
    # सभी स्लाइड्स के नोट्स हटाना
    for i in range(len(presentation.slides)):
        mgr = presentation.slides[i].notes_slide_manager
        mgr.remove_notes_slide()
    # प्रस्तुति को डिस्क पर सहेजें
    presentation.save("RemoveNotesFromAllSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **नोट्स शैली लागू करें**
[notes_style](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masternotesslide/notes_style/) प्रॉपर्टी को [MasterNotesSlide](https://reference.aspose.com/slides/hi/python-net/aspose.slides/masternotesslide/) क्लास में जोड़ा गया है। यह प्रॉपर्टी नोट्स टेक्स्ट की शैली निर्दिष्ट करती है। कार्यान्वयन नीचे दिए गए उदाहरण में प्रदर्शित किया गया है।

```py
import aspose.slides as slides

# प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाला Presentation क्लास बनाएं
with slides.Presentation("AccessSlides.pptx") as presentation:
    notesMaster = presentation.master_notes_slide_manager.master_notes_slide
    if notesMaster != None:
        # MasterNotesSlide टेक्स्ट शैली प्राप्त करें
        notesStyle = notesMaster.notes_style

        #Set पहला स्तर पैराग्राफ के लिए सिम्बॉल बुलेट सेट करें
        paragraphFormat = notesStyle.get_level(0)
        paragraphFormat.bullet.type = slides.BulletType.SYMBOL

    # PPTX फ़ाइल को डिस्क पर सहेजें
    presentation.save("AddNotesSlideWithNotesStyle_out.pptx", slides.export.SaveFormat.PPTX)
```

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन सा API इकाई किसी विशिष्ट स्लाइड के नोट्स तक पहुँच प्रदान करता है?**

नोट्स स्लाइड के नोट्स मैनेजर के माध्यम से एक्सेस किए जाते हैं: स्लाइड के पास एक [NotesSlideManager](https://reference.aspose.com/slides/hi/python-net/aspose.slides/notesslidemanager/) और एक [property](https://reference.aspose.com/slides/hi/python-net/aspose.slides/notesslidemanager/notes_slide/) है जो नोट्स ऑब्जेक्ट लौटाता है, या `None` यदि कोई नोट नहीं हैं।

**क्या लाइब्रेरी द्वारा समर्थित विभिन्न PowerPoint संस्करणों में नोट्स समर्थन में अंतर है?**

लाइब्रेरी Microsoft PowerPoint के व्यापक स्वरूपों (97–नया) और ODP को लक्षित करती है; इन स्वरूपों में नोट्स का समर्थन स्थापित PowerPoint की प्रति पर निर्भर किए बिना किया जाता है।