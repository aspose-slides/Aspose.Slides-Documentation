---
title: Gérer les listes à puces et numérotées dans les présentations en .NET
linktitle: Gérer les listes
type: docs
weight: 70
url: /fr/net/manage-lists/
keywords:
- puce
- liste à puces
- liste numérotée
- puce symbole
- puce image
- puce personnalisée
- liste à plusieurs niveaux
- créer puce
- ajouter puce
- ajouter liste
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à créer et mettre en forme des listes à puces, image, à plusieurs niveaux et numérotées dans les présentations PowerPoint et OpenDocument à l’aide d’Aspose.Slides pour .NET."
---
## **Vue d'ensemble**

Aspose.Slides pour .NET vous permet de créer et de mettre en forme des listes à puces et des listes numérotées dans les présentations PowerPoint et OpenDocument. Un élément de liste est un paragraphe dont les paramètres de puce sont contrôlés via son format de paragraphe.

Utilisez la propriété [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraph/paragraphformat/) pour accéder aux paramètres de liste au niveau du paragraphe. Le point d’entrée principal est [IParagraphFormat.Bullet](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/bullet/), qui renvoie un objet [IBulletFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ibulletformat/). Avec cet objet, vous pouvez définir le type de puce, le symbole, l’image, la couleur, la taille, le style de numérotation et le numéro de départ.

Cet article montre comment :

- créer une liste à puces avec un symbole personnalisé
- créer une puce image
- créer une liste à plusieurs niveaux en définissant la profondeur du paragraphe
- créer une liste numérotée
- inspecter et modifier le format des listes dans une présentation existante

## **Créer une liste à puces**

Pour créer une liste à puces, ajoutez des objets [IParagraph](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraph/) à un [ITextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/) et définissez [IBulletFormat.Type](https://reference.aspose.com/slides/fr/net/aspose.slides/ibulletformat/type/) sur [BulletType.Symbol](https://reference.aspose.com/slides/fr/net/aspose.slides/bullettype/). Vous pouvez ensuite définir [IBulletFormat.Char](https://reference.aspose.com/slides/fr/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/fr/net/aspose.slides/ibulletformat/color/) et [IBulletFormat.Height](https://reference.aspose.com/slides/fr/net/aspose.slides/ibulletformat/height/) pour contrôler l’apparence de la puce.

Le code C# suivant montre comment créer une liste à puces dans une diapositive :

```csharp
static Paragraph CreateParagraph(string text)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    paragraph.ParagraphFormat.Bullet.Char = '*';
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
    paragraph.ParagraphFormat.Bullet.Color.Color = Color.IndianRed;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = CreateParagraph("The first paragraph");
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph");
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("symbol_bullets.pptx", SaveFormat.Pptx);
```

Le résultat :

![The symbol bullets](symbol_bullets.png)

## **Créer une liste numérotée**

Utilisez des listes numérotées lorsque l’ordre des éléments est important. Définissez [IBulletFormat.Type](https://reference.aspose.com/slides/fr/net/aspose.slides/ibulletformat/type/) sur [BulletType.Numbered](https://reference.aspose.com/slides/fr/net/aspose.slides/bullettype/). Vous pouvez également choisir un format de numérotation avec [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/fr/net/aspose.slides/ibulletformat/numberedbulletstyle/) ou définir [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/fr/net/aspose.slides/ibulletformat/numberedbulletstartwith/) lorsque la liste doit commencer à partir d’une valeur autre que 1.

Le code C# suivant montre comment créer une liste numérotée dans une diapositive :

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph1.Text = "Apple";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph2.Text = "Orange";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph3.Text = "Banana";
textFrame.Paragraphs.Add(paragraph3);

presentation.Save("numbered_bullets.pptx", SaveFormat.Pptx);
```

Le résultat :

![The numbered bullets](numbered_bullets.png)

## **Créer une puce image**

Aspose.Slides vous permet de remplacer un symbole de puce standard par une image. Les puces image fonctionnent mieux avec des images simples qui restent lisibles à petite taille, comme des icônes ou de petits fichiers PNG transparents.

{{% alert color="primary" %}}

Idéalement, si vous prévoyez de remplacer le symbole de puce standard par une image, choisissez un graphique simple avec un arrière‑plan transparent. De telles images conviennent bien comme symboles de puce personnalisés.

Gardez à l’esprit que l’image sera réduite à une taille très petite. Pour cette raison, nous vous recommandons vivement de sélectionner une image qui reste claire et visuellement efficace lorsqu’elle est utilisée comme puce dans une liste.

{{% /alert %}}

Pour créer une puce image, ajoutez une image à [Presentation.Images](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/images/) et affectez l’objet image retourné à [IBulletFormat.Picture](https://reference.aspose.com/slides/fr/net/aspose.slides/ibulletformat/picture/). Définissez [IBulletFormat.Type](https://reference.aspose.com/slides/fr/net/aspose.slides/ibulletformat/type/) sur [BulletType.Picture](https://reference.aspose.com/slides/fr/net/aspose.slides/bullettype/) avant d’affecter l’image.

Supposons que nous ayons un « image.png » :

![A picture for the bullets](picture_for_bullets.png)

Le code C# suivant montre comment créer des puces image dans une diapositive :

```csharp
static Paragraph CreateParagraph(string text, IPPImage image)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
    paragraph.ParagraphFormat.Bullet.Picture.Image = image;
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var imageBytes = File.ReadAllBytes("image.png");
var bulletImage = presentation.Images.AddImage(imageBytes);

var paragraph1 = CreateParagraph("The first paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("picture_bullets.pptx", SaveFormat.Pptx);
```

Le résultat :

![The picture bullets](picture_bullets.png)

## **Créer une liste à plusieurs niveaux**

Utilisez [IParagraphFormat.Depth](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/depth/) pour placer les éléments de liste à différents niveaux. Le niveau 0 est le niveau supérieur, le niveau 1 est imbriqué en dessous, etc.

Le code C# suivant montre comment créer une liste à puces à plusieurs niveaux :

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Depth = 0;
paragraph1.Text = "My text - Depth 0";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Depth = 1;
paragraph2.Text = "My text - Depth 1";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Depth = 2;
paragraph3.Text = "My text - Depth 2";
textFrame.Paragraphs.Add(paragraph3);

var paragraph4 = new Paragraph();
paragraph4.ParagraphFormat.Depth = 3;
paragraph4.Text = "My text - Depth 3";
textFrame.Paragraphs.Add(paragraph4);

presentation.Save("multilevel_bullets.pptx", SaveFormat.Pptx);
```

Le résultat :

![The multilevel list](multilevel_list.png)

## **Modifier une liste existante**

Pour modifier le format d’une liste dans une présentation existante, accédez au paragraphe cible et mettez à jour ses paramètres [IParagraphFormat.Bullet](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/bullet/). Les mêmes propriétés utilisées pour créer des listes peuvent être employées pour inspecter ou modifier des listes chargées depuis un fichier PPT, PPTX ou ODP.

Le code C# suivant modifie le premier paragraphe d’un cadre texte pour utiliser un style de liste numérotée :

```csharp
using var presentation = new Presentation("input.pptx");

var slide = presentation.Slides[0];
var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletRomanUCPeriod;
paragraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 1;
paragraph.ParagraphFormat.MarginLeft = 30;
paragraph.ParagraphFormat.Indent = -20;

presentation.Save("updated_list.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Les listes à puces et numérotées peuvent‑elles être exportées en PDF ou en images ?**

Oui. Aspose.Slides conserve le format des listes lorsque le format cible prend en charge la mise en page du texte et les fonctionnalités de puce correspondantes.

**Puis‑je modifier les listes dans des présentations existantes ?**

Oui. Chargez la présentation, accédez au paragraphe cible, inspectez ou mettez à jour ses paramètres [IParagraphFormat.Bullet](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/bullet/), puis enregistrez la présentation.

**Les listes peuvent‑elles contenir du texte non latin ?**

Oui. Le texte des éléments de liste peut contenir des caractères Unicode, ce qui vous permet de créer des listes dans des présentations multilingues. Assurez‑vous que les polices utilisées dans la présentation supportent les caractères nécessaires.