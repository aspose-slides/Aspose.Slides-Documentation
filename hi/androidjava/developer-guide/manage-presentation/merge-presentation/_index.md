---
title: Android पर कुशलता से प्रस्तुतियों को मर्ज करें
linktitle: प्रेज़ेंटेशन मर्ज करें
type: docs
weight: 40
url: /hi/androidjava/merge-presentation/
keywords:
- PowerPoint मर्ज करें
- प्रस्तुतियों को मर्ज करें
- स्लाइड्स को मर्ज करें
- PPT मर्ज करें
- PPTX मर्ज करें
- ODP मर्ज करें
- PowerPoint को संयोजित करें
- प्रस्तुतियों को संयोजित करें
- स्लाइड्स को संयोजित करें
- PPT को संयोजित करें
- PPTX को संयोजित करें
- ODP को संयोजित करें
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके PowerPoint (PPT, PPTX) और OpenDocument (ODP) प्रस्तुतियों को सहजता से मर्ज करें, जिससे आपका कार्यप्रवाह सरल हो जाए।"
---
## **परिचय**

PowerPoint और OpenDocument प्रस्तुतियों को मिलाना कई Android अनुप्रयोगों में आम कार्य है, विशेष रूप से रिपोर्ट उत्पन्न करने, विभिन्न स्रोतों से स्लाइड्स को संकलित करने, या प्रस्तुति वर्कफ़्लो को स्वचालित करने के समय। Aspose.Slides एक शक्तिशाली और आसान‑से‑उपयोग API प्रदान करता है जो कई PPT, PPTX या ODP फ़ाइलों को एकल प्रस्तुति में संयोजित करता है, बिना Microsoft PowerPoint, LibreOffice या OpenOffice स्थापित किए।

इस मार्गदर्शिका में, आप कुछ ही पंक्तियों के कोड का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों को कैसे मिलाएँ, सीखेंगे। हम तैयार‑उपयोग उदाहरण प्रदान करेंगे, और बताएंगे कि मर्ज प्रक्रिया के दौरान स्लाइड फ़ॉर्मेटिंग, लेआउट और अन्य प्रस्तुति तत्व कैसे संरक्षित रखें।

चाहे आप एंटरप्राइज़‑ग्रेड अनुप्रयोग बना रहे हों या साधारण ऑटोमेशन टूल, Aspose.Slides प्रस्तुतियों को तेज़, भरोसेमंद और स्केलेबल तरीके से मर्ज करने में मदद करता है। Aspose.Slides आपको विभिन्न तरीकों से प्रस्तुतियों को मर्ज करने की सुविधा देता है। आप सभी आकृतियों, शैलियों, टेक्स्ट, फ़ॉर्मेटिंग, टिप्पणियों, एनीमेशन आदि के साथ प्रस्तुतियों को संयोजित कर सकते हैं—बिना गुणवत्ता या डेटा के नुकसान की चिंता किए।

{{% alert color="primary" %}}
See also: [Clone Slides](https://docs.aspose.com/slides/hi/androidjava/clone-slides/)
{{% /alert %}}

### **क्या मर्ज किया जा सकता है**

Aspose.Slides के साथ आप मर्ज कर सकते हैं  

* संपूर्ण प्रस्तुतियाँ। सभी स्लाइड्स एक प्रस्तुति में मिल जाती हैं  
* विशिष्ट स्लाइड्स। चुनी गई स्लाइड्स एक प्रस्तुति में मिलती हैं  
* एक ही फ़ॉर्मेट (PPT से PPT, PPTX से PPTX आदि) और विभिन्न फ़ॉर्मेट (PPT से PPTX, PPTX से ODP आदि) की प्रस्तुतियों को आपस में।  

### **मर्जिंग विकल्प**

आप ऐसे विकल्प लागू कर सकते हैं जो निर्धारित करते हैं कि  

* आउटपुट प्रस्तुति में प्रत्येक स्लाइड अपनी अनोखी शैली रखे  
* आउटपुट प्रस्तुति की सभी स्लाइड्स के लिए एक विशिष्ट शैली प्रयोग की जाए।  

प्रस्तुतियों को मर्ज करने के लिए, Aspose.Slides [AddClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) मेथड्स ([ISlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection) इंटरफ़ेस) प्रदान करता है। `AddClone` मेथड के कई कार्यान्वयन हैं जो प्रस्तुति मर्ज प्रक्रिया के पैरामीटर निर्धारित करते हैं। प्रत्येक Presentation ऑब्जेक्ट के पास एक [Slides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#getSlides--) कलेक्शन होता है, इसलिए आप उस प्रस्तुति से `AddClone` मेथड कॉल कर सकते हैं जिसमें आप स्लाइड्स को मर्ज करना चाहते हैं।

`AddClone` मेथड एक `ISlide` ऑब्जेक्ट लौटाता है, जो स्रोत स्लाइड की क्लोन होती है। आउटपुट प्रस्तुति में स्लाइड्स बस स्रोत स्लाइड्स की कॉपी होती हैं। इसलिए आप परिणामस्वरूप स्लाइड्स में परिवर्तन (जैसे, शैलियों या फ़ॉर्मेटिंग विकल्पों या लेआउट को लागू करना) कर सकते हैं, बिना स्रोत प्रस्तुतियों पर असर की चिंता किए।  

## **प्रेज़ेंटेशन मर्ज करें** 

Aspose.Slides वह [**AddClone(ISlide)**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) मेथड प्रदान करता है जो स्लाइड्स को संयोजित करता है जबकि स्लाइड्स अपने लेआउट और शैली (डिफ़ॉल्ट पैरामीटर) बनाए रखती हैं।

यह Java कोड दिखाता है कि प्रस्तुतियों को कैसे मर्ज करें:

```java
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

## **स्लाइड मास्टर के साथ प्रेज़ेंटेशन मर्ज करें** 

Aspose.Slides वह [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) मेथड प्रदान करता है जो स्लाइड्स को संयोजित करता है जबकि स्लाइड मास्टर प्रस्तुति टेम्प्लेट लागू करता है। इस तरह, यदि आवश्यक हो, तो आप आउटपुट प्रस्तुति की स्लाइड्स की शैली बदल सकते हैं।

यह Java कोड वर्णित ऑपरेशन को प्रदर्शित करता है:

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
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
स्लाइड मास्टर के लिए स्लाइड लेआउट स्वतः निर्धारित किया जाता है। जब उपयुक्त लेआउट निर्धारित नहीं किया जा सकता, और यदि `allowCloneMissingLayout` बूलियन पैरामीटर `AddClone` मेथड का मान true सेट किया गया हो, तो स्रोत स्लाइड का लेआउट उपयोग में लाया जाता है। अन्यथा, [PptxEditException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/PptxEditException) फेंका जायेगा। 
{{% /alert %}}

यदि आप आउटपुट प्रस्तुति की स्लाइड्स को अलग लेआउट देना चाहते हैं, तो मर्ज करते समय [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) मेथड का उपयोग करें।  

## **प्रेज़ेंटेशन की विशिष्ट स्लाइड्स मर्ज करें** 

कई प्रस्तुतियों से विशिष्ट स्लाइड्स को मर्ज करना कस्टम स्लाइड डेक बनाने में उपयोगी है। Aspose.Slides for Android via Java आपको केवल आवश्यक स्लाइड्स को चयनित और आयात करने की अनुमति देता है। API मूल स्लाइड्स की फ़ॉर्मेटिंग, लेआउट और डिज़ाइन को संरक्षित रखती है।

निम्नलिखित Java कोड एक नई प्रस्तुति बनाता है, दो अन्य प्रस्तुतियों से टाइटल स्लाइड्स जोड़ता है, और परिणाम को फ़ाइल में सहेजता है:

```java
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
static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```

## **स्लाइड लेआउट के साथ प्रेज़ेंटेशन मर्ज करें** 

यह Java कोड दर्शाता है कि प्रस्तुतियों से स्लाइड्स को कैसे संयोजित करें जबकि आपके पसंदीदा स्लाइड लेआउट को लागू किया जाये, और एक आउटपुट प्रस्तुति प्राप्त हो:

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}

```

## **विभिन्न स्लाइड आकारों वाली प्रस्तुतियों को मर्ज करें** 

{{% alert title="Note" color="warning" %}} 
आप विभिन्न स्लाइड आकारों वाली प्रस्तुतियों को मर्ज नहीं कर सकते। 
{{% /alert %}}

विभिन्न स्लाइड आकारों वाली 2 प्रस्तुतियों को मर्ज करने के लिए, आपको एक प्रस्तुति का आकार बदलना होगा ताकि वह दूसरी प्रस्तुति के आकार से मेल खा सके। 

यह नमूना कोड वर्णित ऑपरेशन को दर्शाता है:

```java
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

## **प्रेज़ेंटेशन सेक्शन में स्लाइड्स मर्ज करें** 

यह Java कोड दिखाता है कि विशेष स्लाइड को प्रस्तुति के सेक्शन में कैसे मर्ज करें:

```java
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

{{% alert title="Tip" color="primary" %}} 
Aspose एक [FREE Collage web app](https://products.aspose.app/slides/hi/collage) प्रदान करता है। इस ऑनलाइन सेवा का उपयोग करके आप [JPG to JPG](https://products.aspose.app/slides/hi/collage/jpg) या PNG to PNG इमेजेज़ को मर्ज कर सकते हैं, [photo grids](https://products.aspose.app/slides/hi/collage/photo-grid) बना सकते हैं, इत्यादि। 
{{% /alert %}}

## **FAQ** 

**क्या प्रस्तुतियों को मर्ज करते समय स्लाइडों की संख्या पर कोई प्रतिबंध है?**  

कोई कड़ा प्रतिबंध नहीं है। Aspose.Slides बड़े फ़ाइलों को संभाल सकता है, लेकिन प्रदर्शन आकार और सिस्टम संसाधनों पर निर्भर करता है। बहुत बड़ी प्रस्तुतियों के लिए 64‑bit JVM उपयोग करने और पर्याप्त हीप मेमोरी आवंटित करने की सलाह दी जाती है।  

**क्या मैं वीडियो या ऑडियो एम्बेडेड प्रस्तुतियों को मर्ज कर सकता हूँ?**  

हां, Aspose.Slides स्लाइड्स में एम्बेडेड मल्टीमीडिया सामग्री को संरक्षित रखता है, लेकिन अंतिम प्रस्तुति का आकार काफी बढ़ सकता है।  

**क्या मर्ज के बाद फ़ॉन्ट्स संरक्षित रहेंगे?**  

हां। स्रोत प्रस्तुतियों में प्रयुक्त फ़ॉन्ट्स आउटपुट फ़ाइल में संरक्षित रहेंगे, बशर्ते वे सिस्टम पर स्थापित हों या [embedded](/slides/hi/androidjava/embedded-font/) हों।  