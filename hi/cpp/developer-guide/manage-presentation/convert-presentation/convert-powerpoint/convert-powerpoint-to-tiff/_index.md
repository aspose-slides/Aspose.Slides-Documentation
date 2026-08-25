---
title: C++ में PowerPoint प्रस्तुतियों को TIFF में परिवर्तित करें
titlelink: PowerPoint से TIFF
type: docs
weight: 90
url: /hi/cpp/convert-powerpoint-to-tiff/
keywords:
  - PowerPoint परिवर्तित करें
  - OpenDocument परिवर्तित करें
  - प्रस्तुति परिवर्तित करें
  - स्लाइड परिवर्तित करें
  - PPT परिवर्तित करें
  - PPTX परिवर्तित करें
  - PowerPoint से TIFF
  - प्रस्तुति से TIFF
  - स्लाइड से TIFF
  - PPT से TIFF
  - PPTX से TIFF
  - PPT को TIFF के रूप में सहेजें
  - PPTX को TIFF के रूप में सहेजें
  - PPT को TIFF में निर्यात करें
  - PPTX को TIFF में निर्यात करें
  - C++
  - Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint (PPT, PPTX) प्रस्तुतियों को उच्च-गुणवत्ता वाले TIFF चित्रों में आसानी से कैसे परिवर्तित करें, कोड उदाहरणों के साथ सीखें।"
---
## **परिचय**

TIFF (**Tagged Image File Format**) एक व्यापक रूप से उपयोग किया जाने वाला, लॉसेस रास्टर इमेज फ़ॉर्मेट है, जिसे उसकी उत्कृष्ट गुणवत्ता और ग्राफिक्स के विस्तृत संरक्षण के लिए जाना जाता है। डिजाइनर, फोटोग्राफ़र, और डेस्कटॉप प्रकाशक अक्सर अपने चित्रों में लेयर्स, रंग की शुद्धता, और मूल सेटिंग्स को बनाए रखने के लिए TIFF का चयन करते हैं।

Aspose.Slides का उपयोग करके, आप आसानी से अपने PowerPoint स्लाइड्स (PPT, PPTX) और OpenDocument स्लाइड्स (ODP) को सीधे उच्च-गुणवत्ता वाले TIFF चित्रों में परिवर्तित कर सकते हैं, यह सुनिश्चित करते हुए कि आपके प्रस्तुतियों में अधिकतम दृश्य सच्चाई बनी रहे।

## **प्रेज़ेंटेशन को TIFF में परिवर्तित करें**

[Presentation] क्लास द्वारा प्रदान किए गए [Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/) मेथड का उपयोग करके, आप जल्दी से पूरे PowerPoint प्रेज़ेंटेशन को TIFF में परिवर्तित कर सकते हैं। परिणामस्वरूप TIFF छवियां डिफ़ॉल्ट स्लाइड आकार के अनुरूप होती हैं।

यह C++ कोड दर्शाता है कि PowerPoint प्रेज़ेंटेशन को TIFF में कैसे परिवर्तित किया जाए:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// एक Presentation क्लास का उदाहरण बनाते हैं जो प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करता है।
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// प्रस्तुति को TIFF के रूप में सहेजें।
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **प्रेज़ेंटेशन को ब्लैक‑एंड‑व्हाइट TIFF में परिवर्तित करना**

[TiffOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/) क्लास में [set_BwConversionMode](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) मेथड आपको रंगीन स्लाइड या इमेज को ब्लैक‑एंड‑व्हाइट TIFF में परिवर्तित करने के दौरान उपयोग किए जाने वाले एल्गोरिद्म को निर्दिष्ट करने की अनुमति देता है। ध्यान दें कि यह सेटिंग केवल तभी लागू होती है जब [set_CompressionType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) मेथड को `CCITT4` या `CCITT3` पर सेट किया गया हो।

{{% alert color="info" title="नोट" %}}
[TiffOptions::set_BwConversionMode](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) एक निर्यात‑स्तरीय सेटिंग है जो संपूर्ण TIFF छवि के लिए पिक्सेल‑परिवर्तन एल्गोरिद्म चुनती है। जब ब्लैक‑एंड‑व्हाइट डिस्प्ले मोड सक्रिय हो, तो यह निर्धारित करने के लिए कि व्यक्तिगत शेप कैसे दिखेगा, [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/set_blackwhitemode/) का उपयोग करें। उदाहरणों के लिए देखें [Control Black-and-White Rendering for Shapes](/slides/hi/cpp/shape-formatting/#control-black-and-white-rendering-for-shapes)।
{{% /alert %}}

मान लीजिए हमारे पास "sample.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![एक प्रस्तुति स्लाइड](slide_black_and_white.png)

यह C++ कोड दर्शाता है कि रंगीन स्लाइड को ब्लैक‑एंड‑व्हाइट TIFF में कैसे परिवर्तित किया जाए:

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

![ब्लैक‑एंड‑व्हाइट TIFF](TIFF_black_and_white.png)

## **कस्टम आकार के साथ प्रेज़ेंटेशन को TIFF में परिवर्तित करें**

यदि आपको विशिष्ट आयामों के साथ TIFF इमेज चाहिए, तो आप [TiffOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/) में उपलब्ध मेथड्स का उपयोग करके अपनी इच्छित मान सेट कर सकते हैं। उदाहरण के लिए, [set_ImageSize](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/set_imagesize/) मेथड आपको परिणामी इमेज का आकार निर्धारित करने की अनुमति देता है।

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

// प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाते हैं।
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// संपीड़न प्रकार सेट करें।
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
संपीड़न प्रकार:
    Default - डिफ़ॉल्ट संपीड़न योजना (LZW) निर्दिष्ट करता है।
    None - कोई संपीड़न नहीं निर्दिष्ट करता।
    CCITT3
    CCITT4
    LZW
    RLE
*/

// गहराई संपीड़न प्रकार पर निर्भर करती है और इसे मैनुअल रूप से सेट नहीं किया जा सकता है।

// छवि DPI सेट करें।
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// छवि आकार सेट करें।
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// निर्दिष्ट आकार के साथ प्रस्तुति को TIFF के रूप में सहेजें।
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **कस्टम इमेज पिक्सेल फॉर्मेट के साथ प्रेज़ेंटेशन को TIFF में परिवर्तित करें**

[TiffOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/) क्लास से [set_PixelFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) मेथड का उपयोग करके, आप परिणामी TIFF इमेज के लिए अपनी पसंदीदा पिक्सेल फॉर्मेट निर्दिष्ट कर सकते हैं।

```cpp
#include <DOM/Presentation.h>
#include <Export/ImagePixelFormat.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) का प्रतिनिधित्व करने वाले Presentation क्लास का उदाहरण बनाते हैं।
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat में निम्नलिखित मान होते हैं (दस्तावेज़ में जैसा बताया गया है):
    Format1bppIndexed - प्रति पिक्सेल 1 बिट, इंडेक्स्ड।
    Format4bppIndexed - प्रति पिक्सेल 4 बिट, इंडेक्स्ड।
    Format8bppIndexed - प्रति पिक्सेल 8 बिट, इंडेक्स्ड।
    Format24bppRgb    - प्रति पिक्सेल 24 बिट, RGB।
    Format32bppArgb   - प्रति पिक्सेल 32 बिट, ARGB।
*/

// निर्दिष्ट छवि आकार के साथ प्रस्तुति को TIFF के रूप में सहेजें।
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="सलाह" color="info" %}}
Aspose का [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) देखें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं पूरे PowerPoint प्रेज़ेंटेशन के बजाय व्यक्तिगत स्लाइड को TIFF में परिवर्तित कर सकता हूँ?**

हाँ। Aspose.Slides आपको PowerPoint और OpenDocument प्रेज़ेंटेशन से व्यक्तिगत स्लाइड्स को अलग‑अलग TIFF इमेजेज़ में परिवर्तित करने की अनुमति देता है।

**क्या प्रेज़ेंटेशन को TIFF में परिवर्तित करने के दौरान स्लाइड्स की संख्या पर कोई सीमा है?**

नहीं, Aspose.Slides स्लाइड्स की संख्या पर कोई प्रतिबंध नहीं लगाता। आप किसी भी आकार के प्रेज़ेंटेशन को TIFF फ़ॉर्मेट में परिवर्तित कर सकते हैं।

**क्या PowerPoint एनीमेशन और ट्रांज़िशन इफेक्ट्स को स्लाइड्स को TIFF में परिवर्तित करने पर संरक्षित रखा जाता है?**

नहीं, TIFF एक स्थैतिक इमेज फ़ॉर्मेट है। इसलिए, एनीमेशन और ट्रांज़िशन इफेक्ट्स संरक्षित नहीं रहते; केवल स्लाइड्स के स्थैतिक स्नैपशॉट्स निर्यात किए जाते हैं।