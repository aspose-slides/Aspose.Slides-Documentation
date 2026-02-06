---
title: Image
type: docs
weight: 50
url: /fr/python-net/examples/elements/picture/
keywords:
- image
- cadre d'image
- ajouter une image
- accéder à l'image
- exemples de code
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Travaillez avec des images en Python avec Aspose.Slides : insérez, remplacez, recadrez, compressez, ajustez la transparence et les effets, remplissez les formes, et exportez au format PPT, PPTX et ODP."
---
Montre comment insérer et accéder aux images à partir d'images en mémoire en utilisant **Aspose.Slides for Python via .NET**. Les exemples ci‑dessus créent une image en mémoire, la placent sur une diapositive, puis la récupèrent.

## **Ajouter une image**

Ce code charge une image depuis un fichier et l'insère comme cadre d'image sur la première diapositive.

```py
def add_picture():
    with slides.Presentation() as presentation:
        slide = presentation.slides[0]

        # Chargez une image depuis un fichier.
        with open("image.png", "rb") as image_stream:
            # Ajoutez l'image aux ressources de la présentation.
            image = presentation.images.add_image(image_stream)

        # Insérez un cadre d'image affichant l'image sur la première diapositive.
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, image.width, image.height, image)

        presentation.save("picture.pptx", slides.export.SaveFormat.PPTX)
```

## **Accéder à une image**

Cet exemple vérifie qu'une diapositive contient un cadre d'image, puis accède au premier trouvé.

```py
def access_picture():
    with slides.Presentation("picture.pptx") as presentation:
        slide = presentation.slides[0]

        # Accédez au premier cadre d'image sur la diapositive.
        picture_frame = next(shape for shape in slide.shapes if isinstance(shape, slides.PictureFrame))
```