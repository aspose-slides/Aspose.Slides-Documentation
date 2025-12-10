---
title: تحويل عروض PowerPoint إلى TIFF في C++
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

## **نظرة عامة**

TIFF (**Tagged Image File Format**) هو تنسيق صور نقطية غير مضغوطة يُستخدم على نطاق واسع، يُعرف بجودته الاستثنائية والحفاظ التفصيلي على الرسومات. غالبًا ما يختار المصممون والمصورون والناشرون المكتبيون TIFF للحفاظ على الطبقات ودقة الألوان والإعدادات الأصلية في صورهم.

باستخدام Aspose.Slides، يمكنك بسهولة تحويل شرائح PowerPoint (PPT، PPTX) وشرائح OpenDocument (ODP) مباشرة إلى صور TIFF عالية الجودة، مما يضمن احتفاظ عروضك التقديمية بأقصى قدر من الدقة البصرية.

## **تحويل عرض تقديمي إلى TIFF**

باستخدام طريقة [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) المقدمة من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/)، يمكنك بسرعة تحويل عرض تقديمي كامل إلى TIFF. تتطابق صور TIFF الناتجة مع حجم الشريحة الافتراضي.

يظهر هذا الكود C++ كيفية تحويل عرض تقديمي PowerPoint إلى TIFF:
```cpp
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

// حفظ العرض التقديمي كملف TIFF.
presentation->Save(u"Output.tiff", SaveFormat::Tiff);

presentation->Dispose();
```


## **تحويل عرض تقديمي إلى TIFF أبيض وأسود**

تتيح الطريقة [set_BwConversionMode](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/) في فئة [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/) تحديد الخوارزمية المستخدمة عند تحويل شريحة أو صورة ملونة إلى TIFF أبيض وأسود. لاحظ أن هذا الإعداد يُطبق فقط عندما تكون طريقة [set_CompressionType](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) مضبوطة على `CCITT4` أو `CCITT3`.

لنفترض أن لدينا ملف "sample.pptx" يحتوي على الشريحة التالية:

![A presentation slide](slide_black_and_white.png)

يوضح هذا الكود C++ كيفية تحويل الشريحة الملونة إلى TIFF أبيض وأسود:
```cpp
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


النتيجة:

![Black-and-White TIFF](TIFF_black_and_white.png)

## **تحويل عرض تقديمي إلى TIFF بحجم مخصص**

إذا كنت تحتاج إلى صورة TIFF بأبعاد محددة، يمكنك تعيين القيم المطلوبة باستخدام الطرق المتاحة في [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/). على سبيل المثال، تسمح طريقة [set_ImageSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) بتحديد حجم الصورة الناتجة.

يظهر هذا الكود C++ كيفية تحويل عرض تقديمي PowerPoint إلى صور TIFF بحجم مخصص:
```cpp
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

// تعيين نوع الضغط.
/*
أنواع الضغط:
    Default - يحدد مخطط الضغط الافتراضي (LZW).
    None - يعني عدم وجود ضغط.
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


## **تحويل عرض تقديمي إلى TIFF بصيغة بكسل مخصصة**

باستخدام طريقة [set_PixelFormat](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) من فئة [TiffOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/)، يمكنك تحديد صيغة البكسل المفضلة للصورة TIFF الناتجة.

يظهر هذا الكود C++ كيفية تحويل عرض تقديمي PowerPoint إلى صورة TIFF بصيغة بكسل مخصصة:
```cpp
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
auto presentation = MakeObject<Presentation>(u"Demo_File.pptx");

auto tiffOptions = MakeObject<TiffOptions>();

tiffOptions->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
ImagePixelFormat يحتوي على القيم التالية (كما هو موضح في الوثائق):
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


{{% alert title="Tip" color="primary" %}}
تحقق من أداة Aspose المجانية لتحويل PowerPoint إلى ملصق في المتصفح.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يمكنني تحويل شريحة واحدة بدلاً من العرض التقديمي الكامل إلى TIFF؟**

نعم. يتيح لك Aspose.Slides تحويل شرائح فردية من عروض PowerPoint وOpenDocument إلى صور TIFF بشكل منفصل.

**هل هناك أي حد لعدد الشرائح عند تحويل عرض تقديمي إلى TIFF؟**

لا، لا يفرض Aspose.Slides أي قيود على عدد الشرائح. يمكنك تحويل عروض بأي حجم إلى تنسيق TIFF.

**هل يتم الحفاظ على الرسوم المتحركة وتأثيرات الانتقال في PowerPoint عند تحويل الشرائح إلى TIFF؟**

لا، TIFF هو تنسيق صورة ثابت. لذا، لا يتم الحفاظ على الرسوم المتحركة أو تأثيرات الانتقال؛ يتم تصدير فقط لقطات ثابتة من الشرائح.