---
title: जावा का उपयोग करके प्रस्तुतियों में स्लाइड सेक्शन प्रबंधित करें
linktitle: स्लाइड सेक्शन
type: docs
weight: 90
url: /hi/java/slide-section/
keywords:
- सेक्शन बनाएं
- सेक्शन जोड़ें
- सेक्शन संपादित करें
- सेक्शन बदलें
- सेक्शन नाम
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java के साथ PowerPoint और OpenDocument में स्लाइड सेक्शन को सुव्यवस्थित करें — विभाजित करें, नाम बदलें, और पुन:क्रमित करें ताकि PPTX और ODP कार्यप्रवाह को अनुकूलित किया जा सके।"
---
## **परिचय**

Aspose.Slides for Java के साथ, आप PowerPoint Presentation को अनुभागों में व्यवस्थित कर सकते हैं। आप ऐसे अनुभाग बना सकते हैं जिनमें विशिष्ट स्लाइड्स हों।

आप निम्नलिखित स्थितियों में अनुभाग बनाकर उन्हें स्लाइड्स को व्यवस्थित या विभाजित करने के लिए उपयोग करना चाह सकते हैं:

- जब आप बड़ी प्रस्तुति पर अन्य लोगों या टीम के साथ काम कर रहे हों—और आपको कुछ स्लाइड्स को सहकर्मी या टीम के कुछ सदस्य को सौंपना हो।  
- जब आपके पास कई स्लाइड्स वाली प्रस्तुति हो—और आप एक साथ उसकी सामग्री को प्रबंधित या संपादित करने में कठिनाई महसूस कर रहे हों।

आदर्श रूप में, आपको ऐसा अनुभाग बनाना चाहिए जिसमें समान स्लाइड्स हों—स्लाइड्स में कोई सामान्यता हो या वे किसी नियम के आधार पर समूहित हो सकें—और अनुभाग को ऐसा नाम दें जो उसके भीतर की स्लाइड्स का वर्णन करे।

## **प्रस्तुतियों में अनुभाग बनाना**

प्रस्तुति में स्लाइड्स को रखने वाले एक अनुभाग को जोड़ने के लिए, Aspose.Slides for Java [addSection()](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ISectionCollection#addSection-java.lang.String-com.aspose.slides.ISlide-) मेथड प्रदान करता है जो आपको बनाये जाने वाले अनुभाग का नाम और वह स्लाइड निर्दिष्ट करने देता है जिससे वह अनुभाग शुरू होता है।

यह नमूना कोड आपको जावा में प्रस्तुति में एक अनुभाग बनाने का तरीका दिखाता है:

```java
Presentation pres = new Presentation();
try {
    ISlide defaultSlide = pres.getSlides().get_Item(0);
    ISlide newSlide1 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide2 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide3 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));
    ISlide newSlide4 = pres.getSlides().addEmptySlide(pres.getLayoutSlides().get_Item(0));

    ISection section1 = pres.getSections().addSection("Section 1", newSlide1);
    ISection section2 = pres.getSections().addSection("Section 2", newSlide3); // section1 newSlide2 पर समाप्त होगा और उसके बाद section2 शुरू होगा   

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

## **अनुभागों के नाम बदलें**

PowerPoint प्रस्तुति में एक अनुभाग बनाने के बाद, आप उसका नाम बदलना चाह सकते हैं।

यह नमूना कोड आपको Aspose.Slides का उपयोग करके जावा में प्रस्तुति में एक अनुभाग का नाम बदलने का तरीका दिखाता है:

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

**क्या PPT (PowerPoint 97–2003) फॉर्मेट में सहेजते समय अनुभाग सुरक्षित रहते हैं?**

नहीं। PPT फॉर्मेट अनुभाग मेटाडेटा को समर्थन नहीं देता, इसलिए .ppt में सहेजने पर अनुभाग समूहांकन खो जाता है।

**क्या पूरी अनुभाग को "छिपाया" जा सकता है?**

नहीं। केवल व्यक्तिगत स्लाइड्स को छिपाया जा सकता है। एक अनुभाग इकाई के रूप में कोई "छिपा हुआ" स्थिति नहीं रखता।

**क्या मैं किसी स्लाइड के आधार पर शीघ्रता से एक अनुभाग खोज सकता हूँ और इसके विपरीत, किसी अनुभाग की पहली स्लाइड प्राप्त कर सकता हूँ?**

हाँ। एक अनुभाग उसकी प्रारंभिक स्लाइड द्वारा विशिष्ट रूप से परिभाषित होता है; किसी स्लाइड को देकर आप निर्धारित कर सकते हैं कि वह किस अनुभाग का हिस्सा है, और किसी अनुभाग के लिए आप उसकी पहली स्लाइड तक पहुँच सकते हैं।