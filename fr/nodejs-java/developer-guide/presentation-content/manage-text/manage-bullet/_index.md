---
title: Gérer les puces
type: docs
weight: 60
url: /fr/nodejs-java/manage-bullet/
keywords: "Puces, Listes à puces, Nombres, Listes numérotées, Puces image, Puces à plusieurs niveaux, Présentation PowerPoint, Java, Aspose.Slides for Node.js via Java"
description: "Créer des listes à puces et numérotées dans une présentation PowerPoint en JavaScript"
---

Dans **Microsoft PowerPoint**, vous pouvez créer des listes à puces et numérotées de la même façon que dans Word et d’autres éditeurs de texte. **Aspose.Slides for Node.js via Java** vous permet également d’utiliser des puces et des numéros dans les diapositives de vos présentations.

## **Pourquoi utiliser les listes à puces ?**

Les listes à puces vous aident à organiser et présenter l’information rapidement et efficacement. 

**Exemple de liste à puces**

Dans la plupart des cas, une liste à puces remplit ces trois fonctions principales :

- attire l’attention de vos lecteurs ou spectateurs sur les informations importantes
- permet à vos lecteurs ou spectateurs de repérer facilement les points clés
- communique et transmet efficacement les détails importants.

## **Pourquoi utiliser les listes numérotées ?**

Les listes numérotées aident également à organiser et présenter l’information. Idéalement, vous devez utiliser des nombres (au lieu de puces) lorsque l’ordre des entrées (par exemple, *étape 1, étape 2*, etc.) est important ou lorsqu’une entrée doit être référencée (par exemple, *voir étape 3*).

**Exemple de liste numérotée**

Voici un résumé des étapes (étape 1 à étape 15) de la procédure **Creating Bullets** ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation). 
2. Accédez à la diapositive souhaitée dans la collection de diapositives à l’aide de l’objet [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide). 
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) dans la diapositive sélectionnée. 
4. Accédez au [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) de la forme ajoutée. 
5. Supprimez le paragraphe par défaut dans le TextFrame. 
6. Créez la première instance de paragraphe à l’aide de la classe [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph). 
7. Définissez le type de puce du paragraphe. 
8. Définissez le type de puce sur [Symbol](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BulletType#Symbol) et définissez le caractère de puce. 
9. Définissez le texte du paragraphe. 
10. Définissez l’indentation du paragraphe pour positionner la puce. 
11. Définissez la couleur de la puce. 
12. Définissez la hauteur des puces. 
13. Ajoutez le paragraphe créé dans la collection de paragraphes du TextFrame. 
14. Ajoutez le deuxième paragraphe et répétez le processus décrit aux étapes **7 à 13**. 
15. Enregistrez la présentation.

```javascript
// Instancier une classe Presentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accéder à la première diapositive
    var slide = pres.getSlides().get_Item(0);
    // Ajouter et accéder à l'AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Accéder au cadre texte de l'auto‑shape créé
    var txtFrm = aShp.getTextFrame();
    // Supprimer le paragraphe par défaut existant
    txtFrm.getParagraphs().removeAt(0);
    // Créer un paragraphe
    var para = new aspose.slides.Paragraph();
    // Définir le style de puce du paragraphe et le symbole
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para.getParagraphFormat().getBullet().setChar(8226);
    // Définir le texte du paragraphe
    para.setText("Welcome to Aspose.Slides");
    // Définir l'indentation de la puce
    para.getParagraphFormat().setIndent(25);
    // Définir la couleur de la puce
    para.getParagraphFormat().getBullet().getColor().setColorType(aspose.slides.ColorType.RGB);
    para.getParagraphFormat().getBullet().getColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // définir IsBulletHardColor à true pour utiliser une couleur de puce personnalisée
    para.getParagraphFormat().getBullet().isBulletHardColor();
    // Définir la hauteur de la puce
    para.getParagraphFormat().getBullet().setHeight(100);
    // Ajouter le paragraphe au cadre texte
    txtFrm.getParagraphs().add(para);
    // enregistrer la présentation en fichier PPTX
    pres.save("Bullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```


## **Création de puces**

Ce sujet fait également partie de la série sur la gestion des paragraphes de texte. Cette page illustre comment gérer les puces de paragraphe. Les puces sont particulièrement utiles lorsqu’un élément doit être décrit étape par étape. De plus, le texte apparaît bien organisé grâce à l’utilisation de puces. Les paragraphes à puces sont toujours plus faciles à lire et à comprendre. Nous verrons comment les développeurs peuvent exploiter cette fonctionnalité petite mais puissante d’Aspose.Slides for Node.js via Java. Veuillez suivre les étapes ci‑dessus pour gérer les puces de paragraphe avec Aspose.Slides for Node.js via Java :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation). 
1. Accédez à la diapositive souhaitée dans la collection de diapositives à l’aide de l’objet [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide). 
1. Ajoutez une [AutoShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/AutoShape) dans la diapositive sélectionnée. 
1. Accédez au [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) de la forme ajoutée. 
1. Supprimez le paragraphe par défaut dans le TextFrame. 
1. Créez la première instance de paragraphe à l’aide de la classe [Paragraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Paragraph). 
1. Définissez le type de puce du paragraphe. 
1. Définissez le type de puce sur [Symbol](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BulletType#Symbol) et définissez le caractère de puce. 
1. Définissez le texte du paragraphe. 
1. Définissez l’indentation du paragraphe pour positionner la puce. 
1. Définissez la couleur de la puce. 
1. Définissez la hauteur des puces. 
1. Ajoutez le paragraphe créé dans la collection de paragraphes du TextFrame. 
1. Ajoutez le deuxième paragraphe et répétez le processus décrit aux étapes **7 à 13**. 
1. Enregistrez la présentation.

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Accéder à la première diapositive
    var slide = pres.getSlides().get_Item(0);
    // Instancier l'image pour les puces
    var picture;
    var image = aspose.slides.Images.fromFile("asp1.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Ajouter et accéder à l'Autoshape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Accéder au cadre texte de l'autoshape créé
    var txtFrm = aShp.getTextFrame();
    // Supprimer le paragraphe existant par défaut
    txtFrm.getParagraphs().removeAt(0);
    // Créer un nouveau paragraphe
    var para = new aspose.slides.Paragraph();
    para.setText("Welcome to Aspose.Slides");
    // Définir le style de puce du paragraphe et l'image
    para.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Picture);
    para.getParagraphFormat().getBullet().getPicture().setImage(picture);
    // Définir la hauteur de la puce
    para.getParagraphFormat().getBullet().setHeight(100);
    // Ajouter le paragraphe au cadre texte
    txtFrm.getParagraphs().add(para);
    // Enregistrer la présentation en fichier PPTX
    pres.save("Bullet.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Création de puces d’image**

Aspose.Slides for Node.js via Java vous permet de modifier les puces des listes à puces. Vous pouvez remplacer les puces par des symboles ou des images personnalisés. Si vous souhaitez ajouter un intérêt visuel à une liste ou attirer davantage l’attention sur les éléments d’une liste, vous pouvez utiliser votre propre image comme puce.

{{% alert color="primary" %}} 

Idéalement, si vous prévoyez de remplacer le symbole de puce standard par une image, il est conseillé de choisir une image graphique simple avec un fond transparent. De telles images fonctionnent le mieux comme symboles de puce personnalisés. 

Dans tous les cas, l’image que vous choisissez sera réduite à une très petite taille, nous vous recommandons donc fortement de sélectionner une image qui rend bien (comme remplacement du symbole de puce) dans une liste. 

{{% /alert %}} 

Pour créer une puce image, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation). 
1. Accédez à la diapositive souhaitée dans la collection de diapositives à l’aide de l’objet [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide). 
1. Ajoutez une autoshape dans la diapositive sélectionnée. 
1. Accédez au [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) de la forme ajoutée. 
1. Supprimez le paragraphe par défaut dans le [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe). 
1. Créez la première instance de paragraphe à l’aide de la classe Paragraph. 
1. Chargez une image depuis le disque dans [PPImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/nterfaces/PPImage). 
1. Définissez le type de puce sur Picture et définissez l’image. 
1. Définissez le texte du paragraphe. 
1. Définissez l’indentation du paragraphe pour positionner la puce. 
1. Définissez la couleur de la puce. 
1. Définissez la hauteur des puces. 
1. Ajoutez le paragraphe créé dans la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe). 
1. Ajoutez le deuxième paragraphe et répétez le processus décrit aux étapes précédentes. 
1. Enregistrez la présentation.

```javascript
// Instancier une classe Presentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accéder à la première diapositive
    var slide = pres.getSlides().get_Item(0);
    // Ajouter et accéder à l'AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Accéder au cadre texte de l'autoshape créé
    var txtFrm = aShp.addTextFrame("");
    // Supprimer le paragraphe par défaut existant
    txtFrm.getParagraphs().clear();
    // Créer le premier paragraphe
    var para1 = new aspose.slides.Paragraph();
    // Définir le style de puce du paragraphe et le symbole
    para1.setText("Content");
    para1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para1.getParagraphFormat().getBullet().setChar(8226);
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para1.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Définir le niveau de la puce
    para1.getParagraphFormat().setDepth(0);
    // Créer le deuxième paragraphe
    var para2 = new aspose.slides.Paragraph();
    // Définir le style de puce du paragraphe et le symbole
    para2.setText("Second level");
    para2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para2.getParagraphFormat().getBullet().setChar('-');
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para2.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Définir le niveau de la puce
    para2.getParagraphFormat().setDepth(1);
    // Créer le troisième paragraphe
    var para3 = new aspose.slides.Paragraph();
    // Définir le style de puce du paragraphe et le symbole
    para3.setText("Third level");
    para3.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para3.getParagraphFormat().getBullet().setChar(8226);
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para3.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Définir le niveau de la puce
    para3.getParagraphFormat().setDepth(2);
    // Créer le quatrième paragraphe
    var para4 = new aspose.slides.Paragraph();
    // Définir le style de puce du paragraphe et le symbole
    para4.setText("Fourth Level");
    para4.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Symbol);
    para4.getParagraphFormat().getBullet().setChar('-');
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    para4.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    // Définir le niveau de la puce
    para4.getParagraphFormat().setDepth(3);
    // Ajouter le paragraphe au cadre texte
    txtFrm.getParagraphs().add(para1);
    txtFrm.getParagraphs().add(para2);
    txtFrm.getParagraphs().add(para3);
    txtFrm.getParagraphs().add(para4);
    // enregistrer la présentation en fichier PPTX
    pres.save("MultilevelBullet.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Création de puces à plusieurs niveaux**

Pour créer une liste à puces contenant des éléments à différents niveaux—des listes supplémentaires sous la liste principale—suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation). 
1. Accédez à la diapositive souhaitée dans la collection de diapositives à l’aide de l’objet [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide). 
1. Ajoutez une autoshape dans la diapositive sélectionnée. 
1. Accédez au [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) de la forme ajoutée. 
1. Supprimez le paragraphe par défaut dans le [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe). 
1. Créez la première instance de paragraphe à l’aide de la classe Paragraph avec une profondeur de 0. 
1. Créez la deuxième instance de paragraphe à l’aide de la classe Paragraph avec une profondeur de 1. 
1. Créez la troisième instance de paragraphe à l’aide de la classe Paragraph avec une profondeur de 2. 
1. Créez la quatrième instance de paragraphe à l’aide de la classe Paragraph avec une profondeur de 3. 
1. Ajoutez les paragraphes créés dans la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe). 
1. Enregistrez la présentation.

```javascript
// Instancier une classe Presentation qui représente un fichier PPTX
var pres = new aspose.slides.Presentation();
try {
    // Accéder à la première diapositive
    var slide = pres.getSlides().get_Item(0);
    // Ajouter et accéder à l'AutoShape
    var aShp = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 200, 400, 200);
    // Accéder au cadre texte de l'auto‑shape créé
    var txtFrm = aShp.addTextFrame("");
    // Supprimer le paragraphe par défaut existant
    txtFrm.getParagraphs().clear();
    // Première liste
    var paragraph1 = new aspose.slides.Paragraph();
    paragraph1.setText("bullet 2");
    paragraph1.getParagraphFormat().setDepth(4);
    paragraph1.getParagraphFormat().getBullet().setNumberedBulletStartWith(2);
    paragraph1.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph1);
    var paragraph2 = new aspose.slides.Paragraph();
    paragraph2.setText("bullet 3");
    paragraph2.getParagraphFormat().setDepth(4);
    paragraph2.getParagraphFormat().getBullet().setNumberedBulletStartWith(3);
    paragraph2.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph2);
    // Deuxième liste
    var paragraph5 = new aspose.slides.Paragraph();
    paragraph5.setText("bullet 5");
    paragraph5.getParagraphFormat().setDepth(4);
    paragraph5.getParagraphFormat().getBullet().setNumberedBulletStartWith(5);
    paragraph5.getParagraphFormat().getBullet().setType(aspose.slides.BulletType.Numbered);
    txtFrm.getParagraphs().add(paragraph5);
    pres.save(resourcesOutputPath + "SetCustomBulletsNumber-slides.pptx.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Créer une liste numérotée personnalisée**

Aspose.Slides for Node.js via Java fournit une API simple pour gérer les paragraphes avec un format de numérotation personnalisé. Pour ajouter une liste numérotée personnalisée dans un paragraphe, suivez les étapes ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation). 
1. Accédez à la diapositive souhaitée dans la collection de diapositives à l’aide de l’objet [Slide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slide). 
1. Ajoutez une autoshape dans la diapositive sélectionnée. 
1. Accédez au [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe) de la forme ajoutée. 
1. Supprimez le paragraphe par défaut dans le [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe). 
1. Créez la première instance de paragraphe à l’aide de la classe Paragraph et définissez **NumberedBulletStartWith** à 2. 
1. Créez la deuxième instance de paragraphe à l’aide de la classe Paragraph et définissez **NumberedBulletStartWith** à 3. 
1. Créez la troisième instance de paragraphe à l’aide de la classe Paragraph et définissez **NumberedBulletStartWith** à 7. 
1. Ajoutez les paragraphes créés dans la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe). 
1. Enregistrez la présentation.

## **FAQ**

**Les listes à puces et numérotées créées avec Aspose.Slides peuvent-elles être exportées vers d’autres formats tels que PDF ou images ?**

Oui, Aspose.Slides préserve entièrement le formatage et la structure des listes à puces et numérotées lors de l’exportation des présentations vers des formats tels que PDF, images, etc., garantissant des résultats cohérents.

**Est‑il possible d’importer des listes à puces ou numérotées à partir de présentations existantes ?**

Oui, Aspose.Slides vous permet d’importer et de modifier les listes à puces ou numérotées à partir de présentations existantes tout en conservant leur formatage et leur apparence d’origine.

**Aspose.Slides prend‑il en charge les listes à puces et numérotées dans des présentations créées en plusieurs langues ?**

Oui, Aspose.Slides prend pleinement en charge les présentations multilingues, vous permettant de créer des listes à puces et numérotées dans n’importe quelle langue, y compris l’utilisation de caractères spéciaux ou non latins.