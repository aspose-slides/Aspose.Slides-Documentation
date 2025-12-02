---
title: Gérer les polices dans les présentations avec JavaScript
linktitle: Gérer les polices
type: docs
weight: 10
url: /fr/nodejs-java/manage-fonts/
keywords:
- gérer les polices
- propriétés des polices
- paragraphe
- mise en forme du texte
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Contrôlez les polices avec Aspose.Slides pour Node.js via Java : incorporez, remplacez et chargez des polices personnalisées pour que les présentations PPT, PPTX et ODP restent claires et cohérentes."
---

## **Gérer les propriétés liées aux polices**
{{% alert color="primary" %}} 

Les présentations contiennent généralement à la fois du texte et des images. Le texte peut être mis en forme de différentes manières, soit pour mettre en évidence des sections et des mots spécifiques, soit pour se conformer aux styles d'entreprise. Le formatage du texte aide les utilisateurs à varier l'apparence du contenu de la présentation. Cet article montre comment utiliser Aspose.Slides pour Node.js via Java afin de configurer les propriétés de police des paragraphes de texte sur les diapositives.

{{% /alert %}} 

Pour gérer les propriétés de police d'un paragraphe en utilisant Aspose.Slides pour Node.js via Java :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Obtenir la référence d'une diapositive en utilisant son index.
1. Accéder aux formes [Placeholder](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Placeholder) dans la diapositive et les convertir en [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/AutoShape).
1. Obtenir le [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Paragraph) à partir du [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/TextFrame) exposé par [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/AutoShape).
1. Justifier le paragraphe.
1. Accéder au texte [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion) d'un [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Paragraph).
1. Définir la police en utilisant [FontData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/FontData) et définir la **Font** du texte [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion) en conséquence.
   1. Mettre la police en gras.
   1. Mettre la police en italique.
1. Définir la couleur de la police en utilisant le [FillFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/FillFormat) exposé par l'objet [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion).
1. Enregistrer la présentation modifiée dans un fichier PPTX.

L'implémentation des étapes ci-dessus est présentée ci-dessous. Elle prend une présentation vierge et formate les polices sur l'une des diapositives. Les captures d'écran suivantes montrent le fichier d'entrée et la façon dont les extraits de code le modifient. Le code change la police, la couleur et le style de la police.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Figure: Le texte dans le fichier d'entrée**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Figure: Le même texte avec un formatage mis à jour**|
```javascript
// Instancier un objet Presentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation("FontProperties.pptx");
try {
    // Accéder à une diapositive en utilisant sa position
    var slide = pres.getSlides().get_Item(0);
    // Accéder aux premier et deuxième espaces réservés de la diapositive et les convertir en AutoShape
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
    // Attribuer les nouvelles polices à la portion
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

Comme indiqué dans **Gestion des propriétés liées aux polices**, un [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion) est utilisé pour contenir du texte avec un style de mise en forme similaire dans un paragraphe. Cet article montre comment utiliser Aspose.Slides pour Node.js via Java pour créer une zone de texte avec du texte, puis définir une police particulière ainsi que diverses autres propriétés de la catégorie de famille de polices.

{{% /alert %}} 

Pour créer une zone de texte et définir les propriétés de police du texte qu'elle contient :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation).
1. Obtenir la référence d'une diapositive en utilisant son index.
1. Ajouter un [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/AutoShape) de type **Rectangle** à la diapositive.
1. Supprimer le style de remplissage associé au [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/AutoShape).
1. Accéder au [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/TextFrame) du [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/AutoShape).
1. Ajouter du texte au [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/TextFrame).
1. Accéder à l'objet [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion) associé au [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/TextFrame).
1. Définir la police à utiliser pour le [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion).
1. Définir d'autres propriétés de police comme gras, italique, souligné, couleur et hauteur en utilisant les propriétés pertinentes exposées par l'objet [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/classes/Portion).
1. Enregistrer la présentation modifiée au format PPTX.

L'implémentation des étapes ci-dessus est présentée ci-dessous.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Figure: Texte avec certaines propriétés de police définies par Aspose.Slides pour Node.js via Java**|
```javascript
// Instancier un objet Presentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    // Obtenir la première diapositive
    var sld = pres.getSlides().get_Item(0);
    // Ajouter une AutoShape de type Rectangle
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
    // Définir la propriété gras de la police
    port.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    // Définir la propriété italique de la police
    port.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
    // Définir la propriété soulignement de la police
    port.getPortionFormat().setFontUnderline(aspose.slides.TextUnderlineType.Single);
    // Définir la taille de la police
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
