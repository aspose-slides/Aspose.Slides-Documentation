---
title: Gérer les Puces
type: docs
weight: 60
url: /androidjava/manage-bullet/
keywords: "Puces, Listes à puces, Nombres, Listes numérotées, Puces d'image, puces multilevel, Présentation PowerPoint, Java, Aspose.Slides pour Android via Java"
description: "Créer des listes à puces et numérotées dans une présentation PowerPoint en Java"
---

Dans **Microsoft PowerPoint**, vous pouvez créer des listes à puces et numérotées de la même manière que dans Word et d'autres éditeurs de texte. **Aspose.Slides pour Android via Java** vous permet également d'utiliser des puces et des numéros dans les diapositives de vos présentations.

## Pourquoi utiliser des listes à puces ?

Les listes à puces vous aident à organiser et à présenter des informations rapidement et efficacement.

**Exemple de liste à puces**

Dans la plupart des cas, une liste à puces remplit ces trois fonctions principales :

- attire l'attention de vos lecteurs ou spectateurs sur des informations importantes
- permet à vos lecteurs ou spectateurs de rechercher facilement les points clés
- communique et transmet des détails importants de manière efficace.

## Pourquoi utiliser des listes numérotées ?

Les listes numérotées aident également à organiser et à présenter des informations. Idéalement, vous devriez utiliser des numéros (au lieu de puces) lorsque l'ordre des entrées (par exemple, *étape 1, étape 2*, etc.) est important ou lorsqu'une entrée doit être référencée (par exemple, *voir étape 3*).

**Exemple de liste numérotée**

Voici un résumé des étapes (étape 1 à étape 15) de la procédure **Créer des puces** ci-dessous :

1. Créer une instance de la classe de présentation. 
2. Effectuer plusieurs tâches (étape 3 à étape 14).
3. Enregistrer la présentation. 

## Création de puces
Ce sujet fait également partie de la série de sujets sur la gestion des paragraphes de texte. Cette page illustrera comment nous pouvons gérer les puces de paragraphe. Les puces sont plus utiles lorsqu'il s'agit de décrire quelque chose étape par étape. De plus, le texte semble bien organisé avec l'utilisation de puces. Les paragraphes à puces sont toujours plus faciles à lire et à comprendre. Nous verrons comment les développeurs peuvent utiliser cette petite mais puissante fonctionnalité d'Aspose.Slides pour Android via Java. Veuillez suivre les étapes ci-dessous pour gérer les puces de paragraphe à l'aide d'Aspose.Slides pour Android via Java :

1. Créer une instance de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) class.
1. Accéder à la diapositive désirée dans la collection de diapositives en utilisant l'objet [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide).
1. Ajouter un [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText) dans la diapositive sélectionnée.
1. Accéder au [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) de la forme ajoutée.
1. Supprimer le paragraphe par défaut dans le TextFrame.
1. Créer la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Paragraph).
1. Définir le type de puce du paragraphe.
1. Définir le type de puce sur [Symbol](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BulletType#Symbol) et définir le caractère de la puce.
1. Définir le texte du paragraphe.
1. Définir l'indentation du paragraphe pour définir la puce.
1. Définir la couleur de la puce.
1. Définir la hauteur des puces.
1. Ajouter le paragraphe créé dans la collection de paragraphes du TextFrame.
1. Ajouter le deuxième paragraphe et répéter le processus donné dans les étapes **7 à 13**.
1. Enregistrer la présentation.

Ce code d'exemple en Java—une implémentation des étapes ci-dessus—vous montre comment créer une liste à puces dans une diapositive :

```java
// Instancier une classe Presentation représentant un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accéder à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajouter et accéder à l'Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Accéder au cadre de texte de l'autoshape créé
    ITextFrame txtFrm = aShp.getTextFrame();
    
    // Supprimer le paragraphe par défaut existant
    txtFrm.getParagraphs().removeAt(0);
    
    // Créer un paragraphe
    Paragraph para = new Paragraph();
    
    // Définir le style et le symbole de la puce du paragraphe
    para.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar((char) 8226);
    
    // Définir le texte du paragraphe
    para.setText("Bienvenue dans Aspose.Slides");
    
    // Définir l'indentation de la puce
    para.getParagraphFormat().setIndent(25);
    
    // Définir la couleur de la puce
    para.getParagraphFormat().getBullet().getColor().setColorType(ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(Color.BLACK);
    
    // définir IsBulletHardColor à vrai pour utiliser votre propre couleur de puce
    para.getParagraphFormat().getBullet().isBulletHardColor();
    
    // Définir la hauteur de la puce
    para.getParagraphFormat().getBullet().setHeight(100);
    
    // Ajouter le paragraphe au cadre de texte
    txtFrm.getParagraphs().add(para);
    
    // sauvegarder la présentation en tant que fichier PPTX
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## Création de puces d'image

Aspose.Slides pour Android via Java vous permet de modifier les puces des listes à puces. Vous pouvez remplacer les puces par des symboles ou des images personnalisées. Si vous voulez ajouter de l'intérêt visuel à une liste ou attirer encore plus l'attention sur les éléments d'une liste, vous pouvez utiliser votre propre image comme puce.

{{% alert color="primary" %}} 

Idéalement, si vous avez l'intention de remplacer le symbole de puce régulier par une image, vous voudrez peut-être sélectionner une image graphique simple avec un fond transparent. De telles images fonctionnent mieux comme symboles de puces personnalisées.

Dans tous les cas, l'image que vous choisissez sera réduite à une taille très petite, donc nous vous recommandons vivement de sélectionner une image qui a l'air bien (comme remplacement du symbole de puce) dans une liste.

{{% /alert %}} 

Pour créer une puce d'image, suivez ces étapes :

1. Créer une instance de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) class
1. Accéder à la diapositive désirée dans la collection de diapositives en utilisant l'objet [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide)
1. Ajouter un autoshape dans la diapositive sélectionnée
1. Accéder au [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) de la forme ajoutée
1. Supprimer le paragraphe par défaut dans le [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe)
1. Créer la première instance de paragraphe en utilisant la classe Paragraph
1. Charger l'image depuis le disque dans [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/interfaces/IPPImage)
1. Définir le type de puce sur Image et définir l'image
1. Définir le texte du paragraphe
1. Définir l'indentation du paragraphe pour définir la puce
1. Définir la couleur de la puce
1. Définir la hauteur des puces
1. Ajouter le paragraphe créé dans la collection de paragraphes [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe)
1. Ajouter le deuxième paragraphe et répéter le processus donné dans les étapes précédentes
1. Enregistrer la présentation

Ce code Java vous montre comment créer une puce d'image dans une diapositive :

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

    // Ajouter et accéder à l'Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accéder au cadre de texte de l'autoshape créé
    ITextFrame txtFrm = aShp.getTextFrame();
    // Supprimer le paragraphe par défaut existant
    txtFrm.getParagraphs().removeAt(0);

    // Créer un nouveau paragraphe
    Paragraph para = new Paragraph();
    para.setText("Bienvenue dans Aspose.Slides");

    // Définir le style de la puce du paragraphe et l'image
    para.getParagraphFormat().getBullet().setType(BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);

    // Définir la hauteur de la puce
    para.getParagraphFormat().getBullet().setHeight(100);

    // Ajouter le paragraphe au cadre de texte
    txtFrm.getParagraphs().add(para);

    // Écrire la présentation en tant que fichier PPTX
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## Création de puces multilevel

Pour créer une liste à puces contenant des éléments à différents niveaux—des listes additionnelles sous la liste principale à puces—suivez ces étapes :

1. Créer une instance de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) class.
1. Accéder à la diapositive désirée dans la collection de diapositives en utilisant l'objet [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide) object.
1. Ajouter un autoshape dans la diapositive sélectionnée.
1. Accéder au [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) de la forme ajoutée.
1. Supprimer le paragraphe par défaut dans le [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
1. Créer la première instance de paragraphe en utilisant la classe Paragraph et avec la profondeur définie à 0.
1. Créer la deuxième instance de paragraphe en utilisant la classe Paragraph et avec la profondeur définie à 1.
1. Créer la troisième instance de paragraphe en utilisant la classe Paragraph et avec la profondeur définie à 2.
1. Créer la quatrième instance de paragraphe en utilisant la classe Paragraph et avec la profondeur définie à 3.
1. Ajouter les paragraphes créés dans la collection de paragraphes [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
1. Enregistrer la présentation.

Ce code, qui est une implémentation des étapes ci-dessus, vous montre comment créer une liste à puces multilevel en Java :

```java
// Instancier une classe Presentation représentant un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accéder à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajouter et accéder à l'Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
    
    // Accéder au cadre de texte de l'autoshape créé
    ITextFrame txtFrm = aShp.addTextFrame("");
    
    // Supprimer le paragraphe par défaut existant
    txtFrm.getParagraphs().clear();
    
    // Créer le premier paragraphe
    Paragraph para1 = new Paragraph();
    // Définir le style et le symbole de la puce du paragraphe
    para1.setText("Contenu");
    para1.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar((char) 8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Définir le niveau de la puce
    para1.getParagraphFormat().setDepth ((short)0);
    
    // Créer le deuxième paragraphe
    Paragraph para2 = new Paragraph();
    // Définir le style et le symbole de la puce du paragraphe
    para2.setText("Deuxième niveau");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Définir le niveau de la puce
    para2.getParagraphFormat().setDepth ((short)1);
    
    // Créer le troisième paragraphe
    Paragraph para3 = new Paragraph();
    // Définir le style et le symbole de la puce du paragraphe
    para3.setText("Troisième niveau");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Définir le niveau de la puce
    para3.getParagraphFormat().setDepth ((short)2);
    
    // Créer le quatrième paragraphe
    Paragraph para4 = new Paragraph();
    // Définir le style et le symbole de la puce du paragraphe
    para4.setText("Quatrième niveau");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Définir le niveau de la puce
    para4.getParagraphFormat().setDepth ((short)3);
    
    // Ajouter le paragraphe au cadre de texte
    txtFrm.getParagraphs().add(para1);
    txtFrm.getParagraphs().add(para2);
    txtFrm.getParagraphs().add(para3);
    txtFrm.getParagraphs().add(para4);
    
    // enregistrer la présentation en tant que fichier PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## Créer une liste numérotée personnalisée
Aspose.Slides pour Android via Java fournit une API simple pour gérer les paragraphes avec un formatage de numéros personnalisés. Pour ajouter une liste de numéros personnalisée dans un paragraphe, veuillez suivre les étapes ci-dessous :

1. Créer une instance de [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation) class.
1. Accéder à la diapositive désirée dans la collection de diapositives en utilisant l'objet [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide).
1. Ajouter un autoshape dans la diapositive sélectionnée.
1. Accéder au [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) de la forme ajoutée.
1. Supprimer le paragraphe par défaut dans le [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
1. Créer la première instance de paragraphe en utilisant la classe Paragraph et définir **NumberedBulletStartWith** sur 2
1. Créer la deuxième instance de paragraphe en utilisant la classe Paragraph et définir **NumberedBulletStartWith** sur 3
1. Créer la troisième instance de paragraphe en utilisant la classe Paragraph et définir **NumberedBulletStartWith** sur 7
1. Ajouter les paragraphes créés dans la collection de paragraphes [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).
1. Enregistrer la présentation.

Ce code Java vous montre comment créer une liste numérotée dans une diapositive :

```java
// Instancier une classe Presentation représentant un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accéder à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajouter et accéder à l'Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accéder au cadre de texte de l'autoshape créé
    ITextFrame txtFrm = aShp.addTextFrame("");

    // Supprimer le paragraphe par défaut existant
    txtFrm.getParagraphs().clear();

    // Première liste
    Paragraph paragraph1 = new Paragraph();
    paragraph1.setText("puce 2");
    paragraph1.getParagraphFormat().setDepth((short)4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)2);
    paragraph1.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph1);

    Paragraph paragraph2 = new Paragraph();
    paragraph2.setText("puce 3");
    paragraph2.getParagraphFormat().setDepth((short)4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)3);
    paragraph2.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph2);

    // Deuxième liste
    Paragraph paragraph5 = new Paragraph();
    paragraph5.setText("puce 5");
    paragraph5.getParagraphFormat().setDepth((short)4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith((short)5);
    paragraph5.getParagraphFormat().getBullet().setType(BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph5);

    pres.save(resourcesOutputPath + "SetCustomBulletsNumber-slides.pptx.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```