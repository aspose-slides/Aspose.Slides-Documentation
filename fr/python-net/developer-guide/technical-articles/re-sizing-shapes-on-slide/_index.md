---
title: Redimensionner les formes dans les présentations avec Python
linktitle: Redimensionnement des formes
type: docs
weight: 130
url: /fr/python-net/re-sizing-shapes-on-slide/
keywords:
- redimensionner la forme
- changer la taille de la forme
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Redimensionnez facilement les formes sur les diapositives PowerPoint et OpenDocument avec Aspose.Slides pour Python via .NET — automatisez les ajustements de mise en page des diapositives et augmentez la productivité."
---

## **Aperçu**

L’une des questions les plus fréquentes des clients d’Aspose.Slides for Python concerne la façon de redimensionner les formes afin que, lorsque la taille de la diapositive change, les données ne soient pas coupées. Cet article technique bref montre comment procéder.

## **Redimensionner les formes**

Pour éviter que les formes ne se désalignent lorsque la taille de la diapositive change, mettez à jour la position et les dimensions de chaque forme afin qu’elles s’ajustent au nouveau format de diapositive.
```py
import aspose.slides as slides

# Charger le fichier de présentation.
with slides.Presentation("sample.pptx") as presentation:
    # Obtenir la taille originale de la diapositive.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # Modifier la taille de la diapositive sans mettre à l'échelle les formes existantes.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Obtenir la nouvelle taille de la diapositive.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    # Redimensionner et repositionner les formes sur chaque diapositive.
    for slide in presentation.slides:
        for shape in slide.shapes:
            # Mettre à l'échelle la taille de la forme.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Mettre à l'échelle la position de la forme.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


{{% alert color="primary" %}} 
Si une diapositive contient un tableau, le code ci‑dessus ne fonctionnera pas correctement. Dans ce cas, chaque cellule du tableau doit être redimensionnée.
{{% /alert %}} 

Utilisez le code suivant pour redimensionner les diapositives contenant des tableaux. Pour les tableaux, le réglage de la largeur ou de la hauteur est un cas particulier : vous devez ajuster les hauteurs des lignes et les largeurs des colonnes individuellement pour modifier la taille globale du tableau.
```py
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    # Obtenir la taille originale de la diapositive.
    current_height = presentation.slide_size.size.height
    current_width = presentation.slide_size.size.width

    # Modifier la taille de la diapositive sans mettre à l'échelle les formes existantes.
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.DO_NOT_SCALE)

    # Obtenir la nouvelle taille de la diapositive.
    new_height = presentation.slide_size.size.height
    new_width = presentation.slide_size.size.width

    height_ratio = new_height / current_height
    width_ratio = new_width / current_width

    for master in presentation.masters:
        for shape in master.shapes:
            # Mettre à l'échelle la taille de la forme.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Mettre à l'échelle la position de la forme.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

        for layout_slide in master.layout_slides:
            for shape in layout_slide.shapes:
                # Mettre à l'échelle la taille de la forme.
                shape.height = shape.height * height_ratio
                shape.width = shape.width * width_ratio

                # Mettre à l'échelle la position de la forme.
                shape.y = shape.y * height_ratio
                shape.x = shape.x * width_ratio

    for slide in presentation.slides:
        for shape in slide.shapes:
            # Mettre à l'échelle la taille de la forme.
            shape.height = shape.height * height_ratio
            shape.width = shape.width * width_ratio

            # Mettre à l'échelle la position de la forme.
            shape.y = shape.y * height_ratio
            shape.x = shape.x * width_ratio

            if type(shape) is slides.Table:
                for row in shape.rows:
                    row.minimal_height = row.minimal_height * height_ratio
                for column in shape.columns:
                    column.width = column.width * width_ratio

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Pourquoi les formes sont‑elles déformées ou coupées après le redimensionnement d’une diapositive ?**

Lors du redimensionnement d’une diapositive, les formes conservent leur position et leur taille d’origine sauf si l’échelle est modifiée explicitement. Cela peut entraîner une découpe du contenu ou un désalignement des formes.

**Le code fourni fonctionne‑t‑il pour tous les types de formes ?**

L’exemple de base fonctionne pour la plupart des types de formes (zones de texte, images, graphiques, etc.). Cependant, pour les tableaux, vous devez gérer séparément les lignes et les colonnes, car la hauteur et la largeur d’un tableau sont déterminées par les dimensions des cellules individuelles.

**Comment redimensionner les tableaux lors du redimensionnement d’une diapositive ?**

Vous devez parcourir toutes les lignes et toutes les colonnes du tableau et redimensionner leur hauteur et leur largeur proportionnellement, comme illustré dans le deuxième exemple de code.

**Ce redimensionnement fonctionne‑t‑il pour les diapositives maîtres et les diapositives de mise en page ?**

Oui, mais vous devez également parcourir les [Masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) et les [Layout slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/layout_slides/) et appliquer la même logique de mise à l’échelle à leurs formes afin d’assurer la cohérence de la présentation.

**Puis‑je changer l’orientation d’une diapositive (portrait/paysage) en même temps que le redimensionnement ?**

Oui. Vous pouvez utiliser [presentation.slide_size.orientation](https://reference.aspose.com/slides/python-net/aspose.slides/islidesize/orientation/) pour modifier l’orientation. Veillez à ajuster la logique de mise à l’échelle en conséquence pour préserver la mise en page.

**Existe‑t‑il une limite à la taille de diapositive que je peux définir ?**

Aspose.Slides prend en charge les tailles personnalisées, mais des tailles très importantes peuvent affecter les performances ou la compatibilité avec certaines versions de PowerPoint.

**Comment empêcher les formes à ratio d’aspect fixe de se déformer ?**

Vous pouvez vérifier la propriété `aspect_ratio_locked` de la forme avant de la mettre à l’échelle. Si elle est verrouillée, ajustez la largeur ou la hauteur proportionnellement plutôt que de les mettre à l’échelle séparément.