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
description: "تحويل عروض PowerPoint التقديمية إلى TIFF مع الملاحظات باستخدام Aspose.Slides for .NET. تعلم كيفية تصدير الشرائح مع ملاحظات المتحدث بكفاءة."
---

## **نظرة عامة**

Aspose.Slides for .NET توفر حلاً بسيطًا لتحويل العروض التقديمية PowerPoint وOpenDocument (PPT وPPTX وODP) مع الملاحظات إلى صيغة TIFF. تُستخدم هذه الصيغة على نطاق واسع لتخزين الصور عالية الجودة والطباعة وأرشفة المستندات. مع Aspose.Slides، يمكنك ليس فقط تصدير العروض التقديمية بالكامل مع ملاحظات المتحدث بل أيضًا إنشاء صور مصغرة للشرائح في طريقة عرض ملاحظات الشريحة. عملية التحويل بسيطة وفعّالة، حيث يتم استدعاء طريقة `Save` من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) لتحويل العرض التقديمي بالكامل إلى سلسلة من صور TIFF مع الحفاظ على الملاحظات والتنسيق.

## **تحويل عرض تقديمي إلى TIFF مع الملاحظات**

حفظ عرض تقديمي PowerPoint أو OpenDocument إلى TIFF مع الملاحظات باستخدام Aspose.Slides for .NET يتضمن الخطوات التالية:

1. إنشاء مثيل لفئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/): تحميل ملف PowerPoint أو OpenDocument.  
1. تكوين خيارات تخطيط الإخراج: استخدام فئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) لتحديد كيفية عرض الملاحظات والتعليقات.  
1. حفظ العرض التقديمي إلى TIFF: تمرير الخيارات المكوّنة إلى طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index).

لنفترض أن لدينا ملف **"speaker_notes.pptx"** يحتوي على الشريحة التالية:

![The presentation slide with speaker notes](slide_with_notes.png)

المقتطف البرمجي أدناه يوضح كيفية تحويل العرض التقديمي إلى صورة TIFF في طريقة عرض ملاحظات الشريحة باستخدام خاصية [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/slideslayoutoptions/).
```c#
// إنشاء كائن فئة Presentation الذي يمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // تكوين خيارات TIFF مع تخطيط الملاحظات.
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // عرض الملاحظات أسفل الشريحة.
        }
    };

    // حفظ العرض التقديمي إلى TIFF مع ملاحظات المتحدث.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```


النتيجة:

![The TIFF image with speaker notes](TIFF_with_notes.png)

{{% alert title="Tip" color="primary" %}}

تحقق من أداة Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **الأسئلة الشائعة**

**هل يمكنني التحكم في موضع منطقة الملاحظات في ملف TIFF الناتج؟**

نعم. استخدم [إعدادات تخطيط الملاحظات](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) لاختيار أحد الخيارات مثل `None` أو `BottomTruncated` أو `BottomFull`، والتي على التوالي تخفي الملاحظات أو تضبطها في صفحة واحدة أو تسمح لها بالانتشار إلى صفحات إضافية.

**كيف يمكنني تقليل حجم ملف TIFF مع الملاحظات دون فقد واضح في الجودة؟**

اختر [ضغطًا فعالًا](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/compressiontype/) (مثل `LZW` أو `RLE`)، وضبط DPI مناسب، وإذا كان مقبولًا، استخدم تنسيق بكسل أقل ([pixel format](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/pixelformat/)) مثل 8 bpp أو 1 bpp للون أحادي. تقليل أبعاد الصورة قليلًا ([image dimensions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/imagesize/)) يمكن أن يساعد أيضًا دون أن يؤثر ملحوظًا على قابلية القراءة.

**هل يؤثر الخط في الملاحظات على النتيجة إذا كانت الخطوط الأصلية غير موجودة على النظام؟**

نعم. الخطوط المفقودة تُفعِّل [استبدالًا](/slides/ar/net/font-selection-sequence/)، مما قد يغيّر مقاييس النص ومظهره. لتجنب ذلك، [وفر الخطوط المطلوبة](/slides/ar/net/custom-font/) أو اضبط [خط احتياطي افتراضي](/slides/ar/net/fallback-font/) حتى تُستخدم الخطوط المقصودة.