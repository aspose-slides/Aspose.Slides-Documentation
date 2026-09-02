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
- Node.js
- जावास्क्रिप्ट
- Aspose.Slides
description: "Aspose.Slides for Node.js में Java के माध्यम से स्लाइड लेआउट लागू करें, बनाएं, और संशोधित करें, प्लेसहोल्डर जोड़ें, अनुपयोगी लेआउट हटाएँ, और फुटर दृश्यता नियंत्रित करें।"
---
## **सारांश**

एक स्लाइड लेआउट शीर्षक, पाठ, चित्र, चार्ट और तालिकाओं जैसी प्लेसहोल्डर की स्थिति और स्वरूप को परिभाषित करता है। एक लेआउट लागू करने से स्लाइड्स को सुसंगत संरचना मिलती है जबकि प्रत्येक स्लाइड को अपना सामग्री रखने की अनुमति देती है।

सबसे सामान्य लेआउट्स में शामिल हैं:

- **शीर्षक स्लाइड**: शीर्षक और उपशीर्षक प्लेसहोल्डर शामिल है।
- **शीर्षक और सामग्री**: एक शीर्षक प्लेसहोल्डर और एक सामान्य प्रयोजन सामग्री प्लेसहोल्डर शामिल है।
- **खाली**: कोई सामग्री प्लेसहोल्डर नहीं होता और यह उपयोगी है जब हर आकृति को मैन्युअल रूप से स्थित किया जाएगा।

## **लेआउट विरासत को समझें**

एक प्रस्तुति के तीन संबंधित स्तर होते हैं:

1. एक [मास्टर स्लाइड](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslide/) थीम, साझा स्वरूप, पृष्ठभूमि और सामान्य वस्तुओं को परिभाषित करता है।
1. एक [लेआउट स्लाइड](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslide/) मास्टर से संबंधित है और प्लेसहोल्डर की विशिष्ट व्यवस्था को परिभाषित करता है।
1. एक [नॉर्मल स्लाइड](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/) एक लेआउट प्रयोग करती है और उस स्लाइड के लिये दर्ज की गई सामग्री को संग्रहीत करती है।

एक नॉर्मल स्लाइड अपना थीम और स्वरूप लेआउट से विरासत में प्राप्त करती है, और लेआउट अपने मास्टर से विरासत में प्राप्त करता है। नॉर्मल स्लाइड पर सीधे सेट किया गया मान उस स्तर पर विरासत मान को ओवरराइड करता है। जब एक नॉर्मल स्लाइड बनाई जाती है, उसके प्लेसहोल्डर आकार चयनित लेआउट से उत्पन्न होते हैं, जबकि उन प्लेसहोल्डर में दर्ज सामग्री नॉर्मल स्लाइड की होती है।

एक लेआउट से स्लाइड बनाने से पहले आवश्यक प्लेसहोल्डर जोड़ें। बाद में लेआउट में दूसरा प्लेसहोल्डर जोड़ने से मौजूदा नॉर्मल स्लाइड्स में स्वचालित रूप से संबंधित प्लेसहोल्डर आकार नहीं बनता।

इस संबंध के दो महत्वपूर्ण परिणाम हैं:

- लेआउट पर विरासत स्वरूप या मौजूदा प्लेसहोल्डर ज्यामिति को बदलने से उस पर निर्भर सभी स्लाइड्स अपडेट हो सकती हैं। उपयोग में पहले से मौजूद लेआउट को संपादित करने से पहले उसके निर्भरताप्राप्त स्लाइड्स की जाँच करें और परिणामी प्रस्तुति की समीक्षा करें।
- वह लेआउट जिसे अभी भी किसी स्लाइड द्वारा उपयोग किया जा रहा है, उसे हटाया नहीं जा सकता। पहले उसके निर्भरताप्राप्त स्लाइड्स को किसी अन्य लेआउट पर पुनः असाइन करें, या केवल अनउपयोगी लेआउट्स ही हटाएँ।

इस पदानुक्रम के शीर्ष स्तर के बारे में अधिक जानकारी के लिए, देखें [स्लाइड मास्टर](/slides/hi/nodejs-java/slide-master/)।

## **स्लाइड लेआउट चुनें और लागू करें**

जब प्रस्तुति मानक PowerPoint लेआउट परिभाषाओं का पालन करती है, तब एक [SlideLayoutType](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slidelayouttype/) मान का उपयोग करें। लेआउट नाम उपयोगकर्ता‑संपादन योग्य होते हैं और स्थानीयकृत किए जा सकते हैं, इसलिए स्रोत टेम्पलेट पर नियंत्रण न होने पर नाम‑आधारित चयन कम भरोसेमंद होता है।

निम्नलिखित उदाहरण पहले मास्टर पर **Title and Content** खोजता है। यदि वह लेआउट उपलब्ध नहीं है, तो जानबूझकर **Blank** पर वापस जाता है। दूसरा null जाँच आवश्यक है क्योंकि एक प्रस्तुति केवल कस्टम लेआउट्स रख सकती है। चयनित लेआउट फिर पहले नॉर्मल स्लाइड पर [Slide.setLayoutSlide](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/slide/#setLayoutSlide) मेथड द्वारा लागू किया जाता है।

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

लेआउट बदलने से सीधे स्लाइड में जोड़ी गई सामान्य आकृतियों को हटाया नहीं जाता। हालांकि, प्लेसहोल्डर की स्थितियां, विरासत स्वरूप और मौजूदा प्लेसहोल्डर और नए लेआउट के बीच का संबंध बदल सकता है, इसलिए बहुत अलग लेआउट्स के बीच स्विच करते समय आउटपुट की जाँच करें।

## **लेआउट स्लाइड जोड़ें**

चयन और निर्माण अलग‑अलग कार्य हैं। पिछला उदाहरण मौजूदा लेआउट को चुनता है; यह एक नया बनाता नहीं है। लेआउट बनाने के लिए टार्गेट मास्टर की लेआउट कलेक्शन पर [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) मेथड को कॉल करें।

निम्नलिखित उदाहरण हमेशा `Report Title and Content` नामक नया **Title and Content** लेआउट जोड़ता है, फिर उस पर आधारित एक नॉर्मल स्लाइड जोड़ता है। लेआउट नाम कलेक्शन के भीतर अद्वितीय होने चाहिए।

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

केवल तभी लेआउट जोड़ें जब टेम्पलेट वास्तव में एक अतिरिक्त पुन: उपयोग योग्य संरचना की आवश्यकता रखता हो। यदि उपयुक्त लेआउट पहले से मौजूद है, तो उसे चुनें और पुनः उपयोग करें, न कि डुप्लिकेट बनाएँ।

## **लेआउट स्लाइड में प्लेसहोल्डर जोड़ें**

[LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) मेथड एक [LayoutPlaceholderManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutplaceholdermanager/) प्रदान करता है, जिससे लेआउट में प्लेसहोल्डर आकृतियां जोड़ी जा सकती हैं।

| PowerPoint प्लेसहोल्डर | `LayoutPlaceholderManager` मेथड |
| ----------------------- | --------------------------------- |
| ![सामग्री](content.png) | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![सामग्री (वर्टिकल)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![टेक्स्ट](text.png) | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![टेक्स्ट (वर्टिकल)](textV.png) | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![चित्र](picture.png) | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![चार्ट](chart.png) | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![तालिका](table.png) | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![स्मार्टआर्ट](smartart.png) | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![मीडिया](media.png) | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![ऑनलाइन इमेज](onlineImage.png) | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

निम्नलिखित उदाहरण सत्यापित करता है कि **Blank** लेआउट मौजूद है, उसमें चार प्लेसहोल्डर जोड़ता है, और फिर संशोधित लेआउट का उपयोग करने वाली एक नॉर्मल स्लाइड बनाता है। क्रम का इरादा है: प्लेसहोल्डर नॉर्मल स्लाइड बनाने से पहले जोड़े जाते हैं, ताकि Aspose.Slides उस स्लाइड पर संबंधित प्लेसहोल्डर आकृतियां उत्पन्न कर सके।

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

{{% alert color="warning" title="Warning" %}}
विरासत स्वरूप या मौजूदा लेआउट प्लेसहोल्डर की ज्यामिति बदलने से निर्भरताप्राप्त स्लाइड्स प्रभावित हो सकती हैं। नवीनतम जोड़े गए लेआउट प्लेसहोल्डर मौजूदा नॉर्मल स्लाइड्स में स्वतः नहीं भरता। लेआउट परिवर्तन को प्रस्तुति की कॉपी पर परीक्षण करें और प्रत्येक निर्भरताप्राप्त स्लाइड की जाँच करें।
{{% /alert %}}

## **अप्रयुक्त लेआउट स्लाइड्स हटाएँ**

[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) मेथड का उपयोग उन लेआउट्स को हटाने के लिये करें जिन्हें कोई नॉर्मल स्लाइड संदर्भित नहीं कर रही है। यह मेथड अभी भी उपयोग में मौजूद लेआउट्स को अपरिवर्तित छोड़ देता है।

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

एक विशिष्ट लेआउट हटाने के लिये, पहले उसकी [hasDependingSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) या [getDependingSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) मेथड का प्रयोग करें। [LayoutSlide.remove](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslide/#remove) को कॉल करने से पहले सभी निर्भरताप्राप्त स्लाइड्स को पुनः असाइन करें। उपयोग में हो रहे लेआउट को हटाने का प्रयास करने पर एक [PptxEditException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pptxeditexception/) उत्पन्न होता है।

## **लेआउट स्लाइड पर फुटर दृश्यता नियंत्रित करें**

एक लेआउट में अपना फुटर, स्लाइड‑नंबर और तिथि‑समय प्लेसहोल्डर होते हैं। इन प्लेसहोल्डर को एक लेआउट के लिये नियंत्रित करने हेतु [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) मेथड का उपयोग करें। यह उपयोगी है जब उदाहरण के लिये कंटेंट लेआउट्स को फुटर दिखाना चाहिए लेकिन टाइटल लेआउट्स को नहीं।

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

## **मास्टर और उसकी चाइल्ड लेआउट्स पर फुटर दृश्यता नियंत्रित करें**

एक मास्टर पदानुक्रम में समान फुटर सेटिंग्स लागू करने के लिये, [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager) मेथड का प्रयोग करें। [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/masterslideheaderfootermanager/) के प्रसार मेथड मास्टर, उसके निर्भरताप्राप्त लेआउट स्लाइड्स और नॉर्मल स्लाइड्स पर कार्य करते हैं; वे केवल एक नॉर्मल स्लाइड को लक्षित नहीं करते।

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

**मास्टर स्लाइड और लेआउट स्लाइड में क्या अंतर है?**

मास्टर स्लाइड प्रस्तुति की थीम और साझा स्वरूप को परिभाषित करती है। लेआउट स्लाइड मास्टर से संबंधित होती है और प्लेसहोल्डर की पुन: उपयोग योग्य व्यवस्था को परिभाषित करती है। नॉर्मल स्लाइड्स इन लेआउट्स का उपयोग करती हैं और स्लाइड‑विशिष्ट सामग्री संग्रहीत करती हैं।

**क्या मैं एक लेआउट स्लाइड को एक प्रस्तुति से दूसरी प्रस्तुति में कॉपी कर सकता हूँ?**

हां। आप गंतव्य कलेक्शन में [addClone](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone) मेथड के साथ एक प्रति जोड़ सकते हैं। प्रस्तुति के बीच कॉपी करते समय स्रोत लेआउट द्वारा उपयोग किए गए फ़ॉन्ट, थीम, चित्र और अन्य संसाधनों की भी जाँच करें।

**जब मैं किसी उपयोग में मौजूद लेआउट को संशोधित करता हूँ तो क्या होता है?**

निर्भरताप्राप्त स्लाइड्स लेआउट परिवर्तन को विरासत में लेती हैं, जब तक कि उन्होंने स्थानीय रूप से स्वरूप या वस्तुओं को ओवरराइड नहीं किया हो। प्लेसहोल्डर ज्यामिति और विरासत शैली कई स्लाइड्स पर एक साथ बदल सकती है। संपादन से पहले प्रभावित स्लाइड्स की पहचान करने के लिये [getDependingSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) का उपयोग करें।

**यदि मैं किसी अभी भी उपयोग में रहने वाले लेआउट को हटाता हूँ तो क्या होता है?**

Aspose.Slides एक [PptxEditException](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/pptxeditexception/) फेंकता है। पहले निर्भरताप्राप्त स्लाइड्स को पुनः असाइन करें, या केवल अनउपयोगी लेआउट्स को हटाने के लिये [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) का उपयोग करें।