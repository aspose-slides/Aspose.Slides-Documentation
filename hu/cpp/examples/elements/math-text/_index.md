---
title: Matematikai szöveg
type: docs
weight: 160
url: /hu/cpp/examples/elements/math-text/
keywords:
- kód példa
- matematikai szöveg
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Fedezze fel az Aspose.Slides for C++ MathematicalText példákat: egyenletek, törtek, mátrixok és szimbólumok létrehozása és formázása C++-val PPT, PPTX és ODP prezentációkban."
---
Ez a cikk bemutatja a matematikai szöveges alakzatok használatát és az egyenletek formázását a **Aspose.Slides for C++** segítségével.

## **Matematikai szöveg hozzáadása**

Hozzon létre egy matematikai alakzatot, amely tartalmaz egy törtet és a Pitagorasz-formulát.

```cpp
static void AddMathText()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Adj hozzá egy Math alakzatot a diához.
    auto mathShape = slide->get_Shapes()->AddMathShape(0, 0, 720, 150);

    // A matematikai bekezdés elérése.
    auto paragraph = mathShape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    auto mathParagraph = ExplicitCast<MathPortion>(textPortion)->get_MathParagraph();

    // Adj hozzá egy egyszerű törtet: x / y.
    auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");
    mathParagraph->Add(MakeObject<MathBlock>(fraction));

    // Adj hozzá egy egyenletet: c² = a² + b².
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

## **Matematikai szöveg elérése**

Keresse meg azt az alakzatot, amely a dián matematikai bekezdést tartalmaz.

```cpp
static void AccessMathText()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    // Keresse meg az első alakzatot, amely matematikai bekezdést tartalmaz.
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

        // Példa: hozzon létre egy törtet (itt nem lett hozzáadva).
        auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");

        // Használja a mathParagraph-et vagy a fraction-t szükség szerint...
    }

    presentation->Dispose();
}
```

## **Matematikai szöveg eltávolítása**

Törölje a matematikai alakzatot a diáról.

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

    // Távolítsa el a matematikai alakzatot.
    slide->get_Shapes()->Remove(mathShape);

    presentation->Dispose();
}
```

## **Matematikai szöveg formázása**

Állítsa be a betűtípus tulajdonságait egy matematikai részhez.

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