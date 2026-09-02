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
description: "जावा में स्लाइड्स को क्लोन करके, मास्टर और लेआउट नियंत्रित करके, स्लाइड सामग्री का आकार बदलकर, सेक्शन को संरक्षित करके, तथा संरक्षित या बड़े फ़ाइलों को संभालते हुए PowerPoint और OpenDocument प्रस्तुतियों को कैसे मर्ज किया जाए, सीखें।"
---
## **अवलोकन**

Aspose.Slides for Java प्रस्तुतियों को एक [प्रस्तुति](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) से दूसरी में स्लाइड्स को क्लोन करके मिलाता है। मुख्य ऑपरेशन है [ISlideCollection.addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-), जो स्रोत स्लाइड के फ़ॉर्मेटिंग को संरक्षित कर सकता है या क्लोन की गई स्लाइड को गंतव्य प्रस्तुति के मास्टर या लेआउट से जोड़ सकता है।

यह लेख सबसे सामान्य मर्जिंग वर्कफ़्लोज़ को कवर करता है:

- सभी स्लाइड्स को उनके स्रोत फ़ॉर्मेटिंग को संरक्षित रखते हुए मर्ज करें;
- चयनित स्लाइड्स को मर्ज करें;
- गंतव्य प्रस्तुति के मास्टर को लागू करें;
- गंतव्य प्रस्तुति के विशिष्ट लेआउट को लागू करें;
- मर्ज करने से पहले विभिन्न स्लाइड आकारों को सामान्यीकृत करें;
- क्लोन की गई स्लाइड्स को एक सेक्शन में जोड़ें;
- कई प्रस्तुतियों को एक पूर्ण वर्कफ़्लो में मर्ज करें;
- मास्टर, संसाधन, नोट्स, टिप्पणी, मीडिया, फ़ॉन्ट, पासवर्ड, बड़े फ़ाइल, और मल्टीथ्रेडिंग संबंधी चिंताओं को संभालें।

## **स्लाइड क्लोनिंग का मास्टर और लेआउट पर प्रभाव**

एक स्लाइड अपनी उपस्थिति का अधिकांश हिस्सा अपने लेआउट और मास्टर से विरासत में प्राप्त करती है। इसलिए, आप जो क्लोन ओवरलोड चुनते हैं, वह निर्धारित करता है कि मर्ज की गई स्लाइड गंतव्य प्रस्तुति में कैसे एकीकृत होगी।

इनमें से किसी एक तरीके से [ISlideCollection.addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecollection/) का उपयोग करें:

- `addClone(sourceSlide)` — स्रोत स्लाइड के लेआउट और फ़ॉर्मेटिंग को संरक्षित रखें। आवश्यक होने पर, स्रोत मास्टर को स्वचालित रूप से गंतव्य प्रस्तुति में क्लोन किया जा सकता है। Aspose.Slides स्वचालित क्लोन किए गए मास्टर को ट्रैक करता है ताकि समान स्रोत मास्टर वाली दोहराई गई स्लाइड्स बार‑बार क्लोन न हों।
- `addClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — क्लोन की गई स्लाइड को एक विशिष्ट गंतव्य [IMasterSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterslide/) से जोड़ें। Aspose.Slides उस मास्टर के तहत लेआउट प्रकार या नाम से मेल खाने वाला लेआउट खोजता है।
- `addClone(sourceSlide, destinationLayout)` — क्लोन की गई स्लाइड को सीधे एक विशिष्ट गंतव्य [ILayoutSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutslide/) से जोड़ें।

`addClone` ओवरलोड को दिया गया मास्टर या लेआउट **गंतव्य** प्रस्तुति से संबंधित होना चाहिए, स्रोत प्रस्तुति से नहीं।

## **संपूर्ण प्रस्तुतियों को मर्ज करें और स्रोत फ़ॉर्मेटिंग रखें**

सबसे सरल मर्ज प्रत्येक स्लाइड को स्रोत प्रस्तुति से गंतव्य प्रस्तुति में कॉपी करता है। यह विकल्प तब उपयुक्त है जब आयातित स्लाइड्स को अपना मूल थीम, मास्टर और लेआउट संबंध बनाए रखने चाहिए।

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

परिणामस्वरूप प्रस्तुति में कई मास्टर हो सकते हैं जब स्रोत और गंतव्य अलग‑अलग डिज़ाइन उपयोग करते हैं। यह अपेक्षित है जब स्रोत फ़ॉर्मेटिंग जानबूझकर संरक्षित की जाती है।

## **चयनित स्लाइड्स को मर्ज करें**

आपको सभी स्लाइड्स को क्लोन करने की आवश्यकता नहीं है। निम्न उदाहरण केवल चयनित स्लाइड सूचकांकों को स्रोत प्रस्तुति से आयात करता है।

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

उपयोगकर्ता इनपुट या बाहरी कॉन्फ़िगरेशन से आने पर क्लोन करने से पहले स्लाइड सूचकांकों की सत्यापन करें।

## **गंतव्य मास्टर का उपयोग करके स्लाइड्स को मर्ज करें**

जब आयातित स्लाइड्स को पहले से गंतव्य प्रस्तुति में मौजूद मास्टर का पालन करना चाहिए, तब [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) ओवरलोड का उपयोग करें।

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

Aspose.Slides निर्दिष्ट मास्टर के तहत स्रोत लेआउट के प्रकार या नाम से मेल खाने वाला उपयुक्त लेआउट चुनता है। यदि कोई उपयुक्त लेआउट नहीं मिलता और `allowCloneMissingLayout` `true` है, तो स्रोत लेआउट को क्लोन किया जाता है ताकि स्लाइड जोड़ी जा सके। यदि यह `false` है, तो एक [PptxEditException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pptxeditexception/) फेंका जाता है।

यदि आप मर्ज को विफल करना चाहते हैं बजाय गंतव्य मास्टर में अतिरिक्त लेआउट जोड़ने के, तो `false` उपयोग करें।

## **विशिष्ट गंतव्य लेआउट का उपयोग करके स्लाइड्स को मर्ज करें**

जब आप ठीक-ठीक जानते हैं कि आयातित स्लाइड्स को कौन सा गंतव्य लेआउट उपयोग करना चाहिए, तब [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-) ओवरलोड का उपयोग करें।

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

गंतव्य लेआउट को लागू करने से विरासत में मिला हुआ लेआउट संबंध बदलता है; यह स्रोत स्लाइड सामग्री को पुनः डिज़ाइन नहीं करता। यदि स्रोत और गंतव्य लेआउट की प्लेसहोल्डर संरचनाएँ अलग हैं, तो परिणाम की जांच करें ताकि विरासत फ़ॉर्मेटिंग और प्लेसहोल्डर व्यवहार उपयुक्त हो।

## **भिन्न स्लाइड आकारों वाली प्रस्तुतियों को मर्ज करें**

भिन्न स्लाइड आयाम वाली प्रस्तुतियों को मर्ज किया जा सकता है, लेकिन किसी स्लाइड को अन्य आकार वाली प्रस्तुति में क्लोन करने से उसकी सामग्री स्वचालित रूप से नई कैनवास के लिए पुनः डिज़ाइन नहीं होती। इसलिए आकार, स्केल या स्थिति में अनअपेक्षित बदलाव दिख सकते हैं।

एक व्यावहारिक तरीका यह है कि क्लोन करने से पहले स्रोत प्रस्तुति को री‑साइज़ करें। [SlideSize.setSize](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slidesize/#setSize-float-float-int-) मेथड मौजूदा सामग्री को स्केल कर सकता है जबकि स्लाइड आयाम बदलता है। [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slidesizescaletype/) सामग्री को अनुरोधित आकार में फिट करने के लिए स्केल करता है।

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

री‑साइज़ करने से स्रोत प्रस्तुति ऑब्जेक्ट मेमोरी में बदल जाता है। यदि आपको मूल स्रोत प्रस्तुति को अन्य ऑपरेशनों के लिए अपरिवर्तित रखना है, तो मर्ज के लिए एक अलग इंस्टेंस खोलें।

## **स्लाइड्स को प्रस्तुति सेक्शन में मर्ज करें**

बेसिक स्लाइड‑क्लोन लूप स्रोत प्रस्तुति की सेक्शन पदानुक्रम को पुनः नहीं बनाता। यदि आउटपुट में सेक्शन मायने रखते हैं, तो गंतव्य प्रस्तुति में सेक्शन बनाएं या चुनें और स्लाइड्स को स्पष्ट रूप से [addClone(ISlide, ISection)](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) के साथ क्लोन करें।

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

क्लोन की गई स्लाइड्स निर्दिष्ट गंतव्य सेक्शन में जोड़ी जाती हैं। कई स्रोत सेक्शन को संरक्षित करने के लिए, उन सेक्शन को गंतव्य में पुनः बनाएं और प्रत्येक स्रोत स्लाइड को संबंधित गंतव्य सेक्शन से मैप करें।

## **एकाधिक प्रस्तुतियों को सुरक्षित रूप से मर्ज करें**

निम्न एंड‑टू‑एंड उदाहरण पहला प्रस्तुति को गंतव्य के रूप में उपयोग करता है, प्रत्येक अतिरिक्त स्रोत का स्लाइड आकार सामान्यीकृत करता है, प्रत्येक स्रोत को केवल तब तक खोलता है जब तक वह कॉपी नहीं हो रहा, और अंत में फ़ाइल को एक बार सहेजता है।

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

यह आयातित स्लाइड्स की स्रोत फ़ॉर्मेटिंग को संरक्षित करने के लिए एक उपयोगी बेसलाइन है। यदि आपके आउटपुट को एकल गंतव्य थीम उपयोग करनी हो, तो सरल `addClone(slide)` कॉल को पहले दिखाए गए उपयुक्त गंतव्य‑मास्टर या गंतव्य‑लेआउट ओवरलोड से बदलें।

## **व्यावहारिक विचार**

### **मास्टर, लेआउट और फ़ॉर्मेटिंग फ़िडेलिटी**

डिफ़ॉल्ट स्लाइड क्लोनिंग आवश्यक स्रोत मास्टर को स्वचालित रूप से गंतव्य प्रस्तुति में ला सकती है। Aspose.Slides स्वचालित क्लोन किए गए मास्टर के लिए एक आंतरिक रेजिस्ट्री रखता है ताकि समान मास्टर की दोहराई गई क्लोनिंग से बचा जा सके। मैन्युअल क्लोन किए गए मास्टर इस रेजिस्ट्री द्वारा ट्रैक नहीं होते, इसलिए जब तक आप मास्टर संरचना पर स्पष्ट नियंत्रण नहीं चाहते तब तक पूर्व‑क्लोनिंग से बचें।

एक ही नाम वाले दो मास्टर या लेआउट को दृश्य रूप से समान मानने से बचें। यदि कॉरपोरेट टेम्प्लेट अंतिम लुक को नियंत्रित करता है, तो स्पष्ट रूप से गंतव्य मास्टर या लेआउट चुनें और मर्ज के बाद परिणाम सत्यापित करें।

### **नोट्स और टिप्पणियां**

स्पीकर नोट्स और स्लाइड कमेंट्स स्लाइड सामग्री से जुड़े होते हैं और स्लाइड क्लोन होने पर कॉपी हो जाते हैं। Aspose.Slides विशेष रूप से [presentation notes](https://docs.aspose.com/slides/hi/java/presentation-notes/) और [presentation comments](https://docs.aspose.com/slides/hi/java/presentation-comments/) के लिए API प्रदान करता है।

यदि नोट‑पेज फ़ॉर्मेटिंग महत्वपूर्ण है, तो मर्ज किए गए प्रस्तुति की जाँच करें क्योंकि नोट मास्टर प्रस्तुति‑स्तर के ऑब्जेक्ट होते हैं और स्रोत फ़ाइलों के बीच भिन्न हो सकते हैं। रिव्यू वर्कफ़्लो के लिए विभिन्न लेखक या टेम्प्लेट से फ़ाइलें मिलाने के बाद टिप्पणी लेखक और थ्रेडेड कमेंट्स भी सत्यापित करें।

### **छवियां, ऑडियो, वीडियो, OLE ऑब्जेक्ट और बाहरी लिंक**

स्लाइड्स प्रस्तुति‑स्तर के संसाधन जैसे चित्र, एंबेडेड ऑडियो, एंबेडेड वीडियो और OLE डेटा को संदर्भित कर सकती हैं। केवल दृश्यमान शैप्स को कॉपी करने के बजाय पूरी स्लाइड को क्लोन करें ताकि Aspose.Slides उसके संसाधन संबंधों को बनाए रख सके।

एम्बेडेड और लिंक्ड संसाधनों को अलग‑अलग संभालें। लिंक्ड ऑडियो, वीडियो, OLE ऑब्जेक्ट या हाइपरलिंक अपने बाहरी लक्ष्य पर निर्भर रहता है; स्लाइड क्लोन करने से लिंक्ड सामग्री एंबेडेड नहीं होती। मर्ज किए गए प्रस्तुति के खुले वातावरण में लिंक्ड‑रिसोर्स पाथ और URL की जांच करें।

Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर को ट्रैक करता है, पर यह सामान्य गारंटी नहीं है कि असंबंधित स्रोत प्रस्तुतियों के समान बाइनरी संसाधन हमेशा डिडुप्लिकेट होंगे। यदि आउटपुट फ़ाइल आकार महत्वपूर्ण है, तो मर्ज किए गए पैकेज का निरीक्षण करें और परिणाम मापें बजाय अप्रत्यक्ष डिडुप्लिकेशन पर भरोसा करने के।

### **एंबेडेड फ़ॉन्ट और फ़ॉन्ट उपलब्धता**

फ़ॉन्ट प्रस्तुति‑स्तर पर प्रबंधित होते हैं। यदि टाइपोग्राफी को सभी मशीनों पर समान रहना है, तो केवल स्लाइड क्लोनिंग यह गारंटी नहीं देती कि आवश्यक फ़ॉन्ट गंतव्य पर्यावरण में उपलब्ध हैं। आप [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/hi/java/com.aspose.slides/fontsmanager/#getEmbeddedFonts--) के साथ एंबेडेड फ़ॉन्ट देख सकते हैं और [Embed Fonts in Presentations](https://docs.aspose.com/slides/hi/java/embedded-font/) में वर्णित अनुसार एंबेडिंग को स्पष्ट रूप से नियंत्रित कर सकते हैं।

साथ ही यह सुनिश्चित करें कि स्रोत फ़ाइलों द्वारा उपयोग किए गए फ़ॉन्ट को एंबेड करने की अनुमति आपके पास है। फ़ॉन्ट लाइसेंस एंबेडिंग को प्रतिबंधित कर सकते हैं।

### **पासवर्ड‑संरक्षित प्रस्तुतियां**

पासवर्ड‑संरक्षित स्रोत को उसके स्लाइड्स को क्लोन करने से पहले सफलतापूर्वक खोलना आवश्यक है। पासवर्ड को [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) के माध्यम से प्रदान करें।

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

एन्क्रिप्टेड स्रोत को खोलने से गंतव्य प्रस्तुति पर स्वतः वही सुरक्षा लागू नहीं होती। आवश्यक होने पर आउटपुट सुरक्षा को अलग से कॉन्फ़िगर करें।

### **बड़ी प्रस्तुतियां और मेमोरी उपयोग**

उच्च‑रिज़ॉल्यूशन चित्र, ऑडियो, वीडियो या अन्य बड़े बाइनरी ऑब्जेक्ट वाली बड़ी प्रस्तुतियों से काफी मेमोरी का उपयोग हो सकता है। [LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) BLOB हैंडलिंग और टेम्पररी‑फ़ाइल उपयोग के लिए नियंत्रण प्रदान करता है। बड़े‑फ़ाइल रणनीतियों के लिए देखें [Manage Presentation BLOBs](https://docs.aspose.com/slides/hi/java/manage-blob/)।

बड़ी फ़ाइलों के लिए संभव हो तो फ़ाइल‑पाथ से लोड करें, प्रत्येक स्रोत प्रस्तुति को मर्ज हो जाने पर तुरंत डिस्पोज़ करें, और मध्यवर्ती परिणामों को बार‑बार सहेजने से बचें जब तक वर्कफ़्लो में चेकपॉइंट की आवश्यकता न हो।

### **थ्रेड सुरक्षा**

एक ही [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) इंस्टेंस को कई थ्रेड्स से एक साथ लोड, संशोधित, सहेज या क्लोन न करें। प्रत्येक प्रस्तुति इंस्टेंस को एक मर्ज ऑपरेशन तक सीमित रखें। यदि आप स्वतंत्र कार्यों को पैरेललाइज़ करते हैं, तो स्वतंत्र प्रस्तुति इंस्टेंस का उपयोग करें और [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/hi/java/multithreading/) का पालन करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रत्येक स्रोत प्रस्तुति का मूल डिज़ाइन कैसे रखूं?**

एक गंतव्य मास्टर या लेआउट निर्दिष्ट किए बिना [`addClone(sourceSlide)`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-) का उपयोग करें। आवश्यक होने पर Aspose.Slides स्वचालित रूप से स्रोत मास्टर को क्लोन कर देता है।

**आयातित स्लाइड्स को गंतव्य थीम का उपयोग कैसे करवाऊँ?**

गंतव्य मास्टर को स्वीकार करने वाले ओवरलोड का उपयोग करें। गंतव्य प्रस्तुति से एक मास्टर पास करें, स्रोत से नहीं। Aspose.Slides प्रत्येक स्रोत स्लाइड को उस मास्टर के तहत उपयुक्त लेआउट से मैप करने का प्रयास करेगा।

**जब मुझे गंतव्य मास्टर की बजाय विशिष्ट गंतव्य लेआउट का उपयोग करना चाहिए?**

जब प्रत्येक आयातित स्लाइड को एक ज्ञात लेआउट उपयोग करना हो, तो विशिष्ट लेआउट चुनें। जब आप चाहते हैं कि Aspose.Slides स्रोत लेआउट प्रकार या नाम के आधार पर उस मास्टर के कई लेआउट में से चयन करे, तो मास्टर चुनें।

**क्या विभिन्न स्लाइड आकार वाली प्रस्तुतियों को मर्ज किया जा सकता है?**

हां, लेकिन स्लाइड सामग्री स्वचालित रूप से गंतव्य आयामों के लिए पुनः डिज़ाइन नहीं होती। यदि स्थिर प्लेसमेंट चाहिए, तो पहले [SlideSize.setSize](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slidesize/#setSize-float-float-int-) और [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/hi/java/com.aspose.slides/slidesizescaletype/) के साथ स्रोत प्रस्तुति को री‑साइज़ करें।

**क्या मैं PPT, PPTX और ODP प्रस्तुतियों को एक फ़ाइल में मर्ज कर सकता हूँ?**

हां। प्रत्येक स्रोत प्रस्तुति को लोड करें, आवश्यक स्लाइड्स को एक गंतव्य में क्लोन करें, और गंतव्य को समर्थित आउटपुट फ़ॉर्मेट में सहेजें। चूँकि विभिन्न फ़ॉर्मेट समान फीचर सेट नहीं प्रदान करते, क्रास‑फ़ॉर्मेट मर्ज के बाद जटिल सामग्री को सत्यापित करना आवश्यक है। देखें [Supported File Formats](https://docs.aspose.com/slides/hi/java/supported-file-formats/)।

**क्या स्रोत सेक्शन स्वचालित रूप से संरक्षित होते हैं?**

सिर्फ स्लाइड क्लोन करने वाले बेसिक लूप से नहीं। आवश्यक सेक्शन को गंतव्य में पुनः बनाएं और सेक्शन संरचना को संरक्षित करने के लिए [addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islidecollection/#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) के सेक्शन ओवरलोड का उपयोग करें।

**क्या स्पीकर नोट्स और टिप्पणियां संरक्षित रहती हैं?**

हां, वे क्लोन की गई स्लाइड के साथ कॉपी हो जाती हैं। नोट‑मास्टर स्टाइलिंग, टिप्पणी लेखक या थ्रेडेड रिव्यू डेटा पर निर्भर वर्कफ़्लो के लिए, मर्ज के बाद परिणाम सत्यापित करें क्योंकि ये परिदृश्य प्रस्तुति‑स्तर की संरचनाओं को भी प्रभावित करते हैं।

**ऑडियो, वीडियो, OLE ऑब्जेक्ट और हाइपरलिंक का क्या होता है?**

एम्बेडेड कंटेंट क्लोन की गई स्लाइड के संसाधन संबंधों के भाग के रूप में ले जाया जाता है। बाहरी लिंक बाहरी ही रहते हैं, इसलिए उनके लक्ष्य फ़ाइल या URL को मर्ज के बाद उपलब्ध होना चाहिए।

**क्या सभी स्रोतों के एंबेडेड फ़ॉन्ट मर्ज किए गए प्रस्तुति में उपलब्ध होंगे?**

स्लाइड क्लोनिंग केवल फ़ॉन्ट डिप्लॉयमेंट की गारंटी नहीं देती। गंतव्य के एंबेडेड फ़ॉन्ट की जाँच करें और फ़ॉन्ट एंबेडिंग या बाहरी फ़ॉन्ट उपलब्धता को स्पष्ट रूप से प्रबंधित करें जब टाइपोग्राफी महत्वपूर्ण हो।

**मैं पासवर्ड‑संरक्षित फ़ाइल को कैसे मर्ज करूँ?**

सही पासवर्ड के साथ [LoadOptions.setPassword](https://reference.aspose.com/slides/hi/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) का उपयोग करके फ़ाइल खोलें, फिर सामान्य रूप से उसकी स्लाइड्स क्लोन करें। आउटपुट सुरक्षा को अलग से कॉन्फ़िगर करें।

**बड़ी प्रस्तुतियों को मैं कैसे संभालूँ?**

बड़े बाइनरी ऑब्जेक्ट के कारण मेमोरी की खपत बढ़ती है; BLOB मैनेजमेंट विकल्पों का उपयोग करें, बहुत बड़ी फ़ाइलों के लिए फ़ाइल‑पाथ लोडिंग को प्राथमिकता दें, स्रोत प्रस्तुतियों को जल्दी डिस्पोज़ करें, और केवल आवश्यक होने पर अंतिम परिणाम सहेजें।

**क्या मैं कई थ्रेड्स से स्लाइड्स को मर्ज कर सकता हूँ?**

एक ही [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) इंस्टेंस को कई थ्रेड्स से एक साथ उपयोग न करें। प्रत्येक मर्ज ऑपरेशन को अलग‑अलग प्रस्तुति इंस्टेंस तक सीमित रखें।