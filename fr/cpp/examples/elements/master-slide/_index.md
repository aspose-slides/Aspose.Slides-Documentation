---
title: Diapositive maître
type: docs
weight: 30
url: /fr/cpp/examples/elements/master-slide/
keywords:
- exemple de code
- diapositive maître
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Explorez les exemples de diapositives maîtres Aspose.Slides pour C++ : créez, modifiez et stylisez les maîtres, les espaces réservés et les thèmes dans PPT, PPTX et ODP avec du code C++ clair."
---
Les diapositives maîtres constituent le niveau supérieur de la hiérarchie d'héritage des diapositives dans PowerPoint. Une **diapositive maître** définit les éléments de conception communs tels que les arrière-plans, les logos et le formatage du texte. Les **diapositives de disposition** héritent des diapositives maîtres, et les **diapositives normales** héritent des diapositives de disposition.

Cet article montre comment créer, modifier et gérer les diapositives maîtres à l'aide d'Aspose.Slides pour C++.

## **Ajouter une diapositive maître**

Cet exemple montre comment créer une nouvelle diapositive maître en clonant celle par défaut. Il ajoute ensuite une bannière avec le nom de l'entreprise à toutes les diapositives via l'héritage de la disposition.

```cpp
static void AddMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Cloner la diapositive maître par défaut.
    auto defaultMasterSlide = presentation->get_Master(0);
    auto newMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);

    // Ajouter une bannière avec le nom de l'entreprise en haut de la diapositive maître.
    auto textBox = newMasterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 720, 25);
    textBox->get_TextFrame()->set_Text(u"Company Name");
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);

    // Assigner la nouvelle diapositive maître à une diapositive de disposition.
    auto layoutSlide = presentation->get_LayoutSlide(0);
    layoutSlide->set_MasterSlide(newMasterSlide);

    // Assigner la diapositive de disposition à la première diapositive de la présentation.
    presentation->get_Slide(0)->set_LayoutSlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Note 1 :** Les diapositives maîtres offrent un moyen d'appliquer une identité visuelle cohérente ou des éléments de conception partagés à toutes les diapositives. Toute modification apportée à la maîtresse se reflétera automatiquement sur les diapositives de disposition et normales dépendantes.

> 💡 **Note 2 :** Toutes les formes ou le formatage ajoutés à une diapositive maître sont hérités par les diapositives de disposition et, à leur tour, par toutes les diapositives normales utilisant ces dispositions.  
> L'image ci-dessous illustre comment une zone de texte ajoutée sur une diapositive maître est automatiquement rendue sur la diapositive finale.

![Exemple d'héritage de maître](master-slide-banner.png)

## **Accéder à une diapositive maître**

Vous pouvez accéder aux diapositives maîtres à l'aide de la collection maîtresse de la présentation. Voici comment les récupérer et travailler avec elles :

```cpp
static void AccessMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto firstMasterSlide = presentation->get_Master(0);

    // Modifier le type d'arrière-plan.
    firstMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);

    presentation->Dispose();
}
```

## **Supprimer une diapositive maître**

Les diapositives maîtres peuvent être supprimées soit par index, soit par référence.

```cpp
static void RemoveMasterSlide()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Supprimer une diapositive maître par indice.
    presentation->get_Masters()->RemoveAt(0);

    // Supprimer une diapositive maître par référence.
    auto firstMasterSlide = presentation->get_Master(0);
    presentation->get_Masters()->Remove(firstMasterSlide);

    presentation->Dispose();
}
```

## **Supprimer les diapositives maîtres inutilisées**

Certaines présentations contiennent des diapositives maîtres qui ne sont pas utilisées. Supprimer ces diapositives peut aider à réduire la taille du fichier.

```cpp
static void RemoveUnusedMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Supprimer toutes les diapositives maîtres inutilisées (même celles marquées comme Preserve).
    presentation->get_Masters()->RemoveUnused(true);

    presentation->Dispose();
}
```