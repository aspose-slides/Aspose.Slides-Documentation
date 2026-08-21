---
title: Gérer les repères de dessin dans les présentations en Python
linktitle: Repères de dessin
type: docs
weight: 85
url: /fr/python-net/drawing-guides/
keywords:
- repère de dessin
- repère horizontal
- repère vertical
- repère d'alignement
- vue de diapositive
- masque de diapositive
- diapositive de mise en page
- masque de notes
- masque de prospectus
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Ajouter, accéder et supprimer les repères de dessin horizontaux et verticaux dans les présentations PowerPoint à l'aide d'Aspose.Slides pour Python via .NET."
---
## **Aperçu**

Les repères de dessin sont des lignes horizontales et verticales réglables qui aident les utilisateurs à aligner les formes de manière cohérente lors de l'édition d'une présentation PowerPoint. Ils sont particulièrement utiles lorsqu'une application génère une présentation qui sera ensuite affinée manuellement : l'application peut enregistrer les mêmes aides à l'alignement que les auteurs doivent suivre lors de l'ajout ou du déplacement de contenu.

Les repères de dessin sont des aides à l'édition, pas du contenu de diapositive. Ils n'apparaissent pas dans un diaporama ni dans la sortie rendue. Aspose.Slides for Python via .NET les expose via l'interface [IDrawingGuidesCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/idrawingguidescollection/). Un repère est représenté par [IDrawingGuide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/idrawingguide/) et possède une orientation, une position et une couleur.

La position est mesurée en points depuis le coin supérieur gauche de la diapositive ou du masque concerné. Un repère vertical utilise une coordonnée horizontale, généralement comprise entre zéro et la largeur de la diapositive. Un repère horizontal utilise une coordonnée verticale, généralement comprise entre zéro et la hauteur de la diapositive.

## **Ajouter des repères à la vue de diapositive**

Utilisez [ICommonSlideViewProperties.drawing_guides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/icommonslideviewproperties/drawing_guides/) pour gérer les repères affichés lors de l'édition des diapositives normales. Appelez [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/fr/python-net/aspose.slides/idrawingguidescollection/add/) avec une valeur [Orientation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/orientation/) et une position en points.

L'exemple suivant ajoute un repère vertical à droite du centre de la diapositive et un repère horizontal en dessous :

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 + 12.5)
    guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 12.5)

    presentation.save("drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Accéder aux repères de dessin**

La propriété [IDrawingGuidesCollection.count](https://reference.aspose.com/slides/fr/python-net/aspose.slides/idrawingguidescollection/count/) et l'indexeur permettent d'accéder aux repères existants. Les propriétés [IDrawingGuide.orientation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/idrawingguide/orientation/), [IDrawingGuide.position](https://reference.aspose.com/slides/fr/python-net/aspose.slides/idrawingguide/position/) et [IDrawingGuide.color](https://reference.aspose.com/slides/fr/python-net/aspose.slides/idrawingguide/color/) peuvent être lues ou modifiées.

L'exemple suivant lit les repères de la vue de diapositive de la présentation créée ci‑dessus :

```py
import aspose.slides as slides

with slides.Presentation("drawing-guides.pptx") as presentation:
    guides = presentation.view_properties.slide_view_properties.drawing_guides

    for index in range(guides.count):
        guide = guides[index]
        print(f"Guide {index}: orientation = {guide.orientation}, position = {guide.position}, color = {guide.color}")
```

## **Ajouter des repères aux masques et aux diapositives de mise en page**

Un masque de diapositive et chacune de ses diapositives de mise en page peuvent posséder leurs propres collections de repères de dessin. Utilisez [IMasterSlide.drawing_guides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/imasterslide/drawing_guides/) pour un masque de diapositive et [ILayoutSlide.drawing_guides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ilayoutslide/drawing_guides/) pour une diapositive de mise en page.

L'exemple suivant ajoute un repère vertical au premier masque de diapositive et un repère horizontal à la première diapositive de mise en page :

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide_size = presentation.slide_size.size
    master_guides = presentation.masters[0].drawing_guides
    layout_guides = presentation.layout_slides[0].drawing_guides

    master_guides.add(slides.Orientation.VERTICAL, slide_size.width / 2 - 20)
    layout_guides.add(slides.Orientation.HORIZONTAL, slide_size.height / 2 + 20)

    presentation.save("master-layout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Ajouter des repères aux masques de notes et de prospectus**

Les masques de notes et de prospectus prennent également en charge les repères de dessin. Utilisez [IMasterNotesSlide.drawing_guides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/imasternotesslide/drawing_guides/) et [IMasterHandoutSlide.drawing_guides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/imasterhandoutslide/drawing_guides/) pour accéder à leurs collections. Si une présentation ne contient pas l'un de ces masques, [IMasterNotesSlideManager.set_default_master_notes_slide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/imasternotesslidemanager/set_default_master_notes_slide/) ou [IMasterHandoutSlideManager.set_default_master_handout_slide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/imasterhandoutslidemanager/set_default_master_handout_slide/) crée le masque par défaut et le renvoie.

L'exemple suivant ajoute un repère horizontal à un masque de notes et un repère vertical à un masque de prospectus :

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    notes_size = presentation.notes_size.size
    notes_master = presentation.master_notes_slide_manager.set_default_master_notes_slide()
    handout_master = presentation.master_handout_slide_manager.set_default_master_handout_slide()

    notes_master.drawing_guides.add(slides.Orientation.HORIZONTAL, notes_size.height / 2 + 50)
    handout_master.drawing_guides.add(slides.Orientation.VERTICAL, notes_size.width / 2 - 50)

    presentation.save("notes-handout-drawing-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **Effacer les repères de dessin**

Appelez [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/fr/python-net/aspose.slides/idrawingguidescollection/clear/) pour supprimer tous les repères d'une collection particulière. Effacer une collection n'affecte pas les repères stockés dans une autre portée.

L'exemple suivant efface les repères de la vue de diapositive et tous les repères des masques de diapositives, des diapositives de mise en page, du masque de notes et du masque de prospectus sans créer les masques manquants :

```py
import aspose.slides as slides

with slides.Presentation("presentation-with-guides.pptx") as presentation:
    presentation.view_properties.slide_view_properties.drawing_guides.clear()

    for master_slide in presentation.masters:
        master_slide.drawing_guides.clear()

    for layout_slide in presentation.layout_slides:
        layout_slide.drawing_guides.clear()

    notes_master = presentation.master_notes_slide_manager.master_notes_slide
    if notes_master is not None:
        notes_master.drawing_guides.clear()

    handout_master = presentation.master_handout_slide_manager.master_handout_slide
    if handout_master is not None:
        handout_master.drawing_guides.clear()

    presentation.save("presentation-without-guides.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Les repères de dessin apparaissent-ils dans un diaporama ou des images exportées ?**

Non. Les repères de dessin sont des aides à l'alignement pour l'édition et ne sont pas rendus comme contenu de la présentation.

**Un repère de dessin peut-il être ajouté directement à une diapositive normale individuelle ?**

Les repères d'édition des diapositives normales sont stockés dans les propriétés de vue de diapositive de la présentation. Des collections de repères distinctes sont disponibles pour les masques de diapositives, les diapositives de mise en page, les masques de notes et les masques de prospectus.

**Quelles unités sont utilisées pour les positions des repères ?**

Les positions sont spécifiées en points, où 72 points équivalent à un pouce. Les positions verticales sont mesurées à partir du bord gauche, et les positions horizontales à partir du bord supérieur.

**Effacer les repères de dessin supprime-t-il des formes ou modifie-t-il le contenu de la diapositive ?**

Non. La méthode `clear` supprime uniquement les repères de la collection sélectionnée. Les formes et le reste du contenu de la diapositive restent inchangés.