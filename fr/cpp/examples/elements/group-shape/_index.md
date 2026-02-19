---
title: Forme de groupe
type: docs
weight: 170
url: /fr/cpp/examples/elements/group-shape/
keywords:
- exemple de code
- forme de groupe
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Gérez les formes groupées dans Aspose.Slides for C++ : créez, imbriquez, alignez, réorganisez et stylisez des formes de groupe avec des exemples C++ dans les présentations PPT, PPTX et ODP."
---
Exemples de création de groupes de formes, d'accès à ceux-ci, de dissociation et de suppression en utilisant **Aspose.Slides for C++**.

## **Ajouter une forme de groupe**

Créer un groupe contenant deux formes de base.

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

## **Accéder à une forme de groupe**

Récupérer la première forme de groupe d'une diapositive.

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

## **Supprimer une forme de groupe**

Supprimer une forme de groupe de la diapositive.

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

## **Dégrouper les formes**

Déplacer les formes hors d'un conteneur de groupe.

```cpp
static void UngroupShapes()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto group = slide->get_Shapes()->AddGroupShape();
    auto rect = group->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 50, 50);

    // Déplacer la forme hors du groupe.
    slide->get_Shapes()->AddClone(rect);
    group->get_Shapes()->Remove(rect);

    presentation->Dispose();
}
```