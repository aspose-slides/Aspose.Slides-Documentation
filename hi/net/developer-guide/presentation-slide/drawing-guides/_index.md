---
title: ".NET में प्रस्तुतियों में ड्राइंग गाइड्स प्रबंधित करें"
linktitle: "ड्राइंग गाइड्स"
type: docs
weight: 85
url: /hi/net/drawing-guides/
keywords:
- "ड्राइंग गाइड"
- "क्षैतिज गाइड"
- "लंबवत गाइड"
- "संरेखण गाइड"
- "स्लाइड दृश्य"
- "मास्टर स्लाइड"
- "लेआउट स्लाइड"
- "नोट्स मास्टर"
- "हैंडआउट मास्टर"
- "PowerPoint"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint प्रस्तुतियों में क्षैतिज और लंबवत ड्राइंग गाइड जोड़ें, एक्सेस करें और साफ़ करें।"
---
## **परिचय**

ड्राइंग गाइड्स समायोज्य क्षैतिज और लंबवत रेखाएँ हैं जो उपयोगकर्ताओं को PowerPoint में प्रस्तुति को संपादित करते समय आकारों को लगातार संरेखित करने में मदद करती हैं। ये विशेष रूप से तब उपयोगी होते हैं जब कोई एप्लिकेशन प्रस्तुति उत्पन्न करता है जिसे बाद में मैन्युअल रूप से परिष्कृत किया जाएगा: एप्लिकेशन वही संरेखण सहायता सहेज सकता है जिसे लेखकों को सामग्री जोड़ते या स्थानांतरित करते समय अनुसरण करना चाहिए।

ड्राइंग गाइड्स संपादन सहायता हैं, स्लाइड सामग्री नहीं। ये स्लाइड शो या रेंडर किए गए आउटपुट में नहीं दिखते। Aspose.Slides for .NET इन्हें [IDrawingGuidesCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/idrawingguidescollection/) इंटरफ़ेस के माध्यम से उजागर करता है। एक गाइड को [IDrawingGuide](https://reference.aspose.com/slides/hi/net/aspose.slides/idrawingguide/) द्वारा दर्शाया जाता है और इसमें अभिविन्यास, स्थिति और रंग होते हैं।

स्थिति को संबंधित स्लाइड या मास्टर के शीर्ष-बाएँ किनारे से पॉइंट्स में मापा जाता है। एक लंबवत गाइड क्षैतिज समन्वय का उपयोग करता है, आमतौर पर शून्य से स्लाइड की चौड़ाई के बीच। एक क्षैतिज गाइड ऊर्ध्वाधर समन्वय का उपयोग करता है, आमतौर पर शून्य से स्लाइड की ऊँचाई के बीच।

## **स्लाइड दृश्य में गाइड जोड़ें**

सामान्य स्लाइड्स को संपादित करते समय प्रदर्शित गाइड्स को प्रबंधित करने के लिए [ICommonSlideViewProperties.DrawingGuides](https://reference.aspose.com/slides/hi/net/aspose.slides/icommonslideviewproperties/drawingguides/) का उपयोग करें। एक [Orientation](https://reference.aspose.com/slides/hi/net/aspose.slides/orientation/) मान और पॉइंट्स में स्थिति के साथ [IDrawingGuidesCollection.Add](https://reference.aspose.com/slides/hi/net/aspose.slides/idrawingguidescollection/add/) को कॉल करें।

निम्न उदाहरण स्लाइड के केंद्र के दाईं ओर एक लंबवत गाइड और उसके नीचे एक क्षैतिज गाइड जोड़ता है:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

guides.Add(Orientation.Vertical, slideSize.Width / 2 + 12.5f);
guides.Add(Orientation.Horizontal, slideSize.Height / 2 + 12.5f);

presentation.Save("drawing-guides.pptx", SaveFormat.Pptx);
```

## **ड्राइंग गाइड तक पहुँच**

[IDrawingGuidesCollection.Count](https://reference.aspose.com/slides/hi/net/aspose.slides/idrawingguidescollection/count/) प्रॉपर्टी और इंडेक्सर मौजूदा गाइड्स तक पहुँच प्रदान करते हैं। [IDrawingGuide.Orientation](https://reference.aspose.com/slides/hi/net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.Position](https://reference.aspose.com/slides/hi/net/aspose.slides/idrawingguide/position/) और [IDrawingGuide.Color](https://reference.aspose.com/slides/hi/net/aspose.slides/idrawingguide/color/) प्रॉपर्टीज़ को पढ़ा या बदला जा सकता है।

निम्न उदाहरण उपरोक्त निर्मित प्रस्तुति से स्लाइड-व्यू गाइड्स को पढ़ता है:

```csharp
using Aspose.Slides;

using var presentation = new Presentation("drawing-guides.pptx");

var guides = presentation.ViewProperties.SlideViewProperties.DrawingGuides;

for (var index = 0; index < guides.Count; index++)
{
    var guide = guides[index];
    Console.WriteLine($"Guide {index}: orientation = {guide.Orientation}, position = {guide.Position}, color = {guide.Color}");
}
```

## **मास्टर और लेआउट स्लाइड्स में गाइड जोड़ें**

एक स्लाइड मास्टर और उसके प्रत्येक लेआउट स्लाइड के अपने ड्राइंग‑गाइड संग्रह हो सकते हैं। मास्टर स्लाइड के लिए [IMasterSlide.DrawingGuides](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterslide/drawingguides/) और लेआउट स्लाइड के लिए [ILayoutSlide.DrawingGuides](https://reference.aspose.com/slides/hi/net/aspose.slides/ilayoutslide/drawingguides/) का उपयोग करें।

निम्न उदाहरण पहले मास्टर स्लाइड में एक लंबवत गाइड और पहले लेआउट स्लाइड में एक क्षैतिज गाइड जोड़ता है:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var slideSize = presentation.SlideSize.Size;
var masterGuides = presentation.Masters[0].DrawingGuides;
var layoutGuides = presentation.LayoutSlides[0].DrawingGuides;

masterGuides.Add(Orientation.Vertical, slideSize.Width / 2 - 20f);
layoutGuides.Add(Orientation.Horizontal, slideSize.Height / 2 + 20f);

presentation.Save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **नोट्स और हैंडआउट मास्टर्स में गाइड जोड़ें**

नोट्स मास्टर्स और हैंडआउट मास्टर्स भी ड्राइंग गाइड्स का समर्थन करते हैं। उनके संग्रहों तक पहुँचने के लिए [IMasterNotesSlide.DrawingGuides](https://reference.aspose.com/slides/hi/net/aspose.slides/imasternotesslide/drawingguides/) और [IMasterHandoutSlide.DrawingGuides](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterhandoutslide/drawingguides/) का उपयोग करें। यदि प्रस्तुति में इनमें से कोई मास्टर नहीं है, तो [IMasterNotesSlideManager.SetDefaultMasterNotesSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/imasternotesslidemanager/setdefaultmasternotesslide/) या [IMasterHandoutSlideManager.SetDefaultMasterHandoutSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) डिफ़ॉल्ट मास्टर बनाता है और उसे लौटाता है।

निम्न उदाहरण नोट्स मास्टर में एक क्षैतिज गाइड और हैंडआउट मास्टर में एक लंबवत गाइड जोड़ता है:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var notesSize = presentation.NotesSize.Size;
var notesMaster = presentation.MasterNotesSlideManager.SetDefaultMasterNotesSlide();
var handoutMaster = presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();

notesMaster.DrawingGuides.Add(Orientation.Horizontal, notesSize.Height / 2 + 50f);
handoutMaster.DrawingGuides.Add(Orientation.Vertical, notesSize.Width / 2 - 50f);

presentation.Save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
```

## **ड्राइंग गाइड साफ़ करें**

किसी विशेष संग्रह से सभी गाइड्स को हटाने के लिए [IDrawingGuidesCollection.Clear](https://reference.aspose.com/slides/hi/net/aspose.slides/idrawingguidescollection/clear/) को कॉल करें। एक संग्रह को साफ़ करने से दूसरे स्कोप में संग्रहीत गाइड्स पर कोई प्रभाव नहीं पड़ता।

निम्न उदाहरण स्लाइड‑व्यू गाइड्स, सभी स्लाइड मास्टर्स, लेआउट स्लाइड्स, नोट्स मास्टर और हैंडआउट मास्टर पर गाइड्स को साफ़ करता है, बिना अनुपलब्ध मास्टर्स बनाए:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation-with-guides.pptx");

presentation.ViewProperties.SlideViewProperties.DrawingGuides.Clear();

foreach (var masterSlide in presentation.Masters)
{
    masterSlide.DrawingGuides.Clear();
}

foreach (var layoutSlide in presentation.LayoutSlides)
{
    layoutSlide.DrawingGuides.Clear();
}

var notesMaster = presentation.MasterNotesSlideManager.MasterNotesSlide;
if (notesMaster != null)
{
    notesMaster.DrawingGuides.Clear();
}

var handoutMaster = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
if (handoutMaster != null)
{
    handoutMaster.DrawingGuides.Clear();
}

presentation.Save("presentation-without-guides.pptx", SaveFormat.Pptx);
```

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या ड्राइंग गाइड स्लाइड शो या निर्यातित छवियों में दिखाई देते हैं?**

नहीं। ड्राइंग गाइड्स संपादन के लिए संरेखण सहायता हैं और प्रस्तुति सामग्री के रूप में रेंडर नहीं होते।

**क्या कोई ड्राइंग गाइड सीधे व्यक्तिगत सामान्य स्लाइड में जोड़ा जा सकता है?**

सामान्य‑स्लाइड संपादन गाइड्स प्रस्तुति की स्लाइड‑व्यू प्रॉपर्टीज़ में संग्रहीत होते हैं। स्लाइड मास्टर्स, लेआउट स्लाइड्स, नोट्स मास्टर्स और हैंडआउट मास्टर्स के लिए अलग गाइड संग्रह उपलब्ध होते हैं।

**गाइड स्थितियों के लिए कौन सी इकाइयाँ उपयोग की जाती हैं?**

स्थिति पॉइंट्स में निर्दिष्ट की जाती है, जहाँ 72 पॉइंट्स एक इंच के बराबर होते हैं। लंबवत स्थितियों को बाएँ किनारे से और क्षैतिज स्थितियों को शीर्ष किनारे से मापा जाता है।

**क्या ड्राइंग गाइड्स साफ़ करने से आकार या स्लाइड सामग्री बदलती है?**

नहीं। `Clear` मेथड केवल चयनित संग्रह में मौजूद गाइड्स को हटाता है। आकार और अन्य स्लाइड सामग्री अपरिवर्तित रहती है।