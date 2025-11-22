---
title: Portion
type: docs
weight: 70
url: /fr/nodejs-java/portion/
---

## **Obtenir les coordonnées de position de la portion**
[**getCoordinates()**](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Portion#getCoordinates--) la méthode a été ajoutée à la classe [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) qui permet de récupérer les coordonnées du début de la portion.
```javascript
// Instancier la classe Prseetation qui représente le PPTX
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    // Remodeler le contexte de la présentation
    var shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);
    var textFrame = shape.getTextFrame();
    for (let i = 0; i < textFrame.getParagraphs().getCount(); i++) {
        const paragraph = textFrame.getParagraphs().get_Item(i);
        for (let j = 0; j < paragraph.getPortions().getCount(); j++) {
            const portion = paragraph.getPortions().get_Item(j);
            var point = portion.getCoordinates();
            console.log("X: " + point.x + " Y: " + point.y);
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Puis-je appliquer un hyperlien à une seule partie du texte d'un même paragraphe ?**

Oui, vous pouvez [attribuer un hyperlien](/slides/fr/nodejs-java/manage-hyperlinks/) à une portion individuelle ; seul ce fragment sera cliquable, pas le paragraphe entier.

**Comment fonctionne l'héritage des styles : qu'est‑ce qu'une Portion remplace, et qu'est‑ce qui est pris du Paragraph/TextFrame ?**

Les propriétés au niveau de la [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) ont la priorité la plus élevée. Si une propriété n'est pas définie sur la Portion, le moteur la récupère du [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) ; si elle n'est pas définie non plus là, du [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) ou du style du [theme](https://reference.aspose.com/slides/nodejs-java/aspose.slides/theme/).

**Que se passe-t-il si la police spécifiée pour une Portion est absente sur la machine/serveur cible ?**

Les [règles de substitution de police](/slides/fr/nodejs-java/font-selection-sequence/) s'appliquent. Le texte peut se reformater : les métriques, la césure et la largeur peuvent changer, ce qui est important pour un positionnement précis.

**Puis-je définir une transparence ou un dégradé de remplissage de texte spécifique à une Portion, indépendant du reste du paragraphe ?**

Oui, la couleur du texte, le remplissage et la transparence au niveau de la [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) peuvent différer des fragments voisins.