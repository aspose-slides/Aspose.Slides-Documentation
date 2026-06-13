---
title: Java में PowerPoint स्लाइड को PNG में परिवर्तित करें
linktitle: PowerPoint से PNG
type: docs
weight: 30
url: /hi/java/convert-powerpoint-to-png/
keywords:
- PowerPoint परिवर्तित करें
- प्रस्तुति परिवर्तित करें
- स्लाइड परिवर्तित करें
- PPT परिवर्तित करें
- PPTX परिवर्तित करें
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
description: "Aspose.Slides for Java के साथ PowerPoint प्रस्तुतियों को उच्च गुणवत्ता वाली PNG छवियों में तेज़ी से बदलें, सटीक और स्वचालित परिणाम सुनिश्चित करते हुए."
---
## **सारांश**

यह लेख Aspose.Slides का उपयोग करके PowerPoint प्रस्तुति को PNG छवियों में परिवर्तित करने की प्रक्रिया समझाता है। यह PPT, PPTX और ODP जैसे स्वरूपों में प्रस्तुति फ़ाइलें लोड करने, स्लाइड को छवि के रूप में रेंडर करने, और परिणाम को PNG स्वरूप में सहेजने का प्रदर्शन करता है।

लेख यह भी दर्शाता है कि उत्पन्न PNG छवियों को स्केल मान सेट करके या इच्छित चौड़ाई और ऊँचाई निर्दिष्ट करके कैसे अनुकूलित किया जाए।

## **PowerPoint को PNG में परिवर्तित करें**

इन चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation) क्लास का एक उदाहरण बनाएँ।  
2. [Presentation.getSlides()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/Presentation#getSlides--) संग्रह से [ISlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlide) इंटरफ़ेस के तहत स्लाइड ऑब्जेक्ट प्राप्त करें।  
3. प्रत्येक स्लाइड की थंबनेल प्राप्त करने के लिए [ISlide.getImage()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISlide) मेथड का उपयोग करें।  
4. स्लाइड थंबनेल को PNG स्वरूप में सहेजने के लिए [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) मेथड का उपयोग करें।

यह Java कोड आपको दिखाता है कि PowerPoint प्रस्तुति को PNG में कैसे परिवर्तित किया जाए:

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

## **कस्टम मापों के साथ PowerPoint को PNG में परिवर्तित करें**

यदि आप किसी निश्चित स्केल के आसपास PNG फ़ाइलें प्राप्त करना चाहते हैं, तो आप `desiredX` और `desiredY` मान सेट कर सकते हैं, जो परिणामी थंबनेल के आयाम निर्धारित करते हैं।

Java में यह कोड वर्णित ऑपरेशन को प्रदर्शित करता है:

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

## **कस्टम आकार के साथ PowerPoint को PNG में परिवर्तित करें**

यदि आप किसी निश्चित आकार के आसपास PNG फ़ाइलें प्राप्त करना चाहते हैं, तो आप `ImageSize` के लिए अपना पसंदीदा `width` और `height` आर्ग्युमेंट पास कर सकते हैं।

यह कोड आपको दिखाता है कि छवियों के आकार को निर्दिष्ट करते हुए PowerPoint को PNG में कैसे परिवर्तित किया जाए:

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

**मैं पूरी स्लाइड के बजाय केवल एक विशिष्ट आकार (जैसे चार्ट या चित्र) को कैसे निर्यात कर सकता हूँ?**

Aspose.Slides व्यक्तिगत आकारों के लिए थंबनेल बनाना[व्यक्तिगत आकारों के लिए थंबनेल बनाना](/slides/hi/java/create-shape-thumbnails/) का समर्थन करता है; आप आकार को PNG छवि में रेंडर कर सकते हैं।

**क्या सर्वर पर समानांतर रूपांतरण समर्थित है?**

हाँ, लेकिन [साझा न करें](/slides/hi/java/multithreading/) एकल प्रस्तुति इंस्टेंस को थ्रेड्स के बीच साझा न करें। प्रत्येक थ्रेड या प्रक्रिया के लिए एक अलग इंस्टेंस उपयोग करें।

**PNG में निर्यात करते समय ट्रायल-वर्ज़न की सीमाएँ क्या हैं?**

मूल्यांकन मोड आउटपुट छवियों में वॉटरमार्क जोड़ता है और लाइसेंस लागू होने तक [अन्य प्रतिबंध](/slides/hi/java/licensing/) को लागू करता है।