---
title: تحويل عروض PowerPoint إلى TIFF باستخدام C++
titlelink: PowerPoint إلى TIFF
type: docs
weight: 90
url: /ar/cpp/convert-powerpoint-to-tiff/
keywords:
- تحويل PowerPoint
- تحويل OpenDocument
- تحويل العرض التقديمي
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى TIFF
- العرض التقديمي إلى TIFF
- الشريحة إلى TIFF
- PPT إلى TIFF
- PPTX إلى TIFF
- حفظ PPT كـ TIFF
- حفظ PPTX كـ TIFF
- تصدير PPT إلى TIFF
- تصدير PPTX إلى TIFF
- C++
- Aspose.Slides
description: "تعلم كيف تقوم بسهولة بتحويل عروض PowerPoint (PPT، PPTX) إلى صور TIFF عالية الجودة باستخدام Aspose.Slides للغة C++، مع أمثلة على الشيفرة."
---
## **المقدمة**

TIFF (**Tagged Image File Format**) هو تنسيق صورة نقطية غير مضغوطة واسع الاستخدام معروف بجودته الاستثنائية وحفظه المفصل للرسومات. غالبًا ما يختار المصممون والمصورون وناشرو المكتبة المكتبية TIFF للحفاظ على الطبقات ودقة الألوان والإعدادات الأصلية في صورهم.

باستخدام Aspose.Slides، يمكنك بسهولة تحويل شرائح PowerPoint (PPT، PPTX) وشرائح OpenDocument (ODP) مباشرةً إلى صور TIFF عالية الجودة، مما يضمن احتفاظ عروضك التقديمية بأقصى قدر من الوضوح البصري.

## **تحويل عرض تقديمي إلى TIFF**

باستخدام طريقة [Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/save/) المقدَّمة من فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/)، يمكنك بسرعة تحويل عرض PowerPoint كامل إلى TIFF. تتطابق صور TIFF الناتجة مع حجم الشريحة الافتراضي.

يُظهر هذا الكود C++ كيفية تحويل عرض PowerPoint إلى TIFF:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// حفظ العرض التقديمي كملف TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **تحويل عرض تقديمي إلى TIFF بالأبيض والأسود**

تتيح الطريقة [set_BwConversionMode](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) في فئة [TiffOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/tiffoptions/) لك تحديد الخوارزمية المستخدمة عند تحويل شريحة أو صورة ملونة إلى TIFF بالأبيض والأسود. لاحظ أن هذا الإعداد يُطبق فقط عندما تكون طريقة [set_CompressionType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) مضبوطة على `CCITT4` أو `CCITT3`.

{{% alert color="info" title="Note" %}}
[TiffOptions::set_BwConversionMode](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) هو إعداد على مستوى التصدير يختار خوارزمية تحويل البكسل للصورة TIFF كاملة. لتحديد كيفية ظهور شكل فردي عندما يكون وضع العرض بالأبيض والأسود نشطًا، استخدم [IShape::set_BlackWhiteMode](https://reference.aspose.com/slides/ar/cpp/aspose.slides/ishape/set_blackwhitemode/). راجع [Control Black-and-White Rendering for Shapes](/slides/ar/cpp/shape-formatting/#control-black-and-white-rendering-for-shapes) للحصول على أمثلة.
{{% /alert %}}

لنفترض أن لدينا ملف "sample.pptx" يحتوي على الشريحة التالية:

![شريحة عرض تقديمي](slide_black_and_white.png)

يُظهر هذا الكود C++ كيفية تحويل الشريحة الملونة إلى TIFF بالأبيض والأسود:

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

النتيجة:

![TIFF بالأبيض والأسود](TIFF_black_and_white.png)

## **تحويل عرض تقديمي إلى TIFF بحجم مخصص**

إذا كنت بحاجة إلى صورة TIFF بأبعاد محددة، يمكنك تعيين القيم المطلوبة باستخدام الطرق المتاحة في فئة [TiffOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/tiffoptions/). على سبيل المثال، تتيح طريقة [set_ImageSize](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/tiffoptions/set_imagesize/) لك تحديد حجم الصورة الناتجة.

يُظهر هذا الكود C++ كيفية تحويل عرض PowerPoint إلى صور TIFF بحجم مخصص:

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

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// تعيين نوع الضغط.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
أنواع الضغط:
    Default - يحدد مخطط الضغط الافتراضي (LZW).
    None - يحدد عدم وجود ضغط.
    CCITT3
    CCITT4
    LZW
    RLE
*/

// يعتمد العمق على نوع الضغط ولا يمكن تعيينه يدويًا.

// تعيين DPI للصورة.
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// تعيين حجم الصورة.
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// حفظ العرض التقديمي كملف TIFF بالحجم المحدد.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **تحويل عرض تقديمي إلى TIFF بتنسيق بكسل مخصص للصورة**

باستخدام طريقة [set_PixelFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) من فئة [TiffOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/tiffoptions/)، يمكنك تحديد تنسيق البكسل المفضل للصورة TIFF الناتجة.

يُظهر هذا الكود C++ كيفية تحويل عرض PowerPoint إلى صورة TIFF بتنسيق بكسل مخصص:

```cpp
#include <DOM/Presentation.h>
#include <Export/ImagePixelFormat.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat يحتوي على القيم التالية (كما هو مذكور في الوثائق):
    Format1bppIndexed - 1 بت لكل بكسل، مفهرس.
    Format4bppIndexed - 4 بت لكل بكسل، مفهرس.
    Format8bppIndexed - 8 بت لكل بكسل، مفهرس.
    Format24bppRgb    - 24 بت لكل بكسل، RGB.
    Format32bppArgb   - 32 بت لكل بكسل، ARGB.
*/

// حفظ العرض التقديمي كملف TIFF بالحجم المحدد للصورة.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="Tip" color="info" %}}
تحقق من [محول PowerPoint إلى ملصق مجاني](https://products.aspose.app/slides/ar/conversion/convert-ppt-to-poster-online) من Aspose.
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يمكنني تحويل شريحة واحدة بدلاً من عرض PowerPoint كامل إلى TIFF؟**

نعم. يتيح لك Aspose.Slides تحويل الشرائح الفردية من عروض PowerPoint وOpenDocument إلى صور TIFF بشكل منفصل.

**هل هناك أي حد لعدد الشرائح عند تحويل عرض تقديمي إلى TIFF؟**

لا، لا يفرض Aspose.Slides أي قيود على عدد الشرائح. يمكنك تحويل عروض تقديمية بأي حجم إلى تنسيق TIFF.

**هل يتم حفظ الرسوم المتحركة وتأثيرات الانتقال في PowerPoint عند تحويل الشرائح إلى TIFF؟**

لا، TIFF هو تنسيق صورة ثابت. لذلك لا يتم حفظ الرسوم المتحركة وتأثيرات الانتقال؛ يتم تصدير لقطات ثابتة فقط من الشرائح.