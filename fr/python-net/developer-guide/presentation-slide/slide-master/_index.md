---
title: Gérer les masters de diapositives de présentation en Python
linktitle: Master de diapositive
type: docs
weight: 80
url: /fr/python-net/slide-master/
keywords:
- master de diapositive
- diapositive maître
- diapositive maître PPT
- plusieurs masters de diapositives
- comparer les masters de diapositives
- arrière-plan
- espace réservé
- cloner la diapositive maître
- copier la diapositive maître
- dupliquer la diapositive maître
- master de diapositive inutilisé
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Gérez les masters de diapositives dans Aspose.Slides pour Python via .NET : accédez, modifiez, clonez, comparez et supprimez les masters de diapositives dans les présentations PowerPoint et OpenDocument."
---
## **Vue d'ensemble**

Un **slide master** définit des paramètres de conception partagés pour un groupe de diapositives. Il peut contenir des formes communes, des logos, des arrière‑plans, des styles de texte, des paramètres de thème et des paramètres de pied de page. Dans PowerPoint, modifier un slide master est la façon habituelle de maintenir la cohérence d’une présentation sans répéter le même formatage sur chaque diapositive.

Aspose.Slides for Python via .NET prend en charge le même modèle. Une présentation peut contenir une ou plusieurs master slides, et chaque master slide peut contenir plusieurs layout slides. Les diapositives normales ne font généralement pas référence directement à une master slide. Au lieu de cela, une diapositive normale utilise une layout slide, et cette layout slide appartient à une master slide.

La hiérarchie est :

1. **Slide master** – définit la conception et le thème partagés.  
1. **Layout slide** – définit un agencement spécifique d’espaces réservés et de formatage au niveau de la disposition.  
1. **Normal slide** – contient le contenu réel de la présentation et utilise une layout slide.

![La hiérarchie des master slides, layout slides et slides normales](slide-master_2.jpg)

Dans Aspose.Slides, un slide master est représenté par la classe [MasterSlide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterslide/). Toutes les master slides d’une présentation sont accessibles via la collection `Presentation.masters`.

{{% alert color="info" title="Héritage" %}}
Lorsque la même propriété est définie à plusieurs niveaux, le niveau le plus spécifique l’emporte. Par exemple, si une master slide et une layout slide définissent toutes deux un arrière‑plan, les diapositives basées sur cette disposition utilisent l’arrière‑plan de la disposition. Pour plus d’informations sur les layout slides, voir [Appliquer ou modifier les dispositions de diapositives](/python-net/slide-layout/).
{{% /alert %}}

## **Accéder aux slide masters**

Dans PowerPoint, vous pouvez ouvrir la vue Slide Master depuis **Affichage** > **Slide Master**.

![La commande Slide Master dans l’onglet Affichage de PowerPoint](slide-master_3.jpg)

Dans Aspose.Slides, utilisez la collection `masters` pour accéder aux master slides :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

Vous pouvez également obtenir la master slide utilisée par une diapositive normale via sa disposition :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    slide = presentation.slides[0]
    layout_slide = slide.layout_slide
    master_slide = layout_slide.master_slide
    master_slide_name = master_slide.name

    print(master_slide_name)
```

## **Ce qu’une Slide Master contient**

Une master slide est un objet de type diapositive. Elle hérite du comportement commun des diapositives à partir de la classe [BaseSlide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseslide/), ainsi elle expose de nombreuses propriétés de diapositive utilisées par les diapositives normales et de disposition. Les membres spécifiques aux master sont répertoriés sur la page API [MasterSlide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterslide/).

Les membres de master slide les plus couramment utilisés incluent :

| Membre | Objectif |
| --- | --- |
| `background` | Définit l’arrière‑plan de la diapositive au niveau du master. |
| `shapes` | Stocke les formes placées sur le master, comme les logos, les cadres d’image et le texte partagé. |
| `layout_slides` | Stocke les layout slides qui appartiennent au master. |
| `theme_manager` | Fournit l’accès aux API du thème du master. |
| `header_footer_manager` | Contrôle les en‑têtes, pieds de page, dates et numéros de diapositive pour le master et ses mises en page enfants. |
| `get_depending_slides` | Renvoie les diapositives normales qui dépendent du master via leurs layouts. |

## **Ajouter une image à un Slide Master**

Lorsque vous ajoutez une image à un master slide, elle apparaît sur les diapositives qui utilisent les layouts de ce master. Cela est utile pour les logos, filigranes, bandes décoratives et autres éléments visuels répétés.

L’exemple suivant ajoute un logo au premier master slide :

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

Pour plus d’informations sur les cadres d’image, voir [Cadre d’image](/python-net/picture-frame/).

## **Travailler avec les espaces réservés**

Les espaces réservés sont généralement définis sur les layout slides. Le master slide fournit le style et le thème partagés que ces layouts héritent, tandis que chaque layout décide quels espaces réservés sont disponibles et où ils sont placés.

Dans PowerPoint, les commandes d’espace réservé sont disponibles dans la vue Slide Master.

![La commande Insérer un espace réservé dans la vue Slide Master de PowerPoint](slide-master_5.png)

Pour ajouter de nouveaux espaces réservés avec Aspose.Slides, travaillez avec la layout slide qui appartient au master :

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

Vous pouvez également mettre en forme les formes d’espace réservé déjà présentes sur un master slide. L’exemple suivant trouve l’espace réservé de titre et applique un remplissage en dégradé linéaire :

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
        title_placeholder.fill_format.gradient_format.gradient_stops.add(255, purple_gradient_color)

    presentation.save("presentation-title-style.pptx", slides.export.SaveFormat.PPTX)
```

![Espace réservé de titre formaté hérité par les diapositives normales](slide-master_8.png)

Pour plus d’options de mise en forme des espaces réservés et du texte, voir [Définir le texte d’invite dans l’espace réservé](/python-net/manage-placeholder/) et [Mise en forme du texte](/python-net/text-formatting/).

## **Modifier l’arrière‑plan d’un Slide Master**

Un arrière‑plan de master est hérité par les layouts et les diapositives qui ne le remplacent pas. L’exemple suivant définit une couleur d’arrière‑plan unie pour le premier master slide :

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

Pour les sujets associés, voir [Arrière‑plan de la présentation](/python-net/presentation-background/) et [Thème de la présentation](/python-net/presentation-theme/).

## **Cloner un Slide Master vers une autre présentation**

Utilisez la méthode `add_clone` de la classe [MasterSlideCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterslidecollection/) pour copier un master slide dans une autre présentation. Le master copié peut alors être utilisé par les layouts et les diapositives de la présentation de destination.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Si vous devez cloner des diapositives normales avec leur master, voir [Cloner des diapositives](/python-net/clone-slides/).

## **Ajouter plusieurs Slide Masters**

Une présentation peut contenir plusieurs master slides. Cela est utile lorsque différentes sections nécessitent un branding, une structure de page ou des paramètres de thème différents.

![Commandes PowerPoint pour insérer et gérer les master slides](slide-master_9.jpg)

L’exemple suivant clone le master par défaut, donne au clone un arrière‑plan différent, récupère un layout vide sous ce master cloné, et ajoute une nouvelle diapositive basée sur ce layout :

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

Les master slides peuvent être comparés avec la méthode `equals` héritée de la classe [BaseSlide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseslide/). La comparaison vérifie la structure et le contenu statique, comme les formes, le texte, le formatage, les animations et d’autres paramètres de diapositive. Elle ne compare pas les identifiants uniques, comme les ID de diapositives, ou les valeurs dynamiques des espaces réservés, comme la date actuelle.

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

Pour plus d’informations, voir [Comparer les diapositives de présentation](/python-net/compare-slides/).

## **Définir la vue Slide Master comme vue par défaut**

Utilisez la propriété `last_view` sur les [ViewProperties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/viewproperties/) de la présentation pour contrôler la vue que PowerPoint ouvre en premier. L’exemple suivant ouvre la présentation en vue Slide Master :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Pour plus de paramètres d’affichage, voir [Enregistrer la présentation](/python-net/save-presentation/).

## **Supprimer les master slides inutilisés**

Les présentations contiennent parfois des master slides qui ne sont plus utilisés par aucune diapositive normale. Supprimer les masters inutilisés peut réduire la taille du fichier et simplifier la maintenance du modèle.

Utilisez `remove_unused` pour supprimer les masters inutilisés de la collection `masters` :

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

**Quelle est la différence entre un slide master et une layout slide ?**

Un slide master définit des paramètres de conception partagés tels que le thème, l’arrière‑plan, les formes communes et les styles de texte. Une layout slide appartient à un slide master et définit un agencement spécifique d’espaces réservés. Une diapositive normale utilise une layout slide, donc elle hérite à la fois de la disposition et du master.

**Une présentation peut‑elle contenir plusieurs slide masters ?**

Oui. Une présentation peut contenir plusieurs slide masters. Utilisez plusieurs masters lorsque différentes sections nécessitent des systèmes visuels ou un branding différents.

**Devrais‑je ajouter des espaces réservés à un master slide ou à une layout slide ?**

Dans la plupart des cas, ajoutez les espaces réservés aux layout slides. Placez les éléments visuels partagés et le formatage partagé sur le master slide, puis placez les espaces réservés de contenu sur les layouts que les diapositives normales utiliseront.

**Puis‑je supprimer un master slide qui est encore utilisé ?**

Non. Un master slide qui possède des diapositives dépendantes ne peut pas être supprimé directement en toute sécurité. Déplacez d’abord ces diapositives vers des layouts sous un autre master, ou utilisez une méthode de nettoyage des masters inutilisés qui ne supprime que les masters qui ne sont pas utilisés.