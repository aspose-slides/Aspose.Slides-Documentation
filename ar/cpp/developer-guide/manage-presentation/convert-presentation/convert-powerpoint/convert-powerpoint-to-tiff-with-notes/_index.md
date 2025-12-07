---
title: تحويل عروض PowerPoint إلى TIFF مع ملاحظات في C++
linktitle: PowerPoint إلى TIFF مع ملاحظات
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
- PowerPoint مع ملاحظات
- العرض التقديمي مع ملاحظات
- الشريحة مع ملاحظات
- PPT مع ملاحظات
- PPTX مع ملاحظات
- TIFF مع ملاحظات
- C++
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى TIFF مع ملاحظات باستخدام Aspose.Slides for C++. تعلم كيفية تصدير الشرائح مع ملاحظات المتحدث بكفاءة."
---

## **نظرة عامة**

Aspose.Slides for C++ يوفر حلاً بسيطًا لتحويل عروض PowerPoint وOpenDocument (PPT، PPTX، وODP) مع الملاحظات إلى تنسيق TIFF. يُستخدم هذا التنسيق على نطاق واسع لتخزين الصور عالية الجودة والطباعة وأرشفة المستندات. مع Aspose.Slides، يمكنك ليس فقط تصدير العروض بالكامل مع ملاحظات المتحدث بل أيضًا إنشاء صور مصغرة للشرائح في وضع ملاحظات الشريحة. عملية التحويل بسيطة وفعّالة، وتستفيد من طريقة `Save` في فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) لتحويل العرض بالكامل إلى سلسلة من صور TIFF مع الحفاظ على الملاحظات والتخطيط.

## **تحويل عرض تقديمي إلى TIFF مع الملاحظات**

حفظ عرض PowerPoint أو OpenDocument إلى TIFF مع الملاحظات باستخدام Aspose.Slides for C++ يتضمن الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/): تحميل ملف PowerPoint أو OpenDocument.  
2. تهيئة خيارات تخطيط الإخراج: استخدم فئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) لتحديد كيفية عرض الملاحظات والتعليقات.  
3. حفظ العرض إلى TIFF: مرّر الخيارات المهيأة إلى طريقة [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

لنفترض أن لدينا ملف "speaker_notes.pptx" يحتوي على الشريحة التالية:

![شريحة العرض مع ملاحظات المتحدث](slide_with_notes.png)

المقتطف البرمجي أدناه يوضح كيفية تحويل العرض إلى صورة TIFF في وضع ملاحظات الشريحة باستخدام طريقة [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/).
```cpp
// إنشاء كائن فئة Presentation التي تمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // عرض الملاحظات أسفل الشريحة.

// تهيئة خيارات TIFF مع تنسيق الملاحظات.
auto tiffOptions = MakeObject<TiffOptions>();
tiffOptions->set_DpiX(300);
tiffOptions->set_DpiY(300);
tiffOptions->set_SlidesLayoutOptions(notesOptions);

// حفظ العرض التقديمي إلى TIFF مع ملاحظات المتحدث.
presentation->Save(u"TIFF_with_notes.tiff", SaveFormat::Tiff, tiffOptions);

presentation->Dispose();
```


النتيجة:

![صورة TIFF مع ملاحظات المتحدث](TIFF_with_notes.png)

{{% alert title="نصيحة" color="primary" %}}
تحقق من أداة Aspose المجانية لتحويل PowerPoint إلى ملصق.
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يمكنني التحكم في موضع منطقة الملاحظات في ملف TIFF الناتج؟**

نعم. استخدم إعدادات تخطيط الملاحظات لاختيار أحد الخيارات مثل `None` أو `BottomTruncated` أو `BottomFull`، والتي على التوالي تخفي الملاحظات، أو تناسبها في صفحة واحدة، أو تسمح بتدفقها إلى صفحات إضافية.

**كيف يمكنني تقليل حجم ملف TIFF مع الملاحظات دون فقدان ملحوظ في الجودة؟**

اختر ضغطًا فعّالًا مثل `LZW` أو `RLE` عبر [efficient compression](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/)، اضبط DPI معقول، وإذا كان مقبولًا استخدم تنسيق بكسل أقل مثل 8 ببت أو 1 ببت للصور أحادية اللون. يمكن أيضًا تقليل أبعاد الصورة قليلاً عبر [image dimensions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) دون الإضرار بوضوح المحتوى بشكل ملحوظ.

**هل يؤثر الخط في الملاحظات على النتيجة إذا كانت الخطوط الأصلية غير موجودة على النظام؟**

نعم. الخطوط المفقودة تُؤدي إلى استبدال ([substitution](/slides/ar/cpp/font-selection-sequence/)) قد يغيّر مقاييس النص ومظهره. لتجنب ذلك، وفر الخطوط المطلوبة عبر [supply the required fonts](/slides/ar/cpp/custom-font/) أو اضبط خطًا افتراضيًا احتياطيًا عبر [fallback font](/slides/ar/cpp/fallback-font/) لضمان استخدام الخطوط المقصودة.