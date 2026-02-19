---
title: SmartArt
type: docs
weight: 140
url: /es/cpp/examples/elements/smart-art/
keywords:
- ejemplo de código
- SmartArt
- PowerPoint
- OpenDocument
- presentación
- C++
- Aspose.Slides
description: "Trabaje con SmartArt en Aspose.Slides for C++: cree, edite, convierta y diseñe diagramas con C++ para presentaciones de PowerPoint y OpenDocument."
---
Este artículo muestra cómo agregar gráficos SmartArt, acceder a ellos, eliminarlos y cambiar los diseños usando **Aspose.Slides for C++**.

## **Agregar SmartArt**

Inserte un gráfico SmartArt utilizando uno de los diseños incorporados.

```cpp
static void AddSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    presentation->Dispose();
}
```

## **Acceder a SmartArt**

Recupere el primer objeto SmartArt en una diapositiva.

```cpp
static void AccessSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    auto firstSmartArt = SharedPtr<ISmartArt>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<ISmartArt>(shape))
        {
            firstSmartArt = ExplicitCast<ISmartArt>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Eliminar SmartArt**

Elimine una forma SmartArt de la diapositiva.

```cpp
static void RemoveSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    slide->get_Shapes()->Remove(smartArt);

    presentation->Dispose();
}
```

## **Cambiar el diseño de SmartArt**

Actualice el tipo de diseño de un gráfico SmartArt existente.

```cpp
static void ChangeSmartArtLayout()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicBlockList);
    smartArt->set_Layout(SmartArtLayoutType::VerticalPictureList);

    presentation->Dispose();
}
```