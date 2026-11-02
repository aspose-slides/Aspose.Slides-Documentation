---
title: ".NET में प्रस्तुति हाइपरलिंक प्रबंधित करें"
linktitle: "हाइपरलिंक प्रबंधित करें"
type: docs
weight: 20
url: /hi/net/manage-hyperlinks/
keywords:
- "URL जोड़ें"
- "हाइपरलिंक जोड़ें"
- "हाइपरलिंक बनाएं"
- "हाइपरलिंक स्वरूपित करें"
- "हाइपरलिंक हटाएं"
- "हाइपरलिंक अपडेट करें"
- "पाठ हाइपरलिंक"
- "स्लाइड हाइपरलिंक"
- "आकार हाइपरलिंक"
- "छवि हाइपरलिंक"
- "वीडियो हाइपरलिंक"
- "परिवर्तनीय हाइपरलिंक"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Aspose.Slides for .NET का उपयोग करके PowerPoint और OpenDocument प्रस्तुतियों में हाइपरलिंक जोड़ें, स्वरूपित करें, अपडेट करें और हटाएं, C# उदाहरणों के साथ।"
---
## **परिचय**

हाइपरलिंक प्रस्तुति सामग्री को एक वेबसाइट या प्रस्तुति के भीतर किसी स्थान से जोड़ता है। PowerPoint में, हाइपरलिंक आमतौर पर दो उद्देश्यों की पूर्ति करते हैं:

* पाठ, आकार या मीडिया फ्रेम से वेबसाइट खोलें।
* उदाहरण के लिए, सामग्री सारणी से किसी अन्य स्लाइड पर नेविगेट करें।

Aspose.Slides for .NET आपको ये लिंक जोड़ने, उनके रूप और ध्वनि को नियंत्रित करने, उनके गुण अपडेट करने और हटाने की सुविधा देता है। नीचे दिए गए उदाहरण दिखाते हैं कि व्यक्तिगत तत्वों पर हाइपरलिंक के साथ कैसे काम किया जाए और प्रस्तुति, स्लाइड या टेक्स्ट‑फ़्रेम स्तर पर हाइपरलिंक तक कैसे पहुँचें।

{{% alert color="info" title="Note" %}}
आप प्रस्तुतियों को [मुफ़्त ऑनलाइन Aspose PowerPoint संपादक](https://products.aspose.app/slides/editor) के साथ भी संपादित कर सकते हैं।
{{% /alert %}} 

## **URL हाइपरलिंक जोड़ें**

आप एक वेबसाइट URL को पाठ, आकार या मीडिया फ्रेम को असाइन कर सकते हैं। जिस तत्व पर आप हाइपरलिंक असाइन करते हैं, वह क्लिक करने योग्य क्षेत्र निर्धारित करता है: एक पाठ भाग चयनित पाठ को लिंक करता है, जबकि आकार या फ्रेम स्लाइड ऑब्जेक्ट को लिंक करता है।

सापेक्ष हाइपरलिंक वाली प्रस्तुतियों के लिए, [हाइपरलिंक बेस का प्रबंधन](/slides/hi/net/presentation-properties/#manage-the-hyperlink-base) देखें ताकि आप दस्तावेज‑स्तर बेस को पढ़, बदल या साफ कर सकें।

### **पाठ के लिए URL हाइपरलिंक जोड़ें**

वेबसाइट से पाठ को लिंक करने के लिए, नीचे दिखाए अनुसार पाठ भाग की [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/portionformat/hyperlinkclick/) गुण को एक [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink/) असाइन करें। केवल वही पाठ भाग क्लिक योग्य बन जाता है।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var textShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
textShape.AddTextFrame("Aspose: File Format APIs");
var portionFormat = textShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
portionFormat.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";
portionFormat.FontHeight = 32;

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

### **आकार और मीडिया फ्रेम में URL हाइपरलिंक जोड़ें**

आकार या फ्रेम को क्लिक करने योग्य बनाने के लिए उसकी [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/hyperlinkclick/) गुण सेट करें। हाइपरलिंक स्वयं ऑब्जेक्ट को संबोधित करता है, न कि उसके अंदर के किसी पाठ भाग को।

समान दृष्टिकोण चित्र, ऑडियो और वीडियो फ्रेम पर भी लागू होता है: फ्रेम को हाइपरलिंक असाइन करें और आवश्यक होने पर लिंक के [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) को सेट करें।

नीचे का उदाहरण एक आयत को क्लिक योग्य बनाता है:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **हाइपरलिंक का उपयोग करके सामग्री तालिका बनाएं**

आंतरिक हाइपरलिंक पाठकों को सामग्री तालिका से किसी विशिष्ट स्लाइड पर जाकर पहुंचाते हैं। नीचे का उदाहरण [SetInternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) का उपयोग करके पहली स्लाइड पर “Page 2” पाठ को दूसरी स्लाइड से जोड़ता है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var firstSlide = presentation.Slides[0];
var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var tableOfContents = firstSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
tableOfContents.FillFormat.FillType = FillType.NoFill;
tableOfContents.LineFormat.FillFormat.FillType = FillType.NoFill;
tableOfContents.TextFrame.Paragraphs.Clear();

var paragraph = new Paragraph();
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
paragraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
paragraph.Text = "Title of slide 2 .......... ";

var linkPortion = new Portion();
linkPortion.Text = "Page 2";
linkPortion.PortionFormat.HyperlinkManager.SetInternalHyperlinkClick(secondSlide);

paragraph.Portions.Add(linkPortion);
tableOfContents.TextFrame.Paragraphs.Add(paragraph);

presentation.Save("link_to_slide.pptx", SaveFormat.Pptx);
```

## **हाइपरलिंक स्वरूपित करें**

### **रंग**

[IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) की [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) गुण निर्धारित करता है कि हाइपरलिंक प्रस्तुति के हाइपरलिंक रंग का उपयोग करता है या पाठ भाग के फ़ॉर्मेट का। कस्टम पाठ रंग लागू करने के लिए, [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkcolorsource/) चुनें और भाग की भराव रंग सेट करें। यह सुविधा PowerPoint 2019 में प्रस्तुत की गई; पुराने संस्करण इस सेटिंग को लागू नहीं करेंगे।

नीचे का उदाहरण एक ही स्लाइड पर दो पाठ हाइपरलिंक जोड़ता है। पहला लाल पाठ भराव का उपयोग करता है, जबकि दूसरा डिफ़ॉल्ट हाइपरलिंक रंग को बनाए रखता है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var coloredShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
coloredShape.AddTextFrame("This hyperlink uses a custom color.");
var coloredPortionFormat = coloredShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
coloredPortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
coloredPortionFormat.HyperlinkClick.ColorSource = HyperlinkColorSource.PortionFormat;
coloredPortionFormat.FillFormat.FillType = FillType.Solid;
coloredPortionFormat.FillFormat.SolidFillColor.Color = Color.Red;

var defaultShape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
defaultShape.AddTextFrame("This hyperlink uses the default color.");
defaultShape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com/");

presentation.Save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
```
### **ध्वनि**

हाइपरलिंक सक्रिय होने पर ध्वनि बजा सकता है या पहले से चल रही ध्वनि को रोक सकता है। इन व्यवहारों को कॉन्फ़िगर करने के लिए निम्नलिखित गुणों का उपयोग करें:

- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) हाइपरलिंक से संबद्ध ऑडियो निर्दिष्ट करता है।
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) नियंत्रित करता है कि हाइपरलिंक सक्रिय होने पर पिछली ध्वनि बंद होनी चाहिए या नहीं।

#### **हाइपरलिंक ध्वनि जोड़ें**

नीचे का उदाहरण `sampleaudio.wav` लोड करता है और पहले स्लाइड पर एक बटन से जोड़ता है। बटन पर क्लिक करने से ध्वनि चलती है और अगली स्लाइड पर नेविगेट होता है। उसी स्लाइड का दूसरा आकार क्लिक पर पिछले ध्वनि को रोकता है, बिना नेविगेशन किए।

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var audioData = File.ReadAllBytes("sampleaudio.wav");
var hyperlinkSound = presentation.Audios.AddAudio(audioData);

var firstSlide = presentation.Slides[0];

var playButton = firstSlide.Shapes.AddAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
playButton.HyperlinkClick = Hyperlink.NextSlide;

if (!playButton.HyperlinkClick.StopSoundOnClick && playButton.HyperlinkClick.Sound == null)
{
    playButton.HyperlinkClick.Sound = hyperlinkSound;
}

var secondSlide = presentation.Slides.AddEmptySlide(firstSlide.LayoutSlide);

var stopButton = secondSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
stopButton.HyperlinkClick = Hyperlink.NoAction;

stopButton.HyperlinkClick.StopSoundOnClick = true;

presentation.Save("hyperlink-sound.pptx", SaveFormat.Pptx);
```

#### **हाइपरलिंक ध्वनि निकालें**

नीचे का उदाहरण ऊपर बनाए गए प्रस्तुति को खोलता है और प्रथम आकार की हाइपरलिंक ऑडियो को [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) और [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/) के माध्यम से मेमोरी में पढ़ता है।

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("hyperlink-sound.pptx");

if (presentation.Slides.Count > 0 && presentation.Slides[0].Shapes.Count > 0)
{
    var hyperlink = presentation.Slides[0].Shapes[0].HyperlinkClick;
    var sound = hyperlink?.Sound;
    if (sound != null)
    {
        var audioData = sound.BinaryData;
        Console.WriteLine($"Extracted {audioData.Length} bytes of hyperlink audio.");
    }
    else
    {
        Console.WriteLine("The first shape has no hyperlink sound.");
    }
}
else
{
    Console.WriteLine("The presentation has no first slide or shape to inspect.");
}
```

### **टूलटिप और इंटरैक्शन सेटिंग्स**

पाठ या आकार को हाइपरलिंक असाइन करने के बाद आप निम्नलिखित [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) गुण अपडेट कर सकते हैं:

- [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) वह पाठ सेट करता है जो दर्शक लिंक के संकेत के रूप में देख सकता है।
- [TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetframe/) लागू होने पर पैरेंट HTML फ्रेमसेट के भीतर लक्ष्य फ्रेम निर्दिष्ट करता है।
- [History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/history/) नियंत्रित करता है कि लिंक सक्रिय होने पर उसका गंतव्य देखी गई हाइपरलिंक सूची में जोड़ा जाए या नहीं।
- [HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/highlightclick/) नियंत्रित करता है कि क्लिक करने पर हाइपरलिंक हाइलाइट हो या नहीं।

## **प्रस्तुति से हाइपरलिंक हटाएं**

परिवर्तन करने से पहले हाइपरलिंक कंटेनरों को एकत्र करने के लिए [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) का उपयोग करें। नीचे का उदाहरण पहली स्लाइड से दोनों सक्रियता प्रकारों को हटाता है। केवल एक प्रकार हटाने के लिए आप केवल [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) या [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) को कॉल करें; क्लिक कार्रवाई हटाने से माउस‑ओवर समकक्ष नहीं हटता।

```csharp
using System;
using System.Linq;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");

if (presentation.Slides.Count > 0)
{
    var containers = presentation.Slides[0].HyperlinkQueries.GetAnyHyperlinks().ToList();
    foreach (var container in containers)
    {
        container.HyperlinkManager.RemoveHyperlinkClick();
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
    presentation.Save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("The presentation has no slides to process.");
}
```

निरपेक्ष हटाने के लिए, [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) चयनित स्कोप में दोनों सक्रियता प्रकारों को एक ही कॉल में हटाता है। चयनात्मक सफाई और मास्टर, लेआउट और नोट्स की कवरेज के लिए देखें [रिपोर्ट, स्वच्छता, और हाइपरलिंक सत्यापित करें](#report-sanitize-and-verify-hyperlinks)।

## **एक पूर्ण हाइपरलिंक इन्वेंट्री बनाएं**

प्रस्तुति वितरित करने से पहले उसकी इंटरैक्टिव क्रियाओं और वेब लिंक की सूची बनाएं। [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) [IHyperlinkContainer](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/) ऑब्जेक्ट्स लौटाता है, न कि URL स्ट्रिंग्स की समतल सूची। प्रत्येक कंटेनर पर [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) और [HyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) दोनों की जांच करें। वे स्वतंत्र होते हैं: एक ही कंटेनर दोनों क्रियाएँ रख सकता है, इसलिए पूर्ण रिपोर्ट के लिए प्रति कंटेनर दो पंक्तियों की आवश्यकता हो सकती है।

केवल आकार‑स्तर के हाइपरलिंक स्कैन करने से पाठ भागों से जुड़े लिंक मिस हो सकते हैं। उचित स्कोप को क्वेरी करें, और लौटाए गए कंटेनरों को रखें ताकि बाद में आप उनके क्रियाओं को अपडेट या हटाना चाहें।

### **प्रस्तुति, स्लाइड, और टेक्स्ट‑फ़्रेम स्कोप की क्वेरी**

[IHyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/) इंटरफ़ेस [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/hyperlinkqueries/), और [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/) के माध्यम से उपलब्ध है। प्रत्येक स्कोप समान क्वेरी का समर्थन करता है:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) क्लिक क्रिया वाले कंटेनर लौटाता है।
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) माउस‑ओवर क्रिया वाले कंटेनर लौटाता है।
- [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) किसी भी या दोनों क्रियाओं वाले कंटेनर लौटाता है।

नीचे का उदाहरण `hyperlink-audit-input.pptx` बनाता है जिसमें बाहरी क्लिक लिंक, फ़ाइल माउस‑ओवर लिंक, आंतरिक स्लाइड नेविगेशन, पाठ माउस‑ओवर लिंक, और मैक्रो कार्रवाई शामिल हैं। यह इन कार्यों में से कोई भी नहीं चलाता। समान तीन क्वेरी हर स्कोप पर काम करती हैं; गणना कंटेनरों को दर्शाती है, कार्य कुलों को नहीं। टेक्स्ट‑फ़्रेम स्कोप enclosing shape के अपने लिंक को बाहर रखता है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var destination = presentation.Slides.AddEmptySlide(slide.LayoutSlide);
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
shape.TextFrame.Text = "Click the text to go to slide 2";
shape.HyperlinkManager.SetExternalHyperlinkClick("https://example.com/");
shape.HyperlinkClick.Tooltip = "Public website";
shape.HyperlinkManager.SetExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

var portionFormat = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat;
portionFormat.HyperlinkManager.SetInternalHyperlinkClick(destination);
portionFormat.HyperlinkManager.SetExternalHyperlinkMouseOver("https://example.com/help");
var macroButton = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
macroButton.HyperlinkManager.SetMacroHyperlinkClick("ReviewPresentation");

PrintCounts("Presentation", presentation.HyperlinkQueries);
PrintCounts("Slide 1", slide.HyperlinkQueries);
PrintCounts("Text frame", shape.TextFrame.HyperlinkQueries);
presentation.Save("hyperlink-audit-input.pptx", SaveFormat.Pptx);

static void PrintCounts(string scope, IHyperlinkQueries queries)
{
    var clickContainers = queries.GetHyperlinkClicks();
    var mouseOverContainers = queries.GetHyperlinkMouseOvers();
    var allContainers = queries.GetAnyHyperlinks();
    Console.WriteLine($"{scope}: click={clickContainers.Count}, mouse-over={mouseOverContainers.Count}, any={allContainers.Count}");
}
```

इस उदाहरण के लिए, प्रस्तुति और स्लाइड क्वेरी प्रत्येक तीन क्लिक कंटेनर, दो माउस‑ओवर कंटेनर, और तीन दोनों प्रकार के कंटेनर रिपोर्ट करती हैं। टेक्स्ट‑फ़्रेम क्वेरी प्रत्येक श्रेणी में एक कंटेनर रिपोर्ट करती है।

### **कार्यों और गंतव्य का वर्गीकरण**

एक कार्रवाई को उसके गंतव्य की व्याख्या से पहले समझने के लिए [IHyperlink.ActionType](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/actiontype/) का उपयोग करें। [HyperlinkActionType](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkactiontype/) मान वेब नेविगेशन से अधिक को कवर करते हैं:

| मान | ऑडिट के लिए अर्थ |
| --- | --- |
| `Hyperlink` | बाहरी हाइपरलिंक; URL और उसके स्कीम की जांच करें। |
| `JumpSpecificSlide` | किसी विशिष्ट स्लाइड पर आंतरिक नेविगेशन। |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | बिल्ट‑इन स्लाइडशो नेविगेशन, स्लाइडशो संदर्भ में हल किया जाता है। |
| `JumpEndShow`, `StartCustomSlideShow` | वर्तमान शो समाप्त करें या कस्टम शो शुरू करें। |
| `StartMacro` | मैक्रो चलाएँ। |
| `StartProgram` | प्रोग्राम लॉन्च करें। |
| `OpenFile`, `OpenPresentation` | फ़ाइल या अन्य प्रस्तुति खोलें; वेब URL से अलग समीक्षा करें। |
| `StartStopMedia` | मीडिया प्लेबैक शुरू या रोकें। |
| `NoAction`, `Unknown` | कोई नेविगेशन कार्रवाई नहीं, या अपरिचित कार्रवाई जिसे समीक्षा की आवश्यकता है। |

बाहरी गंतव्य को [ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) से पढ़ें और विशिष्ट आंतरिक गंतव्य को [TargetSlide](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetslide/) से। आंतरिक कार्रवाइयों और बिल्ट‑इन कमांड में बाहरी URL नहीं हो सकता; खाली URL का अर्थ यह नहीं है कि कंटेनर में कोई कार्रवाई नहीं है। जब [ExternalUrlOriginal](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurloriginal/) सामान्यीकृत URL से भिन्न हो तो उसे संरक्षित रखें, और उपलब्ध होने पर [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) शामिल करें।

### **रिपोर्ट, स्वच्छता, और हाइपरलिंक सत्यापित करें**

नीचे .NET 6+ उदाहरण मौजूदा प्रस्तुति (ऊपर बनाई गई फ़ाइल) पढ़ता है, `hyperlink-audit.json` लिखता है, नीति लागू करता है, `hyperlink-sanitized.pptx` सहेजता है, और दो बार सक्रियता प्रकारों की जाँच के लिए पुनः खोलता है। यह परिवर्तन से पहले कंटेनरों को इकट्ठा करता है और समान कंटेनर को दो बार प्रोसेस करने से बचने के लिए रेफ़रेंस समानता का उपयोग करता है। प्रस्तुति क्वेरियां सामान्य स्लाइड को कवर करती हैं; पैकेज‑व्यापी इन्वेंट्री के लिए यह स्पष्ट रूप से मास्टर, लेआउट, नोट्स, तथा नोट्स और हैंडआउट मास्टर को भी क्वेरी करती है।

रिपोर्ट एक‑आधारित स्लाइड इंडेक्स और उपलब्ध होने पर [SlideId](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideid/) को रिकॉर्ड करती है। समर्थित कंटेनरों के लिए [ISlideComponent.Slide](https://reference.aspose.com/slides/net/aspose.slides/islidecomponent/slide/) वह स्वामित्व स्लाइड प्रदान करता है। मास्टर, लेआउट और नोट्स का कोई सामान्य स्लाइड इंडेक्स नहीं होता और वे अपने स्कोप द्वारा पहचाने जाते हैं। आकार कंटेनर और पाठ‑भाग फ़ॉर्मेट कंटेनर अलग‑अलग लेबल होते हैं; अन्य कंटेनर प्रकार अपने रन‑टाइम टाइप नाम रखते हैं। प्रत्येक कंटेनर को रिपोर्ट‑स्थानीय ID दी जाती है ताकि उसकी दो कार्रवाइयों को संबंधित किया जा सके।

यह सख्त अनुप्रयोग नीति केवल निरपेक्ष HTTPS URL और वैध आंतरिक स्लाइड लक्ष्य की अनुमति देती है। यह मैक्रो, प्रोग्राम, फ़ाइल कार्रवाई, अन्य स्लाइडशो क्रिया, अज्ञात कार्रवाई, और अन्य URL योजनाओं को अस्वीकार करती है। ये अस्वीकृतियाँ नीति निर्णय हैं, Aspose.Slides सुरक्षा निर्णय नहीं। केवल HTTPS भरोसेमंद नहीं है: अपने अनुप्रयोग के लिए होस्ट अलॉ WL लिस्ट और अन्य जाँचें जोड़ें। मूल और सामान्यीकृत दोनों बाहरी URL जाँचे जाते हैं। उदाहरण लिंक फ़ॉलो किए बिना या कार्रवाई चलाए बिना मेटाडेटा का ऑडिट करता है।

समाधान के लिए, कंटेनर का [HyperlinkManager](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) [SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/), और [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) को समर्थन देता है। यहाँ, निषिद्ध बाहरी क्लिक लिंक को एक स्थिर HTTPS लैंडिंग पेज से बदल दिया जाता है; अन्य निषिद्ध क्लिक और निषिद्ध माउस‑ओवर कार्रवाई स्वतंत्र रूप से हटाई जाती हैं। सभी नीति उल्लंघनों को हटाने के लिए `replaceExternalClicks` को `false` सेट करें। तैनाती से पहले एक अनुप्रयोग‑स्वामित्व वाला प्रतिस्थापन पेज चुनें।

रिपोर्ट का निर्यात फ़्लैग एक सावधानीपूर्ण PDF समीक्षा नीति का उपयोग करता है: माउस‑ओवर कार्रवाई और बाहरी लिंक या विशिष्ट स्लाइड जंप के अलावा किसी भी चीज़ को संभावित रूप से असमर्थित के रूप में चिह्नित करता है। यह एक समीक्षा संकेत है, न कि क्षमता परीक्षण या यह गारंटी कि बिना चिह्नित लिंक निर्यात में बचेंगे। समर्थित [PDF](/slides/hi/net/convert-powerpoint-to-pdf/) और [HTML](/slides/hi/net/convert-powerpoint-to-html/) निर्यात कार्रवाई, निर्यात विकल्प और दर्शक पर निर्भर करते हुए हाइपरलिंक रख सकते हैं। रास्टर [images](/slides/hi/net/convert-powerpoint-to-png/) और [video](/slides/hi/net/convert-powerpoint-to-video/) इंटरैक्टिव हाइपरलिंक नहीं रख सकते; उन आउटपुट के लिए ऑडिट करते समय प्रत्येक कार्रवाई को चिह्नित करें।

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Aspose.Slides;
using Aspose.Slides.Export;

const bool replaceExternalClicks = true;
const string replacementUrl = "https://example.com/blocked-link";
using var presentation = new Presentation("hyperlink-audit-input.pptx");
var containers = CollectContainers(presentation);
var rows = new List<object>();

for (var index = 0; index < containers.Count; index++)
{
    var container = containers[index];
    AddRow(container.HyperlinkClick, "click", container, index + 1);
    AddRow(container.HyperlinkMouseOver, "mouse-over", container, index + 1);
}

var jsonOptions = new JsonSerializerOptions { WriteIndented = true };
var json = JsonSerializer.Serialize(rows, jsonOptions);
File.WriteAllText("hyperlink-audit.json", json);

foreach (var container in containers)
{
    var click = container.HyperlinkClick;
    if (PolicyViolation(click) != null)
    {
        if (replaceExternalClicks && click.ActionType == HyperlinkActionType.Hyperlink)
        {
            container.HyperlinkManager.SetExternalHyperlinkClick(replacementUrl);
        }
        else
        {
            container.HyperlinkManager.RemoveHyperlinkClick();
        }
    }
    if (PolicyViolation(container.HyperlinkMouseOver) != null)
    {
        container.HyperlinkManager.RemoveHyperlinkMouseOver();
    }
}

presentation.Save("hyperlink-sanitized.pptx", SaveFormat.Pptx);
using var reopened = new Presentation("hyperlink-sanitized.pptx");
var remainingContainers = CollectContainers(reopened);
var violations = 0;
foreach (var container in remainingContainers)
{
    if (PolicyViolation(container.HyperlinkClick) != null) violations++;
    if (PolicyViolation(container.HyperlinkMouseOver) != null) violations++;
}
Console.WriteLine($"Audit rows: {rows.Count}; prohibited actions after reopening: {violations}");
if (violations != 0)
{
    Console.WriteLine("Verification failed: do not distribute the saved presentation.");
    Environment.ExitCode = 1;
}

void AddRow(IHyperlink? link, string activation, IHyperlinkContainer container, int containerId)
{
    if (link == null) return;
    var ownerSlide = (container as ISlideComponent)?.Slide;
    var targetSlide = link.TargetSlide;
    var violation = PolicyViolation(link);
    var ownerType = container is IShape ? "Shape" : container is IPortionFormat ? "Text portion" : container.GetType().Name;
    var ordinaryAction = link.ActionType == HyperlinkActionType.Hyperlink || link.ActionType == HyperlinkActionType.JumpSpecificSlide;
    rows.Add(new
    {
        ContainerId = containerId,
        SlideIndex = SlideIndex(presentation, ownerSlide),
        SlideId = ownerSlide?.SlideId,
        Scope = ownerSlide?.GetType().Name,
        OwnerType = ownerType,
        Activation = activation,
        ActionType = link.ActionType.ToString(),
        ExternalUrl = link.ExternalUrl,
        TargetSlideIndex = SlideIndex(presentation, targetSlide),
        TargetSlideId = targetSlide?.SlideId,
        Tooltip = link.Tooltip,
        OriginalExternalUrl = link.ExternalUrlOriginal != link.ExternalUrl ? link.ExternalUrlOriginal : null,
        PotentiallyUnsafe = violation != null,
        PolicyViolation = violation,
        TargetExport = "PDF",
        PotentiallyUnsupportedByExport = activation == "mouse-over" || !ordinaryAction
    });
}

static int? SlideIndex(IPresentation presentation, IBaseSlide? slide)
{
    for (var index = 0; index < presentation.Slides.Count; index++)
    {
        if (ReferenceEquals(presentation.Slides[index], slide)) return index + 1;
    }
    return null;
}

static string? PolicyViolation(IHyperlink? link)
{
    if (link == null) return null;
    if (link.ActionType == HyperlinkActionType.JumpSpecificSlide)
    {
        return link.TargetSlide == null ? "Missing target slide" : null;
    }
    if (link.ActionType != HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!IsHttps(link.ExternalUrl)) return "Normalized URL is not absolute HTTPS";
    var original = link.ExternalUrlOriginal;
    if (!string.IsNullOrEmpty(original) && !IsHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

static bool IsHttps(string? value)
{
    return Uri.TryCreate(value, UriKind.Absolute, out var uri) && uri.Scheme == Uri.UriSchemeHttps;
}

static List<IHyperlinkContainer> CollectContainers(IPresentation presentation)
{
    var found = new List<IHyperlinkContainer>();
    found.AddRange(presentation.HyperlinkQueries.GetAnyHyperlinks());
    foreach (var master in presentation.Masters) AddScope(master);
    foreach (var layout in presentation.LayoutSlides) AddScope(layout);
    foreach (var slide in presentation.Slides) AddScope(slide.NotesSlideManager.NotesSlide);
    AddScope(presentation.MasterNotesSlideManager.MasterNotesSlide);
    AddScope(presentation.MasterHandoutSlideManager.MasterHandoutSlide);
    return found.Distinct<IHyperlinkContainer>(ReferenceEqualityComparer.Instance).ToList();

    void AddScope(IBaseSlide? slide)
    {
        if (slide != null) found.AddRange(slide.HyperlinkQueries.GetAnyHyperlinks());
    }
}
```

ऊपर बनाए गए इनपुट के साथ, रिपोर्ट में पाँच कार्रवाई पंक्तियाँ होती हैं। फ़ाइल माउस‑ओवर लिंक और मैक्रो क्लिक हटाए जाते हैं, जबकि HTTPS लिंक और आंतरिक स्लाइड नेविगेशन बरकरार रहते हैं। सत्यापन शून्य निषिद्ध कार्रवाई प्रिंट करता है। एक निषिद्ध बाहरी क्लिक URL वाले इनपुट से प्रतिस्थापन शाखा भी सक्रिय होती है। एक अनुमोदित क्लिक वाले कंटेनर में निषिद्ध माउस‑ओवर होने पर उसकी क्लिक कार्रवाई बनी रहती है।

यह चयनात्मक सफाई [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) से अलग है, जो नीति की परवाह किए बिना चयनित स्कोप में दोनों सक्रियता प्रकारों को हटा देती है। यहाँ सत्यापन केवल हाइपरलिंक कार्रवाई की जाँच करता है; यह एम्बेडेड VBA प्रोजेक्ट, OLE ऑब्जेक्ट या अन्य सक्रिय सामग्री को नहीं हटाता, न ही निर्यातित PDF या HTML फ़ाइल की वैधता जांचता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं किसी अनुभाग या उसके पहले स्लाइड से कैसे लिंक करूँ?**

PowerPoint में अनुभाग स्लाइड को समूहित करते हैं, लेकिन आंतरिक हाइपरलिंक व्यक्तिगत स्लाइड को लक्षित करता है। अनुभाग पर नेविगेशन बनाने के लिए, उस अनुभाग की पहली स्लाइड से लिंक करें।

**क्या मैं मास्टर स्लाइड तत्वों पर हाइपरलिंक संलग्न कर सकता हूँ ताकि वह सभी स्लाइड पर कार्य करे?**

हाँ। मास्टर स्लाइड और लेआउट तत्व हाइपरलिंक का समर्थन करते हैं। इन तत्वों पर लिंक उस स्लाइड शो के दौरान उपलब्ध होते हैं जहाँ संबंधित मास्टर या लेआउट प्रयुक्त होता है।

**क्या PDF, HTML, images, या video में निर्यात करते समय हाइपरलिंक संरक्षित रहते हैं?**

समर्थित PDF और HTML निर्यात हाइपरलिंक को संरक्षित कर सकते हैं; रास्टर इमेज और वीडियो नहीं कर सकते। विवरण के लिए देखें [रिपोर्ट, स्वच्छता, और हाइपरलिंक सत्यापित करें](#report-sanitize-and-verify-hyperlinks)।