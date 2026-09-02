---
title: Appliquer ou modifier les mises en page de diapositives en Python
linktitle: Mise en page de diapositive
type: docs
weight: 60
url: /fr/python-net/slide-layout/
keywords:
- mise en page de diapositive
- mise en page de contenu
- espace réservé
- conception de présentation
- conception de diapositive
- mise en page inutilisée
- visibilité du pied de page
- diapositive de titre
- titre et contenu
- en-tête de section
- deux contenus
- comparaison
- titre uniquement
- mise en page vierge
- contenu avec légende
- image avec légende
- titre et texte vertical
- titre vertical et texte
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Appliquer, créer et modifier les mises en page de diapositives dans Aspose.Slides pour Python via .NET, ajouter des espaces réservés, supprimer les mises en page inutilisées et contrôler la visibilité du pied de page."
---
## **Vue d'ensemble**

Un modèle de diapositive définit les positions et le formatage des espaces réservés tels que les titres, le texte, les images, les graphiques et les tableaux. Appliquer un modèle donne aux diapositives une structure cohérente tout en permettant à chaque diapositive de contenir son propre contenu.

- **Diapositive de titre** : Contient des espaces réservés pour le titre et le sous-titre.
- **Titre et contenu** : Contient un espace réservé pour le titre et un espace réservé de contenu à usage général.
- **Vide** : Ne contient aucun espace réservé de contenu et est utile lorsque chaque forme sera positionnée manuellement.

## **Comprendre l'héritage des modèles**

Une présentation possède trois niveaux associés :

1. Un [diapositive maître](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterslide/) définit le thème, le formatage partagé, les arrière-plans et les objets communs.
2. Une [diapositive de modèle](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutslide/) appartient à un maître et définit une disposition particulière d'espaces réservés.
3. Une [diapositive normale](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/) utilise un modèle et stocke le contenu saisi pour cette diapositive.

Une diapositive normale hérite du thème et du formatage de son modèle, et le modèle hérite du maître. Une valeur définie directement sur une diapositive normale remplace la valeur héritée à ce niveau. Lorsqu'une diapositive normale est créée, ses formes d'espace réservé sont générées à partir du modèle sélectionné, tandis que le contenu saisi dans ces espaces réservés appartient à la diapositive normale.

Ajoutez les espaces réservés requis à un modèle avant de créer des diapositives à partir de celui-ci. Ajouter un autre espace réservé à un modèle ultérieurement n'ajoute pas automatiquement une forme d'espace réservé correspondante aux diapositives normales existantes.

Cette relation entraîne deux conséquences importantes :

- Modifier le formatage hérité ou la géométrie des espaces réservés existants sur un modèle peut mettre à jour chaque diapositive qui en dépend. Avant de modifier un modèle déjà utilisé, inspectez ses diapositives dépendantes et examinez la présentation résultante.
- Un modèle encore utilisé par une diapositive ne peut pas être supprimé. Réattribuez d'abord ses diapositives dépendantes à un autre modèle, ou supprimez uniquement les modèles inutilisés.

Pour plus d'informations sur le niveau supérieur de cette hiérarchie, voyez [Maître de diapositive](/slides/fr/python-net/slide-master/).

## **Sélectionner et appliquer un modèle de diapositive**

Utilisez un type de modèle lorsque la présentation suit les définitions de modèles PowerPoint standard. Les noms de modèles sont éditables par l'utilisateur et peuvent être localisés, ainsi la sélection basée sur le nom est moins fiable à moins que vous ne contrôliez le modèle source.

L'exemple suivant recherche **Titre et contenu** sur le premier maître. Si ce modèle n'est pas disponible, il revient délibérément à **Vide**. La seconde vérification de nullité est nécessaire car une présentation ne peut contenir que des modèles personnalisés. Le modèle sélectionné est ensuite appliqué à la première diapositive normale via la propriété [Slide.layout_slide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/layout_slide/).

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slides = presentation.masters[0].layout_slides
    target_layout = layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if target_layout is None:
        target_layout = layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if target_layout is None:
        raise RuntimeError("The first master does not contain a suitable layout slide.")

    presentation.slides[0].layout_slide = target_layout
    presentation.save("output-with-new-layout.pptx", slides.export.SaveFormat.PPTX)
```

Modifier le modèle d'une diapositive ne supprime pas les formes ordinaires ajoutées directement à la diapositive. Cependant, les positions des espaces réservés, le formatage hérité et la correspondance entre les espaces réservés existants et le nouveau modèle peuvent changer, il faut donc inspecter le résultat lors du passage entre des modèles sensiblement différents.

## **Ajouter une diapositive de modèle**

La sélection et la création sont des opérations distinctes. L'exemple précédent sélectionne un modèle existant ; il n'en crée pas. Pour créer un modèle, appelez la méthode [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterlayoutslidecollection/add/) sur la collection de modèles du maître cible.

L'exemple suivant ajoute toujours un nouveau modèle **Titre et contenu** nommé `Report Title and Content`, puis ajoute une diapositive normale basée sur celui-ci. Les noms de modèles doivent être uniques au sein de la collection.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

Ajoutez un modèle uniquement lorsque le modèle nécessite réellement une autre structure réutilisable. Si un modèle approprié existe déjà, sélectionnez‑le et réutilisez‑le au lieu d'en créer un duplicata.

## **Ajouter des espaces réservés à une diapositive de modèle**

La propriété [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutslide/placeholder_manager/) fournit un [LayoutPlaceholderManager](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutplaceholdermanager/) pour ajouter des formes d'espace réservé à un modèle.

| Espace réservé PowerPoint | `LayoutPlaceholderManager` Method |
| -------------------------- | --------------------------------- |
| ![Contenu](content.png) | [`add_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutplaceholdermanager/add_content_placeholder/) |
| ![Contenu (Vertical)](contentV.png) | [`add_vertical_content_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_content_placeholder/) |
| ![Texte](text.png) | [`add_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutplaceholdermanager/add_text_placeholder/) |
| ![Texte (Vertical)](textV.png) | [`add_vertical_text_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutplaceholdermanager/add_vertical_text_placeholder/) |
| ![Image](picture.png) | [`add_picture_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutplaceholdermanager/add_picture_placeholder/) |
| ![Graphique](chart.png) | [`add_chart_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutplaceholdermanager/add_chart_placeholder/) |
| ![Tableau](table.png) | [`add_table_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutplaceholdermanager/add_table_placeholder/) |
| ![SmartArt](smartart.png) | [`add_smart_art_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutplaceholdermanager/add_smart_art_placeholder/) |
| ![Média](media.png) | [`add_media_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutplaceholdermanager/add_media_placeholder/) |
| ![Image en ligne](onlineImage.png) | [`add_online_image_placeholder(x, y, width, height)`](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutplaceholdermanager/add_online_image_placeholder/) |

L'exemple suivant vérifie que le modèle **Vide** existe, ajoute quatre espaces réservés à celui‑ci, puis crée une diapositive normale qui utilise le modèle modifié. L'ordre est intentionnel : les espaces réservés sont ajoutés avant la création de la diapositive normale, afin qu'Aspose.Slides puisse générer les formes d'espace réservé correspondantes sur cette diapositive.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    blank_layout = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if blank_layout is None:
        raise RuntimeError("The presentation does not contain a Blank layout slide.")

    placeholder_manager = blank_layout.placeholder_manager
    placeholder_manager.add_content_placeholder(20, 20, 310, 270)
    placeholder_manager.add_vertical_text_placeholder(350, 20, 350, 270)
    placeholder_manager.add_chart_placeholder(20, 310, 310, 180)
    placeholder_manager.add_table_placeholder(350, 310, 350, 180)

    presentation.slides.add_empty_slide(blank_layout)
    presentation.save("output-with-placeholders.pptx", slides.export.SaveFormat.PPTX)
```

Le résultat :

![Les espaces réservés sur la diapositive de modèle](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Modifier le formatage hérité ou la géométrie des espaces réservés de modèle existants peut affecter les diapositives dépendantes. Un espace réservé de modèle ajouté récemment n'est pas rétro‑appliqué aux diapositives normales existantes. Testez les modifications de modèle sur une copie de la présentation et inspectez chaque diapositive dépendante.
{{% /alert %}}

## **Supprimer les diapositives de modèle inutilisées**

Utilisez la méthode [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) pour supprimer les modèles auxquels aucune diapositive normale ne fait référence. La méthode laisse intacts les modèles encore utilisés.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

Pour supprimer un modèle spécifique, utilisez d'abord sa propriété [has_depending_slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutslide/has_depending_slides/) ou sa méthode [get_depending_slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutslide/get_depending_slides/). Réattribuez les diapositives dépendantes avant d'appeler [LayoutSlide.remove](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutslide/remove/). Tenter de supprimer un modèle utilisé déclenche une [PptxEditException](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pptxeditexception/).

## **Contrôler la visibilité du pied de page sur une diapositive de modèle**

Un modèle possède ses propres espaces réservés pour le pied de page, le numéro de diapositive et la date‑heure. Utilisez la propriété [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutslide/header_footer_manager/) pour contrôler ces espaces réservés pour un modèle. Ceci est utile lorsque, par exemple, les modèles de contenu doivent afficher les pieds de page mais pas les modèles de titre.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.TITLE_AND_OBJECT)

    if layout_slide is None:
        layout_slide = presentation.layout_slides.get_by_type(slides.SlideLayoutType.BLANK)

    if layout_slide is None:
        raise RuntimeError("The presentation does not contain a suitable layout slide.")

    header_footer_manager = layout_slide.header_footer_manager
    header_footer_manager.set_footer_visibility(True)
    header_footer_manager.set_slide_number_visibility(True)
    header_footer_manager.set_date_time_visibility(True)
    header_footer_manager.set_footer_text("Footer text")
    header_footer_manager.set_date_time_text("Date and time text")

    presentation.save("output-with-layout-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **Contrôler la visibilité du pied de page sur un maître et ses modèles enfants**

Pour appliquer des paramètres de pied de page cohérents à travers une hiérarchie de maître, utilisez la propriété [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterslide/header_footer_manager/). Les méthodes de propagation de [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterslideheaderfootermanager/) agissent sur le maître et ses diapositives de modèle et diapositives normales dépendantes ; elles ne ciblent pas une seule diapositive normale.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    header_footer_manager = presentation.masters[0].header_footer_manager
    header_footer_manager.set_footer_and_child_footers_visibility(True)
    header_footer_manager.set_slide_number_and_child_slide_numbers_visibility(True)
    header_footer_manager.set_date_time_and_child_date_times_visibility(True)
    header_footer_manager.set_footer_and_child_footers_text("Footer text")
    header_footer_manager.set_date_time_and_child_date_times_text("Date and time text")

    presentation.save("output-with-master-footers.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Quelle est la différence entre une diapositive maître et une diapositive de modèle ?**

Une diapositive maître définit le thème de la présentation et le formatage partagé. Une diapositive de modèle appartient à un maître et définit une disposition réutilisable d'espaces réservés. Les diapositives normales utilisent ces modèles et stockent le contenu propre à chaque diapositive.

**Puis‑je copier une diapositive de modèle d'une présentation à une autre ?**

Oui. Ajoutez une copie à la collection de destination avec la méthode [add_clone](https://reference.aspose.com/slides/fr/python-net/aspose.slides/globallayoutslidecollection/add_clone/). Lors de la copie entre présentations, vérifiez également les polices, les thèmes, les images et les autres ressources utilisées par le modèle source.

**Que se passe‑t‑il lorsque je modifie un modèle déjà utilisé ?**

Les diapositives dépendantes héritent des modifications du modèle sauf si elles remplacent localement le formatage ou les objets affectés. La géométrie des espaces réservés et le style hérité peuvent donc changer sur de nombreuses diapositives à la fois. Utilisez [get_depending_slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutslide/get_depending_slides/) pour identifier les diapositives concernées avant de modifier le modèle.

**Que se passe‑t‑il si je supprime un modèle qui est encore utilisé ?**

Aspose.Slides déclenche une [PptxEditException](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pptxeditexception/). Réattribuez d'abord les diapositives dépendantes, ou utilisez [remove_unused_layout_slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) pour supprimer uniquement les modèles non référencés.