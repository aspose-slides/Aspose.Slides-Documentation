---
title: ".NET में नोट्स पेज का आकार और अभिविन्यास बदलें"
linktitle: "नोट्स पेज आकार"
type: docs
weight: 10
url: /hi/net/notes-size/
keywords:
- नोट्स पेज आकार
- नोट्स अभिविन्यास
- लैंडस्केप नोट्स
- पोर्ट्रेट नोट्स
- हैंडआउट आकार
- PowerPoint
- प्रस्तुति
- PPT
- PPTX
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET में नोट्स पेज के आयाम पढ़ें और बदलें, अभिविन्यास बदलें, सहेजे गए आकारों की पुष्टि करें, और नोट्स या हैंडआउट को PDF और छवियों में निर्यात करें।"
---
## **अवलोकन**

[Presentation.NotesSize](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/notessize/) का उपयोग करके प्रस्तुति की नोट्स पृष्ठ सेटिंग्स तक पहुंचें। यह एक [INotesSize](https://reference.aspose.com/slides/hi/net/aspose.slides/inotessize/) ऑब्जेक्ट लौटाता है जिसका [Size](https://reference.aspose.com/slides/hi/net/aspose.slides/inotessize/size/) प्रॉपर्टी लिखी जा सकती है। हालांकि सेटिंग्स ऑब्जेक्ट स्वयं केवल‑पढ़ने योग्य है, आप उसके आकार प्रॉपर्टी को नई माप दे सकते हैं।

चौड़ाई और ऊँचाई **बिंदु** में निर्दिष्ट होती है, जहाँ प्रति इंच 72 बिंदु होते हैं। उदाहरण के लिए, 900 × 600 बिंदु 12.5 × 8⅓ इंच के बराबर है। ये सेटिंग्स पूरी प्रस्तुति पर लागू होती हैं, न कि किसी व्यक्तिगत स्लाइड के नोट्स पर।

| सेटिंग | उद्देश्य |
| --- | --- |
| [Presentation.NotesSize](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/notessize/) | नोट्स पृष्ठ के आकार और हैंडआउट निर्यात के लिए उपयोग किए जाने वाले पृष्ठ आकार को नियंत्रित करता है। |
| [Presentation.SlideSize](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/slidesize/) | नियमित प्रस्तुति स्लाइड के आकार को [ISlideSize](https://reference.aspose.com/slides/hi/net/aspose.slides/islidesize/) के माध्यम से नियंत्रित करता है। |

इन दोनों सेटिंग्स में से किसी एक को बदलने से दूसरी स्वतः नहीं बदलती। नोट्स पृष्ठ का अभिविन्यास बदलने से नियमित स्लाइड भी नहीं घूमती। नियमित स्लाइड का आकार बदलने के लिए [Slide Size](/slides/hi/net/slide-size/) देखें।

नीचे दिए गए उदाहरण एक मौजूदा `sample.pptx` का उपयोग करते हैं। निर्यात उदाहरणों के लिए, कम से कम एक स्लाइड जिसमें स्पीकर नोट्स हों, वाली प्रस्तुति का उपयोग करें। प्रत्येक उदाहरण स्वतंत्र रूप से चलाया जा सकता है।

## **नोट्स पृष्ठ का आकार और अभिविन्यास पढ़ें**

चौड़ाई और ऊँचाई पढ़ें और उनके द्वयों की तुलना करके अभिविन्यास निर्धारित करें: व्यापक पृष्ठ लैंडस्केप है, लंबा पृष्ठ पोर्ट्रेट है, और समान माप वाला पृष्ठ वर्गाकार है। यह उदाहरण बिंदु में वास्तविक माप प्रिंट करता है, बिना किसी मानक कागज आकार को मानते हुए।

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;
var orientation = "Square";

if (size.Width > size.Height)
    orientation = "Landscape";
else if (size.Width < size.Height)
    orientation = "Portrait";

Console.WriteLine($"Notes page: {size.Width} x {size.Height} points");
Console.WriteLine($"Orientation: {orientation}");
```

## **लैंडस्केप में बदलें बिना कागज आकार बदले**

केवल अभिविन्यास बदलने के लिए मौजूदा चौड़ाई और ऊँचाई को अदला‑बदली करें। यह दोनों किनारों की लंबाई को संरक्षित रखता है, जिसमें कस्टम कागज आकार भी शामिल है। नीचे दिया गया शर्त पहले से लैंडस्केप पृष्ठ को फिर से पोर्ट्रेट में बदलने से रोकता है और वर्गाकार पृष्ठ को अपरिवर्तित रखता है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var size = presentation.NotesSize.Size;

if (size.Width < size.Height)
    presentation.NotesSize.Size = new SizeF(size.Height, size.Width);

presentation.Save("landscape-notes.pptx", SaveFormat.Pptx);
```

पोर्ट्रेट अभिविन्यास के लिए, `size.Width > size.Height` होने पर वही असाइनमेंट उपयोग करें। जब तक आप कागज आकार भी बदलना चाहते हैं, तब तक A4 या लेटर मापों को न बदलें।

## **कस्टम नोट्स पृष्ठ आकार सेट करें और सत्यापित करें**

दोनों मापों को एक साथ असाइन करें, फिर प्रस्तुति को लिखने के लिए [Presentation.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) का उपयोग करें। यह उदाहरण 900 × 600‑बिंदु लैंडस्केप पृष्ठ सेट करता है, इसे PPTX के रूप में सहेजता है, और सहेजी गई फ़ाइल को फिर से खोलकर सहेजे गए मानों की जाँच करता है। तुलना में फ्लोटिंग‑पॉइंट मानों के लिए 0.01‑बिंदु की सहनशीलता होती है; यह सभी फ़ाइल स्वरूपों में पूर्ण सटीकता की गारंटी नहीं देता।

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
var expectedSize = new SizeF(900, 600);
presentation.NotesSize.Size = expectedSize;
presentation.Save("custom-notes.pptx", SaveFormat.Pptx);

using var reopened = new Presentation("custom-notes.pptx");
var actualSize = reopened.NotesSize.Size;
var widthMatches = Math.Abs(actualSize.Width - expectedSize.Width) < 0.01f;
var heightMatches = Math.Abs(actualSize.Height - expectedSize.Height) < 0.01f;
var preserved = widthMatches && heightMatches;

Console.WriteLine($"Stored notes page: {actualSize.Width} x {actualSize.Height} points");
Console.WriteLine($"Size preserved: {preserved}");
```

अपेक्षित परिणाम `900 x 600 बिंदु` और `Size preserved: True` है। नई खोली गई प्रस्तुति की जाँच सहेजी गई फ़ाइल को सत्यापित करती है, न कि केवल मेमोरी में मौजूद सेटिंग्स को।

## **नोट्स और हैंडआउट निर्यात**

पृष्ठ आकार नोट्स या हैंडआउट लेआउट के उपलब्ध क्षेत्र को परिभाषित करता है। वे स्वयं उन लेआउट को सक्षम नहीं करते: निर्यात विकल्पों को भी कॉन्फ़िगर करें। नियमित स्लाइड निर्यात अभी भी स्लाइड आकार का उपयोग करता है।

### **नोट्स को PDF और PNG में निर्यात करें**

[NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/notescommentslayoutingoptions/) को [PdfOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/slideslayoutoptions/) में असाइन करके PDF में नोट्स शामिल करें। यह उदाहरण पहली स्लाइड को नोट्स के साथ PNG में भी रेंडर करता है, जिसमें [Slide.GetImage](https://reference.aspose.com/slides/hi/net/aspose.slides/slide/getimage/) और [RenderingOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/renderingoptions/) का उपयोग किया गया है।

[BottomTruncated](https://reference.aspose.com/slides/hi/net/aspose.slides.export/notespositions/) मोड नोट्स को एक पृष्ठ पर रखता है; जो नोट्स फिट नहीं होते उन्हें समाप्त किया जा सकता है। PDF 900 × 600‑बिंदु पृष्ठों का उपयोग करता है। नीचे दिए गए 1 × 1 इमेज स्केल पर PNG 900 × 600 पिक्सेल है। बिंदु पृष्ठ ज्यामिति को दर्शाते हैं; पिक्सेल रास्टर आउटपुट को, जिसका आकार रेंडरिंग स्केल पर भी निर्भर करता है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("notes.pdf", SaveFormat.Pdf, pdfOptions);

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layout };
using var image = presentation.Slides[0].GetImage(renderingOptions, 1, 1);
image.Save("first-slide-notes.png", ImageFormat.Png);
```

लंबे नोट्स वाले PDF निर्यात के लिए, [BottomFull](https://reference.aspose.com/slides/hi/net/aspose.slides.export/notespositions/) अतिरिक्त पृष्ठों की अनुमति देता है। ऊपर दी गई एक‑स्लाइड इमेज कॉल इस मोड का समर्थन नहीं करती; इसलिए इसका उपयोग न करें। आकार बदलने के बाद, क्लिप्ड नोट्स और मौजूदा नोट‑मास्टर ऑब्जेक्ट्स की स्थिति की जाँच करें; केवल पृष्ठ आकार बदलने से यह गारंटी नहीं मिलती कि सभी सामग्री फिट होगी। नोट्स निर्यात के बारे में अधिक जानकारी के लिए [Convert PowerPoint to PDF with Notes](/slides/hi/net/convert-powerpoint-to-pdf-with-notes/) देखें।

### **हैंडआउट को PDF में निर्यात करें**

एक पृष्ठ पर कई स्लाइड थंबनेल के लिए [HandoutLayoutingOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/handoutlayoutingoptions/) का उपयोग करें। नीचे दिया गया उदाहरण 900 × 600‑बिंदु पृष्ठ सेट करता है और [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/hi/net/aspose.slides.export/handouttype/) का उपयोग करके प्रति पृष्ठ अधिकतम चार स्लाइड व्यवस्थित करता है। क्षैतिज प्रीसेट स्लाइड क्रम को नियंत्रित करता है; पृष्ठ अभिविन्यास इसकी चौड़ाई और ऊँचाई से निर्धारित होता है।

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("sample.pptx");
presentation.NotesSize.Size = new SizeF(900, 600);

var layout = new HandoutLayoutingOptions
{
    Handout = HandoutType.Handouts4Horizontal
};

var pdfOptions = new PdfOptions { SlidesLayoutOptions = layout };
presentation.Save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
```

पृष्ठ आकार बदलने से हैंडआउट ग्रिड के उपलब्ध क्षेत्र में परिवर्तन होता है, जबकि स्रोत स्लाइड की माप नहीं बदलती। हैंडआउट छवियों के लिए, व्यक्तिगत स्लाइड की इमेज मेथड के बजाय हैंडआउट लेआउट के साथ [Presentation.GetImages](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/getimages/) का उपयोग करें। Aspose.Slides में, प्रस्तुति‑स्तर के हैंडआउट रेंडरिंग नोट्स पृष्ठ आकार का उपयोग करता है, जबकि व्यक्तिगत स्लाइड इमेज कॉल हैंडआउट पृष्ठ उत्पन्न नहीं करता। लेआउट विकल्पों के लिए [Handout Mode](/slides/hi/net/convert-powerpoint-in-handout-mode/) देखें।

## **दर्शक, निर्यात और प्रिंटिंग में पृष्ठ आकार**

संचित प्रस्तुति आकार, निर्यात पृष्ठ आकार और प्रिंटेड कागज आकार को अलग‑अलग रखें:

- **प्रस्तुति दर्शक:** एक दर्शक अपने स्वयं के लेआउट नियमों के साथ नोट्स प्रदर्शित या प्रिंट कर सकता है। यदि कोई अन्य एप्लिकेशन फ़ाइल को सहेजता है, तो उसे पुनः खोलें और माप पुनः जाँचें; उस एप्लिकेशन का फॉर्मेट परिवर्तन उन्हें मानकीकृत कर सकता है।
- **निर्यात स्वरूप:** उपरोक्त नोट्स और हैंडआउट PDF उदाहरण कॉन्फ़िगर किए गए पृष्ठ माप का उपयोग करते हैं। रास्टर छवियों में पूर्णांक पिक्सेल माप और रेंडरिंग स्केल होते हैं, इसलिए अंश बिंदु मान छवि आउटपुट में गोल किए जा सकते हैं। नियमित स्लाइड निर्यात में नोट्स पृष्ठ आकार लागू नहीं होता।
- **प्रिंटर ड्राइवर:** कागज चयन, स्वतः घुमा‑वटा, और फ़िट‑टू‑पेज सेटिंग्स भौतिक आउटपुट को बदल सकती हैं, बिना प्रस्तुति या PDF में संग्रहीत माप बदलें। विशिष्ट कागज आकार के लिए प्रिंटर सेटिंग्स मिलाएँ और प्रिंट प्रीव्यू जाँचें।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं केवल एक स्लाइड के लिए नोट्स आकार सेट कर सकता हूँ?**

नोट्स पृष्ठ आकार प्रस्तुति‑स्तर की सेटिंग है। व्यक्तिगत स्लाइड में अलग‑अलग नोट्स सामग्री हो सकती है, लेकिन यह प्रॉपर्टी प्रत्येक स्लाइड के लिए अलग पृष्ठ आकार प्रदान नहीं करती।

**नोट्स अभिविन्यास बदलने से मेरी स्लाइड क्यों नहीं बदली?**

नोट्स पृष्ठ और नियमित स्लाइड के माप स्वतंत्र होते हैं। स्लाइड को आकार बदलने के लिए नियमित स्लाइड आकार सेटिंग्स का उपयोग करें।

**मेरी सहेजी या प्रिंट की गई परिणाम का आकार अलग क्यों है?**

पहले सहेजी गई प्रस्तुति को पुनः खोलें और उसके नोट्स माप की तुलना करें। यदि वे बदल गए हैं, तो जांचें कि क्या किसी अन्य एप्लिकेशन में फ़ाइल को सहेजने या परिवर्तित करने से पृष्ठ सेटिंग बदल गई। यदि नहीं, तो निर्यात लेआउट, इमेज स्केल, दर्शक सेटिंग्स और प्रिंटर कागज चयन की जाँच करें।