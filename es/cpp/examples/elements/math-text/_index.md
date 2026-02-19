---
title: Texto matemático
type: docs
weight: 160
url: /es/cpp/examples/elements/math-text/
keywords:
- ejemplo de código
- texto matemático
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Explore los ejemplos de MathematicalText de Aspose.Slides for C++: cree y formatee ecuaciones, fracciones, matrices y símbolos con C++ en presentaciones PPT, PPTX y ODP."
---
Este artículo muestra cómo trabajar con formas de texto matemático y formatear ecuaciones usando **Aspose.Slides for C++**.

## **Agregar texto matemático**

Cree una forma matemática que contenga una fracción y la fórmula pitagórica.

```cpp
static void AddMathText()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Agregar una forma matemática a la diapositiva.
    auto mathShape = slide->get_Shapes()->AddMathShape(0, 0, 720, 150);

    // Acceder al párrafo matemático.
    auto paragraph = mathShape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    auto mathParagraph = ExplicitCast<MathPortion>(textPortion)->get_MathParagraph();

    // Agregar una fracción simple: x / y.
    auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");
    mathParagraph->Add(MakeObject<MathBlock>(fraction));

    // Agregar ecuación: c² = a² + b².
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

## **Acceder al texto matemático**

Ubique una forma que contenga un párrafo de matemáticas en la diapositiva.

```cpp
static void AccessMathText()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    // Encontrar la primera forma que contiene un párrafo matemático.
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

        // Ejemplo: crear una fracción (no añadida aquí).
        auto fraction = MakeObject<MathematicalText>(u"x")->Divide(u"y");

        // Utilizar mathParagraph o fraction según sea necesario...
    }

    presentation->Dispose();
}
```

## **Eliminar texto matemático**

Elimine una forma matemática de la diapositiva.

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

    // Eliminar la forma matemática.
    slide->get_Shapes()->Remove(mathShape);

    presentation->Dispose();
}
```

## **Formatear texto matemático**

Establezca las propiedades de fuente para una porción matemática.

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