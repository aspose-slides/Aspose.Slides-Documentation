---
title: تصدير معادلات الرياضيات من العروض التقديمية في بايثون
linktitle: تصدير المعادلات
type: docs
weight: 30
url: /ar/python-net/exporting-math-equations/
keywords:
- تصدير معادلات الرياضيات
- تصدير المعادلات إلى LaTeX
- PowerPoint إلى LaTeX
- MathML
- LaTeX
- PowerPoint
- عرض تقديمي
- Python
- Aspose.Slides
description: "تصدير معادلات الرياضيات من عروض PowerPoint التقديمية إلى LaTeX أو MathML مباشرةً باستخدام Aspose.Slides للبايثون عبر .NET."
---
## **المقدمة**

Aspose.Slides for Python via .NET تتيح لك تصدير معادلات الرياضيات من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج المعادلات من شرائح معينة وإعادة استخدامها في برنامج أو منصة أخرى.

{{% alert color="primary" %}}
يمكنك تصدير المعادلات مباشرة إلى LaTeX أو إلى MathML، وهو معيار شائع للمحتوى الرياضي يستخدم على الويب وفي العديد من التطبيقات.
{{% /alert %}}
## **تصدير معادلات الرياضيات إلى LaTeX**

Aspose.Slides يمكنه تحويل معادلة رياضية في PowerPoint مباشرة إلى LaTeX؛ لا حاجة إلى ملف MathML وسيط أو محول خارجي. تُخزن المعادلة الرياضية في إطار نص كـ [MathPortion](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/mathportion/). استخدم [MathPortion.math_paragraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) للحصول على [MathParagraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/mathparagraph/)، ثم استدعِ [MathParagraph.to_latex](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/mathparagraph/to_latex/). تُعيد الطريقة سلسلة نصية يمكنك حفظها أو عرضها أو إرسالها إلى تطبيق آخر أو معالجتها لاحقًا.

المثال التالي يفحص كل إطار نص في كل شريحة، يجد جميع أجزاء الرياضيات، ويكتب كل معادلة في ملف `.tex` منفصل:

```py
import aspose.slides as slides

with slides.Presentation("equations.pptx") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        equation_number = 1
        text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.paragraphs:
                for portion in paragraph.portions:
                    if not isinstance(portion, slides.mathtext.MathPortion):
                        continue

                    math_paragraph = portion.math_paragraph
                    latex_path = f"slide_{slide_number}_equation_{equation_number}.tex"

                    latex_text = math_paragraph.to_latex()
                    with open(latex_path, "w", encoding="utf-8") as latex_file:
                        latex_file.write(latex_text)
                    equation_number += 1
```
[SlideUtil.get_all_text_boxes](https://reference.aspose.com/slides/ar/python-net/aspose.slides.util/slideutil/get_all_text_boxes/) يُرجع جميع إطارات النص الموجودة في الشريحة. فحص النوع [MathPortion](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/mathportion/) يميز بين المعادلات القابلة للتحرير الحقيقية والنص العادي والصور.

محركات LaTeX وقوالب المستندات لا تدعم جميعها نفس الأوامر أو الحزم أو الأحرف Unicode. اختبر السلسلة المعادة مع محرك LaTeX المستخدم في تطبيقك. إذا لم يكن هناك تمثيل مناسب لرمز أو عنصر Office Math في تلك البيئة، استبدله في السلسلة المعادة بأمر خاص بالمشروع أو تخطَ المعادلة وسجِّل المشكلة للمراجعة.
## **حفظ معادلات الرياضيات كـ MathML**

على الرغم من أن البشر يمكنهم كتابة LaTeX بسهولة، فإن MathML يُولد عادةً تلقائيًا بواسطة التطبيقات. وبما أن MathML يعتمد على XML، يمكن للبرامج قراءته وتحليله بشكل موثوق، لذا يُستخدم غالبًا كتنسيق إخراج وطباعة عبر العديد من المجالات.

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
## **الأسئلة المتكررة**

**ما الذي يتم تصديره بالضبط إلى MathML—فقرة أم كتلة صيغة منفردة؟**
يمكنك تصدير إما الفقرة الرياضية كاملة ([MathParagraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/mathparagraph/)) أو كتلة صيغ منفردة ([MathBlock](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/mathblock/)) إلى MathML. كلا النوعين يوفر طريقة للكتابة إلى MathML.

**كيف يمكنني معرفة أن كائنًا في الشريحة هو صيغة رياضية وليس نصًا عاديًا أو صورة؟**
الصيغة تُوجد في [MathPortion](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/mathportion/) ولها [MathParagraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/mathparagraph/). الصور وأجزاء النص العادية التي لا تحتوي على [MathParagraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/mathparagraph/) ليست صيغًا قابلة للتصدير.

**من أين يأتي MathML في العرض التقديمي—هل هو خاص بـ PowerPoint أم معيار؟**
عملية التصدير تستهدف MathML القياسي (XML). تستخدم Aspose MathML التقديمي—الجزء التقدمي من المعيار—وهو مستخدم على نطاق واسع عبر التطبيقات والويب.

**هل يدعم تصدير الصيغ داخل الجداول أو SmartArt أو المجموعات وغيرها؟**
نعم، إذا كانت تلك الكائنات تحتوي على أجزاء نصية مع [MathParagraph](https://reference.aspose.com/slides/ar/python-net/aspose.slides.mathtext/mathparagraph/) (أي صيغ PowerPoint حقيقية)، يتم تصديرها. إذا كانت الصيغة مدمجة كصورة، لا يتم تصديرها.

**هل يقوم التصدير إلى MathML بتعديل العرض التقديمي الأصلي؟**
لا. كتابة MathML هي تسلسل لمحتوى الصيغة؛ لا يتم تعديل ملف العرض التقديمي.