---
title: जावा में प्रेज़ेंटेशन आकारों के थंबनेल बनाएं
linktitle: आकार थंबनेल
type: docs
weight: 70
url: /hi/java/create-shape-thumbnails/
keywords:
- आकार थंबनेल
- आकार छवि
- आकार रेंडर
- आकार रेंडरिंग
- PowerPoint
- प्रस्तुति
- Java
- Aspose.Slides
description: Aspose.Slides for Java के साथ PowerPoint स्लाइडों से उच्च‑गुणवत्ता वाले आकार थंबनेल उत्पन्न करें – आसानी से प्रस्तुति थंबनेल बनाएं और निर्यात करें।
---
## **परिचय**

Aspose.Slides for Java का उपयोग प्रस्तुति फाइलें बनाने के लिए किया जा सकता है जहाँ प्रत्येक पृष्ठ एक स्लाइड के अनुरूप होता है। स्लाइड्स को Microsoft PowerPoint से प्रस्तुति फाइलें खोलकर देखा जा सकता है। हालांकि, डेवलपर्स को कभी‑कभी आकारों की छवियों को अलग से एक इमेज व्यूअर में देखना पड़ता है। ऐसे मामलों में, Aspose.Slides for Java स्लाइड आकारों की थंबनेल छवियों को उत्पन्न करने में सहायता करता है।

यह लेख विभिन्न तरीकों से स्लाइड थंबनेल उत्पन्न करने के बारे में बताता है:

- स्लाइड के अंदर एक आकार थंबनेल उत्पन्न करना।
- उपयोगकर्ता‑परिभाषित आयामों के साथ स्लाइड आकार के लिए आकार थंबनेल उत्पन्न करना।
- आकार की उपस्थिति की सीमा में आकार थंबनेल उत्पन्न करना।

## **स्लाइड से आकार थंबनेल उत्पन्न करें**
Aspose.Slides for Java का उपयोग करके किसी भी स्लाइड से आकार थंबनेल उत्पन्न करने के लिए, यह करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
2. किसी भी स्लाइड का संदर्भ उसके ID या इंडेक्स का उपयोग करके प्राप्त करें।
3. [Get the shape thumbnail image](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShape#getImage--) को संदर्भित स्लाइड की डिफ़ॉल्ट स्केल पर प्राप्त करें।
4. अपनी पसंदीदा इमेज फ़ॉर्मेट में थंबनेल छवि सहेजें।

यह नमूना कोड दर्शाता है कि स्लाइड से आकार थंबनेल कैसे उत्पन्न करें:

```java
// प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // पूर्ण स्केल की छवि बनाएं
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

## **उपयोगकर्ता‑परिभाषित स्केलिंग फ़ैक्टर थंबनेल उत्पन्न करें**
Aspose.Slides for Java का उपयोग करके स्लाइड के आकार थंबनेल को उत्पन्न करने के लिए, यह करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
2. किसी भी स्लाइड का संदर्भ उसके ID या इंडेक्स का उपयोग करके प्राप्त करें।
3. [Get the shape thumbnail image](https://reference.aspose.com/slides/hi/java/com.aspose.slides/IShape#getImage-int-float-float-) को संदर्भित स्लाइड पर उपयोगकर्ता‑परिभाषित आयामों के साथ प्राप्त करें।
4. अपनी पसंदीदा इमेज फ़ॉर्मेट में थंबनेल छवि सहेजें।

यह नमूना कोड दिखाता है कि निर्धारित स्केलिंग फ़ैक्टर के आधार पर आकार थंबनेल कैसे उत्पन्न करें:

```java
// प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // पूर्ण स्केल की छवि बनाएं
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

## **बाउंड्स‑आधारित आकार उपस्थिति थंबनेल बनाएं**
आकारों के थंबनेल बनाने की यह विधि डेवलपर्स को आकार की उपस्थिति की सीमा में थंबनेल उत्पन्न करने की अनुमति देती है। यह सभी आकार प्रभावों को ध्यान में रखती है। उत्पन्न आकार थंबनेल स्लाइड की सीमाओं द्वारा प्रतिबंधित होता है। आकार की उपस्थिति की सीमा में स्लाइड आकार का थंबनेल उत्पन्न करने के लिए, यह करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएं।
2. किसी भी स्लाइड का संदर्भ उसके ID या इंडेक्स का उपयोग करके प्राप्त करें।
3. संदर्भित स्लाइड की थंबनेल छवि प्राप्त करें जहाँ आकार की सीमाएँ उपस्थिति के रूप में हों।
4. अपनी पसंदीदा इमेज फ़ॉर्मेट में थंबनेल छवि सहेजें।

यह नमूना कोड ऊपर दिए गए चरणों पर आधारित है:

```java
// प्रेज़ेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास को इंस्टैंसिएट करें
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // पूर्ण स्केल की छवि बनाएं
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

## **FAQ**

**आकार थंबनेल सहेजते समय कौन से इमेज फ़ॉर्मेट उपयोग किए जा सकते हैं?**

[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imageformat/), और अन्य। आकारों को [वेक्तर SVG के रूप में निर्यात](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) करके आकार की सामग्री को SVG के रूप में सहेजा जा सकता है।

**थंबनेल रेंडर करने पर Shape और Appearance बाउंड्स में क्या अंतर है?**

`Shape` आकार की ज्यामिति का उपयोग करता है; `Appearance` [visual effects](/slides/hi/java/shape-effect/) (छायाएं, चमक, आदि) को ध्यान में रखता है।

**यदि किसी आकार को छिपा हुआ चिह्नित किया गया है तो क्या होता है? क्या यह अब भी थंबनेल के रूप में रेंडर होगा?**

एक छिपा हुआ आकार मॉडल का हिस्सा बना रहता है और रेंडर किया जा सकता है; छिपा हुआ फ़्लैग स्लाइड शो प्रदर्शन को प्रभावित करता है लेकिन आकार की छवि उत्पन्न करने से नहीं रोकता।

**क्या समूह आकार, चार्ट, SmartArt, और अन्य जटिल ऑब्जेक्ट समर्थित हैं?**

हां। कोई भी ऑब्जेक्ट जो [Shape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/) के रूप में दर्शाया गया है (जिसमें [GroupShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chart/), और [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/smartart/) शामिल हैं) को थंबनेल या SVG के रूप में सहेजा जा सकता है।

**क्या सिस्टम‑स्थापित फ़ॉन्ट्स टेक्स्ट आकारों के थंबनेल की गुणवत्ता को प्रभावित करते हैं?**

हां। आपको [आवश्यक फ़ॉन्ट्स प्रदान](/slides/hi/java/custom-font/) (या [फ़ॉन्ट प्रतिस्थापन कॉन्फ़़िगर](/slides/hi/java/font-substitution/)) करने चाहिए ताकि अनपेक्षित फ़ॉलबैक और टेक्स्ट रीफ़्लो से बचा जा सके।