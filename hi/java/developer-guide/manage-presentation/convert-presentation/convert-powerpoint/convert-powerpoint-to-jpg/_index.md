---
title: Java में PPT और PPTX को JPG में बदलें
linktitle: PowerPoint से JPG
type: docs
weight: 60
url: /hi/java/convert-powerpoint-to-jpg/
keywords: 
- PowerPoint को बदलें
- प्रेजेंटेशन को बदलें
- स्लाइड को बदलें
- PPT को बदलें
- PPTX को बदलें
- PowerPoint से JPG
- प्रेजेंटेशन से JPG
- स्लाइड से JPG
- PPT से JPG
- PPTX से JPG
- PowerPoint को JPG के रूप में सहेजें
- प्रेजेंटेशन को JPG के रूप में सहेजें
- स्लाइड को JPG के रूप में सहेजें
- PPT को JPG के रूप में सहेजें
- PPTX को JPG के रूप में सहेजें
- PPT को JPG में निर्यात करें
- PPTX को JPG में निर्यात करें
- Java
- Aspose.Slides
description: "Aspose.Slides for Java का उपयोग करके तेज़ और भरोसेमंद कोड उदाहरणों के साथ Java में PowerPoint (PPT, PPTX) स्लाइड को उच्च-गुणवत्ता वाली JPG छवियों में बदलें।"
---
## **परिचय**

PowerPoint और OpenDocument प्रस्तुतियों को JPG छवियों में बदलने से स्लाइड शेयर करना, प्रदर्शन को अनुकूलित करना, और वेबसाइटों या एप्लिकेशन में सामग्री एम्बेड करना आसान हो जाता है। Aspose.Slides आपको PPTX, PPT, और ODP फाइलों को उच्च‑गुणवत्ता वाली JPEG छवियों में बदलने की अनुमति देता है। यह गाइड रूपांतरण के विभिन्न तरीकों को समझाता है।

इन सुविधाओं के साथ, अपना स्वयं का प्रस्तुति दर्शक लागू करना और प्रत्येक स्लाइड के लिए थंबनेल बनाना आसान हो जाता है। यह उपयोगी हो सकता है यदि आप प्रस्तुति स्लाइड को कॉपी से बचाना चाहते हैं या केवल‑पढ़ने योग्य मोड में प्रस्तुति दिखाना चाहते हैं। Aspose.Slides आपको पूरी प्रस्तुति या किसी विशिष्ट स्लाइड को छवि स्वरूपों में बदलने की अनुमति देता है।

## **PowerPoint PPT/PPTX को JPG में परिवर्तित करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) प्रकार की इंस्टेंस बनाएं।
2. [Presentation.getSlides()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getSlides--) संग्रह से [ISlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlide) प्रकार का स्लाइड ऑब्जेक्ट प्राप्त करें।
3. प्रत्येक स्लाइड का थंबनेल बनाएं और फिर उसे JPG में बदलें। [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlide#getImage-float-float-) मेथड का उपयोग स्लाइड का थंबनेल प्राप्त करने के लिए किया जाता है, यह परिणामस्वरूप [Images](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Images) ऑब्जेक्ट लौटाता है। [getImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) मेथड को आवश्यक [ISlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlide) प्रकार की स्लाइड से कॉल किया जाना चाहिए, और परिणामस्वरूप थंबनेल के स्केल को मेथड में पास किया जाता है।
4. स्लाइड थंबनेल प्राप्त करने के बाद, थंबनेल ऑब्जेक्ट से [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) मेथड को कॉल करें। इसमें परिणामस्वरूप फ़ाइल नाम और छवि फ़ॉर्मेट पास करें।

{{% alert color="info" %}}

**नोट**: PPT/PPTX को JPG में रूपांतरण Aspose.Slides API में अन्य प्रकारों के रूपांतरण से अलग होता है। अन्य प्रकारों के लिए, आप आमतौर पर [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) मेथड का उपयोग करते हैं, लेकिन यहाँ आपको [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) मेथड की आवश्यकता होती है।

{{% /alert %}} 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // पूर्ण स्केल छवि बनाता है
        IImage slideImage = sld.getImage(1f, 1f);

        // छवि को JPEG प्रारूप में डिस्क पर सहेजता है
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **PowerPoint PPT/PPTX को कस्टमाइज़्ड डायमेंशन के साथ JPG में बदलें**

परिणामी थंबनेल और JPG छवि का आयाम बदलने के लिए, आप *ScaleX* और *ScaleY* मानों को [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlide#getImage-float-float-) मेथड में पास करके सेट कर सकते हैं:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // आयाम परिभाषित करता है
    int desiredX = 1200;
    int desiredY = 800;
    // X और Y के स्केल किए हुए मान प्राप्त करता है
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // पूर्ण स्केल वाली छवि बनाता है
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // छवि को JPEG प्रारूप में डिस्क पर सहेजता है
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **स्लाइड को छवि के रूप में सहेजते समय टिप्पणी रेंडर करें**

Aspose.Slides for Java एक सुविधा प्रदान करता है जो आपको स्लाइड्स को छवियों में परिवर्तित करते समय प्रस्तुति की स्लाइड्स में टिप्पणियों को रेंडर करने की अनुमति देती है। यह Java कोड इस ऑपरेशन को दर्शाता है:

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);
    notesOptions.setCommentsPosition(CommentsPositions.Right);
    notesOptions.setCommentsAreaWidth(200);

    IRenderingOptions opts = new RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);

    for (ISlide sld : pres.getSlides()) {
        IImage slideImage = sld.getImage(opts, new Dimension(740, 960));
        try {
             slideImage.save(String.format("Slide_%d.png", sld.getSlideNumber()));
        } finally {
                     if (slideImage != null) slideImage.dispose();
                }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="info" %}}

Aspose एक [FREE Collage web app](https://products.aspose.app/slides/hi/collage) प्रदान करता है। इस ऑनलाइन सेवा का उपयोग करके आप [JPG to JPG](https://products.aspose.app/slides/hi/collage/jpg) या PNG से PNG छवियों को मर्ज कर सकते हैं, [photo grids](https://products.aspose.app/slides/hi/collage/photo-grid) बना सकते हैं, आदि।

इस लेख में वर्णित वही सिद्धांतों का उपयोग करके, आप छवियों को एक फ़ॉर्मेट से दूसरे फ़ॉर्मेट में बदल सकते हैं। अधिक जानकारी के लिए, इन पृष्ठों को देखें: परिवर्तित करें [image to JPG](https://products.aspose.com/slides/hi/java/conversion/image-to-jpg/); परिवर्तित करें [JPG to image](https://products.aspose.com/slides/hi/java/conversion/jpg-to-image/); परिवर्तित करें [JPG to PNG](https://products.aspose.com/slides/hi/java/conversion/jpg-to-png/), परिवर्तित करें [PNG to JPG](https://products.aspose.com/slides/hi/java/conversion/png-to-jpg/); परिवर्तित करें [PNG to SVG](https://products.aspose.com/slides/hi/java/conversion/png-to-svg/), परिवर्तित करें [SVG to PNG](https://products.aspose.com/slides/hi/java/conversion/svg-to-png/)।

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या यह विधि बैच रूपांतरण का समर्थन करती है?

हाँ, Aspose.Slides एक ही ऑपरेशन में कई स्लाइड्स को JPG में बैच रूपांतरण की अनुमति देता है।

### क्या रूपांतरण SmartArt, चार्ट, और अन्य जटिल ऑब्जेक्ट्स का समर्थन करता है?

हाँ, Aspose.Slides सभी सामग्री को रेंडर करता है, जिसमें SmartArt, चार्ट, टेबल, शैप्स, आदि शामिल हैं। हालांकि, रेंडरिंग की सटीकता PowerPoint की तुलना में थोड़ी भिन्न हो सकती है, विशेष रूप से कस्टम या अनुपलब्ध फ़ॉन्ट्स के उपयोग पर।

### क्या प्रक्रिया की जा सकने वाली स्लाइड्स की संख्या पर कोई प्रतिबंध है?

Aspose.Slides स्वयं प्रक्रिया की जा सकने वाली स्लाइड्स की संख्या पर कोई सख्त सीमा नहीं लगाता। हालांकि, बड़ी प्रस्तुतियों या हाई‑रेज़ोल्यूशन छवियों के साथ काम करते समय आपको मेमोरी समाप्त होने की त्रुटि का सामना करना पड़ सकता है।

## **संबंधित**

PPT/PPTX को छवि में बदलने के अन्य विकल्प देखें, जैसे:

- [PPT/PPTX से SVG रूपांतरण](/slides/hi/java/render-a-slide-as-an-svg-image/).