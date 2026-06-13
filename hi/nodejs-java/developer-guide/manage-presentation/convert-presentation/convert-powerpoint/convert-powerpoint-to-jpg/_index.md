---
title: JavaScript में PPT और PPTX को JPG में बदलें
linktitle: PowerPoint से JPG
type: docs
weight: 60
url: /hi/nodejs-java/convert-powerpoint-to-jpg/
keywords:
- PowerPoint परिवर्तित करें
- प्रस्तुति परिवर्तित करें
- स्लाइड परिवर्तित करें
- PPT परिवर्तित करें
- PPTX परिवर्तित करें
- PowerPoint से JPG
- प्रस्तुति से JPG
- स्लाइड से JPG
- PPT से JPG
- PPTX से JPG
- PowerPoint को JPG के रूप में सहेजें
- प्रस्तुति को JPG के रूप में सहेजें
- स्लाइड को JPG के रूप में सहेजें
- PPT को JPG के रूप में सहेजें
- PPTX को JPG के रूप में सहेजें
- PPT को JPG में निर्यात करें
- PPTX को JPG में निर्यात करें
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java के साथ JavaScript में PowerPoint (PPT, PPTX) स्लाइड्स को उच्च‑गुणवत्ता वाले JPG इमेज में तेज़ और विश्वसनीय कोड उदाहरणों का उपयोग करके परिवर्तित करें।"
---
## **परिचय**

PowerPoint और OpenDocument प्रस्तुतियों को JPG छवियों में रूपांतरित करने से स्लाइड्स को साझा करना, प्रदर्शन को अनुकूलित करना, और वेबसाइटों या एप्लिकेशनों में सामग्री एम्बेड करना आसान हो जाता है। Aspose.Slides आपको PPTX, PPT, और ODP फ़ाइलों को उच्च‑गुणवत्ता वाली JPEG छवियों में बदलने की सुविधा देता है। यह मार्गदर्शिका रूपांतरण के विभिन्न तरीकों की व्याख्या करती है।

इन सुविधाओं के साथ, अपना स्वयं का प्रस्तुति व्यूअर लागू करना और प्रत्येक स्लाइड के लिए थंबनेल बनाना आसान हो जाता है। यह तब उपयोगी हो सकता है जब आप प्रस्तुति स्लाइड्स को कॉपी करने से बचाना चाहते हैं या प्रस्तुति को केवल‑पठन मोड में प्रदर्शित करना चाहते हैं। Aspose.Slides आपको पूरी प्रस्तुति या किसी विशिष्ट स्लाइड को इमेज फ़ॉर्मैट में बदलने की अनुमति देता है।

## **PowerPoint PPT/PPTX को JPG में बदलें**
यहाँ PPT/PPTX को JPG में बदलने के चरण दिए गए हैं:

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation) प्रकार का इंस्टांस बनाएँ।
2. [Presentation.getSlides()](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#getSlides--) संग्रह से [Slide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Slide) प्रकार का स्लाइड ऑब्जेक्ट प्राप्त करें।
3. प्रत्येक स्लाइड का थंबनेल बनाएँ और फिर उसे JPG में बदलें। [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Slide#getImage-float-float-) मेथड स्लाइड का थंबनेल प्राप्त करने के लिए उपयोग किया जाता है, यह परिणामस्वरूप [Imagess](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Images) ऑब्जेक्ट लौटाता है। [getImage](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Slide#getImage-aspose.slides.IRenderingOptions-float-float-) मेथड को आवश्यक स्लाइड के [Slide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Slide) प्रकार से कॉल किया जाना चाहिए, परिणामस्वरूप थंबनेल के स्केल मेथड में पास किए जाते हैं।
4. जब आप स्लाइड थंबनेल प्राप्त कर लें, तो थंबनेल ऑब्जेक्ट से [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/iimage/#save) मेथड को कॉल करें। परिणामी फ़ाइल नाम और इमेज फ़ॉर्मेट को इसमें पास करें।

{{% alert color="primary" %}}

**नोट**: PPT/PPTX को JPG रूपांतरण Aspose.Slides API में अन्य प्रकारों के रूपांतरण से अलग होता है। अन्य प्रकारों के लिए, आप आमतौर पर [**Presentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) मेथड का उपयोग करते हैं, लेकिन यहाँ आपको [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/iimage/#save) मेथड की आवश्यकता है।

{{% /alert %}} 

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // पूर्ण स्केल छवि बनाता है
        var slideImage = sld.getImage(1.0, 1.0);
        // JPEG फ़ॉर्मैट में छवि को डिस्क पर सहेजता है
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **PowerPoint PPT/PPTX को कस्टमाइज़्ड डायमेंशन के साथ JPG में बदलें**
परिणामी थंबनेल और JPG छवि के आयाम बदलने के लिए, आप *ScaleX* और *ScaleY* मानों को [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Slide#getImage-float-float-) मेथड में पास करके सेट कर सकते हैं:

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    // आयाम निर्धारित करता है
    var desiredX = 1200;
    var desiredY = 800;
    // X और Y के स्केल किए हुए मान प्राप्त करता है
    var ScaleX = 1.0 / pres.getSlideSize().getSize().getWidth() * desiredX;
    var ScaleY = 1.0 / pres.getSlideSize().getSize().getHeight() * desiredY;
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // पूर्ण स्केल छवि बनाता है
        var slideImage = sld.getImage(ScaleX, ScaleY);
        // JPEG फ़ॉर्मैट में छवि को डिस्क पर सहेजता है
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Presentation को इमेज में सहेजते समय टिप्पणी रेंडर करें**
Aspose.Slides for Node.js via Java ऐसी सुविधा प्रदान करता है जो आपको प्रस्तुतियों की स्लाइड्स में टिप्पणी को रेंडर करने की अनुमति देती है जब आप उन स्लाइड्स को इमेज में बदल रहे होते हैं। यह JavaScript कोड इस ऑपरेशन को दर्शाता है:

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    var notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
    var opts = new aspose.slides.RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        var slideImage = sld.getImage(opts, java.newInstanceSync("java.awt.Dimension", 740, 960));
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.png", sld.getSlideNumber()));
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Tip" color="primary" %}}

Aspose एक [FREE Collage web app](https://products.aspose.app/slides/hi/collage) प्रदान करता है। इस ऑनलाइन सेवा का उपयोग करके, आप [JPG to JPG](https://products.aspose.app/slides/hi/collage/jpg) या PNG to PNG इमेज को मर्ज कर सकते हैं, [photo grids](https://products.aspose.app/slides/hi/collage/photo-grid) बना सकते हैं, आदि।

{{% /alert %}}

## **अन्य देखें**

PPT/PPTX को इमेज में बदलने के अन्य विकल्प देखें जैसे:

- [PPT/PPTX से SVG रूपांतरण](/slides/hi/nodejs-java/render-a-slide-as-an-svg-image/).

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या यह विधि बैच रूपांतरण को सपोर्ट करती है?**

हां, Aspose.Slides एक ही ऑपरेशन में कई स्लाइड्स को JPG में बैच रूपांतरण की अनुमति देता है।

**क्या रूपांतरण SmartArt, चार्ट और अन्य जटिल ऑब्जेक्ट्स को सपोर्ट करता है?**

हां, Aspose.Slides सभी सामग्री को रेंडर करता है, जिसमें SmartArt, चार्ट, तालिकाएँ, आकार आदि शामिल हैं। हालांकि, रेंडरिंग सटीकता PowerPoint की तुलना में थोड़ा अलग हो सकती है, विशेषकर जब कस्टम या अनुपलब्ध फ़ॉन्ट्स का उपयोग किया जाता है।

**क्या प्रोसेस की जा सकने वाली स्लाइडों की संख्या पर कोई सीमा है?**

Aspose.Slides खुद प्रोसेस किए जा सकने वाली स्लाइडों की संख्या पर कोई कड़ी सीमा नहीं लगाता। हालांकि, बड़े प्रस्तुतियों या उच्च‑रिज़ॉल्यूशन इमेजों के साथ काम करते समय आपको मेमोरी ख़त्म होने की त्रुटि मिल सकती है।