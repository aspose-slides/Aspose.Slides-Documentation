---
title: जावास्क्रिप्ट में प्रस्तुतियों को कुशलतापूर्वक मर्ज करें
linktitle: प्रस्तुतियों को मर्ज करें
type: docs
weight: 40
url: /hi/nodejs-java/merge-presentation/
keywords:
- PowerPoint को मर्ज करें
- प्रस्तुतियों को मर्ज करें
- स्लाइड्स को मर्ज करें
- PPT को मर्ज करें
- PPTX को मर्ज करें
- ODP को मर्ज करें
- PowerPoint को संयोजित करें
- प्रस्तुतियों को संयोजित करें
- स्लाइड्स को संयोजित करें
- PPT को संयोजित करें
- PPTX को संयोजित करें
- ODP को संयोजित करें
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के साथ जावास्क्रिप्ट में PowerPoint (PPT, PPTX) और OpenDocument (ODP) प्रस्तुतियों को आसानी से मर्ज करें, जिससे आपका कार्यप्रवाह सरल हो जाए।"
---
## **अवलोकन**

Aspose.Slides आपको एक प्रस्तुति से दूसरी प्रस्तुति में स्लाइड्स क्लोन करके प्रस्तुतियों को मिलाने की अनुमति देता है। यह लेख बताता है कि संपूर्ण प्रस्तुतियों या चयनित स्लाइड्स को कैसे मिलाया जाए, मर्ज के दौरान स्लाइड मास्टर या एक विशिष्ट लेआउट का उपयोग कैसे किया जाए, विभिन्न स्लाइड आकार वाली प्रस्तुतियों को कैसे संभाला जाए, और मर्ज की गई स्लाइड्स को प्रस्तुति अनुभाग में कैसे जोड़ा जाए। यह मर्ज किए गए सामग्री से संबंधित व्यावहारिक नोट्स को भी कवर करता है, जैसे कि वक्ता नोट्स, टिप्पणी, पासवर्ड‑संरक्षित स्रोत फ़ाइलें, और थ्रेड उपयोग।

## **प्रस्तुति मर्जिंग**

जब आप एक प्रस्तुति को दूसरी में मिलाते हैं, तो आप प्रभावी रूप से उनकी स्लाइड्स को एक ही प्रस्तुति में संयोजित कर एक फ़ाइल प्राप्त करते हैं। 

{{% alert title="Info" color="info" %}}

अधिकांश प्रस्तुति कार्यक्रम (PowerPoint या OpenOffice) में ऐसी कार्यक्षमता नहीं होती जो उपयोगकर्ताओं को इस प्रकार प्रस्तुतियों को संयोजित करने की अनुमति देती हो। 

[**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/hi/nodejs-java/), हालांकि, आपको विभिन्न तरीकों से प्रस्तुतियों को मर्ज करने की अनुमति देता है। आप सभी आकृतियों, शैलियों, टेक्स्ट, फ़ॉर्मेटिंग, टिप्पणियों, एनीमेशन आदि के साथ प्रस्तुतियों को मर्ज कर सकते हैं, बिना गुणवत्ता या डेटा की हानि की चिंता किए।

**संबंधित देखें**

[स्लाइड क्लोन करें](https://docs.aspose.com/slides/hi/nodejs-java/clone-slides/).

{{% /alert %}}

### **क्या मर्ज किया जा सकता है**

Aspose.Slides के साथ, आप मर्ज कर सकते हैं 

* संपूर्ण प्रस्तुतियां। सभी प्रस्तुतियों की स्लाइड्स एक ही प्रस्तुति में मिल जाती हैं
* विशिष्ट स्लाइड्स। चयनित स्लाइड्स एक ही प्रस्तुति में मिल जाती हैं
* एक ही फ़ॉर्मेट में प्रस्तुतियां (PPT से PPT, PPTX से PPTX, आदि) और विभिन्न फ़ॉर्मेट में (PPT से PPTX, PPTX से ODP, आदि) एक दूसरे के साथ। 

### **मर्जिंग विकल्प**

आप विकल्प लागू कर सकते हैं जो निर्धारित करते हैं कि 

* आउटपुट प्रस्तुति की प्रत्येक स्लाइड एक अनूठी शैली को बनाए रखती है
* एक विशिष्ट शैली आउटपुट प्रस्तुति की सभी स्लाइड्स पर उपयोग की जाती है। 

प्रेजेंटेशन को मर्ज करने के लिए, Aspose.Slides [addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) मेथड्स (जो [SlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection) क्लास से हैं) प्रदान करता है। `addClone` मेथड्स की कई इम्प्लीमेंटेशन हैं जो प्रेजेंटेशन मर्ज प्रक्रिया के पैरामीटर निर्धारित करती हैं। प्रत्येक Presentation ऑब्जेक्ट के पास एक [Slides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/Presentation#getSlides--) संग्रह होता है, इसलिए आप उस प्रस्तुति से `addClone` मेथड को कॉल कर सकते हैं जिसमें आप स्लाइड्स को मर्ज करना चाहते हैं। 

`addClone` मेथड एक `Slide` ऑब्जेक्ट लौटाता है, जो स्रोत स्लाइड का क्लोन होता है। आउटपुट प्रस्तुति की स्लाइड्स बस स्रोत से कॉपी होती हैं। इसलिए आप परिणामी स्लाइड्स में परिवर्तन कर सकते हैं (उदाहरण के लिए, शैलियों, फ़ॉर्मेटिंग विकल्पों या लेआउट्स को लागू करना) बिना स्रोत प्रस्तुतियों के प्रभावित होने की चिंता किए। 

## **प्रेजेंटेशन मर्ज करें** 

Aspose.Slides [**AddClone(ISlide)**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) मेथड प्रदान करता है जो आपको स्लाइड्स को संयोजित करने की अनुमति देता है जबकि स्लाइड्स अपने लेआउट और शैलियों को बनाए रखती हैं (डिफ़ॉल्ट पैरामीटर)। 

यह JavaScript कोड दिखाता है कि कैसे प्रस्तुतियों को मर्ज किया जाए:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **स्लाइड मास्टर के साथ प्रस्तुतियों को मर्ज करें**

Aspose.Slides [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) मेथड प्रदान करता है जो आपको स्लाइड्स को संयोजित करने की अनुमति देता है जबकि स्लाइड मास्टर प्रस्तुति टेम्प्लेट लागू किया जाता है। इस तरह, यदि आवश्यक हो, तो आप आउटपुट प्रस्तुति की स्लाइड्स के लिए शैली बदल सकते हैं। 

यह कोड JavaScript में वर्णित संचालन को प्रदर्शित करता है:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 

स्लाइड मास्टर के लिए स्लाइड लेआउट स्वचालित रूप से निर्धारित किया जाता है। जब उपयुक्त लेआउट निर्धारित नहीं किया जा सकता, यदि `addClone` मेथड का `allowCloneMissingLayout` बूलियन पैरामीटर true पर सेट है, तो स्रोत स्लाइड का लेआउट उपयोग किया जाता है। अन्यथा, [PptxEditException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/PptxEditException) फेंका जाएगा। 

{{% /alert %}}

यदि आप आउटपुट प्रस्तुति की स्लाइड्स के लिए अलग लेआउट चाहते हैं, तो मर्ज करते समय [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) मेथड का उपयोग करें। 

## **प्रस्तुतियों से विशिष्ट स्लाइड्स को मर्ज करें**

विशिष्ट स्लाइड्स को कई प्रस्तुतियों से मर्ज करना कस्टम स्लाइड डेक बनाने में उपयोगी है। Aspose.Slides for Node.js via Java आपको केवल आवश्यक स्लाइड्स का चयन और आयात करने की अनुमति देता है। API मूल स्लाइड्स की फ़ॉर्मेटिंग, लेआउट और डिज़ाइन को बनाए रखती है। 

निम्न JavaScript कोड एक नई प्रस्तुति बनाता है, दो अन्य प्रस्तुतियों से टाइटल स्लाइड्स जोड़ता है, और परिणाम को फ़ाइल में सहेजता है:

```js
function getTitleSlide(presentation) {
  for (let i = 0; i < presentation.getSlides().size(); i++) {
    let slide = presentation.getSlides().get_Item(i);
    if (slide.getLayoutSlide().getLayoutType() == aspose.slides.SlideLayoutType.Title) {
      return slide;
    }
  }
  return null;
}
```
```js
let presentation = new aspose.slides.Presentation();
let presentation1 = new aspose.slides.Presentation("presentation1.pptx");
let presentation2 = new aspose.slides.Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    let slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    let slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```

## **स्लाइड लेआउट के साथ प्रस्तुतियों को मर्ज करें**

यह JavaScript कोड दिखाता है कि कैसे प्रस्तुतियों से स्लाइड्स को संयोजित किया जाए जबकि आपके पसंदीदा स्लाइड लेआउट को लागू किया जाए ताकि एक आउटपुट प्रस्तुति मिल सके:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **भिन्न स्लाइड आकारों के साथ प्रस्तुतियों को मर्ज करें**

{{% alert title="Note" color="warning" %}} 

आप विभिन्न स्लाइड आकारों वाली प्रस्तुतियों को मर्ज नहीं कर सकते। 

{{% /alert %}}

दो विभिन्न स्लाइड आकार वाली प्रस्तुतियों को मर्ज करने के लिए, आपको एक प्रस्तुति का आकार बदलना होगा ताकि वह दूसरे की आकार से मेल खाए। 

यह नमूना कोड वर्णित संचालन को प्रदर्शित करता है:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize(pres1.getSlideSize().getSize().getWidth(), pres1.getSlideSize().getSize().getHeight(), aspose.slides.SlideSizeScaleType.EnsureFit);
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **स्लाइड्स को प्रस्तुति अनुभाग में मर्ज करें**

यह JavaScript कोड दिखाता है कि कैसे एक विशिष्ट स्लाइड को प्रस्तुति के एक अनुभाग में मर्ज किया जाए:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

स्लाइड अनुभाग के अंत में जोड़ी जाती है। 

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मर्ज के दौरान वक्ता नोट्स संरक्षित रहते हैं?**

हां। स्लाइड्स को क्लोन करने पर, Aspose.Slides सभी स्लाइड तत्वों को, जिसमें नोट्स, फ़ॉर्मेटिंग और एनीमेशन शामिल हैं, साथ ले जाता है। 

**क्या टिप्पणियां और उनके लेखक स्थानांतरित होते हैं?**

टिप्पणियां, जो स्लाइड सामग्री का हिस्सा हैं, स्लाइड के साथ कॉपी की जाती हैं। टिप्पणी लेखक लेबल्स परिणामस्वरूप प्रस्तुति में टिप्पणी ऑब्जेक्ट के रूप में संरक्षित रहते हैं। 

**यदि स्रोत प्रस्तुति पासवर्ड‑संरक्षित है तो क्या करें?**

इसे [पासवर्ड के साथ खोलें](/slides/hi/nodejs-java/password-protected-presentation/) चाहिए [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/setpassword/) के माध्यम से; लोड करने के बाद, उन स्लाइड्स को सुरक्षित रूप से अनसंरक्षित लक्ष्य फ़ाइल में (या एक संरक्षित फ़ाइल में भी) क्लोन किया जा सकता है। 

**मर्ज ऑपरेशन कितना थ्रेड‑सेफ है?**

एक ही [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) इंस्टेंस को [एकाधिक थ्रेड्स](/slides/hi/nodejs-java/multithreading/) से उपयोग न करें। अनुशंसित नियम है "एक दस्तावेज़ — एक थ्रेड"; विभिन्न फ़ाइलों को अलग‑थलग थ्रेड्स में समानांतर रूप से verwerkt किया जा सकता है। 

## **संबंधित देखें**

Aspose एक [मुक्त ऑनलाइन कोलाज मेकर](https://products.aspose.app/slides/hi/collage) प्रदान करता है। इस ऑनलाइन सेवा का उपयोग करके आप [JPG से JPG](https://products.aspose.app/slides/hi/collage/jpg) या PNG से PNG इमेज को मर्ज कर सकते हैं, [फ़ोटो ग्रिड्स](https://products.aspose.app/slides/hi/collage/photo-grid) बना सकते हैं, और अधिक। 

[Aspose मुक्त ऑनलाइन मर्जर](https://products.aspose.app/slides/hi/merger) को देखें। यह आपको समान फ़ॉर्मेट (जैसे PPT से PPT, PPTX से PPTX) या विभिन्न फ़ॉर्मेट (जैसे PPT से PPTX, PPTX से ODP) में PowerPoint प्रस्तुतियों को मर्ज करने की सुविधा देता है। 

[![Aspose मुक्त ऑनलाइन मर्जर](slides-merger.png)](https://products.aspose.app/slides/hi/merger)