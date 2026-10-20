---
title: Redimensionner les formes sur les diapositives d'une présentation en Node.js
type: docs
weight: 130
url: /fr/nodejs-java/resizing-shapes-on-slide/
aliases:
  /nodejs-java/redimensionnement-formes-sur-diapositive/
keywords:
  - redimensionner forme
  - modifier taille forme
  - PowerPoint
  - OpenDocument
  - présentation
  - Node.js
  - JavaScript
  - Aspose.Slides
description: "Redimensionnez facilement les formes sur les diapositives PowerPoint et OpenDocument avec Aspose.Slides pour Node.js via Java — automatisez les ajustements de mise en page des diapositives et augmentez la productivité."
---
## **Aperçu**

Lorsque vous modifiez la taille des diapositives d'une présentation, il peut également être nécessaire de redimensionner et de repositionner ses formes pour qu'elles s'ajustent aux nouvelles dimensions. Cet article montre comment mettre à l'échelle les formes manuellement et comment gérer les tableaux sur les diapositives, les maîtres et les dispositions.

## **Redimensionner les formes**

Pour préserver la position et la taille relatives de chaque forme, multipliez ses coordonnées horizontales et sa largeur par le rapport entre la nouvelle largeur de la diapositive et la largeur originale. Appliquez le rapport de hauteur correspondant à ses coordonnées verticales et à sa hauteur.

Le premier exemple charge une présentation dont les diapositives ne contiennent aucun tableau, modifie la taille de la diapositive en A4 et enregistre le résultat. Il utilise [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) avec [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/#DoNotScale) afin que la boucle suivante contrôle le redimensionnement. Les rapports sont sans unité; les positions et dimensions des formes sont mesurées en points. Des ratios de largeur et de hauteur différents peuvent déformer les formes, et modifier les dimensions d'une forme ne met pas à l'échelle les tailles de police.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("sample.pptx");
try {
    // Calculer les facteurs d'échelle horizontaux et verticaux indépendants.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
            shape.setX(java.newFloat(shape.getX() * widthRatio));
            shape.setY(java.newFloat(shape.getY() * heightRatio));
        }
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Les tableaux nécessitent un traitement séparé : redimensionnez leurs largeurs de colonne et hauteurs de ligne au lieu d'attribuer la largeur et la hauteur globales du tableau. Les hauteurs de ligne peuvent rester supérieures à la valeur demandée si le contenu des cellules nécessite plus d'espace.
{{% /alert %}}

Le deuxième exemple prend en charge les tableaux et traite les formes sur les maîtres et les dispositions ainsi que les diapositives individuelles avant d'enregistrer la présentation redimensionnée. Son assistant gère chaque [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) en redimensionnant les largeurs de colonne avec [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth) et les hauteurs de ligne minimales avec [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight). Il redimensionne ensuite la position du tableau sans redimensionner séparément ses dimensions globales.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function resizeShapes(shapes, widthRatio, heightRatio) {
    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        const shape = shapes.get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            const table = shape;
            // Les dimensions du tableau sont contrôlées par les largeurs des colonnes et les hauteurs des lignes.
            for (let columnIndex = 0; columnIndex < table.getColumns().size(); columnIndex++) {
                const column = table.getColumns().get_Item(columnIndex);
                column.setWidth(column.getWidth() * widthRatio);
            }

            for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
                const row = table.getRows().get_Item(rowIndex);
                row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
            }
        }
        else {
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
        }

        shape.setX(java.newFloat(shape.getX() * widthRatio));
        shape.setY(java.newFloat(shape.getY() * heightRatio));
    }
}

const presentation = new slides.Presentation("sample.pptx");
try {
    // Calculer les facteurs d'échelle horizontaux et verticaux indépendants.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    // Redimensionner les formes définies sur les maîtres et les mises en page ainsi que sur les diapositives individuelles.
    for (let masterIndex = 0; masterIndex < presentation.getMasters().size(); masterIndex++) {
        const master = presentation.getMasters().get_Item(masterIndex);
        resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (let layoutSlideIndex = 0; layoutSlideIndex < master.getLayoutSlides().size(); layoutSlideIndex++) {
            const layoutSlide = master.getLayoutSlides().get_Item(layoutSlideIndex);
            resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **FAQ**

**Pourquoi les formes sont‑elles déformées ou coupées après le redimensionnement d'une diapositive ?**

Si vous modifiez la taille de la diapositive sans mettre à l'échelle les formes, elles conservent leurs positions et dimensions d'origine et peuvent dépasser la diapositive. Mettre à l'échelle la largeur et la hauteur avec des ratios différents peut également déformer les formes.

**Le code fourni fonctionne‑t‑il pour tous les types de formes ?**

Le premier exemple modifie directement les limites des formes et est destiné aux diapositives sans tableaux. Le deuxième exemple gère les tableaux séparément. Vérifiez la mise en page résultante, en particulier le texte et les tableaux, car ces exemples ne mettent pas à l'échelle les tailles de police et le contenu des tableaux peut contraindre les hauteurs de ligne.

**Comment redimensionner les tableaux lors du redimensionnement d'une diapositive ?**

Redimensionnez les largeurs de colonne selon le ratio de largeur et les hauteurs de ligne minimales selon le ratio de hauteur, puis redimensionnez la position du tableau, comme indiqué dans le deuxième exemple.

**Ce redimensionnement fonctionnera‑t‑il pour les diapositives maîtres et les diapositives de disposition ?**

Oui. Le deuxième exemple parcourt [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) et les [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getLayoutSlides) de chaque maître et applique la même logique de redimensionnement à leurs formes.

**Puis‑je modifier l'orientation d'une diapositive (portrait/paysage) en même temps que le redimensionnement ?**

Oui. Appelez [SlideSize.setOrientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setOrientation) après avoir modifié la taille de la diapositive et avant de lire les dimensions cibles, afin que les facteurs d'échelle reflètent l'orientation finale.

**Y a‑t‑il une limite à la taille de diapositive que je peux définir ?**

Vous pouvez spécifier des dimensions de diapositive personnalisées avec [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize). Les dimensions prises en charge dépendent également du format de la présentation et de l'application utilisée pour ouvrir le fichier.

**Comment empêcher les formes à ratio d'aspect fixe de se déformer ?**

Utilisez le même facteur d'échelle pour la largeur et la hauteur. Pour adapter la mise en page originale aux nouvelles dimensions de la diapositive, utilisez le plus petit des ratios de largeur et de hauteur pour les deux dimensions et les positions. Cela préserve les proportions mais peut laisser un espace inutilisé le long d'un bord.