---
title: تحويل عروض PowerPoint إلى TIFF مع الملاحظات في C++
linktitle: PowerPoint إلى TIFF مع الملاحظات
type: docs
weight: 100
url: /ar/cpp/convert-powerpoint-to-tiff-with-notes/
keywords:
- تحويل PowerPoint
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
- PowerPoint مع الملاحظات
- العرض التقديمي مع الملاحظات
- الشريحة مع الملاحظات
- PPT مع الملاحظات
- PPTX مع الملاحظات
- TIFF مع الملاحظات
- C++
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى TIFF مع الملاحظات باستخدام Aspose.Slides للغة C++. تعلّم كيفية تصدير الشرائح مع ملاحظات المتحدث بكفاءة."
---

## **نظرة عامة**

توفر Aspose.Slides for C++ حلاً بسيطًا لتحويل عروض PowerPoint وOpenDocument (PPT وPPTX وODP) مع الملاحظات إلى تنسيق TIFF. يُستخدم هذا التنسيق على نطاق واسع لتخزين الصور عالية الجودة والطباعة وأرشفة المستندات. باستخدام Aspose.Slides، يمكنك ليس فقط تصدير العروض الكاملة مع ملاحظات المتحدث، بل أيضًا إنشاء صور مصغرة للشرائح في عرض Notes Slide. عملية التحويل بسيطة وفعّالة، حيث تستخدم طريقة `Save` في فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) لتحويل العرض بالكامل إلى سلسلة من صور TIFF مع الحفاظ على الملاحظات والتخطيط.

## **تحويل عرض تقديمي إلى TIFF مع الملاحظات**

يتضمن حفظ عرض PowerPoint أو OpenDocument إلى TIFF مع الملاحظات باستخدام Aspose.Slides for C++ الخطوات التالية:

1. إنشاء مثال من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/): تحميل ملف PowerPoint أو OpenDocument.
1. تكوين خيارات تخطيط الإخراج: استخدم فئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) لتحديد كيفية عرض الملاحظات والتعليقات.
1. حفظ العرض إلى TIFF: تمرير الخيارات المكوَّنة إلى طريقة [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

لنفرض أن لدينا ملف "speaker_notes.pptx" يحتوي على الشريحة التالية:

![شريحة العرض مع ملاحظات المتحدث](slide_with_notes.png)

يوضح مقطع الشيفرة أدناه كيفية تحويل العرض إلى صورة TIFF في عرض Notes Slide باستخدام طريقة [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) .
```cpp
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // عرض الملاحظات أسفل الشريحة.

// Configure the TIFF options with Notes layouting.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// Save the presentation to TIFF with the speaker notes.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


النتيجة:

![صورة TIFF مع ملاحظات المتحدث](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
تحقق من Aspose [محول PowerPoint إلى ملصق مجاني](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يمكنني التحكم في موضع منطقة الملاحظات في ملف TIFF الناتج؟**

نعم. استخدم [إعدادات تخطيط الملاحظات](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) لاختيار أحد الخيارات مثل `None` أو `BottomTruncated` أو `BottomFull`، التي تقوم على التوالي بإخفاء الملاحظات أو دمجها في صفحة واحدة أو السماح لها بالانتشار إلى صفحات إضافية.

**كيف يمكنني تقليل حجم ملف TIFF مع الملاحظات دون فقدان ملحوظ في الجودة؟**

اختر [ضغطًا فعالًا](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (مثل `LZW` أو `RLE`)، وضع DPI مناسب، وإذا كان مقبولًا، استخدم [تنسيق بكسل](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) أقل (مثل 8 bpp أو 1 bpp للون أحادي). يمكن أن يساعد تقليل أبعاد الصورة قليلاً أيضًا دون الإضرار بشكل ملحوظ بقراءة المحتوى.

**هل يؤثر الخط في الملاحظات على النتيجة إذا كانت الخطوط الأصلية غير موجودة على النظام؟**

نعم. الخطوط المفقودة تُؤدي إلى [استبدال](/slides/ar/cpp/font-selection-sequence/)، مما قد يغيّر مقاييس النص ومظهره. لتجنّب ذلك، [قم بتوفير الخطوط المطلوبة](/slides/ar/cpp/custom-font/) أو عيّن [خطًا احتياطيًا](/slides/ar/cpp/fallback-font/) افتراضيًا حتى تُستخدم الأنواع المرجوة من الخطوط.