---
title: تصدير معادلات الرياضيات من العروض التقديمية باستخدام بايثون
linktitle: تصدير المعادلات
type: docs
weight: 30
url: /ar/python-net/exporting-math-equations/
keywords:
- تصدير معادلات الرياضيات
- MathML
- LaTeX
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تمكين تصدير سلس لمعادلات الرياضيات من PowerPoint إلى MathML باستخدام Aspose.Slides للبايثون عبر .NET — الحفاظ على التنسيق وتعزيز التوافق."
---

## **المقدمة**

Aspose.Slides for Python via .NET يسمح لك بتصدير معادلات الرياضيات من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج المعادلات من شرائح محددة وإعادة استخدامها في برنامج أو منصة أخرى.

{{% alert color="primary" %}}
يمكنك تصدير المعادلات إلى MathML، وهو معيار شائع الاستخدام لتمثيل المحتوى الرياضي على الويب وفي العديد من التطبيقات.
{{% /alert %}}

## **حفظ معادلات الرياضيات كـ MathML**

على الرغم من أن البشر يمكنهم كتابة LaTeX بسهولة، إلا أن MathML يُنشَأ عادةً تلقائيًا بواسطة التطبيقات. وبما أن MathML يعتمد على XML، يمكن للبرامج قراءته وتحليله بشكل موثوق، لذا يُستخدم عادةً كصيغة إخراج وطباعة عبر العديد من المجالات.

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

**ما الذي يتم تصديره بالضبط إلى MathML — فقرة أم كتلة صيغة فردية؟**

يمكنك تصدير إما فقرة رياضية كاملة ([MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)) أو كتلة فردية ([MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)) إلى MathML. كلا النوعين يقدمان طريقة للكتابة إلى MathML.

**كيف يمكنني معرفة أن كائنًا على الشريحة هو صيغة رياضية وليس نصًا عاديًا أو صورة؟**

الصيغة موجودة في [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) ولها [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/). الصور والنصوص العادية التي لا تحتوي على [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) ليست صيغًا قابلة للتصدير.

**من أين يأتي MathML في العرض التقديمي — هل هو خاص بـ PowerPoint أم معيار؟**

يستهدف التصدير MathML القياسي (XML). يستخدم Aspose Presentation MathML — الجزء المتعلق بالعرض من المعيار — وهو مستخدم على نطاق واسع في التطبيقات والويب.

**هل يدعم تصدير الصيغ داخل الجداول أو SmartArt أو المجموعات وما إلى ذلك؟**

نعم، إذا كانت تلك الكائنات تحتوي على أجزاء نصية مع [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) (أي صيغ PowerPoint حقيقية)، فإنها تُصدَّر. إذا كانت الصيغة مدمجة كصورة، فلا تُصدَّر.

**هل يؤدي التصدير إلى MathML إلى تعديل العرض التقديمي الأصلي؟**

لا. كتابة MathML هي عملية تسلسل لمحتوى الصيغة؛ لا تُغيّر ملف العرض التقديمي.