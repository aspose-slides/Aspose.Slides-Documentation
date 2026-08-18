---
title: जावा में प्रेज़ेंटेशन स्लाइड्स क्लोन करें
linktitle: स्लाइड्स क्लोन करें
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
description: "Aspose.Slides for Java के साथ PowerPoint स्लाइड्स को शीघ्रता से डुप्लिकेट करें। सेकंडों में PPT निर्माण को स्वचालित करने और मैन्युअल काम को समाप्त करने के लिए हमारे स्पष्ट कोड उदाहरणों का पालन करें।"
---
## **परिचय**

क्लोनिंग वह प्रक्रिया है जिसमें किसी वस्तु की सटीक प्रतिलिपि या दोहराव बनाया जाता है। Aspose.Slides for Java किसी भी स्लाइड की कॉपी या क्लोन बनाना और फिर उस क्लोन की गई स्लाइड को वर्तमान या किसी अन्य खुले प्रेज़ेंटेशन में सम्मिलित करना संभव बनाता है। स्लाइड क्लोनिंग प्रक्रिया एक नई स्लाइड बनाती है जिसे डेवलपर्स मूल स्लाइड को बदले बिना संशोधित कर सकते हैं। स्लाइड क्लोन करने के कई संभावित तरीके हैं:

- प्रस्तुतिकरण के भीतर अंत में क्लोन करें।
- प्रस्तुतिकरण के भीतर दूसरे स्थान पर क्लोन करें।
- किसी अन्य प्रस्तुतिकरण के अंत में क्लोन करें।
- किसी अन्य प्रस्तुतिकरण में दूसरे स्थान पर क्लोन करें।
- उसकी मास्टर स्लाइड के साथ क्लोन करके किसी अन्य प्रस्तुतिकरण में ले जाएँ।

Aspose.Slides for Java में, (एक संग्रह जिसमें [ISlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlide) ऑब्जेक्ट होते हैं) जो [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) ऑब्जेक्ट द्वारा उजागर किया गया है, वह ऊपर बताई गई स्लाइड क्लोनिंग प्रकारों को करने के लिए [addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) और [insertClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) मेथड्स प्रदान करता है।

## **प्रेज़ेंटेशन के अंत में स्लाइड क्लोन करें**
यदि आप एक स्लाइड को क्लोन करके उसी प्रेज़ेंटेशन फ़ाइल में मौजूदा स्लाइडों के अंत में उपयोग करना चाहते हैं, तो नीचे दिए गए चरणों के अनुसार [addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) मेथड का उपयोग करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) ऑब्जेक्ट द्वारा उजागर किए गए Slides संग्रह को संदर्भित करके [ISlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getSlides--) क्लास का इंस्टेंस बनाएँ।
1. [ISlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getSlides--) ऑब्जेक्ट द्वारा उजागर किए गए [addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) मेथड को कॉल करें और क्लोन की जाने वाली स्लाइड को पैरामीटर के रूप में पास करें।
1. संशोधित प्रेज़ेंटेशन फ़ाइल लिखें।

नीचे दिए गए उदाहरण में, हमने एक स्लाइड (जो प्रेज़ेंटेशन में पहले स्थान – शून्य इंडेक्स – पर थी) को प्रेज़ेंटेशन के अंत में क्लोन किया है।

```java
import com.aspose.slides.*;

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // इच्छित स्लाइड को उसी प्रस्तुति में स्लाइड संग्रह के अंत में क्लोन करें
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // परिवर्तित प्रस्तुति को डिस्क पर लिखें
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **प्रेज़ेंटेशन के भीतर किसी अन्य स्थान पर स्लाइड क्लोन करें**
यदि आप एक स्लाइड को क्लोन करके उसी प्रेज़ेंटेशन फ़ाइल में लेकिन अलग स्थान पर उपयोग करना चाहते हैं, तो [insertClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) मेथड का उपयोग करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) ऑब्जेक्ट द्वारा उजागर किए गए **Slides** संग्रह को संदर्भित करके क्लास का इंस्टेंस बनाएँ।
1. [ISlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getSlides--) ऑब्जेक्ट द्वारा उजागर किए गए [insertClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) मेथड को कॉल करें और क्लोन की जाने वाली स्लाइड तथा नए स्थान के इंडेक्स को पैरामीटर के रूप में पास करें।
1. संशोधित प्रेज़ेंटेशन को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में, हमने एक स्लाइड (जो प्रेज़ेंटेशन में इंडेक्स 1 – स्थान 2 – पर थी) को इंडेक्स 2 – स्थान 3 – पर क्लोन किया है।

```java
import com.aspose.slides.*;

// एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // प्रेज़ेंटेशन में स्लाइड्स का संग्रह प्राप्त करें
    ISlideCollection slds = pres.getSlides();

    // इच्छित स्लाइड को उसी प्रेज़ेंटेशन में निर्दिष्ट इंडेक्स पर क्लोन करें
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // परिवर्तित प्रेज़ेंटेशन को डिस्क पर लिखें
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **किसी अन्य प्रेज़ेंटेशन के अंत में स्लाइड क्लोन करें**
यदि आपको एक प्रेज़ेंटेशन से स्लाइड क्लोन करके उसे दूसरे प्रेज़ेंटेशन फ़ाइल में, मौजूदा स्लाइडों के अंत में सम्मिलित करना है:

1. उस प्रेज़ेंटेशन को सम्मिलित करने वाले [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ जिससे स्लाइड क्लोन की जाएगी।
1. लक्ष्य प्रेज़ेंटेशन को सम्मिलित करने वाले [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
1. लक्ष्य प्रेज़ेंटेशन के Presentation ऑब्जेक्ट द्वारा उजागर किए गए **Slides** संग्रह को संदर्भित करके [ISlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection) क्लास का इंस्टेंस बनाएँ।
1. [ISlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getSlides--) ऑब्जेक्ट द्वारा उजागर किए गए [addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) मेथड को कॉल करें और स्रोत प्रेज़ेंटेशन से स्लाइड को पैरामीटर के रूप में पास करें।
1. संशोधित लक्ष्य प्रेज़ेंटेशन फ़ाइल लिखें।

नीचे दिए गए उदाहरण में, हमने स्रोत प्रेज़ेंटेशन के पहले इंडेक्स से एक स्लाइड को लक्ष्य प्रेज़ेंटेशन के अंत में क्लोन किया है।

```java
import com.aspose.slides.*;

// स्रोत प्रस्तुति फ़ाइल को लोड करने के लिए Presentation क्लास को इंस्टैंसिएट करें
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // गंतव्य PPTX (जहाँ स्लाइड क्लोन की जाएगी) के लिए Presentation क्लास को इंस्टैंसिएट करें
    Presentation destPres = new Presentation();
    try {
        // स्रोत प्रस्तुति से इच्छित स्लाइड को गंतव्य प्रस्तुति में स्लाइड संग्रह के अंत में क्लोन करें
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // गंतव्य प्रस्तुति को डिस्क पर लिखें
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **किसी अन्य प्रेज़ेंटेशन में किसी अन्य स्थान पर स्लाइड क्लोन करें**
यदि आपको एक प्रेज़ेंटेशन से स्लाइड क्लोन करके उसे किसी अन्य प्रेज़ेंटेशन फ़ाइल में, किसी विशिष्ट स्थान पर उपयोग करना है:

1. स्रोत प्रेज़ेंटेशन को सम्मिलित करने वाले [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
1. लक्ष्य प्रेज़ेंटेशन को सम्मिलित करने वाले [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
1. लक्ष्य प्रेज़ेंटेशन के Presentation ऑब्जेक्ट द्वारा उजागर किए गए Slides संग्रह को संदर्भित करके [ISlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getSlides--) क्लास का इंस्टेंस बनाएँ।
1. [ISlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getSlides--) ऑब्जेक्ट द्वारा उजागर किए गए [insertClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) मेथड को कॉल करें और स्रोत प्रेज़ेंटेशन से स्लाइड के साथ वांछित स्थान को पैरामीटर के रूप में पास करें।
1. संशोधित लक्ष्य प्रेज़ेंटेशन फ़ाइल लिखें।

नीचे दिए गए उदाहरण में, हमने स्रोत प्रेज़ेंटेशन के शून्य इंडेक्स से एक स्लाइड को लक्ष्य प्रेज़ेंटेशन के इंडेक्स 1 (स्थान 2) पर क्लोन किया है।

```java
import com.aspose.slides.*;

// स्रोत प्रस्तुति फ़ाइल को लोड करने के लिए Presentation क्लास को इंस्टैंसिएट करें
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // गंतव्य PPTX (जहाँ स्लाइड क्लोन की जाएगी) के लिए Presentation क्लास को इंस्टैंसिएट करें
    Presentation destPres = new Presentation();
    try {
        // स्रोत प्रस्तुति से इच्छित स्लाइड को गंतव्य प्रस्तुति में निर्दिष्ट इंडेक्स पर क्लोन करें
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // गंतव्य प्रस्तुति को डिस्क पर लिखें
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **क्लोन के साथ उसकी मास्टर स्लाइड को किसी अन्य प्रेज़ेंटेशन में ले जाएँ**
यदि आपको एक प्रेज़ेंटेशन से स्लाइड और उसकी मास्टर स्लाइड को क्लोन करके किसी अन्य प्रेज़ेंटेशन में उपयोग करना है, तो पहले स्रोत प्रेज़ेंटेशन से वांछित मास्टर स्लाइड को लक्ष्य प्रेज़ेंटेशन में क्लोन करना होगा। फिर उस मास्टर स्लाइड का उपयोग करके स्लाइड को क्लोन किया जाता है। [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) मेथड लक्ष्य प्रेज़ेंटेशन की मास्टर स्लाइड की अपेक्षा करता है, न कि स्रोत की। स्लाइड को मास्टर के साथ क्लोन करने के लिए नीचे दिए गए चरणों का पालन करें:

1. स्रोत प्रेज़ेंटेशन को सम्मिलित करने वाले [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
1. लक्ष्य प्रेज़ेंटेशन को सम्मिलित करने वाले [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक इंस्टेंस बनाएँ।
1. क्लोन की जाने वाली स्लाइड को उसकी मास्टर स्लाइड के साथ एक्सेस करें।
1. लक्ष्य प्रेज़ेंटेशन के Presentation ऑब्जेक्ट द्वारा उजागर किए गए Masters संग्रह को संदर्भित करके [IMasterSlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IMasterSlideCollection) क्लास का इंस्टेंस बनाएँ।
1. [IMasterSlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IMasterSlideCollection) ऑब्जेक्ट द्वारा उजागर किए गए [addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) मेथड को कॉल करें और स्रोत PPTX से क्लोन की जाने वाली मास्टर स्लाइड को पैरामीटर के रूप में पास करें।
1. लक्ष्य प्रेज़ेंटेशन के Presentation ऑब्जेक्ट द्वारा उजागर किए गए Slides संग्रह को संदर्भित करके [ISlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getSlides--) क्लास का इंस्टेंस बनाएँ।
1. [ISlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getSlides--) ऑब्जेक्ट द्वारा उजागर किए गए [addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) मेथड को कॉल करें और स्रोत प्रेज़ेंटेशन से स्लाइड तथा मास्टर स्लाइड को पैरामीटर के रूप में पास करें।
1. संशोधित लक्ष्य प्रेज़ेंटेशन फ़ाइल लिखें।

नीचे दिए गए उदाहरण में, हमने स्रोत प्रेज़ेंटेशन के शून्य इंडेक्स पर स्थित स्लाइड को उसकी मास्टर के साथ लक्ष्य प्रेज़ेंटेशन के अंत में क्लोन किया है, जहाँ स्रोत स्लाइड की मास्टर का उपयोग किया गया है।

```java
import com.aspose.slides.*;

// स्रोत प्रस्तुति फ़ाइल को लोड करने के लिए Presentation क्लास को इंस्टैंसिएट करें
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // गंतव्य प्रस्तुति (जहाँ स्लाइड क्लोन की जाएगी) के लिए Presentation क्लास को इंस्टैंसिएट करें
    Presentation destPres = new Presentation();
    try {
        // स्रोत प्रस्तुति में स्लाइड संग्रह से ISlide को साथ में
        // मास्टर स्लाइड के साथ इंस्टैंसिएट करें
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // स्रोत प्रस्तुति से इच्छित मास्टर स्लाइड को गंतव्य प्रस्तुति के मास्टर संग्रह में क्लोन करें
        // गंतव्य प्रस्तुति
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = masters.addClone(SourceMaster);

        // स्रोत प्रस्तुति से इच्छित स्लाइड को इच्छित मास्टर के साथ गंतव्य प्रस्तुति के स्लाइड संग्रह के अंत में क्लोन करें
        // गंतव्य प्रस्तुति
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);

        // गंतव्य प्रस्तुति को डिस्क पर सहेजें
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **निर्दिष्ट सेक्शन के अंत में स्लाइड क्लोन करें**
यदि आप एक स्लाइड को क्लोन करके उसी प्रेज़ेंटेशन फ़ाइल में लेकिन किसी अलग सेक्शन में उपयोग करना चाहते हैं, तो [**addClone**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) मेथड का उपयोग करें जो [**ISlideCollection**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlideCollection) इंटरफ़ेस द्वारा प्रदान किया गया है। Aspose.Slides for Java आपको पहले सेक्शन से स्लाइड क्लोन करके उसी प्रेज़ेंटेशन के दूसरे सेक्शन में सम्मिलित करने की सुविधा देता है।

निम्नलिखित कोड स्निपेट दर्शाता है कि कैसे स्लाइड को क्लोन करके क्लोन की गई स्लाइड को निर्दिष्ट सेक्शन में डालें।

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);

    // गंतव्य प्रस्तुति को डिस्क पर सहेजें
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **स्लाइड आकार का मिलान सुनिश्चित करें**

जब स्लाइडों को किसी अन्य प्रेज़ेंटेशन में क्लोन किया जाता है, तो सुनिश्चित करें कि लक्ष्य प्रेज़ेंटेशन का स्लाइड आकार स्रोत के समान हो। यदि स्लाइड आकार भिन्न हैं, तो Aspose.Slides क्लोन की गई शैप्स को स्वतः रिस्केल नहीं करता—उनके मूल निर्देशांक और आयाम बरकरार रहते हैं, जिससे सामग्री असमान रूप से दिखाई दे सकती है या स्लाइड सीमाओं से बाहर निकल सकती है।

क्लोन करने से पहले स्रोत के साथ मिलाने के लिए लक्ष्य प्रेज़ेंटेशन का स्लाइड आकार इस प्रकार सेट कर सकते हैं:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

क्लोन करने से पहले मास्टर और स्लाइड के आकार को मिलाएँ।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या स्पीकर नोट्स और रिव्यूअर कमेंट्स क्लोन होते हैं?**

हँ। नोट्स पेज और रिव्यू कमेंट्स क्लोन में शामिल होते हैं। यदि आप इन्हें नहीं चाहते तो सम्मिलन के बाद इन्हें [हटा](/slides/hi/java/presentation-notes/) दें।

**चार्ट और उनके डेटा स्रोत कैसे संभाले जाते हैं?**

चार्ट ऑब्जेक्ट, फॉर्मेटिंग और एम्बेडेड डेटा कॉपी हो जाता है। यदि चार्ट बाहरी स्रोत (जैसे OLE-एम्बेडेड वर्कबुक) से जुड़ा था, तो वह लिंक एक [OLE ऑब्जेक्ट](/slides/hi/java/manage-ole/) के रूप में संरक्षित रहता है। फ़ाइलों के बीच स्थानांतरित होने के बाद डेटा उपलब्धता और रिफ़्रेश व्यवहार की जाँच करें।

**क्या मैं क्लोन की इन्सर्शन पोज़िशन और सेक्शन को नियंत्रित कर सकता हूँ?**

हँ। आप क्लोन को विशिष्ट स्लाइड इंडेक्स पर इन्सर्ट कर सकते हैं और उसे चुने हुए [सेक्शन](/slides/hi/java/slide-section/) में रख सकते हैं। यदि लक्ष्य सेक्शन मौजूद नहीं है, तो पहले उसे बनाएं और फिर स्लाइड को उसमें ले जाएँ।