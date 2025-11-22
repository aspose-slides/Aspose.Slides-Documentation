---
title: تحويل PowerPoint إلى TIFF مع الملاحظات في C#
linktitle: PowerPoint إلى TIFF مع الملاحظات
type: docs
weight: 100
url: /ar/net/convert-powerpoint-to-tiff-with-notes/
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
- C#
- .NET
- Aspose.Slides
description: "تحويل عروض PowerPoint و OpenDocument إلى TIFF مع الملاحظات باستخدام Aspose.Slides لـ .NET. تعلم كيفية تصدير الشرائح مع ملاحظات المتحدث بكفاءة."
---

## **نظرة عامة**

Aspose.Slides for .NET يوفر حلاً بسيطاً لتحويل عروض PowerPoint وOpenDocument (PPT، PPTX، وODP) مع الملاحظات إلى تنسيق TIFF. يُستخدم هذا التنسيق على نطاق واسع لتخزين الصور عالية الجودة والطباعة وأرشفة المستندات. مع Aspose.Slides، يمكنك ليس فقط تصدير العروض كاملةً مع ملاحظات المتحدث ولكن أيضاً إنشاء صور مصغرة للشرائح في عرض شريحة الملاحظات. عملية التحويل بسيطة وفعّالة، باستخدام طريقة `Save` من فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) لتحويل العرض بالكامل إلى سلسلة من صور TIFF مع الحفاظ على الملاحظات والتنسيق.

## **تحويل عرض إلى TIFF مع الملاحظات**

حفظ عرض PowerPoint أو OpenDocument إلى TIFF مع الملاحظات باستخدام Aspose.Slides for .NET يتضمن الخطوات التالية:

1. إنشاء كائن فئة [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/): تحميل ملف PowerPoint أو OpenDocument.
1. تكوين خيارات تخطيط الإخراج: استخدام فئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/notescommentslayoutingoptions/) لتحديد كيفية عرض الملاحظات والتعليقات.
1. حفظ العرض إلى TIFF: تمرير الخيارات المكوّنة إلى طريقة [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/methods/save/index).

لنفترض أن لدينا ملف "speaker_notes.pptx" يحتوي على الشريحة التالية:

![شريحة العرض مع ملاحظات المتحدث](slide_with_notes.png)

المقتطف البرمجي أدناه يوضح كيفية تحويل العرض إلى صورة TIFF في عرض شريحة الملاحظات باستخدام خاصية [SlidesLayoutOptions](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/slideslayoutoptions/).
```c#
// إنشاء كائن فئة Presentation التي تمثل ملف عرض تقديمي.
using (Presentation presentation = new Presentation("speaker_notes.pptx"))
{
    // تكوين خيارات TIFF مع تخطيط الملاحظات.
    TiffOptions tiffOptions = new TiffOptions
    {
        DpiX = 300,
        DpiY = 300,

        SlidesLayoutOptions = new NotesCommentsLayoutingOptions
        {
            NotesPosition = NotesPositions.BottomFull // عرض الملاحظات تحت الشريحة.
        }
    };

    // حفظ العرض التقديمي إلى TIFF مع ملاحظات المتحدث.
    presentation.Save("TIFF_with_notes.tiff", SaveFormat.Tiff, tiffOptions);
}
```


النتيجة:

![صورة TIFF مع ملاحظات المتحدث](TIFF_with_notes.png)

{{% alert title="نصيحة" color="primary" %}}

اكتشف أداة Aspose [Free PowerPoint to Poster Converter](https://products.aspose.app/slides/conversion/convert-ppt-to-poster-online).

{{% /alert %}}

## **الأسئلة الشائعة**

**هل يمكنني التحكم في موضع منطقة الملاحظات في صورة TIFF الناتجة؟**

نعم. استخدم [إعدادات تخطيط الملاحظات](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) للاختيار بين خيارات مثل `None` أو `BottomTruncated` أو `BottomFull`، والتي إما تخفي الملاحظات أو تضبطها في صفحة واحدة أو تسمح لها بالانتقال إلى صفحات إضافية.

**كيف يمكنني تقليل حجم ملف TIFF مع الملاحظات دون فقدان ملحوظ في الجودة؟**

اختر [ضغطًا فعالًا](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/compressiontype/) (مثل `LZW` أو `RLE`)، عيّن DPI مناسب، وإذا كان مقبولاً، استخدم [صيغة بكسل](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/pixelformat/) أقل (مثل 8 bpp أو 1 bpp للأبيض والأسود). يمكن أيضاً تقليل [أبعاد الصورة](https://reference.aspose.com/slides/net/aspose.slides.export/tiffoptions/imagesize/) قليلًا دون أن يؤثر ذلك بشكل واضح على قابلية القراءة.

**هل يؤثر الخط في الملاحظات على النتيجة إذا كانت الخطوط الأصلية غير موجودة على النظام؟**

نعم. الخطوط المفقودة تؤدي إلى [استبدال](/slides/ar/net/font-selection-sequence/)، مما قد يغيّر قياسات النص ومظهره. لتجنب ذلك، [قدّم الخطوط المطلوبة](/slides/ar/net/custom-font/) أو عيّن [خط احتياطي افتراضي](/slides/ar/net/fallback-font/) لضمان استخدام الخطوط المقصودة.