---
title: Android पर प्रस्तुतियों को कुशलतापूर्वक मर्ज करें
linktitle: प्रस्तुतियों को मर्ज करें
type: docs
weight: 40
url: /hi/androidjava/merge-presentation/
keywords:
- PowerPoint को मर्ज करें
- प्रस्तुतियों को मर्ज करें
- स्लाइड्स को मर्ज करें
- PPT को मर्ज करें
- PPTX को मर्ज करें
- ODP को मर्ज करें
- PowerPoint को मिलाएँ
- प्रस्तुतियों को मिलाएँ
- स्लाइड्स को मिलाएँ
- PPT को मिलाएँ
- PPTX को मिलाएँ
- ODP को मिलाएँ
- Android
- Java
- Aspose.Slides
description: "Android पर स्लाइड्स को क्लोन करके, मास्टर और लेआउट को नियंत्रित करके, स्लाइड सामग्री को रिसाइज़ करके, सेक्शन्स को संरक्षित करके, और सुरक्षित या बड़ी फ़ाइलों को संभालते हुए PowerPoint और OpenDocument प्रस्तुतियों को मर्ज करना सीखें।"
---
## **अवलोकन**

Aspose.Slides for Android via Java प्रस्तुतियों को एक [प्रेजेंटेशन](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) से दूसरे में स्लाइड क्लोन करके मिलाता है। मुख्य ऑपरेशन [ISlideCollection.addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) है, जो स्रोत स्लाइड की फ़ॉर्मेटिंग को बनाए रख सकता है या क्लोन की गई स्लाइड को लक्ष्य प्रस्तुति में एक मास्टर या लेआउट से जोड़ सकता है।

यह लेख सबसे सामान्य मर्जिंग वर्कफ़्लोज़ को कवर करता है:

- सभी स्लाइड्स को उनके स्रोत फ़ॉर्मेटिंग को बनाए रखते हुए मर्ज करें;
- चयनित स्लाइड्स को मर्ज करें;
- लक्ष्य प्रस्तुति से एक मास्टर लागू करें;
- लक्ष्य प्रस्तुति से एक विशिष्ट लेआउट लागू करें;
- मर्ज करने से पहले विभिन्न स्लाइड आकारों को सामान्यize करें;
- क्लोन की गई स्लाइड्स को एक सेक्शन में जोड़ें;
- कई प्रस्तुतियों को एक समग्र वर्कफ़्लो में सुरक्षित रूप से मर्ज करें;
- मास्टर, रिसोर्सेज, नोट्स, कमेंट्स, मीडिया, फ़ॉन्ट्स, पासवर्ड, बड़े फ़ाइलें, और मल्टीथ्रेडिंग से संबंधित मामलों को संभालें।

## **स्लाइड क्लोनिंग का मास्टर और लेआउट पर प्रभाव**

एक स्लाइड अपनी उपस्थिति का काफी हिस्सा अपने लेआउट और मास्टर से विरासत में प्राप्त करती है। इसलिए, आप जिस क्लोनिंग ओवरलोड का चयन करते हैं, वह निर्धारित करता है कि मर्ज की गई स्लाइड लक्ष्य प्रस्तुति में कैसे सम्मिलित होगी।

[ISlideCollection.addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidecollection/) को निम्नलिखित तरीके से उपयोग करें:

- `addClone(sourceSlide)` — स्रोत स्लाइड का लेआउट और फ़ॉर्मेटिंग बनाए रखें। आवश्यक होने पर, स्रोत मास्टर को स्वचालित रूप से लक्ष्य प्रस्तुति में क्लोन किया जा सकता है। Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर को ट्रैक करता है ताकि एक ही स्रोत मास्टर वाली दोहराव वाली स्लाइड्स मास्टर को बार‑बार क्लोन न करें।
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — क्लोन की गई स्लाइड को एक विशिष्ट लक्ष्य [IMasterSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslide/) से जोड़ें। Aspose.Slides उस मास्टर के तहत लेआउट प्रकार या नाम से मेल खाने वाला लेआउट खोजता है।
- `addClone(sourceSlide, destinationLayout)` — क्लोन की गई स्लाइड को सीधे एक विशिष्ट लक्ष्य [ILayoutSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutslide/) से जोड़ें।

`addClone` ओवरलोड में पास किया गया मास्टर या लेआउट **लक्ष्य** प्रस्तुति का होना चाहिए, स्रोत प्रस्तुति का नहीं।

## **पूरी प्रस्तुतियों को मर्ज करें और स्रोत फ़ॉर्मेटिंग रखें**

सबसे सरल मर्ज स्रोत प्रस्तुति की प्रत्येक स्लाइड को लक्ष्य प्रस्तुति में कॉपी करता है। यह विकल्प तब उपयुक्त है जब आयातित स्लाइड्स को उनका मूल थीम, मास्टर और लेआउट संबंध बनाए रखना चाहिए।

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

यदि स्रोत और लक्ष्य अलग‑अलग डिज़ाइन उपयोग करते हैं तो परिणामी प्रस्तुति में कई मास्टर हो सकते हैं। यह अपेक्षित है जब स्रोत फ़ॉर्मेटिंग को इरादतन संरक्षित किया जाता है।

## **चयनित स्लाइड्स को मर्ज करें**

आपको हर स्लाइड क्लोन करने की आवश्यकता नहीं है। निम्न उदाहरण केवल स्रोत प्रस्तुति से चुने गए स्लाइड इंडेक्स को आयात करता है।

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

जब स्लाइड इंडेक्स उपयोगकर्ता इनपुट या बाहरी कॉन्फ़िगरेशन से आते हैं तो क्लोन करने से पहले उनका सत्यापन करें।

## **लक्ष्य मास्टर का उपयोग करके स्लाइड्स को मर्ज करें**

जब आयातित स्लाइड्स को पहले से लक्ष्य प्रस्तुति में मौजूद मास्टर का अनुसरण करना चाहिए, तो [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) ओवरलोड का उपयोग करें।

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

Aspose.Slides निर्दिष्ट मास्टर के तहत स्रोत लेआउट के प्रकार या नाम से मेल खाने वाला उपयुक्त लेआउट चुनता है। यदि कोई उपयुक्त लेआउट नहीं मिलता और `allowCloneMissingLayout` `true` है, तो स्रोत लेआउट को क्लोन किया जाता है ताकि स्लाइड जोड़ी जा सके। यदि यह `false` है, तो एक [PptxEditException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pptxeditexception/) थ्रो किया जाता है।

यदि आप मर्ज को विफल करना चाहते हैं बजाय लक्ष्य मास्टर में अतिरिक्त लेआउट जोड़ने के, तो `false` उपयोग करें।

## **विशिष्ट लक्ष्य लेआउट का उपयोग करके स्लाइड्स को मर्ज करें**

जब आप जानते हैं कि आयातित स्लाइड्स को कौन सा लक्ष्य लेआउट उपयोग करना चाहिए, तो [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) ओवरलोड का प्रयोग करें।

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

लक्ष्य लेआउट लागू करने से विरासत में मिली लेआउट संबंध बदलता है; यह स्रोत स्लाइड की सामग्री को पुनः डिज़ाइन नहीं करता। यदि स्रोत और लक्ष्य लेआउट की प्लेसहोल्डर संरचना अलग है, तो परिणाम का निरीक्षण करें ताकि विरासत में मिली फ़ॉर्मेटिंग और प्लेसहोल्डर व्यवहार उपयुक्त हों।

## **भिन्न स्लाइड आकारों वाली प्रस्तुतियों को मर्ज करें**

विभिन्न स्लाइड आयामों वाली प्रस्तुतियों को मर्ज किया जा सकता है, लेकिन किसी स्लाइड को दूसरे आकार वाली प्रस्तुति में क्लोन करने से उसकी सामग्री स्वचालित रूप से नए कैनवास के अनुसार पुनः डिज़ाइन नहीं होती। आकार बदलने के कारण शेप्स शिफ्ट, स्केल या स्लाइड क्षेत्र के बाहर दिख सकते हैं।

एक व्यावहारिक तरीका यह है कि क्लोन करने से पहले स्रोत प्रस्तुति का आकार बदल दें। [SlideSize.setSize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) मेथड मौजूदा सामग्री को स्केल करता है जबकि स्लाइड आयाम बदलता है। [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slidesizescaletype/) सामग्री को अनुरोधित आकार के भीतर फिट करने के लिए स्केल करता है।

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

## **स्लाइड्स को प्रस्तुति सेक्शन में मर्ज करें**

बुनियादी स्लाइड‑क्लोनिंग लूप स्रोत प्रस्तुति की सेक्शन पदानुक्रम को पुनः बनाता नहीं है। यदि आउटपुट में सेक्शन महत्वपूर्ण हैं, तो लक्ष्य प्रस्तुति में सेक्शन बनाएं या चुनें और स्लाइड्स को स्पष्ट रूप से [addClone(ISlide, ISection)](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) के साथ क्लोन करें।

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

क्लोन की गई स्लाइड्स निर्दिष्ट लक्ष्य सेक्शन में जोड़ दी जाती हैं। कई स्रोत सेक्शनों को संरक्षित करने के लिए, लक्ष्य में वही सेक्शन फिर से बनाएं और प्रत्येक स्रोत स्लाइड को संबंधित लक्ष्य सेक्शन से मैप करें।

## **एकाधिक प्रस्तुतियों को सुरक्षित रूप से मर्ज करें**

निम्न एंड‑टु‑एंड उदाहरण पहला प्रस्तुति को लक्ष्य के रूप में लेता है, प्रत्येक अतिरिक्त स्रोत का स्लाइड आकार सामान्यize करता है, प्रत्येक स्रोत को केवल तब तक खोलता है जब वह कॉपी हो रहा हो, और अंत में अंतिम फ़ाइल सहेजता है।

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

यह आयातित स्लाइड्स की स्रोत फ़ॉर्मेटिंग को संरक्षित करने के लिए एक उपयोगी बेंचलिन है। यदि आपके आउटपुट को एकल लक्ष्य थीम का उपयोग करना है, तो सरल `addClone(slide)` कॉल को पहले दिखाए गए उपयुक्त लक्ष्य‑मास्टर या लक्ष्य‑लेआउट ओवरलोड से बदलें।

## **व्यावहारिक विचार**

### **मास्टर, लेआउट और फ़ॉर्मेटिंग फ़िडेलिटी**

डिफ़ॉल्ट स्लाइड क्लोनिंग स्वचालित रूप से आवश्यक स्रोत मास्टर को लक्ष्य प्रस्तुति में ला सकता है। Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर को ट्रैक करने के लिए एक आंतरिक रजिस्ट्री रखता है ताकि एक ही मास्टर को दोहराव से क्लोन न किया जाए। मैन्युअली क्लोन किए गए मास्टर इस रजिस्ट्री में नहीं होते, इसलिए यदि आपको मास्टर संरचना पर स्पष्ट नियंत्रण चाहिए तो पूर्व‑क्लोनिंग से बचें।

समान नाम वाले दो मास्टर या लेआउट को दृश्य रूप से समान मानने से बचें। यदि कॉरपोरेट टेम्पलेट को अंतिम रूप देना है, तो लक्ष्य मास्टर या लेआउट को स्पष्ट रूप से चुनें और मर्ज के बाद परिणाम सत्यापित करें।

### **नोट्स और कमेंट्स**

स्पीकर नोट्स और स्लाइड कमेंट्स स्लाइड सामग्री से जुड़े होते हैं और स्लाइड क्लोन होने पर कॉपी हो जाते हैं। Aspose.Slides [presentation notes](https://docs.aspose.com/slides/hi/androidjava/presentation-notes/) और [presentation comments](https://docs.aspose.com/slides/hi/androidjava/presentation-comments/) के लिए समर्पित API भी प्रदान करता है।

यदि नोट्स‑पेज फ़ॉर्मेटिंग महत्वपूर्ण है, तो मर्ज की गई प्रस्तुति को सत्यापित करें क्योंकि नोट्स‑मास्टर प्रस्तुति‑स्तर की वस्तु होते हैं और स्रोत फ़ाइलों में अलग हो सकते हैं। समीक्षात्मक वर्कफ़्लो में, विभिन्न लेखक या टेम्पलेट से फाइलें मिलाते समय कमेंट लेखक और थ्रेडेड कमेंट्स भी जांचें।

### **छवियाँ, ऑडियो, वीडियो, OLE ऑब्जेक्ट्स और बाह्य लिंक**

स्लाइड्स प्रस्तुति‑स्तर के रिसोर्सेज जैसे छवियाँ, एम्बेडेड ऑडियो, एम्बेडेड वीडियो और OLE डेटा को संदर्भित कर सकती हैं। केवल दृश्यमान शेप्स की कॉपी करने के बजाय पूरी स्लाइड को क्लोन करें ताकि Aspose.Slides स्लाइड‑से‑रिसोर्स संबंध बनाए रख सके।

एम्बेडेड और लिंक्ड रिसोर्सेज को अलग‑अलग संभालें। एक लिंक्ड ऑडियो, वीडियो, OLE ऑब्जेक्ट या हाइपरलिंक अपना बाहरी टार्गेट पर निर्भर रहता है; स्लाइड को क्लोन करने से बाहरी लिंक एम्बेडेड सामग्री में नहीं बदलते। मर्ज की गई प्रस्तुति को खोलने वाले पर्यावरण में लिंक्ड‑रिसोर्स पाथ और URL का परीक्षण करें।

Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर को ट्रैक करता है, लेकिन यह गारंटी नहीं देता कि असंबंधित स्रोत प्रस्तुतियों के समान बाइनरी रिसोर्सेज हमेशा डिडुप्लिकेट हो जाएंगे। यदि आउटपुट फ़ाइल आकार महत्वपूर्ण है, तो मर्ज पैकेज की जांच करें और परिणाम मापें बजाय implicit deduplication पर भरोसा करने के।

### **एम्बेडेड फ़ॉन्ट्स और फ़ॉन्ट उपलब्धता**

फ़ॉन्ट्स प्रस्तुति‑स्तर पर प्रबंधित होते हैं। यदि टाइपोग्राफी को विभिन्न मशीनों पर समान रखना है, तो यह मानें नहीं कि केवल स्लाइड क्लोनिंग से सभी आवश्यक फ़ॉन्ट लक्ष्य पर्यावरण में उपलब्ध हो जाएंगे। आप [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) से एम्बेडेड फ़ॉन्ट्स देख सकते हैं और [Embed Fonts in Presentations](https://docs.aspose.com/slides/hi/androidjava/embedded-font/) में वर्णित अनुसार एम्बेडिंग को स्पष्ट रूप से प्रबंधित कर सकते हैं।

साथ ही यह सत्यापित करें कि आप स्रोत फ़ाइलों में उपयोग किए गए फ़ॉन्ट्स को एम्बेड करने की अनुमति रखते हैं। फ़ॉन्ट लाइसेंस एम्बेडिंग को प्रतिबंधित कर सकते हैं।

### **पासवर्ड‑प्रोटेक्टेड प्रस्तुतियाँ**

एक पासवर्ड‑प्रोटेक्टेड स्रोत को उसके स्लाइड्स को क्लोन करने से पहले सफलतापूर्वक खोलना आवश्यक है। पासवर्ड को [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) के माध्यम से प्रदान करें।

```java
import com.aspose.slides.*;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation source = new Presentation("protected.pptx", loadOptions);
try {
    // डिक्रिप्टेड प्रस्तुति के साथ काम करें।
} finally {
    source.dispose();
}
```

एन्क्रिप्टेड स्रोत को खोलना स्वचालित रूप से लक्ष्य प्रस्तुति पर वही सुरक्षा लागू नहीं करता। आवश्यकता होने पर आउटपुट सुरक्षा को अलग से कॉन्फ़िगर करें।

### **बड़ी प्रस्तुतियाँ और मेमोरी उपयोग**

बड़ी प्रस्तुतियों में हाई‑रेजोल्यूशन छवियां, ऑडियो, वीडियो या अन्य बड़े बाइनरी ऑब्जेक्ट्स मेमोरी पर भारी पड़ सकते हैं। [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) BLOB हैंडलिंग और टेम्पररी‑फ़ाइल उपयोग के लिए नियंत्रण प्रदान करता है। बड़े‑फ़ाइल रणनीतियों के लिए देखें [Manage Presentation BLOBs](https://docs.aspose.com/slides/hi/androidjava/manage-blob/)।

बड़ी फ़ाइलों के लिए, संभव हो तो फ़ाइल‑पाथ से लोड करें, प्रत्येक स्रोत प्रस्तुति को मर्ज के बाद तुरंत डिस्पोज़ करें, और यदि वर्कफ़्लो चेकपॉइंट की मांग नहीं करता तो मध्यवर्ती परिणाम को बार‑बार सहेजने से बचें।

### **थ्रेड सुरक्षा**

एक ही [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) इंस्टेंस को एकाधिक थ्रेड्स से एक साथ लोड, मॉडिफ़ाइ, सहेज या क्लोन न करें। प्रत्येक प्रस्तुति इंस्टेंस को केवल एक मर्ज ऑपरेशन तक सीमित रखें। यदि आप स्वतंत्र जॉब्स को पैरललाइज़ करते हैं, तो स्वतंत्र प्रस्तुति इंस्टेंस का उपयोग करें और [Aspose.Slides मल्टीथ्रेडिंग गाइडलाइन](https://docs.aspose.com/slides/hi/androidjava/multithreading/) का पालन करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रत्येक स्रोत प्रस्तुति की मूल डिज़ाइन कैसे रखूँ?**

`addClone(sourceSlide)` को बिना कोई लक्ष्य मास्टर या लेआउट दिए उपयोग करें। जब आवश्यक हो तो Aspose.Slides आयातित स्लाइड द्वारा आवश्यक स्रोत मास्टर को स्वचालित रूप से क्लोन कर सकता है।

**इम्पोर्ट की गई स्लाइड्स को लक्ष्य थीम का उपयोग कैसे कराऊँ?**

एक लक्ष्य मास्टर स्वीकार करने वाले ओवरलोड का उपयोग करें। लक्ष्य प्रस्तुति से एक मास्टर पास करें, स्रोत से नहीं। Aspose.Slides प्रत्येक स्रोत स्लाइड को उस मास्टर के तहत उपयुक्त लेआउट पर मैप करने की कोशिश करेगा।

**कब मुझे लक्ष्य मास्टर के बजाय विशिष्ट लक्ष्य लेआउट का उपयोग करना चाहिए?**

जब प्रत्येक आयातित स्लाइड को एक ज्ञात लेआउट की आवश्यकता हो, तब विशिष्ट लेआउट का उपयोग करें। जब आप चाहते हैं कि Aspose.Slides स्रोत लेआउट प्रकार या नाम के आधार पर उस मास्टर की विभिन्न लेआउट्स में से चयन करे, तब मास्टर का उपयोग करें।

**भिन्न स्लाइड आकार वाली प्रस्तुतियों को मर्ज किया जा सकता है?**

हाँ, लेकिन स्लाइड कंटेंट लक्ष्य आयामों के अनुसार स्वचालित रूप से पुनः डिज़ाइन नहीं होता। पूर्व‑रिज़ाइज़ करने के लिए [SlideSize.setSize](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-) और [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/slidesizescaletype/) का उपयोग करें।

**क्या मैं PPT, PPTX और ODP प्रस्तुतियों को एक फ़ाइल में मर्ज कर सकता हूँ?**

हाँ। प्रत्येक स्रोत प्रस्तुति को लोड करें, आवश्यक स्लाइड्स को एक लक्ष्य में क्लोन करें, और लक्ष्य को समर्थित आउटपुट फ़ॉर्मेट में सहेजें। चूँकि प्रस्तुति फ़ॉर्मेट्स समान फीचर सेट नहीं देते, क्रॉस‑फ़ॉर्मेट मर्ज के बाद जटिल सामग्री की जाँच करें। देखें [Supported File Formats](https://docs.aspose.com/slides/hi/androidjava/supported-file-formats/)।

**क्या स्रोत सेक्शन स्वचालित रूप से संरक्षित होते हैं?**

केवल स्लाइड्स को क्लोन करने वाले बेसिक लूप से नहीं। लक्ष्य में आवश्यक सेक्शन फिर से बनाएं और सेक्शन‑ओवरलोड वाले [addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) का उपयोग करें जब सेक्शन संरचना को बनाए रखना आवश्यक हो।

**क्या स्पीकर नोट्स और कमेंट्स संरक्षित होते हैं?**

वे क्लोन की गई स्लाइड के साथ कॉपी हो जाते हैं। जब नोट्स‑मास्टर स्टाइलिंग, कमेंट लेखक या थ्रेडेड रिव्यू डेटा पर निर्भर वर्कफ़्लो हों, तो मर्ज के बाद परिणाम सत्यापित करें क्योंकि ये परिदृश्य प्रस्तुति‑स्तर की संरचनाओं के साथ-साथ स्लाइड‑स्तर की सामग्री को भी शामिल करते हैं।

**ऑडियो, वीडियो, OLE ऑब्जेक्ट्स और हाइपरलिंक्स का क्या होगा?**

एम्बेडेड कंटेंट क्लोन की गई स्लाइड के रिसोर्स रिलेशनशिप का हिस्सा बन कर ले जाता है। बाहरी लिंक बाहरी रहते हैं, इसलिए उनका टार्गेट फ़ाइल या URL मर्ज के बाद भी उपलब्ध होना चाहिए।

**क्या प्रत्येक स्रोत से एम्बेडेड फ़ॉन्ट्स मर्ज्ड प्रस्तुति में उपलब्ध रहेंगे?**

स्लाइड क्लोनिंग अकेले फ़ॉन्ट डिप्लॉयमेंट की गारंटी नहीं देता। लक्ष्य में एम्बेडेड फ़ॉन्ट्स की जांच करें और टाइपोग्राफी महत्वपूर्ण होने पर फ़ॉन्ट एम्बेडिंग या बाहरी फ़ॉन्ट उपलब्धता को स्पष्ट रूप से प्रबंधित करें।

**पासवर्ड‑प्रोटेक्टेड फ़ाइल को कैसे मर्ज करूँ?**

उसे सही [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) के साथ खोलें, फिर सामान्य रूप से उसकी स्लाइड्स क्लोन करें। आउटपुट सुरक्षा को अलग से कॉन्फ़िगर करें।

**बहुत बड़ी प्रस्तुतियों को कैसे संभालूँ?**

जब बड़े बाइनरी ऑब्जेक्ट्स मेमोरी में प्रमुख हो, तो BLOB मैनेजमेंट का उपयोग करें, बहुत बड़ी फ़ाइलों के लिए फ़ाइल‑पाथ लोडिंग को प्राथमिकता दें, स्रोत प्रस्तुतियों को मर्ज हो जाने पर तुरंत डिस्पोज़ करें, और जब तक आवश्यक न हो तब तक अंतिम परिणाम को ही सहेजें।

**क्या मैं कई थ्रेड्स से स्लाइड्स को मर्ज कर सकता हूँ?**

एक ही [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) इंस्टेंस को कई थ्रेड्स से एक साथ लोड, मॉडिफ़ाइ, सहेज या क्लोन न करें। प्रत्येक मर्ज ऑपरेशन को अलग‑अलग प्रस्तुति इंस्टेंस तक सीमित रखें।