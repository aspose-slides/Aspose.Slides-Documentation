---
title: Gérer les espaces réservés de présentation en Python
linktitle: Gérer les espaces réservés
type: docs
weight: 10
url: /fr/python-java/manage-placeholder/
keywords:
- espace réservé
- espace réservé de texte
- espace réservé d'image
- espace réservé de graphique
- espace réservé de contenu
- texte d'invite
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Apprenez à inspecter et modifier les espaces réservés de texte, d'image, de graphique et de contenu, et à comprendre l'héritage des espaces réservés avec Aspose.Slides pour Python via Java."
---
## **Vue d'ensemble**

Un espace réservé est une forme qui réserve une position pour un type particulier de contenu dans un modèle de présentation. Les exemples courants sont les espaces réservés de titre, de corps, d'image, de graphique et les espaces réservés de contenu à usage général. Contrairement à une forme ordinaire, un espace réservé peut hériter de sa position, de sa taille, de son formatage et d'autres paramètres d'une diapositive de mise en page ou d'une diapositive maîtresse.

Aspose.Slides expose les informations d'espace réservé via la méthode [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder). La méthode renvoie un objet [Placeholder](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/) ou `None` pour une forme normale. Utilisez [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) pour déterminer ce que l'espace réservé est censé contenir.

Le type de forme reste important après avoir connu le type d'espace réservé :

- Un espace réservé vide de texte, d'image, de graphique ou de contenu est généralement représenté par un [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/).
- Un espace réservé d'image rempli peut être représenté par un [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/).
- Un espace réservé de graphique rempli peut être représenté par un [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/).
- Un espace réservé de contenu peut contenir plusieurs types de contenu. Vérifiez à la fois [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) et le type de forme à l'exécution au lieu de supposer que chaque espace réservé est un [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) décrit le rôle d'un espace réservé ; il ne garantit pas le type de forme à l'exécution. Utilisez toujours une vérification de type avant d'accéder aux membres spécifiques au texte, à l'image, au graphique, au tableau ou aux médias.
{{% /alert %}}

## **Comprendre l'héritage des espaces réservés**

Les espaces réservés forment une hiérarchie :

1. Une diapositive maîtresse définit des styles réutilisables et, dans certains cas, des espaces réservés au niveau du maître.
2. Une diapositive de mise en page définit l'agencement utilisé par une ou plusieurs diapositives normales et peut hériter du maître.
3. Une diapositive normale contient les espaces réservés pour cette diapositive et peut hériter de sa mise en page.

Appelez [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) pour remonter d'un niveau dans cette hiérarchie. Un espace réservé de diapositive renvoie normalement son espace réservé de mise en page ; un espace réservé de mise en page peut renvoyer son espace réservé maître. La méthode renvoie `None` lorsque la forme n'a aucun espace réservé de base.

L'exemple suivant répertorie les espaces réservés sur la première diapositive et indique leurs espaces réservés de base :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        type_name = shape.getClass().getSimpleName()
        print(f"Slide placeholder: {placeholder_type}; shape type: {type_name}")

        layout_placeholder = shape.getBasePlaceholder()
        if layout_placeholder is not None:
            layout_placeholder_info = layout_placeholder.getPlaceholder()
            layout_placeholder_type = None if layout_placeholder_info is None else layout_placeholder_info.getType()
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.getBasePlaceholder()
            if master_placeholder is not None:
                master_placeholder_info = master_placeholder.getPlaceholder()
                master_placeholder_type = None if master_placeholder_info is None else master_placeholder_info.getType()
                print(f"  Master placeholder: {master_placeholder_type}")
finally:
    presentation.dispose()
```

Modifier un espace réservé sur une diapositive normale crée ou modifie une substitution locale pour cette diapositive. Modifier la mise en page ou le maître associé peut affecter toutes les diapositives qui héritent encore de ce paramètre. Une forme ordinaire locale n'a aucun espace réservé de base et ne commence pas à hériter simplement parce qu'elle occupe les mêmes coordonnées.

## **Supprimer le statut d'espace réservé**

Lors de l'adaptation d'un modèle, utilisez [Shape.removePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#removePlaceholder) pour garder un objet existant comme forme ordinaire. Sa méthode [getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) renvoie `None`, mais la forme reste dans la collection de la diapositive. En revanche, [ShapeCollection.remove](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#remove) supprime la forme de cette collection.

L'exemple suivant nécessite `template.pptx` contenant au moins une diapositive et un espace réservé de texte non vide sur la première diapositive. Utilisez un espace réservé avec un formatage hérité de sa mise en page ou de son maître pour voir l'effet de la suppression de cette relation. L'exemple vérifie que la même forme demeure, appelle à nouveau la méthode sur la forme désormais ordinaire, puis enregistre le résultat.

{{% alert color="warning" title="Warning" %}}
Supprimer le statut d'espace réservé ne préserve pas automatiquement les paramètres d'apparence hérités. L'exemple ci‑dessous laisse délibérément ces paramètres inchangés, de sorte que la sortie peut sembler différente. Une forme dont la position et la taille sont entièrement héritées peut se retrouver avec des coordonnées et des dimensions nulles après l'appel et devenir invisible même si elle reste dans la collection.
{{% /alert %}}

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    found = False

    for index in range(slide.getShapes().size()):
        shape = slide.getShapes().get_Item(index)
        if not isinstance(shape, AutoShape):
            continue

        text_frame = shape.getTextFrame()
        if shape.getPlaceholder() is None or text_frame is None:
            continue
        text = text_frame.getText()
        if text is None or len(text) == 0:
            continue

        shape_count = slide.getShapes().size()
        shape.removePlaceholder()

        print(f"Placeholder removed: {shape.getPlaceholder() is None}")
        print(f"Same shape retained: {slide.getShapes().get_Item(index) == shape}")
        print(f"Shape count unchanged: {slide.getShapes().size() == shape_count}")

        # Appeler la méthode sur une forme ordinaire n'a aucun effet.
        shape.removePlaceholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", SaveFormat.Pptx)
    else:
        print("No nonempty text placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

Pour un espace réservé correspondant, les trois vérifications affichent `True`. Le texte reste, mais la position, la taille, la rotation, la police, l'alignement du paragraphe, les marges du cadre de texte, l'ancrage vertical, le remplissage et les paramètres de ligne hérités peuvent changer lorsque la relation d'espace réservé est supprimée. Par exemple, le formatage de titre hérité peut retomber sur le formatage de texte ordinaire. Consultez [Slide Layout](/slides/fr/python-java/slide-layout/) pour plus d'informations sur les mises en page.

Pour préserver l'apparence voulue, capturez la position, la taille et la rotation résolues avant l'appel, puis copiez les valeurs de formatage effectif requises dans des variables distinctes. Récupérez ces valeurs via [PortionFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/portionformat/#getEffective), [ParagraphFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#getEffective), [TextFrameFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/textframeformat/#getEffective), [FillFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getEffective) et [LineFormat.getEffective](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getEffective). Ne vous fiez pas uniquement aux objets de formatage effectif, car leurs valeurs de formatage de texte peuvent changer après la suppression de la relation. Appliquez explicitement les valeurs capturées à la forme ordinaire par la suite, incluant la famille, la taille, le style et la couleur de police, les paramètres de paragraphe, les paramètres du cadre de texte, le remplissage et la ligne utilisés par votre modèle.

La géométrie de forme héritée peut également devoir être affectée explicitement via [GeometryShape.setShapeType](https://reference.aspose.com/slides/python-java/aspose.slides/geometryshape/#setShapeType). Pour un espace réservé de texte rectangulaire, cela signifie affecter [ShapeType.Rectangle](https://reference.aspose.com/slides/python-java/aspose.slides/shapetype/#Rectangle) ; ne restaurer que le remplissage et la ligne peut ne pas restaurer le rectangle visible. Les modèles avec des effets supplémentaires ou un formatage plus complexe nécessitent également la prise en charge de ces paramètres.

## **Modifier le texte d'un espace réservé**

Les espaces réservés de titre, de titre centré, de sous‑titre, de corps et de texte supportent généralement le texte. Vérifiez la présence d'un [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) avant d'utiliser sa méthode [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/#getTextFrame).

Cet exemple met à jour le premier espace réservé de titre sur la première diapositive et enregistre le résultat :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    title_shape = None

    for shape in slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            title_shape = shape
            break

    if title_shape is None:
        print("The first slide does not contain a title placeholder.")
    else:
        title_shape.getTextFrame().setText("Quarterly Business Review")
        presentation.save("title-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ce modèle évite de traiter les espaces réservés d'image, de graphique, de tableau ou de média comme des [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/). Il identifie également l'espace réservé par son objectif au lieu de s'appuyer sur un indice de forme fragile.

## **Définir le texte d'invite sur une mise en page**

Le texte d'invite est l'instruction affichée en mode conception dans un espace réservé vide, par exemple *Cliquez pour ajouter un titre*. Définissez un texte d'invite personnalisé sur l'espace réservé de mise en page plutôt que d'essayer d'y accéder via la collection de formes d'une diapositive normale. Accédez à la mise en page via [Slide.getLayoutSlide](https://reference.aspose.com/slides/python-java/aspose.slides/slide/#getLayoutSlide) et parcourez la collection renvoyée par [BaseSlide.getShapes](https://reference.aspose.com/slides/python-java/aspose.slides/baseslide/#getShapes).

L'exemple suivant modifie les invites de titre et de sous‑titre sur la mise en page utilisée par la première diapositive :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PlaceholderType, SaveFormat

presentation = Presentation("template.pptx")
try:
    layout_slide = presentation.getSlides().get_Item(0).getLayoutSlide()

    for shape in layout_slide.getShapes():
        if not isinstance(shape, AutoShape):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle):
            shape.getTextFrame().setText("Enter a concise slide title")
        elif placeholder_type == PlaceholderType.Subtitle:
            shape.getTextFrame().setText("Enter a subtitle or reporting period")

    presentation.save("custom-placeholder-prompts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le texte d'invite n'est pas un contenu de diapositive normal. Il est destiné aux espaces réservés vides dans les applications d'édition comme PowerPoint. Une fois qu'un utilisateur ou un programme fournit du contenu réel, l'invite n'est plus affichée. Modifier une invite ne remplace pas non plus le texte existant sur les diapositives qui utilisent la mise en page.

## **Mettre à jour un espace réservé d'image**

Il existe deux cas à gérer :

- Si l'espace réservé d'image est déjà rempli et représenté par un [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/), remplacez l'image via [PictureFillFormat.getPicture](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillformat/#getPicture) et [Picture.setImage](https://reference.aspose.com/slides/python-java/aspose.slides/picture/#setImage).
- S'il s'agit encore d'un espace réservé vide, ajoutez un cadre d'image aux coordonnées de l'espace réservé avec [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addPictureFrame) et supprimez l'espace réservé vide.

L'exemple suivant prend en charge les deux cas et enregistre la présentation :

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("picture-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    picture_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Picture:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        print("The first slide does not contain a picture placeholder.")
    else:
        image_bytes = Path("replacement.png").read_bytes()
        java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
        image = presentation.getImages().addImage(java_image_bytes)

        if isinstance(picture_placeholder, PictureFrame):
            picture_placeholder.getPictureFormat().getPicture().setImage(image)
        else:
            slide.getShapes().addPictureFrame(ShapeType.Rectangle, picture_placeholder.getX(), picture_placeholder.getY(), picture_placeholder.getWidth(), picture_placeholder.getHeight(), image)
            slide.getShapes().remove(picture_placeholder)

        presentation.save("picture-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le remplacement créé pour un espace réservé vide est un cadre d'image local, pas un nouvel espace réservé, car [Shape.getPlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getPlaceholder) ne propose pas de setter. Il conserve la position réservée mais n'hérite plus du comportement spécifique à l'espace réservé. Si le maintien de la relation d'espace réservé est essentiel, préparez et remplissez l'espace réservé dans PowerPoint d'abord, puis mettez à jour le [PictureFrame](https://reference.aspose.com/slides/python-java/aspose.slides/pictureframe/) résultant avec Aspose.Slides.

Pour la transparence d'image, le recadrage et d'autres effets spécifiques aux images, consultez [Manage Picture Frames](/slides/fr/python-java/picture-frame/). Ces opérations appartiennent au cadre d'image ou au remplissage d'image, pas aux métadonnées de l'espace réservé.

## **Travailler avec les espaces réservés de graphique et de contenu**

Un espace réservé de graphique rempli peut être représenté par un [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/). Cet exemple trouve un tel graphique en fonction à la fois du type d'espace réservé et du type d'exécution, modifie son titre et enregistre le fichier :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Chart, PlaceholderType, SaveFormat

presentation = Presentation("chart-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    placeholder_chart = None

    for shape in slide.getShapes():
        if not isinstance(shape, Chart):
            continue

        placeholder = shape.getPlaceholder()
        if placeholder is not None and placeholder.getType() == PlaceholderType.Chart:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        print("The first slide does not contain a populated chart placeholder.")
    else:
        placeholder_chart.setTitle(True)
        placeholder_chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        presentation.save("chart-placeholder-updated.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Un espace réservé de contenu général possède généralement [PlaceholderType.Object](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Object). Dans PowerPoint, il agit comme un lanceur pour plusieurs types de contenu, y compris les graphiques, les tableaux, les diagrammes, les images et les médias. Une fois rempli, inspectez le type de forme réel pour savoir ce qu'il contient. Des mises en page spécialisées peuvent également exposer [PlaceholderType.Chart](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Media) ou [PlaceholderType.Diagram](https://reference.aspose.com/slides/python-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides ne convertit pas un espace réservé [AutoShape](https://reference.aspose.com/slides/python-java/aspose.slides/autoshape/) vide en [Chart](https://reference.aspose.com/slides/python-java/aspose.slides/chart/) simplement en modifiant [Placeholder.getType](https://reference.aspose.com/slides/python-java/aspose.slides/placeholder/#getType) ; le type ne peut pas être changé via l'API. Pour remplir programmatique un graphique ou une zone de contenu vide, ajoutez l'objet requis aux coordonnées de l'espace réservé, puis supprimez l'espace réservé vide. L'exemple suivant le fait pour un graphique :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PlaceholderType, ChartType, SaveFormat

presentation = Presentation("content-template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    target_placeholder = None

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Chart, PlaceholderType.Object):
            target_placeholder = shape
            break

    if target_placeholder is None:
        print("The first slide does not contain a chart or content placeholder.")
    else:
        chart = slide.getShapes().addChart(ChartType.ClusteredColumn, target_placeholder.getX(), target_placeholder.getY(), target_placeholder.getWidth(), target_placeholder.getHeight())
        chart.setTitle(True)
        chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue")
        slide.getShapes().remove(target_placeholder)
        presentation.save("content-placeholder-replaced-with-chart.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le graphique ajouté est un graphique local ordinaire. Il occupe la zone de l'espace réservé mais n'hérite pas du espace réservé de mise en page. Utilisez les [chart management articles](/slides/fr/python-java/powerpoint-charts/) dédiés lorsque vous devez remplacer ses catégories, séries ou données de classeur.

## **Exemple complet : mettre à jour le texte ou le contenu image**

L'exemple de bout en bout suivant ouvre un modèle, recherche la première diapositive pour un espace réservé de titre ou d'image, vérifie les types d'espace réservé et de forme, met à jour le contenu approprié et enregistre le résultat. L'exemple évite délibérément de supposer un indice de forme ou de traiter chaque espace réservé comme le même type.

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, AutoShape, PictureFrame, PlaceholderType, ShapeType, SaveFormat

presentation = Presentation("template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    updated = False

    for shape in slide.getShapes():
        placeholder = shape.getPlaceholder()
        if placeholder is None:
            continue

        placeholder_type = placeholder.getType()
        if placeholder_type in (PlaceholderType.Title, PlaceholderType.CenteredTitle) and isinstance(shape, AutoShape):
            shape.getTextFrame().setText("Quarterly Business Review")
            updated = True
            break

        if placeholder_type == PlaceholderType.Picture:
            image_bytes = Path("replacement.png").read_bytes()
            java_image_bytes = jpype.JArray(jpype.JByte)(image_bytes)
            image = presentation.getImages().addImage(java_image_bytes)

            if isinstance(shape, PictureFrame):
                shape.getPictureFormat().getPicture().setImage(image)
            else:
                slide.getShapes().addPictureFrame(ShapeType.Rectangle, shape.getX(), shape.getY(), shape.getWidth(), shape.getHeight(), image)
                slide.getShapes().remove(shape)

            updated = True
            break

    if updated:
        presentation.save("placeholder-content-updated.pptx", SaveFormat.Pptx)
    else:
        print("No supported title or picture placeholder was found on the first slide.")
finally:
    presentation.dispose()
```

## **FAQ**

**Qu'est‑ce qu'un espace réservé de base ?**

Un espace réservé de base est la forme correspondante sur la mise en page ou le maître dont hérite un autre espace réservé. Utilisez [Shape.getBasePlaceholder](https://reference.aspose.com/slides/python-java/aspose.slides/shape/#getBasePlaceholder) pour le récupérer. Une forme locale ordinaire renvoie `None` car elle ne fait pas partie de la hiérarchie des espaces réservés.

**Puis‑je modifier tous les titres de diapositives en éditant un espace réservé de mise en page ?**

Vous pouvez modifier le formatage hérité ou le texte d'invite via une mise en page, mais le contenu du titre existant est stocké sur les diapositives normales. Pour remplacer le texte réel des titres dans toute la présentation, parcourez les diapositives et mettez à jour chaque espace réservé de titre.

**Comment gérer les espaces réservés de date, numéro de diapositive, en‑tête et pied de page ?**

Utilisez les gestionnaires d'en‑tête et de pied de page au niveau de la diapositive, de la mise en page, du maître, des notes ou du mode aperçu. Consultez [Manage Presentation Header and Footer](/slides/fr/python-java/presentation-header-and-footer/) pour des exemples complets.