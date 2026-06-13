---
title: जावास्क्रिप्ट में प्रेज़ेंटेशन स्लाइड्स को क्लोन करें
linktitle: स्लाइड क्लोन
type: docs
weight: 35
url: /hi/nodejs-java/clone-slides/
keywords:
  - स्लाइड क्लोन
  - स्लाइड कॉपी
  - स्लाइड सहेजें
  - PowerPoint
  - OpenDocument
  - प्रस्तुति
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Aspose.Slides for Node.js के साथ PowerPoint स्लाइड्स को तेज़ी से डुप्लिकेट करें। सेकंडों में PPT निर्माण को स्वचालित करने और मैनुअल काम को समाप्त करने के लिए हमारे कोड उदाहरणों का पालन करें।"
---
## **परिचय**

क्लोनिंग वह प्रक्रिया है जिसमें किसी वस्तु की सटीक प्रति या प्रतिलिपि बनायी़ जाती है। Aspose.Slides for Node.js via Java भी किसी भी स्लाइड की कॉपी या क्लोन बनाना और उसे वर्तमान या किसी अन्य खुले प्रेजेंटेशन में सम्मिलित करना संभव बनाता है। स्लाइड क्लोनिंग प्रक्रिया एक नई स्लाइड बनाती है जिसे डेवलपर्स मूल स्लाइड को बदले बिना संशोधित कर सकते हैं। स्लाइड क्लोन करने के कई संभावित तरीके हैं:

- प्रस्तुति के भीतर अंत में क्लोन करें।
- प्रस्तुति के भीतर किसी अन्य स्थिति में क्लोन करें।
- किसी अन्य प्रस्तुति में अंत में क्लोन करें।
- किसी अन्य प्रस्तुति में किसी अन्य स्थिति में क्लोन करें।
- किसी अन्य प्रस्तुति में विशिष्ट स्थिति पर क्लोन करें।

Aspose.Slides for Node.js via Java में, (एक संग्रह जिसमें [Slide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Slide) वस्तुएँ हैं) जो [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) वस्तु द्वारा उजागर किया गया है, [addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) और [insertClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) विधियों को प्रदान करता है ताकि ऊपर बताए गए स्लाइड क्लोनिंग प्रकारों को किया जा सके।

## **प्रेजेंटेशन के भीतर अंत में क्लोन**
यदि आप किसी स्लाइड को क्लोन करके उसी प्रेजेंटेशन फ़ाइल के मौजूदा स्लाइड्स के अंत में उपयोग करना चाहते हैं, तो नीचे सूचीबद्ध चरणों के अनुसार [addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) विधि का उपयोग करें:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) वस्तु द्वारा उजागर किए गए Slides संग्रह का संदर्भ लेकर [SlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#getSlides--) क्लास का एक इंस्टेंस बनाएँ।
1. [SlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#getSlides--) वस्तु द्वारा उजागर किए गए [addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) विधि को कॉल करें और क्लोन की जाने वाली स्लाइड को पैरामीटर के रूप में पास करें।
1. संशोधित प्रेजेंटेशन फ़ाइल को लिखें।

नीचे दिए गए उदाहरण में, हमने पहली स्थिति (शून्य इंडेक्स) पर स्थित स्लाइड को प्रेजेंटेशन के अंत में क्लोन किया है।

```javascript
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // वांछित स्लाइड को उसी प्रस्तुति में स्लाइड्स के संग्रह के अंत में क्लोन करें
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // संशोधित प्रस्तुति को डिस्क में लिखें
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **प्रेजेंटेशन में किसी अन्य स्थिति में क्लोन**
यदि आप किसी स्लाइड को क्लोन करके उसी प्रेजेंटेशन फ़ाइल में लेकिन अलग स्थिति पर उपयोग करना चाहते हैं, तो [insertClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) विधि का उपयोग करें:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) वस्तु द्वारा उजागर किए गए **Slides** संग्रह का संदर्भ लेकर क्लास को इंस्टेंसिएट करें।
1. [SlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#getSlides--) वस्तु द्वारा उजागर किए गए [insertClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) विधि को कॉल करें और क्लोन की जाने वाली स्लाइड तथा नई स्थिति का इंडेक्स पैरामीटर के रूप में पास करें।
1. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने शून्य इंडेक्स (स्थिति 1) पर स्थित स्लाइड को इंडेक्स 1 (स्थिति 2) पर क्लोन किया है।

```javascript
// प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // इसी प्रेज़ेंटेशन में स्लाइड्स के संग्रह के अंत में वांछित स्लाइड को क्लोन करें
    var slds = pres.getSlides();
    // इसी प्रेज़ेंटेशन में निर्दिष्ट इंडेक्स पर वांछित स्लाइड को क्लोन करें
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // संशोधित प्रेज़ेंटेशन को डिस्क में लिखें
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **किसी अन्य प्रस्तुति में अंत में क्लोन**
यदि आप एक प्रस्तुति से स्लाइड को क्लोन करके उसे किसी अन्य प्रस्तुति फ़ाइल के मौजूदा स्लाइड्स के अंत में उपयोग करना चाहते हैं:

1. स्रोत प्रस्तुति वाली [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
1. गंतव्य प्रस्तुति वाली [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
1. गंतव्य प्रस्तुति के Presentation वस्तु द्वारा उजागर किए गए **Slides** संग्रह का संदर्भ लेकर [SlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection) क्लास को इंस्टेंसिएट करें।
1. [SlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#getSlides--) वस्तु द्वारा उजागर किए गए [addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) विधि को कॉल करें और स्रोत प्रस्तुति से स्लाइड को पैरामीटर के रूप में पास करें।
1. संशोधित गंतव्य प्रस्तुति फ़ाइल को लिखें।

नीचे दिए गए उदाहरण में, हमने स्रोत प्रस्तुति के पहले इंडेक्स से स्लाइड को गंतव्य प्रस्तुति के अंत में क्लोन किया है।

```javascript
// स्रोत प्रेज़ेंटेशन फ़ाइल को लोड करने के लिए Presentation क्लास को इंस्टैंसिएट करें
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // गंतव्य PPTX (जहाँ स्लाइड क्लोन की जानी है) के लिए Presentation क्लास को इंस्टैंसिएट करें
    var destPres = new aspose.slides.Presentation();
    try {
        // स्रोत प्रेज़ेंटेशन से इच्छित स्लाइड को गंतव्य प्रेज़ेंटेशन में स्लाइड्स के संग्रह के अंत में क्लोन करें
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // गंतव्य प्रेज़ेंटेशन को डिस्क में लिखें
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **किसी अन्य प्रस्तुति में किसी अन्य स्थिति में क्लोन**
यदि आप एक प्रस्तुति से स्लाइड को क्लोन करके उसे किसी अन्य प्रस्तुति फ़ाइल में विशिष्ट स्थिति पर उपयोग करना चाहते हैं:

1. स्रोत प्रस्तुति वाली [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
1. गंतव्य प्रस्तुति वाली [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
1. गंतव्य प्रस्तुति के Presentation वस्तु द्वारा उजागर किए गए Slides संग्रह का संदर्भ लेकर [SlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#getSlides--) क्लास को इंस्टेंसिएट करें।
1. [SlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#getSlides--) वस्तु द्वारा उजागर किए गए [insertClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) विधि को कॉल करें और स्रोत प्रस्तुति से स्लाइड तथा इच्छित स्थिति को पैरामीटर के रूप में पास करें।
1. संशोधित गंतव्य प्रस्तुति फ़ाइल को लिखें।

नीचे दिए गए उदाहरण में, हमने स्रोत प्रस्तुति के शून्य इंडेक्स से स्लाइड को गंतव्य प्रस्तुति के इंडेक्स 1 (स्थिति 2) पर क्लोन किया है।

```javascript
// स्रोत प्रेज़ेंटेशन फ़ाइल को लोड करने के लिए Presentation क्लास को इंस्टैंसिएट करें
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // गंतव्य PPTX (जहाँ स्लाइड क्लोन की जानी है) के लिए Presentation क्लास को इंस्टैंसिएट करें
    var destPres = new aspose.slides.Presentation();
    try {
        // स्रोत प्रेज़ेंटेशन से इच्छित स्लाइड को गंतव्य प्रेज़ेंटेशन में स्लाइड्स के संग्रह के अंत में क्लोन करें
        var slds = destPres.getSlides();
        slds.insertClone(2, srcPres.getSlides().get_Item(0));
        // गंतव्य प्रेज़ेंटेशन को डिस्क में लिखें
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **किसी अन्य प्रस्तुति में विशिष्ट स्थिति में क्लोन**
यदि आप किसी प्रस्तुति से मास्टर स्लाइड के साथ स्लाइड को क्लोन करके उसे किसी अन्य प्रस्तुति में उपयोग करना चाहते हैं, तो पहले स्रोत प्रस्तुति से इच्छित मास्टर स्लाइड को गंतव्य प्रस्तुति में क्लोन करना आवश्यक है। उसके बाद उस मास्टर स्लाइड का उपयोग करके स्लाइड को क्लोन किया जाता है। [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) विधि गंतव्य प्रस्तुति से मास्टर स्लाइड उम्मीद करती है, स्रोत प्रस्तुति से नहीं। मास्टर स्लाइड के साथ स्लाइड को क्लोन करने के लिए नीचे दिए गए चरणों का पालन करें:

1. स्रोत प्रस्तुति वाली [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
1. गंतव्य प्रस्तुति वाली [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
1. स्लाइड को मास्टर स्लाइड के साथ एक्सेस करें।
1. गंतव्य प्रस्तुति के Presentation वस्तु द्वारा उजागर किए गए Masters संग्रह का संदर्भ लेकर [MasterSlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/MasterSlideCollection) क्लास को इंस्टेंसिएट करें।
1. [MasterSlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/MasterSlideCollection) वस्तु द्वारा उजागर किए गए [addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) विधि को कॉल करें और स्रोत PPTX से क्लोन की जाने वाली मास्टर स्लाइड को पैरामीटर के रूप में पास करें।
1. गंतव्य प्रस्तुति के Presentation वस्तु द्वारा उजागर किए गए Slides संग्रह का संदर्भ लेकर [SlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#getSlides--) क्लास को इंस्टेंसिएट करें।
1. [SlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#getSlides--) वस्तु द्वारा उजागर किए गए [addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) विधि को कॉल करें और स्रोत प्रस्तुति से स्लाइड तथा मास्टर स्लाइड को पैरामीटर के रूप में पास करें।
1. संशोधित गंतव्य प्रस्तुति फ़ाइल को लिखें।

नीचे दिए गए उदाहरण में, हमने स्रोत प्रस्तुति के शून्य इंडेक्स पर स्थित स्लाइड को स्रोत स्लाइड की मास्टर का उपयोग करके गंतव्य प्रस्तुति के अंत में क्लोन किया है।

```javascript
// स्रोत प्रस्तुति फ़ाइल को लोड करने के लिए Presentation क्लास को इंस्टैंसिएट करें
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // गंतव्य प्रस्तुति (जहाँ स्लाइड को क्लोन किया जाना है) के लिए Presentation क्लास को इंस्टैंसिएट करें
    var destPres = new aspose.slides.Presentation();
    try {
        // स्रोत प्रस्तुति में स्लाइड्स के संग्रह से ISlide को इंस्टैंसिएट करें साथ में
        // मास्टर स्लाइड
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // स्रोत प्रस्तुति से इच्छित मास्टर स्लाइड को लक्षित प्रस्तुति के मास्टर्स के संग्रह में क्लोन करें
        // गंतव्य प्रस्तुति
        var masters = destPres.getMasters();
        var DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // स्रोत प्रस्तुति से इच्छित मास्टर स्लाइड को लक्षित प्रस्तुति के मास्टर्स के संग्रह में क्लोन करें
        // गंतव्य प्रस्तुति
        var iSlide = masters.addClone(SourceMaster);
        // स्रोत प्रस्तुति से इच्छित स्लाइड को इच्छित मास्टर के साथ गंतव्य प्रस्तुति में स्लाइड्स के संग्रह के अंत में क्लोन करें
        // गंतव्य प्रस्तुति में स्लाइड्स के संग्रह
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);
        // गंतव्य प्रस्तुति को डिस्क में सहेजें
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **निर्दिष्ट अनुभाग में अंत में क्लोन**
यदि आप किसी स्लाइड को क्लोन करके उसे उसी प्रेजेंटेशन फ़ाइल के अलग अनुभाग में उपयोग करना चाहते हैं, तो [**addClone**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) विधि का उपयोग करें जो [**SlideCollection**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection) क्लास द्वारा प्रदान की जाती है। Aspose.Slides for Node.js via Java पहली अनुभाग से स्लाइड को क्लोन कर उसे उसी प्रेजेंटेशन के दूसरे अनुभाग में सम्मिलित करना संभव बनाता है।

निम्नलिखित कोड स्निपेट दर्शाता है कि कैसे स्लाइड को क्लोन करके क्लोन किए गए स्लाइड को निर्दिष्ट अनुभाग में सम्मिलित किया जाता है।

```javascript
var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // गंतव्य प्रस्तुति को डिस्क में सहेजें
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या स्पीकर नोट्स और रिव्यूअर कमेंट्स क्लोन होते हैं?**

हाँ। नोट्स पेज और समीक्षा टिप्पणियाँ क्लोन में शामिल होती हैं। यदि आप उन्हें नहीं चाहते हैं, तो सम्मिलन के बाद उन्हें [हटा](/slides/hi/nodejs-java/presentation-notes/) दें।

**चार्ट और उनके डेटा स्रोत कैसे संभाले जाते हैं?**

चार्ट ऑब्जेक्ट, फ़ॉर्मेटिंग और एंबेडेड डेटा कॉपी किए जाते हैं। यदि चार्ट बाहरी स्रोत (जैसे OLE‑एंबेडेड वर्कबुक) से जुड़ा था, तो वह लिंक एक [OLE ऑब्जेक्ट](/slides/hi/nodejs-java/manage-ole/) के रूप में संरक्षित रहता है। फ़ाइलों के बीच स्थानांतरण के बाद डेटा उपलब्धता और रिफ्रेश व्यवहार की जाँच करें।

**क्या मैं क्लोन की सम्मिलन स्थिति और अनुभाग को नियंत्रित कर सकता हूँ?**

हाँ। आप क्लोन को किसी विशिष्ट स्लाइड इंडेक्स पर सम्मिलित कर सकते हैं और उसे चुनी हुई [section](/slides/hi/nodejs-java/slide-section/) में रख सकते हैं। यदि लक्ष्य अनुभाग मौजूद नहीं है, तो पहले उसे बनाएँ और फिर स्लाइड को उसमें ले जाएँ।