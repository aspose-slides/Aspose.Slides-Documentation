---
title: Appliquer ou modifier les dispositions de diapositives en Python via Java
linktitle: Disposition de diapositive
type: docs
weight: 60
url: /fr/python-java/slide-layout/
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
- titre uniquement
- disposition vierge
- contenu avec légende
- image avec légende
- titre et texte vertical
- titre vertical et texte
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Appliquer, créer et modifier les dispositions de diapositives dans Aspose.Slides pour Python via Java, ajouter des espaces réservés, supprimer les dispositions inutilisées et contrôler la visibilité du pied de page."
---
## **Vue d'ensemble**

Une disposition de diapositive définit les positions et le formatage des espaces réservés tels que les titres, le texte, les images, les graphiques et les tableaux. Appliquer une disposition donne aux diapositives une structure cohérente tout en permettant à chaque diapositive de contenir son propre contenu.

Les dispositions les plus courantes comprennent :

- **Diapositive Titre** : Contient des espaces réservés pour le titre et le sous‑titre.
- **Titre et Contenu** : Contient un espace réservé pour le titre et un espace réservé à usage général pour le contenu.
- **Vide** : Ne contient aucun espace réservé et est utile lorsque chaque forme sera positionnée manuellement.

## **Comprendre l'héritage des dispositions**

Une présentation possède trois niveaux liés :

1. Une [diapositive maître](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterslide/) définit le thème, le formatage partagé, les arrière‑plans et les objets communs.
1. Une [diapositive de disposition](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layoutslide/) appartient à un maître et définit un agencement particulier d’espaces réservés.
1. Une [diapositive normale](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/) utilise une disposition et stocke le contenu saisi pour cette diapositive.

Une diapositive normale hérite du thème et du formatage de sa disposition, et la disposition hérite de son maître. Une valeur définie directement sur une diapositive normale remplace la valeur héritée à ce niveau. Lorsqu’une diapositive normale est créée, ses formes d’espaces réservés sont générées à partir de la disposition sélectionnée, tandis que le contenu saisi dans ces espaces réservés appartient à la diapositive normale.

Ajoutez les espaces réservés requis à une disposition avant de créer des diapositives à partir de celle‑ci. Ajouter ultérieurement un autre espace réservé à une disposition n’ajoute pas automatiquement une forme d’espace réservé correspondante aux diapositives normales existantes.

Cette relation entraîne deux conséquences importantes :

- Modifier le formatage hérité ou la géométrie d’un espace réservé existant sur une disposition peut mettre à jour chaque diapositive qui en dépend. Avant de modifier une disposition déjà utilisée, inspectez ses diapositives dépendantes et examinez la présentation résultante.
- Une disposition encore utilisée par une diapositive ne peut pas être supprimée. Réattribuez d’abord ses diapositives dépendantes à une autre disposition, ou supprimez uniquement les dispositions inutilisées.

Pour plus d’informations sur le niveau supérieur de cette hiérarchie, consultez [Maître de diapositive](/slides/fr/python-java/slide-master/).

## **Sélectionner et appliquer une disposition de diapositive**

Utilisez un type de disposition lorsque la présentation suit les définitions de dispositions PowerPoint standard. Les noms de disposition sont modifiables par l’utilisateur et peuvent être localisés, de sorte qu’une sélection basée sur le nom soit moins fiable à moins que vous ne contrôliez le modèle source.

L’exemple suivant recherche **Titre et Contenu** sur le premier maître. Si cette disposition n’est pas disponible, il revient délibérément à **Vide**. La seconde vérification pour `None` est nécessaire parce qu’une présentation peut ne contenir que des dispositions personnalisées. La disposition sélectionnée est ensuite appliquée à la première diapositive normale via la méthode [Slide.setLayoutSlide](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#setLayoutSlide).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slides = presentation.getMasters().get_Item(0).getLayoutSlides()
    target_layout = layout_slides.getByType(SlideLayoutType.TitleAndObject)

    if target_layout is None:
        target_layout = layout_slides.getByType(SlideLayoutType.Blank)

    if target_layout is None:
        print("The first master does not contain a suitable layout slide.")
    else:
        presentation.getSlides().get_Item(0).setLayoutSlide(target_layout)
        presentation.save("output-with-new-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Modifier la disposition d’une diapositive ne supprime pas les formes ordinaires ajoutées directement à la diapositive. Cependant, les positions des espaces réservés, le formatage hérité et la correspondance entre les espaces réservés existants et la nouvelle disposition peuvent changer, il faut donc inspecter le résultat lors du passage entre des dispositions sensiblement différentes.

## **Ajouter une diapositive de disposition**

La sélection et la création sont des opérations distinctes. L’exemple précédent sélectionne une disposition existante ; il ne la crée pas. Pour créer une disposition, appelez la méthode [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterlayoutslidecollection/#add) sur la collection de dispositions du maître cible.

L’exemple suivant ajoute toujours une nouvelle disposition **Titre et Contenu** nommée `Report Title and Content`, puis ajoute une diapositive normale basée sur celle‑ci. Les noms de disposition doivent être uniques au sein de la collection.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    master_slide = presentation.getMasters().get_Item(0)
    report_layout = master_slide.getLayoutSlides().add(SlideLayoutType.TitleAndObject, "Report Title and Content")
    presentation.getSlides().addEmptySlide(report_layout)

    presentation.save("output-with-report-layout.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Ajoutez une disposition uniquement lorsque le modèle nécessite réellement une autre structure réutilisable. Si une disposition adaptée existe déjà, sélectionnez‑la et réutilisez‑la plutôt que de créer un doublon.

## **Ajouter des espaces réservés à une diapositive de disposition**

La méthode [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layoutslide/#getPlaceholderManager) fournit un [LayoutPlaceholderManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layoutplaceholdermanager/) pour ajouter des formes d’espaces réservés à une disposition.

| Espace réservé PowerPoint          | Méthode [LayoutPlaceholderManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layoutplaceholdermanager/) |
| ----------------------------------- | -------------------------------------------------------------------------------------------------------------- |
| ![Contenu](content.png)             | [addContentPlaceholder](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Contenu (Vertical)](contentV.png) | [addVerticalContentPlaceholder](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Texte](text.png)                  | [addTextPlaceholder](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Texte (Vertical)](textV.png)      | [addVerticalTextPlaceholder](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Image](picture.png)               | [addPicturePlaceholder](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Graphique](chart.png)             | [addChartPlaceholder](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tableau](table.png)               | [addTablePlaceholder](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)           | [addSmartArtPlaceholder](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Média](media.png)                 | [addMediaPlaceholder](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Image en ligne](onlineImage.png)  | [addOnlineImagePlaceholder](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

L’exemple suivant vérifie que la disposition **Vide** existe, y ajoute quatre espaces réservés, puis crée une diapositive normale qui utilise la disposition modifiée. L’ordre est intentionnel : les espaces réservés sont ajoutés avant la création de la diapositive normale, de sorte qu’Aspose.Slides puisse générer les formes d’espaces réservés correspondantes sur cette diapositive.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation()
try:
    blank_layout = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if blank_layout is None:
        print("The presentation does not contain a Blank layout slide.")
    else:
        placeholder_manager = blank_layout.getPlaceholderManager()
        placeholder_manager.addContentPlaceholder(20, 20, 310, 270)
        placeholder_manager.addVerticalTextPlaceholder(350, 20, 350, 270)
        placeholder_manager.addChartPlaceholder(20, 310, 310, 180)
        placeholder_manager.addTablePlaceholder(350, 310, 350, 180)

        presentation.getSlides().addEmptySlide(blank_layout)
        presentation.save("output-with-placeholders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Le résultat :

![Les espaces réservés sur la diapositive de disposition](add_placeholders.png)

{{% alert color="warning" title="Warning" %}}

Modifier le formatage hérité ou la géométrie des espaces réservés existants d’une disposition peut affecter les diapositives dépendantes. Un espace réservé ajouté récemment n’est pas rétro‑appliqué aux diapositives normales existantes. Testez les modifications de disposition sur une copie de la présentation et inspectez chaque diapositive dépendante.

{{% /alert %}}

## **Supprimer les diapositives de disposition inutilisées**

Utilisez la méthode [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) pour supprimer les dispositions auxquelles aucune diapositive normale ne fait référence. La méthode laisse intactes les dispositions encore utilisées.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Compress, Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    Compress.removeUnusedLayoutSlides(presentation)
    presentation.save("output-without-unused-layouts.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Pour supprimer une disposition spécifique, utilisez d’abord sa méthode [hasDependingSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layoutslide/#hasDependingSlides) ou [getDependingSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layoutslide/#getDependingSlides). Réattribuez toutes les diapositives dépendantes avant d’appeler [LayoutSlide.remove](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layoutslide/#remove). Tenter de supprimer une disposition utilisée déclenche une [PptxEditException](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pptxeditexception/).

## **Contrôler la visibilité du pied de page sur une diapositive de disposition**

Une disposition possède ses propres espaces réservés pour le pied de page, le numéro de diapositive et la date‑heure. Utilisez la méthode [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layoutslide/#getHeaderFooterManager) pour contrôler ces espaces réservés pour une disposition. Cela est utile, par exemple, lorsque les dispositions de contenu doivent afficher les pieds de page mais pas les dispositions de titre.

L’exemple suivant sélectionne en toute sécurité une disposition et rend ses éléments de pied de page visibles :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, SlideLayoutType

presentation = Presentation("input.pptx")
try:
    layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject)

    if layout_slide is None:
        layout_slide = presentation.getLayoutSlides().getByType(SlideLayoutType.Blank)

    if layout_slide is None:
        print("The presentation does not contain a suitable layout slide.")
    else:
        header_footer_manager = layout_slide.getHeaderFooterManager()
        header_footer_manager.setFooterVisibility(True)
        header_footer_manager.setSlideNumberVisibility(True)
        header_footer_manager.setDateTimeVisibility(True)
        header_footer_manager.setFooterText("Footer text")
        header_footer_manager.setDateTimeText("Date and time text")

        presentation.save("output-with-layout-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Contrôler la visibilité du pied de page sur un maître et ses dispositions enfants**

Pour appliquer des réglages de pied de page cohérents à l’ensemble de la hiérarchie d’un maître, utilisez la méthode [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterslide/#getHeaderFooterManager). Les méthodes de propagation de [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/masterslideheaderfootermanager/) agissent sur le maître ainsi que sur ses diapositives de disposition dépendantes et sur les diapositives normales ; elles ne ciblent pas une seule diapositive normale.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("input.pptx")
try:
    header_footer_manager = presentation.getMasters().get_Item(0).getHeaderFooterManager()
    header_footer_manager.setFooterAndChildFootersVisibility(True)
    header_footer_manager.setSlideNumberAndChildSlideNumbersVisibility(True)
    header_footer_manager.setDateTimeAndChildDateTimesVisibility(True)
    header_footer_manager.setFooterAndChildFootersText("Footer text")
    header_footer_manager.setDateTimeAndChildDateTimesText("Date and time text")

    presentation.save("output-with-master-footers.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Quelle est la différence entre une diapositive maître et une diapositive de disposition ?**

Une diapositive maître définit le thème de la présentation et le formatage partagé. Une diapositive de disposition appartient à un maître et définit un agencement réutilisable d’espaces réservés. Les diapositives normales utilisent ces dispositions et stockent le contenu propre à chaque diapositive.

**Puis‑je copier une diapositive de disposition d’une présentation à une autre ?**

Oui. Ajoutez une copie à la collection de destination avec la méthode [addClone](https://reference.aspose.com/slides/fr/python-java/aspose.slides/globallayoutslidecollection/#addClone). Lors de la copie entre présentations, vérifiez également les polices, thèmes, images et autres ressources utilisées par la disposition source.

**Que se passe‑t‑il si je modifie une disposition déjà utilisée ?**

Les diapositives dépendantes héritent des modifications de la disposition sauf si elles remplacent localement le formatage ou les objets affectés. La géométrie des espaces réservés et le style hérité peuvent donc changer simultanément sur de nombreuses diapositives. Utilisez [getDependingSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/layoutslide/#getDependingSlides) pour identifier les diapositives concernées avant d’éditer la disposition.

**Que se passe‑t‑il si je supprime une disposition qui est encore utilisée ?**

Aspose.Slides lève une [PptxEditException](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pptxeditexception/). Réattribuez d’abord les diapositives dépendantes, ou utilisez [removeUnusedLayoutSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/compress/#removeUnusedLayoutSlides) pour supprimer uniquement les dispositions non référencées.