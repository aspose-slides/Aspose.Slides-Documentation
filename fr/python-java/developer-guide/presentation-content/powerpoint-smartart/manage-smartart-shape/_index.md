---
title: Gérer les graphiques SmartArt dans les présentations avec Python
linktitle: Graphiques SmartArt
type: docs
weight: 20
url: /fr/python-java/manage-smartart-shape/
keywords:
- objet SmartArt
- graphique SmartArt
- style SmartArt
- couleur SmartArt
- créer SmartArt
- ajouter SmartArt
- modifier SmartArt
- changer SmartArt
- accéder à SmartArt
- type de mise en page SmartArt
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Automatisez la création, la modification et le style des SmartArt PowerPoint en Python avec Aspose.Slides, en proposant des exemples de code concis et des conseils axés sur la performance."
---
## **Vue d'ensemble**

Aspose.Slides vous permet de créer et de gérer des graphiques SmartArt dans les présentations PowerPoint de façon programmatique. Cet article explique comment ajouter une forme SmartArt à une diapositive, accéder aux formes SmartArt existantes, rechercher un SmartArt selon un type de mise en page spécifique, et mettre à jour son apparence visuelle en modifiant le style SmartArt ou le style de couleur.

Les exemples montrent comment travailler avec les formes SmartArt via la collection de formes de la diapositive de présentation, vérifier si une forme est un SmartArt, puis modifier ou inspecter ses propriétés.

## **Créer une forme SmartArt**
Aspose.Slides for Python via Java fournit une API pour créer des formes SmartArt. Pour créer une forme SmartArt dans une diapositive, suivez les étapes ci-dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
1. Récupérez une diapositive par son index.
1. [Ajoutez une forme SmartArt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shapecollection/#addSmartArt) en spécifiant un [SmartArtLayoutType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartartlayouttype/).
1. Enregistrez la présentation modifiée en fichier PPTX.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArtLayoutType

presentation = Presentation()
try:
    # Obtenir la première diapositive.
    slide = presentation.getSlides().get_Item(0)

    # Ajouter une forme SmartArt.
    smart_art = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList)

    # Enregistrer la présentation.
    presentation.save("SimpleSmartArt.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure: forme SmartArt ajoutée à la diapositive**|

## **Accéder à une forme SmartArt sur une diapositive**
L'exemple suivant accède aux formes SmartArt d'une diapositive de présentation. Il parcourt chaque forme de la diapositive et vérifie si la forme est une instance de [SmartArt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartart/).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # Parcourir chaque forme sur la première diapositive.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape
            print("Shape Name: " + str(smart_art.getName()))
finally:
    presentation.dispose()
```

## **Accéder à une forme SmartArt avec un type de mise en page particulier**
L'exemple suivant accède à une forme [SmartArt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartart/) avec un type de mise en page particulier, obtenu via [SmartArt.getLayout](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartart/#getLayout).

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) et chargez la présentation contenant une forme SmartArt.
1. Récupérez la première diapositive par son index.
1. Parcourez chaque forme de la première diapositive.
1. Vérifiez si la forme est une instance de [SmartArt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartart/).
1. Vérifiez si la forme SmartArt possède le type de mise en page spécifié et effectuez l'opération requise.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SmartArt, SmartArtLayoutType

presentation = Presentation("AccessSmartArtShape.pptx")
try:
    # Parcourir chaque forme sur la première diapositive.
    for shape in presentation.getSlides().get_Item(0).getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Vérifier la mise en page du SmartArt.
            if smart_art.getLayout() == SmartArtLayoutType.BasicBlockList:
                print("Perform the required operation here.")
finally:
    presentation.dispose()
```

## **Modifier le style d'une forme SmartArt**
Cet exemple montre comment modifier le style rapide d'une forme SmartArt.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) et chargez la présentation contenant une forme SmartArt.
1. Récupérez la première diapositive par son index.
1. Parcourez chaque forme de la première diapositive.
1. Vérifiez si la forme est une instance de [SmartArt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartart/).
1. Trouvez la forme SmartArt avec le style spécifié.
1. Définissez le nouveau style pour la forme SmartArt.
1. Enregistrez la présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtQuickStyleType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Parcourir chaque forme sur la première diapositive.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Vérifier et changer le style du SmartArt.
            if smart_art.getQuickStyle() == SmartArtQuickStyleType.SimpleFill:
                smart_art.setQuickStyle(SmartArtQuickStyleType.Cartoon)

    presentation.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figure: forme SmartArt avec style modifié**|

## **Modifier le style de couleur d'une forme SmartArt**
Cet exemple accède à une forme SmartArt avec un style de couleur particulier et modifie ce style.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) et chargez la présentation contenant une forme SmartArt.
1. Récupérez la première diapositive par son index.
1. Parcourez chaque forme de la première diapositive.
1. Vérifiez si la forme est une instance de [SmartArt](https://reference.aspose.com/slides/fr/python-java/aspose.slides/smartart/).
1. Trouvez la forme SmartArt avec le style de couleur spécifié.
1. Définissez le nouveau style de couleur pour la forme SmartArt.
1. Enregistrez la présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SmartArt, SmartArtColorType

presentation = Presentation("SimpleSmartArt.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    # Parcourir chaque forme sur la première diapositive.
    for shape in slide.getShapes():
        if isinstance(shape, SmartArt):
            smart_art = shape

            # Vérifier et changer le style du SmartArt.
            if smart_art.getColorStyle() == SmartArtColorType.ColoredFillAccent1:
                smart_art.setColorStyle(SmartArtColorType.ColorfulAccentColors)

    presentation.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

|![SmartArt shape](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figure: forme SmartArt avec style de couleur modifié**|

## **FAQ**

**Puis-je animer le SmartArt comme un objet unique ?**  
Oui. SmartArt est une forme, vous pouvez donc appliquer les [animations standard](/slides/fr/python-java/powerpoint-animation/) via l'API d'animations (entrée, sortie, mise en valeur, trajectoires de mouvement) comme pour les autres formes.

**Comment puis-je trouver un SmartArt spécifique sur une diapositive si je ne connais pas son ID interne ?**  
Définissez et utilisez le [texte alternatif](https://reference.aspose.com/slides/fr/python-java/aspose.slides/shape/#setAlternativeText) et recherchez la forme par cette valeur — c’est la méthode recommandée pour localiser la forme cible.

**Puis-je grouper le SmartArt avec d'autres formes ?**  
Oui. Vous pouvez grouper le SmartArt avec d'autres formes (images, tableaux, etc.) puis [manipuler le groupe](/slides/fr/python-java/group/).

**Comment obtenir une image d'un SmartArt spécifique (par ex. pour un aperçu ou un rapport) ?**  
Exportez une vignette/image de la forme ; la bibliothèque peut [rendre des formes individuelles](/slides/fr/python-java/create-shape-thumbnails/) vers des fichiers raster (PNG/JPG/TIFF).

**L'apparence du SmartArt sera-t-elle préservée lors de la conversion de l'ensemble de la présentation en PDF ?**  
Oui. Le moteur de rendu vise une haute fidélité pour l'[export PDF](/slides/fr/python-java/convert-powerpoint-to-pdf/), avec une gamme d'options de qualité et de compatibilité.