---
title: जावा में लो-कोड प्रस्तुति संचालन
linktitle: लो-कोड एपीआई
type: docs
weight: 50
url: /hi/java/low-code-presentation-operations/
keywords:
- लो-कोड प्रस्तुति एपीआई
- प्रेज़ेंटेशन परिवर्तित करें
- प्रेज़ेंटेशन मिलाएँ
- स्लाइड्स पर इटररेट करें
- शेप्स पर इटररेट करें
- टेक्स्ट पर इटररेट करें
- शेप्स एकत्र करें
- प्रेज़ेंटेशन संकुचित करें
- अप्रयुक्त मास्टर स्लाइड्स हटाएँ
- अप्रयुक्त लेआउट स्लाइड्स हटाएँ
- एम्बेडेड फ़ॉन्ट्स संकुचित करें
- PowerPoint
- OpenDocument
- प्रेज़ेंटेशन
- Java
- Aspose.Slides
description: "जावा में Aspose.Slides लो-कोड एपीआई का उपयोग करके प्रेज़ेंटेशन को परिवर्तित और मिलाएँ, सामग्री पर इटररेट करें, शेप्स एकत्र करें, और प्रेज़ेंटेशन का आकार घटाएँ।"
---
## **अवलोकन**

[com.aspose.slides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/) पैकेज सामान्य प्रस्तुति संचालन के लिए स्थैतिक हेल्पर क्लासेज़ प्रदान करता है। ये हेल्पर्स अक्सर उपयोग किए जाने वाले ऑब्जेक्ट- मॉडल कार्यप्रवाह को केंद्रित मेथड्स में लपेटते हैं, जिससे आप कम कोड के साथ फ़ाइलें बदल सकते हैं या मर्ज कर सकते हैं, प्रस्तुति तत्वों को प्रोसेस कर सकते हैं, शेप्स एकत्र कर सकते हैं, और अप्रयुक्त सामग्री को हटा सकते हैं।

जब ऑपरेशन पूरे फ़ाइल या प्रस्तुति पर लागू होता है और डिफ़ॉल्ट कार्यप्रवाह आपकी आवश्यकताओं से मेल खाता है, तब लो-कोड हेल्पर्स सबसे उपयोगी होते हैं। जब आपको व्यक्तिगत स्लाइड्स, मास्टर्स, लेआउट्स, शेप्स, एक्सपोर्ट सेटिंग्स, या प्रस्तुति तत्वों के बीच संबंधों पर सूक्ष्म नियंत्रण चाहिए, तो पूर्ण [Aspose.Slides object model](https://reference.aspose.com/slides/hi/java/com.aspose.slides/) का उपयोग करें।

निम्न तालिका उपलब्ध हेल्पर्स का सारांश प्रस्तुत करती है:

| हेल्पर | उपयोग हेतु |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/hi/java/com.aspose.slides/convert/) | एक प्रस्तुति को सीधे फ़ाइल-से-फ़ाइल कॉल के साथ दूसरे फ़ॉर्मेट में परिवर्तित करना। |
| [Merger](https://reference.aspose.com/slides/hi/java/com.aspose.slides/merger/) | एक ही फ़ॉर्मेट की संपूर्ण प्रस्तुति फ़ाइलों को मिलाना। |
| [ForEach](https://reference.aspose.com/slides/hi/java/com.aspose.slides/foreach/) | प्रत्येक स्लाइड, शेप, पैराग्राफ या टेक्स्ट भाग के लिए एक्शन चलाना। |
| [Collect](https://reference.aspose.com/slides/hi/java/com.aspose.slides/collect/) | बार-बार प्रोसेसिंग या विश्लेषण के लिए पूरी प्रस्तुति से शेप्स प्राप्त करना। |
| [Compress](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compress/) | अप्रयुक्त मास्टर्स और लेआउट्स को हटाना तथा एम्बेडेड फ़ॉन्ट डेटा को कम करना। |

## **प्रेज़ेंटेशन बदलें**

[Convert.autoByExtension](https://reference.aspose.com/slides/hi/java/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) का उपयोग करें जब आउटपुट फ़ाइल एक्स्टेंशन एक्सपोर्ट फ़ॉर्मेट चुनने के लिए पर्याप्त हो। यह मेथड स्रोत प्रस्तुति को खोलता है, आउटपुट पाथ से आवश्यक फ़ॉर्मेट निर्धारित करता है, और परिणाम लिखता है।

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/hi/java/com.aspose.slides/convert/) क्लास PDF, SVG, JPEG, PNG, और TIFF आउटपुट के लिए समर्पित मेथड्स भी प्रदान करता है। जब आपको एक्सपोर्ट से पहले प्रस्तुति का निरीक्षण या संशोधन करने की आवश्यकता हो या चयनित हेल्पर द्वारा उपलब्ध नहीं किए गए एक्सपोर्ट विकल्प को कॉन्फ़िगर करने की आवश्यकता हो, तो पूर्ण ऑब्जेक्ट मॉडल का उपयोग करें। फ़ॉर्मेट-विशिष्ट कार्यप्रवाह और विकल्पों के लिए [Convert Presentation](/java/convert-presentation/) देखें।

## **प्रस्तुति मर्ज करें**

[Merger.process](https://reference.aspose.com/slides/hi/java/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) का उपयोग एक कॉल में संपूर्ण प्रस्तुति फ़ाइलों को मिलाने के लिए करें। इनपुट प्रस्तुतियों का फ़ाइल फ़ॉर्मेट समान होना चाहिए।

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

जब सभी स्लाइड्स को व्यक्तिगत रूप से चयन या पुनःमैप किए बिना एक परिणाम में जोड़ना हो, तो यह हेल्पर उपयुक्त है। जब आपको चयनित स्लाइड्स को मर्ज करना हो, लक्ष्य मास्टर या लेआउट लागू करना हो, सेक्शन स्पष्ट रूप से संरक्षित करने हों, या विभिन्न स्लाइड आकारों को समायोजित करना हो, तो पूर्ण ऑब्जेक्ट मॉडल का उपयोग करें। उन परिदृश्यों के लिए [Merge Presentations](/java/merge-presentation/) देखें।

## **प्रेज़ेंटेशन तत्वों पर इटररेट करें**

[ForEach](https://reference.aspose.com/slides/hi/java/com.aspose.slides/foreach/) क्लास प्रत्येक अनुरोधित प्रस्तुति तत्व प्रकार के लिए कॉलबैक को कॉल करती है। यह नेस्टेड कलेक्शन लूप्स से बचती है और पूरी प्रस्तुति की जाँच या फ़ॉर्मेटिंग परिवर्तन के लिए सुविधाजनक है।

निम्न उदाहरण [ForEach.slide], [ForEach.shape], [ForEach.paragraph] और [ForEach.portion] का उपयोग करके संबंधित तत्वों की जाँच करता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ForEach.slide(presentation, (slide, index) -> {
        System.out.println(String.format("Slide %d: %d shapes", index, slide.getShapes().size()));
    });

    ForEach.shape(presentation, (shape, slide, index) -> {
        System.out.println(String.format("Shape %d on %s: %s", index, slide.getClass().getSimpleName(), shape.getName()));
    });

    ForEach.paragraph(presentation, (paragraph, slide, index) -> {
        System.out.println(String.format("Paragraph %d on %s: %s", index, slide.getClass().getSimpleName(), paragraph.getText()));
    });

    ForEach.portion(presentation, (portion, paragraph, slide, index) -> {
        System.out.println(String.format("Portion %d on %s: %s", index, slide.getClass().getSimpleName(), portion.getText()));
    });
} finally {
    presentation.dispose();
}
```

डिफ़ॉल्ट रूप से, पूरी प्रस्तुति में शेप और टेक्स्ट ट्रैवर्सल में सामान्य, मास्टर, और लेआउट स्लाइड्स शामिल होते हैं। `includeNotes` पैरामीटर वाले ओवरलोड्स नोट्स स्लाइड्स को भी प्रोसेस कर सकते हैं। जब ट्रैवर्सल क्रम, जल्दी निकलना, कॉलबैक कॉल से पहले फ़िल्टरिंग, या विस्तृत पेरेंट-चाइल्ड नियंत्रण महत्वपूर्ण हो, तो सीधे कलेक्शन लूप्स का उपयोग करें।

## **शेप्स एकत्र करें**

[Collect.shapes](https://reference.aspose.com/slides/hi/java/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) का उपयोग तब करें जब आपको प्रत्येक शेप के लिए कॉलबैक के बजाय पूरी प्रस्तुति में सभी शेप्स का संग्रह चाहिए। यह तब उपयोगी है जब वही सेट कई बार फ़िल्टर, गिना या प्रोसेस किया जाना हो।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Iterable<Shape> shapes = Collect.shapes(presentation);

    for (Shape shape : shapes) {
        System.out.println(String.format("%s: %s", shape.getName(), shape.getClass().getSimpleName()));
    }
} finally {
    presentation.dispose();
}
```

जब प्रत्येक शेप को तुरंत हैंडल किया जा सकता है और आप संग्रहित परिणाम को बनाए रखने की आवश्यकता नहीं रखते, तो इसके बजाय [ForEach.shape] का उपयोग करें।

## **प्रेज़ेंटेशन सामग्री को संकुचित करें**

[Compress](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compress/) क्लास अप्रयुक्त संरचनात्मक तत्वों को हटाने और एम्बेडेड फ़ॉन्ट डेटा को कम करने में सक्षम है:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) उन लेआउट स्लाइड्स को हटाता है जिन्हें कोई सामान्य स्लाइड संदर्भित नहीं करती।
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) उन मास्टर स्लाइड्स को हटाता है जो अब उपयोग नहीं होतीं।
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) एम्बेडेड फ़ॉन्ट्स से अप्रयुक्त कैरेक्टर को हटाता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    Compress.removeUnusedMasterSlides(presentation);
    Compress.compressEmbeddedFonts(presentation);

    presentation.save("compressed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

अप्रयुक्त लेआउट्स को अप्रयुक्त मास्टर्स से पहले हटाएँ ताकि लेआउट सफ़ाई के बाद जो मास्टर अप्रसंदर्भित हो जाए उसे भी हटाया जा सके। यदि आपको बाद में मूल मास्टर्स, लेआउट्स, या पूरी एम्बेडेड फ़ॉन्ट डेटा की आवश्यकता पड़ सकती है, तो अनुकूलित प्रस्तुति को नई फ़ाइल में सहेजें। अधिक विवरण के लिए [Slide Master](/java/slide-master/) और [Embedded Font](/java/embedded-font/) देखें।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं कब लो-कोड API का उपयोग पूर्ण ऑब्जेक्ट मॉडल के बजाय करना चाहिए?**

जब कोई मानक ऑपरेशन पूरी फ़ाइल या प्रस्तुति पर लागू हो और व्यक्तिगत तत्वों के ऊपर विस्तृत नियंत्रण की आवश्यकता न हो, तब लो-कोड हेल्पर्स का उपयोग करें। जब आपको विशिष्ट स्लाइड्स का चयन करना हो, मास्टर और लेआउट संबंधों को नियंत्रित करना हो, मध्यवर्ती अवस्था की जाँच करनी हो, या वह व्यवहार कॉन्फ़िगर करना हो जो हेल्पर प्रदान नहीं करता, तो पूर्ण ऑब्जेक्ट मॉडल का उपयोग करें।

**क्या Merger विभिन्न फ़ाइल फ़ॉर्मेट्स की प्रस्तुतियों को मिलाना सकता है?**

नहीं। [Merger.process] को इनपुट प्रस्तुतियों का एक ही फ़ॉर्मेट होना आवश्यक है। पहले इनपुट फ़ाइलों को सामान्य फ़ॉर्मेट में परिवर्तित करें, उदाहरण के लिए [Convert.autoByExtension] के साथ, और फिर परिवर्तित फ़ाइलों को मर्ज करें।

**क्या ForEach मास्टर, लेआउट, और नोट्स स्लाइड्स को प्रोसेस करता है?**

[ForEach.slide] सामान्य प्रस्तुति स्लाइड्स पर इटररेट करता है। पूरी प्रस्तुति में [ForEach.shape], [ForEach.paragraph] और [ForEach.portion] डिफ़ॉल्ट रूप से सामान्य, मास्टर और लेआउट स्लाइड्स को शामिल करते हैं। नोट्स स्लाइड्स को शामिल करने के लिए उनके ओवरलोड में `includeNotes` को `true` सेट करें।

**ForEach.shape और Collect.shapes में क्या अंतर है?**

प्रत्येक शेप को तुरंत कॉलबैक के द्वारा प्रोसेस करने के लिए [ForEach.shape] का उपयोग करें। जब आपको एक इटेरेबल परिणाम चाहिए जो बरकरार रखा सके, फ़िल्टर किया सके, गिना सके या कई बार ट्रैवर्स किया सके, तो [Collect.shapes] का उपयोग करें।

**क्या Compress हमेशा प्रस्तुति फ़ाइल को छोटा बनाता है?**

ज़रूरी नहीं। परिणाम इस बात पर निर्भर करता है कि प्रस्तुति में अप्रयुक्त लेआउट्स, अप्रयुक्त मास्टर्स, या अप्रयुक्त कैरेक्टर्स वाले एम्बेडेड फ़ॉन्ट्स हैं या नहीं। यदि इनमें से कोई भी नहीं है, तो संबंधित [Compress] ऑपरेशन्स फ़ाइल का आकार घटा नहीं सकते।

**क्या ForEach या Compress द्वारा किए गए बदलाव स्वचालित रूप से सहेजे जाते हैं?**

नहीं। ये हेल्पर्स मेमोरी में लोड किए गए [Presentation] ऑब्जेक्ट पर कार्य करते हैं। [ForEach] कॉलबैक में तत्व बदलने या [Compress] चलाने के बाद, परिणाम लिखने के लिए [Presentation.save] को कॉल करें।

## **संबंधित लेख**

- [प्रेज़ेंटेशन बदलें](/java/convert-presentation/)
- [प्रेज़ेंटेशन मिलाएँ](/java/merge-presentation/)
- [स्लाइड मास्टर](/java/slide-master/)
- [टेक्स्ट बॉक्स प्रबंधित करें](/java/manage-textbox/)
- [एम्बेडेड फ़ॉन्ट](/java/embedded-font/)