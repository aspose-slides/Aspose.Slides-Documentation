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
- présentation
- Python
- Aspose.Slides
description: "Appliquer, créer et modifier les dispositions de diapositives dans Aspose.Slides pour Python via .NET, ajouter des espaces réservés, supprimer les dispositions inutilisées et contrôler la visibilité du pied de page."
---
## **Vue d'ensemble**

Une disposition de diapositive définit les positions et le formatage des espaces réservés tels que les titres, le texte, les images, les graphiques et les tableaux. Appliquer une disposition donne aux diapositives une structure cohérente tout en permettant à chaque diapositive de contenir son propre contenu.

Les dispositions les plus courantes incluent :

- **Title Slide** : Contient des espaces réservés pour le titre et le sous‑titre.
- **Title and Content** : Contient un espace réservé pour le titre et un espace réservé de contenu à usage général.
- **Blank** : Ne contient aucun espace réservé de contenu et est utile lorsque chaque forme sera positionnée manuellement.

## **Comprendre l'héritage des dispositions**

Une présentation possède trois niveaux associés :

1. Un [master slide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterslide/) définit le thème, le formatage partagé, les arrière‑plans et les objets communs.
1. Un [layout slide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutslide/) appartient à un master et définit un arrangement particulier d'espaces réservés.
1. Une [normal slide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/) utilise une disposition et stocke le contenu saisi pour cette diapositive.

Une diapositive normale hérite du thème et du formatage de sa disposition, et la disposition hérite de son master. Une valeur définie directement sur une diapositive normale remplace la valeur héritée à ce niveau. Lorsqu’une diapositive normale est créée, ses formes d’espace réservé sont générées à partir de la disposition sélectionnée, tandis que le contenu saisi dans ces espaces réservés appartient à la diapositive normale.

Ajoutez les espaces réservés requis à une disposition avant de créer des diapositives à partir de celle‑ci. Ajouter un autre espace réservé à une disposition ultérieurement n’ajoute pas automatiquement une forme d’espace réservé correspondante aux diapositives normales existantes.

Cette relation a deux conséquences importantes :

- Modifier le formatage hérité ou la géométrie des espaces réservés existants sur une disposition peut mettre à jour chaque diapositive qui en dépend. Avant de modifier une disposition déjà utilisée, inspectez ses diapositives dépendantes et examinez la présentation résultante.
- Une disposition encore utilisée par une diapositive ne peut pas être supprimée. Réattribuez d’abord ses diapositives dépendantes à une autre disposition, ou supprimez uniquement les dispositions inutilisées.

Pour plus d’informations sur le niveau supérieur de cette hiérarchie, voir [Slide Master](/slides/fr/python-net/slide-master/).

Pour masquer les logos hérités ou les formes décoratives du master sur une diapositive ou via une disposition partagée, consultez [Control the Visibility of Master Graphics](/slides/fr/python-net/slide-master/). L’exemple compare deux diapositives utilisant le même master.

## **Sélectionner et appliquer une disposition de diapositive**

Utilisez un type de disposition lorsque la présentation suit les définitions de dispositions PowerPoint standard. Les noms de disposition sont modifiables par l’utilisateur et peuvent être localisés, de sorte qu’une sélection basée sur le nom est moins fiable sauf si vous contrôlez le modèle source.

L’exemple suivant recherche **Title and Content** sur le premier master. Si cette disposition n’est pas disponible, il revient délibérément à **Blank**. La deuxième vérification de nullité est nécessaire parce qu’une présentation ne peut contenir que des dispositions personnalisées. La disposition sélectionnée est ensuite appliquée à la première diapositive normale via la propriété [Slide.layout_slide](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/layout_slide/).

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

Modifier la disposition d’une diapositive ne supprime pas les formes ordinaires ajoutées directement à la diapositive. Cependant, les positions des espaces réservés, le formatage hérité et la correspondance entre les espaces réservés existants et la nouvelle disposition peuvent changer, il faut donc inspecter le résultat lors du passage entre des dispositions sensiblement différentes.

## **Ajouter une disposition de diapositive**

La sélection et la création sont des opérations séparées. L’exemple précédent sélectionne une disposition existante ; il n’en crée pas. Pour créer une disposition, appelez la méthode [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterlayoutslidecollection/add/) sur la collection de dispositions du master cible.

L’exemple suivant ajoute toujours une nouvelle disposition **Title and Content** nommée `Report Title and Content`, puis ajoute une diapositive normale basée sur celle‑ci. Les noms de disposition doivent être uniques au sein de la collection.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    master_slide = presentation.masters[0]
    report_layout = master_slide.layout_slides.add(slides.SlideLayoutType.TITLE_AND_OBJECT, "Report Title and Content")
    presentation.slides.add_empty_slide(report_layout)

    presentation.save("output-with-report-layout.pptx", slides.export.SaveFormat.PPTX)
```

Ajoutez une disposition uniquement lorsque le modèle a réellement besoin d’une autre structure réutilisable. Si une disposition appropriée existe déjà, sélectionnez‑la et réutilisez‑la plutôt que de créer un doublon.

## **Ajouter des espaces réservés à une disposition de diapositive**

La propriété [LayoutSlide.placeholder_manager](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutslide/placeholder_manager/) fournit un [LayoutPlaceholderManager](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutplaceholdermanager/) pour ajouter des formes d’espace réservé à une disposition.

| Espace réservé PowerPoint | `LayoutPlaceholderManager` Méthode |
| -------------------------- | ----------------------------------- |
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

L’exemple suivant vérifie que la disposition **Blank** existe, ajoute quatre espaces réservés à celle‑ci, puis crée une diapositive normale qui utilise la disposition modifiée. L’ordre est intentionnel : les espaces réservés sont ajoutés avant la création de la diapositive normale, de sorte qu’Aspose.Slides puisse générer les formes d’espace réservé correspondantes sur cette diapositive.

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

![Les espaces réservés sur la diapositive de disposition](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}
Modifier le formatage hérité ou la géométrie des espaces réservés existants d’une disposition peut affecter les diapositives dépendantes. Un espace réservé de disposition ajouté récemment n’est pas rétro‑injecté dans les diapositives normales existantes. Testez les modifications de disposition sur une copie de la présentation et inspectez chaque diapositive dépendante.
{{% /alert %}}

## **Supprimer les dispositions de diapositive inutilisées**

Utilisez la méthode [Compress.remove_unused_layout_slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) pour supprimer les dispositions qui ne sont référencées par aucune diapositive normale. La méthode laisse intactes les dispositions encore utilisées.

```python
import aspose.slides as slides

with slides.Presentation("input.pptx") as presentation:
    slides.lowcode.Compress.remove_unused_layout_slides(presentation)
    presentation.save("output-without-unused-layouts.pptx", slides.export.SaveFormat.PPTX)
```

Pour supprimer une disposition spécifique, utilisez d’abord sa propriété [has_depending_slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutslide/has_depending_slides/) ou sa méthode [get_depending_slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutslide/get_depending_slides/). Réattribuez les diapositives dépendantes avant d’appeler [LayoutSlide.remove](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutslide/remove/). Tenter de supprimer une disposition utilisée provoque une [PptxEditException](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pptxeditexception/).

## **Contrôler la visibilité du pied de page sur une disposition de diapositive**

Une disposition possède ses propres espaces réservés pour le pied de page, le numéro de diapositive et la date‑heure. Utilisez la propriété [LayoutSlide.header_footer_manager](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutslide/header_footer_manager/) pour contrôler ces espaces réservés pour une disposition. Ceci est utile lorsque, par exemple, les dispositions de contenu doivent afficher les pieds de page mais pas les dispositions de titre.

L’exemple suivant sélectionne une disposition en toute sécurité et rend ses éléments de pied de page visibles :

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

## **Contrôler la visibilité du pied de page sur un master et ses dispositions enfant**

Pour appliquer des paramètres de pied de page cohérents à travers une hiérarchie de master, utilisez la propriété [MasterSlide.header_footer_manager](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterslide/header_footer_manager/). Les méthodes de propagation de [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/fr/python-net/aspose.slides/masterslideheaderfootermanager/) opèrent sur le master ainsi que sur ses dispositions et diapositives normales dépendantes ; elles ne ciblent pas une seule diapositive normale.

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

**Quelle est la différence entre un master slide et un layout slide ?**

Un master slide définit le thème de la présentation et le formatage partagé. Un layout slide appartient à un master et définit un agencement réutilisable d’espaces réservés. Les diapositives normales utilisent ces dispositions et stockent le contenu propre à chaque diapositive.

**Puis‑je copier un layout slide d’une présentation à une autre ?**

Oui. Ajoutez une copie à la collection de destination avec la méthode [add_clone](https://reference.aspose.com/slides/fr/python-net/aspose.slides/globallayoutslidecollection/add_clone/). Lors de la copie entre présentations, vérifiez également les polices, les thèmes, les images et les autres ressources utilisées par la disposition source.

**Que se passe‑t‑il lorsque je modifie une disposition déjà utilisée ?**

Les diapositives dépendantes héritent des modifications de la disposition à moins qu’elles ne remplacent localement le formatage ou les objets affectés. La géométrie des espaces réservés et le style hérité peuvent donc changer sur de nombreuses diapositives à la fois. Utilisez [get_depending_slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/layoutslide/get_depending_slides/) pour identifier les diapositives concernées avant de modifier la disposition.

**Que se passe‑t‑il si je supprime une disposition encore utilisée ?**

Aspose.Slides lève une [PptxEditException](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pptxeditexception/). Réattribuez d’abord les diapositives dépendantes, ou utilisez [remove_unused_layout_slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides.lowcode/compress/remove_unused_layout_slides/) pour supprimer uniquement les dispositions non référencées.