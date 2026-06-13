---
title: जावा में प्रस्तुति हेडर और फुटर प्रबंधित करें
linktitle: हेडर और फुटर
type: docs
weight: 140
url: /hi/java/presentation-header-and-footer/
keywords:
- हेडर
- हेडर पाठ
- फुटर
- फुटर पाठ
- हेडर सेट करें
- फुटर सेट करें
- हैंडआउट
- नोट्स
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "जावा के लिए Aspose.Slides का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में हेडर और फुटर जोड़ें और अनुकूलित करें, ताकि पेशेवर रूप मिल सके।"
---
## **अवलोकन**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में हेडर और फुटर सेटिंग्स प्रबंधित करने की सुविधा देता है। हेडर और फुटर प्रस्तुति मास्टर स्तर पर संभाले जाते हैं, और API फुटर पाठ सेट करने, फुटर की दृश्यता बदलने और मास्टर नोट्स स्लाइड पर हेडर पाठ अपडेट करने के लिए विधियाँ प्रदान करता है।

आप हैंडआउट और नोट्स स्लाइड के लिए भी हेडर और फुटर प्रबंधित कर सकते हैं। इसमें नोट्स मास्टर, सभी चाइल्ड नोट्स स्लाइड या व्यक्तिगत नोट्स स्लाइड के लिए हेडर, फुटर, स्लाइड नंबर और दिनांक‑समय प्लेसहोल्डर्स की दृश्यता और पाठ बदलना शामिल है।

## **प्रस्तुति में हेडर और फुटर प्रबंधित करें**
नीचे दिखाए गए उदाहरण में कुछ विशिष्ट स्लाइड के नोट्स को हटाया जा सकता है:

```java
// प्रस्तुति लोड करें
Presentation pres = new Presentation("headerTest.pptx");
try {
    // फुटर सेट कर रहे हैं
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
// Header/Footer पाठ सेट करने की विधि
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

## **हैंडआउट और नोट्स स्लाइड पर हेडर और फुटर प्रबंधित करें**
Aspose.Slides for Java हैंडआउट और नोट्स स्लाइड में हेडर और फुटर का समर्थन करता है। कृपया नीचे दिए गए चरणों का पालन करें:

- एक वीडियो युक्त [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) लोड करें।
- नोट्स मास्टर और सभी नोट्स स्लाइड के लिए हेडर और फुटर सेटिंग्स बदलें।
- मास्टर नोट्स स्लाइड और सभी चाइल्ड फुटर प्लेसहोल्डर्स को दृश्यमान सेट करें।
- मास्टर नोट्स स्लाइड और सभी चाइल्ड दिनांक व समय प्लेसहोल्डर्स को दृश्यमान सेट करें।
- केवल पहली नोट्स स्लाइड के लिए हेडर और फुटर सेटिंग्स बदलें।
- नोट्स स्लाइड हेडर प्लेसहोल्डर को दृश्यमान सेट करें।
- नोट्स स्लाइड हेडर प्लेसहोल्डर में पाठ सेट करें।
- नोट्स स्लाइड दिनांक‑समय प्लेसहोल्डर में पाठ सेट करें।
- संशोधित प्रस्तुति फ़ाइल लिखें।

नीचे दिए गए उदाहरण में कोड स्निपेट प्रदान किया गया है।

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // नोट्स मास्टर और सभी नोट्स स्लाइड के लिए हेडर और फुटर सेटिंग बदलें
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // मास्टर नोट्स स्लाइड और सभी चाइल्ड फुटर प्लेसहोल्डर्स को दृश्यमान बनाएं
        headerFooterManager.setFooterAndChildFootersVisibility(true); // मास्टर नोट्स स्लाइड और सभी चाइल्ड हेडर प्लेसहोल्डर्स को दृश्यमान बनाएं
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // मास्टर नोट्स स्लाइड और सभी चाइल्ड स्लाइडनंबर प्लेसहोल्डर्स को दृश्यमान बनाएं
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // मास्टर नोट्स स्लाइड और सभी चाइल्ड दिनांक और समय प्लेसहोल्डर्स को दृश्यमान बनाएं

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // मास्टर नोट्स स्लाइड और सभी चाइल्ड हेडर प्लेसहोल्डर्स को पाठ सेट करें
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // मास्टर नोट्स स्लाइड और सभी चाइल्ड फुटर प्लेसहोल्डर्स को पाठ सेट करें
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // मास्टर नोट्स स्लाइड और सभी चाइल्ड दिनांक और समय प्लेसहोल्डर्स को पाठ सेट करें
    }

    // पहली नोट्स स्लाइड के लिए केवल हेडर और फुटर सेटिंग बदलें
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // इस नोट्स स्लाइड के हेडर प्लेसहोल्डर को दृश्यमान बनाएं

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // इस नोट्स स्लाइड के फुटर प्लेसहोल्डर को दृश्यमान बनाएं

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // इस नोट्स स्लाइड के स्लाइडनंबर प्लेसहोल्डर को दृश्यमान बनाएं

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // इस नोट्स स्लाइड के दिनांक‑समय प्लेसहोल्डर को दृश्यमान बनाएं

        headerFooterManager.setHeaderText("New header text"); // नोट्स स्लाइड हेडर प्लेसहोल्डर को पाठ सेट करें
        headerFooterManager.setFooterText("New footer text"); // नोट्स स्लाइड फुटर प्लेसहोल्डर को पाठ सेट करें
        headerFooterManager.setDateTimeText("New date and time text"); // नोट्स स्लाइड दिनांक‑समय प्लेसहोल्डर को पाठ सेट करें
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं नियमित स्लाइड में "हेडर" जोड़ सकता हूँ?**

PowerPoint में, "हेडर" केवल नोट्स और हैंडआउट के लिए मौजूद होता है; नियमित स्लाइड पर समर्थित तत्व फुटर, दिनांक/समय और स्लाइड नंबर हैं। Aspose.Slides में भी यही सीमाएँ हैं: हेडर केवल नोट्स/हैंडआउट के लिए, और स्लाइड पर—फुटर/दिनांक‑समय/स्लाइडनंबर।

**अगर लेआउट में फुटर क्षेत्र नहीं है—क्या मैं उसकी दृश्यता "सक्रिय" कर सकता हूँ?**

हां। हेडर/फुटर प्रबंधक के माध्यम से दृश्यता जांचें और आवश्यक होने पर इसे सक्षम करें। ये API संकेतक और विधियाँ उन मामलों के लिए डिज़ाइन की गई हैं जब प्लेसहोल्डर अनुपलब्ध या छिपा हुआ हो।

**मैं स्लाइड नंबर को 1 के अलावा किसी अन्य मान से शुरू कैसे करूँ?**

प्रस्तुति का [first slide number](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-) सेट करें; इसके बाद सभी क्रमांकन पुनः गणना किया जाता है। उदाहरण के लिए, आप 0 या 10 से शुरू कर सकते हैं, और शीर्षक स्लाइड पर नंबर को छिपा सकते हैं।

**PDF/छवियों/HTML में निर्यात करते समय हेडर/फुटर का क्या होता है?**

वे प्रस्तुति के नियमित पाठ तत्वों के रूप में रेंडर किए जाते हैं। अर्थात, यदि तत्व स्लाइड्स/नोट्स पृष्ठों पर दृश्यमान हैं, तो वे आउटपुट फॉर्मेट में अन्य सामग्री के साथ प्रदर्शित होंगे।