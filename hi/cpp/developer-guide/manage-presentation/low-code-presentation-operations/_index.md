---
title: C++ में लो-कोड प्रस्तुति संचालन
linktitle: लो-कोड API
type: docs
weight: 50
url: /hi/cpp/low-code-presentation-operations/
keywords:
- लो-कोड प्रस्तुति API
- प्रस्तुति रूपांतरित करें
- प्रस्तुतियों को मिलाएँ
- स्लाइड्स पर पुनरावृति करें
- शैप्स पर पुनरावृति करें
- टेक्स्ट पर पुनरावृति करें
- शैप्स एकत्र करें
- प्रस्तुति संपीड़ित करें
- अप्रयुक्त मास्टर स्लाइड्स हटाएँ
- अप्रयुक्त लेआउट स्लाइड्स हटाएँ
- एम्बेडेड फ़ॉन्ट संपीड़ित करें
- PowerPoint
- OpenDocument
- प्रस्तुति
- C++
- Aspose.Slides
description: "C++ में Aspose.Slides लो-कोड API का उपयोग करके प्रस्तुतियों को रूपांतरित और मिलाएँ, सामग्री पर पुनरावृति करें, शैप्स एकत्र करें, और प्रस्तुति का आकार घटाएँ।"
---
## **अवलोकन**

The [Aspose::Slides::LowCode](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/) namespace provides static helper classes for common presentation operations. These helpers wrap frequently used object-model workflows in focused methods, so you can convert or merge files, process presentation elements, collect shapes, and remove unused content with less code.

Low-code helpers are most useful when the operation applies to an entire file or presentation and the default workflow matches your requirements. Use the full [Aspose.Slides object model](https://reference.aspose.com/slides/hi/cpp/aspose.slides/) when you need fine-grained control over individual slides, masters, layouts, shapes, export settings, or relationships between presentation elements.

The following table summarizes the available helpers:

| सहायक | उपयोग |
| --- | --- |
| [Convert](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/convert/) | सीधे फ़ाइल‑से‑फ़ाइल कॉल के साथ एक प्रस्तुति को दूसरे फ़ॉर्मेट में बदलना। |
| [Merger](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/merger/) | समान फ़ॉर्मेट की पूर्ण प्रस्तुति फ़ाइलों को संयोजित करना। |
| [ForEach](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/foreach/) | प्रत्येक स्लाइड, शैप, पैराग्राफ या टेक्स्ट भाग के लिए कार्रवाई चलाना। |
| [Collect](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/collect/) | बार‑बार प्रक्रिया या विश्लेषण के लिए पूरी प्रस्तुति से शैप्स प्राप्त करना। |
| [Compress](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/) | अप्रयुक्त मास्टर और लेआउट को हटाना और एम्बेडेड फ़ॉन्ट डेटा को कम करना। |

## **एक प्रस्तुति को रूपांतरित करें**

Use [Convert::AutoByExtension](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/convert/autobyextension/) when the output file extension is sufficient to select the export format. The method opens the source presentation, determines the required format from the output path, and writes the result.

```cpp
#include <LowCode/Convert.h>

using namespace Aspose::Slides::LowCode;

Convert::AutoByExtension(u"input.pptx", u"output.pdf");
```

The [Convert](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/convert/) class also provides dedicated methods for PDF, SVG, JPEG, PNG, and TIFF output. Use the full object model when you need to inspect or modify the presentation before export or configure an export option that is not exposed by the selected helper. See [Convert Presentation](/cpp/convert-presentation/) for format-specific workflows and options.

## **प्रस्तुतियों को मिलाएँ**

Use [Merger::Process](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/merger/process/) to combine complete presentation files with one call. The input presentations must have the same file format.

```cpp
#include <LowCode/Merger.h>
#include <system/array.h>
#include <system/string.h>

using namespace Aspose::Slides::LowCode;

auto inputFiles = System::MakeArray<System::String>({u"part-1.pptx", u"part-2.pptx"});
Merger::Process(inputFiles, u"merged.pptx");
```

The helper is appropriate when all slides should be appended to one result without selecting or remapping them individually. Use the full object model when you need to merge selected slides, apply a destination master or layout, preserve sections explicitly, or reconcile different slide sizes. See [Merge Presentations](/cpp/merge-presentation/) for those scenarios.

## **प्रस्तुति तत्वों पर पुनरावृति करें**

The [ForEach](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/foreach/) class invokes a callback for each requested type of presentation element. It avoids nested collection loops and is convenient for presentation-wide inspection or formatting changes.

The following example uses [ForEach::Slide](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/foreach/slide/), [ForEach::Shape](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/foreach/paragraph/), and [ForEach::Portion](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/foreach/portion/) to inspect the corresponding elements:

```cpp
#include <DOM/BaseSlide.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <DOM/Slide.h>
#include <LowCode/ForEach.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <functional>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

auto slideCallback = std::function<void(System::SharedPtr<Slide>, int32_t)>([](System::SharedPtr<Slide> slide, int32_t index)
{
    System::Console::WriteLine(u"Slide {0}: {1} shapes", index, slide->get_Shapes()->get_Count());
});
ForEach::Slide(presentation, slideCallback);

auto shapeCallback = std::function<void(System::SharedPtr<Shape>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Shape> shape, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Shape {0}: {1}", index, shape->get_Name());
});
ForEach::Shape(presentation, shapeCallback);

auto paragraphCallback = std::function<void(System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Paragraph {0}: {1}", index, paragraph->get_Text());
});
ForEach::Paragraph(presentation, paragraphCallback);

auto portionCallback = std::function<void(System::SharedPtr<Portion>, System::SharedPtr<Paragraph>, System::SharedPtr<BaseSlide>, int32_t)>([](System::SharedPtr<Portion> portion, System::SharedPtr<Paragraph> paragraph, System::SharedPtr<BaseSlide> slide, int32_t index)
{
    System::Console::WriteLine(u"Portion {0}: {1}", index, portion->get_Text());
});
ForEach::Portion(presentation, portionCallback);
```

By default, presentation-wide shape and text traversal includes normal, master, and layout slides. Overloads with an `includeNotes` parameter can also process notes slides. Use direct collection loops when traversal order, early exit, filtering before callback invocation, or detailed parent-child control is important.

## **शेप्स एकत्र करें**

Use [Collect::Shapes](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/collect/shapes/) when you need a collection of all shapes in a presentation rather than a callback for each shape. This is useful when the same set will be filtered, counted, or processed more than once.

```cpp
#include <DOM/Presentation.h>
#include <DOM/Shape.h>
#include <LowCode/Collect.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");
auto shapes = Collect::Shapes(presentation);

for (const auto& shape : shapes)
{
    System::Console::WriteLine(shape->get_Name());
}
```

Use [ForEach::Shape](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/foreach/shape/) instead when each shape can be handled immediately and you do not need to retain the collected result.

## **प्रेजेंटेशन सामग्री को संपीडित करें**

The [Compress](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/) class can remove unused structural elements and reduce embedded font data:

- [Compress::RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) removes layout slides that no normal slide references.
- [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) removes master slides that are no longer used.
- [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) removes unused characters from embedded fonts.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"input.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);
Compress::RemoveUnusedMasterSlides(presentation);
Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed.pptx", SaveFormat::Pptx);
```

Remove unused layouts before unused masters so a master that becomes unreferenced after layout cleanup can also be removed. Save the optimized presentation to a new file if you may need the original masters, layouts, or complete embedded font data later. For more detail, see [Slide Master](/cpp/slide-master/) and [Embedded Font](/cpp/embedded-font/).

## **अक्सर पूछे जाने वाले प्रश्न**

**जब मुझे पूर्ण ऑब्जेक्ट मॉडल के बजाय लो‑कोड API का उपयोग करना चाहिए?**

Low‑code सहायक तब उपयोग करें जब मानक संचालन पूरी फ़ाइल या प्रस्तुति पर लागू होता है और विस्तृत नियंत्रण की आवश्यकता नहीं है। जब आपको विशिष्ट स्लाइड्स चुनने, मास्टर‑और‑लेआउट संबंधों को नियंत्रित करने, मध्यवर्ती स्थिति की जाँच करने, या ऐसे व्यवहार को कॉन्फ़िगर करने की जरूरत हो जो सहायक नहीं देता, तो पूर्ण ऑब्जेक्ट मॉडल का उपयोग करें।

**क्या Merger विभिन्न फ़ाइल फ़ॉर्मेट वाली प्रस्तुतियों को मिल सकता है?**

नहीं। [Merger::Process](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/merger/process/) को इनपुट प्रस्तुतियों का एक ही फ़ॉर्मेट होना आवश्यक है। पहले फ़ाइलों को समान फ़ॉर्मेट में बदलें, उदाहरण के लिए [Convert::AutoByExtension](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/convert/autobyextension/) से, फिर परिवर्तित फ़ाइलों को मिलाएँ।

**क्या ForEach master, layout और notes स्लाइड्स को प्रोसेस करता है?**

[ForEach::Slide](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/foreach/slide/) सामान्य प्रस्तुति स्लाइड्स को क्रमांकित करता है। प्रस्तुति‑व्यापी [ForEach::Shape](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/foreach/shape/), [ForEach::Paragraph](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/foreach/paragraph/), और [ForEach::Portion](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/foreach/portion/) डिफ़ॉल्ट रूप से सामान्य, master और layout स्लाइड्स को शामिल करते हैं। नोट्स स्लाइड्स को शामिल करने के लिए `includeNotes` को `true` सेट करके ओवरलोड का उपयोग करें।

**ForEach::Shape और Collect::Shapes में क्या अंतर है?**

यदि आप प्रत्येक शैप को तत्काल कॉलबैक में प्रोसेस करना चाहते हैं तो [ForEach::Shape](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/foreach/shape/) उपयोग करें। यदि आपको शैप्स का संग्रह बाद में प्राप्त करना, फ़िल्टर करना, गिनना या कई बार इटरेट करना है, तो [Collect::Shapes](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/collect/shapes/) उपयोग करें।

**क्या Compress हमेशा प्रस्तुति फ़ाइल को छोटा बनाता है?**

ज़रूरी नहीं। परिणाम इस पर निर्भर करता है कि प्रस्तुति में अप्रयुक्त लेआउट, अप्रयुक्त मास्टर, या अप्रयुक्त अक्षरों वाले एम्बेडेड फ़ॉन्ट हैं या नहीं। यदि इनमें से कुछ नहीं है, तो संबंधित [Compress](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/) ऑपरेशन फ़ाइल आकार को कम नहीं कर सकते।

**क्या ForEach या Compress द्वारा किए गये परिवर्तन स्वतः सहेजे जाते हैं?**

नहीं। ये सहायक लोड किए गए [Presentation](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/) ऑब्जेक्ट पर काम करते हैं। कॉलबैक में तत्व बदलने या [Compress](https://reference.aspose.com/slides/hi/cpp/aspose.slides.lowcode/compress/) चलाने के बाद, परिणाम लिखने के लिए [Presentation::Save](https://reference.aspose.com/slides/hi/cpp/aspose.slides/presentation/save/) को कॉल करें।

## **संबंधित लेख**

- [प्रेजेंटेशन रूपांतरित करें](/cpp/convert-presentation/)
- [प्रेजेंटेशन मिलाएँ](/cpp/merge-presentation/)
- [स्लाइड मास्टर](/cpp/slide-master/)
- [टेक्स्ट बॉक्स प्रबंधन](/cpp/manage-textbox/)
- [एंबेडेड फ़ॉन्ट](/cpp/embedded-font/)