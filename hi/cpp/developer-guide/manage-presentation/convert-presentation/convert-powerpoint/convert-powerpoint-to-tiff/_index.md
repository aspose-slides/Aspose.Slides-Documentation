---
title: C++ में PowerPoint प्रस्तुतियों को TIFF में बदलें
titlelink: PowerPoint से TIFF
type: docs
weight: 90
url: /hi/cpp/convert-powerpoint-to-tiff/
keywords:
- PowerPoint बदलें
- OpenDocument बदलें
- प्रेज़ेंटेशन बदलें
- स्लाइड बदलें
- PPT बदलें
- PPTX बदलें
- PowerPoint से TIFF
- प्रेज़ेंटेशन से TIFF
- स्लाइड से TIFF
- PPT से TIFF
- PPTX से TIFF
- PPT को TIFF के रूप में सहेजें
- PPTX को TIFF के रूप में सहेजें
- PPT को TIFF में निर्यात करें
- PPTX को TIFF में निर्यात करें
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint (PPT, PPTX) प्रस्तुतियों को उच्च गुणवत्ता वाले TIFF चित्रों में आसानी से बदलना सीखें, साथ में कोड उदाहरणों के साथ।"
---
## **परिचय**

TIFF (**Tagged Image File Format**) एक व्यापक रूप से उपयोग किया जाने वाला लॉसलैस रास्टर इमेज फ़ॉर्मेट है, जो अपनी असाधारण गुणवत्ता और ग्राफ़िक्स के विस्तृत संरक्षण के लिए जाना जाता है। डिज़ाइनर, फ़ोटोग्राफ़र और डेस्कटॉप प्रकाशक अक्सर अपने चित्रों में लेयर्स, रंग सटीकता और मूल सेटिंग्स बनाए रखने के लिए TIFF चुनते हैं।

Aspose.Slides का उपयोग करके, आप आसानी से अपने PowerPoint स्लाइड्स (PPT, PPTX) और OpenDocument स्लाइड्स (ODP) को सीधे उच्च‑गुणवत्ता वाले TIFF चित्रों में बदल सकते हैं, जिससे आपके प्रस्तुतियों में अधिकतम दृश्य फ़िडेलिटी बनी रहती है।

## **प्रेज़ेंटेशन को TIFF में बदलें**

[Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/) मेथड, जो कि [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास द्वारा प्रदान किया गया है, का उपयोग करके आप पूरे PowerPoint प्रेज़ेंटेशन को जल्दी से TIFF में बदल सकते हैं। उत्पन्न TIFF चित्र डिफ़ॉल्ट स्लाइड आकार के अनुरूप होते हैं।

यह C++ कोड दर्शाता है कि PowerPoint प्रेज़ेंटेशन को TIFF में कैसे बदलें:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Presentation वर्ग को इंस्टैंटिएट करें जो प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// प्रस्तुति को TIFF के रूप में सहेजें।
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **प्रेज़ेंटेशन को ब्लैक‑एंड‑व्हाइट TIFF में बदलें**

[TiffOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/) क्लास में मौजूद [set_BwConversionMode](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) मेथड आपको रंगीन स्लाइड या चित्र को ब्लैक‑एंड‑व्हाइट TIFF में बदलते समय उपयोग होने वाले एल्गोरिथ्म को निर्दिष्ट करने की अनुमति देता है। ध्यान दें कि यह सेटिंग केवल तब लागू होती है जब [set_CompressionType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) मेथड `CCITT4` या `CCITT3` पर सेट हो।

{{% alert color="info" title="ध्यान दें" %}}
[TiffOptions::set_BwConversionMode](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) एक एक्सपोर्ट‑लेवल सेटिंग है जो संपूर्ण TIFF चित्र के लिए पिक्सेल‑कन्वर्ज़न एल्गोरिद्म चुनती है। यह निर्धारित करने के लिए कि कोई व्यक्तिगत आकार ब्लैक‑एंड‑व्हाइट डिस्प्ले मोड सक्रिय होने पर कैसे दिखेगा, [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/set_blackwhitemode/) का उपयोग करें। उदाहरणों के लिए [Control Black-and-White Rendering for Shapes](/cpp/shape-formatting/#control-black-and-white-rendering-for-shapes) देखें।
{{% /alert %}}

मान लीजिए हमारे पास "sample.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![A presentation slide](slide_black_and_white.png)

यह C++ कोड दर्शाता है कि रंगीन स्लाइड को ब्लैक‑एंड‑व्हाइट TIFF में कैसे बदला जाए:

```cpp
#include <DOM/Presentation.h>
#include <Export/BlackWhiteConversionMode.h>
#include <Export/SaveFormat.h>
#include <Export/TiffCompressionTypes.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

परिणाम:

![Black-and-White TIFF](TIFF_black_and_white.png)

## **प्रेज़ेंटेशन को कस्टम साइज के साथ TIFF में बदलें**

यदि आप विशिष्ट आयामों वाला TIFF चित्र चाहते हैं, तो आप [TiffOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/) में उपलब्ध मेथड्स का उपयोग करके अपनी इच्छित मान सेट कर सकते हैं। उदाहरण के लिए, [set_ImageSize](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/set_imagesize/) मेथड आपको परिणामी चित्र का आकार निर्धारित करने की अनुमति देता है।

यह C++ कोड दर्शाता है कि PowerPoint प्रेज़ेंटेशन को कस्टम साइज वाले TIFF चित्रों में कैसे बदलें:

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffCompressionTypes.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Presentation वर्ग को इंस्टैंटिएट करें जो प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// संपीड़न प्रकार सेट करें।
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
Compression types:
    Default - डिफ़ॉल्ट संपीड़न योजना (LZW) निर्दिष्ट करता है।
    None - कोई संपीड़न नहीं निर्दिष्ट करता है।
    CCITT3
    CCITT4
    LZW
    RLE
*/

// गहराई संपीड़न प्रकार पर निर्भर करती है और इसे मैन्युअल रूप से सेट नहीं किया जा सकता।

// चित्र DPI सेट करें।
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// चित्र आकार सेट करें।
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// निर्दिष्ट आकार के साथ प्रस्तुति को TIFF के रूप में सहेजें।
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **प्रेज़ेंटेशन को कस्टम इमेज पिक्सेल फॉर्मेट के साथ TIFF में बदलें**

[TiffOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/) क्लास के [set_PixelFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) मेथड का उपयोग करके आप परिणामी TIFF चित्र के लिए अपनी पसंदीदा पिक्सेल फॉर्मेट निर्दिष्ट कर सकते हैं।

यह C++ कोड दर्शाता है कि PowerPoint प्रेज़ेंटेशन को कस्टम पिक्सेल फॉर्मेट वाले TIFF चित्र में कैसे बदलें:

```cpp
#include <DOM/Presentation.h>
#include <Export/ImagePixelFormat.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Presentation वर्ग को इंस्टैंटिएट करें जो प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat में निम्नलिखित मान होते हैं (दस्तावेज़ में वर्णित अनुसार):
    Format1bppIndexed - 1 बिट प्रति पिक्सेल, इंडेक्स्ड।
    Format4bppIndexed - 4 बिट प्रति पिक्सेल, इंडेक्स्ड।
    Format8bppIndexed - 8 बिट प्रति पिक्सेल, इंडेक्स्ड।
    Format24bppRgb    - 24 बिट प्रति पिक्सेल, RGB।
    Format32bppArgb   - 32 बिट प्रति पिक्सेल, ARGB।
*/

// निर्दिष्ट चित्र आकार के साथ प्रस्तुति को TIFF के रूप में सहेजें।
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="सलाह" color="info" %}}
Aspose की [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) देखें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पूरे PowerPoint प्रेज़ेंटेशन के बजाय व्यक्तिगत स्लाइड को TIFF में बदल सकता हूँ?**

हां। Aspose.Slides आपको PowerPoint और OpenDocument प्रेज़ेंटेशन की व्यक्तिगत स्लाइड्स को अलग‑अलग TIFF चित्रों में बदलने की सुविधा देता है।

**प्रेज़ेंटेशन को TIFF में बदलते समय स्लाइडों की संख्या पर कोई सीमा है क्या?**

नहीं, Aspose.Slides स्लाइडों की संख्या पर कोई प्रतिबंध नहीं लगाता। आप किसी भी आकार के प्रेज़ेंटेशन को TIFF फ़ॉर्मेट में बदल सकते हैं।

**क्या स्लाइड्स को TIFF में बदलते समय PowerPoint एनीमेशन और ट्रांज़िशन इफेक्ट्स संरक्षित रहते हैं?**

नहीं, TIFF एक स्थिर चित्र फ़ॉर्मेट है। इसलिए एनीमेशन और ट्रांज़िशन इफेक्ट्स संरक्षित नहीं होते; केवल स्लाइडों के स्थिर स्नैपशॉट निर्यात किए जाते हैं।