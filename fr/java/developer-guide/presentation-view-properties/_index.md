---
title: Récupérer et mettre à jour les propriétés de vue de la présentation en Java
linktitle: Propriétés de vue
type: docs
weight: 80
url: /fr/java/presentation-view-properties/
keywords:
- propriétés de vue
- vue normale
- contenu du plan
- icônes du plan
- verrouiller le séparateur vertical
- vue unique
- état de la barre
- taille de la dimension
- ajustement automatique
- zoom par défaut
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Découvrez les propriétés de vue d’Aspose.Slides for Java pour personnaliser les formats de diapositives PPT, PPTX et ODP — ajustez les mises en page, les niveaux de zoom et les paramètres d’affichage."
---
## **Introduction**

La vue normale se compose de trois zones de contenu : la diapositive elle‑même, une zone de contenu latérale et une zone de contenu inférieure. Les propriétés relatives au positionnement des différentes zones de contenu permettent à l’application d’enregistrer l’état de la vue dans le fichier, de sorte que, lors de la réouverture, la vue se trouve dans le même état que lors de la dernière sauvegarde de la présentation.

La méthode [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) a été ajoutée pour offrir l’accès aux propriétés de vue normale d’une présentation.  

Les interfaces [INormalViewProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewRestoredProperties) et leurs descendants, ainsi que l’énumération [SplitterBarStateType](https://reference.aspose.com/slides/fr/java/com.aspose.slides/SplitterBarStateType) ont été ajoutés.

## **À propos d’INormalViewProperties**

Représente les propriétés de la vue normale.

Les méthodes [getShowOutlineIcons](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) et [setShowOutlineIcons](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) indiquent si l’application doit afficher des icônes lors de la présentation du contenu du plan dans l’une des zones de contenu du mode vue normale.

Les méthodes [getSnapVerticalSplitter](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) et [setSnapVerticalSplitter](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) précisent si le séparateur vertical doit se réduire à un état minimisé lorsque la zone latérale est suffisamment petite.

La propriété [getPreferSingleView](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) et [setPreferSingleView](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) indique si l’utilisateur préfère voir une région de contenu unique occupant toute la fenêtre plutôt que la vue normale standard à trois zones de contenu. Si elle est activée, l’application peut choisir d’afficher l’une des régions de contenu sur toute la fenêtre.

Les méthodes [getVerticalBarState](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) et [getHorizontalBarState](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) spécifient l’état dans lequel la barre de séparation horizontale ou verticale doit être affichée. Une barre de séparation horizontale sépare la diapositive de la zone de contenu située sous la diapositive, tandis qu’une barre de séparation verticale sépare la diapositive de la zone de contenu latérale. Les valeurs possibles sont : [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/fr/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/fr/java/com.aspose.slides/SplitterBarStateType#Maximized) et [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fr/java/com.aspose.slides/SplitterBarStateType#Restored).

Les méthodes [getRestoredLeft](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) et [getRestoredTop](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) définissent la taille de la région supérieure ou latérale de la vue normale, lorsque la valeur [SplitterBarStateType.Restored](https://reference.aspose.com/slides/fr/java/com.aspose.slides/SplitterBarStateType#Restored) est appliquée respectivement à [getVerticalBarState](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) et à [getHorizontalBarState](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--).

## **À propos de la restauration d’INormalViewProperties**

Spécifie la taille de la région de la diapositive (largeur lorsqu’elle est enfant de [getRestoredTop](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), hauteur lorsqu’elle est enfant de [getRestoredLeft](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) de la vue normale, lorsque la région possède une taille restaurée variable (ni minimisée ni maximisée).

La méthode [getDimensionSize](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) indique la taille de la région de la diapositive (largeur lorsqu’elle dépend de restoredTop, hauteur lorsqu’elle dépend de restoredLeft).

La méthode [getAutoAdjust](https://reference.aspose.com/slides/fr/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) indique si la taille de la zone de contenu latérale doit se compenser lors du redimensionnement de la fenêtre contenant la vue dans l’application.

Un exemple ci‑dessous montre comment accéder aux propriétés [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) d’une présentation.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Restaurer les propriétés de vue de la présentation
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Définir la valeur de zoom par défaut**

{{% alert color="info" %}} 

Aspose.Slides for Java prend désormais en charge la définition d’une valeur de zoom par défaut pour la présentation, de sorte que le zoom est déjà appliqué à l’ouverture. Cela peut être réalisé en configurant le [ViewProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ViewProperties) d’une présentation. Les méthodes [getSlideViewProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) ainsi que [getNotesViewProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) peuvent être définies programmatique. Dans ce sujet, nous verrons à l’aide d’un exemple comment définir les [View Properties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ViewProperties) d’une [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation) avec Aspose.Slides.

{{% /alert %}} 

Pour définir les propriétés de la vue, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation).
1. Définissez les [View Properties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ViewProperties) de la [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation).
1. Enregistrez la présentation dans un fichier [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   Dans l’exemple ci‑dessous, nous avons défini la valeur de zoom pour la vue diapositive ainsi que pour la vue notes.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Définir les propriétés de vue de la présentation
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Valeur du zoom en pourcentage pour la vue diapositive
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Valeur du zoom en pourcentage pour la vue notes 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Définir l’espacement de la grille**

Utilisez [Presentation.getViewProperties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getViewProperties--) pour accéder aux paramètres de vue à l’échelle de la présentation. Les méthodes [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iviewproperties/#getGridSpacing--) et [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) permettent de lire ou de modifier l’intervalle de la grille d’édition sous‑jacent. Ce paramètre s’applique à toute la présentation, pas à une diapositive individuelle. L’espacement de la grille est exprimé en points, où 72 points = 1 pouce. Utilisez une valeur positive, comme indiqué dans la documentation de l’API.

L’exemple suivant ouvre un fichier `demo.pptx` existant, affiche l’espacement de grille actuel, définit un intervalle d’un quart de pouce, puis enregistre le résultat.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("demo.pptx");
try {
    float gridSpacing = presentation.getViewProperties().getGridSpacing();
    System.out.println("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18f);
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

La grille diffère des [drawing guides](/slides/fr/java/drawing-guides/). L’espacement de la grille contrôle un intervalle régulier, tandis que les guides de dessin sont des lignes d’alignement horizontales ou verticales positionnées individuellement. Ajouter, déplacer ou supprimer des guides de dessin n’affecte pas l’espacement de la grille.

La grille et les guides de dessin sont des aides à l’édition. Ils ne sont pas rendus comme contenu de diapositive dans les PDF, images, SVG ou présentations. Le stockage de l’espacement de la grille ne garantit pas qu’un éditeur l’affichera : sa visibilité dépend également des préférences du visualiseur ou de l’éditeur.

## **FAQ**

**Pourquoi la grille n’est‑elle pas visible après la réouverture de la présentation ?**

Le fichier enregistre l’espacement de la grille, mais c’est l’éditeur qui décide si la grille est affichée. Vérifiez les paramètres de visibilité de la grille dans l’éditeur.

**La suppression des guides de dessin modifie‑t‑elle l’espacement de la grille ?**

Non. Les guides de dessin et l’espacement de la grille sont des réglages indépendants. Supprimer les guides laisse l’intervalle de grille stocké inchangé.

**Puis‑je définir des paramètres de vue différents pour différentes sections d’une présentation ?**

Les [paramètres de vue](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getViewProperties--) sont définis au niveau de la présentation ([Normal View](https://reference.aspose.com/slides/fr/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/fr/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), pas par section, de sorte qu’un seul jeu de paramètres s’applique à l’ensemble du document lors de son ouverture.

**Puis‑je pré‑définir différents états de vue pour différents utilisateurs ?**

Non. Les paramètres sont stockés dans le fichier et partagés. Les applications de visualisation peuvent tenir compte des préférences de l’utilisateur, mais le fichier lui‑même ne contient qu’un unique jeu de propriétés de vue.

**Puis‑je créer un modèle avec des propriétés de vue prédéfinies afin que les nouvelles présentations s’ouvrent de la même manière ?**

Oui. Puisque les [view properties](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/#getViewProperties--) sont stockées au niveau de la présentation, vous pouvez les inclure dans un modèle et créer de nouveaux documents à partir de ce modèle avec la même configuration de vue initiale.