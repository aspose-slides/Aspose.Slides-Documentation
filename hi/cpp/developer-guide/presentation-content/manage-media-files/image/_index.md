---
title: "प्रस्तुति में छवि प्रबंधन को C++ का उपयोग करके अनुकूलित करें"
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
- "लिंक्ड SVG छवियां"
- "SVG फ़ॉन्ट"
- "EMF जोड़ें"
- "WMF जोड़ें"
- "TIFF जोड़ें"
- "PowerPoint"
- "OpenDocument"
- "प्रस्तुति"
- "C++"
- "Aspose.Slides"
description: "Aspose.Slides for C++ के साथ PowerPoint और OpenDocument में छवि प्रबंधन को सहज बनाएं, प्रदर्शन को अनुकूलित करें और अपने कार्यप्रवाह को स्वचालित करें।"
---
## **परिचय**

छवियां प्रस्तुतियों को अधिक आकर्षक और दृश्य रूप से आकर्षक बनाती हैं। Microsoft PowerPoint में, आप फ़ाइलों, इंटरनेट या अन्य स्रोतों से स्लाइड्स पर चित्र डाल सकते हैं। इसी तरह, Aspose.Slides कई तरीकों से प्रस्तुति स्लाइड्स में छवियां जोड़ने की अनुमति देता है।

{{% alert title="टिप" color="info" %}} 

Aspose मुफ्त कनवर्टर प्रदान करता है—[JPEG to PowerPoint](https://products.aspose.app/slides/hi/import/jpg-to-ppt) और [PNG to PowerPoint](https://products.aspose.app/slides/hi/import/png-to-ppt)—जो आपको छवियों से जल्दी से प्रस्तुतियां बनाने देता है। 

{{% /alert %}} 

{{% alert title="जानकारी" color="info" %}}

यदि आप चित्र को एक फ़्रेम के रूप में जोड़ना चाहते हैं—विशेष रूप से यदि आप उसका आकार बदलना, प्रभाव लागू करना, या अन्य मानक फ़ॉर्मेटिंग विकल्प उपयोग करना चाहते हैं—तो देखें [Picture Frame](/slides/hi/cpp/picture-frame/)। 

{{% /alert %}} 

{{% alert title="नोट" color="warning" %}}

आप छवियों को एक फ़ॉर्मेट से दूसरे में परिवर्तित कर सकते हैं। निम्नलिखित पृष्ठ देखें: convert [image to JPG](https://products.aspose.com/slides/hi/cpp/conversion/image-to-jpg/), [JPG to image](https://products.aspose.com/slides/hi/cpp/conversion/jpg-to-image/), [JPG to PNG](https://products.aspose.com/slides/hi/cpp/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/hi/cpp/conversion/png-to-jpg/), [PNG to SVG](https://products.aspose.com/slides/hi/cpp/conversion/png-to-svg/), और [SVG to PNG](https://products.aspose.com/slides/hi/cpp/conversion/svg-to-png/)।

{{% /alert %}}

Aspose.Slides लोकप्रिय फ़ॉर्मेट जैसे JPEG, PNG, BMP, GIF, और अन्य में छवियों का समर्थन करता है। 

## **स्थानीय रूप से संग्रहीत छवियों को स्लाइड्स में जोड़ें**

आप अपनी कंप्यूटर पर संग्रहीत एक या अधिक छवियों को प्रस्तुति स्लाइड में जोड़ सकते हैं। निम्नलिखित C++ नमूना कोड दिखाता है कि स्लाइड में छवि कैसे जोड़ी जाए:

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

## **वेब से छवियों को स्लाइड्स में जोड़ें**

यदि वह छवि जिसे आप स्लाइड में जोड़ना चाहते हैं आपके कंप्यूटर पर संग्रहीत नहीं है, तो आप उसे सीधे वेब से जोड़ सकते हैं। 

निम्नलिखित C++ नमूना कोड दिखाता है कि वेब से छवि को स्लाइड में कैसे जोड़ें:

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

## **स्लाइड मास्टर में छवियां जोड़ें**

स्लाइड मास्टर स्लाइडों के थीम और लेआउट जैसी जानकारी संग्रहीत करता है और नियंत्रित करता है। जब आप स्लाइड मास्टर में एक छवि जोड़ते हैं, तो वह छवि उस मास्टर पर आधारित हर स्लाइड पर दिखाई देती है। 

निम्नलिखित C++ नमूना कोड दिखाता है कि स्लाइड मास्टर में छवि कैसे जोड़ें:

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

## **छवियों को स्लाइड पृष्ठभूमि के रूप में जोड़ें**

आप एक या अधिक स्लाइड्स के लिए पृष्ठभूमि के रूप में चित्र का उपयोग कर सकते हैं। विवरण के लिए देखें *[Setting Images as Backgrounds for Slides](/slides/hi/cpp/presentation-background/#setting-images-as-background-for-slides)*।

## **SVG को प्रस्तुतियों में जोड़ें**

SVG सामग्री को प्रस्तुति में [SvgImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/svgimage/) क्लास का उपयोग करके जोड़ा जा सकता है। परिणामस्वरूप प्राप्त [ISvgImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isvgimage/) ऑब्जेक्ट को फिर प्रस्तुति की इमेज कलेकशन में जोड़ा जा सकता है और एक चित्र फ्रेम बनाने के लिए उपयोग किया जा सकता है।

निम्नलिखित C++ उदाहरण एक स्वतंत्र SVG स्ट्रिंग आयात करता है। इस SVG द्वारा उपयोग की गई सभी छवियां, स्टाइल और अन्य संसाधन सीधे SVG सामग्री में एंबेड किए गए हैं।

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

डिज़ाइन टूल्स, डायग्राम एडिटर्स, आइकन सिस्टम और वेब पाइपलाइन से निर्यात किए गए SVG फ़ाइलों में ऐसे संसाधन हो सकते हैं जो SVG दस्तावेज़ के बाहर संग्रहीत होते हैं। उदाहरण के लिए, एक SVG में `images/photo.png` जैसा छवि लिंक, एक CSS `url(...)` मान, या फ़ॉन्ट URL हो सकता है।

ऐसी SVG सामग्री आयात करने के लिए, एक [IExternalResourceResolver](https://reference.aspose.com/slides/hi/cpp/aspose.slides.import/iexternalresourceresolver/) कार्यान्वयन बनाएं और इसे बेस URI के साथ उपयुक्त `SvgImage` कन्स्ट्रक्टर को पास करें। बेस URI SVG दस्तावेज़ का स्थान पहचानता है और सापेक्ष लिंक को हल करने के लिए उपयोग किया जाता है।

[ISvgImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isvgimage/) इंटरफ़ेस आयातित SVG के बारे में जानकारी तक पहुंच प्रदान करता है:

- `get_SvgContent()` SVG मार्कअप को स्ट्रिंग के रूप में लौटाता है।
- `get_SvgData()` SVG सामग्री को बाइट एरे के रूप में लौटाता है।
- `get_BaseUri()` सापेक्ष लिंक के लिए उपयोग किया गया बेस URI लौटाता है।
- `get_ExternalResourceResolver()` SVG छवि को सौंपे गए रिजॉल्वर को लौटाता है।

### **एक बाहरी संसाधन रिजॉल्वर लागू करें**

रिजॉल्वर में दो मेथड होते हैं:

- [ResolveUri](https://reference.aspose.com/slides/hi/cpp/aspose.slides.import/iexternalresourceresolver/resolveuri/) बेस URI और सापेक्ष संसाधन लिंक को मिलाकर एक पूर्ण URI लौटाता है। जब लिंक को हल नहीं किया जा सकता या अनुमति नहीं है तो null स्ट्रिंग लौटाएं।
- [GetEntity](https://reference.aspose.com/slides/hi/cpp/aspose.slides.import/iexternalresourceresolver/getentity/) पूर्ण संसाधन URI के लिए एक पढ़ने योग्य स्ट्रीम लौटाता है। जब संसाधन अनुपलब्ध, अवरुद्ध या उपलब्ध नहीं हो तो `nullptr` लौटाएं। आवश्यक होने पर एक फॉलबैक स्ट्रीम भी लौटाई जा सकती है।

निम्नलिखित रिजॉल्वर केवल अनुमत स्थानीय निर्देशिका से लिंक किए गए संसाधनों को लोड करता है। नेटवर्क संसाधन और अनुमत निर्देशिका के बाहर के पाथ अवरुद्ध होते हैं। अपरिचित छवि लिंक के लिए एक वैकल्पिक फॉलबैक छवि लौटाई जाती है।

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

        // फॉलबैक केवल छवि संसाधनों के लिए उपयोग करें। छवि स्ट्रीम लौटाना
        // गायब फ़ॉन्ट या स्टाइलशीट के लिए वैध नहीं होगा।
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

### **SVG आयात के दौरान लिंक्ड रिसोर्सेज़ हल करें**

मान लें कि `assets/diagram.svg` में एक सापेक्ष संदर्भ है जैसे:

```xml
<image href="images/photo.png" x="20" y="20" width="320" height="180" />
```

निम्नलिखित C++ उदाहरण SVG फ़ाइल URI को बेस URI के रूप में पास करता है और एक कस्टम रिजॉल्वर प्रदान करता है। रिजॉल्वर सापेक्ष छवि लिंक को पूर्ण URI में बदलता है और लिंक्ड संसाधन वाली स्ट्रीम लौटाता है जबकि Aspose.Slides SVG को प्रोसेस करता है।

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

// बेस URI SVG दस्तावेज़ का स्थान दर्शाता है।
auto baseUri = MakeObject<Uri>(svgFilePath)->get_AbsoluteUri();

auto fallbackImageData = ArrayPtr<uint8_t>();
auto fallbackImagePath = Path::Combine(assetDirectory, u"fallback.png");
if (File::Exists(fallbackImagePath))
{
    fallbackImageData = File::ReadAllBytes(fallbackImagePath);
}

auto resolver = MakeObject<LocalSvgResourceResolver>(assetDirectory, fallbackImageData);
auto svgImage = MakeObject<SvgImage>(svgContent, resolver, baseUri);

// ISvgImage स्रोत सामग्री, बाइनरी डेटा, बेस URI, और रिजॉल्वर को उजागर करता है।
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

`SvgImage` क्लास अतिरिक्त ओवरलोड भी प्रदान करती है जो SVG डेटा को बाइट एरे या स्ट्रीम के रूप में स्वीकार करती है, साथ ही एक बाहरी संसाधन रिजॉल्वर और बेस URI।

{{% alert title="महत्वपूर्ण" color="warning" %}}

रिसोर्स रिजॉल्वर SVG को प्रोसेस और रेंडर करते समय बाहरी संसाधनों को उपलब्ध कराता है। यह मूल SVG मार्कअप को संशोधित नहीं करता या स्वचालित रूप से हल किए गए संसाधनों को उसमें एंबेड नहीं करता।

जब एक `ISvgImage` को प्रस्तुति इमेज कलेक्शन में जोड़ा जाता है, तो PPTX फ़ाइल मूल SVG प्रतिनिधित्व और एक रास्टर फॉलबैक छवि दोनों को शामिल कर सकती है। एक लिंक्ड संसाधन उत्पन्न फॉलबैक छवि में दिख सकता है जबकि `images/photo.png` जैसा सापेक्ष लिंक संग्रहित SVG में अपरिवर्तित रहता है। वह अनुप्रयोग जो मूल SVG प्रतिनिधित्व को रेंडर करता है, मूल बाहरी संसाधन अनुपलब्ध होने पर लिंक्ड सामग्री को छोड़ सकता है।

{{% /alert %}}

### **एक पोर्टेबल SVG चित्र बनाएँ**

एक ऐसा SVG चित्र बनाने के लिए जो बाहरी फ़ाइलों पर निर्भर न हो, `SvgImage` बनाने से पहले SVG को स्व-समावेशी बनाएं। उदाहरण के लिए, लिंक्ड छवि URL को `data:` URI से बदलें जिसमें छवि डेटा शामिल हो:

```xml
<image href="data:image/png;base64,..." x="20" y="20" width="320" height="180" />
```

सभी आवश्यक संसाधन SVG सामग्री में एंबेड होने के बाद, `SvgImage` बनाएं, उसे प्रस्तुति इमेज कलेक्शन में जोड़ें, और पिछले उदाहरण की तरह इसे चित्र फ्रेम में डालें।

### **गुम या अवरुद्ध संसाधनों को संभालें**

जब संसाधन URI अमान्य, प्रतिबंधित, या हल नहीं हो सकता हो तो `ResolveUri` से null स्ट्रिंग लौटाएँ। जब संसाधन पढ़ा नहीं जा सकता हो तो `GetEntity` से `nullptr` लौटाएँ। संभव होने पर Aspose.Slides उस संसाधन के बिना SVG को प्रोसेस करना जारी रखेगा।

एक गुम संसाधन के लिए फॉलबैक स्ट्रीम लौटाई जा सकती है, लेकिन उसकी सामग्री अनुरोधित संसाधन प्रकार के साथ संगत होनी चाहिए। उदाहरण के लिए, केवल गुम छवि के लिए ही छवि स्ट्रीम लौटाएँ, फ़ॉन्ट या स्टाइलशीट के लिए नहीं।

{{% alert title="सुरक्षा" color="warning" %}}

अविश्वसनीय SVG फ़ाइलों से मनमाने फ़ाइल पाथ या असीमित नेटवर्क URL को हल न करें। अनुमत योजनाओं, निर्देशिकाओं और होस्ट को सीमित रखें। नेटवर्क संसाधनों के लिए कनेक्शन टाइमआउट, रिस्पॉन्स‑साइज़ सीमा, और सामग्री वैधता लागू करें।

{{% /alert %}}

## **SVG को आकारों के सेट में परिवर्तित करें**
Aspose.Slides SVG को आकारों के एक सेट में परिवर्तित कर सकता है, जो PowerPoint में समान कार्यक्षमता के समान है:

![PowerPoint Popup Menu](img_01_01.png)

यह कार्यक्षमता [AddGroupShape](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/) मेथड के ओवरलोड द्वारा प्रदान की गई है, जो [IShapeCollection](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishapecollection/) इंटरफ़ेस का हिस्सा है और पहला तर्क के रूप में एक [ISvgImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isvgimage/) ऑब्जेक्ट लेता है।

निम्नलिखित C++ नमूना कोड दिखाता है कि इस मेथड का उपयोग करके SVG फ़ाइल को आकारों के सेट में कैसे परिवर्तित करें:

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

// स्रोत SVG फ़ाइल का नाम
auto svgFileName = System::String(u"sample.svg");

// आउटपुट प्रस्तुति फ़ाइल का नाम
auto outPptxPath = System::String(u"presentation.pptx");

// नई प्रस्तुति बनाएं
auto presentation = System::MakeObject<Presentation>();

// SVG फ़ाइल की सामग्री पढ़ें
auto svgContent = File::ReadAllText(svgFileName);

// SvgImage ऑब्जेक्ट बनाएं
auto svgImage = System::MakeObject<SvgImage>(svgContent);

// स्लाइड का आकार प्राप्त करें
auto slideSize = presentation->get_SlideSize()->get_Size();

// SVG छवि को आकारों के समूह में बदलें और इसे स्लाइड आकार के अनुसार स्केल करें
presentation->get_Slides()->idx_get(0)->get_Shapes()->AddGroupShape(svgImage, 0.f, 0.f, slideSize.get_Width(), slideSize.get_Height());

// प्रस्तुति को PPTX फ़ॉर्मेट में सहेजें
presentation->Save(outPptxPath, SaveFormat::Pptx);
```

## **छवियों को EMF के रूप में स्लाइड्स में जोड़ें**
Aspose.Slides for C++ आपको Aspose.Cells के साथ Excel वर्कशीट्स से EMF छवियां जेनरेट करने और उन्हें प्रस्तुति स्लाइड्स में जोड़ने की अनुमति देता है। 

निम्नलिखित C++ नमूना कोड दिखाता है कि इसे कैसे करें:

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

// Aspose.Cells for C++ को किसी भी प्रकार का उपयोग करने से पहले प्रारंभ किया जाना चाहिए।
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
    // Aspose.Cells रेंडर किया गया पृष्ठ एक बफ़र के रूप में लौटाता है, जिसे Aspose.Slides एक चित्र के रूप में जोड़ता है।
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

## **इमेज कलेक्शन में छवियों को बदलें**

Aspose.Slides आपको प्रस्तुति की इमेज कलेक्शन में संग्रहीत छवियों को बदलने की सुविधा देता है, जिसमें स्लाइड आकारों द्वारा उपयोग की गई छवियां भी शामिल हैं। यह अनुभाग कलेक्शन में छवियों को अपडेट करने के कई तरीकों का वर्णन करता है। आप एक छवि को कच्चे बाइट डेटा, एक [IImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/) इंस्टेंस, या कलेक्शन में पहले से मौजूद किसी अन्य छवि से बदल सकते हैं।

नीचे दिए गए चरणों का पालन करें:

1. उन छवियों वाले प्रस्तुति फ़ाइल को [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास से लोड करें।
1. फ़ाइल से नई छवि को बाइट एरे में लोड करें।
1. बाइट एरे का उपयोग करके लक्ष्य छवि को नई छवि से बदलें।
1. दूसरे तरीके में, छवि को एक [IImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/) ऑब्जेक्ट में लोड करें और लक्ष्य छवि को उस ऑब्जेक्ट से बदलें।
1. तीसरे तरीके में, लक्ष्य छवि को प्रस्तुति की इमेज कलेक्शन में पहले से मौजूद किसी छवि से बदलें।
1. संशोधित प्रस्तुति को PPTX फ़ाइल के रूप में लिखें।

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

// एक Presentation क्लास का उदाहरण बनाएं जो एक प्रस्तुति फ़ाइल का प्रतिनिधित्व करता है।
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// पहला तरीका.
auto imageData = File::ReadAllBytes(u"image0.jpeg");
auto oldImage = presentation->get_Image(0);
oldImage->ReplaceImage(imageData);

// दूसरा तरीका.
auto newImage = Images::FromFile(u"image1.png");
oldImage = presentation->get_Image(1);
oldImage->ReplaceImage(newImage);
newImage->Dispose();

// तीसरा तरीका.
oldImage = presentation->get_Image(2);
oldImage->ReplaceImage(presentation->get_Image(3));

// प्रस्तुति को फ़ाइल में सहेजें।
presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert title="जानकारी" color="info" %}}

Aspose के मुफ्त [Text to GIF](https://products.aspose.app/slides/hi/text-to-gif) कनवर्टर के साथ आप आसानी से टेक्स्ट को एनीमेट कर सकते हैं और टेक्स्ट से GIF बना सकते हैं। 

{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या सम्मिलित करने के बाद मूल छवि का रिज़ॉल्यूशन बरकरार रहता है?**

हाँ। स्रोत पिक्सेल संरक्षित रहते हैं, लेकिन अंतिम दिखावट इस पर निर्भर करती है कि स्लाइड पर [picture](/slides/hi/cpp/picture-frame/) कैसे स्केल किया गया है और सहेजते समय कौन सा संपीड़न लागू किया गया है।

**दर्जनों स्लाइड्स में एक ही लोगो को एक साथ बदलने का सबसे अच्छा तरीका क्या है?**

लोगो को मास्टर स्लाइड या लेआउट पर रखें और उसे प्रस्तुति की इमेज कलेक्शन में बदलें—परिवर्तन उन सभी तत्वों तक पहुँचेंगे जो उस संसाधन का उपयोग करते हैं।

**क्या सम्मिलित SVG को संपादन योग्य आकारों में बदला जा सकता है?**

हाँ। आप SVG को आकारों के समूह में बदल सकते हैं, जिसके बाद व्यक्तिगत भाग मानक आकार गुणों के साथ संपादन योग्य हो जाते हैं।

**मैं कैसे कई स्लाइड्स के लिए एक ही चित्र को पृष्ठभूमि के रूप में सेट कर सकता हूं?**

मास्टर स्लाइड या सम्बंधित लेआउट पर छवि को पृष्ठभूमि के रूप में [assign](/slides/hi/cpp/presentation-background/) करें—उस मास्टर/लेआउट का उपयोग करने वाली सभी स्लाइड्स पृष्ठभूमि को विरासत में प्राप्त करेंगी।

**मैं प्रस्तुति को बहुत बड़ी होने से कैसे रोकूं क्योंकि कई चित्र हैं?**

एक ही छवि संसाधन को कई बार उपयोग करें, उचित रिज़ॉल्यूशन चुनें, सहेजते समय संपीड़न लागू करें, और जहाँ उपयुक्त हो ग्राफिक्स को मास्टर पर रखें।