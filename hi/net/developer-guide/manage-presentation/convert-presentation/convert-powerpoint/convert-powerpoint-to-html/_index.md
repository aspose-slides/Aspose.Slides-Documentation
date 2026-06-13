---
title: PowerPoint प्रस्तुतियों को .NET में HTML में बदलें
linktitle: PowerPoint से HTML
type: docs
weight: 30
url: /hi/net/convert-powerpoint-to-html/
keywords:
- PowerPoint बदलें
- प्रस्तुति बदलें
- स्लाइड बदलें
- PPT बदलें
- PPTX बदलें
- PowerPoint से HTML
- प्रस्तुति से HTML
- स्लाइड से HTML
- PPT से HTML
- PPTX से HTML
- PowerPoint को HTML के रूप में सहेजें
- प्रस्तुति को HTML के रूप में सहेजें
- स्लाइड को HTML के रूप में सहेजें
- PPT को HTML के रूप में सहेजें
- PPTX को HTML के रूप में सहेजें
- PPT को HTML में निर्यात करें
- PPTX को HTML में निर्यात करें
- .NET
- C#
- Aspose.Slides
description: "PowerPoint प्रस्तुतियों को .NET में HTML में बदलें। PPT और PPTX फ़ाइलों, चयनित स्लाइडों, नोट्स, फ़ॉन्ट, छवियों, SVG और मीडिया को निर्यात करने के लिए Aspose.Slides का उपयोग करें।"
---
## **अवलोकन**

Aspose.Slides for .NET Microsoft PowerPoint के बिना PowerPoint प्रस्तुतियों को HTML के रूप में सहेज सकता है। बुनियादी रूपांतरण एकल [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) लोड और एक [Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) कॉल है जिसमें [SaveFormat](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveformat/) उपयोग किया जाता है। जब आपको निर्यातित लेआउट, फ़ॉन्ट, छवियों, नोट्स, टिप्पणियों, SVG आउटपुट, या लिंक्ड संसाधनों को नियंत्रित करने की आवश्यकता हो तो [HtmlOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/htmloptions/) का उपयोग करें।

यह गाइड व्यावहारिक HTML निर्यात परिदृश्यों पर केंद्रित है:

- पूरा प्रस्तुतीकरण या चयनित स्लाइड्स निर्यात करें।
- स्थिर-लेआउट, प्रतिसादशील, या SVG-आधारित HTML उत्पन्न करें।
- वक्ता नोट्स और टिप्पणियों को शामिल करें।
- छवि गुणवत्ता और काटे गए छवि डेटा को नियंत्रित करें।
- फ़ॉन्ट एम्बेड करें या फ़ॉन्ट फ़ाइलें अलग से सहेजें।
- बाहरी संसाधनों और मीडिया फ़ाइलों को लिखने और संदर्भित करने के तरीके का चयन करें।

डिफ़ॉल्ट रूप से, HTML निर्यात एक स्व-समावेशी HTML दस्तावेज़ बनाता है जहाँ अधिकांश संसाधन एम्बेडेड होते हैं। यह एक फ़ाइल को साझा करने के लिए सुविधाजनक है, लेकिन यह आउटपुट आकार बढ़ा सकता है। वेब प्रकाशन के लिए, बाहरी संसाधनों, कम छवि DPI, और केवल उन फ़ॉन्ट्स को एम्बेड करने पर विचार करें जो लक्ष्य पर्यावरण में भरोसेमंद रूप से उपलब्ध नहीं हैं।

## **एक प्रस्तुतीकरण को HTML में परिवर्तित करें**

एक प्रस्तुतीकरण को HTML में निर्यात करने के लिए, इसे [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) से लोड करें और इसे [SaveFormat.Html](https://reference.aspose.com/slides/hi/net/aspose.slides.export/saveformat/) के साथ सहेजें।

```csharp
using var presentation = new Presentation("presentation.pptx");

presentation.Save("presentation.html", SaveFormat.Html);
```

यह उदाहरण एक HTML फ़ाइल लिखता है। `using` घोषणा द्वारा प्रस्तुतीकरण ऑब्जेक्ट को डिस्पोज़ किया जाता है, जो निर्यात के बाद फ़ाइल हैंडल और रेंडरिंग संसाधन जारी कर देती है।

## **HtmlOptions का उपयोग करें**

[HtmlOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/htmloptions/) HTML निर्यात के लिए मुख्य कॉन्फ़िगरेशन क्लास है। सामान्य सेटिंग्स में शामिल हैं:

- `SlidesLayoutOptions`: नोट्स, टिप्पणियां, हैंडआउट या अन्य लेआउट जानकारी जोड़ता है।
- `HtmlFormatter`: HTML दस्तावेज़ संरचना बदलता है या फ़ॉर्मेटिंग को नियंत्रित करने के लिए कंट्रोलर को डेलीगेट करता है।
- `SlideImageFormat`: स्लाइड्स को प्रदर्शित करने का तरीका बदलता है, उदाहरण के लिए SVG के रूप में।
- `PicturesCompression`: छवि DPI और आउटपुट आकार नियंत्रित करता है।
- `DeletePicturesCroppedAreas`: कटे हुए छवि डेटा को रखता या हटाता है।
- `SvgResponsiveLayout`: निर्यातित SVG सामग्री को उसकी कंटेनर के अनुसार अनुकूल बनाता है।
- `ShowHiddenSlides`: आवश्यकतानुसार छिपी स्लाइड्स को शामिल करता है।

निम्नलिखित अनुभाग सबसे सामान्य विकल्पों को अलग-अलग दिखाते हैं ताकि आप केवल वही चुन सकें जो आपके कार्य प्रवाह को आवश्यक है।

## **चयनित स्लाइड्स को HTML में परिवर्तित करें**

[Presentation.Save](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/save/) ओवरलोड जो स्लाइड नंबर स्वीकार करता है, 1-आधारित स्लाइड स्थितियों का प्रयोग करता है। नीचे दिया गया लूप प्रत्येक स्लाइड को अलग HTML फ़ाइल में सहेजता है।

```csharp
using var presentation = new Presentation("presentation.pptx");

var slideCount = presentation.Slides.Count;

for (var slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    var slideNumber = slideIndex + 1;
    var slideNumbers = new[] { slideNumber };
    var htmlFileName = $"slide-{slideNumber}.html";

    presentation.Save(htmlFileName, slideNumbers, SaveFormat.Html);
}
```

जब किसी वेबसाइट या एप्लिकेशन को प्रत्येक स्लाइड के लिए एक HTML पेज चाहिए, तब इस पैटर्न का उपयोग करें। यदि प्रत्येक स्लाइड का लेआउट समान होना चाहिए, तो एक [HtmlOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/htmloptions/) इंस्टेंस बनाएं और उसे प्रत्येक `Save` कॉल में पास करें।

## **प्रतिक्रियाशील HTML बनाएं**

[ResponsiveHtmlController](https://reference.aspose.com/slides/hi/net/aspose.slides.export/responsivehtmlcontroller/) [HtmlFormatter](https://reference.aspose.com/slides/hi/net/aspose.slides.export/htmlformatter/) के माध्यम से प्रतिक्रियाशील HTML आउटपुट प्रदान करता है। इसे तब उपयोग करें जब निर्यातित पृष्ठ को ब्राउज़र की चौड़ाई के अनुसार बेहतर अनुकूलित होना चाहिए।

```csharp
using var presentation = new Presentation("presentation.pptx");

var controller = new ResponsiveHtmlController();
var formatter = HtmlFormatter.CreateCustomFormatter(controller);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-responsive.html", SaveFormat.Html, htmlOptions);
```

SVG-आधारित प्रतिक्रियाशील लेआउट के लिए, [HtmlOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/htmloptions/) पर `SvgResponsiveLayout` सेट करें। यह उपयोगी है जब स्लाइड सामग्री को स्केलेबल SVG मार्कअप के रूप में निर्यात किया जाता है।

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    SvgResponsiveLayout = true
};

presentation.Save("presentation-svg-responsive.html", SaveFormat.Html, htmlOptions);
```

## **वक्ता नोट्स और टिप्पणियां शामिल करें**

`HtmlOptions.SlidesLayoutOptions` के माध्यम से [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/notescommentslayoutingoptions/) का उपयोग करके वक्ता नोट्स या टिप्पणियां शामिल करें। नोट्स और टिप्पणियां डिफ़ॉल्ट रूप से छिपी रहती हैं जब तक आप उनकी स्थिति नहीं चुनते।

मान लीजिए स्रोत प्रस्तुतीकरण में वक्ता नोट्स हैं:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

निम्नलिखित कोड स्लाइड सामग्री को स्लाइड के नीचे वक्ता नोट्स के साथ निर्यात करता है।

```csharp
using var presentation = new Presentation("presentation.pptx");

var layoutOptions = new NotesCommentsLayoutingOptions
{
    NotesPosition = NotesPositions.BottomFull
};

var htmlOptions = new HtmlOptions
{
    SlidesLayoutOptions = layoutOptions
};

presentation.Save("presentation-with-notes.html", SaveFormat.Html, htmlOptions);
```

निर्यातित HTML में नोट्स क्षेत्र शामिल है:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

टिप्पणियों को निर्यात करने के लिए, `CommentsPosition` सेट करें, उदाहरण के लिए `CommentsPositions.Right` या `CommentsPositions.Bottom`। यदि आपको केवल टिप्पणियां चाहिए, तो `NotesPosition` को हटाएं। यदि आपको दोनों नोट्स और टिप्पणियां चाहिए, तो दोनों प्रॉपर्टी सेट करें।

## **छवि गुणवत्ता और कटे हुए क्षेत्रों को नियंत्रित करें**

HTML निर्यात स्लाइड छवियों को संपीड़ित करके आउटपुट आकार घटा सकता है। जब आपको उच्च छवि गुणवत्ता चाहिए तो [PicturesCompression](https://reference.aspose.com/slides/hi/net/aspose.slides.export/picturescompression/) से `PicturesCompression` को किसी मान पर सेट करें।

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    PicturesCompression = PicturesCompression.Dpi150
};

presentation.Save("presentation-dpi-150.html", SaveFormat.Html, htmlOptions);
```

डिफ़ॉल्ट रूप से, छवियों के कटे हुए क्षेत्रों को निर्यातित आउटपुट से हटा दिया जा सकता है। केवल तब कटे हुए डेटा रखें जब उपयोगकर्ताओं को उन छिपे हुए हिस्सों को पुनर्प्राप्त या निरीक्षण करने की आवश्यकता हो। इसे रखने से HTML का आकार बढ़ सकता है।

```csharp
using var presentation = new Presentation("presentation.pptx");

var htmlOptions = new HtmlOptions
{
    DeletePicturesCroppedAreas = false
};

presentation.Save("presentation-with-cropped-areas.html", SaveFormat.Html, htmlOptions);
```

## **CSS जोड़ें**

सरल स्टाइलिंग के लिए, एक CSS स्ट्रिंग को [HtmlFormatter.CreateDocumentFormatter](https://reference.aspose.com/slides/hi/net/aspose.slides.export/htmlformatter/createdocumentformatter/) को पास करें। यह आस्पोज़.Slides द्वारा स्लाइड सामग्री रेंडर किए जाने के दौरान आसपास के HTML दस्तावेज़ को बदलता है।

```csharp
using var presentation = new Presentation("presentation.pptx");

var cssRules = "body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
var formatter = HtmlFormatter.CreateDocumentFormatter(cssRules, true);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-styled.html", SaveFormat.Html, htmlOptions);
```

कस्टम दस्तावेज़ हेडर, लिंक्ड CSS फ़ाइल, या स्लाइड और शैप्स के चारों ओर कस्टम मार्कअप के लिए, [IHtmlFormattingController](https://reference.aspose.com/slides/hi/net/aspose.slides.export/ihtmlformattingcontroller/) को लागू करें और `CreateCustomFormatter` के साथ इसे [HtmlFormatter](https://reference.aspose.com/slides/hi/net/aspose.slides.export/htmlformatter/) को पास करें।

## **फ़ॉन्ट एम्बेड करें**

यदि लक्ष्य पर्यावरण में प्रस्तुतीकरण फ़ॉन्ट स्थापित नहीं हो सकते, तो [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/hi/net/aspose.slides.export/embedallfontshtmlcontroller/) के साथ HTML में फ़ॉन्ट एम्बेड करें। एम्बेडिंग दृश्य सटीकता सुधारती है लेकिन आउटपुट आकार बढ़ाती है।

```csharp
using var presentation = new Presentation("presentation.pptx");

string[] fontNamesToExclude = { "Arial", "Calibri" };
var fontController = new EmbedAllFontsHtmlController(fontNamesToExclude);
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

presentation.Save("presentation-embedded-fonts.html", SaveFormat.Html, htmlOptions);
```

केवल तब फ़ॉन्ट को बाहर रखें जब आपको भरोसा हो कि लक्ष्य ब्राउज़र या सिस्टम में वे पहले से उपलब्ध हैं। ब्रांड फ़ॉन्ट या कम सामान्य फ़ॉन्ट के लिए एम्बेडिंग आमतौर पर सुरक्षित रहती है।

## **फ़ॉन्ट फ़ाइलों को लिंक करें, एम्बेड न करें**

HTML फ़ाइल आकार घटाने के लिए, आप फ़ॉन्ट डेटा को अलग-अलग WOFF फ़ाइलों में लिख सकते हैं और HTML में `@font-face` नियम जोड़ सकते हैं। नीचे दिया गया हेल्पर [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/hi/net/aspose.slides.export/embedallfontshtmlcontroller/) को विस्तारित करता है और `WriteFont` को ओवरराइड करता है।

```cs
using var presentation = new Presentation("presentation.pptx");

var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var fontsDirectory = Path.Combine(outputDirectory, "fonts");
Directory.CreateDirectory(outputDirectory);

var fontController = new LinkedFontsHtmlController(fontsDirectory, "fonts");
var formatter = HtmlFormatter.CreateCustomFormatter(fontController);

var htmlOptions = new HtmlOptions
{
    HtmlFormatter = formatter
};

var htmlFilePath = Path.Combine(outputDirectory, "presentation.html");
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

```cs
public sealed class LinkedFontsHtmlController : EmbedAllFontsHtmlController
{
    private readonly string _fontOutputDirectory;
    private readonly string _fontUrlPrefix;

    public LinkedFontsHtmlController(
        string fontOutputDirectory,
        string fontUrlPrefix)
        : base(Array.Empty<string>())
    {
        _fontOutputDirectory = fontOutputDirectory;
        _fontUrlPrefix = fontUrlPrefix.TrimEnd('/') + "/";

        Directory.CreateDirectory(_fontOutputDirectory);
    }

    public override void WriteFont(
        IHtmlGenerator generator,
        IFontData originalFont,
        IFontData substitutedFont,
        string fontStyle,
        string fontWeight,
        byte[] fontData)
    {
        var font = substitutedFont ?? originalFont;
        var safeFontName = MakeSafeFileName(font.FontName);
        var safeFontStyle = string.IsNullOrWhiteSpace(fontStyle) ? "normal" : fontStyle;
        var safeFontWeight = string.IsNullOrWhiteSpace(fontWeight) ? "normal" : fontWeight;
        var fontFileName = $"{safeFontName}-{safeFontStyle}-{safeFontWeight}.woff";
        var fontFilePath = Path.Combine(_fontOutputDirectory, fontFileName);

        File.WriteAllBytes(fontFilePath, fontData);

        var fontUrl = _fontUrlPrefix + Uri.EscapeDataString(fontFileName);
        var fontFamily = font.FontName.Replace("\\", "\\\\").Replace("'", "\\'");

        generator.AddHtml("<style>");
        generator.AddHtml("@font-face {");
        generator.AddHtml($"font-family: '{fontFamily}';");
        generator.AddHtml($"font-style: {safeFontStyle};");
        generator.AddHtml($"font-weight: {safeFontWeight};");
        generator.AddHtml($"src: url('{fontUrl}') format('woff');");
        generator.AddHtml("}");
        generator.AddHtml("</style>");
    }

    private static string MakeSafeFileName(string fileName)
    {
        var invalidCharacters = Path.GetInvalidFileNameChars();
        var safeCharacters = fileName.ToCharArray();

        for (var characterIndex = 0; characterIndex < safeCharacters.Length; characterIndex++)
        {
            if (Array.IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = '_';
            }
        }

        return new string(safeCharacters);
    }
}
```

इस उदाहरण में, फ़ॉन्ट फ़ाइलें `html-output/fonts` में सहेजी जाती हैं, और HTML उन्हें `fonts/BrandFont-normal-400.woff` जैसे URL से संदर्भित करता है। यदि HTML फ़ाइल और फ़ॉन्ट अलग स्थान पर डिप्लॉय किए जाते हैं, तो `fontUrlPrefix` को उस डिप्लॉय URL पाथ से मेल खाने के लिए चुनें।

## **संसाधनों को बाहरी रूप से सहेजें**

स्व-समावेशी HTML ले जाना आसान है, लेकिन एम्बेडेड Base64 संसाधन फ़ाइल को बड़ा बना सकते हैं। यदि आपका एप्लिकेशन बाहरी छवि फ़ाइलों की आवश्यकता रखता है, तो [ILinkEmbedController](https://reference.aspose.com/slides/hi/net/aspose.slides.export/ilinkembedcontroller/) को लागू करें और इसे [HtmlOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/htmloptions/htmloptions/) कंस्ट्रक्टर को पास करें।

जब आप संसाधनों को बाहरी बनाते हैं, तो दो पाथ को स्पष्ट रूप से चुनें:

- फाइल सिस्टम आउटपुट पाथ, जहाँ आपका एप्लिकेशन जनरेटेड छवियों, फ़ॉन्ट, ऑडियो या वीडियो को लिखता है।
- URL पाथ, जो ब्राउज़र HTML दस्तावेज़ से उन फ़ाइलों को लोड करने के लिए उपयोग करता है।

पूरा इमेज-लिंकिंग इम्प्लीमेंटेशन के लिए देखें [Export Presentations to HTML with Externally Linked Images](/slides/hi/net/exporting-presentations-to-html-with-externally-linked-images/)।

## **मीडिया फ़ाइलें निर्यात करें**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/hi/net/aspose.slides.export/videoplayerhtmlcontroller/) वीडियो और ऑडियो फ़ाइलों को निर्यात करता है और ऐसा HTML लिखता है जो ब्राउज़र में उन्हें चलाने में सक्षम हो। इसका कंस्ट्रक्टर लेता है:

- `path`: वह डायरेक्टरी जहाँ जनरेटेड मीडिया फ़ाइलें लिखी जाएँगी।
- `fileName`: निर्मित HTML फ़ाइल का नाम।
- `baseUri`: HTML लिंक में मीडिया फ़ाइलों के लिए प्रयुक्त पूर्ण URI प्रीफ़िक्स।

यदि HTML फ़ाइल `html-output/presentation.html` है और मीडिया फ़ाइलें `html-output/media` में सहेजी गई हैं, तो `path` को डिस्क पर मीडिया डायरेक्टरी की ओर इशारा करना चाहिए, जबकि `baseUri` को ब्राउज़र के दृष्टिकोण से उसी डायरेक्टरी की ओर। स्थानीय प्रीव्यू के लिए आप मीडिया डायरेक्टरी से `file:///` URI बना सकते हैं। डिप्लॉयड एप्लिकेशन के लिए प्रकाशित मीडिया डायरेक्टरी की पूर्ण URL उपयोग करें।

```csharp
var outputDirectory = Path.Combine(Environment.CurrentDirectory, "html-output");
var mediaDirectory = Path.Combine(outputDirectory, "media");
Directory.CreateDirectory(outputDirectory);
Directory.CreateDirectory(mediaDirectory);

var htmlFileName = "presentation.html";
var mediaBaseUri = new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri;

using var presentation = new Presentation();
using var videoStream = new FileStream("intro.mp4", FileMode.Open, FileAccess.Read);

var video = presentation.Videos.AddVideo(videoStream, LoadingStreamBehavior.ReadStreamAndRelease);
var slide = presentation.Slides[0];
slide.Shapes.AddVideoFrame(20, 20, 480, 270, video);

var controller = new VideoPlayerHtmlController(mediaDirectory, htmlFileName, mediaBaseUri);
var formatter = HtmlFormatter.CreateCustomFormatter(controller);
var svgOptions = new SVGOptions(controller);
var slideImageFormat = SlideImageFormat.Svg(svgOptions);

var htmlOptions = new HtmlOptions(controller)
{
    HtmlFormatter = formatter,
    SlideImageFormat = slideImageFormat
};

var htmlFilePath = Path.Combine(outputDirectory, htmlFileName);
presentation.Save(htmlFilePath, SaveFormat.Html, htmlOptions);
```

ऐसे आउटपुट डायरेक्टरी उपयोग करें जो प्रत्येक निर्यात कार्य के लिए अद्वितीय हों, विशेषकर सर्वर एप्लिकेशन में। साझा आउटपुट पाथ्स विभिन्न रूपांतरणों की फ़ाइलों को ओवरराइट कर सकते हैं।

## **प्रदर्शन और संसाधन प्रबंधन**

HTML रूपांतरण एक रेंडरिंग ऑपरेशन है, इसलिए प्रोसेसिंग समय और मेमोरी उपयोग स्लाइड काउंट, छवि रेज़ॉल्यूशन, फ़ॉन्ट, इफ़ेक्ट, चार्ट और एम्बेडेड मीडिया पर निर्भर करता है। अधिक `PicturesCompression` DPI मान, एम्बेडेड फ़ॉन्ट, SVG आउटपुट और रखे गए कटे हुए छवि क्षेत्र फ़िडेलिटी सुधारते हैं लेकिन आमतौर पर आउटपुट आकार बढ़ाते हैं।

बैच रूपांतरण के लिए:

- प्रत्येक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) इंस्टेंस को शीघ्रता से डिस्पोज़ करें।
- अलग-अलग कार्यों के लिए अलग आउटपुट डायरेक्टरी उपयोग करें।
- सामान्य फ़ॉन्ट को तभी एम्बेड करें जब फ़िडेलिटी की आवश्यकता हो।
- जब HTML प्रीव्यू या थंबनेल के लिए हो तो छवि DPI कम करें।
- स्रोत प्रस्तुतीकरण, जनरेटेड HTML और बाहरी संसाधनों को तब तक एक साथ रखें जब तक तैनाती पाथ अंतिम न हो जाए।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या हाइपरलिंक HTML आउटपुट में संरक्षित रहते हैं?**

हां। प्रस्तुतीकरण के हाइपरलिंक HTML में निर्यात होते हैं और तब क्लिक योग्य रहते हैं जब लक्ष्य URL मान्य हो।

**क्या मैं प्रस्तुतियों को समानांतर में HTML में रूपांतरित कर सकता हूँ?**

हां, लेकिन एक [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) इंस्टेंस को थ्रेड्स के बीच साझा न करें। विभिन्न फ़ाइलों को अलग-अलग प्रस्तुतीकरण इंस्टेंस, अलग स्ट्रीम और अलग आउटपुट डायरेक्टरी के साथ प्रोसेस करें। विवरण के लिए देखें [multithreading guidance](/slides/hi/net/multithreading/)।

**क्या Presentation ऑब्जेक्ट थ्रेड-सेफ़ है?**

नहीं। एकल [Presentation](https://reference.aspose.com/slides/hi/net/aspose.slides/presentation/) इंस्टेंस को एक ही थ्रेड पर लोड, संशोधित, सहेज और डिस्पोज़ किया जाना चाहिए। समानांतर कार्य के लिए प्रत्येक थ्रेड या प्रोसेस में स्वतंत्र इंस्टेंस बनाएं।

**जनरेटेड HTML फ़ाइल बड़ी क्यों होती है?**

डिफ़ॉल्ट निर्यात संसाधनों को सीधे HTML में एम्बेड कर सकता है। एम्बेडेड फ़ॉन्ट, हाई-DPI छवियां, मीडिया, SVG कंटेंट और रखे गए कटे हुए छवि क्षेत्र भी आकार बढ़ाते हैं। छोटे आउटपुट के लिए बाहरी संसाधनों का उपयोग करें, सामान्य फ़ॉन्ट को एम्बेड न करें, और जब फ़िडेलिटी से ज़्यादा आकार महत्वपूर्ण हो तो `PicturesCompression` कम करें।

**PowerPoint में 24 pt फ़ॉन्ट आकार HTML में 17.999819 pt क्यों दिखता है?**

यह इसलिए हो सकता है क्योंकि PowerPoint और HTML अलग DPI मॉडल का उपयोग करते हैं। PowerPoint टेक्स्ट आकार 72 DPI पर टाइपोग्राफिक पॉइंट में संग्रहीत करता है, जबकि HTML लेआउट 96 DPI मॉडल में CSS पिक्सेल पर आधारित है। Aspose.Slides जब प्रस्तुतीकरण को HTML में निर्यात करता है, तो फ़ॉन्ट आकार इन प्रणालियों के बीच अनुवादित होता है, और इस परिवर्तन से छोटे राउंडिंग अंतर उत्पन्न हो सकते हैं।

ये मान वास्तविक दृश्य फ़ॉन्ट आकार परिवर्तन नहीं दर्शाते। वे केवल PowerPoint और HTML के बीच टेक्स्ट मीट्रिक्स बदलने के गणितीय परिणाम हैं।

**मीडिया निर्यात के लिए baseUri कैसे चुनें?**

`baseUri` को ब्राउज़र के दृष्टिकोण से चुनें और इसे पूर्ण URI के रूप में पास करें। स्थानीय प्रीव्यू के लिए आप आउटपुट डायरेक्टरी से `new Uri(mediaDirectory + Path.DirectorySeparatorChar).AbsoluteUri` बना सकते हैं। तैनाती के लिए प्रकाशित मीडिया डायरेक्टरी की पूर्ण URL उपयोग करें। फाइल सिस्टम `path` और ब्राउज़र `baseUri` को एक ही स्ट्रिंग होने की आवश्यकता नहीं, पर दोनों को समान संसाधन स्थान वर्णित करना चाहिए।

**क्या मैं छिपी स्लाइड्स को शामिल कर सकता हूँ?**

हां। जब छिपी स्लाइड्स को निर्यात करना हो, तो [HtmlOptions](https://reference.aspose.com/slides/hi/net/aspose.slides.export/htmloptions/) पर `ShowHiddenSlides = true` सेट करें।