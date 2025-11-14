---
title: تصدير معادلات رياضية
type: docs
weight: 30
url: /ar/python-net/exporting-math-equations/
keywords: "تصدير المعادلات الرياضية، عرض PowerPoint، بايثون، Aspose.Slides لبايثون عبر .NET"
description: "تصدير معادلات PowerPoint الرياضية باستخدام بايثون"
---

تتيح لك Aspose.Slides لبايثون عبر .NET تصدير المعادلات الرياضية من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج المعادلات الرياضية من الشرائح (من عرض تقديمي محدد) واستخدامها في برنامج أو منصة أخرى.

{{% alert color="primary" %}}

يمكنك تصدير المعادلات إلى MathML، وهو تنسيق أو معيار شائع للمعادلات الرياضية ومحتوى مشابه الذي يُرى على الويب وفي العديد من التطبيقات.

{{% /alert %}}

بينما يستطيع البشر بسهولة كتابة الشفرة لبعض تنسيقات المعادلات مثل LaTeX، فإنهم يواجهون صعوبة في كتابة الشفرة لـ MathML لأن هذا الأخير من المفترض أن يتم توليده تلقائيًا بواسطة التطبيقات. تقرأ البرامج وت解析 MathML بسهولة لأن شفرته مكتوبة بصيغة XML، لذا يُستخدم MathML بشكل شائع كتنسق للإخراج والطباعة في العديد من المجالات.

تظهر لك هذه الشفرة النموذجية كيفية تصدير معادلة رياضية من عرض تقديمي إلى MathML:

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as pres:
    autoShape = pres.slides[0].shapes.add_math_shape(0, 0, 500, 50)
    mathParagraph = autoShape.text_frame.paragraphs[0].portions[0].math_paragraph

    mathParagraph.add(
        math.MathematicalText("a").
            set_superscript("2").
            join("+").
            join(math.MathematicalText("b").set_superscript("2")).
            join("=").
            join(math.MathematicalText("c").set_superscript("2")))

    with open("mathml.xml", "wb") as stream:
        mathParagraph.write_as_math_ml(stream)
```