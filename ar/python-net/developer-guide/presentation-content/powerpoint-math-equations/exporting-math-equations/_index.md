---
title: "تصدير المعادلات الرياضية من العروض التقديمية في بايثون"
linktitle: "تصدير المعادلات"
type: docs
weight: 30
url: /ar/python-net/exporting-math-equations/
keywords:
- "تصدير المعادلات الرياضية"
- MathML
- LaTeX
- PowerPoint
- "العرض التقديمي"
- Python
- Aspose.Slides
description: "تمكين تصدير سلس للمعادلات الرياضية من PowerPoint إلى MathML باستخدام Aspose.Slides for Python عبر .NET — الحفاظ على التنسيق وتعزيز التوافق."
---

## **المقدمة**

Aspose.Slides for Python عبر .NET يتيح لك تصدير المعادلات الرياضية من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج المعادلات من شرائح محددة وإعادة استخدامها في برنامج أو منصة أخرى.

{{% alert color="primary" %}}
يمكنك تصدير المعادلات إلى MathML، وهو معيار واسع الاستخدام لتمثيل المحتوى الرياضي على الويب وفي العديد من التطبيقات.
{{% /alert %}}

## **حفظ المعادلات الرياضية كـ MathML**

على الرغم من أن البشر يمكنهم كتابة LaTeX بسهولة، فإن MathML يتم إنشاؤه عادةً تلقائيًا بواسطة التطبيقات. نظرًا لأن MathML يعتمد على XML، يمكن للبرامج قراءته وتحليله بشكل موثوق، لذا يُستخدم بشكل شائع كصيغة إخراج وطباعة عبر العديد من المجالات.

يعرض الكود المثال التالي كيفية تصدير معادلة رياضية من عرض تقديمي إلى MathML:
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


## **الأسئلة المتكررة**

**ما الذي يتم تصديره إلى MathML بالضبط—فقرة أم كتلة صيغة فردية؟**

يمكنك تصدير إما فقرة رياضية كاملة ([MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)) أو كتلة فردية ([MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)) إلى MathML. كلا النوعين يوفران طريقة للكتابة إلى MathML.

**كيف يمكنني معرفة أن كائنًا على الشريحة هو صيغة رياضية وليس نصًا عاديًا أو صورة؟**

توجد الصيغة داخل [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) ولها [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/). الصور وأجزاء النص العادية التي لا تحتوي على [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) ليست صيغًا قابلة للتصدير.

**من أين يأتي MathML في العرض التقديمي—هل هو خاص بـ PowerPoint أم معيار؟**

يستهدف التصدير MathML القياسي (XML). يستخدم Aspose Presentation MathML—المجموعة الفرعية التقديمية من المعيار—والتي تُستخدم على نطاق واسع عبر التطبيقات والويب.

**هل يدعم تصدير الصيغ داخل الجداول، SmartArt، المجموعات، إلخ؟**

نعم، إذا كانت تلك الكائنات تحتوي على أجزاء نصية مع [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) (أي صيغ PowerPoint حقيقية)، فسيتم تصديرها. إذا تم تضمين صيغة كصورة، فلن يتم تصديرها.

**هل يؤدي تصدير إلى MathML إلى تعديل العرض التقديمي الأصلي؟**

لا. كتابة MathML هي تسلسل لمحتوى الصيغة؛ ولا تعدل ملف العرض التقديمي.