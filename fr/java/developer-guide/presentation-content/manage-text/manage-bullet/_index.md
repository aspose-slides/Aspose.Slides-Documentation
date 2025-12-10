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

Dans **Microsoft PowerPoint**, vous pouvez créer des listes à puces et numérotées de la même manière que dans Word et autres éditeurs de texte. **Aspose.Slides for Java** permet également d’utiliser des puces et des numéros dans les diapositives de vos présentations. 

## **Pourquoi utiliser les listes à puces ?**

Les listes à puces vous aident à organiser et présenter les informations rapidement et efficacement. 

**Exemple de liste à puces**

Dans la plupart des cas, une liste à puces remplit ces trois fonctions principales :

- attire l’attention de vos lecteurs ou spectateurs sur les informations importantes
- permet à vos lecteurs ou spectateurs de parcourir facilement les points clés
- communique et transmet efficacement les détails importants.

## **Pourquoi utiliser les listes numérotées ?**

Les listes numérotées aident également à organiser et présenter les informations. Idéalement, vous devriez utiliser des chiffres (à la place des puces) lorsque l’ordre des entrées (par exemple, *étape 1, étape 2*, etc.) est important ou lorsqu’une entrée doit être référencée (par exemple, *voir étape 3*).

**Exemple de liste numérotée**

Voici un résumé des étapes (étape 1 à étape 15) de la procédure **Créer des puces** ci‑dessous :

1. Créer une instance de la classe Presentation. 
2. Effectuer plusieurs tâches (étape 3 à étape 14).
3. Enregistrer la présentation. 

## **Créer des puces**

Ce sujet fait également partie de la série sur la gestion des paragraphes de texte. Cette page illustrera comment gérer les puces de paragraphe. Les puces sont utiles lorsqu’il faut décrire quelque chose par étapes. De plus, le texte semble bien organisé grâce à l’utilisation de puces. Les paragraphes à puces sont toujours plus faciles à lire et à comprendre. Nous verrons comment les développeurs peuvent exploiter cette petite mais puissante fonctionnalité d’Aspose.Slides for Java. Veuillez suivre les étapes ci‑dessous pour gérer les puces de paragraphe avec Aspose.Slides for Java :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation).
1. Accéder à la diapositive souhaitée dans la collection de diapositives à l’aide de l’objet [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide).
1. Ajouter une [AutoShape](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText) dans la diapositive sélectionnée.
1. Accéder au [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame) de la forme ajoutée.
1. Supprimer le paragraphe par défaut du TextFrame.
1. Créer la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/java/com.aspose.slides/Paragraph).
1. Définir le type de puce du paragraphe.
1. Définir le type de puce sur [Symbol](https://reference.aspose.com/slides/java/com.aspose.slides/BulletType#Symbol) et définir le caractère de puce.
1. Définir le texte du paragraphe.
1. Définir le retrait du paragraphe pour placer la puce.
1. Définir la couleur de la puce.
1. Définir la hauteur des puces.
1. Ajouter le paragraphe créé dans la collection de paragraphes du TextFrame.
1. Ajouter le deuxième paragraphe et répéter le processus décrit aux étapes **7 à 13**.
1. Enregistrer la présentation.

```java
// Instancier une classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accéder à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajouter et accéder à une forme automatique
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Accéder au cadre texte de la forme automatique créée
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // Supprimer le paragraphe par défaut existant
    txtFrm.getParagraphs().removeAt(0);
    
    // Créer un paragraphe
    Paragraph para = new Paragraph();
    
    // Définir le style de puce et le symbole du paragraphe
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char) 8226);
    
    // Définir le texte du paragraphe
    para.setText("Welcome to Aspose.Slides");
    
    // Définir le retrait de la puce
    para.getParagraphFormat().setIndent(25);
    
    // Définir la couleur de la puce
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    
    // Définir IsBulletHardColor sur true pour utiliser une couleur de puce personnalisée
    para.getParagraphFormat().getBullet().isBulletHardColor();
    
    // Définir la hauteur de la puce
    para.getParagraphFormat().getBullet().setHeight(100);
    
    // Ajouter le paragraphe au cadre texte
    txtFrm.getParagraphs().add(para);
    
    // Enregistrer la présentation en tant que fichier PPTX
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Créer des puces image**

Aspose.Slides for Java vous permet de modifier les puces des listes à puces. Vous pouvez remplacer les puces par des symboles ou des images personnalisés. Si vous souhaitez ajouter un intérêt visuel à une liste ou attirer davantage l’attention sur les éléments d’une liste, vous pouvez utiliser votre propre image comme puce. 

{{% alert color="primary" %}} 

Idéalement, si vous envisagez de remplacer le symbole de puce standard par une image, vous devriez choisir une image graphique simple avec un fond transparent. De telles images fonctionnent le mieux comme symboles de puce personnalisés. 

Dans tous les cas, l’image que vous choisissez sera réduite à une très petite taille, nous vous recommandons donc fortement de sélectionner une image qui rend bien (en tant que remplacement du symbole de puce) dans une liste. 

{{% /alert %}} 

Pour créer une puce image, suivez ces étapes :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) class
1. Accéder à la diapositive souhaitée dans la collection de diapositives à l’aide de l’objet [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) object
1. Ajouter une autoshape dans la diapositive sélectionnée
1. Accéder au [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) de la forme ajoutée
1. Supprimer le paragraphe par défaut dans le [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe)
1. Créer la première instance de paragraphe en utilisant la classe Paragraph
1. Charger l’image depuis le disque dans [IPPImage](https://reference.aspose.com/slides/java/com.aspose.slides/interfaces/IPPImage)
1. Définir le type de puce sur Picture et définir l’image
1. Définir le texte du paragraphe
1. Définir le retrait du paragraphe pour placer la puce
1. Définir la couleur de la puce
1. Définir la hauteur des puces
1. Ajouter le paragraphe créé dans le [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) paragraph collection
1. Ajouter le deuxième paragraphe et répéter le processus donné aux étapes précédentes
1. Enregistrer la présentation

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

    // Ajouter et accéder à l'autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accéder au cadre texte de l'autoshape créé
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

    // Enregistrer la présentation au format PPTX
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Créer des puces multiniveaux**

Pour créer une liste à puces contenant des éléments à différents niveaux — des listes supplémentaires sous la liste principale —, suivez ces étapes :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) class.
1. Accéder à la diapositive souhaitée dans la collection de diapositives à l’aide de l’objet [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) object.
1. Ajouter une autoshape dans la diapositive sélectionnée.
1. Accéder au [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) de la forme ajoutée.
1. Supprimer le paragraphe par défaut dans le [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe).
1. Créer la première instance de paragraphe en utilisant la classe Paragraph et avec une profondeur définie à 0.
1. Créer la deuxième instance de paragraphe en utilisant la classe Paragraph et avec une profondeur définie à 1.
1. Créer la troisième instance de paragraphe en utilisant la classe Paragraph et avec une profondeur définie à 2.
1. Créer la quatrième instance de paragraphe en utilisant la classe Paragraph et avec une profondeur définie à 3.
1. Ajouter les paragraphes créés dans le [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) paragraph collection.
1. Enregistrer la présentation.

```java
// Instancier une classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accéder à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajouter et accéder à l'autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Accéder au cadre texte de l'autoshape créé
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
    // Définir le niveau de la puce
    para1.getParagraphFormat().setDepth ((short)0);
    
    // Créer le deuxième paragraphe
    Paragraph para2 = new Paragraph();
    // Définir le style de puce du paragraphe et le symbole
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Définir le niveau de la puce
    para2.getParagraphFormat().setDepth ((short)1);
    
    // Créer le troisième paragraphe
    Paragraph para3 = new Paragraph();
    // Définir le style de puce du paragraphe et le symbole
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Définir le niveau de la puce
    para3.getParagraphFormat().setDepth ((short)2);
    
    // Créer le quatrième paragraphe
    Paragraph para4 = new Paragraph();
    // Définir le style de puce du paragraphe et le symbole
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    // Définir le niveau de la puce
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

Aspose.Slides for Java propose une API simple pour gérer les paragraphes avec un formatage de numérotation personnalisé. Pour ajouter une liste numérotée personnalisée dans un paragraphe, veuillez suivre les étapes ci‑dessous :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation) class.
1. Accéder à la diapositive souhaitée dans la collection de diapositives à l’aide de l’objet [ISlide](https://reference.aspose.com/slides/java/com.aspose.slides/islide) object.
1. Ajouter une autoshape dans la diapositive sélectionnée.
1. Accéder au [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) de la forme ajoutée.
1. Supprimer le paragraphe par défaut dans le [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe).
1. Créer la première instance de paragraphe en utilisant la classe Paragraph et définir **NumberedBulletStartWith** à 2
1. Créer la deuxième instance de paragraphe en utilisant la classe Paragraph et définir **NumberedBulletStartWith** à 3
1. Créer la troisième instance de paragraphe en utilisant la classe Paragraph et définir **NumberedBulletStartWith** à 7
1. Ajouter les paragraphes créés dans le [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/textframe) paragraph collection.
1. Enregistrer la présentation.

```java
// Instancier une classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accéder à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajouter et accéder à l'autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accéder au cadre texte de l'autoshape créé
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

**Les listes à puces et numérotées créées avec Aspose.Slides peuvent-elles être exportées vers d’autres formats tels que PDF ou images ?**

Oui, Aspose.Slides préserve complètement le formatage et la structure des listes à puces et numérotées lors de l’exportation des présentations vers des formats tels que PDF, images, et autres, garantissant des résultats cohérents.

**Est-il possible d’importer des listes à puces ou numérotées depuis des présentations existantes ?**

Oui, Aspose.Slides permet d’importer et de modifier des listes à puces ou numérotées provenant de présentations existantes tout en préservant leur formatage et apparence d’origine.

**Aspose.Slides prend‑t‑il en charge les listes à puces et numérotées dans les présentations créées en plusieurs langues ?**

Oui, Aspose.Slides prend pleinement en charge les présentations multilingues, vous permettant de créer des listes à puces et numérotées dans n’importe quelle langue, y compris l’utilisation de caractères spéciaux ou non latins.