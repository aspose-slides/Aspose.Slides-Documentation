---
title: Android पर PPT और PPTX को JPG में परिवर्तित करें
linktitle: PowerPoint को JPG में
type: docs
weight: 60
url: /hi/androidjava/convert-powerpoint-to-jpg/
keywords:
- PowerPoint परिवर्तित करें
- प्रेजेंटेशन परिवर्तित करें
- स्लाइड परिवर्तित करें
- PPT परिवर्तित करें
- PPTX परिवर्तित करें
- PowerPoint को JPG में
- प्रेजेंटेशन को JPG में
- स्लाइड को JPG में
- PPT को JPG में
- PPTX को JPG में
- PowerPoint को JPG के रूप में सहेजें
- प्रेजेंटेशन को JPG के रूप में सहेजें
- स्लाइड को JPG के रूप में सहेजें
- PPT को JPG के रूप में सहेजें
- PPTX को JPG के रूप में सहेजें
- PPT को JPG में निर्यात करें
- PPTX को JPG में निर्यात करें
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android का उपयोग करके जावा में तेज़ और विश्वसनीय कोड उदाहरणों के साथ PowerPoint (PPT, PPTX) स्लाइड्स को उच्च गुणवत्ता वाली JPG छवियों में परिवर्तित करें।"
---
## **परिचय**

PowerPoint और OpenDocument प्रस्तुतियों को JPG छवियों में परिवर्तित करना स्लाइड्स को साझा करने, प्रदर्शन को अनुकूलित करने और वेबसाइटों या अनुप्रयोगों में सामग्री एम्बेड करने में मदद करता है। Aspose.Slides for Android via Java आपको PPTX, PPT, और ODP फ़ाइलों को उच्च गुणवत्ता वाली JPEG छवियों में बदलने की अनुमति देती है। यह गाइड रूपांतरण के विभिन्न तरीकों को समझाता है।

इन सुविधाओं के साथ, अपना स्वयं का प्रस्तुति व्यूअर लागू करना और प्रत्येक स्लाइड के लिए थंबनेल बनाना आसान हो जाता है। यह तब उपयोगी हो सकता है जब आप प्रस्तुति स्लाइड्स को कॉपी से बचाना चाहते हैं या प्रस्तुति को केवल‑पठन मोड में प्रदर्शित करना चाहते हैं। Aspose.Slides आपको पूरी प्रस्तुति या किसी विशिष्ट स्लाइड को इमेज फ़ॉर्मैट में बदलने की सुविधा देता है।

## **प्रस्तुति स्लाइड्स को JPG छवियों में परिवर्तित करें**

PPT, PPTX, या ODP फ़ाइल को JPG में परिवर्तित करने के लिए ये चरण हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएं।
2. [Presentation.getSlides()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getSlides--) मेथड द्वारा लौटाए गए संग्रह से प्रकार [ISlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/) का स्लाइड ऑब्जेक्ट प्राप्त करें।
3. [ISlide.getImage(float, float)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/#getImage-float-float-) मेथड का उपयोग करके स्लाइड की एक छवि बनाएं।
4. छवि ऑब्जेक्ट पर [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) मेथड को कॉल करें। आउटपुट फ़ाइल नाम और इमेज फ़ॉर्मेट को तर्कों के रूप में पास करें।

{{% alert color="primary" %}} 

**नोट:** PPT, PPTX, या ODP से JPG रूपांतरण Aspose.Slides Android via Java API में अन्य फ़ॉर्मैट्स में रूपांतरण से अलग है। अन्य फ़ॉर्मैट्स के लिए, आप आमतौर पर [IPresentation.save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) मेथड का उपयोग करते हैं। हालांकि, JPG रूपांतरण के लिए आपको [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) मेथड का उपयोग करना होगा।

{{% /alert %}} 

```java
int scaleX = 1;
int scaleY = scaleX;

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // निर्दिष्ट स्केल की स्लाइड इमेज बनाएं।
        IImage slideImage = slide.getImage(scaleX, scaleY);

        try {
            // इमेज को JPEG फॉर्मेट में डिस्क पर सहेजें।
            String fileName = String.format("Slide_%d.jpg", slide.getSlideNumber());
            slideImage.save(fileName, ImageFormat.Jpeg);
        } finally {
            slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **कस्टम आकार के साथ स्लाइड्स को JPG में परिवर्तित करें**

परिणामी JPG छवियों के आयाम बदलने के लिए, आप [ISlide.getImage(Size)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) मेथड में इसे पास करके इमेज का आकार सेट कर सकते हैं। इससे आप विशिष्ट चौड़ाई और ऊँचाई मानों वाली छवियां बनाते हैं, जिससे आउटपुट आपके रिज़ॉल्यूशन और आस्पेक्ट रेशियो की आवश्यकताओं को पूरा करता है। यह लचीलापन विशेष रूप से वेब एप्लिकेशन्स, रिपोर्ट्स या दस्तावेज़ीकरण के लिए छवियां जनरेट करते समय उपयोगी है, जहाँ सटीक इमेज डाइमेंशन की आवश्यकता होती है।

```java
Size imageSize = new Size(1200, 800);

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // निर्दिष्ट आकार की स्लाइड इमेज बनाएं।
        IImage slideImage = slide.getImage(imageSize);

        try {
            // इमेज को JPEG फॉर्मेट में डिस्क पर सहेजें।
            String fileName = String.format("Slide_%d.jpg", slide.getSlideNumber());
            slideImage.save(fileName, ImageFormat.Jpeg);
        } finally {
            slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **छवियों के रूप में स्लाइड्स को सहेजते समय टिप्पणी रेंडर करें**

Aspose.Slides for Android via Java एक ऐसी सुविधा प्रदान करता है जो आपको प्रस्तुति की स्लाइड्स पर टिप्पणी को रेंडर करने की अनुमति देती है जब उन्हें JPG छवियों में परिवर्तित किया जाता है। यह कार्यक्षमता विशेष रूप से PowerPoint प्रस्तुतियों में सहयोगियों द्वारा जोड़े गए एनोटेशन, फीडबैक या चर्चाओं को संरक्षित रखने में उपयोगी है। इस विकल्प को सक्षम करके आप सुनिश्चित करते हैं कि टिप्पणियां उत्पन्न छवियों में दृश्यमान हों, जिससे मूल प्रस्तुति फ़ाइल खोले बिना फीडबैक की समीक्षा और साझा करना आसान हो जाता है।

मान लीजिए हमारे पास "sample.pptx" नामक एक प्रस्तुति फ़ाइल है, जिसमें एक स्लाइड पर टिप्पणियां हैं:

![टिप्पणियों वाली स्लाइड](slide_with_comments.png)

निम्नलिखित Java कोड स्लाइड को JPG छवि में परिवर्तित करता है जबकि टिप्पणियों को संरक्षित रखता है:

```java
int scaleX = 2;
int scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    NotesCommentsLayoutingOptions commentsOptions = new NotesCommentsLayoutingOptions();
    commentsOptions.setCommentsPosition(CommentsPositions.Right);
    commentsOptions.setCommentsAreaWidth(200);
    commentsOptions.setCommentsAreaColor(Color.rgb(255, 140, 0));

    IRenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(commentsOptions);

    // पहली स्लाइड को इमेज में परिवर्तित करें।
    IImage slideImage = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        slideImage.save("Slide_1.jpg", ImageFormat.Jpeg);
    } finally {
        slideImage.dispose();
    }
} finally {
    presentation.dispose();
}
```

परिणाम:

![टिप्पणियों के साथ JPG छवि](image_with_comments.png)

## **और देखें**

PPT, PPTX, या ODP को छवियों में परिवर्तित करने के अन्य विकल्प देखें, जैसे:

- [PowerPoint को GIF में परिवर्तित करें](/slides/hi/androidjava/convert-powerpoint-to-animated-gif/)
- [PowerPoint को PNG में परिवर्तित करें](/slides/hi/androidjava/convert-powerpoint-to-png/)
- [PowerPoint को TIFF में परिवर्तित करें](/slides/hi/androidjava/convert-powerpoint-to-tiff/)
- [PowerPoint को SVG में परिवर्तित करें](/slides/hi/androidjava/render-a-slide-as-an-svg-image/)

{{% alert color="primary" %}} 

यह देखने के लिए कि Aspose.Slides PowerPoint प्रस्तुतियों को JPG छवियों में कैसे परिवर्तित करता है, इन मुफ्त ऑनलाइन कनवर्टर्स को आज़माएँ: PowerPoint [PPTX को JPG](https://products.aspose.app/slides/hi/conversion/pptx-to-jpg) और [PPT को JPG](https://products.aspose.app/slides/hi/conversion/ppt-to-jpg)। 

{{% /alert %}} 

![फ़्री ऑनलाइन PPTX से JPG कनवर्टर](ppt-to-jpg.png)

{{% alert title="Tip" color="primary" %}}

Aspose एक [FREE Collage वेब ऐप](https://products.aspose.app/slides/hi/collage) प्रदान करता है। इस ऑनलाइन सेवा का उपयोग करके, आप [JPG to JPG](https://products.aspose.app/slides/hi/collage/jpg) या PNG to PNG छवियों को मर्ज कर सकते हैं, [photo grids](https://products.aspose.app/slides/hi/collage/photo-grid) बना सकते हैं, आदि। 

इस लेख में वर्णित समान सिद्धांतों का उपयोग करके, आप एक फ़ॉर्मैट से दूसरे फ़ॉर्मैट में छवियों को बदल सकते हैं। अधिक जानकारी के लिए इन पेजों को देखें: convert [image to JPG](https://products.aspose.com/slides/hi/java/conversion/image-to-jpg/); convert [JPG to image](https://products.aspose.com/slides/hi/java/conversion/jpg-to-image/); convert [JPG to PNG](https://products.aspose.com/slides/hi/java/conversion/jpg-to-png/), convert [PNG to JPG](https://products.aspose.com/slides/hi/java/conversion/png-to-jpg/); convert [PNG to SVG](https://products.aspose.com/slides/hi/java/conversion/png-to-svg/), convert [SVG to PNG](https://products.aspose.com/slides/hi/java/conversion/svg-to-png/)।

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या यह विधि बैच रूपांतरण को सपोर्ट करती है?**

हां, Aspose.Slides कई स्लाइड्स को एक ही ऑपरेशन में JPG में बैच रूपांतरण की अनुमति देता है।

**क्या रूपांतरण SmartArt, चार्ट्स और अन्य जटिल ऑब्जेक्ट्स का समर्थन करता है?**

हां, Aspose.Slides सभी सामग्री को रेंडर करता है, जिसमें SmartArt, चार्ट्स, टेबल्स, शेप्स और अधिक शामिल हैं। हालांकि, रेंडरिंग की सटीकता PowerPoint की तुलना में थोड़ी भिन्न हो सकती है, विशेषकर कस्टम या अनुपलब्ध फ़ॉन्ट्स के उपयोग पर।

**क्या प्रोसेस की जा सकने वाली स्लाइड्स की संख्या पर कोई सीमाएं हैं?**

Aspose.Slides स्वयं प्रोसेस की जा सकने वाली स्लाइड्स की संख्या पर कोई कड़ी सीमा नहीं लगाता। हालांकि, बड़े प्रस्तुतियों या उच्च रेज़ॉल्यूशन छवियों के साथ काम करते समय आपको मेमोरी समाप्ति (out-of-memory) त्रुटि का सामना करना पड़ सकता है।