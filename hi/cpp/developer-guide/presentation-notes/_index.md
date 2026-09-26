---
title: C++ में प्रस्तुति नोट्स प्रबंधित करें
linktitle: प्रस्तुति नोट्स
type: docs
weight: 110
url: /hi/cpp/presentation-notes/
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
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ प्रस्तुति नोट्स को अनुकूलित करें। PowerPoint और OpenDocument नोट्स के साथ सहजता से काम करके अपनी उत्पादकता बढ़ाएँ।"
---
## **सारांश**

Aspose.Slides प्रस्तुति से नोट्स स्लाइड्स को हटाने का समर्थन करता है। इस विषय में, हम इस सुविधा को प्रस्तुत करेंगे, जिसमें नोट्स को कैसे हटाया जाए और प्रस्तुति में नोट्स स्लाइड्स पर शैली कैसे लागू की जाए, शामिल है। Aspose.Slides आपको किसी भी स्लाइड से नोट्स हटाने और मौजूदा नोट्स पर शैली लागू करने की अनुमति देता है। डेवलपर्स नोट्स को निम्नलिखित तरीकों से हटा सकते हैं:

- प्रस्तुति में किसी विशिष्ट स्लाइड से नोट्स हटाना।
- प्रस्तुति की सभी स्लाइड्स से नोट्स हटाना।

नोट्स पेज के आयाम पढ़ने या बदलने, अभिविन्यास बदलने, और निर्यात व्यवहार जांचने के लिए, देखें [नोट्स पेज साइज](/slides/hi/cpp/notes-size/)।

## **विशिष्ट स्लाइड से नोट्स हटाएं**
निचे दिखाए गए उदाहरण के अनुसार किसी विशिष्ट स्लाइड से नोट्स हटाए जा सकते हैं:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **सभी स्लाइड्स से नोट्स हटाएं**
निचे दिखाए गए उदाहरण के अनुसार प्रस्तुति की सभी स्लाइड्स से नोट्स हटाए जा सकते हैं:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **नोट्स शैली जोड़ें**
NotesStyle प्रॉपर्टी को IMasterNotesSlide इंटरफ़ेस और MasterNotesSlide क्लास में जोड़ा गया है। यह प्रॉपर्टी नोट्स टेक्स्ट की शैली निर्धारित करती है। कार्यान्वयन नीचे दिए गए उदाहरण में दर्शाया गया है।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **FAQ**

### कौन सा API एंटिटी विशिष्ट स्लाइड के नोट्स तक पहुँच प्रदान करता है?

नोट्स स्लाइड की नोट्स मैनेजर के माध्यम से पहुँचा जाता है: स्लाइड में एक [NotesSlideManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/notesslidemanager/) होता है और एक [method](https://reference.aspose.com/slides/hi/cpp/aspose.slides/notesslidemanager/get_notesslide/) है जो नोट्स ऑब्जेक्ट लौटाता है, या यदि नोट्स नहीं हैं तो `null` देता है।

### क्या लाइब्रेरी द्वारा समर्थित PowerPoint संस्करणों में नोट्स समर्थन में अंतर है?

लाइब्रेरी Microsoft PowerPoint के व्यापक रेंज (97‑नया) और ODP को लक्षित करती है; इन स्वरूपों में नोट्स का समर्थन किया जाता है और इसके लिए PowerPoint की स्थापित कॉपी की आवश्यकता नहीं होती।