---
title: Diapositive
type: docs
weight: 10
url: /fr/python-net/examples/elements/slide/
keywords:
- diapositive
- ajouter diapositive
- accéder à la diapositive
- index de diapositive
- cloner diapositive
- réorganiser diapositives
- supprimer diapositive
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Gérer les diapositives en Python avec Aspose.Slides: créer, cloner, réorganiser, masquer, définir les arrière-plans et la taille, appliquer des transitions et exporter pour PowerPoint et OpenDocument."
---
Cet article fournit une série d'exemples montrant comment travailler avec les diapositives en utilisant **Aspose.Slides for Python via .NET**. Vous apprendrez comment ajouter, accéder, cloner, réorganiser et supprimer des diapositives à l'aide de la classe `Presentation`.

Chaque exemple ci-dessous comprend une brève explication suivie d'un extrait de code en Python.

## **Add a Slide**

Pour ajouter une nouvelle diapositive, vous devez d'abord sélectionner une mise en page. Dans cet exemple, nous utilisons la mise en page `Blank` et ajoutons une diapositive vide à la présentation.

```py
def add_slide():
    with slides.Presentation() as presentation:
        # Chaque diapositive est basée sur une mise en page, qui elle‑même est basée sur une diapositive maître.
        # Utilisez la mise en page Blank pour créer une nouvelle diapositive.
        blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

        # Ajoutez une nouvelle diapositive vide en utilisant la mise en page sélectionnée.
        presentation.slides.add_empty_slide(blank_layout)

        presentation.save("slide.pptx", slides.export.SaveFormat.PPTX)
```

> 💡 **Conseil :** Chaque mise en page de diapositive est dérivée d'une diapositive maîtresse, qui définit le design global et la structure des espaces réservés. L'image ci-dessous illustre comment les diapositives maîtresses et leurs mises en page associées sont organisées dans PowerPoint.

![Master and Layout Relationship](master-layout-slide.png)

## **Access Slides by Index**

Vous pouvez accéder aux diapositives en utilisant leur index. Cela est utile pour parcourir ou modifier des diapositives spécifiques.

```py
def access_slide():
    with slides.Presentation("slide.pptx") as presentation:
        # Accéder à une diapositive par index.
        first_slide = presentation.slides[0]
```

## **Clone a Slide**

Cet exemple montre comment cloner une diapositive existante. La diapositive clonée est automatiquement ajoutée à la fin de la collection de diapositives.

```py
def clone_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # Cloner la diapositive ; elle sera ajoutée à la fin de la présentation.
        cloned_slide = presentation.slides.add_clone(slide)

        presentation.save("slide_cloned.pptx", slides.export.SaveFormat.PPTX)
```

## **Reorder Slides**

Vous pouvez modifier l'ordre des diapositives en en déplaçant une vers un nouvel index. Dans ce cas, nous déplaçons une diapositive à la première position.

```py
def reorder_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[1]

        # Déplacer la diapositive à la première position (les autres se déplacent vers le bas).
        presentation.slides.reorder(0, slide)

        presentation.save("slide_reordered.pptx", slides.export.SaveFormat.PPTX)
```

## **Remove a Slide**

Pour supprimer une diapositive, il suffit de la référencer et d'appeler `remove`. Cet exemple supprime la première diapositive.

```py
def remove_slide():
    with slides.Presentation("slide.pptx") as presentation:
        slide = presentation.slides[0]

        # Supprimer la diapositive.
        presentation.slides.remove(slide)

        presentation.save("slide_removed.pptx", slides.export.SaveFormat.PPTX)
```