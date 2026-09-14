---
title: Gérer les repères de dessin dans les présentations en Python
linktitle: Repères de dessin
type: docs
weight: 85
url: /fr/python-java/drawing-guides/
keywords:
- repère de dessin
- guide horizontal
- guide vertical
- guide d'alignement
- vue de diapositive
- masque de diapositive
- diapositive de mise en page
- masque de notes
- masque de prospectus
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Ajouter, accéder et supprimer les repères de dessin horizontaux et verticaux dans les présentations PowerPoint à l'aide d'Aspose.Slides for Python via Java."
---
## **Vue d'ensemble**

Les repères de dessin sont des lignes horizontales et verticales réglables qui aident les utilisateurs à aligner les formes de manière constante lors de la modification d’une présentation dans PowerPoint. Ils sont particulièrement utiles lorsqu’une application génère une présentation qui sera ensuite affinée manuellement : l’application peut enregistrer les mêmes aides à l’alignement que les auteurs doivent suivre lors de l’ajout ou du déplacement de contenu.

Les repères de dessin sont des aides à l’édition, pas du contenu de diapositive. Ils n’apparaissent pas dans le diaporama ni dans la sortie rendue. Aspose.Slides for Python via Java les expose via la classe [DrawingGuidesCollection](https://reference.aspose.com/slides/fr/python-java/aspose.slides/drawingguidescollection/) . Un repère est représenté par [DrawingGuide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/drawingguide/) et possède une orientation, une position et une couleur.

La position est mesurée en points à partir du coin supérieur gauche de la diapositive ou du masque concerné. Un repère vertical utilise une coordonnée horizontale, généralement comprise entre zéro et la largeur de la diapositive. Un repère horizontal utilise une coordonnée verticale, généralement comprise entre zéro et la hauteur de la diapositive.

## **Ajouter des repères à la vue diapositive**

Utilisez [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) pour gérer les repères affichés lors de la modification des diapositives normales. Appelez [DrawingGuidesCollection.add](https://reference.aspose.com/slides/fr/python-java/aspose.slides/drawingguidescollection/#add) avec une valeur [Orientation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/orientation/) et une position en points.

L’exemple suivant ajoute un repère vertical à droite du centre de la diapositive et un repère horizontal en dessous :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    guides.add(Orientation.Vertical, slide_size.getWidth() / 2 + 12.5)
    guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 12.5)

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Accéder aux repères de dessin**

Les méthodes [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/fr/python-java/aspose.slides/drawingguidescollection/#getCount) et [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/fr/python-java/aspose.slides/drawingguidescollection/#get_Item) permettent d’accéder aux repères existants. Les méthodes [DrawingGuide.getOrientation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/drawingguide/#getOrientation), [DrawingGuide.getPosition](https://reference.aspose.com/slides/fr/python-java/aspose.slides/drawingguide/#getPosition) et [DrawingGuide.getColor](https://reference.aspose.com/slides/fr/python-java/aspose.slides/drawingguide/#getColor) renvoient des valeurs qui peuvent également être modifiées via les méthodes d’accesseur correspondantes.

L’exemple suivant lit les repères de la vue diapositive de la présentation créée ci‑dessus :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("drawing-guides.pptx")
try:
    guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides()

    for index in range(guides.getCount()):
        guide = guides.get_Item(index)
        print(f"Guide {index}: orientation = {guide.getOrientation()}, position = {guide.getPosition()}, color = {guide.getColor()}")
finally:
    presentation.dispose()
```

## **Ajouter des repères aux masques et aux diapositives de mise en page**

Un masque de diapositive et chacune de ses diapositives de mise en page peuvent posséder leurs propres collections de repères de dessin. Utilisez [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterslide/#getDrawingGuides) pour un masque de diapositive et [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layoutslide/#getDrawingGuides) pour une diapositive de mise en page.

L’exemple suivant ajoute un repère vertical au premier masque de diapositive et un repère horizontal à la première diapositive de mise en page :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    slide_size = presentation.getSlideSize().getSize()
    master_guides = presentation.getMasters().get_Item(0).getDrawingGuides()
    layout_guides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides()

    master_guides.add(Orientation.Vertical, slide_size.getWidth() / 2 - 20)
    layout_guides.add(Orientation.Horizontal, slide_size.getHeight() / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ajouter des repères aux masques de notes et de prospectus**

Les masques de notes et les masques de prospectus prennent également en charge les repères de dessin. Utilisez [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masternotesslide/#getDrawingGuides) et [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterhandoutslide/#getDrawingGuides) pour accéder à leurs collections. Si une présentation ne contient pas l’un de ces masques, `MasterNotesSlideManager.setDefaultMasterNotesSlide` ou `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` crée le masque par défaut et le renvoie.

L’exemple suivant ajoute un repère horizontal à un masque de notes et un repère vertical à un masque de prospectus :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Orientation, SaveFormat

presentation = Presentation()
try:
    notes_size = presentation.getNotesSize().getSize()
    notes_master = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide()
    handout_master = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide()

    notes_master.getDrawingGuides().add(Orientation.Horizontal, notes_size.getHeight() / 2 + 50)
    handout_master.getDrawingGuides().add(Orientation.Vertical, notes_size.getWidth() / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Effacer les repères de dessin**

Appelez [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/fr/python-java/aspose.slides/drawingguidescollection/#clear) pour supprimer tous les repères d’une collection donnée. Nettoyer une collection n’affecte pas les repères stockés dans un autre périmètre.

L’exemple suivant efface les repères de la vue diapositive et tous les repères sur les masques de diapositives, les diapositives de mise en page, le masque de notes et le masque de prospectus sans créer de masques manquants :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation-with-guides.pptx")
try:
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear()

    for master_slide in presentation.getMasters():
        master_slide.getDrawingGuides().clear()

    for layout_slide in presentation.getLayoutSlides():
        layout_slide.getDrawingGuides().clear()

    notes_master = presentation.getMasterNotesSlideManager().getMasterNotesSlide()
    if notes_master is not None:
        notes_master.getDrawingGuides().clear()

    handout_master = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide()
    if handout_master is not None:
        handout_master.getDrawingGuides().clear()

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Les repères de dessin apparaissent-ils dans un diaporama ou des images exportées ?**

Non. Les repères de dessin sont des aides à l’alignement lors de l’édition et ne sont pas rendus comme contenu de la présentation.

**Un repère de dessin peut-il être ajouté directement à une diapositive normale individuelle ?**

Les repères d’édition des diapositives normales sont stockés dans les propriétés de vue diapositive de la présentation. Des collections de repères distinctes sont disponibles pour les masques de diapositives, les diapositives de mise en page, les masques de notes et les masques de prospectus.

**Quelles unités sont utilisées pour les positions des repères ?**

Les positions sont exprimées en points, où 72 points correspondent à un pouce. Les positions verticales sont mesurées à partir du bord gauche, et les positions horizontales à partir du bord supérieur.

**L’effacement des repères de dessin supprime‑t‑il des formes ou modifie‑t‑il le contenu d’une diapositive ?**

Non. La méthode [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/fr/python-java/aspose.slides/drawingguidescollection/#clear) supprime uniquement les repères de la collection sélectionnée. Les formes et les autres contenus de la diapositive restent inchangés.