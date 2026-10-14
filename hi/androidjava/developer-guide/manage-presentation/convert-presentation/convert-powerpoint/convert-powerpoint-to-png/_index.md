---
title: Android पर PowerPoint स्लाइड्स को PNG में बदलें
linktitle: PowerPoint से PNG
type: docs
weight: 30
url: /hi/androidjava/convert-powerpoint-to-png/
keywords:
- PowerPoint को परिवर्तित करें
- प्रस्तुति को परिवर्तित करें
- स्लाइड को परिवर्तित करें
- PPT को परिवर्तित करें
- PPTX को परिवर्तित करें
- PowerPoint से PNG
- प्रस्तुति से PNG
- स्लाइड से PNG
- PPT से PNG
- PPTX से PNG
- PPT को PNG के रूप में सहेजें
- PPTX को PNG के रूप में सहेजें
- PPT को PNG में निर्यात करें
- PPTX को PNG में निर्यात करें
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके PowerPoint प्रस्तुतियों को उच्च‑गुणवत्ता वाले PNG छवियों में तेज़ी से बदलें, जिससे सटीक और स्वचालित परिणाम सुनिश्चित हों।"
---
## **अवलोकन**

यह लेख समझाता है कि Aspose.Slides for Android via Java का उपयोग करके प्रेजेंटेशन स्लाइड्स को PNG छवियों में कैसे बदलें। आप PPT, PPTX और ODP जैसे फ़ॉर्मैट में प्रस्तुतियों को लोड कर सकते हैं, प्रत्येक स्लाइड को रेंडर कर सकते हैं, और इसे अलग‑अलग PNG छवि के रूप में सहेज सकते हैं।

नीचे के उदाहरण डिफ़ॉल्ट स्केल पर रेंडरिंग, स्केल बढ़ाने, पिक्सेल में आउटपुट आयाम निर्धारित करने, और ग्रेडिएंट रेंडरिंग शैली चुनने को दर्शाते हैं।

## **PowerPoint को PNG में परिवर्तित करें**

एक प्रस्तुति को [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) क्लास से लोड करें और उसके स्लाइड्स को [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) संग्रह के माध्यम से पहुँचें। उदाहरण प्रत्येक स्लाइड को [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) (कोई पैरामीटर नहीं) से थंबनेल बनाता है। फिर यह प्रत्येक रेंडर की गई स्लाइड को PNG छवि के रूप में सहेजने के लिए [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) को [ImageFormat.Png](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imageformat/#Png) के साथ कॉल करता है।

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
पैरामीटर‑लेस [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) ओवरलोड 0.2 स्केल पर रेंडर करता है। उदाहरण के लिए, 720 × 540 पॉइंट्स वाली स्लाइड 144 × 108 पिक्सेल का थंबनेल बनाती है। आउटपुट आयाम को नियंत्रित करने के लिए नीचे दिखाए गए स्केल फ़ैक्टर या स्पष्ट छवि आकार वाले ओवरलोड का उपयोग करें।
{{% /alert %}}

## **PowerPoint को PNG में कस्टम आयामों के साथ परिवर्तित करें**

हॉरिज़ोंटल और वर्टिकल स्केल फ़ैक्टर को [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-float-float-) में पास करें ताकि रेंडर किए गए आयाम नियंत्रित हो सकें। इस उदाहरण में दोनों फ़ैक्टर 2 हैं, इसलिए 720 × 540 पॉइंट्स वाली स्लाइड 1440 × 1080 पिक्सेल की छवि बनाती है। समान स्केल फ़ैक्टर स्लाइड का अनुपात बनाए रखते हैं। प्रत्येक छवि को PNG फ़ॉर्मेट में [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) से सहेजा जाता है।

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

## **PowerPoint को PNG में कस्टम आकार के साथ परिवर्तित करें**

आउटपुट आयाम पिक्सेल में निर्दिष्ट करने के लिए स्केल फ़ैक्टर की बजाय एक आकार को [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) में पास करें। यह उदाहरण प्रत्येक स्लाइड को 960 × 720 पिक्सेल पर रेंडर करता है और परिणाम को [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) से सहेजता है। छवि को खींचने से बचने के लिए स्लाइड के अनुपात से मेल खाने वाले आयाम चुनें।

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Size imageSize = new Size(960, 720);

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

मान लें कि एक स्लाइड में ग्रेडिएंट फिल हैं, लेकिन निर्यात की गई PNG में ट्रांज़िशन PowerPoint में दिखने से हल्की या अलग दिखती हैं। आप [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setGradientStyle-int-) मेथड (जो [RenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/renderingoptions/) से विरासत में मिला है) का उपयोग करके ग्रेडिएंट रेंडरिंग को नियंत्रित कर सकते हैं।

डाउनलोड [gradient-styles.pptx](gradient-styles.pptx) और इसे एप्लिकेशन की कार्यशील निर्देशिका में रखें। इसकी पहली स्लाइड में दो लाइनर ग्रेडिएंट हैं: ऊपर सायन से ऑरेंज और नीचे ब्लू से येलो। प्रत्येक ग्रेडिएंट में दो स्टॉप हैं, 0 % और 100 % पर।

निम्न उदाहरण इस प्रस्तुति को लोड करता है और दोनों मोड में वही पहली स्लाइड को [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) से रेंडर करता है।

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

नीचे की छवियों में एक ही स्लाइड के आउटपुट को दिखाया गया है, प्रत्येक छवि में दोनों ग्रेडिएंट्स के साथ:

| Default | PowerPointUI |
| --- | --- |
| ![डिफ़ॉल्ट के साथ रेंडर किए गए सायन‑से‑ऑरेंज और ब्लू‑से‑येलो ग्रेडिएंट्स](gradient-Default.png) | ![PowerPointUI के साथ रेंडर किए गए समान ग्रेडिएंट्स](gradient-PowerPointUI.png) |

इस उदाहरण में `Default` मध्यम रंगों को हल्का बनाता है, जबकि `PowerPointUI` उन्हें गहरा बनाता है। अंतर ग्रेडिएंट के रंगों और स्टॉप पर निर्भर करता है।

जब Aspose.Slides का मानक आउटपुट आपकी जरूरतों को पूरा करता है, तब `Default` चुनें। यदि आपका प्राथमिक लक्ष्य PowerPoint में दिखने वाले स्वरूप से मेल खाना है, तो `PowerPointUI` आज़माएँ। दोनों आउटपुट की अपनी‑अपनी अपेक्षित परिणाम के साथ तुलना करें; कोई भी मोड सार्वभौमिक रूप से श्रेष्ठ नहीं है।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं पूरी स्लाइड के बजाय कोई विशेष आकार, जैसे चार्ट या चित्र, कैसे निर्यात करूँ?**  
Aspose.Slides [individual shapes के लिए थंबनेल जेनरेट करने](/slides/hi/androidjava/create-shape-thumbnails/) का समर्थन करता है, जिससे आप किसी आकार को PNG छवि के रूप में रेंडर कर सकते हैं।

**क्या सर्वर पर समानांतर रूपांतरण समर्थित है?**  
हाँ। प्रत्येक थ्रेड या प्रोसेस के लिए एक अलग प्रस्तुति इंस्टैंस का उपयोग करें; [थ्रेड्स के बीच एक ही इंस्टैंस साझा न करें](/slides/hi/androidjava/multithreading/)।

**PNG निर्यात के दौरान मूल्यांकन मोड की क्या सीमाएँ हैं?**  
मूल्यांकन मोड आउटपुट छवियों पर वॉटरमार्क जोड़ता है और [अन्य प्रतिबंध](/slides/hi/androidjava/licensing/) लागू करता है, जब तक कि लाइसेंस लागू न किया जाए।