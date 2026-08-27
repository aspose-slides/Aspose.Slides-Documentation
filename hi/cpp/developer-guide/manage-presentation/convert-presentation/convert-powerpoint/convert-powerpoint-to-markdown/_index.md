---
title: C++ में PowerPoint प्रस्तुतियों को मार्कडाउन में बदलें
linktitle: PowerPoint से मार्कडाउन
type: docs
weight: 140
url: /hi/cpp/convert-powerpoint-to-markdown/
keywords:
- PowerPoint रूपांतरित करें
- प्रस्तुति रूपांतरित करें
- स्लाइड रूपांतरित करें
- PPT रूपांतरित करें
- PPTX रूपांतरित करें
- PowerPoint से MD
- प्रस्तुति से MD
- स्लाइड से MD
- PPT से MD
- PPTX से MD
- PowerPoint को मार्कडाउन के रूप में सहेजें
- प्रस्तुति को मार्कडाउन के रूप में सहेजें
- स्लाइड को मार्कडाउन के रूप में सहेजें
- PPT को MD के रूप में सहेजें
- PPTX को MD के रूप में सहेजें
- PPT को MD में निर्यात करें
- PPTX को MD में निर्यात करें
- मार्कडाउन इमेज निर्यात
- CDN इमेज लिंक
- PowerPoint
- प्रस्तुति
- मार्कडाउन
- C++
- Aspose.Slides
description: C++ में PPT और PPTX प्रस्तुतियों को मार्कडाउन में बदलें और नियंत्रित करें कि निर्यात की गई बिटमैप, मेटाफाइल और SVG छवियां कहाँ सहेजी और संदर्भित की जाती हैं।
---
## **परिचय**

Aspose.Slides for C++ PPT और PPTX प्रस्तुतियों को दस्तावेज़ीकरण, स्थिर‑साइट, सामग्री‑माइग्रेशन और संस्करण‑नियंत्रण कार्यप्रवाहों के लिए मार्कडाउन में बदल सकता है। आप एक मार्कडाउन फ़्लेवर चुन सकते हैं, स्लाइड सामग्री के रेंडरिंग को नियंत्रित कर सकते हैं, और तय कर सकते हैं कि निर्यात किए गए चित्र कहाँ संग्रहीत हों और उत्पन्न मार्कडाउन उन्हें कैसे संदर्भित करे।

डिफ़ॉल्ट रूप से, मार्कडाउन निर्यात केवल‑पाठ आउटपुट का उपयोग करता है। दृश्य सामग्री निर्यात करने के लिए, [MarkdownSaveOptions::set_ExportType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/markdownsaveoptions/set_exporttype/) मेथड को [MarkdownExportType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/markdownexporttype/) एनोमरेशन के `Sequential` या `Visual` मान पर सेट करें। `Sequential` स्लाइड आइटम्स को अलग‑अलग और क्रम में रेंडर करता है, जबकि `Visual` समूहित आइटम्स को साथ रखता है ताकि उनका दृश्य संबंध बना रहे। `TextOnly` मान चित्र संसाधनों को उत्पन्न नहीं करता, इसलिए इस मोड में इमेज‑सेविंग इवेंट्स को कॉल नहीं किया जाता।

## **एक प्रस्तुति को मार्कडाउन में परिवर्तित करें**

स्रोत फ़ाइल को [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास से लोड करें, और फिर [Presentation::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/) मेथड को [SaveFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/saveformat/) एनोमरेशन के `Md` मान के साथ कॉल करें।

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.md", SaveFormat::Md);
```

## **एक मार्कडाउन फ़्लेवर चुनें**

[MarkdownSaveOptions::set_Flavor](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/markdownsaveoptions/set_flavor/) मेथड आउटपुट के लिए उपयोग किए जाने वाले मार्कडाउन विनिर्देश को नियंत्रित करता है। [Flavor](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/flavor/) एनोमरेशन में CommonMark, GitHub Flavored Markdown और अन्य समर्थित विविधताएँ शामिल हैं।

निम्नलिखित उदाहरण एक प्रस्तुति को CommonMark के रूप में निर्यात करता है:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/Flavor.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_Flavor(Flavor::CommonMark);

presentation->Save(u"presentation.md", SaveFormat::Md, options);
```

## **डिफ़ॉल्ट स्थानीय‑सहेजने की व्यवहार का उपयोग करके छवियों को निर्यात करें**

[MarkdownSaveOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/markdownsaveoptions/) क्लास स्थानीय रूप से सहेजी गई छवियों को कॉन्फ़िगर करने के लिए दो मेथड प्रदान करता है:

- [set_BasePath](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) मार्कडाउन दस्तावेज़ और उसकी संसाधनों के लिए आधार निर्देशिका निर्दिष्ट करता है।
- [set_ImagesSaveFolderName](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) छवि उपनिर्देशिका निर्दिष्ट करता है। इसका डिफ़ॉल्ट मान `Images` है।

निम्नलिखित उदाहरण दृश्य सामग्री को रेंडर करता है, छवियों को `output/assets` में लिखता है, और मार्कडाउन दस्तावेज़ में सापेक्ष छवि संदर्भ बनाता है:

```cpp
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <system/io/directory.h>
#include <system/io/path.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
Directory::CreateDirectory_(outputDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"assets");

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

यह व्यवहार तब भी फ़ॉलबैक के रूप में कार्य करता है जब एक कस्टम इमेज‑सेविंग हैंडलर `false` लौटाता है।

## **छवि सहेजना और मार्कडाउन लिंक को अनुकूलित करें**

मार्कडाउन निर्यात के दौरान उत्पन्न नॉन‑SVG बिटमैप और मेटाफाइल संसाधनों के लिए `MarkdownSaveOptions::ImageSaving` इवेंट का उपयोग करें। इसका [MarkdownImageSavingHandler](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/markdownsaveoptions/markdownimagesavinghandler/) डेलीगेट [IImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/) ऑब्जेक्ट, उसका [ImageFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imageformat/) और उत्पन्न मार्कडाउन लिंक को `System::String&` पैरामीटर के रूप में प्राप्त करता है। प्रदान किए गए प्रारूप के साथ छवि को सहेजें या अपलोड करें, और `link` को उस संदर्भ से बदलें जो मार्कडाउन आउटपुट में प्रदर्शित होना चाहिए।

SVG प्रारूप में उत्पन्न संसाधनों को अलग से संभाला जाता है। `MarkdownSaveOptions::SvgImageSaving` इवेंट को सब्सक्राइब करें, जिसका [MarkdownSvgImageSavingHandler](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/markdownsaveoptions/markdownsvgimagesavinghandler/) डेलीगेट एक [ISvgImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isvgimage/) ऑब्जेक्ट और `System::String& link` पैरामीटर प्राप्त करता है। SVG के पास `ImageFormat` तर्क नहीं होता; इसके बजाय [ISvgImage::get_SvgData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isvgimage/get_svgdata/) मेथड से उसका XML डेटा लिखें या अपलोड करें। निर्यात मोड और दृश्य समूहबद्धता के आधार पर, स्रोत प्रस्तुति में एक SVG को रास्टराइज़ किया जा सकता है या अन्य सामग्री के साथ संयोजित किया जा सकता है; परिणामी नॉन‑SVG संसाधन फिर `ImageSaving` को पास किया जाता है। जब प्रत्येक निर्यातित दृश्य संसाधन को कस्टम प्रोसेसिंग की आवश्यकता हो तो दोनों इवेंट को सब्सक्राइब करें।

हैंडलर का रिटर्न वैल्यू निर्धारित करता है कि छवि को कौन प्रोसेस करता है:

- यदि हैंडलर ने छवि को सहेजा, अपलोड किया, रूपांतरित किया या अन्यथा प्रोसेस किया और `link` को एक वैध मान सौंपा, तो `true` लौटाएँ। Aspose.Slides उस मान को मार्कडाउन दस्तावेज़ में लिखता है और डिफ़ॉल्ट स्थानीय सहेजना नहीं करता।
- `false` लौटाएँ ताकि Aspose.Slides छवि को स्थानीय रूप से सहेजे और लिंक को [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) और [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) के अनुसार उत्पन्न करे।

{{% alert color="warning" title="Important" %}}
`true` लौटाने वाला हैंडलर छवि की ज़िम्मेदारी लेता है। यदि वह वैध, गैर‑खाली लिंक निर्दिष्ट किए बिना `true` लौटाता है, तो निर्यात `InvalidOperationException` के साथ विफल हो जाता है।
{{% /alert %}}

### **सीडीएन मूल निर्देशिका में छवियाँ सहेजें और बाहरी URL का उपयोग करें**

निम्नलिखित उदाहरण `cdn-origin/presentations/quarterly-report` को एक माउंटेड या सिंक्रनाइज़्ड सीडीएन मूल निर्देशिका के रूप में मानता है। प्रत्येक हैंडलर उत्पन्न फ़ाइल नाम को निकालता है, छवि को उस कस्टम निर्देशिका में सहेजता है, और स्थानीय संदर्भ को सार्वजनिक सीडीएन URL से बदल देता है। स्वयं नमूना कोई नेटवर्क अपलोड नहीं करता: URL केवल तभी मान्य होता है जब निर्देशिका को सीडीएन मूल के रूप में माउंट किया गया हो या उसकी फाइलें सीडीएन पर प्रकाशित हों। ऑब्जेक्ट स्टोरेज के लिए, फ़ाइल‑सिस्टम राइट को स्टोरेज SDK की अपलोड ऑपरेशन से बदलें और अपलोड सफल होने पर ही `link` असाइन करें।

```cpp
#include <DOM/ISvgImage.h>
#include <DOM/Presentation.h>
#include <Export/Markdown/SaveOptions/MarkdownExportType.h>
#include <Export/Markdown/SaveOptions/MarkdownSaveOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <functional>
#include <system/io/directory.h>
#include <system/io/file.h>
#include <system/io/path.h>
#include <system/uri.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

const System::String outputDirectory = u"output";
const System::String publicBaseUrl = u"https://cdn.example.com/presentations/quarterly-report";
const System::String storageDirectory = Path::Combine(u"cdn-origin", u"presentations", u"quarterly-report");
Directory::CreateDirectory_(outputDirectory);
Directory::CreateDirectory_(storageDirectory);

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
auto options = System::MakeObject<MarkdownSaveOptions>();
options->set_ExportType(MarkdownExportType::Visual);
options->set_BasePath(outputDirectory);
options->set_ImagesSaveFolderName(u"fallback-images");

options->ImageSaving.connect(std::function<bool(System::SharedPtr<IImage>, ImageFormat, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<IImage> image, ImageFormat format, System::String& link) -> bool
{
    if (image->get_Width() < 128 || image->get_Height() < 128)
    {
        return false;
    }

    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    image->Save(storagePath, format);
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

options->SvgImageSaving.connect(std::function<bool(System::SharedPtr<ISvgImage>, System::String&)>([storageDirectory, publicBaseUrl](System::SharedPtr<ISvgImage> svgImage, System::String& link) -> bool
{
    auto urlCompatibleLink = link.Replace(u"\\", u"/");
    auto fileName = urlCompatibleLink.Substring(urlCompatibleLink.LastIndexOf(u'/') + 1);
    auto storagePath = Path::Combine(storageDirectory, fileName);
    File::WriteAllBytes(storagePath, svgImage->get_SvgData());
    link = publicBaseUrl + u"/" + System::Uri::EscapeDataString(fileName);
    return true;
}));

auto markdownPath = Path::Combine(outputDirectory, u"presentation.md");
presentation->Save(markdownPath, SaveFormat::Md, options);
```

बिटमैप हैंडलर जानबूझकर 128 × 128 पिक्सेल से छोटे चित्रों के लिए `false` लौटाता है, इसलिए Aspose.Slides उन छवियों को डिफ़ॉल्ट व्यवहार का उपयोग करके `output/fallback-images` में सहेजता है। बड़े बिटमैप, मेटाफाइल संसाधन और SVG संसाधन कस्टम कोड द्वारा संभाले जाते हैं। उदाहरण के लिए, एक उत्पन्न स्थानीय संदर्भ जैसे `fallback-images/image1.png` बन जाता है `https://cdn.example.com/presentations/quarterly-report/image1.png`। हैंडलर फ़ाइल‑सिस्टम पथ लिखते समय केवल ऑपरेटिंग‑सिस्टम पथ का उपयोग करते हैं; मार्कडाउन में लिखे जाने वाले लिंक फॉरवर्ड स्लैश और URL‑एस्केप्ड फ़ाइल नामों का उपयोग करते हैं। सापेक्ष लिंक बनाते समय भी वही नियम लागू करें: `/` उपयोग करें, प्लेटफ़ॉर्म‑विशिष्ट डायरेक्टरी सेपरेटर नहीं।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या कोई एक हैंडलर रास्टर छवियों और SVG छवियों दोनों को प्रोसेस कर सकता है?**  
नहीं। नॉन‑SVG बिटमैप और मेटाफाइल संसाधनों के लिए `MarkdownSaveOptions::ImageSaving` का उपयोग करें और SVG के रूप में उत्पन्न संसाधनों के लिए `MarkdownSaveOptions::SvgImageSaving` का उपयोग करें। former एक [IImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/iimage/) ऑब्जेक्ट और एक [ImageFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides/imageformat/) प्रदान करता है; latter एक [ISvgImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isvgimage/) ऑब्जेक्ट प्रदान करता है जिसका SVG डेटा आप [ISvgImage::get_SvgData](https://reference.aspose.com/slides/hi/cpp/aspose.slides/isvgimage/get_svgdata/) से पढ़ सकते हैं। निर्यात के दौरान रास्टराइज़ किया गया स्रोत SVG `ImageSaving` द्वारा प्रोसेस किया जाता है।

**जब इमेज‑सेविंग हैंडलर `false` लौटाता है तो क्या होता है?**  
Aspose.Slides अपने डिफ़ॉल्ट स्थानीय‑सहेजने के व्यवहार का उपयोग करता है। छवि स्थान और उत्पन्न संदर्भ को [MarkdownSaveOptions::set_BasePath](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/markdownsaveoptions/set_basepath/) और [MarkdownSaveOptions::set_ImagesSaveFolderName](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/markdownsaveoptions/set_imagessavefoldername/) द्वारा नियंत्रित किया जाता है।

**क्या एक हैंडलर बिना स्थानीय रूप से छवि सहेजे URL प्रदान कर सकता है?**  
हाँ। हैंडलर छवि को ऑब्जेक्ट स्टोरेज में अपलोड कर सकता है या किसी अन्य सेवा को पास कर सकता है, परिणामस्वरूप URL को `link` में असाइन कर `true` लौटाएँ। हैंडलर को स्वयं प्रोसेसिंग पूरी करनी होती है; `true` लौटाने से डिफ़ॉल्ट स्थानीय सहेजना रोक दिया जाता है।

**मार्कडाउन निर्यात हैंडलर से `InvalidOperationException` क्यों फेंकता है?**  
यह तब होता है जब हैंडलर `true` लौटाता है लेकिन वैध लिंक प्रदान नहीं करता। `true` लौटाने से पहले उस सापेक्ष पथ या बाहरी URL को असाइन करें जो मार्कडाउन में लिखा जाना चाहिए।

**छवि लिंक कौन से पाथ सेपरेटर का उपयोग करें?**  
मार्कडाउन लिंक और URL में फॉरवर्ड स्लैश (`/`) उपयोग करें। फ़ाइल‑सिस्टम पथों के लिए केवल `Path::Combine` का उपयोग करें, फिर मार्कडाउन संदर्भ को अलग से बनाएं या सामान्यित करें।

**क्या मार्कडाउन निर्यात के दौरान हाइपरलिंक संरक्षित रहते हैं?**  
हाँ। टेक्स्ट [hyperlinks](/slides/hi/cpp/manage-hyperlinks/) को मानक मार्कडाउन लिंक के रूप में संरक्षित रखा जाता है। स्लाइड [transitions](/slides/hi/cpp/slide-transition/) और [animations](/slides/hi/cpp/powerpoint-animation/) को परिवर्तित नहीं किया जाता।

**क्या प्रस्तुतियों को समानांतर में मार्कडाउन में बदला जा सकता है?**  
आप विभिन्न प्रस्तुति फ़ाइलों को समानांतर में प्रोसेस कर सकते हैं, लेकिन एक ही [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) इंस्टेंस को थ्रेड्स के बीच साझा न करें। [multithreading guidelines](/slides/hi/cpp/multithreading/) का पालन करें और प्रत्येक फ़ाइल के लिए अलग इंस्टेंस उपयोग करें।