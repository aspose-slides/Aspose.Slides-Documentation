---
title: Wiskundige tekst
type: docs
weight: 160
url: /nl/cpp/examples/elements/math-text/
keywords:
- codevoorbeeld
- wiskundige tekst
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Ontdek voorbeeldcode voor Aspose.Slides voor C++ MathematicalText: maak en formatteer vergelijkingen, breuken, matrices en symbolen met C++ in PPT-, PPTX- en ODP-presentaties."
---
Dit artikel laat zien hoe u werkt met wiskundige tekstvormen en het opmaken van vergelijkingen met behulp van **Aspose.Slides for C++**.

## **Wiskundige tekst toevoegen**

Maak een wiskundige vorm die een breuk en de pythagorasformule bevat.

```cpp
static void AddMathText()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Voeg een wiskundige vorm toe aan de dia.
    auto mathShape = slide->get_Shapes()->AddMathShape(0, 0, 720, 150);

    // Benader de wiskundige alinea.
    auto paragraph = mathShape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    auto mathParagraph = ExplicitCast<MathPortion>(textPortion)->get_MathParagraph();

    // Voeg een eenvoudige breuk toe: x / y.
    auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");
    mathParagraph->Add(MakeObject<MathBlock>(fraction));

    // Voeg een vergelijking toe: c² = a² + b².
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

## **Wiskundige tekst benaderen**

Zoek een vorm die een wiskundige alinea op de dia bevat.

```cpp
static void AccessMathText()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    // Zoek de eerste vorm die een wiskundige alinea bevat.
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

        // Voorbeeld: maak een breuk (hier niet toegevoegd).
        auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");

        // Gebruik mathParagraph of fraction indien nodig...
    }

    presentation->Dispose();
}
```

## **Wiskundige tekst verwijderen**

Verwijder een wiskundige vorm van de dia.

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

    // Verwijder de wiskundige vorm.
    slide->get_Shapes()->Remove(mathShape);

    presentation->Dispose();
}
```

## **Wiskundige tekst opmaken**

Stel lettertype-eigenschappen in voor een wiskundig onderdeel.

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