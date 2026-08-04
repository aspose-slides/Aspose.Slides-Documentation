---
title: تصدير المعادلات الرياضية من العروض التقديمية بلغة C++
linktitle: تصدير المعادلات
type: docs
weight: 30
url: /ar/cpp/exporting-math-equations/
keywords:
- تصدير المعادلات الرياضية
- تصدير المعادلات إلى LaTeX
- PowerPoint إلى LaTeX
- MathML
- LaTeX
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تصدير المعادلات الرياضية من عروض PowerPoint التقديمية إلى LaTeX أو MathML مباشرةً باستخدام Aspose.Slides للغة C++."
---
## **مقدمة**

تمكنك Aspose.Slides for C++ من تصدير المعادلات الرياضية من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج المعادلات الرياضية على الشرائح (من عرض تقديمي محدد) واستخدامها في برنامج أو منصة أخرى. 

{{% alert color="primary" %}} 
يمكنك تصدير المعادلات مباشرة إلى LaTeX أو إلى MathML، وهو معيار شائع للمحتوى الرياضي يُستخدم على الويب وفي العديد من التطبيقات.
{{% /alert %}}

## **تصدير معادلات الرياضيات إلى LaTeX**

يمكن لـ Aspose.Slides تحويل معادلة رياضية في PowerPoint مباشرة إلى LaTeX؛ لا يلزم وجود ملف MathML وسيط أو محول خارجي. تُخزن المعادلة الرياضية في إطار نصي كـ [IMathPortion](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/imathportion/). استخدم [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/) للحصول على [IMathParagraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/imathparagraph/)، ثم استدعِ [IMathParagraph::ToLatex](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/imathparagraph/tolatex/). تُعيد الطريقة سلسلة يمكنك حفظها أو عرضها أو إرسالها إلى تطبيق آخر أو معالجتها أكثر.

المثال التالي يفحص كل إطار نص على كل شريحة، يجد جميع أجزاء الرياضيات، ويكتب كل معادلة في ملف `.tex` منفصل:

```cpp
auto presentation = MakeObject<Presentation>(u"equations.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    int slideNumber = slideIndex + 1;
    int equationNumber = 1;
    auto textFrames = SlideUtil::GetAllTextBoxes(slide);

    for (const auto&& textFrame : textFrames)
    {
        for (const auto&& paragraph : textFrame->get_Paragraphs())
        {
            for (const auto&& portion : paragraph->get_Portions())
            {
                auto mathPortion = System::AsCast<IMathPortion>(portion);
                if (mathPortion == nullptr)
                    continue;

                auto mathParagraph = mathPortion->get_MathParagraph();
                auto latexPath = String::Format(u"slide_{0}_equation_{1}.tex", slideNumber, equationNumber);

                auto latexText = mathParagraph->ToLatex();
                File::WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}

presentation->Dispose();
```

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/ar/cpp/aspose.slides.util/slideutil/getalltextboxes/) يُرجع جميع إطارات النص الموجودة على الشريحة. فحص النوع [IMathPortion](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/imathportion/) يفصل المعادلات القابلة للتحرير الحقيقية عن النص العادي والصور.

محركات LaTeX وقوالب المستندات لا تدعم جميعها نفس الأوامر أو الحزم أو أحرف Unicode. اختبر السلسلة المعادة مع محرك LaTeX الذي يستخدمه تطبيقك. إذا كان هناك رمز أو عنصر Office Math لا يمتلك تمثيلاً مناسبًا في ذلك البيئة، استبدله في السلسلة بأمر خاص بالمشروع أو تخطَ المعادلة وسجِّل المشكلة للمراجعة.

## **حفظ معادلات الرياضيات كـ MathML**

بينما يكتب البشر بسهولة الكود لبعض صيغ المعادلات مثل LaTeX، يواجهون صعوبة في كتابة كود MathML لأن الأخير يُقصد به أن يُولَّد تلقائيًا بواسطة التطبيقات. تقرأ البرامج وت解析 MathML بسهولة لأن كوده بصيغة XML، لذلك يُستخدم MathML عادةً كتنسيق إخراج وطباعة في العديد من المجالات. 

يعرض هذا الكود النموذجي كيفية تصدير معادلة رياضية من عرض تقديمي إلى MathML:

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

**ما الذي يتم تصديره بالضبط إلى MathML—فقرة أم كتلة صيغة فردية؟**

يمكنك تصدير إما فقرة رياضية كاملة ([MathParagraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/mathparagraph/)) أو كتلة صيغة فردية ([MathBlock](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/mathblock/)) إلى MathML. كلا النوعين يقدمان طريقة للكتابة إلى MathML.

**كيف يمكنني معرفة أن كائنًا على الشريحة هو صيغة رياضية وليس نصًا عاديًا أو صورة؟**

الصيغة توجد في [MathPortion](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/mathportion/) وتحتوي على [MathParagraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/mathparagraph/). الصور وأجزاء النص العادية التي لا تملك [MathParagraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/mathparagraph/) ليست صيغًا قابلة للتصدير.

**من أين يأتي MathML في العرض التقديمي—هل هو خاص بـ PowerPoint أم معيار؟**

يستهدف التصدير MathML القياسي (XML). تستخدم Aspose تنسيق Presentation MathML—الجزء التقديمي من المعيار—الذي يُستَخدَم على نطاق واسع عبر التطبيقات والويب.

**هل يدعم تصدير الصيغ داخل الجداول أو SmartArt أو المجموعات وما إلى ذلك؟**

نعم، إذا كانت تلك الكائنات تحتوي على أجزاء نصية مع [MathParagraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/mathparagraph/) (أي صيغ PowerPoint حقيقية)، فسيتم تصديرها. إذا كانت الصيغة مدمجة كصورة، فإنها لا تُصدر.

**هل تعديل التصدير إلى MathML يغيّر العرض التقديمي الأصلي؟**

لا. كتابة MathML هي تسلسل للبيانات الخاصة بالصيغ؛ ولا تُعدِّل ملف العرض التقديمي.