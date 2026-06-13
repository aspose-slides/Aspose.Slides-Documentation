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
- मास्टर नोट्स
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ प्रस्तुति नोट्स को अनुकूलित करें। PowerPoint और OpenDocument नोट्स के साथ सहजता से काम करें ताकि आपकी उत्पादकता बढ़े।"
---
## **सारांश**

Aspose.Slides प्रस्तुति से नोट्स स्लाइड्स को हटाने का समर्थन करता है। इस विषय में हम इस फ़ीचर को प्रस्तुत करेंगे, जिसमें नोट्स को कैसे हटाएँ और प्रस्तुति में नोट्स स्लाइड्स पर शैली कैसे लागू करें शामिल है। Aspose.Slides आपको किसी भी स्लाइड से नोट्स हटाने और मौजूदा नोट्स पर शैली लागू करने की अनुमति देता है। डेवलपर्स निम्नलिखित तरीकों से नोट्स हटा सकते हैं:

- प्रस्तुति में एक विशिष्ट स्लाइड से नोट्स हटाएँ।
- प्रस्तुति की सभी स्लाइड्स से नोट्स हटाएँ।

## **एक विशिष्ट स्लाइड से नोट्स हटाएँ**
नीचे दिखाए गए उदाहरण के अनुसार कुछ विशिष्ट स्लाइड के नोट्स हटाए जा सकते हैं:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesAtSpecificSlide-RemoveNotesAtSpecificSlide.cpp" >}}
## **सभी स्लाइड्स से नोट्स हटाएँ**
नीचे दिखाए गए उदाहरण के अनुसार प्रस्तुति की सभी स्लाइड्स के नोट्स हटाए जा सकते हैं:

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveNotesFromAllSlides-RemoveNotesFromAllSlides.cpp" >}}
## **नोट्स शैली जोड़ें**
IMasterNotesSlide इंटरफ़ेस और MasterNotesSlide क्लास में क्रमशः NotesStyle प्रॉपर्टी जोड़ी गई है। यह प्रॉपर्टी नोट्स टेक्स्ट की शैली निर्दिष्ट करती है। नीचे दिए गए उदाहरण में कार्यान्वयन दिखाया गया है।

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AddNotesSlideWithNotesStyle-AddNotesSlideWithNotesStyle.cpp" >}}

## **अक्सर पूछे जाने वाले प्रश्न**

**कौन सा API एंटिटी विशिष्ट स्लाइड के नोट्स तक पहुँच प्रदान करती है?**

नोट्स स्लाइड के नोट्स मैनेज़र के माध्यम से पहुँचा जाता है: स्लाइड के पास एक [NotesSlideManager](https://reference.aspose.com/slides/hi/cpp/aspose.slides/notesslidemanager/) और एक [method](https://reference.aspose.com/slides/hi/cpp/aspose.slides/notesslidemanager/get_notesslide/) है जो नोट्स ऑब्जेक्ट लौटाता है, या यदि कोई नोट्स नहीं हैं तो `null`।

**क्या लाइब्रेरी द्वारा समर्थित PowerPoint संस्करणों में नोट्स सपोर्ट में अंतर हैं?**

लाइब्रेरी माइक्रोसॉफ्ट PowerPoint के विभिन्न प्रारूपों (97‑नया) और ODP को लक्षित करती है; इन फ़ॉर्मैट्स में नोट्स समर्थित हैं और इसके लिए PowerPoint की स्थापित प्रति की आवश्यकता नहीं है।