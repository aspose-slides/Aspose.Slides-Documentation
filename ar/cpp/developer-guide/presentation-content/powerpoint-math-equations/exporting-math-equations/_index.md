---
title: تصدير المعادلات الرياضية من العروض التقديمية في C++
linktitle: تصدير المعادلات
type: docs
weight: 30
url: /ar/cpp/exporting-math-equations/
keywords:
- تصدير المعادلات الرياضية
- MathML
- LaTeX
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تمكّن من تصدير المعادلات الرياضية بسلاسة من PowerPoint إلى MathML باستخدام Aspose.Slides لـ C++ — حافظ على التنسيق وزد من التوافق."
---
## **المقدمة**

Aspose.Slides لـ C++ يتيح لك تصدير المعادلات الرياضية من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج المعادلات الرياضية الموجودة على الشرائح (من عرض تقديمي محدد) واستخدامها في برنامج أو منصة أخرى.

{{% alert color="primary" %}} 

يمكنك تصدير المعادلات إلى MathML، وهو تنسيق أو معيار شائع للمعادلات الرياضية والمحتوى المماثل الموجود على الويب وفي العديد من التطبيقات. 

{{% /alert %}}

## **حفظ المعادلات الرياضية كـ MathML**

في حين أن البشر يمكنهم كتابة الشيفرة بسهولة لبعض تنسيقات المعادلات مثل LaTeX، فإنهم يواجهون صعوبة في كتابة شيفرة MathML لأن الأخير يُقصد به أن يُولد تلقائيًا بواسطة التطبيقات. البرامج تقرأ وتُحلل MathML بسهولة لأن شيفرته مكتوبة بـ XML، لذا يُستخدم MathML عادةً كتنسيق إخراج وطباعة في العديد من المجالات. 

هذا المثال يوضح لك كيفية تصدير معادلة رياضية من عرض تقديمي إلى MathML:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 500.0f, 50.0f);
auto mathPortion = System::ExplicitCast<IMathPortion>(autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0));
auto mathParagraph = mathPortion->get_MathParagraph();

mathParagraph->Add(System::MakeObject<MathematicalText>(u"a")
        - >SetSuperscript(u"2")
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"b")
                - >SetSuperscript(u"2"))
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"c")
                - >SetSuperscript(u"2")));

SharedPtr<Stream> stream = System::MakeObject<FileStream>(u"mathml.xml", FileMode::Create);

mathParagraph->WriteAsMathMl(stream);
```

## **الأسئلة الشائعة**

**ما الذي يتم تصديره بالضبط إلى MathML—فقرة أم كتلة صيغة منفردة؟**

يمكنك تصدير إما فقرة رياضية كاملة ([MathParagraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/mathparagraph/)) أو كتلة منفردة ([MathBlock](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/mathblock/)) إلى MathML. كلا النوعين يوفران طريقة للكتابة إلى MathML.

**كيف يمكنني معرفة أن كائنًا على الشريحة هو صيغة رياضية وليس نصًا عاديًا أو صورة؟**

الصيغة توجد داخل [MathPortion](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/mathportion/) وتحتوي على [MathParagraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/mathparagraph/). الصور وأقسام النص العادية التي لا تحتوي على [MathParagraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/mathparagraph/) ليست صيغًا قابلة للتصدير.

**من أين يأتي MathML في العرض التقديمي—هل هو خاص بـ PowerPoint أم معيار؟**

هدف التصدير هو MathML القياسي (XML). تستخدم Aspose MathML العرضي—الجزء الفرعي من المعيار الذي يُستخدم على نطاق واسع عبر التطبيقات والويب.

**هل يتم دعم تصدير الصيغ داخل الجداول، SmartArt، المجموعات، إلخ؟**

نعم، إذا كانت تلك الكائنات تحتوي على أقسام نصية بها [MathParagraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/mathparagraph/) (أي صيغ PowerPoint حقيقية)، فسيتم تصديرها. إذا كانت الصيغة مدمجة كصورة، فلن يتم تصديرها.

**هل يؤدي تصدير إلى MathML إلى تعديل العرض التقديمي الأصلي؟**

لا. كتابة MathML هي عملية تسلسل لمحتوى الصيغة؛ لا تُعدِّل ملف العرض التقديمي.