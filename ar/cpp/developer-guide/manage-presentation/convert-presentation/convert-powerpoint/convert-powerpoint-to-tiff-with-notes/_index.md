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
description: "تحويل عروض PowerPoint إلى TIFF مع الملاحظات باستخدام Aspose.Slides لـ C++. تعرف على كيفية تصدير الشرائح مع ملاحظات المتحدث بكفاءة."
---

## **نظرة عامة**

توفر Aspose.Slides لـ C++ حلاً بسيطًا لتحويل عروض PowerPoint وOpenDocument (PPT، PPTX، وODP) مع الملاحظات إلى تنسيق TIFF. يُستخدم هذا التنسيق على نطاق واسع لتخزين الصور عالية الجودة والطباعة وأرشفة المستندات. باستخدام Aspose.Slides، يمكنك ليس فقط تصدير العروض الكاملة مع ملاحظات المتحدث ولكن أيضًا إنشاء صور مصغرة للشرائح في عرض ملاحظات الشريحة. عملية التحويل بسيطة وفعّالة، باستخدام طريقة `Save` في فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) لتحويل العرض بأكمله إلى سلسلة من صور TIFF مع الحفاظ على الملاحظات والتخطيط.

## **تحويل عرض تقديمي إلى TIFF مع الملاحظات**

يتضمن حفظ عرض PowerPoint أو OpenDocument إلى TIFF مع الملاحظات باستخدام Aspose.Slides لـ C++ الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/): تحميل ملف PowerPoint أو OpenDocument.
1. تكوين خيارات تخطيط الإخراج: استخدم فئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/notescommentslayoutingoptions/) لتحديد كيفية عرض الملاحظات والتعليقات.
1. حفظ العرض إلى TIFF: مرّر الخيارات المكوّنة إلى طريقة [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/).

لنفترض أن لدينا ملف "speaker_notes.pptx" بالشرائح التالية:

![شريحة العرض مع ملاحظات المتحدث](slide_with_notes.png)

يُظهر مقتطف الشيفرة التالي كيفية تحويل العرض إلى صورة TIFF في عرض ملاحظات الشريحة باستخدام طريقة [set_SlidesLayoutOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/).

```cpp
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
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
اطلع على Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يمكنني التحكم في موضع منطقة الملاحظات في ملف TIFF الناتج؟**

نعم. استخدم [notes layout settings](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_slideslayoutoptions/) للاختيار بين خيارات مثل `None`، `BottomTruncated`، أو `BottomFull`، التي تقوم على التوالي بإخفاء الملاحظات، أو ملاءمتها في صفحة واحدة، أو السماح لها بالانتشار إلى صفحات إضافية.

**كيف يمكنني تقليل حجم ملف TIFF مع الملاحظات دون فقدان ملحوظ في الجودة؟**

اختر [efficient compression](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_compressiontype/) (مثل `LZW` أو `RLE`)، واضبط DPI معقول، وإذا كان مقبولًا، استخدم [pixel format](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_pixelformat/) أقل (مثل 8 ببت أو 1 ببت للون أحادي). تقليل أبعاد الصورة قليلًا عبر [image dimensions](https://reference.aspose.com/slides/cpp/aspose.slides.export/tiffoptions/set_imagesize/) قد يساعد أيضًا دون التأثير الملحوظ على قابلية القراءة.

**هل تؤثر الخطوط في الملاحظات على النتيجة إذا كانت الخطوط الأصلية غير موجودة في النظام؟**

نعم. الخطوط المفقودة تُفعّل [substitution](/slides/ar/cpp/font-selection-sequence/)، مما قد يغيّر مقاييس النص ومظهره. لتجنّب ذلك، [supply the required fonts](/slides/ar/cpp/custom-font/) أو عيّن [fallback font](/slides/ar/cpp/fallback-font/) افتراضي بحيث تُستخدم الخطوط المقصودة.