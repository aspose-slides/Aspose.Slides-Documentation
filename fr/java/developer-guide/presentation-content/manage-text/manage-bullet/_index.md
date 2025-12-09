---
title: Gérer les listes à puces et numérotées dans les présentations avec Java
linktitle: Gérer les listes
type: docs
weight: 60
url: /fr/java/manage-bullet/
keywords:
- puce
- liste à puces
- liste numérotée
- puce symbole
- puce image
- puce personnalisée
- liste à plusieurs niveaux
- créer une puce
- ajouter une puce
- ajouter une liste
- PowerPoint
- OpenDocument
- présentation
- Java
- Aspose.Slides
description: "Apprenez à gérer les listes à puces et numérotées dans les présentations PowerPoint et OpenDocument en utilisant Aspose.Slides pour Java. Guide étape par étape."
---

Dans **Microsoft PowerPoint**, vous pouvez créer des listes à puces et numérotées de la même manière que dans Word et d’autres éditeurs de texte. **Aspose.Slides for Java** vous permet également d’utiliser des puces et des numéros dans les diapositives de vos présentations. 

## **Pourquoi utiliser les listes à puces ?**

Les listes à puces vous aident à organiser et présenter l’information rapidement et efficacement. 

**Exemple de liste à puces**

Dans la plupart des cas, une liste à puces remplit ces trois fonctions principales :

- attire l’attention de vos lecteurs ou spectateurs sur des informations importantes
- permet à vos lecteurs ou spectateurs de parcourir facilement les points clés
- communique et transmet efficacement les détails importants.

## **Pourquoi utiliser les listes numérotées ?**

Les listes numérotées aident également à organiser et présenter l’information. Idéalement, vous devez utiliser des chiffres (à la place des puces) lorsque l’ordre des éléments (par exemple, *étape 1, étape 2*, etc.) est important ou lorsqu’un élément doit être référencé (par exemple, *voir étape 3*).

**Exemple de liste numérotée**

Voici un résumé des étapes (étape 1 à étape 15) de la procédure **Creating Bullets** ci‑dessous :

1. Créez une instance de la classe Presentation. 
2. Effectuez plusieurs tâches (étape 3 à étape 14). 
3. Enregistrez la présentation. 

## **Création de puces**

Ce sujet fait également partie de la série de sujets sur la gestion des paragraphes de texte. Cette page illustrera comment gérer les puces de paragraphe. Les puces sont plus utiles lorsqu’il faut décrire quelque chose étape par étape. De plus, le texte apparaît bien organisé grâce à l’utilisation de puces. Les paragraphes à puces sont toujours plus faciles à lire et à comprendre. Nous verrons comment les développeurs peuvent exploiter cette fonctionnalité petite mais puissante d’Aspose.Slides for Java. Veuillez suivre les étapes ci‑dessous pour gérer les puces de paragraphe avec Aspose.Slides for Java :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation). 
2. Accédez à la diapositive souhaitée dans la collection de diapositives à l’aide de l’objet [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide). 
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText) dans la diapositive sélectionnée. 
4. Accédez au [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) de la forme ajoutée. 
5. Supprimez le paragraphe par défaut dans le TextFrame. 
6. Créez la première instance de paragraphe à l’aide de la classe [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/Paragraph). 
7. Définissez le type de puce du paragraphe. 
8. Définissez le type de puce sur [Symbol](https://reference.aspose.com/slides/java/com.aspose.slides/BulletType#Symbol) et définissez le caractère de puce. 
9. Définissez le texte du paragraphe. 
10. Définissez le retrait du paragraphe pour positionner la puce. 
11. Définissez la couleur de la puce. 
12. Définissez la hauteur des puces. 
13. Ajoutez le paragraphe créé à la collection de paragraphes du TextFrame. 
14. Ajoutez le deuxième paragraphe et répétez le processus indiqué aux étapes **7 à 13**. 
15. Enregistrez la présentation. 

```java
// Instancier une classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accéder à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajouter et accéder à la forme AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Accéder au cadre texte de l'AutoShape créée
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // Supprimer le paragraphe par défaut existant
    txtFrm.getParagraphs().removeAt(0);
    
    // Créer un paragraphe
    Paragraph para = new Paragraph();
    
    // Définir le style de puce du paragraphe et le symbole
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char) 8226);
    
    // Définir le texte du paragraphe
    para.setText("Welcome to Aspose.Slides");
    
    // Définir le retrait de la puce
    para.getParagraphFormat().setIndent(25);
    
    // Définir la couleur de la puce
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    
    // définir IsBulletHardColor à true pour utiliser sa propre couleur de puce
    para.getParagraphFormat().getBullet().isBulletHardColor();
    
    // Définir la hauteur de la puce
    para.getParagraphFormat().getBullet().setHeight(100);
    
    // Ajouter le paragraphe au cadre texte
    txtFrm.getParagraphs().add(para);
    
    // enregistrer la présentation en tant que fichier PPTX
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Création de puces avec images**

**Aspose.Slides for Java** vous permet de modifier les puces des listes à puces. Vous pouvez remplacer les puces par des symboles ou des images personnalisés. Si vous souhaitez ajouter un intérêt visuel à une liste ou attirer encore plus l’attention sur les éléments d’une liste, vous pouvez utiliser votre propre image comme puce. 

{{% alert color="primary" %}} 

Idéalement, si vous envisagez de remplacer le symbole de puce standard par une image, vous devriez choisir une image graphique simple avec un arrière‑plan transparent. De telles images fonctionnent le mieux comme symboles de puce personnalisés. 

Dans tous les cas, l’image que vous choisissez sera réduite à une taille très petite, nous vous recommandons donc vivement de sélectionner une image qui reste de bonne qualité (en tant que remplacement du symbole de puce) dans une liste. 

{{% /alert %}} 

Pour créer une puce image, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation). 
2. Accédez à la diapositive souhaitée dans la collection de diapositives à l’aide de l’objet [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide). 
3. Ajoutez une autoshape dans la diapositive sélectionnée. 
4. Accédez au [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) de la forme ajoutée. 
5. Supprimez le paragraphe par défaut dans le [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe). 
6. Créez la première instance de paragraphe en utilisant la classe Paragraph. 
7. Chargez l’image depuis le disque dans [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IPPImage). 
8. Définissez le type de puce sur Picture et définissez l’image. 
9. Définissez le texte du paragraphe. 
10. Définissez le retrait du paragraphe pour positionner la puce. 
11. Définissez la couleur de la puce. 
12. Définissez la hauteur des puces. 
13. Ajoutez le paragraphe créé à la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe). 
14. Ajoutez le deuxième paragraphe et répétez le processus indiqué aux étapes précédentes. 
15. Enregistrez la présentation. 

```java
Presentation pres = new Presentation();
try {
    // Accéder à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Instancier l'image pour les puces
    IPPImage picture;
    IImage image = Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Ajouter et accéder à l'AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accéder au cadre texte de l'AutoShape créée
    ITextFrame txtFrm = aShp.getTextFrame();
    // Supprimer le paragraphe par défaut existant
    txtFrm.getParagraphs().removeAt(0);

    // Créer un nouveau paragraphe
    Paragraph para = new Paragraph();
    para.setText("Welcome to Aspose.Slides");

    // Définir le style de puce du paragraphe et l'image
    para.getParagraphFormat().getBullet().setType(BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Définir la hauteur de la puce
    para.getParagraphFormat().getBullet().setHeight(100);

    // Ajouter le paragraphe au cadre texte
    txtFrm.getParagraphs().add(para);

    // Enregistrer la présentation en tant que fichier PPTX
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Création de puces à plusieurs niveaux**

Pour créer une liste à puces contenant des éléments à différents niveaux — des listes supplémentaires sous la liste principale — suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation). 
2. Accédez à la diapositive souhaitée dans la collection de diapositives à l’aide de l’objet [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide). 
3. Ajoutez une autoshape dans la diapositive sélectionnée. 
4. Accédez au [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) de la forme ajoutée. 
5. Supprimez le paragraphe par défaut dans le [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe). 
6. Créez la première instance de paragraphe en utilisant la classe Paragraph et avec une profondeur fixée à 0. 
7. Créez la deuxième instance de paragraphe en utilisant la classe Paragraph et avec une profondeur fixée à 1. 
8. Créez la troisième instance de paragraphe en utilisant la classe Paragraph et avec une profondeur fixée à 2. 
9. Créez la quatrième instance de paragraphe en utilisant la classe Paragraph et avec une profondeur fixée à 3. 
10. Ajoutez les paragraphes créés à la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe). 
11. Enregistrez la présentation. 

```java
// Instancier une classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accéder à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajouter et accéder à l'AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Accéder au cadre texte de l'AutoShape créée
    ITextFrame txtFrm = aShp.addTextFrame("");
    
    // Supprimer le paragraphe par défaut existant
    txtFrm.getParagraphs().clear();
    
    // Créer le premier paragraphe
    Paragraph para1 = new Paragraph();
    // Définir le style de puce du paragraphe et le symbole
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char) 8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Définir le niveau de puce
    para1.getParagraphFormat().setDepth ((short)0);
    
    // Créer le deuxième paragraphe
    Paragraph para2 = new Paragraph();
    // Définir le style de puce du paragraphe et le symbole
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Définir le niveau de puce
    para2.getParagraphFormat().setDepth ((short)1);
    
    // Créer le troisième paragraphe
    Paragraph para3 = new Paragraph();
    // Définir le style de puce du paragraphe et le symbole
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Définir le niveau de puce
    para3.getParagraphFormat().setDepth ((short)2);
    
    // Créer le quatrième paragraphe
    Paragraph para4 = new Paragraph();
    // Définir le style de puce du paragraphe et le symbole
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Définir le niveau de puce
    para4.getParagraphFormat().setDepth ((short)3);
    
    // Ajouter le paragraphe au cadre texte
    txtFrm.getParagraphs().add(para1);
    txtFrm.getParagraphs().add(para2);
    txtFrm.getParagraphs().add(para3);
    txtFrm.getParagraphs().add(para4);
    
    // Enregistrer la présentation en tant que fichier PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Créer des listes numérotées personnalisées**

**Aspose.Slides for Java** fournit une API simple pour gérer les paragraphes avec un formatage de numérotation personnalisé. Pour ajouter une liste numérotée personnalisée dans un paragraphe, veuillez suivre les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation). 
2. Accédez à la diapositive souhaitée dans la collection de diapositives à l’aide de l’objet [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide). 
3. Ajoutez une autoshape dans la diapositive sélectionnée. 
4. Accédez au [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) de la forme ajoutée. 
5. Supprimez le paragraphe par défaut dans le [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe). 
6. Créez la première instance de paragraphe en utilisant la classe Paragraph et définissez **NumberedBulletStartWith** à 2. 
7. Créez la deuxième instance de paragraphe en utilisant la classe Paragraph et définissez **NumberedBulletStartWith** à 3. 
8. Créez la troisième instance de paragraphe en utilisant la classe Paragraph et définissez **NumberedBulletStartWith** à 7. 
9. Ajoutez les paragraphes créés à la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe). 
10. Enregistrez la présentation. 

```java
// Instancier une classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accéder à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajouter et accéder à l'AutoShape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accéder au cadre texte de l'AutoShape créée
    ITextFrame txtFrm = aShp.addTextFrame("");

    // Supprimer le paragraphe par défaut existant
    txtFrm.getParagraphs().clear();

    // Première liste
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph2);

    // Deuxième liste
    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("bullet 5");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)5);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph5);

    pres.save(resourcesOutputPath + "SetCustomBulletsNumber-slides.pptx.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **FAQ**

**Les listes à puces et numérotées créées avec Aspose.Slides peuvent‑elles être exportées vers d’autres formats tels que PDF ou images ?**

Oui, Aspose.Slides conserve entièrement le formatage et la structure des listes à puces et numérotées lors de l’exportation des présentations vers des formats comme PDF, images et autres, garantissant des résultats cohérents.

**Est‑il possible d’importer des listes à puces ou numérotées depuis des présentations existantes ?**

Oui, Aspose.Slides permet d’importer et de modifier des listes à puces ou numérotées provenant de présentations existantes tout en préservant leur formatage et apparence d’origine.

**Aspose.Slides prend‑il en charge les listes à puces et numérotées dans des présentations créées en plusieurs langues ?**

Oui, Aspose.Slides prend en charge pleinement les présentations multilingues, vous permettant de créer des listes à puces et numérotées dans n’importe quelle langue, y compris l’utilisation de caractères spéciaux ou non latins.