---
title: تحويل PowerPoint إلى TIFF
type: docs
weight: 90
url: /cpp/convert-powerpoint-to-tiff/
keywords: "تحويل عرض PowerPoint, PowerPoint إلى TIFF, PPT إلى TIFF, PPTX إلى TIFF, C++, CPP, Aspose.Slides"
description: "تحويل عرض PowerPoint إلى TIFF في C++"
---

**TIFF** (تنسيق ملف الصورة المج Tagged) هو تنسيق صورة نقطية خالية من الفاقد وعالية الجودة. يستخدم المحترفون TIFF لأغراض التصميم والتصوير والطباعة المكتبية. على سبيل المثال، إذا كنت ترغب في الحفاظ على الطبقات والإعدادات في تصميمك أو صورتك، فقد ترغب في حفظ عملك كملف صورة TIFF.

يتيح لك Aspose.Slides تحويل الشرائح في PowerPoint مباشرة إلى TIFF.

{{% alert title="نصيحة" color="primary" %}}

قد ترغب في الاطلاع على محول [PowerPoint إلى ملصق المجاني](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online) من Aspose.

{{% /alert %}}

## **تحويل PowerPoint إلى TIFF**

باستخدام طريقة [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) التي تعرضها فئة [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation)، يمكنك بسرعة تحويل عرض PowerPoint كامل إلى TIFF. الصور الناتجة بتنسيق TIFF تتوافق مع الحجم الافتراضي للشرائح.

يوضح لك هذا الكود C++ كيفية تحويل PowerPoint إلى TIFF:

```c++
// المسار إلى دليل المستندات.
String dataDir = GetDataPath();

// إنشاء كائن تقديم يمثل ملف عرض تقديمي
auto presentation = System::MakeObject<Presentation>(dataDir + u"DemoFile.pptx");

// يحفظ العرض التقديمي كـ TIFF
presentation->Save(dataDir + u"Tiffoutput_out.tiff", SaveFormat::Tiff);
```

## **تحويل PowerPoint إلى TIFF بالأبيض والأسود**

في Aspose.Slides 23.10، أضاف Aspose.Slides خاصية جديدة ([BwConversionMode](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_bwconversionmode/)) إلى فئة [TiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.tiff_options) لتسمح لك بتحديد الخوارزمية التي تتبع عند تحويل شريحة ملونة أو صورة إلى TIFF بالأبيض والأسود. لاحظ أن هذا الإعداد يتم تطبيقه فقط عندما يتم تعيين خاصية [CompressionType](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) إلى `CCITT4` أو `CCITT3`.

يوضح لك هذا الكود C++ كيفية تحويل شريحة ملونة أو صورة إلى TIFF بالأبيض والأسود:

```c++
System::SharedPtr<TiffOptions> tiffOptions = System::MakeObject<TiffOptions>();
tiffOptions->set_CompressionType(TiffCompressionTypes::CCITT4);
tiffOptions->set_BwConversionMode(BlackWhiteConversionMode::Dithering);

System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.tiff", SaveFormat::Tiff, tiffOptions);
```

## **تحويل PowerPoint إلى TIFF بحجم مخصص**

إذا كنت بحاجة إلى صورة TIFF بأبعاد محددة، يمكنك تحديد الأبعاد المفضلة لديك من خلال الخصائص المتاحة في [TiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.tiff_options). باستخدام خاصية [ImageSize](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/)، على سبيل المثال، يمكنك تحديد حجم الصورة الناتجة.

يوضح لك هذا الكود C++ كيفية تحويل PowerPoint إلى صور TIFF بحجم مخصص:

```c++
// المسار إلى دليل المستندات.
System::String dataDir = GetDataPath();

// إنشاء كائن تقديم يمثل ملف عرض تقديمي
auto pres = System::MakeObject<Presentation>(dataDir + u"Convert_Tiff_Custom.pptx");
    
// إنشاء كائن TiffOptions
auto opts = System::MakeObject<TiffOptions>();

// تعيين نوع الضغط
opts->set_CompressionType(TiffCompressionTypes::Default);

auto notesOptions = opts->get_NotesCommentsLayouting();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
// أنواع الضغط

// Default - يحدد نوع الضغط الافتراضي (LZW).
// None - يشير إلى عدم الضغط.
// CCITT3
// CCITT4
// LZW
// RLE

// العمق يعتمد على نوع الضغط ولا يمكن تعيينه يدويًا.
// وحدة الدقة دائمًا تساوي "2" (نقاط في البوصة)

// تعيين DPI للصورة
opts->set_DpiX(200);
opts->set_DpiY(100);

// تعيين حجم الصورة
opts->set_ImageSize(System::Drawing::Size(1728, 1078));

// يحفظ العرض التقديمي كـ TIFF بالحجم المحدد
pres->Save(dataDir + u"TiffWithCustomSize_out.tiff", SaveFormat::Tiff, opts);
```


## **تحويل PowerPoint إلى TIFF بتنسيق بكسل صورة مخصص**

باستخدام خاصية [PixelFormat](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) تحت فئة [TiffOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.tiff_options)، يمكنك تحديد تنسيق البكسل المفضل لديك للصورة الناتجة بتنسيق TIFF.

يوضح لك هذا الكود C++ كيفية تحويل PowerPoint إلى صورة TIFF بتنسيق بكسل مخصص:

```c++
// المسار إلى دليل المستندات.
System::String dataDir = GetDataPath();

// إنشاء كائن تقديم يمثل ملف عرض تقديمي
auto presentation = System::MakeObject<Presentation>(dataDir + u"DemoFile.pptx");

auto options = System::MakeObject<TiffOptions>();
options->set_PixelFormat(ImagePixelFormat::Format8bppIndexed);
/*
تحتوي ImagePixelFormat على القيم التالية (كما هو موضح في الوثائق):
Format1bppIndexed؛ // 1 بت لكل بكسل، مفهرس.
Format4bppIndexed؛ // 4 بت لكل بكسل، مفهرس.
Format8bppIndexed؛ // 8 بت لكل بكسل، مفهرس.
Format24bppRgb؛ // 24 بت لكل بكسل، RGB.
Format32bppArgb؛ // 32 بت لكل بكسل، ARGB.
*/

// يحفظ العرض التقديمي كـ TIFF بالحجم المحدد
presentation->Save(dataDir + u"Tiff_With_Custom_Image_Pixel_Format_out.tiff", SaveFormat::Tiff, options);
```