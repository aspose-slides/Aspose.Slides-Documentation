---
title: Transition de diapositive
type: docs
weight: 110
url: /fr/python-net/examples/elements/slide-transition/
keywords:
- transition de diapositive
- ajouter une transition de diapositive
- accéder à une transition de diapositive
- supprimer une transition de diapositive
- durée de la transition
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Contrôlez les transitions de diapositives en Python avec Aspose.Slides: choisissez le type, la vitesse, le son et le minutage pour peaufiner les présentations au format PPT, PPTX et ODP."
---
Démontre l'application d'effets de transition de diapositive et de minutages avec **Aspose.Slides for Python via .NET**.

## **Ajouter une transition de diapositive**

Appliquez un effet de transition en fondu à la première diapositive.

```py
def add_slide_transition():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Appliquer une transition en fondu.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.FADE

        presentation.save("slide_transition.pptx", slides.export.SaveFormat.PPTX)
```

## **Accéder à une transition de diapositive**

Lisez le type de transition actuellement attribué à une diapositive.

```py
def access_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Accéder au type de transition.
        transition_type = slide.slide_show_transition.type
```

## **Supprimer une transition de diapositive**

Supprimez tout effet de transition en définissant le type sur `NONE`.

```py
def remove_slide_transition():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        # Supprimer la transition en définissant none.
        slide.slide_show_transition.type = slides.slideshow.TransitionType.NONE

        presentation.save("slide_transition_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir la durée de la transition**

Spécifiez la durée pendant laquelle la diapositive est affichée avant de passer automatiquement à la suivante.

```py
def set_transition_duration():
    with slides.Presentation("slide_transition.pptx") as presentation:
        slide = presentation.slides[0]

        slide.slide_show_transition.advance_on_click = True
        slide.slide_show_transition.advance_after_time = 2000  # en millisecondes.

        presentation.save("transition_duration.pptx", slides.export.SaveFormat.PPTX)
```