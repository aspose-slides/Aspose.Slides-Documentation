---
title: Java में PPT और PPTX को JPG में बदलें
linktitle: PowerPoint से JPG
type: docs
weight: 60
url: /hi/java/convert-powerpoint-to-jpg/
keywords:
- PowerPoint बदलें
- प्रेजेंटेशन बदलें
- स्लाइड बदलें
- PPT बदलें
- PPTX बदलें
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
description: "Aspose.Slides for Java का उपयोग करके तेज़ और विश्वसनीय कोड उदाहरणों के साथ Java में PowerPoint (PPT, PPTX) स्लाइड्स को उच्च गुणवत्ता वाली JPG छवियों में बदलें।"
---
## **परिचय**

PowerPoint और OpenDocument प्रस्तुतियों को JPG छवियों में बदलने से स्लाइड्स को साझा करने, प्रदर्शन को अनुकूलित करने और सामग्री को वेबसाइट या एप्लिकेशन में एम्बेड करने में मदद मिलती है। Aspose.Slides आपको PPTX, PPT और ODP फ़ाइलों को उच्च-गुणवत्ता वाली JPEG छवियों में रूपांतरण करने की अनुमति देता है। यह गाइड विभिन्न रूपांतरण विधियों को समझाता है।

इन सुविधाओं के साथ, अपना स्वयं का प्रस्तुति व्यूअर लागू करना और प्रत्येक स्लाइड के लिए थंबनेल बनाना आसान है। यह उपयोगी हो सकता है यदि आप प्रस्तुति स्लाइड्स को कॉपी करने से सुरक्षित रखना चाहते हैं या केवल-पढ़ने के मोड में प्रस्तुति को प्रदर्शित करना चाहते हैं। Aspose.Slides आपको पूरी प्रस्तुति या विशिष्ट स्लाइड को इमेज फॉर्मेट में बदलने की अनुमति देता है।

## **PowerPoint PPT/PPTX को JPG में परिवर्तित करें**

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) प्रकार का एक उदाहरण बनाएँ।
2. [ISlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlide) प्रकार का स्लाइड ऑब्जेक्ट [Presentation.getSlides()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getSlides--) संग्रह से प्राप्त करें।
3. प्रत्येक स्लाइड का थंबनेल बनाएं और फिर उसे JPG में बदलें। [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlide#getImage-float-float-) मेथड का उपयोग स्लाइड का थंबनेल प्राप्त करने के लिए किया जाता है, यह एक [Images](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Images) ऑब्जेक्ट को परिणाम के रूप में लौटाता है। [getImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) मेथड को आवश्यक [ISlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlide) प्रकार की स्लाइड से कॉल करना आवश्यक है, परिणामस्वरूप थंबनेल के स्केल को मेथड में पास किया जाता है।
4. स्लाइड थंबनेल प्राप्त करने के बाद, थंबनेल ऑब्जेक्ट से [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) मेथड को कॉल करें। इसमें परिणामी फ़ाइल नाम और इमेज फ़ॉर्मेट पास करें।

{{% alert color="primary" %}}
**नोट**: PPT/PPTX को JPG में रूपांतरण Aspose.Slides API में अन्य प्रकारों के रूपांतरण से अलग है। अन्य प्रकारों के लिए, आप आमतौर पर [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) मेथड का उपयोग करते हैं, लेकिन यहाँ आपको [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) मेथड की आवश्यकता है।
{{% /alert %}} 

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // पूर्ण स्केल छवि बनाता है
        IImage slideImage = sld.getImage(1f, 1f);

        // इमेज को डिस्क पर JPEG फ़ॉर्मेट में सहेजता है
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

## **PowerPoint PPT/PPTX को कस्टमाइज़्ड डाइमेंशन के साथ JPG में परिवर्तित करें**

परिणामी थंबनेल और JPG छवि का आकार बदलने के लिए, आप *ScaleX* और *ScaleY* मानों को [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlide#getImage-float-float-) मेथड में पास करके सेट कर सकते हैं:

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // आयाम निर्धारित करता है
    int desiredX = 1200;
    int desiredY = 800;
    // X और Y के स्केल किए हुए मान प्राप्त करता है
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // पूर्ण स्केल छवि बनाता है
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // इमेज को डिस्क पर JPEG फ़ॉर्मेट में सहेजता है
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

## **स्लाइडों को इमेज के रूप में सेव करते समय टिप्पणियों को रेंडर करें**

Aspose.Slides for Java एक सुविधा प्रदान करता है जो आपको स्लाइडों को इमेज में बदलते समय प्रस्तुति की स्लाइडों में टिप्पणियों को रेंडर करने की अनुमति देता है। यह Java कोड इस क्रिया को दर्शाता है:

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);

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

{{% alert title="Tip" color="primary" %}}
Aspose एक [निःशुल्क Collage वेब ऐप](https://products.aspose.app/slides/hi/collage) प्रदान करता है। इस ऑनलाइन सेवा का उपयोग करके आप [JPG से JPG](https://products.aspose.app/slides/hi/collage/jpg) या PNG से PNG छवियों को मर्ज कर सकते हैं, [फ़ोटो ग्रिड्स](https://products.aspose.app/slides/hi/collage/photo-grid) बना सकते हैं, आदि। 

इस लेख में वर्णित समान सिद्धांतों का उपयोग करके आप छवियों को एक फ़ॉर्मेट से दूसरे फ़ॉर्मेट में बदल सकते हैं। अधिक जानकारी के लिए इन पृष्ठों को देखें: convert [image to JPG](https://products.aspose.com/slides/hi/java/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/hi/java/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/hi/java/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/hi/java/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/hi/java/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/hi/java/conversion/svg-to-png/).
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या यह विधि बैच रूपांतरण का समर्थन करती है?**

हाँ, Aspose.Slides कई स्लाइड्स को एक ही ऑपरेशन में JPG में बैच रूपांतरण की अनुमति देता है।

**क्या रूपांतरण SmartArt, चार्ट और अन्य जटिल ऑब्जेक्ट्स का समर्थन करता है?**

हाँ, Aspose.Slides सभी सामग्री को रेंडर करता है, जिसमें SmartArt, चार्ट, टेबल, आकृतियां और अधिक शामिल हैं। हालांकि, रेंडरिंग की शुद्धता PowerPoint की तुलना में थोड़ा भिन्न हो सकती है, विशेष रूप से कस्टम या अनुपलब्ध फ़ॉन्ट का उपयोग करने पर।

**क्या प्रोसेस किए जा सकने वाले स्लाइड्स की संख्या पर कोई सीमा है?**

Aspose.Slides स्वयं प्रोसेस की जा सकने वाली स्लाइड्स की संख्या पर कोई सख्त सीमा नहीं लगाता है। हालांकि, बड़े प्रस्तुतियों या उच्च-रिज़ॉल्यूशन छवियों के साथ काम करते समय आप मेमोरी समाप्ति त्रुटि का सामना कर सकते हैं।

## **अधिक देखें**

PPT/PPTX को इमेज में बदलने के अन्य विकल्प देखें जैसे:

- [PPT/PPTX से SVG रूपांतरण](/slides/hi/java/render-a-slide-as-an-svg-image/).