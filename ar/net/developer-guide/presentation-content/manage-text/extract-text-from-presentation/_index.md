---
title: استخراج النص المتقدم من العروض التقديمية في .NET
linktitle: استخراج النص
type: docs
weight: 90
url: /ar/net/extract-text-from-presentation/
keywords:
- استخراج النص
- استخراج النص من شريحة
- استخراج النص من عرض تقديمي
- استخراج النص من PowerPoint
- استخراج النص من OpenDocument
- استخراج النص من PPT
- استخراج النص من PPTX
- استخراج النص من ODP
- استرجاع النص
- استرجاع النص من شريحة
- استرجاع النص من عرض تقديمي
- استرجاع النص من PowerPoint
- استرجاع النص من OpenDocument
- استرجاع النص من PPT
- استرجاع النص من PPTX
- استرجاع النص من ODP
- PowerPoint
- OpenDocument
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استخراج النص بسرعة من عروض PowerPoint و OpenDocument باستخدام Aspose.Slides للـ .NET. اتبع دليلنا البسيط خطوة بخطوة لتوفير الوقت."
---
## **نظرة عامة**

إن استخراج النص من العروض التقديمية مهمة شائعة ولكنها أساسية للمطورين الذين يعملون مع محتوى الشرائح. سواء كنت تتعامل مع ملفات Microsoft PowerPoint بصيغة PPT أو PPTX، أو عروض OpenDocument (ODP)، فإن الوصول إلى البيانات النصية واسترجاعها يمكن أن يكون حيويًا للتحليل، والأتمتة، والفهرسة، أو لأغراض ترحيل المحتوى.

توفر هذه المقالة دليلًا شاملًا حول كيفية استخراج النص بفعالية من صيغ العروض التقديمية المختلفة، بما في ذلك PPT وPPTX وODP، باستخدام Aspose.Slides for .NET. ستتعلم كيفية التجول sistematicamente عبر عناصر العرض لاسترجاع محتوى النص الذي تحتاجه بدقة.

## **استخراج النص من شريحة**

توفر Aspose.Slides for .NET مساحة الأسماء [Aspose.Slides.Util](https://reference.aspose.com/slides/ar/net/aspose.slides.util/) التي تتضمن الفئة [SlideUtil](https://reference.aspose.com/slides/ar/net/aspose.slides.util/slideutil/). تكشف هذه الفئة عن عدة طرق ثابتة محملة بالوسائط لاستخراج كل النص من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض تقديمي، استخدم الطريقة [GetAllTextBoxes](https://reference.aspose.com/slides/ar/net/aspose.slides.util/slideutil/getalltextboxes/). تقبل هذه الطريقة كمعامل كائن من النوع [IBaseSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseslide/). عند تنفيذها، تقوم الطريقة بفحص الشريحة بأكملها بحثًا عن النص وتعيد مصفوفة من الكائنات من النوع [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/)، مع الحفاظ على أي تنسيق للنص.

المقتطف البرمجي التالي يستخرج كل النص من الشريحة الأولى في العرض التقديمي:

```cs
int slideIndex = 0;

using var presentation = new Presentation("demo.pptx");

var slide = presentation.Slides[slideIndex];

var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextBoxes(slide);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **استخراج النص من عرض تقديمي**

للمسح النصي عبر العرض التقديمي بأكمله، استخدم الطريقة الثابتة [GetAllTextFrames](https://reference.aspose.com/slides/ar/net/aspose.slides.util/slideutil/getalltextframes/) التي توفرها الفئة [SlideUtil](https://reference.aspose.com/slides/ar/net/aspose.slides.util/slideutil/). تقبل هذه الطريقة معاملين:

1. أولاً، كائن من النوع [IPresentation](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/) يمثل عرض PowerPoint أو OpenDocument سيتم استخراج النص منه.
2. ثانياً، قيمة `Boolean` تحدد ما إذا كان يجب تضمين الشرائح الرئيسية عند مسح النص من العرض التقديمي.

تعود الطريقة بمصفوفة من الكائنات من النوع [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/)، متضمنةً معلومات تنسيق النص. يقوم الكود أدناه بمسح النص وتفاصيل التنسيق من عرض تقديمي، بما في ذلك الشرائح الرئيسية.

```cs
using var presentation = new Presentation("demo.pptx");

var includeMasterSlides = true;
var textFrames = Aspose.Slides.Util.SlideUtil.GetAllTextFrames(presentation, includeMasterSlides);

foreach (var textFrame in textFrames)
{
    foreach (var paragraph in textFrame.Paragraphs)
    {
        foreach (var portion in paragraph.Portions)
        {
            var portionText = portion.Text;
            Console.WriteLine(portionText);

            var portionFormat = portion.PortionFormat;
            var fontHeight = portionFormat.FontHeight;
            Console.WriteLine(fontHeight);

            var latinFont = portionFormat.LatinFont;
            if (latinFont != null)
            {
                var fontName = latinFont.FontName;
                Console.WriteLine(fontName);
            }
        }
    }
}
```

## **استخراج النص المصنف والسريع**

توفر الفئة [PresentationFactory](https://reference.aspose.com/slides/ar/net/aspose.slides/presentationfactory/) أيضًا طرقًا لاستخراج كل النص من العروض التقديمية:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

معامل الـenum [TextExtractionArrangingMode](https://reference.aspose.com/slides/ar/net/aspose.slides/textextractionarrangingmode/) يحدد وضع تنظيم نتيجة استخراج النص ويمكن ضبطه على القيم التالية:
- `Unarranged` - النص الخام دون اعتبار لموقعه على الشريحة.
- `Arranged` - يتم ترتيب النص بنفس الترتيب الموجود على الشريحة.

يمكن استخدام وضع الـUnarranged عندما تكون السرعة ضرورية؛ فهو أسرع من وضع الـArranged.

تُعَد [IPresentationText](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationtext/) تمثيلًا للنص الخام المستخرج من العرض التقديمي. الخاصية `SlidesText` تُرجِع مصفوفة من الكائنات من النوع [ISlideText](https://reference.aspose.com/slides/ar/net/aspose.slides/islidetext/). كل كائن يمثل النص على الشريحة المقابلة. يحتوي كائن من النوع [ISlideText](https://reference.aspose.com/slides/ar/net/aspose.slides/islidetext/) على الخصائص التالية:

- `Text` - النص داخل أشكال الشريحة.
- `MasterText` - النص داخل أشكال الشريحة الرئيسية المرتبطة بهذه الشريحة.
- `LayoutText` - النص داخل أشكال شريحة التخطيط المرتبطة بهذه الشريحة.
- `NotesText` - النص داخل أشكال شريحة الملاحظات المرتبطة