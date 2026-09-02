---
title: "C++ का उपयोग करके प्रस्तुतियों में छवि प्रबंधन को अनुकूलित करें"
linktitle: "छवियों का प्रबंधन"
type: docs
weight: 10
url: /hi/cpp/image/
keywords:
- "छवि जोड़ें"
- "चित्र जोड़ें"
- "बिटमैप जोड़ें"
- "छवि बदलें"
- "चित्र बदलें"
- "वेब से"
- "पृष्ठभूमि"
- "PNG जोड़ें"
- "JPG जोड़ें"
- "SVG जोड़ें"
- "बाहरी SVG संसाधन"
- "SVG रिजॉल्वर"
- "लिंक्ड SVG चित्र"
- "SVG फ़ॉन्ट"
- "EMF जोड़ें"
- "WMF जोड़ें"
- "TIFF जोड़ें"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides for C++ के साथ PowerPoint और OpenDocument में छवि प्रबंधन को सरल बनाएं, प्रदर्शन को अनुकूलित करें और अपने कार्यफ़्लो को स्वचालित करें।"
---
## **परिचय**

छवियां प्रस्तुतियों को अधिक आकर्षक और दृश्य रूप से आकर्षक बनाती हैं। Microsoft PowerPoint में, आप फ़ाइलों, इंटरनेट या अन्य स्रोतों से स्लाइड पर चित्र सम्मिलित कर सकते हैं। इसी प्रकार, Aspose.Slides आपको कई तरीकों से प्रस्तुति स्लाइड में चित्र जोड़ने की अनुमति देता है। 

{{% alert title="Tip" color="primary" %}} 

Aspose मुफ्त कनवर्टर प्रदान करता है—[JPEG to PowerPoint](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG to PowerPoint](https://products.aspose.app/slides/hi/import/png-to-ppt)—जो आपको चित्रों से शीघ्रता से प्रस्तुतियां बनाने की सुविधा देते हैं। 

{{% /alert %}} 

{{% alert title="Info" color="info" %}}

यदि आप किसी चित्र को पिक्चर फ्रेम के रूप में जोड़ना चाहते हैं—विशेषकर यदि आप इसका आकार बदलने, प्रभाव लागू करने, या अन्य मानक फ़ॉर्मेटिंग विकल्पों का उपयोग करने की योजना बना रहे हैं—देखें [Picture Frame](/slides/hi/cpp/picture-frame/). 

{{% /alert %}} 

{{% alert title="Note" color="warning" %}}

आप एक फ़ॉर्मेट से दूसरे फ़ॉर्मेट में चित्रों को परिवर्तित कर सकते हैं। निम्नलिखित पृष्ठ देखें: [image to JPG](https://products.aspose.com/slides/hi/cpp/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/hi/cpp/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/hi/cpp/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/hi/cpp/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/hi/cpp/conversion/png-to-svg/), तथा [SVG to PNG](https://products.aspose.com/slides/hi/cpp/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides JPEG, PNG, BMP, GIF और अन्य लोकप्रिय फ़ॉर्मेट में चित्रों का समर्थन करता है। 

## **स्थानीय रूप से संग्रहीत चित्रों को स्लाइड्स में जोड़ें**

आप अपने कंप्यूटर पर संग्रहीत एक या अधिक चित्रों को प्रस्तुति स्लाइड में जोड़ सकते हैं। निम्नलिखित C++ नमूना कोड दिखाता है कि स्लाइड में चित्र कैसे जोड़ें:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();

auto slide = pres->get_Slides()->idx_get(0);
auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **वेब से चित्र स्लाइड्स में जोड़ें**

यदि आप जिस चित्र को स्लाइड में जोड़ना चाहते हैं वह आपके कंप्यूटर पर संग्रहीत नहीं है, तो आप इसे सीधे वेब से जोड़ सकते हैं। 

निम्नलिखित C++ नमूना कोड दिखाता है कि वेब से चित्र कैसे जोड़ें:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <net/web_client.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);

auto webClient = System::MakeObject<System::Net::WebClient>();
auto imageData = webClient->DownloadData(System::MakeObject<Uri>(u"[REPLACE WITH URL]"));

auto image = pres->get_Images()->AddImage(imageData);
slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **स्लाइड मास्टर्स में चित्र जोड़ें**

एक स्लाइड मास्टर उन स्लाइड्स के लिए थीम और लेआउट जैसी जानकारी संचित और नियंत्रित करता है जो इसका उपयोग करती हैं। जब आप एक स्लाइड मास्टर में चित्र जोड़ते हैं, तो वह चित्र उस मास्टर पर आधारित प्रत्येक स्लाइड पर दिखाई देता है। 

निम्नलिखित C++ नमूना कोड दिखाता है कि स्लाइड मास्टर में चित्र कैसे जोड़ें:

``` cpp
#include <DOM/IImageCollection.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto masterSlide = slide->get_LayoutSlide()->get_MasterSlide();

auto image = pres->get_Images()->AddImage(File::ReadAllBytes(u"image.png"));
masterSlide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f, image);

pres->Save(u"pres.pptx", SaveFormat::Pptx);
```

## **स्लाइड बैकग्राउंड के रूप में चित्र जोड़ें**

आप एक या अधिक स्लाइड्स के लिए पृष्ठभूमि के रूप में चित्र का उपयोग कर सकते हैं। विवरण के लिए देखें *[Setting Images as Backgrounds for Slides](/slides/hi/cpp/presentation-background/#setting-images-as-background-for-slides)*।

## **प्रेजेंटेशन में SVG जोड़ें**

SVG सामग्री को एक प्रस्तुति में जोड़ने के लिए आप [SvgImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/svgimage/) क्लास का उपयोग कर सकते हैं। परिणामस्वरूप [ISvgImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isvgimage/) ऑब्जेक्ट को फिर प्रस्तुति की इमेज कलेक्शन में जोड़कर पिक्चर फ्रेम बनाया जा सकता है।

निम्नलिखित C++ उदाहरण एक स्वसंकुलित SVG स्ट्रिंग आयात करता है। इस SVG द्वारा उपयोग की गई सभी चित्र, शैलियां और अन्य संसाधन सीधे SVG सामग्री में एम्बेड किए जाते हैं।

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto svgContent = String(uR"(
<svg xmlns='http://www.w3.org/2000/svg' width='320' height='180'>
    <rect width='320' height='180' fill='#4F81BD'/>
    <circle cx='160' cy='90' r='55' fill='#F2F2F2'/>
</svg>)");

auto presentation = MakeObject<Presentation>();
auto svgImage = MakeObject<SvgImage>(svgContent);
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"self-contained-svg.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **बाहरी संसाधनों के साथ SVG सामग्री आयात करें**

ऐसी SVG सामग्री आयात करने के लिए, एक [IExternalResourceResolver](https://reference.aspose.com/slides/hi/cpp/aspose.slides.import/iexternalresourceresolver/) कार्यान्वयन बनाएं और इसे बेस URI के साथ उचित `SvgImage` कंस्ट्रक्टर को पास करें। बेस URI SVG दस्तावेज़ का स्थान निर्धारित करता है और सापेक्ष लिंक्स को हल करने के लिए उपयोग होता है।

[ISvgImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isvgimage/) इंटरफेस आयातित SVG के बारे में जानकारी तक पहुंच प्रदान करता है:

- `get_SvgContent()` SVG मार्कअप को स्ट्रिंग के रूप में लौटाता है।
- `get_SvgData()` SVG सामग्री को बाइट एरे के रूप में लौटाता है।
- `get_BaseUri()` सापेक्ष लिंक्स के लिए प्रयुक्त बेस URI लौटाता है।
- `get_ExternalResourceResolver()` SVG चित्र को सौंपे गए रिजॉल्वर को लौटाता है।

### **बाहरी संसाधन रिजॉल्वर को लागू करें**

रिजॉल्वर के दो मेथड हैं:

- [ResolveUri](https://reference.aspose.com/slides/hi/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) बेस URI और सापेक्ष संसाधन लिंक को संयोजित कर एक पूर्ण (absolute) URI लौटाता है। जब लिंक को हल नहीं किया जा सकता या अनुमति नहीं है तो null स्ट्रिंग लौटाएँ।
- [GetEntity](https://reference.aspose.com/slides/hi/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) पूर्ण संसाधन URI के लिए एक पढ़ने योग्य स्ट्रीम लौटाता है। जब संसाधन अनुपलब्ध, अवरुद्ध या नहीं मिला हो तो `nullptr` लौटाएँ। उपयुक्त होने पर एक फॉलबैक स्ट्रीम भी लौटाई जा सकती है।

निम्नलिखित रिजॉल्वर लिंक्ड संसाधनों को केवल अनुमत स्थानीय निर्देशिका से लोड करता है। नेटवर्क संसाधन और अनुमत निर्देशिका के बाहर के पाथ अवरुद्ध हैं। एक वैकल्पिक फॉलबैक चित्र अनसुलझे चित्र लिंक के लिए लौटाया जाता है।

```cpp
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/io/file.h>
#include <system/io/memory_stream.h>
#include <system/io/path.h>
#include <system/io/stream.h>
#include <system/string.h>
#include <system/smart_ptr.h>
#include <system/string_comparison.h>
#include <system/uri.h>

using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

class LocalSvgResourceResolver : public IExternalResourceResolver
{
public:
    LocalSvgResourceResolver(String allowedRoot, ArrayPtr<uint8_t> fallbackImageData = nullptr)
        : _allowedRoot(Path::GetFullPath(allowedRoot)),
          _fallbackImageData(fallbackImageData)
    {
    }

    String ResolveUri(String baseUri, String relativeUri) override
    {
        if (String::IsNullOrWhiteSpace(baseUri) ||
            String::IsNullOrWhiteSpace(relativeUri))
        {
            return String::Null;
        }

        auto baseAddress = SharedPtr<Uri>();
        auto absoluteAddress = SharedPtr<Uri>();
        if (!Uri::TryCreate(baseUri, UriKind::Absolute, baseAddress) ||
            !Uri::TryCreate(baseAddress, relativeUri, absoluteAddress))
        {
            return String::Null;
        }

        // यह रिजॉल्वर जानबूझकर केवल स्थानीय फ़ाइलों की अनुमति देता है।
        if (!absoluteAddress->get_IsFile())
        {
            return String::Null;
        }

        auto resourcePath = Path::GetFullPath(absoluteAddress->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return String::Null;
        }

        return absoluteAddress->get_AbsoluteUri();
    }

    SharedPtr<Stream> GetEntity(String absoluteUri) override
    {
        auto resourceUri = SharedPtr<Uri>();
        if (!Uri::TryCreate(absoluteUri, UriKind::Absolute, resourceUri) ||
            !resourceUri->get_IsFile())
        {
            return nullptr;
        }

        auto resourcePath = Path::GetFullPath(resourceUri->get_LocalPath());
        if (!IsInsideAllowedRoot(resourcePath))
        {
            return nullptr;
        }

        if (File::Exists(resourcePath))
        {
            return File::OpenRead(resourcePath);
        }

        // केवल चित्र संसाधनों के लिए फॉलबैक का उपयोग करें। एक छवि स्ट्रीम लौटाना
        // गुम फ़ॉन्ट या स्टाइलशीट के लिए मान्य नहीं होगा।
        if (_fallbackImageData != nullptr && IsImageFile(resourcePath))
        {
            return MakeObject<MemoryStream>(_fallbackImageData, false);
        }

        return nullptr;
    }

private:
    String _allowedRoot;
    ArrayPtr<uint8_t> _fallbackImageData;

    bool IsInsideAllowedRoot(String resourcePath)
    {
        auto normalizedRoot = _allowedRoot;
        auto directorySeparator = String(Path::DirectorySeparatorChar, 1);
        if (!normalizedRoot.EndsWith(directorySeparator))
        {
            normalizedRoot += directorySeparator;
        }

        auto normalizedPath = Path::GetFullPath(resourcePath);
        auto comparison = Path::DirectorySeparatorChar == u'\\'
            ? StringComparison::OrdinalIgnoreCase
            : StringComparison::Ordinal;

        return normalizedPath.StartsWith(normalizedRoot, comparison) ||
               String::Equals(normalizedPath, _allowedRoot, comparison);
    }

    static bool IsImageFile(String path)
    {
        auto extension = Path::GetExtension(path);

        return String::Equals(extension, u".png", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".jpeg", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".gif", StringComparison::OrdinalIgnoreCase) ||
               String::Equals(extension, u".bmp", StringComparison::OrdinalIgnoreCase);
    }
};
```

### **SVG आयात के दौरान लिंक्ड संसाधनों को हल करें**

मान लें कि `assets/diagram.svg` में एक सापेक्ष संदर्भ इस प्रकार है:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

निम्नलिखित C++ उदाहरण SVG फ़ाइल URI को बेस URI के रूप में पास करता है और एक कस्टम रिजॉल्वर प्रदान करता है। रिजॉल्वर सापेक्ष चित्र लिंक को पूर्ण URI में परिवर्तित करता है तथा Aspose.Slides SVG को प्रोसेस करते समय लिंक्ड संसाधन वाली स्ट्रीम लौटाता है।

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <Import/IExternalResourceResolver.h>
#include <system/array.h>
#include <system/environment.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/string.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Import;
using namespace System;
using namespace System::IO;

auto svgFilePath = Path::GetFullPath(Path::Combine(u"assets", u"diagram.svg"));
auto assetDirectory = Path::GetDirectoryName(svgFilePath);
if (String::IsNullOrEmpty(assetDirectory))
{
    assetDirectory = Environment::get_CurrentDirectory();
}

auto svgContent = File::ReadAllText(svgFilePath);

// बेस URI SVG दस्तावेज़ के स्थान को दर्शाता है।
auto baseUri = MakeObject<Uri>(svgFilePath)->get_AbsoluteUri();

auto fallbackImageData = ArrayPtr<uint8_t>();
auto fallbackImagePath = Path::Combine(assetDirectory, u"fallback.png");
if (File::Exists(fallbackImagePath))
{
    fallbackImageData = File::ReadAllBytes(fallbackImagePath);
}

auto resolver = MakeObject<LocalSvgResourceResolver>(assetDirectory, fallbackImageData);
auto svgImage = MakeObject<SvgImage>(svgContent, resolver, baseUri);

// ISvgImage स्रोत सामग्री, बाइनरी डेटा, बेस URI और रिजॉल्वर को उजागर करता है।
auto importedContent = svgImage->get_SvgContent();
auto importedData = svgImage->get_SvgData();
auto importedBaseUri = svgImage->get_BaseUri();
auto importedResolver = svgImage->get_ExternalResourceResolver();

auto presentation = MakeObject<Presentation>();
auto image = presentation->get_Images()->AddImage(svgImage);

presentation->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle, 20.0f, 20.0f,
    static_cast<float>(image->get_Width()),
    static_cast<float>(image->get_Height()),
    image);

presentation->Save(u"svg-with-linked-resources.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

`SvgImage` क्लास अतिरिक्त ओवरलोड भी प्रदान करता है जो SVG डेटा को बाइट एरे या स्ट्रीम के रूप में, साथ ही एक बाहरी संसाधन रिजॉल्वर और बेस URI को स्वीकार करता है।

{{% alert title="Important" color="warning" %}}

रिजॉल्वर SVG को प्रोसेस और रेंडर करते समय बाहरी संसाधनों को उपलब्ध कराता है। यह मूल SVG मार्कअप को संशोधित नहीं करता या स्वचालित रूप से हल किए गए संसाधनों को इसमें एम्बेड नहीं करता।

जब एक `ISvgImage` को प्रस्तुति इमेज कलेक्शन में जोड़ा जाता है, तो PPTX फ़ाइल मूल SVG प्रतिनिधित्व और एक रास्टर फॉलबैक चित्र दोनों शामिल कर सकती है। एक लिंक्ड संसाधन उत्पन्न फॉलबैक चित्र में दिखाई दे सकता है जबकि `images/photo.png` जैसे सापेक्ष लिंक संग्रहीत SVG में अपरिवर्तित रहता है। मूल बाहरी संसाधन अनुपलब्ध होने पर मूल SVG प्रतिनिधित्व को रेंडर करने वाला अनुप्रयोग लिंक्ड सामग्री को छोड़ सकता है।

{{% /alert %}}

### **पोर्टेबल SVG चित्र बनाएं**

एक पोर्टेबल SVG चित्र बनाने के लिए, `SvgImage` बनाने से पहले SVG को स्वसंकुलित बनाएं। उदाहरण के लिए, लिंक्ड चित्र URLs को `data:` URI में बदलें जिसमें चित्र डेटा शामिल हो:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

सभी आवश्यक संसाधनों को SVG सामग्री में एम्बेड करने के बाद, `SvgImage` बनाएं, इसे प्रस्तुति इमेज कलेक्शन में जोड़ें, और पिछले उदाहरण में दिखाए अनुसार पिक्चर फ्रेम में सम्मिलित करें।

### **गायब या अवरुद्ध संसाधनों को संभालें**

`ResolveUri` से जब संसाधन URI अवैध, प्रतिबंधित या हल नहीं किया जा सकता हो तो null स्ट्रिंग लौटाएँ। `GetEntity` से जब संसाधन नहीं पढ़ा जा सकता तो `nullptr` लौटाएँ। Aspose.Slides संभव हो तो उस संसाधन के बिना SVG को प्रोसेस करना जारी रखेगा।

एक गायब संसाधन के लिए फॉलबैक स्ट्रीम लौटाई जा सकती है, लेकिन उसकी सामग्री अनुरोधित संसाधन प्रकार के अनुकूल होनी चाहिए। उदाहरण के लिए, केवल गायब चित्र के लिए चित्र स्ट्रीम लौटाएँ, फ़ॉन्ट या स्टाइलशीट के लिए नहीं।

{{% alert title="Security" color="warning" %}}

अविश्वसनीय SVG फ़ाइलों से मनमाने फ़ाइल पाथ या अवरुद्ध नेटवर्क URL को हल न करें। अनुमत योजनाओं, निर्देशिकाओं और होस्ट को प्रतिबंधित करें। नेटवर्क संसाधनों के लिए कनेक्शन टाइमआउट, प्रतिक्रिया-आकार प्रतिबंध और सामग्री सत्यापन लागू करें।

{{% /alert %}}

## **SVG को आकृतियों के सेट में परिवर्तित करें**
Aspose.Slides SVG को आकृतियों के सेट में परिवर्तित कर सकता है, जैसा कि PowerPoint में समान कार्यक्षमता है:

![PowerPoint Popup Menu](img_01_01.png)

यह कार्यक्षमता [AddGroupShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/) मेथड के एक ओवरलोड द्वारा प्रदान की जाती है, जो [IShapeCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/) इंटरफ़ेस का हिस्सा है और पहला तर्क एक [ISvgImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isvgimage/) ऑब्जेक्ट लेता है।

निम्नलिखित C++ नमूना कोड इस मेथड का उपयोग करके SVG फ़ाइल को आकृतियों के सेट में परिवर्तित करने को दर्शाता है:

``` cpp 
#include <DOM/IPresentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <DOM/SvgImage.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/io/file.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

// स्रोत SVG फ़ाइल नाम
auto svgFileName = System::String(u"sample.svg");

// आउटपुट प्रस्तुति फ़ाइल नाम
auto outPptxPath = System::String(u"presentation.pptx");

// नई प्रस्तुति बनाएं
auto presentation = System::MakeObject<Presentation>();

// SVG फ़ाइल की सामग्री पढ़ें
auto svgContent = File::ReadAllText(svgFileName);

// SvgImage ऑब्जेक्ट बनाएं
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// स्लाइड आकार प्राप्त करें
auto slideSize = presentation->get_SlideSize()->get_Size();

// SVG चित्र को आकृतियों के समूह में परिवर्तित करें और स्लाइड आकार के अनुसार स्केल करें
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// प्रस्तुति को PPTX स्वरूप में सहेजें
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **EMF के रूप में चित्र स्लाइड्स में जोड़ें**
Aspose.Slides for C++ आपको Aspose.Cells के साथ Excel वर्कशीट से EMF चित्र उत्पन्न करने और उन्हें प्रस्तुति स्लाइड्स में जोड़ने की अनुमति देता है। 

निम्नलिखित C++ नमूना कोड यह दर्शाता है:

``` cpp 
#include <DOM/IGlobalLayoutSlideCollection.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/array.h>
#include <system/smart_ptr.h>
#include "Aspose.Cells/ImageOrPrintOptions.h"
#include "Aspose.Cells/ImageType.h"
#include "Aspose.Cells/Initializer.h"
#include "Aspose.Cells/SheetRender.h"
#include "Aspose.Cells/Vector.h"
#include "Aspose.Cells/Workbook.h"
#include "Aspose.Cells/Worksheet.h"
#include "Aspose.Cells/WorksheetCollection.h"

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Aspose.Cells for C++ को उसके किसी भी प्रकार का उपयोग करने से पहले शुरू किया जाना चाहिए.
Aspose::Cells::Startup();

auto workbook = Aspose::Cells::Workbook(u"chart.xls");
auto sheet = workbook.GetWorksheets().Get(0);

// Render the worksheet as EMF.
auto options = Aspose::Cells::ImageOrPrintOptions();
options.SetHorizontalResolution(200);
options.SetVerticalResolution(200);
options.SetImageType(Aspose::Cells::Drawing::ImageType::Emf);

auto sheetRender = Aspose::Cells::SheetRender(sheet, options);

auto presentation = System::MakeObject<Presentation>();
presentation->get_Slides()->RemoveAt(0);

for (auto pageIndex = 0; pageIndex < sheetRender.GetPageCount(); pageIndex++)
{
    // Aspose.Cells रेंडर किया गया पृष्ठ एक बफ़र के रूप में देता है, जिसे Aspose.Slides एक चित्र के रूप में जोड़ता है.
    auto emfData = sheetRender.ToImage(pageIndex);
    auto emfBytes = System::MakeArray<uint8_t>(emfData.GetLength(), emfData.GetData());
    auto emfImage = presentation->get_Images()->AddImage(emfBytes);

    auto slide = presentation->get_Slides()->AddEmptySlide(
        presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank));
    auto slideSize = presentation->get_SlideSize()->get_Size();
    slide->get_Shapes()->AddPictureFrame(ShapeType::Rectangle, 0.0f, 0.0f, slideSize.get_Width(), slideSize.get_Height(), emfImage);
}

presentation->Save(u"Saved.pptx", SaveFormat::Pptx);
presentation->Dispose();
workbook.Dispose();

Aspose::Cells::Cleanup();
```

## **इमेज कलेक्शन में चित्र बदलें**
Aspose.Slides आपको प्रस्तुति की इमेज कलेक्शन में संग्रहीत चित्रों को बदलने की अनुमति देता है, जिसमें स्लाइड आकृतियों द्वारा उपयोग किए गए चित्र भी शामिल हैं। यह अनुभाग कलेक्शन में चित्रों को अपडेट करने के कई तरीकों का वर्णन करता है। आप कच्चे बाइट डेटा, एक [IImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/) इंस्टेंस, या कलेक्शन में पहले से मौजूद अन्य चित्र का उपयोग करके चित्र बदल सकते हैं।

नीचे दिए गए चरणों का पालन करें:

1. वह प्रस्तुति फ़ाइल लोड करें जिसमें चित्र हैं, इसके लिए [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास का उपयोग करें।
2. नई छवि को फ़ाइल से बाइट एरे में लोड करें।
3. बाइट एरे का उपयोग करके लक्ष्य चित्र को नई छवि से बदलें।
4. दूसरे तरीके में, छवि को एक [IImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/) ऑब्जेक्ट में लोड करें और उस ऑब्जेक्ट से लक्ष्य चित्र को बदलें।
5. तीसरे तरीके में, लक्ष्य चित्र को कलेक्शन में पहले से मौजूद किसी अन्य चित्र से बदलें।
6. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

```cpp
#include <DOM/IPPImage.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

// Presentation क्लास का एक उदाहरण बनाएं जो प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// पहला तरीका।
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// दूसरा तरीका।
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// तीसरा तरीका।
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// प्रस्तुति को फ़ाइल में सहेजें।
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}

Aspose के मुफ्त [Text to GIF](https://products.aspose.app/slides/hi/text-to-gif) कनवर्टर के साथ आप आसानी से टेक्स्ट को एनिमेट करके GIF बना सकते हैं। 

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मूल चित्र रिज़ॉल्यूशन सम्मिलन के बाद बरकरार रहता है?**

हां। स्रोत पिक्सेल संरक्षित रहते हैं, परंतु अंतिम दिखाई देना इस बात पर निर्भर करता है कि स्लाइड पर [picture](/slides/hi/cpp/picture-frame/) कैसे स्केल किया गया है और सहेजते समय कोई संपीड़न लागू हुआ है या नहीं।

**कई स्लाइड्स में एक ही लोगो को एक साथ बदलने का सबसे अच्छा तरीका क्या है?**

लोगो को मास्टर स्लाइड या लेआउट पर रखें और प्रस्तुति की इमेज कलेक्शन में इसे बदलें—परिवर्तन सभी उन तत्वों में प्रसारित हो जाएंगे जो उस संसाधन का उपयोग करते हैं।

**क्या सम्मिलित SVG को संपादन योग्य आकृतियों में परिवर्तित किया जा सकता है?**

हां। आप SVG को आकृतियों के समूह में परिवर्तित कर सकते हैं, जिसके बाद व्यक्तिगत भाग मानक आकृति गुणों के साथ संपादन योग्य हो जाते हैं।

**मैं एक तस्वीर को कई स्लाइड्स के बैकग्राउंड के रूप में एक साथ कैसे सेट कर सकता हूँ?**

[Assign the image as the background](/slides/hi/cpp/presentation-background/) को मास्टर स्लाइड या संबंधित लेआउट पर लागू करें—उस मास्टर/लेआउट का उपयोग करने वाली सभी स्लाइड्स बैकग्राउंड को विरासत में प्राप्त करेंगी।

**बहुत सारे चित्रों के कारण प्रस्तुति बहुत बड़ी होने से कैसे रोकूँ?**

एक ही चित्र संसाधन को पुनः उपयोग करें बजाय प्रतियों के, उचित रिज़ॉल्यूशन चुनें, सहेजते समय संपीड़न लागू करें, और जहाँ उचित हो ग्राफिक्स को मास्टर पर रखें।