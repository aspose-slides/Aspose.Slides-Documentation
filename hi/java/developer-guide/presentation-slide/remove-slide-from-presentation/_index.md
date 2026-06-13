---
title: Java में प्रस्तुतियों से स्लाइड्स हटाएँ
linktitle: स्लाइड हटाएँ
type: docs
weight: 30
url: /hi/java/remove-slide-from-presentation/
keywords:
- स्लाइड हटाएँ
- स्लाइड मिटाएँ
- अप्रयुक्त स्लाइड हटाएँ
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint और OpenDocument प्रस्तुतियों से स्लाइड्स को आसानी से हटाएँ। स्पष्ट कोड उदाहरण प्राप्त करें और अपने कार्यप्रवाह को तेज़ बनाएँ।"
---
## **परिचय**

यदि कोई स्लाइड (या उसकी सामग्री) अनावश्यक हो जाए, तो आप इसे हटा सकते हैं। Aspose.Slides प्रदान करता है [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास जो [ISlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecollection/) को समाहित करता है, जो प्रस्तुति में सभी स्लाइडों का रिपॉज़िटरी है। ज्ञात [ISlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/) ऑब्जेक्ट के लिए पॉइंटर्स (रेफरेंस या इंडेक्स) का उपयोग करके, आप वह स्लाइड निर्दिष्ट कर सकते हैं जिसे आप हटाना चाहते हैं। 

## **रेफ़रेंस द्वारा स्लाइड हटाएँ**

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. उस स्लाइड का रेफ़रेंस प्राप्त करें जिसे आप उसके ID या इंडेक्स के माध्यम से हटाना चाहते हैं।
1. रेफ़रेंस्ड स्लाइड को प्रस्तुति से हटाएँ।
1. परिवर्तित प्रस्तुति को सहेजें। 

यह Java कोड दिखाता है कि कैसे रेफ़रेंस के माध्यम से स्लाइड हटाई जा सकती है:

```java
// एक Presentation ऑब्जेक्ट बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
Presentation pres = new Presentation("demo.pptx");
try {
    // स्लाइड्स संग्रह में उसके इंडेक्स के माध्यम से स्लाइड तक पहुँचता है
    ISlide slide = pres.getSlides().get_Item(0);
    
    // रेफ़रेंस के माध्यम से स्लाइड हटाता है
    pres.getSlides().remove(slide);
    
    // संशोधित प्रस्तुति सहेजता है
    pres.save("modified.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **इंडेक्स द्वारा स्लाइड हटाएँ**

1. एक [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) क्लास का इंस्टेंस बनाएं।
1. इंडेक्स स्थिति के माध्यम से स्लाइड को प्रस्तुति से हटाएँ।
1. परिवर्तित प्रस्तुति को सहेजें। 

यह Java कोड दिखाता है कि कैसे इंडेक्स के माध्यम से स्लाइड हटाई जा सकती है:

```java
// एक Presentation ऑब्जेक्ट बनाता है जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है
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

Aspose.Slides प्रदान करता है [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) मेथड (जो [Compress](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compress/) क्लास से है) जिससे आप अनचाहे और अप्रयुक्त लेआउट स्लाइड्स को हटा सकते हैं। यह Java कोड दिखाता है कि कैसे PowerPoint प्रस्तुति से लेआउट स्लाइड हटाई जा सकती है:

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

Aspose.Slides प्रदान करता है [removeUnusedMasterSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) मेथड (जो [Compress](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compress/) क्लास से है) जिससे आप अनचाहे और अप्रयुक्त मास्टर स्लाइड्स को हटा सकते हैं। यह Java कोड दिखाता है कि कैसे PowerPoint प्रस्तुति से मास्टर स्लाइड हटाई जा सकती है:

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

**स्लाइड को हटाने के बाद स्लाइड इंडेक्स क्या होते हैं?**

हटाने के बाद, [collection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slidecollection/) पुनः इंडेक्स करता है: प्रत्येक बाद की स्लाइड एक स्थान बाएँ शिफ्ट हो जाती है, इसलिए पहले के इंडेक्स नंबर पुराने हो जाते हैं। यदि आपको स्थिर रेफ़रेंस चाहिए, तो प्रत्येक स्लाइड के स्थायी ID का उपयोग करें, न कि उसके इंडेक्स का।

**क्या स्लाइड का ID उसके इंडेक्स से अलग है, और क्या यह पड़ोसी स्लाइड्स के हटने पर बदलता है?**

हां। इंडेक्स स्लाइड की स्थिति दर्शाता है और जब स्लाइड्स जोड़ी या हटाई जाती हैं तो यह बदलता है। स्लाइड ID एक स्थायी पहचानकर्ता है और अन्य स्लाइड्स हटने पर नहीं बदलता।

**स्लाइड को हटाने से स्लाइड सेक्शन पर क्या प्रभाव पड़ता है?**

यदि स्लाइड किसी सेक्शन का हिस्सा थी, तो वह सेक्शन बस एक स्लाइड कम रखेगा। सेक्शन की संरचना बनी रहती है; यदि कोई सेक्शन खाली हो जाए, तो आप आवश्यकतानुसार [सेक्शन हटाएँ या पुनर्गठित करें](/slides/hi/java/slide-section/) कर सकते हैं।

**जब स्लाइड हटाई जाती है तो उससे जुड़े नोट्स और टिप्पणियों का क्या होता है?**

[Notes](/slides/hi/java/presentation-notes/) और [comments](/slides/hi/java/presentation-comments/) उस विशेष स्लाइड से जुड़ी होती हैं और उसके साथ ही हटाई जाती हैं। अन्य स्लाइडों की सामग्री पर कोई प्रभाव नहीं पड़ता।

**स्लाइड हटाने और अप्रयुक्त लेआउट/मास्टर साफ़ करने में क्या अंतर है?**

डिलीट करने से डेक से विशेष सामान्य स्लाइड्स हटाई जाती हैं। अप्रयुक्त लेआउट/मास्टर को साफ़ करने से उन लेआउट या मास्टर स्लाइड्स को हटाया जाता है जिनका कोई रेफ़रेंस नहीं है, जिससे फ़ाइल का आकार कम होता है जबकि शेष स्लाइड सामग्री नहीं बदलती। ये क्रियाएं पूरक हैं: आम तौर पर पहले डिलीट करें, फिर सफ़ाई करें।