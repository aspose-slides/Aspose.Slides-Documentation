---
title: Mathematischer Text
type: docs
weight: 160
url: /de/cpp/examples/elements/math-text/
keywords:
- Codebeispiel
- Mathematischer Text
- PowerPoint
- OpenDocument
- Präsentation
- C++
- Aspose.Slides
description: "Entdecken Sie Beispiele für MathematicalText mit Aspose.Slides für C++: Erstellen und formatieren Sie Gleichungen, Brüche, Matrizen und Symbole mit C++ in PPT-, PPTX- und ODP-Präsentationen."
---
Dieser Artikel demonstriert die Arbeit mit mathematischen Textformen und die Formatierung von Gleichungen mit **Aspose.Slides for C++**.

## **Add Math Text**
Erstellen Sie eine mathematische Form, die einen Bruch und die pythagoreische Formel enthält.

```cpp
static void AddMathText()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Füge eine mathematische Form zur Folie hinzu.
    auto mathShape = slide->get_Shapes()->AddMathShape(0, 0, 720, 150);

    // Greife auf den mathematischen Absatz zu.
    auto paragraph = mathShape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    auto mathParagraph = ExplicitCast<MathPortion>(textPortion)->get_MathParagraph();

    // Füge einen einfachen Bruch hinzu: x / y.
    auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");
    mathParagraph->Add(MakeObject<MathBlock>(fraction));

    // Füge Gleichung hinzu: c² = a² + b².
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

## **Access Math Text**
Suchen Sie eine Form, die einen mathematischen Absatz auf der Folie enthält.

```cpp
static void AccessMathText()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    // Finde die erste Form, die einen mathematischen Absatz enthält.
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

        // Beispiel: erstelle einen Bruch (hier nicht hinzugefügt).
        auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");

        // Use mathParagraph or fraction as needed...
    }

    presentation->Dispose();
}
```

## **Remove Math Text**
Löschen Sie eine mathematische Form von der Folie.

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

    // Entferne die mathematische Form.
    slide->get_Shapes()->Remove(mathShape);

    presentation->Dispose();
}
```

## **Format Math Text**
Legen Sie Schriftarteigenschaften für einen mathematischen Abschnitt fest.

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