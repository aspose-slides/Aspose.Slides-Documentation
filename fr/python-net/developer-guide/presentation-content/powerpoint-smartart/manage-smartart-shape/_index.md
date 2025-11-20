---
title: Gérer les graphiques SmartArt dans les présentations avec Python
linktitle: Graphiques SmartArt
type: docs
weight: 20
url: /fr/python-net/manage-smartart-shape/
keywords:
- Objet SmartArt
- Graphique SmartArt
- Style SmartArt
- Couleur SmartArt
- Créer SmartArt
- Ajouter SmartArt
- Modifier SmartArt
- Changer SmartArt
- Accéder à SmartArt
- Type de disposition SmartArt
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Automatisez la création, la modification et le style des SmartArt PowerPoint en Python via .NET avec Aspose.Slides, en proposant des exemples de code concis et des conseils axés sur la performance."
---

## **Créer des formes SmartArt**

Aspose.Slides for Python via .NET vous permet d'ajouter des formes SmartArt personnalisées aux diapositives depuis le départ. L'API rend cela simple. Pour ajouter une forme SmartArt à une diapositive :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez la diapositive cible par son indice.
1. Ajoutez une forme SmartArt en spécifiant son type de disposition.
1. Enregistrez la présentation modifiée au format PPTX.
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Instancier la classe Presentation.
with slides.Presentation() as presentation:
    # Accéder à la diapositive de la présentation.
    slide = presentation.slides[0]
    # Ajouter une forme SmartArt.
    smart_art = slide.shapes.add_smart_art(0, 0, 400, 400, smartart.SmartArtLayoutType.BASIC_BLOCK_LIST)
    # Enregistrer la présentation sur le disque.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Accéder aux formes SmartArt sur les diapositives**

Le code suivant montre comment accéder aux formes SmartArt sur une diapositive. L'exemple parcourt chaque forme sur la diapositive et vérifie s'il s'agit d'un objet [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/).
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

# Charger un fichier de présentation.
with slides.Presentation("SmartArt.pptx") as presentation:
    # Parcourir chaque forme sur la première diapositive.
    for shape in presentation.slides[0].shapes:
        # Vérifier si la forme est une forme SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Afficher le nom de la forme.
            print("Shape name:", shape.name)
```


## **Accéder aux formes SmartArt avec un type de disposition spécifié**

L'exemple suivant montre comment accéder à une forme SmartArt avec un type de disposition spécifié. Notez que vous ne pouvez pas modifier le type de disposition d'un SmartArt ; il est en lecture seule et est défini lors de la création de la forme.

1. Créez une instance de [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et chargez la présentation contenant la forme SmartArt.
1. Obtenez une référence à la première diapositive par indice.
1. Parcourez chaque forme de la première diapositive.
1. Vérifiez si la forme est un objet [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/).
1. Si le type de disposition de la forme SmartArt correspond à celui recherché, effectuez les actions requises.
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Parcourir chaque forme sur la première diapositive.
    for shape in presentation.slides[0].shapes:
        # Vérifier si la forme est une forme SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Vérifier le type de disposition SmartArt.
            if shape.layout == smartart.SmartArtLayoutType.BASIC_BLOCK_LIST:
                print("Do something here...")
```


## **Modifier le style de la forme SmartArt**

L'exemple suivant montre comment localiser les formes SmartArt et modifier leur style :

1. Créez une [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et chargez le fichier contenant les formes SmartArt.
1. Obtenez une référence à la première diapositive par indice.
1. Parcourez chaque forme de la première diapositive.
1. Trouvez la forme SmartArt ayant le style spécifié.
1. Attribuez le nouveau style à la forme SmartArt.
1. Enregistrez la présentation.
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Parcourir chaque forme sur la première diapositive.
    for shape in presentation.slides[0].shapes:
        # Vérifier si la forme est une forme SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Vérifier le style SmartArt.
            if shape.quick_style == smartart.SmartArtQuickStyleType.SIMPLE_FILL:
                # Modifier le style SmartArt.
                smart.quick_style = smartart.SmartArtQuickStyleType.CARTOON
    # Enregistrer la présentation.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Modifier le style de couleur des formes SmartArt**

Cet exemple montre comment changer le style de couleur d'une forme SmartArt. Le code d'exemple localise une forme SmartArt avec un style de couleur spécifié et le met à jour.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et chargez la présentation contenant les formes SmartArt.
1. Obtenez une référence à la première diapositive par indice.
1. Parcourez chaque forme de la première diapositive.
1. Vérifiez si la forme est un objet [SmartArt](https://reference.aspose.com/slides/python-net/aspose.slides.smartart/smartart/).
1. Localisez la forme SmartArt avec le style de couleur spécifié.
1. Attribuez le nouveau style de couleur à cette forme SmartArt.
1. Enregistrez la présentation.
```py
import aspose.slides as slides
import aspose.slides.smartart as smartart

with slides.Presentation("SmartArt.pptx") as presentation:
    # Parcourir chaque forme sur la première diapositive.
    for shape in presentation.slides[0].shapes:
        # Vérifier si la forme est une forme SmartArt.
        if isinstance(shape, smartart.SmartArt):
            # Vérifier le type de couleur.
            if shape.color_style == smartart.SmartArtColorType.COLORED_FILL_ACCENT1:
                # Modifier le type de couleur.
                shape.color_style = smartart.SmartArtColorType.COLORFUL_ACCENT_COLORS
    # Enregistrer la présentation.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Puis-je animer SmartArt comme un seul objet ?**

Oui. SmartArt est une forme, vous pouvez donc appliquer les [animations standard](/slides/fr/python-net/powerpoint-animation/) via l'API d'animations (entrée, sortie, mise en valeur, trajectoires) comme pour les autres formes.

**Comment trouver un SmartArt spécifique sur une diapositive si je ne connais pas son ID interne ?**

Définissez et utilisez le texte alternatif (AltText) et recherchez la forme par cette valeur ; c'est la méthode recommandée pour localiser la forme cible.

**Puis-je regrouper SmartArt avec d'autres formes ?**

Oui. Vous pouvez regrouper SmartArt avec d'autres formes (images, tableaux, etc.) puis [manipuler le groupe](/slides/fr/python-net/group/).

**Comment obtenir une image d'un SmartArt spécifique (par exemple pour un aperçu ou un rapport) ?**

Exportez une vignette/image de la forme ; la bibliothèque peut [rendre des formes individuelles](/slides/fr/python-net/create-shape-thumbnails/) vers des fichiers raster (PNG/JPG/TIFF).

**L'aspect du SmartArt sera-t-il conservé lors de la conversion de toute la présentation en PDF ?**

Oui. Le moteur de rendu vise une haute fidélité pour l'[export PDF](/slides/fr/python-net/convert-powerpoint-to-pdf/), avec une gamme d'options de qualité et de compatibilité.