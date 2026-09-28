---
title: .NET में प्रस्तुति स्लाइड मास्टर को प्रबंधित करें
linktitle: स्लाइड मास्टर
type: docs
weight: 80
url: /hi/net/slide-master/
keywords:
- स्लाइड मास्टर
- मास्टर स्लाइड
- PPT मास्टर स्लाइड
- एकाधिक मास्टर स्लाइड्स
- मास्टर स्लाइड्स की तुलना
- पृष्ठभूमि
- प्लेसहोल्डर
- मास्टर स्लाइड क्लोन करें
- मास्टर स्लाइड कॉपी करें
- मास्टर स्लाइड डुप्लिकेट करें
- अनुपयोगी मास्टर स्लाइड
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: ".NET के लिए Aspose.Slides में स्लाइड मास्टर को प्रबंधित करें: PowerPoint और OpenDocument प्रस्तुतियों में मास्टर स्लाइड्स को एक्सेस, संपादित, क्लोन, तुलना और हटाएँ।"
---
## **अवलोकन**

एक **slide master** समूह स्लाइड्स के लिए साझा डिज़ाइन सेटिंग्स को परिभाषित करता है। इसमें सामान्य आकार, लोगो, पृष्ठभूमि, टेक्स्ट शैली, थीम सेटिंग्स, और फुटर सेटिंग्स हो सकते हैं। PowerPoint में, एक slide master को संपादित करना प्रस्तुति को सुसंगत रखने का सामान्य तरीका है, जिससे प्रत्येक स्लाइड पर समान स्वरूप दोहराने की आवश्यकता नहीं पड़ती।

Aspose.Slides for .NET समान मॉडल को समर्थन देता है। एक प्रस्तुति में एक या अधिक master slides हो सकते हैं, और प्रत्येक master slide में कई layout slides हो सकते हैं। सामान्य स्लाइड्स आमतौर पर सीधे master slide को संदर्भित नहीं करतीं। इसके बजाय, एक सामान्य स्लाइड एक layout slide का उपयोग करती है, और वह layout slide एक master slide से संबंधित होता है।

क्रमक्रम इस प्रकार है:

1. **Slide master** - साझा डिज़ाइन और थीम को परिभाषित करता है।
1. **Layout slide** - placeholders और layout‑स्तर फ़ॉर्मेटिंग की विशिष्ट व्यवस्था को परिभाषित करता है।
1. **Normal slide** - वास्तविक प्रस्तुति सामग्री रखता है और एक layout slide का उपयोग करता है।

![master slides, layout slides और normal slides की हायरार्की](slide-master_2.jpg)

Aspose.Slides में, एक slide master को [IMasterSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslide/) इंटरफ़ेस द्वारा दर्शाया जाता है। किसी प्रस्तुति में सभी master slides [Presentation.Masters](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/masters/) संग्रह के माध्यम से उपलब्ध होते हैं, जो [IMasterSlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslidecollection/) को लागू करता है।

{{% alert color="info" title="Inheritance" %}}
जब एक ही प्रॉपर्टी कई स्तरों पर परिभाषित होती है, तो अधिक विशिष्ट स्तर परिभाषित होता है। उदाहरण के लिए, यदि एक master slide और एक layout slide दोनों पृष्ठभूमि निर्धारित करते हैं, तो उस लेआउट पर आधारित स्लाइड्स लेआउट की पृष्ठभूमि का उपयोग करती हैं। लेआउट स्लाइड्स के बारे में अधिक जानकारी के लिए, देखें [स्लाइड लेआउट लागू करें या बदलें](/slides/hi/net/slide-layout/).
{{% /alert %}}

## **Slide Masters तक पहुंच**

PowerPoint में, आप **View** > **Slide Master** से Slide Master दृश्य खोल सकते हैं।

![PowerPoint View टैब पर Slide Master कमांड](slide-master_3.jpg)

Aspose.Slides में, master slides तक पहुंचने के लिए `Masters` संग्रह का उपयोग करें:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var firstMasterSlide = presentation.Masters[0];
var masterSlideCount = presentation.Masters.Count;
var firstMasterLayoutSlideCount = firstMasterSlide.LayoutSlides.Count;

Console.WriteLine("Master slides: " + masterSlideCount);
Console.WriteLine("Layouts in the first master: " + firstMasterLayoutSlideCount);
```

आप एक सामान्य स्लाइड द्वारा उपयोग किए गए master slide को उसके लेआउट के माध्यम से भी प्राप्त कर सकते हैं:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("presentation.pptx");

var slide = presentation.Slides[0];
var layoutSlide = slide.LayoutSlide;
var masterSlide = layoutSlide.MasterSlide;
var masterSlideName = masterSlide.Name;

Console.WriteLine(masterSlideName);
```

## **Slide Master में क्या सम्मिलित है**

एक master slide स्लाइड के समान ऑब्जेक्ट है। यह [IBaseSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseslide/) को लागू करता है, इसलिए यह सामान्य और layout स्लाइड्स द्वारा उपयोग किए जाने वाले कई समान स्लाइड प्रॉपर्टी प्रकट करता है। Master‑विशिष्ट सदस्य [IMasterSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslide/) API पृष्ठ पर सूचीबद्ध हैं।

आम तौर पर उपयोग किए जाने वाले master slide सदस्य शामिल हैं:

| सदस्य | उद्देश्य |
| --- | --- |
| `Background` | master‑लेवल स्लाइड पृष्ठभूमि सेट करता है। |
| `Shapes` | master पर रखे आकार संग्रहीत करता है, जैसे लोगो, चित्र फ्रेम, और साझा टेक्स्ट। |
| `LayoutSlides` | master से संबंधित layout स्लाइड्स को संग्रहीत करता है। |
| `ThemeManager` | master थीम API तक पहुँच प्रदान करता है। |
| `HeaderFooterManager` | master और उसके चाइल्ड लेआउट्स के लिए हेडर, फुटर, तिथि, और स्लाइड नंबर नियंत्रित करता है। |
| `GetDependingSlides` | उन सामान्य स्लाइड्स को लौटाता है जो अपने लेआउट्स के माध्यम से master पर निर्भर करती हैं। |

## **Slide Master में छवि जोड़ें**

जब आप एक master slide में छवि जोड़ते हैं, तो वह उन स्लाइड्स पर दिखाई देती है जो उस master के लेआउट का उपयोग करती हैं। यह लोगो, वॉटरमार्क, सजावटी बैंड और अन्य दोहराए जाने वाले विज़ुअल तत्वों के लिए उपयोगी है।

निम्नलिखित उदाहरण पहले master slide में एक लोगो जोड़ता है:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

चित्र फ़्रेम के बारे में अधिक जानकारी के लिए देखें [चित्र फ़्रेम](/slides/hi/net/picture-frame/).

## **Master ग्राफ़िक्स की दृश्यता नियंत्रित करें**

विरासत में मिले master ग्राफ़िक्स, जैसे लोगो या सजावटी आकार, को master से हटाए बिना छिपाने के लिए [IBaseSlide.ShowMasterShapes](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseslide/showmastershapes/) का उपयोग करें। उन स्लाइड्स पर जहाँ इन ग्राफ़िक्स को छोड़ना है, [Slide.ShowMasterShapes](https://reference.aspose.com/slides/hi/net/aspose.slides/slide/showmastershapes/) को `false` सेट करें और जिन स्लाइड्स पर इन्हें दिखाना है, उन्हें `true` रखें।

निम्नलिखित स्वतंत्र उदाहरण master पर एक नीला सजावटी बैंड बनाता है और दो स्लाइड्स जो समान खाली लेआउट का उपयोग करती हैं। बैंड पहली स्लाइड पर दिखाई देता है और दूसरी पर छिपा रहता है। कोई इनपुट प्रस्तुति या छवि आवश्यक नहीं है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var masterSlide = presentation.Masters[0];
var layoutSlide = masterSlide.LayoutSlides.GetByType(SlideLayoutType.Blank);
layoutSlide.ShowMasterShapes = true;

var slideHeight = presentation.SlideSize.Size.Height;
var band = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
band.FillFormat.FillType = FillType.Solid;
band.FillFormat.SolidFillColor.Color = Color.SteelBlue;
band.LineFormat.FillFormat.FillType = FillType.NoFill;

var visibleSlide = presentation.Slides[0];
visibleSlide.LayoutSlide = layoutSlide;
visibleSlide.Shapes.Clear();

var hiddenSlide = presentation.Slides.AddEmptySlide(layoutSlide);

visibleSlide.ShowMasterShapes = true;
hiddenSlide.ShowMasterShapes = false;

presentation.Save("master-graphics.pptx", SaveFormat.Pptx);
```

उदाहरण नई प्रस्तुति के साथ प्रदान किए गए **Blank** लेआउट का उपयोग करता है और प्रारंभिक स्लाइड के अपने placeholders को हटाता है।

### **सेटिंग का दायरा चुनें**

एक सामान्य स्लाइड अपने master को [ISlide.LayoutSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/layoutslide/) और [ILayoutSlide.MasterSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/ilayoutslide/masterslide/) के माध्यम से उपयोग करती है। किसी व्यक्तिगत स्लाइड पर प्रॉपर्टी सेट करने से केवल वही स्लाइड प्रभावित होती है। [LayoutSlide.ShowMasterShapes](https://reference.aspose.com/slides/hi/net/aspose.slides/layoutslide/showmastershapes/) को `false` सेट करने से उस साझा लेआउट का उपयोग करने वाली स्लाइड्स पर master ग्राफ़िक्स छिप जाते हैं, भले ही उनकी अपनी सेटिंग `true` हो। केवल एक स्लाइड पर ग्राफ़िक्स छिपाने के लिए, स्लाइड प्रॉपर्टी बदलें और साझा लेआउट को अपरिवर्तित रखें।

यह सेटिंग master स्लाइड पर खुद एक दृश्य नियंत्रण के रूप में समर्थन नहीं करती। master पर यह हमेशा `false` लौटाता है, और `true` असाइन करने से `NotSupportedException` उत्पन्न होता है। इसके बजाय इसे सामान्य स्लाइड या लेआउट पर लागू करें।

### **ग्राफ़िक्स को पृष्ठभूमि से अलग करें**

| ऑपरेशन | प्रभाव |
| --- | --- |
| master ग्राफ़िक्स छिपाएँ | नई विरासत में मिले master shapes की दृश्यता को नियंत्रित करता है बिना उन्हें हटाए या स्लाइड के अपने shapes को बदले। |
| स्लाइड पृष्ठभूमि भर को बदलें | पृष्ठभूमि का रंग, ग्रेडिएंट या छवि बदलता है। master ग्राफ़िक्स अलग shapes होते हैं और पृष्ठभूमि के ऊपर दिखाई दे सकते हैं। देखें [Presentation Background](/slides/hi/net/presentation-background/). |
| master से shape हटाएँ | साझा स्रोत shape को हटा देता है, जिससे वह किसी भी स्लाइड के लिए उपलब्ध नहीं रहता जो उस master का उपयोग करती है। |

## **Placeholders के साथ काम करें**

Placeholders आमतौर पर layout स्लाइड्स में परिभाषित होते हैं। master स्लाइड वह साझा शैली और थीम प्रदान करता है जिसे लेआउट विरासत में प्राप्त करते हैं, जबकि प्रत्येक लेआउट तय करता है कि कौन से placeholders उपलब्ध हैं और वे कहाँ रखे गए हैं।

PowerPoint में, placeholder कमांड्स Slide Master दृश्य में उपलब्ध हैं।

![PowerPoint Slide Master दृश्य में Insert Placeholder कमांड](slide-master_5.png)

Aspose.Slides के साथ नए placeholders जोड़ने के लिए, master से संबंधित layout स्लाइड के साथ काम करें:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

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

आप master स्लाइड पर पहले से मौजूद placeholder shapes को भी फ़ॉर्मेट कर सकते हैं। निम्नलिखित उदाहरण शीर्षक placeholder को खोजता है और उसमें रेखीय ग्रेडिएंट भर लागू करता है:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

![सामान्य स्लाइड्स द्वारा विरासत में मिला फ़ॉर्मेटेड शीर्षक placeholder](slide-master_8.png)

अधिक placeholder और टेक्स्ट फ़ॉर्मेटिंग विकल्पों के लिए देखें [Set Prompt Text in Placeholder](/slides/hi/net/manage-placeholder/) और [Text Formatting](/slides/hi/net/text-formatting/).

## **Slide Master पृष्ठभूमि बदलें**

एक master पृष्ठभूमि लेआउट्स और स्लाइड्स द्वारा विरासत में मिलती है जो इसे ओवरराइड नहीं करतीं। निम्नलिखित przykład पहले master स्लाइड के लिए एक ठोस पृष्ठभूमि रंग सेट करता है:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterSlide = presentation.Masters[0];

masterSlide.Background.Type = BackgroundType.OwnBackground;
masterSlide.Background.FillFormat.FillType = FillType.Solid;
masterSlide.Background.FillFormat.SolidFillColor.Color = Color.ForestGreen;

presentation.Save("presentation-master-background.pptx", SaveFormat.Pptx);
```

संबंधित विषयों के लिए देखें [Presentation Background](/slides/hi/net/presentation-background/) और [Presentation Theme](/slides/hi/net/presentation-theme/)।

## **Slide Master को दूसरे प्रस्तुती में क्लोन करें**

[IMasterSlideCollection.AddClone](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslidecollection/addclone/) का उपयोग करके एक master slide को दूसरे प्रस्तुती में कॉपी करें। कॉपी किया गया master फिर गंतव्य प्रस्तुती में लेआउट्स और स्लाइड्स द्वारा उपयोग किया जा सकता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var sourcePresentation = new Presentation("source.pptx");
using var destinationPresentation = new Presentation("destination.pptx");

var sourceMasterSlide = sourcePresentation.Masters[0];
var clonedMasterSlide = destinationPresentation.Masters.AddClone(sourceMasterSlide);

destinationPresentation.Save("destination-with-master.pptx", SaveFormat.Pptx);
```

यदि आपको उनके master के साथ सामान्य स्लाइड्स को क्लोन करने की आवश्यकता है, तो देखें [Clone Slides](/slides/hi/net/clone-slides/)।

## **एकाधिक Slide Masters जोड़ें**

एक प्रस्तुती में कई master स्लाइड्स हो सकते हैं। यह उपयोगी है जब विभिन्न अनुभागों को विभिन्न ब्रांडिंग, पृष्ठ संरचना, या थीम सेटिंग्स की आवश्यकता होती है।

![master स्लाइड्स को सम्मिलित करने और प्रबंधित करने के लिए PowerPoint कमांड्स](slide-master_9.jpg)

निम्नलिखित उदाहरण डिफ़ॉल्ट master को क्लोन करता है, क्लोन को एक अलग पृष्ठभूमि देता है, उस क्लोन किए गए master के नीचे एक लेआउट बनाता है, और उस लेआउट के आधार पर एक नई स्लाइड जोड़ता है:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Slide Masters की तुलना करें**

Master स्लाइड्स की तुलना [IBaseSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseslide/) से विरासत में प्राप्त `Equals` मेथड से की जा सकती है। तुलना संरचना और स्थैतिक सामग्री जैसे shapes, टेक्स्ट, फ़ॉर्मेटिंग, एनिमेशन, और अन्य स्लाइड सेटिंग्स की जाँच करती है। यह अद्वितीय पहचानकर्ताओं जैसे स्लाइड IDs या गतिशील placeholder मान जैसे वर्तमान तिथि की तुलना नहीं करती।

```csharp
using Aspose.Slides;

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

## **Slide Master दृश्य को डिफ़ॉल्ट दृश्य बनाएं**

[ViewProperties](https://reference.aspose.com/slides/hi/net/aspose.slides/viewproperties/) पर `LastView` प्रॉपर्टी का उपयोग करके वह दृश्य नियंत्रित करें जो PowerPoint पहले खोलता है। निम्नलिखित उदाहरण प्रस्तुती को Slide Master दृश्य में खोलता है:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.ViewProperties.LastView = ViewType.SlideMasterView;
presentation.Save("presentation-master-view.pptx", SaveFormat.Pptx);
```

अधिक दृश्य सेटिंग्स के लिए देखें [Save Presentation](/slides/hi/net/save-presentation/)।

## **Unused Master Slides हटाएं**

कभी-कभी प्रस्तुतियों में ऐसे master स्लाइड्स होते हैं जो अब किसी भी सामान्य स्लाइड द्वारा उपयोग नहीं होते। Unused master को हटाने से फ़ाइल आकार कम हो सकता है और टेम्प्लेट रखरखाव सरल हो जाता है।

Unused master को `Masters` संग्रह से हटाने के लिए [MasterSlideCollection.RemoveUnused](https://reference.aspose.com/slides/hi/net/aspose.slides/masterslidecollection/removeunused/) का उपयोग करें:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

presentation.Masters.RemoveUnused(ignorePreserveField: true);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

आप निम्न‑कोड [Compress.RemoveUnusedMasterSlides](https://reference.aspose.com/slides/hi/net/aspose.slides.lowcode/compress/removeunusedmasterslides/) मेथड का भी उपयोग कर सकते हैं:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

Aspose.Slides.LowCode.Compress.RemoveUnusedMasterSlides(presentation);
presentation.Save("presentation-clean.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Slide master और layout slide में क्या अंतर है?**

एक slide master साझा डिज़ाइन सेटिंग्स जैसे थीम, पृष्ठभूमि, सामान्य shapes और टेक्स्ट शैलियों को परिभाषित करता है। एक layout slide master slide से संबंधित होता है और placeholders की विशिष्ट व्यवस्था निर्धारित करता है। एक सामान्य स्लाइड एक layout slide का उपयोग करती है, इसलिए यह दोनों layout और master से विरासत में प्राप्त करती है।

**क्या एक प्रस्तुती में कई slide masters हो सकते हैं?**

हाँ। एक प्रस्तुती में कई slide masters हो सकते हैं। विभिन्न अनुभागों को विभिन्न दृश्य प्रणाली या ब्रांडिंग की आवश्यकता होने पर एकाधिक master का उपयोग करें।

**क्या मुझे placeholders master slide में जोड़ने चाहिए या layout slide में?**

अधिकांश मामलों में, placeholders को layout slides में जोड़ें। साझा विज़ुअल तत्व और साझा फ़ॉर्मेटिंग को master slide पर रखें, और सामग्री placeholders को उन लेआउट्स पर रखें जो सामान्य स्लाइड्स उपयोग करेंगे।

**क्या मैं एक ऐसा master slide हटा सकता हूँ जो अभी भी उपयोग में है?**

नहीं। एक master slide जिसमें निर्भर स्लाइड्स हैं, उसे सीधे सुरक्षित रूप से नहीं हटाया जा सकता। पहले उन स्लाइड्स को किसी अन्य master के तहत लेआउट्स में स्थानांत्रित करें, या एक ऐसा unused‑master साफ़ करने वाला तरीका उपयोग करें जो केवल उन master को हटाता है जो उपयोग में नहीं हैं।