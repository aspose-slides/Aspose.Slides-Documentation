---
title: Obtenir les limites des portions de texte à partir de présentations sur Android
linktitle: Limites de la portion
type: docs
weight: 47
url: /fr/androidjava/portion-bounds/
keywords:
- limites de portion de texte
- portion de texte
- partie de texte
- coordonnées du texte
- position du texte
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez comment récupérer les limites des portions de texte dans les présentations PowerPoint à l'aide d'Aspose.Slides pour Android via Java."
---
## **Vue d'ensemble**

Une portion de texte représente un fragment spécifique de texte à l'intérieur d'un paragraphe et vous permet de travailler avec ce fragment indépendamment du contenu environnant. Dans Aspose.Slides, les portions peuvent être utilisées lorsque vous devez récupérer les limites d'un fragment de texte, appliquer une mise en forme à une partie seulement d'un paragraphe, ou contrôler le comportement du texte à un niveau plus détaillé.

Cet article montre comment obtenir le rectangle englobant d'une portion en utilisant [IPortion.getRect](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IPortion#getRect--). Il montre également comment obtenir les coordonnées du début d'une portion en utilisant [IPortion.getCoordinates](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IPortion#getCoordinates--). De plus, il met en évidence les scénarios courants liés aux portions, comme l'application d'un hyperlien à un fragment de texte unique, la compréhension de la résolution de la mise en forme à travers la portion, le paragraphe, le cadre de texte et l'héritage du thème, ainsi que la gestion des cas où une police spécifiée est indisponible.

## **Obtenir les limites d'une portion de texte**

Utilisez [IPortion.getRect](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IPortion#getRect--) pour récupérer le rectangle englobant d'une portion de texte :

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            android.graphics.RectF rectangle = portion.getRect();
            System.out.println("X = " + rectangle.left + "; Y = " + rectangle.top + "; Width = " + rectangle.width() + "; Height = " + rectangle.height());
        }
    }
} finally {
    presentation.dispose();
}
```

## **Obtenir les coordonnées d'une portion de texte**

Utilisez [IPortion.getCoordinates](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/IPortion#getCoordinates--) pour récupérer les coordonnées du début d'une portion de texte :

```java
Presentation presentation = new Presentation("Shapes.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = (IAutoShape) slide.getShapes().get_Item(0);

    for (IParagraph paragraph : shape.getTextFrame().getParagraphs())
    {
        for (IPortion portion : paragraph.getPortions())
        {
            PointF point = portion.getCoordinates();
            System.out.println("X = " + point.x + "; Y = " + point.y);
        }
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Puis-je appliquer un hyperlien uniquement à une partie du texte au sein d'un même paragraphe ?**

Oui, vous pouvez [assigner un hyperlien](/slides/fr/androidjava/manage-hyperlinks/) à une portion individuelle ; seul ce fragment sera cliquable, pas le paragraphe entier.

**Comment fonctionne l'héritage du style : qu'est‑ce qu'une portion surcharge, et qu'est‑ce qui est récupéré d'un paragraphe ou d'un cadre de texte ?**

Les propriétés au niveau de la portion ont la priorité la plus élevée. Si une propriété n'est pas définie sur l'[IPortion](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iportion/), Aspose.Slides la récupère depuis l'[IParagraph](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraph/). Si elle n'est pas définie non plus, Aspose.Slides utilise le style de l'[ITextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/) ou du [theme](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/theme/).

**Que se passe‑t‑il si la police spécifiée pour une portion est absente sur la machine ou le serveur cible ?**

Les [règles de substitution de police](/slides/fr/androidjava/font-selection-sequence/) s'appliquent. Le texte peut se reconstituer : les métriques, la césure et la largeur peuvent changer, ce qui est important pour un positionnement précis.

**Puis‑je définir la transparence ou un dégradé de remplissage du texte propre à la portion, indépendamment du reste du paragraphe ?**

Oui, la couleur du texte, le remplissage et la transparence au niveau de l'[IPortion](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iportion/) peuvent différer des fragments voisins.