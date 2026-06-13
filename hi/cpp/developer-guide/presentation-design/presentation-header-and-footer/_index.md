---
title: "C++ में प्रस्तुति हेडर और फूटर प्रबंधित करें"
linktitle: "हेडर और फूटर"
type: docs
weight: 140
url: /hi/cpp/presentation-header-and-footer/
keywords:
- हेडर
- हेडर टेक्स्ट
- फूटर
- फूटर टेक्स्ट
- हेडर सेट करें
- फूटर सेट करें
- हैंडआउट
- नोट्स
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "PowerPoint और OpenDocument प्रस्तुतियों में पेशेवर लुक के लिए हेडर और फूटर जोड़ने और अनुकूलित करने हेतु C++ के लिए Aspose.Slides का उपयोग करें।"
---
## **अवलोकन**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में हेडर और फूटर सेटिंग्स को प्रबंधित करने की अनुमति देता है। हेडर और फूटर प्रस्तुति मास्टर स्तर पर संभाले जाते हैं, और API फूटर टेक्स्ट सेट करने, फूटर की दृश्यता बदलने और मास्टर नोट्स स्लाइड्स पर हेडर टेक्स्ट अपडेट करने के तरीकों को प्रदान करता है।

आप हैंडआउट और नोट्स स्लाइड्स के लिए भी हेडर और फूटर प्रबंधित कर सकते हैं। इसमें नोट्स मास्टर, सभी चाइल्ड नोट्स स्लाइड्स, या एकल नोट्स स्लाइड के लिए हेडर, फूटर, स्लाइड नंबर, और तिथि‑समय प्लेसहोल्डर की दृश्यता और टेक्स्ट बदलना शामिल है।

## **हेडर और फूटर टेक्स्ट प्रबंधित करें**

किसी विशिष्ट स्लाइड के नोट्स को नीचे दिखाए गए उदाहरण के अनुसार अपडेट किया जा सकता है:

``` cpp
// हेडर/फूटर टेक्स्ट सेट करने का फ़ंक्शन
void UpdateHeaderFooterText(System::SharedPtr<IBaseSlide> master)
{
    for (const auto& shape : System::IterateOver(master->get_Shapes()))
    {
        if (shape->get_Placeholder() != nullptr)
        {
            if (shape->get_Placeholder()->get_Type() == PlaceholderType::Header)
            {
                (System::ExplicitCast<IAutoShape>(shape))->get_TextFrame()->set_Text(u"HI there new header");
            }
        }
    }
}
```

``` cpp
// प्रस्तुति लोड करें
auto pres = System::MakeObject<Presentation>(u"headerTest.pptx");

// फूटर सेट करना
pres->get_HeaderFooterManager()->SetAllFootersText(u"My Footer text");
pres->get_HeaderFooterManager()->SetAllFootersVisibility(true);

// हेडर तक पहुँचें और अपडेट करें
auto masterNotesSlide = pres->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (nullptr != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// प्रस्तुति सहेजें
pres->Save(u"HeaderFooterJava.pptx", SaveFormat::Pptx);
```

## **हैंडआउट और नोट्स स्लाइड्स में हेडर और फूटर प्रबंधित करें**
Aspose.Slides for C++ हैंडआउट और नोट्स स्लाइड्स में हेडर और फूटर का समर्थन करता है। कृपया नीचे दिए गए चरणों का पालन करें:

- Load a [प्रेजेंटेशन](https://reference.aspose.com/slides/hi/cpp/class/aspose.slides.presentation)containing a video.
- नोट्स मास्टर और सभी नोट्स स्लाइड्स के लिए हेडर और फूटर सेटिंग्स बदलें।
- मास्टर नोट्स स्लाइड और सभी चाइल्ड फूटर प्लेसहोल्डर को दृश्य बनाएँ।
- मास्टर नोट्स स्लाइड और सभी चाइल्ड तिथि और समय प्लेसहोल्डर को दृश्य बनाएँ।
- केवल पहले नोट्स स्लाइड के लिए हेडर और फूटर सेटिंग्स बदलें।
- नोट्स स्लाइड हेडर प्लेसहोल्डर को दृश्य बनाएँ।
- नोट्स स्लाइड हेडर प्लेसहोल्डर में टेक्स्ट सेट करें।
- नोट्स स्लाइड तिथि‑समय प्लेसहोल्डर में टेक्स्ट सेट करें।
- संशोधित प्रस्तुतिकरण फ़ाइल लिखें।

नीचे दिए गए उदाहरण में कोड स्निपेट प्रदान किया गया है।

``` cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
// नोट्स मास्टर और सभी नोट्स स्लाइड्स के लिए हेडर और फूटर सेटिंग्स बदलें
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (masterNotesSlide != nullptr)
{
	auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

	// मास्टर नोट्स स्लाइड और सभी चाइल्ड फूटर प्लेसहोल्डर को दृश्य बनाएं
	headerFooterManager->SetHeaderAndChildHeadersVisibility(true);
	// मास्टर नोट्स स्लाइड और सभी चाइल्ड हेडर प्लेसहोल्डर को दृश्य बनाएं
	headerFooterManager->SetFooterAndChildFootersVisibility(true);
	// मास्टर नोट्स स्लाइड और सभी चाइल्ड स्लाइड नंबर प्लेसहोल्डर को दृश्य बनाएं
	headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
	// मास्टर नोट्स स्लाइड और सभी चाइल्ड तिथि और समय प्लेसहोल्डर को दृश्य बनाएं
	headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

	// मास्टर नोट्स स्लाइड और सभी चाइल्ड हेडर प्लेसहोल्डर में टेक्स्ट सेट करें
	headerFooterManager->SetHeaderAndChildHeadersText(u"Header text");
	// मास्टर नोट्स स्लाइड और सभी चाइल्ड फूटर प्लेसहोल्डर में टेक्स्ट सेट करें
	headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
	// मास्टर नोट्स स्लाइड और सभी चाइल्ड तिथि और समय प्लेसहोल्डर में टेक्स्ट सेट करें
	headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
}

// केवल पहली नोट्स स्लाइड के लिए हेडर और फूटर सेटिंग्स बदलें
auto notesSlide = presentation->get_Slides()->idx_get(0)->get_NotesSlideManager()->get_NotesSlide();
if (notesSlide != nullptr)
{
	auto headerFooterManager = notesSlide->get_HeaderFooterManager();
	if (!headerFooterManager->get_IsHeaderVisible())
	{
		// इस नोट्स स्लाइड के हेडर प्लेसहोल्डर को दृश्य बनाएं
		headerFooterManager->SetHeaderVisibility(true);
	}

	if (!headerFooterManager->get_IsFooterVisible())
	{
		// इस नोट्स स्लाइड के फूटर प्लेसहोल्डर को दृश्य बनाएं
		headerFooterManager->SetFooterVisibility(true);
	}

	if (!headerFooterManager->get_IsSlideNumberVisible())
	{
		// इस नोट्स स्लाइड के स्लाइड नंबर प्लेसहोल्डर को दृश्य बनाएं
		headerFooterManager->SetSlideNumberVisibility(true);
	}
	
	if (!headerFooterManager->get_IsDateTimeVisible())
	{
		// इस नोट्स स्लाइड के तिथि-समय प्लेसहोल्डर को दृश्य बनाएं
		headerFooterManager->SetDateTimeVisibility(true);
	}
	
	// नोट्स स्लाइड के हेडर प्लेसहोल्डर में टेक्स्ट सेट करें
	headerFooterManager->SetHeaderText(u"New header text");
	// नोट्स स्लाइड के फूटर प्लेसहोल्डर में टेक्स्ट सेट करें
	headerFooterManager->SetFooterText(u"New footer text");
	// नोट्स स्लाइड के तिथि-समय प्लेसहोल्डर में टेक्स्ट सेट करें
	headerFooterManager->SetDateTimeText(u"New date and time text");
}

presentation->Save(u"testresult.pptx", SaveFormat::Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं नियमित स्लाइड्स में "हेडर" जोड़ सकता हूँ?**

PowerPoint में, "हेडर" केवल नोट्स और हैंडआउट के लिए उपलब्ध है; नियमित स्लाइड्स पर समर्थित तत्व फूटर, तिथि/समय, और स्लाइड नंबर हैं। Aspose.Slides में भी यही सीमाएँ लागू होती हैं: हेडर केवल नोट्स/हैंडआउट के लिए, और स्लाइड्स पर—फूटर/DateTime/SlideNumber।

**यदि लेआउट में फूटर क्षेत्र नहीं है तो क्या मैं उसकी दृश्यता "ऑन" कर सकता हूँ?**

हां। हेडर/फूटर प्रबंधक के माध्यम से दृश्यता जांचें और आवश्यक होने पर इसे सक्षम करें। यह API संकेतक और मेथड उन मामलों के लिए डिज़ाइन किए गए हैं जब प्लेसहोल्डर अनुपलब्ध या छिपा हो।

**मैं स्लाइड नंबर को 1 के अलावा किसी अन्य मान से कैसे शुरू करूँ?**

प्रेजेंटेशन के [first slide number](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/set_firstslidenumber/) को सेट करें; उसके बाद सभी नंबरिंग पुनः गणना की जाती है। उदाहरण के लिए, आप 0 या 10 से शुरू कर सकते हैं, और टाइटल स्लाइड पर नंबर को छिपा सकते हैं।

**PDF/इमेज/HTML में निर्यात करते समय हेडर/फूटर का क्या होता है?**

वे प्रस्तुति के सामान्य टेक्स्ट तत्वों की तरह रेंडर होते हैं। अर्थात, यदि ये तत्व स्लाइड्स/नोट्स पेजों पर दृश्य हैं, तो वे आउटपुट फ़ॉर्मेट में बाकी सामग्री के साथ दिखाई देंगे।