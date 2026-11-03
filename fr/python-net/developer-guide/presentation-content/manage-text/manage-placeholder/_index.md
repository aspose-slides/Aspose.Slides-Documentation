---
title: Gérer les espaces réservés de présentation en Python
linktitle: Gérer les espaces réservés
type: docs
weight: 10
url: /fr/python-net/manage-placeholder/
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
- Aspose.Slides
description: "Apprenez à inspecter et modifier les espaces réservés de texte, d'image, de graphique et de contenu, et à comprendre l'héritage des espaces réservés avec Aspose.Slides pour Python via .NET."
---
## **Vue d'ensemble**

Un espace réservé est une forme qui réserve une position pour un type particulier de contenu dans un modèle de présentation. Les exemples courants sont les espaces réservés de titre, corps, image, graphique et de contenu à usage général. Contrairement à une forme ordinaire, un espace réservé peut hériter de sa position, de sa taille, de son formatage et d’autres paramètres d’une diapositive de disposition ou d’une diapositive maître.

Aspose.Slides expose les informations d’espace réservé via la propriété [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/). La propriété renvoie un objet [Placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/) ou `None` pour une forme normale. Utilisez [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) pour déterminer ce que l’espace réservé est censé contenir.

La classe de forme reste importante après avoir connu le type d’espace réservé :

- Un espace réservé vide de texte, d’image, de graphique ou de contenu est généralement représenté par un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).
- Un espace réservé d’image déjà renseigné peut être représenté par un [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/).
- Un espace réservé de graphique déjà renseigné peut être représenté par un [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/).
- Un espace réservé de contenu peut contenir plusieurs types de contenu. Vérifiez à la fois [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) et la classe de forme d’exécution au lieu de supposer que chaque espace réservé est un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) décrit le rôle d’un espace réservé ; il ne garantit pas la classe d’exécution de la forme. Utilisez toujours une vérification de type avant d’accéder aux membres texte, image, graphique, tableau ou média spécifiques.
{{% /alert %}}

## **Comprendre l'héritage des espaces réservés**

Les espaces réservés forment une hiérarchie :

1. Une diapositive maître définit des styles réutilisables et, dans certains cas, des espaces réservés au niveau maître.
2. Une diapositive de disposition définit l’agencement utilisé par une ou plusieurs diapositives normales et peut hériter du maître.
3. Une diapositive normale contient les espaces réservés pour cette diapositive et peut hériter de sa disposition.

Appelez [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) pour remonter d’un niveau dans cette hiérarchie. Un espace réservé de diapositive renvoie normalement son espace réservé de disposition ; un espace réservé de disposition peut renvoyer son espace réservé maître. La méthode renvoie `None` lorsque la forme n’a pas d’espace réservé de base.

L’exemple suivant répertorie les espaces réservés de la première diapositive et indique leurs espaces réservés de base :

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        type_name = type(shape).__name__
        print(f"Slide placeholder: {placeholder_type}; shape class: {type_name}")

        layout_placeholder = shape.get_base_placeholder()
        if layout_placeholder is not None:
            layout_placeholder_type = layout_placeholder.placeholder.type if layout_placeholder.placeholder is not None else None
            print(f"  Layout placeholder: {layout_placeholder_type}")

            master_placeholder = layout_placeholder.get_base_placeholder()
            if master_placeholder is not None:
                master_placeholder_type = master_placeholder.placeholder.type if master_placeholder.placeholder is not None else None
                print(f"  Master placeholder: {master_placeholder_type}")
```

Modifier un espace réservé sur une diapositive normale crée ou modifie une substitution locale pour cette diapositive. Modifier la disposition ou le maître associé peut affecter toutes les diapositives qui héritent encore de ce paramètre. Une forme ordinaire locale n’a aucun espace réservé de base et ne commence pas à hériter simplement parce qu’elle occupe les mêmes coordonnées.

## **Supprimer le statut d'espace réservé**

Lors de l’adaptation d’un modèle, utilisez [Shape.remove_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/remove_placeholder/) pour conserver un objet existant comme forme ordinaire. Sa propriété [placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) devient `None`, mais la forme reste dans la collection de la diapositive. En revanche, [ShapeCollection.remove](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/remove/) supprime la forme de cette collection.

L’exemple suivant requiert `template.pptx` contenant au moins une diapositive et un espace réservé de texte non vide sur la première diapositive. Utilisez un espace réservé dont le formatage est hérité de sa disposition ou de son maître pour observer l’effet de la suppression de cette relation. L’exemple vérifie que la même forme subsiste, rappelle la méthode sur la forme maintenant ordinaire, puis enregistre le résultat.

{{% alert color="warning" title="Warning" %}}
Supprimer le statut d’espace réservé ne préserve pas automatiquement les paramètres d’apparence hérités. L’exemple ci‑dessous laisse délibérément ces paramètres inchangés, de sorte que le rendu peut différer. Une forme dont la position et la taille sont entièrement héritées peut se retrouver avec des coordonnées et dimensions nulles après l’appel et devenir invisible même si elle reste dans la collection.
{{% /alert %}}

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    found = False

    for index in range(len(slide.shapes)):
        shape = slide.shapes[index]
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue
        if shape.text_frame is None or not shape.text_frame.text:
            continue

        shape_count = len(slide.shapes)
        shape.remove_placeholder()

        print(f"Placeholder removed: {shape.placeholder is None}")
        print(f"Same shape retained: {slide.shapes[index] == shape}")
        print(f"Shape count unchanged: {len(slide.shapes) == shape_count}")

        # Appeler la méthode sur une forme ordinaire n'a aucun effet.
        shape.remove_placeholder()
        found = True
        break

    if found:
        presentation.save("placeholder-status-removed.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("No nonempty text placeholder was found on the first slide.")
```

Pour un espace réservé correspondant, les trois vérifications affichent `True`. Le texte persiste, mais la position, la taille, la rotation, la police, l’alignement de paragraphe, les marges du cadre texte, l’ancrage vertical, le remplissage et les paramètres de ligne hérités peuvent changer lorsque la relation d’espace réservé est supprimée. Par exemple, le formatage de titre hérité peut retomber sur le formatage de texte ordinaire. Consultez [Slide Layout](/slides/fr/python-net/slide-layout/) pour plus d’informations sur les dispositions.

Pour conserver l’apparence prévue, capturez la position, la taille et la rotation résolues avant l’appel, puis copiez les valeurs de formatage effectif requises dans des variables séparées. Récupérez ces valeurs via [PortionFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/portionformat/get_effective/), [ParagraphFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/get_effective/), [TextFrameFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/get_effective/), [FillFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/get_effective/), et [LineFormat.get_effective](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/get_effective/). Ne vous fiez pas uniquement aux objets de format effectif, car leurs valeurs de formatage de texte peuvent changer après la suppression de la relation. Appliquez explicitement les valeurs capturées à la forme ordinaire ensuite, y compris la famille, la taille, le style, la couleur de police, les paramètres de paragraphe, les paramètres du cadre texte, le remplissage et le trait utilisés par votre modèle.

La géométrie de forme héritée peut également devoir être affectée explicitement via [GeometryShape.shape_type](https://reference.aspose.com/slides/python-net/aspose.slides/geometryshape/shape_type/). Pour un espace réservé de texte rectangulaire, cela signifie affecter [ShapeType.RECTANGLE](https://reference.aspose.com/slides/python-net/aspose.slides/shapetype/); restaurer uniquement le remplissage et le trait peut ne pas restaurer le rectangle visible. Les modèles avec des effets supplémentaires ou un formatage plus complexe nécessitent également la prise en compte de ces paramètres.

## **Modifier le texte dans un espace réservé**

Les espaces réservés de titre, titre centré, sous‑titre, corps et texte prennent normalement en charge le texte. Vérifiez la présence d’un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) avant d’utiliser sa propriété [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/text_frame/).

Cet exemple met à jour le premier espace réservé de titre sur la première diapositive et enregistre le résultat :

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    title_shape = None

    for shape in slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type
        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            title_shape = shape
            break

    if title_shape is None:
        raise RuntimeError("The first slide does not contain a title placeholder.")

    title_shape.text_frame.text = "Quarterly Business Review"
    presentation.save("title-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Ce modèle évite de traiter les espaces réservés d’image, de graphique, de tableau ou de média comme des objets [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/). Il identifie également l’espace réservé par son objectif au lieu de se baser sur un indice de forme fragile.

## **Définir le texte d'invite sur une mise en page**

Le texte d’invite est l’instruction affichée en mode conception dans un espace réservé vide, par exemple *Cliquez pour ajouter un titre*. Définissez un texte d’invite personnalisé sur l’espace réservé de la mise en page plutôt que d’essayer d’y accéder via la collection de formes d’une diapositive normale. Accédez à la mise en page via [Slide.layout_slide](https://reference.aspose.com/slides/python-net/aspose.slides/slide/layout_slide/) et parcourez [LayoutSlide.shapes](https://reference.aspose.com/slides/python-net/aspose.slides/baseslide/shapes/).

L’exemple suivant modifie les invites de titre et de sous‑titre sur la mise en page utilisée par la première diapositive :

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    layout_slide = presentation.slides[0].layout_slide

    for shape in layout_slide.shapes:
        if not isinstance(shape, slides.AutoShape) or shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE):
            shape.text_frame.text = "Enter a concise slide title"
        elif placeholder_type == slides.PlaceholderType.SUBTITLE:
            shape.text_frame.text = "Enter a subtitle or reporting period"

    presentation.save("custom-placeholder-prompts.pptx", slides.export.SaveFormat.PPTX)
```

Le texte d’invite n’est pas du contenu de diapositive normal. Il est destiné aux espaces réservés vides dans les applications de modification telles que PowerPoint. Une fois qu’un utilisateur ou un programme fournit du contenu réel, l’invite n’est plus affichée. Modifier une invite ne remplace pas non plus le texte existant sur les diapositives qui utilisent la mise en page.

## **Mettre à jour un espace réservé d'image**

Il existe deux cas à gérer :

- Si l’espace réservé d’image est déjà renseigné et représenté par un [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/), remplacez l’image via [PictureFillFormat.picture](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/picture/) et [Picture.image](https://reference.aspose.com/slides/python-net/aspose.slides/picture/image/).
- S’il s’agit encore d’un espace réservé vide, ajoutez un cadre image aux coordonnées de l’espace réservé avec [ShapeCollection.add_picture_frame](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_picture_frame/) et supprimez l’espace réservé vide.

L’exemple suivant prend en charge les deux cas et enregistre la présentation :

```python
import aspose.slides as slides

with slides.Presentation("picture-template.pptx") as presentation:
    slide = presentation.slides[0]
    picture_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.PICTURE:
            picture_placeholder = shape
            break

    if picture_placeholder is None:
        raise RuntimeError("The first slide does not contain a picture placeholder.")

    with open("replacement.png", "rb") as image_stream:
        image_bytes = image_stream.read()

    image = presentation.images.add_image(image_bytes)

    if isinstance(picture_placeholder, slides.PictureFrame):
        picture_placeholder.picture_format.picture.image = image
    else:
        slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, picture_placeholder.x, picture_placeholder.y, picture_placeholder.width, picture_placeholder.height, image)
        slide.shapes.remove(picture_placeholder)

    presentation.save("picture-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Le remplacement créé pour un espace réservé vide est un cadre image local, pas un nouvel espace réservé, car [Shape.placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/placeholder/) est en lecture seule. Il conserve la position réservée mais n’hérite plus du comportement propre aux espaces réservés. Si le maintien de la relation d’espace réservé est essentiel, préparez et remplissez d’abord l’espace réservé dans PowerPoint, puis mettez à jour le [PictureFrame](https://reference.aspose.com/slides/python-net/aspose.slides/pictureframe/) résultant avec Aspose.Slides.

Pour la transparence d’image, le recadrage et d’autres effets propres aux images, consultez [Manage Picture Frames](/slides/fr/python-net/picture-frame/). Ces opérations appartiennent au cadre image ou au remplissage image, pas aux métadonnées de l’espace réservé.

## **Travailler avec les espaces réservés de graphiques et de contenu**

Un espace réservé de graphique renseigné peut être représenté par un [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/). Cet exemple trouve un tel graphique en fonction du type d’espace réservé et de la classe d’exécution, modifie son titre et enregistre le fichier :

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("chart-template.pptx") as presentation:
    slide = presentation.slides[0]
    placeholder_chart = None

    for shape in slide.shapes:
        if isinstance(shape, charts.Chart) and shape.placeholder is not None and shape.placeholder.type == slides.PlaceholderType.CHART:
            placeholder_chart = shape
            break

    if placeholder_chart is None:
        raise RuntimeError("The first slide does not contain a populated chart placeholder.")

    placeholder_chart.has_title = True
    placeholder_chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    presentation.save("chart-placeholder-updated.pptx", slides.export.SaveFormat.PPTX)
```

Un espace réservé de contenu général possède généralement [PlaceholderType.OBJECT](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/). Dans PowerPoint, il agit comme un lanceur pour plusieurs types de contenu, notamment les graphiques, tableaux, diagrammes, images et médias. Après l’avoir renseigné, inspectez la classe réelle de la forme pour savoir ce qu’elle contient. Des dispositions spécialisées peuvent également exposer [PlaceholderType.CHART](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.TABLE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.PICTURE](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), [PlaceholderType.MEDIA](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/), ou [PlaceholderType.DIAGRAM](https://reference.aspose.com/slides/python-net/aspose.slides/placeholdertype/).

Aspose.Slides ne convertit pas un [AutoShape](https://reference.aspose.com/slides/python-net/aspose.slides/autoshape/) vide en [Chart](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/) simplement en modifiant [Placeholder.type](https://reference.aspose.com/slides/python-net/aspose.slides/placeholder/type/) ; le type est en lecture seule. Pour remplir programmatique un graphique ou une zone de contenu vide, ajoutez l’objet requis aux coordonnées de l’espace réservé puis supprimez l’espace réservé vide. L’exemple suivant montre cette opération pour un graphique :

```python
import aspose.slides as slides
import aspose.slides.charts as charts

with slides.Presentation("content-template.pptx") as presentation:
    slide = presentation.slides[0]
    target_placeholder = None

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        if shape.placeholder.type in (slides.PlaceholderType.CHART, slides.PlaceholderType.OBJECT):
            target_placeholder = shape
            break

    if target_placeholder is None:
        raise RuntimeError("The first slide does not contain a chart or content placeholder.")

    chart = slide.shapes.add_chart(charts.ChartType.CLUSTERED_COLUMN, target_placeholder.x, target_placeholder.y, target_placeholder.width, target_placeholder.height)
    chart.has_title = True
    chart.chart_title.add_text_frame_for_overriding("Quarterly Revenue")
    slide.shapes.remove(target_placeholder)
    presentation.save("content-placeholder-replaced-with-chart.pptx", slides.export.SaveFormat.PPTX)
```

Le graphique ajouté est un graphique local ordinaire. Il occupe la zone de l’espace réservé mais n’hérite pas de la disposition de l’espace réservé. Utilisez les articles dédiés à la gestion des graphiques [chart management articles](/slides/fr/python-net/powerpoint-charts/) lorsque vous devez remplacer ses catégories, séries ou données de classeur.

## **Exemple complet : mettre à jour le texte ou le contenu image**

L’exemple de bout en bout suivant ouvre un modèle, recherche la première diapositive pour un espace réservé de titre ou d’image, vérifie les types d’espace réservé et de forme, met à jour le contenu approprié et enregistre le résultat. L’exemple évite délibérément de supposer un indice de forme ou de traiter chaque espace réservé comme la même classe de forme.

```python
import aspose.slides as slides

with slides.Presentation("template.pptx") as presentation:
    slide = presentation.slides[0]
    updated = False

    for shape in slide.shapes:
        if shape.placeholder is None:
            continue

        placeholder_type = shape.placeholder.type

        if placeholder_type in (slides.PlaceholderType.TITLE, slides.PlaceholderType.CENTERED_TITLE) and isinstance(shape, slides.AutoShape):
            shape.text_frame.text = "Quarterly Business Review"
            updated = True
            break

        if placeholder_type == slides.PlaceholderType.PICTURE:
            with open("replacement.png", "rb") as image_stream:
                image_bytes = image_stream.read()

            image = presentation.images.add_image(image_bytes)

            if isinstance(shape, slides.PictureFrame):
                shape.picture_format.picture.image = image
            else:
                slide.shapes.add_picture_frame(slides.ShapeType.RECTANGLE, shape.x, shape.y, shape.width, shape.height, image)
                slide.shapes.remove(shape)

            updated = True
            break

    if not updated:
        raise RuntimeError("No supported title or picture placeholder was found on the first slide.")

    presentation.save("placeholder-content-updated.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Qu'est‑ce qu'un espace réservé de base ?**

Un espace réservé de base est la forme correspondante sur la disposition ou le maître dont hérite un autre espace réservé. Utilisez [Shape.get_base_placeholder](https://reference.aspose.com/slides/python-net/aspose.slides/shape/get_base_placeholder/) pour le récupérer. Une forme locale ordinaire renvoie `None` car elle ne fait pas partie de la hiérarchie d’espaces réservés.

**Puis‑je modifier tous les titres de diapositives en modifiant un espace réservé de disposition ?**

Vous pouvez modifier le formatage ou le texte d’invite hérité via une disposition, mais le contenu réel des titres est stocké sur les diapositives normales. Pour remplacer le texte des titres dans toute la présentation, parcourez les diapositives et mettez à jour chaque espace réservé de titre.

**Comment gérer les espaces réservés de date, numéro de diapositive, en‑tête et pied de page ?**

Utilisez les gestionnaires d’en‑tête et de pied de page au niveau de la diapositive, de la disposition, du maître, des notes ou du livret. Consultez [Manage Presentation Header and Footer](/slides/fr/python-net/presentation-header-and-footer/) pour des exemples complets.