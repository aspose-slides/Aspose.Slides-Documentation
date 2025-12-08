---
title: تصدير معادلات الرياضيات
type: docs
weight: 30
url: /ar/net/exporting-math-equations/
keywords: "تصدير معادلات الرياضيات, عرض PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "تصدير معادلات الرياضيات في PowerPoint باستخدام C# أو .NET"
---

## **المقدمة**

Aspose.Slides for .NET يتيح لك تصدير معادلات الرياضيات من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج المعادلات الرياضية على الشرائح (من عرض تقديمي محدد) واستخدامها في برنامج أو منصة أخرى.

{{% alert color="primary" %}} 
يمكنك تصدير المعادلات إلى MathML، وهو تنسيق أو معيار شائع للمعادلات الرياضية والمحتوى المشابه الموجود على الويب وفي العديد من التطبيقات. 
{{% /alert %}}

## **حفظ معادلات الرياضيات كـ MathML**

بينما يكتب البشر بسهولة شفرة بعض صيغ المعادلات مثل LaTeX، يواجهون صعوبة في كتابة شفرة MathML لأن الأخيرة يُقصد بها أن تُولد تلقائيًا بواسطة التطبيقات. البرامج تقرأ وت解析 MathML بسهولة لأن شفرتها مبنية على XML، لذا يُستخدم MathML عادةً كتنسيق إخراج وطباعة في كثير من المجالات.

هذا المثال يوضح لك كيفية تصدير معادلة رياضية من عرض تقديمي إلى MathML:
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


## **الأسئلة المتكررة**

**ما الذي يتم تصديره بالضبط إلى MathML—فقرة أم كتلة معادلة منفردة؟**

يمكنك تصدير إما فقرة رياضية كاملة ([MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/)) أو كتلة منفردة ([MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/)) إلى MathML. كلا النوعين يوفر طريقة للكتابة إلى MathML.

**كيف يمكنني معرفة أن كائنًا ما على الشريحة هو صيغة رياضية وليس نصًا عاديًا أو صورة؟**

الصيغة موجودة في [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) وتحتوي على [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/). الصور والنصوص العادية التي لا تحتوي على [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) غير قابلة للتصدير كصيغة.

**من أين يأتي MathML في العرض التقديمي—هل هو خاص بـ PowerPoint أم معيار؟**

التصدير يستهدف MathML القياسي (XML). Aspose يستخدم Presentation MathML—الجزء الفرعي من المعيار المتعلق بالعرض—وهو مستخدم على نطاق واسع عبر التطبيقات والويب.

**هل يتم دعم تصدير الصيغ داخل الجداول أو SmartArt أو المجموعات وغيرها؟**

نعم، إذا كانت تلك الكائنات تحتوي على أجزاء نصية مع [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) (أي صيغ PowerPoint حقيقية)، فإنها تُصدر. إذا كانت الصيغة مضمّنة كصورة، فلن يتم تصديرها.

**هل يقوم التصدير إلى MathML بتعديل العرض التقديمي الأصلي؟**

لا. كتابة MathML هي عملية تسلسل لمحتوى الصيغة؛ لا تُغيّر ملف العرض التقديمي.