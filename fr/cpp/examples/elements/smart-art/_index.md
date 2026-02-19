---
title: SmartArt
type: docs
weight: 140
url: /fr/cpp/examples/elements/smart-art/
keywords:
- exemple de code
- SmartArt
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Travaillez avec SmartArt dans Aspose.Slides for C++ : créez, modifiez, convertissez et stylisez des diagrammes avec C++ pour les présentations PowerPoint et OpenDocument."
---
Cet article montre comment ajouter des graphiques SmartArt, y accéder, les supprimer et modifier les dispositions à l'aide de **Aspose.Slides for C++**.

## **Ajouter SmartArt**

Insérez un graphique SmartArt en utilisant l'une des dispositions intégrées.

```cpp
static void AddSmartArt()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto smartArt = slide->get_Shapes()->AddSmartArt(50, 50, 400, 300, SmartArtLayoutType::BasicProcess);

    presentation->Dispose();
}
```

## **Accéder à SmartArt**

Récupérez le premier objet SmartArt d'une diapositive.

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

## **Supprimer SmartArt**

Supprimez une forme SmartArt de la diapositive.

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

## **Modifier la disposition du SmartArt**

Mettez à jour le type de disposition d'un graphique SmartArt existant.

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