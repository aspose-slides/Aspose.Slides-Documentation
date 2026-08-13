---
title: जावा में प्रस्तुतियों को कुशलतापूर्वक मिलाएँ
linktitle: प्रस्तुतियों को मिलाएँ
type: docs
weight: 40
url: /hi/java/merge-presentation/
keywords:
- PowerPoint मिलाएँ
- प्रस्तुतियों को मिलाएँ
- स्लाइड्स को मिलाएँ
- PPT मिलाएँ
- PPTX मिलाएँ
- ODP मिलाएँ
- PowerPoint संयोजित करें
- प्रस्तुतियों को संयोजित करें
- स्लाइड्स को संयोजित करें
- PPT संयोजित करें
- PPTX संयोजित करें
- ODP संयोजित करें
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint (PPT, PPTX) और OpenDocument (ODP) प्रस्तुतियों को सहजता से मिलाएँ, अपने कार्यप्रवाह को सुगम बनाते हुए।"
---
## **परिचय**

PowerPoint और OpenDocument प्रस्तुतियों को मिलाना कई Java अनुप्रयोगों में एक सामान्य कार्य है, विशेष रूप से रिपोर्ट तैयार करने, विभिन्न स्रोतों से स्लाइड संकलित करने, या प्रस्तुति कार्यप्रवाह को स्वचालित करने के समय। Aspose.Slides for Java एक शक्तिशाली और उपयोग में आसान API प्रदान करता है जो कई PPT, PPTX, या ODP फ़ाइलों को एकल प्रस्तुति में संयोजित करता है, बिना Microsoft PowerPoint, LibreOffice, या OpenOffice स्थापित किए।

इस मार्गदर्शिका में, आप कुछ ही Java कोड पंक्तियों का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों को कैसे मिलाना है, सीखेंगे। हम तैयार-उपयोग उदाहरण प्रदान करेंगे, और दिखाएंगे कि मर्ज प्रक्रिया के दौरान स्लाइड फ़ॉर्मेटिंग, लेआउट और अन्य प्रस्तुति तत्वों को कैसे संरक्षित किया जाए।

चाहे आप एंटरप्राइज़-ग्रेड अनुप्रयोग बना रहे हों या एक सरल स्वचालन टूल, Aspose.Slides Java में प्रस्तुतियों को मिलाना तेज, विश्वसनीय और स्केलेबल बनाता है। Aspose.Slides for Java विभिन्न तरीकों से प्रस्तुतियों को जोड़ने की अनुमति देता है। आप प्रस्तुतियों को उनके सभी आकार, शैलियाँ, पाठ, फ़ॉर्मेटिंग, टिप्पणियाँ, एनीमेशन और अधिक के साथ मिलाकर बना सकते हैं—गुणवत्ता या डेटा के नुकसान की चिंता किए बिना।

{{% alert color="info" %}}
देखें: [स्लाइड क्लोन](https://docs.aspose.com/slides/hi/java/clone-slides/)
{{% /alert %}}

### **क्या मर्ज किया जा सकता है?**

**पूरी प्रस्तुतियां** – कई प्रस्तुतियों की सभी स्लाइडें एक में संयोजित की जाती हैं।

**विशिष्ट स्लाइडें** – केवल चयनित स्लाइडें एकल प्रस्तुति में मिलाई जाती हैं।

**उसी स्वरूप में प्रस्तुतियां** (जैसे, PPT से PPT, PPTX से PPTX) और **विभिन्न स्वरूपों में** (जैसे, PPT से PPTX, PPTX से ODP)।

### **मर्ज विकल्प**

आप विकल्प लागू कर सकते हैं जो निर्धारित करते हैं कि:
- आउटपुट प्रस्तुति में प्रत्येक स्लाइड अपनी मूल शैली को बनाए रखती है
- एक विशिष्ट शैली सभी आउटपुट स्लाइडों पर लागू की जाती है

प्रस्तुतियों को मिलाने के लिए, Aspose.Slides `AddClone` विधियों को [ISlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecollection/) इंटरफ़ेस से प्रदान करता है। कई `AddClone` विधि ओवरलोड हैं जो मर्ज प्रक्रिया के व्यवहार को परिभाषित करते हैं। प्रत्येक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) ऑब्जेक्ट में Slides संग्रह होता है। इसलिए, आप लक्ष्य प्रस्तुति पर `AddClone` विधि को कॉल कर सकते हैं, जिसमें आप स्लाइड्स को मर्ज करना चाहते हैं।

`AddClone` विधि एक [ISlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/) ऑब्जेक्ट लौटाती है, जो स्रोत स्लाइड की एक क्लोन होती है। आउटपुट प्रस्तुति में परिणामी स्लाइडें मूल स्लाइडों की सरल प्रतियां होती हैं। इसका मतलब है कि आप क्लोन की गई स्लाइडों को सुरक्षित रूप से संशोधित कर सकते हैं—जैसे शैलियाँ, फ़ॉर्मेटिंग विकल्प या लेआउट लागू करना—बिना स्रोत प्रस्तुति को प्रभावित किए।

## **प्रस्तुतियों को मिलाएँ**

Aspose.Slides [AddClone(ISlide)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISSlide-) विधि प्रदान करता है, जो आपको स्लाइडों को संयोजित करने की अनुमति देती है जबकि उनके मूल लेआउट और शैलियों को संरक्षित रखती है (डिफ़ॉल्ट व्यवहार)।

निम्नलिखित Java कोड दर्शाता है कि प्रस्तुतियों को कैसे मिलाएँ:

```java
import com.aspose.slides.*;

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

## **स्लाइड मास्टर के साथ प्रस्तुतियों को मिलाएँ**

Aspose.Slides [AddClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISSlide-com.aspose.slides.IMasterSlide-boolean-) विधि प्रदान करता है, जो आपको प्रस्तुति टेम्प्लेट से एक स्लाइड मास्टर लागू करते हुए स्लाइडों को संयोजित करने की अनुमति देती है। इस प्रकार, यदि आवश्यक हो, तो आप आउटपुट प्रस्तुति में स्लाइडों की शैली बदल सकते हैं।

निम्नलिखित Java कोड इस ऑपरेशन को दर्शाता है:

```java
import com.aspose.slides.*;

Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        IMasterSlide masterSlide = presentation1.getMasters().get_Item(0);
        presentation1.getSlides().addClone(slide, masterSlide, true);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

{{% alert title="Note" color="warning" %}}
स्लाइड का लेआउट स्वचालित रूप से निर्धारित किया जाता है। जब उपयुक्त लेआउट नहीं मिल पाता, और `AddClone` विधि के `allowCloneMissingLayout` बूलियन पैरामीटर को `true` सेट किया जाता है, तो स्रोत स्लाइड का लेआउट उपयोग किया जाता है। अन्यथा, एक [PptxEditException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pptxeditexception/) उत्पन्न होता है।
{{% /alert %}}

## **प्रस्तुतियों से विशिष्ट स्लाइडें मिलाएँ**

कई प्रस्तुतियों से विशिष्ट स्लाइडें मिलाना कस्टम स्लाइड डेक बनाने में उपयोगी है। Aspose.Slides for Java आपको केवल आवश्यक स्लाइडें चुनने और आयात करने की अनुमति देता है। API मूल स्लाइडों की फ़ॉर्मेटिंग, लेआउट और डिज़ाइन को संरक्षित रखती है।

निम्नलिखित Java कोड एक नई प्रस्तुति बनाता है, दो अन्य प्रस्तुतियों से शीर्षक स्लाइडें जोड़ता है, और परिणाम को फ़ाइल में सहेजता है:

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

## **स्लाइड लेआउट के साथ प्रस्तुतियों को मिलाएँ**

मर्ज के दौरान आउटपुट स्लाइडों पर एक अलग स्लाइड लेआउट लागू करने के लिए, इसके बजाय [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISSlide-com.aspose.slides.ILayoutSlide-) विधि का उपयोग करें।

निम्नलिखित Java कोड दर्शाता है कि कई प्रस्तुतियों से स्लाइड्स को कैसे संयोजित किया जाए जबकि आपकी पसंदीदा स्लाइड लेआउट लागू की जाए, जिससे एकल आउटपुट प्रस्तुति प्राप्त हो:

```java
import com.aspose.slides.*;

int layoutIndex = 0;

Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    for (ISlide slide : presentation2.getSlides()) {
        ILayoutSlide layoutSlide = presentation1.getLayoutSlides().get_Item(layoutIndex);
        presentation1.getSlides().addClone(slide, layoutSlide);
    }
    presentation1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
}
```

## **विभिन्न स्लाइड आकारों के साथ प्रस्तुतियों को मिलाएँ**

भिन्न स्लाइड आकारों वाली दो प्रस्तुतियों को मिलाने के लिए, आपको उनमें से एक को दूसरे प्रस्तुति के स्लाइड आकार से मेल खाने के लिए पुनः आकार देना चाहिए।

निम्नलिखित Java कोड इस ऑपरेशन को दर्शाता है:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

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

## **स्लाइड्स को प्रस्तुति सेक्शन में मिलाएँ**

एक विशिष्ट प्रस्तुति सेक्शन में स्लाइड्स को मिलाना सामग्री को व्यवस्थित करने और स्लाइड नेविगेशन में सुधार करने में मदद करता है। Aspose.Slides आपको मौजूदा सेक्शन में स्लाइड्स को मिलाने की अनुमति देता है। यह प्रत्येक स्लाइड की मूल फ़ॉर्मेटिंग को संरक्षित रखते हुए स्पष्ट संरचना सुनिश्चित करता है।

निम्नलिखित Java कोड दर्शाता है कि एक विशिष्ट स्लाइड को प्रस्तुति के एक सेक्शन में कैसे मिलाएँ:

```java
import com.aspose.slides.*;

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

Aspose एक [नि:शुल्क ऑनलाइन कोलाज मेकर](https://products.aspose.app/slides/hi/collage) प्रदान करता है। इस ऑनलाइन सेवा का उपयोग करके, आप [JPG से JPG](https://products.aspose.app/slides/hi/collage/jpg) या PNG से PNG छवियों को मिलाकर, [फ़ोटो ग्रिड्स](https://products.aspose.app/slides/hi/collage/photo-grid) आदि बना सकते हैं।

[Aspose नि:शुल्क ऑनलाइन मर्जर](https://products.aspose.app/slides/hi/merger) देखें। यह आपको एक ही स्वरूप में PowerPoint प्रस्तुतियों को मिलाने की अनुमति देता है (जैसे, PPT से PPT, PPTX से PPTX) या विभिन्न स्वरूपों में (जैसे, PPT से PPTX, PPTX से ODP)।

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/hi/merger)

प्रस्तुतियों के अलावा, Aspose.Slides आपको अन्य फ़ाइलों को भी मिलाने की अनुमति देता है:

- **छवियां**, जैसे [JPG से JPG](https://products.aspose.com/slides/hi/java/merger/jpg-to-jpg/) या [PNG से PNG](https://products.aspose.com/slides/hi/java/merger/png-to-png/)
- **दस्तावेज़**, जैसे [PDF से PDF](https://products.aspose.com/slides/hi/java/merger/pdf-to-pdf/) या [HTML से HTML](https://products.aspose.com/slides/hi/java/merger/html-to-html/)
- **मिश्रित फ़ाइल प्रकार**, जैसे [image to PDF](https://products.aspose.com/slides/hi/java/merger/image-to-pdf/), [JPG to PDF](https://products.aspose.com/slides/hi/java/merger/jpg-to-pdf/), या [TIFF to PDF](https://products.aspose.com/slides/hi/java/merger/tiff-to-pdf/)

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या प्रस्तुतियों को मिलाते समय स्लाइडों की संख्या पर कोई सीमाएँ हैं?

कठोर सीमाएँ नहीं हैं। Aspose.Slides बड़े फ़ाइलों को संभाल सकता है, लेकिन प्रदर्शन फ़ाइल आकार और सिस्टम संसाधनों पर निर्भर करता है। अत्यधिक बड़ी प्रस्तुतियों के लिए 64‑bit JVM का उपयोग करने और पर्याप्त हीप मेमोरी आवंटित करने की सलाह दी जाती है।

### क्या मैं एम्बेडेड वीडियो या ऑडियो वाली प्रस्तुतियों को मिलाकर सकता हूँ?

हाँ, Aspose.Slides स्लाइड्स में एम्बेडेड मल्टीमीडिया सामग्री को संरक्षित रखता है, लेकिन अंतिम प्रस्तुति आकार काफी बड़ी हो सकती है।

### क्या प्रस्तुतियों को मिलाते समय फ़ॉन्ट्स संरक्षित रहते हैं?

हाँ। स्रोत प्रस्तुतियों में उपयोग किए गए फ़ॉन्ट्स आउटपुट फ़ाइल में संरक्षित रहते हैं, बशर्ते वे सिस्टम पर स्थापित हों या [embedded](/slides/hi/java/embedded-font/) हों।