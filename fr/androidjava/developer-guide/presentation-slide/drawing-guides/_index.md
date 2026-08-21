---
title: Gérer les repères de dessin dans les présentations sur Android
linktitle: Repères de dessin
type: docs
weight: 85
url: /fr/androidjava/drawing-guides/
keywords:
- repère de dessin
- repère horizontal
- repère vertical
- repère d'alignement
- vue de diapositive
- diapositive maître
- diapositive de mise en page
- masque de notes
- masque de prospectus
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Ajouter, accéder et supprimer les repères de dessin horizontaux et verticaux dans les présentations PowerPoint à l'aide d'Aspose.Slides pour Android via Java."
---
## **Vue d'ensemble**

Les repères de dessin sont des lignes horizontales et verticales réglables qui aident les utilisateurs à aligner les formes de manière cohérente lors de la modification d'une présentation dans PowerPoint. Ils sont particulièrement utiles lorsqu'une application génère une présentation qui sera ensuite affinée manuellement : l'application peut enregistrer les mêmes aides à l'alignement que les auteurs doivent suivre lors de l'ajout ou du déplacement de contenu.

Les repères de dessin sont des aides à l'édition, pas du contenu de diapositive. Ils n'apparaissent pas dans un diaporama ni dans la sortie rendue. Aspose.Slides for Android via Java les expose via l'interface [IDrawingGuidesCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/idrawingguidescollection/). Un repère est représenté par [IDrawingGuide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/idrawingguide/) et possède une orientation, une position et une couleur.

La position est mesurée en points à partir du coin supérieur gauche de la diapositive ou du masque concerné. Un repère vertical utilise une coordonnée horizontale, généralement comprise entre zéro et la largeur de la diapositive. Un repère horizontal utilise une coordonnée verticale, généralement comprise entre zéro et la hauteur de la diapositive.

## **Ajouter des repères à la vue de diapositive**

Utilisez [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) pour gérer les repères affichés lors de l'édition des diapositives normales. Appelez [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/idrawingguidescollection/#add-byte-float-) avec une valeur [Orientation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/orientation/) et une position en points.

L'exemple suivant ajoute un repère vertical à droite du centre de la diapositive et un repère horizontal en dessous :

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, slideSize.getWidth() / 2 + 12.5f);
    guides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5f);

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Accéder aux repères de dessin**

Les méthodes [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/idrawingguidescollection/#getCount--) et [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/idrawingguidescollection/#get_Item-int-) permettent d'accéder aux repères existants. Les méthodes [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/idrawingguide/#getOrientation--), [IDrawingGuide.getPosition](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/idrawingguide/#getPosition--) et [IDrawingGuide.getColor](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/idrawingguide/#getColor--) renvoient des valeurs qui peuvent également être modifiées via les méthodes d'accesseur correspondantes.

L'exemple suivant lit les repères de la vue diapositive de la présentation créée ci-dessus :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("drawing-guides.pptx");
try {
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (int index = 0; index < guides.getCount(); index++) {
        IDrawingGuide guide = guides.get_Item(index);
        System.out.println("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **Ajouter des repères aux masques maîtres et aux diapositives de mise en page**

Un masque de diapositive et chacune de ses diapositives de mise en page peuvent disposer de leurs propres collections de repères de dessin. Utilisez [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imasterslide/#getDrawingGuides--) pour un masque de diapositive et [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ilayoutslide/#getDrawingGuides--) pour une diapositive de mise en page.

L'exemple suivant ajoute un repère vertical à la première diapositive maître et un repère horizontal à la première diapositive de mise en page :

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ajouter des repères aux masques de notes et aux masques de prospectus**

Les masques de notes et les masques de prospectus prennent également en charge les repères de dessin. Utilisez [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imasternotesslide/#getDrawingGuides--) et [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) pour accéder à leurs collections. Si une présentation ne contient pas l'un de ces masques, [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) ou [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) crée le masque par défaut et le renvoie.

L'exemple suivant ajoute un repère horizontal à un masque de notes et un repère vertical à un masque de prospectus :

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Effacer les repères de dessin**

Appelez [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) pour supprimer tous les repères d'une collection particulière. La suppression d'une collection n'affecte pas les repères stockés dans une autre portée.

L'exemple suivant efface les repères de la vue diapositive ainsi que tous les repères des masques de diapositives, des diapositives de mise en page, du masque de notes et du masque de prospectus sans créer les masques manquants :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (IMasterSlide masterSlide : presentation.getMasters()) {
        masterSlide.getDrawingGuides().clear();
    }

    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        layoutSlide.getDrawingGuides().clear();
    }

    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        notesMaster.getDrawingGuides().clear();
    }

    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster != null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Les repères de dessin apparaissent-ils dans un diaporama ou sur des images exportées ?**

Non. Les repères de dessin sont des aides à l'alignement pour l'édition et ne sont pas rendus comme contenu de la présentation.

**Un repère de dessin peut‑il être ajouté directement à une diapositive normale individuelle ?**

Les repères d'édition des diapositives normales sont stockés dans les propriétés de vue de diapositive de la présentation. Des collections de repères distinctes sont disponibles pour les masques de diapositives, les diapositives de mise en page, les masques de notes et les masques de prospectus.

**Quelles unités sont utilisées pour les positions des repères ?**

Les positions sont spécifiées en points, où 72 points correspondent à un pouce. Les positions verticales sont mesurées à partir du bord gauche, et les positions horizontales à partir du bord supérieur.

**La suppression des repères de dessin supprime‑t‑elle des formes ou modifie le contenu d'une diapositive ?**

Non. La méthode [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) ne supprime que les repères de la collection sélectionnée. Les formes et les autres contenus de la diapositive restent inchangés.