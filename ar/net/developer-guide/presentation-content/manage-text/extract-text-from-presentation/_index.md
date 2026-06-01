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
  - عرض تقديمي
  - .NET
  - C#
  - Aspose.Slides
description: "استخراج النص بسرعة من عروض PowerPoint وOpenDocument باستخدام Aspose.Slides for .NET. اتبع دليلنا البسيط خطوة بخطوة لتوفير الوقت."
---
## **نظرة عامة**

استخراج النص من العروض التقديمية هو مهمة شائعة ولكنها أساسية للمطورين الذين يعملون مع محتوى الشرائح. سواء كنت تتعامل مع ملفات Microsoft PowerPoint بصيغة PPT أو PPTX، أو عروض OpenDocument (ODP)، فإن الوصول إلى البيانات النصية واستعادتها يمكن أن يكون حيويًا للتحليل، الأتمتة، الفهرسة، أو مهام ترحيل المحتوى.

توفر هذه المقالة دليلًا شاملًا حول كيفية استخراج النص بكفاءة من صيغ العروض التقديمية المختلفة، بما في ذلك PPT وPPTX وODP، باستخدام Aspose.Slides for .NET. ستتعلم كيفية التجول عبر عناصر العرض لاستخلاص النص المطلوب بدقة.

## **استخراج النص من شريحة**

Aspose.Slides for .NET توفر مساحة الأسماء [Aspose.Slides.Util](https://reference.aspose.com/slides/ar/net/aspose.slides.util/) التي تشمل الفئة [SlideUtil](https://reference.aspose.com/slides/ar/net/aspose.slides.util/slideutil/). هذه الفئة تعرض عدة أساليب ثابتة محملة زائدًا لاستخراج كل النص من عرض تقديمي أو شريحة. لاستخراج النص من شريحة في عرض تقديمي، استخدم الأسلوب [GetAllTextBoxes](https://reference.aspose.com/slides/ar/net/aspose.slides.util/slideutil/getalltextboxes/). هذا الأسلوب يقبل كائنًا من النوع [IBaseSlide](https://reference.aspose.com/slides/ar/net/aspose.slides/ibaseslide/) كمعامل. عند التنفيذ، يقوم الأسلوب بمسح الشريحة بالكامل بحثًا عن النص ويعيد مصفوفة من الكائنات من النوع [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/)، مع الحفاظ على أي تنسيق نصي.

المقتطف البرمجي التالي يستخرج كل النص من الشريحة الأولى في العرض:

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

لمسح النص من العرض بالكامل، استخدم الأسلوب الثابت [GetAllTextFrames](https://reference.aspose.com/slides/ar/net/aspose.slides.util/slideutil/getalltextframes/) الذي توفره الفئة [SlideUtil](https://reference.aspose.com/slides/ar/net/aspose.slides.util/slideutil/). يتقبل هذا الأسلوب معاملين:

1. أولاً، كائن من النوع [IPresentation](https://reference.aspose.com/slides/ar/net/aspose.slides/ipresentation/) يمثل عرض PowerPoint أو OpenDocument سيتم استخراج النص منه.
1. ثانيًا، قيمة `Boolean` تُشير إلى ما إذا كان يجب تضمين الشرائح الرئيسية عند مسح النص من العرض.

يعيد الأسلوب مصفوفة من الكائنات من النوع [ITextFrame](https://reference.aspose.com/slides/ar/net/aspose.slides/itextframe/)، متضمنةً معلومات تنسيق النص. الشيفرة أدناه تمسح النص وتفاصيل التن