---
title: JavaScript में प्रस्तुति हेडर और फुटर का प्रबंधन
linktitle: हेडर और फुटर
type: docs
weight: 140
url: /hi/nodejs-java/presentation-header-and-footer/
keywords:
- हेडर
- हेडर टेक्स्ट
- फुटर
- फुटर टेक्स्ट
- हेडर सेट करें
- फुटर सेट करें
- हैंडआउट
- नोट्स
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "JavaScript और Aspose.Slides for Node.js का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में हेडर और फुटर जोड़ें और उन्हें अनुकूलित करें ताकि पेशेवर रूप प्राप्त हो।"
---
## **अवलोकन**

Aspose.Slides आपको PowerPoint प्रस्तुतियों में हेडर और फुटर सेटिंग्स को प्रबंधित करने की अनुमति देता है। हेडर और फुटर प्रस्तुति मास्टर स्तर पर संभाले जाते हैं, और API फुटर टेक्स्ट सेट करने, फुटर दृश्यमानता बदलने, और मास्टर नोट्स स्लाइड्स पर हेडर टेक्स्ट अपडेट करने के लिए मेथड्स प्रदान करता है।

आप हैंडआउट और नोट्स स्लाइड्स के लिए भी हेडर और फुटर का प्रबंधन कर सकते हैं। इसमें नोट्स मास्टर, सभी चाइल्ड नोट्स स्लाइड्स, या व्यक्तिगत नोट्स स्लाइड के लिए हेडर, फुटर, स्लाइड क्रमांक, और तिथि‑समय प्लेसहोल्डर्स की दृश्यमानता और टेक्स्ट बदलना शामिल है।

## **प्रेजेंटेशन में हेडर और फुटर प्रबंधन**

नीचे के उदाहरण में दिखाए अनुसार कुछ विशिष्ट स्लाइड की नोट्स को हटाया जा सकता है:

```javascript
// प्रस्तुति लोड करें
var pres = new aspose.slides.Presentation("headerTest.pptx");
try {
    // फुटर सेट करना
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);
    // हेडर तक पहुंचें और अपडेट करें
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide) {
        updateHeaderFooterText(masterNotesSlide);
    }
    // प्रस्तुति सहेजें
    pres.save("HeaderFooterJava.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function updateHeaderFooterText(master) {
    let shapes = master.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i); 
        if (shape.getPlaceholder() !== null) {
            if (shape.getPlaceholder().getType() === aspose.PlaceholderType.Header) {
                shape.getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **हैंडआउट और नोट्स स्लाइड्स में हेडर और फुटर का प्रबंधन**

Aspose.Slides for Node.js via Java हैंडआउट और नोट्स स्लाइड्स में हेडर और फुटर का समर्थन करता है। कृपया नीचे दिए गए चरणों का पालन करें:

- एक वीडियो वाली [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) लोड करें।
- नोट्स मास्टर और सभी नोट्स स्लाइड्स के लिए हेडर और फुटर सेटिंग्स बदलें।
- मास्टर नोट्स स्लाइड और सभी चाइल्ड फुटर प्लेसहोल्डर्स को दृश्यमान सेट करें।
- मास्टर नोट्स स्लाइड और सभी चाइल्ड तिथि एवं समय प्लेसहोल्डर्स को दृश्यमान सेट करें।
- केवल पहली नोट्स स्लाइड के लिए हेडर और फुटर सेटिंग्स बदलें।
- नोट्स स्लाइड हेडर प्लेसहोल्डर को दृश्यमान सेट करें।
- नोट्स स्लाइड हेडर प्लेसहोल्डर के टेक्स्ट को सेट करें।
- नोट्स स्लाइड तिथि‑समय प्लेसहोल्डर के टेक्स्ट को सेट करें।
- संशोधित प्रेजेंटेशन फ़ाइल लिखें।

नीचे के उदाहरण में कोड स्निपेट प्रदान किया गया है।

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    // नोट्स मास्टर और सभी नोट्स स्लाइड्स के लिए हेडर और फुटर सेटिंग्स बदलें
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null) {
        var headerFooterManager = masterNotesSlide.getHeaderFooterManager();
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);// मास्टर नोट्स स्लाइड और सभी चाइल्ड फुटर प्लेसहोल्डर्स को दृश्यमान बनाएं
        headerFooterManager.setFooterAndChildFootersVisibility(true);// मास्टर नोट्स स्लाइड और सभी चाइल्ड हेडर प्लेसहोल्डर्स को दृश्यमान बनाएं
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);// मास्टर नोट्स स्लाइड और सभी चाइल्ड स्लाइडनंबर प्लेसहोल्डर्स को दृश्यमान बनाएं
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);// मास्टर नोट्स स्लाइड और सभी चाइल्ड तिथि और समय प्लेसहोल्डर्स को दृश्यमान बनाएं
        headerFooterManager.setHeaderAndChildHeadersText("Header text");// मास्टर नोट्स स्लाइड और सभी चाइल्ड हेडर प्लेसहोल्डर्स पर टेक्स्ट सेट करें
        headerFooterManager.setFooterAndChildFootersText("Footer text");// मास्टर नोट्स स्लाइड और सभी चाइल्ड फुटर प्लेसहोल्डर्स पर टेक्स्ट सेट करें
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");// मास्टर नोट्स स्लाइड और सभी चाइल्ड तिथि और समय प्लेसहोल्डर्स पर टेक्स्ट सेट करें
    }
    // केवल पहली नोट्स स्लाइड के लिए हेडर और फुटर सेटिंग्स बदलें
    var notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null) {
        var headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible()) {
            headerFooterManager.setHeaderVisibility(true);
        }// इस नोट्स स्लाइड के हेडर प्लेसहोल्डर को दृश्यमान बनाएं
        if (!headerFooterManager.isFooterVisible()) {
            headerFooterManager.setFooterVisibility(true);
        }// इस नोट्स स्लाइड के फुटर प्लेसहोल्डर को दृश्यमान बनाएं
        if (!headerFooterManager.isSlideNumberVisible()) {
            headerFooterManager.setSlideNumberVisibility(true);
        }// इस नोट्स स्लाइड के स्लाइडनंबर प्लेसहोल्डर को दृश्यमान बनाएं
        if (!headerFooterManager.isDateTimeVisible()) {
            headerFooterManager.setDateTimeVisibility(true);
        }// इस नोट्स स्लाइड के तिथि‑समय प्लेसहोल्डर को दृश्यमान बनाएं
        headerFooterManager.setHeaderText("New header text");// नोट्स स्लाइड के हेडर प्लेसहोल्डर पर टेक्स्ट सेट करें
        headerFooterManager.setFooterText("New footer text");// नोट्स स्लाइड के फुटर प्लेसहोल्डर पर टेक्स्ट सेट करें
        headerFooterManager.setDateTimeText("New date and time text");// नोट्स स्लाइड के तिथि‑समय प्लेसहोल्डर पर टेक्स्ट सेट करें
    }
    pres.save("testresult.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं नियमित स्लाइड्स में "header" जोड़ सकता हूँ?**

PowerPoint में, "Header" केवल नोट्स और हैंडआउट के लिए ही मौजूद है; नियमित स्लाइड्स पर समर्थित तत्व फुटर, तिथि/समय, और स्लाइड क्रमांक हैं। Aspose.Slides में भी यही सीमाएँ लागू होती हैं: हेडर केवल नोट्स/हैंडआउट के लिए, और स्लाइड्स पर—Footer/DateTime/SlideNumber।

**यदि लेआउट में फुटर क्षेत्र नहीं है—क्या मैं उसकी दृश्यमानता "चालू" कर सकता हूँ?**

हाँ। हेडर/फुटर मैनेजर द्वारा दृश्यमानता जांचें और आवश्यक होने पर इसे सक्षम करें। ये API संकेतक और मेथड्स उन मामलों के लिए डिज़ाइन किए गए हैं जब प्लेसहोल्डर अनुपस्थित या छिपा हो।

**मैं स्लाइड क्रमांक को 1 के अलावा किसी मान से शुरू कैसे करूँ?**

प्रेजेंटेशन का [first slide number](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) सेट करें; इसके बाद सभी क्रमांकन पुनः गणना हो जाता है। उदाहरण के लिए, आप 0 या 10 से शुरू कर सकते हैं, और टाइटल स्लाइड पर क्रमांक को छिपा सकते हैं।

**PDF/इमेज/HTML में निर्यात करते समय हेडर/फुटर पर क्या प्रभाव पड़ता है?**

वे प्रेजेंटेशन के सामान्य टेक्स्ट तत्वों के रूप में रेंडर होते हैं। अर्थात, यदि तत्व स्लाइड्स/नोट्स पृष्ठों पर दृश्यमान हैं, तो वे आउटपुट फ़ॉर्मेट में बाकी सामग्री के साथ दिखाई देंगे।