---
title: Aspose.Slides for .NET
second_title: Aspose.Slides for .NET
type: docs
weight: 10
url: /hi/net/
keywords:
- दस्तावेज़ीकरण
- प्रस्तुतिकरण प्रक्रिया
- प्रस्तुतिकरण रूपांतरण
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "यहाँ से शुरू करें: Aspose.Slides for .NET इंस्टॉल करें, पहली प्रस्तुति बनाएं, और सामान्य कार्यों, API संदर्भ और समर्थन के लिए मार्गदर्शिकाएँ खोजें."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for .NET" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for .NET .NET एप्लिकेशन में PowerPoint और OpenDocument प्रस्तुतियों को बनाने, पढ़ने, संपादित करने और परिवर्तित करने के लिए एक क्लास लाइब्रेरी है, बिना Microsoft PowerPoint या Office Automation के।

यह PPT, PPTX, PPS, POT और ODP को लोड और सहेजता है, जिसमें मैक्रो‑सक्षम और टेम्पलेट संस्करण शामिल हैं, और PDF, XPS, HTML, SVG, TIFF, Markdown और छवियों में निर्यात करता है।

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>आरंभ करें</b></p>
<hr>
<p>शुरूआत</p>
<ul>
<li><a href="/slides/hi/net/installation/">इंस्टॉलेशन</a></li>
<li><a href="/slides/hi/net/create-presentation/">अपना पहला प्रस्तुतिकरण बनाएं</a></li>
<li><a href="/slides/hi/net/getting-started/">शुरूआत गाइड</a></li>
</ul>
<p>मूल्यांकन</p>
<ul>
<li><a href="/slides/hi/net/supported-file-formats/">समर्थित फ़ाइल स्वरूप</a></li>
<li><a href="/slides/hi/net/evaluate-aspose-slides/">ट्रायल सीमाएँ</a></li>
<li><a href="/slides/hi/net/licensing/">लाइसेंसिंग</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Slides के साथ बनाएं</b></p>
<hr>
<p>सामान्य कार्य</p>
<ul>
<li><a href="/slides/hi/net/open-presentation/">प्रस्तुति खोलें</a></li>
<li><a href="/slides/hi/net/save-presentation/">प्रस्तुति सहेजें</a></li>
<li><a href="/slides/hi/net/convert-powerpoint-to-pdf/">PDF में परिवर्तित करें</a></li>
<li><a href="/slides/hi/net/convert-slide/">स्लाइड को छवियों के रूप में रेंडर करें</a></li>
<li><a href="/slides/hi/net/manage-text/">पाठ और आकार संपादित करें</a></li>
</ul>
<p>Slides कार्यप्रवाह</p>
<ul>
<li><a href="/slides/hi/net/powerpoint-charts/">चार्ट</a></li>
<li><a href="/slides/hi/net/powerpoint-animation/">एनिमेशन</a></li>
<li><a href="/slides/hi/net/manage-media-files/">ऑडियो और वीडियो</a></li>
<li><a href="/slides/hi/net/presentation-design/">स्लाइड डिज़ाइन</a></li>
<li><a href="/slides/hi/net/merge-presentation/">प्रस्तुतियों को मिलाएं</a></li>
</ul>
<p>उदाहरण</p>
<ul>
<li><a href="/slides/hi/net/examples/">स्लाइड तत्व द्वारा उदाहरण</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-.NET">GitHub पर उदाहरण</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>संदर्भ और समर्थन</b></p>
<hr>
<p>संदर्भ</p>
<ul>
<li><a href="https://reference.aspose.com/slides/hi/net/">API संदर्भ</a></li>
<li><a href="https://releases.aspose.com/slides/hi/net/release-notes/">रिलीज़ नोट्स</a></li>
<li><a href="/slides/hi/net/known-issues/">ज्ञात समस्याएँ</a></li>
<li><a href="https://releases.aspose.com/slides/hi/net/">डाउनलोड</a></li>
</ul>
<p>समर्थन</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/hi/11">मुक्त समर्थन फ़ोरम</a></li>
<li><a href="https://helpdesk.aspose.com/">भुगतान किया गया समर्थन हेल्पडेस्क</a></li>
</ul>
</div>
</div>

------

## **आपकी पहली प्रस्तुति**

.NET SDK 6 या बाद के संस्करण के साथ एक कंसोल एप्लिकेशन बनाएं:

```bash
dotnet new console -n HelloSlides
cd HelloSlides
```

फिर अपने प्लेटफ़ॉर्म के लिए एक पैकेज जोड़ें:

- On Windows: `dotnet add package Aspose.Slides.NET`
- On Linux and macOS: `dotnet add package Aspose.Slides.NET6.CrossPlatform` — see [Installation](/slides/hi/net/installation/) for the Linux prerequisite and for the systems that need Aspose.Slides.NET instead.

इस कोड के साथ *Program.cs* की सामग्री बदलें और `dotnet run` चलाएँ:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
shape.TextFrame.Text = "Hello, Aspose.Slides!";
presentation.Save("hello.pptx", SaveFormat.Pptx);
```

प्रोग्राम *hello.pptx* को एक स्लाइड के साथ सहेजता है, जिसमें एक टेक्स्ट बॉक्स होता है। बिना लाइसेंस के, सहेजी गई फ़ाइल में मूल्यांकन वॉटरमार्क होता है — देखें [लाइसेंसिंग](/slides/hi/net/licensing/). अधिक तरीकों से प्रस्तुति बनाने और भरने के लिए, देखें [प्रस्तुति बनाएं](/slides/hi/net/create-presentation/).