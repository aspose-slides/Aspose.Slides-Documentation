---
title: Gérer les maîtres de diapositives de présentation en Python
linktitle: Diapos maître
type: docs
weight: 80
url: /fr/python-net/slide-master/
keywords:
- maître de diapositive
- diapositive maître
- diapositive maître PPT
- plusieurs diapositives maîtres
- comparer les diapositives maîtres
- arrière-plan
- espace réservé
- cloner la diapositive maître
- copier la diapositive maître
- dupliquer la diapositive maître
- diapositive maître inutilisée
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Gérer les maîtres de diapositives dans Aspose.Slides pour Python via .NET : accéder, modifier, cloner, comparer et supprimer les diapositives maîtres dans les présentations PowerPoint et OpenDocument."
---
## **Vue d'ensemble**

Un **slide master** définit des paramètres de conception partagés pour un groupe de diapositives. Il peut contenir des formes communes, des logos, des arrière-plans, des styles de texte, des paramètres de thème et des paramètres de pied de page. Dans PowerPoint, modifier un slide master est la façon habituelle de garantir la cohérence d’une présentation sans répéter le même formatage sur chaque diapositive.

Aspose.Slides for Python via .NET prend en charge le même modèle. Une présentation peut contenir une ou plusieurs diapositives maîtres, et chaque diapositive maître peut contenir plusieurs diapositives de mise en page. Les diapositives normales ne font généralement pas directement référence à une diapositive maître. Au lieu de cela, une diapositive normale utilise une diapositive de mise en page, et cette diapositive de mise en page appartient à une diapositive maître.

La hiérarchie est :

1. **Slide master** - définit la conception et le thème partagés.
1. **Layout slide** - définit une disposition spécifique de zones réservées et de formatage au niveau de la mise en page.
1. **Normal slide** - contient le contenu réel de la présentation et utilise une diapositive de mise en page.

![La hiérarchie des diapositives maîtres, des diapositives de mise en page et des diapositives normales](slide-master_2.jpg)

Dans Aspose.Slides, un slide master est représenté par la classe [MasterSlide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterslide/). Toutes les diapositives maîtres d’une présentation sont accessibles via la collection `Presentation.masters`.

{{% alert color="info" title="Héritage" %}}
Lorsque la même propriété est définie à plusieurs niveaux, le niveau le plus spécifique l’emporte. Par exemple, si une diapositive maître et une diapositive de mise en page définissent toutes deux un arrière‑plan, les diapositives basées sur cette mise en page utilisent l’arrière‑plan de la mise en page. Pour plus d’informations sur les diapositives de mise en page, consultez [Apply or Change Slide Layouts](/slides/fr/python-net/slide-layout/).
{{% /alert %}}

## **Accéder aux Slide Masters**

Dans PowerPoint, vous pouvez ouvrir la vue Slide Master via **View** > **Slide Master**.

![La commande Slide Master dans l’onglet Affichage de PowerPoint](slide-master_3.jpg)

Dans Aspose.Slides, utilisez la collection `masters` pour accéder aux diapositives maîtres :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

Vous pouvez également obtenir la diapositive maître utilisée par une diapositive normale via sa mise en page :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Ce que contient un Slide Master**

Une diapositive maître est un objet similaire à une diapositive. Elle hérite du comportement commun des diapositives depuis la classe [BaseSlide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseslide/), ce qui lui donne accès à de nombreuses propriétés de diapositive utilisées par les diapositives normales et de mise en page. Les membres spécifiques aux maîtres sont répertoriés sur la page d’API [MasterSlide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterslide/).

Les membres de slide master les plus couramment utilisés incluent :

| Membre | Objectif |
| --- | --- |
| `background` | Définit l’arrière‑plan de la diapositive au niveau du maître. |
| `shapes` | Stocke les formes placées sur le maître, telles que les logos, les cadres d’image et le texte partagé. |
| `layout_slides` | Stocke les diapositives de mise en page qui appartiennent au maître. |
| `theme_manager` | Fournit l’accès aux API du thème du maître. |
| `header_footer_manager` | Contrôle les en‑têtes, pieds de page, dates et numéros de diapositive pour le maître et ses mises en page enfants. |
| `get_depending_slides` | Renvoie les diapositives normales qui dépendent du maître via leurs mises en page. |

## **Ajouter une image à un Slide Master**

Lorsque vous ajoutez une image à une diapositive maître, elle apparaît sur les diapositives qui utilisent les mises en page de ce maître. C’est pratique pour les logos, filigranes, bandes décoratives et autres éléments visuels répétés.

L’exemple suivant ajoute un logo à la première diapositive maître :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    with open("logo.png", "rb") as logo_stream:
        logo_bytes = logo_stream.read()

    logo_image = presentation.images.add_image(logo_bytes)

    master_slide.shapes.add_picture_frame(
        slides.ShapeType.RECTANGLE,
        20,
        20,
        80,
        80,
        logo_image)

    presentation.save("presentation-with-logo.pptx", slides.export.SaveFormat.PPTX)
```

Pour plus d’informations sur les cadres d’image, consultez [Picture Frame](/slides/fr/python-net/picture-frame/).

## **Travailler avec les zones réservées**

Les zones réservées sont généralement définies sur les diapositives de mise en page. Le slide master fournit le style et le thème partagés que ces mises en page héritent, tandis que chaque mise en page décide quelles zones réservées sont disponibles et où elles sont placées.

Dans PowerPoint, les commandes de zone réservée sont disponibles en mode Slide Master.

![La commande Insérer une zone réservée dans la vue Slide Master de PowerPoint](slide-master_5.png)

Pour ajouter de nouvelles zones réservées avec Aspose.Slides, travaillez sur la diapositive de mise en page qui appartient au maître :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    blank_layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout_slide is None:
        blank_layout_slide = presentation.layout_slides.add(
            master_slide,
            slides.SlideLayoutType.BLANK,
            "Blank")

    blank_layout_slide.placeholder_manager.add_text_placeholder(60, 120, 600, 80)

    presentation.slides.add_empty_slide(blank_layout_slide)
    presentation.save("presentation-with-placeholder.pptx", slides.export.SaveFormat.PPTX)
```

Vous pouvez également mettre en forme les formes de zones réservées déjà présentes sur une diapositive maître. L’exemple suivant trouve la zone réservée du titre et applique un remplissage en dégradé linéaire :

```python
import aspose.pydrawing as draw
import aspose.slides as slides


def find_placeholder(master_slide, placeholder_type):
    for shape in master_slide.shapes:
        if isinstance(shape, slides.AutoShape) and shape.placeholder is not None:
            if shape.placeholder.type == placeholder_type:
                return shape

    return None


with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]
    title_placeholder = find_placeholder(master_slide, slides.PlaceholderType.TITLE)

    if title_placeholder is not None:
        red_gradient_color = draw.Color.from_argb(255, 0, 0)
        purple_gradient_color = draw.Color.from_argb(128, 0, 128)

        title_placeholder.fill_format.fill_type = slides.FillType.GRADIENT
        title_placeholder.fill_format.gradient_format.gradient_shape = slides.GradientShape.LINEAR
        title_placeholder.fill_format.gradient_format.gradient_stops.add(0, red_gradient_color)
        title_placeholder.fill_format.gradient_format.gradient_stops.add(1, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Zone réservée titre formatée héritée par les diapositives normales](slide-master_8.png)

Pour plus d’options de mise en forme des zones réservées et du texte, consultez [Set Prompt Text in Placeholder](/slides/fr/python-net/manage-placeholder/) et [Text Formatting](/slides/fr/python-net/text-formatting/).

## **Modifier l’arrière‑plan d’un Slide Master**

Un arrière‑plan maître est hérité par les mises en page et les diapositives qui ne le remplacent pas. L’exemple suivant définit une couleur d’arrière‑plan unie pour la première diapositive maître :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    master_slide = presentation.masters[0]

    master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    master_slide.background.fill_format.solid_fill_color.color = draw.Color.forest_green

    presentation.save("presentation-master-background.pptx", slides.export.SaveFormat.PPTX)
```

Pour des sujets connexes, consultez [Presentation Background](/slides/fr/python-net/presentation-background/) et [Presentation Theme](/slides/fr/python-net/presentation-theme/).

## **Cloner un Slide Master dans une autre présentation**

Utilisez la méthode `add_clone` sur la classe [MasterSlideCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterslidecollection/) pour copier une diapositive maître dans une autre présentation. Le maître copié peut alors être utilisé par les mises en page et les diapositives de la présentation cible.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Si vous devez cloner des diapositives normales avec leur maître, consultez [Clone Slides](/slides/fr/python-net/clone-slides/).

## **Ajouter plusieurs Slide Masters**

Une présentation peut contenir plusieurs diapositives maîtres. C’est utile lorsque différentes sections nécessitent une identité visuelle, une structure de page ou des paramètres de thème différents.

![Commandes PowerPoint pour insérer et gérer les diapositives maîtres](slide-master_9.jpg)

L’exemple suivant clone le maître par défaut, donne au clone un arrière‑plan différent, obtient une mise en page vierge sous ce maître cloné, puis ajoute une nouvelle diapositive basée sur cette mise en page :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    default_master_slide = presentation.masters[0]
    section_master_slide = presentation.masters.add_clone(default_master_slide)

    section_master_slide.background.type = slides.BackgroundType.OWN_BACKGROUND
    section_master_slide.background.fill_format.fill_type = slides.FillType.SOLID
    section_master_slide.background.fill_format.solid_fill_color.color = draw.Color.light_steel_blue

    section_blank_layout = section_master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if section_blank_layout is None:
        section_blank_layout = presentation.layout_slides.add(
            section_master_slide,
            slides.SlideLayoutType.BLANK,
            "Section Blank")

    presentation.slides.add_empty_slide(section_blank_layout)
    presentation.save("presentation-with-multiple-masters.pptx", slides.export.SaveFormat.PPTX)
```

## **Comparer les Slide Masters**

Les diapositives maîtres peuvent être comparées avec la méthode `equals` héritée de la classe [BaseSlide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseslide/). La comparaison vérifie la structure et le contenu statique, tels que les formes, le texte, la mise en forme, les animations et d’autres paramètres de diapositive. Elle ne compare pas les identifiants uniques, comme les IDs de diapositive, ni les valeurs dynamiques des zones réservées, comme la date actuelle.

```python
import aspose.slides as slides

with slides.Presentation("first.pptx") as first_presentation:
    with slides.Presentation("second.pptx") as second_presentation:
        first_presentation_master_count = len(first_presentation.masters)
        second_presentation_master_count = len(second_presentation.masters)

        for first_master_index in range(first_presentation_master_count):
            for second_master_index in range(second_presentation_master_count):
                first_master_slide = first_presentation.masters[first_master_index]
                second_master_slide = second_presentation.masters[second_master_index]
                are_master_slides_equal = first_master_slide.equals(second_master_slide)

                if are_master_slides_equal:
                    print(
                        "first.pptx master #{} equals second.pptx master #{}".format(
                            first_master_index,
                            second_master_index))
```

Pour plus d’informations, consultez [Compare Presentation Slides](/slides/fr/python-net/compare-slides/).

## **Définir la vue Slide Master comme vue par défaut**

Utilisez la propriété `last_view` sur l’objet [ViewProperties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/viewproperties/) de la présentation pour contrôler la vue que PowerPoint ouvre en premier. L’exemple suivant ouvre la présentation en vue Slide Master :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Pour plus de paramètres d’affichage, consultez [Save Presentation](/slides/fr/python-net/save-presentation/).

## **Supprimer les Slide Masters inutilisés**

Les présentations contiennent parfois des diapositives maîtres qui ne sont plus utilisées par aucune diapositive normale. Supprimer les maîtres inutilisés peut réduire la taille du fichier et simplifier la maintenance du modèle.

Utilisez `remove_unused` pour supprimer les maîtres inutilisés de la collection `masters` :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.masters.remove_unused(True)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

Vous pouvez également utiliser la méthode low‑code `remove_unused_master_slides` de la classe [Compress](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/compress/) :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_master_slides(presentation)
    presentation.save("presentation-clean.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

### Quelle est la différence entre un slide master et une diapositive de mise en page ?

Un slide master définit les paramètres de conception partagés tels que le thème, l’arrière‑plan, les formes communes et les styles de texte. Une diapositive de mise en page appartient à un slide master et définit une disposition spécifique de zones réservées. Une diapositive normale utilise une diapositive de mise en page, et hérite ainsi à la fois de la mise en page et du maître.

### Une présentation peut‑elle contenir plusieurs slide masters ?

Oui. Une présentation peut contenir plusieurs slide masters. Utilisez plusieurs maîtres lorsque différentes sections nécessitent des systèmes visuels ou une identité de marque différents.

### Dois‑je ajouter des zones réservées à une diapositive maître ou à une diapositive de mise en page ?

Dans la plupart des cas, ajoutez les zones réservées aux diapositives de mise en page. Placez les éléments visuels partagés et le formatage commun sur le slide master, puis placez les zones réservées de contenu sur les mises en page que les diapositives normales utiliseront.

### Puis‑je supprimer une diapositive maître qui est encore utilisée ?

Non. Une diapositive maître qui possède des diapositives dépendantes ne peut pas être supprimée en toute sécurité. Déplacez d’abord ces diapositives vers des mises en page d’un autre maître, ou utilisez une méthode de nettoyage des maîtres inutilisés qui ne supprime que les maîtres qui ne sont pas en cours d’utilisation.