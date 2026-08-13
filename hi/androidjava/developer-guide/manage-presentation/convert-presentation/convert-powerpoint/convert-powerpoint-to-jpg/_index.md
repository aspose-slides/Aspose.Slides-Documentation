---
title: Android पर PPT और PPTX को JPG में बदलें
linktitle: PowerPoint को JPG में बदलें
type: docs
weight: 60
url: /hi/androidjava/convert-powerpoint-to-jpg/
keywords:
- PowerPoint बदलें
- प्रस्तुति बदलें
- स्लाइड बदलें
- PPT बदलें
- PPTX बदलें
- PowerPoint को JPG में
- प्रस्तुति को JPG में
- स्लाइड को JPG में
- PPT को JPG में
- PPTX को JPG में
- PowerPoint को JPG के रूप में सहेजें
- प्रस्तुति को JPG के रूप में सहेजें
- स्लाइड को JPG के रूप में सहेजें
- PPT को JPG के रूप में सहेजें
- PPTX को JPG के रूप में सहेजें
- PPT को JPG में निर्यात करें
- PPTX को JPG में निर्यात करें
- एंड्रॉइड
- जावा
- Aspose.Slides
description: "Aspose.Slides for Android का उपयोग करके जावा में PowerPoint (PPT, PPTX) स्लाइडों को तेज, विश्वसनीय कोड उदाहरणों के साथ उच्च‑गुणवत्ता वाली JPG छवियों में बदलें।"
---
## **परिचय**

PowerPoint और OpenDocument प्रस्तुतियों को JPG छवियों में बदलने से स्लाइड साझा करने, प्रदर्शन को अनुकूलित करने और वेब साइट या अनुप्रयोगों में सामग्री एंबेड करने में मदद मिलती है। Aspose.Slides for Android via Java आपको PPTX, PPT और ODP फ़ाइलों को उच्च‑गुणवत्ता वाले JPEG छवियों में बदलने की सुविधा देता है। यह गाइड विभिन्न रूपांतरण विधियों को समझाता है।

इन सुविधाओं के साथ, अपना स्वयं का प्रेजेंटेशन व्यूअर लागू करना और प्रत्येक स्लाइड के लिए थंबनेल बनाना आसान हो जाता है। यह तब उपयोगी हो सकता है जब आप स्लाइड्स को कॉपी करने से बचाना चाहते हैं या केवल‑पढ़ने मोड में प्रस्तुति दिखाना चाहते हैं। Aspose.Slides आपको पूरी प्रस्तुति या किसी विशिष्ट स्लाइड को इमेज फ़ॉर्मेट में बदलने की अनुमति देता है।

## **प्रस्तुति स्लाइड को JPG छवियों में बदलें**

PPT, PPTX या ODP फ़ाइल को JPG में बदलने के चरण इस प्रकार हैं:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।
2. [Presentation.getSlides()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getSlides--) मेथड द्वारा लौटाए गए संग्रह से [ISlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/) प्रकार का स्लाइड ऑब्जेक्ट प्राप्त करें।
3. स्लाइड की छवि बनाने के लिए [ISlide.getImage(float, float)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/#getImage-float-float-) मेथड का उपयोग करें।
4. इमेज ऑब्जेक्ट पर [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) मेथड को कॉल करें। आउटपुट फ़ाइल नाम और इमेज फ़ॉर्मेट को तर्क के रूप में पास करें।

{{% alert color="info" %}} 

**नोट:** PPT, PPTX या ODP से JPG रूपांतरण Aspose.Slides Android via Java API में अन्य फ़ॉर्मेट में रूपांतरण से अलग है। अन्य फ़ॉर्मेट के लिए आमतौर पर आप [IPresentation.save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) मेथड का उपयोग करते हैं। हालांकि, JPG रूपांतरण के लिये आपको [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) मेथड का उपयोग करना आवश्यक है।

{{% /alert %}} 

```java
import com.aspose.slides.*;

int scaleX = 1;
int scaleY = scaleX;

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // निर्दिष्ट स्केल के साथ स्लाइड छवि बनाएं।
        IImage slideImage = slide.getImage(scaleX, scaleY);

        try {
            // JPEG फ़ॉर्मेट में छवि को डिस्क पर सहेजें।
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

## **कस्टमाइज़्ड आकार के साथ स्लाइड को JPG में बदलें**

परिणामस्वरूप JPG छवियों के आकार को बदलने के लिये, आप [ISlide.getImage(Size)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) मेथड में आकार पास करके इमेज साइज सेट कर सकते हैं। इससे आप विशिष्ट चौड़ाई और ऊँचाई मानों के साथ छवियों का उत्पादन कर सकते हैं, जिससे आउटपुट रिज़ॉल्यूशन और एस्पेक्ट रेशियो की आवश्यकताएँ पूरी होती हैं। यह लचीलापन विशेष रूप से वेब अनुप्रयोगों, रिपोर्टों या दस्तावेज़ों के लिये उपयोगी है, जहाँ सटीक इमेज डायमेंशन की आवश्यकता होती है।

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

Size imageSize = new Size(1200, 800);

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // निर्दिष्ट आकार के साथ स्लाइड छवि बनाएं।
        IImage slideImage = slide.getImage(imageSize);

        try {
            // JPEG फ़ॉर्मेट में छवि को डिस्क पर सहेजें।
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

## **छवियों के रूप में स्लाइड सहेजते समय टिप्पणियों को रेंडर करें**

Aspose.Slides for Android via Java एक ऐसी सुविधा प्रदान करता है जो प्रस्तुति की स्लाइडों को JPG छवियों में बदलते समय टिप्पणियों को रेंडर करने की अनुमति देती है। यह कार्यक्षमता PowerPoint प्रस्तुतियों में सहयोगियों द्वारा जोड़नी गई एनोटेशन, फीडबैक या चर्चाओं को संरक्षित रखने में विशेष रूप से उपयोगी है। इस विकल्प को सक्रिय करके आप सुनिश्चित करते हैं कि टिप्पणियां उत्पन्न छवियों में दिखाई दें, जिससे मूल प्रस्तुति फ़ाइल खोले बिना फीडबैक की समीक्षा और साझा करना आसान हो जाता है।

मान लीजिए हमारे पास "sample.pptx" नामक एक प्रस्तुति फ़ाइल है, जिसमें एक स्लाइड पर टिप्पणियां हैं:

![टिप्पणियों के साथ स्लाइड](slide_with_comments.png)

निम्नलिखित Java कोड स्लाइड को टिप्पणियों को संरक्षित रखते हुए JPG छवि में बदलता है:

```java
import com.aspose.slides.*;
import java.awt.Color;

int scaleX = 2;
int scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    NotesCommentsLayoutingOptions commentsOptions = new NotesCommentsLayoutingOptions();
    commentsOptions.setCommentsPosition(CommentsPositions.Right);
    commentsOptions.setCommentsAreaWidth(200);
    commentsOptions.setCommentsAreaColor(new Color(255, 140, 0));

    IRenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(commentsOptions);

    // पहले स्लाइड को छवि में बदलें।
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

## **संबंधित देखें**

PPT, PPTX या ODP को छवियों में बदलने के अन्य विकल्प देखें, जैसे:

- [PowerPoint को GIF में बदलें](/slides/hi/androidjava/convert-powerpoint-to-animated-gif/)
- [PowerPoint को PNG में बदलें](/slides/hi/androidjava/convert-powerpoint-to-png/)
- [PowerPoint को TIFF में बदलें](/slides/hi/androidjava/convert-powerpoint-to-tiff/)
- [PowerPoint को SVG में बदलें](/slides/hi/androidjava/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 

यह देखने के लिये कि Aspose.Slides PowerPoint प्रस्तुतियों को JPG छवियों में कैसे बदलता है, इन निःशुल्क ऑनलाइन कॉनवर्टर्स को आज़माएँ: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/hi/conversion/pptx-to-jpg) और [PPT to JPG](https://products.aspose.app/slides/hi/conversion/ppt-to-jpg)।

{{% /alert %}} 

![नि:शुल्क ऑनलाइन PPTX से JPG रूपांतरणकर्ता](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

Aspose एक [नि:शुल्क Collage वेब ऐप](https://products.aspose.app/slides/hi/collage) प्रदान करता है। इस ऑनलाइन सेवा का उपयोग करके आप [JPG to JPG](https://products.aspose.app/slides/hi/collage/jpg) या PNG to PNG छवियों को मर्ज कर सकते हैं, [फोटो ग्रिड्स](https://products.aspose.app/slides/hi/collage/photo-grid) बना सकते हैं, आदि। 

इस लेख में वर्णित उसी सिद्धांतों का उपयोग करके आप एक फ़ॉर्मेट से दूसरे फ़ॉर्मेट में छवियों को बदल सकते हैं। अधिक जानकारी के लिये इन पृष्ठों को देखें: [image to JPG](https://products.aspose.com/slides/hi/java/conversion/image-to-jpg/) रूपांतरण; [JPG to image](https://products.aspose.com/slides/hi/java/conversion/jpg-to-image/) रूपांतरण; [JPG to PNG](https://products.aspose.com/slides/hi/java/conversion/jpg-to-png/) रूपांतरण, [PNG to JPG](https://products.aspose.com/slides/hi/java/conversion/png-to-jpg/) रूपांतरण; [PNG to SVG](https://products.aspose.com/slides/hi/java/conversion/png-to-svg/) रूपांतरण, [SVG to PNG](https://products.aspose.com/slides/hi/java/conversion/svg-to-png/) रूपांतरण।

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या यह विधि बैच रूपांतरण का समर्थन करती है?

हाँ, Aspose.Slides कई स्लाइड्स को एक ही ऑपरेशन में JPG में बैच रूपांतरण करने की अनुमति देता है।

### क्या रूपांतरण में SmartArt, चार्ट और अन्य जटिल वस्तुएँ समर्थित हैं?

हाँ, Aspose.Slides सभी सामग्री, जिसमें SmartArt, चार्ट, तालिका, आकार आदि शामिल हैं, को रेंडर करता है। हालांकि, रेंडरिंग की सटीकता PowerPoint की तुलना में थोड़ा अलग हो सकती है, विशेष रूप से कस्टम या अनुपलब्ध फ़ॉन्ट्स के उपयोग पर।

### प्रक्रिया की जा सकने वाली स्लाइडों की संख्या पर कोई सीमा है क्या?

Aspose.Slides स्वयं प्रक्रिया की जा सकने वाली स्लाइडों की संख्या पर कोई कड़ी सीमा नहीं लगाता। हालांकि, बड़े प्रस्तुतियों या उच्च‑रिज़ॉल्यूशन छवियों के साथ काम करते समय मेमोरी समाप्ति त्रुटि का सामना हो सकता है।