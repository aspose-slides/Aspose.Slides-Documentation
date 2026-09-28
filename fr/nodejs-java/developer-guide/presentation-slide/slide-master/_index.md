---
title: Gérer les maîtres de diapositives de présentation en JavaScript
linktitle: Maître de diapositive
type: docs
weight: 70
url: /fr/nodejs-java/slide-master/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Gérer les maîtres de diapositives dans Aspose.Slides pour Node.js via Java : accéder, modifier, cloner, comparer et supprimer les diapositives maîtres dans les présentations PowerPoint et OpenDocument."
---
## **Vue d'ensemble**

Un **slide master** définit des paramètres de conception partagés pour un groupe de diapositives. Il peut contenir des formes communes, des logos, des arrière‑plans, des styles de texte, des paramètres de thème et des paramètres de pied de page. Dans PowerPoint, modifier un slide master est la façon habituelle de conserver une présentation cohérente sans répéter le même formatage sur chaque diapositive.

Aspose.Slides for Node.js via Java prend en charge le même modèle. Une présentation peut contenir un ou plusieurs slide masters, et chaque slide master peut contenir plusieurs layout slides. Les diapositives normales ne référencent généralement pas directement un slide master. À la place, une diapositive normale utilise un layout slide, et ce layout slide appartient à un slide master.

La hiérarchie est :

1. **Slide master** – définit la conception et le thème partagés.  
1. **Layout slide** – définit une disposition spécifique des espaces réservés et du formatage au niveau de la disposition.  
1. **Normal slide** – contient le contenu réel de la présentation et utilise une disposition.

![Hiérarchie des slide masters, layout slides et slides normales](slide-master_2.jpg)

Dans Aspose.Slides, un slide master est représenté par la classe [MasterSlide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masterslide/). Tous les slide masters d’une présentation sont disponibles via la collection `Presentation.getMasters()`.

{{% alert color="info" title="Inheritance" %}}
Lorsque la même propriété est définie à plusieurs niveaux, le niveau le plus spécifique l’emporte. Par exemple, si un slide master et un layout slide définissent tous deux un arrière‑plan, les diapositives basées sur cette disposition utilisent l’arrière‑plan de la disposition. Pour plus d'informations sur les layout slides, voir [Appliquer ou modifier les dispositions des diapositives](/nodejs-java/slide-layout/).
{{% /alert %}}

## **Accéder aux slide masters**

Dans PowerPoint, vous pouvez ouvrir la vue Slide Master depuis **Affichage** > **Slide Master**.

![Commande Slide Master dans l’onglet Affichage de PowerPoint](slide-master_3.jpg)

Dans Aspose.Slides, utilisez la collection `getMasters()` pour accéder aux slide masters :

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

Vous pouvez également obtenir le slide master utilisé par une diapositive normale via son layout :

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

## **Ce que contient un slide master**

Un slide master est un objet de type diapositive. Il hérite du comportement commun des diapositives à partir de [BaseSlide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseslide/), ce qui lui donne accès à de nombreuses propriétés de diapositive utilisées par les diapositives normales et les layout slides. Les membres spécifiques au master sont répertoriés sur la page API [MasterSlide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masterslide/).

Les membres les plus couramment utilisés sont :

| Membre | Objectif |
| --- | --- |
| `getBackground()` | Définit l’arrière‑plan au niveau du master. |
| `getShapes()` | Contient les formes placées sur le master, telles que les logos, les cadres d’image et le texte partagé. |
| `getLayoutSlides()` | Contient les layout slides qui appartiennent au master. |
| `getThemeManager()` | Fournit l’accès aux API du thème du master. |
| `getHeaderFooterManager()` | Contrôle les en‑têtes, pieds de page, dates et numéros de diapositive pour le master et ses layouts enfants. |
| `getDependingSlides()` | Renvoie les diapositives normales dépendantes du master via leurs layouts. |

## **Ajouter une image à un slide master**

Lorsque vous ajoutez une image à un slide master, elle apparaît sur les diapositives qui utilisent les layouts de ce master. C’est pratique pour les logos, filigranes, bandes décoratives et autres éléments visuels répétés.

L’exemple suivant ajoute un logo au premier slide master :

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

Pour plus d'informations sur les cadres d’image, voir [Picture Frame](/nodejs-java/picture-frame/).

## **Contrôler la visibilité des graphiques du master**

Utilisez [BaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseslide/#setShowMasterShapes) pour masquer les graphiques hérités du master, tels que les logos ou formes décoratives, sans les supprimer du master. Passez `false` à [Slide.setShowMasterShapes](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slide/#setShowMasterShapes) sur la diapositive qui doit omettre ces graphiques et conservez-le à `true` sur les diapositives qui doivent les afficher.

L’exemple autonome suivant crée une bande décorative bleue sur un master et deux diapositives qui utilisent le même layout vierge. La bande est visible sur la première diapositive et masquée sur la seconde. Aucun document d’entrée ni image n’est requis.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation();
try {
    let masterSlide = presentation.getMasters().get_Item(0);
    let blankLayoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
    let layoutSlide = masterSlide.getLayoutSlides().getByType(blankLayoutType);
    layoutSlide.setShowMasterShapes(true);

    let slideHeight = presentation.getSlideSize().getSize().getHeight();
    let band = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 0, 0, 60, slideHeight);
    let bandColor = java.newInstanceSync("java.awt.Color", 70, 130, 180);
    let solidFillType = java.newByte(aspose.slides.FillType.Solid);
    let noFillType = java.newByte(aspose.slides.FillType.NoFill);
    band.getFillFormat().setFillType(solidFillType);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(noFillType);

    let visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    let hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

L’exemple utilise le layout **Blank** fourni avec une nouvelle présentation et supprime les espaces réservés propres à la diapositive initiale.

### **Choisir la portée du paramètre**

Une diapositive normale utilise son master via [Slide.getLayoutSlide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slide/#getLayoutSlide) et [LayoutSlide.getMasterSlide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutslide/#getMasterSlide). Définir la propriété sur une diapositive individuelle n’affecte que celle‑ci. Passer `false` à [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/layoutslide/#setShowMasterShapes) masque les graphiques du master pour toutes les diapositives qui utilisent ce layout partagé, même si leur propre paramètre est `true`. Pour masquer les graphiques sur une seule diapositive, modifiez la propriété de la diapositive et laissez le layout partagé tel quel.

Le paramètre n’est pas pris en charge comme contrôle de visibilité sur le slide master lui‑même. Sur un master, [getShowMasterShapes](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masterslide/#getShowMasterShapes) renvoie toujours `false`, et passer `true` à [setShowMasterShapes](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/masterslide/#setShowMasterShapes) déclenche une exception. Appliquez‑le à une diapositive normale ou à un layout à la place.

### **Distinguer les graphiques de l'arrière‑plan**

| Opération | Effet |
| --- | --- |
| Masquer les graphiques du master | Contrôle la visibilité des formes héritées du master sans les supprimer ni modifier les formes propres à la diapositive. |
| Modifier le remplissage de l’arrière‑plan de la diapositive | Change la couleur, le dégradé ou l’image d’arrière‑plan. Les graphiques du master sont des formes distinctes et peuvent rester visibles au‑dessus de cet arrière‑plan. Voir [Presentation Background](/slides/fr/nodejs-java/presentation-background/). |
| Supprimer une forme du master | Supprime la forme source partagée, de sorte qu’elle ne soit plus disponible pour aucune diapositive utilisant ce master. |

## **Travailler avec les espaces réservés**

Les espaces réservés sont généralement définis sur les layout slides. Le slide master fournit le style et le thème partagés que ces layouts héritent, tandis que chaque layout décide quels espaces réservés sont disponibles et où ils sont placés.

Dans PowerPoint, les commandes d’espace réservé sont disponibles dans la vue Slide Master.

![Commande Insérer un espace réservé dans la vue Slide Master de PowerPoint](slide-master_5.png)

Pour ajouter de nouveaux espaces réservés avec Aspose.Slides, travaillez sur le layout slide qui appartient au master :

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

Vous pouvez également mettre en forme les formes d’espace réservé qui existent déjà sur un slide master. L’exemple suivant trouve l’espace réservé de titre et applique un remplissage en dégradé linéaire :

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

![Espace réservé de titre formaté hérité par les diapositives normales](slide-master_8.png)

Pour plus d’options de mise en forme des espaces réservés et du texte, voir [Définir le texte d’invite dans l’espace réservé](/nodejs-java/manage-placeholder/) et [Mise en forme du texte](/nodejs-java/text-formatting/).

## **Modifier l'arrière‑plan d'un slide master**

Un arrière‑plan de master est hérité par les layouts et les diapositives qui ne le remplacent pas. L’exemple suivant définit une couleur d’arrière‑plan unie pour le premier slide master :

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

Pour les sujets connexes, voir [Presentation Background](/nodejs-java/presentation-background/) et [Presentation Theme](/nodejs-java/presentation-theme/).

## **Cloner un slide master vers une autre présentation**

Utilisez `MasterSlideCollection.addClone` pour copier un slide master dans une autre présentation. Le master copié peut ensuite être utilisé par les layouts et les diapositives de la présentation de destination.

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

Si vous devez cloner des diapositives normales avec leur master, voir [Clone Slides](/nodejs-java/clone-slides/).

## **Ajouter plusieurs slide masters**

Une présentation peut contenir plusieurs slide masters. Cela est utile lorsque différentes sections nécessitent des identités visuelles, structures de page ou paramètres de thème différents.

![Commandes PowerPoint pour insérer et gérer les slide masters](slide-master_9.jpg)

L’exemple suivant clone le master par défaut, donne au clone un arrière‑plan différent, crée un layout sous ce master clone, puis ajoute une nouvelle diapositive basée sur ce layout :

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

## **Comparer les slide masters**

Les slide masters peuvent être comparés avec la méthode `equals` héritée de [BaseSlide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseslide/). La comparaison vérifie la structure et le contenu statique, tels que les formes, le texte, le formatage, les animations et les autres paramètres de diapositive. Elle ne compare pas les identifiants uniques, comme les IDs de diapositive, ni les valeurs dynamiques des espaces réservés, comme la date actuelle.

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

## **Définir la vue Slide Master comme vue par défaut**

Utilisez la méthode `setLastView` sur [ViewProperties](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/viewproperties/) pour contrôler la vue que PowerPoint ouvre en premier. L’exemple suivant ouvre la présentation en vue Slide Master :

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

Pour d’autres paramètres de vue, voir [Save Presentation](/slides/fr/nodejs-java/save-presentation/).

## **Supprimer les slide masters inutilisés**

Les présentations contiennent parfois des slide masters qui ne sont plus utilisés par aucune diapositive normale. Supprimer les masters inutilisés peut réduire la taille du fichier et simplifier la maintenance des modèles.

Utilisez `removeUnused` pour retirer les masters inutilisés de la collection `getMasters()` :

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

Vous pouvez également utiliser la méthode low‑code `Compress.removeUnusedMasterSlides` :

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

**Quelle est la différence entre un slide master et un layout slide ?**

Un slide master définit des paramètres de conception partagés tels que le thème, l’arrière‑plan, les formes communes et les styles de texte. Un layout slide appartient à un slide master et définit une disposition spécifique des espaces réservés. Une diapositive normale utilise un layout slide, héritant ainsi du layout et du master.

**Une présentation peut‑elle contenir plusieurs slide masters ?**

Oui. Une présentation peut contenir plusieurs slide masters. Utilisez plusieurs masters lorsque différentes sections exigent des systèmes visuels ou une identité de marque différents.

**Dois‑je ajouter des espaces réservés à un slide master ou à un layout slide ?**

Dans la plupart des cas, ajoutez les espaces réservés aux layout slides. Placez les éléments visuels partagés et le formatage commun sur le slide master, puis ajoutez les espaces réservés de contenu sur les layouts que les diapositives normales utiliseront.

**Puis‑je supprimer un slide master qui est encore utilisé ?**

Non. Un slide master qui possède des diapositives dépendantes ne peut pas être supprimé directement. Déplacez d’abord ces diapositives vers des layouts sous un autre master, ou utilisez une méthode de nettoyage des masters inutilisés qui ne supprime que les masters qui ne sont pas employés.