---
title: En-tête et pied de page
type: docs
weight: 220
url: /fr/cpp/examples/elements/header-footer/
keywords:
- exemple de code
- en-tête
- pied de page
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Contrôlez les en-têtes et pieds de page des diapositives avec Aspose.Slides for C++: ajoutez des dates, numéros de diapositive et texte personnalisé dans PPT, PPTX et ODP avec des exemples C++."
---
Cet article montre comment ajouter des pieds de page et mettre à jour les espaces reserves de date et d'heure en utilisant **Aspose.Slides for C++**.

## **Add a Footer**
Ajouter un pied de page

Ajouter du texte dans la zone de pied de page d'une diapositive et le rendre visible.

```cpp
static void AddHeaderFooter()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetFooterText(u"My footer");
    slide->get_HeaderFooterManager()->SetFooterVisibility(true);

    presentation->Dispose();
}
```

## **Update Date and Time**
Mettre a jour la date et l'heure

Modifier l'espace reserve de date et d'heure d'une diapositive.

```cpp
static void UpdateDateTime()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetDateTimeText(u"01/01/2024");
    slide->get_HeaderFooterManager()->SetDateTimeVisibility(true);

    presentation->Dispose();
}
```