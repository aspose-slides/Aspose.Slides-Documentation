---
title: Tinta
type: docs
weight: 180
url: /es/cpp/examples/elements/ink/
keywords:
- ejemplo de código
- tinta
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Trabaja con Tinta en Aspose.Slides for C++: dibuja, importa y edita trazos, ajusta el color y el grosor, y exporta a PPT, PPTX y ODP mediante ejemplos en C++."
---
Este artículo ofrece ejemplos de cómo acceder a formas de tinta existentes y eliminarlas usando **Aspose.Slides for C++**.

> ❗ **Nota:** Las formas de tinta representan la entrada del usuario proveniente de dispositivos especializados. Aspose.Slides no puede crear nuevos trazos de tinta de forma programática, pero puedes leer y modificar la tinta existente.

## **Acceso a la tinta**

Lee las etiquetas de la primera forma de tinta en una diapositiva.

```cpp
static void AccessInk()
{
    auto presentation = MakeObject<Presentation>(u"ink.pptx");
    auto slide = presentation->get_Slide(0);

    auto shape = slide->get_Shape(0);
    if (ObjectExt::Is<IInk>(shape))
    {
        auto inkShape = ExplicitCast<IInk>(shape);
        auto tags = inkShape->get_CustomData()->get_Tags();
        if (tags->get_Count() > 0)
        {
            auto tagName = tags->GetNameByIndex(0);
            // Usa tagName según sea necesario.
        }
    }

    presentation->Dispose();
}
```

## **Eliminar tinta**

Elimina una forma de tinta de la diapositiva si existe.

```cpp
static void RemoveInk()
{
    auto presentation = MakeObject<Presentation>(u"ink.pptx");
    auto slide = presentation->get_Slide(0);

    auto ink = SharedPtr<IInk>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IInk>(shape))
        {
            ink = ExplicitCast<IInk>(shape);
            break;
        }
    }
    if (ink != nullptr)
    {
        slide->get_Shapes()->Remove(ink);
    }

    presentation->Dispose();
}
```