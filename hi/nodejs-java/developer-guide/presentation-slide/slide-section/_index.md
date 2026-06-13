---
title: प्रस्तुतियों में जावास्क्रिप्ट का उपयोग करके स्लाइड अनुभागों को प्रबंधित करें
linktitle: स्लाइड अनुभाग
type: docs
weight: 90
url: /hi/nodejs-java/slide-section/
keywords:
- अनुभाग बनाएँ
- अनुभाग जोड़ें
- अनुभाग संपादित करें
- अनुभाग बदलें
- अनुभाग नाम
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के साथ PowerPoint और OpenDocument में स्लाइड अनुभागों को सरल बनाएँ — विभाजित करें, नाम बदलें, और क्रम बदलिए ताकि PPTX और ODP कार्यप्रवाह को अनुकूलित किया जा सके।"
---
## **परिचय**

Aspose.Slides for Node.js via Java का उपयोग करके आप PowerPoint प्रस्तुति को अनुभागों में व्यवस्थित कर सकते हैं। आप विशिष्ट स्लाइडों को समाहित करने वाले अनुभाग बना सकते हैं।

आप निम्न स्थितियों में अनुभाग बनाकर उन्हें स्लाइडों को व्यवस्थित या विभाजित करने के लिए उपयोग कर सकते हैं:

- जब आप बड़े प्रस्तुति पर अन्य लोगों या टीम के साथ काम कर रहे हों—और आपको कुछ स्लाइडें किसी सहयोगी या टीम सदस्य को सौंपनी हों।  
- जब आपके पास बहुत सारी स्लाइडों वाली प्रस्तुति हो—और आप एक बार में उसकी सामग्री को प्रबंधित या संपादित करने में कठिनाई महसूस कर रहे हों।

आदर्श रूप से, आपको समान स्लाइडों को समाहित करने वाला एक अनुभाग बनाना चाहिए—स्लाइडों में कुछ समानता हो या वे किसी नियम के आधार पर समूह में हो सकें—और उस अनुभाग को ऐसा नाम देना चाहिए जो उसके भीतर की स्लाइडों का वर्णन करे।

## **प्रस्तुति में अनुभाग बनाना**

प्रस्तुति में स्लाइडों को समाहित करने वाला एक अनुभाग जोड़ने के लिए, Aspose.Slides for Node.js via Java [addSection()](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SectionCollection#addSection-java.lang.String-aspose.slides.ISlide-) मेथड प्रदान करता है जो आपको वह अनुभाग नाम निर्दिष्ट करने की अनुमति देता है जिसे आप बनाना चाहते हैं और वह स्लाइड जिससे वह अनुभाग शुरू होता है।

यह उदाहरण कोड आपको JavaScript में प्रस्तुति में एक अनुभाग बनाने का तरीका दिखाता है:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var defaultSlide = pres.getSlides().get_Item(0);
    var newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    var section1 = pres.getSections().addSection("Section 1", newSlide1);
    var section2 = pres.getSections().addSection("Section 2", newSlide3);// section1 newSlide2 पर समाप्त होगा और उसके बाद section2 शुरू होगा
    pres.save("pres-sections.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", aspose.slides.SaveFormat.Pptx);
    pres.getSections().removeSectionWithSlides(section2);
    pres.getSections().appendEmptySection("Last empty section");
    pres.save("pres-section-with-empty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अनुभागों के नाम बदलना**

PowerPoint प्रस्तुति में एक अनुभाग बनाने के बाद, आप उसका नाम बदलना चाह सकते हैं।

यह उदाहरण कोड आपको Aspose.Slides का उपयोग करके JavaScript में प्रस्तुति में किसी अनुभाग के नाम को कैसे बदलें, दिखाता है:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**क्या PPT (PowerPoint 97–2003) फ़ॉर्मेट में सहेजने पर अनुभाग संरक्षित रहते हैं?**

नहीं। PPT फ़ॉर्मेट अनुभाग मेटाडाटा का समर्थन नहीं करता, इसलिए .ppt में सहेजने पर अनुभाग समूहण खो जाता है।

**क्या पूरे अनुभाग को "छिपाया" जा सकता है?**

नहीं। केवल व्यक्तिगत स्लाइडें ही छिपाई जा सकती हैं। एक अनुभाग के रूप में कोई "छिपा" स्थिति नहीं होती।

**क्या मैं जल्दी से स्लाइड से किसी अनुभाग को और उलट करके किसी अनुभाग की पहली स्लाइड को खोज सकता हूँ?**

हाँ। किसी अनुभाग को उसकी प्रारंभिक स्लाइड द्वारा अनन्य रूप से परिभाषित किया जाता है; किसी स्लाइड से आप निर्धारित कर सकते हैं वह किस अनुभाग में है, और किसी अनुभाग से आप उसकी पहली स्लाइड तक पहुँच सकते हैं।