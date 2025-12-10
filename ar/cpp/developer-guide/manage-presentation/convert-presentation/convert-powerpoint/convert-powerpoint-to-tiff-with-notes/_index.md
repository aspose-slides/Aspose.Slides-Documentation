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
- PowerPoint مع الملاحظات
- العرض مع الملاحظات
- الشريحة مع الملاحظات
- PPT مع الملاحظات
- PPTX مع الملاحظات
- TIFF مع الملاحظات
- C++
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى TIFF مع الملاحظات باستخدام Aspose.Slides for C++. تعلم كيفية تصدير الشرائح مع ملاحظات المتحدث بكفاءة."
---

## **نظرة عامة**

يوفر Aspose.Slides for C++ حلاً بسيطًا لتحويل عروض PowerPoint و OpenDocument (PPT، PPTX، و ODP) مع الملاحظات إلى تنسيق TIFF. يُستخدم هذا التنسيق على نطاق واسع لتخزين الصور عالية الجودة والطباعة وأرشفة المستندات. باستخدام Aspose.Slides، يمكنك ليس فقط تصدير العروض الكاملة مع ملاحظات المتحدث ولكن أيضًا إنشاء صور مصغرة للشرائح في عرض ملاحظات الشريحة. عملية التحويل بسيطة وفعّالة، حيث تُستخدم طريقة `Save` من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) لتحويل العرض الكامل إلى سلسلة من صور TIFF مع الحفاظ على الملاحظات والتخطيط.

## **تحويل عرض تقديمي إلى TIFF مع الملاحظات**

يتضمن حفظ عرض PowerPoint أو OpenDocument إلى TIFF مع الملاحظات باستخدام Aspose.Slides for C++ الخطوات التالية:

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/): تحميل ملف PowerPoint أو OpenDocument.  
2. تكوين خيارات تخطيط المخرجات: استخدم فئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) لتحديد كيفية عرض الملاحظات والتعليقات.  
3. حفظ العرض إلى TIFF: تمرير الخيارات المُكوَّنة إلى طريقة [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

لنفترض أن لدينا ملف "speaker_notes.pptx" مع الشريحة التالية:

![شريحة العرض مع ملاحظات المتحدث](slide_with_notes.png)

توضح القطعة البرمجية أدناه كيفية تحويل العرض إلى صورة TIFF في عرض ملاحظات الشريحة باستخدام طريقة [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/).

```cpp
// إنشاء كائن الفئة Presentation الذي يمثل ملف عرض تقديمي.
auto presentation = MakeObject<Presentation>(u"speaker_notes.pptx");

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull); // عرض الملاحظات أسفل الشريحة.

// ضبط خيارات TIFF مع تخطيط الملاحظات.
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

{{% alert title="Tip" color="primary" %}}
تحقق من Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يمكنني التحكم في موضع منطقة الملاحظات في ملف TIFF الناتج؟**

نعم. استخدم [notes layout settings](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) لاختيار أحد الخيارات مثل `None` أو `BottomTruncated` أو `BottomFull`، والتي تقوم على التوالي بإخفاء الملاحظات أو ملئها في صفحة واحدة أو السماح لها بالانتقال إلى صفحات إضافية.

**كيف يمكنني تقليل حجم ملف TIFF مع الملاحظات دون فقدان ملحوظ في الجودة؟**

اختر [efficient compression](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (مثل `LZW` أو `RLE`)، وحدد قيم DPI معقولة، وإذا كان مقبولًا، استخدم [pixel format](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) أقل (مثل 8 ببت أو 1 ببت للون أحادي). يمكن أيضًا تقليل أبعاد الصورة قليلاً عبر [image dimensions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) دون الإضرار بشكل ملحوظ بقابلية القراءة.

**هل يؤثر الخط في الملاحظات على النتيجة إذا كانت الخطوط الأصلية غير موجودة على النظام؟**

نعم. الخطوط المفقودة تُؤدي إلى [substitution](/slides/ar/cpp/font-selection-sequence/)، مما قد يغيّر مقاييس النص ومظهره. لتجنب ذلك، [supply the required fonts](/slides/ar/cpp/custom-font/) أو اضبط [fallback font](/slides/ar/cpp/fallback-font/) افتراضيًّا بحيث تُستَخدم الخطوط المقصودة.