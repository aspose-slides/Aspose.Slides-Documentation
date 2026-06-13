---
title: C++ में PowerPoint प्रस्तुतियों को HTML में बदलें
linktitle: PowerPoint से HTML
type: docs
weight: 30
url: /hi/cpp/convert-powerpoint-to-html/
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
- C++
- Aspose.Slides
description: "C++ में PowerPoint प्रस्तुतियों को HTML में बदलें। PPT और PPTX फ़ाइलों, चयनित स्लाइड्स, नोट्स, फ़ॉन्ट, छवियों, SVG और मीडिया को निर्यात करने के लिये Aspose.Slides का उपयोग करें।"
---
## **अवलोकन**

Aspose.Slides for C++ Microsoft PowerPoint के बिना PowerPoint प्रस्तुतियों को HTML के रूप में सहेज सकता है। बुनियादी रूपांतरण एकल [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) लोड और `Save` कॉल के साथ [SaveFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/saveformat/) है। जब आपको निर्यातित लेआउट, फ़ॉन्ट, छवियों, नोट्स, टिप्पणियों, SVG आउटपुट या लिंक्ड संसाधनों को नियंत्रित करने की आवश्यकता हो तो [HtmlOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/htmloptions/) का उपयोग करें।

यह गाइड व्यावहारिक HTML निर्यात परिदृश्यों पर केंद्रित है:

- पूरी प्रस्तुति या चयनित स्लाइड्स को निर्यात करें।
- स्थिर‑लेआउट, उत्तरदायी या SVG‑आधारित HTML उत्पन्न करें।
- वक्ता नोट्स और टिप्पणियाँ शामिल करें।
- छवि गुणवत्ता और क्रॉप्ड छवि डेटा को नियंत्रित करें।
- फ़ॉन्ट एम्बेड करें या फ़ॉन्ट फ़ाइलें अलग से सहेजें।
- बाहरी संसाधनों और मीडिया फ़ाइलों को कैसे लिखा और संदर्भित किया जाए चुनें।

डिफ़ॉल्ट रूप से, HTML निर्यात एक स्व-निहित HTML दस्तावेज़ बनाता है जहाँ अधिकांश संसाधन एम्बेड होते हैं। यह एक फ़ाइल साझा करने में सुविधाजनक है, लेकिन आउटपुट आकार बढ़ा सकता है। वेब प्रकाशन के लिए, बाहरी संसाधनों, कम छवि DPI, और उन फ़ॉन्टों को एम्बेड करने पर विचार करें जो लक्ष्य वातावरण में विश्वसनीय रूप से उपलब्ध नहीं हैं।

## **Presentation को HTML में बदलें**

एक प्रस्तुति को HTML में निर्यात करने के लिए, इसे [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) से लोड करें और `SaveFormat::Html` के साथ सहेजें।

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->Save(u"presentation.html", SaveFormat::Html);

presentation->Dispose();
```

यह उदाहरण एक HTML फ़ाइल लिखता है। `Dispose` को कॉल करने से निर्यात के बाद फ़ाइल हैंडल और रेंडरिंग संसाधन मुक्त हो जाते हैं।

## **HtmlOptions का उपयोग करें**

[HtmlOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/htmloptions/) HTML निर्यात के लिए मुख्य कॉन्फ़िगरेशन क्लास है। सामान्य सेटिंग्स में शामिल हैं:

- `SlidesLayoutOptions`: नोट्स, टिप्पणियाँ, हैंडआउट्स या अन्य लेआउट जानकारी जोड़ते हैं।
- `HtmlFormatter`: HTML दस्तावेज़ संरचना बदलता है या फ़ॉर्मेटिंग को नियंत्रक को सौंपता है।
- `SlideImageFormat`: स्लाइड्स को कैसे दर्शाया जाए बदलता है, उदाहरण के लिए SVG के रूप में।
- `PicturesCompression`: छवि DPI और आउटपुट आकार को नियंत्रित करता है।
- `DeletePicturesCroppedAreas`: क्रॉप्ड छवि डेटा को रखता या हटाता है।
- `SvgResponsiveLayout`: निर्यातित SVG सामग्री को उसके कंटेनर के अनुसार अनुकूल बनाता है।
- `ShowHiddenSlides`: आवश्यकता होने पर छुपी स्लाइड्स को शामिल करता है।

निम्नलिखित अनुभाग सबसे सामान्य विकल्पों को अलग‑अलग दिखाते हैं ताकि आप केवल उन विकल्पों को संयोजित कर सकें जो आपके वर्कफ़्लो को आवश्यक हैं।

## **चयनित स्लाइड्स को HTML में बदलें**

`Presentation::Save` ओवरलोड जो स्लाइड नंबर लेता है, 1‑आधारित स्लाइड स्थितियों का उपयोग करता है। नीचे दिया गया लूप प्रत्येक स्लाइड को अलग HTML फ़ाइल में सहेजता है।

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slideCount = presentation->get_Slides()->get_Count();

for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slideNumber = slideIndex + 1;
    auto slideNumbers = System::MakeArray<int>({ slideNumber });
    auto htmlFileName = System::String::Format(u"slide-{0}.html", slideNumber);

    presentation->Save(htmlFileName, slideNumbers, SaveFormat::Html);
}

presentation->Dispose();
```

जब कोई वेब साइट या एप्लिकेशन प्रति स्लाइड एक HTML पेज चाहिए तब इस पैटर्न का उपयोग करें। यदि प्रत्येक स्लाइड को समान लेआउट चाहिए, तो एक ही [HtmlOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/htmloptions/) इंस्टेंस बनाएँ और इसे प्रत्येक `Save` कॉल में पास करें।

## **उत्तरदायी HTML बनाएं**

[ResponsiveHtmlController](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/responsivehtmlcontroller/) [HtmlFormatter](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/htmlformatter/) के माध्यम से उत्तरदायी HTML आउटपुट प्रदान करता है। जब निर्यातित पेज को ब्राउज़र की चौड़ाई के अनुसार बेहतर अनुकूल होना चाहिए तो इसका उपयोग करें।

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto controller = System::MakeObject<ResponsiveHtmlController>();
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

SVG‑आधारित उत्तरदायी लेआउट के लिए, [HtmlOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/htmloptions/) पर `SvgResponsiveLayout` सेट करें। यह उपयोगी है जब स्लाइड सामग्री को स्केलेबल SVG मार्कअप के रूप में निर्यात किया जाता है।

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SvgResponsiveLayout(true);

presentation->Save(u"presentation-svg-responsive.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **वक्ता नोट्स और टिप्पणियों को शामिल करें**

वक्ता नोट्स या टिप्पणियों को शामिल करने के लिए `HtmlOptions.SlidesLayoutOptions` के माध्यम से [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/notescommentslayoutingoptions/) उपयोग करें। नोट्स और टिप्पणियाँ डिफ़ॉल्ट रूप से छिपी रहती हैं जब तक आप उनकी स्थितियों को निर्धारित न करें।

मान लीजिए स्रोत प्रस्तुति में वक्ता नोट्स हैं:

![Slide with speaker notes in PowerPoint](slide_with_notes.png)

निम्नलिखित कोड स्लाइड सामग्री को स्लाइड के नीचे वक्ता नोट्स के साथ निर्यात करता है।

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto layoutOptions = System::MakeObject<NotesCommentsLayoutingOptions>();
layoutOptions->set_NotesPosition(NotesPositions::BottomFull);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_SlidesLayoutOptions(layoutOptions);

presentation->Save(u"presentation-with-notes.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

निर्यातित HTML में नोट्स क्षेत्र शामिल होता है:

![HTML output with the slide and speaker notes](HTML_with_notes.png)

टिप्पणियों को निर्यात करने के लिए `CommentsPosition` सेट करें, उदाहरण के लिए `CommentsPositions::Right` या `CommentsPositions::Bottom`। यदि केवल टिप्पणियाँ चाहिए तो `NotesPosition` को छोड़ दें। यदि दोनों चाहिए तो दोनों गुण सेट करें।

## **छवि गुणवत्ता और क्रॉप्ड क्षेत्रों को नियंत्रित करें**

HTML निर्यात स्लाइड छवियों को संकुचित करके आउटपुट आकार कम कर सकता है। जब आपको उच्च छवि गुणवत्ता चाहिए तो [PicturesCompression](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/picturescompression/) में से एक मान `PicturesCompression` को सेट करें।

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_PicturesCompression(PicturesCompression::Dpi150);

presentation->Save(u"presentation-dpi-150.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

डिफ़ॉल्ट रूप से, छवियों के क्रॉप्ड क्षेत्रों को निर्यातित आउटपुट से हटाया जा सकता है। केवल तब क्रॉप्ड डेटा रखें जब उपयोगकर्ताओं को उन छिपे हुए भागों को पुनः प्राप्त या निरीक्षण करने की आवश्यकता हो। इसे रखने से HTML आकार बढ़ सकता है।

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_DeletePicturesCroppedAreas(false);

presentation->Save(u"presentation-with-cropped-areas.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

## **CSS जोड़ें**

सरल स्टाइलिंग के लिए `HtmlFormatter::CreateDocumentFormatter` को CSS स्ट्रिंग पास करें। यह Aspose.Slides द्वारा स्लाइड सामग्री रेंडर रहना जारी रखते हुए आसपास का HTML दस्तावेज़ बदलता है।

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto cssRules = u"body { margin: 0; background: #f7f7f7; } .slide { margin: 24px auto; }";
auto formatter = HtmlFormatter::CreateDocumentFormatter(cssRules, true);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-styled.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

कस्टम दस्तावेज़ हेडर, लिंक्ड CSS फ़ाइल, या स्लाइड्स और शेप्स के चारों ओर कस्टम मार्कअप के लिए, [IHtmlFormattingController](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/ihtmlformattingcontroller/) को लागू करें और उसे [HtmlFormatter](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/htmlformatter/) के साथ `CreateCustomFormatter` से पास करें।

## **फ़ॉन्ट एम्बेड करें**

यदि लक्ष्य वातावरण में प्रस्तुति के फ़ॉन्ट स्थापित नहीं हैं, तो [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/embedallfontshtmlcontroller/) के साथ HTML में फ़ॉन्ट एम्बेड करें। एम्बेडिंग दृश्य फ़िडेलिटी सुधारता है लेकिन आउटपुट आकार बढ़ाता है।

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontNamesToExclude = System::MakeArray<System::String>({ u"Arial" });
auto fontController = System::MakeObject<EmbedAllFontsHtmlController>(fontNamesToExclude);
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

presentation->Save(u"presentation-embedded-fonts.html", SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

केवल तब फ़ॉन्ट को बाहर रखें जब आप आश्वस्त हों कि लक्ष्य ब्राउज़र या सिस्टम में वे पहले से उपलब्ध हैं। ब्रांड फ़ॉन्ट या कम सामान्य फ़ॉन्ट के लिए एम्बेडिंग आम तौर पर सुरक्षित रहता है।

## **फ़ॉन्ट फ़ाइलों को लिंक करें, एम्बेड न करें**

HTML फ़ाइल आकार घटाने के लिए फ़ॉन्ट डेटा को अलग‑फ़ाइल WOFF में लिखें और HTML में `@font-face` नियम जोड़ें। नीचे दिया गया हेल्पर [EmbedAllFontsHtmlController](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/embedallfontshtmlcontroller/) को विस्तारित करता है और `WriteFont` को ओवरराइड करता है।

```cpp
class LinkedFontsHtmlController : public EmbedAllFontsHtmlController
{
public:
    LinkedFontsHtmlController(
        System::String fontOutputDirectory,
        System::String fontUrlPrefix)
        : EmbedAllFontsHtmlController(System::MakeArray<System::String>(0)),
          m_fontOutputDirectory(fontOutputDirectory),
          m_fontUrlPrefix(fontUrlPrefix.TrimEnd(u'/') + u"/")
    {
        System::IO::Directory::CreateDirectory_(m_fontOutputDirectory);
    }

    void WriteFont(
        System::SharedPtr<IHtmlGenerator> generator,
        System::SharedPtr<IFontData> originalFont,
        System::SharedPtr<IFontData> substitutedFont,
        System::String fontStyle,
        System::String fontWeight,
        System::ArrayPtr<uint8_t> fontData) override
    {
        auto font = substitutedFont == nullptr ? originalFont : substitutedFont;
        auto safeFontName = MakeSafeFileName(font->get_FontName());
        auto safeFontStyle = System::String::IsNullOrWhiteSpace(fontStyle) ? u"normal" : fontStyle;
        auto safeFontWeight = System::String::IsNullOrWhiteSpace(fontWeight) ? u"normal" : fontWeight;
        auto fontFileName = System::String::Format(u"{0}-{1}-{2}.woff", safeFontName, safeFontStyle, safeFontWeight);
        auto fontFilePath = System::IO::Path::Combine(m_fontOutputDirectory, fontFileName);

        System::IO::File::WriteAllBytes(fontFilePath, fontData);

        auto fontUrl = m_fontUrlPrefix + System::Uri::EscapeDataString(fontFileName);
        auto fontFamily = font->get_FontName().Replace(u"\\", u"\\\\").Replace(u"'", u"\\'");

        generator->AddHtml(u"<style>");
        generator->AddHtml(u"@font-face {");
        generator->AddHtml(System::String::Format(u"font-family: '{0}';", fontFamily));
        generator->AddHtml(System::String::Format(u"font-style: {0};", safeFontStyle));
        generator->AddHtml(System::String::Format(u"font-weight: {0};", safeFontWeight));
        generator->AddHtml(System::String::Format(u"src: url('{0}') format('woff');", fontUrl));
        generator->AddHtml(u"}");
        generator->AddHtml(u"</style>");
    }

private:
    System::String m_fontOutputDirectory;
    System::String m_fontUrlPrefix;

    System::String MakeSafeFileName(System::String fileName)
    {
        auto invalidCharacters = System::IO::Path::GetInvalidFileNameChars();
        auto safeCharacters = fileName.ToCharArray();

        for (int characterIndex = 0; characterIndex < safeCharacters->get_Length(); characterIndex++)
        {
            if (System::Array<int16_t>::IndexOf(invalidCharacters, safeCharacters[characterIndex]) >= 0)
            {
                safeCharacters[characterIndex] = u'_';
            }
        }

        return System::String(safeCharacters);
    }
};

auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto fontsDirectory = System::IO::Path::Combine(outputDirectory, u"fonts");
System::IO::Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto fontController = System::MakeObject<LinkedFontsHtmlController>(fontsDirectory, u"fonts");
auto formatter = HtmlFormatter::CreateCustomFormatter(fontController);

auto htmlOptions = System::MakeObject<HtmlOptions>();
htmlOptions->set_HtmlFormatter(formatter);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, u"presentation.html");
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

presentation->Dispose();
```

इस उदाहरण में फ़ॉन्ट फ़ाइलें `html-output/fonts` में सहेजी जाती हैं, और HTML उन्हें `fonts/BrandFont-normal-400.woff` जैसे URL से संदर्भित करता है। यदि HTML फ़ाइल और फ़ॉन्ट किसी अन्य स्थान पर तैनात होते हैं, तो `fontUrlPrefix` को उस तैनात URL पाथ से मेल खाता चुनें।

## **संसाधनों को बाहरी रूप से सहेजें**

स्व‑निहित HTML को ले जाना आसान है, लेकिन एम्बेडेड Base64 संसाधन फ़ाइल को बड़ा बना सकते हैं। यदि आपका एप्लिकेशन बाहरी छवि फ़ाइलों की आवश्यकता रखता है, तो [ILinkEmbedController](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/ilinkembedcontroller/) को लागू करें और इसे [HtmlOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/htmloptions/) कंस्ट्रक्टर को पास करें।

जब आप संसाधनों को बाहरी बनाते हैं, तो दो पाथ स्पष्ट रूप से चुनें:

- फ़ाइल‑सिस्टम आउटपुट पाथ, जहाँ आपका एप्लिकेशन उत्पन्न छवियों, फ़ॉन्ट्स, ऑडियो या वीडियो लिखता है।
- URL पाथ, जो ब्राउज़र HTML दस्तावेज़ से उन फ़ाइलों को लोड करने के लिये उपयोग करता है।

## **मीडिया फ़ाइलें निर्यात करें**

[VideoPlayerHtmlController](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/videoplayerhtmlcontroller/) वीडियो और ऑडियो फ़ाइलें निर्यात करता है और ऐसा HTML लिखता है जो ब्राउज़र में चल सके। इसका कंस्ट्रक्टर लेता है:

- `path`: वह डायरेक्टरी जहाँ उत्पन्न मीडिया फ़ाइलें लिखी जाएँगी।
- `fileName`: उत्पन्न होने वाली HTML फ़ाइल का नाम।
- `baseUri`: HTML लिंक में मीडिया फ़ाइलों के लिये प्रयुक्त पूर्ण URI उपसर्ग।

यदि HTML फ़ाइल `html-output/presentation.html` है और मीडिया फ़ाइलें `html-output/media` में सहेजी गई हैं, तो `path` डिस्क पर मीडिया डायरेक्टरी की ओर संकेत करे, जबकि `baseUri` ब्राउज़र के दृष्टिकोण से उसी डायरेक्टरी की ओर संकेत करे। स्थानीय पूर्वावलोकन के लिये, आप मीडिया डायरेक्टरी से `file:///` URI बना सकते हैं। तैनात एप्लिकेशन के लिये, प्रकाशित मीडिया डायरेक्टरी के पूर्ण URL का उपयोग करें।

```cpp
auto outputDirectory = System::IO::Path::Combine(System::Environment::get_CurrentDirectory(), u"html-output");
auto mediaDirectory = System::IO::Path::Combine(outputDirectory, u"media");
System::IO::Directory::CreateDirectory_(outputDirectory);
System::IO::Directory::CreateDirectory_(mediaDirectory);

auto htmlFileName = u"presentation.html";
auto mediaBaseUri = System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri();

auto presentation = System::MakeObject<Presentation>();
auto videoStream = System::MakeObject<System::IO::FileStream>(u"intro.mp4", System::IO::FileMode::Open, System::IO::FileAccess::Read);

auto video = presentation->get_Videos()->AddVideo(videoStream, LoadingStreamBehavior::ReadStreamAndRelease);
auto slide = presentation->get_Slide(0);
slide->get_Shapes()->AddVideoFrame(20.0f, 20.0f, 480.0f, 270.0f, video);

auto controller = System::MakeObject<VideoPlayerHtmlController>(mediaDirectory, htmlFileName, mediaBaseUri);
auto formatter = HtmlFormatter::CreateCustomFormatter(controller);
auto svgOptions = System::MakeObject<SVGOptions>(controller);
auto slideImageFormat = SlideImageFormat::Svg(svgOptions);

auto htmlOptions = System::MakeObject<HtmlOptions>(controller);
htmlOptions->set_HtmlFormatter(formatter);
htmlOptions->set_SlideImageFormat(slideImageFormat);

auto htmlFilePath = System::IO::Path::Combine(outputDirectory, htmlFileName);
presentation->Save(htmlFilePath, SaveFormat::Html, htmlOptions);

videoStream->Dispose();
presentation->Dispose();
```

ऐसे आउटपुट डायरेक्टरी उपयोग करें जो प्रत्येक निर्यात कार्य के लिये अद्वितीय हों, विशेषकर सर्वर एप्लिकेशन में। साझा आउटपुट पाथ अलग‑अलग रूपांतरणों की फ़ाइलों को एक‑दूसरे के ऊपर लिखने का कारण बन सकते हैं।

## **प्रदर्शन और संसाधन प्रबंधन**

HTML रूपांतरण एक रेंडरिंग प्रक्रिया है, इसलिए प्रोसेसिंग समय और मेमोरी उपयोग स्लाइड संख्या, छवि रिज़ॉल्यूशन, फ़ॉन्ट, इफ़ेक्ट, चार्ट और एम्बेडेड मीडिया पर निर्भर करता है। उच्च `PicturesCompression` DPI मान, एम्बेडेड फ़ॉन्ट, SVG आउटपुट और बनाए रखे गए क्रॉप्ड छवि क्षेत्रों से फ़िडेलिटी बढ़ती है लेकिन आम तौर पर आउटपुट आकार बढ़ता है।

बैच रूपांतरण के लिये:

- प्रत्येक [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) इंस्टेंस को तुरंत `Dispose` करें।
- अलग‑अलग कार्यों के लिये अलग आउटपुट डायरेक्टरी उपयोग करें।
- सामान्य फ़ॉन्ट को तब तक एम्बेड न करें जब तक फ़िडेलिटी की आवश्यकता न हो।
- जब HTML प्रीव्यू या थंबनेल के लिये हो तो छवि DPI कम रखें।
- स्रोत प्रस्तुति, उत्पन्न HTML, और बाहरी संसाधनों को तब तक एक साथ रखें जब तक परिनियोजन पाथ अंतिम न हो जाएँ।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या हाइपरलिंक HTML आउटपुट में बना रहता है?**

हां। प्रस्तुति के हाइपरलिंक HTML में निर्यात होते हैं और लक्ष्य URL वैध होने पर क्लिक करने योग्य रहते हैं।

**क्या मैं प्रस्तुतियों को समानांतर रूप से HTML में बदल सकता हूं?**

हां, लेकिन एक ही [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) इंस्टेंस को थ्रेड्स के बीच साझा न करें। अलग‑अलग फ़ाइलों को अलग‑अलग प्रस्तुति इंस्टेंस, अलग‑अलग स्ट्रीम, और अलग‑अलग आउटपुट डायरेक्टरी के साथ प्रोसेस करें। विस्तृत जानकारी के लिये [multithreading guidance](/slides/hi/cpp/multithreading/) देखें।

**क्या Presentation ऑब्जेक्ट थ्रेड‑सेफ है?**

नहीं। एक ही [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) इंस्टेंस को केवल एक थ्रेड पर लोड, संशोधित, सहेज और `Dispose` किया जाना चाहिए। समानांतर कार्य के लिये प्रत्येक थ्रेड या प्रक्रिया के लिये स्वतंत्र इंस्टेंस बनाएँ।

**निर्मित HTML फ़ाइल बड़ी क्यों है?**

डिफ़ॉल्ट निर्यात संसाधनों को सीधे HTML में एम्बेड करता है। एम्बेडेड फ़ॉन्ट, उच्च‑DPI छवियाँ, मीडिया, SVG सामग्री और बनाए रखे गए क्रॉप्ड छवि क्षेत्र भी आकार बढ़ाते हैं। छोटे आउटपुट के लिए बाहरी संसाधनों का उपयोग करें, सामान्य फ़ॉन्ट को एम्बेड न करें, और जब अधिकतम फ़िडेलिटी से कम महत्व हो तो `PicturesCompression` को कम करें।

**PowerPoint में 24 pt फ़ॉन्ट आकार HTML में 17.999819 pt क्यों दिखता है?**

यह इसलिए हो सकता है क्योंकि PowerPoint और HTML अलग‑अलग DPI मॉडल का उपयोग करते हैं। PowerPoint 72 DPI पर आधारित टाइपोग्राफ़िक पॉइंट में टेक्स्ट आकार सहेजता है, जबकि HTML लेआउट CSS पिक्सेल पर आधारित 96 DPI मॉडल पर होता है। जब Aspose.Slides प्रस्तुति को HTML में निर्यात करता है, तो फ़ॉन्ट आकार को इन दो सिस्टमों के बीच अनुवादित किया जाता है, और यह परिवर्तन छोटे राउंडिंग अंतर उत्पन्न कर सकता है।

इन मानों से वास्तविक दृश्य फ़ॉन्ट‑साइज़ परिवर्तन नहीं दर्शाया जाता। ये केवल PowerPoint और HTML के बीच टेक्स्ट मेट्रिक रूपांतरण के गणितीय साइड इफ़ेक्ट हैं।

**मीडिया निर्यात के लिये baseUri कैसे चुनें?**

`baseUri` को ब्राउज़र के दृष्टिकोण से चुनें और इसे पूर्ण URI के रूप में पास करें। स्थानीय पूर्वावलोकन के लिये, आप इसे आउटपुट डायरेक्टरी से `System::MakeObject<System::Uri>(mediaDirectory + System::IO::Path::DirectorySeparatorChar)->get_AbsoluteUri()` द्वारा बना सकते हैं। परिनियोजन के लिये, प्रकाशित मीडिया डायरेक्टरी के पूर्ण URL का उपयोग करें। फ़ाइल‑सिस्टम `path` और ब्राउज़र `baseUri` को समान स्ट्रिंग होने की आवश्यकता नहीं है, लेकिन दोनों को समान संसाधन स्थान का वर्णन करना चाहिए।

**क्या मैं छुपी स्लाइड्स को शामिल कर सकता हूं?**

हां। जब छुपी स्लाइड्स को निर्यात करना आवश्यक हो, तो [HtmlOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/htmloptions/) पर `ShowHiddenSlides` को `true` सेट करें।