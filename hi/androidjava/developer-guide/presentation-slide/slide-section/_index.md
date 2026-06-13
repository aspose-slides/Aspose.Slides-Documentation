---
title: एंड्रॉइड पर प्रस्तुतियों में स्लाइड सेक्शन प्रबंधित करें
linktitle: स्लाइड सेक्शन
type: docs
weight: 90
url: /hi/androidjava/slide-section/
keywords:
- सेक्शन बनाएं
- सेक्शन जोड़ें
- सेक्शन संपादित करें
- सेक्शन बदलें
- सेक्शन नाम
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java के साथ PowerPoint और OpenDocument में स्लाइड सेक्शन को सरल बनाएँ—विभाजित करें, पुनःनामित करें, और पुन: क्रमबद्ध करें ताकि PPTX और ODP कार्यप्रवाह को अनुकूलित किया जा सके।"
---
## **परिचय**

Aspose.Slides for Android via Java के साथ आप PowerPoint Presentation को सेक्शन में व्यवस्थित कर सकते हैं। आप विशिष्ट स्लाइड्स वाले सेक्शन बना सकते हैं।

आप इन स्थितियों में स्लाइड्स को व्यवस्थित या विभाजित करने के लिए सेक्शन बनाना और उनका उपयोग करना चाह सकते हैं:

- जब आप बड़ी प्रस्तुति पर अन्य लोगों या टीम के साथ काम कर रहे हों—और आपको कुछ स्लाइड्स को सहयोगी या टीम के सदस्य को असाइन करना हो। 
- जब आप ऐसी प्रस्तुति से निपट रहे हों जिसमें कई स्लाइड्स हों—और आप एक साथ उसकी सामग्री को प्रबंधित या संपादित करने में कठिनाई महसूस कर रहे हों।

आदर्श रूप से, आपको ऐसा सेक्शन बनाना चाहिए जो समान स्लाइड्स को रखे—स्लाइड्स में कोई सामान्य बात हो या वे किसी नियम के आधार पर समूह में रह सकें—और सेक्शन को ऐसा नाम दें जो उसके अंदर की स्लाइड्स का वर्णन करे। 

## **प्रस्तुति में सेक्शन बनाना**

प्रस्तुति में स्लाइड्स को रखने के लिए एक सेक्शन जोड़ने हेतु, Aspose.Slides for Android via Java [addSection()](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) मेथड प्रदान करता है जो आपको बनाने वाले सेक्शन का नाम और वह स्लाइड निर्दिष्ट करने देता है जिससे सेक्शन शुरू होता है।

यह नमूना कोड आपको Java में प्रस्तुति में एक सेक्शन बनाने का तरीका दिखाता है:

```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Section 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // section1 को newSlide2 पर समाप्त किया जाएगा और उसके बाद section2 शुरू होगा   

    pres.save("pres-sections.pptx", SaveFormat.Pptx);

    pres.getSections().reorderSectionWithSlides(section2, 0);
    pres.save("pres-sections-moved.pptx", SaveFormat.Pptx);

    pres.getSections().removeSectionWithSlides(section2);

    pres.getSections().appendEmptySection("Last empty section");

    pres.save("pres-section-with-empty.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **सेक्शन के नाम बदलना**

PowerPoint प्रस्तुति में एक सेक्शन बनाने के बाद, आप उसका नाम बदलना चाह सकते हैं। 

यह नमूना कोड आपको Aspose.Slides का उपयोग करके Java में प्रस्तुति में एक सेक्शन के नाम को बदलने का तरीका दिखाता है:

```java
Presentation pres = new Presentation("pres.pptx");
try {
    ISection section = pres.getSections().get_Item(0);
    section.setName("My section");
} finally {
    if (pres != null) pres.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या सेक्शन PPT (PowerPoint 97–2003) फ़ॉर्मेट में सहेजने पर संरक्षित रहते हैं?**

नहीं। PPT फ़ॉर्मेट सेक्शन मेटाडेटा को सपोर्ट नहीं करता, इसलिए .ppt में सहेजते समय सेक्शन ग्रुपिंग खो जाता है।

**क्या पूरी सेक्शन को "छिपाया" जा सकता है?**

नहीं। केवल व्यक्तिगत स्लाइड्स को ही छुपाया जा सकता है। एक सेक्शन एक इकाई के रूप में कोई "छिपा" अवस्था नहीं रखता।

**क्या मैं स्लाइड द्वारा सेक्शन को जल्दी से खोज सकता हूँ और इसके विपरीत, सेक्शन की पहली स्लाइड खोज सकता हूँ?**

हां। एक सेक्शन को उसकी शुरूआती स्लाइड द्वारा अनन्य रूप से परिभाषित किया जाता है; दी गई स्लाइड से आप यह पता लगा सकते हैं कि वह कौनसे सेक्शन में है, और किसी सेक्शन की पहली स्लाइड तक पहुंच सकते हैं।