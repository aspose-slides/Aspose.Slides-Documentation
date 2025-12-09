---
title: Gérer les paragraphes de texte PowerPoint en .NET
linktitle: Gérer le paragraphe
type: docs
weight: 40
url: /fr/net/manage-paragraph/
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
- texte en HTML
- paragraphe en HTML
- paragraphe en image
- texte en image
- exporter le paragraphe
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Maîtrisez le formatage des paragraphes avec Aspose.Slides pour .NET — optimisez l'alignement, l'espacement et le style dans les présentations PPT, PPTX et ODP en C#."
---

Aspose.Slides fournit toutes les interfaces et classes dont vous avez besoin pour travailler avec les textes, paragraphes et portions de PowerPoint en C#.

* Aspose.Slides fournit l’interface [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) pour vous permettre d’ajouter des objets qui représentent un paragraphe. Un objet `ITextFame` peut contenir un ou plusieurs paragraphes (chaque paragraphe est créé par un retour chariot).
* Aspose.Slides fournit l’interface [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) pour vous permettre d’ajouter des objets qui représentent des portions. Un objet `IParagraph` peut contenir une ou plusieurs portions (collection d’objets iPortions).
* Aspose.Slides fournit l’interface [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) pour vous permettre d’ajouter des objets qui représentent des textes et leurs propriétés de formatage. 

Un objet `IParagraph` est capable de gérer des textes avec différentes propriétés de formatage grâce à ses objets sous‑jacents `IPortion`.

## **Ajouter plusieurs paragraphes contenant plusieurs portions**

Ces étapes montrent comment ajouter un cadre de texte contenant 3 paragraphes et chaque paragraphe contenant 3 portions :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Accédez à la référence de la diapositive concernée via son index.
3. Ajoutez un rectangle [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
4. Récupérez le ITextFrame associé au [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
5. Créez deux objets [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) et ajoutez‑les à la collection `IParagraphs` du [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
6. Créez trois objets [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) pour chaque nouveau `IParagraph` (deux objets Portion pour le paragraphe par défaut) et ajoutez chaque objet `IPortion` à la collection IPortion de chaque `IParagraph`.
7. Définissez un texte pour chaque portion.
8. Appliquez les fonctionnalités de formatage souhaitées à chaque portion en utilisant les propriétés de formatage exposées par l’objet `IPortion`.
9. Enregistrez la présentation modifiée.

Ce code C# est une implémentation des étapes pour ajouter des paragraphes contenant des portions :
```c#
// Instancie une classe Presentation qui représente un fichier PPTX
using (Presentation pres = new Presentation())
{
    // Accède à la première diapositive
    ISlide slide = pres.Slides[0];

    // Ajoute un IAutoShape Rectangle
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Accède au TextFrame de l'AutoShape
    ITextFrame tf = ashp.TextFrame;

    // Crée des Paragraphes et des Portions avec différents formats de texte
    IParagraph para0 = tf.Paragraphs[0];
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.Portions.Add(port01);
    para0.Portions.Add(port02);

    IParagraph para1 = new Paragraph();
    tf.Paragraphs.Add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.Portions.Add(port10);
    para1.Portions.Add(port11);
    para1.Portions.Add(port12);

    IParagraph para2 = new Paragraph();
    tf.Paragraphs.Add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.Portions.Add(port20);
    para2.Portions.Add(port21);
    para2.Portions.Add(port22);

    for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
        {
            tf.Paragraphs[i].Portions[j].Text = "Portion0" + j.ToString();
            if (j == 0)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontBold = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 15;
            }
            else if (j == 1)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontItalic = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 18;
            }
        }
    // Enregistre la présentation modifiée
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);

}
```


## **Gérer les puces de paragraphe**
Les listes à puces vous aident à organiser et présenter l’information rapidement et efficacement. Les paragraphes à puces sont toujours plus faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Accédez à la référence de la diapositive concernée via son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive sélectionnée.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) de l’autoshape. 
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/).
8. Définissez le `Type` de la puce du paragraphe sur `Symbol` et indiquez le caractère de la puce.
9. Définissez le `Text` du paragraphe.
10. Définissez l’`Indent` du paragraphe pour la puce.
11. Définissez une couleur pour la puce.
12. Définissez une hauteur pour la puce.
13. Ajoutez le nouveau paragraphe à la collection de paragraphes du `TextFrame`.
14. Ajoutez le deuxième paragraphe et répétez le processus décrit aux étapes 7 à 13.
15. Enregistrez la présentation.

Ce code C# montre comment ajouter une puce de paragraphe :
```c#
// Instancie une classe Presentation qui représente un fichier PPTX
using (Presentation pres = new Presentation())
{

    // Accède à la première diapositive
    ISlide slide = pres.Slides[0];


    // Ajoute et accède à l'Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accède au cadre de texte de l'autoshape
    ITextFrame txtFrm = aShp.TextFrame;

    // Supprime le paragraphe par défaut
    txtFrm.Paragraphs.RemoveAt(0);

    // Crée un paragraphe
    Paragraph para = new Paragraph();

    // Définit le style et le symbole de puce du paragraphe
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // Définit le texte du paragraphe
    para.Text = "Welcome to Aspose.Slides";

    // Définit le retrait de la puce
    para.ParagraphFormat.Indent = 25;

    // Définit la couleur de la puce
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // définir IsBulletHardColor à true pour utiliser une couleur de puce personnalisée

    // Définit la hauteur de la puce
    para.ParagraphFormat.Bullet.Height = 100;

    // Ajoute le paragraphe au cadre de texte
    txtFrm.Paragraphs.Add(para);

    // Crée le deuxième paragraphe
    Paragraph para2 = new Paragraph();

    // Définit le type et le style de puce du paragraphe
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // Ajoute le texte du paragraphe
    para2.Text = "This is numbered bullet";

    // Définit le retrait de la puce
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // définir IsBulletHardColor à true pour utiliser une couleur de puce personnalisée

    // Définit la hauteur de la puce
    para2.ParagraphFormat.Bullet.Height = 100;

    // Ajoute le paragraphe au cadre de texte
    txtFrm.Paragraphs.Add(para2);


    // Enregistre la présentation modifiée
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```


## **Gérer les puces d’image**
Les listes à puces vous aident à organiser et présenter l’information rapidement et efficacement. Les paragraphes avec image sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Accédez à la référence de la diapositive concernée via son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) de l’autoshape.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe en utilisant la classe [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/).
7. Chargez l’image dans [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/).
8. Définissez le type de puce sur [Picture](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) et indiquez l’image.
9. Définissez le `Text` du paragraphe.
10. Définissez l’`Indent` du paragraphe pour la puce.
11. Définissez une couleur pour la puce.
12. Définissez une hauteur pour la puce.
13. Ajoutez le nouveau paragraphe à la collection de paragraphes du `TextFrame`.
14. Ajoutez le deuxième paragraphe et répétez le processus basé sur les étapes précédentes.
15. Enregistrez la présentation modifiée.

Ce code C# montre comment ajouter et gérer des puces d’image :
```c#
 // Instancie une classe Presentation qui représente un fichier PPTX
 Presentation presentation = new Presentation();

 // Accède à la première diapositive
 ISlide slide = presentation.Slides[0];

 // Instancie l'image pour les puces
 IImage image = Images.FromFile("bullets.png");
 IPPImage ippxImage = presentation.Images.AddImage(image);
 image.Dispose();

 // Ajoute et accède à l'AutoShape
 IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

 // Accède au cadre de texte de l'autoshape
 ITextFrame textFrame = autoShape.TextFrame;

 // Supprime le paragraphe par défaut
 textFrame.Paragraphs.RemoveAt(0);

 // Crée un nouveau paragraphe
 Paragraph paragraph = new Paragraph();
 paragraph.Text = "Welcome to Aspose.Slides";

 // Définit le style de puce du paragraphe et l'image
 paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
 paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

 // Définit la hauteur de la puce
 paragraph.ParagraphFormat.Bullet.Height = 100;

 // Ajoute le paragraphe au cadre de texte
 textFrame.Paragraphs.Add(paragraph);

 // Enregistre la présentation au format PPTX
 presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

 // Enregistre la présentation au format PPT
 presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```


## **Gérer les puces multiniveaux**
Les listes à puces vous aident à organiser et présenter l’information rapidement et efficacement. Les puces multiniveaux sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
2. Accédez à la référence de la diapositive concernée via son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) dans la nouvelle diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) de l’autoshape.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) et définissez la profondeur à 0.
7. Créez la deuxième instance de paragraphe via la classe `Paragraph` et définissez la profondeur à 1.
8. Créez la troisième instance de paragraphe via la classe `Paragraph` et définissez la profondeur à 2.
9. Créez la quatrième instance de paragraphe via la classe `Paragraph` et définissez la profondeur à 3.
10. Ajoutez les nouveaux paragraphes à la collection de paragraphes du `TextFrame`.
11. Enregistrez la présentation modifiée.

Ce code C# montre comment ajouter et gérer des puces multiniveaux :
```c#
// Instancie une classe Presentation qui représente un fichier PPTX
using (Presentation pres = new Presentation())
{

    // Accède à la première diapositive
    ISlide slide = pres.Slides[0];
    
    // Ajoute et accède à l'AutoShape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accède au cadre de texte de l'AutoShape créé
    ITextFrame text = aShp.AddTextFrame("");
    
    // Supprime le paragraphe par défaut
    text.Paragraphs.Clear();

    // Ajoute le premier paragraphe
    IParagraph para1 = new Paragraph();
    para1.Text = "Content";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Définit le niveau de la puce
    para1.ParagraphFormat.Depth = 0;

    // Ajoute le deuxième paragraphe
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Définit le niveau de la puce
    para2.ParagraphFormat.Depth = 1;

    // Ajoute le troisième paragraphe
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Définit le niveau de la puce
    para3.ParagraphFormat.Depth = 2;

    // Ajoute le quatrième paragraphe
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Définit le niveau de la puce
    para4.ParagraphFormat.Depth = 3;

    // Ajoute les paragraphes à la collection
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // Enregistre la présentation au format PPTX
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Gérer les paragraphes avec une liste numérotée personnalisée**
L’interface [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) fournit la propriété [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith) et d’autres options qui vous permettent de gérer des paragraphes avec une numérotation ou un formatage personnalisés. 

1. Créez une instance de la classe [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation)class.
2. Accédez à la diapositive contenant le paragraphe.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) de l’autoshape.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) et définissez [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith) à 2.
7. Créez la deuxième instance de paragraphe via la classe `Paragraph` et définissez `NumberedBulletStartWith` à 3.
8. Créez la troisième instance de paragraphe via la classe `Paragraph` et définissez `NumberedBulletStartWith` à 7.
9. Ajoutez les nouveaux paragraphes à la collection de paragraphes du `TextFrame`.
10. Enregistrez la présentation modifiée.

Ce code C# montre comment ajouter et gérer des paragraphes avec une numérotation ou un formatage personnalisés :
```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// Accède au cadre de texte de l'autoshape créé
	ITextFrame textFrame = shape.TextFrame;

	// Supprime le paragraphe existant par défaut
	textFrame.Paragraphs.RemoveAt(0);

	// Première liste
	var paragraph1 = new Paragraph { Text = "bullet 2" };
	paragraph1.ParagraphFormat.Depth = 4; 
	paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
	paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph1);

	var paragraph2 = new Paragraph { Text = "bullet 3" };
	paragraph2.ParagraphFormat.Depth = 4;
	paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = 3; 
	paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;  
	textFrame.Paragraphs.Add(paragraph2);

	
	var paragraph5 = new Paragraph { Text = "bullet 7" };
	paragraph5.ParagraphFormat.Depth = 4;
	paragraph5.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
	paragraph5.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph5);

	presentation.Save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
}
```


## **Définir l’indent du paragraphe**
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Accédez à la référence de la diapositive concernée via son index.
1. Ajoutez un rectangle [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
1. Ajoutez un [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) contenant trois paragraphes au rectangle autoshape.
1. Masquez les lignes du rectangle.
1. Définissez l’indent pour chaque [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) via sa propriété BulletOffset.
1. Enregistrez la présentation modifiée sous forme de fichier PPT.

Ce code C# montre comment définir un indent de paragraphe :
```c#
 // Instancier la classe Presentation
 Presentation pres = new Presentation();

 // Obtient la première diapositive
 ISlide sld = pres.Slides[0];

 // Ajoute une forme Rectangle
 IAutoShape rect = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);

 // Ajoute un TextFrame au Rectangle
 ITextFrame tf = rect.AddTextFrame("This is first line \rThis is second line \rThis is third line");

 // Définit le texte pour s'ajuster à la forme
 tf.TextFrameFormat.AutofitType = TextAutofitType.Shape;

 // Masque les bordures du Rectangle
 rect.LineFormat.FillFormat.FillType = FillType.Solid;

 // Obtient le premier paragraphe du TextFrame et définit son retrait
 IParagraph para1 = tf.Paragraphs[0];

 // Définit le style de puce du paragraphe et le symbole
 para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
 para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
 para1.ParagraphFormat.Alignment = TextAlignment.Left;

 para1.ParagraphFormat.Depth = 2;
 para1.ParagraphFormat.Indent = 30;

 // Obtient le deuxième paragraphe du TextFrame et définit son retrait
 IParagraph para2 = tf.Paragraphs[1];
 para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
 para2.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
 para2.ParagraphFormat.Alignment = TextAlignment.Left;
 para2.ParagraphFormat.Depth = 2;
 para2.ParagraphFormat.Indent = 40;

 // Obtient le troisième paragraphe du TextFrame et définit son retrait
 IParagraph para3 = tf.Paragraphs[2];
 para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
 para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
 para3.ParagraphFormat.Alignment = TextAlignment.Left;
 para3.ParagraphFormat.Depth = 2;
 para3.ParagraphFormat.Indent = 50;

 // Enregistre la présentation sur le disque
 pres.Save("InOutDent_out.pptx", SaveFormat.Pptx);
```


## **Définir un retrait suspendu pour le paragraphe**

Ce code C# montre comment définir le retrait suspendu pour un paragraphe :  
```c#
using (Presentation pres = new Presentation())
{
    var autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 250, 550, 150);

    Paragraph para1 = new Paragraph
    {
        Text = "Example"
    };
    Paragraph para2 = new Paragraph
    {
        Text = "Set Hanging Indent for Paragraph"
    };
    Paragraph para3 = new Paragraph
    {
        Text = "This C# code shows you how to set the hanging indent for a paragraph: "
    };

    para2.ParagraphFormat.MarginLeft = 10f;
    para3.ParagraphFormat.MarginLeft = 20f;
    
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Gérer les propriétés de fin de paragraphe pour le paragraphe**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez la référence de la diapositive contenant le paragraphe via sa position.
1. Ajoutez un rectangle [autoshape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) à la diapositive.
1. Ajoutez un [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) contenant deux paragraphes au rectangle.
1. Définissez le `FontHeight` et le type de police pour les paragraphes.
1. Définissez les propriétés de fin pour les paragraphes.
1. Enregistrez la présentation modifiée sous forme de fichier PPTX.

Ce code C# montre comment définir les propriétés de fin pour les paragraphes dans PowerPoint :
```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

	Paragraph para1 = new Paragraph();
	para1.Portions.Add(new Portion("Sample text"));

	Paragraph para2 = new Paragraph();
	para2.Portions.Add(new Portion("Sample text 2"));
	PortionFormat endParagraphPortionFormat = new PortionFormat();
	endParagraphPortionFormat.FontHeight = 48;
	endParagraphPortionFormat.LatinFont = new FontData("Times New Roman");
	para2.EndParagraphPortionFormat = endParagraphPortionFormat;

	shape.TextFrame.Paragraphs.Add(para1);
	shape.TextFrame.Paragraphs.Add(para2);

	pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Importer du texte HTML dans les paragraphes**
Aspose.Slides offre un support amélioré pour l’importation de texte HTML dans les paragraphes.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Accédez à la référence de la diapositive concernée via son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) à la diapositive.
4. Ajoutez et accédez à l’[ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) de l’autoshape.
5. Supprimez le paragraphe par défaut dans le `ITextFrame`.
6. Lisez le fichier HTML source dans un TextReader.
7. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/).
8. Ajoutez le contenu du fichier HTML lu par le TextReader à la [ParagraphCollection](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/) du TextFrame.
9. Enregistrez la présentation modifiée.

Ce code C# est une implémentation des étapes pour importer des textes HTML dans des paragraphes :
```c#
// Crée une instance de présentation vide
using (Presentation pres = new Presentation())
{
    // Accède à la première diapositive par défaut de la présentation
    ISlide slide = pres.Slides[0];

    // Ajoute l'AutoShape pour contenir le contenu HTML
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // Ajoute un cadre de texte à la forme
    ashape.AddTextFrame("");

    // Efface tous les paragraphes du cadre de texte ajouté
    ashape.TextFrame.Paragraphs.Clear();

    // Charge le fichier HTML à l'aide d'un StreamReader
    TextReader tr = new StreamReader("file.html");

    // Ajoute le texte du stream reader HTML dans le cadre de texte
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // Enregistre la présentation
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Exporter le texte des paragraphes vers HTML**
Aspose.Slides offre un support amélioré pour l’exportation de textes (contenus dans les paragraphes) vers HTML.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) et chargez la présentation souhaitée.
2. Accédez à la référence de la diapositive concernée via son index.
3. Accédez à la forme contenant le texte qui sera exporté vers HTML.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) de la forme.
5. Créez une instance de `StreamWriter` et ajoutez le nouveau fichier HTML.
6. Fournissez un indice de départ au StreamWriter et exportez les paragraphes souhaités.

Ce code C# montre comment exporter les textes de paragraphes PowerPoint vers HTML :
```c#
// Charge le fichier de présentation
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{
    // Accède à la première diapositive par défaut de la présentation
    ISlide slide = pres.Slides[0];

    // Accède à l'index requis
    int index = 0;

    // Accède à la forme ajoutée
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // Écrit les données des paragraphes en HTML en spécifiant l'index de début du paragraphe et le nombre de paragraphes à copier
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```


## **Enregistrer un paragraphe sous forme d’image**

Dans cette section, nous explorerons deux exemples montrant comment enregistrer un paragraphe de texte, représenté par l’interface [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/), sous forme d’image. Les deux exemples incluent l’obtention de l’image d’une forme contenant le paragraphe à l’aide des méthodes `GetImage` de l’interface [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), le calcul des limites du paragraphe au sein de la forme, et l’exportation sous forme d’image bitmap. Ces approches vous permettent d’extraire des parties spécifiques du texte d’une présentation PowerPoint et de les enregistrer en tant qu’images séparées, ce qui peut être utile pour diverses utilisations.

Supposons que nous disposions d’un fichier de présentation nommé sample.pptx contenant une diapositive, où la première forme est une zone de texte contenant trois paragraphes.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Exemple 1**

Dans cet exemple, nous obtenons le deuxième paragraphe sous forme d’image. Pour ce faire, nous extrayons l’image de la forme de la première diapositive de la présentation, puis nous calculons les limites du deuxième paragraphe dans le cadre de texte de la forme. Le paragraphe est ensuite redessiné sur une nouvelle image bitmap, qui est enregistrée au format PNG. Cette méthode est particulièrement utile lorsqu’il faut enregistrer un paragraphe précis en tant qu’image séparée tout en conservant les dimensions et le formatage exacts du texte.
```csharp
using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Save the shape in memory as a bitmap.
using var shapeImage = firstShape.GetImage();
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Create a shape bitmap from memory.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calculate the boundaries of the second paragraph.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();

// Calculate the size for the output image (minimum size - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepare a bitmap for the paragraph.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```


Le résultat :

![The paragraph image](paragraph_to_image_output.png)

**Exemple 2**

Dans cet exemple, nous étendons l’approche précédente en ajoutant des facteurs d’échelle à l’image du paragraphe. La forme est extraite de la présentation et enregistrée sous forme d’image avec un facteur d’échelle de `2`. Cela permet d’obtenir une sortie en haute résolution lors de l’exportation du paragraphe. Les limites du paragraphe sont alors calculées en tenant compte de l’échelle. Le redimensionnement peut être particulièrement utile lorsqu’une image plus détaillée est requise, par exemple pour une utilisation dans des supports imprimés de haute qualité.
```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Enregistre la forme en mémoire sous forme de bitmap avec mise à l'échelle.
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Crée un bitmap de forme à partir de la mémoire.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calcule les limites du deuxième paragraphe.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

// Calcule la taille de l'image de sortie (taille minimale - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prépare un bitmap pour le paragraphe.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redessine le paragraphe du bitmap de forme vers le bitmap du paragraphe.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```


## **FAQ**

**Puis-je désactiver complètement le retour à la ligne à l’intérieur d’un cadre de texte ?**

Oui. Utilisez le paramètre de retour à la ligne du cadre de texte ([WrapText](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/wraptext/)) pour le désactiver afin que les lignes ne se coupent pas aux bords du cadre.

**Comment obtenir les limites exactes sur la diapositive d’un paragraphe spécifique ?**

Vous pouvez récupérer le rectangle englobant du paragraphe (et même d’une seule portion) pour connaître sa position et sa taille précises sur la diapositive.

**Où est contrôlé l’alignement du paragraphe (gauche/droite/centre/justifié) ?**

[Alignment](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/alignment/) est un paramètre au niveau du paragraphe dans [ParagraphFormat](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/); il s’applique à l’ensemble du paragraphe quel que soit le formatage individuel des portions.

**Puis-je définir une langue de vérification orthographique pour seulement une partie d’un paragraphe (par exemple, un mot) ?**

Oui. La langue est définie au niveau de la portion ([PortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/languageid/)), de sorte que plusieurs langues peuvent coexister dans un même paragraphe.