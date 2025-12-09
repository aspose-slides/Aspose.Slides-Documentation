---
title: تحويل عروض PowerPoint إلى TIFF مع الملاحظات في .NET
linktitle: PowerPoint إلى TIFF مع الملاحظات
type: docs
weight: 100
url: /ar/net/convert-powerpoint-to-tiff-with-notes/
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
- .NET
- C#
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى TIFF مع الملاحظات باستخدام Aspose.Slides لـ .NET. تعرف على كيفية تصدير الشرائح مع ملاحظات المتحدث بكفاءة."
---

## **نظرة عامة**

Aspose.Slides for .NET يوفر حلاً بسيطًا لتحويل عروض PowerPoint وOpenDocument (PPT، PPTX، وODP) مع الملاحظات إلى تنسيق TIFF. يُستخدم هذا التنسيق على نطاق واسع لتخزين الصور عالية الجودة والطباعة وأرشفة المستندات. باستخدام Aspose.Slides، يمكنك ليس فقط تصدير العروض الكاملة مع ملاحظات المتحدث بل أيضًا إنشاء صور مصغرة للشرائح في عرض شريحة الملاحظات. عملية التحويل بسيطة وفعّالة، حيث يتم الاستفادة من طريقة `Save` في فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) لتحويل العرض بالكامل إلى سلسلة من صور TIFF مع الحفاظ على الملاحظات والتخطيط.

## **تحويل عرض إلى TIFF مع الملاحظات**

Saving a PowerPoint or OpenDocument presentation to TIFF with notes using Aspose.Slides for .NET involves the following steps:

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/): تحميل ملف PowerPoint أو OpenDocument.
2. تهيئة خيارات التخطيط للإخراج: استخدم فئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) لتحديد كيفية عرض الملاحظات والتعليقات.
3. حفظ العرض كملف TIFF: تمرير الخيارات المكوَّنة إلى طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index).

لنفترض أن لدينا ملف "speaker_notes.pptx" يحتوي على الشريحة التالية:

![شريحة العرض مع ملاحظات المتحدث](slide_with_notes.png)

```c#
// إنشاء كائن فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // تكوين خيارات TIFF مع تنسيق الملاحظات.
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // عرض الملاحظات أسفل الشريحة.
        }
    };

    // حفظ العرض التقديمي كملف TIFF مع ملاحظات المتحدث.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```


النتيجة:

![صورة TIFF مع ملاحظات المتحدث](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}
تحقق من أداة Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **FAQ**

**هل يمكنني التحكم في موضع منطقة الملاحظات في ملف TIFF الناتج؟**

نعم. استخدم [notes layout settings](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) لاختيار أحد الخيارات مثل `None` أو `BottomTruncated` أو `BottomFull`، التي تقوم على التوالي بإخفاء الملاحظات، أو ملء صفحة واحدة بالملاحظات، أو السماح لها بالانتقال إلى صفحات إضافية.

**كيف يمكنني تقليل حجم ملف TIFF مع الملاحظات دون فقدان واضح للجودة؟**

اختر [efficient compression](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/compressiontype/) (مثل `LZW` أو `RLE`)، عيّن قيمة DPI معقولة، وإذا كان مقبولًا، استخدم تنسيق بكسل أقل مثل [pixel format](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/pixelformat/) (مثلاً 8 bpp أو 1 bpp للون أحادي). يمكن أيضًا تقليل أبعاد الصورة قليلاً عبر [image dimensions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/imagesize/) دون التأثير الملحوظ على قابلية القراءة.

**هل يؤثر الخط في الملاحظات على النتيجة إذا كانت الخطوط الأصلية غير موجودة في النظام؟**

نعم. الخطوط المفقودة تُؤدي إلى [substitution](/slides/ar/net/font-selection-sequence/)، مما قد يغيّر مقاييس النص ومظهره. لتجنّب ذلك، [supply the required fonts](/slides/ar/net/custom-font/) أو عيّن [fallback font](/slides/ar/net/fallback-font/) افتراضيًا حتى تُستخدم الخطوط المقصودة.