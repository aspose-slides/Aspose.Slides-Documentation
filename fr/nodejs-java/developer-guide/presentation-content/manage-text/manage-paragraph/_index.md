---
title: Gérer les paragraphes de texte PowerPoint en JavaScript
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
- indentation du paragraphe
- alinéa suspendu
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
description: "Maîtrisez le formatage des paragraphes avec Aspose.Slides pour Node.js via Java - optimisez l'alignement, l'espacement et le style dans les présentations PPT, PPTX et ODP en JavaScript."
---

Aspose.Slides fournit toutes les classes dont vous avez besoin pour travailler avec le texte, les paragraphes et les portions PowerPoint en Java.

* Aspose.Slides fournit la classe [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) pour vous permettre d’ajouter des objets qui représentent un paragraphe. Un objet `TextFame` peut contenir un ou plusieurs paragraphes (chaque paragraphe est créé via un retour à la ligne).
* Aspose.Slides fournit la classe [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) pour vous permettre d’ajouter des objets qui représentent des portions. Un objet `Paragraph` peut contenir une ou plusieurs portions (collection d’objets de portion de texte).
* Aspose.Slides fournit la classe [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) pour vous permettre d’ajouter des objets qui représentent des textes et leurs propriétés de formatage.

Un objet `Paragraph` est capable de gérer des textes avec différentes propriétés de formatage grâce à ses objets `Portion` sous‑jacents.

## **Ajouter plusieurs paragraphes contenant plusieurs portions**

Ces étapes montrent comment ajouter un cadre de texte contenant 3 paragraphes et chaque paragraphe contenant 3 portions :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée via son index.
3. Ajoutez une forme rectangulaire [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) à la diapositive.
4. Récupérez le ITextFrame associé à l’[AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/).
5. Créez deux objets [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) et ajoutez‑les à la collection `IParagraphs` du [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/).
6. Créez trois objets [Portion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/portion/) pour chaque nouveau `Paragraph` (deux objets Portion pour le paragraphe par défaut) et ajoutez chaque objet `Portion` à la collection IPortion de chaque `Paragraph`.
7. Définissez un texte pour chaque portion.
8. Appliquez les fonctionnalités de formatage souhaitées à chaque portion en utilisant les propriétés de formatage exposées par l’objet `Portion`.
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
    // Create Paragraphs and Portions with different text formats
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
    // Enregistrer le PPTX sur le disque
    pres.save("multiParaPort_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Gérer les puces de paragraphe**

Les listes à puces vous aident à organiser et présenter les informations rapidement et efficacement. Les paragraphes à puces sont toujours plus faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée via son index.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) à la diapositive sélectionnée.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) de l’auto‑forme.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/).
7. Définissez le `Type` de la puce du paragraphe sur `Symbol` et définissez le caractère de puce.
8. Définissez le `Text` du paragraphe.
9. Définissez le `Indent` du paragraphe pour la puce.
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
    // Accède au cadre de texte de l'AutoShape
    var txtFrm = aShp.getTextFrame();
    // Supprime le paragraphe par défaut
    txtFrm.getParagraphs().removeAt(0);
    // Crée un paragraphe
    var para = new aspose.slides.Paragraph();
    // Définit le style de puce du paragraphe et le symbole
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // Définit le texte du paragraphe
    para.setText("Welcome to Aspose.Slides");
    // Définit l'indentation de la puce
    para.getParagraphFormat().setIndent(25);
    // Définit la couleur de la puce
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    para.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// définit IsBulletHardColor à true pour utiliser une couleur de puce personnalisée
    // Définit la hauteur de la puce
    para.getParagraphFormat().getBullet().setHeight(100);
    // Ajoute le paragraphe au cadre de texte
    txtFrm.getParagraphs().add(para);
    // Crée un deuxième paragraphe
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
    para2.getParagraphFormat().getBullet().setBulletHardColor(aspose.slides.NullableBool.True);// définit IsBulletHardColor à true pour utiliser une couleur de puce personnalisée
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


## **Gérer les puces avec image**

Les listes à puces vous aident à organiser et présenter les informations rapidement et efficacement. Les paragraphes avec image sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée via son index.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) de l’auto‑forme.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/).
7. Chargez l’image dans [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/).
8. Définissez le type de puce sur [Picture](https://reference.aspose.com/slides/nodejs-java/aspose.slides/ppimage/) et affectez l’image.
9. Définissez le `Text` du paragraphe.
10. Définissez le `Indent` du paragraphe pour la puce.
11. Définissez une couleur pour la puce.
12. Définissez une hauteur pour la puce.
13. Ajoutez le nouveau paragraphe à la collection de paragraphes du `TextFrame`.
14. Ajoutez le deuxième paragraphe et répétez le processus basé sur les étapes précédentes.
15. Enregistrez la présentation modifiée.

Ce code Javascript montre comment ajouter et gérer des puces avec image :
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
    // Accède au TextFrame de l'AutoShape
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
    // Ajoute le paragraphe au TextFrame
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


## **Gérer les puces à plusieurs niveaux**

Les listes à puces vous aident à organiser et présenter les informations rapidement et efficacement. Les puces à plusieurs niveaux sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée via son index.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) dans la nouvelle diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) de l’auto‑forme.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) et définissez la profondeur à 0.
7. Créez la deuxième instance de paragraphe via la classe `Paragraph` et définissez la profondeur à 1.
8. Créez la troisième instance de paragraphe via la classe `Paragraph` et définissez la profondeur à 2.
9. Créez la quatrième instance de paragraphe via la classe `Paragraph` et définissez la profondeur à 3.
10. Ajoutez les nouveaux paragraphes à la collection de paragraphes du `TextFrame`.
11. Enregistrez la présentation modifiée.

Ce code Javascript montre comment ajouter et gérer des puces à plusieurs niveaux :
```javascript
// Instancie une classe Presentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accède à la première diapositive
    var slide = pres.getSlides().get_Item(0);
    // Ajoute et accède à l'AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Accède au cadre de texte de l'AutoShape créée
    var text = aShp.addTextFrame("");
    // Efface le paragraphe par défaut
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


## **Gérer un paragraphe avec une liste numérotée personnalisée**

La classe [BulletFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/) fournit la propriété [NumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) et d’autres qui vous permettent de gérer des paragraphes avec une numérotation ou un formatage personnalisés.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Accédez à la diapositive contenant le paragraphe.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) de l’auto‑forme.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) et définissez [NumberedBulletStartWith](https://reference.aspose.com/slides/nodejs-java/aspose.slides/bulletformat/#setNumberedBulletStartWith-short-) à 2.
7. Créez la deuxième instance de paragraphe via la classe `Paragraph` et définissez `NumberedBulletStartWith` à 3.
8. Créez la troisième instance de paragraphe via la classe `Paragraph` et définissez `NumberedBulletStartWith` à 7.
9. Ajoutez les nouveaux paragraphes à la collection de paragraphes du `TextFrame`.
10. Enregistrez la présentation modifiée.

Ce code Javascript montre comment ajouter et gérer des paragraphes avec une numérotation ou un formatage personnalisés :
```javascript
var presentation = new aspose.slides.Presentation();
try {
    var shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Accède au cadre de texte de l'autoforme créée
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


## **Définir l’indentation du paragraphe**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Accédez à la référence de la diapositive concernée via son index.
1. Ajoutez une forme rectangulaire [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) à la diapositive.
1. Ajoutez un [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) contenant trois paragraphes à la forme rectangulaire.
1. Masquez les lignes du rectangle.
1. Définissez l’indentation pour chaque [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/) via sa propriété `BulletOffset`.
1. Enregistrez la présentation modifiée au format PPT.

Ce code Javascript montre comment définir l’indentation d’un paragraphe :
```javascript
    // Instancier la classe Presentation
    var pres = new aspose.slides.Presentation();
    try {
        // Obtenir la première diapositive
        var sld = pres.getSlides().get_Item(0);
        // Ajouter une forme rectangle
        var rect = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 500, 150);
        // Ajouter un TextFrame au rectangle
        var tf = rect.addTextFrame("This is first line \rThis is second line \rThis is third line");
        // Définir le texte pour s'adapter à la forme
        tf.getTextFrameFormat().setAutofitType(aspose.slides.TextAutofitType.Shape);
        // Masquer les lignes du rectangle
        rect.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        // Obtenir le premier paragraphe du TextFrame et définir son indentation
        var para1 = tf.getParagraphs().get_Item(0);
        // Définir le style de puce du paragraphe et le symbole
        para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
        para1.getParagraphFormat().getBullet().setChar(8226);
        para1.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        para1.getParagraphFormat().setDepth(2);
        para1.getParagraphFormat().setIndent(30);
        // Obtenir le deuxième paragraphe du TextFrame et définir son indentation
        var para2 = tf.getParagraphs().get_Item(1);
        para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
        para2.getParagraphFormat().getBullet().setChar(8226);
        para2.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        para2.getParagraphFormat().setDepth(2);
        para2.getParagraphFormat().setIndent(40);
        // Obtenir le troisième paragraphe du TextFrame et définir son indentation
        var para3 = tf.getParagraphs().get_Item(2);
        para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
        para3.getParagraphFormat().getBullet().setChar(8226);
        para3.getParagraphFormat().setAlignment(aspose.slides.TextAlignment.Left);
        para3.getParagraphFormat().setDepth(2);
        para3.getParagraphFormat().setIndent(50);
        // Enregistrer la présentation sur le disque
        pres.save("InOutDent_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (pres != null) {
            pres.dispose();
        }
    }
```


## **Définir l’indentation en suspension d’un paragraphe**

Ce code Javascript montre comment définir l’indentation en suspension d’un paragraphe :
```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 250, 550, 150);
    var para1 = new aspose.slides.Paragraph();
    para1.setText("Example");
    var para2 = new aspose.slides.Paragraph();
    para2.setText("Set Hanging Indent for Paragraph");
    var para3 = new aspose.slides.Paragraph();
    para3.setText("This code shows you how to set the hanging indent for a paragraph: ");
    para2.getParagraphFormat().setMarginLeft(10.0);
    para3.getParagraphFormat().setMarginLeft(20.0);
    autoShape.getTextFrame().getParagraphs().add(para1);
    autoShape.getTextFrame().getParagraphs().add(para2);
    autoShape.getTextFrame().getParagraphs().add(para3);
    pres.save("pres.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Gérer les propriétés d’exécution de fin de paragraphe**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
1. Obtenez la référence de la diapositive contenant le paragraphe via sa position.
1. Ajoutez une forme rectangulaire [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) à la diapositive.
1. Ajoutez un [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) contenant deux paragraphes au rectangle.
1. Définissez le `FontHeight` et le type de police pour les paragraphes.
1. Définissez les propriétés de fin pour les paragraphes.
1. Enregistrez la présentation modifiée au format PPTX.

Ce code Javascript montre comment définir les propriétés de fin pour les paragraphes dans PowerPoint :
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

Aspose.Slides fournit un support amélioré pour l’importation de texte HTML dans des paragraphes.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée via son index.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/autoshape/) à la diapositive.
4. Ajoutez et accédez au [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) de l’AutoShape.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Lisez le fichier HTML source dans un TextReader.
7. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/).
8. Ajoutez le contenu du fichier HTML lu dans le TextReader à la [ParagraphCollection](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphcollection/) du TextFrame.
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

Aspose.Slides fournit un support amélioré pour l’exportation de textes (contenus dans des paragraphes) vers HTML.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) et chargez la présentation souhaitée.
2. Accédez à la référence de la diapositive concernée via son index.
3. Accédez à la forme contenant le texte qui sera exporté vers HTML.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) de la forme.
5. Créez une instance de `StreamWriter` et ajoutez le nouveau fichier HTML.
6. Fournissez un index de départ à StreamWriter et exportez les paragraphes souhaités.

Ce code Javascript montre comment exporter les textes de paragraphes PowerPoint vers HTML :
```javascript
// Charger le fichier de présentation
var pres = new aspose.slides.Presentation("ExportingHTMLText.pptx");
try {
    // Accéder à la première diapositive par défaut de la présentation
    var slide = pres.getSlides().get_Item(0);
    // Indice souhaité
    var index = 0;
    // Accéder à la forme ajoutée
    var ashape = slide.getShapes().get_Item(index);
    // Créer le fichier HTML de sortie
    var os = java.newInstanceSync("java.io.FileOutputStream", "output.html");
    var writer = java.newInstanceSync("java.io.OutputStreamWriter", os, "UTF-8");
    // Extraire le premier paragraphe en HTML
    // Écrire les données des paragraphes en HTML en fournissant l'indice de départ du paragraphe et le nombre total de paragraphes à copier
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Enregistrer un paragraphe sous forme d’image**

Dans cette section, nous explorerons deux exemples qui démontrent comment enregistrer un paragraphe de texte, représenté par la classe [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraph/), sous forme d’image. Les deux exemples comprennent l’obtention de l’image d’une forme contenant le paragraphe à l’aide des méthodes `getImage` de la classe [Shape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/), le calcul des limites du paragraphe au sein de la forme, puis son exportation en tant qu’image bitmap. Ces approches vous permettent d’extraire des parties spécifiques du texte d’une présentation PowerPoint et de les enregistrer comme images séparées, ce qui peut être utile dans divers scénarios.

Supposons que nous ayons un fichier de présentation nommé **sample.pptx** contenant une diapositive, où la première forme est une zone de texte contenant trois paragraphes.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Exemple 1**

Dans cet exemple, nous obtenons le deuxième paragraphe sous forme d’image. Pour ce faire, nous extrayons l’image de la forme de la première diapositive de la présentation, puis nous calculons les limites du deuxième paragraphe dans le cadre de texte de la forme. Le paragraphe est ensuite redessiné sur une nouvelle image bitmap, qui est enregistrée au format PNG. Cette méthode est particulièrement utile lorsque vous devez enregistrer un paragraphe spécifique comme image distincte tout en conservant les dimensions et le formatage exacts du texte.
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

**Exemple 2**

Dans cet exemple, nous étendons l’approche précédente en ajoutant des facteurs d’échelle à l’image du paragraphe. La forme est extraite de la présentation et enregistrée sous forme d’image avec un facteur d’échelle de `2`. Cela permet d’obtenir une sortie à plus haute résolution lors de l’exportation du paragraphe. Les limites du paragraphe sont ensuite calculées en tenant compte de l’échelle. L’échelle peut être particulièrement utile lorsqu’une image plus détaillée est requise, par exemple pour une utilisation dans des supports imprimés de haute qualité.
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

**Puis‑je désactiver complètement le retour à la ligne à l’intérieur d’un cadre de texte ?**

Oui. Utilisez le paramètre de retour à la ligne du cadre de texte ([setWrapText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframeformat/setwraptext/)) pour désactiver le retour à la ligne afin que les lignes ne se coupent pas aux bords du cadre.

**Comment obtenir les limites exactes d’un paragraphe spécifique sur la diapositive ?**

Vous pouvez récupérer le rectangle de délimitation du paragraphe (et même d’une seule portion) pour connaître sa position et sa taille précises sur la diapositive.

**Où sont contrôlés les alignements de paragraphe (gauche/droite/centré/justifié) ?**

[setAlignment](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/setalignment/) est une méthode de réglage au niveau du paragraphe dans [ParagraphFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/paragraphformat/); elle s’applique à l’ensemble du paragraphe, quel que soit le formatage individuel des portions.

**Puis‑je définir une langue de vérification orthographique pour une partie seulement d’un paragraphe (par exemple, un mot) ?**

Oui. La langue est définie au niveau de la portion ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseportionformat/#setLanguageId)), ce qui permet à plusieurs langues de coexister dans un même paragraphe.