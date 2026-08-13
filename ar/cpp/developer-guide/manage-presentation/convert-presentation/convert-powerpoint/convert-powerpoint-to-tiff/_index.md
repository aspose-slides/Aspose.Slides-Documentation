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
description: "تعلم كيفية تحويل عروض PowerPoint (PPT، PPTX) بسهولة إلى صور TIFF عالية الجودة باستخدام Aspose.Slides لـ C++، مع أمثلة على الشيفرة."
---
## **مقدمة**

TIFF (**Tagged Image File Format**) هو تنسيق صورة نقطية غير مضغوطة يستخدم على نطاق واسع، ويعرف بجودته الاستثنائية والحفاظ التفصيلي على الرسومات. غالبًا ما يختار المصممون والمصورون وناشرو سطح المكتب TIFF للحفاظ على الطبقات ودقة الألوان والإعدادات الأصلية في صورهم.

باستخدام Aspose.Slides، يمكنك بسهولة تحويل شرائح PowerPoint (PPT، PPTX) وشرائح OpenDocument (ODP) مباشرةً إلى صور TIFF عالية الجودة، مما يضمن احتفاظ عروضك التقديمية بأقصى قدر من الدقة البصرية.

## **تحويل عرض تقديمي إلى TIFF**

باستخدام طريقة [Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/save/) المقدمة من فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/)، يمكنك بسرعة تحويل عرض PowerPoint الكامل إلى TIFF. صور TIFF الناتجة تتطابق مع حجم الشريحة الافتراضي.

الكود التالي بلغة C++ يوضح كيفية تحويل عرض PowerPoint إلى TIFF:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// Save the presentation as TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```

## **تحويل عرض تقديمي إلى TIFF بالأبيض والأسود**

تسمح لك الطريقة [set_BwConversionMode](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) في فئة [TiffOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/tiffoptions/) بتحديد الخوارزمية المستخدمة عند تحويل شريحة ملونة أو صورة إلى TIFF بالأبيض والأسود. لاحظ أن هذا الإعداد يُطبق فقط عندما تكون طريقة [set_CompressionType](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) مضبوطة على `CCITT4` أو `CCITT3`.

لنفترض أن لدينا ملف "sample.pptx" يحتوي على الشريحة التالية:

![شريحة عرض تقديمي](slide_black_and_white.png)

الكود التالي بلغة C++ يوضح كيفية تحويل الشريحة الملونة إلى TIFF بالأبيض والأسود:

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

إذا كنت بحاجة إلى صورة TIFF بأبعاد محددة، يمكنك تعيين القيم المطلوبة باستخدام الطرق المتاحة في [TiffOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/tiffoptions/). على سبيل المثال، تسمح لك طريقة [set_ImageSize](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/tiffoptions/set_imagesize/) بتحديد حجم الصورة الناتجة.

الكود التالي بلغة C++ يوضح كيفية تحويل عرض PowerPoint إلى صور TIFF بحجم مخصص:

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

// تحديد نوع الضغط.
tiffOptions->set_CompressionType(TiffCompressionTypes::Default);
/*
أنواع الضغط:
    Default - يُحدد مخطط الضغط الافتراضي (LZW).
    None - يُحدد عدم وجود ضغط.
    CCITT3
    CCITT4
    LZW
    RLE
*/

// يعتمد العمق على نوع الضغط ولا يمكن تعيينه يدويًا.

// تحديد DPI للصورة.
tiffOptions->set_DpiX(200);
tiffOptions->set_DpiY(200);

// تحديد حجم الصورة.
tiffOptions->set_ImageSize(System::Drawing::Size(1728, 1078));

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// حفظ العرض التقديمي كملف TIFF بالحجم المحدد.
presentation->Save(u"custom_size.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

## **تحويل عرض تقديمي إلى TIFF بتنسيق بكسل صورة مخصص**

باستخدام طريقة [set_PixelFormat](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) من فئة [TiffOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/tiffoptions/)، يمكنك تحديد تنسيق البكسل المفضل للصورة TIFF الناتجة.

الكود التالي بلغة C++ يوضح كيفية تحويل عرض PowerPoint إلى صورة TIFF بتنسيق بكسل مخصص:

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

// حفظ العرض التقديمي كملف TIFF مع حجم الصورة المحدد.
presentation->Save(u"Custom_Image_Pixel_Format.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

{{% alert title="نصيحة" color="info" %}}
اطلع على [محول PowerPoint إلى ملصق مجاني](https://products.aspose.app/slides/ar/conversion/convert-ppt-to-poster-online) من Aspose.
{{% /alert %}}

## **الأسئلة الشائعة**

### هل يمكنني تحويل شريحة واحدة بدلاً من عرض PowerPoint الكامل إلى TIFF؟

نعم. يتيح لك Aspose.Slides تحويل الشرائح الفردية من عروض PowerPoint وعروض OpenDocument إلى صور TIFF بشكل منفصل.

### هل هناك أي حد لعدد الشرائح عند تحويل عرض تقديمي إلى TIFF؟

لا، لا تفرض Aspose.Slides أي قيود على عدد الشرائح. يمكنك تحويل العروض التقديمية من أي حجم إلى تنسيق TIFF.

### هل يتم الحفاظ على الرسوم المتحركة وتأثيرات الانتقال في PowerPoint عند تحويل الشرائح إلى TIFF؟

لا، فإن TIFF هو تنسيق صورة ثابت. وبالتالي، لا يتم الحفاظ على الرسوم المتحركة وتأثيرات الانتقال؛ يتم تصدير لقطات ثابتة فقط من الشرائح.