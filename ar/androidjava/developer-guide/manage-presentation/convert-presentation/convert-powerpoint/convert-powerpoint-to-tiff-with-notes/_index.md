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
- أندرويد
- جافا
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى TIFF مع الملاحظات باستخدام Aspose.Slides لنظام Android عبر Java. تعلم كيفية تصدير الشرائح مع ملاحظات المتحدث بكفاءة."
---

## **نظرة عامة**

Aspose.Slides for Android via Java توفر حلاً بسيطاً لتحويل عروض PowerPoint وOpenDocument (PPT، PPTX، وODP) مع الملاحظات إلى تنسيق TIFF. يُستخدم هذا التنسيق على نطاق واسع لتخزين الصور عالية الجودة والطباعة وأرشفة المستندات. باستخدام Aspose.Slides، يمكنك ليس فقط تصدير العروض الكاملة مع ملاحظات المتحدث ولكن أيضاً إنشاء صور مصغرة للشرائح في عرض ملاحظات الشريحة. عملية التحويل بسيطة وفعالة، حيث يتم الاستفادة من طريقة `save` في فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) لتحويل العرض بالكامل إلى سلسلة من صور TIFF مع الحفاظ على الملاحظات والتخطيط.

## **تحويل عرض إلى TIFF مع الملاحظات**

حفظ عرض PowerPoint أو OpenDocument إلى TIFF مع الملاحظات باستخدام Aspose.Slides for Android via Java يتضمن الخطوات التالية:

1. إنشاء كائن فئة [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) : تحميل ملف PowerPoint أو OpenDocument.  
2. تكوين خيارات تخطيط الإخراج: استخدام فئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/notescommentslayoutingoptions/) لتحديد كيفية عرض الملاحظات والتعليقات.  
3. حفظ العرض إلى TIFF: تمرير الخيارات المكوَّنة إلى طريقة [save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) .

لنفترض أن لدينا ملف "speaker_notes.pptx" يحتوي على الشريحة التالية:

![The presentation slide with speaker notes](slide_with_notes.png)

توضح الشريحة البرمجية أدناه كيفية تحويل العرض إلى صورة TIFF في عرض ملاحظات الشريحة باستخدام طريقة [setSlidesLayoutOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) .
```java
// إنشاء فئة Presentation التي تمثل ملف عرض تقديمي.
Presentation presentation = new Presentation("speaker_notes.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull); // عرض الملاحظات أسفل الشريحة.

    // تهيئة خيارات TIFF مع تخطيط الملاحظات.
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // حفظ العرض التقديمي إلى تنسيق TIFF مع ملاحظات المتحدث.
    presentation.save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```


النتيجة:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
تحقق من أداة Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **الأسئلة المتداولة**

**هل يمكنني التحكم في موضع منطقة الملاحظات في ملف TIFF الناتج؟**

نعم. استخدم [إعدادات تخطيط الملاحظات](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) للاختيار بين الخيارات مثل `None` و`BottomTruncated` أو `BottomFull`، والتي على التوالي تخفي الملاحظات أو تضعها في صفحة واحدة أو تسمح لها بالانتشار إلى صفحات إضافية.

**كيف يمكنني تقليل حجم ملف TIFF مع الملاحظات دون فقدان واضح للجودة؟**

اختر [ضغطًا فعالاً](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) (مثل `LZW` أو `RLE`)، حدد قيمة DPI معقولة، وإذا كان مقبولاً، استخدم تنسيق بكسل أقل [pixel format](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) (مثل 8 bpp أو 1 bpp للصور الأحادية). يمكن أيضاً تقليل [أبعاد الصورة](https://reference.aspose.com/slides/androidjava/com.aspose.slides/tiffoptions/#setImageSize-java.awt.Dimension-) قليلاً دون التأثير الملحوظ على قابلية القراءة.

**هل يؤثر الخط في الملاحظات على النتيجة إذا كانت الخطوط الأصلية غير موجودة في النظام؟**

نعم. الخطوط المفقودة تؤدي إلى [الاستبدال](/slides/ar/androidjava/font-selection-sequence/)، مما قد يغيّر مقاييس النص والمظهر. لتجنب ذلك، [قدم الخطوط المطلوبة](/slides/ar/androidjava/custom-font/) أو عيّن [خطًا احتياطيًا افتراضيًا](/slides/ar/androidjava/fallback-font/) حتى يتم استخدام الخطوط المقصودة.