---
title: Gérer les paragraphes de texte PowerPoint en .NET
linktitle: Gérer le paragraphe
type: docs
weight: 40
url: /fr/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
- ajouter du texte
- ajouter un paragraphe
- gérer le texte
- gérer le paragraphe
- gérer les puces
- indentation de paragraphe
- indentation suspendue
- puce de paragraphe
- liste numérotée
- liste à puces
- propriétés du paragraphe
- importer HTML
- texte vers HTML
- paragraphe vers HTML
- paragraphe vers image
- texte vers image
- exporter le paragraphe
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à créer et formater des paragraphes, des portions, des puces, des listes numérotées, des retraits, du contenu HTML et des images de paragraphe avec Aspose.Slides pour .NET."
---
## **Vue d'ensemble**

Aspose.Slides for .NET représente le texte sous forme d’une hiérarchie de cadres de texte, de paragraphes et de portions :

* [ITextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/) représente le conteneur de texte dans une forme et fournit l’accès à sa collection de paragraphes.
* [IParagraph](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraph/) représente un paragraphe dans un cadre de texte et fournit l’accès à ses portions ainsi qu’au formatage au niveau du paragraphe.
* [IPortion](https://reference.aspose.com/slides/fr/net/aspose.slides/iportion/) représente un fragment de texte au sein d’un paragraphe. Chaque portion peut avoir son propre texte et son propre formatage au niveau des caractères.

Un paragraphe peut donc contenir du texte avec différentes polices, couleurs, tailles et autres formatages en utilisant plusieurs portions.

## **Créer et formater des paragraphes**

### **Créer des paragraphes avec plusieurs portions**

Les étapes suivantes créent un cadre de texte avec trois paragraphes, chacun contenant trois portions :

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation).
2. Accédez à la référence de la diapositive concernée via son indice.
3. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/) rectangulaire à la diapositive.
4. Accédez au [ITextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/) de la forme.
5. Utilisez le paragraphe par défaut et ajoutez deux autres objets [IParagraph](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraph/) au cadre de texte.
6. Ajoutez suffisamment d’objets [IPortion](https://reference.aspose.com/slides/fr/net/aspose.slides/iportion/) pour que chaque paragraphe contienne trois portions. Le paragraphe par défaut contient déjà une portion vide.
7. Définissez le texte de chaque portion.
8. Appliquez le formatage au niveau des caractères via [IPortion.PortionFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/iportion/portionformat/).
9. Enregistrez la présentation modifiée.

Cet exemple C# implémente les étapes :

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
var textFrame = shape.TextFrame;

var firstParagraph = textFrame.Paragraphs[0];
firstParagraph.Portions.Add(new Portion());
firstParagraph.Portions.Add(new Portion());

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph();
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(thirdParagraph);

var paragraphCount = textFrame.Paragraphs.Count;
for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    var paragragaph = textFrame.Paragraphs[paragraphIndex];
    var portionCount = paragragaph.Portions.Count;
    for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        var portion = paragragaph.Portions[portionIndex];
        portion.Text = $"Portion {paragraphIndex + 1}.{portionIndex + 1}";

        if (portionIndex == 0)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
            portion.PortionFormat.FontBold = NullableBool.True;
            portion.PortionFormat.FontHeight = 15;
        }
        else if (portionIndex == 1)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontHeight = 18;
        }
    }
}

presentation.Save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
```

## **Créer des listes à puces et numérotées**

### **Créer une liste à puces ou numérotée**

Les puces et la numérotation facilitent la lecture des éléments liés. Dans Aspose.Slides, les paramètres de liste sont définis via [IBulletFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/ibulletformat/).

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation).
2. Accédez à la référence de la diapositive concernée via son indice.
3. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/) à la diapositive sélectionnée.
4. Accédez au [ITextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/) de la forme.
5. Supprimez le paragraphe par défaut du cadre de texte.
6. Créez un [Paragraph](https://reference.aspose.com/slides/fr/net/aspose.slides/paragraph/) pour une puce symbolique.
7. Définissez [IBulletFormat.Type](https://reference.aspose.com/slides/fr/net/aspose.slides/ibulletformat/type/) sur [BulletType.Symbol](https://reference.aspose.com/slides/fr/net/aspose.slides/bullettype/) et spécifiez le caractère de puce.
8. Définissez le texte du paragraphe, l'indentation, la couleur de la puce et la hauteur de la puce.
9. Ajoutez le paragraphe au cadre de texte.
10. Créez un deuxième paragraphe et définissez [IBulletFormat.Type](https://reference.aspose.com/slides/fr/net/aspose.slides/ibulletformat/type/) sur [BulletType.Numbered](https://reference.aspose.com/slides/fr/net/aspose.slides/bullettype/).
11. Configurez le style de puce numérotée et ajoutez le paragraphe au cadre de texte.
12. Enregistrez la présentation.

Cet exemple C# crée une puce symbolique et une puce numérotée :

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var symbolParagraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
symbolParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
symbolParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
symbolParagraph.ParagraphFormat.Indent = 25;
symbolParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
symbolParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
symbolParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
symbolParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(symbolParagraph);

var numberedParagraph = new Paragraph { Text = "This is a numbered item" };
numberedParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
numberedParagraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;
numberedParagraph.ParagraphFormat.Indent = 25;
numberedParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
numberedParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
numberedParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
numberedParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(numberedParagraph);

presentation.Save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
```

### **Utiliser des puces d'image**

Les puces d'image vous permettent d'utiliser une image personnalisée à la place d'un symbole ou d'un chiffre.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation).
2. Accédez à la référence de la diapositive concernée via son indice.
3. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/) et accédez à son [ITextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/).
4. Supprimez le paragraphe par défaut du cadre de texte.
5. Chargez l'image de la puce et ajoutez‑la à la collection d'images de la présentation en tant que [IPPImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ippimage/).
6. Créez un [Paragraph](https://reference.aspose.com/slides/fr/net/aspose.slides/paragraph/) et définissez son texte.
7. Définissez [IBulletFormat.Type](https://reference.aspose.com/slides/fr/net/aspose.slides/ibulletformat/type/) sur [BulletType.Picture](https://reference.aspose.com/slides/fr/net/aspose.slides/bullettype/).
8. Attribuez l'image via [IBulletFormat.Picture](https://reference.aspose.com/slides/fr/net/aspose.slides/ibulletformat/picture/) et définissez la hauteur de la puce.
9. Ajoutez le paragraphe au cadre de texte.
10. Enregistrez la présentation modifiée.

Cet exemple C# crée une puce d'image :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var bulletImage = Images.FromFile("bullets.png");
var presentationImage = presentation.Images.AddImage(bulletImage);

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = presentationImage;
paragraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(paragraph);

presentation.Save("picture_bullet.pptx", SaveFormat.Pptx);
presentation.Save("picture_bullet.ppt", SaveFormat.Ppt);
```

### **Créer une liste multiniveau**

Définissez [IParagraphFormat.Depth](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/depth/) pour placer les paragraphes à différents niveaux d’une liste. Le niveau supérieur a une profondeur de `0`.

1. Créez une [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) et accédez à une diapositive.
2. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/) et supprimez le paragraphe par défaut de son cadre de texte.
3. Créez quatre paragraphes et configurez leurs symboles de puce.
4. Définissez leurs valeurs [IParagraphFormat.Depth](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/depth/) à `0`, `1`, `2` et `3`.
5. Ajoutez les paragraphes au cadre de texte et enregistrez la présentation.

Cet exemple C# crée une liste à puces à quatre niveaux :

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Content" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
firstParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.Depth = 0;

var secondParagraph = new Paragraph { Text = "Second level" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
secondParagraph.ParagraphFormat.Bullet.Char = '-';
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.Depth = 1;

var thirdParagraph = new Paragraph { Text = "Third level" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
thirdParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.Depth = 2;

var fourthParagraph = new Paragraph { Text = "Fourth level" };
fourthParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
fourthParagraph.ParagraphFormat.Bullet.Char = '-';
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
fourthParagraph.ParagraphFormat.Depth = 3;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);
textFrame.Paragraphs.Add(fourthParagraph);

presentation.Save("multilevel_list.pptx", SaveFormat.Pptx);
```

### **Commencer les éléments numérotés à des valeurs personnalisées**

Utilisez [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/fr/net/aspose.slides/ibulletformat/numberedbulletstartwith/) pour définir le numéro initial affiché pour un paragraphe numéroté.

1. Créez une [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation) et ajoutez une [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/) à une diapositive.
2. Supprimez le paragraphe par défaut du cadre de texte de la forme.
3. Créez trois paragraphes numérotés.
4. Définissez [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/fr/net/aspose.slides/ibulletformat/numberedbulletstartwith/) à `2`, `3` et `7` pour les paragraphes respectifs.
5. Ajoutez les paragraphes au cadre de texte et enregistrez la présentation.

Cet exemple C# assigne un numéro de départ personnalisé à chaque paragraphe :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Start at 2" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
firstParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
textFrame.Paragraphs.Add(firstParagraph);

var secondParagraph = new Paragraph { Text = "Start at 3" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
secondParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 3;
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph { Text = "Start at 7" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
thirdParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("custom_numbered_list.pptx", SaveFormat.Pptx);
```

## **Contrôler la mise en page du paragraphe et les propriétés de fin**

### **Définir une indentation de première ligne**

Utilisez la propriété [IParagraphFormat.Indent](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/indent/) pour contrôler l'indentation de la première ligne d'un paragraphe. Cette propriété déplace uniquement la première ligne par rapport à la marge gauche du paragraphe. Une valeur positive décale la première ligne vers la droite, tandis que les lignes restantes restent alignées au corps du paragraphe.

Utilisez [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/marginleft/) lorsque vous devez déplacer l'ensemble du paragraphe. Utilisez [IParagraphFormat.Indent](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/indent/) lorsque vous devez déplacer uniquement la première ligne.

L'exemple ci‑dessous crée plusieurs paragraphes et applique différentes valeurs [IParagraphFormat.Indent](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/indent/) pour démontrer comment l'indentation de première ligne affecte la mise en page du paragraphe.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/).
2. Accédez à la diapositive cible.
3. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/) rectangulaire à la diapositive.
4. Accédez au [ITextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/) de la forme et supprimez le paragraphe par défaut.
5. Créez plusieurs paragraphes et définissez différentes valeurs [Indent](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/indent/) pour chacun.
6. Ajoutez les paragraphes au cadre de texte.
7. Enregistrez la présentation modifiée.

Ce code montre comment définir une indentation de paragraphe :

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "No first-line indent. Wrapped lines start at the same position as the first line." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 20;
firstParagraph.ParagraphFormat.Indent = 0;

var secondParagraph = new Paragraph { Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 20;
secondParagraph.ParagraphFormat.Indent = 20;

var thirdParagraph = new Paragraph { Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see." };
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.MarginLeft = 20;
thirdParagraph.ParagraphFormat.Indent = 40;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
```

Le résultat :

![Indentation de première ligne des paragraphes](first_line_indent.png)

### **Définir une indentation suspendue**

Une indentation suspendue est une mise en page de paragraphe où la première ligne débute à gauche des lignes suivantes. Dans Aspose.Slides, vous créez cet effet avec la propriété [IParagraphFormat.Indent](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/indent/). Définissez `Indent` à une valeur négative pour déplacer la première ligne vers la gauche par rapport au corps du paragraphe.

En pratique, [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/marginleft/) définit la position gauche du corps du paragraphe, et [IParagraphFormat.Indent](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/indent/) définit la position de la première ligne par rapport à cette marge. Pour créer une indentation suspendue, définissez une valeur positive `MarginLeft` et une valeur négative `Indent`.

Ce formatage est utile pour les bibliographies, références, entrées de glossaire et autres paragraphes où les lignes renvoyées doivent s’aligner sous le corps du paragraphe plutôt que sous le premier caractère de la première ligne.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/).
2. Accédez à la diapositive cible.
3. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/) rectangulaire à la diapositive.
4. Accédez au [ITextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/) de la forme et supprimez le paragraphe par défaut.
5. Créez des paragraphes et définissez une valeur positive [MarginLeft](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/marginleft/) pour chaque paragraphe.
6. Définissez une valeur négative [Indent](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/indent/) pour créer l'effet d'indentation suspendue.
7. Ajoutez les paragraphes au cadre de texte.
8. Enregistrez la présentation modifiée.

Ce code montre comment définir une indentation suspendue pour un paragraphe :

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 40;
firstParagraph.ParagraphFormat.Indent = -20;

var secondParagraph = new Paragraph { Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 60;
secondParagraph.ParagraphFormat.Indent = -30;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
```

Le résultat :

![Indentation suspendue des paragraphes](hanging_indent.png)

### **Définir les propriétés de fin de paragraphe**

La propriété [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraph/endparagraphportionformat/) contrôle le formatage de la marque de fin de paragraphe. L'exemple suivant assigne une taille de police et une police latine à la marque de fin du deuxième paragraphe :

1. Chargez une [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) et accédez à une diapositive.
2. Ajoutez une [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/) et supprimez son paragraphe par défaut.
3. Créez deux paragraphes et ajoutez des portions de texte à ceux‑ci.
4. Créez un [PortionFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/portionformat/) pour la marque de fin du deuxième paragraphe.
5. Définissez [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseportionformat/fontheight/) et [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseportionformat/latinfont/).
6. Attribuez le format à [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraph/endparagraphportionformat/) et enregistrez la présentation.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph();
firstParagraph.Portions.Add(new Portion("Sample text"));

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion("Sample text 2"));

var endParagraphFormat = new PortionFormat();
endParagraphFormat.FontHeight = 48;
endParagraphFormat.LatinFont = new FontData("Times New Roman");
secondParagraph.EndParagraphPortionFormat = endParagraphFormat;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("end_paragraph_format.pptx", SaveFormat.Pptx);
```

## **Importer et exporter le contenu des paragraphes**

### **Importer du texte HTML dans les paragraphes**

Utilisez [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/fr/net/aspose.slides/paragraphcollection/addfromhtml/) pour convertir le balisage HTML en paragraphes et portions dans un cadre de texte.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation).
2. Accédez à une diapositive et ajoutez une [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/).
3. Accédez au [ITextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/) de la forme et supprimez son paragraphe par défaut.
4. Lisez le fichier HTML source.
5. Passez la chaîne HTML à [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/fr/net/aspose.slides/paragraphcollection/addfromhtml/).
6. Enregistrez la présentation modifiée.

Cet exemple C# importe du HTML dans un cadre de texte :

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shapeWidth = presentation.SlideSize.Size.Width - 20;
var shapeHeight = presentation.SlideSize.Size.Height - 20;
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
shape.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

using var reader = new StreamReader("file.html");
var html = reader.ReadToEnd();
shape.TextFrame.Paragraphs.AddFromHtml(html);

presentation.Save("html_text.pptx", SaveFormat.Pptx);
```

### **Exporter le texte du paragraphe vers HTML**

Utilisez [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/fr/net/aspose.slides/paragraphcollection/exporttohtml/) pour exporter une plage sélectionnée de paragraphes au format HTML.

1. Créez une instance de la classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation) et chargez la présentation souhaitée.
2. Accédez à la diapositive et trouvez la [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/) qui contient le texte.
3. Accédez au [ITextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/) de la forme.
4. Appelez [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/fr/net/aspose.slides/paragraphcollection/exporttohtml/) avec l’indice du paragraphe de départ et le nombre de paragraphes à exporter.
5. Écrivez la chaîne HTML retournée dans un fichier.

Cet exemple C# exporte tous les paragraphes de la première forme de texte :

```csharp
using System;
using System.IO;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("ExportingHTMLText.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && textShape.TextFrame != null)
{
    var paragraphs = textShape.TextFrame.Paragraphs;
    var html = paragraphs.ExportToHtml(0, paragraphs.Count, null);
    using var writer = new StreamWriter("paragraphs.html", false, Encoding.UTF8);
    writer.Write(html);
}
else
{
    Console.WriteLine("The first shape is not a text shape.");
}
```

### **Rendre un paragraphe sous forme d’image**

[IParagraph.GetImage](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraph/getimage/) rend directement un paragraphe individuel et renvoie un [IImage](https://reference.aspose.com/slides/fr/net/aspose.slides/iimage/). Enregistrez le résultat dans un fichier ou un flux avec [IImage.Save](https://reference.aspose.com/slides/fr/net/aspose.slides/iimage/save/). Vous n’avez pas besoin de rendre la forme contenant le paragraphe ni de recadrer manuellement un bitmap.

[IParagraph.GetImage](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraph/getimage/) peut renvoyer `null` si le paragraphe est introuvable dans sa collection parente, n’a pas de limites de rendu valides, ou ne peut pas être rendu. Vérifiez le résultat avant de l’enregistrer et libérez l’image retournée après utilisation.

#### **Rendre un paragraphe à l’échelle par défaut**

Supposons que nous disposions d’un fichier de présentation nommé sample.pptx contenant une diapositive, où la première forme est une zone de texte contenant trois paragraphes.

![La zone de texte avec trois paragraphes](paragraph_to_image_input.png)

L'exemple suivant rend le deuxième paragraphe d'une forme de texte ordinaire à l'échelle par défaut et enregistre l'image retournée au format PNG. La déclaration `using` garantit que l'image est correctement libérée.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
if (shape is IAutoShape textShape && 
    textShape.TextFrame != null && 
    textShape.TextFrame.Paragraphs.Count > 1)
{
    var paragraph = textShape.TextFrame.Paragraphs[1];
    using var paragraphImage = paragraph.GetImage();

    if (paragraphImage != null)
    {
        paragraphImage.Save("paragraph.png", ImageFormat.Png);
    }
    else
    {
        Console.WriteLine("The paragraph could not be rendered.");
    }
}
else
{
    Console.WriteLine("The expected text shape or paragraph was not found.");
}
```

Le résultat :

![Image du paragraphe](paragraph_to_image_output.png)

#### **Rendre un paragraphe dans une cellule de tableau avec mise à l’échelle**

Utilisez la surcharge de [IParagraph.GetImage](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraph/getimage/) qui accepte les paramètres `float scaleX` et `float scaleY` pour définir les facteurs d’échelle horizontaux et verticaux. L’exemple suivant crée un tableau, rend le paragraphe dans sa première cellule à deux fois sa largeur et hauteur par défaut, puis enregistre le résultat sous forme d’image PNG.

```csharp
using System;
using Aspose.Slides;

var scaleX = 2f;
var scaleY = 2f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var table = slide.Shapes.AddTable(50, 50, new[] { 300d }, new[] { 80d });
var paragraph = table[0, 0].TextFrame.Paragraphs[0];
paragraph.Text = "Text in a table cell";

using var paragraphImage = paragraph.GetImage(scaleX, scaleY);
if (paragraphImage != null)
{
    paragraphImage.Save("table_paragraph.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The paragraph could not be rendered.");
}
```

Un facteur d’échelle de `1` conserve cette dimension à sa taille de pixel par défaut. Par exemple, `2` pour les deux facteurs produit une image dont la largeur et la hauteur sont approximativement deux fois les dimensions par défaut, ce qui donne quatre fois plus de pixels. Des facteurs plus élevés produisent généralement un texte plus net pour le zoom ou les sorties haute résolution, mais augmentent aussi la consommation de mémoire et la taille du fichier. Des facteurs inférieurs à `1` produisent des images plus petites avec moins de détails. Utilisez des facteurs égaux pour préserver le rapport d’aspect du paragraphe ; des facteurs horizontaux et verticaux différents étirent la sortie indépendamment.

Rendre une forme entière avec [IShape.GetImage](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/getimage/) reste utile lorsque le rendu doit inclure le remplissage, la bordure ou d’autres contextes visuels de la forme. Pour une image uniquement du paragraphe, utilisez [IParagraph.GetImage](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraph/getimage/).

## **FAQ**

**Puis-je désactiver complètement le retour à la ligne dans un cadre de texte ?**

Oui. Définissez [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframeformat/wraptext/) pour désactiver le retour à la ligne afin que les lignes ne se coupent pas aux bords du cadre de texte.

**Comment obtenir les limites exactes d'un paragraphe spécifique sur la diapositive ?**

Utilisez [IParagraph.GetRect](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraph/getrect/) pour récupérer le rectangle englobant du paragraphe. [IPortion.GetRect](https://reference.aspose.com/slides/fr/net/aspose.slides/iportion/getrect/) fournit les limites d’une portion individuelle.

**Où est contrôlé l’alignement du paragraphe (gauche, droite, centre ou justifié) ?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/fr/net/aspose.slides/iparagraphformat/alignment/) est un paramètre au niveau du paragraphe et s’applique à l’ensemble du paragraphe indépendamment du formatage des portions individuelles.

**Puis-je définir la langue de relecture pour une partie d’un paragraphe ?**

Oui. Définissez [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/fr/net/aspose.slides/ibaseportionformat/languageid/) pour les portions individuelles, de sorte qu’un paragraphe puisse contenir du texte dans plusieurs langues.