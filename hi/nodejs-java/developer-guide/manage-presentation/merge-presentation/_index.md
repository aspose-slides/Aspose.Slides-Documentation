---
title: जावास्क्रिप्ट में प्रस्तुतियों को कुशलतापूर्वक मर्ज करें
linktitle: प्रस्तुतियों को मर्ज करें
type: docs
weight: 40
url: /hi/nodejs-java/merge-presentation/
keywords:
- PowerPoint मर्ज करें
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
description: "जावास्क्रिप्ट में स्लाइड्स को क्लोन करके, मास्टर और लेआउट को नियंत्रित करके, स्लाइड सामग्री का आकार बदलकर, सेक्शनों को संरक्षित करके, तथा सुरक्षित या बड़ी फ़ाइलों को संभालते हुए PowerPoint और OpenDocument प्रस्तुतियों को कैसे मर्ज करें, सीखें।"
---
## **अवलोकन**

Aspose.Slides for Node.js via Java एक प्रस्तुति से दूसरी में स्लाइड्स को क्लोन करके प्रस्तुतियों को मिलाता है। मुख्य ऑपरेशन है [SlideCollection.addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-), जिससे स्रोत स्लाइड का फ़ॉर्मेटिंग संरक्षित किया जा सकता है या क्लोन की गई स्लाइड को गंतव्य प्रस्तुति के मास्टर या लेआउट पर संलग्न किया जा सकता है।

यह लेख सबसे सामान्य मर्जिंग वर्कफ़्लो को कवर करता है:

- सभी स्लाइड्स को उनके स्रोत फ़ॉर्मेटिंग को बरकरार रखते हुए मर्ज करें;
- चयनित स्लाइड्स को मर्ज करें;
- गंतव्य प्रस्तुति के मास्टर को लागू करें;
- गंतव्य प्रस्तुति से विशिष्ट लेआउट लागू करें;
- मर्ज करने से पहले विभिन्न स्लाइड आकारों को सामान्यीकृत करें;
- क्लोन की गई स्लाइड्स को एक सेक्शन में जोड़ें;
- एक अंत‑से‑अंत वर्कफ़्लो में कई प्रस्तुतियों को मर्ज करें;
- मास्टर, संसाधन, नोट्स, टिप्पणियाँ, मीडिया, फ़ॉन्ट्स, पासवर्ड, बड़े फ़ाइलें और मल्टीथ्रेडिंग मुद्दों को संभालें।

## **स्लाइड क्लोनिंग का मास्टर और लेआउट पर प्रभाव**

एक स्लाइड अपनी उपस्थिति का अधिकांश हिस्सा अपने लेआउट और मास्टर से विरासत में प्राप्त करती है। इसलिए, आप जो क्लोन ओवरलोड चुनते हैं, यह निर्धारित करता है कि मर्ज की गई स्लाइड को गंतव्य प्रस्तुति में कैसे एकीकृत किया जाता है।

इनमें से एक तरीके से [SlideCollection.addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidecollection/) का उपयोग करें:

- `addClone(sourceSlide)` — स्रोत स्लाइड का लेआउट और फ़ॉर्मेटिंग संरक्षित रखें। आवश्यकता पड़ने पर, स्रोत मास्टर को स्वचालित रूप से गंतव्य प्रस्तुति में क्लोन किया जा सकता है। Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर को ट्रैक करता है जिससे समान स्रोत मास्टर वाले दोहराव वाली स्लाइड्स बार‑बार क्लोन नहीं होतीं।
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — क्लोन की गई स्लाइड को एक विशिष्ट गंतव्य [MasterSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslide/) पर संलग्न करें। Aspose.Slides उस मास्टर के तहत लेआउट प्रकार या नाम के आधार पर मिलते‑जुलते लेआउट की खोज करता है।
- `addClone(sourceSlide, destinationLayout)` — क्लोन की गई स्लाइड को सीधे एक विशिष्ट गंतव्य [LayoutSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslide/) से संलग्न करें।

`addClone` ओवरलोड को दिया गया मास्टर या लेआउट **गंतव्य** प्रस्तुति से संबंधित होना चाहिए, स्रोत प्रस्तुति से नहीं।

## **पूरी प्रस्तुतियों को मर्ज करें और स्रोत फ़ॉर्मेटिंग बनाए रखें**

सबसे सरल मर्ज स्रोत प्रस्तुति की प्रत्येक स्लाइड को गंतव्य प्रस्तुति में कॉपी करता है। यह वह विकल्प है जब आयातित स्लाइड्स को अपना मूल थीम, मास्टर और लेआउट संबंध बनाए रखने चाहिए।

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

परिणामी प्रस्तुति में कई मास्टर हो सकते हैं जब स्रोत और गंतव्य अलग‑अलग डिज़ाइन उपयोग करते हैं। जब स्रोत फ़ॉर्मेटिंग को जानबूझकर संरक्षित किया जाता है, तो यह अपेक्षित है।

## **चयनित स्लाइड्स को मर्ज करें**

आपको प्रत्येक स्लाइड को क्लोन करने की आवश्यकता नहीं है। निम्न उदाहरण केवल चयनित स्लाइड इंडेक्स को स्रोत प्रस्तुति से आयात करता है।

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

उपयोगकर्ता इनपुट या बाहरी कॉन्फ़िगरेशन से मिलने पर क्लोन करने से पहले स्लाइड इंडेक्स की वैधता जाँचें।

## **गंतव्य मास्टर का उपयोग करके स्लाइड्स को मर्ज करें**

जब आयातित स्लाइड्स को गंतव्य प्रस्तुति में पहले से मौजूद मास्टर का पालन करना चाहिए, तब [addClone(Slide, MasterSlide, boolean)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) ओवरलोड का उपयोग करें।

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

Aspose.Slides निर्दिष्ट मास्टर के तहत स्रोत लेआउट के प्रकार या नाम से मेल खाता उपयुक्त लेआउट चुनता है। यदि उपयुक्त लेआउट नहीं मिलता और `allowCloneMissingLayout` `true` है, तो स्रोत लेआउट को क्लोन किया जाता है ताकि स्लाइड जोड़ी जा सके। यदि यह `false` है, तो एक [PptxEditException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pptxeditexception/) फेंका जाता है।

जब आप चाहते हैं कि मर्ज विफल हो और अतिरिक्त लेआउट गंतव्य मास्टर में न जोड़ा जाए, तब `false` का उपयोग करें।

## **विशिष्ट गंतव्य लेआउट का उपयोग करके स्लाइड्स को मर्ज करें**

जब आप ठीक‑ठीक जानते हैं कि आयातित स्लाइड्स को कौन सा गंतव्य लेआउट उपयोग करना चाहिए, तब [addClone(Slide, LayoutSlide)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) ओवरलोड का उपयोग करें।

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

गंतव्य लेआउट लागू करने से केवल विरासत में मिला लेआउट संबंध बदलता है; यह स्रोत स्लाइड की सामग्री को पुनः डिज़ाइन नहीं करता। यदि स्रोत और गंतव्य लेआउट की प्लेसहोल्डर संरचनाएँ अलग हैं, तो परिणाम का निरीक्षण करें ताकि विरासत में मिला फ़ॉर्मेटिंग और प्लेसहोल्डर व्यवहार उचित हों यह पुष्टि हो सके।

## **विभिन्न स्लाइड आकारों वाली प्रस्तुतियों को मर्ज करें**

विभिन्न स्लाइड आयामों वाली प्रस्तुतियों को मर्ज किया जा सकता है, लेकिन किसी अन्य स्लाइड आकार वाली प्रस्तुति में स्लाइड को क्लोन करने से उसकी सामग्री अपने‑आप नए कैनवास के अनुरूप पुनः डिज़ाइन नहीं होती। परिणामस्वरूप शैप्स शिफ्ट, स्केल या स्लाइड के दृश्य क्षेत्र से बाहर दिख सकते हैं।

एक व्यावहारिक तरीका है स्रोत प्रस्तुति को क्लोन करने से पहले उसका आकार बदलना। [SlideSize.setSize](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) मेथड मौजूदा सामग्री को स्केल करते हुए स्लाइड आयाम बदल सकता है। [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidesizescaletype/) सामग्री को अनुरोधित आकार में फिट करने के लिए स्केल करता है।

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

आकार बदलने से स्रोत प्रस्तुति ऑब्जेक्ट मेमोरी में बदल जाता है। यदि आपको अन्य ऑपरेशनों के लिए मूल स्रोत प्रस्तुति को अपरिवर्तित रखना है, तो मर्ज के लिए एक अलग इंस्टेंस खोलें।

## **स्लाइड्स को प्रस्तुति सेक्शन में मर्ज करें**

बेसिक स्लाइड‑क्लोनिंग लूप स्रोत प्रस्तुति की सेक्शन पदानुक्रम को पुनः बनाता नहीं है। यदि आउटपुट में सेक्शन महत्वपूर्ण हैं, तो गंतव्य प्रस्तुति में सेक्शन बनाएं या चुनें और स्लाइड्स को स्पष्ट रूप से [addClone(Slide, Section)](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) के साथ क्लोन करें।

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

क्लोन की गई स्लाइड्स निर्दिष्ट गंतव्य सेक्शन में जोड़ दी जाती हैं। कई स्रोत सेक्शन को संरक्षित करने के लिए, उन सेक्शनों को गंतव्य में पुनः बनाएं और प्रत्येक स्रोत स्लाइड को संबंधित गंतव्य सेक्शन से मैप करें।

## **कई प्रस्तुतियों को सुरक्षित रूप से मर्ज करें**

निम्न अंत‑से‑अन्त उदाहरण पहले प्रस्तुति को गंतव्य के रूप में उपयोग करता है, प्रत्येक अतिरिक्त स्रोत का स्लाइड आकार सामान्यीकृत करता है, प्रत्येक स्रोत को केवल तभी खुला रखता है जब वह कॉपी किया जा रहा हो, और अंतिम फ़ाइल को एक बार सहेजता है।

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

यह आयातित स्लाइड्स की स्रोत फ़ॉर्मेटिंग को बनाए रखने के लिए एक उपयोगी बेसलाइन है। यदि आपके आउटपुट को एकल गंतव्य थीम उपयोग करनी है, तो पहले दिखाए गए उपयुक्त गंतव्य‑मास्टर या गंतव्य‑लेआउट ओवरलोड के साथ साधारण `addClone(sourceSlide)` कॉल को बदलें।

## **व्यावहारिक विचार**

### **मास्टर, लेआउट और फ़ॉर्मेटिंग फ़िडेलिटी**

डिफ़ॉल्ट स्लाइड क्लोनिंग आवश्यक स्रोत मास्टर को स्वचालित रूप से गंतव्य प्रस्तुति में ला सकती है। Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर को दोहराए क्लोनिंग से बचाने के लिए एक आंतरिक रजिस्ट्री रखता है। मैन्युअल रूप से क्लोन किए गए मास्टर इस रजिस्ट्री में ट्रैक नहीं होते, इसलिए तब तक मास्टर को पहले से क्लोन न करें जब तक आप मास्टर संरचना पर स्पष्ट नियंत्रण न चाहते हों।

यह मानें नहीं कि समान नाम वाले दो मास्टर या लेआउट दृश्य रूप से समान हैं। यदि कोई कॉर्पोरेट टेम्पलेट अंतिम रूप को नियंत्रित करता है, तो स्पष्ट रूप से गंतव्य मास्टर या लेआउट चुनें और मर्ज के बाद परिणाम को सत्यापित करें।

### **नोट्स और टिप्पणियाँ**

स्पीकर नोट्स और स्लाइड टिप्पणियाँ स्लाइड सामग्री से जुड़ी होती हैं और स्लाइड क्लोन होने पर कॉपी हो जाती हैं। Aspose.Slides [presentation notes](https://docs.aspose.com/slides/hi/nodejs-java/presentation-notes/) और [presentation comments](https://docs.aspose.com/slides/hi/nodejs-java/presentation-comments/) के लिए समर्पित API भी प्रदान करता है।

यदि नोट‑पेज फ़ॉर्मेटिंग महत्वपूर्ण है, तो मर्ज की गई प्रस्तुति को सत्यापित करें क्योंकि नोट‑मास्टर प्रस्तुति‑स्तर के ऑब्जेक्ट होते हैं और स्रोत फ़ाइलों में अलग हो सकते हैं। समीक्षा वर्कफ़्लो में विभिन्न लेखकों या टेम्पलेट्स की फ़ाइलें मिलाने के बाद टिप्पणी लेखकों और थ्रेडेड टिप्पणियों की भी पुष्टि करें।

### **इमेज, ऑडियो, वीडियो, OLE ऑब्जेक्ट और एक्सटरनल लिंक**

स्लाइड्स में प्रस्तुति‑स्तर के संसाधन जैसे इमेज, एम्बेडेड ऑडियो, एम्बेडेड वीडियो और OLE डेटा का संदर्भ हो सकता है। केवल दृश्यमान शैप्स को कॉपी करने के बजाय पूरी स्लाइड को क्लोन करें ताकि Aspose.Slides स्लाइड‑संसाधन संबंधों को बनाए रखे।

एम्बेडेड और लिंक्ड संसाधनों का अलग‑अलग उपचार किया जाना चाहिए। एक लिंक्ड ऑडियो, वीडियो, OLE ऑब्जेक्ट या हाइपरलिंक अपनी बाहरी लक्ष्य पर निर्भर रहता है; स्लाइड को क्लोन करने से बाहरी लिंक एम्बेडेड सामग्री में नहीं बदलता। उस वातावरण में लिंक्ड‑रिसोर्स पाथ और URL का परीक्षण करें जहाँ मर्ज की गई प्रस्तुति खोली जाएगी।

Aspose.Slides स्वचालित क्लोन किए गए मास्टर को ट्रैक करता है, लेकिन इसे यह सामान्य गारंटी नहीं मानना चाहिए कि असंबंधित स्रोत प्रस्तुतियों से समान बाइनरी संसाधनों को हमेशा डिडुप्लिकेट किया जाएगा। यदि आउटपुट फ़ाइल आकार महत्वपूर्ण है, तो मर्ज किए गए पैकेज का निरीक्षण करें और परिणाम मापें, न कि निहित डिडुप्लिकेशन पर भरोसा करें।

### **एम्बेडेड फ़ॉन्ट और फ़ॉन्ट उपलब्धता**

फ़ॉन्ट प्रदर्शन स्तर पर प्रबंधित होते हैं। यदि टाइपोग्राफी को विभिन्न मशीनों पर समान रहना है, तो केवल स्लाइड क्लोनिंग यह गारंटी नहीं देती कि सभी आवश्यक फ़ॉन्ट गंतव्य वातावरण में उपलब्ध होंगे। आप [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/fontsmanager/#getEmbeddedFonts--) से एम्बेडेड फ़ॉन्ट देख सकते हैं और [Embed Fonts in Presentations](https://docs.aspose.com/slides/hi/nodejs-java/embedded-font/) में वर्णित रूप से एम्बेडिंग को स्पष्ट रूप से प्रबंधित कर सकते हैं।

साथ ही यह सत्यापित करें कि आप स्रोत फ़ाइलों द्वारा उपयोग किए गए फ़ॉन्ट को एम्बेड करने के लिए अनुमति प्राप्त हैं। फ़ॉन्ट लाइसेंस एम्बेडिंग को प्रतिबंधित कर सकते हैं।

### **पासवर्ड‑सुरक्षित प्रस्तुतियां**

एक पासवर्ड‑सुरक्षित स्रोत को उसके स्लाइड्स को क्लोन करने से पहले सफलतापूर्वक खोलना आवश्यक है। पासवर्ड को [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setPassword-String-) के माध्यम से प्रदान करें।

```javascript
const aspose = require("aspose.slides.via.java");

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

const source = new aspose.slides.Presentation("protected.pptx", loadOptions);
try {
    // डिक्रिप्टेड प्रस्तुति के साथ कार्य करें.
} finally {
    source.dispose();
}
```

एक एन्क्रिप्टेड स्रोत को खोलना स्वचालित रूप से गंतव्य प्रस्तुति पर वही सुरक्षा लागू नहीं करता। आवश्यक होने पर आउटपुट सुरक्षा को अलग से कॉन्फ़िगर करें।

### **बड़ी प्रस्तुतियां और मेमोरी उपयोग**

उच्च‑रिज़ॉल्यूशन इमेज, ऑडियो, वीडियो या अन्य बड़े बाइनरी ऑब्जेक्ट वाली बड़ी प्रस्तुतियां पर्याप्त मेमोरी उपयोग कर सकती हैं। [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions--) BLOB हैंडलिंग और टेम्पररी‑फ़ाइल उपयोग के लिए नियंत्रण प्रदान करता है। बड़े‑फ़ाइल रणनीतियों के लिए [Manage Presentation BLOBs](https://docs.aspose.com/slides/hi/nodejs-java/manage-blob/) देखें।

बड़ी फ़ाइलों के लिए संभव हो तो फ़ाइल‑पाथ से लोड करना पसंद करें, प्रत्येक स्रोत प्रस्तुति को मर्ज होने के तुरंत बाद डिस्पोज़ करें, और जब तक आवश्यक न हो इंटरमीडिएट परिणाम को बार‑बार सेव न करें।

### **थ्रेड सुरक्षा**

एक ही [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) इंस्टेंस को कई थ्रेड्स में लोड, सेव या क्लोन न करें। ये ऑपरेशन मल्टीथ्रेडेड उपयोग के लिए समर्थित नहीं हैं। यदि आपको स्वतंत्र मर्ज जॉब्स को समानांतर चलाना है, तो कई सिंगल‑थ्रेडेड प्रोसेस उपयोग करें, प्रत्येक की अपनी प्रस्तुति इंस्टेंस हो, और [Aspose.Slides मल्टीथ्रेडिंग गाइडेंस](https://docs.aspose.com/slides/hi/nodejs-java/multithreading/) का पालन करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रत्येक स्रोत प्रस्तुति के मूल डिज़ाइन को कैसे बनाए रखूँ?**

`addClone(sourceSlide)` को बिना गंतव्य मास्टर या लेआउट प्रदान किए उपयोग करें। आयातित स्लाइड के लिए आवश्यक होने पर Aspose.Slides स्वचालित रूप से स्रोत मास्टर को क्लोन कर सकता है।

**मैं आयातित स्लाइड्स को गंतव्य थीम का उपयोग कैसे कराऊँ?**

ऐसा ओवरलोड उपयोग करें जो गंतव्य मास्टर स्वीकार करता है। गंतव्य प्रस्तुति से एक मास्टर पास करें, स्रोत से नहीं। Aspose.Slides प्रत्येक स्रोत स्लाइड को उस मास्टर के तहत उपयुक्त लेआउट से मैप करने की कोशिश करेगा।

**मैं कब विशिष्ट गंतव्य लेआउट को गंतव्य मास्टर के बजाय उपयोग करूँ?**

जब प्रत्येक आयातित स्लाइड को एक ज्ञात लेआउट उपयोग करना चाहिए, तब विशिष्ट लेआउट चुनें। जब आप चाहते हैं कि Aspose.Slides स्रोत लेआउट प्रकार या नाम के आधार पर उस मास्टर के लेआउट में से चुनें, तब मास्टर उपयोग करें।

**क्या विभिन्न स्लाइड आकार वाली प्रस्तुतियों को मर्ज किया जा सकता है?**

हां, लेकिन स्लाइड सामग्री को गंतव्य आयामों के अनुरूप स्वचालित रूप से पुनः डिज़ाइन नहीं किया जाता। पूर्व‑आकार बदलने के लिए [SlideSize.setSize](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidesize/#setSize-float-float-int-) और [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidesizescaletype/) का उपयोग करें।

**क्या मैं PPT, PPTX और ODP प्रस्तुतियों को एक फ़ाइल में मर्ज कर सकता हूँ?**

हां। प्रत्येक स्रोत प्रस्तुति को लोड करें, आवश्यक स्लाइड्स को एक गंतव्य में क्लोन करें, और गंतव्य को समर्थित आउटपुट फ़ॉर्मेट में सहेजें। चूँकि प्रस्तुति फ़ॉर्मेट समान फ़ीचर सेट नहीं रखते, क्रॉस‑फ़ॉर्मेट मर्ज के बाद जटिल सामग्री को सत्यापित करें। देखें [Supported File Formats](https://docs.aspose.com/slides/hi/nodejs-java/supported-file-formats/)।

**क्या स्रोत सेक्शन स्वचालित रूप से संरक्षित रहते हैं?**

केवल स्लाइड्स को क्लोन करने वाले बेसिक लूप में नहीं। आवश्यक सेक्शन को गंतव्य में पुनः बनाएं और जब सेक्शन संरचना को संरक्षित करना हो, तब [addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidecollection/#addClone-aspose.slides.ISlide-aspose.slides.ISection-) के सेक्शन ओवरलोड का उपयोग करें।

**क्या स्पीकर नोट्स और टिप्पणियाँ संरक्षित रहती हैं?**

वे क्लोन की गई स्लाइड के साथ कॉपी हो जाती हैं। यदि वर्कफ़्लो नोट‑मास्टर स्टाइलिंग, टिप्पणी लेखकों या थ्रेडेड रिव्यू डेटा पर निर्भर करता है, तो मर्ज परिणाम को सत्यापित करें क्योंकि इन परिदृश्यों में प्रस्तुति‑स्तर संरचनाएँ और स्लाइड‑स्तर सामग्री दोनों शामिल होते हैं।

**ऑडियो, वीडियो, OLE ऑब्जेक्ट और हाइपरलिंक का क्या होता है?**

एम्बेडेड कंटेंट क्लोन की गई स्लाइड के संसाधन संबंधों के भाग के रूप में ले जाता है। बाहरी लिंक बाहरी ही रहते हैं, इसलिए उनके लक्ष्य फ़ाइलें या URL मर्ज के बाद भी उपलब्ध रहने चाहिए।

**क्या प्रत्येक स्रोत से एम्बेडेड फ़ॉन्ट्स मर्ज की गई प्रस्तुति में उपलब्ध होते हैं?**

केवल स्लाइड क्लोनिंग पर फ़ॉन्ट डिप्लॉयमेंट के लिए भरोसा न रखें। गंतव्य के एम्बेडेड फ़ॉन्ट की जाँच करें और टाइपोग्राफी महत्वपूर्ण होने पर फ़ॉन्ट एम्बेडिंग या बाहरी फ़ॉन्ट उपलब्धता को स्पष्ट रूप से प्रबंधित करें।

**मैं पासवर्ड‑सुरक्षित फ़ाइल को कैसे मर्ज करूँ?**

सही [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/loadoptions/#setPassword-String-) के साथ इसे खोलें, फिर सामान्य रूप से उसकी स्लाइड्स को क्लोन करें। आउटपुट सुरक्षा को अलग से कॉन्फ़िगर करें।

**बहुत बड़ी प्रस्तुतियों को मैं कैसे संभालूँ?**

जब बड़े बाइनरी ऑब्जेक्ट मेमोरी उपयोग को प्रमुख बनाते हैं, तो BLOB प्रबंधन का उपयोग करें, बहुत बड़ी फ़ाइलों के लिए फ़ाइल‑पाथ लोडिंग पसंद करें, स्रोत प्रस्तुतियों को यथाशीघ्र डिस्पोज़ करें, और अंत में परिणाम को केवल आवश्यक होने पर ही सहेजें।

**क्या मैं कई थ्रेड्स से स्लाइड्स को मर्ज कर सकता हूँ?**

एक ही प्रस्तुति इंस्टेंस को कई थ्रेड्स में लोड, सेव या क्लोन न करें। समानांतर मर्ज जॉब्स के लिए अलग‑अलग सिंगल‑थ्रेडेड प्रोसेस और स्वतंत्र प्रस्तुति इंस्टेंस का उपयोग करें।