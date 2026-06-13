---
title: एन्ड्रॉइड पर प्रस्तुति हेडर और फुटर प्रबंधित करें
linktitle: हेडर & फुटर
type: docs
weight: 140
url: /hi/androidjava/presentation-header-and-footer/
keywords:
- हेडर
- हेडर टेक्स्ट
- फुटर
- फुटर टेक्स्ट
- सेट हेडर
- सेट फुटर
- हैंडआउट
- नोट्स
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "एन्ड्रॉइड के लिए जावा के माध्यम से Aspose.Slides का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में हेडर और फुटर जोड़ें और अनुकूलित करें, ताकि पेशेवर रूप प्राप्त हो सके।"
---
## **समीक्षा**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में हेडर और फुटर सेटिंग्स को प्रबंधित करने की सुविधा देता है। हेडर और फुटर प्रस्तुति मास्टर स्तर पर संभाले जाते हैं, और API फुटर पाठ सेट करने, फुटर की दृश्यता बदलने और मास्टर नोट्स स्लाइड पर हेडर पाठ को अद्यतन करने के लिए मेथड प्रदान करता है।

आप हैंडआउट और नोट्स स्लाइड्स के लिए भी हेडर और फुटर प्रबंधित कर सकते हैं। इसमें नोट्स मास्टर, सभी चाइल्ड नोट्स स्लाइड्स, या व्यक्तिगत नोट्स स्लाइड के लिए हेडर, फुटर, स्लाइड नंबर और दिनांक‑समय प्लेसहोल्डर की दृश्यता और पाठ को बदलना शामिल है।

## **प्रस्तुति में हेडर और फुटर प्रबंधन**
नीचे दी गई उदाहरण में दिखाए अनुसार कुछ विशिष्ट स्लाइड की नोट्स को हटाया जा सकता है:

```java
// प्रस्तुति लोड करें
Presentation pres = new Presentation("headerTest.pptx");
try {
    // फ़ुटर सेट करना
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // हेडर तक पहुँचें और अपडेट करें
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide)
    {
        updateHeaderFooterText(masterNotesSlide);
    }

    // प्रस्तुति सहेजें
    pres.save("HeaderFooterJava.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// हेडर/फुटर टेक्स्ट सेट करने की विधि
public static void updateHeaderFooterText(IBaseSlide master)
{
    for (IShape shape : master.getShapes())
    {
        if (shape.getPlaceholder() != null)
        {
            if (shape.getPlaceholder().getType() == PlaceholderType.Header)
            {
                ((IAutoShape)shape).getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **हैंडआउट और नोट्स स्लाइड्स पर हेडर और फुटर प्रबंधन**
Aspose.Slides for Android via Java हैंडआउट और नोट्स स्लाइड्स में हेडर और फुटर का समर्थन करता है। कृपया नीचे दिए गए चरणों का पालन करें:

- वीडियो युक्त एक [प्रस्तुति](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) लोड करें।
- नोट्स मास्टर और सभी नोट्स स्लाइड्स के लिए हेडर और फुटर सेटिंग्स बदलें।
- मास्टर नोट्स स्लाइड और सभी चाइल्ड फुटर प्लेसहोल्डर को दर्शनीय बनाएं।
- मास्टर नोट्स स्लाइड और सभी चाइल्ड दिनांक‑समय प्लेसहोल्डर को दर्शनीय बनाएं।
- केवल पहली नोट्स स्लाइड के लिए हेडर और फुटर सेटिंग्स बदलें।
- नोट्स स्लाइड हेडर प्लेसहोल्डर को दर्शनीय बनाएं।
- नोट्स स्लाइड हेडर प्लेसहोल्डर में पाठ सेट करें।
- नोट्स स्लाइड दिनांक‑समय प्लेसहोल्डर में पाठ सेट करें।
- संशोधित प्रस्तुति फ़ाइल लिखें।

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // नोट्स मास्टर और सभी नोट्स स्लाइड्स के लिए हेडर और फुटर सेटिंग्स बदलें
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // मास्टर नोट्स स्लाइड और सभी चाइल्ड फुटर प्लेसहोल्डर को दृश्यमान बनाएं
        headerFooterManager.setFooterAndChildFootersVisibility(true); // मास्टर नोट्स स्लाइड और सभी चाइल्ड हेडर प्लेसहोल्डर को दृश्यमान बनाएं
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // मास्टर नोट्स स्लाइड और सभी चाइल्ड स्लाइडनंबर प्लेसहोल्डर को दृश्यमान बनाएं
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // मास्टर नोट्स स्लाइड और सभी चाइल्ड दिनांक और समय प्लेसहोल्डर को दृश्यमान बनाएं

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // टेक्स्ट को मास्टर नोट्स स्लाइड और सभी चाइल्ड हेडर प्लेसहोल्डर पर सेट करें
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // टेक्स्ट को मास्टर नोट्स स्लाइड और सभी चाइल्ड फुटर प्लेसहोल्डर पर सेट करें
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // टेक्स्ट को मास्टर नोट्स स्लाइड और सभी चाइल्ड दिनांक और समय प्लेसहोल्डर पर सेट करें
    }

    // केवल पहले नोट्स स्लाइड के लिए हेडर और फुटर सेटिंग्स बदलें
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // इस नोट्स स्लाइड हेडर प्लेसहोल्डर को दृश्यमान बनाएं

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // इस नोट्स स्लाइड फुटर प्लेसहोल्डर को दृश्यमान बनाएं

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // इस नोट्स स्लाइड स्लाइडनंबर प्लेसहोल्डर को दृश्यमान बनाएं

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // इस नोट्स स्लाइड दिनांक‑समय प्लेसहोल्डर को दृश्यमान बनाएं

        headerFooterManager.setHeaderText("New header text"); // नोट्स स्लाइड हेडर प्लेसहोल्डर पर टेक्स्ट सेट करें
        headerFooterManager.setFooterText("New footer text"); // नोट्स स्लाइड फुटर प्लेसहोल्डर पर टेक्स्ट सेट करें
        headerFooterManager.setDateTimeText("New date and time text"); // नोट्स स्लाइड दिनांक‑समय प्लेसहोल्डर पर टेक्स्ट सेट करें
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं सामान्य स्लाइड्स पर "header" जोड़ सकता हूँ?**

PowerPoint में, "Header" केवल नोट्स और हैंडआउट के लिए मौजूद है; सामान्य स्लाइड्स पर समर्थित तत्व फुटर, दिनांक/समय, और स्लाइड नंबर होते हैं। Aspose.Slides में भी यही सीमाएं लागू होती हैं: हेडर केवल नोट्स/हैंडआउट के लिए, और स्लाइड्स पर—फ़ुटर/DateTime/SlideNumber।

**यदि लेआउट में फुटर क्षेत्र नहीं है—क्या मैं उसकी दृश्यता "ऑन" कर सकता हूँ?**

हां। हेडर/फ़ुटर प्रबंधन के माध्यम से दृश्यता जांचें और आवश्यकता होने पर इसे सक्रिय करें। ये API संकेतक और मेथड्स उन मामलों के लिए डिज़ाइन किए गए हैं जब प्लेसहोल्डर अनुपस्थित या छिपा हो।

**मैं स्लाइड नंबर को 1 से अलग मान से शुरू कैसे करूं?**

प्रस्तुति का [पहला स्लाइड नंबर](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) सेट करें; इसके बाद सभी क्रमांक पुनः गणना किए जाते हैं। उदाहरण के लिए, आप 0 या 10 से शुरू कर सकते हैं, और शीर्षक स्लाइड पर नंबर को छिपा सकते हैं।

**PDF/इमेज/HTML में निर्यात करते समय हेडर/फ़ुटर का क्या होता है?**

वे प्रस्तुति के सामान्य टेक्स्ट तत्वों के रूप में रेंडर किए जाते हैं। अर्थात, यदि ये तत्व स्लाइड्स/नोट्स पृष्ठों पर दृश्यमान हैं, तो वे आउटपुट फ़ॉर्मेट में भी बाकी सामग्री के साथ दिखाई देंगे।