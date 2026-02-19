---
title: Encre
type: docs
weight: 180
url: /fr/cpp/examples/elements/ink/
keywords:
- exemple de code
- encre
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Travaillez avec l'encre dans Aspose.Slides for C++ : dessinez, importez et modifiez les traits, ajustez la couleur et la largeur, et exportez vers PPT, PPTX et ODP à l'aide d'exemples C++."
---
Cet article fournit des exemples d'accès aux formes d'encre existantes et de leur suppression à l'aide de **Aspose.Slides for C++**.

> ❗ **Note:** Les formes d'encre représentent les entrées utilisateur provenant d'appareils spécialisés. Aspose.Slides ne peut pas créer de nouveaux traits d'encre de manière programmatique, mais vous pouvez lire et modifier les encres existantes.

## **Accéder à l'encre**

Lisez les balises de la première forme d'encre sur une diapositive.

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
            // Utilisez tagName selon les besoins.
        }
    }

    presentation->Dispose();
}
```

## **Supprimer l'encre**

Supprimez une forme d'encre de la diapositive si elle existe.

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