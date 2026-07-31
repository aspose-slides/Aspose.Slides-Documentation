---
title: استخراج النص المتقدم من العروض التقديمية في .NET
linktitle: استخراج النص
type: docs
weight: 90
url: /ar/net/extract-text-from-presentation/
aliases:
  - /net/slides-on-cloud-platforms/extracting-text/overview/
  - /net/slides-on-cloud-platforms/extracting-text/slides/ar/
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
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "استخراج النص بسرعة من عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for .NET. اتبع دليلنا البسيط خطوة بخطوة لتوفير الوقت."
---
## **نظرة عامة**

استخراج النص من العروض التقديمية هو مهمة شائعة ولكنها أساسية للمطورين الذين يعملون مع محتوى الشرائح. سواء كنت تتعامل مع ملفات Microsoft PowerPoint بصيغة PPT أو PPTX، أو عروض OpenDocument (ODP)، فإن الوصول إلى البيانات النصية واسترجاعها يمكن أن يكون حيويًا للتحليل، الأتمتة، الفهرسة، أو أغراض ترحيل المحتوى.

توفر هذه المقالة دليلًا شاملًا حول كيفية استخراج النص بكفاءة من تنسيقات العروض المختلفة، بما في ذلك PPT و PPTX و ODP، باستخدام Aspose.Slides for .NET. ستتعلم كيفية التجوال عبر عناصر العرض بشكل منهجي لاسترجاع محتوى النص الذي تحتاجه بدقة.

## **استخراج النص من شريحة**

يوفر Aspose.Slides for .NET مساحة الأسماء [Aspose.Slides.Util](https://reference.aspose.com/slides/ar/net/aspose.slides.util/)، والتي تشمل الفئة [SlideUtil](https://reference.aspose.com/slides/ar/net/aspose.slides.util/slideutil/). تُظهر هذه الفئة عدة طرق ثابتة محملة لاستخراج كل النص من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض تقديمي، استخدم طريقة [GetAllTextBoxes](https://reference.aspose.com/slides/ar/net/aspose.slides.util/slideutil/getalltextboxes/). تقبل هذه الطريقة كائنًا من النوع [IBaseSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseslide/) كمعامل. عند تنفيذها، تقوم الطريقة بمسح الشريحة بأكملها للبحث عن النص وتعيد مصفوفة من الكائنات من النوع [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/)، محتفظةً بأي تنسيق نصي.

المقتطف التالي ي抽取 كل النص من الشريحة الأولى في العرض التقديمي:

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

لمسح النص من كامل العرض التقديمي، استخدم الطريقة الثابتة [GetAllTextFrames](https://reference.aspose.com/slides/ar/net/aspose.slides.util/slideutil/getalltextframes/) التي توفرها الفئة [SlideUtil](https://reference.aspose.com/slides/ar/net/aspose.slides.util/slideutil/). تقبل هذه الطريقة معاملين:

1. أولاً، كائن من النوع [IPresentation](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/) يمثل عرض PowerPoint أو OpenDocument سيتم استخراج النص منه.
1. ثانيًا، قيمة `Boolean` تُحدد ما إذا كان يجب تضمين الشرائح الرئيسة عند مسح النص من العرض التقديمي.

تُعيد الطريقة مصفوفة من الكائنات من النوع [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/)، بما في ذلك معلومات تنسيق النص. الشيفرة أدناه تمسح النص وتفاصيل التنسيق من عرض تقديمي، بما في ذلك الشرائح الرئيسة.

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

تقدم الفئة [PresentationFactory](https://reference.aspose.com/slides/ar/net/aspose.slides/presentationfactory/) أيضًا طرقًا لاستخراج كل النص من العروض التقديمية:

``` cs
IPresentationText GetPresentationText(string file, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode);
IPresentationText GetPresentationText(Stream stream, TextExtractionArrangingMode mode, ILoadOptions options);
```

معامل التعداد [TextExtractionArrangingMode](https://reference.aspose.com/slides/ar/net/aspose.slides/textextractionarrangingmode/) يُحدد وضع تنظيم نتيجة استخراج النص ويمكن تعيينه إلى القيم التالية:
- `Unarranged` - النص الخام دون مراعاة موقعه على الشريحة.
- `Arranged` - يتم ترتيب النص بنفس الترتيب الموجود على الشريحة.

يمكن استخدام وضع غير المرتب عندما تكون السرعة حرجة؛ فهو أسرع من وضع المرتب.

تمثل الواجهة [IPresentationText](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentationtext/) النص الخام المستخرج من العرض التقديمي. تُعيد خاصية `SlidesText` مصفوفة من الكائنات من النوع [ISlideText](https://reference.aspose.com/slides/ar/net/aspose.slides/islidetext/). كل كائن يمثل النص على الشريحة المقابلة. يحتوي كائن من النوع [ISlideText](https://reference.aspose.com/slides/ar/net/aspose.slides/islidetext/) على الخصائص التالية:

- `Text` - النص داخل أشكال الشريحة.
- `MasterText` - النص داخل أشكال الشريحة الرئيسة المرتبطة بهذه الشريحة.
- `LayoutText` - النص داخل أشكال شريحة التخطيط المرتبطة بهذه الشريحة.
- `NotesText` - النص داخل أشكال شريحة الملاحظات المرتبطة بهذه الشريحة.
- `CommentsText` - النص داخل التعليقات المرتبطة بهذه الشريحة.

```cs
var presentationPath = "presentation.ppt";
var arrangingMode = TextExtractionArrangingMode.Unarranged;
var presentationText = PresentationFactory.Instance.GetPresentationText(presentationPath, arrangingMode);
var firstSlideText = presentationText.SlidesText[0];

Console.WriteLine(firstSlideText.Text);
Console.WriteLine(firstSlideText.LayoutText);
Console.WriteLine(firstSlideText.MasterText);
Console.WriteLine(firstSlideText.NotesText);
Console.WriteLine(firstSlideText.CommentsText);
```

## **الأسئلة المتكررة**

**ما السرعة التي تعالج بها Aspose.Slides العروض التقديمية الكبيرة أثناء استخراج النص؟**

تم تحسين Aspose.Slides للأداء العالي ويمكنها معالجة حتى [العروض التقديمية الكبيرة](/slides/ar/net/open-presentation/)، مما يجعلها مناسبة لسيناريوهات المعالجة الفورية أو الضخمة.

**هل يمكن لـ Aspose.Slides استخراج النص من الجداول والرسوم البيانية داخل العروض التقديمية؟**

نعم. يمكن لـ Aspose.Slides استخراج النص من العديد من عناصر الشريحة، بما في ذلك الجداول والكائنات المتعلقة بالمخططات، بحيث يمكنك الوصول إلى المحتوى النصي وتحليله في الهياكل الشائعة للعرض التقديمي.

**هل أحتاج إلى ترخيص خاص من Aspose.Slides لاستخراج النص من العروض التقديمية؟**

يمكنك استخراج النص باستخدام نسخة التجربة المجانية من Aspose.Slides، رغم أنها ستحتوي على [بعض القيود](/slides/ar/net/licensing/)، مثل معالجة عدد محدود من الشرائح فقط. لاستخدام غير مقيد ومعالجة عروض تقديمية أكبر، يُنصح بشراء ترخيص كامل.