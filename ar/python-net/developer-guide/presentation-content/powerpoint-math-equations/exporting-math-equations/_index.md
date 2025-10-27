---
title: تصدير المعادلات الرياضية من العروض التقديمية في بايثون
linktitle: تصدير المعادلات
type: docs
weight: 30
url: /ar/python-net/developer-guide/presentation-content/powerpoint-math-equations/exporting-math-equations/
keywords:
- تصدير المعادلات الرياضية
- MathML
- LaTeX
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تمكين تصدير سلس للمعادلات الرياضية من PowerPoint إلى MathML باستخدام Aspose.Slides for Python via .NET — حافظ على التنسيق وعزز التوافق."
---

## **المقدمة**

Aspose.Slides for Python via .NET يتيح لك تصدير المعادلات الرياضية من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج المعادلات من شرائح معينة وإعادة استخدامها في برنامج أو منصة أخرى.

{{% alert color="primary" %}}

يمكنك تصدير المعادلات إلى MathML، وهو معيار واسع الاستخدام لتمثيل المحتوى الرياضي على الويب وفي العديد من التطبيقات.

{{% /alert %}}

## **حفظ المعادلات الرياضية كـ MathML**

على الرغم من أن البشر يمكنهم كتابة LaTeX بسهولة، فإن MathML يُنشأ عادةً تلقائيًا بواسطة التطبيقات. ونظرًا لأن MathML يعتمد على XML، يمكن للبرامج قراءته وتحليله بثقة، لذا يُستخدم كثيرًا كصيغة إخراج وطباعة عبر مجالات متعددة.

يظهر المثال البرمجي التالي كيف يتم تصدير معادلة رياضية من عرض تقديمي إلى MathML:

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

يمكنك تصدير إما فقرة رياضية كاملة ([MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)) أو كتلة صيغة فردية ([MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)) إلى MathML. كلا النوعين يقدمان طريقة للكتابة إلى MathML.

**كيف يمكنني معرفة أن كائنًا على الشريحة هو صيغة رياضية وليس نصًا عاديًا أو صورة؟**

الصيغة تتواجد داخل [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) وتملك [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/). الصور وأجزاء النص العادي التي لا تحتوي على [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) لا يمكن تصديرها كمعادلات.

**من أين يأتي MathML في العرض التقديمي — هل هو خاص بـ PowerPoint أم معيار عام؟**

هدف التصدير هو MathML القياسي (XML). تستخدم Aspose نسخة Presentation MathML — الجزء الفرعي من المعيار المخصص للعروض التقديمية — وهو مستخدم على نطاق واسع عبر التطبيقات والويب.

**هل يُدعم تصدير الصيغ داخل الجداول أو SmartArt أو المجموعات وما إلى ذلك؟**

نعم، إذا احتوت تلك الكائنات على أجزاء نصية بها [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) (أي صيغ PowerPoint حقيقية)، فسيتم تصديرها. إذا كانت الصيغة مضمَّنة كصورة، فلن يتم تصديرها.

**هل يؤدي تصدير إلى MathML إلى تعديل العرض التقديمي الأصلي؟**

لا. كتابة MathML هو تسلسل لمحتوى الصيغة؛ ولا يُغيّر ملف العرض التقديمي.