---
title: Android पर प्रस्तुतियों को कुशलतापूर्वक मिलाएँ
linktitle: प्रस्तुतियाँ मिलाएँ
type: docs
weight: 40
url: /hi/androidjava/merge-presentation/
keywords:
- PowerPoint को मिलाएँ
- प्रस्तुतियों को मिलाएँ
- स्लाइड्स को मिलाएँ
- PPT को मिलाएँ
- PPTX को मिलाएँ
- ODP को मिलाएँ
- PowerPoint को संयोजित करें
- प्रस्तुतियों को संयोजित करें
- स्लाइड्स को संयोजित करें
- PPT को संयोजित करें
- PPTX को संयोजित करें
- ODP को संयोजित करें
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ PowerPoint (PPT, PPTX) और OpenDocument (ODP) प्रस्तुतियों को बिना मेहनत के मिलाएँ, जिससे आपका कार्यप्रवाह सरल हो जाए।"
---
## **परिचय**

PowerPoint और OpenDocument प्रस्तुतियों को मिलाना कई Android अनुप्रयोगों में एक सामान्य कार्य है, विशेष रूप से रिपोर्ट उत्पन्न करने, विभिन्न स्रोतों से स्लाइड्स एकत्रित करने, या प्रस्तुति कार्य प्रवाह को स्वचालित करने के समय। Aspose.Slides एक शक्तिशाली और उपयोग में आसान API प्रदान करता है जिससे कई PPT, PPTX, या ODP फ़ाइलों को एकल प्रस्तुति में बिना Microsoft PowerPoint, LibreOffice, या OpenOffice स्थापित किए मिलाया जा सकता है।

इस मार्गदर्शिका में, आप कुछ ही पंक्तियों के कोड का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों को कैसे मिलाएँ सीखेंगे। हम तैयार‑उपयोग उदाहरण प्रदान करेंगे, और दिखाएंगे कि मर्ज प्रक्रिया के दौरान स्लाइड फ़ॉर्मेटिंग, लेआउट और अन्य प्रस्तुति तत्वों को कैसे संरक्षित रखें।

चाहे आप एंटरप्राइज़‑ग्रेड एप्लिकेशन बना रहे हों या एक सरल ऑटोमेशन टूल, Aspose.Slides प्रस्तुतियों को तेज़, विश्वसनीय और स्केलेबल तरीके से मिलाता है। Aspose.Slides विभिन्न तरीकों से प्रस्तुतियों को मर्ज करने की सुविधा देता है। आप सभी आकृतियों, शैलियों, टेक्स्ट, फ़ॉर्मेटिंग, टिप्पणियों, एनीमेशन और अन्य तत्वों के साथ प्रस्तुतियों को संयोजित कर सकते हैं—बिना गुणवत्ता या डेटा के नुकसान की चिंता किए।

{{% alert color="info" %}}
और देखें: [Clone Slides](https://docs.aspose.com/slides/hi/androidjava/clone-slides/)
{{% /alert %}}

### **क्या मर्ज किया जा सकता है**

Aspose.Slides के साथ आप निम्नलिखित मर्ज कर सकते हैं

* पूरी प्रस्तुतियाँ। सभी स्लाइड्स एकल प्रस्तुति में सम्मिलित हो जाती हैं
* विशिष्ट स्लाइड्स। चयनित स्लाइड्स एकल प्रस्तुति में सम्मिलित होती हैं
* एक ही फ़ॉर्मेट की प्रस्तुतियाँ (PPT से PPT, PPTX से PPTX, आदि) और विभिन्न फ़ॉर्मेट की प्रस्तुतियाँ (PPT से PPTX, PPTX से ODP, आदि) एक दूसरे के साथ।

### **मर्ज विकल्प**

आप ऐसे विकल्प लागू कर सकते हैं जो निर्धारित करते हैं कि

* आउटपुट प्रस्तुति में प्रत्येक स्लाइड एक अनोखी शैली बनाए रखती है
* सभी स्लाइड्स के लिए एक समान शैली उपयोग की जाती है।

प्रस्तुतियों को मर्ज करने के लिए, Aspose.Slides [AddClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) मेथड्स प्रदान करता है (जो [ISlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection) इंटरफ़ेस से हैं)। `AddClone` मेथड्स की कई कार्यान्वयनें हैं जो प्रस्तुति मर्ज प्रक्रिया पैरामीटर को परिभाषित करती हैं। प्रत्येक Presentation ऑब्जेक्ट में एक [Slides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#getSlides--) संग्रह होता है, इसलिए आप उस प्रस्तुति से `AddClone` मेथड कॉल कर सकते हैं जिसमें आप स्लाइड्स को मर्ज करना चाहते हैं।

`AddClone` मेथड एक `ISlide` ऑब्जेक्ट लौटाता है, जो स्रोत स्लाइड की क्लोन होती है। आउटपुट प्रस्तुति में स्लाइड्स बस स्रोत स्लाइड्स की प्रतिलिपि होती हैं। इसलिए आप परिणामी स्लाइड्स में परिवर्तन (जैसे शैलियाँ लागू करना, फ़ॉर्मेटिंग विकल्प या लेआउट बदलना) कर सकते हैं बिना स्रोत प्रस्तुतियों पर असर की चिंता किए।

## **प्रेज़ेंटेशन मर्ज करना**

Aspose.Slides वह [**AddClone(ISlide)**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) मेथड प्रदान करता है जो डिफ़ॉल्ट पैरामीटर के साथ स्लाइड्स को संयोजित करने देता है, जबकि स्लाइड्स अपनी लेआउट और शैली बरकरार रखती हैं।

यह Java कोड आपको दिखाता है कि कैसे प्रस्तुतियों को मर्ज करें:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **स्लाइड मास्टर के साथ प्रेज़ेंटेशन मर्ज करना**

Aspose.Slides वह [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) मेथड प्रदान करता है जो स्लाइड मास्टर प्रस्तुति टेम्पलेट लागू करते हुए स्लाइड्स को संयोजित करने देता है। इस तरह, यदि आवश्यक हो, आप आउटपुट प्रस्तुति में स्लाइड्स की शैली बदल सकते हैं।

यह Java कोड वर्णित ऑपरेशन को दर्शाता है:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

{{% alert title="Note" color="warning" %}} 
स्लाइड मास्टर के लिए स्लाइड लेआउट स्वचालित रूप से निर्धारित किया जाता है। जब उपयुक्त लेआउट निर्धारित नहीं किया जा सकता, यदि `allowCloneMissingLayout` बूलियन पैरामीटर `AddClone` मेथड में true सेट किया गया है, तो स्रोत स्लाइड का लेआउट उपयोग किया जाएगा। अन्यथा, [PptxEditException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/PptxEditException) थ्रो किया जाएगा।
{{% /alert %}}

यदि आप आउटपुट प्रस्तुति में स्लाइड्स के लिए अलग लेआउट चाहते हैं, तो मर्ज करने के समय [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) मेथड का उपयोग करें।

## **प्रेज़ेंटेशन से विशिष्ट स्लाइड्स मर्ज करना**

कई प्रस्तुतियों से विशिष्ट स्लाइड्स को मर्ज करना कस्टम स्लाइड डेक बनाने में उपयोगी होता है। Aspose.Slides for Android via Java आपको केवल आवश्यक स्लाइड्स चुनने और आयात करने की अनुमति देता है। API मूल स्लाइड्स का फ़ॉर्मेटिंग, लेआउट और डिज़ाइन संरक्षित रखती है।

निम्नलिखित Java कोड एक नई प्रस्तुति बनाता है, दो अन्य प्रस्तुतियों से टाइटल स्लाइड्स जोड़ता है, और परिणाम को फ़ाइल में सहेजता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);

    ISlide slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    ISlide slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```
```java
import com.aspose.slides.*;

static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```

## **स्लाइड लेआउट के साथ प्रेज़ेंटेशन मर्ज करना**

यह Java कोड आपको दिखाता है कि कैसे प्रस्तुतियों की स्लाइड्स को आपके पसंदीदा स्लाइड लेआउट को लागू करते हुए मिलाकर एक आउटपुट प्रस्तुति प्राप्त करें:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **विभिन्न स्लाइड आकारों के साथ प्रेज़ेंटेशन मर्ज करना**

{{% alert title="Note" color="warning" %}} 
आप विभिन्न स्लाइड आकारों वाली प्रस्तुतियों को मर्ज नहीं कर सकते। 
{{% /alert %}}

दो अलग-अलग स्लाइड आकारों वाली प्रस्तुतियों को मर्ज करने के लिए, आपको एक प्रस्तुति का आकार बदलना होगा ताकि वह दूसरी प्रस्तुति के आकार से मेल खाए।

यह नमूना कोड वर्णित ऑपरेशन दर्शाता है:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize((float)pres1.getSlideSize().getSize().getWidth(), (float)pres1.getSlideSize().getSize().getHeight(), SlideSizeScaleType.EnsureFit);

        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **प्रेज़ेंटेशन सेक्शन में स्लाइड्स मर्ज करना**

यह Java कोड आपको दिखाता है कि कैसे एक विशिष्ट स्लाइड को प्रस्तुति के एक सेक्शन में मर्ज करें:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

स्लाइड सेक्शन के अंत में जोड़ी जाती है।

{{% alert title="Tip" color="info" %}}
Aspose एक [FREE Collage web app](https://products.aspose.app/slides/hi/collage) प्रदान करता है। इस ऑनलाइन सेवा का उपयोग करके आप [JPG to JPG](https://products.aspose.app/slides/hi/collage/jpg) या PNG to PNG इमेजेज मर्ज कर सकते हैं, [photo grids](https://products.aspose.app/slides/hi/collage/photo-grid) बना सकते हैं, आदि।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या प्रस्तुतियों को मर्ज करते समय स्लाइड संख्या पर कोई प्रतिबन्ध है?

कोई सख्त प्रतिबन्ध नहीं है। Aspose.Slides बड़ी फ़ाइलों को संभाल सकता है, लेकिन प्रदर्शन फ़ाइल आकार और सिस्टम संसाधनों पर निर्भर करता है। बहुत बड़ी प्रस्तुतियों के लिए 64‑bit JVM का उपयोग करने और पर्याप्त हेप मेमोरी आवंटित करने की सलाह दी जाती है।

### क्या मैं वीडियो या ऑडियो एम्बेडेड प्रस्तुतियों को मर्ज कर सकता हूँ?

हां, Aspose.Slides स्लाइड्स में एम्बेडेड मल्टीमीडिया कंटेंट को संरक्षित रखता है, लेकिन अंतिम प्रस्तुति का आकार उल्लेखनीय रूप से बड़ा हो सकता है।

### क्या फॉन्ट्स मर्ज करते समय संरक्षित रहेंगे?

हां। स्रोत प्रस्तुतियों में प्रयुक्त फॉन्ट्स आउटपुट फ़ाइल में संरक्षित रहते हैं, बशर्ते वे सिस्टम पर स्थापित हों या [embedded](/slides/hi/androidjava/embedded-font/) हों।