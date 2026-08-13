---
title: تحويل عروض PowerPoint إلى TIFF مع الملاحظات في C++
linktitle: PowerPoint إلى TIFF مع الملاحظات
type: docs
weight: 100
url: /ar/cpp/convert-powerpoint-to-tiff-with-notes/
keywords:
- تحويل PowerPoint
- تحويل العرض
- تحويل الشريحة
- تحويل PPT
- تحويل PPTX
- PowerPoint إلى TIFF
- العرض إلى TIFF
- الشريحة إلى TIFF
- PPT إلى TIFF
- PPTX إلى TIFF
- حفظ PPT كـ TIFF
- حفظ PPTX كـ TIFF
- تصدير PPT إلى TIFF
- تصدير PPTX إلى TIFF
- PowerPoint مع ملاحظات
- العرض مع ملاحظات
- الشريحة مع ملاحظات
- PPT مع ملاحظات
- PPTX مع ملاحظات
- TIFF مع ملاحظات
- C++
- Aspose.Slides
description: "قم بتحويل عروض PowerPoint إلى TIFF مع الملاحظات باستخدام Aspose.Slides للغة C++. تعلم كيفية تصدير الشرائح مع ملاحظات المتحدث بفعالية."
---
## **المقدمة**

توفر Aspose.Slides for C++ حلاً بسيطًا لتحويل عروض PowerPoint وOpenDocument (PPT وPPTX وODP) مع الملاحظات إلى تنسيق TIFF. يُستخدم هذا التنسيق على نطاق واسع لتخزين الصور بجودة عالية، والطباعة، وأرشفة المستندات. مع Aspose.Slides، يمكنك ليس فقط تصدير العروض الكاملة مع ملاحظات المتحدث ولكن أيضًا إنشاء صور مصغرة للشرائح في عرض ملاحظات الشريحة. عملية التحويل بسيطة وفعّالة، حيث يتم الاستفادة من طريقة `Save` في فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) لتحويل العرض بالكامل إلى سلسلة من صور TIFF مع الحفاظ على الملاحظات والتخطيط.

## **تحويل عرض تقديمي إلى TIFF مع الملاحظات**

يتضمن حفظ عرض PowerPoint أو OpenDocument إلى TIFF مع الملاحظات باستخدام Aspose.Slides for C++ الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/) : تحميل ملف PowerPoint أو OpenDocument.
1. تكوين خيارات تخطيط المخرجات: استخدم فئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/notescommentslayoutingoptions/) لتحديد كيفية عرض الملاحظات والتعليقات.
1. حفظ العرض إلى TIFF: مرّر الخيارات المكوّنة إلى طريقة [Save](https://reference.aspose.com/slides/ar/cpp/aspose.slides/presentation/save/) .

لنفترض أنه لدينا ملف "speaker_notes.pptx" يحتوي على الشريحة التالية:

![شريحة العرض مع ملاحظات المتحدث](slide_with_notes.png)

The code snippet below demonstrates how to convert the presentation to a TIFF image in Notes Slide view using the [set_SlidesLayoutOptions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) method.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/SaveFormat.h>
#include <Export/TiffOptions.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// إنشاء كائن من فئة Presentation التي تمثّل ملف العرض.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // عرض الملاحظات أسفل الشريحة.

// تكوين خيارات TIFF مع تخطيط الملاحظات.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// حفظ العرض إلى TIFF مع ملاحظات المتحدث.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```

النتيجة:

![صورة TIFF مع ملاحظات المتحدث](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
تحقق من Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/ar/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **الأسئلة الشائعة**

### هل يمكنني التحكم في موضع منطقة الملاحظات في ملف TIFF الناتج؟

نعم. استخدم [notes layout settings](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) لتحديد أحد الخيارات مثل `None` أو `BottomTruncated` أو `BottomFull`، حيث يقوم الأول بإخفاء الملاحظات، والثاني بملاءمتها في صفحة واحدة، والثالث بالسماح لها بالانتشار إلى صفحات إضافية.

### كيف يمكنني تقليل حجم ملف TIFF مع الملاحظات دون فقدان واضح في الجودة؟

اختر [efficient compression](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (مثلاً `LZW` أو `RLE`)، عيّن DPI معقول، وإذا كان مقبولاً، استخدم [pixel format](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) أقل (مثل 8 bpp أو 1 bpp للون أحادي). يمكن أن يساعد تقليل أبعاد الصورة قليلاً ([image dimensions](https://reference.aspose.com/slides/ar/cpp/aspose.slides.export/tiffoptions/set_imagesize/)) دون الإضرار الملحوظ بقراءة المحتوى.

### هل يؤثر خط الملاحظات على النتيجة إذا كانت الخطوط الأصلية مفقودة من النظام؟

نعم. نقص الخطوط يؤدي إلى تشغيل [substitution](/slides/ar/cpp/font-selection-sequence/)، مما قد يغيّر مقاييس النص ومظهره. لتجنّب ذلك، [supply the required fonts](/slides/ar/cpp/custom-font/) أو عيّن [fallback font](/slides/ar/cpp/fallback-font/) افتراضي لضمان استخدام الخطوط المطلوبة.