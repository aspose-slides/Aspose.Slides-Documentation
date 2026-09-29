---
title: समर्थित फ़ाइल फ़ॉर्मैट
type: docs
weight: 106
url: /hi/java/supported-file-formats/
keywords:
- समर्थित फ़ाइल फ़ॉर्मैट
- प्रस्तुति लोड करें
- PDF इम्पोर्ट करें
- HTML इम्पोर्ट करें
- प्रस्तुति सहेजें
- स्लाइड्स रेंडर करें
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
- Java
- Aspose.Slides
description: "देखें कि Aspose.Slides for Java किन फ़ाइल फ़ॉर्मैट्स को लोड, इम्पोर्ट, सहेज और रेंडर कर सकता है, और प्रत्येक को पढ़ने या लिखने के लिए कौन-सा API उपयोग किया जाता है।"
---
## **अवलोकन**

Aspose.Slides for Java PowerPoint और OpenDocument प्रस्तुतियों को खोलता और सहेजता है। यह PDF और HTML सामग्री को स्लाइड्स में इम्पोर्ट करता है, प्रस्तुतियों को दस्तावेज़, वेब, और इमेज फ़ॉर्मैट में सहेजता है, और व्यक्तिगत स्लाइड्स और शैप्स को इमेज के रूप में रेंडर करता है। यह लेख प्रत्येक समर्थित फ़ॉर्मैट को सूचीबद्ध करता है और वह API बताता है जो इसे पढ़ता या लिखता है।

संपादन फ़ीचर के अवलोकन के लिए, देखें [फ़ीचर अवलोकन](/slides/hi/java/features-overview/)।

## **समर्थित माइक्रोसॉफ्ट पावरपॉइंट संस्करण**

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
PowerPoint 95 और उससे पहले के संस्करणों से सहेजी गई प्रस्तुतियों को खोला नहीं जा सकता। [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) PowerPoint 95 फ़ाइल को पहचानता है और `LoadFormat.Ppt95` रिपोर्ट करता है, लेकिन [Presentation](https://reference.aspose.com/slides/hi/java/com.aspose.slides/presentation/#Presentation-java.lang.String-) कन्स्ट्रक्टर इसके लिए [PptUnsupportedFormatException](https://reference.aspose.com/slides/hi/java/com.aspose.slides/pptunsupportedformatexception/) फेंकता है।
{{% /alert %}}

## **समर्थित फ़ाइल फ़ॉर्मैट**

टेबल चार ऑपरेशनों का उपयोग करता है:

- **लोड**: [Presentation] कन्स्ट्रक्टर फ़ाइल को एक संपादन योग्य प्रस्तुति के रूप में खोलता है।
- **इम्पोर्ट**: एक [SlideCollection] मेथड फ़ाइल की सामग्री से स्लाइड्स बनाता है और उन्हें मौजूदा प्रस्तुति में जोड़ता है। Presentation कन्स्ट्रक्टर इन फ़ाइलों को स्लाइड्स में नहीं बदलता।
- **सेव**: [Presentation.save] प्रस्तुति को फ़ाइल या स्ट्रीम में लिखता है। XAML को छोड़कर हर फ़ॉर्मैट को एक [SaveFormat] मान से चुना जाता है।
- **रेंडर**: एक रेंडरिंग मेथड स्लाइड या शैप को इमेज के रूप में बनाता है। केवल रेंडर किए जाने वाले फ़ॉर्मैट्स के पास SaveFormat मान नहीं होते।

|**फ़ॉर्मैट**|**वर्णन**|**लोड / इम्पोर्ट**|**सेव / रेंडर**|**API**|
| :- | :- | :- | :- | :- |
|[PPT](https://docs.fileformat.com/presentation/ppt/)|PowerPoint 97-2003 प्रस्तुति|लोड|सेव|`LoadFormat.Ppt`, `SaveFormat.Ppt`|
|[POT](https://docs.fileformat.com/presentation/pot/)|PowerPoint 97-2003 टेम्पलेट|लोड|सेव|`LoadFormat.Pot`, `SaveFormat.Pot`|
|[PPS](https://docs.fileformat.com/presentation/pps/)|PowerPoint 97-2003 स्लाइड शो|लोड|सेव|`LoadFormat.Pps`, `SaveFormat.Pps`|
|[PPTX](https://docs.fileformat.com/presentation/pptx/)|PowerPoint प्रस्तुति|लोड|सेव|`LoadFormat.Pptx`, `SaveFormat.Pptx`|
|[POTX](https://docs.fileformat.com/presentation/potx/)|PowerPoint टेम्पलेट|लोड|सेव|`LoadFormat.Potx`, `SaveFormat.Potx`|
|[PPSX](https://docs.fileformat.com/presentation/ppsx/)|PowerPoint स्लाइड शो|लोड|सेव|`LoadFormat.Ppsx`, `SaveFormat.Ppsx`|
|[PPTM](https://docs.fileformat.com/presentation/pptm/)|PowerPoint मैक्रो-एनेबल्ड प्रस्तुति|लोड|सेव|`LoadFormat.Pptm`, `SaveFormat.Pptm`|
|[POTM](https://docs.fileformat.com/presentation/potm/)|PowerPoint मैक्रो-एनेबल्ड टेम्पलेट|लोड|सेव|`LoadFormat.Potm`, `SaveFormat.Potm`|
|[PPSM](https://docs.fileformat.com/presentation/ppsm/)|PowerPoint मैक्रो-एनेबल्ड स्लाइड शो|लोड|सेव|`LoadFormat.Ppsm`, `SaveFormat.Ppsm`|
|[ODP](https://docs.fileformat.com/presentation/odp/)|OpenDocument प्रस्तुति|लोड|सेव|`LoadFormat.Odp`, `SaveFormat.Odp`|
|FODP|फ़्लैट XML OpenDocument प्रस्तुति|लोड|सेव|`LoadFormat.Fodp`, `SaveFormat.Fodp`|
|[OTP](https://docs.fileformat.com/presentation/otp/)|OpenDocument प्रस्तुति टेम्पलेट|लोड|सेव|`LoadFormat.Otp`, `SaveFormat.Otp`|
|[XML](https://docs.fileformat.com/web/xml/)|PowerPoint XML प्रस्तुति|लोड|सेव|`SaveFormat.Xml`; loaded files report `SourceFormat.Xml` (there is no `LoadFormat` value)|
|[PDF](https://docs.fileformat.com/pdf/)|पोर्टेबल डॉक्यूमेंट फ़ॉर्मैट|इम्पोर्ट|सेव|`SlideCollection.addFromPdf`; `SaveFormat.Pdf`|
|[HTML](https://docs.fileformat.com/web/html/)|हाइपरटेक्स्ट मार्कअप लैंग्वेज|इम्पोर्ट|सेव|`SlideCollection.addFromHtml`, `SlideCollection.insertFromHtml`; `SaveFormat.Html`, `SaveFormat.Html5`|
|[XPS](https://docs.fileformat.com/page-description-language/xps/)|XML पेपर स्पेसिफिकेशन|—|सेव|`SaveFormat.Xps`|
|[TIFF](https://docs.fileformat.com/image/tiff/)|टैग्ड इमेज फ़ाइल फ़ॉर्मैट|—|सेव, रेंडर|`SaveFormat.Tiff` (one page per slide); `ImageFormat.Tiff` (one slide)|
|[GIF](https://docs.fileformat.com/image/gif/)|ग्राफ़िक्स इंटरचेंज फ़ॉर्मैट|—|सेव, रेंडर|`SaveFormat.Gif` (animated, all slides); `ImageFormat.Gif` (one slide)|
|[SWF](https://docs.fileformat.com/page-description-language/swf/)|स्मॉल वेब फ़ॉर्मैट (फ़्लैश)|—|सेव|`SaveFormat.Swf`|
|[MD](https://docs.fileformat.com/word-processing/md/)|मार्कडाउन|—|सेव|`SaveFormat.Md`|
|[XAML](https://docs.fileformat.com/web/xaml/)|एक्स्टेन्सिबल एप्लिकेशन मार्कअप लैंग्वेज|—|सेव|`Presentation.save(IXamlOptions)`, one XAML file per slide; not a `SaveFormat` value|
|[PNG](https://docs.fileformat.com/image/png/)|पोर्टेबल नेटवर्क ग्राफ़िक्स|—|रेंडर|`ImageFormat.Png`|
|[JPEG](https://docs.fileformat.com/image/jpeg/)|JPEG इमेज|—|रेंडर|`ImageFormat.Jpeg`|
|[BMP](https://docs.fileformat.com/image/bmp/)|बिटमैप इमेज|—|रेंडर|`ImageFormat.Bmp`|
|[EMF](https://docs.fileformat.com/image/emf/)|एन्हांस्ड मेटाफाइल|—|रेंडर|`Slide.writeAsEmf`|
|[SVG](https://docs.fileformat.com/page-description-language/svg/)|स्केलेबल वेक्टर ग्राफ़िक्स|—|रेंडर|`Slide.writeAsSvg`, `Shape.writeAsSvg`|

## **लोड और इम्पोर्ट**

- **लोड:** फ़ाइल पाथ या स्ट्रीम को [Presentation] कन्स्ट्रक्टर को पास करें। फ़ॉर्मैट सामग्री से पता चलता है; [LoadOptions] पासवर्ड जैसी सेटिंग्स प्रदान करता है। फ़ाइल को खोलने से पहले जांचने के लिए, [PresentationFactory.getPresentationInfo] कॉल करें, जो एक [LoadFormat] मान रिपोर्ट करता है। यह PowerPoint XML के लिए `LoadFormat.Unknown` रिपोर्ट करता है, लेकिन कन्स्ट्रक्टर ऐसी फ़ाइल खोलता है, और [Presentation.getSourceFormat] फिर `SourceFormat.Xml` लौटाता है। देखें [Open Presentations](/slides/hi/java/open-presentation/) और [Determine the Original Presentation Format](/slides/hi/java/detect-presentation-source-format/)।
- **इम्पोर्ट:** [SlideCollection.addFromPdf] एक PDF पेज पर एक स्लाइड जोड़ता है और प्रस्तुति के अंत में रखता है। [SlideCollection.addFromHtml] HTML से बनी स्लाइड्स जोड़ता है, और [SlideCollection.insertFromHtml] उन्हें निर्दिष्ट स्थिति पर डालता है। Presentation कन्स्ट्रक्टर इम्पोर्ट नहीं करता: यह PDF फ़ाइल के लिए [PptUnsupportedFormatException] फेंकता है और HTML मार्कअप को स्लाइड सामग्री में नहीं बदलता। देखें [Import Presentations from PDF or HTML](/slides/hi/java/import-presentation/)।

## **सेव और रेंडर**

- **सेव:** [Presentation.save] प्रस्तुति को एक [SaveFormat] मान द्वारा निर्दिष्ट फ़ॉर्मैट में लिखता है। विकल्प वस्तु लेने वाले ओवरलोड्स आउटपुट को नियंत्रित करते हैं, उदाहरण के लिए [PdfOptions], [HtmlOptions], [Html5Options], [TiffOptions], और [GifOptions]। स्लाइड पोजीशन की एरे लेने वाले ओवरलोड्स केवल उन स्लाइड्स को लिखते हैं; वे PDF, XPS, TIFF, HTML, HTML5, SWF, GIF, और Markdown को सपोर्ट करते हैं, लेकिन प्रस्तुति फ़ॉर्मैट या PowerPoint XML को नहीं। XAML का अपना ओवरलोड है, [Presentation.save] जो [IXamlOptions] लेता है। देखें [Save Presentations](/slides/hi/java/save-presentation/), [Convert Presentations](/slides/hi/java/convert-presentation/), और [Export Presentations to XAML](/slides/hi/java/export-to-xaml/)।
- **रेंडर:** [Slide.getImage] और [Shape.getImage] एक [IImage] लौटाते हैं, और [IImage.save] इसे PNG, JPEG, BMP, GIF, या TIFF के रूप में लिखता है, जो एक [ImageFormat] मान द्वारा चुना जाता है। [Presentation.getImages] सभी स्लाइड्स या चयनित स्लाइड्स को एक साथ रेंडर करता है। [Slide.writeAsSvg] और [Shape.writeAsSvg] SVG लिखते हैं, और [Slide.writeAsEmf] EMF लिखता है। देखें [Convert Presentation Slides to Images](/slides/hi/java/convert-slide/) और [Render Presentation Slides as SVG Images](/slides/hi/java/render-a-slide-as-an-svg-image/)।

{{% alert color="warning" title="Warning" %}}
ImageFormat में `Emf`, `Wmf`, `Icon`, `Exif`, और `MemoryBmp` मान भी होते हैं, लेकिन IImage.save इन फ़ॉर्मैट्स को उत्पन्न नहीं करता: जो फ़ाइल लिखी जाती है उसमें PNG डेटा होता है। स्लाइड की EMF इमेज पाने के लिए, Slide.writeAsEmf का उपयोग करें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं PPT प्रस्तुति को PPTX या ODP में कनवर्ट कर सकता हूँ?**

हाँ। PPT फ़ाइल को Presentation कन्स्ट्रक्टर से खोलें और इसे `SaveFormat.Pptx` या `SaveFormat.Odp` के साथ सेव करें। देखें [Convert PPT to PPTX](/slides/hi/java/convert-ppt-to-pptx/)।

**क्या मैं PDF या HTML फ़ाइल को प्रस्तुति के रूप में खोल सकता हूँ?**

नहीं। Presentation कन्स्ट्रक्टर PDF फ़ाइल के लिए PptUnsupportedFormatException फेंकता है और HTML मार्कअप को स्लाइड्स में परिवर्तित नहीं करता। एक प्रस्तुति बनाएँ या खोलें, ऊपर वर्णित स्लाइड कलेक्शन मेथड्स से PDF पेज या HTML सामग्री को इम्पोर्ट करें, और फिर इसे किसी भी समर्थित फ़ॉर्मैट में सेव करें।

**क्या मैं निर्यातित PNG या SVG इमेज को एक संपादन योग्य प्रस्तुति के रूप में लोड कर सकता हूँ?**

नहीं। इमेज आउटपुट केवल स्लाइड की दिखावट को दर्ज करता है, न कि उसका टेक्स्ट, शैप्स या चार्ट्स। यदि बाद में संपादित करने की आवश्यकता है तो मूल प्रस्तुति रखें।

**क्या मैं PDF/A या PDF/UA दस्तावेज़ को सेव कर सकता हूँ?**

हाँ। [PdfCompliance] मान को [PdfOptions.setCompliance] को पास करें: PDF/A-1a, PDF/A-1b, PDF/A-2a, PDF/A-2b, PDF/A-2u, PDF/A-3a, PDF/A-3b, या PDF/UA।

**क्या मैं फ़ाइल को खोलने से पहले जांच सकता हूँ कि वह पासवर्ड‑सुरक्षित है या नहीं?**

हाँ। [PresentationFactory.getPresentationInfo] फ़ाइल को बिना Presentation ऑब्जेक्ट बनाए जाँचता है, और [IPresentationInfo.isPasswordProtected] बताता है कि पासवर्ड आवश्यक है या नहीं। देखें [Password‑Protect Presentations](/slides/hi/java/password-protected-presentation/).