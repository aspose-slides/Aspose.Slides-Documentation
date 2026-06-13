---
title: .NET में प्रस्तुति स्लाइड मास्टर प्रबंधित करें
linktitle: स्लाइड मास्टर
type: docs
weight: 80
url: /hi/net/slide-master/
keywords:
  - स्लाइड मास्टर
  - मास्टर स्लाइड
  - PPT मास्टर स्लाइड
  - कई मास्टर स्लाइड्स
  - मास्टर स्लाइड्स की तुलना करें
  - पृष्ठभूमि
  - प्लेसहोल्डर
  - मास्टर स्लाइड को क्लोन करें
  - मास्टर स्लाइड की प्रति बनाएं
  - मास्टर स्लाइड को डुप्लिकेट करें
  - अनुपयोगी मास्टर स्लाइड
  - PowerPoint
  - OpenDocument
  - प्रस्तुति
  - .NET
  - C#
  - Aspose.Slides
description: "Aspose.Slides for .NET में स्लाइड मास्टर प्रबंधित करें: PowerPoint और OpenDocument प्रस्तुतियों में मास्टर स्लाइड्स तक पहुंचें, संपादित करें, क्लोन करें, तुलना करें और हटाएँ।"
---
## **अवलोकन**

एक **स्लाइड मास्टर** स्लाइडों के एक समूह के लिए साझा डिज़ाइन सेटिंग्स को परिभाषित करता है। इसमें सामान्य आकृतियां, लोगो, पृष्ठभूमियां, टेक्स्ट शैलियां, थीम सेटिंग्स और फूटर सेटिंग्स शामिल हो सकती हैं। PowerPoint में, स्लाइड मास्टर को संपादित करना प्रस्तुति को लगातार बनाए रखने का सामान्य तरीका है, जिससे हर स्लाइड पर एक ही फ़ॉर्मेटिंग को दोहराने की आवश्यकता नहीं रहती।

Aspose.Slides for .NET समान मॉडल का समर्थन करता है। एक प्रस्तुति में एक या अधिक मास्टर स्लाइड्स हो सकती हैं, और प्रत्येक मास्टर स्लाइड कई लेआउट स्लाइड्स रख सकती है। सामान्य स्लाइड्स आमतौर पर सीधे मास्टर स्लाइड को संदर्भित नहीं करतीं। इसके बजाय, एक सामान्य स्लाइड एक लेआउट स्लाइड का उपयोग करती है, और वह लेआउट स्लाइड किसी मास्टर स्लाइड से संबंधित होती है।

क्रमिक संरचना इस प्रकार है:

1. **स्लाइड मास्टर** - साझा डिज़ाइन और थीम को परिभाषित करता है।  
1. **लेआउट स्लाइड** - प्लेसहोल्डर और लेआउट‑स्तर फ़ॉर्मेटिंग की विशिष्ट व्यवस्था को परिभाषित करता है।  
1. **सामान्य स्लाइड** - वास्तविक प्रस्तुति सामग्री रखती है और एक लेआउट स्लाइड का उपयोग करती है।  

![मास्टर स्लाइड, लेआउट स्लाइड और सामान्य स्लाइड की पदानुक्रम](slide-master_2.jpg)

Aspose.Slides में, एक स्लाइड मास्टर को [IMasterSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslide/) इंटरफ़ेस द्वारा दर्शाया जाता है। किसी प्रस्तुति की सभी मास्टर स्लाइड्स [Presentation.Masters](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/masters/) संग्रह के माध्यम से उपलब्ध होती हैं, जो [IMasterSlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslidecollection/) को लागू करता है।

{{% alert color="info" title="Inheritance" %}}
जब एक ही प्रॉपर्टी कई स्तरों पर परिभाषित होती है, तो अधिक विशिष्ट स्तर जीतता है। उदाहरण के लिए, यदि एक मास्टर स्लाइड और एक लेआउट स्लाइड दोनों पृष्ठभूमि निर्धारित करते हैं, तो उस लेआउट पर आधारित स्लाइडें लेआउट की पृष्ठभूमि का उपयोग करती हैं। लेआउट स्लाइड्स के बारे में अधिक जानकारी के लिए देखें [Apply or Change Slide Layouts](/slides/hi/net/slide-layout/)।
{{% /alert %}}

## **स्लाइड मास्टर तक पहुंचें**

PowerPoint में, आप **View** > **Slide Master** से स्लाइड मास्टर दृश्य खोल सकते हैं।

![PowerPoint व्यू टैब पर स्लाइड मास्टर कमांड](slide-master_3.jpg)

Aspose.Slides में, मास्टर स्लाइड्स तक पहुंचने के लिए `Masters` संग्रह का उपयोग करें:

```csharp
using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

आप एक सामान्य स्लाइड के लेआउट के माध्यम से उपयोग किए गए मास्टर स्लाइड को भी प्राप्त कर सकते हैं:

```csharp
using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **स्लाइड मास्टर में क्या होता है**

एक मास्टर स्लाइड एक स्लाइड‑समान वस्तु है। यह [IBaseSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseslide/) को लागू करती है, इसलिए यह सामान्य और लेआउट स्लाइड्स द्वारा उपयोग की जाने वाली कई समान स्लाइड प्रॉपर्टीज़ को उजागर करती है। मास्टर‑विशिष्ट सदस्य [IMasterSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslide/) API पृष्ठ पर सूचीबद्ध हैं।

आम तौर पर उपयोग किए जाने वाले मास्टर स्लाइड सदस्यों में शामिल हैं:

| सदस्य | उद्देश्य |
| --- | --- |
| `Background` | मास्टर‑स्तर की स्लाइड पृष्ठभूमि सेट करता है। |
| `Shapes` | मास्टर पर रखी गई आकृतियों को संग्रहीत करता है, जैसे लोगो, चित्र फ्रेम, और साझा टेक्स्ट। |
| `LayoutSlides` | उस मास्टर से संबंधित लेआउट स्लाइड्स को संग्रहीत करता है। |
| `ThemeManager` | मास्टर थीम API तक पहुंच प्रदान करता है। |
| `HeaderFooterManager` | मास्टर और उसकी चाइल्ड लेआउट्स के लिए हेडर, फूटर, तिथि और स्लाइड नंबर को नियंत्रित करता है। |
| `GetDependingSlides` | उन सामान्य स्लाइड्स को लौटाता है जो अपने लेआउट के माध्यम से मास्टर पर निर्भर करती हैं। |

## **स्लाइड मास्टर में एक छवि जोड़ें**

जब आप एक छवि को मास्टर स्लाइड में जोड़ते हैं, तो वह उन स्लाइड्स पर दिखाई देती है जो उसी मास्टर के लेआउट का उपयोग करती हैं। यह लोगो, वॉटरमार्क, सजावटी बैंड और अन्य पुनरावर्ती दृश्य तत्वों के लिए उपयोगी है।

निचला उदाहरण पहली मास्टर स्लाइड में एक लोगो जोड़ता है:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var logoBytes = File.ReadAllBytes("logo.png");
var logoImage = presentation.Images.AddImage(logoBytes);

masterSlide.Shapes.AddPictureFrame(
    ShapeType.Rectangle,
    x: 20,
    y: 20,
    width: 80,
    height: 80,
    image: logoImage);

presentation.Save("presentation-with-logo.pptx", SaveFormat.Pptx);
```

चित्र फ्रेम के बारे में अधिक जानकारी के लिए देखें [Picture Frame](/slides/hi/net/picture-frame/)।

## **प्लेसहोल्डर्स के साथ काम करें**

प्लेसहोल्डर्स सामान्यतः लेआउट स्लाइड्स पर परिभाषित किए जाते हैं। मास्टर स्लाइड साझा शैली और थीम प्रदान करती है जिसे लेआउट्स विरासत में लेते हैं, जबकि प्रत्येक लेआउट तय करता है कि कौन से प्लेसहोल्डर्स उपलब्ध हैं और वे कहाँ स्थित हैं।

PowerPoint में, प्लेसहोल्डर कमांड्स स्लाइड मास्टर दृश्य में उपलब्ध हैं।

![PowerPoint स्लाइड मास्टर दृश्य में Insert Placeholder कमांड](slide-master_5.png)

Aspose.Slides के साथ नए प्लेसहोल्डर्स जोड़ने के लिए, उस लेआउट स्लाइड के साथ काम करें जो मास्टर से संबंधित है:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var blankLayoutSlide =
    masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    masterSlide.LayoutSlides.Add(SlideLayoutType.Blank, "Blank");

blankLayoutSlide.PlaceholderManager.AddTextPlaceholder(
    x: 60,
    y: 120,
    width: 600,
    height: 80);

presentation.Slides.AddEmptySlide(blankLayoutSlide);
presentation.Save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
```

आप मास्टर स्लाइड पर पहले से मौजूद प्लेसहोल्डर आकृतियों को भी फ़ॉर्मैट कर सकते हैं। नीचे दिया गया उदाहरण शीर्षक प्लेसहोल्डर को खोजता है और रैखिक ग्रेडिएंट फ़िल लागू करता है:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];
var titlePlaceholder = FindPlaceholder(masterSlide, PlaceholderType.Title);

if (titlePlaceholder != null)
{
    var redGradientColor = Color.FromArgb(255, 0, 0);
    var purpleGradientColor = Color.FromArgb(128, 0, 128);

    titlePlaceholder.FillFormat.FillType = FillType.Gradient;
    titlePlaceholder.FillFormat.GradientFormat.GradientShape = GradientShape.Linear;
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(0, redGradientColor);
    titlePlaceholder.FillFormat.GradientFormat.GradientStops.Add(255, purpleGradientColor);
}

presentation.Save("presentation-title-style.pptx", SaveFormat.Pptx);

static IAutoShape? FindPlaceholder(IMasterSlide masterSlide, PlaceholderType placeholderType)
{
    foreach (var shape in masterSlide.Shapes)
    {
        if (shape is IAutoShape { Placeholder: not null } autoShape &&
            autoShape.Placeholder.Type == placeholderType)
        {
            return autoShape;
        }
    }

    return null;
}
```

![सामान्य स्लाइड्स द्वारा विरासत में मिला फ़ॉर्मेट किया गया शीर्षक प्लेसहोल्डर](slide-master_8.png)

और अधिक प्लेसहोल्डर और टेक्स्ट फ़ॉर्मैटिंग विकल्पों के लिए देखें [Set Prompt Text in Placeholder](/slides/hi/net/manage-placeholder/) और [Text Formatting](/slides/hi/net/text-formatting/)।

## **स्लाइड मास्टर पृष्ठभूमि बदलें**

मास्टर पृष्ठभूमि लेआउट्स और उन स्लाइड्स द्वारा विरासत में ली जाती है जो इसे ओवरराइड नहीं करतीं। नीचे दिया गया उदाहरण पहली मास्टर स्लाइड के लिए एक सॉलिड पृष्ठभूमि रंग सेट करता है:

```csharp
using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

संबंधित विषयों के लिए देखें [Presentation Background](/slides/hi/net/presentation-background/) और [Presentation Theme](/slides/hi/net/presentation-theme/)।

## **एक स्लाइड मास्टर को अन्य प्रस्तुति में क्लोन करें**

[IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslidecollection/addclone/) का उपयोग करके एक मास्टर स्लाइड को अन्य प्रस्तुति में कॉपी करें। कॉपी किया गया मास्टर फिर लक्ष्य प्रस्तुति में लेआउट्स और स्लाइड्स द्वारा उपयोग किया जा सकता है।

```csharp
using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

यदि आपको सामान्य स्लाइड्स को उनके मास्टर के साथ क्लोन करने की आवश्यकता है, तो देखें [Clone Slides](/slides/hi/net/clone-slides/)।

## **एकाधिक स्लाइड मास्टर जोड़ें**

एक प्रस्तुति में कई मास्टर स्लाइड्स हो सकती हैं। यह उपयोगी है जब विभिन्न अनुभागों को अलग‑अलग ब्रांडिंग, पृष्ठ संरचना या थीम सेटिंग्स की आवश्यकता होती है।

![मास्टर स्लाइड्स को जोड़ने और प्रबंधित करने के लिए PowerPoint कमांड्स](slide-master_9.jpg)

निचला उदाहरण डिफ़ॉल्ट मास्टर को क्लोन करता है, क्लोन को अलग पृष्ठभूमि देता है, उस क्लोन किए गए मास्टर के तहत एक लेआउट बनाता है, और उस लेआउट पर आधारित एक नई स्लाइड जोड़ता है:

```csharp
using var presentation = new Presentation("presentation.pptx");

var defaultMasterSlide = presentation.Masters[0];
var sectionMasterSlide = presentation.Masters.AddClone(defaultMasterSlide);

sectionMasterSlide.Background.Type = BackgroundType.OwnBackground;
sectionMasterSlide.Background.FillFormat.FillType = FillType.Solid;
sectionMasterSlide.Background.FillFormat.SolidFillColor.Color = Color.LightSteelBlue;

var sourceBlankLayout =
    defaultMasterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank) ??
    defaultMasterSlide.LayoutSlides[0];
var sectionBlankLayout = sectionMasterSlide.LayoutSlides.AddClone(sourceBlankLayout);

presentation.Slides.AddEmptySlide(sectionBlankLayout);
presentation.Save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
```

## **स्लाइड मास्टर की तुलना करें**

मास्टर स्लाइड्स की तुलना `Equals` मेथड से की जा सकती है, जो [IBaseSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseslide/) से विरासत में मिली है। तुलना संरचना और स्थिर सामग्री को जांचती है, जैसे आकृतियां, टेक्स्ट, फ़ॉर्मैटिंग, एनिमेशन और अन्य स्लाइड सेटिंग्स। यह स्लाइड IDs जैसे अद्वितीय पहचानकर्ताओं या वर्तमान तिथि जैसे डायनामिक प्लेसहोल्डर मानों की तुलना नहीं करती।

```csharp
using var firstPresentation = new Presentation("first.pptx");
using var secondPresentation = new Presentation("second.pptx");

var firstPresentationMasterCount = firstPresentation.Masters.Count;
var secondPresentationMasterCount = secondPresentation.Masters.Count;

for (var firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++)
{
    for (var secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++)
    {
        var firstMasterSlide = firstPresentation.Masters[firstMasterIndex];
        var secondMasterSlide = secondPresentation.Masters[secondMasterIndex];
        var areMasterSlidesEqual = firstMasterSlide.Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            Console.WriteLine(
                "first.pptx master #{0} equals second.pptx master #{1}",
                firstMasterIndex,
                secondMasterIndex);
        }
    }
}
```

अधिक जानकारी के लिए देखें [Compare Presentation Slides](/slides/hi/net/compare-slides/)।

## **स्लाइड मास्टर व्यू को डिफ़ॉल्ट व्यू बनाएं**

[ViewProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/viewproperties/) पर `LastView` प्रॉपर्टी का उपयोग करके उस व्यू को नियंत्रित किया जा सकता है जो PowerPoint प्रथम बार खोलता है। नीचे दिया गया उदाहरण प्रस्तुति को स्लाइड मास्टर व्यू में खोलता है:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

और अधिक व्यू सेटिंग्स के लिए देखें [Save Presentation](/slides/hi/net/save-presentation/)।

## **अनुपयोगी मास्टर स्लाइड्स हटाएँ**

कभी‑कभी प्रस्तुतियों में ऐसी मास्टर स्लाइड्स होती हैं जो अब किसी भी सामान्य स्लाइड द्वारा उपयोग नहीं की जातीं। अनावश्यक मास्टर को हटाने से फ़ाइल आकार कम हो सकता है और टेम्पलेट रखरखाव सरल हो जाता है।

`Masters` संग्रह से अनुपयोगी मास्टर को हटाने के लिए [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/hi/net/aspose.slides/masterslidecollection/removeunused/) का उपयोग करें:

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

आप कम‑कोड [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) मेथड का भी उपयोग कर सकते हैं:

```csharp
using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**स्लाइड मास्टर और लेआउट स्लाइड में क्या अंतर है?**

स्लाइड मास्टर थीम, पृष्ठभूमि, सामान्य आकृतियां और टेक्स्ट शैलियों जैसी साझा डिज़ाइन सेटिंग्स को परिभाषित करता है। लेआउट स्लाइड एक मास्टर स्लाइड की सदस्य होती है और प्लेसहोल्डर की विशिष्ट व्यवस्था को परिभाषित करती है। सामान्य स्लाइड एक लेआउट स्लाइड का उपयोग करती है, इसलिए वह दोनों लेआउट और मास्टर से विरासत में लेती है।

**क्या एक प्रस्तुति में कई स्लाइड मास्टर हो सकते हैं?**

हां। एक प्रस्तुति में कई स्लाइड मास्टर हो सकते हैं। विभिन्न अनुभागों को विभिन्न दृश्य प्रणालियों या ब्रांडिंग की आवश्यकता होने पर कई मास्टर का उपयोग करें।

**मास्टर स्लाइड या लेआउट स्लाइड में प्लेसहोल्डर जोड़ना चाहिए?**

अधिकांश मामलों में, प्लेसहोल्डर लेआउट स्लाइड्स में जोड़ें। साझा दृश्य तत्व और साझा फ़ॉर्मैटिंग मास्टर स्लाइड में रखें, फिर सामग्री प्लेसहोल्डर लेआउट्स में रखें जिन्हें सामान्य स्लाइड्स उपयोग करेंगी।

**क्या मैं अभी भी उपयोग में होने वाली मास्टर स्लाइड को हटा सकता हूं?**

नहीं। किसी मास्टर स्लाइड को जिसे निर्भर स्लाइड्स हैं, सीधे हटाना सुरक्षित नहीं है। पहले उन स्लाइड्स को किसी अन्य मास्टर के तहत लेआउट्स में ले जाएँ, या एक अनउपयोगी‑मास्टर सफाई विधि का उपयोग करें जो केवल उन मास्टर को हटाती है जो उपयोग में नहीं हैं।