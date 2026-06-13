---
title: एंड्रॉइड पर प्रस्तुति स्लाइड्स क्लोन करें
linktitle: स्लाइड क्लोन करें
type: docs
weight: 35
url: /hi/androidjava/clone-slides/
keywords:
- स्लाइड क्लोन
- स्लाइड कॉपी
- स्लाइड सहेजें
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के साथ PowerPoint स्लाइड्स को डुप्लिकेट करें। सेकंड में PPT निर्माण को स्वचालित करने और मैनुअल कार्य को समाप्त करने के लिए हमारे स्पष्ट Java कोड उदाहरणों का पालन करें।"
---
## **परिचय**

क्लोनिंग वह प्रक्रिया है जिसमें किसी वस्तु की बिल्कुल समान प्रतिलिपि या पुनरुत्पादन बनाया जाता है। Aspose.Slides for Android via Java के माध्यम से किसी भी स्लाइड की कॉपी या क्लोन बनाना और फिर उस क्लोन की गई स्लाइड को वर्तमान या किसी अन्य खुले प्रस्तुतिकरण में सम्मिलित करना संभव है। स्लाइड क्लोनिंग की प्रक्रिया एक नई स्लाइड बनाती है जिसे डेवलपर्स मूल स्लाइड को बदले बिना संशोधित कर सकते हैं। स्लाइड को क्लोन करने के कई संभव तरीके हैं:

- प्रस्तुति के अंत में क्लोन बनाना।
- प्रस्तुति के भीतर किसी अन्य स्थान पर क्लोन बनाना।
- किसी अन्य प्रस्तुति के अंत में क्लोन बनाना।
- किसी अन्य प्रस्तुति में किसी अन्य स्थान पर क्लोन बनाना।
- किसी अन्य प्रस्तुति में विशिष्ट स्थान पर क्लोन बनाना।

Aspose.Slides for Android via Java में, (एक संग्रह [ISlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlide) ऑब्जेक्ट्स) जो [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) ऑब्जेक्ट द्वारा उजागर किया गया है, [addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) और [insertClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) मेथड्स प्रदान करता है ताकि उपरोक्त प्रकार की स्लाइड क्लोनिंग की जा सके।

## **एक प्रस्तुति के अंत में स्लाइड क्लोन करें**
यदि आप एक स्लाइड को क्लोन करना चाहते हैं और फिर उसी प्रस्तुति फ़ाइल में मौजूदा स्लाइडों के अंत में उपयोग करना चाहते हैं, तो नीचे दी गई क्रमिक चरणों के अनुसार [addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) मेथड का उपयोग करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
2. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) ऑब्जेक्ट द्वारा उजागर किए गए Slides संग्रह का संदर्भ लेकर [ISlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#getSlides--) क्लास को इंस्टैंशियेट करें।
3. [ISlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#getSlides--) ऑब्जेक्ट द्वारा उजागर [addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) मेथड को कॉल करें और क्लोन करने के लिए स्लाइड को पैरामीटर के रूप में पास करें।
4. संशोधित प्रस्तुति फ़ाइल को लिखें।

नीचे दिए गए उदाहरण में, हमने प्रस्तुति के पहले स्थान (शून्य इंडेक्स) पर स्थित एक स्लाइड को प्रस्तुति के अंत में क्लोन किया है।

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // इच्छित स्लाइड को उसी प्रस्तुति में स्लाइड संग्रह के अंत में क्लोन करें
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // संशोधित प्रस्तुति को डिस्क पर लिखें
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **एक प्रस्तुति के भीतर किसी अन्य स्थान पर स्लाइड क्लोन करें**
यदि आप एक स्लाइड को क्लोन करना चाहते हैं और फिर उसी प्रस्तुति फ़ाइल में अलग स्थान पर उपयोग करना चाहते हैं, तो [insertClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) मेथड का उपयोग करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
2. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) ऑब्जेक्ट द्वारा उजागर किए गए **Slides** संग्रह का संदर्भ लेकर क्लास को इंस्टैंशियेट करें।
3. [ISlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#getSlides--) ऑब्जेक्ट द्वारा उजागर [insertClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) मेथड को कॉल करें और क्लोन करने वाली स्लाइड के साथ नए स्थान के इंडेक्स को पैरामीटर के रूप में पास करें।
4. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने प्रस्तुति के शून्य इंडेक्स (स्थिति 1) पर स्थित एक स्लाइड को इंडेक्स 1 (स्थिति 2) पर क्लोन किया है।

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंशिएट करें
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // इच्छित स्लाइड को उसी प्रस्तुति में स्लाइड संग्रह के अंत में क्लोन करें
    ISlideCollection slds = pres.getSlides();

    // इच्छित स्लाइड को उसी प्रस्तुति में निर्दिष्ट इंडेक्स पर क्लोन करें
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // संशोधित प्रस्तुति को डिस्क पर लिखें
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **एक अन्य प्रस्तुति के अंत में स्लाइड क्लोन करें**
यदि आपको एक प्रस्तुति से स्लाइड को क्लोन कर उसे किसी अन्य प्रस्तुति फ़ाइल के अंत में जोड़ना है:

1. स्रोत प्रस्तुति को सम्मिलित करने वाला [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
2. गंतव्य प्रस्तुति को सम्मिलित करने वाला [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
3. गंतव्य प्रस्तुति के [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) ऑब्जेक्ट द्वारा उजागर **Slides** संग्रह का संदर्भ लेकर [ISlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection) क्लास को इंस्टैंशियेट करें।
4. [ISlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#getSlides--) ऑब्जेक्ट द्वारा उजागर [addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) मेथड को कॉल करें और स्रोत प्रस्तुति से स्लाइड को पैरामीटर के रूप में पास करें।
5. संशोधित गंतव्य प्रस्तुति फ़ाइल को लिखें।

नीचे दिए गए उदाहरण में, हमने स्रोत प्रस्तुति के पहले इंडेक्स से एक स्लाइड को गंतव्य प्रस्तुति के अंत में क्लोन किया है।

```java
// सोर्स प्रस्तुति फ़ाइल को लोड करने के लिए Presentation क्लास को इंस्टैंशिएट करें
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // डेस्टिनेशन PPTX (जहां स्लाइड को क्लोन करना है) के लिए Presentation क्लास को इंस्टैंशिएट करें
    Presentation destPres = new Presentation();
    try {
        // सोर्स प्रस्तुति से इच्छित स्लाइड को डेस्टिनेशन प्रस्तुति में स्लाइड संग्रह के अंत में क्लोन करें
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // डेस्टिनेशन प्रस्तुति को डिस्क पर लिखें
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **एक अन्य प्रस्तुति में किसी अन्य स्थान पर स्लाइड क्लोन करें**
यदि आपको एक प्रस्तुति से स्लाइड को क्लोन कर उसे किसी अन्य प्रस्तुति फ़ाइल में विशिष्ट स्थान पर डालना है:

1. स्रोत प्रस्तुति को सम्मिलित करने वाला [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
2. गंतव्य प्रस्तुति को सम्मिलित करने वाला [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
3. गंतव्य प्रस्तुति के [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) ऑब्जेक्ट द्वारा उजागर Slides संग्रह का संदर्भ लेकर [ISlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#getSlides--) क्लास को इंस्टैंशियेट करें।
4. [ISlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#getSlides--) ऑब्जेक्ट द्वारा उजागर [insertClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) मेथड को कॉल करें और स्रोत प्रस्तुति से स्लाइड को इच्छित स्थिति के साथ पैरामीटर के रूप में पास करें।
5. संशोधित गंतव्य प्रस्तुति फ़ाइल को लिखें।

नीचे दिए गए उदाहरण में, हमनें स्रोत प्रस्तुति के शून्य इंडेक्स से एक स्लाइड को गंतव्य प्रस्तुति के इंडेक्स 1 (स्थिति 2) पर क्लोन किया है।

```java
// स्रोत प्रस्तुति फ़ाइल को लोड करने के लिए Presentation क्लास को इंस्टैंशिएट करें
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // लक्ष्य PPTX (जहां स्लाइड को क्लोन करना है) के लिए Presentation क्लास को इंस्टैंशिएट करें
    Presentation destPres = new Presentation();
    try {
        // स्रोत प्रस्तुति से इच्छित स्लाइड को लक्ष्य प्रस्तुति में स्लाइड संग्रह के अंत में क्लोन करें
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // लक्ष्य प्रस्तुति को डिस्क पर लिखें
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **एक अन्य प्रस्तुति में विशिष्ट स्थान पर स्लाइड क्लोन करें**
यदि आप एक प्रस्तुति से मास्टर स्लाइड सहित किसी स्लाइड को क्लोन कर उसे दूसरी प्रस्तुति में उपयोग करना चाहते हैं, तो पहले स्रोत प्रस्तुति से इच्छित मास्टर स्लाइड को गंतव्य प्रस्तुति में क्लोन करना होगा। फिर उस क्लोन किए गए मास्टर स्लाइड का उपयोग करके स्लाइड को क्लोन किया जाता है। [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) मेथड गंतव्य प्रस्तुति से मास्टर स्लाइड की अपेक्षा करता है, स्रोत प्रस्तुति से नहीं। मास्टर के साथ स्लाइड को क्लोन करने के लिए नीचे दिए गए चरणों का पालन करें:

1. स्रोत प्रस्तुति को सम्मिलित करने वाला [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
2. गंतव्य प्रस्तुति को सम्मिलित करने वाला [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
3. स्लाइड के साथ संबंधित मास्टर स्लाइड तक पहुँचें।
4. गंतव्य प्रस्तुति के [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) ऑब्जेक्ट द्वारा उजागर Masters संग्रह का संदर्भ लेकर [IMasterSlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IMasterSlideCollection) क्लास को इंस्टैंशियेट करें।
5. [IMasterSlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IMasterSlideCollection) ऑब्जेक्ट द्वारा उजागर [addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) मेथड को कॉल करें और स्रोत PPTX से क्लोन करने के लिए मास्टर को पैरामीटर के रूप में पास करें।
6. गंतव्य प्रस्तुति के [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) ऑब्जेक्ट द्वारा उजागर Slides संग्रह का संदर्भ लेकर [ISlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#getSlides--) क्लास को सेट करें।
7. [ISlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#getSlides--) ऑब्जेक्ट द्वारा उजागर [addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) मेथड को कॉल करें और स्रोत प्रस्तुति से स्लाइड तथा मास्टर स्लाइड को पैरामीटर के रूप में पास करें।
8. संशोधित गंतव्य प्रस्तुति फ़ाइल को लिखें।

नीचे दिए गए उदाहरण में, हमने स्रोत प्रस्तुति के शून्य इंडेक्स पर स्थित एक मास्टर सहित स्लाइड को स्रोत स्लाइड के मास्टर का उपयोग करके गंतव्य प्रस्तुति के अंत में क्लोन किया है।

```java
// स्रोत प्रस्तुति फ़ाइल को लोड करने के लिए Presentation क्लास को इंस्टैंशिएट करें
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // लक्ष्य प्रस्तुति (जहां स्लाइड को क्लोन किया जाना है) के लिए Presentation क्लास को इंस्टैंशिएट करें
    Presentation destPres = new Presentation();
    try {
        // स्रोत प्रस्तुति के स्लाइड संग्रह से ISlide को इंस्टैंशिएट करें साथ ही
        // मास्टर स्लाइड
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // स्रोत प्रस्तुति से इच्छित मास्टर स्लाइड को लक्ष्य प्रस्तुति में मास्टर संग्रह में क्लोन करें
        // लक्ष्य प्रस्तुति
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // स्रोत प्रस्तुति से इच्छित मास्टर स्लाइड को लक्ष्य प्रस्तुति में मास्टर संग्रह में क्लोन करें
        // लक्ष्य प्रस्तुति
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // स्रोत प्रस्तुति से इच्छित स्लाइड को इच्छित मास्टर के साथ लक्ष्य प्रस्तुति में स्लाइड संग्रह के अंत में क्लोन करें
        // लक्ष्य प्रस्तुति में
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // लक्ष्य प्रस्तुति को डिस्क पर सहेजें
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **निर्दिष्ट सेक्शन के अंत में स्लाइड क्लोन करें**
यदि आप एक स्लाइड को क्लोन करना चाहते हैं और फिर उसी प्रस्तुति फ़ाइल में किसी अलग सेक्शन में उपयोग करना चाहते हैं, तो [**addClone**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) मेथड का उपयोग करें जो [**ISlideCollection**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection) इंटरफ़ेस द्वारा प्रदान किया गया है। Aspose.Slides for Android via Java पहली सेक्शन से स्लाइड को क्लोन कर उसे उसी प्रस्तुति के दूसरी सेक्शन में सम्मिलित करने की सुविधा देता है।

निम्नलिखित कोड स्निपेट दिखाता है कि कैसे एक स्लाइड को क्लोन करके उसे निर्दिष्ट सेक्शन में सम्मिलित किया जाए।

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// डेस्टिनेशन प्रस्तुति को डिस्क पर सहेजें
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**क्या स्पीकर नोट्स और रीव्यूयर कमेंट्स क्लोन किए जाते हैं?**

हाँ। नोट्स पेज और रीव्यू कमेंट्स क्लोन में शामिल होते हैं। यदि आप इन्हें नहीं चाहते हैं, तो सम्मिलन के बाद उन्हें [हटाएँ](/slides/hi/androidjava/presentation-notes/)।

**चार्ट और उनके डेटा स्रोतों को कैसे संभाला जाता है?**

चार्ट ऑब्जेक्ट, फ़ॉर्मेटिंग और एम्बेडेड डेटा कॉपी किए जाते हैं। यदि चार्ट किसी बाहरी स्रोत (जैसे OLE-एम्बेडेड वर्कबुक) से लिंक किया गया था, तो वह लिंक एक [OLE ऑब्जेक्ट](/slides/hi/androidjava/manage-ole/) के रूप में बना रहता है। फ़ाइलों के बीच स्थानांतरित करने के बाद डेटा उपलब्धता और रीफ़्रेश व्यवहार की जाँच करें।

**क्या मैं क्लोन की सम्मिलन स्थिति और सेक्शन को नियंत्रित कर सकता हूँ?**

हां। आप क्लोन को विशिष्ट स्लाइड इंडेक्स पर सम्मिलित कर सकते हैं और इसे इच्छित [सेक्शन](/slides/hi/androidjava/slide-section/) में रख सकते हैं। यदि लक्ष्य सेक्शन मौजूद नहीं है, तो पहले उसे बनाएं और फिर स्लाइड को उसमें ले जाएँ।