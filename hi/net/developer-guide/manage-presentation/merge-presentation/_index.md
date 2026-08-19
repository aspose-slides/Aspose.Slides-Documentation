---
title: .NET में प्रस्तुतियों को कुशलतापूर्वक मिलाएं
linktitle: प्रस्तुतियों को मिलाएं
type: docs
weight: 40
url: /hi/net/merge-presentation/
keywords:
- PowerPoint को मिलाएं
- प्रस्तुतियों को मिलाएं
- स्लाइड्स को मिलाएं
- PPT को मिलाएं
- PPTX को मिलाएं
- ODP को मिलाएं
- PowerPoint को संयोजित करें
- प्रस्तुतियों को संयोजित करें
- स्लाइड्स को संयोजित करें
- PPT को संयोजित करें
- PPTX को संयोजित करें
- ODP को संयोजित करें
- .NET
- C#
- Aspose.Slides
description: ".NET में स्लाइड्स को क्लोन करके, मास्टर और लेआउट को नियंत्रित करके, स्लाइड सामग्री का आकार बदलकर, सेक्शन को संरक्षित करके, तथा संरक्षित या बड़े फ़ाइलों को संभालते हुए PowerPoint और OpenDocument प्रस्तुतियों को कैसे मिलाएं सीखें।"
---
## **Overview**

Aspose.Slides for .NET एक प्रस्तुति से [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) की स्लाइड्स को दूसरे में क्लोन करके प्रस्तुतियों को मिलाता है। मुख्य ऑपरेशन है [ISlideCollection.AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/addclone/), जो स्रोत स्लाइड के फॉर्मेटिंग को बनाए रख सकता है या क्लोन की गई स्लाइड को लक्ष्य प्रस्तुति के मास्टर या लेआउट से जोड़ सकता है।

यह लेख सबसे सामान्य मर्जिंग वर्कफ़्लो को कवर करता है:

- सभी स्लाइड्स को उनके स्रोत फॉर्मेटिंग को बनाए रखते हुए मर्ज करें;
- चयनित स्लाइड्स को मर्ज करें;
- लक्ष्य प्रस्तुति से एक मास्टर लागू करें;
- लक्ष्य प्रस्तुति से एक विशिष्ट लेआउट लागू करें;
- मर्ज करने से पहले विभिन्न स्लाइड आकारों को सामान्यीकृत करें;
- क्लोन की गई स्लाइड्स को एक सेक्शन में जोड़ें;
- कई प्रस्तुतियों को एक एंड‑टू‑एंड वर्कफ़्लो में मर्ज करें;
- मास्टर, रिसोर्सेज, नोट्स, कमेंट्स, मीडिया, फोंट, पासवर्ड, बड़े फ़ाइलें, और मल्टीथ्रेडिंग संबंधी चिंताओं को संभालें।

## **How Slide Cloning Affects Masters and Layouts**

एक स्लाइड अपनी उपस्थिति का अधिकांश हिस्सा अपने लेआउट और मास्टर से विरासत में लेती है। इसी कारण, आप जो क्लोनिंग ओवरलोड चुनते हैं, वह निर्धारित करता है कि मर्ज की गई स्लाइड लक्ष्य प्रस्तुति में कैसे एकीकृत होगी।

[ISlideCollection.AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/addclone/) को इन तरीकों में से किसी एक से उपयोग करें:

- `AddClone(sourceSlide)` — स्रोत स्लाइड के लेआउट और फॉर्मेटिंग को बनाए रखें। आवश्यकता पड़ने पर स्रोत मास्टर को स्वचालित रूप से लक्ष्य प्रस्तुति में क्लोन किया जा सकता है। Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर को ट्रैक करता है ताकि समान स्रोत मास्टर वाले दोहराई गई स्लाइड्स बार‑बार क्लोन न हों।
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — क्लोन की गई स्लाइड को एक विशिष्ट लक्ष्य [IMasterSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslide/) से जोड़ें। Aspose.Slides उस मास्टर के तहत लेआउट प्रकार या नाम के आधार पर मिलते‑जुलते लेआउट की खोज करता है।
- `AddClone(sourceSlide, destinationLayout)` — क्लोन की गई स्लाइड को सीधे एक विशिष्ट लक्ष्य [ILayoutSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/ilayoutslide/) से जोड़ें।

`AddClone` ओवरलोड को दिया गया मास्टर या लेआउट **लक्ष्य** प्रस्तुति से होना चाहिए, स्रोत प्रस्तुति से नहीं।

## **Merge Entire Presentations and Preserve Source Formatting**

सबसे सरल मर्ज स्रोत प्रस्तुति से सभी स्लाइड्स को लक्ष्य प्रस्तुति में कॉपी करता है। यह विकल्प तब उपयुक्त है जब आयात की गई स्लाइड्स को अपना मूल थीम, मास्टर और लेआउट संबंध बनाए रखने चाहिए।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged.pptx", SaveFormat.Pptx);
```

यदि स्रोत और लक्ष्य विभिन्न डिज़ाइन उपयोग कर रहे हैं तो परिणामस्वरूप प्रस्तुति में कई मास्टर हो सकते हैं। यह अपेक्षित है जब स्रोत फॉर्मेटिंग को जानबूझकर संरक्षित किया जाता है।

## **Merge Selected Slides**

आपको हर स्लाइड को क्लोन करने की आवश्यकता नहीं है। निम्न उदाहरण केवल चयनित स्लाइड इंडेक्सों को स्रोत प्रस्तुति से आयात करता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var slideIndexes = new[] { 0, 2, 4 };

foreach (var index in slideIndexes)
{
    destination.Slides.AddClone(source.Slides[index]);
}

destination.Save("merged-selected-slides.pptx", SaveFormat.Pptx);
```

उपयोगकर्ता इनपुट या बाहरी कॉन्फ़िगरेशन से आने वाले स्लाइड इंडेक्स को क्लोन करने से पहले वैधता जांचें।

## **Merge Slides Using a Destination Master**

जब आयात की गई स्लाइड्स को लक्ष्य प्रस्तुति के मौज़ूद मास्टर के तहत होना चाहिए, तब [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/addclone/) ओवरलोड का उपयोग करें।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationMaster = destination.Masters[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationMaster, allowCloneMissingLayout: true);
}

destination.Save("merged-with-destination-master.pptx", SaveFormat.Pptx);
```

Aspose.Slides निर्दिष्ट मास्टर के तहत स्रोत लेआउट के प्रकार या नाम से मिलते‑जुलते लेआउट को चुनता है। यदि उपयुक्त लेआउट मौजूद नहीं है और `allowCloneMissingLayout` `true` है, तो स्रोत लेआउट को क्लोन किया जाता है ताकि स्लाइड जोड़ी जा सके। यदि यह `false` है, तो एक [PptxEditException](https://reference.aspose.com/slides/hi/net/aspose.slides/pptxeditexception/) उत्पन्न होता है।

जब आप मर्ज को असफल करना चाहते हैं और लक्ष्य मास्टर में अतिरिक्त लेआउट न जोड़ना चाहते हैं, तो `false` का प्रयोग करें।

## **Merge Slides Using a Specific Destination Layout**

जब आप ठीक-ठीक जानते हैं कि आयात की गई स्लाइड्स को कौन सा लक्ष्य लेआउट उपयोग करना चाहिए, तब [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/addclone/) ओवरलोड का उपयोग करें।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var destinationLayout = destination.LayoutSlides[0];

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, destinationLayout);
}

destination.Save("merged-with-destination-layout.pptx", SaveFormat.Pptx);
```

एक लक्ष्य लेआउट लागू करने से विरासत में मिली लेआउट संबंध बदल जाता है; यह स्रोत स्लाइड की सामग्री को पुनः डिज़ाइन नहीं करता। यदि स्रोत और लक्ष्य लेआउट की प्लेसहोल्डर संरचना भिन्न है, तो परिणाम को निरीक्षण करें ताकि विरासत में मिला फॉर्मेटिंग और प्लेसहोल्डर व्यवहार उपयुक्त हो।

## **Merge Presentations with Different Slide Sizes**

विभिन्न स्लाइड आयामों वाली प्रस्तुतियों को मर्ज किया जा सकता है, लेकिन एक स्लाइड को दूसरे आकार वाली प्रस्तुति में क्लोन करने से उसकी सामग्री नई कैनवास के अनुरूप स्वतः पुनः डिज़ाइन नहीं होती। परिणामस्वरूप शेप्स शिफ्ट, स्केल या स्लाइड के दृश्य क्षेत्र से बाहर हो सकते हैं।

एक व्यावहारिक तरीका है कि क्लोन करने से पहले स्रोत प्रस्तुति का आकार बदल दें। [SlideSize.SetSize](https://reference.aspose.com/slides/hi/net/aspose.slides/slidesize/setsize/) मेथड मौजूदा सामग्री को स्केल करते हुए स्लाइड आयाम बदल सकता है। [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/hi/net/aspose.slides/slidesizescaletype/) सामग्री को अनुरोधित आकार में फिट करने के लिए स्केल करता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

if (source.SlideSize.Size.Width != destination.SlideSize.Size.Width || 
    source.SlideSize.Size.Height != destination.SlideSize.Size.Height)
{
    source.SlideSize.SetSize(
        destination.SlideSize.Size.Width, 
        destination.SlideSize.Size.Height, 
        SlideSizeScaleType.EnsureFit);
}

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide);
}

destination.Save("merged-same-slide-size.pptx", SaveFormat.Pptx);
```

आकार बदलने से स्रोत प्रस्तुति ऑब्जेक्ट मेमोरी में परिवर्तन करता है। यदि आप मूल स्रोत प्रस्तुति को अन्य ऑपरेशन्स के लिए अपरिवर्तित रखना चाहते हैं, तो मर्ज के लिए एक अलग इंस्टेंस खोलें।

## **Merge Slides into a Presentation Section**

बेसिक स्लाइड‑क्लोनिंग लूप स्रोत प्रस्तुति की सेक्शन पदानुक्रम को पुनर्सृजित नहीं करता। यदि आउटपुट में सेक्शन महत्वपूर्ण हैं, तो लक्ष्य प्रस्तुति में सेक्शन बनाएं या चुनें और स्लाइड्स को स्पष्ट रूप से [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/addclone/) के साथ क्लोन करें।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var destination = new Presentation("destination.pptx");
using var source = new Presentation("source.pptx");

var importedSection = destination.Sections.AppendEmptySection("Imported slides");

foreach (var slide in source.Slides)
{
    destination.Slides.AddClone(slide, importedSection);
}

destination.Save("merged-with-section.pptx", SaveFormat.Pptx);
```

क्लोन की गई स्लाइड्स निर्दिष्ट लक्ष्य सेक्शन में जोड़ दी जाती हैं। कई स्रोत सेक्शन को संरक्षित करने के लिए, लक्ष्य में वही सेक्शन बनाएं और प्रत्येक स्रोत स्लाइड को संबंधित लक्ष्य सेक्शन से मैप करें।

## **Merge Multiple Presentations Safely**

निम्न एंड‑टू‑एंड उदाहरण पहले प्रस्तुति को लक्ष्य के रूप में लेता है, प्रत्येक अतिरिक्त स्रोत का स्लाइड आकार सामान्यीकृत करता है, प्रत्येक स्रोत को केवल तब खुला रखता है जब वह कॉपी हो रहा हो, और अंत में फ़ाइल को सहेजता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var inputFiles = new[] { "part1.pptx", "part2.pptx", "part3.pptx" };

using var merged = new Presentation(inputFiles[0]);

for (var fileIndex = 1; fileIndex < inputFiles.Length; fileIndex++)
{
    using var source = new Presentation(inputFiles[fileIndex]);

    if (source.SlideSize.Size.Width != merged.SlideSize.Size.Width || 
        source.SlideSize.Size.Height != merged.SlideSize.Size.Height)
    {
        source.SlideSize.SetSize(
            merged.SlideSize.Size.Width, 
            merged.SlideSize.Size.Height, 
            SlideSizeScaleType.EnsureFit);
    }

    foreach (var slide in source.Slides)
    {
        merged.Slides.AddClone(slide);
    }
}

merged.Save("merged.pptx", SaveFormat.Pptx);
```

यह आयातित स्लाइड्स के स्रोत फॉर्मेटिंग को संरक्षित करने के लिए एक उपयोगी बेसलाइन है। यदि आपका आउटपुट एकल लक्ष्य थीम का उपयोग करना चाहिए, तो सरल `AddClone(slide)` कॉल को पहले दिखाए गए उपयुक्त destination‑master या destination‑layout ओवरलोड से बदलें।

## **Practical Considerations**

### **Masters, Layouts, and Formatting Fidelity**

डिफ़ॉल्ट स्लाइड क्लोनिंग आवश्यक स्रोत मास्टर को लक्ष्य प्रस्तुति में स्वचालित रूप से ला सकता है। Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर को ट्रैक करने के लिए एक आंतरिक रजिस्ट्री रखता है ताकि समान मास्टर बार‑बार क्लोन न हो। मैन्युअली क्लोन किए गए मास्टर इस रजिस्ट्री में नहीं होते, इसलिए जब तक आपको मास्टर संरचना पर स्पष्ट नियंत्रण न चाहिए तब तक पहले से क्लोन किए गए मास्टर से बचें।

समझें कि दो मास्टर या लेआउट जिनके नाम समान हैं, आवश्यक रूप से दृश्य रूप में समान नहीं होते। यदि कोई कॉरपोरेट टेम्प्लेट अंतिम रूप को नियंत्रित करता है, तो लक्ष्य मास्टर या लेआउट को स्पष्ट रूप से चुनें और मर्ज के बाद परिणाम की पुष्टि करें।

### **Notes and Comments**

स्पीकर नोट्स और स्लाइड कमेंट्स स्लाइड सामग्री से जुड़े होते हैं और स्लाइड क्लोन होने पर कॉपी होते हैं। Aspose.Slides [presentation notes](https://docs.aspose.com/slides/hi/net/presentation-notes/) और [presentation comments](https://docs.aspose.com/slides/hi/net/presentation-comments/) के लिए समर्पित API भी प्रदान करता है।

यदि नोट‑पेज फॉर्मेटिंग महत्वपूर्ण है, तो मर्ज की गई प्रस्तुति की जाँच करें क्योंकि नोट मास्टर प्रस्तुति‑स्तर के ऑब्जेक्ट होते हैं और स्रोत फ़ाइलों के बीच भिन्न हो सकते हैं। समीक्षात्मक वर्कफ़्लो में, विभिन्न लेखकों या टेम्प्लेट्स से फ़ाइलें मिलाने के बाद कमेंट लेखकों और थ्रेडेड कमेंट्स की भी जाँच करें।

### **Images, Audio, Video, OLE Objects, and External Links**

स्लाइड्स प्रस्तुति‑स्तर के रिसोर्सेज जैसे इमेज, एम्बेडेड ऑडियो, एम्बेडेड वीडियो, और OLE डेटा को संदर्भित कर सकती हैं। केवल दृश्यमान शेप्स को कॉपी करने के बजाय स्लाइड को स्वयं क्लोन करें ताकि Aspose.Slides उसके रिसोर्सेज के संबंध बनाए रख सके।

एम्बेडेड और लिंक्ड रिसोर्सेज को अलग‑अलग संभालें। एक लिंक्ड ऑडियो, वीडियो, OLE ऑब्जेक्ट, या हाइपरलिंक बाहरी लक्ष्य पर निर्भर रहता है; स्लाइड क्लोन करने से बाहरी लिंक एम्बेडेड सामग्री में नहीं बदलता। मर्ज किए गए प्रस्तुति को खोलने वाले वातावरण में लिंक्ड‑रिसोर्स पाथ और URL की जाँच करें।

Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर को ट्रैक करता है, लेकिन इसका अर्थ यह नहीं है कि असंबंधित स्रोत प्रस्तुतियों की समान बाइनरी रिसोर्सेज हमेशा डिडुप्लिकेट हो जाएँगी। यदि आउटपुट फ़ाइल आकार महत्वपूर्ण है, तो मर्ज पैकेज का निरीक्षण करें और परिणाम को मापें, न कि केवल अप्रत्यक्ष डिडुप्लिकेशन पर भरोसा करें।

### **Embedded Fonts and Font Availability**

फ़ॉन्ट्स प्रस्तुति‑स्तर पर प्रबंधित होते हैं। यदि टाइपोग्राफी को विभिन्न मशीनों पर समान रखना आवश्यक है, तो केवल स्लाइड क्लोनिंग यह गारंटी नहीं देती कि सभी आवश्यक फ़ॉन्ट लक्ष्य वातावरण में उपलब्ध हों। आप [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsmanager/getembeddedfonts/) से एम्बेडेड फ़ॉन्ट्स की जाँच कर सकते हैं और [Embed Fonts in Presentations](https://docs.aspose.com/slides/hi/net/embedded-font/) में वर्णित रूप से एम्बेडिंग को स्पष्ट रूप से प्रबंधित कर सकते हैं।

यह भी पुष्टि करें कि आप स्रोत फ़ाइलों में उपयोग किए गए फ़ॉन्ट्स को एम्बेड करने के लिए अनुमति रखते हैं। फ़ॉन्ट लाइसेंस एम्बेडिंग को प्रतिबंधित कर सकते हैं।

### **Password-Protected Presentations**

एक पासवर्ड‑सुरक्षित स्रोत को उसके स्लाइड्स को क्लोन करने से पहले सफलतापूर्वक खोलना आवश्यक है। पासवर्ड को [LoadOptions.Password](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/password/) के माध्यम से प्रदान करें।

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

एक एन्क्रिप्टेड स्रोत को खोलना लक्ष्य प्रस्तुति पर स्वतः वही सुरक्षा लागू नहीं करता। आवश्यकता पड़ने पर आउटपुट प्रोटेक्शन को अलग से कॉन्फ़िगर करें।

### **Large Presentations and Memory Use**

उच्च‑रेज़ोल्यूशन इमेज, ऑडियो, वीडियो या अन्य बड़े बाइनरी ऑब्जेक्ट्स वाली बड़ी प्रस्तुतियों में काफी मेमोरी उपयोग हो सकता है। [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/blobmanagementoptions/) BLOB हैंडलिंग और टेम्पररी‑फ़ाइल उपयोग के नियंत्रण प्रदान करता है। बड़े‑फ़ाइल रणनीतियों के लिए देखें [Manage Presentation BLOBs](https://docs.aspose.com/slides/hi/net/manage-blob/)।

बड़ी फ़ाइलों के लिए संभव हो तो फ़ाइल पाथ से लोड करें, प्रत्येक स्रोत प्रस्तुति को मर्ज होने के तुरंत बाद डिस्पोज़ करें, और मध्यवर्ती परिणाम को बार‑बार सहेजने से बचें जब तक वर्कफ़्लो में चेक‑पॉइंट की आवश्यकता न हो।

### **Thread Safety**

एक ही [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) इंस्टेंस को कई थ्रेड्स से एक साथ लोड, मॉडिफ़ाइ, सहेज या क्लोन न करें। प्रत्येक प्रस्तुति इंस्टेंस को एक मर्ज ऑपरेशन तक सीमित रखें। यदि आप स्वतंत्र जॉब्स को समानांतर चलाते हैं, तो स्वतंत्र प्रस्तुति इंस्टेंस उपयोग करें और [Aspose.Slides multithreading guidance](https://docs.aspose.com/slides/hi/net/multithreading/) का पालन करें।

## **FAQ**

**How do I keep each source presentation's original design?**

आयात की गई स्लाइड्स को मूल डिज़ाइन बनाए रखने के लिए `[AddClone(sourceSlide)](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/addclone/)` का उपयोग करें और लक्ष्य मास्टर या लेआउट न दें। आवश्यक होने पर Aspose.Slides स्वचालित रूप से स्रोत मास्टर को क्लोन करेगा।

**How do I make imported slides use the destination theme?**

ऐसे ओवरलोड का उपयोग करें जो लक्ष्य मास्टर स्वीकार करता है। लक्ष्य प्रस्तुति से एक मास्टर पास करें, स्रोत से नहीं। Aspose.Slides प्रत्येक स्रोत स्लाइड को उस मास्टर के उचित लेआउट से मैप करने का प्रयास करेगा।

**When should I use a specific destination layout instead of a destination master?**

जब प्रत्येक आयातित स्लाइड को एक ज्ञात लेआउट का उपयोग करना हो, तो विशिष्ट लेआउट का उपयोग करें। जब आप चाहते हैं कि Aspose.Slides स्रोत लेआउट प्रकार या नाम के आधार पर उस मास्टर के कई लेआउट में से चयन करे, तो मास्टर का उपयोग करें।

**Can presentations with different slide sizes be merged?**

हां, लेकिन स्लाइड सामग्री स्वचालित रूप से लक्ष्य आयामों के अनुसार पुनः डिज़ाइन नहीं होती। पूर्वानुमेय प्लेसमेंट के लिए पहले स्रोत प्रस्तुति का आकार बदलें, उदाहरण के लिए [SlideSize.SetSize](https://reference.aspose.com/slides/hi/net/aspose.slides/slidesize/setsize/) और [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/hi/net/aspose.slides/slidesizescaletype/) का उपयोग करके।

**Can I merge PPT, PPTX, and ODP presentations into one file?**

हां। प्रत्येक स्रोत प्रस्तुति को लोड करें, आवश्यक स्लाइड्स को एक लक्ष्य में क्लोन करें, और लक्ष्य को समर्थित आउटपुट फ़ॉर्मेट में सहेजें। चूंकि प्रस्तुति फ़ॉर्मेट समान फीचर सेट नहीं रखते, क्रॉस‑फ़ॉर्मेट मर्ज के बाद जटिल सामग्री की पुष्टि करें। देखें [Supported File Formats](https://docs.aspose.com/slides/hi/net/supported-file-formats/)।

**Are source sections preserved automatically?**

केवल स्लाइड क्लोन करने वाले बेसिक लूप से नहीं। लक्ष्य में आवश्यक सेक्शन पुनः बनाएं और सेक्शन संरचना को सुरक्षित रखने के लिए [AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/addclone/) के सेक्शन ओवरलोड का उपयोग करें।

**Are speaker notes and comments preserved?**

वे क्लोन की गई स्लाइड के साथ कॉपी होते हैं। जो वर्कफ़्लो नोट‑मास्टर शैली, कमेंट लेखकों या थ्रेडेड रिव्यू डेटा पर निर्भर करते हैं, उनके लिए मर्ज के परिणाम की पुष्टि करें क्योंकि ये परिदृश्य प्रस्तुति‑स्तर की संरचनाओं के साथ स्लाइड‑स्तर की सामग्री को भी शामिल करते हैं।

**What happens to audio, video, OLE objects, and hyperlinks?**

एम्बेडेड सामग्री क्लोन की गई स्लाइड के रिसोर्स रिलेशनशिप के हिस्से के रूप में ले जाई जाती है। एक्सटर्नल लिंक बाहरी ही रहते हैं, इसलिए मर्ज के बाद उनके टार्गेट फ़ाइल या URL उपलब्ध होने चाहिए।

**Are embedded fonts from every source guaranteed to be available in the merged presentation?**

फ़ॉन्ट डिप्लॉयमेंट के लिए केवल स्लाइड क्लोनिंग पर भरोसा न करें। लक्ष्य में एम्बेडेड फ़ॉन्ट्स की जाँच करें और टाइपोग्राफी महत्वपूर्ण होने पर फ़ॉन्ट एम्बेडिंग या बाहरी फ़ॉन्ट उपलब्धता को स्पष्ट रूप से प्रबंधित करें।

**How do I merge a password-protected file?**

सही [LoadOptions.Password](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/password/) के साथ इसे खोलें, फिर सामान्य रूप से उसकी स्लाइड्स को क्लोन करें। आउटपुट सुरक्षा को अलग से कॉन्फ़िगर करें।

**How should I handle very large presentations?**

जब बड़े बाइनरी ऑब्जेक्ट मेमोरी उपयोग को प्रमुख बनाते हैं, तो BLOB प्रबंधन का उपयोग करें, बहुत बड़ी फ़ाइलों के लिए फ़ाइल‑पाथ लोडिंग को प्राथमिकता दें, स्रोत प्रस्तुतियों को शीघ्र ही डिस्पोज़ करें, और अंतिम परिणाम केवल आवश्यक होने पर सहेजें।

**Can I merge slides from multiple threads?**

एक ही [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) इंस्टेंस को कई थ्रेड्स से एक साथ उपयोग न करें। प्रत्येक मर्ज ऑपरेशन को अपने स्वयं के प्रस्तुति इंस्टेंस पर अलग रखें।