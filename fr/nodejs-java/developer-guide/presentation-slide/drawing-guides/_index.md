---
title: Gérer les repères de dessin dans les présentations en JavaScript
linktitle: Repères de dessin
type: docs
weight: 85
url: /fr/nodejs-java/drawing-guides/
keywords:
- repère de dessin
- repère horizontal
- repère vertical
- repère d'alignement
- vue diapositive
- maître de diapositive
- diapositive de disposition
- maître de notes
- maître de prospectus
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Ajouter, accéder et supprimer les repères de dessin horizontaux et verticaux dans les présentations PowerPoint à l'aide d'Aspose.Slides for Node.js via Java."
---
## **Vue d'ensemble**

Les repères de dessin sont des lignes horizontales et verticales réglables qui aident les utilisateurs à aligner les formes de manière cohérente lors de la modification d’une présentation dans PowerPoint. Ils sont particulièrement utiles lorsqu’une application génère une présentation qui sera ensuite peaufinée manuellement : l’application peut enregistrer les mêmes aides à l’alignement que les auteurs devront suivre lors de l’ajout ou du déplacement de contenu.

Les repères de dessin sont des aides à la modification, et non du contenu de diapositive. Ils n’apparaissent pas lors d’un diaporama ni dans le rendu final. Aspose.Slides for Node.js via Java les expose via la classe [DrawingGuidesCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/drawingguidescollection/). Un repère est représenté par [DrawingGuide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/drawingguide/) et possède une orientation, une position et une couleur.

La position est mesurée en points à partir du coin supérieur gauche de la diapositive ou du maître concerné. Un repère vertical utilise une coordonnée horizontale, généralement comprise entre zéro et la largeur de la diapositive. Un repère horizontal utilise une coordonnée verticale, généralement comprise entre zéro et la hauteur de la diapositive.

## **Ajouter des repères à la vue diapositive**

Utilisez [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) pour gérer les repères affichés pendant la modification des diapositives normales. Appelez [DrawingGuidesCollection.add](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/drawingguidescollection/#add) avec une valeur [Orientation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/orientation/) et une position en points.

L’exemple suivant ajoute un repère vertical à droite du centre de la diapositive et un repère horizontal en dessous :

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 + 12.5);
    guides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5);

    presentation.save("drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Accéder aux repères de dessin**

Les méthodes [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/drawingguidescollection/#getCount) et [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/drawingguidescollection/#get_Item) offrent un accès aux repères existants. Les méthodes [DrawingGuide.getOrientation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/drawingguide/#getPosition) et [DrawingGuide.getColor](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/drawingguide/#getColor) renvoient des valeurs qui peuvent également être modifiées via les méthodes d’assesseur correspondantes.

L’exemple suivant lit les repères de la vue diapositive à partir de la présentation créée ci‑dessus :

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("drawing-guides.pptx");
try {
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (let index = 0; index < guides.getCount(); index++) {
        const guide = guides.get_Item(index);
        console.log("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **Ajouter des repères aux maîtres et aux diapositives de disposition**

Un maître de diapositive et chacune de ses diapositives de disposition peuvent avoir leurs propres collections de repères de dessin. Utilisez [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masterslide/#getDrawingGuides) pour un maître de diapositive et [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutslide/#getDrawingGuides) pour une diapositive de disposition.

L’exemple suivant ajoute un repère vertical au premier maître de diapositive et un repère horizontal à la première diapositive de disposition :

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    const layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ajouter des repères aux maîtres de notes et de prospectus**

Les maîtres de notes et les maîtres de prospectus prennent également en charge les repères de dessin. Utilisez [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masternotesslide/#getDrawingGuides) et [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masterhandoutslide/#getDrawingGuides) pour accéder à leurs collections. Si une présentation ne contient pas l’un de ces maîtres, `MasterNotesSlideManager.setDefaultMasterNotesSlide` ou `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` crée le maître par défaut et le renvoie.

L’exemple suivant ajoute un repère horizontal à un maître de notes et un repère vertical à un maître de prospectus :

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const notesSize = presentation.getNotesSize().getSize();
    const notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    const handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(slides.Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(slides.Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Effacer les repères de dessin**

Appelez [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/drawingguidescollection/#clear) pour supprimer tous les repères d’une collection particulière. Le nettoyage d’une collection n’affecte pas les repères stockés dans un autre contexte.

L’exemple suivant efface les repères de la vue diapositive ainsi que tous les repères des maîtres de diapositives, des diapositives de disposition, du maître de notes et du maître de prospectus, sans créer de maîtres manquants :

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (let index = 0; index < presentation.getMasters().size(); index++) {
        presentation.getMasters().get_Item(index).getDrawingGuides().clear();
    }

    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        presentation.getLayoutSlides().get_Item(index).getDrawingGuides().clear();
    }

    const notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster !== null) {
        notesMaster.getDrawingGuides().clear();
    }

    const handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster !== null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Les repères de dessin apparaissent‑ils dans un diaporama ou sur les images exportées ?**

Non. Les repères de dessin sont des aides à l’alignement pour la modification et ne sont pas rendus comme contenu de la présentation.

**Un repère de dessin peut‑il être ajouté directement à une diapositive normale individuelle ?**

Les repères de modification des diapositives normales sont stockés dans les propriétés de vue diapositive de la présentation. Des collections de repères distinctes sont disponibles pour les maîtres de diapositives, les diapositives de disposition, les maîtres de notes et les maîtres de prospectus.

**Quelles unités sont utilisées pour les positions des repères ?**

Les positions sont exprimées en points, où 72 points = 1 pouce. Les positions verticales sont mesurées à partir du bord gauche, et les positions horizontales à partir du bord supérieur.

**Le fait d’effacer les repères de dessin supprime‑t‑il des formes ou modifie‑t‑il le contenu d’une diapositive ?**

Non. La méthode [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/drawingguidescollection/#clear) supprime uniquement les repères de la collection sélectionnée. Les formes et les autres contenus de la diapositive restent inchangés.