---
title: "Diapositive de mise en page"
type: docs
weight: 20
url: /fr/cpp/examples/elements/layout-slide/
keywords:
- "exemple de code"
- "diapositive de mise en page"
- PowerPoint
- OpenDocument
- "présentation"
- C++
- Aspose.Slides
description: "Maîtrisez les diapositives de mise en page dans Aspose.Slides for C++ : choisissez, appliquez et personnalisez les mises en page de diapositives, les espaces réservés et les maîtres avec des exemples C++ pour les présentations PPT, PPTX et ODP."
---
Cet article montre comment travailler avec les **diapositives de mise en page** dans Aspose.Slides for C++. Une diapositive de mise en page définit la conception et le formatage hérités par les diapositives normales. Vous pouvez ajouter, accéder, cloner et supprimer des diapositives de mise en page, ainsi que nettoyer celles qui ne sont pas utilisées pour réduire la taille de la présentation.

## **Ajouter une diapositive de mise en page**

Vous pouvez créer une diapositive de mise en page personnalisée pour définir un formatage réutilisable. Par exemple, vous pouvez ajouter une zone de texte qui apparaît sur toutes les diapositives utilisant cette mise en page.

```cpp
static void AddLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto masterSlide = presentation->get_Master(0);

    // Créez une diapositive de mise en page avec un type de mise en page vierge et un nom personnalisé.
    auto layoutSlide = presentation->get_LayoutSlides()->Add(masterSlide, SlideLayoutType::Blank, u"Main layout");

    // Ajoutez une zone de texte à la diapositive de mise en page.
    auto layoutTextBox = layoutSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 75, 75, 150, 150);
    layoutTextBox->get_TextFrame()->set_Text(u"Layout Slide Text");

    // Ajoutez deux diapositives en utilisant cette mise en page ; les deux hériteront du texte de la mise en page.
    presentation->get_Slides()->AddEmptySlide(layoutSlide);
    presentation->get_Slides()->AddEmptySlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Note 1:** Les diapositives de mise en page servent de modèles pour les diapositives individuelles. Vous pouvez définir les éléments communs une fois et les réutiliser sur de nombreuses diapositives.

> 💡 **Note 2:** Lorsque vous ajoutez des formes ou du texte à une diapositive de mise en page, toutes les diapositives basées sur cette mise en page afficheront automatiquement ce contenu partagé.
> La capture d'ecran ci-dessous montre deux diapositives, laquelle herite d'une zone de texte de la même diapositive de mise en page.

![Diapositives heritant du contenu de la mise en page](layout-slide-result.png)

## **Acceder a une diapositive de mise en page**

Les diapositives de mise en page peuvent être accessibles par indice ou par type de mise en page (par ex., `Blank`, `Title`, `SectionHeader`, etc.).

```cpp
static void AccessLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Accéder à une diapositive de mise en page par indice.
    auto firstLayoutSlide = presentation->get_LayoutSlide(0);

    // Accéder à une diapositive de mise en page par type.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->Dispose();
}
```

## **Supprimer une diapositive de mise en page**

Vous pouvez supprimer une diapositive de mise en page spécifique si elle n'est plus nécessaire.

```cpp
static void RemoveLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Obtenez une diapositive de mise en page par type et supprimez-la.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
    presentation->get_LayoutSlides()->Remove(blankLayoutSlide);

    presentation->Dispose();
}
```

## **Supprimer les diapositives de mise en page inutilisees**

Pour reduire la taille de la presentation, vous pouvez supprimer les diapositives de mise en page qui ne sont utilisees par aucune diapositive normale.

```cpp
static void RemoveUnusedLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // Supprime automatiquement toutes les diapositives de mise en page non référencées par aucune diapositive.
    presentation->get_LayoutSlides()->RemoveUnused();

    presentation->Dispose();
}
```

## **Cloner une diapositive de mise en page**

Vous pouvez dupliquer une diapositive de mise en page en utilisant la méthode `AddClone`.

```cpp
static void CloneLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // Obtenez une diapositive de mise en page existante par type.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    // Clonez la diapositive de mise en page à la fin de la collection de diapositives de mise en page.
    auto clonedLayoutSlide = presentation->get_LayoutSlides()->AddClone(blankLayoutSlide);

    presentation->Dispose();
}
```

> ✅ **Resume :** Les diapositives de mise en page sont des outils puissants pour gerer un formatage coherent sur les diapositives. Aspose.Slides permet un controle complet sur la creation, la gestion et l'optimisation des diapositives de mise en page.