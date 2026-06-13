---
title: JavaScript में प्रस्तुतियों से स्लाइड हटाएँ
linktitle: स्लाइड हटाएँ
type: docs
weight: 30
url: /hi/nodejs-java/remove-slide-from-presentation/
keywords:
- स्लाइड हटाएँ
- स्लाइड हटाएँ
- अनुपयोगी स्लाइड हटाएँ
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js के साथ PowerPoint और OpenDocument प्रस्तुतियों से स्लाइड को आसानी से हटाएँ। स्पष्ट कोड उदाहरण प्राप्त करें और अपने कार्यप्रवाह को बढ़ाएँ।"
---
## **परिचय**

यदि कोई स्लाइड (या उसकी सामग्री) अनावश्यक हो जाए, तो आप उसे हटा सकते हैं। Aspose.Slides [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास प्रदान करता है जो [SlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidecollection/) को एन्कैप्सुलेट करता है, जो प्रस्तुति में सभी स्लाइडों का रिपॉजिटरी है। किसी ज्ञात [Slide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/) ऑब्जेक्ट के लिए पॉइंटर्स (रेफ़रेंस या इंडेक्स) का उपयोग करके, आप वह स्लाइड निर्दिष्ट कर सकते हैं जिसे आप हटाना चाहते हैं।

## **रेफ़रेंस द्वारा स्लाइड हटाएँ**

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. जिस स्लाइड को आप हटाना चाहते हैं, उसका रेफ़रेंस उसके ID या इंडेक्स द्वारा प्राप्त करें।
1. रेफ़रेंस की गई स्लाइड को प्रस्तुति से हटाएँ।
1. संशोधित प्रस्तुति को सहेजें। 

यह JavaScript कोड दिखाता है कि आप रेफ़रेंस के माध्यम से स्लाइड कैसे हटाते हैं:

```javascript
// एक Presentation ऑब्जेक्ट बनाते हैं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // स्लाइड संग्रह में उसकी इंडेक्स के द्वारा स्लाइड तक पहुँचता है
    var slide = pres.getSlides().get_Item(0);
    // रेफ़रेंस के माध्यम से स्लाइड हटाता है
    pres.getSlides().remove(slide);
    // संशोधित प्रस्तुति को सहेजता है
    pres.save("modified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **इंडेक्स द्वारा स्लाइड हटाएँ**

1. एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. इंडेक्स स्थिति के माध्यम से प्रस्तुति से स्लाइड हटाएँ।
1. संशोधित प्रस्तुति को सहेजें। 

यह JavaScript कोड दिखाता है कि आप इंडेक्स के माध्यम से स्लाइड कैसे हटाते हैं:

```javascript
// एक Presentation ऑब्जेक्ट बनाता है जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // स्लाइड का इंडेक्स उपयोग करके स्लाइड हटाता है
    pres.getSlides().removeAt(0);
    // संशोधित प्रस्तुति को सहेजता है
    pres.save("modified.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **अप्रयुक्त लेआउट स्लाइड हटाएँ**

Aspose.Slides [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides-aspose.slides.Presentation-) मेथड (जो [Compress](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compress/) क्लास से है) प्रदान करता है जो आपको अनवांछित और अप्रयुक्त लेआउट स्लाइडों को हटाने की अनुमति देता है। यह JavaScript कोड दिखाता है कि आप PowerPoint प्रस्तुति से लेआउट स्लाइड कैसे हटाते हैं:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अप्रयुक्त मास्टर स्लाइड हटाएँ**

Aspose.Slides [removeUnusedMasterSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compress/#removeUnusedMasterSlides-aspose.slides.Presentation-) मेथड (जो [Compress](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compress/) क्लास से है) प्रदान करता है जो आपको अनवांछित और अप्रयुक्त मास्टर स्लाइडों को हटाने की अनुमति देता है। यह JavaScript कोड दिखाता है कि आप PowerPoint प्रस्तुति से मास्टर स्लाइड कैसे हटाते हैं:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(pres);
    pres.save("pres-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**स्लाइड हटाने के बाद स्लाइड इंडेक्स क्या होते हैं?**

हटाने के बाद, [collection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidecollection/) पुनः इंडेक्स करती है: प्रत्येक अनुगामी स्लाइड एक स्थान बाएँ शिफ्ट हो जाती है, इसलिए पहले के इंडेक्स नंबर अब पुराने हो जाते हैं। यदि आपको स्थिर रेफ़रेंस चाहिए, तो इंडेक्स के बजाय प्रत्येक स्लाइड का स्थायी ID उपयोग करें।

**क्या स्लाइड की ID उसके इंडेक्स से अलग है, और क्या यह पड़ोसी स्लाइडों के हटने पर बदलती है?**

हां। इंडेक्स स्लाइड की स्थिति है और स्लाइड जोड़ने या हटाने पर बदलता है। स्लाइड ID एक स्थायी पहचानकर्ता है और अन्य स्लाइडों के हटने पर नहीं बदलता।

**स्लाइड हटाने से स्लाइड सेक्शन पर क्या प्रभाव पड़ता है?**

यदि स्लाइड किसी सेक्शन का हिस्सा थी, तो उस सेक्शन में एक स्लाइड कम रह जाएगी। सेक्शन संरचना बनी रहती है; यदि कोई सेक्शन खाली हो जाए, तो आप आवश्यकतानुसार [remove or reorganize sections](/slides/hi/nodejs-java/slide-section/) कर सकते हैं।

**जब कोई स्लाइड हटाई जाती है तो उससे जुड़े नोट्स और कमेंट्स का क्या होता है?**

[Notes](/slides/hi/nodejs-java/presentation-notes/) और [comments](/slides/hi/nodejs-java/presentation-comments/) उस विशिष्ट स्लाइड से जुड़े होते हैं और यह स्लाइड हटते ही हट जाते हैं। अन्य स्लाइडों की सामग्री अपरिवर्तित रहती है।

**स्लाइड हटाने और अप्रयुक्त लेआउट/मास्टर को साफ़ करने में क्या अंतर है?**

डिलीट करने से डेक से विशिष्ट सामान्य स्लाइडें हटती हैं। अप्रयुक्त लेआउट/मास्टर को साफ़ करने से उन लेआउट या मास्टर स्लाइडों को हटाया जाता है जिनका कोई रेफ़रेंस नहीं है, जिससे फ़ाइल आकार घटता है जबकि शेष स्लाइडों की सामग्री नहीं बदलती। ये क्रियाएँ परस्परपूरक हैं: सामान्यतः पहले हटाएँ, फिर साफ़ करें।