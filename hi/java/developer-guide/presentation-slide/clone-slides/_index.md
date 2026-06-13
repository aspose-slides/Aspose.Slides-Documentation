---
title: "जावा में प्रेज़ेंटेशन स्लाइड्स क्लोन करें"
linktitle: "स्लाइड क्लोन करें"
type: docs
weight: 35
url: /hi/java/clone-slides/
keywords:
- स्लाइड क्लोन
- स्लाइड कॉपी
- स्लाइड सहेजें
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint स्लाइड्स को जल्दी से डुप्लिकेट करें। सेकंड में PPT निर्माण को स्वचालित करने के लिए हमारे स्पष्ट कोड उदाहरणों का पालन करें और मैनुअल कार्य को समाप्त करें।"
---
## **परिचय**

क्लोनिंग वह प्रक्रिया है जिसके द्वारा किसी वस्तु की सटीक प्रतिलिपि या नकल बनाई जाती है। Aspose.Slides for Java भी किसी भी स्लाइड की कॉपी या क्लोन बनाना और फिर उस क्लोन की गई स्लाइड को वर्तमान या किसी अन्य खुले प्रेजेंटेशन में सम्मिलित करना संभव बनाता है। स्लाइड क्लोनिंग की प्रक्रिया एक नई स्लाइड बनाती है जिसे डेवलपर्स मूल स्लाइड को बदले बिना संशोधित कर सकते हैं। स्लाइड को क्लोन करने के कई संभावित तरीके हैं:

- प्रेजेंटेशन के भीतर अंत में क्लोन करें।
- प्रेजेंटेशन के भीतर किसी अन्य स्थान पर क्लोन करें।
- दूसरे प्रेजेंटेशन में अंत में क्लोन करें।
- दूसरे प्रेजेंटेशन में किसी अन्य स्थान पर क्लोन करें।
- दूसरे प्रेजेंटेशन में एक विशिष्ट स्थान पर क्लोन करें।

Aspose.Slides for Java में, (एक संग्रह [ISlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlide) ऑब्जेक्ट्स का) जिसे [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) ऑब्जेक्ट द्वारा उजागर किया गया है, वह [addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) और [insertClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) मेथड्स प्रदान करता है जिससे उपर्युक्त प्रकार के स्लाइड क्लोन किए जा सकते हैं।

## **प्रेजेंटेशन के अंत में एक स्लाइड क्लोन करें**
यदि आप एक स्लाइड को क्लोन करना चाहते हैं और फिर उसे उसी प्रेजेंटेशन फ़ाइल में मौजूदा स्लाइडों के अंत में उपयोग करना चाहते हैं, तो नीचे सूचीबद्ध चरणों के अनुसार [addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) मेथड का उपयोग करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएँ।
1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) ऑब्जेक्ट द्वारा उजागर किए गए Slides संग्रह का संदर्भ देकर [ISlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getSlides--) क्लास का इंस्टेंस बनाएँ।
1. [ISlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getSlides--) ऑब्जेक्ट द्वारा उजागर किए गए [addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) मेथड को कॉल करें और क्लोन की जाने वाली स्लाइड को [addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) मेथड के पैरामीटर के रूप में पास करें।
1. संशोधित प्रेजेंटेशन फ़ाइल लिखें।

नीचे दिए गए उदाहरण में, हमने प्रेजेंटेशन की पहली स्थिति—शून्य इंडेक्स—पर स्थित स्लाइड को प्रेजेंटेशन के अंत में क्लोन किया है।

```java
// प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // इच्छित स्लाइड को उसी प्रेज़ेंटेशन में स्लाइड्स संग्रह के अंत में क्लोन करें
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // संशोधित प्रेज़ेंटेशन को डिस्क पर लिखें
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **प्रेजेंटेशन के भीतर किसी अन्य स्थान पर स्लाइड क्लोन करें**
यदि आप एक स्लाइड को क्लोन करना चाहते हैं और फिर उसे उसी प्रेजेंटेशन फ़ाइल में लेकिन किसी अलग स्थान पर उपयोग करना चाहते हैं, तो [insertClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) मेथड का उपयोग करें:

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएँ।
1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) ऑब्जेक्ट द्वारा उजागर किए गए **Slides** संग्रह का संदर्भ देकर क्लास का इंस्टेंस बनाएँ।
1. [ISlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getSlides--) ऑब्जेक्ट द्वारा उजागर किए गए [insertClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) मेथड को कॉल करें और क्लोन की जाने वाली स्लाइड को नए स्थान के सूचकांक के साथ [insertClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) मेथड के पैरामीटर में पास करें।
1. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने प्रेजेंटेशन के शून्य इंडेक्स—स्थिति 1—पर स्थित स्लाइड को इंडेक्स 1—स्थिति 2—पर क्लोन किया है।

```java
// प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // इच्छित स्लाइड को उसी प्रेज़ेंटेशन में स्लाइड्स संग्रह के अंत में क्लोन करें
    ISlideCollection slds = pres.getSlides();

    // इच्छित स्लाइड को उसी प्रेज़ेंटेशन में निर्दिष्ट इंडेक्स पर क्लोन करें
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // संशोधित प्रेज़ेंटेशन को डिस्क पर लिखें
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **दूसरे प्रेजेंटेशन के अंत में स्लाइड क्लोन करें**
यदि आपको एक प्रेजेंटेशन से स्लाइड को क्लोन करके दूसरे प्रेजेंटेशन फ़ाइल में, मौजूदा स्लाइडों के अंत में उपयोग करने की आवश्यकता है:

1. उस प्रेजेंटेशन को सम्मिलित करने वाले [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएँ जिससे स्लाइड क्लोन किया जाएगा।
1. उस लक्ष्य प्रेजेंटेशन को सम्मिलित करने वाले [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएँ जिसमें स्लाइड जोड़ी जाएगी।
1. लक्ष्य प्रेजेंटेशन के Presentation ऑब्जेक्ट द्वारा उजागर किए गए **Slides** संग्रह का संदर्भ देकर [ISlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection) क्लास का इंस्टेंस बनाएँ।
1. [ISlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getSlides--) ऑब्जेक्ट द्वारा उजागर किए गए [addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) मेथड को कॉल करें और स्रोत प्रेजेंटेशन से स्लाइड को [addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) मेथड के पैरामीटर के रूप में पास करें।
1. संशोधित लक्ष्य प्रेजेंटेशन फ़ाइल लिखें।

नीचे दिए गए उदाहरण में, हमने स्रोत प्रेजेंटेशन के पहले इंडेक्स से स्लाइड को लक्ष्य प्रेजेंटेशन के अंत में क्लोन किया है।

```java
// स्रोत प्रेज़ेंटेशन फ़ाइल को लोड करने के लिए Presentation क्लास का इंस्टेंस बनाएं
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // गंतव्य PPTX (जहां स्लाइड को क्लोन किया जाएगा) के लिए Presentation क्लास का इंस्टेंस बनाएं
    Presentation destPres = new Presentation();
    try {
        // स्रोत प्रेज़ेंटेशन से इच्छित स्लाइड को गंतव्य प्रेज़ेंटेशन में स्लाइड्स संग्रह के अंत में क्लोन करें
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // गंतव्य प्रेज़ेंटेशन को डिस्क पर लिखें
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **दूसरे प्रेजेंटेशन में किसी अन्य स्थान पर स्लाइड क्लोन करें**
यदि आपको एक प्रेजेंटेशन से स्लाइड को क्लोन करके दूसरे प्रेजेंटेशन फ़ाइल में, एक विशिष्ट स्थान पर उपयोग करने की आवश्यकता है:

1. स्लाइड को स्रोत प्रेजेंटेशन से क्लोन करने वाले [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएँ।
1. स्लाइड को लक्ष्य प्रेजेंटेशन में जोड़ने वाले [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएँ।
1. लक्ष्य प्रेजेंटेशन के Presentation ऑब्जेक्ट द्वारा उजागर किए गए Slides संग्रह का संदर्भ देकर [ISlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getSlides--) क्लास का इंस्टेंस बनाएँ।
1. [ISlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getSlides--) ऑब्जेक्ट द्वारा उजागर किए गए [insertClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) मेथड को कॉल करें और स्रोत प्रेजेंटेशन से स्लाइड को इच्छित स्थान के साथ [insertClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) मेथड के पैरामीटर में पास करें।
1. संशोधित लक्ष्य प्रेजेंटेशन फ़ाइल लिखें।

नीचे दिए गए उदाहरण में, हमने स्रोत प्रेजेंटेशन के शून्य इंडेक्स से स्लाइड को लक्ष्य प्रेजेंटेशन के इंडेक्स 1 (स्थिति 2) पर क्लोन किया है।

```java
// स्रोत प्रेज़ेंटेशन फ़ाइल को लोड करने के लिए Presentation क्लास का इंस्टेंस बनाएं
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // गंतव्य PPTX (जहां स्लाइड को क्लोन किया जाएगा) के लिए Presentation क्लास का इंस्टेंस बनाएं
    Presentation destPres = new Presentation();
    try {
        // स्रोत प्रेज़ेंटेशन से इच्छित स्लाइड को गंतव्य प्रेज़ेंटेशन में स्लाइड्स संग्रह के अंत में क्लोन करें
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // गंतव्य प्रेज़ेंटेशन को डिस्क पर लिखें
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **दूसरे प्रेजेंटेशन में विशिष्ट स्थान पर स्लाइड क्लोन करें**
यदि आपको एक प्रेजेंटेशन से मास्टर स्लाइड के साथ स्लाइड को क्लोन करके दूसरे प्रेजेंटेशन में उपयोग करने की आवश्यकता है, तो पहले आपको स्रोत प्रेजेंटेशन से वांछित मास्टर स्लाइड को लक्ष्य प्रेजेंटेशन में क्लोन करना होगा। फिर उस मास्टर स्लाइड का उपयोग करके स्लाइड क्लोन करें। [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) मेथड लक्ष्य प्रेजेंटेशन के मास्टर स्लाइड की अपेक्षा करता है, न कि स्रोत प्रेजेंटेशन की। मास्टर के साथ स्लाइड क्लोन करने के लिए नीचे दिए गए चरणों का पालन करें:

1. स्लाइड को स्रोत प्रेजेंटेशन से क्लोन करने वाले [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएँ।
1. स्लाइड को लक्ष्य प्रेजेंटेशन में क्लोन करने वाले [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएँ।
1. मास्टर स्लाइड के साथ क्लोन की जाने वाली स्लाइड तक पहुंचें।
1. लक्ष्य प्रेजेंटेशन के Presentation ऑब्जेक्ट द्वारा उजागर किए गए Masters संग्रह का संदर्भ देकर [IMasterSlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IMasterSlideCollection) क्लास का इंस्टेंस बनाएँ।
1. [IMasterSlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IMasterSlideCollection) ऑब्जेक्ट द्वारा उजागर किए गए [addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) मेथड को कॉल करें और स्रोत PPTX से क्लोन किए जाने वाले मास्टर को [addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) मेथड के पैरामीटर में पास करें।
1. लक्ष्य प्रेजेंटेशन के Presentation ऑब्जेक्ट द्वारा उजागर किए गए Slides संग्रह का संदर्भ सेट करके [ISlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getSlides--) क्लास का इंस्टेंस बनाएँ।
1. [ISlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getSlides--) ऑब्जेक्ट द्वारा उजागर किए गए [addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) मेथड को कॉल करें और स्रोत प्रेजेंटेशन से क्लोन की जाने वाली स्लाइड तथा मास्टर स्लाइड को [addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) मेथड के पैरामीटर में पास करें।
1. संशोधित लक्ष्य प्रेजेंटेशन फ़ाइल लिखें।

नीचे दिया गया उदाहरण स्रोत प्रेजेंटेशन के शून्य इंडेक्स से मास्टर के साथ स्लाइड को लक्ष्य प्रेजेंटेशन के अंत में क्लोन करता है।

```java
// स्रोत प्रेज़ेंटेशन फ़ाइल को लोड करने के लिए Presentation क्लास का इंस्टेंस बनाएं
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // गंतव्य प्रेज़ेंटेशन (जहां स्लाइड को क्लोन किया जाएगा) के लिए Presentation क्लास का इंस्टेंस बनाएं
    Presentation destPres = new Presentation();
    try {
        // स्रोत प्रेज़ेंटेशन में स्लाइड्स संग्रह से ISlide को बनाएं साथ में
        // मास्टर स्लाइड
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // स्रोत प्रेज़ेंटेशन से इच्छित मास्टर स्लाइड को गंतव्य प्रेज़ेंटेशन के मास्टर्स संग्रह में क्लोन करें
        // गंतव्य प्रेज़ेंटेशन
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // स्रोत प्रेज़ेंटेशन से इच्छित मास्टर स्लाइड को गंतव्य प्रेज़ेंटेशन के मास्टर्स संग्रह में क्लोन करें
        // गंतव्य प्रेज़ेंटेशन
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // स्रोत प्रेज़ेंटेशन से इच्छित स्लाइड को इच्छित मास्टर के साथ गंतव्य प्रेज़ेंटेशन में स्लाइड्स संग्रह के अंत में क्लोन करें
        // गंतव्य प्रेज़ेंटेशन में स्लाइड्स संग्रह
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // गंतव्य प्रेज़ेंटेशन को डिस्क पर सेव करें
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **निर्दिष्ट सेक्शन के अंत में स्लाइड क्लोन करें**
यदि आप एक स्लाइड को क्लोन करके उसी प्रेजेंटेशन फ़ाइल में लेकिन किसी अलग सेक्शन में उपयोग करना चाहते हैं, तो [addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) मेथड का उपयोग करें जिसे [ISlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection) इंटरफ़ेस द्वारा उजागर किया गया है। Aspose.Slides for Java पहली सेक्शन से स्लाइड क्लोन करके उसी प्रेजेंटेशन की दूसरी सेक्शन में सम्मिलित करने की सुविधा प्रदान करता है।

निम्न कोड स्निपेट दर्शाता है कि कैसे स्लाइड को क्लोन किया जाए और क्लोन की गई स्लाइड को निर्दिष्ट सेक्शन में सम्मिलित किया जाए।

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// गंतव्य प्रेज़ेंटेशन को डिस्क पर सहेजें
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या स्पीकर नोट्स और रिव्यूअर कमेंट्स क्लोन होते हैं?**

हाँ। नोट्स पेज और रिव्यू कमेंट्स क्लोन में शामिल होते हैं। यदि आप इन्हें नहीं चाहते, तो सम्मिलित करने के बाद [उन्हें हटाएँ](/slides/hi/java/presentation-notes/)।

**चार्ट और उनके डेटा स्रोतों को कैसे संभाला जाता है?**

चार्ट ऑब्जेक्ट, फॉर्मेटिंग, और एम्बेडेड डेटा कॉपी किया जाता है। यदि चार्ट किसी बाहरी स्रोत (जैसे OLE-एम्बेडेड वर्कबुक) से जुड़ा था, तो वह लिंक एक [OLE ऑब्जेक्ट](/slides/hi/java/manage-ole/) के रूप में संरक्षित रहता है। फ़ाइलों के बीच स्थानांतरण के बाद डेटा उपलब्धता और रीफ्रेश व्यवहार की पुष्टि करें।

**क्या मैं क्लोन के सम्मिलन स्थान और सेक्शन को नियंत्रित कर सकता हूँ?**

हाँ। आप क्लोन को विशिष्ट स्लाइड इंडेक्स पर सम्मिलित कर सकते हैं और उसे चुने हुए [सेक्शन](/slides/hi/java/slide-section/) में रख सकते हैं। यदि लक्ष्य सेक्शन मौजूद नहीं है, तो पहले उसे बनाएँ और फिर स्लाइड को उसमें ले जाएँ।