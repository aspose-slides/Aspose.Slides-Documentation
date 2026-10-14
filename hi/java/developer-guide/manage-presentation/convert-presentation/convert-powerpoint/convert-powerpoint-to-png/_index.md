---
title: Java में PowerPoint स्लाइड्स को PNG में बदलें
linktitle: PowerPoint से PNG
type: docs
weight: 30
url: /hi/java/convert-powerpoint-to-png/
keywords:
- PowerPoint रूपांतरण
- प्रस्तुति रूपांतरण
- स्लाइड रूपांतरण
- PPT रूपांतरण
- PPTX रूपांतरण
- PowerPoint से PNG
- प्रस्तुति से PNG
- स्लाइड से PNG
- PPT से PNG
- PPTX से PNG
- PPT को PNG के रूप में सहेजें
- PPTX को PNG के रूप में सहेजें
- PPT को PNG में निर्यात करें
- PPTX को PNG में निर्यात करें
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint प्रस्तुतियों को तेज़ी से उच्च‑गुणवत्ता वाले PNG चित्रों में परिवर्तित करें, सटीक और स्वचालित परिणाम सुनिश्चित करते हुए।"
---
## **अवलोकन**

यह लेख बताता है कि Aspose.Slides for Java का उपयोग करके प्रस्तुति स्लाइड्स को PNG छवियों में कैसे बदलें। आप PPT, PPTX, और ODP जैसे फ़ॉर्मेट में प्रस्तुतियों को लोड कर सकते हैं, प्रत्येक स्लाइड को रेंडर कर सकते हैं, और इसे अलग‑अलग PNG छवि के रूप में सहेज सकते हैं।

नीचे दिए गए उदाहरण डिफ़ॉल्ट स्केल पर रेंडरिंग, स्केल बढ़ाने, पिक्सेल में आउटपुट आयाम निर्दिष्ट करने, और ग्रेडिएंट रेंडरिंग शैली चुनने को दर्शाते हैं।

## **PowerPoint को PNG में बदलें**

[Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) क्लास से प्रस्तुति लोड करें और उसकी स्लाइड्स को [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) संग्रह के माध्यम से एक्सेस करें। उदाहरण प्रत्येक स्लाइड को [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) बिना पैरामीटर के थंबनेल बनाने के लिये रेंडर करता है। फिर यह [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) को [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/#Png) के साथ कॉल करके प्रत्येक रेंडर की गई स्लाइड को PNG छवि के रूप में सहेजता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
पैरामीटर‑लेस [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) ओवरलोड 0.2 के स्केल पर रेंडर करता है। उदाहरण के लिये, 720 × 540 पॉइंट्स की एक स्लाइड 144 × 108 पिक्सेल थंबनेल उत्पन्न करती है। आउटपुट आयाम को नियंत्रित करने के लिये, नीचे दर्शाए गए स्केल फैक्टर या स्पष्ट छवि आकार वाले ओवरलोड का उपयोग करें।
{{% /alert %}}

## **PowerPoint को PNG में कस्टम आयामों के साथ बदलें**

रेन्डर किए गए आयामों को नियंत्रित करने के लिये [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-float-float-) को क्षैतिज और लंबवत स्केल फैक्टर पास करें। इस उदाहरण में दोनों फ़ैक्टर 2 हैं, इसलिए 720 × 540 पॉइंट्स की एक स्लाइड 1440 × 1080 पिक्सेल छवि बनाती है। समान स्केल फैक्टर स्लाइड के अनुपात को बनाए रखते हैं। प्रत्येक छवि को [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) के साथ PNG फ़ॉर्मेट में सहेजा जाता है।
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    float scaleX = 2f;
    float scaleY = scaleX;

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **PowerPoint को PNG में कस्टम आकार के साथ बदलें**

आउटपुट आयाम पिक्सेल में निर्दिष्ट करने के लिये, स्केल फ़ैक्टर के बजाय [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) को एक आकार पास करें। यह उदाहरण प्रत्येक स्लाइड को 960 × 720 पिक्सेल पर रेंडर करता है और परिणाम को [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) के साथ सहेजता है। स्लाइड के अनुपात से मेल खाने वाले आयाम चुनें ताकि छवि खिंचाव न हो।
```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Dimension imageSize = new Dimension(960, 720);

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **ग्रेडिएंट रेंडरिंग शैली चुनें**

मान लें कि किसी स्लाइड में ग्रेडिएंट फ़िल्स हैं, लेकिन निर्यात की गई PNG में ट्रांज़िशन PowerPoint में दिखने से हल्के या अलग दिखते हैं। आप [RenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/renderingoptions/) द्वारा विरासत में मिले [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setGradientStyle-int-) मेथड का उपयोग करके ग्रेडिएंट रेंडरिंग शैली चुन सकते हैं।

[gradient-styles.pptx](gradient-styles.pptx) डाउनलोड करें और इसे एप्लिकेशन की वर्किंग डायरेक्टरी में रखें। इसकी पहली स्लाइड में दो रैखिक ग्रेडिएंट हैं: ऊपर सियान से ऑरेंज और नीचे ब्लू से येलो। प्रत्येक ग्रेडिएंट में दो स्टॉप हैं, 0 % और 100 % पर।

निम्नलिखित उदाहरण इस प्रस्तुति को लोड करता है और दोनों मोड में वही पहली स्लाइड रेंडर करता है, [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) का उपयोग करके।
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("gradient-styles.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] gradientStyles = { GradientStyle.Default, GradientStyle.PowerPointUI };
    for (int style : gradientStyles) {
        RenderingOptions options = new RenderingOptions();
        options.setGradientStyle(style);

        String styleName = style == GradientStyle.Default ? "Default" : "PowerPointUI";
        IImage image = slide.getImage(options, 1f, 1f);
        try {
            image.save("gradient-" + styleName + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

छवियों में वही स्लाइड का आउटपुट दिखाया गया है, जहाँ प्रत्येक छवि में दोनों ग्रेडिएंट हैं:

| Default | PowerPointUI |
| --- | --- |
| ![डिफ़ॉल्ट के साथ सियान‑से‑ऑरेंज और ब्लू‑से‑येलो ग्रेडिएंट रेंडर किए गए](gradient-Default.png) | ![PowerPointUI के साथ समान ग्रेडिएंट रेंडर किए गए](gradient-PowerPointUI.png) |

इस उदाहरण में, `Default` मध्यवर्ती रंगों को हल्का बनाता है, जबकि `PowerPointUI` मध्यवर्ती रंगों को गहरा बनाता है। अंतर ग्रेडिएंट के रंगों और स्टॉप्स पर निर्भर करता है।

जब मानक Aspose.Slides आउटपुट आपके आवश्यकतानुसार हो, तो `Default` चुनें। जब आपका प्राथमिक लक्ष्य PowerPoint में दिखने वाले रूप से मेल खटना हो, तो `PowerPointUI` आज़माएँ। दोनों आउटपुट की तुलना अपने इच्छित परिणाम से करें; कोई भी मोड सार्वत्रिक रूप से श्रेष्ठ नहीं है।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं पूरी स्लाइड के बजाय एक विशिष्ट आकार, जैसे चार्ट या चित्र, कैसे निर्यात कर सकता हूँ?**

Aspose.Slides [वैयक्तिक आकार के थंबनेल बनाना](/slides/hi/java/create-shape-thumbnails/) का समर्थन करता है, जिससे आप एक आकार को PNG छवि के रूप में रेंडर कर सकते हैं।

**क्या सर्वर पर समानांतर रूपांतरण समर्थित है?**

हाँ। प्रत्येक थ्रेड या प्रोसेस के लिये अलग प्रस्तुति इंस्टेंस का उपयोग करें; [थ्रेड्स के बीच एक ही इंस्टेंस साझा न करें](/slides/hi/java/multithreading/)।

**PNG निर्यात करते समय मूल्यांकन सीमाएँ क्या हैं?**

मूल्यांकन मोड आउटपुट छवियों पर वॉटरमार्क जोड़ता है और [अन्य प्रतिबंध](/slides/hi/java/licensing/) लागू करता है जब तक लाइसेंस लागू न किया गया हो।