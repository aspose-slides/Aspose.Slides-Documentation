---
title: تصدير المعادلات الرياضية من العروض التقديمية في .NET
linktitle: تصدير المعادلات
type: docs
weight: 30
url: /ar/net/exporting-math-equations/
keywords:
- تصدير المعادلات الرياضية
- MathML
- LaTeX
- PowerPoint
- عرض تقديمي
- .NET
- C#
- Aspose.Slides
description: "تمكين تصدير سلس للمعادلات الرياضية من PowerPoint إلى MathML باستخدام Aspose.Slides لـ .NET — الحفاظ على التنسيق وتعزيز التوافق."
---

## **المقدمة**

تسمح لك Aspose.Slides for .NET بتصدير المعادلات الرياضية من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج المعادلات الرياضية الموجودة على الشرائح (من عرض تقديمي محدد) واستخدامها في برنامج أو منصة أخرى. 

{{% alert color="primary" %}} 
يمكنك تصدير المعادلات إلى MathML، وهو تنسيق شائع أو معيار للمعادلات الرياضية والمحتوى المشابه الموجود على الويب وفي الكثير من التطبيقات. 
{{% /alert %}}

## **حفظ المعادلات الرياضية كـ MathML**

في حين أن البشر يكتبون الكود بسهولة لبعض صيغ المعادلات مثل LaTeX، إلا أنهم يواجهون صعوبة في كتابة الكود لـ MathML لأن الأخيرة تُنشأ تلقائيًا بواسطة التطبيقات. تقرأ البرامج وتفسر MathML بسهولة لأن كودها مكتوب بـ XML، لذا يُستخدم MathML عادةً كصيغة إخراج وطباعة في العديد من المجالات. 

يوضح لك هذا المثال البرمجي كيفية تصدير معادلة رياضية من عرض تقديمي إلى MathML:
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

**ما الذي يتم تصديره إلى MathML بالضبط—فقرة أم كتلة صيغة فردية؟**

يمكنك تصدير إما فقرة رياضية كاملة ([MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/)) أو كتلة فردية ([MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/)) إلى MathML. كلا النوعين يقدمان طريقة للكتابة إلى MathML.

**كيف يمكنني معرفة أن كائنًا على الشريحة هو صيغة رياضية وليس نصًا عاديًا أو صورة؟**

توجد الصيغة داخل [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) وتملك [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/). الصور وأقسام النص العادية التي لا تحتوي على [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) ليست صيغًا قابلة للتصدير.

**من أين يأتي MathML في العرض التقديمي—هل هو خاص بـ PowerPoint أم معيار عام؟**

يستهدف التصدير MathML القياسي (XML). تستخدم Aspose Presentation MathML—الجزء الفرعي التقديمي من المعيار—والذي يُستخدم على نطاق واسع عبر التطبيقات والويب.

**هل يتم دعم تصدير الصيغ داخل الجداول، SmartArt، المجموعات، إلخ؟**

نعم، إذا كان تلك الكائنات تحتوي على أجزاء نصية مع [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) (أي صيغ PowerPoint حقيقية)، فسيتم تصديرها. إذا كانت الصيغة مدمجة كصورة، فلن تُصدر.

**هل يؤدي تصدير إلى MathML إلى تعديل العرض التقديمي الأصلي؟**

لا. كتابة MathML هي عملية تسلسل لمحتوى الصيغة؛ ولا تُعدِّل ملف العرض التقديمي.