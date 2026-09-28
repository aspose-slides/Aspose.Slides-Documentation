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
- फ़ूटर दृश्यता
- शीर्षक स्लाइड
- शीर्षक और सामग्री
- सेक्शन हेडर
- दो सामग्री
- तुलना
- केवल शीर्षक
- खाली लेआउट
- कैप्शन के साथ सामग्री
- कैप्शन के साथ चित्र
- शीर्षक और लंबवत पाठ
- लंबवत शीर्षक और पाठ
- PowerPoint
- OpenDocument
- प्रस्तुति
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android में Java के माध्यम से स्लाइड लेआउट लागू करें, बनाएं और संशोधित करें, प्लेसहोल्डर जोड़ें, अप्रयुक्त लेआउट हटाएँ, और फ़ूटर दृश्यता नियंत्रित करें।"
---
## **अवलोकन**

एक स्लाइड लेआउट शीर्षक, पाठ, चित्र, चार्ट और तालिका जैसे प्लेसहोल्डर्स की स्थितियों और स्वरूपण को परिभाषित करता है। लेआउट लागू करने से स्लाइड्स को एक समान संरचना मिलती है जबकि प्रत्येक स्लाइड को अपना कंटेंट रखने की अनुमति मिलती है।

सबसे सामान्य लेआउट शामिल हैं:

- **Title Slide**: शीर्षक और उपशीर्षक प्लेसहोल्डर्स शामिल करता है।
- **Title and Content**: एक शीर्षक प्लेसहोल्डर और एक सामान्य‑उद्देश्य कंटेंट प्लेसहोल्डर शामिल करता है।
- **Blank**: कोई कंटेंट प्लेसहोल्डर नहीं होता और जब सभी आकारों को मैन्युअल रूप से स्थित किया जायेगा तब उपयोगी रहता है।

## **लेआउट विरासत को समझें**

एक प्रस्तुति में तीन संबंधित स्तर होते हैं:

1. एक [master slide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslide/) थीम, साझा स्वरूपण, पृष्ठभूमियां और सामान्य वस्तुओं को परिभाषित करता है।
1. एक [layout slide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutslide/) एक मास्टर से संबंधित होता है और प्लेसहोल्डर्स की विशिष्ट व्यवस्था को परिभाषित करता है।
1. एक [normal slide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/) एक लेआउट का प्रयोग करता है और उस स्लाइड के लिए दर्ज किया गया कंटेंट संग्रहीत करता है।

एक सामान्य स्लाइड अपने लेआउट से थीम और स्वरूपण विरासत में लेती है, और लेआउट अपने मास्टर से विरासत लेता है। सामान्य स्लाइड पर सीधे सेट किया गया मान उस स्तर पर विरासत वाले मान को ओवरराइड कर देता है। जब एक सामान्य स्लाइड बनाई जाती है, तो उसके प्लेसहोल्डर आकार चयनित लेआउट से उत्पन्न होते हैं, जबकि उन प्लेसहोल्डर्स में दर्ज किया गया कंटेंट सामान्य स्लाइड से जुड़ा होता है।

स्लाइड्स बनाने से पहले लेआउट में आवश्यक प्लेसहोल्डर्स जोड़ें। बाद में लेआउट में दूसरा प्लेसहोल्डर जोड़ने से स्वचालित रूप से मौजूदा सामान्य स्लाइड्स में संबंधित प्लेसहोल्डर आकार नहीं बनता।

इस संबंध के दो महत्वपूर्ण परिणाम हैं:

- लेआउट पर विरासतित स्वरूपण या मौजूदा प्लेसहोल्डर ज्यामिति को बदलने से उन सभी स्लाइड्स को अपडेट किया जा सकता है जो उस पर निर्भर हैं। किसी लेआउट को संपादित करने से पहले, उसके निर्भर स्लाइड्स की जांच करें और परिणामी प्रस्तुति की समीक्षा करें।
- वह लेआउट जिसे अभी भी किसी स्लाइड द्वारा उपयोग किया जा रहा है, उसे हटाया नहीं जा सकता। पहले उसके निर्भर स्लाइड्स को किसी अन्य लेआउट पर पुनः असाइन करें, या केवल अप्रयुक्त लेआउट्स को हटाएँ।

इस पदानुक्रम के शीर्ष स्तर के बारे में अधिक जानकारी के लिए, देखें [Slide Master](/slides/hi/androidjava/slide-master/)।

एक स्लाइड या साझा लेआउट पर विरासतित लोगो या सजावटी मास्टर आकारों को छिपाने के लिए, देखें [Control the Visibility of Master Graphics](/slides/hi/androidjava/slide-master/)। यह उदाहरण एक ही मास्टर का उपयोग करने वाली दो स्लाइड्स की तुलना करता है।

## **स्लाइड लेआउट का चयन और लागू करना**

जब प्रस्तुति मानक PowerPoint लेआउट परिभाषाओं का अनुसरण करती है, तो लेआउट प्रकार का उपयोग करें। लेआउट नाम उपयोग‑संपादन योग्य होते हैं और स्थानीयकृत किए जा सकते हैं, इसलिए नाम‑आधारित चयन कम भरोसेमंद होता है जब तक कि आप स्रोत टेम्पलेट को नियंत्रित न कर रहे हों।

निम्नलिखित उदाहरण पहले मास्टर पर **Title and Content** लेआउट को खोजता है। यदि वह लेआउट उपलब्ध नहीं है, तो जानबूझकर **Blank** पर वापस जाता है। दूसरा null चेक आवश्यक है क्योंकि प्रस्तुति में केवल कस्टम लेआउट्स हो सकते हैं। चयनित लेआउट फिर पहले सामान्य स्लाइड पर [ISlide.setLayoutSlide](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) विधि के माध्यम से लागू किया जाता है।

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

एक स्लाइड के लेआउट को बदलने से सीधे स्लाइड में जोड़ी गई सामान्य आकार नहीं हटतीं। हालांकि, प्लेसहोल्डर स्थितियां, विरासतित स्वरूपण, और मौजूदा प्लेसहोल्डर्स तथा नए लेआउट के बीच का correspondence बदल सकता है, इसलिए सेण्ट्रली विभिन्न लेआउट्स के बीच स्विच करते समय आउटपुट की जांच करें।

## **लेआउट स्लाइड जोड़ें**

चयन और निर्माण अलग‑अलग ऑपरेशन्स हैं। पिछला उदाहरण मौजूदा लेआउट को चुनता है; वह नया नहीं बनाता। लेआउट बनाने के लिए, लक्ष्य मास्टर के लेआउट संग्रह पर [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) विधि को कॉल करें।

निम्नलिखित उदाहरण हमेशा एक नया **Title and Content** लेआउट जिसका नाम `Report Title and Content` है, जोड़ता है, फिर उस पर आधारित एक सामान्य स्लाइड जोड़ता है। लेआउट नाम संग्रह के भीतर अद्वितीय होने चाहिए।

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

केवल तब लेआउट जोड़ें जब टेम्पलेट को वास्तव में एक और पुन: उपयोग योग्य संरचना की जरूरत हो। यदि उपयुक्त लेआउट पहले से मौजूद है, तो उसे चुनें और पुन: उपयोग करें, नया बनाते हुए डुप्लिकेट न बनाएं।

## **लेआउट स्लाइड में प्लेसहोल्डर्स जोड़ें**

[ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) विधि एक [ILayoutPlaceholderManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/) प्रदान करती है जिससे लेआउट में प्लेसहोल्डर आकार जोड़े जा सकते हैं।

| PowerPoint प्लेसहोल्डर               | `ILayoutPlaceholderManager` Method |
| ----------------------------------- | ---------------------------------- |
| ![कंटेंट](content.png)             | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| ![कंटेंट (वर्टिकल)](contentV.png) | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| ![टेक्स्ट](text.png)                   | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| ![टेक्स्ट (वर्टिकल)](textV.png)       | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| ![चित्र](picture.png)             | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| ![चार्ट](chart.png)                 | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| ![टेबल](table.png)                 | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| ![SmartArt](smartart.png)           | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| ![मीडिया](media.png)                 | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ![ऑनलाइन इमेज](onlineImage.png)    | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

निम्नलिखित उदाहरण यह सत्यापित करता है कि **Blank** लेआउट मौजूद है, उसमें चार प्लेसहोल्डर्स जोड़ता है, और फिर संशोधित लेआउट का उपयोग करने वाली एक सामान्य स्लाइड बनाता है। क्रम का इरादा यह है: प्लेसहोल्डर्स पहले जोड़े जाते हैं, फिर सामान्य स्लाइड बनाई जाती है, ताकि Aspose.Slides उस स्लाइड पर संबंधित प्लेसहोल्डर आकार उत्पन्न कर सके।

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

{{% alert color="warning" title="Warning" %}}
विरासतित स्वरूपण या मौजूदा लेआउट प्लेसहोल्डर्स की ज्यामिति को बदलने से निर्भर स्लाइड्स प्रभावित हो सकती हैं। नया जोड़ा गया लेआउट प्लेसहोल्डर मौजूदा सामान्य स्लाइड्स में बैक‑फ़िल नहीं होता। लेआउट बदलावों का परीक्षण प्रस्तुति की प्रतिलिपि पर करें और प्रत्येक निर्भर स्लाइड की जाँच करें।
{{% /alert %}}

## **अनुपयोगी लेआउट स्लाइड्स हटाएँ**

[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) विधि का उपयोग करके उन लेआउट्स को हटाएँ जिन्हें कोई सामान्य स्लाइड संदर्भित नहीं करती। यह विधि उन लेआउट्स को बरकरार रखती है जो अभी भी उपयोग में हैं।

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

एक विशिष्ट लेआउट हटाने के लिए, पहले उसके [hasDependingSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutslide/#hasDependingSlides--) या [getDependingSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) विधि का उपयोग करें। किसी भी निर्भर स्लाइड को पुनः असाइन करने के बाद ही [ILayoutSlide.remove](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutslide/#remove--) कॉल करें। उपयोग में रहे लेआउट को हटाने का प्रयास करने पर एक [PptxEditException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pptxeditexception/) उत्पन्न होता है।

## **लेआउट स्लाइड पर फ़ूटर की दृश्यता नियंत्रित करें**

एक लेआउट की अपनी फ़ूटर, स्लाइड‑नंबर, और तिथि‑समय प्लेसहोल्डर्स होते हैं। उन प्लेसहोल्डर्स को एक लेआउट के लिए नियंत्रित करने हेतु [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) विधि का उपयोग करें। यह तब उपयोगी होता है जब उदाहरण के तौर पर कंटेंट लेआउट्स को फ़ूटर दिखाना हो लेकिन शीर्षक लेआउट्स को नहीं।

निम्नलिखित उदाहरण एक लेआउट को सुरक्षित रूप से चुनता है और उसके फ़ूटर तत्वों को दृश्यमान बनाता है:

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

## **मास्टर और उसकी चाइल्ड लेआउट्स पर फ़ूटर की दृश्यता नियंत्रित करें**

एक मास्टर पदानुक्रम में निरंतर फ़ूटर सेटिंग्स लागू करने के लिए, [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslide/#getHeaderFooterManager--) विधि का उपयोग करें। [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) की प्रसार विधियां मास्टर, उसकी निर्भर लेआउट स्लाइड्स और सामान्य स्लाइड्स पर लागू होती हैं; वे केवल एक सामान्य स्लाइड को लक्षित नहीं करतीं।

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

मास्टर स्लाइड प्रस्तुति की थीम और साझा स्वरूपण को परिभाषित करती है। लेआउट स्लाइड एक मास्टर से जुड़ी होती है और प्लेसहोल्डर्स की पुन: उपयोग योग्य व्यवस्था को परिभाषित करती है। सामान्य स्लाइड्स उन लेआउट्स का उपयोग करती हैं और स्लाइड‑विशिष्ट कंटेंट संग्रहीत करती हैं।

**क्या मैं एक लेआउट स्लाइड को एक प्रस्तुति से दूसरी में कॉपी कर सकता हूँ?**

हाँ। लक्ष्य संग्रह में कॉपी जोड़ने के लिए [addClone](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) विधि का उपयोग करें। प्रस्तुतियों के बीच कॉपी करते समय स्रोत लेआउट द्वारा उपयोग किये गए फ़ॉन्ट, थीम, चित्र और अन्य संसाधनों की भी जाँच करें।

**यदि मैं ऐसी लेआउट को संशोधित करता हूँ जो पहले से उपयोग में है तो क्या होता है?**

निर्भर स्लाइड्स लेआउट परिवर्तन को विरासत में लेती हैं जब तक कि उन्होंने स्थानीय स्तर पर प्रभावित स्वरूपण या वस्तुओं को ओवरराइड नहीं किया हो। इसलिए प्लेसहोल्डर ज्यामिति और विरासतित शैली कई स्लाइड्स में एक साथ बदल सकती है। लेआउट संपादित करने से पहले [getDependingSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/ilayoutslide/#getDependingSlides--) का उपयोग करके प्रभावित स्लाइड्स की पहचान करें।

**यदि मैं अभी भी उपयोग में रहने वाला लेआउट हटाता हूँ तो क्या होगा?**

Aspose.Slides एक [PptxEditException](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/pptxeditexception/) फेंकेगा। पहले निर्भर स्लाइड्स को पुनः असाइन करें, या केवल अनरेफ़रेंस्ड लेआउट्स को हटाने के लिए [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/androidjava/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) का उपयोग करें।