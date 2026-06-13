---
title: .NET में प्रेजेंटेशन नोट्स का प्रबंधन
linktitle: प्रेजेंटेशन नोट्स
type: docs
weight: 110
url: /hi/net/presentation-notes/
keywords:
- नोट्स
- नोट्स स्लाइड
- नोट्स जोड़ें
- नोट्स हटाएँ
- नोट्स शैली
- मास्टर नोट्स
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ प्रेजेंटेशन नोट्स को अनुकूलित करें। PowerPoint और OpenDocument नोट्स के साथ सहजता से काम करके अपनी उत्पादकता बढ़ाएँ।"
---
## **अवलोकन**

Aspose.Slides प्रस्तुति से नोट्स स्लाइड्स को हटाने का समर्थन करता है। इस विषय में, हम इस सुविधा को प्रस्तुत करेंगे, जिसमें नोट्स को हटाने की विधि और प्रस्तुति में नोट्स स्लाइड्स पर स्टाइल लागू करने की प्रक्रिया शामिल है। Aspose.Slides आपको किसी भी स्लाइड से नोट्स हटाने और मौजूदा नोट्स पर स्टाइल लागू करने की अनुमति देता है। डेवलपर्स नोट्स को निम्नलिखित तरीकों से हटा सकते हैं:

- प्रस्तुति की किसी विशिष्ट स्लाइड से नोट्स हटाएँ।
- प्रस्तुति की सभी स्लाइड्स से नोट्स हटाएँ।

## **स्लाइड से नोट्स हटाएँ**
नीचे दिए गए उदाहरण में दिखाए अनुसार किसी विशिष्ट स्लाइड के नोट्स हटाए जा सकते हैं:

```c#
// एक Presentation ऑब्जेक्ट बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है 
Presentation presentation = new Presentation(dataDir + "AccessSlides.pptx");

// पहली स्लाइड के नोट्स हटाना
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// प्रस्तुति को डिस्क पर सहेजें
presentation.Save(dataDir + "RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```


## **सभी स्लाइड्स से नोट्स हटाएँ**
नीचे दिए गए उदाहरण में दिखाए अनुसार प्रस्तुति की सभी स्लाइड्स के नोट्स हटाए जा सकते हैं:

```c#
// एक Presentation ऑब्जेक्ट बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है 
Presentation presentation = new Presentation("AccessSlides.pptx");

// सभी स्लाइड्स के नोट्स हटाना
INotesSlideManager mgr = null;
for (int i = 0; i < presentation.Slides.Count; i++)
{
    mgr = presentation.Slides[i].NotesSlideManager;
    mgr.RemoveNotesSlide();
}
// प्रस्तुति को डिस्क पर सहेजें
presentation.Save("RemoveNotesFromAllSlides_out.pptx", SaveFormat.Pptx);
```


## **नोट्स शैली जोड़ें**
NotesStyle प्रॉपर्टी क्रमशः [IMasterNotesSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/imasternotesslide) इंटरफ़ेस और [MasterNotesSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/masternotesslide) क्लास में जोड़ी गई है। यह प्रॉपर्टी नोट्स टेक्स्ट की शैली निर्धारित करती है। कार्यान्वयन नीचे दिए गए उदाहरण में दिखाया गया है।

```c#
// एक Presentation क्लास बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // MasterNotesSlide टेक्स्ट शैली प्राप्त करें
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //Set पहले स्तर के पैराग्राफ़ के लिए सिंबल बुलेट सेट करें
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // PPTX फ़ाइल को डिस्क पर सहेजें
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन सा API एंटिटी विशिष्ट स्लाइड के नोट्स तक पहुंच प्रदान करता है?**

नोट्स स्लाइड के नोट्स मैनेजर के माध्यम से एक्सेस किए जाते हैं: स्लाइड के पास एक [NotesSlideManager](https://reference.aspose.com/slides/hi/net/aspose.slides/notesslidemanager/) और एक [property](https://reference.aspose.com/slides/hi/net/aspose.slides/notesslidemanager/notesslide/) है जो नोट्स ऑब्जेक्ट लौटाता है, या यदि नोट्स नहीं हैं तो `null` लौटाता है।

**क्या लाइब्रेरी द्वारा समर्थित PowerPoint संस्करणों में नोट्स समर्थन में अंतर है?**

लाइब्रेरी Microsoft PowerPoint के व्यापक श्रेणी (97–न्यूअर) और ODP फ़ॉर्मेट को लक्षित करती है; इन फ़ॉर्मेट्स में नोट्स का समर्थन किया जाता है बिना किसी स्थापित PowerPoint की आवश्यकता के।