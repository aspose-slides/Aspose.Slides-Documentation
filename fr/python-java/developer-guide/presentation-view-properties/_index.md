---
title: Récupérer et mettre à jour les propriétés d'affichage de la présentation en Python via Java
linktitle: Propriétés d'affichage
type: docs
weight: 80
url: /fr/python-java/presentation-view-properties/
keywords:
- propriétés d'affichage
- affichage normal
- contenu du plan
- icônes du plan
- séparateur vertical ajustable
- vue unique
- état de la barre
- taille de la dimension
- ajustement automatique
- zoom par défaut
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Utilisez Aspose.Slides for Python via Java pour configurer la disposition de la vue normale, le zoom des diapositives et des notes, l'espacement de la grille et la visibilité des commentaires dans les présentations PowerPoint."
---
## **Introduction**

Dans la vue normale de PowerPoint, la diapositive apparaît entre un volet latéral pour les vignettes ou le plan et un volet de notes en dessous. Aspose.Slides for Python via Java expose les préférences d'édition enregistrées de la présentation via [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties). Celles‑ci comprennent la disposition des volets, les niveaux de zoom, l'espacement de la grille et la visibilité des commentaires.

## **À propos de NormalViewProperties**

Utilisez [getNormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNormalViewProperties) pour accéder à la classe [NormalViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) contrôle si des icônes apparaissent à côté des titres de diapositive dans le plan. [setSnapVerticalSplitter](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) permet au volet latéral de se raccourcir à son état minimisé lorsque l'utilisateur le réduit. [setPreferSingleView](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) indique une préférence pour l'affichage d'un seul volet dans la fenêtre complète.

[setVerticalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setVerticalBarState) contrôle le séparateur entre le volet latéral et la diapositive. [setHorizontalBarState](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setHorizontalBarState) contrôle le séparateur au-dessus du volet de notes. Les deux acceptent une valeur de type [SplitterBarStateType](https://reference.aspose.com/slides/python-java/aspose.slides/splitterbarstatetype/) : `Minimized`, `Maximized` ou `Restored`.

## **À propos de la restauration de NormalViewProperties**

Lorsque un séparateur est restauré, [getRestoredLeft](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) fournit la taille enregistrée du volet latéral et [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) fournit la taille enregistrée de la zone supérieure de la diapositive. Les deux renvoient une instance de [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/). Sa méthode [setDimensionSize](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) accepte un pourcentage de 0 à 100, et [setAutoAdjust](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) contrôle si l'éditeur ajuste la taille lorsque la fenêtre est redimensionnée.

Cet exemple met à jour une présentation existante. Il restaure le séparateur horizontal, fixe la taille renvoyée par [getRestoredTop](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#getRestoredTop) à 80 % avec l’ajustement automatique activé, et maximise le séparateur vertical. Il appelle également [setShowOutlineIcons](https://reference.aspose.com/slides/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) pour afficher les icônes dans la vue plan.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation("demo.pptx")
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir la valeur de zoom par défaut**

[getSlideViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getSlideViewProperties) et [getNotesViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#getNotesViewProperties) stockent des paramètres de zoom indépendants pour l'éditeur. Ces paramètres n'affectent pas les dimensions des diapositives, la lecture du diaporama ou la résolution d'exportation d'image.

Cet exemple ouvre une présentation existante et appelle [setVariableScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setVariableScale) pour adapter la diapositive à la fenêtre d'édition. Pour la page de notes, il désactive le redimensionnement automatique et appelle [setScale](https://reference.aspose.com/slides/python-java/aspose.slides/commonslideviewproperties/#setScale) pour définir un zoom fixe de 80 %.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    view_properties = presentation.getViewProperties()
    view_properties.getSlideViewProperties().setVariableScale(True)
    notes_view = view_properties.getNotesViewProperties()
    notes_view.setVariableScale(False)
    notes_view.setScale(80)

    presentation.save("zoom.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir l'espacement de la grille**

[setGridSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setGridSpacing) définit la distance entre les lignes de la grille d'édition dans l'ensemble de la présentation. Elle prend une valeur positive en points, 72 points par pouce. Cet exemple affiche l'espacement actuel dans une présentation existante et enregistre une grille d'un quart de pouce en définissant l'intervalle à 18 points.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("demo.pptx")
try:
    grid_spacing = presentation.getViewProperties().getGridSpacing()
    print(f"Current grid spacing: {grid_spacing} points")

    presentation.getViewProperties().setGridSpacing(18.0)

    presentation.save("grid-spacing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

La grille se répète à intervalles fixes. [Drawing guides](/slides/fr/python-java/drawing-guides/) indiquent des positions individuelles horizontales ou verticales. Les deux sont des aides à l'édition et n'apparaissent que dans les éditeurs qui les affichent. Les diaporamas et les exportations vers PDF, images ou SVG les ignorent.

## **Afficher ou masquer les commentaires lors de l'ouverture d'une présentation**

[setShowComments](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setShowComments) enregistre une préférence que les éditeurs compatibles utilisent lors de l'ouverture de la présentation. Pour une présentation existante contenant des commentaires, cet exemple affiche le paramètre actuel et enregistre une copie avec les commentaires masqués. Il appelle également [setLastView](https://reference.aspose.com/slides/python-java/aspose.slides/viewproperties/#setLastView) avec [ViewType.SlideView](https://reference.aspose.com/slides/python-java/aspose.slides/viewtype/#SlideView) afin que la copie s'ouvre en vue diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, Presentation, SaveFormat, ViewType

presentation = Presentation("comments.pptx")
try:
    show_comments = presentation.getViewProperties().getShowComments()
    print(f"Current comment visibility: {show_comments}")

    presentation.getViewProperties().setShowComments(NullableBool.False_)
    presentation.getViewProperties().setLastView(ViewType.SlideView)
    
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Masquer les commentaires préserve leur texte, leurs auteurs, leurs positions, leurs réponses et leurs états. Pour modifier les commentaires eux‑mêmes, consultez [Presentation Comments](/slides/fr/python-java/presentation-comments/). Les paramètres d'exportation contrôlent si les commentaires apparaissent dans le PDF, le HTML, les images, les notes ou les documents imprimés.

## **FAQ**

**Pourquoi la grille est‑elle masquée lorsque je rouvre la présentation ?**

La présentation enregistre l'intervalle de la grille. Pour voir la grille, activez la visibilité de la grille dans l'éditeur.

**La suppression des repères de dessin modifie‑t‑elle l'espacement de la grille ?**

Non. Ajouter, déplacer ou supprimer un repère ne modifie pas l'intervalle de la grille.

**Différentes sections d'une présentation peuvent‑elles avoir des paramètres d'affichage différents ?**

Non. [Presentation.getViewProperties](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/#getViewProperties) s'applique à l'ensemble de la présentation.

**Puis‑je enregistrer des paramètres d'affichage différents pour différents utilisateurs ?**

Le fichier stocke un seul ensemble de propriétés d'affichage pour tous. Un éditeur peut également appliquer les préférences locales d'un utilisateur.

**Puis‑je enregistrer les paramètres d'affichage dans un modèle ?**

Oui. Les présentations créées à partir du modèle héritent de ses paramètres d'affichage enregistrés.