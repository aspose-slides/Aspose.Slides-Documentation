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
[**getCoordinates()**](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPortion#getCoordinates--) la méthode a été ajoutée aux classes [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IPortion) et [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/classes/Portion) qui permet de récupérer les coordonnées du début de la portion.
```java
// Instancier la classe Presentation qui représente le PPTX
Presentation pres = new Presentation();
try {
    // Reconfigurer le contexte de la présentation
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

**Puis-je appliquer un hyperlien uniquement à une partie du texte au sein d'un même paragraphe ?**

Oui, vous pouvez [attribuer un hyperlien](/slides/fr/androidjava/manage-hyperlinks/) à une portion individuelle ; seul ce fragment sera cliquable, pas tout le paragraphe.

**Comment fonctionne l'héritage de style : qu'est‑ce qu'une Portion remplace, et qu'est‑ce qui provient du Paragraph/TextFrame ?**

Les propriétés au niveau de la Portion ont la priorité la plus élevée. Si une propriété n’est pas définie sur la [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/), le moteur la récupère du [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/); si elle n’est pas non plus définie là, il la prend du [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) ou du style du [theme](https://reference.aspose.com/slides/androidjava/com.aspose.slides/theme/).

**Que se passe-t-il si la police spécifiée pour une Portion est absente sur la machine/serveur cible ?**

Les [règles de substitution des polices](/slides/fr/androidjava/font-selection-sequence/) s’appliquent. Le texte peut se reconstituer : les métriques, la césure et la largeur peuvent changer, ce qui influence le positionnement précis.

**Puis-je définir une transparence ou un dégradé de remplissage de texte propre à la Portion, indépendamment du reste du paragraphe ?**

Oui, la couleur du texte, le remplissage et la transparence au niveau de la [Portion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portion/) peuvent différer des fragments voisins.