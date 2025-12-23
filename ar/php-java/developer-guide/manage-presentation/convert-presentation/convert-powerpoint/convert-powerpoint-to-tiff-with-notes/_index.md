---
title: تحويل عروض PowerPoint إلى TIFF مع الملاحظات في PHP
linktitle: PowerPoint إلى TIFF مع الملاحظات
type: docs
weight: 100
url: /ar/php-java/convert-powerpoint-to-tiff-with-notes/
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
- PHP
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى TIFF مع الملاحظات باستخدام Aspose.Slides لـ PHP عبر Java. تعلّم كيفية تصدير الشرائح مع ملاحظات المتحدث بفعالية."
---

## **نظرة عامة**

Aspose.Slides for PHP via Java توفر حلاً بسيطًا لتحويل عروض PowerPoint وOpenDocument (PPT، PPTX، وODP) مع الملاحظات إلى تنسيق TIFF. يُستخدم هذا التنسيق على نطاق واسع لتخزين الصور عالية الجودة والطباعة وأرشفة المستندات. باستخدام Aspose.Slides، يمكنك ليس فقط تصدير العروض بالكامل مع ملاحظات المتحدث بل أيضًا إنشاء صور مصغرة للشرائح في عرض ملاحظات الشريحة. عملية التحويل بسيطة وفعّالة، وتستفيد من طريقة `save` في فئة [العرض](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) لتحويل العرض بالكامل إلى سلسلة من صور TIFF مع الحفاظ على الملاحظات والتنسيق.

## **تحويل عرض تقديمي إلى TIFF مع الملاحظات**

حفظ عرض PowerPoint أو OpenDocument إلى TIFF مع الملاحظات باستخدام Aspose.Slides for PHP via Java يتضمن الخطوات التالية:

1. إنشاء كائن فئة [العرض](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/): تحميل ملف PowerPoint أو OpenDocument.  
2. ضبط خيارات تخطيط الإخراج: استخدم فئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/php-java/aspose.slides/notescommentslayoutingoptions/) لتحديد طريقة عرض الملاحظات والتعليقات.  
3. حفظ العرض كملف TIFF: مرّر الخيارات المضبوطة إلى طريقة [save](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/#save).

لنفترض أن لدينا ملف "speaker_notes.pptx" يحتوي على الشريحة التالية:

![شريحة العرض مع ملاحظات المتحدث](slide_with_notes.png)

```php
// إنشاء كائن فئة Presentation التي تمثل ملف عرض تقديمي.
$presentation = new Presentation("speaker_notes.pptx");
try {
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull); // عرض الملاحظات أسفل الشريحة.

    // تكوين خيارات TIFF مع تخطيط الملاحظات.
    $tiffOptions = new TiffOptions();
    $tiffOptions->setDpiX(300);
    $tiffOptions->setDpiY(300);
    $tiffOptions->setSlidesLayoutOptions($notesOptions);

    // حفظ العرض التقديمي كملف TIFF مع ملاحظات المتحدث.
    $presentation->save("TIFF_with_notes.tiff", SaveFormat::Tiff, $tiffOptions);
} finally {
    $presentation->dispose();
}
```


النتيجة:

![صورة TIFF مع ملاحظات المتحدث](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
تحقق من أسبوز [محول PowerPoint إلى ملصق مجاني](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **الأسئلة المتكررة**

**هل يمكنني التحكم في موضع منطقة الملاحظات في ملف TIFF الناتج؟**

نعم. استخدم [إعدادات تخطيط الملاحظات](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) لاختيار أحد الخيارات مثل `None` أو `BottomTruncated` أو `BottomFull`، والتي على التوالي تخفي الملاحظات أو تناسبها في صفحة واحدة أو تسمح بتوزيعها على صفحات إضافية.

**كيف يمكنني تقليل حجم ملف TIFF مع الملاحظات دون فقدان واضح في الجودة؟**

اختر [ضغطًا فعّالًا](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/setcompressiontype/) (مثل `LZW` أو `RLE`)، قم بتعيين DPI معقول، وإذا كان مقبولاً، استخدم [تنسيق بكسل](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/setpixelformat/) أقل (مثل 8bpp أو 1bpp للون الأحادي). تقليل أبعاد الصورة [قليلًا](https://reference.aspose.com/slides/php-java/aspose.slides/tiffoptions/setimagesize/) أيضًا يمكن أن يساعد دون أن يؤثر بشكل ملحوظ على قابلية القراءة.

**هل يؤثر الخط في الملاحظات على النتيجة إذا كانت الخطوط الأصلية مفقودة من النظام؟**

نعم. الخطوط المفقودة تُفعل [الاستبدال](/slides/ar/php-java/font-selection-sequence/)، مما قد يغيّر مقاييس النص ومظهره. لتجنب ذلك، [قدّم الخطوط المطلوبة](/slides/ar/php-java/custom-font/) أو عيّن [خطًا احتياطيًا افتراضيًا](/slides/ar/php-java/fallback-font/) حتى تُستخدم الأنماط المستهدفة.