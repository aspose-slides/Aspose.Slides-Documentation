---
title: Diapositive
type: docs
weight: 10
url: /fr/cpp/examples/elements/slide/
keywords:
- exemple de code
- diapositive
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Contrôlez les diapositives dans Aspose.Slides for C++ : créez, clonez, réorganisez, redimensionnez, définissez les arrière-plans et appliquez des transitions avec C++ pour les présentations PPT, PPTX et ODP."
---
Cet article fournit une série d'exemples illustrant comment travailler avec les diapositives à l'aide de **Aspose.Slides for C++**. Vous apprendrez comment ajouter, accéder, cloner, réorganiser et supprimer des diapositives en utilisant la classe `Presentation`.

Chaque exemple ci-dessous comprend une brève explication suivie d'un extrait de code en C++.

## **Ajouter une diapositive**

Pour ajouter une nouvelle diapositive, vous devez d'abord sélectionner une mise en page. Dans cet exemple, nous utilisons la mise en page `Blank` et ajoutons une diapositive vide à la présentation.

```cpp
static void AddSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->get_Slides()->AddEmptySlide(blankLayout);

    presentation->Dispose();
}
```

> 💡 **Note :** Chaque mise en page de diapositive est dérivée d'une diapositive maîtresse, qui définit la conception globale et la structure des espaces réservés. L'image ci-dessous illustre comment les diapositives maîtresses et leurs mises en page associées sont organisées dans PowerPoint.

![Relation entre la diapositive maître et la mise en page](master-layout-slide.png)

## **Accéder aux diapositives par index**

Vous pouvez accéder aux diapositives en utilisant leur index, ou trouver l'index d'une diapositive à partir d'une référence. Cela est utile pour parcourir ou modifier des diapositives spécifiques.

```cpp
static void AccessSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Ajoutez une autre diapositive vide.
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    presentation->get_Slides()->AddEmptySlide(blankLayout);

    // Accédez aux diapositives par index.
    auto firstSlide = presentation->get_Slide(0);
    auto secondSlide = presentation->get_Slide(1);

    // Obtenez l'index de la diapositive à partir d'une référence, puis accédez-y par index.
    auto secondSlideIndex = presentation->get_Slides()->IndexOf(secondSlide);
    auto secondSlideByIndex = presentation->get_Slide(secondSlideIndex);

    presentation->Dispose();
}
```

## **Cloner une diapositive**

Cet exemple montre comment cloner une diapositive existante. La diapositive clonée est automatiquement ajoutée à la fin de la collection de diapositives.

```cpp
static void CloneSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    auto clonedSlideIndex = presentation->get_Slides()->IndexOf(clonedSlide);

    presentation->Dispose();
}
```

## **Réorganiser les diapositives**

Vous pouvez modifier l'ordre des diapositives en déplaçant une diapositive vers un nouvel index. Dans ce cas, nous déplaçons une diapositive clonée à la première position.

```cpp
static void ReorderSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    presentation->get_Slides()->Reorder(0, clonedSlide);

    presentation->Dispose();
}
```

## **Supprimer une diapositive**

Pour supprimer une diapositive, il suffit de la référencer et d'appeler `Remove`. Cet exemple ajoute une deuxième diapositive puis supprime l'originale, ne laissant que la nouvelle.

```cpp
static void RemoveSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    auto secondSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

    auto firstSlide = presentation->get_Slide(0);
    presentation->get_Slides()->Remove(firstSlide);

    presentation->Dispose();
}
```