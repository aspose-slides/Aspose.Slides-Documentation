---
title: जावास्क्रिप्ट में प्रस्तुतियों को कुशलता से मर्ज करें
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
description: "जावास्क्रिप्ट में स्लाइड्स को क्लोन करके, मास्टर और लेआउट को नियंत्रित करके, स्लाइड सामग्री का आकार बदलकर, सेक्शन को संरक्षित करके, और संरक्षित या बड़ी फ़ाइलों को संभालते हुए PowerPoint और OpenDocument प्रस्तुतियों को कैसे मर्ज करें, सीखें।"
---
## **अवलोकन**

Aspose.Slides for Node.js via Java प्रस्तुतियों को एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) से दूसरी में स्लाइड्स को क्लोन करके मर्ज करता है। मुख्य ऑपरेशन है [SlideCollection.addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-), जो स्रोत स्लाइड की फॉर्मेटिंग को बनाए रख सकता है या क्लोन की गई स्लाइड को लक्ष्य प्रस्तुति में एक मास्टर या लेआउट से संलग्न कर सकता है।

यह लेख सबसे सामान्य मर्ज वर्कफ़्लो को कवर करता है:

- सभी स्लाइड्स को उनके स्रोत फॉर्मेटिंग को संरक्षित रखते हुए मर्ज करें;
- चयनित स्लाइड्स को मर्ज करें;
- लक्ष्य प्रस्तुति से एक मास्टर लागू करें;
- लक्ष्य प्रस्तुति से एक विशिष्ट लेआउट लागू करें;
- मर्ज करने से पहले विभिन्न स्लाइड आकारों को सामान्यीकृत करें;
- क्लोन की गई स्लाइड्स को एक सेक्शन में जोड़ें;
- कई प्रस्तुतियों को एक संपूर्ण कार्यप्रवाह में मर्ज करें;
- मास्टर, संसाधन, नोट्स, टिप्पणियां, मीडिया, फॉन्ट, पासवर्ड, बड़े फाइलें और मल्टीथ्रेडिंग मामलों को संभालें।

## **स्लाइड क्लोनिंग का मास्टर और लेआउट पर प्रभाव**

एक स्लाइड अपनी उपस्थिति का अधिकांश भाग अपने लेआउट और मास्टर से विरासत में लेती है। इस कारण, आप जो क्लोनिंग ओवरलोड चुनते हैं, वह निर्धारित करता है कि मर्ज की गई स्लाइड को लक्ष्य प्रस्तुति में कैसे एकीकृत किया जाएगा।

इनमें से किसी एक तरीके से [SlideCollection.addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidecollection/) का उपयोग करें:

- `addClone(sourceSlide)` — स्रोत स्लाइड के लेआउट और फॉर्मेटिंग को संरक्षित रखें। आवश्यकता पड़ने पर, स्रोत मास्टर को लक्ष्य प्रस्तुति में स्वतः क्लोन किया जा सकता है। Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर को ट्रैक करता है ताकि समान स्रोत मास्टर वाले दोहराव वाली स्लाइड्स के लिए वह मास्टर कई बार क्लोन न हो।
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — क्लोन की गई स्लाइड को एक विशिष्ट लक्ष्य [MasterSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslide/) से संलग्न करें। Aspose.Slides उस मास्टर के अंतर्गत लेआउट प्रकार या नाम से मिलते‑जुलते लेआउट की तलाश करता है।
- `addClone(sourceSlide, destinationLayout)` — क्लोन की गई स्लाइड को सीधे एक विशिष्ट लक्ष्य [LayoutSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslide/) से संलग्न करें।

`addClone` ओवरलोड को पास किया गया मास्टर या लेआउट **लक्ष्य** प्रस्तुति से संबंधित होना चाहिए, स्रोत प्रस्तुति से नहीं।

## **सभी प्रस्तुतियों को मर्ज करें और स्रोत फॉर्मेटिंग को संरक्षित रखें**

सबसे सरल मर्ज स्रोत प्रस्तुति से प्रत्येक स्लाइड को लक्ष्य प्रस्तुति में कॉपी करता है। यह तब उपयुक्त विकल्प है जब आयातित स्लाइड्स को उनका मूल थीम, मास्टर और लेआउट संबंध बनाए रखना चाहिए।

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

परिणामी प्रस्तुति में कई मास्टर हो सकते हैं जब स्रोत और लक्ष्य अलग‑अलग डिज़ाइन उपयोग कर रहे हों। यह अपेक्षित है जब स्रोत फॉर्मेटिंग जानबूझकर संरक्षित की गई हो।

## **चयनित स्लाइड्स को मर्ज करें**

आपको हर स्लाइड को क्लोन करने की आवश्यकता नहीं है। निम्न उदाहरण केवल स्रोत प्रस्तुति से चयनित स्लाइड इंडेक्स को आयात करता है।

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const slideIndexes = [0, 2, 4];

    for (const index of slideIndexes) {
        destination.getSlides().addClone(source.getSlides().get_Item(index));
    }

    destination.save("merged-selected-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

उपयोगकर्ता इनपुट या बाहरी कॉन्फ़िगरेशन से आने पर क्लोन करने से पहले स्लाइड इंडेक्स की वैधता जांचें।

## **लक्षित मास्टर का उपयोग करके स्लाइड्स को मर्ज करें**

जब आयातित स्लाइड्स को लक्ष्य प्रस्तुति के पहले से मौजूद मास्टर का पालन करना हो, तो [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) ओवरलोड का उपयोग करें।

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationMaster = destination.getMasters().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationMaster, true);
    }

    destination.save("merged-with-destination-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

Aspose.Slides निर्दिष्ट मास्टर के तहत उपयुक्त लेआउट को स्रोत लेआउट के प्रकार या नाम से मिलाकर चुनता है। यदि उपयुक्त लेआउट मौजूद नहीं है और `allowCloneMissingLayout` `true` है, तो स्रोत लेआउट को क्लोन किया जाता है ताकि स्लाइड जोड़ सकें। यदि यह `false` है, तो एक [PptxEditException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pptxeditexception/) फेंका जाता है।

जब आप मर्ज को विफल करना चाहते हैं बजाय लक्ष्य मास्टर में अतिरिक्त लेआउट जोड़ने के, तो `false` का उपयोग करें।

## **विशिष्ट लक्ष्य लेआउट का उपयोग करके स्लाइड्स को मर्ज करें**

जब आप जानते हैं कि आयातित स्लाइड्स को कौन सा लक्ष्य लेआउट उपयोग करना चाहिए, तो [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) ओवरलोड का उपयोग करें।

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const destinationLayout = destination.getLayoutSlides().get_Item(0);

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), destinationLayout);
    }

    destination.save("merged-with-destination-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

लक्ष्य लेआउट लागू करने से विरासत में मिला लेआउट संबंध बदलता है; यह स्रोत स्लाइड की सामग्री को पुनः डिजाइन नहीं करता। यदि स्रोत और लक्ष्य लेआउट की प्लेसहोल्डर संरचनाएँ अलग हैं, तो परिणाम का निरीक्षण करें ताकि विरासत में मिली फ़ॉर्मेटिंग और प्लेसहोल्डर व्यवहार उपयुक्त हों यह पुष्टि हो सके।

## **विभिन्न स्लाइड आकार वाली प्रस्तुतियों को मर्ज करें**

विभिन्न स्लाइड आयाम वाली प्रस्तुतियों को मर्ज किया जा सकता है, लेकिन किसी प्रस्तुति में दूसरे आकार की स्लाइड में क्लोन करने से सामग्री स्वचालित रूप से नई कैनवास के लिए पुनः डिज़ाइन नहीं होती। इसलिए आकार‑समायोजित शैलियों के कारण शैप्स शिफ्ट, स्केल या स्लाइड के दृश्य क्षेत्र से बाहर हो सकते हैं।

व्यावहारिक तरीका यह है कि क्लोन करने से पहले स्रोत प्रस्तुति का आकार बदलें। [SlideSize.setSize](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) मेथड मौजूदा सामग्री को स्केल कर सकता है जबकि स्लाइड आयाम बदलता है। [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidesizescaletype/) सामग्री को अनुरोधित आकार में फिट करता है।

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const sourceSize = source.getSlideSize().getSize();
    const destinationSize = destination.getSlideSize().getSize();
    const sizesDiffer = sourceSize.getWidth() !== destinationSize.getWidth() || 
                        sourceSize.getHeight() !== destinationSize.getHeight();

    if (sizesDiffer) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
            aspose.slides.SlideSizeScaleType.EnsureFit);
    }

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i));
    }

    destination.save("merged-same-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

आकार बदलने से स्रोत प्रस्तुति मेमोरी में बदली हुई रहती है। यदि आप मूल स्रोत प्रस्तुति को अन्य कार्यों के लिए अपरिवर्तित रखना चाहते हैं, तो मर्ज के लिए अलग इंस्टेंस खोलें।

## **स्लाइड्स को प्रस्तुति सेक्शन में मर्ज करें**

बेसिक स्लाइड‑क्लोनिंग लूप स्रोत प्रस्तुति की सेक्शन पदानुक्रम को पुनः नहीं बनाता। यदि आउटपुट में सेक्शन मायने रखते हैं, तो लक्ष्य प्रस्तुति में सेक्शन बनाएं या चुनें और स्लाइड्स को स्पष्ट रूप से [addClone(Slide, Section)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) के साथ उन में क्लोन करें।

```javascript
const aspose = require("aspose.slides.via.java");

const destination = new aspose.slides.Presentation("destination.pptx");
const source = new aspose.slides.Presentation("source.pptx");
try {
    const importedSection = destination.getSections().appendEmptySection("Imported slides");

    for (let i = 0; i < source.getSlides().size(); i++) {
        destination.getSlides().addClone(source.getSlides().get_Item(i), importedSection);
    }

    destination.save("merged-with-section.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    source.dispose();
    destination.dispose();
}
```

क्लोन की गई स्लाइड्स निर्दिष्ट लक्ष्य सेक्शन में जोड़ दी जाती हैं। कई स्रोत सेक्शन को संरक्षित करने के लिए, [Presentation.getSections](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getSections) को एनेमरेट करें, प्रत्येक स्रोत सेक्शन की मौजूदा स्लाइड्स को [Section.getSlidesListOfSection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/section/#getSlidesListOfSection) से प्राप्त करें, लक्ष्य में सेक्शन पुनः बनाएं, और प्रत्येक प्राप्त स्लाइड को उसके संबंधित लक्ष्य सेक्शन में क्लोन करें। पूर्ण सेक्शन‑एनेमरेशन उदाहरण के लिए [Manage Slide Sections](/slides/hi/nodejs-java/slide-section/) देखें, जिसमें खाली सेक्शन और संरचनात्मक बदलाव शामिल हैं।

## **कई प्रस्तुतियों को सुरक्षित रूप से मर्ज करें**

निम्न संपूर्ण उदाहरण पहला प्रस्तुति को लक्ष्य बनाता है, प्रत्येक अतिरिक्त स्रोत का स्लाइड आकार सामान्यीकृत करता है, प्रत्येक स्रोत को केवल तब खुला रखता है जब वह कॉपी हो रहा हो, और अंत में फ़ाइल को एक बार सहेजता है।

```javascript
const aspose = require("aspose.slides.via.java");

const inputFiles = ["part1.pptx", "part2.pptx", "part3.pptx"];

const merged = new aspose.slides.Presentation(inputFiles[0]);
try {
    const mergedSize = merged.getSlideSize().getSize();

    for (let fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        const source = new aspose.slides.Presentation(inputFiles[fileIndex]);
        try {
            const sourceSize = source.getSlideSize().getSize();
            const sizesDiffer = sourceSize.getWidth() !== mergedSize.getWidth() || 
                                sourceSize.getHeight() !== mergedSize.getHeight();

            if (sizesDiffer) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
                    aspose.slides.SlideSizeScaleType.EnsureFit);
            }

            for (let slideIndex = 0; slideIndex < source.getSlides().size(); slideIndex++) {
                merged.getSlides().addClone(source.getSlides().get_Item(slideIndex));
            }
        } finally {
            source.dispose();
        }
    }

    merged.save("merged.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    merged.dispose();
}
```

यह आयातित स्लाइड्स की स्रोत फ़ॉर्मेटिंग को संरक्षित करने के लिए एक उपयोगी बेंचमार्क है। यदि आपका आउटपुट एक ही लक्ष्य थीम उपयोग करना चाहिए, तो सरल `addClone(sourceSlide)` कॉल को पहले दिखाए गए उपयुक्त लक्ष्य‑मास्टर या लक्ष्य‑लेआउट ओवरलोड से बदलें।

## **व्यावहारिक विचार**

### **मास्टर, लेआउट और फ़ॉर्मेटिंग की शुद्धता**

डिफ़ॉल्ट स्लाइड क्लोनिंग आवश्यक स्रोत मास्टर को लक्ष्य प्रस्तुति में स्वतः लाना संभव बनाता है। Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर को दर्ज करता है ताकि समान मास्टर की दोहराव वाली क्लोनिंग से बचा जा सके। मैन्युअली क्लोन किए गए मास्टर इस रजिस्ट्री में नहीं आते, इसलिए जब तक आप मास्टर संरचना पर स्पष्ट नियंत्रण नहीं चाहते तब तक पूर्व‑क्लोनिंग से बचें।

दो मास्टर या लेआउट जिनका नाम समान है, यह मान लेना सही नहीं है कि वे दृश्य रूप से समान होंगे। यदि कोई कॉरपोरेट टेम्पलेट अंतिम रूप को नियंत्रित करता है, तो स्पष्ट रूप से लक्ष्य मास्टर या लेआउट चुनें और मर्ज के बाद परिणाम सत्यापित करें।

### **नोट्स और टिप्पणियां**

स्पीकर नोट्स और स्लाइड टिप्पणियां स्लाइड सामग्री से जुड़ी होती हैं और स्लाइड क्लोन होने पर कॉपी होती हैं। Aspose.Slides [presentation notes](/slides/hi/nodejs-java/presentation-notes/) और [presentation comments](/slides/hi/nodejs-java/presentation-comments/) के लिए समर्पित API भी प्रदान करता है।

यदि नोट‑पेज फ़ॉर्मेटिंग महत्वपूर्ण है, तो मर्ज किए गए प्रस्तुति की जाँच करें क्योंकि नोट‑मास्टर प्रस्तुति‑स्तरीय ऑब्जेक्ट होते हैं और स्रोत फ़ाइलों में अलग हो सकते हैं। समीक्षा वर्कफ़्लो के लिए विभिन्न लेखकों या टेम्पलेट्स से फ़ाइलें मिलाने के बाद टिप्पणी लेखक और थ्रेडेड टिप्पणियों की पुष्टि भी करें।

### **इमेजेज, ऑडियो, वीडियो, OLE ऑब्जेक्ट्स और बाहरी लिंक**

स्लाइड्स प्रस्तुति‑स्तरीय संसाधनों जैसे इमेजेज, एम्बेडेड ऑडियो, एम्बेडेड वीडियो, और OLE डेटा को संदर्भित कर सकती हैं। केवल दृश्यमान शैप्स को कॉपी करने के बजाय स्लाइड स्वयं को क्लोन करें ताकि Aspose.Slides उसके संसाधनों के संबंध बनाए रख सके।

एम्बेडेड और लिंक्ड संसाधनों को अलग‑अलग संभालें। लिंक्ड ऑडियो, वीडियो, OLE ऑब्जेक्ट या हाइपरलिंक अपने बाहरी लक्ष्य पर निर्भर रहता है; स्लाइड को क्लोन करने से बाहरी लिंक एम्बेडेड कंटेंट में नहीं बदलता। मर्ज किए गए प्रस्तुति को खोलने वाले पर्यावरण में लिंक्ड‑रिसोर्स पाथ और URL की जाँच करें।

Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर को ट्रैक करता है, लेकिन यह सामान्य गारंटी नहीं है कि अलग‑अलग स्रोत प्रस्तुतियों से समान बाइनरी संसाधन हमेशा डिडुप्लीकेट हो जाएंगे। यदि आउटपुट फ़ाइल आकार महत्वपूर्ण है, तो मर्ज पैकेज की जाँच करके परिणाम मापें, न कि केवल स्वचालित डिडुप्लीकेशन पर भरोसा करें।

### **एम्बेडेड फॉन्ट और फ़ॉन्ट उपलब्धता**

फ़ॉन्ट प्रस्तुति‑स्तर पर प्रबंधित होते हैं। यदि टाइपोग्राफी को मशीनों के बीच स्थिर रहना चाहिए, तो केवल स्लाइड क्लोनिंग यह गारंटी नहीं देती कि आवश्यक सभी फ़ॉन्ट लक्ष्य वातावरण में उपलब्ध हों। आप [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) से एम्बेडेड फ़ॉन्ट देख सकते हैं और [Embed Fonts in Presentations](/slides/hi/nodejs-java/embedded-font/) में वर्णित अनुसार एम्बेडिंग को स्पष्ट रूप से संभाल सकते हैं।

साथ ही यह सुनिश्चित करें कि आप स्रोत फ़ाइलों में प्रयुक्त फ़ॉन्ट को एम्बेड करने के लिए अनुमति रखते हैं। फ़ॉन्ट लाइसेंस एम्बेडिंग को प्रतिबंधित कर सकते हैं।

### **पासवर्ड‑प्रोटेक्टेड प्रस्तुतियाँ**

पासवर्ड‑संरक्षित स्रोत को उसके स्लाइड्स को क्लोन करने से पहले सफलतापूर्वक खोलना आवश्यक है। पासवर्ड को [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setPassword-String-) के माध्यम से प्रदान करें।

```javascript
const aspose = require("aspose.slides.via.java");

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

const source = new aspose.slides.Presentation("protected.pptx", loadOptions);
try {
    // डिक्रिप्टेड प्रस्तुति के साथ काम करें।
} finally {
    source.dispose();
}
```

एन्क्रिप्टेड स्रोत को खोलना स्वचालित रूप से लक्ष्य प्रस्तुति पर वही सुरक्षा लागू नहीं करता। जब आवश्यक हो तो आउटपुट सुरक्षा को अलग से कॉन्फ़िगर करें।

### **बड़ी प्रस्तुतियों और मेमोरी उपयोग**

उच्च‑रिज़ॉल्यूशन इमेजेज, ऑडियो, वीडियो या अन्य बड़े बाइनरी ऑब्जेक्ट वाली बड़ी प्रस्तुतियां महत्वपूर्ण मेमोरी खपत कर सकती हैं। [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) BLOB हैंडलिंग और टेम्परेरी‑फ़ाइल उपयोग के लिए नियंत्रण प्रदान करता है। बड़े‑फ़ाइल रणनीतियों के लिए देखें [Manage Presentation BLOBs](/slides/hi/nodejs-java/manage-blob/)।

बड़ी फ़ाइलों के लिए संभव हो तो फ़ाइल पाथ से लोड करें, प्रत्येक स्रोत प्रस्तुति को मर्ज हो जाने पर तुरंत डिस्पोज़ करें, और मध्यवर्ती परिणामों को बार‑बार सहेजने से बचें जब तक कि वर्कफ़्लो में चेकपॉइंट की आवश्यकता न हो।

### **थ्रेड सुरक्षा**

एक [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) इंस्टेंस को कई थ्रेड में लोड, सेव या क्लोन न करें। ये ऑपरेशन मल्टीथ्रेडेड उपयोग के लिए समर्थित नहीं हैं। यदि आपको स्वतंत्र मर्ज जॉब्स को समानांतर करना है, तो कई सिंगल‑थ्रेडेड प्रोसेस का उपयोग करें, प्रत्येक के पास अपना प्रस्तुति इंस्टेंस हो, और [Aspose.Slides मल्टीथ्रेडिंग गाइडेंस](/slides/hi/nodejs-java/multithreading/) का पालन करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रत्येक स्रोत प्रस्तुति के मूल डिज़ाइन को कैसे बनाए रखूँ?**

गंतव्य मास्टर या लेआउट प्रदान किए बिना सीधे [addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-) का उपयोग करें। Aspose.Slides आयातित स्लाइड के लिए आवश्यक होने पर स्रोत मास्टर को स्वतः क्लोन कर सकता है।

**मैं आयातित स्लाइड्स को लक्ष्य थीम का उपयोग कैसे करूँ?**

ऐसा ओवरलोड उपयोग करें जो लक्ष्य मास्टर स्वीकार करता है। लक्ष्य प्रस्तुति से एक मास्टर पास करें, स्रोत से नहीं। Aspose.Slides प्रत्येक स्रोत स्लाइड को उस मास्टर के तहत उपयुक्त लेआउट से मैप करने का प्रयास करेगा।

**कब मुझे लक्ष्य लेआउट का उपयोग लक्ष्य मास्टर के बजाय करना चाहिए?**

जब हर आयातित स्लाइड को एक ज्ञात लेआउट प्रयोग करना हो, तब विशिष्ट लेआउट उपयोग करें। जब आप चाहते हैं कि Aspose.Slides स्रोत लेआउट प्रकार या नाम के आधार पर उस मास्टर के लेआउट में से चयन करे, तब मास्टर उपयोग करें।

**क्या विभिन्न स्लाइड आकार वाली प्रस्तुतियों को मर्ज किया जा सकता है?**

हाँ, लेकिन स्लाइड सामग्री स्वचालित रूप से लक्ष्य आयामों के अनुसार पुनः डिज़ाइन नहीं होती। पूर्व‑आकार‑परिवर्तन की आवश्यकता होने पर [SlideSize.setSize](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) और [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidesizescaletype/) का उपयोग करें।

**क्या मैं PPT, PPTX और ODP प्रस्तुतियों को एक फ़ाइल में मर्ज कर सकता हूँ?**

हाँ। प्रत्येक स्रोत प्रस्तुति लोड करें, आवश्यक स्लाइड्स को एक लक्ष्य में क्लोन करें, और लक्ष्य को समर्थित आउटपुट फ़ॉर्मेट में सहेजें। चूंकि प्रस्तुतियों के फ़ॉर्मेट पूरी तरह समान फीचर सेट नहीं रखते, क्रॉस‑फ़ॉर्मेट मर्ज के बाद जटिल सामग्री को सत्यापित करें। देखें [Supported File Formats](/slides/hi/nodejs-java/supported-file-formats/)।

**क्या स्रोत सेक्शन स्वचालित रूप से संरक्षित होते हैं?**

नहीं, केवल स्लाइड क्लोन करने वाले बेसिक लूप से नहीं। लक्ष्य में आवश्यक सेक्शन पुनः बनाएँ और सेक्शन ओवरलोड वाले [addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) का उपयोग करें जब सेक्शन संरचना को संरक्षित करना हो।

**क्या स्पीकर नोट्स और टिप्पणियां संरक्षित रहती हैं?**

वे क्लोन की गई स्लाइड के साथ कॉपी हो जाती हैं। नोट‑मास्टर स्टाइलिंग, टिप्पणी लेखक या थ्रेडेड रिव्यू डेटा पर निर्भर वर्कफ़्लो के लिए, मर्ज परिणाम को सत्यापित करें क्योंकि ये एक‑से‑ज़्यादा प्रस्तुति‑स्तरीय संरचनाओं को शामिल करते हैं।

**ऑडियो, वीडियो, OLE ऑब्जेक्ट और हाइपरलिंक के साथ क्या होता है?**

एम्बेडेड कंटेंट क्लोन की गई स्लाइड के संसाधन संबंधों के भाग के रूप में ले जाया जाता है। बाहरी लिंक बाहरी ही रहते हैं, इसलिए मर्ज के बाद उनके लक्ष्य फ़ाइल या URL उपलब्ध होने चाहिए।

**क्या हर स्रोत से एम्बेडेड फ़ॉन्ट्स मर्ज किए गए प्रस्तुति में उपलब्ध रहेंगे?**

स्लाइड क्लोनिंग केवल फ़ॉन्ट वितरण की गारंटी नहीं देता। लक्ष्य में एम्बेडेड फ़ॉन्ट की जाँच करें और जब टाइपोग्राफी महत्वपूर्ण हो तो फ़ॉन्ट एम्बेडिंग या बाहरी फ़ॉन्ट उपलब्धता को स्पष्ट रूप से प्रबंधित करें।

**मैं पासवर्ड‑संरक्षित फ़ाइल को कैसे मर्ज करूँ?**

सही [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setPassword-String-) के साथ इसे खोलें, फिर सामान्य रूप से स्लाइड्स को क्लोन करें। आउटपुट संरक्षण को अलग से कॉन्फ़िगर करें।

**बड़ी प्रस्तुतियों को कैसे संभालूँ?**

बड़े बाइनरी ऑब्जेक्ट्स के कारण मेमोरी उपयोग होने पर BLOB प्रबंधन का उपयोग करें, बहुत बड़ी फ़ाइलों के लिए फ़ाइल‑पाथ लोडिंग को प्राथमिकता दें, स्रोत प्रस्तुतियों को तुरंत डिस्पोज़ करें, और अंतिम परिणाम को केवल आवश्यक होने पर सहेजें।

**क्या मैं कई थ्रेड से स्लाइड्स को मर्ज कर सकता हूँ?**

एक ही प्रस्तुति इंस्टेंस को कई थ्रेड में लोड, सेव या क्लोन न करें। समानांतर मर्ज जॉब्स के लिए अलग‑अलग सिंगल‑थ्रेडेड प्रोसेस और स्वतंत्र प्रस्तुति इंस्टेंस का उपयोग करें।