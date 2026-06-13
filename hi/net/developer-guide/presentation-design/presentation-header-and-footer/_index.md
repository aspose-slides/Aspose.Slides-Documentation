---
title: .NET में प्रस्तुति हेडर और फ़ुटर को प्रबंधित करें
linktitle: हेडर और फ़ुटर
type: docs
weight: 140
url: /hi/net/presentation-header-and-footer/
keywords:
- हेडर
- हेडर टेक्स्ट
- फ़ुटर
- फ़ुटर टेक्स्ट
- हेडर सेट करें
- फ़ुटर सेट करें
- हैंडआउट
- नोट्स
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "प्रोफ़ेशनल लुक के लिए PowerPoint और OpenDocument प्रस्तुतियों में हेडर और फ़ुटर जोड़ने और अनुकूलित करने के लिए .NET के लिए Aspose.Slides का उपयोग करें।"
---
## **सारांश**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में हेडर और फुटर सेटिंग्स प्रबंधित करने की सुविधा देता है। हेडर और फुटर प्रस्तुति मास्टर स्तर पर संभाले जाते हैं, और API फ़ुटर टेक्स्ट सेट करने, फ़ुटर की दृश्यता बदलने, और मास्टर नोट्स स्लाइड्स पर हेडर टेक्स्ट अपडेट करने के लिए मेथड्स प्रदान करता है।

आप हैंडआउट और नोट्स स्लाइड्स के लिए भी हेडर और फुटर प्रबंधित कर सकते हैं। इसमें नोट्स मास्टर, सभी चाइल्ड नोट्स स्लाइड्स, या किसी व्यक्तिगत नोट्स स्लाइड के लिए हेडर, फुटर, स्लाइड नंबर, और तिथि‑समय प्लेसहोल्डर्स की दृश्यता और टेक्स्ट बदलना शामिल है।

## **हेडर और फुटर टेक्स्ट प्रबंधन**

कुछ विशिष्ट स्लाइड के नोट्स को नीचे दर्शाए गए उदाहरण की तरह अपडेट किया जा सकता है:

```c#
// प्रस्तुति लोड करें
Presentation pres = new Presentation("headerTest.pptx");

// फुटर सेट करना
pres.HeaderFooterManager.SetAllFootersText("My Footer text");
pres.HeaderFooterManager.SetAllFootersVisibility(true);

// हेडर तक पहुँचें और अपडेट करें
IMasterNotesSlide masterNotesSlide = pres.MasterNotesSlideManager.MasterNotesSlide;
if (null != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// प्रस्तुति सहेजें
pres.Save("HeaderFooterJava.pptx", SaveFormat.Pptx);
```



```c#
// हेडर/फ़ुटर टेक्स्ट सेट करने की विधि
public static void UpdateHeaderFooterText(IBaseSlide master)
{
    foreach (IShape shape in master.Shapes)
    {
        if (shape.Placeholder != null)
        {
            if (shape.Placeholder.Type == PlaceholderType.Header)
            {
                ((IAutoShape)shape).TextFrame.Text = "HI there new header";
            }
        }
    }
}
```




## **हैंडआउट और नोट्स स्लाइड्स में हेडर और फुटर प्रबंधन**
Aspose.Slides for .NET हैंडआउट और नोट्स स्लाइड्स में हेडर और फुटर का समर्थन करता है। कृपया नीचे दिए गए चरणों का पालन करें:

- एक [प्रस्तुति](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation)लोड करें जिसमें वीडियो हो।
- नोट्स मास्टर और सभी नोट्स स्लाइड्स के लिए हेडर और फुटर सेटिंग्स बदलें।
- मास्टर नोट्स स्लाइड और सभी चाइल्ड फुटर प्लेसहोल्डर्स को दृश्यमान सेट करें।
- मास्टर नोट्स स्लाइड और सभी चाइल्ड तिथि और समय प्लेसहोल्डर्स को दृश्यमान सेट करें।
- केवल पहले नोट्स स्लाइड के लिए हेडर और फुटर सेटिंग्स बदलें।
- नोट्स स्लाइड हेडर प्लेसहोल्डर को दृश्यमान सेट करें।
- नोट्स स्लाइड हेडर प्लेसहोल्डर में टेक्स्ट सेट करें।
- नोट्स स्लाइड तिथि‑समय प्लेसहोल्डर में टेक्स्ट सेट करें।
- संशोधित प्रस्तुति फ़ाइल लिखें।

नीचे दिए गए उदाहरण में कोड स्निपेट प्रदान किया गया है।

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// नोट्स मास्टर और सभी नोट्स स्लाइड्स के लिए हेडर और फुटर सेटिंग्स बदलें
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // मास्टर नोट्स स्लाइड और सभी चाइल्ड फुटर प्लेसहोल्डर्स को दृश्यमान बनाएं
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // मास्टर नोट्स स्लाइड और सभी चाइल्ड हेडर प्लेसहोल्डर्स को दृश्यमान बनाएं
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // मास्टर नोट्स स्लाइड और सभी चाइल्ड स्लाइडनंबर प्लेसहोल्डर्स को दृश्यमान बनाएं
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // मास्टर नोट्स स्लाइड और सभी चाइल्ड तिथि और समय प्लेसहोल्डर्स को दृश्यमान बनाएं

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // मास्टर नोट्स स्लाइड और सभी चाइल्ड हेडर प्लेसहोल्डर्स को टेक्स्ट सेट करें
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // मास्टर नोट्स स्लाइड और सभी चाइल्ड फुटर प्लेसहोल्डर्स को टेक्स्ट सेट करें
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // मास्टर नोट्स स्लाइड और सभी चाइल्ड तिथि और समय प्लेसहोल्डर्स को टेक्स्ट सेट करें
	}

	// पहली नोट्स स्लाइड के लिए केवल हेडर और फुटर सेटिंग्स बदलें
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // इस नोट्स स्लाइड के हेडर प्लेसहोल्डर को दृश्यमान बनाएं

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // इस नोट्स स्लाइड के फुटर प्लेसहोल्डर को दृश्यमान बनाएं

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // इस नोट्स स्लाइड के स्लाइडनंबर प्लेसहोल्डर को दृश्यमान बनाएं

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // इस नोट्स स्लाइड के तिथि-समय प्लेसहोल्डर को दृश्यमान बनाएं

		headerFooterManager.SetHeaderText("New header text"); // नोट्स स्लाइड हेडर प्लेसहोल्डर को टेक्स्ट सेट करें
		headerFooterManager.SetFooterText("New footer text"); // नोट्स स्लाइड फुटर प्लेसहोल्डर को टेक्स्ट सेट करें
		headerFooterManager.SetDateTimeText("New date and time text"); // नोट्स स्लाइड तिथि-समय प्लेसहोल्डर को टेक्स्ट सेट करें
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं सामान्य स्लाइड्स में "हेडर" जोड़ सकता हूँ?**

PowerPoint में "हेडर" केवल नोट्स और हैंडआउट के लिए मौजूद है; सामान्य स्लाइड्स में समर्थित तत्व फुटर, तिथि/समय, और स्लाइड नंबर हैं। Aspose.Slides में भी यही सीमाएँ लागू होती हैं: हेडर केवल नोट्स/हैंडआउट के लिए, और स्लाइड्स में—फ़ुटर/तिथि‑समय/स्लाइड‑नंबर।

**यदि लेआउट में फुटर क्षेत्र नहीं है—क्या मैं उसकी दृश्यता "ऑन" कर सकता हूँ?**

हाँ। हेडर/फ़ुटर प्रबंधक के माध्यम से दृश्यता जाँचें और आवश्यक होने पर इसे सक्षम करें। यह API संकेतक और मेथड्स उन मामलों के लिए बनाए गए हैं जब प्लेसहोल्डर अनुपलब्ध या छिपा हो।

**मैं स्लाइड नंबर को 1 के अलावा किसी मान से शुरू कैसे करूँ?**

प्रस्तुति के [पहले स्लाइड नंबर](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/firstslidenumber/) को सेट करें; इसके बाद सभी क्रमांक पुनः गणना किए जाएंगे। उदाहरण के लिए, आप 0 या 10 से शुरू कर सकते हैं, और शीर्षक स्लाइड पर नंबर को छिपा सकते हैं।

**PDF/इमेज/HTML में निर्यात करते समय हेडर/फ़ुटर का क्या होता है?**

वे प्रस्तुति के नियमित टेक्स्ट तत्वों के रूप में रेंडर होते हैं। अर्थात यदि ये तत्व स्लाइड्स/नोट्स पृष्ठों पर दृश्यमान हैं, तो वे आउटपुट फ़ॉर्मेट में भी बाकी सामग्री के साथ दिखाई देंगे।