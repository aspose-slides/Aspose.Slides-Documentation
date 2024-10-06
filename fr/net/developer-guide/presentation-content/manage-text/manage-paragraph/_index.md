---
title: Gérer les Paragraphes PowerPoint en C#
type: docs
weight: 40
url: /net/manage-paragraph/
keywords: 
- ajouter un paragraphe
- gérer les paragraphes
- retrait de paragraphe
- propriétés de paragraphe
- texte HTML
- exporter le texte du paragraphe
- présentation PowerPoint
- C#
- Csharp
- Aspose.Slides pour .NET
description: "Créer et gérer des Paragraphes, du texte, des retraits et des propriétés dans des présentations PowerPoint en C# ou .NET"
---

Aspose.Slides fournit toutes les interfaces et classes nécessaires pour travailler avec des textes, des paragraphes et des portions PowerPoint en C#.

* Aspose.Slides fournit l'interface [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) pour vous permettre d'ajouter des objets qui représentent un paragraphe. Un objet `ITextFame` peut contenir un ou plusieurs paragraphes (chaque paragraphe est créé par un retour à la ligne).
* Aspose.Slides fournit l'interface [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) pour vous permettre d'ajouter des objets qui représentent des portions. Un objet `IParagraph` peut contenir un ou plusieurs portions (collection d'objets iPortions).
* Aspose.Slides fournit l'interface [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) pour vous permettre d'ajouter des objets qui représentent des textes et leurs propriétés de formatage. 

Un objet `IParagraph` est capable de gérer des textes avec différentes propriétés de formatage via ses objets `IPortion` sous-jacents.

## **Ajouter Plusieurs Paragraphes Contenant Plusieurs Portions**

Ces étapes vous montrent comment ajouter un cadre de texte contenant 3 paragraphes, chaque paragraphe contenant 3 portions :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Accédez à la référence de la diapositive pertinente via son index.
3. Ajoutez un Rectangle [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
4. Obtenez le ITextFrame associé à [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
5. Créez deux objets [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) et ajoutez-les à la collection `IParagraphs` de [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/).
6. Créez trois objets [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) pour chaque nouveau `IParagraph` (deux objets Portion pour le paragraphe par défaut) et ajoutez chaque objet `IPortion` à la collection IPortion de chaque `IParagraph`.
7. Définissez du texte pour chaque portion.
8. Appliquez vos fonctionnalités de formatage préférées à chaque portion à l'aide des propriétés de formatage exposées par l'objet `IPortion`.
9. Enregistrez la présentation modifiée.

Ce code C# est une implémentation des étapes d'ajout de paragraphes contenant des portions :

```c#
// Instantiates a Presentation class that represents a PPTX file
using (Presentation pres = new Presentation())
{
    // Accesses the first slide
    ISlide slide = pres.Slides[0];

    // Adds a Rectangle IAutoShape
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Accesses the AutoShape TextFrame
    ITextFrame tf = ashp.TextFrame;

    // Creates Paragraphs and Portions with different text formats
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
    // Saves the modified presentation
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);

```


## **Gérer les Puces de Paragraphe**
Les listes à puces vous aident à organiser et présenter les informations rapidement et efficacement. Les paragraphes à puces sont toujours plus faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Accédez à la référence de la diapositive pertinente via son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive sélectionnée.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) de l'autoshape. 
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe à l'aide de la classe [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/).
8. Définissez le `Type` de puce pour le paragraphe sur `Symbol` et définissez le caractère de puce.
9. Définissez le `Text` du paragraphe.
10. Définissez le `Indent` du paragraphe pour la puce.
11. Définissez une couleur pour la puce.
12. Définissez une hauteur pour la puce.
13. Ajoutez le nouveau paragraphe à la collection de paragraphes du `TextFrame`.
14. Ajoutez le deuxième paragraphe et répétez le processus décrit dans les étapes 7 à 13.
15. Enregistrez la présentation.

Ce code C# vous montre comment ajouter une puce de paragraphe :

```c#
// Instantiates a Presentation class that represents a PPTX file
using (Presentation pres = new Presentation())
{

    // Accesses the first slide
    ISlide slide = pres.Slides[0];

    // Adds and accesses Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accesses the autoshape text frame
    ITextFrame txtFrm = aShp.TextFrame;

    // Removes the default paragraph
    txtFrm.Paragraphs.RemoveAt(0);

    // Creates a paragraph
    Paragraph para = new Paragraph();

    // Sets a paragraph bullet style and symbol
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // Sets a paragraph text
    para.Text = "Bienvenue dans Aspose.Slides";

    // Sets bullet indent
    para.ParagraphFormat.Indent = 25;

    // Sets bullet color
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // set IsBulletHardColor to true to use own bullet color

    // Sets Bullet Height
    para.ParagraphFormat.Bullet.Height = 100;

    // Adds Paragraph to text frame
    txtFrm.Paragraphs.Add(para);

    // Creates second paragraph
    Paragraph para2 = new Paragraph();

    // Sets paragraph bullet type and style
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // Adds paragraph text
    para2.Text = "C'est une puce numérotée";

    // Sets bullet indent
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // set IsBulletHardColor to true to use own bullet color

    // Sets Bullet Height
    para2.ParagraphFormat.Bullet.Height = 100;

    // Adds Paragraph to text frame
    txtFrm.Paragraphs.Add(para2);


    // Saves the modified presentation
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```


## **Gérer les Puces d'Image**
Les listes à puces vous aident à organiser et présenter les informations rapidement et efficacement. Les paragraphes d'image sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Accédez à la référence de la diapositive pertinente via son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) de l'autoshape.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe à l'aide de la classe [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/).
7. Chargez l'image dans [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/).
8. Définissez le type de puce sur [Picture](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) et définissez l'image.
9. Définissez le `Text` du paragraphe.
10. Définissez le `Indent` du paragraphe pour la puce.
11. Définissez une couleur pour la puce.
12. Définissez une hauteur pour la puce.
13. Ajoutez le nouveau paragraphe à la collection de paragraphes du `TextFrame`.
14. Ajoutez le deuxième paragraphe et répétez le processus basé sur les étapes précédentes.
15. Enregistrez la présentation modifiée.

Ce code C# vous montre comment ajouter et gérer des puces d'image :

```c#
// Instantiates a Presentation class that represents a PPTX file
Presentation presentation = new Presentation();

// Accesses the first slide
ISlide slide = presentation.Slides[0];

// Instantiates the image for bullets
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// Adds and accesses Autoshape
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// Accesses the autoshape textframe
ITextFrame textFrame = autoShape.TextFrame;

// Removes the default paragraph
textFrame.Paragraphs.RemoveAt(0);

// Creates a new paragraph
Paragraph paragraph = new Paragraph();
paragraph.Text = "Bienvenue dans Aspose.Slides";

// Sets paragraph bullet style and image
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// Sets bullet Height
paragraph.ParagraphFormat.Bullet.Height = 100;

// Adds paragraph to text frame
textFrame.Paragraphs.Add(paragraph);

// Writes the presentation as a PPTX file
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// Writes the presentation as a PPT file
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```


## **Gérer les Puces Multiniveaux**
Les listes à puces vous aident à organiser et présenter les informations rapidement et efficacement. Les puces multiniveaux sont faciles à lire et à comprendre.

1. Créez une instance de la classe [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Accédez à la référence de la diapositive pertinente via son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) dans la nouvelle diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) de l'autoshape.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) et définissez la profondeur à 0.
7. Créez la deuxième instance de paragraphe via la classe `Paragraph` et définissez la profondeur à 1.
8. Créez la troisième instance de paragraphe via la classe `Paragraph` et définissez la profondeur à 2.
9. Créez la quatrième instance de paragraphe via la classe `Paragraph` et définissez la profondeur à 3.
10. Ajoutez les nouveaux paragraphes à la collection de paragraphes du `TextFrame`.
11. Enregistrez la présentation modifiée.

Ce code C# vous montre comment ajouter et gérer des puces multiniveaux :

```c#
// Instantiates a Presentation class that represents a PPTX file
using (Presentation pres = new Presentation())
{

    // Accesses the first slide
    ISlide slide = pres.Slides[0];
    
    // Adds and accesses Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Accesses the text frame of created autoshape
    ITextFrame text = aShp.AddTextFrame("");
    
    // Clears the default paragraph
    text.Paragraphs.Clear();

    // Adds the first paragraph
    IParagraph para1 = new Paragraph();
    para1.Text = "Contenu";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Sets the bullet level
    para1.ParagraphFormat.Depth = 0;

    // Adds the second paragraph
    IParagraph para2 = new Paragraph();
    para2.Text = "Deuxième niveau";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Sets the bullet level
    para2.ParagraphFormat.Depth = 1;

    // Adds the third paragraph
    IParagraph para3 = new Paragraph();
    para3.Text = "Troisième niveau";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Sets the bullet level
    para3.ParagraphFormat.Depth = 2;

    // Adds the fourth paragraph
    IParagraph para4 = new Paragraph();
    para4.Text = "Quatrième niveau";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Sets the bullet level
    para4.ParagraphFormat.Depth = 3;

    // Adds paragraphs to collection
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // Writes the presentation as a PPTX file
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Gérer les Paragraphes avec Liste Numérotée Personnalisée**
L'interface [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/) fournit la propriété [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith) et d'autres qui vous permettent de gérer des paragraphes avec un numéro ou un formatage personnalisé.

1. Créez une instance de la classe [Presentation ](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Accédez à la diapositive contenant le paragraphe.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) de l'autoshape.
5. Supprimez le paragraphe par défaut dans le `TextFrame`.
6. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) et définissez [NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith) sur 2.
7. Créez la deuxième instance de paragraphe via la classe `Paragraph` et définissez `NumberedBulletStartWith` sur 3.
8. Créez la troisième instance de paragraphe via la classe `Paragraph` et définissez `NumberedBulletStartWith` sur 7.
9. Ajoutez les nouveaux paragraphes à la collection de paragraphes du `TextFrame`.
10. Enregistrez la présentation modifiée.

Ce code C# vous montre comment ajouter et gérer des paragraphes avec un numéro ou un formatage personnalisé :

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// Accesses the text frame of created autoshape
	ITextFrame textFrame = shape.TextFrame;

	// Removes the default exisiting paragraph
	textFrame.Paragraphs.RemoveAt(0);

	// First list
	var paragraph1 = new Paragraph { Text = "puce 2" };
	paragraph1.ParagraphFormat.Depth = 4; 
	paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
	paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph1);

	var paragraph2 = new Paragraph { Text = "puce 3" };
	paragraph2.ParagraphFormat.Depth = 4;
	paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = 3; 
	paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;  
	textFrame.Paragraphs.Add(paragraph2);

	
	var paragraph5 = new Paragraph { Text = "puce 7" };
	paragraph5.ParagraphFormat.Depth = 4;
	paragraph5.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
	paragraph5.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph5);

	presentation.Save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
}
```


## **Définir le Retrait de Paragraphe**
1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Accédez à la référence de la diapositive pertinente via son index.
1. Ajoutez une rectangle [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
1. Ajoutez un [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) avec trois paragraphes à l'autoshape rectangle.
1. Masquez les lignes du rectangle.
1. Définissez le retrait pour chaque [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/) via leur propriété BulletOffset.
1. Écrivez la présentation modifiée sous forme de fichier PPT.

Ce code C# vous montre comment définir un retrait de paragraphe :

```c#
// Instantiate Presentation Class
Presentation pres = new Presentation();

// Gets the first slide
ISlide sld = pres.Slides[0];

// Adds a Rectangle Shape
IAutoShape rect = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 500, 150);

// Adds TextFrame to the Rectangle
ITextFrame tf = rect.AddTextFrame("Ceci est la première ligne \rCeci est la deuxième ligne \rCeci est la troisième ligne");

// Sets the text to fit the shape
tf.TextFrameFormat.AutofitType = TextAutofitType.Shape;

// Hides the lines of the Rectangle
rect.LineFormat.FillFormat.FillType = FillType.Solid;

// Gets the first Paragraph in the TextFrame and set its Indent
IParagraph para1 = tf.Paragraphs[0];

// Sets paragraph bullet style and symbol
para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para1.ParagraphFormat.Alignment = TextAlignment.Left;

para1.ParagraphFormat.Depth = 2;
para1.ParagraphFormat.Indent = 30;

// Gets second Paragraph in the TextFrame and set its Indent
IParagraph para2 = tf.Paragraphs[1];
para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para2.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para2.ParagraphFormat.Alignment = TextAlignment.Left;
para2.ParagraphFormat.Depth = 2;
para2.ParagraphFormat.Indent = 40;

// Gets third Paragraph in the TextFrame and sets its Indent
IParagraph para3 = tf.Paragraphs[2];
para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
para3.ParagraphFormat.Alignment = TextAlignment.Left;
para3.ParagraphFormat.Depth = 2;
para3.ParagraphFormat.Indent = 50;

// Writes the Presentation to disk
pres.Save("InOutDent_out.pptx", SaveFormat.Pptx);
```

## **Définir un Retrait Suspendu pour le Paragraphe**

Ce code C# vous montre comment définir le retrait suspendu pour un paragraphe :  

```c#
using (Presentation pres = new Presentation())
{
    var autoShape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 50, 250, 550, 150);

    Paragraph para1 = new Paragraph
    {
        Text = "Exemple"
    };
    Paragraph para2 = new Paragraph
    {
        Text = "Définir un retrait suspendu pour le paragraphe"
    };
    Paragraph para3 = new Paragraph
    {
        Text = "Ce code C# vous montre comment définir le retrait suspendu pour un paragraphe : "
    };

    para2.ParagraphFormat.MarginLeft = 10f;
    para3.ParagraphFormat.MarginLeft = 20f;
    
    autoShape.TextFrame.Paragraphs.Add(para1);
    autoShape.TextFrame.Paragraphs.Add(para2);
    autoShape.TextFrame.Paragraphs.Add(para3);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Gérer les Propriétés de Fin de Paragraphe pour le Paragraphe**

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
1. Obtenez la référence de la diapositive contenant le paragraphe via sa position.
1. Ajoutez une rectangle [autoshape](https://reference.aspose.com/slides/net/aspose.slides/autoshape/) à la diapositive.
1. Ajoutez un [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) avec deux paragraphes au Rectangle.
1. Définissez la `FontHeight` et le type de police pour les paragraphes.
1. Définissez les propriétés de fin pour les paragraphes.
1. Écrivez la présentation modifiée sous forme de fichier PPTX.

Ce code C# vous montre comment définir les propriétés de fin pour les paragraphes dans PowerPoint :

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

	Paragraph para1 = new Paragraph();
	para1.Portions.Add(new Portion("Texte d'exemple"));

	Paragraph para2 = new Paragraph();
	para2.Portions.Add(new Portion("Texte d'exemple 2"));
	PortionFormat endParagraphPortionFormat = new PortionFormat();
	endParagraphPortionFormat.FontHeight = 48;
	endParagraphPortionFormat.LatinFont = new FontData("Times New Roman");
	para2.EndParagraphPortionFormat = endParagraphPortionFormat;

	shape.TextFrame.Paragraphs.Add(para1);
	shape.TextFrame.Paragraphs.Add(para2);

	pres.Save("pres.pptx", SaveFormat.Pptx);
}
```


## **Importer du Texte HTML dans des Paragraphes**
Aspose.Slides offre un support amélioré pour importer du texte HTML dans des paragraphes.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Accédez à la référence de la diapositive pertinente via son index.
3. Ajoutez une [autoshape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) à la diapositive.
4. Ajoutez et accédez à `autoshape` [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/).
5. Supprimez le paragraphe par défaut dans le `ITextFrame`.
6. Lisez le fichier HTML source dans un TextReader.
7. Créez la première instance de paragraphe via la classe [Paragraph](https://reference.aspose.com/slides/net/aspose.slides/paragraph/).
8. Ajoutez le contenu du fichier HTML dans le TextReader lu à la [ParagraphCollection](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/) du TextFrame.
9. Enregistrez la présentation modifiée.

Ce code C# est une implémentation des étapes pour importer des textes HTML dans des paragraphes :

```c#
// Creates Empty presentation instance
using (Presentation pres = new Presentation())
{
    // Acessses the default first slide of presentation
    ISlide slide = pres.Slides[0];

    // Adds the AutoShape to house the HTML content
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // Adds text frame to the shape
    ashape.AddTextFrame("");

    // Clears all paragraphs in the added text frame
    ashape.TextFrame.Paragraphs.Clear();

    // Loads the HTML file using stream reader
    TextReader tr = new StreamReader("file.html");

    // Adds the text from HTML stream reader in text frame
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // Saves Presentation
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Exporter le Texte des Paragraphes vers HTML**
Aspose.Slides offre un support amélioré pour exporter des textes (contenus dans les paragraphes) vers HTML.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) et chargez la présentation souhaitée.
2. Accédez à la référence de la diapositive pertinente via son index.
3. Accédez à la forme contenant le texte qui sera exporté vers HTML.
4. Accédez au [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) de la forme.
5. Créez une instance de `StreamWriter` et ajoutez le nouveau fichier HTML.
6. Fournissez un index de départ au StreamWriter et exportez vos paragraphes préférés.

Ce code C# vous montre comment exporter le texte des paragraphes PowerPoint vers HTML :

```c#
// Loads the presentation file
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // Acessses the default first slide of presentation
    ISlide slide = pres.Slides[0];

    // Accesses the required  index
    int index = 0;

    // Accesses the added shape
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // Writes paragraphs data to HTML by specifying paragraph starting index and number of paragraphs to be copied
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```