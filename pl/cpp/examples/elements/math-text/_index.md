---
title: Tekst matematyczny
type: docs
weight: 160
url: /pl/cpp/examples/elements/math-text/
keywords:
- przykład kodu
- tekst matematyczny
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Poznaj przykłady MathematicalText w Aspose.Slides for C++: twórz i formatuj równania, ułamki, macierze oraz symbole przy użyciu C++ w prezentacjach PPT, PPTX i ODP."
---
Ten artykuł demonstruje pracę z kształtami tekstu matematycznego oraz formatowanie równań przy użyciu **Aspose.Slides for C++**.

## **Dodaj tekst matematyczny**
Utwórz kształt matematyczny zawierający ułamek i wzór Pitagorasa.

```cpp
static void AddMathText()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Dodaj kształt Math do slajdu.
    auto mathShape = slide->get_Shapes()->AddMathShape(0, 0, 720, 150);

    // Uzyskaj dostęp do akapitu matematycznego.
    auto paragraph = mathShape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    auto mathParagraph = ExplicitCast<MathPortion>(textPortion)->get_MathParagraph();

    // Dodaj prosty ułamek: x / y.
    auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");
    mathParagraph->Add(MakeObject<MathBlock>(fraction));

    // Dodaj równanie: c² = a² + b².
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

## **Uzyskaj dostęp do tekstu matematycznego**
Zlokalizuj kształt zawierający akapit matematyczny na slajdzie.

```cpp
static void AccessMathText()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    // Znajdź pierwszy kształt, który zawiera akapit matematyczny.
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

        // Przykład: utwórz ułamek (nie dodany tutaj).
        auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");

        // Użyj mathParagraph lub fraction w razie potrzeby...
    }

    presentation->Dispose();
}
```

## **Usuń tekst matematyczny**
Usuń kształt matematyczny ze slajdu.

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

    // Usuń kształt matematyczny.
    slide->get_Shapes()->Remove(mathShape);

    presentation->Dispose();
}
```

## **Formatuj tekst matematyczny**
Ustaw właściwości czcionki dla fragmentu matematycznego.

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