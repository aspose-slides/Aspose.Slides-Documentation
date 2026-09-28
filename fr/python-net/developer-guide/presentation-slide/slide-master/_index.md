---
title: Gérer les diapositives maîtres de présentation en Python
linktitle: Maître de diapositive
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
description: "Gérer les maîtres de diapositives dans Aspose.Slides pour Python via .NET: accéder, modifier, cloner, comparer et supprimer les diapositives maîtres dans les présentations PowerPoint et OpenDocument."
---
## **Aperçu**

Un **slide master** définit des paramètres de conception partagés pour un groupe de diapositives. Il peut contenir des formes communes, des logos, des arrière‑plans, des styles de texte, des paramètres de thème et des paramètres de pied de page. Dans PowerPoint, la modification d’un slide master est la façon habituelle de garder une présentation cohérente sans répéter le même formatage sur chaque diapositive.

Aspose.Slides for Python via .NET prend en charge le même modèle. Une présentation peut contenir une ou plusieurs diapositives maîtres, et chaque diapositive maître peut contenir plusieurs diapositives de mise en page. Les diapositives normales ne font généralement pas référence directement à une diapositive maître. Au lieu de cela, une diapositive normale utilise une diapositive de mise en page, et cette diapositive de mise en page appartient à une diapositive maître.

La hiérarchie est :

1. **Slide master** – définit la conception et le thème partagés.  
1. **Layout slide** – définit une disposition spécifique de espaces réservés et de formatage au niveau de la mise en page.  
1. **Normal slide** – contient le contenu réel de la présentation et utilise une diapositive de mise en page.

![The hierarchy of master slides, layout slides, and normal slides](slide-master_2.jpg)

Dans Aspose.Slides, un slide master est représenté par la classe [MasterSlide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterslide/). Tous les slides maîtres d’une présentation sont accessibles via la collection `Presentation.masters`.

{{% alert color="info" title="Inheritance" %}}
Lorsque la même propriété est définie à plusieurs niveaux, le niveau le plus spécifique l’emporte. Par exemple, si un slide maître et une diapositive de mise en page définissent toutes deux un arrière‑plan, les diapositives basées sur cette mise en page utilisent l’arrière‑plan de la mise en page. Pour plus d’informations sur les diapositives de mise en page, voir [Apply or Change Slide Layouts](/slides/fr/python-net/slide-layout/).
{{% /alert %}}

## **Accéder aux Slide Masters**

Dans PowerPoint, vous pouvez ouvrir la vue Slide Master depuis **Affichage** > **Slide Master**.

![The Slide Master command on the PowerPoint View tab](slide-master_3.jpg)

Dans Aspose.Slides, utilisez la collection `masters` pour accéder aux slides maîtres :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    first_master_slide = presentation.masters[0]
    master_slide_count = len(presentation.masters)
    first_master_layout_slide_count = len(first_master_slide.layout_slides)

    print("Master slides: " + str(master_slide_count))
    print("Layouts in the first master: " + str(first_master_layout_slide_count))
```

Vous pouvez également récupérer le slide maître utilisé par une diapositive normale via sa mise en page :

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

Un slide maître est un objet semblable à une diapositive. Il hérite du comportement commun des diapositives depuis la classe [BaseSlide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseslide/), ce qui lui expose de nombreuses propriétés de diapositive identiques à celles des diapositives normales et des mises en page. Les membres spécifiques au maître sont répertoriés sur la page API [MasterSlide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterslide/).

Les membres de slide maître les plus couramment utilisés sont :

| Membre | Objectif |
| --- | --- |
| `background` | Définit l’arrière‑plan au niveau du maître. |
| `shapes` | Stocke les formes placées sur le maître, telles que logos, cadres d’image et texte partagé. |
| `layout_slides` | Stocke les diapositives de mise en page appartenant au maître. |
| `theme_manager` | Fournit l’accès aux API de thème du maître. |
| `header_footer_manager` | Contrôle les en‑têtes, pieds de page, dates et numéros de diapositive pour le maître et ses mises en page enfants. |
| `get_depending_slides` | Renvoie les diapositives normales qui dépendent du maître via leurs mises en page. |

## **Ajouter une image à un Slide Master**

Lorsque vous ajoutez une image à un slide maître, elle apparaît sur les diapositives qui utilisent les mises en page de ce maître. C’est utile pour les logos, filigranes, bandes décoratives et autres éléments visuels répétés.

L’exemple suivant ajoute un logo au premier slide maître :

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

Pour plus d’informations sur les cadres d’image, voir [Picture Frame](/slides/fr/python-net/picture-frame/).

## **Contrôler la visibilité des graphiques du maître**

Utilisez [BaseSlide.show_master_shapes](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseslide/show_master_shapes/) pour masquer les graphiques hérités du maître, comme les logos ou formes décoratives, sans les supprimer du maître. Définissez [Slide.show_master_shapes](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/show_master_shapes/) sur `False` sur la diapositive qui doit omettre ces graphiques et laissez‑le sur `True` sur les diapositives qui doivent les afficher.

L’exemple autonome suivant crée une bande décorative bleue sur un maître et deux diapositives qui utilisent la même mise en page vierge. La bande est visible sur la première diapositive et masquée sur la seconde. Aucun fichier de présentation ou image d’entrée n’est requis.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    master_slide = presentation.masters[0]
    layout_slide = master_slide.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
    layout_slide.show_master_shapes = True

    slide_height = presentation.slide_size.size.height
    band = master_slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 0, 0, 60, slide_height)
    band.fill_format.fill_type = slides.FillType.SOLID
    band.fill_format.solid_fill_color.color = draw.Color.steel_blue
    band.line_format.fill_format.fill_type = slides.FillType.NO_FILL

    visible_slide = presentation.slides[0]
    visible_slide.layout_slide = layout_slide
    visible_slide.shapes.clear()

    hidden_slide = presentation.slides.add_empty_slide(layout_slide)

    visible_slide.show_master_shapes = True
    hidden_slide.show_master_shapes = False

    presentation.save("master-graphics.pptx", slides.export.SaveFormat.PPTX)
```

L’exemple utilise la mise en page **Blank** fournie avec une nouvelle présentation et supprime les espaces réservés propres à la diapositive initiale.

### **Choisir la portée du paramètre**

Une diapositive normale utilise son maître via [Slide.layout_slide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/layout_slide/) et [LayoutSlide.master_slide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutslide/master_slide/). Définir la propriété sur une diapositive individuelle n’affecte que cette diapositive. Définir [LayoutSlide.show_master_shapes](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutslide/show_master_shapes/) sur `False` masque les graphiques du maître pour toutes les diapositives qui utilisent cette mise en page partagée, même si leur propre paramètre est `True`. Pour masquer les graphiques sur une seule diapositive, modifiez la propriété de la diapositive et laissez la mise en page partagée inchangée.

Le paramètre n’est pas pris en charge comme contrôle de visibilité sur le slide maître lui‑même. Sur un maître, il renvoie toujours `False`, et le définir à `True` lève une exception. Appliquez‑le à une diapositive normale ou à une mise en page à la place.

### **Distinction entre graphiques et arrière‑plan**

| Opération | Effet |
| --- | --- |
| Masquer les graphiques du maître | Contrôle la visibilité des formes héritées du maître sans les supprimer ni modifier les formes propres à la diapositive. |
| Modifier le remplissage d’arrière‑plan de la diapositive | Change la couleur, le dégradé ou l’image d’arrière‑plan. Les graphiques du maître sont des formes séparées et peuvent rester visibles au-dessus de cet arrière‑plan. Voir [Presentation Background](/slides/fr/python-net/presentation-background/). |
| Supprimer une forme du maître | Supprime la forme source partagée, de sorte qu’elle ne soit plus disponible pour aucune diapositive utilisant ce maître. |

## **Travailler avec les espaces réservés**

Les espaces réservés sont normalement définis sur les diapositives de mise en page. Le slide maître fournit le style et le thème partagés que ces mises en page héritent, tandis que chaque mise en page décide quels espaces réservés sont disponibles et où ils sont placés.

Dans PowerPoint, les commandes d’espace réservé sont disponibles en mode Slide Master.

![The Insert Placeholder command in PowerPoint Slide Master view](slide-master_5.png)

Pour ajouter de nouveaux espaces réservés avec Aspose.Slides, travaillez sur la diapositive de mise en page qui appartient au maître :

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

Vous pouvez également formater les formes d’espace réservé déjà existantes sur un slide maître. L’exemple suivant trouve l’espace réservé au titre et applique un remplissage en dégradé linéaire :

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

![Formatted title placeholder inherited by normal slides](slide-master_8.png)

Pour plus d’options de mise en forme d’espace réservé et de texte, voir [Set Prompt Text in Placeholder](/slides/fr/python-net/manage-placeholder/) et [Text Formatting](/slides/fr/python-net/text-formatting/).

## **Modifier l’arrière‑plan d’un Slide Master**

Un arrière‑plan de maître est hérité par les mises en page et les diapositives qui ne le remplacent pas. L’exemple suivant définit une couleur d’arrière‑plan unie pour le premier slide maître :

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

Pour les sujets connexes, voir [Presentation Background](/slides/fr/python-net/presentation-background/) et [Presentation Theme](/slides/fr/python-net/presentation-theme/).

## **Cloner un Slide Master vers une autre présentation**

Utilisez la méthode `add_clone` de la classe [MasterSlideCollection](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterslidecollection/) pour copier un slide maître dans une autre présentation. Le maître copié peut alors être utilisé par les mises en page et les diapositives de la présentation de destination.

```python
import aspose.slides as slides

with slides.Presentation("source.pptx") as source_presentation:
    with slides.Presentation("destination.pptx") as destination_presentation:
        source_master_slide = source_presentation.masters[0]
        cloned_master_slide = destination_presentation.masters.add_clone(source_master_slide)

        destination_presentation.save("destination-with-master.pptx", slides.export.SaveFormat.PPTX)
```

Si vous devez cloner des diapositives normales avec leur maître, voir [Clone Slides](/slides/fr/python-net/clone-slides/).

## **Ajouter plusieurs Slide Masters**

Une présentation peut contenir plusieurs slides maîtres. Cela est utile lorsque différentes sections nécessitent des logos, structures de page ou paramètres de thème différents.

![PowerPoint commands for inserting and managing master slides](slide-master_9.jpg)

L’exemple suivant clone le maître par défaut, donne au clone un arrière‑plan différent, récupère une mise en page vierge sous ce maître cloné, et ajoute une nouvelle diapositive basée sur cette mise en page :

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

Les slides maîtres peuvent être comparés avec la méthode `equals` héritée de la classe [BaseSlide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseslide/). La comparaison vérifie la structure et le contenu statique, tels que les formes, le texte, le formatage, les animations et d’autres paramètres de diapositive. Elle ne compare pas les identifiants uniques, comme les ID de diapositive, ni les valeurs dynamiques d’espace réservé, comme la date actuelle.

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

Pour plus d’informations, voir [Compare Presentation Slides](/slides/fr/python-net/compare-slides/).

## **Définir la vue Slide Master comme vue par défaut**

Utilisez la propriété `last_view` sur les [ViewProperties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/viewproperties/) de la présentation pour contrôler la vue que PowerPoint ouvre en premier. L’exemple suivant ouvre la présentation en vue Slide Master :

```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("presentation-master-view.pptx", slides.export.SaveFormat.PPTX)
```

Pour d’autres paramètres de vue, voir [Save Presentation](/slides/fr/python-net/save-presentation/).

## **Supprimer les Slide Masters inutilisés**

Les présentations contiennent parfois des slides maîtres qui ne sont plus utilisés par aucune diapositive normale. Supprimer les maîtres inutilisés peut réduire la taille du fichier et simplifier la maintenance des modèles.

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

**Quelle est la différence entre un slide master et une layout slide ?**

Un slide master définit les paramètres de conception partagés tels que le thème, l’arrière‑plan, les formes communes et les styles de texte. Une layout slide appartient à un slide master et définit une disposition spécifique d’espaces réservés. Une diapositive normale utilise une layout slide, elle hérite donc à la fois de la mise en page et du maître.

**Une présentation peut‑elle contenir plusieurs slide masters ?**

Oui. Une présentation peut contenir plusieurs slide masters. Utilisez plusieurs maîtres lorsque différentes sections nécessitent des systèmes visuels ou des logos différents.

**Dois‑je ajouter des espaces réservés à un slide master ou à une layout slide ?**

Dans la plupart des cas, ajoutez les espaces réservés aux layout slides. Placez les éléments visuels partagés et le formatage partagé sur le slide master, puis les espaces réservés de contenu sur les mises en page que les diapositives normales utiliseront.

**Puis‑je supprimer un slide master qui est encore utilisé ?**

Non. Un slide master qui possède des diapositives dépendantes ne peut pas être supprimé en toute sécurité. Déplacez d’abord ces diapositives vers des mises en page sous un autre maître, ou utilisez une méthode de nettoyage des maîtres non utilisés qui ne supprime que les maîtres qui ne sont pas en cours d’utilisation.