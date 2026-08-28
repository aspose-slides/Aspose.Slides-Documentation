---
title: .NET में प्रस्तुति स्लाइड्स को छवियों में बदलें
linktitle: स्लाइड से छवि
type: docs
weight: 41
url: /hi/net/convert-slide/
keywords:
- स्लाइड बदलें
- स्लाइड निर्यात करें
- स्लाइड से छवि
- स्लाइड को छवि के रूप में सहेजें
- स्लाइड से EMF
- स्लाइड से PNG
- स्लाइड से JPEG
- स्लाइड से बिटमैप
- स्लाइड से TIFF
- पावरपॉइंट
- ओपनडॉक्यूमेंट
- प्रस्तुति
- .NET
- C#
- Aspose.Slides
description: "PPT, PPTX और ODP प्रस्तुतियों की स्लाइड्स को PNG, JPEG, GIF, TIFF, EMF और अन्य चित्र स्वरूपों में C# के साथ Aspose.Slides for .NET का उपयोग करके बदलें।"
---
## **परिचय**

Aspose.Slides for .NET व्यक्तिगत स्लाइडों को PowerPoint और OpenDocument प्रस्तुतियों से PNG, JPEG, GIF, TIFF और अन्य छवि स्वरूपों में रेंडर कर सकता है।

एक स्लाइड को छवि में बदलने के लिए, इन चरणों का पालन करें:

1. प्रेज़ेंटेशन को [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) वर्ग के साथ लोड करें।
2. उस स्लाइड का चयन करें जिसे आप रेंडर करना चाहते हैं।
3. यदि आवश्यक हो, तो रेंडरिंग को [RenderingOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/renderingoptions/) या [TiffOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/) वर्ग के साथ कॉन्फ़िगर करें।
4. [GetImage](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/getimage/) विधि को कॉल करें। यह एक [IImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) ऑब्जेक्ट लौटाता है।
5. [IImage.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/save/) विधि को कॉल करें और आउटपुट फ़ॉर्मेट को एक [ImageFormat](https://reference.aspose.com/slides/hi/net/aspose.slides/imageformat/) मान के साथ निर्दिष्ट करें।

## **स्लाइड को PNG छवि में बदलें**

सबसे सरल रूपांतरण डिफ़ॉल्ट रेंडरिंग सेटिंग्स का उपयोग करता है। परिणामस्वरूप [IImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimage/) ऑब्जेक्ट को मेमोरी में प्रोसेस किया जा सकता है या फ़ाइल में सहेजा जा सकता है।

निम्नलिखित C# उदाहरण पहला स्लाइड रेंडर करता है और इसे PNG छवि के रूप में सहेजता है:

```cs
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage();
image.Save("Slide_0.png", ImageFormat.Png);
```

## **कस्टम आकारों के साथ स्लाइड्स को छवियों में बदलें**

एक स्लाइड को सटीक पिक्सेल आयामों के साथ रेंडर करने के लिए, वह [GetImage](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/getimage/) ओवरलोड उपयोग करें जो एक [Size](https://learn.microsoft.com/en-us/dotnet/api/system.drawing.size) मान स्वीकार करता है।

निम्नलिखित उदाहरण 1820 × 1040 JPEG छवि बनाता है:

```cs
using System.Drawing;
using Aspose.Slides;

var imageSize = new Size(1820, 1040);

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(imageSize);
image.Save("Slide_0.jpg", ImageFormat.Jpeg);
```

## **नोट्स और टिप्पणियों के साथ स्लाइड्स को छवियों में बदलें**

डिफ़ॉल्ट रूप से, स्लाइड छवियों में नोट्स या टिप्पणियां शामिल नहीं होतीं। नोट्स और टिप्पणियों के प्रदर्शित स्थान को नियंत्रित करने के लिए एक [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/notescommentslayoutingoptions/) ऑब्जेक्ट को [RenderingOptions.SlidesLayoutOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/renderingoptions/slideslayoutoptions/) प्रॉपर्टी पर असाइन करें।

निम्नलिखित उदाहरण स्लाइड के नीचे ट्रंकेटेड नोट्स और दाएँ ओर टिप्पणियां रखता है:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var scaleX = 2f;
var scaleY = scaleX;

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomTruncated,
    CommentsPosition = CommentsPositions.Right,
    CommentsAreaWidth = 500,
    CommentsAreaColor = Color.AntiqueWhite
};

var renderingOptions = new RenderingOptions { SlidesLayoutOptions = layoutOptions };

using var presentation = new Presentation("Presentation_with_notes_and_comments.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(renderingOptions, scaleX, scaleY);
image.Save("Image_with_notes_and_comments_0.gif", ImageFormat.Gif);
```

{{% alert title="Warning" color="warning" %}}
स्लाइड-टू-इमेज रूपांतरण के लिए, [NotesPosition](https://reference.aspose.com/slides/hi/net/aspose.slides.export/inotescommentslayoutingoptions/notesposition/) प्रॉपर्टी को [BottomFull](https://reference.aspose.com/slides/hi/net/aspose.slides.export/notespositions/) पर सेट न करें। नोट्स में ऐसी मात्रा में टेक्स्ट हो सकता है जो निश्चित छवि आकार में फिट नहीं हो पाएगा। इसके बजाय [BottomTruncated](https://reference.aspose.com/slides/hi/net/aspose.slides.export/notespositions/) का उपयोग करें।
{{% /alert %}}

## **TIFF विकल्पों का उपयोग करके स्लाइड्स को छवियों में बदलें**

[TiffOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/tiffoptions/) वर्ग आपको रेंडर की गई TIFF छवि का आकार, रिज़ॉल्यूशन और अन्य गुणों को नियंत्रित करने की अनुमति देता है।

निम्नलिखित उदाहरण पहले स्लाइड को 2160 × 2880 TIFF छवि के रूप में 300 DPI पर रेंडर करता है:

```cs
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

var tiffOptions = new TiffOptions
{
    ImageSize = new Size(2160, 2880),
    DpiX = 300,
    DpiY = 300
};

using var presentation = new Presentation("sample.pptx");
var slide = presentation.Slides[0];

using var image = slide.GetImage(tiffOptions);
image.Save("output.tiff", ImageFormat.Tiff);
```

## **सभी स्लाइड्स को छवियों में बदलें**

पूरा प्रेज़ेंटेशन को छवियों की श्रृंखला में बदलने के लिए स्लाइड संग्रह के माध्यम से इटररेट करें। छिपी हुई स्लाइड्स को शामिल किया जाता है जब तक आप उन्हें स्पष्ट रूप से छोड़ न दें।

निम्नलिखित उदाहरण प्रत्येक स्लाइड को क्षैतिज और लंबवत स्केल कारक 2 के साथ JPEG छवि के रूप में रेंडर करता है:

```cs
using Aspose.Slides;

var scaleX = 2f;
var scaleY = scaleX;

using var presentation = new Presentation("Presentation.pptx");

var slideCount = presentation.Slides.Count;
for (var index = 0; index < slideCount; index++)
{
    var slide = presentation.Slides[index];
    using var image = slide.GetImage(scaleX, scaleY);
    image.Save($"Slide_{index}.jpg", ImageFormat.Jpeg);
}
```

## **एन्हांस्ड मेटाफाइल आउटपुट बनाएं**

Enhanced Metafile (EMF) तब उपयोगी होता है जब वेक्टर-आधारित ग्राफ़िक्स को Microsoft Office या अन्य Windows अनुप्रयोगों के साथ, जो Windows मेटाफाइल का समर्थन करते हैं, के साथ साझा करना आवश्यक हो। पिक्सेल-आधारित छवि के विपरीत, EMF वेक्टर ड्रॉइंग ऑपरेशन्स को बनाए रख सकता है जो स्केल होने पर भी कटाव नहीं होते। हालांकि, EMF मुख्यतः Windows मेटाफाइल समर्थन वाले अनुप्रयोगों के लिए एक संगतता फ़ॉर्मेट है, न कि एक सार्वभौमिक विनिमय फ़ॉर्मेट। इसके अतिरिक्त, जटिल स्लाइड सामग्री, जैसे बिटमैप छवियां और कुछ प्रभाव, वेक्टर मेटाफाइल कंटेनर के अंदर रास्टराइज़्ड तत्वों के रूप में संग्रहीत हो सकते हैं।

### **स्लाइड को EMF में निर्यात करें**

[ISlide.WriteAsEmf](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/writeasemf/) विधि एक [ISlide](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/) को EMF फ़ॉर्मेट में टार्गेट स्ट्रीम पर लिखती है। निम्नलिखित उदाहरण एक प्रेज़ेंटेशन लोड करता है, पहला स्लाइड चुनता है, और इसे EMF फ़ाइल स्ट्रीम में लिखता है:

```cs
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("Presentation.pptx");
var slide = presentation.Slides[0];

using var emfStream = File.Create("Slide_0.emf");
slide.WriteAsEmf(emfStream);
```

कॉलर वह स्ट्रीम का मालिक होता है जो [ISlide.WriteAsEmf](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/writeasemf/) को पास किया गया है और उसे बंद या डिस्पोज करना आवश्यक है। Aspose.Slides स्ट्रीम की वर्तमान पोज़िशन पर लिखता है और स्ट्रीम को खुला छोड़ देता है।

### **SVG छवि को EMF में बदलें और प्रेज़ेंटेशन में जोड़ें**

[ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/hi/net/aspose.slides/isvgimage/writeasemf/) का उपयोग करके SVG सामग्री को EMF में बदलें। परिणामस्वरूप बाइट्स को [IImageCollection.AddImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimagecollection/addimage/) के माध्यम से प्रेज़ेंटेशन में जोड़ा जा सकता है और उन्हें [IShapeCollection.AddPictureFrame](https://reference.aspose.com/slides/hi/net/aspose.slides/ishapecollection/addpictureframe/) द्वारा स्लाइड पर रखा जा सकता है।

निम्नलिखित उदाहरण SVG मार्कअप से एक [SvgImage](https://reference.aspose.com/slides/hi/net/aspose.slides/svgimage/) बनाता है, इसे इन-मेमोरी EMF में बदलता है, प्रथम स्लाइड पर मेटाफाइल सम्मिलित करता है, और प्रेज़ेंटेशन को सहेजता है:

```cs
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

var svgContent = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"200\" height=\"100\"><rect width=\"200\" height=\"100\" fill=\"#4472C4\"/></svg>";
var svgImage = new SvgImage(svgContent);

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var emfStream = new MemoryStream();
svgImage.WriteAsEmf(emfStream);

emfStream.Position = 0;
var image = presentation.Images.AddImage(emfStream);
slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 20, 20, 200, 100, image);

presentation.Save("Presentation_with_emf.pptx", SaveFormat.Pptx);
```

[ISvgImage.WriteAsEmf](https://reference.aspose.com/slides/hi/net/aspose.slides/isvgimage/writeasemf/) लक्ष्य स्ट्रीम की स्वामित्व नहीं लेता। लिखने के बाद, स्ट्रीम पोज़िशन उत्पन्न डेटा के अंत में होती है। ऊपर दिखाए अनुसार उसी सीक योग्य स्ट्रीम को रीडर को पास करने से पहले `Position` को शुरुआत में रीसेट करें। कंज्यूमर के पढ़ने समाप्त होने तक स्ट्रीम को खुला रखें, और बाद में उसे डिस्पोज करें। वैकल्पिक रूप से, `ToArray` को कॉल करें और वापस मिला बाइट ऐरे [IImageCollection.AddImage](https://reference.aspose.com/slides/hi/net/aspose.slides/iimagecollection/addimage/) को पास करें; `ToArray` वर्तमान स्ट्रीम पोज़िशन की परवाह किए बिना पूर्ण बफ़र लौटाता है।

EMF जनरेशन चयनित Aspose.Slides for .NET बिल्ड द्वारा समर्थित ऑपरेटिंग सिस्टम पर उपलब्ध है, लेकिन फ़ॉन्ट्स या नेटिव ग्राफ़िक्स निर्भरताएँ अनुपलब्ध होने पर विभिन्न प्लेटफ़ॉर्म पर रेंडरिंग भिन्न हो सकती है। स्रोत सामग्री द्वारा उपयोग किए गए फ़ॉन्ट्स स्थापित करें या उपयुक्त प्रतिस्थापन कॉन्फ़िगर करें, अपने Aspose.Slides पैकेज के लिए [platform requirements](/slides/hi/net/system-requirements/) का पालन करें, और लक्ष्य EMF-उपभोगकर्ता एप्लिकेशन में परिणाम को मान्य करें। Linux और macOS एप्लिकेशन अक्सर Windows मेटाफाइल को दिखाने और संपादित करने में सीमित या असंगत समर्थन रखते हैं।

## **रंगीन इमोजी रेंडरिंग**

{{% alert title="Note" color="info" %}}
प्रेज़ेंटेशन स्लाइड्स को छवियों में बदलते समय रंगीन इमोजी को सही ढंग से रेंडर करने के लिए, प्रेज़ेंटेशन में उपयोग किए गए इमोजी फ़ॉन्ट्स को इंस्टॉल किया जाना चाहिए और वह सिस्टम पर उपलब्ध होना चाहिए जो रूपांतरण कर रहा हो। उदाहरण के लिए, यदि प्रेज़ेंटेशन **Segoe UI Emoji** का उपयोग करता है और यह फ़ॉन्ट अनुपलब्ध है, तो आउटपुट छवियों में इमोजी मोनोक्रोम दिख सकते हैं।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या Aspose.Slides एनीमेशन के साथ स्लाइड्स को रेंडर करने का समर्थन करता है?**

नहीं। [GetImage](https://reference.aspose.com/slides/hi/net/aspose.slides/islide/getimage/) विधि स्लाइड की एक स्थैतिक छवि रेंडर करती है और एनीमेशन निर्यात नहीं करती।

**क्या छिपी हुई स्लाइड्स को छवियों के रूप में निर्यात किया जा सकता है?**

हाँ। छिपी हुई स्लाइड्स को सामान्य स्लाइड्स की तरह रेंडर किया जा सकता है। उन्हें प्रोसेसिंग लूप में शामिल करें, जैसा कि ऊपर दिए उदाहरण में दिखाया गया है।

**क्या स्लाइड छवियों में शैडो और अन्य प्रभाव संरक्षित रहते हैं?**

हाँ। Aspose.Slides स्लाइड छवियों में छायाएँ, पारदर्शिता और अन्य समर्थित ग्राफ़िकल प्रभावों को रेंडर करता है।