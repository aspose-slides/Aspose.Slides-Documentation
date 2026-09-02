---
title: C++ में प्रस्तुति इंक ऑब्जेक्ट्स का प्रबंधन
linktitle: इंक प्रबंधन
type: docs
weight: 95
url: /hi/cpp/manage-ink/
keywords:
- इंक
- इंक ऑब्जेक्ट
- इंक ट्रेस
- इंक प्रबंधन
- इंक ड्रॉ करें
- ड्रॉइंग
- इंक निर्यात
- इंक रेंडरिंग
- इंक छुपाएँ
- IInkOptions
- PowerPoint
- प्रस्तुति
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ के साथ PowerPoint इंक ऑब्जेक्ट्स को प्रबंधित करें, ट्रेसेस और ब्रश गुणों को संपादित करें, और PDF, HTML, SVG, TIFF तथा इमेज निर्यात के दौरान इंक की उपस्थिति को नियंत्रित करें।"
---
## **परिचय**

PowerPoint एक इंक सुविधा प्रदान करता है जो आपको मुक्तआकृति स्ट्रोक्स ड्रॉ करने देती है। इंक का उपयोग अन्य वस्तुओं को हाइलाइट करने, कनेक्शन और प्रक्रियाओं को दिखाने, और स्लाइड पर विशिष्ट आइटम्स पर ध्यान आकर्षित करने के लिए किया जा सकता है।

[Aspose.Slides.Ink](https://reference.aspose.com/slides/hi/cpp/aspose.slides.ink/) नामस्थान में इंक ऑब्जेक्ट्स के साथ काम करने के लिए आवश्यक क्लासेज़ और इंटरफ़ेस शामिल हैं। उदाहरण के लिए, इंटरफ़ेस [IInk](https://reference.aspose.com/slides/hi/cpp/aspose.slides.ink/iink/) एक स्लाइड पर इंक ऑब्जेक्ट का प्रतिनिधित्व करता है।

## **साधारण ऑब्जेक्ट्स और इंक ऑब्जेक्ट्स के बीच अंतर**

PowerPoint स्लाइड पर ऑब्जेक्ट्स आमतौर पर शेप ऑब्जेक्ट्स द्वारा दर्शाए जाते हैं। सबसे सरल रूप में, शेप एक कंटेनर है जो ऑब्जेक्ट के क्षेत्र (उसका फ्रेम) को परिभाषित करता है, साथ ही कंटेनर का आकार, आकार और बैकग्राउंड जैसी विशेषताओं के साथ। अधिक जानकारी के लिए देखें [शेप लेआउट फ़ॉर्मेट](https://docs.aspose.com/slides/hi/cpp/shape-manipulations/#access-layout-formats-for-shape)।

हालाँकि, जब PowerPoint इंक ऑब्जेक्ट को संभालता है, तो वह ऑब्जेक्ट फ्रेम (कंटेनर) की सभी विशेषताओं को छोड़ देता है सिवाय उसके आकार के। कंटेनर क्षेत्र का आकार मानक [IShape::get_Width](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_width/) और [IShape::get_Height](https://reference.aspose.com/slides/hi/cpp/aspose.slides/ishape/get_height/) विधियों द्वारा निर्धारित होता है:

![ink_powerpoint1](ink_powerpoint1.png)

## **इंक ट्रेसेस**

इंक ट्रेस एक बुनियादी तत्व है जो उपयोगकर्ता द्वारा डिजिटल इंक लिखते समय पेन की गति को रिकॉर्ड करता है। एक ट्रेस जुड़े हुए बिंदुओं की क्रमबद्धता संग्रहीत करता है।

कोडिंग का सबसे सरल रूप प्रत्येक सैंपल बिंदु के X और Y निर्देशांक को निर्दिष्ट करता है। जब सभी जुड़े हुए बिंदुओं को रेंडर किया जाता है, तो वे इस प्रकार की छवि बनाते हैं:

![ink_powerpoint2](ink_powerpoint2.png)

## **ड्रॉइंग के लिए ब्रश प्रॉपर्टीज़**

ब्रश का उपयोग इंक ट्रेस के बिंदुओं को जोड़ने वाली रेखाओं को ड्रॉ करने के लिए किया जाता है। ब्रश का अपना रंग और आकार होता है, जिसे [IInkBrush::get_Color](https://reference.aspose.com/slides/hi/cpp/aspose.slides.ink/iinkbrush/get_color/) और [IInkBrush::get_Size](https://reference.aspose.com/slides/hi/cpp/aspose.slides.ink/iinkbrush/get_size/) विधियों द्वारा दर्शाया गया है।

### **इंक ब्रश का रंग सेट करें**

यह C++ कोड दिखाता है कि इंक ब्रश का रंग कैसे सेट करें:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Color(System::Drawing::Color::get_Red());

presentation->Dispose();
```

### **इंक ब्रश का आकार सेट करें**

यह C++ कोड दिखाता है कि इंक ब्रश का आकार कैसे सेट करें:

```cpp
#include <DOM/Ink/IInk.h>
#include <DOM/Ink/IInkBrush.h>
#include <DOM/Ink/IInkTrace.h>
#include <DOM/Presentation.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Ink::IInk;
using Aspose::Slides::Presentation;
using System::ExplicitCast;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"pres.pptx");
auto ink = ExplicitCast<IInk>(presentation->get_Slide(0)->get_Shape(0));
auto inkTrace = ink->get_Traces()[0];
auto brush = inkTrace->get_Brush();
brush->set_Size(System::Drawing::SizeF(5.0f, 10.0f));

presentation->Dispose();
```

आम तौर पर, ब्रश की चौड़ाई और ऊँचाई समान नहीं होती, इसलिए PowerPoint ब्रश के आकार को प्रदर्शित नहीं करता (संबंधित डेटा सेक्शन ग्रे हो जाता है)। जब ब्रश की चौड़ाई और ऊँचाई समान होती है, तो PowerPoint अपना आकार इस प्रकार दिखाता है:

![ink_powerpoint3](ink_powerpoint3.png)

स्पष्टीकरण के लिए, आइए इंक ऑब्जेक्ट की ऊँचाई बढ़ाएँ और महत्वपूर्ण आयामों की समीक्षा करें:

![ink_powerpoint4](ink_powerpoint4.png)

कंटेनर (फ़्रेम) ब्रश के आकार को नहीं मानता—यह हमेशा मान लेता है कि रेखा की मोटाई शून्य है (पिछली छवि देखें)।

इसलिए, पूरे इंक ऑब्जेक्ट के दृश्यों को निर्धारित करने के लिए उसके ट्रेसेस के ब्रश आकार को ध्यान में रखना आवश्यक है। यहाँ, लक्ष्य ऑब्जेक्ट (हैंडराइटन टेक्स्ट ट्रेस) को कंटेनर (फ़्रेम) के आकार के अनुसार स्केल किया गया है। जब कंटेनर का आकार बदलता है, तो ब्रश आकार स्थिर रहता है, और इसके विपरीत भी।

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint टेक्स्ट ऑब्जेक्ट्स के लिए समान व्यवहार का उपयोग करता है:

![ink_powerpoint6](ink_powerpoint6.png)

## **निर्यात और रेंडरिंग के दौरान इंक की उपस्थिति नियंत्रित करें**

Aspose.Slides [IInkOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/iinkoptions/) इंटरफ़ेस प्रदान करता है जिससे आप निर्यात या रेंडर किए गए आउटपुट में इंक ऑब्जेक्ट्स की उपस्थिति को नियंत्रित कर सकते हैं। आप इसकी विधियों का उपयोग करके इंक को पूरी तरह छिपा सकते हैं या इंक ब्रश मास्क ऑपरेशन्स की व्याख्या बदल सकते हैं।

इंक विकल्पों को कई आउटपुट प्रकारों के निर्यात या रेंडरिंग विकल्पों के माध्यम से उपलब्ध कराया जाता है:

| आउटपुट | इंक विकल्प विधि |
| --- | --- |
| PDF | [PdfOptions::get_InkOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/pdfoptions/get_inkoptions/) |
| HTML | [HtmlOptions::get_InkOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/htmloptions/get_inkoptions/) |
| SVG | [SVGOptions::get_InkOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/svgoptions/get_inkoptions/) |
| TIFF | [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) |
| स्लाइड इमेज | [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) |

इन विधियों के माध्यम से दो समान सेटिंग्स उपलब्ध हैं:

- [IInkOptions::set_HideInk](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/iinkoptions/set_hideink/) निर्धारित करता है कि इंक ऑब्जेक्ट्स आउटपुट में शामिल हों या नहीं। इसकी डिफ़ॉल्ट वैल्यू `false` है।
- [IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) निर्धारित करता है कि रेंडरिंग के दौरान इंक ब्रश की मास्क ऑपरेशन को अपारदर्शिता के रूप में व्याख्यायित किया जाए या नहीं। इसका डिफ़ॉल्ट मान `true` है; `false` सेट करने पर ROP ऑपरेशन उपयोग होगा।

### **PDF आउटपुट में इंक ऑब्जेक्ट्स छिपाएँ**

डिफ़ॉल्ट रूप से, निर्यात के दौरान इंक ऑब्जेक्ट्स दिखाई देते हैं। जब आपको हैंडरिटन एनोटेशन या अन्य इंक सामग्री के बिना साफ़ आउटपुट चाहिए, तो `true` के साथ [IInkOptions::set_HideInk](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/iinkoptions/set_hideink/) कॉल करें।

निम्न C++ उदाहरण सभी इंक ऑब्जेक्ट्स को छिपाते हुए प्रस्तुति को PDF में निर्यात करता है:

```cpp
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::PdfOptions;
using Aspose::Slides::Export::SaveFormat;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->get_InkOptions()->set_HideInk(true);

presentation->Save(u"presentation_without_ink.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **स्लाइड को इमेज के रूप में रेंडर करते समय इंक ऑब्जेक्ट्स छिपाएँ**

स्लाइड को बिटमैप इमेज के रूप में रेंडर करते समय इंक ऑब्जेक्ट्स को छिपाने के लिए [RenderingOptions::get_InkOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/renderingoptions/get_inkoptions/) को कॉन्फ़िगर करें और रेंडरिंग विकल्पों को [ISlide::GetImage](https://reference.aspose.com/slides/hi/cpp/aspose.slides/islide/getimage/) मेथड में पास करें।

निम्न C++ उदाहरण पहली स्लाइड को PNG इमेज के रूप में इंक ऑब्जेक्ट्स के बिना रेंडर करता है:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/RenderingOptions.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/smart_ptr.h>

using Aspose::Slides::ImageFormat;
using Aspose::Slides::Presentation;
using Aspose::Slides::Export::RenderingOptions;
using System::MakeObject;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->get_InkOptions()->set_HideInk(true);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions);
image->Save(u"slide_without_ink.png", ImageFormat::Png);

image->Dispose();
presentation->Dispose();
```

### **इंक मास्क रेंडरिंग नियंत्रित करें**

[IInkOptions::set_InterpretMaskOpAsOpacity](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/iinkoptions/set_interpretmaskopasopacity/) मेथड रेंडरिंग के दौरान इंक ब्रश के मास्क ऑपरेशन्स की व्याख्या को नियंत्रित करता है। डिफ़ॉल्ट मान `true` है, जो अपारदर्शिता उपयोग करता है। इसे `false` सेट करने पर ROP ऑपरेशन उपयोग होगा।

निम्न C++ उदाहरण एक स्लाइड को SVG में निर्यात करता है और इंक मास्क ऑपरेशन्स के लिए ROP-आधारित रेंडरिंग का उपयोग करता है:

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/IInkOptions.h>
#include <Export/SVGOptions.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using Aspose::Slides::Presentation;
using Aspose::Slides::Export::SVGOptions;
using System::MakeObject;
using System::IO::File;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto svgOptions = MakeObject<SVGOptions>();
svgOptions->get_InkOptions()->set_InterpretMaskOpAsOpacity(false);

auto stream = File::Create(u"slide.svg");
presentation->get_Slide(0)->WriteAsSvg(stream, svgOptions);

stream->Dispose();
presentation->Dispose();
```

जब कोई प्रस्तुति निर्यात की जा रही हो या स्लाइड को TIFF में रेंडर किया जा रहा हो, तो समान सेटिंग को [TiffOptions::get_InkOptions](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/tiffoptions/get_inkoptions/) के माध्यम से लागू किया जा सकता है।

### **इंक को छिपाएँ या संरक्षित रखें, यह चुनें**

जब निर्यातित फ़ाइल एनोटेटेड प्रस्तुति का साफ़ संस्करण होनी चाहिए (जैसे वितरण के लिए अंतिम प्रति), तो `true` के साथ [IInkOptions::set_HideInk](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/iinkoptions/set_hideink/) उपयोग करें।

यदि इंक एनोटेशन इच्छित सामग्री का हिस्सा हैं—जैसे रिव्यू कमेंट, हैंडरिटन नोट, हाइलाइट या ड्रॉइंग—तो डिफ़ॉल्ट `false` सेटिंग के साथ इंक को दृश्यमान रखें। इससे एप्लिकेशन एक ही प्रस्तुति से अलग-अलग रिव्यू और फाइनल आउटपुट उत्पन्न कर सकते हैं बिना स्रोत इंक ऑब्जेक्ट्स को संशोधित किए।

## **अक्सर पूछे जाने वाले प्रश्न**

**क्या मैं मौजूदा इंक स्ट्रोक का रंग या आकार बदल सकता हूँ?**

हाँ। [IInk::get_Traces](https://reference.aspose.com/slides/hi/cpp/aspose.slides.ink/iink/get_traces/) से ट्रेस प्राप्त करें, फिर उसकी [IInkTrace::get_Brush](https://reference.aspose.com/slides/hi/cpp/aspose.slides.ink/iinktrace/get_brush/) को बदलें। आप ब्रश पर [IInkBrush::set_Color](https://reference.aspose.com/slides/hi/cpp/aspose.slides.ink/iinkbrush/set_color/) और [IInkBrush::set_Size](https://reference.aspose.com/slides/hi/cpp/aspose.slides.ink/iinkbrush/set_size/) कॉल कर सकते हैं।

**क्या इंक को छिपाने से स्रोत प्रस्तुति बदलती है?**

नहीं। [IInkOptions::set_HideInk](https://reference.aspose.com/slides/hi/cpp/aspose.slides.export/iinkoptions/set_hideink/) केवल रेंडर या निर्यात परिणाम को प्रभावित करता है; यह स्रोत प्रस्तुति में इंक ऑब्जेक्ट्स को नहीं हटाता या संशोधित नहीं करता।

**कौन से निर्यात फ़ॉर्मेट इंक विकल्पों का समर्थन करते हैं?**

आप ऊपर दिखाए गए संबंधित निर्यात या रेंडरिंग विकल्पों के माध्यम से PDF, HTML, SVG, TIFF, और बिटमैप स्लाइड इमेज के लिए इंक विकल्प कॉन्फ़िगर कर सकते हैं।

**अधिक पढ़ें**

* शेप्स के बारे में सामान्य जानकारी के लिए देखें [PowerPoint Shapes](https://docs.aspose.com/slides/hi/cpp/powerpoint-shapes/) सेक्शन।
* प्रभावी मानों के बारे में अधिक जानकारी के लिए देखें [Shape Effective Properties](https://docs.aspose.com/slides/hi/cpp/shape-effective-properties/#get-effective-font-height-value)।
* PDF निर्यात के विवरण के लिए देखें [Convert PPT and PPTX to PDF](https://docs.aspose.com/slides/hi/cpp/convert-powerpoint-to-pdf/)।
* HTML निर्यात के विवरण के लिए देखें [Convert PowerPoint Presentations to HTML](https://docs.aspose.com/slides/hi/cpp/convert-powerpoint-to-html/)।
* SVG निर्यात के विवरण के लिए देखें [Render Presentation Slides as SVG Images](https://docs.aspose.com/slides/hi/cpp/render-a-slide-as-an-svg-image/)।
* TIFF निर्यात के विवरण के लिए देखें [Convert PowerPoint Presentations to TIFF](https://docs.aspose.com/slides/hi/cpp/convert-powerpoint-to-tiff/)।
* स्लाइड‑से‑इमेज रेंडरिंग के विवरण के लिए देखें [Convert Presentation Slides to Images](https://docs.aspose.com/slides/hi/cpp/convert-slide/).