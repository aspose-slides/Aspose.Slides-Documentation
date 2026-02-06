---
title: SmartArt
type: docs
weight: 140
url: /fr/python-net/examples/elements/smart-art/
keywords:
- SmartArt
- ajouter SmartArt
- accéder à SmartArt
- supprimer SmartArt
- disposition SmartArt
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Créez et modifiez des SmartArt en Python avec Aspose.Slides : ajoutez des nœuds, changez les mises en page et les styles, convertissez en formes avec précision, et exportez au format PPT, PPTX et ODP."
---
Montre comment ajouter des graphiques SmartArt, y accéder, les supprimer et modifier les dispositions en utilisant **Aspose.Slides for Python via .NET**.

## **Ajouter SmartArt**

Insérez un graphique SmartArt en utilisant l’une des mises en page intégrées.

```py
def add_smart_art():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        smart_art = slide.shapes.add_smart_art(50, 50, 400, 300, slides.smartart.SmartArtLayoutType.BASIC_PROCESS)

        presentation.save("smart_art.pptx", slides.export.SaveFormat.PPTX)
```

## **Accéder à SmartArt**

Récupérez le premier objet SmartArt d’une diapositive.

```py
def access_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Accéder à la première forme SmartArt.
        first_smart_art = next(shape for shape in slide.shapes if isinstance(shape, slides.smartart.SmartArt))
```

## **Supprimer SmartArt**

Supprimez une forme SmartArt de la diapositive.

```py
def remove_smart_art():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Supposant que la première forme est un objet SmartArt.
        smart_art = slide.shapes[0]

        slide.shapes.remove(smart_art)

        presentation.save("smart_art_removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Modifier la mise en page SmartArt**

Mettez à jour le type de mise en page d’un graphique SmartArt existant.

```py
def change_smart_art_layout():
    with slides.Presentation("smart_art.pptx") as presentation:
        slide = presentation.slides[0]

        # Supposant que la première forme est un objet SmartArt.
        smart_art = slide.shapes[0]

        # Modifier la mise en page du SmartArt.
        smart_art.layout = slides.smartart.SmartArtLayoutType.VERTICAL_PICTURE_LIST

        presentation.save("smart_art_changed.pptx", slides.export.SaveFormat.PPTX)
```