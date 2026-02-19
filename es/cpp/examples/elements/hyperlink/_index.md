---
title: Hipervínculo
type: docs
weight: 130
url: /es/cpp/examples/elements/hyperlink/
keywords:
- ejemplo de código
- hipervínculo
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Agregar y gestionar hipervínculos en Aspose.Slides for C++: enlazar texto, formas e imágenes, establecer destinos y acciones para PPT, PPTX y ODP con ejemplos en C++."
---
Este artículo muestra cómo agregar, acceder, eliminar y actualizar hipervínculos en formas usando **Aspose.Slides for C++**.

## **Agregar un hipervínculo**

Cree una forma rectangular con un hipervínculo que apunte a un sitio web externo.

```cpp
static void AddHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    presentation->Dispose();
}
```

## **Acceder a un hipervínculo**

Lea la información del hipervínculo desde la porción de texto de una forma.

```cpp
static void AccessHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    auto hyperlink = textPortion->get_PortionFormat()->get_HyperlinkClick();

    presentation->Dispose();
}
```

## **Eliminar un hipervínculo**

Elimine el hipervínculo del texto de una forma.

```cpp
static void RemoveHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://www.aspose.com"));

    textPortion->get_PortionFormat()->set_HyperlinkClick(nullptr);

    presentation->Dispose();
}
```

## **Actualizar un hipervínculo**

Cambie el destino de un hipervínculo existente. Use `HyperlinkManager` para modificar texto que ya contiene un hipervínculo, lo que imita cómo PowerPoint actualiza hipervínculos de forma segura.

```cpp
static void UpdateHyperlink()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 150, 50);
    shape->get_TextFrame()->set_Text(u"Aspose");

    auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
    auto textPortion = paragraph->get_Portion(0);
    textPortion->get_PortionFormat()->set_HyperlinkClick(MakeObject<Hyperlink>(u"https://old.example.com"));

    // Cambiar un hipervínculo dentro del texto existente debe hacerse mediante
    // HyperlinkManager en lugar de establecer la propiedad directamente.
    // Esto imita cómo PowerPoint actualiza hipervínculos de forma segura.
    textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://new.example.com");

    presentation->Dispose();
}
```