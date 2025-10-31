---
title: تصدير المعادلات الرياضية من العروض التقديمية في بايثون
linktitle: تصدير المعادلات
type: docs
weight: 30
url: /ar/python-net/exporting-math-equations/
keywords:
- تصدير معادلات رياضية
- MathML
- LaTeX
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تمكين تصدير سلس للمعادلات الرياضية من PowerPoint إلى MathML باستخدام Aspose.Slides for Python via .NET—حافظ على التنسيق وزد التوافق."
---

## **المقدمة**

Aspose.Slides for Python via .NET يتيح لك تصدير المعادلات الرياضية من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج المعادلات من شرائح محددة وإعادة استخدامها في برنامج أو منصة أخرى.

{{% alert color="primary" %}}
يمكنك تصدير المعادلات إلى MathML، وهو معيار شائع الاستخدام لتمثيل المحتوى الرياضي على الويب وفي العديد من التطبيقات.
{{% /alert %}}

## **حفظ المعادلات الرياضية كـ MathML**

على الرغم من أن البشر يمكنهم كتابة LaTeX بسهولة، إلا أن MathML يُولَّد عادةً تلقائيًا بواسطة التطبيقات. ولأن MathML يعتمد على XML، يمكن للبرامج قراءته وتحليله بشكل موثوق، لذا يُستخدم كثيرًا كصيغة خروج وطباعة عبر مجالات متعددة.

الكود التالي يوضح كيفية تصدير معادلة رياضية من عرض تقديمي إلى MathML:

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_math_shape(0, 0, 500, 50)
    math_paragraph = auto_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    math_paragraph.add(
        math.MathematicalText("a").
            set_superscript("2").
            join("+").
            join(math.MathematicalText("b").set_superscript("2")).
            join("=").
            join(math.MathematicalText("c").set_superscript("2")))

    with open("mathml.xml", "wb") as file_stream:
        math_paragraph.write_as_math_ml(file_stream)
```

## **الأسئلة الشائعة**

**ما الذي يتم تصديره بالضبط إلى MathML—فقرة أم كتلة معادلة فردية؟**  
يمكنك تصدير إما فقرة رياضية كاملة ([MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)) أو كتلة فردية ([MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)) إلى MathML. كلا النوعين يقدمان طريقة للكتابة إلى MathML.

**كيف يمكنني معرفة أن كائنًا على الشريحة هو معادلة رياضية وليس نصًا عاديًا أو صورة؟**  
المعادلة موجودة في [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) وتملك [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/). الصور والنصوص العادية التي لا تحتوي على [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) غير قابلة للتصدير كمعادلات.

**من أين يأتي MathML في العرض التقديمي—هل هو خاص بـ PowerPoint أم معيار عام؟**  
عملية التصدير تستهدف MathML القياسي (XML). تستخدم Aspose Presentation MathML—الجزء الفرعي من المعيار المتعلق بالعروض—والذي يُستَخدم على نطاق واسع عبر التطبيقات والويب.

**هل يدعم التصدير للمعادلات داخل الجداول أو SmartArt أو المجموعات وما إلى ذلك؟**  
نعم، إذا كانت تلك الكائنات تحتوي على أجزاء نصية بها [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) (أي معادلات PowerPoint حقيقية)، فسيتم تصديرها. إذا وُضعت المعادلة كصورة، فلن تُصدر.

**هل تعديل التصدير إلى MathML يغيّر العرض التقديمي الأصلي؟**  
لا. كتابة MathML هي عملية تسلسل لمحتوى المعادلة؛ ولا تُغيّر ملف العرض التقديمي.