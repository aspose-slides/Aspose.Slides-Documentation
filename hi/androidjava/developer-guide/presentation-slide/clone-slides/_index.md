---
title: एंड्रॉइड पर प्रेजेंटेशन स्लाइड्स क्लोन करें
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
- प्रेजेंटेशन
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के साथ PowerPoint स्लाइड्स को दोहराएँ। सेकंडों में PPT बनाने को स्वचालित करने और मैन्युअल काम को समाप्त करने के लिए हमारे स्पष्ट Java कोड उदाहरणों का पालन करें।"
---
## **परिचय**

क्लोनिंग वह प्रक्रिया है जो किसी वस्तु की सटीक कॉपी या प्रतिलिपि बनाती है। Aspose.Slides for Android via Java भी किसी भी स्लाइड की कॉपी या क्लोन बनाना और उसे वर्तमान या किसी अन्य खुले प्रेजेंटेशन में सम्मिलित करना संभव बनाता है। स्लाइड क्लोनिंग प्रक्रिया एक नई स्लाइड बनाती है जिसे डेवलपर्स मूल स्लाइड को बदले बिना संशोधित कर सकते हैं। स्लाइड क्लोन करने के कई सम्भव तरीके हैं:

- प्रेजेंटेशन के भीतर अंत में क्लोन करें।
- प्रेजेंटेशन के भीतर किसी अन्य स्थान पर क्लोन करें।
- किसी अन्य प्रेजेंटेशन में अंत में क्लोन करें।
- किसी अन्य प्रेजेंटेशन में किसी अन्य स्थान पर क्लोन करें।
- किसी अन्य प्रेजेंटेशन में निर्दिष्ट स्थान पर क्लोन करें।

Aspose.Slides for Android via Java में, ([ISlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlide) ऑब्जेक्ट्स का संग्रह) जो [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) ऑब्जेक्ट द्वारा उजागर किया गया है, ऊपर दर्शाए गए स्लाइड क्लोनिंग प्रकारों को करने के लिए [addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) और [insertClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) मेथड्स प्रदान करता है।

## **प्रेजेंटेशन के अंत में स्लाइड क्लोन करना**
यदि आप स्लाइड को क्लोन करना चाहते हैं और फिर उसे उसी प्रेजेंटेशन फ़ाइल में मौजूदा स्लाइड्स के अंत में उपयोग करना चाहते हैं, तो नीचे दिए गए चरणों के अनुसार [addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) मेथड का उपयोग करें:

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएं।
2. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) ऑब्जेक्ट द्वारा उजागर किए गए Slides संग्रह को संदर्भित करके [ISlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#getSlides--) क्लास का इंस्टेंस बनाएं।
3. [ISlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#getSlides--) ऑब्जेक्ट द्वारा उजागर किए गए [addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) मेथड को कॉल करें और क्लोन करने वाली स्लाइड को पैरामीटर के रूप में पास करें।
4. संशोधित प्रेजेंटेशन फ़ाइल लिखें।

नीचे दिए गए उदाहरण में हमने स्लाइड (जो प्रेजेंटेशन में प्रथम स्थान – शून्य इंडेक्स – पर थी) को प्रेजेंटेशन के अंत में क्लोन किया है।

```java
import com.aspose.slides.*;

// प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // इसी प्रेजेंटेशन में स्लाइड्स के संग्रह के अंत में वांछित स्लाइड को क्लोन करें
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // संशोधित प्रेजेंटेशन को डिस्क पर सहेजें
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **प्रेजेंटेशन के भीतर किसी अन्य स्थान पर स्लाइड क्लोन करना**
यदि आप स्लाइड को क्लोन करके उसी प्रेजेंटेशन फ़ाइल में लेकिन अलग स्थान पर उपयोग करना चाहते हैं, तो [insertClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) मेथड का उपयोग करें:

1. एक नया [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएं।
2. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) ऑब्जेक्ट द्वारा उजागर किए गए **Slides** संग्रह को संदर्भित करके क्लास का इंस्टेंस बनाएं।
3. [ISlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#getSlides--) ऑब्जेक्ट द्वारा उजागर किए गए [insertClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) मेथड को कॉल करें और क्लोन करने वाली स्लाइड के साथ नई स्थिति के इंडेक्स को पैरामीटर के रूप में पास करें।
4. संशोधित प्रेजेंटेशन को PPTX फ़ाइल के रूप में लिखें।

नीचे दिए गए उदाहरण में हमने स्लाइड (जो इंडेक्स 1 – स्थान 2 – पर थी) को इंडेक्स 2 – स्थान 3 – पर क्लोन किया है।

```java
import com.aspose.slides.*;

// प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // उसी प्रेजेंटेशन में स्लाइड्स का संग्रह प्राप्त करें
    ISlideCollection slds = pres.getSlides();

    // समान प्रेजेंटेशन में निर्दिष्ट इंडेक्स पर वांछित स्लाइड को क्लोन करें
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // संशोधित प्रेजेंटेशन को डिस्क पर सहेजें
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **दूसरे प्रेजेंटेशन के अंत में स्लाइड क्लोन करना**
यदि आपको एक प्रेजेंटेशन से स्लाइड क्लोन करके उसे किसी अन्य प्रेजेंटेशन फ़ाइल में मौजूदा स्लाइड्स के अंत में जोड़ना है:

1. स्रोत प्रेजेंटेशन को सम्मिलित करने वाले [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएं।
2. लक्ष्य प्रेजेंटेशन को सम्मिलित करने वाले [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएं।
3. लक्ष्य प्रेजेंटेशन के [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) ऑब्जेक्ट द्वारा उजागर किए गए **Slides** संग्रह को संदर्भित करके [ISlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection) क्लास का इंस्टेंस बनाएं।
4. [ISlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#getSlides--) ऑब्जेक्ट द्वारा उजागर किए गए [addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) मेथड को कॉल करें और स्रोत प्रेजेंटेशन से स्लाइड को पैरामीटर के रूप में पास करें।
5. संशोधित लक्ष्य प्रेजेंटेशन फ़ाइल लिखें।

नीचे दिए गए उदाहरण में हमने स्रोत प्रेजेंटेशन के प्रथम इंडेक्स से स्लाइड को लक्ष्य प्रेजेंटेशन के अंत में क्लोन किया है।

```java
import com.aspose.slides.*;

// स्रोत प्रेजेंटेशन फ़ाइल को लोड करने के लिए Presentation क्लास को इंस्टैंसिएट करें
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // गन्तव्य PPTX के लिए Presentation क्लास को इंस्टैंसिएट करें (जिसमें स्लाइड क्लोन किया जाएगा)
    Presentation destPres = new Presentation();
    try {
        // स्रोत प्रेजेंटेशन से वांछित स्लाइड को गन्तव्य प्रेजेंटेशन में स्लाइड्स के संग्रह के अंत में क्लोन करें
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // गन्तव्य प्रेजेंटेशन को डिस्क पर सहेजें
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **दूसरे प्रेजेंटेशन में किसी अन्य स्थान पर स्लाइड क्लोन करना**
यदि आपको एक प्रेजेंटेशन से स्लाइड क्लोन करके उसे किसी अन्य प्रेजेंटेशन फ़ाइल में विशिष्ट स्थान पर उपयोग करना है:

1. स्रोत प्रेजेंटेशन को सम्मिलित करने वाले [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएं।
2. लक्ष्य प्रेजेंटेशन को सम्मिलित करने वाले [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएं।
3. लक्ष्य प्रेजेंटेशन के [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) ऑब्जेक्ट द्वारा उजागर किए गए Slides संग्रह को संदर्भित करके [ISlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#getSlides--) क्लास का इंस्टेंस बनाएं।
4. [ISlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#getSlides--) ऑब्जेक्ट द्वारा उजागर किए गए [insertClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) मेथड को कॉल करें और स्रोत प्रेजेंटेशन से स्लाइड के साथ इच्छित स्थिति को पैरामीटर के रूप में पास करें।
5. संशोधित लक्ष्य प्रेजेंटेशन फ़ाइल लिखें।

नीचे दिए गए उदाहरण में हमने स्रोत प्रेजेंटेशन के शून्य इंडेक्स से स्लाइड को लक्ष्य प्रेजेंटेशन के इंडेक्स 1 (स्थिति 2) पर क्लोन किया है।

```java
import com.aspose.slides.*;

// स्रोत प्रेजेंटेशन फ़ाइल को लोड करने के लिए Presentation क्लास को इंस्टैंसिएट करें
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // गंतव्य PPTX के लिए Presentation क्लास को इंस्टैंसिएट करें (जहाँ स्लाइड को क्लोन किया जाएगा)
    Presentation destPres = new Presentation();
    try {
        // स्रोत प्रेजेंटेशन से वांछित स्लाइड को गंतव्य प्रेजेंटेशन में निर्दिष्ट इंडेक्स पर क्लोन करें
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // गंतव्य प्रेजेंटेशन को डिस्क पर सहेजें
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **दूसरे प्रेजेंटेशन में विशिष्ट स्थान पर मास्टर स्लाइड के साथ स्लाइड क्लोन करना**
यदि आपको किसी प्रेजेंटेशन से मास्टर स्लाइड के साथ स्लाइड को क्लोन करके किसी अन्य प्रेजेंटेशन में उपयोग करना है, तो पहले स्रोत प्रेजेंटेशन से वांछित मास्टर स्लाइड को लक्ष्य प्रेजेंटेशन में क्लोन करना होगा। इसके बाद उस मास्टर स्लाइड का उपयोग करके स्लाइड को क्लोन करना होगा। [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) मेथड लक्ष्य प्रेजेंटेशन की मास्टर स्लाइड की अपेक्षा करता है, न कि स्रोत की। नीचे दी गई चरणों का पालन करें:

1. स्रोत प्रेजेंटेशन को सम्मिलित करने वाले [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएं।
2. लक्ष्य प्रेजेंटेशन को सम्मिलित करने वाले [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का इंस्टेंस बनाएं।
3. क्लोन की जाने वाली स्लाइड और उससे जुड़ी मास्टर स्लाइड तक पहुँचें।
4. लक्ष्य प्रेजेंटेशन के [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) ऑब्जेक्ट द्वारा उजागर किए गए Masters संग्रह को संदर्भित करके [IMasterSlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IMasterSlideCollection) क्लास का इंस्टेंस बनाएं।
5. [IMasterSlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IMasterSlideCollection) ऑब्जेक्ट द्वारा उजागर किए गए [addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) मेथड को कॉल करें और स्रोत PPTX से क्लोन की जाने वाली मास्टर स्लाइड को पैरामीटर के रूप में पास करें।
6. लक्ष्य प्रेजेंटेशन के [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) ऑब्जेक्ट द्वारा उजागर किए गए Slides संग्रह को संदर्भित करके [ISlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#getSlides--) क्लास का इंस्टेंस बनाएं।
7. [ISlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#getSlides--) ऑब्जेक्ट द्वारा उजागर किए गए [addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-) मेथड को कॉल करें और स्रोत प्रेजेंटेशन से स्लाइड को क्लोन करने के साथ-साथ मास्टर स्लाइड को भी पैरामीटर के रूप में पास करें।
8. संशोधित लक्ष्य प्रेजेंटेशन फ़ाइल लिखें।

नीचे दिए गए उदाहरण में हमने स्रोत प्रेजेंटेशन के शून्य इंडेक्स पर स्थित स्लाइड को स्रोत स्लाइड की मास्टर का उपयोग करके लक्ष्य प्रेजेंटेशन के अंत में क्लोन किया है।

```java
import com.aspose.slides.*;

// स्रोत प्रेजेंटेशन फ़ाइल को लोड करने के लिए Presentation क्लास को इंस्टैंसिएट करें
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // गंतव्य प्रेजेंटेशन (जहाँ स्लाइड क्लोन की जाएगी) के लिए Presentation क्लास को इंस्टैंसिएट करें
    Presentation destPres = new Presentation();
    try {
        // स्रोत प्रेजेंटेशन में स्लाइड्स के संग्रह से ISlide को इंस्टैंसिएट करें साथ में
        // मास्टर स्लाइड
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // स्रोत प्रेजेंटेशन से वांछित मास्टर स्लाइड को गंतव्य प्रेजेंटेशन के मास्टर्स संग्रह में क्लोन करें
        // गंतव्य प्रेजेंटेशन
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // स्रोत प्रेजेंटेशन से वांछित मास्टर के साथ वांछित स्लाइड को गंतव्य प्रेजेंटेशन में स्लाइड्स के संग्रह के अंत में क्लोन करें
        // गंतव्य प्रेजेंटेशन में स्लाइड्स के संग्रह
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // गंतव्य प्रेजेंटेशन को डिस्क पर सहेजें
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **निर्दिष्ट सेक्शन के अंत में स्लाइड क्लोन करना**
यदि आप स्लाइड को क्लोन करके उसे उसी प्रेजेंटेशन फ़ाइल में लेकिन किसी अन्य सेक्शन में उपयोग करना चाहते हैं, तो [**addClone**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ISection-) मेथड का उपयोग करें जो [**ISlideCollection**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection) इंटरफ़ेस द्वारा प्रदान किया गया है। Aspose.Slides for Android via Java पहले सेक्शन से स्लाइड को क्लोन करके फिर उसी प्रेजेंटेशन के दूसरे सेक्शन में सम्मिलित करने की क्षमता देता है।

निम्नलिखित कोड स्निपेट दिखाता है कि कैसे स्लाइड को क्लोन करके निर्दिष्ट सेक्शन में सम्मिलित किया जाए।

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
    // गंतव्य प्रेजेंटेशन को डिस्क पर सहेजें
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **स्लाइड आकार का मिलान सुनिश्चित करना**

जब स्लाइड्स को किसी अन्य प्रेजेंटेशन में क्लोन किया जाता है, तो सुनिश्चित करें कि लक्ष्य प्रेजेंटेशन का स्लाइड आकार स्रोत के समान हो। यदि स्लाइड आकार अलग है, तो Aspose.Slides क्लोन की गई आकृतियों को स्वतः री‑स्केल नहीं करता—उनके मूल निर्देशांक और आयाम बरकरार रहते हैं, जिससे सामग्री असंगत या स्लाइड की सीमा से बाहर निकल सकती है।

क्लोन करने से पहले आप लक्ष्य प्रेजेंटेशन का स्लाइड आकार स्रोत से मिलाने के लिए सेट कर सकते हैं:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

क्लोन करने से पहले मास्टर और स्लाइड के आकार को मिलाएँ।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या स्पीकर नोट्स और रिव्यूअर कमेंट्स क्लोन होते हैं?**

हाँ। नोट्स पेज और रिव्यू कमेंट्स क्लोन में शामिल होते हैं। यदि आप उन्हें नहीं चाहते, तो सम्मिलन के बाद [उन्हें हटाएँ](/slides/hi/androidjava/presentation-notes/)।

**चार्ट और उनके डेटा स्रोतों को कैसे संभाला जाता है?**

चार्ट ऑब्जेक्ट, फॉर्मेटिंग और एम्बेडेड डेटा कॉपी हो जाता है। यदि चार्ट किसी बाहरी स्रोत (जैसे OLE‑एम्बेडेड वर्कबुक) से जुड़ा था, तो वह लिंक एक [OLE ऑब्जेक्ट](/slides/hi/androidjava/manage-ole/) के रूप में बना रहता है। फ़ाइलों के बीच स्थानांतरित करने के बाद डेटा उपलब्धता और रीफ़्रेश व्यवहार की जाँच करें।

**क्या मैं क्लोन की सम्मिलन स्थिति और सेक्शन को नियंत्रित कर सकता हूँ?**

हाँ। आप क्लोन को विशिष्ट स्लाइड इंडेक्स पर सम्मिलित कर सकते हैं और उसे इच्छित [सेक्शन](/slides/hi/androidjava/slide-section/) में रख सकते हैं। यदि लक्ष्य सेक्शन मौजूद नहीं है, तो पहले उसे बनाएँ और फिर स्लाइड को उसमें ले जाएँ।