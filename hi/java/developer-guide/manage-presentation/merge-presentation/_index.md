---
title: जावा में प्रस्तुतियों को कुशलतापूर्वक मर्ज करें
linktitle: प्रस्तुतियों को मर्ज करें
type: docs
weight: 40
url: /hi/java/merge-presentation/
keywords:
- PowerPoint मर्ज करें
- प्रस्तुतियों को मर्ज करें
- स्लाइड्स को मर्ज करें
- PPT मर्ज करें
- PPTX मर्ज करें
- ODP मर्ज करें
- PowerPoint को संयोजित करें
- प्रस्तुतियों को संयोजित करें
- स्लाइड्स को संयोजित करें
- PPT को संयोजित करें
- PPTX को संयोजित करें
- ODP को संयोजित करें
- Java
- Aspose.Slides
description: "जावा में स्लाइड्स को क्लोन करके, मास्टर और लेआउट को नियंत्रित करके, स्लाइड सामग्री का आकार बदलकर, सेक्शन संरक्षित करके, तथा संरक्षित या बड़ी फ़ाइलों को संभालते हुए PowerPoint और OpenDocument प्रस्तुतियों को कैसे मर्ज करें, जानें।"
---
## **अवलोकन**

Aspose.Slides for Java प्रस्तुतियों को एक [प्रेजेंटेशन](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) से दूसरी में स्लाइड क्लोन करके मर्ज करता है। मुख्य ऑपरेशन है [ISlideCollection.addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), जो स्रोत स्लाइड के फ़ॉर्मेटिंग को संरक्षित कर सकता है या क्लोन की गई स्लाइड को गन्तव्य प्रेजेंटेशन के मास्टर या लेआउट से जोड़ सकता है।

यह लेख सबसे सामान्य मर्जिंग वर्कफ़्लोज़ को कवर करता है:

- सभी स्लाइड्स का मर्ज करना और उनके स्रोत फ़ॉर्मेटिंग को संरक्षित रखना;
- चयनित स्लाइड्स का मर्ज करना;
- गन्तव्य प्रेजेंटेशन से एक मास्टर लागू करना;
- गन्तव्य प्रेजेंटेशन से एक विशिष्ट लेआउट लागू करना;
- मर्ज करने से पहले विभिन्न स्लाइड आकारों को सामान्य बनाना;
- क्लोन की गई स्लाइड्स को एक सेक्शन में जोड़ना;
- कई प्रस्तुतियों को एक अंत‑से‑अंत वर्कफ़्लो में मर्ज करना;
- मास्टर, रिसोर्सेज, नोट्स, कमेंट्स, मीडिया, फ़ॉन्ट्स, पासवर्ड, बड़े फ़ाइल, और मल्टीथ्रेडिंग संबंधी चिंताओं को संभालना।

## **स्लाइड क्लोनिंग का मास्टर और लेआउट पर प्रभाव**

एक स्लाइड अपनी उपस्थिति का अधिकांश भाग अपने लेआउट और मास्टर से विरासत में प्राप्त करती है। इसलिए, आप जिस क्लोन ओवरलोड को चुनते हैं, वह निर्धारित करता है कि मर्ज की गई स्लाइड गन्तव्य प्रेजेंटेशन में कैसे सम्मिलित की जाती है।

इनमें से किसी एक तरीके से [ISlideCollection.addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecollection/) का उपयोग करें:

- `addClone(sourceSlide)` — स्रोत स्लाइड के लेआउट और फ़ॉर्मेटिंग को संरक्षित रखें। आवश्यक होने पर, स्रोत मास्टर को स्वचालित रूप से गन्तव्य प्रेजेंटेशन में क्लोन किया जा सकता है। Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर को ट्रैक करता है ताकि समान स्रोत मास्टर का उपयोग करने वाली दोहराई गई स्लाइड्स लगातार क्लोन न हों।
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — क्लोन की गई स्लाइड को एक विशिष्ट गन्तव्य [IMasterSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterslide/) से जोड़ें। Aspose.Slides उस मास्टर के अंतर्गत लेआउट प्रकार या नाम से मेल खाने वाला लेआउट खोजता है।
- `addClone(sourceSlide, destinationLayout)` — क्लोन की गई स्लाइड को सीधे एक विशिष्ट गन्तव्य [ILayoutSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutslide/) से जोड़ें।

`addClone` ओवरलोड को पास किया गया मास्टर या लेआउट **गन्तव्य** प्रेजेंटेशन से संबंधित होना चाहिए, स्रोत प्रेजेंटेशन से नहीं।

## **पूरी प्रस्तुतियों को मर्ज करें और स्रोत फ़ॉर्मेटिंग को संरक्षित रखें**

सबसे सरल मर्ज स्रोत प्रस्तुतिएँ से प्रत्येक स्लाइड को गन्तव्य प्रस्तुति में कॉपी करता है। यह तब उपयुक्त विकल्प है जब आयातित स्लाइड्स को अपना मूल थीम, मास्टर, और लेआउट संबंध बनाए रखना चाहिए।

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

यदि स्रोत और गन्तव्य विभिन्न डिज़ाइनों का उपयोग करते हैं तो परिणामस्वरूप कई मास्टर हो सकते हैं। यह वही अपेक्षित है जब स्रोत फ़ॉर्मेटिंग जानबूझकर संरक्षित की जाती है।

## **चयनित स्लाइड्स को मर्ज करें**

आपको हर स्लाइड को क्लोन करने की आवश्यकता नहीं है। नीचे दिया गया उदाहरण स्रोत प्रस्तुतिएँ से केवल चयनित स्लाइड इंडेक्स को इम्पोर्ट करता है।

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    int[] slideIndexes = { 0, 2, 4 };

    for (int index : slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

उपयोगकर्ता इनपुट या बाहरी कॉन्फ़िगरेशन से आने वाले स्लाइड इंडेक्स को क्लोन करने से पहले वैधता जांचें।

## **गन्तव्य मास्टर का उपयोग करके स्लाइड्स को मर्ज करें**

जब आयातित स्लाइड्स को ऐसे मास्टर का पालन करना हो जो पहले से गन्तव्य प्रेजेंटेशन में मौजूद हो, तो [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) ओवरलोड का उपयोग करें।

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    IMasterSlide destinationMaster = destination.getMasters().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides निर्दिष्ट मास्टर के अंतर्गत स्रोत लेआउट के प्रकार या नाम से मेल खाने वाला उपयुक्त लेआउट चुनता है। यदि कोई उपयुक्त लेआउट नहीं मिलता और `allowCloneMissingLayout` **true** है, तो स्रोत लेआउट को क्लोन किया जाता है ताकि स्लाइड जोड़ी जा सके। यदि यह **false** है, तो एक [PptxEditException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pptxeditexception/) उत्पन्न किया जाता है।

जब आप चाहते हैं कि मर्ज विफल हो और गन्तव्य मास्टर में अतिरिक्त लेआउट न जोड़ा जाए, तब **false** का उपयोग करें।

## **गन्तव्य लेआउट का उपयोग करके स्लाइड्स को मर्ज करें**

जब आपको ठीक-ठीक पता हो कि आयातित स्लाइड्स को कौन सा गन्तव्य लेआउट उपयोग करना चाहिए, तो [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) ओवरलोड का उपयोग करें।

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ILayoutSlide destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

गन्तव्य लेआउट को लागू करने से विरासत में मिला लेआउट संबंध बदलता है; यह स्रोत स्लाइड सामग्री को पुनः डिज़ाइन नहीं करता। यदि स्रोत और गन्तव्य लेआउट की प्लेसहोल्डर संरचनाएँ अलग हैं, तो परिणाम की जांच करें ताकि विरासत में मिला फ़ॉर्मेटिंग और प्लेसहोल्डर व्यवहार उपयुक्त हो।

## **विभिन्न स्लाइड आकारों वाली प्रस्तुतियों को मर्ज करें**

विभिन्न स्लाइड आयाम वाली प्रस्तुतियों को मर्ज किया जा सकता है, लेकिन एक स्लाइड को दूसरे आकार की प्रस्तुति में क्लोन करने से उसकी सामग्री स्वतः नया कैनवस के लिये पुनः डिज़ाइन नहीं होती। इस कारण आकृतियाँ स्थान से हट सकती हैं, अप्रत्याशित रूप से स्केल हो सकती हैं, या दृश्य स्लाइड क्षेत्र के बाहर जा सकती हैं।

एक व्यावहारिक तरीका यह है कि क्लोन करने से पहले स्रोत प्रस्तुति का आकार बदलें। [SlideSize.setSize](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slidesize/#setSize-float-float-int-) मेथड मौजूदा सामग्री को स्केल करते हुए स्लाइड आयाम बदल सकता है। [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slidesizescaletype/) अनुरोधित आकार में सामग्री को फिट करने के लिये स्केल करता है।

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    Dimension2D sourceSize = source.getSlideSize().getSize();
    Dimension2D destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            (float) destinationSize.getWidth(), 
            (float) destinationSize.getHeight(), 
            SlideSizeScaleType.EnsureFit);
    }

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide);
    }

    destination.save("merged-same-slide-size.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

आकार बदलने से स्रोत प्रस्तुति ऑब्जेक्ट मेमोरी में बदलता है। यदि आप अन्य कार्यों के लिये मूल स्रोत प्रस्तुति को अपरिवर्तित रखना चाहते हैं, तो मर्ज के लिये एक अलग इंस्टेंस खोलें।

## **स्लाइड्स को प्रस्तुति सेक्शन में मर्ज करें**

बेसिक स्लाइड‑क्लोन लूप स्रोत प्रस्तुति की सेक्शन पदानुक्रम को पुनः नहीं बनाता। यदि आउटपुट में सेक्शन का महत्व है, तो गन्तव्य प्रस्तुति में सेक्शन बनाएं या चुनें और स्लाइड्स को स्पष्ट रूप से [addClone(ISlide, ISection)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) के साथ क्लोन करें।

```java
import com.aspose.slides.*;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    ISection importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (ISlide slide : source.getSlides()) {
        destination.getSlides().addClone(slide, importedSection);
    }

    destination.save("merged-with-section.pptx", SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

क्लोन की गई स्लाइड्स निर्दिष्ट गन्तव्य सेक्शन में जोड़ दी जाती हैं। कई स्रोत सेक्शन को संरक्षित करने के लिये, [Presentation.getSections](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getSections--) को एन्उमरेट करें, प्रत्येक स्रोत सेक्शन की वर्तमान स्लाइड्स को [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/isection/#getSlidesListOfSection--) से प्राप्त करें, गन्तव्य में सेक्शन पुनः बनाएं, और प्रत्येक प्राप्त स्लाइड को उसके संबंधित गन्तव्य सेक्शन में क्लोन करें। पूर्ण सेक्शन‑एन्उमरेशन उदाहरण के लिये देखें [Manage Slide Sections](/slides/hi/java/slide-section/) जिसमें खाली सेक्शन और संरचनात्मक परिवर्तन शामिल हैं।

## **एकाधिक प्रस्तुतियों को सुरक्षित रूप से मर्ज करें**

निचे दिया गया अंत‑से‑अंत उदाहरण पहली प्रस्तुति को गन्तव्य बनाकर, प्रत्येक अतिरिक्त स्रोत का स्लाइड आकार सामान्य करता है, प्रत्येक स्रोत को केवल कॉपी करने के दौरान खोलते रहता है, और अंतिम फ़ाइल को एक बार सेव करता है।

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    Dimension2D mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            Dimension2D sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    (float) mergedSize.getWidth(), 
                    (float) mergedSize.getHeight(), 
                    SlideSizeScaleType.EnsureFit);
            }

            for (ISlide slide : source.getSlides()) {
                merged.getSlides().addClone(slide);
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

यह आयातित स्लाइड्स की स्रोत फ़ॉर्मेटिंग को संरक्षित रखने के लिये एक उपयोगी बेसलाइन है। यदि आपका आउटपुट एक ही गन्तव्य थीम का उपयोग करना चाहिए, तो सरल `addClone(slide)` कॉल को पहले दिखाए गए उपयुक्त गन्तव्य‑मास्टर या गन्तव्य‑लेआउट ओवरलोड से बदलें।

## **व्यावहारिक विचार**

### **मास्टर, लेआउट, और फ़ॉर्मेटिंग फ़िडेलिटी**

डिफ़ॉल्ट स्लाइड क्लोनिंग स्वचालित रूप से आवश्यक स्रोत मास्टर को गन्तव्य प्रस्तुति में ला सकता है। Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर को दोहराव से बचाने हेतु एक अंतःस्थ रजिस्ट्री रखता है। मैन्युअली क्लोन किए गए मास्टर उस रजिस्ट्री में नहीं आते, इसलिए जब तक आपको मास्टर स्ट्रक्चर पर स्पष्ट नियंत्रण न चाहिए, तब तक पूर्व‑क्लोनिंग से बचें।

यह मानें नहीं कि समान नाम वाले दो मास्टर या लेआउट दृश्य रूप से समान हों। यदि कॉरपोरेट टेम्प्लेट अंतिम लुक को नियंत्रित करना है, तो स्पष्ट रूप से गन्तव्य मास्टर या लेआउट चुनें और मर्ज के बाद परिणाम की पुष्टि करें।

### **नोट्स और कमेंट्स**

स्पीकर नोट्स और स्लाइड कमेंट्स स्लाइड सामग्री से जुड़े होते हैं और स्लाइड क्लोनिंग पर कॉपी होते हैं। Aspose.Slides dedicated API भी प्रदान करता है जैसे [presentation notes](/slides/hi/java/presentation-notes/) और [presentation comments](/slides/hi/java/presentation-comments/)।

यदि नोट‑पेज फ़ॉर्मेटिंग महत्वपूर्ण है, तो मर्ज की गई प्रस्तुति की जाँच करें क्योंकि नोट्स‑मास्टर प्रस्तुति‑स्तर के ऑब्जेक्ट होते हैं और स्रोत फ़ाइलों के बीच अलग हो सकते हैं। समीक्षा वर्कफ़्लो में विभिन्न लेखकों या टेम्प्लेट्स से फ़ाइलें मिलाने के बाद कमेंट‑लेखकों और थ्रेडेड कमेंट्स की भी जाँच करें।

### **छवियाँ, ऑडियो, वीडियो, OLE ऑब्जेक्ट्स, और बाहरी लिंक**

स्लाइड्स प्रस्तुति‑स्तर के रिसोर्सेज जैसे छवियाँ, एम्बेडेड ऑडियो, एम्बेडेड वीडियो, और OLE डेटा का रेफ़र कर सकती हैं। केवल दृश्य आकृतियों को कॉपी करने के बजाय स्लाइड को स्वयं क्लोन करें ताकि Aspose.Slides रिसोर्सेज के संबंध को बनाए रख सके।

एम्बेडेड और लिंक्ड रिसोर्सेज को अलग‑अलग संभालें। एक लिंक्ड ऑडियो, वीडियो, OLE ऑब्जेक्ट, या हाइपरलिंक अभी भी अपने बाहरी टार्गेट पर निर्भर रहता है; स्लाइड क्लोन करने से बाहरी लिंक एम्बेडेड कंटेंट में नहीं बदलता। क्लोन किए गए प्रस्तुति को खोलने वाले वातावरण में लिंक्ड‑रिसोर्स पाथ्स और URL की जाँच करें।

Aspose.Slides स्वचालित क्लोन किए गए मास्टर को ट्रैक करता है, लेकिन इसे यह सामान्य गारंटी नहीं समझना चाहिए कि असंबंधित स्रोत प्रस्तुतियों से समान बाइनरी रिसोर्सेज हमेशा डिडुप्लिकेट हो जाएँ। यदि आउटपुट फ़ाइल आकार महत्त्वपूर्ण है, तो मर्ज किए गए पैकेज की जाँच करें और परिणाम को मापें बजाय implicit डिडुप्लीकेशन पर भरोसा किए।

### **एम्बेडेड फ़ॉन्ट्स और फ़ॉन्ट उपलब्धता**

फ़ॉन्ट्स प्रस्तुति‑स्तर पर प्रबंधित होते हैं। यदि टाइपोग्राफी को विभिन्न मशीनों पर सुसंगत रहना है, तो केवल स्लाइड क्लोनिंग यह गारंटी नहीं देती कि सभी आवश्यक फ़ॉन्ट्स गन्तव्य वातावरण में उपलब्ध हों। आप [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) के साथ एम्बेडेड फ़ॉन्ट्स की जाँच कर सकते हैं और [Embed Fonts in Presentations](/slides/hi/java/embedded-font/) में वर्णित अनुसार एम्बेडिंग को स्पष्ट रूप से प्रबंधित कर सकते हैं।

इसके अतिरिक्त सुनिश्चित करें कि आप स्रोत फ़ाइलों द्वारा उपयोग किए गए फ़ॉन्ट्स को एम्बेड करने की अनुमति रखते हैं। फ़ॉन्ट लाइसेंस एम्बेडिंग को प्रतिबंधित कर सकते हैं।

### **पासवर्ड‑प्रोटेक्टेड प्रस्तुतियाँ**

एक पासवर्ड‑प्रोटेक्टेड स्रोत को क्लोन करने से पहले सफलतापूर्वक खोलना आवश्यक है। पासवर्ड को [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) के माध्यम से प्रदान करें।

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // डिक्रिप्ट की गई प्रस्तुति के साथ काम करें.
} finally {
    source.dispose();
}
```

Encrypted स्रोत को खोलने से गन्तव्य प्रस्तुति पर वही सुरक्षा स्वयं लागू नहीं होती। आवश्यकता होने पर आउटपुट प्रोटेक्शन को अलग से कॉन्फ़िगर करें।

### **बड़ी प्रस्तुतियाँ और मेमोरी उपयोग**

उच्च‑रिज़ॉल्यूशन छवियों, ऑडियो, वीडियो, या अन्य बड़े बाइनरी ऑब्जेक्ट्स वाली बड़ी प्रस्तुतियों से महत्वपूर्ण मेमोरी की खपत हो सकती है। [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) BLOB प्रबंधन और अस्थायी‑फ़ाइल उपयोग पर नियंत्रण प्रदान करता है। बड़े‑फ़ाइल रणनीतियों के लिये देखें [Manage Presentation BLOBs](/slides/hi/java/manage-blob/)।

बड़ी फ़ाइलों के लिये संभव हो तो फ़ाइल पाथ से लोड करें, प्रत्येक स्रोत प्रस्तुति को मर्ज के बाद तुरंत dispose करें, और यदि वर्कफ़्लो में checkpoints आवश्यक न हों तो इंटरमीडिएट सेविंग से बचें।

### **थ्रेड सुरक्षा**

एक ही [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) इंस्टेंस को कई थ्रेड्स से समानांतर रूप से लोड, मॉडिफ़ाय, सेव, या क्लोन न करें। प्रत्येक प्रस्तुति इंस्टेंस को एक मर्ज ऑपरेशन तक सीमित रखें। यदि आप स्वतंत्र जॉब्स को पैरालेलाइज़ करते हैं, तो स्वतंत्र प्रस्तुति इंस्टेंस का उपयोग करें और [Aspose.Slides मल्टीथ्रेडिंग गाइडेंस](/slides/hi/java/multithreading/) का पालन करें।

## **FAQ**

**मैं प्रत्येक स्रोत प्रस्तुति की मूल डिज़ाइन कैसे बनाए रखूँ?**

[addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) का उपयोग करें बिना गन्तव्य मास्टर या लेआउट प्रदान किए। Aspose.Slides आयातित स्लाइड द्वारा आवश्यक होने पर स्वचालित रूप से स्रोत मास्टर को क्लोन कर सकता है।

**मैं आयातित स्लाइड्स को गन्तव्य थीम का उपयोग कैसे करवाऊँ?**

ऐसे ओवरलोड का उपयोग करें जो गन्तव्य मास्टर स्वीकार करता है। गन्तव्य प्रस्तुति से एक मास्टर पास करें, स्रोत से नहीं। Aspose.Slides प्रत्येक स्रोत स्लाइड को उस मास्टर के अंतर्गत उपयुक्त लेआउट से मैप करने की कोशिश करेगा।

**किस स्थिति में गन्तव्य लैआउट उपयोग करना चाहिए, न कि गन्तव्य मास्टर?**

जब प्रत्येक आयातित स्लाइड को एक ज्ञात लेआउट का उपयोग करना हो, तो विशिष्ट लेआउट का उपयोग करें। जब आप चाहते हैं कि Aspose.Slides स्रोत लेआउट प्रकार या नाम के आधार पर उस मास्टर के विभिन्न लेआउट में से चुनें, तो मास्टर का उपयोग करें।

**क्या विभिन्न स्लाइड आकारों वाली प्रस्तुतियों को मर्ज किया जा सकता है?**

हाँ, लेकिन स्लाइड कंटेंट गन्तव्य आयाम के लिये स्वतः पुनः डिज़ाइन नहीं होता। जब पूर्वानुमित प्लेसमेंट चाहिए, तो पहले [SlideSize.setSize](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slidesize/#setSize-float-float-int-) और [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slidesizescaletype/) के साथ स्रोत प्रस्तुति को री‑साइज़ करें।

**क्या मैं PPT, PPTX, और ODP प्रस्तुतियों को एक फ़ाइल में मर्ज कर सकता हूँ?**

हाँ। प्रत्येक स्रोत प्रस्तुति को लोड करें, आवश्यक स्लाइड्स को एक ही गन्तव्य में क्लोन करें, और गन्तव्य को समर्थित आउटपुट फ़ॉर्मेट में सेव करें। चूँकि प्रस्तुति फ़ॉर्मेट्स में फीचर सेट समान नहीं होता, क्रॉस‑फ़ॉर्मेट मर्ज के बाद जटिल कंटेंट की जाँच करें। देखें [Supported File Formats](/slides/hi/java/supported-file-formats/)।

**क्या स्रोत सेक्शन स्वचालित रूप से संरक्षित होते हैं?**

सिर्फ स्लाइड क्लोन करने वाले बेसिक लूप से नहीं। गन्तव्य में आवश्यक सेक्शन को पुनः बनाएं और सेक्शन संरचना को संरक्षित रखने हेतु [addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) के सेक्शन ओवरलोड का उपयोग करें।

**क्या स्पीकर नोट्स और कमेंट्स संरक्षित रहते हैं?**

वे क्लोन की गई स्लाइड के साथ कॉपी होते हैं। नोट‑मास्टर स्टाइलिंग, कमेंट‑लेखकों, या थ्रेडेड रिव्यू डेटा पर निर्भर वर्कफ़्लो के लिये, मर्ज परिणाम की पुष्टि करें क्योंकि ये परिदृश्य प्रस्तुति‑स्तर संरचनाओं के साथ-साथ स्लाइड‑स्तर कंटेंट को भी प्रभावित करते हैं।

**ऑडियो, वीडियो, OLE ऑब्जेक्ट्स, और हाइपरलिंक का क्या होता है?**

एम्बेडेड कंटेंट क्लोन की गई स्लाइड के रिसोर्स रिलेशनशिप के भाग के रूप में ले जाया जाता है। बाहरी लिंक अभी भी बाहरी रहते हैं, इसलिए उनके टार्गेट फ़ाइलें या URL मर्ज के बाद उपलब्ध होने चाहिए।

**क्या सभी स्रोतों से एम्बेडेड फ़ॉन्ट्स मर्ज्ड प्रस्तुति में उपलब्ध होंगे?**

केवल स्लाइड क्लोनिंग पर फ़ॉन्ट डिप्लॉयमेंट के लिये निर्भर न रहें। गन्तव्य की एम्बेडेड फ़ॉन्ट्स की जाँच करें और फ़ॉन्ट एम्बेडिंग या बाहरी फ़ॉन्ट उपलब्धता को स्पष्ट रूप से प्रबंधित करें जब टाइपोग्राफी महत्त्वपूर्ण हो।

**मैं पासवर्ड‑प्रोटेक्टेड फ़ाइल को कैसे मर्ज करूँ?**

सही [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) के साथ इसे खोलें, फिर उसके स्लाइड्स को सामान्य रूप से क्लोन करें। आउटपुट प्रोटेक्शन को अलग से कॉन्फ़िगर किया जाता है।

**बड़ी प्रस्तुतियों को मैं कैसे संभालूँ?**

जब बड़े बाइनरी ऑब्जेक्ट्स मेमोरी उपयोग को प्रभावित करते हैं, तो BLOB मैनेजमेंट का उपयोग करें, बहुत बड़ी फ़ाइलों के लिये फ़ाइल‑पाथ लोडिंग को प्राथमिकता दें, स्रोत प्रस्तुतियों को मर्ज के बाद शीघ्र डिस्पोज़ करें, और यदि वर्कफ़्लो आवश्यक न हो तो मध्यवर्ती सेविंग से बचें।

**क्या मैं कई थ्रेड्स से स्लाइड्स को मर्ज कर सकता हूँ?**

एक ही [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) इंस्टेंस को कई थ्रेड्स से समानांतर रूप से लोड, मॉडिफ़ाय, सेव, या क्लोन न करें। प्रत्येक मर्ज ऑपरेशन को अलग‑अलग प्रस्तुति इंस्टेंस तक सीमित रखें। स्वतंत्र जॉब्स को पैरालेलाइज़ करने के लिये स्वतंत्र इंस्टेंस का उपयोग करें और [Aspose.Slides मल्टीथ्रेडिंग गाइडेंस](/slides/hi/java/multithreading/) का पालन करें।