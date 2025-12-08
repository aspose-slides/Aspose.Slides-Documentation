---
title: Appliquer ou modifier les dispositions de diapositives en Python
linktitle: Disposition de diapositive
type: docs
weight: 60
url: /fr/python-net/slide-layout/
keywords:
- disposition de diapositive
- disposition de contenu
- espace réservé
- conception de présentation
- conception de diapositive
- disposition inutilisée
- visibilité du pied de page
- diapositive titre
- titre et contenu
- en-tête de section
- deux contenus
- comparaison
- titre seul
- disposition vierge
- contenu avec légende
- image avec légende
- titre et texte vertical
- titre vertical et texte
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Apprenez à gérer et personnaliser les dispositions de diapositives dans Aspose.Slides for Python via .NET. Explorez les types de dispositions, le contrôle des espaces réservés, la visibilité du pied de page et la manipulation des dispositions à l'aide d'exemples de code en Python."
---

## **Vue d'ensemble**

Une disposition de diapositive définit l'agencement des zones réservées et le formatage du contenu d'une diapositive. Elle contrôle quelles zones réservées sont disponibles et où elles apparaissent. Les dispositions de diapositive vous aident à créer des présentations rapidement et de manière cohérente—que vous conceviez quelque chose de simple ou de plus complexe. Parmi les dispositions de diapositive les plus courantes dans PowerPoint figurent :

**Title Slide layout** – Comprend deux zones réservées de texte : une pour le titre et une pour le sous-titre.

**Title and Content layout** – Propose une petite zone réservée de titre en haut et une plus grande en dessous pour le contenu principal (texte, puces, graphiques, images, etc.).

**Blank layout** – Ne contient aucune zone réservée, vous offrant un contrôle total pour concevoir la diapositive à partir de zéro.

Les dispositions de diapositive font partie d'un maître de diapositive, qui est la diapositive de niveau supérieur définissant les styles de disposition pour la présentation. Vous pouvez accéder aux dispositions et les modifier via le maître de diapositive—soit par type, nom ou identifiant unique. Vous pouvez également modifier directement une disposition spécifique au sein de la présentation.

Pour travailler avec les dispositions de diapositive dans Aspose.Slides for Python, utilisez :

- Propriétés telles que [layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/layout_slides/) et [masters](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/masters/) sous la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)
- Types comme [LayoutSlide](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterlayoutslidecollection/), [LayoutPlaceholderManager](https://reference.aspose.com/slides/python-net/aspose.slides/layoutplaceholdermanager/), et [LayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
Pour en savoir plus sur la gestion des maîtres de diapositives, consultez l'article [Gérer les maîtres de diapositives PowerPoint en Python](/slides/fr/python-net/slide-master/).
{{% /alert %}}

## **Ajouter des dispositions de diapositive aux présentations**

Pour personnaliser l'apparence et la structure de vos diapositives, il peut être nécessaire d'ajouter de nouvelles dispositions à une présentation. Aspose.Slides for Python vous permet de vérifier si une disposition spécifique existe déjà, d'en ajouter une nouvelle si besoin, et de l'utiliser pour insérer des diapositives basées sur cette disposition.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Accédez à la [MasterLayoutSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterlayoutslidecollection/).
1. Vérifiez si la disposition souhaitée existe déjà dans la collection. Sinon, ajoutez la disposition dont vous avez besoin.
1. Ajoutez une diapositive vide basée sur la nouvelle disposition.
1. Enregistrez la présentation.

Le code Python suivant montre comment ajouter une disposition de diapositive à une présentation PowerPoint :
```python
import aspose.slides as slides

# Instancier la classe Presentation pour ouvrir le fichier de présentation.
with slides.Presentation("sample.pptx") as presentation:
    # Parcourir les types de diapositives de mise en page pour sélectionner une diapositive de mise en page.
    layout_slides = presentation.masters[0].layout_slides
    layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)
    if layout_slide is None:
         layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.TITLE)

    if layout_slide is None:
        # Une situation où la présentation ne contient pas tous les types de mise en page.
        # Le fichier de présentation ne contient que les types de mise en page Blank et Custom.
        # Cependant, les diapositives de mise en page avec des types personnalisés peuvent avoir des noms reconnaissables,
        # comme "Title", "Title and Content", etc., qui peuvent être utilisés pour la sélection de la diapositive de mise en page.
        # Vous pouvez également vous baser sur un ensemble de types de formes d'espace réservé.
        # Par exemple, une diapositive Title doit contenir uniquement le type d'espace réservé Title, etc.
        for title_and_object_layout_slide in layout_slides:
            if title_and_object_layout_slide.name == "Title and Object":
                layout_slide = title_and_object_layout_slide
                break

        if layout_slide is None:
            for title_layout_slide in layout_slides:
                if title_layout_slide.name == "Title":
                    layout_slide = title_layout_slide
                    break

            if layout_slide is None:
                layout_slide = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)
                if layout_slide is None:
                    layout_slide = layout_slides.Add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Title and Object")

    # Ajouter une diapositive vide en utilisant la diapositive de mise en page ajoutée.
    presentation.slides.insert_empty_slide(0, layout_slide)

    # Enregistrer la présentation sur le disque.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Supprimer les dispositions de diapositive inutilisées**

Aspose.Slides fournit la méthode [remove_unused_layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) de la classe [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) pour supprimer les dispositions de diapositive indésirables et inutilisées.

Le code Python suivant montre comment supprimer une disposition de diapositive d'une présentation PowerPoint :
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Ajouter des zones réservées aux dispositions de diapositive**

Aspose.Slides propose la propriété [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/python-net/aspose.slides/layoutslide/placeholder_manager/), qui permet d'ajouter de nouvelles zones réservées à une disposition.

Ce gestionnaire contient des méthodes pour les types de zones réservées suivants :

| PowerPoint Placeholder              | [LayoutPlaceholderManager](https://reference.aspose.com/slides/python-net/aspose.slides/layoutplaceholdermanager/) Method |
| ----------------------------------- | ------------------------------------------------------------ |
| ![Content](content.png)             | add_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Content (Vertical)](contentV.png) | add_vertical_content_placeholder(x: float, y: float, width: float, height: float) |
| ![Text](text.png)                   | add_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Text (Vertical)](textV.png)       | add_vertical_text_placeholder(x: float, y: float, width: float, height: float) |
| ![Picture](picture.png)             | add_picture_placeholder(x: float, y: float, width: float, height: float) |
| ![Chart](chart.png)                 | add_chart_placeholder(x: float, y: float, width: float, height: float) |
| ![Table](table.png)                 | add_table_placeholder(x: float, y: float, width: float, height: float) |
| ![SmartArt](smartart.png)           | add_smart_art_placeholder(x: float, y: float, width: float, height: float) |
| ![Media](media.png)                 | add_media_placeholder(x: float, y: float, width: float, height: float) |
| ![Online Image](onlineimage.png)    | add_online_image_placeholder(x: float, y: float, width: float, height: float) |

Le code Python suivant montre comment ajouter de nouvelles formes de zone réservée à la disposition Blank :
```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Obtenir la diapositive de mise en page vierge.
    layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    # Obtenir le gestionnaire de zones réservées de la diapositive de mise en page.
    placeholder_manager = layout.placeholder_manager

    # Ajouter différentes zones réservées à la diapositive de mise en page vierge.
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    # Ajouter une nouvelle diapositive avec la mise en page vierge.
    new_slide = presentation.slides.add_empty_slide(layout)

    presentation.save("placeholders.pptx", slides.export.SaveFormat.PPTX)
```


Le résultat :

![The placeholders on the layout slide](add_placeholders.png)

## **Définir la visibilité du pied de page pour une disposition de diapositive**

Dans les présentations PowerPoint, les éléments du pied de page comme la date, le numéro de diapositive et le texte personnalisé peuvent être affichés ou masqués selon la disposition. Aspose.Slides for Python vous permet de contrôler la visibilité de ces zones réservées du pied de page. Ceci est utile lorsque vous souhaitez que certaines dispositions affichent les informations du pied de page tandis que d'autres restent épurées.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une référence à une disposition de diapositive par son indice.
1. Passez la zone réservée du pied de page de la diapositive à visible.
1. Passez la zone réservée du numéro de diapositive à visible.
1. Passez la zone réservée de la date/heure à visible.
1. Enregistrez la présentation.

Le code Python suivant montre comment définir la visibilité du pied de page d'une diapositive et effectuer les tâches associées :
```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    header_footer_manager = presentation.layout_slides[0].header_footer_manager

    if not header_footer_manager.is_footer_visible: 
        header_footer_manager.set_footer_visibility(True) 

    if not header_footer_manager.is_slide_number_visible:  
        header_footer_manager.set_slide_number_visibility(True) 

    if not header_footer_manager.is_date_time_visible: 
        header_footer_manager.set_date_time_visibility(True)

    header_footer_manager.set_footer_text("Footer text") 
    header_footer_manager.set_date_time_text("Date and time text") 

    presentation.save("output.ppt", slides.export.SaveFormat.PPT)
```


## **Définir la visibilité du pied de page enfant pour une diapositive**

​Dans les présentations PowerPoint, les éléments du pied de page tels que la date, le numéro de diapositive et le texte personnalisé peuvent être contrôlés au niveau du maître de diapositive afin d'assurer la cohérence sur toutes les dispositions. Aspose.Slides for Python permet de définir la visibilité et le contenu de ces zones réservées du pied de page sur le maître de diapositive et de propager ces paramètres à toutes les dispositions enfants. Cette approche garantit une information de pied de page uniforme dans l’ensemble de la présentation.​

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une référence au maître de diapositive par son indice.
1. Passez les zones réservées du pied de page du maître et de toutes les dispositions enfants à visibles.
1. Passez les zones réservées du numéro de diapositive du maître et de toutes les dispositions enfants à visibles.
1. Passez les zones réservées de la date/heure du maître et de toutes les dispositions enfants à visibles.
1. Enregistrez la présentation.

Le code Python suivant montre cette opération :
```python
import aspose.slides as slides

with slides.Presentation("presentation.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager

    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)

    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **FAQ**

**Quelle est la différence entre un maître de diapositive et une disposition de diapositive ?**

Un maître de diapositive définit le thème global et le formatage par défaut, tandis que les dispositions de diapositive définissent des agencements spécifiques de zones réservées pour différents types de contenu.

**Puis-je copier une disposition de diapositive d’une présentation à une autre ?**

Oui, vous pouvez cloner une disposition de diapositive depuis la collection [layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/layout_slides/) d’une présentation et l’insérer dans une autre à l’aide de la méthode `add_clone`.

**Que se passe-t-il si je supprime une disposition de diapositive encore utilisée par une diapositive ?**

Si vous essayez de supprimer une disposition de diapositive qui est toujours référencée par au moins une diapositive de la présentation, Aspose.Slides lèvera une [PptxEditException](https://reference.aspose.com/slides/python-net/aspose.slides/pptxeditexception/). Pour éviter cela, utilisez [remove_unused_layout_slides](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) qui supprime en toute sécurité uniquement les dispositions inutilisées.