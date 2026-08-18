---
title: जावास्क्रिप्ट में प्रस्तुति स्लाइड्स को क्लोन करें
linktitle: स्लाइड्स क्लोन करें
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
description: "Aspose.Slides for Node.js के साथ PowerPoint स्लाइड्स को तेज़ी से डुप्लिकेट करें। कोड उदाहरणों का पालन करके सेकंडों में PPT निर्माण को स्वचालित करें और मैन्युअल कार्य को समाप्त करें।"
---
## **परिचय**

Cloning वह प्रक्रिया है जिसमें किसी चीज़ की सटीक प्रति या प्रतिकृति बनाई जाती है। Aspose.Slides for Node.js via Java किसी भी स्लाइड की प्रति या क्लोन बनाना और फिर उस क्लोन किए गए स्लाइड को वर्तमान या किसी अन्य खुली प्रस्तुति में सम्मिलित करना संभव बनाता है। स्लाइड क्लोन करने की प्रक्रिया एक नया स्लाइड बनाती है जिसे डेवलपर्स मूल स्लाइड को बदले बिना संशोधित कर सकते हैं। स्लाइड को क्लोन करने के कई संभावित तरीके हैं:

- प्रस्तुति के भीतर अंत में क्लोन करें।
- प्रस्तुति के भीतर किसी अन्य स्थान पर क्लोन करें।
- अन्य प्रस्तुति में अंत में क्लोन करें।
- अन्य प्रस्तुति में किसी अन्य स्थान पर क्लोन करें।
- अन्य प्रस्तुति में एक विशिष्ट स्थान पर क्लोन करें।

Aspose.Slides for Node.js via Java में, (एक संग्रह जिसमें [Slide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Slide) ऑब्जेक्ट्स होते हैं) जो [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) ऑब्जेक्ट द्वारा प्रदर्शित है, [addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) और [insertClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) मेथड प्रदान करता है ताकि ऊपर बताए गए स्लाइड क्लोनिंग प्रकारों को किया जा सके।

## **प्रस्तुति के भीतर अंत में क्लोन**
यदि आप एक स्लाइड को क्लोन करके उसी प्रस्तुति फ़ाइल में मौजूदा स्लाइड्स के अंत में उपयोग करना चाहते हैं, तो नीचे सूचीबद्ध चरणों के अनुसार [addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) मेथड का उपयोग करें:

1. एक नई [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की इंस्टेंस बनाएँ।
2. Slides संग्रह को संदर्भित करके [SlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#getSlides--) क्लास को इंस्टैन्टिएट करें, जो [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) ऑब्जेक्ट द्वारा प्रदर्शित है।
3. [SlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#getSlides--) ऑब्जेक्ट द्वारा प्रदर्शित [addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) मेथड को कॉल करें और क्लोन की जाने वाली स्लाइड को [addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) मेथड के पैरामीटर के रूप में पास करें।
4. परिवर्तित प्रस्तुति फ़ाइल को लिखें।

नीचे दिए गए उदाहरण में, हमने प्रस्तुति के पहले स्थान (शून्य इंडेक्स) पर स्थित एक स्लाइड को प्रस्तुति के अंत तक क्लोन किया है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टैंस बनाएं
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // इच्छित स्लाइड को उसी प्रस्तुति में स्लाइड्स संग्रह के अंत में क्लोन करें
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // संशोधित प्रस्तुति को डिस्क पर लिखें
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **प्रस्तुति के भीतर किसी अन्य स्थान पर क्लोन**
यदि आप एक स्लाइड को क्लोन करके उसी प्रस्तुति फ़ाइल में लेकिन अलग स्थान पर उपयोग करना चाहते हैं, तो [insertClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) मेथड का उपयोग करें:

1. एक नई [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की इंस्टेंस बनाएँ।
2. **Slides** संग्रह को संदर्भित करके क्लास को इंस्टैन्टिएट करें, जो [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) ऑब्जेक्ट द्वारा प्रदर्शित है।
3. [SlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#getSlides--) ऑब्जेक्ट द्वारा प्रदर्शित [insertClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) मेथड को कॉल करें और क्लोन की जाने वाली स्लाइड को नए स्थान के इंडेक्स के साथ [insertClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) मेथड के पैरामीटर के रूप में पास करें।
4. परिवर्तित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने प्रस्तुति के इंडेक्स 1 (स्थिति 2) पर स्थित स्लाइड को इंडेक्स 2 (स्थिति 3) पर क्लोन किया है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंस करें
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // इच्छित स्लाइड को उसी प्रस्तुति में स्लाइड्स के संग्रह के अंत में क्लोन करें
    var slds = pres.getSlides();
    // इच्छित स्लाइड को उसी प्रस्तुति में निर्दिष्ट इंडेक्स पर क्लोन करें
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // संशोधित प्रस्तुति को डिस्क पर लिखें
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **अन्य प्रस्तुति में अंत में क्लोन**
यदि आपको किसी एक प्रस्तुति से स्लाइड को क्लोन करके दूसरे प्रस्तुति फ़ाइल में, मौजूदा स्लाइड्स के अंत में उपयोग करना है:

1. स्लाइड को क्लोन करने वाली स्रोत प्रस्तुति को शामिल करने वाली [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की इंस्टेंस बनाएँ।
2. स्लाइड को जोड़ने वाली गंतव्य प्रस्तुति को शामिल करने वाली [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की इंस्टेंस बनाएँ।
3. गंतव्य प्रस्तुति के Presentation ऑब्जेक्ट द्वारा प्रदर्शित **Slides** संग्रह को संदर्भित करके [SlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection) क्लास को इंस्टैन्टिएट करें।
4. [SlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#getSlides--) ऑब्जेक्ट द्वारा प्रदर्शित [addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) मेथड को कॉल करें और स्रोत प्रस्तुति से स्लाइड को [addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) मेथड के पैरामीटर के रूप में पास करें।
5. परिवर्तित गंतव्य प्रस्तुति फ़ाइल को लिखें।

नीचे दिए गए उदाहरण में, हमने स्रोत प्रस्तुति के पहले इंडेक्स से स्लाइड को गंतव्य प्रस्तुति के अंत में क्लोन किया है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// स्रोत प्रस्तुति फ़ाइल को लोड करने के लिए Presentation क्लास को इंस्टैंस करें
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // गंतव्य PPTX (जिसमें स्लाइड को क्लोन किया जाएगा) के लिए Presentation क्लास को इंस्टैंस करें
    var destPres = new aspose.slides.Presentation();
    try {
        // स्रोत प्रस्तुति से इच्छित स्लाइड को गंतव्य प्रस्तुति में स्लाइड्स संग्रह के अंत में क्लोन करें
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // गंतव्य प्रस्तुति को डिस्क पर लिखें
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **अन्य प्रस्तुति में किसी अन्य स्थान पर क्लोन**
यदि आपको किसी एक प्रस्तुति से स्लाइड को क्लोन करके दूसरे प्रस्तुति फ़ाइल में, एक विशिष्ट स्थान पर उपयोग करना है:

1. स्लाइड को क्लोन करने वाली स्रोत प्रस्तुति को शामिल करने वाली [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की इंस्टेंस बनाएँ।
2. स्लाइड को जोड़ने वाली गंतव्य प्रस्तुति को शामिल करने वाली [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की इंस्टेंस बनाएँ।
3. गंतव्य प्रस्तुति के Presentation ऑब्जेक्ट द्वारा प्रदर्शित Slides संग्रह को संदर्भित करके [SlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#getSlides--) क्लास को इंस्टैन्टिएट करें।
4. [SlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#getSlides--) ऑब्जेक्ट द्वारा प्रदर्शित [insertClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) मेथड को कॉल करें और स्रोत प्रस्तुति से स्लाइड को इच्छित स्थान के साथ [insertClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) मेथड के पैरामीटर के रूप में पास करें।
5. परिवर्तित गंतव्य प्रस्तुति फ़ाइल को लिखें।

नीचे दिए गए उदाहरण में, हमने स्रोत प्रस्तुति के शून्य इंडेक्स से स्लाइड को गंतव्य प्रस्तुति के इंडेक्स 1 (स्थिति 2) पर क्लोन किया है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// स्रोत प्रस्तुति फ़ाइल को लोड करने के लिए Presentation क्लास को इंस्टैंस करें
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // गंतव्य PPTX (जिसमें स्लाइड को क्लोन किया जाएगा) के लिए Presentation क्लास को इंस्टैंस करें
    var destPres = new aspose.slides.Presentation();
    try {
        // स्रोत प्रस्तुति से इच्छित स्लाइड को गंतव्य प्रस्तुति में स्लाइड्स संग्रह के अंत में क्लोन करें
        var slds = destPres.getSlides();
        slds.insertClone(1, srcPres.getSlides().get_Item(0));
        // गंतव्य प्रस्तुति को डिस्क पर लिखें
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **अन्य प्रस्तुति में विशिष्ट स्थान पर क्लोन**
यदि आपको एक प्रस्तुति से मास्टर स्लाइड के साथ स्लाइड को क्लोन करके दूसरे प्रस्तुति में उपयोग करना है, तो आपको पहले स्रोत प्रस्तुति से वांछित मास्टर स्लाइड को गंतव्य प्रस्तुति में क्लोन करना होगा। उसके बाद आपको उस मास्टर स्लाइड का उपयोग करके मास्टर स्लाइड के साथ स्लाइड को क्लोन करना होगा। [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) गंतव्य प्रस्तुति से मास्टर स्लाइड की अपेक्षा करता है, न कि स्रोत प्रस्तुति से। मास्टर के साथ स्लाइड को क्लोन करने के लिए, कृपया नीचे दिए गए चरणों का पालन करें:

1. स्लाइड को क्लोन करने वाली स्रोत प्रस्तुति को शामिल करने वाली [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की इंस्टेंस बनाएँ।
2. स्लाइड को क्लोन करने वाली गंतव्य प्रस्तुति को शामिल करने वाली [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) क्लास की इंस्टेंस बनाएँ।
3. क्लोन की जाने वाली स्लाइड को उसके मास्टर स्लाइड के साथ एक्सेस करें।
4. गंतव्य प्रस्तुति के [Presentation] ऑब्जेक्ट द्वारा प्रदर्शित Masters संग्रह को संदर्भित करके [MasterSlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/MasterSlideCollection) क्लास को इंस्टैन्टिएट करें।
5. [MasterSlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/MasterSlideCollection) ऑब्जेक्ट द्वारा प्रदर्शित [addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) मेथड को कॉल करें और स्रोत PPTX से क्लोन किए जाने वाले मास्टर को [addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) मेथड के पैरामीटर के रूप में पास करें।
6. गंतव्य प्रस्तुति के [Presentation] ऑब्जेक्ट द्वारा प्रदर्शित Slides संग्रह को संदर्भित करके [SlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#getSlides--) क्लास को इंस्टैन्टिएट करें।
7. [SlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#getSlides--) ऑब्जेक्ट द्वारा प्रदर्शित [addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) मेथड को कॉल करें और स्रोत प्रस्तुति से क्लोन की जाने वाली स्लाइड और मास्टर स्लाइड को [addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) मेथड के पैरामीटर के रूप में पास करें।
8. परिवर्तित गंतव्य प्रस्तुति फ़ाइल को लिखें।

नीचे दिए गए उदाहरण में, हमने स्रोत प्रस्तुति के शून्य इंडेक्स पर स्थित मास्टर के साथ एक स्लाइड को स्रोत स्लाइड के मास्टर का उपयोग करके गंतव्य प्रस्तुति के अंत में क्लोन किया है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// स्रोत प्रस्तुति फ़ाइल को लोड करने के लिए Presentation क्लास को इंस्टैंस करें
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // गंतव्य प्रस्तुति (जिसमें स्लाइड को क्लोन किया जाएगा) के लिए Presentation क्लास को इंस्टैंस करें
    var destPres = new aspose.slides.Presentation();
    try {
        // स्रोत प्रस्तुति में स्लाइड्स संग्रह से ISlide को इंस्टैंस करें साथ ही
        // मास्टर स्लाइड
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // स्रोत प्रस्तुति से इच्छित मास्टर स्लाइड को गंतव्य प्रस्तुति में मास्टर्स संग्रह में क्लोन करें
        // गंतव्य प्रस्तुति
        var masters = destPres.getMasters();
        var DestMaster = masters.addClone(SourceMaster);
        // इच्छित मास्टर के साथ स्रोत प्रस्तुति से इच्छित स्लाइड को गंतव्य प्रस्तुति में स्लाइड्स संग्रह के अंत में क्लोन करें
        // गंतव्य प्रस्तुति के स्लाइड्स संग्रह में
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);
        // गंतव्य प्रस्तुति को डिस्क पर सहेजें
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **निर्दिष्ट अनुभाग में अंत में क्लोन**
यदि आप एक स्लाइड को क्लोन करके उसी प्रस्तुति फ़ाइल में लेकिन अलग अनुभाग में उपयोग करना चाहते हैं, तो [**addClone**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) मेथड का उपयोग करें, जो [**SlideCollection**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection) क्लास द्वारा प्रदर्शित है। Aspose.Slides for Node.js via Java पहली अनुभाग से स्लाइड को क्लोन करके उसी प्रस्तुति के दूसरे अनुभाग में सम्मिलित करना संभव बनाता है।

निम्नलिखित कोड स्निपेट दर्शाता है कि कैसे एक स्लाइड को क्लोन करके क्लोन की गई स्लाइड को एक निर्दिष्ट अनुभाग में सम्मिलित किया जाए।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // गंतव्य प्रस्तुति को डिस्क पर सहेजें
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **स्लाइड आकार मिलान सुनिश्चित करें**
जब स्लाइड्स को किसी अन्य प्रस्तुति में क्लोन किया जाता है, तो सुनिश्चित करें कि गंतव्य प्रस्तुति का स्लाइड आकार स्रोत के समान हो। यदि स्लाइड आकार अलग है, तो Aspose.Slides क्लोन की गई आकृतियों का आकार स्वचालित रूप से नहीं बदलता—उनके मूल निर्देशांक और आयाम संरक्षित रहते हैं, जिससे सामग्री असम्योजित दिख सकती है या स्लाइड की सीमाओं से बाहर जा सकती है।

आप क्लोन करने से पहले गंतव्य प्रस्तुति के स्लाइड आकार को स्रोत के बराबर सेट कर सकते हैं:

```javascript
const sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), aspose.slides.SlideSizeScaleType.DoNotScale);
```

क्लोन करने से पहले मास्टर और स्लाइड दोनों के लिए यह करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या स्पीकर नोट्स और समीक्षक टिप्पणियाँ क्लोन की जाती हैं?**  
हां। नोट्स पेज और समीक्षक टिप्पणियाँ क्लोन में शामिल की जाती हैं। यदि आप इन्हें नहीं चाहते, तो सम्मिलन के बाद इन्हें [हटा दें](/slides/hi/nodejs-java/presentation-notes/)।

**चार्ट और उनके डेटा स्रोतों को कैसे संभाला जाता है?**  
चार्ट ऑब्जेक्ट, फॉर्मेटिंग और एम्बेडेड डेटा कॉपी किए जाते हैं। यदि चार्ट किसी बाहरी स्रोत (जैसे OLE-एंबेडेड वर्कबुक) से जुड़ा था, तो वह लिंक [OLE ऑब्जेक्ट](/slides/hi/nodejs-java/manage-ole/) के रूप में संरक्षित रहता है। फ़ाइलों के बीच स्थानांतरण के बाद डेटा उपलब्धता और रिफ्रेश व्यवहार की जाँच करें।

**क्या मैं क्लोन की सम्मिलन स्थिती और अनुभाग को नियंत्रित कर सकता हूँ?**  
हां। आप क्लोन को विशिष्ट स्लाइड इंडेक्स पर सम्मिलित कर सकते हैं और उसे चुने हुए [अंश](/slides/hi/nodejs-java/slide-section/) में रख सकते हैं। यदि लक्ष्य अनुभाग मौजूद नहीं है, तो पहले उसे बनायें और फिर स्लाइड को उसमें ले जाएँ।