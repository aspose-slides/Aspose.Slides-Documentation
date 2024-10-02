---
title: Экспорт математических уравнений
type: docs
weight: 30
url: /ru/cpp/exporting-math-equations/

---

# Экспорт математических уравнений из презентаций

Aspose.Slides для C++ позволяет экспортировать математические уравнения из презентаций. Например, вам может потребоваться извлечь математические уравнения со слайдов (из конкретной презентации) и использовать их в другой программе или на другой платформе.

{{% alert color="primary" %}}

Вы можете экспортировать уравнения в MathML, популярный формат или стандарт для математических уравнений и аналогичного контента, который встречается в интернете и во многих приложениях.

{{% /alert %}}

Хотя люди легко пишут код для некоторых форматов уравнений, таких как LaTeX, им трудно написать код для MathML, потому что последний предназначен для автоматической генерации приложениями. Программы легко читают и разбирают MathML, потому что его код написан в XML, поэтому MathML часто используется как формат вывода и печати во многих областях.

Этот пример кода показывает, как экспортировать математическое уравнение из презентации в MathML:

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