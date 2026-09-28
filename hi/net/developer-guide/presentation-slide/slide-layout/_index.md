---
title: .NET में स्लाइड लेआउट लागू करें या बदलें
linktitle: स्लाइड लेआउट
type: docs
weight: 60
url: /hi/net/slide-layout/
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
- ब्लैंक लेआउट
- कैप्शन के साथ सामग्री
- कैप्शन के साथ चित्र
- शीर्षक और वर्टिकल टेक्स्ट
- वर्टिकल शीर्षक और टेक्स्ट
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- C#
- .NET
- Aspose.Slides
description: "Aspose.Slides for .NET में स्लाइड लेआउट लागू करें, बनाएं और संशोधित करें, प्लेसहोल्डर जोड़ें, अप्रयुक्त लेआउट हटाएँ, और फ़ूटर दृश्यता को नियंत्रित करें।"
---
## **समीक्षा**

एक स्लाइड लेआउट शीर्षक, पाठ, चित्र, चार्ट और तालिकाओं जैसे प्लेसहोल्डर्स की स्थितियों और स्वरूपण को परिभाषित करता है। लेआउट लागू करने से स्लाइड्स को एक समान संरचना मिलती है जबकि प्रत्येक स्लाइड को अपना स्वयं का सामग्री रखने की अनुमति मिलती है।

सबसे सामान्य लेआउट शामिल हैं:

- **शीर्षक स्लाइड**: शीर्षक और उपशीर्षक प्लेसहोल्डर्स शामिल करता है।
- **शीर्षक और सामग्री**: एक शीर्षक प्लेसहोल्डर और एक सामान्य‑उद्देश्य सामग्री प्लेसहोल्डर शामिल है।
- **ब्लैंक**: कोई सामग्री प्लेसहोल्डर नहीं होते और यह तब उपयोगी होता है जब हर आकार को मैन्युअली स्थित किया जाता है।

## **लेआउट उत्तराधिकार को समझें**

एक प्रस्तुति में तीन संबंधित स्तर होते हैं:

1. एक [मास्टर स्लाइड](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslide/) थीम, साझा स्वरूपण, पृष्ठभूमि और सामान्य वस्तुओं को परिभाषित करता है।
2. एक [लेआउट स्लाइड](https://reference.aspose.com/slides/hi/net/aspose.slides/ilayoutslide/) मास्टर का भाग होता है और प्लेसहोल्डर्स की एक विशिष्ट व्यवस्था को परिभाषित करता है।
3. एक [सामान्य स्लाइड](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/) एक लेआउट का उपयोग करता है और उस स्लाइड के लिए दर्ज की गई सामग्री को संग्रहीत करता है।

एक सामान्य स्लाइड अपने लेआउट से थीम और स्वरूपण को विरासत में प्राप्त करता है, और लेआउट अपने मास्टर से विरासत में प्राप्त करता है। सामान्य स्लाइड पर सीधे सेट किया गया मान उस स्तर पर विरासत में प्राप्त मान को अधिलेखित करता है। जब एक सामान्य स्लाइड बनाई जाती है, तो उसके प्लेसहोल्डर आकार चयनित लेआउट से उत्पन्न होते हैं, जबकि उन प्लेसहोल्डर्स में दर्ज सामग्री सामान्य स्लाइड की ही होती है।

लेआउट से स्लाइड बनाने से पहले आवश्यक प्लेसहोल्डर्स जोड़ें। बाद में लेआउट में एक और प्लेसहोल्डर जोड़ने से मौजूदा सामान्य स्लाइड्स में संबंधित प्लेसहोल्डर आकार स्वतः नहीं जुड़ेगा।

इस संबंध के दो महत्वपूर्ण परिणाम हैं:

- लेआउट पर विरासत में प्राप्त स्वरूपण या मौजूदा प्लेसहोल्डर ज्यामिति को बदलने से उस पर निर्भर सभी स्लाइड्स अपडेट हो सकती हैं। पहले से उपयोग में मौजूद लेआउट को संपादित करने से पहले उसके निर्भर स्लाइड्स की जाँच करें और परिणामी प्रस्तुति की समीक्षा करें।
- कोई लेआउट जो अभी भी किसी स्लाइड द्वारा उपयोग किया जा रहा है, उसे हटाया नहीं जा सकता। पहले उसकी निर्भर स्लाइड्स को किसी अन्य लेआउट में पुनः असाइन करें, या केवल अप्रयुक्त लेआउट हटाएँ।

इस पदानुक्रम के शीर्ष स्तर के बारे में अधिक जानकारी के लिए देखें [स्लाइड मास्टर](/slides/hi/net/slide-master/)।

एक स्लाइड या साझा लेआउट पर विरासत में प्राप्त लोगो या सजावटी मास्टर आकारों को छिपाने के लिए देखें [Control the Visibility of Master Graphics](/slides/hi/net/slide-master/)。 उदाहरण दो स्लाइड्स की तुलना करता है जो एक ही मास्टर का उपयोग करती हैं।

## **एक स्लाइड लेआउट चुनें और लागू करें**

जब प्रस्तुति मानक PowerPoint लेआउट परिभाषाओं का अनुसरण करती है, तो लेआउट प्रकार का उपयोग करें। लेआउट नाम उपयोगकर्ता‑संपादन योग्य होते हैं और स्थानीयकृत किए जा सकते हैं, इसलिए स्रोत टेम्पलेट पर नियंत्रण न होने पर नाम‑आधारित चयन कम भरोसेमंद होता है।

निम्नलिखित उदाहरण पहले मास्टर पर **शीर्षक और सामग्री** की खोज करता है। यदि वह लेआउट उपलब्ध नहीं है, तो यह जानबूझकर **ब्लैंक** पर वापस लौटता है। दूसरा null जाँच आवश्यक है क्योंकि प्रस्तुति में केवल कस्टम लेआउट ही हो सकते हैं। चयनित लेआउट फिर [ISlide.LayoutSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/layoutslide/) प्रॉपर्टी के माध्यम से पहली सामान्य स्लाइड पर लागू किया जाता है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlides = presentation.Masters[0].LayoutSlides;
var targetLayout = layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? layoutSlides.GetByType(SlideLayoutType.Blank);

if (targetLayout == null)
{
    throw new InvalidOperationException("The first master does not contain a suitable layout slide.");
}

presentation.Slides[0].LayoutSlide = targetLayout;
presentation.Save("output-with-new-layout.pptx", SaveFormat.Pptx);
```

एक स्लाइड के लेआउट को बदलने से सीधे स्लाइड में जोड़े गए सामान्य आकार हटते नहीं हैं। हालांकि, प्लेसहोल्डर स्थितियाँ, विरासत में प्राप्त स्वरूपण, और मौजूदा प्लेसहोल्डर्स व नए लेआउट के बीच मेल बदल सकता है, इसलिए विभिन्न लेआउट के बीच स्विच करते समय परिणाम की जाँच करें।

## **एक लेआउट स्लाइड जोड़ें**

चयन और निर्माण अलग‑अलग संचालन हैं। पिछला उदाहरण मौजूदा लेआउट को चुनता है; यह नया नहीं बनाता। लेआउट बनाने के लिए लक्ष्य मास्टर की लेआउट संग्रह पर [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/hi/net/aspose.slides/masterlayoutslidecollection/add/) मेथड को कॉल करें।

निम्नलिखित उदाहरण हमेशा `Report Title and Content` नामक नया **शीर्षक और सामग्री** लेआउट जोड़ता है, फिर उस पर आधारित एक सामान्य स्लाइड जोड़ता है। लेआउट नाम संग्रह के भीतर अद्वितीय होना चाहिए।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

केवल तब ही लेआउट जोड़ें जब टेम्पलेट को वास्तव में एक और पुन: उपयोग योग्य संरचना की आवश्यकता हो। यदि उपयुक्त लेआउट पहले से मौजूद है, तो उसे चुनें और पुन: उपयोग करें, न कि डुप्लिकेट बनाएं।

## **एक लेआउट स्लाइड में प्लेसहोल्डर्स जोड़ें**

[ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/hi/net/aspose.slides/ilayoutslide/placeholdermanager/) प्रॉपर्टी एक [ILayoutPlaceholderManager](https://reference.aspose.com/slides/hi/net/aspose.slides/ilayoutplaceholdermanager/) प्रदान करती है जिससे लेआउट में प्लेसहोल्डर आकार जोड़े जा सकते हैं।

| PowerPoint प्लेसहोल्डर              | ILayoutPlaceholderManager विधि |
| ----------------------------------- | -------------------------------- |
| ![सामग्री](content.png)             | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![सामग्री (Vertical)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![पाठ](text.png)                   | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![पाठ (Vertical)](textV.png)       | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![चित्र](picture.png)             | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![चार्ट](chart.png)               | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![तालिका](table.png)               | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![SmartArt](smartart.png)           | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![मीडिया](media.png)                 | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![ऑनलाइन इमेज](onlineImage.png)    | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

निम्न उदाहरण सत्यापित करता है कि **ब्लैंक** लेआउट मौजूद है, उसमें चार प्लेसहोल्डर जोड़ता है, और फिर संशोधित लेआउट का उपयोग करने वाली एक सामान्य स्लाइड बनाता है। क्रम का इरादा है: प्लेसहोल्डर सामान्य स्लाइड बनाने से पहले जोड़े जाते हैं, ताकि Aspose.Slides उस स्लाइड पर अनुरूप प्लेसहोल्डर आकार उत्पन्न कर सके।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var blankLayout = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (blankLayout == null)
{
    throw new InvalidOperationException("The presentation does not contain a Blank layout slide.");
}

var placeholderManager = blankLayout.PlaceholderManager;
placeholderManager.AddContentPlaceholder(20, 20, 310, 270);
placeholderManager.AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager.AddChartPlaceholder(20, 310, 310, 180);
placeholderManager.AddTablePlaceholder(350, 310, 350, 180);

presentation.Slides.AddEmptySlide(blankLayout);
presentation.Save("output-with-placeholders.pptx", SaveFormat.Pptx);
```

परिणाम:

![लेआउट स्लाइड पर प्लेसहोल्डर](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
विरासत में प्राप्त स्वरूपण या मौजूदा लेआउट प्लेसहोल्डर की ज्यामिति को बदलने से निर्भर स्लाइड्स प्रभावित हो सकती हैं। नया जोड़ा गया लेआउट प्लेसहोल्डर मौजूदा सामान्य स्लाइड्स में स्वचालित रूप से नहीं भरता। लेआउट परिवर्तन को प्रस्तुति की प्रतिलिपि पर परीक्षण करें और प्रत्येक निर्भर स्लाइड की जाँच करें।
{{% /alert %}}

## **अप्रयुक्त लेआउट स्लाइड्स हटाएँ**

लेआउट्स जिन्हें कोई सामान्य स्लाइड संदर्भित नहीं करती, उन्हें हटाने के लिए [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) मेथड का उपयोग करें। यह मेथड अभी भी उपयोग में चल रहे लेआउट्स को अपरिवर्तित छोड़ देता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

एक विशिष्ट लेआउट हटाने के लिए पहले उसकी [HasDependingSlides](https://reference.aspose.com/slides/hi/net/aspose.slides/ilayoutslide/hasdependingslides/) प्रॉपर्टी या [GetDependingSlides](https://reference.aspose.com/slides/hi/net/aspose.slides/ilayoutslide/getdependingslides/) मेथड का उपयोग करें। किसी भी निर्भर स्लाइड को [ILayoutSlide.Remove](https://reference.aspose.com/slides/hi/net/aspose.slides/ilayoutslide/remove/) कॉल करने से पहले पुनः असाइन करें। उपयोग में चल रहे लेआउट को हटाने का प्रयास करने पर [PptxEditException](https://reference.aspose.com/slides/hi/net/aspose.slides/pptxeditexception/) उत्पन्न होता है।

## **लेआउट स्लाइड पर फुटर दृश्यता नियंत्रित करें**

एक लेआउट का अपना फुटर, स्लाइड‑नंबर, और तिथि‑समय प्लेसहोल्डर्स होते हैं। इन प्लेसहोल्डर्स को एक लेआउट के लिए नियंत्रित करने हेतु [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/hi/net/aspose.slides/ilayoutslide/headerfootermanager/) प्रॉपर्टी का उपयोग करें। उदाहरण के लिये, सामग्री लेआउट में फुटर दिखाना चाहिए लेकिन शीर्षक लेआउट में नहीं देना चाहिए।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.TitleAndObject) ?? presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);

if (layoutSlide == null)
{
    throw new InvalidOperationException("The presentation does not contain a suitable layout slide.");
}

var headerFooterManager = layoutSlide.HeaderFooterManager;
headerFooterManager.SetFooterVisibility(true);
headerFooterManager.SetSlideNumberVisibility(true);
headerFooterManager.SetDateTimeVisibility(true);
headerFooterManager.SetFooterText("Footer text");
headerFooterManager.SetDateTimeText("Date and time text");

presentation.Save("output-with-layout-footers.pptx", SaveFormat.Pptx);
```

## **मास्टर और उसके चाइल्ड लेआउट्स पर फुटर दृश्यता नियंत्रित करें**

मास्टर पदानुक्रम में सुसंगत फुटर सेटिंग्स लागू करने के लिए [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslide/headerfootermanager/) प्रॉपर्टी का उपयोग करें। [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslideheaderfootermanager/) की प्रसार विधियाँ मास्टर, उसके निर्भर लेआउट स्लाइड्स और सामान्य स्लाइड्स पर कार्य करती हैं; वे केवल एक सामान्य स्लाइड को लक्षित नहीं करतीं।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var headerFooterManager = presentation.Masters[0].HeaderFooterManager;
headerFooterManager.SetFooterAndChildFootersVisibility(true);
headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);
headerFooterManager.SetFooterAndChildFootersText("Footer text");
headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");

presentation.Save("output-with-master-footers.pptx", SaveFormat.Pptx);
```

## **FAQ**

**मास्टर स्लाइड और लेआउट स्लाइड में क्या अंतर है?**

मास्टर स्लाइड प्रस्तुति की थीम और साझा स्वरूपण को परिभाषित करती है। लेआउट स्लाइड मास्टर का भाग होती है और प्लेसहोल्डर्स की एक पुन: उपयोग योग्य व्यवस्था को परिभाषित करती है। सामान्य स्लाइड्स इन लेआउट्स का उपयोग करती हैं और स्लाइड‑विशिष्ट सामग्री संग्रहीत करती हैं।

**क्या मैं एक लेआउट स्लाइड को एक प्रस्तुति से दूसरी में कॉपी कर सकता हूँ?**

हां। गंतव्य संग्रह में कॉपी जोड़ने के लिए [AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/globallayoutslidecollection/addclone/) मेथड का उपयोग करें। प्रस्तुतियों के बीच कॉपी करते समय स्रोत लेआउट द्वारा उपयोग किए गए फ़ॉन्ट, थीम, चित्र और अन्य संसाधनों की भी जाँच करें।

**जब मैं किसी लेआउट को संशोधित करता हूँ जो पहले से उपयोग में है, तो क्या होता है?**

निर्भर स्लाइड्स लेआउट परिवर्तन को विरासत में लेती हैं, जब तक कि उन्होंने स्थानीय रूप से स्वरूपण या वस्तुओं को अधिलेखित नहीं किया हो। प्लेसहोल्डर ज्यामिति और विरासत में प्राप्त शैली कई स्लाइड्स पर एक साथ बदल सकती है। संपादन से पहले प्रभावित स्लाइड्स की पहचान करने के लिए [GetDependingSlides](https://reference.aspose.com/slides/hi/net/aspose.slides/ilayoutslide/getdependingslides/) का उपयोग करें।

**यदि मैं अभी भी उपयोग में चल रहे लेआउट को हटाता हूँ तो क्या होगा?**

Aspose.Slides एक [PptxEditException](https://reference.aspose.com/slides/hi/net/aspose.slides/pptxeditexception/) फेंकेगा। पहले निर्भर स्लाइड्स को पुनः असाइन करें, या केवल अप्रयुक्त लेआउट हटाने के लिए [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) का उपयोग करें।