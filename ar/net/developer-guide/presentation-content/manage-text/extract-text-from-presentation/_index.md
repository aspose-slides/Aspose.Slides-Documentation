---
title: "استخراج النص المتقدم من العروض التقديمية في C#"
linktitle: "استخراج النص"
type: docs
weight: 90
url: /ar/net/extract-text-from-presentation/
keywords:
- "استخراج النص"
- "استخراج النص من الشريحة"
- "استخراج النص من العرض التقديمي"
- "استخراج النص من PowerPoint"
- "استخراج النص من PPT"
- "استخراج النص من PPTX"
- "استخراج النص من ODP"
- "C#"
- ".NET"
- "Aspose.Slides"
description: "تعلم كيف تستخرج النص بسرعة وسهولة من عروض PowerPoint التقديمية باستخدام Aspose.Slides لـ .NET. اتبع دليلنا البسيط خطوة بخطوة لتوفير الوقت والوصول بكفاءة إلى محتوى الشرائح في تطبيقاتك."
---

## **نظرة عامة**

يُعد استخراج النص من العروض التقديمية مهمة شائعة ولكنها أساسية للمطورين الذين يتعاملون مع محتوى الشرائح. سواء كنت تتعامل مع ملفات Microsoft PowerPoint بصيغة PPT أو PPTX، أو عروض OpenDocument (ODP)، فإن الوصول إلى البيانات النصية واسترجاعها يمكن أن يكون حيويًا للتحليل، والأتمتة، والفهرسة، أو نقل المحتوى.

توفر هذه المقالة دليلًا شاملًا حول كيفية استخراج النص بكفاءة من صيغ العروض المختلفة، بما في ذلك PPT وPPTX وODP، باستخدام Aspose.Slides for .NET. ستتعلم كيفية iterating systematic عبر عناصر العرض لاسترداد محتوى النص بدقة.

## **استخراج النص من شريحة**

توفر Aspose.Slides for .NET مساحة الاسم [Aspose.Slides.Util](https://reference.aspose.com/slides/net/aspose.slides.util/) التي تشمل الفئة [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/). تُعرِّف هذه الفئة عدة أساليب ثابتة محمَّلة لاستخراج كل النص من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض تقديمي، استخدم الأسلوب [GetAllTextBoxes](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/getalltextboxes/). يقبل هذا الأسلوب كائنًا من النوع [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/) كمعامل. عند تنفيذه، يقوم الأسلوب بفحص الشريحة بالكامل للبحث عن النص ويعيد مصفوفة من الكائنات من النوع [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)، مع الحفاظ على أي تنسيق للنص.

المقتطف البرمجي التالي يستخرج كل النص من الشريحة الأولى للعرض التقديمي:
```cs
int slideIndex = 0;

// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي (PPT، PPTX، ODP، إلخ).
using Presentation presentation = new Presentation("demo.pptx");

// Get a reference to the slide.
ISlide slide = presentation.Slides[slideIndex];

// Get an array of text frames from the slide.
ITextFrame[] textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

// Loop through the array of the text frames.
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


## **استخراج النص من عرض تقديمي كامل**

لمسح النص من العرض التقديمي بالكامل، استخدم الأسلوب الثابت [GetAllTextFrames](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/getalltextframes/) الموجود في الفئة [SlideUtil](https://reference.aspose.com/slides/net/aspose.slides.util/slideutil/). يقبل هذا الأسلوب معاملين:

1. أولاً، كائن [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) يمثل عرض PowerPoint أو OpenDocument سيتم استخراج النص منه.
2. ثانيًا، قيمة `Boolean` تحدد ما إذا كان يجب تضمين الشرائح الرئيسية عند مسح النص من العرض التقديمي.

يعيد الأسلوب مصفوفة من الكائنات من النوع [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)، تشمل معلومات تنسيق النص. الكود أدناه يقوم بمسح النص وتفاصيل التنسيق من عرض تقديمي، بما في ذلك الشرائح الرئيسية:
```cs
// إنشاء كائن من فئة Presentation التي تمثل ملف عرض تقديمي (PPT, PPTX, ODP, إلخ).
using Presentation presentation = new Presentation("demo.pptx");

// Get an array of text frames from all slides in the presentation.
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

توفر الفئة [PresentationFactory](https://reference.aspose.com/slides/net/aspose.slides/presentationfactory/) أيضًا أساليب ثابتة لاستخراج كل النص من العروض التقديمية:
``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```


تشير الوسيطة enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/net/aspose.slides/textextractionarrangingmode/) إلى وضع تنظيم نتيجة استخراج النص ويمكن تعيينها إلى القيم التالية:
- `Unarranged` - النص الخام دون اعتبار لموقعه على الشريحة.
- `Arranged` - يُرتَّب النص بنفس الترتيب الموجود على الشريحة.

يمكن استخدام وضع "Unarranged" عندما تكون السرعة حرجة؛ فهو أسرع من وضع "Arranged".

يمثل [IPresentationText](https://reference.aspose.com/slides/net/aspose.slides/ipresentationtext/) النص الخام المستخرج من العرض التقديمي. يحتوي على خاصية [SlidesText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/) من مساحة الاسم [Aspose.Slides.Util](https://reference.aspose.com/slides/net/aspose.slides.util/)، والتي تُعيد مصفوفة من الكائنات من النوع [ISlideText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/). كل كائن يمثل النص على الشريحة المقابلة. يحتوي كائن النوع [ISlideText](https://reference.aspose.com/slides/net/aspose.slides/islidetext/) على الخصائص التالية:

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


## **الأسئلة الشائعة**

**ما مدى سرعة معالجة Aspose.Slides لعروض تقديمية كبيرة أثناء استخراج النص؟**

تم تحسين Aspose.Slides لأداء عالي ويعالج حتى العروض الكبيرة بكفاءة، مما يجعله مناسبًا للسيناريوهات ذات الوقت الحقيقي أو المعالجة الضخمة.

**هل يمكن لـ Aspose.Slides استخراج النص من الجداول والرسوم البيانية داخل العروض التقديمية؟**

نعم، يدعم Aspose.Slides استخراج النص من الجداول، والرسوم البيانية، وغيرها من عناصر الشريحة المعقدة، مما يتيح لك الوصول إلى جميع المحتويات النصية وتحليلها بسهولة.

**هل أحتاج إلى ترخيص Aspose.Slides خاص لاستخراج النص من العروض التقديمية؟**

يمكنك استخراج النص باستخدام النسخة التجريبية المجانية من Aspose.Slides، رغم أنها تحتوي على بعض القيود، مثل معالجة عدد محدود من الشرائح. للحصول على استخدام غير مقيد ومعالجة عروض تقديمية أكبر، يُنصح بشراء ترخيص كامل.