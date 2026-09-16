---
title: .NET में प्रस्तुति हाइपरलिंक प्रबंधन
linktitle: हाइपरलिंक प्रबंधन
type: docs
weight: 20
url: /hi/net/manage-hyperlinks/
keywords:
- URL जोड़ें
- हाइपरलिंक जोड़ें
- हाइपरलिंक बनाएं
- हाइपरलिंक स्वरूपित करें
- हाइपरलिंक हटाएं
- हाइपरलिंक अपडेट करें
- टेक्स्ट हाइपरलिंक
- स्लाइड हाइपरलिंक
- शेप हाइपरलिंक
- इमेज हाइपरलिंक
- वीडियो हाइपरलिंक
- परिवर्तनीय हाइपरलिंक
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET का उपयोग करके, C# उदाहरणों के साथ PowerPoint और OpenDocument प्रस्तुतियों में हाइपरलिंक जोड़ें, स्वरूपित करें, अपडेट करें और हटाएँ।"
---
## **परिचय**

एक हाइपरलिंक प्रस्तुति की सामग्री को किसी वेबसाइट या प्रस्तुति के भीतर एक स्थान से जोड़ता है। PowerPoint में, हाइपरलिंक आमतौर पर दो प्रयोजनों की सेवा करते हैं:

* पाठ, आकार या मीडिया फ्रेम से वेबसाइट खोलें।
* किसी अन्य स्लाइड पर जाएँ, उदाहरण के लिये, सामग्री तालिका से।

Aspose.Slides for .NET आपको इन लिंक को जोड़ने, उनके स्वरूप और ध्वनि को नियंत्रित करने, उनकी गुणों को अपडेट करने और उन्हें हटाने की सुविधा देता है। नीचे दिए गए उदाहरण दिखाते हैं कि व्यक्तिगत तत्वों पर हाइपरलिंक के साथ कैसे काम करें और प्रस्तुति, स्लाइड, या टेक्स्ट-फ़्रेम स्तर पर हाइपरलिंक तक कैसे पहुँचें।

{{% alert color="info" title="Note" %}}
आप प्रस्तुति को [free online Aspose PowerPoint editor](https://products.aspose.app/slides/hi/editor) के साथ भी संपादित कर सकते हैं।
{{% /alert %}} 

## **URL हाइपरलिंक जोड़ें**

आप टेक्स्ट, आकार या मीडिया फ्रेम को वेबसाइट URL असाइन कर सकते हैं। जिस तत्व पर आप हाइपरलिंक असाइन करते हैं, वह क्लिकेबल क्षेत्र निर्धारित करता है: टेक्स्ट भाग चयनित टेक्स्ट से लिंक करता है, जबकि आकार या फ्रेम स्लाइड ऑब्जेक्ट से लिंक करता है।

### **टेक्स्ट में URL हाइपरलिंक जोड़ें**

टेक्स्ट को वेबसाइट से लिंक करने के लिए, नीचे दिखाए अनुसार टेक्स्ट भाग की [HyperlinkClick](https://reference.aspose.com/slides/hi/net/aspose.slides/portionformat/hyperlinkclick/) प्रॉपर्टी को [Hyperlink](https://reference.aspose.com/slides/hi/net/aspose.slides/hyperlink/) असाइन करें। केवल वह टेक्स्ट भाग क्लिकेबल हो जाएगा।

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

एक आकार या फ्रेम को क्लिकेबल बनाने के लिए, उसकी [HyperlinkClick](https://reference.aspose.com/slides/hi/net/aspose.slides/shape/hyperlinkclick/) प्रॉपर्टी सेट करें। हाइपरलिंक स्वयं ऑब्जेक्ट से जुड़ा होता है, न कि उसके भीतर के टेक्स्ट भाग से।

यह ही तरीका चित्र, ऑडियो और वीडियो फ्रेम पर भी लागू होता है: फ्रेम को हाइपरलिंक असाइन करें और आवश्यक होने पर लिंक की [Tooltip](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink/tooltip/) सेट करें।

निम्न उदाहरण एक आयत को क्लिकेबल बनाता है:

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

आंतरिक हाइपरलिंक पाठकों को सामग्री तालिका से किसी विशिष्ट स्लाइड पर जाने की अनुमति देते हैं। निम्न उदाहरण [SetInternalHyperlinkClick](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) का उपयोग करके पहले स्लाइड पर “Page 2” टेक्स्ट को दूसरी स्लाइड से लिंक करता है।

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

[ColorSource](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink/colorsource/) प्रॉपर्टी जो [IHyperlink](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink/) में है, निर्धारित करती है कि हाइपरलिंक प्रस्तुति के हाइपरलिंक रंग का उपयोग करे या टेक्स्ट भाग का फ़ॉर्मेट। कस्टम टेक्स्ट रंग लागू करने के लिए, [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/hyperlinkcolorsource/) चुनें और भाग के फ़िल रंग को सेट करें। यह सुविधा PowerPoint 2019 में पेश की गई थी; पुराने संस्करण इस सेटिंग को लागू नहीं करते।

निम्न उदाहरण समान स्लाइड में दो टेक्स्ट हाइपरलिंक जोड़ता है। पहला लाल टेक्स्ट फ़िल का उपयोग करता है, जबकि दूसरा डिफ़ॉल्ट हाइपरलिंक रंग बरकरार रखता है।

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

हाइपरलिंक सक्रिय होने पर ध्वनि बजा सकता है या पहले से चल रही ध्वनि को रोक सकता है। इन व्यवहारों को कॉन्फ़िगर करने के लिए निम्न प्रॉपर्टी का उपयोग करें:

- [IHyperlink.Sound](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink/sound/) हाइपरलिंक से जुड़ी ऑडियो को निर्दिष्ट करता है।
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink/stopsoundonclick/) निर्धारित करता है कि हाइपरलिंक सक्रिय करने से पहले की ध्वनि रुक जाए या नहीं।

#### **हाइपरलिंक ध्वनि जोड़ें**

निम्न उदाहरण `sampleaudio.wav` लोड करता है और पहले स्लाइड पर एक बटन के साथ जोड़ता है। बटन पर क्लिक करने से ध्वनि चलती है और अगले स्लाइड पर जाता है। उसी स्लाइड पर दूसरा आकार क्लिक करने पर पूर्व ध्वनि को रोकता है, बिना नेविगेशन कार्रवाई किए।

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

निम्न उदाहरण ऊपर निर्मित प्रस्तुति को खोलता है और पहले आकार की हाइपरलिंक ऑडियो को मेमोरी में [Sound](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink/sound/) और [BinaryData](https://reference.aspose.com/slides/hi/net/aspose.slides/iaudio/binarydata/) के माध्यम से पढ़ता है।

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

टेक्स्ट या आकार को हाइपरलिंक असाइन करने के बाद आप निम्न [IHyperlink](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink/) प्रॉपर्टी को अपडेट कर सकते हैं:

- [Tooltip](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink/tooltip/) लिंक के लिए वही टेक्स्ट सेट करता है जो दर्शक संकेत के रूप में देख सकता है।
- [TargetFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink/targetframe/) पैरें‍ट HTML फ्रेमसेट के भीतर लक्ष्य फ्रेम निर्दिष्ट करता है, जब लागू हो।
- [History](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink/history/) निर्धारित करता है कि लिंक सक्रिय करने से उसका गंतव्य देखी गई हाइपरलिंक सूची में जोड़ा जाए या नहीं।
- [HighlightClick](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink/highlightclick/) निर्धारित करता है कि क्लिक पर हाइपरलिंक को हाइलाइट किया जाए या नहीं।

## **प्रस्तुति से हाइपरलिंक हटाएँ**

[GetAnyHyperlinks](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) का उपयोग करके हाइपरलिंक कंटेनर एकत्र करें, जिसमें टेक्स्ट-भाग लिंक भी शामिल हैं, उन्हें बदलने से पहले। निम्न उदाहरण पहली स्लाइड से दोनों सक्रियण प्रकार हटाता है। केवल एक प्रकार हटाने के लिए, केवल [RemoveHyperlinkClick](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) या [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) को कॉल करें; क्लिक कार्रवाई हटाने से उसका माउस‑ओवर साथी नहीं हटता।

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

बिना शर्त हटाने के लिए, [RemoveAllHyperlinks](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) चयनित स्कोप में एक कॉल में दोनों सक्रियण प्रकारों को हटाता है। चयनित सफाई और मास्टर, लेआउट, और नोट्स को कवर करने के लिए, देखें [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)。

## **पूरा हाइपरलिंक इन्वेंट्री बनाएं**

प्रस्तुति वितरित करने से पहले, उसके इंटरऐक्टिव एक्शन और वेब लिंक का इन्वेंट्री बनाएं। [GetAnyHyperlinks](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) [IHyperlinkContainer](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlinkcontainer/) ऑब्जेक्ट लौटाता है, न कि URL स्ट्रिंग की एक सपाट सूची। प्रत्येक कंटेनर पर दोनों [HyperlinkClick](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) और [HyperlinkMouseOver](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) जांचें। ये स्वतंत्र हैं: एक ही कंटेनर दोनों एक्शन दिखा सकता है, इसलिए पूर्ण रिपोर्ट के लिए कंटेनर पर दो पंक्तियों तक की आवश्यकता हो सकती है।

केवल आकार-स्तर के हाइपरलिंक स्कैन करने से टेक्स्ट भाग से जुड़े लिंक छूट सकते हैं। इसके बजाय उचित स्कोप को क्वेरी करें, और लौटे हुए कंटेनर को रखें ताकि आप बाद में उनके एक्शन को अपडेट या हटा सकें।

### **प्रस्तुति, स्लाइड, और टेक्स्ट-फ़्रेम स्कोप क्वेरी करें**

इंटरफ़ेस [IHyperlinkQueries](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlinkqueries/) को [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseslide/hyperlinkqueries/), और [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/hi/net/aspose.slides/itextframe/hyperlinkqueries/) के माध्यम से उपलब्ध है। प्रत्येक स्कोप समान क्वेरी समर्थन करता है:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) क्लिक एक्शन वाले कंटेनर लौटाता है।
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) माउस‑ओवर एक्शन वाले कंटेनर लौटाता है।
- [GetAnyHyperlinks](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) किसी भी या दोनों एक्शन वाले कंटेनर लौटाता है।

निम्न उदाहरण `hyperlink-audit-input.pptx` बनाता है जिसमें एक बाहरी क्लिक लिंक, एक फ़ाइल माउस‑ओवर लिंक, आंतरिक स्लाइड नेविगेशन, एक टेक्स्ट माउस‑ओवर लिंक, और एक मैक्रो एक्शन शामिल है। यह इन में से किसी भी एक्शन को निष्पादित नहीं करता। वही तीन क्वेरी प्रत्येक स्कोप पर काम करती हैं; गिनती कंटेनरों को दर्शाती है, न कि एक्शन की कुल संख्या। टेक्स्ट-फ़्रेम स्कोप enclosing आकार के अपने लिंक को बाहर रखता है।

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

इस उदाहरण के लिए, प्रस्तुति और स्लाइड क्वेरी क्रमशः तीन क्लिक कंटेनर, दो माउस‑ओवर कंटेनर, और तीन कंटेनर (कोई भी एक्शन) रिपोर्ट करती हैं। टेक्स्ट-फ़्रेम क्वेरी प्रत्येक श्रेणी में एक कंटेनर रिपोर्ट करती है।

### **एक्शन और डेस्टिनेशन वर्गीकृत करें**

एक्शन को उसके डेस्टिनेशन के पहले व्याख्या करने के लिए [IHyperlink.ActionType](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink/actiontype/) का उपयोग करें। [HyperlinkActionType](https://reference.aspose.com/slides/hi/net/aspose.slides/hyperlinkactiontype/) मान वेब नेविगेशन से अधिक को कवर करते हैं:

| मान | ऑडिट के लिए अर्थ |
| --- | --- |
| `Hyperlink` | बाहरी हाइपरलिंक; URL और उसके स्कीम को जांचें। |
| `JumpSpecificSlide` | विशिष्ट स्लाइड पर आंतरिक नेविगेशन। |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | बिल्ट‑इन स्लाइडशो नेविगेशन, स्लाइडशो संदर्भ में हल किया जाता है। |
| `JumpEndShow`, `StartCustomSlideShow` | वर्तमान शो को समाप्त करें या कस्टम शो शुरू करें। |
| `StartMacro` | मैक्रो निष्पादित करें। |
| `StartProgram` | एक प्रोग्राम लॉन्च करें। |
| `OpenFile`, `OpenPresentation` | फ़ाइल या अन्य प्रस्तुति खोलें; वेब URL से अलग समीक्षा करें। |
| `StartStopMedia` | मीडिया प्लेबैक शुरू या रोकें। |
| `NoAction`, `Unknown` | कोई नेविगेशन एक्शन नहीं, या एक अज्ञात एक्शन जो समीक्षा की आवश्यकता है। |

[ExternalUrl](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink/externalurl/) से बाहरी डेस्टिनेशन पढ़ें और [TargetSlide](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink/targetslide/) से विशिष्ट आंतरिक डेस्टिनेशन पढ़ें। आंतरिक एक्शन और बिल्ट‑इन कमांड्स में बाहरी URL नहीं हो सकता; खाली URL का मतलब यह नहीं है कि कंटेनर में कोई एक्शन नहीं है। जब [ExternalUrlOriginal](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink/externalurloriginal/) सामान्यीकृत URL से अलग हो, तो उसे सुरक्षित रखें, और उपलब्ध होने पर [Tooltip](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlink/tooltip/) शामिल करें।

### **हाइपरलिंक रिपोर्ट, सैनिटाइज़, और सत्यापित करें**

निम्न .NET 6+ उदाहरण एक मौजूदा प्रस्तुति पढ़ता है (ऊपर बनाई गई फ़ाइल उपयोग करें), `hyperlink-audit.json` लिखता है, एक नीति लागू करता है, `hyperlink-sanitized.pptx` सहेजता है, और दोनों सक्रियण प्रकारों की फिर से जाँच के लिए इसे पुनः खोलता है। यह बदलने से पहले कंटेनर एकत्र करता है और रेफ़रेंस समानता का उपयोग करके एक ही कंटेनर को दो बार प्रोसेस होने से बचाता है। प्रस्तुति क्वेरी सामान्य स्लाइड को कवर करती है; पैकेज‑व्यापी इन्वेंट्री के लिए, यह स्पष्ट रूप से मास्टर, लेआउट, नोट्स, और मौजूद होने पर नोट्स और हैंडआउट मास्टर को भी क्वेरी करती है।

रिपोर्ट एक-आधारित स्लाइड इंडेक्स और जहाँ उपलब्ध हो [SlideId](https://reference.aspose.com/slides/hi/net/aspose.slides/ibaseslide/slideid/) को रिकॉर्ड करती है। [ISlideComponent.Slide](https://reference.aspose.com/slides/hi/net/aspose.slides/islidecomponent/slide/) समर्थित कंटेनरों के लिए मालिक स्लाइड प्रदान करता है। मास्टर, लेआउट, और नोट्स के पास सामान्य स्लाइड इंडेक्स नहीं होता और उन्हें उनके स्कोप द्वारा पहचाना जाता है। आकार कंटेनर और टेक्स्ट‑भाग फ़ॉर्मेटिंग कंटेनर अलग‑अलग लेबल किए जाते हैं; अन्य कंटेनर प्रकार अपने रन‑टाइम प्रकार नाम को रखते हैं। प्रत्येक कंटेनर को एक रिपोर्ट‑स्थानीय ID मिलती है ताकि उसके दो एक्शन को जोड़ा जा सके।

यह जानबूझकर प्रतिबंधित एप्लिकेशन नीति केवल पूर्ण HTTPS URL और वैध आंतरिक स्लाइड टार्गेट की अनुमति देती है। यह मैक्रो, प्रोग्राम, फ़ाइल एक्शन, अन्य स्लाइडशो एक्शन, अज्ञात एक्शन और अन्य URL योजनाओं को अस्वीकार करता है। ये अस्वीकृतियाँ नीति निर्णय हैं, Aspose.Slides सुरक्षा निर्णय नहीं। केवल HTTPS भरोसा स्थापित नहीं करता: अपने एप्लिकेशन के लिये होस्ट एलाउलिस्ट और अन्य जांचें जोड़ें। मूल और सामान्यीकृत दोनों बाहरी URL जांचे जाते हैं। उदाहरण बिना लिंक के अनुसरण या एक्शन 실행 किए मेटाडेटा का ऑडिट करता है।

सुधार के लिए, कंटेनर का [HyperlinkManager](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) [SetExternalHyperlinkClick](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/), और [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) का समर्थन करता है। यहाँ, प्रतिबंधित बाहरी क्लिक लिंक को एक नियत HTTPS लैंडिंग पेज से बदला गया है; अन्य प्रतिबंधित क्लिक और प्रतिबंधित माउस‑ओवर एक्शन स्वतंत्र रूप से हटाए गए हैं। सभी नीति उल्लंघनों को हटाने के लिये `replaceExternalClicks` को `false` सेट करें। डिप्लॉयमेंट से पहले एक एप्लिकेशन‑स्वामित्व वाला प्रतिस्थापन पेज चुनें।

रिपोर्ट का एक्सपोर्ट फ्लैग एक रूढ़िवादी PDF समीक्षा नीति का उपयोग करता है: माउस‑ओवर एक्शन और बाहरी लिंक या विशिष्ट स्लाइड जंप के अलावा किसी भी चीज़ को संभावित रूप से असमर्थित के रूप में फ़्लैग करें। यह एक समीक्षा संकेत है, न कि क्षमता परीक्षण या यह गारंटी कि अनफ़्लैग्ड लिंक एक्सपोर्ट में बचेंगे। समर्थित [PDF](/slides/hi/net/convert-powerpoint-to-pdf/) और [HTML](/slides/hi/net/convert-powerpoint-to-html/) एक्सपोर्ट हाइपरलिंक को संरक्षित कर सकते हैं, एक्शन, एक्सपोर्ट विकल्प और व्यूअर पर निर्भर करता है। रास्टर [images](/slides/hi/net/convert-powerpoint-to-png/) और [video](/slides/hi/net/convert-powerpoint-to-video/) इंटरएक्टिव हाइपरलिंक को संरक्षित नहीं कर सकते; इन आउटपुट के लिए ऑडिट करते समय प्रत्येक एक्शन को फ़्लैग करें।

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

ऊपर बनाए गए इनपुट के साथ, रिपोर्ट में पाँच एक्शन पंक्तियाँ हैं। फ़ाइल माउस‑ओवर लिंक और मैक्रो क्लिक हटाए गए हैं, जबकि HTTPS लिंक और आंतरिक स्लाइड नेविगेशन बना रहता है। सत्यापन शून्य प्रतिबंधित एक्शन प्रिंट करता है। प्रतिबंधित बाहरी क्लिक URL वाले इनपुट से प्रतिस्थापन शाखा भी सक्रिय होती है। अनुमति प्राप्त क्लिक और प्रतिबंधित माउस‑ओवर वाला कंटेनर अपना क्लिक एक्शन रखता है।

यह चयनात्मक सफाई [RemoveAllHyperlinks](https://reference.aspose.com/slides/hi/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) से अलग है, जो नीति की परवाह किए बिना चयनित स्कोप में दोनों सक्रियण प्रकारों को हटाता है। यहाँ सत्यापन केवल हाइपरलिंक एक्शन को जांचता है; यह एम्बेडेड VBA प्रोजेक्ट, OLE ऑब्जेक्ट या अन्य सक्रिय सामग्री को हटाता नहीं है, और न ही निर्यात किए गए PDF या HTML फ़ाइल को वैध करता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं सेक्शन या उसके पहले स्लाइड से कैसे लिंक करूँ?**

PowerPoint में सेक्शन स्लाइड को समूहित करते हैं, लेकिन आंतरिक हाइपरलिंक व्यक्तिगत स्लाइड को लक्ष्य बनाता है। सेक्शन में नेविगेशन बनाने के लिए, उस सेक्शन की पहली स्लाइड से लिंक करें।

**क्या मैं मास्टर स्लाइड तत्वों पर हाइपरलिंक लगा सकता हूँ ताकि यह सभी स्लाइड पर काम करे?**

हाँ। मास्टर स्लाइड और लेआउट तत्व हाइपरलिंक का समर्थन करते हैं। इन तत्वों पर मौजूद लिंक उन स्लाइड शो के दौरान उपलब्ध होते हैं जो संबंधित मास्टर या लेआउट का उपयोग करते हैं।

**PDF, HTML, छवियों या वीडियो में निर्यात करने पर क्या हाइपरलिंक संरक्षित रहेंगे?**

समर्थित PDF और HTML एक्सपोर्ट हाइपरलिंक को संरक्षित कर सकते हैं; रास्टर छवियां और वीडियो नहीं रख सकते। देखें एक्सपोर्ट विचार [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)。