---
title: Android पर प्रस्तुतियों को कुशलता से मर्ज करें
linktitle: प्रस्तुति मर्ज करें
type: docs
weight: 40
url: /hi/androidjava/merge-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Android पर PowerPoint और OpenDocument प्रस्तुतियों को स्लाइड्स को क्लोन करके, मास्टर और लेआउट को नियंत्रित करके, स्लाइड सामग्री का आकार बदलकर, सेक्शन को संरक्षित करके, तथा संरक्षित या बड़े फ़ाइलों को संभालते हुए कैसे मर्ज करें, यह सीखें।"
---
## **परिचय**

Aspose.Slides for Android via Java प्रस्तुतियों को एक [प्रस्तुति](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) से दूसरी में स्लाइड्स को क्लोन करके मर्ज करता है। मुख्य ऑपरेशन है [ISlideCollection.addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), जो स्रोत स्लाइड के फ़ॉर्मेट को संरक्षित कर सकता है या क्लोन की गई स्लाइड को लक्ष्य प्रस्तुति में मास्टर या लेआउट से जोड़ सकता है।

यह लेख सबसे सामान्य मर्जिंग कार्यधाराओं को कवर करता है:

- सभी स्लाइड्स को उनके स्रोत फ़ॉर्मेट को संरक्षित रखते हुए मर्ज करें;
- चयनित स्लाइड्स को मर्ज करें;
- लक्ष्य प्रस्तुति से एक मास्टर लागू करें;
- लक्ष्य प्रस्तुति से एक विशिष्ट लेआउट लागू करें;
- मर्ज करने से पहले विभिन्न स्लाइड आकारों को सामान्यीकृत करें;
- क्लोन की गई स्लाइड्स को एक सेक्शन में जोड़ें;
- कई प्रस्तुतियों को एक अंतिम कार्यधारा में मर्ज करें;
- मास्टर, संसाधन, नोट्स, टिप्पणी, मीडिया, फ़ॉन्ट, पासवर्ड, बड़े फ़ाइलें और मल्टीथ्रेडिंग संबंधी मामलों को संभालें।

## **स्लाइड क्लोनिंग का मास्टर और लेआउट पर प्रभाव**

एक स्लाइड अपनी उपस्थिति का बहुत हिस्सा अपनी लेआउट और मास्टर से विरासत में प्राप्त करता है। इसलिए, आप जिस क्लोनिंग ओवरलोड को चुनते हैं, वह निर्धारित करता है कि मर्ज की गई स्लाइड को लक्ष्य प्रस्तुति में कैसे एकीकृत किया जाता है।

इनमें से किसी एक तरीके से [ISlideCollection.addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidecollection/) का उपयोग करें:

- `addClone(sourceSlide)` — स्रोत स्लाइड की लेआउट और फ़ॉर्मेट को संरक्षित करता है। आवश्यकता पड़ने पर स्रोत मास्टर को लक्ष्य प्रस्तुति में स्वचालित रूप से क्लोन किया जा सकता है। Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर को ट्रैक करता है ताकि समान स्रोत मास्टर वाली कई स्लाइड्स को क्लोन करने से मास्टर कई बार क्लोन न हो।
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — क्लोन की गई स्लाइड को एक विशिष्ट लक्ष्य [IMasterSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslide/) से संलग्न करता है। Aspose.Slides उस मास्टर के तहत लेआउट टाइप या नाम के आधार पर मिलते-जुलते लेआउट की खोज करता है।
- `addClone(sourceSlide, destinationLayout)` — क्लोन की गई स्लाइड को सीधे एक विशिष्ट लक्ष्य [ILayoutSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutslide/) से संलग्न करता है।

`addClone` ओवरलोड में पास किया गया मास्टर या लेआउट **लक्ष्य** प्रस्तुति से संबंधित होना चाहिए, स्रोत प्रस्तुति से नहीं।

## **पूरी प्रस्तुतियों को मर्ज करें और स्रोत फ़ॉर्मेट को संरक्षित रखें**

सबसे सरल मर्ज स्रोत प्रस्तुति की हर स्लाइड को लक्ष्य प्रस्तुति में कॉपी करता है। यह तब उपयुक्त चयन है जब आयातित स्लाइड्स को उनका मूल थीम, मास्टर और लेआउट संबंध बनाए रखना चाहिए।

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

परिणामी प्रस्तुति में कई मास्टर हो सकते हैं जब स्रोत और लक्ष्य अलग-अलग डिज़ाइन का उपयोग करते हैं। यह अपेक्षित है जब स्रोत फ़ॉर्मेट को जानबूझकर संरक्षित किया जाता है।

## **चयनित स्लाइड्स को मर्ज करें**

आपको हर स्लाइड को क्लोन करने की आवश्यकता नहीं है। निम्न उदाहरण स्रोत प्रस्तुति से केवल चयनित स्लाइड इंडेक्स को आयात करता है।

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

क्लोन करने से पहले स्लाइड इंडेक indices को सत्यापित करें जब वे उपयोगकर्ता इनपुट या बाहरी कॉन्फ़िगरेशन से आते हैं।

## **लक्ष्य मास्टर का उपयोग करके स्लाइड्स को मर्ज करें**

जब आयातित स्लाइड्स को पहले से लक्ष्य प्रस्तुति में मौजूद मास्टर से अनुसरण करना चाहिए, तो [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) ओवरलोड का उपयोग करें।

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

Aspose.Slides निर्दिष्ट मास्टर के तहत स्रोत लेआउट के प्रकार या नाम से मेल खाने वाले उपयुक्त लेआउट को चुनता है। यदि कोई उपयुक्त लेआउट मौजूद नहीं है और `allowCloneMissingLayout` `true` है, तो स्रोत लेआउट को क्लोन किया जाता है ताकि स्लाइड जोड़ी जा सके। यदि यह `false` है, तो एक [PptxEditException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pptxeditexception/) फेंका जाता है।

जब आप मर्ज को विफल करना चाहते हैं बजाय लक्ष्य मास्टर में अतिरिक्त लेआउट जोड़ने के, तो `false` का उपयोग करें।

## **विशिष्ट लक्ष्य लेआउट का उपयोग करके स्लाइड्स को मर्ज करें**

जब आप ठीक-ठीक जानते हैं कि आयातित स्लाइड्स को कौन सा लक्ष्य लेआउट उपयोग करना चाहिए, तो [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) ओवरलोड का उपयोग करें।

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

लक्ष्य लेआउट को लागू करने से विरासत में मिलने वाला लेआउट संबंध बदलता है; यह स्रोत स्लाइड की सामग्री को पुन:डिज़ाइन नहीं करता। यदि स्रोत और लक्ष्य लेआउट में प्लेसहोल्डर संरचनाएँ अलग हैं, तो परिणाम की जाँच करें ताकि विरासत में मिले फ़ॉर्मेट और प्लेसहोल्डर व्यवहार उपयुक्त हो।

## **भिन्न स्लाइड आकारों वाली प्रस्तुतियों को मर्ज करें**

विभिन्न स्लाइड आयामों वाली प्रस्तुतियों को मर्ज किया जा सकता है, लेकिन एक स्लाइड को किसी अन्य स्लाइड आकार वाली प्रस्तुति में क्लोन करने से उसकी सामग्री नई कैनवास के अनुसार स्वचालित रूप से पुनःडिज़ाइन नहीं होती। परिणामस्वरूप आकार बदलना, स्थान बदलना या स्लाइड के दृश्यमान क्षेत्र के बाहर जाना संभव है।

व्यावहारिक तरीका है क्लोन करने से पहले स्रोत प्रस्तुति का आकार बदलना। [SlideSize.setSize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) मेथड मौजूदा सामग्री को स्केल कर सकता है जबकि स्लाइड आयाम बदलता है। [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slidesizescaletype/) सामग्री को अनुरोधित आकार में फिट करने के लिए स्केल करता है।

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation destination = new Presentation("destination.pptx");
Presentation source = new Presentation("source.pptx");
try {
    SizeF sourceSize = source.getSlideSize().getSize();
    SizeF destinationSize = destination.getSlideSize().getSize();

    if (sourceSize.getWidth() != destinationSize.getWidth() || 
        sourceSize.getHeight() != destinationSize.getHeight()) {
        source.getSlideSize().setSize(
            destinationSize.getWidth(), 
            destinationSize.getHeight(), 
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

आकार बदलने से स्रोत प्रस्तुति ऑब्जेक्ट मेमोरी में बदल जाता है। यदि आपको अन्य ऑपरेशनों के लिए मूल स्रोत प्रस्तुति अपरिवर्तित चाहिए, तो मर्ज के लिए एक अलग इंस्टेंस खोलें।

## **स्लाइड्स को एक प्रस्तुति सेक्शन में मर्ज करें**

बुनियादी स्लाइड-क्लोनिंग लूप स्रोत प्रस्तुति की सेक्शन पदानुक्रम को पुनःनिर्मित नहीं करता। यदि आउटपुट में सेक्शन महत्वपूर्ण हैं, तो लक्ष्य प्रस्तुति में सेक्शन बनाएँ या चुनें और स्लाइड्स को स्पष्ट रूप से [addClone(ISlide, ISection)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) द्वारा उनमें क्लोन करें।

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

क्लोन की गई स्लाइड्स निर्दिष्ट लक्ष्य सेक्शन में जोड़ी जाती हैं। कई स्रोत सेक्शन को संरक्षित करने के लिए, [Presentation.getSections](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getSections--) को एन्यूमरेट करें, प्रत्येक स्रोत सेक्शन की वर्तमान स्लाइड्स को [ISection.getSlidesListOfSection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/isection/#getSlidesListOfSection--) से प्राप्त करें, लक्ष्य में सेक्शन दोबारा बनाएं, और प्रत्येक प्राप्त स्लाइड को उसके अनुरूप लक्ष्य सेक्शन में क्लोन करें। पूर्ण सेक्शन-एन्यूमरेशन उदाहरण के लिए देखें [Manage Slide Sections](/slides/hi/androidjava/slide-section/), जिसमें खाली सेक्शन और संरचनात्मक परिवर्तन शामिल हैं।

## **कई प्रस्तुतियों को सुरक्षित रूप से मर्ज करें**

निम्न अंतिम-से-अंत उदाहरण पहली प्रस्तुति को लक्ष्य के रूप में उपयोग करता है, प्रत्येक अतिरिक्त स्रोत की स्लाइड आकार को सामान्यीकृत करता है, प्रत्येक स्रोत को केवल तभी खुला रखता है जब वह कॉपी हो रहा हो, और अंत में अंतिम फ़ाइल को सेव करता है।

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

String[] inputFiles = { "part1.pptx", "part2.pptx", "part3.pptx" };

Presentation merged = new Presentation(inputFiles[0]);
try {
    SizeF mergedSize = merged.getSlideSize().getSize();

    for (int fileIndex = 1; fileIndex < inputFiles.length; fileIndex++) {
        Presentation source = new Presentation(inputFiles[fileIndex]);
        try {
            SizeF sourceSize = source.getSlideSize().getSize();

            if (sourceSize.getWidth() != mergedSize.getWidth() || 
                sourceSize.getHeight() != mergedSize.getHeight()) {
                source.getSlideSize().setSize(
                    mergedSize.getWidth(), 
                    mergedSize.getHeight(), 
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

यह आयातित स्लाइड्स के स्रोत फ़ॉर्मेट को संरक्षित करने के लिए एक उपयोगी बेसलाइन है। यदि आपका आउटपुट एकल लक्ष्य थीम उपयोग करना चाहिए, तो सरल `addClone(slide)` कॉल को पहले दिखाए गए उपयुक्त लक्ष्य-मास्टर या लक्ष्य-लेआउट ओवरलोड से बदल दें।

## **व्यावहारिक विचार**

### **मास्टर, लेआउट और फ़ॉर्मेटिंग फ़िडेलिटी**

डिफ़ॉल्ट स्लाइड क्लोनिंग आवश्यक स्रोत मास्टर को लक्ष्य प्रस्तुति में स्वचालित रूप से ला सकता है। Aspose.Slides स्वचालित क्लोन किए गए मास्टर के लिए एक आंतरिक रजिस्ट्री रखता है ताकि एक ही मास्टर को बार‑बार क्लोन करने से बचा जा सके। मैन्युअल रूप से क्लोन किए गए मास्टर इस रजिस्ट्री में ट्रैक नहीं होते, इसलिए तब तक मास्टर को पूर्व‑क्लोन न करें जब तक कि आपको मास्टर संरचना पर स्पष्ट नियंत्रण की आवश्यकता न हो।

एक ही नाम वाले दो मास्टर या लेआउट को दृश्य रूप से समान मानने से बचें। यदि कोई कॉर्पोरेट टेम्प्लेट अंतिम रूप को नियंत्रित करता है, तो स्पष्ट रूप से लक्ष्य मास्टर या लेआउट चुनें और मर्ज के बाद परिणाम की पुष्टि करें।

### **नोट्स और टिप्पणियाँ**

स्पीकर नोट्स और स्लाइड टिप्पणियाँ स्लाइड सामग्री से जुड़ी होती हैं और स्लाइड क्लोन होने पर कॉपी हो जाती हैं। Aspose.Slides विशेष API भी प्रदान करता है [presentation notes](/slides/hi/androidjava/presentation-notes/) और [presentation comments](/slides/hi/androidjava/presentation-comments/) के लिए।

यदि नोट‑पेज फ़ॉर्मेटिंग महत्वपूर्ण है, तो मर्ज की गई प्रस्तुति की जाँच करें क्योंकि नोट‑मास्टर प्रस्तुति‑स्तर के ऑब्जेक्ट होते हैं और स्रोत फ़ाइलों के बीच भिन्न हो सकते हैं। समीक्षात्मक कार्यधाराओं में विभिन्न लेखकों या टेम्प्लेट्स से फ़ाइलें मिलाने के बाद टिप्पणी लेखक और थ्रेडेड कमेंट्स की भी पुष्टि करें।

### **छवियां, ऑडियो, वीडियो, OLE ऑब्जेक्ट और बाहरी लिंक्स**

स्लाइड्स प्रस्तुति‑स्तर के संसाधनों जैसे छवियां, एम्बेडेड ऑडियो, एम्बेडेड वीडियो और OLE डेटा को संदर्भित कर सकती हैं। केवल दृश्यमान आकार कॉपी करने के बजाय स्लाइड को स्वयं क्लोन करें ताकि Aspose.Slides उसकी संसाधनों के साथ संबंध बनाए रख सके।

एम्बेडेड और लिंक्ड संसाधनों को अलग‑अलग संभालें। एक लिंक्ड ऑडियो, वीडियो, OLE ऑब्जेक्ट या हाइपरलिंक अपने बाहरी लक्ष्य पर निर्भर रहता है; स्लाइड क्लोन करने से बाहरी लिंक एम्बेडेड सामग्री में नहीं बदलता। मर्ज की गई प्रस्तुति को खोलने वाले वातावरण में लिंक्ड‑रिसोर्स पाथ और URL का परीक्षण करें।

Aspose.Slides स्वचालित क्लोन किए गए मास्टर को ट्रैक करता है, लेकिन यह सामान्य गारंटी नहीं है कि असंबंधित स्रोत प्रस्तुतियों के समान बाइनरी संसाधन हमेशा डिडुप्लिकेट हो जाएँ। यदि आउटपुट फ़ाइल का आकार महत्वपूर्ण है, तो मर्ज पैकेज की जाँच करें और परिणाम मापें बजाय अपरिचित डिडुप्लिकेशन पर निर्भर हुए।

### **एंबेडेड फ़ॉन्ट और फ़ॉन्ट उपलब्धता**

फ़ॉन्ट प्रस्तुति‑स्तर पर प्रबंधित होते हैं। यदि टाइपोग्राफी कई मशीनों पर समान रहनी चाहिए, तो केवल स्लाइड क्लोन पर निर्भर न रहें क्योंकि यह आवश्यक फ़ॉन्ट की उपलब्धता की गारंटी नहीं देता। आप एंबेडेड फ़ॉन्ट को [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) से देख सकते हैं और [Embed Fonts in Presentations](/slides/hi/androidjava/embedded-font/) में वर्णित अनुसार एंबेडिंग को स्पष्ट रूप से प्रबंधित कर सकते हैं।

यह भी सत्यापित करें कि आप स्रोत फ़ाइलों द्वारा उपयोग किए गए फ़ॉन्ट को एंबेड करने की अनुमति रखते हैं। फ़ॉन्ट लाइसेंस एंबेडिंग को प्रतिबंधित कर सकते हैं।

### **पासवर्ड‑सुरक्षित प्रस्तुतियां**

पासवर्ड‑सुरक्षित स्रोत को उसके स्लाइड्स को क्लोन करने से पहले सफलतापूर्वक खोलना आवश्यक है। पासवर्ड को [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) द्वारा प्रदान करें।

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // डिक्रिप्ट की गई प्रस्तुति के साथ काम करें।
} finally {
    source.dispose();
}
```

एक एन्क्रिप्टेड स्रोत को खोलना स्वचालित रूप से लक्ष्य प्रस्तुति पर वही सुरक्षा लागू नहीं करता। आवश्यकता होने पर आउटपुट सुरक्षा को अलग से कॉन्फ़िगर करें।

### **बड़ी प्रस्तुतियां और मेमोरी उपयोग**

उच्च‑रिज़ॉल्यूशन छवियों, ऑडियो, वीडियो या अन्य बड़े बाइनरी ऑब्जेक्ट वाली बड़ी प्रस्तुतियां काफी मेमोरी उपयोग कर सकती हैं। [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) BLOB हैंडलिंग और अस्थायी‑फ़ाइल उपयोग के नियंत्रण प्रदान करता है। बड़े‑फ़ाइल रणनीतियों के लिए देखें [Manage Presentation BLOBs](/slides/hi/androidjava/manage-blob/)।

बड़ी फ़ाइलों के लिए, संभव हो तो फ़ाइल पाथ से लोड करना प्राथमिकता दें, प्रत्येक स्रोत प्रस्तुति को मर्ज के बाद तुरंत डिस्पोज़ करें, और मध्यवर्ती परिणामों को बार‑बार सेव करने से बचें जब तक कि कार्यधारा में चेक‑पॉइंट की आवश्यकता न हो।

### **थ्रेड सुरक्षा**

एक ही [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) इंस्टेंस को कई थ्रेड से एक साथ लोड, संशोधित, सेव या क्लोन न करें। प्रत्येक प्रस्तुति इंस्टेंस को एक मर्ज ऑपरेशन तक सीमित रखें। यदि आप स्वतंत्र कार्यों को समानांतर चलाते हैं, तो स्वतंत्र प्रस्तुति इंस्टेंस का उपयोग करें और [Aspose.Slides मल्टीथ्रेडिंग मार्गदर्शन](/slides/hi/androidjava/multithreading/) का पालन करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रत्येक स्रोत प्रस्तुति की मूल डिजाइन कैसे रखूँ?**

एक लक्ष्य मास्टर या लेआउट प्रदान किए बिना [addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) का उपयोग करें। Aspose.Slides आवश्यक होने पर स्रोत मास्टर को स्वचालित रूप से क्लोन कर सकता है।

**मैं आयातित स्लाइड्स को लक्ष्य थीम कैसे लागू करूँ?**

एक लक्ष्य मास्टर स्वीकार करने वाले ओवरलोड का उपयोग करें। लक्ष्य प्रस्तुति से मास्टर पास करें, स्रोत से नहीं। Aspose.Slides प्रत्येक स्रोत स्लाइड को उस मास्टर के तहत उपयुक्त लेआउट से मैप करने का प्रयास करेगा।

**किस स्थिति में लक्ष्य लेआउट के बजाय लक्ष्य मास्टर उपयोग करूँ?**

जब हर आयातित स्लाइड को एक ज्ञात लेआउट का उपयोग करना हो तब विशिष्ट लेआउट चुनें। जब आप चाहते हैं कि Aspose.Slides स्रोत लेआउट टाइप या नाम के आधार पर उस मास्टर के कई लेआउट में से उपयुक्त चुनें, तो मास्टर उपयोग करें।

**क्या विभिन्न स्लाइड आकारों वाली प्रस्तुतियों को मर्ज किया जा सकता है?**

हां, लेकिन स्लाइड सामग्री स्वचालित रूप से नई आयामों के लिए पुनःडिज़ाइन नहीं होती। पूर्व‑आकार बदलने के लिए [SlideSize.setSize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) और [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slidesizescaletype/) का उपयोग करें।

**क्या मैं PPT, PPTX और ODP प्रस्तुतियों को एक फ़ाइल में मर्ज कर सकता हूँ?**

हां। प्रत्येक स्रोत प्रस्तुति को लोड करें, आवश्यक स्लाइड्स को एक लक्ष्य में क्लोन करें, और लक्ष्य को समर्थित आउटपुट फ़ॉर्मेट में सेव करें। चूंकि फ़ॉर्मेट पूरी तरह समान फ़ीचर सेट नहीं देते, क्रॉस‑फ़ॉर्मेट मर्ज के बाद जटिल सामग्री की जाँच करें। देखें [Supported File Formats](/slides/hi/androidjava/supported-file-formats/)।

**क्या स्रोत सेक्शन स्वचालित रूप से संरक्षित होते हैं?**

सिर्फ स्लाइड क्लोन करने वाले बुनियादी लूप से नहीं। लक्ष्य में आवश्यक सेक्शन दोबारा बनाएं और सेक्शन ओवरलोड वाले [addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) का उपयोग करें जब सेक्शन संरचना को संरक्षित करना हो।

**क्या स्पीकर नोट्स और टिप्पणियाँ संरक्षित रहती हैं?**

वे क्लोन की गई स्लाइड के साथ कॉपी हो जाती हैं। नोट‑मास्टर स्टाइलिंग, टिप्पणी लेखक या थ्रेडेड रिव्यू डेटा पर निर्भर कार्यधाराओं में, मर्ज परिणाम की पुष्टि करें क्योंकि ये परिदृश्य प्रस्तुति‑स्तर संरचनाओं और स्लाइड‑स्तर सामग्री दोनों को शामिल करते हैं।

**ऑडियो, वीडियो, OLE ऑब्जेक्ट और हाइपरलिंक्स के साथ क्या होता है?**

एंबेडेड कंटेंट क्लोन की गई स्लाइड के संसाधन संबंधों के हिस्से के रूप में ले जाया जाता है। बाहरी लिंक बाहरी ही रहते हैं, इसलिए मर्ज के बाद उनके लक्ष्य फ़ाइल या URL उपलब्ध होने चाहिए।

**क्या सभी स्रोतों से एंबेडेड फ़ॉन्ट स्वचालित रूप से मर्ज्ड प्रस्तुति में उपलब्ध होते हैं?**

स्लाइड क्लोनिंग ही फ़ॉन्ट डिप्लॉयमेंट की गारंटी नहीं देती। लक्ष्य में एंबेडेड फ़ॉन्ट की जाँच करें और टाइपोग्राफी महत्वपूर्ण होने पर फ़ॉन्ट एंबेडिंग या बाहरी फ़ॉन्ट उपलब्धता को स्पष्ट रूप से प्रबंधित करें।

**मैं पासवर्ड‑सुरक्षित फ़ाइल को कैसे मर्ज करूँ?**

सही पासवर्ड के साथ इसे [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) से खोलें, फिर सामान्य रूप से उसकी स्लाइड्स क्लोन करें। आउटपुट सुरक्षा को अलग से कॉन्फ़िगर करें।

**बड़ी प्रस्तुतियों को संभालने का सही तरीका क्या है?**

बड़े बाइनरी ऑब्जेक्टों के कारण मेमोरी उपयोग को कम करने हेतु BLOB प्रबंधन उपयोग करें, बहुत बड़ी फ़ाइलों के लिए फ़ाइल‑पाथ लोडिंग को प्राथमिकता दें, स्रोत प्रस्तुतियों को तुरंत डिस्पोज़ करें, और अंतिम परिणाम को केवल आवश्यक होने पर ही सेव करें।

**क्या मैं कई थ्रेड से स्लाइड्स को मर्ज कर सकता हूँ?**

एक ही [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) इंस्टेंस को कई थ्रेड से एक साथ उपयोग न करें। प्रत्येक मर्ज ऑपरेशन को अपने स्वयं के प्रस्तुति इंस्टेंस तक सीमित रखें।