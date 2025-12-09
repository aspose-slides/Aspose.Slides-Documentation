---
title: استخراج النص المتقدم من العروض التقديمية في .NET
linktitle: استخراج النص
type: docs
weight: 90
url: /ar/net/extract-text-from-presentation/
keywords:
- استخراج النص
- استخراج النص من الشريحة
- استخراج النص من العرض التقديمي
- استخراج النص من PowerPoint
- استخراج النص من OpenDocument
- استخراج النص من PPT
- استخراج النص من PPTX
- استخراج النص من ODP
- استرجاع النص
- استرجاع النص من الشريحة
- استرجاع النص من العرض التقديمي
- استرجاع النص من PowerPoint
- استرجاع النص من OpenDocument
- استرجاع النص من PPT
- استرجاع النص من PPTX
- استرجاع النص من ODP
- PowerPoint
- OpenDocument
- العرض التقديمي
- .NET
- C#
- Aspose.Slides
description: "استخراج النص بسرعة من عروض PowerPoint و OpenDocument باستخدام Aspose.Slides لـ .NET. اتبع دليلنا البسيط خطوة بخطوة لتوفير الوقت."
---

## **نظرة عامة**

يُعد استخراج النص من العروض التقديمية مهمة شائعة ولكنها أساسية للمطورين الذين يتعاملون مع محتوى الشرائح. سواءً كنت تتعامل مع ملفات Microsoft PowerPoint بصيغة PPT أو PPTX، أو عروض OpenDocument (ODP)، فإن الوصول إلى البيانات النصية واسترجاعها يمكن أن يكون حيويًا للتحليل، أو الأتمتة، أو الفهرسة، أو أغراض ترحيل المحتوى.

تقدم هذه المقالة دليلًا شاملاً حول كيفية استخراج النص بفعالية من تنسيقات العرض المختلفة، بما في ذلك PPT وPPTX وODP، باستخدام Aspose.Slides for .NET. ستتعلم كيفية تكرار عناصر العرض بشكل منهجي لاسترجاع محتوى النص الدقيق الذي تحتاجه.

## **استخراج النص من شريحة**

توفر Aspose.Slides for .NET مساحة الأسماء [Aspose.Slides.Util](https://reference.aspose.com/slides/net/aspose.slides.util/) التي تحتوي على الفئة [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/). تُعرِّف هذه الفئة عدة طرق ثابتة محملّة (overloaded) لاستخراج جميع النصوص من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض تقديمي، استخدم الطريقة [GetAllTextBoxes](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/getalltextboxes/). تقبل هذه الطريقة كمعامل كائنًا من النوع [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/). عند تنفيذها، تقوم الطريقة بمسح الشريحة بالكامل بحثًا عن النص وتعيد مصفوفة من الكائنات من النوع [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)، مع الحفاظ على أي تنسيق للنص.

المقتطف البرمجي التالي يستخرج جميع النصوص من الشريحة الأولى في العرض التقديمي:
```cs
int slideIndex = 0;

// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
using Presentation presentation = new Presentation("demo.pptx");

// الحصول على مرجع إلى الشريحة.
ISlide slide = presentation.Slides[slideIndex];

// الحصول على مصفوفة من إطارات النص من الشريحة.
ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

// التكرار عبر مصفوفة إطارات النص.
for (int i = 0; i < textFrames.Length; i++)
{
    // التكرار عبر الفقرات في إطار النص الحالي.
    foreach (IParagraph paragraph in textFrames[i].Paragraphs)
    {
        // التكرار عبر أجزاء النص في الفقرة الحالية.
        foreach (IPortion portion in paragraph.Portions)
        {
            // عرض النص في جزء النص الحالي.
            Console.WriteLine(portion.Text);

            // عرض ارتفاع الخط للنص.
            Console.WriteLine(portion.PortionFormat.FontHeight);

            // عرض اسم الخط للنص.
            if (portion.PortionFormat.LatinFont != null)
                Console.WriteLine(portion.PortionFormat.LatinFont.FontName);
        }
    }
}
```



## **استخراج النص من عرض تقديمي**

لمسح النص من العرض التقديمي بأكمله، استخدم الطريقة الثابتة [GetAllTextFrames](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/getalltextframes/) التي توفرها الفئة [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/). تقبل هذه الطريقة معاملين:

1. أولاً، كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) يمثل عرض PowerPoint أو OpenDocument سيتم استخراج النص منه.
1. ثانياً، قيمة `Boolean` تحدد ما إذا كان يجب تضمين الشرائح الرئيسية عند مسح النص من العرض التقديمي.

تُعيد الطريقة مصفوفة من الكائنات من النوع [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)، متضمنةً معلومات تنسيق النص. الشيفرة أدناه تمسح النص وتفاصيل التنسيق من عرض تقديمي، بما في ذلك الشرائح الرئيسية:
```cs
// إنشاء كائن من الفئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
using Presentation presentation = new Presentation("demo.pptx");

// الحصول على مصفوفة من إطارات النص من جميع الشرائح في العرض التقديمي.
ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, true);

// التكرار عبر مصفوفة إطارات النص.
for (int i = 0; i < textFrames.Length; i++)
{
    // التكرار عبر الفقرات في إطار النص الحالي.
    foreach (IParagraph paragraph in textFrames[i].Paragraphs)
    {
        // التكرار عبر أجزاء النص في الفقرة الحالية.
        foreach (IPortion portion in paragraph.Portions)
        {
            // عرض النص في جزء النص الحالي.
            Console.WriteLine(portion.Text);

            // عرض ارتفاع الخط للنص.
            Console.WriteLine(portion.PortionFormat.FontHeight);

            // عرض اسم الخط للنص.
            if (portion.PortionFormat.LatinFont != null)
                Console.WriteLine(portion.PortionFormat.LatinFont.FontName);
        }
    }
}
```


## **استخراج النص المصنف والسريع**

توفر الفئة [PresentationFactory](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/) أيضًا طرقًا ثابتة لاستخراج جميع النصوص من العروض التقديمية:
``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```


معامل تعداد [TextExtractionArrangingMode](https://reference.aspose.com/slides/net/aspose.slides/textextractionarrangingmode/) يشير إلى وضع تنظيم نتيجة استخراج النص ويمكن ضبطه على القيم التالية:
- `Unarranged` - النص الخام دون النظر إلى موقعه على الشريحة.
- `Arranged` - يُرتّب النص بنفس الترتيب الموجود على الشريحة.

يمكن استخدام وضع **Unarranged** عندما يكون السرعة أمرًا حاسمًا؛ فهو أسرع من وضع **Arranged**.

الواجهة [IPresentationText](https://reference.aspose.com/slides/net/aspose.slides/ipresentationtext/) تمثل النص الخام المستخرج من العرض التقديمي. تحتوي على الخاصية [SlidesText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/) من مساحة الأسماء [Aspose.Slides.Util](https://reference.aspose.com/slides/net/aspose.slides.util/)، والتي تُعيد مصفوفة من الكائنات من النوع [ISlideText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/). يمثل كل كائن النص الموجود على الشريحة المقابلة. يحتوي كائن النوع [ISlideText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/) على الخصائص التالية:

- `Text` - النص داخل أشكال الشريحة.
- `MasterText` - النص داخل أشكال الشريحة الرئيسية المرتبطة بهذه الشريحة.
- `LayoutText` - النص داخل أشكال شريحة التخطيط المرتبطة بهذه الشريحة.
- `NotesText` - النص داخل أشكال شريحة الملاحظات المرتبطة بهذه الشريحة.
- `CommentsText` - النص داخل التعليقات المرتبطة بهذه الشريحة.
```cs
IPresentationText text = new PresentationFactory().GetPresentationText("presentation.ppt", TextExtractionArrangingMode.Unarranged);
Console.WriteLine(text.SlidesText[0].Text);
Console.WriteLine(text.SlidesText[0].LayoutText);
Console.WriteLine(text.SlidesText[0].MasterText);
Console.WriteLine(text.SlidesText[0].NotesText);
Console.WriteLine(text.SlidesText[0].CommentsText);
```


## **الأسئلة المتكررة**

**ما مدى سرعة معالجة Aspose.Slides للعروض التقديمية الكبيرة أثناء استخراج النص؟**

تم تحسين Aspose.Slides للأداء العالي ويعالج العروض الكبيرة بكفاءة، مما يجعله مناسبًا للسيناريوهات الوقت الحقيقي أو المعالجة الضخمة.

**هل يمكن لـ Aspose.Slides استخراج النص من الجداول والرسوم البيانية داخل العروض التقديمية؟**

نعم، يدعم Aspose.Slides استخراج النص من الجداول والرسوم البيانية والعناصر المعقدة الأخرى في الشرائح، مما يتيح لك الوصول إلى جميع المحتويات النصية وتحليلها بسهولة.

**هل أحتاج إلى ترخيص خاص من Aspose.Slides لاستخراج النص من العروض التقديمية؟**

يمكنك استخراج النص باستخدام النسخة التجريبية المجانية من Aspose.Slides، رغم أنها ستفرض بعض القيود مثل معالجة عدد محدود من الشرائح. للحصول على استخدام غير مقيد ومعالجة عروض تقديمية أكبر، يُنصح بشراء ترخيص كامل.