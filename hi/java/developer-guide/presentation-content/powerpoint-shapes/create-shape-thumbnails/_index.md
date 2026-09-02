---
title: Java में प्रेजेंटेशन आकारों की थंबनेल बनाएं
linktitle: आकार थंबनेल
type: docs
weight: 70
url: /hi/java/create-shape-thumbnails/
keywords:
- आकार थंबनेल
- आकार छवि
- आकार रेंडर
- आकार रेंडरिंग
- विज़ुअल बाउंड्स
- आकार बाउंड्स
- PowerPoint
- प्रेजेंटेशन
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint स्लाइड्स से उच्च-गुणवत्ता वाले आकार थंबनेल जनरेट करें – प्रेजेंटेशन थंबनेल को आसानी से बनाएं और निर्यात करें।"
---
## **परिचय**

Aspose.Slides for Java का उपयोग ऐसी प्रेजेंटेशन फ़ाइलें बनाने के लिए किया जा सकता है जिनमें प्रत्येक पृष्ठ एक स्लाइड के अनुरूप होता है। स्लाइड को Microsoft PowerPoint का उपयोग करके प्रेजेंटेशन फ़ाइलें खोलकर देखा जा सकता है। हालांकि, डेवलपर्स को कभी‑कभी आकारों की छवियों को अलग से इमेज व्यूअर में देखना पड़ता है। ऐसे मामलों में, Aspose.Slides for Java स्लाइड आकारों की थंबनेल छवियां बनाने में मदद करता है।

यह लेख विभिन्न तरीकों से स्लाइड थंबनेल बनाने के तरीकों को समझाता है:

- स्लाइड के भीतर आकार थंबनेल जेनरेट करना।  
- उपयोगकर्ता‑परिभाषित आयामों के साथ स्लाइड आकार के लिए आकार थंबनेल जेनरेट करना।  
- आकार की उपस्थिति की सीमाओं में आकार थंबनेल जेनरेट करना।  

## **स्लाइड से आकार थंबनेल जेनरेट करें**
Aspose.Slides for Java का उपयोग करके किसी भी स्लाइड से आकार थंबनेल बनाने के लिए, निम्नलिखित करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।  
1. उस स्लाइड का संदर्भ प्राप्त करें, चाहे वह ID हो या इंडेक्स।  
1. डिफ़ॉल्ट स्केल पर संदर्भित स्लाइड की [आकार थंबनेल छवि प्राप्त करें](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getImage--)।  
1. थंबनेल छवि को अपनी पसंदीदा इमेज फ़ॉर्मेट में सहेजें।

यह नमूना कोड दिखाता है कि स्लाइड से आकार थंबनेल कैसे जेनरेट किया जाता है:

```java
// एक Presentation क्लास का उदाहरण बनाएं जो प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // पूर्ण स्केल इमेज बनाएं
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // इमेज को डिस्क पर PNG फ़ॉर्मेट में सहेजें
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
Aspose.Slides for Java का उपयोग करके स्लाइड के आकार थंबनेल को बनाने के लिए, निम्नलिखित करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।  
1. उस स्लाइड का संदर्भ प्राप्त करें, चाहे वह ID हो या इंडेक्स।  
1. उपयोगकर्ता‑परिभाषित आयामों के साथ आकार थंबनेल छवि प्राप्त करें[https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getImage-int-float-float-] (link को सही रखें, यह एक टेम्पलेट है)।  
1. थंबनेल छवि को अपनी पसंदीदा इमेज फ़ॉर्मेट में सहेजें।

यह नमूना कोड दिखाता है कि परिभाषित स्केलिंग फ़ैक्टर के आधार पर आकार थंबनेल कैसे जेनरेट किया जाता है:

```java
// प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // पूर्ण स्केल इमेज बनाएं
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // इमेज को डिस्क पर PNG फ़ॉर्मेट में सहेजें
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **बाउंड‑आधारित आकार उपस्थिति थंबनेल बनाएं**
यह विधि डेवलपर्स को आकार की उपस्थिति की सीमाओं (bounds) में थंबनेल जेनरेट करने की अनुमति देती है। यह सभी आकार प्रभावों को ध्यान में रखती है। जेनरेट किया गया आकार थंबनेल स्लाइड बाउंड्स द्वारा सीमित होता है। आकार की उपस्थिति की सीमा में स्लाइड आकार का थंबनेल जेनरेट करने के लिए, निम्नलिखित करें:

1. [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का एक उदाहरण बनाएं।  
1. उस स्लाइड का संदर्भ प्राप्त करें, चाहे वह ID हो या इंडेक्स।  
1. आकार बाउंड्स को उपस्थिति के रूप में लेकर संदर्भित स्लाइड की थंबनेल छवि प्राप्त करें।  
1. थंबनेल छवि को अपनी पसंदीदा इमेज फ़ॉर्मेट में सहेजें।

यह नमूना कोड उपरोक्त चरणों पर आधारित है:

```java
// प्रेजेंटेशन फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // पूर्ण स्केल इमेज बनाएं
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // इमेज को डिस्क पर PNG फ़ॉर्मेट में सहेजें
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **आकार की वास्तविक विज़ुअल बाउंड्स प्राप्त करें**

[IShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/) की फ्रेम प्रॉपर्टीज़—इनकी `getX()`, `getY()`, `getWidth()`, और `getHeight()` मेथड्स—प्रेजेंटेशन मॉडल में संग्रहित आयत को दर्शाती हैं। वास्तविक रूप से रेंडर की गई सामग्री उस फ्रेम से बाहर तक विस्तारित हो सकती है या अलग अक्ष‑समीकरण आयत को घेर सकती है। रोटेशन, आउटलाइन, एरोहेड, टेक्स्ट लेआउट और ओवेरफ़्लो, जेनरेटेड SmartArt ज्योमेट्री, और अन्य रेंडरिंग इफेक्ट्स सभी घेरित क्षेत्र को बदल सकते हैं।

इमेज नहीं बनाते हुए उस घेरित क्षेत्र की गणना के लिए [Shape.getVisualBounds](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/#getVisualBounds--) का उपयोग करें। यह मेथड स्लाइड निर्देशांकों में एक [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) लौटाता है। लौटाया गया आयत स्लाइड तक क्लिप नहीं किया गया है, इसलिए जब सामग्री स्लाइड मूल बिंदु से परे विस्तारित होती है तो इसके निर्देशांक नकारात्मक हो सकते हैं।

[Shape.getVisualBounds](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/#getVisualBounds--) वर्तमान में [IShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/) इंटरफ़ेस द्वारा घोषित नहीं है। इसलिए, स्लाइड के shape collection से प्राप्त shape को इंटरफ़ेस वैल्यू के रूप में रखें और केवल मेथड कॉल करते समय ही इसे कास्ट करें।

निम्नलिखित उदाहरण फ्रेम और विज़ुअल बाउंड्स को प्राप्त करता है और उनकी तुलना करता है:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    Rectangle2D.Float visualBounds = ((Shape) shape).getVisualBounds();

    Rectangle2D.Float frameBounds = new Rectangle2D.Float(
        shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight());

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

उसी [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) का उपयोग निकटस्थ आकारों को बाएँ, दाएँ, ऊपर या नीचे किनारे पर संरेखित करने, जनरेटेड लेआउट में पर्याप्त स्थान आरक्षित करने, या अनुमत क्षेत्र के बाहर की सामग्री का पता लगाने के लिए किया जा सकता है। विज़ुअल बाउंड्स विशेष रूप से SmartArt, टेक्स्ट बॉक्स, एरो, चित्र, घुमाए गए आकार, और समूह आकारों के लिए उपयोगी होते हैं, जहाँ संग्रहित फ्रेम पूर्ण रेंडर किए गए परिणाम को नहीं दर्शा सकता।

जब आपको लेआउट या वैलीडेशन के लिए निर्देशांक की आवश्यकता हो और बिटमैप नहीं चाहिए, तो [Shape.getVisualBounds](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/#getVisualBounds--) का उपयोग करें। जब आपको आकार को रेंडर करना हो, तो [IShape.getImage](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ishape/#getImage--) का उपयोग करें। [ShapeThumbnailBounds](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shapethumbnailbounds/) के साथ, `ShapeThumbnailBounds.Shape` आकार बाउंड्स से सहित आउटलाइन सेटिंग्स के साथ इमेज आकार देता है, जबकि `ShapeThumbnailBounds.Appearance` आकार की उपस्थिति से आकार देता है और परिणाम को स्लाइड बाउंड्स तक सीमित करता है। इसके विपरीत, [Shape.getVisualBounds](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/#getVisualBounds--) केवल गणनित आयत लौटाता है और इसे स्लाइड तक क्लिप नहीं करता।

## **अक्सर पूछे जाने वाले प्रश्न**

**आकार थंबनेल सहेजते समय कौन से इमेज फ़ॉर्मेट उपयोग किए जा सकते हैं?**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imageformat/), और अन्य। आकारों को [वेक्टर SVG के रूप में एक्सपोर्ट भी किया जा सकता है](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) SVG के रूप में आकार की सामग्री सहेजकर।

**थंबनेल रेंडर करते समय Shape और Appearance बाउंड्स में क्या अंतर है?**  
`Shape` आकार की ज्योमेट्री का उपयोग करता है; `Appearance` [विज़ुअल इफ़ेक्ट्स](/slides/hi/java/shape-effect/) (छाया, चमक आदि) को ध्यान में रखता है।

**यदि कोई आकार hidden के रूप में चिह्नित हो तो क्या होगा? क्या वह अभी भी थंबनेल के रूप में रेंडर होगा?**  
एक hidden आकार मॉडल का हिस्सा बना रहता है और रेंडर किया जा सकता है; hidden फ़्लैग स्लाइडशो प्रदर्शन को प्रभावित करता है लेकिन आकार की इमेज जेनरेट होने से नहीं रोकता।

**क्या समूह आकार, चार्ट, SmartArt, और अन्य जटिल ऑब्जेक्ट्स समर्थित हैं?**  
हां। कोई भी ऑब्जेक्ट जो [Shape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/shape/) के रूप में दर्शाया गया है (जिसमें [GroupShape](https://reference.aspose.com/slides/hi/java/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/hi/java/com.aspose.slides/chart/), और [SmartArt](https://reference.aspose.com/slides/hi/java/com.aspose.slides/smartart/) शामिल हैं) को थंबनेल या SVG के रूप में सहेजा जा सकता है।

**क्या सिस्टम‑इंस्टॉल किए गए फ़ॉन्ट्स टेक्स्ट आकारों के थंबनेल की गुणवत्ता को प्रभावित करते हैं?**  
हां। आपको आवश्यक फ़ॉन्ट्स प्रदान करने चाहिए[/slides/hi/java/custom-font/] (या फ़ॉन्ट प्रतिस्थापन कॉन्फ़िगर करना[/slides/hi/java/font-substitution/]) ताकि अनचाहे fallback और टेक्स्ट रीफ़्लो से बचा जा सके।