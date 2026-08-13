---
title: "C++ में PowerPoint प्रस्तुतियों को TIFF में परिवर्तित करें"
titlelink: "PowerPoint से TIFF"
type: docs
weight: 90
url: /hi/cpp/convert-powerpoint-to-tiff/
keywords:
- "PowerPoint परिवर्तित करें"
- "OpenDocument परिवर्तित करें"
- "प्रस्तुति परिवर्तित करें"
- "स्लाइड परिवर्तित करें"
- "PPT परिवर्तित करें"
- "PPTX परिवर्तित करें"
- "PowerPoint से TIFF"
- "प्रस्तुति से TIFF"
- "स्लाइड से TIFF"
- "PPT से TIFF"
- "PPTX से TIFF"
- "PPT को TIFF के रूप में सहेजें"
- "PPTX को TIFF के रूप में सहेजें"
- "PPT को TIFF में निर्यात करें"
- "PPTX को TIFF में निर्यात करें"
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ का उपयोग करके PowerPoint (PPT, PPTX) प्रस्तुतियों को उच्च-गुणवत्ता वाले TIFF इमेज में आसानी से परिवर्तित करना सीखें, कोड उदाहरणों सहित."
---
## **परिचय**

TIFF (**Tagged Image File Format**) एक व्यापक रूप से उपयोग किया जाने वाला, लॉसलेस रास्टर इमेज फ़ॉर्मेट है जो अपनी उत्कृष्ट गुणवत्ता और ग्राफ़िक्स के विस्तृत संरक्षण के लिए जाना जाता है। डिजाइनर, फ़ोटोग्राफ़र, और डेस्कटॉप पब्लिशर अक्सर TIFF चुनते हैं ताकि अपनी छवियों में लेयर्स, रंग सटीकता, और मूल सेटिंग्स को बना रखा जा सके।

Aspose.Slides का उपयोग करके, आप अपने PowerPoint स्लाइड्स (PPT, PPTX) और OpenDocument स्लाइड्स (ODP) को आसानी से सीधे उच्च-गुणवत्ता वाले TIFF इमेज में बदल सकते हैं, जिससे आपकी प्रस्तुतियां अधिकतम दृश्य सटीकता बनाए रखें।

## **प्रेजेंटेशन को TIFF में बदलें**

जिस [Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/) मेथड को [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) क्लास प्रदान करता है, उसका उपयोग करके आप पूरी PowerPoint प्रस्तुति को जल्दी से TIFF में बदल सकते हैं। परिणामी TIFF इमेज डिफ़ॉल्ट स्लाइड आकार के अनुरूप होते हैं।

यह C++ कोड दर्शाता है कि PowerPoint प्रस्तुति को TIFF में कैसे बदलें:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Presentation वर्ग का उदाहरण बनाएं जो एक प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) को दर्शाता है।
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// प्रस्तुति को TIFF के रूप में सहेजें।
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **प्रेजेंटेशन को काला-धूसर TIFF में बदलें**

[set_BwConversionMode](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) मेथड, जो [TiffOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/) क्लास में है, आपको रंगीन स्लाइड या इमेज को काला-धूसर TIFF में बदलते समय उपयोग किए जाने वाले एल्गोरिद्म को निर्धारित करने देता है। ध्यान रखें कि यह सेटिंग केवल तभी लागू होती है जब [set_CompressionType](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) मेथड `CCITT4` या `CCITT3` पर सेट किया गया हो।

मान लीजिए हमारे पास एक "sample.pptx" फ़ाइल है जिसमें निम्नलिखित स्लाइड है:

![एक प्रस्तुति स्लाइड](slide_black_and_white.png)

यह C++ कोड दर्शाता है कि रंगीन स्लाइड को काला-धूसर TIFF में कैसे बदलें:

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

![काला-धूसर TIFF](TIFF_black_and_white.png)

## **प्रेजेंटेशन को कस्टम आकार के साथ TIFF में बदलें**

यदि आपको विशिष्ट आयामों के साथ TIFF इमेज चाहिए, तो आप [TiffOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/) में उपलब्ध मेथड्स का उपयोग करके अपनी इच्छित मान सेट कर सकते हैं। उदाहरण के लिए, [set_ImageSize](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/set_imagesize/) मेथड आपको परिणामी इमेज का आकार निर्धारित करने देता है।

यह C++ कोड दर्शाता है कि PowerPoint प्रस्तुति को कस्टम आकार के साथ TIFF इमेज में कैसे बदलें:

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

// Presentation वर्ग का उदाहरण बनाएं जो एक प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) को दर्शाता है।
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// संपीड़न प्रकार सेट करें।
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
संपीड़न प्रकार:
    Default - डिफ़ॉल्ट संपीड़न योजना (LZW) को निर्दिष्ट करता है।
    None - कोई संपीड़न नहीं होने को निर्दिष्ट करता है।
    CCITT3
    CCITT4
    LZW
    RLE
*/

// गहराई संपीड़न प्रकार पर निर्भर करती है और इसे मैन्युअल रूप से सेट नहीं किया जा सकता।

// इमेज DPI सेट करें।
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// इमेज आकार सेट करें।
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// निर्दिष्ट आकार के साथ प्रस्तुति को TIFF के रूप में सहेजें।
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **प्रेजेंटेशन को कस्टम इमेज पिक्सेल फॉर्मेट के साथ TIFF में बदलें**

[TiffOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/) क्लास के [set_PixelFormat](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) मेथड का उपयोग करके आप परिणामी TIFF इमेज के लिए अपनी पसंदीदा पिक्सेल फॉर्मेट निर्दिष्ट कर सकते हैं।

यह C++ कोड दर्शाता है कि PowerPoint प्रस्तुति को कस्टम पिक्सेल फॉर्मेट वाले TIFF इमेज में कैसे बदलें:

```cpp
#include <DOM/Presentation.h>
#include <Export/ImagePixelFormat.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Presentation वर्ग का उदाहरण बनाएं जो एक प्रस्तुति फ़ाइल (PPT, PPTX, ODP, आदि) को दर्शाता है।
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat में निम्नलिखित मान हैं (दस्तावेज़ में जैसा बताया गया है):
    Format1bppIndexed - 1 बिट प्रति पिक्सेल, इंडेक्स्ड.
    Format4bppIndexed - 4 बिट प्रति पिक्सेल, इंडेक्स्ड.
    Format8bppIndexed - 8 बिट प्रति पिक्सेल, इंडेक्स्ड.
    Format24bppRgb    - 24 बिट प्रति पिक्सेल, RGB.
    Format32bppArgb   - 32 बिट प्रति पिक्सेल, ARGB.
*/

// निर्दिष्ट इमेज आकार के साथ प्रस्तुति को TIFF के रूप में सहेजें।
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="सलाह" color="info" %}}
Aspose के [नि:शुल्क PowerPoint से पोस्टर कनवर्टर](https://products.aspose.app/slides/hi/conversion/convert-ppt-to-poster-online) को देखें।
{{% /alert %}}

## **अक्सर पूछे जाने वाले प्रश्न**

### क्या मैं पूरे PowerPoint प्रस्तुति के बजाय व्यक्तिगत स्लाइड को TIFF में बदल सकता हूँ?

हाँ। Aspose.Slides आपको PowerPoint और OpenDocument प्रस्तुतियों की व्यक्तिगत स्लाइड्स को अलग‑अलग TIFF इमेज में बदलने की अनुमति देता है।

### क्या प्रेजेंटेशन को TIFF में बदलते समय स्लाइडों की संख्या पर कोई सीमा है?

नहीं, Aspose.Slides स्लाइडों की संख्या पर कोई प्रतिबंध नहीं लगाता। आप किसी भी आकार की प्रस्तुतियों को TIFF फॉर्मेट में बदल सकते हैं।

### क्या PowerPoint एनिमेशन और ट्रांज़िशन इफ़ेक्ट्स को स्लाइड्स को TIFF में बदलते समय संरक्षित किया जाता है?

नहीं, TIFF एक स्थिर इमेज फॉर्मेट है। इसलिए, एनिमेशन और ट्रांज़िशन इफ़ेक्ट्स संरक्षित नहीं रहते; केवल स्लाइडों के स्थिर स्नैपशॉट निर्यात किए जाते हैं।