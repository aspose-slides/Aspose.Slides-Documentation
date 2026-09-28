---
title: Java में स्लाइड लेआउट लागू या बदलें
linktitle: स्लाइड लेआउट
type: docs
weight: 60
url: /hi/java/slide-layout/
keywords:
- स्लाइड लेआउट
- सामग्री लेआउट
- प्लेसहोल्डर
- प्रस्तुति डिज़ाइन
- स्लाइड डिज़ाइन
- अप्रयुक्त लेआउट
- फूटर दृश्यता
- टाइटल स्लाइड
- टाइटल और कंटेंट
- सेक्शन हेडर
- दो कंटेंट
- तुलना
- केवल टाइटल
- खाली लेआउट
- कैप्शन के साथ कंटेंट
- कैप्शन के साथ चित्र
- टाइटल और वर्टिकल टेक्स्ट
- वर्टिकल टाइटल और टेक्स्ट
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में स्लाइड लेआउट लागू करें, बनाएं और संशोधित करें, प्लेसहोल्डर जोड़ें, अप्रयुक्त लेआउट हटाएँ, और फूटर दृश्यता नियंत्रित करें।"
---
## **समीक्षा**

एक स्लाइड लेआउट शीर्षक, पाठ, चित्र, चार्ट और तालिकाओं जैसी प्लेसहोल्डर्स की स्थिति और स्वरूपण को परिभाषित करता है। लेआउट लागू करने से स्लाइड्स की संरचना सुसंगत रहती है जबकि प्रत्येक स्लाइड अपनी अलग सामग्री रख सकती है।

सबसे सामान्य लेआउट्स में शामिल हैं:

- **टाइटल स्लाइड**: शीर्षक और उपशीर्षक प्लेसहोल्डर्स शामिल करता है।
- **टाइटल और कंटेंट**: एक शीर्षक प्लेसहोल्डर और एक सामान्य‑उद्देश्य कंटेंट प्लेसहोल्डर शामिल करता है।
- **ब्लैंक**: कोई कंटेंट प्लेसहोल्डर नहीं होता और जब प्रत्येक आकार को मैन्युअली स्थित किया जाना हो तब उपयोगी होता है।

## **लेआउट वंशानुक्रम को समझें**

एक प्रस्तुति में तीन संबंधित स्तर होते हैं:

1. एक [मास्टर स्लाइड](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterslide/) थीम, साझा स्वरूपण, पृष्ठभूमि और सामान्य वस्तुओं को परिभाषित करता है।
1. एक [लेआउट स्लाइड](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutslide/) एक मास्टर से जुड़ी होती है और प्लेसहोल्डर्स की विशिष्ट व्यवस्था निर्धारित करती है।
1. एक [नॉर्मल स्लाइड](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/) एक लेआउट का उपयोग करती है और उस स्लाइड के लिए दर्ज की गई सामग्री को संग्रहीत करती है।

एक नॉर्मल स्लाइड अपने लेआउट से थीम और स्वरूपण विरासत में प्राप्त करती है, और लेआउट अपने मास्टर से विरासत में लेता है। नॉर्मल स्लाइड पर सीधे सेट किया गया मान उस स्तर पर विरासत में मिले मान को ओवरराइड कर देता है। जब नॉर्मल स्लाइड बनाई जाती है, तो उसके प्लेसहोल्डर शैप्स चयनित लेआउट से उत्पन्न होते हैं, जबकि उन प्लेसहोल्डर्स में दर्ज सामग्री नॉर्मल स्लाइड से संबंधित होती है।

स्लाइड्स बनाने से पहले किसी लेआउट में आवश्यक प्लेसहोल्डर्स जोड़ें। बाद में लेआउट में एक और प्लेसहोल्डर जोड़ने से मौजूदा नॉर्मल स्लाइड्स में स्वचालित रूप से संबंधित प्लेसहोल्डर शैप नहीं जुड़ता।

इस संबंध के दो महत्वपूर्ण परिणाम होते हैं:

- लेआउट पर विरासत में मिला स्वरूपण या मौजूदा प्लेसहोल्डर ज्यामिति में परिवर्तन सभी निर्भर स्लाइड्स को अपडेट कर सकता है। उपयोग में मौजूद लेआउट को संपादित करने से पहले उसकी निर्भर स्लाइड्स की जाँच करें और परिणामस्वरूप प्रस्तुति को समीक्षा करें।
- किसी लेआट को हटाया नहीं जा सकता यदि वह अभी भी किसी स्लाइड द्वारा उपयोग में है। पहले उसकी निर्भर स्लाइड्स को किसी अन्य लेआउट पर पुनः असाइन करें, या सिर्फ अनउपयोग किए गए लेआउट्स को ही हटाएँ।

इस पदानुक्रम के शीर्ष स्तर के बारे में अधिक जानकारी के लिए देखें: [Slide Master](/slides/hi/java/slide-master/)।

किसी एक स्लाइड या साझा लेआउट पर विरासत में मिले लोगो या सजावटी मास्टर शैप्स को छिपाने के लिए देखें: [Control the Visibility of Master Graphics](/slides/hi/java/slide-master/)। उदाहरण दो स्लाइड्स की तुलना करता है जो एक ही मास्टर का उपयोग करती हैं।

## **स्लाइड लेआउट चुनें और लागू करें**

जब प्रस्तुति मानक PowerPoint लेआउट परिभाषाओं का पालन करती है, तो लेआउट प्रकार का उपयोग करें। लेआउट नाम उपयोगकर्ता‑संपादित योग्य होते हैं और स्थानीयकृत किए जा सकते हैं, इसलिए नाम‑आधारित चयन तभी विश्वसनीय होता है जब आप स्रोत टेम्पलेट पर नियंत्रण रखते हों।

निम्न उदाहरण पहले मास्टर पर **Title and Content** लेआउट को खोजता है। यदि वह लेआउट उपलब्ध नहीं है, तो यह जानबूझकर **Blank** पर फ़ॉलबैक करता है। दूसरा null जांच आवश्यक है क्योंकि प्रस्तुति में केवल कस्टम लेआउट हो सकते हैं। चयनित लेआउट फिर पहले नॉर्मल स्लाइड पर [ISlide.setLayoutSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) विधि के माध्यम से लागू किया जाता है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide targetLayout = layoutSlides.getByType(SlideLayoutType.TitleAndObject);

    if (targetLayout == null) {
        targetLayout = layoutSlides.getByType(SlideLayoutType.Blank);
    }

    if (targetLayout == null) {
        throw new IllegalStateException("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

लेआउट बदलने से सीधे स्लाइड में जोड़े गए सामान्य शैप्स हटते नहीं हैं। हालाँकि, प्लेसहोल्डर स्थितियाँ, विरासत में मिला स्वरूपण, और मौजूदा प्लेसहोल्डर्स व नए लेआउट के बीच का मिलान बदल सकता है, इसलिए विभिन्न लेआउट्स के बीच स्विच करते समय आउटपुट की जांच करें।

## **एक लेआउट स्लाइड जोड़ें**

चयन और निर्माण अलग‑अलग संचालन हैं। पिछले उदाहरण में मौजूदा लेआउट को चुना गया था; यह नया लेआउट नहीं बनाता। लेआउट बनाने के लिए लक्ष्य मास्टर की लेआउट संग्रह पर [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) विधि को कॉल करें।

निम्न उदाहरण हमेशा एक नया **Title and Content** लेआउट `Report Title and Content` नाम से जोड़ता है, फिर उसके आधार पर एक नॉर्मल स्लाइड जोड़ता है। लेआउट नाम संग्रह में अद्वितीय होना चाहिए।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide reportLayout = masterSlide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

केवल तभी लेआउट जोड़ें जब टेम्पलेट को वास्तव में एक अतिरिक्त पुन: प्रयोग योग्य संरचना की आवश्यकता हो। यदि उपयुक्त लेआउट पहले से मौजूद है, तो उसे चुनें और पुनः उपयोग करें, डुप्लिकेट बनाने के बजाय।

## **लेआउट स्लाइड में प्लेसहोल्डर्स जोड़ें**

[ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) विधि एक [ILayoutPlaceholderManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutplaceholdermanager/) प्रदान करती है ताकि लेआउट में प्लेसहोल्डर शैप्स जोड़े जा सकें।

| PowerPoint प्लेसहोल्डर | `ILayoutPlaceholderManager` विधि |
| -------------------------- | ----------------------------------- |
| ![Content](content.png) | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![Content (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![Text](text.png) | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![Text (Vertical)](textV.png) | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![Picture](picture.png) | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![Chart](chart.png) | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![Table](table.png) | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![Media](media.png) | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![Online Image](onlineImage.png) | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

निम्न उदाहरण जाँचता है कि **Blank** लेआउट मौजूद है, उसमें चार प्लेसहोल्डर जोड़ता है, और फिर संशोधित लेआउट का उपयोग करके एक नॉर्मल स्लाइड बनाता है। क्रम जानबूझकर इस प्रकार है: प्लेसहोल्डर पहले जोड़े जाते हैं, फिर नॉर्मल स्लाइड बनाई जाती है, ताकि Aspose.Slides उस स्लाइड पर संबंधित प्लेसहोल्डर शैप्स उत्पन्न कर सके।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ILayoutSlide blankLayout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayout == null) {
        throw new IllegalStateException("The presentation does not contain a Blank layout slide.");
    }

    ILayoutPlaceholderManager placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
विरासत में मिला स्वरूपण या मौजूदा लेआउट प्लेसहोल्डर की ज्यामिति में परिवर्तन निर्भर स्लाइड्स को प्रभावित कर सकता है। नया जोड़ा गया लेआउट प्लेसहोल्डर मौजूदा नॉर्मल स्लाइड्स में स्वचालित रूप से नहीं भरता। लेआउट परिवर्तन को प्रस्तुति की कॉपी पर टेस्ट करें और प्रत्येक निर्भर स्लाइड की जांच करें।
{{% /alert %}}

## **अनउपयोग किए गए लेआउट स्लाइड्स हटाएँ**

लेआउट्स को हटाने के लिए [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) विधि का उपयोग करें जो किसी नॉर्मल स्लाइड द्वारा संदर्भित नहीं हैं। यह विधि अभी भी उपयोग में मौजूद लेआउट्स को अपरिवर्तित रखती है।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

एक विशिष्ट लेआउट हटाने के लिए पहले उसकी [hasDependingSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--) या [getDependingSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) विधि को उपयोग करें। किसी भी निर्भर स्लाइड को पुनः असाइन करें और फिर [ILayoutSlide.remove](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutslide/#remove--) को कॉल करें। उपयोग में मौजूद लेआउट को हटाने का प्रयास करने पर [PptxEditException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pptxeditexception/) उत्पन्न होगा।

## **लेआउट स्लाइड पर फुटर दृश्यमानता नियंत्रित करें**

एक लेआउट का अपना फुटर, स्लाइड‑नंबर और दिनांक‑समय प्लेसहोल्डर होता है। इन प्लेसहोल्डर्स को नियंत्रित करने के लिए [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) विधि का उपयोग करें। यह तब उपयोगी होता है जब उदाहरण के लिए कंटेंट लेआउट में फुटर दिखाना हो लेकिन टाइटल लेआउट में न दिखे।

निम्न उदाहरण लेआउट को सुरक्षित रूप से चुनता है और उसके फुटर तत्वों को दृश्यमान बनाता है:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);

    if (layoutSlide == null) {
        layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);
    }

    if (layoutSlide == null) {
        throw new IllegalStateException("The presentation does not contain a suitable layout slide.");
    }

    ILayoutSlideHeaderFooterManager headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **मास्टर और उसकी चाइल्ड लेआउट्स पर फुटर दृश्यमानता नियंत्रित करें**

मास्टर पदानुक्रम में सुसंगत फुटर सेटिंग्स लागू करने के लिए [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--) विधि का उपयोग करें। [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterslideheaderfootermanager/) की प्रसार विधियाँ मास्टर, उसकी निर्भर लेआउट स्लाइड्स और नॉर्मल स्लाइड्स पर लागू होती हैं; वे केवल एक नॉर्मल स्लाइड को नहीं लक्ष्य करतीं।

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**मास्टर स्लाइड और लेआउट स्लाइड में क्या अंतर है?**

मास्टर स्लाइड प्रस्तुति की थीम और साझा स्वरूपण को परिभाषित करती है। लेआउट स्लाइड एक मास्टर से जुड़ी होती है और प्लेसहोल्डर्स की पुन: उपयोग योग्य व्यवस्था परिभाषित करती है। नॉर्मल स्लाइड्स उन लेआउट्स का उपयोग करती हैं और स्लाइड‑विशिष्ट सामग्री संग्रहीत करती हैं।

**क्या मैं एक लेआउट स्लाइड को एक प्रस्तुति से दूसरी में कॉपी कर सकता हूँ?**

हां। गंतव्य संग्रह में कॉपी जोड़ने के लिए [addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) विधि का उपयोग करें। जब प्रस्तुति के बीच कॉपी किया जाता है, तो स्रोत लेआउट द्वारा उपयोग किए गए फ़ॉन्ट, थीम, चित्र और अन्य संसाधनों की भी जाँच करें।

**यदि मैं किसी उपयोग में मौज़ूद लेआउट को संशोधित करूँ तो क्या होता है?**

निर्भर स्लाइड्स लेआउट में हुए परिवर्तन को विरासत में लेती हैं, जब तक वे स्थानीय रूप से प्रभावित स्वरूपण या वस्तुओं को ओवरराइड नहीं करते। प्लेसहोल्डर ज्यामिति और विरासत में मिला स्टाइल कई स्लाइड्स पर एक साथ बदल सकता है। संपादन से पहले प्रभावित स्लाइड्स की पहचान के लिए [getDependingSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) का उपयोग करें।

**यदि मैं अभी भी उपयोग में मौजूद लेआउट को हटाने का प्रयास करूँ तो क्या होगा?**

Aspose.Slides [PptxEditException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pptxeditexception/) उत्पन्न करेगा। पहले निर्भर स्लाइड्स को पुनः असाइन करें, या केवल अनरेफ़रेंस्ड लेआउट्स को हटाने के लिए [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) का उपयोग करें।