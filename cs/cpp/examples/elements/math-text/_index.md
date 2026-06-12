---
title: Matematický text
type: docs
weight: 160
url: /cs/cpp/examples/elements/math-text/
keywords:
- příklad kódu
- matematický text
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Prozkoumejte příklady MathematicalText v Aspose.Slides pro C++: vytvářejte a formátujte rovnice, zlomky, matice a symboly v C++ v prezentacích PPT, PPTX a ODP."
---
Tento článek demonstruje práci s matematickými textovými tvary a formátování rovnic pomocí **Aspose.Slides for C++**.

## **Přidat matematický text**

Vytvořte matematický tvar obsahující zlomek a pythagorovu větu.

```cpp
static void AddMathText()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Přidat matematický tvar do snímku.
    auto mathShape = slide->get_Shapes()->AddMathShape(0, 0, 720, 150);

    // Přístup k matematickému odstavci.
    auto paragraph = mathShape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    auto mathParagraph = ExplicitCast<MathPortion>(textPortion)->get_MathParagraph();

    // Přidat jednoduchý zlomek: x / y.
    auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");
    mathParagraph->Add(MakeObject<MathBlock>(fraction));

    // Přidat rovnici: c² = a² + b².
    auto mathBlock = MakeObject<MathematicalText>(u"c")
        - >SetSuperscript(u"2")
        - >Join(u"=")
        - >Join(MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
        - >Join(u"+")
        - >Join(MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));
    mathParagraph->Add(mathBlock);

    presentation->Dispose();
}
```

## **Přístup k matematickému textu**

Najděte tvar, který obsahuje matematický odstavec na snímku.

```cpp
static void AccessMathText()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    // Najít první tvar, který obsahuje matematický odstavec.
    auto mathShape = SharedPtr<IAutoShape>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto textFrame = autoShape->get_TextFrame();
            auto hasMath = false;
            for (auto&& paragraph : textFrame->get_Paragraphs())
            {
                for (auto&& textPortion : paragraph->get_Portions())
                {
                    if (ObjectExt::Is<MathPortion>(textPortion))
                    {
                        hasMath = true;
                        break;
                    }
                }
                if (hasMath) break;
            }
            if (hasMath)
            {
                mathShape = autoShape;
                break;
            }
        }
    }

    if (mathShape != nullptr)
    {
        auto paragraph = mathShape->get_TextFrame()->get_Paragraph(0);
        auto textPortion = paragraph->get_Portion(0);
        auto mathParagraph = ExplicitCast<MathPortion>(textPortion)->get_MathParagraph();

        // Příklad: vytvořit zlomek (není zde přidán).
        auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");

        // Použijte mathParagraph nebo fraction podle potřeby...
    }

    presentation->Dispose();
}
```

## **Odstranit matematický text**

Smažte matematický tvar ze snímku.

```cpp
static void RemoveMathText()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto mathShape = slide->get_Shapes()->AddMathShape(50, 50, 100, 50);

    auto paragraph = mathShape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    auto mathParagraph = ExplicitCast<MathPortion>(textPortion)->get_MathParagraph();
    auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");
    mathParagraph->Add(MakeObject<MathBlock>(fraction));

    // Odstranit matematický tvar.
    slide->get_Shapes()->Remove(mathShape);

    presentation->Dispose();
}
```

## **Formátovat matematický text**

Nastavte vlastnosti písma pro matematickou část.

```cpp
static void FormatMathText()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto mathShape = slide->get_Shapes()->AddMathShape(50, 50, 100, 50);
    auto paragraph = mathShape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    auto mathParagraph = ExplicitCast<MathPortion>(textPortion)->get_MathParagraph();
    auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");
    mathParagraph->Add(MakeObject<MathBlock>(fraction));

    textPortion->get_PortionFormat()->set_FontHeight(20);

    presentation->Dispose();
}
```