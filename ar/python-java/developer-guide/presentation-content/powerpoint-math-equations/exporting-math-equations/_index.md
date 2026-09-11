---
title: تصدير معادلات الرياضيات من العروض التقديمية بلغة بايثون
linktitle: تصدير المعادلات
type: docs
weight: 30
url: /ar/python-java/exporting-math-equations/
keywords:
- تصدير معادلات الرياضيات
- تصدير المعادلات إلى LaTeX
- PowerPoint إلى LaTeX
- MathML
- LaTeX
- PowerPoint
- عرض تقديمي
- Python
- Java
- Aspose.Slides
description: "تصدير معادلات الرياضيات من عروض تقديمية PowerPoint إلى LaTeX أو MathML مباشرةً باستخدام Aspose.Slides للبايثون عبر Java."
---
## **المقدمة**

Aspose.Slides يتيح لك تصدير معادلات الرياضيات من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج المعادلات الرياضية على الشرائح (من عرض تقديمي محدد) واستخدامها في برنامج أو منصة أخرى. 

{{% alert color="info" title="Note" %}} 
يمكنك تصدير المعادلات مباشرة إلى LaTeX أو إلى MathML، وهو معيار شائع للمحتوى الرياضي يُستخدم على الويب وفي العديد من التطبيقات.
{{% /alert %}}

## **تصدير معادلات الرياضيات إلى LaTeX**

يمكن لـ Aspose.Slides تحويل معادلة رياضية في PowerPoint مباشرة إلى LaTeX؛ لا يلزم وجود ملف MathML وسيط أو محول خارجي. تُخزن المعادلة الرياضية في إطار نصي كـ [MathPortion](https://reference.aspose.com/slides/ar/python-java/aspose.slides/mathportion/). استخدم [MathPortion.getMathParagraph](https://reference.aspose.com/slides/ar/python-java/aspose.slides/mathportion/#getMathParagraph) للحصول على [MathParagraph](https://reference.aspose.com/slides/ar/python-java/aspose.slides/mathparagraph/)، ثم استدعِ [MathParagraph.toLatex](https://reference.aspose.com/slides/ar/python-java/aspose.slides/mathparagraph/#toLatex). تُعيد الطريقة سلسلة نصية يمكنك حفظها أو عرضها أو إرسالها إلى تطبيق آخر أو معالجتها بصورة إضافية.

المثال التالي يفحص كل إطار نصي في كل شريحة، يجد جميع أجزاء الرياضيات، ويكتب كل معادلة في ملف `.tex` منفصل:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathPortion, Presentation, SlideUtil

presentation = Presentation("equations.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide_index + 1
        equation_number = 1
        text_frames = SlideUtil.getAllTextBoxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    if not isinstance(portion, MathPortion):
                        continue

                    math_paragraph = portion.getMathParagraph()
                    latex_file_name = f"slide_{slide_number}_equation_{equation_number}.tex"
                    latex_text = math_paragraph.toLatex()
                    latex_path = Path(latex_file_name)
                    latex_path.write_text(str(latex_text), encoding="utf-8")
                    equation_number += 1
finally:
    presentation.dispose()
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/ar/python-java/aspose.slides/slideutil/#getAllTextBoxes) تُرجِع جميع إطارات النص الموجودة في الشريحة. يتحقق فحص النوع [MathPortion](https://reference.aspose.com/slides/ar/python-java/aspose.slides/mathportion/) من فصل المعادلات القابلة للتحرير الحقيقية عن النص العادي والصور.

لا تدعم جميع محركات LaTeX وقوالب المستندات نفس الأوامر أو الحزم أو أحرف Unicode. اختبر السلسلة المعادة باستخدام محرك LaTeX الذي يستخدمه تطبيقك. إذا لم يكن للرمز أو عنصر Office Math تمثيل مناسب في تلك البيئة، استبدله في السلسلة المعادة بأمر مخصص للمشروع أو تخطّ المعادلة وسجِّل المشكلة للمراجعة.

## **حفظ معادلات الرياضيات كـ MathML**

بينما يمكن للناس كتابة كود بسهولة لبعض صيغ المعادلات مثل LaTeX، فإن MathML أصعب كتابةً يدويًا لأنه صُمم لتُولَّد تلقائيًا بواسطة التطبيقات. يمكن للبرامج قراءة MathML وتحليلها بسهولة لأنها مبنية على XML، لذا يُستخدم MathML عادةً كصيغة إخراج وطباعة في العديد من المجالات. 

يوضح لك هذا الكود عينة كيفية تصدير معادلة رياضية من عرض تقديمي إلى MathML:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText, Presentation
from java.io import FileOutputStream

presentation = Presentation()
try:
    math_shape = presentation.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50)
    math_portion = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    math_paragraph = math_portion.getMathParagraph()

    a_squared = MathematicalText("a").setSuperscript("2")
    b_squared = MathematicalText("b").setSuperscript("2")
    c_squared = MathematicalText("c").setSuperscript("2")
    equation = a_squared.join("+").join(b_squared).join("=").join(c_squared)
    math_paragraph.add(equation)

    stream = FileOutputStream("mathml.xml")
    try:
        math_paragraph.writeAsMathMl(stream)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

## **الأسئلة المتكررة**

**ما الذي يتم تصديره بالضبط إلى MathML—فقرة أم كتلة صيغة فردية؟**

يمكنك تصدير إما فقرة رياضية كاملة ([MathParagraph](https://reference.aspose.com/slides/ar/python-java/aspose.slides/mathparagraph/)) أو كتلة صيغة فردية ([MathBlock](https://reference.aspose.com/slides/ar/python-java/aspose.slides/mathblock/)) إلى MathML. كلا النوعين يوفران طريقة للكتابة إلى MathML.

**كيف يمكنني معرفة أن كائنًا على الشريحة هو صيغة رياضية بدلاً من نص عادي أو صورة؟**

توجد الصيغة داخل [MathPortion](https://reference.aspose.com/slides/ar/python-java/aspose.slides/mathportion/) وتملك [MathParagraph](https://reference.aspose.com/slides/ar/python-java/aspose.slides/mathparagraph/). الصور وأجزاء النص العادي التي لا تحتوي على [MathParagraph](https://reference.aspose.com/slides/ar/python-java/aspose.slides/mathparagraph/) ليست صيغًا قابلة للتصدير.

**من أين يأتي MathML في العرض التقديمي—هل هو خاص بـ PowerPoint أم معيار؟**

يستهدف التصدير MathML القياسي (XML). تستخدم Aspose Presentation MathML—الفرع التقديمي من المعيار—والذي يُستخدم على نطاق واسع عبر التطبيقات والويب.

**هل يُدعم تصدير الصيغ داخل الجداول أو SmartArt أو المجموعات، إلخ؟**

نعم، إذا احتوت تلك الكائنات على أجزاء نصية ذات [MathParagraph](https://reference.aspose.com/slides/ar/python-java/aspose.slides/mathparagraph/) (أي صيغ PowerPoint حقيقية)، يتم تصديرها. إذا كانت الصيغة مضمنة كصورة، فلن تُصدَّر.

**هل يؤدي التصدير إلى MathML إلى تعديل العرض التقديمي الأصلي؟**

لا. كتابة MathML هي عملية تسلسل لمحتوى الصيغة؛ ولا تُغيّر ملف العرض التقديمي.