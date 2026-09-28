---
title: जावास्क्रिप्ट में स्लाइड लेआउट लागू या बदलें
linktitle: स्लाइड लेआउट
type: docs
weight: 60
url: /hi/nodejs-java/slide-layout/
keywords:
- स्लाइड लेआउट
- सामग्री लेआउट
- प्लेसहोल्डर
- प्रस्तुति डिज़ाइन
- स्लाइड डिज़ाइन
- अप्रयुक्त लेआउट
- फ़ूटर दृश्यता
- शीर्षक स्लाइड
- शीर्षक और सामग्री
- अनुभाग शीर्षक
- दो सामग्री
- तुलना
- केवल शीर्षक
- खाली लेआउट
- कैप्शन सहित सामग्री
- कैप्शन सहित चित्र
- शीर्षक और लंबवत पाठ
- लंबवत शीर्षक और पाठ
- PowerPoint
- OpenDocument
- प्रस्तुति
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js में जावा के माध्यम से स्लाइड लेआउट लागू करें, बनायें, और संशोधित करें, प्लेसहोल्डर जोड़ें, अप्रयुक्त लेआउट हटाएँ, और फ़ूटर दृश्यता नियंत्रित करें."
---
## **अवलोकन**

एक स्लाइड लेआउट शीर्षक, पाठ, चित्र, चार्ट और तालिकाओं जैसे प्लेसहोल्डर्स की स्थितियों और स्वरूपण को परिभाषित करता है। लेआउट लागू करने से स्लाइड्स को एक सुसंगत संरचना मिलती है जबकि प्रत्येक स्लाइड को अपना स्वयं का कंटेंट रखने की अनुमति देती है।

सबसे सामान्य लेआउट शामिल हैं:

- **टाइटल स्लाइड**: शीर्षक और उपशीर्षक प्लेसहोल्डर्स शामिल है।
- **शीर्षक और सामग्री**: एक शीर्षक प्लेसहोल्डर और एक सामान्य‑उद्देश्य कंटेंट प्लेसहोल्डर शामिल है।
- **ब्लैंक**: कोई कंटेंट प्लेसहोल्डर नहीं होते और जब प्रत्येक आकार को मैन्युअल रूप से स्थित किया जाएगा तो यह उपयोगी होता है।

## **लेआउट विरासत को समझें**

एक प्रस्तुति में तीन संबंधित स्तर होते हैं:

1. A [मास्टर स्लाइड](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslide/) defines the theme, shared formatting, backgrounds, and common objects.
2. A [लेआउट स्लाइड](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslide/) belongs to a master and defines a particular arrangement of placeholders.
3. A [सामान्य स्लाइड](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/) uses one layout and stores the content entered for that slide.

एक सामान्य स्लाइड अपने लेआउट से थीम और स्वरूपण को विरासत में प्राप्त करती है, और लेआउट अपने मास्टर से विरासत में प्राप्त करता है। सामान्य स्लाइड पर सीधे सेट किया गया मान उस स्तर पर विरासत मान को ओवरराइड करता है। जब एक सामान्य स्लाइड बनाई जाती है, तो उसके प्लेसहोल्डर आकार चुने गए लेआउट से उत्पन्न होते हैं, जबकि उन प्लेसहोल्डरों में दर्ज कंटेंट सामान्य स्लाइड से संबंधित होता है।

एक लेआउट से स्लाइड बनाने से पहले आवश्यक प्लेसहोल्डर जोड़ें। लेआउट में बाद में दूसरा प्लेसहोल्डर जोड़ने से मौजूदा सामान्य स्लाइड्स में स्वचालित रूप से संबंधित प्लेसहोल्डर आकार नहीं जुड़ता।

इस संबंध के दो महत्वपूर्ण परिणाम हैं:

- लेआउट पर विरासत स्वरूपण या मौजूदा प्लेसहोल्डर ज्यामिति बदलने से उसपर निर्भर सभी स्लाइड्स अपडेट हो सकती हैं। उपयोग में पहले से मौजूद लेआउट को संपादित करने से पहले, उसके निर्भर स्लाइड्स का निरीक्षण करें और परिणामी प्रस्तुति की समीक्षा करें।
- वह लेआउट जिसे अभी भी किसी स्लाइड द्वारा उपयोग किया जा रहा है, हटाया नहीं जा सकता। पहले उसके निर्भर स्लाइड्स को किसी अन्य लेआउट पर पुनःनिर्धारित करें, या केवल अप्रयुक्त लेआउट्स को हटाएँ।

इस श्रेणी के शीर्ष स्तर के बारे में अधिक जानकारी के लिए, देखें [स्लाइड मास्टर](/slides/hi/nodejs-java/slide-master/)।

एक स्लाइड या साझा लेआउट पर विरासत में मिले लोगो या सजावटी मास्टर आकारों को छिपाने के लिए, देखें [मास्टर ग्राफ़िक्स की दृश्यमानता को नियंत्रित करें](/slides/hi/nodejs-java/slide-master/)। उदाहरण में एक ही मास्टर का उपयोग करने वाले दो स्लाइड्स की तुलना की गई है।

## **स्लाइड लेआउट चुनें और लागू करें**

जब प्रस्तुति मानक PowerPoint लेआउट परिभाषाओं का पालन करती है, तो एक [SlideLayoutType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidelayouttype/) मान का उपयोग करें। लेआउट नाम उपयोगकर्ता‑संपादन योग्य होते हैं और स्थानीयकृत किए जा सकते हैं, इसलिए नाम‑आधारित चयन भरोसेमंद नहीं है जब तक आप स्रोत टेम्प्लेट को नियंत्रित नहीं करते।

निम्न उदाहरण पहले मास्टर पर **शीर्षक और सामग्री** लेआउट को खोजता है। यदि वह उपलब्ध नहीं है, तो यह जानबूझकर **ब्लैंक** पर वापस जाता है। दूसरा null चेक आवश्यक है क्योंकि एक प्रस्तुति में केवल कस्टम लेआउट्स हो सकते हैं। चयनित लेआउट फिर पहले सामान्य स्लाइड पर [Slide.setLayoutSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/#setLayoutSlide) विधि के माध्यम से लागू किया जाता है।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let targetLayout = layoutSlides.getByType(titleAndObjectLayoutType);

    if (targetLayout === null) {
        targetLayout = layoutSlides.getByType(blankLayoutType);
    }

    if (targetLayout === null) {
        throw new Error("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

एक स्लाइड का लेआउट बदलने से सीधे स्लाइड में जोड़े गए साधारण आकार हटते नहीं हैं। हालांकि, प्लेसहोल्डर स्थितियाँ, विरासत स्वरूपण, और मौजूदा प्लेसहोल्डर्स व नए लेआउट के बीच का संबंध बदल सकता है, इसलिए बड़े अंतर वाले लेआउट्स के बीच स्विच करते समय आउटपुट का निरीक्षण करें।

## **लेआउट स्लाइड जोड़ें**

चयन और निर्माण अलग‑अलग कार्य हैं। पिछला उदाहरण एक मौजूदा लेआउट चुनता है; यह एक नहीं बनाता। लेआउट बनाने के लिए लक्ष्य मास्टर की लेआउट संग्रह पर [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) विधि को कॉल करें।

निम्न उदाहरण हमेशा `Report Title and Content` नामक नया **शीर्षक और सामग्री** लेआउट जोड़ता है, फिर उसके आधार पर एक सामान्य स्लाइड जोड़ता है। लेआउट नाम संग्रह के भीतर अद्वितीय होने चाहिए।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let reportLayout = masterSlide.getLayoutSlides().add(titleAndObjectLayoutType, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

केवल तभी लेआउट जोड़ें जब टेम्प्लेट को वास्तव में एक और पुन: उपयोग योग्य संरचना की आवश्यकता हो। यदि एक उपयुक्त लेआउट पहले से मौजूद है, तो नया बनाने के बजाय उसे चुनें और पुनः उपयोग करें।

## **लेआउट स्लाइड में प्लेसहोल्डर जोड़ें**

[LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) विधि एक [LayoutPlaceholderManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutplaceholdermanager/) प्रदान करती है जिससे लेआउट में प्लेसहोल्डर आकार जोड़े जा सकते हैं।

| PowerPoint प्लेसहोल्डर | `LayoutPlaceholderManager` मेथड |
| ----------------------- | -------------------------------- |
| ![सामग्री](content.png) | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![सामग्री (ऊर्ध्वाधर)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![पाठ](text.png) | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![पाठ (ऊर्ध्वाधर)](textV.png) | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![चित्र](picture.png) | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![चार्ट](chart.png) | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![तालिका](table.png) | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![स्मार्टआर्ट](smartart.png) | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![मीडिया](media.png) | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![ऑनलाइन छवि](onlineImage.png) | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

निम्न उदाहरण सत्यापित करता है कि **ब्लैंक** लेआउट मौजूद है, उसमें चार प्लेसहोल्डर जोड़ता है, और फिर संशोधित लेआउट का उपयोग करने वाली एक सामान्य स्लाइड बनाता है। क्रम इरादतन है: प्लेसहोल्डर सामान्य स्लाइड बनाने से पहले जोड़े जाते हैं, ताकि Aspose.Slides उस स्लाइड पर संबंधित प्लेसहोल्डर आकार उत्पन्न कर सके।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayout = presentation.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayout === null) {
        throw new Error("The presentation does not contain a Blank layout slide.");
    }

    let placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

परिणाम:

![लेआउट स्लाइड पर प्लेसहोल्डर](add_placeholders.png)

{{% alert color="warning" title="चेतावनी" %}}
विरासत स्वरूपण या मौजूदा लेआउट प्लेसहोल्डर की ज्यामिति बदलने से निर्भर स्लाइड्स प्रभावित हो सकती हैं। नया जोड़ा गया लेआउट प्लेसहोल्डर मौजूदा सामान्य स्लाइड्स में बैकफ़िल नहीं होता। लेआउट परिवर्तन को प्रस्तुति की प्रतिलिपि पर परीक्षण करें और प्रत्येक निर्भर स्लाइड का निरीक्षण करें।
{{% /alert %}}

## **अप्रयुक्त लेआउट स्लाइड हटाएँ**

कोई सामान्य स्लाइड संदर्भ नहीं देती ऐसी लेआउट्स को हटाने के लिए [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) विधि का उपयोग करें। विधि उन लेआउट्स को अपरिवर्तित छोड़ देती है जो अभी भी उपयोग में हैं।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

एक विशिष्ट लेआउट हटाने के लिए, पहले उसके [hasDependingSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) या [getDependingSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) विधि का उपयोग करें। किसी भी निर्भर स्लाइड को पुनःनिर्धारित करने के बाद [LayoutSlide.remove](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslide/#remove) को कॉल करें। उपयोग में मौजूद लेआउट हटाने का प्रयास करने से [PptxEditException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pptxeditexception/) उठता है।

## **लेआउट स्लाइड पर फुटर दृश्यता नियंत्रित करें**

एक लेआउट का अपना फुटर, स्लाइड‑नंबर, और तारीख‑समय प्लेसहोल्डर होता है। एक लेआउट के लिए उन प्लेसहोल्डर्स को नियंत्रित करने हेतु [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) विधि का उपयोग करें। यह तब उपयोगी होता है जब उदाहरण के तौर पर कंटेंट लेआउट्स को फुटर दिखाना चाहिए पर टाइटल लेआउट्स को नहीं।

निम्न उदाहरण सुरक्षित रूप से एक लेआउट चुनता है और उसके फुटर तत्वों को दृश्यमान बनाता है:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(titleAndObjectLayoutType);

    if (layoutSlide === null) {
        layoutSlide = presentation.getLayoutSlides().getByType(blankLayoutType);
    }

    if (layoutSlide === null) {
        throw new Error("The presentation does not contain a suitable layout slide.");
    }

    let headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **मास्टर और इसकी चाइल्ड लेआउट्स पर फुटर दृश्यता नियंत्रित करें**

एक मास्टर पदानुक्रम में सुसंगत फुटर सेटिंग्स लागू करने के लिए [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager) विधि का उपयोग करें। [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslideheaderfootermanager/) की प्रोपेगेशन विधियाँ मास्टर, उसके निर्भर लेआउट स्लाइड्स और सामान्य स्लाइड्स पर काम करती हैं; वे केवल एक सामान्य स्लाइड को लक्षित नहीं करतीं।

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **अक्सर पूछे जाने वाले प्रश्न**

**मास्टर स्लाइड और लेआउट स्लाइड के बीच क्या अंतर है?**

एक मास्टर स्लाइड प्रस्तुति की थीम और साझा स्वरूपण को परिभाषित करती है। एक लेआउट स्लाइड मास्टर का भाग होती है और प्लेसहोल्डर्स की एक पुनः‑उपयोग योग्य व्यवस्था को परिभाषित करती है। सामान्य स्लाइड्स इन लेआउट्स का उपयोग करती हैं और स्लाइड‑विशिष्ट कंटेंट संग्रहीत करती हैं।

**क्या मैं एक लेआउट स्लाइड को एक प्रस्तुति से दूसरी में कॉपी कर सकता हूँ?**

हां। लक्ष्य संग्रह में एक प्रति जोड़ने के लिए [addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone) विधि का उपयोग करें। प्रस्तुति के बीच कॉपी करते समय, स्रोत लेआउट द्वारा उपयोग किए गए फोंट, थीम, चित्र और अन्य संसाधनों की भी जाँच करें।

**जब मैं एक लेआउट को संशोधित करता हूँ जो पहले से उपयोग में है तो क्या होता है?**

निर्भर स्लाइड्स लेआउट बदलावों को विरासत में लेती हैं, जब तक कि उन्होंने प्रभावित स्वरूपण या वस्तुओं को स्थानीय रूप से ओवरराइड न किया हो। प्लेसहोल्डर ज्यामिति और विरासत शैली कई स्लाइड्स पर एक साथ बदल सकती है। संपादन से पहले प्रभावित स्लाइड्स की पहचान करने के लिए [getDependingSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) का उपयोग करें।

**यदि मैं एक लेआउट हटाता हूँ जो अभी भी उपयोग में है तो क्या होता है?**

Aspose.Slides एक [PptxEditException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pptxeditexception/) उत्पन्न करता है। पहले निर्भर स्लाइड्स को पुनःनिर्धारित करें, या केवल बिना संदर्भ वाले लेआउट्स को हटाने के लिए [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) का उपयोग करें।