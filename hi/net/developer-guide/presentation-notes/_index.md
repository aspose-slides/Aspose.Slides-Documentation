---
title: .NET में प्रस्तुति नोट्स प्रबंधित करें
linktitle: प्रस्तुति नोट्स
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
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ प्रस्तुति नोट्स को अनुकूलित करें। PowerPoint और OpenDocument नोट्स के साथ सहजता से काम करके अपनी उत्पादकता बढ़ाएँ।"
---
## **अवलोकन**

Aspose.Slides प्रस्तुति से नोट्स स्लाइड को हटाने का समर्थन करता है। इस विषय में, हम इस सुविधा को प्रस्तुत करेंगे, जिसमें नोट्स को कैसे हटाया जाए और प्रस्तुति में नोट्स स्लाइड पर शैली कैसे लागू की जाए शामिल है। Aspose.Slides आपको किसी भी स्लाइड से नोट्स हटाने और मौजूदा नोट्स पर शैली लागू करने की अनुमति देता है। डेवलपर्स निम्नलिखित तरीकों से नोट्स हटा सकते हैं:

- प्रस्तुति में किसी विशिष्ट स्लाइड से नोट्स हटाएँ।
- प्रस्तुति की सभी स्लाइड्स से नोट्स हटाएँ।

नोट्स पेज के आयाम पढ़ने या बदलने, अभिविन्यास बदलने, और निर्यात व्यवहार जांचने के लिए, देखें [Notes Page Size](/slides/hi/net/notes-size/)।

## **एक स्लाइड से नोट्स हटाएँ**
नीचे दिए गए उदाहरण के अनुसार कुछ विशिष्ट स्लाइड के नोट्स हटाए जा सकते हैं:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// एक Presentation वस्तु बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करती है
Presentation presentation = new Presentation("AccessSlides.pptx");

// पहली स्लाइड के नोट्स को हटाना
INotesSlideManager mgr = presentation.Slides[0].NotesSlideManager;
mgr.RemoveNotesSlide();

// प्रस्तुति को डिस्क पर सहेजें
presentation.Save("RemoveNotesAtSpecificSlide_out.pptx", SaveFormat.Pptx);
```

## **सभी स्लाइड्स से नोट्स हटाएँ**
नीचे दिए गए उदाहरण के अनुसार प्रस्तुति की सभी स्लाइड्स के नोट्स हटाए जा सकते हैं:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// एक Presentation वस्तु बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करती है 
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
NotesStyle प्रॉपर्टी क्रमशः [IMasterNotesSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/imasternotesslide) इंटरफ़ेस और [MasterNotesSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/masternotesslide) क्लास में जोड़ी गई है। यह प्रॉपर्टी नोट्स टेक्स्ट की शैली को निर्दिष्ट करती है। कार्यान्वयन नीचे दिए गए उदाहरण में दिखाया गया है।

```c#
using Aspose.Slides;

// एक Presentation क्लास बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करती है
using (Presentation presentation = new Presentation("AccessSlides.pptx"))
{
    IMasterNotesSlide notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;

    if (notesMaster != null)
    {
        // MasterNotesSlide का टेक्स्ट शैली प्राप्त करें
        ITextStyle notesStyle = notesMaster.NotesStyle;

        //पहले स्तर के पैराग्राफ़ के लिए प्रतीक बुलेट सेट करें
        IParagraphFormat paragraphFormat = notesStyle.GetLevel(0);
        paragraphFormat.Bullet.Type = BulletType.Symbol;
    }

    // PPTX फ़ाइल को डिस्क पर सहेजें
    presentation.Save("AddNotesSlideWithNotesStyle_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

}
```

## **सामान्य प्रश्न**

### विशिष्ट स्लाइड के नोट्स तक पहुंच प्रदान करने वाली API इकाई कौन सी है?

नोट्स स्लाइड की नोट्स मैनेजर के माध्यम से एक्सेस की जाती हैं: स्लाइड में एक [NotesSlideManager](https://reference.aspose.com/slides/hi/net/aspose.slides/notesslidemanager/) और एक [property](https://reference.aspose.com/slides/hi/net/aspose.slides/notesslidemanager/notesslide/) है जो नोट्स ऑब्जेक्ट लौटाता है, या यदि कोई नोट्स नहीं हैं तो `null`।

### लाइब्रेरी जिस PowerPoint संस्करणों के साथ काम करती है, उनके बीच नोट्स समर्थन में कोई अंतर है क्या?

लाइब्रेरी Microsoft PowerPoint के व्यापक रेंज (97‑नया) और ODP फ़ॉर्मेट को लक्षित करती है; इन फ़ॉर्मेट में नोट्स का समर्थन किया जाता है और इसके लिए PowerPoint की स्थापित प्रति की आवश्यकता नहीं होती।