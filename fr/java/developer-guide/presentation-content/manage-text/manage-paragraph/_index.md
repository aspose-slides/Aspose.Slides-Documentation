---
title: Gérer les paragraphes de texte PowerPoint en Java
linktitle: Gérer le paragraphe
type: docs
weight: 40
url: /fr/java/manage-paragraph/
aliases:
  - /java/paragraph/
  - /java/portion/
keywords:
  - ajouter du texte
  - ajouter un paragraphe
  - gérer le texte
  - gérer le paragraphe
  - gérer les puces
  - alinéa de paragraphe
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
  - Java
  - Aspose.Slides
description: "Maîtrisez la mise en forme des paragraphes avec Aspose.Slides pour Java - optimisez l'alignement, l'espacement et le style dans les présentations PPT, PPTX et ODP en Java."
---
## **Introduction**

Aspose.Slides fournit toutes les interfaces et classes nécessaires pour travailler avec les textes, paragraphes et portions de PowerPoint en Java.

* Aspose.Slides fournit l'interface [ITextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/) permettant d'ajouter des objets représentant un paragraphe. Un objet `ITextFame` peut contenir un ou plusieurs paragraphes (chaque paragraphe est créé par un retour chariot).
* Aspose.Slides fournit l'interface [IParagraph](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraph/) permettant d'ajouter des objets représentant des portions. Un objet `IParagraph` peut contenir une ou plusieurs portions (collection d'objets iPortions).
* Aspose.Slides fournit l'interface [IPortion](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iportion/) permettant d'ajouter des objets représentant des textes et leurs propriétés de mise en forme.

Un objet `IParagraph` peut gérer des textes avec différentes propriétés de mise en forme grâce à ses objets sous-jacents `IPortion`.

## **Ajouter plusieurs paragraphes contenant plusieurs portions**

Ces étapes vous montrent comment ajouter un cadre de texte contenant 3 paragraphes, chaque paragraphe contenant 3 portions :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée via son index.
3. Ajoutez un rectangle [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/) à la diapositive.
4. Obtenez le ITextFrame associé au [IAutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/).
5. Créez deux objets [IParagraph](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraph/) et ajoutez-les à la collection `IParagraphs` du [ITextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/).
6. Créez trois objets [IPortion](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iportion/) pour chaque nouveau `IParagraph` (deux objets Portion pour le paragraphe par défaut) et ajoutez chaque objet `IPortion` à la collection IPortion de chaque `IParagraph`.
7. Définissez un texte pour chaque portion.
8. Appliquez les caractéristiques de mise en forme souhaitées à chaque portion en utilisant les propriétés de mise en forme exposées par l'objet `IPortion`.
9. Enregistrez la présentation modifiée.

Ce code Java est une implémentation des étapes d'ajout de paragraphes contenant des portions :

```java
// Instancier une classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accéder à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajouter une AutoShape de type Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Accéder au TextFrame de l'AutoShape
    ITextFrame tf = ashp.getTextFrame();

    // Créer des Paragraphes et des Portions avec différents formats de texte
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

## **Gestion des puces de paragraphe**

Les listes à puces vous aident à organiser et présenter les informations rapidement et efficacement. Les paragraphes à puces sont toujours plus faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée via son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/) à la diapositive sélectionnée.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/) de l'autoshape.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/fr/java/com.aspose.slides/paragraph/).
7. Définissez le `Type` de puce du paragraphe sur `Symbol` et définissez le caractère de puce.
8. Définissez le `Text` du paragraphe.
9. Définissez l'`Indent` du paragraphe pour la puce.
10. Définissez une couleur pour la puce.
11. Définissez une hauteur pour la puce.
12. Ajoutez le nouveau paragraphe à la collection de paragraphes du `TextFrame`.
13. Ajoutez le deuxième paragraphe et répétez le processus indiqué aux étapes 7 à 13.
14. Enregistrez la présentation.

Ce code Java montre comment ajouter une puce à un paragraphe :

```java
// Instancie une classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accède à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajoute et accède à l'Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accède au cadre de texte de l'autoshape
    ITextFrame txtFrm = aShp.getTextFrame();

    // Supprime le paragraphe par défaut
    txtFrm.getParagraphs().removeAt(0);

    // Crée un paragraphe
    Paragraph para = new Paragraph();

    // Définit le style de puce du paragraphe et le symbole
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // Définit le texte du paragraphe
    para.setText("Welcome to Aspose.Slides");

    // Définit l'alinéa de la puce
    para.getParagraphFormat().setIndent(25);

    // Définit la couleur de la puce
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // définir IsBulletHardColor à true pour utiliser sa propre couleur de puce

    // Définit la hauteur de la puce
    para.getParagraphFormat().getBullet().setHeight(100);

    // Ajoute le paragraphe au cadre de texte
    txtFrm.getParagraphs().add(para);

    // Crée un deuxième paragraphe
    Paragraph para2 = new Paragraph();

    // Définit le type et le style de puce du paragraphe
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Ajoute le texte du paragraphe
    para2.setText("This is numbered bullet");

    // Définit l'alinéa de la puce
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // définir IsBulletHardColor à true pour utiliser sa propre couleur de puce

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

## **Gestion des puces d’image**

Les listes à puces vous aident à organiser et présenter les informations rapidement et efficacement. Les paragraphes d'image sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée via son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/) à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/) de l'autoshape.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/fr/java/com.aspose.slides/paragraph/).
7. Chargez l'image dans [IPPImage](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ippimage/).
8. Définissez le type de puce sur [Picture](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ippimage/) et attribuez l'image.
9. Définissez le `Text` du paragraphe.
10. Définissez l'`Indent` du paragraphe pour la puce.
11. Définissez une couleur pour la puce.
12. Définissez une hauteur pour la puce.
13. Ajoutez le nouveau paragraphe à la collection de paragraphes du `TextFrame`.
14. Ajoutez le deuxième paragraphe et répétez le processus basé sur les étapes précédentes.
15. Enregistrez la présentation modifiée.

```java
// Instancie une classe Presentation qui représente un fichier PPTX
Presentation presentation = new Presentation();
try {
    // Accède à la première diapositive
    ISlide slide = presentation.getSlides().get_Item(0);

    // Instancie l'image pour les puces
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Ajoute et accède à l'Autoshape
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accède au cadre de texte de l'autoshape
    ITextFrame textFrame = autoShape.getTextFrame();

    // Supprime le paragraphe par défaut
    textFrame.getParagraphs().removeAt(0);

    // Crée un nouveau paragraphe
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Welcome to Aspose.Slides");

    // Définit le style de puce du paragraphe et l'image
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Définit la hauteur de la puce
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // Ajoute le paragraphe au cadre de texte
    textFrame.getParagraphs().add(paragraph);

    // Enregistre la présentation au format PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // Enregistre la présentation au format PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Gestion des puces à plusieurs niveaux**

Les listes à puces vous aident à organiser et présenter les informations rapidement et efficacement. Les puces à plusieurs niveaux sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée via son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/) dans la nouvelle diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/) de l'autoshape.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/fr/java/com.aspose.slides/paragraph/) et définissez la profondeur à 0.
7. Créez la deuxième instance de paragraphe via la classe `Paragraph` et définissez la profondeur à 1.
8. Créez la troisième instance de paragraphe via la classe `Paragraph` et définissez la profondeur à 2.
9. Créez la quatrième instance de paragraphe via la classe `Paragraph` et définissez la profondeur à 3.
10. Ajoutez les nouveaux paragraphes à la collection de paragraphes du `TextFrame`.
11. Enregistrez la présentation modifiée.

```java
// Instancie une classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accède à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajoute et accède à l'Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accède au cadre de texte de l'autoshape créée
    ITextFrame text = aShp.addTextFrame("");

    // Efface le paragraphe par défaut
    text.getParagraphs().clear();

    // Ajoute le premier paragraphe
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Définit le niveau de la puce
    para1.getParagraphFormat().setDepth((short)0);

    // Ajoute le deuxième paragraphe
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Définit le niveau de la puce
    para2.getParagraphFormat().setDepth((short)1);

    // Ajoute le troisième paragraphe
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Définit le niveau de la puce
    para3.getParagraphFormat().setDepth((short)2);

    // Ajoute le quatrième paragraphe
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Définit le niveau de la puce
    para4.getParagraphFormat().setDepth((short)3);

    // Ajoute les paragraphes à la collection
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // Enregistre la présentation au format PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Gérer un paragraphe avec une liste numérotée personnalisée**

L'interface [IBulletFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibulletformat/) fournit la propriété [NumberedBulletStartWith](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) et d'autres qui vous permettent de gérer des paragraphes avec une numérotation ou une mise en forme personnalisée.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
2. Accédez à la diapositive contenant le paragraphe.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/) à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/) de l'autoshape.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/fr/java/com.aspose.slides/paragraph/) et définissez [NumberedBulletStartWith](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) à 2.
7. Créez la deuxième instance de paragraphe via la classe `Paragraph` et définissez `NumberedBulletStartWith` à 3.
8. Créez la troisième instance de paragraphe via la classe `Paragraph` et définissez `NumberedBulletStartWith` à 7.
9. Ajoutez les nouveaux paragraphes à la collection de paragraphes du `TextFrame`.
10. Enregistrez la présentation modifiée.

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accède au cadre de texte de l'autoshape créé
    ITextFrame textFrame = shape.getTextFrame();

    // Supprime le paragraphe par défaut existant
    textFrame.getParagraphs().removeAt(0);

    // Première liste
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph2);


    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("bullet 7");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)7);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    textFrame.getParagraphs().add(paragraph5);

    presentation.save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Définir l'alinéa de première ligne pour un paragraphe**

Utilisez la méthode [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#setIndent-float-) pour contrôler l'alinéa de première ligne d'un paragraphe. Cette méthode déplace uniquement la première ligne par rapport à la marge gauche du paragraphe. Une valeur positive décale la première ligne vers la droite, tandis que les lignes restantes restent alignées au corps du paragraphe.

Utilisez [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) lorsque vous devez déplacer l'ensemble du paragraphe. Utilisez [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#setIndent-float-) lorsque vous devez déplacer uniquement la première ligne.

L'exemple ci‑dessous crée plusieurs paragraphes et applique différentes valeurs d'alinéa afin de montrer comment l'alinéa de première ligne affecte la mise en page du paragraphe.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
2. Accédez à la diapositive cible.
3. Ajoutez un [AutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/autoshape/) rectangulaire à la diapositive.
4. Ajoutez un [TextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/textframe/) vide à la forme et supprimez le paragraphe par défaut.
5. Créez plusieurs paragraphes et définissez différentes valeurs d'[Indent](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#setIndent-float-) pour chacun.
6. Ajoutez les paragraphes au cadre de texte.
7. Enregistrez la présentation modifiée.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("No first-line indent. Wrapped lines start at the same position as the first line.");
    firstParagraph.getParagraphFormat().setMarginLeft(20f);
    firstParagraph.getParagraphFormat().setIndent(0f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
    secondParagraph.getParagraphFormat().setMarginLeft(20f);
    secondParagraph.getParagraphFormat().setIndent(20f);

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    thirdParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    thirdParagraph.setText("First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
    thirdParagraph.getParagraphFormat().setMarginLeft(20f);
    thirdParagraph.getParagraphFormat().setIndent(40f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);
    textFrame.getParagraphs().add(thirdParagraph);

    presentation.save("paragraph_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Le résultat :

![L'alinéa de première ligne des paragraphes](first_line_indent.png)

## **Définir un alinéa suspendu pour un paragraphe**

Un alinéa suspendu est une mise en page de paragraphe où la première ligne débute à gauche des lignes restantes. Dans Aspose.Slides, vous créez cet effet avec la méthode [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#setIndent-float-). Définissez l'alinéa à une valeur négative pour déplacer la première ligne vers la gauche par rapport au corps du paragraphe.

En pratique, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) définit la position gauche du corps du paragraphe, et [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#setIndent-float-) définit la position de la première ligne par rapport à cette marge. Pour créer un alinéa suspendu, définissez une valeur positive pour `MarginLeft` et une valeur négative pour `Indent`.

Cette mise en forme est utile pour les bibliographies, références, entrées de glossaire et autres paragraphes où les lignes renvoyées doivent s'aligner sous le corps du paragraphe plutôt que sous le premier caractère de la première ligne.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
2. Accédez à la diapositive cible.
3. Ajoutez un [AutoShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/autoshape/) rectangulaire à la diapositive.
4. Ajoutez un [TextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/textframe/) vide à la forme et supprimez le paragraphe par défaut.
5. Créez des paragraphes et définissez une valeur positive pour [MarginLeft](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) pour chaque paragraphe.
6. Définissez une valeur négative pour [Indent](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraphformat/#setIndent-float-) afin de créer l'effet d'alinéa suspendu.
7. Ajoutez les paragraphes au cadre de texte.
8. Enregistrez la présentation modifiée.

```java
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape rectangleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.getFillFormat().setFillType(FillType.NoFill);
    rectangleShape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    rectangleShape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.GRAY);

    ITextFrame textFrame = rectangleShape.addTextFrame("");
    textFrame.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    textFrame.getParagraphs().removeAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    firstParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    firstParagraph.setText("A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
    firstParagraph.getParagraphFormat().setMarginLeft(40f);
    firstParagraph.getParagraphFormat().setIndent(-20f);

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    secondParagraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    secondParagraph.setText("This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
    secondParagraph.getParagraphFormat().setMarginLeft(60f);
    secondParagraph.getParagraphFormat().setIndent(-30f);

    textFrame.getParagraphs().add(firstParagraph);
    textFrame.getParagraphs().add(secondParagraph);

    presentation.save("hanging_indent.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

Le résultat :

![L'alinéa suspendu des paragraphes](hanging_indent.png)

## **Gérer les propriétés de fin de paragraphe**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
2. Obtenez la référence de la diapositive contenant le paragraphe via sa position.
3. Ajoutez un rectangle [autoshape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/) à la diapositive.
4. Ajoutez un [TextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/) contenant deux paragraphes au rectangle.
5. Définissez le `FontHeight` et le type de police pour les paragraphes.
6. Définissez les propriétés End pour les paragraphes.
7. Enregistrez la présentation modifiée en tant que fichier PPTX.

Ce code Java montre comment définir les propriétés End pour les paragraphes dans PowerPoint :

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Sample text"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("Sample text 2"));

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

## **Importer du texte HTML dans les paragraphes**

Aspose.Slides offre une prise en charge améliorée de l'importation de texte HTML dans les paragraphes.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée via son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iautoshape/) à la diapositive.
4. Ajoutez et accédez à l'`autoshape` [ITextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/itextframe/).
5. Supprimez le paragraphe par défaut dans le `ITextFrame`.
6. Lisez le fichier HTML source dans un TextReader.
7. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/fr/java/com.aspose.slides/paragraph/).
8. Ajoutez le contenu du fichier HTML lu par le TextReader à la [ParagraphCollection](https://reference.aspose.com/slides/fr/java/com.aspose.slides/paragraphcollection/) du TextFrame.
9. Enregistrez la présentation modifiée.

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

    // Enregistrer la présentation
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Exporter le texte d'un paragraphe vers HTML**

Aspose.Slides offre une prise en charge améliorée de l'exportation de textes (contenus dans des paragraphes) vers HTML.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/) et chargez la présentation souhaitée.
2. Accédez à la référence de la diapositive concernée via son index.
3. Accédez à la forme contenant le texte qui sera exporté en HTML.
4. Accédez à la [TextFrame](https://reference.aspose.com/slides/fr/java/com.aspose.slides/textframe/) de la forme.
5. Créez une instance de `StreamWriter` et ajoutez le nouveau fichier HTML.
6. Fournissez un index de départ à StreamWriter et exportez les paragraphes souhaités.

```java
// Charger le fichier de présentation
Presentation pres = new Presentation("ExportingHTMLText.pptx");
try {
    // Accéder à la première diapositive par défaut de la présentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Index souhaité
    int index = 0;

    // Accéder à la forme ajoutée
    IAutoShape ashape = (IAutoShape) slide.getShapes().get_Item(index);

    // Créer le fichier HTML de sortie
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    //Extraction du premier paragraphe en HTML
    // Écrire les données des paragraphes en HTML en fournissant l'index de départ du paragraphe, le nombre total de paragraphes à copier
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Enregistrer un paragraphe sous forme d'image**

Dans cette section, nous explorerons deux exemples montrant comment enregistrer un paragraphe de texte, représenté par l'interface [IParagraph](https://reference.aspose.com/slides/fr/java/com.aspose.slides/iparagraph/) , sous forme d'image. Les deux exemples comprennent l'obtention de l'image d'une forme contenant le paragraphe à l'aide des méthodes `getImage` de l'interface [IShape](https://reference.aspose.com/slides/fr/java/com.aspose.slides/ishape/) , le calcul des limites du paragraphe à l'intérieur de la forme, et son exportation en tant qu'image bitmap. Ces approches vous permettent d'extraire des parties spécifiques du texte des présentations PowerPoint et de les enregistrer en tant qu'images distinctes, ce qui peut être utile dans divers scénarios.

Supposons que nous disposions d'un fichier de présentation nommé sample.pptx contenant une diapositive, où la première forme est une zone de texte contenant trois paragraphes.

![La zone de texte avec trois paragraphes](paragraph_to_image_input.png)

**Exemple 1**

Dans cet exemple, nous obtenons le deuxième paragraphe sous forme d'image. Pour ce faire, nous extrayons l'image de la forme de la première diapositive de la présentation, puis calculons les limites du deuxième paragraphe dans le cadre de texte de la forme. Le paragraphe est ensuite redessiné sur une nouvelle image bitmap, qui est enregistrée au format PNG. Cette méthode est particulièrement utile lorsque vous devez enregistrer un paragraphe spécifique en tant qu'image séparée tout en conservant les dimensions et la mise en forme exactes du texte.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Enregistrer la forme en mémoire sous forme de bitmap.
    IImage shapeImage = firstShape.getImage();
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Créer un bitmap de forme à partir de la mémoire.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Calculer les limites du deuxième paragraphe.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();

    // Calculer les coordonnées et la taille de l'image de sortie (taille minimale - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // Recadrer le bitmap de la forme pour ne garder que le bitmap du paragraphe.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

Le résultat :

![L'image du paragraphe](paragraph_to_image_output.png)

**Exemple 2**

Dans cet exemple, nous étendons l'approche précédente en ajoutant des facteurs d'échelle à l'image du paragraphe. La forme est extraite de la présentation et enregistrée en tant qu'image avec un facteur d'échelle de `2`. Cela permet d'obtenir une sortie en haute résolution lors de l'exportation du paragraphe. Les limites du paragraphe sont alors calculées en tenant compte de l'échelle. Le redimensionnement peut être particulièrement utile lorsqu'une image plus détaillée est nécessaire, par exemple pour une utilisation dans des documents imprimés de haute qualité.

```java
float imageScaleX = 2f;
float imageScaleY = imageScaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    IAutoShape firstShape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);

    // Enregistrer la forme en mémoire sous forme de bitmap avec mise à l'échelle.
    IImage shapeImage = firstShape.getImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
    ByteArrayOutputStream shapeImageStream = new ByteArrayOutputStream();
    shapeImage.save(shapeImageStream, ImageFormat.Png);
    shapeImage.dispose();

    // Créer un bitmap de forme à partir de la mémoire.
    InputStream shapeImageInputStream = new ByteArrayInputStream(shapeImageStream.toByteArray());
    BufferedImage shapeBitmap = ImageIO.read(shapeImageInputStream);

    // Calculer les limites du deuxième paragraphe.
    IParagraph secondParagraph = firstShape.getTextFrame().getParagraphs().get_Item(1);
    Rectangle2D paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.setRect(
            paragraphRectangle.getX() * imageScaleX,
            paragraphRectangle.getY() * imageScaleY,
            paragraphRectangle.getWidth() * imageScaleX,
            paragraphRectangle.getHeight() * imageScaleY
    );

    // Calculer les coordonnées et la taille de l'image de sortie (taille minimale - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.getX());
    int imageY = (int) Math.floor(paragraphRectangle.getY());
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.getWidth()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.getHeight()));

    // Recadrer le bitmap de la forme pour ne garder que le bitmap du paragraphe.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Puis-je désactiver complètement le retour à la ligne à l'intérieur d'un cadre de texte ?**

Oui. Utilisez le paramètre de retour à la ligne du cadre de texte ([setWrapText](https://reference.aspose.com/slides/fr/java/com.aspose.slides/textframeformat/#setWrapText-byte-)) pour désactiver le retour à la ligne afin que les lignes ne se coupent pas aux bords du cadre.

**Comment obtenir les limites exactes sur la diapositive d'un paragraphe spécifique ?**

Vous pouvez récupérer le rectangle englobant du paragraphe (et même d'une seule portion) pour connaître sa position et sa taille précises sur la diapositive.

**Où la justification du paragraphe (gauche/droite/centré/justifié) est‑elle contrôlée ?**

[Alignment](https://reference.aspose.com/slides/fr/java/com.aspose.slides/paragraphformat/#setAlignment-int-) est un paramètre au niveau du paragraphe dans [ParagraphFormat](https://reference.aspose.com/slides/fr/java/com.aspose.slides/paragraphformat/) ; il s'applique à l'ensemble du paragraphe, indépendamment de la mise en forme des portions individuelles.

**Puis‑je définir une langue de vérification orthographique pour une partie seulement d'un paragraphe (par exemple, un mot) ?**

Oui. La langue est définie au niveau de la portion ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/fr/java/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)), de sorte que plusieurs langues peuvent coexister dans un même paragraphe.