---
title: تصدير المعادلات الرياضية
type: docs
weight: 30
url: /net/exporting-math-equations/
keywords: "تصدير المعادلات الرياضية، عرض PowerPoint، C#، Csharp، Aspose.Slides لـ .NET"
description: "تصدير معادلات PowerPoint الرياضية في C# أو .NET"
---

تتيح لك Aspose.Slides لـ .NET تصدير المعادلات الرياضية من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج المعادلات الرياضية من الشرائح (من عرض تقديمي معين) واستخدامها في برنامج أو منصة أخرى.

{{% alert color="primary" %}} 

يمكنك تصدير المعادلات إلى MathML، وهو تنسيق شائع أو معيار للمعادلات الرياضية ومحتوى مشابه يُرى على الويب وفي العديد من التطبيقات.

{{% /alert %}}

بينما يكتب البشر بسهولة الشيفرة لبعض تنسيقات المعادلات مثل LaTeX، فإنهم يواجهون صعوبة في كتابة الشيفرة لـ MathML لأن الأخيرة مصممة ليتم إنشاؤها تلقائيًا بواسطة التطبيقات. تقرأ البرامج وتن解析 MathML بسهولة لأن شيفرتها في XML، لذا يُستخدم MathML بشكل شائع كتنسيق للإخراج والطباعة في العديد من المجالات.

تظهر لك هذه الشيفرة المثال كيفية تصدير معادلة رياضية من عرض تقديمي إلى MathML:

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