---
title: Java में स्लाइड लेआउट्स लागू या बदलें
linktitle: स्लाइड लेआउट
type: docs
weight: 60
url: /hi/java/slide-layout/
keywords:
- स्लाइड लेआउट
- सामग्री लेआउट
- प्लेसहोल्डर
- प्रेजेंटेशन डिज़ाइन
- स्लाइड डिज़ाइन
- अनुपयोगी लेआउट
- फुटर दृश्यता
- शीर्षक स्लाइड
- शीर्षक और सामग्री
- सेक्शन हेडर
- दो सामग्री
- तुलना
- केवल शीर्षक
- खाली लेआउट
- कैप्शन के साथ सामग्री
- कैप्शन के साथ चित्र
- शीर्षक और वर्टिकल टेक्स्ट
- वर्टिकल शीर्षक और टेक्स्ट
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में स्लाइड लेआउट्स को प्रबंधित और अनुकूलित करें। लेआउट प्रकारों, प्लेसहोल्डर नियंत्रण और फुटर दृश्यता को Java कोड उदाहरणों के माध्यम से खोजें।"
---
## **परिचय**

एक स्लाइड लेआउट स्लाइड पर सामग्री के लिए प्लेसहोल्डर बॉक्सों की व्यवस्था और स्वरूपण को परिभाषित करता है। यह नियंत्रित करता है कि कौन से प्लेसहोल्डर उपलब्ध हैं और वे जहाँ दिखाई देते हैं। स्लाइड लेआउट आपको जल्दी और लगातार प्रेजेंटेशन डिज़ाइन करने में मदद करते हैं— चाहे आप कुछ सरल या अधिक जटिल बना रहे हों। PowerPoint में सबसे आम स्लाइड लेआउट्स में शामिल हैं:

**Title Slide layout** – दो टेक्स्ट प्लेसहोल्डर शामिल हैं: एक शीर्षक के लिए और एक उपशीर्षक के लिए।

**Title and Content layout** – ऊपर एक छोटा शीर्षक प्लेसहोल्डर और नीचे मुख्य सामग्री (जैसे टेक्स्ट, बुलेट पॉइंट्स, चार्ट, छवियां, आदि) के लिए बड़ा प्लेसहोल्डर दिखाता है।

**Blank layout** – कोई प्लेसहोल्डर नहीं होता, जिससे आप स्लाइड को शून्य से डिज़ाइन कर सकते हैं।

स्लाइड लेआउट्स स्लाइड मास्टर का हिस्सा होते हैं, जो प्रेजेंटेशन के लिए लेआउट शैलियों को परिभाषित करने वाली शीर्ष-स्तर की स्लाइड है। आप स्लाइड मास्टर के माध्यम से लेआउट स्लाइड्स तक पहुँच सकते हैं और उन्हें संशोधित कर सकते हैं— चाहे उनके प्रकार, नाम या विशिष्ट आईडी के द्वारा। वैकल्पिक रूप से, आप सीधे प्रेजेंटेशन में किसी विशेष लेआउट स्लाइड को संपादित कर सकते हैं।

Aspose.Slides for Java में स्लाइड लेआउट्स के साथ कार्य करने के लिए आप उपयोग कर सकते हैं:

- Methods such as [getLayoutSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getLayoutSlides--) and [getMasters](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getMasters--) under the [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) class
- Types like [ILayoutSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutslide/), [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterlayoutslidecollection/), [ILayoutPlaceholderManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutplaceholdermanager/), and [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
मास्टर स्लाइड्स के साथ काम करने के बारे में अधिक जानने के लिए, [Slide Master](/slides/hi/java/slide-master/) लेख देखें।
{{% /alert %}}

## **प्रेजेंटेशन में स्लाइड लेआउट जोड़ें**

अपनी स्लाइड्स की उपस्थिति और संरचना को अनुकूलित करने के लिए, आपको प्रेजेंटेशन में नई लेआउट स्लाइड्स जोड़ने की आवश्यकता हो सकती है। Aspose.Slides for Java आपको यह जाँचने की अनुमति देता है कि कोई विशिष्ट लेआउट पहले से मौजूद है या नहीं, यदि आवश्यक हो तो नया जोड़ें, और उस लेआउट के आधार पर स्लाइड्स सम्मिलित करें।

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) class.
1. Access the [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterlayoutslidecollection/).
1. Check whether the desired layout slide already exists in the collection. If not, add the layout slide you need.
1. Add an empty slide based on the new layout slide.
1. Save the presentation.

निम्नलिखित Java कोड दिखाता है कि PowerPoint प्रेजेंटेशन में स्लाइड लेआउट कैसे जोड़ें:

```java
// PowerPoint फ़ाइल को दर्शाने वाली Presentation क्लास का उदाहरण बनाएं।
Presentation presentation = new Presentation("Sample.pptx");
try {
    // लेआउट स्लाइड प्रकारों के माध्यम से जाकर एक लेआउट स्लाइड चुनें।
    IMasterLayoutSlideCollection layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    ILayoutSlide layoutSlide = null;
    if (layoutSlides.getByType(SlideLayoutType.TitleAndObject) != null)
        layoutSlide = layoutSlides.getByType(SlideLayoutType.TitleAndObject);
    else
        layoutSlide = layoutSlides.getByType(SlideLayoutType.Title);

    if (layoutSlide == null) {
        // ऐसी स्थिति जहाँ प्रेजेंटेशन में सभी लेआउट प्रकार नहीं होते।
        // प्रेजेंटेशन फ़ाइल में केवल Blank और Custom लेआउट प्रकार होते हैं।
        // हालांकि, कस्टम प्रकार वाली लेआउट स्लाइड्स के पहचानने योग्य नाम हो सकते हैं,
        // "Title", "Title and Content" आदि जैसे, जिन्हें लेआउट स्लाइड चयन के लिये उपयोग किया जा सकता है।
        // आप प्लेसहोल्डर आकार प्रकारों के सेट पर भी भरोसा कर सकते हैं।
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

## **नunused लेआउट स्लाइड्स हटाएँ**

Aspose.Slides [Compress](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compress/) क्लास से [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) मेथड प्रदान करता है जिससे आप अनवांछित और न उपयोग किए गए लेआउट स्लाइड्स को हटा सकते हैं।

निम्नलिखित Java कोड दिखाता है कि PowerPoint प्रेजेंटेशन से लेआउट स्लाइड कैसे हटाएँ:

```java
Presentation presentation = new Presentation("Presentation.pptx");
try {
    Compress.removeUnusedLayoutSlides(presentation);

    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **लेआउट स्लाइड्स में प्लेसहोल्डर जोड़ें**

Aspose.Slides [ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) मेथड प्रदान करता है, जो आपको लेआउट स्लाइड में नए प्लेसहोल्डर जोड़ने की अनुमति देता है।

यह मैनेजर निम्नलिखित प्लेसहोल्डर प्रकारों के लिए मेथड्स रखता है:

| PowerPoint प्लेसहोल्डर | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutplaceholdermanager/) विधि |
| ---------------------- | ------------------------------------------------------------ |
| ![सामग्री](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![सामग्री (वर्टिकल)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![पाठ](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![पाठ (वर्टिकल)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![चित्र](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![चार्ट](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![टेबल](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![स्मार्टआर्ट](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![मीडिया](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![ऑनलाइन छवि](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

निम्नलिखित Java कोड दिखाता है कि Blank लेआउट स्लाइड में नए प्लेसहोल्डर आकार कैसे जोड़ें:

```java
Presentation presentation = new Presentation();
try {
    // Blank लेआउट स्लाइड प्राप्त करें।
    ILayoutSlide layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank);

    // लेआउट स्लाइड के प्लेसहोल्डर मैनेजर को प्राप्त करें।
    ILayoutPlaceholderManager placeholderManager = layout.getPlaceholderManager();

    // Blank लेआउट स्लाइड में विभिन्न प्लेसहोल्डर जोड़ें।
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // Blank लेआउट के साथ नई स्लाइड जोड़ें।
    ISlide newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![लेआउट स्लाइड पर प्लेसहोल्डर](add_placeholders.png)

## **लेआउट स्लाइड के लिए फुटर दृश्यता सेट करें**

PowerPoint प्रेजेंटेशन में, फुटर तत्व जैसे तिथि, स्लाइड नंबर, और कस्टम टेक्स्ट लेआउट के अनुसार दिखाए या छिपाए जा सकते हैं। Aspose.Slides for Java आपको इन फुटर प्लेसहोल्डर की दृश्यता नियंत्रित करने देता है। यह तब उपयोगी होता है जब आप कुछ लेआउट्स में फुटर जानकारी दिखाना चाहते हैं जबकि अन्य को साफ़ और न्यूनतम रखना चाहते हैं।

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) class.
1. Get a layout slide reference by its index.
1. Set the slide footer placeholder to visible.
1. Set the slide number placeholder to visible.
1. Set the date-time placeholder to visible.
1. Save the presentation.

निम्नलिखित Java कोड दिखाता है कि स्लाइड फुटर की दृश्यता कैसे सेट करें और संबंधित कार्य कैसे करें:

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

## **स्लाइड के लिए चाइल्ड फुटर दृश्यता सेट करें**

PowerPoint प्रेजेंटेशन में, तिथि, स्लाइड नंबर, और कस्टम टेक्स्ट जैसे फुटर तत्वों को मास्टर स्लाइड स्तर पर नियंत्रित किया जा सकता है ताकि सभी लेआउट स्लाइड्स में सुसंगतता बनी रहे। Aspose.Slides for Java आपको मास्टर स्लाइड पर इन फुटर प्लेसहोल्डर की दृश्यता और सामग्री सेट करने और इन सेटिंग्स को सभी चाइल्ड लेआउट स्लाइड्स में प्रसारित करने की सुविधा देता है। यह विधि आपके प्रेजेंटेशन में समान फुटर जानकारी सुनिश्चित करती है।

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/) class.
1. Get a reference to the master slide by its index.
1. Set the master’s and all child footer placeholders to visible.
1. Set the master’s and all child slide number placeholders to visible.
1. Set the master’s and all child date-time placeholders to visible.
1. Save the presentation.

निम्नलिखित Java कोड इस ऑपरेशन को दर्शाता है:

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

## **FAQ**

**मास्टर स्लाइड और लेआउट स्लाइड के बीच क्या अंतर है?**

मास्टर स्लाइड समग्र थीम और डिफ़ॉल्ट फ़ॉर्मेटिंग परिभाषित करती है, जबकि लेआउट स्लाइड विभिन्न प्रकार की सामग्री के लिए प्लेसहोल्डर की विशिष्ट व्यवस्था को निर्धारित करती है।

**क्या मैं एक लेआउट स्लाइड को एक प्रेजेंटेशन से दूसरे में कॉपी कर सकता हूँ?**

हां, आप किसी प्रेजेंटेशन के लेआउट स्लाइड कलेक्शन से, जो कि [getLayoutSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#getLayoutSlides--) मेथड से उपलब्ध है, लेआउट स्लाइड को क्लोन कर सकते हैं, और `addClone` मेथड का उपयोग करके उसे दूसरे प्रेजेंटेशन में सम्मिलित कर सकते हैं।

**यदि मैं वह लेआउट स्लाइड हटाता हूँ जिसका उपयोग अभी भी किसी स्लाइड द्वारा किया जा रहा है, तो क्या होता है?**

यदि आप ऐसी लेआउट स्लाइड को हटाने का प्रयास करते हैं जो प्रेजेंटेशन में कम से कम एक स्लाइड द्वारा अभी भी संदर्भित है, तो Aspose.Slides एक [PptxEditException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pptxeditexception/) फेंकेगा। इसे टालने के लिए, आप [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) का उपयोग कर सकते हैं, जो केवल उन लेआउट स्लाइड्स को सुरक्षित रूप से हटाता है जो उपयोग में नहीं हैं।