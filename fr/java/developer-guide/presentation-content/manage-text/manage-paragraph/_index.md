---
title: Gérer les Paragraphes PowerPoint en Java
type: docs
weight: 40
url: /java/manage-paragraph/
keywords: "Ajouter un paragraphe PowerPoint, Gérer les paragraphes, Retrait de paragraphe, Propriétés de paragraphe, Texte HTML, Exporter le texte du paragraphe, Présentation PowerPoint, Java, Aspose.Slides pour Java"
description: "Créer et gérer un paragraphe, du texte, un retrait et des propriétés dans des présentations PowerPoint en Java"
---

Aspose.Slides fournit toutes les interfaces et classes nécessaires pour travailler avec les textes, paragraphes et portions PowerPoint en Java.

* Aspose.Slides fournit l'interface [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) pour vous permettre d'ajouter des objets représentant un paragraphe. Un objet `ITextFame` peut avoir un ou plusieurs paragraphes (chaque paragraphe est créé par un retour à la ligne).
* Aspose.Slides fournit l'interface [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) pour vous permettre d'ajouter des objets représentant des portions. Un objet `IParagraph` peut avoir une ou plusieurs portions (collection d'objets iPortions).
* Aspose.Slides fournit l'interface [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) pour vous permettre d'ajouter des objets représentant des textes et leurs propriétés de formatage. 

Un objet `IParagraph` est capable de gérer des textes avec différentes propriétés de formatage à travers ses objets `IPortion` sous-jacents.

## **Ajouter plusieurs Paragraphes contenant plusieurs Portions**

Ces étapes vous montrent comment ajouter un cadre de texte contenant 3 paragraphes et chaque paragraphe contenant 3 portions :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Accédez à la référence du diapositive pertinente par son index.
3. Ajoutez une Rectangle [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) à la diapositive.
4. Obtenez le ITextFrame associé à [IAutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/).
5. Créez deux objets [IParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/iparagraph/) et ajoutez-les à la collection `IParagraphs` du [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/).
6. Créez trois objets [IPortion](https://reference.aspose.com/slides/java/com.aspose.slides/iportion/) pour chaque nouveau `IParagraph` (deux objets Portion pour le paragraphe par défaut) et ajoutez chaque objet `IPortion` à la collection IPortion de chaque `IParagraph`.
7. Définissez un texte pour chaque portion.
8. Appliquez vos fonctionnalités de formatage préférées à chaque portion en utilisant les propriétés de formatage exposées par l'objet `IPortion`.
9. Enregistrez la présentation modifiée.

Ce code Java est une implémentation des étapes pour ajouter des paragraphes contenant des portions :

```java
// Instancier une classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accéder à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajouter une forme AutoShape de type Rectangle
    IAutoShape ashp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Accéder à TextFrame de l'AutoShape
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

    //Écrire PPTX sur disque
    pres.save("multiParaPort_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Gérer les Puces de Paragraphes**

Les listes à puces vous aident à organiser et à présenter des informations rapidement et efficacement. Les paragraphes à puces sont toujours plus faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Accédez à la référence de la diapositive pertinente par son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) à la diapositive sélectionnée.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) de l'autoshape. 
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/).
7. Définissez le `Type` de la puce pour le paragraphe sur `Symbol` et définissez le caractère de la puce.
8. Définissez le `Text` du paragraphe.
9. Définissez le `Indent` du paragraphe pour la puce.
10. Définissez une couleur pour la puce.
11. Définissez une hauteur pour la puce.
12. Ajoutez le nouveau paragraphe à la collection de paragraphes du `TextFrame`.
13. Ajoutez le deuxième paragraphe et répétez le processus décrit dans les étapes 7 à 13.
14. Sauvegardez la présentation.

Ce code Java vous montre comment ajouter une puce de paragraphe :

```java
// Instantiates a Presentation class that represents a PPTX file
Presentation pres = new Presentation();
try {
    // Accesses the first slide
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Adds and accesses Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accesses the autoshape text frame
    ITextFrame txtFrm = aShp.getTextFrame();

    // Removes the default paragraph
    txtFrm.getParagraphs().removeAt(0);

    // Creates a paragraph
    Paragraph para = new Paragraph();

    // Sets a paragraph bullet style and symbol
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char)8226);

    // Sets a paragraph text
    para.setText("Bienvenue dans Aspose.Slides");

    // Sets bullet indent
    para.getParagraphFormat().setIndent(25);

    // Sets bullet color
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // définissez IsBulletHardColor sur true pour utiliser votre propre couleur de puce

    // Sets Bullet Height
    para.getParagraphFormat().getBullet().setHeight(100);

    // Adds Paragraph to text frame
    txtFrm.getParagraphs().add(para);

    // Creates second paragraph
    Paragraph para2 = new Paragraph();

    // Sets paragraph bullet type and style
    para2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    para2.getParagraphFormat().getBullet().setNumberedBulletStyle(NumberedBulletStyle.BulletCircleNumWDBlackPlain);

    // Adds paragraph text
    para2.setText("Ceci est une puce numérotée");

    // Sets bullet indent
    para2.getParagraphFormat().setIndent(25);

    para2.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para2.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    para2.getParagraphFormat().getBullet().setBulletHardColor(NullableBool.True); // définissez IsBulletHardColor sur true pour utiliser votre propre couleur de puce

    // Sets Bullet Height
    para2.getParagraphFormat().getBullet().setHeight(100);

    // Adds Paragraph to text frame
    txtFrm.getParagraphs().add(para2);
    
    // Saves the modified presentation
    pres.save("Bullet_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Gérer les Puces d'Image**

Les listes à puces vous aident à organiser et à présenter des informations rapidement et efficacement. Les paragraphes avec des images sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Accédez à la référence de la diapositive pertinente par son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) de l'autoshape. 
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/).
7. Chargez l'image dans [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/).
8. Définissez le type de puce sur [Picture](https://reference.aspose.com/slides/java/com.aspose.slides/ippimage/) et définissez l'image.
9. Définissez le `Text` du paragraphe.
10. Définissez le `Indent` du paragraphe pour la puce.
11. Définissez une couleur pour la puce.
12. Définissez une hauteur pour la puce.
13. Ajoutez le nouveau paragraphe à la collection de paragraphes du `TextFrame`.
14. Ajoutez le deuxième paragraphe et répétez le processus en fonction des étapes précédentes.
15. Enregistrez la présentation modifiée.

Ce code Java vous montre comment ajouter et gérer des puces d'image :

```java
// Instantiates a Presentation class that represents a PPTX file
Presentation presentation = new Presentation();
try {
    // Accesses the first slide
    ISlide slide = presentation.getSlides().get_Item(0);

    // Instantiates the image for bullets
    IPPImage picture;
    IImage image = Images.fromFile("bullets.png");
    try {
        picture = presentation.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }
    // Adds and accesses Autoshape
    IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accesses the autoshape textframe
    ITextFrame textFrame = autoShape.getTextFrame();

    // Removes the default paragraph
    textFrame.getParagraphs().removeAt(0);

    // Creates a new paragraph
    Paragraph paragraph = new Paragraph();
    paragraph.setText("Bienvenue dans Aspose.Slides");

    // Sets paragraph bullet style and image
    paragraph.getParagraphFormat().getBullet().setType(BulletType.Picture);
    paragraph.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Sets bullet Height
    paragraph.getParagraphFormat().getBullet().setHeight(100);

    // Adds paragraph to text frame
    textFrame.getParagraphs().add(paragraph);

    // Writes the presentation as a PPTX file
    presentation.save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

    // Writes the presentation as a PPT file
    presentation.save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
} catch (IOException e) {
} finally {
    if (presentation != null) presentation.dispose();
}
```


## **Gérer les Puces Multiniveau**

Les listes à puces vous aident à organiser et à présenter des informations rapidement et efficacement. Les puces multiniveau sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Accédez à la référence de la diapositive pertinente par son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) dans la nouvelle diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) de l'autoshape. 
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe à l'aide de la classe [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) et définissez la profondeur sur 0.
7. Créez la deuxième instance de paragraphe par la classe `Paragraph` et définissez la profondeur sur 1.
8. Créez la troisième instance de paragraphe par la classe `Paragraph` et définissez la profondeur sur 2.
9. Créez la quatrième instance de paragraphe par la classe `Paragraph` et définissez la profondeur sur 3.
10. Ajoutez les nouveaux paragraphes à la collection de paragraphes du `TextFrame`.
11. Enregistrez la présentation modifiée.

Ce code Java vous montre comment ajouter et gérer des puces multiniveau :

```java
// Instantiates a Presentation class that represents a PPTX file
Presentation pres = new Presentation();
try {
    // Accesses the first slide
    ISlide slide = pres.getSlides().get_Item(0);

    // Adds and accesses Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accesses the text frame of created autoshape
    ITextFrame text = aShp.addTextFrame("");

    // Clears the default paragraph
    text.getParagraphs().clear();

    // Adds the first paragraph
    IParagraph para1 = new Paragraph();
    para1.setText("Contenu");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Sets the bullet level
    para1.getParagraphFormat().setDepth((short)0);

    // Adds the second paragraph
    IParagraph para2 = new Paragraph();
    para2.setText("Deuxième niveau");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Sets the bullet level
    para2.getParagraphFormat().setDepth((short)1);

    // Adds the third paragraph
    IParagraph para3 = new Paragraph();
    para3.setText("Troisième niveau");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Sets the bullet level
    para3.getParagraphFormat().setDepth((short)2);

    // Adds the fourth paragraph
    IParagraph para4 = new Paragraph();
    para4.setText("Quatrième niveau");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Sets the bullet level
    para4.getParagraphFormat().setDepth((short)3);

    // Adds paragraphs to collection
    text.getParagraphs().add(para1);
    text.getParagraphs().add(para2);
    text.getParagraphs().add(para3);
    text.getParagraphs().add(para4);

    // Writes the presentation as a PPTX file
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Gérer le Paragraphe avec Liste Numérotée Personnalisée**

L'interface [IBulletFormat](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/) fournit la propriété [NumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) et d'autres qui vous permettent de gérer les paragraphes avec une numérotation ou un formatage personnalisé. 

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Accédez à la diapositive contenant le paragraphe.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) de l'autoshape.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) et définissez [NumberedBulletStartWith](https://reference.aspose.com/slides/java/com.aspose.slides/ibulletformat/#setNumberedBulletStartWith-short-) sur 2.
7. Créez la deuxième instance de paragraphe via la classe `Paragraph` et définissez `NumberedBulletStartWith` sur 3.
8. Créez la troisième instance de paragraphe via la classe `Paragraph` et définissez `NumberedBulletStartWith` sur 7.
9. Ajoutez les nouveaux paragraphes à la collection de paragraphes du `TextFrame`.
10. Enregistrez la présentation modifiée.

Ce code Java vous montre comment ajouter et gérer des paragraphes avec une numérotation ou un formatage personnalisé :

```java
Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accesses the text frame of created autoshape
    ITextFrame textFrame = shape.getTextFrame();

    // Removes the default exisiting paragraph
    textFrame.getParagraphs().removeAt(0);

    // First list
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


## **Définir le Retrait de Paragraphe**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
1. Accédez à la référence de la diapositive pertinente par son index.
1. Ajoutez une rectangle [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) à la diapositive.
1. Ajoutez un [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) avec trois paragraphes à l'autoshape rectangle.
1. Masquez les lignes du rectangle.
1. Définissez le retrait pour chaque [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/) via leur propriété BulletOffset.
1. Écrivez la présentation modifiée sous forme de fichier PPT.

Ce code Java vous montre comment définir un retrait de paragraphe :

```java
// Instantiate Presentation Class
Presentation pres = new Presentation();
try {
    // Get first slide
    ISlide sld = pres.getSlides().get_Item(0);
    
    // Add a Rectangle Shape
    IAutoShape rect = sld.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);
    
    // Add TextFrame to the Rectangle
    ITextFrame tf = rect.addTextFrame("Ceci est la première ligne \rCeci est la deuxième ligne \rCeci est la troisième ligne");
    
    // Set the text to fit the shape
    tf.getTextFrameFormat().setAutofitType(TextAutofitType.Shape);
    
    // Hide the lines of the Rectangle
    rect.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    
    // Get first Paragraph in the TextFrame and set its Indent
    IParagraph para1 = tf.getParagraphs().get_Item(0);
    // Définir le style de puce du paragraphe et le symbole
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char)8226);
    para1.getParagraphFormat().setAlignment(TextAlignment.Left);
    
    para1.getParagraphFormat().setDepth((short)2);
    para1.getParagraphFormat().setIndent(30);
    
    // Get second Paragraph in the TextFrame and set its Indent
    IParagraph para2 = tf.getParagraphs().get_Item(1);
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar((char)8226);
    para2.getParagraphFormat().setAlignment(TextAlignment.Left);
    para2.getParagraphFormat().setDepth((short)2);
    para2.getParagraphFormat().setIndent(40);
    
    // Get third Paragraph in the TextFrame and set its Indent
    IParagraph para3 = tf.getParagraphs().get_Item(2);
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char)8226);
    para3.getParagraphFormat().setAlignment(TextAlignment.Left);
    para3.getParagraphFormat().setDepth((short)2);
    para3.getParagraphFormat().setIndent(50);
    
    //Écrire la Présentation sur disque
    pres.save("InOutDent_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Définir le Retrait Suspendu pour le Paragraphe**

Ce code Java montre comment définir le retrait suspendu pour un paragraphe :

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

## **Gérer les Propriétés de Fin de Paragraphe pour le Paragraphe**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) .
1. Obtenez la référence pour la diapositive contenant le paragraphe via sa position.
1. Ajoutez une rectangle [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) à la diapositive.
1. Ajoutez un [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) avec deux paragraphes à la Rectangle.
1. Définissez le `FontHeight` et le type de police pour les paragraphes.
1. Définissez les propriétés de fin pour les paragraphes.
1. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code Java vous montre comment définir les propriétés de fin pour les paragraphes dans PowerPoint : 

```java
Presentation pres = new Presentation();
try {
    IAutoShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

    Paragraph para1 = new Paragraph();
    para1.getPortions().add(new Portion("Texte d'exemple"));

    Paragraph para2 = new Paragraph();
    para2.getPortions().add(new Portion("Texte d'exemple 2"));

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


## **Importer du Texte HTML dans les Paragraphes**

Aspose.Slides fournit un support amélioré pour l'importation de texte HTML dans les paragraphes.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/).
2. Accédez à la référence de la diapositive pertinente par son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/java/com.aspose.slides/iautoshape/) à la diapositive.
4. Ajoutez et accédez à l'autoshape [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/).
5. Supprimez le paragraphe par défaut dans le `ITextFrame`.
6. Lisez le fichier HTML source dans un TextReader.
7. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/paragraph/).
8. Ajoutez le contenu du fichier HTML dans le TextReader lu à la [ParagraphCollection](https://reference.aspose.com/slides/java/com.aspose.slides/paragraphcollection/) de TextFrame.
9. Enregistrez la présentation modifiée.

Ce code Java est une implémentation des étapes pour importer des textes HTML dans des paragraphes :

```java
// Créer une instance de présentation vide
Presentation pres = new Presentation();
try {
    // Accéder à la première diapositive par défaut de la présentation
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajout de l'AutoShape pour accueillir le contenu HTML
    IAutoShape ashape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10,
            (float)pres.getSlideSize().getSize().getWidth() - 20, (float)pres.getSlideSize().getSize().getHeight() - 10);

    ashape.getFillFormat().setFillType(FillType.NoFill);

    // Ajout d'un cadre de texte à la forme
    ashape.addTextFrame("");

    // Effacer tous les paragraphes du cadre de texte ajouté
    ashape.getTextFrame().getParagraphs().clear();

    // Charger le fichier HTML à l'aide de TextReader
    TextReader tr = new StreamReader("file.html");

    // Ajouter le texte du lecteur de flux HTML dans le cadre de texte
    ashape.getTextFrame().getParagraphs().addFromHtml(tr.readToEnd());

    // Enregistrer la présentation
    pres.save("output_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Exporter le Texte des Paragraphes vers HTML**

Aspose.Slides fournit un support amélioré pour exporter des textes (contenus dans des paragraphes) vers HTML.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) et chargez la présentation souhaitée.
2. Accédez à la référence de la diapositive pertinente par son index.
3. Accédez à la forme contenant le texte qui sera exporté vers HTML.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe/) de la forme.
5. Créez une instance de `StreamWriter` et ajoutez le nouveau fichier HTML.
6. Fournissez un index de départ au StreamWriter et exportez vos paragraphes préférés.

Ce code Java vous montre comment exporter les textes de paragraphe PowerPoint vers HTML :

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

    // Création du fichier HTML de sortie
    OutputStream os = new FileOutputStream("output.html");
    Writer writer = new OutputStreamWriter(os, "UTF-8");

    // Extraire le premier paragraphe en tant que HTML
    // Écrire les données des paragraphes dans HTML en fournissant l'index de départ du paragraphe, le nombre total de paragraphes à copier
    writer.write(ashape.getTextFrame().getParagraphs().exportToHtml(0, ashape.getTextFrame().getParagraphs().getCount(), null));
    writer.close();
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```