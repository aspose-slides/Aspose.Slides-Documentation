---
title: Redimensionner les formes sur la diapositive
type: docs
weight: 130
url: /python-net/re-sizing-shapes-on-slide/
---

## **Redimensionner les formes sur la diapositive**
L'une des questions les plus fréquentes posées par les clients d'Aspose.Slides pour Python via .NET est comment redimensionner les formes afin que lorsque la taille de la diapositive est modifiée, les données ne soient pas coupées. Cette astuce technique courte montre comment y parvenir.

Pour éviter la désorientation des formes, chaque forme sur la diapositive doit être mise à jour en fonction de la nouvelle taille de la diapositive.

```py
import aspose.slides as slides

#Charger une présentation
with slides.Presentation("pres.pptx") as presentation:
    #Ancienne taille de diapositive
    currentHeight = presentation.slide_size.size.height
    currentWidth = presentation.slide_size.size.width

    #Changement de taille de diapositive
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    #Nouvelle taille de diapositive
    newHeight = presentation.slide_size.size.height
    newWidth = presentation.slide_size.size.width

    ratioHeight = newHeight / currentHeight
    ratioWidth = newWidth / currentWidth

    for slide in presentation.slides:
        for shape in slide.shapes:
            #Redimensionner la position
            shape.height = shape.height * ratioHeight
            shape.width = shape.width * ratioWidth

            #Redimensionner la taille de la forme si nécessaire 
            shape.y = shape.y * ratioHeight
            shape.x = shape.x * ratioWidth

    presentation.save("Resize-1.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}} 

S'il y a une table dans la diapositive, le code ci-dessus ne fonctionnerait pas parfaitement. Dans ce cas, chaque cellule de la table doit être redimensionnée.

{{% /alert %}} 

Vous devez utiliser le code suivant de votre côté si vous devez redimensionner les diapositives avec des tables. Définir la largeur ou la hauteur d'une table est un cas particulier dans les formes où vous devez modifier la hauteur de chaque ligne et la largeur de chaque colonne pour modifier la hauteur et la largeur de la table.

```py
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    #Ancienne taille de diapositive
    currentHeight = presentation.slide_size.size.height
    currentWidth = presentation.slide_size.size.width

    #Changement de taille de diapositive
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    #Nouvelle taille de diapositive
    newHeight = presentation.slide_size.size.height
    newWidth = presentation.slide_size.size.width

    ratioHeight = newHeight / currentHeight
    ratioWidth = newWidth / currentWidth

    for master in presentation.masters:
        for shape in master.shapes:
            #Redimensionner la position
            shape.height = shape.height * ratioHeight
            shape.width = shape.width * ratioWidth

            #Redimensionner la taille de la forme si nécessaire 
            shape.y = shape.y * ratioHeight
            shape.x = shape.x * ratioWidth

        for layoutslide in master.layout_slides:
            for shape in layoutslide.shapes:
                #Redimensionner la position
                shape.height = shape.height * ratioHeight
                shape.width = shape.width * ratioWidth

                #Redimensionner la taille de la forme si nécessaire 
                shape.y = shape.y * ratioHeight
                shape.x = shape.x * ratioWidth

    for slide in presentation.slides:
        for shape in slide.shapes:
            #Redimensionner la position
            shape.height = shape.height * ratioHeight
            shape.width = shape.width * ratioWidth

            #Redimensionner la taille de la forme si nécessaire 
            shape.y = shape.y * ratioHeight
            shape.x = shape.x * ratioWidth
            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * ratioHeight
                for col in shape.columns:
                    col.width = col.width * ratioWidth

    presentation.save("Resize-2.pptx", slides.export.SaveFormat.PPTX)
```