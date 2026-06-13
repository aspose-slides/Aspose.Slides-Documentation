---
title: Android पर PowerPoint स्लाइड्स को PNG में बदलें
linktitle: PowerPoint से PNG
type: docs
weight: 30
url: /hi/androidjava/convert-powerpoint-to-png/
keywords:
- PowerPoint को बदलें
- प्रस्तुतीकरण को बदलें
- स्लाइड को बदलें
- PPT को बदलें
- PPTX को बदलें
- PowerPoint से PNG
- प्रस्तुतीकरण से PNG
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
description: "Aspose.Slides for Android द्वारा Java के माध्यम से PowerPoint प्रस्तुतियों को तेज़ी से उच्च-गुणवत्ता वाले PNG छवियों में बदलें, सटीक और स्वचालित परिणाम सुनिश्चित करते हुए।"
---
## **अवलोकन**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुतीकरण को PNG छवियों में बदलने के तरीके को समझाता है। यह दिखाता है कि PPT, PPTX और ODP जैसे स्वरूपों में प्रस्तुतीकरण फ़ाइलों को कैसे लोड किया जाए, स्लाइडों को छवियों के रूप में रेंडर किया जाए, और परिणामों को PNG स्वरूप में कैसे सहेजा जाए।

लेख यह भी दर्शाता है कि उत्पन्न PNG छवियों को स्केल मान सेट करके या वांछित चौड़ाई और ऊँचाई निर्दिष्ट करके कैसे अनुकूलित किया जा सकता है।

## **PowerPoint को PNG में बदलें**

Go through these steps:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएँ।
2. [Presentation.getSlides()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/Presentation#getSlides--) संग्रह से स्लाइड ऑब्जेक्ट प्राप्त करें, जो [ISlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlide) इंटरफ़ेस के अंतर्गत है।
3. प्रत्येक स्लाइड के थंबनेल को प्राप्त करने के लिए [ISlide.getImage()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISlide) मेथड का उपयोग करें।
4. स्लाइड थंबनेल को PNG स्वरूप में सहेजने के लिए [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IImage#save(String formatName, int imageFormat)) मेथड का उपयोग करें।

यह Java कोड दिखाता है कि PowerPoint प्रस्तुतीकरण को PNG में कैसे बदलें:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage();
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **कस्टम आयामों के साथ PowerPoint को PNG में बदलें**

यदि आप किसी विशिष्ट स्केल के आधार पर PNG फ़ाइलें प्राप्त करना चाहते हैं, तो आप `desiredX` और `desiredY` मान सेट कर सकते हैं, जो उत्पन्न थंबनेल के आयाम निर्धारित करते हैं। 

यह कोड Java में वर्णित ऑपरेशन को प्रदर्शित करता है:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    float scaleX = 2f;
    float scaleY = 2f;
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(scaleX, scaleY);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **कस्टम आकार के साथ PowerPoint को PNG में बदलें**

यदि आप किसी विशिष्ट आकार की PNG फ़ाइलें प्राप्त करना चाहते हैं, तो आप `ImageSize` के लिए अपनी इच्छित `width` और `height` तर्क पास कर सकते हैं। 

यह कोड दिखाता है कि PowerPoint को PNG में बदलते समय छवियों के आकार को कैसे निर्दिष्ट किया जाए: 

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Dimension size = new Dimension(960, 720);
    for (int index = 0; index < pres.getSlides().size(); index++)
    {
        ISlide slide = pres.getSlides().get_Item(index);
        IImage slideImage = slide.getImage(size);
        try {
              slideImage.save("image_java_" + index + ".png", ImageFormat.Png);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं पूरे स्लाइड की बजाय केवल एक विशिष्ट आकार (जैसे चार्ट या चित्र) को कैसे निर्यात कर सकता हूँ?**

Aspose.Slides [व्यक्तिगत आकारों के लिए थंबनेल बनाने](/slides/hi/androidjava/create-shape-thumbnails/) का समर्थन करता है; आप किसी आकार को PNG छवि में रेंडर कर सकते हैं।

**क्या सर्वर पर समानांतर रूपांतरण समर्थित है?**

हाँ, लेकिन एक ही प्रस्तुतीकरण इंस्टेंस को थ्रेड्स के बीच [साझा न करें](/slides/hi/androidjava/multithreading/); प्रत्येक थ्रेड या प्रक्रिया के लिए अलग इंस्टेंस उपयोग करें।

**PNG निर्यात करते समय परीक्षण संस्करण की सीमाएँ क्या हैं?**

मूल्यांकन मोड आउटपुट छवियों पर वॉटरमार्क जोड़ता है और लाइसेंस लागू होने तक [अन्य प्रतिबंध](/slides/hi/androidjava/licensing/) लागू करता है।