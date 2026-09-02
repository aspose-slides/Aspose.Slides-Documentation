---
title: "Android पर प्रस्तुति आकारों के थंबनेल बनाएं"
linktitle: "आकार थंबनेल"
type: docs
weight: 70
url: /hi/androidjava/create-shape-thumbnails/
keywords:
- "आकार थंबनेल"
- "आकार छवि"
- "आकार रेंडर"
- "आकार रेंडरिंग"
- "विज़ुअल बाउंड्स"
- "आकार बाउंड्स"
- "PowerPoint"
- "प्रस्तुति"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Android via Java का उपयोग करके PowerPoint स्लाइड्स से उच्च‑गुणवत्ता वाले आकार थंबनेल बनाएँ – आसानी से प्रस्तुति थंबनेल बनाएं और निर्यात करें।"
---
## **परिचय**

Aspose.Slides for Android via Java का उपयोग प्रेजेंटेशन फ़ाइलें बनाने के लिए किया जा सकता है जहाँ प्रत्येक पेज एक स्लाइड के अनुरूप होता है। स्लाइडों को Microsoft PowerPoint के माध्यम से प्रेजेंटेशन फ़ाइलें खोलकर देखा जा सकता है। हालांकि, डेवलपर्स को कभी‑कभी शेप की छवियों को अलग-अलग इमेज व्यूअर में देखना पड़ता है। ऐसे मामलों में, Aspose.Slides for Android via Java स्लाइड शेप की थंबनेल छवियों को उत्पन्न करने में मदद करता है।

इस टॉपिक में, हम विभिन्न स्थितियों में स्लाइड थंबनेल कैसे उत्पन्न करें, यह दिखाएंगे:

- स्लाइड के भीतर एक शेप थंबनेल उत्पन्न करना।
- उपयोगकर्ता‑परिभाषित आयामों के साथ स्लाइड शेप के लिए एक शेप थंबनेल उत्पन्न करना।
- शेप की उपस्थिति की सीमाओं में एक शेप थंबनेल उत्पन्न करना।

## **स्लाइड से शेप थंबनेल उत्पन्न करें**
Aspose.Slides for Android via Java का उपयोग कर किसी भी स्लाइड से शेप थंबनेल उत्पन्न करने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) वर्ग की एक इंस्टेंस बनाएँ।
1. उसके ID या इंडेक्स का उपयोग कर किसी भी स्लाइड का रेफ़रेंस प्राप्त करें।
1. डिफ़ॉल्ट स्केल पर रेफ़रेंस की गई स्लाइड का [shape thumbnail image](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShape#getImage--) प्राप्त करें।
1. थंबनेल छवि को अपनी पसंदीदा इमेज फ़ॉर्मेट में सहेजें।

यह नमूना कोड दर्शाता है कि स्लाइड से शेप थंबनेल कैसे उत्पन्न किया जाए:

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // पूर्ण स्केल छवि बनाएं
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    
    // छवि को PNG फ़ॉर्मेट में डिस्क पर सहेजें
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **उपयोगकर्ता‑परिभाषित स्केलिंग फैक्टर थंबनेल उत्पन्न करें**
Aspose.Slides for Android via Java का उपयोग कर स्लाइड के शेप थंबनेल को उत्पन्न करने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) वर्ग की एक इंस्टेंस बनाएँ।
1. उसके ID या इंडेक्स से किसी भी स्लाइड का रेफ़रेंस प्राप्त करें।
1. उपयोगकर्ता‑परिभाषित आयामों के साथ रेफ़रेंस की गई स्लाइड का [shape thumbnail image](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/IShape#getImage-int-float-float-) प्राप्त करें।
1. थंबनेल छवि को अपनी पसंदीदा इमेज फ़ॉर्मेट में सहेजें।

यह नमूना कोड दिखाता है कि परिभाषित स्केलिंग फैक्टर के आधार पर शेप थंबनेल कैसे उत्पन्न किया जाए:

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // पूर्ण स्केल छवि बनाएं
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Shape, 1, 1);

    // छवि को PNG फ़ॉर्मेट में डिस्क पर सहेजें
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **सीमाओं‑आधारित शेप एपीयरेंस थंबनेल बनाएँ**
शेप के थंबनेल बनाने की यह विधि डेवलपर्स को शेप की एपीयरेंस की सीमाओं में थंबनेल उत्पन्न करने की अनुमति देती है। यह सभी शेप इफ़ेक्ट्स को ध्यान में रखती है। उत्पन्न किया गया शेप थंबनेल स्लाइड की सीमाओं द्वारा प्रतिबंधित रहता है। एपीयरेंस की सीमा में स्लाइड शेप का थंबनेल उत्पन्न करने के लिए नीचे दिए गए चरणों का पालन करें:

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation) वर्ग की एक इंस्टेंस बनाएँ।
1. उसके ID या इंडेक्स से किसी भी स्लाइड का रेफ़रेंस प्राप्त करें।
1. रेफ़रेंस की गई स्लाइड की थंबनेल छवि को शेप बाउंड्स को एपीयरेंस के रूप में लेकर प्राप्त करें।
1. थंबनेल छवि को अपनी पसंदीदा इमेज फ़ॉर्मेट में सहेजें।

यह नमूना कोड ऊपर दिए गए चरणों पर आधारित है:

```java
// प्रस्तुति फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का उदाहरण बनाएं
Presentation pres = new Presentation("Thumbnail.pptx");
try {
    // पूर्ण स्केल छवि बनाएं
    IImage slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(ShapeThumbnailBounds.Appearance, 1, 1);

    // छवि को PNG फ़ॉर्मेट में डिस्क पर सहेजें
    try {
          slideImage.save("output.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **शेप के वास्तविक विज़ुअल बाउंड्स प्राप्त करें**

[IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) की फ्रेम प्रॉपर्टीज़—`getX()`, `getY()`, `getWidth()`, और `getHeight()` मेथड्स—प्रेजेंटेशन मॉडल में संग्रहीत आयत का वर्णन करती हैं। वास्तव में रेंडर की गई सामग्री इस फ्रेम से बाहर तक विस्तारित हो सकती है या विभिन्न अक्ष‑संबंधित आयत में हो सकती है। रोटेशन, आउटलाइन, एरोहेड्स, टेक्स्ट लेआउट और ओवरफ़्लो, जेनरेटेड SmartArt जियोमेट्री, और अन्य रेंडरिंग इफ़ेक्ट्स सभी अधिष्कृत क्षेत्र को बदल सकते हैं।

इमेज बनाए बिना उस अधिष्कृत क्षेत्र की गणना करने के लिए आप [Shape.getVisualBounds](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shape/#getVisualBounds--) का उपयोग कर सकते हैं। यह मेथड स्लाइड कोऑर्डिनेट्स में एक [RectF](https://developer.android.com/reference/android/graphics/RectF) लौटाता है। लौटाया गया आयत स्लाइड तक क्लिप नहीं किया गया है, इसलिए जब सामग्री स्लाइड मूल से बाहर तक विस्तारित होती है तो इसके कोऑर्डिनेट्स नकारात्मक हो सकते हैं।

[Shape.getVisualBounds](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shape/#getVisualBounds--) वर्तमान में [IShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/) इंटरफ़ेस में घोषित नहीं है। इसलिए, स्लाइड के शेप कलेक्शन से प्राप्त शेप को एक इंटरफ़ेस वैल्यू के रूप में रखें और केवल मेथड कॉल करते समय ही इसे कास्ट करें।

निम्न उदाहरण फ्रेम और विज़ुअल बाउंड्स को प्राप्त करता है और तुलना करता है:

```java
Presentation presentation = new Presentation("example.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    RectF visualBounds = ((Shape) shape).getVisualBounds();

    float frameLeft = shape.getX();
    float frameTop = shape.getY();
    float frameRight = frameLeft + shape.getWidth();
    float frameBottom = frameTop + shape.getHeight();
    RectF frameBounds = new RectF(frameLeft, frameTop, frameRight, frameBottom);

    System.out.println("Frame bounds: " + frameBounds);
    System.out.println("Visual bounds: " + visualBounds);
} finally {
    presentation.dispose();
}
```

एक ही [RectF](https://developer.android.com/reference/android/graphics/RectF) का उपयोग निकटवर्ती शेप्स को बाएँ, दाएँ, ऊपर या नीचे किनारे पर संरेखित करने, जेनरेटेड लेआउट में पर्याप्त स्थान आरक्षित करने, या अनुमति क्षेत्र के बाहर की सामग्री का पता लगाने के लिए किया जा सकता है। विज़ुअल बाउंड्स विशेष रूप से SmartArt, टेक्स्ट बॉक्स, एरो, चित्र, घुमाए गए शेप्स, और ग्रुप शेप्स के लिए उपयोगी होते हैं, जहाँ संग्रहीत फ्रेम पूर्ण रेंडर्ड परिणाम को दर्शा नहीं सकता।

लेआउट या वैधता के लिए यदि आपको कोऑर्डिनेट्स चाहिए और बिटमैप की आवश्यकता नहीं है तो [Shape.getVisualBounds](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shape/#getVisualBounds--) का उपयोग करें। यदि आपको शेप को रेंडर करने की आवश्यकता है तो [IShape.getImage](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ishape/#getImage--) का उपयोग करें। [ShapeThumbnailBounds](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shapethumbnailbounds/) के साथ, `ShapeThumbnailBounds.Shape` आउटलाइन सेटिंग्स सहित शेप बाउंड्स से इमेज का आकार तय करता है, जबकि `ShapeThumbnailBounds.Appearance` शेप की एपीयरेंस से आकार लेता है और परिणाम को स्लाइड बाउंड्स तक सीमित करता है। इसके विपरीत, [Shape.getVisualBounds](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shape/#getVisualBounds--) केवल गणना किया गया आयत लौटाता है और इसे स्लाइड तक क्लिप नहीं करता।

## **अक्सर पूछे जाने वाले प्रश्न**

**शेप थंबनेल सहेजते समय कौन‑से इमेज फ़ॉर्मेट उपयोग किए जा सकते हैं?**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imageformat/), आदि। शेप को [वेक्टर SVG के रूप में निर्यात किया जा सकता है](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) भी, जब आप शेप की सामग्री को SVG के रूप में सहेजते हैं।

**थंबनेल रेंडर करते समय Shape और Appearance बाउंड्स में क्या अंतर है?**  
`Shape` शेप की ज्योमेट्री का उपयोग करता है; `Appearance` [विज़ुअल इफ़ेक्ट्स](/slides/hi/androidjava/shape-effect/) (छाया, चमक आदि) को ध्यान में रखता है।

**यदि किसी शेप को हटाए (hidden) के रूप में चिह्नित किया गया हो तो क्या होता है? क्या यह अभी भी थंबनेल के रूप में रेंडर होगा?**  
हिडन (छिपा) शेप मॉडल का हिस्सा बना रहता है और इसे रेंडर किया जा सकता है; हिडन फ़्लैग स्लाइडशो प्रदर्शन को प्रभावित करता है, लेकिन शेप की इमेज जनरेट करने से नहीं रोकता।

**क्या ग्रुप शेप्स, चार्ट्स, SmartArt, और अन्य जटिल ऑब्जेक्ट्स समर्थित हैं?**  
हां। कोई भी ऑब्जेक्ट जो [Shape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/shape/) के रूप में प्रतिनिधित्व करता है (जिसमें [GroupShape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/chart/), और [SmartArt](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/smartart/) शामिल हैं) थंबनेल या SVG के रूप में सहेजा जा सकता है।

**क्या सिस्टम‑इंस्टॉल्ड फ़ॉन्ट्स टेक्स्ट शेप्स के थंबनेल की गुणवत्ता को प्रभावित करते हैं?**  
हां। आपको [आवश्यक फ़ॉन्ट्स प्रदान करने चाहिए](/slides/hi/androidjava/custom-font/) (या [फ़ॉन्ट सब्स्टिट्यूशन कॉन्फ़िगर करें](/slides/hi/androidjava/font-substitution/)) ताकि अनिच्छित फ़ॉलबैक और टेक्स्ट रीफ़्लो से बचा जा सके।