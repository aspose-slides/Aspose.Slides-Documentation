---
title: जावा में प्रस्तुतियों को कुशलतापूर्वक मर्ज करें
linktitle: प्रस्तुतियों को मर्ज करें
type: docs
weight: 40
url: /hi/java/merge-presentation/
keywords:
- PowerPoint को मर्ज करें
- प्रस्तुतियों को मर्ज करें
- स्लाइड्स को मर्ज करें
- PPT को मर्ज करें
- PPTX को मर्ज करें
- ODP को मर्ज करें
- PowerPoint को संयोजित करें
- प्रस्तुतियों को संयोजित करें
- स्लाइड्स को संयोजित करें
- PPT को संयोजित करें
- PPTX को संयोजित करें
- ODP को संयोजित करें
- जावा
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint (PPT, PPTX) और OpenDocument (ODP) प्रस्तुतियों को सहजता से मर्ज करें, जिससे आपका कार्यप्रवाह सरल हो जाता है।"
---
## **अवलोकन**

PowerPoint और OpenDocument प्रस्तुतियों को मिलाना कई Java अनुप्रयोगों में एक सामान्य कार्य है, विशेष रूप से रिपोर्ट बनाते समय, विभिन्न स्रोतों से स्लाइड्स को संकलित करते समय, या प्रस्तुति कार्यप्रवाह को स्वचालित करते समय। Aspose.Slides for Java एक शक्तिशाली और उपयोग में आसान API प्रदान करता है जो कई PPT, PPTX, या ODP फ़ाइलों को एकल प्रस्तुति में मिलाता है, बिना Microsoft PowerPoint, LibreOffice, या OpenOffice स्थापित किए।

इस मार्गदर्शिका में, आप केवल कुछ Java कोड की लाइनों का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों को कैसे मिलाएँ, सीखेंगे। हम तैयार-उपयोग उदाहरण प्रदान करेंगे, और दिखाएंगे कि मर्ज प्रक्रिया के दौरान स्लाइड फ़ॉर्मेटिंग, लेआउट, और अन्य प्रस्तुति तत्वों को कैसे संरक्षित रखें।

चाहे आप एंटरप्राइज़-ग्रेड एप्लिकेशन बना रहे हों या एक सरल ऑटोमेशन टूल, Aspose.Slides Java में प्रस्तुतियों को मिलाना तेज़, विश्वसनीय, और स्केलेबल बनाता है। Aspose.Slides for Java आपको विभिन्न तरीकों से प्रस्तुतियों को मिलाने की अनुमति देता है। आप सभी शैप्स, स्टाइल्स, टेक्स्ट, फ़ॉर्मेटिंग, टिप्पणी, एनिमेशन, और अन्य चीज़ों के साथ प्रस्तुतियों को संयोजित कर सकते हैं—गुणवत्ता या डेटा के नुकसान की चिंता किए बिना।

{{% alert color="primary" %}}
और देखें: [Clone Slides](https://docs.aspose.com/slides/hi/java/clone-slides/)
{{% /alert %}}

### **क्या मर्ज किया जा सकता है?**

Aspose.Slides के साथ, आप मर्ज कर सकते हैं:

**पूरी प्रस्तुतियां** – कई प्रस्तुतियों की सभी स्लाइड्स को एक में जोड़ा जाता है।

**विशिष्ट स्लाइड्स** – केवल चयनित स्लाइड्स को एकल प्रस्तुति में मर्ज किया जाता है।

**एक ही फ़ॉर्मेट में प्रस्तुतियां** (उदाहरण के लिए, PPT से PPT, PPTX से PPTX) और **विभिन्न फ़ॉर्मेट में** (उदाहरण के लिए, PPT से PPTX, PPTX से ODP)।

### **मर्जिंग विकल्प**

आप विकल्प लागू कर सकते हैं जो निर्धारित करते हैं कि:
- आउटपुट प्रस्तुति की प्रत्येक स्लाइड अपनी मूल शैली बनाए रखती है
- आउटपुट प्रस्तुति की सभी स्लाइड्स पर एक विशिष्ट शैली लागू की जाती है

प्रस्तुतियों को मर्ज करने के लिए, Aspose.Slides [ISlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecollection/) इंटरफ़ेस से `AddClone` मेथड प्रदान करता है। कई `AddClone` मेथड ओवरलोड मौजूद हैं जो मर्ज प्रक्रिया के व्यवहार को निर्धारित करते हैं। प्रत्येक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) ऑब्जेक्ट में एक Slides संग्रह होता है। इसलिए, आप लक्ष्य प्रस्तुति पर `AddClone` मेथड को कॉल कर सकते हैं जिसमें आप स्लाइड्स को मर्ज करना चाहते हैं।

`AddClone` मेथड एक [ISlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/) ऑब्जेक्ट लौटाता है, जो स्रोत स्लाइड का क्लोन होता है। आउटपुट प्रस्तुति में परिणामी स्लाइड्स मूल स्लाइड्स की साधारण प्रतियां होती हैं। इसका मतलब है कि आप क्लोन किए गए स्लाइड्स को सुरक्षित रूप से संशोधित कर सकते हैं—जैसे कि स्टाइल, फ़ॉर्मेटिंग विकल्प, या लेआउट लागू करना—बिना स्रोत प्रस्तुति को प्रभावित किए।

## **प्रस्तुतियों को मर्ज करें** 

Aspose.Slides [AddClone(ISlide)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) मेथड प्रदान करता है, जो आपको स्लाइड्स को संयोजित करने की अनुमति देता है जबकि उनके मूल लेआउट और शैली को संरक्षित रखता है (डिफ़ॉल्ट व्यवहार)।

नीचे दिया गया Java कोड दिखाता है कि प्रस्तुतियों को कैसे मर्ज किया जाए:

```java
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        presentation1.getSlides().addClone(slide);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

## **स्लाइड मास्टर के साथ प्रस्तुतियों को मर्ज करें**

Aspose.Slides [AddClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISSlide-com.aspose.slides.IMasterSlide-boolean-) मेथड प्रदान करता है, जो आपको प्रस्तुति टेम्पलेट से स्लाइड मास्टर लागू करते हुए स्लाइड्स को संयोजित करने की अनुमति देता है। इस तरह, आवश्यकता पड़ने पर आप आउटपुट प्रस्तुति में स्लाइड्स की शैली बदल सकते हैं।

नीचे दिया गया Java कोड इस ऑपरेशन को दर्शाता है:

```java
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        IMasterSlide masterSlide = presentation2.getMasters().get_Item(0);
        presentation1.getSlides().addClone(slide, masterSlide, true);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

{{% alert title="Note" color="warning" %}}
स्लाइड का लेआउट स्वचालित रूप से निर्धारित किया जाता है। जब उपयुक्त लेआउट नहीं मिल पाता, और `AddClone` मेथड का `allowCloneMissingLayout` बूलियन पैरामीटर `true` पर सेट किया जाता है, तो स्रोत स्लाइड से लेआउट उपयोग किया जाता है। अन्यथा, एक [PptxEditException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pptxeditexception/) फेंका जाता है।
{{% /alert %}}

## **प्रस्तुतियों से विशिष्ट स्लाइड्स को मर्ज करें**

कई प्रस्तुतियों से विशिष्ट स्लाइड्स को मर्ज करना कस्टम स्लाइड डेक बनाने के लिए उपयोगी है। Aspose.Slides for Java आपको केवल आवश्यक स्लाइड्स चुनने और आयात करने की अनुमति देता है। API मूल स्लाइड्स की फ़ॉर्मेटिंग, लेआउट, और डिज़ाइन को संरक्षित रखती है।

नीचे दिया गया Java कोड एक नई प्रस्तुति बनाता है, दो अन्य प्रस्तुतियों से शीर्षक स्लाइड्स जोड़ता है, और परिणाम को फ़ाइल में सहेजता है:

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

## **स्लाइड लेआउट के साथ प्रस्तुतियों को मर्ज करें**

मर्ज के दौरान आउटपुट स्लाइड्स पर एक अलग स्लाइड लेआउट लागू करने के लिए, इसके बजाय [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ILayoutSlide-) मेथड का उपयोग करें।

नीचे दिया गया Java कोड दिखाता है कि कई प्रस्तुतियों से स्लाइड्स को कैसे संयोजित किया जाए जबकि आपका पसंदीदा स्लाइड लेआउट लागू किया जाए, जिससे एक एकल आउटपुट प्रस्तुति बनती है:

```java
int layoutIndex = 0;

Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        ILayoutSlide layoutSlide = presentation2.getLayoutSlides().get_Item(layoutIndex);
        presentation1.getSlides().addClone(slide, layoutSlide);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

## **विभिन्न स्लाइड आकारों के साथ प्रस्तुतियों को मर्ज करें**

विभिन्न स्लाइड आकारों वाली दो प्रस्तुतियों को मर्ज करने के लिए, आपको उनमें से एक का आकार दूसरे प्रस्तुति के स्लाइड आकार से मेल खाने के लिए बदलना चाहिए।

```java
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    Dimension2D slideSize = presentation1.getSlideSize().getSize();
    float slideWidth = (float) slideSize.getWidth();
    float slideHeight = (float) slideSize.getHeight();
    
    presentation2.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    for (ISlide slide : presentation2.getSlides()) {
        presentation1.getSlides().addClone(slide);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

## **एक प्रस्तुति सेक्शन में स्लाइड्स को मर्ज करें**

विशिष्ट प्रस्तुति सेक्शन में स्लाइड्स को मर्ज करना सामग्री को व्यवस्थित करने और स्लाइड नेविगेशन सुधारने में मदद करता है। Aspose.Slides आपको मौजूदा सेक्शन्स में स्लाइड्स को मर्ज करने की अनुमति देता है। इससे प्रत्येक स्लाइड की मूल फ़ॉर्मेटिंग को संरक्षित रखते हुए स्पष्ट संरचना सुनिश्चित होती है।

```java
int sectionIndex = 0;

Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        ISection section = presentation1.getSections().get_Item(sectionIndex);
        presentation1.getSlides().addClone(slide, section);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

स्लाइड सेक्शन के अंत में जोड़ी जाती है।

## **और देखें**

Aspose एक [FREE Online Collage Maker](https://products.aspose.app/slides/hi/collage) प्रदान करता है। इस ऑनलाइन सेवा का उपयोग करके आप [JPG से JPG](https://products.aspose.app/slides/hi/collage/jpg) या PNG से PNG इमेजेस को मर्ज कर सकते हैं, [फ़ोटो ग्रिड्स](https://products.aspose.app/slides/hi/collage/photo-grid) बना सकते हैं, और कई अन्य कार्य कर सकते हैं।

देखें [Aspose FREE Online Merger](https://products.aspose.app/slides/hi/merger)। यह आपको एक ही फ़ॉर्मेट में PowerPoint प्रस्तुतियों को मर्ज करने की अनुमति देता है (जैसे, PPT से PPT, PPTX से PPTX) या विभिन्न फ़ॉर्मेट में (जैसे, PPT से PPTX, PPTX से ODP)।

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/hi/merger)

प्रस्तुतियों के अलावा, Aspose.Slides आपको अन्य फ़ाइलों को भी मर्ज करने की अनुमति देता है:

- [**Images**](https://products.aspose.com/slides/hi/java/merger/image-to-image/), जैसे कि [JPG से JPG](https://products.aspose.com/slides/hi/java/merger/jpg-to-jpg/) या [PNG से PNG](https://products.aspose.com/slides/hi/java/merger/png-to-png/)
- **Documents**, जैसे कि [PDF से PDF](https://products.aspose.com/slides/hi/java/merger/pdf-to-pdf/) या [HTML से HTML](https://products.aspose.com/slides/hi/java/merger/html-to-html/)
- **Mixed file types**, जैसे कि [image to PDF](https://products.aspose.com/slides/hi/java/merger/image-to-pdf/), [JPG to PDF](https://products.aspose.com/slides/hi/java/merger/jpg-to-pdf/), या [TIFF to PDF](https://products.aspose.com/slides/hi/java/merger/tiff-to-pdf/)

## **FAQ**

**क्या प्रस्तुतियों को मर्ज करते समय स्लाइडों की संख्या पर कोई सीमा है?**

कोई सख्त सीमा नहीं है। Aspose.Slides बड़ी फ़ाइलों को संभाल सकता है, लेकिन प्रदर्शन आकार और सिस्टम संसाधनों पर निर्भर करता है। बहुत बड़ी प्रस्तुतियों के लिए 64-बिट JVM का उपयोग करने और पर्याप्त हीप मेमोरी आवंटित करने की सलाह दी जाती है।

**क्या मैं एम्बेडेड वीडियो या ऑडियो वाली प्रस्तुतियों को मर्ज कर सकता हूँ?**

हाँ, Aspose.Slides स्लाइड्स में एम्बेडेड मल्टीमीडिया सामग्री को संरक्षित रखता है, लेकिन अंतिम प्रस्तुति काफी बड़ी हो सकती है।

**क्या प्रस्तुतियों को मर्ज करते समय फ़ॉन्ट संरक्षित रहेंगे?**

हाँ। स्रोत प्रस्तुतियों में उपयोग किए गए फ़ॉन्ट आउटपुट फ़ाइल में संरक्षित रहते हैं, बशर्ते कि वे सिस्टम में स्थापित हों या [एम्बेडेड](/slides/hi/java/embedded-font/) हों।