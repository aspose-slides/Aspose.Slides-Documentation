---
title: Appliquer ou modifier les modèles de diapositives en JavaScript
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
- modèle inutilisé
- visibilité du pied de page
- diapositive titre
- titre et contenu
- en-tête de section
- deux contenus
- comparaison
- titre uniquement
- modèle vierge
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
description: "Appliquer, créer et modifier les modèles de diapositives dans Aspose.Slides pour Node.js via Java, ajouter des espaces réservés, supprimer les modèles inutilisés et contrôler la visibilité du pied de page."
---
## **Vue d'ensemble**

Un modèle de diapositive définit les positions et le formatage des espaces réservés tels que les titres, le texte, les images, les graphiques et les tableaux. Appliquer un modèle confère aux diapositives une structure cohérente tout en permettant à chaque diapositive de contenir son propre contenu.

- **Diapositive Titre** : Contient des espaces réservés pour le titre et le sous‑titre.
- **Titre et Contenu** : Contient un espace réservé pour le titre et un espace réservé de contenu à usage général.
- **Vide** : Ne contient aucun espace réservé de contenu et est utile lorsque chaque forme sera positionnée manuellement.

## **Comprendre l'héritage des modèles**

Une présentation possède trois niveaux associés :

1. Une [diapositive maître](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masterslide/) définit le thème, le formatage partagé, les arrière‑plans et les objets communs.
2. Une [diapositive modèle](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutslide/) appartient à un maître et définit un agencement particulier d'espaces réservés.
3. Une [diapositive normale](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slide/) utilise un modèle et stocke le contenu saisi pour cette diapositive.

Une diapositive normale hérite du thème et du formatage de son modèle, et le modèle hérite de son maître. Une valeur définie directement sur une diapositive normale remplace la valeur héritée à ce niveau. Lorsqu'une diapositive normale est créée, ses formes d'espace réservé sont générées à partir du modèle sélectionné, tandis que le contenu saisi dans ces espaces réservés appartient à la diapositive normale.

Ajoutez les espaces réservés requis à un modèle avant de créer des diapositives à partir de celui‑ci. Ajouter un autre espace réservé à un modèle ultérieurement n'ajoute pas automatiquement la forme d'espace réservé correspondante aux diapositives normales existantes.

Cette relation a deux conséquences importantes :

- Modifier le formatage hérité ou la géométrie des espaces réservés existants sur un modèle peut mettre à jour chaque diapositive qui en dépend. Avant de modifier un modèle déjà utilisé, inspectez ses diapositives dépendantes et examinez la présentation résultante.
- Un modèle encore utilisé par une diapositive ne peut pas être supprimé. Réattribuez d'abord ses diapositives dépendantes à un autre modèle, ou supprimez uniquement les modèles inutilisés.

Pour plus d'informations sur le niveau supérieur de cette hiérarchie, voir [Maître de diapositive](/slides/fr/nodejs-java/slide-master/).

## **Sélectionner et appliquer un modèle de diapositive**

Utilisez une valeur [SlideLayoutType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slidelayouttype/) lorsque la présentation suit les définitions de modèles standard de PowerPoint. Les noms de modèles sont modifiables par l'utilisateur et peuvent être localisés, de sorte que la sélection basée sur le nom est moins fiable sauf si vous contrôlez le modèle source.

L'exemple suivant recherche **Titre et Contenu** sur le premier maître. Si ce modèle est indisponible, il revient délibérément à **Vide**. La deuxième vérification de nullité est nécessaire car une présentation peut ne contenir que des modèles personnalisés. Le modèle sélectionné est ensuite appliqué à la première diapositive normale via la méthode [Slide.setLayoutSlide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slide/#setLayoutSlide).

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

Modifier le modèle d'une diapositive ne supprime pas les formes ordinaires ajoutées directement à la diapositive. Cependant, les positions des espaces réservés, le formatage hérité et la correspondance entre les espaces réservés existants et le nouveau modèle peuvent changer, il faut donc inspecter le résultat lors du passage entre des modèles sensiblement différents.

## **Ajouter une diapositive modèle**

La sélection et la création sont des opérations distinctes. L'exemple précédent sélectionne un modèle existant ; il n'en crée pas. Pour créer un modèle, appelez la méthode [MasterLayoutSlideCollection.add](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masterlayoutslidecollection/#add) sur la collection de modèles du maître cible.

L'exemple suivant ajoute toujours un nouveau modèle **Titre et Contenu** nommé `Report Title and Content`, puis ajoute une diapositive normale basée dessus. Les noms de modèles doivent être uniques au sein de la collection.

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

Ajoutez un modèle uniquement lorsque le modèle nécessite réellement une autre structure réutilisable. Si un modèle approprié existe déjà, sélectionnez‑le et réutilisez‑le plutôt que de créer un double.

## **Ajouter des espaces réservés à une diapositive modèle**

La méthode [LayoutSlide.getPlaceholderManager](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutslide/#getPlaceholderManager) fournit un [LayoutPlaceholderManager](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutplaceholdermanager/) pour ajouter des formes d'espaces réservés à un modèle.

| Espace réservé PowerPoint          | Méthode `LayoutPlaceholderManager` |
| ----------------------------------- | ----------------------------------- |
| ![Contenu](content.png)             | [`addContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutplaceholdermanager/#addContentPlaceholder) |
| ![Contenu (Vertical)](contentV.png) | [`addVerticalContentPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalContentPlaceholder) |
| ![Texte](text.png)                   | [`addTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTextPlaceholder) |
| ![Texte (Vertical)](textV.png)       | [`addVerticalTextPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutplaceholdermanager/#addVerticalTextPlaceholder) |
| ![Image](picture.png)                | [`addPicturePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutplaceholdermanager/#addPicturePlaceholder) |
| ![Graphique](chart.png)              | [`addChartPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutplaceholdermanager/#addChartPlaceholder) |
| ![Tableau](table.png)                | [`addTablePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutplaceholdermanager/#addTablePlaceholder) |
| ![SmartArt](smartart.png)            | [`addSmartArtPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutplaceholdermanager/#addSmartArtPlaceholder) |
| ![Média](media.png)                  | [`addMediaPlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutplaceholdermanager/#addMediaPlaceholder) |
| ![Image en ligne](onlineImage.png)   | [`addOnlineImagePlaceholder(x, y, width, height)`](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutplaceholdermanager/#addOnlineImagePlaceholder) |

L'exemple suivant vérifie que le modèle **Vide** existe, ajoute quatre espaces réservés à celui‑ci, puis crée une diapositive normale utilisant le modèle modifié. L'ordre est intentionnel : les espaces réservés sont ajoutés avant la création de la diapositive normale, afin qu'Aspose.Slides puisse générer les formes d'espaces réservés correspondantes sur cette diapositive.

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

![Les espaces réservés sur la diapositive modèle](add_placeholders.png)

{{% alert color="warning" title="Attention" %}}
Modifier le formatage hérité ou la géométrie des espaces réservés existants du modèle peut affecter les diapositives dépendantes. Un espace réservé de modèle nouvellement ajouté n'est pas répercuté rétroactivement sur les diapositives normales existantes. Testez les modifications de modèle sur une copie de la présentation et inspectez chaque diapositive dépendante.
{{% /alert %}}

## **Supprimer les diapositives modèles inutilisées**

Utilisez la méthode [Compress.removeUnusedLayoutSlides](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) pour supprimer les modèles qui ne sont référencés par aucune diapositive normale. La méthode laisse intacts les modèles qui sont toujours utilisés.

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

Pour supprimer un modèle spécifique, utilisez d'abord sa méthode [hasDependingSlides](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutslide/#hasDependingSlides) ou [getDependingSlides](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutslide/#getDependingSlides). Réattribuez toutes les diapositives dépendantes avant d'appeler [LayoutSlide.remove](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutslide/#remove). Tenter de supprimer un modèle utilisé déclenche une [PptxEditException](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pptxeditexception/).

## **Contrôler la visibilité du pied de page sur une diapositive modèle**

Un modèle possède ses propres espaces réservés de pied de page, de numéro de diapositive et de date/heure. Utilisez la méthode [LayoutSlide.getHeaderFooterManager](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutslide/#getHeaderFooterManager) pour contrôler ces espaces réservés pour un modèle. Cela est utile lorsque, par exemple, les modèles de contenu doivent afficher les pieds de page mais pas les modèles de titre.

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

## **Contrôler la visibilité du pied de page sur un maître et ses modèles enfants**

Pour appliquer des paramètres de pied de page cohérents sur toute une hiérarchie de maîtres, utilisez la méthode [MasterSlide.getHeaderFooterManager](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masterslide/#getHeaderFooterManager). Les méthodes de propagation de [MasterSlideHeaderFooterManager](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masterslideheaderfootermanager/) agissent sur le maître ainsi que sur ses diapositives modèles dépendantes et sur les diapositives normales ; elles ne ciblent pas une seule diapositive normale.

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

**Quelle est la différence entre une diapositive maître et une diapositive modèle ?**

Une diapositive maître définit le thème de la présentation et le formatage partagé. Une diapositive modèle appartient à un maître et définit un agencement réutilisable d'espaces réservés. Les diapositives normales utilisent ces modèles et stockent le contenu propre à chaque diapositive.

**Puis‑je copier une diapositive modèle d'une présentation à une autre ?**

Oui. Ajoutez une copie à la collection de destination avec la méthode [addClone](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/globallayoutslidecollection/#addClone). Lors de la copie entre présentations, vérifiez également les polices, les thèmes, les images et les autres ressources utilisées par le modèle source.

**Que se passe‑t‑il lorsque je modifie un modèle déjà utilisé ?**

Les diapositives dépendantes héritent des modifications du modèle sauf si elles remplacent localement le formatage ou les objets affectés. La géométrie des espaces réservés et le style hérité peuvent donc changer sur de nombreuses diapositives à la fois. Utilisez [getDependingSlides](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutslide/#getDependingSlides) pour identifier les diapositives affectées avant de modifier le modèle.

**Que se passe‑t‑il si je supprime un modèle qui est encore utilisé ?**

Aspose.Slides déclenche une [PptxEditException](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pptxeditexception/). Réattribuez d'abord les diapositives dépendantes, ou utilisez [removeUnusedLayoutSlides](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/compress/#removeUnusedLayoutSlides) pour supprimer uniquement les modèles non référencés.