---
title: Gestion des maîtres de diapositives de présentation en JavaScript
linktitle: Maître de diapositive
type: docs
weight: 70
url: /fr/nodejs-java/slide-master/
keywords:
- maître de diapositive
- diapositive maître
- diapositive maître PPT
- plusieurs maîtres de diapositives
- comparaison de maîtres de diapositives
- arrière-plan
- espace réservé
- cloner diapositive maître
- copier diapositive maître
- dupliquer diapositive maître
- maître de diapositive inutilisé
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Gérez les maîtres de diapositives dans Aspose.Slides pour Node.js via Java : accédez, modifiez, clonez, comparez et supprimez les diapositives maîtres dans les présentations PowerPoint et OpenDocument."
---
## **Vue d’ensemble**

Un **maître de diapositive** définit des paramètres de conception partagés pour un groupe de diapositives. Il peut contenir des formes communes, des logos, des arrière‑plans, des styles de texte, des paramètres de thème et des paramètres de pied de page. Dans PowerPoint, la modification d’un maître de diapositive est la façon habituelle de garder une présentation cohérente sans répéter le même formatage sur chaque diapositive.

Aspose.Slides for Node.js via Java prend en charge le même modèle. Une présentation peut contenir une ou plusieurs maîtres de diapositives, et chaque maître peut contenir plusieurs diapositives de mise en page. Les diapositives normales ne font généralement pas référence directement à un maître de diapositive. À la place, une diapositive normale utilise une diapositive de mise en page, et cette diapositive de mise en page appartient à un maître de diapositive.

La hiérarchie est :

1. **Maître de diapositive** – définit la conception et le thème partagés.  
1. **Diapositive de mise en page** – définit une disposition spécifique de zones réservées et de formatage au niveau de la mise en page.  
1. **Diapositive normale** – contient le contenu réel de la présentation et utilise une diapositive de mise en page.

![La hiérarchie des maîtres de diapositives, des diapositives de mise en page et des diapositives normales](slide-master_2.jpg)

Dans Aspose.Slides, un maître de diapositive est représenté par la classe [MasterSlide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masterslide/). Tous les maîtres de diapositives d’une présentation sont accessibles via la collection `Presentation.getMasters()`.

{{% alert color="info" title="Héritage" %}}

Lorsque la même propriété est définie à plusieurs niveaux, le niveau le plus spécifique l’emporte. Par exemple, si un maître de diapositive et une diapositive de mise en page définissent tous deux un arrière‑plan, les diapositives basées sur cette mise en page utilisent l’arrière‑plan de la mise en page. Pour plus d’informations sur les diapositives de mise en page, voir [Apply or Change Slide Layouts](/nodejs-java/slide-layout/).

{{% /alert %}}

## **Accéder aux maîtres de diapositives**

Dans PowerPoint, vous pouvez ouvrir la vue Maître des diapositives via **Affichage** > **Maître des diapositives**.

![La commande Maître des diapositives dans l’onglet Affichage de PowerPoint](slide-master_3.jpg)

Dans Aspose.Slides, utilisez la collection `getMasters()` pour accéder aux maîtres de diapositives :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let firstMasterSlide = presentation.getMasters().get_Item(0);
    let masterSlideCount = presentation.getMasters().size();
    let firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    console.log("Master slides: " + masterSlideCount);
    console.log("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

Vous pouvez également obtenir le maître de diapositive utilisé par une diapositive normale via sa mise en page :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let layoutSlide = slide.getLayoutSlide();
    let masterSlide = layoutSlide.getMasterSlide();
    let masterSlideName = masterSlide.getName();

    console.log(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **Contenu d’un maître de diapositive**

Un maître de diapositive est un objet semblable à une diapositive. Il hérite du comportement commun des diapositives depuis [BaseSlide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseslide/), ce qui lui donne accès à de nombreuses propriétés de diapositive également utilisées par les diapositives normales et de mise en page. Les membres spécifiques au maître sont listés sur la page API [MasterSlide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masterslide/).

Parmi les membres du maître de diapositive les plus utilisés :

| Membre | Objectif |
| --- | --- |
| `getBackground()` | Définit l’arrière‑plan au niveau du maître. |
| `getShapes()` | Contient les formes placées sur le maître, comme les logos, les cadres d’image et le texte partagé. |
| `getLayoutSlides()` | Contient les diapositives de mise en page appartenant au maître. |
| `getThemeManager()` | Fournit l’accès aux API du thème du maître. |
| `getHeaderFooterManager()` | Contrôle les en‑têtes, pieds de page, dates et numéros de diapositive pour le maître et ses mises en page enfants. |
| `getDependingSlides()` | Retourne les diapositives normales qui dépendent du maître via leurs mises en page. |

## **Ajouter une image à un maître de diapositive**

Lorsque vous ajoutez une image à un maître de diapositive, elle apparaît sur les diapositives qui utilisent des mises en page de ce maître. Cela est utile pour les logos, filigranes, bandes décoratives et autres éléments visuels répétés.

L’exemple suivant ajoute un logo au premier maître de diapositive :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let logo = aspose.slides.Images.fromFile("logo.png");

    try {
        let logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
            aspose.slides.ShapeType.Rectangle,
            20,
            20,
            80,
            80,
            logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pour plus d’informations sur les cadres d’image, voir [Picture Frame](/nodejs-java/picture-frame/).

## **Travailler avec les espaces réservés**

Les espaces réservés sont généralement définis sur les diapositives de mise en page. Le maître de diapositive fournit le style et le thème partagés que ces mises en page héritent, tandis que chaque mise en page décide quels espaces réservés sont disponibles et où ils sont placés.

Dans PowerPoint, les commandes d’espace réservé sont disponibles en mode Maître des diapositives.

![La commande Insérer un espace réservé dans la vue Maître des diapositives de PowerPoint](slide-master_5.png)

Pour ajouter de nouveaux espaces réservés avec Aspose.Slides, travaillez sur la diapositive de mise en page qui appartient au maître :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let blankLayoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);

    if (blankLayoutSlide === null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(blankLayoutType, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Vous pouvez également formater les formes d’espace réservé déjà présentes sur un maître de diapositive. L’exemple suivant trouve l’espace réservé au titre et applique un remplissage en dégradé linéaire :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let titlePlaceholder = null;
    let masterShapes = masterSlide.getShapes();
    let masterShapeCount = masterShapes.size();

    for (let masterShapeIndex = 0; masterShapeIndex < masterShapeCount; masterShapeIndex++) {
        let shape = masterShapes.get_Item(masterShapeIndex);

        if (java.instanceOf(shape, "com.aspose.slides.AutoShape")) {
            let placeholder = shape.getPlaceholder();

            if (placeholder !== null && placeholder.getType() === aspose.slides.PlaceholderType.Title) {
                titlePlaceholder = shape;
                break;
            }
        }
    }

    if (titlePlaceholder !== null) {
        let gradientFillType = java.newByte(aspose.slides.FillType.Gradient);
        let linearGradientShape = java.newByte(aspose.slides.GradientShape.Linear);
        let redGradientColor = java.newInstanceSync("java.awt.Color", 255, 0, 0);
        let purpleGradientColor = java.newInstanceSync("java.awt.Color", 128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(gradientFillType);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(linearGradientShape);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Espace réservé au titre formaté hérité par les diapositives normales](slide-master_8.png)

Pour d’autres options de formatage des espaces réservés et du texte, voir [Set Prompt Text in Placeholder](/nodejs-java/manage-placeholder/) et [Text Formatting](/nodejs-java/text-formatting/).

## **Modifier l’arrière‑plan d’un maître de diapositive**

Un arrière‑plan de maître est hérité par les mises en page et les diapositives qui ne le remplacent pas. L’exemple suivant définit une couleur d’arrière‑plan unie pour le premier maître de diapositive :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let masterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "GREEN");

    masterSlide.getBackground().setType(ownBackgroundType);
    masterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pour les sujets associés, voir [Presentation Background](/nodejs-java/presentation-background/) et [Presentation Theme](/nodejs-java/presentation-theme/).

## **Cloner un maître de diapositive vers une autre présentation**

Utilisez `MasterSlideCollection.addClone` pour copier un maître de diapositive dans une autre présentation. Le maître copié peut alors être utilisé par les mises en page et les diapositives de la présentation de destination.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let sourcePresentation = new aspose.slides.Presentation("source.pptx");
let destinationPresentation = new aspose.slides.Presentation("destination.pptx");
try {
    let sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    let clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Si vous devez cloner des diapositives normales avec leur maître, voir [Clone Slides](/nodejs-java/clone-slides/).

## **Ajouter plusieurs maîtres de diapositives**

Une présentation peut contenir plusieurs maîtres de diapositives. Ceci est utile lorsque différentes sections nécessitent une identité visuelle, une structure de page ou des paramètres de thème différents.

![Commandes PowerPoint pour insérer et gérer les maîtres de diapositives](slide-master_9.jpg)

L’exemple suivant clone le maître par défaut, donne au clone un arrière‑plan différent, crée une mise en page sous ce maître cloné, et ajoute une nouvelle diapositive basée sur cette mise en page :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let defaultMasterSlide = presentation.getMasters().get_Item(0);
    let sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    let ownBackgroundType = java.newByte(aspose.slides.BackgroundType.OwnBackground);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let sectionMasterBackgroundColor = java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY");

    sectionMasterSlide.getBackground().setType(ownBackgroundType);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(solidFillType);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(blankLayoutType);
    if (sourceBlankLayout === null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    let sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Comparer les maîtres de diapositives**

Les maîtres de diapositives peuvent être comparés avec la méthode `equals` héritée de [BaseSlide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseslide/). La comparaison vérifie la structure et le contenu statique, tels que les formes, le texte, le formatage, les animations et d’autres paramètres de diapositive. Elle ne compare pas les identifiants uniques, comme les IDs de diapositive, ni les valeurs dynamiques d’espaces réservés, comme la date actuelle.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let firstPresentation = new aspose.slides.Presentation("first.pptx");
let secondPresentation = new aspose.slides.Presentation("second.pptx");
try {
    let firstPresentationMasterCount = firstPresentation.getMasters().size();
    let secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (let firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (let secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            let firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            let secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            let areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                console.log(
                    "first.pptx master #" + firstMasterIndex +
                    " equals second.pptx master #" + secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

Pour plus d’informations, voir [Compare Presentation Slides](/slides/fr/nodejs-java/compare-slides/).

## **Définir la vue Maître des diapositives comme vue par défaut**

Utilisez la méthode `setLastView` sur [ViewProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/viewproperties/) pour contrôler la vue que PowerPoint ouvre en premier. L’exemple suivant ouvre la présentation en mode Maître des diapositives :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    let slideMasterViewType = java.newByte(aspose.slides.ViewType.SlideMasterView);

    presentation.getViewProperties().setLastView(slideMasterViewType);
    presentation.save("presentation-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pour plus de paramètres d’affichage, voir [Save Presentation](/slides/fr/nodejs-java/save-presentation/).

## **Supprimer les maîtres de diapositives inutilisés**

Les présentations contiennent parfois des maîtres de diapositives qui ne sont plus utilisés par aucune diapositive normale. Supprimer les maîtres inutilisés peut réduire la taille du fichier et simplifier la maintenance du modèle.

Utilisez `removeUnused` pour retirer les maîtres inutilisés de la collection `getMasters()` :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Vous pouvez également utiliser la méthode à faible code `Compress.removeUnusedMasterSlides` :

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    aspose.slides.Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

### Quelle est la différence entre un maître de diapositive et une diapositive de mise en page ?

Un maître de diapositive définit des paramètres de conception partagés tels que le thème, l’arrière‑plan, les formes communes et les styles de texte. Une diapositive de mise en page appartient à un maître de diapositive et définit une disposition spécifique d’espaces réservés. Une diapositive normale utilise une diapositive de mise en page, ainsi elle hérite à la fois de la mise en page et du maître.

### Une présentation peut‑t‑elle contenir plusieurs maîtres de diapositives ?

Oui. Une présentation peut contenir plusieurs maîtres de diapositives. Utilisez plusieurs maîtres lorsque différentes sections nécessitent des systèmes visuels ou une identité de marque différents.

### Dois‑je ajouter des espaces réservés à un maître de diapositive ou à une diapositive de mise en page ?

Dans la plupart des cas, ajoutez les espaces réservés aux diapositives de mise en page. Placez les éléments visuels partagés et le formatage commun sur le maître de diapositive, puis mettez les espaces réservés de contenu sur les mises en page que les diapositives normales utiliseront.

### Puis‑je supprimer un maître de diapositive qui est encore utilisé ?

Non. Un maître de diapositive qui possède des diapositives dépendantes ne peut pas être supprimé en toute sécurité directement. Déplacez d’abord ces diapositives vers des mises en page sous un autre maître, ou utilisez une méthode de nettoyage des maîtres inutilisés qui ne supprime que les maîtres qui ne sont pas utilisés.