---
title: Cuadro de texto
type: docs
weight: 40
url: /es/cpp/examples/elements/text-box/
keywords:
- ejemplo de código
- cuadro de texto
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Trabajar con cuadros de texto en Aspose.Slides para C++: agregar, formatear, alinear, ajustar, autofit y dar estilo al texto usando C++ para presentaciones PPT, PPTX y ODP."
---
En Aspose.Slides, un **cuadro de texto** está representado por un `AutoShape`. Prácticamente cualquier forma puede contener texto, pero un cuadro de texto típico no tiene relleno ni borde y solo muestra texto.

Esta guía explica cómo agregar, acceder y eliminar cuadros de texto mediante programación.

## **Añadir un cuadro de texto**

Un cuadro de texto es simplemente un `AutoShape` sin relleno ni borde y con algo de texto formateado. A continuación se muestra cómo crear uno:

```cpp
static void AddTextBox()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Crear una forma rectangular (por defecto llena con borde y sin texto).
    auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

    // Eliminar el relleno y el borde para que parezca un cuadro de texto típico.
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);
    textBox->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    // Establecer formato de texto.
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    // Asignar el contenido de texto real.
    textBox->get_TextFrame()->set_Text(u"Some text...");

    presentation->Dispose();
}
```

> 💡 **Nota:** Cualquier `AutoShape` que contenga un `TextFrame` no vacío puede funcionar como un cuadro de texto.

## **Acceder a los cuadros de texto por contenido**

Para encontrar todos los cuadros de texto que contengan una palabra clave específica (p. ej., "Slide"), recorre las formas y verifica su texto:

```cpp
static void AccessTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    for (auto&& shape : slide->get_Shapes())
    {
        // Sólo los AutoShapes pueden contener texto editable.
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto text = autoShape->get_TextFrame()->get_Text();
            if (text.Contains(u"Slide"))
            {
                // Haz algo con el cuadro de texto coincidente.
            }
        }
    }

    presentation->Dispose();
}
```

## **Eliminar los cuadros de texto por contenido**

Este ejemplo encuentra y elimina todos los cuadros de texto de la primera diapositiva que contienen una palabra clave específica:

```cpp
static void RemoveTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    auto shapesToRemove = MakeObject<List<SharedPtr<IShape>>>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            if (autoShape->get_TextFrame()->get_Text().Contains(u"Slide"))
            {
                shapesToRemove->Add(shape);
            }
        }
    }

    for (auto&& shape : shapesToRemove)
    {
        slide->get_Shapes()->Remove(shape);
    }

    presentation->Dispose();
}
```

> 💡 **Consejo:** Siempre crea una copia de la colección de formas antes de modificarla durante la iteración para evitar errores de modificación de la colección.