---
title: "Android पर स्लाइड लेआउट लागू करें या बदलें"
linktitle: "स्लाइड लेआउट"
type: docs
weight: 60
url: /hi/androidjava/slide-layout/
keywords:
- स्लाइड लेआउट
- सामग्री लेआउट
- प्लेसहोल्डर
- प्रेजेंटेशन डिजाइन
- स्लाइड डिजाइन
- अप्रयुक्त लेआउट
- फ़ूटर दृश्यता
- शीर्षक स्लाइड
- शीर्षक और सामग्री
- सेक्शन हेडर
- दो सामग्री
- तुलना
- केवल शीर्षक
- खाली लेआउट
- कैप्शन वाली सामग्री
- कैप्शन वाली चित्र
- शीर्षक और ऊर्ध्वाधर टेक्स्ट
- ऊर्ध्वाधर शीर्षक और टेक्स्ट
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android में स्लाइड लेआउट को प्रबंधित और अनुकूलित करें। लेआउट प्रकार, प्लेसहोल्डर नियंत्रण, और फ़ूटर दृश्यता को Java कोड उदाहरणों के माध्यम से अन्वेषण करें।"
---
## **परिचय**

एक स्लाइड लेआउट स्लाइड पर सामग्री के लिए प्लेसहोल्डर बॉक्स और फ़ॉर्मेटिंग की व्यवस्था को परिभाषित करता है। यह नियंत्रित करता है कि कौन से प्लेसहोल्डर उपलब्ध हैं और वे कहां दिखाई देते हैं। स्लाइड लेआउट आपको प्रस्तुतियों को तेज़ और सुसंगत रूप से डिज़ाइन करने में मदद करते हैं— चाहे आप कुछ सरल या अधिक जटिल बना रहे हों। PowerPoint में सबसे सामान्य स्लाइड लेआउट में शामिल हैं:

**Title Slide layout** – दो टेक्स्ट प्लेसहोल्डर शामिल करता है: एक शीर्षक के लिए और एक उपशीर्षक के लिए।

**Title and Content layout** – ऊपर एक छोटा शीर्षक प्लेसहोल्डर और नीचे मुख्य सामग्री (जैसे टेक्स्ट, बुलेट पॉइंट, चार्ट, छवियां, आदि) के लिए बड़ा प्लेसहोल्डर प्रस्तुत करता है।

**Blank layout** – कोई प्लेसहोल्डर नहीं होता, जिससे आप स्लाइड को ख़ाली स्थित से पूरी तरह नियंत्रित कर सकते हैं।

स्लाइड लेआउट स्लाइड मास्टर का हिस्सा होते हैं, जो प्रस्तुति के लिए लेआउट शैलियों को परिभाषित करने वाला शीर्ष‑स्तर स्लाइड है। आप स्लाइड मास्टर के माध्यम से लेआउट स्लाइड तक पहुंच और उनके संशोधन कर सकते हैं—या तो उनके प्रकार, नाम, या अनूठे आईडी द्वारा। वैकल्पिक रूप से, आप सीधे प्रस्तुति के भीतर किसी विशिष्ट लेआउट स्लाइड को संपादित कर सकते हैं।

PowerPoint के लिए Android पर Aspose.Slides के साथ स्लाइड लेआउट पर काम करने हेतु आप उपयोग कर सकते हैं:

- मेथड जैसे [getLayoutSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) और [getMasters](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getMasters--) जो [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास के तहत उपलब्ध हैं
- टाइप जैसे [ILayoutSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/), और [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
मास्टर स्लाइड के साथ काम करने के बारे में अधिक जानने के लिए, [Slide Master](/slides/hi/androidjava/slide-master/) लेख देखें।
{{% /alert %}}

## **प्रेजेंटेशन में स्लाइड लेआउट जोड़ें**

अपनी स्लाइड्स की उपस्थिति और संरचना को अनुकूलित करने के लिए, आपको एक प्रेजेंटेशन में नई लेआउट स्लाइड जोड़ने की आवश्यकता हो सकती है। Aspose.Slides for Android आपको यह जांचने की अनुमति देता है कि कोई विशिष्ट लेआउट पहले से मौजूद है या नहीं, आवश्यकता पड़ने पर नई लेआउट जोड़ें, और उस लेआउट पर आधारित स्लाइड्स सम्मिलित करें।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएँ।
1. [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterlayoutslidecollection/) तक पहुँचें।
1. जाँचें कि इच्छित लेआउट स्लाइड संग्रह में पहले से मौजूद है या नहीं। यदि नहीं, तो आवश्यक लेआउट स्लाइड जोड़ें।
1. नई लेआउट स्लाइड के आधार पर एक खाली स्लाइड जोड़ें।
1. प्रेजेंटेशन सहेजें।

```java
// PowerPoint फ़ाइल का प्रतिनिधित्व करने वाली Presentation क्लास का इंस्टेंस बनाएं।
Presentation presentation = new Presentation("Sample.pptx");
try {
    // लेआउट स्लाइड प्रकारों के माध्यम से जा कर एक लेआउट स्लाइड चुनें।
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // ऐसी स्थिति जहाँ प्रेजेंटेशन में सभी लेआउट प्रकार नहीं हैं।
        // प्रेजेंटेशन फ़ाइल में केवल Blank और Custom लेआउट प्रकार हैं।
        // हालांकि, कस्टम प्रकारों वाली लेआउट स्लाइड्स में पहचानने योग्य नाम हो सकते हैं,
        // जैसे "Title", "Title and Content", आदि, जिन्हें लेआउट स्लाइड चयन के लिए उपयोग किया जा सकता है।
        // आप प्लेसहोल्डर शैप प्रकारों के सेट पर भी निर्भर कर सकते हैं।
        // उदाहरण के लिए, एक Title स्लाइड में केवल Title प्लेसहोल्डर प्रकार होना चाहिए, आदि।
        for (ILayoutSlide titleAndObjectLayoutSlide : layoutSlides) {
            if (titleAndObjectLayoutSlide.getName().equals("Title and Object")) {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (ILayoutSlide titleLayoutSlide : layoutSlides) {
                if (titleLayoutSlide.getName().equals("Title")) {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(SlideLayoutType.Blank);
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(SlideLayoutType.TitleAndObject, "Title and Object");
                }
            }
        }
    }

    // जोड़ी गई लेआउट स्लाइड का उपयोग करके एक खाली स्लाइड जोड़ें।
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // प्रेजेंटेशन को डिस्क पर सहेजें।
    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अनुपयोगी लेआउट स्लाइड हटाएँ**

Aspose.Slides [Compress](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compress/) क्लास से [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) मेथड प्रदान करता है, जिससे आप अनावश्यक और अप्रयुक्त लेआउट स्लाइड को हटा सकते हैं।

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **स्लाइड लेआउट में प्लेसहोल्डर जोड़ें**

Aspose.Slides [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) मेथड प्रदान करता है, जो आपको लेआउट स्लाइड में नए प्लेसहोल्डर जोड़ने की अनुमति देता है।

यह मैनेजर निम्नलिखित प्लेसहोल्डर प्रकारों के लिए मेथड सम्मिलित करता है:

| PowerPoint Placeholder | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) Method |
| ---------------------- | ------------------------------------------------------------ |
| ![सामग्री](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![सामग्री (ऊर्ध्वाधर)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![पाठ](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![पाठ (ऊर्ध्वाधर)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![चित्र](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![चार्ट](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![टेबल](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![स्मार्टआर्ट](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![मीडिया](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![ऑनलाइन छवि](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

निम्नलिखित Java कोड दिखाता है कि कैसे ब्लैंक लेआउट स्लाइड में नए प्लेसहोल्डर आकार जोड़े जा सकते हैं:

```java
Presentation presentation = new Presentation();
try {
    // Blank लेआउट स्लाइड प्राप्त करें.
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // लेआउट स्लाइड का प्लेसहोल्डर मैनेजर प्राप्त करें.
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // Blank लेआउट स्लाइड में विभिन्न प्लेसहोल्डर जोड़ें.
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Blank लेआउट के साथ एक नई स्लाइड जोड़ें.
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![लेआउट स्लाइड पर प्लेसहोल्डर](add_placeholders.png)

## **लेआउट स्लाइड के लिए फुटर दृश्यमानता सेट करें**

PowerPoint प्रस्तुतियों में, तिथि, स्लाइड नंबर, और कस्टम टेक्स्ट जैसे फुटर तत्व स्लाइड लेआउट के आधार पर दिखाए या छुपाए जा सकते हैं। Aspose.Slides for Android आपको इन फुटर प्लेसहोल्डर की दृश्यमानता नियंत्रित करने की सुविधा देता है। यह तब उपयोगी होता है जब आप चाहते हैं कि कुछ लेआउट फुटर जानकारी दिखाएँ जबकि अन्य साफ़ और न्यूनतम रहें।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएँ।
1. उसके इंडेक्स द्वारा एक लेआउट स्लाइड रेफ़रेंस प्राप्त करें।
1. स्लाइड फुटर प्लेसहोल्डर को दृश्यमान सेट करें।
1. स्लाइड नंबर प्लेसहोल्डर को दृश्यमान सेट करें।
1. दिनांक‑समय प्लेसहोल्डर को दृश्यमान सेट करें।
1. प्रेजेंटेशन सहेजें।

```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    ILayoutSlideHeaderFooterManager headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

    if (!headerFooterManager.isFooterVisible()) {
        headerFooterManager.setFooterVisibility(true);
    }

    if (!headerFooterManager.isSlideNumberVisible()) {
        headerFooterManager.setSlideNumberVisibility(true);
    }

    if (!headerFooterManager.isDateTimeVisible()) {
        headerFooterManager.setDateTimeVisibility(true);
    }

    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("Presentation.ppt", SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

## **स्लाइड के लिए चाइल्ड फुटर दृश्यमानता सेट करें**

PowerPoint प्रस्तुतियों में, तिथि, स्लाइड नंबर, और कस्टम टेक्स्ट जैसे फुटर तत्व मास्टर स्लाइड स्तर पर नियंत्रित किए जा सकते हैं ताकि सभी लेआउट स्लाइड में स्थिरता बनी रहे। Aspose.Slides for Android आपको मास्टर स्लाइड पर इन फुटर प्लेसहोल्डर की दृश्यमानता और सामग्री सेट करने और इन सेटिंग्स को सभी चाइल्ड लेआउट स्लाइड पर लागू करने की अनुमति देता है। यह दृष्टिकोण आपके प्रेजेंटेशन में समान फुटर जानकारी सुनिश्चित करता है।

1. [Presentation](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/) क्लास का एक इंस्टेंस बनाएँ।
1. उसके इंडेक्स द्वारा मास्टर स्लाइड का रेफ़रेंस प्राप्त करें।
1. मास्टर और सभी चाइल्ड फुटर प्लेसहोल्डर को दृश्यमान सेट करें।
1. मास्टर और सभी चाइल्ड स्लाइड नंबर प्लेसहोल्डर को दृश्यमान सेट करें।
1. मास्टर और सभी चाइल्ड दिनांक‑समय प्लेसहोल्डर को दृश्यमान सेट करें।
1. प्रेजेंटेशन सहेजें।

```java
Presentation presentation = new Presentation("Presentation.ppt");
try {
    IMasterSlideHeaderFooterManager headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मास्टर स्लाइड और लेआउट स्लाइड में क्या अंतर है?**

मास्टर स्लाइड समग्र थीम और डिफ़ॉल्ट फ़ॉर्मेटिंग को परिभाषित करती है, जबकि लेआउट स्लाइड विभिन्न प्रकार की सामग्री के लिए प्लेसहोल्डर की विशिष्ट व्यवस्था निर्धारित करती है।

**क्या मैं एक लेआउट स्लाइड को एक प्रेजेंटेशन से दूसरे प्रेजेंटेशन में कॉपी कर सकता हूँ?**

हां, आप एक लेआउट स्लाइड को किसी प्रेजेंटेशन की लेआउट स्लाइड कलेक्शन से क्लोन कर सकते हैं, जिसे आप [getLayoutSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/presentation/#getLayoutSlides--) मेथड के माध्यम से एक्सेस कर सकते हैं, और फिर `addClone` मेथड का उपयोग करके उसे दूसरे प्रेजेंटेशन में सम्मिलित कर सकते हैं।

**यदि मैं एक लेआउट स्लाइड को हटाता हूँ जो अभी भी किसी स्लाइड द्वारा उपयोग में है तो क्या होता है?**

यदि आप किसी लेआउट स्लाइड को हटाने का प्रयास करते हैं जो प्रेजेंटेशन में कम से कम एक स्लाइड द्वारा अभी भी संदर्भित है, तो Aspose.Slides एक [PptxEditException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pptxeditexception/) फेंकेगा। इसे टालने के लिए, आप [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) का उपयोग कर सकते हैं, जो केवल उन लेआउट स्लाइड्स को सुरक्षित रूप से हटाता है जो उपयोग में नहीं हैं।