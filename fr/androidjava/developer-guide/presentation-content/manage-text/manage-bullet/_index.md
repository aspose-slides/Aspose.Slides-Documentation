---
title: Gérer les listes à puces et numérotées dans les présentations sur Android
linktitle: Gérer les listes
type: docs
weight: 60
url: /fr/androidjava/manage-bullet/
keywords:
- puce
- liste à puces
- liste numérotée
- puce de symbole
- puce image
- puce personnalisée
- liste à plusieurs niveaux
- créer une puce
- ajouter une puce
- ajouter une liste
- PowerPoint
- OpenDocument
- présentation
- Android
- Java
- Aspose.Slides
description: "Apprenez à gérer les listes à puces et numérotées dans les présentations PowerPoint et OpenDocument à l'aide d'Aspose.Slides pour Android via Java. Guide étape par étape."
---

Dans **Microsoft PowerPoint**, vous pouvez créer des listes à puces et numérotées de la même manière que dans Word et d’autres éditeurs de texte. **Aspose.Slides for Android via Java** vous permet également d’utiliser des puces et des numéros dans les diapositives de vos présentations.

## **Pourquoi utiliser les listes à puces ?**

Les listes à puces vous aident à organiser et à présenter l’information rapidement et efficacement. 

**Exemple de liste à puces**

Dans la plupart des cas, une liste à puces remplit ces trois fonctions principales :

- attire l’attention de vos lecteurs ou spectateurs sur des informations importantes  
- permet à vos lecteurs ou spectateurs de parcourir facilement les points clés  
- communique et transmet les détails importants de façon efficace.

## **Pourquoi utiliser les listes numérotées ?**

Les listes numérotées aident également à organiser et à présenter l’information. Idéalement, vous devez utiliser des chiffres (au lieu de puces) lorsque l’ordre des éléments (par exemple, *étape 1, étape 2*, etc.) est important ou lorsqu’un élément doit être référencé (par exemple, *voir l’étape 3*).

**Exemple de liste numérotée**

Voici un résumé des étapes (étape 1 à étape 15) de la procédure **Création de puces** ci‑dessous :

1. Créez une instance de la classe de présentation.  
2. Effectuez plusieurs tâches (étape 3 à étape 14).  
3. Enregistrez la présentation.  

## **Créer des puces**
Ce sujet fait également partie de la série sur la gestion des paragraphes de texte. Cette page illustre comment gérer les puces de paragraphe. Les puces sont utiles lorsqu’un élément doit être décrit étape par étape. De plus, le texte apparaît mieux organisé grâce aux puces. Les paragraphes à puces sont toujours plus faciles à lire et à comprendre. Nous verrons comment les développeurs peuvent exploiter cette petite mais puissante fonctionnalité d’Aspose.Slides for Android via Java. Suivez les étapes ci‑dessous pour gérer les puces de paragraphe avec Aspose.Slides for Android via Java :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).  
1. Accédez à la diapositive souhaitée dans la collection de diapositives à l’aide de l’objet [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide).  
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IPresentationText) sur la diapositive sélectionnée.  
1. Accédez au [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/TextFrame) de la forme ajoutée.  
1. Supprimez le paragraphe par défaut du TextFrame.  
1. Créez la première instance de paragraphe à l’aide de la classe [Paragraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Paragraph).  
1. Définissez le type de puce du paragraphe.  
1. Définissez le type de puce sur [Symbol](https://reference.aspose.com/slides/androidjava/com.aspose.slides/BulletType#Symbol) et indiquez le caractère de puce.  
1. Définissez le texte du paragraphe.  
1. Définissez le retrait du paragraphe pour positionner la puce.  
1. Définissez la couleur de la puce.  
1. Définissez la hauteur des puces.  
1. Ajoutez le paragraphe créé à la collection de paragraphes du TextFrame.  
1. Ajoutez le deuxième paragraphe et répétez le processus indiqué aux étapes **7 à 13**.  
1. Enregistrez la présentation.  

Ce code d’exemple en Java—une implémentation des étapes ci‑dessus—vous montre comment créer une liste à puces dans une diapositive :
```java
// Instancier une classe Presentation qui représente un fichier PPTX
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
    
    // Ajouter le paragraphe au cadre de texte
    txtFrm.getParagraphs().add(para);
    
    // enregistrer la présentation en tant que fichier PPTX
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Créer des puces image**

Aspose.Slides for Android via Java vous permet de modifier les puces des listes à puces. Vous pouvez remplacer les puces par des symboles ou des images personnalisées. Si vous souhaitez ajouter un attrait visuel à une liste ou attirer encore plus l’attention sur les éléments, vous pouvez utiliser votre propre image comme puce.

{{% alert color="primary" %}} 

Idéalement, si vous avez l’intention de remplacer le symbole de puce standard par une image, choisissez une petite illustration graphique avec un arrière‑plan transparent. Ces images fonctionnent le mieux comme symboles de puce personnalisés. 

Dans tous les cas, l’image sélectionnée sera réduite à une taille très petite, nous vous recommandons donc de choisir une image qui reste lisible (en tant que remplacement du symbole de puce) dans une liste. 

{{% /alert %}} 

Pour créer une puce image, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).  
1. Accédez à la diapositive souhaitée dans la collection de diapositives à l’aide de l’objet [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide).  
1. Ajoutez une autoshape sur la diapositive sélectionnée.  
1. Accédez au [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) de la forme ajoutée.  
1. Supprimez le paragraphe par défaut du [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).  
1. Créez la première instance de paragraphe à l’aide de la classe Paragraph.  
1. Chargez l’image depuis le disque dans [IPPImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ippimage/).  
1. Définissez le type de puce sur Picture et indiquez l’image.  
1. Définissez le texte du paragraphe.  
1. Définissez le retrait du paragraphe pour positionner la puce.  
1. Définissez la couleur de la puce.  
1. Définissez la hauteur des puces.  
1. Ajoutez le paragraphe créé à la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).  
1. Ajoutez le deuxième paragraphe et répétez le processus décrit aux étapes précédentes.  
1. Enregistrez la présentation.  

Ce code Java vous montre comment créer une puce image dans une diapositive :
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

    // Accéder au cadre texte de l'autoshape créé
    ITextFrame txtFrm = aShp.getTextFrame();
    // Supprimer le paragraphe existant par défaut
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

    // Enregistrer la présentation en fichier PPTX
    pres.save("Bullet.pptx", SaveFormat.Pptx);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Créer des puces à plusieurs niveaux**

Pour créer une liste à puces contenant des éléments à différents niveaux—des sous‑listes sous la liste principale—suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).  
1. Accédez à la diapositive souhaitée dans la collection de diapositives à l’aide de l’objet [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide).  
1. Ajoutez une autoshape sur la diapositive sélectionnée.  
1. Accédez au [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) de la forme ajoutée.  
1. Supprimez le paragraphe par défaut du [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).  
1. Créez la première instance de paragraphe avec la profondeur 0.  
1. Créez la deuxième instance de paragraphe avec la profondeur 1.  
1. Créez la troisième instance de paragraphe avec la profondeur 2.  
1. Créez la quatrième instance de paragraphe avec la profondeur 3.  
1. Ajoutez les paragraphes créés à la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).  
1. Enregistrez la présentation.  

Ce code, implémentation des étapes ci‑dessus, vous montre comment créer une liste à puces à plusieurs niveaux en Java :
```java
// Instancier une classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accéder à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Ajouter et accéder à l'Autoshape
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
    //Définir le niveau de la puce
    para1.getParagraphFormat().setDepth ((short)0);
    
    // Créer le deuxième paragraphe
    Paragraph para2 = new Paragraph();
    // Définir le style de puce du paragraphe et le symbole
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Définir le niveau de la puce
    para2.getParagraphFormat().setDepth ((short)1);
    
    // Créer le troisième paragraphe
    Paragraph para3 = new Paragraph();
    // Définir le style de puce du paragraphe et le symbole
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar((char) 8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Définir le niveau de la puce
    para3.getParagraphFormat().setDepth ((short)2);
    
    // Créer le quatrième paragraphe
    Paragraph para4 = new Paragraph();
    // Définir le style de puce du paragraphe et le symbole
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType ((byte)FillType.Solid);
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    //Définir le niveau de la puce
    para4.getParagraphFormat().setDepth ((short)3);
    
    // Ajouter le paragraphe au cadre texte
    txtFrm.getParagraphs().add(para1);
    txtFrm.getParagraphs().add(para2);
    txtFrm.getParagraphs().add(para3);
    txtFrm.getParagraphs().add(para4);
    
    // enregistrer la présentation en fichier PPTX
    pres.save("MultilevelBullet.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```


## **Créer des listes numérotées personnalisées**
Aspose.Slides for Android via Java fournit une API simple pour gérer les paragraphes avec un format de numérotation personnalisé. Pour ajouter une liste numérotée personnalisée dans un paragraphe, suivez les étapes ci‑dessus :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation).  
1. Accédez à la diapositive souhaitée dans la collection de diapositives à l’aide de l’objet [ISlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide).  
1. Ajoutez une autoshape sur la diapositive sélectionnée.  
1. Accédez au [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe) de la forme ajoutée.  
1. Supprimez le paragraphe par défaut du [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).  
1. Créez la première instance de paragraphe et définissez **NumberedBulletStartWith** à 2.  
1. Créez la deuxième instance de paragraphe et définissez **NumberedBulletStartWith** à 3.  
1. Créez la troisième instance de paragraphe et définissez **NumberedBulletStartWith** à 7.  
1. Ajoutez les paragraphes créés à la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/textframe).  
1. Enregistrez la présentation.  

Ce code Java vous montre comment créer une liste numérotée dans une diapositive :
```java
// Instancier une classe Presentation qui représente un fichier PPTX
Presentation pres = new Presentation();
try {
    // Accéder à la première diapositive
    ISlide slide = pres.getSlides().get_Item(0);

    // Ajouter et accéder à l'Autoshape
    IAutoShape aShp = slide.getShapes().addAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accéder au cadre texte de l'autoshape créé
    ITextFrame txtFrm = aShp.addTextFrame("");

    // Supprimer le paragraphe existant par défaut
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

Oui, Aspose.Slides conserve intégralement la mise en forme et la structure des listes à puces et numérotées lors de l’exportation des présentations vers des formats comme PDF, images et autres, garantissant des résultats cohérents.

**Est‑il possible d’importer des listes à puces ou numérotées depuis des présentations existantes ?**

Oui, Aspose.Slides permet d’importer et de modifier des listes à puces ou numérotées provenant de présentations existantes tout en conservant leur mise en forme et apparence d’origine.

**Aspose.Slides prend‑il en charge les listes à puces et numérotées dans des présentations créées en plusieurs langues ?**

Oui, Aspose.Slides prend pleinement en charge les présentations multilingues, vous permettant de créer des listes à puces et numérotées dans n’importe quelle langue, y compris l’utilisation de caractères spéciaux ou non latins.