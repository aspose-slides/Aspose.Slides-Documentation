---
title: जावा में स्लाइड लेआउट लागू करें या बदलें
linktitle: स्लाइड लेआउट
type: docs
weight: 60
url: /hi/java/slide-layout/
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
- कैप्शन सहित सामग्री
- कैप्शन सहित चित्र
- शीर्षक और ऊर्ध्वाधर पाठ
- ऊर्ध्वाधर शीर्षक और पाठ
- PowerPoint
- OpenDocument
- प्रस्तुति
- Java
- Aspose.Slides
description: "Aspose.Slides for Java में स्लाइड लेआउट को लागू करें, बनाएं और संशोधित करें, प्लेसहोल्डर जोड़ें, अप्रयुक्त लेआउट हटाएँ, और फ़ूटर दृश्यता को नियंत्रित करें।"
---
## **समीक्षा**

एक स्लाइड लेआउट शीर्षक, पाठ, चित्र, चार्ट और तालिकाओं जैसे प्लेसहोल्डर की स्थितियों और स्वरूपण को परिभाषित करता है। लेआउट लागू करने से स्लाइड्स को एक सुसंगत संरचना मिलती है जबकि प्रत्येक स्लाइड को अपनी सामग्री रखने की अनुमति मिलती है।

सबसे सामान्य लेआउट में शामिल हैं:

- **Title Slide**: शीर्षक और उपशीर्षक प्लेसहोल्डर शामिल करता है।
- **Title and Content**: एक शीर्षक प्लेसहोल्डर और एक सामान्य उद्देश्य सामग्री प्लेसहोल्डर शामिल करता है।
- **Blank**: इसमें कोई सामग्री प्लेसहोल्डर नहीं होते और यह उपयोगी होता है जब प्रत्येक आकार को मैन्युअल रूप से स्थित किया जाएगा।

## **लेआउट विरासत को समझें**

एक प्रस्तुति में तीन संबंधित स्तर होते हैं:

1. एक [master slide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterslide/) थीम, साझा स्वरूपण, पृष्ठभूमि और सामान्य वस्तुओं को परिभाषित करता है।
1. एक [layout slide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutslide/) एक master का भाग होता है और प्लेसहोल्डर की विशेष व्यवस्था को परिभाषित करता है।
1. एक [normal slide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/) एक लेआउट का उपयोग करता है और उस स्लाइड के लिए दर्ज की गई सामग्री को संग्रहीत करता है।

एक normal slide अपनी लेआउट से थीम और स्वरूपण को विरासत में प्राप्त करता है, और लेआउट अपने master से विरासत में प्राप्त करता है। normal slide पर सीधे सेट किया गया मान उस स्तर पर विरासत में मिली मान को ओवरराइड करता है। जब एक normal slide बनाया जाता है, तो उसके प्लेसहोल्डर आकार चयनित लेआउट से उत्पन्न होते हैं, जबकि उन प्लेसहोल्डर में दर्ज की गई सामग्री normal slide की होती है।

आवश्यक प्लेसहोल्डर को लेआउट में जोड़ें इससे पहले कि आप उसके आधार पर स्लाइड्स बनाएँ। लेआउट में बाद में कोई अन्य प्लेसहोल्डर जोड़ने से मौजूदा normal स्लाइड्स में स्वचालित रूप से संबंधित प्लेसहोल्डर आकार नहीं जुड़ता।

इस संबंध के दो महत्वपूर्ण परिणाम हैं:

- लेआउट पर विरासत में मिला स्वरूपण या मौजूदा प्लेसहोल्डर ज्योमेट्री को बदलने से उन सभी स्लाइड्स को अपडेट किया जा सकता है जो इस पर निर्भर हैं। कोई लेआउट जो पहले से उपयोग में है, उसे संपादित करने से पहले उसके निर्भर स्लाइड्स की जांच करें और परिणामी प्रस्तुति की समीक्षा करें।
- एक लेआउट जो अभी भी किसी स्लाइड द्वारा उपयोग में है, उसे हटाया नहीं जा सकता। पहले उसके निर्भर स्लाइड्स को किसी अन्य लेआउट को असाइन करें, या केवल अप्रयुक्त लेआउट को हटाएँ।

इस श्रेणी के शीर्ष स्तर के बारे में अधिक जानकारी के लिए देखें [Slide Master](/slides/hi/java/slide-master/)।

## **स्लाइड लेआउट का चयन और लागू करना**

जब प्रस्तुति मानक PowerPoint लेआउट परिभाषाओं का पालन करती है, तो एक लेआउट प्रकार का उपयोग करें। लेआउट नाम उपयोगकर्ता‑संपादन योग्य होते हैं और स्थानीयकृत किए जा सकते हैं, इसलिए नाम‑आधारित चयन कम भरोसेमंद होता है जब तक आप स्रोत टेम्प्लेट को नियंत्रित न कर रहे हों।

निम्न उदाहरण पहले master पर **Title and Content** को खोजता है। यदि वह लेआउट उपलब्ध नहीं है, तो इरादतन **Blank** पर वापस जाता है। दूसरा null जाँच आवश्यक है क्योंकि प्रस्तुति में केवल कस्टम लेआउट हो सकते हैं। चयनित लेआउट फिर पहले normal स्लाइड पर [ISlide.setLayoutSlide](https://reference.aspose.com/slides/hi/java/com.aspose.slides/islide/#setLayoutSlide-com.aspose.slides.ILayoutSlide-) मेथड के द्वारा लागू किया जाता है।

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

लेआउट बदलने से सामान्य रूप से स्लाइड में सीधे जोड़े गए आकार हटते नहीं हैं। हालांकि, प्लेसहोल्डर की स्थितियाँ, विरासत में मिला स्वरूपण, और मौजूदा प्लेसहोल्डर व नए लेआउट के बीच का मेल बदल सकता है, इसलिए बहुत अलग लेआउट के बीच स्विच करते समय आउटपुट की जाँच करें।

## **लेआउट स्लाइड जोड़ें**

चयन और निर्माण अलग‑अलग कार्य हैं। पिछले उदाहरण ने मौजूदा लेआउट को चुना; उसने नया नहीं बनाया। लेआउट बनाने के लिए लक्ष्य master की लेआउट कलेक्शन पर [IMasterLayoutSlideCollection.add](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterlayoutslidecollection/#add-byte-java.lang.String-) मेथड को कॉल करें।

निम्न उदाहरण हमेशा एक नया **Title and Content** लेआउट `Report Title and Content` नाम से जोड़ता है, फिर उसके आधार पर एक normal स्लाइड जोड़ता है। लेआउट नाम कलेक्शन में अद्वितीय होने चाहिए।

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

टेम्प्लेट को वास्तव में एक अतिरिक्त पुन: उपयोगी संरचना की आवश्यकता होने पर ही लेआउट जोड़ें। यदि उपयुक्त लेआउट पहले से मौजूद है, तो उसे चुनें और पुन: उपयोग करें, डुप्लिकेट बनाने के बजाय।

## **लेआउट स्लाइड में प्लेसहोल्डर जोड़ें**

[ILayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutslide/#getPlaceholderManager--) मेथड एक [ILayoutPlaceholderManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutplaceholdermanager/) प्रदान करता है जिससे लेआउट में प्लेसहोल्डर आकार जोड़े जा सकते हैं।

| PowerPoint प्लेसहोल्डर            | `ILayoutPlaceholderManager` Method |
| ----------------------------------- | ---------------------------------- |
| सामग्री                              | [`addContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutplaceholdermanager/#addContentPlaceholder-float-float-float-float-) |
| सामग्री (ऊर्ध्वाधर)                 | [`addVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalContentPlaceholder-float-float-float-float-) |
| पाठ                                 | [`addTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutplaceholdermanager/#addTextPlaceholder-float-float-float-float-) |
| पाठ (ऊर्ध्वाधर)                     | [`addVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutplaceholdermanager/#addVerticalTextPlaceholder-float-float-float-float-) |
| चित्र                               | [`addPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutplaceholdermanager/#addPicturePlaceholder-float-float-float-float-) |
| चार्ट                               | [`addChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutplaceholdermanager/#addChartPlaceholder-float-float-float-float-) |
| तालिका                              | [`addTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutplaceholdermanager/#addTablePlaceholder-float-float-float-float-) |
| SmartArt                            | [`addSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutplaceholdermanager/#addSmartArtPlaceholder-float-float-float-float-) |
| Media                               | [`addMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutplaceholdermanager/#addMediaPlaceholder-float-float-float-float-) |
| ऑनलाइन छवि                         | [`addOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutplaceholdermanager/#addOnlineImagePlaceholder-float-float-float-float-) |

निम्न उदाहरण यह सत्यापित करता है कि **Blank** लेआउट मौजूद है, उसमें चार प्लेसहोल्डर जोड़ता है, और फिर एक normal स्लाइड बनाता है जो संशोधित लेआउट को उपयोग करता है। क्रम जानबूझकर है: प्लेसहोल्डर पहले जोड़ें, फिर normal स्लाइड बनाएं, ताकि Aspose.Slides उस स्लाइड पर संबंधित प्लेसहोल्डर आकार बना सके।

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
विरासत में मिला स्वरूपण या मौजूदा लेआउट प्लेसहोल्डर की ज्योमेट्री को बदलने से निर्भर स्लाइड्स प्रभावित हो सकते हैं। नई जोड़ी गई लेआउट प्लेसहोल्डर मौजूदा normal स्लाइड्स में बैकफ़िल नहीं होती। लेआउट परिवर्तन को प्रस्तुति की एक कॉपी पर परीक्षण करें और हर निर्भर स्लाइड की जाँच करें।
{{% /alert %}}

## **अप्रयुक्त लेआउट स्लाइड्स हटाएँ**

[Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) मेथड का उपयोग करके उन लेआउट को हटाएँ जिनका कोई normal स्लाइड संदर्भ नहीं देता। यह मेथड उन लेआउट को जैसा है वैसा छोड़ देता है जो अभी भी उपयोग में हैं।

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

एक विशिष्ट लेआउट हटाने के लिए, पहले उसके [hasDependingSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutslide/#hasDependingSlides--) या [getDependingSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) मेथड का उपयोग करें। कॉल करने से पहले किसी भी निर्भर स्लाइड को पुनः असाइन करें [ILayoutSlide.remove](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutslide/#remove--)। प्रयुक्त लेआउट को हटाने का प्रयास करने पर एक [PptxEditException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pptxeditexception/) उत्पन्न होगा।

## **लेआउट स्लाइड पर फुटर दृश्यता नियंत्रित करें**

एक लेआउट का अपना फुटर, स्लाइड‑नंबर, और दिनांक‑समय प्लेसहोल्डर होता है। किसी लेआउट के लिए इन प्लेसहोल्डर को नियंत्रित करने हेतु [ILayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutslide/#getHeaderFooterManager--) मेथड का उपयोग करें। यह तब उपयोगी होता है जब उदाहरण के लिए कंटेंट लेआउट्स को फुटर दिखाना चाहिए लेकिन टाइटल लेआउट्स को नहीं।

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

## **मास्टर और उसके चाइल्ड लेआउट्स पर फुटर दृश्यता नियंत्रित करें**

एक master पदानुक्रम पर निरंतर फुटर सेटिंग लागू करने हेतु [IMasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterslide/#getHeaderFooterManager--) मेथड का उपयोग करें। [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/java/com.aspose.slides/imasterslideheaderfootermanager/) की प्रसार विधियाँ master और उसके निर्भर लेआउट स्लाइड्स तथा normal स्लाइड्स पर लागू होती हैं; वे केवल एक normal स्लाइड को लक्षित नहीं करतीं।

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

## **अक्सर पूछे जाने वाले प्रश्न**

**मास्टर स्लाइड और लेआउट स्लाइड के बीच क्या अंतर है?**

मास्टर स्लाइड प्रस्तुति की थीम और साझा स्वरूपण को परिभाषित करती है। लेआउट स्लाइड एक master का हिस्सा होती है और प्लेसहोल्डर की एक पुन: उपयोगी व्यवस्था को परिभाषित करती है। Normal स्लाइड्स इन लेआउट्स को उपयोग करती हैं और स्लाइड‑विशिष्ट सामग्री संग्रहीत करती हैं।

**क्या मैं एक लेआउट स्लाइड को एक प्रस्तुति से दूसरी प्रस्तुति में कॉपी कर सकता हूँ?**

हाँ। लक्ष्य कलेक्शन में कॉपी जोड़ने के लिए [addClone](https://reference.aspose.com/slides/hi/java/com.aspose.slides/igloballayoutslidecollection/#addClone-com.aspose.slides.ILayoutSlide-) मेथड का उपयोग करें। प्रस्तुतियों के बीच कॉपी करते समय फ़ॉन्ट, थीम, छवियों और स्रोत लेआउट द्वारा उपयोग किए जाने वाले अन्य संसाधनों की भी जाँच करें।

**जब मैं किसी उपयोग में मौजूद लेआउट को संशोधित करता हूँ तो क्या होता है?**

निर्भर स्लाइड्स लेआउट परिवर्तन को विरासत में ले लेती हैं जब तक कि उन्होंने स्थानीय रूप से प्रभावित स्वरूपण या वस्तुओं को ओवरराइड नहीं किया हो। प्लेसहोल्डर ज्योमेट्री और विरासत में मिला शैली कई स्लाइड्स पर एक साथ बदल सकती है। संपादन करने से पहले प्रभावित स्लाइड्स की पहचान के लिए [getDependingSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/ilayoutslide/#getDependingSlides--) का उपयोग करें।

**यदि मैं वह लेआउट हटाता हूँ जो अभी भी उपयोग में है तो क्या होगा?**

Aspose.Slides एक [PptxEditException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pptxeditexception/) फेंकेगा। पहले निर्भर स्लाइड्स को पुनः असाइन करें, या केवल अनरेफ़रेंस्ड लेआउट्स को हटाने के लिए [removeUnusedLayoutSlides](https://reference.aspose.com/slides/hi/java/com.aspose.slides/compress/#removeUnusedLayoutSlides-com.aspose.slides.Presentation-) का उपयोग करें।