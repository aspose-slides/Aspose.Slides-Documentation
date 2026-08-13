---
title: تصدير معادلات الرياضيات من العروض التقديمية في C++
linktitle: تصدير المعادلات
type: docs
weight: 30
url: /ar/cpp/exporting-math-equations/
keywords:
- تصدير معادلات الرياضيات
- تصدير المعادلات إلى LaTeX
- PowerPoint إلى LaTeX
- MathML
- LaTeX
- PowerPoint
- عرض تقديمي
- C++
- Aspose.Slides
description: "تصدير معادلات الرياضيات من عروض PowerPoint التقديمية إلى LaTeX أو MathML مباشرةً باستخدام Aspose.Slides لـ C++."
---
## **المقدمة**

يمكّن Aspose.Slides for C++ من تصدير معادلات الرياضيات من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج المعادلات الرياضية الموجودة على الشرائح (من عرض تقديمي معين) واستخدامها في برنامج أو منصة أخرى. 

{{% alert color="info" %}} 

يمكنك تصدير المعادلات مباشرة إلى LaTeX أو إلى MathML، وهو معيار شائع للمحتوى الرياضي يُستخدم على الويب وفي العديد من التطبيقات.

{{% /alert %}}

## **تصدير معادلات الرياضيات إلى LaTeX**

يمكن لـ Aspose.Slides تحويل معادلة PowerPoint الرياضية مباشرة إلى LaTeX؛ لا يلزم ملف MathML وسيط ولا محول خارجي. تُخزن المعادلة الرياضية في إطار نصي كـ [IMathPortion](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/imathportion/). استخدم [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/) للحصول على [IMathParagraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/imathparagraph/)، ثم استدعِ [IMathParagraph::ToLatex](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/imathparagraph/tolatex/). تُعيد الطريقة سلسلة يمكنك حفظها أو عرضها أو إرسالها إلى تطبيق آخر أو معالجتها لاحقًا.

المثال التالي يتحقق من كل إطار نصي في كل شريحة، يجد جميع أجزاء الرياضيات، ويكتب كل معادلة إلى ملف `.tex` منفصل:

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

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/ar/cpp/aspose.slides.util/slideutil/getalltextboxes/) تُعيد جميع إطارات النص الموجودة في الشريحة. يتحقق الفحص من نوع [IMathPortion](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/imathportion/) من فصل المعادلات القابلة للتحرير الحقيقية عن النصوص العادية والصور.

لا تدعم جميع محركات LaTeX والقوالب المستندية نفس الأوامر أو الحزم أو أحرف Unicode. اختبر السلسلة المرجعة باستخدام محرك LaTeX الذي يستخدمه تطبيقك. إذا لم يكن للرمز أو عنصر Office Math تمثيل مناسب في تلك البيئة، استبدله في السلسلة بأمر خاص بالمشروع أو تخطَ المعادلة وسجِّل المشكلة للمراجعة.

## **حفظ معادلات الرياضيات كـ MathML**

بينما يكتب البشر بسهولة الشيفرة لبعض صيغ المعادلات مثل LaTeX، يواجهون صعوبة في كتابة الشيفرة لـ MathML لأن الأخيرة تُصمم لتُولد تلقائيًا بواسطة التطبيقات. تقرأ البرامج وتُحلل MathML بسهولة لأن شيفرتها في XML، لذا يُستخدم MathML غالبًا كصيغة إخراج وطباعة في العديد من المجالات. 

يظهر هذا الكود العيني كيفية تصدير معادلة رياضية من عرض تقديمي إلى MathML:

``` cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathBlock.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/IMathPortion.h>
#include <DOM/MathText/IMathSuperscriptElement.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::MathText;
using namespace System;
using namespace System::IO;

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

## **الأسئلة المتكررة**

**ما الذي يتم تصديره بالضبط إلى MathML—فقرة أم كتلة معادلة منفردة؟**

يمكنك تصدير إما فقرة رياضية كاملة ([MathParagraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/mathparagraph/)) أو كتلة منفردة ([MathBlock](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/mathblock/)) إلى MathML. كلا النوعين يقدمان طريقة للكتابة إلى MathML.

**كيف يمكنني التمييز بين كائن على الشريحة هو معادلة رياضية أم نص عادي أو صورة؟**

المعادلة تتواجد داخل [MathPortion](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/mathportion/) وتملك [MathParagraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/mathparagraph/). الصور وأجزاء النص العادية التي لا تحتوي على [MathParagraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/mathparagraph/) لا يمكن تصديرها كمعادلات.

**من أين يأتي MathML في العرض التقديمي—هل هو خاص بـ PowerPoint أم معيار؟**

يهدف التصدير إلى MathML القياسي (XML). تستخدم Aspose معيار Presentation MathML—الفرع التقدمي من المعيار—الذي يُستعمل على نطاق واسع في التطبيقات وعلى الويب.

**هل يتم دعم تصدير المعادلات داخل الجداول أو SmartArt أو المجموعات وغيرها؟**

نعم، إذا كانت تلك الكائنات تحتوي على أجزاء نصية مع [MathParagraph](https://reference.aspose.com/slides/ar/cpp/aspose.slides.mathtext/mathparagraph/) (أي معادلات PowerPoint حقيقية)، فسيتم تصديرها. إذا كانت المعادلة مدمجة كصورة، فلن تُصدَّر.

**هل يؤدي تصدير إلى MathML إلى تعديل العرض التقديمي الأصلي؟**

لا. كتابة MathML هي عملية تسلسل لمحتوى المعادلة؛ ولا تُعدِّل ملف العرض التقديمي.