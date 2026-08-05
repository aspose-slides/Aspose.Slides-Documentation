---
title: जावास्क्रिप्ट में प्रस्तुति शैप्स के थंबनेल बनाएं
linktitle: शैप थंबनेल
type: docs
weight: 70
url: /hi/nodejs-java/create-shape-thumbnails/
keywords:
- शैप थंबनेल
- शैप इमेज
- शैप रेंडर करें
- शैप रेंडरिंग
- विज़ुअल बाउंड्स
- शैप बाउंड्स
- PowerPoint
- प्रेजेंटेशन
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "PowerPoint स्लाइड्स से जावास्क्रिप्ट और Aspose.Slides for Node.js का उपयोग करके उच्च गुणवत्ता वाले शैप थंबनेल उत्पन्न करें – आसानी से प्रस्तुति थंबनेल बनाएं और निर्यात करें।"
---
## **परिचय**

Aspose.Slides का उपयोग प्रस्तुति फ़ाइलें बनाने के लिए किया जाता है जहाँ प्रत्येक पृष्ठ एक स्लाइड होता है। इन स्लाइडों को Microsoft PowerPoint द्वारा खोलकर देखा जा सकता है। कभी‑कभी डेवलपर्स को शैप की छवियों को अलग‑अलग इमेज व्यूअर में देखना पड़ता है। ऐसे मामलों में Aspose.Slides आपको स्लाइड शैप के थंबनेल इमेज जनरेट करने में मदद करता है। इस सुविधा का प्रयोग कैसे करें, यह इस लेख में बताया गया है।  
यह लेख विभिन्न तरीकों से स्लाइड थंबनेल जनरेट करने के बारे में बताता है:

- स्लाइड के भीतर शैप थंबनेल बनाना।  
- उपयोगकर्ता द्वारा निर्दिष्ट आयामों के साथ स्लाइड शैप के लिए थंबनेल बनाना।  
- शैप के Appearance की सीमा के भीतर थंबनेल बनाना।

## **स्लाइड्स से शैप थंबनेल बनाना**
Aspose.Slides for Node.js via Java का उपयोग कर किसी भी स्लाइड से शैप थंबनेल जनरेट करने के लिए निम्न चरण अपनाएँ:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।  
1. स्लाइड के ID या इंडेक्स द्वारा उसका रेफ़रेंस प्राप्त करें।  
1. रेफ़रेंस्ड स्लाइड की डिफ़ॉल्ट स्केल पर [शेप थंबनेल इमेज प्राप्त करें](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Shape#getImage--)।  
1. थंबनेल इमेज को अपनी पसंदीदा इमेज फ़ॉर्मेट में सहेजें।

यह नमूना कोड दिखाता है कि स्लाइड से शैप थंबनेल कैसे जनरेट किया जाता है:

```javascript
// प्रस्तुति फ़ाइल को दर्शाने वाली Presentation क्लास का इंस्टेंस बनाएं
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // पूर्ण स्केल इमेज बनाएं
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage();
    // इमेज को PNG फ़ॉर्मेट में डिस्क पर सहेजें
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **उपयोगकर्ता‑परिभाषित स्केलिंग फ़ैक्टर के साथ शैप थंबनेल बनाना**
Aspose.Slides for Node.js via Java का उपयोग कर स्लाइड शैप का थंबनेल जनरेट करने के लिए निम्न चरण अपनाएँ:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।  
1. स्लाइड के ID या इंडेक्स द्वारा उसका रेफ़रेंस प्राप्त करें।  
1. रेफ़रेंस्ड स्लाइड की उपयोगकर्ता‑परिभाषित आयामों के साथ [शेप थंबनेल इमेज प्राप्त करें](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Shape#getImage-int-float-float-)।  
1. थंबनेल इमेज को अपनी पसंदीदा इमेज फ़ॉर्मेट में सहेजें।

यह नमूना कोड दिखाता है कि परिभाषित स्केलिंग फ़ैक्टर के आधार पर शैप थंबनेल कैसे जनरेट किया जाता है:

```javascript
// प्रस्तुति फ़ाइल को दर्शाने वाली Presentation क्लास का इंस्टेंस बनाएं
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // पूर्ण स्केल इमेज बनाएं
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Shape, 1, 1);
    // इमेज को PNG फ़ॉर्मेट में डिस्क पर सहेजें
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **बाउंड्स के शैप थंबनेल बनाना**
शैप की Appearance की सीमा के भीतर थंबनेल बनाना डेवलपर्स को सभी शैप इफ़ेक्ट्स को ध्यान में रखते हुए थंबनेल जनरेट करने की सुविधा देता है। उत्पन्न शैप थंबनेल स्लाइड की सीमा द्वारा प्रतिबंधित रहता है। Appearance की सीमा में स्लाइड शैप का थंबनेल जनरेट करने के लिए निम्न चरण अपनाएँ:

1. [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation) क्लास का एक इंस्टेंस बनाएँ।  
1. स्लाइड के ID या इंडेक्स द्वारा उसका रेफ़रेंस प्राप्त करें।  
1. Appearance को बाउंड के रूप में लेकर रेफ़रेंस्ड स्लाइड की थंबनेल इमेज प्राप्त करें।  
1. थंबनेल इमेज को अपनी पसंदीदा इमेज फ़ॉर्मेट में सहेजें।

उपर्युक्त चरणों पर आधारित यह नमूना कोड है:

```javascript
// प्रस्तुति फ़ाइल को दर्शाने वाली Presentation क्लास का इंस्टेंस बनाएं
var pres = new aspose.slides.Presentation("Thumbnail.pptx");
try {
    // पूर्ण स्केल इमेज बनाएं
    var slideImage = pres.getSlides().get_Item(0).getShapes().get_Item(0).getImage(aspose.slides.ShapeThumbnailBounds.Appearance, 1, 1);
    // इमेज को PNG फ़ॉर्मेट में डिस्क पर सहेजें
    try {
        slideImage.save("output.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **शैप की वास्तविक विज़ुअल बाउंड्स प्राप्त करना**
[Shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/) की फ्रेम प्रॉपर्टी—`getX()`, `getY()`, `getWidth()`, और `getHeight()` मेथड्स—प्रेजेंटेशन मॉडल में संग्रहीत आयत को वर्णित करती हैं। वास्तविक रेंडर किया गया कंटेंट उस फ्रेम से बाहर भी जा सकता है या अलग आयात‑अलाइन्ड आयत में हो सकता है। रोटेशन, आउटलाइन, एरोहेड, टेक्स्ट लेआउट व ओवरफ़्लो, जनरेटेड SmartArt ज्योमेट्री और अन्य रेंडरिंग इफ़ेक्ट्स सभी व्याप्त क्षेत्र को बदल सकते हैं।

[Shape.getVisualBounds](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/#getVisualBounds--) का उपयोग करके इमेज बनाए बिना उस व्याप्त क्षेत्र की गणना करें। यह मेथड स्लाइड कोऑर्डिनेट्स में एक [Rectangle2D.Float](https://docs.oracle.com/javase/8/docs/api/java/awt/geom/Rectangle2D.Float.html) ऑब्जेक्ट लौटाता है। लौटाया गया आयत स्लाइड से क्लिप नहीं किया गया है, इसलिए कंटेंट स्लाइड मूल बिंदु से बाहर निकलने पर इस की कोऑर्डिनेट नेगेटिव हो सकते हैं।

निम्न उदाहरण फ्रेम और विज़ुअल बाउंड्स को प्राप्त कर तुलना करता है:

```javascript
const presentation = new aspose.slides.Presentation("example.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);

    const visualBounds = shape.getVisualBounds();

    const frameBounds = {
        x: shape.getX(),
        y: shape.getY(),
        width: shape.getWidth(),
        height: shape.getHeight()
    };
    const visualBoundsValues = {
        x: visualBounds.getX(),
        y: visualBounds.getY(),
        width: visualBounds.getWidth(),
        height: visualBounds.getHeight()
    };

    console.log(
        `Frame bounds (x, y, width, height): ${frameBounds.x}, ${frameBounds.y}, ${frameBounds.width}, ${frameBounds.height}`
    );
    console.log(
        `Visual bounds (x, y, width, height): ${visualBoundsValues.x}, ${visualBoundsValues.y}, ${visualBoundsValues.width}, ${visualBoundsValues.height}`
    );
} finally {
    presentation.dispose();
}
```

उसी आयत का उपयोग निकटवर्ती शैप को बाएँ, दाएँ, ऊपर या नीचे किनारे के साथ संरेखित करने, जनरेटेड लेआउट में पर्याप्त स्पेस रिज़र्व करने, या अनुमति प्राप्त क्षेत्र के बाहर कंटेंट का पता लगाने के लिए किया जा सकता है। विज़ुअल बाउंड्स विशेष रूप से SmartArt, टेक्स्ट बॉक्स, एरो, चित्र, घुमाए हुए शैप और ग्रुप शैप में उपयोगी होते हैं, जहाँ संग्रहीत फ्रेम पूर्ण रेंडर परिणाम को दर्शाता नहीं है।

जब आपको लेआउट या वैलिडेशन के लिए कोऑर्डिनेट चाहिए और इमेज नहीं चाहिए, तो [Shape.getVisualBounds](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/#getVisualBounds--) का उपयोग करें। जब आपको शैप को रेंडर करने की आवश्यकता हो, तो [Shape.getImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/#getImage--) का उपयोग करें। [ShapeThumbnailBounds](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shapethumbnailbounds/) के साथ, `ShapeThumbnailBounds.Shape` शैप बाउंड्स (आउटलाइन सेटिंग्स सहित) से इमेज साइज करता है, जबकि `ShapeThumbnailBounds.Appearance` शैप की Appearance से साइज करता है और परिणाम को स्लाइड बाउंड्स तक सीमित करता है। इसके विपरीत, [Shape.getVisualBounds](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/#getVisualBounds--) केवल गणना किया गया आयत लौटाता है और उसे स्लाइड तक क्लिप नहीं करता।

## **अक्सर पूछे जाने वाले प्रश्न**

**शैप थंबनेल सहेजते समय कौन‑से इमेज फ़ॉर्मेट उपयोग किए जा सकते हैं?**  
[PNG, JPEG, BMP, GIF, TIFF](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/imageformat/), और अन्य। शैप को SVG वेक्टर के रूप में भी [एक्सपोर्ट किया जा सकता है](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/writeassvg/)।

**थंबनेल रेंडर करते समय Shape बाउंड और Appearance बाउंड में क्या अंतर है?**  
`Shape` शैप की ज्योमेट्री का उपयोग करता है; `Appearance` [विज़ुअल इफ़ेक्ट्स](/slides/hi/nodejs-java/shape-effect/) (शैडो, ग्लो आदि) को ध्यान में रखता है।

**यदि शैप को छिपा (hidden) चिह्नित किया गया हो तो क्या वह थंबनेल में रेंडर होगी?**  
छिपा शैप मॉडल का हिस्सा बना रहता है और रेंडर किया जा सकता है; छिपा फ़्लैग स्लाइडशो प्रदर्शित को प्रभावित करता है, लेकिन शैप की इमेज जनरेशन को नहीं रोकता।

**क्या ग्रुप शैप, चार्ट, SmartArt और अन्य जटिल ऑब्जेक्ट समर्थित हैं?**  
हाँ। कोई भी ऑब्जेक्ट जो [Shape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/shape/) (जैसे [GroupShape](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/groupshape/), [Chart](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/chart/), और [SmartArt](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/smartart/)) के रूप में प्रतिनिधित्व किया गया है, उसे थंबनेल या SVG के रूप में सहेजा जा सकता है।

**क्या सिस्टम‑इंस्टॉल फ़ॉन्ट्स टेक्स्ट शैप के थंबनेल की गुणवत्ता को प्रभावित करते हैं?**  
हाँ। अनचाहे फ़ॉन्ट फ़ॉलबैक और टेक्स्ट रीफ़्लो से बचने के लिए आपको [आवश्यक फ़ॉन्ट्स प्रदान करने](/slides/hi/nodejs-java/custom-font/) (या [फ़ॉन्ट सब्स्टिट्यूशन कॉन्फ़िगर करने](/slides/hi/nodejs-java/font-substitution/)) की जरूरत है।