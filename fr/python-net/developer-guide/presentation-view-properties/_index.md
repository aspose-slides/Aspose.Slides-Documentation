---
title: Récupérer et mettre à jour les propriétés d'affichage de la présentation en Python
linktitle: Propriétés d'affichage
type: docs
weight: 80
url: /fr/python-net/presentation-view-properties/
keywords: 
- propriétés d'affichage
- vue normale
- contenu du plan
- icônes du plan
- ancrage du séparateur vertical
- vue unique
- état de la barre
- taille de la dimension
- ajustement automatique
- zoom par défaut
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Utilisez Aspose.Slides for Python via .NET pour configurer la disposition de la vue normale, le zoom des diapositives et des notes, l'espacement de la grille et la visibilité des commentaires dans les présentations PowerPoint."
---
## **Introduction**

Dans la vue normale de PowerPoint, la diapositive apparaît entre un volet latéral contenant des vignettes ou un plan et un volet de notes en dessous. Aspose.Slides for Python via .NET expose les préférences d’édition sauvegardées de la présentation via [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/). Celles‑ci comprennent la disposition des volets, les niveaux de zoom, l’espacement de la grille et la visibilité des commentaires.

## **À propos de NormalViewProperties**

Utilisez [normal_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/) pour accéder à l’objet [NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/). [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) contrôle si des icônes s’affichent à côté des titres de diapositive dans le plan. [snap_vertical_splitter](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/snap_vertical_splitter/) permet au volet latéral de se réduire à son état minimisé lorsque l’utilisateur le rétrécit. [prefer_single_view](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/prefer_single_view/) indique une préférence pour l’affichage d’un seul volet dans la fenêtre complète.

[vertical_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/vertical_bar_state/) contrôle le séparateur entre le volet latéral et la diapositive. [horizontal_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/horizontal_bar_state/) contrôle le séparateur au-dessus du volet de notes. Les deux acceptent une valeur [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) de `MINIMIZED`, `MAXIMIZED` ou `RESTORED`.

<!-- visual-explanation:presentation-view-properties:start -->
[![Un éditeur conceptuel sépare un panneau latéral, une région de diapositive et une région inférieure avec des séparateurs verticaux et horizontaux étiquetés.](visual-presentation-view-properties-40ae1765a743.svg)](visual-presentation-view-properties-40ae1765a743.svg)

*En vue normale, le séparateur vertical contrôle la largeur du volet latéral. Le séparateur horizontal contrôle l’espace au‑dessus du volet de notes.*
<!-- visual-explanation:presentation-view-properties:end -->

## **À propos de la restauration de NormalViewProperties**

Lorsque un séparateur est restauré, [restored_left](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_left/) fournit la taille sauvegardée du volet latéral et [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) fournit la taille sauvegardée de la zone supérieure de la diapositive. Les deux exposent [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/). Sa propriété [dimension_size](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/dimension_size/) accepte un pourcentage de 0 à 100, et [auto_adjust](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/auto_adjust/) contrôle si l’éditeur ajuste la taille lors du redimensionnement de la fenêtre.

Cet exemple met à jour une présentation existante. Il restaure le séparateur horizontal, définit [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) à 80 % avec l’ajustement automatique activé, et maximise le séparateur vertical. Il active également [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) pour la vue plan.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    normal_view = presentation.view_properties.normal_view_properties
    normal_view.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    normal_view.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED
    normal_view.restored_top.auto_adjust = True
    normal_view.restored_top.dimension_size = 80
    normal_view.show_outline_icons = True

    presentation.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir la valeur de zoom par défaut**

[slide_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/) et [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/notes_view_properties/) stockent des réglages de zoom indépendants pour l’éditeur. Ces réglages n’affectent pas les dimensions des diapositives, la lecture du diaporama ou la résolution d’exportation d’images.

Cet exemple ouvre une présentation existante et active [variable_scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/variable_scale/) pour adapter la diapositive à la fenêtre d’édition. Pour la page de notes, il désactive le redimensionnement automatique et définit [scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/scale/) à un zoom fixe de 80 %.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    view_properties.slide_view_properties.variable_scale = True
    view_properties.notes_view_properties.variable_scale = False
    view_properties.notes_view_properties.scale = 80

    presentation.save("zoom.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir l’espacement de la grille**

[grid_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/grid_spacing/) définit la distance entre les lignes de la grille d’édition dans toute la présentation. Elle prend une valeur positive en points, avec 72 points par pouce. Cet exemple affiche l’espacement actuel dans une présentation existante et enregistre une grille de un quart de pouce en fixant l’intervalle à 18 points.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current grid spacing: {view_properties.grid_spacing} points")

    view_properties.grid_spacing = 18.0

    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

La grille se répète à intervalles fixes. Les [Drawing guides](/slides/fr/python-net/drawing-guides/) marquent des positions horizontales ou verticales individuelles. Les deux sont des aides à l’édition et n’apparaissent que dans les éditeurs qui les affichent. Les diaporamas et les exportations en PDF, images ou SVG les omettent.

## **Afficher ou masquer les commentaires lors de l’ouverture d’une présentation**

[show_comments](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/show_comments/) stocke une préférence que les éditeurs compatibles utilisent lors de l’ouverture de la présentation. Pour une présentation existante contenant des commentaires, cet exemple affiche le réglage actuel et enregistre une copie avec les commentaires masqués. Il définit également [last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/last_view/) sur [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/) afin que la copie s’ouvre en vue diapositive.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current comment visibility: {view_properties.show_comments}")

    view_properties.show_comments = slides.NullableBool.FALSE
    view_properties.last_view = slides.ViewType.SLIDE_VIEW
    
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

Masquer les commentaires conserve leur texte, leurs auteurs, leurs positions, leurs réponses et leurs statuts. Pour modifier les commentaires eux‑mêmes, consultez [Presentation Comments](/slides/fr/python-net/presentation-comments/). Les paramètres d’exportation contrôlent la présence des commentaires dans les PDF, HTML, images, notes ou documents de travail.

## **FAQ**

**Pourquoi la grille est‑elle masquée lorsque je rouvre la présentation ?**

La présentation enregistre l’intervalle de la grille. Pour voir la grille, activez la visibilité de la grille dans l’éditeur.

**Supprimer les guides de dessin modifie‑t‑il l’espacement de la grille ?**

Non. Ajouter, déplacer ou supprimer un guide ne modifie pas l’intervalle de la grille.

**Différentes sections d’une présentation peuvent‑elles avoir des paramètres d’affichage différents ?**

Non. [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) s’applique à l’ensemble de la présentation.

**Puis‑je enregistrer des paramètres d’affichage différents pour différents utilisateurs ?**

Le fichier ne stocke qu’un seul jeu de propriétés d’affichage pour tous. Un éditeur peut également appliquer les préférences locales de l’utilisateur.

**Puis‑je enregistrer les paramètres d’affichage dans un modèle ?**

Oui. Les présentations créées à partir du modèle héritent de ses paramètres d’affichage enregistrés.