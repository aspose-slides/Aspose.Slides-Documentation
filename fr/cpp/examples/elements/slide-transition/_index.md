---
title: Transition de diapositive
type: docs
weight: 110
url: /fr/cpp/examples/elements/slide-transition/
keywords:
- exemple de code
- transition de diapositive
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Maîtrisez les transitions de diapositives dans Aspose.Slides for C++ : ajoutez, personnalisez et séquencez les effets et les durées avec des exemples C++ pour les présentations PPT, PPTX et ODP."
---
Cet article montre comment appliquer des effets de transition de diapositive et des minuteries avec **Aspose.Slides for C++**.

## **Ajouter une transition de diapositive**

Appliquez un effet de transition en fondu à la première diapositive.

```cpp
static void AddSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    // Appliquer une transition en fondu.
    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    presentation->Dispose();
}
```

## **Accéder à une transition de diapositive**

Lisez le type de transition actuellement attribué à une diapositive.

```cpp
static void AccessSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Push);

    // Accéder au type de transition.
    auto type = slide->get_SlideShowTransition()->get_Type();

    presentation->Dispose();
}
```

## **Supprimer une transition de diapositive**

Supprimez tout effet de transition en définissant le type sur `None`.

```cpp
static void RemoveSlideTransition()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_Type(TransitionType::Fade);

    // Supprimer la transition en définissant None.
    slide->get_SlideShowTransition()->set_Type(TransitionType::None);

    presentation->Dispose();
}
```

## **Définir la durée de la transition**

Spécifiez la durée d’affichage de la diapositive avant de passer automatiquement à la suivante.

```cpp
static void SetTransitionDuration()
{
    auto presentation = MakeObject<Presentation>();

    auto slide = presentation->get_Slide(0);

    slide->get_SlideShowTransition()->set_AdvanceOnClick(true);
    slide->get_SlideShowTransition()->set_AdvanceAfterTime(2000); // En millisecondes.

    presentation->Dispose();
}
```