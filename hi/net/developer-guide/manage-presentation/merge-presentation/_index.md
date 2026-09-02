---
title: .NET में प्रस्तुतियों को कुशलता से मर्ज करें
linktitle: प्रस्तुतियों को मर्ज करें
type: docs
weight: 40
url: /hi/net/merge-presentation/
keywords:
- PowerPoint को मर्ज करें
- प्रस्तुतियों को मर्ज करें
- स्लाइड्स को मर्ज करें
- PPT को मर्ज करें
- PPTX को मर्ज करें
- ODP को मर्ज करें
- PowerPoint को संयोजित करें
- प्रस्तुतियों को संयोजित करें
- स्लाइड्स को संयोजित करें
- PPT को संयोजित करें
- PPTX को संयोजित करें
- ODP को संयोजित करें
- .NET
- C#
- Aspose.Slides
description: ".NET में स्लाइड्स को क्लोन करके, मास्टर और लेआउट को नियंत्रित करके, स्लाइड सामग्री का आकार बदलकर, सेक्शन को संरक्षित करके, तथा संरक्षित या बड़ी फ़ाइलों को संभालते हुए PowerPoint और OpenDocument प्रस्तुतियों को मर्ज करना सीखें।"
---
## **अवलोकन**

Aspose.Slides for .NET एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) से दूसरी में स्लाइड्स को क्लोन करके प्रस्तुतियों को मिलाता है। मुख्य ऑपरेशन [ISlideCollection.AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/addclone/) है, जो स्रोत स्लाइड का फॉर्मेटिंग बरकरार रख सकता है या क्लोन की गई स्लाइड को लक्ष्य प्रस्तुति में किसी मास्टर या लेआउट से संलग्न कर सकता है।

यह लेख सबसे सामान्य मर्जिंग कार्य प्रवाहों को कवर करता है:

- सभी स्लाइड्स को उनके स्रोत फॉर्मेटिंग को बनाए रखते हुए मर्ज करें;
- चयनित स्लाइड्स को मर्ज करें;
- लक्ष्य प्रस्तुति से एक मास्टर लागू करें;
- लक्ष्य प्रस्तुति से एक विशिष्ट लेआउट लागू करें;
- मर्ज करने से पहले विभिन्न स्लाइड आकारों को सामान्य करें;
- क्लोन किए गए स्लाइड्स को एक सेक्शन में जोड़ें;
- कई प्रस्तुतियों को एक अंत‑से‑अंत कार्यप्रवाह में मर्ज करें;
- मास्टर्स, संसाधन, नोट्स, टिप्पणियाँ, मीडिया, फ़ॉन्ट्स, पासवर्ड, बड़े फ़ाइलें, और मल्टीथ्रेडिंग संबंधी मामलों को संभालें।

## **स्लाइड क्लोनिंग का मास्टर्स और लेआउट्स पर प्रभाव**

एक स्लाइड अपनी उपस्थिति का अधिकांश भाग अपने लेआउट और मास्टर से विरासत में प्राप्त करती है। इसलिए, आप जिस क्लोनिंग ओवरलोड को चुनते हैं, वह निर्धारित करता है कि मर्ज की गई स्लाइड लक्ष्य प्रस्तुति में कैसे एकीकृत होगी।

[ISlideCollection.AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/addclone/) को निम्नलिखित तरीकों में से एक से उपयोग करें:

- `AddClone(sourceSlide)` — स्रोत स्लाइड का लेआउट और फॉर्मेटिंग बरकरार रखें। जब आवश्यकता हो, स्रोत मास्टर को स्वचालित रूप से लक्ष्य प्रस्तुति में क्लोन किया जा सकता है। Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर्स को ट्रैक करता है ताकि समान स्रोत मास्टर वाले दोहराए गए स्लाइड्स की क्लोनिंग दोहरायी न जाए।
- `AddClone(sourceSlide, destinationMaster, allowCloneMissingLayout)` — क्लोन की गई स्लाइड को एक विशिष्ट लक्ष्य [IMasterSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslide/) से संलग्न करें। Aspose.Slides उस मास्टर के तहत लेआउट प्रकार या नाम द्वारा मिलते‑जुलते लेआउट की खोज करता है।
- `AddClone(sourceSlide, destinationLayout)` — क्लोन की गई स्लाइड को सीधे एक विशिष्ट लक्ष्य [ILayoutSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/ilayoutslide/) से संलग्न करें।

`AddClone` ओवरलोड को पास किया गया मास्टर या लेआउट **लक्ष्य** प्रस्तुति से संबंधित होना चाहिए, स्रोत प्रस्तुति से नहीं।

## **पूरी प्रस्तुतियों को मर्ज करें और स्रोत फॉर्मेटिंग बरकरार रखें**

सबसे सरल मर्ज स्रोत प्रस्तुति की प्रत्येक स्लाइड को लक्ष्य प्रस्तुति में कॉपी करता है। यह तब उपयुक्त विकल्प है जब आयातित स्लाइड्स को उनका मूल थीम, मास्टर, और लेआउट संबंध बनाए रखना चाहिए।

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

जब स्रोत और लक्ष्य विभिन्न डिज़ाइन उपयोग करते हैं तो परिणामस्वरूप प्रस्तुति में कई मास्टर हो सकते हैं। यह तब अपेक्षित है जब स्रोत फॉर्मेटिंग को जानबूझकर बरकरार रखा गया हो।

## **चयनित स्लाइड्स को मर्ज करें**

आपको हर स्लाइड को क्लोन करने की आवश्यकता नहीं है। निम्नलिखित उदाहरण स्रोत प्रस्तुति से केवल चयनित स्लाइड इंडेक्स को आयात करता है।

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

उपयोगकर्ता इनपुट या बाहरी कॉन्फ़िगरेशन से आने वाले स्लाइड इंडेक्स को क्लोन करने से पहले सत्यापित करें।

## **लक्ष्य मास्टर के साथ स्लाइड्स को मर्ज करें**

जब आयातित स्लाइड्स को पहले से लक्ष्य प्रस्तुति में मौजूद एक मास्टर का अनुसरण करना चाहिए, तो [AddClone(ISlide, IMasterSlide, Boolean)](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/addclone/) ओवरलोड का उपयोग करें।

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

Aspose.Slides स्रोत लेआउट के प्रकार या नाम के आधार पर निर्दिष्ट मास्टर के तहत एक उपयुक्त लेआउट चुनता है। यदि कोई उपयुक्त लेआउट नहीं मिलता और `allowCloneMissingLayout` `true` है, तो स्रोत लेआउट को क्लोन किया जाता है ताकि स्लाइड जोड़ी जा सके। यदि यह `false` है, तो एक [PptxEditException](https://reference.aspose.com/slides/hi/net/aspose.slides/pptxeditexception/) फेंका जाता है।

जब आप चाहते हैं कि मर्ज विफल हो और लक्ष्य मास्टर में अतिरिक्त लेआउट न जोड़े जाएँ, तो `false` उपयोग करें।

## **विशिष्ट लक्ष्य लेआउट के साथ स्लाइड्स को मर्ज करें**

जब आप ठीक‑ठीक जानते हैं कि आयातित स्लाइड्स को कौन सा लक्ष्य लेआउट उपयोग करना चाहिए, तो [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/addclone/) ओवरलोड का उपयोग करें।

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

लक्ष्य लेआउट को लागू करने से विरासत में मिला लेआउट संबंध बदलता है; यह स्रोत स्लाइड की सामग्री को पुनः डिज़ाइन नहीं करता। यदि स्रोत और लक्ष्य लेआउट की प्लेसहोल्डर संरचना अलग है, तो परिणाम की जांच करें कि विरासत में मिला फॉर्मेटिंग और प्लेसहोल्डर व्यवहार उपयुक्त हैं या नहीं।

## **विभिन्न स्लाइड आकारों वाली प्रस्तुतियों को मर्ज करें**

विभिन्न स्लाइड आयाम वाली प्रस्तुतियों को मर्ज किया जा सकता है, लेकिन किसी स्लाइड को दूसरे आकार वाली प्रस्तुति में क्लोन करने से उसकी सामग्री स्वचालित रूप से नई कैनवास के लिए पुनः डिज़ाइन नहीं होती। परिणामस्वरूप आकार बदलने, शिफ्ट होने, या दृश्य स्लाइड क्षेत्र के बाहर रहने की संभावना होती है।

व्यावहारिक तरीका यह है कि क्लोन करने से पहले स्रोत प्रस्तुति का आकार बदलें। [SlideSize.SetSize](https://reference.aspose.com/slides/hi/net/aspose.slides/slidesize/setsize/) मेथड मौजूदा सामग्री को स्केल करते हुए स्लाइड आयाम बदल सकता है। [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/hi/net/aspose.slides/slidesizescaletype/) सामग्री को अनुरोधित आकार में फिट करने के लिए स्केल करता है।

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

आकार बदलने से स्रोत प्रस्तुति ऑब्जेक्ट मेमोरी में बदला जाता है। यदि आपको अन्य ऑपरेशन्स के लिए मूल स्रोत प्रस्तुति अपरिवर्तित चाहिए, तो मर्ज के लिए एक अलग इंस्टेंस खोलें।

## **स्लाइड्स को प्रस्तुति सेक्शन में मर्ज करें**

बेसिक स्लाइड‑क्लोनिंग लूप स्रोत प्रस्तुति की सेक्शन पदानुक्रम को पुनः नहीं बनाता। यदि आउटपुट में सेक्शन महत्वपूर्ण हैं, तो लक्ष्य प्रस्तुति में सेक्शन बनाएं या चुनें और स्लाइड्स को स्पष्ट रूप से [AddClone(ISlide, ISection)](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/addclone/) के साथ क्लोन करें।

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

क्लोन की गई स्लाइड्स निर्दिष्ट लक्ष्य सेक्शन में जोड़ दी जाती हैं। कई स्रोत सेक्शन को बरकरार रखने के लिए, [Presentation.Sections](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/sections/) को इटरेट करें, प्रत्येक स्रोत सेक्शन की वर्तमान स्लाइड्स को [ISection.GetSlidesListOfSection](https://reference.aspose.com/slides/hi/net/aspose.slides/isection/getslideslistofsection/) से प्राप्त करें, लक्ष्य में सेक्शन पुनः बनाएं, और प्रत्येक प्राप्त स्लाइड को उसके संबंधित लक्ष्य सेक्शन में क्लोन करें। संपूर्ण सेक्शन‑इटरेशन उदाहरण के लिए [Manage Slide Sections](/slides/hi/net/slide-section/) देखें, जिसमें खाली सेक्शन और संरचनात्मक परिवर्तन भी शामिल हैं।

## **एकाधिक प्रस्तुतियों को सुरक्षित रूप से मर्ज करें**

निम्नलिखित अंत‑से‑अंत उदाहरण पहले प्रस्तुति को लक्ष्य के रूप में उपयोग करता है, प्रत्येक अतिरिक्त स्रोत का स्लाइड आकार सामान्य करता है, प्रत्येक स्रोत को केवल तब तक खुला रखता है जब वह कॉपी हो रहा हो, और अंत में फ़ाइल सहेजता है।

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

यह आयातित स्लाइड्स की स्रोत फॉर्मेटिंग को बरकरार रखने के लिए एक उपयोगी बेंचमार्क है। यदि आपके आउटपुट को एकल लक्ष्य थीम उपयोग करना है, तो सरल `AddClone(slide)` कॉल को पहले दर्शाए गए उपयुक्त लक्ष्य‑मास्टर या लक्ष्य‑लेआउट ओवरलोड से बदलें।

## **व्यावहारिक विचार**

### **मास्टर्स, लेआउट्स, और फॉर्मेटिंग फिडेलिटी**

डिफ़ॉल्ट स्लाइड क्लोनिंग आवश्यक स्रोत मास्टर को लक्ष्य प्रस्तुति में स्वचालित रूप से ला सकता है। Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर्स को दोहराए जाने से बचाने के लिए एक आंतरिक रजिस्ट्री रखता है। मैन्युअल रूप से क्लोन किए गए मास्टर्स इस रजिस्ट्री द्वारा ट्रैक नहीं होते, इसलिए जब तक आप मास्टर संरचना पर स्पष्ट नियंत्रण नहीं चाहते तब तक पूर्व‑क्लोनिंग से बचें।

यह न मानें कि दो मास्टर या लेआउट जिनके नाम समान हैं, दृश्यमान रूप से समान हैं। यदि कॉरपोरेट टेम्प्लेट को अंतिम रूप से नियंत्रित करना है, तो स्पष्ट रूप से लक्ष्य मास्टर या लेआउट चुनें और मर्ज के बाद परिणाम की पुष्टि करें।

### **नोट्स और टिप्पणियाँ**

स्पीकर नोट्स और स्लाइड कमेंट्स स्लाइड सामग्री के साथ जुड़े होते हैं और स्लाइड क्लोन होने पर कॉपी हो जाते हैं। Aspose.Slides [presentation notes](/slides/hi/net/presentation-notes/) और [presentation comments](/slides/hi/net/presentation-comments/) के लिए भी समर्पित API प्रदान करता है।

यदि नोट‑पेज फॉर्मेटिंग महत्वपूर्ण है, तो मर्ज की गई प्रस्तुति की जाँच करें क्योंकि नोट्स‑मास्टर प्रस्तुति‑स्तर के ऑब्जेक्ट होते हैं और स्रोत फ़ाइलों में अलग हो सकते हैं। समीक्षात्मक कार्यप्रवाहों में विभिन्न लेखकों या टेम्प्लेट्स से फ़ाइलें मिलाने के बाद टिप्पणी लेखकों और थ्रेडेड टिप्पणियों की भी पुष्टि करें।

### **छवियाँ, ऑडियो, वीडियो, OLE ऑब्जेक्ट्स, और एक्सटर्नल लिंक**

स्लाइड्स प्रस्तुति‑स्तर के संसाधनों जैसे छवियाँ, एम्बेडेड ऑडियो, एम्बेडेड वीडियो, और OLE डेटा का संदर्भ दे सकते हैं। केवल दृश्यमान आकारों को कॉपी करने के बजाय पूरी स्लाइड को क्लोन करें ताकि Aspose.Slides उसके संसाधन संबंधों को बनाए रखे।

एम्बेडेड और लिंक्ड संसाधनों को अलग‑अलग संभालना चाहिए। एक लिंक्ड ऑडियो, वीडियो, OLE ऑब्जेक्ट, या हाइपरलिंक अभी भी अपने बाहरी लक्ष्य पर निर्भर रहता है; स्लाइड क्लोन करने से बाहरी लिंक एम्बेडेड सामग्री में नहीं बदलता। जहाँ मर्ज किया गया प्रस्तुति खोला जाएगा, उस पर्यावरण में लिंक्ड‑रेसोर्स पाथ और URL का परीक्षण करें।

Aspose.Slides स्वचालित रूप से क्लोन किए गए मास्टर्स को ट्रैक करता है, लेकिन इसे यह सामान्य गारंटी नहीं समझना चाहिए कि असंबंधित स्रोत प्रस्तुतियों से समान बाइनरी संसाधनों को हमेशा डेडुप्लिकेट किया जाएगा। यदि आउटपुट फ़ाइल आकार महत्वपूर्ण है, तो मर्ज किए गए पैकेज की जाँच करें और परिणाम मापें, न कि अंतर्निहित डेडुप्लिकेशन पर निर्भर रहें।

### **एम्बेडेड फ़ॉन्ट्स और फ़ॉन्ट उपलब्धता**

फ़ॉन्ट्स प्रस्तुति‑स्तर पर प्रबंधित होते हैं। यदि टाइपोग्राफी को मशीनों के बीच समान रखना है, तो केवल स्लाइड क्लोनिंग यह गारंटी नहीं देती कि सभी आवश्यक फ़ॉन्ट्स लक्ष्य पर्यावरण में उपलब्ध हों। आप [FontsManager.GetEmbeddedFonts](https://reference.aspose.com/slides/hi/net/aspose.slides/fontsmanager/getembeddedfonts/) से एम्बेडेड फ़ॉन्ट्स देख सकते हैं और [Embed Fonts in Presentations](/slides/hi/net/embedded-font/) में वर्णित अनुसार एम्बेडिंग को स्पष्ट रूप से प्रबंधित कर सकते हैं।

साथ ही यह पुष्टि करें कि आप स्रोत फ़ाइलों में प्रयुक्त फ़ॉन्ट्स को एम्बेड करने की अनुमति रखते हैं। फ़ॉन्ट लाइसेंस एम्बेडिंग को प्रतिबंधित कर सकते हैं।

### **पासवर्ड‑सुरक्षित प्रस्तुतियाँ**

एक पासवर्ड‑सुरक्षित स्रोत को उसके स्लाइड्स को क्लोन करने से पहले सफलतापूर्वक खोलना आवश्यक है। पासवर्ड को [LoadOptions.Password](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/password/) के माध्यम से प्रदान करें।

```csharp
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "YOUR_PASSWORD" };

using var source = new Presentation("protected.pptx", loadOptions);
```

एन्क्रिप्टेड स्रोत को खोलने से लक्ष्य प्रस्तुति पर वही सुरक्षा अपने‑आप लागू नहीं होती। आवश्यक होने पर आउटपुट संरक्षण को अलग से कॉन्फ़िगर करें।

### **बड़ी प्रस्तुतियाँ और मेमोरी उपयोग**

उच्च‑रिज़ॉल्यूशन छवियों, ऑडियो, वीडियो या अन्य बड़े बाइनरी ऑब्जेक्ट्स वाली बड़ी प्रस्तुतियाँ काफी मेमोरी उपयोग कर सकती हैं। [LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/blobmanagementoptions/) BLOB हैंडलिंग और टेम्पररी‑फ़ाइल उपयोग के लिए नियंत्रण प्रदान करता है। बड़े‑फ़ाइल रणनीतियों के लिए [Manage Presentation BLOBs](/slides/hi/net/manage-blob/) देखें।

बड़ी फ़ाइलों के लिए संभव हो तो फ़ाइल पाथ से लोड करें, प्रत्येक स्रोत प्रस्तुति को तभी नष्ट करें जब वह मर्ज हो चुका हो, और मध्यवर्ती परिणामों को बार‑बार सहेजने से बचें जब तक कि वर्कफ़्लो में चेक‑पॉइंट्स की आवश्यकता न हो।

### **थ्रेड सुरक्षा**

एक ही [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) इंस्टेंस को कई थ्रेड्स से एक साथ लोड, मॉडिफ़ाइ, सहेज या क्लोन न करें। प्रत्येक प्रस्तुति इंस्टेंस को एक मर्ज ऑपरेशन तक सीमित रखें। यदि आप स्वतंत्र कार्यों को समानांतर चलाते हैं, तो स्वतंत्र प्रस्तुति इंस्टेंस उपयोग करें और [Aspose.Slides मल्टीथ्रेडिंग गाइडेंस](/slides/hi/net/multithreading/) का पालन करें।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं प्रत्येक स्रोत प्रस्तुति की मूल डिज़ाइन कैसे बरकरार रखूँ?**

एक लक्ष्य मास्टर या लेआउट प्रदान किए बिना [AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/addclone/) का उपयोग करें। Aspose.Slides आवश्यक होने पर स्रोत मास्टर को स्वचालित रूप से क्लोन कर सकता है।

**आयातित स्लाइड्स को लक्ष्य थीम का उपयोग कैसे कराऊँ?**

उस ओवरलोड का उपयोग करें जो लक्ष्य मास्टर को स्वीकार करता है। लक्ष्य प्रस्तुति से एक मास्टर पास करें, स्रोत से नहीं। Aspose.Slides प्रत्येक स्रोत स्लाइड को उस मास्टर के तहत उपयुक्त लेआउट से मैप करने की कोशिश करेगा।

**किस परिस्थिति में लक्ष्य मास्टर के बजाय विशिष्ट लक्ष्य लेआउट का उपयोग करना चाहिए?**

जब प्रत्येक आयातित स्लाइड को एक ज्ञात लेआउट का प्रयोग करना हो, तो विशिष्ट लेआउट उपयोग करें। जब आप चाहते हैं कि Aspose.Slides स्रोत लेआउट प्रकार या नाम के आधार पर उस मास्टर के विभिन्न लेआउट्स में से चयन करे, तो मास्टर उपयोग करें।

**क्या विभिन्न स्लाइड आकारों वाली प्रस्तुतियों को मर्ज किया जा सकता है?**

हाँ, लेकिन स्लाइड सामग्री लक्ष्य आयामों के लिए स्वचालित रूप से पुनः डिज़ाइन नहीं होती। पूर्व‑आकार बदलने के लिए [SlideSize.SetSize](https://reference.aspose.com/slides/hi/net/aspose.slides/slidesize/setsize/) और [SlideSizeScaleType.EnsureFit](https://reference.aspose.com/slides/hi/net/aspose.slides/slidesizescaletype/) का उपयोग करें।

**क्या मैं PPT, PPTX, और ODP प्रस्तुतियों को एक फ़ाइल में मर्ज कर सकता हूँ?**

हां। प्रत्येक स्रोत प्रस्तुति को लोड करें, आवश्यक स्लाइड्स को एक लक्ष्य में क्लोन करें, और लक्ष्य को समर्थित आउटपुट फ़ॉर्मेट में सहेजें। चूँकि प्रस्तुति फ़ॉर्मेट्स में फीचर सेट पूरी तरह समान नहीं होते, क्रॉस‑फ़ॉर्मेट मर्ज के बाद जटिल सामग्री की पुष्टि करें। देखें [Supported File Formats](/slides/hi/net/supported-file-formats/)।

**क्या स्रोत सेक्शन स्वचालित रूप से बरकरार रहते हैं?**

नहीं, केवल स्लाइड्स को क्लोन करने वाले बेसिक लूप में नहीं। लक्ष्य में आवश्यक सेक्शन को पुनः बनाएं और सेक्शन संरचना को बरकरार रखने के लिए [AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecollection/addclone/) के सेक्शन ओवरलोड का उपयोग करें।

**क्या स्पीकर नोट्स और टिप्पणियाँ बरकरार रहती हैं?**

वे क्लोन की गई स्लाइड के साथ कॉपी हो जाती हैं। यदि नोट‑मास्टर स्टाइलिंग, टिप्पणी लेखकों या थ्रेडेड रिव्यू डेटा पर निर्भर वर्कफ़्लो है, तो मर्ज के बाद परिणाम की पुष्टि करें, क्योंकि इन स्थितियों में प्रस्तुति‑स्तर की संरचनाएं भी शामिल हैं।

**ऑडियो, वीडियो, OLE ऑब्जेक्ट्स, और हाइपरलिंक्स का क्या होता है?**

एम्बेडेड सामग्री क्लोन की गई स्लाइड के संसाधन संबंधों के हिस्से के रूप में ले जाई जाती है। बाहरी लिंक बाहरी ही रहते हैं, इसलिए मर्ज के बाद उनके लक्ष्य फ़ाइलें या URL उपलब्ध होना आवश्यक है।

**क्या सभी स्रोतों के एम्बेडेड फ़ॉन्ट्स मर्ज की गई प्रस्तुति में उपलब्ध सुनिश्चित हैं?**

स्लाइड क्लोनिंग केवल फ़ॉन्ट वितरण की गारंटी नहीं देती। लक्ष्य में एम्बेडेड फ़ॉन्ट्स की जाँच करें और टाइपोग्राफी महत्वपूर्ण होने पर फ़ॉन्ट एम्बेडिंग या बाहरी फ़ॉन्ट उपलब्धता को स्पष्ट रूप से प्रबंधित करें।

**मैं पासवर्ड‑सुरक्षित फ़ाइल को कैसे मर्ज करूँ?**

सही [LoadOptions.Password](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/password/) के साथ इसे खोलें, फिर उसकी स्लाइड्स को सामान्य रूप से क्लोन करें। आउटपुट सुरक्षा को अलग से कॉन्फ़िगर करें।

**बहुत बड़ी प्रस्तुतियों को कैसे संभालूँ?**

जब बड़े बाइनरी ऑब्जेक्ट मेमोरी को हावी करते हों, तो BLOB प्रबंधन उपयोग करें, बहुत बड़ी फ़ाइलों के लिए फ़ाइल‑पाथ लोडिंग को प्राथमिकता दें, स्रोत प्रस्तुतियों को तुरंत नष्ट करें, और अंतिम परिणाम को केवल आवश्यक होने पर ही सहेजें।

**क्या मैं कई थ्रेड्स से स्लाइड्स को मर्ज कर सकता हूँ?**

एक ही [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) इंस्टेंस को कई थ्रेड्स से एक साथ उपयोग न करें। प्रत्येक मर्ज ऑपरेशन को अपने स्वयं के प्रस्तुति इंस्टेंस तक सीमित रखें।