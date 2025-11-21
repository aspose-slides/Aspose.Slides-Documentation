---
title: تحويل PowerPoint إلى TIFF مع الملاحظات في JavaScript
linktitle: PowerPoint إلى TIFF مع الملاحظات
type: docs
weight: 100
url: /ar/nodejs-java/convert-powerpoint-to-tiff-with-notes/
keywords:
- تحويل PowerPoint إلى TIFF
- تحويل العرض التقديمي إلى TIFF
- تحويل الشريحة إلى TIFF
- تحويل PPT إلى TIFF
- تحويل PPTX إلى TIFF
- تحويل ODP إلى TIFF
- PowerPoint إلى TIFF
- العرض التقديمي إلى TIFF
- الشريحة إلى TIFF
- PPT إلى TIFF
- PPTX إلى TIFF
- ODP إلى TIFF
- PowerPoint مع الملاحظات
- العرض التقديمي مع الملاحظات
- الشريحة مع الملاحظات
- PPT مع الملاحظات
- PPTX مع الملاحظات
- ODP مع الملاحظات
- TIFF مع الملاحظات
- Node.js
- JavaScript
- Aspose.Slides
description: "تحويل عروض PowerPoint وOpenDocument إلى TIFF مع الملاحظات باستخدام Aspose.Slides لـ Node.js عبر Java. تعلم كيفية تصدير الشرائح مع ملاحظات المتحدث بكفاءة."
---

## **نظرة عامة**

Aspose.Slides for Node.js via Java يوفر حلاً بسيطًا لتحويل عروض PowerPoint وOpenDocument (PPT, PPTX, وODP) مع الملاحظات إلى صيغة TIFF. تُستخدم هذه الصيغة على نطاق واسع لتخزين الصور عالية الجودة، الطباعة، وأرشفة المستندات. مع Aspose.Slides، يمكنك ليس فقط تصدير العروض بالكامل مع ملاحظات المتحدث بل أيضًا إنشاء صور مصغرة للشرائح في عرض ملاحظات الشريحة. عملية التحويل بسيطة وفعّالة، باستخدام طريقة `save` من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) لتحويل العرض بالكامل إلى سلسلة من صور TIFF مع الحفاظ على الملاحظات والتخطيط.

## **تحويل عرض تقديمي إلى TIFF مع الملاحظات**

حفظ عرض PowerPoint أو OpenDocument إلى TIFF مع الملاحظات باستخدام Aspose.Slides for Node.js via Java يتضمن الخطوات التالية:

1. إنشاء كائن من فئة [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/): تحميل ملف PowerPoint أو OpenDocument.  
1. تكوين خيارات تخطيط الإخراج: استخدم فئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/notescommentslayoutingoptions/) لتحديد كيفية عرض الملاحظات والتعليقات.  
1. حفظ العرض بتنسيق TIFF: مرّر الخيارات المُكوَّنة إلى طريقة [save](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#save).

لنفترض أن لدينا الملف "speaker_notes.pptx" مع الشريحة التالية:

![شريحة العرض التقديمي مع ملاحظات المتحدث](slide_with_notes.png)

المقتطف البرمجي أدناه يوضح كيفية تحويل العرض إلى صورة TIFF في عرض ملاحظات الشريحة باستخدام طريقة [setSlidesLayoutOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions).
```js
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
let presentation = new aspose.slides.Presentation("speaker_notes.pptx");
try {
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull); // عرض الملاحظات أسفل الشريحة.

    // تكوين خيارات TIFF مع تخطيط الملاحظات.
    let tiffOptions = new aspose.slides.TiffOptions();
    tiffOptions.setDpiX(300);
    tiffOptions.setDpiY(300);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // حفظ العرض التقديمي إلى TIFF مع ملاحظات المتحدث.
    presentation.save("TIFF_with_notes.tiff", aspose.slides.SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```


النتيجة:

![صورة TIFF مع ملاحظات المتحدث](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
تحقق من Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **الأسئلة الشائعة**

**هل يمكنني التحكم في موقع منطقة الملاحظات في ملف TIFF الناتج؟**

نعم. استخدم [إعدادات تخطيط الملاحظات](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/#setSlidesLayoutOptions) للاختيار بين الخيارات مثل `None`، `BottomTruncated`، أو `BottomFull`، والتي تُخفي الملاحظات، تُلائمها في صفحة واحدة، أو تسمح لها بالانتشار إلى صفحات إضافية على التوالي.

**كيف يمكنني تقليل حجم ملف TIFF مع الملاحظات دون فقدان واضح للجودة؟**

اختر [ضغطًا فعالًا](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/setcompressiontype/) (مثل `LZW` أو `RLE`)، حدد قيمة DPI معقولة، وإذا كان مقبولًا، استخدم [تنسيق بكسل](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/setpixelformat/) أقل (مثل 8 bpp أو 1 bpp للوحيد اللون). تقليل أبعاد [الصورة](https://reference.aspose.com/slides/nodejs-java/aspose.slides/tiffoptions/setimagesize/) قليلًا يمكن أيضًا أن يساعد دون التأثير الملحوظ على قابلية القراءة.

**هل يؤثر الخط في الملاحظات على النتيجة إذا كانت الخطوط الأصلية مفقودة من النظام؟**

نعم. الخطوط المفقودة تُفعِّل [الاستبدال](/slides/ar/nodejs-java/font-selection-sequence/)، ما قد يغيّر مقاييس النص ومظهره. لتجنّب ذلك، [وفر الخطوط المطلوبة](/slides/ar/nodejs-java/custom-font/) أو عيّن [خط احتياطي افتراضي](/slides/ar/nodejs-java/fallback-font/) حتى تُستخدم الأنماط المطلوبة.