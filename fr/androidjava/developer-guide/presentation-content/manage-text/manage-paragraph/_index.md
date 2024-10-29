---
title: Gérer les Paragraphes PowerPoint en Java
type: docs
weight: 40
url: /fr/androidjava/manage-paragraph/
keywords: "Ajouter un paragraphe PowerPoint, Gérer les paragraphes, Retrait de paragraphe, Propriétés de paragraphe, Texte HTML, Exporter le texte du paragraphe, Présentation PowerPoint, Java, Aspose.Slides pour Android via Java"
description: "Créer et gérer des Paragraphes, du texte, des retraits et des propriétés dans des présentations PowerPoint en Java"
---

Aspose.Slides fournit toutes les interfaces et classes nécessaires pour travailler avec les textes, paragraphes et portions PowerPoint en Java.

* Aspose.Slides fournit l'interface [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) pour vous permettre d'ajouter des objets représentant un paragraphe. Un objet `ITextFame` peut contenir un ou plusieurs paragraphes (chaque paragraphe est créé par un retour à la ligne).
* Aspose.Slides fournit l'interface [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) pour vous permettre d'ajouter des objets représentant des portions. Un objet `IParagraph` peut avoir une ou plusieurs portions (collection d'objets iPortions).
* Aspose.Slides fournit l'interface [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) pour vous permettre d'ajouter des objets représentant des textes et leurs propriétés de formatage.

Un objet `IParagraph` est capable de gérer des textes avec différentes propriétés de formatage à travers ses objets `IPortion` sous-jacents.

## **Ajouter Plusieurs Paragraphes Contenant Plusieurs Portions**

Ces étapes vous montrent comment ajouter un cadre de texte contenant 3 paragraphes et chaque paragraphe contenant 3 portions :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée à travers son index.
3. Ajoutez une forme Rectangulaire [IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) à la diapositive.
4. Obtenez le ITextFrame associé à l'[IAutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/).
5. Créez deux objets [IParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iparagraph/) et ajoutez-les à la collection `IParagraphs` du [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/).
6. Créez trois objets [IPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportion/) pour chaque nouvel `IParagraph` (deux objets Portion pour le paragraphe par défaut) et ajoutez chaque objet `IPortion` à la collection IPortion de chaque `IParagraph`.
7. Définissez du texte pour chaque portion.
8. Appliquez vos fonctionnalités de formatage préférées à chaque portion en utilisant les propriétés de formatage exposées par l'objet `IPortion`.
9. Enregistrez la présentation modifiée.

Ce code Java est une implémentation des étapes pour ajouter des paragraphes contenant des portions :

```java
// Instanciation d'une classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accès à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajout d'une forme AutoShape de type Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Accès au TextFrame de l'AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // Création de Paragraphes et Portions avec différents formats de texte
    IParagraph para0 = tf.getParagraphs().get_Item(0);
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.getPortions().add(port01);
    para0.getPortions().add(port02);

    IParagraph para1 = new Paragraph();
    tf.getParagraphs().add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.getPortions().add(port10);
    para1.getPortions().add(port11);
    para1.getPortions().add(port12);

    IParagraph para2 = new Paragraph();
    tf.getParagraphs().add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.getPortions().add(port20);
    para2.getPortions().add(port21);
    para2.getPortions().add(port22);

    for (int i = 0; i < 3; i++) 
    {
        for (int j = 0; j < 3; j++) 
        {
            IPortion portion = tf.getParagraphs().get_Item(i).getPortions().get_Item(j); 
            portion.setText("Portion0" + j);
            if (j == 0) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.RED);
                portion.getPortionFormat().setFontBold(NullableBool.True);
                portion.getPortionFormat().setFontHeight(15);
            } else if (j == 1) {
                portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
                portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
                portion.getPortionFormat().setFontItalic(NullableBool.True);
                portion.getPortionFormat().setFontHeight(18);
            }
        }
    }

    //Écrire le PPTX sur le disque
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Gérer les Puces de Paragraphe**

Les listes à puces vous aident à organiser et à présenter l'information rapidement et efficacement. Les paragraphes à puces sont toujours plus faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée à travers son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) à la diapositive sélectionnée.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) de l'autoshape.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/).
7. Définissez le `Type` de puce pour le paragraphe sur `Symbol` et définissez le caractère de puce.
8. Définissez le `Text` du paragraphe.
9. Définissez le `Indent` du paragraphe pour la puce.
10. Définissez une couleur pour la puce.
11. Définissez une hauteur pour la puce.
12. Ajoutez le nouveau paragraphe à la collection de paragraphes du `TextFrame`.
13. Ajoutez le deuxième paragraphe et répétez le processus indiqué dans les étapes 7 à 13.
14. Enregistrez la présentation.

Ce code Java vous montre comment ajouter une puce de paragraphe :

```java
// Instanciation d'une classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accède à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajoute et accède à l'Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accède au text frame de l'autoshape
    ITextFrame txtFrm = aShp.getTextFrame();

    // Supprime le paragraphe par défaut
    txtFrm.getParagraphs().removeAt(0);

    // Crée un paragraphe
    Paragraph para = new Paragraph();

    // Définit un style de puce et un symbole de paragraphe
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // Définit un texte de paragraphe
    para.setText("Bienvenue chez Aspose.Slides");

    // Définit le retrait de la puce
    para.getParagraphFormat().setIndent(25);

    // Définit la couleur de la puce
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // Définit IsBulletHardColor sur true pour utiliser sa propre couleur de puce

    // Définit la hauteur de la puce
    para.getParagraphFormat().getBullet().setHeight(100);

    // Ajoute le paragraphe au cadre de texte
    txtFrm.getParagraphs().add(para);

    // Crée le deuxième paragraphe
    Paragraph para2 = new Paragraph();

    // Définit le type et le style de puce du paragraphe
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Ajoute le texte du paragraphe
    para2.setText("Ceci est une puce numérotée");

    // Définit le retrait de la puce
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // Définit IsBulletHardColor sur true pour utiliser sa propre couleur de puce

    // Définit la hauteur de la puce
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Ajoute le paragraphe au cadre de texte
    txtFrm.getParagraphs().add(para2);
    
    // Enregistre la présentation modifiée
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Gérer les Puces d'Image**

Les listes à puces vous aident à organiser et à présenter l'information rapidement et efficacement. Les paragraphes d'images sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée à travers son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) de l'autoshape.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/).
7. Chargez l'image dans [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/).
8. Définissez le type de puce sur [Image](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/) et définissez l'image.
9. Définissez le `Text` du paragraphe.
10. Définissez le `Indent` du paragraphe pour la puce.
11. Définissez une couleur pour la puce.
12. Définissez une hauteur pour la puce.
13. Ajoutez le nouveau paragraphe à la collection de paragraphes du `TextFrame`.
14. Ajoutez le deuxième paragraphe et répétez le processus basé sur les étapes précédentes.
15. Enregistrez la présentation modifiée.

Ce code Java vous montre comment ajouter et gérer des puces d'images :

```java
// Instanciation d'une classe Presentation qui représente un fichier PPTX
Presentation presentation = new Presentation();
try {
    // Accède à la première diapositive
    ISlide slide = presentation.getSlides().get_Item(0);

    // Instanciation de l'image pour les puces
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Ajoute et accède à l'Autoshape
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accède au text frame de l'autoshape
    ITextFrame textFrame = autoShape.getTextFrame();

    // Supprime le paragraphe par défaut
    textFrame.getParagraphs().removeAt(0);

    // Crée un nouveau paragraphe
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Bienvenue chez Aspose.Slides");

    // Définit le style et l'image de la puce du paragraphe
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Définit la hauteur de la puce
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // Ajoute le paragraphe au cadre de texte
    textFrame.getParagraphs().add(paragraph);

    // Écrit la présentation sous forme de fichier PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // Écrit la présentation sous forme de fichier PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Gérer les Puces Multiniveaux**

Les listes à puces vous aident à organiser et à présenter l'information rapidement et efficacement. Les puces multiniveaux sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée à travers son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) dans la nouvelle diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) de l'autoshape.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe à travers la classe [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) et définissez la profondeur à 0.
7. Créez la deuxième instance de paragraphe à travers la classe `Paragraph` et définissez la profondeur à 1.
8. Créez la troisième instance de paragraphe à travers la classe `Paragraph` et définissez la profondeur à 2.
9. Créez la quatrième instance de paragraphe à travers la classe `Paragraph` et définissez la profondeur à 3.
10. Ajoutez les nouveaux paragraphes à la collection de paragraphes du `TextFrame`.
11. Enregistrez la présentation modifiée.

Ce code Java vous montre comment ajouter et gérer des puces multiniveaux :

```java
// Instanciation d'une classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accède à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajoute et accède à l'Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accède au cadre de texte de l'autoshape créé
    ITextFrame text = aShp.addTextFrame("");

    // Efface le paragraphe par défaut
    text.getParagraphs().clear();

    // Ajoute le premier paragraphe
    IParagraph para1 = new Paragraph();
    para1.setText("Contenu");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Définit le niveau de puce
    para1.getParagraphFormat().setDepth((short)0);

    // Ajoute le deuxième paragraphe
    IParagraph para2 = new Paragraph();
    para2.setText("Deuxième Niveau");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Définit le niveau de puce
    para2.getParagraphFormat().setDepth((short)1);

    // Ajoute le troisième paragraphe
    IParagraph para3 = new Paragraph();
    para3.setText("Troisième Niveau");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Définit le niveau de puce
    para3.getParagraphFormat().setDepth((short)2);

    // Ajoute le quatrième paragraphe
    IParagraph para4 = new Paragraph();
    para4.setText("Quatrième Niveau");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Définit le niveau de puce
    para4.getParagraphFormat().setDepth((short)3);

    // Ajoute les paragraphes à la collection
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // Écrit la présentation sous forme de fichier PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Gérer les Paragraphes avec une Liste Numérotée Personnalisée**

L'interface [IBulletFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/) fournit la propriété [NumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) et d'autres qui vous permettent de gérer les paragraphes avec un numérotage ou un formatage personnalisé.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Accédez à la diapositive contenant le paragraphe.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) de l'autoshape.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe à travers la classe [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) et définissez [NumberedBulletStartWith](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) à 2.
7. Créez la deuxième instance de paragraphe à travers la classe `Paragraph` et définissez `NumberedBulletStartWith` à 3.
8. Créez la troisième instance de paragraphe à travers la classe `Paragraph` et définissez `NumberedBulletStartWith` à 7.
9. Ajoutez les nouveaux paragraphes à la collection de paragraphes du `TextFrame`.
10. Enregistrez la présentation modifiée.

Ce code Java vous montre comment ajouter et gérer des paragraphes avec un numérotage ou un formatage personnalisé :

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accède au cadre de texte de l'autoshape créé
    ITextFrame textFrame = shape.getTextFrame();

    // Supprime le paragraphe existant par défaut
    textFrame.getParagraphs().removeAt(0);

    // Première liste
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("puce 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("puce 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);


    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("puce 7");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)7);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);

    presentation.save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Définir le Retrait du Paragraphe**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
1. Accédez à la référence de la diapositive concernée à travers son index.
1. Ajoutez une forme rectangulaire [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) à la diapositive.
1. Ajoutez un [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) avec trois paragraphes dans la forme rectangulaire.
1. Cachez les lignes du rectangle.
1. Définissez le retrait pour chaque [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/) via leur propriété BulletOffset.
1. Écrivez la présentation modifiée sous forme de fichier PPT.

Ce code Java vous montre comment définir un retrait de paragraphe :

```java
// Instanciation de la classe Presentation
Presentation pres = new Presentation();
try {
    // Obtenir la première diapositive
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Ajouter une forme Rectangulaire
    IAutoShape rect = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);
    
    // Ajouter le TextFrame au Rectangle
    ITextFrame tf = rect.addTextFrame("Ceci est la première ligne \rCeci est la deuxième ligne \rCeci est la troisième ligne");
    
    // Ajuster le texte pour qu'il s'adapte à la forme
    tf.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    
    // Cacher les lignes du Rectangle
    rect.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    
    // Obtenir le premier Paragraphe dans le TextFrame et définir son Retrait
    IParagraph para1 = tf.getParagraphs().get_Item(0);
    // Définir le style de puce du paragraphe et le symbole
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().setAlignment(TextAlignment.Left);
    
    para1.getParagraphFormat().setDepth((short)2);
    para1.getParagraphFormat().setIndent(30);
    
    // Obtenir le deuxième Paragraphe dans le TextFrame et définir son Retrait
    IParagraph para2 = tf.getParagraphs().get_Item(1);
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar((char)8226);
    para2.getParagraphFormat().setAlignment(TextAlignment.Left);
    para2.getParagraphFormat().setDepth((short)2);
    para2.getParagraphFormat().setIndent(40);
    
    // Obtenir le troisième Paragraphe dans le TextFrame et définir son Retrait
    IParagraph para3 = tf.getParagraphs().get_Item(2);
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().setAlignment(TextAlignment.Left);
    para3.getParagraphFormat().setDepth((short)2);
    para3.getParagraphFormat().setIndent(50);
    
    // Écrire la présentation sur le disque
    pres.save("InOutDent_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir un Retrait Suspendu pour un Paragraphe**

Ce code Java vous montre comment définir le retrait suspendu pour un paragraphe :

```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 50, 250, 550, 150);

    Paragraph para1 = new Paragraph();
    para1.setText("Exemple");

    Paragraph para2 = new Paragraph();
    para2.setText("Définir le retrait suspendu pour le paragraphe");

    Paragraph para3 = new Paragraph();
    para3.setText("Ce code C# vous montre comment définir le retrait suspendu pour un paragraphe : ");

    para2.getParagraphFormat().setMarginLeft(10f);
    para3.getParagraphFormat().setMarginLeft(20f);

    autoShape.getTextFrame().getParagraphs().add(para1);
    autoShape.getTextFrame().getParagraphs().add(para2);
    autoShape.getTextFrame().getParagraphs().add(para3);

    pres.save("pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gérer les Propriétés de Fin de Portion pour le Paragraphe**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) .
1. Obtenez la référence pour la diapositive contenant le paragraphe via sa position.
1. Ajoutez une [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) rectangle à la diapositive.
1. Ajoutez un [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) avec deux paragraphes dans le rectangle.
1. Définissez la `FontHeight` et le type de police pour les paragraphes.
1. Définissez les propriétés de fin pour les paragraphes.
1. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code Java vous montre comment définir les propriétés de fin pour les paragraphes dans PowerPoint : 

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Exemple de texte"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("Exemple de texte 2"));

    PortionFormat portionFormat = new PortionFormat();
    portionFormat.setFontHeight(48);
    portionFormat.setLatinFont(new FontData("Times New Roman"));
    para2.setEndParagraphPortionFormat(portionFormat);

    shape.getTextFrame().getParagraphs().add(para1);
    shape.getTextFrame().getParagraphs().add(para2);

    pres.save(resourcesOutputPath+"pres.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Importer du Texte HTML dans des Paragraphes**

Aspose.Slides fournit un support amélioré pour importer du texte HTML dans des paragraphes.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée à travers son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iautoshape/) à la diapositive.
4. Ajoutez et accédez à `autoshape` [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/).
5. Supprimez le paragraphe par défaut dans le `ITextFrame`.
6. Lisez le fichier HTML source dans un TextReader.
7. Créez la première instance de paragraphe à travers la classe [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraph/).
8. Ajoutez le contenu du fichier HTML dans le TextReader lu à la [ParagraphCollection](https://reference.aspose.com/slides/androidjava/com.aspose.slides/paragraphcollection/) du TextFrame.
9. Enregistrez la présentation modifiée.

Ce code Java est une implémentation des étapes pour importer des textes HTML dans des paragraphes :

```java
// Créer une instance de présentation vide
Presentation pres = new Presentation();
try {
    // Accéder à la première diapositive par défaut de la présentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajouter l'AutoShape pour accueillir le contenu HTML
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Ajouter un cadre de texte à la forme
    ashape.addTextFrame("");

    // Effacer tous les paragraphes dans le cadre de texte ajouté
    ashape.getTextFrame().getParagraphs().clear();

    // Charger le fichier HTML en utilisant un lecteur de flux
    TextReader tr = new StreamReader("file.html");

    // Ajouter le texte du lecteur de flux HTML dans le cadre de texte
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Enregistrer la Présentation
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Exporter le Texte des Paragraphes vers HTML**

Aspose.Slides fournit un support amélioré pour exporter les textes (contenus dans des paragraphes) vers HTML.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) et chargez la présentation souhaitée.
2. Accédez à la référence de la diapositive concernée à travers son index.
3. Accédez à la forme contenant le texte qui sera exporté vers HTML.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe/) de la forme.
5. Créez une instance de `StreamWriter` et ajoutez le nouveau fichier HTML.
6. Fournissez un index de départ à StreamWriter et exportez vos paragraphes préférés.

Ce code Java vous montre comment exporter des textes de paragraphe PowerPoint vers HTML :

```java
// Charger le fichier de la présentation
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Accédez à la première diapositive par défaut de la présentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Index souhaité
    int index = 0;

    // Accéder à la forme ajoutée
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Créer un fichier HTML de sortie
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    // Extraire le premier paragraphe sous forme de HTML
    // Écrire les données des Paragraphes dans le HTML en fournissant l'index de départ du paragraphe, le nombre total de paragraphes à copier
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```