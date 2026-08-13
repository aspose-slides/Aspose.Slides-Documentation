---
title: تحويل عروض PowerPoint إلى TIFF مع الملاحظات في .NET
linktitle: PowerPoint إلى TIFF مع الملاحظات
type: docs
weight: 100
url: /ar/net/convert-powerpoint-to-tiff-with-notes/
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
- PowerPoint مع ملاحظات
- العرض مع ملاحظات
- الشريحة مع ملاحظات
- PPT مع ملاحظات
- PPTX مع ملاحظات
- TIFF مع ملاحظات
- .NET
- C#
- Aspose.Slides
description: "تحويل عروض PowerPoint إلى TIFF مع الملاحظات باستخدام Aspose.Slides for .NET. تعرف على كيفية تصدير الشرائح مع ملاحظات المتحدث بكفاءة."
---
## **مقدمة**

توفر Aspose.Slides for .NET حلاً بسيطًا لتحويل عروض PowerPoint وOpenDocument (PPT وPPTX وODP) مع الملاحظات إلى تنسيق TIFF. يُستخدم هذا التنسيق على نطاق واسع لتخزين الصور عالية الجودة، والطباعة، وأرشفة المستندات. مع Aspose.Slides، يمكنك ليس فقط تصدير العروض الكاملة مع ملاحظات المتحدث وإنما أيضًا إنشاء صور مصغرة للشرائح في عرض ملاحظات الشريحة. عملية التحويل بسيطة وفعالة، حيث يتم استخدام طريقة `Save` من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/) لتحويل العرض بالكامل إلى سلسلة من صور TIFF مع الحفاظ على الملاحظات والتخطيط.

## **تحويل عرض تقديمي إلى TIFF مع الملاحظات**

حفظ عرض PowerPoint أو OpenDocument إلى TIFF مع الملاحظات باستخدام Aspose.Slides for .NET يتضمن الخطوات التالية:

1. إنشاء كائن من الفئة [Presentation](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/): تحميل ملف PowerPoint أو OpenDocument.  
1. تكوين خيارات تخطيط الإخراج: استخدم الفئة [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/ar/net/aspose.slides.export/notescommentslayoutingoptions/) لتحديد كيفية عرض الملاحظات والتعليقات.  
1. حفظ العرض إلى TIFF: مرّر الخيارات المُكوَّنة إلى طريقة [Save](https://reference.aspose.com/slides/ar/net/aspose.slides/presentation/methods/save/index).

لنفترض أننا نملك ملف "speaker_notes.pptx" يحتوي على الشريحة التالية:

![شريحة العرض مع ملاحظات المتحدث](slide_with_notes.png)

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي.
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

![صورة TIFF مع ملاحظات المتحدث](TIFF_with_notes.png)

{{% alert title="Tip" color="info" %}}
تحقق من Aspose [محول PowerPoint مجاني إلى ملصق](https://products.aspose.app/slides/ar/conversion/convert-ppt-to-poster-online).
{{% /alert %}}

## **الأسئلة الشائعة**

### هل يمكنني التحكم في موضع منطقة الملاحظات في ملف TIFF الناتج؟

نعم. استخدم [إعدادات تخطيط الملاحظات](https://reference.aspose.com/slides/ar/net/aspose.slides.export/tiffoptions/slideslayoutoptions/) لاختيار أحد الخيارات مثل `None` أو `BottomTruncated` أو `BottomFull`، التي تقوم على التوالي بإخفاء الملاحظات، أو ملئها في صفحة واحدة، أو السماح لها بالامتداد إلى صفحات إضافية.

### كيف يمكنني تقليل حجم ملف TIFF مع الملاحظات دون فقدان ملحوظ للجودة؟

اختر [ضغطًا فعالًا](https://reference.aspose.com/slides/ar/net/aspose.slides.export/tiffoptions/compressiontype/) (مثل `LZW` أو `RLE`)، واضبط DPI معقول، وإذا كان مقبولًا، استخدم [تنسيق بكسل](https://reference.aspose.com/slides/ar/net/aspose.slides.export/tiffoptions/pixelformat/) أقل (مثل 8 bpp أو 1 bpp للون أحادي). تقليل أبعاد [الصورة](https://reference.aspose.com/slides/ar/net/aspose.slides.export/tiffoptions/imagesize/) قليلاً يمكن أيضًا أن يساعد دون أن يؤثر بشكل واضح على قابلية القراءة.

### هل يؤثر الخط في الملاحظات على النتيجة إذا كانت الخطوط الأصلية مفقودة من النظام؟

نعم. الخطوط المفقودة تُفعِّل [الاستبدال](/slides/ar/net/font-selection-sequence/)، مما قد يغيّر قياسات النص ومظهره. لتجنب ذلك، [قدِّم الخطوط المطلوبة](/slides/ar/net/custom-font/) أو عيّن [خطًا احتياطيًا](/slides/ar/net/fallback-font/) افتراضيًا حتى تُستخدم الخطوط المقصودة.