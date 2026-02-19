---
title: Zone de texte
type: docs
weight: 40
url: /fr/cpp/examples/elements/text-box/
keywords:
- exemple de code
- zone de texte
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Travaillez avec les zones de texte dans Aspose.Slides pour C++ : ajoutez, formatez, alignez, enroulez, ajustez automatiquement et stylisez le texte en C++ pour les présentations PPT, PPTX et ODP."
---
Dans Aspose.Slides, une **zone de texte** est représentée par un `AutoShape`. Pratiquement toutes les formes peuvent contenir du texte, mais une zone de texte typique n’a pas de remplissage ni de bordure et n’affiche que du texte.

Ce guide explique comment ajouter, accéder et supprimer des zones de texte par programme.

## **Ajouter une zone de texte**

Une zone de texte est simplement un `AutoShape` sans remplissage ni bordure et contenant du texte formaté. Voici comment en créer une :

```cpp
static void AddTextBox()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Créer une forme rectangulaire (remplie par défaut avec une bordure et aucun texte).
    auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 75, 150, 100);

    // Supprimer le remplissage et la bordure pour qu'elle ressemble à une zone de texte typique.
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);
    textBox->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

    // Définir le format du texte.
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());

    // Attribuer le contenu réel du texte.
    textBox->get_TextFrame()->set_Text(u"Some text...");

    presentation->Dispose();
}
```

> 💡 **Remarque :** Tout `AutoShape` contenant un `TextFrame` non vide peut fonctionner comme une zone de texte.

## **Accéder aux zones de texte par leur contenu**

Pour trouver toutes les zones de texte contenant un mot‑clé spécifique (par ex. « Slide »), parcourez les formes et vérifiez leur texte :

```cpp
static void AccessTextBox()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");
    auto slide = presentation->get_Slide(0);

    for (auto&& shape : slide->get_Shapes())
    {
        // Seuls les AutoShapes peuvent contenir du texte modifiable.
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            auto text = autoShape->get_TextFrame()->get_Text();
            if (text.Contains(u"Slide"))
            {
                // Faire quelque chose avec la zone de texte correspondante.
            }
        }
    }

    presentation->Dispose();
}
```

## **Supprimer les zones de texte par leur contenu**

Cet exemple trouve et supprime toutes les zones de texte de la première diapositive qui contiennent un mot‑clé spécifique :

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

> 💡 **Conseil :** Créez toujours une copie de la collection de formes avant de la modifier pendant l’itération afin d’éviter les erreurs de modification de collection.