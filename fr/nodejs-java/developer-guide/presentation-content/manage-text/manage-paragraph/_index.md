---
title: Gestion des paragraphes de texte PowerPoint en JavaScript
linktitle: Gérer le paragraphe
type: docs
weight: 40
url: /fr/nodejs-java/manage-paragraph/
keywords:
- ajouter du texte
- ajouter un paragraphe
- gérer le texte
- gérer le paragraphe
- gérer les puces
- indentation de paragraphe
- indentation suspendue
- puce de paragraphe
- liste numérotée
- liste à puces
- propriétés du paragraphe
- importer HTML
- texte vers HTML
- paragraphe vers HTML
- paragraphe vers image
- texte vers image
- exporter le paragraphe
- PowerPoint
- OpenDocument
- présentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Maîtrisez le formatage des paragraphes avec Aspose.Slides pour Node.js via Java — optimisez l’alignement, l’espacement et le style dans les présentations PPT, PPTX et ODP en JavaScript."
---
Aspose.Slides fournit toutes les classes dont vous avez besoin pour travailler avec les textes, paragraphes et portions PowerPoint en Java.

* Aspose.Slides fournit la classe [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/) pour vous permettre d’ajouter des objets représentant un paragraphe. Un objet `TextFame` peut contenir un ou plusieurs paragraphes (chaque paragraphe est créé via un retour chariot).
* Aspose.Slides fournit la classe [Paragraph](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraph/) pour vous permettre d’ajouter des objets représentant des portions. Un objet `Paragraph` peut contenir une ou plusieurs portions (collection d’objets de portion de texte).
* Aspose.Slides fournit la classe [Portion](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portion/) pour vous permettre d’ajouter des objets représentant des textes et leurs propriétés de formatage.

Un objet `Paragraph` peut gérer des textes avec différentes propriétés de formatage grâce à ses objets sous‑jacent `Portion`.

## **Ajouter plusieurs paragraphes contenant plusieurs portions**

Ces étapes montrent comment ajouter un cadre de texte contenant 3 paragraphes et chaque paragraphe contenant 3 portions :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive souhaitée par son indice.
3. Ajoutez un [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) rectangle à la diapositive.
4. Obtenez le `ITextFrame` associé à l’[AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/).
5. Créez deux objets [Paragraph](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraph/) et ajoutez‑les à la collection `IParagraphs` du [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/).
6. Créez trois objets [Portion](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/portion/) pour chaque nouveau `Paragraph` (deux objets Portion pour le paragraphe par défaut) et ajoutez chaque objet `Portion` à la collection `IPortion` de chaque `Paragraph`.
7. Définissez du texte pour chaque portion.
8. Appliquez les caractéristiques de formatage souhaitées à chaque portion en utilisant les propriétés de formatage exposées par l’objet `Portion`.
9. Enregistrez la présentation modifiée.

Ce code Javascript implémente les étapes pour ajouter des paragraphes contenant des portions :

```javascript
// Instancier une classe Presentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accéder à la première diapositive
    var slide = pres.getSlides().get_Item(0);
    // Ajouter une AutoShape de type Rectangle
    var ashp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 150, 300, 150);
    // Accéder au TextFrame de l'AutoShape
    var tf = ashp.getTextFrame();
    // Créer des Paragraphs et Portions avec différents formats de texte
    var para0 = tf.getParagraphs().get_Item(0);
    var port01 = new aspose.slides.Portion();
    var port02 = new aspose.slides.Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);
    var para1 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para1);
    var port10 = new aspose.slides.Portion();
    var port11 = new aspose.slides.Portion();
    var port12 = new aspose.slides.Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);
    var para2 = new aspose.slides.Paragraph();
    tf.getParagraphs().add(para2);
    var port20 = new aspose.slides.Portion();
    var port21 = new aspose.slides.Portion();
    var port22 = new aspose.slides.Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);
    for (var i = 0; i < 3; i++) {
        for (var j = 0; j < 3; j++) {
            var portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j);
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
                portion.getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
                portion.getPortionFormat().setFontItalic(aspose.slides.NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }
    // Écrire le PPTX sur le disque
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gestion des puces de paragraphe**

Les listes à puces vous aident à organiser et présenter l’information rapidement et efficacement. Les paragraphes à puces sont toujours plus faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive souhaitée par son indice.
3. Ajoutez un [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) à la diapositive sélectionnée.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/) de l’auto‑forme.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraph/).
7. Définissez le `Type` de puce du paragraphe sur `Symbol` et spécifiez le caractère de puce.
8. Définissez le `Text` du paragraphe.
9. Définissez l’`Indent` du paragraphe pour la puce.
10. Définissez une couleur pour la puce.
11. Définissez une hauteur pour la puce.
12. Ajoutez le nouveau paragraphe à la collection de paragraphes du `TextFrame`.
13. Ajoutez le deuxième paragraphe et répétez le processus décrit aux étapes 7 à 13.
14. Enregistrez la présentation.

Ce code Javascript montre comment ajouter une puce de paragraphe :

```javascript
// Instancie une classe Presentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accède à la première diapositive
    var slide = pres.getSlides().get_Item(0);
    // Ajoute et accède à l'AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Accède au cadre de texte de l'auto‑forme
    var txtFrm = aShp.getTextFrame();
    // Supprime le paragraphe par défaut
    txtFrm.getParagraphs().removeAt(0);
    // Crée un paragraphe
    var para = new aspose.slides.Paragraph();
    // Définit le style de puce et le symbole du paragraphe
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // Définit le texte du paragraphe
    para.setText("Welcome to Aspose.Slides");
    // Définit l'indentation de la puce
    para.getParagraphFormat().setIndent(25);
    // Définit la couleur de la puce
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// définir IsBulletHardColor sur true pour utiliser une couleur de puce personnalisée
    // Définit la hauteur de la puce
    para.getParagraphFormat().getBullet().setHeight(100);
    // Ajoute le paragraphe au cadre de texte
    txtFrm.getParagraphs().add(para);
    // Crée le deuxième paragraphe
    var para2 = new aspose.slides.Paragraph();
    // Définit le type et le style de puce du paragraphe
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(aspose.slides.NumberedBulletStyle.BulletCircleNumWDBlackPlain);
    // Ajoute le texte du paragraphe
    para2.setText("This is numbered bullet");
    // Définit l'indentation de la puce
    para2.getParagraphFormat().setIndent(25);
    para2.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// définir IsBulletHardColor sur true pour utiliser une couleur de puce personnalisée
    // Définit la hauteur de la puce
    para2.getParagraphFormat().getBullet().setHeight(100);
    // Ajoute le paragraphe au cadre de texte
    txtFrm.getParagraphs().add(para2);
    // Enregistre la présentation modifiée
    pres.save("Bullet_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gestion des puces d’image**

Les listes à puces vous aident à organiser et présenter l’information rapidement et efficacement. Les paragraphes avec image sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive souhaitée par son indice.
3. Ajoutez un [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/) de l’auto‑forme.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraph/).
7. Chargez l’image dans [PPImage](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/).
8. Définissez le type de puce sur [Picture](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/ppimage/) et affectez l’image.
9. Définissez le `Text` du paragraphe.
10. Définissez l’`Indent` du paragraphe pour la puce.
11. Définissez une couleur pour la puce.
12. Définissez une hauteur pour la puce.
13. Ajoutez le nouveau paragraphe à la collection de paragraphes du `TextFrame`.
14. Ajoutez le deuxième paragraphe et répétez le processus basé sur les étapes précédentes.
15. Enregistrez la présentation modifiée.

Ce code Javascript montre comment ajouter et gérer des puces d’image :

```javascript
// Instancie une classe Presentation qui représente un fichier PPTX
var presentation = new aspose.slides.Presentation();
try {
    // Accède à la première diapositive
    var slide = presentation.getSlides().get_Item(0);
    // Instancie l'image pour les puces
    var picture;
    var image = aspose.slides.Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Ajoute et accède à l'AutoShape
    var autoShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Accède au cadre de texte de l'autoshape
    var textFrame = autoShape.getTextFrame();
    // Supprime le paragraphe par défaut
    textFrame.getParagraphs().removeAt(0);
    // Crée un nouveau paragraphe
    var paragraph = new aspose.slides.Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");
    // Définit le style de puce du paragraphe et l'image
    paragraph.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // Définit la hauteur de la puce
    paragraph.getParagraphFormat().getBullet().setHeight(100);
    // Ajoute le paragraphe au cadre de texte
    textFrame.getParagraphs().add(paragraph);
    // Enregistre la présentation au format PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", aspose.slides.SaveFormat.Pptx);
    // Enregistre la présentation au format PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", aspose.slides.SaveFormat.Ppt);
} catch (e) {console.log(e);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Gestion des puces à niveaux multiples**

Les listes à puces vous aident à organiser et présenter l’information rapidement et efficacement. Les puces à plusieurs niveaux sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive souhaitée par son indice.
3. Ajoutez un [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) dans la nouvelle diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/) de l’auto‑forme.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraph/) et définissez la profondeur à 0.
7. Créez la deuxième instance de paragraphe via la classe `Paragraph` et définissez la profondeur à 1.
8. Créez la troisième instance de paragraphe via la classe `Paragraph` et définissez la profondeur à 2.
9. Créez la quatrième instance de paragraphe via la classe `Paragraph` et définissez la profondeur à 3.
10. Ajoutez les nouveaux paragraphes à la collection de paragraphes du `TextFrame`.
11. Enregistrez la présentation modifiée.

Ce code Javascript montre comment ajouter et gérer des puces à niveaux multiples :

```javascript
// Instancie une classe Presentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accède à la première diapositive
    var slide = pres.getSlides().get_Item(0);
    // Ajoute et accède à l'AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Accède au cadre de texte de l'AutoShape créé
    var text = aShp.addTextFrame("");
    // Vide le paragraphe par défaut
    text.getParagraphs().clear();
    // Ajoute le premier paragraphe
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Définit le niveau de la puce
    para1.getParagraphFormat().setDepth(0);
    // Ajoute le deuxième paragraphe
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Définit le niveau de la puce
    para2.getParagraphFormat().setDepth(1);
    // Ajoute le troisième paragraphe
    var para3 = new aspose.slides.Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Définit le niveau de la puce
    para3.getParagraphFormat().setDepth(2);
    // Ajoute le quatrième paragraphe
    var para4 = new aspose.slides.Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Définit le niveau de la puce
    para4.getParagraphFormat().setDepth(3);
    // Ajoute les paragraphes à la collection
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);
    // Enregistre la présentation au format PPTX
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Gestion des paragraphes avec liste numérotée personnalisée**

La classe [BulletFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/bulletformat/) fournit la propriété [NumberedBulletStartWith](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) et d’autres qui vous permettent de gérer des paragraphes avec une numérotation ou un formatage personnalisé.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/).
2. Accédez à la diapositive contenant le paragraphe.
3. Ajoutez un [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/) de l’auto‑forme.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraph/) et définissez [NumberedBulletStartWith](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) à 2.
7. Créez la deuxième instance de paragraphe via la classe `Paragraph` et définissez `NumberedBulletStartWith` à 3.
8. Créez la troisième instance de paragraphe via la classe `Paragraph` et définissez `NumberedBulletStartWith` à 7.
9. Ajoutez les nouveaux paragraphes à la collection de paragraphes du `TextFrame`.
10. Enregistrez la présentation modifiée.

Ce code Javascript montre comment ajouter et gérer des paragraphes avec une numérotation ou un formatage personnalisé :

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Accède au cadre de texte de l'auto-shape créée
    var textFrame = shape.getTextFrame();
    // Supprime le paragraphe par défaut existant
    textFrame.getParagraphs().removeAt(0);
    // Première liste
    var paragraph1 = new aspose.slides.Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth(4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith(2);
    paragraph1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);
    var paragraph2 = new aspose.slides.Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth(4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith(3);
    paragraph2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);
    var paragraph5 = new aspose.slides.Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth(4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith(7);
    paragraph5.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);
    presentation.save("SetCustomBulletsNumber-slides.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Définir l’indentation de première ligne d’un paragraphe**

Utilisez la méthode [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/setindent/) pour contrôler l’indentation de la première ligne d’un paragraphe. Cette méthode ne déplace que la première ligne par rapport à la marge gauche du paragraphe. Une valeur positive décale la première ligne vers la droite, tandis que les lignes suivantes restent alignées au corps du paragraphe.

Utilisez [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) lorsque vous devez déplacer le paragraphe entier. Utilisez [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/setindent/) lorsque vous ne devez déplacer que la première ligne.

L’exemple ci‑dessous crée plusieurs paragraphes et applique différentes valeurs d’indentation pour illustrer l’impact de l’indentation de première ligne sur la mise en page du paragraphe.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/).
2. Accédez à la diapositive cible.
3. Ajoutez un [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) rectangulaire à la diapositive.
4. Ajoutez un [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/) vide à la forme et supprimez le paragraphe par défaut.
5. Créez plusieurs paragraphes et définissez différentes valeurs d’[Indent](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/setindent/) pour chacun.
6. Ajoutez les paragraphes au cadre de texte.
7. Enregistrez la présentation modifiée.

Ce code montre comment définir une indentation de paragraphe :

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20);
    firstParagraph.getParagraphFormat().setIndent(0);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20);
    secondParagraph.getParagraphFormat().setIndent(20);

    let thirdParagraph = new aspose.slides.Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20);
    thirdParagraph.getParagraphFormat().setIndent(40);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Le résultat :

![The first-line indent of the paragraphs](first_line_indent.png)

## **Définir une indentation suspendue pour un paragraphe**

Une indentation suspendue est une mise en page où la première ligne commence à gauche des lignes suivantes. Dans Aspose.Slides, vous créez cet effet avec la méthode [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/setindent/). Définissez l’indentation sur une valeur négative pour déplacer la première ligne vers la gauche par rapport au corps du paragraphe.

En pratique, [ParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) définit la position gauche du corps du paragraphe, et [ParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/setindent/) définit la position de la première ligne par rapport à cette marge. Pour créer une indentation suspendue, définissez une valeur positive pour `MarginLeft` et une valeur négative pour `Indent`.

Ce formatage est utile pour les bibliographies, références, entrées de glossaire et tout autre paragraphe où les lignes enroulées doivent être alignées sous le corps du paragraphe plutôt que sous le premier caractère de la première ligne.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/).
2. Accédez à la diapositive cible.
3. Ajoutez un [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) rectangulaire à la diapositive.
4. Ajoutez un [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/) vide à la forme et supprimez le paragraphe par défaut.
5. Créez des paragraphes et définissez une valeur positive pour [MarginLeft](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/setmarginleft/) pour chaque paragraphe.
6. Définissez une valeur négative pour [Indent](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/setindent/) afin de créer l’effet d’indentation suspendue.
7. Ajoutez les paragraphes au cadre de texte.
8. Enregistrez la présentation modifiée.

Ce code montre comment définir une indentation suspendue pour un paragraphe :

```js
let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let rectangleShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    rectangleShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "GRAY"));

    let textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(java.newByte(aspose.slides.TextAutofitType.Shape));
    textFrame.getParagraphs().removeAt(0);

    let firstParagraph = new aspose.slides.Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40);
    firstParagraph.getParagraphFormat().setIndent(-20);

    let secondParagraph = new aspose.slides.Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60);
    secondParagraph.getParagraphFormat().setIndent(-30);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", aspose.slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Le résultat :

![The hanging indent of the paragraphs](hanging_indent.png)

## **Gestion des propriétés de fin d’exécution du paragraphe**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/).
1. Obtenez la référence de la diapositive contenant le paragraphe par sa position.
1. Ajoutez un [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) rectangle à la diapositive.
1. Ajoutez un [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/) avec deux paragraphes au rectangle.
1. Définissez le `FontHeight` et le type de police pour les paragraphes.
1. Définissez les propriétés End pour les paragraphes.
1. Enregistrez la présentation modifiée au format PPTX.

Ce code Javascript montre comment définir les propriétés End pour les paragraphes dans PowerPoint :

```javascript
var pres = new aspose.slides.Presentation();
try {
    var shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, 200, 250);
    var para1 = new aspose.slides.Paragraph();
    para1.getPortions().add(new aspose.slides.Portion("Sample text"));
    var para2 = new aspose.slides.Paragraph();
    para2.getPortions().add(new aspose.slides.Portion("Sample text 2"));
    var portionFormat = new aspose.slides.PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new aspose.slides.FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);
    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);
    pres.save(resourcesOutputPath + "pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Importer du texte HTML dans des paragraphes**

Aspose.Slides offre une prise en charge améliorée de l’importation de texte HTML dans des paragraphes.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive souhaitée par son indice.
3. Ajoutez un [AutoShape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/autoshape/) à la diapositive.
4. Ajoutez et accédez au [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/) de l’AutoShape.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Lisez le fichier HTML source dans un `TextReader`.
7. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraph/).
8. Ajoutez le contenu du fichier HTML lu par le `TextReader` à la [ParagraphCollection](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphcollection/) du TextFrame.
9. Enregistrez la présentation modifiée.

Ce code Javascript implémente les étapes d’importation de textes HTML dans des paragraphes :

```javascript
// Créer une instance de présentation vide
var pres = new aspose.slides.Presentation();
try {
    // Accéder à la première diapositive par défaut de la présentation
    var slide = pres.getSlides().get_Item(0);
    // Ajouter l'AutoShape pour accueillir le contenu HTML
    var ashape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 10, 10, pres.getSlideSize().getSize().getWidth() - 20, pres.getSlideSize().getSize().getHeight() - 10);
    ashape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    // Ajouter un cadre de texte à la forme
    ashape.addTextFrame("");
    // Effacer tous les paragraphes du cadre de texte ajouté
    ashape.getTextFrame().getParagraphs().clear();
    // Charger le fichier HTML à l'aide d'un lecteur de flux
    var tr = java.newInstanceSync("StreamReader", "file.html");
    // Ajouter le texte du lecteur de flux HTML dans le cadre de texte
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());
    // Enregistrer la présentation
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Exporter le texte des paragraphes vers HTML**

Aspose.Slides offre une prise en charge améliorée de l’exportation de textes (contenus dans des paragraphes) vers HTML.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/presentation/) et chargez la présentation souhaitée.
2. Accédez à la référence de la diapositive pertinente par son indice.
3. Accédez à la forme contenant le texte à exporter vers HTML.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframe/) de la forme.
5. Créez une instance de `StreamWriter` et ajoutez le nouveau fichier HTML.
6. Fournissez un indice de départ à `StreamWriter` et exportez les paragraphes souhaités.

Ce code Javascript montre comment exporter les textes de paragraphes PowerPoint vers HTML :

```javascript
// Charger le fichier de présentation
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // Accéder à la première diapositive par défaut de la présentation
    var slide = pres.getSlides().get_Item(0);
    // Index souhaité
    var index = 0;
    // Accéder à la forme ajoutée
    var ashape = slide.getShapes().get_Item(index);
    // Créer le fichier HTML de sortie
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // Extraire le premier paragraphe en HTML
    // Écrire les données des paragraphes en HTML en fournissant l'index de départ du paragraphe et le nombre total de paragraphes à copier
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Enregistrer un paragraphe en tant qu’image**

Dans cette section, nous explorerons deux exemples illustrant comment enregistrer un paragraphe de texte, représenté par la classe [Paragraph](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraph/), sous forme d’image. Les deux exemples comprennent l’obtention de l’image d’une forme contenant le paragraphe à l’aide des méthodes `getImage` de la classe [Shape](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/shape/), le calcul des limites du paragraphe dans la forme, et l’exportation sous forme d’image bitmap. Ces approches permettent d’extraire des parties spécifiques du texte d’une présentation PowerPoint et de les enregistrer comme images séparées, ce qui peut être utile dans divers scénarios.

Supposons que nous disposions d’un fichier de présentation nommé **sample.pptx** contenant une diapositive, où la première forme est une zone de texte contenant trois paragraphes.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Example 1**

Dans cet exemple, nous obtenons le deuxième paragraphe sous forme d’image. Pour ce faire, nous extrayons l’image de la forme de la première diapositive de la présentation, puis calculons les limites du deuxième paragraphe dans le cadre de texte de la forme. Le paragraphe est ensuite redessiné sur une nouvelle image bitmap, enregistrée au format PNG. Cette méthode est particulièrement utile lorsque vous devez enregistrer un paragraphe spécifique comme image séparée tout en conservant les dimensions et le formatage exacts du texte.

```java
const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Enregistrer la forme en mémoire sous forme de bitmap.
    const shapeImage = firstShape.getImage();
        
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();
    shapeImageStream.flush();
    
    // Créer un bitmap de forme à partir de la mémoire.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // Calculer les limites du deuxième paragraphe.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();

    // Calculer les coordonnées et la taille de l'image de sortie (taille minimale - 1x1 pixel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Recadrer le bitmap de la forme pour obtenir uniquement le bitmap du paragraphe.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

Le résultat :

![The paragraph image](paragraph_to_image_output.png)

**Example 2**

Dans cet exemple, nous étendons l’approche précédente en ajoutant des facteurs d’échelle à l’image du paragraphe. La forme est extraite de la présentation et enregistrée en tant qu’image avec un facteur d’échelle de `2`. Cela permet d’obtenir une sortie à plus haute résolution lors de l’exportation du paragraphe. Les limites du paragraphe sont alors calculées en tenant compte de l’échelle. Le redimensionnement peut être particulièrement utile lorsqu’une image plus détaillée est requise, par exemple pour une utilisation dans des documents imprimés de haute qualité.

```java
const imageScaleX = 2;
const imageScaleY = imageScaleX;

const imageio = java.import("javax.imageio.ImageIO");
const presentation = new aspose.slides.Presentation("sample.pptx");
try {
    const firstShape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Enregistrer la forme en mémoire sous forme de bitmap avec mise à l'échelle.
    const shapeImage = firstShape.getImage(aspose.slides.ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    const shapeImageStream = java.newInstanceSync("java.io.ByteArrayOutputStream");
    shapeImage.save(shapeImageStream, aspose.slides.ImageFormat.Png);
    shapeImage.dispose();

    // Créer un bitmap de forme à partir de la mémoire.
    const byteBuffer = java.callMethodSync(shapeImageStream, "toByteArray");    
    const javaBytes = java.newArray("byte", Array.from(byteBuffer));
    const ByteArrayInputStream = java.import("java.io.ByteArrayInputStream");
    const shapeImageInputStream = new ByteArrayInputStream(javaBytes);
    const shapeBitmap = imageio.read(shapeImageInputStream);

    // Calculer les limites du deuxième paragraphe.
    const secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    const paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // Calculer les coordonnées et la taille de l'image de sortie (taille minimale - 1x1 pixel).
    const imageX = Math.floor(paragraphRectangle.getX());
    const imageY = Math.floor(paragraphRectangle.getY());
    const imageWidth = Math.max(1, Math.ceil(paragraphRectangle.getWidth()));
    const imageHeight = Math.max(1, Math.ceil(paragraphRectangle.getHeight()));

    // Recadrer le bitmap de la forme pour obtenir uniquement le bitmap du paragraphe.
    const paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    const file = java.newInstanceSync("java.io.File", "paragraph.png");

    imageio.write(paragraphBitmap, "png", file);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **FAQ**

**Puis‑je désactiver complètement le retour à la ligne dans un cadre de texte ?**

Oui. Utilisez le paramètre de retour à la ligne du cadre de texte ([setWrapText](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/textframeformat/setwraptext/)) pour désactiver le retour à la ligne afin que les lignes ne se coupent pas aux bords du cadre.

**Comment obtenir les limites exactes d’un paragraphe spécifique sur la diapositive ?**

Vous pouvez récupérer le rectangle englobant du paragraphe (et même d’une seule portion) pour connaître sa position et sa taille précises sur la diapositive.

**Où est‑ce que l’alignement du paragraphe (gauche/droite/centré/justifié) est contrôlé ?**

[setAlignment](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/setalignment/) est une méthode de réglage au niveau du paragraphe dans [ParagraphFormat](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/paragraphformat/); elle s’applique à l’ensemble du paragraphe indépendamment du formatage des portions individuelles.

**Puis‑je définir une langue de vérification orthographique pour une seule partie d’un paragraphe (par ex., un mot) ?**

Oui. La langue est définie au niveau de la portion ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/fr/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)), de sorte que plusieurs langues peuvent coexister au sein d’un même paragraphe.