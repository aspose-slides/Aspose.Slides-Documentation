---
title: تصدير المعادلات الرياضية
type: docs
weight: 30
url: /cpp/exporting-math-equations/

---

# تصدير المعادلات الرياضية من العروض التقديمية

يسمح لك Aspose.Slides لـ C++ بتصدير المعادلات الرياضية من العروض التقديمية. على سبيل المثال، قد تحتاج إلى استخراج المعادلات الرياضية الموجودة في الشرائح (من عرض تقديمي معين) واستخدامها في برنامج أو منصة أخرى.

{{% alert color="primary" %}} 

يمكنك تصدير المعادلات إلى MathML، وهو تنسيق أو معيار شائع للمعادلات الرياضية ومحتوى مشابه يُرى على الويب وفي العديد من التطبيقات.

{{% /alert %}}

بينما يمكن للبشر بسهولة كتابة الشيفرة لبعض تنسيقات المعادلات مثل LaTeX، فإنهم يواجهون صعوبة في كتابة الشيفرة لـ MathML لأن الأخيرة مصممة ليتم إنشاؤها تلقائيًا بواسطة التطبيقات. تقرأ البرامج وتتحلل MathML بسهولة لأن شيفرتها مكتوبة بصيغة XML، لذا يتم استخدام MathML عادةً كتنسيق إخراج وطباعة في العديد من المجالات.

تظهر لك هذه الشيفرة النموذجية كيفية تصدير معادلة رياضية من عرض تقديمي إلى MathML:

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