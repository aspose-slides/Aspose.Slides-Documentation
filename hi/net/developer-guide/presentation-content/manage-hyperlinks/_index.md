---
title: .NET में प्रस्तुति हाइपरलिंक प्रबंधित करें
linktitle: हाइपरलिंक प्रबंधित करें
type: docs
weight: 20
url: /hi/net/manage-hyperlinks/
keywords:
- URL जोड़ें
- हाइपरलिंक जोड़ें
- हाइपरलिंक बनाएं
- हाइपरलिंक का स्वरूप
- हाइपरलिंक हटाएँ
- हाइपरलिंक अपडेट करें
- टेक्स्ट हाइपरलिंक
- स्लाइड हाइपरलिंक
- आकार हाइपरलिंक
- छवि हाइपरलिंक
- वीडियो हाइपरलिंक
- परिवर्तनीय हाइपरलिंक
- PowerPoint
- OpenDocument
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET के साथ PowerPoint और OpenDocument प्रस्तुतियों में हाइपरलिंक जोड़ें, स्वरूपित करें, अपडेट करें और हटाएँ, C# उदाहरणों का उपयोग करके।"
---
## **परिचय**

हाइपरलिंक प्रस्तुति सामग्री को एक वेबसाइट या प्रस्तुति के भीतर के किसी स्थान से जोड़ता है। PowerPoint में, हाइपरलिंक आमतौर पर दो उद्देश्यों की पूर्ति करते हैं:

* पाठ, आकार, या मीडिया फ्रेम से वेबसाइट खोलें।
* एक अन्य स्लाइड पर जाएँ, उदाहरण के लिए, तालिका‑सामग्री से।

Aspose.Slides for .NET आपको इन लिंक को जोड़ने, उनके दिखावे और ध्वनि को नियंत्रित करने, उनके गुणों को अपडेट करने और उन्हें हटाने की सुविधा देता है। नीचे दिए गए उदाहरण दिखाते हैं कि व्यक्तिगत तत्वों पर हाइपरलिंक कैसे काम किया जाता है और प्रस्तुति, स्लाइड, या टेक्स्ट‑फ़्रेम स्तर पर हाइपरलिंक तक कैसे पहुँचा जाता है।

{{% alert color="info" title="Note" %}}
आप प्रस्तुतियों को [मुक्त ऑनलाइन Aspose PowerPoint संपादक](https://products.aspose.app/slides/editor) के साथ भी संपादित कर सकते हैं।
{{% /alert %}}

## **URL हाइपरलिंक जोड़ें**

आप टेक्स्ट, आकार, या मीडिया फ्रेम को एक वेबसाइट URL असाइन कर सकते हैं। जिस तत्व को आप हाइपरलिंक असाइन करते हैं, वह क्लिक करने योग्य क्षेत्र निर्धारित करता है: टेक्स्ट भाग चयनित टेक्स्ट को लिंक करता है, जबकि आकार या फ्रेम स्लाइड ऑब्जेक्ट को लिंक करता है।

सापेक्ष हाइपरलिंक वाली प्रस्तुतियों के लिए, [हाइपरलिंक बेस प्रबंधित करें](/slides/hi/net/presentation-properties/#manage-the-hyperlink-base) देखें ताकि आप दस्तावेज़‑स्तर के बेस को पढ़, बदल या साफ़ कर सकें।

### **URL हाइपरलिंक को टेक्स्ट में जोड़ें**

टेक्स्ट को वेबसाइट से लिंक करने के लिए, नीचे दिखाए अनुसार टेक्स्ट भाग की [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/portionformat/hyperlinkclick/) प्रॉपर्टी को एक [Hyperlink](https://reference.aspose.com/slides/net/aspose.slides/hyperlink/) असाइन करें। केवल वह टेक्स्ट भाग क्लिक योग्य बन जाता है।

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

### **Shapes और Media Frames में URL हाइपरलिंक जोड़ें**

आयत के [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/shape/hyperlinkclick/) प्रॉपर्टी को एक URL असाइन करने से उसकी पूरी सतह क्लिक करने योग्य हो जाती है। जब पाठक आयत के ऊपर होवर करते हैं तो [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) गंतव्य के बारे में संकेत देता है। ये ही प्रॉपर्टी चित्र, ऑडियो और वीडियो फ्रेम पर भी लागू होते हैं।

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();

var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

shape.HyperlinkClick = new Hyperlink("https://www.aspose.com/");
shape.HyperlinkClick.Tooltip = "Explore Aspose file format APIs";

presentation.Save("presentation-out.pptx", SaveFormat.Pptx);
```

## **हाइपरलिंक का उपयोग करके तालिका सामग्री बनाएं**

आंतरिक हाइपरलिंक पाठकों को तालिका‑सामग्री से एक विशिष्ट स्लाइड पर कूदने देते हैं। निम्न उदाहरण [SetInternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setinternalhyperlinkclick/) का उपयोग करके पहली स्लाइड के “Page 2” टेक्स्ट को दूसरी स्लाइड से लिंक करता है।

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

## **हाइपरलिंक का स्वरूप**

आप लिंक किए गए टेक्स्ट का रंग बदल सकते हैं, जब पाठक लिंक को सक्रिय करता है तो ध्वनि चलाने या रोकने का प्रबंधन कर सकते हैं, तथा होवर करने पर दिखने वाले टूलटिप को सेट कर सकते हैं।

### **रंग**

[IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) की [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) प्रॉपर्टी निर्धारित करती है कि हाइपरलिंक प्रस्तुति के हाइपरलिंक रंग या टेक्स्ट भाग के फ़ॉर्मेट को उपयोग करे। कस्टम टेक्स्ट रंग लागू करने के लिए, [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkcolorsource/) चुनें और भाग का फ़िल रंग सेट करें। यह सुविधा PowerPoint 2019 में प्रस्तुत की गई थी; पुराने संस्करण इस सेटिंग को लागू नहीं करते।

इस उदाहरण में, पहले लिंक पर [ColorSource](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/colorsource/) सेट करने से उसका टेक्स्ट लाल दिखाई देता है। दूसरा लिंक प्रस्तुति के हाइपरलिंक रंग को बरकरार रखता है।

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

एक हाइपरलिंक सक्रिय होने पर ध्वनि चला सकता है या पहले से चल रही ध्वनि को रोक सकता है। इन व्यवहारों को कॉन्फ़िगर करने के लिए निम्न प्रॉपर्टी का उपयोग करें:

- [IHyperlink.Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) हाइपरलिंक से जुड़ी ऑडियो को निर्दिष्ट करता है।
- [IHyperlink.StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) नियंत्रित करता है कि हाइपरलिंक सक्रिय करने पर पहले की ध्वनि रोक दी जाए या नहीं।

#### **हाइपरलिंक ध्वनि जोड़ें**

पहली स्लाइड पर बटन [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) का उपयोग करके जब पाठक आगे बढ़ने के लिये क्लिक करता है तो WAV फ़ाइल से ऑडियो चलाता है। दूसरी स्लाइड पर, एक अलग बटन [StopSoundOnClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/stopsoundonclick/) का उपयोग करके प्लेबैक रोकता है और पाठक को उसी स्लाइड पर रखता है।

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

निम्न उदाहरण ऊपर बनाई गई प्रस्तुति को खोलता है और पहले आकार की हाइपरलिंक ऑडियो को मेमोरी में [Sound](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/sound/) और [BinaryData](https://reference.aspose.com/slides/net/aspose.slides/iaudio/binarydata/) के माध्यम से पढ़ता है।

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

टेक्स्ट या आकार को हाइपरलिंक असाइन करने के बाद आप निम्न [IHyperlink](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/) प्रॉपर्टी को अपडेट कर सकते हैं:

- [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) वह टेक्स्ट सेट करता है जो दर्शक लिंक के लिए संकेत के रूप में दिखा सकता है।
- [TargetFrame](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetframe/) लागू होने पर पैरेंट HTML फ्रेमसेट के भीतर लक्ष्य फ्रेम निर्दिष्ट करता है।
- [History](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/history/) नियंत्रित करता है कि लिंक सक्रिय करने पर उसके गंतव्य को देखे गए हाइपरलिंक की सूची में जोड़ना है या नहीं।
- [HighlightClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/highlightclick/) नियंत्रित करता है कि क्लिक करने पर हाइपरलिंक हाइलाइट हो या नहीं।

## **प्रस्तुतियों से हाइपरलिंक हटाएँ**

[GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) का उपयोग करके हाइपरलिंक कंटेनर, जिनमें टेक्स्ट‑भाग के लिंक भी शामिल हैं, को बदलने से पहले इकट्ठा करें। निम्न उदाहरण पहली स्लाइड से दोनों सक्रियता प्रकार हटाता है। केवल एक प्रकार हटाने के लिए, केवल [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) या [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) को कॉल करें; क्लिक कार्रवाई हटाने से उसके माउस‑ओवर समकक्ष नहीं हटता।

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

निर्बाध हटाने के लिए, [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) चयनित स्कोप में एक कॉल में दोनों सक्रियता प्रकार हटाता है। चयनात्मक सफ़ाई और मास्टर, लेआउट और नोट्स को कवर करने के लिये, देखें [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks)।

### **स्मार्टआर्ट टेक्स्ट बदलने से पहले हाइपरलिंक साफ़ करें**

जब आप मौजूदा SmartArt नोड में एक पैराग्राफ बदलते हैं, तो उसके टेक्स्ट भागों को साफ़ करने से पुराना हाइपरलिंक प्रभावी रह सकता है। पैराग्राफ को [ISmartArtNode.TextFrame](https://reference.aspose.com/slides/net/aspose.slides.smartart/ismartartnode/textframe/) के माध्यम से प्राप्त करें। उसके भागों को साफ़ करने से पहले, उस नोड आकार के टेक्स्ट फ्रेम पर [HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/) के माध्यम से [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) को कॉल करें जो पैराग्राफ प्रदर्शित करता है। यह फ्रेम में सभी हाइपरलिंक हटा देता है, उसमें अन्य पैराग्राफों के लिंक भी शामिल हैं।

उदाहरण यह मानता है कि पहली स्लाइड पर तीसरा आकार SmartArt ग्राफ़िक है। यह चौथे नोड के पहला पैराग्राफ बदलता है। इस प्रस्तुति में, नोड का पहला आकार वह पैराग्राफ प्रदर्शित करता है।

दोनों भाग जोड़ने के बाद, उदाहरण [GetEffective](https://reference.aspose.com/slides/net/aspose.slides/iportionformat/geteffective/) के साथ उनके प्रभावी फ़ॉर्मेट को पढ़ता है। प्रभावी [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/iportionformateffectivedata/hyperlinkclick/) प्रॉपर्टी पहले भाग के लिए नया हाइपरलिंक और दूसरे के लिए `null` लौटाता है।

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.SmartArt;

using var presentation = new Presentation("SmartArtHyperlink.pptx");
var slide = presentation.Slides[0];

var smartArt = (ISmartArt)slide.Shapes[2];
var node = smartArt.AllNodes[3];
var paragraph = node.TextFrame.Paragraphs[0];

node.Shapes[0].TextFrame.HyperlinkQueries.RemoveAllHyperlinks();
paragraph.Portions.Clear();

var link = new Portion("New reference");
link.PortionFormat.HyperlinkClick = new Hyperlink("https://example.com/new");
paragraph.Portions.Add(link);
var text = new Portion(" (updated)");
paragraph.Portions.Add(text);

Console.WriteLine(link.PortionFormat.GetEffective().HyperlinkClick.ExternalUrl); // https://example.com/new
Console.WriteLine(text.PortionFormat.GetEffective().HyperlinkClick?.ToString() ?? "null"); // null
```

## **एक पूर्ण हाइपरलिंक इन्वेंट्री बनाएं**

प्रस्तुति वितरित करने से पहले, उसकी इंटरैक्टिव क्रियाओं और वेब लिंक की सूची बनाएं। [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) [IHyperlinkContainer](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/) ऑब्जेक्ट लौटाता है, न कि URL स्ट्रिंग की सीधी सूची। प्रत्येक कंटेनर पर दोनों [HyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkclick/) और [HyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmouseover/) को निरीक्षण करें। वे स्वतंत्र हैं: वही कंटेनर दोनों क्रियाएँ दे सकता है, इसलिए पूर्ण रिपोर्ट में प्रत्येक कंटेनर के लिए दो पंक्तियों तक की आवश्यकता हो सकती है।

### **प्रस्तुति, स्लाइड, और टेक्स्ट‑फ़्रेम स्कोप को क्वेरी करें**

[IHyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/) इंटरफ़ेस [IPresentation.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ipresentation/hyperlinkqueries/), [IBaseSlide.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/hyperlinkqueries/), तथा [ITextFrame.HyperlinkQueries](https://reference.aspose.com/slides/net/aspose.slides/itextframe/hyperlinkqueries/) के माध्यम से उपलब्ध है। प्रत्येक स्कोप समान क्वेरीज़ को सपोर्ट करता है:

- [GetHyperlinkClicks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkclicks/) उन कंटेनरों को लौटाता है जिनमें क्लिक कार्रवाई होती है।
- [GetHyperlinkMouseOvers](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/gethyperlinkmouseovers/) उन कंटेनरों को लौटाता है जिनमें माउस‑ओवर कार्रवाई होती है।
- [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) उन कंटेनरों को लौटाता है जिनमें कोई भी या दोनों कार्रवाई होती है।

इस उदाहरण में एक आकार और उसके टेक्स्ट को क्लिक और माउस‑ओवर कार्रवाई असाइन की गई है, तथा एक अलग बटन को मैक्रो कार्रवाई। यह [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) द्वारा लौटाए गए कंटेनरों की तुलना प्रत्येक सक्रियता प्रकार की गिनती से करता है। टेक्स्ट‑फ़्रेम क्वेरी केवल टेक्स्ट में लिंक गिनती है। सम्मिलित आकार की अपनी कार्रवाइयाँ स्लाइड और प्रस्तुतियों की क्वेरी में दिखाई देती हैं।

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

इस उदाहरण में, प्रस्तुति और स्लाइड क्वेरी प्रत्येक तीन क्लिक कंटेनर, दो माउस‑ओवर कंटेनर, और तीन कंटेनर जो कोई भी कार्रवाई रखते हैं, रिपोर्ट करती हैं। टेक्स्ट‑फ़्रेम क्वेरी प्रत्येक श्रेणी में एक कंटेनर रिपोर्ट करती है।

### **क्रियाओं और गंतव्यों को वर्गीकृत करें**

[IHyperlink.ActionType](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/actiontype/) का उपयोग करके आप कार्रवाई को उसके गंतव्य को समझने से पहले व्याख्या कर सकते हैं। [HyperlinkActionType](https://reference.aspose.com/slides/net/aspose.slides/hyperlinkactiontype/) मान वेब नेविगेशन से अधिक कवर करते हैं:

| मान | ऑडिट के लिए अर्थ |
| --- | --- |
| `Hyperlink` | बाह्य हाइपरलिंक; URL और उसके स्कीम की जाँच करें। |
| `JumpSpecificSlide` | एक विशिष्ट स्लाइड पर आंतरिक नेविगेशन। |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | बिल्ट‑इन स्लाइडशो नेविगेशन, स्लाइडशो संदर्भ में हल किया जाता है। |
| `JumpEndShow`, `StartCustomSlideShow` | वर्तमान शो को समाप्त करें या कस्टम शो शुरू करें। |
| `StartMacro` | मैक्रो चलाएँ। |
| `StartProgram` | एक प्रोग्राम लॉन्च करें। |
| `OpenFile`, `OpenPresentation` | फ़ाइल या अन्य प्रस्तुति खोलें; वेब URLs से अलग समीक्षा करें। |
| `StartStopMedia` | मीडिया प्लेबैक शुरू या रोकें। |
| `NoAction`, `Unknown` | कोई नेविगेशन कार्रवाई नहीं, या एक अप्रत्याशित कार्रवाई जिसके लिए समीक्षा आवश्यक है। |

[ExternalUrl](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurl/) से बाहरी गंतव्य पढ़ें और [TargetSlide](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/targetslide/) से विशिष्ट आंतरिक गंतव्य। आंतरिक कार्रवाइयों और बिल्ट‑इन कमांड्स में बाहरी URL नहीं हो सकता; खाली URL का अर्थ यह नहीं है कि कंटेनर में कोई क्रिया नहीं है। जब [ExternalUrlOriginal](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/externalurloriginal/) सामान्यीकृत URL से भिन्न हो तो उसे सुरक्षित रखें, और उपलब्ध होने पर [Tooltip](https://reference.aspose.com/slides/net/aspose.slides/ihyperlink/tooltip/) शामिल करें।

### **हाइपरलिंक की रिपोर्ट, साफ‑सफ़ाई, और सत्यापन**

यह .NET 6+ उदाहरण ऊपर के उदाहरण से प्रस्तुति खोलता है और प्रत्येक कार्रवाई के लिए एक JSON रिकॉर्ड लिखता है। यह [GetAnyHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/getanyhyperlinks/) का उपयोग करके सामान्य स्लाइड, मास्टर, लेआउट और नोट्स, तथा उपस्थित नोट्स और हैंडआउट मास्टर पर कंटेनर एकत्र करता है। यह रेफ़रेंस समानता से प्रत्येक कंटेनर को एक बार गिनता है, नीचे वर्णित नीति लागू करता है, और सहेजी गई प्रस्तुति को फिर से खोलकर दोनों क्लिक और माउस‑ओवर कार्रवाई की जाँच करता है।

रिपोर्ट में उपलब्ध होने पर एक‑आधारित स्लाइड इंडेक्स और [SlideId](https://reference.aspose.com/slides/net/aspose.slides/ibaseslide/slideid/) दर्ज किया जाता है। [ISlideComponent.Slide](https://reference.aspose.com/slides/net/aspose.slides/islidecomponent/slide/) समर्थित कंटेनरों के स्वामित्व वाली स्लाइड प्रदान करता है। मास्टर, लेआउट और नोट्स के पास सामान्य स्लाइड इंडेक्स नहीं होता और उन्हें उनके स्कोप से पहचाना जाता है। आकार कंटेनर और टेक्स्ट‑भाग फ़ॉर्मेट कंटेनर अलग‑अलग लेबल होते हैं; अन्य कंटेनर प्रकार अपना रनटाइम टाइप नाम रखते हैं। प्रत्येक कंटेनर को रिपोर्ट‑लोकल आईडी दी जाती है ताकि उसकी दो कार्रवाइयों को जोड़ा जा सके।

यह जानबूझकर प्रतिबंधात्मक एप्लिकेशन नीति केवल पूर्ण HTTPS URLs और मान्य आंतरिक स्लाइड लक्ष्य को ही अनुमति देती है। यह मैक्रो, प्रोग्राम, फ़ाइल कार्रवाइयों, अन्य स्लाइडशो कार्रवाइयों, अज्ञात कार्रवाइयों और अन्य URL स्कीम को अस्वीकार करती है। ये अस्वीकृतियां नीति निर्णय हैं, Aspose.Slides सुरक्षा निर्णय नहीं। केवल HTTPS भरोसा नहीं बनाता: अपने एप्लिकेशन के लिए होस्ट अलाउ‑लिस्ट और अन्य जाँचें जोड़ें। मूल और सामान्यीकृत दोनों बाहरी URLs की जाँच की जाती है। उदाहरण लिंक का अनुसरण किए बिना या कार्रवाइयों को चलाए बिना मेटाडेटा का ऑडिट करता है।

समाधान के लिए, कंटेनर का [HyperlinkManager](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkcontainer/hyperlinkmanager/) [SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), [RemoveHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkclick/) और [RemoveHyperlinkMouseOver](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/removehyperlinkmouseover/) का समर्थन करता है। यहाँ, प्रतिबंधित बाहरी क्लिक लिंक को एक निश्चित HTTPS लैंडिंग पेज से बदला जाता है; अन्य प्रतिबंधित क्लिक और प्रतिबंधित माउस‑ओवर कार्रवाई स्वतंत्र रूप से हटाई जाती हैं। सभी नीति उल्लंघनों को हटाने के लिये `replaceExternalClicks` को `false` सेट करें। डिप्लॉयमेंट से पहले एप्लिकेशन‑स्वामित्व वाले प्रतिस्थापन पेज का चयन करें।

रिपोर्ट का एक्सपोर्ट फ़्लैग एक रूढ़िवादी PDF समीक्षा नीति का उपयोग करता है: माउस‑ओवर कार्रवाइयों तथा बाहरी लिंक या विशिष्ट स्लाइड जंप के अलावा किसी भी चीज़ को संभावित असमर्थित के रूप में फ़्लैग करता है। यह एक समीक्षा संकेत है, न कि क्षमता परीक्षण या यह गारंटी कि अनफ़्लैग किए गए लिंक एक्सपोर्ट में बरकरार रहेंगे। समर्थित [PDF](/slides/hi/net/convert-powerpoint-to-pdf/) और [HTML](/slides/hi/net/convert-powerpoint-to-html/) एक्सपोर्ट हाइपरलिंक को संरक्षित कर सकते हैं, जो कार्रवाई, एक्सपोर्ट विकल्प और व्यूअर पर निर्भर करता है। रास्टर [images](/slides/hi/net/convert-powerpoint-to-png/) और [video](/slides/hi/net/convert-powerpoint-to-video/) इंटरैक्टिव हाइपरलिंक को संरक्षित नहीं कर सकते; उन आउटपुट्स के ऑडिट करते समय प्रत्येक कार्रवाई को फ़्लैग करें।

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

ऊपर बनाए गए इनपुट के साथ, रिपोर्ट में पाँच कार्रवाई पंक्तियां होती हैं। फ़ाइल माउस‑ओवर लिंक और मैक्रो क्लिक हटाए गए हैं, जबकि HTTPS लिंक और आंतरिक स्लाइड नेविगेशन बने रहते हैं। सत्यापन शून्य प्रतिबंधित कार्रवाई प्रदर्शित करता है। प्रतिबंधित बाहरी क्लिक URL वाले इनपुट से प्रतिस्थापन शाखा भी चलती है। अनुमत क्लिक और प्रतिबंधित माउस‑ओवर वाले कंटेनर का क्लिक कार्रवाई बना रहता है।

यह चयनात्मक सफ़ाई [RemoveAllHyperlinks](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkqueries/removeallhyperlinks/) से अलग है, जो नीति की परवाह किए बिना चयनित स्कोप में दोनों सक्रियता प्रकार हटाता है। यहाँ का सत्यापन केवल हाइपरलिंक कार्रवाईयों की जाँच करता है; यह एम्बेडेड VBA प्रोजेक्ट, OLE ऑब्जेक्ट या अन्य सक्रिय सामग्री को नहीं हटाता, और न ही निर्यातित PDF या HTML फ़ाइल को वैध करता है।

## **अक्सर पूछे जाने वाले प्रश्न**

**मैं सेक्शन या उसकी पहली स्लाइड से कैसे लिंक कर सकता हूँ?**

PowerPoint में सेक्शन स्लाइडों को समूहित करते हैं, लेकिन आंतरिक हाइपरलिंक व्यक्तिगत स्लाइड को लक्षित करता है। सेक्शन पर नेविगेशन बनाने के लिए, उस सेक्शन की पहली स्लाइड से लिंक करें।

**क्या मैं मास्टर स्लाइड तत्वों पर हाइपरलिंक जोड़ सकता हूँ ताकि वह सभी स्लाइडों में काम करे?**

हाँ। मास्टर स्लाइड और लेआउट तत्व हाइपरलिंक को समर्थन देते हैं। इन तत्वों पर लिंक उस स्लाइड शो में उपलब्ध होते हैं जहाँ संबंधित मास्टर या लेआउट का उपयोग किया गया हो।

**क्या PDF, HTML, इमेज या वीडियो में एक्सपोर्ट करते समय हाइपरलिंक संरक्षित रहेंगे?**

समर्थित PDF और HTML एक्सपोर्ट हाइपरलिंक को संरक्षित कर सकते हैं; रास्टर इमेज और वीडियो नहीं कर सकते। अधिक विवरण के लिये [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks) देखें।