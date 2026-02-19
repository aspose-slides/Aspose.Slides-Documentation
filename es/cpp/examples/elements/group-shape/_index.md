---
title: Forma de grupo
type: docs
weight: 170
url: /es/cpp/examples/elements/group-shape/
keywords:
- ejemplo de código
- forma de grupo
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Gestiona formas agrupadas en Aspose.Slides for C++: crea, anida, alinea, reordena y aplica estilo a formas de grupo con ejemplos en C++ en presentaciones PPT, PPTX y ODP."
---
Ejemplos de creación de grupos de formas, acceso a los mismos, desagrupación y eliminación utilizando **Aspose.Slides for C++**.

## **Agregar una forma de grupo**

Cree un grupo que contenga dos formas básicas.

```cpp
static void AddGroupShape()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
    group->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 60, 0, 50, 50);

    presentation->Dispose();
}
```

## **Acceder a una forma de grupo**

Recupere la primera forma de grupo de una diapositiva.

```cpp
static void AccessGroupShape()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);

    auto firstGroup = SharedPtr<IGroupShape>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IGroupShape>(shape))
        {
            firstGroup = ExplicitCast<IGroupShape>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Eliminar una forma de grupo**

Elimine una forma de grupo de la diapositiva.

```cpp
static void RemoveGroupShape()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();

    slide->get_Shapes()->Remove(group);

    presentation->Dispose();
}
```

## **Desagrupar formas**

Mueva las formas fuera de un contenedor de grupo.

```cpp
static void UngroupShapes()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    auto rect = group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);

    // Mover la forma fuera del grupo.
    slide->get_Shapes()->AddClone(rect);
    group->get_Shapes()->Remove(rect);

    presentation->Dispose();
}
```