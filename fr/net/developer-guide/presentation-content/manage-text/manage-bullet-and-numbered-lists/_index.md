---
title: Gérer les listes à puces et numérotées dans les présentations en .NET
linktitle: Gérer les listes
type: docs
weight: 70
url: /fr/net/manage-bullet-and-numbered-lists
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
- presentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à gérer les listes à puces et numérotées dans les présentations PowerPoint et OpenDocument à l’aide d’Aspose.Slides pour .NET. Guide étape par étape."
---

Dans **Microsoft PowerPoint**, vous pouvez créer des listes à puces et numérotées de la même façon que dans Word et d’autres éditeurs de texte. **Aspose.Slides for .NET** vous permet également d’utiliser des puces et des numéros dans les diapositives de vos présentations. 

## **Pourquoi utiliser les listes à puces ?**

Les listes à puces vous aident à organiser et présenter les informations rapidement et efficacement. 

**Exemple de liste à puces**

Dans la plupart des cas, une liste à puces remplit ces trois fonctions principales :

- attire l’attention de vos lecteurs ou spectateurs sur les informations importantes
- permets à vos lecteurs ou spectateurs de parcourir facilement les points clés
- communique et transmet les détails importants de façon efficace.

## **Pourquoi utiliser les listes numérotées ?**

Les listes numérotées aident également à organiser et présenter les informations. Idéalement, vous devez utiliser des chiffres (à la place des puces) lorsque l’ordre des entrées (par exemple, *étape 1, étape 2*, etc.) est important ou lorsqu’une entrée doit être référencée (par exemple, *voir étape 3*).

**Exemple de liste numérotée**

Voici un résumé des étapes (étape 1 à étape 15) de la procédure **Creating Bullets** ci‑dessous :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
2. Effectuez plusieurs tâches (étape 3 à étape 14).
3. Enregistrez la présentation. 

## **Créer des puces**

Pour créer une liste à puces, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
2. Accédez à la diapositive (dans laquelle vous voulez ajouter une liste à puces) dans la collection de diapositives via l’objet [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index). 
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) dans la diapositive sélectionnée. 
4. Accédez au [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) de la forme ajoutée. 
5. Supprimez le paragraphe par défaut dans le [TextFrame](). 
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph). 
8. Définissez le type de puce sur Symbol et définissez ensuite le caractère de la puce. 
9. Définissez le texte du paragraphe. 
10. Définissez l’indentation du paragraphe pour placer la puce. 
11. Définissez la couleur de la puce. 
12. Définissez la hauteur de la puce. 
13. Ajoutez le paragraphe créé dans la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe). 
14. Ajoutez le deuxième paragraphe et répétez les étapes 7‑12. 
15. Enregistrez la présentation. 

Ce code d’exemple en C#—une implémentation des étapes ci‑dessus—vous montre comment créer une liste à puces dans une diapositive :
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    paragraph.ParagraphFormat.Bullet.Char = '*';
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
    paragraph.ParagraphFormat.Bullet.Color.Color = Color.Red;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = "My text";

    textFrame.Paragraphs.Add(paragraph);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Créer des puces d’image**

**Aspose.Slides for .NET** vous permet de modifier les puces des listes à puces. Vous pouvez remplacer les puces par des symboles ou des images personnalisés. Si vous souhaitez ajouter un attrait visuel à une liste ou attirer encore plus l’attention sur les éléments d’une liste, vous pouvez utiliser votre propre image comme puce. 

{{% alert color="primary" %}} 

Idéalement, si vous avez l’intention de remplacer le symbole de puce standard par une image, vous devriez choisir une image graphique simple avec un fond transparent. De telles images fonctionnent le mieux comme symboles de puces personnalisés. 

Dans tous les cas, l’image que vous choisissez sera réduite à une taille très petite, nous vous recommandons donc vivement de sélectionner une image qui reste agréable (en tant que remplacement du symbole de puce) dans une liste. 

{{% /alert %}} 

Pour créer une puce d’image, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
2. Accédez à la diapositive désirée dans la collection de diapositives via l’objet [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index). 
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) dans la diapositive sélectionnée. 
4. Accédez au [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) de la forme ajoutée. 
5. Supprimez le paragraphe par défaut dans le [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe). 
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph). 
7. Chargez l’image depuis le disque et ajoutez‑la à [Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/images) puis utilisez l’instance [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) renvoyée par la méthode [AddImage](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/methods/addimage/index). 
8. Définissez le type de puce sur Picture puis définissez l’image. 
9. Définissez le texte du paragraphe. 
10. Définissez l’indentation du paragraphe pour placer la puce. 
11. Définissez la couleur de la puce. 
12. Définissez la hauteur des puces. 
13. Ajoutez le paragraphe créé dans la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe). 
14. Ajoutez le deuxième paragraphe et répétez les étapes 7‑13. 
15. Enregistrez la présentation. 

Ce code C# vous montre comment créer une puce d’image dans une diapositive :
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    paragraph.ParagraphFormat.Bullet.Picture.Image = image;
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = "My text";

    textFrame.Paragraphs.Add(paragraph);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Créer des puces à plusieurs niveaux**

Pour créer une liste à puces contenant des éléments à différents niveaux—des listes supplémentaires sous la liste principale—suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation). 
2. Accédez à la diapositive désirée dans la collection de diapositives via l’objet [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index). 
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) dans la diapositive sélectionnée. 
4. Accédez au [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) de la forme ajoutée. 
5. Supprimez le paragraphe par défaut dans le [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe). 
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) avec une profondeur définie à 0. 
7. Créez la deuxième instance de paragraphe en utilisant la classe Paragraph avec la profondeur définie à 1. 
8. Créez la troisième instance de paragraphe en utilisant la classe Paragraph avec la profondeur définie à 2. 
9. Créez la quatrième instance de paragraphe en utilisant la classe Paragraph avec la profondeur définie à 3. 
10. Ajoutez les paragraphes créés dans la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe). 
11. Enregistrez la présentation. 

Ce code, qui est une implémentation des étapes ci‑dessus, vous montre comment créer une liste à puces à plusieurs niveaux en C# :
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 300, 300);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Depth = 0;
    paragraph.Text = "My text Depth 0";
    textFrame.Paragraphs.Add(paragraph);
    
    Paragraph paragraph2 = new Paragraph();
    paragraph2.ParagraphFormat.Depth = 0;
    paragraph2.Text = "My text Depth 1";
    textFrame.Paragraphs.Add(paragraph2);
    
    Paragraph paragraph3 = new Paragraph();
    paragraph3.ParagraphFormat.Depth = 2;
    paragraph3.Text = "My text Depth 2";
    textFrame.Paragraphs.Add(paragraph3);
    
    Paragraph paragraph4 = new Paragraph();
    paragraph4.ParagraphFormat.Depth = 3;
    paragraph4.Text = "My text Depth 3";
    textFrame.Paragraphs.Add(paragraph4);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Créer des listes numérotées**

Ce code C# vous montre comment créer une liste numérotée dans une diapositive :
```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 100);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    paragraph.Text = "My text 1";
    textFrame.Paragraphs.Add(paragraph);
    
    Paragraph paragraph2 = new Paragraph();
    paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    paragraph2.Text = "My text 2";
    textFrame.Paragraphs.Add(paragraph2);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Les listes à puces et numérotées créées avec Aspose.Slides peuvent‑elles être exportées vers d’autres formats comme PDF ou images ?**

Oui, Aspose.Slides préserve entièrement la mise en forme et la structure des listes à puces et numérotées lors de l’exportation des présentations vers des formats tels que PDF, images et autres, garantissant des résultats cohérents.

**Est‑il possible d’importer des listes à puces ou numérotées à partir de présentations existantes ?**

Oui, Aspose.Slides vous permet d’importer et de modifier des listes à puces ou numérotées à partir de présentations existantes tout en préservant leur mise en forme et apparence d’origine.

**Aspose.Slides prend‑il en charge les listes à puces et numérotées dans des présentations créées en plusieurs langues ?**

Oui, Aspose.Slides prend pleinement en charge les présentations multilingues, vous permettant de créer des listes à puces et numérotées dans n’importe quelle langue, y compris l’utilisation de caractères spéciaux ou non latins.