---
title: Gérer les portions de texte dans les présentations sur Android
linktitle: Portion de texte
type: docs
weight: 70
url: /fr/androidjava/portion/
keywords:
- portion de texte
- partie de texte
- coordonnées du texte
- position du texte
- PowerPoint
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez à gérer les portions de texte dans les présentations PowerPoint à l'aide d'Aspose.Slides pour Android via Java, en améliorant les performances et la personnalisation."
---

## **Obtenir les coordonnées d'une portion de texte**
La méthode [**getCoordinates()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getCoordinates--) a été ajoutée aux classes [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) et [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) qui permet de récupérer les coordonnées du début de la portion.
```java
// Instancier la classe Presentation qui représente le PPTX
Presentation pres = new Presentation();
try {
    // Remodeler le contexte de la présentation
    IAutoShape shape = (IAutoShape) pres.getSlides().get_Item(0).getShapes().get_Item(0);
    
    ITextFrame textFrame = (ITextFrame) shape.getTextFrame();
    
    for (IParagraph paragraph : textFrame.getParagraphs()) 
    {
        for (IPortion portion : paragraph.getPortions()) 
        {
            Point2D.Float point = portion.getCoordinates();
            System.out.println("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Puis-je appliquer un hyperlien à seulement une partie du texte d'un même paragraphe ?**

Oui, vous pouvez [assigner un hyperlien](/slides/fr/androidjava/manage-hyperlinks/) à une portion individuelle; seul ce fragment sera cliquable, pas le paragraphe entier.

**Comment fonctionne l'héritage de style : qu'est-ce qu'une Portion surcharge, et qu'est-ce qui est récupéré du Paragraph/TextFrame ?**

Les propriétés au niveau de la Portion ont la priorité la plus élevée. Si une propriété n'est pas définie sur la [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/), le moteur la récupère depuis le [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/); si elle n'est pas définie non plus là, depuis le [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) ou le style du [theme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/theme/).

**Que se passe-t-il si la police spécifiée pour une Portion est absente sur la machine/serveur cible ?**

Les [règles de substitution de police](/slides/fr/androidjava/font-selection-sequence/) s'appliquent. Le texte peut se réagencer: les métriques, la césure et la largeur peuvent changer, ce qui importe pour un positionnement précis.

**Puis-je définir une transparence ou un dégradé de remplissage de texte propre à une Portion, indépendamment du reste du paragraphe ?**

Oui, la couleur, le remplissage et la transparence du texte au niveau de la [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) peuvent différer des fragments voisins.