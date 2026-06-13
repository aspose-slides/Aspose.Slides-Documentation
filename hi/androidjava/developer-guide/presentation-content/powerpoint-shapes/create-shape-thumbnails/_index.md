---
title: Android पर प्रस्तुति आकृतियों के थंबनेल बनाएं
linktitle: आकृति थंबनेल
type: docs
weight: 70
url: /hi/androidjava/create-shape-thumbnails/
keywords:
- आकृति थंबनेल
- आकृति छवि
- आकृति रेंडर
- आकृति रेंडरिंग
- PowerPoint
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java का उपयोग करके PowerPoint स्लाइड्स से उच्च-गुणवत्ता वाले आकृति थंबनेल उत्पन्न करें – आसानी से प्रस्तुति थंबनेल बनाएं और निर्यात करें।"
---
## **परिचय**

Aspose.Slides for Android via Java का उपयोग करके प्रस्तुति फ़ाइलें बनाई जा सकती हैं जहाँ प्रत्येक पृष्ठ एक स्लाइड के अनुरूप होता है। स्लाइड्स को Microsoft PowerPoint के माध्यम से प्रस्तुति फ़ाइलें खोलकर देखा जा सकता है। हालांकि, डेवलपर्स को कभी‑कभी आकृतियों की छवियों को अलग से किसी इमेज व्यूअर में देखना पड़ता है। ऐसे मामलों में Aspose.Slides for Android via Java स्लाइड आकृतियों की थंबनेल छवियां उत्पन्न करने में मदद करता है।

इस विषय में, हम विभिन्न स्थितियों में स्लाइड थंबनेल बनाने का तरीका दिखाएंगे:

- स्लाइड के भीतर आकृति थंबनेल बनाना।
- उपयोगकर्ता‑परिभाषित आयामों के साथ स्लाइड आकृति के लिए आकृति थंबनेल बनाना।
- आकृति की उपस्थिति की सीमाओं में आकृति थंबनेल बनाना।

## **स्लाइड से आकृति थंबनेल बनाएं**
Aspose.Slides for Android via Java का उपयोग करके किसी भी स्लाइड से आकृति थंबनेल बनाने के लिए, निम्न करें:

1. एक [प्रेजेंटेशन](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
2. उसके ID या इंडेक्स का उपयोग करके किसी भी स्लाइड का रेफ़रेंस प्राप्त करें।
3. डिफ़ॉल्ट स्केल पर रेफ़रेंस्ड स्लाइड की आकृति थंबनेल छवि [प्राप्त करें](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShape#getImage--)।
4. अपने पसंदीदा इमेज फ़ॉर्मेट में थंबनेल छवि को सहेजें।

यह सैंपल कोड दिखाता है कि स्लाइड से आकृति थंबनेल कैसे उत्पन्न किया जाए:

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंटिएट करें
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // पूर्ण स्केल इमेज बनाएं
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // इमेज को PNG फ़ॉर्मेट में डिस्क पर सहेजें
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **उपयोगकर्ता‑परिभाषित स्केलिंग फ़ैक्टर थंबनेल बनाएं**
Aspose.Slides for Android via Java का उपयोग करके स्लाइड की आकृति थंबनेल बनाने के लिए, निम्न करें:

1. एक [प्रेजेंटेशन](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
2. उसके ID या इंडेक्स का उपयोग करके किसी भी स्लाइड का रेफ़रेंस प्राप्त करें।
3. उपयोगकर्ता‑परिभाषित आयामों के साथ रेफ़रेंस्ड स्लाइड की आकृति थंबनेल छवि [प्राप्त करें](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShape#getImage-int-float-float-)।
4. अपने पसंदीदा इमेज फ़ॉर्मेट में थंबनेल छवि को सहेजें।

यह सैंपल कोड दिखाता है कि परिभाषित स्केलिंग फ़ैक्टर के आधार पर आकृति थंबनेल कैसे उत्पन्न किया जाए:

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंटिएट करें
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // पूर्ण स्केल इमेज बनाएं
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // इमेज को PNG फ़ॉर्मेट में डिस्क पर सहेजें
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **सीमा‑आधारित आकृति उपस्थिति थंबनेल बनाएं**
यह विधि डेवलपर्स को आकृति की उपस्थिति की सीमाओं के भीतर थंबनेल उत्पन्न करने की सुविधा देती है। यह सभी आकृति इफ़ेक्ट्स को ध्यान में रखती है। उत्पन्न आकृति थंबनेल स्लाइड की सीमाओं द्वारा प्रतिबंधित होता है। आकृति की उपस्थिति की सीमा में स्लाइड आकृति का थंबनेल बनाने के लिए, निम्न करें:

1. एक [प्रेजेंटेशन](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
2. उसके ID या इंडेक्स का उपयोग करके किसी भी स्लाइड का रेफ़रेंस प्राप्त करें।
3. आकृति की सीमाओं को उपस्थिति के रूप में उपयोग करके रेफ़रेंस्ड स्लाइड की थंबनेल छवि प्राप्त करें।
4. अपने पसंदीदा इमेज फ़ॉर्मेट में थंबनेल छवि को सहेजें।

यह सैंपल कोड उपरोक्त चरणों पर आधारित है:

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंटिएट करें
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // पूर्ण स्केल इमेज बनाएं
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // इमेज को PNG फ़ॉर्मेट में डिस्क पर सहेजें
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**शेप थंबनेल सहेजते समय कौन‑से इमेज फ़ॉर्मेट उपयोग किए जा सकते हैं?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imageformat/), और अन्य। आकृतियों को SVG वेक्टर के रूप में भी [एक्सपोर्ट किया जा सकता है](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) SVG के रूप में आकृति की सामग्री सहेजकर।

**थंबनेल रेंडर करते समय Shape और Appearance बाउंड्स में क्या अंतर है?**

`Shape` आकृति की ज्यामिति का उपयोग करता है; `Appearance` [विज़ुअल इफ़ेक्ट्स](/slides/hi/androidjava/shape-effect/) (छायाएँ, चमक आदि) को ध्यान में रखता है।

**यदि किसी आकृति को छिपा (hidden) चिह्नित किया गया है तो क्या होगा? क्या वह अभी भी थंबनेल के रूप में रेंडर होगी?**

एक छिपी हुई आकृति मॉडल का हिस्सा बनी रहती है और रेंडर की जा सकती है; छिपा फ़्लैग स्लाइड शो प्रदर्शन को प्रभावित करता है लेकिन आकृति की छवि उत्पन्न करने से नहीं रोकता।

**क्या समूह आकृतियां (GroupShape), चार्ट, SmartArt, और अन्य जटिल ऑब्जेक्ट समर्थित हैं?**

हाँ। कोई भी वस्तु जो [Shape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shape/) (समेत [GroupShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chart/), और [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/smartart/)) के रूप में प्रतिनिधित्व करती है, थंबनेल या SVG के रूप में सहेजी जा सकती है।

**क्या सिस्टम पर इंस्टॉल किए गए फ़ॉन्ट्स टेक्स्ट आकृतियों के थंबनेल की गुणवत्ता को प्रभावित करते हैं?**

हाँ। आपको आवश्यक फ़ॉन्ट्स [प्रदान करने चाहिए](/slides/hi/androidjava/custom-font/) (या [फ़ॉन्ट सब्स्टीट्यूशन कॉन्फ़िगर करें](/slides/hi/androidjava/font-substitution/)) ताकि अनचाहे फ़ॉलबैक्स और टेक्स्ट रीफ़्लो से बचा जा सके।