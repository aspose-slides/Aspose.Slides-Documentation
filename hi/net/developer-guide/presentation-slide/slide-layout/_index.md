---
title: ".NET में स्लाइड लेआउट लागू या बदलें"
linktitle: "स्लाइड लेआउट"
type: docs
weight: 60
url: /hi/net/slide-layout/
keywords:
- स्लाइड लेआउट
- कंटेंट लेआउट
- प्लेसहोल्डर
- प्रेजेंटेशन डिज़ाइन
- स्लाइड डिज़ाइन
- अनउपयोगित लेआउट
- फुटर दृश्यता
- शीर्षक स्लाइड
- शीर्षक और कंटेंट
- सेक्शन हेडर
- दो कंटेंट
- तुलना
- केवल शीर्षक
- खाली लेआउट
- कैप्शन के साथ कंटेंट
- कैप्शन के साथ चित्र
- शीर्षक और लंबवत पाठ
- लंबवत शीर्षक और पाठ
- PowerPoint
- OpenDocument
- प्रेजेंटेशन
- C#
- .NET
- Aspose.Slides
description: "Aspose.Slides for .NET में स्लाइड लेआउट लागू करें, बनाएँ और संशोधित करें, प्लेसहोल्डर जोड़ें, अनउपयोगित लेआउट हटाएँ, और फुटर दृश्यता नियंत्रित करें."
---
## **Overview**

एक स्लाइड लेआउट शीर्षक, पाठ, चित्र, चार्ट और तालिकाओं जैसे प्लेसहोल्डर्स की स्थितियों और स्वरूपण को परिभाषित करता है। लेआउट लागू करने से स्लाइड्स में एकसमान संरचना बनती है जबकि प्रत्येक स्लाइड अपना स्वयं का कंटेंट रख सकती है।

सबसे सामान्य लेआउट्स हैं:

- **Title Slide**: शीर्षक और उपशीर्षक प्लेसहोल्डर्स शामिल होते हैं।
- **Title and Content**: एक शीर्षक प्लेसहोल्डर और एक सामान्य प्रयोजन कंटेंट प्लेसहोल्डर शामिल होते हैं।
- **Blank**: कोई कंटेंट प्लेसहोल्डर नहीं होते और यह उपयोगी है जब सभी आकृतियों को मैन्युअल रूप से स्थित किया जाएगा।

## **Understand Layout Inheritance**

एक प्रेजेंटेशन में तीन संबंधित स्तर होते हैं:

1. एक [master slide](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslide/) थीम, साझा स्वरूपण, बैकग्राउंड और सामान्य ऑब्जेक्ट्स को परिभाषित करता है।
1. एक [layout slide](https://reference.aspose.com/slides/hi/net/aspose.slides/ilayoutslide/) मास्टर का हिस्सा होता है और प्लेसहोल्डर्स की विशिष्ट व्यवस्था को परिभाषित करता है।
1. एक [normal slide](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/) एक लेआउट का उपयोग करती है और उस स्लाइड के लिए दर्ज किया गया कंटेंट संग्रहीत करती है।

एक normal slide अपने लेआउट से थीम और स्वरूपण विरासत में लेती है, और लेआउट अपने मास्टर से विरासत में लेता है। normal slide पर सीधे सेट किया गया मान उस स्तर पर विरासत में प्राप्त मान को ओवरराइड कर देता है। जब एक normal slide बनाई जाती है, उसके प्लेसहोल्डर आकृतियाँ चयनित लेआउट से उत्पन्न होती हैं, जबकि उन प्लेसहोल्डर्स में दर्ज किया गया कंटेंट normal slide से संबंधित होता है।

लेआउट से स्लाइड्स बनाने से पहले आवश्यक प्लेसहोल्डर्स जोड़ें। बाद में लेआउट में कोई नया प्लेसहोल्डर जोड़ने से मौजूदा normal स्लाइड्स में स्वचालित रूप से संबंधित प्लेसहोल्डर आकृति नहीं बनती।

यह संबंध दो महत्वपूर्ण परिणाम देता है:

- लेआउट पर विरासत में मिला स्वरूपण या मौजूदा प्लेसहोल्डर ज्योमेट्री बदलने से हर उस स्लाइड को अपडेट किया जा सकता है जो उस पर निर्भर है। पहले उपयोग में मौजूद लेआउट को संपादित करने से पहले उसके निर्भर स्लाइड्स की जाँच करें और परिणामी प्रेजेंटेशन की समीक्षा करें।
- वह लेआउट जिसे अभी भी कोई स्लाइड उपयोग कर रही है, उसे हटाया नहीं जा सकता। पहले उसके निर्भर स्लाइड्स को किसी अन्य लेआउट पर पुनः असाइन करें, या केवल अनउपयोगित लेआउट्स को हटाएँ।

इस पदानुक्रम के शीर्ष स्तर के बारे में अधिक जानकारी के लिए देखें [Slide Master](/slides/hi/net/slide-master/)।

## **Select and Apply a Slide Layout**

जब प्रेजेंटेशन मानक PowerPoint लेआउट परिभाषाओं का पालन करता है, तब लेआउट प्रकार का उपयोग करें। लेआउट नाम उपयोगकर्ता-सम्पादन योग्य होते हैं और स्थानीयकृत किए जा सकते हैं, इसलिए स्रोत टेम्प्लेट को नियंत्रित न करने पर नाम-आधारित चयन कम भरोसेमंद होता है।

निम्न उदाहरण पहले मास्टर पर **Title and Content** की खोज करता है। यदि वह लेआउट उपलब्ध नहीं है, तो यह जानबूझकर **Blank** पर वापस जाता है। दूसरा null जाँच आवश्यक है क्योंकि प्रेजेंटेशन में केवल कस्टम लेआउट्स हो सकते हैं। चयनित लेआउट फिर पहले normal स्लाइड पर [ISlide.LayoutSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/layoutslide/) प्रॉपर्टी के माध्यम से लागू किया जाता है।

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

एक स्लाइड का लेआउट बदलने से सीधे स्लाइड में जोड़े गए सामान्य आकृतियों को हटाया नहीं जाता। हालांकि, प्लेसहोल्डर स्थितियाँ, विरासत में मिला स्वरूपण, और मौजूदा प्लेसहोल्डर्स तथा नए लेआउट के बीच का मेल बदल सकता है, इसलिए बड़े अंतर वाले लेआउट्स के बीच स्विच करते समय आउटपुट की जाँच करें।

## **Add a Layout Slide**

निर्वाचक और निर्माण अलग-अलग कार्य हैं। पिछले उदाहरण में एक मौजूदा लेआउट का चयन किया गया; यह कोई नया लेआउट नहीं बनाता। लेआउट बनाने के लिए लक्ष्य मास्टर के लेआउट संग्रह पर [IMasterLayoutSlideCollection.Add](https://reference.aspose.com/slides/hi/net/aspose.slides/masterlayoutslidecollection/add/) मेथड कॉल करें।

निम्न उदाहरण हमेशा एक नया **Title and Content** लेआउट `Report Title and Content` नाम से जोड़ता है, फिर उस पर आधारित एक normal स्लाइड जोड़ता है। लेआउट नाम संग्रह के भीतर अद्वितीय होना चाहिए।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("input.pptx");

var masterSlide = presentation.Masters[0];
var reportLayout = masterSlide.LayoutSlides.Add(SlideLayoutType.TitleAndObject, "Report Title and Content");
presentation.Slides.AddEmptySlide(reportLayout);

presentation.Save("output-with-report-layout.pptx", SaveFormat.Pptx);
```

केवल तब लेआउट जोड़ें जब टेम्प्लेट को वास्तव में एक अतिरिक्त पुन: उपयोग योग्य संरचना की आवश्यकता हो। यदि उपयुक्त लेआउट पहले से मौजूद है, तो उसे चुनें और पुन: उपयोग करें, न कि डुप्लिकेट बनाएँ।

## **Add Placeholders to a Layout Slide**

[ILayoutSlide.PlaceholderManager](https://reference.aspose.com/slides/hi/net/aspose.slides/ilayoutslide/placeholdermanager/) प्रॉपर्टी लेआउट में प्लेसहोल्डर आकृतियों को जोड़ने के लिए एक [ILayoutPlaceholderManager](https://reference.aspose.com/slides/hi/net/aspose.slides/ilayoutplaceholdermanager/) प्रदान करती है।

| PowerPoint प्लेसहोल्डर | ILayoutPlaceholderManager विधि |
| ----------------------- | ------------------------------ |
| ![सामग्री](content.png) | [`AddContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/net/aspose.slides/layoutplaceholdermanager/addcontentplaceholder/) |
| ![सामग्री (लंबवत)](contentV.png) | [`AddVerticalContentPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/net/aspose.slides/layoutplaceholdermanager/addverticalcontentplaceholder/) |
| ![पाठ](text.png) | [`AddTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/net/aspose.slides/layoutplaceholdermanager/addtextplaceholder/) |
| ![पाठ (लंबवत)](textV.png) | [`AddVerticalTextPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/net/aspose.slides/layoutplaceholdermanager/addverticaltextplaceholder/) |
| ![चित्र](picture.png) | [`AddPicturePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/net/aspose.slides/layoutplaceholdermanager/addpictureplaceholder/) |
| ![चार्ट](chart.png) | [`AddChartPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/net/aspose.slides/layoutplaceholdermanager/addchartplaceholder/) |
| ![तालिका](table.png) | [`AddTablePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/net/aspose.slides/layoutplaceholdermanager/addtableplaceholder/) |
| ![स्मार्टआर्ट](smartart.png) | [`AddSmartArtPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/net/aspose.slides/layoutplaceholdermanager/addsmartartplaceholder/) |
| ![मीडिया](media.png) | [`AddMediaPlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/net/aspose.slides/layoutplaceholdermanager/addmediaplaceholder/) |
| ![ऑनलाइन छवि](onlineImage.png) | [`AddOnlineImagePlaceholder(float x, float y, float width, float height)`](https://reference.aspose.com/slides/hi/net/aspose.slides/layoutplaceholdermanager/addonlineimageplaceholder/) |

निम्न उदाहरण यह सत्यापित करता है कि **Blank** लेआउट मौजूद है, उसमें चार प्लेसहोल्डर जोड़ता है, और फिर संशोधित लेआउट का उपयोग करने वाली एक normal स्लाइड बनाता है। क्रम जानबूझकर रखा गया है: प्लेसहोल्डर पहले जोड़े जाते हैं, फिर normal स्लाइड बनाई जाती है, ताकि Aspose.Slides उस स्लाइड पर संबंधित प्लेसहोल्डर आकृतियाँ उत्पन्न कर सके।

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

![The placeholders on the layout slide](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
विरासत में मिले स्वरूपण या मौजूदा लेआउट प्लेसहोल्डर्स की ज्योमेट्री बदलने से निर्भर स्लाइड्स पर प्रभाव पड़ सकता है। नया जोड़ा गया लेआउट प्लेसहोल्डर मौजूदा normal स्लाइड्स में स्वचालित रूप से नहीं भरता। लेआउट परिवर्तन को प्रेजेंटेशन की एक कॉपी पर परीक्षण करें और प्रत्येक निर्भर स्लाइड की जाँच करें।
{{% /alert %}}

## **Remove Unused Layout Slides**

लेआउट्स जिन्हें कोई normal स्लाइड संदर्भित नहीं करती, उन्हें हटाने के लिए [Compress.RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) मेथड का उपयोग करें। यह मेथड उन लेआउट्स को छोड़ देता है जो अभी भी उपयोग में हैं।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.LowCode;

using var presentation = new Presentation("input.pptx");

Compress.RemoveUnusedLayoutSlides(presentation);
presentation.Save("output-without-unused-layouts.pptx", SaveFormat.Pptx);
```

किसी विशेष लेआउट को हटाने के लिए, पहले उसकी [HasDependingSlides](https://reference.aspose.com/slides/hi/net/aspose.slides/ilayoutslide/hasdependingslides/) प्रॉपर्टी या [GetDependingSlides](https://reference.aspose.com/slides/hi/net/aspose.slides/ilayoutslide/getdependingslides/) मेथड का उपयोग करें। [ILayoutSlide.Remove](https://reference.aspose.com/slides/hi/net/aspose.slides/ilayoutslide/remove/) कॉल करने से पहले किसी भी निर्भर स्लाइड को पुनः असाइन करें। उपयोग में रहे लेआउट को हटाने का प्रयास करने पर [PptxEditException](https://reference.aspose.com/slides/hi/net/aspose.slides/pptxeditexception/) उत्पन्न होता है।

## **Control Footer Visibility on a Layout Slide**

एक लेआउट का अपना फुटर, स्लाइड‑नंबर और डेट‑टाइम प्लेसहोल्डर होता है। किसी एक लेआउट के लिए उन प्लेसहोल्डर्स को नियंत्रित करने के लिए [ILayoutSlide.HeaderFooterManager](https://reference.aspose.com/slides/hi/net/aspose.slides/ilayoutslide/headerfootermanager/) प्रॉपर्टी का उपयोग करें। यह तब उपयोगी होता है जब उदाहरण के लिए कंटेंट लेआउट्स फुटर दिखाएँ, लेकिन शीर्षक लेआउट्स नहीं दिखाएँ।

निम्न उदाहरण एक लेआउट को सुरक्षित रूप से चुनता है और उसके फुटर तत्वों को दिखाई देने योग्य बनाता है:

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

## **Control Footer Visibility on a Master and Its Child Layouts**

मास्टर पदानुक्रम में सुसंगत फुटर सेटिंग्स लागू करने के लिए, [IMasterSlide.HeaderFooterManager](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslide/headerfootermanager/) प्रॉपर्टी का उपयोग करें। [IMasterSlideHeaderFooterManager](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslideheaderfootermanager/) की प्रोपेगेशन मेथड्स मास्टर और उसके निर्भर लेआउट स्लाइड्स तथा normal स्लाइड्स पर काम करती हैं; वे केवल एक normal स्लाइड को लक्षित नहीं करतीं।

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

**एक Master Slide और Layout Slide में क्या अंतर है?**

एक master slide प्रेजेंटेशन की थीम और साझा स्वरूपण को परिभाषित करता है। एक layout slide master का हिस्सा होता है और प्लेसहोल्डर्स की एक पुन: उपयोग योग्य व्यवस्था को परिभाषित करता है। normal स्लाइड्स उन लेआउट्स को उपयोग करती हैं और स्लाइड‑विशिष्ट कंटेंट संग्रहीत करती हैं।

**क्या मैं एक Layout Slide को एक प्रेजेंटेशन से दूसरे प्रेजेंटेशन में कॉपी कर सकता हूँ?**

हां। दूरी के संग्रह में एक कॉपी जोड़ने के लिए [AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/globallayoutslidecollection/addclone/) मेथड का प्रयोग करें। प्रेजेंटेशन्स के बीच कॉपी करते समय स्रोत लेआउट द्वारा उपयोग किए गए फ़ॉन्ट, थीम, चित्र और अन्य संसाधनों की भी जाँच करें।

**यदि मैं किसी लेआउट को संशोधित करता हूँ जो पहले से उपयोग में है, तो क्या होता है?**

निर्भर स्लाइड्स लेआउट परिवर्तन को विरासत में लेती हैं जब तक वे स्थानीय रूप से प्रभावित स्वरूपण या ऑब्जेक्ट्स को ओवरराइड न करें। प्लेसहोल्डर ज्योमेट्री और विरासत में मिली स्टाइलिंग कई स्लाइड्स पर एक साथ बदल सकती है। संपादन से पहले प्रभावित स्लाइड्स की पहचान के लिए [GetDependingSlides](https://reference.aspose.com/slides/hi/net/aspose.slides/ilayoutslide/getdependingslides/) उपयोग करें।

**यदि मैं एक लेआउट को हटाता हूँ जो अभी भी उपयोग में है, तो क्या होता है?**

Aspose.Slides एक [PptxEditException](https://reference.aspose.com/slides/hi/net/aspose.slides/pptxeditexception/) उत्पन्न करता है। पहले निर्भर स्लाइड्स को पुनः असाइन करें, या केवल अनउपयोगित लेआउट्स को हटाने के लिए [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/compress/removeunusedlayoutslides/) का उपयोग करें।