---
title: JavaScript में स्लाइड लेआउट लागू करें या बदलें
linktitle: स्लाइड लेआउट
type: docs
weight: 60
url: /hi/nodejs-java/slide-layout/
keywords:
- स्लाइड लेआउट
- सामग्री लेआउट
- प्लेसहोल्डर
- प्रेजेंटेशन डिजाइन
- स्लाइड डिजाइन
- अप्रयुक्त लेआउट
- फुटर दृश्यता
- शीर्षक स्लाइड
- शीर्षक और सामग्री
- सेक्शन हेडर
- दो सामग्री
- तुलना
- केवल शीर्षक
- ब्लैंक लेआउट
- कैप्शन के साथ सामग्री
- कैप्शन के साथ चित्र
- शीर्षक और लंबवत टेक्स्ट
- लंबवत शीर्षक और टेक्स्ट
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js में स्लाइड लेआउट्स को प्रबंधित और अनुकूलित करें। लेआउट प्रकार, प्लेसहोल्डर नियंत्रण, और कोड उदाहरणों के माध्यम से फुटर दृश्यता का अन्वेषण करें।"
---
## **परिचय**

एक स्लाइड लेआउट स्लाइड पर सामग्री के प्लेसहोल्डर बॉक्स और फॉर्मेटिंग की व्यवस्था को परिभाषित करता है। यह नियंत्रित करता है कि कौन से प्लेसहोल्डर उपलब्ध हैं और वे कहाँ दिखेंगे। स्लाइड लेआउट आपको प्रस्तुतियों को तेज़ी और सुसंगत रूप से डिज़ाइन करने में मदद करते हैं—चाहे आप कुछ सरल या अधिक जटिल बना रहे हों। PowerPoint में सबसे आम स्लाइड लेआउट्स में शामिल हैं:

**Title Slide layout** – दो टेक्स्ट प्लेसहोल्डर शामिल हैं: एक शीर्षक के लिए और एक उपशीर्षक के लिए।

**Title and Content layout** – शीर्ष पर छोटा शीर्षक प्लेसहोल्डर और नीचे बड़ा प्लेसहोल्डर मुख्य सामग्री (जैसे टेक्स्ट, बुलेट पॉइंट्स, चार्ट, छवियां, आदि) के लिए दिखाता है।

**Blank layout** – कोई प्लेसहोल्डर नहीं होता, जिससे आप स्लाइड को शून्य से डिज़ाइन कर सकते हैं।

स्लाइड लेआउट्स एक स्लाइड मास्टर का हिस्सा होते हैं, जो प्रस्तुति के लिए लेआउट शैलियों को परिभाषित करने वाला शीर्ष-स्तर स्लाइड है। आप स्लाइड मास्टर के माध्यम से लेआउट स्लाइड्स तक पहुँच सकते हैं और उनका संशोधन कर सकते हैं—या तो उनके प्रकार, नाम, या अनूठे ID द्वारा। वैकल्पिक रूप से, आप प्रस्तुति के भीतर सीधे एक विशिष्ट लेआउट स्लाइड को संपादित कर सकते हैं।

Aspose.Slides for Node.js में स्लाइड लेआउट्स के साथ काम करने के लिए आप उपयोग कर सकते हैं:

- क्लास [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) के तहत [getLayoutSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getLayoutSlides) और [getMasters](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getMasters) जैसी विधियां
- प्रकार जैसे [LayoutSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutplaceholdermanager/), और [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
मास्टर स्लाइड्स के साथ काम करने के बारे में अधिक जानने के लिए, कृपया [Slide Master](/slides/hi/nodejs-java/slide-master/) लेख देखें।
{{% /alert %}}

## **प्रेजेंटेशन में स्लाइड लेआउट जोड़ें**

अपनी स्लाइड्स की उपस्थिति और संरचना को अनुकूलित करने के लिए, आपको प्रेजेंटेशन में नए लेआउट स्लाइड्स जोड़ने की आवश्यकता हो सकती है। Aspose.Slides for Node.js आपको यह जाँचने की सुविधा देता है कि कोई विशेष लेआउट पहले से मौजूद है या नहीं, आवश्यकता पड़ने पर नया जोड़ें, और उस लेआउट के आधार पर स्लाइड्स शामिल करें।

1. क्लास [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) की एक इंस्टेंस बनाएं।
1. [MasterLayoutSlideCollection](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterlayoutslidecollection/) तक पहुँचें।
1. जांचें कि चयनित लेआउट स्लाइड संग्रह में पहले से मौजूद है या नहीं। यदि नहीं, तो आवश्यक लेआउट स्लाइड जोड़ें।
1. नए लेआउट स्लाइड के आधार पर एक खाली स्लाइड जोड़ें।
1. प्रेजेंटेशन को सेव करें।

निम्नलिखित JavaScript कोड एक PowerPoint प्रेजेंटेशन में स्लाइड लेआउट जोड़ने का उदाहरण दर्शाता है:

```js
// PowerPoint फ़ाइल का प्रतिनिधित्व करने वाले Presentation क्लास का इंस्टैंस बनाएं।
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // लेआउट स्लाइड प्रकारों के माध्यम से जाएं ताकि एक लेआउट स्लाइड चुन सकें।
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let layoutSlide = null;
    if (layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject)) != null) {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    } else {
        layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Title));
    }

    if (layoutSlide == null) {
        // ऐसी स्थिति जहाँ प्रस्तुति में सभी लेआउट प्रकार नहीं होते।
        // प्रेजेंटेशन फ़ाइल में केवल ब्लैंक और कस्टम लेआउट प्रकार होते हैं।
        // हालांकि, कस्टम प्रकार वाली लेआउट स्लाइड्स में पहचाने जाने योग्य नाम हो सकते हैं,
        // "Title", "Title and Content" आदि जैसे नाम, जिन्हें लेआउट स्लाइड चयन के लिए उपयोग किया जा सकता है।
        // आप प्लेसहोल्डर शेड आकार प्रकारों के सेट पर भी निर्भर कर सकते हैं।
        // उदाहरण के लिए, एक Title स्लाइड में केवल Title प्लेसहोल्डर प्रकार होना चाहिए, आदि।
        for (let i = 0; i < layoutSlides.size(); i++) {
            let titleAndObjectLayoutSlide = layoutSlides.get_Item(i);
            if (titleAndObjectLayoutSlide.getName() === "Title and Object") {
                layoutSlide = titleAndObjectLayoutSlide;
                break;
            }
        }

        if (layoutSlide == null) {
            for (let i = 0; i < layoutSlides.size(); i++) {
                let titleLayoutSlide = layoutSlides.get_Item(i);
                if (titleLayoutSlide.getName() === "Title") {
                    layoutSlide = titleLayoutSlide;
                    break;
                }
            }

            if (layoutSlide == null) {
                layoutSlide = layoutSlides.getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));
                if (layoutSlide == null) {
                    layoutSlide = layoutSlides.add(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject), "Title and Object");
                }
            }
        }
    }

    // जोड़े गये लेआउट स्लाइड का उपयोग करके एक खाली स्लाइड जोड़ें।
    presentation.getSlides().insertEmptySlide(0, layoutSlide);

    // प्रेजेंटेशन को डिस्क पर सेव करें।
    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अनुपयोगी लेआउट स्लाइड्स हटाएँ**

Aspose.Slides [Compress](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compress/) क्लास से [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) विधि प्रदान करता है जिससे आप अनचाही और अप्रयुक्त लेआउट स्लाइड्स को हटा सकते हैं।

निम्नलिखित JavaScript कोड दिखाता है कि PowerPoint प्रेजेंटेशन से एक लेआउट स्लाइड कैसे हटाएँ:

```js
let presentation = new aspose.slides.Presentation("Presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **स्लाइड लेआउट में प्लेसहोल्डर जोड़ें**

Aspose.Slides [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) विधि प्रदान करता है, जो आपको लेआउट स्लाइड में नए प्लेसहोल्डर जोड़ने की सुविधा देता है।

यह मैनेजर निम्नलिखित प्लेसहोल्डर प्रकारों के लिए विधियां शामिल करता है:

| PowerPoint प्लेसहोल्डर | [LayoutPlaceholderManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutplaceholdermanager/) विधि |
| ----------------------- | ------------------------------------------------------------ |
| ![Content](content.png) | addContentPlaceholder(float x, float y, float width, float height) |
| ![Content (Vertical)](contentV.png) | addVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Text](text.png) | addTextPlaceholder(float x, float y, float width, float height) |
| ![Text (Vertical)](textV.png) | addVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Picture](picture.png) | addPicturePlaceholder(float x, float y, float width, float height) |
| ![Chart](chart.png) | addChartPlaceholder(float x, float y, float width, float height) |
| ![Table](table.png) | addTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png) | addSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Media](media.png) | addMediaPlaceholder(float x, float y, float width, float height) |
| ![Online Image](onlineimage.png) | addOnlineImagePlaceholder(float x, float y, float width, float height) |

निम्नलिखित JavaScript कोड Blank लेआउट स्लाइड में नए प्लेसहोल्डर शैप्स जोड़ने का उदाहरण दर्शाता है:

```js
let presentation = new aspose.slides.Presentation();
try {
    // ब्लैंक लेआउट स्लाइड प्राप्त करें।
    let layout = presentation.getLayoutSlides().getByType(java.newByte(aspose.slides.SlideLayoutType.Blank));

    // लेआउट स्लाइड के प्लेसहोल्डर मैनेज़र को प्राप्त करें।
    let placeholderManager = layout.getPlaceholderManager();

    // ब्लैंक लेआउट स्लाइड में विभिन्न प्लेसहोल्डर जोड़ें।
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    // ब्लैंक लेआउट के साथ नई स्लाइड जोड़ें।
    let newSlide = presentation.getSlides().addEmptySlide(layout);

    presentation.save("Placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![लेआउट स्लाइड पर प्लेसहोल्डर](add_placeholders.png)

## **लेआउट स्लाइड के लिए फुटर दृश्यता सेट करें**

PowerPoint प्रेजेंटेशन में फुटर तत्व जैसे तिथि, स्लाइड नंबर, और कस्टम टेक्स्ट लेआउट के आधार पर दिखाए या छिपाए जा सकते हैं। Aspose.Slides for Node.js आपको इन फुटर प्लेसहोल्डर की दृश्यता को नियंत्रित करने की सुविधा देता है। यह तब उपयोगी होता है जब आप चाहते हैं कि कुछ लेआउट फुटर जानकारी दिखाएँ जबकि अन्य साफ़ और न्यूनतम रहें।

1. क्लास [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) की एक इंस्टेंस बनाएं।
1. उसके इंडेक्स से एक लेआउट स्लाइड रेफ़रेंस प्राप्त करें।
1. स्लाइड फुटर प्लेसहोल्डर को दृश्यमान सेट करें।
1. स्लाइड नंबर प्लेसहोल्डर को दृश्यमान सेट करें।
1. तिथि‑समय प्लेसहोल्डर को दृश्यमान सेट करें।
1. प्रेजेंटेशन को सेव करें।

निम्नलिखित JavaScript कोड दर्शाता है कि स्लाइड फुटर की दृश्यता कैसे सेट करें और संबंधित कार्य कैसे करें:

```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getLayoutSlides().get_Item(0).getHeaderFooterManager();

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

    presentation.save("Presentation.ppt", aspose.slides.SaveFormat.Ppt);
} finally {
    presentation.dispose();
}
```

## **स्लाइड के लिए चाइल्ड फुटर दृश्यता सेट करें**

PowerPoint प्रेजेंटेशन में फुटर तत्व जैसे तिथि, स्लाइड नंबर, और कस्टम टेक्स्ट को मास्टर स्लाइड स्तर पर नियंत्रित किया जा सकता है ताकि सभी लेआउट स्लाइड्स में सुसंगतता बनी रहे। Aspose.Slides for Node.js आपको मास्टर स्लाइड पर इन फुटर प्लेसहोल्डर की दृश्यता और सामग्री सेट करने और इन सेटिंग्स को सभी चाइल्ड लेआउट स्लाइड्स में प्रसारित करने की अनुमति देता है। यह आपकी प्रस्तुति में समान फुटर जानकारी सुनिश्चित करता है।

1. क्लास [Presentation](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/) की एक इंस्टेंस बनाएं।
1. उसके इंडेक्स से एक मास्टर स्लाइड रेफ़रेंस प्राप्त करें।
1. मास्टर और सभी चाइल्ड फुटर प्लेसहोल्डर को दृश्यमान सेट करें।
1. मास्टर और सभी चाइल्ड स्लाइड नंबर प्लेसहोल्डर को दृश्यमान सेट करें।
1. मास्टर और सभी चाइल्ड तिथि‑समय प्लेसहोल्डर को दृश्यमान सेट करें।
1. प्रेजेंटेशन को सेव करें।

निम्नलिखित JavaScript कोड इस ऑपरेशन को दर्शाता है:

```js
let presentation = new aspose.slides.Presentation("Presentation.ppt");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();

    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मास्टर स्लाइड और लेआउट स्लाइड में क्या अंतर है?**

मास्टर स्लाइड कुल थीम और डिफ़ॉल्ट फॉर्मेटिंग को परिभाषित करती है, जबकि लेआउट स्लाइड विभिन्न प्रकार की सामग्री के लिए प्लेसहोल्डर की विशिष्ट व्यवस्था को परिभाषित करती है।

**क्या मैं एक लेआउट स्लाइड को एक प्रेजेंटेशन से दूसरे में कॉपी कर सकता हूँ?**

हाँ, आप किसी प्रेजेंटेशन की लेआउट स्लाइड कलेक्शन से, जिसे [getLayoutSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/presentation/#getLayoutSlides) विधि के माध्यम से एक्सेस किया जा सकता है, एक लेआउट स्लाइड को क्लोन करके `addClone` विधि द्वारा दूसरे प्रेजेंटेशन में जोड़ सकते हैं।

**यदि मैं ऐसे लेआउट स्लाइड को डिलीट करता हूँ जो अभी भी किसी स्लाइड द्वारा उपयोग में है तो क्या होता है?**

यदि आप किसी लेआउट स्लाइड को डिलीट करने का प्रयास करते हैं जो कम से कम एक स्लाइड द्वारा अभी भी संदर्भित है, तो Aspose.Slides एक [PptxEditException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pptxeditexception/) फेंकेगा। इसे रोकने के लिए, [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) का उपयोग करें जो केवल अनउपयोगी लेआउट स्लाइड्स को सुरक्षित रूप से हटाता है।