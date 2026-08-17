---
title: Android पर स्लाइड लेआउट लागू या बदलें
linktitle: स्लाइड लेआउट
type: docs
weight: 60
url: /hi/androidjava/slide-layout/
keywords:
- स्लाइड लेआउट
- सामग्री लेआउट
- प्लेसहोल्डर
- प्रस्तुति डिजाइन
- स्लाइड डिजाइन
- अप्रयुक्त लेआउट
- फ़ुटर दृश्यता
- शीर्षक स्लाइड
- शीर्षक और सामग्री
- अनुभाग शीर्षक
- दो सामग्री
- तुलना
- केवल शीर्षक
- खाली लेआउट
- कैप्शन के साथ सामग्री
- कैप्शन के साथ चित्र
- शीर्षक और ऊर्ध्वाधर पाठ
- ऊर्ध्वाधर शीर्षक और पाठ
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android में Java के माध्यम से स्लाइड लेआउट लागू करें, बनाएं और संशोधित करें, प्लेसहोल्डर जोड़ें, अप्रयुक्त लेआउट हटाएँ, और फ़ुटर दृश्यता नियंत्रित करें।"
---
## **परिचय**

एक स्लाइड लेआउट शीर्षक, टेक्स्ट, चित्र, चार्ट, और तालिका जैसे प्लेसहोल्डरों की स्थितियों और स्वरूपण को परिभाषित करता है। लेआउट लागू करने से स्लाइड्स में एकसमान संरचना बनती है जबकि प्रत्येक स्लाइड को अपना सामग्री रखने की अनुमति मिलती है।

सबसे सामान्य लेआउट में शामिल हैं:

- **Title Slide**: शीर्षक और उपशीर्षक प्लेसहोल्डर शामिल करता है।
- **Title and Content**: शीर्षक प्लेसहोल्डर और सामान्य प्रयोजन सामग्री प्लेसहोल्डर शामिल करता है।
- **Blank**: कोई सामग्री प्लेसहोल्डर नहीं होते और जब सभी आकार मैन्युअल रूप से स्थित किए जाएंगे तब उपयोगी होता है।

## **लेआउट विरासत को समझें**

एक प्रस्तुति तीन संबंधित स्तर रखती है:

1. A [मास्टर स्लाइड](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslide/) थीम, साझा स्वरूपण, पृष्ठभूमि और सामान्य वस्तुओं को परिभाषित करता है।
1. A [लेआउट स्लाइड](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutslide/) एक मास्टर से जुड़ी होती है और प्लेसहोल्डरों की विशिष्ट व्यवस्था को परिभाषित करती है।
1. A [सामान्य स्लाइड](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/) एक लेआउट का उपयोग करती है और उस स्लाइड के लिए दर्ज सामग्री को संग्रहीत करती है।

एक सामान्य स्लाइड अपने लेआउट से थीम और स्वरूपण विरासत में प्राप्त करती है, और लेआउट अपने मास्टर से विरासत में प्राप्त करता है। सामान्य स्लाइड पर सीधे सेट किया गया मान उस स्तर पर विरासत में मिले मान को ओवरराइड करता है। जब एक सामान्य स्लाइड बनाई जाती है, उसकी प्लेसहोल्डर आकार चयनित लेआउट से उत्पन्न होते हैं, जबकि उन प्लेसहोल्डरों में दर्ज सामग्री सामान्य स्लाइड की ही होती है।

स्लाइड बनाने से पहले लेआउट में आवश्यक प्लेसहोल्डर जोड़ें। बाद में लेआउट में एक नया प्लेसहोल्डर जोड़ने से मौजूदा सामान्य स्लाइड में स्वचालित रूप से संबंधित प्लेसहोल्डर आकार नहीं बनता।

इस संबंध के दो महत्वपूर्ण परिणाम हैं:

- लेआउट पर विरासत में मिला स्वरूपण या मौजूदा प्लेसहोल्डर ज्यामिति बदलने से उस पर निर्भर सभी स्लाइड अपडेट हो सकते हैं। पहले उपयोग में हो रहे लेआउट को संपादित करने से पहले उसके निर्भर स्लाइड की जाँच करें और resulting presentation की समीक्षा करें।
- एक लेआउट जिसे अभी भी कोई स्लाइड उपयोग कर रही है, उसे हटाया नहीं जा सकता। पहले उसके निर्भर स्लाइड को किसी दूसरे लेआउट पर पुनः असाइन करें, या केवल अनउपयोगी लेआउट को हटाएँ।

इस पदानुक्रम के शीर्ष स्तर के बारे में अधिक जानकारी के लिए देखें [Slide Master](/slides/hi/androidjava/slide-master/)।

## **स्लाइड लेआउट चुनें और लागू करें**

जब प्रस्तुति मानक PowerPoint लेआउट परिभाषाओं का पालन करती है तो लेआउट प्रकार का उपयोग करें। लेआउट नाम उपयोगकर्ता‑संपादन योग्य होते हैं और स्थानीयकृत किए जा सकते हैं, इसलिए स्रोत टेम्पलेट को नियंत्रित न करने पर नाम‑आधारित चयन कम भरोसेमंद होता है।

निम्न उदाहरण पहले मास्टर पर **Title and Content** की खोज करता है। यदि वह लेआउट उपलब्ध नहीं है, तो जानबूझकर **Blank** पर वापसfallback करता है। दूसरा null जाँच आवश्यक है क्योंकि प्रस्तुति में केवल कस्टम लेआउट ही हो सकते हैं। चयनित लेआउट फिर पहले सामान्य स्लाइड पर [ISlide.setLayoutSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) मेथड के माध्यम से लागू किया जाता है।

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

एक स्लाइड का लेआउट बदलने से सीधे स्लाइड में जोड़ी गई सामान्य आकार नहीं हटते। हालांकि, प्लेसहोल्डर स्थितियों, विरासत में मिले स्वरूपण और मौजूदा प्लेसहोल्डरों व नए लेआउट के बीच का संबंध बदल सकता है, इसलिए विभिन्न लेआउट के बीच स्विच करते समय आउटपुट की जाँच करें।

## **लेआउट स्लाइड जोड़ें**

चयन और निर्माण अलग‑अलग कार्य हैं। पिछले उदाहरण ने मौजूदा लेआउट चुना; उसने कोई नया नहीं बनाया। लेआउट बनाने के लिए लक्षित मास्टर की लेआउट कलेक्शन पर [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) मेथड को कॉल करें।

निम्न उदाहरण हमेशा `Report Title and Content` नामक नया **Title and Content** लेआउट जोड़ता है, फिर उस पर आधारित एक सामान्य स्लाइड जोड़ता है। लेआउट नाम संग्रह में अद्वितीय होने चाहिए।

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

केवल तभी लेआउट जोड़ें जब टेम्पलेट को वास्तव में किसी अतिरिक्त पुन: उपयोग योग्य संरचना की आवश्यकता हो। यदि उपयुक्त लेआउट पहले से मौजूद है, तो उसे चुनें और पुनः उपयोग करें, न कि एक डुप्लीकेट बनाएँ।

## **लेआउट स्लाइड में प्लेसहोल्डर जोड़ें**

[ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) मेथड एक [ILayoutPlaceholderManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) प्रदान करता है जिससे लेआउट में प्लेसहोल्डर आकार जोड़े जा सकते हैं।

| PowerPoint प्लेसहोल्डर              | `ILayoutPlaceholderManager` विधि |
| ----------------------------------- | -------------------------------- |
| ![सामग्री](content.png)             | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![सामग्री (ऊर्ध्वाधर)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![पाठ](text.png)                   | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![पाठ (ऊर्ध्वाधर)](textV.png)       | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![चित्र](picture.png)             | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![चार्ट](chart.png)                 | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![तालिका](table.png)                 | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![मीडिया](media.png)                 | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![ऑनलाइन छवि](onlineImage.png)    | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

निम्न उदाहरण सत्यापित करता है कि **Blank** लेआउट मौजूद है, उसमें चार प्लेसहोल्डर जोड़ता है, और फिर संशोधित लेआउट का उपयोग करने वाली एक सामान्य स्लाइड बनाता है। क्रम जानबूझकर है: प्लेसहोल्डर पहले जोड़े जाते हैं, फिर सामान्य स्लाइड बनाई जाती है, ताकि Aspose.Slides उस स्लाइड पर संबंधित प्लेसहोल्डर आकार उत्पन्न कर सके।

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

![लेआउट स्लाइड पर प्लेसहोल्डर](add_placeholders.png)

{{% alert color="warning" title="चेतावनी" %}}
विरासत में मिला स्वरूपण या मौजूदा लेआउट प्लेसहोल्डर की ज्यामिति बदलने से निर्भर स्लाइड प्रभावित हो सकते हैं। नया जोड़ा गया लेआउट प्लेसहोल्डर मौजूदा सामान्य स्लाइड में बैक‑फ़िल नहीं होता। लेआउट परिवर्तन को प्रस्तुति की एक कॉपी पर टेस्ट करें और हर निर्भर स्लाइड की जाँच करें।
{{% /alert %}}

## **अप्रयुक्त लेआउट स्लाइड हटाएँ**

[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) मेथड का उपयोग करके उन लेआउट को हटाएँ जिनका कोई सामान्य स्लाइड संदर्भ नहीं देता। यह मेथड अभी भी उपयोग में रहने वाले लेआउट को वैसा ही रखता है।

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

किसी विशिष्ट लेआउट को हटाने के लिए, पहले उसके [hasDependingSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--) या [getDependingSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) मेथड का उपयोग करें। किसी भी निर्भर स्लाइड को पुनः असाइन करें और फिर [ILayoutSlide.remove](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutslide/#remove--) को कॉल करें। उपयोग में रहे लेआउट को हटाने का प्रयास करने पर एक [PptxEditException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pptxeditexception/) उठाया जाता है।

## **लेआउट स्लाइड पर फुटर दृश्यता नियंत्रित करें**

एक लेआउट के अपने फुटर, स्लाइड‑नम्बर और दिनांक‑समय प्लेसहोल्डर होते हैं। इन प्लेसहोल्डरों को किसी एक लेआउट के लिए नियंत्रित करने हेतु [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) मेथड का उपयोग करें। यह तब उपयोगी होता है जब उदाहरण के तौर पर सामग्री लेआउट को फुटर दिखाना हो लेकिन शीर्षक लेआउट को नहीं।

निम्न उदाहरण एक लेआउट को सुरक्षित रूप से चुनता है और उसके फुटर तत्वों को दृश्यमान बनाता है:

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

## **मास्टर और इसकी चाइल्ड लेआउट में फुटर दृश्यता नियंत्रित करें**

मास्टर पदानुक्रम में समान फुटर सेटिंग लागू करने के लिए, [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--) मेथड का उपयोग करें। [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) की प्रसार मेथड्स मास्टर, उसके निर्भर लेआउट स्लाइड और सामान्य स्लाइड को प्रभावित करती हैं; वे केवल एक सामान्य स्लाइड को लक्षित नहीं करतीं।

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

एक मास्टर स्लाइड प्रस्तुति की थीम और साझा स्वरूपण को परिभाषित करती है। एक लेआउट स्लाइड मास्टर से जुड़ी होती है और प्लेसहोल्डरों की एक पुन: उपयोग योग्य व्यवस्था को परिभाषित करती है। सामान्य स्लाइड इन लेआउट को उपयोग करती हैं और स्लाइड‑विशिष्ट सामग्री संग्रहीत करती हैं।

**क्या मैं एक लेआउट स्लाइड को एक प्रस्तुति से दूसरी में कॉपी कर सकता हूँ?**

हाँ। गंतव्य संग्रह में कॉपी जोड़ने के लिए [addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) मेथड का उपयोग करें। विभिन्न प्रस्तुति के बीच कॉपी करते समय फ़ॉन्ट, थीम, चित्र और अन्य स्रोत लेआउट द्वारा उपयोग किए गए संसाधनों की भी जाँच करें।

**जब मैं किसी उपयोग में चल रहे लेआउट को संशोधित करता हूँ तो क्या होता है?**

निर्भरत स्लाइडें लेआउट परिवर्तन विरासत में लेती हैं जब तक कि वे स्थानीय रूप से स्वरूपण या वस्तुओं को ओवरराइड न करें। प्लेसहोल्डर ज्यामिति और विरासत में मिला स्टाइल कई स्लाइड पर एक साथ बदल सकता है। लेआउट संपादित करने से पहले प्रभावित स्लाइड की पहचान करने के लिए [getDependingSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) का उपयोग करें।

**यदि मैं अभी भी उपयोग में रहे लेआउट को हटाने की कोशिश करता हूँ तो क्या होता है?**

Aspose.Slides एक [PptxEditException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pptxeditexception/) उत्पन्न करता है। पहले निर्भर स्लाइड को पुनः असाइन करें, या केवल बिना संदर्भ वाले लेआउट को हटाने के लिए [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) का उपयोग करें।