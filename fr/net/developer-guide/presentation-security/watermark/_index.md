---
title: Filigrane
type: docs
weight: 40
url: /net/watermark/
keywords:
- filigrane
- ajouter filigrane
- filigrane texte
- filigrane image
- PowerPoint
- présentation
- C#
- Csharp
- Aspose.Slides for .NET
description: "Ajoutez des filigranes texte et image aux présentations PowerPoint en C# ou .NET"
---

## **À propos des Filigranes**

**Un filigrane** dans une présentation est un texte ou une image imprimé utilisé sur une diapositive ou sur toutes les diapositives de la présentation. En général, un filigrane est utilisé pour indiquer que la présentation est un brouillon (par exemple, un filigrane "Brouillon"), qu'elle contient des informations confidentielles (par exemple, un filigrane "Confidentiel"), pour spécifier à quelle entreprise elle appartient (par exemple, un filigrane "Nom de l'Entreprise"), pour identifier l'auteur de la présentation, etc. Un filigrane contribue à prévenir les violations de droits d'auteur en indiquant que la présentation ne doit pas être copiée. Les filigranes sont utilisés dans les formats de présentation PowerPoint et OpenOffice. Dans Aspose.Slides, vous pouvez ajouter un filigrane aux formats de fichiers PowerPoint PPT, PPTX et OpenOffice ODP.

Dans [**Aspose.Slides**](https://products.aspose.com/slides/net/), il existe diverses façons de créer des filigranes dans des documents PowerPoint ou OpenOffice et de modifier leur design et leur comportement. L'aspect commun est que pour ajouter des filigranes texte, vous devez utiliser l'interface [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/), et pour ajouter des filigranes image, utilisez la classe [PictureFrame](https://reference.aspose.com/slides/net/aspose.slides/pictureframe/) ou remplissez une forme de filigrane avec une image. `PictureFrame` implémente l'interface [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape), vous permettant d'utiliser tous les paramètres flexibles de l'objet forme. Étant donné que `ITextFrame` n'est pas une forme et que ses paramètres sont limités, il est encapsulé dans un objet [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape).

Un filigrane peut être appliqué de deux manières : à une seule diapositive ou à toutes les diapositives de la présentation. Le Slide Master est utilisé pour appliquer un filigrane à toutes les diapositives de présentation : le filigrane est ajouté au Slide Master, entièrement conçu là-bas et appliqué à toutes les diapositives sans affecter l'autorisation de modifier le filigrane sur des diapositives individuelles.

Un filigrane est généralement considéré comme non modifiable par d'autres utilisateurs. Pour empêcher que le filigrane (ou plutôt la forme parente du filigrane) ne soit modifié, Aspose.Slides fournit une fonctionnalité de verrouillage de forme. Une forme spécifique peut être verrouillée sur une diapositive normale ou sur un Slide Master. Lorsque la forme de filigrane est verrouillée sur le Slide Master, elle sera verrouillée sur toutes les diapositives de présentation.

Vous pouvez définir un nom pour le filigrane afin que, à l'avenir, si vous souhaitez le supprimer, vous puissiez le trouver dans les formes de la diapositive par son nom.

Vous pouvez concevoir le filigrane de n'importe quelle manière ; cependant, il existe généralement des caractéristiques communes dans les filigranes, telles que l'alignement central, la rotation, la position à l'avant, etc. Nous allons considérer comment utiliser ces éléments dans les exemples ci-dessous.

## **Filigrane Texte**

### **Ajouter un Filigrane Texte à une Diapositive**

Pour ajouter un filigrane texte dans PPT, PPTX ou ODP, vous pouvez d'abord ajouter une forme à la diapositive, puis ajouter un cadre de texte à cette forme. Le cadre de texte est représenté par l'interface [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe). Ce type n'est pas hérité de [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), qui possède un large ensemble de propriétés pour positionner le filigrane de manière flexible. Par conséquent, l'objet [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe) est encapsulé dans un objet [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/). Pour ajouter le texte du filigrane à la forme, utilisez la méthode [AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe) comme indiqué ci-dessous.

```cs
string watermarkText = "CONFIDENTIEL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="Voir aussi" %}} 
- [Comment utiliser la classe TextFrame](/slides/net/text-formatting/)
{{% /alert %}}

### **Ajouter un Filigrane Texte à une Présentation**

Si vous souhaitez ajouter un filigrane texte à l'ensemble de la présentation (c'est-à-dire à toutes les diapositives à la fois), ajoutez-le au [MasterSlide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/). Le reste de la logique est le même que lorsqu'on ajoute un filigrane à une seule diapositive : créez un objet [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) et ajoutez ensuite le filigrane en utilisant la méthode [AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/methods/addtextframe).

```cs
string watermarkText = "CONFIDENTIEL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="primary" title="Voir aussi" %}} 
- [Comment utiliser le Slide Master](/slides/net/slide-master/)
{{% /alert %}}

### **Définir la Transparence de la Forme de Filigrane**

Par défaut, la forme rectangle est stylisée avec des couleurs de remplissage et de ligne. Les lignes de code suivantes rendent la forme transparente.

```cs
watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **Définir la Police pour un Filigrane Texte**

Vous pouvez changer la police du filigrane texte comme indiqué ci-dessous.

```cs
IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **Définir la Couleur du Texte du Filigrane**

Pour définir la couleur du texte du filigrane, utilisez ce code :

```cs
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **Centrer un Filigrane Texte**

Il est possible de centrer le filigrane sur une diapositive, et pour cela, vous pouvez faire ce qui suit :

```cs
SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

L'image ci-dessous montre le résultat final.

![Le filigrane texte](text_watermark.png)

## **Filigrane Image**

### **Ajouter un Filigrane Image à une Présentation**

Pour ajouter un filigrane image à une diapositive de présentation, vous pouvez faire ce qui suit :

```cs
using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **Verrouiller un Filigrane contre l'Édition**

S'il est nécessaire d'empêcher un filigrane d'être modifié, utilisez la propriété [IAutoShape.ShapeLock](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/properties/shapelock) sur la forme. Avec cette propriété, vous pouvez protéger la forme contre la sélection, le redimensionnement, le repositionnement, le regroupement avec d'autres éléments, verrouiller son texte contre modification, et bien plus encore :

```cs
// Verrouiller la forme de filigrane contre la modification
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **Amener un Filigrane au Premier Plan**

Dans Aspose.Slides, l'ordre Z des formes peut être défini via la méthode [IShapeCollection.Reorder](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/reorder/#reorder). Pour ce faire, vous devez appeler cette méthode à partir de la liste des diapositives de la présentation et passer la référence de la forme ainsi que son numéro d'ordre dans la méthode. De cette manière, il est possible d'amener une forme au premier plan ou de l'envoyer à l'arrière de la diapositive. Cette fonctionnalité est particulièrement utile si vous devez placer un filigrane devant la présentation :

```cs
int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **Définir la Rotation du Filigrane**

Voici un exemple de code montrant comment ajuster la rotation du filigrane afin qu'il soit positionné de manière diagonale sur la diapositive :

```cs
double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **Définir un Nom pour un Filigrane**

Aspose.Slides vous permet de définir le nom d'une forme. En utilisant le nom de la forme, vous pouvez y accéder à l'avenir pour la modifier ou la supprimer. Pour définir le nom de la forme de filigrane, assignez-le à la propriété [IAutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name) :

```cs
watermarkShape.Name = "watermark";
```

## **Supprimer un Filigrane**

Pour supprimer la forme de filigrane, utilisez la propriété [IAutoShape.Name](https://reference.aspose.com/slides/net/aspose.slides/ishape/properties/name) pour la trouver dans les formes de la diapositive. Ensuite, passez la forme de filigrane dans la méthode [IShapeCollection.Remove](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/remove/) :

```cs
List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(watermarkShape);
    }
}
```

## **Un Exemple en Direct**

Vous pouvez vouloir consulter **Aspose.Slides free** [Ajouter Filigrane](https://products.aspose.app/slides/watermark) et [Supprimer Filigrane](https://products.aspose.app/slides/watermark/remove-watermark) outils en ligne.

![Outils en ligne pour ajouter et supprimer des filigranes](online_tools.png)