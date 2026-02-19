---
title: Conector
type: docs
weight: 190
url: /es/cpp/examples/elements/connector/
keywords:
- ejemplo de código
- Conector
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Aprenda cómo añadir, enrutar y dar estilo a los conectores entre formas usando Aspose.Slides for C++, con ejemplos para presentaciones PPT, PPTX y ODP."
---
Este artículo muestra cómo conectar formas con conectores y cambiar sus destinos usando **Aspose.Slides for C++**.

## **Agregar un conector**

Inserte una forma de conector entre dos puntos en la diapositiva.

```cpp
static void AddConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);
    presentation->Dispose();
}
```

## **Acceder a un conector**

Recupere la primera forma de conector añadida a una diapositiva.

```cpp
static void AccessConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    // Accede al primer conector de la diapositiva.
    auto connector = SharedPtr<IConnector>();
    for (auto&& shape :  slide->get_Shapes())
    {
        if (ObjectExt::Is<IConnector>(shape))
        {
            connector = ExplicitCast<IConnector>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Eliminar un conector**

Elimine un conector de la diapositiva.

```cpp
static void RemoveConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    slide->get_Shapes()->Remove(connector);

    presentation->Dispose();
}
```

## **Reconectar formas**

Adjunte un conector a dos formas asignando los destinos de inicio y fin.

```cpp
static void ReconnectShapes()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);
    auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 50, 50);
    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    connector->set_StartShapeConnectedTo(shape1);
    connector->set_EndShapeConnectedTo(shape2);

    presentation->Dispose();
}
```