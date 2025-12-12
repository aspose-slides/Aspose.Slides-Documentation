---
title: تحويل عروض PowerPoint إلى TIFF مع الملاحظات على Android
linktitle: PowerPoint إلى TIFF مع الملاحظات
type: docs
weight: 100
url: /ar/androidjava/convert-powerpoint-to-tiff-with-notes/
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
- Android
- Java
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى TIFF مع الملاحظات باستخدام Aspose.Slides لأندرويد عبر جافا. تعلّم كيفية تصدير الشرائح مع ملاحظات المتحدث بفعالية."
---

## **نظرة عامة**

توفر Aspose.Slides لأندرويد عبر جافا حلاً بسيطًا لتحويل عروض PowerPoint وOpenDocument (PPT وPPTX وODP) مع الملاحظات إلى تنسيق TIFF. يُستخدم هذا التنسيق على نطاق واسع لتخزين الصور عالية الجودة والطباعة وأرشفة المستندات. باستخدام Aspose.Slides، يمكنك ليس فقط تصدير العروض الكاملة مع ملاحظات المتحدث بل أيضًا إنشاء صور مصغرة للشرائح في وضع ملاحظات الشريحة. عملية التحويل بسيطة وفعّالة، وتستفيد من طريقة `save` الخاصة بفئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) لتحويل العرض بالكامل إلى سلسلة من صور TIFF مع الحفاظ على الملاحظات والتخطيط.

## **تحويل عرض تقديمي إلى TIFF مع الملاحظات**

يتضمن حفظ عرض PowerPoint أو OpenDocument إلى TIFF مع الملاحظات باستخدام Aspose.Slides لأندرويد عبر جافا الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) : تحميل ملف PowerPoint أو OpenDocument.
1. تهيئة خيارات تخطيط المخرجات: استخدم فئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/) لتحديد كيفية عرض الملاحظات والتعليقات.
1. حفظ العرض بصيغة TIFF: مرّر الخيارات المهيأة إلى طريقة [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) .

لنفترض أن لدينا ملف "speaker_notes.pptx" يحتوي على الشريحة التالية:

![شريحة العرض مع ملاحظات المتحدث](slide_with_notes.png)

القطعة البرمجية أدناه توضح كيفية تحويل العرض إلى صورة TIFF في وضع ملاحظة الشريحة باستخدام طريقة [setSlidesLayoutOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) .
```java
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // عرض الملاحظات أسفل الشريحة.

    // تهيئة خيارات TIFF مع تخطيط الملاحظات.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // حفظ العرض التقديمي كملف TIFF مع ملاحظات المتحدث.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```


النتيجة:

![صورة TIFF مع ملاحظات المتحدث](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
تحقق من Aspose [محول PowerPoint مجاني إلى ملصق](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يمكنني التحكم في موضع منطقة الملاحظات في ملف TIFF الناتج؟**

نعم. استخدم [notes layout settings](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) لاختيار أحد الخيارات مثل `None` أو `BottomTruncated` أو `BottomFull`، والتي على التوالي تخفي الملاحظات أو تُلائمها في صفحة واحدة أو تسمح لها بالانتقال إلى صفحات إضافية.

**كيف يمكنني تقليل حجم ملف TIFF مع الملاحظات دون فقدان ملحوظ في الجودة؟**

اختر [efficient compression](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) (مثلاً `LZW` أو `RLE`)، حدد DPI معقول، وإذا كان مقبولًا، استخدم [pixel format](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) أقل (مثل 8 bpp أو 1 bpp للصور أحادية اللون). يمكن أيضًا تقليل أبعاد الصورة [image dimensions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) قليلاً دون أن يؤثر ذلك بشكل ملحوظ على قابلية القراءة.

**هل يؤثر الخط في الملاحظات على النتيجة إذا كانت الخطوط الأصلية غير موجودة في النظام؟**

نعم. يؤدي عدم توفر الخطوط الأصلية إلى استدعاء [substitution](/slides/ar/androidjava/font-selection-sequence/)، مما قد يغيّر مقاييس النص ومظهره. لتجنّب ذلك، [supply the required fonts](/slides/ar/androidjava/custom-font/) أو عيّن [fallback font](/slides/ar/androidjava/fallback-font/) افتراضيًا لضمان استخدام الخطوط المطلوبة.