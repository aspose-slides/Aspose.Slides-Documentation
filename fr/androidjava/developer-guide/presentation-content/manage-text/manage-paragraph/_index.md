---
title: Gérer les paragraphes de texte PowerPoint sur Android
linktitle: Gérer le paragraphe
type: docs
weight: 40
url: /fr/androidjava/manage-paragraph/
keywords:
- ajouter du texte
- ajouter un paragraphe
- gérer le texte
- gérer le paragraphe
- gérer les puces
- retrait de paragraphe
- retrait suspendu
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
- Android
- Java
- Aspose.Slides
description: "Maîtrisez la mise en forme des paragraphes avec Aspose.Slides pour Android - optimisez l'alignement, l'espacement et le style dans les présentations PPT, PPTX et ODP en Java."
---
Aspose.Slides fournit toutes les interfaces et classes nécessaires pour travailler avec les textes, paragraphes et portions PowerPoint en Java.

* Aspose.Slides fournit l’interface [ITextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/) pour vous permettre d’ajouter des objets représentant un paragraphe. Un objet `ITextFame` peut contenir un ou plusieurs paragraphes (chaque paragraphe est créé par un retour chariot).
* Aspose.Slides fournit l’interface [IParagraph](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraph/) pour vous permettre d’ajouter des objets représentant des portions. Un objet `IParagraph` peut contenir une ou plusieurs portions (collection d’objets iPortions).
* Aspose.Slides fournit l’interface [IPortion](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iportion/) pour vous permettre d’ajouter des objets représentant des textes et leurs propriétés de mise en forme.

Un objet `IParagraph` peut gérer des textes avec des propriétés de mise en forme différentes grâce à ses objets sous‑jacents `IPortion`.

## **Ajouter plusieurs paragraphes contenant plusieurs portions de texte**

Ces étapes montrent comment ajouter un cadre de texte contenant 3 paragraphes, chaque paragraphe contenant 3 portions :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée par son index.
3. Ajoutez un rectangle [IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) à la diapositive.
4. Récupérez le ITextFrame associé à l’[IAutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/).
5. Créez deux objets [IParagraph](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraph/) et ajoutez‑les à la collection `IParagraphs` du [ITextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/).
6. Créez trois objets [IPortion](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iportion/) pour chaque nouveau `IParagraph` (deux objets Portion pour le paragraphe par défaut) et ajoutez chaque objet `IPortion` à la collection IPortion de chaque `IParagraph`.
7. Définissez du texte pour chaque portion.
8. Appliquez les fonctionnalités de mise en forme souhaitées à chaque portion en utilisant les propriétés exposées par l’objet `IPortion`.
9. Enregistrez la présentation modifiée.

Ce code Java met en œuvre les étapes pour ajouter des paragraphes contenant des portions :

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

    // Écrire le PPTX sur le disque
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Gérer les puces de paragraphe**

Les listes à puces vous aident à organiser et présenter l’information rapidement et efficacement. Les paragraphes à puces sont toujours plus faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée par son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) à la diapositive sélectionnée.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/) de l’autoshape.
5. Supprimez le paragraphe par défaut du `TextFrame`.
6. Créez la première instance de paragraphe à l’aide de la classe [Paragraph](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/paragraph/).
7. Définissez le `Type` de puce du paragraphe sur `Symbol` et indiquez le caractère de puce.
8. Définissez le `Text` du paragraphe.
9. Définissez l’`Indent` du paragraphe pour la puce.
10. Attribuez une couleur à la puce.
11. Définissez une hauteur pour la puce.
12. Ajoutez le nouveau paragraphe à la collection de paragraphes du `TextFrame`.
13. Ajoutez le deuxième paragraphe et répétez le processus indiqué aux étapes 7 à 13.
14. Enregistrez la présentation.

Ce code Java montre comment ajouter une puce de paragraphe :

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

    // Définit le retrait de la puce
    para.getParagraphFormat().setIndent(25);

    // Définit la couleur de la puce
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // définir IsBulletHardColor à true pour utiliser une couleur de puce personnalisée

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
    para2.setText("This is numbered bullet");

    // Définit le retrait de la puce
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // définir IsBulletHardColor à true pour utiliser une couleur de puce personnalisée

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


## **Gérer les puces d’image**

Les listes à puces vous aident à organiser et présenter l’information rapidement et efficacement. Les paragraphes à image sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée par son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/) de l’autoshape.
5. Supprimez le paragraphe par défaut du `TextFrame`.
6. Créez la première instance de paragraphe à l’aide de la classe [Paragraph](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/paragraph/).
7. Chargez l’image dans [IPPImage](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ippimage/).
8. Définissez le type de puce sur [Picture](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ippimage/) et indiquez l’image.
9. Définissez le `Text` du paragraphe.
10. Définissez l’`Indent` du paragraphe pour la puce.
11. Attribuez une couleur à la puce.
12. Définissez une hauteur pour la puce.
13. Ajoutez le nouveau paragraphe à la collection de paragraphes du `TextFrame`.
14. Ajoutez le deuxième paragraphe et répétez le processus en suivant les étapes précédentes.
15. Enregistrez la présentation modifiée.

Ce code Java montre comment ajouter et gérer des puces d’image :

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

    // Enregistre la présentation en tant que fichier PPTX
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // Enregistre la présentation en tant que fichier PPT
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Gérer les puces à plusieurs niveaux**

Les listes à puces vous aident à organiser et présenter l’information rapidement et efficacement. Les puces à plusieurs niveaux sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée par son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) dans la nouvelle diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/) de l’autoshape.
5. Supprimez le paragraphe par défaut du `TextFrame`.
6. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/paragraph/) et définissez la profondeur à 0.
7. Créez la seconde instance de paragraphe via la classe `Paragraph` et définissez la profondeur à 1.
8. Créez la troisième instance de paragraphe via la classe `Paragraph` et définissez la profondeur à 2.
9. Créez la quatrième instance de paragraphe via la classe `Paragraph` et définissez la profondeur à 3.
10. Ajoutez les nouveaux paragraphes à la collection de paragraphes du `TextFrame`.
11. Enregistrez la présentation modifiée.

Ce code Java montre comment ajouter et gérer des puces à plusieurs niveaux :

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

    // Supprime le paragraphe par défaut
    text.getParagraphs().clear();

    // Ajoute le premier paragraphe
    IParagraph para1 = new Paragraph();
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Définit le niveau de puce
    para1.getParagraphFormat().setDepth((short)0);

    // Ajoute le deuxième paragraphe
    IParagraph para2 = new Paragraph();
    para2.setText("Second Level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Définit le niveau de puce
    para2.getParagraphFormat().setDepth((short)1);

    // Ajoute le troisième paragraphe
    IParagraph para3 = new Paragraph();
    para3.setText("Third Level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Définit le niveau de puce
    para3.getParagraphFormat().setDepth((short)2);

    // Ajoute le quatrième paragraphe
    IParagraph para4 = new Paragraph();
    para4.setText("Fourth Level");
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

    // Enregistre la présentation au format PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Gérer un paragraphe avec une liste numérotée personnalisée**

L’interface [IBulletFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibulletformat/) fournit la propriété [NumberedBulletStartWith](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) et d’autres qui permettent de gérer les paragraphes avec une numérotation ou une mise en forme personnalisée.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/).
2. Accédez à la diapositive contenant le paragraphe.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/) de l’autoshape.
5. Supprimez le paragraphe par défaut du `TextFrame`.
6. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/paragraph/) et définissez [NumberedBulletStartWith](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) à 2.
7. Créez la seconde instance de paragraphe via la classe `Paragraph` et définissez `NumberedBulletStartWith` à 3.
8. Créez la troisième instance de paragraphe via la classe `Paragraph` et définissez `NumberedBulletStartWith` à 7.
9. Ajoutez les nouveaux paragraphes à la collection de paragraphes du `TextFrame`.
10. Enregistrez la présentation modifiée.

Ce code Java montre comment ajouter et gérer des paragraphes avec une numérotation ou une mise en forme personnalisée :

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accède au cadre de texte de l'autoshape créée
    ITextFrame textFrame = shape.getTextFrame();

    // Supprime le paragraphe existant par défaut
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

## **Définir l’indent de première ligne d’un paragraphe**

Utilisez la méthode [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) pour contrôler l’indent de la première ligne d’un paragraphe. Cette méthode ne déplace que la première ligne par rapport à la marge gauche du paragraphe. Une valeur positive décale la première ligne vers la droite, tandis que les lignes restantes restent alignées avec le corps du paragraphe.

Utilisez [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) lorsque vous devez déplacer tout le paragraphe. Utilisez [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) lorsque vous ne devez déplacer que la première ligne.

L’exemple ci‑dessous crée plusieurs paragraphes et applique différentes valeurs d’indent pour illustrer l’impact de l’indent de première ligne sur la mise en page.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/).
2. Accédez à la diapositive cible.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/autoshape/) rectangulaire à la diapositive.
4. Ajoutez un [TextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/textframe/) vide à la forme et supprimez le paragraphe par défaut.
5. Créez plusieurs paragraphes et définissez des valeurs différentes d’[Indent](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) pour chacun d’eux.
6. Ajoutez les paragraphes au cadre de texte.
7. Enregistrez la présentation modifiée.

Ce code montre comment définir un indent de paragraphe :

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

![The first-line indent of the paragraphs](first_line_indent.png)

## **Définir un retrait suspendu pour un paragraphe**

Un retrait suspendu est une mise en page dans laquelle la première ligne commence à gauche des lignes suivantes. Dans Aspose.Slides, vous créez cet effet avec la méthode [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-). Définissez l’indent sur une valeur négative pour déplacer la première ligne vers la gauche par rapport au corps du paragraphe.

En pratique, [IParagraphFormat.setMarginLeft](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) définit la position gauche du corps du paragraphe, et [IParagraphFormat.setIndent](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) définit la position de la première ligne par rapport à cette marge. Pour créer un retrait suspendu, attribuez une valeur positive à `MarginLeft` et une valeur négative à `Indent`.

Ce type de mise en forme est utile pour les bibliographies, références, entrées de glossaire et autres paragraphes où les lignes renvoyées doivent s’aligner sous le corps du paragraphe plutôt que sous le premier caractère de la première ligne.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/).
2. Accédez à la diapositive cible.
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/autoshape/) rectangulaire à la diapositive.
4. Ajoutez un [TextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/textframe/) vide à la forme et supprimez le paragraphe par défaut.
5. Créez des paragraphes et définissez une valeur positive de [MarginLeft](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setMarginLeft-float-) pour chaque paragraphe.
6. Définissez une valeur négative d’[Indent](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraphformat/#setIndent-float-) pour obtenir l’effet de retrait suspendu.
7. Ajoutez les paragraphes au cadre de texte.
8. Enregistrez la présentation modifiée.

Ce code montre comment définir un retrait suspendu pour un paragraphe :

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

![The hanging indent of the paragraphs](hanging_indent.png)

## **Gérer les propriétés d’exécution de fin de paragraphe**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/).
1. Obtenez la référence de la diapositive contenant le paragraphe via sa position.
1. Ajoutez une [autoshape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) rectangulaire à la diapositive.
1. Ajoutez un [TextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/) contenant deux paragraphes au rectangle.
1. Définissez la `FontHeight` et le type de police pour les paragraphes.
1. Définissez les propriétés de fin pour les paragraphes.
1. Enregistrez la présentation modifiée au format PPTX.

Ce code Java montre comment définir les propriétés de fin pour les paragraphes dans PowerPoint :

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


## **Importer du texte HTML dans des paragraphes**

Aspose.Slides propose une prise en charge améliorée de l’importation de texte HTML dans les paragraphes.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/).
2. Accédez à la référence de la diapositive concernée par son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iautoshape/) à la diapositive.
4. Ajoutez et accédez à l’[ITextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/itextframe/) de l’autoshape.
5. Supprimez le paragraphe par défaut du `ITextFrame`.
6. Lisez le fichier HTML source dans un `TextReader`.
7. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/paragraph/).
8. Ajoutez le contenu du fichier HTML lu par le `TextReader` à la [ParagraphCollection](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/paragraphcollection/) du `TextFrame`.
9. Enregistrez la présentation modifiée.

Ce code Java implémente les étapes d’importation de textes HTML dans des paragraphes :

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

    // Effacer tous les paragraphes du cadre de texte ajouté
    ashape.getTextFrame().getParagraphs().clear();

    // Charger le fichier HTML à l'aide d'un lecteur de flux
    TextReader tr = new StreamReader("file.html");

    // Ajouter le texte du lecteur de flux HTML dans le cadre de texte
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Enregistrer la présentation
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Exporter le texte d’un paragraphe vers HTML**

Aspose.Slides propose une prise en charge améliorée de l’exportation de textes (contenus dans les paragraphes) vers HTML.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) et chargez la présentation souhaitée.
2. Accédez à la référence de la diapositive concernée par son index.
3. Accédez à la forme contenant le texte qui sera exporté en HTML.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/textframe/) de la forme.
5. Créez une instance de `StreamWriter` et ajoutez le nouveau fichier HTML.
6. Fournissez un indice de départ à `StreamWriter` et exportez les paragraphes souhaités.

Ce code Java montre comment exporter les textes de paragraphes PowerPoint vers HTML :

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

    //Extraire le premier paragraphe en HTML
    // Écrire les données des paragraphes en HTML en fournissant l'index de départ du paragraphe, le nombre total de paragraphes à copier
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Enregistrer un paragraphe sous forme d’image**

Dans cette section, nous explorerons deux exemples démontrant comment enregistrer un paragraphe de texte, représenté par l’interface [IParagraph](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/iparagraph/), sous forme d’image. Les deux exemples incluent l’obtention de l’image d’une forme contenant le paragraphe à l’aide des méthodes `getImage` de l’interface [IShape](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/ishape/), le calcul des limites du paragraphe dans la forme, puis son exportation en image bitmap. Ces approches permettent d’extraire des parties spécifiques du texte de présentations PowerPoint et de les sauvegarder comme images séparées, ce qui peut être utile dans divers scénarios.

Supposons que nous disposions d’un fichier de présentation nommé **sample.pptx** contenant une diapositive, dont la première forme est une zone de texte contenant trois paragraphes.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Exemple 1**

Dans cet exemple, nous obtenons le deuxième paragraphe sous forme d’image. Pour cela, nous extrayons l’image de la forme de la première diapositive de la présentation, puis calculons les limites du deuxième paragraphe dans le cadre de texte de la forme. Le paragraphe est ensuite redessiné sur une nouvelle image bitmap, enregistrée au format PNG. Cette méthode est particulièrement utile lorsqu’il faut enregistrer un paragraphe spécifique en tant qu’image distincte tout en conservant ses dimensions et sa mise en forme exactes.

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
    RectF paragraphRectangle = secondParagraph.getRect();

    // Calculer les coordonnées et la taille de l'image de sortie (taille minimale - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // Recadrer le bitmap de la forme pour obtenir uniquement le bitmap du paragraphe.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

Le résultat :

![The paragraph image](paragraph_to_image_output.png)

**Exemple 2**

Dans cet exemple, nous étendons l’approche précédente en ajoutant des facteurs d’échelle à l’image du paragraphe. La forme est extraite de la présentation et enregistrée sous forme d’image avec un facteur d’échelle de `2`. Cela permet d’obtenir une sortie à plus haute résolution lors de l’exportation du paragraphe. Les limites du paragraphe sont alors calculées en tenant compte de l’échelle. Le redimensionnement est particulièrement utile lorsqu’une image plus détaillée est requise, par exemple pour des matériaux imprimés de haute qualité.

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
    RectF paragraphRectangle = secondParagraph.getRect();
    paragraphRectangle.set(
            paragraphRectangle.left * imageScaleX,
            paragraphRectangle.top * imageScaleY,
            paragraphRectangle.right * imageScaleX,
            paragraphRectangle.bottom * imageScaleY
    );

    // Calculer les coordonnées et la taille de l'image de sortie (taille minimale - 1x1 pixel).
    int imageX = (int) Math.floor(paragraphRectangle.left);
    int imageY = (int) Math.floor(paragraphRectangle.top);
    int imageWidth = Math.max(1, (int) Math.ceil(paragraphRectangle.width()));
    int imageHeight = Math.max(1, (int) Math.ceil(paragraphRectangle.height()));

    // Recadrer le bitmap de la forme pour obtenir uniquement le bitmap du paragraphe.
    BufferedImage paragraphBitmap = shapeBitmap.getSubimage(imageX, imageY, imageWidth, imageHeight);

    ImageIO.write(paragraphBitmap, "png", new File("paragraph.png"));
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**Puis‑je désactiver complètement le retour à la ligne dans un cadre de texte ?**

Oui. Utilisez le paramètre de retour à la ligne du cadre de texte ([setWrapText](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/textframeformat/#setWrapText-byte-)) pour désactiver le retour à la ligne afin que les lignes ne se coupent pas aux bords du cadre.

**Comment obtenir les limites exactes d’un paragraphe spécifique sur la diapositive ?**

Vous pouvez récupérer le rectangle englobant du paragraphe (et même d’une seule portion) pour connaître sa position et sa taille précises sur la diapositive.

**Où se contrôle l’alignement du paragraphe (gauche/droite/centré/justifié) ?**

[Alignment](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/paragraphformat/#setAlignment-int-) est un paramètre au niveau du paragraphe dans [ParagraphFormat](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/paragraphformat/); il s’applique à l’ensemble du paragraphe indépendamment du formatage des portions individuelles.

**Puis‑je définir une langue de vérification orthographique pour une partie seulement d’un paragraphe (par ex., un mot) ?**

Oui. La langue est définie au niveau de la portion ([PortionFormat.setLanguageId](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/baseportionformat/#setLanguageId-java.lang.String-)), ce qui permet de coexister plusieurs langues au sein d’un même paragraphe.