---
title: समर्थित फ़ाइल स्वरूप
type: docs
weight: 96
url: /hi/net/supported-file-formats/
keywords:
- समर्थित फ़ाइल स्वरूप
- प्रस्तुति लोड करें
- PDF आयात करें
- HTML आयात करें
- प्रस्तुति सहेजें
- स्लाइड रेंडर करें
- PowerPoint
- OpenDocument
- PPT
- PPTX
- ODP
- PDF
- HTML
- XPS
- SVG
- XAML
- .NET
- C#
- Aspose.Slides
description: "देखें कि Aspose.Slides for .NET कौन से फ़ाइल स्वरूप लोड, आयात, सहेज और रेंडर कर सकता है, और कौन सा API प्रत्येक को पढ़ता या लिखता है।"
---
## **अवलोकन**

Aspose.Slides for .NET PowerPoint और OpenDocument प्रस्तुतियों को खोलता और सहेजता है। यह PDF और HTML सामग्री को स्लाइडों में आयात करता है, प्रस्तुतियों को दस्तावेज़, वेब और छवि स्वरूपों में सहेजता है, और व्यक्तिगत स्लाइड एवं आकारों को छवियों के रूप में रेंडर करता है। यह लेख प्रत्येक समर्थित स्वरूप की सूची देता है और वह API बताता है जो इसे पढ़ता या लिखता है।

Aspose.Slides.NET और Aspose.Slides.NET6.CrossPlatform दोनों NuGet पैकेज समान स्वरूपों का समर्थन करते हैं; उनके बीच चयन करने के लिए [स्थापना](/slides/hi/net/installation/) देखें। संपादन सुविधाओं का अवलोकन पाने के लिए, [फ़ीचर अवलोकन](/slides/hi/net/features-overview/) देखें।

## **समर्थित Microsoft PowerPoint संस्करण**

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003
- Microsoft PowerPoint 2007
- Microsoft PowerPoint 2010
- Microsoft PowerPoint 2013
- Microsoft PowerPoint 2016
- Microsoft PowerPoint 2019
- Microsoft PowerPoint for Mac
- PowerPoint for Microsoft 365 (formerly Office 365)

{{% alert color="info" title="Note" %}}
PowerPoint 95 और उससे पहले के संस्करणों द्वारा सुरक्षित प्रस्तुतियों को खोला नहीं जा सकता। [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hi/net/aspose.slides/presentationfactory/getpresentationinfo/) PowerPoint 95 फ़ाइल को पहचानता है और `LoadFormat.Ppt95` रिपोर्ट करता है, लेकिन [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/presentation/) कन्स्ट्रक्टर इसके लिए [PptUnsupportedFormatException](https://reference.aspose.com/slides/hi/net/aspose.slides/pptunsupportedformatexception/) थ्रो करता है।
{{% /alert %}}

## **समर्थित फ़ाइल स्वरूप**

टेबल चार ऑपरेशन्स का उपयोग करता है:

- **लोड**: [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/presentation/) कन्स्ट्रक्टर फ़ाइल को संपादन योग्य प्रस्तुति के रूप में खोलता है।
- **इम्पोर्ट**: [SlideCollection](https://reference.aspose.com/slides/hi/net/aspose.slides/slidecollection/) मेथड फ़ाइल की सामग्री से स्लाइड बनाता है और मौजूदा प्रस्तुति में जोड़ता है। Presentation कन्स्ट्रक्टर इन फ़ाइलों को प्रस्तुति के रूप में लोड नहीं करता।
- **सेव**: [Presentation.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) प्रस्तुति को एक फ़ाइल या स्ट्रीम में लिखता है। XAML को छोड़कर हर स्वरूप को एक [SaveFormat](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveformat/) मान से चुना जाता है।
- **रेंडर**: एक रेंडरिंग मेथड स्लाइड या आकार को छवि के रूप में बनाता है। केवल रेंडर किए जाने वाले स्वरूपों के लिए SaveFormat मान नहीं होते।

|**फ़ॉर्मेट**|**विवरण**|**लोड / इम्पोर्ट**|**सेव / रेंडर**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003 प्रस्तुति|लोड|सेव|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97-2003 टेम्पलेट|लोड|सेव|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97-2003 स्लाइड शो|लोड|सेव|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint प्रस्तुति|लोड|सेव|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint टेम्पलेट|लोड|सेव|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint स्लाइड शो|लोड|सेव|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint मैक्रो-सक्षम प्रस्तुति|लोड|सेव|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint मैक्रो-सक्षम टेम्पलेट|लोड|सेव|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint मैक्रो-सक्षम स्लाइड शो|लोड|सेव|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument प्रस्तुति|लोड|सेव|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|फ़्लैट XML OpenDocument प्रस्तुति|लोड|सेव|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument प्रस्तुति टेम्पलेट|लोड|सेव|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML प्रस्तुति|लोड|सेव|`SaveFormat.Xml`; loaded files report `SourceFormat.Xml` (there is no `LoadFormat` value)|
|[PDF](https://docs.fileformat.com/pdf/)|पोर्टेबल डॉक्यूमेंट फ़ॉर्मेट|इम्पोर्ट|सेव|`SlideCollection.AddFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|हाइपरटेक्स्ट मार्कअप लैंग्वेज|इम्पोर्ट|सेव|`SlideCollection.AddFromHtml`, `SlideCollection.InsertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML पेपर स्पेसिफिकेशन|—|सेव|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|टैग्ड इमेज फ़ाइल फ़ॉर्मेट|—|सेव, रेंडर|`SaveFormat.Tiff`; `ImageFormat.Tiff` (one slide)|
|[GIF](https://docs.fileformat.com/image/gif/)|ग्राफिक्स इंटरचेंज फ़ॉर्मेट|—|सेव, रेंडर|`SaveFormat.Gif` (animated, all slides); `ImageFormat.Gif` (one slide)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|स्मॉल वेब फ़ॉर्मेट (फ़्लैश)|—|सेव|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|मार्कडाउन|—|सेव|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|एक्स्टेंसिबल एप्लीकेशन मार्कअप लैंग्वेज|—|सेव|`Presentation.Save(IXamlOptions)`, one XAML file per slide; not a `SaveFormat` value|
|[PNG](https://docs.fileformat.com/image/png/)|पोर्टेबल नेटवर्क ग्राफिक्स|—|रेंडर|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG इमेज|—|रेंडर|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|बिटमैप इमेज|—|रेंडर|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|एन्हांस्ड मेटा फ़ाइल|—|रेंडर|`Slide.WriteAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|स्केलेबल वेक्टर ग्राफिक्स|—|रेंडर|`Slide.WriteAsSvg`, `Shape.WriteAsSvg`|

## **लोड और इम्पोर्ट**

- **लोड:** फ़ाइल पथ या स्ट्रीम को [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/presentation/) कन्स्ट्रक्टर को पास करें। स्वरूप सामग्री से पता लगाया जाता है; [LoadOptions](https://reference.aspose.com/slides/hi/net/aspose.slides/loadoptions/) पासवर्ड जैसी सेटिंग्स प्रदान करता है। फ़ाइल को खोलने से पहले जांचने के लिए, [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hi/net/aspose.slides/presentationfactory/getpresentationinfo/) को कॉल करें, जो एक [LoadFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/loadformat/) मान रिपोर्ट करता है। यह PowerPoint XML के लिए `LoadFormat.Unknown` रिपोर्ट करता है, लेकिन कन्स्ट्रक्टर इस फ़ाइल को खोलता है, और [Presentation.SourceFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/sourceformat/) फिर `SourceFormat.Xml` लौटाता है। देखें [Open Presentations](/slides/hi/net/open-presentation/) और [Determine the Original Presentation Format](/slides/hi/net/detect-presentation-source-format/)।
- **इम्पोर्ट:** [SlideCollection.AddFromPdf](https://reference.aspose.com/slides/hi/net/aspose.slides/slidecollection/addfrompdf/) प्रत्येक PDF पृष्ठ के लिए एक स्लाइड को प्रस्तुति के अंत में जोड़ता है। [SlideCollection.AddFromHtml](https://reference.aspose.com/slides/hi/net/aspose.slides/slidecollection/addfromhtml/) HTML से निर्मित स्लाइड जोड़ता है, और [SlideCollection.InsertFromHtml](https://reference.aspose.com/slides/hi/net/aspose.slides/slidecollection/insertfromhtml/) उन्हें निर्दिष्ट स्थिति पर डालता है। Presentation कन्स्ट्रक्टर इम्पोर्ट नहीं करता: यह PDF फ़ाइल के लिए [PptUnsupportedFormatException](https://reference.aspose.com/slides/hi/net/aspose.slides/pptunsupportedformatexception/) थ्रो करता है और HTML मार्कअप को स्लाइड सामग्री में परिवर्तित नहीं करता। देखें [Import Presentations from PDF or HTML](/slides/hi/net/import-presentation/)।

## **सेव और रेंडर**

- **सेव:** [Presentation.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) प्रस्तुति को एक [SaveFormat](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveformat/) मान के स्वरूप में लिखता है। विकल्प ऑब्जेक्ट लेने वाले ओवरलोड आउटपुट को नियंत्रित करते हैं, उदाहरण के लिए [PdfOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/htmloptions/), [Html5Options](https://reference.aspose.com/slides/hi/net/aspose.slides.export/html5options/), [TiffOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/), और [GifOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/gifoptions/)। स्लाइड पोजीशन की ऐरे (1 से शुरू) लेने वाले ओवरलोड केवल उन स्लाइडों को लिखते हैं; वे PDF, XPS, TIFF, HTML, HTML5, SWF, GIF और Markdown को सपोर्ट करते हैं, लेकिन प्रस्तुति स्वरूपों या PowerPoint XML को नहीं। XAML का अपना ओवरलोड है जो [IXamlOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export.xaml/ixamloptions/) लेता है। देखें [Save Presentations](/slides/hi/net/save-presentation/), [Convert Presentations](/slides/hi/net/convert-presentation/), और [Export Presentations to XAML](/slides/hi/net/export-to-xaml/)।
- **रेंडर:** [Slide.GetImage](https://reference.aspose.com/slides/hi/net/aspose.slides/slide/getimage/) और [Shape.GetImage](https://reference.aspose.com/slides/hi/net/aspose.slides/shape/getimage/) एक [IImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) लौटाते हैं, और [IImage.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/save/) इसे PNG, JPEG, BMP, GIF, या TIFF के रूप में लिखता है, जिसे एक [ImageFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/imageformat/) मान से चुना जाता है। [Presentation.GetImages](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/getimages/) सभी स्लाइड या चयनित स्लाइड को एक साथ रेंडर करता है। [Slide.WriteAsSvg](https://reference.aspose.com/slides/hi/net/aspose.slides/slide/writeassvg/) और [Shape.WriteAsSvg](https://reference.aspose.com/slides/hi/net/aspose.slides/shape/writeassvg/) SVG लिखते हैं, और [Slide.WriteAsEmf](https://reference.aspose.com/slides/hi/net/aspose.slides/slide/writeasemf/) EMF लिखता है। देखें [Convert Presentation Slides to Images](/slides/hi/net/convert-slide/) और [Render a Slide as an SVG Image](/slides/hi/net/render-a-slide-as-an-svg-image/)।

{{% alert color="warning" title="Warning" %}}
ImageFormat में `Emf`, `Wmf`, `Icon`, `Exif`, और `MemoryBmp` मान भी हैं, लेकिन IImage.Save इन स्वरूपों को उत्पन्न नहीं करता: जो फ़ाइल यह लिखता है वह PNG डेटा रखती है। स्लाइड की EMF इमेज प्राप्त करने के लिए, Slide.WriteAsEmf का उपयोग करें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं PPT प्रस्तुति को PPTX या ODP में परिवर्तित कर सकता हूँ?**

हाँ। PPT फ़ाइल को Presentation कन्स्ट्रक्टर से खोलें और उसे `SaveFormat.Pptx` या `SaveFormat.Odp` के साथ सहेजें। देखें [PPT को PPTX में बदलें](/slides/hi/net/convert-ppt-to-pptx/)।

**क्या मैं PDF या HTML फ़ाइल को प्रस्तुति के रूप में खोल सकता हूँ?**

नहीं। एक प्रस्तुति बनाएं या खोलें, ऊपर वर्णित स्लाइड कलेक्शन मेथड्स से PDF पृष्ठों या HTML सामग्री को इम्पोर्ट करें, और फिर इसे किसी भी समर्थित स्वरूप में सहेजें।

**क्या मैं एक्स्पोर्टेड PNG या SVG इमेज को संपादन योग्य प्रस्तुति के रूप में लोड कर सकता हूँ?**

नहीं। इमेज आउटपुट केवल स्लाइड की दृश्यता को रिकॉर्ड करता है, न कि उसका टेक्स्ट, आकार या चार्ट। यदि आपको बाद में संपादन की आवश्यकता है तो मूल प्रस्तुति रखें।

**क्या मैं PDF/A या PDF/UA दस्तावेज़ सहेज सकता हूँ?**

हाँ। [PdfOptions.Compliance](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfoptions/compliance/) को किसी [PdfCompliance](https://reference.aspose.com/slides/hi/net/aspose.slides.export/pdfcompliance/) मान पर सेट करें: PDF/A-1a, PDF/A-1b, PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b, या PDF/UA।

**क्या मैं फ़ाइल खोलने से पहले यह जांच सकता हूँ कि वह पासवर्ड‑प्रोटेक्टेड है?**

हाँ। [PresentationFactory.GetPresentationInfo](https://reference.aspose.com/slides/hi/net/aspose.slides/presentationfactory/getpresentationinfo/) फ़ाइल को बिना Presentation ऑब्जेक्ट बनाए जांचता है, और उसकी [IsPasswordProtected](https://reference.aspose.com/slides/hi/net/aspose.slides/ipresentationinfo/ispasswordprotected/) प्रॉपर्टी बताती है कि पासवर्ड आवश्यक है या नहीं। देखें [Password‑Protect Presentations](/slides/hi/net/password-protected-presentation/)।

**क्या दो NuGet पैकेज अलग‑अलग स्वरूपों का समर्थन करते हैं?**

नहीं। Aspose.Slides.NET और Aspose.Slides.NET6.CrossPlatform में समान LoadFormat और SaveFormat मान और समान इम्पोर्ट एवं रेंडर मेथड्स हैं। वे चलने वाले प्लेटफ़ॉर्म और उन प्लेटफ़ॉर्म की आवश्यकताओं में अलग हैं; देखें [स्थापना](/slides/hi/net/installation/).