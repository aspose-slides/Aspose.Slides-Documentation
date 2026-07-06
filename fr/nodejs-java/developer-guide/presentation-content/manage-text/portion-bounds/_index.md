---
title: Obtenir les limites de la portion de texte dans les présentations en JavaScript
linktitle: Limites de la portion
type: docs
weight: 47
url: /fr/nodejs-java/portion-bounds/
keywords:
- limites de portion de texte
- portion de texte
- partie de texte
- coordonnées de texte
- position de texte
- PowerPoint
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Apprenez à récupérer les limites des portions de texte dans les présentations PowerPoint à l'aide d'Aspose.Slides pour Node.js via Java."
---
## **Vue d'ensemble**

Une portion de texte représente un fragment spécifique de texte à l'intérieur d'un paragraphe et vous permet de travailler avec ce fragment indépendamment du contenu environnant. Dans Aspose.Slides, les portions peuvent être utilisées lorsque vous devez récupérer les limites d'un fragment de texte, appliquer une mise en forme à seulement une partie d'un paragraphe ou contrôler le comportement du texte à un niveau plus détaillé.

Cet article montre comment obtenir le rectangle englobant d'une portion en utilisant [Portion.getRect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portion/getrect/). Il montre également comment obtenir les coordonnées du début d'une portion en utilisant [Portion.getCoordinates](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portion/getcoordinates/). De plus, il met en évidence des scénarios courants liés aux portions, tels que l'application d'un hyperlien à un fragment de texte unique, la compréhension de la résolution du formatage à travers la portion, le paragraphe, le cadre de texte et l'héritage du thème, ainsi que la gestion des cas où une police spécifiée est indisponible.

## **Obtenir les limites d'une portion de texte**

Utilisez [Portion.getRect](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portion/getrect/) pour récupérer le rectangle englobant d'une portion de texte :

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const rectangle = portion.getRect();
            console.log("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Obtenir les coordonnées d'une portion de texte**

Utilisez [Portion.getCoordinates](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portion/getcoordinates/) pour récupérer les coordonnées du début d'une portion de texte :

```javascript
const presentation = new aspose.slides.Presentation("Shapes.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().get_Item(0);
    const paragraphs = shape.getTextFrame().getParagraphs();

    for (let paragraphIndex = 0; paragraphIndex < paragraphs.getCount(); paragraphIndex++) {
        const paragraph = paragraphs.get_Item(paragraphIndex);
        const portions = paragraph.getPortions();

        for (let portionIndex = 0; portionIndex < portions.getCount(); portionIndex++) {
            const portion = portions.get_Item(portionIndex);
            const point = portion.getCoordinates();
            console.log("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Puis-je appliquer un hyperlien à seulement une partie du texte d'un même paragraphe ?**

Oui, vous pouvez [assigner un hyperlien](/slides/fr/nodejs-java/manage-hyperlinks/) à une portion individuelle ; seul ce fragment sera cliquable, pas le paragraphe entier.

**Comment fonctionne l'héritage de style : qu'est-ce qu'une portion surcharge, et qu'est‑ce qui est repris d'un paragraphe ou d'un cadre de texte ?**

Les propriétés au niveau de la Portion ont la priorité la plus élevée. Si une propriété n'est pas définie sur la [Portion](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portion/), Aspose.Slides la récupère depuis le [Paragraph](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraph/). Si elle n'est pas non plus définie là, Aspose.Slides utilise le style du [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/) ou du [theme](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/theme/).

**Que se passe-t-il si la police spécifiée pour une portion est absente sur la machine ou le serveur cible ?**

[Les règles de substitution de police](/slides/fr/nodejs-java/font-selection-sequence/) s'appliquent. Le texte peut se réorganiser : les métriques, la césure et la largeur peuvent changer, ce qui importe pour un positionnement précis.

**Puis-je définir la transparence ou un dégradé de remplissage du texte propre à une portion indépendamment du reste du paragraphe ?**

Oui, la couleur du texte, le remplissage et la transparence au niveau de la [Portion](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portion/) peuvent différer des fragments voisins.