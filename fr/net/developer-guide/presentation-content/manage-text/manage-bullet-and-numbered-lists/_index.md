---
title: Gérer les listes à puces et numérotées
type: docs
weight: 70
url: /fr/net/manage-bullet-and-numbered-lists
keywords: "Puces, Listes à puces, Nombres, Listes numérotées, Puces image, Puces à plusieurs niveaux, Présentation PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Créer des listes à puces et numérotées dans une présentation PowerPoint en C# ou .NET"
---

Dans **Microsoft PowerPoint**, vous pouvez créer des listes à puces et numérotées de la même manière que dans Word et d'autres éditeurs de texte. **Aspose.Slides for .NET** vous permet également d'utiliser des puces et des numéros dans les diapositives de vos présentations. 

## **Pourquoi utiliser les listes à puces ?**

Les listes à puces vous aident à organiser et présenter l'information rapidement et efficacement. 

**Exemple de liste à puces**

Dans la plupart des cas, une liste à puces remplit ces trois fonctions principales :

- attire l'attention de vos lecteurs ou spectateurs sur les informations importantes
- permet à vos lecteurs ou spectateurs de parcourir facilement les points clés
- communique et transmet les détails importants de manière efficace.

## **Pourquoi utiliser les listes numérotées ?**

Les listes numérotées aident également à organiser et présenter l'information. Idéalement, vous devez utiliser des numéros (à la place des puces) lorsque l'ordre des éléments (par exemple, *étape 1, étape 2*, etc.) est important ou lorsqu'un élément doit être référencé (par exemple, *voir étape 3*).

**Exemple de liste numérotée**

Voici un résumé des étapes (étape 1 à étape 15) de la procédure **Creating Bullets** ci‑dessous :

1. Créez une instance de la classe Presentation. 
2. Effectuez plusieurs tâches (étape 3 à étape 14).
3. Enregistrez la présentation. 

## **Création de puces**

Pour créer une liste à puces, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Accédez à la diapositive (dans laquelle vous souhaitez ajouter une liste à puces) dans la collection de diapositives via l'objet [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index).
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) dans la diapositive sélectionnée.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) de la forme ajoutée.
5. Supprimez le paragraphe par défaut dans le [TextFrame]().
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph).
8. Définissez le type de puce sur Symbol puis définissez le caractère de la puce.
9. Définissez le texte du paragraphe.
10. Définissez l'indentation du paragraphe pour régler la puce.
11. Définissez la couleur de la puce.
12. Définissez la hauteur de la puce.
13. Ajoutez le paragraphe créé dans la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
14. Ajoutez le deuxième paragraphe et répétez les étapes 7 à 12.
15. Enregistrez la présentation.

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


## **Création de puces image**

Aspose.Slides for .NET vous permet de modifier les puces des listes à puces. Vous pouvez remplacer les puces par des symboles ou des images personnalisés. Si vous souhaitez ajouter un intérêt visuel à une liste ou attirer davantage l'attention sur les éléments d'une liste, vous pouvez utiliser votre propre image comme puce. 

{{% alert color="primary" %}} 
Idéalement, si vous envisagez de remplacer le symbole de puce standard par une image, vous devriez choisir une image graphique simple avec un fond transparent. De telles images fonctionnent le mieux comme symboles de puces personnalisés.

Dans tous les cas, l'image que vous choisissez sera réduite à une très petite taille, nous vous recommandons donc fortement de sélectionner une image qui reste esthétique (en remplacement du symbole de puce) dans une liste. 
{{% /alert %}} 

Pour créer une puce image, suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Accédez à la diapositive souhaitée dans la collection de diapositives en utilisant l'objet [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index).
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) dans la diapositive sélectionnée.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) de la forme ajoutée.
5. Supprimez le paragraphe par défaut dans le [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph).
7. Chargez l'image depuis le disque et ajoutez‑la à [Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/images), puis utilisez l'instance [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) qui a été renvoyée par la méthode [AddImage](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/methods/addimage/index).
8. Définissez le type de puce sur Picture puis définissez l'image.
9. Définissez le texte du paragraphe.
10. Définissez l'indentation du paragraphe pour régler la puce.
11. Définissez la couleur de la puce.
12. Définissez la hauteur des puces.
13. Ajoutez le paragraphe créé dans la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
14. Ajoutez le deuxième paragraphe et répétez les étapes 7 à 13.
15. Enregistrez la présentation.

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


## **Création de puces à plusieurs niveaux**

Pour créer une liste à puces contenant des éléments à différents niveaux — des listes supplémentaires sous la liste principale — suivez ces étapes :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Accédez à la diapositive souhaitée dans la collection de diapositives en utilisant l'objet [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index).
3. Ajoutez une [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) dans la diapositive sélectionnée.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) de la forme ajoutée.
5. Supprimez le paragraphe par défaut dans le [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) avec une profondeur réglée à 0.
7. Créez la deuxième instance de paragraphe en utilisant la classe Paragraph avec une profondeur réglée à 1.
8. Créez la troisième instance de paragraphe en utilisant la classe Paragraph avec une profondeur réglée à 2.
9. Créez la quatrième instance de paragraphe en utilisant la classe Paragraph avec une profondeur réglée à 3.
10. Ajoutez les paragraphes créés dans la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
11. Enregistrez la présentation.

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


## **Création de numéros**

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

**Les listes à puces et numérotées créées avec Aspose.Slides peuvent-elles être exportées vers d'autres formats tels que PDF ou images ?**

Oui, Aspose.Slides conserve entièrement le formatage et la structure des listes à puces et numérotées lors de l'exportation des présentations vers des formats tels que PDF, images et autres, garantissant des résultats cohérents.

**Est-il possible d'importer des listes à puces ou numérotées depuis des présentations existantes ?**

Oui, Aspose.Slides vous permet d'importer et de modifier des listes à puces ou numérotées depuis des présentations existantes tout en conservant leur formatage et apparence d'origine.

**Aspose.Slides prend-il en charge les listes à puces et numérotées dans des présentations créées dans plusieurs langues ?**

Oui, Aspose.Slides prend pleinement en charge les présentations multilingues, vous permettant de créer des listes à puces et numérotées dans n'importe quelle langue, y compris l'utilisation de caractères spéciaux ou non latins.