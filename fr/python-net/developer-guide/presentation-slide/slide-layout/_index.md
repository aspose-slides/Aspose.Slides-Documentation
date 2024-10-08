---
title: Mise en Page des Diapositives
type: docs
weight: 60
url: /fr/python-net/slide-layout/
keyword: "Définir la taille des diapositives, définir les options des diapositives, spécifier la taille des diapositives, visibilité du pied de page, pied de page enfant, mise à l'échelle du contenu, taille de page, Python, Aspose.Slides"
description: "Définir la taille et les options des diapositives PowerPoint en Python"
---

Une mise en page de diapositive contient les zones de texte réservées et les informations de formatage pour tout le contenu qui apparaît sur une diapositive. La mise en page détermine les zones de contenu réservées disponibles et où elles sont placées.

Les mises en page de diapositives vous permettent de créer et de concevoir rapidement des présentations (qu'elles soient simples ou complexes). Voici quelques-unes des mises en page de diapositives les plus populaires utilisées dans les présentations PowerPoint :

* **Mise en page de Diapositive Titre**. Cette mise en page se compose de deux zones de texte réservées. Une zone est pour le titre et l'autre est pour le sous-titre.
* **Mise en page Titre et Contenu**. Cette mise en page contient une zone réservée relativement petite en haut pour le titre et une plus grande zone réservée pour le contenu principal (graphique, paragraphes, liste à puces, liste numérotée, images, etc).
* **Mise en page Vide**. Cette mise en page ne contient pas de zones réservées, vous permettant de créer des éléments à partir de zéro.

Puisqu'un modèle de diapositive est la diapositive hiérarchiquement supérieure qui stocke des informations sur les mises en page de diapositives, vous pouvez utiliser la diapositive maître pour accéder aux mises en page de diapositives et y effectuer des modifications. Une diapositive de mise en page peut être accédée par type ou par nom. De même, chaque diapositive a un id unique, qui peut être utilisé pour y accéder.

Alternativement, vous pouvez apporter des modifications directement à une mise en page de diapositive spécifique dans une présentation.

* Pour vous permettre de travailler avec des mises en page de diapositives (y compris celles dans des diapositives maîtres), Aspose.Slides fournit des propriétés telles que `layout_slides` et `masters` sous la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
* Pour effectuer des tâches liées, Aspose.Slides fournit [MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/masterslide/), [MasterLayoutSlideCollection](https://reference.aspose.com/slides/python-net/aspose.slides/masterlayoutslidecollection/), [SlideSize](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/), [BaseSlideHeaderFooterManager](https://reference.aspose.com/slides/python-net/aspose.slides/baseslideheaderfootermanager/), et de nombreux autres types.

{{% alert title="Info" color="info" %}}

Pour plus d'informations sur le travail avec les Diapositives Maîtres en particulier, voir l'article [Diapositive Maître](https://docs.aspose.com/slides/python-net/slide-master/).

{{% /alert %}}

## **Ajouter une Mise en Page de Diapositive à la Présentation**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Accédez à la [collection MasterSlide](https://reference.aspose.com/slides/python-net/aspose.slides/imasterlayoutslidecollection/).
1. Parcourez les diapositives de mise en page existantes pour confirmer que la diapositive de mise en page requise existe déjà dans la collection de mises en page de diapositives. Sinon, ajoutez la diapositive de mise en page que vous souhaitez.
1. Ajoutez une diapositive vide basée sur la nouvelle diapositive de mise en page.
1. Enregistrez la présentation.

Ce code Python vous montre comment ajouter une mise en page de diapositive à une présentation PowerPoint :

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instancie une classe Presentation qui représente le fichier de présentation
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    # Parcourt les types de diapositives de mise en page
    layoutSlides = presentation.masters[0].layout_slides
    layoutSlide = layoutSlides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)  
    if layoutSlide is None:
         layoutSlide = layoutSlides.get_by_type(slides.SlideLayoutType.TITLE)

    if layoutSlide is None:
        # La situation où une présentation ne contient pas certains types de mise en page.
        # Le fichier de présentation contient seulement des types de mise en page Vides et Personnalisés.
        # Mais les diapositives de mise en page de types Personnalisés ont des noms de diapositives différents,
        # comme "Titre", "Titre et Contenu", etc. Et il est possible d'utiliser ces
        # noms pour la sélection de la diapositive de mise en page.
        # Vous pouvez également utiliser un ensemble de types de formes de zones réservées. Par exemple,
        # La diapositive de titre devrait avoir uniquement le type de zone réservée Titre, etc.
        for titleAndObjectLayoutSlide in layoutSlides:
            if titleAndObjectLayoutSlide.name == "Titre et Objet":
                layoutSlide = titleAndObjectLayoutSlide
                break

        if layoutSlide is None:
            for titleLayoutSlide in layoutSlides:
                if titleLayoutSlide.name == "Titre":
                    layoutSlide = titleLayoutSlide
                    break

            if layoutSlide is None:
                layoutSlide = layoutSlides.get_by_type(slides.SlideLayoutType.BLANK)
                if layoutSlide is None:
                    layoutSlide = layoutSlides.Add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Titre et Objet")

    # Ajoute une diapositive vide avec la diapositive de mise en page ajoutée 
    presentation.slides.insert_empty_slide(0, layoutSlide)

    # Enregistre la présentation sur le disque
    presentation.save("AddLayoutSlides_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Supprimer une Diapositive de Mise en Page Inutilisée**

Aspose.Slides fournit la méthode `remove_unused_layout_slides` de la classe [Compress](https://reference.aspose.com/slides/python-net/aspose.slides.lowcode/compress/) pour vous permettre de supprimer les diapositives de mise en page indésirables et inutilisées. Ce code Python vous montre comment supprimer une diapositive de mise en page d'une présentation PowerPoint :

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as pres:
    slides.lowcode.Compress.remove_unused_layout_slides(pres)
    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir la Taille et le Type pour la Mise en Page de Diapositive**

Pour vous permettre de définir la taille et le type d'une diapositive de mise en page spécifique, Aspose.Slides fournit les propriétés `type` et `size` (de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)). Ce Python démontre l'opération :

```python
import aspose.slides as slides

# Instancie un objet Presentation qui représente un fichier de présentation 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    with slides.Presentation() as auxPresentation:
        slide = presentation.slides[0]

        # Définit la taille de la diapositive pour la présentation générée à celle de la source
        auxPresentation.slide_size.set_size(presentation.slide_size.type, slides.SlideSizeScaleType.ENSURE_FIT)

        auxPresentation.slides.insert_clone(0, slide)
        auxPresentation.slides.remove_at(0)
        # Enregistre la présentation sur le disque
        auxPresentation.save("Set_Size&Type_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir la Visibilité du Pied de Page à l'Intérieur de la Diapositive**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une référence à une diapositive par son index.
1. Réglez la zone réservée pour le pied de page de la diapositive sur visible.
1. Réglez la zone réservée de date-heure sur visible.
1. Enregistrez la présentation.

Ce code Python vous montre comment définir la visibilité d'un pied de page de diapositive (et effectuer des tâches liées) :

```python
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    headerFooterManager = presentation.slides[0].header_footer_manager
    # La propriété is_footer_visible est utilisée pour spécifier qu'une zone réservée de pied de page de diapositive est manquante
    if not headerFooterManager.is_footer_visible: 
        # La méthode set_footer_visibility est utilisée pour définir une zone réservée de pied de page de diapositive sur visible
        headerFooterManager.set_footer_visibility(True) 
        # La propriété is_slide_number_visible est utilisée pour spécifier qu'une zone réservée de numéro de diapositive est manquante
    if not headerFooterManager.is_slide_number_visible:  
        # La méthode set_slide_number_visibility est utilisée pour définir une zone réservée de numéro de diapositive sur visible
        headerFooterManager.set_slide_number_visibility(True) 
        # La propriété is_date_time_visible est utilisée pour spécifier qu'une zone réservée de date-heure de diapositive est manquante
    if not headerFooterManager.is_date_time_visible: 
        # La méthode set_date_time_visibility est utilisée pour définir une zone réservée de date-heure de diapositive sur visible 
        headerFooterManager.set_date_time_visibility(True)

    # La méthode set_footer_text est utilisée pour définir un texte pour une zone réservée de pied de page de diapositive 
    headerFooterManager.set_footer_text("Texte du pied de page") 
    # La méthode set_date_time_text est utilisée pour définir un texte pour une zone réservée de date-heure de diapositive.
    headerFooterManager.set_date_time_text("Texte de la date et de l'heure") 

    # Enregistre la présentation sur le disque
    presentation.save("Presentation.ppt", slides.export.SaveFormat.PPT)
```

## **Définir la Visibilité du Pied de Page Enfant à l'Intérieur de la Diapositive**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
1. Obtenez une référence pour la diapositive maître par son index.
1. Réglez la diapositive maître et toutes les zones réservées du pied de page enfant sur visible.
1. Définissez un texte pour la diapositive maître et toutes les zones réservées du pied de page enfant.
1. Définissez un texte pour la diapositive maître et toutes les zones réservées de date-heure enfant.
1. Enregistrez la présentation.

Ce code Python démontre l'opération :

```python
import aspose.slides as slides

with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    manager = presentation.masters[0].header_footer_manager
    manager.set_footer_and_child_footers_visibility(True) # La méthode set_footer_and_child_footers_visibility est utilisée pour régler la diapositive maître et toutes les zones réservées du pied de page enfant sur visible
    manager.set_slide_number_and_child_slide_numbers_visibility(True) # La méthode set_slide_number_and_child_slide_numbers_visibility est utilisée pour régler la diapositive maître et toutes les zones réservées de numéro de page enfant sur visible
    manager.set_date_time_and_child_date_times_visibility(True) # La méthode set_date_time_and_child_date_times_visibility est utilisée pour régler une diapositive maître et toutes les zones réservées de date-heure enfant sur visible

    manager.set_footer_and_child_footers_text("Texte du pied de page") # La méthode set_footer_and_child_footers_text est utilisée pour définir des textes pour la diapositive maître et toutes les zones réservées du pied de page enfant
    manager.set_date_time_and_child_date_times_text("Texte de la date et de l'heure") # La méthode set_date_time_and_child_date_times_text est utilisée pour définir un texte pour la diapositive maître et toutes les zones réservées de date-heure enfant
```

## **Définir la Taille de la Diapositive en Fonction de la Mise à l'Échelle du Contenu**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) et chargez la présentation contenant la diapositive dont vous voulez définir la taille.
1. Créez une autre instance de la classe [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) pour générer une nouvelle présentation.
1. Obtenez la référence de la diapositive (de la première présentation) par son index.
1. Réglez la zone réservée pour le pied de page de la diapositive sur visible.
1. Réglez la zone réservée de date-heure sur visible.
1. Enregistrez la présentation.

Ce Python démontre l'opération :

```python
import aspose.slides as slides

# Instancie un objet Presentation qui représente un fichier de présentation 
with slides.Presentation(path + "AccessSlides.pptx") as presentation:
    with slides.Presentation() as auxPresentation:
        slide = presentation.slides[0]

        # Définit la taille de la diapositive pour les présentations générées à celle de la source
        presentation.slide_size.set_size(540, 720, slides.SlideSizeScaleType.ENSURE_FIT) # La méthode set_size est utilisée pour définir la taille de la diapositive avec mise à l'échelle du contenu pour assurer l'ajustement
        presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.MAXIMIZE) # La méthode set_size est utilisée pour définir la taille de la diapositive avec la taille maximale du contenu
                
        # Enregistre la présentation sur le disque
        auxPresentation.save("Set_Size&Type_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Définir la Taille de Page lors de la Génération d'un PDF**

Certaines présentations (comme des affiches) sont souvent converties en documents PDF. Si vous souhaitez convertir votre PowerPoint en PDF pour accéder aux meilleures options d'impression et d'accessibilité, vous devez définir vos diapositives sur des tailles adaptées aux documents PDF (A4, par exemple).

Aspose.Slides fournit la classe [SlideSize](https://reference.aspose.com/slides/python-net/aspose.slides/slidesize/) pour vous permettre de spécifier vos paramètres préférés pour les diapositives. Ce code Python vous montre comment utiliser la propriété `type` (de la classe `SlideSize`) pour définir une taille de papier spécifique pour les diapositives d'une présentation :

```python
import aspose.slides as slides

# Instancie un objet Presentation qui représente un fichier de présentation  
with slides.Presentation() as presentation:
    # Définit la propriété SlideSize.Type 
    presentation.slide_size.set_size(slides.SlideSizeType.A4_PAPER, slides.SlideSizeScaleType.ENSURE_FIT)

    # Définit différentes propriétés pour les Options PDF
    opts = slides.export.PdfOptions()
    opts.sufficient_resolution = 600

    # Enregistre la présentation sur le disque
    presentation.save("SetPDFPageSize_out.pdf", slides.export.SaveFormat.PDF, opts)
```