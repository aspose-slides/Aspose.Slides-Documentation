---
title: تصدير المعادلات الرياضية من العروض التقديمية في С++
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
- С++
- Aspose.Slides
description: "افتح تصديرًا سلسًا للمعادلات الرياضية من PowerPoint إلى MathML باستخدام Aspose.Slides للـ С++ — حافظ على التنسيق وعزز التوافق."
---

## **تصدير المعادلات الرياضية من العروض التقديمية**

Aspose.Slides for C++ يسمح لك بتصدير المعادلات الرياضية من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج المعادلات الرياضية الموجودة على الشرائح (من عرض تقديمي محدد) واستخدامها في برنامج أو منصة أخرى. 

{{% alert color="primary" %}} 
يمكنك تصدير المعادلات إلى MathML، وهو تنسيق أو معيار شائع للمعادلات الرياضية والمحتوى المشابه الذي يُرى على الويب وفي العديد من التطبيقات. 
{{% /alert %}}

بينما البشر يكتبون بسهولة الكود لبعض تنسيقات المعادلات مثل LaTeX، فإنهم يواجهون صعوبة في كتابة الكود الخاص بـ MathML لأن الأخير يُقصد به أن يُولد تلقائيًا بواسطة التطبيقات. البرامج تقرأ وتُحلل MathML بسهولة لأن الكود الخاص به مكتوب بصيغة XML، لذا يُستخدم MathML عادةً كتنسيق إخراج وطباعة في العديد من المجالات. 

توضح لك عينة الكود هذه كيفية تصدير معادلة رياضية من عرض تقديمي إلى MathML:
``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 500.0f, 50.0f);
auto mathPortion = System::ExplicitCast<IMathPortion>(autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0));
auto mathParagraph = mathPortion->get_MathParagraph();

mathParagraph->Add(System::MakeObject<MathematicalText>(u"a")
        ->SetSuperscript(u"2")
        ->Join(u"+")
        ->Join(System::MakeObject<MathematicalText>(u"b")
                ->SetSuperscript(u"2"))
        ->Join(u"=")
        ->Join(System::MakeObject<MathematicalText>(u"c")
                ->SetSuperscript(u"2")));

SharedPtr<Stream> stream = System::MakeObject<FileStream>(u"mathml.xml", FileMode::Create);

mathParagraph->WriteAsMathMl(stream);
```


## **الأسئلة الشائعة**

**ما الذي يتم تصديره بالضبط إلى MathML—فقرة كاملة أم كتلة معادلة فردية؟**

يمكنك تصدير إما فقرة رياضية كاملة ([MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/)) أو كتلة فردية ([MathBlock](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/)) إلى MathML. كلا النوعين يقدمان طريقة للكتابة إلى MathML.

**كيف يمكنني معرفة أن كائنًا على الشريحة هو صيغة رياضية وليس نصًا عاديًا أو صورة؟**

الصيغة توجد داخل [MathPortion](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) ولها [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/). الصور والأجزاء النصية العادية التي لا تحتوي على [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) ليست صيغًا قابلة للتصدير.

**من أين يأتي MathML في العرض التقديمي—هل هو خاص بـ PowerPoint أم معيار عام؟**

أهداف التصدير هي MathML القياسي (XML). تستخدم Aspose Presentation MathML—الجزء الفرعي من المعيار المتعلق بالعرض—وهو مستخدم على نطاق واسع عبر التطبيقات والويب.

**هل يتم دعم تصدير الصيغ داخل الجداول أو SmartArt أو المجموعات وما إلى ذلك؟**

نعم، إذا كانت تلك الكائنات تحتوي على أجزاء نصية بها [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) (أي صيغ PowerPoint حقيقية)، فسيتم تصديرها. إذا كانت الصيغة مدمجة كصورة، فلن يتم تصديرها.

**هل يؤدي تصدير إلى MathML إلى تعديل العرض التقديمي الأصلي؟**

لا. كتابة MathML هي عملية تسلسل لمحتوى الصيغة؛ ولا تُغيّر ملف العرض التقديمي.