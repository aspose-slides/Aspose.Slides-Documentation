---
title: "تصدير المعادلات الرياضية من العروض التقديمية في .NET"
linktitle: "تصدير المعادلات"
type: docs
weight: 30
url: /ar/net/exporting-math-equations/
keywords:
- "تصدير المعادلات الرياضية"
- "تصدير المعادلات إلى LaTeX"
- "PowerPoint إلى LaTeX"
- "MathML"
- "LaTeX"
- "PowerPoint"
- "عرض تقديمي"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "تصدير المعادلات الرياضية من عروض PowerPoint إلى LaTeX أو MathML مباشرةً باستخدام Aspose.Slides لـ .NET."
---
## **مقدمة**

تمكنك Aspose.Slides for .NET من تصدير المعادلات الرياضية من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج المعادلات الرياضية الموجودة على الشرائح (من عرض تقديمي معين) واستخدامها في برنامج أو منصة أخرى. 

{{% alert color="info" %}} 
يمكنك تصدير المعادلات مباشرة إلى LaTeX أو إلى MathML، وهو معيار شائع للمحتوى الرياضي يُستخدم على الويب وفي العديد من التطبيقات.
{{% /alert %}}

## **تصدير المعادلات الرياضية إلى LaTeX**

يمكن لـ Aspose.Slides تحويل معادلة رياضية في PowerPoint مباشرةً إلى LaTeX؛ لا تحتاج إلى ملف MathML وسيط أو محول خارجي. يتم تخزين المعادلة الرياضية في إطار نص كـ [MathPortion](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathportion/). استخدم [MathPortion.MathParagraph](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathportion/mathparagraph/) للحصول على [IMathParagraph](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathparagraph/)، ثم استدعِ [IMathParagraph.ToLatex](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathparagraph/tolatex/). تُعيد الطريقة سلسلة نصية يمكنك حفظها أو عرضها أو إرسالها إلى تطبيق آخر أو معالجتها بشكل إضافي.

المثال التالي يفحص كل إطار نص على كل شريحة، يجد جميع أجزاء الرياضيات، ويكتب كل معادلة في ملف `.tex` منفصل:

```csharp
using Aspose.Slides;
using Aspose.Slides.MathText;
using Aspose.Slides.Util;

using var presentation = new Presentation("equations.pptx");

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    var slideNumber = slideIndex + 1;
    var equationNumber = 1;
    var textFrames = SlideUtil.GetAllTextBoxes(slide);

    foreach (var textFrame in textFrames)
    {
        foreach (var paragraph in textFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is not MathPortion mathPortion)
                    continue;

                IMathParagraph mathParagraph = mathPortion.MathParagraph;
                var latexPath = $"slide_{slideNumber}_equation_{equationNumber}.tex";

                var latexText = mathParagraph.ToLatex();
                File.WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}
```

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/ar/net/aspose.slides.util/slideutil/getalltextboxes/) تُعيد كل إطارات النص الموجودة على الشريحة. يميز الفحص النوعي لـ [MathPortion](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathportion/) المعادلات القابلة للتحرير الحقيقية عن النص العادي والصور.

محركات LaTeX وقوالب المستندات لا تدعم جميعها نفس الأوامر أو الحزم أو الأحرف Unicode. اختبر السلسلة المسترجعة مع محرك LaTeX الذي يستخدمه تطبيقك. إذا كان هناك رمز أو عنصر Office Math لا يمتلك تمثيلاً مناسبًا في ذلك البيئة، استبدله في السلسلة المسترجعة بأمر خاص بالمشروع أو تخطَ المعادلة وسجِّل المسألة للمراجعة.

## **حفظ المعادلات الرياضية كـ MathML**

بينما يكتب البشر بسهولة الكود لبعض صيغ المعادلات مثل LaTeX، يواجهون صعوبة في كتابة الكود لـ MathML لأن الأخير يُقصد توليده تلقائيًا بواسطة التطبيقات. تقرأ البرامج وتُحلّل MathML بسهولة لأن كودها مبني على XML، لذا يُستخدم MathML عادةً كصيغة إخراج وطباعة في العديد من المجالات. 

يعرض هذا الكود النموذجي كيفية تصدير معادلة رياضية من عرض تقديمي إلى MathML:

```c#
using Aspose.Slides;
using Aspose.Slides.MathText;

using (Presentation pres = new Presentation())
        {
            var autoShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            mathParagraph.Add(new MathematicalText("a").SetSuperscript("2").Join("+").Join(new MathematicalText("b").SetSuperscript("2")).Join("=").Join(new MathematicalText("c").SetSuperscript("2")));

       using (Stream stream = new FileStream("mathml.xml", FileMode.Create))
                mathParagraph.WriteAsMathMl(stream);
        }
```

## **الأسئلة المتداولة**

**ما الذي يتم تصديره بالضبط إلى MathML – فقرة أم كتلة صيغة منفردة؟**  
يمكنك تصدير إما فقرة رياضية كاملة ([MathParagraph](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathparagraph/)) أو كتلة صيغة منفردة ([MathBlock](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathblock/)) إلى MathML. كلا النوعين يوفّران طريقة للكتابة إلى MathML.

**كيف يمكنني معرفة أن كائنًا على الشريحة هو صيغة رياضية وليس نصًا عاديًا أو صورة؟**  
الصيغة موجودة داخل [MathPortion](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathportion/) وتملك [MathParagraph](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathparagraph/). الصور وأجزاء النص العادي التي لا تحتوي على [MathParagraph](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathparagraph/) ليست صيغًا قابلة للتصدير.

**من أين يأتي MathML في العرض التقديمي – هل هو خاص بـ PowerPoint أم معيار عام؟**  
يستهدف التصدير MathML القياسي (XML). تستخدم Aspose Presentation MathML – الجزء المُقدم من المعيار – وهو مستخدم على نطاق واسع عبر التطبيقات والويب.

**هل يدعم تصدير الصيغ داخل الجداول أو SmartArt أو المجموعات، إلخ؟**  
نعم، إذا احتوت تلك الكائنات على أجزاء نصية مع [MathParagraph](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathparagraph/) (أي صيغ PowerPoint الحقيقية)، يتم تصديرها. إذا كانت الصيغة مضمنة كصورة، فلن يتم تصديرها.

**هل يُغيّر تصدير إلى MathML العرض التقديمي الأصلي؟**  
لا. كتابة MathML هي عملية تسلسل لمحتوى الصيغة؛ ولا تُعدّل ملف العرض التقديمي.