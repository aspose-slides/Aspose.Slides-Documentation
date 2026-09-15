---
title: "Récupérer et mettre à jour les propriétés d’affichage de la présentation en Python via Java"
linktitle: "Propriétés d’affichage"
type: docs
weight: 80
url: /fr/python-java/presentation-view-properties/
keywords:
- "propriétés d’affichage"
- "vue normale"
- "contenu du plan"
- "icônes du plan"
- "ajustement du séparateur vertical"
- "vue unique"
- "état de la barre"
- "taille de la dimension"
- "ajustement automatique"
- "zoom par défaut"
- "PowerPoint"
- "OpenDocument"
- "présentation"
- "Python"
- "Java"
- "Aspose.Slides"
description: "Découvrez les propriétés d’affichage d’Aspose.Slides pour Python via Java pour personnaliser les diapositives PPT, PPTX et ODP — ajustez les mises en page, les niveaux de zoom et les paramètres d’affichage."
---
## **Introduction**

La vue normale comprend trois zones de contenu : la diapositive elle‑même, une zone de contenu latérale et une zone de contenu inférieure. Les propriétés de la vue normale décrivent le positionnement de ces zones de contenu. Ces informations permettent à l’application d’enregistrer l’état de la vue dans le fichier, de sorte que, lorsqu’il est rouvert, la vue se trouve dans le même état que lors du dernier enregistrement de la présentation.

La méthode [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/#getNormalViewProperties) a été ajoutée pour fournir l’accès aux propriétés de la vue normale d’une présentation.

Les classes [NormalViewProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/) et [NormalViewRestoredProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewrestoredproperties/) ainsi que l’énumération [SplitterBarStateType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/splitterbarstatetype/) ont été ajoutées.

## **À propos de NormalViewProperties**

Représente les propriétés de la vue normale.

Les méthodes [getShowOutlineIcons](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getShowOutlineIcons) et [setShowOutlineIcons](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) indiquent si l’application doit afficher des icônes lors de l’affichage du contenu du plan dans l’une des zones de contenu du mode vue normale.

Les méthodes [getSnapVerticalSplitter](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getSnapVerticalSplitter) et [setSnapVerticalSplitter](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) spécifient si le séparateur vertical doit se réduire à un état minimisé lorsque la zone latérale est suffisamment petite.

Les méthodes [getPreferSingleView](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getPreferSingleView) et [setPreferSingleView](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#setPreferSingleView) indiquent si l’utilisateur préfère voir une seule zone de contenu pleine fenêtre plutôt que la vue normale standard avec trois zones de contenu. Si activé, l’application peut choisir d’afficher l’une des zones de contenu dans toute la fenêtre.

Les méthodes [getVerticalBarState](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) et [getHorizontalBarState](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState) spécifient l’état dans lequel la barre de séparateur horizontale ou verticale doit être affichée. Une barre de séparateur horizontale sépare la diapositive de la zone de contenu située sous la diapositive ; une barre de séparateur verticale sépare la diapositive de la zone de contenu latérale. Les valeurs possibles sont : [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/fr/python-java/aspose.slides/splitterbarstatetype/#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/fr/python-java/aspose.slides/splitterbarstatetype/#Maximized) et [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fr/python-java/aspose.slides/splitterbarstatetype/#Restored).

Les méthodes [getRestoredLeft](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getRestoredLeft) et [getRestoredTop](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getRestoredTop) définissent la taille de la zone supérieure ou latérale de la diapositive en mode vue normale, lorsque la valeur [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fr/python-java/aspose.slides/splitterbarstatetype/#Restored) est appliquée à [getVerticalBarState](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getVerticalBarState) et [getHorizontalBarState](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getHorizontalBarState), respectivement.

## **À propos de la restauration de NormalViewProperties**

Spécifie la taille de la zone de diapositive (largeur lorsqu’elle est enfant de [getRestoredTop](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getRestoredTop), hauteur lorsqu’elle est enfant de [getRestoredLeft](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)) de la vue normale, lorsque la zone possède une taille restaurée variable (ni minimisée ni maximisée).

La méthode [getDimensionSize](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewrestoredproperties/#getDimensionSize) spécifie la taille de la zone de diapositive (largeur lorsqu’elle est enfant de [getRestoredTop](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getRestoredTop), hauteur lorsqu’elle est enfant de [getRestoredLeft](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewproperties/#getRestoredLeft)).

La méthode [getAutoAdjust](https://reference.aspose.com/slides/fr/python-java/aspose.slides/normalviewrestoredproperties/#getAutoAdjust) indique si la taille de la zone de contenu latérale doit compenser la nouvelle taille lors du redimensionnement de la fenêtre contenant la vue dans l’application.

L’exemple ci‑dessous montre comment accéder à [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/#getNormalViewProperties) pour une présentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SplitterBarStateType

presentation = Presentation()
try:
    normal_view_properties = presentation.getViewProperties().getNormalViewProperties()
    normal_view_properties.setHorizontalBarState(SplitterBarStateType.Restored)
    normal_view_properties.setVerticalBarState(SplitterBarStateType.Maximized)

    # Restaurer les propriétés d'affichage de la présentation.
    normal_view_properties.getRestoredTop().setAutoAdjust(True)
    normal_view_properties.getRestoredTop().setDimensionSize(80)
    normal_view_properties.setShowOutlineIcons(True)

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Définir la valeur de zoom par défaut**

{{% alert color="info" title="Note" %}}
Aspose.Slides for Python via Java prend en charge la définition de la valeur de zoom par défaut afin qu’elle soit déjà appliquée à l’ouverture de la présentation. Cela peut être fait en configurant les [ViewProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/) d’une présentation. Les méthodes [getSlideViewProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/#getSlideViewProperties) ainsi que [getNotesViewProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/#getNotesViewProperties) peuvent être configurées par programme. Dans ce sujet, nous verrons avec un exemple comment définir les [Propriétés d’affichage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/) d’une [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) dans [Aspose.Slides](/slides/fr/).
{{% /alert %}}

Pour définir les propriétés d’affichage, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
2. Configurez les [Propriétés d’affichage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/) de la [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/).
3. Enregistrez la présentation sous forme de fichier [PPTX](https://docs.fileformat.com/presentation/pptx/).

Dans l’exemple ci‑dessous, nous définissons la valeur de zoom à la fois pour la vue diapositive et pour la vue des notes.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Définir les propriétés d'affichage de la présentation.
    presentation.getViewProperties().getSlideViewProperties().setScale(100)  # Pourcentage de zoom pour la vue diapositive.
    presentation.getViewProperties().getNotesViewProperties().setScale(100)  # Pourcentage de zoom pour la vue des notes.

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Puis‑je définir différents paramètres d’affichage pour différentes sections d’une présentation ?**

[Paramètres d’affichage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getViewProperties) sont définis au niveau de la présentation ([Vue normale](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/#getNormalViewProperties)/[Vue diapositive](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/#getSlideViewProperties)), pas par section, de sorte qu’un seul jeu de paramètres s’applique à l’ensemble du document lorsqu’il s’ouvre.

**Puis‑je pré‑définir différents états d’affichage pour différents utilisateurs ?**

Non. Les paramètres sont stockés dans le fichier et sont partagés. Les applications de visualisation peuvent tenir compte des préférences de l’utilisateur, mais le fichier lui‑même ne contient qu’un seul ensemble de propriétés d’affichage.

**Puis‑je préparer un modèle avec des propriétés d’affichage pré‑configurées afin que les nouvelles présentations s’ouvrent de la même façon ?**

Oui. Étant donné que les [propriétés d’affichage](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getViewProperties) sont stockées au niveau de la présentation, vous pouvez les intégrer dans un modèle et créer de nouveaux documents à partir de celui‑ci avec la même configuration d’affichage initiale.