---
title: Matematisk text
type: docs
weight: 160
url: /sv/cpp/examples/elements/math-text/
keywords:
- kodexempel
- matematisk text
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Utforska Aspose.Slides för C++-exempel på MathematicalText: skapa och formatera ekvationer, bråk, matriser och symboler med C++ i PPT-, PPTX- och ODP-presentationer."
---
Den här artikeln visar hur du arbetar med matematiska textformer och formaterar ekvationer med **Aspose.Slides för C++**.

## **Lägg till matematiktext**

Skapa en matematikform som innehåller en bråkdel och Pythagoras formel.

```cpp
static void AddMathText()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Lägg till en matematikform på bilden.
    auto mathShape = slide->get_Shapes()->AddMathShape(0, 0, 720, 150);

    // Åtkomst till det matematiska stycket.
    auto paragraph = mathShape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    auto mathParagraph = ExplicitCast<MathPortion>(textPortion)->get_MathParagraph();

    // Lägg till ett enkelt bråk: x / y.
    auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");
    mathParagraph->Add(MakeObject<MathBlock>(fraction));

    // Lägg till ekvation: c² = a² + b².
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

## **Åtkomst till matematiktext**

Lokalisera en form som innehåller ett matematikstycke på bilden.

```cpp
static void AccessMathText()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    // Hitta den första formen som innehåller ett matematiskt stycke.
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

        // Exempel: skapa ett bråk (ej tillagt här).
        auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");

        // Använd mathParagraph eller fraction vid behov...
    }

    presentation->Dispose();
}
```

## **Ta bort matematiktext**

Ta bort en matematikform från bilden.

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

    // Ta bort den matematiska formen.
    slide->get_Shapes()->Remove(mathShape);

    presentation->Dispose();
}
```

## **Formatera matematiktext**

Ange teckensnittsegenskaper för en matematisk del.

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