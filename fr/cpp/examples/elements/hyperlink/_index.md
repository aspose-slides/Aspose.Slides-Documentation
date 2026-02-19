---
title: Hyperlien
type: docs
weight: 130
url: /fr/cpp/examples/elements/hyperlink/
keywords:
- exemple de code
- hyperlien
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Ajouter et gérer les hyperliens dans Aspose.Slides for C++: texte du lien, formes et images, définir les cibles et les actions pour PPT, PPTX et ODP avec des exemples en C++."
---
Cet article montre comment ajouter, accéder, supprimer et mettre à jour des hyperliens sur des formes à l'aide de **Aspose.Slides for C++**.

## **Ajouter un hyperlien**

Créer une forme rectangulaire avec un hyperlien pointant vers un site Web externe.

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

## **Accéder à un hyperlien**

Lire les informations de l'hyperlien à partir de la partie texte d'une forme.

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

## **Supprimer un hyperlien**

Supprimer l'hyperlien du texte d'une forme.

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

## **Mettre à jour un hyperlien**

Modifier la cible d'un hyperlien existant. Utilisez `HyperlinkManager` pour modifier le texte contenant déjà un hyperlien, ce qui reproduit la façon dont PowerPoint met à jour les hyperliens en toute sécurité.

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

    // Modifier un hyperlien dans du texte existant doit être fait via
    // HyperlinkManager plutôt que de définir la propriété directement.
    // Cela reproduit la façon dont PowerPoint met à jour les hyperliens en toute sécurité.
    textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://new.example.com");

    presentation->Dispose();
}
```