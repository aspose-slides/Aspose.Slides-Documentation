---
title: Obtenir les limites des portions de texte dans les présentations en Java
linktitle: Limites de la portion
type: docs
weight: 47
url: /fr/java/portion-bounds/
keywords:
- limites de portions de texte
- portion de texte
- partie de texte
- coordonnées du texte
- position du texte
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Apprenez comment récupérer les limites des portions de texte dans les présentations PowerPoint à l'aide d'Aspose.Slides pour Java."
---
## **Vue d'ensemble**

Une portion de texte représente un fragment spécifique de texte à l'intérieur d'un paragraphe et vous permet de travailler avec ce fragment indépendamment du contenu environnant. Dans Aspose.Slides, les portions peuvent être utilisées lorsque vous devez récupérer les limites d'un fragment de texte, appliquer une mise en forme à seulement une partie d'un paragraphe ou contrôler le comportement du texte à un niveau plus détaillé.

Cet article montre comment obtenir le rectangle englobant d'une portion en utilisant [IPortion.getRect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IPortion#getRect--). Il montre également comment obtenir les coordonnées du début d'une portion en utilisant [IPortion.getCoordinates](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IPortion#getCoordinates--). De plus, il met en évidence des scénarios courants liés aux portions, tels que l'application d'un hyperlien à un fragment de texte unique, la compréhension du mode de résolution de la mise en forme à travers la portion, le paragraphe, le cadre de texte et l'héritage du thème, ainsi que la gestion des cas où une police spécifiée est indisponible.

## **Obtenir les limites d'une portion de texte**

Utilisez [IPortion.getRect](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IPortion#getRect--) pour récupérer le rectangle englobant d'une portion de texte :

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Rectangle2D.Float rectangle = portion.getRect();
            System.out.println("X = " + rectangle.x + "; Y = " + rectangle.y + "; Width = " + rectangle.width + "; Height = " + rectangle.height);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Obtenir les coordonnées d'une portion de texte**

Utilisez [IPortion.getCoordinates](https://reference.aspose.com/slides/fr/java/com.aspose.slides/IPortion#getCoordinates--) pour récupérer les coordonnées du début d'une portion de texte :

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            java.awt.geom.Point2D.Float point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Puis-je appliquer un hyperlien à seulement une partie du texte d'un seul paragraphe ?**

Oui, vous pouvez [attribuer un hyperlien](/slides/fr/java/manage-hyperlinks/) à une portion individuelle ; seul ce fragment sera cliquable, pas le paragraphe entier.

**Comment fonctionne l'héritage de style : qu'est‑ce qu'une portion surcharge, et qu'est‑ce qui est pris d'un paragraphe ou d'un cadre de texte ?**

Les propriétés au niveau de la portion ont la priorité la plus élevée. Si une propriété n'est pas définie sur l'[IPortion](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iportion/), Aspose.Slides la récupère depuis l'[IParagraph](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraph/). Si elle n'est pas définie non plus à ce niveau, Aspose.Slides utilise le style de l'[ITextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/) ou du [theme](https://reference.aspose.com/slides/fr/java/com.aspose.slides/theme/).

**Que se passe-t-il si la police spécifiée pour une portion est absente sur la machine ou le serveur cible ?**

Les [règles de substitution de police](/slides/fr/java/font-selection-sequence/) s'appliquent. Le texte peut se réorganiser : les métriques, la césure et la largeur peuvent changer, ce qui a de l'importance pour un positionnement précis.

**Puis-je définir la transparence ou un dégradé de remplissage du texte propre à une portion indépendamment du reste du paragraphe ?**

Oui, la couleur du texte, le remplissage et la transparence au niveau de l'[IPortion](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iportion/) peuvent différer des fragments voisins.