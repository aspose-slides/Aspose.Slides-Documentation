---
title: एंड्रॉयड पर लो-कोड प्रस्तुति ऑपरेशन्स
linktitle: लो-कोड API
type: docs
weight: 50
url: /hi/androidjava/low-code-presentation-operations/
keywords:
- लो-कोड प्रस्तुति API
- प्रस्तुति बदलना
- प्रस्तुतियों को मिलाना
- स्लाइड्स पर इटरैट करना
- शेप्स पर इटरैट करना
- टेक्स्ट पर इटरैट करना
- शेप्स एकत्र करना
- प्रस्तुति संपीड़ित करना
- अप्रयुक्त मास्टर स्लाइड्स हटाना
- अप्रयुक्त लेआउट स्लाइड्स हटाना
- एम्बेडेड फ़ॉन्ट्स संपीड़ित करना
- PowerPoint
- OpenDocument
- प्रस्तुति
- एंड्रॉयड
- Java
- Aspose.Slides
description: "एंड्रॉयड पर Aspose.Slides लो-कोड API का उपयोग करके प्रस्तुतियों को बदलें और मिलाएँ, सामग्री में इटरैट करें, शेप्स एकत्र करें, और प्रस्तुति का आकार घटाएँ।"
---
## **अवलोकन**

पैकेज [com.aspose.slides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/) सामान्य प्रस्तुति कार्यों के लिए स्थिर सहायक क्लासेस प्रदान करता है। ये सहायक अक्सर उपयोग किए जाने वाले ऑब्जेक्ट‑मॉडल वर्कफ़्लोज़ को केंद्रित मेथड्स में लपेटते हैं, ताकि आप फ़ाइलों को परिवर्तित या मर्ज कर सकें, प्रस्तुति तत्वों को प्रोसेस कर सकें, शैप्स एकत्र कर सकें, और कम कोड के साथ अस्थिर सामग्री को हटा सकें।

लो‑कोड सहायक तब सबसे उपयोगी होते हैं जब ऑपरेशन पूरे फ़ाइल या प्रस्तुति पर लागू होता है और डिफ़ॉल्ट वर्कफ़्लो आपकी आवश्यकताओं के अनुरूप होता है। जब आपको व्यक्तिगत स्लाइड्स, मास्टर्स, लेआउट्स, शैप्स, एक्सपोर्ट सेटिंग्स, या प्रस्तुति तत्वों के बीच संबंधों पर सूक्ष्म नियंत्रण की आवश्यकता हो, तो पूरा [Aspose.Slides object model](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/) उपयोग करें।

निम्न तालिका उपलब्ध सहायक को संक्षेप में प्रस्तुत करती है:

| सहायक | उपयोग हेतु |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/convert/) | एक प्रस्तुति को सीधे फ़ाइल‑से‑फ़ाइल कॉल के साथ दूसरे फॉर्मेट में बदलना। |
| [Merger](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/merger/) | एक ही फॉर्मेट की पूरी प्रस्तुति फ़ाइलों को मिलाना। |
| [ForEach](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/foreach/) | प्रत्येक स्लाइड, शैप, पैराग्राफ, या टेक्स्ट भाग के लिए एक्शन चलाना। |
| [Collect](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/collect/) | पूरी प्रस्तुति से शैप्स को पुनरावृत्ति प्रोसेसिंग या विश्लेषण के लिए प्राप्त करना। |
| [Compress](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compress/) | अप्रयुक्त मास्टर्स और लेआउट्स को हटाना और एम्बेडेड फ़ॉन्ट डेटा को कम करना। |

## **प्रस्तुति परिवर्तित करना**

[Convert.autoByExtension](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) का उपयोग तब करें जब आउटपुट फ़ाइल एक्स्टेंशन एक्सपोर्ट फॉर्मेट चुनने के लिए पर्याप्त हो। यह मेथड स्रोत प्रस्तुति को खोलता है, आउटपुट पथ से आवश्यक फॉर्मेट निर्धारित करता है, और परिणाम लिखता है।

```java
import com.aspose.slides.Convert;

Convert.autoByExtension("input.pptx", "output.pdf");
```

[Convert](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/convert/) क्लास PDF, SVG, JPEG, PNG, और TIFF आउटपुट के लिए समर्पित मेथड्स भी प्रदान करता है। जब आपको एक्सपोर्ट से पहले प्रस्तुति का निरीक्षण या संशोधन करना हो या ऐसे एक्सपोर्ट विकल्प को कॉन्फ़िगर करना हो जो चयनित सहायक द्वारा उजागर नहीं किए गए हों, तो पूरे ऑब्जेक्ट मॉडल का उपयोग करें। स्वरूप‑विशिष्ट वर्कफ़्लोज़ और विकल्पों के लिए देखें [Convert Presentation](/slides/hi/androidjava/convert-presentation/)।

## **प्रस्तुति मर्ज करना**

[Merger.process](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) का उपयोग करके एक कॉल में पूरी प्रस्तुति फ़ाइलों को मिलाएँ। इनपुट प्रस्तुतियों का फ़ाइल फ़ॉर्मेट समान होना चाहिए।

```java
import com.aspose.slides.Merger;

String[] inputFiles = { "part-1.pptx", "part-2.pptx" };
Merger.process(inputFiles, "merged.pptx");
```

यह सहायक तब उपयुक्त है जब सभी स्लाइड्स को व्यक्तिगत रूप से चुनने या पुन:मैपिंग किए बिना एक परिणाम में जोड़ना हो। जब आपको चयनित स्लाइड्स को मर्ज करना हो, गंतव्य मास्टर या लेआउट लागू करना हो, सेक्शन को स्पष्ट रूप से संरक्षित करना हो, या विभिन्न स्लाइड आकारों को समेटना हो, तो पूरे ऑब्जेक्ट मॉडल का उपयोग करें। ऐसे परिदृश्यों के लिए देखें [Merge Presentations](/slides/hi/androidjava/merge-presentation/)।

## **प्रस्तुति तत्वों पर इटरेट करना**

[ForEach](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/foreach/) क्लास अनुरोधित प्रकार के प्रत्येक प्रस्तुति तत्व के लिए एक कॉलबैक को बुलाती है। यह नेस्टेड संग्रह लूप्स से बचती है और प्रस्तुति‑व्यापी निरीक्षण या फ़ॉर्मेटिंग परिवर्तन के लिए सुविधाजनक है।

निम्न उदाहरण [ForEach.slide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-), [ForEach.shape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), और [ForEach.portion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) का उपयोग करके संबंधित तत्वों की जांच करता है:

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

डिफ़ॉल्ट रूप से, प्रस्तुति‑व्यापी शैप और टेक्स्ट ट्रैवर्सल में सामान्य, मास्टर और लेआउट स्लाइड्स शामिल होते हैं। `includeNotes` पैरामीटर वाले ओवरलोड भी नोट्स स्लाइड्स को प्रोसेस कर सकते हैं। जब ट्रैवर्सल क्रम, शीघ्र निकास, कॉलबैक बुलाने से पहले फ़िल्टरिंग, या विस्तृत पैरेंट‑चाइल्ड नियंत्रण महत्वपूर्ण हो, तो सीधे संग्रह लूप्स का उपयोग करें।

## **शेप्स एकत्र करना**

जब आपको प्रत्येक शैप के लिए कॉलबैक के बजाय प्रस्तुति में सभी शैप्स का संग्रह चाहिए हो, तो [Collect.shapes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) का उपयोग करें। यह उपयोगी है जब एक ही सेट को कई बार फ़िल्टर, गिनना, या प्रोसेस किया जाना हो।

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

जब प्रत्येक शैप को तुरंत संभाला जा सकता है और आपको एकत्रित परिणाम को बनाए रखने की आवश्यकता नहीं है, तो इसके बजाय [ForEach.shape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) का उपयोग करें।

## **प्रस्तुति सामग्री संपीड़ित करना**

[Compress](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compress/) क्लास अस्थिर संरचनात्मक तत्वों को हटाकर और एम्बेडेड फ़ॉन्ट डेटा को कम करके संपीड़ित कर सकती है:

- [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) उन लेआउट स्लाइड्स को हटाता है जो किसी सामान्य स्लाइड द्वारा संदर्भित नहीं हैं।
- [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) उन मास्टर स्लाइड्स को हटाता है जो अब उपयोग में नहीं हैं।
- [Compress.compressEmbeddedFonts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compress/#compressEmbeddedFonts-com.aspose.slides.Presentation-) एम्बेडेड फ़ॉन्ट्स से अस्थिर अक्षरों को हटाता है।

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

अप्रयुक्त लेआउट्स को अप्रयुक्त मास्टर्स से पहले हटाएँ ताकि लेआउट सफ़ाई के बाद अनरेफ़रेंस्ड हो गया मास्टर भी हटाया जा सके। यदि बाद में आपको मूल मास्टर्स, लेआउट्स, या पूरी एम्बेडेड फ़ॉन्ट डेटा की आवश्यकता हो सकती है, तो अनुकूलित प्रस्तुति को नई फ़ाइल में सहेजें। अधिक विवरण के लिए देखें [Slide Master](/slides/hi/androidjava/slide-master/) और [Embedded Font](/slides/hi/androidjava/embedded-font/)।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं लो‑कोड API को पूर्ण ऑब्जेक्ट मॉडल के बजाय कब उपयोग करूँ?**  
जब एक मानक ऑपरेशन पूरे फ़ाइल या प्रस्तुति पर लागू होता है और व्यक्तिगत तत्वों पर विस्तृत नियंत्रण की आवश्यकता नहीं होती, तब लो‑कोड सहायक का उपयोग करें। जब आपको विशिष्ट स्लाइड्स चुननी हों, मास्टर और लेआउट संबंधों को नियंत्रित करना हो, मध्यवर्ती स्थिति को निरीक्षित करना हो, या ऐसे व्यवहार को कॉन्फ़िगर करना हो जो सहायक उजागर नहीं करता, तो पूर्ण ऑब्जेक्ट मॉडल का उपयोग करें।

**क्या Merger विभिन्न फ़ाइल फ़ॉर्मेट की प्रस्तुतियों को संयोजित कर सकता है?**  
नहीं। [Merger.process](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/merger/#process-java.lang.String:A-java.lang.String-) को इनपुट प्रस्तुतियों को समान फ़ॉर्मेट में होना आवश्यक है। पहले इनपुट फ़ाइलों को सामान्य फ़ॉर्मेट में परिवर्तित करें, उदाहरण के लिए [Convert.autoByExtension](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/convert/#autoByExtension-java.lang.String-java.lang.String-) का उपयोग करके, और फिर परिवर्तित फ़ाइलों को मर्ज करें।

**क्या ForEach मास्टर, लेआउट और नोट्स स्लाइड्स को प्रोसेस करता है?**  
[ForEach.slide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/foreach/#slide-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachSlideCallback-) सामान्य प्रस्तुति स्लाइड्स पर इटरेट करता है। प्रस्तुति‑व्यापी [ForEach.shape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-), [ForEach.paragraph](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/foreach/#paragraph-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachParagraphCallback-), और [ForEach.portion](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/foreach/#portion-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachPortionCallback-) ऑपरेशन डिफ़ॉल्ट रूप से सामान्य, मास्टर और लेआउट स्लाइड्स को शामिल करते हैं। `includeNotes` को `true` सेट करके ओवरलोड का उपयोग करने पर नोट्स स्लाइड्स भी शामिल किए जा सकते हैं।

**ForEach.shape और Collect.shapes में क्या अंतर है?**  
[ForEach.shape](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/foreach/#shape-com.aspose.slides.Presentation-com.aspose.slides.ForEach.ForEachShapeCallback-) का उपयोग प्रत्येक शैप को तुरंत कॉलबैक के माध्यम से प्रोसेस करने के लिए करें। जब आपको एक पुनरावृत्ति योग्य परिणाम चाहिए जिसे आप रख सकें, फ़िल्टर कर सकें, गिन सकें, या कई बार ट्रैवर्स कर सकें, तो [Collect.shapes](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/collect/#shapes-com.aspose.slides.Presentation-) का उपयोग करें।

**क्या Compress हमेशा प्रस्तुति फ़ाइल को छोटा बनाता है?**  
ज़रूर नहीं। परिणाम इस बात पर निर्भर करता है कि प्रस्तुति में अप्रयुक्त लेआउट, अप्रयुक्त मास्टर, या अप्रयुक्त अक्षरों वाले एम्बेडेड फ़ॉन्ट हैं या नहीं। यदि इनमें से कुछ नहीं है, तो संबंधित [Compress](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compress/) ऑपरेशन फ़ाइल आकार नहीं घटा सकते।

**क्या ForEach या Compress द्वारा किए गए परिवर्तन स्वतः सहेजे जाते हैं?**  
नहीं। ये सहायक लोड किए गए [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) ऑब्जेक्ट पर मेमोरी में काम करते हैं। [ForEach](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/foreach/) कॉलबैक में तत्व बदलने या [Compress](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compress/) चलाने के बाद, परिणाम लिखने के लिए [Presentation.save](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) को कॉल करें।

## **संबंधित लेख**

- [प्रेज़ेंटेशन परिवर्तित करना](/slides/hi/androidjava/convert-presentation/)
- [प्रेज़ेंटेशन मर्ज करना](/slides/hi/androidjava/merge-presentation/)
- [स्लाइड मास्टर](/slides/hi/androidjava/slide-master/)
- [टेक्स्ट बॉक्स प्रबंधन](/slides/hi/androidjava/manage-textbox/)
- [एम्बेडेड फ़ॉन्ट](/slides/hi/androidjava/embedded-font/)