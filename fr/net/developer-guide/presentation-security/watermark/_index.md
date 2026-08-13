---
title: Ajouter des filigranes aux présentations en .NET
linktitle: Filigrane
type: docs
weight: 40
url: /fr/net/watermark/
keywords:
- filigrane
- filigrane texte
- filigrane image
- ajouter un filigrane
- modifier le filigrane
- supprimer le filigrane
- effacer le filigrane
- ajouter un filigrane à PPT
- ajouter un filigrane à PPTX
- ajouter un filigrane à ODP
- supprimer le filigrane de PPT
- supprimer le filigrane de PPTX
- supprimer le filigrane de ODP
- effacer le filigrane de PPT
- effacer le filigrane de PPTX
- effacer le filigrane de ODP
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Gérez les filigranes texte et image dans les présentations PowerPoint et OpenDocument en .NET pour indiquer un brouillon, des informations confidentielles, des droits d’auteur, etc."
---
## **Introduction**

**Un filigrane** dans une présentation est un tampon texte ou image utilisé sur une diapositive ou sur toutes les diapositives de la présentation. Habituellement, un filigrane indique que la présentation est un brouillon (p. ex. un filigrane « Draft »), qu'elle contient des informations confidentielles (p. ex. un filigrane « Confidential »), précise à quelle entreprise elle appartient (p. ex. un filigrane « Company Name »), identifie l'auteur de la présentation, etc. Un filigrane aide à prévenir les violations de droits d’auteur en indiquant que la présentation ne doit pas être copiée. Les filigranes sont utilisés à la fois dans les formats de présentation PowerPoint et OpenDocument. Dans Aspose.Slides, vous pouvez ajouter un filigrane aux formats de fichier PowerPoint PPT, PPTX et OpenDocument ODP.

In [**Aspose.Slides**](https://products.aspose.com/slides/fr/net/), il existe plusieurs façons de créer des filigranes dans des documents PowerPoint ou OpenDocument et de modifier leur conception et leur comportement. L’aspect commun est que, pour ajouter des filigranes texte, vous devez utiliser l’interface [ITextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe/), et pour ajouter des filigranes image, utilisez la classe [PictureFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/pictureframe/) ou remplissez une forme de filigrane avec une image. `PictureFrame` implémente l’interface [IShape](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape), vous permettant d’utiliser tous les paramètres flexibles de l’objet forme. Comme `ITextFrame` n’est pas une forme et que ses paramètres sont limités, il est encapsulé dans un objet [IShape](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape).

Il existe deux manières d’appliquer un filigrane : sur une seule diapositive ou sur toutes les diapositives de la présentation. Le Masque des diapositives (Slide Master) est utilisé pour appliquer un filigrane à toutes les diapositives — le filigrane est ajouté au Masque des diapositives, entièrement conçu à cet endroit, et appliqué à toutes les diapositives sans affecter la permission de modifier le filigrane sur les diapositives individuelles.

Un filigrane est généralement considéré comme non modifiable par d’autres utilisateurs. Pour empêcher le filigrane (ou plutôt la forme parent du filigrane) d’être modifié, Aspose.Slides fournit une fonctionnalité de verrouillage des formes. Une forme spécifique peut être verrouillée sur une diapositive normale ou sur un Masque des diapositives. Lorsque la forme du filigrane est verrouillée sur le Masque des diapositives, elle sera verrouillée sur toutes les diapositives de la présentation.

Vous pouvez attribuer un nom au filigrane afin de pouvoir le retrouver plus tard dans les formes de la diapositive par son nom lorsqu’il faudra le supprimer.

Vous pouvez concevoir le filigrane comme vous le souhaitez ; cependant, il existe généralement des caractéristiques communes aux filigranes, telles que l’alignement centré, la rotation, la position en avant-plan, etc. Nous verrons comment les utiliser dans les exemples ci‑dessous.

## **Filigrane texte**

### **Ajouter un filigrane texte à une diapositive**

Pour ajouter un filigrane texte dans PPT, PPTX ou ODP, vous pouvez d’abord ajouter une forme à la diapositive, puis ajouter un cadre de texte à cette forme. Le cadre de texte est représenté par l’interface [ITextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe). Ce type n’est pas hérité de [IShape](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/), qui possède un large éventail de propriétés pour positionner le filigrane de manière flexible. Ainsi, l’objet [ITextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/itextframe) est enveloppé dans un objet [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/). Pour ajouter du texte de filigrane à la forme, utilisez la méthode [AddTextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/methods/addtextframe) comme indiqué ci‑dessous.

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

// Ajouter le filigrane à la diapositive.
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="Voir aussi" %}} 
- [Comment utiliser la classe TextFrame ?](/slides/fr/net/text-formatting/)
{{% /alert %}}

### **Ajouter un filigrane texte à une présentation**

Si vous souhaitez ajouter un filigrane texte à l’ensemble de la présentation (c’est‑à‑dire à toutes les diapositives en même temps), ajoutez‑le au [MasterSlide](https://reference.aspose.com/slides/fr/net/aspose.slides/masterslide/). Le reste de la logique est identique à celui de l’ajout d’un filigrane à une seule diapositive — créez un objet [IAutoShape](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/) puis ajoutez le filigrane en utilisant la méthode [AddTextFrame](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/methods/addtextframe).

```cs
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.Masters[0];

// Ajouter le filigrane à la diapositive maître.
IAutoShape watermarkShape = masterSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

{{% alert color="info" title="Voir aussi" %}} 
- [Comment utiliser le Masque des diapositives ?](/slides/fr/net/slide-master/)
{{% /alert %}}

### **Définir la transparence de la forme du filigrane**

Par défaut, la forme rectangulaire possède des couleurs de remplissage et de contour. Cela signifie que, lorsqu’il est ajouté, le filigrane peut apparaître avec un arrière‑plan ou une bordure solide qui pourrait détourner l’attention du contenu de la diapositive. Pour garantir que le filigrane reste discret et n’interfère pas avec le design visuel de la présentation, vous pouvez rendre la forme totalement transparente.

Les lignes de code suivantes rendent la forme transparente en supprimant à la fois sa couleur de remplissage et sa couleur de bordure :

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.FillFormat.FillType = FillType.NoFill;
watermarkShape.LineFormat.FillFormat.FillType = FillType.NoFill;
```

### **Définir la police pour un filigrane texte**

Avant d’appliquer le filigrane texte à votre diapositive, il est important de personnaliser son apparence afin qu’elle s’harmonise avec le design global. Vous pouvez modifier le type et la taille de la police pour garantir que le filigrane soit lisible et esthétiquement agréable. La personnalisation de la police peut également contribuer à renforcer l’identité de la marque ou simplement à correspondre au style de la présentation.

Le fragment de code ci‑dessous montre comment ajuster les paramètres de police du filigrane en sélectionnant une police latine spécifique et en définissant une hauteur de police appropriée :

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat;
textFormat.LatinFont = new FontData("Arial");
textFormat.FontHeight = 50;
```

### **Définir la couleur du texte du filigrane**

Avant d’appliquer votre filigrane, il est essentiel de veiller à ce que la couleur du texte soit correctement définie afin qu’elle se fondre bien avec le contenu de la diapositive sans le dominer. Ajuster la transparence de la couleur (alpha) ainsi que les composantes rouge, verte et bleue vous permet de créer un filigrane subtil et semi‑transparent, visible mais discret. Cette approche aide à garder l’attention sur votre présentation principale tout en protégeant votre contenu.

Pour définir la couleur du texte du filigrane, utilisez le code suivant :

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.AddTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.Paragraphs[0].ParagraphFormat.DefaultPortionFormat.FillFormat;
fillFormat.FillType = FillType.Solid;
fillFormat.SolidFillColor.Color = Color.FromArgb(alpha, red, green, blue);
```

### **Centrer un filigrane texte**

Centrer correctement votre filigrane texte peut améliorer considérablement l’esthétique globale de votre présentation en garantissant que le filigrane est positionné symétriquement, quelle que soit la taille de la diapositive. Cette méthode confère à vos diapositives un aspect professionnel tout en veillant à ce que le filigrane n’interfère pas avec le contenu principal de la diapositive.

Le fragment de code ci‑dessous montre comment calculer la position centrale d’une diapositive et placer le filigrane texte en conséquence :

```cs
using System.Drawing;
using Aspose.Slides;

string watermarkText = "CONFIDENTIAL";

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

SizeF slideSize = presentation.SlideSize.Size;

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = (slideSize.Width - watermarkWidth) / 2;
float watermarkY = (slideSize.Height - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.Shapes.AddAutoShape(
    ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.AddTextFrame(watermarkText);
```

L’image ci‑dessous montre le résultat final.

![Le filigrane texte](text_watermark.png)

## **Filigrane image**

### **Ajouter un filigrane image à une présentation**

Dans de nombreux cas, un filigrane image peut offrir un élément de marque unique ou une alternative visuellement plus attrayante à un filigrane texte. Avant d’ajouter le filigrane, assurez‑vous que le fichier image est disponible (p. ex. PNG pour la transparence). L’exemple suivant montre comment charger une image depuis votre système de fichiers, l’ajouter à la présentation, puis l’appliquer comme filigrane en utilisant les propriétés de remplissage de la forme.

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

using FileStream imageStream = File.OpenRead("watermark.png");
IPPImage image = presentation.Images.AddImage(imageStream);

watermarkShape.FillFormat.FillType = FillType.Picture;
watermarkShape.FillFormat.PictureFillFormat.Picture.Image = image;
watermarkShape.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
```

## **Verrouiller un filigrane contre la modification**

S’il est nécessaire d’empêcher la modification d’un filigrane, utilisez la propriété [IAutoShape.ShapeLock](https://reference.aspose.com/slides/fr/net/aspose.slides/iautoshape/properties/shapelock) sur la forme. Avec cette propriété, vous pouvez protéger la forme contre la sélection, le redimensionnement, le repositionnement, le groupement avec d’autres éléments, verrouiller son texte contre la modification, et bien plus encore :

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// Verrouiller la forme du filigrane pour empêcher toute modification.
watermarkShape.ShapeLock.SelectLocked = true;
watermarkShape.ShapeLock.SizeLocked = true;
watermarkShape.ShapeLock.TextLocked = true;
watermarkShape.ShapeLock.PositionLocked = true;
watermarkShape.ShapeLock.GroupingLocked = true;
```

## **Amener un filigrane à l’avant‑plan**

Dans Aspose.Slides, l’ordre Z des formes peut être défini via la méthode [IShapeCollection.Reorder](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapecollection/reorder/#reorder). Pour ce faire, vous devez appeler cette méthode depuis la liste des diapositives de la présentation en y passant la référence de la forme et son numéro d’ordre. Ainsi, il est possible de placer une forme au premier plan ou de l’envoyer à l’arrière de la diapositive. Cette fonctionnalité est particulièrement utile si vous devez placer un filigrane au premier plan de la présentation :

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.Shapes.Count;
slide.Shapes.Reorder(shapeCount - 1, watermarkShape);
```

## **Définir la rotation du filigrane**

Modifier la rotation de votre filigrane peut grandement améliorer l’impact visuel et la discrétion de votre présentation. Un filigrane diagonal, par exemple, peut être moins intrusif tout en offrant une protection solide contre l’utilisation non autorisée. L’exemple suivant calcule l’angle approprié en fonction des dimensions de la diapositive afin que le filigrane soit positionné en diagonale sur la diapositive. Ce calcul dynamique garantit que le filigrane reste efficace quel que soit le format des diapositives.

```cs
using System.Drawing;
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

SizeF slideSize = presentation.SlideSize.Size;

double diagonalAngle = Math.Atan((slideSize.Height / slideSize.Width)) * 180 / Math.PI;

watermarkShape.Rotation = (float)diagonalAngle;
```

## **Attribuer un nom à un filigrane**

Aspose.Slides vous permet de définir le nom d’une forme. En utilisant le nom de la forme, vous pouvez y accéder ultérieurement pour la modifier ou la supprimer. Pour attribuer un nom à la forme du filigrane, affectez‑le à la propriété [IAutoShape.Name](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/properties/name) :

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];
IAutoShape watermarkShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.Name = "watermark";
```

## **Supprimer un filigrane**

Pour supprimer la forme du filigrane, utilisez la propriété [IAutoShape.Name](https://reference.aspose.com/slides/fr/net/aspose.slides/ishape/properties/name) afin de la repérer parmi les formes de la diapositive. Ensuite, passez la forme du filigrane à la méthode [IShapeCollection.Remove](https://reference.aspose.com/slides/fr/net/aspose.slides/ishapecollection/remove/) :

```cs
using Aspose.Slides;

using Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

List<IShape> slideShapes = slide.Shapes.ToList();
foreach (IShape shape in slideShapes)
{
    if (string.Compare(shape.Name, "watermark", StringComparison.Ordinal) == 0)
    {
        slide.Shapes.Remove(shape);
    }
}
```

## **Un exemple en direct**

Vous pouvez consulter les outils en ligne **Aspose.Slides free** [Ajouter un filigrane](https://products.aspose.app/slides/fr/watermark) et [Supprimer le filigrane](https://products.aspose.app/slides/fr/watermark/remove-watermark).

![Outils en ligne pour ajouter et supprimer des filigranes](online_tools.png)

## **FAQ**

### Qu’est‑ce qu’un filigrane et pourquoi l’utiliser ?

Un filigrane est une superposition texte ou image appliquée aux diapositives qui aide à protéger la propriété intellectuelle, à renforcer la reconnaissance de la marque ou à empêcher l’utilisation non autorisée des présentations.

### Puis‑je ajouter un filigrane à toutes les diapositives d’une présentation ?

Oui, Aspose.Slides vous permet d’ajouter programmétiquement un filigrane à chaque diapositive d’une présentation. Vous pouvez parcourir toutes les diapositives et appliquer les paramètres du filigrane individuellement.

### Comment ajuster la transparence du filigrane ?

Vous pouvez ajuster la transparence du filigrane en modifiant les paramètres de remplissage ([FillFormat](https://reference.aspose.com/slides/fr/net/aspose.slides/shape/fillformat/)) de la forme. Cela garantit que le filigrane reste discret et n’attire pas l’attention du contenu de la diapositive.

### Quels formats d’image sont pris en charge pour les filigranes ?

Aspose.Slides prend en charge divers formats d’image tels que PNG, JPEG, GIF, BMP, SVG, etc.

### Puis‑je personnaliser la police et le style d’un filigrane texte ?

Oui, vous pouvez choisir n’importe quelle police, taille et style pour correspondre au design de votre présentation et maintenir la cohérence de la marque.

### Comment modifier la position ou l’orientation d’un filigrane ?

Vous pouvez modifier la position et l’orientation du filigrane programmétiquement en ajustant les coordonnées, la taille et les propriétés de rotation de la forme.