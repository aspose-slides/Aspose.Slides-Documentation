---
title: Gérer les polices dans les présentations avec JavaScript
linktitle: Gérer les polices
type: docs
weight: 10
url: /fr/nodejs-java/manage-fonts/
keywords:
- gérer les polices
- propriétés de police
- paragraphe
- formatage du texte
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Contrôlez les polices avec Aspose.Slides pour Node.js via Java : intégrez, remplacez et chargez des polices personnalisées pour garder les présentations PPT, PPTX et ODP claires et cohérentes."
---

## **Gérer les propriétés liées aux polices**
{{% alert color="primary" %}} 

Les présentations contiennent généralement à la fois du texte et des images. Le texte peut être formaté de différentes manières, soit pour mettre en évidence des sections et des mots spécifiques, soit pour se conformer aux styles d'entreprise. Le formatage du texte aide les utilisateurs à varier l'apparence du contenu de la présentation. Cet article montre comment utiliser Aspose.Slides for Node.js via Java pour configurer les propriétés de police des paragraphes de texte sur les diapositives.

{{% /alert %}} 

Pour gérer les propriétés de police d'un paragraphe en utilisant Aspose.Slides for Node.js via Java :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Obtenez la référence d'une diapositive en utilisant son index.
1. Accédez aux formes [Placeholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/placeholder/) de la diapositive et convertissez-les en [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
1. Récupérez le [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) à partir du [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) exposé par [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
1. Justifiez le paragraphe.
1. Accédez au texte [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) d'un [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/).
1. Définissez la police à l'aide de [FontData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fontdata/) et définissez la **Font** du texte [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) en conséquence.
   1. Appliquez le gras à la police.
   1. Appliquez l'italique à la police.
1. Définissez la couleur de la police à l'aide du [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/) exposé par l'objet [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/).
1. Enregistrez la présentation modifiée dans un fichier PPTX.

L'implémentation des étapes ci‑dessus est présentée ci‑après. Elle prend une présentation brute et formate les polices sur l'une des diapositives. Les captures d'écran qui suivent montrent le fichier d'entrée et la façon dont les extraits de code le modifient. Le code change la police, la couleur et le style de la police.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figure : Le texte dans le fichier d’entrée**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figure : Le même texte avec le formatage mis à jour**|
```javascript
    // Instancier un objet Presentation qui représente un fichier PPTX
    var pres = new aspose.slides.Presentation("FontProperties.pptx");
    try {
        // Accéder à une diapositive en utilisant sa position
        var slide = pres.getSlides().get_Item(0);
        // Accéder au premier et au deuxième espace réservé dans la diapositive et le convertir en AutoShape
        var tf1 = slide.getShapes().get_Item(0).getTextFrame();
        var tf2 = slide.getShapes().get_Item(1).getTextFrame();
        // Accéder au premier paragraphe
        var para1 = tf1.getParagraphs().get_Item(0);
        var para2 = tf2.getParagraphs().get_Item(0);
        // Justifier le paragraphe
        para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.JustifyLow);
        // Accéder à la première portion
        var port1 = para1.getPortions().get_Item(0);
        var port2 = para2.getPortions().get_Item(0);
        // Définir de nouvelles polices
        var fd1 = new aspose.slides.FontData("Elephant");
        var fd2 = new aspose.slides.FontData("Castellar");
        // Assigner les nouvelles polices à la portion
        port1.getPortionFormat().setLatinFont(fd1);
        port2.getPortionFormat().setLatinFont(fd2);
        // Définir la police en gras
        port1.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
        port2.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
        // Définir la police en italique
        port1.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
        port2.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
        // Définir la couleur de la police
        port1.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
        port2.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GREEN"));
        // Enregistrer le PPTX sur le disque
        pres.save("WelcomeFont.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```


## **Définir les propriétés de police du texte**
{{% alert color="primary" %}} 

Comme indiqué dans **Gérer les propriétés liées aux polices**, un [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) est utilisé pour contenir du texte avec un style de formatage similaire dans un paragraphe. Cet article montre comment utiliser Aspose.Slides for Node.js via Java pour créer une zone de texte avec du texte, puis définir une police particulière ainsi que diverses autres propriétés de la catégorie de famille de police.

{{% /alert %}} 

Pour créer une zone de texte et définir les propriétés de police du texte qu'elle contient :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Obtenez la référence d'une diapositive en utilisant son index.
1. Ajoutez un [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) de type **Rectangle** à la diapositive.
1. Supprimez le style de remplissage associé au [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
1. Accédez au [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) du [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
1. Ajoutez du texte au [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).
1. Accédez à l'objet [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) associé au [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).
1. Définissez la police à utiliser pour le [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/).
1. Définissez d'autres propriétés de police telles que gras, italique, souligné, couleur et taille en utilisant les propriétés correspondantes exposées par l'objet [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/).
1. Enregistrez la présentation modifiée au format PPTX.

L'implémentation des étapes ci‑dessus est présentée ci‑après.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figure : Texte avec certaines propriétés de police définies par Aspose.Slides for Node.js via Java**|
```javascript
// Instancier un objet Presentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Ajouter un AutoShape de type Rectangle
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 200, 50);
    // Supprimer tout style de remplissage associé à l'AutoShape
    ashp.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Accéder au TextFrame associé à l'AutoShape
    var tf = ashp.getTextFrame();
    tf.setText("Aspose TextBox");
    // Accéder à la Portion associée au TextFrame
    var port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
    // Définir la police pour la Portion
    port.getPortionFormat().setLatinFont(new aspose.slides.FontData("Times New Roman"));
    // Définir la propriété Gras de la police
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Définir la propriété Italique de la police
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Définir la propriété Souligné de la police
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // Définir la hauteur de la police
    port.getPortionFormat().setFontHeight(25);
    // Définir la couleur de la police
    port.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // Enregistrer la présentation sur le disque
    pres.save("pptxFont.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
