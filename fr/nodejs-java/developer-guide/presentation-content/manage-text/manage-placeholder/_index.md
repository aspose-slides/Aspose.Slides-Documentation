---
title: Gérer les espaces réservés de présentation en JavaScript
linktitle: Gérer les espaces réservés
type: docs
weight: 10
url: /fr/nodejs-java/manage-placeholder/
keywords:
- espace réservé
- espace réservé de texte
- espace réservé d'image
- espace réservé de graphique
- espace réservé de contenu
- texte d'invite
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez à inspecter et modifier les espaces réservés de texte, d'image, de graphique et de contenu et à comprendre l'héritage des espaces réservés avec Aspose.Slides pour Node.js via Java."
---
## **Vue d'ensemble**

Un espace réservé est une forme qui réserve une position pour un type de contenu particulier dans un modèle de présentation. Les exemples courants sont les espaces réservés de titre, de corps, d'image, de graphique et les espaces réservés de contenu polyvalents. Contrairement à une forme ordinaire, un espace réservé peut hériter de sa position, de sa taille, de son formatage et d'autres paramètres d'une diapositive de mise en page ou d'une diapositive maître.

Aspose.Slides expose les informations d'espace réservé via la méthode [Shape.getPlaceholder](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/#getPlaceholder). La méthode renvoie un objet [Placeholder](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/placeholder/) ou `null` pour une forme normale. Utilisez [Placeholder.getType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/placeholder/#getType) pour déterminer ce que l'espace réservé est censé contenir.

La classe de forme reste importante après avoir identifié le type d'espace réservé :

- Un espace réservé vide de texte, d'image, de graphique ou de contenu est généralement représenté par un [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/).
- Un espace réservé d'image rempli peut être représenté par un [PictureFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pictureframe/).
- Un espace réservé de graphique rempli peut être représenté par un [Chart](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chart/).
- Un espace réservé de contenu peut contenir plusieurs types de contenu. Vérifiez à la fois [Placeholder.getType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/placeholder/#getType) et la classe de forme d'exécution au lieu de supposer que chaque espace réservé est un [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/).

{{% alert color="warning" title="Warning" %}}
[Placeholder.getType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/placeholder/#getType) décrit le rôle d'un espace réservé ; il ne garantit pas le type d'exécution de la forme. Utilisez toujours une vérification de type avant d'accéder aux membres spécifiques au texte, à l'image, au graphique, au tableau ou aux médias.
{{% /alert %}}

## **Comprendre l'héritage des espaces réservés**

Les espaces réservés forment une hiérarchie :

1. Une diapositive maître définit des styles réutilisables et, dans certains cas, des espaces réservés au niveau du maître.
2. Une diapositive de mise en page définit la disposition utilisée par une ou plusieurs diapositives normales et peut hériter du maître.
3. Une diapositive normale contient les espaces réservés pour cette diapositive et peut hériter de sa mise en page.

Appelez [Shape.getBasePlaceholder](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/#getBasePlaceholder) pour remonter d'un niveau dans cette hiérarchie. Un espace réservé de diapositive renvoie généralement son espace réservé de mise en page ; un espace réservé de mise en page peut renvoyer son espace réservé maître. La méthode renvoie `null` lorsque la forme n'a pas d'espace réservé de base.

L'exemple suivant répertorie les espaces réservés sur la première diapositive et indique leurs espaces réservés de base :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function getShapeClassName(shape) {
    if (java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
        return "AutoShape";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
        return "PictureFrame";
    }

    if (java.instanceOf(shape, "com.aspose.slides.IChart")) {
        return "Chart";
    }

    return "Shape";
}

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const shapeClassName = getShapeClassName(shape);
        const slidePlaceholderMessage = "Slide placeholder: " + placeholderType + "; shape class: " + shapeClassName;
        console.log(slidePlaceholderMessage);

        const layoutPlaceholder = shape.getBasePlaceholder();
        if (layoutPlaceholder != null) {
            const layoutPlaceholderInfo = layoutPlaceholder.getPlaceholder();
            const layoutPlaceholderType = layoutPlaceholderInfo == null ? null : layoutPlaceholderInfo.getType();
            const layoutPlaceholderMessage = "  Layout placeholder: " + layoutPlaceholderType;
            console.log(layoutPlaceholderMessage);

            const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            if (masterPlaceholder != null) {
                const masterPlaceholderInfo = masterPlaceholder.getPlaceholder();
                const masterPlaceholderType = masterPlaceholderInfo == null ? null : masterPlaceholderInfo.getType();
                const masterPlaceholderMessage = "  Master placeholder: " + masterPlaceholderType;
                console.log(masterPlaceholderMessage);
            }
        }
    }
} finally {
    presentation.dispose();
}
```

Modifier un espace réservé sur une diapositive normale crée ou modifie une substitution locale pour cette diapositive. Modifier la mise en page ou le maître associé peut affecter toutes les diapositives qui héritent encore de ce paramètre. Une forme locale ordinaire n'a pas d'espace réservé de base et ne commence pas à hériter simplement parce qu'elle occupe les mêmes coordonnées.

## **Modifier le texte d'un espace réservé**

Les espaces réservés de titre, de titre centré, de sous-titre, de corps et de texte prennent généralement en charge le texte. Vérifiez la présence d'un [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) avant d'utiliser sa méthode [getTextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/#getTextFrame).

Cet exemple met à jour le premier espace réservé de titre sur la première diapositive et enregistre le résultat :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let titleShape = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            titleShape = shape;
            break;
        }
    }

    if (titleShape == null) {
        throw new Error("The first slide does not contain a title placeholder.");
    }

    titleShape.getTextFrame().setText("Quarterly Business Review");
    presentation.save("title-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ce modèle évite de traiter les espaces réservés d'image, de graphique, de tableau ou de médias comme des objets [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/). Il identifie également l'espace réservé par son objectif au lieu de se fier à un indice de forme fragile.

## **Définir le texte d'invite sur une mise en page**

Le texte d'invite est l'instruction affichée en temps de conception dans un espace réservé vide, par exemple *Cliquer pour ajouter un titre*. Définissez un texte d'invite personnalisé sur l'espace réservé de mise en page plutôt que d'essayer d'y accéder via la collection de formes d'une diapositive normale. Accédez à la mise en page via [Slide.getLayoutSlide](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/slide/#getLayoutSlide) et parcourez la collection renvoyée par [BaseSlide.getShapes](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseslide/#getShapes).

L'exemple suivant modifie les invites de titre et de sous-titre sur la mise en page utilisée par la première diapositive :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const firstSlide = slides.get_Item(0);
    const layoutSlide = firstSlide.getLayoutSlide();
    const shapes = layoutSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();

        if (placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle) {
            shape.getTextFrame().setText("Enter a concise slide title");
        } else if (placeholderType === aspose.slides.PlaceholderType.Subtitle) {
            shape.getTextFrame().setText("Enter a subtitle or reporting period");
        }
    }

    presentation.save("custom-placeholder-prompts.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le texte d'invite n'est pas un contenu de diapositive normal. Il est destiné aux espaces réservés vides dans des applications d'édition comme PowerPoint. Une fois qu'un utilisateur ou un programme fournit du contenu réel, l'invite n'est plus affichée. Modifier une invite ne remplace pas non plus le texte existant sur les diapositives qui utilisent la mise en page.

## **Mettre à jour un espace réservé d'image**

Il y a deux cas à gérer :

- Si l'espace réservé d'image est déjà rempli et représenté par un [PictureFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pictureframe/), remplacez l'image via [PictureFrame.getPictureFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pictureframe/#getPictureFormat), [PictureFillFormat.getPicture](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/picturefillformat/#getPicture) et [Picture.setImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/picture/#setImage).
- Si c'est encore un espace réservé vide, ajoutez un cadre d'image aux coordonnées de l'espace réservé avec [ShapeCollection.addPictureFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shapecollection/#addPictureFrame) et supprimez l'espace réservé vide.

L'exemple suivant prend en charge les deux cas et enregistre la présentation :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("picture-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let picturePlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Picture) {
            picturePlaceholder = shape;
            break;
        }
    }

    if (picturePlaceholder == null) {
        throw new Error("The first slide does not contain a picture placeholder.");
    }

    const sourceImage = aspose.slides.Images.fromFile("replacement.png");
    try {
        const image = presentation.getImages().addImage(sourceImage);

        if (java.instanceOf(picturePlaceholder, "com.aspose.slides.IPictureFrame")) {
            picturePlaceholder.getPictureFormat().getPicture().setImage(image);
        } else {
            const x = picturePlaceholder.getX();
            const y = picturePlaceholder.getY();
            const width = picturePlaceholder.getWidth();
            const height = picturePlaceholder.getHeight();
            const frameX = java.newFloat(x);
            const frameY = java.newFloat(y);
            const frameWidth = java.newFloat(width);
            const frameHeight = java.newFloat(height);
            shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
            shapes.remove(picturePlaceholder);
        }
    } finally {
        sourceImage.dispose();
    }

    presentation.save("picture-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le remplacement créé pour un espace réservé vide est un cadre d'image local, pas un nouvel espace réservé, parce que [Shape.getPlaceholder](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/#getPlaceholder) ne fournit pas de mutateur. Il conserve la position réservée mais n'hérite plus du comportement propre aux espaces réservés. Si la conservation de la relation d'espace réservé est essentielle, préparez et remplissez d'abord l'espace réservé dans PowerPoint, puis mettez à jour le [PictureFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/pictureframe/) résultant avec Aspose.Slides.

Pour la transparence d'image, le recadrage et d'autres effets spécifiques aux images, voir [Manage Picture Frames](/slides/fr/nodejs-java/picture-frame/). Ces opérations appartiennent au cadre d'image ou au remplissage d'image, pas aux métadonnées de l'espace réservé.

## **Travailler avec les espaces réservés de graphique et de contenu**

Un espace réservé de graphique rempli peut être représenté par un [Chart](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chart/). Cet exemple trouve un tel graphique à la fois par type d'espace réservé et par classe d'exécution, modifie son titre et enregistre le fichier :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("chart-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let placeholderChart = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        if (!java.instanceOf(shape, "com.aspose.slides.IChart")) {
            continue;
        }

        const placeholder = shape.getPlaceholder();
        if (placeholder != null && placeholder.getType() === aspose.slides.PlaceholderType.Chart) {
            placeholderChart = shape;
            break;
        }
    }

    if (placeholderChart == null) {
        throw new Error("The first slide does not contain a populated chart placeholder.");
    }

    placeholderChart.setTitle(true);
    placeholderChart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    presentation.save("chart-placeholder-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Un espace réservé de contenu général possède généralement [PlaceholderType.Object](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/placeholdertype/#Object). Dans PowerPoint, il agit comme un lanceur pour plusieurs types de contenu, notamment les graphiques, les tableaux, les diagrammes, les images et les médias. Après qu'il a été rempli, inspectez la classe de forme réelle pour savoir ce qu'il contient. Des mises en page spécialisées peuvent également exposer [PlaceholderType.Chart](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/placeholdertype/#Chart), [PlaceholderType.Table](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/placeholdertype/#Table), [PlaceholderType.Picture](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/placeholdertype/#Picture), [PlaceholderType.Media](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/placeholdertype/#Media) ou [PlaceholderType.Diagram](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/placeholdertype/#Diagram).

Aspose.Slides ne convertit pas un espace réservé [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) vide en un [Chart](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/chart/) simplement en modifiant [Placeholder.getType](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/placeholder/#getType) ; le type ne peut pas être changé via l'objet. Pour remplir programmétiquement un graphique ou une zone de contenu vide, ajoutez l'objet requis aux coordonnées de l'espace réservé puis supprimez l'espace réservé vide. L'exemple suivant le fait pour un graphique :

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("content-template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let targetPlaceholder = null;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        if (placeholderType === aspose.slides.PlaceholderType.Chart || placeholderType === aspose.slides.PlaceholderType.Object) {
            targetPlaceholder = shape;
            break;
        }
    }

    if (targetPlaceholder == null) {
        throw new Error("The first slide does not contain a chart or content placeholder.");
    }

    const x = targetPlaceholder.getX();
    const y = targetPlaceholder.getY();
    const width = targetPlaceholder.getWidth();
    const height = targetPlaceholder.getHeight();
    const chartX = java.newFloat(x);
    const chartY = java.newFloat(y);
    const chartWidth = java.newFloat(width);
    const chartHeight = java.newFloat(height);
    const chart = shapes.addChart(aspose.slides.ChartType.ClusteredColumn, chartX, chartY, chartWidth, chartHeight);
    chart.setTitle(true);
    chart.getChartTitle().addTextFrameForOverriding("Quarterly Revenue");
    shapes.remove(targetPlaceholder);
    presentation.save("content-placeholder-replaced-with-chart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Le graphique ajouté est un graphique local ordinaire. Il occupe la zone de l'espace réservé mais n'hérite pas de l'espace réservé de mise en page. Utilisez les [articles de gestion des graphiques](/slides/fr/nodejs-java/powerpoint-charts/) lorsque vous devez remplacer ses catégories, séries ou données de classeur.

## **Exemple complet : mettre à jour le texte ou le contenu image**

L'exemple suivant, de bout en bout, ouvre un modèle, recherche la première diapositive pour un espace réservé de titre ou d'image, vérifie les types d'espace réservé et de forme, met à jour le contenu approprié et enregistre la sortie. L'exemple évite délibérément de supposer un indice de forme ou de traiter chaque espace réservé comme la même classe.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation("template.pptx");
try {
    const slides = presentation.getSlides();
    const slide = slides.get_Item(0);
    const shapes = slide.getShapes();
    let updated = false;

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const placeholder = shape.getPlaceholder();
        if (placeholder == null) {
            continue;
        }

        const placeholderType = placeholder.getType();
        const isTitlePlaceholder = placeholderType === aspose.slides.PlaceholderType.Title || placeholderType === aspose.slides.PlaceholderType.CenteredTitle;

        if (isTitlePlaceholder && java.instanceOf(shape, "com.aspose.slides.IAutoShape")) {
            shape.getTextFrame().setText("Quarterly Business Review");
            updated = true;
            break;
        }

        if (placeholderType === aspose.slides.PlaceholderType.Picture) {
            const sourceImage = aspose.slides.Images.fromFile("replacement.png");
            try {
                const image = presentation.getImages().addImage(sourceImage);

                if (java.instanceOf(shape, "com.aspose.slides.IPictureFrame")) {
                    shape.getPictureFormat().getPicture().setImage(image);
                } else {
                    const x = shape.getX();
                    const y = shape.getY();
                    const width = shape.getWidth();
                    const height = shape.getHeight();
                    const frameX = java.newFloat(x);
                    const frameY = java.newFloat(y);
                    const frameWidth = java.newFloat(width);
                    const frameHeight = java.newFloat(height);
                    shapes.addPictureFrame(aspose.slides.ShapeType.Rectangle, frameX, frameY, frameWidth, frameHeight, image);
                    shapes.remove(shape);
                }
            } finally {
                sourceImage.dispose();
            }

            updated = true;
            break;
        }
    }

    if (!updated) {
        throw new Error("No supported title or picture placeholder was found on the first slide.");
    }

    presentation.save("placeholder-content-updated.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Qu'est‑ce qu'un espace réservé de base ?**

Un espace réservé de base est la forme correspondante sur la mise en page ou le maître dont hérite un autre espace réservé. Utilisez [Shape.getBasePlaceholder](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/#getBasePlaceholder) pour le récupérer. Une forme locale ordinaire renvoie `null` car elle ne fait pas partie de la hiérarchie des espaces réservés.

**Puis‑je modifier tous les titres de diapositives en modifiant un espace réservé de mise en page ?**

Vous pouvez modifier le formatage ou le texte d'invite hérité via une mise en page, mais le contenu réel du titre est stocké sur les diapositives normales. Pour remplacer le texte du titre dans toute la présentation, parcourez les diapositives et mettez à jour chaque espace réservé de titre.

**Comment gérer les espaces réservés de date, de numéro de diapositive, d'en-tête et de pied de page ?**

Utilisez les gestionnaires d'en-tête et de pied de page au niveau de la diapositive, de la mise en page, du maître, des notes ou du document de distribution. Consultez [Manage Presentation Header and Footer](/slides/fr/nodejs-java/presentation-header-and-footer/) pour des exemples complets.