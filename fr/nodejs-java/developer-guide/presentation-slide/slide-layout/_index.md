---
title: Appliquer ou modifier les dispositions de diapositives en JavaScript
linktitle: Disposition de diapositive
type: docs
weight: 60
url: /fr/nodejs-java/slide-layout/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Appliquer, créer et modifier les dispositions de diapositives dans Aspose.Slides pour Node.js via Java, ajouter des espaces réservés, supprimer les dispositions inutilisées et contrôler la visibilité du pied de page."
---
## **Vue d'ensemble**

Une disposition de diapositive définit les positions et le formatage des espaces réservés tels que les titres, le texte, les images, les graphiques et les tableaux. Appliquer une disposition donne aux diapositives une structure cohérente tout en permettant à chaque diapositive de contenir son propre contenu.

Les dispositions les plus courantes comprennent :

- **Diapositive Titre** : Contient des espaces réservés pour le titre et le sous-titre.
- **Titre et Contenu** : Contient un espace réservé pour le titre et un espace réservé de contenu à usage général.
- **Vide** : Ne contient aucun espace réservé de contenu et est utile lorsque chaque forme sera positionnée manuellement.

## **Comprendre l’héritage des dispositions**

Une présentation possède trois niveaux liés :

1. Une [diapositive maître](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masterslide/) définit le thème, le formatage partagé, les arrière-plans et les objets communs.
1. Une [diapositive de disposition](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutslide/) appartient à un maître et définit un arrangement particulier d’espaces réservés.
1. Une [diapositive normale](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slide/) utilise une disposition et stocke le contenu saisi pour cette diapositive.

Une diapositive normale hérite du thème et du formatage de sa disposition, et la disposition hérite de son maître. Une valeur définie directement sur une diapositive normale remplace la valeur héritée à ce niveau. Lorsqu’une diapositive normale est créée, ses formes d’espaces réservés sont générées à partir de la disposition sélectionnée, tandis que le contenu saisi dans ces espaces réservés appartient à la diapositive normale.

Ajoutez les espaces réservés requis à une disposition avant de créer des diapositives à partir de celle‑ci. Ajouter ultérieurement un autre espace réservé à une disposition n’ajoute pas automatiquement une forme d’espace réservé correspondante aux diapositives normales existantes.

Cette relation comporte deux conséquences importantes :

- Modifier le formatage hérité ou la géométrie d’un espace réservé existant sur une disposition peut mettre à jour chaque diapositive qui en dépend. Avant de modifier une disposition déjà utilisée, inspectez ses diapositives dépendantes et examinez la présentation résultante.
- Une disposition encore utilisée par une diapositive ne peut pas être supprimée. Réaffectez d’abord ses diapositives dépendantes à une autre disposition, ou supprimez uniquement les dispositions non utilisées.

Pour plus d’informations sur le niveau supérieur de cette hiérarchie, consultez [Maître de diapositive](/slides/fr/nodejs-java/slide-master/).

Pour masquer les logos hérités ou les formes maîtres décoratives sur une diapositive ou via une disposition partagée, voir [Contrôler la visibilité des graphiques maîtres](/slides/fr/nodejs-java/slide-master/). L’exemple compare deux diapositives utilisant le même maître.

## **Sélectionner et appliquer une disposition de diapositive**

Utilisez une valeur [SlideLayoutType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidelayouttype/) lorsque la présentation suit les définitions de dispositions standard de PowerPoint. Les noms de disposition sont modifiables par l’utilisateur et peuvent être localisés, ainsi la sélection basée sur le nom est moins fiable sauf si vous contrôlez le modèle source.

L’exemple suivant recherche **Title and Content** sur le premier maître. Si cette disposition n’est pas disponible, il revient délibérément à **Blank**. La deuxième vérification de nullité est nécessaire parce qu’une présentation ne peut contenir que des dispositions personnalisées. La disposition sélectionnée est ensuite appliquée à la première diapositive normale via la méthode [Slide.setLayoutSlide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slide/#setLayoutSlide).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let layoutSlides = presentation.getMasters().get_Item(0).getLayoutSlides();
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let targetLayout = layoutSlides.getByType(titleAndObjectLayoutType);

    if (targetLayout === null) {
        targetLayout = layoutSlides.getByType(blankLayoutType);
    }

    if (targetLayout === null) {
        throw new Error("The first master does not contain a suitable layout slide.");
    }

    presentation.getSlides().get_Item(0).setLayoutSlide(targetLayout);
    presentation.save("output-with-new-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Modifier la disposition d’une diapositive ne supprime pas les formes ordinaires ajoutées directement à la diapositive. Cependant, les positions des espaces réservés, le formatage hérité et la correspondance entre les espaces réservés existants et la nouvelle disposition peuvent changer, il convient donc d’inspecter le résultat lors du basculement entre des dispositions sensiblement différentes.

## **Ajouter une diapositive de disposition**

La sélection et la création sont des opérations distinctes. L’exemple précédent sélectionne une disposition existante ; il n’en crée pas. Pour créer une disposition, appelez la méthode [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) sur la collection de dispositions du maître ciblé.

L’exemple suivant ajoute toujours une nouvelle disposition **Title and Content** nommée `Report Title and Content`, puis ajoute une diapositive normale basée sur celle‑ci. Les noms de disposition doivent être uniques dans la collection.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let reportLayout = masterSlide.getLayoutSlides().add(titleAndObjectLayoutType, "Report Title and Content");
    presentation.getSlides().addEmptySlide(reportLayout);

    presentation.save("output-with-report-layout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ajoutez une disposition uniquement lorsque le modèle nécessite réellement une autre structure réutilisable. Si une disposition appropriée existe déjà, sélectionnez‑la et réutilisez‑la plutôt que de créer un doublon.

## **Ajouter des espaces réservés à une diapositive de disposition**

La méthode [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) fournit un [LayoutPlaceholderManager](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutplaceholdermanager/) pour ajouter des formes d’espaces réservés à une disposition.

| Espace réservé PowerPoint | `LayoutPlaceholderManager` Method |
| -------------------------- | --------------------------------- |
| ![Contenu](content.png) | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Contenu (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Texte](text.png) | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Texte (Vertical)](textV.png) | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Image](picture.png) | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Graphique](chart.png) | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tableau](table.png) | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png) | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Média](media.png) | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Image en ligne](onlineImage.png) | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

L’exemple suivant vérifie que la disposition **Blank** existe, ajoute quatre espaces réservés, puis crée une diapositive normale utilisant la disposition modifiée. L’ordre est intentionnel : les espaces réservés sont ajoutés avant la création de la diapositive normale, afin qu’Aspose.Slides puisse générer les formes d’espace réservé correspondantes sur cette diapositive.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayout = presentation.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayout === null) {
        throw new Error("The presentation does not contain a Blank layout slide.");
    }

    let placeholderManager = blankLayout.getPlaceholderManager();
    placeholderManager.addContentPlaceholder(20, 20, 310, 270);
    placeholderManager.addVerticalTextPlaceholder(350, 20, 350, 270);
    placeholderManager.addChartPlaceholder(20, 310, 310, 180);
    placeholderManager.addTablePlaceholder(350, 310, 350, 180);

    presentation.getSlides().addEmptySlide(blankLayout);
    presentation.save("output-with-placeholders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le résultat :

![Les espaces réservés sur la diapositive de disposition](add_placeholders.png)

{{% alert color="warning" title="Avertissement" %}}
Modifier le formatage hérité ou la géométrie des espaces réservés existants sur une disposition peut affecter les diapositives dépendantes. Un espace réservé de disposition ajouté récemment n’est pas rétro‑alimenté dans les diapositives normales existantes. Testez les changements de disposition sur une copie de la présentation et inspectez chaque diapositive dépendante.
{{% /alert %}}

## **Supprimer les diapositives de disposition inutilisées**

Utilisez la méthode [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) pour supprimer les dispositions auxquelles aucune diapositive normale ne fait référence. La méthode laisse intactes les dispositions encore utilisées.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    aspose.slides.Compress.removeUnusedLayoutSlides(presentation);
    presentation.save("output-without-unused-layouts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pour supprimer une disposition spécifique, utilisez d’abord sa méthode [hasDependingSlides](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) ou [getDependingSlides](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutslide/#getDependingSlides). Réaffectez les diapositives dépendantes avant d’appeler [LayoutSlide.remove](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutslide/#remove). Tenter de supprimer une disposition utilisée déclenche une [PptxEditException](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pptxeditexception/).

## **Contrôler la visibilité du pied de page sur une diapositive de disposition**

Une disposition possède ses propres espaces réservés de pied de page, de numéro de diapositive et de date‑heure. Utilisez la méthode [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) pour contrôler ces espaces réservés pour une disposition. Cela est utile, par exemple, lorsque les dispositions de contenu doivent afficher les pieds de page mais que les dispositions de titre ne le doivent pas.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let titleAndObjectLayoutType = java.newByte(aspose.slides.SlideLayoutType.TitleAndObject);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = presentation.getLayoutSlides().getByType(titleAndObjectLayoutType);

    if (layoutSlide === null) {
        layoutSlide = presentation.getLayoutSlides().getByType(blankLayoutType);
    }

    if (layoutSlide === null) {
        throw new Error("The presentation does not contain a suitable layout slide.");
    }

    let headerFooterManager = layoutSlide.getHeaderFooterManager();
    headerFooterManager.setFooterVisibility(true);
    headerFooterManager.setSlideNumberVisibility(true);
    headerFooterManager.setDateTimeVisibility(true);
    headerFooterManager.setFooterText("Footer text");
    headerFooterManager.setDateTimeText("Date and time text");

    presentation.save("output-with-layout-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Contrôler la visibilité du pied de page sur un maître et ses dispositions enfants**

Pour appliquer des paramètres de pied de page cohérents à toute la hiérarchie d’un maître, utilisez la méthode [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager). Les méthodes de propagation de [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masterslideheaderfootermanager/) agissent sur le maître ainsi que sur ses diapositives de disposition et ses diapositives normales ; elles ne ciblent pas une seule diapositive normale.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("input.pptx");
try {
    let headerFooterManager = presentation.getMasters().get_Item(0).getHeaderFooterManager();
    headerFooterManager.setFooterAndChildFootersVisibility(true);
    headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);
    headerFooterManager.setFooterAndChildFootersText("Footer text");
    headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");

    presentation.save("output-with-master-footers.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Quelle est la différence entre une diapositive maître et une diapositive de disposition ?**

Une diapositive maître définit le thème et le formatage partagé de la présentation. Une diapositive de disposition appartient à un maître et définit un arrangement réutilisable d’espaces réservés. Les diapositives normales utilisent ces dispositions et stockent le contenu propre à chaque diapositive.

**Puis-je copier une diapositive de disposition d’une présentation à une autre ?**

Oui. Ajoutez une copie à la collection de destination avec la méthode [addClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone). Lors de la copie entre présentations, vérifiez également les polices, les thèmes, les images et les autres ressources utilisées par la disposition source.

**Que se passe-t-il lorsque je modifie une disposition déjà utilisée ?**

Les diapositives dépendantes héritent des modifications de la disposition, sauf si elles remplacent localement le formatage ou les objets affectés. La géométrie des espaces réservés et le style hérité peuvent donc changer simultanément sur de nombreuses diapositives. Utilisez [getDependingSlides](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) pour identifier les diapositives concernées avant d’éditer la disposition.

**Que se passe-t-il si je supprime une disposition qui est encore utilisée ?**

Aspose.Slides déclenche une [PptxEditException](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pptxeditexception/). Réaffectez d’abord les diapositives dépendantes, ou utilisez [removeUnusedLayoutSlides](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) pour ne supprimer que les dispositions non référencées.