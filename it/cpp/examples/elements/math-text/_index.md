---
title: Testo Matematico
type: docs
weight: 160
url: /it/cpp/examples/elements/math-text/
keywords:
- esempio di codice
- testo matematico
- PowerPoint
- OpenDocument
- presentazione
- C++
- Aspose.Slides
description: "Esplora gli esempi di MathematicalText di Aspose.Slides per C++: crea e formatta equazioni, frazioni, matrici e simboli con C++ in presentazioni PPT, PPTX e ODP."
---
Questo articolo dimostra come lavorare con forme di testo matematico e formattare le equazioni utilizzando **Aspose.Slides for C++**.

## **Aggiungi testo matematico**

Crea una forma matematica contenente una frazione e la formula di Pitagora.

```cpp
static void AddMathText()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Aggiungi una forma Math alla diapositiva.
    auto mathShape = slide->get_Shapes()->AddMathShape(0, 0, 720, 150);

    // Accedi al paragrafo math.
    auto paragraph = mathShape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    auto mathParagraph = ExplicitCast<MathPortion>(textPortion)->get_MathParagraph();

    // Aggiungi una frazione semplice: x / y.
    auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");
    mathParagraph->Add(MakeObject<MathBlock>(fraction));

    // Aggiungi equazione: c² = a² + b².
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

## **Accedi al testo matematico**

Individua una forma che contiene un paragrafo matematico nella diapositiva.

```cpp
static void AccessMathText()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    // Trova la prima forma che contiene un paragrafo matematico.
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

        // Esempio: crea una frazione (non aggiunta qui).
        auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");

        // Usa mathParagraph o fraction secondo necessità...
    }

    presentation->Dispose();
}
```

## **Rimuovi testo matematico**

Elimina una forma matematica dalla diapositiva.

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

    // Rimuovi la forma matematica.
    slide->get_Shapes()->Remove(mathShape);

    presentation->Dispose();
}
```

## **Formatta testo matematico**

Imposta le proprietà del carattere per una porzione matematica.

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