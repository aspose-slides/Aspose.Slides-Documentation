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
description: "تصدير المعادلات الرياضية من عروض PowerPoint التقديمية إلى LaTeX أو MathML مباشرةً باستخدام Aspose.Slides لـ .NET."
---
## **المقدمة**

Aspose.Slides for .NET يسمح لك بتصدير المعادلات الرياضية من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج المعادلات الرياضية على الشرائح (من عرض تقديمي محدد) واستخدامها في برنامج أو منصة أخرى. 

{{% alert color="primary" %}} 
يمكنك تصدير المعادلات مباشرة إلى LaTeX أو إلى MathML، وهو معيار شائع للمحتوى الرياضي يُستخدم على الويب وفي العديد من التطبيقات.
{{% /alert %}}

## **تصدير المعادلات الرياضية إلى LaTeX**

Aspose.Slides يمكنه تحويل معادلة PowerPoint الرياضية مباشرة إلى LaTeX؛ لا يلزم ملف وسط MathML أو محول خارجي. تُخزن المعادلة الرياضية في إطار نص كـ [MathPortion](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathportion/). استخدم [MathPortion.MathParagraph](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathportion/mathparagraph/) للحصول على [IMathParagraph](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathparagraph/)، ثم استدعِ [IMathParagraph.ToLatex](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/imathparagraph/tolatex/). تُعيد الطريقة سلسلة نصية يمكنك حفظها أو عرضها أو إرسالها إلى تطبيق آخر أو معالجتها بصورة إضافية.

المثال التالي يفحص كل إطار نص على كل شريحة، يجد جميع أجزاء الرياضيات، ويكتب كل معادلة إلى ملف `.tex` منفصل:

```csharp
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

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/ar/net/aspose.slides.util/slideutil/getalltextboxes/) تُعيد جميع إطارات النص الموجودة على الشريحة. فحص النوع [MathPortion](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathportion/) يُميز المعادلات القابلة للتحرير الحقيقية عن النصوص العادية والصور.

محركات LaTeX وقوالب المستندات لا تدعم جميع الأوامر أو الحزم أو الأحرف Unicode نفسها. اختبر السلسلة التي تم إرجاعها مع محرك LaTeX المستخدم في تطبيقك. إذا لم يكن هناك تمثيل مناسب لرمز أو عنصر Office Math في ذلك البيئة، استبدله في السلسلة بأمر خاص بالمشروع أو تخطِ المعادلة وسجل المشكلة للمراجعة.

## **حفظ المعادلات الرياضية كـ MathML**

بينما يكتب البشر بسهولة الشيفرة لبعض صيغ المعادلات مثل LaTeX، يواجهون صعوبة في كتابة الشيفرة للـ MathML لأن الأخيرة تُقصد أن تُولد آليًا بواسطة التطبيقات. تقرأ البرامج وتُحلل MathML بسهولة لأن شيفرتها في XML، لذلك يُستخدم MathML عادةً كصيغة إخراج وطباعة في العديد من المجالات. 

هذا الكود العيني يُظهر لك كيفية تصدير معادلة رياضية من عرض تقديمي إلى MathML:

```c#
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

**ما الذي يتم تصديره بالضبط إلى MathML—فقرة أم كتلة صيغة فردية؟**

يمكنك تصدير إما فقرة رياضية كاملة ([MathParagraph](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathparagraph/)) أو كتلة فردية ([MathBlock](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathblock/)) إلى MathML. كلا النوعين يقدمان طريقة للكتابة إلى MathML.

**كيف يمكنني معرفة أن كائنًا على الشريحة هو صيغة رياضية وليس نصًا عاديًا أو صورة؟**

الصيغة موجودة في [MathPortion](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathportion/) وتملك [MathParagraph](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathparagraph/). الصور وأجزاء النص العادية التي لا تحتوي على [MathParagraph](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathparagraph/) ليست صيغًا قابلة للتصدير.

**من أين يأتي MathML في العرض التقديمي—هل هو خاص بـ PowerPoint أم معيار؟**

أهداف التصدير هي MathML المعياري (XML). تستخدم Aspose Presentation MathML—الفرع التقديمي من المعيار—وهو مستخدم على نطاق واسع عبر التطبيقات والويب.

**هل يتم دعم تصدير الصيغ داخل الجداول أو SmartArt أو المجموعات وغيرها؟**

نعم، إذا احتوت تلك الكائنات على أجزاء نص مع [MathParagraph](https://reference.aspose.com/slides/ar/net/aspose.slides.mathtext/mathparagraph/) (أي صيغ PowerPoint حقيقية)، فإنها تُصدَّر. إذا كانت الصيغة مضمنة كصورة، فلن تُصدَّر.

**هل تعديل العرض التقديمي الأصلي يحدث عند تصدير إلى MathML؟**

لا. كتابة MathML هي تسلسل محتوى الصيغة؛ لا تُعدِّل ملف العرض التقديمي الأصلي.