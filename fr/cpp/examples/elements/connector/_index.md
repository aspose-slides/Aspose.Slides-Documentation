---
title: Connecteur
type: docs
weight: 190
url: /fr/cpp/examples/elements/connector/
keywords:
- exemple de code
- Connector
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Apprenez comment ajouter, acheminer et styliser des connecteurs entre des formes à l'aide d'Aspose.Slides pour C++, avec des exemples pour les présentations PPT, PPTX et ODP."
---
Cet article montre comment connecter des formes avec des connecteurs et modifier leurs cibles en utilisant **Aspose.Slides for C++**.

## **Ajouter un connecteur**

Insérez une forme de connecteur entre deux points sur la diapositive.

```cpp
static void AddConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto connector = slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);
    presentation->Dispose();
}
```

## **Accéder à un connecteur**

Récupérez la première forme de connecteur ajoutée à une diapositive.

```cpp
static void AccessConnector()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_Shapes()->AddConnector(ShapeType::BentConnector2, 0, 0, 100, 100);

    // Accéder au premier connecteur sur la diapositive.
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

## **Supprimer un connecteur**

Supprimez un connecteur de la diapositive.

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

## **Reconnecter les formes**

Attachez un connecteur à deux formes en assignant les cibles de départ et d'arrivée.

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