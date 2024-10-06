---
title: Gérer les listes à puces et numérotées
type: docs
weight: 70
url: /net/manage-bullet-and-numbered-lists
keywords: "Puces, Listes à puces, Nombres, Listes numérotées, Puces d'image, puces multiniveaux, Présentation PowerPoint, C#, Csharp, Aspose.Slides pour .NET"
description: "Créer des listes à puces et numérotées dans une présentation PowerPoint en C# ou .NET"
---

Dans **Microsoft PowerPoint**, vous pouvez créer des listes à puces et numérotées de la même manière que dans Word et d'autres éditeurs de texte. **Aspose.Slides pour .NET** vous permet également d'utiliser des puces et des numéros dans les diapositives de vos présentations.

### Pourquoi utiliser des listes à puces ?

Les listes à puces vous aident à organiser et à présenter des informations rapidement et efficacement.

**Exemple de liste à puces**

Dans la plupart des cas, une liste à puces remplit ces trois fonctions principales :

- attire l'attention de vos lecteurs ou spectateurs sur des informations importantes
- permet à vos lecteurs ou spectateurs de repérer facilement les points clés
- communique et livre des détails importants de manière efficace.

### Pourquoi utiliser des listes numérotées ?

Les listes numérotées aident également à organiser et à présenter des informations. Idéalement, vous devriez utiliser des numéros (au lieu de puces) lorsque l'ordre des énoncés (par exemple, *étape 1, étape 2*, etc.) est important ou lorsqu'un énoncé doit être référencé (par exemple, *voir étape 3*).

**Exemple de liste numérotée**

Voici un résumé des étapes (étape 1 à étape 15) dans la procédure **Création de puces** ci-dessous :

1. Créer une instance de la classe de présentation. 
2. Effectuer plusieurs tâches (étape 3 à étape 14).
3. Enregistrer la présentation.

## Création de puces

Pour créer une liste à puces, suivez ces étapes :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Accéder à la diapositive (dans laquelle vous souhaitez ajouter une liste à puces) dans la collection de diapositives via l'objet [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index).
3. Ajouter un [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) dans la diapositive sélectionnée.
4. Accéder au [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) de la forme ajoutée.
5. Supprimer le paragraphe par défaut dans le [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
6. Créer la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph).
8. Définir le type de puce sur Symbole et ensuite définir le caractère de puce.
9. Définir le texte du paragraphe.
10. Définir l'indentation du paragraphe pour définir la puce.
11. Définir la couleur de la puce.
12. Définir la hauteur de la puce.
13. Ajouter le paragraphe créé dans la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
14. Ajouter le deuxième paragraphe et répéter les étapes 7-12.
15. Enregistrer la présentation.

Cet exemple de code en C#—une implémentation des étapes ci-dessus—vous montre comment créer une liste à puces dans une diapositive :

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
    paragraph.Text = "Mon texte";

    textFrame.Paragraphs.Add(paragraph);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## Création de puces d'image

Aspose.Slides pour .NET vous permet de changer les puces sur les listes à puces. Vous pouvez remplacer les puces par des symboles ou des images personnalisés. Si vous souhaitez ajouter un intérêt visuel à une liste ou attirer encore plus l'attention sur les éléments d'une liste, vous pouvez utiliser votre propre image comme puce.

 {{% alert color="primary" %}} 

Idéalement, si vous avez l'intention de remplacer le symbole de puce régulier par une image, vous voudrez peut-être sélectionner une image graphique simple avec un fond transparent. De telles images fonctionnent mieux comme symboles de puce personnalisés.

Dans tous les cas, l'image que vous choisissez sera réduite à une très petite taille, donc nous vous recommandons vivement de choisir une image qui a fière allure (en tant que remplacement du symbole de puce) dans une liste.

{{% /alert %}} 

Pour créer une puce d'image, suivez ces étapes :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Accéder à la diapositive désirée dans la collection de diapositives en utilisant l'objet [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index).
3. Ajouter un [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) dans la diapositive sélectionnée.
4. Accéder au [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) de la forme ajoutée.
5. Supprimer le paragraphe par défaut dans le [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
6. Créer la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph).
7. Charger l'image depuis le disque et l'ajouter à [Presentation.Images](https://reference.aspose.com/slides/net/aspose.slides/presentation/properties/images) puis utiliser l'instance [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage) qui a été renvoyée par la méthode [AddImage](https://reference.aspose.com/slides/net/aspose.slides/imagecollection/methods/addimage/index).
8. Définir le type de puce sur Image et ensuite définir l'image.
9. Définir le texte du paragraphe.
10. Définir l'indentation du paragraphe pour définir la puce.
11. Définir la couleur de la puce.
12. Définir la hauteur des puces.
13. Ajouter le paragraphe créé dans la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
14. Ajouter le deuxième paragraphe et répéter les étapes 7-13.
15. Enregistrer la présentation.

Ce code C# vous montre comment créer une puce d'image dans une diapositive :

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
    paragraph.Text = "Mon texte";

    textFrame.Paragraphs.Add(paragraph);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## Création de puces multiniveaux

Pour créer une liste à puces qui contient des éléments à différents niveaux—des listes supplémentaires sous la liste principale à puces—suivez ces étapes :

1. Créer une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Accéder à la diapositive désirée dans la collection de diapositives en utilisant l'objet [ISlide](https://reference.aspose.com/slides/net/aspose.slides/islide/methods/index).
3. Ajouter un [AutoShape](https://reference.aspose.com/slides/net/aspose.slides/autoshape) dans la diapositive sélectionnée.
4. Accéder au [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe) de la forme ajoutée.
5. Supprimer le paragraphe par défaut dans le [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
6. Créer la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph) et avec une profondeur définie à 0.
7. Créer la deuxième instance de paragraphe en utilisant la classe Paragraph et avec une profondeur définie à 1.
8. Créer la troisième instance de paragraphe en utilisant la classe Paragraph et avec une profondeur définie à 2.
9. Créer la quatrième instance de paragraphe en utilisant la classe Paragraph et avec une profondeur définie à 3.
10. Ajouter les paragraphes créés dans la collection de paragraphes du [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe).
11. Enregistrer la présentation.

Ce code, qui est une implémentation des étapes ci-dessus, vous montre comment créer une liste à puces multiniveaux en C# :

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 300, 300);
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Paragraphs.Clear();
    
    Paragraph paragraph = new Paragraph();
    paragraph.ParagraphFormat.Depth = 0;
    paragraph.Text = "Mon texte Profondeur 0";
    textFrame.Paragraphs.Add(paragraph);
    
    Paragraph paragraph2 = new Paragraph();
    paragraph2.ParagraphFormat.Depth = 0;
    paragraph2.Text = "Mon texte Profondeur 1";
    textFrame.Paragraphs.Add(paragraph2);
    
    Paragraph paragraph3 = new Paragraph();
    paragraph3.ParagraphFormat.Depth = 2;
    paragraph3.Text = "Mon texte Profondeur 2";
    textFrame.Paragraphs.Add(paragraph3);
    
    Paragraph paragraph4 = new Paragraph();
    paragraph4.ParagraphFormat.Depth = 3;
    paragraph4.Text = "Mon texte Profondeur 3";
    textFrame.Paragraphs.Add(paragraph4);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## Création de numéros

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
    paragraph.Text = "Mon texte 1";
    textFrame.Paragraphs.Add(paragraph);
    
    Paragraph paragraph2 = new Paragraph();
    paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    paragraph2.Text = "Mon texte 2";
    textFrame.Paragraphs.Add(paragraph2);
    
    // ...
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```