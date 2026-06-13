---
title: एंड्रॉइड पर प्रस्तुतियों से स्लाइड्स हटाएँ
linktitle: स्लाइड हटाएँ
type: docs
weight: 30
url: /hi/androidjava/remove-slide-from-presentation/
keywords:
- स्लाइड हटाएँ
- स्लाइड हटाएँ
- अप्रयुक्त स्लाइड हटाएँ
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android के साथ PowerPoint और OpenDocument प्रस्तुतियों से स्लाइड्स को आसानी से हटाएँ। स्पष्ट Java कोड उदाहरण प्राप्त करें और अपने कार्यप्रवाह को बढ़ाएँ।"
---
## **परिचय**

यदि कोई स्लाइड (या उसकी सामग्री) अत्यधिक हो जाता है, तो आप उसे हटा सकते हैं। Aspose.Slides [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास प्रदान करता है जो [ISlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidecollection/) को सम्मिलित करता है, जो प्रस्तुति में सभी स्लाइड्स के लिए एक रिपॉजिटरी है। ज्ञात [ISlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/) ऑब्जेक्ट के लिए पॉइंटर्स (रेफ़रेंस या इंडेक्स) का उपयोग करके, आप उस स्लाइड को निर्दिष्ट कर सकते हैं जिसे आप हटाना चाहते हैं।

## **रेफ़रेंस द्वारा स्लाइड हटाएँ**

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
1. जिसके ID या इंडेक्स के माध्यम से आप हटाना चाहते हैं, उस स्लाइड का रेफ़रेंस प्राप्त करें।
1. प्रस्तुति से संदर्भित स्लाइड को हटाएँ।
1. संशोधित प्रस्तुति को सहेजें।

यह जावा कोड आपको दिखाता है कि रेफ़रेंस के माध्यम से स्लाइड कैसे हटाएं:

```java
// एक Presentation वस्तु बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करती है
Presentation pres = new Presentation("demo.pptx");
try {
    // स्लाइड्स संग्रह में उसके इंडेक्स के माध्यम से स्लाइड तक पहुँचता है
    ISlide slide = pres.getSlides().get_Item(0);
    
    // संदर्भ के माध्यम से स्लाइड हटाता है
    pres.getSlides().remove(slide);
    
    // संशोधित प्रस्तुति को सहेजता है
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **इंडेक्स द्वारा स्लाइड हटाएँ**

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास की एक इंस्टेंस बनाएं।
1. अपनी इंडेक्स पोजीशन के माध्यम से प्रस्तुति से स्लाइड को हटाएँ।
1. संशोधित प्रस्तुति को सहेजें।

यह जावा कोड आपको दिखाता है कि इंडेक्स के माध्यम से स्लाइड कैसे हटाएं:

```java
// एक Presentation वस्तु बनाता है जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करती है
Presentation pres = new Presentation("demo.pptx");
try {
    // स्लाइड इंडेक्स के माध्यम से स्लाइड हटाता है
    pres.getSlides().removeAt(0);
    
    // संशोधित प्रस्तुति को सहेजता है
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **अप्रयुक्त लेआउट स्लाइड्स हटाएँ**

Aspose.Slides [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) मेथड (जो [Compress](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compress/) क्लास से है) प्रदान करता है जिससे आप अवांछित और अप्रयुक्त लेआउट स्लाइड्स को हटा सकते हैं। यह जावा कोड आपको दिखाता है कि PowerPoint प्रस्तुति से लेआउट स्लाइड कैसे हटाएं:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    Compress.removeUnusedLayoutSlides(pres);

    pres.save("pres-out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **अप्रयुक्त मास्टर स्लाइड्स हटाएँ**

Aspose.Slides [removeUnusedMasterSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) मेथड (जो [Compress](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compress/) क्लास से है) प्रदान करता है जिससे आप अवांछित और अप्रयुक्त मास्टर स्लाइड्स को हटा सकते हैं। यह जावा कोड आपको दिखाता है कि PowerPoint प्रस्तुति से मास्टर स्लाइड कैसे हटाएं:

```java
Presentation pres = new Presentation("pres.pptx");
 try {
     Compress.removeUnusedMasterSlides(pres);

     pres.save("pres-out.pptx", SaveFormat.Pptx);
 } finally {
     if (pres != null) pres.dispose();
 }
```

## **अक्सर पूछे जाने वाले प्रश्न**

**स्लाइड हटाने के बाद स्लाइड इंडेक्स में क्या परिवर्तन होते हैं?**

हटाने के बाद, [collection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slidecollection/) फिर से इंडेक्स बनाता है: प्रत्येक अगले स्लाइड एक पद बाएँ शिफ्ट हो जाता है, इसलिए पूर्व के इंडेक्स नंबर अब वैध नहीं रहते। यदि आपको एक स्थिर रेफ़रेंस चाहिए, तो प्रत्येक स्लाइड के स्थायी ID का उपयोग करें, न कि उसके इंडेक्स का।

**क्या स्लाइड का ID उसके इंडेक्स से अलग है, और क्या यह आस-पास की स्लाइड्स हटाने पर बदलता है?**

हाँ। इंडेक्स स्लाइड की स्थिति है और स्लाइड्स जोड़ने या हटाने पर बदलता है। स्लाइड ID एक स्थायी पहचानकर्ता है और अन्य स्लाइड्स हटने पर नहीं बदलती।

**स्लाइड को हटाने से स्लाइड सेक्शनों पर क्या प्रभाव पड़ता है?**

यदि स्लाइड किसी सेक्शन का हिस्सा थी, तो वह सेक्शन केवल एक कम स्लाइड रखेगा। सेक्शन संरचना बनी रहती है; यदि कोई सेक्शन खाली हो जाता है, तो आप आवश्यकतानुसार [सेक्शन हटाएँ या पुनः व्यवस्थित करें](/slides/hi/androidjava/slide-section/) सकते हैं।

**जब स्लाइड हटाई जाती है तो उससे जुड़े नोट्स और टिप्पणियाँ क्या होती हैं?**

[Notes](/slides/hi/androidjava/presentation-notes/) और [comments](/slides/hi/androidjava/presentation-comments/) उस विशिष्ट स्लाइड से जुड़े होते हैं और वह हटते ही साथ ही हट जाते हैं। अन्य स्लाइड्स की सामग्री पर कोई प्रभाव नहीं पड़ता।

**स्लाइड हटाने और अप्रयुक्त लेआउट/मास्टर को साफ़ करने में क्या अंतर है?**

डिलीट करने से डेक से विशिष्ट सामान्य स्लाइड्स हटती हैं। अप्रयुक्त लेआउट/मास्टर को साफ़ करने से उन लेआउट या मास्टर स्लाइड्स को हटाया जाता है जिनका कोई रेफ़रेंस नहीं है, जिससे फ़ाइल आकार घटता है जबकि शेष स्लाइड सामग्री नहीं बदलती। ये दोनों कार्य आपसी पूरक हैं: आमतौर पर पहले डिलीट करें, फिर साफ़ करें।